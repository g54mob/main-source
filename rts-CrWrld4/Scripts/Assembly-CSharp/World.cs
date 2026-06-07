using System;
using System.Collections.Generic;
using System.Threading;
using NBT.Tags;
using UnityEngine;

public class World
{
	public class BreederStruct
	{
		public enum TYPE
		{
			EMPTY = 0,
			BREEDER_CREEPER = 1,
			BREEDER_AC = 2,
			FLIP_BREEDER = 3,
			ABSORBER = 4,
			MESH = 5,
			SHATTERED_LAND = 6,
			CONTAMINANT = 7,
			CORRUPTION = 8,
			RESOURCE = 9
		}

		public int DUTY_ON;

		public int DUTY_OFF;

		public int MIN;

		public int MAX;

		public int RATE;

		public int ACMIN;

		public int ACMAX;

		public int ACRATE;

		public byte DECAY_LEVEL;

		public byte DECAY_MIN_HEIGHT;

		public string title;

		public int ACTUAL_RATE;

		public int ACTUAL_MAX;

		public TYPE type;

		public BreederStruct(TYPE type, string title, int DUTY_ON, int DUTY_OFF, int MIN, int MAX, int RATE, int ACMIN, int ACMAX, int ACRATE, byte DECAY_LEVEL, byte DECAY_MIN_HEIGHT)
		{
		}

