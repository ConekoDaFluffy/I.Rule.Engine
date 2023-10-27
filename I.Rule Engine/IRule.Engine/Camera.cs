using Microsoft.Xna.Framework;

namespace IRule.Engine
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public void MoveTo(Vector2 newPosition)
        {
            var position = Matrix.CreateTranslation(
              -newPosition.X,
              -newPosition.Y,
              0);
            var offset = Matrix.CreateTranslation(
                Main.ScreenWidth / 2,
                Main.ScreenHeight / 2,
                0);
            Transform = position * offset;
        }

        public void Center()
        {
            MoveTo(new Vector2(Main.ScreenWidth / 2, Main.ScreenHeight / 2));
        }
    }
}