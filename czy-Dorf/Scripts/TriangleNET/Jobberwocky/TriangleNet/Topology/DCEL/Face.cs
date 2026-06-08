using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Topology.DCEL
{
	public class Face
	{
		public static readonly Face Empty;

		internal int id;

		internal Point generator;

		internal HalfEdge edge;

		internal bool bounded;

		public int ID => id;

		static Face()
		{
			Empty = new Face(null);
			Empty.id = -1;
		}

		public Face(Point generator)
			: this(generator, null)
		{
		}

		public Face(Point generator, HalfEdge edge)
		{
			this.generator = generator;
			this.edge = edge;
			bounded = true;
			if (generator != null)
			{
				id = generator.ID;
			}
		}

		public override string ToString()
		{
			return $"F-ID {id}";
		}
	}
}
