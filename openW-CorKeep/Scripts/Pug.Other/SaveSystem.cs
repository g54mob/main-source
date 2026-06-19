using Inventory;
using PlayerCommand;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[DisableAutoCreation]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class SaveSystem : SystemBase
{
	private EntityQuery serializeTriggerQ;

	private EntityQuery initialLoadingDoneQ;

	private float timeUntilSave;

	private bool skipSave;

	private bool saveIsPending;

	public bool SaveIsPending => saveIsPending;

	[Preserve]
	protected override void OnCreate()
	{
		timeUntilSave = ((PlatformConfiguration.Instance != null) ? ((float)PlatformConfiguration.Instance.SessionConfiguration.AutoSaveInterval) : 60f);
		serializeTriggerQ = GetEntityQuery(typeof(SerializeWorldSystem.SerializeWorld));
		initialLoadingDoneQ = GetEntityQuery(typeof(InitialLoadingDoneCD));
		RequireForUpdate(initialLoadingDoneQ);
		if (CommandLineArgs.Has("-disableautosave"))
		{
			base.Enabled = false;
		}
		base.OnCreate();
	}

	public void QueueNewSave()
	{
		EntityCommandBuffer entityCommandBuffer = base.World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>().CreateCommandBuffer();
		Entity e = entityCommandBuffer.CreateEntity();
		entityCommandBuffer.AddComponent(e, default(SerializeWorldSystem.SerializeWorld));
	}

	public void Save()
	{
		skipSave = false;
		if (initialLoadingDoneQ.IsEmpty)
		{
			skipSave = true;
			return;
		}
		if (saveIsPending)
		{
			Debug.LogError("Already triggered save");
			return;
		}
		base.World.Unmanaged.ResolveSystemStateRef(WorldExtensions.GetExistingSystem<InventoryUpdateSystem>(base.World)).Enabled = false;
		base.World.GetExistingSystemManaged<ServerSystem>().Enabled = false;
		Entity entity = base.EntityManager.CreateEntity(typeof(BlockSaveCD), typeof(BlockSaveTimerCD));
		base.EntityManager.SetComponentData(entity, new BlockSaveTimerCD
		{
			Value = 1.2f
		});
		base.EntityManager.CreateEntity(typeof(SerializeWorldSystem.SerializeWorld));
		saveIsPending = true;
	}

	public bool SaveDone()
	{
		if (skipSave)
		{
			return true;
		}
		if (!saveIsPending)
		{
			Debug.LogError("Waiting for save, but no save triggered");
			return true;
		}
		saveIsPending = !serializeTriggerQ.IsEmpty;
		if (!saveIsPending)
		{
			SystemHandle existingSystem = base.World.GetExistingSystem<SerializationSystemGroup>();
			SystemHandle existingSystem2 = base.World.GetExistingSystem<BeginSimulationEntityCommandBufferSystem>();
			existingSystem.Update(base.World.Unmanaged);
			existingSystem2.Update(base.World.Unmanaged);
			existingSystem.Update(base.World.Unmanaged);
		}
		return !saveIsPending;
	}

	[Preserve]
	protected override void OnUpdate()
	{
		timeUntilSave -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (timeUntilSave <= 0f && !saveIsPending)
		{
			QueueNewSave();
			timeUntilSave = ((PlatformConfiguration.Instance != null) ? ((float)PlatformConfiguration.Instance.SessionConfiguration.AutoSaveInterval) : 60f);
		}
	}

	[Preserve]
	public SaveSystem()
	{
	}
}
