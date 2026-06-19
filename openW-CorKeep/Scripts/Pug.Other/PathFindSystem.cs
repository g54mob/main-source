using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct PathFindSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	private struct PathStart
	{
		private const int MAXIMUM_DIR_COUNT = 4;

		public unsafe fixed byte directions[4];

		public byte directionsAdded;

		public unsafe void AddDirectionIfMissing(byte direction)
		{
			if (directionsAdded < 4)
			{
				directions[directionsAdded] = direction;
				directionsAdded++;
			}
		}
	}

	private struct TileDurabilityInfo
	{
		public int Health;

		public int DamageReduction;
	}

	private interface IAStarPolicy
	{
		bool IsBlocked(int2 position);

		int ComputeStepCost(int2 from, int2 to);

		int ComputeHeuristicCost(int2 position, NativeHashSet<int2> targetPositions);
	}

	private struct UniformCostAStarPolicy : IAStarPolicy
	{
		private TileAccessor _tileAccessor;

		private readonly bool _isFlying;

		public UniformCostAStarPolicy(TileAccessor tileAccessor, bool isFlying)
		{
			_tileAccessor = tileAccessor;
			_isFlying = isFlying;
		}

		public bool IsBlocked(int2 position)
		{
			TileType topType = _tileAccessor.GetTopType(position);
			if (!_isFlying)
			{
				return !topType.IsWalkableTile();
			}
			return !topType.IsFlyOverTile();
		}

		public int ComputeStepCost(int2 from, int2 to)
		{
			return math.csum(math.abs(from - to));
		}

		public int ComputeHeuristicCost(int2 position, NativeHashSet<int2> targetPositions)
		{
			int num = int.MaxValue;
			foreach (int2 item in targetPositions)
			{
				num = math.min(num, math.csum(math.abs(position - item)));
			}
			return num;
		}
	}

	private struct AllowButAvoidWallsPolicy : IAStarPolicy
	{
		private const int UNBREAKABLE_WALL_COST = 1000000;

		private const int WALL_BASE_COST = 4;

		private const int COST_PER_HIT = 1;

		private TileAccessor _tileAccessor;

		private bool _isFlying;

		private int _miningDamage;

		private NativeArray<TileDurabilityInfo> _wallDurabilityInfo;

		public AllowButAvoidWallsPolicy(TileAccessor tileAccessor, bool isFlying, int miningDamage, NativeArray<TileDurabilityInfo> wallDurabilityInfo)
		{
			_tileAccessor = tileAccessor;
			_isFlying = isFlying;
			_miningDamage = miningDamage;
			_wallDurabilityInfo = wallDurabilityInfo;
		}

		public bool IsBlocked(int2 position)
		{
			TileType topType = _tileAccessor.GetTopType(position);
			if (topType != TileType.wall && topType != TileType.ore && topType != TileType.ancientCrystal)
			{
				if (!_isFlying)
				{
					return !topType.IsWalkableTile();
				}
				return !topType.IsFlyOverTile();
			}
			return false;
		}

		public int ComputeStepCost(int2 from, int2 to)
		{
			TileCD topDamageableTile = _tileAccessor.GetTopDamageableTile(to);
			if (topDamageableTile.tileType != TileType.wall)
			{
				return 1;
			}
			int tileset = topDamageableTile.tileset;
			if (tileset < 0 || tileset >= 75)
			{
				return 1000000;
			}
			TileDurabilityInfo tileDurabilityInfo = _wallDurabilityInfo[tileset];
			int num = _miningDamage - tileDurabilityInfo.DamageReduction;
			if (num <= 0)
			{
				return 1000000;
			}
			int num2 = (int)math.ceil((float)tileDurabilityInfo.Health / (float)num);
			return 4 + num2;
		}

		public int ComputeHeuristicCost(int2 position, NativeHashSet<int2> targetPositions)
		{
			int num = int.MaxValue;
			foreach (int2 item in targetPositions)
			{
				num = math.min(num, math.csum(math.abs(position - item)));
			}
			return num;
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(PathFindBfsCD) })]
	private struct BfsJob : IJobEntity, IJobChunk
	{
		private struct BfsNode
		{
			public int2 Position;

			public PathStart PathStart;
		}

		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PathFindCD> __PathFindCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<PathFindNodeBuffer> __PathFindNodeBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PathFindCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PathFindCD>();
					__PathFindNodeBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<PathFindNodeBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PathFindCD_RW_ComponentTypeHandle.Update(ref state);
					__PathFindNodeBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PathFindBfsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PathFindCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PathFindNodeBuffer>();
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
			public void Run(ref BfsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BfsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BfsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BfsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BfsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BfsJob job, EntityManager entityManager)
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
		public CollisionWorld CollisionWorld;

		[ReadOnly]
		public TileAccessor TileLookup;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<ActivatedByElectricityStateCD> ActivatedByElectricityStateLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> DoorLookup;

		[ReadOnly]
		public ComponentLookup<GateCD> GateLookup;

		public float DeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref PathFindCD pathFind, ref DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer)
		{
			pathFind.UpdateTimers(DeltaTime);
			if (!pathFind.ShouldRefreshPath() || !LocalTransformLookup.TryGetComponent(pathFind.startEntity, out var componentData))
			{
				return;
			}
			Unity.Mathematics.Random rng = Unity.Mathematics.Random.CreateFromIndex((uint)entity.Index);
			pathFind.MarkRefreshed(ref rng);
			NativeQueue<BfsNode> frontier = new NativeQueue<BfsNode>(Allocator.Temp);
			NativeParallelHashSet<int2> blocked = new NativeParallelHashSet<int2>(16, Allocator.Temp);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = pathFind.belongsToLayer,
				CollidesWith = (uint)(0x20101 | (pathFind.blockedByCreatures ? 16 : 0))
			};
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (CollisionWorld.OverlapSphere(componentData.Position, 10f, ref outHits, filter))
			{
				GetBlockedPositionsFromColliderHits(pathFind, outHits, Database, ref blocked, LocalTransformLookup, ObjectDataLookup, DirectionLookup, ActivatedByElectricityStateLookup, DoorLookup, GateLookup);
			}
			int2 int5 = componentData.Position.RoundToInt2();
			if (IsTileBlocked(int5, ref TileLookup, ref blocked, pathFind.isFlying))
			{
				return;
			}
			using NativeArray<int2> allDirs = GetShuffledCardinalDirections(ref rng, Allocator.Temp);
			using NativeHashSet<int2> targetPositions = GetTargetPositions(pathFind, Database, LocalTransformLookup, ObjectDataLookup, DirectionLookup, Allocator.Temp);
			if (PathFindBfs(int5, targetPositions, allDirs, pathFind.isFlying, pathFind.searchRadius, ref frontier, ref blocked, ref TileLookup, out var result))
			{
				pathFind.pathValidTime = 1f;
				AddStartingNodesToBuffer(pathFindNodeBuffer, in pathFind, int5, allDirs, in result, TileLookup);
			}
			frontier.Dispose();
			blocked.Dispose();
			outHits.Dispose();
		}

		private static bool PathFindBfs(int2 startPosition, NativeHashSet<int2> targetPositions, NativeArray<int2> allDirs, bool isFlying, int2 searchRadius, ref NativeQueue<BfsNode> frontier, ref NativeParallelHashSet<int2> blockedAndVisited, ref TileAccessor tileLookup, out PathStart result)
		{
			if (targetPositions.Contains(startPosition))
			{
				result = default(PathStart);
				return true;
			}
			frontier.Enqueue(new BfsNode
			{
				Position = startPosition
			});
			BfsNode item;
			while (frontier.TryDequeue(out item))
			{
				for (int i = 0; i < allDirs.Length; i++)
				{
					int2 int5 = allDirs[i];
					int2 int6 = item.Position + int5;
					if (!math.any(math.abs(int6 - startPosition) > searchRadius) && !IsTileBlocked(int6, ref tileLookup, ref blockedAndVisited, isFlying))
					{
						BfsNode value = new BfsNode
						{
							Position = int6,
							PathStart = item.PathStart
						};
						value.PathStart.AddDirectionIfMissing((byte)i);
						if (targetPositions.Contains(int6))
						{
							result = value.PathStart;
							return true;
						}
						frontier.Enqueue(value);
						blockedAndVisited.Add(int6);
					}
				}
			}
			result = default(PathStart);
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PathFindCD_RW_ComponentTypeHandle);
			BufferAccessor<PathFindNodeBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PathFindNodeBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref PathFindCD pathFind = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, i);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer = bufferAccessor[i];
					Execute(entity, ref pathFind, ref pathFindNodeBuffer);
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
						ref PathFindCD pathFind2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref pathFind2, ref pathFindNodeBuffer2);
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
					ref PathFindCD pathFind3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, j);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer3 = bufferAccessor[j];
					Execute(entity3, ref pathFind3, ref pathFindNodeBuffer3);
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
					ref PathFindCD pathFind4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, k);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer4 = bufferAccessor[k];
					Execute(entity4, ref pathFind4, ref pathFindNodeBuffer4);
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
	private struct AStarJob : IJobEntity, IJobChunk
	{
		private struct AStarNode
		{
			public int2 Position;

			public int Cost;

			public PathStart PathStart;
		}

		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PathFindCD> __PathFindCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<PathFindNodeBuffer> __PathFindNodeBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PathFindAStarCD> __PathFindAStarCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PathFindCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PathFindCD>();
					__PathFindNodeBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<PathFindNodeBuffer>();
					__PathFindAStarCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PathFindAStarCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PathFindCD_RW_ComponentTypeHandle.Update(ref state);
					__PathFindNodeBuffer_RW_BufferTypeHandle.Update(ref state);
					__PathFindAStarCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PathFindAStarCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PathFindCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PathFindNodeBuffer>();
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
			public void Run(ref AStarJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AStarJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AStarJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AStarJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AStarJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AStarJob job, EntityManager entityManager)
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
		public CollisionWorld CollisionWorld;

		[ReadOnly]
		public TileAccessor TileLookup;

		[ReadOnly]
		public NativeArray<TileDurabilityInfo> WallDurabilityInfo;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<ActivatedByElectricityStateCD> ActivatedByElectricityStateLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> DoorLookup;

		[ReadOnly]
		public ComponentLookup<GateCD> GateLookup;

		public float DeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref PathFindCD pathFind, ref DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer, in PathFindAStarCD aStarParameters)
		{
			pathFind.UpdateTimers(DeltaTime);
			if (!pathFind.ShouldRefreshPath() || !LocalTransformLookup.TryGetComponent(pathFind.startEntity, out var componentData))
			{
				return;
			}
			Unity.Mathematics.Random rng = Unity.Mathematics.Random.CreateFromIndex((uint)entity.Index);
			pathFind.MarkRefreshed(ref rng);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = pathFind.belongsToLayer,
				CollidesWith = (uint)(0x20101 | (pathFind.blockedByCreatures ? 16 : 0))
			};
			NativeParallelHashSet<int2> blocked = new NativeParallelHashSet<int2>(16, Allocator.Temp);
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (CollisionWorld.OverlapSphere(componentData.Position, 10f, ref outHits, filter))
			{
				GetBlockedPositionsFromColliderHits(pathFind, outHits, Database, ref blocked, LocalTransformLookup, ObjectDataLookup, DirectionLookup, ActivatedByElectricityStateLookup, DoorLookup, GateLookup);
			}
			int2 int5 = componentData.Position.RoundToInt2();
			using NativeArray<int2> allDirs = GetShuffledCardinalDirections(ref rng, Allocator.Temp);
			using NativeHashSet<int2> targetPositions = GetTargetPositions(pathFind, Database, LocalTransformLookup, ObjectDataLookup, DirectionLookup, Allocator.Temp);
			using NativeHashMap<int2, int> bestCost = new NativeHashMap<int2, int>(16, Allocator.Temp);
			using NativePriorityQueue<AStarNode> frontier = new NativePriorityQueue<AStarNode>(16, Allocator.Temp);
			bool flag;
			PathStart result;
			switch (aStarParameters.Policy)
			{
			case PathFindAStarCD.PolicyType.UniformCost:
				flag = PathFindAStar(policy: new UniformCostAStarPolicy(TileLookup, pathFind.isFlying), startPosition: int5, targetPositions: targetPositions, allDirs: allDirs, searchRadius: pathFind.searchRadius, bestCost: bestCost, frontier: frontier, blocked: blocked, tileLookup: TileLookup, result: out result);
				break;
			case PathFindAStarCD.PolicyType.AllowButAvoidWalls:
				flag = PathFindAStar(policy: new AllowButAvoidWallsPolicy(TileLookup, pathFind.isFlying, aStarParameters.MiningDamage, WallDurabilityInfo), startPosition: int5, targetPositions: targetPositions, allDirs: allDirs, searchRadius: pathFind.searchRadius, bestCost: bestCost, frontier: frontier, blocked: blocked, tileLookup: TileLookup, result: out result);
				break;
			default:
				UnityEngine.Debug.LogError($"Unknown A* policy {aStarParameters.Policy}");
				flag = false;
				result = default(PathStart);
				break;
			}
			if (flag)
			{
				pathFind.pathValidTime = 1f;
				AddStartingNodesToBuffer(pathFindNodeBuffer, in pathFind, int5, allDirs, in result, TileLookup);
			}
			blocked.Dispose();
			outHits.Dispose();
		}

		private static bool PathFindAStar<Policy>(int2 startPosition, NativeHashSet<int2> targetPositions, NativeArray<int2> allDirs, int2 searchRadius, NativeHashMap<int2, int> bestCost, NativePriorityQueue<AStarNode> frontier, NativeParallelHashSet<int2> blocked, TileAccessor tileLookup, Policy policy, out PathStart result) where Policy : IAStarPolicy
		{
			result = default(PathStart);
			if (targetPositions.Contains(startPosition))
			{
				return true;
			}
			if (IsBlocked(startPosition, ref policy, ref blocked))
			{
				return false;
			}
			frontier.Clear();
			frontier.Enqueue(new AStarNode
			{
				Position = startPosition,
				Cost = 0
			}, 0f);
			bestCost.Clear();
			bestCost.Add(startPosition, 0);
			while (!frontier.IsEmpty)
			{
				float priority;
				AStarNode aStarNode = frontier.Dequeue(out priority);
				if (targetPositions.Contains(aStarNode.Position))
				{
					result = aStarNode.PathStart;
					return true;
				}
				if (!bestCost.TryGetValue(aStarNode.Position, out var item))
				{
					UnityEngine.Debug.LogError("Best cost to position was not recorded.");
					result = default(PathStart);
					return false;
				}
				if (item < aStarNode.Cost)
				{
					continue;
				}
				for (int i = 0; i < allDirs.Length; i++)
				{
					int2 int5 = allDirs[i];
					int2 int6 = aStarNode.Position + int5;
					if (math.any(math.abs(int6 - startPosition) > searchRadius) || IsBlocked(int6, ref policy, ref blocked))
					{
						continue;
					}
					int num = item;
					int2 position = aStarNode.Position;
					int num2 = num + policy.ComputeStepCost(position, int6);
					if (bestCost.TryGetValue(int6, out var item2))
					{
						if (item2 <= num2)
						{
							continue;
						}
						bestCost.Remove(int6);
					}
					AStarNode aStarNode2 = new AStarNode
					{
						Position = int6,
						Cost = num2,
						PathStart = aStarNode.PathStart
					};
					aStarNode2.PathStart.AddDirectionIfMissing((byte)i);
					AStarNode value = aStarNode2;
					NativeHashSet<int2> targetPositions2 = targetPositions;
					frontier.Enqueue(value, num2 + policy.ComputeHeuristicCost(int6, targetPositions2));
					bestCost.Add(int6, num2);
				}
			}
			result = default(PathStart);
			return false;
		}

		private static bool IsBlocked<Policy>(int2 position, ref Policy policy, ref NativeParallelHashSet<int2> blockedCache) where Policy : IAStarPolicy
		{
			if (blockedCache.Contains(position))
			{
				return true;
			}
			bool num = policy.IsBlocked(position);
			if (num)
			{
				blockedCache.Add(position);
			}
			return num;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PathFindCD_RW_ComponentTypeHandle);
			BufferAccessor<PathFindNodeBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PathFindNodeBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PathFindAStarCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref PathFindCD pathFind = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, i);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer = bufferAccessor[i];
					Execute(entity, ref pathFind, ref pathFindNodeBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindAStarCD>(nativeArrayPtr3, i));
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
						ref PathFindCD pathFind2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref pathFind2, ref pathFindNodeBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindAStarCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref PathFindCD pathFind3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, j);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer3 = bufferAccessor[j];
					Execute(entity3, ref pathFind3, ref pathFindNodeBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindAStarCD>(nativeArrayPtr3, j));
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
					ref PathFindCD pathFind4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindCD>(nativeArrayPtr2, k);
					DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer4 = bufferAccessor[k];
					Execute(entity4, ref pathFind4, ref pathFindNodeBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PathFindAStarCD>(nativeArrayPtr3, k));
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
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ActivatedByElectricityStateCD> __ActivatedByElectricityStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GateCD> __GateCD_RO_ComponentLookup;

		public BfsJob.InternalCompilerQueryAndHandleData __PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle;

		public AStarJob.InternalCompilerQueryAndHandleData __PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__ActivatedByElectricityStateCD_RO_ComponentLookup = state.GetComponentLookup<ActivatedByElectricityStateCD>(isReadOnly: true);
			__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
			__GateCD_RO_ComponentLookup = state.GetComponentLookup<GateCD>(isReadOnly: true);
			__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00002916_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00002916_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00002916_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00002917_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002917_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002917_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00002918_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00002918_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00002918_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_00002919_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00002919_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00002919_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_0000291A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000291A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000291A_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private TileAccessor _tileAccessor;

	private NativeArray<TileDurabilityInfo> _wallDurabilityInfo;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1107132078_0;

	private EntityQuery __query_1107132078_1;

	private EntityQuery __query_1107132078_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<TileWithTilesetToObjectDataMapCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		if (_wallDurabilityInfo.IsCreated)
		{
			return;
		}
		_wallDurabilityInfo = new NativeArray<TileDurabilityInfo>(75, Allocator.Persistent);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_1107132078_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		NativeHashMap<TileTypeTileSetTuple, ObjectDataCD> lookup = __query_1107132078_1.GetSingleton<TileWithTilesetToObjectDataMapCD>().lookup;
		for (int i = 0; i < 75; i++)
		{
			_wallDurabilityInfo[i] = new TileDurabilityInfo
			{
				Health = int.MaxValue,
				DamageReduction = int.MaxValue
			};
			if (!lookup.TryGetValue((TileType.wall, (Tileset)i), out var item))
			{
				continue;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(item.objectID, databaseBankBlob, item.variation);
			if (!(primaryPrefabEntity == Entity.Null) && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state, primaryPrefabEntity))
			{
				HealthCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state, primaryPrefabEntity);
				TileDurabilityInfo value = new TileDurabilityInfo
				{
					Health = componentAfterCompletingDependency.maxHealth,
					DamageReduction = 0
				};
				if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state, primaryPrefabEntity))
				{
					value.DamageReduction = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state, primaryPrefabEntity).reduction;
				}
				_wallDurabilityInfo[i] = value;
			}
		}
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		if (_wallDurabilityInfo.IsCreated)
		{
			_wallDurabilityInfo.Dispose();
		}
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		_tileAccessor.Update(ref state);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_1107132078_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		CollisionWorld collisionWorld = __query_1107132078_2.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		BfsJob job = new BfsJob
		{
			CollisionWorld = collisionWorld,
			TileLookup = _tileAccessor,
			Database = databaseBankBlob,
			LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			DirectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			ActivatedByElectricityStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ActivatedByElectricityStateCD_RO_ComponentLookup, ref state),
			DoorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
			GateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GateCD_RO_ComponentLookup, ref state),
			DeltaTime = deltaTime
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		AStarJob job2 = new AStarJob
		{
			CollisionWorld = collisionWorld,
			TileLookup = _tileAccessor,
			WallDurabilityInfo = _wallDurabilityInfo,
			Database = databaseBankBlob,
			LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			DirectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			ActivatedByElectricityStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ActivatedByElectricityStateCD_RO_ComponentLookup, ref state),
			DoorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
			GateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GateCD_RO_ComponentLookup, ref state),
			DeltaTime = deltaTime
		};
		state.Dependency = __ScheduleViaJobChunkExtension_1(job2, __TypeHandle.__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static NativeArray<int2> GetShuffledCardinalDirections(ref Unity.Mathematics.Random rng, Allocator allocator)
	{
		NativeArray<int2> list = new NativeArray<int2>(4, allocator);
		list[0] = new int2(1, 0);
		list[1] = new int2(-1, 0);
		list[2] = new int2(0, 1);
		list[3] = new int2(0, -1);
		PugRandom.ShuffleListKindOfRandomly(ref list, ref rng);
		return list;
	}

	private static void GetBlockedPositionsFromColliderHits(PathFindCD pathFind, NativeList<DistanceHit> collisionHits, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ref NativeParallelHashSet<int2> blocked, ComponentLookup<LocalTransform> localTransformLookup, ComponentLookup<ObjectDataCD> objectDataLookup, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<ActivatedByElectricityStateCD> activatedByElectricityStateLookup, ComponentLookup<DoorCD> doorLookup, ComponentLookup<GateCD> gateLookup)
	{
		foreach (DistanceHit item2 in collisionHits)
		{
			if (item2.Entity == pathFind.startEntity || item2.Entity == pathFind.targetEntity || !objectDataLookup.TryGetComponent(item2.Entity, out var componentData))
			{
				continue;
			}
			if (doorLookup.HasComponent(item2.Entity) || gateLookup.HasComponent(item2.Entity))
			{
				ActivatedByElectricityStateCD componentData2;
				bool flag = activatedByElectricityStateLookup.TryGetComponent(item2.Entity, out componentData2);
				if (flag)
				{
					ActivatedByElectricityStateCD.State internalState = componentData2.internalState;
					if (internalState == ActivatedByElectricityStateCD.State.Activating || internalState == ActivatedByElectricityStateCD.State.Active)
					{
						continue;
					}
				}
				if (!flag)
				{
					int variation = componentData.variation;
					if (variation == 1 || variation == 3)
					{
						continue;
					}
				}
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData.objectID, database, componentData.variation);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (directionLookup.TryGetComponent(item2.Entity, out var componentData3))
			{
				componentData3.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			int2 int6;
			int2 int5 = (int6 = localTransformLookup[item2.Entity].Position.RoundToInt2()) + size;
			for (int i = int6.y + offset.y; i < int5.y + offset.y; i++)
			{
				for (int j = int6.x + offset.x; j < int5.x + offset.x; j++)
				{
					int2 item = new int2(j, i);
					blocked.Add(item);
				}
			}
		}
	}

	private static NativeHashSet<int2> GetTargetPositions(PathFindCD pathFind, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ComponentLookup<LocalTransform> localTransformLookup, ComponentLookup<ObjectDataCD> objectDataLookup, ComponentLookup<DirectionCD> directionLookup, Allocator allocator)
	{
		NativeHashSet<int2> result = new NativeHashSet<int2>(1, allocator);
		if (!localTransformLookup.TryGetComponent(pathFind.targetEntity, out var componentData))
		{
			result.Add(pathFind.targetPosition);
			return result;
		}
		int2 item = componentData.Position.RoundToInt2();
		if (!objectDataLookup.TryGetComponent(pathFind.targetEntity, out var componentData2))
		{
			result.Add(item);
			return result;
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData2.objectID, database, componentData2.variation);
		int2 offset = entityObjectInfo.prefabCornerOffset;
		int2 size = entityObjectInfo.prefabTileSize;
		if (directionLookup.TryGetComponent(pathFind.targetEntity, out var componentData3))
		{
			componentData3.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
		}
		for (int i = item.y + offset.y; i < item.y + offset.y + size.y; i++)
		{
			for (int j = item.x + offset.x; j < item.x + offset.x + size.x; j++)
			{
				result.Add(new int2(j, i));
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static void AddStartingNodesToBuffer(DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer, in PathFindCD pathFind, int2 origin, NativeArray<int2> allDirs, in PathStart result, TileAccessor tileLookup)
	{
		int y = result.directionsAdded + 1;
		int num = math.min(pathFindNodeBuffer.Length, y);
		int2 position = origin;
		pathFindNodeBuffer.ElementAt(0).position = position;
		int i;
		for (i = 1; i < num; i++)
		{
			int num2 = i - 1;
			position += allDirs[result.directions[num2]];
			pathFindNodeBuffer.ElementAt(i).position = position;
		}
		for (; i < pathFindNodeBuffer.Length; i++)
		{
			pathFindNodeBuffer.ElementAt(i).position = position;
		}
		ApplyShortcuts(pathFindNodeBuffer, num, in pathFind, tileLookup);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ApplyShortcuts(DynamicBuffer<PathFindNodeBuffer> pathFindNodeBuffer, int nodesWithUniqueValues, in PathFindCD pathFind, TileAccessor tileLookup)
	{
		int2 int5 = pathFindNodeBuffer[0].position;
		int2 position = pathFindNodeBuffer[1].position;
		for (int i = 2; i < nodesWithUniqueValues; i++)
		{
			int2 int6 = int5;
			int5 = position;
			position = pathFindNodeBuffer[i].position;
			int2 int7 = int5 - int6;
			int2 int8 = position - int5;
			int2 worldPosition = int6 + int8;
			bool flag = math.all(int7 == int2.zero);
			bool flag2 = math.dot(int7, int8) == 1;
			if (!(flag || flag2) && (pathFind.isFlying ? tileLookup.GetTopType(worldPosition).IsFlyOverTile() : tileLookup.GetTopType(worldPosition).IsWalkableTile()))
			{
				int5 = position;
				pathFindNodeBuffer.ElementAt(i - 1).position = int5;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsTileBlocked(int2 position, ref TileAccessor tileAccessor, ref NativeParallelHashSet<int2> blockedPositions, bool isFlying)
	{
		if (blockedPositions.Contains(position))
		{
			return true;
		}
		TileType topType = tileAccessor.GetTopType(position);
		if (!(isFlying ? topType.IsFlyOverTile() : topType.IsWalkableTile()))
		{
			blockedPositions.Add(position);
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsTileBlockedAStar(int2 position, ref TileAccessor tileAccessor, ref NativeParallelHashSet<int2> blockedPositions, bool isFlying)
	{
		if (blockedPositions.Contains(position))
		{
			return true;
		}
		TileType topType = tileAccessor.GetTopType(position);
		if (topType != TileType.wall && !(isFlying ? topType.IsFlyOverTile() : topType.IsWalkableTile()))
		{
			blockedPositions.Add(position);
			return true;
		}
		return false;
	}

	[Conditional("PATH_FIND_DEBUG")]
	private static void DebugDrawBlocked(int2 position)
	{
	}

	[Conditional("PATH_FIND_DEBUG")]
	private static void DebugDrawEnqueued(int2 position)
	{
	}

	[Conditional("PATH_FIND_DEBUG")]
	private static void DebugDrawExplored(int2 position)
	{
	}

	[Conditional("PATH_FIND_DEBUG")]
	private static void DebugDrawPath(DynamicBuffer<PathFindNodeBuffer> path)
	{
		for (int i = 1; i < path.Length; i++)
		{
			UnityEngine.Debug.DrawLine(DebugGetRenderPosition(path[i - 1].position, 0.7f), DebugGetRenderPosition(path[i].position, 0.7f), Color.red, 1f);
		}
	}

	[Conditional("PATH_FIND_DEBUG")]
	private static void DebugDrawPosition(int2 position, float priority, Color color)
	{
		UnityEngine.Debug.DrawLine(DebugGetRenderPosition(position + new float2(-0.5f, -0.5f), priority), DebugGetRenderPosition(position + new float2(0.5f, 0.5f), priority), color, 1f);
		UnityEngine.Debug.DrawLine(DebugGetRenderPosition(position + new float2(-0.5f, 0.5f), priority), DebugGetRenderPosition(position + new float2(0.5f, -0.5f), priority), color, 1f);
	}

	private static Vector3 DebugGetRenderPosition(float2 worldPosition, float priority)
	{
		return EntityMonoBehaviour.ToRenderFromWorld(new Vector3(worldPosition.x, priority, worldPosition.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(BfsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PathFindSystem_BfsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(AStarJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PathFindSystem_AStarJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1107132078_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileWithTilesetToObjectDataMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1107132078_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1107132078_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00002916_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002917_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00002918_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00002919_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000291A_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PathFindSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
