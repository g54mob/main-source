using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using UnityEngine;

public class PlayerMap
{
	public byte Player;

	public Dictionary<uint, NetworkRoom> Rooms = new Dictionary<uint, NetworkRoom>();

	public Dictionary<uint, Roof> Roofs = new Dictionary<uint, Roof>();

	public Dictionary<uint, RoomSegment> Segments = new Dictionary<uint, RoomSegment>();

	public DictionaryList<uint, Furniture> Furnitures = new DictionaryList<uint, Furniture>();

	public Dictionary<int, List<WallEdge>> WallEdges = new Dictionary<int, List<WallEdge>>();

	private HashSet<WallSnap> _dirtySnaps = new HashSet<WallSnap>();

	private int _refreshFurnEdgeNum;

	private int _refreshFurnEdgeOffset;

	public void UpdateEdgeDetection()
	{
		_refreshFurnEdgeNum = Furnitures.Count;
	}

	public void RefreshVisibility()
	{
		if (Furnitures.Count <= 0)
		{
			return;
		}
		_refreshFurnEdgeNum = Mathf.Min(_refreshFurnEdgeNum, Furnitures.Count);
		int num = Mathf.Min(_refreshFurnEdgeNum, Mathf.Max(100, Furnitures.Count / 5));
		for (int i = 0; i < num; i++)
		{
			Furniture furniture = Furnitures[(_refreshFurnEdgeOffset + i) % Furnitures.Count];
			if (furniture != null)
			{
				furniture.RefreshEdgeDetection();
			}
		}
		_refreshFurnEdgeNum -= num;
		_refreshFurnEdgeOffset = (_refreshFurnEdgeOffset + num) % Furnitures.Count;
	}

	public void RefreshSnaps()
	{
		if (_dirtySnaps.Count <= 0)
		{
			return;
		}
		foreach (WallSnap dirtySnap in _dirtySnaps)
		{
			if (dirtySnap != null && dirtySnap.GetPrimarySaveRoom() == null)
			{
				dirtySnap.TryPlace(WallEdges.GetOrNull(dirtySnap.GetFloor()));
			}
		}
		_dirtySnaps.Clear();
	}

	public void UpdateRooms()
	{
		foreach (NetworkRoom value in Rooms.Values)
		{
			value.UpdateMe();
		}
	}

	public PlayerMap()
	{
	}

	public void Destroy()
	{
		foreach (KeyValuePair<uint, NetworkRoom> room in Rooms)
		{
			if (room.Value != null)
			{
				if (room.Value.Floor == 0)
				{
					GrassSystem.Instance.InvalidateArea();
				}
				Object.Destroy(room.Value.gameObject);
			}
		}
		foreach (KeyValuePair<uint, Roof> roof in Roofs)
		{
			if (roof.Value != null)
			{
				Object.Destroy(roof.Value.gameObject);
			}
		}
		foreach (KeyValuePair<uint, RoomSegment> segment in Segments)
		{
			if (segment.Value != null)
			{
				Object.Destroy(segment.Value.gameObject);
			}
		}
		for (int i = 0; i < Furnitures.Count; i++)
		{
			Furniture furniture = Furnitures[i];
			if (furniture != null)
			{
				Object.Destroy(furniture.gameObject);
			}
		}
	}

	public void DirtyAllSnaps(NetworkRoom room)
	{
		_dirtySnaps.AddRange(room.GetSnaps());
	}

