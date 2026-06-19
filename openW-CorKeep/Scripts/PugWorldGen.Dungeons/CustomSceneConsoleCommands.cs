using Pug.UnityExtensions;
using QFSW.QC;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

public static class CustomSceneConsoleCommands
{
	[Preserve]
	[Command("spawnCustomScene", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SpawnCustomScene([CustomSceneName] string sceneName)
	{
		if (Manager.main.player == null)
		{
			Manager.menu.quantumConsole.LogToConsole("Must be in a world to spawn a custom scene.");
		}
		else
		{
			SpawnCustomScene(sceneName, Manager.main.player.WorldPosition);
		}
	}

	[Preserve]
	[Command("spawnCustomScene", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SpawnCustomScene([CustomSceneName] string sceneName, Vector3 worldPosition)
	{
		World serverWorld = Manager.ecs.ServerWorld;
		if (serverWorld == null)
		{
			Manager.menu.quantumConsole.LogToConsole("Custom scenes can only be spawned by the server host.");
			return;
		}
		Entity entity = serverWorld.EntityManager.CreateEntity();
		serverWorld.EntityManager.AddComponentData(entity, LocalTransform.FromPosition(worldPosition));
		serverWorld.EntityManager.AddComponentData(entity, new SpawnCustomSceneCD
		{
			name = sceneName,
			seed = PugRandom.GetSeed()
		});
	}
}
