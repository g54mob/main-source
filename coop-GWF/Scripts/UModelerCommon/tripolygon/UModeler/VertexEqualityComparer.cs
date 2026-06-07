using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class VertexEqualityComparer : IEqualityComparer<Vertex>
	{
		private static VertexEqualityComparer comparer_ = new VertexEqualityComparer();

		public bool Equals(Vertex ve0, Vertex ve1)
		{
			return Comparer.IsEquivalent(ve0.uv, ve1.uv) & Comparer.IsEquivalent(ve0.pos, ve1.pos);
		}

		public int GetHashCode(Vertex ve)
		{
			return (int)(ve.uv.sqrMagnitude * 100f + ve.pos.sqrMagnitude);
		}

		public static bool Equivalent(Vertex v0, Vertex v1)
		{
			return comparer_.Equals(v0, v1);
		}
	}
}
