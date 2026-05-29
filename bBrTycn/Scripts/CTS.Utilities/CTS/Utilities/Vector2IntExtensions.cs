using UnityEngine;

namespace CTS.Utilities
{
	public static class Vector2IntExtensions
	{
		public static int RandomInRangeInclusive(this Vector2Int vector)
		{
			return Random.Range(vector.x, vector.y + 1);
		}

		public static int RandomInRangeExclusive(this Vector2Int vector)
		{
			return Random.Range(vector.x, vector.y);
		}
	}
}
