using IRule.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IRule
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Room Room
        {
            get
            {
                return Room;
            }
            set
            {
                if (Room != null)
                {
                    Room.Destroy();
                }
                Room = value;
                camera.Center();
            }
        }

        public static Camera camera = new Camera();
        public static int ScreenWidth
        {
            get
            {
                return ScreenSize.X;
            }
        }
        public static int ScreenHeight
        {
            get
            {
                return ScreenSize.Y;
            }
        }

        private static Point ScreenSize = new Point(1, 1);

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Room = new Room();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            ScreenSize.X = Window.ClientBounds.X;
            ScreenSize.Y = Window.ClientBounds.Y;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: camera.Transform, samplerState: SamplerState.PointClamp);
            Room.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}