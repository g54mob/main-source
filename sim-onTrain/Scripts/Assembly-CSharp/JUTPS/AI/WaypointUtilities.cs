using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.AI
{
	public class WaypointUtilities
	{
		public enum FollowingState
		{
			None = 0,
			Started = 1,
			Following = 2,
			Ended = 3
		}

		public static FollowingState GetPathFollowingState(Transform PathFollower, ref Vector3 OldFollowerPosition, Vector3[] path, int currentPathCornerID, float StoppingDistance = 3f)
		{
			FollowingState result = FollowingState.None;
			if (path.Length < 2)
			{
				return result;
			}
			Vector3.Distance(PathFollower.position, path[currentPathCornerID]);
			float num = Vector3.Distance(PathFollower.position, path[^1]);
			if (OldFollowerPosition == Vector3.zero)
			{
				OldFollowerPosition = PathFollower.position;
			}
			float num2 = (PathFollower.position - OldFollowerPosition).magnitude * 2f;
			OldFollowerPosition = PathFollower.position;
			result = ((num2 > 2f) ? FollowingState.Following : FollowingState.None);
			if (num2 < 1f && num2 > 0f && currentPathCornerID < 2)
			{
				result = FollowingState.Started;
			}
			if (num - 2f < StoppingDistance)
			{
				result = FollowingState.Ended;
			}
			return result;
		}

		public static Vector3 GetClosestPoint(Vector3 SourcePosition, Vector3[] PathList, int SpecificIDPositionFromPath = -1)
		{
			float num = 9999f;
			Vector3 vector = new Vector3(0f, 0f, 0f);
			List<Vector3> list = new List<Vector3>();
			foreach (Vector3 vector2 in PathList)
			{
				float num2 = Vector3.Distance(SourcePosition, vector2);
				if (num2 < num)
				{
					vector = vector2;
					list.Add(vector);
					num = num2;
				}
			}
			list.Reverse();
			if (SpecificIDPositionFromPath == -1 || list.Count != PathList.Length || SpecificIDPositionFromPath > list.Count - 1)
			{
				return vector;
			}
			_ = list[SpecificIDPositionFromPath];
			return list[SpecificIDPositionFromPath];
		}

		public static void DrawPath(Vector3[] Path, Color LineColor = default(Color), Color CornerColor = default(Color))
		{
			if (LineColor == Color.clear || CornerColor == Color.clear)
			{
				LineColor = new Color(1f, 1f, 1f, 0.2f);
				CornerColor = new Color(0f, 1f, 0f, 0.5f);
			}
			for (int i = 0; i < Path.Length; i++)
			{
				Gizmos.color = CornerColor;
				Gizmos.DrawSphere(Path[i], 0.1f);
				Gizmos.DrawWireSphere(Path[i], 0.1f);
				if (i < Path.Length - 1)
				{
					Gizmos.color = LineColor;
					_ = ref Path[i + 1];
					_ = ref Path[i];
					Gizmos.DrawLine(Path[i], Path[i + 1]);
				}
			}
		}

		public static Vector3[] ConvertWaypointTransformsToVector3Path(List<Transform> waypointsList)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (Transform waypoints in waypointsList)
			{
				list.Add(waypoints.position);
			}
			return list.ToArray();
		}

		public static List<Transform> GetAllWaypointsChilds(Transform waypointPath)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < waypointPath.transform.childCount; i++)
			{
				list.Add(waypointPath.transform.GetChild(i));
			}
			return list;
		}

		public static void DividePath(ref Vector3[] originalPath, float divideAtDistance = 1f)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < originalPath.Length; i++)
			{
				if (i + 1 < originalPath.Length)
				{
					float num = Vector3.Distance(originalPath[i], originalPath[i + 1]);
					Vector3 normalized = (originalPath[i + 1] - originalPath[i]).normalized;
					for (float num2 = 0f; num2 < num; num2 += divideAtDistance)
					{
						list.Add(originalPath[i] + normalized * num2);
					}
				}
				else
				{
					list.Add(originalPath[originalPath.Length - 1]);
				}
			}
			originalPath = list.ToArray();
		}

		public static float GetPathFullSize(Vector3[] path)
		{
			float num = 0f;
			for (int i = 0; i < path.Length - 1; i++)
			{
				if (i + 1 < path.Length - 1)
				{
					num += Vector3.Distance(path[i], path[i + 1]);
				}
			}
			return num;
		}

		public static Vector3[] GetWaypointsPositions(Transform waypointPath)
		{
			return ConvertWaypointTransformsToVector3Path(GetAllWaypointsChilds(waypointPath));
		}
	}
}
