using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.Rendering;

public class Room : Selectable, IRoom
{
	[Serializable]
	public class Dirt : IHasVector
	{
		public Vector2 Pos;

		public float Amount;

		public float Rot;

		public int Index;

		public int MeshIndex;

		public int Type;

		public int SubMesh
		{
			get
			{
				return ObjectDatabase.Instance.DirtSubmesh[Type];
			}
		}

		public Dirt()
		{
		}

		public Dirt(Vector2 pos, float rot, float amount, int idx, int mIdx, int type)
		{
			Pos = pos;
			Rot = rot;
			Amount = amount;
			Index = idx;
			MeshIndex = mIdx;
			Type = type;
		}

		public Vector2 GetPos()
		{
			return Pos;
		}
	}

	public enum RoomLimits
	{
		Reception = -5,
		Meeting = -4,
		Canteen = -3,
		Lounge = -2,
		Anyone = -1,
		Leaders = 0,
		Programmers = 1,
		Designers = 2,
		Artists = 3,
		Service = 4
	}

	public enum FloorType
	{
		Wood = 0,
		Carpet = 1,
		Ceramic = 2,
		Concrete = 3
	}

	public class UVTileNode
	{
		public Vector2 OuterP;

		public Vector2 InnerP;

		public float InnerUV;

		public float OuterUV;

		public UVTileNode(Vector2 outerA, Vector2 innerA, float innerUV, float outerUV)
		{
			OuterP = outerA;
			InnerP = innerA;
			InnerUV = innerUV;
			OuterUV = outerUV;
		}
	}

	public enum MatType
	{
		Floor = 0,
		Inner = 1,
		Outer = 2
	}

	private class FreeNavObject
	{
		public int Num;

		public int Count;

		public List<Furniture> Furn;

		public ThreadCountdown Counter;

		public FreeNavObject(int num, int count, List<Furniture> furn, ThreadCountdown counter)
		{
			Num = num;
			Count = count;
			Furn = furn;
			Counter = counter;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass288_0
	{
		public float statIndex;

		public float value;

		public int rank;
	}

	public static float WallOffset = 0.2f;

	public float AccRefreshTime;

	[NonSerialized]
	public Dictionary<PathCacheKey, List<Vector2>> CachedPaths = new Dictionary<PathCacheKey, List<Vector2>>();

	public static HashSet<Room> UpdatePCNoisiness = new HashSet<Room>();

	public Rect RoomBounds;

	public float Insulation = 1f;

	[NonSerialized]
	public string RoomGroup;

	[NonSerialized]
	private HashList<Furniture> _furnitures = new HashList<Furniture>();

	[NonSerialized]
	public Dictionary<string, HashList<Furniture>> FurnitureTypes = new Dictionary<string, HashList<Furniture>>();

	[NonSerialized]
	public List<Actor> Occupants = new List<Actor>();

	public GameObject Darkness;

	public MeshFilter DustFilter;

	public MeshRenderer DustRend;

	[NonSerialized]
	public List<ValueTuple<Room, float>> RoomConnections = new List<ValueTuple<Room, float>>();

	[NonSerialized]
	public List<PathNode<Vector3>> PathNodes = new List<PathNode<Vector3>>();

	public List<PathNode<Vector3>> SubNodes = new List<PathNode<Vector3>>();

	public bool Dummy;

	public bool HasTwoFloor;

	public bool CanClean = true;

	public bool Accessible = true;

	public bool IsPrivate = true;

	public bool IsRect;

	public bool Destroyed;

	[NonSerialized]
	public bool DogBlessing;

	[NonSerialized]
	private bool _playerOwned;

	[NonSerialized]
	private bool _rentable = true;

	public int Reservers;

	public float WindowDarkLevel = 0.5f;

	public float IndirectLighting;

	public float WindowDarkLevelNoCap = 0.5f;

	public float AirCleansing;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public float Smell;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool OnlookerVisited;

	public float Temperature;

	private int _dirt1Count;

	private int _dirt2Count;

	public GameObject InnerWalls;

	public GameObject OuterWalls;

	public GameObject UpperWalls;

	public GameObject BalconyFloor;

	public GameObject FloorMesh;

	public GameObject Roof;

	public GameObject DirtObject;

	public GameObject MainFence;

	public GameObject SubFence;

	public MeshFilter DirtMesh;

	public MeshFilter FloorMeshFilter;

	public MeshFilter TopWallMesh;

	public TeamTextScript TeamText;

	public TeamTextScript RoleText;

	private Renderer TopRend;

	private Renderer DarknessRend;

	public string[] TempTeam;

	public int ForceRole = -1;

	public float DirtScore = 1f;

	public float GermCount;

	private bool DisableDirt;

	public bool BuildingOnFire;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool AllowPass;

	public float Burn;

	public float BurnStop = 1f;

	public float Acoustics = 1f;

	public float FurnEnvironment = 1f;

	public FloorType SFXType = FloorType.Carpet;

	public Texture2D ErrorIcon;

	public GUIStyle ErrorBox;

	public List<string> Problems = new List<string>();

	public bool MajorProblem;

	[NonSerialized]
	public List<Dirt> Dirts = new List<Dirt>();

	[NonSerialized]
	public GridQuery<Dirt> DirtTree;

	[NonSerialized]
	private List<Vector3> _firePoints = new List<Vector3>();

	[NonSerialized]
	private List<Vector3> _outsideFirePoints = new List<Vector3>();

	public float Dust;

	public ParticleSystem DustParticles;

	private float[] AuraValues;

	private float[] AwardBuffs;

	public float Area;

	public bool DirtyNavMesh = true;

	public bool DirtyOuterMesh = true;

	public bool DirtyInnerMesh = true;

	public bool DirtyPathNodes = true;

	public bool DirtyStateVariables = true;

	public bool DirtyFloorMesh;

	public bool DirtyRoofMesh;

	public bool DirtyConveyors = true;

	public bool FixedConveyors;

	public bool DirtyTeamNames = true;

	public bool DirtyTableGroups;

	public bool DirtyFurnitureRoomCheck;

	public bool stateRefreshNeighbours;

	public bool _navmeshRebuilding;

	public bool NavmeshRebuildStarted;

	public Room ParentRoom;

	[NonSerialized]
	public HashList<Room> ChildrenRooms = new HashList<Room>();

	[NonSerialized]
	public Dictionary<Room, float> NoisePropagation = new Dictionary<Room, float>();

	[NonSerialized]
	private List<Vector3> _dirtVector = new List<Vector3>();

	[NonSerialized]
	private List<Vector3> _dirtNormal = new List<Vector3>();

	[NonSerialized]
	private List<Vector2> _dirtUV1 = new List<Vector2>();

	[NonSerialized]
	private List<Vector2> _dirtUV2 = new List<Vector2>();

	[NonSerialized]
	private List<int> _dirtIndex = new List<int>();

	[NonSerialized]
	private List<int> _dirtIndex2 = new List<int>();

	[NonSerialized]
	private List<UndoObject.UndoAction> _destructionUndo = new List<UndoObject.UndoAction>();

	[NonSerialized]
	public TemperatureGroup TempGroup;

	[NonSerialized]
	public CCTVGroup CCGroup;

	private bool _hasCachedDestructionCost;

	private float _cachedDestructionCost;

	[NonSerialized]
	public object NavLock = new object();

	[NonSerialized]
	private object _rebuildLock = new object();

	[NonSerialized]
	private bool _navMeshLocked;

	[NonSerialized]
	public Dictionary<RoomConKey, RoomCon> RoomConCache = new Dictionary<RoomConKey, RoomCon>();

	[NonSerialized]
	private bool _isBeingDestroyed;

	[NonSerialized]
	public Room AtriumParent;

	[NonSerialized]
	public List<Room> AtriumChildren = new List<Room>();

	private GameObject Grass;

	private static int[] _grassBladeCount = new int[4] { 0, 7, 10, 14 };

	public static readonly HashList<Furniture> EmptyFurn = new HashList<Furniture>();

	private static HashSet<Furniture> _startConveyors = new HashSet<Furniture>();

	private static HashSet<Conveyor> _conveyorTrav = new HashSet<Conveyor>();

	public string _insideMat;

	public string _outsideMat;

	public string _floorMat;

	public string _fenceStyle = "Concrete";

	private Color _insideColor = Color.white;

	private Color _floorColor = Color.white;

	private Color _outsideColor = Color.gray;

	private Color _insideColor2 = Color.white;

	private Color _floorColor2 = Color.white;

	private Color _outsideColor2 = Color.gray;

	private Color _fenceColor = Color.gray;

	[NonSerialized]
	private int _insideColorID = -1;

	[NonSerialized]
	private int _floorColorID = -1;

	[NonSerialized]
	private int _outsideColorID = -1;

	private static bool _fromParent = false;

	private float _darknessLevel;

	[NonSerialized]
	public List<Furniture> Lamps = new List<Furniture>();

	[NonSerialized]
	public HashSet<Team> Teams = new HashSet<Team>();

	private static string[] actions = new string[12]
	{
		"Destroy", "Change Room Team", "Limit Use", "Select Staff", "SelectBuildingFloor", "Select Building", "Room Color", "Material", "Types in Room", "SegmentsInRoom",
		"MergeRooms", "GroupRooms"
	};

	private static string[] pillarActions = new string[6] { "Destroy", "SelectBuildingFloor", "Select Building", "Room Color", "Material", "MergeRooms" };

	private static string[] pillarRentActions = new string[3] { "SelectBuildingFloor", "Select Building", "Room Color" };

	private static string[] pillarNotOwnedActions = new string[2] { "SelectBuildingFloor", "Select Building" };

	private static string[] EditActions = new string[12]
	{
		"Destroy", "SelectBuildingFloor", "Select Building", "Room Color", "Material", "Types in Room", "SegmentsInRoom", "MergeRooms", "ToggleRentable", "TogglePlayerOwned",
		"GroupRentRooms", "AutoGroupRentRooms"
	};

	private static string[] RentableActions = new string[8] { "Change Room Team", "Limit Use", "Select Staff", "SelectBuildingFloor", "Select Building", "Room Color", "Types in Room", "GroupRooms" };

	private static string[] NotOwnedRentableActions = new string[3] { "Select Staff", "SelectBuildingFloor", "Select Building" };

	private static string[] NonRentable = new string[3] { "Select Staff", "SelectBuildingFloor", "Select Building" };

	private static string[] AtriumActions = new string[8] { "Destroy", "Select Staff", "SelectBuildingFloor", "Select Building", "Room Color", "Material", "Types in Room", "SegmentsInRoom" };

	private static string[] RentableAtriumActions = new string[5] { "Select Staff", "SelectBuildingFloor", "Select Building", "Room Color", "Types in Room" };

	public List<TableScript> TableParents = new List<TableScript>();

	private static List<Furniture> _tableGroupCache = new List<Furniture>();

	[NonSerialized]
	public float WallArea = 1f;

	private static List<Furniture> _furnCache = new List<Furniture>();

	private static Dictionary<Room, float> _roomConnectionCache = new Dictionary<Room, float>();

	private static float[,] _cacheAuraCap = new float[3, 2];

	[NonSerialized]
	private float _coolingControlArea;

	[NonSerialized]
	private float _heatingControlArea;

	[NonSerialized]
	private float _coolingDirectArea;

	[NonSerialized]
	private float _heatingDirectArea;

	[NonSerialized]
	private float _serverTemp;

	[NonSerialized]
	private float _noThermoArea;

	public float TheoCoolingControlArea;

	public float TheoHeatingControlArea;

	[NonSerialized]
	private float _lastTempValueUpdate = -1f;

	[NonSerialized]
	public float TempHeatDirectUsage;

	[NonSerialized]
	public float TempCoolDirectUsage;

	[NonSerialized]
	public float TempHeatControlUsage;

	[NonSerialized]
	public float TempCoolControlUsage;

	private bool DataOverlayMode;

	[NonSerialized]
	private MaterialPropertyBlock _dataBlock;

	public const float SprinklerProtectionDistance = 2f;

	private bool _anyBurnables = true;

	[NonSerialized]
	public float _lastLampDarkLevel;

	public bool FurnOnFire;

	private float _dirtWarningTimer;

	public const float SmellChangeFactor = 0.5f;

	private static readonly List<TriangleNode.Portal> PortalCache = new List<TriangleNode.Portal>();

	public Vector2 Center;

	[NonSerialized]
	private uint SerializedParentRoom;

	[NonSerialized]
	private uint[] SerializedChildrenRooms;

	private static Color[] _nearnessColors = new Color[5]
	{
		new Color(0f, 1f, 0f),
		new Color(0f, 1f, 1f),
		new Color(1f, 0f, 1f),
		new Color(1f, 1f, 0f),
		new Color(1f, 0f, 0f)
	};

	private bool HasTriedFix;

	private static List<Vector2> _supportCheckCache = new List<Vector2>();

	private static HashSet<WallEdge> _supportEdgeCheckCache = new HashSet<WallEdge>();

	private static List<WallSnap> _segmentCache = new List<WallSnap>();

	private static List<WallSnap> _wallSnapCache = new List<WallSnap>();

	[NonSerialized]
	private bool _isSurrounded;

	[NonSerialized]
	private List<UVTileNode> _uvTiling;

	private TriangleNode[] NavMap;

	private BSPTree<TriangleNode> BSPNavMap;

	public const float AgentRadius = 0.3f;

	[NonSerialized]
	public MultiBitMask Mask;

	[NonSerialized]
	public MultiBitMask PseudoMask;

	[NonSerialized]
	public MultiBitMask TeamMask;

	[NonSerialized]
	public HashSet<Team> ActuallyAllowed;

	public List<WallEdge> Edges { get; set; }

	public int Floor { get; set; }

	public bool Outdoors { get; set; }

	public bool Pillar { get; set; }

	public float FenceHeight { get; set; } = 1f;

	public int AtriumChildrenCount
	{
		get
		{
			return AtriumChildren.Count;
		}
	}

	public Roof Roofing { get; set; }

	public bool IsOnFire { get; private set; }

	public bool Outside { get; set; }

	[SaveField]
	public SVector3 FloorOffset { get; set; } = SVector3.Zero;

	[SaveField]
	public float FloorRotation { get; set; }

	[SaveField(1f)]
	public float FloorScale { get; set; } = 1f;

	public bool IsUpperAtrium
	{
		get
		{
			if (AtriumParent.IsAliveNotNull())
			{
				return AtriumParent != this;
			}
			return false;
		}
	}

	public bool IsUpperAtriumNotBalcony
	{
		get
		{
			if (AtriumParent.IsAliveNotNull() && AtriumParent != this)
			{
				return AtriumParent.AtriumParent == AtriumParent;
			}
			return false;
		}
	}

	public bool IsBalcony
	{
		get
		{
			if (AtriumParent.IsAliveNotNull() && AtriumParent != this)
			{
				return AtriumParent.AtriumParent != AtriumParent;
			}
			return false;
		}
	}

	public string InsideMat
	{
		get
		{
			return _insideMat;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				_fromParent = true;
				Room mainAtriumParent = GetMainAtriumParent();
				mainAtriumParent.InsideMat = value;
				foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
				{
					atriumChild.InsideMat = value;
				}
				_fromParent = false;
			}
			Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
			if (materialForcedSecondaryColor.HasValue)
			{
				InsideColor2 = materialForcedSecondaryColor.Value;
			}
			if (InnerWalls != null)
			{
				SetMaterial(this, InnerWalls.GetComponent<MeshFilter>(), value, _insideColorID, true);
			}
			_insideMat = value;
		}
	}

	public string OutsideMat
	{
		get
		{
			return _outsideMat;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				_fromParent = true;
				Room mainAtriumParent = GetMainAtriumParent();
				mainAtriumParent.OutsideMat = value;
				foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
				{
					atriumChild.OutsideMat = value;
				}
				_fromParent = false;
			}
			Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
			if (materialForcedSecondaryColor.HasValue)
			{
				OutsideColor2 = materialForcedSecondaryColor.Value;
			}
			if (OuterWalls != null && !Outdoors)
			{
				SetMaterial(this, OuterWalls.GetComponent<MeshFilter>(), value, _outsideColorID, false);
			}
			_outsideMat = value;
		}
	}

	public string FloorMat
	{
		get
		{
			return _floorMat;
		}
		set
		{
			if (!"None".Equals(value) || Outdoors)
			{
				RoomMaterialController.WallMaterial value2;
				SFXType = ((!RoomMaterialController.Instance.AllMaterials.TryGetValue(value, out value2)) ? FloorType.Carpet : value2.SFXType);
				Color? materialForcedSecondaryColor = RoomMaterialController.GetMaterialForcedSecondaryColor(value);
				if (materialForcedSecondaryColor.HasValue)
				{
					FloorColor2 = materialForcedSecondaryColor.Value;
				}
				if (FloorMesh != null)
				{
					SetMaterial(this, FloorMesh.GetComponent<MeshFilter>(), value, _floorColorID, true);
				}
				_floorMat = value;
				UpdateGrass();
			}
		}
	}

	public Color InsideColor
	{
		get
		{
			return _insideColor;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				Room mainAtriumParent = GetMainAtriumParent();
				if (!mainAtriumParent.IsReferenceNull())
				{
					_fromParent = true;
					mainAtriumParent.InsideColor = value;
					foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
					{
						if (atriumChild.IsAliveNotNull())
						{
							atriumChild.InsideColor = value;
						}
					}
					_fromParent = false;
				}
			}
			if (_insideColorID == -1)
			{
				_insideColorID = RoomMaterialController.Take2Colors();
			}
			if (Burn > 0f)
			{
				value = value.Alpha(1f - Burn);
			}
			RoomMaterialController.WriteColor(_insideColorID, value);
			_insideColor = value;
		}
	}

	public Color InsideColor2
	{
		get
		{
			return _insideColor2;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				Room mainAtriumParent = GetMainAtriumParent();
				if (!mainAtriumParent.IsReferenceNull())
				{
					_fromParent = true;
					mainAtriumParent.InsideColor2 = value;
					foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
					{
						if (atriumChild.IsAliveNotNull())
						{
							atriumChild.InsideColor2 = value;
						}
					}
					_fromParent = false;
				}
			}
			if (_insideColorID == -1)
			{
				_insideColorID = RoomMaterialController.Take2Colors();
			}
			RoomMaterialController.WriteColor(_insideColorID + 1, value);
			_insideColor2 = value;
		}
	}

	public Color OutsideColor
	{
		get
		{
			return _outsideColor;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				Room mainAtriumParent = GetMainAtriumParent();
				if (!mainAtriumParent.IsReferenceNull())
				{
					_fromParent = true;
					mainAtriumParent.OutsideColor = value;
					foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
					{
						if (atriumChild.IsAliveNotNull())
						{
							atriumChild.OutsideColor = value;
						}
					}
					_fromParent = false;
				}
			}
			if (!Outdoors)
			{
				if (_outsideColorID == -1)
				{
					_outsideColorID = RoomMaterialController.Take2Colors();
				}
				if (Burn > 0f)
				{
					value = value.Alpha(1f - Burn);
				}
				RoomMaterialController.WriteColor(_outsideColorID, value);
			}
			_outsideColor = value;
		}
	}

	public Color OutsideColor2
	{
		get
		{
			return _outsideColor2;
		}
		set
		{
			if (!_fromParent && AtriumParent != null)
			{
				Room mainAtriumParent = GetMainAtriumParent();
				if (!mainAtriumParent.IsReferenceNull())
				{
					_fromParent = true;
					mainAtriumParent.OutsideColor2 = value;
					foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
					{
						if (atriumChild.IsAliveNotNull())
						{
							atriumChild.OutsideColor2 = value;
						}
					}
					_fromParent = false;
				}
			}
			if (!Outdoors)
			{
				if (_outsideColorID == -1)
				{
					_outsideColorID = RoomMaterialController.Take2Colors();
				}
				RoomMaterialController.WriteColor(_outsideColorID + 1, value);
			}
			_outsideColor2 = value;
		}
	}

	public Color FenceColor
	{
		get
		{
			return _fenceColor;
		}
		set
		{
			if (MainFence != null)
			{
				Mesh sharedMesh = MainFence.GetComponent<MeshFilter>().sharedMesh;
				sharedMesh.colors = Utilities.RepeatValue(value, sharedMesh.vertexCount);
			}
			_fenceColor = value;
		}
	}

	public Color FloorColor
	{
		get
		{
			return _floorColor;
		}
		set
		{
			if (_floorColorID == -1)
			{
				_floorColorID = RoomMaterialController.Take2Colors();
			}
			if (Burn > 0f)
			{
				value = value.Alpha(1f - Burn);
			}
			RoomMaterialController.WriteColor(_floorColorID, value);
			_floorColor = value;
		}
	}

	public Color FloorColor2
	{
		get
		{
			return _floorColor2;
		}
		set
		{
			if (_floorColorID == -1)
			{
				_floorColorID = RoomMaterialController.Take2Colors();
			}
			RoomMaterialController.WriteColor(_floorColorID + 1, value);
			_floorColor2 = value;
		}
	}

	public string FenceStyle
	{
		get
		{
			return _fenceStyle;
		}
	}

	public float DarknessLevel
	{
		get
		{
			if (Darkness != null || AtriumParent != null)
			{
				return _darknessLevel;
			}
			return 0f;
		}
	}

	public bool Rentable
	{
		get
		{
			if (!Pillar)
			{
				return _rentable;
			}
			return false;
		}
		set
		{
			if (Pillar)
			{
				value = false;
			}
			if (_rentable == value)
			{
				return;
			}
			CheckAtriumChildrenForRent();
			_rentable = value;
			if (!_rentable)
			{
				_playerOwned = false;
			}
			Room room = ParentRoom ?? this;
			if (room == this)
			{
				HashList<Room> childrenRooms = room.ChildrenRooms;
				for (int i = 0; i < childrenRooms.Count; i++)
				{
					childrenRooms[i].Rentable = value;
				}
			}
			else
			{
				room.Rentable = value;
			}
		}
	}

	public bool PlayerOwned
	{
		get
		{
			return _playerOwned;
		}
	}

	public bool IsSurrounded
	{
		get
		{
			return _isSurrounded;
		}
	}

	public uint GetUniqueID()
	{
		return DID;
	}

	public uint GetRoomNetworkID()
	{
		return InitLocalNetworkID();
	}

	public void AddOccupant(Actor a)
	{
		if (a.AItype != AI.AIType.Burglar && a.AItype != AI.AIType.FireInspector && !AI.IsStaff(a.AItype) && !a.employee.Founder)
		{
			OnlookerVisited = true;
		}
		Occupants.Add(a);
	}

	public void RemoveOccupant(Actor a)
	{
		Occupants.Remove(a);
	}

	public bool IsAtriumParent(Room r)
	{
		if (!(AtriumParent == r))
		{
			if (AtriumParent.IsAliveNotNull())
			{
				return AtriumParent.AtriumParent == r;
			}
			return false;
		}
		return true;
	}

	public Room GetMainAtriumParent()
	{
		if (!AtriumParent.IsAliveNotNull())
		{
			return null;
		}
		if (AtriumParent == this)
		{
			return this;
		}
		return AtriumParent.GetMainAtriumParent();
	}

	public Room GetMainAtriumParentOrSelf()
	{
		if (!AtriumParent.IsAliveNotNull() || AtriumParent == this)
		{
			return this;
		}
		return AtriumParent.GetMainAtriumParentOrSelf();
	}

	public Room GetBalconyMainAtriumParentOrSelf()
	{
		if (!AtriumParent.IsAliveNotNull() || AtriumParent == this || IsBalcony)
		{
			return this;
		}
		return AtriumParent.GetBalconyMainAtriumParentOrSelf();
	}

	public IEnumerable<Room> GetAtriumChildren()
	{
		bool bAtr = AtriumParent == this;
		for (int i = 0; i < AtriumChildren.Count; i++)
		{
			Room child = AtriumChildren[i];
			yield return child;
			if (bAtr)
			{
				for (int j = 0; j < child.AtriumChildren.Count; j++)
				{
					yield return child.AtriumChildren[j];
				}
			}
		}
	}

	public IEnumerable<Room> GetAtriumChildrenAndSelf()
	{
		yield return this;
		bool bAtr = AtriumParent == this;
		for (int i = 0; i < AtriumChildren.Count; i++)
		{
			Room child = AtriumChildren[i];
			yield return child;
			if (bAtr)
			{
				for (int j = 0; j < child.AtriumChildren.Count; j++)
				{
					yield return child.AtriumChildren[j];
				}
			}
		}
	}

	public IEnumerable<Room> GetConnectedAtriumRoomsForSelection()
	{
		if (IsUpperAtriumNotBalcony)
		{
			yield return AtriumParent;
			for (int i = 0; i < AtriumParent.AtriumChildren.Count; i++)
			{
				yield return AtriumParent.AtriumChildren[i];
			}
		}
		else if (this == AtriumParent)
		{
			yield return this;
			for (int i = 0; i < AtriumChildren.Count; i++)
			{
				yield return AtriumChildren[i];
			}
		}
		else
		{
			yield return this;
		}
	}

	public IEnumerable<IRoom> GetSelfAndAtriumsAbove()
	{
		yield return this;
		if (!AtriumParent.IsAliveNotNull())
		{
			yield break;
		}
		if (AtriumParent == this)
		{
			for (int i = 0; i < AtriumChildren.Count; i++)
			{
				yield return AtriumChildren[i];
			}
		}
		else if (!IsBalcony)
		{
			int num = AtriumParent.AtriumChildren.IndexOf(this);
			for (int i = num + 1; i < AtriumParent.AtriumChildren.Count; i++)
			{
				yield return AtriumParent.AtriumChildren[i];
			}
		}
	}

	public IEnumerable<Room> GetTouchingRooms()
	{
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge other = Edges[i];
			Room room = Edges[(i + 1) % Edges.Count].GetRoom(other);
			if (room != null && !room.Outside)
			{
				yield return room;
			}
		}
	}

	public void UpdateGrass()
	{
		if (Grass != null)
		{
			UnityEngine.Object.Destroy(Grass);
		}
		if (Options.GrassOutdoors && Options.GrassQuality > 0 && Outdoors && "None".Equals(FloorMat) && FloorMesh != null)
		{
			Grass = new GameObject("Grass");
			Grass.transform.SetParent(base.transform);
			Grass.transform.position = Vector3.up * Floor * 2f;
			MeshRenderer meshRenderer = Grass.AddComponent<MeshRenderer>();
			MeshFilter meshFilter = Grass.AddComponent<MeshFilter>();
			Mesh sharedMesh = FloorMesh.GetComponent<MeshFilter>().sharedMesh;
			List<CombineInstance> list = new List<CombineInstance>();
			int num = _grassBladeCount[Mathf.Clamp(Options.GrassQuality, 0, _grassBladeCount.Length - 1)];
			for (int i = 1; i <= num; i++)
			{
				list.Add(new CombineInstance
				{
					mesh = sharedMesh,
					transform = Matrix4x4.Translate(Vector3.up * ((float)i * 0.1f / (float)num))
				});
			}
			Mesh mesh = (meshFilter.sharedMesh = new Mesh());
			mesh.CombineMeshes(list.ToArray());
			meshRenderer.sharedMaterials = new Material[2]
			{
				TimeOfDay.Instance.NoiseGrassMaterial,
				TimeOfDay.Instance.GrassMask
			};
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetTexture("_Trot", Texture2D.whiteTexture);
			materialPropertyBlock.SetTexture("_MaskTex", Texture2D.whiteTexture);
			materialPropertyBlock.SetFloat("_BaseHeight", (float)Floor * 2f);
			meshRenderer.SetPropertyBlock(materialPropertyBlock);
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
	}

	private void SetNavMeshRunning(bool started)
	{
		lock (_rebuildLock)
		{
			_navmeshRebuilding = started;
		}
	}

	public bool GetNavMeshRunning()
	{
		lock (_rebuildLock)
		{
			return _navmeshRebuilding;
		}
	}

	public bool WaitForNavmesh()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		while (!_navMeshLocked && GetNavMeshRunning())
		{
			if (Time.realtimeSinceStartup - realtimeSinceStartup > 1f)
			{
				_navMeshLocked = true;
				break;
			}
		}
		return !GetNavMeshRunning();
	}

	public void AddDestructionUndo(Furniture furn)
	{
		if (!furn.Type.Equals("Award") && string.IsNullOrEmpty(furn.MetalMarket))
		{
			_destructionUndo.Add(new UndoObject.UndoAction(furn));
			_hasCachedDestructionCost = false;
		}
		GameSettings.Instance.InsuranceIncident();
	}

	public void ResetDestructionUndo()
	{
		if (BuildController.Instance != null)
		{
			_destructionUndo.Clear();
			BuildController.Instance.RefreshRestoreButton();
			_hasCachedDestructionCost = false;
		}
	}

	public bool AnyFurnitureRestoration()
	{
		if (_destructionUndo != null)
		{
			return _destructionUndo.Count > 0;
		}
		return false;
	}

	public float GetRestoreFurnitureCost()
	{
		if (!_hasCachedDestructionCost)
		{
			_cachedDestructionCost = 0f;
			for (int i = 0; i < _destructionUndo.Count; i++)
			{
				UndoObject.UndoAction undoAction = _destructionUndo[i];
				WriteDictionary writeDictionary = undoAction.Get<WriteDictionary>("Furn");
				string type = writeDictionary["Type"].ToString();
				uint num = writeDictionary.Get("WriteID", 0u);
				if (num == 0 || !GameSettings.HasInventoryItem(type, num))
				{
					_cachedDestructionCost += undoAction.BalanceDiff;
				}
			}
			_hasCachedDestructionCost = true;
		}
		return 0f - _cachedDestructionCost;
	}

	public bool HasRestore()
	{
		return _destructionUndo.Count > 0;
	}

	public bool RestoreFurniture()
	{
		if (_destructionUndo.Count > 0)
		{
			new UndoObject(FixDestructionUndo()).Execute(true);
			_destructionUndo.Clear();
			return true;
		}
		return false;
	}

	public void AddFurniture(Furniture furn)
	{
		ResetDestructionUndo();
		MakeTemperatureDirty(false);
		lock (_furnitures)
		{
			_furnitures.Add(furn);
		}
		FurnitureTypes.Append(furn.Type, furn);
		if ("Elevator".Equals(furn.Type) && IgnoreConnected())
		{
			HUD.Instance.InaccessibleRoom.Remove(this);
		}
	}

	public bool RemoveFurniture(Furniture furn)
	{
		bool flag;
		lock (_furnitures)
		{
			flag = _furnitures.Remove(furn);
		}
		if (flag)
		{
			GetFurniture(furn.Type).Remove(furn);
			if (!furn.NonPlayerDestruction)
			{
				ResetDestructionUndo();
			}
			MakeTemperatureDirty(false);
		}
		return flag;
	}

	public HashList<Furniture> GetFurniture(string type)
	{
		return FurnitureTypes.GetOrDefault(type, EmptyFurn);
	}

	public List<Furniture> GetFurnitures()
	{
		return _furnitures.GetUnderlyingList();
	}

	public IEnumerable<Furniture> GetFurnitureInAtrium(string type)
	{
		Room pick = this;
		Room main = GetMainAtriumParentOrSelf();
		if (!IsBalcony)
		{
			pick = main;
		}
		for (int j = 0; j < main.AtriumChildren.Count + 1; j++)
		{
			Room room = ((j == 0) ? pick : main.AtriumChildren[j - 1]);
			HashList<Furniture> fs = room.GetFurniture(type);
			for (int i = 0; i < fs.Count; i++)
			{
				Furniture furniture = fs[i];
				if (furniture.InteractionParent == pick)
				{
					yield return furniture;
				}
			}
		}
	}

	public bool AnyFurnitureInAtrium(string type)
	{
		Room room = this;
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		if (!IsBalcony)
		{
			room = mainAtriumParentOrSelf;
		}
		for (int i = 0; i < mainAtriumParentOrSelf.AtriumChildren.Count + 1; i++)
		{
			Room room2 = ((i == 0) ? room : mainAtriumParentOrSelf.AtriumChildren[i - 1]);
			if (room2.FurnitureTypes.ContainsKey(type) && room2.FurnitureTypes[type].Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	public IEnumerable<Furniture> GetFurnituresInAtrium()
	{
		Room pick = this;
		Room main = GetMainAtriumParentOrSelf();
		if (!IsBalcony)
		{
			pick = main;
		}
		for (int j = 0; j < main.AtriumChildren.Count + 1; j++)
		{
			Room child = ((j == 0) ? pick : main.AtriumChildren[j - 1]);
			for (int i = 0; i < child._furnitures.Count; i++)
			{
				Furniture furniture = child._furnitures[i];
				if (furniture.InteractionParent == pick)
				{
					yield return furniture;
				}
			}
		}
	}

	public IEnumerable<Furniture> GetFurnituresInAtrium(int maxFloor)
	{
		Room pick = this;
		Room main = GetMainAtriumParentOrSelf();
		if (!IsBalcony)
		{
			pick = main;
		}
		for (int j = 0; j < main.AtriumChildren.Count + 1; j++)
		{
			Room child = ((j == 0) ? pick : main.AtriumChildren[j - 1]);
			if (child.Floor > maxFloor)
			{
				continue;
			}
			for (int i = 0; i < child._furnitures.Count; i++)
			{
				Furniture furniture = child._furnitures[i];
				if (furniture.InteractionParent == pick)
				{
					yield return furniture;
				}
			}
		}
	}

	public void UpdateRoom(bool navmesh, bool outermesh, bool innermesh, bool pathnodes, bool stateVars, bool floormesh = false, bool roofmesh = false, bool dirtyTeamNames = false, bool dirtyTableGroups = false)
	{
		if (!this.IsAliveNotNull())
		{
			return;
		}
		if (Pillar)
		{
			DirtyNavMesh = false;
			DirtyPathNodes = false;
			DirtyInnerMesh = false;
			DirtyFloorMesh = false;
			navmesh = false;
			pathnodes = false;
			innermesh = false;
			floormesh = false;
		}
		if (IsUpperAtriumNotBalcony)
		{
			navmesh = false;
			pathnodes = false;
			DirtyNavMesh = false;
			DirtyPathNodes = false;
		}
		else if (IsBalcony)
		{
			outermesh = outermesh || floormesh;
			floormesh = floormesh || outermesh;
		}
		if (innermesh || outermesh)
		{
			List<RoomSegment> segments = GetSegments();
			for (int i = 0; i < segments.Count; i++)
			{
				segments[i].UpdateMerge();
			}
		}
		if (innermesh && floormesh)
		{
			floormesh = false;
		}
		if (outermesh && roofmesh)
		{
			roofmesh = false;
		}
		bool flag = false;
		if (NavmeshRebuildStarted && !GetNavMeshRunning() && !navmesh)
		{
			PostNavMesh();
			flag = true;
			NavmeshRebuildStarted = false;
			if (Dummy)
			{
				RoadManager.Instance.PlaceRoadLamps();
			}
		}
		else if (!GetNavMeshRunning() && (navmesh || (!Outside && pathnodes)) && (NavMap == null || (!IsOnFire && GameSettings.ConstructionAllowed())))
		{
			NavmeshRebuildStarted = true;
			SetNavMeshRunning(true);
			GameSettings.StartNav(this);
			CachedPaths.Clear();
			if (AtriumParent != null)
			{
				foreach (Room item in GetElligableAtriumSearch())
				{
					for (int j = 0; j < item._furnitures.Count; j++)
					{
						Furniture furniture = item._furnitures[j];
						if (furniture.InteractionParent == this)
						{
							furniture.ImprintPosition();
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < _furnitures.Count; k++)
				{
					_furnitures[k].ImprintPosition();
				}
			}
			new Thread((ParameterizedThreadStart)delegate
			{
				BuildNavMesh();
			}).Start();
		}
		if (outermesh)
		{
			UpdateOuteredges();
			Highlightables = null;
		}
		if (innermesh)
		{
			GenerateInnerPolygon();
			Highlightables = null;
		}
		if (floormesh)
		{
			UpdateFloor();
			Highlightables = null;
			UpdateVisibility();
		}
		if (roofmesh)
		{
			GenerateRoof();
			Highlightables = null;
			UpdateVisibility();
		}
		if (!GetNavMeshRunning() && pathnodes)
		{
			if (!flag && Outside)
			{
				GameSettings.Instance.sRoomManager.PathController.UpdateEndPoints();
			}
			UpdatePathNodes();
		}
		if (stateVars)
		{
			innerRecalculateStateVariables(stateRefreshNeighbours);
		}
		if (FixedConveyors)
		{
			DirtyConveyors = false;
			FixedConveyors = false;
		}
		if (DirtyConveyors)
		{
			DirtyConveyors = false;
			FixedConveyors = true;
			_startConveyors.Clear();
			_startConveyors.AddRange(_furnitures.Where((Furniture x) => x.IsAliveNotNull() && x.HasConveyor && x.Parent == this));
			for (int num = 0; num < _furnitures.Count; num++)
			{
				Furniture furniture2 = _furnitures[num];
				if (furniture2.IsAliveNotNull() && furniture2.HasConveyor)
				{
					if (furniture2.Parent == this)
					{
						furniture2.Conveyor.ConnectUp(_startConveyors);
					}
					else if (furniture2.Conveyor.OutputSecondRoom.Any((bool x) => x) && furniture2.Parent != this)
					{
						furniture2.Parent.DirtyConveyors = true;
					}
				}
			}
			for (int num2 = 0; num2 < _furnitures.Count; num2++)
			{
				Furniture furniture3 = _furnitures[num2];
				if (furniture3.IsAliveNotNull() && furniture3.HasConveyor && furniture3.Parent == this)
				{
					furniture3.Conveyor.CheckFacingSelf();
					furniture3.Conveyor.UpdateBelts();
				}
			}
			int num3 = 0;
			_conveyorTrav.Clear();
			foreach (Furniture startConveyor in _startConveyors)
			{
				TraverseConveyor(startConveyor.Conveyor, num3, 0, _conveyorTrav);
				num3++;
			}
			_conveyorTrav.Clear();
			for (int num4 = 0; num4 < _furnitures.Count; num4++)
			{
				Furniture furniture4 = _furnitures[num4];
				if (furniture4.IsAliveNotNull() && furniture4.HasConveyor && furniture4.Conveyor.PalletToInput)
				{
					furniture4.Conveyor.ConnectPallet();
				}
			}
			_startConveyors.Clear();
			ConveyorFlow.SetFlowDirty();
		}
		if (dirtyTeamNames && !GameSettings.Instance.sRoomManager.TeamAssignmentDirty)
		{
			DirtyTeamNames = false;
			UpdateTeamText();
			UpdateProblems();
			if (!navmesh && !pathnodes)
			{
				for (int num5 = 0; num5 < _furnitures.Count; num5++)
				{
					Furniture furniture5 = _furnitures[num5];
					if (furniture5.IsAliveNotNull() && furniture5.CanAssign)
					{
						furniture5.CheckAllowedInRoom();
					}
				}
			}
		}
		if (DirtyTableGroups)
		{
			RecalculateTableGroupsInner();
		}
		if (DirtyFurnitureRoomCheck)
		{
			DirtyFurnitureRoomCheck = false;
			for (int num6 = 0; num6 < _furnitures.Count; num6++)
			{
				_furnitures[num6].CheckUserCanUseInRoom();
			}
		}
	}

	private int? TraverseConveyor(Conveyor c, int group, int number, HashSet<Conveyor> hits)
	{
		if (hits.Add(c))
		{
			int? result = null;
			for (int i = 0; i < c.OutputLength; i++)
			{
				Conveyor output = c.GetOutput(i);
				if (output != null && output.Parent.Parent == this)
				{
					int? num = TraverseConveyor(output, group, number + 1, hits);
					if (num.HasValue)
					{
						result = num;
						group = num.Value;
					}
				}
			}
			c.Group = group;
			c.Number = number;
			return result;
		}
		return c.Group;
	}

	public bool MakeBlack()
	{
		if (!Outdoors && !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode && Rentable)
		{
			return !PlayerOwned;
		}
		return false;
	}

	public IRoom GetAtriumParent(bool returnNull)
	{
		if (!returnNull)
		{
			return GetMainAtriumParentOrSelf();
		}
		return GetMainAtriumParent();
	}

	public static void SetMaterial(IRoom room, MeshFilter rend, string mat, int colorID, bool canBlack)
	{
		if (rend != null)
		{
			bool flag = canBlack && room.MakeBlack();
			Room room2;
			float materialIDAndSkirt = RoomMaterialController.GetMaterialIDAndSkirt(flag ? "CannotRent" : mat, (object)(room2 = room as Room) != null && room2.IsUpperAtrium);
			Mesh sharedMesh = rend.sharedMesh;
			Vector2[] uv = sharedMesh.uv2;
			int num = (mat.Equals("None") ? RoomMaterialController.Instance.GroundColorID : (flag ? RoomMaterialController.Instance.BlackColorID : colorID));
			for (int i = 0; i < uv.Length; i++)
			{
				uv[i] = new Vector2(num, materialIDAndSkirt);
			}
			sharedMesh.uv2 = uv;
		}
	}

	public bool SetFenceStyle(string value, List<UndoObject.UndoAction> undos)
	{
		if (Outdoors || IsBalcony)
		{
			_fenceStyle = value;
			FenceHeight = ObjectDatabase.Instance.FenceStyles.First((ObjectDatabase.FenceStyle x) => x.Name.Equals(_fenceStyle)).Height;
			for (int num = 0; num < Edges.Count; num++)
			{
				WallEdge wallEdge = Edges[num];
				WallEdge wallEdge2 = Edges[(num + 1) % Edges.Count];
				HashSet<WallSnap> orNull = wallEdge.Children.GetOrNull(wallEdge2);
				if (orNull != null)
				{
					foreach (WallSnap item in orNull)
					{
						if (!item.ValidSnap(false) && undos != null && item.IsAliveNotNull())
						{
							undos.Add(new UndoObject.UndoAction(item, false));
							item.DestroyGO();
						}
					}
				}
				Room room = wallEdge2.GetRoom(wallEdge);
				if (room != null && (room.Outdoors || room.IsBalcony))
				{
					room.DirtyOuterMesh = true;
				}
			}
			DirtyOuterMesh = true;
			return true;
		}
		return false;
	}

	public void SetPlayerOwned(bool playerOwned, List<UndoObject.UndoAction> undo)
	{
		if (_playerOwned == playerOwned)
		{
			return;
		}
		CheckAtriumChildrenForRent();
		if (_playerOwned && !GameSettings.Instance.EditMode)
		{
			UpdateTeams(new Team[0]);
			ChangeRole(-1);
			ClearDirt();
		}
		_playerOwned = playerOwned;
		if (!Outdoors)
		{
			InsideMat = InsideMat;
			FloorMat = FloorMat;
		}
		if (!GameSettings.Instance.EditMode && !_playerOwned)
		{
			List<Furniture> list;
			lock (_furnitures)
			{
				list = _furnitures.ToList();
			}
			for (int i = 0; i < list.Count; i++)
			{
				Furniture furniture = list[i];
				if (furniture.InRentMode && !furniture.PlacedInEditMode)
				{
					if (undo != null)
					{
						undo.Add(new UndoObject.UndoAction(furniture, false));
					}
					furniture.DestroyGO();
				}
			}
		}
		_furnitures.ThreadSafeForEach(delegate(Furniture x)
		{
			x.RefreshUsage();
		});
		if (_playerOwned)
		{
			_rentable = true;
		}
		Room room = ParentRoom ?? this;
		if (room == this)
		{
			HashList<Room> childrenRooms = room.ChildrenRooms;
			for (int num = 0; num < childrenRooms.Count; num++)
			{
				childrenRooms[num].SetPlayerOwned(playerOwned, undo);
			}
		}
		else
		{
			room.SetPlayerOwned(playerOwned, undo);
		}
		GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
	}

	private void CheckAtriumChildrenForRent()
	{
		if (!(AtriumParent == this))
		{
			return;
		}
		if (ParentRoom == null || ParentRoom == this)
		{
			ChildrenRooms.AddRange(AtriumChildren);
			AtriumChildren.ForEach(delegate(Room x)
			{
				x.ParentRoom = this;
			});
		}
		else if (ParentRoom != null)
		{
			ParentRoom.ChildrenRooms.AddRange(AtriumChildren);
			AtriumChildren.ForEach(delegate(Room x)
			{
				x.ParentRoom = ParentRoom;
			});
		}
	}

	public override string[] GetActions()
	{
		if (IsUpperAtriumNotBalcony)
		{
			if (!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
			{
				if (Rentable && PlayerOwned)
				{
					return RentableAtriumActions;
				}
				return NonRentable;
			}
			return AtriumActions;
		}
		if (Pillar)
		{
			if (GameSettings.Instance.EditMode)
			{
				return pillarActions;
			}
			if (GameSettings.Instance.RentMode)
			{
				if (Rentable)
				{
					if (!PlayerOwned)
					{
						return pillarNotOwnedActions;
					}
					return pillarRentActions;
				}
				return pillarNotOwnedActions;
			}
			return pillarActions;
		}
		if (GameSettings.Instance.EditMode)
		{
			return EditActions;
		}
		if (GameSettings.Instance.RentMode)
		{
			if (Rentable)
			{
				if (!PlayerOwned)
				{
					return NotOwnedRentableActions;
				}
				return RentableActions;
			}
			return NonRentable;
		}
		return actions;
	}

	public override string GetInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Pillar)
		{
			stringBuilder.AppendLine("Pillar".Loc());
		}
		stringBuilder.AppendLine("Area".Loc() + ": " + Area.ToString("N0") + " ㎡");
		if (Pillar)
		{
			return stringBuilder.ToString();
		}
		if (GameSettings.Instance.RentMode && Rentable)
		{
			stringBuilder.AppendLine("Rent".Loc() + ": " + GetRentPrice().Currency());
		}
		if (RoomGroup != null)
		{
			stringBuilder.AppendLine("Group".Loc() + ": " + RoomGroup);
		}
		if (AuraValues != null)
		{
			for (int i = 0; i < AuraValues.Length; i++)
			{
				if (AuraValues[i] != 0f)
				{
					Furniture.AuraTypes auraTypes = (Furniture.AuraTypes)i;
					stringBuilder.AppendLine(auraTypes.ToString().Loc() + ": " + AuraValues[i].ToPercent(true, true).FontColor((AuraValues[i] > 0f) ? new Color(0f, 0.5f, 0f) : new Color(0.5f, 0f, 0f)));
				}
			}
		}
		if (AwardBuffs != null)
		{
			for (int j = 0; j < AwardBuffs.Length; j++)
			{
				if (AwardBuffs[j] != 0f)
				{
					stringBuilder.AppendLine(string.Concat((AwardTrophy.BuffType)j, "AwardBuff").Loc() + ": " + AwardBuffs[j].ToPercent());
				}
			}
		}
		int count = GetFurniture("Computer").Count;
		if (count > 0)
		{
			stringBuilder.AppendLine("Computer".LocPlural(count));
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public float GetRentPrice()
	{
		if (Pillar)
		{
			return 0f;
		}
		Room room = ParentRoom ?? this;
		float num = BuildController.GetRoomCost(room, false, true);
		for (int i = 0; i < room.ChildrenRooms.Count; i++)
		{
			Room r = room.ChildrenRooms[i];
			num += BuildController.GetRoomCost(r, false, true);
		}
		return num;
	}

	public override string[] GetExtendedInfo()
	{
		if (!IsPlayerControlled() || Pillar)
		{
			return null;
		}
		string[] array = new string[5];
		string teamsString = GetTeamsString();
		RoomLimits forceRole = (RoomLimits)ForceRole;
		array[0] = teamsString + " (" + forceRole.ToString().Loc() + ")";
		array[1] = (string)GetExtendedInfoData(0, 0);
		array[2] = (string)GetExtendedInfoData(1, 0);
		array[3] = (string)GetExtendedInfoData(2, 0);
		array[4] = (string)GetExtendedInfoData(3, 0);
		return array;
	}

	public override string[] GetExtendedIconInfo()
	{
		if (!IsPlayerControlled() || Pillar)
		{
			return null;
		}
		return new string[5]
		{
			"MoreEmployees",
			(string)GetExtendedInfoData(0, 1),
			(string)GetExtendedInfoData(1, 1),
			(string)GetExtendedInfoData(2, 1),
			(string)GetExtendedInfoData(3, 1)
		};
	}

	public override string[] GetExtendedTooltipInfo()
	{
		if (!IsPlayerControlled() || Pillar)
		{
			return null;
		}
		return new string[4]
		{
			(string)GetExtendedInfoData(0, 2),
			(string)GetExtendedInfoData(1, 2),
			(string)GetExtendedInfoData(2, 2),
			(string)GetExtendedInfoData(3, 2)
		};
	}

	public override Color[] GetExtendedColorInfo()
	{
		return new Color[4]
		{
			(Color)GetExtendedInfoData(0, 3),
			(Color)GetExtendedInfoData(1, 3),
			(Color)GetExtendedInfoData(2, 3),
			(Color)GetExtendedInfoData(3, 3)
		};
	}

	private object GetExtendedInfoData(int n, int type)
	{
		int num = -1;
		for (int i = 0; i < 5; i++)
		{
			if (MatchesRank(i) == n)
			{
				num = i;
				break;
			}
		}
		switch (num)
		{
		case 0:
			switch (type)
			{
			case 0:
				return ((1f - DarknessLevel) * 400f).ToString("0") + " lux";
			case 1:
				return "Lightbulb";
			case 2:
				return "Lighting".Loc();
			case 3:
				return GetColorStat((1f - DarknessLevel) * 2f);
			}
			break;
		case 1:
			switch (type)
			{
			case 0:
				return (GetEnvironment() * 100f).ToString("0") + "%";
			case 1:
				return "Painting";
			case 2:
				return "Environment".Loc();
			case 3:
				return GetColorStat(GetEnvironment());
			}
			break;
		case 2:
			switch (type)
			{
			case 0:
				return Temperature.Temperature(false);
			case 1:
				return "Thermometer";
			case 2:
				return "Temperature".Loc();
			case 3:
				return GetColorStat((1f - Mathf.Abs(21f - Temperature) / 24f) * 2f);
			}
			break;
		case 3:
			switch (type)
			{
			case 0:
				return Acoustics.ToPercent(false);
			case 1:
				return "Speaker";
			case 2:
				return "#" + "Acoustics".Loc() + "\n" + "AcousticsDesc".Loc();
			case 3:
				return GetColorStat(Acoustics * 2f);
			}
			break;
		case 4:
			switch (type)
			{
			case 0:
				return (Smell * 1000f).ToString("0") + " ppb";
			case 1:
				return "Air";
			case 2:
				return "#" + "AirQuality".Loc() + "\n" + "AirQualityDesc".Loc();
			case 3:
				return GetColorStat((1f - Smell) * 2f);
			}
			break;
		}
		return null;
	}

	private float GetTempScore()
	{
		return 1f - Mathf.Abs(21f - Temperature) / 24f;
	}

	private int MatchesRank(float statIndex)
	{
		_003C_003Ec__DisplayClass288_0 _003C_003Ec__DisplayClass288_1 = default(_003C_003Ec__DisplayClass288_0);
		_003C_003Ec__DisplayClass288_1.statIndex = statIndex;
		float darknessLevel = DarknessLevel;
		float num = 1f - GetEnvironment();
		float num2 = 1f - GetTempScore();
		float num3 = 0.5f - Acoustics;
		float num4 = Smell - 0.01f;
		_003C_003Ec__DisplayClass288_1.value = ((_003C_003Ec__DisplayClass288_1.statIndex == 0f) ? darknessLevel : ((_003C_003Ec__DisplayClass288_1.statIndex == 1f) ? num : ((_003C_003Ec__DisplayClass288_1.statIndex == 2f) ? num2 : ((_003C_003Ec__DisplayClass288_1.statIndex == 3f) ? num3 : num4))));
		_003C_003Ec__DisplayClass288_1.rank = 0;
		_003CMatchesRank_003Eg__Check_007C288_0(darknessLevel, 0, ref _003C_003Ec__DisplayClass288_1);
		_003CMatchesRank_003Eg__Check_007C288_0(num, 1, ref _003C_003Ec__DisplayClass288_1);
		_003CMatchesRank_003Eg__Check_007C288_0(num2, 2, ref _003C_003Ec__DisplayClass288_1);
		_003CMatchesRank_003Eg__Check_007C288_0(num3, 3, ref _003C_003Ec__DisplayClass288_1);
		_003CMatchesRank_003Eg__Check_007C288_0(num4, 4, ref _003C_003Ec__DisplayClass288_1);
		return _003C_003Ec__DisplayClass288_1.rank;
	}

	public override string[] GetMultiIcon()
	{
		return new string[2] { "Grid", "Computer" };
	}

	public override string[] GetMultiDesc()
	{
		return new string[2]
		{
			"Area".Loc(),
			"Computers".Loc()
		};
	}

	public override string[] GetMultiValue(IEnumerable<Selectable> selected)
	{
		float num = 0f;
		int num2 = 0;
		foreach (Room item in selected.OfType<Room>())
		{
			num += item.Area;
			num2 += item.GetFurniture("Computer").Count;
		}
		return new string[2]
		{
			num.ToString("N0") + " ㎡",
			num2.ToString()
		};
	}

	public void UnGroup()
	{
		Room room = ParentRoom ?? this;
		if (room == this)
		{
			if (AtriumParent == this)
			{
				room.AtriumChildren.ForEach(delegate(Room x)
				{
					x.ParentRoom = null;
					ChildrenRooms.Remove(x);
				});
			}
			if (ChildrenRooms.Count > 0)
			{
				Room room2 = ChildrenRooms[0];
				room2.ParentRoom = room2;
				for (int num = 1; num < ChildrenRooms.Count; num++)
				{
					Room room3 = ChildrenRooms[num];
					room3.ParentRoom = room2;
					room2.ChildrenRooms.Add(room3);
				}
				ChildrenRooms.Clear();
			}
		}
		else
		{
			room.ChildrenRooms.Remove(this);
			room.ChildrenRooms.RemoveRange(AtriumChildren);
		}
		ParentRoom = this;
		CheckAtriumChildrenForRent();
	}

	public void GroupTo(Room parent)
	{
		parent = parent.AtriumParent ?? parent;
		if (IsUpperAtriumNotBalcony)
		{
			AtriumParent.GroupTo(parent);
			return;
		}
		UnGroup();
		Rentable = parent.Rentable;
		SetPlayerOwned(parent.PlayerOwned, null);
		ParentRoom = parent;
		if (!(parent != this))
		{
			return;
		}
		parent.ChildrenRooms.Add(this);
		if (AtriumParent == this)
		{
			ChildrenRooms.RemoveRange(AtriumChildren);
			parent.ChildrenRooms.AddRange(AtriumChildren);
			AtriumChildren.ForEach(delegate(Room x)
			{
				x.ParentRoom = parent;
			});
		}
	}

	public override IEnumerable<Selectable> GetRelated()
	{
		if (GameSettings.Instance.EditMode)
		{
			Room p = ParentRoom ?? this;
			yield return p;
			for (int i = 0; i < p.ChildrenRooms.Count; i++)
			{
				yield return p.ChildrenRooms[i];
			}
		}
		if (!(AtriumParent == this))
		{
			yield break;
		}
		foreach (Room atriumChild in GetAtriumChildren())
		{
			yield return atriumChild;
		}
	}

	public override string GetPanelActionName()
	{
		if (!GameSettings.Instance.HasDanger())
		{
			if (IsPlayerControlled() && !IsOnFire && Burn > 0f)
			{
				return "Repair";
			}
			if (_destructionUndo.Count > 0)
			{
				return "RestoreFurniture";
			}
			if (!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode && Rentable)
			{
				if (!PlayerOwned)
				{
					return "Lease";
				}
				return "Cancel lease";
			}
		}
		return null;
	}

	public override string GetPanelActionTip(ref float sum)
	{
		if (IsPlayerControlled() && !IsOnFire && Burn > 0f)
		{
			sum -= GetFireRepairCost();
			return sum.Currency();
		}
		if (_destructionUndo.Count > 0)
		{
			sum -= GetRestoreFurnitureCost();
			return sum.Currency();
		}
		if (!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode && Rentable && PlayerOwned)
		{
			return "TerminateLeaseWarning".Loc();
		}
		return null;
	}

	public void RepairFireDamage()
	{
		Burn = 0f;
		InsideColor = InsideColor.Alpha(1f);
		OutsideColor = OutsideColor.Alpha(1f);
		FloorColor = FloorColor.Alpha(1f);
	}

	private UndoObject.UndoAction[] FixDestructionUndo()
	{
		HashSet<uint> hashSet = new HashSet<uint>();
		for (int i = 0; i < _destructionUndo.Count; i++)
		{
			UndoObject.UndoAction undoAction = _destructionUndo[i];
			WriteDictionary val;
			uint val2;
			if (undoAction.Type == UndoObject.UndoAction.ActionType.CreateFurniture && undoAction.Dictionary.TryGet<WriteDictionary>("Furn", out val) && val.TryGet<uint>("WriteID", out val2) && !hashSet.Add(val2))
			{
				_destructionUndo.RemoveAt(i);
				i--;
			}
		}
		UndoObject.UndoAction[] array = new UndoObject.UndoAction[_destructionUndo.Count];
		int cur = 0;
		for (int j = 0; j < _destructionUndo.Count; j++)
		{
			UndoObject.UndoAction undoAction2 = _destructionUndo[j];
			CheckDeps(_destructionUndo, array, j, ref cur);
			array[cur] = undoAction2;
			cur++;
		}
		_hasCachedDestructionCost = false;
		return array;
	}

	public static void CheckDeps(List<UndoObject.UndoAction> d, UndoObject.UndoAction[] res, int idx, ref int cur)
	{
		uint num = d[idx].Get<WriteDictionary>("Furn").Get("SnapPoint", 0u);
		if (num == 0)
		{
			return;
		}
		for (int i = idx + 1; i < d.Count; i++)
		{
			UndoObject.UndoAction undoAction = d[i];
			uint dID = GetDID(undoAction);
			if (num == dID)
			{
				CheckDeps(d, res, i, ref cur);
				res[cur] = undoAction;
				cur++;
				d.RemoveAt(i);
				break;
			}
		}
	}

	private static uint GetDID(UndoObject.UndoAction a)
	{
		return a.Get<WriteDictionary>("Furn").Get("WriteID", 0u);
	}

	public float GetFireRepairCost()
	{
		return BuildController.GetRoomCost(this, false, false) * Mathf.Min(Burn, 1f);
	}

	public override void InvokePanelAction(List<UndoObject.UndoAction> undos)
	{
		if (GameSettings.Instance.HasDanger())
		{
			return;
		}
		if (IsPlayerControlled() && !IsOnFire && Burn > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - GetFireRepairCost(), Company.TransactionCategory.Construction, true);
			RepairFireDamage();
			BuildController.Instance.RefreshRestoreButton();
		}
		else if (_destructionUndo.Count > 0)
		{
			RestoreFurniture();
			UISoundFX.PlaySFX("Kaching");
			BuildController.Instance.RefreshRestoreButton();
		}
		else
		{
			if (!GameSettings.Instance.RentMode || !Rentable)
			{
				return;
			}
			if (!PlayerOwned)
			{
				float rentPrice = GetRentPrice();
				if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - rentPrice))
				{
					GameSettings.Instance.MyCompany.MakeTransaction(0f - rentPrice, Company.TransactionCategory.Bills, true, "Rent");
					UISoundFX.PlaySFX("Kaching");
					undos.Add(new UndoObject.UndoAction(this, PlayerOwned));
					SetPlayerOwned(true, undos);
					GameSettings.Instance.DirtyRentGrid.Add(Floor);
					Furniture.UpdateEdgeDetection();
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), false, DialogWindow.DialogType.Error);
				}
			}
			else
			{
				undos.Add(new UndoObject.UndoAction(this, PlayerOwned));
				SetPlayerOwned(false, undos);
				GameSettings.Instance.DirtyRentGrid.Add(Floor);
				Furniture.UpdateEdgeDetection();
			}
		}
	}

	public override Selectable PanelActionDivert()
	{
		if (!GameSettings.Instance.HasDanger() && ((IsPlayerControlled() && !IsOnFire && Burn > 0f) || _destructionUndo.Count > 0))
		{
			return this;
		}
		return ParentRoom ?? this;
	}

	public float GetAuraValue(Furniture.AuraTypes type)
	{
		if (AuraValues == null || (int)type >= AuraValues.Length)
		{
			return 1f;
		}
		return 1f + AuraValues[(int)type];
	}

	public float GetAwardValue(AwardTrophy.BuffType type)
	{
		if (AwardBuffs == null || (int)type >= AwardBuffs.Length)
		{
			return 0f;
		}
		return AwardBuffs[(int)type];
	}

	public override string Description()
	{
		return "Rooms";
	}

	public void UpdateTeams(IEnumerable<Team> newTeam)
	{
		Teams.Clear();
		Teams.AddRange(newTeam);
		DirtyTeamNames = true;
		GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
	}

	public void AddTeam(Team newTeam)
	{
		Teams.Add(newTeam);
		DirtyTeamNames = true;
		GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
	}

	private void UpdateTeamText()
	{
		TeamText.tm.text = GetTeamsString();
		GetActuallyAllowed();
		TeamText.InUse = TeamText.tm.text != "";
	}

	public string GetTeamsString()
	{
		HashSet<Team> allowed = GetActuallyAllowed();
		if (Teams.Count == 0)
		{
			return "";
		}
		Team team = null;
		if (allowed != null && allowed.Count < GameSettings.Instance.sActorManager.Teams.Count)
		{
			team = Teams.FirstOrDefault((Team x) => !allowed.Contains(x));
		}
		if (team != null)
		{
			return team.Name.FontColor(Color.red) + ((Teams.Count > 1) ? ("+" + (Teams.Count - 1)) : "");
		}
		return Teams.First().Name + ((Teams.Count > 1) ? ("+" + (Teams.Count - 1)) : "");
	}

	public bool CompatibleWithTeam(Team team)
	{
		HashSet<Team> actuallyAllowed = GetActuallyAllowed();
		if (team != null && actuallyAllowed != null)
		{
			return actuallyAllowed.Contains(team);
		}
		if (actuallyAllowed != null)
		{
			return actuallyAllowed.Count > 0;
		}
		if (Teams.Count != 0)
		{
			if (team != null)
			{
				return Teams.Contains(team);
			}
			return false;
		}
		return true;
	}

	public bool ToiletInUse()
	{
		return AnyInUse("Toilet");
	}

	public bool AnyInUse(string type)
	{
		HashList<Furniture> furniture = GetFurniture(type);
		for (int i = 0; i < furniture.Count; i++)
		{
			if (furniture[i].InteractionPoints[0].UsedBy != null)
			{
				return true;
			}
		}
		return false;
	}

	private void RecalculateTableGroupsInner()
	{
		DirtyTableGroups = false;
		TableParents.Clear();
		lock (_furnitures)
		{
			_tableGroupCache.AddRange(_furnitures.Where((Furniture x) => x != null && x.gameObject != null && x.Table != null && x.UsableForTableGroup()));
		}
		List<List<Furniture>> list = _tableGroupCache.SimpleClustering((Furniture x, Furniture y) => (x.transform.position - y.transform.position).magnitude, 3f);
		_tableGroupCache.Clear();
		for (int num = 0; num < list.Count; num++)
		{
			TableScript component = list[num][0].GetComponent<TableScript>();
			TableParents.Add(component);
			component.Parent = component;
			component.Children.Clear();
			for (int num2 = 1; num2 < list[num].Count; num2++)
			{
				TableScript component2 = list[num][num2].GetComponent<TableScript>();
				component2.Parent = component;
				component2.Children.Clear();
				component.Children.Add(component2);
			}
		}
		_furnitures.ThreadSafeForEach(delegate(Furniture item)
		{
			if (item.IsAliveNotNull() && item.Table != null && !item.UsableForTableGroup())
			{
				item.Table.Parent = item.Table;
				item.Table.Children.Clear();
				item.Table.UpdateStatus(true);
			}
		});
		for (int num3 = 0; num3 < TableParents.Count; num3++)
		{
			TableParents[num3].UpdateStatus(true);
		}
	}

	public void RecalculateTableGroups()
	{
		DirtyTableGroups = true;
	}

	public void RecalculateTableGroupsNow()
	{
		RecalculateTableGroupsInner();
	}

	public void RemoveTable(TableScript table)
	{
		RecalculateTableGroups();
	}

	public void AddTable(Vector2 p, TableScript table)
	{
		RecalculateTableGroups();
	}

	public void RecalculateStateVariables(bool refreshNeighbours = false)
	{
		Room obj = AtriumParent ?? this;
		obj.DirtyStateVariables = true;
		obj.stateRefreshNeighbours |= refreshNeighbours;
	}

	public static float GetOutdoorNoise(Vector3 pos)
	{
		if (!(pos.y < 0f))
		{
			return GameSettings.Instance.Environment.BackgroundNoise / (1f + pos.y);
		}
		return 0f;
	}

	private void CalculateNoisePropagation()
	{
		NoisePropagation.Clear();
		WallArea = 0f;
		if (Outdoors || Dummy)
		{
			WallArea = 1f;
			return;
		}
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			WallEdge wallEdge2 = Edges[(i + 1) % Edges.Count];
			float num = (wallEdge.Pos - wallEdge2.Pos).magnitude * 2f;
			WallArea += num;
			float num2 = num * 0.1f;
			Room key = GameSettings.Instance.sRoomManager.Outside;
			foreach (KeyValuePair<IRoom, WallEdge> link in wallEdge2.Links)
			{
				if (link.Value == wallEdge)
				{
					Room room;
					if (!link.Key.Outdoors && (object)(room = link.Key as Room) != null)
					{
						key = room;
					}
					break;
				}
			}
			HashSet<WallSnap> value;
			if (wallEdge.Children.TryGetValue(wallEdge2, out value))
			{
				foreach (WallSnap item in value)
				{
					RoomSegment roomSegment = item as RoomSegment;
					if (roomSegment != null)
					{
						num2 += roomSegment.WallWidth * (roomSegment.Height2 - roomSegment.Height1) * roomSegment.NoiseFactor;
					}
				}
			}
			NoisePropagation.AddUp(key, num2);
		}
	}

	public void UpdateAwardValues()
	{
		HashList<Furniture> furniture = GetFurniture("Award");
		if (furniture.Count > 0)
		{
			AwardBuffs = new float[4];
			for (int i = 0; i < furniture.Count; i++)
			{
				AwardTrophy component = furniture[i].GetComponent<AwardTrophy>();
				int type = (int)component.Type;
				AwardBuffs[type] = Mathf.Max(AwardBuffs[type], component.GetEffectiveness());
			}
		}
		else
		{
			AwardBuffs = null;
		}
	}

	private void GetConnections()
	{
		if (Outdoors || Outside || Pillar)
		{
			return;
		}
		foreach (Furniture item in GetFurniture("Stairs"))
		{
			Room parentRoom = item.GetParentRoom(false);
			if (parentRoom != null && parentRoom != this)
			{
				_roomConnectionCache.AddUp(parentRoom.GetMainAtriumParentOrSelf(), 2f);
				continue;
			}
			parentRoom = item.GetParentRoom(true);
			if (parentRoom != null && parentRoom != this)
			{
				_roomConnectionCache.AddUp(parentRoom.GetMainAtriumParentOrSelf(), 2f);
			}
		}
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			WallEdge wallEdge2 = Edges[(i + 1) % Edges.Count];
			Room room = null;
			HashSet<WallSnap> value;
			if (!wallEdge.Children.TryGetValue(wallEdge2, out value))
			{
				continue;
			}
			foreach (WallSnap item2 in value)
			{
				if (!(item2.Permeability > 0f))
				{
					continue;
				}
				if (room.IsReferenceNull())
				{
					room = wallEdge2.GetRoom(wallEdge);
					room = ((room != null) ? room.GetMainAtriumParentOrSelf() : GameSettings.Instance.sRoomManager.Outside);
					if (room.Pillar)
					{
						break;
					}
				}
				_roomConnectionCache.AddUp(room, item2.WallWidth * item2.Permeability);
			}
		}
	}

	private void innerRecalculateStateVariables(bool refreshNeighbours)
	{
		if (GameSettings.Instance.sRoomManager.DisableMeshRebuild)
		{
			return;
		}
		DirtyStateVariables = false;
		stateRefreshNeighbours = false;
		if (AtriumParent != null && AtriumParent != this)
		{
			Room mainAtriumParent = GetMainAtriumParent();
			mainAtriumParent.DirtyStateVariables = true;
			mainAtriumParent.stateRefreshNeighbours = refreshNeighbours;
			return;
		}
		float atriumArea = GetAtriumArea();
		if (Outdoors)
		{
			Acoustics = 1f;
			WindowDarkLevel = 1f;
			WindowDarkLevelNoCap = 1f;
			if (_furnitures.Count > 0)
			{
				float result = 1.5f;
				_furnitures.ThreadSafeForEach(delegate(Furniture furniture3)
				{
					if (!furniture3.IsReversed)
					{
						result *= furniture3.Environment;
					}
				});
				FurnEnvironment = result;
			}
			else
			{
				FurnEnvironment = 1.5f;
			}
			if (refreshNeighbours)
			{
				GameSettings.Instance.sRoomManager.PropagateLighting(this);
			}
			return;
		}
		lock (_furnitures)
		{
			_furnitures.RemoveAll((Furniture x) => x == null);
		}
		FurnitureTypes.ForEachEnum(delegate(KeyValuePair<string, HashList<Furniture>> x)
		{
			x.Value.RemoveAll((Furniture y) => y == null);
		});
		_furnCache.Clear();
		_furnCache.AddRange(_furnitures);
		_roomConnectionCache.Clear();
		GetConnections();
		foreach (Room atriumChild in GetAtriumChildren())
		{
			lock (atriumChild._furnitures)
			{
				atriumChild._furnitures.RemoveAll((Furniture x) => x == null);
			}
			atriumChild.FurnitureTypes.ForEachEnum(delegate(KeyValuePair<string, HashList<Furniture>> x)
			{
				x.Value.RemoveAll((Furniture y) => y == null);
			});
			_furnCache.AddRange(atriumChild._furnitures);
			atriumChild.GetConnections();
		}
		_roomConnectionCache.Remove(this);
		RoomConnections.Clear();
		RoomConnections.AddRange(_roomConnectionCache.Select([return: TupleElementNames(new string[] { "Key", "Value" })] (KeyValuePair<Room, float> x) => new ValueTuple<Room, float>(x.Key, x.Value)));
		_roomConnectionCache.Clear();
		UpdateAwardValues();
		if (AuraValues == null || AuraValues.Length != 3)
		{
			AuraValues = new float[3];
		}
		for (int num = 0; num < 3; num++)
		{
			AuraValues[num] = 0f;
		}
		AirCleansing = 0f;
		_cacheAuraCap[0, 0] = 0f;
		_cacheAuraCap[0, 1] = 0f;
		_cacheAuraCap[1, 0] = 0f;
		_cacheAuraCap[1, 1] = 0f;
		_cacheAuraCap[2, 0] = 0f;
		_cacheAuraCap[2, 1] = 0f;
		for (int num2 = 0; num2 < _furnCache.Count; num2++)
		{
			Furniture furniture = _furnCache[num2];
			if (!furniture.TemperatureOutput || furniture.PlacedInEditMode || furniture.TempGroup != null)
			{
				AirCleansing += furniture.AirCleaning;
			}
			if (furniture.IsReversed || (furniture.HasUpg && furniture.upg.Broken) || furniture.CapAura)
			{
				continue;
			}
			for (int num3 = 0; num3 < 3; num3++)
			{
				if (furniture.AuraValues == null)
				{
					break;
				}
				if (furniture.AuraValues.Length <= num3)
				{
					break;
				}
				if (!(furniture.AuraValues[num3] <= -1f) && furniture.AuraValues[num3] != 0f)
				{
					if (furniture.AuraValues[num3] < 0f)
					{
						_cacheAuraCap[num3, 0] = -0.25f;
					}
					else
					{
						_cacheAuraCap[num3, 1] = 0.25f;
					}
					float num4 = Mathf.Max(1f, atriumArea / Mathf.Max(1f, furniture.AuraCoverage));
					AuraValues[num3] += furniture.AuraValues[num3] / num4;
				}
			}
		}
		for (int num5 = 0; num5 < _furnCache.Count; num5++)
		{
			Furniture furniture2 = _furnCache[num5];
			if (furniture2.IsReversed || (furniture2.HasUpg && furniture2.upg.Broken) || !furniture2.CapAura)
			{
				continue;
			}
			for (int num6 = 0; num6 < 3; num6++)
			{
				if (furniture2.AuraValues == null)
				{
					break;
				}
				if (furniture2.AuraValues.Length <= num6)
				{
					break;
				}
				if (!(furniture2.AuraValues[num6] <= -1f) && furniture2.AuraValues[num6] != 0f)
				{
					if (furniture2.AuraValues[num6] < 0f)
					{
						_cacheAuraCap[num6, 0] = Mathf.Min(_cacheAuraCap[num6, 0], furniture2.AuraValues[num6]);
					}
					else
					{
						_cacheAuraCap[num6, 1] = Mathf.Max(_cacheAuraCap[num6, 1], furniture2.AuraValues[num6]);
					}
					float num7 = Mathf.Max(1f, atriumArea / Mathf.Max(1f, furniture2.AuraCoverage));
					AuraValues[num6] += furniture2.AuraValues[num6] / num7;
				}
			}
		}
		for (int num8 = 0; num8 < 3; num8++)
		{
			AuraValues[num8] = Mathf.Clamp(AuraValues[num8], Mathf.Max(-0.25f, _cacheAuraCap[num8, 0]), Mathf.Min(0.25f, _cacheAuraCap[num8, 1]));
		}
		Lamps.Clear();
		Lamps.AddRange(_furnCache.Where((Furniture x) => x != null && !x.IsReversed && x.Lighting > 0f));
		List<WallSnap> wallSnaps = GetWallSnaps();
		float num9 = 0f;
		foreach (Room atriumChild2 in GetAtriumChildren())
		{
			if (atriumChild2.IsBalcony)
			{
				num9 += atriumChild2.Area;
			}
			atriumChild2.GetWallSnaps(null, wallSnaps);
		}
		float num10 = 0f;
		if (Floor >= 0)
		{
			for (int num11 = 0; num11 < wallSnaps.Count; num11++)
			{
				WallSnap wallSnap = wallSnaps[num11];
				if (wallSnap != null && wallSnap.TowardsOutside())
				{
					num10 += wallSnap.LightAddition;
				}
			}
		}
		WindowDarkLevelNoCap = num10 / (atriumArea / 4f);
		WindowDarkLevel = Mathf.Min(1f, WindowDarkLevelNoCap * 4f);
		if (_furnCache.Count > 0)
		{
			float num12 = 1f;
			for (int num13 = 0; num13 < _furnCache.Count; num13++)
			{
				if (!_furnCache[num13].IsReversed)
				{
					num12 *= _furnCache[num13].Environment;
				}
			}
			FurnEnvironment = num12;
		}
		else
		{
			FurnEnvironment = 1f;
		}
		FurnEnvironment *= Mathf.Min(2f, 1f + WindowDarkLevelNoCap / 4f * GameSettings.Instance.Environment.BackgroundBeauty);
		float num14 = Mathf.Clamp01(atriumArea / ((float)Math.PI * RoomBounds.width * RoomBounds.height * 0.25f));
		Acoustics = Mathf.Clamp01((num9 * 2.5f + _furnCache.SumSafe((Furniture x) => (!x.IsReversed) ? x.AcousticDampening : 0f)) / (atriumArea * 1.2f * num14));
		foreach (Room atriumChild3 in GetAtriumChildren())
		{
			atriumChild3.WindowDarkLevelNoCap = WindowDarkLevelNoCap;
			atriumChild3.WindowDarkLevel = WindowDarkLevel;
			atriumChild3.Acoustics = Acoustics;
			atriumChild3.FurnEnvironment = FurnEnvironment;
		}
		if (refreshNeighbours)
		{
			GameSettings.Instance.sRoomManager.PropagateLighting(this);
		}
	}

	public int GetMissingAcousticElements(float acousticDampening)
	{
		float atriumArea = GetAtriumArea();
		float num = Mathf.Clamp01(GetAtriumArea() / ((float)Math.PI * RoomBounds.width * RoomBounds.height * 0.25f));
		float num2 = atriumArea * 1.2f * num;
		return Mathf.CeilToInt((1f - Acoustics) * num2 / acousticDampening);
	}

	public List<WallSnap> GetWallSnaps(HashSet<Room> destroy = null, List<WallSnap> existing = null)
	{
		HashSet<WallSnap> hashSet = new HashSet<WallSnap>();
		if (Dummy)
		{
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(0))
			{
				foreach (KeyValuePair<WallEdge, HashSet<WallSnap>> child in item.Children)
				{
					if (!item.Links.ContainsValue(child.Key))
					{
						hashSet.AddRange(child.Value);
					}
				}
			}
		}
		else
		{
			if (Edges == null || Edges.Count == 0)
			{
				return new List<WallSnap>();
			}
			WallEdge wallEdge = Edges[0];
			WallEdge wallEdge2 = wallEdge;
			int num = 0;
			do
			{
				WallEdge value;
				if (!wallEdge.Links.TryGetValue(this, out value))
				{
					if (!TryFixEdges())
					{
						return new List<WallSnap>();
					}
					if (!wallEdge.Links.TryGetValue(this, out value))
					{
						return new List<WallSnap>();
					}
				}
				HashSet<WallSnap> value2;
				if (wallEdge.Children.TryGetValue(value, out value2))
				{
					if (destroy != null)
					{
						foreach (WallSnap item2 in value2)
						{
							Room room = value.GetRoom(wallEdge);
							if (room == null || destroy.Contains(room) || !item2.ValidSnap(false, destroy))
							{
								hashSet.Add(item2);
							}
						}
					}
					else
					{
						hashSet.AddRange(value2);
					}
				}
				wallEdge = value;
				num++;
				if (num > Edges.Count * 2)
				{
					if (destroy != null)
					{
						destroy.Clear();
					}
					return BrokenWhileLoop(() => GetWallSnaps(destroy), new List<WallSnap>());
				}
			}
			while (wallEdge != wallEdge2);
		}
		if (existing != null)
		{
			existing.AddRange(hashSet);
			return existing;
		}
		return hashSet.ToList();
	}

	public IEnumerable<RoomSegment> GetSegmentsMainThreadNotOutside()
	{
		if (Edges == null || Edges.Count == 0)
		{
			yield break;
		}
		WallEdge wallEdge = Edges[0];
		WallEdge breaker = wallEdge;
		int i = 0;
		WallEdge next;
		while (wallEdge.Links.TryGetValue(this, out next))
		{
			HashSet<WallSnap> value;
			if (wallEdge.Children.TryGetValue(next, out value))
			{
				foreach (RoomSegment item in value.OfType<RoomSegment>())
				{
					yield return item;
				}
			}
			wallEdge = next;
			i++;
			if (i <= Edges.Count * 2)
			{
				next = null;
				if (wallEdge == breaker)
				{
					break;
				}
				continue;
			}
			break;
		}
	}

	public List<WallSnap> GetSegmentsGeneric(List<WallSnap> output, HashSet<Room> destroy = null)
	{
		HashSet<WallSnap> hashSet = new HashSet<WallSnap>();
		if (Dummy)
		{
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(0))
			{
				foreach (KeyValuePair<WallEdge, HashSet<WallSnap>> child in item.Children)
				{
					if (!item.Links.ContainsValue(child.Key))
					{
						hashSet.AddRange(child.Value.OfType<RoomSegment>());
					}
				}
			}
		}
		else
		{
			if (Edges == null || Edges.Count == 0)
			{
				return output;
			}
			WallEdge wallEdge = Edges[0];
			WallEdge wallEdge2 = wallEdge;
			int num = 0;
			do
			{
				WallEdge value;
				if (!wallEdge.Links.TryGetValue(this, out value))
				{
					if (!TryFixEdges())
					{
						return output;
					}
					if (!wallEdge.Links.TryGetValue(this, out value))
					{
						return output;
					}
				}
				HashSet<WallSnap> value2;
				if (wallEdge.Children.TryGetValue(value, out value2))
				{
					if (destroy != null)
					{
						foreach (RoomSegment item2 in value2.OfType<RoomSegment>())
						{
							Room room = value.GetRoom(wallEdge);
							if (room == null || destroy.Contains(room) || !item2.ValidSnap(false, destroy))
							{
								hashSet.Add(item2);
							}
						}
					}
					else
					{
						hashSet.AddRange(value2.OfType<RoomSegment>());
					}
				}
				wallEdge = value;
				num++;
				if (num > Edges.Count * 2)
				{
					if (destroy != null)
					{
						destroy.Clear();
					}
					return BrokenWhileLoop(() => GetSegmentsGeneric(output, destroy), output);
				}
			}
			while (wallEdge != wallEdge2);
		}
		output.AddRange(hashSet);
		return output;
	}

	public List<RoomSegment> GetSegments(HashSet<Room> destroy = null)
	{
		HashSet<RoomSegment> hashSet = new HashSet<RoomSegment>();
		if (Dummy)
		{
			foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(0))
			{
				foreach (KeyValuePair<WallEdge, HashSet<WallSnap>> child in item.Children)
				{
					if (!item.Links.ContainsValue(child.Key))
					{
						hashSet.AddRange(child.Value.OfType<RoomSegment>());
					}
				}
			}
		}
		else
		{
			if (Edges == null || Edges.Count == 0)
			{
				return new List<RoomSegment>();
			}
			WallEdge wallEdge = Edges[0];
			WallEdge wallEdge2 = wallEdge;
			int num = 0;
			do
			{
				WallEdge value;
				if (!wallEdge.Links.TryGetValue(this, out value))
				{
					if (!TryFixEdges())
					{
						return new List<RoomSegment>();
					}
					if (!wallEdge.Links.TryGetValue(this, out value))
					{
						return new List<RoomSegment>();
					}
				}
				HashSet<WallSnap> value2;
				if (wallEdge.Children.TryGetValue(value, out value2))
				{
					if (destroy != null)
					{
						foreach (RoomSegment item2 in value2.OfType<RoomSegment>())
						{
							Room room = value.GetRoom(wallEdge);
							if (room == null || destroy.Contains(room) || !item2.ValidSnap(false, destroy))
							{
								hashSet.Add(item2);
							}
						}
					}
					else
					{
						hashSet.AddRange(value2.OfType<RoomSegment>());
					}
				}
				wallEdge = value;
				num++;
				if (num > Edges.Count * 2)
				{
					if (destroy != null)
					{
						destroy.Clear();
					}
					return BrokenWhileLoop(() => GetSegments(destroy), new List<RoomSegment>());
				}
			}
			while (wallEdge != wallEdge2);
		}
		return hashSet.ToList();
	}

	private float GetFurnTempPower(Furniture furn)
	{
		if (!furn.HasUpg)
		{
			return 1f;
		}
		return furn.upg.Quality.MapRange(0f, 0.5f, 0f, 1f, true);
	}

	public void MakeTemperatureDirty(bool instantly)
	{
		_lastTempValueUpdate = (instantly ? (-1f) : (Time.realtimeSinceStartup - 9.75f));
	}

	private void CalculateInsulation()
	{
		if (Outdoors)
		{
			Insulation = 2f;
			return;
		}
		if (Floor < 0)
		{
			Insulation = 0.5f;
			TemperatureGroup tempGroup = TempGroup;
			if (tempGroup != null)
			{
				tempGroup.RefreshTemperatureValues();
			}
			return;
		}
		if (AtriumParent != null && AtriumParent != this)
		{
			AtriumParent.CalculateInsulation();
			return;
		}
		float totalDist = 0f;
		float insDist = 0f;
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge e = Edges[i];
			WallEdge e2 = Edges[(i + 1) % Edges.Count];
			SubInsulation(e, e2, ref totalDist, ref insDist);
		}
		foreach (Room atriumChild in GetAtriumChildren())
		{
			for (int j = 0; j < atriumChild.Edges.Count; j++)
			{
				WallEdge wallEdge = atriumChild.Edges[j];
				if (!wallEdge.IsBalconyWall(atriumChild))
				{
					WallEdge e3 = atriumChild.Edges[(j + 1) % atriumChild.Edges.Count];
					SubInsulation(wallEdge, e3, ref totalDist, ref insDist);
				}
			}
		}
		Insulation = insDist / totalDist;
		foreach (Room atriumChild2 in GetAtriumChildren())
		{
			atriumChild2.Insulation = Insulation;
		}
		TemperatureGroup tempGroup2 = TempGroup;
		if (tempGroup2 != null)
		{
			tempGroup2.RefreshTemperatureValues();
		}
	}

	private void SubInsulation(WallEdge e1, WallEdge e2, ref float totalDist, ref float insDist)
	{
		float magnitude = (e2.Pos - e1.Pos).magnitude;
		totalDist += magnitude;
		Room room = e2.GetRoom(e1);
		if (room != null && !room.Outdoors)
		{
			insDist += magnitude * 0.5f;
			return;
		}
		float num = 0f;
		HashSet<WallSnap> value;
		if (e1.Children.TryGetValue(e2, out value))
		{
			foreach (WallSnap item in value)
			{
				num += item.LightAddition;
			}
		}
		insDist += magnitude + num;
	}

	public void UpdateTemperatureValues()
	{
		_coolingControlArea = 0f;
		_coolingDirectArea = 0f;
		_heatingControlArea = 0f;
		_heatingDirectArea = 0f;
		TheoCoolingControlArea = 0f;
		TheoHeatingControlArea = 0f;
		_serverTemp = 0f;
		_noThermoArea = 0f;
		_lastTempValueUpdate = Time.realtimeSinceStartup;
		if (Outdoors || (AtriumParent != null && AtriumParent != this))
		{
			return;
		}
		if (AtriumParent == this)
		{
			foreach (Room item in GetAtriumChildrenAndSelf())
			{
				lock (item._furnitures)
				{
					int count = item._furnitures.Count;
					for (int i = 0; i < count; i++)
					{
						UpdateTemperatureFurniture(item._furnitures[i]);
					}
				}
			}
		}
		else
		{
			lock (_furnitures)
			{
				int count2 = _furnitures.Count;
				for (int j = 0; j < count2; j++)
				{
					UpdateTemperatureFurniture(_furnitures[j]);
				}
			}
		}
		UpdateTemperature(false);
	}

	private void UpdateTemperatureFurniture(Furniture furn)
	{
		if (!furn.IsAliveNotNull() || furn.TemperatureController)
		{
			return;
		}
		if (furn.TempControlType != Furniture.TemperatureType.None)
		{
			if (!furn.EqualizeTemperature)
			{
				_noThermoArea += furn.HeatCoolArea * GetFurnTempPower(furn);
			}
			else
			{
				if (GameSettings.Instance.RentMode)
				{
					return;
				}
				if (furn.TempControlType == Furniture.TemperatureType.Cooling)
				{
					float tempArea = furn.GetTempArea();
					TheoCoolingControlArea += tempArea;
					if (furn.IsOn)
					{
						if (furn.TemperatureOutput)
						{
							_coolingControlArea += tempArea * GetFurnTempPower(furn);
						}
						else
						{
							_coolingDirectArea += tempArea * GetFurnTempPower(furn);
						}
					}
					return;
				}
				float tempArea2 = furn.GetTempArea();
				TheoHeatingControlArea += tempArea2;
				if (furn.IsOn)
				{
					if (furn.TemperatureOutput)
					{
						_heatingControlArea += tempArea2 * GetFurnTempPower(furn);
					}
					else
					{
						_heatingDirectArea += tempArea2 * GetFurnTempPower(furn);
					}
				}
			}
		}
		else if (furn.Type.Equals("Server") && furn.IsOn)
		{
			Server component = furn.GetComponent<Server>();
			_serverTemp += component.Power.MapRange(50f, 10000f, 60f, 100f) * (1f - component.GetGroupAvailable()).MapRange(0f, 1f, 0.25f, 1f) / GetAtriumArea();
		}
	}

	public void ResetTempUsage()
	{
		TempHeatDirectUsage = 0f;
		TempCoolDirectUsage = 0f;
		TempHeatControlUsage = 0f;
		TempCoolControlUsage = 0f;
	}

	public void UpdateTemperature(bool withCost)
	{
		if (Outdoors)
		{
			Temperature = TimeOfDay.Instance.Temperature;
			return;
		}
		if (AtriumParent != null && AtriumParent != this)
		{
			Temperature = AtriumParent.Temperature;
			return;
		}
		Temperature = (GameSettings.Instance.RentMode ? (21f + _serverTemp) : (((Floor == -1) ? 5f : TimeOfDay.Instance.Temperature) + _serverTemp));
		if (!GameSettings.Instance.RentMode)
		{
			bool flag = Temperature > 21f;
			float num = GetAtriumArea() * Insulation * TemperatureAreaScale(Temperature);
			float num2 = (flag ? (_coolingControlArea + _coolingDirectArea) : (_heatingControlArea + _heatingDirectArea));
			if (num2 > 0f)
			{
				float t = num2 / num;
				if (flag)
				{
					if (withCost)
					{
						UpdateUsage(_coolingControlArea, _coolingDirectArea, num, ref TempCoolControlUsage);
						UpdateUsage(_coolingDirectArea, _coolingControlArea, num, ref TempCoolDirectUsage);
					}
					Temperature = Mathf.Lerp(Temperature, 21f, t);
				}
				else
				{
					if (withCost)
					{
						UpdateUsage(_heatingControlArea, _heatingDirectArea, num, ref TempHeatControlUsage);
						UpdateUsage(_heatingDirectArea, _heatingControlArea, num, ref TempHeatDirectUsage);
					}
					Temperature = Mathf.Lerp(Temperature, 21f, t);
				}
			}
		}
		if (_noThermoArea > 0f)
		{
			float num3 = _noThermoArea / (GetAtriumArea() * TemperatureAreaScale(Temperature, true)) * 10f;
			if (Temperature > -10f)
			{
				Temperature = Mathf.Max(-10f, Temperature - num3);
			}
		}
		if (IsOnFire)
		{
			Temperature = Mathf.Lerp(Temperature, 100f, Burn / 3f);
		}
	}

	private void UpdateUsage(float area, float otherArea, float roomArea, ref float output)
	{
		if (area > 0f)
		{
			float num = area / (roomArea * (area / (area + otherArea)));
			num = ((num < 1f) ? 1f : (1f / num));
			output = num;
		}
	}

	public void UpdateColors()
	{
		bool dataOverlayMode = DataOverlayMode;
		if (((GameSettings.Instance.ActiveFloor < 0 && Floor < 0) || (GameSettings.Instance.ActiveFloor >= 0 && Floor <= GameSettings.Instance.ActiveFloor)) && DataOverlay.HasActive)
		{
			if (_dataBlock == null)
			{
				_dataBlock = new MaterialPropertyBlock();
			}
			_dataBlock.SetColor("_DataColor", (DataOverlay.Instance.ActiveOverlay.Func == null) ? Color.white : DataOverlay.Instance.ActiveOverlay.Func(IsUpperAtriumNotBalcony ? AtriumParent : this));
			if (Roof != null)
			{
				Roof.GetComponent<MeshRenderer>().SetPropertyBlock(_dataBlock);
			}
			if (FloorMesh != null)
			{
				FloorMesh.GetComponent<MeshRenderer>().SetPropertyBlock(_dataBlock);
			}
			if (InnerWalls != null)
			{
				InnerWalls.GetComponent<MeshRenderer>().SetPropertyBlock(_dataBlock);
			}
			if (OuterWalls != null)
			{
				OuterWalls.GetComponent<MeshRenderer>().SetPropertyBlock(_dataBlock);
			}
			DataOverlayMode = true;
		}
		else
		{
			DataOverlayMode = false;
		}
		if (dataOverlayMode != DataOverlayMode && !DataOverlayMode)
		{
			MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
			if (Roof != null)
			{
				Roof.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
			}
			if (FloorMesh != null)
			{
				FloorMesh.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
			}
			if (InnerWalls != null)
			{
				InnerWalls.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
			}
			if (OuterWalls != null)
			{
				OuterWalls.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
			}
		}
	}

	private float LampCount(bool forceOn = false)
	{
		float num = 0f;
		_lastLampDarkLevel = 0f;
		for (int i = 0; i < Lamps.Count; i++)
		{
			if (Lamps[i].IsOn || forceOn || HUD.Instance.BuildMode)
			{
				num += Lamps[i].Lighting;
			}
			if (Lamps[i].IsOn || (HUD.Instance.BuildMode && HUD.Instance.SunSlider.value < 0.5f))
			{
				_lastLampDarkLevel += Lamps[i].Lighting;
			}
		}
		if (AtriumParent == this)
		{
			foreach (Room atriumChild in GetAtriumChildren())
			{
				atriumChild._lastLampDarkLevel = _lastLampDarkLevel;
			}
		}
		return num;
	}

	public bool IsLit()
	{
		float num = Mathf.Min(1f, LampCount(true) / (GetAtriumArea() / 16f));
		return Mathf.Min((Floor < 0) ? 1f : (1f - Mathf.Min(1f, WindowDarkLevel + IndirectLighting)), 1f - num) < 0.01f;
	}

	public float IsLitPercent()
	{
		float num = Mathf.Min(1f, LampCount(true) / (GetAtriumArea() / 16f));
		float num2 = Mathf.Min((Floor < 0) ? 1f : (1f - Mathf.Min(1f, WindowDarkLevel + IndirectLighting)), 1f - num);
		return Mathf.Clamp01(1f - num2);
	}

	private void UpdateDust()
	{
	}

	public void UpdateVisibility()
	{
		if (Dummy)
		{
			return;
		}
		bool flag = (CameraScript.Instance.FlyMode ? (CameraScript.Instance.mainCam.transform.position.y < 0f) : Utilities.InBasement(GameSettings.Instance.ActiveFloor)) == Utilities.InBasement(Floor) || HasTwoFloor;
		if (!Pillar)
		{
			if (InnerWalls != null)
			{
				if (IsSurrounded && !CameraScript.Instance.FlyMode)
				{
					InnerWalls.GetComponent<Renderer>().enabled = Floor == GameSettings.Instance.ActiveFloor && flag;
				}
				else
				{
					InnerWalls.GetComponent<Renderer>().enabled = Floor <= GameSettings.Instance.ActiveFloor && flag;
				}
			}
			if (FloorMesh != null)
			{
				Renderer component = FloorMesh.GetComponent<Renderer>();
				component.shadowCastingMode = ShadowCastingMode.TwoSided;
				if (IsSurrounded && !CameraScript.Instance.FlyMode)
				{
					component.enabled = Floor == GameSettings.Instance.ActiveFloor && flag;
				}
				else if (Floor > 0 && Outdoors && Floor > GameSettings.Instance.ActiveFloor)
				{
					component.enabled = true;
					component.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
				}
				else
				{
					component.enabled = Floor <= GameSettings.Instance.ActiveFloor && flag;
				}
				if (Outdoors && Grass != null)
				{
					Grass.SetActive(component.enabled && component.shadowCastingMode != ShadowCastingMode.ShadowsOnly);
				}
			}
			if (DirtObject != null)
			{
				DirtObject.SetActive(IsContentVisible());
			}
			if (UpperWalls != null)
			{
				UpperWalls.GetComponent<Renderer>().enabled = Floor == GameSettings.Instance.ActiveFloor;
				if (GameSettings.Instance.ActiveFloor == Floor)
				{
					UpperWalls.transform.position = new Vector3(0f, (GameSettings.WallsDown == GameSettings.WallState.Low || GameSettings.WallsDown == GameSettings.WallState.LowNoSeg) ? ((float)(Floor * 2) - 1.8f) : ((float)(Floor * 2)), 0f);
				}
			}
			if (BalconyFloor != null)
			{
				BalconyFloor.GetComponent<Renderer>().enabled = GameSettings.Instance.ActiveFloor >= Floor;
			}
		}
		if (OuterWalls != null)
		{
			Renderer component2 = OuterWalls.GetComponent<Renderer>();
			if (flag)
			{
				component2.enabled = true;
				if (Floor <= GameSettings.Instance.ActiveFloor)
				{
					Material highlight = null;
					SelectorController.HighlightType type;
					if (GetHighlightType(out type))
					{
						highlight = SelectorController.Instance.GetHighlightMaterial(type, false, false, null);
					}
					SetMaterial(component2, highlight, MatType.Outer);
				}
				else
				{
					component2.sharedMaterials = new Material[1] { RoomMaterialController.Instance.ShadowsOnly };
				}
			}
			else
			{
				component2.enabled = false;
			}
		}
		if (MainFence != null)
		{
			Renderer component3 = MainFence.GetComponent<Renderer>();
			if (flag)
			{
				component3.enabled = true;
				component3.shadowCastingMode = ((Floor <= GameSettings.Instance.ActiveFloor) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			}
			else
			{
				component3.enabled = false;
			}
			if (SubFence != null)
			{
				SubFence.GetComponent<Renderer>().enabled = component3.enabled && component3.shadowCastingMode == ShadowCastingMode.On;
			}
		}
		if (Roof != null)
		{
			Renderer component4 = Roof.GetComponent<Renderer>();
			if (flag)
			{
				int num = (Pillar ? (Floor - 1) : Floor);
				component4.enabled = true;
				component4.sharedMaterial = ((num < GameSettings.Instance.ActiveFloor) ? RoomMaterialController.Instance.StandardRoof : RoomMaterialController.Instance.ShadowsOnly);
			}
			else
			{
				component4.enabled = false;
			}
		}
	}

	private void OnApplicationQuit()
	{
		GameSettings.IsQuitting = true;
		GameSettings.Instance = null;
	}

	public void StartFire()
	{
		if (Dummy || Outdoors || Pillar || IsOnFire)
		{
			return;
		}
		_anyBurnables = true;
		if (!NotificationManager.CheckAggregate<RoomFireNotification>(this))
		{
			NotificationManager.AddNotification(new RoomFireNotification(this));
		}
		GameSettings.Instance.ResetUndo();
		IsOnFire = true;
		if (HUD.Instance.BuildMode)
		{
			HUD.Instance.BuildMode = false;
		}
		BurnStop = 1f;
		GameSettings.Instance.AddToFireCounter();
		GameSettings.Instance.sRoomManager.RefreshFireEscapes(this);
		HashSet<Furniture> sprinklers = GetFurnitureAtrium("Sprinkler").ToHashSet();
		foreach (Furniture item in sprinklers)
		{
			item.IsOn = true;
		}
		_furnitures.ThreadSafeForEach(delegate(Furniture f)
		{
			if (!sprinklers.Contains(f))
			{
				f.FireProtection = false;
				Vector2 vector = f.transform.position.FlattenVector3();
				foreach (Furniture item2 in sprinklers)
				{
					Vector2 vector2 = item2.transform.position.FlattenVector3();
					if (vector.MaxDist(vector2) <= 2f && vector.SqrDist(vector2) <= 4f)
					{
						if (f.HasUpg && f.ITFix && f.IsOn)
						{
							f.upg.Quality = 0f;
						}
						f.FireProtection = true;
						break;
					}
				}
			}
		});
		IEnumerable<Furniture> furnitureAtrium = GetFurnitureAtrium("FireAlarm");
		bool flag = false;
		foreach (Furniture item3 in furnitureAtrium)
		{
			item3.IsOn = true;
			flag = true;
		}
		if (flag)
		{
			List<Room> connected = GameSettings.Instance.sRoomManager.GetConnected(this, false, false);
			for (int num = 0; num < connected.Count; num++)
			{
				connected[num].OccupantsFlee();
			}
		}
		else
		{
			OccupantsFlee();
		}
		GameSettings.Instance.SpawnFireFighter(this);
		if (!(AtriumParent != null))
		{
			return;
		}
		Room atriumParent = AtriumParent;
		if (!atriumParent.IsOnFire && atriumParent != this)
		{
			atriumParent.StartFire();
		}
		foreach (Room atriumChild in atriumParent.GetAtriumChildren())
		{
			if (!atriumChild.IsOnFire && atriumChild != this)
			{
				atriumChild.StartFire();
			}
		}
	}

	public IEnumerable<Furniture> GetFurnitureAtrium(string type)
	{
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		foreach (Room item in mainAtriumParentOrSelf.GetAtriumChildrenAndSelf())
		{
			HashList<Furniture> fs = item.GetFurniture(type);
			for (int i = 0; i < fs.Count; i++)
			{
				yield return fs[i];
			}
		}
	}

	public IEnumerable<Furniture> GetAllFurnitureAtriumAndBalconies(int maxFloor = int.MaxValue)
	{
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		foreach (Room item in mainAtriumParentOrSelf.GetAtriumChildrenAndSelf())
		{
			if (item.Floor > maxFloor)
			{
				continue;
			}
			List<Furniture> fs = item.GetFurnitures();
			for (int i = 0; i < fs.Count; i++)
			{
				Furniture furniture = fs[i];
				if ((float)furniture.Floor * 2f + furniture.OffsetHeight(0) + 0.0001f < (float)maxFloor * 2f + 2f)
				{
					yield return furniture;
				}
			}
		}
	}

	public int CountFurnitureAtrium(string type)
	{
		int num = 0;
		foreach (Room item in GetMainAtriumParentOrSelf().GetAtriumChildrenAndSelf())
		{
			num += item.GetFurniture(type).Count;
		}
		return num;
	}

	public void StopFire()
	{
		if (!IsOnFire)
		{
			return;
		}
		GameSettings.Instance.FireCounter--;
		IsOnFire = false;
		foreach (Furniture item in GetFurnitureAtrium("FireAlarm"))
		{
			item.IsOn = false;
		}
		foreach (Furniture item2 in GetFurnitureAtrium("Sprinkler"))
		{
			item2.IsOn = false;
		}
		GameSettings.Instance.sRoomManager.RefreshFireEscapes(this);
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		if (GameSettings.Instance.PassedFireInspection && insurance.ActualContentInsurance > 0)
		{
			GameSettings.Instance.ContentsInsured += insurance.GetContentCoverage(true) * GetFireRepairCost() * 0.5f;
		}
	}

	private void OccupantsFlee()
	{
		for (int i = 0; i < Occupants.Count; i++)
		{
			Occupants[i].FleeNow();
		}
	}

	private void EmitFire(List<Vector3> ps)
	{
		int num = Mathf.CeilToInt((float)ps.Count * BurnStop * 0.05f * Mathf.Sqrt(GameSettings.GameSpeed));
		ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
		{
			velocity = Vector3.up * 4f,
			startLifetime = 0.5f,
			startSize = 1.5f
		};
		for (int i = 0; i < num; i++)
		{
			emitParams.position = ps.GetRandom();
			emitParams.rotation = UnityEngine.Random.value * 360f;
			BuildController.Instance.FireEmitter.Emit(emitParams, 1);
		}
	}

	public static void FirePoof(Vector3 pos)
	{
		ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
		{
			position = pos,
			startSize = 1f,
			startLifetime = 2f
		};
		for (int i = 0; i < 25; i++)
		{
			emitParams.velocity = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(3f, 4f), UnityEngine.Random.Range(-1f, 1f));
			emitParams.rotation = UnityEngine.Random.value * 360f;
			HUD.Instance.DirtEmitter.Emit(emitParams, 1);
			BuildController.Instance.FireEmitter.Emit(emitParams, 1);
		}
	}

	public void UpdateFurnOnFire(Furniture ignore = null)
	{
		FurnOnFire = _furnitures.ThreadSafeAny((Furniture x) => x != ignore && x.OnFire > 0f);
	}

	public void ClearDirtTimer()
	{
		_dirtWarningTimer = 0f;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		UpdateRoom(DirtyNavMesh, !Dummy && DirtyOuterMesh, !Dummy && DirtyInnerMesh, DirtyPathNodes, DirtyStateVariables, DirtyFloorMesh, DirtyRoofMesh, DirtyTeamNames, DirtyTableGroups);
		if (Dummy || Pillar)
		{
			return;
		}
		Problems.Clear();
		if (Outdoors)
		{
			_darknessLevel = 0f;
		}
		else
		{
			if (DirtScore < 0.1f && (ForceRole == -5 || GetFurniture("Computer").Count > 0 || GetFurniture("Desk").Count > 0))
			{
				if (_dirtWarningTimer < 30f)
				{
					_dirtWarningTimer += Time.deltaTime * GameSettings.GameSpeed;
					if (_dirtWarningTimer >= 30f && !NotificationManager.CheckAggregate<DirtyRoomNotification>(this))
					{
						NotificationManager.AddNotification(new DirtyRoomNotification(this));
					}
				}
			}
			else
			{
				_dirtWarningTimer = 0f;
			}
			if (IsOnFire)
			{
				if (GameSettings.GameSpeed > 0f)
				{
					if (IsUpperAtriumNotBalcony)
					{
						if (_outsideFirePoints.Count > 0 && Floor <= GameSettings.Instance.ActiveFloor)
						{
							EmitFire(_outsideFirePoints);
						}
					}
					else if (Floor == GameSettings.Instance.ActiveFloor || IsContentVisible())
					{
						EmitFire(_firePoints);
					}
					else if (_outsideFirePoints.Count > 0 && Floor < GameSettings.Instance.ActiveFloor && Utilities.InBasement(Floor) == Utilities.InBasement(GameSettings.Instance.ActiveFloor))
					{
						EmitFire(_outsideFirePoints);
					}
				}
				float num = ((Occupants.Count == 0 && !_anyBurnables) ? 10f : 1f);
				float atriumArea = GetAtriumArea();
				float num2 = 50f / atriumArea;
				if (num2 * num < 0.5f)
				{
					num = 0.5f / num2;
				}
				Burn += num * Utilities.PerHour(num2);
				BurnStop -= num * Utilities.PerHour((float)(CountFurnitureAtrium("Sprinkler") * 32) / atriumArea);
				if (BurnStop <= 0f)
				{
					StopFire();
				}
				else
				{
					if (IsPlayerControlled() && _furnitures.Count > 0)
					{
						if (Utilities.ChancePerInGameMinute(num * 0.2f, Time.deltaTime) > 0)
						{
							Furniture furniture = null;
							lock (_furnitures)
							{
								int num3 = UnityEngine.Random.Range(0, _furnitures.Count);
								for (int i = 0; i < _furnitures.Count; i++)
								{
									Furniture furniture2 = _furnitures[(i + num3) % _furnitures.Count];
									if (furniture2.IsAliveNotNull() && furniture2.CanBurn())
									{
										furniture = furniture2;
										break;
									}
								}
							}
							if (furniture.IsAliveNotNull())
							{
								while (furniture.SnapPoints != null && furniture.SnapPoints.Length != 0)
								{
									SnapPoint snapPoint = furniture.SnapPoints.FirstOrDefault((SnapPoint x) => x.UsedByCount > 0);
									if (!(snapPoint != null))
									{
										break;
									}
									furniture = snapPoint.GetAllUsedBy().GetRandom();
								}
								if (Floor == GameSettings.Instance.ActiveFloor)
								{
									FirePoof(furniture.transform.position);
									UISoundFX.PlaySFX("FireBreak", furniture.transform.position, GameSettings.Instance.sRoomManager.CameraRoom != this);
								}
								furniture.InsurancePayout();
								furniture.Undo = true;
								furniture.NonPlayerDestruction = true;
								AddDestructionUndo(furniture);
								furniture.DestroyGO();
							}
							else
							{
								_anyBurnables = Occupants.Count > 0;
							}
						}
					}
					else
					{
						_anyBurnables = Occupants.Count > 0;
					}
					if (Burn < 1f)
					{
						InsideColor = InsideColor.Alpha(1f - Burn);
						OutsideColor = OutsideColor.Alpha(1f - Burn);
						FloorColor = FloorColor.Alpha(1f - Burn);
					}
					else if (Burn >= 3f)
					{
						StopFire();
					}
					else if (Utilities.ChancePerInGameMinute(num * 0.1f, Time.deltaTime) > 0)
					{
						bool flag = false;
						Vector2? vector = FindRandomSpot();
						if (vector.HasValue)
						{
							Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(Floor + ((!(UnityEngine.Random.value > 0.5f)) ? 1 : (-1)), vector.Value);
							if (roomFromPoint != null && !roomFromPoint.IsOnFire && roomFromPoint.Burn == 0f && !roomFromPoint.Outdoors && !roomFromPoint.Pillar)
							{
								roomFromPoint.StartFire();
								flag = true;
							}
						}
						if (!flag)
						{
							for (int num4 = 0; num4 < Edges.Count; num4++)
							{
								WallEdge other = Edges[num4];
								Room room = Edges[(num4 + 1) % Edges.Count].GetRoom(other);
								if (room != null && !room.IsOnFire && room.Burn == 0f && !room.Outdoors && !room.Pillar)
								{
									room.StartFire();
									break;
								}
							}
						}
					}
				}
			}
			else if (!IsPlayerControlled() && Burn > 0f && !BuildingOnFire)
			{
				RepairFireDamage();
			}
			if (!IsUpperAtrium)
			{
				if (GameSettings.GameSpeed > 0f)
				{
					RefreshGerms(Time.deltaTime * GameSettings.GameSpeed);
					RefreshSmell(Time.deltaTime * GameSettings.GameSpeed);
				}
				if (_lastTempValueUpdate < 0f || Time.realtimeSinceStartup - _lastTempValueUpdate > 10f)
				{
					UpdateTemperatureValues();
				}
			}
			else if (AtriumParent != null)
			{
				Smell = AtriumParent.Smell;
				GermCount = AtriumParent.GermCount;
			}
			UpdateTemperature(false);
			if (AtriumParent == null || AtriumParent == this)
			{
				DustRend.enabled = Smell > 0.25f && (Floor == GameSettings.Instance.ActiveFloor || (Utilities.InBasement(GameSettings.Instance.ActiveFloor) == Utilities.InBasement(Floor) && Floor < GameSettings.Instance.ActiveFloor && !IsSurrounded));
				if (DustRend.enabled)
				{
					float dust = Smell.MapRange(0.25f, 0.9f, 0f, 1f, true);
					float num5 = CameraScript.Instance.LastCamPos.y - (float)(Floor * 2);
					Material[] dust2 = MaterialBank.Instance.GetDust(dust);
					if (num5 > 70f)
					{
						DustRend.sharedMaterial = dust2[1];
					}
					else
					{
						DustRend.sharedMaterials = dust2;
					}
				}
				float num6 = Mathf.Min(1f, LampCount() / (GetAtriumArea() / 16f));
				_darknessLevel = Mathf.Min((Floor == -1) ? 1f : (1f - Mathf.Min(1f, WindowDarkLevel + IndirectLighting) * TimeOfDay.LightLevel), 1f - num6);
				if (!FurnitureInfluenceDrawer.Instance.enabled && Mathf.Approximately(_darknessLevel, 0f))
				{
					DarknessRend.enabled = false;
				}
				else
				{
					int num7 = Mathf.Max(1, 1 + Mathf.Min(AtriumChildren.Count, GameSettings.Instance.ActiveFloor - Floor));
					Transform obj = DustFilter.transform;
					Vector3 localScale = (Darkness.transform.localScale = new Vector3(1f, (float)num7 * 2f - 0.01f, 1f));
					obj.localScale = localScale;
					DarknessRend.sharedMaterial = MaterialBank.Instance.GetDarkness(_darknessLevel);
					DarknessRend.enabled = (FurnitureInfluenceDrawer.Instance.enabled || !HUD.Instance.BuildMode || GameSettings.WallsDown == GameSettings.WallState.High) && !DataOverlay.HasActive && (Floor >= 0 || GameSettings.Instance.ActiveFloor < 0 || HasTwoFloor) && Floor <= GameSettings.Instance.ActiveFloor && (FurnitureInfluenceDrawer.Instance.enabled || _darknessLevel > 0f || Dust > 0f);
				}
			}
			else
			{
				_darknessLevel = AtriumParent._darknessLevel;
			}
			if (!IsUpperAtriumNotBalcony && IsPlayerControlled() && Floor == GameSettings.Instance.ActiveFloor && (MajorProblem || HUD.Instance.BuildMode) && ((OuterWalls != null && OuterWalls.GetComponent<Renderer>().isVisible) || (MainFence != null && MainFence.GetComponent<Renderer>().isVisible)))
			{
				UpdateProblems();
			}
		}
		UpdateColors();
	}

	public void RefreshGerms(float delta)
	{
		if (GermCount > 0f)
		{
			GermCount = Mathf.Max(0f, GermCount - Utilities.PerHour(1f / 24f, delta, false));
		}
	}

	public void RefreshSmell(float delta)
	{
		if (Outside || Pillar || Outdoors)
		{
			Smell = 0f;
			return;
		}
		float atriumArea = GetAtriumArea();
		float num = ((Occupants.Count > 0) ? ((float)Occupants.SumSafe((Actor x) => (!x.BO) ? 1 : 4) * 20f / 8f) : 0f);
		if (DirtScore < 1f)
		{
			num += (1f - DirtScore) * atriumArea / 4f;
		}
		if (TimeOfDay.Instance.Temperature > 10f)
		{
			num -= WindowDarkLevelNoCap * atriumArea / 2f * GameSettings.Instance.Environment.AirQuality;
		}
		for (int num2 = 0; num2 < RoomConnections.Count; num2++)
		{
			ValueTuple<Room, float> valueTuple = RoomConnections[num2];
			if (valueTuple.Item1.Outside || valueTuple.Item1.Outdoors)
			{
				Smell -= Utilities.PerHour(valueTuple.Item2 * 50f / atriumArea, delta, false) * 0.5f;
			}
			else
			{
				if (!(Smell < 1f))
				{
					continue;
				}
				float atriumArea2 = valueTuple.Item1.GetAtriumArea();
				float num3 = 1f;
				if (valueTuple.Item1.Smell * atriumArea2 * num3 > Smell * atriumArea)
				{
					float num4 = Mathf.Min(valueTuple.Item1.Smell, Utilities.PerHour(valueTuple.Item2 * 50f * valueTuple.Item1.Smell, delta, false)) * 0.5f;
					Smell += num4 / atriumArea;
					if (Smell > 1f)
					{
						num4 -= (Smell - 1f) * atriumArea;
						Smell = 1f;
					}
					valueTuple.Item1.Smell = Mathf.Max(0f, valueTuple.Item1.Smell - num4 / atriumArea2);
				}
			}
		}
		num -= AirCleansing;
		Smell = Mathf.Clamp01(Smell + Utilities.PerHour(num * 0.5f / atriumArea, delta, false));
	}

	public void UpdateFrameState()
	{
		UpdateDust();
	}

	public static float TemperatureAreaScale(float temp, bool onlyHeat = false)
	{
		if (!onlyHeat && temp < 0f)
		{
			return 1f - temp / 20f;
		}
		if (temp > 35f)
		{
			return 1f + (temp - 35f) / 20f;
		}
		return 1f;
	}

	private void UpdateProblems()
	{
		MajorProblem = false;
		if (Pillar)
		{
			return;
		}
		bool isBalcony = IsBalcony;
		int count = GetFurniture("Toilet").Count;
		int count2 = GetFurniture("Computer").Count;
		if (count > 1 || ((Occupants.Count > 1 || count2 > 0 || !IsPrivate) && count > 0))
		{
			Problems.Add("PublicToiletWarning".Loc());
			MajorProblem = true;
		}
		else if (GetFurniture("Shower").Count > 0 && !IsPrivate)
		{
			Problems.Add("PublicShowerWarning".Loc());
			MajorProblem = true;
		}
		if (!isBalcony && !GameSettings.Instance.RentMode)
		{
			float num = GetAtriumArea() * Insulation;
			if (count2 > 0)
			{
				if (Floor >= 0 && TimeOfDay.Instance.CurrentWeather.MaximumTemperature > 21f && num * TemperatureAreaScale(TimeOfDay.Instance.CurrentWeather.MaximumTemperature) > TheoCoolingControlArea)
				{
					Problems.Add("RoomCoolingWarning".Loc());
				}
				else if (TimeOfDay.Instance.CurrentWeather.MinimumTemperature < 21f && num * TemperatureAreaScale((Floor >= 0) ? TimeOfDay.Instance.CurrentWeather.MinimumTemperature : 5f) > TheoHeatingControlArea)
				{
					Problems.Add("RoomHeatingWarning".Loc());
				}
			}
		}
		if (count2 > 1 && (float)count2 / Area > 0.3f)
		{
			Problems.Add("RoomOvercrowdWarning".Loc());
		}
		if (!isBalcony && count2 > 0 && WindowDarkLevel + IndirectLighting + Lamps.Sum((Furniture x) => x.Lighting) / (GetAtriumArea() / 16f) < 0.75f)
		{
			Problems.Add("RoomLighingWaning".Loc());
		}
		if (count2 > 0 && GetFurniture("Trashcan").SumSafe((Furniture x) =>
		{
			TrashCan component;
			return x.TryGetComponent<TrashCan>(out component) ? component.MaxTrash : 0;
		}) / count2 < 7)
		{
			Problems.Add("TrashRoomWarning".Loc());
			MajorProblem = true;
		}
		if (count2 > 0 && (float)(count2 * 20 / 8) - AirCleansing > 0f)
		{
			Problems.Add("RoomAirQualityWarning".Loc());
		}
		HashSet<Team> allowed = GetActuallyAllowed();
		if (Teams.Count > 0 && allowed != null && allowed.Count < GameSettings.Instance.sActorManager.Teams.Count && Teams.Any((Team x) => !allowed.Contains(x)))
		{
			Problems.Add("RoomTeamAssignmentWarning".Loc());
			MajorProblem = true;
		}
	}

	private void Start()
	{
		if (!Deserialized)
		{
			TeamChange();
			ChangeRole(ForceRole);
		}
		AuraValues = new float[3];
		for (int i = 0; i < 3; i++)
		{
			AuraValues[i] = 0f;
		}
		if (Edges != null && Edges.Count > 0)
		{
			Vector2 f = Edges[0].Pos;
			if (Edges.All((WallEdge x) => x.Pos == f))
			{
				DestroyGO();
			}
		}
		GameSettings.Instance.SetDirtyHelipad(Floor);
	}

	private void ClearMesh(GameObject go)
	{
		if (go != null)
		{
			UnityEngine.Object.Destroy(go.GetComponent<MeshFilter>().sharedMesh);
		}
	}

	private void ClearMesh(MeshFilter go)
	{
		if (go.sharedMesh != null)
		{
			UnityEngine.Object.Destroy(go.sharedMesh);
		}
	}

	public void UpdateParentOfFurniture(List<UndoObject.UndoAction> undos = null)
	{
		_furnitures.UpdateParentOfFurniture(false, undos);
	}

	private void OnDestroy()
	{
		UpdatePCNoisiness.Remove(this);
		ClearMesh(Roof);
		ClearMesh(FloorMesh);
		ClearMesh(OuterWalls);
		ClearMesh(MainFence);
		ClearMesh(SubFence);
		ClearMesh(InnerWalls);
		ClearMesh(UpperWalls);
		ClearMesh(BalconyFloor);
		ClearMesh(Darkness);
		ClearMesh(DirtMesh);
		if (GameSettings.Instance.IsReferenceNull() || ErrorLogging.SceneChanging || HUD.Instance == null)
		{
			return;
		}
		if (AtriumParent != null)
		{
			if (AtriumParent == this)
			{
				AtriumChildren.ForEach(delegate(Room x)
				{
					if (x.IsAliveNotNull())
					{
						x.DestroyGO();
						x.AtriumParent = null;
					}
				});
				AtriumChildren.Clear();
			}
			else
			{
				AtriumParent.AtriumChildren.Remove(this);
				AtriumParent.UpdateAtriumNetwork();
				AtriumParent.DirtyInnerMesh = true;
				Room mainAtriumParent = GetMainAtriumParent();
				if (mainAtriumParent != null)
				{
					mainAtriumParent.DirtyRoofMesh = true;
					mainAtriumParent.RecalculateStateVariables(true);
					foreach (Room atriumChild in mainAtriumParent.GetAtriumChildren())
					{
						if (atriumChild.IsAliveNotNull())
						{
							atriumChild.DirtyRoofMesh = true;
							if (IsBalcony)
							{
								atriumChild.DirtyOuterMesh = true;
							}
							atriumChild.UpdateParentOfFurniture();
						}
					}
					if (mainAtriumParent.AtriumChildren.Count == 0)
					{
						mainAtriumParent.AtriumParent = null;
						mainAtriumParent.RefreshTextureTiling();
					}
					mainAtriumParent.UpdateParentOfFurniture();
				}
			}
		}
		GameSettings.EndNav(this);
		GameSettings.Instance.SetDirtyHelipad(Floor);
		HUD.Instance.InaccessibleRoom.Remove(this);
		if (IsOnFire)
		{
			GameSettings.Instance.FireCounter--;
		}
		if (GrassSystem.Instance != null && Floor == 0)
		{
			GrassSystem.Instance.InvalidateArea();
		}
		if (HUD.Instance.roofEditWindow.HasRoom(this))
		{
			HUD.Instance.roofEditWindow.Window.Close();
		}
		UnGroup();
		if (Floor < 1 && _furnitures.ThreadSafeAny((Furniture x) => x.IsAliveNotNull() && x.TwoFloors && x.MakeHole && ((x.Parent == this && Floor == -1) || x.ExtraParent == this)))
		{
			TimeOfDay.Instance.GroundTopDirty = true;
		}
		RoomMaterialController.Free2Colors(_insideColorID);
		RoomMaterialController.Free2Colors(_outsideColorID);
		RoomMaterialController.Free2Colors(_floorColorID);
		List<WallEdge> list = Destroy();
		for (int num = 0; num < list.Count; num++)
		{
			GameSettings.Instance.sRoomManager.AllSegments.Remove(list[num]);
		}
		GameSettings.Instance.sRoomManager.Rooms.RemoveAll((Room x) => x == this);
		List<Furniture> list2;
		lock (_furnitures)
		{
			list2 = _furnitures.ToList();
		}
		for (int num2 = 0; num2 < list2.Count; num2++)
		{
			Furniture furniture = list2[num2];
			if (furniture.IsAliveNotNull() && !furniture.KeepWithoutParent(this))
			{
				if (furniture.PreferInventory)
				{
					furniture.Undo = true;
				}
				furniture.DestroyGO();
			}
		}
		if (Floor == 0)
		{
			GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
		}
		GameSettings.Instance.RemoveRoomFromGroups(this);
		GameSettings.Instance.sRoomManager.RemoveRoom(this);
		GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
		GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
		GameSettings.Instance.sRoomManager.CCTVDirty = true;
		List<Actor> list3 = Occupants.ToList();
		for (int num3 = 0; num3 < list3.Count; num3++)
		{
			Actor actor = list3[num3];
			if (actor.IsAliveNotNull() && actor.currentActualRoom == this)
			{
				actor.currentRoom = null;
				actor.ResetState();
				GameSettings.Instance.ResetRooms.Add(actor);
			}
		}
	}

	public void RefreshNoise()
	{
		if (Dummy)
		{
			return;
		}
		if (AudioVisualizer.Instance != null && AudioVisualizer.Instance.LastRoom == this)
		{
			AudioVisualizer.Instance.ForceRedraw();
		}
		UpdatePCNoisiness.Add(this);
		for (int i = 0; i < Edges.Count; i++)
		{
			Room room = Edges[(i + 1) % Edges.Count].GetRoom(Edges[i]);
			if (room != null)
			{
				UpdatePCNoisiness.Add(room);
			}
		}
	}

	public Vector3? GetValidPointNear(Vector3 ppp, float radius, bool exact = false, float angleFrom = 0f, float angleTo = (float)Math.PI * 2f)
	{
		lock (NavLock)
		{
			if (NavMap == null || NavMap.Length == 0)
			{
				return null;
			}
			Vector2 vector = ppp.FlattenVector3();
			float f = UnityEngine.Random.Range(angleFrom, angleTo);
			float num = (exact ? 1f : UnityEngine.Random.value);
			vector += new Vector2(Mathf.Sin(f) * radius * num, Mathf.Cos(f) * radius * num);
			if (Outside)
			{
				RoadSegment road = GameSettings.Instance.sRoomManager.GetRoad(ppp);
				if (road != null)
				{
					float roadSize = RoadManager.Instance.RoadSize;
					Vector2 vector2 = new Vector2(Mathf.Clamp(vector.x, (float)road.x * roadSize, (float)road.x * roadSize + roadSize), Mathf.Clamp(vector.y, (float)road.y * roadSize, (float)road.y * roadSize + roadSize));
					return vector2.ToVector3(road.SampleHeight(vector2));
				}
			}
			float num2 = float.MaxValue;
			Vector2? vector3 = null;
			if (BSPNavMap != null)
			{
				List<TriangleNode> nodes = BSPNavMap.GetNodes(vector);
				for (int i = 0; i < nodes.Count; i++)
				{
					if (nodes[i].IsInside(vector))
					{
						return vector.ToVector3((float)Floor * 2f);
					}
				}
			}
			for (int j = 0; j < NavMap.Length; j++)
			{
				TriangleNode triangleNode = NavMap[j];
				if (BSPNavMap == null && triangleNode.IsInside(vector))
				{
					return vector.ToVector3((float)Floor * 2f);
				}
				Vector2 vector4 = Utilities.ClosestPointOnTriangle(triangleNode.PortalPoints, vector, 0.001f);
				float num3 = vector4.SqrDist(vector);
				if (num3 < num2)
				{
					num2 = num3;
					vector3 = vector4;
				}
			}
			return (!vector3.HasValue) ? ((Vector3?)null) : new Vector3?(vector3.Value.ToVector3((float)Floor * 2f));
		}
	}

	private TriangleNode ClosestNav(Vector2 p)
	{
		if (NavMap == null || NavMap.Length == 0)
		{
			return null;
		}
		if (BSPNavMap == null)
		{
			return NavMap.MinInstance((TriangleNode x) => Utilities.ClosestPointOnTriangle(x.Points, p).SqrDist(p));
		}
		return BSPNavMap.GetNodes(p).MinInstance((TriangleNode x) => Utilities.ClosestPointOnTriangle(x.Points, p).SqrDist(p));
	}

	public bool GetNavOrClosest(Vector2 p, out Vector2? pos, float validRangeSqr = 0f, bool locking = true)
	{
		if (locking)
		{
			Monitor.Enter(NavLock);
		}
		try
		{
			pos = null;
			if (NavMap == null)
			{
				return false;
			}
			float num = float.MaxValue;
			if (BSPNavMap != null)
			{
				List<TriangleNode> nodes = BSPNavMap.GetNodes(p);
				if (nodes != null)
				{
					for (int i = 0; i < nodes.Count; i++)
					{
						if (nodes[i].IsInside(p))
						{
							return true;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < NavMap.Length; j++)
				{
					if (NavMap[j].IsInside(p))
					{
						return true;
					}
				}
			}
			for (int k = 0; k < NavMap.Length; k++)
			{
				Vector2 vector = Utilities.ClosestPointOnTriangle(NavMap[k].Points, p, 0.001f);
				float num2 = vector.SqrDist(p);
				if (num2 < num)
				{
					num = num2;
					pos = vector;
				}
				if (num2 < validRangeSqr)
				{
					break;
				}
			}
			return false;
		}
		finally
		{
			if (locking)
			{
				Monitor.Exit(NavLock);
			}
		}
	}

	public TriangleNode GetTriangle(Vector2 p)
	{
		if (BSPNavMap != null)
		{
			List<TriangleNode> nodes = BSPNavMap.GetNodes(p);
			if (nodes != null)
			{
				for (int i = 0; i < nodes.Count; i++)
				{
					if (nodes[i].IsInside(p))
					{
						return nodes[i];
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < NavMap.Length; j++)
			{
				if (NavMap[j].IsInside(p))
				{
					return NavMap[j];
				}
			}
		}
		return null;
	}

	private Vector2? FixNavPos(Vector2 p)
	{
		if (NavMap == null || NavMap.Length == 0 || GetNodeAt(p) != null)
		{
			return null;
		}
		TriangleNode triangleNode = NavMap.MinInstance((TriangleNode x) => x.Center.SqrDist(p));
		if (triangleNode != null)
		{
			return Utilities.ClosestPointOnTriangle(triangleNode.Points, p);
		}
		return null;
	}

	public void FixActorPosition(Actor actor, bool stateReset = true)
	{
		if (Dummy)
		{
			return;
		}
		Vector2 vector = new Vector2(actor.ActualPosition.x, actor.ActualPosition.z);
		Vector2? vector2 = FixNavPos(vector);
		if (vector2.HasValue)
		{
			actor.ActualPosition = new Vector3(vector2.Value.x, actor.ActualPosition.y, vector2.Value.y);
			if (stateReset && vector2.Value.MaxDist(vector) > 0.05f)
			{
				actor.ResetState();
			}
		}
	}

	public void FixActorPositions()
	{
		if (Dummy)
		{
			return;
		}
		for (int i = 0; i < Occupants.Count; i++)
		{
			Actor actor = Occupants[i];
			if (actor.CurrentPath == null)
			{
				FixActorPosition(actor);
			}
		}
	}

	public TriangleNode GetNodeAt(Vector2 p, bool locking = true)
	{
		if (locking)
		{
			Monitor.Enter(NavLock);
		}
		try
		{
			if (NavMap == null)
			{
				return null;
			}
			if (BSPNavMap != null)
			{
				List<TriangleNode> nodes = BSPNavMap.GetNodes(p);
				if (nodes != null)
				{
					for (int i = 0; i < nodes.Count; i++)
					{
						if (nodes[i].IsInside(p))
						{
							return nodes[i];
						}
					}
					return null;
				}
			}
			for (int j = 0; j < NavMap.Length; j++)
			{
				if (NavMap[j].IsInside(p))
				{
					return NavMap[j];
				}
			}
			return null;
		}
		finally
		{
			if (locking)
			{
				Monitor.Exit(NavLock);
			}
		}
	}

	public bool FindPath(Vector3 Start, Vector3 Goal, ref List<PathVector> result, IRoomConnector a, IRoomConnector b, byte flagA, byte flagB)
	{
		lock (NavLock)
		{
			if (a != null && b != null)
			{
				List<Vector2> orNull = CachedPaths.GetOrNull(new PathCacheKey(a, b, flagA, flagB));
				if (orNull != null)
				{
					ConvertToWalkablePath(orNull, result, Dummy);
					CanClean = true;
					return true;
				}
				orNull = CachedPaths.GetOrNull(new PathCacheKey(b, a, flagB, flagA));
				if (orNull != null)
				{
					ConvertToWalkablePath(orNull, result, Dummy, true);
					CanClean = true;
					return true;
				}
			}
			Vector2 p = Start.FlattenVector3();
			TriangleNode triangleNode = GetNodeAt(p, false);
			if (triangleNode == null)
			{
				triangleNode = ClosestNav(p);
				if (triangleNode == null)
				{
					return false;
				}
			}
			TriangleNode nodeAt = GetNodeAt(new Vector2(Goal.x, Goal.z), false);
			if (nodeAt == null)
			{
				return false;
			}
			if (triangleNode == nodeAt)
			{
				PathVector.PathType type = (Outside ? PathVector.PathType.Outside : PathVector.PathType.None);
				result.Add(new PathVector(Start.x, Floor * 2, Start.z, type));
				result.Add(new PathVector(Goal.x, Floor * 2, Goal.z, type));
				CanClean = true;
				return true;
			}
			Vector2 center = triangleNode.Center;
			Vector2 center2 = nodeAt.Center;
			triangleNode.StartEnd = (nodeAt.StartEnd = true);
			triangleNode.Center = new Vector2(Start.x, Start.z);
			nodeAt.Center = new Vector2(Goal.x, Goal.z);
			TriangleNode.MainPathToggle++;
			triangleNode.StartEnd = false;
			UpdateCenter(triangleNode, nodeAt);
			List<TriangleNode> list = NodePathFinding<TriangleNode>.FindPath(triangleNode.PathNode, nodeAt.PathNode, TriangleDistance, TriangleHeuristic, (object x) => true);
			triangleNode.StartEnd = (nodeAt.StartEnd = false);
			triangleNode.Center = center;
			nodeAt.Center = center2;
			if (list == null)
			{
				return false;
			}
			lock (PortalCache)
			{
				PortalCache.Clear();
				TriangleNode.GetPortals(list, Start.FlattenVector3(), PortalCache);
				NodePathFinding<TriangleNode>.Release(list);
				PortalCache.Insert(0, new TriangleNode.Portal(new Vector2(Start.x, Start.z)));
				if (PortalCache.Count > 1)
				{
					Vector2 p2 = Start.FlattenVector3();
					Vector2 left = PortalCache[1].Left;
					Vector2 right = PortalCache[1].Right;
					if (Utilities.IsLeft(p2, left, right) > 0)
					{
						PortalCache.Insert(1, new TriangleNode.Portal((p2.SqrDist(left) < p2.SqrDist(right)) ? left : right));
					}
				}
				PortalCache.Add(new TriangleNode.Portal(new Vector2(Goal.x, Goal.z)));
				if (a != null && b != null)
				{
					List<Vector2> list2 = RemoveDoubles(TriangleNode.StringPull(PortalCache));
					CachedPaths[new PathCacheKey(a, b, flagA, flagB)] = list2;
					result.AddRangeQuick(ConvertToWalkablePath(list2, null, Dummy));
				}
				else
				{
					ConvertToWalkablePath(RemoveDoubles(TriangleNode.StringPull(PortalCache)), result, Dummy);
				}
			}
			CanClean = true;
			return true;
		}
	}

	private List<Vector2> RemoveDoubles(List<Vector2> path)
	{
		for (int i = 0; i < path.Count - 1; i++)
		{
			if (path[i] == path[i + 1])
			{
				path.RemoveAt(i);
				i--;
			}
		}
		return path;
	}

	private List<PathVector> ConvertToWalkablePath(List<Vector2> path, List<PathVector> result, bool outdoor, bool reverse = false)
	{
		if (result == null)
		{
			result = new List<PathVector>();
		}
		PathVector.PathType type = (outdoor ? PathVector.PathType.Outside : PathVector.PathType.None);
		for (int i = 0; i < path.Count - 1; i++)
		{
			int index = (reverse ? (path.Count - 1 - i) : i);
			result.Add(new PathVector(path[index].x, Floor * 2, path[index].y, type));
		}
		Vector2 vector = path[(!reverse) ? (path.Count - 1) : 0];
		result.Add(new PathVector(vector.x, Floor * 2, vector.y, type));
		return result;
	}

	private float TriangleDistance(TriangleNode a, TriangleNode b, TriangleNode to)
	{
		if (a == null || b == null)
		{
			return 0f;
		}
		UpdateCenter(a, to);
		UpdateCenter(b, to);
		Vector2 vector = ((a.PathToggle == TriangleNode.MainPathToggle) ? a.preferredPoint : a.Center);
		Vector2 vector2 = ((b.PathToggle == TriangleNode.MainPathToggle) ? b.preferredPoint : b.Center);
		if (b.PathToggle == TriangleNode.MainPathToggle)
		{
			float num = float.MaxValue;
			for (int i = 0; i < 3; i++)
			{
				Vector2 res;
				if (Utilities.GetLineIntersectionClamped(b.Points[i], b.Points[(i + 1) % 3], vector, to.Center, -0.1f, 1.1f, out res))
				{
					float sqrMagnitude = (res - to.Center).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						vector2 = res;
					}
				}
			}
		}
		return (vector - vector2).magnitude * a.Weight.GetOrDefault(b, 1f);
	}

	private float TriangleHeuristic(TriangleNode from, TriangleNode a, TriangleNode b)
	{
		if (a == null || b == null || a == b)
		{
			return 0f;
		}
		UpdateCenter(a, b);
		float num = ((from == a) ? 0.5f : from.Weight.GetOrDefault(a, 1f));
		return (a.preferredPoint - b.Center).magnitude * num;
	}

	private void UpdateCenter(TriangleNode current, TriangleNode end)
	{
		if (current.PathToggle != TriangleNode.MainPathToggle && !current.StartEnd)
		{
			current.PathToggle = TriangleNode.MainPathToggle;
			current.preferredPoint = Utilities.ClosestPointOnTriangle(current.Points, end.Center);
		}
	}

	private void EmitDirt()
	{
		EmitDirt(Edges, Floor);
	}

	public static void EmitDirt(IList<WallEdge> edges, int floor, bool connected = true)
	{
		if (!(BuildController.Instance != null))
		{
			return;
		}
		int num = (connected ? edges.Count : (edges.Count - 1));
		for (int i = 0; i < num; i++)
		{
			Vector2 pos = edges[i].Pos;
			Vector2 pos2 = edges[(i + 1) % edges.Count].Pos;
			Vector3 vector = new Vector3(pos.x, floor * 2, pos.y);
			Vector3 vector2 = new Vector3(pos2.x - pos.x, 0f, pos2.y - pos.y);
			Quaternion quaternion = new Vector3(pos.x - pos2.x, 0f, pos.y - pos2.y).LookDir();
			int num2 = Mathf.RoundToInt(vector2.magnitude * 5f);
			float num3 = 0.5f;
			for (int j = 0; j < num2; j++)
			{
				float value = UnityEngine.Random.value;
				EmitDirt(vector + vector2 * value, Vector3.up * UnityEngine.Random.Range(2f * num3, 4f * num3) - quaternion * Vector3.right * UnityEngine.Random.Range(2f * num3, 5f * num3) - quaternion * Vector3.forward * (value - 0.5f) * UnityEngine.Random.Range(2f * num3, 5f * num3));
			}
		}
	}

	public static void EmitDirt(Vector3 position, Vector3 velocity)
	{
		BuildController.Instance.DirtEmitter.Emit(new ParticleSystem.EmitParams
		{
			position = position,
			velocity = velocity
		}, 1);
	}

	private void SetSizes(bool initial)
	{
		UpdateBounds(initial);
		_firePoints.Clear();
		_outsideFirePoints.Clear();
		int num = Mathf.FloorToInt(RoomBounds.xMin);
		int num2 = Mathf.FloorToInt(RoomBounds.yMin);
		int num3 = Mathf.CeilToInt(RoomBounds.xMax);
		int num4 = Mathf.CeilToInt(RoomBounds.yMax);
		for (int i = num; i < num3; i++)
		{
			for (int j = num2; j < num4; j++)
			{
				float f = UnityEngine.Random.value * (float)Math.PI * 2f;
				float value = UnityEngine.Random.value;
				Vector2 vector = new Vector2((float)i + 0.5f + Mathf.Cos(f) * value, (float)j + 0.5f + Mathf.Sin(f) * value);
				if (IsInside(vector))
				{
					_firePoints.Add(vector.ToVector3(Floor * 2));
				}
			}
		}
		for (int k = 0; k < Edges.Count; k++)
		{
			WallEdge wallEdge = Edges[k];
			WallEdge wallEdge2 = Edges[(k + 1) % Edges.Count];
			if (!wallEdge2.Links.ContainsValue(wallEdge))
			{
				Vector2 vector2 = wallEdge2.Pos - wallEdge.Pos;
				float magnitude = vector2.magnitude;
				vector2 /= magnitude;
				for (float num5 = 0f; num5 < magnitude; num5 += 1f)
				{
					_outsideFirePoints.Add((wallEdge.Pos + vector2 * num5).ToVector3(Floor * 2));
				}
			}
		}
		UpdateRoomCenter();
		UpdateLabelPosition();
		DustParticles.transform.position = new Vector3(Center.x, Floor * 2 + 1, Center.y);
		DustParticles.transform.localScale = new Vector3(RoomBounds.width * 2f, 1f, RoomBounds.height * 2f);
	}

	private void UpdateRoomCenter()
	{
		Center = Utilities.GetPolygonCentroid(Edges);
		float num = 0f;
		if (IsRect || Edges.Count <= 3 || IsInside(Center))
		{
			return;
		}
		for (int i = 0; i < Edges.Count - 2; i++)
		{
			for (int j = 0; j < Edges.Count - 3; j++)
			{
				int num2 = j + i + 2;
				if (num2 >= Edges.Count)
				{
					break;
				}
				Vector2 pos = Edges[i].Pos;
				Vector2 pos2 = Edges[num2].Pos;
				float sqrMagnitude = (pos - pos2).sqrMagnitude;
				if (!(sqrMagnitude > num))
				{
					continue;
				}
				bool flag = true;
				for (int k = 0; k < Edges.Count; k++)
				{
					if (k == i || k == num2)
					{
						continue;
					}
					int num3 = (k + 1) % Edges.Count;
					if (num3 != i && num3 != num2)
					{
						Vector2 pos3 = Edges[k].Pos;
						Vector2 pos4 = Edges[num3].Pos;
						if (Utilities.LinesIntersect(pos, pos2, pos3, pos4, false, true))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					Vector2 vector = (pos + pos2) * 0.5f;
					if (IsInside(vector))
					{
						num = sqrMagnitude;
						Center = vector;
					}
				}
			}
		}
	}

	private void UpdateLabelPosition()
	{
		TeamTextScript teamText = TeamText;
		Vector3 origPos = (TeamText.transform.position = new Vector3(Center.x, Floor * 2 + 4, Center.y));
		teamText.OrigPos = origPos;
		TeamTextScript roleText = RoleText;
		origPos = (RoleText.transform.position = new Vector3(Center.x, (float)(Floor * 2) + 3.3f, Center.y));
		roleText.OrigPos = origPos;
	}

	public void ChangeRole(int role)
	{
		Array values = Enum.GetValues(typeof(RoomLimits));
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < values.Length; i++)
		{
			int a = (int)values.GetValue(i);
			num = Mathf.Min(a, num);
			num2 = Mathf.Max(a, num2);
		}
		role = Mathf.Clamp(role, num, num2);
		ForceRole = role;
		TextMesh tm = RoleText.tm;
		RoomLimits roomLimits = (RoomLimits)role;
		tm.text = roomLimits.ToString().Loc();
		RoleText.InUse = ForceRole != -1;
	}

	public void Init(IEnumerable<WallEdge> s, int floor, bool emitDirt, List<UndoObject.UndoAction> undos, bool dummy = false, bool OptimizeNow = true, bool initDID = true)
	{
		if (!dummy && initDID)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.Construction);
		}
		Dummy = dummy;
		Floor = floor;
		if (!dummy)
		{
			if (initDID)
			{
				InitWritable();
			}
			Edges = s.ToList();
			for (int i = 0; i < Edges.Count; i++)
			{
				Edges[i].Floor = floor;
			}
			if (Clockwise(Edges))
			{
				Edges.Reverse();
			}
			GameSettings.Instance.sRoomManager.AddRoom(this);
		}
		TeamText.gameObject.SetActive(GameSettings.Instance.sRoomManager.TeamText);
		RoleText.gameObject.SetActive(GameSettings.Instance.sRoomManager.TeamText);
		if (Temperature == 0f)
		{
			Temperature = TimeOfDay.Instance.Temperature;
		}
		if (!dummy)
		{
			if (DirtMesh.sharedMesh == null)
			{
				Mesh mesh = new Mesh();
				mesh.MarkDynamic();
				DirtMesh.sharedMesh = mesh;
			}
			for (int j = 0; j < Edges.Count; j++)
			{
				WallEdge wallEdge = Edges[j];
				WallEdge value = Edges[(j + 1) % Edges.Count];
				wallEdge.Links[this] = value;
			}
			if (!Deserialized && OptimizeNow)
			{
				OptimizeSegments();
			}
			if (emitDirt)
			{
				EmitDirt();
			}
			foreach (Room item in Edges.SelectMany((WallEdge x) => x.Links.Keys).OfType<Room>().Distinct())
			{
				item.DirtyOuterMesh = true;
			}
			SetSizes(true);
			if (emitDirt && Floor == 0)
			{
				GameSettings.Instance.SetTreeShake(Center);
			}
			Area = Utilities.PolygonArea(Edges);
			UpdateDirtScore(false);
			if (!Deserialized && MaterialPreviewer.Instance.gameObject.activeSelf)
			{
				MaterialPreviewer.Instance.GetActiveStyle().Apply(this, null);
			}
			GameSettings.Instance.sRoomManager.AddRoom(this);
			GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
			GameSettings.Instance.sRoomManager.CCTVDirty = true;
			if (!Deserialized && Floor > -1 && Floor < 3)
			{
				RemoveTrees(undos);
				if (Floor == 0)
				{
					GrassSystem.Instance.InvalidateArea();
				}
			}
		}
		else
		{
			UpdatePathNodes(false);
		}
	}

	public void RefreshEdges(List<UndoObject.UndoAction> undos, bool clone)
	{
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			WallEdge key = Edges[(i + 1) % Edges.Count];
			HashSet<WallSnap> value;
			if (!wallEdge.Children.TryGetValue(key, out value))
			{
				continue;
			}
			foreach (WallSnap item in value.ToList())
			{
				if (item.IsAliveNotNull() && !item.EdgeChanged(clone) && undos != null)
				{
					undos.Add(new UndoObject.UndoAction(item, false));
				}
			}
		}
	}

	public void RemoveTrees(List<UndoObject.UndoAction> undos)
	{
		HashSet<TreeInstance> hashSet = new HashSet<TreeInstance>();
		bool flag = false;
		foreach (TreeInstance item in GameSettings.Instance.TreeTree.Query(RoomBounds.Expand(6f, 6f)))
		{
			Vector2 pos = item.GetPos();
			StaticTree treeMesh = item.TreeMesh;
			float num = Mathf.Max(treeMesh.bounds.size.x, treeMesh.bounds.size.z);
			if (RoomBounds.ContainsEntirely(pos, num / 2f) && IsInside(pos, 0f - num))
			{
				hashSet.Add(item);
				flag = true;
			}
		}
		if (!flag)
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

	private float FixRot(float rot)
	{
		rot %= 360f;
		if (rot != 360f)
		{
			return rot;
		}
		return 0f;
	}

	private Vector3I FixPos(Vector3I input, float rot)
	{
		return new Vector3I(input.x + (Mathf.Approximately(rot, 180f) ? (-1) : 0) + (Mathf.Approximately(rot, 0f) ? 1 : 0), input.y, input.z + (Mathf.Approximately(rot, 270f) ? 1 : 0) + (Mathf.Approximately(rot, 90f) ? (-1) : 0));
	}

	private static CombineInstance CombineFromMesh(MeshFilter mesh)
	{
		return new CombineInstance
		{
			mesh = mesh.sharedMesh,
			transform = mesh.transform.localToWorldMatrix
		};
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		RoomBounds = dictionary.Get("RoomBounds", new SRect(0f, 0f, 0f, 0f)).ToRect();
		IsRect = Edges.IsAlignedRectangle();
		Floor = (int)dictionary["Floor"];
		RoomGroup = dictionary.Get<string>("RoomGroup", null);
		Outdoors = dictionary.Get("Outdoors", false);
		Pillar = dictionary.Get("Pillar", false);
		InsideMat = (string)dictionary["InsideMat"];
		OutsideMat = (string)dictionary["OutsideMat"];
		FloorMat = (string)dictionary["FloorMat"];
		InsideColor = ((SVector3)dictionary["InsideColor"]).ToColor();
		FloorColor = ((SVector3)dictionary["FloorColor"]).ToColor();
		FloorColor2 = dictionary.Get("FloorColor2", (SVector3)FloorColor.GetDefaultSecondaryColor());
		InsideColor2 = dictionary.Get("InsideColor2", (SVector3)InsideColor.GetDefaultSecondaryColor());
		if (Outdoors)
		{
			if (dictionary.Contains("FenceColor"))
			{
				FenceColor = ((SVector3)dictionary["FenceColor"]).ToColor();
				OutsideColor = ((SVector3)dictionary["OutsideColor"]).ToColor();
			}
			else
			{
				Color outsideColor = (FenceColor = ((SVector3)dictionary["OutsideColor"]).ToColor());
				OutsideColor = outsideColor;
			}
		}
		else
		{
			OutsideColor = ((SVector3)dictionary["OutsideColor"]).ToColor();
			OutsideColor2 = dictionary.Get("OutsideColor2", (SVector3)OutsideColor.GetDefaultSecondaryColor());
			FenceColor = dictionary.Get("FenceColor", (SVector3)FenceColor);
		}
		_fenceStyle = dictionary.Get("FenceStyle", "Concrete");
		FenceHeight = ObjectDatabase.Instance.FenceStyles.First((ObjectDatabase.FenceStyle x) => x.Name.Equals(_fenceStyle)).Height;
		TempTeam = dictionary.Get("Teams", new string[0]);
		Temperature = dictionary.Get("Temperature", 0f);
		ChangeRole(dictionary.Get("Role", -1));
		TempHeatDirectUsage = dictionary.Get("TempHeatDirectUsage", 0f);
		TempHeatControlUsage = dictionary.Get("TempHeatControlUsage", 0f);
		TempCoolDirectUsage = dictionary.Get("TempCoolDirectUsage", 0f);
		TempCoolControlUsage = dictionary.Get("TempCoolControlUsage", 0f);
		if (loading && dictionary.Contains("AtriumParent"))
		{
			uint num = dictionary.Get("AtriumParent", 0u);
			if (num != 0)
			{
				if (num == DID)
				{
					AtriumParent = this;
					RefreshTextureTiling();
				}
				else
				{
					Room room = GetDeserializedObject(num) as Room;
					if (room != null)
					{
						AtriumParent = room;
						room.AtriumChildren.Add(this);
						room.RefreshTextureTiling();
					}
				}
			}
		}
		RefreshDirtQuad();
		if (dictionary.Contains("DirtSpots3"))
		{
			List<Dirt> list = dictionary.Get<List<Dirt>>("DirtSpots3", null);
			if (list != null)
			{
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					AddNewDirt(list[num2].Pos, list[num2].Amount, list[num2].Type, list[num2].Rot);
				}
			}
		}
		else
		{
			SVector3[] array = dictionary.Get<SVector3[]>("DirtSpots2", null);
			if (array != null)
			{
				for (int num3 = 0; num3 < array.Length; num3++)
				{
					Vector2 vector = array[num3];
					if (RoomBounds.Contains(vector))
					{
						AddNewDirt(vector, array[num3].z, 0, array[num3].w);
					}
				}
			}
			else
			{
				List<Vector2> list2 = ((IList<SVector3>)dictionary.Get("DirtSpots", Array.Empty<SVector3>())).Select((Func<SVector3, Vector2>)((SVector3 x) => x)).ToList();
				List<float> list3 = dictionary.Get("DirtAmount", Array.Empty<float>()).ToList();
				for (int num4 = 0; num4 < list2.Count; num4++)
				{
					if (RoomBounds.Contains(list2[num4]))
					{
						AddNewDirt(list2[num4], list3[num4], 0, null);
					}
				}
			}
		}
		UpdateDirtScore(false);
		Reservers = dictionary.Get("Reservers", 0);
		SerializedParentRoom = dictionary.Get("ParentRoom", DID);
		SerializedChildrenRooms = dictionary.Get<uint[]>("ChildrenRooms", null);
		_rentable = dictionary.Get("Rentable", true);
		_playerOwned = dictionary.Get("PlayerOwned", false);
		GermCount = dictionary.Get("GermCount", 0f);
		IsOnFire = dictionary.Get("IsOnFire", false);
		if (IsOnFire)
		{
			GameSettings.Instance.AddToFireCounter();
		}
		Burn = dictionary.Get("Burn", 0f);
		BurnStop = dictionary.Get("BurnStop", 0f);
		if (!loading)
		{
			uint roofing = dictionary.Get("Roofing", 0u);
			if (roofing != 0)
			{
				Roof roof = GameSettings.Instance.sRoomManager.Roofs.FirstOrDefault((Roof x) => x.DID == roofing);
				if (roof != null)
				{
					Roofing = roof;
					if (!roof.RoofOf.Contains(this))
					{
						roof.RoofOf.Add(this);
					}
				}
			}
		}
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["RoomBounds"] = (SRect)RoomBounds;
		dictionary["Floor"] = Floor;
		dictionary["RoomGroup"] = RoomGroup;
		dictionary["InsideMat"] = InsideMat;
		dictionary["OutsideMat"] = OutsideMat;
		dictionary["FloorMat"] = FloorMat;
		dictionary["TempHeatDirectUsage"] = TempHeatDirectUsage;
		dictionary["TempHeatControlUsage"] = TempHeatControlUsage;
		dictionary["TempCoolDirectUsage"] = TempCoolDirectUsage;
		dictionary["TempCoolControlUsage"] = TempCoolControlUsage;
		dictionary["Roofing"] = ((!(Roofing == null)) ? Roofing.DID : 0u);
		if (AtriumParent != null)
		{
			dictionary["AtriumParent"] = AtriumParent.DID;
		}
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			dictionary["InsideColor"] = (SVector3)InsideColor;
			dictionary["FloorColor"] = (SVector3)FloorColor;
			dictionary["OutsideColor"] = (SVector3)OutsideColor;
			dictionary["InsideColor2"] = (SVector3)InsideColor2;
			dictionary["FloorColor2"] = (SVector3)FloorColor2;
			dictionary["OutsideColor2"] = (SVector3)OutsideColor2;
			dictionary["FenceColor"] = (SVector3)FenceColor;
			dictionary["Teams"] = Teams.Select((Team x) => x.Name).ToArray();
			dictionary["Role"] = ForceRole;
			dictionary["Temperature"] = Temperature;
			dictionary["DirtSpots3"] = Dirts;
			dictionary["Reservers"] = Reservers;
			dictionary["GermCount"] = GermCount;
			dictionary["IsOnFire"] = IsOnFire;
			dictionary["Burn"] = Burn;
			dictionary["BurnStop"] = BurnStop;
			dictionary["DirtSpots2"] = Dirts.Select((Dirt x) => new SVector3(x.Pos.x, x.Pos.y, x.Amount, x.Rot)).ToArray();
		}
		else
		{
			dictionary["InsideColor"] = (SVector3)InsideColor.Alpha(1f);
			dictionary["FloorColor"] = (SVector3)FloorColor.Alpha(1f);
			dictionary["OutsideColor"] = (SVector3)OutsideColor.Alpha(1f);
			dictionary["InsideColor2"] = (SVector3)InsideColor2.Alpha(1f);
			dictionary["FloorColor2"] = (SVector3)FloorColor2.Alpha(1f);
			dictionary["OutsideColor2"] = (SVector3)OutsideColor2.Alpha(1f);
			dictionary["FenceColor"] = (SVector3)FenceColor.Alpha(1f);
		}
		dictionary["Outdoors"] = Outdoors;
		dictionary["Pillar"] = Pillar;
		dictionary["FenceStyle"] = FenceStyle;
		dictionary["ParentRoom"] = ((ParentRoom == null) ? DID : ParentRoom.DID);
		dictionary["ChildrenRooms"] = ChildrenRooms.Select((Room x) => x.DID).ToArray();
		dictionary["Rentable"] = Rentable;
		dictionary["PlayerOwned"] = PlayerOwned;
		dictionary["Roofing"] = ((!(Roofing == null)) ? Roofing.DID : 0u);
	}

	private Room GetRoom(uint did, Room defaultValue)
	{
		object obj = (GetDeserializedObject(did) as Room) ?? GameSettings.Instance.sRoomManager.GetRooms().FirstOrDefault((Room x) => x.DID == did);
		if (obj == null)
		{
			obj = defaultValue;
		}
		return (Room)obj;
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		if (SerializedChildrenRooms == null)
		{
			return;
		}
		ParentRoom = GetRoom(SerializedParentRoom, this);
		ChildrenRooms.AddRange(from x in SerializedChildrenRooms
			select GetRoom(x, null) into x
			where x != null
			select x);
		ChildrenRooms.Remove(this);
		if (ParentRoom == this)
		{
			ChildrenRooms.ToList().ForEach(delegate(Room x)
			{
				x.GroupTo(this);
			});
		}
		else if (!ParentRoom.ChildrenRooms.Contains(this))
		{
			Room parent = ParentRoom.ParentRoom ?? ParentRoom;
			ChildrenRooms.ToList().ForEach(delegate(Room x)
			{
				if (x.ParentRoom == this)
				{
					x.UnGroup();
				}
			});
			ChildrenRooms.Clear();
			GroupTo(parent);
		}
		if (AtriumChildren.Count > 0)
		{
			AtriumChildren.Sort((Room x, Room y) => x.Floor.CompareTo(y.Floor));
		}
	}

	public override string WriteName()
	{
		return "Room";
	}

	public float GetEnvironment()
	{
		return Mathf.Clamp(FurnEnvironment * DirtScore, 0f, 2f);
	}

	public void CopyOverSettings(Room other)
	{
		other.Outdoors = Outdoors;
		other.SetFenceStyle(FenceStyle, null);
		other.FloorMat = FloorMat;
		other.FloorColor = FloorColor;
		other.FloorColor2 = FloorColor2;
		other.InsideMat = InsideMat;
		other.InsideColor = InsideColor;
		other.InsideColor2 = InsideColor2;
		other.OutsideMat = OutsideMat;
		other.OutsideColor = OutsideColor;
		other.OutsideColor2 = OutsideColor2;
		other.FenceColor = FenceColor;
		other.UpdateTeams(Teams);
		other.ForceRole = ForceRole;
		other.UnGroup();
		other._rentable = Rentable;
		other._playerOwned = PlayerOwned;
		other.Roofing = Roofing;
		if (Roofing != null)
		{
			Roofing.RoofOf.Add(other);
		}
		if (ParentRoom != this || ChildrenRooms.Count > 0)
		{
			other.ParentRoom = ParentRoom;
			ParentRoom.ChildrenRooms.Add(other);
		}
	}

	private void RefreshDirtQuad()
	{
		DirtTree = new GridQuery<Dirt>(new Rect(RoomBounds.xMin, RoomBounds.yMin, RoomBounds.width + 1f, RoomBounds.height + 1f));
		for (int i = 0; i < Dirts.Count; i++)
		{
			DirtTree.Add(Dirts[i]);
		}
	}

	public List<Dirt> QueryDirtQuad(Rect query)
	{
		if (DirtTree != null)
		{
			return DirtTree.Query(query);
		}
		return Dirts;
	}

	public void DirtyUp(int amount, int type = 0)
	{
		for (int i = 0; i < amount; i++)
		{
			AddDirt(new Vector2(UnityEngine.Random.Range(RoomBounds.xMin, RoomBounds.xMax), UnityEngine.Random.Range(RoomBounds.yMin, RoomBounds.yMax)), 1f, null, type);
		}
	}

	public float AddDirt(Vector2 vec, float amount = 0.5f, Vector2? dir = null, int type = 0)
	{
		if (amount > 0f && (DisableDirt || (GameSettings.Instance.RentMode && (!PlayerOwned || !Rentable))))
		{
			return amount;
		}
		if (amount > 0f)
		{
			float awardValue = GetAwardValue(AwardTrophy.BuffType.Dirt);
			if (awardValue > 0f && UnityEngine.Random.value < awardValue)
			{
				return 0f;
			}
		}
		Dirt dirt = null;
		Rect query = new Rect(vec.x - 1f, vec.y - 1f, 2f, 2f);
		List<Dirt> list = QueryDirtQuad(query);
		for (int i = 0; i < list.Count; i++)
		{
			Dirt dirt2 = list[i];
			if ((amount < 0f || (dirt2.Type == type && dirt2.Amount < 1f && (dirt2.Amount < 0.75f || UnityEngine.Random.value > 0.5f))) && (vec - dirt2.Pos).sqrMagnitude <= ((amount > 0f) ? 0.25f : 1f))
			{
				dirt = dirt2;
				break;
			}
		}
		if (dirt == null && amount > 0f)
		{
			if (!FixDirtPos(ref vec))
			{
				return 0f;
			}
			query = new Rect(vec.x - 1f, vec.y - 1f, 2f, 2f);
			list = QueryDirtQuad(query);
			for (int j = 0; j < list.Count; j++)
			{
				Dirt dirt3 = list[j];
				if (dirt3.Type == type && dirt3.Amount < 1f && (dirt3.Amount < 0.75f || UnityEngine.Random.value > 0.5f) && (vec - dirt3.Pos).sqrMagnitude <= 0.25f)
				{
					dirt = dirt3;
					break;
				}
			}
		}
		if (dirt == null && amount > 0f)
		{
			AddNewDirt(vec, amount, type, dir.HasValue ? new float?(Mathf.Atan2(dir.Value.x, dir.Value.y) * 57.29578f) : ((float?)null));
			UpdateDirtScore();
			return amount;
		}
		if (dirt != null)
		{
			if (amount > 0f)
			{
				if (dirt.Amount + amount > 1f)
				{
					float result = 1f - dirt.Amount;
					dirt.Amount = 1f;
					UpdateDirtTrans(dirt.Index);
					UpdateDirtScore();
					return result;
				}
				dirt.Amount += amount;
				UpdateDirtTrans(dirt.Index);
				UpdateDirtScore();
				return amount;
			}
			dirt.Amount += amount;
			if (dirt.Amount <= 0f)
			{
				RemoveDirt(dirt.Index);
				UpdateDirtScore();
				return 0f - dirt.Amount;
			}
			UpdateDirtTrans(dirt.Index);
			UpdateDirtScore();
			if (!(amount < 0f))
			{
				return amount;
			}
			return 0f;
		}
		return 0f;
	}

	public float GetDirt(float x, float y)
	{
		Vector2 vector = new Vector2(x, y);
		List<Dirt> list = QueryDirtQuad(new Rect(x - 1f, y - 1f, 2f, 2f));
		for (int i = 0; i < list.Count; i++)
		{
			if ((vector - list[i].Pos).sqrMagnitude <= 1f)
			{
				return list[i].Amount;
			}
		}
		return 0f;
	}

	private void FurnitureValidCheck(List<UndoObject.UndoAction> undos, Dictionary<WallSnap, UndoObject.UndoAction> snaps)
	{
		List<Furniture> list;
		lock (_furnitures)
		{
			list = _furnitures.ToList();
		}
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			UndoObject.UndoAction undoAction = ((snaps != null) ? snaps.GetOrNull(furniture) : null);
			if (furniture.OnlyOnGrass && !"None".Equals(FloorMat) && Outside)
			{
				if (undos != null && furniture.IsAliveNotNull())
				{
					undos.Add(undoAction ?? new UndoObject.UndoAction(furniture, false));
				}
				furniture.DestroyGO();
			}
			else if (Outdoors)
			{
				if (!furniture.ValidOutdoors)
				{
					if (undos != null && furniture.IsAliveNotNull())
					{
						undos.Add(undoAction ?? new UndoObject.UndoAction(furniture, false));
					}
					furniture.DestroyGO();
				}
			}
			else if (!furniture.ValidIndoors)
			{
				if (undos != null && furniture.IsAliveNotNull())
				{
					undos.Add(undoAction ?? new UndoObject.UndoAction(furniture, false));
				}
				furniture.DestroyGO();
			}
		}
	}

	public void UpdateDirtScore(bool warning = true)
	{
		float num = 0f;
		for (int i = 0; i < Dirts.Count; i++)
		{
			num += Dirts[i].Amount;
		}
		num /= Area * 0.8f;
		DisableDirt = num > 2f;
		DirtScore = Mathf.Clamp01(1f - num);
	}

	private void UpdateDirtTrans(int num)
	{
		for (int i = 0; i < 4; i++)
		{
			_dirtUV2[num * 4 + i] = new Vector2(Dirts[num].Amount, 0f);
		}
		DirtMesh.sharedMesh.SetUVs(1, _dirtUV2);
	}

	public void ClearDirt()
	{
		int count = Dirts.Count;
		for (int i = 0; i < count; i++)
		{
			RemoveDirt(0);
		}
		UpdateDirtScore(false);
	}

	public void RefreshDirtNavmesh()
	{
	}

	public void RemoveDirtAt(Vector2 vec)
	{
		for (int i = 0; i < Dirts.Count; i++)
		{
			if ((vec - Dirts[i].Pos).sqrMagnitude <= 1f)
			{
				RemoveDirt(i);
				i--;
			}
		}
	}

	public bool AllowedInRoom(Actor act)
	{
		if (ForceRole == -5)
		{
			if (act.AItype != AI.AIType.Guest)
			{
				return act.AItype == AI.AIType.Receptionist;
			}
			return true;
		}
		if (!act.IsEmployee())
		{
			return true;
		}
		if (GameSettings.Instance.RentMode && Rentable && !PlayerOwned)
		{
			return false;
		}
		if (Teams.Count == 0)
		{
			if (act.GetTeam() != null)
			{
				HashSet<Team> actuallyAllowed = GetActuallyAllowed();
				if (actuallyAllowed != null && !actuallyAllowed.Contains(act.GetTeam()))
				{
					return false;
				}
			}
			if (ForceRole >= 0)
			{
				return (Employee.RoleToMask[ForceRole] & act.GetRole()) > Employee.RoleBit.None;
			}
			return true;
		}
		if (ForceRole < 0)
		{
			return CompatibleWithTeam(act.GetTeam());
		}
		if ((Employee.RoleToMask[ForceRole] & act.GetRole()) > Employee.RoleBit.None)
		{
			return CompatibleWithTeam(act.GetTeam());
		}
		return false;
	}

	public int OrderByRole(int role)
	{
		if (role < 0)
		{
			if (ForceRole != role)
			{
				return 1;
			}
			return 0;
		}
		if (ForceRole < 0)
		{
			return 1;
		}
		if ((role & Employee.RoleToBit[0]) > 0)
		{
			if (ForceRole != 0)
			{
				return 1;
			}
			return 0;
		}
		if ((Employee.RoleToBit[ForceRole] & role) <= 0)
		{
			return 1;
		}
		return 0;
	}

	public bool AllowedInRoom(Team team, Employee.RoleBit role, bool ignoreRole)
	{
		if (GameSettings.Instance.RentMode && Rentable && !PlayerOwned)
		{
			return false;
		}
		if (Teams.Count == 0)
		{
			if (!ignoreRole && ForceRole >= 0)
			{
				return (Employee.RoleToMask[ForceRole] & role) > Employee.RoleBit.None;
			}
			return true;
		}
		if (ForceRole < 0)
		{
			return CompatibleWithTeam(team);
		}
		if (ignoreRole || (Employee.RoleToMask[ForceRole] & role) > Employee.RoleBit.None)
		{
			return CompatibleWithTeam(team);
		}
		return false;
	}

	public void RemoveDirt(int num)
	{
		Dirt dirt = Dirts[num];
		int subMesh = dirt.SubMesh;
		if (DirtTree != null)
		{
			DirtTree.Remove(dirt);
		}
		Dirts.RemoveAt(num);
		for (int i = num; i < Dirts.Count; i++)
		{
			Dirts[i].Index--;
			if (Dirts[i].SubMesh == subMesh)
			{
				Dirts[i].MeshIndex--;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			_dirtUV1.RemoveAt(num * 4);
			_dirtUV2.RemoveAt(num * 4);
			_dirtVector.RemoveAt(num * 4);
			_dirtNormal.RemoveAt(num * 4);
		}
		for (int k = 0; k < _dirtIndex.Count; k++)
		{
			if (_dirtIndex[k] > num * 4)
			{
				_dirtIndex[k] -= 4;
			}
		}
		for (int l = 0; l < _dirtIndex2.Count; l++)
		{
			if (_dirtIndex2[l] > num * 4)
			{
				_dirtIndex2[l] -= 4;
			}
		}
		List<int> list = ((subMesh == 0) ? _dirtIndex : _dirtIndex2);
		for (int m = 0; m < 6; m++)
		{
			list.RemoveAt(dirt.MeshIndex * 6);
		}
		Mesh sharedMesh = DirtMesh.sharedMesh;
		sharedMesh.SetTriangles(_dirtIndex, 0);
		sharedMesh.SetTriangles(_dirtIndex2, 1);
		sharedMesh.SetVertices(_dirtVector);
		sharedMesh.SetUVs(0, _dirtUV1);
		sharedMesh.SetUVs(1, _dirtUV2);
		sharedMesh.SetNormals(_dirtNormal);
		if (subMesh == 0)
		{
			_dirt1Count--;
		}
		else
		{
			_dirt2Count--;
		}
	}

	private bool FixDirtPos(ref Vector2 v)
	{
		List<Dirt> list = QueryDirtQuad(new Rect(v.x - 1f, v.y - 1f, 2f, 2f));
		for (int i = 0; i < list.Count; i++)
		{
			Vector2 vector = v - list[i].Pos;
			if (vector.sqrMagnitude < 1f)
			{
				v += vector.normalized * UnityEngine.Random.Range(0.25f, 1f);
				break;
			}
		}
		if (!IsInside(v))
		{
			float num = float.MaxValue;
			Vector2 vector2 = v;
			for (int j = 0; j < Edges.Count; j++)
			{
				Vector2 pos = Edges[j].Pos;
				Vector2 pos2 = Edges[(j + 1) % Edges.Count].Pos;
				Vector2 vector3 = Utilities.ProjectToLineEndlessClamped(v, pos, pos2);
				float sqrMagnitude = (vector3 - v).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					vector2 = vector3 + (pos2 - pos).normalized.Turn90() * 0.5f;
				}
			}
			if (num >= 1f)
			{
				return false;
			}
			v = vector2;
		}
		else
		{
			for (int k = 0; k < Edges.Count; k++)
			{
				Vector2 pos3 = Edges[k].Pos;
				Vector2 pos4 = Edges[(k + 1) % Edges.Count].Pos;
				Vector2 res;
				if (!Utilities.ProjectToLine(v, pos3, pos4, out res))
				{
					continue;
				}
				Vector2 vector4 = v - res;
				float magnitude = vector4.magnitude;
				if (magnitude > 0f)
				{
					float num2 = 0.5f - magnitude;
					if (num2 > 0f)
					{
						vector4 *= 1f / magnitude;
						v += vector4 * num2;
					}
				}
				else
				{
					v += (pos4 - pos3).Turn90() * 0.5f;
				}
			}
		}
		if (DirtTree != null)
		{
			return DirtTree.Contains(v);
		}
		return true;
	}

	private Vector2 FindClosestWallPos(Vector2 p, Vector2 Def)
	{
		float num = float.MaxValue;
		Vector2 result = Def;
		for (int i = 0; i < Edges.Count; i++)
		{
			int index = (i + 1) % Edges.Count;
			Vector2 pos = Edges[i].Pos;
			Vector2 pos2 = Edges[index].Pos;
			Vector2 res;
			if (Utilities.ProjectToLine(p, pos, pos2, out res))
			{
				float sqrMagnitude = (res - p).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = res;
					num = sqrMagnitude;
				}
			}
		}
		return result;
	}

	public void AddNewDirt(Vector2 pos, float amount, int type, float? rott)
	{
		int num = ObjectDatabase.Instance.DirtSubmesh[type];
		Dirt dirt = new Dirt(mIdx: (num == 0) ? _dirt1Count : _dirt2Count, pos: pos, rot: rott ?? ((float)UnityEngine.Random.Range(0, 360)), amount: amount, idx: Dirts.Count, type: type);
		if (num == 0)
		{
			_dirt1Count++;
		}
		else
		{
			_dirt2Count++;
		}
		if (DirtTree != null)
		{
			DirtTree.Add(dirt);
		}
		Dirts.Add(dirt);
		Quaternion quaternion = Quaternion.Euler(0f, dirt.Rot, 0f);
		Vector3 vector = new Vector3(pos.x, Floor * 2, pos.y);
		Vector2Int vector2Int = ObjectDatabase.Instance.DirtTypes[type];
		int num2 = UnityEngine.Random.Range(vector2Int.x, vector2Int.y);
		float num3 = ObjectDatabase.Instance.GetDirtScale(num2) * 0.5f;
		int dirtAtlasSize = ObjectDatabase.Instance.DirtAtlasSize;
		float num4 = (float)(num2 % dirtAtlasSize) / (float)dirtAtlasSize;
		float num5 = (float)(dirtAtlasSize - 1 - num2 / dirtAtlasSize) / (float)dirtAtlasSize;
		float y = Mathf.Min((float)Dirts.Count / 10000f, 0.01f);
		_dirtVector.Add(vector + quaternion * new Vector3(0f - num3, y, 0f - num3));
		_dirtVector.Add(vector + quaternion * new Vector3(num3, y, 0f - num3));
		_dirtVector.Add(vector + quaternion * new Vector3(num3, y, num3));
		_dirtVector.Add(vector + quaternion * new Vector3(0f - num3, y, num3));
		int count = _dirtVector.Count;
		List<int> obj = ((num == 0) ? _dirtIndex : _dirtIndex2);
		obj.Add(count - 2);
		obj.Add(count - 3);
		obj.Add(count - 4);
		obj.Add(count - 4);
		obj.Add(count - 1);
		obj.Add(count - 2);
		float num6 = 1f / (float)dirtAtlasSize;
		_dirtUV1.Add(new Vector2(num4, num5));
		_dirtUV1.Add(new Vector2(num4 + num6, num5));
		_dirtUV1.Add(new Vector2(num4 + num6, num5 + num6));
		_dirtUV1.Add(new Vector2(num4, num5 + num6));
		_dirtUV2.Add(new Vector2(amount, 0f));
		_dirtUV2.Add(new Vector2(amount, 0f));
		_dirtUV2.Add(new Vector2(amount, 0f));
		_dirtUV2.Add(new Vector2(amount, 0f));
		_dirtNormal.Add(Vector3.up);
		_dirtNormal.Add(Vector3.up);
		_dirtNormal.Add(Vector3.up);
		_dirtNormal.Add(Vector3.up);
		Mesh mesh = DirtMesh.sharedMesh;
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.MarkDynamic();
			DirtMesh.sharedMesh = mesh;
		}
		mesh.SetVertices(_dirtVector);
		mesh.SetUVs(0, _dirtUV1);
		mesh.SetUVs(1, _dirtUV2);
		mesh.SetNormals(_dirtNormal);
		mesh.subMeshCount = 2;
		mesh.SetTriangles(_dirtIndex, 0);
		mesh.SetTriangles(_dirtIndex2, 1);
	}

	private List<int> GetPathNodeCounts()
	{
		List<int> list = new List<int>(PathNodes.Count + 1);
		list.Add(PathNodes.Count);
		for (int i = 0; i < PathNodes.Count; i++)
		{
			PathNode<Vector3> pathNode = PathNodes[i];
			List<PathNode<Vector3>> connections = pathNode.GetConnections();
			int num = 0;
			for (int j = 0; j < connections.Count; j++)
			{
				if (connections[j].HasConnection(pathNode))
				{
					num++;
				}
			}
			list.Add(num);
		}
		return list;
	}

	public IEnumerable<IRoomConnector> GetConnectors()
	{
		if (Dummy)
		{
			foreach (PathController.PathPoint endPoint in GameSettings.Instance.sRoomManager.PathController.EndPoints)
			{
				yield return endPoint;
			}
		}
		List<WallSnap> list = GetSegmentsGeneric(new List<WallSnap>());
		for (int i = 0; i < list.Count; i++)
		{
			RoomSegment roomSegment = list[i] as RoomSegment;
			if (roomSegment != null && roomSegment.IsConnecter)
			{
				yield return roomSegment;
			}
		}
		list.Clear();
		lock (_furnitures)
		{
			for (int j = 0; j < _furnitures.Count; j++)
			{
				Furniture furniture = _furnitures[j];
				if (furniture != null && furniture.IsConnecter)
				{
					list.Add(furniture);
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture2;
			if ((object)(furniture2 = list[i] as Furniture) != null)
			{
				yield return furniture2;
			}
		}
		if (!Dummy)
		{
			yield break;
		}
		foreach (RoadSegment groundLevelRamp in RoadManager.Instance.GroundLevelRamps)
		{
			yield return groundLevelRamp;
		}
	}

	private void UpdatePathNodes(bool recalculateGraph = true)
	{
		if (GameSettings.Instance.IsReferenceNull() || HUD.Instance == null || NavMap == null)
		{
			return;
		}
		CanClean = true;
		DirtyPathNodes = false;
		CachedPaths.Clear();
		lock (PathNodes)
		{
			List<int> pathNodeCounts = GetPathNodeCounts();
			for (int i = 0; i < PathNodes.Count; i++)
			{
				PathNode<Vector3> pathNode = PathNodes[i];
				List<PathNode<Vector3>> connections = pathNode.GetConnections();
				for (int j = 0; j < connections.Count; j++)
				{
					connections[j].RemoveConnection(pathNode);
				}
			}
			for (int k = 0; k < SubNodes.Count; k++)
			{
				PathNode<Vector3> pathNode2 = SubNodes[k];
				List<PathNode<Vector3>> connections2 = pathNode2.GetConnections();
				for (int l = 0; l < connections2.Count; l++)
				{
					connections2[l].RemoveConnection(pathNode2);
				}
			}
			SubNodes.Clear();
			PathNodes.Clear();
			List<IRoomConnector> list = (from x in GetConnectors()
				where x.pathNode != null
				select x).ToList();
			if (list.Count == 0)
			{
				PathNode<Vector3> pathNode3 = new PathNode<Vector3>(Vector3.zero, this);
				pathNode3.Tag2 = pathNode3;
				PathNodes.Add(pathNode3);
				if (recalculateGraph)
				{
					GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
				}
				return;
			}
			List<List<IRoomConnector>> list2 = new List<List<IRoomConnector>>();
			list2.Add(new List<IRoomConnector> { list[0] });
			for (int num = 0; num < list.Count; num++)
			{
				list[num].UpdateBlocked();
			}
			for (int num2 = 1; num2 < list.Count; num2++)
			{
				bool flag = false;
				for (int num3 = 0; num3 < list2.Count; num3++)
				{
					if (NodesAccessible(list[num2], list2[num3][0]))
					{
						list2[num3].Add(list[num2]);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2.Add(new List<IRoomConnector> { list[num2] });
				}
			}
			for (int num4 = 0; num4 < list2.Count; num4++)
			{
				PathNode<Vector3> pathNode4 = (Dummy ? new PathNode<Vector3>(Vector3.zero, this) : new PathNode<Vector3>(new Vector3(Center.x, (float)(Floor * 2) + 0.5f, Center.y), this));
				pathNode4.NullWeight = true;
				for (int num5 = 0; num5 < list2[num4].Count; num5++)
				{
					IRoomConnector roomConnector = list2[num4][num5];
					if (roomConnector.AllowExit())
					{
						roomConnector.pathNode.AddConnection(pathNode4);
					}
					if (roomConnector.AllowEntry())
					{
						pathNode4.AddConnection(roomConnector.pathNode);
					}
				}
				pathNode4.Tag2 = pathNode4;
				PathNodes.Add(pathNode4);
			}
			SubdividePathnodes();
			if (Outside)
			{
				lock (this)
				{
					Vector3 position = GameSettings.Instance.BusStopSign.transform.position;
					List<PathVector> result = new List<PathVector>();
					for (int num6 = 0; num6 < PathNodes.Count; num6++)
					{
						PathNode<Vector3> pathNode5 = PathNodes[num6];
						pathNode5.OutsideAccessible = false;
						List<PathNode<Vector3>> connections3 = pathNode5.GetConnections();
						if (connections3.Count > 0)
						{
							IRoomConnector roomConnector2 = (IRoomConnector)connections3[0].Tag;
							if (!roomConnector2.IsNull)
							{
								Vector3 offsetPos = roomConnector2.GetOffsetPos(this);
								pathNode5.OutsideAccessible = FindPath(position, offsetPos, ref result, null, roomConnector2, 0, 0);
							}
						}
					}
				}
			}
			if (recalculateGraph)
			{
				List<int> pathNodeCounts2 = GetPathNodeCounts();
				if (pathNodeCounts2.Count == pathNodeCounts.Count)
				{
					bool flag2 = false;
					for (int num7 = 0; num7 < pathNodeCounts.Count; num7++)
					{
						if (pathNodeCounts[num7] != pathNodeCounts2[num7])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						recalculateGraph = false;
					}
				}
				if (recalculateGraph)
				{
					GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
				}
			}
		}
		GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
	}

	private void SubdividePathnodes()
	{
		for (int i = 0; i < PathNodes.Count; i++)
		{
			List<PathNode<Vector3>> connections = PathNodes[i].GetConnections();
			int count = connections.Count;
			for (int j = 0; j < count; j++)
			{
				bool flag = AllowExit(connections[j]);
				bool flag2 = AllowEntry(connections[j]);
				bool flag3 = false;
				Furniture furniture = connections[j].Tag as Furniture;
				if (furniture != null && "Elevator".Equals(furniture.Type))
				{
					flag3 = true;
				}
				for (int k = j + 1; k < count; k++)
				{
					PathNode<Vector3> pathNode = new PathNode<Vector3>((connections[j].Point + connections[k].Point) * 0.5f, this);
					pathNode.Tag2 = PathNodes[i];
					pathNode.Parent = PathNodes[i];
					if (Dummy && !(connections[j].Tag is PathController.PathPoint) && !(connections[k].Tag is PathController.PathPoint))
					{
						pathNode.Weight = 2f;
					}
					else if (flag3)
					{
						Furniture furniture2 = connections[k].Tag as Furniture;
						if (furniture2 != null && "Elevator".Equals(furniture2.Type))
						{
							pathNode.Weight = 3f;
						}
					}
					SubNodes.Add(pathNode);
					pathNode.AddConnection(connections[j]);
					pathNode.AddConnection(connections[k]);
					if (flag && AllowEntry(connections[k]))
					{
						connections[j].AddConnection(pathNode);
					}
					if (AllowExit(connections[k]) && flag2)
					{
						connections[k].AddConnection(pathNode);
					}
				}
			}
		}
	}

	private bool AllowExit(PathNode<Vector3> node)
	{
		IRoomConnector roomConnector = node.Tag as IRoomConnector;
		if (roomConnector != null)
		{
			return roomConnector.AllowExit();
		}
		return true;
	}

	private bool AllowEntry(PathNode<Vector3> node)
	{
		IRoomConnector roomConnector = node.Tag as IRoomConnector;
		if (roomConnector != null)
		{
			return roomConnector.AllowEntry();
		}
		return true;
	}

	public PathNode<Vector3> GetFirstPathNode()
	{
		if (PathNodes.Count != 0)
		{
			return PathNodes[0];
		}
		return new PathNode<Vector3>(Vector3.zero, this);
	}

	public PathNode<Vector3> GetAvailableNode(Vector3 pos)
	{
		if (PathNodes.Count == 0)
		{
			return new PathNode<Vector3>(Vector3.zero, this);
		}
		if (PathNodes.Count == 1)
		{
			return PathNodes[0];
		}
		List<PathVector> result = new List<PathVector>();
		for (int i = 0; i < PathNodes.Count; i++)
		{
			PathNode<Vector3> pathNode = PathNodes[i];
			List<PathNode<Vector3>> connections = pathNode.GetConnections();
			if (connections.Count <= 0)
			{
				continue;
			}
			IRoomConnector roomConnector = (IRoomConnector)connections[0].Tag;
			if (!roomConnector.IsNull)
			{
				Vector3 offsetPos = roomConnector.GetOffsetPos(this);
				if (FindPath(pos, offsetPos, ref result, null, roomConnector, 0, 0))
				{
					return pathNode;
				}
				result.Clear();
			}
		}
		return new PathNode<Vector3>(Vector3.zero, this);
	}

	private bool NodesAccessible(IRoomConnector d1, IRoomConnector d2)
	{
		Vector3 offsetPos = d1.GetOffsetPos(this);
		Vector3 offsetPos2 = d2.GetOffsetPos(this);
		List<PathVector> result = new List<PathVector>();
		return FindPath(offsetPos, offsetPos2, ref result, d1, d2, 0, 0);
	}

	public void CacheAllPaths()
	{
		List<IRoomConnector> list = (from x in GetConnectors()
			where x.pathNode != null
			select x).ToList();
		List<PathVector> result = new List<PathVector>();
		for (int num = 0; num < list.Count; num++)
		{
			IRoomConnector roomConnector = list[num];
			for (int num2 = num + 1; num2 < list.Count; num2++)
			{
				IRoomConnector roomConnector2 = list[num2];
				FindPath(roomConnector.GetOffsetPos(this), roomConnector2.GetOffsetPos(this), ref result, roomConnector, roomConnector2, 0, 0);
				result.Clear();
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (!Dummy && Example.EnableNearness && base.IsSelected)
		{
			List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(this);
			for (int i = 0; i < connectedRooms.Count; i++)
			{
				KeyValuePair<Room, int> keyValuePair = connectedRooms[i];
				if (keyValuePair.Key.Floor <= GameSettings.Instance.ActiveFloor && keyValuePair.Key.FloorMesh != null)
				{
					Gizmos.color = ((keyValuePair.Value == 0) ? new Color(1f, 1f, 1f, 0.75f) : _nearnessColors[Mathf.Min(keyValuePair.Value - 1, _nearnessColors.Length - 1)].Alpha(Mathf.Lerp(0.75f, 0.1f, Mathf.Clamp01((float)(keyValuePair.Value / _nearnessColors.Length) / 3f))));
					Gizmos.DrawMesh(keyValuePair.Key.FloorMesh.GetComponent<MeshFilter>().sharedMesh, 0, keyValuePair.Key.transform.position + Vector3.up * (keyValuePair.Key.Floor * 2 + 1));
				}
			}
			Gizmos.color = Color.white;
		}
		if (Floor == GameSettings.Instance.ActiveFloor && !Example.CachedPaths)
		{
			Color[] array = new Color[3]
			{
				Color.red,
				Color.green,
				Color.blue
			};
			int num = 0;
			foreach (PathNode<Vector3> pathNode in PathNodes)
			{
				Gizmos.color = array[num % array.Length];
				foreach (PathNode<Vector3> connection in pathNode.GetConnections())
				{
					Gizmos.DrawLine(pathNode.Point, connection.Point);
				}
				num++;
			}
		}
		Gizmos.color = Color.white;
	}

	public void UpdateBounds(bool initial)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			if (wallEdge.Pos.x < num)
			{
				num = wallEdge.Pos.x;
			}
			if (wallEdge.Pos.y < num2)
			{
				num2 = wallEdge.Pos.y;
			}
			if (wallEdge.Pos.x > num3)
			{
				num3 = wallEdge.Pos.x;
			}
			if (wallEdge.Pos.y > num4)
			{
				num4 = wallEdge.Pos.y;
			}
		}
		Rect rect = new Rect(num, num2, num3 - num, num4 - num2);
		bool flag = RoomBounds != rect;
		if (!initial && flag)
		{
			GameSettings.Instance.sRoomManager.RemoveRoomFromQuery(this);
		}
		RoomBounds = new Rect(num, num2, num3 - num, num4 - num2);
		if (!Outside && (initial || flag))
		{
			GameSettings.Instance.sRoomManager.AddRoomToQuery(this);
		}
		IsRect = Edges.IsAlignedRectangle();
	}

	public static float LeftVal(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		Vector2 vector = new Vector2(p2.x - p1.x, p2.y - p1.y);
		Vector2 vector2 = new Vector2(p3.x - p2.x, p3.y - p2.y);
		float num = Mathf.Atan2(vector.y, vector.x) - Mathf.Atan2(vector2.y, vector2.x);
		if (num > (float)Math.PI)
		{
			num -= (float)Math.PI * 2f;
		}
		if (num < -(float)Math.PI)
		{
			num += (float)Math.PI * 2f;
		}
		return num;
	}

	public bool IsInside(Vector3 p)
	{
		return IsInside(new Vector2(p.x, p.z));
	}

	public Vector2[] GetExpanded(float expansion, bool ignoreBalcony = false)
	{
		if (Edges == null || Edges.Count == 0)
		{
			return Array.Empty<Vector2>();
		}
		Vector2[] array = new Vector2[Edges.Count];
		int num = 0;
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge;
		do
		{
			if (num >= Edges.Count)
			{
				return BrokenWhileLoop(() => GetExpanded(expansion, ignoreBalcony), array);
			}
			WallEdge value;
			WallEdge value2;
			if (!wallEdge.Links.TryGetValue(this, out value) || !value.Links.TryGetValue(this, out value2))
			{
				return BrokenWhileLoop(() => GetExpanded(expansion, ignoreBalcony), array);
			}
			if (ignoreBalcony)
			{
				array[num] = GetAtriumOffset(wallEdge, value, value2, expansion);
			}
			else
			{
				array[num] = GetOffset(wallEdge, value, value2, expansion);
			}
			wallEdge = value;
			num++;
		}
		while (wallEdge != wallEdge2);
		return array;
	}

	private void BrokenWhileLoop(Action Retry)
	{
		if (Thread.CurrentThread != ModController.MainThread)
		{
			return;
		}
		if (!HasTriedFix)
		{
			HasTriedFix = true;
			if (!TryFixEdges())
			{
				Debug.LogException(new Exception("Room has less than 3 walls after fix"), this);
				return;
			}
			Debug.LogException(new Exception("Ignore:Broken while loop"), this);
			Retry();
		}
		else
		{
			Debug.LogException(new Exception("Broken while loop after trying fix"), this);
		}
	}

	private T BrokenWhileLoop<T>(Func<T> Retry, T def)
	{
		if (Thread.CurrentThread != ModController.MainThread)
		{
			return def;
		}
		if (!HasTriedFix)
		{
			HasTriedFix = true;
			if (!TryFixEdges())
			{
				Debug.LogException(new Exception("Room has less than 3 walls after fix"), this);
				return def;
			}
			Debug.LogException(new Exception("Ignore:Broken while loop"), this);
			return Retry();
		}
		Debug.LogException(new Exception("Broken while loop after trying fix"), this);
		return def;
	}

	public bool TryFixEdges()
	{
		if (Thread.CurrentThread != ModController.MainThread)
		{
			return false;
		}
		if (this == null || _isBeingDestroyed)
		{
			return false;
		}
		foreach (WallEdge item in GameSettings.Instance.sRoomManager.GetEdgesOnFloor(Floor))
		{
			item.Links.Remove(this);
		}
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			WallEdge wallEdge2 = Edges[(i + 1) % Edges.Count];
			if (wallEdge == wallEdge2)
			{
				Edges.RemoveAt(i);
				i--;
			}
			else
			{
				wallEdge.Links[this] = wallEdge2;
			}
		}
		if (Edges.Count < 3 && base.gameObject != null)
		{
			DestroyGO();
			return false;
		}
		return true;
	}

	public bool IsInside(Vector2 p, float expansion)
	{
		if (Outside)
		{
			return true;
		}
		if (Edges == null || Edges.Count == 0)
		{
			return false;
		}
		if (p.x < RoomBounds.xMin + expansion - 0.01f || p.x > RoomBounds.xMax - expansion + 0.01f || p.y < RoomBounds.yMin + expansion - 0.01f || p.y > RoomBounds.yMax - expansion + 0.01f)
		{
			return false;
		}
		if (IsRect)
		{
			return true;
		}
		bool flag = expansion != 0f;
		int num = 0;
		Vector2 p2 = (flag ? GetOffset(Edges[Edges.Count - 1], Edges[0], Edges[1], expansion) : Edges[Edges.Count - 1].Pos);
		for (int i = 0; i < Edges.Count; i++)
		{
			Vector2 vector;
			if (flag)
			{
				WallEdge first = Edges[i];
				WallEdge second = Edges[(i + 1) % Edges.Count];
				WallEdge third = Edges[(i + 2) % Edges.Count];
				vector = GetOffset(first, second, third, expansion);
			}
			else
			{
				vector = Edges[i].Pos;
			}
			if (p2.y <= p.y)
			{
				if (vector.y > p.y && Utilities.IsLeft(p2, vector, p) > 0)
				{
					num++;
				}
			}
			else if (vector.y <= p.y && Utilities.IsLeft(p2, vector, p) < 0)
			{
				num--;
			}
			p2 = vector;
		}
		return num != 0;
	}

	public bool IsInside(Vector2 p, bool strict = false)
	{
		if (Outside)
		{
			return true;
		}
		if (Edges == null || Edges.Count == 0)
		{
			return false;
		}
		if (strict && (p.x < RoomBounds.xMin + 0.01f || p.x > RoomBounds.xMax - 0.01f || p.y < RoomBounds.yMin + 0.01f || p.y > RoomBounds.yMax - 0.01f))
		{
			return false;
		}
		if (p.x < RoomBounds.xMin - 0.01f || p.x > RoomBounds.xMax + 0.01f || p.y < RoomBounds.yMin - 0.01f || p.y > RoomBounds.yMax + 0.01f)
		{
			return false;
		}
		if (IsRect)
		{
			return true;
		}
		int num = 0;
		int num2 = 0;
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge;
		do
		{
			WallEdge value;
			if (!wallEdge.Links.TryGetValue(this, out value))
			{
				if (!TryFixEdges())
				{
					return false;
				}
				if (!wallEdge.Links.TryGetValue(this, out value))
				{
					return false;
				}
			}
			if (wallEdge.Pos.y <= p.y)
			{
				if (value.Pos.y > p.y && Utilities.IsLeft(wallEdge.Pos, value.Pos, p) > 0)
				{
					num2++;
				}
			}
			else if (value.Pos.y <= p.y && Utilities.IsLeft(wallEdge.Pos, value.Pos, p) < 0)
			{
				num2--;
			}
			wallEdge = value;
			num++;
			if (num > Edges.Count * 2)
			{
				return BrokenWhileLoop(() => IsInside(p), false);
			}
		}
		while (wallEdge != wallEdge2);
		return num2 != 0;
	}

	public bool IsStrictlyInside(Vector2 p)
	{
		if (Outside)
		{
			return true;
		}
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < Edges.Count; i++)
		{
			Vector2 pos = Edges[i].Pos;
			Vector2 pos2 = Edges[(i + 1) % Edges.Count].Pos;
			if (IsValidInsideCheck(p, pos, pos2))
			{
				if (IsBetween(p.y, pos.y, pos2.y))
				{
					flag2 = !flag2;
				}
				else if (pos.y == p.y && flag && flag)
				{
					flag2 = !flag2;
				}
				flag = pos2.y == p.y;
			}
		}
		return flag2;
	}

	private bool IsValidInsideCheck(Vector2 p, Vector2 a, Vector2 b)
	{
		if (a.x < p.x && b.x < p.x)
		{
			return true;
		}
		if (IsBetween(p.x, a.x, b.x))
		{
			float num = (b.y - a.y) / (b.x - a.x);
			float num2 = (0f - num) * a.x + a.y;
			float num3 = (p.y - num2) / num;
			return p.x > num3;
		}
		return false;
	}

	private bool IsBetween(float x, float a, float b)
	{
		if (a > b)
		{
			if (x > b)
			{
				return x < a;
			}
			return false;
		}
		if (x > a)
		{
			return x < b;
		}
		return false;
	}

	public bool IsInsideBounds(Vector2 p, float offset)
	{
		if (p.x >= RoomBounds.xMin - offset && p.x <= RoomBounds.xMax + offset && p.y >= RoomBounds.yMin - offset)
		{
			return p.y <= RoomBounds.yMax + offset;
		}
		return false;
	}

	public int LinkBack(WallEdge s, WallEdge go, Room r2, bool tryAgain)
	{
		int num = 0;
		do
		{
			if (!go.Links.ContainsKey(r2))
			{
				return 0;
			}
			num++;
			go = go.Links[r2];
		}
		while (go != s);
		if (tryAgain && num > 1)
		{
			num = LinkBack(s, s, r2, false) - 1;
			if (num > 1)
			{
				num = LinkBack(s, s.Links[r2], r2, false) - 1;
			}
		}
		return num;
	}

	public bool CanMerge(Room other, bool ignoreAtrium = false)
	{
		if (Floor != other.Floor || Burn > 0f || other.Burn > 0f || other == this || Edges.Count < 3 || other.Edges.Count < 3)
		{
			return false;
		}
		if (!ignoreAtrium)
		{
			if (AtriumParent != null && other == AtriumParent)
			{
				return false;
			}
			if ((AtriumParent != null || other.AtriumParent != null) && AtriumParent != other.AtriumParent && other.AtriumParent != this)
			{
				bool flag = false;
				if (AtriumParent == this && other.AtriumParent == other && AtriumChildren.Count == other.AtriumChildren.Count)
				{
					bool flag2 = true;
					for (int i = 0; i < AtriumChildren.Count; i++)
					{
						if (!AtriumChildren[i].CanMerge(other.AtriumChildren[i], true))
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
		}
		int num = 0;
		int num2 = 0;
		bool flag3 = Edges.First().Links.ContainsKey(other);
		foreach (WallEdge edge in Edges)
		{
			if (num2 % 2 == 1)
			{
				if (!edge.Links.ContainsKey(other))
				{
					num2++;
				}
			}
			else if (edge.Links.ContainsKey(other))
			{
				num2++;
			}
			if (edge.Links.ContainsKey(other) && edge.Links[other].Links.ContainsKey(this) && edge.Links[other].Links[this] == edge)
			{
				num++;
			}
		}
		if (flag3)
		{
			num2--;
		}
		if (num2 > 2)
		{
			return false;
		}
		num2 = 0;
		flag3 = other.Edges.First().Links.ContainsKey(this);
		foreach (WallEdge edge2 in other.Edges)
		{
			if (num2 % 2 == 1)
			{
				if (!edge2.Links.ContainsKey(this))
				{
					num2++;
				}
			}
			else if (edge2.Links.ContainsKey(this))
			{
				num2++;
			}
		}
		if (flag3)
		{
			num2--;
		}
		if (num2 > 2)
		{
			return false;
		}
		if (num == 0)
		{
			return false;
		}
		if (!IsUpperAtrium && Floor > 0)
		{
			_supportCheckCache.Clear();
			_supportEdgeCheckCache.Clear();
			_supportEdgeCheckCache.AddRange(other.Edges);
			int num3 = -1;
			int num4 = -1;
			bool flag4 = _supportEdgeCheckCache.Contains(Edges.Last());
			bool flag5 = true;
			for (int j = 0; j < Edges.Count; j++)
			{
				bool num5 = _supportEdgeCheckCache.Contains(Edges[j]);
				if (num5)
				{
					if (flag4)
					{
						if (flag5)
						{
							num4 = j;
						}
					}
					else
					{
						num3 = j;
					}
				}
				if (!num5 && num4 >= 0)
				{
					flag5 = false;
				}
				flag4 = num5;
			}
			if (num3 < 0 || num4 < 0)
			{
				return false;
			}
			for (int num6 = num4; num6 != num3; num6 = (num6 + 1) % Edges.Count)
			{
				_supportCheckCache.Add(Edges[num6].Pos);
			}
			num3 = other.Edges.IndexOf(Edges[num3]);
			num4 = other.Edges.IndexOf(Edges[num4]);
			for (int num6 = num3; num6 != num4; num6 = (num6 + 1) % other.Edges.Count)
			{
				_supportCheckCache.Add(other.Edges[num6].Pos);
			}
			if (!GameSettings.Instance.sRoomManager.IsSupported(_supportCheckCache, Floor, null))
			{
				return false;
			}
		}
		return true;
	}

	public void RefreshBalconyLook()
	{
		_fromParent = true;
		_fromParent = false;
		DirtyOuterMesh = true;
		DirtyInnerMesh = true;
		if (AtriumParent != null)
		{
			InsideColor = AtriumParent._insideColor;
			OutsideColor = AtriumParent._outsideColor;
			_insideMat = AtriumParent._insideMat;
			_outsideMat = AtriumParent._outsideMat;
		}
	}

	public List<Vector2> MergeWith(Room other, Dictionary<WallSnap, UndoObject.UndoAction> snaps, List<UndoObject.UndoAction> undos, bool undoReverse = false)
	{
		lock (NavLock)
		{
			if (AtriumParent == this && other.AtriumParent == other && AtriumChildren.Count == other.AtriumChildren.Count)
			{
				for (int i = 0; i < AtriumChildren.Count; i++)
				{
					Room room = AtriumChildren[i];
					Room room2 = other.AtriumChildren[i];
					List<Vector2> split = room.MergeWith(room2, room2.PrepareSplit(undos != null, room.PrepareSplit(undos != null)), undos);
					if (undos != null)
					{
						undos.Add(new UndoObject.UndoAction(room, room2, split, true));
					}
				}
			}
			other.AtriumChildren.ForEach(delegate(Room x)
			{
				x.AtriumParent = this;
			});
			AtriumChildren.AddRange(other.AtriumChildren);
			AtriumChildren.ForEach(delegate(Room x)
			{
				x.RefreshBalconyLook();
			});
			if (other.Roofing != Roofing)
			{
				if (other.Roofing.IsAliveNotNull())
				{
					if (undos != null)
					{
						undos.Add(new UndoObject.UndoAction(false, other.Roofing));
					}
					other.Roofing.DestroyGO();
				}
				if (Roofing.IsAliveNotNull())
				{
					if (undos != null)
					{
						undos.Add(new UndoObject.UndoAction(false, Roofing));
					}
					Roofing.DestroyGO();
				}
			}
			else if (other.Roofing != null)
			{
				other.Roofing.RoofOf.Remove(other);
			}
			List<WallEdge> list = Edges.Concat(other.Edges).Distinct().ToList();
			Dictionary<WallEdge, WallEdge> dictionary = new Dictionary<WallEdge, WallEdge>();
			bool flag = false;
			for (int num = 0; num < Edges.Count; num++)
			{
				WallEdge wallEdge = Edges[num];
				WallEdge key = wallEdge.Links[this];
				if (dictionary.ContainsKey(key))
				{
					if (flag)
					{
						throw new Exception("Room edges were too corrupted to merge with");
					}
					dictionary.Clear();
					if (!TryFixEdges())
					{
						throw new Exception("Room edges were too corrupted to merge with, room was removed");
					}
					num = -1;
					flag = true;
				}
				else
				{
					dictionary[key] = wallEdge;
				}
			}
			int num2 = 0;
			for (int num3 = 0; num3 < Edges.Count; num3++)
			{
				WallEdge wallEdge2 = Edges[num3];
				if (!wallEdge2.Links.ContainsKey(other) || !wallEdge2.Links[other].Links.ContainsKey(this))
				{
					num2 = num3;
					break;
				}
			}
			List<Vector2> list2 = new List<Vector2>();
			bool flag2 = true;
			for (int num4 = 0; num4 < Edges.Count; num4++)
			{
				WallEdge wallEdge3 = Edges[(num4 + num2) % Edges.Count];
				if (!wallEdge3.Links.ContainsKey(other) || !wallEdge3.Links[other].Links.ContainsKey(this))
				{
					continue;
				}
				WallEdge wallEdge4 = dictionary[wallEdge3];
				while (wallEdge4.Links.ContainsKey(other) && (!wallEdge4.Links[other].Links.ContainsKey(this) || wallEdge4 != wallEdge4.Links[other].Links[this]))
				{
					if (flag2)
					{
						WallEdge wallEdge5 = wallEdge4;
						do
						{
							list2.Add(wallEdge5.Pos);
							wallEdge5 = wallEdge5.Links[this];
						}
						while (wallEdge5.Links.ContainsKey(other) && wallEdge5.Links[other].Links.ContainsKey(this));
						flag2 = false;
					}
					HashSet<WallSnap> value;
					if (wallEdge4.Links.ContainsKey(this) && wallEdge4.Children.TryGetValue(wallEdge4.Links[this], out value))
					{
						_segmentCache.Clear();
						_segmentCache.AddRange(value);
						for (int num5 = 0; num5 < _segmentCache.Count; num5++)
						{
							WallSnap wallSnap = _segmentCache[num5];
							if (undos != null && wallSnap.IsAliveNotNull())
							{
								Furniture furniture;
								if ((object)(furniture = wallSnap as Furniture) != null)
								{
									furniture.UndoDestroyWithChildren(undos, snaps);
								}
								else
								{
									undos.Add(snaps[wallSnap]);
								}
							}
							wallSnap.DestroyGO();
						}
						_segmentCache.Clear();
						value.Clear();
						wallEdge4.Links[this].Children[wallEdge4].Clear();
					}
					wallEdge4.Links[this] = wallEdge4.Links[other];
					wallEdge4.Links.Remove(other);
					wallEdge4 = wallEdge4.Links[this];
					if (wallEdge4.Links.ContainsKey(this) || !wallEdge4.Links.ContainsKey(other))
					{
						break;
					}
				}
			}
			int num6 = 0;
			List<WallEdge> list3 = new List<WallEdge>();
			WallEdge wallEdge6 = Edges[0].Links[this];
			WallEdge wallEdge7 = wallEdge6;
			do
			{
				if (list3.Contains(wallEdge6))
				{
					int num7 = list3.IndexOf(wallEdge6);
					for (int num8 = 0; num8 < num7; num8++)
					{
						list3.RemoveAt(0);
					}
					break;
				}
				list3.Add(wallEdge6);
				wallEdge6 = wallEdge6.Links[this];
				num6++;
				if (num6 > Edges.Count * 2 + other.Edges.Count * 2)
				{
					Debug.LogException(new Exception("Broken while loop"), this);
					break;
				}
			}
			while (wallEdge6 != wallEdge7);
			Edges = list3;
			Edges.ForEach(delegate(WallEdge x)
			{
				x.Links.Remove(other);
			});
			UpdateBounds(false);
			List<Furniture> list4;
			lock (other._furnitures)
			{
				list4 = other._furnitures.ToList();
				other._furnitures.Clear();
			}
			list4.ForEach(delegate(Furniture x)
			{
				x.Parent = null;
			});
			other.FurnitureTypes.Clear();
			GameSettings.Instance.sRoomManager.Rooms.RemoveAll((Room x) => x == other);
			for (int num9 = 0; num9 < Edges.Count; num9++)
			{
				WallEdge wallEdge8 = Edges[num9];
				if (Outdoors)
				{
					Room room3 = Edges[(num9 + 1) % Edges.Count].GetRoom(wallEdge8);
					if (room3 != null)
					{
						room3.DirtyOuterMesh = true;
					}
				}
				HashSet<WallSnap> value2;
				if (!wallEdge8.Children.TryGetValue(wallEdge8.Links[this], out value2))
				{
					continue;
				}
				_segmentCache.Clear();
				_segmentCache.AddRange(value2);
				for (int num10 = 0; num10 < _segmentCache.Count; num10++)
				{
					WallSnap wallSnap2 = _segmentCache[num10];
					bool flag3 = wallSnap2.IsAliveNotNull();
					UndoObject.UndoAction value3;
					if (!wallSnap2.EdgeChanged(false) && undos != null && flag3 && snaps.TryGetValue(wallSnap2, out value3))
					{
						undos.Add(value3);
					}
				}
				_segmentCache.Clear();
			}
			OptimizeSegments();
			DirtyOuterMesh = true;
			DirtyInnerMesh = true;
			List<Actor> list5 = other.Occupants.ToList();
			for (int num11 = 0; num11 < list5.Count; num11++)
			{
				list5[num11].currentRoom = this;
			}
			other.DestroyGO();
			other._isBeingDestroyed = true;
			for (int num12 = 0; num12 < list.Count; num12++)
			{
				WallEdge wallEdge9 = list[num12];
				if (!Edges.Contains(wallEdge9))
				{
					GameSettings.Instance.sRoomManager.AllSegments.Remove(wallEdge9);
					_segmentCache.Clear();
					_segmentCache.AddRange(wallEdge9.Children.SelectMany((KeyValuePair<WallEdge, HashSet<WallSnap>> x) => x.Value));
					for (int num13 = 0; num13 < _segmentCache.Count; num13++)
					{
						_segmentCache[num13].DestroyGO();
					}
					_segmentCache.Clear();
				}
			}
			for (int num14 = 0; num14 < other.Dirts.Count; num14++)
			{
				Dirt dirt = other.Dirts[num14];
				AddNewDirt(dirt.Pos, dirt.Amount, dirt.Type, dirt.Rot);
			}
			if (!Pillar)
			{
				UpdateFloor();
			}
			list4.UpdateParentOfFurniture(!undoReverse, undos);
			RecalculateTableGroupsNow();
			_furnitures.ThreadSafeForEach(delegate(Furniture x)
			{
				x.UpdateBoundsMesh();
			});
			other.Edges.ForEach(delegate(WallEdge x)
			{
				x.Links.Remove(other);
			});
			other.Edges.Clear();
			DirtyNavMesh = true;
			DirtyPathNodes = true;
			FurnitureValidCheck(undos, snaps);
			float num15 = other.Smell * other.Area;
			float num16 = Smell * Area;
			Area = Utilities.PolygonArea(Edges);
			Smell = (num15 + num16) / Area;
			ResetDestructionUndo();
			GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
			GameSettings.Instance.sRoomManager.CCTVDirty = true;
			RefreshTextureTiling();
			QueueEdgeNetworkUpdate();
			return list2;
		}
	}

	public Dictionary<WallSnap, UndoObject.UndoAction> PrepareSplit(bool undo, Dictionary<WallSnap, UndoObject.UndoAction> snaps = null)
	{
		if (snaps == null)
		{
			snaps = new Dictionary<WallSnap, UndoObject.UndoAction>();
		}
		foreach (WallSnap item in Edges.SelectMany((WallEdge x) => x.Children.SelectMany((KeyValuePair<WallEdge, HashSet<WallSnap>> z) => z.Value)).Distinct())
		{
			if (snaps.ContainsKey(item))
			{
				continue;
			}
			if (undo && item.IsAliveNotNull())
			{
				snaps[item] = new UndoObject.UndoAction(item, false);
				Furniture furniture;
				if ((object)(furniture = item as Furniture) == null)
				{
					continue;
				}
				foreach (Furniture item2 in furniture.IterateSnap())
				{
					if (item2.IsAliveNotNull())
					{
						snaps[item2] = new UndoObject.UndoAction(item2, false);
					}
				}
			}
			else
			{
				snaps[item] = null;
			}
		}
		return snaps;
	}

	private bool EdgeFixCheck()
	{
		bool flag = true;
		for (int i = 0; i < Edges.Count; i++)
		{
			if (!Edges[i].Links.ContainsKey(this))
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			return TryFixEdges();
		}
		return true;
	}

	private ValueTuple<Room, Room> SplitUpperAtrium(List<WallEdge> segments, List<UndoObject.UndoAction> undo, WallEdge a, WallEdge b)
	{
		List<UndoObject.UndoAction> list = ((undo == null) ? null : new List<UndoObject.UndoAction>());
		if (a.IsSplitter)
		{
			a.SplitSegment(undo);
		}
		if (b.IsSplitter)
		{
			b = FindSplit(b);
			b.SplitSegment(undo);
		}
		List<WallEdge> list2 = new List<WallEdge>();
		list2.Add(a);
		for (int i = 1; i < segments.Count - 1; i++)
		{
			list2.Add(new WallEdge(segments[i].Pos, Floor));
		}
		list2.Add(b);
		Dictionary<WallSnap, UndoObject.UndoAction> snaps = PrepareSplit(list != null);
		GameSettings.Instance.sRoomManager.AllSegments.AddRange(list2);
		Room room = Split(list2, list, snaps, null, true, null, true, false);
		if (room != null)
		{
			for (int j = 0; j < room.Edges.Count; j++)
			{
				WallEdge other = room.Edges[j];
				Room room2 = room.Edges[(j + 1) % room.Edges.Count].GetRoom(other);
				if (room2 != null && room2.AtriumParent == this)
				{
					room2.AtriumParent = room;
					room.AtriumChildren.Add(room2);
					AtriumChildren.Remove(room2);
				}
			}
			BuildController.Instance.PostCut(this, room, room.Center, 0f, undo, list);
		}
		else
		{
			OptimizeSegments();
			foreach (WallEdge item in list2)
			{
				if (!Edges.Contains(item))
				{
					GameSettings.Instance.sRoomManager.AllSegments.Remove(item);
				}
			}
		}
		return new ValueTuple<Room, Room>(this, room);
	}

	private WallEdge FindSplit(WallEdge e)
	{
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			if ((wallEdge.Pos - e.Pos).sqrMagnitude < 0.0001f)
			{
				return wallEdge;
			}
		}
		for (int j = 0; j < Edges.Count; j++)
		{
			WallEdge wallEdge2 = Edges[j];
			WallEdge wallEdge3 = Edges[(j + 1) % Edges.Count];
			Vector2 res;
			if (Utilities.ProjectToLine(e.Pos, wallEdge2.Pos, wallEdge3.Pos, out res) && (res - e.Pos).sqrMagnitude < 0.0001f)
			{
				float magnitude = (wallEdge3.Pos - wallEdge2.Pos).magnitude;
				float magnitude2 = (res - wallEdge2.Pos).magnitude;
				if (!magnitude2.VeryStrictlyBelow(BuildController.Instance.MinWallDistance) && !(magnitude - magnitude2).VeryStrictlyBelow(BuildController.Instance.MinWallDistance))
				{
					WallEdge wallEdge4 = new WallEdge(res, Floor);
					wallEdge4.SetSplit(wallEdge2, this);
					return wallEdge4;
				}
				return null;
			}
		}
		Debug.LogException(new Exception("Couldn't find corresponding WallEdge for atrium " + DID));
		return null;
	}

	public Room Split(List<WallEdge> segments, List<UndoObject.UndoAction> destroyed, Dictionary<WallSnap, UndoObject.UndoAction> snaps, string debug = null, bool keepGroup = true, WriteDictionary other = null, bool atrium = false, bool allowBalcony = true, bool ignoreSupport = false)
	{
		lock (NavLock)
		{
			if (debug == null)
			{
				debug = string.Join("\n", segments.Select((WallEdge x) => x.Pos.x + ";" + x.Pos.y).ToArray()) + "\n\n" + string.Join("\n", Edges.Select((WallEdge x) => x.Pos.x + ";" + x.Pos.y).ToArray());
			}
			try
			{
				if (!EdgeFixCheck())
				{
					return null;
				}
				WallEdge wallEdge = segments[0].Links[this];
				for (int num = 0; num < segments.Count - 1; num++)
				{
					segments[num].Links[this] = segments[num + 1];
				}
				int num2 = 0;
				WallEdge wallEdge2 = segments[segments.Count - 1];
				WallEdge wallEdge3 = wallEdge2;
				List<WallEdge> list = new List<WallEdge>();
				do
				{
					list.Add(wallEdge3);
					wallEdge3 = wallEdge3.Links[this];
					num2++;
					if (num2 > Edges.Count * 2 + segments.Count * 2)
					{
						Debug.LogException(new Exception("Broken while loop"), this);
						return null;
					}
				}
				while (wallEdge3 != wallEdge2);
				int count = Edges.Count;
				count = Mathf.Max(list.Count, count);
				List<WallEdge> list2 = new List<WallEdge>();
				wallEdge3 = wallEdge;
				num2 = 0;
				while (wallEdge3 != wallEdge2)
				{
					list2.Add(wallEdge3);
					wallEdge3 = wallEdge3.Links[this];
					num2++;
					if (num2 > count * 2 + segments.Count * 2)
					{
						Debug.LogException(new Exception("Broken while loop"), this);
						return null;
					}
				}
				List<WallEdge> list3 = new List<WallEdge>(list2);
				list3.AddRange(Enumerable.Reverse(segments));
				if (!atrium && !ignoreSupport && (!GameSettings.Instance.sRoomManager.IsSupported(list.Select((WallEdge x) => x.Pos), Floor, null) || !GameSettings.Instance.sRoomManager.IsSupported(list3.Select((WallEdge x) => x.Pos), Floor, null)))
				{
					for (int num3 = 0; num3 < Edges.Count; num3++)
					{
						Edges[num3].Links[this] = Edges[(num3 + 1) % Edges.Count];
					}
					WindowManager.SpawnDialog("SplitUnsupported".Loc(), true, DialogWindow.DialogType.Error);
					return null;
				}
				List<ValueTuple<Room, Room>> list4 = null;
				if (AtriumParent == this && other == null)
				{
					list4 = new List<ValueTuple<Room, Room>>();
					List<ValueTuple<WallEdge, WallEdge>> list5 = new List<ValueTuple<WallEdge, WallEdge>>();
					List<Room> list6 = AtriumChildren.ToList();
					for (int num4 = 0; num4 < list6.Count; num4++)
					{
						WallEdge wallEdge4 = list6[num4].FindSplit(segments[0]);
						if (wallEdge4 != null)
						{
							WallEdge wallEdge5 = list6[num4].FindSplit(segments.Last());
							if (wallEdge5 != null)
							{
								list5.Add(new ValueTuple<WallEdge, WallEdge>(wallEdge4, wallEdge5));
								continue;
							}
							for (int num5 = 0; num5 < Edges.Count; num5++)
							{
								Edges[num5].Links[this] = Edges[(num5 + 1) % Edges.Count];
							}
							return null;
						}
						for (int num6 = 0; num6 < Edges.Count; num6++)
						{
							Edges[num6].Links[this] = Edges[(num6 + 1) % Edges.Count];
						}
						return null;
					}
					for (int num7 = 0; num7 < list6.Count; num7++)
					{
						ValueTuple<Room, Room> item = list6[num7].SplitUpperAtrium(segments, destroyed, list5[num7].Item1, list5[num7].Item2);
						if (item.Item2 != null)
						{
							list4.Add(item);
							continue;
						}
						for (int num8 = 0; num8 < list4.Count; num8++)
						{
							list4[0].Item1.MergeWith(list4[1].Item2, null, null);
						}
						for (int num9 = 0; num9 < Edges.Count; num9++)
						{
							Edges[num9].Links[this] = Edges[(num9 + 1) % Edges.Count];
						}
						return null;
					}
				}
				Edges = list;
				list2.ForEach(delegate(WallEdge x)
				{
					x.Links.Remove(this);
				});
				list2.AddRange(Enumerable.Reverse(segments));
				List<UndoObject.UndoAction> list7 = ((destroyed == null) ? null : new List<UndoObject.UndoAction>());
				Room room = BuildController.Instance.MakeRoom(list2, Floor, list7, false, false, true, Outdoors, Pillar);
				if (list7 != null)
				{
					destroyed.AddRange(list7.Where((UndoObject.UndoAction x) => x.Type == UndoObject.UndoAction.ActionType.CreateFurniture));
				}
				if (IsBalcony)
				{
					room.AtriumParent = AtriumParent;
					AtriumParent.AtriumChildren.Add(room);
				}
				else if (IsUpperAtrium && allowBalcony)
				{
					room.AtriumParent = this;
					AtriumChildren.Add(room);
				}
				if (list4 != null)
				{
					room.AtriumParent = room;
					AtriumChildren.Clear();
					for (int num10 = 0; num10 < list4.Count; num10++)
					{
						ValueTuple<Room, Room> valueTuple = list4[num10];
						AtriumChildren.Add(valueTuple.Item1);
						valueTuple.Item1.AtriumParent = this;
						room.AtriumChildren.Add(valueTuple.Item2);
						valueTuple.Item2.AtriumParent = room;
					}
					room.RefreshTextureTiling();
					RefreshTextureTiling();
					AtriumChildren.Sort((Room x, Room y) => x.Floor.CompareTo(y.Floor));
					room.AtriumChildren.Sort((Room x, Room y) => x.Floor.CompareTo(y.Floor));
				}
				EmitDirt(segments, Floor);
				if (other != null)
				{
					room.DeserializeThis(other, false);
					room.PostDeserialize();
				}
				else
				{
					CopyOverSettings(room);
				}
				foreach (KeyValuePair<WallSnap, UndoObject.UndoAction> snap in snaps)
				{
					if (!snap.Key.IsAliveNotNull() || snap.Key.EdgeChanged(null, false) || snap.Value == null || destroyed == null)
					{
						continue;
					}
					Furniture furniture = snap.Key as Furniture;
					destroyed.Add(snap.Value);
					if (furniture != null)
					{
						destroyed.AddRange(from x in furniture.IterateSnap()
							select new UndoObject.UndoAction(x, false));
					}
				}
				DirtyInnerMesh = true;
				DirtyNavMesh = true;
				DirtyPathNodes = true;
				SetSizes(false);
				for (int num11 = 0; num11 < Dirts.Count; num11++)
				{
					if (!IsInside(Dirts[num11].Pos))
					{
						if (room.IsInside(Dirts[num11].Pos))
						{
							room.AddNewDirt(Dirts[num11].Pos, Dirts[num11].Amount, Dirts[num11].Type, Dirts[num11].Rot);
						}
						RemoveDirt(num11);
						num11--;
					}
				}
				room.Smell = Smell;
				UpdateDirtScore();
				room.UpdateDirtScore();
				if (!atrium)
				{
					room.UpdateRoom(true, true, true, true, true, true, false, true);
				}
				for (int num12 = 0; num12 < AtriumChildren.Count; num12++)
				{
					Room room2 = AtriumChildren[num12];
					room2.DirtyInnerMesh = true;
					room2.DirtyOuterMesh = true;
				}
				if (keepGroup && RoomGroup != null)
				{
					RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(RoomGroup);
					if (roomGroup != null)
					{
						roomGroup.AddRoom(room);
					}
				}
				foreach (Actor item2 in Occupants.ToList())
				{
					item2.UpdateCurrentRoom(true);
				}
				RefreshNoise();
				room.RefreshNoise();
				DirtyLights();
				ResetDestructionUndo();
				GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
				GameSettings.Instance.sRoomManager.CCTVDirty = true;
				if (IsUpperAtrium && !atrium)
				{
					UpdateAtriumFurniture(destroyed);
				}
				QueueEdgeNetworkUpdate();
				return room;
			}
			catch (Exception exception)
			{
				MiscMsg.SendMsg("SplitRoom", Versioning.VersionString + "\n" + debug);
				Debug.LogException(exception);
				return null;
			}
		}
	}

	private List<WallEdge> Destroy()
	{
		if (Edges == null)
		{
			return new List<WallEdge>();
		}
		List<WallEdge> list = new List<WallEdge>();
		List<Room> list2;
		lock (NavLock)
		{
			list2 = (from x in Edges.SelectMany((WallEdge x) => x.Links.Keys).OfType<Room>()
				where x != this
				select x).Distinct().ToList();
			for (int num = 0; num < Edges.Count; num++)
			{
				Edges[num].Links.Remove(this);
			}
			for (int num2 = 0; num2 < Edges.Count; num2++)
			{
				WallEdge wallEdge = Edges[num2];
				WallEdge wallEdge2 = Edges[(num2 + 1) % Edges.Count];
				HashSet<WallSnap> value;
				if (wallEdge.Children.TryGetValue(wallEdge2, out value))
				{
					_wallSnapCache.Clear();
					_wallSnapCache.AddRange(value);
					foreach (WallSnap item in _wallSnapCache)
					{
						if (wallEdge2.Links.ContainsValue(wallEdge))
						{
							item.EdgeChanged(false);
						}
						else
						{
							item.DestroyGO();
						}
					}
					_wallSnapCache.Clear();
				}
				if (wallEdge.Links.Count == 0)
				{
					list.Add(wallEdge);
				}
			}
			foreach (Room item2 in list2)
			{
				item2.OptimizeSegments();
			}
		}
		list2.ForEach(delegate(Room x)
		{
			x.DirtyOuterMesh = true;
		});
		return list;
	}

	public void UpdateSurrounded()
	{
		_isSurrounded = true;
		if (Outdoors)
		{
			_isSurrounded = false;
			return;
		}
		if (AtriumParent != null)
		{
			_isSurrounded = false;
			return;
		}
		if (_furnitures.ThreadSafeAny((Furniture x) => (x.PunchHole() && x.TowardsOutside()) || (x.TwoFloors && x.MakeHole && x.Parent == this)))
		{
			_isSurrounded = false;
			return;
		}
		if (Options.OpaqueGlass)
		{
			_isSurrounded = true;
			return;
		}
		for (int num = 0; num < Edges.Count; num++)
		{
			WallEdge wallEdge = Edges[num];
			WallEdge wallEdge2 = Edges[(num + 1) % Edges.Count];
			Room room = wallEdge2.GetRoom(wallEdge);
			HashSet<WallSnap> value;
			if ((!(room == null) && !room.Outdoors && !(room.AtriumParent != null)) || !wallEdge.Children.TryGetValue(wallEdge2, out value) || value.Count == 0)
			{
				continue;
			}
			foreach (WallSnap item in value)
			{
				if (item.LightAddition > 0f)
				{
					_isSurrounded = false;
					return;
				}
				RoomSegment roomSegment = item as RoomSegment;
				if (roomSegment != null && roomSegment.IsConnecter)
				{
					_isSurrounded = false;
					return;
				}
			}
		}
	}

	public static float GetParentUVTiling(IRoom room, Vector2 pos, float defaultVal, bool inside)
	{
		Room room2;
		if ((object)(room2 = room as Room) != null)
		{
			Room mainAtriumParent = room2.GetMainAtriumParent();
			if (mainAtriumParent != null && mainAtriumParent._uvTiling != null)
			{
				for (int i = 0; i < mainAtriumParent._uvTiling.Count - 1; i++)
				{
					UVTileNode uVTileNode = mainAtriumParent._uvTiling[i];
					if (pos == (inside ? uVTileNode.InnerP : uVTileNode.OuterP))
					{
						if (!inside)
						{
							return uVTileNode.OuterUV;
						}
						return uVTileNode.InnerUV;
					}
				}
				for (int j = 0; j < mainAtriumParent._uvTiling.Count - 1; j++)
				{
					UVTileNode uVTileNode2 = mainAtriumParent._uvTiling[j];
					UVTileNode uVTileNode3 = mainAtriumParent._uvTiling[(j + 1) % mainAtriumParent._uvTiling.Count];
					Vector2 vector = (inside ? uVTileNode2.InnerP : uVTileNode2.OuterP);
					Vector2 vector2 = (inside ? uVTileNode3.InnerP : uVTileNode3.OuterP);
					Vector2 res;
					if (Utilities.ProjectToLine(pos, vector, vector2, out res) && (res - pos).sqrMagnitude < 0.001f)
					{
						return Mathf.Lerp(inside ? uVTileNode2.InnerUV : uVTileNode2.OuterUV, inside ? uVTileNode3.InnerUV : uVTileNode3.OuterUV, (res - vector).magnitude / (vector2 - vector).magnitude);
					}
				}
			}
		}
		return defaultVal;
	}

	public void RefreshTextureTiling()
	{
		if (AtriumParent == null)
		{
			_uvTiling = null;
		}
		else if (AtriumParent == this)
		{
			_uvTiling = new List<UVTileNode>();
			float num = 0f;
			float num2 = 0f;
			Vector2 vector = GetOffset(Edges[0], Edges[1], Edges[2], (0f - WallOffset) / 2f);
			Vector2 vector2 = GetOffset(Edges[0], Edges[1], Edges[2], WallOffset / 2f);
			for (int i = 0; i <= Edges.Count; i++)
			{
				WallEdge first = Edges[(i + 1) % Edges.Count];
				WallEdge second = Edges[(i + 2) % Edges.Count];
				WallEdge third = Edges[(i + 3) % Edges.Count];
				Vector2 offset = GetOffset(first, second, third, (0f - WallOffset) / 2f);
				Vector2 offset2 = GetOffset(first, second, third, WallOffset / 2f);
				_uvTiling.Add(new UVTileNode(vector, vector2, num, num2));
				num2 += (vector - offset).magnitude / 2f;
				num += (vector2 - offset2).magnitude / 2f;
				vector = offset;
				vector2 = offset2;
			}
		}
		else
		{
			AtriumParent.RefreshTextureTiling();
		}
	}

	public static GameObject GenerateOuterWalls(IRoom room, int colorID, string material, bool ignoreHoles = false)
	{
		Vector2 vector = new Vector2(colorID, RoomMaterialController.GetMaterialID(material));
		List<Vector2> list = new List<Vector2>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector4> list3 = new List<Vector4>();
		WallEdge wallEdge = room.Edges[0];
		WallEdge wallEdge2 = wallEdge.Links[room];
		WallEdge wallEdge3 = wallEdge2;
		bool flag = true;
		List<float> list4 = new List<float>();
		float num = 0f;
		MeshCombiner meshCombiner = new MeshCombiner("Room outer", true);
		int num2 = 0;
		bool lastSmooth = CheckSmooth(room.Edges[room.Edges.Count - 2], room.Edges.Last(), room.Edges[0], room.Edges[1], 0f - WallOffset);
		Vector2? vector2 = null;
		do
		{
			WallEdge wallEdge4 = wallEdge2.Links[room];
			WallEdge localF = wallEdge2;
			WallEdge localS = wallEdge4;
			if (wallEdge2.Links.Keys.Count((IRoom x) => localS.Links.Any((KeyValuePair<IRoom, WallEdge> y) => y.Key == x && y.Value == localF)) > 0 && !wallEdge2.IsAgainstOutdoors(wallEdge4))
			{
				if (!(wallEdge2 != wallEdge3 || flag))
				{
					break;
				}
				Vector2 offset = GetOffset(wallEdge, wallEdge2, wallEdge4, (0f - WallOffset) / 2f);
				Vector2 offset2 = GetOffset(wallEdge2, wallEdge4, wallEdge4.Links[room], (0f - WallOffset) / 2f);
				float num3 = 0f;
				if (vector2.HasValue)
				{
					num3 = (vector2.Value - offset).magnitude / 2f;
				}
				vector2 = offset2;
				num = (num + (offset - offset2).magnitude / 2f + num3) % 1f;
				flag = false;
				wallEdge = wallEdge2;
				wallEdge2 = wallEdge4;
				num2++;
				if (num2 <= room.Edges.Count * 2)
				{
					continue;
				}
				Room room2;
				if ((object)(room2 = room as Room) != null)
				{
					return room2.BrokenWhileLoop(() => GenerateOuterWalls(room, colorID, material), null);
				}
				return null;
			}
			flag = false;
			WallEdge wallEdge5 = FindSubstitute(room, wallEdge, wallEdge2, wallEdge4, true);
			WallEdge third = FindSubstitute(room, wallEdge, wallEdge2, wallEdge4, false);
			Vector2 offset3 = GetOffset(wallEdge5, wallEdge2, wallEdge4, (0f - WallOffset) / 2f);
			Vector2 offset4 = GetOffset(wallEdge2, wallEdge4, third, (0f - WallOffset) / 2f);
			Vector2 vector3 = offset4 - offset3;
			float magnitude = vector3.magnitude;
			vector3 = vector3.normalized;
			Vector3 nA = new Vector3(vector3.y, 0f, 0f - vector3.x);
			Vector3 nB = nA;
			bool smooth = GetSmooth(wallEdge2, wallEdge4, offset3, offset4, nA, ref lastSmooth, out nA, out nB);
			float num4 = 0f;
			if (vector2.HasValue)
			{
				num4 = (vector2.Value - offset3).magnitude / 2f;
			}
			vector2 = offset4;
			if (num2 == 0 && wallEdge5 != wallEdge)
			{
				num4 += (offset3 - GetOffset(wallEdge, wallEdge2, wallEdge4, (0f - WallOffset) / 2f)).magnitude / 2f;
			}
			float parentUVTiling = GetParentUVTiling(room, offset3, num + num4, false);
			float num5 = magnitude / 2f;
			list.Add(offset3);
			list2.Add(nA);
			list3.Add(TangentFromNormal(list2, true));
			list4.Add(parentUVTiling);
			bool flag2 = true;
			List<Vector2> list5 = (ignoreHoles ? null : wallEdge2.GetSplit(wallEdge4));
			if (list5 != null)
			{
				for (int num6 = 0; num6 < list5.Count; num6++)
				{
					Vector2 res;
					if (!Utilities.ProjectToLine(list5[num6], offset3, offset4, out res))
					{
						if (num6 == 0)
						{
							list.RemoveAt(list.Count - 1);
							list2.RemoveAt(list2.Count - 1);
							list3.RemoveAt(list3.Count - 1);
							list4.RemoveAt(list4.Count - 1);
						}
						else if (num6 == list5.Count - 1)
						{
							flag2 = false;
						}
					}
					else
					{
						list.Add(res);
						float num7 = offset3.Dist(res) / magnitude;
						list2.Add(GetNormal(nA, nB, num7, smooth));
						list3.Add(TangentFromNormal(list2, true));
						list4.Add(parentUVTiling + num5 * num7);
					}
				}
			}
			if (flag2)
			{
				list.Add(offset4);
				list2.Add(nB);
				list3.Add(TangentFromNormal(list2, true));
				list4.Add(parentUVTiling + num5);
			}
			wallEdge2.GetAllMeshes(wallEdge4, offset3, num, false, room.Floor, vector, meshCombiner);
			num = (parentUVTiling + num5) % 1f;
			wallEdge = wallEdge2;
			wallEdge2 = wallEdge4;
			num2++;
			if (num2 <= room.Edges.Count * 2)
			{
				continue;
			}
			Room room3;
			if ((object)(room3 = room as Room) != null)
			{
				return room3.BrokenWhileLoop(() => GenerateOuterWalls(room, colorID, material), null);
			}
			return null;
		}
		while (wallEdge2 != wallEdge3);
		meshCombiner.AddWall(list, list2, list3, list4, vector, false);
		Room room4;
		if ((object)(room4 = room as Room) != null && Cheats.CeilingMeshes && !room4.IsBalcony)
		{
			if (room4.FloorMesh == null)
			{
				room4.UpdateFloor();
			}
			if (room4.FloorMesh != null)
			{
				meshCombiner.AddMesh(room4.FloorMesh.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, new Vector3(1f, -1f, 1f)), true, Vector2.one * 0.5f, vector);
			}
		}
		GameObject obj = new GameObject("OuterWalls");
		obj.tag = "Highlight";
		obj.transform.position = Vector3.up * (room.Floor * 2);
		obj.AddComponent<MeshRenderer>().reflectionProbeUsage = ReflectionProbeUsage.Off;
		obj.AddComponent<MeshFilter>().sharedMesh = meshCombiner.CreateMesh();
		return obj;
	}

	private void UpdateOuteredges()
	{
		if (GameSettings.Instance.sRoomManager.DisableMeshRebuild)
		{
			return;
		}
		DirtyOuterMesh = false;
		CalculateInsulation();
		if (Outdoors)
		{
			if (MainFence != null)
			{
				UnityEngine.Object.Destroy(MainFence.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(MainFence);
			}
			GenerateFence();
			GenerateRoof();
			GenerateUpperPolygon();
			SetSizes(false);
			RecalculateStateVariables();
			UpdateVisibility();
			GameSettings.Instance.sRoomManager.UpdateSupport(Floor);
			return;
		}
		if (IsBalcony)
		{
			if (MainFence != null)
			{
				UnityEngine.Object.Destroy(MainFence.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(MainFence);
			}
			GenerateFence();
		}
		GenerateRoof();
		Material highlight = null;
		if (OuterWalls != null)
		{
			Renderer component = OuterWalls.GetComponent<Renderer>();
			if (component.sharedMaterials.Length > 1)
			{
				highlight = component.sharedMaterials[1];
			}
			UnityEngine.Object.Destroy(OuterWalls.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(OuterWalls);
		}
		OuterWalls = GenerateOuterWalls(this, _outsideColorID, OutsideMat);
		if (OuterWalls != null)
		{
			OuterWalls.transform.SetParent(base.transform);
			SetMaterial(OuterWalls.GetComponent<Renderer>(), highlight, MatType.Outer);
		}
		GenerateUpperPolygon();
		SetSizes(false);
		RecalculateStateVariables();
		GameSettings.Instance.sRoomManager.UpdateSupport(Floor);
		UpdateVisibility();
	}

	public void UpdateAllMaterials()
	{
		if (!Outdoors && InnerWalls != null)
		{
			SetMaterial(InnerWalls.GetComponent<MeshRenderer>(), null, MatType.Inner);
		}
	}

	private void SetMaterial(Renderer rend, Material highlight, MatType type)
	{
		Material material = RoomMaterialController.Instance.MainMat;
		if (!Pillar && !GameSettings.Instance.IsReferenceNull() && Floor == GameSettings.Instance.ActiveFloor)
		{
			GameSettings.WallState wallsDown = GameSettings.WallsDown;
			if (type == MatType.Inner && (wallsDown == GameSettings.WallState.Low || wallsDown == GameSettings.WallState.LowNoSeg))
			{
				material = RoomMaterialController.Instance.MainCutMat;
			}
			else if (type == MatType.Outer && (wallsDown == GameSettings.WallState.Low || wallsDown == GameSettings.WallState.LowNoSeg || wallsDown == GameSettings.WallState.Back))
			{
				material = RoomMaterialController.Instance.MainCutMat;
			}
		}
		highlight = highlight ?? ((rend.sharedMaterials.Length > 1) ? rend.sharedMaterials[1] : null);
		rend.sharedMaterials = ((!(highlight != null)) ? new Material[1] { material } : new Material[2] { material, highlight });
	}

	private static WallEdge FindSubstitute(IRoom room, WallEdge s1, WallEdge s2, WallEdge s3, bool first, bool reverse = false, bool allowSubEdge = true)
	{
		Vector2 vector = (reverse ? s3.Pos : s2.Pos);
		Vector2 vector2 = (reverse ? s2.Pos : s3.Pos);
		if (first)
		{
			float num = float.MaxValue;
			WallEdge result = s1;
			{
				foreach (IRoom key in s2.Links.Keys)
				{
					Room r;
					if (key.Outdoors || (object)(r = key as Room) == null)
					{
						continue;
					}
					WallEdge wallEdge = s2.FindConnectionIn(r);
					if (wallEdge != null && wallEdge != s3)
					{
						float num2 = LeftVal(vector2, vector, wallEdge.Pos);
						if ((allowSubEdge || num2 > -0.0001f) && num2 < num)
						{
							result = wallEdge;
							num = num2;
						}
					}
				}
				return result;
			}
		}
		float num3 = float.MinValue;
		WallEdge result2 = s3.Links[room];
		foreach (KeyValuePair<IRoom, WallEdge> link in s3.Links)
		{
			if (link.Value != s2 && !link.Key.Outdoors)
			{
				float num4 = LeftVal(vector, vector2, link.Value.Pos);
				if ((allowSubEdge || num4 < 0.0001f) && num4 > num3)
				{
					result2 = link.Value;
					num3 = num4;
				}
			}
		}
		return result2;
	}

	public static Vector2 GetOffset(WallEdge first, WallEdge second, WallEdge third, float offset, bool angleOffset = true)
	{
		return Utilities.GetOffset(first.Pos, second.Pos, third.Pos, offset, angleOffset);
	}

	private static bool CheckSmooth(WallEdge l, WallEdge a, WallEdge b, WallEdge n, float offset)
	{
		if (a.Smooth.Contains(b))
		{
			Vector2 offset2 = GetOffset(l, a, b, offset);
			Vector2 offset3 = GetOffset(a, b, n, offset);
			Vector3 lhs = (offset2 - a.Pos).normalized.ToVector3(0f);
			Vector3 rhs = (offset3 - b.Pos).normalized.ToVector3(0f);
			return Vector3.Dot(lhs, rhs) >= 0.9f;
		}
		return false;
	}

	private static bool GetSmooth(WallEdge a, WallEdge b, Vector2 offsetA, Vector2 offsetB, Vector3 defaultNormal, ref bool lastSmooth, out Vector3 nA, out Vector3 nB)
	{
		if (a.Smooth.Contains(b))
		{
			nA = (offsetA - a.Pos).normalized.ToVector3(0f);
			nB = (offsetB - b.Pos).normalized.ToVector3(0f);
			if (Vector3.Dot(nA, nB) < 0.89f)
			{
				if (lastSmooth)
				{
					nB = defaultNormal;
				}
				else
				{
					nA = defaultNormal;
				}
				lastSmooth = false;
			}
			else
			{
				lastSmooth = true;
			}
			return true;
		}
		lastSmooth = false;
		nA = defaultNormal;
		nB = defaultNormal;
		return false;
	}

	private static Vector3 GetNormal(Vector3 normal1, Vector3 normal2, float d, bool smoothed)
	{
		if (!smoothed)
		{
			return normal1;
		}
		return Vector3.Lerp(normal1, normal2, d).normalized;
	}

	private static Vector4 TangentFromNormal(IList<Vector3> normals, bool ext)
	{
		Vector3 vector = normals.Last();
		if (!ext)
		{
			return new Vector4(vector.z, 0f, 0f - vector.x, 1f);
		}
		return new Vector4(0f - vector.z, 0f, vector.x, -1f);
	}

	private void GenerateInnerPolygon()
	{
		if (GameSettings.Instance.sRoomManager.DisableMeshRebuild || Edges.Count < 3)
		{
			return;
		}
		DirtyInnerMesh = false;
		if (Outdoors)
		{
			if (InnerWalls != null)
			{
				UnityEngine.Object.Destroy(InnerWalls.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(InnerWalls);
			}
			GenerateUpperPolygon();
			UpdateFloor();
			UpdateDarkness();
			Area = Utilities.PolygonArea(Edges);
			RecalculateStateVariables();
			UpdateVisibility();
			DirtyLights();
			return;
		}
		UpdateFloor();
		bool flag = MakeBlack();
		Vector2 vector = new Vector2(flag ? RoomMaterialController.Instance.BlackColorID : _insideColorID, RoomMaterialController.GetMaterialIDAndSkirt(flag ? "CannotRent" : InsideMat, IsUpperAtrium));
		int num = 0;
		List<Vector2> list = new List<Vector2>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector4> list3 = new List<Vector4>();
		List<float> list4 = new List<float>();
		float num2 = 0f;
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge.Links[this];
		WallEdge wallEdge3 = wallEdge;
		MeshCombiner meshCombiner = new MeshCombiner("Room inner", true);
		float num3 = 150f;
		bool lastSmooth = CheckSmooth(Edges[Edges.Count - 2], Edges.Last(), Edges[0], Edges[1], WallOffset);
		bool flag2 = !Edges[1].IsBalconyWall(this) && Edges[1].Pos.FullAngleBetween(Edges[0].Pos, Edges[2].Pos) < num3;
		bool flag3 = !Edges[2].IsBalconyWall(this) && Edges[2].Pos.FullAngleBetween(Edges[1].Pos, Edges[3 % Edges.Count].Pos) < num3;
		do
		{
			if (wallEdge2.IsBalconyWall(this))
			{
				WallEdge wallEdge4 = wallEdge2.Links[this];
				WallEdge third = wallEdge4.Links[this];
				Vector2 offset = GetOffset(wallEdge, wallEdge2, wallEdge4, WallOffset / 2f);
				float num4 = (GetOffset(wallEdge2, wallEdge4, third, WallOffset / 2f) - offset).magnitude / 2f;
				num2 = (num2 + num4) % 1f;
				wallEdge = wallEdge2;
				wallEdge2 = wallEdge2.Links[this];
				wallEdge4 = wallEdge2.Links[this];
				flag2 = false;
				flag3 = false;
				num++;
				if (num > Edges.Count * 2)
				{
					BrokenWhileLoop(delegate
					{
						GenerateInnerPolygon();
					});
					return;
				}
				continue;
			}
			WallEdge wallEdge5 = wallEdge2.Links[this];
			WallEdge wallEdge6 = wallEdge5.Links[this];
			WallEdge first = wallEdge;
			WallEdge third2 = wallEdge5;
			FindSubBalcony(ref first, wallEdge2, ref third2);
			Vector2 offset2 = GetOffset(first, wallEdge2, third2, WallOffset / 2f);
			first = wallEdge2;
			third2 = wallEdge6;
			FindSubBalcony(ref first, wallEdge5, ref third2);
			Vector2 offset3 = GetOffset(first, wallEdge5, third2, WallOffset / 2f);
			Vector2 vector2 = offset3 - offset2;
			float magnitude = vector2.magnitude;
			vector2 = vector2.normalized;
			Vector3 nA = new Vector3(0f - vector2.y, 0f, vector2.x);
			Vector3 nB = nA;
			bool smooth = GetSmooth(wallEdge2, wallEdge5, offset2, offset3, nA, ref lastSmooth, out nA, out nB);
			float parentUVTiling = GetParentUVTiling(this, offset2, num2, true);
			float num5 = magnitude / 2f;
			Vector2 vector3 = -vector2 * WallOffset;
			Vector2 vector4 = offset2 + vector3;
			Vector2 vector5 = offset3 - vector3;
			list.Add(flag2 ? vector4 : offset2);
			list2.Add(nA);
			list3.Add(TangentFromNormal(list2, false));
			list4.Add(parentUVTiling - (flag2 ? (WallOffset / 2f) : 0f));
			List<Vector2> split = wallEdge2.GetSplit(wallEdge5);
			bool flag4 = true;
			bool flag5 = false;
			if (split != null)
			{
				for (int num6 = 0; num6 < split.Count; num6++)
				{
					Vector2 res;
					if (!Utilities.ProjectToLine(split[num6], offset2, offset3, out res))
					{
						if (((flag2 && num6 == 0) || (flag3 && num6 == split.Count - 1)) && Utilities.ProjectToLine(split[num6], vector4, vector5, out res))
						{
							if (num6 == 0)
							{
								list.Add(res);
								float num7 = offset2.Dist(res) / magnitude;
								list2.Add(GetNormal(nA, nB, num7, smooth));
								list3.Add(TangentFromNormal(list2, false));
								list4.Add(parentUVTiling + num5 * num7);
							}
							else if (num6 == split.Count - 1)
							{
								flag5 = true;
							}
						}
						else if (num6 == 0)
						{
							list.RemoveAt(list.Count - 1);
							list2.RemoveAt(list2.Count - 1);
							list3.RemoveAt(list3.Count - 1);
							list4.RemoveAt(list4.Count - 1);
						}
						else if (num6 == split.Count - 1)
						{
							flag4 = false;
						}
					}
					else
					{
						list.Add(res);
						float num8 = offset2.Dist(res) / magnitude;
						list2.Add(GetNormal(nA, nB, num8, smooth));
						list3.Add(TangentFromNormal(list2, false));
						list4.Add(parentUVTiling + num5 * num8);
					}
				}
			}
			if (flag4)
			{
				if (flag5)
				{
					list.Add(offset3);
					list2.Add(nB);
					list3.Add(TangentFromNormal(list2, false));
					list4.Add(parentUVTiling + num5);
				}
				list.Add(flag3 ? vector5 : offset3);
				list2.Add(nB);
				list3.Add(TangentFromNormal(list2, false));
				list4.Add(parentUVTiling + num5 + (flag3 ? (WallOffset / 2f) : 0f));
			}
			wallEdge2.GetAllMeshes(wallEdge5, offset2, num2, true, Floor, vector, meshCombiner);
			num2 = (parentUVTiling + num5) % 1f;
			wallEdge = wallEdge2;
			wallEdge2 = wallEdge5;
			wallEdge5 = wallEdge2.Links[this];
			flag2 = flag3;
			flag3 = !wallEdge5.IsBalconyWall(this) && wallEdge5.Pos.FullAngleBetween(wallEdge2.Pos, wallEdge5.Links[this].Pos) < num3;
			num++;
			if (num > Edges.Count * 2)
			{
				BrokenWhileLoop(delegate
				{
					GenerateInnerPolygon();
				});
				return;
			}
		}
		while (wallEdge != wallEdge3);
		meshCombiner.AddWall(list, list2, list3, list4, vector, true);
		if (Cheats.CeilingMeshes && !Pillar)
		{
			bool isBalcony = IsBalcony;
			if (Roof != null)
			{
				meshCombiner.AddMesh(Roof.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.TRS(new Vector3(0f, 3.99f, 0f), Quaternion.identity, new Vector3(1f, -1f, 1f)), true, Vector2.one * 0.5f, vector);
			}
			else if (isBalcony && FloorMesh != null)
			{
				meshCombiner.AddMesh(FloorMesh.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.TRS(new Vector3(0f, -0.1f, 0f), Quaternion.identity, new Vector3(1f, -1f, 1f)), true, Vector2.one * 0.5f, vector);
			}
			else if (Floor < 0 && FloorMesh != null)
			{
				meshCombiner.AddMesh(FloorMesh.GetComponent<MeshFilter>().sharedMesh, Matrix4x4.TRS(new Vector3(0f, 1.99f, 0f), Quaternion.identity, new Vector3(1f, -1f, 1f)), true, Vector2.one * 0.5f, vector);
			}
		}
		if (InnerWalls != null)
		{
			UnityEngine.Object.Destroy(InnerWalls.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(InnerWalls);
		}
		InnerWalls = new GameObject("InnerWalls");
		InnerWalls.tag = "HighlightOnlyDiag";
		InnerWalls.transform.position = Vector3.up * (Floor * 2);
		InnerWalls.transform.SetParent(base.transform);
		MeshRenderer meshRenderer = InnerWalls.AddComponent<MeshRenderer>();
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		SetMaterial(meshRenderer, null, MatType.Inner);
		InnerWalls.AddComponent<MeshFilter>().sharedMesh = meshCombiner.CreateMesh();
		GenerateUpperPolygon();
		UpdateDarkness();
		Area = Utilities.PolygonArea(Edges);
		RecalculateStateVariables();
		UpdateVisibility();
		RefreshDirtQuad();
		DirtyLights();
	}

	private bool CanOptimize(WallEdge s)
	{
		if (s.Links.Count != 1)
		{
			if (s.Links.Count == 2)
			{
				return s.Links.Values.All((WallEdge x) => x.Links.ContainsValue(s));
			}
			return false;
		}
		return true;
	}

	private bool CanOptimizeOutdoor(WallEdge s)
	{
		int num = 0;
		foreach (KeyValuePair<IRoom, WallEdge> link in s.Links)
		{
			if (!link.Key.Outdoors)
			{
				num++;
			}
		}
		switch (num)
		{
		case 1:
			return true;
		case 2:
			foreach (KeyValuePair<IRoom, WallEdge> link2 in s.Links)
			{
				if (link2.Key.Outdoors)
				{
					continue;
				}
				bool flag = false;
				foreach (KeyValuePair<IRoom, WallEdge> link3 in link2.Value.Links)
				{
					if (!link3.Key.Outdoors && link3.Value == s)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		default:
			return false;
		}
	}

	public void OptimizeSegments()
	{
		HashSet<Room> hashSet = new HashSet<Room>();
		bool flag = false;
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[(i == 0) ? (Edges.Count - 1) : (i - 1)];
			WallEdge wallEdge2 = Edges[i];
			WallEdge wallEdge3 = Edges[(i + 1) % Edges.Count];
			if (!CanOptimize(wallEdge2))
			{
				continue;
			}
			Vector2 normalized = (wallEdge2.Pos - wallEdge.Pos).normalized;
			Vector2 normalized2 = (wallEdge3.Pos - wallEdge2.Pos).normalized;
			if (!(wallEdge2.Pos == wallEdge.Pos) && !(normalized == normalized2) && !(Mathf.Abs(Mathf.Acos(Vector2.Dot(normalized, normalized2))) < (float)Math.PI / 60f))
			{
				continue;
			}
			if (wallEdge2 != wallEdge)
			{
				GameSettings.Instance.sRoomManager.AllSegments.Remove(wallEdge2);
			}
			flag = true;
			hashSet.AddRange(wallEdge2.Links.Keys.OfType<Room>());
			foreach (Room item in wallEdge2.Links.Keys.OfType<Room>())
			{
				item.Edges.Remove(wallEdge2);
			}
			foreach (KeyValuePair<IRoom, WallEdge> item2 in wallEdge.Links.ToList())
			{
				if (item2.Value == wallEdge2)
				{
					wallEdge.Links[item2.Key] = wallEdge3;
				}
			}
			foreach (KeyValuePair<IRoom, WallEdge> item3 in wallEdge3.Links.ToList())
			{
				if (item3.Value == wallEdge2)
				{
					wallEdge3.Links[item3.Key] = wallEdge;
				}
			}
			wallEdge.Smooth.Remove(wallEdge2);
			if (wallEdge2.Smooth.Contains(wallEdge3))
			{
				wallEdge.Smooth.Add(wallEdge3);
			}
			float num = wallEdge.Pos.Dist(wallEdge3.Pos);
			float num2 = wallEdge.Pos.Dist(wallEdge2.Pos);
			HashSet<WallSnap> value;
			if (wallEdge.Children.TryGetValue(wallEdge2, out value))
			{
				foreach (WallSnap item4 in value.ToList())
				{
					if (item4.IsAliveNotNull())
					{
						if (item4.FirstEdge == wallEdge)
						{
							item4.Init(wallEdge, wallEdge3, item4.WallPosition[wallEdge] / num, true);
						}
						else
						{
							item4.Init(wallEdge3, wallEdge, 1f - item4.WallPosition[wallEdge] / num, true);
						}
					}
				}
			}
			if (wallEdge2.Children.TryGetValue(wallEdge3, out value))
			{
				foreach (WallSnap item5 in value.ToList())
				{
					if (item5.IsAliveNotNull())
					{
						if (item5.FirstEdge == wallEdge2)
						{
							item5.Init(wallEdge, wallEdge3, (num2 + item5.WallPosition[wallEdge2]) / num, true);
						}
						else
						{
							item5.Init(wallEdge3, wallEdge, 1f - (num2 + item5.WallPosition[wallEdge2]) / num, true);
						}
					}
				}
			}
			i--;
		}
		if (flag)
		{
			QueueEdgeNetworkUpdate();
		}
		bool flag2 = true;
		if (Edges.Count >= 3 && this.IsAliveNotNull())
		{
			flag2 = TryFixEdges();
		}
		foreach (Room item6 in hashSet)
		{
			item6.DirtyInnerMesh = true;
			item6.TryFixEdges();
		}
		if (flag2 && Edges.Count < 3 && this.IsAliveNotNull())
		{
			DestroyGO();
		}
	}

	private bool CheckTopCondition(WallEdge e)
	{
		int num = 0;
		foreach (KeyValuePair<IRoom, WallEdge> link in e.Links)
		{
			if (link.Key.Outdoors)
			{
				continue;
			}
			bool flag = false;
			foreach (KeyValuePair<IRoom, WallEdge> link2 in link.Value.Links)
			{
				if (!link2.Key.Outdoors && link2.Value == e)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				num++;
			}
		}
		return num <= 1;
	}

	private void AppendTopEdge(WallEdge first, WallEdge second, WallEdge third, bool end, List<Vector2> topPolygon)
	{
		if (CanOptimizeOutdoor(second))
		{
			topPolygon.Add(GetOffset(first, second, third, WallOffset / 2f));
			topPolygon.Add(GetOffset(first, second, third, (0f - WallOffset) / 2f));
		}
		else if (CheckTopCondition(second))
		{
			topPolygon.Add(GetOffset(first, second, third, WallOffset / 2f));
			WallEdge wallEdge = FindSubstitute(this, first, second, third, true, false, false);
			WallEdge wallEdge2 = FindSubstitute(this, null, wallEdge, second, false, false, false);
			wallEdge = FindSubstitute(this, wallEdge, second, wallEdge2, true, false, false);
			wallEdge = ((wallEdge == wallEdge2) ? first : wallEdge);
			wallEdge2 = ((wallEdge2 == wallEdge) ? third : wallEdge2);
			topPolygon.Add(GetOffset(wallEdge, second, wallEdge2, (0f - WallOffset) / 2f));
		}
		else
		{
			Vector2 normalized = (end ? (second.Pos - first.Pos) : (third.Pos - second.Pos)).Turn90().normalized;
			topPolygon.Add(second.Pos + normalized * (WallOffset / 2f));
			topPolygon.Add(second.Pos - normalized * (WallOffset / 2f));
		}
	}

	public void FindSubBalcony(ref WallEdge first, WallEdge second, ref WallEdge third)
	{
		Room room = third.GetRoom(second);
		WallEdge value;
		if (room != null && (room == AtriumParent || room.AtriumParent == this || (AtriumParent != null && AtriumParent == room.AtriumParent)) && second.Links.TryGetValue(room, out value))
		{
			third = value;
		}
		room = second.GetRoom(first);
		if (room != null && (room == AtriumParent || room.AtriumParent == this || (AtriumParent != null && AtriumParent == room.AtriumParent)))
		{
			WallEdge wallEdge = second.FindConnectionIn(room);
			if (wallEdge != null)
			{
				first = wallEdge;
			}
		}
	}

	private static Vector2 GetBalconyOffset(IRoom room, WallEdge first, WallEdge second, WallEdge third)
	{
		Room room2;
		if ((object)(room2 = room as Room) != null && room2.IsBalcony)
		{
			Room room3 = second.GetRoom(first);
			bool flag = room3 != room2.AtriumParent;
			Room room4 = third.GetRoom(second);
			bool flag2 = room4 != room2.AtriumParent;
			if (flag2 && flag)
			{
				return Vector2.zero;
			}
			if (flag2)
			{
				if (room4 == null || room4.AtriumParent != room2.AtriumParent)
				{
					return (first.Pos - second.Pos).Turn90().normalized * (WallOffset / 2f);
				}
				return GetOffset(first, second, second.Links[room4], (0f - WallOffset) / 2f) - second.Pos;
			}
			if (flag)
			{
				if (room3 == null || room3.AtriumParent != room2.AtriumParent)
				{
					return (second.Pos - third.Pos).Turn90().normalized * (WallOffset / 2f);
				}
				return GetOffset(second.FindConnectionIn(room3), second, third, (0f - WallOffset) / 2f) - second.Pos;
			}
			return GetOffset(first, second, third, (0f - WallOffset) / 2f) - second.Pos;
		}
		return Vector2.zero;
	}

	private Vector2 GetAtriumOffset(WallEdge first, WallEdge second, WallEdge third, float offset)
	{
		if (IsBalcony)
		{
			Room room = second.GetRoom(first);
			bool flag = room != null && room.IsUpperAtriumNotBalcony;
			room = third.GetRoom(second);
			bool flag2 = room != null && room.IsUpperAtriumNotBalcony;
			if (flag2 && flag)
			{
				return second.Pos;
			}
			if (flag2)
			{
				return second.Pos + (third.Pos - second.Pos).normalized * offset;
			}
			if (flag)
			{
				return second.Pos - (second.Pos - first.Pos).normalized * offset;
			}
		}
		return GetOffset(first, second, third, offset);
	}

	public void GenerateUpperPolygon()
	{
		if (Outdoors)
		{
			if (UpperWalls != null)
			{
				UnityEngine.Object.Destroy(UpperWalls.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(UpperWalls);
				TopWallMesh = null;
			}
			return;
		}
		int num = 0;
		List<Vector2> list = new List<Vector2>();
		List<Vector2> list2 = null;
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge.Links[this];
		WallEdge wallEdge3 = wallEdge;
		do
		{
			bool sharedBalcony;
			if (wallEdge2.IsBalconyWall(this, out sharedBalcony))
			{
				WallEdge wallEdge4 = wallEdge2.Links[this];
				if (IsBalcony && !sharedBalcony)
				{
					if (list2 == null)
					{
						list2 = new List<Vector2>();
					}
					list2.Add(wallEdge2.Pos + GetBalconyOffset(this, wallEdge, wallEdge2, wallEdge4));
					list2.Add(wallEdge4.Pos + GetBalconyOffset(this, wallEdge2, wallEdge4, wallEdge4.Links[this]));
				}
				wallEdge = wallEdge2;
				wallEdge2 = wallEdge4;
				num++;
				continue;
			}
			WallEdge wallEdge5 = wallEdge2.Links[this];
			WallEdge first = wallEdge;
			WallEdge third = wallEdge5;
			FindSubBalcony(ref first, wallEdge2, ref third);
			AppendTopEdge(first, wallEdge2, third, false, list);
			wallEdge = wallEdge2;
			wallEdge2 = wallEdge5;
			WallEdge wallEdge6 = wallEdge2.Links[this];
			first = wallEdge;
			third = wallEdge6;
			FindSubBalcony(ref first, wallEdge2, ref third);
			AppendTopEdge(first, wallEdge2, third, true, list);
			num++;
			if (num > Edges.Count * 2)
			{
				BrokenWhileLoop(delegate
				{
					GenerateUpperPolygon();
				});
				return;
			}
		}
		while (wallEdge != wallEdge3);
		Mesh mesh = new Mesh();
		mesh.vertices = list.SelectInPlace((Vector2 x) => new Vector3(x.x, 2f, x.y));
		mesh.uv = Utilities.RepeatValue(Vector2.zero, list.Count);
		mesh.normals = Utilities.RepeatValue(Vector3.up, list.Count);
		List<int> list3 = new List<int>();
		for (int num2 = 0; num2 < list.Count; num2 += 4)
		{
			list3.Add(num2 + 2);
			list3.Add(num2 + 1);
			list3.Add(num2);
			list3.Add(num2 + 3);
			list3.Add(num2 + 1);
			list3.Add(num2 + 2);
		}
		mesh.triangles = list3.ToArray();
		if (BalconyFloor != null)
		{
			UnityEngine.Object.Destroy(BalconyFloor.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(BalconyFloor);
		}
		if (list2 != null)
		{
			Mesh mesh2 = new Mesh();
			Vector3[] array = new Vector3[list2.Count * 2];
			for (int num3 = 0; num3 < list2.Count; num3++)
			{
				Vector2 vector = list2[num3];
				array[num3 * 2] = new Vector3(vector.x, 0.01f, vector.y);
				array[num3 * 2 + 1] = new Vector3(vector.x, -0.1f, vector.y);
			}
			mesh2.vertices = array;
			mesh2.uv = Utilities.RepeatValue(Vector2.zero, array.Length);
			list3.Clear();
			for (int num4 = 0; num4 < array.Length; num4 += 4)
			{
				list3.Add(num4 + 2);
				list3.Add(num4 + 1);
				list3.Add(num4);
				list3.Add(num4 + 3);
				list3.Add(num4 + 1);
				list3.Add(num4 + 2);
			}
			mesh2.triangles = list3.ToArray();
			mesh2.RecalculateNormals();
			BalconyFloor = new GameObject("BalconyFloor");
			BalconyFloor.transform.position = Vector3.up * (Floor * 2);
			BalconyFloor.transform.SetParent(base.transform);
			MeshRenderer meshRenderer = BalconyFloor.AddComponent<MeshRenderer>();
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			meshRenderer.sharedMaterial = MaterialBank.Instance.TopWall;
			BalconyFloor.AddComponent<MeshFilter>().sharedMesh = mesh2;
		}
		if (UpperWalls != null)
		{
			UnityEngine.Object.Destroy(UpperWalls.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(UpperWalls);
		}
		UpperWalls = new GameObject("TopWall");
		UpperWalls.transform.position = Vector3.up * (Floor * 2);
		UpperWalls.transform.SetParent(base.transform);
		if (!Pillar)
		{
			TopRend = UpperWalls.AddComponent<MeshRenderer>();
			TopRend.reflectionProbeUsage = ReflectionProbeUsage.Off;
			TopRend.receiveShadows = false;
			TopRend.shadowCastingMode = ShadowCastingMode.Off;
			TopRend.sharedMaterial = MaterialBank.Instance.TopWall;
		}
		TopWallMesh = UpperWalls.AddComponent<MeshFilter>();
		TopWallMesh.sharedMesh = mesh;
	}

	public static GameObject GenerateFloor(IRoom room, int _colorID, string material)
	{
		int num = 0;
		List<Vector2> list = new List<Vector2>();
		WallEdge wallEdge = room.Edges[0];
		WallEdge wallEdge2 = wallEdge.Links[room];
		WallEdge wallEdge3 = wallEdge;
		do
		{
			WallEdge wallEdge4 = wallEdge2.Links[room];
			list.Add(wallEdge2.Pos + GetBalconyOffset(room, wallEdge, wallEdge2, wallEdge4));
			wallEdge = wallEdge2;
			wallEdge2 = wallEdge4;
			num++;
			if (num <= room.Edges.Count * 2)
			{
				continue;
			}
			Room room2;
			if ((object)(room2 = room as Room) != null)
			{
				return room2.BrokenWhileLoop(() => GenerateFloor(room, _colorID, material), null);
			}
			return null;
		}
		while (wallEdge != wallEdge3);
		Mesh mesh = new Mesh();
		Room frr;
		if ((object)(frr = room as Room) != null && frr._furnitures.ThreadSafeAny((Furniture x) => x.ExtraParent == frr && x.TwoFloors && x.MakeHole))
		{
			if (room.Floor == 0)
			{
				TimeOfDay.Instance.GroundTopDirty = true;
			}
			List<Vector2[]> holes;
			lock (frr._furnitures)
			{
				holes = frr._furnitures.Where((Furniture x) => x.ExtraParent == frr && x.TwoFloors && x.MakeHole).Select(delegate(Furniture x)
				{
					if (x.FinalNav == null)
					{
						x.UpdateBoundaryPoints();
					}
					return x.FinalNav;
				}).ToList();
			}
			ValueTuple<Vector2[], int[]> valueTuple = SwincBooster.Tesselate(list, holes, false);
			mesh.vertices = valueTuple.Item1.SelectInPlace((Vector2 x) => x.ToVector3(0f));
			mesh.triangles = valueTuple.Item2.ReverseArray();
		}
		else
		{
			Vector3[] vertices = list.Select((Vector2 x) => new Vector3(x.x, 0f, x.y)).ToArray();
			mesh.vertices = vertices;
			int[] triangles = new Triangulator(list.ToArray()).Triangulate();
			mesh.triangles = triangles;
		}
		Vector3[] vertices2 = mesh.vertices;
		bool flag = room.MakeBlack();
		mesh.normals = Utilities.RepeatValue(Vector3.up, vertices2.Length);
		mesh.tangents = Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), vertices2.Length);
		if (!object.Equals(room.FloorOffset, SVector3.Zero) || room.FloorRotation > 0f || room.FloorScale != 1f)
		{
			Matrix4x4 mat = Matrix4x4.TRS(new Vector3(room.FloorOffset.x, 0f, room.FloorOffset.y), Quaternion.Euler(0f, room.FloorRotation, 0f), Vector3.one * (1f - (room.FloorScale - 1f)));
			mesh.uv = vertices2.SelectInPlace((Vector3 x) => mat.MultiplyPoint(x).FlattenVector3());
		}
		else
		{
			mesh.uv = vertices2.SelectInPlace((Vector3 x) => new Vector2(x.x, x.z));
		}
		mesh.uv2 = Utilities.RepeatValue(new Vector2(material.Equals("None") ? RoomMaterialController.Instance.GroundColorID : (flag ? RoomMaterialController.Instance.BlackColorID : _colorID), RoomMaterialController.GetMaterialID(flag ? "CannotRent" : material)), vertices2.Length);
		GameObject obj = new GameObject("Floor");
		obj.tag = "HighlightAndDiag";
		obj.transform.position = new Vector3(0f, (float)(room.Floor * 2) + 0.01f, 0f);
		obj.AddComponent<MeshRenderer>().reflectionProbeUsage = ReflectionProbeUsage.Off;
		obj.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.TwoSided;
		obj.AddComponent<MeshFilter>().sharedMesh = mesh;
		return obj;
	}

	private void UpdateFloor()
	{
		DirtyFloorMesh = false;
		if (IsUpperAtriumNotBalcony || Pillar)
		{
			if (FloorMesh != null)
			{
				UnityEngine.Object.Destroy(FloorMesh.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(FloorMesh);
			}
			return;
		}
		Material highlight = null;
		if (FloorMesh != null)
		{
			Renderer component = ((OuterWalls != null) ? OuterWalls : MainFence).GetComponent<Renderer>();
			if (component.sharedMaterials.Length > 1)
			{
				highlight = component.sharedMaterials[1];
			}
			UnityEngine.Object.Destroy(FloorMesh.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(FloorMesh);
		}
		FloorMesh = GenerateFloor(this, _floorColorID, FloorMat);
		if (FloorMesh != null)
		{
			FloorMesh.transform.SetParent(base.transform);
			SetMaterial(FloorMesh.GetComponent<MeshRenderer>(), highlight, MatType.Floor);
			FloorMeshFilter = FloorMesh.GetComponent<MeshFilter>();
		}
		UpdateGrass();
	}

	public List<Vector2> GetFenceSegments()
	{
		List<Vector2> list = new List<Vector2>();
		List<Vector2> list2 = new List<Vector2>();
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge n1 = Edges[i];
			WallEdge wallEdge = Edges[(i + 1) % Edges.Count];
			int num = n1.FenceCount(wallEdge);
			if (num == 1 || (num == 2 && DID > wallEdge.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == n1).Key.GetUniqueID()))
			{
				list2.Clear();
				list2.Add(n1.Pos);
				List<Vector2> split = n1.GetSplit(wallEdge);
				if (split != null)
				{
					list2.AddRange(split);
				}
				list2.Add(wallEdge.Pos);
				for (int num2 = 0; num2 < list2.Count; num2 += 2)
				{
					Vector2 item = list2[num2];
					Vector2 item2 = list2[num2 + 1];
					list.Add(item);
					list.Add(item2);
				}
			}
		}
		return list;
	}

	private static bool HigherFencePriority(IRoom r1, IRoom r2)
	{
		if (r1.FenceHeight == r2.FenceHeight)
		{
			return r1.GetUniqueID() > r2.GetUniqueID();
		}
		return r1.FenceHeight > r2.FenceHeight;
	}

	public static KeyValuePair<GameObject, GameObject> GenerateFenceObjects(IRoom room, string style, Color color)
	{
		List<ObjectDatabase.FenceStyle> fenceStyles = ObjectDatabase.Instance.FenceStyles;
		ObjectDatabase.FenceStyle fenceStyle = (fenceStyles.Any((ObjectDatabase.FenceStyle x) => x.Name.Equals(style)) ? fenceStyles.First((ObjectDatabase.FenceStyle x) => x.Name.Equals(style)) : fenceStyles.First());
		List<CombineInstance> list = new List<CombineInstance>();
		List<CombineInstance> list2 = null;
		List<Vector3> list3 = new List<Vector3>();
		Room room2;
		bool flag = (object)(room2 = room as Room) != null && room2.IsBalcony;
		int num = (flag ? room.Edges[room.Edges.Count - 1].FenceCountBalcony(room as Room) : room.Edges[room.Edges.Count - 1].FenceCount(room.Edges[0]));
		List<Mesh> list4 = new List<Mesh>();
		List<Vector2> split = room.Edges.Last().GetSplit(room.Edges[0]);
		bool flag2 = num == 0 || (split != null && split.Last() == room.Edges[0].Pos);
		bool flag3 = fenceStyle.FenceMat != null;
		for (int num2 = 0; num2 < room.Edges.Count; num2++)
		{
			WallEdge n1 = room.Edges[num2];
			WallEdge wallEdge = room.Edges[(num2 + 1) % room.Edges.Count];
			int num3 = (flag ? n1.FenceCountBalcony(room as Room) : n1.FenceCount(wallEdge));
			if (num3 == 1 || (num3 == 2 && HigherFencePriority(room, wallEdge.Links.First((KeyValuePair<IRoom, WallEdge> x) => x.Value == n1).Key)))
			{
				list3.Clear();
				list3.Add(n1.Pos.ToVector3(0f));
				List<Vector2> split2 = n1.GetSplit(wallEdge);
				if (split2 != null)
				{
					list3.AddRange(split2.Select((Vector2 x) => x.ToVector3(0f)));
				}
				list3.Add(wallEdge.Pos.ToVector3(0f));
				Quaternion q = Quaternion.LookRotation(list3[0] - list3.Last());
				for (int num4 = 0; num4 < list3.Count; num4 += 2)
				{
					Vector3 vector = list3[num4];
					Vector3 vector2 = list3[num4 + 1];
					Vector3 vector3 = vector2 - vector;
					if (vector3 == Vector3.zero)
					{
						if (num4 == 0 && !flag2)
						{
							list.Add(new CombineInstance
							{
								mesh = fenceStyle.Pole,
								transform = Matrix4x4.TRS(vector, q, Vector3.one)
							});
						}
						flag2 = true;
						continue;
					}
					flag2 = false;
					float magnitude = vector3.magnitude;
					CombineInstance item = default(CombineInstance);
					Mesh item2 = (item.mesh = StretchUV(fenceStyle.Fence, magnitude));
					list4.Add(item2);
					item.transform = Matrix4x4.TRS((vector + vector2) * 0.5f, q, new Vector3(1f, 1f, magnitude));
					if (flag3)
					{
						if (list2 == null)
						{
							list2 = new List<CombineInstance>();
						}
						list2.Add(item);
					}
					else
					{
						list.Add(item);
					}
					if (num4 > 0 || num > 0)
					{
						list.Add(new CombineInstance
						{
							mesh = fenceStyle.Pole,
							transform = Matrix4x4.TRS(vector, q, Vector3.one)
						});
					}
					if (list3.Count > 2 && num4 < list3.Count - 2)
					{
						list.Add(new CombineInstance
						{
							mesh = fenceStyle.Pole,
							transform = Matrix4x4.TRS(vector2, q, Vector3.one)
						});
					}
				}
			}
			else
			{
				flag2 = true;
			}
			num = num3;
		}
		GameObject obj = new GameObject("MainFence");
		obj.tag = "Highlight";
		obj.transform.position = Vector3.up * (room.Floor * 2);
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		meshRenderer.sharedMaterial = fenceStyle.Mat;
		Mesh mesh2 = new Mesh();
		mesh2.CombineMeshes(list.ToArray());
		mesh2.colors = Utilities.RepeatValue(color, mesh2.vertexCount);
		obj.AddComponent<MeshFilter>().sharedMesh = mesh2;
		GameObject gameObject = null;
		if (list2 != null)
		{
			gameObject = new GameObject("SubFence");
			gameObject.transform.position = Vector3.up * (room.Floor * 2);
			MeshRenderer meshRenderer2 = gameObject.AddComponent<MeshRenderer>();
			meshRenderer2.reflectionProbeUsage = ReflectionProbeUsage.Off;
			meshRenderer2.sharedMaterial = fenceStyle.FenceMat;
			Mesh mesh3 = new Mesh();
			mesh3.CombineMeshes(list2.ToArray());
			gameObject.AddComponent<MeshFilter>().sharedMesh = mesh3;
		}
		list4.ForEach(UnityEngine.Object.Destroy);
		return new KeyValuePair<GameObject, GameObject>(obj, gameObject);
	}

	private void GenerateFence()
	{
		if (SubFence != null)
		{
			UnityEngine.Object.Destroy(SubFence.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(SubFence);
		}
		KeyValuePair<GameObject, GameObject> keyValuePair = GenerateFenceObjects(this, FenceStyle, FenceColor);
		MainFence = keyValuePair.Key;
		SubFence = keyValuePair.Value;
		MainFence.transform.SetParent(base.transform);
		Highlight(IsHighlight, IsSecondary);
		if (SubFence != null)
		{
			SubFence.transform.SetParent(base.transform);
		}
	}

	private static Mesh StretchUV(Mesh m, float length)
	{
		Mesh mesh = new Mesh();
		mesh.vertices = m.vertices;
		mesh.triangles = m.triangles;
		mesh.tangents = m.tangents;
		mesh.normals = m.normals;
		Vector2[] array = new Vector2[m.uv.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Vector2(m.uv[i].x * length, m.uv[i].y);
		}
		mesh.uv = array;
		return mesh;
	}

	private void UpdateDarkness()
	{
		if (Outdoors || (AtriumParent != null && AtriumParent != this))
		{
			if (Darkness != null)
			{
				UnityEngine.Object.Destroy(Darkness.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(Darkness);
			}
			return;
		}
		int num = 0;
		List<Vector2> floorPolygon = new List<Vector2>();
		WallEdge wallEdge = Edges[0];
		WallEdge wallEdge2 = wallEdge.Links[this];
		WallEdge wallEdge3 = wallEdge;
		do
		{
			WallEdge wallEdge4 = wallEdge2.Links[this];
			floorPolygon.Add(GetOffset(wallEdge, wallEdge2, wallEdge4, WallOffset / 2f + 0.01f));
			wallEdge = wallEdge2;
			wallEdge2 = wallEdge4;
			num++;
			if (num > Edges.Count * 2)
			{
				BrokenWhileLoop(delegate
				{
					UpdateDarkness();
				});
				return;
			}
		}
		while (wallEdge != wallEdge3);
		Mesh mesh = new Mesh();
		Vector3[] array = floorPolygon.AppendSelfArray((Vector2 x) => x.ToVector3(0f), (Vector2 x) => x.ToVector3(1f));
		Vector2[] array2 = new Vector2[array.Length];
		for (int num2 = 0; num2 < floorPolygon.Count; num2++)
		{
			array2[num2] = Vector2.zero;
			array2[num2 + floorPolygon.Count] = Vector2.one;
		}
		mesh.vertices = array;
		Triangulator triangulator = new Triangulator(floorPolygon.ToArray());
		List<int> list = new List<int>();
		list.AddRange(from x in triangulator.Triangulate()
			select x + floorPolygon.Count);
		for (int num3 = 0; num3 < floorPolygon.Count; num3++)
		{
			list.Add(num3);
			list.Add(floorPolygon.Count + num3);
			if (num3 == floorPolygon.Count - 1)
			{
				list.Add(floorPolygon.Count);
				list.Add(floorPolygon.Count);
				list.Add(0);
			}
			else
			{
				list.Add(floorPolygon.Count + num3 + 1);
				list.Add(floorPolygon.Count + num3 + 1);
				list.Add(num3 + 1);
			}
			list.Add(num3);
		}
		mesh.SetTriangles(list, 0);
		mesh.normals = Utilities.RepeatValue(Vector3.up, array.Length);
		mesh.uv = array2;
		if (Darkness != null)
		{
			UnityEngine.Object.Destroy(Darkness.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(Darkness);
		}
		Darkness = new GameObject("Darkness");
		Darkness.layer = 1;
		Transform obj = Darkness.transform;
		Vector3 position = (DustFilter.transform.position = new Vector3(0f, Floor * 2, 0f));
		obj.position = position;
		Darkness.transform.SetParent(base.transform);
		DarknessRend = Darkness.AddComponent<MeshRenderer>();
		DarknessRend.sharedMaterial = MaterialBank.Instance.GetDarkness(1f);
		DarknessRend.reflectionProbeUsage = ReflectionProbeUsage.Off;
		DarknessRend.shadowCastingMode = ShadowCastingMode.Off;
		DarknessRend.receiveShadows = false;
		Darkness.AddComponent<MeshFilter>().sharedMesh = mesh;
		DustFilter.sharedMesh = mesh;
	}

	public static bool Clockwise(List<WallEdge> s)
	{
		float num = 0f;
		for (int i = 0; i < s.Count; i++)
		{
			WallEdge wallEdge = s[i];
			WallEdge wallEdge2 = s[(i + 1) % s.Count];
			num += (wallEdge2.Pos.x - wallEdge.Pos.x) * (wallEdge2.Pos.y + wallEdge.Pos.y);
		}
		return num > 0f;
	}

	public static void DrawArrow(Vector3 a, Vector3 b, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		Gizmos.DrawLine(a, b);
		Vector3 forward = b - a;
		Vector3 vector = Quaternion.LookRotation(forward) * Quaternion.Euler(0f, 180f + arrowHeadAngle, 0f) * new Vector3(0f, 0f, 1f);
		Vector3 vector2 = Quaternion.LookRotation(forward) * Quaternion.Euler(0f, 180f - arrowHeadAngle, 0f) * new Vector3(0f, 0f, 1f);
		Gizmos.DrawRay(b, vector * arrowHeadLength);
		Gizmos.DrawRay(b, vector2 * arrowHeadLength);
	}

	private void DrawBSP(BSPTree<TriangleNode> node, Rect bounds, int d = 0)
	{
		if (node == null)
		{
			return;
		}
		Gizmos.color = ((d == 0) ? Color.white : Color.Lerp(Color.red, Color.green, Mathf.Clamp01((float)d / 10f)));
		d++;
		if (node.Nodes.Count == 0)
		{
			if (node.Vertical)
			{
				float num = Mathf.Clamp(node.Middle, bounds.xMin, bounds.xMax);
				Gizmos.DrawLine(new Vector3(num, base.transform.position.y, bounds.yMin), new Vector3(num, base.transform.position.y, bounds.yMax));
				DrawBSP(node.Smaller, Rect.MinMaxRect(bounds.xMin, bounds.yMin, num, bounds.yMax), d);
				DrawBSP(node.Larger, Rect.MinMaxRect(num, bounds.yMin, bounds.xMax, bounds.yMax), d);
			}
			else
			{
				float num2 = Mathf.Clamp(node.Middle, bounds.yMin, bounds.yMax);
				Gizmos.DrawLine(new Vector3(bounds.xMin, base.transform.position.y, num2), new Vector3(bounds.xMax, base.transform.position.y, num2));
				DrawBSP(node.Smaller, Rect.MinMaxRect(bounds.xMin, bounds.yMin, bounds.xMax, num2), d);
				DrawBSP(node.Larger, Rect.MinMaxRect(bounds.xMin, num2, bounds.xMax, bounds.yMax), d);
			}
		}
	}

	private bool IsNotTopAtrium()
	{
		if (AtriumParent != null)
		{
			if (AtriumParent == this)
			{
				return true;
			}
			if (IsBalcony)
			{
				return AtriumParent.AtriumParent.AtriumChildren.Last() != AtriumParent;
			}
			if (AtriumParent.AtriumChildren.Last() != this)
			{
				return true;
			}
		}
		return false;
	}

	public static GameObject GenerateRoofObject(IRoom room, int colorID)
	{
		List<Vector2> list = new List<Vector2>();
		int num = 0;
		WallEdge wallEdge = room.Edges[0];
		WallEdge wallEdge2 = wallEdge;
		WallEdge wallEdge3 = wallEdge.Links[room];
		do
		{
			WallEdge wallEdge4 = wallEdge3.Links[room];
			WallEdge wallEdge5 = FindSubstitute(room, wallEdge, wallEdge3, wallEdge4, true);
			WallEdge wallEdge6 = FindSubstitute(room, null, wallEdge, wallEdge3, false);
			wallEdge5 = ((wallEdge5 == wallEdge4) ? wallEdge : wallEdge5);
			wallEdge6 = ((wallEdge6 == wallEdge) ? wallEdge4 : wallEdge6);
			Vector2 offset = GetOffset(wallEdge, wallEdge3, wallEdge6, (0f - WallOffset) / 2f);
			Vector2 offset2 = GetOffset(wallEdge5, wallEdge3, wallEdge4, (0f - WallOffset) / 2f);
			bool flag = !wallEdge3.IsAgainstOutdoors(wallEdge) && wallEdge3.Links.ContainsValue(wallEdge);
			bool flag2 = !wallEdge4.IsAgainstOutdoors(wallEdge3) && wallEdge4.Links.ContainsValue(wallEdge3);
			if (flag2 && flag)
			{
				list.Add(wallEdge3.Pos);
			}
			else if (flag2)
			{
				list.Add(offset);
				list.Add(wallEdge3.Pos);
			}
			else if (flag)
			{
				list.Add(wallEdge3.Pos);
				list.Add(offset2);
			}
			else if (offset == offset2)
			{
				list.Add(offset);
			}
			else
			{
				list.Add(offset);
				list.Add(wallEdge3.Pos);
				list.Add(offset2);
			}
			wallEdge = wallEdge3;
			wallEdge3 = wallEdge4;
			num++;
			if (num <= room.Edges.Count * 2)
			{
				continue;
			}
			Room brr;
			if ((object)(brr = room as Room) != null)
			{
				return brr.BrokenWhileLoop(() => GenerateRoofObject(brr, colorID), null);
			}
			return null;
		}
		while (wallEdge != wallEdge2);
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			int index = (num2 + 1) % list.Count;
			if (list[num2] == list[index])
			{
				list.RemoveAt(index);
				num2--;
			}
		}
		Mesh mesh = new Mesh();
		Room rr = room as Room;
		List<Furniture> list2 = ((rr != null) ? rr._furnitures.Where((Furniture x) => x.TwoFloors && x.MakeHole && x.Parent == rr && x.CheckTwoFloorValid()).ToList() : null);
		if (list2 != null && list2.Count > 0)
		{
			List<Vector2[]> holes;
			lock (rr._furnitures)
			{
				holes = rr._furnitures.Where((Furniture x) => x.Parent == rr && x.TwoFloors && x.MakeHole).Select(delegate(Furniture x)
				{
					if (x.FinalNav == null)
					{
						x.UpdateBoundaryPoints();
					}
					return x.FinalNav;
				}).ToList();
			}
			rr.HasTwoFloor = true;
			ValueTuple<Vector2[], int[]> valueTuple = SwincBooster.Tesselate(list, holes, false);
			mesh.vertices = valueTuple.Item1.SelectInPlace((Vector2 x) => x.ToVector3(2f));
			mesh.triangles = valueTuple.Item2.ReverseArray();
		}
		else
		{
			if (rr != null)
			{
				rr.HasTwoFloor = false;
			}
			mesh.vertices = list.Select((Vector2 x) => new Vector3(x.x, 2f, x.y)).ToArray();
			Triangulator triangulator = new Triangulator(list.ToArray());
			mesh.triangles = triangulator.Triangulate();
		}
		Vector3[] vertices = mesh.vertices;
		mesh.normals = Utilities.RepeatValue(Vector3.up, vertices.Length);
		mesh.tangents = Utilities.RepeatValue(new Vector4(1f, 0f, 0f, -1f), vertices.Length);
		mesh.uv = Utilities.RepeatValue(RoomMaterialController.Instance.ColorController.GetColorUV(colorID), vertices.Length);
		GameObject obj = new GameObject("Roof");
		obj.transform.position = new Vector3(0f, room.Pillar ? ((float)(room.Floor * 2) - 0.001f) : ((float)(room.Floor * 2)), 0f);
		MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
		meshRenderer.shadowCastingMode = ShadowCastingMode.TwoSided;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		meshRenderer.sharedMaterial = RoomMaterialController.Instance.StandardRoof;
		obj.AddComponent<MeshFilter>().sharedMesh = mesh;
		return obj;
	}

	private void GenerateRoof()
	{
		bool flag = IsNotTopAtrium();
		if (flag || Outdoors)
		{
			if (flag)
			{
				UpdateSurrounded();
			}
			if (Roof != null)
			{
				UnityEngine.Object.Destroy(Roof.GetComponent<MeshFilter>().sharedMesh);
				UnityEngine.Object.Destroy(Roof);
			}
			return;
		}
		UpdateSurrounded();
		DirtyRoofMesh = false;
		if (Floor == -1)
		{
			HasTwoFloor = _furnitures.ThreadSafeAny((Furniture x) => x.TwoFloors && x.MakeHole && x.Parent == this);
			if (!Pillar)
			{
				return;
			}
		}
		if (Roof != null)
		{
			UnityEngine.Object.Destroy(Roof.GetComponent<MeshFilter>().sharedMesh);
			UnityEngine.Object.Destroy(Roof);
		}
		Roof = GenerateRoofObject(this, _outsideColorID);
		if (Roof != null)
		{
			Roof.transform.SetParent(base.transform);
		}
	}

	private bool TryNav(Vector2[] r, List<Vector2[]> holes, int fixHoles, bool divide, List<Vector3> holeTr, bool completeFail, ref KeyValuePair<Vector2[], int[]> result, bool editorError = true)
	{
		try
		{
			result = Utilities.SubtractAndTriangulate(r, holes, fixHoles, divide, holeTr);
			return true;
		}
		catch (Exception ex)
		{
			if (completeFail)
			{
				if (Dummy)
				{
					ErrorLogging.AddException(new Exception("Error in ground nav:" + Environment.NewLine + ex.ToString()));
					result = Utilities.SubtractAndTriangulate(r, RoadManager.Instance.Landmarks.Select((Landmark x) => x.GetNavMesh()).ToList(), 0, false);
					MiscMsg.SendMsg("GroundNav", Versioning.VersionString + "\n" + ConvertToString());
				}
				else
				{
					ErrorLogging.AddException(new Exception("Error in room nav:" + Environment.NewLine + ex.ToString()));
					Vector2[] expanded;
					using (new ReadWriteLockUse(GameReader.SaveLock))
					{
						expanded = GetExpanded(WallOffset / 2f + 0.01f);
					}
					result = Utilities.SubtractAndTriangulate(expanded, new List<Vector2[]>(), 1, true);
					MiscMsg.SendMsg("RoomNav", Versioning.VersionString + "\n" + ConvertToString());
				}
			}
		}
		return false;
	}

	private void BuildNavMesh()
	{
		lock (NavLock)
		{
			DirtyNavMesh = false;
			KeyValuePair<Vector2[], int[]> result = new KeyValuePair<Vector2[], int[]>(null, null);
			if (!Dummy)
			{
				List<Furniture> list;
				lock (_furnitures)
				{
					list = _furnitures.Where((Furniture furniture) => furniture.Height1 < Actor.HumanHeight && furniture.FinalNav != null && furniture.FinalNav.Length != 0).ToList();
				}
				List<Vector3> holeTr = list.Select((Furniture furniture) => furniture.OriginalPosition).ToList();
				List<Vector2[]> list2 = list.Select((Furniture furniture) => furniture.FinalNav.ToArray()).ToList();
				Vector2[] expanded;
				using (new ReadWriteLockUse(GameReader.SaveLock))
				{
					expanded = GetExpanded(WallOffset / 2f + 0.01f);
				}
				if (!TryNav(expanded, list2, 0, true, holeTr, false, ref result, false) && !TryNav(expanded, list2, 1, true, holeTr, false, ref result))
				{
					if (list2.Count > list.Count)
					{
						list2.RemoveRange(list.Count, list2.Count - list.Count);
					}
					if (TryNav(expanded, list2, 2, true, holeTr, true, ref result))
					{
					}
				}
			}
			else
			{
				List<Vector2[]> holes = new List<Vector2[]>();
				if (_furnitures.Count > 0)
				{
					_furnitures.ThreadSafeForEach(delegate(Furniture f)
					{
						if (f.Height1 < Actor.HumanHeight && f.FinalNav != null && f.FinalNav.Length != 0)
						{
							holes.Add(f.FinalNav);
						}
					});
				}
				for (int num = 0; num < RoadManager.Instance.Landmarks.Count; num++)
				{
					Vector2[] navMesh = RoadManager.Instance.Landmarks[num].GetNavMesh();
					if (navMesh != null)
					{
						holes.Add(navMesh);
					}
				}
				foreach (RoadNode item in RoadManager.Instance.GetParkingMesh())
				{
					if (item.Parent.floor == 0 && item.NavMesh != null)
					{
						holes.Add(item.NavMesh);
					}
				}
				float roadSize = RoadManager.Instance.RoadSize;
				foreach (RoadSegment groundLevelRamp in RoadManager.Instance.GroundLevelRamps)
				{
					holes.Add(new Vector2[4]
					{
						new Vector2((float)groundLevelRamp.x * roadSize - 0.1f, (float)groundLevelRamp.y * roadSize - 0.1f),
						new Vector2((float)groundLevelRamp.x * roadSize + roadSize + 0.1f, (float)groundLevelRamp.y * roadSize - 0.1f),
						new Vector2((float)groundLevelRamp.x * roadSize + roadSize + 0.1f, (float)groundLevelRamp.y * roadSize + roadSize + 0.1f),
						new Vector2((float)groundLevelRamp.x * roadSize - 0.1f, (float)groundLevelRamp.y * roadSize + roadSize + 0.1f)
					});
				}
				List<Room> rooms = GameSettings.Instance.sRoomManager.GetRooms();
				using (new ReadWriteLockUse(GameReader.SaveLock))
				{
					for (int num2 = 0; num2 < rooms.Count; num2++)
					{
						Room room = rooms[num2];
						if (room.Floor == 0 && room.Edges != null)
						{
							holes.Add(room.GetExpanded((0f - WallOffset) / 2f));
						}
					}
				}
				int count = holes.Count;
				Vector2[] r = new Vector2[4]
				{
					new Vector2(-1f, -1f),
					new Vector2(257f, -1f),
					new Vector2(257f, 257f),
					new Vector2(-1f, 257f)
				};
				if (!TryNav(r, holes, 0, false, null, false, ref result, false) && !TryNav(r, holes, 1, false, null, false, ref result))
				{
					if (holes.Count > count)
					{
						holes.RemoveRange(count, holes.Count - count);
					}
					TryNav(r, holes, 2, false, null, true, ref result);
				}
			}
			BSPNavMap = null;
			try
			{
				NavMap = TriangleNode.GenerateMap(result.Key, result.Value, 0.3f, Dummy);
			}
			catch (Exception ex)
			{
				ErrorLogging.AddException(ex);
				Vector2[] expanded2;
				using (new ReadWriteLockUse(GameReader.SaveLock))
				{
					expanded2 = GetExpanded(WallOffset / 2f + 0.01f);
				}
				result = Utilities.SubtractAndTriangulate(expanded2, new List<Vector2[]>(), 1, true);
				NavMap = TriangleNode.GenerateMap(result.Key, result.Value, 0.3f, Dummy);
				MiscMsg.SendMsg("Room triangulate", Versioning.VersionString + "\n" + ConvertToString());
			}
			RemoveUnreachableNavNodes();
			if (NavMap.Length >= 16)
			{
				BSPNavMap = new BSPTree<TriangleNode>(NavMap.Length / 8, 8, BSPComparer, BSPMiddle);
				float x = NavMap.Average((TriangleNode triangleNode) => triangleNode.Center.x);
				float y = NavMap.Average((TriangleNode triangleNode) => triangleNode.Center.y);
				Vector2 cv = new Vector2(x, y);
				foreach (TriangleNode item2 in NavMap.OrderByDescending((TriangleNode triangleNode) => (triangleNode.Center - cv).sqrMagnitude))
				{
					BSPNavMap.AddNode(item2);
				}
			}
		}
		List<Furniture> list3 = new List<Furniture>();
		if (AtriumParent != null)
		{
			foreach (Room item3 in GetElligableAtriumSearch())
			{
				lock (item3._furnitures)
				{
					list3.AddRange(item3._furnitures.Where((Furniture f) => (f.SnapPoints.Length != 0 || f.InteractionPoints.Length != 0) && f.InteractionParent == this));
				}
			}
		}
		else
		{
			lock (_furnitures)
			{
				list3.AddRange(_furnitures.Where((Furniture f) => f.SnapPoints.Length != 0 || f.InteractionPoints.Length != 0));
			}
		}
		if (list3.Count > 16)
		{
			int num3 = Mathf.RoundToInt(Mathf.Sqrt(list3.Count));
			int num4 = Mathf.CeilToInt((float)list3.Count / (float)num3);
			ThreadCountdown threadCountdown = new ThreadCountdown(num4);
			for (int num5 = 0; num5 < num4; num5++)
			{
				ThreadPool.QueueUserWorkItem(UpdateFreeNav, new FreeNavObject(num5, num3, list3, threadCountdown));
			}
			threadCountdown.Wait();
		}
		else
		{
			for (int num6 = 0; num6 < list3.Count; num6++)
			{
				try
				{
					list3[num6].UpdateFreeNavs(true);
				}
				catch (Exception ex2)
				{
					ErrorLogging.AddException(ex2);
				}
			}
		}
		SetNavMeshRunning(false);
		GameSettings.EndNav(this);
		_navMeshLocked = false;
	}

	public IEnumerable<Room> GetElligableAtriumSearch()
	{
		yield return this;
		if (IsBalcony)
		{
			Room mP = AtriumParent.AtriumParent;
			int num = mP.AtriumChildren.IndexOf(AtriumParent);
			for (int i = num + 1; i < mP.AtriumChildren.Count; i++)
			{
				yield return mP.AtriumChildren[i];
			}
		}
		else
		{
			for (int i = 0; i < AtriumChildren.Count; i++)
			{
				yield return AtriumChildren[i];
			}
		}
	}

	private void UpdateFreeNav(object state)
	{
		FreeNavObject freeNavObject = (FreeNavObject)state;
		int num = freeNavObject.Num;
		int count = freeNavObject.Count;
		try
		{
			int num2 = Mathf.Min(num * count + count, freeNavObject.Furn.Count);
			using (new ReadWriteLockUse(GameReader.SaveLock))
			{
				for (int i = num * count; i < num2; i++)
				{
					freeNavObject.Furn[i].UpdateFreeNavs(true);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorLogging.AddException(ex);
			throw;
		}
		finally
		{
			freeNavObject.Counter.FinishTask();
		}
	}

	private static int BSPComparer(TriangleNode n, bool v, float x)
	{
		float num = (v ? n.rect.xMin : n.rect.yMin);
		float num2 = (v ? n.rect.xMax : n.rect.yMax);
		if (x + 0.01f < num)
		{
			return 1;
		}
		if (x - 0.01f > num2)
		{
			return -1;
		}
		return 0;
	}

	private static float BSPMiddle(List<TriangleNode> nodes, bool v)
	{
		float num = 0f;
		for (int i = 0; i < nodes.Count; i++)
		{
			num += (v ? nodes[i].Center.x : nodes[i].Center.y);
		}
		return num / (float)Mathf.Max(1, nodes.Count);
	}

	private void PostNavMesh()
	{
		if (NavMap == null)
		{
			return;
		}
		HashList<Furniture> furnitures = _furnitures;
		for (int i = 0; i < furnitures.Count; i++)
		{
			for (int j = 0; j < furnitures[i].InteractionPoints.Length; j++)
			{
				InteractionPoint interactionPoint = furnitures[i].InteractionPoints[j];
				if (interactionPoint.DirtyPos)
				{
					interactionPoint.transform.position = interactionPoint.pos;
					interactionPoint.DirtyPos = false;
				}
			}
		}
		if (Dummy)
		{
			GameSettings.Instance.sRoomManager.PathController.UpdateEndPoints();
			GameSettings.Instance.RefreshGaragePorts(0);
		}
		FixActorPositions();
	}

	private void RemoveUnreachableNavNodes()
	{
		if (Dummy)
		{
			return;
		}
		HashSet<TriangleNode> hashSet = new HashSet<TriangleNode>();
		foreach (IRoomConnector connector in GetConnectors())
		{
			TriangleNode nodeAt = GetNodeAt(connector.GetOffsetPos(this).FlattenVector3(), false);
			if (nodeAt != null)
			{
				AddToReachable(nodeAt, hashSet);
			}
		}
		if (hashSet.Count > 0 && hashSet.Count < NavMap.Length)
		{
			NavMap = hashSet.ToArray();
		}
	}

	private void AddToReachable(TriangleNode node, HashSet<TriangleNode> map)
	{
		Stack<TriangleNode> stack = new Stack<TriangleNode>();
		if (!map.Contains(node))
		{
			stack.Push(node);
		}
		while (stack.Count > 0)
		{
			TriangleNode triangleNode = stack.Pop();
			map.Add(triangleNode);
			List<PathNode<TriangleNode>> connections = triangleNode.PathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<TriangleNode> pathNode = connections[i];
				if (!map.Contains(pathNode.Point))
				{
					stack.Push(pathNode.Point);
				}
			}
		}
	}

	public override int GetFloor()
	{
		return Floor;
	}

	public override bool IsSelectableInView()
	{
		if (Floor <= -1)
		{
			return GameSettings.Instance.ActiveFloor < 0;
		}
		return true;
	}

	public override string ToString()
	{
		return "Room: " + DID;
	}

	public string ConvertToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Dummy)
		{
			foreach (Vector2[] item in from x in GameSettings.Instance.sRoomManager.GetRooms()
				where x.Floor == 0 && x.Edges != null
				select x.GetExpanded((0f - WallOffset) / 2f))
			{
				for (int num = 0; num < item.Length; num++)
				{
					stringBuilder.AppendLine(item[num].x + "\t" + item[num].y);
				}
				stringBuilder.AppendLine();
			}
		}
		else
		{
			foreach (WallEdge edge in Edges)
			{
				stringBuilder.Append(edge.Pos.x + ";" + edge.Pos.y + ";");
			}
			stringBuilder.AppendLine();
			int num2 = 0;
			Dictionary<Furniture, int> dictionary = new Dictionary<Furniture, int>();
			lock (_furnitures)
			{
				foreach (Furniture item2 in _furnitures.OrderBy((Furniture x) => x.IsSnapping ? 1 : 0))
				{
					stringBuilder.Append(item2.name + ";");
					stringBuilder.Append(item2.OriginalPosition.x + ";" + item2.OriginalPosition.z + ";");
					stringBuilder.Append(item2.transform.rotation.eulerAngles.y + ";");
					if (item2.WallFurn)
					{
						stringBuilder.Append(Edges.IndexOf(item2.FirstEdge) + ";" + Edges.IndexOf(item2.SecondEdge) + ";" + item2.WallPosition[item2.FirstEdge] + ";");
					}
					else
					{
						stringBuilder.Append("-1;-1;-1;");
					}
					if (item2.IsSnapping)
					{
						stringBuilder.Append(dictionary[item2.SnappedTo.Parent] + ";" + item2.SnappedTo.Id);
					}
					else
					{
						stringBuilder.Append("-1;-1");
					}
					stringBuilder.AppendLine();
					dictionary[item2] = num2;
					num2++;
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void UpdateFurnitureWallNearness()
	{
		_furnitures.ThreadSafeForEach(delegate(Furniture f)
		{
			if (f.IsAliveNotNull())
			{
				f.CalcEdge();
			}
		});
	}

	public Vector2? FindRandomSpot()
	{
		if (NavMap == null || NavMap.Length == 0)
		{
			return null;
		}
		TriangleNode randomWhere = NavMap.GetRandomWhere((TriangleNode x) => x.Area > 0.5f);
		if (randomWhere != null)
		{
			return randomWhere.Points.GetRandomTrianglePoint();
		}
		return null;
	}

	public bool IsNeutral(bool forMeeting = false)
	{
		if (BuildingOnFire || Burn > 0f)
		{
			return false;
		}
		if (GameSettings.Instance.RentMode && Rentable && !PlayerOwned)
		{
			return false;
		}
		if (Dummy)
		{
			return true;
		}
		RoomLimits forceRole = (RoomLimits)ForceRole;
		if (forceRole == RoomLimits.Reception)
		{
			return false;
		}
		if (!forMeeting && forceRole == RoomLimits.Meeting)
		{
			return false;
		}
		if (Teams.Count > 0 && forceRole != RoomLimits.Canteen && forceRole != RoomLimits.Lounge && (GetFurniture("Tray").Count == 0 || forceRole != RoomLimits.Anyone))
		{
			return false;
		}
		if (GetFurniture("Computer").Count > 0 || GetFurniture("Toilet").Count > 0)
		{
			return false;
		}
		return true;
	}

	public bool UpdateIsPrivate(bool force = false)
	{
		if (Outdoors || Outside)
		{
			IsPrivate = false;
			return false;
		}
		bool flag = false;
		if (AtriumParent.IsAliveNotNull() && AtriumParent != this)
		{
			if (!force)
			{
				GetMainAtriumParent().UpdateIsPrivate();
				return IsPrivate;
			}
			flag = true;
		}
		IsPrivate = true;
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			HashSet<WallSnap> hashSet = Utilities.GetOrNull(key: Edges[(i + 1) % Edges.Count], dict: wallEdge.Children);
			if (hashSet != null)
			{
				foreach (WallSnap item in hashSet)
				{
					if (item.IsAliveNotNull() && item.PunchHole() && !item.IsPrivate)
					{
						IsPrivate = false;
						break;
					}
				}
			}
			if (!IsPrivate)
			{
				break;
			}
		}
		if (!flag)
		{
			if (IsPrivate)
			{
				for (int j = 0; j < AtriumChildren.Count; j++)
				{
					if (AtriumChildren[j].IsAliveNotNull())
					{
						IsPrivate = AtriumChildren[j].UpdateIsPrivate(true);
						if (!IsPrivate)
						{
							IsPrivate = false;
							break;
						}
					}
				}
			}
			for (int k = 0; k < AtriumChildren.Count; k++)
			{
				Room room = AtriumChildren[k];
				if (!room.IsAliveNotNull())
				{
					continue;
				}
				room.IsPrivate = IsPrivate;
				for (int l = 0; l < room.AtriumChildren.Count; l++)
				{
					if (room.AtriumChildren[l].IsAliveNotNull())
					{
						room.AtriumChildren[l].IsPrivate = IsPrivate;
					}
				}
			}
		}
		return IsPrivate;
	}

	public int CountAllOccupants()
	{
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		int num = mainAtriumParentOrSelf.Occupants.Count;
		for (int i = 0; i < mainAtriumParentOrSelf.AtriumChildren.Count; i++)
		{
			Room room = mainAtriumParentOrSelf.AtriumChildren[i];
			num += room.Occupants.Count;
			for (int j = 0; j < room.AtriumChildren.Count; j++)
			{
				num += room.AtriumChildren[j].Occupants.Count;
			}
		}
		return num;
	}

	public bool AnyOccupantsAtrium(bool excludeSleeping = false)
	{
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		if (mainAtriumParentOrSelf.Occupants.Count > 0 && (!excludeSleeping || mainAtriumParentOrSelf.Occupants.Any((Actor x) => x.SpecialState != Actor.HomeState.Sleeping)))
		{
			return true;
		}
		for (int num = 0; num < mainAtriumParentOrSelf.AtriumChildren.Count; num++)
		{
			Room room = mainAtriumParentOrSelf.AtriumChildren[num];
			if (room.Occupants.Count > 0 && (!excludeSleeping || room.Occupants.Any((Actor x) => x.SpecialState != Actor.HomeState.Sleeping)))
			{
				return true;
			}
			for (int num2 = 0; num2 < room.AtriumChildren.Count; num2++)
			{
				if (room.AtriumChildren[num2].Occupants.Count > 0 && (!excludeSleeping || room.AtriumChildren[num2].Occupants.Any((Actor x) => x.SpecialState != Actor.HomeState.Sleeping)))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsPlayerControlled()
	{
		if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
		{
			return PlayerOwned;
		}
		return true;
	}

	public bool IsSupported(HashSet<Room> with = null)
	{
		return GameSettings.Instance.sRoomManager.IsSupported(Edges.Select((WallEdge x) => x.Pos), Floor, null, true, with);
	}

	public void UpdatePillars()
	{
		int num = Mathf.CeilToInt(RoomBounds.width);
		int num2 = Mathf.CeilToInt(RoomBounds.height);
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				bool flag = false;
				float x = RoomBounds.xMin + (float)i + 0.5f;
				float y = RoomBounds.yMin + (float)j + 0.5f;
				Vector2 vector = new Vector2(x, y);
				if (!IsInside(vector))
				{
					continue;
				}
				for (int k = 0; k < list.Count; k++)
				{
					if ((list[k] - vector).sqrMagnitude < 16f)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					for (int l = 0; l < Edges.Count; l++)
					{
						WallEdge wallEdge = Edges[l];
						if ((vector - wallEdge.Pos).sqrMagnitude < 16f)
						{
							flag = true;
							break;
						}
						WallEdge wallEdge2 = Edges[(l + 1) % Edges.Count];
						Vector2 res;
						if (Utilities.ProjectToLine(vector, wallEdge.Pos, wallEdge2.Pos, out res) && (vector - res).sqrMagnitude < 16f)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					UnityEngine.Object.Instantiate(BuildController.Instance.PillarPrefab).transform.position = vector.ToVector3((float)Floor * 2f);
					list.Add(vector);
				}
			}
		}
	}

	public override Vector2 GetFlatPos()
	{
		return Center;
	}

	public override bool IsSelectionRestricted()
	{
		return Dummy;
	}

	public float GetTemperatureArea(bool cooling)
	{
		return GetAtriumArea() * Insulation * TemperatureAreaScale((Floor < 0) ? 5f : (cooling ? TimeOfDay.Instance.CurrentWeather.MaximumTemperature : TimeOfDay.Instance.CurrentWeather.MinimumTemperature));
	}

	public bool IsProperlyTemperatureControlled(bool fromControl = false)
	{
		if (!GameSettings.Instance.RentMode)
		{
			float num = (fromControl ? _coolingControlArea : TheoCoolingControlArea);
			float num2 = GetAtriumArea() * Insulation;
			if (Floor >= 0 && TimeOfDay.Instance.CurrentWeather.MaximumTemperature > 21f && num2 * TemperatureAreaScale(TimeOfDay.Instance.CurrentWeather.MaximumTemperature) > num)
			{
				return false;
			}
			float num3 = (fromControl ? _heatingControlArea : TheoHeatingControlArea);
			if (TimeOfDay.Instance.CurrentWeather.MinimumTemperature < 21f && num2 * TemperatureAreaScale((Floor >= 0) ? TimeOfDay.Instance.CurrentWeather.MinimumTemperature : 5f) > num3)
			{
				return false;
			}
		}
		return true;
	}

	private void ConvertBounds(Vector3[] bounds, Vector2[] output, Matrix4x4 mat4)
	{
		for (int i = 0; i < bounds.Length; i++)
		{
			output[i] = mat4.MultiplyPoint(bounds[i]).FlattenVector3();
		}
	}

	public void InitializeTeamMask(Dictionary<Team, int> teamDict)
	{
		Mask = new MultiBitMask(teamDict.Count, true);
		PseudoMask = new MultiBitMask(teamDict.Count, true);
		if (GameSettings.Instance.RentMode && Rentable && !PlayerOwned)
		{
			TeamMask = new MultiBitMask(teamDict.Count, true);
		}
		else if (Teams.Count == 0)
		{
			TeamMask = new MultiBitMask(teamDict.Count, false);
		}
		else
		{
			TeamMask = new MultiBitMask(teamDict.Count, true);
			foreach (Team team in Teams)
			{
				TeamMask.SetBit(teamDict[team], true);
			}
		}
		lock (Teams)
		{
			ActuallyAllowed = null;
		}
	}

	public HashSet<Team> GetActuallyAllowed()
	{
		lock (Teams)
		{
			return ActuallyAllowed;
		}
	}

	public void SaveMask(Team[] teams)
	{
		lock (Teams)
		{
			ActuallyAllowed = new HashSet<Team>();
			int num = 0;
			foreach (bool item in Mask.Iterate())
			{
				if (num >= teams.Length)
				{
					break;
				}
				if (item)
				{
					ActuallyAllowed.Add(teams[num]);
				}
				num++;
			}
		}
		DirtyTeamNames = true;
		DirtyFurnitureRoomCheck = true;
	}

	public void DirtyLights()
	{
		if (!Options.MoreShadow)
		{
			return;
		}
		_furnitures.ThreadSafeForEach(delegate(Furniture f)
		{
			if (f.HasLamp)
			{
				f.Lamp.DirtyLights();
			}
		});
	}

	public void ClearAtriumPillarVariables()
	{
		NavMap = null;
		BSPNavMap = null;
		CachedPaths.Clear();
		ClearDirt();
		PathNodes.Clear();
		Teams.Clear();
		DirtyTeamNames = true;
		ClearMesh(Darkness);
		UnityEngine.Object.Destroy(Darkness);
		lock (HUD.Instance.InaccessibleRoom)
		{
			HUD.Instance.InaccessibleRoom.Remove(this);
		}
		GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
		GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
	}

	public void TogglePillar(bool undo)
	{
		if (Outdoors)
		{
			return;
		}
		List<UndoObject.UndoAction> undos = null;
		if (undo)
		{
			undos = new List<UndoObject.UndoAction>();
		}
		if (undo)
		{
			undos.Add(new UndoObject.UndoAction(this));
		}
		DirtyFloorMesh = true;
		DirtyInnerMesh = true;
		DirtyOuterMesh = true;
		DirtyNavMesh = true;
		DirtyPathNodes = true;
		ChangeRole(-1);
		if (Pillar)
		{
			Pillar = false;
			float num = BuildController.GetRoomCost(Edges, Area, false, true, Floor, false, false, IsUpperAtrium) - BuildController.GetRoomCost(Edges, Area, false, false, Floor, false, false, IsUpperAtrium);
			GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, true);
			GrassSystem.Instance.InvalidateArea();
			if (undo)
			{
				EmitDirt();
				UISoundFX.PlaySFX("PlaceRoom");
				GameSettings.Instance.AddUndo(undos.ToArray());
				UISoundFX.PlaySFX("Kaching");
				CostDisplay.Instance.Show(0f - num, Center.ToVector3((float)Floor * 2f + 2f));
				CostDisplay.Instance.FloatAway();
			}
			return;
		}
		Pillar = true;
		ClearAtriumPillarVariables();
		ClearMesh(InnerWalls);
		ClearMesh(FloorMesh);
		UnityEngine.Object.Destroy(InnerWalls);
		UnityEngine.Object.Destroy(FloorMesh);
		HashSet<WallSnap> destroyed = new HashSet<WallSnap>();
		for (int i = 0; i < Edges.Count; i++)
		{
			WallEdge wallEdge = Edges[i];
			HashSet<WallSnap> value;
			if (!wallEdge.Children.TryGetValue(Edges[(i + 1) % Edges.Count], out value))
			{
				continue;
			}
			foreach (WallSnap item in value)
			{
				if (item.IsOnSide(wallEdge) && destroyed.Add(item))
				{
					if (undo)
					{
						undos.Add(new UndoObject.UndoAction(item, false));
					}
					item.DestroyGO();
				}
			}
		}
		_furnitures.ThreadSafeForEach(delegate(Furniture furn)
		{
			if (destroyed.Add(furn))
			{
				if (undo)
				{
					undos.Add(new UndoObject.UndoAction(furn, false, furn.PreferInventory));
				}
				if (furn.PreferInventory)
				{
					furn.Undo = true;
					GameSettings.AddToInventory(furn);
				}
				furn.DestroyGO();
			}
		});
		GameSettings.Instance.MyCompany.MakeTransaction(BuildController.GetRoomCost(Edges, Area, false, false, Floor, false, false, IsUpperAtrium) - BuildController.GetRoomCost(Edges, Area, false, true, Floor, false, false, IsUpperAtrium), Company.TransactionCategory.Construction, true);
		if (undo)
		{
			GameSettings.Instance.AddUndo(undos.ToArray());
			EmitDirt();
			UISoundFX.PlaySFX("PlaceRoom");
		}
	}

	public override Selectable DeferSelection()
	{
		return this;
	}

	public override IStyle GetStyle()
	{
		return new RoomStyle("", this);
	}

	public float GetAtriumArea()
	{
		Room mainAtriumParentOrSelf = GetMainAtriumParentOrSelf();
		return mainAtriumParentOrSelf.Area * (float)(1 + mainAtriumParentOrSelf.AtriumChildren.Count);
	}

	public bool IsContentVisible()
	{
		if (Floor < 0 && GameSettings.Instance.ActiveFloor >= 0)
		{
			return false;
		}
		if (Floor >= 0 && GameSettings.Instance.ActiveFloor < 0)
		{
			return false;
		}
		int floor = Floor;
		int num = Floor;
		Room mainAtriumParent = GetMainAtriumParent();
		if (mainAtriumParent != null)
		{
			floor = Floor;
			num = mainAtriumParent.Floor + mainAtriumParent.AtriumChildren.Count;
		}
		if (GameSettings.Instance.ActiveFloor >= floor)
		{
			return GameSettings.Instance.ActiveFloor <= num;
		}
		return false;
	}

	public void PlaceColumns(List<UndoObject.UndoAction> undos)
	{
		ValueTuple<Vector2, float>? furthestPointFromEdges = GetFurthestPointFromEdges();
		Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent("Round Column");
		Vector3[] array = furnitureComponent.BuildBoundary.SelectInPlace((Vector2 x) => x.ToVector3(0f));
		Vector2[] array2 = new Vector2[array.Length];
		while (furthestPointFromEdges.HasValue && furthestPointFromEdges.Value.Item2 > 4f)
		{
			Vector3 pos = furthestPointFromEdges.Value.Item1.ToVector3((float)Floor * 2f);
			Matrix4x4 mat = Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one);
			ConvertBounds(array, array2, mat);
			if (FurnitureBuilder.IsValid(furnitureComponent, pos, array2, furnitureComponent.Height1, furnitureComponent.Height2, this, false))
			{
				bool inventory;
				Furniture furniture = FurnitureBuilder.MakeFurn(pos, Quaternion.identity, this, null, null, 0f, false, null, furnitureComponent.gameObject, 0f, false, out inventory);
				AddFurniture(furniture);
				furniture.UpdateBoundaryPoints();
				furniture.InitLOD();
				undos.Add(new UndoObject.UndoAction(furniture, true, inventory));
				furthestPointFromEdges = GetFurthestPointFromEdges();
				continue;
			}
			break;
		}
	}

	public ValueTuple<Vector2, float>? GetFurthestPointFromEdges()
	{
		float num = float.MinValue;
		Vector2? vector = null;
		Rect r = RoomBounds;
		int num2 = Mathf.CeilToInt(r.width);
		int num3 = Mathf.CeilToInt(r.height);
		for (int i = 0; i < 2; i++)
		{
			ValueTuple<Vector2, float>? valueTuple = ExamineRect(r, num2, num3);
			if (!valueTuple.HasValue || !(valueTuple.Value.Item2 > num))
			{
				break;
			}
			num = valueTuple.Value.Item2;
			vector = valueTuple.Value.Item1;
			num2 = 2;
			num3 = 2;
			float num4 = r.width / (float)num2;
			float num5 = r.height / (float)num3;
			r = new Rect(vector.Value.x - num4 / 2f, vector.Value.x - num5 / 2f, num4, num5);
		}
		if (vector.HasValue)
		{
			return new ValueTuple<Vector2, float>(vector.Value, num);
		}
		return null;
	}

	public float IntegrityFromPoint(Vector2 p, Furniture ignore, Vector2? extra)
	{
		return GetPointDistanceFromEdge(p, ignore, extra).MapRange(4f, 4.2f, 1f, 0f, true);
	}

	private ValueTuple<Vector2, float>? ExamineRect(Rect r, int subW, int subH)
	{
		float num = float.MinValue;
		Vector2? vector = null;
		float num2 = r.width / (float)subW;
		float num3 = r.height / (float)subH;
		for (int i = 0; i < subW; i++)
		{
			for (int j = 0; j < subH; j++)
			{
				Vector2 vector2 = new Vector2(r.xMin + ((float)i + 0.5f) * num2, r.yMin + ((float)j + 0.5f) * num3);
				if (IsInside(vector2, true))
				{
					float pointDistanceFromEdge = GetPointDistanceFromEdge(vector2);
					if (pointDistanceFromEdge > num)
					{
						num = pointDistanceFromEdge;
						vector = vector2;
					}
				}
			}
		}
		if (vector.HasValue)
		{
			return new ValueTuple<Vector2, float>(vector.Value, num);
		}
		return null;
	}

	private float GetPointDistanceFromEdge(Vector2 p, Furniture ignore = null, Vector2? extra = null)
	{
		float num = float.MaxValue;
		for (int i = 0; i < Edges.Count; i++)
		{
			Vector2 pos = Edges[i].Pos;
			Vector2 pos2 = Edges[(i + 1) % Edges.Count].Pos;
			float magnitude = (Utilities.ProjectToLineEndlessClamped(p, pos, pos2) - p).magnitude;
			if (magnitude < num)
			{
				num = magnitude;
			}
		}
		HashList<Furniture> furniture = GetFurniture("Column");
		for (int j = 0; j < furniture.Count; j++)
		{
			Furniture furniture2 = furniture[j];
			if (furniture2 != ignore)
			{
				float magnitude2 = (p - furniture2.OriginalPosition.FlattenVector3()).magnitude;
				if (magnitude2 < num)
				{
					num = magnitude2;
				}
			}
		}
		if (extra.HasValue)
		{
			float magnitude3 = (p - extra.Value).magnitude;
			if (magnitude3 < num)
			{
				num = magnitude3;
			}
		}
		return num;
	}

	public Room FindFloorAtrium(Vector2 p)
	{
		if (AtriumParent == null || AtriumParent == this || IsBalcony)
		{
			return this;
		}
		for (int i = 0; i < AtriumChildren.Count; i++)
		{
			Room room = AtriumChildren[i];
			if (room.IsInside(p))
			{
				return room;
			}
		}
		int num = AtriumParent.AtriumChildren.IndexOf(this);
		if (num == 0)
		{
			return AtriumParent;
		}
		return AtriumParent.AtriumChildren[num - 1].FindFloorAtrium(p);
	}

	public IRoom FindCeilingAtrium(Vector2 p)
	{
		if (AtriumParent == null)
		{
			return this;
		}
		if (AtriumParent == this)
		{
			if (AtriumChildren.Count <= 0)
			{
				return this;
			}
			return AtriumChildren[0].FindCeilingAtrium(p);
		}
		if (IsBalcony)
		{
			int num = AtriumParent.AtriumParent.AtriumChildren.IndexOf(AtriumParent);
			if (num == AtriumParent.AtriumParent.AtriumChildren.Count - 1)
			{
				return this;
			}
			IRoom room = AtriumParent.AtriumParent.AtriumChildren[num + 1].FindCeilingAtrium(p);
			if (room != AtriumParent)
			{
				return room;
			}
			return this;
		}
		int num2 = AtriumParent.AtriumChildren.IndexOf(this);
		for (int i = 0; i < AtriumChildren.Count; i++)
		{
			if (AtriumChildren[i].IsInside(p))
			{
				if (num2 == 0)
				{
					return AtriumParent;
				}
				return AtriumParent.AtriumChildren[num2 - 1];
			}
		}
		if (num2 == AtriumParent.AtriumChildren.Count - 1)
		{
			return this;
		}
		return AtriumParent.AtriumChildren[num2 + 1].FindCeilingAtrium(p);
	}

	public void SpreadDirt()
	{
		for (float num = 0.5f; num < RoomBounds.width - 0.5f; num += 0.5f)
		{
			for (float num2 = 0.5f; num2 < RoomBounds.height - 0.5f; num2 += 0.5f)
			{
				AddDirt(new Vector2(RoomBounds.xMin + num, RoomBounds.yMin + num2), 1f);
			}
		}
	}

	public void UpdateAtriumFurniture(List<UndoObject.UndoAction> undos = null)
	{
		Room mainAtriumParent = GetMainAtriumParent();
		if (mainAtriumParent != null)
		{
			mainAtriumParent.UpdateParentOfFurniture(undos);
			mainAtriumParent.GetAtriumChildren().ForEachEnum(delegate(Room x)
			{
				x.UpdateParentOfFurniture(undos);
			});
		}
	}

	public int GetAtriumSubOrder()
	{
		if (AtriumParent == null || AtriumParent == this)
		{
			return 0;
		}
		if (AtriumParent.AtriumParent != AtriumParent)
		{
			return 2;
		}
		return 1;
	}

	public void UpdateAtriumNetwork()
	{
		if (base.NetworkID != 0)
		{
			NetworkMessaging.SendUpdateRoomAtrium(base.NetworkID, AtriumChildren.Count + 1, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public override void UpdateStyleNetwork()
	{
		if (base.NetworkID != 0)
		{
			if (Outdoors)
			{
				NetworkMessaging.SendObjectStyle(base.NetworkID, true, FloorMat, FenceStyle, FenceColor, FloorColor, FloorColor2, Color.black, 0, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			else
			{
				NetworkMessaging.SendObjectStyle(base.NetworkID, true, OutsideMat, null, OutsideColor, OutsideColor2, Color.black, Color.black, 0, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
	}

	public void QueueEdgeNetworkUpdate()
	{
		if (base.NetworkID != 0)
		{
			GameSettings.Instance.QueuedNetworkEdges.Add(this);
		}
	}

	public bool IgnoreConnected()
	{
		if (Area > 4.001f)
		{
			return false;
		}
		return GetFurniture("Elevator").Count > 0;
	}

	public void UpdateEdgesNetwork()
	{
		if (base.NetworkID != 0)
		{
			Vector2[] array = Edges.SelectInPlace((WallEdge x) => x.Pos);
			bool[] array2 = new bool[array.Length];
			for (int num = 0; num < Edges.Count; num++)
			{
				array2[num] = Edges[num].Smooth.Contains(Edges[(num + 1) % Edges.Count]);
			}
			NetworkMessaging.SendRoomEdges(base.NetworkID, array, array2, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public override bool IsNetworkIDLocal()
	{
		return true;
	}

	public override bool IsNetworkIDLocal(WriteDictionary d)
	{
		return true;
	}

	[CompilerGenerated]
	private static void _003CMatchesRank_003Eg__Check_007C288_0(float other, int otherIndex, ref _003C_003Ec__DisplayClass288_0 P_2)
	{
		if ((float)otherIndex != P_2.statIndex && (other > P_2.value || (other == P_2.value && (float)otherIndex < P_2.statIndex)))
		{
			P_2.rank++;
		}
	}
}