	public void DestroyObject(uint id)
	{
		NetworkRoom value;
		Roof value2;
		RoomSegment value3;
		if (Rooms.TryGetValue(id, out value))
		{
			if (value.Floor == 0)
			{
				GrassSystem.Instance.InvalidateArea();
			}
			DirtyAllSnaps(value);
			Object.Destroy(value.gameObject);
			Rooms.Remove(id);
		}
		else if (Roofs.TryGetValue(id, out value2))
		{
			Object.Destroy(value2.gameObject);
			Roofs.Remove(id);
		}
		else if (Segments.TryGetValue(id, out value3))
		{
			if (value3 == null)
			{
				Segments.Remove(id);
				return;
			}
			value3.RemoveFromWallEdges();
			_dirtySnaps.Remove(value3);
			Object.Destroy(value3.gameObject);
			Segments.Remove(id);
			DirtyParents(value3);
		}
		else
		{
			Furniture value4;
			if (!Furnitures.TryGetValue(id, out value4))
			{
				return;
			}
			if (value4 == null)
			{
				Furnitures.Remove(id);
				return;
			}
			if (value4.WallFurn)
			{
				value4.RemoveFromWallEdges();
			}
			_dirtySnaps.Remove(value4);
			Object.Destroy(value4.gameObject);
			Furnitures.Remove(id);
		}
	}

	public void DirtyParents(RoomSegment seg)
	{
		for (int i = 0; i < seg.ParentRooms.Length; i++)
		{
			NetworkRoom networkRoom;
			if ((object)(networkRoom = seg.ParentRooms[i] as NetworkRoom) != null)
			{
				networkRoom.MakeDirty();
			}
		}
	}

	public PlayerMap(byte player)
	{
		Player = player;
	}

	public PlayerMap(byte player, BuildingPrefab map)
	{
		Player = player;
		Sync(map);
	}

	public void Sync(BuildingPrefab map)
	{
		for (int i = 0; i < map.Rooms.Length; i++)
		{
			BuildingPrefab.RoomObject roomObject = map.Rooms[i];
			NetworkRoom r;
			if (Rooms.TryGetValue(roomObject.RoomGroupID, out r))
			{
				DirtyAllSnaps(r);
				r.Edges.ForEach(delegate(WallEdge x)
				{
					CleanEdge(x, r);
				});
				r.SetData(map, i);
			}
			else
			{
				GameObject gameObject = new GameObject("NetworkRoom");
				r = gameObject.AddComponent<NetworkRoom>();
				r.Init(this, map, i);
				Rooms[r.NetworkID] = r;
			}
			BuildingPrefab.SegmentObject[] segments = roomObject.Segments;
			foreach (BuildingPrefab.SegmentObject segment in segments)
			{
				SyncSegment(segment, r);
			}
		}
		for (int num2 = 0; num2 < map.Roofs.Length; num2++)
		{
			Roof value;
			if (Roofs.TryGetValue(map.Roofs[num2].NetworkID, out value))
			{
				if (!value.Init(map, num2, this))
				{
					DestroyObject(value.NetworkID);
				}
				continue;
			}
			Roof roof = Object.Instantiate(HUD.Instance.roofEditWindow.RoofPrefab);
			if (roof.Init(map, num2, this))
			{
				Roofs[roof.NetworkID] = roof;
			}
			else
			{
				Object.Destroy(roof.gameObject);
			}
		}
	}

