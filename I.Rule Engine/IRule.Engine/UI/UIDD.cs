using Microsoft.Xna.Framework;

namespace IRule.Engine.UI
{
    /// <summary>
    /// User Interface Dimension Data
    /// </summary>
    public struct UIDD
    {
        public Point Offset;
        public Vector2 Scale;

        public UIDD(int X, int Y, float scaleX, float scaleY)
        {
            Offset = new Point(X, Y);
            Scale = new Vector2(scaleX, scaleY);
        }

        public static UIDD FromScale(float scaleX, float scaleY)
        {
            return new UIDD(0, 0, scaleX, scaleY);
        }

        public static UIDD FromOffset(float scaleX, float scaleY)
        {
            return new UIDD(0, 0, scaleX, scaleY);
        }
    }
}