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

namespace WorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class SpawnRootsInNewAreasSystem : PugSimulationSystemBase
	{
		internal struct Trigger : IComponentData, IQueryTypeParameter
		{
			public int2 Position;

			public int2 Size;

			public Entity SpawnCellEntity;

			public readonly bool ContainsPoint(int2 point)
			{
				if (point.x >= Position.x && point.x < Position.x + Size.x && point.y >= Position.y)
				{
					return point.y < Position.y + Size.y;
				}
				return false;
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Job : IJobChunk
		{
			public EntityCommandBuffer ecb;

			public Entity updatedTilesSingleton;

			[ReadOnly]
			public BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup;

			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> partialRespawnAreaLookup;

			[ReadOnly]
			public TileAccessor tileAccessor;

			public uint seed;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<Trigger> __areaTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in Trigger area)
			{
				ecb.DestroyEntity(entity);
				using NativeQueue<int2> nativeQueue = new NativeQueue<int2>(Allocator.Temp);
				Unity.Mathematics.Random rngFromEntity = PugRandom.GetRngFromEntity(seed, entity);
				NativeArray<BlockedSpawnArea> blockedSpawnAreas = blockedSpawnAreaBufferLookup[area.SpawnCellEntity].AsNativeArray().Reinterpret<BlockedSpawnArea>();
				PartialRespawnArea componentData;
				bool flag = partialRespawnAreaLookup.TryGetComponent(area.SpawnCellEntity, out componentData);
				int2 int5 = area.Position - GetSpawnCellBasePosition(area.Position);
				NativeParallelHashSet<int2> rootsPlaced = new NativeParallelHashSet<int2>(area.Size.x * area.Size.y * 3, Allocator.Temp);
				for (int i = 0; i < area.Size.y; i++)
				{
					for (int j = 0; j < area.Size.x; j++)
					{
						int2 int6 = new int2(j, i);
						if (flag)
						{
							int2 sampleIndex = PartialRespawnArea.GetSampleIndex(int5 + int6);
							if (!componentData.LowResShouldRespawnFlags.GetByRef(sampleIndex))
							{
								continue;
							}
						}
						int2 int7 = area.Position + int6;
						TileCD top = tileAccessor.GetTop(int7);
						math.lengthsq(int7);
						float num = ((top.tileset == 55) ? 0.0085f : 0.017f);
						if (!(rngFromEntity.NextFloat() < num) || top.tileType != TileType.ground)
						{
							continue;
						}
						Tileset tileset = (Tileset)top.tileset;
						if ((tileset != Tileset.Dirt && tileset != Tileset.Turf && tileset != Tileset.Clay && tileset != Tileset.Nature && tileset != Tileset.Sea && tileset != Tileset.Crystal) || EntityUtility.PointIsBlockedForSpawning(blockedSpawnAreas, int7))
						{
							continue;
						}
						tileset = (Tileset)top.tileset;
						int tileset2 = ((tileset != Tileset.Clay && tileset != Tileset.Turf) ? top.tileset : 0);
						nativeQueue.Clear();
						nativeQueue.Enqueue(int7);
						int num2 = 0;
						int2 item;
						while (nativeQueue.TryDequeue(out item))
						{
							if (CanPlaceRoot(item, rootsPlaced, tileAccessor, canReplaceWalls: true, out var blockingWall) && area.ContainsPoint(item) && !EntityUtility.PointIsBlockedForSpawning(blockedSpawnAreas, item))
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
										tileset = tileset2,
										tileType = TileType.bigRoot
									}
								});
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									nativeQueue.Enqueue(item + left);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									nativeQueue.Enqueue(item + right);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									nativeQueue.Enqueue(item + SpawnRootsInNewAreasSystem.top);
								}
								if (rngFromEntity.NextFloat() < 0.8f)
								{
									nativeQueue.Enqueue(item + bot);
								}
							}
							num2++;
							if (num2 > 20)
							{
								break;
							}
						}
						nativeQueue.Clear();
					}
				}
				rootsPlaced.Dispose();
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Trigger>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Trigger>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Trigger>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Trigger>(nativeArrayPtr2, l));
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
			public ComponentTypeHandle<Trigger> __WorldGen_SpawnRootsInNewAreasSystem_Trigger_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferLookup<BlockedSpawnAreaBuffer> __BlockedSpawnAreaBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<PartialRespawnArea> __PartialRespawnArea_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__WorldGen_SpawnRootsInNewAreasSystem_Trigger_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Trigger>(isReadOnly: true);
				__BlockedSpawnAreaBuffer_RO_BufferLookup = state.GetBufferLookup<BlockedSpawnAreaBuffer>(isReadOnly: true);
				__PartialRespawnArea_RO_ComponentLookup = state.GetComponentLookup<PartialRespawnArea>(isReadOnly: true);
			}
		}

		private const float SPAWN_CHANCE_MODIFIER = 0.85f;

		private const float SPAWN_CHANCE = 0.017f;

		private const float GLEAM_WOOD_SPAWN_CHANCE = 0.0085f;

		private const float SPREAD_CHANCE = 0.8f;

		private EntityQuery query;

		private static readonly int2 left = new int2(-1, 0);

		private static readonly int2 right = new int2(1, 0);

		private static readonly int2 top = new int2(0, 1);

		private static readonly int2 bot = new int2(0, -1);

		private TypeHandle __TypeHandle;

		private EntityQuery __query_288116896_0;

		private EntityQuery __query_288116896_1;

		[Preserve]
		protected override void OnCreate()
		{
			NeedTileUpdateBuffer();
			RequireForUpdate(query);
			RequireForUpdate<WorldGenerationTypeCD>();
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (__query_288116896_1.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease)
			{
				EntityCommandBuffer ecb = CreateCommandBuffer();
				Entity updatedTilesSingleton = tileUpdateBufferSingletonEntity;
				BufferLookup<BlockedSpawnAreaBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__BlockedSpawnAreaBuffer_RO_BufferLookup, ref base.CheckedStateRef);
				ComponentLookup<PartialRespawnArea> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PartialRespawnArea_RO_ComponentLookup, ref base.CheckedStateRef);
				TileAccessor tileAccessor = CreateTileAccessor();
				uint seed = PugRandom.GetSeed();
				SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Execute(ecb, updatedTilesSingleton, bufferLookup, componentLookup, tileAccessor, seed);
				base.OnUpdate();
			}
		}

		private static int2 GetSpawnCellBasePosition(int2 position)
		{
			int num = 128;
			return (position + num >> 8 << 8) - num;
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

		private void SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity updatedTilesSingleton, BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup, ComponentLookup<PartialRespawnArea> partialRespawnAreaLookup, TileAccessor tileAccessor, uint seed)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__WorldGen_SpawnRootsInNewAreasSystem_Trigger_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Job jobData = new SpawnRootsInNewAreasSystem_55285ACF_LambdaJob_0_Job
			{
				ecb = ecb,
				updatedTilesSingleton = updatedTilesSingleton,
				blockedSpawnAreaBufferLookup = blockedSpawnAreaBufferLookup,
				partialRespawnAreaLookup = partialRespawnAreaLookup,
				tileAccessor = tileAccessor,
				seed = seed,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__areaTypeHandle = __TypeHandle.__WorldGen_SpawnRootsInNewAreasSystem_Trigger_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_288116896_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Trigger>();
			query = (__query_288116896_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_288116896_1 = entityQueryBuilder2.Build(ref state);
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
		public SpawnRootsInNewAreasSystem()
		{
		}
	}
}
