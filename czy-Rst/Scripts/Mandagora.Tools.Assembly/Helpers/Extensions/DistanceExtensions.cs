using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Helpers.Extensions
{
	public static class DistanceExtensions
	{
		public static T ChooseClosestObject<T>(this Component target, IEnumerable<T> candidates) where T : Component
		{
			return candidates.ChooseClosestObject(target);
		}

		public static T ChooseClosestObject<T>(this IEnumerable<T> candidates, Component to) where T : Component
		{
			T result = null;
			float num = float.MaxValue;
			foreach (T candidate in candidates)
			{
				float magnitude = (candidate.transform.position - to.transform.position).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					result = candidate;
				}
			}
			return result;
		}

		public static GameObject ChooseClosestGameObject(this IEnumerable<GameObject> candidates, GameObject to)
		{
			GameObject result = null;
			float num = float.MaxValue;
			foreach (GameObject candidate in candidates)
			{
				float magnitude = (candidate.transform.position - to.transform.position).magnitude;
				if (magnitude < num)
				{
					num = magnitude;
					result = candidate;
				}
			}
			return result;
		}

		public static float CalculateDistance(this NavMeshPath path)
		{
			float num = 0f;
			if (path.corners.Length < 2)
			{
				return num;
			}
			for (int i = 0; i < path.corners.Length - 1; i++)
			{
				num += Vector3.Distance(path.corners[i], path.corners[i + 1]);
			}
			return num;
		}
	}
}
