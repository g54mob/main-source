using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class EntityPrespawnSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1310928531_0;

	private EntityQuery __query_1310928531_1;

	public Entity CreatePrespawnEntity(ObjectDataCD objectData, float3 position, float3 direction = default(float3))
	{
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_1310928531_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankBlob, objectData.variation);
		if (primaryPrefabEntity == Entity.Null)
		{
			return Entity.Null;
		}
		Entity entity = base.EntityManager.Instantiate(primaryPrefabEntity);
		base.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(EntityMonoBehaviour.ToWorldFromRender(position)));
		if (base.EntityManager.HasComponent<DirectionCD>(primaryPrefabEntity) && math.any(direction != float3.zero))
		{
			base.EntityManager.SetComponentData(entity, new DirectionCD
			{
				direction = direction
			});
		}
		ref GhostPrefabBlobMetaData value = ref base.EntityManager.GetComponentData<GhostPrefabMetaData>(primaryPrefabEntity).Value.Value;
		if (value.SupportedModes == GhostPrefabBlobMetaData.GhostMode.Both && value.DefaultMode != GhostPrefabBlobMetaData.GhostMode.Both)
		{
			__query_1310928531_1.GetSingletonRW<GhostPredictionSwitchingQueues>().ValueRW.ConvertToInterpolatedQueue.Enqueue(new ConvertPredictionEntry
			{
				TargetEntity = entity,
				TransitionDurationSeconds = 0f
			});
		}
		return entity;
	}

	public Entity CreatePrespawnEntityWithoutSwitchingToInterpolation(EntityCommandBuffer ecb, ObjectDataCD objectData, float3 position, out Entity prefabEntity, float3 direction = default(float3))
	{
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_1310928531_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		prefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankBlob, objectData.variation);
		if (prefabEntity == Entity.Null)
		{
			return Entity.Null;
		}
		Entity entity = ecb.Instantiate(prefabEntity);
		ecb.SetComponent(entity, LocalTransform.FromPosition(EntityMonoBehaviour.ToWorldFromRender(position)));
		if (base.EntityManager.HasComponent<DirectionCD>(prefabEntity) && math.any(direction != float3.zero))
		{
			ecb.SetComponent(entity, new DirectionCD
			{
				direction = direction
			});
		}
		return entity;
	}

	public static Entity CreatePrespawnEntityWithoutSwitchingToInterpolation(EntityCommandBuffer ecb, in PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<DirectionCD> directionLookup, ObjectDataCD objectData, float3 position, out Entity prefabEntity, float3 direction = default(float3))
	{
		prefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
		if (prefabEntity == Entity.Null)
		{
			return Entity.Null;
		}
		Entity entity = ecb.Instantiate(prefabEntity);
		ecb.SetComponent(entity, LocalTransform.FromPosition(position));
		if (directionLookup.HasComponent(prefabEntity) && math.any(direction != float3.zero))
		{
			ecb.SetComponent(entity, new DirectionCD
			{
				direction = direction
			});
		}
		return entity;
	}

	[Preserve]
	protected override void OnCreate()
	{
		base.Enabled = false;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.Enabled = false;
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1310928531_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<GhostPredictionSwitchingQueues>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1310928531_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public EntityPrespawnSystem()
	{
	}
}
