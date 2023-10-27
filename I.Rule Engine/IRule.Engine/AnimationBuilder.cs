using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IRule.Engine
{
    /// <summary>
    /// Class to make animator class making comfier
    /// </summary>
    public class AnimationBuilder
    {
        public int frameWidth;
        public int frameHeight;
        public int framesPerSecond;

        public List<Animation> animations;

        public AnimationBuilder(int frameW, int frameH, int fps)
        {
            framesPerSecond = fps;
            frameWidth = frameW;
            frameHeight = frameH;
            animations = new List<Animation>();
        }

        public void AddAnimation(string name, int gridY, int frames)
        {
            Animation newAnimation = new Animation(name, 0, gridY, frames);
            animations.Add(newAnimation);
        }

        public Animator Build(Texture2D texture)
        {
            Animator animator = new Animator(texture, animations, frameWidth, frameHeight, framesPerSecond);
            return animator;
        }
    }
}