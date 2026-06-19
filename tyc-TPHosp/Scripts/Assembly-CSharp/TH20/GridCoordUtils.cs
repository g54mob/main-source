using UnityEngine;

namespace TH20
{
	public static class GridCoordUtils
	{
		public static Vector3 ToWorldPosition(this GridCoord source)
		{
			return GridCoord.GridCoordToWorldPosition(source);
		}

		public static GridCoord ToGridCoord(this Vector3 source)
		{
			return GridCoord.WorldPositionToGridCoord(source);
		}
	}
}
