using System;
using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class Point2DList : IEnumerable<Point2D>, IEnumerable, IList<Point2D>, ICollection<Point2D>
	{
		public enum WindingOrderType
		{
			CW = 0,
			CCW = 1,
			Unknown = 2,
			Default = 1
		}

		[Flags]
		public enum PolygonError : uint
		{
			None = 0u,
			NotEnoughVertices = 1u,
			NotConvex = 2u,
			NotSimple = 4u,
			AreaTooSmall = 8u,
			SidesTooCloseToParallel = 0x10u,
			TooThin = 0x20u,
			Degenerate = 0x40u,
			Unknown = 0x40000000u
		}

		public static readonly int kMaxPolygonVertices;

		public static readonly double kLinearSlop;

		public static readonly double kAngularSlop;

		protected List<Point2D> mPoints;

		protected Rect2D mBoundingBox;

		protected WindingOrderType mWindingOrder;

		protected double mEpsilon;

		public Rect2D BoundingBox => null;

		public WindingOrderType WindingOrder
		{
			get
			{
				return default(WindingOrderType);
			}
			set
			{
			}
		}

		public double Epsilon => 0.0;

		public Point2D this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		public virtual bool IsReadOnly => false;

		public Point2DList()
		{
		}

		public Point2DList(int capacity)
		{
		}

		public Point2DList(IList<Point2D> l)
		{
		}

		public Point2DList(Point2DList l)
		{
		}

		public override string ToString()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		IEnumerator<Point2D> IEnumerable<Point2D>.GetEnumerator()
		{
			return null;
		}

		public void Clear()
		{
		}

		public int IndexOf(Point2D p)
		{
			return 0;
		}

		public virtual void Add(Point2D p)
		{
		}

		protected virtual void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
		{
		}

		public virtual void AddRange(Point2DList l)
		{
		}

		public virtual void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
		{
		}

		public virtual void Insert(int idx, Point2D item)
		{
		}

		public virtual bool Remove(Point2D p)
		{
			return false;
		}

		public virtual void RemoveAt(int idx)
		{
		}

		public virtual void RemoveRange(int idxStart, int count)
		{
		}

		public bool Contains(Point2D p)
		{
			return false;
		}

		public void CopyTo(Point2D[] array, int arrayIndex)
		{
		}

		public void CalculateBounds()
		{
		}

		public double CalculateEpsilon()
		{
			return 0.0;
		}

		public WindingOrderType CalculateWindingOrder()
		{
			return default(WindingOrderType);
		}

		public int NextIndex(int index)
		{
			return 0;
		}

		public int PreviousIndex(int index)
		{
			return 0;
		}

		public double GetSignedArea()
		{
			return 0.0;
		}

		public double GetArea()
		{
			return 0.0;
		}

		public Point2D GetCentroid()
		{
			return null;
		}

		public void Translate(Point2D vector)
		{
		}

		public void Scale(Point2D value)
		{
		}

		public void Rotate(double radians)
		{
		}

		public bool IsDegenerate()
		{
			return false;
		}

		public bool IsConvex()
		{
			return false;
		}

		public bool IsSimple()
		{
			return false;
		}

		public PolygonError CheckPolygon()
		{
			return default(PolygonError);
		}

		public static string GetErrorString(PolygonError error)
		{
			return null;
		}

		public void RemoveDuplicateNeighborPoints()
		{
		}

		public void Simplify()
		{
		}

		public void Simplify(double bias)
		{
		}

		public void MergeParallelEdges(double tolerance)
		{
		}

		public void ProjectToAxis(Point2D axis, out double min, out double max)
		{
			min = default(double);
			max = default(double);
		}
	}
}
