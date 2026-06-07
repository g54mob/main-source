using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.Rendering;

public class Roof : Selectable
{
	[Serializable]
	public class RoofPoint
	{
		public float X;

		public float Y;

		public Vector2 V
		{
			get
			{
				return new Vector2(X, Y);
			}
		}

		public RoofPoint()
		{
		}

		public RoofPoint(Vector2 v)
		{
			X = v.x;
			Y = v.y;
		}
	}

	[Serializable]
	public class RoofEdge
	{
		public RoofPoint A;

		public RoofPoint B;

		public RoofEdge()
		{
		}

		public RoofEdge(RoofPoint a, RoofPoint b)
		{
			A = a;
			B = b;
		}
	}

	public static float SideBuildDistance = 0.01f;

	private Color _roofColor = new Color(0.9f, 0.5f, 0.3f, 1f);

	private Color _gableColor = new Color(0.7f, 0.5f, 0.5f, 1f);

	private Color _roofColor2 = new Color(0.9f, 0.5f, 0.3f, 1f);

	private Color _gableColor2 = new Color(0.7f, 0.5f, 0.5f, 1f);

	private string _roofMaterial = "Roof tiles";

	private string _gableMaterial = "Brick wall";

	public MeshFilter RoofingMesh;

	public MeshFilter GableMesh;

	public MeshRenderer RoofingRend;

	public MeshRenderer GableRend;

	public List<Vector2> Area;

	public Rect Bounds;

	public int Floor;

	public List<IRoom> RoofOf = new List<IRoom>();

	[NonSerialized]
	public List<RoofEdge> RoofLine;

	public float Height;

	public float Bulge;

	public bool HasHadOffset;

	[NonSerialized]
	public PlayerMap Map;

	[NonSerialized]
	private int _roofColorID = -1;

	[NonSerialized]
	private int _gableColorID = -1;

	[NonSerialized]
	private uint[] _serializedRooms;

	public Color RoofColor
	{
		get
		{
			return _roofColor;
		}
		set
		{
			_roofColor = value;
			if (_roofColorID >= 0)
			{
				RoomMaterialController.WriteColor(_roofColorID, RoofColor);
			}
		}
	}

	public Color RoofColor2
	{
		get
		{
			return _roofColor2;
		}
		set
		{
			_roofColor2 = value;
			if (_roofColorID >= 0)
			{
				RoomMaterialController.WriteColor(_roofColorID + 1, RoofColor2);
			}
		}
	}

	public Color GableColor
	{
		get
		{
			return _gableColor;
		}
		set
		{
			_gableColor = value;
			if (_gableColorID >= 0)
			{
				RoomMaterialController.WriteColor(_gableColorID, GableColor);
			}
		}
	}

	public Color GableColor2
	{
		get
		{
			return _gableColor2;
		}
		set
		{
			_gableColor2 = value;
			if (_gableColorID >= 0)
			{
				RoomMaterialController.WriteColor(_gableColorID + 1, GableColor2);
			}
		}
	}

	public string GableMaterial
	{
		get
		{
			return _gableMaterial;
		}
		set
		{
			_gableMaterial = value;
			Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
			if (materialForcedSecondaryColor.HasValue)
			{
				GableColor2 = materialForcedSecondaryColor.Value;
			}
			UpdateMesh(GableMesh.sharedMesh, GableMaterial, _gableColorID);
		}
	}

	public string RoofMaterial
	{
		get
		{
			return _roofMaterial;
		}
		set
		{
			_roofMaterial = value;
			Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
			if (materialForcedSecondaryColor.HasValue)
			{
				RoofColor2 = materialForcedSecondaryColor.Value;
			}
			UpdateMesh(RoofingMesh.sharedMesh, RoofMaterial, _roofColorID);
		}
	}

	private void UpdateMesh(Mesh m, string mat, int color)
	{
		if (m != null)
		{
			Vector2 value = new Vector2(color, RoomMaterialController.GetMaterialID(mat));
			m.uv2 = Utilities.RepeatValue(value, m.vertexCount);
		}
	}

	public void SetGable(Mesh gable)
	{
		if (GableMesh.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(GableMesh.sharedMesh);
		}
		if (gable == null)
		{
			if (_gableColorID >= 0)
			{
				RoomMaterialController.Free2Colors(_gableColorID);
				_gableColorID = -1;
			}
			return;
		}
		GableMesh.sharedMesh = gable;
		if (_gableColorID < 0)
		{
			_gableColorID = RoomMaterialController.Take2Colors();
			RoomMaterialController.WriteColor(_gableColorID, GableColor);
			RoomMaterialController.WriteColor(_gableColorID + 1, GableColor2);
		}
		UpdateMesh(GableMesh.sharedMesh, GableMaterial, _gableColorID);
	}

