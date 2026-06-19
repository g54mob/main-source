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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(StateSystemGroup))]
public class NearbyEntitiesTrackerSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct NearbyEntitiesTrackerSystem_2D4E18D8_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public float deltaTime;

		public uint seed;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<NearbyEntitiesBufferCD> __nearbyEntitiesBufferCDTypeHandle;

		public ComponentTypeHandle<NearbyEntitiesTrackerCD> __netCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBufferCD, [NoAlias] ref NearbyEntitiesTrackerCD netCD, [NoAlias] in LocalTransform transform)
		{
			netCD.cooldownTimer -= deltaTime;
			if (netCD.cooldownTimer > 0f)
			{
				return;
			}
			Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(seed ^ (uint)entityInQueryIndex);
			if (netCD.ignoreCooldown)
			{
				netCD.cooldownTimer = 0f;
			}
			else
			{
				netCD.cooldownTimer = random.NextFloat(0.5f, 1f);
			}
			nearbyEntitiesBufferCD.Clear();
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (collisionWorld.OverlapSphere(transform.Position, netCD.radius, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = netCD.detectsLayer
			}))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					if (__PlayerGhost_ComponentLookup.HasComponent(outHits[i].Entity))
					{
						nearbyEntitiesBufferCD.Add(new NearbyEntitiesBufferCD
						{
							entity = __PlayerGhost_ComponentLookup[outHits[i].Entity].playerGhostExtrapolated
						});
					}
					if (outHits[i].Entity != entity)
					{
						nearbyEntitiesBufferCD.Add(new NearbyEntitiesBufferCD
						{
							entity = outHits[i].Entity
						});
					}
				}
			}
			outHits.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor = chunk.GetBufferAccessor(ref __nearbyEntitiesBufferCDTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __netCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l));
				}
				num2 >>= 1;
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

		public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RW_BufferTypeHandle;

		public ComponentTypeHandle<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__NearbyEntitiesBufferCD_RW_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>();
			__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NearbyEntitiesTrackerCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_555697362_0;

	[Preserve]
	protected override void OnUpdate()
	{
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		uint seed = PugRandom.GetSeed();
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		NearbyEntitiesTrackerSystem_2D4E18D8_LambdaJob_0_Execute(deltaTime, seed, collisionWorld);
		entityCommandBuffer.Playback(base.EntityManager);
		entityCommandBuffer.Dispose();
		base.OnUpdate();
	}

	private void NearbyEntitiesTrackerSystem_2D4E18D8_LambdaJob_0_Execute(float deltaTime, uint seed, CollisionWorld collisionWorld)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesBufferCD_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		NearbyEntitiesTrackerSystem_2D4E18D8_LambdaJob_0_Job jobData = new NearbyEntitiesTrackerSystem_2D4E18D8_LambdaJob_0_Job
		{
			deltaTime = deltaTime,
			seed = seed,
			collisionWorld = collisionWorld,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__nearbyEntitiesBufferCDTypeHandle = __TypeHandle.__NearbyEntitiesBufferCD_RW_BufferTypeHandle,
			__netCDTypeHandle = __TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__PlayerGhost_ComponentLookup = __TypeHandle.__PlayerGhost_RO_ComponentLookup
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_555697362_0.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_555697362_0, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesBufferCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesTrackerCD>();
		__query_555697362_0 = entityQueryBuilder2.Build(ref state);
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
	public NearbyEntitiesTrackerSystem()
	{
	}
}
