using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class EdgeEqualityComparer : IEqualityComparer<Edge>
	{
		public bool Equals(Edge x, Edge y)
		{
			if (!x.IsEquivalent(y))
			{
				return x.IsEquivalent(y.Invert());
			}
			return true;
		}

		public int GetHashCode(Edge obj)
		{
			return (int)(obj.length * 100f);
		}
	}
}
