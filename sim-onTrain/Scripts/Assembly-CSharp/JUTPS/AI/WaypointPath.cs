using System;
using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.AI
{
	public class WaypointPath : MonoBehaviour
	{
		public enum OnEndPathAction
		{
			Stop = 0,
			ReversePath = 1,
			RestartPath = 2
		}

		[HideInInspector]
		public List<Transform> WaypointsTransforms = new List<Transform>();

		[HideInInspector]
		public Vector3[] WaypointPathPositions;

		[Header("Waypoints Settings")]
		public bool ClearWaypointsAfterGettingPathPositions;

		public bool ReverseOnStart;

		[Header("Path Gizmo Visualization")]
		public bool DrawPath = true;

		public Color LineColor = new Color(1f, 1f, 1f, 0.2f);

		public Color CornerColor = new Color(0f, 1f, 0f, 0.5f);

		private Bounds waypointBounds;

		private void Start()
		{
			RefreshWaypoints();
			if (ReverseOnStart)
			{
				Array.Reverse(WaypointPathPositions);
			}
		}

		public Vector3 GetWaypointCenter()
		{
			if (waypointBounds.center == Vector3.zero)
			{
				waypointBounds = new Bounds(WaypointPathPositions[0], Vector3.zero);
				for (int i = 1; i < WaypointPathPositions.Length; i++)
				{
					waypointBounds.Encapsulate(WaypointPathPositions[i]);
				}
				return waypointBounds.center;
			}
			return waypointBounds.center;
		}

		public void RefreshWaypoints()
		{
			if (WaypointsTransforms.Count == 0 && !Application.isPlaying)
			{
				Transform obj = new GameObject("Waypoint").transform;
				Transform transform = new GameObject("Waypoint (1)").transform;
				obj.position = base.transform.position;
				transform.position = base.transform.position + base.transform.forward * 2f;
				obj.parent = base.transform;
				transform.parent = base.transform;
			}
			WaypointsTransforms = WaypointUtilities.GetAllWaypointsChilds(base.transform);
			WaypointPathPositions = WaypointUtilities.GetWaypointsPositions(base.transform);
			if (!ClearWaypointsAfterGettingPathPositions || !Application.isPlaying)
			{
				return;
			}
			foreach (Transform waypointsTransform in WaypointsTransforms)
			{
				UnityEngine.Object.Destroy(waypointsTransform.gameObject);
			}
			waypointBounds.center = Vector3.zero;
			GetWaypointCenter();
		}

		public static void FollowPathTowards(GameObject gameObjectToMove, ref Vector3[] path, ref int currentPathCornerId, float Speed = 10f, OnEndPathAction onPathEnd = OnEndPathAction.ReversePath)
		{
			if (path.Length == 0 || gameObjectToMove == null)
			{
				return;
			}
			float num = 0.1f;
			float num2 = Vector3.Distance(gameObjectToMove.transform.position, path[currentPathCornerId]);
			if (path.Length - 1 < currentPathCornerId)
			{
				currentPathCornerId = 0;
			}
			if (num2 < num && currentPathCornerId < path.Length - 1)
			{
				currentPathCornerId++;
			}
			gameObjectToMove.transform.position = Vector3.MoveTowards(gameObjectToMove.transform.position, path[currentPathCornerId], Speed * Time.deltaTime);
			if (currentPathCornerId >= path.Length - 1 && num2 < num)
			{
				switch (onPathEnd)
				{
				case OnEndPathAction.ReversePath:
					Array.Reverse(path);
					currentPathCornerId = 0;
					break;
				case OnEndPathAction.RestartPath:
					currentPathCornerId = 0;
					break;
				case OnEndPathAction.Stop:
					break;
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (!DrawPath)
			{
				return;
			}
			if (!Application.isPlaying)
			{
				if (base.transform.childCount == 0)
				{
					RefreshWaypoints();
					return;
				}
				if (base.transform.childCount != WaypointsTransforms.Count || WaypointPathPositions[base.transform.childCount - 1] != WaypointsTransforms[base.transform.childCount - 1].position)
				{
					RefreshWaypoints();
				}
			}
			WaypointUtilities.DrawPath(WaypointPathPositions, LineColor, CornerColor);
		}
	}
}
