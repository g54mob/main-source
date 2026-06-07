using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	public struct JobRepairPath : IJobChunk
	{
		public struct Scheduler
		{
			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandleRO;

			public ComponentTypeHandle<MovementState> MovementStateTypeHandleRW;

			[ReadOnly]
			public ComponentTypeHandle<AgentCylinderShape> AgentCylinderShapeTypeHandleRO;

			[NativeDisableContainerSafetyRestriction]
			public ComponentTypeHandle<ManagedState> ManagedStateTypeHandleRW;

			[ReadOnly]
			public ComponentTypeHandle<MovementSettings> MovementSettingsTypeHandleRO;

			public ComponentTypeHandle<AutoRepathPolicy> AutoRepathPolicyRW;

			[ReadOnly]
			public ComponentTypeHandle<DestinationPoint> DestinationPointTypeHandleRO;

			[ReadOnly]
			public ComponentTypeHandle<AgentMovementPlane> AgentMovementPlaneTypeHandleRO;

			public ComponentTypeHandle<ReadyToTraverseOffMeshLink> ReadyToTraverseOffMeshLinkTypeHandleRW;

			public GCHandle entityManagerHandle;

			public bool onlyApplyPendingPaths;

			public EntityQueryBuilder GetEntityQuery(Allocator allocator)
			{
				return default(EntityQueryBuilder);
			}

			public Scheduler(ref SystemState systemState)
			{
				LocalTransformTypeHandleRO = default(ComponentTypeHandle<LocalTransform>);
				MovementStateTypeHandleRW = default(ComponentTypeHandle<MovementState>);
				AgentCylinderShapeTypeHandleRO = default(ComponentTypeHandle<AgentCylinderShape>);
				ManagedStateTypeHandleRW = default(ComponentTypeHandle<ManagedState>);
				MovementSettingsTypeHandleRO = default(ComponentTypeHandle<MovementSettings>);
				AutoRepathPolicyRW = default(ComponentTypeHandle<AutoRepathPolicy>);
				DestinationPointTypeHandleRO = default(ComponentTypeHandle<DestinationPoint>);
				AgentMovementPlaneTypeHandleRO = default(ComponentTypeHandle<AgentMovementPlane>);
				ReadyToTraverseOffMeshLinkTypeHandleRW = default(ComponentTypeHandle<ReadyToTraverseOffMeshLink>);
				entityManagerHandle = default(GCHandle);
				onlyApplyPendingPaths = false;
			}

			public void Dispose()
			{
			}

			public void Update(ref SystemState systemState)
			{
			}

			public JobHandle ScheduleParallel(ref SystemState systemState, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}
		}

		public Scheduler scheduler;

		[NativeDisableContainerSafetyRestriction]
		public NativeArray<int> indicesScratch;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> nextCornersScratch;

		public bool onlyApplyPendingPaths;

		private static readonly ProfilerMarker MarkerRepair;

		private static readonly ProfilerMarker MarkerGetNextCorners;

		private static readonly ProfilerMarker MarkerUpdateReachedEndInfo;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}

		public static void Execute(ref LocalTransform transform, ref MovementState state, ref AgentCylinderShape shape, ref AgentMovementPlane movementPlane, ref AutoRepathPolicy autoRepathPolicy, ref DestinationPoint destination, EnabledRefRW<ReadyToTraverseOffMeshLink> readyToTraverseOffMeshLink, ManagedState managedState, in MovementSettings settings, NativeList<float3> nextCornersScratch, ref NativeArray<int> indicesScratch, Allocator allocator, bool onlyApplyPendingPaths)
		{
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}
	}
}
