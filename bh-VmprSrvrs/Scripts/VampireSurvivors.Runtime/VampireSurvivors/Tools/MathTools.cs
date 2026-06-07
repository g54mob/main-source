using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public static class MathTools
	{
		public static Vector2 SetToPolar(this Vector2 v2, float azimuth, float radius)
		{
			return default(Vector2);
		}

		public static float Remap(this float value, float from1, float to1, float from2, float to2)
		{
			return 0f;
		}

		public static bool ContainsRect(Rect rectA, Rect rectB)
		{
			return false;
		}

		public static Vector2 RandomOutside(Rect outer, Rect inner)
		{
			return default(Vector2);
		}

		public static List<Vector2> GetPointsOnCircle(int count, float radius = 1f)
		{
			return null;
		}

		public static List<Vector2> GetPoints(int count, float spawnAngle, float radius = 1f)
		{
			return null;
		}

		public static float DistanceSq(Vector2 v1, Vector2 v2)
		{
			return 0f;
		}

		public static T FurthestObject<T>(Vector2 source, List<T> targets) where T : Component
		{
			return null;
		}

		public static T FurthestObject<T>(Vector2 source, HashSet<T> targets) where T : Component
		{
			return null;
		}

		public static List<T> ListNearestToFarthest<T>(Vector2 source, HashSet<T> targets) where T : Component
		{
			return null;
		}

		public static GameObject FurthestGameObject(Vector2 source, List<GameObject> targets)
		{
			return null;
		}

		public static GameObject FurthestGameObject(Vector2 source, Dictionary<int, GameObject> targets, out float max)
		{
			max = default(float);
			return null;
		}

		public static GameObject FurthestGameObject(List<Vector2> sources, Dictionary<int, GameObject> targets)
		{
			return null;
		}
	}
}
