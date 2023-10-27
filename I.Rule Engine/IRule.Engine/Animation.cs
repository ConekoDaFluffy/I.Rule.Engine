namespace IRule.Engine
{
    /// <summary>
    /// Data about an animation
    /// </summary>
    public struct Animation
    {
        public string name;
        public int gridX, gridY;
        public int frames;

        public Animation(string animName, int animX, int animY, int animFrames)
        {
            name = animName;
            gridX = animX;
            gridY = animY;
            frames = animFrames;
        }
    }
}