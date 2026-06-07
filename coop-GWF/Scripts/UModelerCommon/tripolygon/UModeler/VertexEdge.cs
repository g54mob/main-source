namespace tripolygon.UModeler
{
	public class VertexEdge
	{
		public Vertex v0;

		public Vertex v1;

		public VertexEdge()
		{
		}

		public VertexEdge(Vertex _v0, Vertex _v1)
		{
			v0 = _v0;
			v1 = _v1;
		}

		public VertexEdge Clone()
		{
			return new VertexEdge(v0, v1);
		}

		public VertexEdge Invert()
		{
			Vertex vertex = v0;
			v0 = v1;
			v1 = vertex;
			return this;
		}
	}
}
