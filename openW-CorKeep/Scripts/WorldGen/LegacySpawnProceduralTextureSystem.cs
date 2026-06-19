using System;
using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class LegacySpawnProceduralTextureSystem : PugSimulationSystemBase
{
	[BurstCompile]
	private struct GetUnsetPositionsJob : IJob
	{
		private readonly ProceduralSpawnArea _proceduralSpawnArea;

		private TileAccessor _tileAccessor;

		public NativeReference<SubMapLayer> PositionsNotSet;

		public GetUnsetPositionsJob(ProceduralSpawnArea proceduralSpawnArea, TileAccessor tileAccessor, AllocatorManager.AllocatorHandle allocatorHandle)
		{
			_proceduralSpawnArea = proceduralSpawnArea;
			_tileAccessor = tileAccessor;
			PositionsNotSet = new NativeReference<SubMapLayer>(allocatorHandle, NativeArrayOptions.UninitializedMemory);
		}

		public void Execute()
		{
			SubMapLayer sl = default(SubMapLayer);
			for (int i = 0; i < _proceduralSpawnArea.Size.y; i++)
			{
				for (int j = 0; j < _proceduralSpawnArea.Size.x; j++)
				{
					int2 int5 = new int2(j, i);
					int2 worldPosition = _proceduralSpawnArea.Position + int5;
					if (_tileAccessor.Count(worldPosition) == 0 || _tileAccessor.GetTopType(worldPosition) == TileType.none)
					{
						sl.Set(int5);
					}
				}
			}
			PositionsNotSet.Value = sl;
		}
	}

	[BurstCompile]
	private struct GenerateSubmapFromTexturesJob : IJob
	{
		[ReadOnly]
		private Entity entity;

		[ReadOnly]
		private NativeReference<SubMapLayer> positionsNotSet;

		[ReadOnly]
		private NativeArray<LegacyProceduralWorldTexture.TileTypeExtractor> tileTypeExtractors;

		[ReadOnly]
		private ProceduralSpawnArea _proceduralSpawnArea;

		[ReadOnly]
		private LegacySpawnProceduralInAreaCD spawnProceduralInArea;

		[ReadOnly]
		private EntityArchetype waterSpreadingArchetype;

		private EntityCommandBuffer ecb;

		private TileAccessor tileAccessor;

		public GenerateSubmapFromTexturesJob(Entity entity, NativeReference<SubMapLayer> positionsNotSet, ProceduralSpawnArea proceduralSpawnArea, NativeArray<LegacyProceduralWorldTexture.TileTypeExtractor> tileTypeExtractors, LegacySpawnProceduralInAreaCD spawnProceduralInArea, EntityArchetype waterSpreadingArchetype, EntityCommandBuffer ecb, TileAccessor tileAccessor)
		{
			this.entity = entity;
			this.positionsNotSet = positionsNotSet;
			_proceduralSpawnArea = proceduralSpawnArea;
			this.tileTypeExtractors = tileTypeExtractors;
			this.spawnProceduralInArea = spawnProceduralInArea;
			this.waterSpreadingArchetype = waterSpreadingArchetype;
			this.ecb = ecb;
			this.tileAccessor = tileAccessor;
		}

		public void Execute()
		{
			NativeList<int2> nativeList = new NativeList<int2>(4096, Allocator.Temp);
			int num = 0;
			foreach (LegacyProceduralWorldTexture.TileTypeExtractor tileTypeExtractor in tileTypeExtractors)
			{
				for (int i = 0; i < _proceduralSpawnArea.Size.y; i++)
				{
					for (int j = 0; j < _proceduralSpawnArea.Size.x; j++)
					{
						int2 int5 = new int2(j, i);
						int2 value = _proceduralSpawnArea.Position + int5;
						TileCD tileType = tileTypeExtractor.GetTileType(int5);
						if (tileType.tileType != TileType.none && positionsNotSet.Value.Get(int5) && (tileType.tileset != 2 || (tileType.tileType != TileType.wall && tileType.tileType != TileType.ground)))
						{
							num++;
							tileAccessor.Set(value, tileType);
							if (tileType.tileType == TileType.water || tileType.tileType == TileType.pit)
							{
								nativeList.Add(in value);
							}
						}
					}
				}
			}
			ecb.RemoveComponent<LegacySpawnProceduralInAreaCD>(entity);
			if (num > 100)
			{
				if (spawnProceduralInArea.fillPartialSubMap)
				{
					ecb.AddComponent(entity, new LegacySpawnEnvironmentObjectsInAreaCD
					{
						fillPartialSubMap = spawnProceduralInArea.fillPartialSubMap
					});
				}
				else
				{
					ecb.AddComponent<LegacySpawnRootsInAreaCD>(entity);
				}
			}
			else
			{
				ecb.RemoveComponent<BlockSaveCD>(entity);
			}
			foreach (int2 item in nativeList)
			{
				ecb.SetComponent(ecb.CreateEntity(waterSpreadingArchetype), new WaterSpreaderCD
				{
					position = item
				});
			}
			nativeList.Dispose();
		}
	}

	private struct LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job : IJobChunk
	{
		public LegacySpawnProceduralTextureSystem __this;

		public EntityCommandBuffer ecb;

		public TileAccessor tileAccessor;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ProceduralSpawnArea> __spawnedAreaTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LegacySpawnProceduralInAreaCD> __spawnProceduralInAreaTypeHandle;

		private void OriginalLambdaBody(Entity entity, in ProceduralSpawnArea spawnedArea, in LegacySpawnProceduralInAreaCD spawnProceduralInArea)
		{
			int num = 0;
			if (!tileAccessor.IsInitialized(spawnedArea.Position))
			{
				return;
			}
			GetUnsetPositionsJob jobData = new GetUnsetPositionsJob(spawnedArea, tileAccessor, __this.World.UpdateAllocator.ToAllocator);
			IJobExtensions.Run(jobData);
			NativeReference<SubMapLayer> positionsNotSet = jobData.PositionsNotSet;
			TileCD tileCD = new TileCD
			{
				tileset = 0,
				tileType = TileType.ground
			};
			TileCD tileCD2 = new TileCD
			{
				tileset = 0,
				tileType = TileType.pit
			};
			for (int i = 0; i < spawnedArea.Size.y; i++)
			{
				for (int j = 0; j < spawnedArea.Size.x; j++)
				{
					int2 int5 = new int2(j, i);
					int2 int6 = spawnedArea.Position + int5;
					TileCD tile = (math.all(math.abs(int6) < 20) ? tileCD : tileCD2);
					if (positionsNotSet.Value.Get(int5))
					{
						num++;
						tileAccessor.Set(int6, tile);
					}
				}
			}
			ecb.RemoveComponent<LegacySpawnProceduralInAreaCD>(entity);
			if (num > 100)
			{
				if (spawnProceduralInArea.fillPartialSubMap)
				{
					ecb.AddComponent(entity, new LegacySpawnEnvironmentObjectsInAreaCD
					{
						fillPartialSubMap = spawnProceduralInArea.fillPartialSubMap
					});
				}
				else
				{
					ecb.AddComponent<LegacySpawnRootsInAreaCD>(entity);
				}
			}
			else
			{
				ecb.RemoveComponent<BlockSaveCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnedAreaTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnProceduralInAreaTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnProceduralInAreaCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnProceduralInAreaCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnProceduralInAreaCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnProceduralInAreaCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job>(jobPtr), ref query);
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
		public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LegacySpawnProceduralInAreaCD> __LegacySpawnProceduralInAreaCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
			__LegacySpawnProceduralInAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LegacySpawnProceduralInAreaCD>(isReadOnly: true);
		}
	}

	private LegacyProceduralWorldTexture[] proceduralWorldTextures;

	private static readonly int SeedId = Shader.PropertyToID("seed");

	private static readonly int WallHasBeenLowered = Shader.PropertyToID("WallHasBeenLowered");

	private EntityQuery wallHasBeenLoweredQuery;

	private EntityArchetype waterSpreadingArchetype;

	private EntityQuery spawnedAreaQuery;

	private NativeQueue<Entity> entitiesAwaitingGeneration;

	private Entity currentlyGeneratingEntity;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2051077905_0;

	private EntityQuery __query_2051077905_1;

	[Preserve]
	protected override void OnCreate()
	{
		NeedServerSeed();
		proceduralWorldTextures = null;
		RequireForUpdate<BiomeRangesCD>();
		spawnedAreaQuery = GetEntityQuery(ComponentType.ReadOnly<ProceduralSpawnArea>(), ComponentType.ReadOnly<LegacySpawnProceduralInAreaCD>());
		RequireForUpdate(spawnedAreaQuery);
		wallHasBeenLoweredQuery = GetEntityQuery(ComponentType.ReadOnly<TheGreatWallHasBeenLoweredCD>());
		waterSpreadingArchetype = base.EntityManager.CreateArchetype(typeof(WaterSpreaderCD));
		entitiesAwaitingGeneration = new NativeQueue<Entity>(Allocator.Persistent);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		entitiesAwaitingGeneration.Dispose();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		if (proceduralWorldTextures == null && !Manager.saves.IsWorldModeEnabled(WorldMode.Creative))
		{
			proceduralWorldTextures = UnityEngine.Object.FindObjectsOfType<LegacyProceduralWorldTexture>(includeInactive: true);
			LegacyProceduralWorldTexture[] array = proceduralWorldTextures;
			foreach (LegacyProceduralWorldTexture obj in array)
			{
				obj.gameObject.SetActive(value: true);
				obj.gameObject.SetActive(value: false);
			}
		}
		currentlyGeneratingEntity = Entity.Null;
	}

	[Preserve]
	protected override void OnUpdate()
	{
		WorldGenerationType value = __query_2051077905_1.GetSingleton<WorldGenerationTypeCD>().Value;
		if (value == WorldGenerationType.FullRelease)
		{
			return;
		}
		EntityCommandBuffer ecb = CreateCommandBuffer();
		TileAccessor tileAccessor = CreateTileAccessor(readOnly: false);
		uint num = serverSeed;
		Shader.SetGlobalInt(WallHasBeenLowered, (!wallHasBeenLoweredQuery.IsEmpty) ? 1 : 0);
		Shader.SetGlobalInt(SeedId, (int)(num % 100000));
		if (value == WorldGenerationType.Creative)
		{
			LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Execute(ref ecb, ref tileAccessor);
		}
		else
		{
			if (currentlyGeneratingEntity == Entity.Null && entitiesAwaitingGeneration.IsEmpty())
			{
				using NativeArray<Entity> nativeArray = spawnedAreaQuery.ToEntityArray(Allocator.Temp);
				foreach (Entity item in nativeArray)
				{
					entitiesAwaitingGeneration.Enqueue(item);
				}
			}
			if (currentlyGeneratingEntity != Entity.Null)
			{
				bool flag = false;
				LegacyProceduralWorldTexture[] array = proceduralWorldTextures;
				foreach (LegacyProceduralWorldTexture legacyProceduralWorldTexture in array)
				{
					flag |= legacyProceduralWorldTexture.IsUpdating();
				}
				if (!flag)
				{
					ProceduralSpawnArea component = GetComponent<ProceduralSpawnArea>(currentlyGeneratingEntity);
					LegacySpawnProceduralInAreaCD component2 = GetComponent<LegacySpawnProceduralInAreaCD>(currentlyGeneratingEntity);
					GetUnsetPositionsJob jobData = new GetUnsetPositionsJob(component, tileAccessor, base.World.UpdateAllocator.ToAllocator);
					base.Dependency = IJobExtensions.Schedule(jobData, base.Dependency);
					NativeArray<LegacyProceduralWorldTexture.TileTypeExtractor> tileTypeExtractors = CollectionHelper.CreateNativeArray<LegacyProceduralWorldTexture.TileTypeExtractor>(proceduralWorldTextures.Length, base.World.UpdateAllocator.ToAllocator, NativeArrayOptions.UninitializedMemory);
					for (int j = 0; j < proceduralWorldTextures.Length; j++)
					{
						tileTypeExtractors[j] = proceduralWorldTextures[j].GetTileTypeExtractor(base.World.UpdateAllocator.ToAllocator);
					}
					GenerateSubmapFromTexturesJob jobData2 = new GenerateSubmapFromTexturesJob(currentlyGeneratingEntity, jobData.PositionsNotSet, component, tileTypeExtractors, component2, waterSpreadingArchetype, ecb, tileAccessor);
					base.Dependency = IJobExtensions.Schedule(jobData2, base.Dependency);
					currentlyGeneratingEntity = Entity.Null;
				}
			}
			else if (entitiesAwaitingGeneration.TryDequeue(out currentlyGeneratingEntity))
			{
				ProceduralSpawnArea component3 = GetComponent<ProceduralSpawnArea>(currentlyGeneratingEntity);
				LegacyProceduralWorldTexture[] array = proceduralWorldTextures;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ScheduleWorldPixelUpdate(component3.Position, component3.Size);
				}
			}
		}
		base.OnUpdate();
	}

	private void LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref TileAccessor tileAccessor)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LegacySpawnProceduralInAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job value = new LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job
		{
			__this = this,
			ecb = ecb,
			tileAccessor = tileAccessor,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__spawnedAreaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle,
			__spawnProceduralInAreaTypeHandle = __TypeHandle.__LegacySpawnProceduralInAreaCD_RO_ComponentTypeHandle
		};
		if (!__query_2051077905_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LegacySpawnProceduralTextureSystem_7B671D2E_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2051077905_0, jobPtr);
		}
		ecb = value.ecb;
		tileAccessor = value.tileAccessor;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LegacySpawnProceduralInAreaCD>();
		__query_2051077905_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2051077905_1 = entityQueryBuilder2.Build(ref state);
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
	public LegacySpawnProceduralTextureSystem()
	{
	}
}
