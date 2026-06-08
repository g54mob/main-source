using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class NavigationHelper
{
	private static List<Waypoint> _allWaypoints = null;

	private static List<AdjacentRoomData> _adjacentRoomData = new List<AdjacentRoomData>();

	private static AStarSearch _aStarSearch = new AStarSearch();

	public static List<Waypoint> FindPath(Waypoint start, Waypoint end)
	{
		return FindPath(start, end, true);
	}

	public static List<Waypoint> FindPath(Waypoint start, Waypoint end, bool stopAtBlocked)
	{
		if (start == end)
		{
			List<Waypoint> list = new List<Waypoint>();
			list.Add(end);
			return list;
		}
		List<Waypoint> list2 = new List<Waypoint>();
		if (_aStarSearch.Search(start, end, list2, stopAtBlocked))
		{
			OptimizePath(list2);
			return list2;
		}
		return null;
	}

	private static void OptimizePath(List<Waypoint> path)
	{
		if (path.Count > 1 && path.First().Room != path.Last().Room)
		{
			List<Waypoint> list = new List<Waypoint>();
			int count = path.Count;
			for (int i = 0; i < count; i++)
			{
				Waypoint waypoint = path[i];
				if (waypoint.WaypointType != WaypointTypeEnum.Door && waypoint.Room != path.Last().Room)
				{
					list.Add(waypoint);
				}
			}
			if (path[0].Door != null && path[0].Room == path[1].Room && !list.Contains(path[0]))
			{
				list.Add(path[0]);
			}
			list.ForEach(delegate(Waypoint x)
			{
				path.Remove(x);
			});
		}
		for (int num = 0; num < path.Count; num++)
		{
			if (path[num].AuxWaypoint != null)
			{
				path[num] = path[num].AuxWaypoint;
			}
		}
	}

	private static List<Waypoint> FindPathAdjacentOnly(Waypoint start, Waypoint end, bool stopAtBlocked)
	{
		AdjacentRoomData adjacentRoomData = GetAdjacentRoomData(start, end);
		if (adjacentRoomData != null && stopAtBlocked && adjacentRoomData.ConnectingDoor.state != DoorState.Open)
		{
			adjacentRoomData = null;
		}
		if (adjacentRoomData != null)
		{
			List<Waypoint> list = null;
			if (adjacentRoomData.ConnectingWaypoints.FirstOrDefault() == start)
			{
				list = adjacentRoomData.ConnectingWaypoints.ToList();
			}
			else
			{
				list = adjacentRoomData.ConnectingWaypoints.ToList();
				list.Reverse();
			}
			return list;
		}
		return null;
	}

	public static List<Waypoint> GetWaypoints()
	{
		LoadAllWaypoints();
		return _allWaypoints;
	}

	public static List<Waypoint> GetWaypoints(WaypointTypeEnum type)
	{
		return (from x in GetWaypoints()
			where x.WaypointType == type
			select x).ToList();
	}

	public static List<Waypoint> GetWaypoints(WaypointTypeEnum type, Room room)
	{
		return (from x in GetWaypoints()
			where x.WaypointType == type && x.Room == room
			select x).ToList();
	}

	public static void Clear()
	{
		_allWaypoints = null;
		_adjacentRoomData = new List<AdjacentRoomData>();
	}

	public static void Refresh()
	{
		if (_allWaypoints != null)
		{
			Object[] array = Object.FindObjectsOfType(typeof(Waypoint));
			Object[] array2 = array;
			foreach (Object obj in array2)
			{
				Waypoint waypoint = (Waypoint)obj;
				if (waypoint.AuxWaypoint != null)
				{
					waypoint.AuxWaypoint = null;
				}
			}
		}
		Clear();
		LoadAllWaypoints();
		foreach (Waypoint allWaypoint in _allWaypoints)
		{
			allWaypoint.CalculateDistancesToConnectedWaypoints();
		}
		EventManager.Instance.Publish(GeneralEventType.RefreshNavigation);
	}

	public static void LoadAllWaypoints()
	{
		if (_allWaypoints != null)
		{
			return;
		}
		DungeonManager instance = DungeonManager.Instance;
		Object[] array = Object.FindObjectsOfType(typeof(Waypoint));
		_allWaypoints = new List<Waypoint>();
		Object[] array2 = array;
		foreach (Object obj in array2)
		{
			Waypoint waypoint = (Waypoint)obj;
			_allWaypoints.Add(waypoint);
			waypoint.GetComponent<Renderer>().enabled = false;
			if (waypoint.WaypointType == WaypointTypeEnum.None || waypoint.WaypointType == WaypointTypeEnum.Door)
			{
				Corridor[] corridors = instance.corridors;
				foreach (Corridor corridor in corridors)
				{
					if (corridor.GetComponent<Collider>().bounds.Intersects(waypoint.GetComponent<Collider>().bounds))
					{
						waypoint.WaypointType = WaypointTypeEnum.Door;
						waypoint.Door = corridor.door;
						waypoint.name = "Waypoint Door: " + corridor.door.Label;
						break;
					}
				}
			}
			Room[] rooms = instance.rooms;
			foreach (Room room in rooms)
			{
				if (room.GetComponent<Collider>().bounds.Intersects(waypoint.GetComponent<Collider>().bounds))
				{
					waypoint.Room = room;
					break;
				}
			}
		}
		LoadAllAdjacentRoomData();
	}

	public static Dictionary<Waypoint, List<Waypoint>> GetAccessibleAdjacentRoomWaypoints(Waypoint startingWaypoint)
	{
		if (!startingWaypoint.IsMainRoomWaypoint)
		{
			startingWaypoint = GetMainRoomWaypoint(startingWaypoint.Room);
		}
		Dictionary<Waypoint, List<Waypoint>> dictionary = new Dictionary<Waypoint, List<Waypoint>>();
		Stack<Waypoint> stack = new Stack<Waypoint>();
		foreach (Waypoint connectedRoom in startingWaypoint.ConnectedRooms)
		{
			stack.Clear();
			if (FindWaypointRecursive(startingWaypoint, connectedRoom, stack, true, 5))
			{
				dictionary.Add(connectedRoom, stack.Reverse().ToList());
			}
		}
		return dictionary;
	}

	public static Dictionary<Waypoint, List<Waypoint>> GetAdjacentRoomWaypoints(Waypoint startingWaypoint)
	{
		Dictionary<Waypoint, List<Waypoint>> dictionary = new Dictionary<Waypoint, List<Waypoint>>();
		Stack<Waypoint> stack = new Stack<Waypoint>();
		foreach (Waypoint connectedRoom in startingWaypoint.ConnectedRooms)
		{
			stack.Clear();
			if (FindWaypointRecursive(startingWaypoint, connectedRoom, stack, false, 5))
			{
				if (!dictionary.ContainsKey(connectedRoom))
				{
					dictionary.Add(connectedRoom, stack.Reverse().ToList());
				}
			}
			else
			{
				Debug.Log(string.Format("GetAdjacentRoomWaypoints - did not find path from {0} to {1}", startingWaypoint.Room, connectedRoom.Room));
			}
		}
		return dictionary;
	}

	private static bool FindWaypointRecursive(Waypoint current, Waypoint end, Stack<Waypoint> pathSoFar, bool stopAtBlocked, int maxDepth)
	{
		pathSoFar.Push(current);
		if (stopAtBlocked && current.IsBlocked())
		{
			pathSoFar.Pop();
			return false;
		}
		if (current == end)
		{
			return true;
		}
		if (pathSoFar.Count >= maxDepth)
		{
			pathSoFar.Pop();
			return false;
		}
		IEnumerable<Waypoint> enumerable = current.ConnectedWaypoints.Where((Waypoint x) => !pathSoFar.Any((Waypoint p) => p == x));
		bool flag = false;
		foreach (Waypoint item in enumerable)
		{
			flag = FindWaypointRecursive(item, end, pathSoFar, stopAtBlocked, maxDepth);
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			pathSoFar.Pop();
		}
		return flag;
	}

	public static List<Waypoint> GetDoorWaypointsInThisRoom(Room room)
	{
		List<Waypoint> waypoints = GetWaypoints(WaypointTypeEnum.Door);
		return waypoints.Where((Waypoint x) => x.Room == room).ToList();
	}

	private static void LoadAllAdjacentRoomData()
	{
		_adjacentRoomData.Clear();
		foreach (Waypoint item in _allWaypoints.Where((Waypoint x) => x.IsMainRoomWaypoint))
		{
			LoadAdjacentRoomDataForThisRoomWaypoint(item);
		}
	}

	private static void LoadAdjacentRoomDataForThisRoomWaypoint(Waypoint roomWaypoint)
	{
		Dictionary<Waypoint, List<Waypoint>> adjacentRoomWaypoints = GetAdjacentRoomWaypoints(roomWaypoint);
		foreach (KeyValuePair<Waypoint, List<Waypoint>> item in adjacentRoomWaypoints)
		{
			Waypoint adjacentWaypoint = item.Key;
			List<Waypoint> value = item.Value;
			if (_adjacentRoomData.Any((AdjacentRoomData x) => x.IsDataForTheseRooms(roomWaypoint.Room, adjacentWaypoint.Room)))
			{
				continue;
			}
			AdjacentRoomData adjacentRoomData = new AdjacentRoomData();
			adjacentRoomData.Room1 = roomWaypoint.Room;
			adjacentRoomData.Room2 = adjacentWaypoint.Room;
			adjacentRoomData.ConnectingWaypoints = value;
			Dictionary<Door, List<Waypoint>> dictionary = new Dictionary<Door, List<Waypoint>>();
			foreach (Waypoint item2 in value.Where((Waypoint x) => x.Door != null))
			{
				if (!dictionary.ContainsKey(item2.Door))
				{
					dictionary.Add(item2.Door, new List<Waypoint>());
				}
				dictionary[item2.Door].Add(item2);
			}
			if (dictionary.Any((KeyValuePair<Door, List<Waypoint>> x) => x.Value.Any((Waypoint y) => y.Room == roomWaypoint.Room) && x.Value.Any((Waypoint y) => y.Room == adjacentWaypoint.Room)))
			{
				KeyValuePair<Door, List<Waypoint>> doorWaypointPair = dictionary.First((KeyValuePair<Door, List<Waypoint>> x) => x.Value.Any((Waypoint y) => y.Room == roomWaypoint.Room) && x.Value.Any((Waypoint y) => y.Room == adjacentWaypoint.Room));
				adjacentRoomData.ConnectingDoor = doorWaypointPair.Key;
				Vector3 vector = doorWaypointPair.Value.First().transform.position - doorWaypointPair.Value.Last().transform.position;
				float num = Mathf.Abs(vector.x);
				float num2 = Mathf.Abs(vector.y);
				if (num > num2)
				{
					adjacentRoomData.ConnectingDoor.IsHorizontal = true;
				}
				else
				{
					adjacentRoomData.ConnectingDoor.IsHorizontal = false;
				}
				CreateAuxRoomWaypoints(adjacentRoomData, doorWaypointPair);
			}
			else
			{
				Debug.Log(string.Format("Could not find door between {0} and {1}", adjacentRoomData.Room1, adjacentRoomData.Room2));
			}
			_adjacentRoomData.Add(adjacentRoomData);
		}
	}

	private static void CreateAuxRoomWaypoints(AdjacentRoomData adjacentData, KeyValuePair<Door, List<Waypoint>> doorWaypointPair)
	{
		DungeonManager instance = DungeonManager.Instance;
		Waypoint waypoint = null;
		Waypoint waypoint2 = null;
		if (doorWaypointPair.Value.First().Room == adjacentData.Room1)
		{
			waypoint = doorWaypointPair.Value.First();
			waypoint2 = doorWaypointPair.Value.Last();
		}
		else
		{
			waypoint = doorWaypointPair.Value.Last();
			waypoint2 = doorWaypointPair.Value.First();
		}
		Vector3 position;
		Vector3 position2;
		if (adjacentData.ConnectingDoor.IsHorizontal)
		{
			float num = 1f;
			if (adjacentData.Room1.transform.position.x < waypoint.transform.position.x)
			{
				num = 0f - num;
			}
			position = new Vector3(waypoint.transform.position.x + num, waypoint.transform.position.y, waypoint.transform.position.z);
			num = 1f;
			if (adjacentData.Room2.transform.position.x < waypoint2.transform.position.x)
			{
				num = 0f - num;
			}
			position2 = new Vector3(waypoint2.transform.position.x + num, waypoint2.transform.position.y, waypoint2.transform.position.z);
		}
		else
		{
			float num2 = 1f;
			if (adjacentData.Room1.transform.position.y < waypoint.transform.position.y)
			{
				num2 = 0f - num2;
			}
			position = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y + num2, waypoint.transform.position.z);
			num2 = 1f;
			if (adjacentData.Room2.transform.position.y < waypoint2.transform.position.y)
			{
				num2 = 0f - num2;
			}
			position2 = new Vector3(waypoint2.transform.position.x, waypoint2.transform.position.y + num2, waypoint2.transform.position.z);
		}
		GameObject gameObject = instance.InstantiateGameObject(waypoint.gameObject);
		gameObject.transform.position = position;
		gameObject.name = string.Format("Aux Door Waypoint - ({0}, {1})", adjacentData.ConnectingDoor.Label, adjacentData.Room1.Label);
		Waypoint component = gameObject.GetComponent<Waypoint>();
		component.WaypointType = WaypointTypeEnum.AuxDoor;
		component.IsMainRoomWaypoint = false;
		component.ConnectedRooms.Clear();
		component.ConnectedWaypoints.Clear();
		component.WaypointEdges.Clear();
		component.Door = adjacentData.ConnectingDoor;
		component.Room = adjacentData.Room1;
		GameObject gameObject2 = instance.InstantiateGameObject(waypoint2.gameObject);
		gameObject2.transform.position = position2;
		gameObject2.name = string.Format("Aux Door Waypoint - ({0}, {1})", adjacentData.ConnectingDoor.Label, adjacentData.Room2.Label);
		Waypoint component2 = gameObject2.GetComponent<Waypoint>();
		component2.WaypointType = WaypointTypeEnum.AuxDoor;
		component2.IsMainRoomWaypoint = false;
		component2.ConnectedRooms.Clear();
		component2.ConnectedWaypoints.Clear();
		component2.WaypointEdges.Clear();
		component2.Door = adjacentData.ConnectingDoor;
		component2.Room = adjacentData.Room2;
		waypoint.AuxWaypoint = component;
		waypoint2.AuxWaypoint = component2;
	}

	public static AdjacentRoomData GetAdjacentRoomData(Waypoint roomWaypointA, Waypoint roomWaypointB)
	{
		int count = _adjacentRoomData.Count;
		for (int i = 0; i < count; i++)
		{
			AdjacentRoomData adjacentRoomData = _adjacentRoomData[i];
			if (adjacentRoomData.IsDataForTheseRooms(roomWaypointA.Room, roomWaypointB.Room))
			{
				return adjacentRoomData;
			}
		}
		return null;
	}

	public static AdjacentRoomData GetAdjacentRoomData(Door door)
	{
		int count = _adjacentRoomData.Count;
		for (int i = 0; i < count; i++)
		{
			AdjacentRoomData adjacentRoomData = _adjacentRoomData[i];
			if (adjacentRoomData.ConnectingDoor == door)
			{
				return adjacentRoomData;
			}
		}
		return null;
	}

	public static IEnumerable<AdjacentRoomData> GetAllAdjacentRoomData(Room room)
	{
		return _adjacentRoomData.Where((AdjacentRoomData x) => x.Room1 == room || x.Room2 == room);
	}

	public static Waypoint GetMainRoomWaypoint(Room room)
	{
		int count = _allWaypoints.Count;
		for (int i = 0; i < count; i++)
		{
			Waypoint waypoint = _allWaypoints[i];
			if (waypoint.IsMainRoomWaypoint && waypoint.Room == room)
			{
				return waypoint;
			}
		}
		return null;
	}
}
