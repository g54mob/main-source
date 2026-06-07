using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Vector2Comparer : IComparer<Vector2>
	{
		private static Vector2Comparer comparer_ = new Vector2Comparer();

		public int Compare(Vector2 v0, Vector2 v1)
		{
			if (Comparer.IsEquivalent(v0, v1))
			{
				return 0;
			}
			if (v0.x < v1.x - 0.0001f || (Comparer.IsEquivalent(v0.x, v1.x) && v0.y < v1.y - 0.0001f))
			{
				return -1;
			}
			return 1;
		}

		public static bool Less(Vector2 v0, Vector2 v1)
		{
			return comparer_.Compare(v0, v1) == -1;
		}

		public static bool Greater(Vector2 v0, Vector2 v1)
		{
			return comparer_.Compare(v0, v1) == 1;
		}

		public static bool Equivalent(Vector2 v0, Vector2 v1)
		{
			return comparer_.Compare(v0, v1) == 0;
		}
	}
}