	public void SetRoof(Mesh roofing)
	{
		if (RoofingMesh.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(RoofingMesh.sharedMesh);
		}
		if (roofing == null)
		{
			if (_roofColorID >= 0)
			{
				RoomMaterialController.Free2Colors(_roofColorID);
				_roofColorID = -1;
			}
			return;
		}
		RoofingMesh.sharedMesh = roofing;
		if (_roofColorID < 0)
		{
			_roofColorID = RoomMaterialController.Take2Colors();
			RoomMaterialController.WriteColor(_roofColorID, RoofColor);
			RoomMaterialController.WriteColor(_roofColorID + 1, RoofColor2);
		}
		UpdateMesh(RoofingMesh.sharedMesh, RoofMaterial, _roofColorID);
	}

	public void SetRoofLine(List<RoofPointObject> roofLinePoints, List<RoofEdgeObject> roofLineEdges)
	{
		if (roofLineEdges.Count == 0 && roofLinePoints.Count > 0)
		{
			RoofPoint roofPoint = new RoofPoint(roofLinePoints[0].P);
			RoofLine = new List<RoofEdge>();
			RoofLine.Add(new RoofEdge(roofPoint, roofPoint));
			return;
		}
		Dictionary<RoofPointObject, RoofPoint> points = roofLinePoints.ToDictionary((RoofPointObject x) => x, (RoofPointObject x) => new RoofPoint(x.P));
		RoofLine = roofLineEdges.Select((RoofEdgeObject x) => new RoofEdge(points[x.A], points[x.B])).ToList();
	}

	public void Init(List<IRoom> rooms, List<Vector2> area, int floor)
	{
		RoofOf = rooms;
		for (int i = 0; i < RoofOf.Count; i++)
		{
			RoofOf[i].Roofing = this;
		}
		Floor = floor;
		base.transform.position = Vector3.up * Floor * 2f;
		Area = area;
		Bounds = GetBounds(Area);
	}

	public bool Init(BuildingPrefab prefab, int idx, PlayerMap map)
	{
		Map = map;
		BuildingPrefab.RoofObject roofObject = prefab.Roofs[idx];
		base.NetworkID = roofObject.NetworkID;
		Height = roofObject.Height;
		Bulge = roofObject.Slope;
		List<Vector2> list = roofObject.Area.Select((SVector3 x) => x.ToVector2()).ToList();
		if (Utilities.Clockwise(list))
		{
			list.Reverse();
		}
		Init(((IList<uint>)roofObject.RoofOfNetwork).SelectNotNull((Func<uint, IRoom>)((uint x) => map.Rooms.GetOrNull(x))).ToList(), list, roofObject.Floor);
		RoofColor = roofObject.RoofColor;
		GableColor = roofObject.GableColor;
		if (RoomMaterialController.AllowSecondaryRecolor(roofObject.RoofMaterial))
		{
			RoofColor2 = roofObject.RoofColor2 ?? roofObject.RoofColor.GetDefaultSecondaryColor();
		}
		if (RoomMaterialController.AllowSecondaryRecolor(roofObject.GableMaterial))
		{
			GableColor2 = roofObject.GableColor2 ?? roofObject.GableColor.GetDefaultSecondaryColor();
		}
		RoofMaterial = roofObject.RoofMaterial;
		GableMaterial = roofObject.GableMaterial;
		RoofPoint[] ps = roofObject.RoofPoints.SelectInPlace((SVector3 x) => new RoofPoint(x.ToVector2()));
		RoofLine = roofObject.RoofEdges.ZipList((int x, int y) => new RoofEdge(ps[x], ps[y]));
		return GenerateRoofing();
	}

	public static Rect GetBounds(IList<Vector2> area)
	{
		return area.GetBounds().Expand(1f, 1f);
	}

	private void Start()
	{
		RoofingRend.sharedMaterial = RoomMaterialController.Instance.MainMat;
		GableRend.sharedMaterial = RoomMaterialController.Instance.MainMat;
		if (Map == null)
		{
			InitWritable();
			GameSettings.Instance.sRoomManager.Roofs.Add(this);
		}
	}

