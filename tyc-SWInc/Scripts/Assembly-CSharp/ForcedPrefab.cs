using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ForcedPrefab : MonoBehaviour
{
	[Serializable]
	public class ForcedRoom
	{
		public Vector2[] Edges;

		public int Floor;

		public bool Outside;

		public bool Pillar;

		public ForcedRoom()
		{
		}

		public ForcedRoom(BuildingPrefab p, BuildingPrefab.RoomObject r)
		{
			Edges = r.Edges.SelectInPlace((int x) => p.Edges[x].ToVector2());
			Floor = r.Floor;
			Outside = r.Outdoor;
			Pillar = r.Pillar;
		}
	}

	[Serializable]
	public class ForcedFurniture
	{
		public string Name;

		public string Type;

		public Vector3 Position;

		public int Floor;

		public float Rotation;

		public bool TypeOnly;

		public ForcedFurniture()
		{
		}

		public ForcedFurniture(BuildingPrefab.FurnitureObject f, BuildingPrefab.RoomObject r)
		{
			Name = f.Name;
			Type = ObjectDatabase.Instance.GetFurnitureComponent(f.Name).Type;
			Position = f.Position.ToVector3();
			Floor = r.Floor;
			Rotation = f.Rotation.ToQuaternion().eulerAngles.y;
			TypeOnly = f.TypeOnly;
		}

		public ForcedFurniture(string name, Vector3 position, int floor, float rotation, bool typeOnly)
		{
			Name = name;
			Type = ObjectDatabase.Instance.GetFurnitureComponent(Name).Type;
			Position = position;
			Floor = floor;
			Rotation = rotation;
			TypeOnly = typeOnly;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	[Serializable]
	public class ForcedSegment
	{
		public string Name;

		public Vector2 Position;

		public int Floor;

		public float Width;

		public float Rotation;

		public ForcedSegment()
		{
		}

		public ForcedSegment(BuildingPrefab p, BuildingPrefab.RoomObject r, BuildingPrefab.SegmentObject s)
		{
			Name = s.Name;
			Position = s.Position.ToVector3().FlattenVector3();
			Floor = r.Floor;
			Width = s.Width;
			for (int i = 0; i < r.Edges.Length; i++)
			{
				Vector2 vector = p.Edges[r.Edges[i]].ToVector2();
				Vector2 vector2 = p.Edges[r.Edges[(i + 1) % r.Edges.Length]].ToVector2();
				Vector2 res;
				if (Utilities.ProjectToLine(Position, vector, vector2, out res) && (res - Position).sqrMagnitude < 0.1f)
				{
					Rotation = Quaternion.LookRotation(vector2.ToVector3(0f) - vector.ToVector3(0f), Vector3.up).eulerAngles.y;
				}
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}

	[NonSerialized]
	public Dictionary<ForcedRoom, ForcedPrefabElement> Rooms = new Dictionary<ForcedRoom, ForcedPrefabElement>();

	[NonSerialized]
	public Dictionary<ForcedFurniture, ForcedPrefabElement> Furniture = new Dictionary<ForcedFurniture, ForcedPrefabElement>();

	[NonSerialized]
	public Dictionary<ForcedSegment, ForcedPrefabElement> Segments = new Dictionary<ForcedSegment, ForcedPrefabElement>();

	[NonSerialized]
	public Dictionary<ForcedFurniture, Furniture> CompletedWith = new Dictionary<ForcedFurniture, Furniture>();

	private ForcedPrefabElement _lastHighlight;

	public WriteDictionary Serialize()
	{
		WriteDictionary writeDictionary = new WriteDictionary("ForcedPrefab");
		writeDictionary["Rooms"] = Rooms.Keys.ToArray();
		writeDictionary["Furniture"] = Furniture.Keys.ToArray();
		writeDictionary["Segments"] = Segments.Keys.ToArray();
		writeDictionary["CompletedWith"] = CompletedWith.Where((KeyValuePair<ForcedFurniture, Furniture> x) => x.Value != null).ToDictionary((KeyValuePair<ForcedFurniture, Furniture> x) => x.Key, (KeyValuePair<ForcedFurniture, Furniture> x) => x.Value.DID);
		return writeDictionary;
	}

	public void Deserialize(WriteDictionary data)
	{
		Rooms = data.Get("Rooms", Array.Empty<ForcedRoom>()).ToDictionary((ForcedRoom x) => x, (ForcedRoom x) => (ForcedPrefabElement)null);
		Furniture = data.Get("Furniture", Array.Empty<ForcedFurniture>()).ToDictionary((ForcedFurniture x) => x, (ForcedFurniture x) => (ForcedPrefabElement)null);
		Segments = data.Get("Segments", Array.Empty<ForcedSegment>()).ToDictionary((ForcedSegment x) => x, (ForcedSegment x) => (ForcedPrefabElement)null);
		foreach (KeyValuePair<ForcedFurniture, uint> item in data.Get("CompletedWith", new Dictionary<ForcedFurniture, uint>()))
		{
			Furniture furniture = Writeable.STGetDeserializedObject(item.Value) as Furniture;
			if (furniture != null)
			{
				CompletedWith[item.Key] = furniture;
			}
			else
			{
				Furniture[item.Key] = null;
			}
		}
		InitObjects();
	}

	public void Init(BuildingPrefab prefab, bool ignoreRooms = false)
	{
		BuildingPrefab.RoomObject[] rooms = prefab.Rooms;
		foreach (BuildingPrefab.RoomObject roomObject in rooms)
		{
			if (ignoreRooms || !roomObject.Ignore)
			{
				ForcedRoom key = new ForcedRoom(prefab, roomObject);
				Rooms[key] = null;
			}
			BuildingPrefab.FurnitureObject[] furniture = roomObject.Furniture;
			for (int j = 0; j < furniture.Length; j++)
			{
				ForcedFurniture key2 = new ForcedFurniture(furniture[j], roomObject);
				Furniture[key2] = null;
			}
			BuildingPrefab.SegmentObject[] segments = roomObject.Segments;
			foreach (BuildingPrefab.SegmentObject s in segments)
			{
				ForcedSegment key3 = new ForcedSegment(prefab, roomObject, s);
				Segments[key3] = null;
			}
		}
		InitObjects();
	}

	private void InitObjects()
	{
		foreach (Room room in GameSettings.Instance.sRoomManager.Rooms)
		{
			CheckRoom(room.Edges.SelectInPlace((WallEdge x) => x.Pos), room.Floor, room.Outdoors, room.Pillar);
		}
		foreach (Furniture item in GameSettings.Instance.sRoomManager.AllFurniture)
		{
			CheckFurniture(item);
		}
		foreach (RoomSegment roomSegment in GameSettings.Instance.sRoomManager.RoomSegments)
		{
			CheckSegment(roomSegment.name, roomSegment.Floor, roomSegment.transform.position.FlattenVector3(), roomSegment.WallWidth, roomSegment.transform.rotation.eulerAngles.y - 90f);
		}
		if (Rooms.Count > 0)
		{
			foreach (ForcedRoom item2 in Rooms.Keys.ToList())
			{
				Rooms[item2] = CreateRoomElement(item2);
			}
		}
		if (Furniture.Count > 0)
		{
			foreach (ForcedFurniture item3 in Furniture.Keys.ToList())
			{
				Furniture[item3] = CreateFurnitureElement(item3);
			}
		}
		if (Segments.Count <= 0)
		{
			return;
		}
		foreach (ForcedSegment item4 in Segments.Keys.ToList())
		{
			Segments[item4] = CreateSegmentElement(item4);
		}
	}

	public void CheckCompletedValid()
	{
		bool flag = false;
		foreach (KeyValuePair<ForcedFurniture, Furniture> item in CompletedWith.ToList())
		{
			if (item.Value == null || !CheckAgainstFurniture(item.Key, item.Value))
			{
				CompletedWith.Remove(item.Key);
				Furniture[item.Key] = CreateFurnitureElement(item.Key);
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (Furniture item2 in GameSettings.Instance.sRoomManager.AllFurniture)
		{
			CheckFurniture(item2);
		}
	}

	public bool CheckFinished()
	{
		CheckCompletedValid();
		if (Rooms.Count == 0 && Furniture.Count == 0 && Segments.Count == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return true;
		}
		return false;
	}

	public bool CheckRoom(IList<Vector2> edges, int floor, bool outdoor, bool pillar)
	{
		ForcedRoom forcedRoom = Rooms.Keys.FirstOrDefault((ForcedRoom x) => x.Floor == floor && x.Outside == outdoor && x.Pillar == pillar && WallDragTool.SitsOn(x.Edges, edges) && WallDragTool.SitsOn(edges, x.Edges));
		if (forcedRoom != null)
		{
			ForcedPrefabElement forcedPrefabElement = Rooms[forcedRoom];
			if (forcedPrefabElement != null)
			{
				UnityEngine.Object.Destroy(forcedPrefabElement.gameObject);
			}
			Rooms.Remove(forcedRoom);
			CheckFinished();
			return true;
		}
		return false;
	}

	public bool CheckAgainstFurniture(ForcedFurniture x, Furniture furn)
	{
		return CheckAgainstFurniture(x, furn, furn.OriginalPosition, furn.Floor, furn.transform.rotation.eulerAngles.y);
	}

	public bool CheckAgainstFurniture(ForcedFurniture x, Furniture furn, Vector3 pos, int floor, float rot)
	{
		if ((x.TypeOnly ? x.Type.Equals(furn.Type) : x.Name.Equals(furn.name.Replace("(Clone)", ""))) && x.Floor.Equals(floor) && x.Position.Approximate(pos, 0.06f))
		{
			if (furn.PrefabRotationImportant)
			{
				return Mathf.Abs(Mathf.DeltaAngle(x.Rotation, rot)) <= 0.01f;
			}
			return true;
		}
		return false;
	}

	public bool CheckFurniture(Furniture furn)
	{
		ForcedFurniture forcedFurniture = Furniture.Keys.FirstOrDefault((ForcedFurniture x) => CheckAgainstFurniture(x, furn));
		if (forcedFurniture != null)
		{
			ForcedPrefabElement forcedPrefabElement = Furniture[forcedFurniture];
			if (forcedPrefabElement != null)
			{
				UnityEngine.Object.Destroy(forcedPrefabElement.gameObject);
			}
			CompletedWith[forcedFurniture] = furn;
			Furniture.Remove(forcedFurniture);
			CheckFinished();
			return true;
		}
		return false;
	}

	public bool CheckOnlyFurniture(Furniture furn, Vector3 pos, int floor, float rot)
	{
		return Furniture.Keys.Any((ForcedFurniture x) => CheckAgainstFurniture(x, furn, pos, floor, rot));
	}

	public bool CheckSegment(string name, int floor, Vector2 position, float width, float rotation)
	{
		ForcedSegment forcedSegment = Segments.Keys.FirstOrDefault(delegate(ForcedSegment x)
		{
			if (!x.Name.Equals(name) || !x.Floor.Equals(floor) || !x.Position.Approximate(position, 0.06f) || !x.Width.Appx(width, 0.01f))
			{
				return false;
			}
			float num = Mathf.Abs(Mathf.DeltaAngle(x.Rotation, rotation));
			return num <= 0.01f || Mathf.Abs(num - 180f) < 0.01f;
		});
		if (forcedSegment != null)
		{
			ForcedPrefabElement forcedPrefabElement = Segments[forcedSegment];
			if (forcedPrefabElement != null)
			{
				UnityEngine.Object.Destroy(forcedPrefabElement.gameObject);
			}
			Segments.Remove(forcedSegment);
			CheckFinished();
			return true;
		}
		return false;
	}

	public void AddFurniture(string name, int floor, Vector3 position, float rotation, bool typeOnly)
	{
		ForcedFurniture forcedFurniture = new ForcedFurniture(name, position, floor, rotation, typeOnly);
		Furniture[forcedFurniture] = CreateFurnitureElement(forcedFurniture);
	}

	public bool ValidFurniture(string name)
	{
		return Furniture.Keys.Any((ForcedFurniture x) => x.Name.Equals(name));
	}

	public bool ValidSegment(string name)
	{
		return Segments.Keys.Any((ForcedSegment x) => x.Name.Equals(name));
	}

	private ForcedPrefabElement CreateRoomElement(ForcedRoom room)
	{
		GameObject gameObject = new GameObject("Room");
		gameObject.layer = 14;
		gameObject.transform.SetParent(base.transform, true);
		ForcedPrefabElement forcedPrefabElement = gameObject.AddComponent<ForcedPrefabElement>();
		forcedPrefabElement.Room = true;
		forcedPrefabElement.Fence = room.Outside;
		for (int i = 0; i < room.Edges.Length; i++)
		{
			Vector2 vector = room.Edges[i];
			Vector2 vector2 = room.Edges[(i + 1) % room.Edges.Length];
			Vector2 v = (vector + vector2) / 2f;
			float magnitude = (vector2 - vector).magnitude;
			Vector3 pos = v.ToVector3((float)room.Floor * 2f + 1f);
			CreateBox(pos, Quaternion.LookRotation(vector2.ToVector3(0f) - vector.ToVector3(0f)), magnitude, 2f, Room.WallOffset).transform.SetParent(gameObject.transform);
		}
		return forcedPrefabElement;
	}

	private ForcedPrefabElement CreateFurnitureElement(ForcedFurniture furniture)
	{
		GameObject gameObject = new GameObject("Furniture");
		gameObject.layer = 14;
		gameObject.transform.SetParent(base.transform, true);
		ForcedPrefabElement forcedPrefabElement = gameObject.AddComponent<ForcedPrefabElement>();
		forcedPrefabElement.Furniture = (furniture.TypeOnly ? furniture.Type.LocTry() : Localization.GetFurniture(furniture.Name, furniture.Name, null)[0]);
		GameObject furniture2 = ObjectDatabase.Instance.GetFurniture(furniture.Name);
		CopyChildren(furniture2.transform, gameObject.transform, Vector3.one);
		forcedPrefabElement.transform.position = furniture.Position;
		forcedPrefabElement.transform.rotation = Quaternion.Euler(0f, furniture.Rotation, 0f);
		BoxCollider[] components = furniture2.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components)
		{
			BoxCollider boxCollider2 = gameObject.AddComponent<BoxCollider>();
			boxCollider2.center = boxCollider.center;
			boxCollider2.size = boxCollider.size;
		}
		return forcedPrefabElement;
	}

	private void CopyChildren(Transform from, Transform parent, Vector3 scale)
	{
		scale = Vector3.Scale(scale, from.localScale);
		MeshFilter component;
		if (from.gameObject.tag.Equals("Highlight") && from.TryGetComponent<MeshFilter>(out component) && component != null)
		{
			GameObject obj = new GameObject("Mesh");
			obj.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
			obj.AddComponent<MeshRenderer>().sharedMaterial = BuildController.Instance.ForcedPrefabMaterial;
			obj.transform.position = from.transform.position;
			obj.transform.rotation = from.transform.rotation;
			obj.transform.localScale = scale;
			obj.transform.SetParent(parent, true);
		}
		for (int i = 0; i < from.childCount; i++)
		{
			CopyChildren(from.GetChild(i), parent, scale);
		}
	}

	private GameObject CreateBox(Vector3 pos, Quaternion rot, float width, float height, float depth)
	{
		GameObject obj = new GameObject("Box");
		obj.AddComponent<MeshFilter>().sharedMesh = BuildController.Instance.ForcedPrefabBox;
		obj.AddComponent<MeshRenderer>().sharedMaterial = BuildController.Instance.ForcedPrefabMaterial;
		obj.transform.position = pos;
		obj.transform.rotation = rot;
		obj.transform.localScale = new Vector3(depth, height, width);
		return obj;
	}

	private ForcedPrefabElement CreateSegmentElement(ForcedSegment segment)
	{
		GameObject gameObject = new GameObject("Segment");
		gameObject.layer = 14;
		gameObject.transform.SetParent(base.transform, true);
		ForcedPrefabElement forcedPrefabElement = gameObject.AddComponent<ForcedPrefabElement>();
		forcedPrefabElement.Segment = Localization.GetFurniture(segment.Name, segment.Name, null)[0];
		RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(segment.Name);
		GameObject obj = CreateBox(Vector3.zero, Quaternion.identity, segment.Width, segmentComponent.Height2 - segmentComponent.Height1, Room.WallOffset + 0.1f);
		gameObject.transform.position = segment.Position.ToVector3((float)(segment.Floor * 2) + segmentComponent.Height1 + (segmentComponent.Height2 - segmentComponent.Height1) / 2f);
		gameObject.transform.rotation = Quaternion.Euler(0f, segment.Rotation, 0f);
		obj.transform.SetParent(gameObject.transform, true);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.center = Vector3.zero;
		boxCollider.size = new Vector3(Room.WallOffset + 0.1f, segmentComponent.Height2 - segmentComponent.Height1, segment.Width);
		return forcedPrefabElement;
	}

	private void Update()
	{
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (!GUICheck.OverGUI && !BuildController.Instance.IsActive() && Physics.Raycast(ray, out hitInfo, 1000f, 16384))
		{
			ForcedPrefabElement component;
			if (hitInfo.collider.TryGetComponent<ForcedPrefabElement>(out component))
			{
				if (component != _lastHighlight)
				{
					if (_lastHighlight != null)
					{
						_lastHighlight.Highlight(false);
					}
					_lastHighlight = component;
					_lastHighlight.Highlight(true);
				}
			}
			else if (_lastHighlight != null)
			{
				_lastHighlight.Highlight(false);
				_lastHighlight = null;
			}
		}
		else if (_lastHighlight != null)
		{
			_lastHighlight.Highlight(false);
			_lastHighlight = null;
		}
		if (!GUICheck.OverGUI && !BuildController.Instance.IsActive() && Input.GetMouseButton(0) && _lastHighlight != null)
		{
			_lastHighlight.Click();
		}
	}
}
