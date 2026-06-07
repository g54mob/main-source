using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class Contour : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		private List<Contour> mHoles;

		private ITriangulatable mParent;

		private string mName;

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

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IList<DelaunayTriangle> Triangles
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public TriangulationMode TriangulationMode => default(TriangulationMode);

		public string FileName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool DisplayFlipX
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DisplayFlipY
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float DisplayRotate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public Contour(ITriangulatable parent)
		{
		}

		public Contour(ITriangulatable parent, IList<TriangulationPoint> points, WindingOrderType windingOrder)
		{
		}

		public override string ToString()
		{
			return null;
		}

		IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
		{
			return null;
		}

		public int IndexOf(TriangulationPoint p)
		{
			return 0;
		}

		public void Add(TriangulationPoint p)
		{
		}

		protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
		{
		}

		public override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
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

		public bool Contains(TriangulationPoint p)
		{
			return false;
		}

		public void CopyTo(TriangulationPoint[] array, int arrayIndex)
		{
		}

		protected void AddHole(Contour c)
		{
		}

		public int GetNumHoles(bool parentIsHole)
		{
			return 0;
		}

		public int GetNumHoles()
		{
			return 0;
		}

		public Contour GetHole(int idx)
		{
			return null;
		}

		public void GetActualHoles(bool parentIsHole, ref List<Contour> holes)
		{
		}

		public List<Contour>.Enumerator GetHoleEnumerator()
		{
			return default(List<Contour>.Enumerator);
		}

		public void InitializeHoles(ConstrainedPointSet cps)
		{
		}

		public static void InitializeHoles(List<Contour> holes, ITriangulatable parent, ConstrainedPointSet cps)
		{
		}

		public void Prepare(TriangulationContext tcx)
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

		public Point2D FindPointInContour()
		{
			return null;
		}

		public bool IsPointInsideContour(Point2D p)
		{
			return false;
		}
	}
}
