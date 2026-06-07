using DV.Utils;
using UnityEngine;

public class LevelInfo : SingletonBehaviour<LevelInfo>
{
	public enum WorldSpecificPrefabs
	{
		SchematicMapRender = 0,
		RouteMapRender = 1
	}

	private const float WATER_LEVEL_FALLBACK = -10f;

	private static readonly string[] xAxis = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

	private static readonly string[] yAxis = new string[8] { "8", "7", "6", "5", "4", "3", "2", "1" };

	public float waterLevel;

	public Vector3 worldSize = new Vector3(16384f, 1500f, 16384f);

	public float worldTerrainHeight = 1000f;

	public Vector3 worldOffset;

	public Vector3 defaultSpawnPosition;

	public Vector3 defaultSpawnRotation;

	public Vector3 newCareerSpawnPosition;

	public Vector3 newCareerSpawnRotation;

	public bool customBoundary;

	public Vector3 customBoundarySize;

	public Vector3 customBoundaryOffset;

	public string terrainHeightmapName;

	public string biomeMapName;

	public int splatsCount;

	public int terrainSpan;

	public float heightMapResolution;

	public float splatResolution;

	public float terrainSize;

	public bool enforceBoundary;

	public float worldBoundaryMargin;

	public JunctionGeneratedDataRuntime junctionData;

	[SerializeField]
	private GameObject[] worldSpecificPrefabs;

	public static float WaterLevel
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return -10f;
			}
			return SingletonBehaviour<LevelInfo>.Instance.waterLevel;
		}
	}

	public static Vector3 WorldSize
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.worldSize;
		}
	}

	public static float WorldTerrainHeight
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return 1000f;
			}
			return SingletonBehaviour<LevelInfo>.Instance.worldTerrainHeight;
		}
	}

	public static Vector3 WorldOffset
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.worldOffset;
		}
	}

	public static Vector3 DefaultSpawnPosition
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.defaultSpawnPosition;
		}
	}

	public static Vector3 DefaultSpawnRotation
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.defaultSpawnRotation;
		}
	}

	public static Vector3 NewCareerSpawnPosition
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.newCareerSpawnPosition;
		}
	}

	public static Vector3 NewCareerSpawnRotation
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.newCareerSpawnRotation;
		}
	}

	public static bool EnforceBoundary
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return false;
			}
			return SingletonBehaviour<LevelInfo>.Instance.enforceBoundary;
		}
	}

	public static float WorldBoundaryMargin
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return 0f;
			}
			return SingletonBehaviour<LevelInfo>.Instance.worldBoundaryMargin;
		}
	}

	public static Vector3 WorldBoundaryOffset
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			if (!SingletonBehaviour<LevelInfo>.Instance.customBoundary)
			{
				return Vector3.zero;
			}
			return SingletonBehaviour<LevelInfo>.Instance.customBoundaryOffset;
		}
	}

	public static Vector3 WorldBoundarySize
	{
		get
		{
			if (!(SingletonBehaviour<LevelInfo>.Instance != null))
			{
				return Vector3.zero;
			}
			if (!SingletonBehaviour<LevelInfo>.Instance.customBoundary)
			{
				return WorldSize;
			}
			return SingletonBehaviour<LevelInfo>.Instance.customBoundarySize;
		}
	}

	public new static string AllowAutoCreate()
	{
		return null;
	}

	public static bool IsUnderWater(Vector3 point)
	{
		return IsUnderWater(point.y);
	}

	public static bool IsUnderWater(float altitude)
	{
		return altitude <= WaterLevel;
	}

	public static GameObject GetWorldSpecificPrefab(WorldSpecificPrefabs prefab)
	{
		if (SingletonBehaviour<LevelInfo>.Instance == null)
		{
			Debug.LogError("LevelInfo: Instance is null. Cannot get world specific prefab.");
			return null;
		}
		if (SingletonBehaviour<LevelInfo>.Instance.worldSpecificPrefabs == null || SingletonBehaviour<LevelInfo>.Instance.worldSpecificPrefabs.Length == 0)
		{
			Debug.LogError("LevelInfo: World specific prefabs array is null or empty. Cannot get world specific prefab.");
			return null;
		}
		if (!((int)prefab).IsInRange(0, SingletonBehaviour<LevelInfo>.Instance.worldSpecificPrefabs.Length))
		{
			Debug.LogError(string.Format("{0}: World specific prefab index {1} for prefab {2} is out of array bounds. Cannot get world specific prefab.", "LevelInfo", (int)prefab, prefab));
			return null;
		}
		GameObject obj = SingletonBehaviour<LevelInfo>.Instance.worldSpecificPrefabs[(int)prefab];
		if (obj == null)
		{
			Debug.LogError(string.Format("{0}: Requested world specific prefab {1} doesn't have a valid reference. Returning null.", "LevelInfo", prefab));
		}
		return obj;
	}

	public string Get8x8PositionCoords(Vector3 point)
	{
		int num = Mathf.FloorToInt(NumberUtil.MapClamp(point.x, 0f, worldSize.x, 0f, 7.999f));
		int num2 = Mathf.FloorToInt(NumberUtil.MapClamp(point.z, 0f, worldSize.z, 0f, 7.999f));
		return xAxis[num] + yAxis[num2];
	}
}
