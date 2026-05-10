using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

namespace Gley.TrafficSystem.Internal
{
	[BurstCompile]
	public struct UpdateWheelJob : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<float3> WheelsOrigin;

		[ReadOnly]
		public NativeArray<float3> DownDirection;

		[ReadOnly]
		public NativeArray<float> WheelRotation;

		[ReadOnly]
		public NativeArray<float> TurnAngle;

		[ReadOnly]
		public NativeArray<float> WheelRadius;

		[ReadOnly]
		public NativeArray<float> RayCastDistance;

		[ReadOnly]
		public NativeArray<float> MaxSuspension;

		[ReadOnly]
		public NativeArray<int> VehicleIndex;

		[ReadOnly]
		public NativeArray<bool> CanSteer;

		[ReadOnly]
		public NativeArray<bool> ExcludedWheels;

		[ReadOnly]
		public int NrOfVehicles;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}
}
