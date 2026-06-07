using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Furniture : WallSnap, IRoomConnector, IDistributee, IFormatColorObject
{
	[Serializable]
	public class IsOnEvent : UnityEvent<bool>
	{
	}

	public enum UseEffect
	{
		Lead = 0,
		Programmer = 1,
		Designer = 2,
		Artist = 3,
		Service = 4,
		NoiseCancelling = 5,
		SocialIsolation = 6
	}

	public enum TemperatureType
	{
		None = 0,
		Heating = 1,
		Cooling = 2
	}

	public enum AuraTypes
	{
		Effectiveness = 0,
		Skill = 1,
		Mood = 2
	}

	public enum UseType
	{
		Water = 0,
		Watt = 1,
		Gas = 2
	}

	public const float WaterPrice = 0.05f;

	public const float ElectricityPrice = 0.6f;

	public const float GasPrice = 1f;

	public const int UseEffectCount = 7;

	private static float[] _useEffectCache = new float[7];

	private static bool _useEffectCleared = true;

	public bool PunchHoleThroughWall;

	[Header("Placement and pathfinding")]
	public Vector2[] BuildBoundary;

	public Vector2[] NavBoundary;

	[NonSerialized]
	public Vector2[] FinalNav;

	public Vector2[] FinalBoundary;

	public bool OnXEdge;

	public bool OnYEdge;

	public bool GenerateBoundaryOnStart;

	public bool CanRotate = true;

	public bool Only180Rotation;

	public bool IsDraggable;

	public float DragDistance = 1f;

	public float Height1;

	public float Height2;

	public bool IgnoreBoundary;

	public bool BasementValid = true;

	public bool OnlyExteriorWalls;

	public bool OnlyInteriorWalls;

	public bool WallFurn;

	public bool InFloor;

	public bool BlocksFloor;

	public bool ValidIndoors = true;

	public bool ValidOutdoors = true;

	public bool ValidOutside;

	public bool ValidOnFence = true;

	public bool ValidAgainstOutdoorArea = true;

	public bool OnlyOnGrass;

	public bool PokesThroughWall;

	public bool PokesThroughRoof;

	public bool NeedsRoadConnection;

	public bool ShowBuildBoundaryOutline;

	public bool AtriumValid = true;

	public bool AtriumFixture;

	public bool PrefabRotationImportant = true;

	public bool ValidInBlueprints = true;

	public bool ValidInInventory = true;

	public float MirrorRotationOffset;

	public string IgnoreType;

	public string[] AutoPlaceGroup;

	public bool DefaultInteractionDistance;

	[Header("Snapping")]
	public SnapPoint[] SnapPoints;

	public SnapPoint SnappedTo;

	public bool IsSnapping;

	public float SurfaceSnapRadius = -1f;

	public bool CanNotSnap;

	public string[] SnapsTo = new string[0];

	private HashSet<string> _actualSnap;

	[Header("Ingame Options")]
	public bool CanAssign = true;

	public bool ReverseLowPass;

	public bool NeedsChair;

	public bool ManualUsageCalculation;

	public bool CanSteal;

	public bool InteractAnimation;

	public bool InteractOnAnimation;

	public string RunningAnimation = "";

	public int MaxQueue;

	public AudioClip InteractStartClip;

	public AudioClip InteractEndClip;

	public string UpgradeTo;

	public bool InDemo = true;

	public bool ITFix;

	public int UnlockYear;

	public string UnlockMission;

	public bool TemperatureController;

	public bool TemperatureOutput;

	public bool TemperatureModifyUsage = true;

	public TemperatureType TempControlType;

	public Transform TempAccessPoint;

	public bool AlwaysOn;

	public bool DefaultOn;

	public bool OnWithParent;

	public bool OnWhenUsed;

	public Renderer TheScreen;

	public MeshFilter InteractChangeMesh;

	public Material OnMat;

	public Material OffMat;

	public FurnitureInteractScript[] InteractionScripts;

	public GameObject[] DisableObjs;

	public Transform ComputerTransform;

	public Vector3 OriginalOffset;

	public Vector3 PCAddonOffset;

	public Vector3 OriginalRotation;

	public Vector3 PCAddonRotation;

	public bool CanLean = true;

	public bool TwoFloors;

	public bool MakeHole = true;

	public Transform CustomHoleTransform;

	public Mesh CustomHoleMesh;

	public Mesh DefaultMesh;

	public Mesh InteractMesh;

	public Transform[] OffsetPoints;

	[NonSerialized]
	private Vector3[] _offsetPointCached;

	[NonSerialized]
	private Matrix4x4 _elevatorMatrix;

	public Transform[] InterPoints;

	public Transform[] InterPointsReversed;

	public GameObject UpperFloorFrame;

	public GameObject OnRoofObject;

	public Transform[] HoldablePoints;

	[NonSerialized]
	private List<Holdable> Holdables = new List<Holdable>();

	public bool DespawnHoldables;

	public float DespawnHour = 24f;

	public bool RandomSFX;

	public string KeepAudioSynced = "";

	public AudioClip[] SFXFiles;

	public float RandomSFXMin;

	public float RandomSFXMax;

	private float _randomSFXTimer;

	public bool DisableTableGrouping;

	public bool InRentMode = true;

	public Transform[] LookAtPoints;

	public GameObject ActiveWithOn;

	public Vector4 HighlightAlphaUV = new Vector4(0f, 0f, 1f, 1f);

	public bool OnHead;

	public bool Deprecated;

	public MeshRenderer[] ElevatorDisplay;

	public DoorScript[] ElevatorDoors;

	public Rect ElevatorEntrance;

	public Rect ElevatorArea;

	public bool WallFurnHide = true;

	public int AvailableMonth = -1;

	public bool ForcePCPricing;

	public bool CanBoost;

	public float MinBoostValue = 1f;

	public float MaxBoostValue = 3f;

	public float BoostIncrement = 1f;

	public float BoostUseModifier = 1f;

	public Transform AtriumObject;

	public bool ReverseAtriumScale;

	public bool VisibleAtAnyAngles;

	public IsOnEvent IsOnStateChanged;

	public string MetalMarket = "";

	public int MetalLevel;

	public bool Offshore;

	public bool AllowNoExtraParent;

	public bool CanCopy = true;

	public bool ShouldNetwork;

	public bool PreferInventory;

	public bool BlueprintUpgradeTo;

	public bool BlueprintUpgradeFrom;

	public bool BlueprintReplaceable = true;

	public bool LightAlwaysOn;

	[Header("Ingame attributes")]
	public int SelectionSubType;

	public string LocalizeOverride;

	[NonSerialized]
	public string NameOverride;

	public string[] Category;

	public string FunctionCategory;

	public float Cost = 5f;

	public string Unlockable;

	public float ComputerPowerModifier = 1f;

	public bool IgnorePCRelease;

	public float HeatCoolArea;

	public bool EqualizeTemperature = true;

	[FormerlySerializedAs("RoleBuffs")]
	public float[] UseEffects;

	public float Lighting;

	public float Wait;

	[FormerlySerializedAs("Coffee")]
	public float MiscPotential;

	public int Capacity;

	public bool RefillCapacity = true;

	public int Expiration;

	public float UnitCost;

	public float[] AuraValues;

	public float AuraCoverage = 40f;

	public bool CapAura;

	public float Wattage;

	public float Water;

	public float Gas;

	public float Noisiness;

	public float ExpectedOn = 24f;

	public float Comfort;

	public float Environment = 1f;

	public float AcousticDampening = 1f;

	public float AirCleaning;

	public CompanySignage Signage;

	[NonSerialized]
	[Header("Do not touch")]
	private bool _hasAtriumObject;

	public bool TurnOnOccupants;

	public bool PlacedInEditMode;

	public bool PartOfGen;

	[NonSerialized]
	public PlayerMap Map;

	[NonSerialized]
	public bool StartInteraction;

	[NonSerialized]
	public float OnFire;

	public float _boostValue = 1f;

	[NonSerialized]
	public double SpecialPrice;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool FireProtection;

	public bool CanInsure = true;

	private Animation _anim;

	[NonSerialized]
	public int HasHoldables;

	[NonSerialized]
	private List<FurnitureStock> _unitStock;

	public Vector2[] MeshBoundary;

	public float WallCullingDistance;

	public float RotationOffset;

	public Vector3 OriginalPosition;

	[NonSerialized]
	private uint[][] SerializedQueue;

	private bool _isOn;

	private bool _hasClip;

	public AudioSource AudioSrc;

	[NonSerialized]
	private bool HasAudioSource;

	public bool isTemporary;

	public Upgradable upg;

	[NonSerialized]
	public bool HasUpg;

	private float AtEdge;

	public int PathFailCount;

	public InteractionPoint[] InteractionPoints;

	private Room _parent;

	public Room InteractionParent;

	[NonSerialized]
	public Vector3 SnapPointOffset;

	[NonSerialized]
	public NetworkRoom NetworkParent;

	public int Floor;

	private Actor _reserved;

	public float EnvironmentNoise;

	public float ActorNoise;

	public float FinalNoise;

	public bool CanTraverse = true;

	[SaveField]
	public bool CanExitElevator = true;

	[SaveField]
	public bool CanEnterElevator = true;

	public Furniture ComputerChair;

	public bool Undo;

	private bool _playingOneShot;

	[NonSerialized]
	public bool NonPlayerDestruction;

	[NonSerialized]
	public TemperatureGroup TempGroup;

	[NonSerialized]
	public Furniture TempPointTo;

	[NonSerialized]
	public bool ForceTempUpdate;

	[NonSerialized]
	public bool Insured = true;

	[NonSerialized]
	public CCTVGroup CCGroup;

	public ProductPallet Pallet;

	public ProductPrinter Printer;

	public Conveyor Conveyor;

	public bool HasConveyor;

	[NonSerialized]
	private float[] _useEffects;

	[NonSerialized]
	public Actor OnHeadOf;

	[NonSerialized]
	public ElevatorGroup EGroup;

	[NonSerialized]
	public LampScript Lamp;

	[NonSerialized]
	public bool HasLamp;

	[HideInInspector]
	public bool CanFallback;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public float Waste;

	[NonSerialized]
	public SDateTime? TurnOffTimer;

	private float MaxAudioDistance;

	[NonSerialized]
	public Room ExtraParent;

	public int StartDowngrade = int.MaxValue;

	public TableScript Table;

	private bool _forceEmission;

	private float _useModifier = 1f;

	private double _currentWattage;

	private double _currentWater;

	private double _currentGas;

	public const int AuraCount = 3;

	private Actor _ownedBy;

	private Renderer[] Children;

	[NonSerialized]
	public string[] actions = new string[2] { "Sell", "Types in Room" };

	private PathNode<Vector3> _pathNode;

	private int _atriumOffset;

	[NonSerialized]
	private bool _initialized;

	[NonSerialized]
	private int _lastLOD = -1;

	public const float LOD2Dist = 1600f;

	public const float LOD1Dist = 625f;

	private static Dictionary<string, Furniture> _timeMasters = new Dictionary<string, Furniture>();

	private bool _syncAudio;

	[NonSerialized]
	public bool LoadError;

	private static List<IFurnitureSerialization> _subSerializeList = new List<IFurnitureSerialization>();

	[NonSerialized]
	private Rect? _boundCache;

	private static readonly FloatInterpolator ComfortDegration = new FloatInterpolator(1f, 0.9999f, 0.9984f, 0.9919f, 0.9744f, 0.9375f, 0.8704f, 0.7599f, 0.5904f, 0.3439f, 0.18549375f);

	[NonSerialized]
	private Vector2 _boundsOffset = Vector2.zero;

	public bool EmissionOnWithFurniture = true;

	public bool EmissionWarmUp;

	public bool ChangeColorOffSecondary;

	public bool ChangeColorOffTertiary;

	public List<LODFurn> LODGroups;

	public Renderer TreeLeaves;

	private static readonly List<Vector2> cSegments = new List<Vector2>();

	private static HashSet<Room> NoiseVisit = new HashSet<Room>();

	private static List<float> NoiseValues = new List<float>();

	private static int NoiseValueCount = 0;

	public static float NoiseValueMax = 0f;

	private static float WallIsolation = 0.3f;

	private static HashSet<Actor> _noiseIgnoreCache = new HashSet<Actor>();

	public const float NeighbourDistance = 3.5f;

	public const float NeighbourDistanceSquared = 12.25f;

	[NonSerialized]
	private TrashCan _connectedCan;

	public const float TrashCanDistanceSqr = 12.25f;

	public bool CanSnapSurface
	{
		get
		{
			return SurfaceSnapRadius > 0f;
		}
	}

	public float BoostValue
	{
		get
		{
			return _boostValue;
		}
		set
		{
			_boostValue = (CanBoost ? Mathf.Clamp(value, MinBoostValue, MaxBoostValue) : 1f);
			UseModifier = _boostValue.MapRange(1f, MaxBoostValue, _boostValue, _boostValue * BoostUseModifier);
			if (Conveyor != null)
			{
				Conveyor.UpdateBeltRends();
			}
		}
	}

	public Room Parent
	{
		get
		{
			return _parent;
		}
		set
		{
			_parent = value;
			InteractionParent = ((_parent == null) ? null : _parent.FindFloorAtrium(OriginalPosition.FlattenVector3()));
		}
	}

	public bool Insurable
	{
		get
		{
			if (CanInsure)
			{
				if (!CanBurn())
				{
					return CheckCanSteal();
				}
				return true;
			}
			return false;
		}
	}

	public Actor Reserved
	{
		get
		{
			return _reserved;
		}
		set
		{
			if (value != _reserved)
			{
				Actor reserved = _reserved;
				if ((object)reserved != null)
				{
					reserved.ReservedFurniture.Remove(this);
				}
				_reserved = value;
				Actor reserved2 = _reserved;
				if ((object)reserved2 != null)
				{
					reserved2.ReservedFurniture.Add(this);
				}
			}
		}
	}

	public float ComputerPower
	{
		get
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				return GameSettings.Instance.GetComputerPower(StartDowngrade, ComputerPowerModifier);
			}
			return ComputerPowerModifier;
		}
	}

	public float ActualHeight
	{
		get
		{
			return Height2 - Height1;
		}
	}

	public bool ForceEmission
	{
		get
		{
			return _forceEmission;
		}
		set
		{
			if (_forceEmission != value)
			{
				_forceEmission = value;
				InitializeMatBlock();
				if (_forceEmission)
				{
					_matBlock.SetFloat("_EmissionFact", 1f);
				}
				else if (EmissionOnWithFurniture && !IsOn)
				{
					_matBlock.SetFloat("_EmissionFact", 0f);
				}
				UpdateMaterials();
			}
		}
	}

	public float UseModifier
	{
		get
		{
			return _useModifier;
		}
		set
		{
			_useModifier = value;
			RefreshUsage();
		}
	}

	public float CurrentWattage
	{
		get
		{
			return (float)_currentWattage;
		}
	}

	public bool IsOn
	{
		get
		{
			return _isOn;
		}
		set
		{
			if (isTemporary || Map != null)
			{
				return;
			}
			AudioVisualizer.NoiseDirty = true;
			if (HasUpg && upg.Broken)
			{
				value = false;
			}
			if ((!(!AlwaysOn || value) && (!HasUpg || !upg.Broken)) || _isOn == value)
			{
				return;
			}
			_isOn = value;
			if (!_isOn)
			{
				TurnOffTimer = null;
			}
			RefreshUsage();
			if (ActiveWithOn != null)
			{
				ActiveWithOn.SetActive(_isOn);
			}
			if (InteractOnAnimation)
			{
				_anim.Play(_isOn ? "InteractStart" : "InteractEnd");
			}
			if (TempControlType != TemperatureType.None)
			{
				if (TurnOnOccupants)
				{
					Parent.UpdateTemperatureValues();
				}
				else
				{
					Parent.MakeTemperatureDirty(false);
				}
			}
			for (int i = 0; i < SnapPoints.Length; i++)
			{
				SnapPoints[i].ForEachUsed(delegate(Furniture x)
				{
					x.ParentPowerToggled();
				});
			}
			if (Noisiness > 0f)
			{
				Parent.RefreshNoise();
			}
			PowerToggled(_isOn);
			if (Colorable.Count > 0)
			{
				InitializeMatBlock();
				if (!EmissionWarmUp)
				{
					_matBlock.SetFloat("_EmissionFact", (ForceEmission || !EmissionOnWithFurniture || IsOn) ? 1 : 0);
				}
				UpdateMaterials();
			}
			IsOnStateChanged.Invoke(IsOn);
		}
	}

	public Actor OwnedBy
	{
		get
		{
			return _ownedBy;
		}
		set
		{
			if (_ownedBy != null)
			{
				_ownedBy.Owns.Remove(this);
			}
			_ownedBy = ((PartOfGen || (PlacedInEditMode && !GameSettings.Instance.CampaignMode)) ? null : value);
			if (_ownedBy != null)
			{
				_ownedBy.Owns.Add(this);
				if (Reserved != null && Reserved.AItype != AI.AIType.Burglar && OwnedBy != Reserved)
				{
					Reserved = null;
				}
				for (int i = 0; i < InteractionPoints.Length; i++)
				{
					InteractionPoint interactionPoint = InteractionPoints[i];
					if (interactionPoint.UsedBy != null && interactionPoint.UsedBy != _ownedBy)
					{
						interactionPoint.UsedBy.ResetState();
					}
				}
				if (OwnedBy.isActiveAndEnabled && OwnedBy.UsingPoint != null && OwnedBy.UsingPoint.Parent != this && OwnedBy.UsingPoint.Parent.Type.Equals(Type) && OwnedBy.UsingPoint.Parent.OwnedBy != OwnedBy && !OwnedBy.AIScript.HasFlag(AI.NodeFlag.InMeeting))
				{
					if (OwnedBy.UsingPoint.Parent.Reserved == OwnedBy)
					{
						OwnedBy.UsingPoint.Parent.Reserved = null;
					}
					OwnedBy.UsingPoint = null;
					OwnedBy.AIScript.currentNode = OwnedBy.AIScript.BehaviorNodes["Loiter"];
				}
			}
			if (Type.Equals("Chair"))
			{
				Furniture computer = GetComputer();
				if (computer != null && computer.OwnedBy != OwnedBy)
				{
					computer.OwnedBy = _ownedBy;
				}
			}
			else if (Type.Equals("Computer") && ComputerChair != null && ComputerChair.OwnedBy != OwnedBy)
			{
				ComputerChair.OwnedBy = _ownedBy;
			}
			CheckAllowedInRoom();
		}
	}

	public bool IsConnecter
	{
		get
		{
			if (Map == null)
			{
				if (!"Elevator".Equals(Type) && !"Stairs".Equals(Type))
				{
					return "Portal".Equals(Type);
				}
				return true;
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

	public bool IsActivelySnapping
	{
		get
		{
			if (IsSnapping)
			{
				if (CanNotSnap)
				{
					return SnappedTo != null;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsCCTVFurn
	{
		get
		{
			if (!"CCTV".Equals(Type))
			{
				return "SurveillanceDesk".Equals(Type);
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

	public bool IsValid
	{
		get
		{
			if (this != null)
			{
				return base.gameObject != null;
			}
			return false;
		}
	}

	public bool IsBlocked { get; set; }

	public bool MovesBetweenFloors
	{
		get
		{
			if (!TwoFloors)
			{
				return "Elevator".Equals(Type);
			}
			return true;
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

	public bool IsRefreshing
	{
		get
		{
			if (Parent != null)
			{
				return Parent.NavmeshRebuildStarted;
			}
			return false;
		}
	}

	public static float GetWaterPrice()
	{
		return 0.05f * GameSettings.Instance.Environment.UtilitiesCostFactor;
	}

	public static float GetGasPrice()
	{
		return 1f * GameSettings.Instance.Environment.UtilitiesCostFactor;
	}

	public static float GetElectricityPrice()
	{
		return 0.6f * GameSettings.Instance.Environment.UtilitiesCostFactor;
	}

	public static void UpdateEdgeDetection()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.UpdateEdgeDetection();
		}
	}

	public void RefreshUsage(bool destroyed = false)
	{
		if (_currentWattage > 0.0)
		{
			GameSettings.Instance.ElectricityDelta -= _currentWattage;
		}
		else if (_currentWattage < 0.0)
		{
			GameSettings.Instance.ElectricityGenerationDelta -= 0.0 - _currentWattage;
		}
		if (_currentWater > 0.0)
		{
			GameSettings.Instance.WaterDelta -= _currentWater;
		}
		if (_currentGas > 0.0)
		{
			GameSettings.Instance.GasDelta -= _currentGas;
		}
		if (destroyed)
		{
			_currentWater = 0.0;
			_currentWattage = 0.0;
			_currentGas = 0.0;
			return;
		}
		bool flag = !ManualUsageCalculation && IsOn && IsPlayerOwned();
		_currentWater = (flag ? (Water * UseModifier) : 0f);
		_currentWattage = (flag ? (Wattage * UseModifier) : 0f);
		_currentGas = (flag ? (Gas * UseModifier) : 0f);
		if (_currentWattage > 0.0)
		{
			GameSettings.Instance.ElectricityDelta += _currentWattage;
		}
		else if (_currentWattage < 0.0)
		{
			GameSettings.Instance.ElectricityGenerationDelta += 0.0 - _currentWattage;
		}
		if (_currentWater > 0.0)
		{
			GameSettings.Instance.WaterDelta += _currentWater;
		}
		if (_currentGas > 0.0)
		{
			GameSettings.Instance.GasDelta += _currentGas;
		}
	}

	public void PowerToggled(bool ison)
	{
		if (DisableObjs != null && DisableObjs.Length != 0)
		{
			for (int i = 0; i < DisableObjs.Length; i++)
			{
				DisableObjs[i].SetActive(ison);
			}
		}
		if (TheScreen != null)
		{
			if (OnMat == null)
			{
				TheScreen.material.color = (ison ? Color.blue : Color.white);
			}
			else
			{
				TheScreen.sharedMaterial = (ison ? OnMat : OffMat);
			}
		}
		if (HasConveyor)
		{
			Conveyor.UpdateBeltRends();
		}
		if (ChangeColorOffSecondary || ChangeColorOffTertiary)
		{
			TurnOffColor(ChangeColorOffSecondary && !ison, ChangeColorOffTertiary && !ison);
		}
	}

	public bool DoesSnapTo(string furn)
	{
		if (SnapsTo != null && SnapsTo.Length != 0)
		{
			if (SnapsTo.Length == 1)
			{
				return SnapsTo[0].Equals(furn);
			}
			if (_actualSnap == null)
			{
				_actualSnap = SnapsTo.ToHashSet();
			}
			return _actualSnap.Contains(furn);
		}
		return false;
	}

	public void CheckUserCanUseInRoom()
	{
		if (Reserved != null && Reserved.AItype != AI.AIType.Burglar && !Parent.AllowedInRoom(Reserved))
		{
			Reserved = null;
		}
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.UsedBy != null && !Parent.AllowedInRoom(interactionPoint.UsedBy))
			{
				interactionPoint.UsedBy.ResetState();
			}
		}
	}

	public void SetOwnedByDeserializing(Actor act)
	{
		if (_ownedBy == null && !PartOfGen && (!PlacedInEditMode || GameSettings.Instance.CampaignMode))
		{
			_ownedBy = act;
		}
	}

	public override string[] GetActions()
	{
		return actions;
	}

	public override string[] GetExtendedIconInfo()
	{
		if (!Type.Equals("Server"))
		{
			return new string[1] { "Furniture" };
		}
		return new string[5] { "Server", "Chart", "Lightning", "Wires", "MoreSoftware" };
	}

	public override Color[] GetExtendedColorInfo()
	{
		if (Type.Equals("Server"))
		{
			Server component = GetComponent<Server>();
			return new Color[4]
			{
				GetColorStat((component != null) ? (component.GetGroupAvailable() * 2f) : 1f),
				GetColorStat(1f),
				GetColorStat(1f),
				GetColorStat(1f)
			};
		}
		return null;
	}

	public void TurnMonth()
	{
		_currentWattage = 0.0;
		_currentWater = 0.0;
		_currentGas = 0.0;
		RefreshUsage();
	}

	public float? GetUse(UseType type)
	{
		float num = 0f;
		switch (type)
		{
		case UseType.Water:
			num = Water;
			break;
		case UseType.Watt:
			num = Wattage;
			break;
		case UseType.Gas:
			num = Gas;
			break;
		}
		if (num <= 0f)
		{
			return null;
		}
		if (!IsOn)
		{
			return 0f;
		}
		float num2 = UseModifier;
		if (Printer != null)
		{
			num2 = ((Printer.OwedWatt > 0f) ? 1f : 0f);
		}
		return num * num2;
	}

	public void ParentPowerToggled()
	{
		if (OnWithParent && SnappedTo != null)
		{
			IsOn = SnappedTo.Parent.IsOn;
		}
	}

	public override string[] GetExtendedInfo()
	{
		if (Type.Equals("Server"))
		{
			Server component = GetComponent<Server>();
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(component.ServerName);
			if (serverGroup != null)
			{
				return new string[5]
				{
					serverGroup.Name,
					((1f - serverGroup.Available) * 100f).ToString("0") + "%",
					serverGroup.PowerSum.Bandwidth(),
					serverGroup.Servers.Count.ToString(),
					serverGroup.Items.Count.ToString()
				};
			}
		}
		if (string.IsNullOrEmpty(NameOverride))
		{
			string[] furniture = Localization.GetFurniture(GetLocalizationName(), GetDefaultName(), null);
			return new string[1] { furniture[0] };
		}
		return new string[1] { NameOverride };
	}

	public override string[] GetExtendedTooltipInfo()
	{
		if (Type.Equals("Server"))
		{
			return new string[4]
			{
				"ServerLoad".Loc(),
				"Bandwidth".Loc(),
				"Servercount".Loc(),
				"Processes".Loc()
			};
		}
		return null;
	}

	public override string GetLocalizationName()
	{
		if (!string.IsNullOrEmpty(LocalizeOverride))
		{
			return LocalizeOverride;
		}
		return base.name;
	}

	public string GetDefaultName()
	{
		if (!string.IsNullOrEmpty(LocalizedName))
		{
			return LocalizedName;
		}
		return GetLocalizationName();
	}

	public bool IsConstructionFurniture()
	{
		if (Category != null && Category.Length != 0)
		{
			return "Construction".Equals(Category[0]);
		}
		return false;
	}

	public bool CanBurn()
	{
		if (!FireProtection && !IsConstructionFurniture() && IsActuallyPlayerControlled() && !"Sprinkler".Equals(Type) && !"DogBed".Equals(Type))
		{
			return string.IsNullOrEmpty(MetalMarket);
		}
		return false;
	}

	public void InsurancePayout()
	{
		InsuranceAccount insurance = GameSettings.Instance.Insurance;
		if (Insured && Insurable && GameSettings.Instance.PassedFireInspection && insurance.ActualContentInsurance > 0)
		{
			GameSettings.Instance.ContentsInsured += insurance.GetContentCoverage(true) * GetCost();
		}
	}

	public bool Broken()
	{
		if (HasUpg)
		{
			return upg.Broken;
		}
		return false;
	}

	public float GetTempCapacity()
	{
		if (TempControlType == TemperatureType.Cooling)
		{
			if (TempGroup == null)
			{
				return 0f;
			}
			return TempGroup.CoolCapacity;
		}
		if (TempGroup == null)
		{
			return 0f;
		}
		return TempGroup.HeatCapacity;
	}

	public float GetTempOutput()
	{
		if (TemperatureOutput)
		{
			if (TempGroup == null)
			{
				return 0f;
			}
			Room mainAtriumParentOrSelf = Parent.GetMainAtriumParentOrSelf();
			if (TempControlType == TemperatureType.Cooling)
			{
				return Mathf.Min(1f, mainAtriumParentOrSelf.GetTemperatureArea(true) / mainAtriumParentOrSelf.TheoCoolingControlArea, TempGroup.CoolOutput);
			}
			return Mathf.Min(1f, mainAtriumParentOrSelf.GetTemperatureArea(false) / mainAtriumParentOrSelf.TheoHeatingControlArea, TempGroup.HeatOutput);
		}
		return 1f;
	}

	public float GetTempArea()
	{
		return HeatCoolArea * GetTempOutput();
	}

	public override string GetInfo()
	{
		if (base.gameObject == null)
		{
			return "";
		}
		if (!string.IsNullOrEmpty(MetalMarket))
		{
			float num = GameSettings.Instance.MetalMarkets.First((StockMarket x) => x.Name.Equals(MetalMarket)).Value * GameSettings.GetMetalPriceFactor(MetalLevel);
			return "Worth".Loc() + ": " + num.Currency() + " (" + ((double)num / SpecialPrice - 1.0).ToPercent(true, true) + ")";
		}
		if (Type.Equals("Award"))
		{
			AwardTrophy component = GetComponent<AwardTrophy>();
			if (component.For != null)
			{
				return component.For.FontBold() + "\n" + "Tier".Loc() + ": " + component.Tier.ToString().Loc() + "\n" + "Effectiveness".Loc() + ": " + component.GetEffectiveness().ToPercent() + "\n" + "Worth".Loc() + ": " + component.GetWorth().Currency();
			}
			return "Tier".Loc() + ": " + component.Tier.ToString().Loc() + "\n" + "Effectiveness".Loc() + ": " + component.GetEffectiveness().ToPercent() + "\n" + "Worth".Loc() + ": " + component.GetWorth().Currency();
		}
		if (Type.Equals("Server"))
		{
			return "Electricity".Loc() + ": " + _currentWattage.GetWatt(false) + "\n" + upg.GetDescription();
		}
		if (Type.Equals("Battery"))
		{
			return "ElectricCharge".Loc() + ": " + (GetComponent<Battery>().CurrentCharge * 1000f).GetWatt(true) + "\n" + upg.GetDescription();
		}
		if (Type.Equals("Elevator") && ElevatorDoors.Length != 0)
		{
			if (!CanExitElevator)
			{
				return "ExitNotAllowed".Loc();
			}
			return "ExitAllowed".Loc();
		}
		if (Wattage < 0f)
		{
			return "Producing".Loc() + ": " + (0.0 - _currentWattage).GetWatt(false) + "\n" + upg.GetDescription();
		}
		if (Type.Equals("Stairs"))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (HasUpg)
		{
			stringBuilder.AppendLine(upg.GetDescription());
		}
		if (Wattage > 0f)
		{
			stringBuilder.AppendLine(IsOn ? "Currentlyon".Loc() : "Currentlyoff".Loc());
			if (_currentWattage > 0.0)
			{
				stringBuilder.AppendLine("Electricity".Loc() + ": " + _currentWattage.GetWatt(false));
			}
		}
		if (_currentWater > 0.0)
		{
			stringBuilder.AppendLine("Water".Loc() + ": " + _currentWater.ToString("0.#") + " " + "LiterAbbr".Loc());
		}
		if (_currentGas > 0.0)
		{
			stringBuilder.AppendLine("Gas".Loc() + ": " + _currentGas.ToString("0.#") + " m3");
		}
		if (InteractionPoints.Length != 0)
		{
			stringBuilder.AppendLine("Currentlyusedby".Loc() + ": " + UsedByInfo());
		}
		if (CanAssign)
		{
			stringBuilder.AppendLine("Ownedby".Loc() + ": " + ((OwnedBy == null) ? "Nobody".Loc() : OwnedBy.employee.FullName));
		}
		if (Type.Equals("Chair"))
		{
			stringBuilder.AppendLine("Comfort".Loc() + ": " + (GetComfort() * 100f).ToString("F") + "%");
		}
		if (Type.Equals("Computer"))
		{
			if (InteractionPoints[0].UsedBy != null)
			{
				stringBuilder.AppendLine("Noiselevel".Loc() + ": " + FinalNoise.ToDB());
			}
			stringBuilder.AppendLine("Power".Loc() + ": " + ComputerPower.ToPercent());
		}
		if (TemperatureController)
		{
			stringBuilder.AppendLine("Capacity".Loc() + ": " + GetTempCapacity().ToPercent());
		}
		if (TemperatureOutput)
		{
			stringBuilder.AppendLine("Usage".Loc() + ": " + GetTempOutput().ToPercent());
		}
		if (Printer != null)
		{
			if (Printer.OwedWatt > 0f)
			{
				stringBuilder.AppendLine("Electricity".Loc() + ": " + (Wattage * UseModifier).GetWatt(false));
			}
			if (Printer.IsManufacturing() && Printer.Group != null)
			{
				stringBuilder.AppendLine("AssemblyLine".Loc() + ": " + Printer.Group.Name);
			}
			stringBuilder.AppendLine("Effectiveness".Loc() + ": " + Printer.GetEffectiveness().ToPercent());
			if (Printer.Type == ProductPrinter.PrinterType.Assembly)
			{
				stringBuilder.AppendLine((Printer.TargetProcess == null) ? "Unassigned".Loc() : Printer.TargetProcess.GetPrettyName());
				stringBuilder.AppendLine("TicketsQueued".Loc(Printer.ManufactureQueue.Count));
			}
			else if (Printer.Type == ProductPrinter.PrinterType.Component)
			{
				stringBuilder.AppendLine((Printer.TargetComponent == null) ? "Unassigned".Loc() : Printer.TargetComponent.GetPrettyName());
			}
			if (IsOn)
			{
				float num2 = Printer.ActualPrintSpeed();
				if (num2 > 0f)
				{
					stringBuilder.AppendLine("NextPrintCountdown".Loc(Mathf.RoundToInt(Printer.NextPrint / num2 * 60f)));
				}
			}
		}
		if (Pallet != null)
		{
			ProductPallet pallet = Pallet;
			Dictionary<IStockable, uint> dictionary = new Dictionary<IStockable, uint>();
			for (int num3 = 0; num3 < pallet.Orders.Length; num3++)
			{
				ProductPrintOrder productPrintOrder = pallet.Orders[num3];
				if (productPrintOrder == null)
				{
					continue;
				}
				for (int num4 = 0; num4 < productPrintOrder.Copies.Length; num4++)
				{
					if (productPrintOrder.Stockables[num4] != null)
					{
						dictionary.AddUp(productPrintOrder.Stockables[num4], productPrintOrder.Copies[num4]);
					}
				}
			}
			foreach (KeyValuePair<IStockable, uint> item in dictionary)
			{
				stringBuilder.AppendLine(item.Key.GetIdentifyingName() + " x " + item.Value);
			}
		}
		if (HasConveyor && Conveyor.Recycler && Conveyor.Recycled != null)
		{
			int num5 = Conveyor.Recycled.SumSafe((int x) => x);
			int num6 = Conveyor.NonRecycled.SumSafe((int x) => x);
			stringBuilder.AppendLine("Effeciency".Loc() + ": " + ((num5 == 0) ? 1f : ((float)num6 / (float)(num5 + num6))).ToPercent());
			stringBuilder.AppendLine("PastTwentyFour".Loc() + ": " + num5);
			stringBuilder.AppendLine("Average".Loc() + ": " + Conveyor.Recycled.AverageOrDefault((int x) => x).ToString("0.#"));
		}
		if (MaxQueue > 0)
		{
			int num7 = 0;
			for (int num8 = 0; num8 < InteractionPoints.Length; num8++)
			{
				InteractionPoint interactionPoint = InteractionPoints[num8];
				num7 += Mathf.Max(0, interactionPoint.CurrentQueue.Count - 1);
			}
			stringBuilder.AppendLine("FurnitureQueue".Loc("Employee".LocPlural(num7)));
		}
		if (Capacity > 0)
		{
			stringBuilder.AppendLine("Capacity".Loc() + ": " + GetStockLeft() + "/" + Capacity);
			if (Waste > 0f)
			{
				stringBuilder.AppendLine("LastMonthWaste".Loc() + ": " + Waste.Currency());
			}
		}
		TrashCan component2;
		if (Type.Equals("Trashcan") && this.TryGetComponent<TrashCan>(out component2))
		{
			stringBuilder.AppendLine("Trash: " + ((float)component2.CurrentTrash / (float)component2.MaxTrash).ToPercent());
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public int GetStockLeft()
	{
		if (_unitStock == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < _unitStock.Count; i++)
		{
			num += _unitStock[i].Amount;
		}
		return num;
	}

	public override IEnumerable<Selectable> GetRelated()
	{
		if (!(base.gameObject != null))
		{
			yield break;
		}
		if (Type.Equals("Server"))
		{
			Server component = GetComponent<Server>();
			if (component == null)
			{
				yield break;
			}
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(component.ServerName);
			if (serverGroup != null)
			{
				foreach (Server item in from x in serverGroup.Servers.OfType<Server>()
					where x != null && x.gameObject != null && x.furn != null
					select x)
				{
					yield return item.furn;
				}
			}
		}
		else if (Type.Equals("Trashcan"))
		{
			foreach (Furniture item2 in Parent.GetFurniture("Computer"))
			{
				if ((item2.transform.position.FlattenVector3() - base.transform.position.FlattenVector3()).sqrMagnitude < 12.25f)
				{
					yield return item2;
				}
			}
		}
		else if (Table != null)
		{
			foreach (TableScript item3 in from x in Table.GetChildren()
				where x != null && x.gameObject != null && x.FurnComp != null
				select x)
			{
				yield return item3.FurnComp;
			}
		}
		else if (TempGroup != null)
		{
			if (TemperatureController)
			{
				foreach (Room item4 in TempGroup.Rooms.Where((Room x) => x != null && x.gameObject != null))
				{
					yield return item4;
				}
			}
			else if (TemperatureOutput)
			{
				HashSet<Furniture> source = ((TempControlType == TemperatureType.Cooling) ? TempGroup.Coolers : TempGroup.Heaters);
				foreach (Furniture item5 in source.Where((Furniture x) => x != null && x.gameObject != null))
				{
					yield return item5;
				}
			}
		}
		else if (CCGroup != null)
		{
			if (Type.Equals("CCTV"))
			{
				foreach (SurveillanceDesk item6 in CCGroup.Desks.Where((SurveillanceDesk x) => x != null && x.gameObject != null))
				{
					yield return item6.Furn;
				}
			}
			else
			{
				foreach (Furniture item7 in CCGroup.CCTVs.Keys.Where((Furniture x) => x != null && x.gameObject != null))
				{
					yield return item7;
				}
			}
		}
		else if (OwnedBy != null)
		{
			yield return OwnedBy;
		}
		if (EGroup == null)
		{
			yield break;
		}
		Furniture[] elevators = EGroup.Elevators;
		foreach (Furniture furniture in elevators)
		{
			if (furniture != null && furniture.gameObject != null)
			{
				yield return furniture;
			}
		}
	}

	public Furniture GetConnectedElevator(bool above)
	{
		if (above)
		{
			if (SnapPoints != null)
			{
				for (int i = 0; i < SnapPoints.Length; i++)
				{
					SnapPoint snapPoint = SnapPoints[i];
					if (snapPoint.MainUsedBy != null && snapPoint.MainUsedBy.Type.Equals("Elevator"))
					{
						return snapPoint.MainUsedBy;
					}
				}
			}
		}
		else if (SnappedTo != null && SnappedTo.Parent.Type.Equals("Elevator"))
		{
			return SnappedTo.Parent;
		}
		Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(base.transform.position + Vector3.up * (above ? 2.5f : (-2.5f)));
		if (roomFromPoint != null)
		{
			Furniture furniture = roomFromPoint.GetFurnitureAtrium("Elevator").FirstOrDefault((Furniture x) => (x.OriginalPosition + (above ? (Vector3.down * 2f) : (Vector3.up * 2f))).Approximate(OriginalPosition, 0.08f));
			if (furniture != null && furniture.Capacity == Capacity && furniture.MiscPotential.Appx(MiscPotential))
			{
				return furniture;
			}
		}
		return null;
	}

	private Vector3 GetRandomEntrancePoint()
	{
		Vector3 vector = _elevatorMatrix.MultiplyPoint(ElevatorEntrance.GetRandomPoint().ToVector3(0f));
		Vector2? pos;
		if (!Parent.GetNavOrClosest(vector.FlattenVector3(), out pos) && pos.HasValue)
		{
			return pos.Value.ToVector3(vector.y);
		}
		return vector;
	}

	public Vector3 GetOffsetPos(Room room, bool inverse = false)
	{
		if ("Portal".Equals(Type))
		{
			return OriginalPosition;
		}
		if ("Elevator".Equals(Type) && room != null)
		{
			if (inverse)
			{
				if (room == Parent)
				{
					return _elevatorMatrix.MultiplyPoint(ElevatorArea.GetRandomPoint().ToVector3(0f));
				}
				return GetRandomEntrancePoint();
			}
			if (room == Parent)
			{
				return GetRandomEntrancePoint();
			}
			Furniture connectedElevator = GetConnectedElevator(true);
			if (connectedElevator != null && room == connectedElevator.Parent)
			{
				return connectedElevator.OriginalPosition;
			}
			connectedElevator = GetConnectedElevator(false);
			if (connectedElevator != null && room == connectedElevator.Parent)
			{
				return connectedElevator.OriginalPosition;
			}
		}
		if (OffsetPoints.Length != 0)
		{
			if (!(room == Parent))
			{
				return _offsetPointCached[(!inverse) ? 1u : 0u];
			}
			return _offsetPointCached[inverse ? 1 : 0];
		}
		return OriginalPosition;
	}

	private string UsedByInfo()
	{
		HashSet<string> hashSet = new HashSet<string>();
		InteractionPoint[] interactionPoints = InteractionPoints;
		foreach (InteractionPoint interactionPoint in interactionPoints)
		{
			if (interactionPoint.UsedBy != null)
			{
				hashSet.Add(interactionPoint.UsedBy.employee.FullName);
			}
		}
		return Newspaper.MakeList(hashSet.ToArray());
	}

	public override string Description()
	{
		return "Pieces of furniture";
	}

	public void SetInteractionMesh(bool interact)
	{
		if (InteractChangeMesh != null)
		{
			InteractChangeMesh.sharedMesh = (interact ? InteractMesh : DefaultMesh);
		}
	}

	public void InteractStart()
	{
		if (InteractAnimation)
		{
			_anim["InteractStart"].speed = GameSettings.GameSpeed;
			_anim.Play("InteractStart");
		}
		if (InteractionScripts != null && InteractionScripts.Length != 0)
		{
			for (int i = 0; i < InteractionScripts.Length; i++)
			{
				InteractionScripts[i].Interact();
			}
		}
		SetInteractionMesh(true);
		if (HasAudioSource && InteractStartClip != null && GameSettings.Instance.ActiveFloor == GetFloor())
		{
			UpdateAudioState();
			UISoundFX.PlaySFX(InteractStartClip, base.transform.position, AudioSrc);
		}
	}

	public void InteractEnd()
	{
		if (InteractAnimation)
		{
			_anim["InteractEnd"].speed = GameSettings.GameSpeed;
			_anim.Play("InteractEnd");
		}
		if (InteractionScripts != null && InteractionScripts.Length != 0)
		{
			for (int i = 0; i < InteractionScripts.Length; i++)
			{
				InteractionScripts[i].Interact();
			}
		}
		SetInteractionMesh(false);
		if (HasAudioSource && InteractEndClip != null && GameSettings.Instance.ActiveFloor == GetFloor())
		{
			if (!IsOn && AudioSrc.isPlaying)
			{
				AudioSrc.Stop();
			}
			UISoundFX.PlaySFX(InteractEndClip, base.transform.position, AudioSrc);
		}
	}

	public bool CheckTwoFloorValid()
	{
		if (Parent != null && ExtraParent != null)
		{
			Furniture[] ignore = SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy()).Concate(this).ToArray();
			if (FurnitureBuilder.IsValid(this, Parent, false, ignore) && FurnitureBuilder.IsValid(this, ExtraParent, false, ignore))
			{
				return true;
			}
		}
		return false;
	}

	public bool KeepWithoutParent(Room r)
	{
		if (!r.Outdoors || TwoFloors || !(r != Parent))
		{
			if (ValidOutside && WallFurn && SecondEdge != null)
			{
				return SecondEdge.Links.ContainsValue(FirstEdge);
			}
			return false;
		}
		return true;
	}

	public bool UpdateParent(bool checkValid = true, bool tableScript = true)
	{
		RefreshEdgeDetection();
		if (Parent != null)
		{
			Parent.RefreshNoise();
		}
		if (WallFurn)
		{
			return true;
		}
		int floor = Mathf.FloorToInt(base.transform.position.y / 2f + 0.5f);
		if (tableScript && Table != null && Parent != null)
		{
			Parent.RemoveTable(Table);
		}
		if (TwoFloors && ExtraParent != null)
		{
			ExtraParent.RemoveFurniture(this);
			ExtraParent.DirtyNavMesh = true;
			ExtraParent.DirtyFloorMesh |= TwoFloors && MakeHole;
			ExtraParent = null;
		}
		Vector2 p = new Vector2(base.transform.position.x, base.transform.position.z);
		if (Parent != null)
		{
			floor = Parent.Floor;
			if (!Parent.IsInside(p, -0.02f))
			{
				if (TwoFloors && MakeHole)
				{
					Parent.DirtyRoofMesh = true;
				}
				Parent.RemoveFurniture(this);
				if ("Elevator".Equals(Type))
				{
					ClearElevatorConnections();
				}
				if (IsConnecter)
				{
					pathNode.Clear();
					Parent.DirtyPathNodes = true;
					if (Type.Equals("Portal"))
					{
						GameSettings.Instance.RefreshPortals(null);
					}
				}
				Parent = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == floor && x.IsInside(p));
				CheckNoiseRefresh();
			}
		}
		else
		{
			if ("Elevator".Equals(Type))
			{
				ClearElevatorConnections();
			}
			if (IsConnecter)
			{
				pathNode.Clear();
				if (Type.Equals("Portal"))
				{
					GameSettings.Instance.RefreshPortals(null);
				}
			}
			Parent = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.Floor == floor && x.IsInside(p));
		}
		if (Parent == null)
		{
			DestroyGO();
			return false;
		}
		Floor = Parent.Floor;
		if (TwoFloors)
		{
			ExtraParent = FurnitureBuilder.GetBestRoom(floor + 1, p, this, null);
			if (!FurnitureBuilder.IsValid(this, ExtraParent, false, SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy()).Concate(this).ToArray()))
			{
				ExtraParent = null;
			}
			if (ExtraParent != null)
			{
				ExtraParent.AddFurniture(this);
				ExtraParent.DirtyNavMesh = true;
				ExtraParent.DirtyPathNodes = true;
				ExtraParent.DirtyFloorMesh |= TwoFloors && MakeHole;
			}
		}
		if (TwoFloors && ExtraParent == null)
		{
			DestroyGO();
			return false;
		}
		if (checkValid && ((IsActivelySnapping && !FurnitureBuilder.IsValid(this, Parent, false, this, SnappedTo.Parent)) || (!IsActivelySnapping && !FurnitureBuilder.IsValid(this, Parent, false, SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy()).Concate(this).ToArray()))))
		{
			DestroyGO();
			return false;
		}
		if (TwoFloors && MakeHole)
		{
			Parent.DirtyRoofMesh = true;
		}
		Parent.AddFurniture(this);
		Floor = Parent.Floor;
		if (tableScript && Table != null)
		{
			Table.Init();
		}
		LampScript component = GetComponent<LampScript>();
		if (component != null)
		{
			component.CalcEdge();
		}
		Parent.DirtyNavMesh = true;
		CalcEdge();
		if (IsConnecter)
		{
			Parent.DirtyPathNodes = true;
		}
		if (Type.Equals("Elevator"))
		{
			UpdateElevatorConnections();
		}
		UpdateBoundsMesh();
		CleanFloor();
		Parent.RecalculateStateVariables();
		Parent.RefreshNoise();
		RefreshAtriumObject();
		InteractionParent = Parent.FindFloorAtrium(OriginalPosition.FlattenVector3());
		return true;
	}

	public void RefreshAtriumObject()
	{
		if (_hasAtriumObject && !Parent.Outside)
		{
			int atriumOffset = _atriumOffset;
			_atriumOffset = 0;
			if (ReverseAtriumScale)
			{
				_atriumOffset = Floor - Parent.FindFloorAtrium(OriginalPosition.FlattenVector3()).Floor;
			}
			else
			{
				_atriumOffset = Parent.FindCeilingAtrium(OriginalPosition.FlattenVector3()).Floor - Floor;
			}
			if (atriumOffset != _atriumOffset)
			{
				RefreshAtriumObjectHeight();
			}
		}
	}

	private void RefreshAtriumObjectHeight()
	{
		if (_hasAtriumObject && !Parent.Outside)
		{
			if (ReverseAtriumScale)
			{
				int num = Floor - _atriumOffset;
				int floor = Floor;
				AtriumObject.localScale = new Vector3(AtriumObject.localScale.x, AtriumObject.position.y - (float)floor * 2f + (float)((floor - num) * 2), AtriumObject.localScale.z);
			}
			else
			{
				int floor2 = Floor;
				int num2 = Mathf.Min(GameSettings.Instance.ActiveFloor, Floor + _atriumOffset);
				AtriumObject.localScale = new Vector3(AtriumObject.localScale.x, (float)floor2 * 2f + 2f - AtriumObject.position.y + (float)((num2 - floor2) * 2) - 0.02f, AtriumObject.localScale.z);
			}
		}
	}

	public void Init()
	{
		if (!_initialized)
		{
			_initialized = true;
			_hasAtriumObject = AtriumObject != null;
			HasUpg = upg != null;
			if (InteractionPoints == null)
			{
				InteractionPoints = new InteractionPoint[0];
			}
			for (int i = 0; i < InteractionPoints.Length; i++)
			{
				InteractionPoints[i].Id = i;
			}
			if (SnapPoints == null)
			{
				SnapPoints = new SnapPoint[0];
			}
			for (int j = 0; j < SnapPoints.Length; j++)
			{
				SnapPoints[j].Id = j;
			}
			if (HoldablePoints == null)
			{
				HoldablePoints = new Transform[0];
			}
			for (int k = 0; k < HoldablePoints.Length; k++)
			{
				Holdables.Add(null);
			}
			if (InteractAnimation || InteractOnAnimation || !string.IsNullOrEmpty(RunningAnimation))
			{
				_anim = GetComponentInChildren<Animation>();
			}
		}
	}

	private void Awake()
	{
		Init();
	}

	public bool TestAvailable(InteractionPoint.ActionType action)
	{
		if (OnFire > 0f)
		{
			return false;
		}
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.UsedBy == null && interactionPoint.Action == action && interactionPoint.Usable())
			{
				return true;
			}
		}
		return false;
	}

	public bool TestAvailable(bool usingCheck = true, InteractionPoint.ActionType? action = null)
	{
		if (OnFire > 0f)
		{
			return false;
		}
		bool result = false;
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if ((!action.HasValue && interactionPoint.Usable()) || (action.HasValue && interactionPoint.Action == action.Value && interactionPoint.Usable()))
			{
				result = true;
				if (usingCheck && interactionPoint.UsedBy != null)
				{
					return false;
				}
			}
		}
		return result;
	}

	protected override void InitializeMatBlock()
	{
		if (_matBlock == null)
		{
			_matBlock = new MaterialPropertyBlock();
			if (ForceEmission)
			{
				_matBlock.SetFloat("_EmissionFact", 1f);
			}
			else if (!isTemporary && EmissionWarmUp)
			{
				_matBlock.SetFloat("_EmissionFact", 0f);
			}
			else if (!isTemporary && EmissionOnWithFurniture && !IsOn)
			{
				_matBlock.SetFloat("_EmissionFact", 0f);
			}
			else
			{
				_matBlock.SetFloat("_EmissionFact", 1f);
			}
		}
	}

	private void Start()
	{
		InitializeMatBlock();
		if (TreeLeaves != null && !GameSettings.Instance.IsReferenceNull())
		{
			TreeLeaves.sharedMaterial = GameSettings.Instance.LeaveMat;
		}
		if (GenerateBoundaryOnStart)
		{
			GenerateBoundary();
			return;
		}
		if (!isTemporary)
		{
			bool flag = Map == null;
			if (!flag)
			{
				TableScript component = GetComponent<TableScript>();
				if (component != null)
				{
					UnityEngine.Object.Destroy(component);
				}
			}
			AudioVisualizer.NoiseDirty = !flag;
			TurnOnOccupants = GetComponent<TurnOnOccupants>() != null;
			List<string> list = (flag ? new List<string>(actions) : null);
			if (Deserialized)
			{
				TimeProbe.BeginTime("Furniture init time:");
			}
			if (RandomSFX)
			{
				_randomSFXTimer = UnityEngine.Random.Range(RandomSFXMin, RandomSFXMax);
			}
			if (flag)
			{
				if (Parent == null)
				{
					DestroyGO();
					return;
				}
				Parent.AddFurniture(this);
				if (PunchHole())
				{
					RefreshParentWall(Parent, false);
				}
				else
				{
					Parent.RefreshNoise();
					Parent.RecalculateStateVariables();
				}
				UpdateBoundaryPoints();
				base.name = base.name.Replace("(Clone)", "");
				GameSettings.Instance.sRoomManager.AllFurniture.Add(this);
				if (!GameSettings.Instance.RentMode && (TemperatureController || TemperatureOutput))
				{
					if (TemperatureOutput)
					{
						HUD.Instance.NoInputTemp.Add(this);
					}
					GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
				}
				if (IsCCTVFurn)
				{
					GameSettings.Instance.sRoomManager.CCTVDirty = true;
				}
				if (Type.Equals("ITStation"))
				{
					GameSettings.Instance.AddITStation(this);
				}
				if (IsConnecter && _pathNode == null)
				{
					_pathNode = new PathNode<Vector3>(base.transform.position + Vector3.up * 0.5f, this);
				}
				if (Type.Equals("Elevator"))
				{
					UpdateElevatorConnections(null, DeserializeClone || !Deserialized || !GameSettings.Instance.ElevatorsSerialized);
					UpdateElevatorDisplay();
				}
				if (IsConnecter || (NavBoundary != null && NavBoundary.Length != 0))
				{
					Parent.DirtyPathNodes = true;
				}
				if (!Deserialized || AlwaysOn)
				{
					IsOn = AlwaysOn || DefaultOn || (IsSnapping && OnWithParent && SnappedTo != null && SnappedTo.Parent.IsOn);
				}
				else if (!Deserialized && DefaultOn)
				{
					IsOn = true;
				}
				UserImageFrame component2;
				if (!Deserialized && "ImageFrame".Equals(Type) && this.TryGetComponent<UserImageFrame>(out component2))
				{
					component2.Init();
				}
				if (Type.Equals("Portal"))
				{
					GameSettings.Instance.InitNewPortal(this);
				}
				if (!Deserialized && !IsOn)
				{
					for (int i = 0; i < SnapPoints.Length; i++)
					{
						SnapPoints[i].ForEachUsed(delegate(Furniture x)
						{
							x.ParentPowerToggled();
						});
					}
				}
				PowerToggled(IsOn);
				if (!isTemporary)
				{
					if (Type.Equals("Sink"))
					{
						NotificationManager.RemoveAggregate<SinkWarningNotification>(null);
					}
					else if (Type.Equals("Solarpanel"))
					{
						UseModifier = TimeOfDay.Instance.SunEffectiveness;
					}
					else if (Type.Equals("WindTurbine"))
					{
						UseModifier = TimeOfDay.Instance.Windiness.magnitude.MapRange(0.01f, 0.02f, 0f, 1f, true);
					}
					else if (Type.Equals("Server"))
					{
						Server component3 = GetComponent<Server>();
						if (component3.Group != null)
						{
							component3.Group.RefreshUsage();
						}
						else
						{
							UseModifier = 0f;
						}
					}
					else if (TempControlType != TemperatureType.None && TemperatureModifyUsage)
					{
						Room mainAtriumParentOrSelf = Parent.GetMainAtriumParentOrSelf();
						mainAtriumParentOrSelf.UpdateTemperatureValues();
						mainAtriumParentOrSelf.ResetTempUsage();
						mainAtriumParentOrSelf.UpdateTemperature(true);
						float useModifier = ((TempControlType == TemperatureType.Cooling) ? mainAtriumParentOrSelf.TempCoolDirectUsage : mainAtriumParentOrSelf.TempHeatDirectUsage);
						UseModifier = useModifier;
					}
					else
					{
						RefreshUsage();
					}
				}
				else
				{
					RefreshUsage();
				}
				if (!Deserialized && Table != null)
				{
					Table.Init();
				}
				if (HasConveyor && Conveyor.GaragePort)
				{
					GameSettings.Instance.GaragePorts.Add(this);
				}
				if (!Deserialized)
				{
					CleanFloor();
					if (TemperatureOutput)
					{
						HintController.Show(HintController.Hints.HintAutoBuyTemp);
					}
				}
			}
			LampScript component4 = GetComponent<LampScript>();
			if (component4 != null)
			{
				component4.CalcEdge();
				if (list != null)
				{
					list.Add("LightAlwaysOn");
				}
			}
			UpdateBoundsMesh();
			if (flag)
			{
				if (Height1 < Actor.HumanHeight && FinalNav != null && FinalNav.Length != 0)
				{
					Parent.DirtyNavMesh = true;
				}
				CheckNoiseRefresh();
				UpdateUseEffects();
				InitWritable();
			}
			RefreshChildren();
			if (flag)
			{
				AudioSrc = ((AudioSrc != null) ? AudioSrc : GetComponent<AudioSource>());
				if (AudioSrc != null)
				{
					HasAudioSource = true;
					MaxAudioDistance = AudioSrc.maxDistance * AudioSrc.maxDistance;
				}
				else
				{
					HasAudioSource = false;
				}
			}
			else
			{
				AudioSource[] components = GetComponents<AudioSource>();
				for (int num = 0; num < components.Length; num++)
				{
					UnityEngine.Object.Destroy(components[num]);
				}
				AudioSrc = null;
				HasAudioSource = false;
			}
			_hasClip = AudioSrc != null && AudioSrc.clip != null;
			CanAssign = CanAssign && InteractionPoints.Length != 0;
			if (flag)
			{
				if (HasConveyor)
				{
					Parent.DirtyConveyors = true;
					Conveyor.UpdateCachedPoints();
				}
				if (HasUpg || HasAudioSource || DespawnHoldables)
				{
					GameSettings.Instance.FurnitureUpdateHandler.RegisterObject(this);
				}
				if ("Computer".Equals(Type))
				{
					GameSettings.Instance.ComputerNoiseUpdateHandler.RegisterObject(this);
				}
				if (!GameSettings.Instance.EditMode && ValidInInventory && !IsConstructionFurniture() && (CanCopy || Type.Equals("Award")))
				{
					list.Add("PutInventory");
				}
				if (CanAssign)
				{
					list.Add("Unpair");
				}
				if (Printer != null && Printer.IsManufacturing())
				{
					list.Add("SetComponentOutput");
					if (Printer.Type == ProductPrinter.PrinterType.Assembly)
					{
						list.Add("ClearBoxes");
						list.Add("AssemblyDetail");
					}
				}
				if (!Type.Equals("Elevator"))
				{
					list.Add("Move");
				}
				else if (ElevatorDoors.Length != 0 && (GameSettings.Instance.EditMode || IsActuallyPlayerControlled()))
				{
					list.Add("ToggleElevator");
				}
				if (ObjectDatabase.Instance.GetUpgrades(UpgradeTo).Count > 0)
				{
					list.Add("ReplaceFurn");
				}
				if (!Type.Equals("Award") && base.ColorEditEnabled)
				{
					list.Add("Furniture color");
				}
				if (AtlasObject != null)
				{
					list.Add("FurnitureStyle");
					list.Add("FurnitureRandomStyle");
				}
				else if ((Signage != null && !Signage.JustLogo) || ReplacementGroups.Length != 0)
				{
					list.Add("FurnitureStyle");
				}
				else if ("ImageFrame".Equals(Type))
				{
					list.Add("FurnitureStyle");
				}
				if (!GameSettings.Instance.EditMode)
				{
					if (Type.Equals("Conveyor") && Conveyor.OutputLength == 1)
					{
						list.Add("TogglePower");
						list.Add("ClearBoxes");
					}
					else if (HasConveyor && Conveyor.GaragePort)
					{
						list.Add("ClearBoxes");
					}
				}
				if (Type.Equals("Server"))
				{
					list.Add("ConnectServers");
				}
				if (CanCopy)
				{
					list.Add("Duplicate");
				}
				if (Insurable)
				{
					list.Add("Insured");
				}
				actions = list.ToArray();
				if (Parent != null)
				{
					Parent.DirtyLights();
					RefreshAtriumObject();
				}
			}
		}
		else if (WallFurn && CustomHeight)
		{
			base.transform.position = new Vector3(base.transform.position.x, WallHeight, base.transform.position.z);
		}
		if (!DisableInitColor && !Deserialized && !GameSettings.Instance.IsReferenceNull())
		{
			InitColors();
			InitAtlas();
			if (Colorable.Count > 0)
			{
				UpdateMaterials();
			}
		}
		if (isTemporary)
		{
			if (!Deserialized)
			{
				ForceTemporary();
			}
		}
		else
		{
			if (ForceColorPrimary)
			{
				base.ColorPrimary = ColorPrimaryDefault;
			}
			if (ForceColorSecondary)
			{
				base.ColorSecondary = ColorSecondaryDefault;
			}
			if (ForceColorTertiary)
			{
				base.ColorTertiary = ColorTertiaryDefault;
			}
			if (ForceColorPrimary || ForceColorSecondary || ForceColorTertiary)
			{
				UpdateMaterials();
			}
		}
		if (!Deserialized && !isTemporary)
		{
			if (RefillCapacity && Capacity > 0)
			{
				Restock(false, true);
			}
			if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.EditMode)
			{
				PlacedInEditMode = true;
			}
		}
		RefreshEdgeDetection();
		if (Deserialized)
		{
			TimeProbe.EndTime("Furniture init time:");
		}
		else if (Map == null && IsNetworkValid() && NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 1)
		{
			SendNetwork();
		}
	}

	public void SendNetwork()
	{
		GameSettings.Instance.QueuedNetworkFurniture.Add(this);
	}

	public bool IsNetworkValid()
	{
		if (!isTemporary && !PartOfGen && ShouldNetwork)
		{
			if (!Parent.Outside && !Parent.Outdoors && !PokesThroughRoof && !PokesThroughWall)
			{
				if (WallFurn)
				{
					return GetAgainstExterior();
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool IsChildVisible()
	{
		if (Colorable != null && Colorable.Count > 0 && Colorable[0] != null)
		{
			return Colorable[0].isVisible;
		}
		if (Children != null && Children[0] != null)
		{
			return Children[0].isVisible;
		}
		return false;
	}

	public void RefreshChildren()
	{
		bool hasRoof = OnRoofObject != null;
		Children = (from x in GetComponentsInChildren<Renderer>(true)
			where !"HideUnaffected".Equals(x.tag) && x.GetComponent<ParticleSystem>() == null && x.GetComponent<Holdable>() == null && (!hasRoof || !IsParentRoof(x.gameObject))
			select x).ToArray();
		CalcEdge();
	}

	public Renderer[] GetChildren()
	{
		return Children;
	}

	private bool IsParentRoof(GameObject o)
	{
		if (o == OnRoofObject)
		{
			return true;
		}
		if (o == base.gameObject)
		{
			return false;
		}
		Transform parent = o.transform.parent;
		if (parent == null)
		{
			return false;
		}
		return IsParentRoof(parent.gameObject);
	}

	public string GetComponentOutput()
	{
		if (Printer != null)
		{
			if (Printer.Type == ProductPrinter.PrinterType.Assembly)
			{
				if (Printer.TargetProcess != null)
				{
					return Printer.TargetProcess.GetPath();
				}
			}
			else if (Printer.Type == ProductPrinter.PrinterType.Component && Printer.TargetComponent != null)
			{
				return Printer.TargetComponent.GetPath();
			}
		}
		return null;
	}

	public void CopyPrinter(Furniture print)
	{
		if (!(Printer != null) || !Printer.IsManufacturing() || !(print.Printer != null) || Printer.Type != print.Printer.Type)
		{
			return;
		}
		lock (Printer)
		{
			if (Printer.Type == ProductPrinter.PrinterType.Assembly)
			{
				Printer.TargetProcess = print.Printer.TargetProcess;
			}
			else
			{
				Printer.TargetComponent = print.Printer.TargetComponent;
			}
		}
		Printer.UpdateSticker();
		GameSettings.Instance.PrinterChanged();
		DistributionWindow.RefreshHardwareStats();
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		if (SerializedQueue != null)
		{
			for (int i = 0; i < SerializedQueue.Length; i++)
			{
				foreach (Actor item in from x in SerializedQueue[i].Skip(1)
					select (Actor)GetDeserializedObject(x))
				{
					if (item != null)
					{
						item.InQueue[Type] = InteractionPoints[i];
						InteractionPoints[i].CurrentQueue.Add(item);
					}
				}
			}
		}
		Server component = GetComponent<Server>();
		if (component != null)
		{
			component.PostDeserialize();
		}
		TableScript component2 = GetComponent<TableScript>();
		if (component2 != null)
		{
			component2.PostDeserialize();
		}
		ReceptionDesk component3 = GetComponent<ReceptionDesk>();
		if (component3 != null && component3.QueueSave != null)
		{
			component3.Queue = (from x in component3.QueueSave
				select GetDeserializedObject(x) as Actor into x
				where x != null
				select x).ToList();
		}
		if (Printer != null)
		{
			Printer.PostDeserialize();
		}
		_subSerializeList.Clear();
		GetComponents(_subSerializeList);
		for (int num = 0; num < _subSerializeList.Count; num++)
		{
			_subSerializeList[num].PostDeserialize();
		}
		_subSerializeList.Clear();
	}

	public void ForceTemporary()
	{
		base.ColorPrimary = ColorPrimaryDefault;
		base.ColorSecondary = ColorSecondaryDefault;
		base.ColorTertiary = ColorTertiaryDefault;
		IsOn = true;
		UpdateMaterials();
	}

	public void UpdateElevatorConnections(Furniture from = null, bool makeGroups = true)
	{
		IsOn = false;
		ClearElevatorConnections();
		Furniture connectedElevator = GetConnectedElevator(true);
		if (connectedElevator != null && connectedElevator.pathNode != null)
		{
			if (connectedElevator != from)
			{
				connectedElevator.UpdateElevatorConnections(this, makeGroups);
				if (makeGroups)
				{
					FixElevatorGroup(connectedElevator);
				}
			}
			pathNode.AddConnection(connectedElevator.pathNode);
		}
		connectedElevator = GetConnectedElevator(false);
		if (!(connectedElevator != null) || connectedElevator.pathNode == null)
		{
			return;
		}
		if (connectedElevator != from)
		{
			connectedElevator.UpdateElevatorConnections(this, makeGroups);
			if (makeGroups)
			{
				FixElevatorGroup(connectedElevator);
			}
		}
		pathNode.AddConnection(connectedElevator.pathNode);
	}

	private void FixElevatorGroup(Furniture other)
	{
		if (EGroup != null && EGroup == other.EGroup)
		{
			return;
		}
		if (EGroup == null)
		{
			if (other.EGroup == null)
			{
				GameSettings.Instance.ElevatorGroups.Add(new ElevatorGroup(this, other));
			}
			else
			{
				other.EGroup.Add(this);
			}
		}
		else if (other.EGroup == null)
		{
			EGroup.Add(other);
		}
		else
		{
			GameSettings.Instance.ElevatorGroups.Remove(ElevatorGroup.Merge(EGroup, other.EGroup));
		}
	}

	public bool UsableForTableGroup()
	{
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = SnapPoints[i];
			if (snapPoint.Name.Equals("OnTable") && snapPoint.MainUsedBy != null && snapPoint.MainUsedBy.DisableTableGrouping)
			{
				return false;
			}
		}
		return true;
	}

	private void UpdateAudioState()
	{
		if (ReverseLowPass)
		{
			Room parentRoom = GetParentRoom(false);
			if (parentRoom == null || parentRoom.Outside || parentRoom.Outdoors)
			{
				AudioSrc.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom.Outdoors || GameSettings.Instance.sRoomManager.CameraRoom.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
			}
			else
			{
				AudioSrc.outputAudioMixerGroup = (((object)GameSettings.Instance.sRoomManager.CameraRoom == parentRoom) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
			}
		}
		else
		{
			Room parent = Parent;
			Room room = (((object)parent != null) ? parent.GetMainAtriumParentOrSelf() : null);
			Room cameraRoom = GameSettings.Instance.sRoomManager.CameraRoom;
			Room room2 = (((object)cameraRoom != null) ? cameraRoom.GetMainAtriumParentOrSelf() : null);
			AudioSrc.outputAudioMixerGroup = (((object)room2 == room) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
	}

	public void UpdateLOD()
	{
		if (LODGroups == null || LODGroups.Count == 0)
		{
			return;
		}
		int num = 0;
		float num2 = CameraScript.Instance.LastCamPos.x - OriginalPosition.x;
		float num3 = CameraScript.Instance.LastCamPos.y - OriginalPosition.y;
		float num4 = CameraScript.Instance.LastCamPos.z - OriginalPosition.z;
		float num5 = num2 * num2 + num3 * num3 + num4 * num4;
		if (num5 > 1600f)
		{
			num = 2;
		}
		else if (num5 > 625f)
		{
			num = 1;
		}
		if (_lastLOD != num)
		{
			_lastLOD = num;
			for (int i = 0; i < LODGroups.Count; i++)
			{
				LODGroups[i].SetLOD(num);
			}
		}
	}

	public void UpdateNow(float delta)
	{
		if (isTemporary || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (EmissionWarmUp && !ForceEmission)
		{
			InitializeMatBlock();
			_matBlock.SetFloat("_EmissionFact", Mathf.Lerp(_matBlock.GetFloat("_EmissionFact"), IsOn ? 1 : 0, delta * 0.3f * GameSettings.GameSpeed));
			UpdateMaterials();
		}
		if (InteractOnAnimation)
		{
			_anim["InteractStart"].speed = GameSettings.GameSpeed;
		}
		if (TurnOffTimer.HasValue && SDateTime.Now() >= TurnOffTimer.Value)
		{
			IsOn = false;
			TurnOffTimer = null;
		}
		if (!string.IsNullOrEmpty(RunningAnimation))
		{
			_anim[RunningAnimation].speed = GameSettings.GameSpeed;
		}
		if (HasUpg)
		{
			upg.UpdateMe();
		}
		if (StartInteraction)
		{
			StartInteraction = false;
			InteractStart();
		}
		if (DespawnHoldables)
		{
			lock (Holdables)
			{
				bool flag = false;
				for (int i = 0; i < Holdables.Count; i++)
				{
					Holdable holdable = Holdables[i];
					if (!(holdable != null))
					{
						break;
					}
					if (SDateTime.GetHours(holdable.Spawned, SDateTime.Now()) > DespawnHour)
					{
						if (holdable.Worth > 0f)
						{
							GameSettings.Instance.MyCompany.AddToBill(0f - holdable.Worth, Company.TransactionCategory.Bills, "FoodWaste");
						}
						holdable.DestroyMe();
						Holdables[i] = null;
						flag = true;
					}
				}
				if (flag)
				{
					UpdateHoldableStatus();
					if (HasHoldables > 0)
					{
						int num = Holdables.Count;
						for (int j = 0; j < num; j++)
						{
							if (!(Holdables[j] == null))
							{
								continue;
							}
							for (int num2 = num - 1; num2 > j; num2--)
							{
								Holdable holdable2 = Holdables[num2];
								if (holdable2 != null)
								{
									PlaceHoldableTransform(j, holdable2);
									Holdables[num2] = null;
									num--;
									break;
								}
								num--;
							}
						}
					}
				}
			}
		}
		if (HoldablePoints.Length != 0 && Parent != null)
		{
			bool flag2 = CameraScript.Instance.GetCameraFloor() == Parent.Floor;
			for (int k = 0; k < HoldablePoints.Length; k++)
			{
				Holdable holdable3 = Holdables[k];
				if (holdable3 != null && holdable3.Renderers.Length != 0 && holdable3.Renderers[0].enabled != flag2)
				{
					for (int l = 0; l < holdable3.Renderers.Length; l++)
					{
						holdable3.Renderers[l].enabled = flag2;
					}
				}
			}
		}
		if (!HasAudioSource || !AudioSrc.isActiveAndEnabled)
		{
			return;
		}
		Room parent = Parent;
		Room room = (((object)parent != null) ? parent.GetMainAtriumParentOrSelf() : null);
		bool isPlaying = AudioSrc.isPlaying;
		if (isPlaying)
		{
			UpdateAudioState();
		}
		_playingOneShot &= isPlaying;
		if (_playingOneShot)
		{
			return;
		}
		if (RandomSFX && GameSettings.Instance.sRoomManager.CameraRoom == room && GameSettings.GameSpeed > 0f && IsOn)
		{
			UpdateAudioState();
			_randomSFXTimer -= delta;
			if (_randomSFXTimer <= 0f)
			{
				_randomSFXTimer = UnityEngine.Random.Range(RandomSFXMin, RandomSFXMax);
				if ((base.transform.position - CameraScript.Instance.LastListenerPos).sqrMagnitude <= MaxAudioDistance)
				{
					AudioSrc.loop = false;
					AudioSrc.clip = SFXFiles.GetRandom();
					AudioSrc.Play();
				}
			}
		}
		if (!_hasClip)
		{
			return;
		}
		if (GameSettings.GameSpeed > 0f && IsOn && (room.IsContentVisible() || (room.Floor <= GameSettings.Instance.ActiveFloor && ReverseLowPass && (object)GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside)))
		{
			if (!isPlaying)
			{
				if (AudioManager.MaxChannels / 2 <= AudioManager.FurniturePlaying || !((base.transform.position - CameraScript.Instance.LastListenerPos).sqrMagnitude <= MaxAudioDistance))
				{
					return;
				}
				AudioSrc.Play();
				if (!string.IsNullOrEmpty(KeepAudioSynced))
				{
					Furniture orDefault = _timeMasters.GetOrDefault(KeepAudioSynced);
					if (orDefault == null || !orDefault.AudioSrc.isPlaying)
					{
						_timeMasters[KeepAudioSynced] = this;
					}
					else
					{
						AudioSrc.timeSamples = orDefault.AudioSrc.timeSamples;
					}
				}
				AudioManager.FurniturePlaying++;
			}
			else if ((base.transform.position - CameraScript.Instance.LastListenerPos).sqrMagnitude > MaxAudioDistance)
			{
				AudioSrc.Stop();
				AudioManager.FurniturePlaying--;
			}
		}
		else if (isPlaying)
		{
			AudioSrc.Stop();
			AudioManager.FurniturePlaying--;
		}
	}

	public void UpdateNow2(float delta)
	{
		ActorNoise = RecalculateNoise(OriginalPosition.FlattenVector3(), true, Parent, this);
		RefreshFinalNoiseValue();
	}

	public bool NeedUpdate(bool firstFunction)
	{
		if (!firstFunction)
		{
			return InteractionPoints[0].UsedBy != null;
		}
		return true;
	}

	public bool IsInCeiling()
	{
		if (!WallFurn)
		{
			return Height1 > 1.6f;
		}
		return false;
	}

	public void RefreshEdgeDetection()
	{
		if ((Parent == null && Map == null) || GameSettings.Instance.IsReferenceNull() || Children == null || Children.Length == 0 || CameraScript.Instance == null || !this.IsAliveNotNull())
		{
			return;
		}
		object room;
		if (Map == null)
		{
			IRoom parent = Parent;
			room = parent;
		}
		else
		{
			IRoom parent = NetworkParent;
			room = parent;
		}
		if (room == null)
		{
			room = GameSettings.Instance.sRoomManager.Outside;
		}
		IRoom room2 = (IRoom)room;
		bool flag = (PokesThroughWall && OnlyExteriorWalls) || !GameSettings.Instance.RentMode || GameSettings.Instance.EditMode || room2.PlayerOwned || !room2.Rentable || (ExtraParent != null && (ExtraParent.PlayerOwned || !ExtraParent.Rentable));
		if (TwoFloors && MakeHole)
		{
			int num = room2.Floor + 1;
			int num2 = num;
			IRoom room3 = ((ExtraParent != null) ? ExtraParent.GetAtriumParent(true) : null);
			if (room3 != null)
			{
				num2 = Mathf.Max(num, room3.Floor + room3.AtriumChildrenCount);
			}
			if (UpperFloorFrame != null)
			{
				bool flag2 = !(ExtraParent != null) || ExtraParent.Outdoors;
				bool flag3 = _beingStylized || (flag && (CameraScript.Instance.FlyMode || (GameSettings.Instance.ActiveFloor >= num && GameSettings.Instance.ActiveFloor <= num2) || (num2 < GameSettings.Instance.ActiveFloor && flag2)));
				if (flag3 ^ UpperFloorFrame.activeSelf)
				{
					UpperFloorFrame.SetActive(flag3);
				}
			}
		}
		if ((PokesThroughRoof || (TwoFloors && !MakeHole)) && OnRoofObject != null)
		{
			OnRoofObject.SetActive((PokesThroughRoof || flag) && (CameraScript.Instance.FlyMode || GameSettings.Instance.ActiveFloor > room2.Floor));
		}
		bool flag4 = IsInCeiling();
		bool flag5 = ((room2.Outside || (IsReversed && Floor <= GameSettings.Instance.ActiveFloor && (!WallFurn || Floor < GameSettings.Instance.ActiveFloor || CheckWallDown()))) && GameSettings.Instance.ActiveFloor >= 0) || IsErrorOutline || (flag && (CameraScript.Instance.FlyMode || ((!flag4 || !GameSettings.Instance.HideCeilingFurniture) && (!WallFurn || CheckWallDown()) && (room2.IsContentVisible() || (TwoFloors && (room2.Floor + 1 == GameSettings.Instance.ActiveFloor || (ExtraParent != null && ExtraParent.IsContentVisible()))) || (!OnHead && !flag4 && GameSettings.Instance.ActiveFloor > -1 && room2.Floor > -1 && room2.Floor < GameSettings.Instance.ActiveFloor && (PokesThroughWall || IsHighlight || IsSecondary || room2.Outdoors || EdgeDetection()))))));
		if (flag5 && IsActivelySnapping && (float)Floor * 2f + OffsetHeight(0) + 0.001f >= (float)(GameSettings.Instance.ActiveFloor * 2 + 2))
		{
			flag5 = false;
		}
		if (Children[0].enabled != flag5)
		{
			for (int i = 0; i < Children.Length; i++)
			{
				Children[i].enabled = flag5;
			}
		}
		if (flag5)
		{
			RefreshAtriumObjectHeight();
		}
	}

	private bool CheckWallDown()
	{
		if (GameSettings.WallsDown == GameSettings.WallState.Low || GameSettings.WallsDown == GameSettings.WallState.LowNoSeg)
		{
			if (MakeHole || GameSettings.Instance.ActiveFloor > Floor)
			{
				return PokesThroughWall;
			}
			return false;
		}
		if (GameSettings.WallsDown == GameSettings.WallState.Back || GameSettings.WallsDown == GameSettings.WallState.High)
		{
			if (!IsHighlight && !IsSecondary && !PokesThroughWall && WallFurnHide && !CameraScript.Instance.TopDown)
			{
				return Vector2.Dot(base.transform.forward.FlattenVector3().normalized, CameraScript.Instance.FlatForward) <= 0.1f;
			}
			return true;
		}
		return true;
	}

	private void OnDestroy()
	{
		Reserved = null;
		if (AudioSrc != null && AudioSrc.isPlaying)
		{
			AudioManager.FurniturePlaying--;
		}
		if (GameSettings.IsQuitting || ErrorLogging.SceneChanging)
		{
			return;
		}
		if (Map != null)
		{
			if (LODGroups != null && LODGroups.Count > 0)
			{
				GameSettings.Instance.DeregisterLOD(this, GetFloor());
			}
		}
		else
		{
			if (isTemporary)
			{
				return;
			}
			if (OwnedBy != null)
			{
				OwnedBy.Owns.Remove(this);
			}
			if (SelectorController.Instance != null && SelectorController.Instance.Selected.Contains(this))
			{
				SelectorController.Instance.Selected.Remove(this);
				SelectorController.Instance.DoPostSelectChecks();
			}
			if (GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			RefreshUsage(true);
			if (HasConveyor && Conveyor.GaragePort)
			{
				GameSettings.Instance.GaragePorts.Add(this);
			}
			if ("Elevator".Equals(Type) && EGroup != null)
			{
				EGroup.Split(this);
			}
			GameSettings.Instance.BrokenIT.Remove(this);
			if ("ITStation".Equals(Type))
			{
				GameSettings.Instance.RemoveITStation(this);
			}
			GameSettings.Instance.FurnitureUpdateHandler.UnregisterObject(this);
			if ("Computer".Equals(Type))
			{
				GameSettings.Instance.ComputerNoiseUpdateHandler.UnregisterObject(this);
			}
			GameSettings.Instance.sActorManager.Actors.ForEach(delegate(Actor x)
			{
				x.Owns.Remove(this);
			});
			GameSettings.Instance.sActorManager.Staff.ForEach(delegate(Actor x)
			{
				x.Owns.Remove(this);
			});
			GameSettings.Instance.sRoomManager.AllFurniture.Remove(this);
			lock (Holdables)
			{
				for (int num = Holdables.Count - 1; num >= 0; num--)
				{
					if (Holdables[num] != null)
					{
						Holdables[num].DestroyMe();
					}
				}
			}
			SymbolicDestroy();
			if ("Portal".Equals(Type))
			{
				if (GameSettings.Instance.Portal1 == this)
				{
					if (GameSettings.Instance.Portal2 != null)
					{
						GameSettings.Instance.Portal2.pathNode.RemoveConnection(pathNode);
					}
					GameSettings.Instance.Portal1 = null;
				}
				if (GameSettings.Instance.Portal2 == this)
				{
					if (GameSettings.Instance.Portal1 != null)
					{
						GameSettings.Instance.Portal1.pathNode.RemoveConnection(pathNode);
					}
					GameSettings.Instance.Portal2 = null;
				}
				GameSettings.Instance.RefreshPortals(this);
			}
			foreach (Furniture item in SnapPoints.SelectMany((SnapPoint x) => x.GetAllUsedBy()))
			{
				if (item != null)
				{
					item.DestroyGO();
				}
			}
			if (!Undo && !PartOfGen && !_networkRedundant)
			{
				if (Offshore || !string.IsNullOrEmpty(MetalMarket))
				{
					GameSettings.Instance.OffshoreAccount += GetSellPrice();
					GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
					AchievementController.SetInteraction(AchievementController.Mechanics.OffshoreAccount);
				}
				else
				{
					GameSettings.Instance.MyCompany.MakeTransaction(GetSellPrice(), Company.TransactionCategory.Construction, Type.Equals("Award"), "Recycle");
				}
			}
			if (Parent != null)
			{
				Parent.DirtyLights();
				if (PokesThroughRoof && Parent.Floor == -1 && GrassSystem.Instance != null)
				{
					GrassSystem.Instance.InvalidateArea();
				}
			}
			BuildController.Instance.ValidateForcedPrefab();
		}
	}

	public float GetCost()
	{
		return GetCost(Type, ComputerPower, UnlockYear, Cost, ForcePCPricing);
	}

	public static float GetCost(string type, float power, int unlock, float cost, bool forcePC)
	{
		if (type.Equals("Computer") || forcePC)
		{
			float num = (SDateTime.Now().ToFloat() + 1900f - (float)unlock).MapRange(0f, 5f, 1.25f, 1f, true);
			return Mathf.CeilToInt(cost * power * num / 100f) * 100;
		}
		return cost;
	}

	public float GetTimelessCost()
	{
		if (Type.Equals("Computer"))
		{
			return Cost * ComputerPower;
		}
		return Cost;
	}

	public float GetSellPrice()
	{
		if (Type.Equals("Award"))
		{
			return GetComponent<AwardTrophy>().GetWorth();
		}
		if (!string.IsNullOrEmpty(MetalMarket))
		{
			return GameSettings.Instance.MetalMarkets.First((StockMarket x) => x.Name.Equals(MetalMarket)).Value * GameSettings.GetMetalPriceFactor(MetalLevel);
		}
		return GetSellPrice(Type, ComputerPower, UnlockYear, Cost, (!HasUpg) ? 1f : upg.Quality, ForcePCPricing);
	}

	public float GetSellPriceIgnoreQuality()
	{
		if (Type.Equals("Award"))
		{
			return GetComponent<AwardTrophy>().GetWorth();
		}
		if (!string.IsNullOrEmpty(MetalMarket))
		{
			return GameSettings.Instance.MetalMarkets.First((StockMarket x) => x.Name.Equals(MetalMarket)).Value * GameSettings.GetMetalPriceFactor(MetalLevel);
		}
		return GetSellPrice(Type, ComputerPower, UnlockYear, Cost, 1f, ForcePCPricing);
	}

	public static float GetSellPrice(string type, float power, int unlock, float cost, float quality, bool force)
	{
		return GetCost(type, power, unlock, cost, force) / 2f * quality;
	}

	public void RefreshNoiseReduction()
	{
	}

	private void ClearElevatorConnections()
	{
		if (this.pathNode == null)
		{
			return;
		}
		List<PathNode<Vector3>> connections = this.pathNode.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			PathNode<Vector3> pathNode = connections[i];
			IRoomConnector roomConnector = pathNode.Tag as IRoomConnector;
			if (roomConnector != null)
			{
				if (roomConnector.pathNode != null)
				{
					roomConnector.pathNode.RemoveConnection(this.pathNode);
				}
				this.pathNode.RemoveConnection(pathNode);
				i--;
			}
		}
	}

	public void CheckNoiseRefresh()
	{
	}

	public void InitLOD()
	{
		if (LODGroups != null && LODGroups.Count > 0)
		{
			GameSettings.Instance.RegisterLOD(this, GetFloor());
		}
	}

	public bool CheckAllowedInRoom()
	{
		if (HUD.Instance != null)
		{
			if (this != null && _ownedBy != null && Parent != null && !Parent.AllowedInRoom(_ownedBy))
			{
				if (!NotificationManager.CheckAggregate<FurnitureAssignmentIssue>(this))
				{
					NotificationManager.AddNotification(new FurnitureAssignmentIssue(SDateTime.Now(), this));
				}
				HUD.Instance.NotAllowedInRoom.Add(this);
				if (ComputerChair.IsAliveNotNull())
				{
					ComputerChair.CheckAllowedInRoom();
				}
				return false;
			}
			NotificationManager.RemoveAggregate<FurnitureAssignmentIssue>(this);
			HUD.Instance.NotAllowedInRoom.Remove(this);
		}
		if (ComputerChair.IsAliveNotNull())
		{
			ComputerChair.CheckAllowedInRoom();
		}
		return true;
	}

	public void SymbolicDestroy()
	{
		_boundCache = null;
		ClearConnections();
		if (LODGroups != null && LODGroups.Count > 0)
		{
			GameSettings.Instance.DeregisterLOD(this, GetFloor());
		}
		if (TemperatureController || TemperatureOutput)
		{
			GameSettings.Instance.sRoomManager.TemperatureControlDirty = true;
		}
		if (IsCCTVFurn)
		{
			GameSettings.Instance.sRoomManager.CCTVDirty = true;
		}
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoints[i].ClearQueue();
		}
		if (HUD.Instance != null)
		{
			lock (HUD.Instance.UnreachableFuniture)
			{
				HUD.Instance.UnreachableFuniture.Remove(this);
			}
			HUD.Instance.BlockedDoorways.Remove(this);
			HUD.Instance.NoChairPC.Remove(this);
			HUD.Instance.NoInputTemp.Remove(this);
			NotificationManager.RemoveAggregate<FurnitureAssignmentIssue>(this);
			HUD.Instance.NotAllowedInRoom.Remove(this);
			HUD.Instance.CCTVNoConnection.Remove(this);
		}
		for (int j = 0; j < GameSettings.Instance.sRoomManager.Rooms.Count; j++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[j];
			if (room != null && room.gameObject != null)
			{
				RefreshParentWall(room, true);
			}
		}
		if (Parent != null)
		{
			CheckNoiseRefresh();
			if (Table != null)
			{
				Parent.RemoveTable(Table);
			}
			if (IsConnecter && pathNode != null)
			{
				if (Type.Equals("Elevator"))
				{
					ClearElevatorConnections();
				}
				pathNode.Clear();
				if (Type.Equals("Portal"))
				{
					GameSettings.Instance.RefreshPortals(null);
				}
			}
			if (Height1 < Actor.HumanHeight && FinalNav != null && FinalNav.Length != 0)
			{
				Parent.DirtyNavMesh = true;
			}
			Parent.DirtyPathNodes = true;
			Parent.RecalculateStateVariables();
			if (TwoFloors && MakeHole)
			{
				Parent.DirtyRoofMesh = true;
			}
		}
		else if (IsConnecter && pathNode != null)
		{
			if (Type.Equals("Elevator"))
			{
				ClearElevatorConnections();
			}
			pathNode.Clear();
			if (Type.Equals("Portal"))
			{
				GameSettings.Instance.RefreshPortals(null);
			}
		}
		if (ExtraParent != null)
		{
			ExtraParent.RemoveFurniture(this);
			bool flag = NavBoundary != null && NavBoundary.Length != 0;
			ExtraParent.DirtyNavMesh = flag;
			ExtraParent.DirtyPathNodes = flag;
			ExtraParent.DirtyFloorMesh |= TwoFloors && MakeHole;
			ExtraParent = null;
		}
		if (Floor < 0 && TwoFloors && MakeHole)
		{
			TimeOfDay.Instance.GroundTopDirty = true;
		}
		if (InteractionPoints != null)
		{
			InteractionPoint[] interactionPoints = InteractionPoints;
			foreach (InteractionPoint ip in interactionPoints)
			{
				if (ip != null && ip.UsedBy != null)
				{
					ip.UsedBy.ResetState();
					Furniture computer = GetComputer();
					if (ip.UsedBy != null && (ip.UsedBy.UsingPoint == ip || (computer != null && computer.InteractionPoints.Any((InteractionPoint x) => x.UsedBy == ip.UsedBy))))
					{
						ip.UsedBy.UsingPoint = null;
					}
				}
			}
		}
		if (SnappedTo != null)
		{
			SnappedTo.SetUsedBy(this, false);
			if (DoesSnapTo("OnTable") && SnappedTo.Parent != null && SnappedTo.Parent.Parent != null)
			{
				SnappedTo.Parent.Parent.RecalculateTableGroups();
			}
			else if (SnappedTo.Parent.Table != null)
			{
				SnappedTo.Parent.Table.UpdateStatus(true);
			}
		}
		AudioVisualizer.NoiseDirty = true;
	}

	private bool EdgeDetection()
	{
		if (CameraScript.Instance.FlyMode)
		{
			return true;
		}
		if (Options.OpaqueGlass)
		{
			return false;
		}
		if (AtEdge <= 11f)
		{
			return false;
		}
		return CameraScript.Instance.transform.rotation.eulerAngles.x < AtEdge;
	}

	public void CalcEdge()
	{
		AtEdge = 0f;
		object room;
		if (Map == null)
		{
			IRoom parent = Parent;
			room = parent;
		}
		else
		{
			IRoom parent = NetworkParent;
			room = parent;
		}
		if (room == null)
		{
			room = GameSettings.Instance.sRoomManager.Outside;
		}
		IRoom room2 = (IRoom)room;
		if (room2 == null || IsInCeiling())
		{
			SetShadowCastingMode(ShadowCastingMode.Off);
			return;
		}
		if (room2.Outdoors || room2.Outside || PokesThroughRoof || PokesThroughWall)
		{
			AtEdge = 90f;
			SetShadowCastingMode(ShadowCastingMode.On);
			return;
		}
		Vector2 vector = new Vector2(base.transform.position.x, base.transform.position.z);
		List<WallEdge> edges = room2.Edges;
		if (edges == null)
		{
			SetShadowCastingMode(ShadowCastingMode.Off);
			return;
		}
		float num = float.MaxValue;
		foreach (IRoom item in room2.GetSelfAndAtriumsAbove())
		{
			if (item == null)
			{
				continue;
			}
			edges = item.Edges;
			for (int i = 0; i < edges.Count; i++)
			{
				int index = (i + 1) % edges.Count;
				if (!edges[i].IsAgainstOutdoorsOutsideAtrium(edges[index]))
				{
					continue;
				}
				Vector2 vector2 = Utilities.ProjectToLineEndlessClamped(vector, edges[i].Pos, edges[index].Pos);
				float magnitude = (vector2 - edges[i].Pos).magnitude;
				if (edges[i].WindowCheck(edges[index], magnitude))
				{
					if (VisibleAtAnyAngles)
					{
						num = 0f;
						break;
					}
					float sqrMagnitude = (vector2 - vector).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
					}
				}
			}
		}
		if (num != float.MaxValue)
		{
			num = Mathf.Max(0f, Mathf.Sqrt(num) - WallCullingDistance);
			float num2 = (float)(room2.FindCeilingAtrium(OriginalPosition.FlattenVector3()).Floor - Floor + 1) * 2f - Height1;
			AtEdge = ((num == 0f) ? 90f : (Mathf.Atan(num2 / num) * 57.29578f));
		}
		SetShadowCastingMode((AtEdge < 4f && !InFloor) ? ShadowCastingMode.On : ShadowCastingMode.Off);
	}

	private void SetShadowCastingMode(ShadowCastingMode mode)
	{
		if (Children == null)
		{
			return;
		}
		for (int i = 0; i < Children.Length; i++)
		{
			if (!"IgnoreMesh".Equals(Children[i].gameObject.tag))
			{
				Children[i].shadowCastingMode = mode;
			}
		}
	}

	public void CleanFloor()
	{
	}

	private static void ClearUseCache()
	{
		if (!_useEffectCleared)
		{
			for (int i = 0; i < _useEffectCache.Length; i++)
			{
				_useEffectCache[i] = 0f;
			}
			_useEffectCleared = true;
		}
	}

	private void ApplyUseCache(int num)
	{
		if (num == 0)
		{
			_useEffects = null;
			return;
		}
		if (_useEffects == null || _useEffects.Length != num || _useEffects == UseEffects)
		{
			_useEffects = new float[num];
		}
		for (int i = 0; i < num; i++)
		{
			_useEffects[i] = _useEffectCache[i];
		}
	}

	private void UpdateUseEffects()
	{
		bool flag = false;
		int num = 0;
		bool flag2 = false;
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			if (SnapPoints[i].UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture item in SnapPoints[i].GetAllUsedBy())
			{
				if (!(item != null) || item.UseEffects == null || item.UseEffects.Length == 0)
				{
					continue;
				}
				if (!flag)
				{
					ClearUseCache();
					flag = true;
				}
				for (int j = 0; j < item.UseEffects.Length; j++)
				{
					if (item.UseEffects[j] > 0f)
					{
						_useEffectCache[j] = Mathf.Max(item.UseEffects[j], _useEffectCache[j]);
						_useEffectCleared = false;
						num = Mathf.Max(num, j + 1);
						flag2 = true;
					}
				}
			}
		}
		if (flag2)
		{
			if (UseEffects != null && UseEffects.Length != 0)
			{
				for (int k = 0; k < UseEffects.Length; k++)
				{
					if (UseEffects[k] > 0f)
					{
						_useEffectCache[k] = Mathf.Max(UseEffects[k], _useEffectCache[k]);
						_useEffectCleared = false;
						num = Mathf.Max(num, k + 1);
					}
				}
			}
			ApplyUseCache(num);
		}
		else
		{
			_useEffects = UseEffects;
		}
	}

	public float GetUseEffect(UseEffect effect)
	{
		return GetUseEffect((int)effect);
	}

	public float GetUseEffect(int i)
	{
		if (_useEffects == null)
		{
			return 0f;
		}
		if (i < _useEffects.Length)
		{
			return _useEffects[i];
		}
		return 0f;
	}

	public void NotifySnapPoint(SnapPoint point, Furniture furn, bool hasSnapped)
	{
		furn.UpdateComputerChair(hasSnapped);
		UpdateUseEffects();
		if (Type.Equals("Computer") && point.Name.Equals("PCAddon") && ComputerTransform != null)
		{
			ComputerTransform.localPosition = (hasSnapped ? PCAddonOffset : OriginalOffset);
			ComputerTransform.localRotation = Quaternion.Euler(hasSnapped ? PCAddonRotation : OriginalRotation);
		}
	}

	public float GetEffectivenessValue(Employee.EmployeeRole role)
	{
		float num = (HasUpg ? upg.Quality : 1f);
		if (num < 0.25f && !NotificationManager.CheckAggregate<FurnitureRepairNotification>(this))
		{
			NotificationManager.AddNotification(new FurnitureRepairNotification(FurnitureRepairNotification.RepairType.Computer, this));
		}
		float computerPower = ComputerPower;
		if (computerPower < 0.6f)
		{
			HintController.Show(HintController.Hints.OldComputerHint);
		}
		return Mathf.Clamp01(num * 2f) * computerPower * (1f + GetUseEffect((int)role));
	}

	public float GetRawEffectivenessValue()
	{
		float num = (HasUpg ? upg.Quality : 1f);
		float computerPower = ComputerPower;
		return Mathf.Clamp01(num * 2f) * computerPower;
	}

	public float GetMaxEffectivenessValue(Employee emp)
	{
		float computerPower = ComputerPower;
		if (computerPower < 0.6f)
		{
			HintController.Show(HintController.Hints.OldComputerHint);
		}
		if (emp.CurrentRoleBit == Employee.RoleBit.None)
		{
			return computerPower;
		}
		float num = 0f;
		int currentRoleBit = (int)emp.CurrentRoleBit;
		for (int i = 0; i < 5; i++)
		{
			if (((1 << i) & currentRoleBit) > 0)
			{
				num = Mathf.Max(emp.GetSkillI(i) * GetUseEffect(i), num);
			}
		}
		return computerPower * (1f + num) + (float)((emp.HasDemanded(LeadDesignDemands.Demand.PrivateOffice) && Parent.GetFurniture("Computer").Count == 1) ? 2 : 0);
	}

	public int GetSnappingDepth()
	{
		int num = 0;
		SnapPoint snappedTo = SnappedTo;
		while (snappedTo != null)
		{
			num++;
			snappedTo = snappedTo.Parent.SnappedTo;
		}
		return num;
	}

	public void LogLoadError(string error, UnityEngine.Object context = null)
	{
		LoadError = true;
		if (GameSettings.Instance.FurnitureErrorOccured)
		{
			Debug.Log(error, context);
		}
		else
		{
			Debug.LogException(new Exception(error), context);
		}
	}

	public Vector2 GetMeanPos()
	{
		return GetMeanPos(base.transform.localToWorldMatrix);
	}

	public Vector2 GetMeanPos(Matrix4x4 trans)
	{
		IList<Vector2> list = ((BuildBoundary == null || BuildBoundary.Length == 0) ? ((IList<Vector2>)CalculateBoundary()) : ((IList<Vector2>)BuildBoundary));
		if (list != null && list.Count > 0)
		{
			return Utilities.GetPolygonCentroid(list, trans);
		}
		return OriginalPosition.FlattenVector3();
	}

	public void UpdateConnectorPositions()
	{
		_elevatorMatrix = base.transform.localToWorldMatrix;
		if (OffsetPoints != null && OffsetPoints.Length != 0)
		{
			_offsetPointCached = OffsetPoints.SelectInPlace((Transform x) => x.position);
		}
	}

	private void PutInInventory(WriteDictionary dictionary)
	{
		if (ValidInInventory && !IsConstructionFurniture())
		{
			Color color = (ForceColorPrimary ? ColorPrimaryDefault : dictionary.Get("ColP", (SVector3)ColorPrimaryDefault).ToColor());
			Color color2 = (ForceColorSecondary ? ColorSecondaryDefault : dictionary.Get("ColS", (SVector3)ColorSecondaryDefault).ToColor());
			Color color3 = (ForceColorTertiary ? ColorTertiaryDefault : dictionary.Get("ColT", (SVector3)ColorTertiaryDefault).ToColor());
			GameSettings.AddToInventory(new InventoryItem(base.name, dictionary.Get("WriteID", 0u), dictionary.Get("AtlasIndex", 0), color, color2, color3, dictionary.Get("Quality", 1f), dictionary.Get("Offshore", false), dictionary.Get("Insured", true)));
		}
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkClient)
	{
		base.transform.position = (SVector3)dictionary["Pos"];
		OriginalPosition = base.transform.position;
		base.transform.rotation = (SVector3)dictionary["Rot"];
		RotationOffset = dictionary.Get("RotationOffset", 0f);
		Parent = GameSettings.Instance.sRoomManager.GetRoomFromPoint(base.transform.position);
		PlacedInEditMode = dictionary.Get("PlacedInEditMode", false);
		base.AtlasIndex = dictionary.Get("AtlasIndex", 0);
		PartOfGen = dictionary.Get("PartOfGen", false);
		SpecialPrice = dictionary.Get("SpecialPrice", 0.0);
		Offshore = dictionary.Get("Offshore", false);
		Insured = dictionary.Get("Insured", true);
		if (dictionary.Contains("TurnOffTimer"))
		{
			TurnOffTimer = dictionary.Get<SDateTime>("TurnOffTimer");
		}
		LightAlwaysOn = dictionary.Get("LightAlwaysOn", false);
		uint num = dictionary.Get("Parent", 0u);
		if (Parent == null || Parent.DID != num || Parent.Outside)
		{
			Vector2 meanPos = GetMeanPos();
			Parent = GameSettings.Instance.sRoomManager.GetRoomFromPoint(meanPos.ToVector3(OriginalPosition.y));
		}
		if ((Parent == null || (Parent.Outside && !ValidOutside)) && !WallFurn && !IsSnapping)
		{
			if (Parent == null)
			{
				LogLoadError("Parent was null for furniture: " + base.name);
			}
			else
			{
				LogLoadError("Parent was outside for furniture: " + base.name);
			}
			PutInInventory(dictionary);
			Parent = null;
			isTemporary = true;
			base.gameObject.SetActive(false);
			DestroyGO();
			return null;
		}
		if (CanBoost)
		{
			BoostValue = dictionary.Get("BoostValue", 1f);
		}
		if (IsSnapping)
		{
			uint pSnapID = dictionary.Get("SnapPoint", 0u);
			if (pSnapID != 0 || !CanNotSnap)
			{
				Furniture furniture = GetDeserializedObject(pSnapID) as Furniture;
				if (furniture == null && pSnapID != 0)
				{
					furniture = GameSettings.Instance.sRoomManager.AllFurniture.FirstOrDefault((Furniture x) => x.DID == pSnapID);
				}
				if (!(furniture != null))
				{
					LogLoadError("Snap was null for furniture: " + base.name);
					PutInInventory(dictionary);
					Parent = null;
					isTemporary = true;
					base.gameObject.SetActive(false);
					DestroyGO();
					return null;
				}
				if (furniture.SnapPoints == null || furniture.SnapPoints.Length == 0)
				{
					LogLoadError("Tried to snap: " + base.name + " to unsnappable object: " + furniture.name, furniture);
					PutInInventory(dictionary);
					Parent = null;
					isTemporary = true;
					base.gameObject.SetActive(false);
					DestroyGO();
					return null;
				}
				int num2 = dictionary.Get("SnapId", 0);
				if (num2 >= furniture.SnapPoints.Length)
				{
					LogLoadError("Snap was out of index for: " + base.name);
					PutInInventory(dictionary);
					Parent = null;
					isTemporary = true;
					base.gameObject.SetActive(false);
					DestroyGO();
					return null;
				}
				SnapPoint snapPoint = furniture.SnapPoints[num2];
				if (snapPoint.HasMain && snapPoint.MainUsedBy != this)
				{
					LogLoadError("Tried to snap " + base.name + " to " + furniture.name + ", but it already had a snap: " + snapPoint.MainUsedBy.name, snapPoint.MainUsedBy);
					PutInInventory(dictionary);
					Parent = null;
					isTemporary = true;
					base.gameObject.SetActive(false);
					DestroyGO();
					return null;
				}
				SnappedTo = snapPoint;
				SnapPointOffset = dictionary.Get("SnapPointOffset", Vector3.zero);
				Vector3 originalPosition = (base.transform.position = SnappedTo.FixPosition(this));
				OriginalPosition = originalPosition;
				RotationOffset = base.transform.rotation.eulerAngles.y - snapPoint.transform.eulerAngles.y;
				if (!CanRotate && RotationOffset != 0f)
				{
					RotationOffset = 0f;
					base.transform.rotation = snapPoint.transform.rotation;
				}
				snapPoint.SetUsedBy(this);
				Parent = furniture.Parent;
			}
		}
		if (WallFurn)
		{
			if (!DeserializeSnap(dictionary, OriginalPosition.FlattenVector3()))
			{
				PutInInventory(dictionary);
				return null;
			}
			if (FirstEdge == null)
			{
				LogLoadError("First wallEdge was null for furniture: " + base.name);
				PutInInventory(dictionary);
				Parent = null;
				isTemporary = true;
				base.gameObject.SetActive(false);
				DestroyGO();
				return null;
			}
			if (SecondEdge == null)
			{
				LogLoadError("Other wallEdge was null for furniture: " + base.name);
				PutInInventory(dictionary);
				Parent = null;
				isTemporary = true;
				base.gameObject.SetActive(false);
				DestroyGO();
				return null;
			}
			Parent = GetPrimaryRoom();
			if (Parent == null)
			{
				LogLoadError("Parent was null for furniture: " + base.name);
				PutInInventory(dictionary);
				isTemporary = true;
				base.gameObject.SetActive(false);
				DestroyGO();
				return null;
			}
			OriginalPosition = base.transform.position;
		}
		if (Parent == null)
		{
			LogLoadError("Parent was null on double check for furniture: " + base.name);
			PutInInventory(dictionary);
			isTemporary = true;
			base.gameObject.SetActive(false);
			DestroyGO();
			return null;
		}
		Floor = Parent.Floor;
		Parent.AddFurniture(this);
		InitLOD();
		Upgradable component = GetComponent<Upgradable>();
		if (component != null)
		{
			component.Deserialize(dictionary);
		}
		if (OnHead)
		{
			OriginalOffset = dictionary.Get("HeadOff", SVector3.Zero);
			OriginalRotation = dictionary.Get("HeadRot", SVector3.Zero);
		}
		if (Signage != null)
		{
			Signage.Deserialize(dictionary);
		}
		if ("Award".Equals(Type))
		{
			GetComponent<AwardTrophy>().Deserialize(dictionary);
		}
		IsOn = (DefaultOn && PlacedInEditMode) || (!Type.Equals("FireAlarm") && !Type.Equals("CCTV") && (bool)dictionary["isOn"]);
		base.ColorPrimary = (ForceColorPrimary ? ColorPrimaryDefault : dictionary.Get("ColP", (SVector3)ColorPrimaryDefault).ToColor());
		base.ColorSecondary = (ForceColorSecondary ? ColorSecondaryDefault : dictionary.Get("ColS", (SVector3)ColorSecondaryDefault).ToColor());
		base.ColorTertiary = (ForceColorTertiary ? ColorTertiaryDefault : dictionary.Get("ColT", (SVector3)ColorTertiaryDefault).ToColor());
		DeserializeReplacement(dictionary);
		Server component2 = GetComponent<Server>();
		if (component2 != null)
		{
			WriteDictionary writeDictionary = dictionary.Get<WriteDictionary>("Server", null);
			if (writeDictionary != null)
			{
				component2.DeserializeThis(writeDictionary, loading, networkClient);
			}
		}
		CalcEdge();
		if (!"Minifridge".Equals(Type))
		{
			if (dictionary.Contains("CapacityUsed"))
			{
				int num3 = dictionary.Get("CapacityUsed", 0);
				if (num3 > 0)
				{
					SDateTime dateLocked = TimeOfDay.GetDateLocked();
					_unitStock = new List<FurnitureStock>
					{
						new FurnitureStock(num3, dateLocked.Year, dateLocked.Month)
					};
				}
			}
			else
			{
				_unitStock = dictionary.Get<List<FurnitureStock>>("UnitStock", null);
			}
		}
		if (loading)
		{
			OnFire = dictionary.Get("OnFire", 0f);
			if (OnFire > 0f)
			{
				GameSettings.Instance.OnFire.Add(this);
				GameSettings.Instance.AddToFireCounter();
				Parent.UpdateFurnOnFire();
			}
			ReceptionDesk component3 = GetComponent<ReceptionDesk>();
			if (component3 != null)
			{
				component3.QueueSave = dictionary.Get<uint[]>("ReceptionQueue", null);
			}
			SerializedQueue = dictionary.Get<uint[][]>("CurrentQueue2", null);
			if (Table != null)
			{
				Table.DeserializeState(dictionary);
			}
			if (dictionary.Contains("AnimAnim") && _anim != null)
			{
				string animation = dictionary.Get<string>("AnimAnim");
				_anim.Play(animation);
				_anim[animation].time = dictionary.Get("AnimTime", 0f);
			}
		}
		Battery component4 = GetComponent<Battery>();
		if (component4 != null)
		{
			component4.Deserialize(dictionary, loading);
		}
		uint pId = dictionary.Get("ExtraParent", 0u);
		ExtraParent = GetDeserializedObject(pId) as Room;
		if (TwoFloors && ExtraParent == null)
		{
			if (pId != 0)
			{
				ExtraParent = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == pId);
			}
			else
			{
				ExtraParent = FurnitureBuilder.GetBestRoom(Parent.Floor + 1, OriginalPosition.FlattenVector3(), this, null);
			}
			if (ExtraParent == null && !AllowNoExtraParent)
			{
				LogLoadError("Extra parent was null for furniture: " + base.name);
				PutInInventory(dictionary);
				ExtraParent = null;
				isTemporary = true;
				base.gameObject.SetActive(false);
				DestroyGO();
				return null;
			}
		}
		if (ExtraParent != null)
		{
			ExtraParent.AddFurniture(this);
			if (GetFloor() == -1)
			{
				TimeOfDay.Instance.GroundTopDirty = true;
			}
		}
		string[] array = dictionary.Get<string[]>("Holdables", null);
		if (array != null)
		{
			int num4 = Mathf.Min(array.Length, HoldablePoints.Length);
			for (int num5 = 0; num5 < num4; num5++)
			{
				if (array[num5] != null)
				{
					PlaceHoldableTransform(num5, ItemDispenser.Instance.Dispense(array[num5].Replace("(Clone)", "")));
				}
			}
		}
		else
		{
			Holdable.HoldableData[] array2 = dictionary.Get<Holdable.HoldableData[]>("Holdables2", null);
			if (array2 != null)
			{
				int num6 = Mathf.Min(array2.Length, HoldablePoints.Length);
				for (int num7 = 0; num7 < num6; num7++)
				{
					if (array2[num7].Type != null)
					{
						Holdable holdable = ItemDispenser.Instance.Dispense(array2[num7].Type);
						holdable.Deserialize(array2[num7]);
						PlaceHoldableTransform(num7, holdable);
					}
				}
			}
		}
		UpdateHoldableStatus();
		if (Printer != null)
		{
			Printer.DeserializeThis(dictionary, loading, networkClient);
		}
		if (Pallet != null)
		{
			Pallet.DeserializeThis(dictionary, loading, networkClient);
		}
		GameSettings.Instance.sRoomManager.AllFurniture.Add(this);
		uint ownedBy = dictionary.Get("OwnedBy", 0u);
		if (ownedBy != 0)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.DID == ownedBy);
			if (actor != null)
			{
				OwnedBy = actor;
			}
		}
		if (HasConveyor)
		{
			Conveyor.UpdateCachedPoints();
			if (Conveyor.Recycler)
			{
				Conveyor.Recycled = dictionary.Get<int[]>("Recycled", null);
				Conveyor.NonRecycled = dictionary.Get<int[]>("NonRecycled", null);
			}
		}
		if (IsConnecter && _pathNode == null)
		{
			_pathNode = new PathNode<Vector3>(base.transform.position + Vector3.up * 0.5f, this);
		}
		UpdateConnectorPositions();
		_subSerializeList.Clear();
		GetComponents(_subSerializeList);
		for (int num8 = 0; num8 < _subSerializeList.Count; num8++)
		{
			_subSerializeList[num8].Deserialize(dictionary, loading);
		}
		_subSerializeList.Clear();
		return this;
	}

	public void SerializeUndo(WriteDictionary dict)
	{
		if (OwnedBy != null)
		{
			dict["OwnedBy"] = OwnedBy.DID;
		}
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["Pos"] = (SVector3)OriginalPosition;
		dictionary["Rot"] = (SVector3)base.transform.rotation;
		dictionary["Floor"] = Floor;
		dictionary["Type"] = base.name;
		dictionary["Parent"] = ((Parent != null) ? Parent.DID : 0u);
		dictionary["RotationOffset"] = RotationOffset;
		dictionary["PlacedInEditMode"] = PlacedInEditMode;
		dictionary["AtlasIndex"] = base.AtlasIndex;
		if (!Insured)
		{
			dictionary["Insured"] = false;
		}
		if (LightAlwaysOn)
		{
			dictionary["LightAlwaysOn"] = true;
		}
		if (Offshore)
		{
			dictionary["Offshore"] = true;
		}
		if (SpecialPrice > 0.0)
		{
			dictionary["SpecialPrice"] = SpecialPrice;
		}
		if (RefillCapacity && Capacity > 0 && mode != GameReader.NewLoadMode.Full)
		{
			dictionary["CapacityUsed"] = Capacity;
		}
		else if (_unitStock != null)
		{
			dictionary["UnitStock"] = _unitStock;
		}
		if (CanFallback && BaseObject != null)
		{
			dictionary["Fallback"] = BaseObject.name;
		}
		if (PartOfGen)
		{
			dictionary["PartOfGen"] = PartOfGen;
		}
		if (CanBoost)
		{
			dictionary["BoostValue"] = BoostValue;
		}
		if (IsSnapping && SnappedTo != null)
		{
			dictionary["SnapPointOffset"] = SnapPointOffset;
			Furniture parent = SnappedTo.Parent;
			if (parent != null)
			{
				dictionary["SnapPoint"] = parent.DID;
				dictionary["SnapId"] = SnappedTo.Id;
			}
		}
		if (WallFurn)
		{
			SerializeSnap(dictionary);
		}
		if (OnHead)
		{
			dictionary["HeadOff"] = (SVector3)OriginalOffset;
			dictionary["HeadRot"] = (SVector3)OriginalRotation;
		}
		dictionary["isOn"] = _isOn;
		dictionary["ColP"] = (SVector3)base.ActualColorPrimary;
		dictionary["ColS"] = (SVector3)base.ActualColorSecondary;
		dictionary["ColT"] = (SVector3)base.ActualColorTertiary;
		SerializeReplacement(dictionary);
		if (Table != null)
		{
			Table.SerializeState(dictionary);
		}
		Server component = GetComponent<Server>();
		if (component != null)
		{
			dictionary["Server"] = component.SerializeThis(mode, networkMode, checkDIDs);
		}
		if (Signage != null)
		{
			Signage.Serialize(dictionary);
		}
		if ("Award".Equals(Type))
		{
			GetComponent<AwardTrophy>().Serialize(dictionary);
		}
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			dictionary["OnFire"] = OnFire;
			if (HasUpg)
			{
				upg.Serialize(dictionary);
			}
			bool flag = false;
			for (int i = 0; i < InteractionPoints.Length; i++)
			{
				InteractionPoint interactionPoint = InteractionPoints[i];
				for (int j = 0; j < interactionPoint.CurrentQueue.Count; j++)
				{
					if (interactionPoint.CurrentQueue[j] == null)
					{
						interactionPoint.CurrentQueue.RemoveAt(j);
						j--;
					}
					else
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				dictionary["CurrentQueue2"] = InteractionPoints.SelectInPlace((InteractionPoint x) => x.CurrentQueue.SelectInPlace((Actor z) => z.DID));
			}
			if (Holdables != null && Holdables.Count > 0)
			{
				dictionary["Holdables2"] = Holdables.SelectInPlace((Holdable x) => (!(x == null)) ? x.Serialize() : new Holdable.HoldableData(null));
			}
			ReceptionDesk component2 = GetComponent<ReceptionDesk>();
			if (component2 != null)
			{
				flag = false;
				for (int num = 0; num < component2.Queue.Count; num++)
				{
					if (component2.Queue[num] == null)
					{
						component2.Queue.RemoveAt(num);
						num--;
					}
					else
					{
						flag = true;
					}
				}
				if (flag)
				{
					dictionary["ReceptionQueue"] = component2.Queue.SelectInPlace((Actor x) => x.DID);
				}
			}
			if (Pallet != null)
			{
				Pallet.SerializeThis(dictionary, mode, networkMode, checkDIDs);
			}
			if (HasConveyor && Conveyor.Recycler && Conveyor.Recycled != null)
			{
				dictionary["Recycled"] = Conveyor.Recycled;
				dictionary["NonRecycled"] = Conveyor.NonRecycled;
			}
			Battery component3 = GetComponent<Battery>();
			if (component3 != null)
			{
				component3.Serialize(dictionary, mode);
			}
			if (TurnOffTimer.HasValue)
			{
				dictionary["TurnOffTimer"] = TurnOffTimer.Value;
			}
		}
		if (_anim != null)
		{
			foreach (AnimationState item in _anim)
			{
				if (item.enabled)
				{
					dictionary["AnimAnim"] = item.name;
					dictionary["AnimTime"] = item.time;
					break;
				}
			}
		}
		if (Printer != null)
		{
			Printer.SerializeThis(dictionary, mode, networkMode, checkDIDs);
		}
		dictionary["ExtraParent"] = ((!(ExtraParent == null)) ? ExtraParent.DID : 0u);
		_subSerializeList.Clear();
		GetComponents(_subSerializeList);
		for (int num2 = 0; num2 < _subSerializeList.Count; num2++)
		{
			_subSerializeList[num2].Serialize(dictionary);
		}
		_subSerializeList.Clear();
	}

	public override string WriteName()
	{
		return "Furniture";
	}

	public void InitializeInteractionPoints()
	{
		if (InteractionPoints != null)
		{
			for (int i = 0; i < InteractionPoints.Length; i++)
			{
				InteractionPoints[i].InitializePosition();
			}
		}
	}

	private void SnapInteractionPointsToChair()
	{
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.Action == InteractionPoint.ActionType.Use || interactionPoint.Action == InteractionPoint.ActionType.Repair)
			{
				InteractionPoint interactionPoint2 = ComputerChair.GetInteractionPoint(InteractionPoint.ActionType.Use, true);
				if (interactionPoint2 != null)
				{
					interactionPoint.transform.position = interactionPoint2.transform.position.ReplaceY(interactionPoint.transform.position.y);
					interactionPoint.transform.rotation = interactionPoint2.transform.rotation;
				}
			}
		}
	}

	public void UpdateComputerChair(bool hasSnapped)
	{
		if (HUD.Instance == null || !(SnappedTo != null))
		{
			return;
		}
		if (NeedsChair && hasSnapped)
		{
			Furniture computerChair = ComputerChair;
			ComputerChair = null;
			if (computerChair != null && computerChair.OwnedBy == OwnedBy)
			{
				computerChair.OwnedBy = null;
			}
			foreach (SnapPoint link in SnappedTo.Links)
			{
				if (!link.HasMain || !(link.MainUsedBy != null) || !"Chair".Equals(link.MainUsedBy.Type))
				{
					continue;
				}
				Furniture mainUsedBy = link.MainUsedBy;
				float y = Quaternion.LookRotation(mainUsedBy.transform.position - base.transform.position).eulerAngles.y;
				y = Mathf.Max(Mathf.Abs(Mathf.DeltaAngle(base.transform.rotation.eulerAngles.y, y)), Mathf.Abs(Mathf.DeltaAngle(mainUsedBy.transform.rotation.eulerAngles.y - 180f, y)));
				if (y < 5f)
				{
					ComputerChair = mainUsedBy;
					if (ComputerChair != null && ComputerChair.OwnedBy != OwnedBy)
					{
						ComputerChair.OwnedBy = OwnedBy;
					}
					SnapInteractionPointsToChair();
					HUD.Instance.NoChairPC.Remove(this);
					return;
				}
			}
			HUD.Instance.NoChairPC.Add(this);
		}
		else
		{
			if (!"Chair".Equals(Type))
			{
				return;
			}
			for (int i = 0; i < SnappedTo.Parent.SnapPoints.Length; i++)
			{
				SnapPoint snapPoint = SnappedTo.Parent.SnapPoints[i];
				if (snapPoint.HasMain && snapPoint.MainUsedBy.NeedsChair)
				{
					snapPoint.MainUsedBy.UpdateComputerChair(true);
				}
			}
		}
	}

	public Rect GetBuildRect()
	{
		if (!_boundCache.HasValue)
		{
			if (FinalBoundary == null || FinalBoundary.Length < 2)
			{
				_boundCache = new Rect(base.transform.position.x, base.transform.position.z, 0f, 0f);
			}
			_boundCache = ((IList<Vector2>)FinalBoundary).GetBounds();
		}
		return _boundCache.Value;
	}

	public Rect GetBuildRect(Vector2 pos, Quaternion rot)
	{
		Rect result = ((BuildBoundary != null && BuildBoundary.Length >= 2) ? ((rot != Quaternion.identity) ? BuildBoundary.Select((Vector2 x) => (rot * x.ToVector3(0f)).FlattenVector3()).GetBounds() : ((IList<Vector2>)BuildBoundary).GetBounds()) : Rect.zero);
		result.position += pos;
		return result;
	}

	public bool UpgradeCompatible(string group)
	{
		if (!string.IsNullOrEmpty(UpgradeTo) && UpgradeTo.Equals(group))
		{
			return true;
		}
		return false;
	}

	public bool UpgradeCompatible(string group, IList<Furniture> fs)
	{
		if (UpgradeCompatible(group))
		{
			if (IsSnapping)
			{
				return fs.Any((Furniture x) => x.IsSnapping && SnapsTo.Contains(x.SnappedTo.Name));
			}
			return true;
		}
		return false;
	}

	public Furniture GetComputer()
	{
		if (SnappedTo == null || !Type.Equals("Chair"))
		{
			return null;
		}
		foreach (SnapPoint link in SnappedTo.Links)
		{
			Furniture mainUsedBy = link.MainUsedBy;
			if (mainUsedBy != null && mainUsedBy.Type.Equals("Computer") && mainUsedBy.ComputerChair == this)
			{
				return mainUsedBy;
			}
		}
		return null;
	}

	public float GetComfort()
	{
		if (Type.Equals("Computer"))
		{
			if (!(ComputerChair != null))
			{
				return 1f;
			}
			return ComputerChair.GetComfort();
		}
		if (!HasUpg)
		{
			return Comfort;
		}
		return ComfortDegration.Evaluate(1f - upg.Quality) * Comfort;
	}

	public void UpdateBoundsMesh()
	{
		if (WallFurn || MeshBoundary == null || MeshBoundary.Length == 0)
		{
			return;
		}
		IRoom room2;
		if (Map != null)
		{
			IRoom room;
			if (!(NetworkParent != null))
			{
				IRoom outside = GameSettings.Instance.sRoomManager.Outside;
				room = outside;
			}
			else
			{
				IRoom outside = NetworkParent;
				room = outside;
			}
			room2 = room;
		}
		else
		{
			room2 = ((Parent != null) ? Parent : GameSettings.Instance.sRoomManager.Outside);
		}
		if (room2 == null)
		{
			return;
		}
		float num = (room2.Outdoors ? 0.05f : Room.WallOffset);
		Vector2[] expanded = room2.GetExpanded(num / 2f);
		Vector2 zero = Vector2.zero;
		Vector2 vector = Vector2.one;
		base.transform.position = OriginalPosition;
		base.transform.localScale = Vector3.one;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		for (int i = 0; i < MeshBoundary.Length; i++)
		{
			num2 = Mathf.Min(num2, MeshBoundary[i].x);
			num3 = Mathf.Max(num3, MeshBoundary[i].x);
			num4 = Mathf.Min(num4, MeshBoundary[i].y);
			num5 = Mathf.Max(num5, MeshBoundary[i].y);
		}
		Vector2 vector2 = new Vector2(Mathf.Clamp(1f / (num3 - num2), 0.5f, 2f), Mathf.Clamp(1f / (num5 - num4), 0.5f, 2f));
		Vector2 vector3 = OriginalPosition.FlattenVector3();
		float num6 = num * num + 0.01f;
		Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		Matrix4x4 inverse = localToWorldMatrix.inverse;
		bool flag = !Utilities.IsInside(vector3, expanded);
		for (int j = 0; j < MeshBoundary.Length; j++)
		{
			Vector2 vector4 = MeshBoundary[j];
			Vector3 vector5 = inverse.MultiplyVector(zero.ToVector3(0f));
			Vector3 point = new Vector3(vector4.x * vector.x + vector5.x, 0f, vector4.y * vector.y + vector5.z);
			Vector2 vector6 = localToWorldMatrix.MultiplyPoint(point).FlattenVector3();
			if (Utilities.IsInside(vector6, expanded))
			{
				continue;
			}
			Vector2 vector7 = Vector2.zero;
			float num7 = float.MaxValue;
			Vector2 vector8 = Vector2.zero;
			float num8 = float.MaxValue;
			for (int k = 0; k < expanded.Length; k++)
			{
				int num9 = (k + 1) % expanded.Length;
				if (!((Utilities.IsLeft(expanded[k], expanded[num9], vector3) > 0) ^ flag))
				{
					continue;
				}
				if (((Utilities.IsLeft(expanded[(k == 0) ? (expanded.Length - 1) : (k - 1)], expanded[k], vector3) > 0) ^ flag) && (room2.Edges[num9].Pos - vector6).magnitude < 0.001f)
				{
					vector8 = expanded[k] - room2.Edges[num9].Pos;
					break;
				}
				if (Utilities.IsLeft(expanded[k], expanded[num9], vector6) > 0)
				{
					continue;
				}
				Vector2 res;
				if (Utilities.ProjectToLine(vector6, expanded[k], expanded[num9], out res))
				{
					Vector2 vector9 = res - vector6;
					float sqrMagnitude = vector9.sqrMagnitude;
					if (sqrMagnitude < 16f)
					{
						float num10 = Mathf.Abs(Vector2.Dot(vector9.normalized, (vector3 - res).normalized));
						sqrMagnitude -= num10 * 0.5f;
						if (sqrMagnitude < num8 && sqrMagnitude < num6)
						{
							num8 = sqrMagnitude;
							vector8 = vector9;
						}
					}
				}
				else
				{
					Vector2 vector10 = expanded[k] - vector6;
					float sqrMagnitude2 = vector10.sqrMagnitude;
					if (sqrMagnitude2 < num7 && sqrMagnitude2 < num6)
					{
						num7 = sqrMagnitude2;
						vector7 = vector10;
					}
				}
			}
			if (vector8 == Vector2.zero && vector7 != Vector2.zero)
			{
				vector8 = vector7;
			}
			if (vector8 != Vector2.zero)
			{
				vector8 *= 1f + 0.01f / vector8.magnitude;
				zero += vector8 * 0.5f;
				Vector3 vector11 = inverse.MultiplyVector(vector8.ToVector3(0f));
				vector = new Vector2(vector.x - Mathf.Abs(vector11.x) * vector2.x, vector.y - Mathf.Abs(vector11.z) * vector2.y);
			}
		}
		_boundsOffset = zero;
		base.transform.position = base.transform.position + new Vector3(zero.x, 0f, zero.y);
		base.transform.localScale = new Vector3(Mathf.Abs(vector.x), 1f, Mathf.Abs(vector.y));
		UpdateSnapPos();
	}

	private void UpdateSnapPos()
	{
		ImprintPosition();
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = SnapPoints[i];
			if (snapPoint.MainUsedBy != null && snapPoint.MainUsedBy.OnHeadOf == null)
			{
				Furniture mainUsedBy = snapPoint.MainUsedBy;
				Vector3 originalPosition = (snapPoint.MainUsedBy.transform.position = snapPoint.FixPosition(snapPoint.MainUsedBy));
				mainUsedBy.OriginalPosition = originalPosition;
				if (snapPoint.MainUsedBy.ComputerChair != null)
				{
					snapPoint.MainUsedBy.SnapInteractionPointsToChair();
				}
				snapPoint.MainUsedBy.UpdateSnapPos();
			}
		}
	}

	public Vector3 GetOriginalPositionWithOffset()
	{
		return OriginalPosition + _boundsOffset.ToVector3(0f);
	}

	public bool IsUsed()
	{
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			if (InteractionPoints[i].UsedBy != null)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanUse(Actor actor, InteractionPoint.ActionType action)
	{
		bool flag = true;
		if (actor.IsEmployee() || actor.AItype == AI.AIType.Parent)
		{
			if (!Parent.CompatibleWithTeam(actor.GetTeam()))
			{
				return false;
			}
			if (Parent.ForceRole >= 0 && (Employee.RoleToMask[Parent.ForceRole] & actor.GetRole()) == 0)
			{
				return false;
			}
			flag = (Reserved == null || Reserved == actor) && (OwnedBy == null || OwnedBy == actor);
		}
		if (flag)
		{
			flag = false;
			for (int i = 0; i < InteractionPoints.Length; i++)
			{
				InteractionPoint interactionPoint = InteractionPoints[i];
				if ((interactionPoint.UsedBy == null || interactionPoint.UsedBy == actor) && interactionPoint.Action == action && interactionPoint.Usable())
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			return false;
		}
		if (!actor.CanUseBrokenFurniture() && HasUpg && upg.Broken)
		{
			return false;
		}
		if (NeedsChair && (ComputerChair == null || !ComputerChair.CanUse(actor, action)))
		{
			return false;
		}
		return true;
	}

	public InteractionPoint GetInteractionPoint(InteractionPoint.ActionType action, bool force = false)
	{
		if (!force && (OnFire > 0f || Parent.BuildingOnFire || Parent.Burn > 0f))
		{
			return null;
		}
		InteractionPoint result = null;
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.Action == action && (force || interactionPoint.Usable()) && !interactionPoint.IsBlocked)
			{
				result = interactionPoint;
				break;
			}
		}
		return result;
	}

	public InteractionPoint GetQueueableInteractionPoint(Actor act, InteractionPoint.ActionType action)
	{
		if (OnFire > 0f || Parent.BuildingOnFire || Parent.Burn > 0f)
		{
			return null;
		}
		if (MaxQueue == 0)
		{
			return null;
		}
		InteractionPoint result = null;
		float num = float.MaxValue;
		Vector2 v = act.ActualPosition.FlattenVector3();
		bool flag = act.currentRoom != Parent;
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.Action == action && interactionPoint.Usable() && interactionPoint.CanQueue(act, action))
			{
				if (flag)
				{
					result = interactionPoint;
					break;
				}
				float num2 = v.ManhattanDist(interactionPoint.Point);
				if (num2 < num)
				{
					result = interactionPoint;
					num = num2;
				}
			}
		}
		return result;
	}

	public InteractionPoint GetInteractionPoint(Actor actor, InteractionPoint.ActionType action)
	{
		if (OnFire > 0f || Parent.BuildingOnFire || Parent.Burn > 0f)
		{
			return null;
		}
		if (actor.IsEmployee() || actor.AItype == AI.AIType.Parent)
		{
			if (GameSettings.Instance.RentMode && Parent.Rentable && !Parent.PlayerOwned)
			{
				return null;
			}
			if (!Parent.AllowedInRoom(actor))
			{
				if (actor == OwnedBy && !NotificationManager.CheckAggregate<FurnitureAssignmentIssue>(this))
				{
					NotificationManager.AddNotification(new FurnitureAssignmentIssue(SDateTime.Now(), this));
				}
				return null;
			}
			if (action == InteractionPoint.ActionType.Use && ((Reserved != null && Reserved != actor) || (OwnedBy != null && OwnedBy != actor)))
			{
				return null;
			}
		}
		if (!actor.CanUseBrokenFurniture() && HasUpg && upg.Broken)
		{
			return null;
		}
		if (Type.Equals("Tray"))
		{
			if (action == InteractionPoint.ActionType.Serve)
			{
				FoodAssemblyInput component = GetComponent<FoodAssemblyInput>();
				if (component != null)
				{
					if (!component.CanReceive())
					{
						return null;
					}
				}
				else if (!CanPlaceHoldable())
				{
					return null;
				}
			}
			else if (HasHoldables == 0)
			{
				return null;
			}
		}
		else if (NeedsChair && (action == InteractionPoint.ActionType.Use || action == InteractionPoint.ActionType.Repair) && (ComputerChair == null || (action != InteractionPoint.ActionType.Repair && !ComputerChair.CanUse(actor, InteractionPoint.ActionType.Use))))
		{
			return null;
		}
		InteractionPoint result = null;
		float num = float.MaxValue;
		Vector2 v = actor.ActualPosition.FlattenVector3();
		bool flag = actor.currentRoom != Parent;
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if ((interactionPoint.UsedBy == null || interactionPoint.UsedBy == actor) && interactionPoint.Action == action && interactionPoint.Usable() && (MaxQueue == 0 || interactionPoint.CurrentQueue.Count == 0 || interactionPoint.CurrentQueue[0] == actor) && !interactionPoint.IsBlocked)
			{
				if (flag)
				{
					result = interactionPoint;
					break;
				}
				float num2 = v.ManhattanDist(interactionPoint.Point);
				if (num2 < num)
				{
					result = interactionPoint;
					num = num2;
				}
			}
		}
		return result;
	}

	public void ImprintPosition()
	{
		if (this == null)
		{
			return;
		}
		if (ComputerChair != null)
		{
			for (int i = 0; i < InteractionPoints.Length; i++)
			{
				InteractionPoints[i].pos = InteractionPoints[i].GetActualPos();
				InteractionPoints[i].worldPos = InteractionPoints[i].transform.position;
			}
		}
		else
		{
			Vector3 position = base.transform.position;
			base.transform.position = GetOriginalPositionWithOffset();
			for (int j = 0; j < InteractionPoints.Length; j++)
			{
				InteractionPoints[j].pos = InteractionPoints[j].GetActualPos();
				InteractionPoints[j].worldPos = InteractionPoints[j].transform.position;
			}
			base.transform.position = position;
		}
		for (int k = 0; k < SnapPoints.Length; k++)
		{
			SnapPoints[k].pos = SnapPoints[k].GetRealPos();
		}
	}

	public InteractionPoint GetDefer(InteractionPoint.ActionType a)
	{
		if ((a == InteractionPoint.ActionType.Use || a == InteractionPoint.ActionType.Repair) && ComputerChair != null)
		{
			return ComputerChair.GetInteractionPoint(InteractionPoint.ActionType.Use, true);
		}
		return null;
	}

	public void SetFire()
	{
		if (SnappedTo != null)
		{
			SnappedTo.Parent.SetFire();
		}
		else if (OnFire == 0f && CanBurn())
		{
			OnFire = 0.0001f;
			GameSettings.Instance.OnFire.Add(this);
			GameSettings.Instance.AddToFireCounter();
			if (HUD.Instance.BuildMode)
			{
				HUD.Instance.BuildMode = false;
			}
			Parent.UpdateFurnOnFire();
		}
	}

	public void UpdateFreeNavs(bool threaded = false)
	{
		bool flag = true;
		Vector3 position = Vector3.zero;
		if (!threaded)
		{
			position = base.transform.position;
			base.transform.position = GetOriginalPositionWithOffset();
		}
		InteractionPoint.ActionType actionType = InteractionPoint.ActionType.Use;
		int num = 0;
		int num2 = 0;
		int num3 = 1;
		bool flag2 = true;
		int num4 = 0;
		bool flag3 = false;
		bool flag4 = false;
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if (interactionPoint.Action != actionType || flag2)
			{
				if (!flag2 && (num < num3 || num2 == 0))
				{
					if (!flag3 && num2 < num3)
					{
						i = num4 - 1;
						flag3 = true;
						num = 0;
						num3 = 1;
						continue;
					}
					flag = flag && (!flag4 || num >= num3);
				}
				flag4 = false;
				num4 = i;
				flag3 = false;
				flag2 = false;
				actionType = interactionPoint.Action;
				num = 0;
				num2 = 0;
				num3 = 1;
			}
			flag4 |= interactionPoint.NeedsReachCheck;
			interactionPoint.UpdateFreeNav(threaded, flag3);
			bool flag5 = interactionPoint.Usable();
			if (!interactionPoint.NeedsReachCheck || flag5)
			{
				num++;
			}
			if (flag5)
			{
				num2++;
			}
			num3 = Mathf.Max(num3, interactionPoint.MinimumNeeded);
			if (i == InteractionPoints.Length - 1 && (num < num3 || num2 == 0))
			{
				if (flag3 || num2 >= num3)
				{
					flag = flag && (!flag4 || num >= num3);
					continue;
				}
				i = num4 - 1;
				flag3 = true;
				num = 0;
				num2 = 0;
			}
		}
		if (!threaded)
		{
			base.transform.position = position;
		}
		for (int j = 0; j < InteractionPoints.Length; j++)
		{
			InteractionPoints[j].UpdateDefer();
		}
		if (!IsSelectionRestricted() && HUD.Instance != null)
		{
			lock (HUD.Instance.UnreachableFuniture)
			{
				if (flag)
				{
					HUD.Instance.UnreachableFuniture.Remove(this);
				}
				else
				{
					HUD.Instance.UnreachableFuniture.Add(this);
				}
			}
		}
		for (int k = 0; k < SnapPoints.Length; k++)
		{
			if (!SnapPoints[k].HasMain)
			{
				SnapPoints[k].UpdateValid(threaded);
			}
		}
	}

	public override bool ValidSnap(bool clone, HashSet<Room> destroy = null, bool keep = false)
	{
		if (Map != null)
		{
			return true;
		}
		if (!clone && FirstEdge.IsFence(SecondEdge))
		{
			float height = FirstEdge.GetHeight(SecondEdge);
			if (Height2 > height)
			{
				return false;
			}
		}
		Room primaryRoom = GetPrimaryRoom();
		if (primaryRoom == null)
		{
			return false;
		}
		if (!clone)
		{
			if (primaryRoom.IsUpperAtriumNotBalcony && !AtriumValid)
			{
				return false;
			}
			if (OnlyExteriorWalls)
			{
				if (FirstEdge.Links.ContainsValue(SecondEdge) && SecondEdge.Links.ContainsValue(FirstEdge))
				{
					if (!ValidAgainstOutdoorArea)
					{
						return false;
					}
					if (!primaryRoom.Outdoors && !GetSecondaryRoom().Outdoors)
					{
						return false;
					}
				}
			}
			else if (OnlyInteriorWalls)
			{
				if (primaryRoom.Outdoors || !FirstEdge.Links.ContainsValue(SecondEdge) || !SecondEdge.Links.ContainsValue(FirstEdge))
				{
					return false;
				}
				if (GetSecondaryRoom().Outdoors)
				{
					return false;
				}
			}
			WallEdge wallEdge = FirstEdge.FindNextColinear(primaryRoom, true, IsReversed);
			WallEdge wallEdge2 = FirstEdge.FindNextColinear(primaryRoom, false, IsReversed);
			float num = wallEdge.Pos.Dist(wallEdge2.Pos);
			Vector2 vector = OriginalPosition.FlattenVector3();
			float num2 = vector.Dist(wallEdge.Pos);
			num2 *= (float)((Utilities.IsLeft(wallEdge.Pos, wallEdge.Pos + (wallEdge2.Pos - wallEdge.Pos).Turn90(), vector) <= 0) ? 1 : (-1));
			if (num2 - WallWidth / 2f < -0.0001f || num2 + WallWidth / 2f > num + 0.0001f)
			{
				return false;
			}
		}
		return true;
	}

	public override bool EdgeChanged(WallEdge[] previous, bool clone)
	{
		_boundCache = null;
		RefreshEdgeDetection();
		if (Map != null)
		{
			return true;
		}
		if (!WallFurn)
		{
			return true;
		}
		Room primaryRoom = GetPrimaryRoom();
		if (primaryRoom == null)
		{
			if (!clone && ValidOutside)
			{
				if (GetSecondaryRoom() != null)
				{
					IsReversed = (SecondEdge.Pos - FirstEdge.Pos).Turn90().normalized.Approximate(base.transform.forward.FlattenVector3(), 0.001f);
					Init(SecondEdge, FirstEdge, WallPosition[SecondEdge] / FirstEdge.Pos.Dist(SecondEdge.Pos));
					return this.IsAliveNotNull();
				}
				DestroyGO();
				return false;
			}
			DestroyGO();
			return false;
		}
		if (!clone)
		{
			if (IsReversed)
			{
				if (GetSecondaryRoom() != null)
				{
					IsReversed = false;
					Init(SecondEdge, FirstEdge, WallPosition[SecondEdge] / FirstEdge.Pos.Dist(SecondEdge.Pos));
					return this.IsAliveNotNull();
				}
			}
			else if (GetPrimaryRoom() == null && ValidOutside && GetSecondaryRoom() != null)
			{
				IsReversed = true;
				Init(SecondEdge, FirstEdge, WallPosition[SecondEdge] / FirstEdge.Pos.Dist(SecondEdge.Pos));
				return this.IsAliveNotNull();
			}
		}
		if (!ValidSnap(clone))
		{
			DestroyGO();
			return false;
		}
		if (primaryRoom != Parent)
		{
			if (Parent != null)
			{
				RefreshParentWall(Parent, true);
			}
			Parent = primaryRoom;
			if (Parent != null)
			{
				Floor = Parent.Floor;
				Parent.AddFurniture(this);
				RefreshParentWall(Parent, false);
			}
		}
		if (PokesThroughWall && (BuildBoundary.Length != 0 || PunchHole()))
		{
			Room room = GetSecondaryRoom();
			if (OnlyExteriorWalls && room != null && !room.Outdoors)
			{
				room = null;
			}
			if (room != ExtraParent)
			{
				if (ExtraParent != null)
				{
					RefreshParentWall(ExtraParent, true);
				}
				ExtraParent = room;
				if (ExtraParent != null)
				{
					ExtraParent.AddFurniture(this);
					RefreshParentWall(ExtraParent, false);
				}
			}
		}
		return true;
	}

	private void RefreshParentWall(Room r, bool remove)
	{
		if (remove && !r.RemoveFurniture(this))
		{
			return;
		}
		r.RefreshNoise();
		if (PunchHole())
		{
			r.DirtyOuterMesh = true;
			r.DirtyInnerMesh = true;
			if (NavBoundary != null && NavBoundary.Length != 0)
			{
				r.DirtyNavMesh = true;
			}
			r.UpdateIsPrivate();
			if (LightAddition > 0f)
			{
				r.UpdateFurnitureWallNearness();
			}
			r.RecalculateStateVariables(LightAddition > 0f);
		}
	}

	public void UpdateBoundaryPoints()
	{
		Matrix4x4 mat = Matrix4x4.TRS(OriginalPosition, base.transform.rotation, Vector3.one);
		FinalBoundary = BuildBoundary.SelectInPlace((Vector2 x) => mat.MultiplyPoint(x.ToVector3(0f)).FlattenVector3());
		FinalNav = NavBoundary.SelectInPlace((Vector2 x) => mat.MultiplyPoint(x.ToVector3(0f)).FlattenVector3());
	}

	public List<Vector2> CalculateBoundary()
	{
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		Vector3 localScale = base.transform.localScale;
		base.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		base.transform.localScale = Vector3.one;
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>(true);
		List<Vector2> list = new List<Vector2>();
		List<Vector3> list2 = new List<Vector3>();
		foreach (MeshFilter item in componentsInChildren.Where((MeshFilter x) => !"HideUnaffected".Equals(x.tag) && !"IgnoreMesh".Equals(x.tag)))
		{
			Matrix4x4 mat = item.transform.localToWorldMatrix;
			item.sharedMesh.GetVertices(list2);
			list.AddRange(list2.Select((Vector3 x) => mat.MultiplyPoint(x).FlattenVector3()));
			list2.Clear();
		}
		list = Utilities.ComputeConvexHull(list);
		if (Utilities.Clockwise(list))
		{
			list.Reverse();
		}
		list.CleanUpPolygon();
		base.transform.SetPositionAndRotation(position, rotation);
		base.transform.localScale = localScale;
		return list;
	}

	public void GenerateBoundary()
	{
		BuildBoundary = CalculateBoundary().ToArray();
	}

	private void OnDrawGizmosSelected()
	{
		if (MeshBoundary != null && MeshBoundary.Length > 1)
		{
			Gizmos.color = Color.yellow;
			Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			for (int i = 0; i < MeshBoundary.Length; i++)
			{
				Vector3 vector = localToWorldMatrix.MultiplyPoint(MeshBoundary[i].ToVector3(0f));
				Vector3 to = localToWorldMatrix.MultiplyPoint(MeshBoundary[(i + 1) % MeshBoundary.Length].ToVector3(0f));
				Gizmos.DrawLine(vector, to);
				Gizmos.DrawSphere(vector, 0.02f);
			}
		}
		if (FinalBoundary != null && FinalBoundary.Length > 1)
		{
			for (int j = 0; j < FinalBoundary.Length; j++)
			{
				Gizmos.color = Color.Lerp(Color.white, Color.black, (float)j / (float)(FinalBoundary.Length - 1));
				int num = (j + 1) % FinalBoundary.Length;
				Gizmos.DrawLine(new Vector3(FinalBoundary[j].x, OffsetHeight(0), FinalBoundary[j].y), new Vector3(FinalBoundary[j].x, OffsetHeight(1), FinalBoundary[j].y));
				Gizmos.DrawLine(new Vector3(FinalBoundary[j].x, OffsetHeight(0), FinalBoundary[j].y), new Vector3(FinalBoundary[num].x, OffsetHeight(0), FinalBoundary[num].y));
				Gizmos.DrawLine(new Vector3(FinalBoundary[j].x, OffsetHeight(1), FinalBoundary[j].y), new Vector3(FinalBoundary[num].x, OffsetHeight(1), FinalBoundary[num].y));
				Gizmos.DrawSphere(new Vector3(FinalBoundary[j].x, Height1, FinalBoundary[j].y), 0.02f);
			}
			Gizmos.color = Color.white;
		}
		else if ((BuildBoundary != null && BuildBoundary.Length > 1) || (NavBoundary != null && NavBoundary.Length > 1))
		{
			if (BuildBoundary != null && BuildBoundary.Length > 1)
			{
				for (int k = 0; k < BuildBoundary.Length; k++)
				{
					Gizmos.color = Color.Lerp(Color.red, Color.black, (float)k / (float)(BuildBoundary.Length - 1));
					int num2 = (k + 1) % BuildBoundary.Length;
					Vector3 vector2 = base.transform.localToWorldMatrix.MultiplyPoint(BuildBoundary[k].ToVector3(0f));
					Vector3 vector3 = base.transform.localToWorldMatrix.MultiplyPoint(BuildBoundary[num2].ToVector3(0f));
					Gizmos.DrawLine(base.transform.position + new Vector3(vector2.x, OffsetHeight(0), vector2.z), base.transform.position + new Vector3(vector2.x, OffsetHeight(1), vector2.z));
					Gizmos.DrawLine(base.transform.position + new Vector3(vector2.x, OffsetHeight(0), vector2.z), base.transform.position + new Vector3(vector3.x, OffsetHeight(0), vector3.z));
					Gizmos.DrawLine(base.transform.position + new Vector3(vector2.x, OffsetHeight(1), vector2.z), base.transform.position + new Vector3(vector3.x, OffsetHeight(1), vector3.z));
					Gizmos.DrawSphere(base.transform.position + new Vector3(vector2.x, Height1, vector2.z), 0.02f);
				}
			}
			if (NavBoundary != null && NavBoundary.Length > 1)
			{
				for (int l = 0; l < NavBoundary.Length; l++)
				{
					Gizmos.color = Color.Lerp(Color.cyan, Color.black, (float)l / (float)(NavBoundary.Length - 1));
					int num3 = (l + 1) % NavBoundary.Length;
					Gizmos.DrawLine(base.transform.position + new Vector3(NavBoundary[l].x, 0.01f, NavBoundary[l].y), base.transform.position + new Vector3(NavBoundary[num3].x, 0.01f, NavBoundary[num3].y));
					Gizmos.DrawSphere(base.transform.position + new Vector3(NavBoundary[l].x, 0.01f, NavBoundary[l].y), 0.02f);
				}
			}
			Gizmos.color = Color.white;
		}
		if (SurfaceSnapRadius > 0f)
		{
			Gizmos.color = Color.yellow;
			Utilities.DrawCylinder(base.transform.position + Vector3.up * Height1, Height2 - Height1, SurfaceSnapRadius, Gizmos.DrawLine);
		}
		if (ComputerChair != null)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(base.transform.position, ComputerChair.transform.position);
			Gizmos.color = Color.white;
		}
		if ("Elevator".Equals(Type))
		{
			Gizmos.matrix = _elevatorMatrix;
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireCube(ElevatorEntrance.center.ToVector3(0f), ElevatorEntrance.size.ToVector3(0.1f));
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(ElevatorArea.center.ToVector3(0f), ElevatorArea.size.ToVector3(0.1f));
			Gizmos.matrix = Matrix4x4.identity;
		}
		if (!IsConnecter || pathNode == null)
		{
			return;
		}
		foreach (PathNode<Vector3> connection in pathNode.GetConnections())
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(pathNode.Point, connection.Point);
		}
	}

	public Matrix4x4 GetElevatorMatrix()
	{
		return _elevatorMatrix;
	}

	public void OnDrawGizmos()
	{
		if (HasAudioSource && (GameSettings.Instance.IsReferenceNull() || Floor == GameSettings.Instance.ActiveFloor))
		{
			Gizmos.color = ((!AudioSrc.isPlaying) ? Color.red : ((AudioSrc.outputAudioMixerGroup == AudioManager.InGameHighPass) ? Color.blue : Color.green));
			Gizmos.DrawSphere(base.transform.position + Vector3.up * 1.5f, 0.1f);
		}
		Gizmos.color = Color.white;
	}

	public override int GetFloor()
	{
		return Floor;
	}

	public void UpdateBlocked()
	{
		HUD.Instance.BlockedDoorways.Remove(this);
		if (!IsConnecter)
		{
			return;
		}
		IsBlocked = HasUpg && upg.Broken;
		if (!IsBlocked)
		{
			Vector3 offsetPosCheck = GetOffsetPosCheck();
			if (Parent.GetNodeAt(offsetPosCheck.FlattenVector3()) == null)
			{
				IsBlocked = true;
			}
			else if (TwoFloors && ExtraParent != null)
			{
				offsetPosCheck = GetOffsetPos(Parent, true);
				if (ExtraParent.GetNodeAt(offsetPosCheck.FlattenVector3()) == null)
				{
					IsBlocked = true;
				}
			}
		}
		if (IsBlocked)
		{
			HUD.Instance.BlockedDoorways.Add(this);
		}
		UpdateWeight();
	}

	public Vector3 GetOffsetPosCheck()
	{
		if (!Type.Equals("Elevator"))
		{
			return GetOffsetPos(Parent);
		}
		return _elevatorMatrix.MultiplyPoint(ElevatorEntrance.center.ToVector3(0f));
	}

	public void UpdateWeight(float? weight = null)
	{
		if (IsBlocked)
		{
			pathNode.Weight = float.PositiveInfinity;
		}
		else if ("Portal".Equals(Type))
		{
			pathNode.Weight = 0f;
		}
		else if (weight.HasValue)
		{
			pathNode.Weight = weight.Value;
		}
		else if ("Elevator".Equals(Type))
		{
			pathNode.Weight = ((EGroup == null) ? 0.5f : (EGroup.PathWeight * ((!CanExitElevator && !CanEnterElevator) ? 0.75f : 1f)));
		}
		else
		{
			pathNode.Weight = 1f;
		}
	}

	public Transform[] IntermediatePoints(Room from)
	{
		if (from != Parent && InterPointsReversed != null && InterPointsReversed.Length != 0)
		{
			return InterPointsReversed;
		}
		return InterPoints;
	}

	public bool IsCampaignOwned()
	{
		if (GameSettings.Instance.CampaignMode && OwnedBy != null)
		{
			return OwnedBy.employee.Founder;
		}
		return false;
	}

	public override bool IsSelectionRestricted()
	{
		if (Map != null)
		{
			return true;
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			if (PartOfGen)
			{
				return true;
			}
			if (!GameSettings.Instance.EditMode && PlacedInEditMode)
			{
				return true;
			}
			if (Parent != null && !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode && !IsCampaignOwned() && (!InRentMode || !Parent.Rentable || !Parent.PlayerOwned))
			{
				return true;
			}
		}
		return false;
	}

	public override bool IsSelectableInView()
	{
		if (Parent != null && (Parent.Outdoors || Parent.Outside || IsReversed || Parent.IsContentVisible() || ((PokesThroughRoof || TwoFloors) && GetFloor() + 1 == GameSettings.Instance.ActiveFloor)) && (!IsInCeiling() || !GameSettings.Instance.HideCeilingFurniture))
		{
			if (WallFurn)
			{
				return CheckWallDown();
			}
			return true;
		}
		return false;
	}

	public KeyValuePair<CombineInstance[], int> FixCombine()
	{
		CombineInstance[] array = new CombineInstance[Colorable.Count];
		int num = 0;
		for (int i = 0; i < Colorable.Count; i++)
		{
			CombineInstance combineInstance = (array[i] = new CombineInstance
			{
				mesh = FixMesh(Colorable[i].GetComponent<MeshFilter>().mesh),
				transform = Colorable[i].localToWorldMatrix
			});
			num += combineInstance.mesh.vertexCount;
		}
		return new KeyValuePair<CombineInstance[], int>(array, num);
	}

	private Mesh FixMesh(Mesh m)
	{
		Mesh mesh = new Mesh();
		Vector2[] uv = m.uv;
		mesh.vertices = m.vertices;
		mesh.normals = m.normals;
		mesh.uv = uv;
		mesh.tangents = m.tangents;
		Color[] array = new Color[uv.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Vector2 vector = uv[i];
			if (vector.x < 0.5f)
			{
				if (vector.y < 0.5f)
				{
					array[i] = base.ColorTertiary.Alpha(1f - vector.y / 0.5f);
				}
				else
				{
					array[i] = base.ColorPrimary.Alpha((1f - vector.y) / 0.5f);
				}
			}
			else if (vector.y < 0.5f)
			{
				float a = (vector.x - 0.5f) / 0.5f;
				float num = vector.y / 0.5f;
				array[i] = new Color(num, num, num, a);
			}
			else
			{
				array[i] = base.ColorSecondary.Alpha((1f - vector.y) / 0.5f);
			}
		}
		mesh.colors = array;
		mesh.triangles = m.triangles;
		return mesh;
	}

	public override bool SingleMat()
	{
		return false;
	}

	public bool CanPlaceHoldable()
	{
		lock (Holdables)
		{
			for (int num = Holdables.Count - 1; num >= 0; num--)
			{
				if (Holdables[num] == null)
				{
					return true;
				}
			}
			return false;
		}
	}

	public void UpdateHoldableStatus()
	{
		lock (Holdables)
		{
			HasHoldables = Holdables.Count((Holdable x) => x != null);
		}
	}

	public void ClearHoldables()
	{
		lock (Holdables)
		{
			for (int i = 0; i < Holdables.Count; i++)
			{
				if (Holdables[i] != null)
				{
					Holdables[i].DestroyMe();
					Holdables[i] = null;
				}
			}
			UpdateHoldableStatus();
		}
	}

	public bool AnyHoldable(Func<Holdable, bool> check)
	{
		lock (Holdables)
		{
			for (int i = 0; i < Holdables.Count; i++)
			{
				if (Holdables[i] != null && check(Holdables[i]))
				{
					return true;
				}
			}
			return false;
		}
	}

	public Holdable GetHoldable(Func<Holdable, bool> check)
	{
		lock (Holdables)
		{
			for (int i = 0; i < Holdables.Count; i++)
			{
				if (Holdables[i] != null && check(Holdables[i]))
				{
					Holdable result = Holdables[i];
					Holdables[i] = null;
					UpdateHoldableStatus();
					return result;
				}
			}
			return null;
		}
	}

	public void ForeachHoldable(Action<Holdable> action)
	{
		lock (Holdables)
		{
			for (int i = 0; i < Holdables.Count; i++)
			{
				if (Holdables[i] != null)
				{
					action(Holdables[i]);
				}
			}
		}
	}

	public bool PlaceHoldable(Holdable holdable)
	{
		lock (Holdables)
		{
			for (int i = 0; i < Holdables.Count; i++)
			{
				if (Holdables[i] == null)
				{
					PlaceHoldableTransform(i, holdable);
					UpdateHoldableStatus();
					return true;
				}
			}
			return false;
		}
	}

	private void PlaceHoldableTransform(int i, Holdable holdable)
	{
		lock (Holdables)
		{
			if (i < HoldablePoints.Length)
			{
				holdable.transform.position = HoldablePoints[i].position;
				holdable.transform.rotation = HoldablePoints[i].rotation;
				holdable.transform.SetParent(HoldablePoints[i], true);
				Holdables[i] = holdable;
			}
			else
			{
				Debug.LogException(new Exception("Tried placing more holdables than allowed on " + base.name));
			}
		}
	}

	public Holdable TakeHoldable()
	{
		lock (Holdables)
		{
			Holdable holdable = null;
			for (int num = Holdables.Count - 1; num >= 0; num--)
			{
				if (Holdables[num] != null)
				{
					holdable = Holdables[num];
					Holdables[num] = null;
					break;
				}
			}
			UpdateHoldableStatus();
			if (holdable != null)
			{
				holdable.transform.SetParent(null, true);
			}
			return holdable;
		}
	}

	public static float CalculateNoise(float noise, float distance, float acoustics)
	{
		distance *= acoustics.MapRange(0f, 1f, 0.5f, 1f);
		if (distance >= noise)
		{
			return 0f;
		}
		float num = Mathf.Min(1f, distance / noise);
		num = Mathf.Pow(1f - num, 0.25f);
		return num * Mathf.Clamp01(noise / 8f);
	}

	private static List<Vector2> GetNoiseReduction(Vector2 pos, Room r, List<Furniture> cubicles, float maxDistance = 2f)
	{
		cSegments.Clear();
		if (cubicles != null)
		{
			for (int i = 0; i < cubicles.Count; i++)
			{
				AddSegment(pos, cubicles[i], maxDistance);
			}
		}
		else
		{
			HashList<Furniture> furniture = r.GetFurniture("Cubicle");
			int count = furniture.Count;
			for (int j = 0; j < count; j++)
			{
				Furniture furn = furniture[j];
				AddSegment(pos, furn, maxDistance);
			}
		}
		return cSegments;
	}

	private static void AddSegment(Vector2 pos, Furniture furn, float maxDistance)
	{
		float num = pos.x - furn.OriginalPosition.x;
		float num2 = pos.y - furn.OriginalPosition.z;
		if (num > 0f - maxDistance && num < maxDistance && num2 > 0f - maxDistance && num2 < maxDistance)
		{
			Vector3 vector = furn.transform.right * 0.5f;
			cSegments.Add(new Vector2(furn.OriginalPosition.x + vector.x, furn.OriginalPosition.z + vector.z));
			cSegments.Add(new Vector2(furn.OriginalPosition.x - vector.x, furn.OriginalPosition.z - vector.z));
		}
	}

	private static bool CheckCubicleIntersection(Vector2 a, Vector2 b, List<Vector2> cubes)
	{
		if (cubes.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < cubes.Count; i += 2)
		{
			Vector2 p = cubes[i];
			Vector2 p2 = cubes[i + 1];
			if (a.x < p.x)
			{
				if (a.x < p2.x && b.x < p.x && b.x < p2.x)
				{
					continue;
				}
			}
			else if (p.x < b.x && p2.x < a.x && p2.x < b.x)
			{
				continue;
			}
			if (a.y < p.y)
			{
				if (a.y < p2.y && b.y < p.y && b.y < p2.y)
				{
					continue;
				}
			}
			else if (p.y < b.y && p2.y < a.y && p2.y < b.y)
			{
				continue;
			}
			if (Utilities.FasterLineSegmentIntersection(a, b, p, p2))
			{
				return true;
			}
		}
		return false;
	}

	private static float CalculateNoiseReduction(Vector2 a, Vector2 b, List<Vector2> cubes)
	{
		if (!CheckCubicleIntersection(a, b, cubes))
		{
			return 1f;
		}
		return 0.6f;
	}

	private static void AddNoiseValue(float val)
	{
		if (val > 0f)
		{
			NoiseValues.AddOrReplace(NoiseValueCount, val);
			NoiseValueCount++;
			NoiseValueMax = Mathf.Max(val, NoiseValueMax);
		}
	}

	private static float CalculateFinalNoiseValue()
	{
		if (NoiseValueCount == 0 || NoiseValueMax == 0f)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < NoiseValueCount; i++)
		{
			num += NoiseValues[i] / NoiseValueMax * NoiseValues[i];
		}
		return num;
	}

	private HashSet<Actor> GetIgnoreNoiseFrom(bool clear = true)
	{
		if (clear)
		{
			if (SnappedTo != null)
			{
				return SnappedTo.Parent.GetIgnoreNoiseFrom();
			}
			_noiseIgnoreCache.Clear();
		}
		for (int i = 0; i < InteractionPoints.Length; i++)
		{
			InteractionPoint interactionPoint = InteractionPoints[i];
			if ((interactionPoint.Action == InteractionPoint.ActionType.Use || interactionPoint.Action == InteractionPoint.ActionType.Social || interactionPoint.Action == InteractionPoint.ActionType.Visit) && interactionPoint.UsedBy != null)
			{
				_noiseIgnoreCache.Add(interactionPoint.UsedBy);
			}
		}
		for (int j = 0; j < SnapPoints.Length; j++)
		{
			SnapPoint snapPoint = SnapPoints[j];
			if (snapPoint.HasMain && snapPoint.MainUsedBy != null)
			{
				snapPoint.MainUsedBy.GetIgnoreNoiseFrom(false);
			}
		}
		return _noiseIgnoreCache;
	}

	public static float RecalculateNoise(Vector2 p, bool actor, Room parent, Furniture self, List<Furniture> cubicles = null, bool both = false, bool forceNoise = false)
	{
		List<Vector2> noiseReduction = GetNoiseReduction(p, parent, cubicles);
		NoiseValueCount = 0;
		NoiseValueMax = 0f;
		float num = parent.Acoustics.MapRange(0f, 1f, 2f, 1f);
		if (actor || both)
		{
			HashSet<Actor> hashSet = ((self == null) ? null : self.GetIgnoreNoiseFrom());
			for (int i = 0; i < parent.Occupants.Count; i++)
			{
				Actor actor2 = parent.Occupants[i];
				if ((hashSet == null || !hashSet.Contains(actor2)) && actor2.Noisiness > 0f)
				{
					Vector2 vector = actor2.ActualPosition.FlattenVector3();
					float num2 = actor2.Noisiness * CalculateNoiseReduction(p, vector, noiseReduction);
					if (Mathf.Abs(vector.x - p.x) < num2 * num && Mathf.Abs(vector.y - p.y) < num2 * num)
					{
						AddNoiseValue(CalculateNoise(num2, (p - vector).magnitude, parent.Acoustics));
					}
				}
			}
		}
		if (!actor || both)
		{
			Room mainAtriumParentOrSelf = parent.GetMainAtriumParentOrSelf();
			NoiseVisit.Clear();
			if (mainAtriumParentOrSelf.AtriumChildren.Count > 0)
			{
				foreach (Room item in mainAtriumParentOrSelf.GetAtriumChildrenAndSelf())
				{
					GetNoiseFromRoom(item, parent, p, noiseReduction, self, false, forceNoise);
					for (int j = 0; j < item.Edges.Count; j++)
					{
						Room room = item.Edges[(j + 1) % item.Edges.Count].GetRoom(item.Edges[j]);
						if (room != null)
						{
							GetNoiseFromRoom(room, parent, p, noiseReduction, self, !room.IsAtriumParent(mainAtriumParentOrSelf), forceNoise);
						}
					}
				}
			}
			else
			{
				GetNoiseFromRoom(mainAtriumParentOrSelf, parent, p, noiseReduction, self, false, forceNoise);
				for (int k = 0; k < mainAtriumParentOrSelf.Edges.Count; k++)
				{
					Room room2 = mainAtriumParentOrSelf.Edges[(k + 1) % mainAtriumParentOrSelf.Edges.Count].GetRoom(mainAtriumParentOrSelf.Edges[k]);
					if (room2 != null)
					{
						GetNoiseFromRoom(room2, parent, p, noiseReduction, self, true, forceNoise);
					}
				}
			}
			if (parent.Floor >= 0)
			{
				float outdoorNoise = Room.GetOutdoorNoise(new Vector3(0f, parent.Floor * 2, 0f));
				if (outdoorNoise > 0f)
				{
					float num3 = 100f;
					float num4 = 0.05f;
					for (int l = 0; l < parent.Edges.Count; l++)
					{
						WallEdge wallEdge = parent.Edges[l];
						WallEdge wallEdge2 = parent.Edges[(l + 1) % parent.Edges.Count];
						Room room3 = wallEdge2.GetRoom(wallEdge);
						Vector2 res;
						if ((!(room3 == null) && !room3.Outdoors) || !Utilities.ProjectToLine(p, wallEdge.Pos, wallEdge2.Pos, out res))
						{
							continue;
						}
						float magnitude = (p - res).magnitude;
						if (!(magnitude < outdoorNoise))
						{
							continue;
						}
						float num5 = WallIsolation;
						float magnitude2 = (wallEdge.Pos - res).magnitude;
						HashSet<WallSnap> orNull = wallEdge.Children.GetOrNull(wallEdge2);
						if (orNull != null)
						{
							foreach (RoomSegment item2 in orNull.OfType<RoomSegment>())
							{
								float num6 = item2.WallPosition[wallEdge];
								float num7 = num6 + item2.WallWidth / 2f;
								num6 -= item2.WallWidth / 2f;
								if (magnitude2 > num6 && magnitude2 < num7)
								{
									num5 = item2.NoiseFactor * (item2.Height2 - item2.Height1) / 2f;
									break;
								}
							}
						}
						num5 *= CalculateNoiseReduction(p, res, noiseReduction);
						if (magnitude / num5 < num3 / num4)
						{
							num3 = magnitude;
							num4 = num5;
						}
					}
					outdoorNoise *= num4;
					AddNoiseValue(CalculateNoise(outdoorNoise, num3, parent.Acoustics));
				}
			}
		}
		return CalculateFinalNoiseValue();
	}

	private static void GetNoiseFromRoom(Room r, Room from, Vector2 p, List<Vector2> noiseReduction, Furniture self, bool neighbor, bool forceNoise)
	{
		r = r.GetMainAtriumParentOrSelf();
		if (!NoiseVisit.Add(r))
		{
			return;
		}
		if (r.AtriumChildren.Count > 0)
		{
			foreach (Room item in r.GetAtriumChildrenAndSelf())
			{
				SubGetNoiseFromRoom(item, from, p, noiseReduction, self, neighbor, forceNoise);
			}
			return;
		}
		SubGetNoiseFromRoom(r, from, p, noiseReduction, self, neighbor, forceNoise);
	}

	private static void SubGetNoiseFromRoom(Room r, Room from, Vector2 p, List<Vector2> noiseReduction, Furniture self, bool neighbor, bool forceNoise)
	{
		float num = from.Acoustics.MapRange(0f, 1f, 2f, 1f);
		List<Furniture> furnitures = r.GetFurnitures();
		int count = furnitures.Count;
		for (int i = 0; i < count; i++)
		{
			Furniture furniture = furnitures[i];
			if (furniture.Noisiness > 0f && (forceNoise || furniture.IsOn) && furniture != self && (furniture.SnappedTo == null || furniture.SnappedTo.Parent != self) && Mathf.Abs(furniture.OriginalPosition.x - p.x) < furniture.Noisiness * num && Mathf.Abs(furniture.OriginalPosition.z - p.y) < furniture.Noisiness * num)
			{
				Vector2 vector = furniture.OriginalPosition.FlattenVector3();
				float num2 = furniture.Noisiness * CalculateNoiseReduction(p, vector, noiseReduction);
				if (neighbor)
				{
					num2 *= GetWallFactor(p, vector, from, furniture.Parent);
				}
				if (r.Floor != from.Floor)
				{
					AddNoiseValue(CalculateNoise(num2, (p.ToVector3((float)from.Floor * 2f) - furniture.OriginalPosition).magnitude, from.Acoustics));
				}
				else
				{
					AddNoiseValue(CalculateNoise(num2, (p - vector).magnitude, from.Acoustics));
				}
			}
		}
	}

	private static float GetWallFactor(Vector2 p, Vector2 p2, Room r, Room inside)
	{
		for (int i = 0; i < r.Edges.Count; i++)
		{
			WallEdge wallEdge = r.Edges[i];
			WallEdge wallEdge2 = r.Edges[(i + 1) % r.Edges.Count];
			Vector2? lineIntersection = Utilities.GetLineIntersection(p, p2, wallEdge.Pos, wallEdge2.Pos);
			if (!lineIntersection.HasValue)
			{
				continue;
			}
			if (wallEdge.IsBalconyWall(r))
			{
				return 1f;
			}
			HashSet<WallSnap> orNull = wallEdge.Children.GetOrNull(wallEdge2);
			if (orNull != null)
			{
				float magnitude = (wallEdge.Pos - lineIntersection.Value).magnitude;
				foreach (RoomSegment item in orNull.OfType<RoomSegment>())
				{
					float num = item.WallPosition[wallEdge];
					float num2 = num + item.WallWidth / 2f;
					num -= item.WallWidth / 2f;
					if (magnitude > num && magnitude < num2)
					{
						if (r != inside && wallEdge2.GetRoom(wallEdge) != inside)
						{
							break;
						}
						return item.NoiseFactor * (item.Height2 - item.Height1) / 2f;
					}
				}
			}
			return WallIsolation;
		}
		return 0f;
	}

	public static float CombineNoises(float environmentNoise, float actorNoise)
	{
		float num = Mathf.Max(environmentNoise, actorNoise);
		if (num > 0f)
		{
			float num2 = environmentNoise / num * environmentNoise;
			float num3 = actorNoise / num * actorNoise;
			return Mathf.Clamp01(num2 + num3);
		}
		return 0f;
	}

	public List<Actor> GetNeighbours()
	{
		List<Actor> list = new List<Actor>();
		HashList<Furniture> furniture = Parent.GetFurniture("Computer");
		if (furniture.Count > 1)
		{
			Vector2 vector = OriginalPosition.FlattenVector3();
			List<Vector2> noiseReduction = GetNoiseReduction(OriginalPosition.FlattenVector3(), Parent, null, 3.5f);
			foreach (Furniture item in furniture)
			{
				if (!(item != this))
				{
					continue;
				}
				Vector2 vector2 = item.OriginalPosition.FlattenVector3();
				Vector2 v = vector - vector2;
				if (!(v.MaxDist() <= 3.5f) || !(v.sqrMagnitude <= 12.25f))
				{
					continue;
				}
				InteractionPoint interactionPoint = item.InteractionPoints.FirstOrDefault((InteractionPoint x) => x.UsedBy != null && x.UsedBy.AItype == AI.AIType.Employee);
				if (!(interactionPoint != null) || CheckCubicleIntersection(vector, vector2, noiseReduction))
				{
					continue;
				}
				bool flag = true;
				for (int num = 0; num < Parent.Edges.Count; num++)
				{
					Vector2 pos = Parent.Edges[num].Pos;
					Vector2 pos2 = Parent.Edges[(num + 1) % Parent.Edges.Count].Pos;
					if (Utilities.FasterLineSegmentIntersection(vector, vector2, pos, pos2))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(interactionPoint.UsedBy);
				}
			}
		}
		return list;
	}

	public void RefreshFinalNoiseValue()
	{
		FinalNoise = CombineNoises(EnvironmentNoise, ActorNoise);
	}

	public IEnumerable<Furniture> IterateSnap(Furniture stopAt = null)
	{
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = SnapPoints[i];
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture snap in snapPoint.GetAllUsedBy())
			{
				if (snap == stopAt)
				{
					continue;
				}
				yield return snap;
				foreach (Furniture item in snap.IterateSnap())
				{
					yield return item;
				}
			}
		}
	}

	public IEnumerable<Furniture> ReverseIterateSnap(Furniture stopAt = null)
	{
		SnapPoint[] snapPoints = SnapPoints;
		foreach (SnapPoint snapPoint in snapPoints)
		{
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture snap in snapPoint.GetAllUsedBy())
			{
				if (snap == stopAt)
				{
					continue;
				}
				foreach (Furniture item in snap.ReverseIterateSnap())
				{
					yield return item;
				}
				yield return snap;
			}
		}
	}

	public bool CheckCanSteal()
	{
		if (CanSteal)
		{
			return IsActuallyPlayerControlled();
		}
		return false;
	}

	public bool IsPlayerOwned()
	{
		if (!PartOfGen)
		{
			if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
			{
				if (!(Parent == null))
				{
					return Parent.IsPlayerControlled();
				}
				return true;
			}
			return true;
		}
		return false;
	}

	public bool IsPlayerControlled()
	{
		if (!PartOfGen)
		{
			if (!GameSettings.Instance.IsReferenceNull() && !GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
			{
				return InRentMode;
			}
			return true;
		}
		return false;
	}

	public override bool IsActuallyPlayerControlled()
	{
		if (!PartOfGen)
		{
			if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.RentMode)
			{
				if ((Parent == null || Parent.IsPlayerControlled()) && InRentMode)
				{
					return !PlacedInEditMode;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool CheckInRange(Vector2 p)
	{
		Vector2 vector = base.transform.position.FlattenVector3();
		float num = Mathf.Abs(p.x - vector.x);
		float num2 = Mathf.Abs(p.y - vector.y);
		if (num < MiscPotential && num2 < MiscPotential && num * num + num2 * num2 < MiscPotential * MiscPotential)
		{
			return Quaternion.Angle(Quaternion.LookRotation((p - vector).ToVector3(0f)), base.transform.rotation) < 45f;
		}
		return false;
	}

	public RoadSegment GetRoad(Room from)
	{
		return null;
	}

	public override string GetActualString()
	{
		return Localization.GetFurniture(GetLocalizationName(), GetDefaultName(), null)[0];
	}

	public override bool CanRectSelect()
	{
		return true;
	}

	public override Vector3 GetSelectPosition()
	{
		if (CustomHeight)
		{
			return base.transform.position;
		}
		return base.transform.position + new Vector3(0f, (OffsetHeight(0) + OffsetHeight(1)) * 0.5f, 0f);
	}

	public override IEnumerable<Renderer> GetHighlights()
	{
		for (int i = 0; i < Colorable.Count; i++)
		{
			yield return Colorable[i];
		}
	}

	public bool AnyUnitsLeft()
	{
		if (Capacity != 0)
		{
			return GetStockLeft() > 0;
		}
		return true;
	}

	public void SubtractUnit()
	{
		if (_unitStock == null)
		{
			return;
		}
		for (int i = 0; i < _unitStock.Count; i++)
		{
			FurnitureStock furnitureStock = _unitStock[i];
			if (furnitureStock.Amount > 0)
			{
				furnitureStock.Amount--;
				if (furnitureStock.Amount == 0 && _unitStock.Count > 1)
				{
					_unitStock.RemoveAt(i);
				}
				break;
			}
		}
	}

	public void AddStock()
	{
		if (_unitStock == null)
		{
			_unitStock = new List<FurnitureStock>
			{
				new FurnitureStock(1)
			};
		}
		else if (_unitStock.Count > 0)
		{
			_unitStock.Last().Amount++;
		}
		else
		{
			_unitStock.Add(new FurnitureStock(1));
		}
	}

	public float Restock(bool perish, bool pay)
	{
		float num = 0f;
		SDateTime t = SDateTime.Now();
		if (perish && _unitStock != null)
		{
			if (t.Day == 0)
			{
				Waste = 0f;
			}
			for (int i = 0; i < _unitStock.Count; i++)
			{
				FurnitureStock furnitureStock = _unitStock[i];
				if (!furnitureStock.Perished(Expiration, t))
				{
					break;
				}
				if (pay && UnitCost > 0f)
				{
					num += (float)furnitureStock.Amount * UnitCost / (float)GameSettings.DaysPerMonth;
				}
				if (_unitStock.Count > 1)
				{
					_unitStock.RemoveAt(i);
					i--;
				}
				else
				{
					furnitureStock.Amount = 0;
				}
			}
			Waste += num;
		}
		int num2 = Capacity - GetStockLeft();
		if (num2 > 0)
		{
			if (_unitStock == null)
			{
				_unitStock = new List<FurnitureStock>();
			}
			if (_unitStock.Count == 1 && _unitStock[0].Amount == 0)
			{
				FurnitureStock furnitureStock2 = _unitStock[0];
				furnitureStock2.Amount = num2;
				furnitureStock2.Month = (byte)t.Month;
				furnitureStock2.Year = t.Year;
			}
			else if (_unitStock.Count > 0)
			{
				FurnitureStock furnitureStock3 = _unitStock.Last();
				if (furnitureStock3.Month == t.Month && furnitureStock3.Year == t.Year)
				{
					furnitureStock3.Amount += num2;
				}
				else
				{
					_unitStock.Add(new FurnitureStock(num2));
				}
			}
			else
			{
				_unitStock.Add(new FurnitureStock(num2));
			}
			if (pay)
			{
				GameSettings.Instance.MyCompany.MakeTransaction((float)(-num2) * UnitCost / (float)GameSettings.DaysPerMonth, Company.TransactionCategory.Bills, true, "Coffee".Equals(Type) ? "Coffee" : "Food");
			}
		}
		return num;
	}

	public override TemperatureGroup GetTempGroup()
	{
		return TempGroup;
	}

	public override TemperatureGroup.TempType GetTempType()
	{
		if (TempControlType != TemperatureType.Cooling)
		{
			return TemperatureGroup.TempType.Heat;
		}
		return TemperatureGroup.TempType.Cool;
	}

	public override string GetPanelActionName()
	{
		if (TemperatureController && TempGroup != null && !GameSettings.Instance.HasDanger())
		{
			return "AutoBuyTempFurn";
		}
		if (RefillCapacity && IsActuallyPlayerControlled() && Capacity > 0 && GetStockLeft() < Capacity)
		{
			return "Refill";
		}
		if ("DogBed".Equals(Type))
		{
			return "FindFriend";
		}
		if ("HardwareDisplay".Equals(Type))
		{
			return "Details";
		}
		return null;
	}

	public override string GetPanelActionTip(ref float sum)
	{
		if (TemperatureController && TempGroup != null && !GameSettings.Instance.HasDanger() && TempGroup != null)
		{
			sum += TempGroup.Rooms.SumSafe((Room x) => x.GetAtriumArea());
			return sum + " m2";
		}
		if (RefillCapacity && IsActuallyPlayerControlled() && Capacity > 0)
		{
			int stockLeft = GetStockLeft();
			if (stockLeft < Capacity)
			{
				sum += (float)(Capacity - stockLeft) * UnitCost / (float)GameSettings.DaysPerMonth;
				return sum.Currency();
			}
		}
		return null;
	}

	public override void InvokePanelAction(List<UndoObject.UndoAction> undos)
	{
		if (TemperatureController && TempGroup != null && !GameSettings.Instance.HasDanger())
		{
			string key = ((TempControlType == TemperatureType.Cooling) ? "Ventilation" : "Radiator");
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(key);
			FurnitureAutoPlacement.PlacementAlgorithm placementAlgorithm = FurnitureAutoPlacement.AutoPlacementFunctions[key];
			{
				foreach (Room item in TempGroup.Rooms.Where((Room x) => x.GetFurniture("Computer").Count > 0 || x.GetFurniture("Desk").Count > 0))
				{
					List<FurnitureAutoPlacement.PlacementData> list = placementAlgorithm.F(furnitureComponent, item, Quaternion.identity);
					for (int num = 0; num < list.Count; num++)
					{
						FurnitureAutoPlacement.PlacementData placementData = list[num];
						bool inventory;
						Furniture furniture = FurnitureBuilder.MakeFurn(placementData.P, placementData.R, item, placementData.E1, placementData.E2, placementData.WallPos, false, null, furnitureComponent.gameObject, 0f, false, out inventory);
						item.AddFurniture(furniture);
						furniture.UpdateBoundaryPoints();
						furniture.InitLOD();
						undos.Add(new UndoObject.UndoAction(furniture, true, inventory));
					}
				}
				return;
			}
		}
		if (RefillCapacity && IsActuallyPlayerControlled() && Capacity > 0)
		{
			Restock(false, true);
		}
		else
		{
			if (!"HardwareDisplay".Equals(Type))
			{
				return;
			}
			HardwareDesignFurn component = GetComponent<HardwareDesignFurn>();
			if (!(component != null))
			{
				return;
			}
			SoftwareProduct product = MarketSimulation.Active.GetProduct(component.ProductID, false);
			if (product == null)
			{
				return;
			}
			if (component.AddonID != 0)
			{
				AddOnProduct addon = product.GetAddon(component.AddonID);
				if (addon != null)
				{
					HUD.Instance.GetProductWindow(null).ShowAddonDetails(addon);
				}
			}
			else
			{
				HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
			}
		}
	}

	public override void FinalizePanelAction(string action, List<UndoObject.UndoAction> undos)
	{
		if (!"AutoBuyTempFurn".Equals(action))
		{
			return;
		}
		if (undos.Count > 0)
		{
			float x = undos.SumSafe((UndoObject.UndoAction undoAction) => undoAction.BalanceDiff);
			WindowManager.Instance.ShowMessageBox("AutoBuyTempFurnSucc".Loc(undos.Count, x.Currency()), true, DialogWindow.DialogType.Information);
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("AutoBuyTempFurnFail".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	public override Selectable PanelActionDivert()
	{
		if (TempGroup != null)
		{
			return ((TempControlType == TemperatureType.Cooling) ? TempGroup.Coolers.FirstOrDefault() : TempGroup.Heaters.FirstOrDefault()) ?? this;
		}
		return this;
	}

	public bool IsUnlocked(bool ignoreTasks = false)
	{
		if (AvailableMonth > 0 && AvailableMonth != DateTime.Now.Month)
		{
			return false;
		}
		if (GameSettings.Instance.CampaignMode && !GameSettings.Instance.EditMode && ((!string.IsNullOrEmpty(UnlockMission) && !GameSettings.HasCompletedOrInMission(UnlockMission)) || !IsPurchasable() || !IsPlayerControlled()))
		{
			return false;
		}
		if (!ignoreTasks && !string.IsNullOrEmpty(Unlockable))
		{
			return GameSettings.Instance.HasClaimedReward(Unlockable);
		}
		return true;
	}

	public bool IsPurchasable()
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.Instance.EditMode || Cheats.UnlockFurn)
		{
			return true;
		}
		if (!GameSettings.Instance.AllowModdedFurniture && FileName != null)
		{
			return false;
		}
		if (TimeOfDay.Instance.Year + 1900 < UnlockYear)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(UnlockMission) && !GameSettings.HasCompletedOrInMission(UnlockMission))
		{
			return false;
		}
		return true;
	}

	public override Renderer[] GetHighlightRenders()
	{
		return Children;
	}

	public override bool PunchHole()
	{
		if (WallFurn && PokesThroughWall)
		{
			return PunchHoleThroughWall;
		}
		return false;
	}

	public override bool TowardsOutside()
	{
		if (WallFurn && PokesThroughWall)
		{
			if (!(Parent == null))
			{
				return ExtraParent == null;
			}
			return true;
		}
		return false;
	}

	public override Room GetParentRoom(bool first)
	{
		if (!first)
		{
			return ExtraParent;
		}
		return Parent;
	}

	public void UpdateElevatorDisplay()
	{
		if (ElevatorDisplay.Length != 0)
		{
			int floor = ((EGroup == null) ? GetFloor() : EGroup.CurrentFloor);
			int move = ((EGroup != null) ? Utilities.Sign(EGroup.TargetFloor - EGroup.CurrentFloor) : 0);
			int inTransit = ((EGroup != null) ? EGroup.InTransit.Count : 0);
			UpdateElevatorDisplay(floor, move, inTransit);
		}
	}

	public void UpdateElevatorDisplay(int floor, int move, int inTransit)
	{
		if (ElevatorDisplay.Length != 0 && this != null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			if (floor < 0)
			{
				materialPropertyBlock.SetVector("_Offset", IToUV(18));
				ElevatorDisplay[0].SetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetVector("_Offset", IToUV(Mathf.Abs(floor) % 10));
				ElevatorDisplay[1].SetPropertyBlock(materialPropertyBlock);
			}
			else
			{
				int i = floor % 10;
				int i2 = floor / 10 % 10;
				materialPropertyBlock.SetVector("_Offset", IToUV(i2));
				ElevatorDisplay[0].SetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetVector("_Offset", IToUV(i));
				ElevatorDisplay[1].SetPropertyBlock(materialPropertyBlock);
			}
			if (CanExitElevator)
			{
				int num = Mathf.CeilToInt((float)inTransit * 4f / (float)Capacity);
				materialPropertyBlock.SetVector("_Offset", IToUV(num + 10));
			}
			else
			{
				materialPropertyBlock.SetVector("_Offset", IToUV(19));
			}
			ElevatorDisplay[2].SetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetVector("_Offset", IToUV(move + 16));
			ElevatorDisplay[3].SetPropertyBlock(materialPropertyBlock);
		}
	}

	private static Vector4 IToUV(int i)
	{
		int num = i % 4;
		return new Vector4(y: 1f - (float)(i / 4 + 1) / 8f, x: (float)num / 4f, z: 0.25f, w: 0.125f);
	}

	public override void ToggleDoors(bool open, bool keepOpen, bool force = false)
	{
		for (int i = 0; i < ElevatorDoors.Length; i++)
		{
			if (open)
			{
				ElevatorDoors[i].DoorCollision(true, !keepOpen, force);
			}
			else
			{
				ElevatorDoors[i].CloseNow(force);
			}
		}
	}

	public bool AllowExit()
	{
		return CanExitElevator;
	}

	public bool AllowEntry()
	{
		return CanEnterElevator;
	}

	public float OffsetHeight(int i)
	{
		return ((i == 0) ? Height1 : Height2).OffsetHeight(OriginalPosition.y, Floor);
	}

	public override bool SelectableThroughWall()
	{
		if (WallFurn)
		{
			if (!PokesThroughWall)
			{
				return PunchHoleThroughWall;
			}
			return true;
		}
		return false;
	}

	public override bool IsOnSide(WallEdge w)
	{
		if (PokesThroughWall)
		{
			return true;
		}
		return (FirstEdge == w) ^ ReverseWallSide;
	}

	public void UndoDestroyWithChildren(List<UndoObject.UndoAction> undos, bool first = true)
	{
		if ((first || this.IsAliveNotNull()) && undos != null)
		{
			undos.Add(new UndoObject.UndoAction(this, false));
			DestroyGO();
		}
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			if (SnapPoints[i].UsedByCount > 0)
			{
				SnapPoints[i].ForEachUsed(delegate(Furniture x)
				{
					x.UndoDestroyWithChildren(undos, false);
				});
			}
		}
	}

	public void UndoDestroyWithChildren(List<UndoObject.UndoAction> undos, Dictionary<WallSnap, UndoObject.UndoAction> undoItems)
	{
		for (int i = 0; i < SnapPoints.Length; i++)
		{
			if (SnapPoints[i].UsedByCount > 0)
			{
				SnapPoints[i].ForEachUsed(delegate(Furniture x)
				{
					x.UndoDestroyWithChildren(undos, undoItems);
				});
			}
		}
		UndoObject.UndoAction value;
		if (this.IsAliveNotNull() && undoItems.TryGetValue(this, out value))
		{
			undos.Add(value);
			DestroyGO();
		}
	}

	public FurnitureBuilder.AtriumType GetAtriumType()
	{
		if (AtriumFixture)
		{
			if (_hasAtriumObject)
			{
				if (!ReverseAtriumScale)
				{
					return FurnitureBuilder.AtriumType.Up;
				}
				return FurnitureBuilder.AtriumType.Down;
			}
			return FurnitureBuilder.AtriumType.Ignore;
		}
		return FurnitureBuilder.AtriumType.None;
	}

	public Bounds GetBounds(bool precise)
	{
		float num = base.transform.position.y + Height1;
		float num2 = base.transform.position.y + Height2;
		float num3 = base.transform.position.x - 1f;
		float num4 = base.transform.position.z - 1f;
		float num5 = base.transform.position.x + 1f;
		float num6 = base.transform.position.z + 1f;
		if (precise && MeshBoundary != null && MeshBoundary.Length != 0)
		{
			Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			num3 = float.MaxValue;
			num4 = float.MaxValue;
			num5 = float.MinValue;
			num6 = float.MinValue;
			for (int i = 0; i < MeshBoundary.Length; i++)
			{
				Vector2 vector = localToWorldMatrix.MultiplyPoint(MeshBoundary[i].ToVector3(0f)).FlattenVector3();
				num3 = Mathf.Min(num3, vector.x);
				num4 = Mathf.Min(num4, vector.y);
				num5 = Mathf.Max(num5, vector.x);
				num6 = Mathf.Max(num6, vector.y);
			}
		}
		Rect rect = new Rect(num3, num4, num5 - num3, num6 - num4);
		return new Bounds(rect.center.ToVector3((num + num2) * 0.5f), rect.size.ToVector3(num2 - num));
	}

	public override bool IsCustomizable()
	{
		if (!Type.Equals("Award"))
		{
			return base.IsCustomizable();
		}
		return false;
	}

	public bool Queryable()
	{
		if (!Deprecated)
		{
			return !OnlyInEditor;
		}
		return false;
	}

	public override void UpdateStyleNetwork()
	{
		if (base.NetworkID != 0 && (AtlasObject != null || ColorPrimaryEnabled || ColorSecondaryEnabled || ColorTertiaryEnabled))
		{
			NetworkMessaging.SendObjectStyle(base.NetworkID, IsNetworkIDLocal(), null, null, ColorPrimaryEnabled ? base.ColorPrimary : Color.black, ColorSecondaryEnabled ? base.ColorSecondary : Color.black, ColorTertiaryEnabled ? base.ColorTertiary : Color.black, Color.black, base.AtlasIndex, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public override bool IsNetworkIDLocal()
	{
		return !PartOfGen;
	}

	public override bool IsNetworkIDLocal(WriteDictionary d)
	{
		return !d.Get("PartOfGen", false);
	}

	public void AddToInventory(List<UndoObject.UndoAction> undos)
	{
		if (undos != null)
		{
			undos.Add(new UndoObject.UndoAction(this, false, true));
		}
		Undo = true;
		GameSettings.AddToInventory(this);
	}

	public void ImprintSnapPointOffset(SnapPoint relativeTo)
	{
		if (relativeTo != null)
		{
			SnapPointOffset = relativeTo.transform.rotation.Invert() * (OriginalPosition - relativeTo.GetRealPos());
		}
	}

	public TrashCan GetTrashCan()
	{
		Vector2 vector = base.transform.position.FlattenVector3();
		if (_connectedCan == null || _connectedCan.Furn.Parent != Parent || (_connectedCan.transform.position.FlattenVector3() - vector).sqrMagnitude >= 12.25f || _connectedCan.IsFull())
		{
			HashList<Furniture> furniture = Parent.GetFurniture("Trashcan");
			for (int i = 0; i < furniture.Count; i++)
			{
				TrashCan component;
				if ((furniture[i].transform.position.FlattenVector3() - vector).sqrMagnitude < 12.25f && furniture[i].TryGetComponent<TrashCan>(out component) && !component.IsFull())
				{
					_connectedCan = component;
					break;
				}
			}
		}
		return _connectedCan;
	}
}
