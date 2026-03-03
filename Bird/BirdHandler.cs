using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace Flappy.Bird
{
    internal class BirdHandler : Component, IUpdatable
    {
        float _gravity = 1000f;
        float _jumpForce = -400f;

        Texture2D _midFlap;
        Texture2D _downFlap;
        Texture2D _upFlap;

        Vector2 _velocity;

        SpriteRenderer _renderer;

        ColliderTriggerHelper _triggerHelper;
        public override void Initialize()
        {
            base.Initialize();
            _upFlap = Entity.Scene.Content.LoadTexture("Content/upflap.png");
            _midFlap = Entity.Scene.Content.LoadTexture("Content/midflap.png");
            _downFlap = Entity.Scene.Content.LoadTexture("Content/downflap.png");

        }
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            _renderer = Entity?.AddComponent(new SpriteRenderer(_midFlap));
            var collider = Entity.AddComponent(new BoxCollider(20, 20));
            collider.IsTrigger = true;
            _triggerHelper = new ColliderTriggerHelper(Entity);
        }

        void IUpdatable.Update()
        {
            _velocity.Y += _gravity * Time.DeltaTime;

            if (Input.IsKeyPressed(Keys.Space))
            {
                _velocity.Y = _jumpForce;
            }

            Entity.Position += _velocity * Time.DeltaTime;

            if (_velocity.Y < -100f)
            {
                _renderer.Sprite = new Nez.Textures.Sprite(_downFlap);
            }
            else if (_velocity.Y > 100f)
            {
                _renderer.Sprite = new Nez.Textures.Sprite(_upFlap);
            }
            else
            {
                _renderer.Sprite = new Nez.Textures.Sprite(_midFlap);
            }

            if (Entity.Position.Y <= 0 || Entity.Position.Y >= Entity.Scene.SceneRenderTargetSize.Y)
            {
                Entity.Destroy();
                GameState.GameOver();
            }
            _triggerHelper.Update();
        }
    }
}
