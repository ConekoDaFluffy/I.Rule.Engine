using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IRule.Engine.UI
{
    public class UIElement
    {
        public UIDD Position;
        public UIDD Size;
        public List<UIElement> Children;

        public Rectangle DrawRectangle
        {
            get
            {
                int spaceX = Main.ScreenWidth;
                int spaceY = Main.ScreenHeight;

                if (Parent != null)
                {
                    Rectangle space = Parent.DrawRectangle;
                    spaceX = space.X;
                    spaceY = space.Y;
                }

                Rectangle result = new Rectangle();
                result.X = (int)(Position.Offset.X + (spaceX * Position.Scale.X));
                result.Y = (int)(Position.Offset.Y + (spaceY * Position.Scale.Y));

                result.Width = (int)(Size.Offset.X + (spaceX * Size.Scale.X));
                result.Height = (int)(Size.Offset.Y + (spaceY * Size.Scale.Y));

                return result;
            }
        }

        public int Depth
        {
            get => Depth;
            set
            {
                if (value != Depth && Parent != null)
                {
                    Parent.shouldUpdateDepth = true;
                }
                Depth = value;
            }
        }
        public UIElement Parent;
        public bool _destroyed
        {
            get { return _destroyed; }
            set
            {
                _destroyed = true;
            }
        }
        public bool shouldUpdateDepth = false;

        public virtual void Update()
        {

            for (int i = 0; i < Children.Count; i++)
            {
                UIElement element = Children[i];

                if (!element._destroyed)
                {
                    continue;
                }

                Children.RemoveAt(i);
                i--;
            }

            for (int i = 0; i < Children.Count; i++)
            {
                UIElement element = Children[i];
                element.Update();
            }

            if (shouldUpdateDepth)
            {
                UpdateDepth();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                UIElement element = Children[i];
                element.Draw(spriteBatch);
            }
        }


        public void AddElement(UIElement element)
        {
            element.Parent = this;

            if (Children.Contains(element))
            {
                return;
            }
            shouldUpdateDepth = true;
            Children.Add(element);
        }

        public void Destroy()
        {
            if (_destroyed)
            {
                return;
            }

            _destroyed = true;
        }

        void UpdateDepth()
        {
            Children.Sort((a, b) =>
            {
                if (a.Depth == b.Depth)
                {
                    return 0;
                }

                if (a.Depth > b.Depth)
                {
                    return -1;
                }
                return 1;
            });
        }
    }
}