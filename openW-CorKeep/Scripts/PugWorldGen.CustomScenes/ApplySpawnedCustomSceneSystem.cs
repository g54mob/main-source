using System;
using System.Runtime.CompilerServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using PugWorldGen;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class ApplySpawnedCustomSceneSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct ApplySpawnedCustomSceneSystem_349D5E71_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public TileAccessor tileAccessor;

		public Entity tileUpdateBufferSingletonLocal;

		public EntityArchetype waterSpreadingArchetypeLocal;

		public CustomScenePrefabUtility.Lookups customScenePrefabLookupsLocal;

		public BlobAssetReference<CustomSceneTableBlob> customSceneTableLocal;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> directionFromVariationLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> propertiesLookup;

		public CustomScenePrefabUtility.Data customSceneData;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SpawnCustomSceneCD> __spawnCustomSceneTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in LocalTransform transform, [NoAlias] in SpawnCustomSceneCD spawnCustomScene)
		{
			for (int i = 0; i < customSceneTableLocal.Value.scenes.Length; i++)
			{
				ref CustomSceneBlob reference = ref customSceneTableLocal.Value.scenes[i];
				if (spawnCustomScene.name.Equals(reference.sceneName))
				{
					if (ApplyCustomScene(transform.Position.RoundToInt2(), ref reference, tileAccessor, ecb, tileUpdateBufferSingletonLocal, new Unity.Mathematics.Random(spawnCustomScene.seed), waterSpreadingArchetypeLocal, directionFromVariationLookup, directionLookup, propertiesLookup, customScenePrefabLookupsLocal, customSceneData))
					{
						break;
					}
					return;
				}
			}
			ecb.DestroyEntity(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnCustomSceneTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnCustomSceneCD>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnCustomSceneCD>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnCustomSceneCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnCustomSceneCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SpawnCustomSceneCD> __SpawnCustomSceneCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__SpawnCustomSceneCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnCustomSceneCD>(isReadOnly: true);
			__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
		}
	}

	private EntityArchetype waterSpreadingArchetype;

	private CustomScenePrefabUtility.Lookups _customScenePrefabLookups;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_655702436_0;

	private EntityQuery __query_655702436_1;

	private EntityQuery __query_655702436_2;

	private EntityQuery __query_655702436_3;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<CustomSceneTableCD>();
		RequireForUpdate<ActivatedContentBundlesBuffer>();
		NeedTileUpdateBuffer();
		waterSpreadingArchetype = base.EntityManager.CreateArchetype(typeof(WaterSpreaderCD));
		_customScenePrefabLookups = new CustomScenePrefabUtility.Lookups(ref base.CheckedStateRef);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		TileAccessor tileAccessor = CreateTileAccessor(readOnly: false);
		Entity tileUpdateBufferSingletonLocal = tileUpdateBufferSingletonEntity;
		EntityArchetype waterSpreadingArchetypeLocal = waterSpreadingArchetype;
		_customScenePrefabLookups.Update(ref base.CheckedStateRef);
		CustomScenePrefabUtility.Lookups customScenePrefabLookups = _customScenePrefabLookups;
		BlobAssetReference<CustomSceneTableBlob> value = __query_655702436_1.GetSingleton<CustomSceneTableCD>().Value;
		ComponentLookup<DirectionBasedOnVariationCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<DirectionCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<ObjectPropertiesCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref base.CheckedStateRef);
		CustomScenePrefabUtility.Data customSceneData = new CustomScenePrefabUtility.Data
		{
			ActiveContentBundles = __query_655702436_2.GetSingletonBuffer<ActivatedContentBundlesBuffer>().AsNativeArray().Reinterpret<DataBlockAddress>(),
			Database = __query_655702436_3.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob
		};
		ApplySpawnedCustomSceneSystem_349D5E71_LambdaJob_0_Execute(ecb, tileAccessor, tileUpdateBufferSingletonLocal, waterSpreadingArchetypeLocal, customScenePrefabLookups, value, componentLookup, componentLookup2, componentLookup3, customSceneData);
		base.OnUpdate();
	}

	private static bool ApplyCustomScene(int2 position, ref CustomSceneBlob sceneBlob, TileAccessor tileAccessor, EntityCommandBuffer ecb, Entity tileUpdateBufferSingletonLocal, Unity.Mathematics.Random rng, EntityArchetype waterSpreadingArchetypeLocal, ComponentLookup<DirectionBasedOnVariationCD> directionFromVariationLookup, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<ObjectPropertiesCD> propertiesLookup, CustomScenePrefabUtility.Lookups customSceneLookups, CustomScenePrefabUtility.Data customSceneData)
	{
		bool flag = false;
		int2 int5 = new int2((!sceneBlob.canFlipX || !rng.NextBool()) ? 1 : (-1), (!sceneBlob.canFlipY || !rng.NextBool()) ? 1 : (-1));
		for (int i = 0; i < sceneBlob.tilePositions.Length; i++)
		{
			if (sceneBlob.tiles[i].tileType != TileType.none)
			{
				int2 int6 = position + int5 * (sceneBlob.tilePositions[i] - sceneBlob.centerPosition);
				if (tileAccessor.IsInitialized(int6))
				{
					tileAccessor.Clear(int6);
					continue;
				}
				ecb.AppendToBuffer(tileUpdateBufferSingletonLocal, new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = int6
				});
				flag = true;
			}
		}
		for (int j = 0; j < sceneBlob.tilePositions.Length; j++)
		{
			if (sceneBlob.tiles[j].tileType == TileType.none)
			{
				continue;
			}
			int2 int7 = position + int5 * (sceneBlob.tilePositions[j] - sceneBlob.centerPosition);
			if (tileAccessor.IsInitialized(int7))
			{
				tileAccessor.Set(int7, sceneBlob.tiles[j]);
				if (!flag)
				{
					Entity e = ecb.CreateEntity(waterSpreadingArchetypeLocal);
					ecb.SetComponent(e, new WaterSpreaderCD
					{
						position = int7
					});
				}
			}
		}
		if (flag)
		{
			return false;
		}
		float3 float5 = position.ToFloat3();
		float3 float6 = sceneBlob.centerPosition.ToFloat3();
		float3 float7 = int5.ToFloat3();
		for (int k = 0; k < sceneBlob.prefabPositions.Length; k++)
		{
			Entity entity = CustomScenePrefabUtility.CreateWithOverrides(ecb, k, ref sceneBlob, customSceneLookups, customSceneData);
			float3 float8 = (math.min(0, int5) * (sceneBlob.prefabSizes[k] + sceneBlob.prefabCornerOffsets[k] * 2 - 1)).ToFloat3();
			float3 position2 = float5 + float7 * (sceneBlob.prefabPositions[k] - float6) + float8;
			ecb.SetComponent(entity, LocalTransform.FromPosition(position2));
			Entity entity2 = sceneBlob.prefabs[k];
			ObjectDataCD objectDataCD = sceneBlob.prefabObjectDatas[k];
			DirectionCD componentData;
			if (directionFromVariationLookup.HasComponent(entity2))
			{
				int flippedVariation = DirectionBasedOnVariationCD.GetFlippedVariation(objectDataCD.variation, int5.x == -1, int5.y == -1);
				if (flippedVariation != objectDataCD.variation)
				{
					objectDataCD.variation = flippedVariation;
					ecb.SetComponent(entity, objectDataCD);
				}
			}
			else if (!TryFlipWallMountedObjects(ecb, entity2, entity, objectDataCD, int5, position2, propertiesLookup) && directionLookup.TryGetComponent(entity2, out componentData))
			{
				if (sceneBlob.prefabDirections[k].TryGetValue(out var output))
				{
					componentData.direction = output;
				}
				componentData.direction *= float7;
				ecb.SetComponent(entity, componentData);
			}
		}
		return true;
	}

	private static bool TryFlipWallMountedObjects(EntityCommandBuffer ecb, Entity prefabEntity, Entity entity, ObjectDataCD objectData, int2 flip, float3 position, ComponentLookup<ObjectPropertiesCD> propertiesLookup)
	{
		if (!propertiesLookup.TryGetComponent(prefabEntity, out var componentData))
		{
			return false;
		}
		if (!componentData.Has(121328368))
		{
			return false;
		}
		int num = objectData.variation;
		bool flag = componentData.Has(-377237680);
		if (flag)
		{
			if (num == 0)
			{
				return false;
			}
			num--;
		}
		if ((flip.x == -1 && num % 2 == 1) || (flip.y == -1 && num % 2 == 0))
		{
			num = (num + 2) % 4;
		}
		if (flag)
		{
			num++;
		}
		if (num != objectData.variation)
		{
			objectData.variation = num;
			ecb.SetComponent(entity, objectData);
		}
		return true;
	}

	private void ApplySpawnedCustomSceneSystem_349D5E71_LambdaJob_0_Execute(EntityCommandBuffer ecb, TileAccessor tileAccessor, Entity tileUpdateBufferSingletonLocal, EntityArchetype waterSpreadingArchetypeLocal, CustomScenePrefabUtility.Lookups customScenePrefabLookupsLocal, BlobAssetReference<CustomSceneTableBlob> customSceneTableLocal, ComponentLookup<DirectionBasedOnVariationCD> directionFromVariationLookup, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<ObjectPropertiesCD> propertiesLookup, CustomScenePrefabUtility.Data customSceneData)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnCustomSceneCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ApplySpawnedCustomSceneSystem_349D5E71_LambdaJob_0_Job jobData = new ApplySpawnedCustomSceneSystem_349D5E71_LambdaJob_0_Job
		{
			ecb = ecb,
			tileAccessor = tileAccessor,
			tileUpdateBufferSingletonLocal = tileUpdateBufferSingletonLocal,
			waterSpreadingArchetypeLocal = waterSpreadingArchetypeLocal,
			customScenePrefabLookupsLocal = customScenePrefabLookupsLocal,
			customSceneTableLocal = customSceneTableLocal,
			directionFromVariationLookup = directionFromVariationLookup,
			directionLookup = directionLookup,
			propertiesLookup = propertiesLookup,
			customSceneData = customSceneData,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__spawnCustomSceneTypeHandle = __TypeHandle.__SpawnCustomSceneCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_655702436_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnCustomSceneCD>();
		_queryRequiredForUpdate = (__query_655702436_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_655702436_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_655702436_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_655702436_3 = entityQueryBuilder2.Build(ref state);
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
	public ApplySpawnedCustomSceneSystem()
	{
	}
}
