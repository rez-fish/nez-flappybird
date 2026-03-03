using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Flappy.Pipes
{
    internal class PipeHandler : Component, IUpdatable
    {
        Texture2D _pipeTexture;
        SpriteRenderer _topPipe;
        SpriteRenderer _bottomPipe;
        Entity _topPipeEnt;
        Entity _bottomPipeEnt;
        Entity _scoreCollider;
        ColliderTriggerHelper _triggerHelper;

        public override void Initialize()
        {
            base.Initialize();
            _pipeTexture = Entity.Scene.Content.LoadTexture("Content/pipe-green.png");
        }
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            var seed = Random.NextFloat();
            _topPipeEnt = Entity.Scene.CreateEntity("top-pipe", new Vector2(Screen.Width, 0 + Mathf.Lerp(-100, 150, seed))); // Can go from -100 to 150
            _topPipeEnt.AddComponent(new PipeCollider());
            _topPipe = _topPipeEnt.AddComponent(new SpriteRenderer(_pipeTexture));
            _topPipe.FlipY = true;

            _bottomPipeEnt = Entity.Scene.CreateEntity("top-pipe", new Vector2(Screen.Width, Screen.Height - Mathf.Lerp(650, 400, seed))); // Can go from 400 to 650
            _bottomPipeEnt.AddComponent(new PipeCollider());
            _bottomPipe = _bottomPipeEnt.AddComponent(new SpriteRenderer(_pipeTexture));

            _scoreCollider = Entity.Scene.CreateEntity("score-collider", new Vector2(Screen.Width, _bottomPipeEnt.LocalPosition.Y - (_bottomPipe.Height - 83)));
            _scoreCollider.AddComponent(new ScoreCollider(_pipeTexture.Width, 150));

        }
        void IUpdatable.Update()
        {
            _bottomPipeEnt.Position -= new Vector2(100, 0) * Time.DeltaTime;
            _topPipeEnt.Position -= new Vector2(100, 0) * Time.DeltaTime;
            _scoreCollider.Position -= new Vector2(100, 0) * Time.DeltaTime;

            Debug.Log("Entity count: " + Entity.Scene.Entities.Count);

            if (_bottomPipeEnt.IsDestroyed && _topPipeEnt.IsDestroyed) return;

            if (_bottomPipeEnt.Position.X <= 0 - _pipeTexture.Width && _topPipeEnt?.Position.X <= 0 - _pipeTexture.Width)
            {
                _bottomPipeEnt.Destroy();
                _topPipeEnt.Destroy();
                _scoreCollider.Destroy();
            }
        }
    }
}
