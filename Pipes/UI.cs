using Microsoft.Xna.Framework;
using Nez;

namespace Flappy.Pipes
{
    internal class UI : Component, IUpdatable
    {
        TextComponent _scoreText;
        TextComponent _restartText;
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();

            _scoreText = Entity.AddComponent(new TextComponent());
            _scoreText.SetText("Score: 0");

            _restartText = Entity.AddComponent(new TextComponent());
            _restartText.SetText("Game Over - R to Restart");


            _scoreText.Transform.SetLocalScale(2);
            _scoreText.RenderLayer = -1;
            _scoreText.SetLocalOffset(new Vector2(Entity.Scene.SceneRenderTargetSize.X - _scoreText.Width * 2.2f, 20));


            _restartText.Enabled = false;
            _restartText.RenderLayer = -1;
            _restartText.SetLocalOffset(new Vector2(Entity.Scene.SceneRenderTargetSize.X / 2 - _restartText.Width / 2, Entity.Scene.SceneRenderTargetSize.Y / 2));
        }

        void IUpdatable.Update()
        {
            _scoreText.SetText("Score: " + GameState.Score);

            if (GameState.Playing == false)
            {
                _restartText.Enabled = true;
            }
        }
    }
}
