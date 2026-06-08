using System.Reflection;
using Jobberwocky.TriangleNet.Topology;

namespace Jobberwocky.TriangleNet.Geometry
{
	[DefaultMember("Item")]
	public class Vertex : Point
	{
		internal int hash;

		internal double[] attributes;

		internal VertexType type;

		internal Otri tri;

		public Vertex(double x, double y)
			: this(x, y, 0)
		{
		}

		public Vertex(double x, double y, int mark)
			: base(x, y, mark)
		{
			type = VertexType.InputVertex;
		}

		public Vertex(double x, double y, int mark, int attribs)
			: this(x, y, mark)
		{
			if (attribs > 0)
			{
				attributes = new double[attribs];
			}
		}

		public override int GetHashCode()
		{
			return hash;
		}
	}
}
