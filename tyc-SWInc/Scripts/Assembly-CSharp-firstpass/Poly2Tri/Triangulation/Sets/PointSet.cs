using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Sets
{
	public class PointSet : Point2DList, ITriangulatable, IEnumerable<TriangulationPoint>, IEnumerable, IList<TriangulationPoint>, ICollection<TriangulationPoint>
	{
		private readonly Dictionary<uint, TriangulationPoint> _pointMap = new Dictionary<uint, TriangulationPoint>();

		private double _precision = 3.0;

		public IList<DelaunayTriangle> Triangles { get; private set; }

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

		public virtual TriangulationMode TriangulationMode
		{
			get
			{
				return TriangulationMode.Unconstrained;
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

		protected PointSet(IEnumerable<TriangulationPoint> bounds)
		{
			foreach (TriangulationPoint bound in bounds)
			{
				Add(bound, -1, false);
				base.BoundingBox = base.BoundingBox.AddPoint(bound);
			}
			base.Epsilon = CalculateEpsilon();
			base.WindingOrder = WindingOrderType.Unknown;
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
			Add(p as TriangulationPoint, -1, false);
		}

		public virtual void Add(TriangulationPoint p)
		{
			Add(p, -1, false);
		}

		protected override void Add(Point2D p, int idx, bool constrainToBounds)
		{
			Add(p as TriangulationPoint, idx, constrainToBounds);
		}

		protected bool Add(TriangulationPoint p, int idx, bool constrainToBounds)
		{
			if (p == null)
			{
				return false;
			}
			if (constrainToBounds)
			{
				ConstrainPointToBounds(p);
			}
			if (_pointMap.ContainsKey(p.VertexCode))
			{
				return true;
			}
			_pointMap.Add(p.VertexCode, p);
			if (idx < 0)
			{
				MPoints.Add(p);
			}
			else
			{
				MPoints.Insert(idx, p);
			}
			return true;
		}

		protected override void AddRange(IEnumerator<Point2D> iter, WindingOrderType windingOrder)
		{
			if (iter != null)
			{
				iter.Reset();
				while (iter.MoveNext())
				{
					Add(iter.Current);
				}
			}
		}

		public virtual bool AddRange(IEnumerable<TriangulationPoint> points)
		{
			bool flag = true;
			foreach (TriangulationPoint point in points)
			{
				flag = Add(point, -1, false) && flag;
			}
			return flag;
		}

		protected bool TryGetPoint(double x, double y, out TriangulationPoint p)
		{
			uint key = TriangulationPoint.CreateVertexCode(x, y, Precision);
			if (_pointMap.TryGetValue(key, out p))
			{
				return true;
			}
			return false;
		}

		public void Insert(int idx, TriangulationPoint item)
		{
			MPoints.Insert(idx, item);
		}

		public override bool Remove(Point2D p)
		{
			return MPoints.Remove(p);
		}

		public bool Remove(TriangulationPoint p)
		{
			return MPoints.Remove(p);
		}

		public override void RemoveAt(int idx)
		{
			if (idx >= 0 && idx < base.Count)
			{
				MPoints.RemoveAt(idx);
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

		protected bool ConstrainPointToBounds(Point2D p)
		{
			double x = p.X;
			double y = p.Y;
			p.X = Math.Max(MinX, p.X);
			p.X = Math.Min(MaxX, p.X);
			p.Y = Math.Max(MinY, p.Y);
			p.Y = Math.Min(MaxY, p.Y);
			if (p.X == x)
			{
				return p.Y != y;
			}
			return true;
		}

		protected bool ConstrainPointToBounds(TriangulationPoint p)
		{
			double x = p.X;
			double y = p.Y;
			p.X = Math.Max(MinX, p.X);
			p.X = Math.Min(MaxX, p.X);
			p.Y = Math.Max(MinY, p.Y);
			p.Y = Math.Min(MaxY, p.Y);
			if (p.X == x)
			{
				return p.Y != y;
			}
			return true;
		}

		public virtual void AddTriangle(DelaunayTriangle t)
		{
			Triangles.Add(t);
		}

		public void AddTriangles(IEnumerable<DelaunayTriangle> list)
		{
			foreach (DelaunayTriangle item in list)
			{
				AddTriangle(item);
			}
		}

		public void ClearTriangles()
		{
			Triangles.Clear();
		}

		protected virtual bool Initialize()
		{
			return true;
		}

		public virtual void Prepare(TriangulationContext tcx)
		{
			if (Triangles == null)
			{
				Triangles = new List<DelaunayTriangle>(base.Count);
			}
			else
			{
				Triangles.Clear();
			}
			tcx.Points.AddRange(this);
		}
	}
}
