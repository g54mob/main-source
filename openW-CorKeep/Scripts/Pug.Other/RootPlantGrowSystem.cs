using System;
using System.Runtime.CompilerServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class RootPlantGrowSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct RootPlantGrowSystem_2B0FA8C6_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity updatedTilesSingleton;

		public Entity effectEventBufferEntity;

		[ReadOnly]
		public TileAccessor tileAccessor;

		public uint seed;

		public NativeQueue<int2> frontier;

		public EntityArchetype growArchetypeLocal;

		public NativeArray<int2> allDirs;

		public int simulationTickRate;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<RootPlantCD> __rootPlantTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GrowingCD> __growingTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PugFloraDoGrowCD> __doGrowTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectPropertiesCD> __propertiesTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in RootPlantCD rootPlant, [NoAlias] in LocalTransform transform, [NoAlias] in GrowingCD growing, [NoAlias] in PugFloraDoGrowCD doGrow, [NoAlias] in ObjectPropertiesCD properties)
		{
			if (!growing.HasReachedFinalStage(properties))
			{
				return;
			}
			bool hasGrownThisFrame = growing.hasGrownThisFrame;
			float min = (hasGrownThisFrame ? 1f : rootPlant.minTimeBetweenSpread);
			float max = (hasGrownThisFrame ? 1f : rootPlant.maxTimeBetweenSpread);
			float num = PugRandom.GetRngFromEntity(seed, entity).NextFloat(min, max);
			NativeParallelHashMap<int2, bool> nativeParallelHashMap = new NativeParallelHashMap<int2, bool>(128, Allocator.Temp);
			int2 int5 = transform.Position.RoundToInt2();
			ecb.RemoveComponent<PugFloraDoGrowCD>(entity);
			frontier.Clear();
			nativeParallelHashMap.Add(int5, item: false);
			for (int i = 0; i < allDirs.Length; i++)
			{
				frontier.Enqueue(int5 + allDirs[i]);
			}
			float num2 = 25f;
			int2 item;
			while (frontier.TryDequeue(out item))
			{
				if (math.distancesq(int5, item) > num2 || nativeParallelHashMap.ContainsKey(item))
				{
					continue;
				}
				TileCD top = tileAccessor.GetTop(item);
				if (top.tileType == TileType.bigRoot && top.tileset == (int)rootPlant.tileset)
				{
					nativeParallelHashMap.Add(item, item: false);
					for (int j = 0; j < allDirs.Length; j++)
					{
						frontier.Enqueue(item + allDirs[j]);
					}
					continue;
				}
				int num3 = 0;
				for (int k = 0; k < allDirs.Length; k++)
				{
					top = tileAccessor.GetTop(item + allDirs[k]);
					if (top.tileType == TileType.bigRoot && top.tileset == (int)rootPlant.tileset)
					{
						num3++;
					}
				}
				if (num3 > 1)
				{
					nativeParallelHashMap.Add(item, item: false);
				}
				else
				{
					nativeParallelHashMap.Add(item, item: true);
				}
			}
			frontier.Clear();
			if (!doGrow.initialize && nativeParallelHashMap.ContainsKey(doGrow.position) && nativeParallelHashMap[doGrow.position])
			{
				int2 position = doGrow.position;
				nativeParallelHashMap[doGrow.position] = false;
				ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = position,
					tile = new TileCD
					{
						tileset = (int)rootPlant.tileset,
						tileType = TileType.bigRoot
					}
				});
				EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
				{
					entity = entity,
					effectID = EffectID.SpawnRoot,
					position1 = new float3(position.x, 0.1f, position.y)
				});
			}
			bool flag = false;
			NativeKeyValueArrays<int2, bool> keyValueArrays = nativeParallelHashMap.GetKeyValueArrays(Allocator.Temp);
			try
			{
				for (int l = 0; l < keyValueArrays.Length; l++)
				{
					NativeArray<bool> values = keyValueArrays.Values;
					if (values[l])
					{
						flag = true;
						Entity e = ecb.CreateEntity(growArchetypeLocal);
						ref EntityCommandBuffer reference = ref ecb;
						PugFloraGrowerCD component = default(PugFloraGrowerCD);
						NativeArray<int2> keys = keyValueArrays.Keys;
						component.position = keys[l];
						component.entity = entity;
						component.timer = (int)math.ceil(num * (float)simulationTickRate);
						component.tilesets = rootPlant.allowedTilesets;
						reference.SetComponent(e, component);
					}
				}
				if (!flag)
				{
					Entity e2 = ecb.CreateEntity(growArchetypeLocal);
					ecb.SetComponent(e2, new PugFloraGrowerCD
					{
						position = int5,
						entity = entity,
						timer = (int)math.ceil(num * (float)simulationTickRate),
						tilesets = rootPlant.allowedTilesets
					});
				}
				nativeParallelHashMap.Dispose();
			}
			finally
			{
				((IDisposable)keyValueArrays/*cast due to .constrained prefix*/).Dispose();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rootPlantTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __growingTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __doGrowTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __propertiesTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RootPlantCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraDoGrowCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RootPlantCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraDoGrowCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RootPlantCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraDoGrowCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RootPlantCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugFloraDoGrowCD>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, l));
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
		public ComponentTypeHandle<RootPlantCD> __RootPlantCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GrowingCD> __GrowingCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PugFloraDoGrowCD> __PugFloraDoGrowCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__RootPlantCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RootPlantCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__GrowingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GrowingCD>(isReadOnly: true);
			__PugFloraDoGrowCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugFloraDoGrowCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
		}
	}

	private EntityArchetype growArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1303729376_0;

	private EntityQuery __query_1303729376_1;

	private EntityQuery __query_1303729376_2;

	[Preserve]
	protected override void OnCreate()
	{
		NeedTileUpdateBuffer();
		RequireForUpdate<EffectEventBuffer>();
		growArchetype = base.EntityManager.CreateArchetype(typeof(PugFloraGrowerCD));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		Entity updatedTilesSingleton = tileUpdateBufferSingletonEntity;
		Entity singletonEntity = __query_1303729376_1.GetSingletonEntity();
		TileAccessor tileAccessor = CreateTileAccessor();
		uint seed = PugRandom.GetSeed();
		NativeQueue<int2> frontier = new NativeQueue<int2>(base.World.UpdateAllocator.ToAllocator);
		EntityArchetype growArchetypeLocal = growArchetype;
		NativeArray<int2> allDirs = CollectionHelper.CreateNativeArray<int2>(4, base.World.UpdateAllocator.ToAllocator);
		for (int i = 0; i < allDirs.Length; i++)
		{
			allDirs[i] = Direction.allFourClockwise[i].i2;
		}
		__query_1303729376_2.TryGetSingleton<ClientServerTickRate>(out var value);
		value.ResolveDefaults();
		int simulationTickRate = value.SimulationTickRate;
		RootPlantGrowSystem_2B0FA8C6_LambdaJob_0_Execute(ecb, updatedTilesSingleton, singletonEntity, tileAccessor, seed, frontier, growArchetypeLocal, allDirs, simulationTickRate);
		base.OnUpdate();
	}

	private void RootPlantGrowSystem_2B0FA8C6_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity updatedTilesSingleton, Entity effectEventBufferEntity, TileAccessor tileAccessor, uint seed, NativeQueue<int2> frontier, EntityArchetype growArchetypeLocal, NativeArray<int2> allDirs, int simulationTickRate)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RootPlantCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__GrowingCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PugFloraDoGrowCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		RootPlantGrowSystem_2B0FA8C6_LambdaJob_0_Job jobData = new RootPlantGrowSystem_2B0FA8C6_LambdaJob_0_Job
		{
			ecb = ecb,
			updatedTilesSingleton = updatedTilesSingleton,
			effectEventBufferEntity = effectEventBufferEntity,
			tileAccessor = tileAccessor,
			seed = seed,
			frontier = frontier,
			growArchetypeLocal = growArchetypeLocal,
			allDirs = allDirs,
			simulationTickRate = simulationTickRate,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__rootPlantTypeHandle = __TypeHandle.__RootPlantCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__growingTypeHandle = __TypeHandle.__GrowingCD_RO_ComponentTypeHandle,
			__doGrowTypeHandle = __TypeHandle.__PugFloraDoGrowCD_RO_ComponentTypeHandle,
			__propertiesTypeHandle = __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1303729376_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<RootPlantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GrowingCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugFloraDoGrowCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1303729376_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1303729376_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1303729376_2 = entityQueryBuilder2.Build(ref state);
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
	public RootPlantGrowSystem()
	{
	}
}
