using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class VertexPosComparer : IEqualityComparer<Vertex>
	{
		private static VertexPosComparer comparer_ = new VertexPosComparer();

		public bool Equals(Vertex ve0, Vertex ve1)
		{
			return Comparer.IsEquivalent(ve0.pos, ve1.pos);
		}

		public int GetHashCode(Vertex ve)
		{
			return (int)ve.pos.sqrMagnitude;
		}

		public static bool Equivalent(Vertex v0, Vertex v1)
		{
			return comparer_.Equals(v0, v1);
		}
	}
}