	private void FixedUpdate()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			int num = Floor;
			if (Map != null)
			{
				num--;
			}
			bool flag = GameSettings.Instance.ActiveFloor >= num;
			if (flag != (RoofingRend.shadowCastingMode == ShadowCastingMode.On))
			{
				RoofingRend.shadowCastingMode = (flag ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
				GableRend.shadowCastingMode = (flag ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			}
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.sRoomManager.Roofs.Remove(this);
			for (int i = 0; i < RoofOf.Count; i++)
			{
				if (RoofOf[i] != null)
				{
					RoofOf[i].Roofing = null;
				}
			}
			SetGable(null);
			SetRoof(null);
		}
		else
		{
			if (RoofingMesh.sharedMesh != null)
			{
				UnityEngine.Object.Destroy(RoofingMesh.sharedMesh);
			}
			if (GableMesh.sharedMesh != null)
			{
				UnityEngine.Object.Destroy(GableMesh.sharedMesh);
			}
		}
	}

	public override string WriteName()
	{
		return "Roof";
	}

	public override IEnumerable<Selectable> GetRelated()
	{
		return RoofOf.Select((IRoom x) => x as Selectable);
	}

	public override int GetFloor()
	{
		return Floor;
	}

	public override Vector2 GetFlatPos()
	{
		return Utilities.GetPolygonCentroid(Area);
	}

	public override string Description()
	{
		return "Roofs";
	}

	public override string GetInfo()
	{
		return "Room".LocPlural(RoofOf.Count);
	}

	public override bool IsSelectableInView()
	{
		return Map == null;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["Rooms"] = RoofOf.SelectInPlace((IRoom x) => x.GetUniqueID());
		dictionary["RoofLine"] = RoofLine;
		dictionary["Area"] = Area;
		dictionary["Height"] = Height;
		dictionary["Bugle"] = Bulge;
		dictionary["RoofMat"] = RoofMaterial;
		dictionary["RoofColor"] = (SVector3)RoofColor;
		dictionary["GableMat"] = GableMaterial;
		dictionary["GableColor"] = (SVector3)GableColor;
		dictionary["RoofColor2"] = (SVector3)RoofColor2;
		dictionary["GableColor2"] = (SVector3)GableColor2;
		dictionary["Floor"] = Floor;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		_serializedRooms = dictionary.Get("Rooms", new uint[0]);
		RoofLine = dictionary.Get("RoofLine", new List<RoofEdge>());
		Area = dictionary.Get("Area", new List<Vector2>());
		Height = dictionary.Get("Height", 1f);
		Bulge = dictionary.Get("Bugle", 1f);
		RoofMaterial = dictionary.Get("RoofMat", RoofMaterial);
		RoofColor = dictionary.Get("RoofColor", (SVector3)RoofColor);
		GableMaterial = dictionary.Get("GableMat", GableMaterial);
		GableColor = dictionary.Get("GableColor", (SVector3)GableColor);
		RoofColor2 = dictionary.Get("RoofColor2", (SVector3)RoofColor.GetDefaultSecondaryColor());
		GableColor2 = dictionary.Get("GableColor2", (SVector3)GableColor.GetDefaultSecondaryColor());
		Floor = dictionary.Get("Floor", 0);
		Bounds = GetBounds(Area);
		if (!GenerateRoofing())
		{
			DestroyGO();
			return null;
		}
		return this;
	}

	public void ShallowDeserialize(WriteDictionary dictionary)
	{
		SetRoof(null);
		SetGable(null);
		RoofLine = dictionary.Get("RoofLine", new List<RoofEdge>());
		Height = dictionary.Get("Height", 1f);
		Bulge = dictionary.Get("Bugle", 1f);
		RoofMaterial = dictionary.Get("RoofMat", RoofMaterial);
		RoofColor = dictionary.Get("RoofColor", (SVector3)RoofColor);
		GableMaterial = dictionary.Get("GableMat", GableMaterial);
		GableColor = dictionary.Get("GableColor", (SVector3)GableColor);
		RoofColor2 = dictionary.Get("RoofColor2", (SVector3)RoofColor.GetDefaultSecondaryColor());
		GableColor2 = dictionary.Get("GableColor2", (SVector3)GableColor.GetDefaultSecondaryColor());
		if (!GenerateRoofing())
		{
			DestroyGO();
		}
	}

