using IRule.Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace IRule.Engine
{
    public class Room
    {
        public List<GameObject> GameObjects;
        public UIElement UI;
        public bool depthIsOutdated = false;

        public Room()
        {
            GameObjects = new List<GameObject>();
            UI = new UIElement();
            UI.Size = UIDD.FromOffset(Main.ScreenWidth, Main.ScreenHeight);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject go = GameObjects[i];

                if (go._destroyed)
                {
                    GameObjects.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject go = GameObjects[i];
                go.Update(gameTime);
            }

            if (depthIsOutdated)
            {
                UpdateDepth();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject go = GameObjects[i];

                if (!go.visible)
                {
                    continue;
                }

                go.Draw(spriteBatch);
            }
        }

        void UpdateDepth()
        {
            GameObjects.Sort((a, b) =>
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

        public void AddGameobject(GameObject gameObject)
        {
            gameObject.room = this;

            if (GameObjects.Contains(gameObject))
            {
                return;
            }

            depthIsOutdated = true;
            GameObjects.Add(gameObject);
        }

        public void Destroy()
        {
            foreach (GameObject go in GameObjects)
            {
                go.Destroy();
            }

            GameObjects.Clear();
        }
    }
}