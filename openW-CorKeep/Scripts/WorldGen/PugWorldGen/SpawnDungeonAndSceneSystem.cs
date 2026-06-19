using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

namespace PugWorldGen
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct SpawnDungeonAndSceneSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct HasSpawnedArea : IComponentData, IQueryTypeParameter
		{
		}

		private struct AfterSpawnCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
		{
			public Entity AreaEntityRef;
		}

		private struct CustomSceneSpawnCount
		{
			public int IndexInTable;

			public int RemainingSpawnCount;

			public int Radius;
		}

		[BurstCompile]
		private struct SpawnJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<SpawnDungeonsAndScenesInArea> __SpawnDungeonsAndScenesInArea_RW_ComponentTypeHandle;

					public BufferTypeHandle<BlockedSpawnAreaBuffer> __BlockedSpawnAreaBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__SpawnDungeonsAndScenesInArea_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnDungeonsAndScenesInArea>();
						__BlockedSpawnAreaBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<BlockedSpawnAreaBuffer>();
						__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__SpawnDungeonsAndScenesInArea_RW_ComponentTypeHandle.Update(ref state);
						__BlockedSpawnAreaBuffer_RW_BufferTypeHandle.Update(ref state);
						__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnDungeonsAndScenesInArea>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BlockedSpawnAreaBuffer>();
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
				public void Run(ref SpawnJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SpawnJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SpawnJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SpawnJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SpawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SpawnJob job, EntityManager entityManager)
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

			private const int FAKE_BLOCKER_IDENTIFIER = 123456;

			private static readonly ProfilerMarker BestSampleMarker = new ProfilerMarker("Find best sample");

			private static readonly ProfilerMarker FindDungeonMarker = new ProfilerMarker("Find dungeon");

			private static readonly ProfilerMarker SpawnDungeonMarker = new ProfilerMarker("Spawn dungeon");

			private static readonly ProfilerMarker FindCustomSceneMarker = new ProfilerMarker("Find custom scene");

			private static readonly ProfilerMarker SpawnCustomSceneMarker = new ProfilerMarker("Spawn custom scene");

			public EntityCommandBuffer Ecb;

			public uint Seed;

			[ReadOnly]
			public BufferLookup<DungeonSpawnTableBuffer> DungeonSpawnTableLookup;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> DungeonAreaLookup;

			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> PartialRespawnAreaLookup;

			[ReadOnly]
			public BiomeLookup BiomeLookup;

			[ReadOnly]
			public NativeArray<DungeonBiomeSpawnTableBuffer> DungeonBiomeSpawnTable;

			public NativeList<CustomSceneSpawnCount> AvailableCustomScenes;

			public BlobAssetReference<CustomSceneTableBlob> CustomSceneTableBlob;

			[ReadOnly]
			public StaticallyBlockedAreas StaticallyBlockedAreas;

			public float WorldScale;

			private UnsafeList<int> _reusableIndexList;

			private UnsafeHashSet<int> _customScenesSpawnedInCell;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity areaEntity, ref SpawnDungeonsAndScenesInArea spawnTrigger, ref DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas, in ProceduralSpawnArea spawnArea)
			{
				_customScenesSpawnedInCell = new UnsafeHashSet<int>(32, Allocator.Temp);
				if (!_reusableIndexList.IsCreated)
				{
					_reusableIndexList = new UnsafeList<int>(32, Allocator.Temp);
				}
				foreach (BlockedSpawnAreaBuffer blockedArea in blockedAreas)
				{
					_ = blockedArea;
				}
				PugRandom.HaltonSequenceGenerator2D haltonSequence = new PugRandom.HaltonSequenceGenerator2D(0);
				if (!PartialRespawnAreaLookup.TryGetComponent(areaEntity, out var componentData))
				{
					componentData = new PartialRespawnArea
					{
						LowResShouldRespawnFlags = default(SubMapLayer).Invert()
					};
				}
				for (int i = 0; i < MIN_AREA_RADIUS_PER_SPAWN_PASS.Length; i++)
				{
					SpawnForSize(NUM_SPAWN_TARGET_PER_PASS[i], MIN_AREA_RADIUS_PER_SPAWN_PASS[i], spawnArea.Position, spawnArea.Size, areaEntity, blockedAreas, ref haltonSequence, ref spawnTrigger, ref componentData);
				}
				for (int num = blockedAreas.Length - 1; num >= 0; num--)
				{
					if (blockedAreas[num].Value.ElapsedTicks == 123456)
					{
						blockedAreas.RemoveAtSwapBack(num);
					}
				}
				Ecb.AddComponent<HasSpawnedArea>(areaEntity);
			}

			private void SpawnForSize(int targetSpawnCount, int minRadius, int2 basePosition, int2 size, Entity areaEntity, DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas, ref PugRandom.HaltonSequenceGenerator2D haltonSequence, ref SpawnDungeonsAndScenesInArea spawnTrigger, ref PartialRespawnArea partialRespawnArea)
			{
				for (int i = 0; i < targetSpawnCount; i++)
				{
					FindSampleWithLargestMargin(out var bestDistance, out var bestPoint, basePosition, size, blockedAreas.AsNativeArray().Reinterpret<BlockedSpawnArea>(), ref haltonSequence, ref partialRespawnArea);
					if (bestDistance < (float)minRadius)
					{
						continue;
					}
					int maxRadius = (int)math.floor(bestDistance) - 5;
					Unity.Mathematics.Random rngFromInt = PugRandom.GetRngFromInt2(bestPoint, Seed);
					Biome biome = BiomeLookup.GetBiome(bestPoint);
					int sceneIndex;
					if (TryGetRandomDungeon(out var dungeon, biome, minRadius, maxRadius, rngFromInt.NextFloat(), DungeonBiomeSpawnTable, DungeonSpawnTableLookup, in DungeonAreaLookup))
					{
						SpawnDungeon(dungeon, bestPoint, areaEntity);
						blockedAreas.Add(new BlockedSpawnAreaBuffer
						{
							Value = new BlockedSpawnArea
							{
								Center = bestPoint,
								Radius = dungeon.radius,
								ElapsedTicks = 123456
							}
						});
						spawnTrigger.PendingSpawns++;
					}
					else if (TryGetRandomCustomScene(out sceneIndex, biome, minRadius, maxRadius, rngFromInt.NextFloat(), AvailableCustomScenes, CustomSceneTableBlob, ignoreRemainingCount: true))
					{
						int radius = AvailableCustomScenes[sceneIndex].Radius;
						if (AvailableCustomScenes[sceneIndex].RemainingSpawnCount > 0)
						{
							uint seed = rngFromInt.NextUInt();
							int indexInTable = AvailableCustomScenes[sceneIndex].IndexInTable;
							blockedAreas.Add(new BlockedSpawnAreaBuffer(bestPoint, radius));
							SpawnCustomScene(Ecb, indexInTable, seed, CustomSceneTableBlob, areaEntity, bestPoint);
							spawnTrigger.PendingSpawns++;
							DecrementSceneCount(sceneIndex, AvailableCustomScenes);
							_customScenesSpawnedInCell.Add(sceneIndex);
						}
						else
						{
							blockedAreas.Add(new BlockedSpawnAreaBuffer
							{
								Value = new BlockedSpawnArea
								{
									Center = bestPoint,
									Radius = radius,
									ElapsedTicks = 123456
								}
							});
						}
					}
				}
			}

			private void FindSampleWithLargestMargin(out float bestDistance, out int2 bestPoint, int2 basePosition, int2 size, NativeArray<BlockedSpawnArea> blockedAreas, ref PugRandom.HaltonSequenceGenerator2D haltonSequence, ref PartialRespawnArea partialRespawnArea)
			{
				bool flag = partialRespawnArea.LowResShouldRespawnFlags.IsAnyUnset();
				bestDistance = 0f;
				bestPoint = int2.zero;
				for (int i = 0; i < 100; i++)
				{
					int2 int5 = (haltonSequence.Next() * size).RoundToInt2();
					int2 int6 = basePosition + int5;
					float x = EntityUtility.DistanceToNearestBlocker(blockedAreas, int6);
					x = math.min(x, DistanceToCellEdge(int6, basePosition, size));
					if (BiomeLookup.TryGetDistanceToBiome(int6, Biome.None, out var distance, 256))
					{
						x = math.min(x, distance - 16f);
					}
					x = math.min(x, StaticallyBlockedAreas.GetClosestDistance(int6.ToFloat2() / WorldScale) * WorldScale);
					if (x < bestDistance)
					{
						continue;
					}
					if (flag)
					{
						PartialRespawnArea.GetSampleRange(int5 - (int)math.ceil(x), 2 * (int)math.ceil(x), out var startIndex, out var endIndex);
						for (int j = startIndex.y; j < endIndex.y; j++)
						{
							for (int k = startIndex.x; k < endIndex.x; k++)
							{
								int2 int7 = new int2(k, j);
								if (!partialRespawnArea.LowResShouldRespawnFlags.Get(int7))
								{
									int2 int8 = int7 << 2;
									x = math.min(x, math.length(int8 - int5));
								}
							}
						}
					}
					if (x > bestDistance)
					{
						bestDistance = x;
						bestPoint = int6;
					}
				}
			}

			private static float DistanceToCellEdge(int2 position, int2 basePosition, int2 size)
			{
				return math.min(math.cmin(position - basePosition), math.cmin(basePosition + size - position));
			}

			private static bool TryGetRandomDungeon(out ValidDungeonEntry dungeon, Biome biome, int minRadius, int maxRadius, float spawnValue, NativeArray<DungeonBiomeSpawnTableBuffer> dungeonBiomeTablesBuffer, BufferLookup<DungeonSpawnTableBuffer> dungeonBuffer, in ComponentLookup<DungeonAreaCD> dungeonLookup)
			{
				using (FindDungeonMarker.Auto())
				{
					float num = 0f;
					for (int i = 0; i < dungeonBiomeTablesBuffer.Length; i++)
					{
						DungeonBiomeSpawnTableBuffer dungeonBiomeSpawnTableBuffer = dungeonBiomeTablesBuffer[i];
						Biome fullRelease = dungeonBiomeSpawnTableBuffer.biome.fullRelease;
						if (fullRelease != Biome.None && fullRelease != biome)
						{
							continue;
						}
						DynamicBuffer<DungeonSpawnTableBuffer> dynamicBuffer = dungeonBuffer[dungeonBiomeSpawnTableBuffer.tableEntity];
						for (int j = 0; j < dynamicBuffer.Length; j++)
						{
							DungeonSpawnTableBuffer dungeonSpawnTableBuffer = dynamicBuffer[j];
							int placementRadius = dungeonLookup[dungeonSpawnTableBuffer.prefabEntity].placementRadius;
							if (placementRadius >= minRadius && placementRadius < maxRadius)
							{
								num += dungeonSpawnTableBuffer.spawnChance;
								if (num >= spawnValue)
								{
									dungeon = new ValidDungeonEntry
									{
										tableIndex = i,
										entryIndex = j,
										radius = placementRadius
									};
									return true;
								}
							}
						}
					}
					dungeon = default(ValidDungeonEntry);
					return false;
				}
			}

			private void SpawnDungeon(ValidDungeonEntry dungeon, int2 position, Entity areaEntity)
			{
				DungeonSpawnTableBuffer dungeonSpawnTableBuffer = DungeonSpawnTableLookup[DungeonBiomeSpawnTable[dungeon.tableIndex].tableEntity][dungeon.entryIndex];
				Entity e = Ecb.Instantiate(dungeonSpawnTableBuffer.prefabEntity);
				Ecb.SetComponent(e, LocalTransform.FromPosition(position.ToFloat3()));
				Ecb.SetComponent(e, new SpawnAreaEntityRefCD
				{
					Value = areaEntity
				});
				Ecb.AddComponent(e, new AfterSpawnCleanup
				{
					AreaEntityRef = areaEntity
				});
			}

			private bool TryGetRandomCustomScene(out int sceneIndex, Biome biome, int minRadius, int maxRadius, float spawnValue, NativeList<CustomSceneSpawnCount> availableScenes, BlobAssetReference<CustomSceneTableBlob> customScenesData, bool ignoreRemainingCount)
			{
				using (FindCustomSceneMarker.Auto())
				{
					_reusableIndexList.Clear();
					UnsafeList<int> reusableIndexList = _reusableIndexList;
					for (int i = 0; i < availableScenes.Length; i++)
					{
						int radius = availableScenes[i].Radius;
						if (radius < minRadius || radius >= maxRadius || (!ignoreRemainingCount && availableScenes[i].RemainingSpawnCount <= 0) || _customScenesSpawnedInCell.Contains(i))
						{
							continue;
						}
						ref CustomSceneBlob reference = ref customScenesData.Value.scenes[availableScenes[i].IndexInTable];
						bool flag = false;
						for (int j = 0; j < reference.biomesToSpawnIn.fullRelease.Length; j++)
						{
							if (reference.biomesToSpawnIn.fullRelease[j] == biome)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							reusableIndexList.Add(in i);
						}
					}
					sceneIndex = ((reusableIndexList.Length == 0) ? (-1) : reusableIndexList[(int)math.floor(spawnValue * (float)reusableIndexList.Length)]);
					return sceneIndex != -1;
				}
			}

			private static void SpawnCustomScene(EntityCommandBuffer ecb, int tableIndex, uint seed, BlobAssetReference<CustomSceneTableBlob> customSceneTable, Entity areaEntity, int2 spawnPos)
			{
				ref CustomSceneBlob reference = ref customSceneTable.Value.scenes[tableIndex];
				Entity e = ecb.CreateEntity();
				ecb.AddComponent(e, LocalTransform.FromPosition(spawnPos.ToFloat3()));
				ecb.AddComponent(e, new CustomSceneCD
				{
					name = new FixedString32Bytes(in reference.sceneName)
				});
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent(e2, LocalTransform.FromPosition(spawnPos.ToFloat3()));
				ecb.AddComponent(e2, new SpawnCustomSceneCD
				{
					name = new FixedString32Bytes(in reference.sceneName),
					seed = seed
				});
				ecb.AddComponent(e2, new AfterSpawnCleanup
				{
					AreaEntityRef = areaEntity
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SpawnDungeonsAndScenesInArea_RW_ComponentTypeHandle);
				BufferAccessor<BlockedSpawnAreaBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__BlockedSpawnAreaBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity areaEntity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref SpawnDungeonsAndScenesInArea spawnTrigger = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, i);
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas = bufferAccessor[i];
						Execute(areaEntity, ref spawnTrigger, ref blockedAreas, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, i));
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
							Entity areaEntity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
							ref SpawnDungeonsAndScenesInArea spawnTrigger2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, nextRangeBegin);
							DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas2 = bufferAccessor[nextRangeBegin];
							Execute(areaEntity2, ref spawnTrigger2, ref blockedAreas2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, nextRangeBegin));
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
						Entity areaEntity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
						ref SpawnDungeonsAndScenesInArea spawnTrigger3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, j);
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas3 = bufferAccessor[j];
						Execute(areaEntity3, ref spawnTrigger3, ref blockedAreas3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Entity areaEntity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
						ref SpawnDungeonsAndScenesInArea spawnTrigger4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, k);
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas4 = bufferAccessor[k];
						Execute(areaEntity4, ref spawnTrigger4, ref blockedAreas4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr3, k));
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

		[BurstCompile]
		private struct AfterSpawnCleanupJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AfterSpawnCleanup> __PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanup_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanup_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AfterSpawnCleanup>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanup_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAll<AfterSpawnCleanup>().Build(ref state);
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
				public void Run(ref AfterSpawnCleanupJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref AfterSpawnCleanupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref AfterSpawnCleanupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref AfterSpawnCleanupJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref AfterSpawnCleanupJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref AfterSpawnCleanupJob job, EntityManager entityManager)
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

			public ComponentLookup<SpawnDungeonsAndScenesInArea> SpawnDungeonsAndScenesInAreaLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in AfterSpawnCleanup cleanup)
			{
				Ecb.RemoveComponent<AfterSpawnCleanup>(entity);
				SpawnDungeonsAndScenesInAreaLookup.GetRefRW(cleanup.AreaEntityRef).ValueRW.PendingSpawns--;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanup_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AfterSpawnCleanup>(nativeArrayPtr2, k));
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

		[BurstCompile]
		[WithAll(new Type[] { typeof(HasSpawnedArea) })]
		private struct ForwardToProceduralSpawnJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<SpawnDungeonsAndScenesInArea> __SpawnDungeonsAndScenesInArea_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__SpawnDungeonsAndScenesInArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnDungeonsAndScenesInArea>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__SpawnDungeonsAndScenesInArea_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnDungeonsAndScenesInArea>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<HasSpawnedArea>();
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
				public void Run(ref ForwardToProceduralSpawnJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ForwardToProceduralSpawnJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ForwardToProceduralSpawnJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ForwardToProceduralSpawnJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ForwardToProceduralSpawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ForwardToProceduralSpawnJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in SpawnDungeonsAndScenesInArea spawnTrigger)
			{
				if (spawnTrigger.PendingSpawns <= 0)
				{
					Ecb.RemoveComponent<SpawnDungeonsAndScenesInArea>(entity);
					Ecb.RemoveComponent<HasSpawnedArea>(entity);
					Ecb.AddComponent<SpawnProceduralInAreaCD>(entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SpawnDungeonsAndScenesInArea_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDungeonsAndScenesInArea>(nativeArrayPtr2, k));
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

		private struct ValidDungeonEntry
		{
			public int tableIndex;

			public int entryIndex;

			public float radius;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_62091955_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public CustomSceneCD Get(int index)
				{
					return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<CustomSceneCD>(item1_IntPtr, index);
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<CustomSceneCD> item1_ComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<CustomSceneCD>(isReadOnly: true);
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
					};
				}
			}

			public struct Enumerator : IEnumerator<CustomSceneCD>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public CustomSceneCD Current => _resolvedChunk.Get(_currentEntityIndex);

				object IEnumerator.Current
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					if (!entityQuery.IsEmptyIgnoreFilter)
					{
						CompleteDependencies(ref state);
						typeHandle.Update(ref state);
					}
					_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
					_currentEntityIndex = -1;
					_endEntityIndex = -1;
					_typeHandle = typeHandle;
					_resolvedChunk = default(ResolvedChunk);
				}

				public void Dispose()
				{
					_entityQueryEnumerator.Dispose();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					_currentEntityIndex++;
					if (_currentEntityIndex >= _endEntityIndex)
					{
						if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
						{
							if (movedToNewChunk)
							{
								_resolvedChunk = _typeHandle.Resolve(chunk);
							}
							_currentEntityIndex = entityStartIndex;
							_endEntityIndex = entityEndIndex;
							return true;
						}
						return false;
					}
					return true;
				}

				public Enumerator GetEnumerator()
				{
					return this;
				}

				public void Reset()
				{
					throw new NotImplementedException();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				return new Enumerator(entityQuery, typeHandle, ref state);
			}

			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRO<CustomSceneCD>();
			}
		}

		private struct TypeHandle
		{
			public IFE_62091955_0.TypeHandle __IFE_62091955_0_TypeHandle;

			[ReadOnly]
			public ComponentLookup<BossLarvaCD> __BossLarvaCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<DungeonSpawnTableBuffer> __PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> __PartialRespawnArea_RO_ComponentLookup;

			public SpawnJob.InternalCompilerQueryAndHandleData __PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<SpawnDungeonsAndScenesInArea> __SpawnDungeonsAndScenesInArea_RW_ComponentLookup;

			public AfterSpawnCleanupJob.InternalCompilerQueryAndHandleData __PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public ForwardToProceduralSpawnJob.InternalCompilerQueryAndHandleData __PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_62091955_0_TypeHandle = new IFE_62091955_0.TypeHandle(ref state);
				__BossLarvaCD_RO_ComponentLookup = state.GetComponentLookup<BossLarvaCD>(isReadOnly: true);
				__PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup = state.GetBufferLookup<DungeonSpawnTableBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonAreaCD_RO_ComponentLookup = state.GetComponentLookup<DungeonAreaCD>(isReadOnly: true);
				__PartialRespawnArea_RO_ComponentLookup = state.GetComponentLookup<PartialRespawnArea>(isReadOnly: true);
				__PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__SpawnDungeonsAndScenesInArea_RW_ComponentLookup = state.GetComponentLookup<SpawnDungeonsAndScenesInArea>();
				__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000256_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000256_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000256_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnCreate_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_00000257_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000257_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000257_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnUpdate_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnDestroy_00000258_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_00000258_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00000258_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnDestroy_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnStopRunning_0000025A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_0000025A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000025A_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnStopRunning_0024BurstManaged(self, state);
			}
		}

		private const int HALTON_SAMPLES_PER_SPAWN = 100;

		private const int MIN_SPACE_BETWEEN_PLACEMENTS = 5;

		private static readonly int[] MIN_AREA_RADIUS_PER_SPAWN_PASS = new int[3] { 44, 20, 0 };

		private static readonly int[] NUM_SPAWN_TARGET_PER_PASS = new int[3] { 4, 8, 32 };

		private static readonly Color ColorYellow = Color.yellow;

		private static readonly Color ColorBlue = Color.blue;

		private static readonly Color ColorRed = Color.red;

		private static readonly Color ColorGreen = Color.green;

		private static readonly Color ColorMagenta = Color.magenta;

		private static readonly Color ColorCyan = Color.cyan;

		private static readonly Color ColorGray = Color.gray;

		private BiomeLookup _biomeLookup;

		private TileAccessor _tileAccessor;

		private BlobAssetReference<CustomSceneTableBlob> _customSceneTableBlob;

		private NativeList<CustomSceneSpawnCount> _availableCustomScenes;

		private StaticallyBlockedAreas _staticallyBlockedAreas;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_62091955_0;

		private EntityQuery __query_62091955_1;

		private EntityQuery __query_62091955_2;

		private EntityQuery __query_62091955_3;

		private EntityQuery __query_62091955_4;

		private EntityQuery __query_62091955_5;

		private EntityQuery __query_62091955_6;

		private EntityQuery __query_62091955_7;

		private EntityQuery __query_62091955_8;

		private EntityQuery __query_62091955_9;

		private EntityQuery __query_62091955_10;

		private EntityQuery __query_62091955_11;

		private EntityQuery __query_62091955_12;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BiomeSamplesCD>();
			state.RequireForUpdate<DungeonBiomeSpawnTableBuffer>();
			state.RequireForUpdate<CustomSceneTableCD>();
			state.RequireForUpdate<InitialLoadingDoneCD>();
			state.RequireForUpdate<TileUpdateBuffer>();
			state.RequireForUpdate<ServerSeedCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate(__query_62091955_1);
		}

		public void OnStartRunning(ref SystemState state)
		{
			DynamicBuffer<ActivatedContentBundlesBuffer> singletonBuffer = __query_62091955_4.GetSingletonBuffer<ActivatedContentBundlesBuffer>();
			_customSceneTableBlob = __query_62091955_5.GetSingleton<CustomSceneTableCD>().Value;
			_biomeLookup = new BiomeLookup(__query_62091955_6.GetSingleton<BiomeSamplesCD>());
			if (!_availableCustomScenes.IsCreated)
			{
				_availableCustomScenes = new NativeList<CustomSceneSpawnCount>(512, Allocator.Persistent);
				for (int i = 1; i < _customSceneTableBlob.Value.scenes.Length; i++)
				{
					ref CustomSceneBlob reference = ref _customSceneTableBlob.Value.scenes[i];
					if (reference.maxOccurrences > 0)
					{
						int remainingSpawnCount = reference.maxOccurrences;
						if (reference.replacedByContentBundle.TryGetValue(out var output) && singletonBuffer.Contains(new ActivatedContentBundlesBuffer
						{
							ContentBundle = output
						}))
						{
							remainingSpawnCount = 0;
							UnityEngine.Debug.Log($"Do not spawn custom scene {reference.sceneName} because it is replaced by content bundle {ContentBundleDataBlock.GetBundleName(output)}");
						}
						_availableCustomScenes.Add(new CustomSceneSpawnCount
						{
							IndexInTable = i,
							RemainingSpawnCount = remainingSpawnCount,
							Radius = (int)math.ceil(reference.radius)
						});
					}
				}
				foreach (CustomSceneCD item in IFE_62091955_0.Query(__query_62091955_0, __TypeHandle.__IFE_62091955_0_TypeHandle, ref state))
				{
					for (int num = _availableCustomScenes.Length - 1; num >= 0; num--)
					{
						int indexInTable = _availableCustomScenes[num].IndexInTable;
						FixedString32Bytes name = item.name;
						if (name.Equals(_customSceneTableBlob.Value.scenes[indexInTable].sceneName))
						{
							DecrementSceneCount(num, _availableCustomScenes);
						}
					}
				}
				BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_62091955_7.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
				CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
				ComponentLookup<BossLarvaCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossLarvaCD_RO_ComponentLookup, ref state);
				_staticallyBlockedAreas = StaticallyBlockedAreas.Create(databaseBankBlob, worldGenerationParametersReference, componentLookup, Allocator.Persistent);
			}
			_tileAccessor = new TileAccessor(ref state, isReadOnly: false);
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
			_biomeLookup.Dispose();
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
			if (_availableCustomScenes.IsCreated)
			{
				_availableCustomScenes.Dispose();
			}
			if (_staticallyBlockedAreas.IsCreated)
			{
				_staticallyBlockedAreas.Dispose();
			}
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			if (__query_62091955_8.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease)
			{
				EntityCommandBuffer ecb = __query_62091955_9.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
				_tileAccessor.Update(ref state);
				EntityQuery _query_62091955_ = __query_62091955_2;
				if (!_query_62091955_.IsEmpty)
				{
					SpawnJob job = new SpawnJob
					{
						Ecb = ecb,
						Seed = __query_62091955_10.GetSingleton<ServerSeedCD>().Value,
						DungeonSpawnTableLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup, ref state),
						DungeonAreaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentLookup, ref state),
						PartialRespawnAreaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PartialRespawnArea_RO_ComponentLookup, ref state),
						BiomeLookup = _biomeLookup,
						DungeonBiomeSpawnTable = __query_62091955_11.GetSingletonBuffer<DungeonBiomeSpawnTableBuffer>().AsNativeArray(),
						AvailableCustomScenes = _availableCustomScenes,
						CustomSceneTableBlob = _customSceneTableBlob,
						StaticallyBlockedAreas = _staticallyBlockedAreas,
						WorldScale = __query_62091955_12.GetSingleton<WorldScaleCD>().Value
					};
					state.Dependency = __ScheduleViaJobChunkExtension_0(job, _query_62091955_, state.Dependency, ref state, hasUserDefinedQuery: true);
				}
				AfterSpawnCleanupJob job2 = new AfterSpawnCleanupJob
				{
					Ecb = ecb,
					SpawnDungeonsAndScenesInAreaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnDungeonsAndScenesInArea_RW_ComponentLookup, ref state)
				};
				EntityQuery _query_62091955_2 = __query_62091955_3;
				state.Dependency = __ScheduleViaJobChunkExtension_1(job2, _query_62091955_2, state.Dependency, ref state, hasUserDefinedQuery: true);
				ForwardToProceduralSpawnJob job3 = new ForwardToProceduralSpawnJob
				{
					Ecb = ecb
				};
				state.Dependency = __ScheduleViaJobChunkExtension_2(job3, __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}

		private static void DecrementSceneCount(int sceneNumber, NativeList<CustomSceneSpawnCount> availableScenes)
		{
			if (availableScenes[sceneNumber].RemainingSpawnCount > 0)
			{
				availableScenes.ElementAt(sceneNumber).RemainingSpawnCount--;
			}
		}

		[BurstDiscard]
		[Conditional("DEBUG_SPAWN_SCENES_SYSTEM")]
		private static void DebugDrawWorldGenCircle(int2 center, int radius, Color color)
		{
			PugWorld.AddDebugCircle(new Vector2(center.x, center.y), radius, color);
		}

		[BurstDiscard]
		[Conditional("DEBUG_SPAWN_SCENES_SYSTEM")]
		private static void DebugDrawWorldGenRect(int2 pos, int2 size, Color color)
		{
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y), new Vector2(pos.x, pos.y + size.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y), new Vector2(pos.x + size.x, pos.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x + size.x, pos.y), new Vector2(pos.x + size.x, pos.y + size.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y + size.y), new Vector2(pos.x + size.x, pos.y + size.y), color);
		}

		[BurstDiscard]
		[Conditional("DEBUG_SPAWN_SCENES_SYSTEM")]
		private static void DebugDrawWorldGenRectFromCenter(int2 center, int radius, Color color)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(SpawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(AfterSpawnCleanupJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_AfterSpawnCleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(ForwardToProceduralSpawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_SpawnDungeonAndSceneSystem_ForwardToProceduralSpawnJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneCD>();
			__query_62091955_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnDungeonsAndScenesInArea, ProceduralSpawnArea>();
			__query_62091955_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnDungeonsAndScenesInArea, ProceduralSpawnArea, BlockedSpawnAreaBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<HasSpawnedArea>();
			__query_62091955_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<AfterSpawnCleanup>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<SpawnCustomSceneCD, DungeonAreaCD>();
			__query_62091955_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_9 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_10 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<DungeonBiomeSpawnTableBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_11 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldScaleCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_62091955_12 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			__codegen__OnCreate_00000256_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000257_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_00000258_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_0000025A_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnDungeonAndSceneSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
