using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Sets;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon
{
	public class Contour : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		private readonly List<Contour> _holes = new List<Contour>();

		private ITriangulatable _parent;

		public new TriangulationPoint this[int index]
		{
			get
			{
				return MPoints[index] as TriangulationPoint;
			}
			set
			{
				MPoints[index] = value;
			}
		}

		public IList<DelaunayTriangle> Triangles
		{
			get
			{
				throw new NotImplementedException("PolyHole.Triangles should never get called");
			}
		}

		public TriangulationMode TriangulationMode
		{
			get
			{
				return _parent.TriangulationMode;
			}
		}

		public bool DisplayFlipX
		{
			get
			{
				return _parent.DisplayFlipX;
			}
			set
			{
			}
		}

		public bool DisplayFlipY
		{
			get
			{
				return _parent.DisplayFlipY;
			}
			set
			{
			}
		}

		public float DisplayRotate
		{
			get
			{
				return _parent.DisplayRotate;
			}
			set
			{
			}
		}

		public double Precision
		{
			get
			{
				return _parent.Precision;
			}
			set
			{
			}
		}

		public double MinX
		{
			get
			{
				return base.BoundingBox.MinX;
			}
		}

		public double MaxX
		{
			get
			{
				return base.BoundingBox.MaxX;
			}
		}

		public double MinY
		{
			get
			{
				return base.BoundingBox.MinY;
			}
		}

		public double MaxY
		{
			get
			{
				return base.BoundingBox.MaxY;
			}
		}

		public Rect2D Bounds
		{
			get
			{
				return base.BoundingBox;
			}
		}

		public Contour(ITriangulatable parent)
		{
			_parent = parent;
		}

		public Contour(ITriangulatable parent, IList<TriangulationPoint> points, WindingOrderType windingOrder)
		{
			_parent = parent;
			AddRange(points, windingOrder);
		}

		IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
		{
			return MPoints.Cast<TriangulationPoint>().GetEnumerator();
		}

		public int IndexOf(TriangulationPoint p)
		{
			return MPoints.IndexOf(p);
		}

		public void Add(TriangulationPoint p)
		{
			Add(p, -1, true);
		}

		protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
		{
			TriangulationPoint triangulationPoint = ((!(p is TriangulationPoint)) ? new TriangulationPoint(p.X, p.Y) : (p as TriangulationPoint));
			if (idx < 0)
			{
				MPoints.Add(triangulationPoint);
			}
			else
			{
				MPoints.Insert(idx, triangulationPoint);
			}
			base.BoundingBox = base.BoundingBox.AddPoint(triangulationPoint);
			if (bCalcWindingOrderAndEpsilon)
			{
				if (base.WindingOrder == WindingOrderType.Unknown)
				{
					base.WindingOrder = CalculateWindingOrder();
				}
				base.Epsilon = CalculateEpsilon();
			}
		}

		protected override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
		{
			if (iter == null)
			{
				return;
			}
			if (base.WindingOrder == WindingOrderType.Unknown && base.Count == 0)
			{
				base.WindingOrder = windingOrder;
			}
			bool flag = base.WindingOrder != WindingOrderType.Unknown && windingOrder != WindingOrderType.Unknown && base.WindingOrder != windingOrder;
			bool flag2 = true;
			int count = MPoints.Count;
			iter.Reset();
			while (iter.MoveNext())
			{
				TriangulationPoint item = ((!(iter.Current is TriangulationPoint)) ? new TriangulationPoint(iter.Current.X, iter.Current.Y) : (iter.Current as TriangulationPoint));
				if (!flag2)
				{
					flag2 = true;
					MPoints.Add(item);
				}
				else if (flag)
				{
					MPoints.Insert(count, item);
				}
				else
				{
					MPoints.Add(item);
				}
				base.BoundingBox = base.BoundingBox.AddPoint(iter.Current);
			}
			if (base.WindingOrder == WindingOrderType.Unknown && windingOrder == WindingOrderType.Unknown)
			{
				base.WindingOrder = CalculateWindingOrder();
			}
			base.Epsilon = CalculateEpsilon();
		}

		private void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder)
		{
			if (points == null || points.Count < 1)
			{
				return;
			}
			if (base.WindingOrder == WindingOrderType.Unknown && base.Count == 0)
			{
				base.WindingOrder = windingOrder;
			}
			int count = points.Count;
			bool flag = base.WindingOrder != WindingOrderType.Unknown && windingOrder != WindingOrderType.Unknown && base.WindingOrder != windingOrder;
			for (int i = 0; i < count; i++)
			{
				int index = i;
				if (flag)
				{
					index = points.Count - i - 1;
				}
				Add(points[index], -1, false);
			}
			if (base.WindingOrder == WindingOrderType.Unknown)
			{
				base.WindingOrder = CalculateWindingOrder();
			}
			base.Epsilon = CalculateEpsilon();
		}

		public void Insert(int idx, TriangulationPoint p)
		{
			Add(p, idx, true);
		}

		public bool Remove(TriangulationPoint p)
		{
			return Remove((Point2D)p);
		}

		public bool Contains(TriangulationPoint p)
		{
			return MPoints.Contains(p);
		}

		public void CopyTo(TriangulationPoint[] array, int arrayIndex)
		{
			int num = Math.Min(base.Count, array.Length - arrayIndex);
			for (int i = 0; i < num; i++)
			{
				array[arrayIndex + i] = MPoints[i] as TriangulationPoint;
			}
		}

		private void AddHole(Contour c)
		{
			c._parent = this;
			_holes.Add(c);
		}

		public int GetNumHoles(bool parentIsHole)
		{
			return ((!parentIsHole) ? 1 : 0) + _holes.Sum((Contour c) => c.GetNumHoles(!parentIsHole));
		}

		private int GetNumHoles()
		{
			return _holes.Count;
		}

		private Contour GetHole(int idx)
		{
			if (idx < 0 || idx >= _holes.Count)
			{
				return null;
			}
			return _holes[idx];
		}

		public void GetActualHoles(bool parentIsHole, ref List<Contour> holes)
		{
			if (parentIsHole)
			{
				holes.Add(this);
			}
			foreach (Contour hole in _holes)
			{
				hole.GetActualHoles(!parentIsHole, ref holes);
			}
		}

		public List<Contour>.Enumerator GetHoleEnumerator()
		{
			return _holes.GetEnumerator();
		}

		public void InitializeHoles(ConstrainedPointSet cps)
		{
			InitializeHoles(_holes, this, cps);
			foreach (Contour hole in _holes)
			{
				hole.InitializeHoles(cps);
			}
		}

		public static void InitializeHoles(List<Contour> holes, ITriangulatable parent, ConstrainedPointSet cps)
		{
			int num = holes.Count;
			int i;
			for (i = 0; i < num; i++)
			{
				int num2 = i + 1;
				while (num2 < num)
				{
					if (PolygonUtil.PolygonsAreSame2D(holes[i], holes[num2]))
					{
						holes.RemoveAt(num2);
						num--;
					}
					else
					{
						num2++;
					}
				}
			}
			i = 0;
			while (i < num)
			{
				bool flag = true;
				int num3 = i + 1;
				while (num3 < num)
				{
					if (PolygonUtil.PolygonContainsPolygon(holes[i], holes[i].Bounds, holes[num3], holes[num3].Bounds, false))
					{
						holes[i].AddHole(holes[num3]);
						holes.RemoveAt(num3);
						num--;
						continue;
					}
					if (PolygonUtil.PolygonContainsPolygon(holes[num3], holes[num3].Bounds, holes[i], holes[i].Bounds, false))
					{
						holes[num3].AddHole(holes[i]);
						holes.RemoveAt(i);
						num--;
						flag = false;
						break;
					}
					if (PolygonUtil.PolygonsIntersect2D(holes[i], holes[i].Bounds, holes[num3], holes[num3].Bounds))
					{
						PolygonOperationContext polygonOperationContext = new PolygonOperationContext();
						if (!polygonOperationContext.Init(PolygonUtil.PolyOperation.Union | PolygonUtil.PolyOperation.Intersect, holes[i], holes[num3]))
						{
							if (polygonOperationContext.Error == PolygonUtil.PolyUnionError.Poly1InsidePoly2)
							{
								holes[num3].AddHole(holes[i]);
								holes.RemoveAt(i);
								num--;
								flag = false;
								break;
							}
							throw new Exception("PolygonOperationContext.Init had an error during initialization");
						}
						if (PolygonUtil.PolygonOperation(polygonOperationContext) != PolygonUtil.PolyUnionError.None)
						{
							throw new Exception("PolygonOperation had an error!");
						}
						Point2DList union = polygonOperationContext.Union;
						Point2DList intersect = polygonOperationContext.Intersect;
						Contour contour = new Contour(parent);
						contour.AddRange(union);
						contour.WindingOrder = WindingOrderType.AntiClockwise;
						int numHoles = holes[i].GetNumHoles();
						for (int j = 0; j < numHoles; j++)
						{
							contour.AddHole(holes[i].GetHole(j));
						}
						numHoles = holes[num3].GetNumHoles();
						for (int k = 0; k < numHoles; k++)
						{
							contour.AddHole(holes[num3].GetHole(k));
						}
						Contour contour2 = new Contour(contour);
						contour2.AddRange(intersect);
						contour2.WindingOrder = WindingOrderType.AntiClockwise;
						contour.AddHole(contour2);
						holes[i] = contour;
						holes.RemoveAt(num3);
						num--;
						num3 = i + 1;
					}
					else
					{
						num3++;
					}
				}
				if (flag)
				{
					i++;
				}
			}
			num = holes.Count;
			for (i = 0; i < num; i++)
			{
				int count = holes[i].Count;
				for (int l = 0; l < count; l++)
				{
					int index = holes[i].NextIndex(l);
					uint constraintCode = TriangulationConstraint.CalculateContraintCode(holes[i][l], holes[i][index]);
					TriangulationConstraint tc;
					if (!cps.TryGetConstraint(constraintCode, out tc))
					{
						tc = new TriangulationConstraint(holes[i][l], holes[i][index]);
						cps.AddConstraint(tc);
					}
					if (holes[i][l].VertexCode == tc.P.VertexCode)
					{
						holes[i][l] = tc.P;
					}
					else if (holes[i][index].VertexCode == tc.P.VertexCode)
					{
						holes[i][index] = tc.P;
					}
					if (holes[i][l].VertexCode == tc.Q.VertexCode)
					{
						holes[i][l] = tc.Q;
					}
					else if (holes[i][index].VertexCode == tc.Q.VertexCode)
					{
						holes[i][index] = tc.Q;
					}
				}
			}
		}

		public void Prepare(TriangulationContext tcx)
		{
			throw new NotImplementedException("PolyHole.Prepare should never get called");
		}

		public void AddTriangle(DelaunayTriangle t)
		{
			throw new NotImplementedException("PolyHole.AddTriangle should never get called");
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
			throw new NotImplementedException("PolyHole.AddTriangles should never get called");
		}

		public void ClearTriangles()
		{
			throw new NotImplementedException("PolyHole.ClearTriangles should never get called");
		}

		public Point2D FindPointInContour()
		{
			if (base.Count < 3)
			{
				return null;
			}
			Point2D centroid = GetCentroid();
			if (IsPointInsideContour(centroid))
			{
				return centroid;
			}
			Random random = new Random();
			do
			{
				centroid.X = random.NextDouble() * (MaxX - MinX) + MinX;
				centroid.Y = random.NextDouble() * (MaxY - MinY) + MinY;
			}
			while (!IsPointInsideContour(centroid));
			return centroid;
		}

		private bool IsPointInsideContour(Point2D p)
		{
			if (PolygonUtil.PointInPolygon2D(this, p))
			{
				return _holes.All((Contour c) => !c.IsPointInsideContour(p));
			}
			return false;
		}
	}
}
