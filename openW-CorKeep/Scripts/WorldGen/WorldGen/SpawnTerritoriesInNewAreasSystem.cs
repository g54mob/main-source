using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugWorldGen;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace WorldGen
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct SpawnTerritoriesInNewAreasSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		private struct PendingTerritorySpawnCount : IComponentData, IQueryTypeParameter
		{
			public int Count;
		}

		private struct AfterSpawnCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
		{
			public Entity SpawnCellEntity;
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

					public BufferTypeHandle<BlockedSpawnAreaBuffer> __BlockedSpawnAreaBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__BlockedSpawnAreaBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<BlockedSpawnAreaBuffer>();
						__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
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

			public EntityCommandBuffer Ecb;

			public uint ServerSeed;

			[ReadOnly]
			public BiomeLookup BiomeLookup;

			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> PartialRespawnAreaLookup;

			public float WorldScale;

			public int SlimeTerritoriesMinCoreDistance;

			public int LarvaTerritoriesMinCoreDistance;

			public int CavelingTerritoriesMinCoreDistance;

			public int PoisonSlimeTerritoriesMinCoreDistance;

			public int CavelingNatureTerritoriesMinCoreDistance;

			public int SlipperySlimeTerritoriesMinCoreDistance;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, ref DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas, in ProceduralSpawnArea spawnArea)
			{
				PugRandom.HaltonSequenceGenerator2D haltonSequenceGenerator2D = default(PugRandom.HaltonSequenceGenerator2D);
				Unity.Mathematics.Random rngFromInt = PugRandom.GetRngFromInt2(spawnArea.Position, ServerSeed);
				int2 int5 = spawnArea.Position + 25 + 4;
				int2 int6 = spawnArea.Size - 58;
				int num = rngFromInt.NextInt(16, 33);
				AfterSpawnCleanup component = new AfterSpawnCleanup
				{
					SpawnCellEntity = entity
				};
				PartialRespawnArea componentData;
				bool flag = PartialRespawnAreaLookup.TryGetComponent(entity, out componentData);
				if (flag)
				{
					int num2 = 0;
					for (int i = 0; i < 64; i++)
					{
						num2 += math.countbits(componentData.LowResShouldRespawnFlags.Row(i));
					}
					float num3 = (float)num2 / 4096f;
					if (num3 < 0.1f)
					{
						Ecb.AddComponent(entity, default(PendingTerritorySpawnCount));
						return;
					}
					num = (int)((float)num * num3);
				}
				int num4 = 0;
				for (int j = 0; j < 256 && num4 < num; j++)
				{
					int2 int7 = (haltonSequenceGenerator2D.Next() * int6).RoundToInt2() + int5;
					int num5 = rngFromInt.NextInt(25, 41);
					if (math.cmin(math.min(int7 - spawnArea.Position, spawnArea.Position + spawnArea.Size - int7)) < num5 + 4)
					{
						continue;
					}
					float num6 = EntityUtility.DistanceToNearestBlocker(blockedAreas.AsNativeArray().Reinterpret<BlockedSpawnArea>(), int7);
					if (num6 < 27f)
					{
						continue;
					}
					if (num6 < (float)(num5 + 2))
					{
						num5 = (int)math.floor(num6 - 2f);
					}
					if (flag)
					{
						bool flag2 = true;
						PartialRespawnArea.GetSampleRange(int7 - spawnArea.Position - num5 / 2, num5, out var startIndex, out var endIndex);
						for (int k = startIndex.y; k < endIndex.y && flag2; k++)
						{
							for (int l = startIndex.x; l < endIndex.x; l++)
							{
								if (!componentData.LowResShouldRespawnFlags.Get(l, k))
								{
									flag2 = false;
									break;
								}
							}
						}
						if (!flag2)
						{
							continue;
						}
					}
					switch (BiomeLookup.GetBiome(int7))
					{
					case Biome.Slime:
						if (!(math.length(int7) / WorldScale - (float)num5 < (float)SlimeTerritoriesMinCoreDistance))
						{
							Entity e7 = Ecb.CreateEntity();
							Ecb.AddComponent(e7, new SlimeTerritoryCD
							{
								position = int7,
								size = num5,
								slimeBlobSpawnChance = 0.05f,
								slimeType = SlimeType.Regular
							});
							Ecb.AddComponent(e7, component);
							blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
							num4++;
						}
						break;
					case Biome.Larva:
						if (rngFromInt.NextFloat() < 0.3f)
						{
							if (!(math.length(int7) / WorldScale - (float)num5 < (float)SlimeTerritoriesMinCoreDistance))
							{
								Entity e5 = Ecb.CreateEntity();
								Ecb.AddComponent(e5, new SlimeTerritoryCD
								{
									position = int7,
									size = num5,
									slimeBlobSpawnChance = 0.05f,
									slimeType = SlimeType.Regular
								});
								Ecb.AddComponent(e5, component);
								blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
								num4++;
							}
						}
						else if (!(math.length(int7) / WorldScale - (float)num5 < (float)LarvaTerritoriesMinCoreDistance))
						{
							Entity e6 = Ecb.CreateEntity();
							Ecb.AddComponent(e6, new LarvaTerritoryCD
							{
								position = int7,
								size = num5
							});
							Ecb.AddComponent(e6, component);
							blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
							num4++;
						}
						break;
					case Biome.Stone:
						if (!(math.length(int7) / WorldScale - (float)num5 < (float)CavelingTerritoriesMinCoreDistance))
						{
							Entity e2 = Ecb.CreateEntity();
							Ecb.AddComponent(e2, new CavelingTerritoryCD
							{
								position = int7,
								size = num5,
								cavelingSpawnChance = 0.03f,
								cavelingShamanSpawnChance = 0.01f,
								cavelingBruteSpawnChance = 0.003f
							});
							Ecb.AddComponent(e2, component);
							blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
							num4++;
						}
						break;
					case Biome.Nature:
						if (rngFromInt.NextFloat() < 0.3f)
						{
							if (!(math.length(int7) / WorldScale - (float)num5 < (float)PoisonSlimeTerritoriesMinCoreDistance))
							{
								Entity e3 = Ecb.CreateEntity();
								Ecb.AddComponent(e3, new SlimeTerritoryCD
								{
									position = int7,
									size = num5,
									slimeBlobSpawnChance = 0.05f,
									slimeType = SlimeType.Poison
								});
								Ecb.AddComponent(e3, component);
								blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
								num4++;
							}
						}
						else if (!(math.length(int7) / WorldScale - (float)num5 < (float)CavelingNatureTerritoriesMinCoreDistance))
						{
							Entity e4 = Ecb.CreateEntity();
							Ecb.AddComponent(e4, new CavelingNatureTerritoryCD
							{
								position = int7,
								size = num5,
								farmerSpawnChance = 0.01f,
								hunterSpawnChance = 0.01f
							});
							Ecb.AddComponent(e4, component);
							blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
							num4++;
						}
						break;
					case Biome.Sea:
						if (!(math.length(int7) / WorldScale - (float)num5 < (float)SlipperySlimeTerritoriesMinCoreDistance))
						{
							Entity e = Ecb.CreateEntity();
							Ecb.AddComponent(e, new SlimeTerritoryCD
							{
								position = int7,
								size = num5,
								slimeBlobSpawnChance = 0.05f,
								slimeType = SlimeType.Slippery
							});
							Ecb.AddComponent(e, component);
							blockedAreas.Add(new BlockedSpawnAreaBuffer(int7, num5));
							num4++;
						}
						break;
					}
				}
				Ecb.AddComponent(entity, new PendingTerritorySpawnCount
				{
					Count = num4
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				BufferAccessor<BlockedSpawnAreaBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__BlockedSpawnAreaBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas = bufferAccessor[i];
						Execute(entity, ref blockedAreas, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, i));
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
							DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas2 = bufferAccessor[nextRangeBegin];
							Execute(entity2, ref blockedAreas2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, nextRangeBegin));
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
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas3 = bufferAccessor[j];
						Execute(entity3, ref blockedAreas3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, j));
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
						DynamicBuffer<BlockedSpawnAreaBuffer> blockedAreas4 = bufferAccessor[k];
						Execute(entity4, ref blockedAreas4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, k));
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
		private struct CleanupJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AfterSpawnCleanup> __WorldGen_SpawnTerritoriesInNewAreasSystem_AfterSpawnCleanup_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__WorldGen_SpawnTerritoriesInNewAreasSystem_AfterSpawnCleanup_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AfterSpawnCleanup>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__WorldGen_SpawnTerritoriesInNewAreasSystem_AfterSpawnCleanup_RO_ComponentTypeHandle.Update(ref state);
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
				public void Run(ref CleanupJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref CleanupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref CleanupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref CleanupJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref CleanupJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref CleanupJob job, EntityManager entityManager)
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

			public ComponentLookup<PendingTerritorySpawnCount> PendingTerritorySpawnCountLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in AfterSpawnCleanup cleanup)
			{
				ref PendingTerritorySpawnCount valueRW = ref PendingTerritorySpawnCountLookup.GetRefRW(cleanup.SpawnCellEntity).ValueRW;
				valueRW.Count--;
				if (valueRW.Count == 0)
				{
					Ecb.DestroyEntity(cleanup.SpawnCellEntity);
				}
				Ecb.RemoveComponent<AfterSpawnCleanup>(entity);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_AfterSpawnCleanup_RO_ComponentTypeHandle);
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
		private struct RemoveCompletedSpawnCellJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PendingTerritorySpawnCount> __WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PendingTerritorySpawnCount>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAll<PendingTerritorySpawnCount>().Build(ref state);
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
				public void Run(ref RemoveCompletedSpawnCellJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RemoveCompletedSpawnCellJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RemoveCompletedSpawnCellJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RemoveCompletedSpawnCellJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RemoveCompletedSpawnCellJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RemoveCompletedSpawnCellJob job, EntityManager entityManager)
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

			public void Execute(Entity entity, in PendingTerritorySpawnCount pendingTerritorySpawnCount)
			{
				if (pendingTerritorySpawnCount.Count == 0)
				{
					Ecb.DestroyEntity(entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PendingTerritorySpawnCount>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PendingTerritorySpawnCount>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PendingTerritorySpawnCount>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PendingTerritorySpawnCount>(nativeArrayPtr2, k));
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

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> __PartialRespawnArea_RO_ComponentLookup;

			public SpawnJob.InternalCompilerQueryAndHandleData __WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<PendingTerritorySpawnCount> __WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RW_ComponentLookup;

			public CleanupJob.InternalCompilerQueryAndHandleData __WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public RemoveCompletedSpawnCellJob.InternalCompilerQueryAndHandleData __WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PartialRespawnArea_RO_ComponentLookup = state.GetComponentLookup<PartialRespawnArea>(isReadOnly: true);
				__WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RW_ComponentLookup = state.GetComponentLookup<PendingTerritorySpawnCount>();
				__WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000018D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000018D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000018D_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000018E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000018E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000018E_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStopRunning_00000190_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_00000190_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000190_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

		private const int MIN_TERRITORY_SIZE = 25;

		private const int MAX_TERRITORY_SIZE = 40;

		private const int MIN_TERRITORIES_PER_CELL = 16;

		private const int MAX_TERRITORIES_PER_CELL = 32;

		private const int MAX_SPAWN_ATTEMPTS_PER_CELL = 256;

		private const int CELL_EDGE_PADDING = 4;

		private const int BLOCKED_AREA_PADDING = 2;

		private static readonly Color CellBorderColor = Color.gray;

		private static readonly Color SpawnedTerritoryColor = Color.blue;

		private int _slimeTerritoriesMinCoreDistance;

		private int _larvaTerritoriesMinCoreDistance;

		private int _cavelingTerritoriesMinCoreDistance;

		private int _poisonSlimeTerritoriesMinCoreDistance;

		private int _cavelingNatureTerritoriesMinCoreDistance;

		private int _slipperySlimeTerritoriesMinCoreDistance;

		private BiomeLookup _biomeLookup;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1094607590_0;

		private EntityQuery __query_1094607590_1;

		private EntityQuery __query_1094607590_2;

		private EntityQuery __query_1094607590_3;

		private EntityQuery __query_1094607590_4;

		private EntityQuery __query_1094607590_5;

		private EntityQuery __query_1094607590_6;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BiomeSamplesCD>();
			state.RequireForUpdate<InitialLoadingDoneCD>();
			state.RequireForUpdate<ServerSeedCD>();
			state.RequireForUpdate<SpawnTerritoriesInAreaCD>();
		}

		public void OnStartRunning(ref SystemState state)
		{
			_slimeTerritoriesMinCoreDistance = 16;
			int num = (int)math.ceil(Manager.saves.GetWorldGenerationParametersReference().ring1Size);
			int num2 = (int)math.ceil(Manager.saves.GetWorldGenerationParametersReference().ring2Size);
			_larvaTerritoriesMinCoreDistance = num;
			_cavelingTerritoriesMinCoreDistance = num;
			_poisonSlimeTerritoriesMinCoreDistance = num2;
			_cavelingNatureTerritoriesMinCoreDistance = num2;
			_slipperySlimeTerritoriesMinCoreDistance = num2;
			_biomeLookup = new BiomeLookup(__query_1094607590_2.GetSingleton<BiomeSamplesCD>());
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
			_biomeLookup.Dispose();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			EntityCommandBuffer ecb = __query_1094607590_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			if (__query_1094607590_4.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease)
			{
				SpawnJob job = new SpawnJob
				{
					Ecb = ecb,
					ServerSeed = __query_1094607590_5.GetSingleton<ServerSeedCD>().Value,
					BiomeLookup = _biomeLookup,
					PartialRespawnAreaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PartialRespawnArea_RO_ComponentLookup, ref state),
					WorldScale = __query_1094607590_6.GetSingleton<WorldScaleCD>().Value,
					SlimeTerritoriesMinCoreDistance = _slimeTerritoriesMinCoreDistance,
					LarvaTerritoriesMinCoreDistance = _larvaTerritoriesMinCoreDistance,
					CavelingTerritoriesMinCoreDistance = _cavelingTerritoriesMinCoreDistance,
					PoisonSlimeTerritoriesMinCoreDistance = _poisonSlimeTerritoriesMinCoreDistance,
					CavelingNatureTerritoriesMinCoreDistance = _cavelingNatureTerritoriesMinCoreDistance,
					SlipperySlimeTerritoriesMinCoreDistance = _slipperySlimeTerritoriesMinCoreDistance
				};
				EntityQuery _query_1094607590_ = __query_1094607590_0;
				state.Dependency = __ScheduleViaJobChunkExtension_0(job, _query_1094607590_, state.Dependency, ref state, hasUserDefinedQuery: true);
				CleanupJob job2 = new CleanupJob
				{
					Ecb = ecb,
					PendingTerritorySpawnCountLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_PendingTerritorySpawnCount_RW_ComponentLookup, ref state)
				};
				EntityQuery _query_1094607590_2 = __query_1094607590_1;
				state.Dependency = __ScheduleViaJobChunkExtension_1(job2, _query_1094607590_2, state.Dependency, ref state, hasUserDefinedQuery: true);
				RemoveCompletedSpawnCellJob job3 = new RemoveCompletedSpawnCellJob
				{
					Ecb = ecb
				};
				state.Dependency = __ScheduleViaJobChunkExtension_2(job3, __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}

		[BurstDiscard]
		[Conditional("DEBUG_SPAWN_TERRITORIES_IN_NEW_AREAS")]
		private static void DebugDrawWorldGenCircle(int2 center, int radius, Color color)
		{
			PugWorld.AddDebugCircle(new Vector2(center.x, center.y), radius, color);
		}

		[BurstDiscard]
		[Conditional("DEBUG_SPAWN_TERRITORIES_IN_NEW_AREAS")]
		private static void DebugDrawWorldGenRect(int2 pos, int2 size, Color color)
		{
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y), new Vector2(pos.x, pos.y + size.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y), new Vector2(pos.x + size.x, pos.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x + size.x, pos.y), new Vector2(pos.x + size.x, pos.y + size.y), color);
			PugWorld.AddDebugLine(new Vector2(pos.x, pos.y + size.y), new Vector2(pos.x + size.x, pos.y + size.y), color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(SpawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_SpawnJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(CleanupJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_CleanupJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(RemoveCompletedSpawnCellJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__WorldGen_SpawnTerritoriesInNewAreasSystem_RemoveCompletedSpawnCellJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea, SpawnTerritoriesInAreaCD, BlockedSpawnAreaBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<PendingTerritorySpawnCount>();
			__query_1094607590_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<AfterSpawnCleanup>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<SlimeTerritoryCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<CavelingTerritoryCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<LarvaTerritoryCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<CavelingNatureTerritoryCD>();
			__query_1094607590_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1094607590_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1094607590_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1094607590_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1094607590_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldScaleCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1094607590_6 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000018D_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000018E_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			((SpawnTerritoriesInNewAreasSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_00000190_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SpawnTerritoriesInNewAreasSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnTerritoriesInNewAreasSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnTerritoriesInNewAreasSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((SpawnTerritoriesInNewAreasSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
