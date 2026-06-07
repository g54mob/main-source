using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Vector3Comparer : IComparer<Vector3>, IEqualityComparer<Vector3>
	{
		private static Vector3Comparer comparer_ = new Vector3Comparer();

		public int Compare(Vector3 v0, Vector3 v1)
		{
			if (Comparer.IsEquivalent(v0, v1))
			{
				return 0;
			}
			if (v0.x < v1.x - 0.0001f || (Comparer.IsEquivalent(v0.x, v1.x) && v0.y < v1.y - 0.0001f) || (Comparer.IsEquivalent(v0.x, v1.x) && Comparer.IsEquivalent(v0.y, v1.y) && v0.z < v1.z - 0.0001f))
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(Vector3 x, Vector3 y)
		{
			return Comparer.IsEquivalent(x, y);
		}

		public int GetHashCode(Vector3 v)
		{
			return v.GetHashCode();
		}

		public static bool Less(Vector3 v0, Vector3 v1)
		{
			return comparer_.Compare(v0, v1) == -1;
		}

		public static bool Greater(Vector3 v0, Vector3 v1)
		{
			return comparer_.Compare(v0, v1) == 1;
		}

		public static bool Equivalent(Vector3 v0, Vector3 v1)
		{
			return comparer_.Compare(v0, v1) == 0;
		}
	}
}
