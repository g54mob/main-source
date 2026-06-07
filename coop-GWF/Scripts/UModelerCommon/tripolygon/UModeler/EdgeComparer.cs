using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class EdgeComparer : IComparer<Edge>
	{
		public int Compare(Edge e0, Edge e1)
		{
			if (e0.IsEquivalent(e1))
			{
				return 0;
			}
			if (Vector3Comparer.Less(e0.p0, e1.p0) || (Comparer.IsEquivalent(e0.p0, e1.p0) && Vector3Comparer.Less(e0.p1, e1.p1)))
			{
				return -1;
			}
			return 1;
		}
	}
}
