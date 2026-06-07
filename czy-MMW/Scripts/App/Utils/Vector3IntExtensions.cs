using UnityEngine;

namespace Utils
{
	public static class Vector3IntExtensions
	{
		public static Vector3Int RotateCW2D(this Vector3Int vector)
		{
			return new Vector3Int(vector.y, -vector.x, 0);
		}

		public static Vector3Int RotateCCW2D(this Vector3Int vector)
		{
			return new Vector3Int(-vector.y, vector.x, 0);
		}
	}
}
