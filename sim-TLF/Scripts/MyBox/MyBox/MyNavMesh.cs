using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyBox
{
	public static class MyNavMesh
	{
		public static float GetLength(this NavMeshPath path)
		{
			Vector3[] corners = path.corners;
			float num = 0f;
			for (int i = 1; i < corners.Length; i++)
			{
				num += Vector3.Distance(corners[i - 1], corners[i]);
			}
			return num;
		}

		public static float GetTimeToPass(this NavMeshPath path, float speed)
		{
			return path.GetLength() / speed + (float)(path.corners.Length - 1) * 0.5f;
		}

		public static Vector3 GetPointOnPath(this NavMeshPath path, float rate)
		{
			rate = Mathf.Clamp01(rate);
			float length = path.GetLength();
			float num = 0f;
			for (int i = 1; i < path.corners.Length; i++)
			{
				Vector3 a = path.corners[i - 1];
				Vector3 b = path.corners[i];
				float num2 = Vector3.Distance(a, b) / length;
				num += num2;
				if (rate <= num)
				{
					float num3 = num - rate;
					float t = 1f - num3 / num2;
					return Vector3.Lerp(a, b, t);
				}
			}
			return path.corners[path.corners.Length - 1];
		}

		public static IEnumerable<Vector3> GetPointsOnPath(this NavMeshPath path, float distance = 1f)
		{
			float pieceTraversedDistance = 0f;
			for (int i = 1; i < path.corners.Length; i++)
			{
				Vector3 from = path.corners[i - 1];
				Vector3 to = path.corners[i];
				float pieceLength;
				for (pieceLength = Vector3.Distance(from, to); pieceTraversedDistance < pieceLength + distance; pieceTraversedDistance += distance)
				{
					float t = pieceTraversedDistance / pieceLength;
					yield return Vector3.Lerp(from, to, t);
				}
				pieceTraversedDistance -= pieceLength;
			}
		}
	}
}
