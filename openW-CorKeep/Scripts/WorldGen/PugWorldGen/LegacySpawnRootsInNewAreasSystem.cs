using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using PugTilemap;
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
	public class LegacySpawnRootsInNewAreasSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Job : IJobChunk
		{
			public EntityCommandBuffer ecb;

			public Entity updatedTilesSingleton;

			[ReadOnly]
			public NativeArray<BlockedSpawnArea> blockedAreas;

			public WorldGenerationType worldGenerationType;

			[ReadOnly]
			public TileAccessor tileAccessor;

			public uint seed;

			public NativeQueue<int2> frontier;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ProceduralSpawnArea> __spawnedAreaTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in ProceduralSpawnArea spawnedArea)
			{
				ecb.RemoveComponent<LegacySpawnRootsInAreaCD>(entity);
				ecb.AddComponent<LegacySpawnEnvironmentObjectsInAreaCD>(entity);
				if (worldGenerationType == WorldGenerationType.Creative)
				{
					return;
				}
				Unity.Mathematics.Random rngFromEntity = PugRandom.GetRngFromEntity(seed, entity);
				NativeParallelHashSet<int2> rootsPlaced = new NativeParallelHashSet<int2>(spawnedArea.Size.x * spawnedArea.Size.y * 3, Allocator.Temp);
				for (int i = 0; i < spawnedArea.Size.y; i++)
				{
					for (int j = 0; j < spawnedArea.Size.x; j++)
					{
						int2 int5 = spawnedArea.Position + new int2(j, i);
						TileCD top = tileAccessor.GetTop(int5);
						float num = math.lengthsq(int5);
						float num2 = ((top.tileset == 55) ? 0.01f : 0.02f);
						if (!(num > 144f) || !(rngFromEntity.NextFloat() < num2) || top.tileType != TileType.ground || (top.tileset != 0 && top.tileset != 13 && top.tileset != 11 && top.tileset != 8 && top.tileset != 10 && top.tileset != 55) || EntityUtility.PointIsBlockedForSpawning(blockedAreas, int5))
						{
							continue;
						}
						int tileset = ((top.tileset != 11 && top.tileset != 13) ? top.tileset : 0);
						frontier.Clear();
						frontier.Enqueue(int5);
						int num3 = 0;
						int2 item;
						while (frontier.TryDequeue(out item))
						{
							if (CanPlaceRoot(item, rootsPlaced, tileAccessor, canReplaceWalls: true, out var blockingWall) && ProceduralSpawnArea.ContainsPoint(spawnedArea, item) && !EntityUtility.PointIsBlockedForSpawning(blockedAreas, item))
							{
								rootsPlaced.Add(item);
								if (blockingWall.tileType == TileType.wall)
								{
									ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
									{
										command = TileUpdateBuffer.Command.Remove,
										position = item,
										tile = new TileCD
										{
											tileset = blockingWall.tileset,
											tileType = TileType.wall
										}
									});
								}
								ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
								{
									command = TileUpdateBuffer.Command.Add,
									position = item,
									tile = new TileCD
									{
										tileset = tileset,
										tileType = TileType.bigRoot
									}
								});
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									frontier.Enqueue(item + left);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									frontier.Enqueue(item + right);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									frontier.Enqueue(item + LegacySpawnRootsInNewAreasSystem.top);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									frontier.Enqueue(item + bot);
								}
							}
							num3++;
							if (num3 > 20)
							{
								break;
							}
						}
						frontier.Clear();
					}
				}
				rootsPlaced.Dispose();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnedAreaTypeHandle);
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

		private const float SPAWN_CHANCE = 0.02f;

		private const float GLEAM_WOOD_SPAWN_CHANCE = 0.01f;

		private const float SPREAD_CHANCE = 0.8f;

		private EntityQuery query;

		private EntityQuery blockedAreasQ;

		private static readonly int2 left = new int2(-1, 0);

		private static readonly int2 right = new int2(1, 0);

		private static readonly int2 top = new int2(0, 1);

		private static readonly int2 bot = new int2(0, -1);

		private TypeHandle __TypeHandle;

		private EntityQuery __query_160816752_0;

		private EntityQuery __query_160816752_1;

		[Preserve]
		protected override void OnCreate()
		{
			NeedTileUpdateBuffer();
			RequireForUpdate(query);
			RequireForUpdate<WorldGenerationTypeCD>();
			blockedAreasQ = GetEntityQuery(ComponentType.ReadOnly<BlockedSpawnAreaCD>());
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (__query_160816752_1.GetSingleton<WorldGenerationTypeCD>().Value != WorldGenerationType.FullRelease)
			{
				EntityCommandBuffer ecb = CreateCommandBuffer();
				Entity updatedTilesSingleton = tileUpdateBufferSingletonEntity;
				NativeArray<BlockedSpawnArea> blockedAreas = blockedAreasQ.ToComponentDataArray<BlockedSpawnAreaCD>(base.World.UpdateAllocator.ToAllocator).Reinterpret<BlockedSpawnArea>();
				WorldGenerationType value = __query_160816752_1.GetSingleton<WorldGenerationTypeCD>().Value;
				TileAccessor tileAccessor = CreateTileAccessor();
				uint seed = PugRandom.GetSeed();
				NativeQueue<int2> frontier = new NativeQueue<int2>(base.World.UpdateAllocator.ToAllocator);
				LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Execute(ecb, updatedTilesSingleton, blockedAreas, value, tileAccessor, seed, frontier);
				base.OnUpdate();
			}
		}

		private static bool CanPlaceRoot(int2 pos, NativeParallelHashSet<int2> rootsPlaced, TileAccessor tileAccessor, bool canReplaceWalls, out TileCD blockingWall)
		{
			blockingWall = default(TileCD);
			TileCD tileCD = tileAccessor.GetTop(pos);
			bool flag = tileCD.tileType == TileType.wall && tileCD.tileset != 2;
			bool num = canReplaceWalls && flag;
			if (num)
			{
				blockingWall = tileCD;
			}
			if ((!num && !tileCD.tileType.CanGrowOn()) || (tileCD.tileset != 0 && tileCD.tileset != 13 && tileCD.tileset != 8 && tileCD.tileset != 10 && tileCD.tileset != 11 && tileCD.tileset != 55))
			{
				return false;
			}
			int2 int5 = pos + left;
			int2 int6 = pos + right;
			int2 int7 = pos + top;
			int2 int8 = pos + bot;
			int num2 = 4;
			num2 -= ((tileAccessor.GetTop(int5).tileType != TileType.bigRoot && !rootsPlaced.Contains(int5)) ? 1 : 0);
			num2 -= ((tileAccessor.GetTop(int6).tileType != TileType.bigRoot && !rootsPlaced.Contains(int6)) ? 1 : 0);
			num2 -= ((tileAccessor.GetTop(int7).tileType != TileType.bigRoot && !rootsPlaced.Contains(int7)) ? 1 : 0);
			num2 -= ((tileAccessor.GetTop(int8).tileType != TileType.bigRoot && !rootsPlaced.Contains(int8)) ? 1 : 0);
			if (!rootsPlaced.Contains(pos))
			{
				return num2 <= 1;
			}
			return false;
		}

		private void LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity updatedTilesSingleton, NativeArray<BlockedSpawnArea> blockedAreas, WorldGenerationType worldGenerationType, TileAccessor tileAccessor, uint seed, NativeQueue<int2> frontier)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Job jobData = new LegacySpawnRootsInNewAreasSystem_743BA73E_LambdaJob_0_Job
			{
				ecb = ecb,
				updatedTilesSingleton = updatedTilesSingleton,
				blockedAreas = blockedAreas,
				worldGenerationType = worldGenerationType,
				tileAccessor = tileAccessor,
				seed = seed,
				frontier = frontier,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__spawnedAreaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_160816752_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralSpawnArea>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LegacySpawnRootsInAreaCD>();
			query = (__query_160816752_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_160816752_1 = entityQueryBuilder2.Build(ref state);
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
		public LegacySpawnRootsInNewAreasSystem()
		{
		}
	}
}
