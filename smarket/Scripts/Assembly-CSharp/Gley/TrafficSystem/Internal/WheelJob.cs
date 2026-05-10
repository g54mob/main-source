using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Gley.TrafficSystem.Internal
{
	[BurstCompile]
	public struct WheelJob : IJobParallelFor
	{
		public NativeArray<float3> WheelSuspensionForce;

		public NativeArray<float3> WheelSideForce;

		[ReadOnly]
		public NativeArray<float3> WheelNormalDirection;

		[ReadOnly]
		public NativeArray<float3> WheelRightDirection;

		[ReadOnly]
		public NativeArray<float3> WheelVelocity;

		[ReadOnly]
		public NativeArray<float> SpringForces;

		[ReadOnly]
		public NativeArray<float> WheelRayCastDistance;

		[ReadOnly]
		public NativeArray<float> WheelRadius;

		[ReadOnly]
		public NativeArray<float> WheelMaxSuspension;

		[ReadOnly]
		public NativeArray<float> SpringStiffness;

		[ReadOnly]
		public NativeArray<int> StartWheelIndex;

		[ReadOnly]
		public NativeArray<int> NrOfVehicleWheels;

		[ReadOnly]
		public NativeArray<int> WheelAssociatedVehicle;

		[ReadOnly]
		public NativeArray<int> VehicleNrOfWheels;

		[ReadOnly]
		public NativeArray<bool> ExcludedWheels;

		public void Execute(int i)
		{
		}

		private float3 ComputeSuspensionForce(float springForce, float compression, float3 normalPoint, int index)
		{
			return default(float3);
		}
	}
}
