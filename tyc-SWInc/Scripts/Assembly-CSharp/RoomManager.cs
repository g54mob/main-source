using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ClipperLib;
using SINetworking;
using UnityEngine;

public class RoomManager
{
	public enum RoomBuildState
	{
		Invalid = 0,
		Identical = 1,
		Expand = 2,
		Split = 3
	}

	private class BFSNode<T>
	{
		public BFSNode<T> Parent;

		public T Value;

		public int Distance = int.MaxValue;

		public BFSNode(T val)
		{
			Value = val;
		}
	}

	public class BFSObject
	{
		public Room R;

		public List<Room> rooms;

		public Dictionary<Room, HashSet<Room>> Conn;

		public ThreadCountdown Counter;

		public BFSObject(Room r, List<Room> rooms, Dictionary<Room, HashSet<Room>> conn, ThreadCountdown counter)
		{
			R = r;
			this.rooms = rooms;
			Conn = conn;
			Counter = counter;
		}
	}

	public enum PathAllow
	{
		None = 0,
		Some = 1,
		Full = 2
	}

	public enum ConnectorType
	{
		Other = 0,
		Elevator = 1,
		Portal = 2,
		Furn = 3
	}

	private class ProtoEdge
	{
		public Vector2 Pos;

		public int Iterated;

		public HashSet<ProtoEdge> Links;

		public bool GoOut = true;

		public ProtoEdge(Vector2 pos)
		{
			Pos = pos;
			Links = new HashSet<ProtoEdge>();
		}

		public void UpdateIterate()
		{
			foreach (ProtoEdge link in Links)
			{
				if (!link.Links.Contains(this))
				{
					Iterated++;
				}
			}
			GoOut = Iterated <= 1;
		}
	}

	private class PolygonShell
	{
		public List<Vector2> Polygon;

		public PolygonShell Parent;

		public HashSet<PolygonShell> Children = new HashSet<PolygonShell>();

		public void AddPolys(List<List<Vector2>> result, bool active)
		{
			foreach (PolygonShell child in Children)
			{
				if (active)
				{
					MergePolygons(child.Polygon, Polygon);
				}
				child.AddPolys(result, !active);
			}
			if (active)
			{
				result.Add(Polygon);
			}
		}

		public PolygonShell(List<Vector2> polygon)
		{
			Polygon = polygon;
		}

		public bool IsAlreadyParent(PolygonShell p)
		{
			if (Parent != null)
			{
				if (Parent != p)
				{
					return Parent.IsAlreadyParent(p);
				}
				return true;
			}
			return false;
		}

		public void MakeParent(PolygonShell p)
		{
			if (Parent != null)
			{
				if (Parent.IsAlreadyParent(p))
				{
					return;
				}
				if (Parent.Inside(p))
				{
					Parent.MakeParent(p);
					return;
				}
				Parent.Children.Remove(this);
			}
			Parent = p;
			p.Children.Add(this);
		}

		public bool Inside(PolygonShell other)
		{
			for (int i = 0; i < Polygon.Count; i++)
			{
				if (!Utilities.IsInside(Polygon[i], other.Polygon))
				{
					return false;
				}
			}
			return true;
		}
	}

	public class TeamAssignObject
	{
		public Dictionary<Team, int> TeamDict = new Dictionary<Team, int>();

		public List<Room> Rooms = new List<Room>();

		public Room Outside;

		public void Initialize(ActorManager am, RoomManager rm)
		{
			Rooms.Clear();
			Rooms.AddRange(rm.Rooms);
			Outside = rm.Outside;
			TeamDict.Clear();
			int num = 0;
			foreach (Team value in am.Teams.Values)
			{
				TeamDict[value] = num;
				num++;
			}
			for (int i = 0; i < Rooms.Count; i++)
			{
				Rooms[i].InitializeTeamMask(TeamDict);
			}
		}
	}

	public static int MaxRoomsPerUpdate = 10;

	public Room[] UpdateRooms = new Room[MaxRoomsPerUpdate];

	public List<Room> Rooms = new List<Room>();

	public Dictionary<int, GridAreaQuery<Room>> RoomQuery = new Dictionary<int, GridAreaQuery<Room>>();

	public List<Roof> Roofs = new List<Roof>();

	public List<TemperatureGroup> TempGroups = new List<TemperatureGroup>();

	public static ObjectPool<TemperatureGroup> TempGroupPool = new ObjectPool<TemperatureGroup>(() => new TemperatureGroup(), null, delegate(TemperatureGroup x)
	{
		x.Clear();
	});

	public List<CCTVGroup> CCGroups = new List<CCTVGroup>();

	public static ObjectPool<CCTVGroup> CCGroupPool = new ObjectPool<CCTVGroup>(() => new CCTVGroup(), null, delegate(CCTVGroup x)
	{
		x.Clear();
	});

	public HashSet<WallEdge> AllSegments = new HashSet<WallEdge>();

	public HashSet<RoomSegment> RoomSegments = new HashSet<RoomSegment>();

	public HashList<Furniture> AllFurniture = new HashList<Furniture>();

	public HashSet<int> DirtyCombineFloors = new HashSet<int>();

	private Dictionary<Room, List<KeyValuePair<Room, int>>> ConnectedRooms = new Dictionary<Room, List<KeyValuePair<Room, int>>>();

	private Dictionary<int, Dictionary<Selectable, Vector2[]>> RoomSupport = new Dictionary<int, Dictionary<Selectable, Vector2[]>>();

	public Dictionary<byte, PlayerMap> PlayerMaps = new Dictionary<byte, PlayerMap>();

	public Room Outside;

	public Room CameraRoom;

	public PathController PathController = new PathController();

	public bool DisableMeshRebuild;

	public bool RoomNearnessDirty;

	public int RoomRoadDirty = -1;

	public bool TemperatureControlDirty;

	public bool CCTVDirty;

	private bool _teamText;

	public bool TeamAssignmentDirty = true;

	public bool TeamAssignmentRunning;

	public bool CacheRoomConnection;

	private List<KeyValuePair<Room, int>> EmptyConnection = new List<KeyValuePair<Room, int>>();

	private bool BFSStarted;

	public uint BFSTotal = 1u;

	public uint BFSDone;

	private object BFSLock = new object();

	private static ObjectPool<List<int>> _traverseActualPool = new ObjectPool<List<int>>(() => new List<int>(), delegate(List<int> x)
	{
		x.Clear();
	});

	public HashSet<int> RoofOffsetCheck = new HashSet<int>();

	private static Dictionary<object, int> _fixPathCache = new Dictionary<object, int>();

	private List<PathNode<Vector3>> _visitedCache = new List<PathNode<Vector3>>();

	private List<RoomCon> _conCache = new List<RoomCon>();

	private List<PathNode<Vector3>> _cachedRoomPath = new List<PathNode<Vector3>>();

	private TeamAssignObject _teamAssignObject = new TeamAssignObject();

	public bool TeamText
	{
		get
		{
			return _teamText;
		}
		set
		{
			_teamText = value;
			Rooms.ForEach(delegate(Room x)
			{
				x.TeamText.gameObject.SetActive(value);
				x.RoleText.gameObject.SetActive(value);
			});
		}
	}

	public List<KeyValuePair<Room, int>> GetConnectedRooms(Room r)
	{
		if (r != null)
		{
			lock (BFSLock)
			{
				List<KeyValuePair<Room, int>> value;
				if (ConnectedRooms.TryGetValue(r, out value))
				{
					return value;
				}
			}
		}
		return EmptyConnection;
	}

	public IEnumerable<Furniture> GetFurniture(string type)
	{
		for (int i = 0; i < AllFurniture.Count; i++)
		{
			Furniture furniture = AllFurniture[i];
			if (type.Equals(furniture.Type))
			{
				yield return furniture;
			}
		}
	}

	public void UpdateSupport(int floor)
	{
		Dictionary<Selectable, Vector2[]> dictionary = new Dictionary<Selectable, Vector2[]>();
		foreach (Room item in Rooms.Where((Room x) => x.Floor == floor && !x.Outdoors))
		{
			List<List<IntPoint>> list = Clipper.SimplifyPolygon((from x in item.GetExpanded(-4.01f)
				select new IntPoint(x.x * 100f, x.y * 100f)).ToList(), PolyFillType.pftPositive);
			if (list.Count > 0)
			{
				dictionary[item] = list[0].Select((IntPoint x) => new Vector2((float)x.X / 100f, (float)x.Y / 100f)).ToArray();
			}
		}
		foreach (Furniture item2 in Outside.GetFurniture("Column"))
		{
			if (item2.SnapPoints[0].MainUsedBy == null && Mathf.FloorToInt(item2.OriginalPosition.y / 2f) == floor)
			{
				dictionary[item2] = new Rect(item2.OriginalPosition.x - 4f, item2.OriginalPosition.z - 4f, 8f, 8f).ToPolygon();
			}
		}
		RoomSupport[floor] = dictionary;
	}

	public void UpdateSupport(Room r)
	{
		if (r.Floor <= -1)
		{
			return;
		}
		Dictionary<Selectable, Vector2[]> value;
		if (!RoomSupport.TryGetValue(r.Floor, out value))
		{
			value = (RoomSupport[r.Floor] = new Dictionary<Selectable, Vector2[]>());
		}
		List<List<IntPoint>> list = Clipper.SimplifyPolygon((from x in r.GetExpanded(-4.01f)
			select new IntPoint(x.x * 100f, x.y * 100f)).ToList(), PolyFillType.pftPositive);
		if (list.Count > 0)
		{
			value[r] = list[0].Select((IntPoint x) => new Vector2((float)x.X / 100f, (float)x.Y / 100f)).ToArray();
		}
	}

	public void ChangeFloor()
	{
		for (int i = 0; i < Rooms.Count; i++)
		{
			Rooms[i].UpdateVisibility();
			Rooms[i].UpdateAllMaterials();
		}
		RoadManager.Instance.UpdateRoadVisibility();
		RoomMaterialController.UpdateCutoffMat();
		GameSettings.Instance.UpdateGridVisibility();
		GameSettings.Instance.UpdateCutoffShaders();
		RoomMaterialController.Instance.StandardRoof.SetFloat("_SnowFactor", (GameSettings.Instance.ActiveFloor < 0) ? 0f : 1f);
		GameSettings.Instance.LODDirty = true;
		TimeOfDay.Instance.UpdateProbeState();
	}

	public void RecalculateAllDirtyTableGroups()
	{
		for (int i = 0; i < Rooms.Count; i++)
		{
			Room room = Rooms[i];
			if (room.DirtyTableGroups)
			{
				room.RecalculateTableGroupsNow();
			}
		}
	}

	public void UpdateStates()
	{
		for (int i = 0; i < MaxRoomsPerUpdate; i++)
		{
			UpdateRooms[i] = null;
		}
		for (int j = 0; j < Rooms.Count; j++)
		{
			if (Rooms[j].AccRefreshTime > 0f)
			{
				for (int k = 0; k < MaxRoomsPerUpdate; k++)
				{
					if (!UpdateRooms[k].IsAliveNotNull() || Rooms[j].AccRefreshTime > UpdateRooms[k].AccRefreshTime)
					{
						UpdateRooms[k] = Rooms[j];
						break;
					}
				}
			}
			Rooms[j].AccRefreshTime += Time.deltaTime;
		}
		for (int l = 0; l < MaxRoomsPerUpdate; l++)
		{
			if (UpdateRooms[l].IsAliveNotNull())
			{
				UpdateRooms[l].UpdateFrameState();
				UpdateRooms[l].AccRefreshTime = 0f;
			}
		}
	}

