using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class PointSet : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		protected Dictionary<uint, TriangulationPoint> mPointMap;

		protected double mPrecision;

		public IList<TriangulationPoint> Points
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public IList<DelaunayTriangle> Triangles { get; private set; }

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

		public virtual TriangulationMode TriangulationMode => default(TriangulationMode);

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

		public PointSet(List<TriangulationPoint> bounds)
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

		public virtual void Add(TriangulationPoint p)
		{
		}

		protected override void Add(Point2D p, int idx, bool constrainToBounds)
		{
		}

		protected bool Add(TriangulationPoint p, int idx, bool constrainToBounds)
		{
			return false;
		}

		public override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
		{
		}

		public virtual bool AddRange(List<TriangulationPoint> points)
		{
			return false;
		}

		public bool TryGetPoint(double x, double y, out TriangulationPoint p)
		{
			p = null;
			return false;
		}

		public void Insert(int idx, TriangulationPoint item)
		{
		}

		public override bool Remove(Point2D p)
		{
			return false;
		}

		public bool Remove(TriangulationPoint p)
		{
			return false;
		}

		public override void RemoveAt(int idx)
		{
		}

		public bool Contains(TriangulationPoint p)
		{
			return false;
		}

		public void CopyTo(TriangulationPoint[] array, int arrayIndex)
		{
		}

		protected bool ConstrainPointToBounds(Point2D p)
		{
			return false;
		}

		protected bool ConstrainPointToBounds(TriangulationPoint p)
		{
			return false;
		}

		public virtual void AddTriangle(DelaunayTriangle t)
		{
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
		}

		public void ClearTriangles()
		{
		}

		public virtual bool Initialize()
		{
			return false;
		}

		public virtual void Prepare(TriangulationContext tcx)
		{
		}
	}
}
