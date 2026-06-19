using Pug.Platform;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class LoadSystem : SystemBase
{
	private FilesystemManager.File saveFile;

	private EntityQuery loadingQ;

	private EntityQuery loadingDoneQ;

	private Entity dummyLoadingEntity;

	private bool saveFileExists;

	[Preserve]
	protected override void OnCreate()
	{
		loadingQ = GetEntityQuery(typeof(InitialLoadingCD));
		loadingDoneQ = GetEntityQuery(typeof(InitialLoadingDoneCD));
		dummyLoadingEntity = base.EntityManager.CreateEntity(typeof(InitialLoadingCD));
		RequireForUpdate(loadingQ);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		using (EntityQuery entityQuery = base.EntityManager.CreateEntityQuery(typeof(ServerSaveIdCD)))
		{
			if (entityQuery.IsEmpty)
			{
				Debug.LogError("no save id in server world");
				Manager.load.ExitGame();
				base.World.QuitUpdate = true;
				return;
			}
			int value = entityQuery.GetSingleton<ServerSaveIdCD>().Value;
			saveFile = Manager.filesystemManager.GetFile(FilesystemManager.FileID.WorldSave, value);
		}
		Entity entity = base.EntityManager.CreateEntity(typeof(DeserializeWorldTriggerCD), typeof(InitialLoadingCD));
		base.EntityManager.SetComponentData(entity, new DeserializeWorldTriggerCD
		{
			file = saveFile
		});
		if (dummyLoadingEntity != Entity.Null)
		{
			base.EntityManager.DestroyEntity(dummyLoadingEntity);
			dummyLoadingEntity = Entity.Null;
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		if (loadingQ.IsEmpty && loadingDoneQ.IsEmpty)
		{
			base.EntityManager.CreateEntity(typeof(InitialLoadingDoneCD));
			base.Enabled = false;
		}
		base.OnStopRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
	}

	[Preserve]
	public LoadSystem()
	{
	}
}