		public BreederStruct Clone()
		{
			return null;
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public class MissionObjectiveData
	{
		public bool required;

		public bool enabled;

		public int count;

		public int time;

		public bool timeStop;

		public string customName;

		public bool complete;

		public bool failed;

		public int extra;

		public int completionTime;

		public int completionEco;

		public int completionUnitsBuilt;

		public int completionUnitsLost;

		public long acquiredTimestamp;

		public bool IsComplete()
		{
			return false;
		}

		public static byte GetByte(bool obj0, bool obj1, bool obj2, bool obj3, bool obj4, bool obj5)
		{
			return 0;
		}

		public static void ParseByte(byte b, out bool obj0, out bool obj1, out bool obj2, out bool obj3, out bool obj4, out bool obj5)
		{
			obj0 = default(bool);
			obj1 = default(bool);
			obj2 = default(bool);
			obj3 = default(bool);
			obj4 = default(bool);
			obj5 = default(bool);
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public enum MISSION_OBJECTIVE_TYPE
	{
		NULLIFY = 0,
		TOTEM = 1,
		RECLAIM = 2,
		HOLD = 3,
		COLLECT = 4,
		CUSTOM = 5
	}

	public enum PROCESS_PIXELS_METHOD
	{
		Average = 0,
		Max = 1,
		Min = 2
	}

	public int RUNNINGCREEPER_SMOOTH;

	public const int MAX_LAND_HEIGHT = 20;

	public static int SECTOR_CELL_WIDTH;

	public static int SECTOR_CELL_HEIGHT;

	public static int WORLD_SECTOR_WIDTH;

	public static int WORLD_SECTOR_HEIGHT;

	public static int WORLD_CELL_WIDTH;

	public static int WORLD_CELL_HEIGHT;

	public static int ACTION_MAP_CELL_WIDTH;

	public static int ACTION_MAP_CELL_HEIGHT;

	public static int ACTION_MAP_WIDTH;

	public static int ACTION_MAP_HEIGHT;

	public static int BIGBLOCK_MAP_CELL_WIDTH;

	public static int BIGBLOCK_MAP_CELL_HEIGHT;

	public static int BIGBLOCK_MAP_WIDTH;

	public static int BIGBLOCK_MAP_HEIGHT;

	public int MIN_CREEPER;

	public static float CREEPER_TRANSFER_MUL_RL_BASE;

	public static float CREEPER_TRANSFER_MUL_UD_BASE;

	public static float CREEPER_TRANSFER_MUL_RL1_BASE;

	public static float CREEPER_TRANSFER_MUL_UD1_BASE;

	public float CREEPER_TRANSFER_MULTIPLIER;

	public float CREEPER_TRANSFER_MUL_RL;

	public float CREEPER_TRANSFER_MUL_UD;

	public float CREEPER_TRANSFER_MUL_RL1;

	public float CREEPER_TRANSFER_MUL_UD1;

	public int BREEDER_MIN;

	public int BREEDER_MAX;

	public int BREEDER_RATE;

	public int AC_BREEDER_MIN;

	public int AC_BREEDER_MAX;

	public int AC_BREEDER_RATE;

	public int PURGE_RATE;

	public int PURGE_DELAY;

	public int PURGE_ACTIVE_TIME;

	public int purgeActiveCount;

	public int BREEDER_DUTY_ON;

	public int BREEDER_DUTY_OFF;

	public int AC_BREEDER_DUTY_ON;

	public int AC_BREEDER_DUTY_OFF;

	public BreederStruct BREEDER1;

	public BreederStruct BREEDER2;

	public BreederStruct BREEDER3;

	public BreederStruct BREEDER4;

	public BreederStruct BREEDER5;

	public BreederStruct BREEDER6;

	public BreederStruct BREEDER7;

	public BreederStruct BREEDER8;

	public BreederStruct BREEDER9;

	public BreederStruct BREEDER10;

	public static int VOID_VALUE;

	public static int DIGITALIS_CREEPER_DEPTH;

	public float CREEPER_WAVE_TRANSFER;

	public int CREEPER_WAVE_TRANSFERCAP;

	public int CREEPER_STAIN_FLOW_THRESHOLD;

	public int CREEPER_STAIN_EVAP;

	public int CREEPER_STAIN_FLOW;

	public static int TERRAIN_DECAY_RATE;

	public static int CORRUPTION_RATE;

	public int WALL_DECAY;

	public static Color mistCreeperColor;

	public static Color mistAntiCreeperColor;

	public byte[] terrain;

	public bool[] terrainSlice;

	public int legalUnitLocationCount;

	public bool[] legalUnitLocations;

	public bool useLegalUnitLocations;

	private short[] defogTerrain;

	private short[] fogTerrain;

	public bool[] isFogTerrain;

	public float[] actionMap;

	private byte[] lastRecorderData;

	public byte[] creeperState;

	public int[] creeper;

	public int[] creeperShadow;

	public int[] runningCreeper;

	public long[] mainDamageMap;

	public int[] creeperStain;

	public int[] mXFields;

	public int[] mYFields;

	public CreeperSector[] creeperSectors;

	public int[] fieldsCreeperRL;

	public int[] fieldsCreeperUD;

	public int[] fieldsACRL;

	public int[] fieldsACUD;

	public short[] pinFieldsCreeper;

	public short[] pinFieldsAC;

	public int globalFieldCreeperRL;

	public int globalFieldCreeperUD;

	public int globalFieldACRL;

	public int globalFieldACUD;

	public int[] resistors;

	public int[] powerZone;

	public HashSet<int>[] desiredPowerZone;

	public bool[] platform;

	public int[] pseudoTerrain;

	public int[] overrideTerrain;

	public List<int>[] individualPseudoTerrains;

	public int[] shieldsVisible;

	public List<int>[] individualShieldsVisible;

	public byte[] creeperFlowConstants;

	public int[] terraformLevels;

	public int[] partialTerraform;

	public int[] terrainDecay;

	public byte[] terrainDecayLevels;

	public byte[] terrainDecayMinHeights;

	public byte[] terrainBreederLevels;

	public Digitalis digitalis;

	public HashSet<UnitManager>[] forbTargetMap;

	public List<AirSacBubble>[] asbArray;

	public float objectiveReclaimRatio;

	public int objectiveReclaimThreshold;

	public float creeperCutoffMax;

	public int maxEggs;

	public int eggPayload;

	public float eggBrave;

	public int eggBraveInterval;

	public int eggBraveMaxPickup;

	public bool enableMapPan;

	public bool enableMapZoom;

	public bool enableMapRotation;

	public bool terraformingOn;

	public bool deconOn;

	public bool soylentOn;

	public bool canMoveUnits;

	public bool minimapAvailable;

	public bool creeperGraphAvailable;

	public bool departButtonAvailable;

	public bool unitsSelectable;

	public bool canOverloadNullifiers;

	public int soylentDeployDelay;

	public int soylentDeployCount;

	public float statEnergyGeneration;

	public float statEnergyUse;

	public float statEnergyStore;

	public float statEnergyEco;

	public float statEnergyBonus;

	public int progressiveGraceTime;

	public int progressiveMax;

	public int progressiveNullifierOffLevel;

	private int _progressiveIncreaseTime;

	public int dominationValue;

	public int dominationBaseRate;

	public static string[] MISSION_OBJECTIVE_NAMES;

	public static int MISSION_OBJECTIVE_COUNT;

	public MissionObjectiveData[] missionObjectives;

	private TerrainTheme _currentTerrainTheme;

	public int maxCreeper;

	public int minCreeper;

	public int maxCreeperLoc;

	public int minCreeperLoc;

	public int maxAC;

	public int minAC;

	public int maxACLoc;

	public int minACLoc;

	public int maxCreeperWD;

	public int minCreeperWD;

	public int maxCreeperLocWD;

	public int minCreeperLocWD;

	public System.Random random;

	private int _backgroundPlanet;

	private Color _backgroundPlanetColor;

	private float _backgroundPlanetColorIntensity;

	private bool _backgroundPlanetFlow;

	[NonSerialized]
	public bool ignoreMVerse;

	public static int RECORD_INTERVAL;

	private ManualResetEvent resetEvent;

	private List<Thread> threads;

	private int currentSectorForThread;

	private int completionCounter;

	private Signaller signaller;

	private object _lock;

	private bool exitAllThreads;

	private WaitCallback[] threadCallbacks;

	private int threadCounter;

	private byte[] generatedMapData;

	private static HashSet<int> openHashSet;

	private static HashSet<int> closedHashSet;

	public int progressiveIncreaseTime
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public TerrainTheme currentTerrainTheme
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int backgroundPlanet
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Color backgroundPlanetColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public float backgroundPlanetColorIntensity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool backgroundPlanetFlow
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float GetCreeperCutoffMax(bool includeProgressive)
	{
		return 0f;
	}

	public bool IsMissionObjectiveComplete(int objective)
	{
		return false;
	}

	public bool IsMissionObjectiveFailed(int objective)
	{
		return false;
	}

	public void UpdateMissionObjectiveData(int objective)
	{
	}

	public void CleanObjectives()
	{
	}

	public void AcquireMissionObjective(int objective, bool showPopup = true)
	{
	}

	public void FailMissionObjective(int objective, bool showPopup = true)
	{
	}

	public bool IsMissionComplete()
	{
		return false;
	}

	public void SetCreeperTransferMultiplier(float val)
	{
	}

	public void SetCurrentTerrainTheme(int builtInTheme, TerrainTheme customTheme)
	{
	}

	public void RefreshTerrainTheme()
	{
	}

	public void Init()
	{
	}

	~World()
	{
	}

	public static BreederStruct GetBreederStruct(byte breederLevel)
	{
		return null;
	}

	public static void SetBreederStruct(byte breederLevel, BreederStruct bs)
	{
	}

	public void Cleanup()
	{
	}

	public HashSet<UnitManager> GetForbTargetMap(int cellX, int cellY)
	{
		return null;
	}

	public int GetForbTargetMapCount(int cellX, int cellY)
	{
		return 0;
	}

	public void AddToForbTargetMap(int cellX, int cellY, UnitManager b)
	{
	}

	public void RemoveFromForbTargetMap(int cellX, int cellY, UnitManager b)
	{
	}

	public void GetTerrainDecayInfo(int x, int y, out byte decayLevel, out byte minHeight)
	{
		decayLevel = default(byte);
		minHeight = default(byte);
	}

	public void SetTerrainDecayInfo(int x, int y, byte decayLevel, byte minHeight)
	{
	}

	public void SetTerrainBreederLevel(int x, int y, byte level, bool createMesh = false)
	{
	}

	public byte GetTerrainBreederLevel(int x, int y)
	{
		return 0;
	}

	public void ApplyAction(int cellX, int cellY)
	{
	}

	public int GetPowerZone(int x, int y)
	{
		return 0;
	}

	public void SetPowerZone(int x, int y, int val)
	{
	}

	public int ContainsDesiredPowerZoneCount(int x, int y)
	{
		return 0;
	}

	public bool IsDesiredPowerZoneOccupied(int x, int y, int excludeVal)
	{
		return false;
	}

	public void AddDesiredPowerZone(int x, int y, int val)
	{
	}

	public void RemoveDesiredPowerZone(int x, int y, int val)
	{
	}

	public bool GetPlatform(int x, int y)
	{
		return false;
	}

	public void SetPlatform(int x, int y, bool val)
	{
	}

	public void SetLegalUnitCell(int x, int y, bool val)
	{
	}

	public void SetAllLegalUnitCells(bool val)
	{
	}

	public bool GetLegalUnitCellIfSet(int x, int y)
	{
		return false;
	}

	public void ClearLegalUnitCells()
	{
	}

	public byte GetTerrain(int x, int y)
	{
		return 0;
	}

	public void SetTerrain(int x, int y, byte val, bool notifyUnits = false)
	{
	}

	public void SetTerrain(int x, int y, byte val, bool notifyUnits, bool allowMVerseSend)
	{
	}

	public byte GetMaxTerrain(int cx, int cy, int WIDTH, int HEIGHT)
	{
		return 0;
	}

	public void RaiseLowerTerrain(int amt)
	{
	}

	public bool GetIsFogTerrain(int x, int y)
	{
		return false;
	}

	public short GetDeFogTerrain(int x, int y)
	{
		return 0;
	}

	public void SetDeFogTerrain(int x, int y, short val)
	{
	}

	public short GetFogTerrain(int x, int y)
	{
		return 0;
	}

	public void SetFogTerrain(int x, int y, short val)
	{
	}

	public void DeleteAllCreeper(bool includeAntiCreeper, bool includeWaves)
	{
	}

	public void DeleteAllAntiCreeper(bool includeWaves)
	{
	}

	public void SetAllCreeper(int amt)
	{
	}

	public Vector3 GetCreeperVertex(int x, int y)
	{
		return default(Vector3);
	}

	public int[] GetCreeperSample(Vector3 position, int r)
	{
		return null;
	}

	public void SetCreeperSample(Vector3 position, int r, int[] sample)
	{
	}

	public int GetCreeper(int x, int y)
	{
		return 0;
	}

	public int GetRunningCreeper(int x, int y)
	{
		return 0;
	}

	public void ApplyRunningCreeper(int x, int y, int val, int weight, bool onlyLower)
	{
	}

	public void ApplyRunningCreeper(int x, int y, int val, int weight, bool onlyLower, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public void ApplyRunningCreeper(int x, int y, int val)
	{
	}

	public void SetRunningCreeper(int val, int x, int y)
	{
	}

	public int GetCreeperStain(int x, int y)
	{
		return 0;
	}

	public void SetCreeperStain(int amt, int x, int y)
	{
	}

	public void SetCreeperStain(int amt, int x, int y, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public void SetCreeper(int amt, int x, int y, bool dontLower)
	{
	}

	public void SetCreeper(int amt, int x, int y, bool dontLower, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public int AddCreeper(int x, int y, long amt, long cap)
	{
		return 0;
	}

	public int AddCreeper(int x, int y, long amt, long cap, bool allowMVerseSend, bool allowMVerseIgnore)
	{
		return 0;
	}

	public int AddCreeper(int x, int y, int amt)
	{
		return 0;
	}

	public int AddCreeper(int x, int y, int amt, bool allowMVerseSend, bool allowMVerseIgnore)
	{
		return 0;
	}

	public void ClipCreeperLine(Vector3 start, Vector3 end, int lineWidth, bool affectCreeper, bool affectAC, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public int GetMXData(int x, int y)
	{
		return 0;
	}

	public int GetMYData(int x, int y)
	{
		return 0;
	}

	public void SetMXData(int x, int y, int amt)
	{
	}

	public void SetMYData(int x, int y, int amt)
	{
	}

	public void AddMXData(int x, int y, int amt)
	{
	}

	public void AddMYData(int x, int y, int amt)
	{
	}

	public void ClearMData(int x, int y, bool suppressMVerse = false)
	{
	}

	public void SetAllMData(int xAmt, int yAmt)
	{
	}

	public int AddCreeperStain(int x, int y, int amt)
	{
		return 0;
	}

	public int GetCreeperShadow(int x, int y)
	{
		return 0;
	}

	public int GetCreeperStainShadow(int x, int y)
	{
		return 0;
	}

	public int GetResistor(int x, int y)
	{
		return 0;
	}

	public void SetResistor(int x, int y, int val)
	{
	}

	public int GetOverrideTerrain(int x, int y)
	{
		return 0;
	}

	public void SetOverrideTerrain(int x, int y, int val)
	{
	}

	public void SetOverrideTerrainOnLoad(int i, int val)
	{
	}

	public int GetPseudoTerrain(int x, int y)
	{
		return 0;
	}

	public void AddPseudoTerrain(int x, int y, int val)
	{
	}

	public void RemovePseudoTerrain(int x, int y, int val)
	{
	}

	public int GetShieldVisible(int x, int y)
	{
		return 0;
	}

	public void AddShieldVisible(int x, int y, int val)
	{
	}

	public void RemoveShieldVisible(int x, int y, int val)
	{
	}

	public void SetCreeperFlowConstant(int x, int y, bool val)
	{
	}

	public void ConvertCreeperToAC(int gX, int gY, int dist)
	{
	}

	public void ConvertCreeperToAC(int gX, int gY, int dist, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public void ConvertACToCreeper(int gX, int gY, int dist)
	{
	}

	public void ConvertACToCreeper(int gX, int gY, int dist, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public void DamageCreeper(int gX, int gY, int count, int maxDist, int amt)
	{
	}

	public void DamageCreeper(int gX, int gY, int count, int maxDist, int amt, bool followTerrain)
	{
	}

	public void DamageCreeper(int gX, int gY, int count, int maxDist, int amt, bool followTerrain, int[] damageResultMap)
	{
	}

	public void DamageCreeper(int gX, int gY, int count, int maxDist, int amt, bool followTerrain, int[] damageResultMap, bool suppressMVerse)
	{
	}

	public void AddCreeper(int x, int y, int amt, bool allowCrossOver, bool zeroExisting, bool includeCrystal, bool progressive)
	{
	}

	public void AddCreeper(int x, int y, int amt, bool allowCrossOver, bool zeroExisting, bool includeCrystal, bool progressive, bool allowMVerseSend, bool allowMVerseIgnore)
	{
	}

	public void ApplyRadialCreeperForces(int tx, int ty, int radius, float force)
	{
	}

	public void DisplaceCreeper(int tx, int ty, int radius)
	{
	}

	public void ApplyDamageMap(int gX, int gY, int maxDist, int amt, bool square)
	{
	}

	public void UpdateGameRecorder()
	{
	}

	public void GameUpdate()
	{
	}

	private void UpdateBreederRate(BreederStruct bs, float r)
	{
	}

	private void UpdateBreederRates()
	{
	}

	private void UpdateCreeperSectors()
	{
	}

	public void ExitThreads()
	{
	}

	private void CreateThreads()
	{
	}

	private void ThreadFunction()
	{
	}

	private void ThreadCall(object o_s)
	{
	}

	public bool[] FloodFillTerrain(int startCell, int minTerrainHeight, int maxTerrainHeight, int fillLimit, out List<int> list)
	{
		list = null;
		return null;
	}

	private bool CheckTerrainCell(int cell, int minTerrainHeight, int maxTerrainHeight)
	{
		return false;
	}

	public bool IsCellTerrainEdge(int cellX, int cellY)
	{
		return false;
	}

	public float GetTerrainHeight(int cx, int cy, bool includeShield)
	{
		return 0f;
	}

	public void SetTerrainInRange(int cx, int cy, byte minHeight, byte maxHeight, int radius, bool isSquare, float fillRatio, bool notifyUnits)
	{
	}

	public void SetTerrainLine(int startX, int startY, int endX, int endY, byte minHeight, byte maxHeight, int width, float fillRatio, bool notifyUnits)
	{
	}

	public bool IsCreeperCutoff(bool includeSurvive = true)
	{
		return false;
	}

	public float GetExactTerrainHeight(float x, float y)
	{
		return 0f;
	}

	public float GetExactTerrainHeight(float x, float y, out Vector3 normal)
	{
		normal = default(Vector3);
		return 0f;
	}

	public float GetExactTerrainHeight(float x, float y, bool includePseudoTerrain, bool includeShields, out bool pseudoTerrainTaller, out bool shieldTaller, out Vector3 normal)
	{
		pseudoTerrainTaller = default(bool);
		shieldTaller = default(bool);
		normal = default(Vector3);
		return 0f;
	}

	private float GetCreeperScreenHeight2(int cx, int cy, bool allowFlatten, bool ignoreAC, bool ignoreC, float zeroBias, out bool hasCreeper, out bool hasAC)
	{
		hasCreeper = default(bool);
		hasAC = default(bool);
		return 0f;
	}

	public float GetExactCreeperHeight(float x, float y, bool ignoreAC, bool ignoreC, out Vector3 normal, out bool hasCreeper, out bool hasAC)
	{
		normal = default(Vector3);
		hasCreeper = default(bool);
		hasAC = default(bool);
		return 0f;
	}

	private void SetFieldCell(int x, int z, Vector2 data, int fieldStrength, int direction, int affected, bool deploy)
	{
	}

	public void DeployRectField(int gsx, int gsz, List<RplCore.Data> data, int rWidth, int fieldStrength, int direction, int affected, bool deploy)
	{
	}

	public byte GetBrightnessForTerrain(int cellX, int cellY, float scale)
	{
		return 0;
	}

	public byte[] GetGeneratedMapData()
	{
		return null;
	}

	public byte[] GenerateTerrainDataFromImage(byte[] data, PROCESS_PIXELS_METHOD processMethod, float redAmt, float greenAmt, float blueAmt, int minHeight, int maxHeight, float alphaCutoff, int smoothAmt)
	{
		return null;
	}

	public void SetTerrainFromGeneratedData()
	{
	}

	public void SetTerrainFromGeneratedData(byte[] data)
	{
	}

	private float GetDataFromPixelBlock(Color[] pixelBlock, PROCESS_PIXELS_METHOD processMethod, float redAmt, float greenAmt, float blueAmt, int minHeight, int maxHeight, float alphaCutoff)
	{
		return 0f;
	}

	private Dictionary<int, int> SearchActionMap(int start, int goal)
	{
		return null;
	}

	private static float Hfunc(int start, int goal)
	{
		return 0f;
	}

	public List<int> PathFindActionMap(int start, int goal)
	{
		return null;
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}

	private void CalculateCreeperTotalsOnLoad()
	{
	}
}
