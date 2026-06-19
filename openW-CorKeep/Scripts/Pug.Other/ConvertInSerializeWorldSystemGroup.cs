using Pug.Properties;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[DisableAutoCreation]
public class ConvertInSerializeWorldSystemGroup : ComponentSystemGroup
{
	public World ServerWorld;

	[Preserve]
	[Preserve]
	public ConvertInSerializeWorldSystemGroup()
	{
	}

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		AddSystemToUpdateList(WorldExtensions.CreateSystem<ConvertCookedFoodsSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<CheckForReappearedGreatWallSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<FixDuplicateSubMapConvertSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<UpdateExplodingWallThresholdSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<ReplaceAbyssTreeSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<AddMissingGroundUnderOasisWallsSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<FixSwappedPetTalentsSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<DestroyNoneDroppedItemsSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<DestroyClumpedItemsSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<ConvertSingleSlotCraftersSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<RemoveFloatingOreSystem>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<AddEchoMapMarkersToSpawnedDungeons>(base.World));
		AddSystemToUpdateList(WorldExtensions.CreateSystem<ConvertContentBundlesToDataBlocksSystem>(base.World));
		AddSystemToUpdateList(base.World.CreateSystemManaged<DefaultConvertSystem>());
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		DefaultConvertSystem existingSystemManaged = base.World.GetExistingSystemManaged<DefaultConvertSystem>();
		using EntityQuery entityQuery = ServerWorld.EntityManager.CreateEntityQuery(typeof(DatabaseCD));
		if (entityQuery.IsEmpty)
		{
			Debug.LogError("No DatabaseCD found in server world");
		}
		else
		{
			existingSystemManaged.NewDatabase = entityQuery.GetSingleton<DatabaseCD>();
		}
		base.OnStartRunning();
	}
}
