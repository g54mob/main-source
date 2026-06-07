using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
	[Serializable]
	public struct TileInfo
	{
		public Vector2Int coordinates;

		public List<BuildInfo> buildInfo;

		public List<DecorInfo> decorInfo;

		public List<CropInfo> cropsInfo;

		public List<HouseInfo> houseInfo;

		public List<AnimalInfo> animalInfo;

		public bool occupied;

		public bool unlocked;
	}

	[Serializable]
	public struct BuildInfo
	{
		public Building buildingScript;

		public BuildingType buildingAnchoredHere;

		public int buildingSOIndex;

		public Building.State buildingState;

		public int buildingSpeedLvl;

		public int buildingCapacityLvl;

		public bool buildingDisabled;

		public Vector2Int moveToCoordinates;

		public CropType cropSign;

		public BuildInfo(Building script, BuildingType type, int buildSOIndex, Building.State state, int speedLvl, int capacityLvl, bool enabled, Vector2Int moveToCoord, CropType sign)
		{
			buildingScript = script;
			buildingAnchoredHere = type;
			buildingSOIndex = buildSOIndex;
			buildingState = state;
			buildingSpeedLvl = speedLvl;
			buildingCapacityLvl = capacityLvl;
			buildingDisabled = !enabled;
			moveToCoordinates = moveToCoord;
			cropSign = sign;
		}
	}

	[Serializable]
	public struct CropInfo
	{
		public CropType cropType;

		public int cropState;

		public float cropProgress;

		public int cropMultiplier;

		public float cropFertilizerTimer;

		public bool cropImproved;

		public CropInfo(CropType type, int state, float progress, int multiplier, float fertTimer, bool improved)
		{
			cropType = type;
			cropState = state;
			cropProgress = progress;
			cropMultiplier = multiplier;
			cropFertilizerTimer = fertTimer;
			cropImproved = improved;
		}
	}

	[Serializable]
	public struct DecorInfo
	{
		public Decoration decorScript;

		public int decorId;

		public int decorProgress;

		public DecorInfo(Decoration script, int id, int progress)
		{
			decorScript = script;
			decorId = id;
			decorProgress = progress;
		}
	}

	[Serializable]
	public struct HouseInfo
	{
		public House houseScript;

		public HouseType houseType;

		public House.State houseState;

		public Vector2Int moveToCoordinates;

		public HouseInfo(House script, HouseType type, House.State state, Vector2Int moveToCoord)
		{
			houseScript = script;
			houseType = type;
			houseState = state;
			moveToCoordinates = moveToCoord;
		}
	}

	[Serializable]
	public struct AnimalInfo
	{
		public int animalId;

		public AnimalInfo(int id)
		{
			animalId = id;
		}
	}

	public static GridSystem ins;

	public Vector2Int gridSize;

	public Vector2Int vertSize = new Vector2Int(14, 82);

	public Vector2Int horiSize = new Vector2Int(144, 8);

	public float cellSize;

	private Vector2 originPosition;

	public Tile tilePrefab;

	public Transform tilesParent;

	public GameObject savingScreen;

	public GameObject loadingScreen;

	private Tile[,] tilePrefabs;

	public TileInfo[,] tile;

	[Header("Cursor")]
	public Cursor cursor;

	public LineRenderer movingLine;

	public GameObject upIndicator;

	public GameObject downIndicator;

	[Header("Sounds")]
	[SerializeField]
	private AudioClip buildAudio;

	[Header("Don't Seed Sign")]
	public CropSO dontSeedCropSO;

	[Header("Maps")]
	public GameObject grassyPlainsHorizontal;

	public GameObject grassyPlainsVertical;

	public GameObject swampLandHorizontal;

	public GameObject swampLandVertical;

	public GameObject desertSandsHorizontal;

	public GameObject desertSandsVertical;

	public GameObject blossomForestHorizontal;

	public GameObject blossomForestVertical;

	public GameObject desertOasisHorizontal;

	public GameObject desertOasisVertical;

	public GameObject winterSnowHorizontal;

	public GameObject winterSnowVertical;

	[Header("Crossover Maps")]
	public GameObject vampireSurvivorsHorizontal;

	public GameObject vampireSurvivorsVertical;

	public GameObject balatroHorizontal;

	public GameObject balatroVertical;

	private void Awake()
	{
		ins = this;
		cursor.Hide();
		if (SaveData.ins.checkIfSaveFileExists())
		{
			SetGridSizeBasedOnVerticalMode();
			SetFarmType();
			SetMapTo(SaveData.ins.verticalMode, SaveData.ins.farmType, SaveData.ins.crossoverFarmType);
			PopulateTileInfoAcrossGrid();
			PopulateTileObjsAcrossGrid();
			SaveData.ins.LoadGameData();
			MarkAllTilesAsNotOccupied();
			SpawnBuildingsAndCrops();
			BlockUnderHouseTiles();
		}
		else
		{
			SetGridSizeBasedOnVerticalMode();
			SetFarmType();
			SetMapTo(SaveData.ins.verticalMode, SaveData.ins.farmType, SaveData.ins.crossoverFarmType);
			PopulateTileInfoAcrossGrid();
			PopulateTileObjsAcrossGrid();
			SpawnStartingBuildings();
			SetCoordinatesInTileInfoGrid();
		}
		loadingScreen.SetActive(value: false);
	}

	private void SetGridSizeBasedOnVerticalMode()
	{
		if (PersistentFilePath.ins.currentFilePath.Substring(0, 1) == "V")
		{
			SaveData.ins.verticalMode = true;
		}
		if (PersistentFilePath.ins.currentFilePath.Substring(0, 1) == "H")
		{
			SaveData.ins.verticalMode = false;
		}
		if (SaveData.ins.verticalMode)
		{
			gridSize = vertSize;
		}
		else
		{
			gridSize = horiSize;
		}
		originPosition = new Vector2((float)(-gridSize.x) * cellSize * 0.5f, (float)(-gridSize.y) * cellSize * 0.5f);
		originPosition += Vector2.up * 0.375f;
		DebugDrawGrid();
	}

	private void SetFarmType()
	{
		bool flag = false;
		if (PersistentFilePath.ins.currentFilePath.Substring(1, 1) == "S")
		{
			flag = true;
		}
		if (!flag)
		{
			string text = PersistentFilePath.ins.currentFilePath.Substring(1, 1);
			if (text == "0")
			{
				SaveData.ins.farmType = SaveData.FarmType.GrassyPlains;
			}
			if (text == "1")
			{
				SaveData.ins.farmType = SaveData.FarmType.Swamp;
			}
			if (text == "2")
			{
				SaveData.ins.farmType = SaveData.FarmType.Desert;
			}
			if (text == "3")
			{
				SaveData.ins.farmType = SaveData.FarmType.BlossomForest;
			}
			if (text == "4")
			{
				SaveData.ins.farmType = SaveData.FarmType.DesertOasis;
			}
			if (text == "5")
			{
				SaveData.ins.farmType = SaveData.FarmType.WinterSnow;
			}
			if (text == "6")
			{
				SaveData.ins.farmType = SaveData.FarmType.Autumn;
			}
		}
		else
		{
			string text2 = PersistentFilePath.ins.currentFilePath.Substring(2, 1);
			if (text2 == "1")
			{
				SaveData.ins.crossoverFarmType = CrossoverFarmType.VampireSurvivors;
			}
			if (text2 == "2")
			{
				SaveData.ins.crossoverFarmType = CrossoverFarmType.Balatro;
			}
		}
	}

	private void SetMapTo(bool vert, SaveData.FarmType farm, CrossoverFarmType crossoverFarm)
	{
		if (vert)
		{
			if (crossoverFarm != CrossoverFarmType.None)
			{
				if (crossoverFarm == CrossoverFarmType.VampireSurvivors)
				{
					vampireSurvivorsVertical.SetActive(value: true);
				}
				if (crossoverFarm == CrossoverFarmType.Balatro)
				{
					balatroVertical.SetActive(value: true);
				}
				return;
			}
			if (farm == SaveData.FarmType.GrassyPlains)
			{
				grassyPlainsVertical.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.Swamp)
			{
				swampLandVertical.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.Desert)
			{
				desertSandsVertical.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.BlossomForest)
			{
				blossomForestVertical.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.DesertOasis)
			{
				desertOasisVertical.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.WinterSnow)
			{
				winterSnowVertical.SetActive(value: true);
			}
		}
		else if (crossoverFarm != CrossoverFarmType.None)
		{
			if (crossoverFarm == CrossoverFarmType.VampireSurvivors)
			{
				vampireSurvivorsHorizontal.SetActive(value: true);
			}
			if (crossoverFarm == CrossoverFarmType.Balatro)
			{
				balatroHorizontal.SetActive(value: true);
			}
		}
		else
		{
			if (farm == SaveData.FarmType.GrassyPlains)
			{
				grassyPlainsHorizontal.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.Swamp)
			{
				swampLandHorizontal.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.Desert)
			{
				desertSandsHorizontal.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.BlossomForest)
			{
				blossomForestHorizontal.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.DesertOasis)
			{
				desertOasisHorizontal.SetActive(value: true);
			}
			if (farm == SaveData.FarmType.WinterSnow)
			{
				winterSnowHorizontal.SetActive(value: true);
			}
		}
	}

	private void Start()
	{
		SaveData.ins.LoadSettings();
		SaveData.ins.ApplyAllSettings();
		StartCoroutine(DeactivateDebugLog());
	}

	private IEnumerator DeactivateDebugLog()
	{
		for (int i = 0; i < 5000; i++)
		{
			yield return null;
		}
		Debug.Log("Disabling the log after 5000 frames");
		Debug.unityLogger.logEnabled = !GameManager.ins.disablePlayerLog;
	}

	public void PrepareBuildingsAndCropsForSave()
	{
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				if (tile[i, j].decorInfo != null && tile[i, j].decorInfo.Count == 1)
				{
					tile[i, j].buildInfo = null;
					tile[i, j].cropsInfo = null;
					tile[i, j].houseInfo = null;
					tile[i, j].animalInfo = null;
					tile[i, j].decorInfo[0] = new DecorInfo(tile[i, j].decorInfo[0].decorScript, tile[i, j].decorInfo[0].decorId, tile[i, j].decorInfo[0].decorScript.statProgress);
				}
				else if (tile[i, j].houseInfo != null && tile[i, j].houseInfo.Count == 1)
				{
					tile[i, j].buildInfo = null;
					tile[i, j].decorInfo = null;
					tile[i, j].cropsInfo = null;
					tile[i, j].animalInfo = null;
					House.State state = tile[i, j].houseInfo[0].houseScript.state;
					tile[i, j].houseInfo[0] = new HouseInfo(tile[i, j].houseInfo[0].houseScript, tile[i, j].houseInfo[0].houseType, state, tile[i, j].houseInfo[0].houseScript.moveToCoord);
				}
				else
				{
					if (tile[i, j].buildInfo == null || tile[i, j].buildInfo.Count != 1)
					{
						continue;
					}
					tile[i, j].decorInfo = null;
					tile[i, j].houseInfo = null;
					Building.State state2 = tile[i, j].buildInfo[0].buildingScript.state;
					if (state2 == Building.State.IsBuilding)
					{
						state2 = Building.State.NeedsBuilding;
					}
					if (state2 == Building.State.MarkedForBuilding)
					{
						state2 = Building.State.NeedsBuilding;
					}
					if (state2 == Building.State.IsUpgrading)
					{
						state2 = Building.State.NeedsUpgrading;
					}
					if (state2 == Building.State.MarkedForUpgrading)
					{
						state2 = Building.State.NeedsUpgrading;
					}
					CropType sign = CropType.None;
					if (tile[i, j].buildInfo[0].buildingScript.cropSign != null)
					{
						sign = tile[i, j].buildInfo[0].buildingScript.cropSign.getCropType();
					}
					tile[i, j].buildInfo[0] = new BuildInfo(tile[i, j].buildInfo[0].buildingScript, tile[i, j].buildInfo[0].buildingScript.building.buildType, tile[i, j].buildInfo[0].buildingScript.building.buildIndexInList, state2, tile[i, j].buildInfo[0].buildingScript.speedLevel, tile[i, j].buildInfo[0].buildingScript.capacityLevel, tile[i, j].buildInfo[0].buildingScript.buildingEnabled, tile[i, j].buildInfo[0].buildingScript.moveToCoord, sign);
					if (tile[i, j].buildInfo[0].buildingScript.cropSlots.Length == 0)
					{
						tile[i, j].cropsInfo = null;
						continue;
					}
					if (tile[i, j].buildInfo[0].buildingScript.cropSlots[0] == null)
					{
						tile[i, j].cropsInfo = null;
						continue;
					}
					tile[i, j].cropsInfo = new List<CropInfo>();
					for (int k = 0; k < tile[i, j].buildInfo[0].buildingScript.cropSlots.Length; k++)
					{
						ICropSlot component = tile[i, j].buildInfo[0].buildingScript.cropSlots[k].GetComponent<ICropSlot>();
						CropInfo item = new CropInfo(component._CropType, component._CropState, component._CropProgress, component._CropMultiplier, component._CropFertilizer, component._CropImproved);
						tile[i, j].cropsInfo.Add(item);
					}
					if (tile[i, j].buildInfo[0].buildingScript.animalSlots.Length == 0)
					{
						tile[i, j].animalInfo = null;
						continue;
					}
					if (tile[i, j].buildInfo[0].buildingScript.animalSlots[0] == null)
					{
						tile[i, j].animalInfo = null;
						continue;
					}
					tile[i, j].animalInfo = new List<AnimalInfo>();
					for (int l = 0; l < tile[i, j].buildInfo[0].buildingScript.animalSlots.Length; l++)
					{
						AnimalSlot component2 = tile[i, j].buildInfo[0].buildingScript.animalSlots[l].GetComponent<AnimalSlot>();
						if (!component2.occupied)
						{
							AnimalInfo item2 = new AnimalInfo(-1);
							tile[i, j].animalInfo.Add(item2);
						}
						else
						{
							AnimalInfo item3 = new AnimalInfo(component2.animalId);
							tile[i, j].animalInfo.Add(item3);
						}
					}
				}
			}
		}
	}

	private void PopulateTileInfoAcrossGrid()
	{
		tile = new TileInfo[gridSize.x, gridSize.y];
	}

	private void SetCoordinatesInTileInfoGrid()
	{
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				tile[i, j].coordinates = new Vector2Int(i, j);
			}
		}
	}

	private void PopulateTileObjsAcrossGrid()
	{
		tilePrefabs = new Tile[gridSize.x, gridSize.y];
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				tilePrefabs[i, j] = UnityEngine.Object.Instantiate(tilePrefab, getWorldPosition(i, j), Quaternion.identity);
				tilePrefabs[i, j].SetCoordsTo(i, j);
				tilePrefabs[i, j].SetRandomizedVisual();
				tilePrefabs[i, j].gameObject.name = $"Tile: {i}, {j}";
				tilePrefabs[i, j].transform.parent = tilesParent;
			}
		}
	}

	private void MarkAllTilesAsNotOccupied()
	{
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				tile[i, j].occupied = false;
			}
		}
	}

	private void BlockUnderHouseTiles()
	{
		if (SaveData.ins.verticalMode)
		{
			MarkTilesAsOccupied(new Vector2Int(9, 38), new Vector2Int(6, 7), occupiedState: true);
		}
		else
		{
			MarkTilesAsOccupied(new Vector2Int(74, 0), new Vector2Int(6, 8), occupiedState: true);
		}
	}

	private void SpawnStartingBuildings()
	{
		if (SaveData.ins.verticalMode)
		{
			SetActiveTileObjsAt(new Vector2Int(13, 32), new Vector2Int(14, 18), active: false);
			QuickBuild(GameManager.ins.getBuildingSO(BuildingType.CropPatch), Building.State.Built, new Vector2Int(13, 37), out var bScript);
			AddBeginnerCropsToCropPatch(bScript);
			QuickBuild(GameManager.ins.getBuildingSO(BuildingType.BiofuelConverter), Building.State.Built, new Vector2Int(13, 42), out var _);
			QuickDecorate(GameManager.ins.buildingManager.decorCatalog[129], new Vector2Int(0, 0), 0);
			MarkTilesAsOccupied(new Vector2Int(9, 38), new Vector2Int(6, 7), occupiedState: true);
			return;
		}
		SetActiveTileObjsAt(new Vector2Int(87, 0), new Vector2Int(32, 8), active: false);
		if (GameManager.ins.demo)
		{
			MarkTilesAsOccupied(new Vector2Int(55, 0), new Vector2Int(56, 8), occupiedState: true);
			MarkTilesAsOccupied(new Vector2Int(143, 0), new Vector2Int(56, 8), occupiedState: true);
		}
		QuickBuild(GameManager.ins.getBuildingSO(BuildingType.CropPatch), Building.State.Built, new Vector2Int(68, 0), out var bScript3);
		AddBeginnerCropsToCropPatch(bScript3);
		QuickBuild(GameManager.ins.getBuildingSO(BuildingType.BiofuelConverter), Building.State.Built, new Vector2Int(67, 5), out var _);
		QuickDecorate(GameManager.ins.buildingManager.decorCatalog[129], new Vector2Int(0, 0), 0);
		MarkTilesAsOccupied(new Vector2Int(74, 0), new Vector2Int(6, 8), occupiedState: true);
	}

	private void AddBeginnerCropsToCropPatch(Building buildingScript)
	{
		buildingScript.cropSlots[0].GetComponent<CropSlot>().PlantSeedForFree(CropType.Wheat);
		buildingScript.cropSlots[6].GetComponent<CropSlot>().PlantSeedForFree(CropType.Wheat);
		buildingScript.cropSlots[1].GetComponent<CropSlot>().PlantSeedForFree(CropType.Radish);
		buildingScript.cropSlots[4].GetComponent<CropSlot>().PlantSeedForFree(CropType.Radish);
		buildingScript.cropSlots[2].GetComponent<CropSlot>().PlantSeedForFree(CropType.Cabbage);
		buildingScript.cropSlots[7].GetComponent<CropSlot>().PlantSeedForFree(CropType.Cabbage);
	}

	private void SpawnBuildingsAndCrops()
	{
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				if (tile[i, j].unlocked)
				{
					SetActiveTileObjsAt(new Vector2Int(i, j), active: false);
				}
				if (tile[i, j].decorInfo != null && tile[i, j].decorInfo.Count == 1)
				{
					Decoration decor = GameManager.ins.buildingManager.decorCatalog[tile[i, j].decorInfo[0].decorId];
					QuickDecorate(decor, new Vector2Int(i, j), tile[i, j].decorInfo[0].decorProgress);
				}
				else if (tile[i, j].houseInfo != null && tile[i, j].houseInfo.Count == 1)
				{
					HouseType houseType = tile[i, j].houseInfo[0].houseType;
					House houseOfType = GameManager.ins.buildingManager.getHouseOfType(houseType);
					QuickBuildHouse(houseOfType, new Vector2Int(i, j), tile[i, j].houseInfo[0].houseState);
				}
				else
				{
					if (tile[i, j].buildInfo == null || tile[i, j].buildInfo.Count != 1)
					{
						continue;
					}
					int buildingSOIndex = tile[i, j].buildInfo[0].buildingSOIndex;
					BuildingSO building = GameManager.ins.buildingManager.buildCatalog[buildingSOIndex];
					QuickBuild(building, tile[i, j].buildInfo[0].buildingState, new Vector2Int(i, j), out var bScript);
					if (bScript == null || bScript.cropSlots == null || bScript.cropSlots.Length == 0)
					{
						continue;
					}
					if (tile[i, j].cropsInfo != null && tile[i, j].cropsInfo.Count > 0)
					{
						for (int k = 0; k < tile[i, j].cropsInfo.Count; k++)
						{
							ICropSlot component = bScript.cropSlots[k].GetComponent<ICropSlot>();
							component._CropType = tile[i, j].cropsInfo[k].cropType;
							component._CropState = tile[i, j].cropsInfo[k].cropState;
							component._CropProgress = tile[i, j].cropsInfo[k].cropProgress;
							component._CropMultiplier = tile[i, j].cropsInfo[k].cropMultiplier;
							component._CropFertilizer = tile[i, j].cropsInfo[k].cropFertilizerTimer;
							component._CropImproved = tile[i, j].cropsInfo[k].cropImproved;
							component.ForceUpdateCropSlot();
						}
					}
					if (bScript.animalSlots == null || bScript.animalSlots.Length == 0 || tile[i, j].animalInfo == null || tile[i, j].animalInfo.Count <= 0)
					{
						continue;
					}
					for (int l = 0; l < tile[i, j].animalInfo.Count; l++)
					{
						if (tile[i, j].animalInfo[l].animalId != -1)
						{
							AnimalSlot component2 = bScript.animalSlots[l].GetComponent<AnimalSlot>();
							int animalId = tile[i, j].animalInfo[l].animalId;
							component2.QuickPlaceAnimal(GameManager.ins.cropManager.animalCatalog[animalId]);
						}
					}
				}
			}
		}
	}

	public void QuickBuild(BuildingSO building, Building.State state, Vector2Int coord, out Building bScript)
	{
		MarkTilesAsOccupied(coord, building.size, occupiedState: true);
		GameObject obj = UnityEngine.Object.Instantiate(building.prefab, getWorldPosition(coord), Quaternion.identity);
		bScript = null;
		if (obj.TryGetComponent<Building>(out var component))
		{
			bScript = component;
			bScript.AddAnchorCoord(coord);
			bScript.state = state;
			if (tile[coord.x, coord.y].buildInfo != null && tile[coord.x, coord.y].buildInfo.Count == 1)
			{
				bScript.speedLevel = tile[coord.x, coord.y].buildInfo[0].buildingSpeedLvl;
				bScript.capacityLevel = tile[coord.x, coord.y].buildInfo[0].buildingCapacityLvl;
				bScript.buildingEnabled = !tile[coord.x, coord.y].buildInfo[0].buildingDisabled;
				bScript.moveToCoord = tile[coord.x, coord.y].buildInfo[0].moveToCoordinates;
				if (bScript.cropSign != null)
				{
					CropType cropType = tile[coord.x, coord.y].buildInfo[0].cropSign;
					if (cropType == CropType.DontSeedSign)
					{
						bScript.cropSign.PlaceCropSign(dontSeedCropSO, playSound: false, checkMoney: false);
						cropType = CropType.None;
					}
					if (cropType != CropType.None)
					{
						bScript.cropSign.PlaceCropSign(GameManager.ins.getCropSO(cropType), playSound: false, checkMoney: false);
					}
				}
			}
			GameManager.ins.buildings.Add(bScript);
			AddBuildingAt(coord, bScript);
		}
		Inventory.ins.AddToBuildingInventory(building, 1);
	}

	private void DebugDrawGrid()
	{
		for (int i = 0; i < gridSize.x; i++)
		{
			for (int j = 0; j < gridSize.y; j++)
			{
				Debug.DrawLine(getWorldPosition(i, j), getWorldPosition(i, j + 1), Color.white, 10f);
				Debug.DrawLine(getWorldPosition(i, j), getWorldPosition(i + 1, j), Color.white, 10f);
			}
		}
		Debug.DrawLine(getWorldPosition(0, gridSize.y), getWorldPosition(gridSize.x, gridSize.y), Color.white, 10f);
		Debug.DrawLine(getWorldPosition(gridSize.x, 0), getWorldPosition(gridSize.x, gridSize.y), Color.white, 10f);
	}

	private void Update()
	{
		if (GameManager.ins.state == GameManager.State.CanBuild)
		{
			IsBuilding(GameManager.ins.buildingSelected);
		}
		if ((GameManager.ins.state == GameManager.State.CanBuild && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.CanBuild && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if (GameManager.ins.state == GameManager.State.CanBuildHouse)
		{
			IsBuildingHouse(GameManager.ins.houseSelected);
		}
		if ((GameManager.ins.state == GameManager.State.CanBuildHouse && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.CanBuildHouse && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if (GameManager.ins.state == GameManager.State.CanDecorate)
		{
			IsDecorating(GameManager.ins.decorSelected);
		}
		if ((GameManager.ins.state == GameManager.State.CanDecorate && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.CanDecorate && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if (GameManager.ins.state == GameManager.State.IsMovingBuilding)
		{
			if ((bool)GameManager.ins.buildingSelectedForMoving)
			{
				IsMoving(GameManager.ins.buildingSelectedForMoving);
			}
			if ((bool)GameManager.ins.houseSelectedForMoving)
			{
				IsMoving(GameManager.ins.houseSelectedForMoving);
			}
			if ((bool)GameManager.ins.decorSelectedForMoving)
			{
				IsMoving(GameManager.ins.decorSelectedForMoving);
			}
		}
		if (GameManager.ins.state == GameManager.State.IsMovingAnimal && (bool)GameManager.ins.animalSelectedForMoving)
		{
			IsMovingAnimal(GameManager.ins.animalSelectedForMoving);
		}
		if ((GameManager.ins.state == GameManager.State.IsMovingBuilding && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.IsMovingBuilding && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if ((GameManager.ins.state == GameManager.State.CanMoveBuilding && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.CanMoveBuilding && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if ((GameManager.ins.state == GameManager.State.IsMovingAnimal && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.IsMovingAnimal && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
		if ((GameManager.ins.state == GameManager.State.CanMoveAnimal && Input.GetMouseButtonDown(1)) || (GameManager.ins.state == GameManager.State.CanMoveAnimal && Input.GetKeyDown(KeyCode.Escape)))
		{
			ExitState();
		}
	}

	public void MoveBuilding(Building building, Vector2Int newCoords)
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		EnableMovingLine(value: false);
		if (!checkIfInsideGrid(newCoords, building.building.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(newCoords, building.building.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.buildingSelectedForMoving.SetNewBuildingCoord(newCoords);
		GameManager.ins.buildingSelectedForMoving = null;
	}

	public void MoveHouse(House house, Vector2Int newCoords)
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		EnableMovingLine(value: false);
		if (!checkIfInsideGrid(newCoords, house.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(newCoords, house.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.houseSelectedForMoving.SetNewHouseCoord(newCoords);
		GameManager.ins.houseSelectedForMoving = null;
	}

	public void MoveDecoration(Decoration decor, Vector2Int newCoords)
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		EnableMovingLine(value: false);
		if (!checkIfInsideGrid(newCoords, decor.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(newCoords, decor.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		GameManager.ins.decorSelectedForMoving.SetNewDecorationCoord(newCoords);
		GameManager.ins.decorSelectedForMoving = null;
	}

	public void MoveAnimal()
	{
		cursor.Hide();
		EnableMovingLine(value: false);
	}

	private void IsMoving(Building building)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(building.building.size, 1.125f);
		cursor.ChangeRangeTo(building.building.rangeSize);
		if (!checkIfInsideGrid(xYCoordinates, building.building.size) || checkIfTilesAreOccupied(xYCoordinates, building.building.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
		EnableMovingLine(value: true);
		DrawMovingLine(building.transform.position, getWorldPosition(xYCoordinates), building.center.position - building.transform.position);
	}

	private void IsMoving(House house)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(house.size, 1.125f);
		if (!checkIfInsideGrid(xYCoordinates, house.size) || checkIfTilesAreOccupied(xYCoordinates, house.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
		EnableMovingLine(value: true);
		DrawMovingLine(house.transform.position, getWorldPosition(xYCoordinates), house.center.position - house.transform.position);
	}

	private void IsMoving(Decoration decor)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(decor.size, 1.125f);
		if (!checkIfInsideGrid(xYCoordinates, decor.size) || checkIfTilesAreOccupied(xYCoordinates, decor.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
		EnableMovingLine(value: true);
		DrawMovingLine(decor.transform.position, getWorldPosition(xYCoordinates), new Vector2(0.5625f, 0.5625f));
	}

	private void IsMovingAnimal(Animal animal)
	{
		Vector2 vector = convertMousePositionToWorldPosition(Input.mousePosition);
		new Vector2Int(1, 1);
		cursor.UpdatePosition(vector);
		EnableMovingLine(value: true);
		DrawMovingLine(animal.parentSlot.transform.position, vector, new Vector2(0f, 0f));
	}

	public void EnableMovingLine(bool value)
	{
		movingLine.enabled = value;
		upIndicator.SetActive(value);
		downIndicator.SetActive(value);
	}

	private void DrawMovingLine(Vector2 origin, Vector2 target, Vector2 centerDisplacement)
	{
		upIndicator.transform.position = origin + centerDisplacement;
		movingLine.SetPosition(0, origin + centerDisplacement);
		downIndicator.transform.position = target + centerDisplacement;
		movingLine.SetPosition(1, target + centerDisplacement);
	}

	public void Build(BuildingSO building, Vector2Int targetCoords)
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		if (!checkIfInsideGrid(targetCoords, building.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(targetCoords, building.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (!checkIfPlayerHasResources(GameManager.ins.buildingSPCost, GameManager.ins.buildingBFCost, GameManager.ins.buildingFOCost))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			ExitState();
			return;
		}
		Inventory.ins.AddSpareParts(-GameManager.ins.buildingSPCost);
		Inventory.ins.AddBiofuel(-GameManager.ins.buildingBFCost);
		Inventory.ins.AddFossils(-GameManager.ins.buildingFOCost);
		Vector2 vector = getWorldPosition(targetCoords) + Vector2.up;
		GameManager.ins.SpawnBiofuelPopUp(vector + Vector2.up * 0.5f, -GameManager.ins.buildingBFCost);
		if (GameManager.ins.buildingSPCost != 0)
		{
			GameManager.ins.SpawnSparePartsPopUp(vector, -GameManager.ins.buildingSPCost);
		}
		if (GameManager.ins.buildingFOCost != 0)
		{
			GameManager.ins.SpawnFossilPopUp(vector, -GameManager.ins.buildingFOCost);
		}
		if ((building.buildType == BuildingType.WaterBot || building.buildType == BuildingType.HarvestBot) && !GameManager.ins.convertBiofuelTutorialPlayed)
		{
			GameManager.ins.convertBiofuelTutorial.SetActive(value: true);
		}
		Inventory.ins.AddToBuildingInventory(building, 1);
		MarkTilesAsOccupied(targetCoords, building.size, occupiedState: true);
		if (UnityEngine.Object.Instantiate(building.prefab, getWorldPosition(targetCoords), Quaternion.identity).TryGetComponent<Building>(out var component))
		{
			component.AddAnchorCoord(targetCoords);
			GameManager.ins.buildings.Add(component);
			AddBuildingAt(targetCoords, component);
		}
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	private void IsBuilding(BuildingSO building)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(building.size, 1.125f);
		cursor.ChangeRangeTo(building.rangeSize);
		if (!checkIfInsideGrid(xYCoordinates, building.size) || checkIfTilesAreOccupied(xYCoordinates, building.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
	}

	public void AddBuildingAt(Vector2Int coordinates, Building buildScript)
	{
		tile[coordinates.x, coordinates.y].decorInfo = null;
		tile[coordinates.x, coordinates.y].buildInfo = new List<BuildInfo>();
		CropType sign = CropType.None;
		if (buildScript.cropSign != null)
		{
			sign = buildScript.cropSign.getCropType();
		}
		BuildInfo item = new BuildInfo(buildScript, buildScript.building.buildType, buildScript.building.buildIndexInList, buildScript.state, buildScript.speedLevel, buildScript.capacityLevel, buildScript.buildingEnabled, buildScript.moveToCoord, sign);
		tile[coordinates.x, coordinates.y].buildInfo.Add(item);
	}

	public void RemoveBuildingAt(Vector2Int coordinates, Vector2Int buildingSize)
	{
		MarkTilesAsOccupied(coordinates, buildingSize, occupiedState: false);
		tile[coordinates.x, coordinates.y].buildInfo = null;
	}

	public Building getBuildingScriptAt(Vector2Int coordinates)
	{
		if (tile[coordinates.x, coordinates.y].buildInfo == null)
		{
			return null;
		}
		return tile[coordinates.x, coordinates.y].buildInfo[0].buildingScript;
	}

	public void BuildHouse(House house, Vector2Int targetCoords)
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		if (!checkIfInsideGrid(targetCoords, house.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(targetCoords, house.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		int num = house.spareParts;
		int biofuel = house.biofuel;
		if (SaveData.ins.checkIfCrossover(out var crossover) && crossover == CrossoverFarmType.Balatro)
		{
			num = ((house.houseType != HouseType.HaikuHouse) ? (num * 3) : (num * 2));
		}
		if (!checkIfPlayerHasResources(num, biofuel, 0))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			ExitState();
			return;
		}
		Inventory.ins.AddSpareParts(-num);
		Inventory.ins.AddBiofuel(-biofuel);
		Vector2 vector = getWorldPosition(targetCoords) + Vector2.up;
		GameManager.ins.SpawnSparePartsPopUp(vector, -num);
		GameManager.ins.SpawnBiofuelPopUp(vector + Vector2.up * 0.5f, -biofuel);
		Inventory.ins.SetHouseToBuilt(house.houseType);
		AchievementManager.ins.BuildHouse(house);
		MarkTilesAsOccupied(targetCoords, house.size, occupiedState: true);
		if (UnityEngine.Object.Instantiate(house, getWorldPosition(targetCoords), Quaternion.identity).TryGetComponent<House>(out var component))
		{
			component.AddAnchorCoord(targetCoords);
			AddHouseAt(targetCoords, component);
		}
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void QuickBuildHouse(House house, Vector2Int coord, House.State state)
	{
		MarkTilesAsOccupied(coord, house.size, occupiedState: true);
		House house2 = UnityEngine.Object.Instantiate(house, getWorldPosition(coord), Quaternion.identity);
		house2.AddAnchorCoord(coord);
		house2.moveToCoord = tile[coord.x, coord.y].houseInfo[0].moveToCoordinates;
		AddHouseAt(coord, house2);
		Inventory.ins.SetHouseToBuilt(house.houseType);
		AchievementManager.ins.BuildHouse(house);
		house2.state = state;
	}

	private void IsBuildingHouse(House house)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(house.size, 1.125f);
		cursor.ChangeRangeTo(0);
		if (!checkIfInsideGrid(xYCoordinates, house.size) || checkIfTilesAreOccupied(xYCoordinates, house.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
	}

	public void AddHouseAt(Vector2Int coordinates, House houseScript)
	{
		tile[coordinates.x, coordinates.y].decorInfo = null;
		tile[coordinates.x, coordinates.y].buildInfo = null;
		tile[coordinates.x, coordinates.y].houseInfo = new List<HouseInfo>();
		HouseInfo item = new HouseInfo(houseScript, houseScript.houseType, houseScript.state, houseScript.moveToCoord);
		tile[coordinates.x, coordinates.y].houseInfo.Add(item);
	}

	public void RemoveHouseAt(Vector2Int coordinates, Vector2Int houseSize)
	{
		MarkTilesAsOccupied(coordinates, houseSize, occupiedState: false);
		tile[coordinates.x, coordinates.y].houseInfo = null;
	}

	public void Decorate(Decoration decor, Vector2Int targetCoords)
	{
		if (!checkIfInsideGrid(targetCoords, decor.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (checkIfTilesAreOccupied(targetCoords, decor.size))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		if (!checkIfPlayerHasResources(decor.spareParts, decor.biofuel, 0))
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			ExitState();
			return;
		}
		Inventory.ins.AddSpareParts(-decor.spareParts);
		Inventory.ins.AddBiofuel(-decor.biofuel);
		Vector2 vector = getWorldPosition(targetCoords) + Vector2.up;
		GameManager.ins.SpawnSparePartsPopUp(vector, -decor.spareParts);
		GameManager.ins.SpawnBiofuelPopUp(vector + Vector2.up * 0.5f, -decor.biofuel);
		AchievementManager.ins.SpentOnDecorStat(decor.spareParts, decor.biofuel);
		MarkTilesAsOccupied(targetCoords, decor.size, occupiedState: true);
		Decoration decoration = UnityEngine.Object.Instantiate(decor, getWorldPosition(targetCoords), Quaternion.identity);
		decoration.AddAnchorCoord(targetCoords);
		AddDecorAt(targetCoords, decoration);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		AchievementManager.ins.PlaceDecoration();
	}

	public void QuickDecorate(Decoration decor, Vector2Int coord, int progress)
	{
		MarkTilesAsOccupied(coord, decor.size, occupiedState: true);
		Decoration decoration = UnityEngine.Object.Instantiate(decor, getWorldPosition(coord), Quaternion.identity);
		decoration.AddAnchorCoord(coord);
		decoration.SetProgressStat(progress);
		AddDecorAt(coord, decoration);
		AchievementManager.ins.PlaceDecoration();
	}

	private void IsDecorating(Decoration decor)
	{
		Vector2Int xYCoordinates = getXYCoordinates(convertMousePositionToWorldPosition(Input.mousePosition));
		if (xYCoordinates.y < 0 || xYCoordinates.y >= gridSize.y)
		{
			cursor.Hide();
			return;
		}
		cursor.Show();
		cursor.UpdatePosition(getWorldPosition(xYCoordinates));
		cursor.ChangeSizeTo(decor.size, 1.125f);
		cursor.ChangeRangeTo(0);
		if (!checkIfInsideGrid(xYCoordinates, decor.size) || checkIfTilesAreOccupied(xYCoordinates, decor.size))
		{
			cursor.ChangeColor(white: false);
		}
		else
		{
			cursor.ChangeColor(white: true);
		}
	}

	public void AddDecorAt(Vector2Int coordinates, Decoration decor)
	{
		tile[coordinates.x, coordinates.y].buildInfo = null;
		tile[coordinates.x, coordinates.y].cropsInfo = null;
		tile[coordinates.x, coordinates.y].decorInfo = new List<DecorInfo>();
		DecorInfo item = new DecorInfo(decor, decor.decorId, decor.statProgress);
		tile[coordinates.x, coordinates.y].decorInfo.Add(item);
	}

	public void RemoveDecorAt(Vector2Int coordinates, Vector2Int size)
	{
		MarkTilesAsOccupied(coordinates, size, occupiedState: false);
		tile[coordinates.x, coordinates.y].decorInfo = null;
	}

	private void ExitState()
	{
		GameManager.ins.SetStateToIdle();
		cursor.Hide();
		EnableMovingLine(value: false);
		if (GameManager.ins.buildingSelectedForMoving != null)
		{
			MarkTilesAsOccupied(GameManager.ins.buildingSelectedForMoving.getCoords(), GameManager.ins.buildingSelectedForMoving.building.size, occupiedState: true);
		}
		if (GameManager.ins.houseSelectedForMoving != null)
		{
			MarkTilesAsOccupied(GameManager.ins.houseSelectedForMoving.getCoords(), GameManager.ins.houseSelectedForMoving.size, occupiedState: true);
		}
		GameManager.ins.buildingSelectedForMoving = null;
		GameManager.ins.houseSelectedForMoving = null;
		GameManager.ins.animalSelectedForMoving = null;
	}

	public void MarkTilesAsOccupied(Vector2Int coordinates, Vector2Int buildingSize, bool occupiedState)
	{
		for (int i = 0; i < buildingSize.x; i++)
		{
			for (int j = 0; j < buildingSize.y; j++)
			{
				if (coordinates.x - i < gridSize.x && coordinates.y + j < gridSize.y && coordinates.x - i >= 0 && coordinates.y + j >= 0)
				{
					tile[coordinates.x - i, coordinates.y + j].occupied = occupiedState;
					tilePrefabs[coordinates.x - i, coordinates.y + j].SetColliderActive(!occupiedState);
				}
			}
		}
		if (GameManager.ins.checkIfAllLandsUnblocked())
		{
			AchievementManager.ins.CheckIfEntireFarmCovered();
		}
	}

	public void SetActiveTileObjsAt(Vector2Int coord, Vector2Int size, bool active)
	{
		for (int i = 0; i < size.x; i++)
		{
			for (int j = 0; j < size.y; j++)
			{
				tile[coord.x - i, coord.y + j].unlocked = !active;
				tilePrefabs[coord.x - i, coord.y + j].SetVisualActive(active);
			}
		}
	}

	public void SetActiveTileObjsAt(Vector2Int coord, bool active)
	{
		tile[coord.x, coord.y].unlocked = !active;
		tilePrefabs[coord.x, coord.y].SetVisualActive(active);
	}

	public Vector2 convertMousePositionToWorldPosition(Vector3 mousePosition)
	{
		return GameManager.ins.mainCam.ScreenToWorldPoint(mousePosition);
	}

	private Vector2 getWorldPosition(int x, int y)
	{
		return new Vector2(x, y) * cellSize + originPosition;
	}

	public Vector2 getWorldPosition(Vector2Int coordinates)
	{
		return new Vector2(coordinates.x, coordinates.y) * cellSize + originPosition;
	}

	public Vector2Int getXYCoordinates(Vector2 worldPosition)
	{
		int x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
		int y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
		return new Vector2Int(x, y);
	}

	public bool checkIfInsideGrid(Vector2Int coordinates, Vector2Int buildingSize)
	{
		if (coordinates.x > gridSize.x || coordinates.x < buildingSize.x - 1)
		{
			return false;
		}
		if (coordinates.y > gridSize.y - buildingSize.y || coordinates.y < 0)
		{
			return false;
		}
		return true;
	}

	public bool checkIfTilesAreOccupied(Vector2Int coordinates, Vector2Int buildingSize)
	{
		for (int i = 0; i < buildingSize.x; i++)
		{
			for (int j = 0; j < buildingSize.y; j++)
			{
				if (tile[coordinates.x - i, coordinates.y + j].occupied)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool checkIfPlayerHasResources(int spareparts, int biofuel, int fossils)
	{
		if (Inventory.ins.spareParts < spareparts)
		{
			return false;
		}
		if (Inventory.ins.biofuel < biofuel)
		{
			return false;
		}
		if (Inventory.ins.fossils < fossils)
		{
			return false;
		}
		return true;
	}

	public void ClearSave()
	{
		ES3.DeleteFile();
		Application.Quit();
	}
}
