using System.Collections.Generic;
using System.Linq;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Polygon;
using Poly2Tri.Utility;

namespace Poly2Tri.Triangulation.Sets
{
	public class ConstrainedPointSet : PointSet
	{
		private readonly Dictionary<uint, TriangulationConstraint> _constraintMap = new Dictionary<uint, TriangulationConstraint>();

		private readonly List<Contour> _holes = new List<Contour>();

		public override TriangulationMode TriangulationMode
		{
			get
			{
				return TriangulationMode.Constrained;
			}
		}

		public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds)
			: base(bounds)
		{
			AddBoundaryConstraints();
		}

		public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds, IEnumerable<TriangulationConstraint> constraints)
			: base(bounds)
		{
			AddBoundaryConstraints();
			AddConstraints(constraints);
		}

		public ConstrainedPointSet(IList<TriangulationPoint> bounds, ICollection<int> indices)
			: base(bounds)
		{
			AddBoundaryConstraints();
			List<TriangulationConstraint> list = new List<TriangulationConstraint>();
			for (int i = 0; i < indices.Count; i += 2)
			{
				TriangulationConstraint item = new TriangulationConstraint(bounds[i], bounds[i + 1]);
				list.Add(item);
			}
			AddConstraints(list);
		}

		private void AddBoundaryConstraints()
		{
			TriangulationPoint p;
			if (!TryGetPoint(base.MinX, base.MinY, out p))
			{
				p = new TriangulationPoint(base.MinX, base.MinY);
				Add(p);
			}
			TriangulationPoint p2;
			if (!TryGetPoint(base.MaxX, base.MinY, out p2))
			{
				p2 = new TriangulationPoint(base.MaxX, base.MinY);
				Add(p2);
			}
			TriangulationPoint p3;
			if (!TryGetPoint(base.MaxX, base.MaxY, out p3))
			{
				p3 = new TriangulationPoint(base.MaxX, base.MaxY);
				Add(p3);
			}
			TriangulationPoint p4;
			if (!TryGetPoint(base.MinX, base.MaxY, out p4))
			{
				p4 = new TriangulationPoint(base.MinX, base.MaxY);
				Add(p4);
			}
			TriangulationConstraint tc = new TriangulationConstraint(p, p2);
			AddConstraint(tc);
			TriangulationConstraint tc2 = new TriangulationConstraint(p2, p3);
			AddConstraint(tc2);
			TriangulationConstraint tc3 = new TriangulationConstraint(p3, p4);
			AddConstraint(tc3);
			TriangulationConstraint tc4 = new TriangulationConstraint(p4, p);
			AddConstraint(tc4);
		}

		public override void Add(Point2D p)
		{
			Add(p as TriangulationPoint, -1, true);
		}

		public override void Add(TriangulationPoint p)
		{
			Add(p, -1, true);
		}

		public override bool AddRange(IEnumerable<TriangulationPoint> points)
		{
			bool flag = true;
			foreach (TriangulationPoint point in points)
			{
				flag = Add(point, -1, true) && flag;
			}
			return flag;
		}

		public bool AddHole(List<TriangulationPoint> points)
		{
			if (points == null)
			{
				return false;
			}
			List<Contour> list = new List<Contour>();
			int num = 0;
			Contour item = new Contour(this, points, WindingOrderType.Unknown);
			list.Add(item);
			if (MPoints.Count > 1)
			{
				int count = list[num].Count;
				for (int i = 0; i < count; i++)
				{
					ConstrainPointToBounds(list[num][i]);
				}
			}
			while (num < list.Count)
			{
				list[num].RemoveDuplicateNeighborPoints();
				list[num].WindingOrder = WindingOrderType.AntiClockwise;
				bool flag = true;
				PolygonError polygonError = list[num].CheckPolygon();
				while (flag && polygonError != PolygonError.None)
				{
					if ((polygonError & PolygonError.NotEnoughVertices) == PolygonError.NotEnoughVertices)
					{
						flag = false;
					}
					else if ((polygonError & PolygonError.NotSimple) == PolygonError.NotSimple)
					{
						IEnumerable<Point2DList> enumerable = PolygonUtil.SplitComplexPolygon(list[num], list[num].Epsilon);
						list.RemoveAt(num);
						foreach (Point2DList item3 in enumerable)
						{
							Contour contour = new Contour(this);
							contour.AddRange(item3);
							list.Add(contour);
						}
						polygonError = list[num].CheckPolygon();
					}
					else if ((polygonError & PolygonError.Degenerate) == PolygonError.Degenerate)
					{
						list[num].Simplify(base.Epsilon);
						polygonError = list[num].CheckPolygon();
					}
					else if ((polygonError & PolygonError.AreaTooSmall) == PolygonError.AreaTooSmall || (polygonError & PolygonError.SidesTooCloseToParallel) == PolygonError.SidesTooCloseToParallel || (polygonError & PolygonError.TooThin) == PolygonError.TooThin || (polygonError & PolygonError.Unknown) == PolygonError.Unknown)
					{
						flag = false;
					}
				}
				if (!flag && list[num].Count != 2)
				{
					list.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			bool result = true;
			num = 0;
			while (num < list.Count)
			{
				int count2 = list[num].Count;
				if (count2 < 2)
				{
					num++;
					result = false;
					continue;
				}
				if (count2 == 2)
				{
					uint key = TriangulationConstraint.CalculateContraintCode(list[num][0], list[num][1]);
					TriangulationConstraint value;
					if (!_constraintMap.TryGetValue(key, out value))
					{
						value = new TriangulationConstraint(list[num][0], list[num][1]);
						AddConstraint(value);
					}
				}
				else
				{
					Contour item2 = new Contour(this, list[num], WindingOrderType.Unknown)
					{
						WindingOrder = WindingOrderType.AntiClockwise
					};
					_holes.Add(item2);
				}
				num++;
			}
			return result;
		}

		private void AddConstraints(IEnumerable<TriangulationConstraint> constraints)
		{
			if (constraints == null)
			{
				return;
			}
			foreach (TriangulationConstraint constraint in constraints)
			{
				if (ConstrainPointToBounds(constraint.P) || ConstrainPointToBounds(constraint.Q))
				{
					constraint.CalculateContraintCode();
				}
				TriangulationConstraint value;
				if (!_constraintMap.TryGetValue(constraint.ConstraintCode, out value))
				{
					value = constraint;
					AddConstraint(value);
				}
			}
		}

		public void AddConstraint(TriangulationConstraint tc)
		{
			if (tc != null && tc.P != null && tc.Q != null && !_constraintMap.ContainsKey(tc.ConstraintCode))
			{
				TriangulationPoint p;
				if (TryGetPoint(tc.P.X, tc.P.Y, out p))
				{
					tc.P = p;
				}
				else
				{
					Add(tc.P);
				}
				if (TryGetPoint(tc.Q.X, tc.Q.Y, out p))
				{
					tc.Q = p;
				}
				else
				{
					Add(tc.Q);
				}
				_constraintMap.Add(tc.ConstraintCode, tc);
			}
		}

		public bool TryGetConstraint(uint constraintCode, out TriangulationConstraint tc)
		{
			return _constraintMap.TryGetValue(constraintCode, out tc);
		}

		public int GetNumConstraints()
		{
			return _constraintMap.Count;
		}

		public Dictionary<uint, TriangulationConstraint>.Enumerator GetConstraintEnumerator()
		{
			return _constraintMap.GetEnumerator();
		}

		public int GetNumHoles()
		{
			return _holes.Sum((Contour c) => c.GetNumHoles(false));
		}

		public Contour GetHole(int idx)
		{
			if (idx < 0 || idx >= _holes.Count)
			{
				return null;
			}
			return _holes[idx];
		}

		public int GetActualHoles(out List<Contour> holes)
		{
			holes = new List<Contour>();
			foreach (Contour hole in _holes)
			{
				hole.GetActualHoles(false, ref holes);
			}
			return holes.Count;
		}

		private void InitializeHoles()
		{
			Contour.InitializeHoles(_holes, this, this);
			foreach (Contour hole in _holes)
			{
				hole.InitializeHoles(this);
			}
		}

		protected override bool Initialize()
		{
			InitializeHoles();
			return base.Initialize();
		}

		public override void Prepare(TriangulationContext tcx)
		{
			if (Initialize())
			{
				base.Prepare(tcx);
				Dictionary<uint, TriangulationConstraint>.Enumerator enumerator = _constraintMap.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TriangulationConstraint value = enumerator.Current.Value;
					tcx.NewConstraint(value.P, value.Q);
				}
			}
		}

		public override void AddTriangle(DelaunayTriangle t)
		{
			base.Triangles.Add(t);
		}
	}
}
