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
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class DetectRoomSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct DetectRoomSystem_1A14A832_LambdaJob_0_Job : IJobChunk
	{
		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public NativeQueue<int2> frontier;

		public NativeParallelHashSet<int2> visited;

		public NativeList<DistanceHit> colliderHits;

		public NativeParallelHashSet<Entity> detectedEntities;

		public NativeParallelHashSet<int2> wallEntities;

		public NativeParallelHashSet<int2> positionsBlockedByEntities;

		public float deltaTime;

		[ReadOnly]
		public TileAccessor tileLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public ComponentTypeHandle<DetectRoomCD> __detectRoomTypeHandle;

		public BufferTypeHandle<RoomObjectBuffer> __roomObjectBufferTypeHandle;

		public BufferTypeHandle<RoomEmptyPositions> __emptyPositionsTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> __DoorCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref DetectRoomCD detectRoom, DynamicBuffer<RoomObjectBuffer> roomObjectBuffer, DynamicBuffer<RoomEmptyPositions> emptyPositions, [NoAlias] in LocalTransform transform)
		{
			detectRoom.updateTimer -= deltaTime;
			if (detectRoom.updateTimer > 0f)
			{
				return;
			}
			detectRoom.updateTimer = Unity.Mathematics.Random.CreateFromIndex(math.hash(transform.Position)).NextFloat(2f, 5f);
			int2 int5 = transform.Position.RoundToInt2();
			frontier.Clear();
			visited.Clear();
			frontier.Enqueue(int5);
			detectRoom.roomSize = 0;
			detectRoom.minPosition = int.MaxValue;
			detectRoom.maxPosition = int.MinValue;
			roomObjectBuffer.Clear();
			emptyPositions.Clear();
			wallEntities.Clear();
			positionsBlockedByEntities.Clear();
			colliderHits.Clear();
			int num = 16;
			int num2 = num * num;
			if (collisionWorld.OverlapSphere(int5.ToFloat3(), num + 1, ref colliderHits, CollisionFilter.Default))
			{
				for (int i = 0; i < colliderHits.Length; i++)
				{
					if (!__ObjectDataCD_ComponentLookup.HasComponent(colliderHits[i].Entity))
					{
						continue;
					}
					int2 int6 = __Unity_Transforms_LocalTransform_ComponentLookup[colliderHits[i].Entity].Position.RoundToInt2();
					ObjectID objectID = __ObjectDataCD_ComponentLookup[colliderHits[i].Entity].objectID;
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, databaseLocal);
					int2 size = entityObjectInfo.prefabTileSize;
					int2 offset = entityObjectInfo.prefabCornerOffset;
					if (__DirectionCD_ComponentLookup.HasComponent(colliderHits[i].Entity))
					{
						__DirectionCD_ComponentLookup[colliderHits[i].Entity].GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
					}
					int6 += offset;
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseLocal);
					if (__DoorCD_ComponentLookup.HasComponent(primaryPrefabEntity))
					{
						for (int j = int6.y; j < int6.y + size.y; j++)
						{
							for (int k = int6.x; k < int6.x + size.x; k++)
							{
								wallEntities.Add(new int2(k, j));
							}
						}
					}
					for (int l = int6.y; l < int6.y + size.y; l++)
					{
						for (int m = int6.x; m < int6.x + size.x; m++)
						{
							positionsBlockedByEntities.Add(new int2(m, l));
						}
					}
				}
			}
			int2 item;
			while (detectRoom.roomSize <= 64 && frontier.TryDequeue(out item))
			{
				if (visited.Contains(item))
				{
					continue;
				}
				visited.Add(item);
				if (!tileLookup.HasType(item, TileType.wall) && !tileLookup.HasType(item, TileType.thinWall) && !wallEntities.Contains(item))
				{
					TileType topType = tileLookup.GetTopType(item);
					if (!positionsBlockedByEntities.Contains(item) && topType.IsWalkableTile() && math.distancesq(item, int5) <= (float)num2)
					{
						emptyPositions.Add(new RoomEmptyPositions
						{
							Value = item
						});
					}
					detectRoom.minPosition = math.min(detectRoom.minPosition, item);
					detectRoom.maxPosition = math.max(detectRoom.maxPosition, item);
					detectRoom.roomSize++;
					int2 int7 = item + new int2(-1, 0);
					int2 int8 = item + new int2(1, 0);
					int2 int9 = item + new int2(0, -1);
					int2 int10 = item + new int2(0, 1);
					if (!visited.Contains(int7))
					{
						frontier.Enqueue(int7);
					}
					if (!visited.Contains(int8))
					{
						frontier.Enqueue(int8);
					}
					if (!visited.Contains(int9))
					{
						frontier.Enqueue(int9);
					}
					if (!visited.Contains(int10))
					{
						frontier.Enqueue(int10);
					}
				}
			}
			frontier.Clear();
			if (detectRoom.roomSize > 64)
			{
				detectRoom.roomDetected = false;
				return;
			}
			detectRoom.roomDetected = true;
			detectedEntities.Clear();
			for (int n = 0; n < colliderHits.Length; n++)
			{
				if (!detectedEntities.Contains(colliderHits[n].Entity))
				{
					detectedEntities.Add(colliderHits[n].Entity);
					int2 item2 = __Unity_Transforms_LocalTransform_ComponentLookup[colliderHits[n].Entity].Position.RoundToInt2();
					if (visited.Contains(item2) && __ObjectDataCD_ComponentLookup.HasComponent(colliderHits[n].Entity))
					{
						RoomObjectBuffer elem = new RoomObjectBuffer
						{
							Value = __ObjectDataCD_ComponentLookup[colliderHits[n].Entity]
						};
						roomObjectBuffer.Add(elem);
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __detectRoomTypeHandle);
			BufferAccessor<RoomObjectBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roomObjectBufferTypeHandle);
			BufferAccessor<RoomEmptyPositions> bufferAccessor2 = chunk.GetBufferAccessor(ref __emptyPositionsTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectRoomCD>(nativeArrayPtr, i), bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectRoomCD>(nativeArrayPtr, j), bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectRoomCD>(nativeArrayPtr, k), bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectRoomCD>(nativeArrayPtr, l), bufferAccessor[l], bufferAccessor2[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l));
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
		public ComponentTypeHandle<DetectRoomCD> __DetectRoomCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<RoomObjectBuffer> __RoomObjectBuffer_RW_BufferTypeHandle;

		public BufferTypeHandle<RoomEmptyPositions> __RoomEmptyPositions_RW_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DetectRoomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DetectRoomCD>();
			__RoomObjectBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RoomObjectBuffer>();
			__RoomEmptyPositions_RW_BufferTypeHandle = state.GetBufferTypeHandle<RoomEmptyPositions>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
		}
	}

	private const int maxRoomSize = 8;

	private const int maxRoomSizeSq = 64;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_850443948_0;

	private EntityQuery __query_850443948_1;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NetworkTime singleton = __query_850443948_1.GetSingleton<NetworkTime>();
		if (!VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 4, 3f, out var ticksPerUpdate))
		{
			base.OnUpdate();
			return;
		}
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		NativeQueue<int2> frontier = new NativeQueue<int2>(base.World.UpdateAllocator.ToAllocator);
		NativeParallelHashSet<int2> visited = new NativeParallelHashSet<int2>(128, base.World.UpdateAllocator.ToAllocator);
		NativeList<DistanceHit> colliderHits = new NativeList<DistanceHit>(base.World.UpdateAllocator.ToAllocator);
		NativeParallelHashSet<Entity> detectedEntities = new NativeParallelHashSet<Entity>(128, base.World.UpdateAllocator.ToAllocator);
		NativeParallelHashSet<int2> wallEntities = new NativeParallelHashSet<int2>(128, base.World.UpdateAllocator.ToAllocator);
		NativeParallelHashSet<int2> positionsBlockedByEntities = new NativeParallelHashSet<int2>(128, base.World.UpdateAllocator.ToAllocator);
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime * (float)ticksPerUpdate;
		TileAccessor tileLookup = CreateTileAccessor();
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		DetectRoomSystem_1A14A832_LambdaJob_0_Execute(databaseLocal, frontier, visited, colliderHits, detectedEntities, wallEntities, positionsBlockedByEntities, deltaTime, tileLookup, collisionWorld);
		base.OnUpdate();
	}

	private void DetectRoomSystem_1A14A832_LambdaJob_0_Execute(BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, NativeQueue<int2> frontier, NativeParallelHashSet<int2> visited, NativeList<DistanceHit> colliderHits, NativeParallelHashSet<Entity> detectedEntities, NativeParallelHashSet<int2> wallEntities, NativeParallelHashSet<int2> positionsBlockedByEntities, float deltaTime, TileAccessor tileLookup, CollisionWorld collisionWorld)
	{
		__TypeHandle.__DetectRoomCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RoomObjectBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RoomEmptyPositions_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DirectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DoorCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		DetectRoomSystem_1A14A832_LambdaJob_0_Job jobData = new DetectRoomSystem_1A14A832_LambdaJob_0_Job
		{
			databaseLocal = databaseLocal,
			frontier = frontier,
			visited = visited,
			colliderHits = colliderHits,
			detectedEntities = detectedEntities,
			wallEntities = wallEntities,
			positionsBlockedByEntities = positionsBlockedByEntities,
			deltaTime = deltaTime,
			tileLookup = tileLookup,
			collisionWorld = collisionWorld,
			__detectRoomTypeHandle = __TypeHandle.__DetectRoomCD_RW_ComponentTypeHandle,
			__roomObjectBufferTypeHandle = __TypeHandle.__RoomObjectBuffer_RW_BufferTypeHandle,
			__emptyPositionsTypeHandle = __TypeHandle.__RoomEmptyPositions_RW_BufferTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__DirectionCD_ComponentLookup = __TypeHandle.__DirectionCD_RO_ComponentLookup,
			__DoorCD_ComponentLookup = __TypeHandle.__DoorCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_850443948_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DetectRoomCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoomObjectBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoomEmptyPositions>();
		_queryRequiredForUpdate = (__query_850443948_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_850443948_1 = entityQueryBuilder2.Build(ref state);
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
	public DetectRoomSystem()
	{
	}
}
