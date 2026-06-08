using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Tools
{
	public static class Interpolation
	{
		public static void InterpolateAttributes(Vertex vertex, ITriangle triangle, int n)
		{
			Vertex vertex2 = triangle.GetVertex(0);
			Vertex vertex3 = triangle.GetVertex(1);
			Vertex vertex4 = triangle.GetVertex(2);
			double num = vertex3.x - vertex2.x;
			double num2 = vertex3.y - vertex2.y;
			double num3 = vertex4.x - vertex2.x;
			double num4 = vertex4.y - vertex2.y;
			double num5 = 0.5 / (num * num4 - num3 * num2);
			double num6 = vertex.x - vertex2.x;
			double num7 = vertex.y - vertex2.y;
			double num8 = (num4 * num6 - num3 * num7) * (2.0 * num5);
			double num9 = (num * num7 - num2 * num6) * (2.0 * num5);
			for (int i = 0; i < n; i++)
			{
				vertex.attributes[i] = vertex2.attributes[i] + num8 * (vertex3.attributes[i] - vertex2.attributes[i]) + num9 * (vertex4.attributes[i] - vertex2.attributes[i]);
			}
		}

		public static void InterpolateZ(Point p, ITriangle triangle)
		{
			Vertex vertex = triangle.GetVertex(0);
			Vertex vertex2 = triangle.GetVertex(1);
			Vertex vertex3 = triangle.GetVertex(2);
			double num = vertex2.x - vertex.x;
			double num2 = vertex2.y - vertex.y;
			double num3 = vertex3.x - vertex.x;
			double num4 = vertex3.y - vertex.y;
			double num5 = 0.5 / (num * num4 - num3 * num2);
			double num6 = p.x - vertex.x;
			double num7 = p.y - vertex.y;
			double num8 = (num4 * num6 - num3 * num7) * (2.0 * num5);
			double num9 = (num * num7 - num2 * num6) * (2.0 * num5);
			p.z = vertex.z + num8 * (vertex2.z - vertex.z) + num9 * (vertex3.z - vertex.z);
		}
	}
}
