using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Map.Waypoint
{
	public class WaypointManager : MonoBehaviour
	{
		[Header("Waypoint Behavior")]
		[Tooltip("XZ-plane distance within which a right-click removes the existing waypoint instead of placing a new one")]
		[SerializeField]
		private float removeProximityThreshold;

		[Tooltip("When the player gets within this distance (meters), the waypoint auto-removes")]
		[SerializeField]
		private float autoRemoveDistance;

		[Header("Map Icon")]
		[Tooltip("MapIconDefinition asset for the waypoint marker on the map")]
		[SerializeField]
		private MapIconDefinition waypointIconDefinition;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Camera playerCamera;

		private GameObject waypointAnchor;

		public static WaypointManager Instance { get; private set; }

		public bool HasWaypoint { get; private set; }

		public Vector3 WaypointPosition { get; private set; }

		public float DistanceToWaypoint { get; private set; }

		public bool IsWaypointOnScreen { get; private set; }

		public event Action<Vector3> OnWaypointPlaced
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnWaypointRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void HandleLocalCameraRegistered(Camera cam)
		{
		}

		private void HandleLocalCameraUnregistered()
		{
		}

		public void HandleMapRightClick(Vector3 worldPos)
		{
		}

		public void PlaceWaypoint(Vector3 worldPos)
		{
		}

		public void RemoveWaypoint()
		{
		}

		private void CalculateDirectionalData()
		{
		}

		private void CreateWaypointAnchor(Vector3 worldPos)
		{
		}

		private void DestroyWaypointAnchor()
		{
		}
	}
}
