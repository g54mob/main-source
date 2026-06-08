using System;
using System.Collections.Generic;
using Jobberwocky.GeometryAlgorithms.Source.Core;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D
{
	public class Hull2DAlgorithm
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Comparison<Vertex> _003C_003E9__8_0;

			internal int _003CSortByX_003Eb__8_0(Vertex p1, Vertex p2)
			{
				if (p1.Position.x == p2.Position.x)
				{
					return p1.Position.y.CompareTo(p2.Position.y);
				}
				return p1.Position.x.CompareTo(p2.Position.x);
			}
		}

		private readonly double constAngleCos = Math.Cos(Math.PI / 2.0);

		private double Cross(Vertex o, Vertex a, Vertex b)
		{
			return (a.Position.x - o.Position.x) * (b.Position.y - o.Position.y) - (a.Position.y - o.Position.y) * (b.Position.x - o.Position.x);
		}

		private Vertex[] UpperTangent(Vertex[] pointSet)
		{
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < pointSet.Length; i++)
			{
				while (list.Count >= 2 && Cross(list[list.Count - 2], list[list.Count - 1], pointSet[i]) <= 0.0)
				{
					list.RemoveAt(list.Count - 1);
				}
				list.Add(pointSet[i]);
			}
			list.RemoveAt(list.Count - 1);
			return list.ToArray();
		}

		private Vertex[] LowerTangent(ref Vertex[] pointSet)
		{
			Vertex[] array = new Vertex[pointSet.Length];
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < pointSet.Length; i++)
			{
				array[i] = pointSet[pointSet.Length - 1 - i];
				while (list.Count >= 2 && Cross(list[list.Count - 2], list[list.Count - 1], array[i]) <= 0.0)
				{
					list.RemoveAt(list.Count - 1);
				}
				list.Add(array[i]);
			}
			list.RemoveAt(list.Count - 1);
			pointSet = array;
			return list.ToArray();
		}

		private List<Vertex> Convex(ref Vertex[] pointSet)
		{
			Vertex[] array = UpperTangent(pointSet);
			Vertex[] array2 = LowerTangent(ref pointSet);
			List<Vertex> list = new List<Vertex>(array2.Length + array.Length + 1);
			list.AddRange(array2);
			list.AddRange(array);
			list.Add(pointSet[0]);
			return list;
		}

		private bool Ccw(Vertex p1, Vertex p2, Vertex p3)
		{
			float num = (p3.Position.y - p1.Position.y) * (p2.Position.x - p1.Position.x) - (p2.Position.y - p1.Position.y) * (p3.Position.x - p1.Position.x);
			if (!(num > 0f))
			{
				if (!(num < 0f))
				{
					return true;
				}
				return false;
			}
			return true;
		}

		private bool Intersect(Vertex seg1P1, Vertex seg1P2, Vertex seg2P1, Vertex seg2P2)
		{
			if (Ccw(seg1P1, seg2P1, seg2P2) != Ccw(seg1P2, seg2P1, seg2P2))
			{
				return Ccw(seg1P1, seg1P2, seg2P1) != Ccw(seg1P1, seg1P2, seg2P2);
			}
			return false;
		}

		private void SortByX(Vertex[] pointSet)
		{
			Array.Sort(pointSet, (Vertex p1, Vertex p2) => (p1.Position.x == p2.Position.x) ? p1.Position.y.CompareTo(p2.Position.y) : p1.Position.x.CompareTo(p2.Position.x));
		}

		private double SqLength(Vertex a, Vertex b)
		{
			return (b.Position.x - a.Position.x) * (b.Position.x - a.Position.x) + (b.Position.y - a.Position.y) * (b.Position.y - a.Position.y);
		}

		private double Cos(Vertex o, Vertex a, Vertex b)
		{
			float num = a.Position.x - o.Position.x;
			float num2 = a.Position.y - o.Position.y;
			float num3 = b.Position.x - o.Position.x;
			float num4 = b.Position.y - o.Position.y;
			double num5 = SqLength(o, a);
			double num6 = SqLength(o, b);
			return (double)(num * num3 + num2 * num4) / Math.Sqrt(num5 * num6);
		}

		private bool Intersect(Vertex seg1P1, Vertex seg1P2, List<Vertex> pointSet)
		{
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				Vertex vertex = pointSet[i];
				Vertex vertex2 = pointSet[i + 1];
				if (!seg1P1.Equals(vertex) && !seg1P1.Equals(vertex2) && Intersect(seg1P1, seg1P2, vertex, vertex2))
				{
					return true;
				}
			}
			return false;
		}

		private double[] OccupiedArea(Vertex[] pointSet)
		{
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			double num3 = double.MinValue;
			double num4 = double.MinValue;
			for (int num5 = pointSet.Length - 1; num5 >= 0; num5--)
			{
				if ((double)pointSet[num5].Position.x < num)
				{
					num = pointSet[num5].Position.x;
				}
				if ((double)pointSet[num5].Position.y < num2)
				{
					num2 = pointSet[num5].Position.y;
				}
				if ((double)pointSet[num5].Position.x > num3)
				{
					num3 = pointSet[num5].Position.x;
				}
				if ((double)pointSet[num5].Position.y > num4)
				{
					num4 = pointSet[num5].Position.y;
				}
			}
			return new double[2]
			{
				num3 - num,
				num4 - num2
			};
		}

		private double[] BboxAround(Vertex[] edge)
		{
			return new double[4]
			{
				Math.Min(edge[0].Position.x, edge[1].Position.x),
				Math.Min(edge[0].Position.y, edge[1].Position.y),
				Math.Max(edge[0].Position.x, edge[1].Position.x),
				Math.Max(edge[0].Position.y, edge[1].Position.y)
			};
		}

		private Vertex MidPoint(Vertex[] edge, List<Vertex> innerPoints, List<Vertex> hullPoints)
		{
			double num = constAngleCos;
			double num2 = constAngleCos;
			Vertex result = null;
			Vertex vertex = null;
			for (int i = 0; i < innerPoints.Count; i++)
			{
				vertex = innerPoints[i];
				double num3 = Cos(edge[0], edge[1], vertex);
				double num4 = Cos(edge[1], edge[0], vertex);
				if (num3 > num && num4 > num2 && !Intersect(edge[0], vertex, hullPoints) && !Intersect(edge[1], vertex, hullPoints))
				{
					num = num3;
					num2 = num4;
					result = vertex;
				}
			}
			return result;
		}

		private Vertex[] Concave(List<Vertex> convex, double maxSqEdgeLen, double[] maxSearchArea, Grid grid)
		{
			double[] array = new double[4];
			Vertex[] array2 = new Vertex[2];
			Dictionary<EdgeKey, bool> dictionary = new Dictionary<EdgeKey, bool>();
			bool flag;
			EdgeKey key = default(EdgeKey);
			do
			{
				flag = false;
				for (int i = 0; i < convex.Count - 1; i++)
				{
					Vertex vertex = null;
					array2[0] = convex[i];
					array2[1] = convex[i + 1];
					key.point1 = array2[0].Id;
					key.point2 = array2[1].Id;
					if (!(SqLength(array2[0], array2[1]) < maxSqEdgeLen) && !dictionary.TryGetValue(key, out var _))
					{
						int num = 0;
						array = BboxAround(array2);
						double num2;
						double num3;
						do
						{
							grid.ExtendBbox(array, num);
							num2 = array[2] - array[0];
							num3 = array[3] - array[1];
							vertex = MidPoint(array2, grid.RangePoints(array), convex);
							num++;
						}
						while (vertex == null && (maxSearchArea[0] > num2 || maxSearchArea[1] > num3));
						if (num2 >= maxSearchArea[0] && num3 >= maxSearchArea[1])
						{
							dictionary[key] = true;
						}
						if (vertex != null)
						{
							convex.Insert(i + 1, vertex);
							grid.RemovePoint(vertex);
							flag = true;
						}
					}
				}
			}
			while (flag);
			return convex.ToArray();
		}

		public Vertex[] GenerateHull(Vertex[] points, double concavity)
		{
			if (points.Length < 4)
			{
				return points;
			}
			SortByX(points);
			double[] array = OccupiedArea(points);
			double[] maxSearchArea = new double[2]
			{
				array[0] * 0.6,
				array[1] * 0.6
			};
			List<Vertex> list = Convex(ref points);
			double maxSqEdgeLen = concavity * concavity;
			int cellSize = (int)Math.Ceiling(1.0 / ((double)points.Length / (array[0] * array[1])));
			Grid grid = new Grid(points, cellSize);
			for (int i = 0; i < list.Count; i++)
			{
				grid.RemovePoint(list[i]);
			}
			return Concave(list, maxSqEdgeLen, maxSearchArea, grid);
		}
	}
}
