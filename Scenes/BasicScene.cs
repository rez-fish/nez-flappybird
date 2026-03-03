using Flappy.Bird;
using Flappy.Pipes;
using Microsoft.Xna.Framework;
using Nez;

namespace Flappy.Scenes;

public class BasicScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();
        AddRenderer(new DefaultRenderer());
        //Core.DebugRenderEnabled = true;

        SetDesignResolution(288, 512, SceneResolutionPolicy.ShowAllPixelPerfect);
        Screen.SetSize(288 * 2, 512 * 2);

        var bird = CreateEntity("bird", new Vector2(100, 256));
        bird.AddComponent(new BirdHandler());

        var spawner = CreateEntity("spawner");
        spawner.AddComponent(new PipeSpawner());

        var ui = CreateEntity("ui");
        ui.AddComponent(new UI());
    }

    public override void Update()
    {
        base.Update();
        if (GameState.Playing == true) return;
        if (Input.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
        {
            GameState.Reset();
        }
    }
}