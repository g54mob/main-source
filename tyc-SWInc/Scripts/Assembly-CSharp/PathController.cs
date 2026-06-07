using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathController
{
	public class PathPoint : IRoomConnector
	{
		public Vector2 Point;

		public bool Bezier;

		public uint ID;

		public PathObject ParentObject;

		public PathNode<Vector3> Node;

		public List<KeyValuePair<PathPoint, float>> Connections = new List<KeyValuePair<PathPoint, float>>();

		public Dictionary<PathPoint, PathVector[]> CachedPaths;

		private HashSet<RoomSegment> _connectingSegments = new HashSet<RoomSegment>();

		public float CachedDist = float.PositiveInfinity;

		public PathPoint CachedLast;

		public string Material;

		public Color? Color;

		public bool MovesBetweenFloors
		{
			get
			{
				return false;
			}
		}

		public bool IsBlocked
		{
			get
			{
				return false;
			}
		}

		public int ConnectedSegmentCount
		{
			get
			{
				return _connectingSegments.Count;
			}
		}

		public uint[] SegmentIDArray
		{
			get
			{
				return _connectingSegments.Select((RoomSegment x) => x.DID).ToArray();
			}
		}

		public bool IsConnecter
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PathNode<Vector3> pathNode
		{
			get
			{
				return Node;
			}
			set
			{
			}
		}

		public Transform ObjectTransform
		{
			get
			{
				return null;
			}
		}

		public bool IsNull
		{
			get
			{
				return false;
			}
		}

		public bool IsRefreshing
		{
			get
			{
				return false;
			}
		}

		public HashSet<RoomSegment> GetConnectedSegments()
		{
			return _connectingSegments;
		}

		public bool NeedsPathing()
		{
			if (Connections.Count >= 2)
			{
				return _connectingSegments.Count > 0;
			}
			return true;
		}

		public void RemoveFromParent()
		{
			if (!(ParentObject != null))
			{
				return;
			}
			ParentObject.Path.Remove(this);
			if (ParentObject.Path.Count == 0)
			{
				if (SelectorController.Instance.Selected.Remove(ParentObject))
				{
					SelectorController.Instance.DoPostSelectChecks();
				}
				GameSettings.Instance.sRoomManager.PathController.DestroyPathObject(ParentObject);
			}
		}

		public void AddConnection(PathPoint p)
		{
			if (p == this)
			{
				return;
			}
			for (int i = 0; i < Connections.Count; i++)
			{
				if (Connections[i].Key == p)
				{
					return;
				}
			}
			float magnitude = (Point - p.Point).magnitude;
			Connections.Add(new KeyValuePair<PathPoint, float>(p, magnitude));
			p.Connections.Add(new KeyValuePair<PathPoint, float>(this, magnitude));
		}

		public void RemoveConnection(PathPoint p)
		{
			for (int i = 0; i < Connections.Count; i++)
			{
				if (Connections[i].Key == p)
				{
					Connections.RemoveAt(i);
					break;
				}
			}
		}

		public PathPoint(Vector2 point, ref uint id, bool bezier)
		{
			Point = point;
			Bezier = bezier;
			ID = id;
			id++;
		}

		public PathPoint(Vector2 point, bool bezier, uint id)
		{
			Point = point;
			Bezier = bezier;
			ID = id;
		}

		public void InitializeNode()
		{
			if (Node == null)
			{
				Node = new PathNode<Vector3>(Point.ToVector3(0f), this)
				{
					Weight = 0.75f
				};
			}
		}

		public void RemoveSegmentConnection(RoomSegment s)
		{
			if (s != null)
			{
				_connectingSegments.Remove(s);
				s.pathNode.RemoveConnection(Node);
				Node.RemoveConnection(s.pathNode);
				if (s.ConnectedPath == this)
				{
					s.ConnectedPath = null;
				}
				return;
			}
			foreach (RoomSegment connectingSegment in _connectingSegments)
			{
				connectingSegment.pathNode.RemoveConnection(Node);
				Node.RemoveConnection(connectingSegment.pathNode);
				if (connectingSegment.ConnectedPath == this)
				{
					connectingSegment.ConnectedPath = null;
				}
			}
			_connectingSegments.Clear();
		}

		public void ConnectSegment(RoomSegment segment)
		{
			if (segment.ConnectedPath != null && segment.ConnectedPath != this)
			{
				Debug.LogError("Ignore: Tried to connect segment to path, which was already connected to other path");
				return;
			}
			InitializeNode();
			_connectingSegments.Add(segment);
			segment.pathNode.AddConnection(Node);
			Node.AddConnection(segment.pathNode);
			segment.ConnectedPath = this;
		}

		public void ClearNode()
		{
			if (Node == null)
			{
				return;
			}
			List<PathNode<Vector3>> connections = Node.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<Vector3> pathNode = connections[i];
				PathPoint pathPoint = pathNode.Tag as PathPoint;
				if (pathPoint != null)
				{
					pathNode.RemoveConnection(Node);
					pathPoint.CachedPaths.Remove(this);
				}
			}
			Node.Clear();
			if (_connectingSegments.Count > 0)
			{
				foreach (RoomSegment connectingSegment in _connectingSegments)
				{
					Node.AddConnection(connectingSegment.pathNode);
				}
			}
			else
			{
				Node = null;
			}
			if (CachedPaths != null)
			{
				CachedPaths.Clear();
				CachedPaths = null;
			}
		}

		public void CachePath(PathPoint p, IList<PathPoint> list, bool reverse)
		{
			InitializeNode();
			if (CachedPaths == null)
			{
				CachedPaths = new Dictionary<PathPoint, PathVector[]>();
			}
			PathVector[] array = new PathVector[list.Count];
			if (reverse)
			{
				array[0] = GetPathPoint(list[array.Length - 1].Point, list[array.Length - 2].Point, true);
				for (int i = 1; i < list.Count - 1; i++)
				{
					Vector2 point = list[list.Count - i].Point;
					Vector2 point2 = list[list.Count - 1 - i].Point;
					Vector2 point3 = list[list.Count - 2 - i].Point;
					array[i] = Utilities.GetOffset(point, point2, point3, 0f - PathWalkOffset).ToVector3(0f);
				}
				array[array.Length - 1] = GetPathPoint(list[0].Point, list[1].Point);
			}
			else
			{
				array[0] = GetPathPoint(list[0].Point, list[1].Point, true);
				for (int j = 1; j < list.Count - 1; j++)
				{
					Vector2 point4 = list[j - 1].Point;
					Vector2 point5 = list[j].Point;
					Vector2 point6 = list[j + 1].Point;
					array[j] = Utilities.GetOffset(point4, point5, point6, 0f - PathWalkOffset).ToVector3(0f);
				}
				array[array.Length - 1] = GetPathPoint(list[list.Count - 1].Point, list[list.Count - 2].Point);
			}
			CachedPaths[p] = array;
			Node.AddConnection(p.Node);
		}

		private static PathVector GetPathPoint(Vector2 a, Vector2 b, bool rev = false)
		{
			Vector2 vector = (b - a).Turn90().normalized * PathWalkOffset;
			Vector2 vector2 = (rev ? (a - vector) : (a + vector));
			return new PathVector(vector2.x, 0f, vector2.y, PathVector.PathType.Path);
		}

		public Vector3 GetOffsetPos(Room room, bool inverse = false)
		{
			return Point.ToVector3(0f);
		}

		public bool AllowEntry()
		{
			return true;
		}

		public void UpdateBlocked()
		{
		}

		public Transform[] IntermediatePoints(Room from)
		{
			return null;
		}

		public Vector2 GetPoint(Vector2 from, PathPoint other, bool reverse = false)
		{
			PathVector[] array = (reverse ? other.CachedPaths.GetOrNull(this) : CachedPaths.GetOrNull(other));
			if (array != null)
			{
				return Utilities.ProjectToLineEndlessClamped(from, array[reverse ? (array.Length - 1) : 0].Flatten(), array[(!reverse) ? 1 : (array.Length - 2)].Flatten());
			}
			return Point;
		}

		public bool AllowExit()
		{
			return true;
		}
	}

	public class SaveNode
	{
		public SVector3 P;

		public int GroupIDX;

		public uint[] SegmentID;

		public uint ID;

		public List<SaveNode> Connections;

		public bool EndPoint;

		public bool Bezier;

		public SaveNode()
		{
		}

		public SaveNode(PathPoint p, Dictionary<PathPoint, SaveNode> nodes, Dictionary<PathObject, int> parentIDs, ref int pIDX)
		{
			P = p.Point;
			ID = p.ID;
			if (!parentIDs.TryGetValue(p.ParentObject, out GroupIDX))
			{
				GroupIDX = pIDX;
				parentIDs[p.ParentObject] = pIDX;
				pIDX++;
			}
			SegmentID = p.SegmentIDArray;
			Connections = new List<SaveNode>();
			for (int i = 0; i < p.Connections.Count; i++)
			{
				SaveNode value;
				if (nodes.TryGetValue(p.Connections[i].Key, out value))
				{
					Connections.Add(value);
				}
			}
			EndPoint = p.NeedsPathing();
			Bezier = p.Bezier;
		}
	}

	public static float PathSegSnapDist = 1.02f;

	public static float PathWalkOffset = 0.3f;

	public uint IDCounter;

	public HashSet<PathPoint> EndPoints = new HashSet<PathPoint>();

	public HashSet<PathPoint> InAccessibleEndPoints = new HashSet<PathPoint>();

	public HashSet<PathPoint> EndPointQueue = new HashSet<PathPoint>();

	public List<PathPoint> AllPoints = new List<PathPoint>();

	public List<PathObject> AllPathObjects = new List<PathObject>();

	private List<PathPoint> _tmpIn = new List<PathPoint>();

	private List<PathPoint> _tmpAc = new List<PathPoint>();

	public void RemoveEndPoint(PathPoint p)
	{
		EndPointQueue.Remove(p);
		InAccessibleEndPoints.Remove(p);
		if (EndPoints.Remove(p))
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
		}
	}

	private bool IsAccessible(PathPoint p)
	{
		return GameSettings.Instance.sRoomManager.Outside.GetNodeAt(p.Point) != null;
	}

	public void EnqeueEndPoint(PathPoint p)
	{
		if (!EndPoints.Contains(p) && !InAccessibleEndPoints.Contains(p))
		{
			EndPoints.Add(p);
		}
		GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
	}

	public void UpdateEndPoints()
	{
		foreach (PathPoint inAccessibleEndPoint in InAccessibleEndPoints)
		{
			if (IsAccessible(inAccessibleEndPoint))
			{
				_tmpAc.Add(inAccessibleEndPoint);
			}
			else
			{
				_tmpIn.Add(inAccessibleEndPoint);
			}
		}
		foreach (PathPoint endPoint in EndPoints)
		{
			if (IsAccessible(endPoint))
			{
				_tmpAc.Add(endPoint);
			}
			else
			{
				_tmpIn.Add(endPoint);
			}
		}
		InAccessibleEndPoints.Clear();
		EndPoints.Clear();
		InAccessibleEndPoints.AddRange(_tmpIn);
		EndPoints.AddRange(_tmpAc);
		_tmpIn.Clear();
		_tmpAc.Clear();
		foreach (PathPoint item in EndPointQueue)
		{
			if (IsAccessible(item))
			{
				EndPoints.Add(item);
				InAccessibleEndPoints.Remove(item);
			}
			else
			{
				InAccessibleEndPoints.Add(item);
				EndPoints.Remove(item);
			}
		}
		EndPointQueue.Clear();
	}

	public static void GetIntermediatePoints(PathPoint a, PathPoint b, List<Vector2> result, bool includeEnd, bool includeStart = true)
	{
		Vector2 point = a.Point;
		Vector2 point2 = b.Point;
		Vector2 zero = Vector2.zero;
		Vector2 vector = Vector2.zero;
		bool flag = false;
		bool flag2 = false;
		if (a.Bezier && a.Connections.Count == 2)
		{
			PathPoint pathPoint = a.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => x.Key != b, (KeyValuePair<PathPoint, float> x) => x.Key);
			zero = FindBezierOffset(pathPoint.Point, point, point2).normalized;
			point += (((a.Point + b.Point) * 0.5f + (a.Point + pathPoint.Point) * 0.5f) * 0.5f - a.Point).normalized * 0.5f;
			flag = true;
		}
		else
		{
			zero = (point2 - point).normalized;
		}
		if (b.Bezier && b.Connections.Count == 2)
		{
			PathPoint pathPoint2 = b.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => x.Key != a, (KeyValuePair<PathPoint, float> x) => x.Key);
			vector = FindBezierOffset(pathPoint2.Point, point2, point).normalized;
			point2 += (((a.Point + b.Point) * 0.5f + (b.Point + pathPoint2.Point) * 0.5f) * 0.5f - b.Point).normalized * 0.5f;
			flag2 = true;
		}
		else if (flag)
		{
			vector = (point - point2).normalized;
		}
		if (includeStart)
		{
			result.Add(point);
		}
		if (flag || flag2)
		{
			Vector2 p = point + zero;
			Vector2 p2 = point2 + vector;
			if (flag)
			{
				result.Add(Bezier(point, p, p2, point2, 0.05f));
				result.Add(Bezier(point, p, p2, point2, 0.1f));
				result.Add(Bezier(point, p, p2, point2, 0.15f));
				result.Add(Bezier(point, p, p2, point2, 0.2f));
			}
			if (flag2)
			{
				result.Add(Bezier(point, p, p2, point2, 0.8f));
				result.Add(Bezier(point, p, p2, point2, 0.85f));
				result.Add(Bezier(point, p, p2, point2, 0.9f));
				result.Add(Bezier(point, p, p2, point2, 0.95f));
			}
		}
		if (includeEnd)
		{
			result.Add(point2);
		}
	}

	private static Vector2 FindBezierOffset(Vector2 a, Vector2 b, Vector2 c)
	{
		return Vector2.Lerp((a - b).Turn90().normalized, (b - c).Turn90().normalized, 0.5f).Turn90();
	}

	private void GetFullPath(IList<PathPoint> ps, List<Vector2> res)
	{
		bool flag = ps[0].Connections.Count <= 2;
		if (!flag)
		{
			res.Add(ps[0].Point + (ps[1].Point - ps[0].Point).normalized);
		}
		for (int i = 0; i < ps.Count - 2; i++)
		{
			GetIntermediatePoints(ps[i], ps[i + 1], res, false, flag || i > 0);
		}
		bool flag2 = ps[ps.Count - 1].Connections.Count <= 2;
		GetIntermediatePoints(ps[ps.Count - 2], ps[ps.Count - 1], res, flag2, flag || ps.Count > 2);
		if (!flag2)
		{
			res.Add(ps[ps.Count - 1].Point + (ps[ps.Count - 2].Point - ps[ps.Count - 1].Point).normalized);
		}
	}

	public static Vector2 Bezier(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
	{
		float num = 1f - t;
		float num2 = num * num * num;
		float num3 = num * num;
		return num2 * p0 + 3f * t * num3 * p1 + 3f * t * t * num * p2 + t * t * t * p3;
	}

	public void DeletePoint(PathPoint p)
	{
		p.ClearNode();
		for (int i = 0; i < p.Connections.Count; i++)
		{
			p.Connections[i].Key.RemoveConnection(p);
		}
		p.Connections.Clear();
		p.RemoveFromParent();
		AllPoints.Remove(p);
		RemoveEndPoint(p);
		p.RemoveSegmentConnection(null);
	}

	public void DeleteEntirePath(PathObject o)
	{
		foreach (PathPoint item in o.Path)
		{
			if (o.Path.Count > 0)
			{
				GrassSystem.Instance.InvalidateArea();
			}
			item.ClearNode();
			AllPoints.Remove(item);
			RemoveEndPoint(item);
			item.RemoveSegmentConnection(null);
		}
		DestroyPathObject(o);
	}

	public void DestroyPathObject(PathObject o)
	{
		AllPathObjects.Remove(o);
		o.DestroyGO();
	}

	public void CheckSegmentDelete(RoomSegment s)
	{
		PathPoint connectedPath = s.ConnectedPath;
		if (connectedPath != null)
		{
			connectedPath.RemoveSegmentConnection(s);
			PathPoint a;
			PathPoint b;
			if (IsOnStraightLine(connectedPath, out a, out b))
			{
				MergePathPoint(a, connectedPath, b, true);
			}
			else if (connectedPath.Connections.Count > 1)
			{
				connectedPath.ClearNode();
			}
			else
			{
				EnqeueEndPoint(connectedPath);
			}
		}
	}

	public bool IsOnStraightLine(PathPoint p, out PathPoint a, out PathPoint b, PathPoint ignore = null)
	{
		a = null;
		b = null;
		int num = ((ignore == null) ? 2 : 3);
		if (p.ConnectedSegmentCount == 0 && p.Connections.Count == num)
		{
			for (int i = 0; i < p.Connections.Count; i++)
			{
				PathPoint key = p.Connections[i].Key;
				if (key != ignore)
				{
					if (a != null && (p.Point - a.Point).normalized == (key.Point - p.Point).normalized)
					{
						b = key;
						return true;
					}
					a = key;
				}
			}
			a = null;
		}
		return false;
	}

	public void MergePathPoint(PathPoint a, PathPoint delete, PathPoint b, bool refreshPaths)
	{
		DeletePoint(delete);
		a.AddConnection(b);
		if (refreshPaths)
		{
			RefreshPathFrom(a);
		}
	}

	public void RefreshPathFrom(PathPoint p, bool mesh = true)
	{
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		HashSet<PathPoint> visited = new HashSet<PathPoint>();
		FindGroup(p, visited, hashSet);
		FindPaths(hashSet);
		if (mesh)
		{
			BuildMesh(new HashSet<PathPoint> { p });
		}
	}

	public PathPoint[] OrderByEnds(HashSet<PathPoint> ps)
	{
		PathPoint[] array = ps.ToArray();
		PathPoint pathPoint = null;
		foreach (PathPoint pathPoint2 in array)
		{
			if (pathPoint2.Connections.Count((KeyValuePair<PathPoint, float> x) => ps.Contains(x.Key)) == 1)
			{
				pathPoint = pathPoint2;
				break;
			}
		}
		if (pathPoint == null)
		{
			pathPoint = array[0];
			array = new PathPoint[array.Length + 1];
		}
		PathPoint pathPoint3 = (array[0] = pathPoint);
		for (int num = 1; num < array.Length; num++)
		{
			PathPoint first1 = pathPoint;
			PathPoint pathPoint4 = (array[num] = pathPoint3.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => ps.Contains(x.Key) && x.Key != first1, (KeyValuePair<PathPoint, float> x) => x.Key));
			pathPoint = pathPoint3;
			pathPoint3 = pathPoint4;
		}
		return array;
	}

	public void DeletePath(HashSet<PathPoint> p)
	{
		GrassSystem.Instance.InvalidateArea();
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		HashSet<PathPoint> hashSet2 = new HashSet<PathPoint>();
		List<KeyValuePair<PathPoint, int>> list = new List<KeyValuePair<PathPoint, int>>(p.Select((PathPoint x) => new KeyValuePair<PathPoint, int>(x, x.Connections.Count((KeyValuePair<PathPoint, float> z) => !p.Contains(z.Key)))));
		for (int num = 0; num < list.Count; num++)
		{
			PathPoint key = list[num].Key;
			for (int num2 = 0; num2 < key.Connections.Count; num2++)
			{
				PathPoint key2 = key.Connections[num2].Key;
				if (!p.Contains(key2))
				{
					hashSet2.Add(key2);
				}
			}
			int value = list[num].Value;
			if (value > 0)
			{
				PathPoint a;
				PathPoint b;
				if (value == 2 && IsOnStraightLine(key, out a, out b, key.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => p.Contains(x.Key), (KeyValuePair<PathPoint, float> x) => x.Key)))
				{
					MergePathPoint(a, key, b, false);
					hashSet.Add(a);
					continue;
				}
				for (int num3 = 0; num3 < key.Connections.Count; num3++)
				{
					PathPoint key3 = key.Connections[num3].Key;
					if (p.Contains(key3))
					{
						key.RemoveConnection(key3);
						key3.RemoveConnection(key);
						num3--;
					}
				}
				key.ClearNode();
				hashSet.Add(key.Connections.First((KeyValuePair<PathPoint, float> x) => !p.Contains(x.Key)).Key);
				hashSet2.Add(key);
				p.Remove(key);
			}
			else
			{
				DeletePoint(key);
			}
		}
		foreach (PathPoint item in hashSet2)
		{
			if (item.Connections.Count < 2 && item.ConnectedSegmentCount == 0)
			{
				EnqeueEndPoint(item);
			}
		}
		BuildMesh(hashSet.ToHashSet());
		FindAllPaths(hashSet);
	}

	public PathPoint SplitPath(PathPoint a, PathPoint b, Vector2 pos, PathPoint res = null, bool? bezier = null)
	{
		res = res ?? new PathPoint(pos, ref IDCounter, bezier ?? (a.Bezier || b.Bezier));
		a.RemoveConnection(b);
		b.RemoveConnection(a);
		res.AddConnection(a);
		res.AddConnection(b);
		AllPoints.Add(res);
		return res;
	}

	public float AddPath(List<Vector2> path, bool bezier, uint[] ids = null, Color? col = null, string mat = null)
	{
		for (int i = 0; i < path.Count - 1; i++)
		{
			if ((path[i] - path[i + 1]).sqrMagnitude < 1f)
			{
				path.RemoveAt(i);
				i--;
			}
		}
		if (path.Count > 2)
		{
			Vector2 vector = (path[1] - path[0]).normalized;
			for (int j = 1; j < path.Count - 1; j++)
			{
				Vector2 normalized = (path[j + 1] - path[j]).normalized;
				if (vector == normalized)
				{
					path.RemoveAt(j);
					j--;
				}
				else
				{
					vector = normalized;
				}
			}
		}
		if (path.Count < 2)
		{
			return 0f;
		}
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		HashSet<PathPoint> hashSet2 = new HashSet<PathPoint>();
		List<PathPoint> list = new List<PathPoint>(path.Count);
		GrassSystem.Instance.InvalidateArea();
		PathPoint shortA = null;
		PathPoint shortB = null;
		for (int k = 0; k < path.Count; k++)
		{
			if (ids != null)
			{
				int i2 = k;
				PathPoint pathPoint = AllPoints.FirstOrDefault((PathPoint x) => x.ID == ids[i2]);
				if (pathPoint != null)
				{
					list.Add(pathPoint);
					hashSet2.Add(pathPoint);
					continue;
				}
			}
			Vector2 p = path[k];
			PathPoint[] array = GetPath(ref p, 4f, ids != null);
			if (array != null && k > 0 && array[0] == list[k - 1])
			{
				if (p == list[k - 1].Point)
				{
					continue;
				}
				array = null;
			}
			if (array != null)
			{
				if (array.Length == 1)
				{
					PathPoint pathPoint2 = array[0];
					bool flag = false;
					if (array[0].ConnectedSegmentCount == 0)
					{
						int num = ((k == 0) ? 1 : ((k == path.Count - 1) ? (-1) : 0));
						if (array[0].Connections.Count == 1 && num != 0 && (array[0].Connections[0].Key.Point - array[0].Point).normalized == (path[k] - path[k + num]).normalized)
						{
							if (num == 1)
							{
								shortA = array[0];
							}
							else
							{
								shortB = array[0];
							}
							pathPoint2 = array[0].Connections[0].Key;
							DeletePoint(array[0]);
							flag = true;
						}
					}
					pathPoint2.ClearNode();
					if (!flag)
					{
						RemoveEndPoint(pathPoint2);
					}
					list.Add(pathPoint2);
					hashSet2.Add(pathPoint2);
				}
				else
				{
					PathPoint pathPoint3 = ((ids == null) ? new PathPoint(p, ref IDCounter, bezier) : new PathPoint(p, bezier, ids[k]));
					SplitPath(array[0], array[1], p, pathPoint3);
					hashSet2.Add(pathPoint3);
					list.Add(pathPoint3);
					if (col.HasValue)
					{
						pathPoint3.Color = col.Value;
						pathPoint3.Material = mat;
					}
				}
			}
			else
			{
				PathPoint pathPoint4 = ((ids == null) ? new PathPoint(path[k], ref IDCounter, bezier) : new PathPoint(path[k], bezier, ids[k]));
				list.Add(pathPoint4);
				AllPoints.Add(pathPoint4);
				if (col.HasValue)
				{
					pathPoint4.Color = col.Value;
					pathPoint4.Material = mat;
				}
				if (k == 0 || k == path.Count - 1)
				{
					EndPointQueue.Add(pathPoint4);
					hashSet.Add(pathPoint4);
				}
			}
		}
		for (int num2 = 0; num2 < AllPoints.Count; num2++)
		{
			PathPoint pathPoint5 = AllPoints[num2];
			for (int num3 = 0; num3 < list.Count - 1; num3++)
			{
				Vector2 res;
				if (pathPoint5 != list[num3] && pathPoint5 != list[num3 + 1] && Utilities.ProjectToLine(pathPoint5.Point, list[num3].Point, list[num3 + 1].Point, out res) && (pathPoint5.Point - res).sqrMagnitude < 1f)
				{
					RemoveEndPoint(pathPoint5);
					pathPoint5.ClearNode();
					hashSet.Remove(pathPoint5);
					hashSet2.Add(pathPoint5);
					list.Insert(num3 + 1, pathPoint5);
					break;
				}
			}
		}
		for (int num4 = 0; num4 < list.Count - 1; num4++)
		{
			list[num4].AddConnection(list[num4 + 1]);
		}
		for (int num5 = 0; num5 < AllPoints.Count; num5++)
		{
			PathPoint pathPoint6 = AllPoints[num5];
			int num6 = list.IndexOf(pathPoint6);
			for (int num7 = 0; num7 < pathPoint6.Connections.Count; num7++)
			{
				PathPoint key = pathPoint6.Connections[num7].Key;
				if (pathPoint6.ID <= key.ID)
				{
					continue;
				}
				int num8 = list.IndexOf(key);
				for (int num9 = 0; num9 < list.Count - 1; num9++)
				{
					if (pathPoint6 == list[num9] || pathPoint6 == list[num9 + 1] || key == list[num9] || key == list[num9 + 1])
					{
						continue;
					}
					Vector2? lineIntersection = Utilities.GetLineIntersection(pathPoint6.Point, key.Point, list[num9].Point, list[num9 + 1].Point, false);
					if (!lineIntersection.HasValue)
					{
						continue;
					}
					Vector2 p2 = lineIntersection.Value;
					PathPoint[] path2 = GetPath(ref p2, 1f);
					PathPoint pathPoint7;
					if (path2 != null && path2.Length == 1)
					{
						pathPoint7 = path2[0];
						if (pathPoint7 == pathPoint6 || pathPoint7 == key)
						{
							continue;
						}
						int num10 = AllPoints.IndexOf(pathPoint7);
						if (num10 < num5)
						{
							num5--;
							AllPoints.RemoveAt(num10);
							AllPoints.Add(pathPoint7);
						}
					}
					else
					{
						pathPoint7 = SplitPath(list[num9], list[num9 + 1], lineIntersection.Value, null, bezier);
						list.Insert(num9 + 1, pathPoint7);
					}
					if (num6 >= 0 && num8 >= 0 && Mathf.Abs(num6 - num8) == 1)
					{
						list.Insert(Mathf.Max(num6, num8), pathPoint7);
					}
					num6 = list.IndexOf(pathPoint6);
					pathPoint6.RemoveConnection(key);
					key.RemoveConnection(pathPoint6);
					pathPoint6.AddConnection(pathPoint7);
					key.AddConnection(pathPoint7);
					num7--;
					break;
				}
			}
		}
		foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
		{
			bool flag2 = false;
			if (!roomSegment.IsConnectedToOutside() || roomSegment.ConnectedPath != null)
			{
				continue;
			}
			Vector2 vector2 = roomSegment.transform.position.FlattenVector3();
			for (int num11 = 0; num11 < list.Count; num11++)
			{
				if ((list[num11].Point - vector2).sqrMagnitude < PathSegSnapDist && roomSegment.IsOnOutside(list[num11].Point))
				{
					list[num11].ConnectSegment(roomSegment);
					RemoveEndPoint(list[num11]);
					hashSet2.Remove(list[num11]);
					hashSet.Add(list[num11]);
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				continue;
			}
			for (int num12 = 0; num12 < list.Count - 1; num12++)
			{
				PathPoint pathPoint8 = list[num12];
				PathPoint pathPoint9 = list[num12 + 1];
				Vector2 res2;
				if (Utilities.ProjectToLine(vector2, pathPoint8.Point, pathPoint9.Point, out res2) && (vector2 - res2).sqrMagnitude < PathSegSnapDist && roomSegment.IsOnOutside(res2))
				{
					PathPoint pathPoint10 = SplitPath(pathPoint8, pathPoint9, res2, null, bezier);
					pathPoint10.ConnectSegment(roomSegment);
					list.Insert(num12 + 1, pathPoint10);
					hashSet.Add(pathPoint10);
					break;
				}
			}
		}
		List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
		RemoveTrees(list, list2);
		if (hashSet2.Count > 0)
		{
			HashSet<PathPoint> visited = new HashSet<PathPoint>();
			while (hashSet2.Count > 0)
			{
				FindGroup(hashSet2.First(), visited, hashSet, hashSet2);
			}
		}
		RoomStyle roomStyle = (MaterialPreviewer.Instance.GetActiveStyle() as RoomStyle) ?? GameSettings.Instance.DefaultPathStyle;
		BuildMesh(list.ToHashSet(), null, roomStyle.OutsideMat, roomStyle.OutsideColor, roomStyle.OutsideColor2 ?? roomStyle.OutsideColor.GetDefaultSecondaryColor());
		FindPaths(hashSet);
		float num13 = 0f;
		for (int num14 = 0; num14 < list.Count - 1; num14++)
		{
			num13 += PathBuilder.GetCost(list[num14].Point, list[num14 + 1].Point);
		}
		if (ids == null)
		{
			list2.Add(new UndoObject.UndoAction(num13, list, shortA, shortB));
			GameSettings.Instance.AddUndo(list2.ToArray());
		}
		return num13;
	}

	private void RemoveTrees(IList<PathPoint> points, List<UndoObject.UndoAction> undos)
	{
		Rect area = Utilities.GetBounds(points.SelectInPlace((PathPoint x) => x.Point)).Expand(4f, 4f);
		HashSet<TreeInstance> hashSet = new HashSet<TreeInstance>();
		foreach (TreeInstance item in GameSettings.Instance.TreeTree.Query(area))
		{
			Vector2 vector = item.Position.ToVector2Z();
			float num = 1f + (item.Bounds.size.FlattenVector3() * 0.5f).sqrMagnitude;
			for (int num2 = 0; num2 < points.Count; num2++)
			{
				PathPoint pathPoint = points[num2];
				if ((pathPoint.Point - vector).sqrMagnitude < num)
				{
					hashSet.Add(item);
					break;
				}
				bool flag = false;
				for (int num3 = 0; num3 < pathPoint.Connections.Count; num3++)
				{
					PathPoint key = pathPoint.Connections[num3].Key;
					Vector2 res;
					if (pathPoint.ID > key.ID && Utilities.ProjectToLine(vector, pathPoint.Point, key.Point, out res) && (res - vector).sqrMagnitude < num)
					{
						hashSet.Add(item);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		if (hashSet.Count <= 0)
		{
			return;
		}
		if (undos != null)
		{
			undos.Add(new UndoObject.UndoAction(hashSet.ToArray(), true));
		}
		foreach (TreeInstance item2 in hashSet)
		{
			GameSettings.Instance.RemoveTree(item2);
		}
	}

	private void FindAllPaths(HashSet<PathPoint> needsFullPathing)
	{
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		HashSet<PathPoint> visited = new HashSet<PathPoint>();
		while (needsFullPathing.Count > 0)
		{
			FindGroup(needsFullPathing.First(), visited, hashSet, needsFullPathing);
		}
		FindPaths(hashSet);
	}

	private void CreatePathObject(HashSet<PathPoint> points, MeshCombiner builder, HashSet<PathObject> used, string mat, Color? c)
	{
		if (!builder.HasData())
		{
			return;
		}
		PathObject pathObject = used.FirstOrDefault((PathObject x) => x.Path.Count == 0);
		if (pathObject != null)
		{
			pathObject.Path.Clear();
			pathObject.Path.AddRange(points);
		}
		else
		{
			pathObject = UnityEngine.Object.Instantiate(BuildController.Instance.PathObjectPrefab);
			pathObject.Path.AddRange(points);
			AllPathObjects.Add(pathObject);
		}
		if (mat != null && c.HasValue)
		{
			pathObject.MatColor = c.Value;
			pathObject.Material = mat;
		}
		else if (points.Any((PathPoint x) => x.Color.HasValue))
		{
			pathObject.MatColor = points.Where((PathPoint x) => x.Color.HasValue).Mode((PathPoint x) => x.Color.Value);
			pathObject.Material = points.Where((PathPoint x) => x.Material != null).Mode((PathPoint x) => x.Material);
		}
		foreach (PathPoint point in points)
		{
			point.Color = pathObject.MatColor;
			point.Material = pathObject.Material;
		}
		Mesh mesh = builder.CreateMesh(new Vector2(pathObject.ColorID, RoomMaterialController.GetMaterialID(pathObject.Material)));
		pathObject.SetMesh(mesh);
		pathObject.Dirty = false;
		foreach (PathPoint point2 in points)
		{
			point2.ParentObject = pathObject;
		}
		builder.Clear("Path");
	}

	private void BuildMesh(HashSet<PathPoint> affected = null, MeshCombiner builder = null, string mat = null, Color? c = null, Color? c2 = null)
	{
		HashSet<PathPoint> hashSet = affected ?? new HashSet<PathPoint>(AllPoints);
		ClearCache(hashSet);
		HashSet<PathObject> hashSet2 = new HashSet<PathObject>();
		HashSet<PathPoint> hashSet3 = new HashSet<PathPoint>();
		builder = builder ?? new MeshCombiner("Path", true, false);
		for (int i = 0; i < AllPoints.Count; i++)
		{
			PathPoint pathPoint = AllPoints[i];
			if (hashSet.Contains(pathPoint))
			{
				hashSet2.Clear();
				hashSet3.Clear();
				BuildMeshSub(pathPoint, hashSet, hashSet3, builder, hashSet2);
				CreatePathObject(hashSet3, builder, hashSet2, mat, c);
			}
		}
		while (hashSet.Count > 0)
		{
			hashSet2.Clear();
			hashSet3.Clear();
			PathPoint pathPoint2 = hashSet.First();
			BuildMeshLoop(pathPoint2, hashSet, hashSet3, builder, hashSet2, pathPoint2);
			CreatePathObject(hashSet3, builder, hashSet2, mat, c);
		}
		for (int j = 0; j < AllPathObjects.Count; j++)
		{
			if (!AllPathObjects[j].Dirty)
			{
				continue;
			}
			PathObject pathObject = AllPathObjects[j];
			if (pathObject.Path.Count == 0)
			{
				if (SelectorController.Instance.Selected.Remove(pathObject))
				{
					SelectorController.Instance.DoPostSelectChecks();
				}
				pathObject.DestroyGO();
				AllPathObjects.RemoveAt(j);
				j--;
			}
			else
			{
				hashSet.AddRange(pathObject.Path);
			}
		}
		if (hashSet.Count > 0)
		{
			BuildMesh(hashSet, builder, mat, c, c2);
		}
	}

	private void ClearPathParent(PathPoint a, HashSet<PathObject> used)
	{
		if (a.ParentObject != null)
		{
			a.ParentObject.Dirty = true;
			used.Add(a.ParentObject);
			a.ParentObject.Path.Remove(a);
			a.ParentObject = null;
		}
	}

	private void BuildMeshLoop(PathPoint a, HashSet<PathPoint> left, HashSet<PathPoint> added, MeshCombiner combiner, HashSet<PathObject> used, PathPoint original, PathPoint from = null)
	{
		left.Remove(a);
		if (a.Connections.Count == 2)
		{
			added.Add(a);
			ClearPathParent(a, used);
			a.CachedLast = from;
			PathPoint pathPoint = a.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => x.Key != from, (KeyValuePair<PathPoint, float> x) => x.Key);
			if (pathPoint == original)
			{
				BuildPath(a, original, combiner, true);
			}
			else
			{
				BuildMeshLoop(pathPoint, left, added, combiner, used, original, a);
			}
		}
	}

	private void BuildMeshSub(PathPoint a, HashSet<PathPoint> left, HashSet<PathPoint> added, MeshCombiner combiner, HashSet<PathObject> used, PathPoint from = null)
	{
		if (a.Connections.Count > 2)
		{
			if (from != null)
			{
				BuildPath(from, a, combiner, false);
			}
			if (added.Contains(a))
			{
				return;
			}
			ClearPathParent(a, used);
			left.Remove(a);
			added.Add(a);
			BuildIntersection(a, combiner);
			for (int i = 0; i < a.Connections.Count; i++)
			{
				if (a.Connections[i].Key != from)
				{
					BuildMeshSub(a.Connections[i].Key, left, added, combiner, used, a);
				}
			}
		}
		else if (from != null)
		{
			ClearPathParent(a, used);
			added.Add(a);
			left.Remove(a);
			if (a.Connections.Count == 1)
			{
				BuildPath(from, a, combiner, false);
				return;
			}
			a.CachedLast = from;
			BuildMeshSub(a.Connections.FirstOrDefaultOf((KeyValuePair<PathPoint, float> x) => x.Key != from, (KeyValuePair<PathPoint, float> x) => x.Key), left, added, combiner, used, a);
		}
		else if (a.Connections.Count == 1)
		{
			ClearPathParent(a, used);
			added.Add(a);
			left.Remove(a);
			BuildMeshSub(a.Connections[0].Key, left, added, combiner, used, a);
		}
	}

	private float DeltaAngle(float from, float to)
	{
		if (to < from)
		{
			return (float)Math.PI * 2f + (to - from);
		}
		return to - from;
	}

	private bool AngleBetween(float a, float p, float b)
	{
		if (p < 0f)
		{
			p = (float)Math.PI * 2f + p;
		}
		if (!p.IsBetween(a, b))
		{
			return (p % ((float)Math.PI * 2f)).IsBetween(a, b);
		}
		return true;
	}

	private void BuildIntersection(PathPoint intersection, MeshCombiner combiner)
	{
		List<float> list = new List<float>();
		Vector2 point = intersection.Point;
		float num = (float)Math.PI * 2f;
		for (int i = 0; i < intersection.Connections.Count; i++)
		{
			Vector2 point2 = intersection.Connections[i].Key.Point;
			float num2 = Mathf.Atan2(point2.y - point.y, point2.x - point.x);
			list.Add((num2 < 0f) ? (num + num2) : num2);
		}
		list.Sort();
		float num3 = (float)Math.PI / 4f;
		float num4 = list[list.Count - 1] + num3;
		List<Vector2> list2 = new List<Vector2> { point };
		float num5 = Mathf.Sqrt(2f);
		for (int j = 0; j < list.Count; j++)
		{
			float num6 = list[j];
			float num7 = list[(j + 1) % list.Count];
			float p = num7 - num3;
			float num8 = num6 - num3;
			float num9 = num6 + num3;
			if (AngleBetween(num8, num4, num9))
			{
				num8 = ((j == 0) ? ((num4 + num8 + num) * 0.5f) : ((num4 + num8) * 0.5f));
			}
			list2.Add(point + new Vector2(Mathf.Cos(num8), Mathf.Sin(num8)) * num5);
			if (!AngleBetween(num8, p, num9))
			{
				list2.Add(point + new Vector2(Mathf.Cos(num9), Mathf.Sin(num9)) * num5);
			}
			float num10 = ((j == list.Count - 1) ? (num - num6 + num7) : (num7 - num6));
			if (!Mathf.Approximately(num10, (float)Math.PI) && num10 > (float)Math.PI)
			{
				float f = num6 + num10 * 0.5f;
				float num11 = num10.MapRange((float)Math.PI, 4.712389f, 1f, num5, true);
				list2.Add(point + new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * num11);
			}
			num4 = num9;
		}
		combiner.AddTriangleFlatFan(list2, 0f, false);
	}

	private void BuildPath(PathPoint start, PathPoint extra, MeshCombiner combiner, bool loop)
	{
		List<PathPoint> list = new List<PathPoint>();
		list.Add(extra);
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		while (start != null && !hashSet.Contains(start))
		{
			list.Add(start);
			hashSet.Add(start);
			start = start.CachedLast;
		}
		List<Vector2> list2 = new List<Vector2>();
		GetFullPath(list, list2);
		bool flag = false;
		bool flag2 = false;
		if (!loop)
		{
			if (list[0].Connections.Count == 1 && (list[0].Bezier || list[0].ConnectedSegmentCount > 0))
			{
				CapPath(list[0], combiner);
				flag = true;
			}
			if (list[list.Count - 1].Connections.Count == 1 && (list[list.Count - 1].Bezier || list[list.Count - 1].ConnectedSegmentCount > 0))
			{
				CapPath(list[list.Count - 1], combiner);
				flag2 = true;
			}
		}
		Vector2[] array = new Vector2[list2.Count * 2];
		int[] array2 = new int[(list2.Count - 1) * 6];
		Vector2 vector = (loop ? (Utilities.GetOffset(list2[list2.Count - 2], list2[0], list2[1], 1f, true) - list2[0]) : (list[1].Point - list[0].Point).Turn90().normalized);
		Vector2 vector2 = ((!loop && !flag && list[0].Connections.Count == 1) ? (list2[0] + (list2[0] - list2[1]).normalized) : list2[0]);
		array[0] = vector2 - vector;
		array[1] = vector2 + vector;
		for (int i = 0; i < list2.Count - 1; i++)
		{
			array2[i * 6] = i * 2;
			array2[i * 6 + 1] = i * 2 + 1;
			array2[i * 6 + 2] = i * 2 + 3;
			array2[i * 6 + 3] = i * 2 + 3;
			array2[i * 6 + 4] = i * 2 + 2;
			array2[i * 6 + 5] = i * 2;
		}
		for (int j = 1; j < list2.Count - 1; j++)
		{
			Vector2 first = list2[j - 1];
			Vector2 vector3 = list2[j];
			Vector2 third = list2[j + 1];
			Vector2 vector4 = Utilities.GetOffset(first, vector3, third, 1f, true) - vector3;
			if (vector4.sqrMagnitude > 16f)
			{
				vector4 = vector4.normalized * 4f;
			}
			array[j * 2] = vector3 - vector4;
			array[j * 2 + 1] = vector3 + vector4;
		}
		Vector2 vector5 = (loop ? vector : (list[list.Count - 1].Point - list[list.Count - 2].Point).Turn90().normalized);
		Vector2 vector6 = ((!loop && !flag2 && list[list.Count - 1].Connections.Count == 1) ? (list2[list2.Count - 1] + (list2[list2.Count - 1] - list2[list2.Count - 2]).normalized) : list2[list2.Count - 1]);
		array[array.Length - 2] = vector6 - vector5;
		array[array.Length - 1] = vector6 + vector5;
		combiner.AddFlatMesh(array, array2, 0f);
	}

	private void CapPath(PathPoint p, MeshCombiner combiner)
	{
		Vector2 point = p.Point;
		Vector2 point2 = p.Connections[0].Key.Point;
		float startAngle = Mathf.Atan2(point2.y - point.y, point2.x - point.x) + (float)Math.PI / 2f;
		combiner.AddTriangleFlatFan(point, startAngle, 180f, 1f, 8, 0f);
	}

	private void FindPaths(HashSet<PathPoint> newEndPoints)
	{
		if (newEndPoints.Count == 0)
		{
			return;
		}
		List<PathPoint> list = new List<PathPoint>();
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		HashSet<PathPoint> hashSet2 = new HashSet<PathPoint>();
		List<PathPoint> list2 = new List<PathPoint>();
		while (newEndPoints.Count > 0)
		{
			list.Clear();
			hashSet2.Clear();
			hashSet.Clear();
			FindGroup(newEndPoints.First(), hashSet, hashSet2, newEndPoints, list);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].ClearNode();
				list[i].InitializeNode();
			}
			for (int j = 0; j < list.Count; j++)
			{
				ClearCache(hashSet);
				PathPoint pathPoint = list[j];
				hashSet2.Remove(pathPoint);
				if (hashSet2.Count <= 0)
				{
					continue;
				}
				Dijkstra(pathPoint, 0f);
				foreach (PathPoint item in hashSet2)
				{
					list2.Clear();
					ConstructPath(item, pathPoint, list2);
					item.CachePath(pathPoint, list2, false);
					pathPoint.CachePath(item, list2, true);
				}
			}
		}
	}

	private void ConstructPath(PathPoint from, PathPoint to, List<PathPoint> path)
	{
		if (from != null)
		{
			path.Add(from);
			if (from != to)
			{
				ConstructPath(from.CachedLast, to, path);
			}
		}
	}

	private void ClearCache(HashSet<PathPoint> nodes)
	{
		foreach (PathPoint node in nodes)
		{
			node.CachedLast = null;
			node.CachedDist = float.PositiveInfinity;
		}
	}

	private void FindGroup(PathPoint root, HashSet<PathPoint> visited, HashSet<PathPoint> missing, HashSet<PathPoint> newEndPoints = null, List<PathPoint> result = null)
	{
		if (!visited.Contains(root))
		{
			if (root.NeedsPathing())
			{
				missing.Add(root);
			}
			visited.Add(root);
			if (newEndPoints != null && newEndPoints.Remove(root) && result != null)
			{
				result.Add(root);
			}
			for (int i = 0; i < root.Connections.Count; i++)
			{
				FindGroup(root.Connections[i].Key, visited, missing, newEndPoints, result);
			}
		}
	}

	private void Dijkstra(PathPoint node, float dist, PathPoint from = null)
	{
		node.CachedDist = dist;
		node.CachedLast = from;
		for (int i = 0; i < node.Connections.Count; i++)
		{
			KeyValuePair<PathPoint, float> keyValuePair = node.Connections[i];
			if (keyValuePair.Key != from)
			{
				float num = dist + keyValuePair.Value;
				if (num < keyValuePair.Key.CachedDist)
				{
					Dijkstra(keyValuePair.Key, num, node);
				}
			}
		}
	}

	public PathPoint[] GetPath(ref Vector2 p, float dist2, bool onlySegment = false)
	{
		float num = dist2;
		PathPoint pathPoint = null;
		if (!onlySegment)
		{
			for (int i = 0; i < AllPoints.Count; i++)
			{
				PathPoint pathPoint2 = AllPoints[i];
				float sqrMagnitude = (pathPoint2.Point - p).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					pathPoint = pathPoint2;
				}
			}
			if (pathPoint != null)
			{
				return new PathPoint[1] { pathPoint };
			}
		}
		PathPoint pathPoint3 = null;
		for (int j = 0; j < AllPoints.Count; j++)
		{
			PathPoint pathPoint4 = AllPoints[j];
			for (int k = 0; k < pathPoint4.Connections.Count; k++)
			{
				PathPoint key = pathPoint4.Connections[k].Key;
				Vector2 res;
				if (pathPoint4.ID > key.ID && Utilities.ProjectToLine(p, pathPoint4.Point, key.Point, out res))
				{
					float sqrMagnitude2 = (res - p).sqrMagnitude;
					if (sqrMagnitude2 < num)
					{
						num = sqrMagnitude2;
						pathPoint = pathPoint4;
						pathPoint3 = key;
						p = res;
					}
				}
			}
		}
		if (pathPoint == null)
		{
			return null;
		}
		return new PathPoint[2] { pathPoint, pathPoint3 };
	}

	public PathPoint GetPathFirst(Vector2 p, float dist2)
	{
		for (int i = 0; i < AllPoints.Count; i++)
		{
			PathPoint pathPoint = AllPoints[i];
			if ((pathPoint.Point - p).sqrMagnitude < dist2)
			{
				return pathPoint;
			}
		}
		for (int j = 0; j < AllPoints.Count; j++)
		{
			PathPoint pathPoint2 = AllPoints[j];
			for (int k = 0; k < pathPoint2.Connections.Count; k++)
			{
				PathPoint key = pathPoint2.Connections[k].Key;
				Vector2 res;
				if (pathPoint2.ID > key.ID && Utilities.ProjectToLine(p, pathPoint2.Point, key.Point, out res) && (res - p).sqrMagnitude < dist2)
				{
					return pathPoint2;
				}
			}
		}
		return null;
	}

	public WriteDictionary Serialize(WriteDictionary data, List<PathPoint> points = null)
	{
		Dictionary<PathObject, int> dictionary = new Dictionary<PathObject, int>();
		Dictionary<PathPoint, SaveNode> dictionary2 = new Dictionary<PathPoint, SaveNode>();
		int pIDX = 0;
		points = points ?? AllPoints;
		int num = 0;
		for (int i = 0; i < points.Count; i++)
		{
			PathPoint pathPoint = points[i];
			if (pathPoint.ParentObject != null)
			{
				dictionary2[pathPoint] = new SaveNode(pathPoint, dictionary2, dictionary, ref pIDX);
			}
			else
			{
				num++;
			}
		}
		if (num > 0)
		{
			Debug.Log(num + " path points didn't have a parent object");
		}
		data["PathColors"] = ((IEnumerable<KeyValuePair<PathObject, int>>)dictionary).Select((Func<KeyValuePair<PathObject, int>, SVector3>)((KeyValuePair<PathObject, int> x) => x.Key.MatColor)).ToArray();
		data["PathColors2"] = ((IEnumerable<KeyValuePair<PathObject, int>>)dictionary).Select((Func<KeyValuePair<PathObject, int>, SVector3>)((KeyValuePair<PathObject, int> x) => x.Key.MatColor2)).ToArray();
		data["PathMats"] = dictionary.Select((KeyValuePair<PathObject, int> x) => x.Key.Material).ToArray();
		data["PathPoints"] = dictionary2.Select((KeyValuePair<PathPoint, SaveNode> x) => x.Value).ToArray();
		return data;
	}

	public void Deserialize(WriteDictionary data)
	{
		TimeProbe.BeginTime("Path rebuild time:");
		SVector3[] array = data.Get("PathColors", new SVector3[0]);
		SVector3[] array2 = data.Get<SVector3[]>("PathColors2", null);
		string[] array3 = data.Get("PathMats", new string[0]);
		SaveNode[] source = data.Get("PathPoints", new SaveNode[0]);
		Dictionary<SaveNode, PathPoint> dictionary = new Dictionary<SaveNode, PathPoint>();
		HashSet<PathPoint> hashSet = new HashSet<PathPoint>();
		uint num = 0u;
		foreach (IGrouping<int, SaveNode> item in from x in source
			group x by x.GroupIDX)
		{
			int num2 = 0;
			dictionary.Clear();
			hashSet.Clear();
			foreach (SaveNode item2 in item)
			{
				num2 = item2.GroupIDX;
				PathPoint pathPoint = new PathPoint(item2.P, item2.Bezier, item2.ID);
				if (item2.ID > num)
				{
					num = item2.ID;
				}
				AllPoints.Add(pathPoint);
				dictionary[item2] = pathPoint;
				if (item2.EndPoint)
				{
					hashSet.Add(pathPoint);
				}
				for (int num3 = 0; num3 < item2.Connections.Count; num3++)
				{
					pathPoint.AddConnection(dictionary[item2.Connections[num3]]);
				}
				for (int num4 = 0; num4 < item2.SegmentID.Length; num4++)
				{
					RoomSegment roomSegment = Writeable.STGetDeserializedObject(item2.SegmentID[num4]) as RoomSegment;
					if (roomSegment != null)
					{
						pathPoint.ConnectSegment(roomSegment);
					}
				}
			}
			foreach (PathPoint item3 in hashSet)
			{
				if (item3.Connections.Count == 1 && item3.ConnectedSegmentCount == 0)
				{
					EndPointQueue.Add(item3);
				}
			}
			FindPaths(hashSet);
			BuildMesh(dictionary.Values.ToHashSet(), null, array3[num2], array[num2], (array2 != null) ? array2[num2] : array[num2].GetDefaultSecondaryColor());
		}
		if (num + 1 > IDCounter)
		{
			IDCounter = num + 1;
		}
		GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
		TimeProbe.FinalizeTime("Path rebuild time:");
	}
}
