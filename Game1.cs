using Flappy.Scenes;

namespace Flappy
{
    public class Game1 : Nez.Core
    {
        protected override void Initialize()
        {
            base.Initialize();
            Scene = new BasicScene();
        }
    }
}
