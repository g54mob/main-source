using System;
using Poly2Tri.Triangulation.Polygon;

namespace Poly2Tri.Triangulation.Util
{
	public class PolygonGenerator
	{
		private static readonly Random _rng = new Random();

		private const double PI_2 = Math.PI * 2.0;

		public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep(double scale, int vertexCount)
		{
			double num = scale / 4.0;
			PolygonPoint[] array = new PolygonPoint[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				do
				{
					num = ((i % 250 == 0) ? (num + scale / 2.0 * (0.5 - _rng.NextDouble())) : ((i % 50 != 0) ? (num + 25.0 * scale / (double)vertexCount * (0.5 - _rng.NextDouble())) : (num + scale / 5.0 * (0.5 - _rng.NextDouble()))));
					num = ((num > scale / 2.0) ? (scale / 2.0) : num);
					num = ((num < scale / 10.0) ? (scale / 10.0) : num);
				}
				while (num < scale / 10.0 || num > scale / 2.0);
				PolygonPoint polygonPoint = new PolygonPoint(num * Math.Cos(Math.PI * 2.0 * (double)i / (double)vertexCount), num * Math.Sin(Math.PI * 2.0 * (double)i / (double)vertexCount));
				array[i] = polygonPoint;
			}
			return new Poly2Tri.Triangulation.Polygon.Polygon(array);
		}

		public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep2(double scale, int vertexCount)
		{
			double num = scale / 4.0;
			PolygonPoint[] array = new PolygonPoint[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				do
				{
					num += scale / 5.0 * (0.5 - _rng.NextDouble());
					num = ((num > scale / 2.0) ? (scale / 2.0) : num);
					num = ((num < scale / 10.0) ? (scale / 10.0) : num);
				}
				while (num < scale / 10.0 || num > scale / 2.0);
				PolygonPoint polygonPoint = new PolygonPoint(num * Math.Cos(Math.PI * 2.0 * (double)i / (double)vertexCount), num * Math.Sin(Math.PI * 2.0 * (double)i / (double)vertexCount));
				array[i] = polygonPoint;
			}
			return new Poly2Tri.Triangulation.Polygon.Polygon(array);
		}
	}
}