	public IEnumerable<WallEdge> GetEdgesOnFloor(int floor)
	{
		foreach (WallEdge allSegment in AllSegments)
		{
			if (allSegment.Floor == floor)
			{
				yield return allSegment;
			}
		}
	}

	public Room RoomUnderMouse(bool outdoors = false)
	{
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		float enter = 0f;
		Room result = null;
		if (new Plane(Vector3.up, new Vector3(0f, GameSettings.Instance.ActiveFloor * 2, 0f)).Raycast(ray, out enter))
		{
			float num = Mathf.Tan((90f - CameraScript.Instance.transform.rotation.eulerAngles.x) * ((float)Math.PI / 180f)) * 1.5f;
			Vector3 point = ray.GetPoint(enter);
			Vector3 point2 = ray.GetPoint(0f);
			Vector2 p = new Vector2(point.x, point.z);
			for (int i = 0; i < Rooms.Count; i++)
			{
				Room room = Rooms[i];
				if (room.Outdoors && !outdoors)
				{
					continue;
				}
				float num2 = (room.Outdoors ? room.FenceHeight : 2f);
				if (room.Floor != GameSettings.Instance.ActiveFloor || !room.IsInsideBounds(p, num * num2))
				{
					continue;
				}
				for (int j = 0; j < room.Edges.Count; j++)
				{
					Vector2 pos = room.Edges[j].Pos;
					Vector2 pos2 = room.Edges[(j + 1) % room.Edges.Count].Pos;
					Vector2 v = pos - pos2;
					Vector3 inNormal = v.Turn90().normalized.ToVector3(0f);
					Plane plane = new Plane(inNormal, pos.ToVector3(0f));
					float enter2;
					if (plane.GetSide(point2) || !plane.Raycast(ray, out enter2))
					{
						continue;
					}
					Vector3 point3 = ray.GetPoint(enter2);
					if (point3.y >= (float)(room.Floor * 2) && point3.y <= (float)(room.Floor * 2) + num2)
					{
						Vector2 vector = point3.FlattenVector3();
						float sqrMagnitude = v.sqrMagnitude;
						float sqrMagnitude2 = (vector - pos).sqrMagnitude;
						float sqrMagnitude3 = (vector - pos2).sqrMagnitude;
						if (sqrMagnitude2 <= sqrMagnitude && sqrMagnitude3 <= sqrMagnitude)
						{
							return room;
						}
					}
				}
				if (room.IsInside(p))
				{
					result = room;
				}
			}
		}
		return result;
	}

	public RoomSegment[] GetAllSegments()
	{
		return RoomSegments.ToArray();
	}

	public void ClearReservations(Actor actor)
	{
		foreach (Furniture item in actor.ReservedFurniture.ToList())
		{
			if (item.Reserved == actor)
			{
				item.Reserved = null;
			}
		}
	}

	public bool IsBFSStarted()
	{
		return BFSStarted;
	}

	public void RecalculateNearRooms()
	{
		if (DisableMeshRebuild || BFSStarted || Outside.NavmeshRebuildStarted)
		{
			return;
		}
		for (int i = 0; i < Rooms.Count; i++)
		{
			if (Rooms[i].NavmeshRebuildStarted)
			{
				return;
			}
		}
		RoomNearnessDirty = false;
		BFSStarted = true;
		BFSTotal = (uint)Rooms.Count;
		if (BFSTotal < 1)
		{
			BFSTotal = 1u;
		}
		BFSDone = 0u;
		new Thread((ThreadStart)delegate
		{
			try
			{
				BFS();
			}
			catch (Exception ex)
			{
				ErrorLogging.AddException(ex);
				BFSStarted = false;
				RoomNearnessDirty = true;
			}
			BFSStarted = false;
		}).Start();
	}

	private void BFS()
	{
		List<Room> list = new List<Room>(Rooms.Count);
		for (int i = 0; i < Rooms.Count; i++)
		{
			if (!Rooms[i].Pillar && !Rooms[i].IsUpperAtriumNotBalcony)
			{
				list.Add(Rooms[i]);
			}
		}
		Dictionary<Room, HashSet<Room>> dictionary = new Dictionary<Room, HashSet<Room>>();
		StartTraverseConnected(Outside, dictionary);
		HashSet<RoadSegment> visited = new HashSet<RoadSegment>();
		foreach (RoadSegment groundLevelRamp in RoadManager.Instance.GroundLevelRamps)
		{
			RoomConnectionFromRoads(groundLevelRamp, visited, dictionary, Outside);
		}
		HashSet<Room> ignore = dictionary.Keys.ToHashSet();
		for (int j = 0; j < list.Count; j++)
		{
			Room room = list[j];
			if (!dictionary.ContainsKey(room))
			{
				dictionary[room] = GetAllConnectedRooms(room, ignore);
			}
		}
		list.Add(Outside);
		ThreadCountdown threadCountdown = new ThreadCountdown(list.Count);
		for (int k = 0; k < list.Count; k++)
		{
			Room r = list[k];
			ThreadPool.QueueUserWorkItem(BFSThread, new BFSObject(r, list, dictionary, threadCountdown));
		}
		threadCountdown.Wait();
	}

	private static void StartTraverseConnected(Room to, Dictionary<Room, HashSet<Room>> allConn)
	{
		lock (to.PathNodes)
		{
			HashSet<Room> orAdd = allConn.GetOrAdd(to, (Room x) => new HashSet<Room>());
			for (int num = 0; num < to.PathNodes.Count; num++)
			{
				if (!to.PathNodes[num].OutsideAccessible)
				{
					continue;
				}
				List<PathNode<Vector3>> connections = to.PathNodes[num].GetConnections();
				for (int num2 = 0; num2 < connections.Count; num2++)
				{
					List<PathNode<Vector3>> connections2 = connections[num2].GetConnections();
					for (int num3 = 0; num3 < connections2.Count; num3++)
					{
						PathNode<Vector3> pathNode = connections2[num3];
						if (!pathNode.OutsideAccessible)
						{
							continue;
						}
						foreach (Room item in GetRoomFromNode(pathNode))
						{
							if (item != to && orAdd.Add(item))
							{
								TraverseConnected(to.PathNodes[num], item, allConn);
							}
						}
					}
				}
			}
			orAdd.Remove(to);
		}
	}

	private static IEnumerable<Room> GetRoomFromNode(PathNode<Vector3> p, Furniture from = null)
	{
		Room room;
		if ((object)(room = p.Tag as Room) != null)
		{
			yield return room;
			yield break;
		}
		Furniture furniture;
		Furniture el = (furniture = p.Tag as Furniture);
		if ((object)furniture != null)
		{
			if ("Elevator".Equals(el.Type))
			{
				if (el.CanExitElevator)
				{
					yield return el.Parent;
					yield break;
				}
				List<PathNode<Vector3>> conns = el.pathNode.GetConnections();
				for (int l = 0; l < conns.Count; l++)
				{
					Furniture furniture2 = conns[l].Tag as Furniture;
					if (!(furniture2 != null) || !"Elevator".Equals(furniture2.Type) || !(furniture2 != from))
					{
						continue;
					}
					foreach (Room item in GetRoomFromNode(conns[l], el))
					{
						yield return item;
					}
				}
			}
			else if ("Portal".Equals(el.Type))
			{
				yield return el.Parent;
			}
		}
		else if (p.Tag is RoadSegment)
		{
			yield return GameSettings.Instance.sRoomManager.Outside;
		}
	}

	private static void TraverseConnected(PathNode<Vector3> from, Room to, Dictionary<Room, HashSet<Room>> allConn)
	{
		lock (to.PathNodes)
		{
			List<int> list = null;
			try
			{
				bool flag = true;
				if (to.PathNodes.Count > 1)
				{
					flag = false;
					list = _traverseActualPool.Get();
					for (int i = 0; i < to.PathNodes.Count; i++)
					{
						List<PathNode<Vector3>> connections = to.PathNodes[i].GetConnections();
						bool flag2 = false;
						for (int j = 0; j < connections.Count; j++)
						{
							List<PathNode<Vector3>> connections2 = connections[j].GetConnections();
							for (int k = 0; k < connections2.Count; k++)
							{
								foreach (Room item in GetRoomFromNode(connections2[k]))
								{
									if (from.Tag == item)
									{
										list.Add(i);
										flag2 = true;
										break;
									}
								}
							}
							if (flag2)
							{
								break;
							}
						}
					}
				}
				else if (to.PathNodes.Count == 1 && !to.PathNodes[0].OutsideAccessible)
				{
					flag = false;
				}
				if (!flag && (list == null || list.Count <= 0))
				{
					return;
				}
				HashSet<Room> orAdd = allConn.GetOrAdd(to, (Room x) => new HashSet<Room>());
				int num = (flag ? to.PathNodes.Count : list.Count);
				for (int num2 = 0; num2 < num; num2++)
				{
					PathNode<Vector3> pathNode = (flag ? to.PathNodes[num2] : to.PathNodes[list[num2]]);
					List<PathNode<Vector3>> connections3 = pathNode.GetConnections();
					for (int num3 = 0; num3 < connections3.Count; num3++)
					{
						List<PathNode<Vector3>> connections4 = connections3[num3].GetConnections();
						for (int num4 = 0; num4 < connections4.Count; num4++)
						{
							PathNode<Vector3> pathNode2 = connections4[num4];
							foreach (Room item2 in GetRoomFromNode(pathNode2))
							{
								if (pathNode2 != from && pathNode.Tag != item2 && orAdd.Add(item2))
								{
									TraverseConnected(pathNode, item2, allConn);
								}
							}
						}
					}
				}
				orAdd.Remove(to);
				Room room = from.Tag as Room;
				if (room != null && room != to)
				{
					orAdd.Add(room);
				}
			}
			finally
			{
				if (list != null)
				{
					_traverseActualPool.Release(list);
				}
			}
		}
	}

	private void BFSThread(object stateObj)
	{
		BFSObject bFSObject = (BFSObject)stateObj;
		Room r = bFSObject.R;
		List<Room> rooms = bFSObject.rooms;
		Dictionary<Room, HashSet<Room>> conn = bFSObject.Conn;
		try
		{
			Dictionary<Room, BFSNode<Room>> dictionary = rooms.ToDictionary((Room x) => x, (Room x) => new BFSNode<Room>(x));
			Queue<BFSNode<Room>> queue = new Queue<BFSNode<Room>>();
			BFSNode<Room> bFSNode = dictionary[r];
			queue.Clear();
			bFSNode.Distance = 0;
			queue.Enqueue(bFSNode);
			r.Accessible = r.Dummy;
			if (!r.Outdoors && !r.Dummy && !r.IgnoreConnected())
			{
				lock (HUD.Instance.InaccessibleRoom)
				{
					HUD.Instance.InaccessibleRoom.Add(r);
				}
			}
			while (queue.Count > 0)
			{
				BFSNode<Room> bFSNode2 = queue.Dequeue();
				HashSet<Room> value;
				if (!conn.TryGetValue(bFSNode2.Value, out value))
				{
					continue;
				}
				foreach (Room item in value)
				{
					BFSNode<Room> value2;
					if (!dictionary.TryGetValue(item, out value2))
					{
						continue;
					}
					if (value2.Value == Outside)
					{
						r.Accessible = true;
						if (!r.Outdoors && !r.Dummy)
						{
							lock (HUD.Instance.InaccessibleRoom)
							{
								HUD.Instance.InaccessibleRoom.Remove(r);
							}
						}
					}
					if (value2.Distance == int.MaxValue)
					{
						value2.Distance = bFSNode2.Distance + 1;
						value2.Parent = bFSNode2;
						queue.Enqueue(value2);
					}
				}
			}
			lock (BFSLock)
			{
				List<KeyValuePair<Room, int>> newConnectedRoom = GetNewConnectedRoom(r);
				foreach (BFSNode<Room> value3 in dictionary.Values)
				{
					if (value3.Distance != int.MaxValue)
					{
						newConnectedRoom.Add(new KeyValuePair<Room, int>(value3.Value, value3.Distance));
					}
				}
				newConnectedRoom.Sort((KeyValuePair<Room, int> x, KeyValuePair<Room, int> y) => x.Value.CompareTo(y.Value));
			}
		}
		catch (Exception ex)
		{
			lock (BFSLock)
			{
				GetNewConnectedRoom(r).Add(new KeyValuePair<Room, int>(r, 0));
			}
			ErrorLogging.AddException(ex);
			throw;
		}
		finally
		{
			BFSDone++;
			bFSObject.Counter.FinishTask();
		}
	}

