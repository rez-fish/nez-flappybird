namespace Flappy
{
    internal class GameState
    {
        public static int Score = 0;
        public static bool Playing = true;

        public static void GameOver()
        {
            Playing = false;
        }
        public static void AddScore(int amount)
        {
            Score += amount;
        }

        public static void Reset()
        {
            Playing = true;
            Score = 0;
            Nez.Core.Scene = new Flappy.Scenes.BasicScene();
        }
    }
}
