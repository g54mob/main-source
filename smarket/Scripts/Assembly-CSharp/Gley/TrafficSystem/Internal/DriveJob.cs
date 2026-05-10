using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Gley.TrafficSystem.Internal
{
	[BurstCompile]
	public struct DriveJob : IJobParallelFor
	{
		public NativeArray<float3> BodyForce;

		public NativeArray<float3> TrailerForce;

		public NativeArray<float> ActionValue;

		public NativeArray<float> WheelRotation;

		public NativeArray<float> TurnAngle;

		public NativeArray<float> VehicleRotationAngle;

		public NativeArray<int> Gear;

		public NativeArray<bool> ReadyToRemove;

		public NativeArray<bool> NeedsWaypoint;

		public NativeArray<bool> IsBraking;

		[ReadOnly]
		public NativeArray<DriveActions> SpecialDriveAction;

		[ReadOnly]
		public NativeArray<float3> TargetWaypointPosition;

		[ReadOnly]
		public NativeArray<float3> AllBotsPosition;

		[ReadOnly]
		public NativeArray<float3> GroundDirection;

		[ReadOnly]
		public NativeArray<float3> ForwardDirection;

		[ReadOnly]
		public NativeArray<float3> RightDirection;

		[ReadOnly]
		public NativeArray<float3> TrailerRightDirection;

		[ReadOnly]
		public NativeArray<float3> TrailerForwardDirection;

		[ReadOnly]
		public NativeArray<float3> TriggerForwardDirection;

		[ReadOnly]
		public NativeArray<float3> DownDirection;

		[ReadOnly]
		public NativeArray<float3> CarVelocity;

		[ReadOnly]
		public NativeArray<float3> TrailerVelocity;

		[ReadOnly]
		public NativeArray<float3> CameraPositions;

		[ReadOnly]
		public NativeArray<float3> ClosestObstacle;

		[ReadOnly]
		public NativeArray<float> WheelCircumferences;

		[ReadOnly]
		public NativeArray<float> MaxSteer;

		[ReadOnly]
		public NativeArray<float> PowerStep;

		[ReadOnly]
		public NativeArray<float> BrakeStep;

		[ReadOnly]
		public NativeArray<float> Drag;

		[ReadOnly]
		public NativeArray<float> TrailerDrag;

		[ReadOnly]
		public NativeArray<float> MaxSpeed;

		[ReadOnly]
		public NativeArray<float> WheelDistance;

		[ReadOnly]
		public NativeArray<float> SteeringStep;

		[ReadOnly]
		public NativeArray<float> VehicleLength;

		[ReadOnly]
		public NativeArray<float> MassDifference;

		[ReadOnly]
		public NativeArray<float> DistanceToStop;

		[ReadOnly]
		public NativeArray<int> WheelSign;

		[ReadOnly]
		public NativeArray<int> NrOfWheels;

		[ReadOnly]
		public NativeArray<int> TrailerNrOfWheels;

		[ReadOnly]
		public NativeArray<bool> ExcludedVehicles;

		[ReadOnly]
		public float3 WorldUp;

		[ReadOnly]
		public float DistanceToRemove;

		[ReadOnly]
		public float FixedDeltaTime;

		private float3 _waypointDirection;

		private float _minWaypointDistance;

		private float _targetSpeed;

		private float _currentSpeed;

		private float _dotProduct;

		private float _waypointDistance;

		private float _angle;

		private bool _avoidBackward;

		private bool _avoidForward;

		public void Execute(int index)
		{
		}

		private void Drive(int index)
		{
		}

		private void Forward(int index, float maxSpeed)
		{
		}

		private void Reverse(int index)
		{
		}

		private void AvoidReverse(int index)
		{
		}

		private void StopNow(int index)
		{
		}

		private void StopInDistance(int index)
		{
		}

		private void StopInPoint(int index)
		{
		}

		private void AvoidForward(int index)
		{
		}

		private void Follow(int index, float followSpeed)
		{
		}

		private void ComputeBodyForce(int index, float maxSpeed, int gear)
		{
		}

		private void ChangeWaypoint(int index)
		{
		}

		private void ComputeWheelRotationAngle(int index)
		{
		}

		private void ComputeSteerAngle(int index, float maxSteer, float targetVelocity)
		{
		}

		private void RemoveVehicle(int index)
		{
		}

		private bool IsInCorrectGear(int index)
		{
			return false;
		}

		private void PutInDrive(int index)
		{
		}

		private void PutInReverse(int index)
		{
		}

		private void ApplyAcceleration(int index)
		{
		}

		private void ApplyBrakes(int index, float power)
		{
		}

		private void AvoidBackward()
		{
		}

		private float SignedAngle(float3 dir1, float3 dir2, float3 normal)
		{
			return 0f;
		}

		private float GetDrag(float targetSpeed, float drag, float fixedDeltaTime)
		{
			return 0f;
		}
	}
}
