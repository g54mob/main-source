using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class LegacySpawnTerritoriesInNewAreasSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Job : IJobChunk
		{
			public EntityCommandBuffer ecb;

			[ReadOnly]
			public NativeArray<BlockedSpawnArea> blockedAreas;

			public uint serverSeedLocal;

			public FixedList512Bytes<BiomeRanges> biomeRangesLocal;

			public WorldGenerationType worldGenerationType;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ProceduralSpawnArea> __areaTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ProceduralSpawnArea area)
			{
				ecb.RemoveComponent<LegacySpawnTerritoriesInAreaCD>(entity);
				ecb.RemoveComponent<BlockSaveCD>(entity);
				if (worldGenerationType == WorldGenerationType.Creative)
				{
					return;
				}
				Unity.Mathematics.Random random = new Unity.Mathematics.Random(math.hash(area.Position) + serverSeedLocal);
				int num = 0;
				bool flag = false;
				bool num2 = BiomeRanges.IsWithinBiome(area.Position, biomeRangesLocal[1]);
				bool flag2 = BiomeRanges.IsWithinBiome(area.Position, biomeRangesLocal[2], -40f);
				bool flag3 = BiomeRanges.IsWithinBiome(area.Position, biomeRangesLocal[3], -40f);
				bool flag4 = BiomeRanges.IsWithinBiome(area.Position, biomeRangesLocal[5], -40f);
				bool flag5 = BiomeRanges.IsWithinBiome(area.Position, biomeRangesLocal[7], -40f);
				if (num2 || ((flag2 || flag4 || flag5) && random.NextFloat() < 0.3f))
				{
					num = random.NextInt(1, 3);
					for (int i = 0; i < num; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							int2 int5 = new int2(random.NextInt(10 + area.Position.x, area.Position.x + area.Size.x - 10), random.NextInt(area.Position.y + 10, area.Position.y + area.Size.y - 10));
							if (!EntityUtility.PointIsBlockedForSpawning(blockedAreas, int5))
							{
								Entity e = ecb.CreateEntity();
								ecb.AddComponent(e, new SlimeTerritoryCD
								{
									position = int5,
									size = random.NextInt(25, 40),
									slimeBlobSpawnChance = 0.05f,
									slimeType = (flag4 ? SlimeType.Poison : (flag5 ? SlimeType.Slippery : SlimeType.Regular))
								});
								flag = true;
								break;
							}
						}
					}
				}
				if (flag2 && !flag)
				{
					num = random.NextInt(1, 3);
					for (int k = 0; k < num; k++)
					{
						for (int l = 0; l < 3; l++)
						{
							int2 int6 = new int2(random.NextInt(10 + area.Position.x, area.Position.x + area.Size.x - 10), random.NextInt(area.Position.y + 10, area.Position.y + area.Size.y - 10));
							if (!EntityUtility.PointIsBlockedForSpawning(blockedAreas, int6))
							{
								Entity e2 = ecb.CreateEntity();
								ecb.AddComponent(e2, new LarvaTerritoryCD
								{
									position = int6,
									size = random.NextInt(25, 40)
								});
								flag = true;
								break;
							}
						}
					}
				}
				if (flag3 && !flag)
				{
					num = random.NextInt(1, 3);
					for (int m = 0; m < num; m++)
					{
						for (int n = 0; n < 3; n++)
						{
							int2 int7 = new int2(random.NextInt(10 + area.Position.x, area.Position.x + area.Size.x - 10), random.NextInt(area.Position.y + 10, area.Position.y + area.Size.y - 10));
							if (!EntityUtility.PointIsBlockedForSpawning(blockedAreas, int7) && math.length(int7) > 150f)
							{
								Entity e3 = ecb.CreateEntity();
								ecb.AddComponent(e3, new CavelingTerritoryCD
								{
									position = int7,
									size = random.NextInt(25, 40),
									cavelingSpawnChance = 0.03f,
									cavelingShamanSpawnChance = 0.01f,
									cavelingBruteSpawnChance = 0.003f
								});
								flag = true;
								break;
							}
						}
					}
				}
				if (!flag4 || flag)
				{
					return;
				}
				num = random.NextInt(1, 3);
				for (int num3 = 0; num3 < num; num3++)
				{
					for (int num4 = 0; num4 < 3; num4++)
					{
						int2 int8 = new int2(random.NextInt(10 + area.Position.x, area.Position.x + area.Size.x - 10), random.NextInt(area.Position.y + 10, area.Position.y + area.Size.y - 10));
						if (!EntityUtility.PointIsBlockedForSpawning(blockedAreas, int8) && math.length(int8) > 150f)
						{
							Entity e4 = ecb.CreateEntity();
							ecb.AddComponent(e4, new CavelingNatureTerritoryCD
							{
								position = int8,
								size = random.NextInt(25, 40),
								farmerSpawnChance = 0.01f,
								hunterSpawnChance = 0.01f
							});
							flag = true;
							break;
						}
					}
				}
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, l));
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
			public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
			}
		}

		private const int TERRITORY_MIN_SIZE = 25;

		private const int TERRITORY_MAX_SIZE = 40;

		private const int TERRITORY_EDGE_PADDING = 10;

		private const int MIN_TERRITORIES_AMOUNT_PER_AREA = 1;

		private const int MAX_TERRITORIES_AMOUNT_PER_AREA = 2;

		private const int SPAWN_ATTEMPTS = 3;

		private EntityQuery blockedAreasQ;

		private EntityQuery spawnTerritoriesQ;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2023030951_0;

		private EntityQuery __query_2023030951_1;

		private EntityQuery __query_2023030951_2;

		[Preserve]
		protected override void OnCreate()
		{
			RequireForUpdate<BiomeRangesCD>();
			RequireForUpdate<WorldGenerationTypeCD>();
			NeedServerSeed();
			RequireForUpdate<ServerSeedCD>();
			RequireForUpdate(spawnTerritoriesQ);
			blockedAreasQ = GetEntityQuery(ComponentType.ReadOnly<BlockedSpawnAreaCD>());
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer ecb = CreateCommandBuffer();
			NativeArray<BlockedSpawnArea> blockedAreas = blockedAreasQ.ToComponentDataArray<BlockedSpawnAreaCD>(base.World.UpdateAllocator.ToAllocator).Reinterpret<BlockedSpawnArea>();
			uint serverSeedLocal = serverSeed;
			FixedList512Bytes<BiomeRanges> value = __query_2023030951_1.GetSingleton<BiomeRangesCD>().Value;
			WorldGenerationType value2 = __query_2023030951_2.GetSingleton<WorldGenerationTypeCD>().Value;
			LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Execute(ecb, blockedAreas, serverSeedLocal, value, value2);
			base.OnUpdate();
		}

		private void LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Execute(EntityCommandBuffer ecb, NativeArray<BlockedSpawnArea> blockedAreas, uint serverSeedLocal, FixedList512Bytes<BiomeRanges> biomeRangesLocal, WorldGenerationType worldGenerationType)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Job jobData = new LegacySpawnTerritoriesInNewAreasSystem_8B8BCA3_LambdaJob_0_Job
			{
				ecb = ecb,
				blockedAreas = blockedAreas,
				serverSeedLocal = serverSeedLocal,
				biomeRangesLocal = biomeRangesLocal,
				worldGenerationType = worldGenerationType,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__areaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_2023030951_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LegacySpawnTerritoriesInAreaCD>();
			spawnTerritoriesQ = (__query_2023030951_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2023030951_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2023030951_2 = entityQueryBuilder2.Build(ref state);
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
		public LegacySpawnTerritoriesInNewAreasSystem()
		{
		}
	}
}
