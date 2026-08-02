using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Mirror;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class ChunkDataHolder : NetworkBehaviour
{
	public int chunkID;

	public GameObject connectedTerrain;

	[SerializeField]
	private LayerMask validLayers = -1;

	public bool isGenerating;

	public bool isGenerated;

	[Header("Performance Settings")]
	[Tooltip("Maximum milliseconds per frame for spawning objects")]
	[Range(1f, 10f)]
	public float maxMillisecondsPerFrame = 3f;

	[Tooltip("How many raycasts to process in one batch (max 256)")]
	[Range(32f, 256f)]
	public int raycastBatchSize = 128;

	[Tooltip("Spatial grid cell size for distance checking")]
	public float spatialGridCellSize = 10f;

	[Tooltip("Minimum distance between spawned objects")]
	public float minObjectDistance = 2.5f;

	private readonly Dictionary<Vector2Int, List<Vector3>> spatialGrid = new Dictionary<Vector2Int, List<Vector3>>();

	private readonly Stopwatch frameTimer = new Stopwatch();

	private static readonly WaitForSeconds seedWaitDelay = new WaitForSeconds(0.1f);

	public TerrainChunkEditorHelper gridSystem;

	public BiomesAndAreas defaultBiom;

	public List<GridCell> allCells = new List<GridCell>();

	public List<ChunkBiomData> chunkBiomDatas = new List<ChunkBiomData>();

	public bool preLoadTrees;

	public bool preLoadOres;

	public bool preLoadStickAndStones;

	public bool preLoadProgressiveItems;

	public List<int> destroyedTreeIDS = new List<int>();

	public List<int> destroyedMineIDS = new List<int>();

	public List<int> lootedItemIDS = new List<int>();

	public List<GameObject> spawnedObjects = new List<GameObject>();

	public List<PreArrangedChestController> preArrangedChests = new List<PreArrangedChestController>();

	public List<TSPlayerController> activatedPlayers = new List<TSPlayerController>();

	public SyncList<ChunkObjectData> chunkObjectDatas = new SyncList<ChunkObjectData>();

	[Header("Player-Based Chunk Streaming")]
	[Tooltip("Maximum distance from player to load cells")]
	[Range(50f, 500f)]
	public float cellLoadDistance = 200f;

	[Tooltip("How often to update active cells (in seconds)")]
	[Range(0.5f, 5f)]
	public float updateInterval = 1f;

	[Tooltip("Enable debug visualization in Scene view")]
	public bool enableDebugVisualization = true;

	private Dictionary<int, CellActivationData> cellActivationStates = new Dictionary<int, CellActivationData>();

	private Coroutine dynamicUpdateCoroutine;

	public int activeCellCount;

	public int totalSpawnedObjects;

	public int activeObjectCount;

	private int objectIndex;

	private TrainGameManager gameManager => TrainGameManager.Instance;

	public void AddMultipleSelected(BiomesAndAreas biom)
	{
		foreach (int cellID in gridSystem.GetSelectedCellIds().ToList())
		{
			int num = chunkBiomDatas.FindIndex((ChunkBiomData data) => data.cellID == cellID);
			if (num != -1)
			{
				ChunkBiomData value = chunkBiomDatas[num];
				if (value.biomesAndAreas == null)
				{
					value.biomesAndAreas = new List<BiomesAndAreas>();
				}
				if (!value.biomesAndAreas.Contains(biom))
				{
					value.biomesAndAreas.Add(biom);
				}
				chunkBiomDatas[num] = value;
			}
			else
			{
				ChunkBiomData item = new ChunkBiomData
				{
					cellID = cellID,
					biomesAndAreas = new List<BiomesAndAreas> { biom }
				};
				chunkBiomDatas.Add(item);
			}
		}
	}

	public void LoadPreGeneratedObjects()
	{
		spawnedObjects.Clear();
		int num = 0;
		BreakableObject[] componentsInChildren = base.transform.parent.GetComponentsInChildren<BreakableObject>();
		foreach (BreakableObject obj in componentsInChildren)
		{
			GameObject item = obj.gameObject;
			obj.objectServerData.cellID = chunkID;
			obj.objectServerData.objectID = num;
			obj.Register();
			num++;
			spawnedObjects.Add(item);
		}
	}

	public void LoadPreArrangedChests()
	{
		preArrangedChests.Clear();
		int num = 0;
		PreArrangedChestController[] componentsInChildren = base.transform.parent.GetComponentsInChildren<PreArrangedChestController>();
		foreach (PreArrangedChestController preArrangedChestController in componentsInChildren)
		{
			preArrangedChestController.chunkID = chunkID;
			preArrangedChestController.objectID = num;
			preArrangedChestController.Register();
			num++;
			preArrangedChests.Add(preArrangedChestController);
		}
		UnityEngine.Debug.Log($"[ChunkDataHolder {chunkID}] Registered {preArrangedChests.Count} PreArranged Chests");
	}

	public void DeleteDuplicatedPrespawnedObjects()
	{
		if (spawnedObjects == null || spawnedObjects.Count == 0)
		{
			UnityEngine.Debug.LogWarning("[ChunkDataHolder] No spawned objects to check for duplicates.");
		}
		else
		{
			StartCoroutine(DeleteDuplicatesCoroutine());
		}
	}

	private IEnumerator DeleteDuplicatesCoroutine()
	{
		UnityEngine.Debug.Log($"[ChunkDataHolder] Starting duplicate check for {spawnedObjects.Count} objects...");
		float num = 0.8f;
		float duplicateDistanceSqr = num * num;
		Dictionary<Vector2Int, List<int>> duplicateSpatialGrid = new Dictionary<Vector2Int, List<int>>();
		float gridCellSize = 1f;
		UnityEngine.Debug.Log("[ChunkDataHolder] Phase 1: Building spatial grid...");
		for (int i = 0; i < spawnedObjects.Count; i++)
		{
			if (!(spawnedObjects[i] == null))
			{
				Vector3 position = spawnedObjects[i].transform.position;
				Vector2Int key = new Vector2Int(Mathf.FloorToInt(position.x / gridCellSize), Mathf.FloorToInt(position.z / gridCellSize));
				if (!duplicateSpatialGrid.ContainsKey(key))
				{
					duplicateSpatialGrid[key] = new List<int>();
				}
				duplicateSpatialGrid[key].Add(i);
				if (i % 1000 == 0)
				{
					yield return null;
				}
			}
		}
		UnityEngine.Debug.Log("[ChunkDataHolder] Phase 2: Finding duplicates...");
		HashSet<int> indicesToRemove = new HashSet<int>();
		int processed = 0;
		foreach (KeyValuePair<Vector2Int, List<int>> item in duplicateSpatialGrid)
		{
			Vector2Int key2 = item.Key;
			List<int> value = item.Value;
			for (int j = -1; j <= 1; j++)
			{
				for (int k = -1; k <= 1; k++)
				{
					Vector2Int key3 = new Vector2Int(key2.x + j, key2.y + k);
					if (!duplicateSpatialGrid.ContainsKey(key3))
					{
						continue;
					}
					List<int> list = duplicateSpatialGrid[key3];
					foreach (int item2 in value)
					{
						if (spawnedObjects[item2] == null || indicesToRemove.Contains(item2))
						{
							continue;
						}
						foreach (int item3 in list)
						{
							if (item2 < item3 && !(spawnedObjects[item3] == null) && !indicesToRemove.Contains(item3))
							{
								Vector3 position2 = spawnedObjects[item2].transform.position;
								Vector3 position3 = spawnedObjects[item3].transform.position;
								if ((position2 - position3).sqrMagnitude < duplicateDistanceSqr)
								{
									indicesToRemove.Add(item3);
								}
							}
						}
					}
				}
			}
			processed++;
			if (processed % 100 == 0)
			{
				UnityEngine.Debug.Log($"[ChunkDataHolder] Progress: {processed}/{duplicateSpatialGrid.Count} cells checked, {indicesToRemove.Count} duplicates found");
				yield return null;
			}
		}
		UnityEngine.Debug.Log($"[ChunkDataHolder] Phase 3: Removing {indicesToRemove.Count} duplicates...");
		List<int> list2 = indicesToRemove.OrderByDescending((int x) => x).ToList();
		int removed = 0;
		foreach (int item4 in list2)
		{
			if (item4 < spawnedObjects.Count && spawnedObjects[item4] != null)
			{
				GameObject obj = spawnedObjects[item4];
				spawnedObjects.RemoveAt(item4);
				Object.DestroyImmediate(obj);
				removed++;
				if (removed % 500 == 0)
				{
					UnityEngine.Debug.Log($"[ChunkDataHolder] Removed {removed}/{indicesToRemove.Count} objects...");
					yield return null;
				}
			}
		}
		UnityEngine.Debug.Log("[ChunkDataHolder] Phase 4: Reassigning object IDs...");
		for (int i = 0; i < spawnedObjects.Count; i++)
		{
			if (spawnedObjects[i] != null)
			{
				BreakableObject component = spawnedObjects[i].GetComponent<BreakableObject>();
				if (component != null)
				{
					component.objectServerData.objectID = i;
					component.Register();
				}
			}
			if (i % 1000 == 0)
			{
				yield return null;
			}
		}
		UnityEngine.Debug.Log($"[ChunkDataHolder] ✓ Duplicate cleanup complete! Removed {removed} objects. Remaining: {spawnedObjects.Count}");
	}

	private void OnEnable()
	{
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(RegisterPlayer);
		StartCoroutine(SetDistance());
	}

	private void OnDisable()
	{
		if (Singleton<TSNetworkObjetManager>.Instance != null)
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.RemoveListener(RegisterPlayer);
		}
		if (dynamicUpdateCoroutine != null)
		{
			StopCoroutine(dynamicUpdateCoroutine);
		}
	}

	public void RegisterPlayer(TSPlayerController player)
	{
		if (!(player == null) && !activatedPlayers.Contains(player))
		{
			activatedPlayers.Add(player);
			if (activatedPlayers.Count == 1 && dynamicUpdateCoroutine == null)
			{
				dynamicUpdateCoroutine = StartCoroutine(DynamicCellUpdateCoroutine());
			}
			UpdateActiveCellsBasedOnPlayers();
		}
	}

	public void UnregisterPlayer(TSPlayerController player)
	{
		if (!(player == null) && activatedPlayers.Contains(player))
		{
			activatedPlayers.Remove(player);
			if (activatedPlayers.Count == 0 && dynamicUpdateCoroutine != null)
			{
				StopCoroutine(dynamicUpdateCoroutine);
				dynamicUpdateCoroutine = null;
				DeactivateAllCells();
			}
			else
			{
				UpdateActiveCellsBasedOnPlayers();
			}
		}
	}

	private IEnumerator SetDistance()
	{
		yield return new WaitForFixedUpdate();
	}

	private void Start()
	{
		StartCoroutine(WaitForSeedInitialization());
	}

	private IEnumerator WaitForSeedInitialization()
	{
		while (TrainGameManager.Instance == null || TrainGameManager.Instance.seed == 0)
		{
			yield return seedWaitDelay;
		}
		if ((preLoadTrees || preLoadOres || preLoadStickAndStones || preLoadProgressiveItems) && spawnedObjects.Count > 0)
		{
			if (base.isServer)
			{
				StartCoroutine(RegisterPreloadedObjectsToNetwork());
			}
			else
			{
				StartCoroutine(SyncWithNetworkData());
			}
		}
	}

	private IEnumerator DynamicCellUpdateCoroutine()
	{
		WaitForSeconds waitInterval = new WaitForSeconds(updateInterval);
		while (true)
		{
			yield return waitInterval;
			if (activatedPlayers.Count > 0)
			{
				UpdateActiveCellsBasedOnPlayers();
			}
		}
	}

	private void UpdateActiveCellsBasedOnPlayers()
	{
		if (activatedPlayers.Count == 0)
		{
			DeactivateAllCells();
			return;
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (TSPlayerController activatedPlayer in activatedPlayers)
		{
			if (activatedPlayer == null)
			{
				continue;
			}
			Vector3 position = activatedPlayer.transform.position;
			foreach (GridCell allCell in allCells)
			{
				if (Vector3.Distance(allCell.position, position) <= cellLoadDistance)
				{
					hashSet.Add(allCell.id);
				}
			}
		}
		foreach (int item in hashSet)
		{
			if (!cellActivationStates.ContainsKey(item))
			{
				ActivateCell(item);
			}
			else if (!cellActivationStates[item].isActive)
			{
				ReactivateCell(item);
			}
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, CellActivationData> cellActivationState in cellActivationStates)
		{
			if (cellActivationState.Value.isActive && !hashSet.Contains(cellActivationState.Key))
			{
				list.Add(cellActivationState.Key);
			}
		}
		foreach (int item2 in list)
		{
			DeactivateCell(item2);
		}
	}

	private void ActivateCell(int cellId)
	{
		if (allCells.Find((GridCell x) => x.id == cellId) != null)
		{
			CellActivationData value = new CellActivationData
			{
				isActive = true,
				spawnedObjectsInCell = new List<GameObject>(),
				isGenerated = false
			};
			cellActivationStates[cellId] = value;
			StartCoroutine(GenerateCellObjects(cellId));
		}
	}

	private void ReactivateCell(int cellId)
	{
		if (!cellActivationStates.ContainsKey(cellId))
		{
			return;
		}
		CellActivationData value = cellActivationStates[cellId];
		value.isActive = true;
		cellActivationStates[cellId] = value;
		foreach (GameObject item in value.spawnedObjectsInCell)
		{
			if (item != null)
			{
				item.SetActive(value: true);
			}
		}
	}

	private void DeactivateCell(int cellId)
	{
		if (!cellActivationStates.ContainsKey(cellId))
		{
			return;
		}
		CellActivationData value = cellActivationStates[cellId];
		value.isActive = false;
		cellActivationStates[cellId] = value;
		foreach (GameObject item in value.spawnedObjectsInCell)
		{
			if (item != null)
			{
				item.SetActive(value: false);
			}
		}
	}

	private void DeactivateAllCells()
	{
		foreach (KeyValuePair<int, CellActivationData> cellActivationState in cellActivationStates)
		{
			if (cellActivationState.Value.isActive)
			{
				DeactivateCell(cellActivationState.Key);
			}
		}
	}

	private IEnumerator GenerateCellObjects(int cellId)
	{
		if (!cellActivationStates.ContainsKey(cellId))
		{
			yield break;
		}
		CellActivationData data = cellActivationStates[cellId];
		if (data.isGenerated)
		{
			yield break;
		}
		if (base.isServer && NetworkSceneObjectSpawner.Instance != null && !NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded)
		{
			yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance == null || NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded);
		}
		List<BiomesAndAreas> biomes = null;
		if (chunkBiomDatas.Any((ChunkBiomData x) => x.cellID == cellId))
		{
			biomes = chunkBiomDatas.Find((ChunkBiomData x) => x.cellID == cellId).biomesAndAreas;
		}
		yield return StartCoroutine(PlaceObjectsInCellOptimized(biomes, cellId));
		data.isGenerated = true;
		cellActivationStates[cellId] = data;
	}

	public void SetCellPositionAccordingToPlayer(TSPlayerController player)
	{
		allCells = allCells.OrderBy((GridCell cell) => Vector3.Distance(cell.position, player.transform.position)).ToList();
		GenerateMap(gameManager.seed);
	}

	public void RemoveSelecteds()
	{
		foreach (int item in gridSystem.GetSelectedCellIds().ToList())
		{
			if (chunkBiomDatas.Where((ChunkBiomData x) => x.cellID == item).Any())
			{
				ChunkBiomData item2 = chunkBiomDatas.Find((ChunkBiomData x) => x.cellID == item);
				chunkBiomDatas.Remove(item2);
			}
		}
	}

	public void GetAllCells()
	{
		allCells.Clear();
		allCells = gridSystem.GetAllCells();
	}

	public void GenerateMap(int gameSeed)
	{
		Random.InitState(gameSeed);
		if (preLoadTrees || preLoadOres || preLoadStickAndStones || preLoadProgressiveItems)
		{
			LoadPreGeneratedObjects();
			if (base.isServer)
			{
				StartCoroutine(RegisterPreloadedObjectsToNetwork());
			}
			else
			{
				StartCoroutine(SyncWithNetworkData());
			}
		}
		UnityEngine.Debug.Log($"[ChunkDataHolder {chunkID}] Map generation initialized. Waiting for players to activate cells.");
	}

	private IEnumerator RegisterPreloadedObjectsToNetwork()
	{
		yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance != null);
		yield return new WaitUntil(() => Singleton<ES3SaveManager>.Instance != null);
		yield return null;
		if (!NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded)
		{
			UnityEngine.Debug.Log($"[ChunkDataHolder {chunkID}] Forcing load of saved world object states");
			NetworkSceneObjectSpawner.Instance.LoadWorldObjectStates();
		}
		UnityEngine.Debug.Log($"[ChunkDataHolder {chunkID}] Save data ready ({NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded}), registering {spawnedObjects.Count} preloaded objects");
		List<GameObject> list = new List<GameObject>();
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject == null)
			{
				continue;
			}
			BreakableObject component = spawnedObject.GetComponent<BreakableObject>();
			if (component == null)
			{
				continue;
			}
			component.MarkAsPreloaded();
			WorldObjectSaveData savedObjectState = NetworkSceneObjectSpawner.Instance.GetSavedObjectState(component.objectServerData.cellID, component.objectServerData.objectID);
			UnityEngine.Debug.Log($"[ChunkDataHolder {chunkID}] Object cellID={component.objectServerData.cellID}, objectID={component.objectServerData.objectID}, savedState={savedObjectState != null}, name={spawnedObject.name}");
			if (savedObjectState != null)
			{
				if (savedObjectState.isDestroyed)
				{
					component.objectServerData.health = savedObjectState.health;
					component.objectServerData.isDestroyed = true;
					component.objectServerData.isLootable = savedObjectState.isLootable;
					NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(component.objectServerData);
					list.Add(spawnedObject);
					Object.Destroy(spawnedObject);
					UnityEngine.Debug.Log($"SERVER: Destroyed saved object - cellID={component.objectServerData.cellID}, objectID={component.objectServerData.objectID}");
					continue;
				}
				component.objectServerData.health = savedObjectState.health;
				component.objectServerData.isLootable = savedObjectState.isLootable;
				TreeCollectable component2 = spawnedObject.GetComponent<TreeCollectable>();
				if (component2 != null)
				{
					component2.InitializeForPreload(savedObjectState.health);
				}
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(component.objectServerData);
				UnityEngine.Debug.Log($"SERVER: Restored object - cellID={component.objectServerData.cellID}, objectID={component.objectServerData.objectID}, health={savedObjectState.health}");
			}
			else
			{
				TreeCollectable component3 = spawnedObject.GetComponent<TreeCollectable>();
				if (component3 != null)
				{
					Random.InitState(gameManager.seed + chunkID + component.objectServerData.objectID);
					component.objectServerData.health = Random.Range(component3.healthRange.x, component3.healthRange.y);
					component3.InitializeForPreload(component.objectServerData.health);
				}
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(component.objectServerData);
				UnityEngine.Debug.Log($"SERVER: Registered object - cellID={component.objectServerData.cellID}, objectID={component.objectServerData.objectID}");
			}
		}
		foreach (GameObject item in list)
		{
			spawnedObjects.Remove(item);
		}
	}

	private IEnumerator SyncWithNetworkData()
	{
		yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance != null);
		yield return new WaitForSeconds(1f);
		SyncList<ObjectServerData> changedList = NetworkSceneObjectSpawner.Instance.changedObjectServerDatas;
		UnityEngine.Debug.Log($"CLIENT: Starting sync. Network list has {changedList.Count} objects");
		Dictionary<int, BreakableObject> localByObjectID = new Dictionary<int, BreakableObject>(spawnedObjects.Count);
		int initBudget = 0;
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject == null)
			{
				continue;
			}
			BreakableObject component = spawnedObject.GetComponent<BreakableObject>();
			if (!(component == null))
			{
				component.MarkAsPreloaded();
				localByObjectID[component.objectServerData.objectID] = component;
				TreeCollectable component2 = spawnedObject.GetComponent<TreeCollectable>();
				if (component2 != null)
				{
					Random.InitState(gameManager.seed + chunkID + component.objectServerData.objectID);
					float health = Random.Range(component2.healthRange.x, component2.healthRange.y);
					component.objectServerData.health = health;
					component2.InitializeForPreload(health);
				}
				int num = initBudget + 1;
				initBudget = num;
				if (num >= 64)
				{
					initBudget = 0;
					yield return null;
				}
			}
		}
		int processed = 0;
		for (int i = 0; i < changedList.Count; i++)
		{
			ObjectServerData objectServerData = changedList[i];
			if (objectServerData.cellID != chunkID)
			{
				continue;
			}
			if (localByObjectID.TryGetValue(objectServerData.objectID, out var value) && value != null)
			{
				GameObject gameObject = value.gameObject;
				value.objectServerData = objectServerData;
				if (objectServerData.isDestroyed || objectServerData.health <= 0f)
				{
					spawnedObjects.Remove(gameObject);
					localByObjectID.Remove(objectServerData.objectID);
					Object.Destroy(gameObject);
				}
				else
				{
					TreeCollectable component3 = gameObject.GetComponent<TreeCollectable>();
					if (component3 != null)
					{
						component3.UpdateHealthFromServer(objectServerData.health);
					}
					LootableTerrainItemProgressive component4 = gameObject.GetComponent<LootableTerrainItemProgressive>();
					if (component4 != null)
					{
						component4.UpdateHealthFromServer(objectServerData.health);
					}
				}
			}
			int num = processed + 1;
			processed = num;
			if (num >= 64)
			{
				processed = 0;
				yield return null;
			}
		}
	}

	public void ClearGeneratedMapObjects()
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			Object.DestroyImmediate(spawnedObject.gameObject);
		}
		ClearSpawnedObjects();
		cellActivationStates.Clear();
	}

	public void PlaceObjects()
	{
		if (isGenerating || isGenerated)
		{
			UnityEngine.Debug.LogWarning($"[ChunkDataHolder] Chunk {chunkID} is already generating or generated. Skipping.");
			return;
		}
		if (!preLoadTrees && !preLoadOres && !preLoadStickAndStones && !preLoadProgressiveItems)
		{
			ClearGeneratedMapObjects();
		}
		UnityEngine.Debug.LogWarning("[ChunkDataHolder] PlaceObjects() is deprecated. Using OLD SYSTEM to generate ALL objects at once. Consider using player-based streaming for better performance.");
		StartCoroutine(PlaceObjectsCoroutine());
	}

	private IEnumerator PlaceObjectsCoroutine()
	{
		isGenerating = true;
		spatialGrid.Clear();
		foreach (GridCell cell in allCells)
		{
			List<BiomesAndAreas> biomes = null;
			if (chunkBiomDatas.Any((ChunkBiomData x) => x.cellID == cell.id))
			{
				biomes = chunkBiomDatas.Find((ChunkBiomData x) => x.cellID == cell.id).biomesAndAreas;
			}
			yield return StartCoroutine(PlaceObjectsInCellOptimized(biomes, cell.id));
		}
		isGenerating = false;
		isGenerated = true;
	}

	private IEnumerator PlaceObjectsInCellOptimized(List<BiomesAndAreas> biomes, int gridCellId)
	{
		Random.InitState(gameManager.seed + gridCellId);
		objectIndex = 0;
		List<BiomesAndAreas> chunkBiomes = biomes ?? new List<BiomesAndAreas> { defaultBiom };
		GridCell gridCell = allCells.Find((GridCell x) => x.id == gridCellId);
		if (gridCell == null)
		{
			UnityEngine.Debug.LogWarning($"Grid cell {gridCellId} not found!");
			yield break;
		}
		Vector3 position = gridCell.position;
		Vector3 size = gridCell.size;
		spatialGrid.Clear();
		List<PotentialSpawn> potentialSpawns = new List<PotentialSpawn>();
		if (!preLoadTrees)
		{
			foreach (PrefabDestinationDatas treePrefab in gameManager.treePrefabs)
			{
				GenerateSpawnPositions(position, size, treePrefab, chunkBiomes, gridCellId, potentialSpawns);
			}
		}
		if (!preLoadOres)
		{
			foreach (PrefabDestinationDatas miningPrefab in gameManager.miningPrefabs)
			{
				GenerateSpawnPositions(position, size, miningPrefab, chunkBiomes, gridCellId, potentialSpawns);
			}
		}
		if (!preLoadStickAndStones)
		{
			foreach (PrefabDestinationDatas sticksAndStone in gameManager.sticksAndStones)
			{
				GenerateSpawnPositions(position, size, sticksAndStone, chunkBiomes, gridCellId, potentialSpawns);
			}
		}
		if (potentialSpawns.Count != 0)
		{
			yield return StartCoroutine(BatchRaycastValidation(potentialSpawns));
			yield return StartCoroutine(SpawnObjectsWithBudget(potentialSpawns));
		}
	}

	private void GenerateSpawnPositions(Vector3 cellPosition, Vector3 cellSize, PrefabDestinationDatas prefabData, List<BiomesAndAreas> chunkBiomes, int gridCellId, List<PotentialSpawn> potentialSpawns)
	{
		int hashCode = prefabData.prefab.name.GetHashCode();
		Random.InitState(gameManager.seed + gridCellId + hashCode);
		float num = prefabData.destinationPerChunk;
		foreach (SpeacialBiomAreas specialBiome in prefabData.specialBiomes)
		{
			if (chunkBiomes.Contains(specialBiome.biomType))
			{
				num = specialBiome.overrideDestinationPerChunk;
				break;
			}
		}
		int num2 = Mathf.FloorToInt(num);
		float num3 = num - (float)num2;
		float value = Random.value;
		int num4 = num2;
		if (value < num3)
		{
			num4++;
		}
		if (num4 <= 0)
		{
			return;
		}
		int num5 = 0;
		int num6 = num4 * 20;
		for (int i = 0; i < num6; i++)
		{
			if (num5 >= num4)
			{
				break;
			}
			Vector3 position = cellPosition + new Vector3(Random.Range((0f - cellSize.x) / 2f, cellSize.x / 2f), 0f, Random.Range((0f - cellSize.z) / 2f, cellSize.z / 2f));
			if (!IsTooCloseSpatialHash(position, minObjectDistance))
			{
				PotentialSpawn item = new PotentialSpawn
				{
					position = position,
					prefab = prefabData.prefab,
					rotation = Random.Range(0f, 360f),
					scale = Random.Range(0.85f, 1.15f),
					isValid = false,
					gridCellId = gridCellId,
					objectIndex = objectIndex++
				};
				potentialSpawns.Add(item);
				AddToSpatialGrid(position);
				num5++;
			}
		}
	}

	private Vector2Int GetGridKey(Vector3 position)
	{
		return new Vector2Int(Mathf.FloorToInt(position.x / spatialGridCellSize), Mathf.FloorToInt(position.z / spatialGridCellSize));
	}

	private void AddToSpatialGrid(Vector3 position)
	{
		Vector2Int gridKey = GetGridKey(position);
		if (!spatialGrid.ContainsKey(gridKey))
		{
			spatialGrid[gridKey] = new List<Vector3>();
		}
		spatialGrid[gridKey].Add(position);
	}

	private bool IsTooCloseSpatialHash(Vector3 position, float minDistance)
	{
		Vector2Int gridKey = GetGridKey(position);
		float num = minDistance * minDistance;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				Vector2Int key = new Vector2Int(gridKey.x + i, gridKey.y + j);
				if (!spatialGrid.TryGetValue(key, out var value))
				{
					continue;
				}
				foreach (Vector3 item in value)
				{
					if ((position - item).sqrMagnitude < num)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private IEnumerator BatchRaycastValidation(List<PotentialSpawn> spawns)
	{
		int totalSpawns = spawns.Count;
		int processedCount = 0;
		if (validLayers.value == 0)
		{
			validLayers = -1;
		}
		for (int i = 0; i < totalSpawns; i += raycastBatchSize)
		{
			int currentBatchSize = Mathf.Min(raycastBatchSize, totalSpawns - i);
			NativeArray<RaycastCommand> commands = new NativeArray<RaycastCommand>(currentBatchSize, Allocator.TempJob);
			NativeArray<RaycastHit> results = new NativeArray<RaycastHit>(currentBatchSize, Allocator.TempJob);
			for (int j = 0; j < currentBatchSize; j++)
			{
				PotentialSpawn potentialSpawn = spawns[i + j];
				QueryParameters queryParameters = new QueryParameters
				{
					layerMask = -1,
					hitBackfaces = false,
					hitTriggers = QueryTriggerInteraction.Collide,
					hitMultipleFaces = false
				};
				commands[j] = new RaycastCommand(potentialSpawn.position + Vector3.up * 1000f, Vector3.down, queryParameters, 2000f);
			}
			JobHandle handle = RaycastCommand.ScheduleBatch(commands, results, 32);
			yield return new WaitUntil(() => handle.IsCompleted);
			handle.Complete();
			for (int num = 0; num < currentBatchSize; num++)
			{
				RaycastHit raycastHit = results[num];
				if (raycastHit.collider != null)
				{
					int layer = raycastHit.collider.gameObject.layer;
					if (((1 << layer) & validLayers.value) != 0 && Vector3.Angle(raycastHit.normal, Vector3.up) < 45f)
					{
						PotentialSpawn value = spawns[i + num];
						value.isValid = true;
						value.groundPosition = raycastHit.point;
						spawns[i + num] = value;
						processedCount++;
					}
				}
			}
			commands.Dispose();
			results.Dispose();
			yield return null;
		}
	}

	private IEnumerator SpawnObjectsWithBudget(List<PotentialSpawn> spawns)
	{
		frameTimer.Restart();
		foreach (PotentialSpawn spawn in spawns)
		{
			if (!spawn.isValid)
			{
				continue;
			}
			GameObject gameObject = Object.Instantiate(spawn.prefab, spawn.groundPosition, Quaternion.Euler(0f, spawn.rotation, 0f), base.transform);
			gameObject.transform.localScale *= spawn.scale;
			spawnedObjects.Add(gameObject);
			BreakableObject component = gameObject.GetComponent<BreakableObject>();
			if (component != null)
			{
				component.objectServerData.cellID = spawn.gridCellId;
				component.objectServerData.objectID = spawn.objectIndex;
				component.Register();
				if (base.isServer)
				{
					if (NetworkSceneObjectSpawner.Instance != null)
					{
						WorldObjectSaveData savedObjectState = NetworkSceneObjectSpawner.Instance.GetSavedObjectState(spawn.gridCellId, spawn.objectIndex);
						if (savedObjectState != null && savedObjectState.isDestroyed)
						{
							component.objectServerData.isDestroyed = true;
							component.objectServerData.isLootable = savedObjectState.isLootable;
							NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(component.objectServerData);
							spawnedObjects.Remove(gameObject);
							Object.Destroy(gameObject);
							continue;
						}
						if (savedObjectState != null)
						{
							component.objectServerData.health = savedObjectState.health;
							component.objectServerData.isLootable = savedObjectState.isLootable;
							NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(component.objectServerData);
						}
					}
				}
				else if (NetworkSceneObjectSpawner.Instance != null)
				{
					ObjectServerData networkObjectState = NetworkSceneObjectSpawner.Instance.GetNetworkObjectState(spawn.gridCellId, spawn.objectIndex);
					if (networkObjectState != null && (networkObjectState.isDestroyed || networkObjectState.health <= 0f))
					{
						spawnedObjects.Remove(gameObject);
						Object.Destroy(gameObject);
						continue;
					}
					if (networkObjectState != null)
					{
						component.objectServerData.health = networkObjectState.health;
						component.objectServerData.isLootable = networkObjectState.isLootable;
						LootableTerrainItemProgressive component2 = gameObject.GetComponent<LootableTerrainItemProgressive>();
						if (component2 != null)
						{
							component2.UpdateHealthFromServer(networkObjectState.health);
						}
						TreeCollectable component3 = gameObject.GetComponent<TreeCollectable>();
						if (component3 != null)
						{
							component3.UpdateHealthFromServer(networkObjectState.health);
						}
					}
				}
			}
			if (cellActivationStates.ContainsKey(spawn.gridCellId))
			{
				CellActivationData value = cellActivationStates[spawn.gridCellId];
				if (value.spawnedObjectsInCell == null)
				{
					value.spawnedObjectsInCell = new List<GameObject>();
				}
				value.spawnedObjectsInCell.Add(gameObject);
				cellActivationStates[spawn.gridCellId] = value;
			}
			if (frameTimer.Elapsed.TotalMilliseconds > (double)maxMillisecondsPerFrame)
			{
				yield return null;
				frameTimer.Restart();
			}
		}
	}

	private void ClearSpawnedObjects()
	{
		foreach (GameObject spawnedObject in spawnedObjects)
		{
			if (spawnedObject != null)
			{
				Object.DestroyImmediate(spawnedObject);
			}
		}
		spawnedObjects.Clear();
	}

	private void UpdateDebugStats()
	{
		activeCellCount = 0;
		activeObjectCount = 0;
		foreach (KeyValuePair<int, CellActivationData> cellActivationState in cellActivationStates)
		{
			if (cellActivationState.Value.isActive)
			{
				activeCellCount++;
				if (cellActivationState.Value.spawnedObjectsInCell != null)
				{
					activeObjectCount += cellActivationState.Value.spawnedObjectsInCell.Count;
				}
			}
		}
		totalSpawnedObjects = spawnedObjects.Count;
	}

	private void OnDrawGizmos()
	{
		if (!enableDebugVisualization || allCells == null || allCells.Count == 0)
		{
			return;
		}
		foreach (GridCell allCell in allCells)
		{
			if (cellActivationStates.ContainsKey(allCell.id) && cellActivationStates[allCell.id].isActive)
			{
				Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
			}
			else if (cellActivationStates.ContainsKey(allCell.id) && !cellActivationStates[allCell.id].isGenerated)
			{
				Gizmos.color = new Color(1f, 1f, 0f, 0.1f);
			}
			else
			{
				Gizmos.color = new Color(1f, 0f, 0f, 0.05f);
			}
			Gizmos.DrawCube(allCell.position, allCell.size);
		}
		if (activatedPlayers == null || activatedPlayers.Count <= 0)
		{
			return;
		}
		Gizmos.color = new Color(0f, 0.5f, 1f, 0.3f);
		foreach (TSPlayerController activatedPlayer in activatedPlayers)
		{
			if (activatedPlayer != null)
			{
				Gizmos.DrawWireSphere(activatedPlayer.transform.position, cellLoadDistance);
			}
		}
	}

	private void Update()
	{
		if (Application.isPlaying)
		{
			UpdateDebugStats();
		}
	}

	public void ForceUpdateActiveCells()
	{
		UpdateActiveCellsBasedOnPlayers();
	}

	public void DeactivateAllCellsManually()
	{
		DeactivateAllCells();
	}

	public void LogChunkStreamingStatus()
	{
		UnityEngine.Debug.Log($"=== Chunk {chunkID} Streaming Status ===");
		UnityEngine.Debug.Log($"Active Players: {activatedPlayers.Count}");
		UnityEngine.Debug.Log($"Active Cells: {activeCellCount}");
		UnityEngine.Debug.Log($"Total Spawned Objects: {totalSpawnedObjects}");
		UnityEngine.Debug.Log($"Active Objects: {activeObjectCount}");
		UnityEngine.Debug.Log($"Cell Load Distance: {cellLoadDistance}m");
		UnityEngine.Debug.Log($"Update Interval: {updateInterval}s");
		foreach (TSPlayerController activatedPlayer in activatedPlayers)
		{
			if (activatedPlayer != null)
			{
				UnityEngine.Debug.Log($"  - Player: {activatedPlayer.name} at {activatedPlayer.transform.position}");
			}
		}
	}

	public ChunkDataHolder()
	{
		InitSyncObject(chunkObjectDatas);
	}

	public override bool Weaved()
	{
		return true;
	}
}
