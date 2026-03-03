using Nez;

namespace Flappy.Pipes
{
    internal class ScoreCollider(int width, int height) : Component, ITriggerListener
    {
        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            Entity.AddComponent(new BoxCollider(width, height));
        }
        void ITriggerListener.OnTriggerEnter(Collider other, Collider local)
        {

        }

        void ITriggerListener.OnTriggerExit(Collider other, Collider local)
        {
            GameState.AddScore(1);
        }
    }
}
