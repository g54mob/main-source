using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine.Jobs;

namespace Pathfinding.ECS
{
	[BurstCompile]
	internal struct JobSyncEntitiesToTransforms : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<Entity> entities;

		[ReadOnly]
		public ComponentLookup<LocalTransform> entityPositions;

		[ReadOnly]
		public ComponentLookup<MovementState> movementState;

		[ReadOnly]
		public ComponentLookup<SyncPositionWithTransform> syncPositionWithTransform;

		[ReadOnly]
		public ComponentLookup<SyncRotationWithTransform> syncRotationWithTransform;

		[ReadOnly]
		public ComponentLookup<OrientationYAxisForward> orientationYAxisForward;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}
}
