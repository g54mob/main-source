using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : GameMap
{
	public class Settings
	{
		public List<int> lastCrazySeeds;

		public int currentCrazySeedLoc;

		public short version;

		public int mapSeed;

		public int resourceSeed;

		public int enemySeed;

		public short mapWidth;

		public short mapHeight;

		public byte mapTextureTheme;

		public bool mapAlternativeNoise;

		public short mapMultiplierX;

		public short mapMultiplierY;

		public byte mapAmplitude;

		public byte mapPersistence;

		public byte mapLacunarity;

		public bool mapSeamless;

		public bool mapSmooth;

		public float creeperTransfer;

		public int creeperWaveTransferCap;

		public float creeperWaveTransfer;

		public float creeperCutoffMax;

		public int maxEggs;

		public int eggPayload;

		public float eggBrave;

		public int eggBraveInterval;

		public int eggStartTime;

		public int eggProductionInterval;

		public bool eggOnlyDuringCutoff;

		public int eggCount;

		public float eggOffensiveRatio;

		public float eggDefensiveRatio;

		public byte lowestLevelsVoid;

		public byte horizontalRidgeCount;

		public byte verticalRidgeCount;

		public short ridgeWidth;

		public byte ridgeStartHeight;

		public short ridgeSlope;

		public byte voidHorizontalRidgeCount;

		public byte voidVerticalRidgeCount;

		public short voidRidgeWidth;

		public byte mesaCount;

		public bool createParkingSpace;

		public byte parkingSpaceSize;

		public byte parkingSpaceHeight;

		public byte parkingSpaceX;

		public byte parkingSpaceY;

		public byte totemPlacement;

		public byte totemCount;

		public byte ernPlacement;

		public byte ernCount;

		public byte oreDepositPlacement;

		public byte oreDepositCount;

		public byte greenarPlacement;

		public byte greenarCount;

		public byte enemyPlacement;

		public bool includeDigitalis;

		public bool edgeBreeder;

		public byte digitalisBloomFrequency;

		public byte minDigitalisBloomSize;

		public byte maxDigitalisBloomSize;

		public byte minDigitalisTendrils;

		public byte maxDigitalisTendrils;

		public byte minDigitalisTendrilDistance;

		public byte maxDigitalisTendrilDistance;

		public byte emitterCount;

		public short minEmitterStrength;

		public short maxEmitterStrength;

		public short minEmitterInterval;

		public short maxEmitterInterval;

		public byte sporeTowerCount;

		public short minInitialSporeDelay;

		public short maxInitialSporeDelay;

		public byte minSporeCount;

		public byte maxSporeCount;

		public short minSporeWaveInterval;

		public short maxSporeWaveInterval;

		public short minSporePayload;

		public short maxSporePayload;

		public byte runnerNestCount;

		public bool createForbs;

		public byte blobNestCount;

		public float blobCarryEggRatio;

		public byte stashCount;

		public byte aETowerCount;

		public byte minAETowerSize;

		public byte maxAETowerSize;

		public byte airSacCount;

		public short panX;

		public short panY;

		public bool includeInhibitor;

		public short inhibitorX;

		public short inhibitorY;

		public byte resourcePackPlacement;

		public byte resourcePackCount;

		public byte flipBreederPlacement;

		public byte flipBreederCount;

		public static Dictionary<string, IntPair> limits;

		public void Defaults()
		{
		}

		public void Crazy(bool prev = false)
		{
		}

		public static void ReadMapSize(string data, out short mapWidth, out short mapHeight)
		{
			mapWidth = default(short);
			mapHeight = default(short);
		}

		public bool ReadEncoding(string data)
		{
			return false;
		}

		private void EnforceLimits()
		{
		}

		private void Enforce(ref int val, IntPair limits)
		{
		}

		private void Enforce(ref short val, IntPair limits)
		{
		}

		private void Enforce(ref byte val, IntPair limits)
		{
		}

		public IntPair GetLimits(string name)
		{
			return default(IntPair);
		}

		public string GetEncoding()
		{
			return null;
		}

		private static void Write(ref BitArray b, ref int loc, float val)
		{
		}

		private static void Write(ref BitArray b, ref int loc, int val)
		{
		}

		private static void Write(ref BitArray b, ref int loc, short val)
		{
		}

		private static void Write(ref BitArray b, ref int loc, byte val)
		{
		}

		private static void Write(ref BitArray b, ref int loc, bool val)
		{
		}

		private static void Read(ref BitArray b, ref int loc, out float val)
		{
			val = default(float);
		}

		private static void Read(ref BitArray b, ref int loc, out int val)
		{
			val = default(int);
		}

		private static void Read(ref BitArray b, ref int loc, out short val)
		{
			val = default(short);
		}

		private static void Read(ref BitArray b, ref int loc, out byte val)
		{
			val = default(byte);
		}

		private static void Read(ref BitArray b, ref int loc, out bool val)
		{
			val = default(bool);
		}

		private static byte[] ToByteArray(BitArray bits)
		{
			return null;
		}
	}

	private System.Random mapRand;

	private System.Random resourceRand;

	private System.Random enemyRand;

	private int seed;

	private int parkingSpaceX;

	private int parkingSpaceY;

	private Vector2 inhibitorLocation;

	private List<Vector2> emitterLocations;

	private List<Vector2> runnerNestLocations;

	private List<Vector2> blobNestLocations;

	private List<Vector2> airSacLocations;

	private List<Vector2> stashLocations;

	private List<Vector2> sporeTowerLocations;

	private List<Vector2> airExclusionTowerLocations;

	private List<Vector2> oreDepositLocations;

	private List<Vector2> greenarLocations;

	private List<Vector2> totemLocations;

	private List<Vector2> ernLocations;

	private List<Vector2> resourcePackLocations;

	private List<Vector2> flipBreederLocations;

	private bool tall;

	public const int Placement_All = 0;

	public const int Placement_Right = 1;

	public const int Placement_Top = 2;

	public const int Placement_Left = 3;

	public const int Placement_Bottom = 4;

	public Settings settings;

	public ProceduralMap(Settings s)
	{
	}

	public static void WriteMetaData(byte opt0, byte opt1, byte opt2, byte opt3, out int metaData)
	{
		metaData = default(int);
	}

	public static void ReadMetaData(int metaData, out byte opt0, out byte opt1, out byte opt2, out byte opt3)
	{
		opt0 = default(byte);
		opt1 = default(byte);
		opt2 = default(byte);
		opt3 = default(byte);
	}

	private static Settings GetSettingForOptions(string GUID, byte opt0, byte opt1, byte opt2, byte opt3)
	{
		return null;
	}

	private static Settings GetSettingForGUIDMarkV(string GUID, int metaData)
	{
		return null;
	}

	private static Settings GetSettingForGUIDSpan(string GUID)
	{
		return null;
	}

	public static Settings GetSettingsForGUID(string GUID)
	{
		return null;
	}

	private static int GetOppositePlacement(int placement)
	{
		return 0;
	}

	private static Rect GetRectForPlacement(int p, int offset, int w, int h, bool opposite = false)
	{
		return default(Rect);
	}

	private static System.Random GetRandom(string GUID, out int seed)
	{
		seed = default(int);
		return null;
	}

	private int[] LoadTextureNumbers()
	{
		return null;
	}

	public void CreateMap()
	{
	}

	private void GetLevelExtremes(out int lowestLevel, out int highestLevel)
	{
		lowestLevel = default(int);
		highestLevel = default(int);
	}

	private void SetLevelsToValue(int low, int high, byte val)
	{
	}

	private void DrawEco(int gsx, int gsy, byte ecoType)
	{
	}

	private void DrawDigitalis(int gsx, int gsy, int distance)
	{
	}

	private void DrawDigitalisLine(int startX, int startY, int endX, int endY, int startR, int endR)
	{
	}

	private void SmoothTerrain(int hc, int lc)
	{
	}

	private int HigherCount(int gsx, int gsy)
	{
		return 0;
	}

	private int LowerCount(int gsx, int gsy)
	{
		return 0;
	}

	private bool IsLower(int gsx, int gsy, int amt)
	{
		return false;
	}

	private bool IsHigher(int gsx, int gsy, int amt)
	{
		return false;
	}

	private void LevelTerrain(int gsx, int gsy, int distance)
	{
	}

	private void LevelTerrain(int gsx, int gsy, int distance, bool circle, byte terrainLevel, bool useHighestTerrain)
	{
	}

	private void CreateParkingSpace()
	{
	}

	private void CreateInhibitor()
	{
	}

	private List<int> GetLandInZone(int x, int y, int width, int height)
	{
		return null;
	}

	private List<int> GetLand(int offset, int p, bool half = false)
	{
		return null;
	}

	private Vector2 GetRandEnemyPos(List<int> land)
	{
		return default(Vector2);
	}

	private Vector2 GetRandResourcePos(List<int> land)
	{
		return default(Vector2);
	}

	private bool GetMinSurfaceArea(int startX, int startY, int min)
	{
		return false;
	}

	private void SetOccupied(Vector2 loc, int r, bool round)
	{
	}

	private void CreateEmitters()
	{
	}

	private void CreateRunnerNests()
	{
	}

	private void FindNearestDigitalis(int gameSpaceX, int gameSpaceY, out int dx, out int dy)
	{
		dx = default(int);
		dy = default(int);
	}

	private void CreateAirSacs()
	{
	}

	private void CreateSporeTowers()
	{
	}

	private void CreateAirExclusionTowers()
	{
	}

	private void CreateOreDeposits()
	{
	}

	private void CreateGreenar()
	{
	}

	private void CreateTotems()
	{
	}

	private void CreateERNs()
	{
	}

	private void CreateBlobNests()
	{
	}

	private void CreateStashes()
	{
	}

	private void CreateFlipBreeder()
	{
	}

	private int GetNewDir(int lastDir)
	{
		return 0;
	}

	private void CreateResourcePacks()
	{
	}

	private float DistanceToInhibitor(Vector2 coords)
	{
		return 0f;
	}

	private float DistantToNearestStructure(Vector2 coords)
	{
		return 0f;
	}

	private float GetDistance(Vector2 v1, Vector2 v2)
	{
		return 0f;
	}

	private void CreateRidge(bool createVoid, bool horizontal, int rw, byte startHeight, int slope)
	{
	}

	private void DrawRidgeLine(float sx, float sy, float tx, float ty, byte ridgeHeight, int ridgeWidth, bool horizontal)
	{
	}

	private void CreateBolt(float sx, float sy, float tx, float ty, float displacement, bool horizontal, List<float> result)
	{
	}

	public void CreateSpire(int x, int y, int radius, int min, int max, int levels, int inset, float irregularity, float irregularityAmplitude, bool replace, int seed)
	{
	}

	public void CreatePad(int cx, int cy, byte heightPos, int size, float irregularity, float irregularityAmplitude, bool replace, int seed)
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
}
