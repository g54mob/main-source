using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class Polygon : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		protected Dictionary<uint, TriangulationPoint> mPointMap;

		protected List<DelaunayTriangle> mTriangles;

		private double mPrecision;

		protected List<Polygon> mHoles;

		protected List<TriangulationPoint> mSteinerPoints;

		protected PolygonPoint _last;

		public IList<TriangulationPoint> Points => null;

		public IList<DelaunayTriangle> Triangles => null;

		public TriangulationMode TriangulationMode => default(TriangulationMode);

		public string FileName { get; set; }

		public bool DisplayFlipX { get; set; }

		public bool DisplayFlipY { get; set; }

		public float DisplayRotate { get; set; }

		public double Precision
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double MinX => 0.0;

		public double MaxX => 0.0;

		public double MinY => 0.0;

		public double MaxY => 0.0;

		public Rect2D Bounds => null;

		public new TriangulationPoint this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IList<Polygon> Holes => null;

		public Polygon(IList<PolygonPoint> points)
		{
		}

		public Polygon(IEnumerable<PolygonPoint> points)
		{
		}

		public Polygon(params PolygonPoint[] points)
		{
		}

		IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
		{
			return null;
		}

		public int IndexOf(TriangulationPoint p)
		{
			return 0;
		}

		public override void Add(Point2D p)
		{
		}

		public void Add(TriangulationPoint p)
		{
		}

		public void Add(PolygonPoint p)
		{
		}

		protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
		{
		}

		public void AddRange(IList<PolygonPoint> points, WindingOrderType windingOrder)
		{
		}

		public void AddRange(IList<TriangulationPoint> points, WindingOrderType windingOrder)
		{
		}

		public void Insert(int idx, TriangulationPoint p)
		{
		}

		public bool Remove(TriangulationPoint p)
		{
			return false;
		}

		public void RemovePoint(PolygonPoint p)
		{
		}

		public bool Contains(TriangulationPoint p)
		{
			return false;
		}

		public void CopyTo(TriangulationPoint[] array, int arrayIndex)
		{
		}

		public void AddSteinerPoint(TriangulationPoint point)
		{
		}

		public void AddSteinerPoints(List<TriangulationPoint> points)
		{
		}

		public void ClearSteinerPoints()
		{
		}

		public void AddHole(Polygon poly)
		{
		}

		public void AddTriangle(DelaunayTriangle t)
		{
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
		}

		public void ClearTriangles()
		{
		}

		public bool IsPointInside(TriangulationPoint p)
		{
			return false;
		}

		public void Prepare(TriangulationContext tcx)
		{
		}
	}
}