	public void MoveFurniture(Furniture furniture, Vector3 position, int floor, float rot, float rotOffset, uint room, uint parent, int snapID, bool isReversed)
	{
		Vector2 vector = new Vector2(position.x, position.z);
		float num = position.y.GetFloorOffset(floor);
		if (furniture.CustomHeight && num == 0f)
		{
			num = furniture.WallHeight;
		}
		position = new Vector3(vector.x, (float)(floor * 2) + num, vector.y);
		SnapPoint snapPoint = null;
		if (furniture.IsSnapping && parent != 0)
		{
			Furniture value;
			if (!Furnitures.TryGetValue(parent, out value))
			{
				Debug.Log("Tried moving network furniture, but missing snapping parent: " + furniture.name);
				return;
			}
			snapPoint = value.SnapPoints.FirstOrDefault((SnapPoint x) => x.Id == snapID);
			if (snapPoint == null)
			{
				Debug.Log("Tried moving network furniture, but snap point did not exist in parent: " + furniture.name);
				return;
			}
			position = snapPoint.transform.position;
		}
		WallEdge wallEdge = null;
		WallEdge edge = null;
		float wallPos = 0f;
		NetworkRoom networkRoom = ((room != 0) ? Rooms.GetOrNull(room) : null);
		if (furniture.WallFurn)
		{
			if (networkRoom == null)
			{
				Debug.Log("Tried moving network furniture, but missing parent to snap wall: " + furniture.name);
				return;
			}
			List<WallEdge> edges = networkRoom.Edges;
			for (int num2 = 0; num2 < edges.Count; num2++)
			{
				WallEdge wallEdge2 = edges[num2];
				WallEdge wallEdge3 = edges[(num2 + 1) % edges.Count];
				Vector2 res;
				if (Utilities.ProjectToLine(vector, wallEdge2.Pos, wallEdge3.Pos, out res) && (vector - res).magnitude < 0.1f)
				{
					wallEdge = wallEdge2;
					edge = wallEdge3;
					wallPos = (wallEdge2.Pos - res).magnitude / (wallEdge2.Pos - wallEdge3.Pos).magnitude;
					break;
				}
			}
			if (wallEdge == null)
			{
				Debug.Log("Tried moving network furniture, but couldn't find appropriate wall to snap to");
				return;
			}
		}
		FurnitureBuilder.NetworkMoveFurn(position, rot, floor, wallEdge, edge, wallPos, isReversed, snapPoint, furniture.gameObject, rotOffset, networkRoom);
	}

	public void SyncFurniture(BuildingPrefab.FurnitureObject furniture)
	{
		if (!Furnitures.ContainsKey(furniture.ID))
		{
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(furniture.Name);
			if (furnitureComponent == null)
			{
				Debug.Log("Tried syncing furniture missing on client: " + furniture.Name);
				return;
			}
			Vector2 vector = new Vector2(furniture.Position.x, furniture.Position.z);
			float num = furniture.Position.y.GetFloorOffset(furniture.Floor);
			if (furnitureComponent.CustomHeight && num == 0f)
			{
				num = furnitureComponent.WallHeight;
			}
			Vector3 pos = new Vector3(vector.x, (float)(furniture.Floor * 2) + num, vector.y);
			SnapPoint snapPoint = null;
			bool flag = furnitureComponent.IsSnapping && (!furnitureComponent.CanNotSnap || furniture.Parent != 0);
			if (flag)
			{
				Furniture value;
				if (!Furnitures.TryGetValue(furniture.Parent, out value))
				{
					Debug.Log("Tried syncing furniture, but missing snapping parent: " + furniture.Name);
					return;
				}
				snapPoint = value.SnapPoints.FirstOrDefault((SnapPoint x) => x.Id == furniture.SnapID);
				if (snapPoint == null)
				{
					Debug.Log("Tried syncing furniture, but snap point did not exist in parent: " + furniture.Name);
					return;
				}
				pos = snapPoint.transform.position;
			}
			WallEdge wallEdge = null;
			WallEdge edge = null;
			float wallPos = 0f;
			NetworkRoom networkRoom = ((furniture.ParentNetworkRoom != 0) ? Rooms.GetOrNull(furniture.ParentNetworkRoom) : null);
			if (furnitureComponent.WallFurn)
			{
				if (networkRoom == null)
				{
					Debug.Log("Tried syncing furniture, but missing parent to snap wall: " + furniture.Name);
					return;
				}
				List<WallEdge> edges = networkRoom.Edges;
				for (int num2 = 0; num2 < edges.Count; num2++)
				{
					WallEdge wallEdge2 = edges[num2];
					WallEdge wallEdge3 = edges[(num2 + 1) % edges.Count];
					Vector2 res;
					if (Utilities.ProjectToLine(vector, wallEdge2.Pos, wallEdge3.Pos, out res) && (vector - res).magnitude < 0.1f)
					{
						wallEdge = wallEdge2;
						edge = wallEdge3;
						wallPos = (wallEdge2.Pos - res).magnitude / (wallEdge2.Pos - wallEdge3.Pos).magnitude;
						break;
					}
				}
				if (wallEdge == null)
				{
					Debug.Log("Tried syncing furniture, but couldn't find appropriate wall to snap to");
					return;
				}
			}
			Quaternion identity = Quaternion.identity;
			Furniture furniture2 = FurnitureBuilder.MakeFurnNetwork(rot: (!flag) ? furniture.Rotation.ToQuaternion() : (Quaternion.Euler(0f, furniture.RotationOffset, 0f) * snapPoint.transform.rotation), id: furniture.ID, pos: pos, rotOffset: furniture.RotationOffset, floor: furniture.Floor, edge1: wallEdge, edge2: edge, wallPos: wallPos, reverseWall: furniture.IsReversed, snap: snapPoint, furnFab: furnitureComponent.gameObject, map: this, parent: networkRoom);
			FurnitureBuilder.CopyStyle(furniture, furniture2);
			Furnitures[furniture.ID] = furniture2;
		}
		else
		{
			Debug.Log("Tried syncing existing furniture: " + furniture.Name + " - " + furniture.ID);
		}
	}

