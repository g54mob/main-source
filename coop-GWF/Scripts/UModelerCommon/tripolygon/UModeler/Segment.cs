using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class Segment
	{
		public List<Vertex> vertices = new List<Vertex>();

		public List<int> indices = new List<int>();

		public bool open;
	}
}
