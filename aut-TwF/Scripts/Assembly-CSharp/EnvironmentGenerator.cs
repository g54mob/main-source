using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LightTower;
using Unity.Mathematics;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
	private const int PLAYER_TOWER_DISTANCE = 2;

	private const int ENEMY_TOWER_DISTANCE = 2;

	[SerializeField]
	private PlayerTower playerTowerPrefab;

	[SerializeField]
	private EnemyTower enemyTowerPrefab;

	[SerializeField]
	private Tile fakePathTilePrefab;

	private PlayerTower playerTower;

	private EnemyTower enemyTower;

	private List<GameObject> obelisks;

	private List<GameObject> specialBuildings;

	private GameObject trader;

	[SerializeField]
	private GridBasedSpawnerData crystalAltarSpawnerData;

	[SerializeField]
	private CircleBasedSpawnerData traderSpawnerData;

	[SerializeField]
	private BaseSpawnerData[] perkBeaconsSpawnerData;

	[SerializeField]
	private BaseSpawnerData[] otherSpecialBuildings;

	[SerializeField]
	private CircleBasedSpawnerData crystalFinderSpawnerData;

	[SerializeField]
	private int crystalFinderActivationCost;

	[SerializeField]
	private List<BaseSpawnerData> resourcesSpawnerDatas;

	[SerializeField]
	private WeightedRandomSelector<GameObject> treePrefabs;

	[SerializeField]
	private Vector2 minMaxTreeScale = Vector2.one;

	[SerializeField]
	[Tooltip("Escal del noise para colocar los cluster de árboles")]
	private float treeClusterNoiseScale = 10f;

	[SerializeField]
	[Tooltip("Genera distintos patrones de noise en cada generación. Desactivar SOLO para testeo")]
	private bool noiseOffsetEnabled = true;

	[SerializeField]
	[Tooltip("Si es true, el Cluster Noise Scale se usa como si fuera una distancia normalizada y no euclídea")]
	private bool treeNormalizeDistance;

	[SerializeField]
	private bool treeInvertNoise;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Tamaño máximo de cada cluster de árboles")]
	private float treeClusterMaxSizeBias = 0.5f;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Probabilidad de spawn de árboles en el centro del cluster")]
	private float treeClustesInnerDensity = 1f;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Probabilidad de spawn de árboles en la parte externa del cluster")]
	private float treeClustesOuterDensity;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Probabilidad de spawn de árboles en las casillas que no son de cluster")]
	private float sparseTreeDensity = 0.05f;

	[SerializeField]
	[Tooltip("Permite que haya árboles pegados")]
	private bool allowAdjacentTrees = true;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("Si no puede haber árboles pegados, determina la probabilidad de borrar un árbol que está pegado a otro")]
	private float removeAdjacentTreeProbability = 1f;

	[SerializeField]
	private PathBasedSpawnerData obelisksSpawnerData;

	[SerializeField]
	private GridBasedSpawnerData chestsSpawnerData;

	[SerializeField]
	private ChestLootTableData chestLootTable;

	[SerializeField]
	private int chestValuePerMeter;

	[SerializeField]
	[Tooltip("0 = infinito")]
	private int chestMaxValue;

	[SerializeField]
	private int chestMaxDifferentResources = 1;

	[SerializeField]
	private GridBasedSpawnerData GCCSpawnerData;

	[SerializeField]
	private Vector2 minMaxGoldenCoinsPerChest = Vector2.one;

	[SerializeField]
	private GridBasedSpawnerData gemsChestsSpawnerData;

	[SerializeField]
	private GemsChestLootTableData gemsChestLootTable;

	[SerializeField]
	private float gemsChestValuePerMeter;

	[SerializeField]
	[Tooltip("0 = infinito")]
	private int gemsChestMaxValue;

	[SerializeField]
	private float playerTowerClearAreaRadius = 5f;

	[SerializeField]
	private float enemyTowerClearAreaRadius = 5f;

	[SerializeField]
	private float crystalAltarsClearAreaRadius;

	[SerializeField]
	private float obelisksClearAreaRadius = 2f;

	[SerializeField]
	private float pathClearAreaRadius = 1f;

	[SerializeField]
	private int specialBuildingsClearAreaRadius = 1;

	[SerializeField]
	private Vector2 minMaxStarterAreaRadius;

	[SerializeField]
	private int minStarterTrees = 10;

	[SerializeField]
	private int minStarterStones = 2;

	[SerializeField]
	private List<GameObject> starterStonePrefabs;

	[SerializeField]
	private int minStarterCoal;

	[SerializeField]
	private List<GameObject> starterCoalPrefabs;

	[SerializeField]
	private int minStarterIron;

	[SerializeField]
	private List<GameObject> starterIronPrefabs;

	private Grid grid;

	private PathTile[] pathTiles;

	private KeyValuePair<PathTile, EOrientation> firstPathTile;

	private KeyValuePair<PathTile, EOrientation> lastPathTile;

	public PlayerTower PlayerTower
	{
		get
		{
			return playerTower;
		}
		private set
		{
			playerTower = value;
		}
	}

	public EnemyTower EnemyTower
	{
		get
		{
			return enemyTower;
		}
		private set
		{
			enemyTower = value;
		}
	}

	public List<GameObject> Obelisks
	{
		get
		{
			return obelisks;
		}
		private set
		{
			obelisks = value;
		}
	}

	public List<GameObject> CrystalAltars { get; private set; }

	public List<GameObject> SpecialBuildings
	{
		get
		{
			return specialBuildings;
		}
		private set
		{
			specialBuildings = value;
		}
	}

	public List<GameObject> CrystalFinders { get; private set; }

	public bool GenerateEnvironment(KeyValuePair<PathTile, EOrientation> firstPathTile, KeyValuePair<PathTile, EOrientation> lastPathTile, Grid grid, PathTile[] pathTiles, bool forceEndGeneration)
	{
		this.grid = grid;
		this.pathTiles = pathTiles;
		this.firstPathTile = firstPathTile;
		this.lastPathTile = lastPathTile;
		SpawnMainTowers();
		if (!SpawnCrystalAltars() && !forceEndGeneration)
		{
			return false;
		}
		if (!SpawnObelisks() && !forceEndGeneration)
		{
			return false;
		}
		if (!SpawnSpecialBuildings() && !forceEndGeneration)
		{
			return false;
		}
		if (!SpawnCrystalFinder() && !forceEndGeneration)
		{
			return false;
		}
		SpawnChests();
		SpawnGoldenCoinsChests();
		SpawnGemsChests();
		SpawnResources();
		SpawnTrees();
		CleanAreas();
		GenerateStarterArea();
		return true;
	}

	private bool TryToAssignObjectToGrid(Grid grid, PlacementComponent placementComponent, bool replace, bool forcePlace = false)
	{
		GridCell gridCell = null;
		Vector3[] occupiedPositions;
		if (!forcePlace)
		{
			occupiedPositions = placementComponent.GetOccupiedPositions();
			foreach (Vector3 position in occupiedPositions)
			{
				gridCell = grid.GetGridCell(position);
				if (gridCell != null && gridCell.Tile.PreventBuildOnMapGeneration)
				{
					UnityEngine.Object.DestroyImmediate(placementComponent.gameObject);
					return false;
				}
				if (gridCell == null || (!gridCell.CanBuild() && gridCell.BuiltObject != this))
				{
					if (gridCell == null || gridCell.IsFree())
					{
						UnityEngine.Object.DestroyImmediate(placementComponent.gameObject);
						return false;
					}
					if (!replace)
					{
						UnityEngine.Object.DestroyImmediate(placementComponent.gameObject);
						return false;
					}
					UnityEngine.Object.DestroyImmediate(gridCell.BuiltObject.gameObject);
				}
			}
		}
		occupiedPositions = placementComponent.GetOccupiedPositions();
		foreach (Vector3 position2 in occupiedPositions)
		{
			grid.GetGridCell(position2).BuiltObject = placementComponent;
		}
		return true;
	}

	private void SpawnMainTowers()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Vector3 vector = firstPathTile.Key.transform.position + LTFunctionLibrary.GetDirectionFromOrientation(firstPathTile.Value) * -1f * 2f;
		vector = vector.RoundToInt();
		Quaternion rotation = Quaternion.LookRotation(LTFunctionLibrary.GetDirectionFromOrientation(firstPathTile.Value) * -1f);
		PlayerTower = UnityEngine.Object.Instantiate(playerTowerPrefab, vector, rotation, base.transform);
		TryToAssignObjectToGrid(grid, PlayerTower.GetComponent<PlacementComponent>(), replace: true, forcePlace: true);
		Vector3 vector2 = lastPathTile.Key.transform.position + LTFunctionLibrary.GetDirectionFromOrientation(lastPathTile.Value) * 2f;
		vector2 = vector2.RoundToInt();
		Quaternion rotation2 = Quaternion.LookRotation(LTFunctionLibrary.GetDirectionFromOrientation(lastPathTile.Value) * -1f);
		EnemyTower = UnityEngine.Object.Instantiate(enemyTowerPrefab, vector2, rotation2, base.transform);
		TryToAssignObjectToGrid(grid, EnemyTower.GetComponent<PlacementComponent>(), replace: true, forcePlace: true);
		Vector3 position = firstPathTile.Key.transform.position + LTFunctionLibrary.GetDirectionFromOrientation(firstPathTile.Value) * -1f;
		UnityEngine.Object.DestroyImmediate(grid.GetGridCell(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z)).Tile.gameObject);
		Tile tile = UnityEngine.Object.Instantiate(fakePathTilePrefab, position, rotation, playerTower.transform);
		grid.AddGridCell(tile);
		stopwatch.Stop();
		UnityEngine.Debug.Log("TOWERS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private bool SpawnCrystalAltars()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("CrystalAltars");
		gameObject.transform.parent = base.transform;
		CrystalAltars = crystalAltarSpawnerData.SpawnRandomGridBasedObjects(grid, pathTiles, gameObject.transform, GenerateMapElements());
		int num = 0;
		foreach (GameObject crystalAltar in CrystalAltars)
		{
			crystalAltar.GetComponent<SaveComponent>().Id = "CrystalAltar_" + num;
			num++;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("ALTARS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		int num2 = grid.GetGridSize().x * grid.GetGridSize().y;
		if (CrystalAltars != null)
		{
			return CrystalAltars.Count == crystalAltarSpawnerData.GetObjectsAmount(num2);
		}
		return false;
	}

	private bool SpawnCrystalFinder()
	{
		if (crystalFinderSpawnerData == null)
		{
			return true;
		}
		int num = MatchInfo.instance?.CurrentMatchSettings?.MaxCrystalFindersAmount ?? (-1);
		if (num == 0)
		{
			return true;
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("CrystalFinders");
		gameObject.transform.parent = base.transform;
		CrystalFinders = crystalFinderSpawnerData.SpawnRandomCircleBasedObjects(grid, PlayerTower.transform.position, pathTiles, GenerateMapElements(), gameObject.transform, num);
		int num2 = 0;
		foreach (GameObject crystalFinder in CrystalFinders)
		{
			crystalFinder.GetComponent<CrystalFinder>().ActivationCost[0].Amount = crystalFinderActivationCost;
			crystalFinder.GetComponent<SaveComponent>().Id = "CrystalFinder_" + num2;
			num2++;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("CRYSTAL FINDERS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		int num3 = grid.GetGridSize().x * grid.GetGridSize().y;
		if (CrystalFinders != null)
		{
			return CrystalFinders.Count == ((num != -1 && num < crystalFinderSpawnerData.GetObjectsAmount(num3)) ? num : crystalFinderSpawnerData.GetObjectsAmount(num3));
		}
		return false;
	}

	private void SpawnChests()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("Chests");
		gameObject.transform.parent = base.transform;
		chestsSpawnerData.SpawnRandomGridBasedObjects(grid, pathTiles, gameObject.transform, GenerateMapElements());
		int num = 0;
		Chest[] componentsInChildren = gameObject.GetComponentsInChildren<Chest>();
		foreach (Chest chest in componentsInChildren)
		{
			GenerateChestLoot(chest);
			chest.GetComponent<SaveComponent>().Id = "Chest_" + num;
			num++;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("CHESTS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void SpawnGoldenCoinsChests()
	{
		if (!(GCCSpawnerData == null))
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			GameObject gameObject = new GameObject("GoldenCoinChests");
			gameObject.transform.parent = base.transform;
			GCCSpawnerData.SpawnRandomGridBasedObjects(grid, pathTiles, gameObject.transform, GenerateMapElements());
			int num = 0;
			GoldenCoinsChest[] componentsInChildren = gameObject.GetComponentsInChildren<GoldenCoinsChest>();
			foreach (GoldenCoinsChest goldenCoinsChest in componentsInChildren)
			{
				GenerateGoldenCoinsChestLoot(goldenCoinsChest, grid.GetGridSize());
				goldenCoinsChest.GetComponent<SaveComponent>().Id = "GCChest_" + num;
				num++;
			}
			stopwatch.Stop();
			UnityEngine.Debug.Log("GOLDEN COINS CHESTS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		}
	}

	private void SpawnGemsChests()
	{
		if (LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade("PlayerUpgrade_gems_unlock"))
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			GameObject gameObject = new GameObject("GemsChests");
			gameObject.transform.parent = base.transform;
			gemsChestsSpawnerData.SpawnRandomGridBasedObjects(grid, pathTiles, gameObject.transform, GenerateMapElements());
			int num = 0;
			GemsChest[] componentsInChildren = gameObject.GetComponentsInChildren<GemsChest>();
			foreach (GemsChest gemsChest in componentsInChildren)
			{
				GenerateGemsChestLoot(gemsChest);
				gemsChest.GetComponent<SaveComponent>().Id = "GemsChest_" + num;
				num++;
			}
			stopwatch.Stop();
			UnityEngine.Debug.Log("GEMS CHESTS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		}
	}

	private bool SpawnSpecialBuildings()
	{
		SpecialBuildings = new List<GameObject>();
		int num = grid.GetGridSize().x * grid.GetGridSize().y;
		bool flag = false;
		bool num2 = LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade("PlayerUpgrade_specialBuildings_trader_unlock");
		flag = LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade("PlayerUpgrade_specialBuildings_perkBeacons_unlock");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("SpecialBuildings");
		gameObject.transform.parent = base.transform;
		List<GameObject> list = new List<GameObject>();
		if (num2)
		{
			list.AddRange(traderSpawnerData.SpawnRandomCircleBasedObjects(grid, PlayerTower.transform.position, pathTiles, GenerateMapElements(), gameObject.transform));
			if (list.Count != traderSpawnerData.GetObjectsAmount(num))
			{
				return false;
			}
			SpecialBuildings.AddRange(list);
		}
		BaseSpawnerData[] array;
		if (flag)
		{
			list.Clear();
			int num3 = 0;
			array = perkBeaconsSpawnerData;
			foreach (BaseSpawnerData baseSpawnerData in array)
			{
				list.AddRange(SpawnGenericObjects(baseSpawnerData, grid, pathTiles, gameObject.transform));
				num3 += baseSpawnerData.GetObjectsAmount(num);
			}
			if (list.Count != num3)
			{
				return false;
			}
			SpecialBuildings.AddRange(list);
		}
		array = otherSpecialBuildings;
		foreach (BaseSpawnerData baseSpawnerData2 in array)
		{
			list.Clear();
			list.AddRange(SpawnGenericObjects(baseSpawnerData2, grid, pathTiles, gameObject.transform));
			if (list.Count != baseSpawnerData2.GetObjectsAmount(num))
			{
				return false;
			}
			SpecialBuildings.AddRange(list);
		}
		for (int j = 0; j < SpecialBuildings.Count; j++)
		{
			if (SpecialBuildings[j].TryGetComponent<SaveComponent>(out var component))
			{
				component.Id = "SpecialBuilding_" + j;
			}
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("SPECIAL BUILDINGS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		return true;
	}

	private bool SpawnObelisks()
	{
		if (!obelisksSpawnerData)
		{
			return true;
		}
		int num = grid.GetGridSize().x * grid.GetGridSize().y;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("Obelisks");
		gameObject.transform.parent = base.transform;
		Obelisks = obelisksSpawnerData.SpawnRandomPathBasedObjects(grid, GenerateMapElements(), gameObject.transform);
		stopwatch.Stop();
		UnityEngine.Debug.Log("OBELISKS: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
		if (Obelisks != null)
		{
			return Obelisks.Count == obelisksSpawnerData.GetObjectsAmount(num);
		}
		return false;
	}

	private void SpawnResources()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GameObject gameObject = new GameObject("Resources");
		gameObject.transform.parent = base.transform;
		foreach (BaseSpawnerData resourcesSpawnerData in resourcesSpawnerDatas)
		{
			if (resourcesSpawnerData is GridBasedSpawnerData)
			{
				(resourcesSpawnerData as GridBasedSpawnerData).SpawnRandomGridBasedObjects(grid, pathTiles, gameObject.transform, GenerateMapElements());
			}
			else if (resourcesSpawnerData is CircleBasedSpawnerData)
			{
				(resourcesSpawnerData as CircleBasedSpawnerData).SpawnRandomCircleBasedObjects(grid, PlayerTower.transform.position, pathTiles, GenerateMapElements(), gameObject.transform);
			}
		}
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).GetComponent<SaveComponent>().Id = "Resource_" + i;
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("RESOURCES: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void SpawnTrees()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		int num = (noiseOffsetEnabled ? UnityEngine.Random.Range(0, 100000) : 0);
		GameObject gameObject = new GameObject("Trees");
		gameObject.transform.SetParent(base.transform);
		for (int i = 0; i < grid.GetGridSize().x; i++)
		{
			for (int j = 0; j < grid.GetGridSize().y; j++)
			{
				float2 float5 = noise.cellular(new float2((float)(i + num) / treeClusterNoiseScale, (float)(j + num) / treeClusterNoiseScale));
				float num2 = (treeNormalizeDistance ? (float5.x / float5.y) : float5.x);
				if (treeInvertNoise)
				{
					num2 = 1f - num2;
				}
				if ((num2 <= treeClusterMaxSizeBias && UnityEngine.Random.value < Mathf.Lerp(treeClustesOuterDensity, treeClustesInnerDensity, 1f - num2 / treeClusterMaxSizeBias)) || (num2 > treeClusterMaxSizeBias && UnityEngine.Random.value < sparseTreeDensity))
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(treePrefabs.GetRandomElement(), new Vector3(i, 0f, j), Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f), gameObject.transform);
					gameObject2.transform.localScale = Vector3.one * UnityEngine.Random.Range(minMaxTreeScale.x, minMaxTreeScale.y);
					TryToAssignObjectToGrid(grid, gameObject2.GetComponent<PlacementComponent>(), replace: false);
				}
			}
		}
		if (!allowAdjacentTrees)
		{
			for (int num3 = gameObject.transform.childCount - 1; num3 >= 0; num3--)
			{
				int num4 = 0;
				Transform child = gameObject.transform.GetChild(num3);
				foreach (GridCell adjacentGridCell in grid.GetAdjacentGridCells(child.position))
				{
					if ((bool)adjacentGridCell.BuiltObject && adjacentGridCell.BuiltObject.TryGetComponent<Source>(out var component) && component.Resource.Id == "wood")
					{
						num4++;
					}
				}
				if (num4 > 0 && UnityEngine.Random.value < removeAdjacentTreeProbability)
				{
					UnityEngine.Object.DestroyImmediate(child.gameObject);
				}
				else
				{
					child.gameObject.GetComponent<SaveComponent>().Id = "Tree_" + num3;
				}
			}
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("TREES: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void CleanAreas()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		RemoveObjectsAroundPosition<Source>(PlayerTower.transform.position, playerTowerClearAreaRadius);
		RemoveObjectsAroundPosition<Source>(EnemyTower.transform.position, enemyTowerClearAreaRadius);
		foreach (GameObject crystalAltar in CrystalAltars)
		{
			RemoveObjectsAroundPosition<Source>(crystalAltar.transform.position, crystalAltarsClearAreaRadius);
		}
		foreach (GameObject obelisk in obelisks)
		{
			RemoveObjectsAroundPosition<Source>(obelisk.transform.position, obelisksClearAreaRadius);
		}
		if (pathClearAreaRadius > 0f)
		{
			for (int i = 0; i < pathTiles.Length; i += 2)
			{
				RemoveObjectsAroundPosition<Source>(pathTiles[i].transform.position, pathClearAreaRadius);
			}
		}
		foreach (GameObject specialBuilding in SpecialBuildings)
		{
			RemoveObjectsAroundPosition<Source>(specialBuilding.transform.position, specialBuildingsClearAreaRadius);
		}
		stopwatch.Stop();
		UnityEngine.Debug.Log("CLEANING: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void GenerateStarterArea()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		List<Source> objectsAroundPosition = GetObjectsAroundPosition<Source>(PlayerTower.transform.position, minMaxStarterAreaRadius.y);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (Source item in objectsAroundPosition)
		{
			switch (item.Resource.Id)
			{
			case "wood":
				num++;
				break;
			case "stone":
				num2++;
				break;
			case "coal":
				num3++;
				break;
			case "iron":
				num4++;
				break;
			}
		}
		GameObject gameObject = new GameObject("StarterArea");
		gameObject.transform.SetParent(base.transform);
		int num5 = 1000;
		for (int i = 0; i < minStarterTrees - num; i++)
		{
			bool flag = false;
			int num6 = 0;
			while (!flag && num6 < num5)
			{
				num6++;
				Vector3 positionAroundPosition = GetPositionAroundPosition(PlayerTower.transform.position, minMaxStarterAreaRadius, PlayerTower.transform.forward * -1f, 45f);
				positionAroundPosition = grid.SnapPositionToGrid(positionAroundPosition);
				GameObject gameObject2 = UnityEngine.Object.Instantiate(treePrefabs.GetRandomElement(), positionAroundPosition, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f), gameObject.transform);
				gameObject2.transform.localScale = Vector3.one * UnityEngine.Random.Range(minMaxTreeScale.x, minMaxTreeScale.y);
				flag = TryToAssignObjectToGrid(grid, gameObject2.GetComponent<PlacementComponent>(), replace: false);
				if (flag)
				{
					gameObject2.GetComponent<SaveComponent>().Id = "StarterTree_" + i;
				}
			}
			if (!flag && num6 >= num5)
			{
				UnityEngine.Debug.LogWarning("Tras muchos intentos no se pudo colocar un Starter Tree y se dejó de intentar");
			}
		}
		SpawnStarterResources(starterStonePrefabs, minStarterStones, num2, gameObject.transform, grid);
		SpawnStarterResources(starterCoalPrefabs, minStarterCoal, num3, gameObject.transform, grid);
		SpawnStarterResources(starterIronPrefabs, minStarterIron, num4, gameObject.transform, grid);
		stopwatch.Stop();
		UnityEngine.Debug.Log("STARTER AREA: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void SpawnStarterResources(List<GameObject> prefabs, int minAmount, int currentAmount, Transform parent, Grid grid)
	{
		if (prefabs == null)
		{
			return;
		}
		int num = 1000;
		for (int i = 0; i < minAmount - currentAmount; i++)
		{
			bool flag = false;
			int num2 = 0;
			while (!flag && num2 < num)
			{
				num2++;
				Vector3 positionAroundPosition = GetPositionAroundPosition(PlayerTower.transform.position, minMaxStarterAreaRadius, PlayerTower.transform.forward * -1f, 45f);
				positionAroundPosition = grid.SnapPositionToGrid(positionAroundPosition);
				GameObject gameObject = UnityEngine.Object.Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)], positionAroundPosition, Quaternion.Euler(0f, 90f * (float)UnityEngine.Random.Range(0, 4), 0f), parent);
				flag = TryToAssignObjectToGrid(grid, gameObject.GetComponent<PlacementComponent>(), replace: false);
				if (flag)
				{
					gameObject.GetComponent<SaveComponent>().Id = prefabs[0].name + i;
				}
			}
			if (!flag && num2 >= num)
			{
				UnityEngine.Debug.LogWarning("Tras muchos intentos no se pudo colocar un Starter Resource (" + prefabs[0].name + ") y se dejó de intentar");
			}
		}
	}

	private Vector3 GetPositionAroundPosition(Vector3 position, Vector2 minMaxRadius, Vector3 frontDirection, float frontInvalidAreaDegrees)
	{
		float angle = UnityEngine.Random.Range(frontInvalidAreaDegrees, 180f) * ((UnityEngine.Random.value < 0.5f) ? 1f : (-1f));
		Vector3 vector = frontDirection.normalized * UnityEngine.Random.Range(minMaxRadius.x, minMaxRadius.y);
		vector = Quaternion.AngleAxis(angle, Vector3.up) * vector;
		return position + vector;
	}

	private List<T> GetObjectsAroundPosition<T>(Vector3 position, float radius)
	{
		if (radius <= 0f)
		{
			return null;
		}
		List<T> list = new List<T>();
		Collider[] array = Physics.OverlapSphere(position, radius);
		foreach (Collider collider in array)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			T component2;
			if ((object)attachedRigidbody != null && attachedRigidbody.TryGetComponent<T>(out var component))
			{
				list.Add(component);
			}
			else if (collider.TryGetComponent<T>(out component2))
			{
				list.Add(component2);
			}
		}
		return list;
	}

	private void RemoveObjectsAroundPosition<T>(Vector3 position, float radius)
	{
		List<T> objectsAroundPosition = GetObjectsAroundPosition<T>(position, radius);
		if (objectsAroundPosition == null)
		{
			return;
		}
		foreach (T item in objectsAroundPosition)
		{
			if (item is MonoBehaviour)
			{
				UnityEngine.Object.DestroyImmediate((item as MonoBehaviour).gameObject);
			}
		}
	}

	private List<GameObject> SpawnGenericObjects(BaseSpawnerData data, Grid grid, ICollection pathTile, Transform parent, List<(Vector3, float)> invalidAreas = null)
	{
		if (data is CircleBasedSpawnerData)
		{
			return (data as CircleBasedSpawnerData).SpawnRandomCircleBasedObjects(grid, PlayerTower.transform.position, pathTile, GenerateMapElements(), parent);
		}
		if (data is GridBasedSpawnerData)
		{
			return (data as GridBasedSpawnerData).SpawnRandomGridBasedObjects(grid, pathTile, parent, GenerateMapElements());
		}
		UnityEngine.Debug.LogError("El tipo de data no es válido para el spawner genérico");
		return null;
	}

	private void GenerateChestLoot(Chest chest)
	{
		List<Cost> list = new List<Cost>();
		float num = Vector3.Distance(chest.transform.position, PlayerTower.transform.position);
		float num2 = num * (float)chestValuePerMeter;
		if (chestMaxValue > 0)
		{
			num2 = Math.Min(num2, chestMaxValue);
		}
		List<ResourceData> list2 = new List<ResourceData>();
		foreach (ChestLootTableData.FChestLoot item in chestLootTable.Loot)
		{
			if (num >= (float)item.MinMaxDistance.x && num <= (float)item.MinMaxDistance.y)
			{
				list2.Add(item.Resource);
			}
		}
		int num3 = UnityEngine.Random.Range(1, Mathf.Min(chestMaxDifferentResources, list2.Count) + 1);
		list2.Shuffle();
		float[] array = FunctionLibrary.DistributePercentage(num3);
		for (int i = 0; i < num3; i++)
		{
			list.Add(new Cost(list2[i], Mathf.CeilToInt(num2 * array[i] / list2[i].Value)));
		}
		chest.Reward = list;
	}

	private void GenerateGoldenCoinsChestLoot(GoldenCoinsChest chest, Vector2Int gridSize)
	{
		float num = Vector3.Distance(chest.transform.position, PlayerTower.transform.position);
		float num2 = 0f;
		float playerTowerInvalidAreaRange = GCCSpawnerData.PlayerTowerInvalidAreaRange;
		float num3 = GCCSpawnerData.DistanceFromBorders;
		float num4 = Vector3.Distance(PlayerTower.transform.position, new Vector3(0f + num3, 0f, 0f + num3));
		if (num4 > num2)
		{
			num2 = num4;
		}
		num4 = Vector3.Distance(PlayerTower.transform.position, new Vector3((float)gridSize.x - num3, 0f, 0f + num3));
		if (num4 > num2)
		{
			num2 = num4;
		}
		num4 = Vector3.Distance(PlayerTower.transform.position, new Vector3(0f + num3, 0f, (float)gridSize.y - num3));
		if (num4 > num2)
		{
			num2 = num4;
		}
		num4 = Vector3.Distance(PlayerTower.transform.position, new Vector3((float)gridSize.x - num3, 0f, (float)gridSize.y - num3));
		if (num4 > num2)
		{
			num2 = num4;
		}
		float t = Mathf.Clamp01((num - playerTowerInvalidAreaRange) / Mathf.Max(1E-05f, num2 - playerTowerInvalidAreaRange));
		float value = UnityEngine.Random.value;
		float a = Mathf.Clamp01(value - 0.5f);
		float b = Mathf.Clamp01(value + 0.5f);
		float t2 = Mathf.Lerp(a, b, t);
		float num5 = MatchInfo.instance?.CurrentMatchSettings?.GoldenCoinMultiplierChests ?? 1f;
		chest.Money = Mathf.CeilToInt((float)Mathf.RoundToInt(Mathf.Lerp(minMaxGoldenCoinsPerChest.x, minMaxGoldenCoinsPerChest.y, t2)) * num5);
	}

	private void GenerateGemsChestLoot(GemsChest chest)
	{
		List<GemData> list = new List<GemData>();
		float num = Vector3.Distance(chest.transform.position, PlayerTower.transform.position);
		int num2 = Mathf.RoundToInt(num * gemsChestValuePerMeter);
		if (gemsChestMaxValue > 0)
		{
			num2 = Math.Min(num2, gemsChestMaxValue);
		}
		List<GemData> list2 = new List<GemData>();
		foreach (GemsChestLootTableData.FGemsChestLoot item in gemsChestLootTable.Loot)
		{
			if (num >= (float)item.MinMaxDistance.x && num <= (float)item.MinMaxDistance.y)
			{
				list2.Add(item.GemData);
			}
		}
		bool flag = false;
		while (num2 > 0 && !flag)
		{
			list2.Shuffle();
			flag = true;
			for (int num3 = list2.Count - 1; num3 >= 0; num3--)
			{
				if (list2[num3].Value <= num2)
				{
					list.Add(list2[num3]);
					num2 -= list2[num3].Value;
					flag = false;
					break;
				}
				list2.RemoveAt(num3);
			}
		}
		chest.Reward = list;
	}

	private BaseSpawnerData.FMapElements GenerateMapElements()
	{
		return new BaseSpawnerData.FMapElements(playerTower, enemyTower, CrystalAltars, pathTiles, obelisks, specialBuildings);
	}
}
