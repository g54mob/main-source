using System;
using System.Collections.Generic;
using ClockStone;
using NBT.Tags;
using QuickOutline;
using TMPro;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class UnitManager : MonoBehaviour, BaseUnitManager, IComparable<UnitManager>
{
	public enum MOVE_STATE
	{
		LANDED = 0,
		TAKINGOFF = 1,
		MOVING = 2,
		LANDING = 3
	}

	public enum ORIENTATION
	{
		FORWARD = 0,
		RIGHT = 1,
		BACK = 2,
		LEFT = 3
	}

	private class DamageMapData
	{
		public int cellX;

		public int cellY;

		public int maxDist;

		public int amt;

		public bool square;

		public DamageMapData()
		{
		}

		public DamageMapData(int cellX, int cellY, int maxDist, int amt, bool square)
		{
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public Material unitBuildingMaterial;

	public Material unitMaterial;

	public Material unitDisabledMaterial;

	[NonSerialized]
	public string trueGUID;

	[NonSerialized]
	public MVersePlayerPrefab mverseOwner;

	[NonSerialized]
	public int WIDTH;

	[NonSerialized]
	public int HEIGHT;

	[NonSerialized]
	public float Y_HEIGHT;

	[NonSerialized]
	public Vector3 CONNECT_OFFSET;

	[NonSerialized]
	public Vector3 FIRE_OFFSET;

	[NonSerialized]
	public int RANGE;

	[NonSerialized]
	public int BUILD_COST;

	[NonSerialized]
	public float PZ_RANGE_BOOST;

	[NonSerialized]
	public float UPGRADE_RANGE_BOOST;

	[NonSerialized]
	public Dictionary<int, int> BUILD_WARES;

	private MVerseUnit _mvu;

	[NonSerialized]
	public bool suppressAnimus;

	private bool _CONNECTABLE;

	[NonSerialized]
	public bool LOS_ENABLED;

	[NonSerialized]
	public float LOS_TARGET_HEIGHT_OFFSET;

	[NonSerialized]
	public bool LOS_ALWAYS_SHOW;

	[NonSerialized]
	public bool LOS_IGNORE_TERRAIN;

	[NonSerialized]
	public bool LOS_NEEDS_REFRESH;

	[NonSerialized]
	public float LOS_TERRAIN_HEIGHT_MOD;

	[NonSerialized]
	public Vector3 TARGET_ME_OFFSET;

	[NonSerialized]
	public bool LOS_INDIRECT;

	[NonSerialized]
	public float LOS_INDIRECT_HEIGHT_OFFSET;

	[NonSerialized]
	public float LOS_START_DIST_BIAS;

	[NonSerialized]
	public float MAX_AMMO;

	[NonSerialized]
	public Dictionary<int, int> AMMO_WARES;

	[NonSerialized]
	public float MAX_HEALTH;

	[NonSerialized]
	public bool CAN_MOVE;

	[NonSerialized]
	public bool CREEPER_DAMAGES_ONLY_ON_HEIGHT;

	[NonSerialized]
	public bool MOVE_IGNORE_LAND;

	[NonSerialized]
	public bool ONLY_ON_RESOURCE;

	[NonSerialized]
	public bool AVOID_CONTAMINANT;

	[NonSerialized]
	public bool IGNORE_FOG;

	[NonSerialized]
	public bool ONLY_ON_VOID;

	[NonSerialized]
	public bool ALLOW_PLATFORM;

	[NonSerialized]
	public bool AVOID_MESH;

	[NonSerialized]
	public bool CREATE_FOOTPRINT;

	[NonSerialized]
	public bool START_BUILDING;

	[NonSerialized]
	public bool PLAYER_CAN_DESTROY;

	[NonSerialized]
	public bool CREEPER_DAMAGES;

	[NonSerialized]
	public bool ANTICREEPER_DAMAGES;

	[NonSerialized]
	public bool CAN_STUN;

	[NonSerialized]
	public bool FLYING_UNIT;

	[NonSerialized]
	public bool DESTROY_ON_UNEVEN_TERRAIN;

	[NonSerialized]
	public bool CAN_ERN;

	[NonSerialized]
	public float ERN_DOCKED_HEIGHT;

	[NonSerialized]
	public bool REQUEST_PACKETS;

	[NonSerialized]
	public bool CAN_REQUEST_AMMO;

	private bool _CAN_PASS_PACKETS;

	private bool _GROWS_MESH;

	[NonSerialized]
	public bool DRAG_SELECTABLE;

	[NonSerialized]
	public int PSEUDO_TERRAIN_HEIGHT;

	[NonSerialized]
	public bool LOG_DESTROY;

	[NonSerialized]
	public float DECREASES_COMMAND_SCORE;

	[NonSerialized]
	public bool INCLUDE_IN_GAME_RECORDER;

	[NonSerialized]
	public int SUPPLY;

	private bool _CAN_NULLIFY;

	private int _SPECIAL_TARGET;

	[NonSerialized]
	public bool suppress_move;

	[NonSerialized]
	public bool DESTROYS_TREES_PERMANENTLY;

	[NonSerialized]
	public bool SHAKE_CAMERA_ON_DESTROY;

	[NonSerialized]
	public int unitUID;

	private int _squad;

	[NonSerialized]
	public string DESTROYED_EXPLOSION;

	[NonSerialized]
	public Vector3 DESTROYED_EXPLOSION_SCALE;

	[NonSerialized]
	public string DESTROYED_SOUND;

	[NonSerialized]
	public int faction;

	[NonSerialized]
	public int searcherID;

	[NonSerialized]
	public TextMeshPro debugText;

	[NonSerialized]
	public int OSCILLATION_INTERVAL;

	private float oscillateBaseScale;

	private float oscillateAddScale;

	private int oscillateDuration;

	private int oscillationStart;

	private ERN assignedERN;

	private UnitERNIndicator uei;

	private bool _wantsERN;

	private bool _mverseErnDocked;

	private bool _ernDocked;

	protected CubeBar healthBar;

	protected CubeBar ammoBar;

	private bool _hasBuildBar;

	private bool _hasHealthBar;

	private bool _hasAmmoBar;

	private int _buildBarCubes;

	private int _healthBarCubes;

	private int _ammoBarCubes;

	[NonSerialized]
	public Color buildBarColor;

	[NonSerialized]
	public Color healthBarColor;

	[NonSerialized]
	public Color ammoBarColor;

	[NonSerialized]
	public Vector3 ammoBarPosBack;

	[NonSerialized]
	public Vector3 ammoBarPosForward;

	[NonSerialized]
	public Vector3 buildBarPosBack;

	[NonSerialized]
	public Vector3 buildBarPosForward;

	[NonSerialized]
	public Vector3 healthBarPosBack;

	[NonSerialized]
	public Vector3 healthBarPosForward;

	public static int CONNECT_RANGE;

	[NonSerialized]
	public int _SHIELD_RANGE;

	[NonSerialized]
	public int fieldStrength;

	[NonSerialized]
	public int CF1_RANGE;

	[NonSerialized]
	public float LANDING_SPEED;

	[NonSerialized]
	public float MOVE_SPEED;

	[NonSerialized]
	public float CREEPER_DAMAGE_AMT;

	[NonSerialized]
	public float HEAL_RATE;

	[NonSerialized]
	public int PACKET_REQUEST_RATE;

	[NonSerialized]
	public int PACKET_WARE_REQUEST_RATE;

	[NonSerialized]
	public int PACKET_REQUEST_QUELL;

	private int _SET_PACKET_REQUEST_RATE;

	[NonSerialized]
	public int updateCount;

	[NonSerialized]
	public MOVE_STATE moveState;

	private int orbitalDropTargetCellX;

	private int orbitalDropTargetCellY;

	private int orbitalStartHeight;

	private bool droppingFromOrbit;

	[NonSerialized]
	public GameObject explosionPrefab;

	protected int packetRequestSize;

	[NonSerialized]
	public Packet.PACKET_TYPE packetRequestType;

	[NonSerialized]
	public int packetRequestTime;

	[NonSerialized]
	public int assignedPackets;

	private int packetRequestDelay;

	private int packetRequestQuell;

	private int packetWareRequestQuell;

	protected int packetWareRequestSize;

	[NonSerialized]
	public Dictionary<int, int> assignedPacketWares;

	[NonSerialized]
	public int packetWareRequestTime;

	private int packetWareRequestDelay;

	private int lastWareNeededIndex;

	[NonSerialized]
	public float AMMO_REQUEST_THRESHOLD;

	[NonSerialized]
	public float AMMO_WARE_REQUEST_THRESHOLD;

	[NonSerialized]
	public float radialCreeperForceOnDestroy;

	[NonSerialized]
	public int radialCreeperDistanceOnDestroy;

	[NonSerialized]
	public bool enemy;

	[NonSerialized]
	public bool dontCountLoss;

	[NonSerialized]
	public bool impervious;

	public float selectorSizeWidth;

	public float selectorSizeHeight;

	[NonSerialized]
	public List<UnitManager> hyperPathUnits;

	[NonSerialized]
	public HashSet<UnitManager> assignedMissiles;

	private bool _dead;

	private bool shouldDestroy;

	protected bool autoShadow;

	[NonSerialized]
	public int STUN_TIME;

	public const int SUPPRESS_TIME = 30;

	[NonSerialized]
	public int suppressCount;

	[NonSerialized]
	public List<Path> paths;

	[NonSerialized]
	public MoveTarget tempMoveTarget;

	[NonSerialized]
	public List<MoveTarget> moveTargets;

	[NonSerialized]
	public List<MoveTarget> workingMoveTargets;

	[NonSerialized]
	public Vector2 deployedPosition;

	[NonSerialized]
	public ORIENTATION deployedOrientation;

	[NonSerialized]
	public int lastCellX;

	[NonSerialized]
	public int lastCellY;

	[NonSerialized]
	public int lastCellHeight;

	[NonSerialized]
	public ORIENTATION lastOrientation;

	[NonSerialized]
	public List<HyperPathBuilder> hyperPathBuilders;

	private HashSet<Beam> beams;

	[NonSerialized]
	public bool avoidCreeper;

	[NonSerialized]
	public Dictionary<int, float> waresHeld;

	[NonSerialized]
	public GraphSearch.SearchVars individualSearchVars;

	private ORIENTATION _orientation;

	private GameObject stunnedEffect;

	private int _stunnedCount;

	[NonSerialized]
	public Vector2 deployedDTPosition;

	private int deployuedDTRange;

	private int _deFogTerrainRange;

	private bool _deFogEnabled;

	private Vector2 deployedFTPosition;

	private int deployedFTWidth;

	private int deployedFTHeight;

	private int _fogTerrainWidth;

	private bool deployedFTSquare;

	private int _fogTerrainHeight;

	private bool _fogIsSquare;

	private bool _fogEnabled;

	private float _health;

	private float _ammo;

	private bool _enabled;

	private bool _armed;

	private bool _resupplied;

	private bool _isBuilding;

	private List<DamageMapData> damageMapList;

	private SelectionIndicator selectionIndicator;

	[NonSerialized]
	public bool selectable;

	private bool _selected;

	private int hoverHighlightedTime;

	protected bool shadowState2;

	private bool recorderDisabledSent;

	private bool lastIsConnected;

	[NonSerialized]
	public string UNIT_LAND_SOUND;

	[NonSerialized]
	public string UNIT_TAKEOFF_SOUND;

	[NonSerialized]
	public string UNIT_BUILD_SOUND;

	private GameObject moveIndicator;

	private bool[] losCache;

	private int losCacheRange;

	private int losCacheX;

	private int losCacheY;

	private bool losCacheDirty;

	private bool terrainChangedThisFrame;

	protected Vector2 deployedCF1Position;

	[NonSerialized]
	public Vector2 deployedShieldPosition;

	protected int deployedShieldCenterHeight;

	private bool _showShield;

	private Vector2 deployedPseudoTerrainPosition;

	private int deployedPseudoTerrainHeight;

	private ORIENTATION deployedPseudoTerrainOrientation;

	public static Vector3 NOTSETV;

	[NonSerialized]
	public int simulatedERN;

	private int[] wnarray;

	[NonSerialized]
	public bool forceAmmoRequest;

	[NonSerialized]
	public GraphSearch.SearchVars[] searchVarsA;

	private AudioObject loopingSound;

	private float loopingSoundVolume;

	private string loopingSoundName;

	protected bool mverseUnitCreated;

	private bool mverseSlaveUnitOwner;

	[NonSerialized]
	public bool mverseOwnedUnit;

	private bool userInitiatedDestroy;

	private bool dotNotLogDestroy;

	[NonSerialized]
	public bool suppressMVerse;

	protected bool skipDestroy;

	private UnitText unitText;

	private bool lastSuppressed;

	private Outline outline;

	private bool quellOutline;

	private Outline otherOutline;

	private bool quellOtherOutline;

	protected Tag lateData;

	public MVerseUnit mvu
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool CONNECTABLE
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool CAN_PASS_PACKETS
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool GROWS_MESH
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool CAN_NULLIFY
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int SPECIAL_TARGET
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int squad
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool wantsERN
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool mverseErnDocked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool ernDocked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HasBuildBar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HasHealthBar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool HasAmmoBar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int BuildBarCubes
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int HealthBarCubes
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int AmmoBarCubes
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int SHIELD_RANGE
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int SET_PACKET_REQUEST_RATE
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool dead
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual string officialName => null;

	public virtual string helpText => null;

	public ORIENTATION orientation
	{
		get
		{
			return default(ORIENTATION);
		}
		set
		{
		}
	}

	public int stunnedCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int deFogTerrainRange
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool deFogEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int fogTerrainWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int fogTerrainHeight
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool fogIsSquare
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool fogEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float health
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual float ammo
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual bool unitEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool armed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool resupplied
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool isBuilding
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int cellX
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cellY
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int cellHeight
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public virtual bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual UnitManager proxySelectObject => null;

	public bool showShield
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int CompareTo(UnitManager um)
	{
		return 0;
	}

	private void RemoveSpecialTarget(int ST)
	{
	}

	private void AddSpecialTarget(int ST)
	{
	}

	public bool HasLocalERNOnly()
	{
		return false;
	}

	private void RefreshUEI()
	{
	}

	public CubeBar GetHealthBar()
	{
		return null;
	}

	public CubeBar GetAmmoBar()
	{
		return null;
	}

	public void RefreshBars()
	{
	}

	public int GetShieldRange()
	{
		return 0;
	}

	public static int GetCellX(float x)
	{
		return 0;
	}

	public static int GetCellY(float y)
	{
		return 0;
	}

	public static int GetCellHeight(float h)
	{
		return 0;
	}

	public void ApplyDamageMapData(int cellX, int cellY, int maxDist, int amt, bool square)
	{
	}

	public void RemoveAllDamageMapData()
	{
	}

	public static ORIENTATION RotateOrientationRight(ORIENTATION orient)
	{
		return default(ORIENTATION);
	}

	public static ORIENTATION RotateOrientationLeft(ORIENTATION orient)
	{
		return default(ORIENTATION);
	}

	public static Vector3 GetVectorFromOrientation(ORIENTATION orient)
	{
		return default(Vector3);
	}

	public static Vector3 GetConnectOffset(ORIENTATION orient, Vector3 baseConnectOffset)
	{
		return default(Vector3);
	}

	public Vector3 GetConnectOffset()
	{
		return default(Vector3);
	}

	protected virtual void SetUnitMaterial()
	{
	}

	public void CreateAmmoBar()
	{
	}

	public void CreateHealthBar()
	{
	}

	public void DestroyAmmoBar()
	{
	}

	public void DestroyHealthBar()
	{
	}

	public virtual void OnMouseOver()
	{
	}

	private void HoverHighlightMoveGhosts()
	{
	}

	private void ClearHoverHighlightMoveGhosts()
	{
	}

	public void HilightPaths(int time = -1)
	{
	}

	public void UpdatePathColors()
	{
	}

	protected void SetColor(Color32 color, Mesh m)
	{
	}

	protected virtual void SetBodyShadow(bool state)
	{
	}

	public virtual IClonePack GetClonePack()
	{
		return null;
	}

	public virtual void OnEnable()
	{
	}

	public virtual void OnDisable()
	{
	}

	private void ApplySupply(bool take)
	{
	}

	public void ReassignUnitUID(int newUID)
	{
	}

	public virtual void Awake()
	{
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void GameUpdate()
	{
	}

	private void AssignERN()
	{
	}

	public void ReleaseERN()
	{
	}

	public virtual void MovedInEdit()
	{
	}

	public virtual void SetUnitConstants(string unit)
	{
	}

	public void DropFromOrbit(int targetCellX, int targetCellY)
	{
	}

	public virtual void Damage(float damage)
	{
	}

	public void SetPosition(int cellX, int cellY)
	{
	}

	public void AssignMissile(Missile m)
	{
	}

	public void UnassignMissile(Missile m)
	{
	}

	private void DeFogTerrain(bool deploy, int cx, int cy, int range, bool suppressLOSUpdate = false)
	{
	}

	private void FogTerrain(bool deploy, int cx, int cy, int width, int height, bool isSquare, bool suppressLOSUpdate = false)
	{
	}

	public bool AreBuildConditionsMet()
	{
		return false;
	}

	public void CompleteTheBuild(bool force = false)
	{
	}

	public virtual void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public virtual OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public void ApplyBuildEnergy(float amt)
	{
	}

	public void ApplyAmmo(float amt)
	{
	}

	public virtual void BuildComplete()
	{
	}

	public virtual Vector3 GetERNDockLocation(ERN ern)
	{
		return default(Vector3);
	}

	public virtual void ERNDocked(ERN ern)
	{
	}

	public static ERN FindFreeERN(Vector3 fromPos)
	{
		return null;
	}

	public static int GetAvailableERNCount()
	{
		return 0;
	}

	public virtual void OnLanded()
	{
	}

	public virtual void OnTakingOff()
	{
	}

	public float GetMinMoveHeightExpanded(int cellX, int cellY, bool forceIgnoreCreeper = false)
	{
		return 0f;
	}

	private float GetMinMoveHeight(int cellX, int cellY, bool forceIgnoreCreeper)
	{
		return 0f;
	}

	private float GetMinMoveHeight(int cellX, int cellY)
	{
		return 0f;
	}

	protected virtual void OnMoveComplete()
	{
	}

	private void HandleMove()
	{
	}

	protected void SetMoveState(MOVE_STATE s)
	{
	}

	public bool MoveToInternal(float x, float y)
	{
		return false;
	}

	public bool MoveTo(int cellX, int cellY, bool waypoint, bool ignoreTempMoveTarget = false)
	{
		return false;
	}

	public void ClearWorkingMoveTargets()
	{
	}

	protected void ClearMoveTargets()
	{
	}

	public MoveTarget GetMoveTargetFromGhost(UnitMoveGhost umg)
	{
		return null;
	}

	public void GetFinalMoveCell(out int cellX, out int cellY)
	{
		cellX = default(int);
		cellY = default(int);
	}

	public virtual void IndicateTarget(TargetIndicator ti)
	{
	}

	public virtual TargetIndicator CreateTargetIndicator()
	{
		return null;
	}

	public void DeployFootprint(bool deploy)
	{
	}

	protected virtual void DeployFootprint(bool deploy, int gsx, int gsy, ORIENTATION orient)
	{
	}

	public static void ClearScapeItems(int gsx, int gsy, int WIDTH, int HEIGHT, bool perm, bool circle = false, ORIENTATION orient = ORIENTATION.FORWARD)
	{
	}

	public void ClearScapeItems(bool perm)
	{
	}

	public void RefreshLOSCache(Vector3 start, int range, float targetHeightOffset, bool ignoreTerrain, float terrainHeightMod, bool losIndirect, float losIndirectHeightOffset, float startDistBias)
	{
	}

	public virtual void RefreshLOSCache()
	{
	}

	public static void CalculateLOSCache(bool[] losCache, Vector3 start, int range, float targetHeightOffset, bool ignoreTerrain, float terrainHeightMod, bool losIndirect, float losIndirectHeightOffset, float startDistBias)
	{
	}

	public void RemoveLOSCache()
	{
	}

	public void InvalidateLOSCache()
	{
	}

	public bool HasLOSCached(int x, int y)
	{
		return false;
	}

	public bool IsNearAnyUnitFootprint(int range, bool ignoreSelf)
	{
		return false;
	}

	public static bool IsNearAnyUnitFootprint(int cellX, int cellY, int range, UnitManager ignoreUnit)
	{
		return false;
	}

	public void Suppress()
	{
	}

	public bool IsSuppressed()
	{
		return false;
	}

	public virtual void Stun()
	{
	}

	public virtual void SetStunCount(int amt)
	{
	}

	public void StunUnitsInRange(int cx, int cy, int range)
	{
	}

	public static void StunUnitsInRangeS(int cx, int cy, int range, bool enemy, bool suppressMVerse = false)
	{
	}

	public static void NotifyUnitsOfTerrainChange(int cx, int cy, bool suppressDestroy)
	{
	}

	private static void NotifyConnectingUnitsOfTerrianChange(int cx, int cy)
	{
	}

	private void TerrainChanged(int cx, int cy)
	{
	}

	public bool CollideWithUnits(float damageAmt, bool isEnemy)
	{
		return false;
	}

	public void DeployCF1(bool deploy)
	{
	}

	private void DeployCF1(bool deploy, int gsx, int gsy)
	{
	}

	private void DeployField(int gsx, int gsy, int R, bool deploy)
	{
	}

	public void DeployShield(bool deploy)
	{
	}

	private void DeployShield(bool deploy, int gsx, int gsy)
	{
	}

	public void DeployPseudoTerrain(bool deploy, int height)
	{
	}

	private void DeployPseudoTerrain(bool deploy, int gsx, int gsy, ORIENTATION orient, int height)
	{
	}

	public virtual void DamageShield()
	{
	}

	protected bool DamageShieldCollision(float extraDist)
	{
		return false;
	}

	protected bool BounceShieldCollision(Vector3 lp, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	protected bool BounceTerrainCollision(Vector3 lp, bool includePseudoTerrain, bool includeShield, float standOff, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	public static bool BounceTerrainCollision(Vector3 position, Vector3 lp, bool includePseudoTerrain, bool includeShield, float standOff, float damping, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	public static bool BounceTrueEdgeCollision(Vector3 position, Vector3 lp, float damping, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	protected bool BounceEdgeCollision(Vector3 lp, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	public static bool BounceEdgeCollision(Vector3 pos, Vector3 lp, out Vector3 newLastPos, out Vector3 newPos)
	{
		newLastPos = default(Vector3);
		newPos = default(Vector3);
		return false;
	}

	public static void CheckCreeper(int X, int Y, int W, int H, out bool inCreeper, out bool inAC)
	{
		inCreeper = default(bool);
		inAC = default(bool);
	}

	public int GetResourceCount()
	{
		return 0;
	}

	public bool InCreeperUnconditional()
	{
		return false;
	}

	public bool InCreeper()
	{
		return false;
	}

	public bool InCreeperAny()
	{
		return false;
	}

	public bool OverLandAny()
	{
		return false;
	}

	public byte GetMaxTerrain()
	{
		return 0;
	}

	public bool InFog()
	{
		return false;
	}

	public static bool OverPowerZone(int gsx, int gsy)
	{
		return false;
	}

	public bool IsERNHeld()
	{
		return false;
	}

	private static bool CanConnectTo(UnitManager targetUnit, string sourceUnit)
	{
		return false;
	}

	private static bool CheckPath(UnitManager targetUnit, string sourceUnit, float sourceX, float sourceY, float sourceZ, bool sourceUnitIsBuilding, bool ernHeld)
	{
		return false;
	}

	public static List<UnitManager> GetPossiblePaths(string sourceUnit, float sourceX, float sourceY, float sourceZ, bool sourceUnitIsBuilding, bool ernHeld, bool isConnector)
	{
		return null;
	}

	public Path GetPathTo(UnitManager um)
	{
		return null;
	}

	private Path ConnectToUnit(UnitManager um)
	{
		return null;
	}

	public void RemovePath(Path path)
	{
	}

	public void Disconnect()
	{
	}

	private void TerminateHookup()
	{
	}

	public void HookUp()
	{
	}

	public bool IsAnyPathHyper()
	{
		return false;
	}

	public bool IsConnectedToCommandBase()
	{
		return false;
	}

	public float GetPathDistanceToCommandBase()
	{
		return 0f;
	}

	public bool IsConnectedTo(UnitManager sourceUnit)
	{
		return false;
	}

	public bool IsConnectedToAny()
	{
		return false;
	}

	public void AssignPacketWare(int wareNum)
	{
	}

	public void UnassignPacketWare(int wareNum)
	{
	}

	public void AssignPacket()
	{
	}

	public void UnassignPacket()
	{
	}

	public int GetAssignedPacketWare(int wareNum)
	{
		return 0;
	}

	public bool AreAnyAssignedPackets()
	{
		return false;
	}

	public bool RequestPacketWare()
	{
		return false;
	}

	public bool AreWaresNeeded(bool ignoreAssigned = false)
	{
		return false;
	}

	protected virtual bool AreWaresNeededOLD(out int wareTypeNeeded, out float priority, bool skipUnavailable)
	{
		wareTypeNeeded = default(int);
		priority = default(float);
		return false;
	}

	public Dictionary<int, int> GetNeededWares()
	{
		return null;
	}

	public bool IsWareNeeded(int wareNum)
	{
		return false;
	}

	public void ClearAllAmmoWaresNeeded()
	{
	}

	public virtual void AddWareHeld(int wareNum, float amt)
	{
	}

	public virtual void SetWareHeld(int wareNum, float amt)
	{
	}

	public int GetAmmoWareWanted(int wareNum)
	{
		return 0;
	}

	public void UpdateBarsFromWaresHeld(int wareNum = -1)
	{
	}

	protected virtual void RemoveWareHeld(int wareNum)
	{
	}

	public virtual void RemoveAllWaresHeld()
	{
	}

	public float GetWareHeld(int wareNum)
	{
		return 0f;
	}

	public virtual float GetWaresAvailableToDispatch(int wareNum)
	{
		return 0f;
	}

	private bool IdeallyWantsAnyPacket()
	{
		return false;
	}

	private bool IdeallyWantsPacket()
	{
		return false;
	}

	private bool IdeallyWantsPacketWare()
	{
		return false;
	}

	public bool RequestPacket()
	{
		return false;
	}

	public bool NeedsPacket()
	{
		return false;
	}

	public bool NeedsPacketWare()
	{
		return false;
	}

	public virtual bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public virtual void ApplyPacket(Packet pm)
	{
	}

	public HyperPathBuilder GetHyperPathBuilderToTarget(UnitManager um)
	{
		return null;
	}

	public static float GetMinHeight(Vector3 pos, float minHeight, int checkRadius, bool includeCreeper, bool includeAntiCreeper, bool includePseudoTerrain)
	{
		return 0f;
	}

	public static Vector3 MoveTowardsPrecise(Vector3 start, Vector3 dest, float maxDelta, float minHeight, int checkRadius, bool includeCreeper, bool includeAnticreeper, bool includePseudoTerrain)
	{
		return default(Vector3);
	}

	public static Vector3 MoveTowardsCell(Vector3 start, Vector2Int dest, float maxDelta, float minHeight, int checkRadius, bool includeCreeper, bool includeAnticreeper, bool includePseudoTerrain)
	{
		return default(Vector3);
	}

	public GraphSearch.SearchVars GetSearchVars(UnitManager root)
	{
		return null;
	}

	public void ClearAllSearchVars()
	{
	}

	public bool IsOscillatingScale()
	{
		return false;
	}

	public void OscillateScale(float baseScale, float addScale, int durationInCycles)
	{
	}

	public HashSet<Beam> GetBeams()
	{
		return null;
	}

	public void AddBeam(Beam beam)
	{
	}

	public void RemoveBeam(Beam beam)
	{
	}

	public Beam GetBeamByUID(int beamUID)
	{
		return null;
	}

	private void HandleLoopingSound()
	{
	}

	public void PlayLoopingSound(string sound, float volume)
	{
	}

	public void StopLoopingSound()
	{
	}

	public void SetMaterialAll(Material mat)
	{
	}

	public virtual void CreateMVerseUnit(string unitName, int uid, Vector3 position)
	{
	}

	public virtual void ManageMVerseSlaveUnit(string unitName, Vector3 position, ORIENTATION orientation)
	{
	}

	public virtual void DestroyUnit(bool suppressEffects, bool userInitiated, bool doNotLog)
	{
	}

	public virtual void DestroyUnit(bool suppressEffects)
	{
	}

	public void SetDebugText(string t)
	{
	}

	public void SetUnitTextOffset(Vector3 offset)
	{
	}

	public void SetUnitText(string t)
	{
	}

	public void RemoveUnitText()
	{
	}

	public UnitText GetUnitTextObj()
	{
		return null;
	}

	public void RefreshEnemyOutlineState()
	{
	}

	public void RefreshOtherOutlineState()
	{
	}

	public virtual string GetDataName()
	{
		return null;
	}

	public virtual void ReadData(Tag data)
	{
	}

	public virtual void ReadDataLate()
	{
	}

	public virtual TagCompound WriteData()
	{
		return null;
	}

	public static UnitManager CreateUnitAtPosition(string unitName, Vector3 position)
	{
		return null;
	}

	public static UnitManager CreateUnit(GameObject prefab)
	{
		return null;
	}

	public static UnitManager CreateUnit(string unitName, bool deferAwakeInScripts = false)
	{
		return null;
	}
}
