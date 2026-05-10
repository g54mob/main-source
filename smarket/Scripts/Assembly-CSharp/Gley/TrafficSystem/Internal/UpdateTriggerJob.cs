using Unity.Burst;
using Unity.Collections;
using UnityEngine.Jobs;

namespace Gley.TrafficSystem.Internal
{
	[BurstCompile]
	public struct UpdateTriggerJob : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<float> TurnAngle;

		[ReadOnly]
		public NativeArray<bool> ExcludedVehicles;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}
}
