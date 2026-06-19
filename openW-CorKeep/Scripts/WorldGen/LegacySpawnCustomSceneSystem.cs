using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class LegacySpawnCustomSceneSystem : PugSimulationSystemBase
{
	private struct LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public LegacySpawnCustomSceneSystem __this;

		public bool skipSpawn;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<CustomSceneTableBlob> customScenesData;

		public uint seed;

		[ReadOnly]
		public NativeArray<BlockedSpawnArea> blockedAreas;

		public bool hasPendingCustomSceneSpawns;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<LegacySpawnRandomCustomSceneInAreaCD> __spawnRandomCustomSceneInAreaTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ProceduralSpawnArea> __areaTypeHandle;

		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref LegacySpawnRandomCustomSceneInAreaCD spawnRandomCustomSceneInArea, in ProceduralSpawnArea area)
		{
			if (!skipSpawn && spawnRandomCustomSceneInArea.attempts > 0)
			{
				__this.TrySpawnRandomCustomScene(ecb, area, customScenesData, seed, blockedAreas, biomeLookup);
				spawnRandomCustomSceneInArea.attempts--;
			}
			else if (!hasPendingCustomSceneSpawns)
			{
				ecb.RemoveComponent<LegacySpawnRandomCustomSceneInAreaCD>(entity);
				ecb.AddComponent<LegacySpawnProceduralInAreaCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __spawnRandomCustomSceneInAreaTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __areaTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnRandomCustomSceneInAreaCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, i));
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
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnRandomCustomSceneInAreaCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnRandomCustomSceneInAreaCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LegacySpawnRandomCustomSceneInAreaCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, l));
				}
				num2 >>= 1;
			}
		}

		public void DisposeOnCompletion()
		{
			blockedAreas.Dispose();
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job>(jobPtr), ref query);
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

		public ComponentTypeHandle<LegacySpawnRandomCustomSceneInAreaCD> __LegacySpawnRandomCustomSceneInAreaCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<CustomSceneCD> __CustomSceneCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__LegacySpawnRandomCustomSceneInAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LegacySpawnRandomCustomSceneInAreaCD>();
			__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
			__CustomSceneCD_RO_ComponentLookup = state.GetComponentLookup<CustomSceneCD>(isReadOnly: true);
		}
	}

	private static readonly DataBlockAddress ClassicBundle = new DataBlockAddress("7507d88e-fd7a-7444-1b18-3816c6fbe382");

	private List<int> availableSceneIndices;

	private List<int> availableScenesAmount;

	private EntityQuery blockedAreasQ;

	private EntityQuery spawnCustomSceneQ;

	private bool loadedScenesAdded;

	private EntityQuery query;

	private BiomeLookup _biomeLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_253074018_0;

	private EntityQuery __query_253074018_1;

	private EntityQuery __query_253074018_2;

	private EntityQuery __query_253074018_3;

	private EntityQuery __query_253074018_4;

	private EntityQuery __query_253074018_5;

	[Preserve]
	protected override void OnCreate()
	{
		NeedServerSeed();
		UpdatesInRunGroup();
		RequireForUpdate<CustomSceneTableCD>();
		loadedScenesAdded = false;
		availableSceneIndices = new List<int>();
		availableScenesAmount = new List<int>();
		blockedAreasQ = GetEntityQuery(ComponentType.ReadOnly<BlockedSpawnAreaCD>());
		spawnCustomSceneQ = GetEntityQuery(ComponentType.ReadOnly<SpawnCustomSceneCD>());
		RequireForUpdate(query);
		RequireForUpdate(__query_253074018_1);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		BlobAssetReference<CustomSceneTableBlob> value = __query_253074018_2.GetSingleton<CustomSceneTableCD>().Value;
		int num = 1;
		for (int i = 1; i < value.Value.scenes.Length; i++)
		{
			ref CustomSceneBlob reference = ref value.Value.scenes[i];
			if (reference.maxOccurrences > 0 && (!reference.replacedByContentBundle.TryGetValue(out var output) || output != ClassicBundle))
			{
				availableScenesAmount.Add(reference.maxOccurrences);
				availableSceneIndices.Add(num);
			}
			num++;
		}
		_biomeLookup = (__query_253074018_3.TryGetSingleton<BiomeSamplesCD>(out var value2) ? new BiomeLookup(value2) : new BiomeLookup(__query_253074018_4.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		if (!loadedScenesAdded)
		{
			NativeArray<Entity> nativeArray = GetEntityQuery(ComponentType.ReadOnly<CustomSceneCD>()).ToEntityArray(Allocator.Temp);
			for (int j = 0; j < nativeArray.Length; j++)
			{
				FixedString32Bytes name = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__CustomSceneCD_RO_ComponentLookup, ref base.CheckedStateRef, nativeArray[j]).name;
				for (int num2 = availableSceneIndices.Count - 1; num2 >= 0; num2--)
				{
					int index = availableSceneIndices[num2];
					if (name.Equals(value.Value.scenes[index].sceneName))
					{
						DecrementSceneCount(num2);
					}
				}
			}
			nativeArray.Dispose();
			loadedScenesAdded = true;
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		_biomeLookup.Dispose();
		base.OnStopRunning();
	}

	private void DecrementSceneCount(int sceneNumber)
	{
		if (availableScenesAmount[sceneNumber] > 0)
		{
			availableScenesAmount[sceneNumber]--;
			if (availableScenesAmount[sceneNumber] <= 0)
			{
				availableScenesAmount.RemoveAt(sceneNumber);
				availableSceneIndices.RemoveAt(sceneNumber);
			}
		}
	}

	[Preserve]
	protected override void OnUpdate()
	{
		WorldGenerationType value = __query_253074018_5.GetSingleton<WorldGenerationTypeCD>().Value;
		if (value != WorldGenerationType.FullRelease)
		{
			bool skipSpawn = value == WorldGenerationType.Creative;
			EntityCommandBuffer ecb = CreateCommandBuffer();
			BlobAssetReference<CustomSceneTableBlob> customScenesData = __query_253074018_2.GetSingleton<CustomSceneTableCD>().Value;
			uint seed = serverSeed;
			NativeArray<BlockedSpawnArea> blockedAreas = blockedAreasQ.ToComponentDataArray<BlockedSpawnAreaCD>(Allocator.Temp).Reinterpret<BlockedSpawnArea>();
			bool hasPendingCustomSceneSpawns = !spawnCustomSceneQ.IsEmpty;
			BiomeLookup biomeLookup = _biomeLookup;
			LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Execute(ref skipSpawn, ref ecb, ref customScenesData, ref seed, ref blockedAreas, ref hasPendingCustomSceneSpawns, ref biomeLookup);
			base.OnUpdate();
		}
	}

	private void TrySpawnRandomCustomScene(EntityCommandBuffer ecb, ProceduralSpawnArea area, BlobAssetReference<CustomSceneTableBlob> customScenesData, uint seed, NativeArray<BlockedSpawnArea> blockedAreas, BiomeLookup biomeLookup)
	{
		int2 int5 = default(int2);
		Unity.Mathematics.Random rng = new Unity.Mathematics.Random(math.hash(area.Position) ^ seed);
		if (availableSceneIndices.Count <= 0)
		{
			return;
		}
		Biome biome = biomeLookup.GetBiome(area.Center);
		float num = 0.5f;
		switch (biome)
		{
		case Biome.Slime:
			num = 1f;
			break;
		case Biome.Sea:
			num = 0.2f;
			break;
		case Biome.Desert:
			num = 0.2f;
			break;
		}
		if (!(rng.NextFloat() < num) || biome == Biome.None || biome == Biome.Obsidian)
		{
			return;
		}
		List<int2> list = new List<int2>(availableSceneIndices.Count);
		for (int i = 0; i < availableSceneIndices.Count; i++)
		{
			int index = availableSceneIndices[i];
			ref CustomSceneBlob reference = ref customScenesData.Value.scenes[index];
			if (math.any(reference.boundsSize > area.Size))
			{
				Debug.LogWarning("custom map " + index + " too large for spawn area");
				continue;
			}
			bool flag = false;
			for (int j = 0; j < reference.biomesToSpawnIn.classic.Length; j++)
			{
				if (reference.biomesToSpawnIn.classic[j] == biome)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				list.Add(new int2(i, availableSceneIndices[i]));
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		int num2 = ((biome != Biome.Slime) ? 1 : 5);
		int num3 = 0;
		int sceneNumber = 0;
		int index2 = 0;
		for (num3 = 0; num3 < num2; num3++)
		{
			int index3 = rng.NextInt(0, list.Count);
			sceneNumber = list[index3].x;
			index2 = list[index3].y;
			ref CustomSceneBlob reference2 = ref customScenesData.Value.scenes[index2];
			float radius = reference2.radius;
			int k = 0;
			int num4;
			for (num4 = ((biome == Biome.Slime) ? 10 : 3); k < num4; k++)
			{
				int2 max = area.Size - reference2.boundsSize;
				int2 int6 = rng.NextInt2(max);
				int5 = area.Position + reference2.boundsSize / 2 + int6;
				float num5 = math.length(int5);
				if ((reference2.minDistanceFromCoreInClassicWorlds == 0 || !((float)reference2.minDistanceFromCoreInClassicWorlds > num5)) && !EntityUtility.PointIsBlockedForSpawning(blockedAreas, int5, radius) && biomeLookup.IsOnlyBiomeInRange(int5, (int)math.ceil(radius), biome))
				{
					break;
				}
			}
			if (k != num4)
			{
				break;
			}
		}
		if (num3 != num2)
		{
			DecrementSceneCount(sceneNumber);
			SpawnCustomScene(ecb, int5, ref customScenesData.Value.scenes[index2], ref rng);
		}
	}

	private static void SpawnCustomScene(EntityCommandBuffer ecb, int2 scenePos, ref CustomSceneBlob scene, ref Unity.Mathematics.Random rng)
	{
		Entity e = ecb.CreateEntity();
		ecb.AddComponent(e, new CustomSceneCD
		{
			name = new FixedString32Bytes(in scene.sceneName)
		});
		Entity e2 = ecb.CreateEntity();
		ecb.AddComponent(e2, new BlockedSpawnAreaCD(scenePos, scene.radius));
		Entity e3 = ecb.CreateEntity();
		ecb.AddComponent(e3, LocalTransform.FromPosition(scenePos.ToFloat3()));
		ecb.AddComponent(e3, new SpawnCustomSceneCD
		{
			name = new FixedString32Bytes(in scene.sceneName),
			seed = rng.NextUInt()
		});
	}

	private void LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Execute(ref bool skipSpawn, ref EntityCommandBuffer ecb, ref BlobAssetReference<CustomSceneTableBlob> customScenesData, ref uint seed, ref NativeArray<BlockedSpawnArea> blockedAreas, ref bool hasPendingCustomSceneSpawns, ref BiomeLookup biomeLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LegacySpawnRandomCustomSceneInAreaCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job value = new LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job
		{
			__this = this,
			skipSpawn = skipSpawn,
			ecb = ecb,
			customScenesData = customScenesData,
			seed = seed,
			blockedAreas = blockedAreas,
			hasPendingCustomSceneSpawns = hasPendingCustomSceneSpawns,
			biomeLookup = biomeLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__spawnRandomCustomSceneInAreaTypeHandle = __TypeHandle.__LegacySpawnRandomCustomSceneInAreaCD_RW_ComponentTypeHandle,
			__areaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle
		};
		value.__ChunkBaseEntityIndices = __query_253074018_0.CalculateBaseEntityIndexArray(base.CheckedStateRef.WorldUpdateAllocator);
		if (!__query_253074018_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LegacySpawnCustomSceneSystem_6D38713D_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_253074018_0, jobPtr);
		}
		value.DisposeOnCompletion();
		skipSpawn = value.skipSpawn;
		ecb = value.ecb;
		customScenesData = value.customScenesData;
		seed = value.seed;
		blockedAreas = value.blockedAreas;
		hasPendingCustomSceneSpawns = value.hasPendingCustomSceneSpawns;
		biomeLookup = value.biomeLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LegacySpawnRandomCustomSceneInAreaCD>();
		query = (__query_253074018_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_253074018_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_253074018_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_253074018_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_253074018_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_253074018_5 = entityQueryBuilder2.Build(ref state);
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
	public LegacySpawnCustomSceneSystem()
	{
	}
}
