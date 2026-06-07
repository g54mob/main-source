using UnityEngine;

namespace Libs
{
	public static class Vector2IntExtension
	{
		public static Vector3Int ToV3I(this Vector2Int v2)
		{
			return default(Vector3Int);
		}

		public static Vector2Int FromV3I(this Vector3Int v3)
		{
			return default(Vector2Int);
		}

		public static Vector2Int[] AroundAddrs(this Vector2Int addr)
		{
			return null;
		}

		public static bool IsNeighbor(this Vector2Int self, Vector2Int other)
		{
			return false;
		}

		public static Vector2Int[] GetNeighborLines(this Vector2Int from, Vector2Int to)
		{
			return null;
		}

		public static (int, Dir.Rot, RectInt) GetLineLengthInGrid(this Vector2Int from, Vector2Int to)
		{
			return default((int, Dir.Rot, RectInt));
		}
	}
}
