using Nez;

namespace Flappy.Pipes
{
    internal class PipeSpawner : Component, IUpdatable
    {
        float _timer;
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            Entity.AddComponent(new PipeHandler());
        }

        void IUpdatable.Update()
        {
            _timer += Time.DeltaTime;
            if (_timer >= 2)
            {
                Entity.AddComponent(new PipeHandler());
                _timer = 0;
            }
        }
    }
}
