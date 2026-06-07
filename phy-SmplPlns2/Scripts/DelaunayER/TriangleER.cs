public class TriangleER
{
	public PointER Vertex1;

	public PointER Vertex2;

	public PointER Vertex3;

	public TriangleER(PointER vertex1, PointER vertex2, PointER vertex3)
	{
		Vertex1 = vertex1;
		Vertex2 = vertex2;
		Vertex3 = vertex3;
	}

	public double ContainsInCircumcircle(PointER point)
	{
		double num = Vertex1.x - point.x;
		double num2 = Vertex1.y - point.y;
		double num3 = Vertex2.x - point.x;
		double num4 = Vertex2.y - point.y;
		double num5 = Vertex3.x - point.x;
		double num6 = Vertex3.y - point.y;
		double num7 = num * num4 - num3 * num2;
		double num8 = num3 * num6 - num5 * num4;
		double num9 = num5 * num2 - num * num6;
		double num10 = num * num + num2 * num2;
		double num11 = num3 * num3 + num4 * num4;
		double num12 = num5 * num5 + num6 * num6;
		return num10 * num8 + num11 * num9 + num12 * num7;
	}

	public bool SharesVertexWith(TriangleER triangle)
	{
		if (Vertex1.x == triangle.Vertex1.x && Vertex1.y == triangle.Vertex1.y)
		{
			return true;
		}
		if (Vertex1.x == triangle.Vertex2.x && Vertex1.y == triangle.Vertex2.y)
		{
			return true;
		}
		if (Vertex1.x == triangle.Vertex3.x && Vertex1.y == triangle.Vertex3.y)
		{
			return true;
		}
		if (Vertex2.x == triangle.Vertex1.x && Vertex2.y == triangle.Vertex1.y)
		{
			return true;
		}
		if (Vertex2.x == triangle.Vertex2.x && Vertex2.y == triangle.Vertex2.y)
		{
			return true;
		}
		if (Vertex2.x == triangle.Vertex3.x && Vertex2.y == triangle.Vertex3.y)
		{
			return true;
		}
		if (Vertex3.x == triangle.Vertex1.x && Vertex3.y == triangle.Vertex1.y)
		{
			return true;
		}
		if (Vertex3.x == triangle.Vertex2.x && Vertex3.y == triangle.Vertex2.y)
		{
			return true;
		}
		if (Vertex3.x == triangle.Vertex3.x && Vertex3.y == triangle.Vertex3.y)
		{
			return true;
		}
		return false;
	}
}
