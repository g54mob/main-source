using System;
using System.Collections.Generic;

namespace Poly2Tri.Triangulation.Util
{
	public class PointGenerator
	{
		private static readonly Random _rng = new Random();

		public static List<TriangulationPoint> UniformDistribution(int n, double scale)
		{
			List<TriangulationPoint> list = new List<TriangulationPoint>();
			for (int i = 0; i < n; i++)
			{
				list.Add(new TriangulationPoint(scale * (0.5 - _rng.NextDouble()), scale * (0.5 - _rng.NextDouble())));
			}
			return list;
		}

		public static List<TriangulationPoint> UniformGrid(int n, double scale)
		{
			double num = scale / (double)n;
			double num2 = 0.5 * scale;
			List<TriangulationPoint> list = new List<TriangulationPoint>();
			for (int i = 0; i < n + 1; i++)
			{
				double x = num2 - (double)i * num;
				for (int j = 0; j < n + 1; j++)
				{
					list.Add(new TriangulationPoint(x, num2 - (double)j * num));
				}
			}
			return list;
		}
	}
}
