using Nez;

namespace Flappy.Pipes
{
    internal class PipeCollider : Component, ITriggerListener
    {
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            Entity.AddComponent(new BoxCollider());
        }
        void ITriggerListener.OnTriggerEnter(Collider other, Collider local)
        {
            if (other.Entity.IsDestroyed) return;
            other.Entity.Destroy();
            GameState.GameOver();
        }

        void ITriggerListener.OnTriggerExit(Collider other, Collider local)
        {

        }
    }
}
