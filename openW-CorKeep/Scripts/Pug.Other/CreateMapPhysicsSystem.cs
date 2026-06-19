using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

[UpdateBefore(typeof(DisablePhysicsSystem))]
[UpdateInGroup(typeof(BeforePhysicsSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[BurstCompile]
public struct CreateMapPhysicsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	private struct FourWayDirectionData
	{
		public const int Length = 4;

		private unsafe fixed int dirXY[8];

		private unsafe fixed int mask[4];

		public unsafe int2 GetDir(int index)
		{
			fixed (int* ptr = dirXY)
			{
				return ((int2*)ptr)[index];
			}
		}

		public unsafe void SetDir(int index, int2 dir)
		{
			fixed (int* ptr = dirXY)
			{
				((int2*)ptr)[index] = dir;
			}
		}

		public unsafe int GetMask(int index)
		{
			return mask[index];
		}

		public unsafe void SetMask(int index, int val)
		{
			mask[index] = val;
		}
	}

	private static class ColliderCacheConstants
	{
		public const int ClientStartSize = 128;

		public const int ClientExpandLimit = 16;

		public const int ClintColliderExpandAmount = 32;

		public const int ClientContractLimit = 64;

		public const int ClientContractResize = 32;

		public const int ServerStartSize = 2048;

		public const int ServerExpandLimit = 256;

		public const int ServerColliderExpandAmount = 512;

		public const int ServerContractLimit = 1024;

		public const int ServerContractResize = 512;
	}

	[BurstCompile]
	private struct BalanceColliderCacheJob : IJob
	{
		public NativeList<Entity> FreeColliders;

		public Entity ColliderPrefab;

		public EntityCommandBuffer ECB;

		public int ExpandLimit;

		public int ExpandAmount;

		public int ContractLimit;

		public int ContractResize;

		public void Execute()
		{
			if (FreeColliders.Length < ExpandLimit)
			{
				for (int i = 0; i < ExpandAmount; i++)
				{
					ECB.Instantiate(ColliderPrefab);
				}
			}
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(TileColliderCD) })]
	private struct AdjustWallColliderJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<TileCD> __TileCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__TileCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TileCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__TileCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<TileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileColliderCD>();
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
			public void Run(ref AdjustWallColliderJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AdjustWallColliderJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AdjustWallColliderJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AdjustWallColliderJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AdjustWallColliderJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AdjustWallColliderJob job, EntityManager entityManager)
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

		[ReadOnly]
		public TileAccessor TileAccessor;

		public FourWayDirectionData FourWayDirectionData;

		public double ElapsedTime;

		public NativeParallelHashMap<int2, Entity> PositionsWithColliders;

		public ComponentLookup<PhysicsCollider> PhysicsColliderLookup;

		public ComponentLookup<TileColliderCD> TileColliderLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, in TileCD tileCD, in LocalTransform transform)
		{
			TileColliderCD tileColliderCD = TileColliderLookup[entity];
			int2 int5 = transform.Position.RoundToInt2();
			TileAccessor.TryGetBlockingTile(int5, out var tile);
			bool flag = tile.tileType != TileType.water && TileAccessor.HasAdjacentWater(int5);
			if (tile.tileType == tileCD.tileType && flag == tileColliderCD.isShoreLine && (double)tileColliderCD.despawnTimestamp >= ElapsedTime)
			{
				if (!PositionsWithColliders.ContainsKey(int5))
				{
					PositionsWithColliders.Add(int5, entity);
				}
				return;
			}
			PhysicsColliderLookup[entity] = new PhysicsCollider
			{
				Value = BlobAssetReference<Collider>.Null
			};
			TileColliderLookup.SetComponentEnabled(entity, value: false);
			PositionsWithColliders.Remove(int5);
			for (int i = 0; i < 4; i++)
			{
				int2 dir = FourWayDirectionData.GetDir(i);
				int2 key = int5 + dir;
				if (PositionsWithColliders.TryGetValue(key, out var item) && TileColliderLookup.HasComponent(item))
				{
					TileColliderLookup.GetRefRW(item).ValueRW.needsRefreshfromAdjacentTileChange = true;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__TileCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct CreateMapCollidersJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<WallColliderCreatorCD> __WallColliderCreatorCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__WallColliderCreatorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WallColliderCreatorCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__WallColliderCreatorCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallColliderCreatorCD>();
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
			public void Run(ref CreateMapCollidersJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CreateMapCollidersJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CreateMapCollidersJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CreateMapCollidersJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CreateMapCollidersJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CreateMapCollidersJob job, EntityManager entityManager)
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

		[ReadOnly]
		public TileAccessor TileAccessor;

		public FourWayDirectionData FourWayDirectionData;

		[ReadOnly]
		public NativeParallelHashMap<int2, Entity> PositionsWithColliders;

		public NativeParallelHashSet<int2> PendingColliderCreations;

		public Entity ColliderPrefab;

		public BlobAssetReference<Collider> PhysicsCollider;

		public BlobAssetReference<Collider> PhysicsColliderLow;

		public BlobAssetReference<Collider> PhysicsColliderWater;

		public BlobAssetReference<Collider> PhysicsColliderShoreline;

		public BlobAssetReference<Collider> PhysicsColliderWithShoreline;

		public BlobAssetReference<Collider> PhysicsColliderLowWithShoreline;

		public EntityCommandBuffer ECB;

		public float DeltaTime;

		public float FixedDeltaTime;

		public double ElapsedTime;

		public NativeParallelHashMap<int, BlobAssetReference<Collider>> MediumAdaptivePhysicsColliders;

		public NativeParallelHashMap<int, BlobAssetReference<Collider>> SmallAdaptivePhysicsColliders;

		public NativeParallelHashMap<int, BlobAssetReference<Collider>> MediumAdaptivePhysicsCollidersWithShoreline;

		public NativeParallelHashMap<int, BlobAssetReference<Collider>> SmallAdaptivePhysicsCollidersWithShoreline;

		public NativeList<Entity> FreeColliders;

		public ComponentLookup<TileColliderCD> TileColliderLookup;

		public ComponentLookup<PhysicsCollider> PhysicsColliderLookup;

		public ComponentLookup<LocalTransform> LocalTransformLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> PhysicsVelocityLookup;

		public ComponentLookup<TileCD> TileCDLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> PlayerGhostLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref WallColliderCreatorCD wallColliderCreator)
		{
			LocalTransform localTransform = LocalTransformLookup[entity];
			PhysicsVelocity physicsVelocity = PhysicsVelocityLookup[entity];
			int2 int5 = (int2)math.round(localTransform.Position.xz);
			int2 int6 = (int2)math.round(localTransform.Position.xz + physicsVelocity.Linear.xz * FixedDeltaTime);
			uint num = math.hash(new int4(int5, int6));
			if (wallColliderCreator.refreshTime > ElapsedTime && num == wallColliderCreator.lastHash && !PlayerGhostLookup.HasComponent(entity))
			{
				return;
			}
			wallColliderCreator.refreshTime = ElapsedTime + 1.0 - (double)(2f * DeltaTime);
			wallColliderCreator.lastHash = num;
			int num2 = ((!PlayerGhostLookup.HasComponent(entity)) ? 1 : 3);
			int2 int7 = math.min(int5, int6) - num2;
			int2 int8 = math.max(int5, int6) + num2;
			for (int i = int7.x; i <= int8.x; i++)
			{
				for (int j = int7.y; j <= int8.y; j++)
				{
					int2 int9 = new int2(i, j);
					TileCD tile;
					bool num3 = TileAccessor.TryGetBlockingTile(int9, out tile);
					bool flag = num3 && tile.tileType == TileType.water;
					bool flag2 = !flag && TileAccessor.HasAdjacentWater(int9);
					if ((!num3 && !flag2) || PendingColliderCreations.Contains(int9))
					{
						continue;
					}
					if (PositionsWithColliders.TryGetValue(int9, out var item) && TileColliderLookup.HasComponent(item))
					{
						TileColliderLookup.GetRefRW(item).ValueRW.despawnTimestamp = (float)ElapsedTime + 1f;
						if (!TileColliderLookup.GetRefRO(item).ValueRO.needsRefreshfromAdjacentTileChange)
						{
							continue;
						}
					}
					bool flag3 = tile.tileType != TileType.none;
					bool flag4 = tile.tileType.HasThinCollider();
					bool flag5 = tile.tileType.HasMediumCollider();
					bool flag6 = tile.tileType.IsLowCollider();
					BlobAssetReference<Collider> value;
					if (flag4 || flag5)
					{
						int num4 = 0;
						int num5 = 0;
						for (int k = 0; k < 4; k++)
						{
							TileCD top = TileAccessor.GetTop(int9 + FourWayDirectionData.GetDir(k));
							if (top.tileType.IsBlockingTile() && top.tileType == tile.tileType && (tile.tileType.BlockingAdaptsToAllTilesets() || top.tileset == tile.tileset))
							{
								num4 |= FourWayDirectionData.GetMask(k);
								num5++;
							}
						}
						if (tile.tileType.ShouldUseFenceLikeAdaption() && num5 < 2)
						{
							int num6 = 0;
							int num7 = 0;
							bool flag7 = false;
							int dir = num4 & 0x55;
							for (int l = 0; l < 4; l++)
							{
								int mask = FourWayDirectionData.GetMask(l);
								TileCD top2 = TileAccessor.GetTop(int9 + FourWayDirectionData.GetDir(l));
								if (!tile.tileType.ShouldUseFenceLikeAdaptionTowardsTileType(top2.tileType))
								{
									continue;
								}
								num6++;
								num7 = mask;
								if (num5 == 1)
								{
									if (AdjacentDir.IsOppositeDirections(mask, dir))
									{
										num4 |= mask;
										flag7 = true;
										break;
									}
								}
								else
								{
									num4 |= mask;
								}
							}
							if (num5 == 1 && num6 == 1 && !flag7)
							{
								num4 |= num7;
							}
						}
						value = GetColliderForAdjacentMask(num4, ref !flag2 ? ref flag4 ? ref SmallAdaptivePhysicsColliders : ref MediumAdaptivePhysicsColliders : ref flag4 ? ref SmallAdaptivePhysicsCollidersWithShoreline : ref MediumAdaptivePhysicsCollidersWithShoreline, flag6);
					}
					else
					{
						value = ((!flag2) ? (flag ? PhysicsColliderWater : (flag6 ? PhysicsColliderLow : PhysicsCollider)) : ((!flag3) ? PhysicsColliderShoreline : (flag6 ? PhysicsColliderLowWithShoreline : PhysicsColliderWithShoreline)));
					}
					TileColliderCD tileColliderCD = new TileColliderCD
					{
						despawnTimestamp = (float)ElapsedTime + 1f,
						isShoreLine = flag2
					};
					PhysicsCollider physicsCollider = new PhysicsCollider
					{
						Value = value
					};
					LocalTransform localTransform2 = LocalTransform.FromPosition(new float3(i, 0f, j));
					TileCD tileCD = new TileCD
					{
						tileset = tile.tileset,
						tileType = tile.tileType
					};
					int num8;
					if (TileColliderLookup.HasComponent(item))
					{
						num8 = (TileColliderLookup.GetRefRW(item).ValueRW.needsRefreshfromAdjacentTileChange ? 1 : 0);
						if (num8 != 0)
						{
							PhysicsColliderLookup[item] = physicsCollider;
							TileColliderLookup.GetRefRW(item).ValueRW.needsRefreshfromAdjacentTileChange = false;
							goto IL_05b7;
						}
					}
					else
					{
						num8 = 0;
					}
					if (FreeColliders.Length > 0)
					{
						int index = FreeColliders.Length - 1;
						Entity entity2 = FreeColliders[index];
						FreeColliders.RemoveAt(index);
						TileColliderLookup.SetComponentEnabled(entity2, value: true);
						TileColliderLookup[entity2] = tileColliderCD;
						PhysicsColliderLookup[entity2] = physicsCollider;
						LocalTransformLookup[entity2] = localTransform2;
						TileCDLookup[entity2] = tileCD;
					}
					else
					{
						Entity e = ECB.Instantiate(ColliderPrefab);
						ECB.SetComponentEnabled<TileColliderCD>(e, value: true);
						ECB.SetComponent(e, tileColliderCD);
						ECB.SetComponent(e, physicsCollider);
						ECB.SetComponent(e, localTransform2);
						ECB.SetComponent(e, tileCD);
						PendingColliderCreations.Add(int9);
					}
					goto IL_05b7;
					IL_05b7:
					if (num8 != 0)
					{
						continue;
					}
					for (int m = 0; m < 4; m++)
					{
						int2 dir2 = FourWayDirectionData.GetDir(m);
						int2 key = int9 + dir2;
						if (PositionsWithColliders.TryGetValue(key, out var item2) && TileColliderLookup.HasComponent(item2))
						{
							TileColliderLookup.GetRefRW(item2).ValueRW.needsRefreshfromAdjacentTileChange = true;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__WallColliderCreatorCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WallColliderCreatorCD>(nativeArrayPtr2, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WallColliderCreatorCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WallColliderCreatorCD>(nativeArrayPtr2, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WallColliderCreatorCD>(nativeArrayPtr2, k));
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
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_RW_ComponentLookup;

		public ComponentLookup<TileColliderCD> __TileColliderCD_RW_ComponentLookup;

		public AdjustWallColliderJob.InternalCompilerQueryAndHandleData __CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RO_ComponentLookup;

		public ComponentLookup<TileCD> __TileCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		public CreateMapCollidersJob.InternalCompilerQueryAndHandleData __CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Physics_PhysicsCollider_RW_ComponentLookup = state.GetComponentLookup<PhysicsCollider>();
			__TileColliderCD_RW_ComponentLookup = state.GetComponentLookup<TileColliderCD>();
			__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__Unity_Physics_PhysicsVelocity_RO_ComponentLookup = state.GetComponentLookup<PhysicsVelocity>(isReadOnly: true);
			__TileCD_RW_ComponentLookup = state.GetComponentLookup<TileCD>();
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000015A9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000015A9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000015A9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000015AA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000015AA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000015AA_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_000015AB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000015AB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000015AB_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_000015AC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000015AC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000015AC_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const float colliderLifetime = 1f;

	private const int distFromPlayerToCreate = 3;

	private Entity colliderPrefab;

	private BlobAssetReference<Collider> physicsCollider;

	private BlobAssetReference<Collider> physicsColliderLow;

	private BlobAssetReference<Collider> physicsColliderWater;

	private BlobAssetReference<Collider> physicsColliderShoreline;

	private BlobAssetReference<Collider> physicsColliderWithShoreline;

	private BlobAssetReference<Collider> physicsColliderLowWithShoreline;

	private NativeParallelHashMap<int, BlobAssetReference<Collider>> smallAdaptivePhysicsColliders;

	private NativeParallelHashMap<int, BlobAssetReference<Collider>> mediumAdaptivePhysicsColliders;

	private NativeParallelHashMap<int, BlobAssetReference<Collider>> smallAdaptivePhysicsCollidersWithShoreline;

	private NativeParallelHashMap<int, BlobAssetReference<Collider>> mediumAdaptivePhysicsCollidersWithShoreline;

	private NativeParallelHashMap<int2, Entity> positionsWithColliders;

	private TileAccessor _tileAccessor;

	private FourWayDirectionData _fourWayDirectionData;

	private EntityQuery _createMapClientQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1741593573_0;

	private EntityQuery __query_1741593573_1;

	private EntityQuery __query_1741593573_2;

	private EntityQuery __query_1741593573_3;

	private EntityQuery __query_1741593573_4;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		if (state.WorldUnmanaged.IsServer())
		{
			state.RequireForUpdate<InitialLoadingDoneCD>();
		}
		EntityArchetype archetype = state.EntityManager.CreateArchetype(typeof(PhysicsCollider), typeof(PhysicsWorldIndex), typeof(LocalTransform), typeof(TileCD), typeof(TileColliderCD));
		colliderPrefab = state.EntityManager.CreateEntity(archetype);
		state.EntityManager.AddComponentData(colliderPrefab, default(Prefab));
		state.EntityManager.SetComponentData(colliderPrefab, LocalTransform.Identity);
		state.EntityManager.SetComponentEnabled<TileColliderCD>(colliderPrefab, value: false);
		positionsWithColliders = new NativeParallelHashMap<int2, Entity>(4096, Allocator.Persistent);
		_createMapClientQuery = __query_1741593573_0;
		_createMapClientQuery.ResetFilter();
		_createMapClientQuery.AddChangedVersionFilter(ComponentType.ReadOnly<LocalTransform>());
		_createMapClientQuery.AddChangedVersionFilter(ComponentType.ReadOnly<PhysicsVelocity>());
		_createMapClientQuery.AddOrderVersionFilter();
		for (int i = 0; i < 4; i++)
		{
			_fourWayDirectionData.SetDir(i, AdjacentDir.GetInt2(AdjacentDir.fourWay[i]));
			_fourWayDirectionData.SetMask(i, AdjacentDir.fourWay[i]);
		}
		SetupColliders();
		CreateColliderEntityCache(ref state, state.WorldUnmanaged.IsServer() ? 2048 : 128);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		positionsWithColliders.Dispose();
		DisposeColliderMap(ref smallAdaptivePhysicsColliders);
		DisposeColliderMap(ref mediumAdaptivePhysicsColliders);
		DisposeColliderMap(ref smallAdaptivePhysicsCollidersWithShoreline);
		DisposeColliderMap(ref mediumAdaptivePhysicsCollidersWithShoreline);
		physicsCollider.Dispose();
		physicsColliderWithShoreline.Dispose();
		physicsColliderLow.Dispose();
		physicsColliderLowWithShoreline.Dispose();
		physicsColliderWater.Dispose();
		physicsColliderShoreline.Dispose();
	}

	private void SetupColliders()
	{
		CollisionFilter collisionFilter = new CollisionFilter
		{
			BelongsTo = 1u,
			CollidesWith = 32788u
		};
		CollisionFilter collisionFilter2 = new CollisionFilter
		{
			BelongsTo = 256u,
			CollidesWith = 32788u
		};
		CollisionFilter collisionFilter3 = new CollisionFilter
		{
			BelongsTo = 131072u,
			CollidesWith = 32788u
		};
		physicsCollider = CreateDefaultCollider(collisionFilter, isShoreLine: false);
		physicsColliderWithShoreline = CreateDefaultCollider(collisionFilter, isShoreLine: true);
		physicsColliderLow = CreateDefaultCollider(collisionFilter2, isShoreLine: false);
		physicsColliderLowWithShoreline = CreateDefaultCollider(collisionFilter2, isShoreLine: true);
		physicsColliderWater = CreateDefaultCollider(collisionFilter3, isShoreLine: false);
		physicsColliderShoreline = CreateDefaultShorelineCollider();
		smallAdaptivePhysicsColliders = GetThinAdaptiveColliders(isShoreLine: false);
		mediumAdaptivePhysicsColliders = GetMediumThickAdaptiveColliders(isShoreLine: false);
		smallAdaptivePhysicsCollidersWithShoreline = GetThinAdaptiveColliders(isShoreLine: true);
		mediumAdaptivePhysicsCollidersWithShoreline = GetMediumThickAdaptiveColliders(isShoreLine: true);
	}

	private static BlobAssetReference<Collider> CreateDefaultShorelineCollider()
	{
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = 262144u,
			CollidesWith = 32788u
		};
		return BoxCollider.Create(new BoxGeometry
		{
			Center = new float3(0f, 0f, 0f),
			Orientation = quaternion.identity,
			Size = new float3(1f, 2f, 1f),
			BevelRadius = 0f
		}, filter);
	}

	private static BlobAssetReference<Collider> CreateDefaultCollider(CollisionFilter collisionFilter, bool isShoreLine)
	{
		BlobAssetReference<Collider> blobAssetReference = BoxCollider.Create(new BoxGeometry
		{
			Center = new float3(0f, 0f, 0f),
			Orientation = quaternion.identity,
			Size = new float3(1f, 2f, 1f),
			BevelRadius = 0f
		}, collisionFilter);
		if (isShoreLine)
		{
			BlobAssetReference<Collider> collider = CreateDefaultShorelineCollider();
			NativeArray<CompoundCollider.ColliderBlobInstance> children = new NativeArray<CompoundCollider.ColliderBlobInstance>(2, Allocator.Temp);
			children[0] = new CompoundCollider.ColliderBlobInstance
			{
				Entity = Entity.Null,
				Collider = blobAssetReference,
				CompoundFromChild = new RigidTransform(quaternion.identity, new float3(0f, 0f, 0f))
			};
			children[1] = new CompoundCollider.ColliderBlobInstance
			{
				Entity = Entity.Null,
				Collider = collider,
				CompoundFromChild = new RigidTransform(quaternion.identity, new float3(0f, 0f, 0f))
			};
			BlobAssetReference<Collider> result = CompoundCollider.Create(children);
			blobAssetReference.Dispose();
			collider.Dispose();
			return result;
		}
		return blobAssetReference;
	}

	private void CreateColliderEntityCache(ref SystemState state, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			state.EntityManager.Instantiate(colliderPrefab);
		}
	}

	private void DisposeColliderMap(ref NativeParallelHashMap<int, BlobAssetReference<Collider>> colliderMap)
	{
		foreach (KeyValue<int, BlobAssetReference<Collider>> item in colliderMap)
		{
			item.Value.Dispose();
		}
		colliderMap.Dispose();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer eCB = __query_1741593573_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		_tileAccessor.Update(ref state);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new AdjustWallColliderJob
		{
			TileAccessor = _tileAccessor,
			FourWayDirectionData = _fourWayDirectionData,
			ElapsedTime = elapsedTime,
			PositionsWithColliders = positionsWithColliders,
			PhysicsColliderLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RW_ComponentLookup, ref state),
			TileColliderLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileColliderCD_RW_ComponentLookup, ref state)
		}, __TypeHandle.__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		JobHandle outJobHandle;
		NativeList<Entity> freeColliders = __query_1741593573_1.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		state.Dependency = JobHandle.CombineDependencies(state.Dependency, outJobHandle);
		ClientServerTickRate singleton = __query_1741593573_3.GetSingleton<ClientServerTickRate>();
		NativeParallelHashSet<int2> pendingColliderCreations = new NativeParallelHashSet<int2>(256, state.WorldUpdateAllocator);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new CreateMapCollidersJob
		{
			TileAccessor = _tileAccessor,
			ECB = eCB,
			DeltaTime = deltaTime,
			FixedDeltaTime = 1f / (float)singleton.SimulationTickRate,
			ElapsedTime = elapsedTime,
			FourWayDirectionData = _fourWayDirectionData,
			PhysicsColliderLow = physicsColliderLow,
			PhysicsCollider = physicsCollider,
			PhysicsColliderWater = physicsColliderWater,
			PhysicsColliderShoreline = physicsColliderShoreline,
			PhysicsColliderLowWithShoreline = physicsColliderLowWithShoreline,
			PhysicsColliderWithShoreline = physicsColliderWithShoreline,
			PositionsWithColliders = positionsWithColliders,
			PendingColliderCreations = pendingColliderCreations,
			MediumAdaptivePhysicsColliders = mediumAdaptivePhysicsColliders,
			SmallAdaptivePhysicsColliders = smallAdaptivePhysicsColliders,
			MediumAdaptivePhysicsCollidersWithShoreline = mediumAdaptivePhysicsCollidersWithShoreline,
			SmallAdaptivePhysicsCollidersWithShoreline = smallAdaptivePhysicsCollidersWithShoreline,
			ColliderPrefab = colliderPrefab,
			FreeColliders = freeColliders,
			TileColliderLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileColliderCD_RW_ComponentLookup, ref state),
			PhysicsColliderLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RW_ComponentLookup, ref state),
			LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
			PhysicsVelocityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RO_ComponentLookup, ref state),
			TileCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RW_ComponentLookup, ref state),
			PlayerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state)
		}, _createMapClientQuery, state.Dependency, ref state, hasUserDefinedQuery: true);
		__query_1741593573_4.TryGetSingleton<NetworkTime>(out var value);
		if (value.IsFinalPredictionTick)
		{
			bool flag = state.WorldUnmanaged.IsServer();
			state.Dependency = IJobExtensions.Schedule(new BalanceColliderCacheJob
			{
				ECB = eCB,
				ColliderPrefab = colliderPrefab,
				FreeColliders = freeColliders,
				ExpandLimit = (flag ? 256 : 16),
				ExpandAmount = (flag ? 512 : 32),
				ContractLimit = (flag ? 1024 : 64),
				ContractResize = (flag ? 512 : 32)
			}, state.Dependency);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static BlobAssetReference<Collider> GetColliderForAdjacentMask(int adjacentMask, ref NativeParallelHashMap<int, BlobAssetReference<Collider>> colliders, bool lowCollider)
	{
		int num = adjacentMask + 1;
		return colliders[lowCollider ? (-num) : num];
	}

	private static NativeParallelHashMap<int, BlobAssetReference<Collider>> GetMediumThickAdaptiveColliders(bool isShoreLine)
	{
		return GetAdaptiveColliders(0.625f, useThicknessForDepthOnStandaloneTiles: false, isShoreLine);
	}

	private static NativeParallelHashMap<int, BlobAssetReference<Collider>> GetThinAdaptiveColliders(bool isShoreLine)
	{
		return GetAdaptiveColliders(0.2f, useThicknessForDepthOnStandaloneTiles: true, isShoreLine);
	}

	private static NativeParallelHashMap<int, BlobAssetReference<Collider>> GetAdaptiveColliders(float thickness, bool useThicknessForDepthOnStandaloneTiles, bool isShoreLine)
	{
		NativeParallelHashMap<int, BlobAssetReference<Collider>> result = new NativeParallelHashMap<int, BlobAssetReference<Collider>>(16, Allocator.Persistent);
		int[] allFourWayCombinations = AdjacentDir.allFourWayCombinations;
		result.Add(1, CreateAdaptiveCollider(0.5f, 0, lowCollider: false, isShoreLine));
		result.Add(-1, CreateAdaptiveCollider(useThicknessForDepthOnStandaloneTiles ? new float2(0.5f, thickness) : ((float2)0.5f), 0, lowCollider: true, isShoreLine));
		for (int i = 0; i < allFourWayCombinations.Length; i++)
		{
			result.Add(allFourWayCombinations[i] + 1, CreateAdaptiveCollider(thickness, allFourWayCombinations[i], lowCollider: false, isShoreLine));
			result.Add(-1 * (allFourWayCombinations[i] + 1), CreateAdaptiveCollider(thickness, allFourWayCombinations[i], lowCollider: true, isShoreLine));
		}
		return result;
	}

	private static BlobAssetReference<Collider> CreateAdaptiveCollider(float2 size, int adjacentDirMask, bool lowCollider, bool isShoreLine)
	{
		float3 size2 = new float3(size.x, 2f, size.y);
		float3 center = new float3(0f, 0f, 0f);
		float2 float5 = (new float2(1f, 1f) - size) / 2f;
		float2 float6 = float5 / 2f;
		if (size.x != 1f && size.y != 1f)
		{
			if (1 == (adjacentDirMask & 1))
			{
				size2 += new float3(float5.x, 0f, 0f);
				center += new float3(float6.x, 0f, 0f);
			}
			if (16 == (adjacentDirMask & 0x10))
			{
				size2 += new float3(float5.x, 0f, 0f);
				center += new float3(0f - float6.x, 0f, 0f);
			}
			if (64 == (adjacentDirMask & 0x40))
			{
				size2 += new float3(0f, 0f, float5.y);
				center += new float3(0f, 0f, float6.y);
			}
			if (4 == (adjacentDirMask & 4))
			{
				size2 += new float3(0f, 0f, float5.y);
				center += new float3(0f, 0f, 0f - float6.y);
			}
		}
		BlobAssetReference<Collider> blobAssetReference = BoxCollider.Create(new BoxGeometry
		{
			Center = center,
			Orientation = quaternion.identity,
			Size = size2,
			BevelRadius = 0f
		}, new CollisionFilter
		{
			BelongsTo = ((!lowCollider) ? 1u : 256u),
			CollidesWith = 32788u,
			GroupIndex = 0
		});
		if (isShoreLine)
		{
			BlobAssetReference<Collider> collider = CreateDefaultShorelineCollider();
			NativeArray<CompoundCollider.ColliderBlobInstance> children = new NativeArray<CompoundCollider.ColliderBlobInstance>(2, Allocator.Temp);
			children[0] = new CompoundCollider.ColliderBlobInstance
			{
				Entity = Entity.Null,
				Collider = blobAssetReference,
				CompoundFromChild = new RigidTransform(quaternion.identity, new float3(0f, 0f, 0f))
			};
			children[1] = new CompoundCollider.ColliderBlobInstance
			{
				Entity = Entity.Null,
				Collider = collider,
				CompoundFromChild = new RigidTransform(quaternion.identity, new float3(0f, 0f, 0f))
			};
			BlobAssetReference<Collider> result = CompoundCollider.Create(children);
			blobAssetReference.Dispose();
			collider.Dispose();
			return result;
		}
		return blobAssetReference;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(AdjustWallColliderJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CreateMapPhysicsSystem_AdjustWallColliderJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(CreateMapCollidersJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CreateMapPhysicsSystem_CreateMapCollidersJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataCD, PhysicsVelocity, WallColliderCreatorCD, LocalTransform, Simulate>();
		__query_1741593573_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithDisabled<TileColliderCD>();
		__query_1741593573_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1741593573_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1741593573_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1741593573_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000015A9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000015AA_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000015AB_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000015AC_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CreateMapPhysicsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
