using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.Rendering;

public class RoomSegment : WallSnap, IRoomConnector
{
	public struct TransformInfo
	{
		public Vector3 Position;

		public Vector3 Scale;

		public Bounds Bounds;

		public TransformInfo(Transform t)
		{
			Position = t.localPosition;
			Scale = t.localScale;
			Vector3? vector = null;
			Vector3? vector2 = null;
			MeshFilter[] componentsInChildren = t.GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Bounds bounds = componentsInChildren[i].sharedMesh.bounds;
				Vector3 rhs = t.localToWorldMatrix.MultiplyPoint(bounds.min);
				Vector3 vector3 = t.localToWorldMatrix.MultiplyPoint(bounds.max);
				if (!vector.HasValue)
				{
					vector = Vector3.Min(vector3, rhs);
					vector2 = Vector3.Max(vector3, rhs);
				}
				else
				{
					vector = Vector3.Min(new Vector3?(Vector3.Min(vector.Value, rhs)).Value, vector3);
					vector2 = Vector3.Max(new Vector3?(Vector3.Max(vector2.Value, rhs)).Value, vector3);
				}
			}
			Vector3 vector4 = vector ?? Position;
			Vector3 vector5 = vector2 ?? Position;
			Bounds = new Bounds((vector4 + vector5) * 0.5f, vector5 - vector4);
		}
	}

	private static Dictionary<string, Dictionary<string, TransformInfo>> _movableTransforms = new Dictionary<string, Dictionary<string, TransformInfo>>();

	private static Dictionary<string, float> _lightAdditions = new Dictionary<string, float>();

	public bool Hidden;

	public bool MiniMap;

	public string Fallback;

	public float MiniYOffset = 1f;

	public float MiniHeight = 2f;

	public float MiniWidth = 1f;

	public float Height1;

	public float Height2 = 2f;

	public Color MiniColor = Color.white;

	public bool HideWithWalls;

	public bool IsTemporary;

	public bool OnlyInterior;

	public bool HasGlass;

	public bool IsTransparent = true;

	public bool Taggable;

	public float TagOffset = 0.101f;

	public float TagRot;

	public Vector2 TagPosition;

	public Transform TagParent;

	public Renderer[] GlassRend;

	public Material TransGlassMat;

	public Material OpaqueGlassMat;

	public float NoiseFactor = 1f;

	public float Cost = 5f;

	public Renderer[] Children;

	public int Floor;

	public bool DynamicWidth;

	public float MaxDynamicWidth = -1f;

	public bool InsideSegment = true;

	public bool MergeNeighbors;

	public List<GameObject> ScalableObjects;

	public List<GameObject> ScalableObjectsEdgeToEdge;

	public List<GameObject> MovableObjects;

	public bool Directional;

	private bool IsRendered = true;

	private bool IsShadowsOnly;

	[NonSerialized]
	public PathController.PathPoint ConnectedPath;

	public bool IsAgainstExterior = true;

	public GameObject WallMask;

	public bool HasMask;

	public DoorScript[] Hinges;

	[NonSerialized]
	public bool MergeFirst;

	[NonSerialized]
	public bool MergeSecond;

	[NonSerialized]
	public bool MergeRev;

	[NonSerialized]
	private bool _updateBlocked;

	[NonSerialized]
	public PlayerMap Map;

	[NonSerialized]
	private float _originalWallWidth = -1f;

	[NonSerialized]
	private float _originalCollWidth = -1f;

	[NonSerialized]
	public IRoom[] ParentRooms = new IRoom[2];

	[NonSerialized]
	private bool _initialized;

	[NonSerialized]
	public HashSet<Actor> GuardedBy = new HashSet<Actor>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public SDateTime LastGuarded;

	private Vector3 _pos;

	private Vector3 _forward;

	[NonSerialized]
	[SaveField]
	private string _tagText = "";

	private int _tagState;

	private TextMesh _currentTag;

	[NonSerialized]
	private MaterialPropertyBlock _glassMatBlock;

	public bool IsConnector;

	private PathNode<Vector3> _pathNode;

	private static string[] Actions = new string[3] { "Dismantle", "SelectWall", "SegmentsInRoom" };

	private string[] _actions;

	public string TagText
	{
		get
		{
			return _tagText;
		}
		set
		{
			_tagText = value;
			if (_tagState != 0)
			{
				SetText();
			}
		}
	}

	public bool IsBlocked { get; set; }

	public bool MovesBetweenFloors
	{
		get
		{
			return false;
		}
	}

	public bool IsConnecter
	{
		get
		{
			if (IsConnector)
			{
				return Map == null;
			}
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
			return _pathNode;
		}
		set
		{
			_pathNode = value;
		}
	}

	public bool IsRefreshing
	{
		get
		{
			Room room;
			if ((object)(room = ParentRooms[0] as Room) == null || !room.NavmeshRebuildStarted)
			{
				Room room2;
				if ((object)(room2 = ParentRooms[1] as Room) != null)
				{
					return room2.NavmeshRebuildStarted;
				}
				return false;
			}
			return true;
		}
	}

	public Transform ObjectTransform
	{
		get
		{
			return base.transform;
		}
	}

	public bool IsNull
	{
		get
		{
			if (!(this == null))
			{
				return base.gameObject == null;
			}
			return true;
		}
	}

	public override bool TowardsOutside()
	{
		return (ParentRooms[0] == null) ^ (ParentRooms[1] == null);
	}

	public bool TowardsOutdoors()
	{
		if (ParentRooms[0] != null && ParentRooms[1] != null && !ParentRooms[0].Outdoors)
		{
			return ParentRooms[1].Outdoors;
		}
		return true;
	}

	public override void Initialized()
	{
		_pos = base.transform.position;
		_forward = base.transform.forward.normalized;
	}

	public override bool IsMerge(WallEdge e)
	{
		if (FirstEdge == e)
		{
			if (!MergeRev)
			{
				return MergeFirst;
			}
			return MergeSecond;
		}
		if (!MergeRev)
		{
			return MergeSecond;
		}
		return MergeFirst;
	}

	public static void ClearStaticData()
	{
		_lightAdditions.Clear();
		_movableTransforms.Clear();
	}

	public Dictionary<string, TransformInfo> InitMovables(out float lightAdd)
	{
		Dictionary<string, TransformInfo> value;
		if (!_movableTransforms.TryGetValue(base.name, out value))
		{
			_lightAdditions[base.name] = LightAddition;
			Dictionary<string, TransformInfo> dictionary = (_movableTransforms[base.name] = new Dictionary<string, TransformInfo>());
			value = dictionary;
			foreach (GameObject movableObject in MovableObjects)
			{
				value[movableObject.name] = new TransformInfo(movableObject.transform);
			}
			foreach (GameObject scalableObject in ScalableObjects)
			{
				value[scalableObject.name] = new TransformInfo(scalableObject.transform);
			}
			foreach (GameObject item in ScalableObjectsEdgeToEdge)
			{
				value[item.name] = new TransformInfo(item.transform);
			}
		}
		lightAdd = _lightAdditions.GetOrDefault(base.name, LightAddition);
		return value;
	}

	public void FixDynamicWidth(float mult)
	{
		BoxCollider component = GetComponent<BoxCollider>();
		Init(component);
		base.name = base.name.Replace("(Clone)", "");
		MiniWidth = mult;
		float lightAdd;
		Dictionary<string, TransformInfo> dictionary = InitMovables(out lightAdd);
		LightAddition = lightAdd * mult;
		WallWidth = mult;
		component.size = new Vector3(_originalCollWidth - _originalWallWidth + WallWidth, component.size.y, component.size.z);
		float num = mult + 0.25f * (mult - 1f);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		Room room = null;
		bool flag = MergeFirst;
		bool flag2 = MergeSecond;
		WallEdge wallEdge = FirstEdge;
		WallEdge wallEdge2 = SecondEdge;
		if (MergeFirst || MergeSecond)
		{
			room = (MergeRev ? SecondEdge.GetRoom(FirstEdge) : FirstEdge.GetRoom(SecondEdge));
			if (MergeRev)
			{
				flag = MergeSecond;
				flag2 = MergeFirst;
				wallEdge = SecondEdge;
				wallEdge2 = FirstEdge;
			}
			if (room == null)
			{
				return;
			}
		}
		if (flag)
		{
			Vector2 pos = wallEdge.FindConnectionIn(room).Pos;
			Vector2 pos2 = wallEdge.Pos;
			Vector2 pos3 = wallEdge2.Pos;
			float number = 1f - Mathf.Abs(Vector2.Dot((pos - pos2).normalized, (pos3 - pos2).normalized));
			num2 = number.WeightOne(0.15f) * Room.WallOffset * 0.75f;
			num4 = number.WeightOne(0.9f) * Room.WallOffset * 0.5f;
		}
		if (flag2)
		{
			Vector2 pos4 = wallEdge.Pos;
			Vector2 pos5 = wallEdge2.Pos;
			Vector2 pos6 = wallEdge2.Links[room].Pos;
			float number2 = 1f - Mathf.Abs(Vector2.Dot((pos4 - pos5).normalized, (pos6 - pos5).normalized));
			num3 = number2.WeightOne(0.15f) * Room.WallOffset * 0.75f;
			num5 = number2.WeightOne(0.9f) * Room.WallOffset * 0.5f;
		}
		num += num2 + num3;
		float num6 = num3 * 0.5f - num2 * 0.5f;
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(num, 1f, 1f));
		foreach (GameObject scalableObject in ScalableObjects)
		{
			TransformInfo transformInfo = dictionary[scalableObject.name];
			float x = (WallWidth + transformInfo.Bounds.size.x - _originalWallWidth + num2 + num3) / transformInfo.Bounds.size.x;
			matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(x, 1f, 1f));
			scalableObject.transform.localScale = matrix4x.MultiplyPoint(transformInfo.Scale);
		}
		foreach (GameObject scalableObject2 in ScalableObjects)
		{
			Vector3 position = dictionary[scalableObject2.name].Position;
			scalableObject2.transform.localPosition = new Vector3(position.x + num6, position.y, position.z);
		}
		num = mult + num4 + num5;
		num6 = num5 * 0.5f - num4 * 0.5f;
		matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(num, 1f, 1f));
		foreach (GameObject item in ScalableObjectsEdgeToEdge)
		{
			TransformInfo transformInfo2 = dictionary[item.name];
			float x2 = (WallWidth + transformInfo2.Bounds.size.x - _originalWallWidth + num4 + num5) / transformInfo2.Bounds.size.x;
			matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(x2, 1f, 1f));
			item.transform.localScale = matrix4x.MultiplyPoint(transformInfo2.Scale);
		}
		foreach (GameObject item2 in ScalableObjectsEdgeToEdge)
		{
			Vector3 position2 = dictionary[item2.name].Position;
			item2.transform.localPosition = new Vector3(position2.x + num6, position2.y, position2.z);
		}
		foreach (GameObject movableObject in MovableObjects)
		{
			TransformInfo transformInfo3 = dictionary[movableObject.name];
			if (transformInfo3.Bounds.center.x < 0f)
			{
				if (flag)
				{
					movableObject.SetActive(false);
					continue;
				}
				movableObject.SetActive(true);
				Vector3 position3 = transformInfo3.Position;
				movableObject.transform.localPosition = new Vector3((0f - mult) / 2f + position3.x + 0.5f - (1f - _originalWallWidth) / 2f, position3.y, position3.z);
			}
			else if (flag2)
			{
				movableObject.SetActive(false);
			}
			else
			{
				movableObject.SetActive(true);
				Vector3 position4 = transformInfo3.Position;
				movableObject.transform.localPosition = new Vector3(mult / 2f + position4.x - 0.5f + (1f - _originalWallWidth) / 2f, position4.y, position4.z);
			}
		}
	}

	private bool ValidForMerge(WallEdge b)
	{
		if (b.Links.Count((KeyValuePair<IRoom, WallEdge> x) => !x.Key.Outdoors || x.Key.FenceHeight > 0.1f) != 1)
		{
			if (b.Links.Count == 2)
			{
				return b.Links.All((KeyValuePair<IRoom, WallEdge> x) => x.Value.Links.ContainsValue(b));
			}
			return false;
		}
		return true;
	}

	public void UpdateMerge()
	{
		if (!MergeNeighbors)
		{
			return;
		}
		bool mergeFirst = MergeFirst;
		bool mergeSecond = MergeSecond;
		MergeFirst = false;
		MergeSecond = false;
		Room room = FirstEdge.GetRoom(SecondEdge);
		WallEdge wallEdge = FirstEdge;
		WallEdge wallEdge2 = SecondEdge;
		if (room == null)
		{
			room = SecondEdge.GetRoom(FirstEdge);
			wallEdge = SecondEdge;
			wallEdge2 = FirstEdge;
			MergeRev = true;
		}
		if (room != null)
		{
			if ((WallPosition[wallEdge] - WallWidth / 2f).Appx(0f))
			{
				WallEdge wallEdge3 = wallEdge.FindConnectionIn(room);
				HashSet<WallSnap> value;
				if (ValidForMerge(wallEdge) && Vector2.Dot((wallEdge3.Pos - wallEdge.Pos).normalized, (wallEdge2.Pos - wallEdge.Pos).normalized) <= 0.001f && wallEdge.Children.TryGetValue(wallEdge3, out value))
				{
					foreach (RoomSegment item in value.OfType<RoomSegment>())
					{
						if (item.name.Equals(base.name) && (item.WallPosition[wallEdge] - item.WallWidth / 2f).Appx(0f))
						{
							MergeFirst = true;
							break;
						}
					}
				}
			}
			if ((WallPosition[wallEdge2] - WallWidth / 2f).Appx(0f))
			{
				WallEdge wallEdge4 = wallEdge2.Links[room];
				HashSet<WallSnap> value2;
				if (ValidForMerge(wallEdge2) && Vector2.Dot((wallEdge4.Pos - wallEdge2.Pos).normalized, (wallEdge.Pos - wallEdge2.Pos).normalized) <= 0.001f && wallEdge4.Children.TryGetValue(wallEdge2, out value2))
				{
					foreach (RoomSegment item2 in value2.OfType<RoomSegment>())
					{
						if (item2.name.Equals(base.name) && (item2.WallPosition[wallEdge2] - item2.WallWidth / 2f).Appx(0f))
						{
							MergeSecond = true;
							break;
						}
					}
				}
			}
		}
		if (MergeFirst != mergeFirst || MergeSecond != mergeSecond)
		{
			FixDynamicWidth(WallWidth);
		}
	}

	public bool IsConnectedToOutside(bool includeRoad = false)
	{
		if ((Floor == 0 || (includeRoad && IsConnectedToRoad())) && IsConnector)
		{
			if (ParentRooms[0] != null)
			{
				return ParentRooms[1] == null;
			}
			return true;
		}
		return false;
	}

	public bool IsConnectedToOutside(HashSet<Room> inside)
	{
		if (IsConnector)
		{
			if (ParentRooms[0] != null && inside.Contains(ParentRooms[0]) && ParentRooms[1] != null)
			{
				return !inside.Contains(ParentRooms[1]);
			}
			return true;
		}
		return false;
	}

	public bool IsConnectedToRoad()
	{
		IRoom room = ((ParentRooms[0] == null) ? ParentRooms[1] : ParentRooms[0]);
		if (room != null)
		{
			return GetRoad(room) != null;
		}
		return false;
	}

	private void Init(BoxCollider b)
	{
		if (_originalWallWidth < 0f)
		{
			_originalWallWidth = WallWidth;
			_originalCollWidth = b.size.x;
		}
	}

	private void Awake()
	{
		Init(GetComponent<BoxCollider>());
	}

	public void UpdateParents()
	{
		if (IsConnecter)
		{
			InitPathNode();
			List<PathNode<Vector3>> connections = this.pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<Vector3> pathNode = connections[i];
				if (pathNode.Tag == ParentRooms[0] || pathNode.Tag == ParentRooms[1])
				{
					pathNode.RemoveConnection(this.pathNode);
					this.pathNode.RemoveConnection(pathNode);
					i--;
				}
			}
		}
		List<WallEdge> es = WallPosition.Keys.ToList();
		if (es.Count < 2)
		{
			ParentRooms[0] = null;
			ParentRooms[1] = null;
			return;
		}
		bool flag = IsConnectedToOutside();
		ParentRooms[0] = (from x in es[0].Links
			where x.Value == es[1]
			select x.Key).FirstOrDefault();
		ParentRooms[1] = (from x in es[1].Links
			where x.Value == es[0]
			select x.Key).FirstOrDefault();
		if (Map != null)
		{
			return;
		}
		if (flag && ParentRooms[0] != null && ParentRooms[1] != null)
		{
			GameSettings.Instance.sRoomManager.PathController.CheckSegmentDelete(this);
		}
		else if (ConnectedPath == null && IsConnectedToOutside())
		{
			Vector2 p = GetOffsetPos(GameSettings.Instance.sRoomManager.Outside).FlattenVector3();
			PathController.PathPoint[] path = GameSettings.Instance.sRoomManager.PathController.GetPath(ref p, PathController.PathSegSnapDist);
			if (path != null)
			{
				if (path.Length == 1)
				{
					if (IsOnOutside(path[0].Point))
					{
						path[0].ConnectSegment(this);
						if (path[0].Connections.Count > 1 || path[0].ConnectedSegmentCount == 1)
						{
							GameSettings.Instance.sRoomManager.PathController.RefreshPathFrom(path[0], false);
						}
						if (GameSettings.Instance.sRoomManager.PathController.EndPoints.Remove(path[0]))
						{
							GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
						}
					}
				}
				else if (IsOnOutside(p))
				{
					PathController.PathPoint pathPoint = GameSettings.Instance.sRoomManager.PathController.SplitPath(path[0], path[1], p);
					pathPoint.ConnectSegment(this);
					PathObject parentObject = path[0].ParentObject;
					if (parentObject != null)
					{
						pathPoint.ParentObject = parentObject;
						parentObject.Path.Add(pathPoint);
					}
					GameSettings.Instance.sRoomManager.PathController.RefreshPathFrom(pathPoint, false);
				}
			}
		}
		Room room;
		Room room2;
		if ((object)(room = ParentRooms[0] as Room) != null)
		{
			room.RefreshNoise();
		}
		else if ((object)(room2 = ParentRooms[1] as Room) != null)
		{
			room2.RefreshNoise();
		}
	}

	public override string[] GetActions()
	{
		return _actions;
	}

	public override string[] GetExtendedInfo()
	{
		return new string[1] { Localization.GetFurniture(base.name, string.IsNullOrEmpty(LocalizedName) ? base.name : LocalizedName, ButtonDescription)[0] };
	}

	public override string[] GetExtendedIconInfo()
	{
		return new string[1] { "Door" };
	}

	public override string GetInfo()
	{
		return "";
	}

	public override void ToggleDoors(bool open, bool keepOpen, bool force = false)
	{
	}

	private void Start()
	{
		base.name = base.name.Replace("(Clone)", "").Trim();
		if (Map != null)
		{
			if (IsCustomizable())
			{
				InitializeMatBlock();
			}
			base.transform.position = new Vector3(base.transform.position.x, Floor * 2, base.transform.position.z);
			if (!DisableInitColor && !Deserialized && !GameSettings.Instance.IsReferenceNull())
			{
				InitColors();
				InitAtlas();
				if (Colorable.Count > 0)
				{
					UpdateMaterials();
				}
			}
		}
		else if (!IsTemporary)
		{
			if (IsCustomizable())
			{
				InitializeMatBlock();
			}
			InitWritable();
			List<string> list = new List<string>(Actions);
			if (Taggable)
			{
				list.Add("EditTag");
			}
			if (base.ColorEditEnabled)
			{
				list.Add("Furniture color");
			}
			if (AtlasObject != null)
			{
				list.Add("FurnitureStyle");
			}
			_actions = list.ToArray();
			base.transform.position = new Vector3(base.transform.position.x, Floor * 2, base.transform.position.z);
			InitPathNode();
			if (!DisableInitColor && !Deserialized && !GameSettings.Instance.IsReferenceNull())
			{
				InitColors();
				InitAtlas();
				if (Colorable.Count > 0)
				{
					UpdateMaterials();
				}
			}
			GameSettings.Instance.sRoomManager.RoomSegments.Add(this);
			if (TowardsOutdoors())
			{
				SendNetwork();
			}
		}
		else
		{
			if (IsCustomizable())
			{
				InitializeMatBlock();
			}
			if (!DisableInitColor)
			{
				InitColors();
				InitAtlas();
				if (Colorable.Count > 0)
				{
					UpdateMaterials();
				}
			}
		}
		_initialized = true;
	}

	public void SendNetwork()
	{
		if (NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 1 && FirstEdge != null && SecondEdge != null)
		{
			Room room = GetPrimaryRoom() ?? GetSecondaryRoom();
			if (room != null && room.NetworkID != 0)
			{
				NetworkMessaging.SendNewRoomSegment(new BuildingPrefab.SegmentObject(this, 0, true, room), room.NetworkID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
	}

	private void InitPathNode()
	{
		if (IsConnector && pathNode == null)
		{
			pathNode = new PathNode<Vector3>(new Vector3(base.transform.position.x, (float)(Floor * 2) + 0.5f, base.transform.position.z), this);
		}
	}

	private void SetText()
	{
		_currentTag.text = _tagText;
		float num = _currentTag.font.GetLineWidth(_tagText, _currentTag.fontSize, _currentTag.fontStyle);
		num = Mathf.Min(0.1f, RoomSegmentTagger.Instance.MaxTextWidth / num);
		_currentTag.transform.localScale = Vector3.one * num;
	}

	private void SetTagPosition()
	{
		Quaternion localRotation = ((_tagState < 0) ? Quaternion.Euler(0f, 180f + TagRot, 0f) : Quaternion.Euler(0f, TagRot, 0f));
		_currentTag.transform.localRotation = localRotation;
		localRotation = Quaternion.Euler(0f, TagRot, 0f);
		_currentTag.transform.localPosition = localRotation * new Vector3(TagPosition.x, TagPosition.y, (_tagState < 0) ? TagOffset : (0f - TagOffset));
	}

	public void SetTagPosition(Transform t, int state)
	{
		t.transform.SetParent(TagParent);
		Quaternion localRotation = ((state < 0) ? Quaternion.Euler(0f, 180f + TagRot, 0f) : Quaternion.Euler(0f, TagRot, 0f));
		t.localRotation = localRotation;
		localRotation = Quaternion.Euler(0f, TagRot, 0f);
		t.localPosition = localRotation * new Vector3(TagPosition.x, TagPosition.y, (state < 0) ? TagOffset : (0f - TagOffset));
	}

	public bool IsInterior()
	{
		Room parentRoom = GetParentRoom(true);
		if (parentRoom == null || parentRoom.Outside || parentRoom.Outdoors)
		{
			return false;
		}
		parentRoom = GetParentRoom(false);
		if (parentRoom == null || parentRoom.Outside || parentRoom.Outdoors)
		{
			return false;
		}
		return true;
	}

	private bool IsAtriumVisible()
	{
		Room parentRoom = GetParentRoom(true);
		if (parentRoom != null && parentRoom.IsContentVisible())
		{
			return true;
		}
		parentRoom = GetParentRoom(false);
		if (parentRoom != null && parentRoom.IsContentVisible())
		{
			return true;
		}
		return false;
	}

	private void FixedUpdate()
	{
		if (IsTemporary || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Taggable)
		{
			if (string.IsNullOrEmpty(TagText))
			{
				if (_tagState != 0)
				{
					_tagState = 0;
					RoomSegmentTagger.Release(_currentTag);
				}
			}
			else
			{
				Vector3 position = base.transform.position;
				int num = (CameraScript.Instance.FlyMode ? Mathf.FloorToInt(CameraScript.Instance.LastCamPos.y / 2f) : GameSettings.Instance.ActiveFloor);
				bool flag = IsRendered && !IsShadowsOnly && Children[0].isVisible && (num == Floor || !IsInterior()) && Mathf.Abs(position.y - CameraScript.Instance.LastCamPos.y) < RoomSegmentTagger.Instance.MaxRenderHeight;
				if (flag != (_tagState != 0))
				{
					if (flag)
					{
						_tagState = ((!(Vector2.Dot(CameraScript.Instance.FlatForward, (Quaternion.Euler(0f, TagRot, 0f) * TagParent.forward).FlattenVector3()) < 0f)) ? 1 : (-1));
						_currentTag = RoomSegmentTagger.Get();
						_currentTag.transform.SetParent(TagParent);
						SetText();
						SetTagPosition();
					}
					else
					{
						_tagState = 0;
						RoomSegmentTagger.Release(_currentTag);
					}
				}
				else if (flag)
				{
					int num2 = ((!(Vector2.Dot(CameraScript.Instance.FlatForward, (Quaternion.Euler(0f, TagRot, 0f) * TagParent.forward).FlattenVector3()) < 0f)) ? 1 : (-1));
					if (num2 != _tagState)
					{
						_tagState = num2;
						SetTagPosition();
					}
				}
			}
		}
		if (_updateBlocked)
		{
			ActualUpdateBlocked();
		}
		if (HasMask)
		{
			bool flag2 = Floor == GameSettings.Instance.ActiveFloor && (Map != null || GameSettings.WallsDown == GameSettings.WallState.Low || GameSettings.WallsDown == GameSettings.WallState.LowNoSeg);
			if (flag2 != WallMask.activeSelf)
			{
				WallMask.SetActive(flag2);
			}
		}
		bool flag3 = (CameraScript.Instance.FlyMode ? (CameraScript.Instance.mainCam.transform.position.y < 0f) : Utilities.InBasement(GameSettings.Instance.ActiveFloor)) == Utilities.InBasement(Floor);
		bool flag4 = (!CheckWallDown() && Floor == GameSettings.Instance.ActiveFloor) || (flag3 && Floor > GameSettings.Instance.ActiveFloor);
		bool flag5 = flag3 && (IsAgainstExterior || CameraScript.Instance.FlyMode || Floor == GameSettings.Instance.ActiveFloor || (!Options.OpaqueGlass && Floor < GameSettings.Instance.ActiveFloor) || IsAtriumVisible());
		if (!flag5 && Floor < 0 && GameSettings.Instance.ActiveFloor == 0 && ParentRooms.Any((IRoom x) =>
		{
			Room room2;
			return (object)(room2 = x as Room) != null && room2.HasTwoFloor;
		}))
		{
			flag5 = true;
			flag4 = false;
		}
		if (IsShadowsOnly != flag4 || IsRendered != flag5)
		{
			IsRendered = flag5;
			IsShadowsOnly = flag4;
			for (int num3 = 0; num3 < Children.Length; num3++)
			{
				Renderer renderer = Children[num3];
				renderer.enabled = flag5;
				if (flag5)
				{
					renderer.shadowCastingMode = ((!flag4) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
				}
			}
		}
		if ((Options.OpaqueGlass || Map != null) && HasGlass && IsRendered && !IsShadowsOnly)
		{
			bool flag6 = Map == null && Floor == GameSettings.Instance.ActiveFloor;
			if (flag6 != IsTransparent)
			{
				IsTransparent = flag6;
				for (int num4 = 0; num4 < GlassRend.Length; num4++)
				{
					GlassRend[num4].sharedMaterial = (IsTransparent ? TransGlassMat : OpaqueGlassMat);
				}
			}
			if (!IsTransparent && Map == null)
			{
				if (_glassMatBlock == null)
				{
					_glassMatBlock = new MaterialPropertyBlock();
				}
				Room room = (ParentRooms[0] as Room) ?? (ParentRooms[1] as Room);
				_glassMatBlock.SetFloat("_EmissionFact", (room != null) ? Mathf.Min(1f, room._lastLampDarkLevel / (room.GetAtriumArea() / 16f)) : 0f);
				for (int num5 = 0; num5 < GlassRend.Length; num5++)
				{
					GlassRend[num5].SetPropertyBlock(_glassMatBlock);
				}
			}
		}
		else if (!IsTransparent)
		{
			IsTransparent = true;
			for (int num6 = 0; num6 < GlassRend.Length; num6++)
			{
				GlassRend[num6].sharedMaterial = TransGlassMat;
			}
		}
	}

	private bool CheckWallDown()
	{
		if (Map != null)
		{
			return true;
		}
		if (GameSettings.WallsDown == GameSettings.WallState.LowNoSeg)
		{
			return false;
		}
		if (GameSettings.WallsDown == GameSettings.WallState.Low)
		{
			return !HideWithWalls;
		}
		if (GameSettings.WallsDown == GameSettings.WallState.Back)
		{
			if (!HideWithWalls)
			{
				return true;
			}
			if (SecondEdge == null)
			{
				return true;
			}
			if (SecondEdge.Links.ContainsValue(FirstEdge))
			{
				return true;
			}
			Vector2 pos = FirstEdge.Pos;
			Vector2 pos2 = SecondEdge.Pos;
			return Mathf.Abs(Quaternion.Angle(Quaternion.LookRotation((pos - pos2).ToVector3(0f)) * Quaternion.Euler(0f, 90f, 0f), CameraScript.Instance.mainCam.transform.rotation)) > 90f;
		}
		return true;
	}

	public override bool ValidSnap(bool clone, HashSet<Room> destroy = null, bool keep = false)
	{
		if (Map != null)
		{
			return true;
		}
		if (SecondEdge == null)
		{
			return false;
		}
		Room primaryRoom = GetPrimaryRoom();
		Room secondaryRoom = GetSecondaryRoom();
		bool shared;
		bool flag = FirstEdge.IsBalconyWall(SecondEdge, out shared);
		if (IsConnecter)
		{
			if (flag && !shared)
			{
				return false;
			}
			if ((primaryRoom != null && primaryRoom.IsUpperAtriumNotBalcony) || (secondaryRoom != null && secondaryRoom.IsUpperAtriumNotBalcony))
			{
				return false;
			}
		}
		if ((primaryRoom != null && !primaryRoom.Destroyed && primaryRoom.Pillar) || (secondaryRoom != null && !secondaryRoom.Destroyed && secondaryRoom.Pillar))
		{
			return false;
		}
		bool flag2 = primaryRoom != null && (destroy == null || keep == destroy.Contains(primaryRoom));
		bool flag3 = secondaryRoom != null && (destroy == null || keep == destroy.Contains(secondaryRoom));
		int num = 0;
		if (flag)
		{
			if (shared)
			{
				num = 2;
			}
		}
		else
		{
			if (flag2)
			{
				num += (primaryRoom.Outdoors ? 1 : (-1));
			}
			if (flag3)
			{
				num += (secondaryRoom.Outdoors ? 1 : (-1));
			}
		}
		if (!clone && num > 0 == InsideSegment)
		{
			return false;
		}
		if (!flag2 && !flag3)
		{
			return false;
		}
		flag2 = flag2 && !primaryRoom.Outdoors;
		flag3 = flag3 && !secondaryRoom.Outdoors;
		if (!clone && OnlyInterior && (!flag2 || !flag3))
		{
			return false;
		}
		return true;
	}

	public override Room GetParentRoom(bool first)
	{
		return ParentRooms[(!first) ? 1u : 0u] as Room;
	}

	public override bool EdgeChanged(WallEdge[] previous, bool clone)
	{
		if (FirstEdge != null)
		{
			Floor = FirstEdge.Floor;
		}
		bool flag = TowardsOutside();
		UpdateParents();
		if (Map != null)
		{
			return true;
		}
		if (Floor > 1 && Floor / 2 < RoadManager.Floors && Floor % 2 == 0)
		{
			GameSettings.Instance.sRoomManager.RoomRoadDirty = 2;
		}
		if (!ValidSnap(clone))
		{
			DestroyGO();
			return false;
		}
		List<Room> list = new List<Room>();
		if (previous != null && previous.Length > 1 && previous[0] != null && previous[1] != null)
		{
			Room room = previous[0].GetRoom(previous[1]);
			Room room2 = previous[1].GetRoom(previous[0]);
			if (room != null)
			{
				room.UpdateIsPrivate();
				list.Add(room);
			}
			if (room2 != null)
			{
				room2.UpdateIsPrivate();
				list.Add(room2);
			}
		}
		foreach (Room item in list)
		{
			if (IsConnector)
			{
				item.DirtyPathNodes = true;
			}
			item.RecalculateStateVariables(LightAddition > 0f);
		}
		if (list.Count == 1 && IsConnector && Floor == 0)
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
		}
		for (int i = 0; i < ParentRooms.Length; i++)
		{
			Room room3;
			if ((object)(room3 = ParentRooms[i] as Room) != null)
			{
				if (IsConnector)
				{
					room3.DirtyPathNodes = true;
				}
				room3.RecalculateStateVariables(LightAddition > 0f);
				room3.UpdateIsPrivate();
			}
		}
		if (IsConnector && Floor == 0)
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
		}
		IsAgainstExterior = GetAgainstExterior();
		if (_initialized)
		{
			if (TowardsOutdoors())
			{
				if (!flag || _pos != base.transform.position)
				{
					GameSettings.Instance.QueuedNetworkSegments[this] = true;
				}
			}
			else if (base.NetworkID != 0)
			{
				GameSettings.Instance.QueuedNetworkSegments[this] = false;
			}
		}
		return true;
	}

	public void UpdateBlocked()
	{
		_updateBlocked = true;
	}

	private void ActualUpdateBlocked()
	{
		if (HUD.Instance == null)
		{
			return;
		}
		HUD.Instance.BlockedDoorways.Remove(this);
		IsBlocked = false;
		for (int i = 0; i < ParentRooms.Length; i++)
		{
			bool flag = true;
			Room room;
			if ((object)(room = ParentRooms[i] as Room) != null)
			{
				if (room.GetNavMeshRunning())
				{
					return;
				}
				if (room.GetNodeAt(GetOffsetPos(room).FlattenVector3()) == null)
				{
					flag = false;
				}
			}
			else
			{
				Room outside = GameSettings.Instance.sRoomManager.Outside;
				Vector2 p = GetOffsetPos(outside).FlattenVector3();
				if (Floor == 0)
				{
					if (outside.GetNavMeshRunning())
					{
						return;
					}
					if (outside.GetNodeAt(GetOffsetPos(outside).FlattenVector3()) == null)
					{
						flag = false;
					}
				}
				else if (Floor > 0)
				{
					if (Floor % 2 == 0)
					{
						if (RoadManager.Instance.GetRoad(p, Floor / 2) == 0)
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (!flag)
			{
				pathNode.Weight = float.PositiveInfinity;
				HUD.Instance.BlockedDoorways.Add(this);
				IsBlocked = true;
				_updateBlocked = false;
				return;
			}
		}
		_updateBlocked = false;
		pathNode.Weight = 1f;
	}

	public Transform[] IntermediatePoints(Room from)
	{
		return null;
	}

	public bool IsRoadLevel()
	{
		if (Floor > 1 && Floor / 2 < RoadManager.Floors)
		{
			return Floor % 2 == 0;
		}
		return false;
	}

	public RoadSegment GetRoad(IRoom from)
	{
		Room room;
		if (IsRoadLevel() && (ParentRooms[0] == null || ParentRooms[1] == null) && (object)(room = from as Room) != null)
		{
			Vector3 offsetPos = GetOffsetPos(room, true);
			RoadSegment segment = RoadManager.Instance.GetSegment(offsetPos, Floor / 2, false);
			if (segment != null && !segment.WestRaised && !segment.EastRaised && !segment.NorthRaised && !segment.SouthRaised)
			{
				return segment;
			}
		}
		return null;
	}

	public void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull() || ErrorLogging.SceneChanging || BuildController.Instance == null || Map != null)
		{
			return;
		}
		if (Taggable && _tagState != 0)
		{
			RoomSegmentTagger.Release(_currentTag);
		}
		if (IsConnectedToOutside())
		{
			GameSettings.Instance.sRoomManager.PathController.CheckSegmentDelete(this);
		}
		IRoom[] parentRooms = ParentRooms;
		ClearConnections();
		if (HUD.Instance != null)
		{
			HUD.Instance.BlockedDoorways.Remove(this);
		}
		if (SelectorController.Instance != null && SelectorController.Instance.Selected.Contains(this))
		{
			SelectorController.Instance.ToggleRightClickMenu(false);
			SelectorController.Instance.Selected.Remove(this);
		}
		GameSettings.Instance.sRoomManager.RoomSegments.Remove(this);
		IRoom[] array = parentRooms;
		foreach (IRoom room in array)
		{
			Room room2;
			if (room == null)
			{
				if (!IsConnector)
				{
					continue;
				}
				if (Floor == 0)
				{
					GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
				}
				else
				{
					if (!IsRoadLevel())
					{
						continue;
					}
					List<PathNode<Vector3>> connections = this.pathNode.GetConnections();
					for (int j = 0; j < connections.Count; j++)
					{
						PathNode<Vector3> pathNode = connections[j];
						RoadSegment roadSegment = pathNode.Tag as RoadSegment;
						if (roadSegment != null)
						{
							RoadManager.Instance.SetSidewalkDirty(roadSegment.x, roadSegment.y, roadSegment.floor);
							pathNode.RemoveConnection(this.pathNode);
						}
					}
				}
			}
			else if ((object)(room2 = room as Room) != null && room2.IsAliveNotNull())
			{
				if (LightAddition > 0f)
				{
					room2.UpdateFurnitureWallNearness();
				}
				if (IsConnector)
				{
					room2.DirtyPathNodes = true;
				}
				room2.DirtyOuterMesh = true;
				room2.DirtyInnerMesh = true;
				room2.RecalculateStateVariables(LightAddition > 0f);
				room2.RefreshNoise();
				room2.UpdateIsPrivate();
			}
		}
	}

	public Vector3 GetOffsetPos(Room room, bool inverse = false)
	{
		if (this == null || room == null)
		{
			return Vector3.zero;
		}
		WallEdge wallEdge = FirstEdge;
		if (wallEdge == null || WallPosition == null)
		{
			Vector3 vector = _forward * Room.WallOffset;
			return _pos + (inverse ? vector : (-vector));
		}
		WallEdge wallEdge2 = SecondEdge;
		if (wallEdge2 == null)
		{
			Vector3 vector2 = _forward * Room.WallOffset;
			return _pos + (inverse ? vector2 : (-vector2));
		}
		WallEdge value;
		if (room.Outside)
		{
			if (wallEdge.Links.ContainsValue(wallEdge2))
			{
				WallEdge wallEdge3 = wallEdge2;
				wallEdge2 = wallEdge;
				wallEdge = wallEdge3;
			}
		}
		else if (!wallEdge.Links.TryGetValue(room, out value) || value != wallEdge2)
		{
			value = wallEdge2;
			wallEdge2 = wallEdge;
			wallEdge = value;
		}
		Vector2 vector3 = wallEdge2.Pos - wallEdge.Pos;
		Vector3 vector4 = new Vector3(vector3.y, 0f, 0f - vector3.x).normalized * Room.WallOffset;
		return _pos + (inverse ? vector4 : (-vector4));
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		if (DynamicWidth)
		{
			FixDynamicWidth(dictionary.Get("DynamicWallWidth", WallWidth));
		}
		if (!DeserializeSnap(dictionary))
		{
			return null;
		}
		if (FirstEdge != null)
		{
			Floor = FirstEdge.Floor;
		}
		base.ColorPrimary = (ForceColorPrimary ? ColorPrimaryDefault : dictionary.Get("ColP", (SVector3)ColorPrimaryDefault).ToColor());
		base.ColorSecondary = (ForceColorSecondary ? ColorSecondaryDefault : dictionary.Get("ColS", (SVector3)ColorSecondaryDefault).ToColor());
		base.ColorTertiary = (ForceColorTertiary ? ColorTertiaryDefault : dictionary.Get("ColT", (SVector3)ColorTertiaryDefault).ToColor());
		base.AtlasIndex = dictionary.Get("AtlasIndex", 0);
		UpdateParents();
		DeserializeReplacement(dictionary);
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["Type"] = base.name;
		dictionary["DynamicWallWidth"] = WallWidth;
		if (ColorPrimaryEnabled)
		{
			dictionary["ColP"] = (SVector3)base.ActualColorPrimary;
		}
		if (ColorSecondaryEnabled)
		{
			dictionary["ColS"] = (SVector3)base.ActualColorSecondary;
		}
		if (ColorTertiaryEnabled)
		{
			dictionary["ColT"] = (SVector3)base.ActualColorTertiary;
		}
		dictionary["AtlasIndex"] = base.AtlasIndex;
		if (!string.IsNullOrEmpty(Fallback))
		{
			dictionary["Fallback"] = Fallback;
		}
		SerializeSnap(dictionary);
		SerializeReplacement(dictionary);
	}

	public override string WriteName()
	{
		return "RoomSegment";
	}

	public void OnDrawGizmosSelected()
	{
		if (!IsConnector || pathNode == null)
		{
			return;
		}
		foreach (PathNode<Vector3> connection in pathNode.GetConnections())
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(pathNode.Point, connection.Point);
		}
		Gizmos.color = Color.yellow;
		Room room = ((!GameSettings.Instance.IsReferenceNull()) ? GameSettings.Instance.sRoomManager.Outside : null);
		Gizmos.DrawSphere(GetOffsetPos((ParentRooms[0] as Room) ?? room) + Vector3.up * 0.5f, 0.1f);
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(GetOffsetPos((ParentRooms[1] as Room) ?? room) + Vector3.up * 0.5f, 0.1f);
	}

	public bool AllowExit()
	{
		return true;
	}

	public bool AllowEntry()
	{
		return true;
	}

	public override int GetFloor()
	{
		return Floor;
	}

	public override bool IsSelectableInView()
	{
		if (Utilities.InBasement(GameSettings.Instance.ActiveFloor) == Utilities.InBasement(Floor))
		{
			if (Floor != GameSettings.Instance.ActiveFloor || !CheckWallDown())
			{
				if (Floor < GameSettings.Instance.ActiveFloor)
				{
					return IsAgainstExterior;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override bool IsSelectionRestricted()
	{
		if (Map == null)
		{
			if (!GameSettings.Instance.EditMode)
			{
				return GameSettings.Instance.RentMode;
			}
			return false;
		}
		return true;
	}

	public bool IsOnOutside(Vector2 p)
	{
		Room outside = GameSettings.Instance.sRoomManager.Outside;
		Vector2 vector = GetOffsetPos(outside).FlattenVector3();
		Vector2 vector2 = GetOffsetPos(outside, true).FlattenVector3();
		Vector2 vector3 = base.transform.position.FlattenVector3();
		return Utilities.IsLeft(vector3, vector3 + (vector - vector2).Turn90(), p) < 0;
	}

	public float GetDoorAngle(Room outside)
	{
		return (GetOffsetPos(outside) - base.transform.position).GetFlatAngle();
	}

	public override Renderer[] GetHighlightRenders()
	{
		return Children;
	}

	public override bool SelectableThroughWall()
	{
		return true;
	}

	public override bool IsActuallyPlayerControlled()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			return !GameSettings.Instance.RentMode;
		}
		return true;
	}

	public override bool IsNetworkIDLocal()
	{
		return true;
	}

	public override bool IsNetworkIDLocal(WriteDictionary d)
	{
		return true;
	}

	public override void UpdateStyleNetwork()
	{
		if (base.NetworkID != 0 && IsCustomizable())
		{
			NetworkMessaging.SendObjectStyle(base.NetworkID, true, null, null, ColorPrimaryEnabled ? base.ColorPrimary : Color.black, ColorSecondaryEnabled ? base.ColorSecondary : Color.black, ColorTertiaryEnabled ? base.ColorTertiary : Color.black, Color.black, base.AtlasIndex, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}
}
