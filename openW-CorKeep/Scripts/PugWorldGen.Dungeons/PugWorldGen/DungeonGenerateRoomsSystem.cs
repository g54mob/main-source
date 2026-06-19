using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonAssignSeedSystem))]
	[UpdateAfter(typeof(DungeonPlaceRoomsSystem))]
	[UpdateAfter(typeof(DungeonPlacePathsSystem))]
	public class DungeonGenerateRoomsSystem : PugSimulationSystemBase
	{
		private struct SpawnMapEntry
		{
			public int spawnIndex;

			public ObjectDataCD objectData;

			public bool dontOverrideObject;
		}

		private struct GenerationState
		{
			public Entity CurrentlyGeneratingEntity;

			public int RoomIdx;

			public int PathIdx;

			public bool InitializeRng;

			public Unity.Mathematics.Random Rng;

			public int TotalRoomsAndPathsInQueue;
		}

		[NoAlias]
		[BurstCompile]
		private struct DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Job : IJobChunk
		{
			public NativeReference<GenerationState> generationStateLocal;

			public NativeQueue<Entity> entitiesAwaitingGenerationLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<DungeonRoomBuffer> __roomBufferTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __pathBufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<DungeonRoomBuffer> roomBuffer, DynamicBuffer<DungeonPathBuffer> pathBuffer)
			{
				entitiesAwaitingGenerationLocal.Enqueue(entity);
				GenerationState value = generationStateLocal.Value;
				value.TotalRoomsAndPathsInQueue += roomBuffer.Length + pathBuffer.Length;
				generationStateLocal.Value = value;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roomBufferTypeHandle);
				BufferAccessor<DungeonPathBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __pathBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], bufferAccessor2[i]);
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], bufferAccessor2[j]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], bufferAccessor2[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], bufferAccessor2[l]);
					}
					num >>= 1;
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Job : IJob
		{
			public NativeReference<GenerationState> generationStateLocal;

			public EntityCommandBuffer ecb;

			public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

			public BlobAssetReference<CustomSceneTableBlob> customSceneTableLocal;

			public bool isPlaying;

			public NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMapLocal;

			public BufferLookup<DungeonRoomBuffer> roomBufferAccessor;

			public BufferLookup<DungeonPathBuffer> pathBufferAccessor;

			public BufferLookup<DungeonSpawnedObjectBuffer> spawnObjectsAccessor;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> directionLookup;

			[ReadOnly]
			public ComponentLookup<DontOverrideInDungeonGenerationCD> dontOverrideLookup;

			[ReadOnly]
			public NativeArray<int2> allDirs;

			public int maxIterationsThisTick;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody()
			{
				using NativeParallelHashSet<int2> positionsSet = new NativeParallelHashSet<int2>(20000, Allocator.Temp);
				GenerationState value = generationStateLocal.Value;
				if (value.InitializeRng)
				{
					value.Rng = new Unity.Mathematics.Random(__PugWorldGen_DungeonAreaCD_ComponentLookup[value.CurrentlyGeneratingEntity].seed ^ 0x26365D);
					value.InitializeRng = false;
				}
				LocalTransform localTransform = __Unity_Transforms_LocalTransform_ComponentLookup[value.CurrentlyGeneratingEntity];
				DungeonAreaCD dungeonArea = __PugWorldGen_DungeonAreaCD_ComponentLookup[value.CurrentlyGeneratingEntity];
				DynamicBuffer<DungeonRoomBuffer> dynamicBuffer = roomBufferAccessor[value.CurrentlyGeneratingEntity];
				DynamicBuffer<DungeonPathBuffer> dynamicBuffer2 = pathBufferAccessor[value.CurrentlyGeneratingEntity];
				DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects = spawnObjectsAccessor[value.CurrentlyGeneratingEntity];
				int2 dungeonCenter = localTransform.Position.RoundToInt2();
				int num = 0;
				while (num < maxIterationsThisTick && value.RoomIdx < dynamicBuffer.Length)
				{
					RoomCD room = dynamicBuffer[value.RoomIdx].room;
					if (customSceneTableLocal.IsCreated && !dynamicBuffer[value.RoomIdx].customSceneName.IsEmpty)
					{
						DungeonRoomBuffer dungeonRoomBuffer = dynamicBuffer[value.RoomIdx];
						SpawnCustomScene(in dungeonRoomBuffer.customSceneName, room, customSceneTableLocal, ref spawnMapLocal, ref spawnObjects, positionsSet, databaseLocal, ecb, isPlaying, ref value.Rng, directionLookup, dontOverrideLookup);
					}
					BlobAssetReference<SpawnTemplateBlob> spawnTemplate = dynamicBuffer[value.RoomIdx].spawnTemplate;
					Spawn(isRoom: true, room, default(PathCD), dungeonCenter, ref value.Rng, dungeonArea, spawnMapLocal, positionsSet, spawnTemplate, databaseLocal, allDirs, ref spawnObjects, dontOverrideLookup);
					num++;
					value.RoomIdx++;
					value.TotalRoomsAndPathsInQueue--;
				}
				while (num < maxIterationsThisTick && value.PathIdx < dynamicBuffer2.Length)
				{
					PathCD path = dynamicBuffer2[value.PathIdx].path;
					BlobAssetReference<SpawnTemplateBlob> spawnTemplate2 = dynamicBuffer2[value.PathIdx].spawnTemplate;
					Spawn(isRoom: false, default(RoomCD), path, dungeonCenter, ref value.Rng, dungeonArea, spawnMapLocal, positionsSet, spawnTemplate2, databaseLocal, allDirs, ref spawnObjects, dontOverrideLookup);
					num++;
					value.PathIdx++;
					value.TotalRoomsAndPathsInQueue--;
				}
				if (value.RoomIdx == dynamicBuffer.Length && value.PathIdx == dynamicBuffer2.Length)
				{
					ecb.AddComponent<DungeonApplySpawnedObjectsSystem.Trigger>(value.CurrentlyGeneratingEntity);
					value.CurrentlyGeneratingEntity = Entity.Null;
					value.RoomIdx = 0;
					value.PathIdx = 0;
					spawnMapLocal.Clear();
				}
				generationStateLocal.Value = value;
			}

			public void Execute()
			{
				OriginalLambdaBody();
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			public BufferLookup<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RW_BufferLookup;

			public BufferLookup<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RW_BufferLookup;

			public BufferLookup<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DontOverrideInDungeonGenerationCD> __DontOverrideInDungeonGenerationCD_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonAreaCD_RO_ComponentLookup = state.GetComponentLookup<DungeonAreaCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__PugWorldGen_DungeonRoomBuffer_RW_BufferLookup = state.GetBufferLookup<DungeonRoomBuffer>();
				__PugWorldGen_DungeonPathBuffer_RW_BufferLookup = state.GetBufferLookup<DungeonPathBuffer>();
				__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferLookup = state.GetBufferLookup<DungeonSpawnedObjectBuffer>();
				__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
				__DontOverrideInDungeonGenerationCD_RO_ComponentLookup = state.GetComponentLookup<DontOverrideInDungeonGenerationCD>(isReadOnly: true);
			}
		}

		private const int SYSTEM_SEED = 2504285;

		private const int MAX_GENERATION_DELAY_SECONDS = 1;

		private new BlobAssetReference<PugDatabase.PugDatabaseBank> database;

		private BlobAssetReference<CustomSceneTableBlob> customSceneTable;

		private EntityQuery pugDatabaseQ;

		private EntityQuery customSceneTableQ;

		private NativeQueue<Entity> entitiesAwaitingGeneration;

		private NativeReference<GenerationState> generationState;

		private NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMap;

		private RateLimiter _rateLimiter;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_880537417_0;

		[Preserve]
		protected override void OnCreate()
		{
			EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<DungeonAreaCD>() };
			EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
			RequireForUpdate(GetEntityQuery(entityQueryDesc2));
			pugDatabaseQ = GetEntityQuery(ComponentType.ReadOnly<PugDatabase.DatabaseBankCD>());
			customSceneTableQ = GetEntityQuery(ComponentType.ReadOnly<CustomSceneTableCD>());
			RequireForUpdate<PugDatabase.DatabaseBankCD>();
			generationState = new NativeReference<GenerationState>(new GenerationState
			{
				CurrentlyGeneratingEntity = Entity.Null,
				RoomIdx = 0,
				PathIdx = 0
			}, Allocator.Persistent);
			entitiesAwaitingGeneration = new NativeQueue<Entity>(Allocator.Persistent);
			spawnMap = new NativeParallelMultiHashMap<int2, SpawnMapEntry>(200000, Allocator.Persistent);
			_rateLimiter = new RateLimiter(PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			generationState.Dispose();
			entitiesAwaitingGeneration.Dispose();
			spawnMap.Dispose();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			if (!pugDatabaseQ.IsEmpty)
			{
				database = pugDatabaseQ.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
			}
			if (!customSceneTableQ.IsEmpty)
			{
				customSceneTable = customSceneTableQ.GetSingleton<CustomSceneTableCD>().Value;
			}
			base.OnStartRunning();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			NativeReference<GenerationState> generationStateLocal = generationState;
			NativeQueue<Entity> entitiesAwaitingGenerationLocal = entitiesAwaitingGeneration;
			if (generationStateLocal.Value.CurrentlyGeneratingEntity != Entity.Null && !base.EntityManager.Exists(generationStateLocal.Value.CurrentlyGeneratingEntity))
			{
				Debug.LogWarning("Entity under generation no longer exists.");
				generationStateLocal.Value = new GenerationState
				{
					CurrentlyGeneratingEntity = Entity.Null
				};
			}
			Entity item;
			while (generationStateLocal.Value.CurrentlyGeneratingEntity == Entity.Null && entitiesAwaitingGeneration.TryDequeue(out item))
			{
				if (!base.EntityManager.Exists(item))
				{
					Debug.LogError($"Entity {item} {base.EntityManager.GetName(item)} no longer exists.");
					continue;
				}
				GenerationState value = generationStateLocal.Value;
				value.CurrentlyGeneratingEntity = item;
				value.RoomIdx = 0;
				value.PathIdx = 0;
				value.InitializeRng = true;
				generationStateLocal.Value = value;
			}
			if (generationStateLocal.Value.CurrentlyGeneratingEntity != Entity.Null)
			{
				EntityCommandBuffer ecb = CreateCommandBuffer();
				BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
				BlobAssetReference<CustomSceneTableBlob> customSceneTableLocal = customSceneTable;
				bool isPlaying = Application.isPlaying;
				NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMapLocal = spawnMap;
				BufferLookup<DungeonRoomBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferLookup, ref base.CheckedStateRef);
				BufferLookup<DungeonPathBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferLookup, ref base.CheckedStateRef);
				BufferLookup<DungeonSpawnedObjectBuffer> bufferLookup3 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferLookup, ref base.CheckedStateRef);
				ComponentLookup<DirectionBasedOnVariationCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref base.CheckedStateRef);
				ComponentLookup<DontOverrideInDungeonGenerationCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontOverrideInDungeonGenerationCD_RO_ComponentLookup, ref base.CheckedStateRef);
				NativeArray<int2> allDirs = CollectionHelper.CreateNativeArray<int2>(Direction.allEightClockwise.Length, base.World.UpdateAllocator.ToAllocator);
				for (int i = 0; i < allDirs.Length; i++)
				{
					allDirs[i] = Direction.allEightClockwise[i].vec2i.ToInt2();
				}
				int maxIterationsThisTick = ((!isPlaying) ? int.MaxValue : _rateLimiter.UpdateAndGetCurrentTarget(generationStateLocal.Value.TotalRoomsAndPathsInQueue));
				DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Execute(generationStateLocal, ecb, databaseLocal, customSceneTableLocal, isPlaying, spawnMapLocal, bufferLookup, bufferLookup2, bufferLookup3, componentLookup, componentLookup2, allDirs, maxIterationsThisTick);
			}
			DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Execute(generationStateLocal, entitiesAwaitingGenerationLocal);
			base.OnUpdate();
		}

		private static void SpawnCustomScene(in FixedString64Bytes sceneName, RoomCD room, BlobAssetReference<CustomSceneTableBlob> customScenesTable, ref NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMap, ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects, NativeParallelHashSet<int2> positionsSet, BlobAssetReference<PugDatabase.PugDatabaseBank> database, EntityCommandBuffer ecb, bool isPlaying, ref Unity.Mathematics.Random rng, ComponentLookup<DirectionBasedOnVariationCD> directionLookup, ComponentLookup<DontOverrideInDungeonGenerationCD> dontOverrideLookup)
		{
			ref BlobArray<CustomSceneBlob> scenes = ref customScenesTable.Value.scenes;
			for (int i = 0; i < scenes.Length; i++)
			{
				if (scenes[i].sceneName.Equals(sceneName))
				{
					SpawnCustomScene(ref scenes[i], room, ref spawnMap, ref spawnObjects, positionsSet, database, ecb, isPlaying, ref rng, directionLookup, dontOverrideLookup, i);
					break;
				}
			}
		}

		private static void SpawnCustomScene(ref CustomSceneBlob customScene, RoomCD room, ref NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMap, ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects, NativeParallelHashSet<int2> positionsSet, BlobAssetReference<PugDatabase.PugDatabaseBank> database, EntityCommandBuffer ecb, bool isPlaying, ref Unity.Mathematics.Random rng, ComponentLookup<DirectionBasedOnVariationCD> directionLookup, ComponentLookup<DontOverrideInDungeonGenerationCD> dontOverrideLookup, int sceneIndex)
		{
			if (!database.IsCreated)
			{
				return;
			}
			positionsSet.Clear();
			ref BlobArray<TileCD> tiles = ref customScene.tiles;
			ref BlobArray<int2> tilePositions = ref customScene.tilePositions;
			int2 int5 = new int2((!customScene.canFlipX || !rng.NextBool()) ? 1 : (-1), (!customScene.canFlipY || !rng.NextBool()) ? 1 : (-1));
			for (int i = 0; i < tiles.Length; i++)
			{
				TileCD tileCD = tiles[i];
				int2 pos = room.position + int5 * (tilePositions[i] - customScene.centerPosition);
				ObjectDataCD objectData = PugDatabase.GetObjectData(tileCD.tileset, tileCD.tileType, database);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, database);
				bool dontOverrideObject = dontOverrideLookup.HasComponent(primaryPrefabEntity);
				if (objectData.objectID != ObjectID.None)
				{
					AddSpawn(objectData, LootTableID.Empty, pos, 1, ref spawnObjects, spawnMap, positionsSet, dontOverrideObject);
				}
			}
			ref BlobArray<Entity> prefabs = ref customScene.prefabs;
			ref BlobArray<float3> prefabPositions = ref customScene.prefabPositions;
			ref BlobArray<int2> prefabSizes = ref customScene.prefabSizes;
			ref BlobArray<int2> prefabCornerOffsets = ref customScene.prefabCornerOffsets;
			ref BlobArray<ObjectDataCD> prefabObjectDatas = ref customScene.prefabObjectDatas;
			for (int j = 0; j < prefabs.Length; j++)
			{
				ObjectDataCD toSpawn = prefabObjectDatas[j];
				Entity entity = prefabs[j];
				if (directionLookup.HasComponent(entity))
				{
					toSpawn.variation = DirectionBasedOnVariationCD.GetFlippedVariation(toSpawn.variation, int5.x == -1, int5.y == -1);
				}
				Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(toSpawn.objectID, database);
				bool dontOverrideObject2 = dontOverrideLookup.HasComponent(primaryPrefabEntity2);
				float3 x = room.position.ToFloat3() + int5.ToFloat3() * (prefabPositions[j] - customScene.centerPosition.ToFloat3());
				int2 x2 = math.min(0, int5) * (prefabSizes[j] + prefabCornerOffsets[j] * 2 - 1);
				x += x2.ToFloat3();
				AddSpawn(toSpawn, LootTableID.Empty, x.RoundToInt2(), prefabSizes[j], ref spawnObjects, spawnMap, positionsSet, dontOverrideObject2, prefabs[j], x.ToFloat2(), sceneIndex, j);
			}
		}

		private static void Spawn(bool isRoom, RoomCD room, PathCD path, int2 dungeonCenter, ref Unity.Mathematics.Random rng, DungeonAreaCD dungeonArea, NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMap, NativeParallelHashSet<int2> positionsSet, BlobAssetReference<SpawnTemplateBlob> spawnTemplate, BlobAssetReference<PugDatabase.PugDatabaseBank> database, NativeArray<int2> allDirs, ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects, ComponentLookup<DontOverrideInDungeonGenerationCD> dontOverrideLookup)
		{
			if (!spawnTemplate.IsCreated)
			{
				return;
			}
			positionsSet.Clear();
			quaternion q = default(quaternion);
			quaternion q2 = default(quaternion);
			float num = 0f;
			float2 float5 = default(float2);
			uint seed = rng.NextUInt();
			int2 int5;
			int num2;
			if (isRoom)
			{
				int5 = room.position;
				num2 = room.size;
			}
			else
			{
				int2 int6 = path.to - path.from;
				int num3 = (int)math.ceil(math.length(int6));
				int5 = (path.from + path.to) / 2;
				num2 = num3 / 2;
				num = 0f - math.atan2(int6.y, int6.x);
				q = quaternion.RotateY(num);
				q2 = quaternion.RotateY(0f - num);
				float5 = new float2((float)num3 / 2f, path.width / 2f);
			}
			if (num2 == 0)
			{
				return;
			}
			SpotShapeEnumerator spotShapeEnumerator = default(SpotShapeEnumerator);
			CircleShapeEnumerator circleShapeEnumerator = default(CircleShapeEnumerator);
			RectShapeEnumerator rectShapeEnumerator = default(RectShapeEnumerator);
			ClusterShapeEnumerator clusterShapeEnumerator = default(ClusterShapeEnumerator);
			for (int i = 0; i < spawnTemplate.Value.entries.Length; i++)
			{
				ref SpawnEntryCD reference = ref spawnTemplate.Value.entries[i];
				if (reference.disabled || rng.NextFloat() > reference.chanceToAppearAtAll)
				{
					continue;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(reference.objectToSpawn.objectID, database);
				bool dontOverrideObject = dontOverrideLookup.HasComponent(primaryPrefabEntity);
				GetRandomVariationInfo(ref reference, ref rng, database, out var variation, out var entitySize, out var entityOffset);
				int num4 = rng.NextInt(reference.amount.min, reference.amount.max + 1);
				for (int j = 0; j < num4; j++)
				{
					int2 int7;
					if (isRoom)
					{
						float x = rng.NextFloat(0f, MathF.PI * 2f);
						int7 = (int2)math.round(rng.NextFloat(reference.placement.min, reference.placement.max) * (float)num2 * new float2(math.cos(x), math.sin(x)));
					}
					else
					{
						float2 x2 = new float2(rng.NextFloat(reference.placement.min, reference.placement.max), rng.NextFloat(-1f, 1f)) * float5;
						x2.x = (rng.NextBool() ? x2.x : (0f - x2.x));
						int7 = math.rotate(q, x2.ToFloat3()).RoundToInt2();
					}
					float2 size = rng.NextFloat(reference.shapeSize.min, reference.shapeSize.max) * (float)num2;
					float num5 = rng.NextFloat(reference.oblongness.min, reference.oblongness.max);
					if (num5 < 0f)
					{
						size.x *= 1f + num5;
					}
					else if (num5 > 0f)
					{
						size.y *= 1f - num5;
					}
					float rotation;
					if (reference.rotateTowardsCenter)
					{
						if (isRoom)
						{
							int2 int8 = int5 - dungeonCenter;
							rotation = 0f - math.atan2(int8.y, int8.x);
						}
						else
						{
							rotation = num;
						}
					}
					else
					{
						rotation = rng.NextFloat(reference.tilt.min, reference.tilt.max);
					}
					switch (reference.algorithm)
					{
					case SpawnAlgorithm.Spot:
						spotShapeEnumerator = new SpotShapeEnumerator(int7);
						break;
					case SpawnAlgorithm.Circle:
						circleShapeEnumerator = new CircleShapeEnumerator(int7, size, rotation);
						break;
					case SpawnAlgorithm.Rect:
						rectShapeEnumerator = new RectShapeEnumerator(int7, size, rotation);
						break;
					case SpawnAlgorithm.Cluster:
						clusterShapeEnumerator = new ClusterShapeEnumerator(int7, size, rotation, rng.NextUInt(), Allocator.Temp);
						break;
					}
					while (true)
					{
						int2 int9 = default(int2);
						bool flag = false;
						bool flag2 = true;
						switch (reference.algorithm)
						{
						case SpawnAlgorithm.Spot:
							if (spotShapeEnumerator.MoveNext())
							{
								int9 = spotShapeEnumerator.Current;
								flag = true;
							}
							break;
						case SpawnAlgorithm.Circle:
							if (circleShapeEnumerator.MoveNext())
							{
								int9 = circleShapeEnumerator.Current;
								flag = true;
							}
							break;
						case SpawnAlgorithm.Rect:
							if (rectShapeEnumerator.MoveNext())
							{
								int9 = rectShapeEnumerator.Current;
								if (reference.placementAlignment != PlacementAlignment.Anywhere && (rectShapeEnumerator.Placement & reference.placementAlignment) == 0)
								{
									flag2 = false;
								}
								flag = true;
							}
							break;
						case SpawnAlgorithm.Cluster:
							if (clusterShapeEnumerator.MoveNext())
							{
								int9 = clusterShapeEnumerator.Current;
								flag = true;
							}
							break;
						}
						if (!flag)
						{
							break;
						}
						if (!flag2 || rng.NextFloat() >= reference.randomChance)
						{
							continue;
						}
						int amount = rng.NextInt(reference.objectToSpawn.amount.min, reference.objectToSpawn.amount.max + 1);
						RerollRandomVariationInfo(ref reference, ref rng, database, ref variation, ref entitySize, ref entityOffset);
						ObjectDataCD toSpawn = new ObjectDataCD
						{
							objectID = reference.objectToSpawn.objectID,
							amount = amount,
							variation = variation
						};
						int2 int10 = int9;
						int10 += int5;
						bool flag3 = true;
						for (int k = entityOffset.x; k < entitySize.x + entityOffset.x; k++)
						{
							for (int l = entityOffset.y; l < entitySize.y + entityOffset.y; l++)
							{
								int2 int11 = int10 + new int2(k, l);
								int2 int12 = int9 + new int2(k, l);
								if (isRoom)
								{
									float num6 = math.fmod(math.atan2(int12.y, int12.x) + MathF.PI * 2f, MathF.PI * 2f);
									if (num2 >= dungeonArea.radius)
									{
										if (math.length(int12) > dungeonArea.GetRadiusIncludingShape(num6) + 0.5f)
										{
											flag3 = false;
											break;
										}
									}
									else
									{
										float num7 = MathUtilities.SquiggleNoise(num6, MathF.PI * 2f, spawnTemplate.Value.shapeFreq, seed);
										if (math.length(int12) > (float)num2 * (1f + spawnTemplate.Value.shapeAmp * num7))
										{
											flag3 = false;
											break;
										}
									}
								}
								else
								{
									float3 x3 = math.rotate(q2, int12.ToFloat3());
									float num8 = MathUtilities.SquiggleNoise(x3.x / 50f, 1f, spawnTemplate.Value.shapeFreq, seed) * spawnTemplate.Value.shapeAmp;
									float num9 = math.abs(x3.x) / float5.x;
									x3.z = math.lerp(x3.z + num8, x3.z, num9 * num9);
									if (math.any(math.abs(x3.ToFloat2()) > float5 + 0.1f))
									{
										flag3 = false;
										break;
									}
								}
								bool flag4 = reference.canSpawnOn.Length == 0;
								if (spawnMap.TryGetFirstValue(int11, out var item, out var it))
								{
									do
									{
										if (item.objectData.objectID == toSpawn.objectID && positionsSet.Contains(int11))
										{
											flag3 = false;
										}
										if (i != 0 && !positionsSet.Contains(int11))
										{
											continue;
										}
										for (int m = 0; m < reference.canNotSpawnOn.Length; m++)
										{
											if (reference.canNotSpawnOn[m] == item.objectData.objectID)
											{
												flag3 = false;
												break;
											}
										}
										if (!flag3)
										{
											break;
										}
										if (reference.cannotSpawnOnAnyPreviousObject)
										{
											for (int n = 0; n < reference.canSpawnOn.Length; n++)
											{
												if (reference.canSpawnOn[n] != item.objectData.objectID)
												{
													flag3 = false;
													break;
												}
											}
										}
										if (!flag3)
										{
											break;
										}
										for (int num10 = 0; num10 < reference.canSpawnOn.Length; num10++)
										{
											if (reference.canSpawnOn[num10] == item.objectData.objectID)
											{
												flag4 = true;
											}
										}
									}
									while (spawnMap.TryGetNextValue(out item, ref it));
								}
								else if (reference.canSpawnOn.Length > 0 && reference.canSpawnOn[0] == ObjectID.None)
								{
									flag4 = true;
								}
								if (!flag4)
								{
									flag3 = false;
								}
								if (!flag3)
								{
									break;
								}
								if (reference.canSpawnNextTo.Length <= 0)
								{
									continue;
								}
								bool flag5 = false;
								for (int num11 = 0; num11 < allDirs.Length; num11++)
								{
									int2 int13 = allDirs[num11];
									if (spawnMap.TryGetFirstValue(int11 + int13, out var item2, out var it2))
									{
										do
										{
											for (int num12 = 0; num12 < reference.canSpawnNextTo.Length; num12++)
											{
												if (reference.canSpawnNextTo[num12] == item2.objectData.objectID)
												{
													flag5 = true;
													break;
												}
											}
										}
										while (spawnMap.TryGetNextValue(out item2, ref it2));
									}
									else
									{
										for (int num13 = 0; num13 < reference.canSpawnNextTo.Length; num13++)
										{
											if (reference.canSpawnNextTo[num13] == ObjectID.None)
											{
												flag5 = true;
												break;
											}
										}
									}
									if (flag5)
									{
										break;
									}
								}
								if (!flag5)
								{
									flag3 = false;
									break;
								}
							}
							if (!flag3)
							{
								break;
							}
						}
						if (flag3)
						{
							AddSpawn(toSpawn, reference.containLoot, int10, entitySize, ref spawnObjects, spawnMap, positionsSet, dontOverrideObject);
						}
					}
					if (reference.algorithm == SpawnAlgorithm.Cluster)
					{
						clusterShapeEnumerator.Dispose();
					}
				}
			}
		}

		private static void GetRandomVariationInfo(ref SpawnEntryCD template, ref Unity.Mathematics.Random rng, BlobAssetReference<PugDatabase.PugDatabaseBank> database, out int variation, out int2 entitySize, out int2 entityOffset)
		{
			variation = GetRandomVariation(ref rng, ref template.objectToSpawn);
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(template.objectToSpawn.objectID, database, variation);
			entitySize = math.max(entityObjectInfo.prefabTileSize, 1);
			entityOffset = entityObjectInfo.prefabCornerOffset;
		}

		private static void RerollRandomVariationInfo(ref SpawnEntryCD template, ref Unity.Mathematics.Random rng, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ref int variation, ref int2 entitySize, ref int2 entityOffset)
		{
			int randomVariation = GetRandomVariation(ref rng, ref template.objectToSpawn);
			if (randomVariation != variation)
			{
				variation = randomVariation;
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(template.objectToSpawn.objectID, database, variation);
				entitySize = math.max(entityObjectInfo.prefabTileSize, 1);
				entityOffset = entityObjectInfo.prefabCornerOffset;
			}
		}

		private static int GetRandomVariation(ref Unity.Mathematics.Random rng, ref ObjectDataWithRange objectData)
		{
			int randomIndex = GetRandomIndex(ref rng, ref objectData.accumulatedVariationProbability);
			return objectData.variations[randomIndex];
		}

		private static int GetRandomIndex(ref Unity.Mathematics.Random rng, ref BlobArray<float> normalizedWeights)
		{
			float num = rng.NextFloat();
			for (int i = 0; i < normalizedWeights.Length; i++)
			{
				if (num < normalizedWeights[i])
				{
					return i;
				}
			}
			return normalizedWeights.Length - 1;
		}

		private static void AddSpawn(ObjectDataCD toSpawn, LootTableID containLoot, int2 pos, int2 entitySize, ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects, NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMap, NativeParallelHashSet<int2> positionsSet, bool dontOverrideObject, Entity prefabEntity = default(Entity), float2 prefabPosition = default(float2), int sceneIndex = -1, int scenePrefabIndex = -1)
		{
			for (int i = 0; i < entitySize.x; i++)
			{
				for (int j = 0; j < entitySize.y; j++)
				{
					int2 int5 = pos + new int2(i, j);
					if (!positionsSet.Contains(int5))
					{
						positionsSet.Add(int5);
						if (spawnMap.TryGetFirstValue(int5, out var item, out var it))
						{
							do
							{
								if (!item.dontOverrideObject)
								{
									spawnObjects.ElementAt(item.spawnIndex) = default(DungeonSpawnedObjectBuffer);
								}
							}
							while (spawnMap.TryGetNextValue(out item, ref it));
							spawnMap.Remove(int5);
						}
					}
					spawnMap.Add(int5, new SpawnMapEntry
					{
						objectData = toSpawn,
						spawnIndex = spawnObjects.Length,
						dontOverrideObject = dontOverrideObject
					});
				}
			}
			spawnObjects.Add(new DungeonSpawnedObjectBuffer
			{
				position = pos,
				objectData = toSpawn,
				loot = containLoot,
				prefabEntity = prefabEntity,
				prefabEntityPosition = prefabPosition,
				optionalSceneIndex = sceneIndex,
				optionalScenePrefabIndex = scenePrefabIndex
			});
		}

		private void DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Execute(NativeReference<GenerationState> generationStateLocal, NativeQueue<Entity> entitiesAwaitingGenerationLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Job jobData = new DungeonGenerateRoomsSystem_47075FBF_LambdaJob_0_Job
			{
				generationStateLocal = generationStateLocal,
				entitiesAwaitingGenerationLocal = entitiesAwaitingGenerationLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__roomBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle,
				__pathBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_880537417_0, base.CheckedStateRef.Dependency);
		}

		private void DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Execute(NativeReference<GenerationState> generationStateLocal, EntityCommandBuffer ecb, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, BlobAssetReference<CustomSceneTableBlob> customSceneTableLocal, bool isPlaying, NativeParallelMultiHashMap<int2, SpawnMapEntry> spawnMapLocal, BufferLookup<DungeonRoomBuffer> roomBufferAccessor, BufferLookup<DungeonPathBuffer> pathBufferAccessor, BufferLookup<DungeonSpawnedObjectBuffer> spawnObjectsAccessor, ComponentLookup<DirectionBasedOnVariationCD> directionLookup, ComponentLookup<DontOverrideInDungeonGenerationCD> dontOverrideLookup, NativeArray<int2> allDirs, int maxIterationsThisTick)
		{
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Job jobData = new DungeonGenerateRoomsSystem_47075FBF_LambdaJob_1_Job
			{
				generationStateLocal = generationStateLocal,
				ecb = ecb,
				databaseLocal = databaseLocal,
				customSceneTableLocal = customSceneTableLocal,
				isPlaying = isPlaying,
				spawnMapLocal = spawnMapLocal,
				roomBufferAccessor = roomBufferAccessor,
				pathBufferAccessor = pathBufferAccessor,
				spawnObjectsAccessor = spawnObjectsAccessor,
				directionLookup = directionLookup,
				dontOverrideLookup = dontOverrideLookup,
				allDirs = allDirs,
				maxIterationsThisTick = maxIterationsThisTick,
				__PugWorldGen_DungeonAreaCD_ComponentLookup = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentLookup,
				__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup
			};
			base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonRoomBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonPathBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonSpawnedObjectBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonAreaCD>();
			__query_880537417_0 = entityQueryBuilder2.Build(ref state);
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
		public DungeonGenerateRoomsSystem()
		{
		}
	}
}