	public void SyncSegment(BuildingPrefab.SegmentObject segment, IRoom r)
	{
		RoomSegment value;
		if (!Segments.TryGetValue(segment.NetworkID, out value) || value == null)
		{
			RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(segment.Name);
			if (!(segmentComponent != null))
			{
				return;
			}
			Vector2 vector = new Vector2(segment.Position.x, segment.Position.z);
			int floor = r.Floor;
			List<WallEdge> value2;
			if (!WallEdges.TryGetValue(floor, out value2))
			{
				return;
			}
			for (int i = 0; i < value2.Count; i++)
			{
				WallEdge wallEdge = value2[i];
				WallEdge value3;
				Vector2 res;
				if (wallEdge.Links.TryGetValue(r, out value3) && Utilities.ProjectToLine(vector, wallEdge.Pos, value3.Pos, out res) && (vector - res).magnitude < 0.1f)
				{
					if (segment.Reversed)
					{
						WallEdge wallEdge2 = wallEdge;
						wallEdge = value3;
						value3 = wallEdge2;
					}
					RoomSegment roomSegment = Object.Instantiate(segmentComponent);
					roomSegment.Map = this;
					roomSegment.NetworkID = segment.NetworkID;
					Segments[roomSegment.NetworkID] = roomSegment;
					roomSegment.name = segmentComponent.name;
					RoomSegment component = roomSegment.GetComponent<RoomSegment>();
					if (segmentComponent.DynamicWidth)
					{
						component.FixDynamicWidth(segment.Width);
					}
					component.Floor = floor;
					component.transform.position = new Vector3(component.transform.position.x, floor * 2, component.transform.position.z);
					component.Init(wallEdge, value3, (wallEdge.Pos - res).magnitude / (wallEdge.Pos - value3.Pos).magnitude, true);
					DirtyParents(component);
					if (segment.Colors != null)
					{
						component.ColorPrimary = (component.ColorPrimaryEnabled ? segment.Colors[0].ToColor() : component.ColorPrimaryDefault);
						component.ColorSecondary = (component.ColorSecondaryEnabled ? segment.Colors[1].ToColor() : component.ColorSecondaryDefault);
						component.ColorTertiary = (component.ColorTertiaryEnabled ? segment.Colors[2].ToColor() : component.ColorTertiaryDefault);
						component.AtlasIndex = segment.AtlasIndex;
						component.DisableInitColor = true;
					}
					break;
				}
			}
			return;
		}
		Vector2 vector2 = new Vector2(segment.Position.x, segment.Position.z);
		int floor2 = r.Floor;
		List<WallEdge> list = WallEdges[floor2];
		for (int j = 0; j < list.Count; j++)
		{
			WallEdge wallEdge3 = list[j];
			WallEdge value4;
			Vector2 res2;
			if (wallEdge3.Links.TryGetValue(r, out value4) && Utilities.ProjectToLine(vector2, wallEdge3.Pos, value4.Pos, out res2) && (vector2 - res2).magnitude < 0.1f)
			{
				if (segment.Reversed)
				{
					WallEdge wallEdge4 = wallEdge3;
					wallEdge3 = value4;
					value4 = wallEdge4;
				}
				if (value.DynamicWidth)
				{
					value.FixDynamicWidth(segment.Width);
				}
				value.Floor = floor2;
				value.transform.position = new Vector3(value.transform.position.x, floor2 * 2, value.transform.position.z);
				value.Init(wallEdge3, value4, (wallEdge3.Pos - res2).magnitude / (wallEdge3.Pos - value4.Pos).magnitude, true);
				break;
			}
		}
	}

