namespace Jobberwocky.TriangleNet.Topology.DCEL
{
	public class HalfEdge
	{
		internal int id;

		internal Vertex origin;

		internal Face face;

		internal HalfEdge twin;

		internal HalfEdge next;

		public Vertex Origin => origin;

		public Face Face => face;

		public HalfEdge Twin => twin;

		public HalfEdge(Vertex origin, Face face)
		{
			this.origin = origin;
			this.face = face;
			if (face != null && face.edge == null)
			{
				face.edge = this;
			}
		}

		public override string ToString()
		{
			return $"HE-ID {id} (Origin = VID-{origin.id})";
		}
	}
}
