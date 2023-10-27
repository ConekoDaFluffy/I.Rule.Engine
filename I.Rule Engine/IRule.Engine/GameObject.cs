using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IRule.Engine
{
    public class GameObject
    {
        public Vector2 Position;
        public int Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                if (room != null)
                {
                    room.depthIsOutdated = true;
                }
                _depth = value;
            }
        }
        int _depth;

        public Room room;
        public bool _destroyed
        {
            get { return _destroyed; }
            set { _destroyed = true; }
        }
        public bool visible = false;

        public virtual void Create() { }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        public virtual void Destroy()
        {
            if (_destroyed == true)
            {
                return;
            }
            _destroyed = true;
            room = null;
        }

        public bool IsOfType<T>()
        {
            bool isSubclass = GetType().IsSubclassOf(typeof(T));
            bool isClass = GetType() == typeof(T);

            return isSubclass || isClass;
        }
    }
}