	private List<KeyValuePair<Room, int>> GetNewConnectedRoom(Room r)
	{
		List<KeyValuePair<Room, int>> value;
		if (ConnectedRooms.TryGetValue(r, out value))
		{
			value.Clear();
		}
		else
		{
			value = new List<KeyValuePair<Room, int>>();
			ConnectedRooms[r] = value;
		}
		return value;
	}

	private float GetDistance(Dictionary<KeyValuePair<Room, Room>, float> dist, KeyValuePair<Room, Room> key)
	{
		float value;
		if (!dist.TryGetValue(key, out value))
		{
			return float.PositiveInfinity;
		}
		return value;
	}

	private static HashSet<Room> GetAllConnectedRooms(Room room, HashSet<Room> ignore)
	{
		HashSet<Room> hashSet = new HashSet<Room>();
		lock (room.PathNodes)
		{
			for (int i = 0; i < room.PathNodes.Count; i++)
			{
				List<PathNode<Vector3>> connections = room.PathNodes[i].GetConnections();
				if (!room.PathNodes[i].OutsideAccessible)
				{
					continue;
				}
				for (int j = 0; j < connections.Count; j++)
				{
					List<PathNode<Vector3>> connections2 = connections[j].GetConnections();
					for (int k = 0; k < connections2.Count; k++)
					{
						PathNode<Vector3> pathNode = connections2[k];
						Room room2 = pathNode.Tag as Room;
						Furniture furniture;
						if (room2 != null && (ignore == null || !ignore.Contains(room2)))
						{
							hashSet.Add(room2);
						}
						else if ((object)(furniture = pathNode.Tag as Furniture) != null)
						{
							if (furniture.Type.Equals("Elevator"))
							{
								SearchElevator(furniture, null, hashSet);
							}
							else if (furniture.Type.Equals("Portal"))
							{
								hashSet.Add(furniture.Parent);
							}
						}
					}
				}
			}
		}
		hashSet.Remove(room);
		return hashSet;
	}

