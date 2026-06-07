using UnityEngine;

namespace Gh.Tk
{
	public static class DistanceHelper
	{
		public static float GetSquareXZDistance(this GameObjectX source, GameObjectX target)
		{
			return 0f;
		}

		public static double GetSquareXZDistance(this GameObjectX source, Vector3 target)
		{
			return 0.0;
		}

		public static float GetSquareXZDistance(this Transform source, Transform target)
		{
			return 0f;
		}

		public static float GetSquareXZDistance(this Vector3 source, Vector3 target)
		{
			return 0f;
		}
	}
}
