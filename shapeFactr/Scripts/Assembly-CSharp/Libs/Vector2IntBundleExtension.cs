using UnityEngine;

namespace Libs
{
	public static class Vector2IntBundleExtension
	{
		public static Vector2Int? ToOppositeEnd(this Vector2IntBundle self, Vector2Int start)
		{
			return null;
		}

		public static RectInt ToInclusiveRectInt(this Vector2IntBundle rect)
		{
			return default(RectInt);
		}

		public static RectInt NextLargerRect(this Vector2IntBundle ri)
		{
			return default(RectInt);
		}

		public static Rect ToInclusiveRect(this Vector2IntBundle rect)
		{
			return default(Rect);
		}

		public static Vector2 ToTopCenterVector2(this Vector2IntBundle rect)
		{
			return default(Vector2);
		}

		public static (int, Dir.Rot, Vector2IntBundle) GetLineLengthInGrid(this Vector2IntBundle from, Vector2IntBundle to, int lenLimit = 0, Dir.Rot? forceRightAngle = null, bool snap = true)
		{
			return default((int, Dir.Rot, Vector2IntBundle));
		}

		public static Vector2IntBundle FromV3IToV2IB(this Vector3Int v3I)
		{
			return default(Vector2IntBundle);
		}

		public static Vector2IntBundle[] GetNeighborLineGrids(this Vector2IntBundle from, Vector2IntBundle to)
		{
			return null;
		}

		public static bool IsNeighbor(this Vector2IntBundle self, Vector2IntBundle other)
		{
			return false;
		}
	}
}
