using System;
using JUTPS.VehicleSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.AI
{
	[AddComponentMenu("JU TPS/AI/Vehicle AI")]
	public class VehicleAI : MonoBehaviour
	{
		private Vehicle vehicle;

		private Vector3 oldPosition;

		[HideInInspector]
		public int CurrentWayPointToFollow;

		[HideInInspector]
		public Vector3[] PathToDestination;

		[Header("Destination Settings")]
		public bool EnablePathfinding;

		public float RecalculatePathRefreshRate = 1f;

		public Vector3 Destination;

		[JUReadOnly("EnablePathfinding", true, false)]
		public WaypointPath WaypointPath;

		[Header("Vehicle Path Locomotion Settings")]
		public float DistanceToContinuePath = 2f;

		public float VehicleDesacelerationIntensity = 1f;

		public Vehicle.VehicleRaycastCheck FrontCheck;

		public bool CheckNearestPointOnPath;

		public WaypointPath.OnEndPathAction OnEndPath;

		[Header("Events")]
		public UnityEvent OnStartPath;

		public UnityEvent OnFollowing;

		public UnityEvent OnEnded;

		private bool Started;

		private bool Following;

		private bool Ended;

		private void Start()
		{
			vehicle = GetComponent<Vehicle>();
			if (EnablePathfinding || WaypointPath == null)
			{
				RecalculatePath();
			}
			else
			{
				PathToDestination = WaypointPath.WaypointPathPositions;
			}
			InvokeRepeating("RecalculatePath", RecalculatePathRefreshRate, RecalculatePathRefreshRate);
		}

		public void SetVehicleDestination(Vector3 destination, bool recalculatePath = true)
		{
			Destination = destination;
			RecalculatePath();
		}

		public void RecalculatePath()
		{
			if (EnablePathfinding)
			{
				PathToDestination = JUPathFinder.CalculatePath(base.transform.position, Destination);
				WaypointUtilities.DividePath(ref PathToDestination, 5f);
				CurrentWayPointToFollow = 0;
			}
		}

		private void Update()
		{
			if (vehicle.IsOn && vehicle.GroundCheck.IsGrounded)
			{
				FrontCheck.Check(vehicle.transform, base.transform.forward);
				FollowPath(ref PathToDestination, vehicle, DistanceToContinuePath, VehicleDesacelerationIntensity, ref CurrentWayPointToFollow, OnEndPath, FrontCheck.IsCollided, CheckNearestPointOnPath);
				if (EnablePathfinding)
				{
					JUPathFinder.VisualizePath(PathToDestination);
				}
				WaypointUtilities.FollowingState pathFollowingState = WaypointUtilities.GetPathFollowingState(base.transform, ref oldPosition, PathToDestination, CurrentWayPointToFollow, DistanceToContinuePath);
				if (pathFollowingState == WaypointUtilities.FollowingState.Started && !Started)
				{
					OnStartPath.Invoke();
					Started = true;
					Ended = false;
				}
				if (pathFollowingState == WaypointUtilities.FollowingState.Following)
				{
					OnFollowing.Invoke();
				}
				Following = pathFollowingState == WaypointUtilities.FollowingState.Following;
				if (pathFollowingState == WaypointUtilities.FollowingState.Ended && !Ended)
				{
					OnEnded.Invoke();
					Following = false;
					Started = false;
					Ended = true;
				}
			}
		}

		public static void FollowPath(ref Vector3[] path, Vehicle vehicle, float stoppingDistance, float desacelerationOnCurvesIntensity, ref int currentPathCornerId, WaypointPath.OnEndPathAction onPathEnd = WaypointPath.OnEndPathAction.Stop, bool TheresWallInVehicleFront = false, bool CheckClosestPoint = false)
		{
			if (!vehicle.IsOn || !vehicle.GroundCheck.IsGrounded || path.Length == 0)
			{
				return;
			}
			if (path.Length - 1 < currentPathCornerId)
			{
				currentPathCornerId = 0;
			}
			Vector3 normalized = (path[currentPathCornerId] - vehicle.transform.position).normalized;
			Vector3 normalized2 = (WaypointUtilities.GetClosestPoint(vehicle.transform.position, path, 1) - vehicle.transform.position).normalized;
			float num = Vector3.Distance(vehicle.transform.position, path[currentPathCornerId]);
			float num2 = Vector3.SignedAngle(vehicle.transform.forward, normalized, Vector3.up);
			Vector3.SignedAngle(vehicle.transform.forward, normalized2, Vector3.up);
			float num3 = Vector3.Dot(vehicle.transform.forward, normalized);
			float horizontalInput = Mathf.Clamp(num2, -90f, 90f) / 90f * (1f + Mathf.Clamp(num3, 0f, 1f));
			float verticalInput = 0f;
			bool brakeInput = false;
			if (num + vehicle.GetVehicleCurrentSpeed(0.2f) < stoppingDistance && currentPathCornerId < path.Length - 1)
			{
				currentPathCornerId++;
			}
			if (currentPathCornerId != path.Length - 1 && num * 2f > stoppingDistance)
			{
				float num4 = Mathf.Clamp(Mathf.Abs(num2), 0f, 90f);
				float value = desacelerationOnCurvesIntensity * (num4 / 360f + vehicle.GetVehicleCurrentSpeed(0.05f) / 4f);
				verticalInput = 1f - Mathf.Clamp(value, -1f, 0.5f);
				verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
				brakeInput = false;
			}
			if (num3 > 0.3f && vehicle.GetSmoothedForwardMovement() < -1f)
			{
				Debug.Log("Forward Movement = " + vehicle.GetSmoothedForwardMovement());
				Debug.Log("BRAKING");
				brakeInput = true;
			}
			if (TheresWallInVehicleFront)
			{
				verticalInput = -2f;
				horizontalInput = ((!(num2 > 0f)) ? 1 : (-1));
				brakeInput = false;
			}
			if (CheckClosestPoint)
			{
				Vector3 closestPoint = WaypointUtilities.GetClosestPoint(vehicle.transform.position, path);
				int num5 = Array.IndexOf(path, closestPoint);
				if (Vector3.Distance(vehicle.transform.position, closestPoint) < num && num5 > currentPathCornerId && num5 != path.Length - 1)
				{
					currentPathCornerId = num5;
				}
			}
			if (currentPathCornerId >= path.Length - 1 && num < stoppingDistance)
			{
				switch (onPathEnd)
				{
				case WaypointPath.OnEndPathAction.Stop:
					verticalInput = 0f;
					brakeInput = true;
					break;
				case WaypointPath.OnEndPathAction.ReversePath:
					Array.Reverse(path);
					currentPathCornerId = 0;
					break;
				case WaypointPath.OnEndPathAction.RestartPath:
					currentPathCornerId = 0;
					break;
				}
			}
			vehicle.SetEngineInputs(horizontalInput, verticalInput, brakeInput);
		}

		public static float GetVehicleRightDirectionIntensity(Vehicle vehicle, Vector3 currentTargetPathPosition)
		{
			Vector3 normalized = (currentTargetPathPosition - vehicle.transform.position).normalized;
			return Vector3.Dot(vehicle.transform.forward, normalized);
		}
	}
}
