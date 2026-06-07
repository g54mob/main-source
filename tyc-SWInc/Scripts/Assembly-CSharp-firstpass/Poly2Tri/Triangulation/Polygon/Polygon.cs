using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Polygon
{
	public class Polygon : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		private readonly Dictionary<uint, TriangulationPoint> _pointMap = new Dictionary<uint, TriangulationPoint>();

		private List<DelaunayTriangle> _triangles;

		private double _precision = 3.0;

		private PolygonPoint _last;

		public IList<TriangulationPoint> Points
		{
			get
			{
				return this;
			}
		}

		public IList<DelaunayTriangle> Triangles
		{
			get
			{
				return _triangles;
			}
		}

		public TriangulationMode TriangulationMode
		{
			get
			{
				return TriangulationMode.Polygon;
			}
		}

		public string FileName { get; set; }

		public bool DisplayFlipX { get; set; }

		public bool DisplayFlipY { get; set; }

		public float DisplayRotate { get; set; }

		public double Precision
		{
			get
			{
				return _precision;
			}
			set
			{
				_precision = value;
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

		private List<Polygon> Holes { get; set; }

		private Polygon(IList<PolygonPoint> points)
		{
			if (points.Count < 3)
			{
				throw new ArgumentException("List has fewer than 3 points", "points");
			}
			AddRange(points, WindingOrderType.Unknown);
		}

		public Polygon(IEnumerable<PolygonPoint> points)
			: this((points as IList<PolygonPoint>) ?? points.ToArray())
		{
		}

		public Polygon(params PolygonPoint[] points)
			: this((IList<PolygonPoint>)points)
		{
		}

		IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
		{
			return MPoints.Cast<TriangulationPoint>().GetEnumerator();
		}

		public int IndexOf(TriangulationPoint p)
		{
			return MPoints.IndexOf(p);
		}

		public override void Add(Point2D p)
		{
			Add(p, -1, true);
		}

		public void Add(TriangulationPoint p)
		{
			Add(p, -1, true);
		}

		public void Add(PolygonPoint p)
		{
			Add(p, -1, true);
		}

		protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
		{
			TriangulationPoint triangulationPoint = p as TriangulationPoint;
			if (triangulationPoint == null || _pointMap.ContainsKey(triangulationPoint.VertexCode))
			{
				return;
			}
			_pointMap.Add(triangulationPoint.VertexCode, triangulationPoint);
			base.Add(p, idx, bCalcWindingOrderAndEpsilon);
			PolygonPoint polygonPoint = p as PolygonPoint;
			if (polygonPoint != null)
			{
				polygonPoint.Previous = _last;
				if (_last != null)
				{
					polygonPoint.Next = _last.Next;
					_last.Next = polygonPoint;
				}
				_last = polygonPoint;
			}
		}

		private void AddRange(IList<PolygonPoint> points, WindingOrderType windingOrder)
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

		public void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder)
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
			return base.Remove(p);
		}

		public void RemovePoint(PolygonPoint p)
		{
			PolygonPoint next = p.Next;
			PolygonPoint previous = p.Previous;
			previous.Next = next;
			next.Previous = previous;
			MPoints.Remove(p);
			base.BoundingBox = default(Rect2D);
			foreach (Point2D mPoint in MPoints)
			{
				base.BoundingBox = base.BoundingBox.AddPoint(mPoint);
			}
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

		public void AddHole(Polygon poly)
		{
			if (Holes == null)
			{
				Holes = new List<Polygon>();
			}
			Holes.Add(poly);
		}

		public void AddTriangle(DelaunayTriangle t)
		{
			_triangles.Add(t);
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
			_triangles.AddRange(list);
		}

		public void ClearTriangles()
		{
			if (_triangles != null)
			{
				_triangles.Clear();
			}
		}

		public bool IsPointInside(TriangulationPoint p)
		{
			return PolygonUtil.PointInPolygon2D(this, p);
		}

		public void Prepare(TriangulationContext tcx)
		{
			if (_triangles == null)
			{
				_triangles = new List<DelaunayTriangle>(MPoints.Count);
			}
			else
			{
				_triangles.Clear();
			}
			for (int i = 0; i < MPoints.Count - 1; i++)
			{
				tcx.NewConstraint(this[i], this[i + 1]);
			}
			tcx.NewConstraint(this[0], this[base.Count - 1]);
			tcx.Points.AddRange(this);
			if (Holes == null)
			{
				return;
			}
			foreach (Polygon hole in Holes)
			{
				for (int j = 0; j < hole.MPoints.Count - 1; j++)
				{
					tcx.NewConstraint(hole[j], hole[j + 1]);
				}
				tcx.NewConstraint(hole[0], hole[hole.Count - 1]);
				tcx.Points.AddRange(hole);
			}
		}
	}
}
