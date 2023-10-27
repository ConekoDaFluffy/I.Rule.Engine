using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IRule.Engine
{
    /// <summary>
    /// Class to have animate sprites!
    /// </summary>
    public class Animator
    {
        public Texture2D texture;
        public string AnimationName
        {
            get => _animationName;
            private set => _animationName = value;
        }
        private string _animationName;

        public Animation Animation
        {
            get
            {
                return animations[AnimationName];
            }
        }

        public float frame;
        private int frameWidth;
        private int frameHeight;
        private float fps;

        public bool Ended
        {
            get => _ended;
            private set => _ended = value;
        }
        private bool _ended = false;

        private Dictionary<string, Animation> animations;

        public Animator(Texture2D newTexture, List<Animation> newAnimations, int width, int height, float framesPerSecond)
        {
            animations = new Dictionary<string, Animation>();
            fps = framesPerSecond;
            texture = newTexture;
            frameWidth = width;
            frameHeight = height;
            foreach (Animation anim in newAnimations)
            {
                animations.Add(anim.name, anim);
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                Point Position = new Point();
                Position.X = ((int)frame) * frameWidth;
                Position.Y += (frameHeight * Animation.gridY);

                Point Size = new Point(frameWidth, frameHeight);
                Rectangle rectangle = new Rectangle(Position, Size);

                return rectangle;
            }
        }

        public void ChangeAnimation(string newAnimation, bool force = false)
        {
            if (!force && (AnimationName == newAnimation))
            {
                return;
            }
            AnimationName = newAnimation;
            Ended = false;
            frame = 0;
        }

        public void Update(GameTime gameTime)
        {
            frame = (frame + (fps / 60f));

            if (frame > Animation.frames)
            {
                Ended = true;
                frame -= Animation.frames;
            }
        }
    }
}