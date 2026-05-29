using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Libs
{
	public static class RectIntExtension
	{
		public static Vector3Int ToV3I(this RectInt ri)
		{
			return default(Vector3Int);
		}

		public static RectInt FromV3IToRI(this Vector3Int v3I)
		{
			return default(RectInt);
		}

		public static int XMax(this RectInt ri)
		{
			return 0;
		}

		public static int YMax(this RectInt ri)
		{
			return 0;
		}

		public static int XMin(this RectInt ri)
		{
			return 0;
		}

		public static int YMin(this RectInt ri)
		{
			return 0;
		}

		public static RectInt NextLarger(this RectInt ri)
		{
			return default(RectInt);
		}

		public static RectInt ToInclusive(this List<RectInt> rects)
		{
			return default(RectInt);
		}

		public static Vector2Int[] ToVector2Ints(this RectInt ri)
		{
			return null;
		}

		public static List<StructureAddr> ToStructureAddrs(this RectInt ri)
		{
			return null;
		}

		public static (int, Dir.Rot, RectInt) GetLineLengthInGrid(this RectInt from, RectInt to, int lenLimit = 0)
		{
			return default((int, Dir.Rot, RectInt));
		}

		public static (int, Dir.Rot, RectInt) GetLineLengthInGrid(this RectInt? from, RectInt to, int lenLimit = 0)
		{
			return default((int, Dir.Rot, RectInt));
		}

		public static bool IsNeighbor(this RectInt self, RectInt other)
		{
			return false;
		}

		public static Vector2 CenterLeft(this RectInt self)
		{
			return default(Vector2);
		}

		public static Vector2 CenterRight(this RectInt self)
		{
			return default(Vector2);
		}

		public static Vector2 CenterTop(this RectInt self)
		{
			return default(Vector2);
		}

		public static Vector2 CenterBottom(this RectInt self)
		{
			return default(Vector2);
		}

		public static RectInt[] GetNeighborLineGrids(this RectInt from, RectInt to)
		{
			return null;
		}

		public static Vector2Int? ToOppositeEnd(this RectInt self, Vector2Int start)
		{
			return null;
		}

		public static int length(this RectInt rect)
		{
			return 0;
		}

		public static bool IsVertex(this RectInt rect, Vector2Int pos)
		{
			return false;
		}

		public static bool ContainsInt(this RectInt rect, Vector2Int pos)
		{
			return false;
		}

		public static string ToDumpMinMax(this RectInt self)
		{
			return null;
		}
	}
}
