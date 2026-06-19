using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using PugWorldGen;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(DisableEntitiesSystem))]
public class SpawnEnvironmentObjectsSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct WaitingToSpawn : IComponentData, IQueryTypeParameter
	{
	}

	private struct SpawnEntityAndPosition
	{
		public Entity Entity;

		public int2 Position;

		public int2 Size;
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(SpawnEnvironmentObjectsCD) })]
	[WithNone(new Type[]
	{
		typeof(WaitingToSpawn),
		typeof(EnableEntitiesInBoxCD)
	})]
	private struct EnqueueJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SpawnEnvironmentObjectsCD> __SpawnEnvironmentObjectsCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SpawnEnvironmentObjectsCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnEnvironmentObjectsCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SpawnEnvironmentObjectsCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<WaitingToSpawn>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<EnableEntitiesInBoxCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnEnvironmentObjectsCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref EnqueueJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref EnqueueJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref EnqueueJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref EnqueueJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref EnqueueJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref EnqueueJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public EntityCommandBuffer Ecb;

		public NativeList<SpawnEntityAndPosition> Queue;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, SpawnEnvironmentObjectsCD spawnTrigger)
		{
			ref NativeList<SpawnEntityAndPosition> queue = ref Queue;
			SpawnEntityAndPosition value = new SpawnEntityAndPosition
			{
				Entity = entity,
				Position = spawnTrigger.position,
				Size = spawnTrigger.size
			};
			queue.Add(in value);
			Ecb.AddComponent<WaitingToSpawn>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SpawnEnvironmentObjectsCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct SpawnEnvironmentObjectsSystem_1EEEEFC0_LambdaJob_0_Job : IJobChunk
	{
		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public uint serverSeedLocal;

		public Entity updatedTilesSingletonLocal;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public NativeArray<BlockedSpawnArea> globalBlockedAreas;

		[ReadOnly]
		public TileAccessor tileLookup;

		public Entity environmentSpawnObjectsBufferEntityLocal;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public NativeParallelHashMap<TileCD, ObjectID> objectIdLookup;

		public BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup;

		public NativeArray<WorldGenerationSettingLevel> worldGenSettingsLocal;

		[ReadOnly]
		public BiomeLookup biomeLookupLocal;

		public int2 left;

		public int2 right;

		public int2 top;

		public int2 bot;

		public uint respawnSeed;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SpawnEnvironmentObjectsCD> __areaTypeHandle;

		public BufferLookup<EnvironmentSpawnObjectBuffer> __EnvironmentSpawnObjectBuffer_BufferLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in SpawnEnvironmentObjectsCD area)
		{
			ecb.DestroyEntity(entity);
			NativeArray<BlockedSpawnArea> blockedAreas = ((area.optionalSpawnEntityRef == Entity.Null) ? globalBlockedAreas : blockedSpawnAreaBufferLookup[area.optionalSpawnEntityRef].AsNativeArray().Reinterpret<BlockedSpawnArea>());
			DynamicBuffer<EnvironmentSpawnObjectBuffer> environmentSpawnObjects = __EnvironmentSpawnObjectBuffer_BufferLookup[environmentSpawnObjectsBufferEntityLocal];
			int num = area.size.x * area.size.y;
			NativeArray<ObjectID> spawnedPositions = new NativeArray<ObjectID>(num * 9, Allocator.Temp);
			NativeParallelHashMap<int, int> objectCount = new NativeParallelHashMap<int, int>(objectIdLookup.Capacity, Allocator.Temp);
			NativeList<int2> list = new NativeList<int2>(8, Allocator.Temp);
			NativeArray<int> nativeArray = new NativeArray<int>(environmentSpawnObjects.Length, Allocator.Temp);
			NativeArray<int> nativeArray2 = new NativeArray<int>(environmentSpawnObjects.Length, Allocator.Temp);
			NativeArray<int2> list2 = new NativeArray<int2>(num, Allocator.Temp);
			Unity.Mathematics.Random rng = (area.respawn ? new Unity.Mathematics.Random(respawnSeed) : new Unity.Mathematics.Random(math.hash(area.position) + serverSeedLocal));
			NativeArray<float> nativeArray3 = new NativeArray<float>(environmentSpawnObjects.Length, Allocator.Temp);
			NativeParallelHashMap<TileCD, int> nativeParallelHashMap = new NativeParallelHashMap<TileCD, int>(num, Allocator.Temp);
			for (int i = 0; i < list2.Length; i++)
			{
				int y = i / area.size.x + area.position.y;
				int x = i % area.size.x + area.position.x;
				list2[i] = new int2(x, y);
			}
			for (int j = area.position.y; j < area.position.y + area.size.y; j++)
			{
				for (int k = area.position.x; k < area.position.x + area.size.x; k++)
				{
					int2 worldPosition = new int2(k, j);
					TileCD key = tileLookup.GetTop(worldPosition);
					if (nativeParallelHashMap.TryGetValue(key, out var item))
					{
						nativeParallelHashMap[key] = item + 1;
					}
					else
					{
						nativeParallelHashMap.Add(key, 1);
					}
					if (objectIdLookup.TryGetValue(key, out var item2))
					{
						if (!objectCount.ContainsKey((int)item2))
						{
							objectCount.Add((int)item2, 1);
						}
						else
						{
							objectCount[(int)item2]++;
						}
					}
				}
			}
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			int2 int5 = area.size / 2;
			int2 int6 = area.position + int5;
			float2 float5 = (float2)int5 * 3f;
			int2 int7 = int6 - int5 - new int2(1, 1);
			int2 int8 = int6 + int5 + new int2(1, 1);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 9291u
			};
			if (collisionWorld.OverlapBox(int6.ToFloat3(), quaternion.identity, new float3(float5.x, 10f, float5.y), ref outHits, filter))
			{
				for (int l = 0; l < outHits.Length; l++)
				{
					if (!__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(outHits[l].Entity) || !__ObjectDataCD_ComponentLookup.HasComponent(outHits[l].Entity))
					{
						continue;
					}
					int2 value = __Unity_Transforms_LocalTransform_ComponentLookup[outHits[l].Entity].Position.RoundToInt2();
					ObjectDataCD objectDataCD = __ObjectDataCD_ComponentLookup[outHits[l].Entity];
					ObjectID objectId = objectDataCD.objectID;
					if (value.x > int7.x && value.x < int8.x && value.y > int7.y && value.y < int8.y)
					{
						if (!objectCount.ContainsKey((int)objectId))
						{
							objectCount.Add((int)objectId, 1);
						}
						else
						{
							objectCount[(int)objectId]++;
						}
					}
					if (objectId == ObjectID.Player && !list.Contains(value))
					{
						list.Add(in value);
					}
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, databaseLocal);
					int2 prefabTileSize = entityObjectInfo.prefabTileSize;
					int2 prefabCornerOffset = entityObjectInfo.prefabCornerOffset;
					for (int m = prefabCornerOffset.x; m < prefabTileSize.x + prefabCornerOffset.x; m++)
					{
						for (int n = prefabCornerOffset.y; n < prefabTileSize.y + prefabCornerOffset.y; n++)
						{
							SetObjectAt(value + new int2(m, n), in objectId, in area, ref spawnedPositions);
						}
					}
				}
			}
			outHits.Dispose();
			for (int num2 = 0; num2 < environmentSpawnObjects.Length; num2++)
			{
				EnvironmentSpawnObjectBuffer environmentSpawnObjectBuffer = environmentSpawnObjects[num2];
				nativeArray3[num2] = environmentSpawnObjectBuffer.spawnChance.GetValue(worldGenSettingsLocal[(int)environmentSpawnObjectBuffer.spawnChance.worldGenSetting]);
				if (nativeArray3[num2] == 0f || area.respawn != environmentSpawnObjectBuffer.respawn)
				{
					continue;
				}
				nativeArray2[num2] = int.MaxValue;
				if (area.respawn && (environmentSpawnObjectBuffer.minTilesRequiredToRespawn > 0f || environmentSpawnObjectBuffer.maxSpawnPerTile > 0f))
				{
					int num3 = 0;
					for (int num4 = 0; num4 < environmentSpawnObjectBuffer.onlySpawnsOnTilesets.Length; num4++)
					{
						TileCD key2 = new TileCD
						{
							tileset = (int)environmentSpawnObjectBuffer.onlySpawnsOnTilesets[num4],
							tileType = environmentSpawnObjectBuffer.spawnsOnTileType
						};
						if (nativeParallelHashMap.TryGetValue(key2, out var item3))
						{
							num3 += item3;
						}
					}
					if (environmentSpawnObjectBuffer.minTilesRequiredToRespawn > 0f && (float)num3 < environmentSpawnObjectBuffer.minTilesRequiredToRespawn)
					{
						continue;
					}
					if (environmentSpawnObjectBuffer.maxSpawnPerTile > 0f)
					{
						nativeArray2[num2] = (int)math.ceil(environmentSpawnObjectBuffer.maxSpawnPerTile * (float)num3);
						if (objectCount.TryGetValue((int)environmentSpawnObjectBuffer.objectId, out var item4))
						{
							nativeArray2[num2] -= item4;
						}
					}
					if (environmentSpawnObjectBuffer.maxSpawnsPerRespawn != 0)
					{
						nativeArray2[num2] = math.min(nativeArray2[num2], environmentSpawnObjectBuffer.maxSpawnsPerRespawn);
					}
				}
				int num5 = 0;
				if (nativeArray2[num2] > 0)
				{
					for (int num6 = 0; num6 < num; num6++)
					{
						if (rng.NextFloat() < nativeArray3[num2])
						{
							num5++;
						}
					}
				}
				nativeArray[num2] = num5;
			}
			for (int num7 = 0; num7 < environmentSpawnObjects.Length; num7++)
			{
				if (nativeArray[num7] == 0)
				{
					continue;
				}
				float num8 = 144f;
				if (environmentSpawnObjects[num7].objectId == ObjectID.YellowFirefly || environmentSpawnObjects[num7].objectId == ObjectID.GlowingTulipPlant)
				{
					num8 = 441f;
				}
				PugRandom.ShuffleListKindOfRandomly(list2, ref rng);
				for (int num9 = 0; num9 < nativeArray[num7]; num9++)
				{
					if (nativeArray2[num7] <= 0)
					{
						break;
					}
					int2 pos = list2[num9];
					if (math.lengthsq(pos) <= num8)
					{
						continue;
					}
					bool flag = false;
					for (int num10 = 0; num10 < list.Length; num10++)
					{
						if (math.distancesq(list[num10], pos) < 36f)
						{
							flag = true;
							break;
						}
					}
					if (!flag && (environmentSpawnObjects[num7].objectId == ObjectID.RoofHole || GetObjectAt(in pos, in area, ref spawnedPositions) == ObjectID.None) && SpawnPosition(num7, ref ecb, ref databaseLocal, ref blockedAreas, ref spawnedPositions, area, updatedTilesSingletonLocal, pos, left, right, top, bot, ref tileLookup, ref rng, ref biomeLookupLocal, ref environmentSpawnObjects, ref objectCount, 1f / nativeArray3[num7], worldGenSettingsLocal))
					{
						int index = num7;
						int value2 = nativeArray2[index] - 1;
						nativeArray2[index] = value2;
					}
				}
			}
			nativeParallelHashMap.Dispose();
			nativeArray3.Dispose();
			list2.Dispose();
			nativeArray2.Dispose();
			nativeArray.Dispose();
			list.Dispose();
			objectCount.Dispose();
			spawnedPositions.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __areaTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEnvironmentObjectsCD>(nativeArrayPtr2, l));
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
		public ComponentTypeHandle<SpawnEnvironmentObjectsCD> __SpawnEnvironmentObjectsCD_RO_ComponentTypeHandle;

		public BufferLookup<EnvironmentSpawnObjectBuffer> __EnvironmentSpawnObjectBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<BlockedSpawnAreaBuffer> __BlockedSpawnAreaBuffer_RO_BufferLookup;

		public EnqueueJob.InternalCompilerQueryAndHandleData __SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__SpawnEnvironmentObjectsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnEnvironmentObjectsCD>(isReadOnly: true);
			__EnvironmentSpawnObjectBuffer_RW_BufferLookup = state.GetBufferLookup<EnvironmentSpawnObjectBuffer>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__BlockedSpawnAreaBuffer_RO_BufferLookup = state.GetBufferLookup<BlockedSpawnAreaBuffer>(isReadOnly: true);
			__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	private const float CLOSEST_PLAYER_SPAWN_DISTANCE_SQ = 36f;

	private const int MAX_SPAWN_DELAY_SECONDS = 15;

	private const int MAX_SPAWN_DELAY_ON_QUIT_SECONDS = 5;

	private int _nextSpawnQueueIndex;

	private List<Queue<SpawnEntityAndPosition>> _spawnQueueByCoordinate;

	private NativeList<SpawnEntityAndPosition> _nativeSpawnQueue;

	private RateLimiter _rateLimiter;

	private NativeArray<WorldGenerationSettingLevel> _worldGenSettings;

	private NativeParallelHashMap<TileCD, ObjectID> _objectIdLookup;

	private BiomeLookup _biomeLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_452990886_0;

	private EntityQuery __query_452990886_1;

	private EntityQuery __query_452990886_2;

	private EntityQuery __query_452990886_3;

	private EntityQuery __query_452990886_4;

	private EntityQuery __query_452990886_5;

	private EntityQuery __query_452990886_6;

	private EntityQuery __query_452990886_7;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		NeedTileUpdateBuffer();
		NeedServerSeed();
		RequireForUpdate<SpawnEnvironmentObjectsCD>();
		RequireForUpdate<EnvironmentSpawnObjectBuffer>();
		RequireForUpdate(__query_452990886_1);
		_spawnQueueByCoordinate = new List<Queue<SpawnEntityAndPosition>>(9);
		for (int i = 0; i < 9; i++)
		{
			_spawnQueueByCoordinate.Add(new Queue<SpawnEntityAndPosition>());
		}
		_nativeSpawnQueue = new NativeList<SpawnEntityAndPosition>(Allocator.Persistent);
		_rateLimiter = new RateLimiter(PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate * 15);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		_biomeLookup = (__query_452990886_4.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_452990886_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		if (!_objectIdLookup.IsCreated)
		{
			DynamicBuffer<EnvironmentSpawnObjectBuffer> singletonBuffer = __query_452990886_6.GetSingletonBuffer<EnvironmentSpawnObjectBuffer>();
			_objectIdLookup = new NativeParallelHashMap<TileCD, ObjectID>(singletonBuffer.Length * 2, Allocator.Persistent);
			for (int i = 0; i < singletonBuffer.Length; i++)
			{
				EnvironmentSpawnObjectBuffer environmentSpawnObjectBuffer = singletonBuffer[i];
				TileCD tileCD = new TileCD
				{
					tileset = (int)environmentSpawnObjectBuffer.tileset,
					tileType = environmentSpawnObjectBuffer.tileType
				};
				if (environmentSpawnObjectBuffer.isTile && !_objectIdLookup.TryAdd(tileCD, environmentSpawnObjectBuffer.objectId) && _objectIdLookup[tileCD] != environmentSpawnObjectBuffer.objectId)
				{
					UnityEngine.Debug.LogError($"duplicate spawn tile with different object {tileCD}: {_objectIdLookup[tileCD]} != {environmentSpawnObjectBuffer.objectId}");
				}
			}
		}
		if (!_worldGenSettings.IsCreated)
		{
			int length = Enum.GetValues(typeof(WorldGenerationSettingType)).Length;
			_worldGenSettings = new NativeArray<WorldGenerationSettingLevel>(length, Allocator.Persistent);
			for (int j = 0; j < length; j++)
			{
				_worldGenSettings[j] = WorldGenerationSettingLevel.Normal;
			}
			List<LevelWorldGenerationSetting> worldGenerationSettings = Manager.saves.GetWorldInfo().worldGenerationSettings;
			if (worldGenerationSettings != null)
			{
				foreach (LevelWorldGenerationSetting item in worldGenerationSettings)
				{
					_worldGenSettings[(int)item.type] = item.level;
				}
			}
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		_biomeLookup.Dispose();
		base.OnStopRunning();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		if (_objectIdLookup.IsCreated)
		{
			_objectIdLookup.Dispose();
		}
		if (_nativeSpawnQueue.IsCreated)
		{
			_nativeSpawnQueue.Dispose();
		}
		if (_worldGenSettings.IsCreated)
		{
			_worldGenSettings.Dispose();
		}
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		uint serverSeedLocal = serverSeed;
		Entity updatedTilesSingletonLocal = tileUpdateBufferSingletonEntity;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		NativeArray<BlockedSpawnArea> globalBlockedAreas = __query_452990886_2.ToComponentDataArray<BlockedSpawnAreaCD>(base.World.UpdateAllocator.ToAllocator).Reinterpret<BlockedSpawnArea>();
		TileAccessor tileLookup = CreateTileAccessor();
		Entity singletonEntity = __query_452990886_7.GetSingletonEntity();
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		NativeParallelHashMap<TileCD, ObjectID> objectIdLookup = _objectIdLookup;
		BufferLookup<BlockedSpawnAreaBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__BlockedSpawnAreaBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		NativeArray<WorldGenerationSettingLevel> worldGenSettings = _worldGenSettings;
		BiomeLookup biomeLookup = _biomeLookup;
		int2 left = new int2(-1, 0);
		int2 right = new int2(1, 0);
		int2 top = new int2(0, 1);
		int2 bot = new int2(0, -1);
		foreach (SpawnEntityAndPosition item in _nativeSpawnQueue)
		{
			int2 int5 = item.Position / 16;
			int5 = (int5 % 3 + 3) % 3;
			_spawnQueueByCoordinate[int5.x + int5.y * 3].Enqueue(item);
		}
		_nativeSpawnQueue.Clear();
		if (!__query_452990886_3.IsEmpty)
		{
			_rateLimiter.SetMaxTicksToProcessAll(PlatformConfiguration.Instance.SessionConfiguration.NetworkSendRate * 5);
		}
		int num = 0;
		foreach (Queue<SpawnEntityAndPosition> item2 in _spawnQueueByCoordinate)
		{
			num += item2.Count;
		}
		int num2 = _rateLimiter.UpdateAndGetCurrentTarget(num);
		for (int i = 0; i < 9; i++)
		{
			_nextSpawnQueueIndex = (_nextSpawnQueueIndex + 1) % 9;
			if (_spawnQueueByCoordinate[_nextSpawnQueueIndex].Count != 0)
			{
				break;
			}
		}
		Queue<SpawnEntityAndPosition> queue = _spawnQueueByCoordinate[_nextSpawnQueueIndex];
		for (int j = 0; j < num2; j++)
		{
			if (!queue.TryDequeue(out var result))
			{
				break;
			}
			int2 int6 = result.Position + result.Size / 2;
			float radius = (float)result.Size.x * 1.5f;
			ecb.AddComponent(result.Entity, new EnableEntitiesInBoxCD
			{
				Area = PugGeometry.AxisAlignedBoundingBox.FromCenterAndRadius(int6, radius)
			});
			ecb.RemoveComponent<WaitingToSpawn>(result.Entity);
		}
		EnqueueJob job = new EnqueueJob
		{
			Ecb = ecb,
			Queue = _nativeSpawnQueue
		};
		base.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: false);
		uint seed = PugRandom.GetSeed();
		SpawnEnvironmentObjectsSystem_1EEEEFC0_LambdaJob_0_Execute(databaseLocal, serverSeedLocal, updatedTilesSingletonLocal, ecb, globalBlockedAreas, tileLookup, singletonEntity, collisionWorld, objectIdLookup, bufferLookup, worldGenSettings, biomeLookup, left, right, top, bot, seed);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ObjectID GetObjectAt(in int2 pos, in SpawnEnvironmentObjectsCD area, ref NativeArray<ObjectID> spawnedPositions)
	{
		int2 size = area.size;
		int2 int5 = pos - area.position + size;
		int2 int6 = size * 3;
		int num = int5.y * int6.x + int5.x;
		if (num < 0 || num >= spawnedPositions.Length)
		{
			UnityEngine.Debug.LogError("spawn env get position out of range");
			return ObjectID.Mushroom;
		}
		return spawnedPositions[num];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void SetObjectAt(in int2 pos, in ObjectID objectId, in SpawnEnvironmentObjectsCD area, ref NativeArray<ObjectID> spawnedPositions)
	{
		if (objectId != ObjectID.RoofHole)
		{
			int2 size = area.size;
			int2 int5 = pos - area.position + size;
			int2 int6 = size * 3;
			int num = int5.y * int6.x + int5.x;
			if (num >= 0 && num < spawnedPositions.Length)
			{
				spawnedPositions[num] = objectId;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool SpawnPosition(int spawnObjectIndex, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref NativeArray<BlockedSpawnArea> blockedAreas, ref NativeArray<ObjectID> spawnedPositions, SpawnEnvironmentObjectsCD area, Entity updatedTilesSingletonLocal, int2 pos, int2 left, int2 right, int2 top, int2 bot, ref TileAccessor tileLookup, ref Unity.Mathematics.Random rng, ref BiomeLookup biomeLookup, ref DynamicBuffer<EnvironmentSpawnObjectBuffer> environmentSpawnObjects, ref NativeParallelHashMap<int, int> objectCount, float spawnChanceMultiplier, NativeArray<WorldGenerationSettingLevel> worldGenSettings)
	{
		bool flag = EntityUtility.PointIsBlockedForSpawning(blockedAreas, pos);
		EnvironmentSpawnObjectBuffer buffer = environmentSpawnObjects[spawnObjectIndex];
		int alreadyExistingAmount = 0;
		if (area.respawn && objectCount.ContainsKey((int)buffer.objectId))
		{
			alreadyExistingAmount = objectCount[(int)buffer.objectId];
		}
		if ((buffer.canSpawnInBlockedArea || !flag) && (!area.fillPartialSubMap || !buffer.skipSpawnForPartialMap) && buffer.ShouldSpawn(pos, ref rng, ref tileLookup, ref biomeLookup, left, right, top, bot, area.respawn, alreadyExistingAmount, spawnChanceMultiplier, worldGenSettings))
		{
			return SpawnObjectAtPosition(spawnObjectIndex, ref ecb, ref databaseLocal, ref blockedAreas, ref spawnedPositions, area, updatedTilesSingletonLocal, pos, ref tileLookup, ref rng, ref environmentSpawnObjects, ref objectCount);
		}
		return false;
	}

	private static bool SpawnObjectAtPosition(int spawnObjectIndex, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref NativeArray<BlockedSpawnArea> blockedAreas, ref NativeArray<ObjectID> spawnedPositions, SpawnEnvironmentObjectsCD area, Entity updatedTilesSingletonLocal, int2 pos, ref TileAccessor tileLookup, ref Unity.Mathematics.Random rng, ref DynamicBuffer<EnvironmentSpawnObjectBuffer> environmentSpawnObjects, ref NativeParallelHashMap<int, int> objectCount)
	{
		int num = 1;
		while (num > 0 && spawnObjectIndex < environmentSpawnObjects.Length)
		{
			bool flag = true;
			EnvironmentSpawnObjectBuffer environmentSpawnObjectBuffer = environmentSpawnObjects[spawnObjectIndex];
			int randomIndex = GetRandomIndex(ref rng, environmentSpawnObjectBuffer.accumulatedVariationProbability);
			int variation = environmentSpawnObjectBuffer.variations.Value[randomIndex];
			if (environmentSpawnObjectBuffer.spawnAlgorithm == EnvironmentObjectSpawnAlgorithm.Spot)
			{
				if (environmentSpawnObjectBuffer.isTile)
				{
					SetObjectAt(in pos, in environmentSpawnObjectBuffer.objectId, in area, ref spawnedPositions);
					ecb.AppendToBuffer(updatedTilesSingletonLocal, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Add,
						position = pos,
						tile = new TileCD
						{
							tileset = (int)environmentSpawnObjectBuffer.tileset,
							tileType = environmentSpawnObjectBuffer.tileType
						}
					});
					flag = true;
				}
				else
				{
					flag = TrySpawnObject(environmentSpawnObjectBuffer.objectId, variation, math.max(1, environmentSpawnObjectBuffer.amount), environmentSpawnObjectBuffer.spawnsOnTileType, pos, area, ref ecb, ref databaseLocal, ref tileLookup, ref spawnedPositions);
				}
			}
			else
			{
				SpawnCluster(environmentSpawnObjectBuffer.isTile, environmentSpawnObjectBuffer.objectId, variation, environmentSpawnObjectBuffer.tileType, (int)environmentSpawnObjectBuffer.tileset, environmentSpawnObjectBuffer.spawnsOnTileType, environmentSpawnObjectBuffer.onlySpawnsOnTilesets, environmentSpawnObjectBuffer.clusterSpawnChance, environmentSpawnObjectBuffer.clusterSpreadChance, pos, area, ref spawnedPositions, ref tileLookup, ref rng, ref ecb, updatedTilesSingletonLocal, dontSpawnOnBlockedAreas: true, ref blockedAreas, ref databaseLocal, environmentSpawnObjectBuffer.clusterSpreadType);
				flag = true;
			}
			if (!flag)
			{
				return false;
			}
			if (area.respawn)
			{
				if (objectCount.ContainsKey((int)environmentSpawnObjectBuffer.objectId))
				{
					objectCount[(int)environmentSpawnObjectBuffer.objectId]++;
				}
				else
				{
					objectCount.Add((int)environmentSpawnObjectBuffer.objectId, 1);
				}
			}
			num = math.max(num - 1, environmentSpawnObjectBuffer.alsoSpawnNextNObjectsFromSameBiome);
			spawnObjectIndex++;
		}
		return true;
	}

	private static int GetRandomIndex(ref Unity.Mathematics.Random rng, BlobAssetReference<BlobArray<float>> normalizedWeights)
	{
		ref BlobArray<float> value = ref normalizedWeights.Value;
		float num = rng.NextFloat();
		for (int i = 0; i < normalizedWeights.Value.Length; i++)
		{
			if (num < value[i])
			{
				return i;
			}
		}
		return normalizedWeights.Value.Length - 1;
	}

	private static void SpawnCluster(bool isTile, ObjectID objectID, int variation, TileType tileType, int tileset, TileType canOnlySpawnOnTile, FixedList64Bytes<Tileset> canOnlySpawnOnTilesets, float spawnChance, float decayingSpawnChance, int2 pos, SpawnEnvironmentObjectsCD area, ref NativeArray<ObjectID> spawnedPositions, ref TileAccessor tileLookup, ref Unity.Mathematics.Random rng, ref EntityCommandBuffer ecb, Entity updatedTilesSingleton, bool dontSpawnOnBlockedAreas, ref NativeArray<BlockedSpawnArea> blockedAreas, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ClusterSpreadType spreadType)
	{
		NativeParallelHashSet<int2> visited = new NativeParallelHashSet<int2>(100, Allocator.Temp);
		visited.Add(pos);
		SpawnClusterRecursive(isTile, objectID, variation, tileType, tileset, canOnlySpawnOnTile, canOnlySpawnOnTilesets, spawnChance, decayingSpawnChance, pos, pos, area, ref spawnedPositions, ref visited, ref tileLookup, ref rng, ref ecb, updatedTilesSingleton, dontSpawnOnBlockedAreas, ref blockedAreas, ref databaseLocal, spreadType, 0);
		visited.Dispose();
	}

	private static void SpawnClusterRecursive(bool isTile, ObjectID objectID, int variation, TileType tileType, int tileset, TileType canOnlySpawnOnTile, FixedList64Bytes<Tileset> canOnlySpawnOnTilesets, float spawnChance, float decayingSpawnChance, int2 startPos, int2 currentPos, SpawnEnvironmentObjectsCD area, ref NativeArray<ObjectID> spawnedPositions, ref NativeParallelHashSet<int2> visited, ref TileAccessor tileLookup, ref Unity.Mathematics.Random rng, ref EntityCommandBuffer ecb, Entity updatedTilesSingleton, bool dontSpawnOnBlockedAreas, ref NativeArray<BlockedSpawnArea> blockedAreas, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ClusterSpreadType spreadType, int count)
	{
		if (math.lengthsq(currentPos) <= 144f)
		{
			return;
		}
		if (rng.NextFloat() < spawnChance && (objectID == ObjectID.RoofHole || GetObjectAt(in currentPos, in area, ref spawnedPositions) == ObjectID.None) && (!dontSpawnOnBlockedAreas || !EntityUtility.PointIsBlockedForSpawning(blockedAreas, currentPos)) && PositionHasTile(currentPos, tileLookup, canOnlySpawnOnTile, canOnlySpawnOnTilesets))
		{
			SetObjectAt(in currentPos, in objectID, in area, ref spawnedPositions);
			if (isTile)
			{
				ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = currentPos,
					tile = new TileCD
					{
						tileset = tileset,
						tileType = tileType
					}
				});
			}
			else
			{
				EntityUtility.CreateEntity(ecb, new float3(currentPos.x, 0f, currentPos.y), objectID, 1, databaseLocal, variation);
			}
		}
		if (count + 1 >= area.size.x)
		{
			return;
		}
		int[] array = ((spreadType == ClusterSpreadType.EightWay) ? AdjacentDir.eightWay : AdjacentDir.fourWay);
		for (int i = 0; i < array.Length; i++)
		{
			int2 int5 = currentPos + AdjacentDir.GetInt2(array[i]);
			if (!visited.Contains(int5))
			{
				visited.Add(int5);
				if (rng.NextFloat() < math.pow(decayingSpawnChance, math.distance(int5, startPos)))
				{
					SpawnClusterRecursive(isTile, objectID, variation, tileType, tileset, canOnlySpawnOnTile, canOnlySpawnOnTilesets, spawnChance, decayingSpawnChance, startPos, int5, area, ref spawnedPositions, ref visited, ref tileLookup, ref rng, ref ecb, updatedTilesSingleton, dontSpawnOnBlockedAreas, ref blockedAreas, ref databaseLocal, spreadType, count + 1);
				}
			}
		}
	}

	private static bool TrySpawnObject(ObjectID objectID, int variation, int amount, TileType spawnsOnTileType, int2 pos, SpawnEnvironmentObjectsCD area, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref TileAccessor tileLookup, ref NativeArray<ObjectID> spawnedPositions)
	{
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, databaseLocal, variation);
		int2 prefabTileSize = entityObjectInfo.prefabTileSize;
		int2 prefabCornerOffset = entityObjectInfo.prefabCornerOffset;
		bool flag = true;
		for (int i = prefabCornerOffset.x; i < prefabTileSize.x + prefabCornerOffset.x; i++)
		{
			for (int j = prefabCornerOffset.y; j < prefabTileSize.y + prefabCornerOffset.y; j++)
			{
				int2 pos2 = pos + new int2(i, j);
				if ((objectID != ObjectID.RoofHole && GetObjectAt(in pos2, in area, ref spawnedPositions) != ObjectID.None) || tileLookup.GetTop(pos2).tileType != spawnsOnTileType)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		if (flag)
		{
			EntityUtility.CreateEntity(ecb, new float3(pos.x, 0f, pos.y), objectID, amount, databaseLocal, variation);
			for (int k = 0; k < prefabTileSize.x; k++)
			{
				for (int l = 0; l < prefabTileSize.y; l++)
				{
					SetObjectAt(pos + new int2(k, l), in objectID, in area, ref spawnedPositions);
				}
			}
			return true;
		}
		return false;
	}

	private static bool PositionHasTile(int2 pos, TileAccessor tileLookup, TileType tileType, FixedList64Bytes<Tileset> tilesets)
	{
		TileCD top = tileLookup.GetTop(pos);
		bool flag = tilesets.Length == 0;
		for (int i = 0; i < tilesets.Length; i++)
		{
			if (tilesets[i] == (Tileset)top.tileset)
			{
				flag = true;
				break;
			}
		}
		return top.tileType == tileType && flag;
	}

	private void SpawnEnvironmentObjectsSystem_1EEEEFC0_LambdaJob_0_Execute(BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, uint serverSeedLocal, Entity updatedTilesSingletonLocal, EntityCommandBuffer ecb, NativeArray<BlockedSpawnArea> globalBlockedAreas, TileAccessor tileLookup, Entity environmentSpawnObjectsBufferEntityLocal, CollisionWorld collisionWorld, NativeParallelHashMap<TileCD, ObjectID> objectIdLookup, BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup, NativeArray<WorldGenerationSettingLevel> worldGenSettingsLocal, BiomeLookup biomeLookupLocal, int2 left, int2 right, int2 top, int2 bot, uint respawnSeed)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnEnvironmentObjectsCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnvironmentSpawnObjectBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		SpawnEnvironmentObjectsSystem_1EEEEFC0_LambdaJob_0_Job jobData = new SpawnEnvironmentObjectsSystem_1EEEEFC0_LambdaJob_0_Job
		{
			databaseLocal = databaseLocal,
			serverSeedLocal = serverSeedLocal,
			updatedTilesSingletonLocal = updatedTilesSingletonLocal,
			ecb = ecb,
			globalBlockedAreas = globalBlockedAreas,
			tileLookup = tileLookup,
			environmentSpawnObjectsBufferEntityLocal = environmentSpawnObjectsBufferEntityLocal,
			collisionWorld = collisionWorld,
			objectIdLookup = objectIdLookup,
			blockedSpawnAreaBufferLookup = blockedSpawnAreaBufferLookup,
			worldGenSettingsLocal = worldGenSettingsLocal,
			biomeLookupLocal = biomeLookupLocal,
			left = left,
			right = right,
			top = top,
			bot = bot,
			respawnSeed = respawnSeed,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__areaTypeHandle = __TypeHandle.__SpawnEnvironmentObjectsCD_RO_ComponentTypeHandle,
			__EnvironmentSpawnObjectBuffer_BufferLookup = __TypeHandle.__EnvironmentSpawnObjectBuffer_RW_BufferLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_452990886_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(EnqueueJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpawnEnvironmentObjectsSystem_EnqueueJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnEnvironmentObjectsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PositionHasBeenEnabled>();
		__query_452990886_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_452990886_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BlockedSpawnAreaCD>();
		__query_452990886_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<QuitPendingCD>();
		__query_452990886_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_452990886_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_452990886_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<EnvironmentSpawnObjectBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_452990886_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EnvironmentSpawnObjectBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_452990886_7 = entityQueryBuilder2.Build(ref state);
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
	public SpawnEnvironmentObjectsSystem()
	{
	}
}
