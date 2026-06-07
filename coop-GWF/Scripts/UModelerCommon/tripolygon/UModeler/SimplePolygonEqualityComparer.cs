using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class SimplePolygonEqualityComparer : IEqualityComparer<SimplePolygon>
	{
		private static SimplePolygonEqualityComparer comparer_ = new SimplePolygonEqualityComparer();

		public bool Equals(SimplePolygon poly0, SimplePolygon poly1)
		{
			if (poly0.GetVertexCount() != poly1.GetVertexCount())
			{
				return false;
			}
			if (poly0.GetEdgeCount() != poly1.GetEdgeCount())
			{
				return false;
			}
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < poly0.GetEdgeCount(); i++)
			{
				Edge pureEdge = poly0.GetPureEdge(i);
				list.Add(pureEdge);
			}
			EdgeEqualityComparer edgeEqual = new EdgeEqualityComparer();
			for (int j = 0; j < poly1.GetEdgeCount(); j++)
			{
				Edge e = poly1.GetPureEdge(j);
				if (list.FindIndex((Edge a) => edgeEqual.Equals(a, e)) == -1)
				{
					return false;
				}
			}
			return true;
		}

		public int GetHashCode(SimplePolygon poly)
		{
			int num = 0;
			for (int i = 0; i < poly.GetVertexCount(); i++)
			{
				Vertex vertex = poly.GetVertex(i);
				num ^= (int)(vertex.pos.x * 100f);
				num ^= (int)(vertex.pos.y * 100f);
				num ^= (int)(vertex.pos.z * 100f);
			}
			return num;
		}

		public static bool Equivalent(SimplePolygon poly0, SimplePolygon poly1)
		{
			return comparer_.Equals(poly0, poly1);
		}
	}
}