	public bool GenerateRoofing()
	{
		bool[] array = CheckRoofRoomIntersect(Area, Bounds, Floor);
		HasHadOffset = array.Any((bool x) => x);
		List<RoofBuilder.MeshTriangle> list = RoofBuilder.BuildRoof(Area.ToArray(), GenerateRoofLine(RoofLine), array);
		if (list != null)
		{
			Mesh[] array2 = RoofBuilder.BuildRoofMesh(RoofBuilder.Subdivide(Bulge, list), Height / 2f, false);
			SetRoof(array2[0]);
			SetGable((array2.Length > 1) ? array2[1] : null);
			base.transform.localScale = new Vector3(1f, Height, 1f);
			return true;
		}
		Debug.LogError("Roof could not be generated");
		return false;
	}

	public static bool[] CheckRoofRoomIntersect(IList<Vector2> roofArea, Rect bounds, int floor)
	{
		bool[] array = new bool[roofArea.Count];
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (room.Floor != floor || !room.RoomBounds.Overlaps(bounds))
			{
				continue;
			}
			for (int j = 0; j < roofArea.Count; j++)
			{
				if (array[j])
				{
					continue;
				}
				Vector2 p = roofArea[j];
				Vector2 p2 = roofArea[(j + 1) % roofArea.Count];
				for (int k = 0; k < room.Edges.Count; k++)
				{
					Vector2 pos = room.Edges[k].Pos;
					Vector2 pos2 = room.Edges[(k + 1) % room.Edges.Count].Pos;
					if (Utilities.LinesIntersect(p, p2, pos, pos2, false, false))
					{
						array[j] = true;
						break;
					}
				}
			}
		}
		return array;
	}

	public static List<RoofBuilder.RoofEdge> GenerateRoofLine(IList<RoofEdge> roofLine)
	{
		Dictionary<RoofPoint, RoofBuilder.RoofPoint> dict = new Dictionary<RoofPoint, RoofBuilder.RoofPoint>();
		List<RoofBuilder.RoofEdge> list = new List<RoofBuilder.RoofEdge>();
		for (int i = 0; i < roofLine.Count; i++)
		{
			RoofEdge roofEdge = roofLine[i];
			list.Add(new RoofBuilder.RoofEdge(dict.GetOrAdd(roofEdge.A, (RoofPoint x) => new RoofBuilder.RoofPoint(x.V, true)), dict.GetOrAdd(roofEdge.B, (RoofPoint x) => new RoofBuilder.RoofPoint(x.V, true))));
		}
		return list;
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		if (_serializedRooms == null)
		{
			return;
		}
		RoofOf = ((IList<uint>)_serializedRooms).SelectNotNull((Func<uint, IRoom>)((uint x) => GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room z) => z.DID == x))).ToList();
		if (RoofOf.Count > 0)
		{
			Floor = RoofOf[0].Floor + 1;
			base.transform.position = Vector3.up * Floor * 2f;
			for (int num = 0; num < RoofOf.Count; num++)
			{
				RoofOf[num].Roofing = this;
			}
		}
		else
		{
			Debug.LogError("A roof was saved with no associated rooms and will be deleted (Can safely be ignored)");
			DestroyGO();
		}
	}

	public override string[] GetActions()
	{
		return new string[4] { "Destroy", "Roof Color", "Roof material", "Edit roof" };
	}

	public override bool IsSelectionRestricted()
	{
		if (!GameSettings.Instance.EditMode)
		{
			return GameSettings.Instance.RentMode;
		}
		return false;
	}

	private void OnDrawGizmosSelected()
	{
		for (int i = 0; i < Area.Count; i++)
		{
			Vector3 vector = Area[i].ToVector3(Floor * 2);
			Vector3 to = Area[(i + 1) % Area.Count].ToVector3(Floor * 2);
			Gizmos.color = Color.Lerp(Color.white, Color.red, (float)i / (float)(Area.Count - 1));
			Gizmos.DrawLine(vector, to);
		}
	}

	public override IStyle GetStyle()
	{
		return new RoomStyle("", this);
	}

	public override void UpdateStyleNetwork()
	{
		if (base.NetworkID != 0)
		{
			NetworkMessaging.SendObjectStyle(base.NetworkID, true, RoofMaterial, GableMaterial, RoofColor, RoofColor2, GableColor, GableColor2, 0, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public override void ApplyNetworkStyle(string material, string material2, Color c, Color c2, Color c3, Color c4, int atlasIndex)
	{
		RoofMaterial = material;
		GableMaterial = material2;
		RoofColor = c;
		RoofColor2 = c2;
		GableColor = c3;
		GableColor2 = c4;
	}

	public override bool IsNetworkIDLocal()
	{
		return true;
	}

	public override bool IsNetworkIDLocal(WriteDictionary d)
	{
		return true;
	}
}