	private static void SearchElevator(Furniture el, Furniture from, HashSet<Room> result)
	{
		if (el.CanExitElevator)
		{
			result.Add(el.Parent);
			return;
		}
		List<PathNode<Vector3>> connections = el.pathNode.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			Furniture furniture;
			if ((object)(furniture = connections[i].Tag as Furniture) != null && furniture.Type.Equals("Elevator") && furniture != from)
			{
				if (furniture.CanExitElevator)
				{
					result.Add(furniture.Parent);
				}
				else
				{
					SearchElevator(furniture, el, result);
				}
			}
		}
	}

	private static void RoomConnectionFromRoads(RoadSegment start, HashSet<RoadSegment> visited, Dictionary<Room, HashSet<Room>> input, Room outside)
	{
		if (!visited.Add(start))
		{
			return;
		}
		List<PathNode<Vector3>> connections = start.Self.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			PathNode<Vector3> pathNode = connections[i];
			RoomSegment roomSegment = pathNode.Tag as RoomSegment;
			if (roomSegment != null)
			{
				Room room = (Room)((roomSegment.ParentRooms[0] != null) ? roomSegment.ParentRooms[0] : roomSegment.ParentRooms[1]);
				if (room != outside && room != null)
				{
					PathNode<Vector3> pathNode2 = roomSegment.pathNode.GetConnections().FirstOrDefault((PathNode<Vector3> x) => x.Tag is RoadSegment);
					if (pathNode2 != null)
					{
						TraverseConnected(pathNode2, room, input);
						input.Append(outside, room);
						input.Append(room, outside);
					}
					else
					{
						Debug.LogError("Failed finding door to outside connection", roomSegment);
					}
				}
			}
			else
			{
				RoadSegment roadSegment = pathNode.Tag as RoadSegment;
				if (roadSegment != null && roadSegment.floor > 0)
				{
					RoomConnectionFromRoads(roadSegment, visited, input, outside);
				}
			}
		}
	}

	public Room GetRoomFromPoint(Vector3I p)
	{
		return GetRoomFromPoint(p.y, new Vector2(p.x, p.z), false);
	}

	public bool ValidRoomPos(Rect r, int floor)
	{
		foreach (Room item in Rooms.Where((Room x) => x.Floor == floor))
		{
			int num = 0;
			Rect roomBounds = item.RoomBounds;
			if (roomBounds.xMin == r.xMin)
			{
				num |= 1;
			}
			if (roomBounds.xMax == r.xMax)
			{
				num |= 2;
			}
			if (roomBounds.yMin == r.yMin)
			{
				num |= 4;
			}
			if (roomBounds.yMax == r.yMax)
			{
				num |= 8;
			}
			switch (num)
			{
			case 15:
				return false;
			case 14:
				if (!(r.xMin - roomBounds.xMin > 1f) && !(roomBounds.xMin > r.xMin))
				{
					return false;
				}
				break;
			case 13:
				if (!(roomBounds.xMax - r.xMax > 1f) && !(roomBounds.xMax < r.xMax))
				{
					return false;
				}
				break;
			case 11:
				if (!(r.yMin - roomBounds.yMin > 1f) && !(roomBounds.yMin > r.yMin))
				{
					return false;
				}
				break;
			case 7:
				if (!(roomBounds.yMax - r.yMax > 1f) && !(roomBounds.yMax < r.yMax))
				{
					return false;
				}
				break;
			default:
				if (item.RoomBounds.Overlaps(r.Expand(2f, 2f)))
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	public static Rect[] SplitRect(Rect oldRect, Rect newRect)
	{
		int num = 0;
		if (oldRect.xMin == newRect.xMin)
		{
			num |= 1;
		}
		if (oldRect.xMax == newRect.xMax)
		{
			num |= 2;
		}
		if (oldRect.yMin == newRect.yMin)
		{
			num |= 4;
		}
		if (oldRect.yMax == newRect.yMax)
		{
			num |= 8;
		}
		switch (num)
		{
		case 14:
			return new Rect[2]
			{
				new Rect(oldRect.x, oldRect.y, oldRect.width - newRect.width - 1f, oldRect.height),
				new Rect(newRect.x, oldRect.y, newRect.width, oldRect.height)
			};
		case 13:
			return new Rect[2]
			{
				new Rect(oldRect.x, oldRect.y, newRect.width, oldRect.height),
				new Rect(newRect.xMax + 1f, oldRect.y, oldRect.width - newRect.width - 1f, oldRect.height)
			};
		case 11:
			return new Rect[2]
			{
				new Rect(oldRect.x, oldRect.y, oldRect.width, oldRect.height - newRect.height - 1f),
				new Rect(oldRect.x, newRect.y, oldRect.width, newRect.height)
			};
		case 7:
			return new Rect[2]
			{
				new Rect(oldRect.x, oldRect.y, oldRect.width, newRect.height),
				new Rect(oldRect.x, newRect.yMax + 1f, oldRect.width, oldRect.height - newRect.height - 1f)
			};
		default:
			return null;
		}
	}

	public Dictionary<Room, RoomBuildState> CheckRoomBounds(Rect r, int floor)
	{
		IEnumerable<Room> enumerable = Rooms.Where((Room x) => x.Floor == floor);
		Dictionary<Room, RoomBuildState> dictionary = new Dictionary<Room, RoomBuildState>();
		foreach (Room item in enumerable)
		{
			int num = 0;
			Rect roomBounds = item.RoomBounds;
			if (roomBounds.xMin == r.xMin)
			{
				num |= 1;
			}
			if (roomBounds.xMax == r.xMax)
			{
				num |= 2;
			}
			if (roomBounds.yMin == r.yMin)
			{
				num |= 4;
			}
			if (roomBounds.yMax == r.yMax)
			{
				num |= 8;
			}
			switch (num)
			{
			case 15:
				dictionary.Add(item, RoomBuildState.Identical);
				goto end_IL_0167;
			case 14:
				dictionary.Add(item, (roomBounds.xMin < r.xMin) ? RoomBuildState.Split : RoomBuildState.Expand);
				continue;
			case 13:
				dictionary.Add(item, (roomBounds.xMax > r.xMax) ? RoomBuildState.Split : RoomBuildState.Expand);
				continue;
			case 11:
				dictionary.Add(item, (roomBounds.yMin < r.yMin) ? RoomBuildState.Split : RoomBuildState.Expand);
				continue;
			case 7:
				dictionary.Add(item, (roomBounds.yMax > r.yMax) ? RoomBuildState.Split : RoomBuildState.Expand);
				continue;
			}
			if (!item.RoomBounds.Overlaps(r.Expand(2f, 2f)))
			{
				continue;
			}
			dictionary.Add(item, RoomBuildState.Invalid);
			break;
			continue;
			end_IL_0167:
			break;
		}
		return dictionary;
	}

	public Vector2 GetRoomChange(Rect r, int floor)
	{
		IEnumerable<Room> enumerable = Rooms.Where((Room x) => x.Floor == floor);
		int num = 0;
		bool flag = false;
		Rect rect = new Rect(0f, 0f, 0f, 0f);
		foreach (Room item in enumerable)
		{
			int num2 = 0;
			Rect roomBounds = item.RoomBounds;
			if (roomBounds.xMin == r.xMin)
			{
				num2 |= 1;
			}
			if (roomBounds.xMax == r.xMax)
			{
				num2 |= 2;
			}
			if (roomBounds.yMin == r.yMin)
			{
				num2 |= 4;
			}
			if (roomBounds.yMax == r.yMax)
			{
				num2 |= 8;
			}
			switch (num2)
			{
			case 15:
				return r.size;
			case 14:
				rect = item.RoomBounds;
				flag = roomBounds.xMin < r.xMin;
				num++;
				break;
			case 13:
				rect = item.RoomBounds;
				flag = roomBounds.xMax > r.xMax;
				num++;
				break;
			case 11:
				rect = item.RoomBounds;
				flag = roomBounds.yMin < r.yMin;
				num++;
				break;
			case 7:
				rect = item.RoomBounds;
				flag = roomBounds.yMax > r.yMax;
				num++;
				break;
			default:
				if (item.RoomBounds.Overlaps(r.Expand(2f, 2f)))
				{
					return r.size;
				}
				break;
			}
		}
		switch (num)
		{
		case 2:
			if (r.width != rect.width)
			{
				return new Vector2(1f, r.height);
			}
			return new Vector2(r.width, 1f);
		default:
			return r.size;
		case 1:
			if (flag)
			{
				if (r.width != rect.width)
				{
					return new Vector2(1f, r.height);
				}
				return new Vector2(r.width, 1f);
			}
			if (r.width != rect.width)
			{
				return new Vector2(r.width - rect.width, r.height);
			}
			return new Vector2(r.width, r.height - rect.height);
		}
	}

	public Room GetRoomFromPoint(int floor, Vector2 point, bool add = true, bool withPillars = true)
	{
		GridAreaQuery<Room> value;
		if (RoomQuery.TryGetValue(floor, out value))
		{
			List<Room> list = value.Query(point);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].Floor == floor && (withPillars || !list[i].Pillar) && list[i].IsInside(point))
					{
						return list[i];
					}
				}
			}
		}
		if (floor != 0)
		{
			return null;
		}
		return Outside;
	}

	public Room GetRoomFromPoint(Vector3 p)
	{
		return GetRoomFromPoint(Mathf.FloorToInt((p.y + 1f) / 2f), new Vector2(p.x, p.z));
	}

	public float Distance(Vector3 v1, Vector3 v2)
	{
		return (v1 - v2).sqrMagnitude;
	}

	public List<Room> GetRooms()
	{
		return Rooms;
	}

	public void RemoveRoom(Room room)
	{
		if (room != null)
		{
			Rooms.RemoveAll((Room x) => x == room);
			RoofOffsetCheck.Add(room.Floor);
			lock (BFSLock)
			{
				ConnectedRooms.Remove(room);
			}
			RemoveRoomFromQuery(room);
		}
	}

	public void AddRoom(Room room)
	{
		if (!(room == null) && !Rooms.Contains(room))
		{
			Rooms.Add(room);
			RoofOffsetCheck.Add(room.Floor);
			if (room.Floor == 0)
			{
				GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
			}
			if (NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 1 && SelectorController.Instance.DoneLoading)
			{
				GameSettings.Instance.QueuedNetworkRooms.Add(room);
			}
		}
	}

	public void RemoveRoomFromQuery(Room room)
	{
		GridAreaQuery<Room> value;
		if (RoomQuery.TryGetValue(room.Floor, out value))
		{
			value.Remove(room, room.RoomBounds);
		}
	}

	public void AddRoomToQuery(Room room)
	{
		RoomQuery.GetOrAdd(room.Floor, (int x) => new GridAreaQuery<Room>(new Rect(0f, 0f, 256f, 256f), new Vector2(8f, 8f))).Add(room, room.RoomBounds);
	}

	public void RefreshRoofOffsets()
	{
		if (RoofOffsetCheck.Count <= 0)
		{
			return;
		}
		foreach (int item in RoofOffsetCheck)
		{
			CheckRoofOffsets(item);
		}
		RoofOffsetCheck.Clear();
	}

	private void CheckRoofOffsets(int floor)
	{
		for (int i = 0; i < Roofs.Count; i++)
		{
			Roof roof = Roofs[i];
			if (roof.Floor != floor)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < Rooms.Count; j++)
			{
				Room room = Rooms[j];
				if (room.Floor == roof.Floor && roof.Bounds.Overlaps(room.RoomBounds))
				{
					flag = true;
					break;
				}
			}
			if (flag != roof.HasHadOffset && !roof.GenerateRoofing())
			{
				roof.DestroyGO();
			}
		}
	}

	public void RefreshFireEscapes(Room from)
	{
		List<Room> connected = GetConnected(from);
		bool flag = connected.Any((Room x) => x.IsOnFire);
		for (int num = 0; num < connected.Count; num++)
		{
			Room room = connected[num];
			room.BuildingOnFire = flag;
			HashList<Furniture> furniture = room.GetFurniture("Elevator");
			for (int num2 = 0; num2 < furniture.Count; num2++)
			{
				furniture[num2].CanTraverse = !flag;
			}
		}
	}

	public bool FilterFunction(Team team, Employee.RoleBit role, bool allowAny, bool elevator, object node)
	{
		if (!allowAny)
		{
			Room room = node as Room;
			if (room != null)
			{
				if (!room.Dummy && !room.AllowPass)
				{
					return room.AllowedInRoom(team, role, true);
				}
				return true;
			}
		}
		IRoomConnector roomConnector;
		if ((roomConnector = node as IRoomConnector) != null && roomConnector.IsBlocked)
		{
			return false;
		}
		Furniture furniture = node as Furniture;
		if (furniture != null)
		{
			if (furniture.CanTraverse && !furniture.IsBlocked)
			{
				if (!elevator)
				{
					return !furniture.Type.Equals("Elevator");
				}
				return true;
			}
			return false;
		}
		return true;
	}

	public bool SimpleFilterFunctionNoPaths(object node)
	{
		IRoomConnector roomConnector;
		if ((roomConnector = node as IRoomConnector) != null && roomConnector.IsBlocked)
		{
			return false;
		}
		Furniture furniture = node as Furniture;
		if (furniture != null)
		{
			return furniture.CanTraverse;
		}
		if (node is PathController.PathPoint)
		{
			return false;
		}
		return true;
	}

	private ConnectorType IsElevator(object s)
	{
		Furniture furniture;
		if ((object)(furniture = s as Furniture) != null)
		{
			if (furniture.Type.Equals("Elevator"))
			{
				return ConnectorType.Elevator;
			}
			if (!furniture.Type.Equals("Portal"))
			{
				return ConnectorType.Furn;
			}
			return ConnectorType.Portal;
		}
		return ConnectorType.Other;
	}

	public void FixPath(List<PathNode<Vector3>> path)
	{
		lock (_fixPathCache)
		{
			_fixPathCache.Clear();
			for (int i = 0; i < path.Count; i++)
			{
				if (path[i].Tag2 == null)
				{
					continue;
				}
				int value = -1;
				if (_fixPathCache.TryGetValue(path[i].Tag2, out value))
				{
					for (int num = i; num > value; num--)
					{
						_fixPathCache.Remove(path[num].Tag2);
						path.RemoveAt(num);
					}
					i = value;
				}
				else
				{
					_fixPathCache[path[i].Tag2] = i;
				}
			}
		}
	}

	public RoadSegment GetRoad(Vector3 v)
	{
		int num = Mathf.FloorToInt((v.y + 1f) / 4f);
		if (num < RoadManager.Floors)
		{
			RoadSegment segment = RoadManager.Instance.GetSegment(v, num);
			if (!(segment != null) || (segment.floor <= 0 && !segment.Raised))
			{
				return null;
			}
			return segment;
		}
		return null;
	}

	private Vector3 GetRoadCorner(Vector3 pos)
	{
		float roadSize = RoadManager.Instance.RoadSize;
		Vector3 vector = new Vector3(Mathf.Floor(pos.x / roadSize) * roadSize, pos.y, Mathf.Floor(pos.z / roadSize) * roadSize);
		return vector + new Vector3((pos.x - vector.x < 4f) ? 0.5f : (roadSize - 0.5f), 0f, (pos.z - vector.z < 4f) ? 0.5f : (roadSize - 0.5f));
	}

	public static bool GetRoadRight(float angle, Vector3 pos)
	{
		float roadSize = RoadManager.Instance.RoadSize;
		Vector3 vector = new Vector3((Mathf.Floor(pos.x / roadSize) + 0.5f) * roadSize, 0f, (Mathf.Floor(pos.z / roadSize) + 0.5f) * roadSize);
		Vector3 vector2 = pos - vector;
		if (Mathf.Abs(Mathf.DeltaAngle(angle, 180f)) <= 45f)
		{
			return vector2.x < 0f;
		}
		if (Mathf.Abs(Mathf.DeltaAngle(angle, 270f)) <= 45f)
		{
			return vector2.z >= 0f;
		}
		if (Mathf.Abs(Mathf.DeltaAngle(angle, 0f)) <= 45f)
		{
			return vector2.x >= 0f;
		}
		return vector2.z < 0f;
	}

	private float GetInitialDir(Vector3 pos)
	{
		float roadSize = RoadManager.Instance.RoadSize;
		float num = pos.x % roadSize;
		float num2 = pos.z % roadSize;
		float num3 = Mathf.Min(num, roadSize - num);
		float num4 = Mathf.Min(num2, roadSize - num2);
		if (roadSize - num < num4)
		{
			return 270f;
		}
		if (roadSize - num2 < num3)
		{
			return 180f;
		}
		if (num < num4)
		{
			return 90f;
		}
		return 0f;
	}

	public List<PathNode<Vector3>> FindRoomPath(PathNode<Vector3> n1, PathNode<Vector3> n2, Vector3 startV, Vector3 endV, Func<object, bool> filter, Func<PathNode<Vector3>, float> weight, Func<PathNode<Vector3>, bool> earlyStop = null)
	{
		Vector3 point = n1.Point;
		Vector3 point2 = n2.Point;
		n1.Point = startV;
		n2.Point = endV;
		List<PathNode<Vector3>> list = NodePathFinding<Vector3>.FindPathNodes(n1, n2, (Vector3 x, Vector3 y) => (x - y).magnitude, (Vector3 x, Vector3 y) => (x - y).magnitude, filter, weight, earlyStop);
		n1.Point = point;
		n2.Point = point2;
		if (list == null)
		{
			return null;
		}
		FixPath(list);
		return list;
	}

	private static bool isRoadSegment(PathNode<Vector3> p)
	{
		return p.Tag is RoadSegment;
	}

	public List<PathVector> FindPathToOutside(Vector3 startV, float angle)
	{
		PathNode<Vector3> pathNode = null;
		PathNode<Vector3> pathNode2 = Outside.PathNodes.FirstOrDefault();
		if (pathNode2 == null)
		{
			return null;
		}
		RoadSegment road = GetRoad(startV);
		if (road != null)
		{
			pathNode = road.Self;
		}
		else
		{
			Room roomFromPoint = GetRoomFromPoint(startV);
			if (roomFromPoint == null)
			{
				return null;
			}
			pathNode = roomFromPoint.GetAvailableNode(startV);
		}
		List<PathNode<Vector3>> list = FindRoomPath(pathNode, pathNode2, startV, startV, SimpleFilterFunctionNoPaths, null, isRoadSegment);
		if (list == null)
		{
			return null;
		}
		Vector3 vector = startV;
		Room finalRoom = Outside;
		if (list.Count > 1)
		{
			RoomSegment roomSegment = list[list.Count - 2].Tag as RoomSegment;
			if (roomSegment == null || roomSegment.ObjectTransform == null)
			{
				NodePathFinding<Vector3>.Release(list);
				return null;
			}
			if (list.Last().Tag is RoadSegment)
			{
				finalRoom = null;
			}
			else
			{
				for (int i = 2; i < list.Count - 1; i++)
				{
					if (list[i].Tag is RoadSegment)
					{
						RoomSegment roomSegment2 = list[i - 1].Tag as RoomSegment;
						if (roomSegment2 != null)
						{
							roomSegment = roomSegment2;
							list.RemoveRange(i + 1, list.Count - i - 1);
							finalRoom = null;
							break;
						}
					}
				}
			}
			float doorAngle = roomSegment.GetDoorAngle(Outside);
			Vector3? validPointNear = Outside.GetValidPointNear(roomSegment.ObjectTransform.position, UnityEngine.Random.Range(2f, 4f), true, (doorAngle - 75f) * ((float)Math.PI / 180f), (doorAngle + 75f) * ((float)Math.PI / 180f));
			if (!validPointNear.HasValue)
			{
				NodePathFinding<Vector3>.Release(list);
				return null;
			}
			vector = validPointNear.Value;
		}
		else if (list.Count == 1 && isRoadSegment(list[0]))
		{
			NodePathFinding<Vector3>.Release(list);
			List<PathVector> list2 = Actor.PathPool.Get();
			list2.Add(startV);
			return list2;
		}
		if (vector.y.Appx(0f))
		{
			RoadSegment segment = RoadManager.Instance.GetSegment(vector, 0, false);
			if (segment != null)
			{
				vector = segment.GetNearestSidewalk(vector);
			}
		}
		List<PathVector> result = FindPath(startV, vector, angle, list, finalRoom);
		NodePathFinding<Vector3>.Release(list);
		return result;
	}

	private void CachePath(List<PathNode<Vector3>> path)
	{
		if (!CacheRoomConnection)
		{
			return;
		}
		for (int i = 0; i < path.Count; i++)
		{
			Room room = path[i].Tag as Room;
			if (room != null && !room.Outside)
			{
				_visitedCache.Add(path[i].ActualNode);
				if (i + 1 >= path.Count)
				{
					continue;
				}
				PathNode<Vector3> pathNode = path[i + 1];
				if (IsElevator(pathNode.Tag) == ConnectorType.Elevator)
				{
					int j;
					for (j = i + 1; j < path.Count; j++)
					{
						if (IsElevator(path[j].Tag) != ConnectorType.Elevator)
						{
							j--;
							break;
						}
					}
					i = j;
					_conCache.Add(new RoomCon(pathNode, null, path[i]));
				}
				else
				{
					_conCache.Add(new RoomCon(pathNode, null));
					i++;
				}
			}
			else
			{
				SubCachePath();
			}
		}
		SubCachePath();
	}

	private void SubCachePath()
	{
		if (_visitedCache.Count > 1 && _conCache.Count > 0 && !((Room)_visitedCache[0].Tag).RoomConCache.ContainsKey(new RoomConKey(_visitedCache[0], _visitedCache.Last())))
		{
			for (int i = 0; i < _visitedCache.Count - 1; i++)
			{
				Room room = _visitedCache[i].Tag as Room;
				for (int j = i + 1; j < _visitedCache.Count; j++)
				{
					Room obj = _visitedCache[j].Tag as Room;
					room.RoomConCache[new RoomConKey(_visitedCache[i], _visitedCache[j])] = new RoomCon(_conCache[i].Connection, _visitedCache[i + 1], _conCache[i].SubConnection);
					obj.RoomConCache[new RoomConKey(_visitedCache[j], _visitedCache[i])] = new RoomCon(_conCache[j - 1].ReverseConnection, _visitedCache[j - 1], _conCache[j - 1].ReverseSubConnection);
				}
			}
		}
		_visitedCache.Clear();
		_conCache.Clear();
	}

	public static float FireInspectorWeight(PathNode<Vector3> p)
	{
		Furniture furniture = p.Tag as Furniture;
		if (furniture != null && "Elevator".Equals(furniture.Type))
		{
			return 65536f;
		}
		return p.Weight;
	}

	public static float BurglarWeight(PathNode<Vector3> p)
	{
		Room room = p.Tag as Room;
		if (room != null)
		{
			if (room.GetFurniture("CCTV").Count > 0 || room.GetFurniture("SecurityDesk").Count > 0)
			{
				return 5000f;
			}
			return p.Weight;
		}
		RoomSegment roomSegment = p.Tag as RoomSegment;
		if (roomSegment != null)
		{
			if (roomSegment.GuardedBy.Count > 0)
			{
				return 5000f;
			}
			return p.Weight;
		}
		return p.Weight;
	}

	public List<PathVector> FindPath(Vector3 startV, Vector3 endV, float angle, Team team, Employee.RoleBit role, bool allowAny, out bool failedRoom, bool allowElevator = true, Func<PathNode<Vector3>, float> weighting = null)
	{
		failedRoom = false;
		PathNode<Vector3> pathNode = null;
		PathNode<Vector3> pathNode2 = null;
		Room room = null;
		RoadSegment road = GetRoad(endV);
		if (road != null)
		{
			pathNode2 = road.Self;
		}
		else
		{
			room = GetRoomFromPoint(endV);
			if (room == null || room.GetNodeAt(endV.FlattenVector3()) == null)
			{
				return null;
			}
			pathNode2 = room.GetAvailableNode(endV);
		}
		RoadSegment road2 = GetRoad(startV);
		Room room2 = null;
		if (road2 != null)
		{
			pathNode = road2.Self;
		}
		else
		{
			room2 = GetRoomFromPoint(startV);
			if (room2 == null)
			{
				return null;
			}
			pathNode = room2.GetAvailableNode(startV);
		}
		bool flag = false;
		List<PathNode<Vector3>> list = null;
		if (CacheRoomConnection && room2 != null && room != null && pathNode.HasCachedPath(pathNode2))
		{
			_cachedRoomPath.Clear();
			pathNode.FindCachedPath(pathNode2, _cachedRoomPath);
			if (_cachedRoomPath.Count > 0)
			{
				list = _cachedRoomPath;
				flag = true;
			}
		}
		if (!flag)
		{
			list = FindRoomPath(pathNode, pathNode2, startV, endV, (object x) => FilterFunction(team, role, allowAny, allowElevator, x), weighting);
		}
		if (list == null)
		{
			failedRoom = true;
			return null;
		}
		if (!flag)
		{
			CachePath(list);
		}
		List<PathVector> result = FindPath(startV, endV, angle, list, room);
		if (!flag)
		{
			NodePathFinding<Vector3>.Release(list);
		}
		return result;
	}

	public List<PathVector> FindPath(Vector3 startV, Vector3 endV, float angle, List<PathNode<Vector3>> roomPath, Room finalRoom)
	{
		float num = angle;
		angle = GetInitialDir(startV);
		bool flag = GetRoadRight(angle, startV);
		startV = new Vector3(startV.x, Mathf.RoundToInt(startV.y), startV.z);
		endV = new Vector3(endV.x, Mathf.RoundToInt(endV.y), endV.z);
		List<PathVector> result = Actor.PathPool.Get();
		result.Add(startV);
		IRoomConnector roomConnector = null;
		bool flag2 = false;
		for (int i = 0; i < roomPath.Count - 1; i++)
		{
			object tag = roomPath[i].Tag;
			object tag2 = roomPath[i + 1].Tag;
			Room room = tag as Room;
			RoadSegment roadSegment;
			RoadSegment roadSegment3;
			IRoomConnector roomConnector4;
			if ((object)(roadSegment = tag as RoadSegment) != null)
			{
				RoomSegment roomSegment;
				RoadSegment roadSegment2;
				if (tag2 is Room)
				{
					result.Add(roadSegment.GetOffset(flag, 0f, out angle, false));
					roomConnector = roadSegment;
				}
				else if ((object)(roomSegment = tag2 as RoomSegment) != null)
				{
					Vector3 offsetPos = roomSegment.GetOffsetPos(Outside);
					PathVector pathVector = result[result.Count - 1];
					if ((pathVector - offsetPos).sqrMagnitude > 5f)
					{
						Vector3 roadCorner = GetRoadCorner(offsetPos);
						float current = ((i == 0) ? num : angle);
						Vector3 vector = ((!(Mathf.Abs(Mathf.DeltaAngle(current, 180f)) < 45f) && !(Mathf.Abs(Mathf.DeltaAngle(current, 0f)) < 45f)) ? new Vector3(pathVector.x, pathVector.y, roadCorner.z) : new Vector3(roadCorner.x, pathVector.y, pathVector.z));
						result.Add(vector);
						float sqrMagnitude = (vector - offsetPos).sqrMagnitude;
						if (sqrMagnitude >= (roadCorner - vector).sqrMagnitude && sqrMagnitude >= (roadCorner - offsetPos).sqrMagnitude)
						{
							result.Add(roadCorner);
						}
					}
					result.Add(new PathVector(offsetPos, roomSegment));
					result.Add(roomSegment.GetOffsetPos(Outside, true));
					roomConnector = roomSegment;
				}
				else if ((object)(roadSegment2 = tag2 as RoadSegment) != null)
				{
					Quaternion quaternion = Quaternion.LookRotation(roadSegment2.Self.Point.ReplaceY(0f) - roadSegment.Self.Point.ReplaceY(0f));
					float y = quaternion.eulerAngles.y;
					float num2 = Mathf.DeltaAngle(angle, y);
					if (!Mathf.Approximately(num2, 0f) && num2 > 0f != flag)
					{
						flag = !flag;
					}
					Vector3 vector2 = (flag ? new Vector3(3.5f, 0f, -4f) : new Vector3(-3.5f, 0f, -4f));
					Vector3 v = roadSegment2.Self.Point + quaternion * vector2;
					result.Add(v.ReplaceY(roadSegment2.SampleHeight(v.FlattenVector3())));
					angle = y;
					roomConnector = null;
				}
				flag2 = false;
			}
			else if ((object)(roadSegment3 = tag2 as RoadSegment) != null)
			{
				if (room != null)
				{
					flag = roadSegment3.GetRight(result[result.Count - 1]);
					Vector3 offset = roadSegment3.GetOffset(flag, 0f, out angle, true);
					if (!room.FindPath(result[result.Count - 1], offset, ref result, roomConnector, roadSegment3, 0, (byte)(flag ? 1u : 0u)))
					{
						Actor.PathPool.Release(result);
						return null;
					}
					roomConnector = null;
				}
				else if (tag is RoomSegment)
				{
					PathVector pathVector2 = result[result.Count - 1];
					angle = Utilities.GetFlatAngle(result[result.Count - 2], pathVector2);
					flag = GetRoadRight(angle, pathVector2);
					result.Add(new PathVector(pathVector2, tag));
					if (i + 2 < roomPath.Count && roomPath[i + 2].Tag is RoadSegment)
					{
						float flatAngle = roomPath[i + 1].Point.GetFlatAngle(roomPath[i + 2].Point);
						if (Mathf.Abs(Mathf.DeltaAngle(angle, flatAngle)) < 10f)
						{
							result.Add(GetRoadCorner(pathVector2));
						}
					}
					roomConnector = null;
				}
				flag2 = false;
			}
			else if (tag is PathController.PathPoint && tag2 is PathController.PathPoint)
			{
				int count = result.Count;
				result.AddRange(((PathController.PathPoint)tag).CachedPaths[(PathController.PathPoint)tag2]);
				if (flag2)
				{
					result.RemoveAt(count - 1);
				}
				roomConnector = null;
				flag2 = false;
			}
			else if (tag is RoomSegment && tag2 is PathController.PathPoint)
			{
				roomConnector = null;
				flag2 = true;
			}
			else if (tag is PathController.PathPoint && tag2 is RoomSegment)
			{
				IRoomConnector roomConnector2 = (IRoomConnector)tag2;
				result[result.Count - 1] = new PathVector(roomConnector2.GetOffsetPos(Outside), tag2);
				result.Add(roomConnector2.GetOffsetPos(Outside, true));
				roomConnector = roomConnector2;
				flag2 = false;
			}
			else if (tag is PathController.PathPoint && tag2 is Room)
			{
				if (i + 2 < roomPath.Count)
				{
					IRoomConnector roomConnector3;
					if ((roomConnector3 = roomPath[i + 2].Tag as IRoomConnector) != null)
					{
						Room room2 = (Room)tag2;
						Vector2 p = roomConnector3.GetOffsetPos(room2).FlattenVector3();
						result[result.Count - 1] = Utilities.ProjectToLineEndlessClamped(p, result[result.Count - 2].Flatten(), result[result.Count - 1].Flatten()).ToVector3(result[result.Count - 1].y);
					}
				}
				else
				{
					result[result.Count - 1] = Utilities.ProjectToLineEndlessClamped(endV.FlattenVector3(), result[result.Count - 2].Flatten(), result[result.Count - 1].Flatten()).ToVector3(result[result.Count - 1].y);
				}
			}
			else if (room != null && (roomConnector4 = tag2 as IRoomConnector) != null)
			{
				PathVector pathVector3 = result[result.Count - 1];
				PathController.PathPoint pathPoint;
				PathController.PathPoint other;
				if ((pathPoint = roomConnector4 as PathController.PathPoint) != null && i + 2 < roomPath.Count && (other = roomPath[i + 2].Tag as PathController.PathPoint) != null)
				{
					Vector2 vector3 = pathVector3.Flatten();
					Vector3 goal = pathPoint.GetPoint(vector3, other).ToVector3(pathVector3.y);
					if (!room.FindPath(pathVector3, goal, ref result, roomConnector, roomConnector4, 0, 0))
					{
						goal = pathPoint.GetPoint(vector3, other, true).ToVector3(pathVector3.y);
						if (!room.FindPath(pathVector3, goal, ref result, roomConnector, roomConnector4, 0, 0) && !room.FindPath(pathVector3, pathPoint.Point.ToVector3(0f), ref result, roomConnector, roomConnector4, 0, 0))
						{
							Actor.PathPool.Release(result);
							return null;
						}
					}
					roomConnector = roomConnector4;
					flag2 = true;
					continue;
				}
				Vector3 offsetPos2 = roomConnector4.GetOffsetPos(room);
				bool flag3 = roomConnector is RoadSegment;
				if (!room.FindPath(pathVector3, offsetPos2, ref result, roomConnector, roomConnector4, (!(!flag3 || flag)) ? ((byte)1) : ((byte)0), 0))
				{
					Actor.PathPool.Release(result);
					return null;
				}
				Transform[] array = roomConnector4.IntermediatePoints(room);
				if (IsElevator(roomConnector4) == ConnectorType.Elevator)
				{
					ElevatorGroup eGroup = ((Furniture)roomConnector4).EGroup;
					if (eGroup != null)
					{
						eGroup.AddPenalty();
					}
				}
				result[result.Count - 1] = new PathVector(offsetPos2, roomConnector4);
				if (array != null)
				{
					for (int j = 0; j < array.Length; j++)
					{
						result.Add(new PathVector(array[j].position, roomConnector4));
					}
				}
				Vector3 offsetPos3 = roomConnector4.GetOffsetPos(room, true);
				result.Add(offsetPos3);
				roomConnector = roomConnector4;
				flag2 = false;
			}
			else if (IsElevator(tag) == ConnectorType.Portal && IsElevator(tag2) == ConnectorType.Portal)
			{
				result.Add(new PathVector(((IRoomConnector)tag).GetOffsetPos(null), tag as Writeable, PathVector.PathType.Portal));
				result.Add(((IRoomConnector)tag2).GetOffsetPos(null));
				roomConnector = null;
				flag2 = false;
			}
		}
		if (finalRoom != null && !finalRoom.FindPath(result[result.Count - 1], endV, ref result, null, null, 0, 0))
		{
			Actor.PathPool.Release(result);
			return null;
		}
		result[0] = startV;
		result.Add(endV);
		for (int k = 1; k < result.Count; k++)
		{
			if (result[k].Approximate(result[k - 1]))
			{
				if (result[k].Type != PathVector.PathType.None)
				{
					result.RemoveAt(k - 1);
				}
				else
				{
					result.RemoveAt(k);
				}
				k--;
			}
		}
		if (roomPath.Count > 1)
		{
			RoadSegment roadSegment4 = roomPath[0].Tag as RoadSegment;
			if (roadSegment4 != null && roomPath[1].Tag is RoadSegment && !roadSegment4.Raised)
			{
				Vector3 vector4 = Quaternion.Euler(0f, num, 0f) * Vector3.forward;
				Vector3 vector5 = ((Mathf.Abs(vector4.x) > Mathf.Abs(vector4.z)) ? new Vector3(startV.x, startV.y, result[1].z) : new Vector3(result[1].x, startV.y, startV.z));
				if (result.Count > 2 && (vector5 - result[2]).sqrMagnitude < (result[1] - result[2]).sqrMagnitude)
				{
					result[1] = vector5;
				}
				else
				{
					result.Insert(1, vector5);
				}
			}
		}
		return result;
	}

	public bool CanDestroy(Room room, HashSet<Room> destroying)
	{
		if (room.Floor == -1)
		{
			return true;
		}
		List<Room> connected = GetConnected(room);
		for (int i = 0; i < connected.Count; i++)
		{
			Room room2 = connected[i];
			if (room2.Floor == room.Floor + 1 && !IsSupported(room2.Edges.Select((WallEdge x) => x.Pos), room2.Floor, room))
			{
				return false;
			}
		}
		if (room.IsUpperAtriumNotBalcony)
		{
			for (int num = room.AtriumParent.AtriumChildren.IndexOf(room) + 1; num < room.AtriumParent.AtriumChildren.Count; num++)
			{
				if (!destroying.Contains(room.AtriumParent.AtriumChildren[num]))
				{
					return false;
				}
			}
		}
		return true;
	}

	public List<Room> GetConnected(Room room, bool oneFloor = false, bool outDoor = true, bool atrium = true)
	{
		if (room.Outdoors && !outDoor)
		{
			return new List<Room>();
		}
		HashSet<Room> untouched = (oneFloor ? Rooms.Where((Room x) => x.Floor == room.Floor && (!x.Outdoors || outDoor)).ToHashSet() : Rooms.Where((Room x) => !x.Outdoors || outDoor).ToHashSet());
		untouched.Remove(room);
		SubGetConnected(room, untouched, oneFloor);
		return Rooms.Where((Room x) => (!x.Outdoors || outDoor) && (atrium || x.AtriumParent == null || x.AtriumParent == x) && (!oneFloor || x.Floor == room.Floor) && !untouched.Contains(x)).ToList();
	}

	private void SubGetConnected(Room room, HashSet<Room> untouched, bool oneFloor)
	{
		if (room == null)
		{
			return;
		}
		HashSet<Room> hashSet = new HashSet<Room>();
		List<WallEdge> edges = room.Edges;
		Rect rect = room.RoomBounds.Expand(1f, 1f);
		List<Room> list = untouched.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Room room2 = list[i];
			if (!untouched.Contains(room2) || room2 == null)
			{
				continue;
			}
			int num = Mathf.Abs(room2.Floor - room.Floor);
			if (num > 1 || !rect.Overlaps(room2.RoomBounds))
			{
				continue;
			}
			if (num == 0)
			{
				if (room.AtriumParent == room2 || room2.AtriumParent == room)
				{
					untouched.Remove(room2);
					hashSet.Add(room2);
					continue;
				}
				for (int j = 0; j < room2.Edges.Count; j++)
				{
					if (room2.Edges[j].Links.ContainsKey(room))
					{
						untouched.Remove(room2);
						hashSet.Add(room2);
						break;
					}
				}
			}
			else
			{
				if (oneFloor)
				{
					continue;
				}
				if (room.AtriumParent == room2 || room2.AtriumParent == room)
				{
					untouched.Remove(room2);
					hashSet.Add(room2);
					continue;
				}
				bool flag = false;
				List<WallEdge> edges2 = room2.Edges;
				for (int k = 0; k < room.Edges.Count; k++)
				{
					if (Utilities.IsInside(room.Edges[k].Pos, edges2))
					{
						untouched.Remove(room2);
						hashSet.Add(room2);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				for (int l = 0; l < room2.Edges.Count; l++)
				{
					if (Utilities.IsInside(room2.Edges[l].Pos, edges))
					{
						untouched.Remove(room2);
						hashSet.Add(room2);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				for (int m = 0; m < room2.Edges.Count; m++)
				{
					for (int n = 0; n < room.Edges.Count; n++)
					{
						int index = (m + 1) % room2.Edges.Count;
						int index2 = (n + 1) % room.Edges.Count;
						if (Utilities.LinesIntersect(room2.Edges[m].Pos, room2.Edges[index].Pos, room.Edges[n].Pos, room.Edges[index2].Pos, false, true))
						{
							untouched.Remove(room2);
							hashSet.Add(room2);
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
		}
		foreach (Room item in hashSet)
		{
			SubGetConnected(item, untouched, oneFloor);
		}
	}

	public bool IsSupported(Vector2 p, int floor, Room without)
	{
		if (floor < 1)
		{
			return true;
		}
		Dictionary<Selectable, Vector2[]> value = null;
		if (RoomSupport.TryGetValue(floor - 1, out value))
		{
			foreach (KeyValuePair<Selectable, Vector2[]> item in value)
			{
				if (!(item.Key == without) && Utilities.IsInside(p, item.Value))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsSupported(IEnumerable<Vector2> points, int floor, Room without, bool checkFloor = true, HashSet<Room> with = null)
	{
		if (checkFloor && floor < 1)
		{
			return true;
		}
		List<Vector2> rp = new List<Vector2>(points);
		for (int i = 0; i < rp.Count; i++)
		{
			Vector2 vector = rp[i];
			Vector2 vector2 = rp[(i + 1) % rp.Count];
			Vector2 vector3 = rp[(i + 2) % rp.Count];
			if ((vector2 - vector).normalized == (vector3 - vector2).normalized)
			{
				rp.RemoveAt((i + 1) % rp.Count);
				i--;
			}
		}
		for (int j = 0; j < rp.Count; j += 2)
		{
			rp.Insert(j + 1, (rp[j] + rp[(j + 1) % rp.Count]) * 0.5f);
		}
		Dictionary<Selectable, Vector2[]> value;
		if (RoomSupport.TryGetValue(floor - 1, out value))
		{
			HashSet<Selectable> hashSet = new HashSet<Selectable>();
			for (int k = 0; k < rp.Count; k++)
			{
				Vector2 p = rp[k];
				bool flag = false;
				bool flag2 = false;
				foreach (KeyValuePair<Selectable, Vector2[]> item in value.Where((KeyValuePair<Selectable, Vector2[]> x) => x.Key != null))
				{
					if ((with == null || with.Contains(item.Key)) && Utilities.IsInside(p, item.Value))
					{
						hashSet.Add(item.Key);
						if (item.Key == without)
						{
							flag2 = true;
						}
						else
						{
							flag = true;
						}
					}
				}
				if (!flag && (without == null || flag2))
				{
					return false;
				}
			}
			bool flag3 = false;
			foreach (Selectable item2 in hashSet)
			{
				Room room;
				if ((object)(room = item2 as Room) != null)
				{
					if (room.Edges.Any((WallEdge x) => Utilities.IsInside(x.Pos, rp, -0.01f)))
					{
						if (!(room == without))
						{
							return true;
						}
						flag3 = true;
					}
					for (int num = 0; num < rp.Count; num++)
					{
						if (room.IsInside(rp[num], -0.01f))
						{
							if (!(room == without))
							{
								return true;
							}
							flag3 = true;
						}
						for (int num2 = 0; num2 < room.Edges.Count; num2++)
						{
							Vector2 pos = room.Edges[num2].Pos;
							Vector2 pos2 = room.Edges[(num2 + 1) % room.Edges.Count].Pos;
							if (Utilities.LinesIntersect(rp[num], rp[(num + 1) % rp.Count], pos, pos2, true, false))
							{
								if (!(room == without))
								{
									return true;
								}
								flag3 = true;
							}
						}
					}
				}
				else
				{
					Furniture furniture;
					if ((object)(furniture = item2 as Furniture) == null)
					{
						continue;
					}
					Rect rect = new Rect(furniture.OriginalPosition.x - 4f, furniture.OriginalPosition.z - 4f, 8f, 8f);
					for (int num3 = 0; num3 < rp.Count; num3++)
					{
						if (rect.Contains(rp[num3]))
						{
							return true;
						}
					}
				}
			}
			if (without != null)
			{
				return !flag3;
			}
			return false;
		}
		return false;
	}

	public void UpdateFloorMeshes(int floor, bool navMesh = false)
	{
		foreach (Room item in Rooms.Where((Room x) => x.Floor == floor))
		{
			item.UpdateRoom(navMesh, true, true, false, true);
		}
	}

	private TemperatureGroup GetTempGroupFromRoom(Room r)
	{
		for (int i = 0; i < TempGroups.Count; i++)
		{
			TemperatureGroup temperatureGroup = TempGroups[i];
			if (temperatureGroup.Rooms.Contains(r))
			{
				return temperatureGroup;
			}
		}
		TemperatureGroup temperatureGroup2 = TempGroupPool.Get();
		TempGroups.Add(temperatureGroup2);
		return temperatureGroup2;
	}

	public void UpdateTemperatureControllers()
	{
		TemperatureControlDirty = false;
		if (GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
		{
			return;
		}
		TempGroups.ForEachEnum(delegate(TemperatureGroup x)
		{
			x.IsValid = false;
		});
		HashSet<Room> hashSet = new HashSet<Room>();
		for (int num = 0; num < AllFurniture.Count; num++)
		{
			Furniture furniture = AllFurniture[num];
			if (furniture != null && furniture.gameObject != null && furniture.Parent != null && furniture.TemperatureController)
			{
				hashSet.Add(furniture.Parent.GetMainAtriumParentOrSelf());
			}
		}
		while (hashSet.Count > 0)
		{
			Room room = hashSet.First();
			hashSet.Remove(room);
			TemperatureGroup tempGroupFromRoom = GetTempGroupFromRoom(room);
			tempGroupFromRoom.ClearRooms();
			tempGroupFromRoom.IsValid = true;
			List<Room> connected = GetConnected(room, false, false, false);
			for (int num2 = 0; num2 < connected.Count; num2++)
			{
				tempGroupFromRoom.Rooms.Add(connected[num2]);
				connected[num2].TempGroup = tempGroupFromRoom;
				hashSet.Remove(connected[num2]);
			}
			tempGroupFromRoom.UpdateFurniture();
		}
		for (int num3 = 0; num3 < TempGroups.Count; num3++)
		{
			TemperatureGroup temperatureGroup = TempGroups[num3];
			if (!temperatureGroup.IsValid)
			{
				TempGroups.RemoveAt(num3);
				num3--;
				TempGroupPool.Release(temperatureGroup);
			}
			else
			{
				temperatureGroup.RefreshTemperatureValues();
			}
		}
	}

	private CCTVGroup GetCCGroupFromRoom(Room r)
	{
		for (int i = 0; i < CCGroups.Count; i++)
		{
			CCTVGroup cCTVGroup = CCGroups[i];
			if (cCTVGroup.Rooms.Contains(r))
			{
				return cCTVGroup;
			}
		}
		CCTVGroup cCTVGroup2 = CCGroupPool.Get();
		CCGroups.Add(cCTVGroup2);
		return cCTVGroup2;
	}

	public void UpdateCCTVControllers()
	{
		CCTVDirty = false;
		if (GameSettings.Instance.EditMode)
		{
			return;
		}
		CCGroups.ForEachEnum(delegate(CCTVGroup x)
		{
			x.IsValid = false;
		});
		HashSet<Room> hashSet = new HashSet<Room>();
		for (int num = 0; num < AllFurniture.Count; num++)
		{
			Furniture furniture = AllFurniture[num];
			if (furniture != null && furniture.gameObject != null && furniture.Parent != null && furniture.IsCCTVFurn)
			{
				hashSet.Add(furniture.Parent.GetMainAtriumParentOrSelf());
			}
		}
		while (hashSet.Count > 0)
		{
			Room room = hashSet.First();
			hashSet.Remove(room);
			CCTVGroup cCGroupFromRoom = GetCCGroupFromRoom(room);
			cCGroupFromRoom.ClearRooms();
			cCGroupFromRoom.IsValid = true;
			List<Room> connected = GetConnected(room);
			for (int num2 = 0; num2 < connected.Count; num2++)
			{
				cCGroupFromRoom.Rooms.Add(connected[num2]);
				connected[num2].CCGroup = cCGroupFromRoom;
				hashSet.Remove(connected[num2]);
			}
			cCGroupFromRoom.UpdateFurniture();
		}
		for (int num3 = 0; num3 < CCGroups.Count; num3++)
		{
			CCTVGroup cCTVGroup = CCGroups[num3];
			if (!cCTVGroup.IsValid)
			{
				CCGroups.RemoveAt(num3);
				num3--;
				CCGroupPool.Release(cCTVGroup);
			}
			else
			{
				cCTVGroup.AssignCCs();
			}
		}
	}

	private void WindowConnection(Room room, Dictionary<Room, Dictionary<Room, float>> set)
	{
		if (room.DirtyStateVariables)
		{
			room.stateRefreshNeighbours = false;
			room.UpdateRoom(false, false, false, false, true);
		}
		Dictionary<Room, float> dictionary = new Dictionary<Room, float>();
		set.Add(room, dictionary);
		room.IndirectLighting = 0f;
		foreach (Room item in room.GetAtriumChildrenAndSelf())
		{
			List<WallSnap> wallSnaps = item.GetWallSnaps();
			for (int i = 0; i < wallSnaps.Count; i++)
			{
				WallSnap wallSnap = wallSnaps[i];
				Room parentRoom = wallSnap.GetParentRoom(true);
				Room parentRoom2 = wallSnap.GetParentRoom(false);
				if (wallSnap.LightAddition > 0f && parentRoom != null && parentRoom2 != null)
				{
					ConnectWindowLighting((parentRoom == item) ? parentRoom2 : parentRoom, wallSnap.LightAddition, set, dictionary);
				}
			}
		}
	}

	private void ConnectWindowLighting(Room to, float addition, Dictionary<Room, Dictionary<Room, float>> set, Dictionary<Room, float> dic)
	{
		to = to.GetMainAtriumParentOrSelf();
		dic.AddUp(to, addition);
		if (!set.ContainsKey(to))
		{
			WindowConnection(to, set);
		}
	}

	private void Propagate(Room r, float amount, HashSet<Room> visited, Dictionary<Room, Dictionary<Room, float>> map, bool diminish, bool directConnection)
	{
		visited.Add(r);
		if (!directConnection)
		{
			amount /= Mathf.Max(1f, r.GetAtriumArea() / 4f);
			if (!diminish)
			{
				amount = Mathf.Min(1f, amount * 4f);
			}
		}
		r.IndirectLighting += amount;
		if (amount.Appx(0f, 0.001f))
		{
			return;
		}
		foreach (KeyValuePair<Room, float> item in map[r])
		{
			if (!visited.Contains(item.Key))
			{
				Propagate(item.Key, amount, visited, map, !r.Outdoors, r.GetMainAtriumParentOrSelf() == item.Key.GetMainAtriumParentOrSelf());
			}
		}
	}

	public void PropagateLighting(Room room)
	{
		Dictionary<Room, Dictionary<Room, float>> dictionary = new Dictionary<Room, Dictionary<Room, float>>();
		WindowConnection(room, dictionary);
		foreach (KeyValuePair<Room, Dictionary<Room, float>> item in dictionary)
		{
			if (item.Key.WindowDarkLevel == 0f)
			{
				continue;
			}
			foreach (KeyValuePair<Room, float> item2 in item.Value)
			{
				HashSet<Room> hashSet = new HashSet<Room>();
				hashSet.Add(item.Key);
				Propagate(item2.Key, item2.Value * item.Key.WindowDarkLevel, hashSet, dictionary, !item.Key.Outdoors, item2.Key.GetMainAtriumParentOrSelf() == item.Key.GetMainAtriumParentOrSelf());
			}
		}
	}

	private static ProtoEdge FindNextEdge(ProtoEdge s2, ProtoEdge s3)
	{
		Vector2 pos = s2.Pos;
		Vector2 pos2 = s3.Pos;
		ProtoEdge result = s3;
		if (s3.GoOut)
		{
			float num = float.MinValue;
			foreach (ProtoEdge link in s3.Links)
			{
				float num2 = Room.LeftVal(pos, pos2, link.Pos);
				if (num2 > num)
				{
					result = link;
					num = num2;
				}
			}
		}
		else
		{
			float num3 = float.MaxValue;
			foreach (ProtoEdge link2 in s3.Links)
			{
				float num4 = Room.LeftVal(pos, pos2, link2.Pos);
				if (num4 < num3)
				{
					result = link2;
					num3 = num4;
				}
			}
		}
		return result;
	}

	private static List<ProtoEdge> BuildRoomGraph(BuildingPrefab b, int floor)
	{
		List<ProtoEdge> list = b.Edges.SelectInPlaceList((SVector3 x) => new ProtoEdge(x));
		for (int num = 0; num < b.Rooms.Length; num++)
		{
			BuildingPrefab.RoomObject roomObject = b.Rooms[num];
			if (roomObject.Floor == floor)
			{
				for (int num2 = 0; num2 < roomObject.Edges.Length; num2++)
				{
					int index = roomObject.Edges[num2];
					int index2 = roomObject.Edges[(num2 + 1) % roomObject.Edges.Length];
					list[index].Links.Add(list[index2]);
				}
			}
		}
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			list[num3].UpdateIterate();
		}
		list.Sort((ProtoEdge x, ProtoEdge y) => x.Iterated.CompareTo(y.Iterated));
		return list;
	}

	public static List<List<Vector2>> CombineRoomEdges(BuildingPrefab b, int floor, float offset, bool parentFix)
	{
		List<ProtoEdge> list = BuildRoomGraph(b, floor);
		List<List<Vector2>> list2 = new List<List<Vector2>>();
		for (int i = 0; i < list.Count; i++)
		{
			ProtoEdge protoEdge = list[i];
			if (protoEdge.Iterated <= 0)
			{
				continue;
			}
			int num = -1;
			ProtoEdge protoEdge2;
			do
			{
				protoEdge2 = null;
				int num2 = 0;
				foreach (ProtoEdge link in protoEdge.Links)
				{
					if (num2 > num && link.Iterated > 0 && !link.Links.Contains(protoEdge))
					{
						protoEdge2 = link;
						num = num2;
						break;
					}
					num2++;
				}
				if (protoEdge2 == null)
				{
					continue;
				}
				protoEdge.Iterated--;
				List<Vector2> list3 = new List<Vector2>();
				list3.Add(protoEdge2.Pos);
				ProtoEdge s = protoEdge;
				ProtoEdge protoEdge3 = protoEdge2;
				int num3 = list.Count;
				while (protoEdge3 != protoEdge && num3 >= 0)
				{
					ProtoEdge protoEdge4 = FindNextEdge(s, protoEdge3);
					protoEdge3.Iterated--;
					list3.Add(protoEdge4.Pos);
					s = protoEdge3;
					protoEdge3 = protoEdge4;
					num3--;
				}
				List<Vector2> list4 = new List<Vector2>(list3.Count);
				Vector2 vector = list3[list3.Count - 1];
				Vector2 vector2 = (vector - list3[0]).normalized;
				for (int j = 0; j < list3.Count; j++)
				{
					Vector2 vector3 = list3[j];
					Vector2 vector4 = list3[(j + 1) % list3.Count];
					Vector2 normalized = (vector3 - vector4).normalized;
					if (!(normalized == vector2))
					{
						list4.Add((offset == 0f) ? vector3 : Utilities.GetOffset(vector, vector3, vector4, offset, true));
						vector = vector3;
						vector2 = normalized;
					}
				}
				list2.Add(list4);
			}
			while (protoEdge.Iterated > 0 && protoEdge2 != null);
		}
		if (parentFix)
		{
			List<List<Vector2>> result = new List<List<Vector2>>();
			List<PolygonShell> list5 = list2.SelectInPlaceList((List<Vector2> x) => new PolygonShell(x));
			ParentPolygons(list5);
			for (int num4 = 0; num4 < list5.Count; num4++)
			{
				PolygonShell polygonShell = list5[num4];
				if (polygonShell.Parent == null)
				{
					polygonShell.AddPolys(result, true);
				}
			}
			return result;
		}
		return list2;
	}

	private static void ParentPolygons(List<PolygonShell> polys)
	{
		for (int i = 0; i < polys.Count; i++)
		{
			PolygonShell polygonShell = polys[i];
			for (int j = 0; j < polys.Count; j++)
			{
				if (i != j && !polygonShell.IsAlreadyParent(polys[j]))
				{
					PolygonShell polygonShell2 = polys[j];
					if (polygonShell.Inside(polygonShell2))
					{
						polygonShell.MakeParent(polygonShell2);
					}
				}
			}
		}
	}

	private static void MergePolygons(List<Vector2> inner, List<Vector2> outer)
	{
		float num = float.MaxValue;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < inner.Count; i++)
		{
			for (int j = 0; j < outer.Count; j++)
			{
				float sqrMagnitude = (inner[i] - outer[j]).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					num2 = i;
					num3 = j;
				}
			}
		}
		outer.Insert(num3 + 1, outer[num3]);
		for (int k = 0; k < inner.Count; k++)
		{
			outer.Insert(num3 + 1, inner[(k + num2) % inner.Count]);
		}
		outer.Insert(num3 + 1, inner[num2]);
	}

	public void UpdateRoomRoadConnections()
	{
		if (BFSStarted)
		{
			RoomRoadDirty = 2;
			return;
		}
		foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
		{
			if (!roomSegment.IsRoadLevel() || !roomSegment.IsConnecter)
			{
				continue;
			}
			IRoom room = roomSegment.ParentRooms[0];
			IRoom room2 = roomSegment.ParentRooms[1];
			List<PathNode<Vector3>> connections = roomSegment.pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<Vector3> pathNode = connections[i];
				RoadSegment roadSegment = pathNode.Tag as RoadSegment;
				if (roadSegment != null)
				{
					RoadManager.Instance.SetSidewalkDirty(roadSegment.x, roadSegment.y, roadSegment.floor);
					pathNode.RemoveConnection(roomSegment.pathNode);
					roomSegment.pathNode.RemoveConnection(pathNode);
					i--;
					TeamAssignmentDirty = true;
				}
			}
			if (room == null || room2 == null)
			{
				IRoom room3 = ((room == null) ? room2 : room);
				if (room3 != null)
				{
					RoadSegment road = roomSegment.GetRoad(room3);
					if (road != null)
					{
						roomSegment.pathNode.AddConnection(road.Self);
						road.Self.AddConnection(roomSegment.pathNode);
						RoadManager.Instance.SetSidewalkDirty(road.x, road.y, road.floor);
						TeamAssignmentDirty = true;
					}
				}
			}
			roomSegment.UpdateBlocked();
		}
	}

	public Room RoomNear(Vector2 p, float dist, int floor, out bool inside, out Vector2 pp)
	{
		pp = p;
		inside = false;
		Room result = null;
		float num = float.MaxValue;
		for (int i = 0; i < Rooms.Count; i++)
		{
			Room room = Rooms[i];
			if (room.Floor != floor || !room.RoomBounds.ContainsEntirely(p, dist))
			{
				continue;
			}
			if (room.IsInside(p))
			{
				inside = true;
				pp = p;
				return room;
			}
			for (int j = 0; j < room.Edges.Count; j++)
			{
				WallEdge wallEdge = room.Edges[j];
				WallEdge wallEdge2 = room.Edges[(j + 1) % room.Edges.Count];
				Vector2 vector = Utilities.ProjectToLineEndlessClamped(p, wallEdge.Pos, wallEdge2.Pos);
				float sqrMagnitude = (p - vector).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					pp = vector;
					result = room;
				}
			}
		}
		return result;
	}

	public void CheckTeamAssignment()
	{
		if (TeamAssignmentDirty && !TeamAssignmentRunning)
		{
			TeamAssignmentDirty = false;
			TeamAssignmentRunning = true;
			_teamAssignObject.Initialize(GameSettings.Instance.sActorManager, this);
			ThreadPool.QueueUserWorkItem(RunTeamAlgo, _teamAssignObject);
		}
	}

	private void RunTeamAlgo(object obj)
	{
		try
		{
			TeamAssignObject teamAssignObject = (TeamAssignObject)obj;
			HashSet<Room> hashSet = new HashSet<Room>();
			HashSet<PathNode<Vector3>> visitedNodes = new HashSet<PathNode<Vector3>>();
			foreach (Room allConnectedRoom in GetAllConnectedRooms(teamAssignObject.Outside, null))
			{
				SubRunTeamAlgo(allConnectedRoom, null, new MultiBitMask(teamAssignObject.TeamDict.Count, false), hashSet, visitedNodes);
			}
			HashSet<RoadSegment> visited = new HashSet<RoadSegment>();
			foreach (RoadSegment groundLevelRamp in RoadManager.Instance.GroundLevelRamps)
			{
				SubTeamRoad(groundLevelRamp, teamAssignObject.TeamDict.Count, visited, hashSet, visitedNodes);
			}
			Team[] array = new Team[teamAssignObject.TeamDict.Count];
			foreach (KeyValuePair<Team, int> item in teamAssignObject.TeamDict)
			{
				array[item.Value] = item.Key;
			}
			for (int i = 0; i < teamAssignObject.Rooms.Count; i++)
			{
				teamAssignObject.Rooms[i].SaveMask(array);
			}
		}
		catch (InvalidOperationException)
		{
			TeamAssignmentDirty = true;
		}
		catch (NullReferenceException)
		{
			TeamAssignmentDirty = true;
		}
		catch (IndexOutOfRangeException)
		{
			TeamAssignmentDirty = true;
		}
		catch (ArgumentOutOfRangeException)
		{
			TeamAssignmentDirty = true;
		}
		catch (Exception ex5)
		{
			TeamAssignmentDirty = true;
			ErrorLogging.AddException(ex5);
		}
		finally
		{
			TeamAssignmentRunning = false;
		}
	}

	private void SubTeamRoad(RoadSegment start, int teamCount, HashSet<RoadSegment> visited, HashSet<Room> visited2, HashSet<PathNode<Vector3>> visitedNodes)
	{
		if (!visited.Add(start))
		{
			return;
		}
		List<PathNode<Vector3>> connections = start.Self.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			PathNode<Vector3> pathNode = connections[i];
			RoomSegment roomSegment = pathNode.Tag as RoomSegment;
			if (roomSegment != null)
			{
				Room room = (Room)((roomSegment.ParentRooms[0] != null) ? roomSegment.ParentRooms[0] : roomSegment.ParentRooms[1]);
				if (room != null && !room.Outside)
				{
					SubRunTeamAlgo(room, null, new MultiBitMask(teamCount, false), visited2, visitedNodes);
				}
			}
			else
			{
				RoadSegment roadSegment = pathNode.Tag as RoadSegment;
				if (roadSegment != null && roadSegment.floor > 0)
				{
					SubTeamRoad(roadSegment, teamCount, visited, visited2, visitedNodes);
				}
			}
		}
	}

	private void SubRunTeamAlgo(Room from, PathNode<Vector3> specificNode, MultiBitMask mask, HashSet<Room> visited, HashSet<PathNode<Vector3>> visitedNodes)
	{
		if (TeamAssignmentDirty)
		{
			return;
		}
		bool flag = specificNode != null && from.Outside && !specificNode.OutsideAccessible;
		if ((!flag || !visitedNodes.Add(specificNode)) && (flag || !visited.Add(from)))
		{
			return;
		}
		if (flag || (!from.Outside && !from.TeamMask.IsNull))
		{
			MultiBitMask multiBitMask = (from.Outside ? mask : mask.And(from.TeamMask));
			bool flag2 = false;
			if (flag)
			{
				flag2 = true;
			}
			else if (from.AllowPass)
			{
				if (!mask.AndTest(from.PseudoMask))
				{
					from.Mask.OrSelf(multiBitMask);
					from.PseudoMask.OrSelf(mask);
					flag2 = true;
				}
			}
			else if (!multiBitMask.AndTest(from.Mask))
			{
				from.Mask.OrSelf(multiBitMask);
				mask = multiBitMask;
				flag2 = true;
			}
			if (flag2)
			{
				if (flag)
				{
					List<PathNode<Vector3>> connections = specificNode.GetConnections();
					for (int i = 0; i < connections.Count; i++)
					{
						TeamAlgoSubRoom(connections[i], mask, visited, visitedNodes);
					}
				}
				else
				{
					for (int j = 0; j < from.PathNodes.Count; j++)
					{
						if (from.PathNodes[j].OutsideAccessible)
						{
							List<PathNode<Vector3>> connections2 = from.PathNodes[j].GetConnections();
							for (int k = 0; k < connections2.Count; k++)
							{
								TeamAlgoSubRoom(connections2[k], mask, visited, visitedNodes);
							}
						}
					}
				}
			}
		}
		visited.Remove(from);
	}

	private void TeamAlgoSubRoom(PathNode<Vector3> node, MultiBitMask mask, HashSet<Room> visited, HashSet<PathNode<Vector3>> visitedNodes)
	{
		List<PathNode<Vector3>> connections = node.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			PathNode<Vector3> pathNode = connections[i];
			Room room = pathNode.Tag as Room;
			if (room != null)
			{
				SubRunTeamAlgo(room, pathNode, mask, visited, visitedNodes);
				continue;
			}
			Furniture furniture = pathNode.Tag as Furniture;
			if (furniture != null)
			{
				if ("Elevator".Equals(furniture.Type))
				{
					TeamAlgoElevatorRun(furniture, null, mask, visited, visitedNodes);
				}
				else if ("Portal".Equals(furniture.Type))
				{
					SubRunTeamAlgo(furniture.Parent, pathNode, mask, visited, visitedNodes);
				}
			}
		}
	}

	private void TeamAlgoElevatorRun(Furniture el, Furniture from, MultiBitMask mask, HashSet<Room> visited, HashSet<PathNode<Vector3>> visitedNodes)
	{
		if (el.CanExitElevator)
		{
			List<PathNode<Vector3>> connections = el.pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				Room room = connections[i].Tag as Room;
				if (room != null)
				{
					SubRunTeamAlgo(room, el.pathNode, mask, visited, visitedNodes);
				}
			}
			return;
		}
		List<PathNode<Vector3>> connections2 = el.pathNode.GetConnections();
		for (int j = 0; j < connections2.Count; j++)
		{
			Furniture furniture;
			if ((object)(furniture = connections2[j].Tag as Furniture) != null && "Elevator".Equals(furniture.Type) && furniture != from)
			{
				TeamAlgoElevatorRun(furniture, el, mask, visited, visitedNodes);
			}
		}
	}

	public PlayerMap GetMap(NetworkPlayer player)
	{
		return GetMap(player.ID);
	}

	public PlayerMap GetMap(byte id)
	{
		PlayerMap value;
		if (!PlayerMaps.TryGetValue(id, out value))
		{
			return PlayerMaps[id] = new PlayerMap(id);
		}
		return value;
	}
}
