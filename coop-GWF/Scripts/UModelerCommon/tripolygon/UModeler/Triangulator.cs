using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Triangulator
	{
		private enum EPointType
		{
			Start = 0,
			End = 1,
			Regular = 2,
			Split = 3,
			Merge = 4,
			Invalid = 5
		}

		private class Point
		{
			public Vector2 pos;

			public Vertex originalVtx;

			public int referringvtx;

			public Point next;

			public Point prev;

			public EPointType type;

			public EDirection interiorDir;

			public EDirection whichSideInMonotone;

			public bool IsCCW()
			{
				return IsCCW(prev, this, next);
			}

			public bool IsCW()
			{
				return !IsCCW();
			}

			public void Clear()
			{
				prev = (next = null);
			}

			public static bool IsCCW(Point p0, Point p1, Point p2)
			{
				Vector2 vector = p0.pos - p1.pos;
				Vector2 vector2 = p2.pos - p1.pos;
				vector.Normalize();
				vector2.Normalize();
				return Vector3.Cross(vector, vector2).z < 0f;
			}

			public static bool IsCW(Point p0, Point p1, Point p2)
			{
				return !IsCCW(p0, p1, p2);
			}

			public Point FindPoint(Vector3 pos)
			{
				Point point = this;
				do
				{
					if (Comparer.IsEquivalent(point.originalVtx.pos, pos))
					{
						return point;
					}
					point = point.next;
				}
				while (point != this);
				return null;
			}
		}

		private class PointPair
		{
			public Point p0;

			public Point p1;

			public PointPair()
			{
			}

			public PointPair(Point _p0, Point _p1)
			{
				p0 = _p0;
				p1 = _p1;
			}

			public PointPair Clone()
			{
				return new PointPair(p0, p1);
			}

			public PointPair Swap()
			{
				Point point = p1;
				p1 = p0;
				p0 = point;
				return this;
			}
		}

		private class PointPairComparer : IComparer<PointPair>
		{
			public int Compare(PointPair x, PointPair y)
			{
				if (x.p0.GetHashCode() == y.p0.GetHashCode() && x.p1.GetHashCode() == y.p1.GetHashCode())
				{
					return 0;
				}
				if (x.p0.GetHashCode() < y.p0.GetHashCode() || (x.p0.GetHashCode() == y.p0.GetHashCode() && x.p1.GetHashCode() < y.p1.GetHashCode()))
				{
					return -1;
				}
				return 1;
			}
		}

		private class Convexhull
		{
			private List<Point> points_ = new List<Point>();

			public int Count => points_.Count;

			public Convexhull(List<Point> points)
			{
				for (int i = 0; i < points.Count; i++)
				{
					points_.Add(points[i]);
				}
			}

			public Convexhull(Point[] points)
			{
				for (int i = 0; i < points.Length; i++)
				{
					points_.Add(points[i]);
				}
			}

			public void AddPoint(Point point)
			{
				points_.Add(point);
			}

			public bool Contains(Point pt)
			{
				return points_.Contains(pt);
			}

			public Point GetPoint(int idx)
			{
				return points_[idx];
			}

			public bool IsEquivalent(Convexhull convexhull)
			{
				if (convexhull.Count != points_.Count)
				{
					return false;
				}
				for (int i = 0; i < convexhull.Count; i++)
				{
					if (!Contains(convexhull.GetPoint(i)))
					{
						return false;
					}
				}
				return true;
			}

			public bool Join(Convexhull convexhull)
			{
				int num = FindMatchedPointIndex(convexhull, 1);
				if (num == -1)
				{
					return false;
				}
				List<Point> list = new List<Point>();
				for (int i = 0; i < convexhull.Count; i++)
				{
					list.Add(convexhull.points_[(i + num) % convexhull.Count]);
				}
				int num2 = FindMatchedPointIndex(convexhull, 0);
				if (num2 == -1)
				{
					return false;
				}
				int num3 = -1;
				for (int j = 0; j < points_.Count; j++)
				{
					if (convexhull.points_[num2] == points_[j])
					{
						num3 = j;
						break;
					}
				}
				if (num3 == -1)
				{
					return false;
				}
				for (int k = 1; k < points_.Count - 1; k++)
				{
					list.Add(points_[(k + num3) % points_.Count]);
				}
				points_ = list;
				return true;
			}

			private int FindMatchedPointIndex(Convexhull convexhull, int order)
			{
				int num = 0;
				for (int i = 0; i < convexhull.points_.Count; i++)
				{
					for (int j = 0; j < points_.Count; j++)
					{
						if (convexhull.points_[i] == points_[j] && num++ == order)
						{
							return i;
						}
					}
				}
				return -1;
			}

			public bool IsConvexhull()
			{
				for (int i = 0; i < points_.Count; i++)
				{
					if (Point.IsCW(points_[i], points_[(i + 1) % points_.Count], points_[(i + 2) % points_.Count]))
					{
						return false;
					}
				}
				return true;
			}

			public Convexhull Clone()
			{
				return new Convexhull(points_);
			}

			public SimplePolygon ToPolygon(List<Vertex> whole_vertices)
			{
				List<Vertex> list = new List<Vertex>();
				for (int i = 0; i < points_.Count; i++)
				{
					list.Add(whole_vertices[points_[i].referringvtx]);
				}
				return new SimplePolygon(list);
			}
		}

		private class DiagonalConvexhulls
		{
			private SortedDictionary<PointPair, List<Convexhull>> diagonalConvexhullsMap_ = new SortedDictionary<PointPair, List<Convexhull>>(new PointPairComparer());

			private List<Convexhull> joinedConvexhulls_ = new List<Convexhull>();

			private void Init()
			{
				diagonalConvexhullsMap_ = new SortedDictionary<PointPair, List<Convexhull>>(new PointPairComparer());
				joinedConvexhulls_ = new List<Convexhull>();
			}

			public PointPair GetInvertDiagonal(PointPair diagonal)
			{
				return new PointPair(diagonal.p1, diagonal.p0);
			}

			public bool FindDiagonal(PointPair diagonal, out PointPair out_diagonal)
			{
				for (int i = 0; i < 2; i++)
				{
					if (diagonalConvexhullsMap_.ContainsKey(diagonal))
					{
						out_diagonal = diagonal;
						return true;
					}
					diagonal = diagonal.Clone().Swap();
				}
				out_diagonal = null;
				return false;
			}

			private bool IsJoined(Convexhull convexhull)
			{
				for (int i = 0; i < joinedConvexhulls_.Count; i++)
				{
					if (joinedConvexhulls_[i].IsEquivalent(convexhull))
					{
						return true;
					}
				}
				return false;
			}

			private void AddToJoinedList(Convexhull convexhull)
			{
				if (!IsJoined(convexhull))
				{
					joinedConvexhulls_.Add(convexhull);
				}
			}

			public void AddConvexhull(PointPair diagonal, Convexhull convexhull)
			{
				PointPair out_diagonal = null;
				if (FindDiagonal(diagonal, out out_diagonal))
				{
					diagonalConvexhullsMap_[out_diagonal].Add(convexhull);
					return;
				}
				List<Convexhull> list = new List<Convexhull>();
				list.Add(convexhull);
				diagonalConvexhullsMap_.Add(diagonal, list);
			}

			private void OrganizeDiagonalConvexhullMap(List<Convexhull> convexhulls)
			{
				Init();
				for (int i = 0; i < convexhulls.Count; i++)
				{
					for (int j = 0; j < convexhulls[i].Count; j++)
					{
						PointPair pointPair = new PointPair(convexhulls[i].GetPoint(j), convexhulls[i].GetPoint((j + 1) % convexhulls[i].Count));
						if (IsDiagonal(pointPair))
						{
							AddConvexhull(pointPair, convexhulls[i]);
						}
					}
				}
			}

			public List<SimplePolygon> CreateConvexhullPolygons(List<Convexhull> convexhulls, List<Vertex> whole_vertices)
			{
				int num = 0;
				do
				{
					num = convexhulls.Count;
					OrganizeDiagonalConvexhullMap(convexhulls);
					convexhulls = CreateConvexhulls();
				}
				while (convexhulls.Count < num);
				List<SimplePolygon> list = new List<SimplePolygon>();
				for (int i = 0; i < convexhulls.Count; i++)
				{
					list.Add(convexhulls[i].ToPolygon(whole_vertices));
				}
				return list;
			}

			private List<Convexhull> CreateConvexhulls()
			{
				foreach (KeyValuePair<PointPair, List<Convexhull>> item in diagonalConvexhullsMap_)
				{
					List<Convexhull> value = item.Value;
					if (value.Count != 2)
					{
						continue;
					}
					bool[] array = new bool[2]
					{
						IsJoined(value[0]),
						IsJoined(value[1])
					};
					Convexhull[] array2 = new Convexhull[2]
					{
						value[0],
						value[1]
					};
					if (array[0] || array[1])
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i])
							{
								value.Remove(array2[i]);
							}
						}
						continue;
					}
					Convexhull convexhull = value[0].Clone();
					convexhull.Join(value[1]);
					if (convexhull.IsConvexhull())
					{
						AddToJoinedList(value[0].Clone());
						AddToJoinedList(value[1].Clone());
						value.Clear();
						value.Add(convexhull);
					}
				}
				List<Convexhull> list = new List<Convexhull>();
				foreach (KeyValuePair<PointPair, List<Convexhull>> item2 in diagonalConvexhullsMap_)
				{
					List<Convexhull> value2 = item2.Value;
					for (int j = 0; j < value2.Count; j++)
					{
						if (!IsJoined(value2[j]) && FindEquivalentConvexhull(value2[j], list) == null)
						{
							list.Add(value2[j]);
						}
					}
				}
				return list;
			}

			private Convexhull FindEquivalentConvexhull(Convexhull convexhull, List<Convexhull> convexhulls)
			{
				for (int i = 0; i < convexhulls.Count; i++)
				{
					if (convexhulls[i].IsEquivalent(convexhull))
					{
						return convexhulls[i];
					}
				}
				return null;
			}
		}

		private static SimplePolygon polygon_ = new SimplePolygon();

		private static CachedMesh mesh_ = null;

		private static List<Point> points_ = new List<Point>();

		private static SortedDictionary<PointPair, PointPair> originalEdgeSet_ = null;

		private static DiagonalConvexhulls diagonalConvexhulls_ = null;

		private static List<SimplePolygon> easyConvexhullPolygons_ = null;

		private static List<Convexhull> triangleConvexhulls_ = null;

		private static Queue<Point> pointsQueue_ = new Queue<Point>();

		private static CachedMesh mesh
		{
			get
			{
				if (mesh_ == null)
				{
					mesh_ = new CachedMesh();
				}
				return mesh_;
			}
		}

		private static Point Dequeue()
		{
			if (pointsQueue_.Count > 0)
			{
				return pointsQueue_.Dequeue();
			}
			return new Point();
		}

		public static CachedMesh Triangulate(SimplePolygon polygon, CachedMesh mesh, bool includeLinkEdges = false)
		{
			if (polygon.IsOpen() || !polygon.IsValid())
			{
				return null;
			}
			Init();
			mesh_ = mesh;
			polygon.CloneTo(polygon_);
			if (!includeLinkEdges)
			{
				polygon_.RemoveLinkEdges();
			}
			if (!TriangulatePolygon())
			{
				return null;
			}
			return mesh_;
		}

		private static bool TriangulatePolygon()
		{
			polygon_.Optimize();
			if (polygon_.IsOpen() || !polygon_.IsValid())
			{
				return false;
			}
			if (polygon_.IsNonplanarQuad())
			{
				TriangulateNonplanarQuad();
			}
			else if (polygon_.IsConvexhull())
			{
				TriangulateConvex();
			}
			else
			{
				TriangulateConcave();
			}
			return true;
		}

		public static List<SimplePolygon> TriangulateToPolygons(SimplePolygon polygon, bool includeLinkEdges = false)
		{
			if (polygon.IsOpen() || !polygon.IsValid())
			{
				return null;
			}
			Triangulate(polygon, null, includeLinkEdges);
			if (mesh_ == null)
			{
				return null;
			}
			return mesh_.ToPolygonsClone(polygon.flags);
		}

		public static void BreakDownToConvexhulls(SimplePolygon polygon, List<SimplePolygon> outputConvexHull)
		{
			Init();
			diagonalConvexhulls_ = new DiagonalConvexhulls();
			easyConvexhullPolygons_ = new List<SimplePolygon>();
			triangleConvexhulls_ = new List<Convexhull>();
			polygon.CloneTo(polygon_);
			polygon_.RemoveLinkEdges();
			TriangulatePolygon();
			List<SimplePolygon> list = null;
			if (easyConvexhullPolygons_.Count > 0)
			{
				list = easyConvexhullPolygons_;
			}
			if (list == null)
			{
				list = diagonalConvexhulls_.CreateConvexhullPolygons(triangleConvexhulls_, mesh.vertices);
			}
			if (outputConvexHull.Count > list.Count)
			{
				outputConvexHull.RemoveRange(list.Count, outputConvexHull.Count - list.Count);
			}
			else if (outputConvexHull.Count < list.Count)
			{
				int num = outputConvexHull.Count;
				while (outputConvexHull.Count < list.Count)
				{
					outputConvexHull.Add(new SimplePolygon());
					num++;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].CloneTo(outputConvexHull[i]);
			}
		}

		private static void Init()
		{
			mesh_ = null;
			if (points_.Count > 0)
			{
				foreach (Point item in points_)
				{
					pointsQueue_.Enqueue(item);
				}
			}
			points_.Clear();
			originalEdgeSet_ = null;
			diagonalConvexhulls_ = null;
			easyConvexhullPolygons_ = null;
			triangleConvexhulls_ = null;
		}

		private static void TriangulateNonplanarQuad()
		{
			List<Vertex> vertices = polygon_.segments.GetOutsideLoop().vertices;
			int count = vertices.Count;
			mesh.vertices.Clear();
			mesh.normals.Clear();
			mesh.originalUVs.Clear();
			float num = -3E+10f;
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				if (polygon_.plane.CalcDistanceToPoint(vertices[i].pos) > num)
				{
					num2 = i;
				}
			}
			for (int j = 0; j < count - 2; j++)
			{
				Vertex vertex = vertices[num2].Clone();
				Vertex vertex2 = vertices[(num2 + j + 1) % count].Clone();
				Vertex vertex3 = vertices[(num2 + j + 2) % count].Clone();
				mesh.originalUVs.Add(vertex.uv);
				mesh.originalUVs.Add(vertex2.uv);
				mesh.originalUVs.Add(vertex3.uv);
				Vector3 normalized = MathUtil.Cross(vertex.pos, vertex2.pos, vertex3.pos).normalized;
				mesh.vertices.Add(vertex);
				mesh.vertices.Add(vertex2);
				mesh.vertices.Add(vertex3);
				mesh.indices.Add(j * 3);
				mesh.indices.Add(j * 3 + 1);
				mesh.indices.Add(j * 3 + 2);
				mesh.normals.Add(normalized);
				mesh.normals.Add(normalized);
				mesh.normals.Add(normalized);
				if (easyConvexhullPolygons_ != null)
				{
					List<Vertex> list = new List<Vertex>();
					list.Add(vertex);
					list.Add(vertex2);
					list.Add(vertex3);
					easyConvexhullPolygons_.Add(new SimplePolygon(list));
				}
			}
		}

		private static void TriangulateConvex()
		{
			mesh.vertices = polygon_.segments.GetOutsideLoop().vertices;
			int count = mesh.vertices.Count;
			for (int i = 0; i < count - 2; i++)
			{
				mesh.indices.Add(0);
				mesh.indices.Add(i + 1);
				mesh.indices.Add(i + 2);
			}
			_ = (Vector2)polygon_.aabb.GetCenter();
			for (int j = 0; j < mesh.vertices.Count; j++)
			{
				mesh.normals.Add(polygon_.plane.normal);
				mesh.originalUVs.Add(mesh.vertices[j].uv);
			}
			if (easyConvexhullPolygons_ != null)
			{
				easyConvexhullPolygons_.Add(polygon_);
			}
		}

		private static void TriangulateConcave()
		{
			if (!polygon_.IsValid())
			{
				return;
			}
			InitializePoints();
			List<List<Point>> list = BreakDownToMonotones();
			for (int i = 0; i < list.Count; i++)
			{
				if (IsConvex(list[i]))
				{
					TriangulateConvexMonotone(list[i], mesh_);
				}
				else
				{
					TriangulateConcaveMonotone(list[i], mesh_);
				}
			}
			for (int j = 0; j < mesh.vertices.Count; j++)
			{
				mesh.normals.Add(polygon_.plane.normal);
				mesh.originalUVs.Add(mesh.vertices[j].uv);
			}
		}

		private static Quaternion FindBestRotQuaternion()
		{
			float num = 17.123f;
			Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.forward);
			bool flag = false;
			int num2 = 0;
			while (!flag && ++num2 < 36)
			{
				flag = true;
				SortedList<KeyValuePair<float, int>, float> sortedList = new SortedList<KeyValuePair<float, int>, float>(new FloatIntComparer());
				for (int i = 0; i < polygon_.segments.GetLoopCount(); i++)
				{
					List<Vertex> vertices = polygon_.segments.GetLoop(i).vertices;
					for (int j = 0; j < vertices.Count; j++)
					{
						Vector2 vector = quaternion * polygon_.plane.ToPlaneCoord(vertices[j].pos);
						KeyValuePair<float, int> key = new KeyValuePair<float, int>(vector.y, i);
						if (!sortedList.ContainsKey(key))
						{
							sortedList.Add(key, vector.y);
							continue;
						}
						num += 17.123f;
						quaternion = Quaternion.AngleAxis(num, Vector3.forward);
						sortedList.Clear();
						flag = false;
						break;
					}
					if (!flag)
					{
						break;
					}
				}
			}
			return quaternion;
		}

		private static void InitializePoints()
		{
			Quaternion quaternion = FindBestRotQuaternion();
			Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
			for (int i = 0; i < polygon_.segments.GetLoopCount(); i++)
			{
				List<Vertex> vertices = polygon_.segments.GetLoop(i).vertices;
				for (int j = 0; j < vertices.Count; j++)
				{
					if (!dictionary.ContainsKey(vertices[j].pos))
					{
						mesh.vertices.Add(vertices[j]);
						dictionary.Add(vertices[j].pos, dictionary.Count);
					}
				}
			}
			for (int k = 0; k < polygon_.segments.GetLoopCount(); k++)
			{
				List<Vertex> vertices2 = polygon_.segments.GetLoop(k).vertices;
				Point point = null;
				Point point2 = null;
				Point point3 = null;
				for (int l = 0; l < vertices2.Count; l++)
				{
					Point point4 = new Point();
					if (l == 0)
					{
						point = point4;
					}
					if (l == vertices2.Count - 1)
					{
						point2 = point4;
					}
					point4.referringvtx = dictionary[vertices2[l].pos];
					point4.pos = quaternion * polygon_.plane.ToPlaneCoord(vertices2[l].pos);
					point4.originalVtx = vertices2[l];
					point4.prev = point3;
					point4.next = null;
					if (point3 != null)
					{
						point3.next = point4;
					}
					point3 = point4;
				}
				point.prev = point2;
				point2.next = point;
				MarkPointTypes(point);
				points_.Add(point);
			}
		}

		private static List<List<Point>> BreakDownToMonotones()
		{
			SortedDictionary<KeyValuePair<float, int>, Point> out_sorted_points = null;
			InitializeSortedDict(out out_sorted_points);
			Dictionary<Point, Point> dictionary = new Dictionary<Point, Point>();
			HashSet<Point> hashSet = new HashSet<Point>();
			HashSet<KeyValuePair<Point, Point>> diagonal_set = new HashSet<KeyValuePair<Point, Point>>();
			foreach (KeyValuePair<KeyValuePair<float, int>, Point> item in out_sorted_points)
			{
				Point value = item.Value;
				switch (value.type)
				{
				case EPointType.Start:
					hashSet.Add(value);
					dictionary[value] = value;
					break;
				case EPointType.End:
					if (GetHelperType(dictionary, value.prev) == EPointType.Merge)
					{
						AddDiagonal(diagonal_set, dictionary[value.prev], value);
					}
					hashSet.Remove(value.prev);
					break;
				case EPointType.Split:
				{
					Point point3 = FindDirectLeftEdge(hashSet, value);
					if (GetHelperType(dictionary, point3) != EPointType.Invalid)
					{
						AddDiagonal(diagonal_set, dictionary[point3], value);
						dictionary[point3] = value;
					}
					hashSet.Add(value);
					dictionary[value] = value;
					break;
				}
				case EPointType.Merge:
				{
					if (GetHelperType(dictionary, value.prev) == EPointType.Merge)
					{
						AddDiagonal(diagonal_set, dictionary[value.prev], value);
					}
					hashSet.Remove(value.prev);
					Point point2 = FindDirectLeftEdge(hashSet, value);
					if (GetHelperType(dictionary, point2) == EPointType.Merge)
					{
						AddDiagonal(diagonal_set, dictionary[point2], value);
					}
					if (point2 != null)
					{
						dictionary[point2] = value;
					}
					break;
				}
				case EPointType.Regular:
					if (value.interiorDir == EDirection.Right)
					{
						if (GetHelperType(dictionary, value.prev) == EPointType.Merge)
						{
							AddDiagonal(diagonal_set, dictionary[value.prev], value);
						}
						hashSet.Remove(value.prev);
						hashSet.Add(value);
						dictionary[value] = value;
					}
					else if (value.interiorDir == EDirection.Left)
					{
						Point point = FindDirectLeftEdge(hashSet, value);
						if (GetHelperType(dictionary, point) == EPointType.Merge)
						{
							AddDiagonal(diagonal_set, value, dictionary[point]);
						}
						if (point != null)
						{
							dictionary[point] = value;
						}
					}
					break;
				}
			}
			return FindMonotoneLoops(diagonal_set);
		}

		private static void InitializeSortedDict(out SortedDictionary<KeyValuePair<float, int>, Point> out_sorted_points)
		{
			out_sorted_points = new SortedDictionary<KeyValuePair<float, int>, Point>(new FloatIntComparer());
			for (int i = 0; i < points_.Count; i++)
			{
				Point point = points_[i];
				Point point2 = point;
				do
				{
					KeyValuePair<float, int> key = new KeyValuePair<float, int>(point2.pos.y, (int)(point2.pos.x * 10000f));
					while (out_sorted_points.ContainsKey(key))
					{
						key = new KeyValuePair<float, int>(point2.pos.y, key.Value + 1);
					}
					out_sorted_points.Add(key, point2);
					point2 = point2.next;
				}
				while (point2 != point);
			}
		}

		private static EPointType GetHelperType(Dictionary<Point, Point> helpers, Point helper)
		{
			if (helper == null || !helpers.ContainsKey(helper))
			{
				return EPointType.Invalid;
			}
			return helpers[helper].type;
		}

		private static void AddDiagonal(HashSet<KeyValuePair<Point, Point>> diagonal_set, Point p0, Point p1)
		{
			diagonal_set.Add(new KeyValuePair<Point, Point>(p0, p1));
			diagonal_set.Add(new KeyValuePair<Point, Point>(p1, p0));
		}

		private static Point FindDirectLeftEdge(HashSet<Point> edge_search_tree, Point point)
		{
			float num = 3E+10f;
			Point result = null;
			Vector2 direction = new Vector2(-1f, 0f);
			foreach (Point item in edge_search_tree)
			{
				Edge2D edge = new Edge2D(item.pos, item.next.pos);
				Line2D line2D = new Line2D(edge);
				if (line2D.Distance(point.pos) > 0.0001f)
				{
					continue;
				}
				HitResult hitResult = line2D.RayHit(point.pos, direction);
				float num2 = 0f;
				if (hitResult != null)
				{
					num2 = Mathf.Abs(hitResult.t);
				}
				else
				{
					if (!(Mathf.Abs(edge.p0.y - edge.p1.y) < 0.0001f) || !(Mathf.Abs(edge.p0.y - point.pos.y) < 0.0001f))
					{
						continue;
					}
					num2 = Mathf.Min(Vector2.Distance(point.pos, edge.p0), Vector2.Distance(point.pos, edge.p1));
				}
				if (num2 < num)
				{
					num = num2;
					result = item;
				}
			}
			return result;
		}

		private static List<List<Point>> FindMonotoneLoops(HashSet<KeyValuePair<Point, Point>> diagonal_set)
		{
			List<List<Point>> list = new List<List<Point>>();
			SortedDictionary<Vector3, HashSet<KeyValuePair<Point, Point>>> sortedDictionary = new SortedDictionary<Vector3, HashSet<KeyValuePair<Point, Point>>>(new Vector3Comparer());
			HashSet<KeyValuePair<Point, Point>> hashSet = new HashSet<KeyValuePair<Point, Point>>();
			HashSet<KeyValuePair<Point, Point>> hashSet2 = new HashSet<KeyValuePair<Point, Point>>();
			foreach (KeyValuePair<Point, Point> item3 in diagonal_set)
			{
				HashSet<KeyValuePair<Point, Point>> value = new HashSet<KeyValuePair<Point, Point>>();
				if (!sortedDictionary.TryGetValue(item3.Key.pos, out value))
				{
					sortedDictionary.Add(item3.Key.pos, value = new HashSet<KeyValuePair<Point, Point>>());
				}
				value.Add(item3);
				hashSet.Add(item3);
			}
			foreach (Point item4 in points_)
			{
				Point point = item4;
				do
				{
					HashSet<KeyValuePair<Point, Point>> value2 = new HashSet<KeyValuePair<Point, Point>>();
					if (!sortedDictionary.TryGetValue(point.pos, out value2))
					{
						sortedDictionary.Add(point.pos, value2 = new HashSet<KeyValuePair<Point, Point>>());
					}
					KeyValuePair<Point, Point> item = new KeyValuePair<Point, Point>(point, point.next);
					value2.Add(item);
					hashSet.Add(item);
					point = point.next;
				}
				while (point != item4);
			}
			foreach (KeyValuePair<Point, Point> item5 in hashSet)
			{
				if (hashSet2.Contains(item5))
				{
					continue;
				}
				List<Point> list2 = new List<Point>();
				KeyValuePair<Point, Point> item2 = item5;
				do
				{
					list2.Add(item2.Key);
					hashSet2.Add(item2);
					HashSet<KeyValuePair<Point, Point>> hashSet3 = sortedDictionary[item2.Value.pos];
					if (hashSet3.Count == 0)
					{
						break;
					}
					if (hashSet3.Count == 1)
					{
						HashSet<KeyValuePair<Point, Point>>.Enumerator enumerator3 = hashSet3.GetEnumerator();
						enumerator3.MoveNext();
						item2 = new KeyValuePair<Point, Point>(item2.Value, enumerator3.Current.Value);
						hashSet3.Clear();
					}
					else
					{
						if (hashSet3.Count <= 1)
						{
							continue;
						}
						float num = -1.5f;
						float num2 = 1.5f;
						Point point2 = null;
						Point value3 = null;
						foreach (KeyValuePair<Point, Point> item6 in hashSet3)
						{
							if (item6.Value == item2.Key)
							{
								continue;
							}
							float num3 = Cosine(item2.Key, item2.Value, item6.Value);
							if (IsCCW(item2.Key, item2.Value, item6.Value))
							{
								if (num3 > num)
								{
									point2 = item6.Value;
									num = num3;
								}
							}
							else if (num3 < num2)
							{
								value3 = item6.Value;
								num2 = num3;
							}
						}
						if (point2 != null)
						{
							item2 = new KeyValuePair<Point, Point>(item2.Value, point2);
							hashSet3.Remove(item2);
						}
						else
						{
							item2 = new KeyValuePair<Point, Point>(item2.Value, value3);
							hashSet3.Remove(item2);
						}
					}
				}
				while (item2.Value != item5.Key);
				hashSet2.Add(item2);
				list2.Add(item2.Key);
				list.Add(list2);
			}
			return list;
		}

		private static bool IsConvex(List<Point> points)
		{
			for (int i = 0; i < points.Count; i++)
			{
				if (!IsCCW(points[i], points[(i + 1) % points.Count], points[(i + 2) % points.Count]))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsCCW(Point p0, Point p1, Point p2)
		{
			Vector2 vector = p0.pos - p1.pos;
			Vector2 vector2 = p2.pos - p1.pos;
			vector.Normalize();
			vector2.Normalize();
			return Vector3.Cross(vector, vector2).z < -0.0001f;
		}

		private static bool IsCCW(Point point)
		{
			return IsCCW(point.prev, point, point.next);
		}

		private static bool IsCW(Point p0, Point p1, Point p2)
		{
			return !IsCCW(p0, p1, p2);
		}

		private static bool IsCW(Point point)
		{
			return !IsCCW(point);
		}

		private static float Cosine(Point p0, Point p1, Point p2)
		{
			Vector2 lhs = p0.pos - p1.pos;
			Vector2 rhs = p2.pos - p1.pos;
			lhs.Normalize();
			rhs.Normalize();
			return Vector2.Dot(lhs, rhs);
		}

		private static void TriangulateConvexMonotone(List<Point> monotone, CachedMesh mesh)
		{
			for (int i = 0; i < monotone.Count - 2; i++)
			{
				AddTriangle(monotone[0], monotone[i + 1], monotone[i + 2], mesh);
			}
		}

		private static void TriangulateConcaveMonotone(List<Point> monotone, CachedMesh mesh)
		{
			SortedDictionary<KeyValuePair<float, int>, int> sorted_points = null;
			if (!SortMonotonPoints(monotone, out sorted_points))
			{
				return;
			}
			BSPTree2D bspTree = BuildBSPTree2D(monotone);
			Stack<int> stack = new Stack<int>();
			SortedDictionary<KeyValuePair<float, int>, int>.Enumerator enumerator = sorted_points.GetEnumerator();
			enumerator.MoveNext();
			stack.Push(enumerator.Current.Value);
			enumerator.MoveNext();
			stack.Push(enumerator.Current.Value);
			KeyValuePair<KeyValuePair<float, int>, int> current = enumerator.Current;
			while (enumerator.MoveNext())
			{
				int num = stack.Peek();
				int value = enumerator.Current.Value;
				stack.Pop();
				int index = stack.Peek();
				stack.Push(num);
				EDirection whichSideInMonotone = monotone[num].whichSideInMonotone;
				EDirection whichSideInMonotone2 = monotone[value].whichSideInMonotone;
				if (whichSideInMonotone != whichSideInMonotone2)
				{
					while (stack.Count != 0)
					{
						num = stack.Peek();
						if (IsCCW(monotone[value], monotone[index], monotone[num]))
						{
							AddFace(monotone[value], monotone[index], monotone[num], monotone, mesh);
						}
						else
						{
							AddFace(monotone[value], monotone[num], monotone[index], monotone, mesh);
						}
						index = num;
						stack.Pop();
					}
					stack.Push(current.Value);
				}
				else if ((whichSideInMonotone2 == EDirection.Right && IsCCW(monotone[value], monotone[num], monotone[index])) || (whichSideInMonotone2 == EDirection.Left && IsCW(monotone[value], monotone[num], monotone[index])))
				{
					index = num;
					stack.Pop();
					while (stack.Count != 0)
					{
						num = stack.Peek();
						if (!IsInside(bspTree, monotone, value, num))
						{
							break;
						}
						if (IsCCW(monotone[value], monotone[index], monotone[num]))
						{
							AddFace(monotone[value], monotone[index], monotone[num], monotone, mesh);
						}
						else
						{
							AddFace(monotone[value], monotone[num], monotone[index], monotone, mesh);
						}
						index = num;
						stack.Pop();
					}
					stack.Push(index);
				}
				stack.Push(enumerator.Current.Value);
				current = enumerator.Current;
			}
		}

		private static bool SortMonotonPoints(List<Point> monotone, out SortedDictionary<KeyValuePair<float, int>, int> sorted_points)
		{
			sorted_points = new SortedDictionary<KeyValuePair<float, int>, int>(new FloatIntComparer());
			float num = 3E+10f;
			float num2 = -3E+10f;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < monotone.Count; i++)
			{
				if (monotone[i].pos.y < num)
				{
					num = monotone[i].pos.y;
					num3 = i;
				}
				if (monotone[i].pos.y > num2)
				{
					num2 = monotone[i].pos.y;
					num4 = i;
				}
				KeyValuePair<float, int> key = new KeyValuePair<float, int>(monotone[i].pos.y, (int)(monotone[i].pos.x * 10000f));
				while (sorted_points.ContainsKey(key))
				{
					key = new KeyValuePair<float, int>(monotone[i].pos.y, key.Value + 1);
				}
				sorted_points.Add(key, i);
			}
			for (int num5 = num3; num5 != num4; num5 = (num5 + 1) % monotone.Count)
			{
				monotone[num5].whichSideInMonotone = EDirection.Left;
			}
			for (int num6 = num4; num6 != num3; num6 = (num6 + 1) % monotone.Count)
			{
				monotone[num6].whichSideInMonotone = EDirection.Right;
			}
			return true;
		}

		private static void MarkPointTypes(Point start_point)
		{
			Point point = start_point;
			do
			{
				if (point.pos.y < point.prev.pos.y && point.pos.y < point.next.pos.y)
				{
					if (IsCCW(point))
					{
						point.type = EPointType.Start;
					}
					else
					{
						point.type = EPointType.Split;
					}
					point.interiorDir = EDirection.Other;
				}
				else if (point.pos.y > point.prev.pos.y && point.pos.y > point.next.pos.y)
				{
					if (IsCCW(point))
					{
						point.type = EPointType.End;
					}
					else
					{
						point.type = EPointType.Merge;
					}
					point.interiorDir = EDirection.Other;
				}
				else
				{
					point.type = EPointType.Regular;
					if (point.prev.pos.y < point.pos.y && point.pos.y < point.next.pos.y)
					{
						point.interiorDir = EDirection.Right;
					}
					else
					{
						point.interiorDir = EDirection.Left;
					}
				}
				point = point.next;
			}
			while (point != start_point);
		}

		private static void AddFace(Point p0, Point p1, Point p2, List<Point> monotone, CachedMesh mesh)
		{
			if (!IsDegenerated(p0, p1, p2) && !SolveTJunctionsInTriangle(p0, p1, p2, monotone, mesh))
			{
				AddTriangle(p0, p1, p2, mesh);
			}
		}

		private static bool IsDegenerated(Point p0, Point p1, Point p2)
		{
			Vector2 v = p1.pos - p0.pos;
			Vector2 vector = p2.pos - p0.pos;
			v.Normalize();
			vector.Normalize();
			if (!Comparer.IsEquivalent(v, vector))
			{
				return Comparer.IsEquivalent(v, -vector);
			}
			return true;
		}

		private static bool SolveTJunctionsInTriangle(Point p0, Point p1, Point p2, List<Point> monotone, CachedMesh mesh)
		{
			Point[] array = new Point[3] { p0, p1, p2 };
			int length = array.GetLength(0);
			bool result = false;
			for (int i = 0; i < length; i++)
			{
				Point p3 = array[(i - 1 + length) % length];
				Point point = array[i];
				Point point2 = array[(i + 1) % length];
				Point point3 = point2;
				Point point4 = FindNextPoint(point3, monotone);
				int num = 0;
				while (point4 != null && point4 != point)
				{
					if (IsInsideEdge(new PointPair(point2, p3), point4))
					{
						if ((point != p0 || point3 != p1 || point4 != p2) && (point != p1 || point3 != p2 || point4 != p0) && (point != p2 || point3 != p0 || point4 != p1))
						{
							result = true;
							AddTriangle(point, point3, point4, mesh);
						}
						point3 = point4;
					}
					point4 = FindNextPoint(point4, monotone);
					if (num++ > monotone.Count)
					{
						break;
					}
				}
			}
			return result;
		}

		private static Point FindNextPoint(Point p, List<Point> points)
		{
			for (int i = 0; i < points.Count; i++)
			{
				if (p == points[i])
				{
					return points[(i + 1) % points.Count];
				}
			}
			return null;
		}

		private static void OrganizeOriginalEdgeSet()
		{
			List<Point> list = new List<Point>();
			for (int i = 0; i < polygon_.GetVertexCount(); i++)
			{
				Vertex vertex = polygon_.GetVertex(i);
				for (int j = 0; j < points_.Count; j++)
				{
					Point point = points_[j].FindPoint(vertex.pos);
					if (point != null)
					{
						list.Add(point);
						break;
					}
				}
			}
			originalEdgeSet_ = new SortedDictionary<PointPair, PointPair>(new PointPairComparer());
			for (int k = 0; k < polygon_.GetEdgeCount(); k++)
			{
				IndexPair edge = polygon_.GetEdge(k);
				PointPair pointPair = new PointPair(list[edge.i0], list[edge.i1]);
				originalEdgeSet_.Add(pointPair, pointPair);
			}
		}

		private static bool IsDiagonal(PointPair edge)
		{
			if (originalEdgeSet_ == null)
			{
				OrganizeOriginalEdgeSet();
			}
			if (originalEdgeSet_.ContainsKey(edge) || originalEdgeSet_.ContainsKey(edge.Clone().Swap()))
			{
				return false;
			}
			return true;
		}

		private static bool IsInsideEdge(PointPair point_edge, Point p)
		{
			return new Edge2D(point_edge.p0.pos, point_edge.p1.pos).IsInside(p.pos);
		}

		private static void AddTriangle(Point p0, Point p1, Point p2, CachedMesh mesh)
		{
			if (!mesh.HasTriangle(p0.referringvtx, p1.referringvtx, p2.referringvtx))
			{
				mesh.indices.Add(p0.referringvtx);
				mesh.indices.Add(p1.referringvtx);
				mesh.indices.Add(p2.referringvtx);
				if (triangleConvexhulls_ != null)
				{
					triangleConvexhulls_.Add(new Convexhull(new Point[3] { p0, p1, p2 }));
				}
			}
		}

		private static bool IsInside(BSPTree2D bspTree, List<Point> monotone, int i0, int i1)
		{
			if (Mathf.Abs(i0 - i1) == 1)
			{
				return true;
			}
			Edge edge = new Edge(polygon_.plane.FromPlaneCoord(monotone[i0].pos), polygon_.plane.FromPlaneCoord(monotone[i1].pos));
			return bspTree.IsInside(edge);
		}

		private static BSPTree2D BuildBSPTree2D(List<Point> points)
		{
			BSPTree2D bSPTree2D = new BSPTree2D();
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < points.Count; i++)
			{
				list.Add(points[i].pos);
			}
			bSPTree2D.Build(list, polygon_.plane);
			return bSPTree2D;
		}
	}
}