	public byte[] SerializeData()
	{
		BuildingPrefab buildingPrefab = BuildingPrefab.SaveNetworkRooms(Rooms.Values.ToArray(), Roofs.Values.ToArray());
		using (MemoryStream memoryStream = new MemoryStream())
		{
			buildingPrefab.WriteData(memoryStream);
			memoryStream.WriteArray(from x in Furnitures
				where x != null
				select new BuildingPrefab.FurnitureObject(x, true), delegate(Stream s, BuildingPrefab.FurnitureObject x)
			{
				x.WriteData(s);
			});
			return memoryStream.ToArray();
		}
	}

	public WriteDictionary Serialize()
	{
		WriteDictionary writeDictionary = new WriteDictionary("NetworkPlayerMap");
		writeDictionary["PlayerID"] = Player;
		writeDictionary["MapData"] = SerializeData();
		return writeDictionary;
	}

	public static WriteDictionary CreateLocalData()
	{
		WriteDictionary writeDictionary = new WriteDictionary("NetworkPlayerMap");
		writeDictionary["PlayerID"] = NetworkManager.Self.ID;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			BuildingPrefab.SaveRoomsForNetwork(GameSettings.Instance.sRoomManager.Rooms.ToArray(), GameSettings.Instance.sRoomManager.Roofs.ToArray(), true).WriteData(memoryStream);
			memoryStream.WriteArray(from x in GameSettings.Instance.sRoomManager.AllFurniture
				where x.IsNetworkValid()
				select new BuildingPrefab.FurnitureObject(x, true), delegate(Stream s, BuildingPrefab.FurnitureObject x)
			{
				x.WriteData(s);
			});
			writeDictionary["MapData"] = memoryStream.ToArray();
			return writeDictionary;
		}
	}

	public void Deserialize(WriteDictionary data)
	{
		Player = data.Get("PlayerID", (byte)0);
		using (MemoryStream memoryStream = new MemoryStream(data.Get<byte[]>("MapData")))
		{
			Sync(BuildingPrefab.ReadData(memoryStream));
			BuildingPrefab.FurnitureObject[] array = memoryStream.ReadArray(BuildingPrefab.FurnitureObject.ReadData);
			for (int i = 0; i < array.Length; i++)
			{
				SyncFurniture(array[i]);
			}
		}
	}

	public WallEdge GetEdge(Vector2 p, int floor, bool create)
	{
		List<WallEdge> value;
		if (WallEdges.TryGetValue(floor, out value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				WallEdge wallEdge = value[i];
				if ((wallEdge.Pos - p).sqrMagnitude < 0.001f)
				{
					return wallEdge;
				}
			}
		}
		else if (create)
		{
			value = (WallEdges[floor] = new List<WallEdge>());
		}
		if (create)
		{
			WallEdge wallEdge2 = new WallEdge(p, floor);
			value.Add(wallEdge2);
			return wallEdge2;
		}
		return null;
	}

	public void CleanEdge(WallEdge e, IRoom room)
	{
		e.Links.Remove(room);
		if (e.Links.Count == 0)
		{
			List<WallEdge> list = WallEdges[e.Floor];
			list.Remove(e);
			if (list.Count == 0)
			{
				WallEdges.Remove(e.Floor);
			}
		}
		else
		{
			e.Links.Keys.OfType<NetworkRoom>().ForEachEnum(delegate(NetworkRoom x)
			{
				x.MakeDirty();
			});
		}
	}
}
