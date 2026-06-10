using System.Collections.Generic;
using UnityEngine;

public class CityData : MonoBehaviour
{
	public struct ParsedFloorTile
	{
		public Vector2 tileLocation;

		public int roomID;

		public List<Vector2> tileAccessList;

		public int designation;

		public int tileType;

		public bool addressAnchor;

		public float floorRotation;

		public List<Vector2> doorsAccess;

		public Dictionary<Vector2, int> windowsAccess;

		public bool lightswitch;

		public int cctv;
	}

	public class ParsedFloorData
	{
		public Dictionary<int, List<ParsedFloorTile>> unitData;

		public List<ParsedFloorTile> allTiles;

		public Vector2 mainEntranceOutside;

		public Vector2 mainEntranceInside;

		public Dictionary<Vector2, Vector2> additionalEntrances;

		public float floorHeight;

		public float ceilingHeight;
	}

	public class CityDirectoryEntry
	{
		public int linkID;

		public string entryName;

		public string sortString;

		public static int PhoneBookSort(CityDirectoryEntry other1, CityDirectoryEntry other2)
		{
			return 0;
		}
	}

	public enum BlockingDirection
	{
		none = 0,
		behindLeft = 1,
		behind = 2,
		behindRight = 3,
		left = 4,
		right = 5,
		frontLeft = 6,
		front = 7,
		frontRight = 8
	}

	public string cityName;

	public Vector2 citySize;

	public string cityBuiltWith;

	public int citizensToGenerate;

	public float populationMultiplier;

	public string seed;

	public List<string> instanceIDs;

	public Vector2 maxCoord;

	public float boundaryLeft;

	public float boundaryRight;

	public float boundaryUp;

	public float boundaryDown;

	public BlockController borderBlock;

	public Dictionary<string, FloorSaveData> floorData;

	public List<StreetController> streetDirectory;

	public List<NewAddress> addressDirectory;

	public List<NewFloor> floorDirectory;

	public Dictionary<int, NewAddress> addressDictionary;

	public List<NewGameLocation> gameLocationDirectory;

	public List<NewRoom> roomDirectory;

	public Dictionary<int, NewRoom> roomDictionary;

	public List<ResidenceController> residenceDirectory;

	public List<Company> companyDirectory;

	public List<Citizen> citizenDirectory;

	public List<Citizen> homelessDirectory;

	public List<Citizen> homedDirectory;

	public Dictionary<int, Human> citizenDictionary;

	public List<Human> deadCitizensDirectory;

	public List<Occupation> jobsDirectory;

	public List<Occupation> assignedJobsDirectory;

	public List<Occupation> unemployedDirectory;

	public List<Occupation> criminalJobDirectory;

	public List<ReflectionProbeController> reflectionProbeDirectory;

	public List<FurnitureLocation> jobBoardsDirectory;

	public Dictionary<int, NewDoor> doorDictionary;

	public List<AirDuctGroup> airDuctGroupDirectory;

	public List<AirDuctGroup.AirVent> airVentDirectory;

	public List<Interactable> interactableDirectory;

	public List<SceneRecorder> surveillanceDirectory;

	public Dictionary<int, Telephone> phoneDictionary;

	public Dictionary<int, Interactable> savableInteractableDictionary;

	public List<Interactable> caseTrays;

	public Dictionary<int, MetaObject> metaObjectDictionary;

	public List<LightController> dynamicShadowSystemLights;

	public List<Citizen> homlessAssign;

	public Dictionary<AddressPreset, List<NewAddress>> addressTypeReference;

	public Dictionary<RetailItemPreset, Evidence> itemSingletons;

	public HashSet<NewRoom> visibleRooms;

	public List<Actor> visibleActors;

	public Vector2 floorRange;

	public int residentialBuildings;

	public int commercialBuildings;

	public int industrialBuildings;

	public int municipalBuildings;

	public int parkBuildings;

	public int inhabitedResidences;

	public int employedCitizens;

	public int extraUnemloyedCreated;

	public float averageShoeSize;

	public Evidence cityDirectory;

	public Evidence elevatorControls;

	public EvidenceWitness telephone;

	public EvidenceWitness hospitalBed;

	public Dictionary<int, string> cityDirText;

	public Toolbox.MaterialKey echelonFloorMatKey;

	public Toolbox.MaterialKey echelonCeilingMatKey;

	public Toolbox.MaterialKey echelonDefaultWallKey;

	private static CityData _instance;

	public Vector2Int[] offsetArrayX4;

	public Vector2[] offsetArrayX4StreetJunction;

	public Vector2Int[] offsetArrayX4Diagonal;

	public Vector2Int[] offsetArrayX8;

	public Vector3Int[] offsetArrayX6;

	public Vector2Int[] offsetArrayX24;

	public int[] angleArrayX4;

	public int[] angleArrayX8;

	public static CityData Instance => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void DestroySelf()
	{
	}

	public void ParseFloorData()
	{
	}

	public Vector3Int CityTileToTile(Vector2Int coords)
	{
		return default(Vector3Int);
	}

	public Vector2Int PathmapToGroundmap(Vector3Int coords)
	{
		return default(Vector2Int);
	}

	public Vector2Int RealPosToGroundmap(Vector3 coords)
	{
		return default(Vector2Int);
	}

	public Vector3Int RealPosToPathmap(Vector3 coords)
	{
		return default(Vector3Int);
	}

	public Vector3Int RealPosToPathmapIncludingZ(Vector3 coords)
	{
		return default(Vector3Int);
	}

	public Vector3 RealPosToNode(Vector3 coords)
	{
		return default(Vector3);
	}

	public Vector3 RealPosToNodeFloat(Vector3 coords)
	{
		return default(Vector3);
	}

	public Vector3Int RealPosToNodeInt(Vector3 coords)
	{
		return default(Vector3Int);
	}

	public Vector3 CityTileToRealpos(Vector2 coords)
	{
		return default(Vector3);
	}

	public Vector3 TileToRealpos(Vector3Int coords)
	{
		return default(Vector3);
	}

	public Vector3 TileToRealpos(Vector3 coords)
	{
		return default(Vector3);
	}

	public Vector3 NodeToRealpos(Vector3 coords)
	{
		return default(Vector3);
	}

	public Vector3 NodeToRealposInt(Vector3Int coords)
	{
		return default(Vector3);
	}

	public float GetTileHeight(Vector2 coords)
	{
		return 0f;
	}

	public void CreateSingletons()
	{
	}

	public void CreateCityDirectory()
	{
	}

	public void GenerateEchelonDecorData()
	{
	}

	public Vector2Int GetOffsetFromDirection(BlockingDirection dir)
	{
		return default(Vector2Int);
	}

	public MetaObject FindMetaObject(int id)
	{
		return null;
	}

	public bool GetHuman(int id, out Human output, bool includePlayer = true)
	{
		output = null;
		return false;
	}

	public string GetCurrentGameInstanceID()
	{
		return null;
	}
}
