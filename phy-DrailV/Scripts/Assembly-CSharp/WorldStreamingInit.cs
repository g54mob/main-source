using System;
using System.Collections;
using System.Linq;
using AwesomeTechnologies.VegetationSystem;
using DV.Common;
using DV.Localization;
using DV.MultipleUnit;
using DV.RenderTextureSystem;
using DV.TerrainSystem;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using DV.WeatherSystem;
using DV.WorldTools;
using Newtonsoft.Json.Linq;
using Unity.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldStreamingInit : SingletonBehaviour<WorldStreamingInit>
{
	public const string ORIGIN_SHIFT_CONTENT = "[origin shift content]";

	private static bool isLoaded;

	[Header("Prefabs / scenes to load")]
	public GameObject playerInitializerPrefab;

	public GameObject vegetationStudioPrefab;

	[HideInInspector]
	public string terrainsScenePath;

	[HideInInspector]
	public string railwayScenePath;

	public GameObject railwayProcgenPrefab;

	[HideInInspector]
	public string gameContentScenePath;

	[HideInInspector]
	public Transform originShiftParent;

	private Streamer nearScenesStreamer;

	private Streamer farScenesStreamer;

	private TerrainGrid terrainGrid;

	private GameObject audioListenerTempGO;

	private int currentStep;

	public const string INFO_START_GAME_DATA_LOADING = "loading/start_game_data";

	public const string INFO_START_GAME_DATA_MISSING = "loading/start_game_data_missing";

	public const string INFO_VEGETATION = "loading/vegetation";

	public const string INFO_TERRAINS_INIT = "loading/terrains";

	public const string INFO_RAILWAY_SCENE = "loading/railway_layout";

	public const string INFO_RAILWAY_VISUAL = "loading/railway_visuals";

	public const string INFO_STREAMING_INIT = "loading/streaming";

	public const string INFO_GAME_CONTENT = "loading/game_content";

	public const string INFO_PLAYER = "loading/player";

	public const string INFO_CAR_POOLING = "loading/car_pool";

	public const string INFO_SAVEGAME_LOAD = "loading/restoring_game_state";

	public const string INFO_STREAMING_LOAD = "loading/waiting_for_streaming";

	public const string INFO_TERRAINS_LOAD = "loading/waiting_for_terrains";

	public const string INFO_LOADING_FINISHED = "done";

	private const int EXPECTED_STEPS = 14;

	public static bool IsLoaded
	{
		get
		{
			if ((bool)SingletonBehaviour<WorldStreamingInit>.Instance)
			{
				return isLoaded;
			}
			return true;
		}
	}

	public static bool IsStreamingDone { get; private set; }

	public event Action TerrainsOrScenesLoadStateChanged;

	public static event Action<string, bool, float> LoadingStatusChanged;

	public static event Action LoadingFinished;

	protected override void Awake()
	{
		base.Awake();
		StartCoroutine(LoadingRoutine());
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		isLoaded = false;
		if ((bool)nearScenesStreamer)
		{
			nearScenesStreamer.LoadedScenesChanged -= OnTerrainOrLoadedScenesChanged;
		}
		if ((bool)farScenesStreamer)
		{
			farScenesStreamer.LoadedScenesChanged -= OnTerrainOrLoadedScenesChanged;
		}
		if (terrainGrid != null)
		{
			terrainGrid.TerrainsMoved -= OnTerrainOrLoadedScenesChanged;
		}
		PlayerManager.PlayerChanged -= OnPlayerChanged;
		PlayerManager.PlayerChanged -= DestroyTempAudioListener;
		SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
	}

	public bool IsSceneAndTerrainRegionLoaded(Vector3 worldPos)
	{
		if (nearScenesStreamer == null || !nearScenesStreamer.IsSceneLoaded(worldPos))
		{
			return false;
		}
		if (farScenesStreamer == null || !farScenesStreamer.IsSceneLoaded(worldPos))
		{
			return false;
		}
		if (terrainGrid == null || !terrainGrid.IsInLoadedRegion(worldPos))
		{
			return false;
		}
		return true;
	}

	public bool IsSceneAndTerrainCellLoaded(Vector3 worldPos)
	{
		if (nearScenesStreamer == null || !nearScenesStreamer.IsSceneLoaded(worldPos))
		{
			return false;
		}
		if (farScenesStreamer == null || !farScenesStreamer.IsSceneLoaded(worldPos))
		{
			return false;
		}
		if (terrainGrid == null || !terrainGrid.IsInLoadedCell(worldPos))
		{
			return false;
		}
		return true;
	}

	private void OnTerrainOrLoadedScenesChanged()
	{
		this.TerrainsOrScenesLoadStateChanged?.Invoke();
	}

	private void Info(string msg)
	{
		msg = LocalizationAPI.L(msg);
		currentStep++;
		Debug.Log($"[Loading] {msg} (step: {currentStep}, frame: {Time.frameCount})");
		int num = Mathf.RoundToInt((float)currentStep / 14f * 100f);
		if (num > 100)
		{
			Debug.LogError(string.Format("[Loading] {0} value is wrong ({1})", "EXPECTED_STEPS", 14));
		}
		WorldStreamingInit.LoadingStatusChanged?.Invoke(msg, arg2: false, num);
	}

	private void Error(string msg, float percentageLoaded)
	{
		Debug.LogError(msg);
		WorldStreamingInit.LoadingStatusChanged?.Invoke(msg, arg2: true, percentageLoaded);
	}

	private IEnumerator LoadingRoutine()
	{
		isLoaded = false;
		IsStreamingDone = false;
		if (!Validate())
		{
			yield break;
		}
		audioListenerTempGO = new GameObject("[AudioListener temp]");
		audioListenerTempGO.AddComponent<AudioListener>();
		PlayerManager.PlayerChanged += DestroyTempAudioListener;
		AudioListener.volume = 0f;
		originShiftParent = new GameObject("origin_shift_parent").transform;
		SingletonBehaviour<WorldMover>.Instance.SetOriginShiftParent(originShiftParent);
		GameObject playerContainer = new GameObject("[player container]");
		playerContainer.SetActive(value: false);
		SingletonBehaviour<WorldMover>.Instance.playerTracker.SetActualPlayer(playerContainer.transform);
		Info("loading/start_game_data");
		yield return null;
		AStartGameData startGameData = SingletonBehaviour<SaveGameManager>.Instance.FindStartGameData();
		if (startGameData == null)
		{
			Debug.LogError("Got null SaveGameData, starting new career as fallback");
			Info("loading/start_game_data_missing");
			yield return null;
			startGameData = AStartGameData.FallbackNewCareer();
		}
		SaveGameData saveGame = startGameData.GetSaveGameData();
		Info("loading/vegetation");
		yield return null;
		GameObject gameObject = Add(vegetationStudioPrefab);
		VegetationSystemPro vsPro = gameObject.GetComponentInChildren<VegetationSystemPro>();
		vsPro.FloatingOriginAnchor = originShiftParent;
		Info("loading/terrains");
		yield return null;
		SceneManager.LoadScene(terrainsScenePath, LoadSceneMode.Additive);
		yield return null;
		MoveSceneObjectsToOriginShift(terrainsScenePath);
		Info("loading/railway_layout");
		yield return null;
		SceneManager.LoadScene(railwayScenePath, LoadSceneMode.Additive);
		yield return null;
		MoveSceneObjectsToOriginShift(railwayScenePath);
		yield return null;
		_ = SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks;
		Info("loading/railway_visuals");
		yield return null;
		RailwayMeshGenerator componentInChildren = Add(railwayProcgenPrefab).GetComponentInChildren<RailwayMeshGenerator>();
		componentInChildren.chunkReference = SingletonBehaviour<WorldMover>.Instance.playerTracker.GetTrackerTransform();
		componentInChildren.parent = originShiftParent;
		JObject jObject = saveGame.GetJObject("Turntables");
		if (jObject != null)
		{
			TurntableController.LoadData(jObject);
		}
		else
		{
			Debug.LogWarning("Turntables data not found in savegame");
		}
		JObject jObject2 = saveGame.GetJObject(SaveGameKeys.Junctions);
		if (jObject2 != null)
		{
			JunctionsSaveManager.Load(jObject2);
		}
		else
		{
			Debug.LogWarning("Junctions data not found in savegame");
		}
		UnityEngine.Random.InitState(Environment.TickCount);
		Info("loading/game_content");
		yield return null;
		SceneManager.LoadScene(gameContentScenePath, LoadSceneMode.Additive);
		yield return null;
		Scene sceneByPath = SceneManager.GetSceneByPath(gameContentScenePath);
		sceneByPath.GetRootGameObjects().FirstOrDefault((GameObject go) => go.name == "[origin shift content]").Children()
			.ToList()
			.ForEach(delegate(GameObject go)
			{
				go.transform.SetParent(originShiftParent);
			});
		sceneByPath.GetRootGameObjects().ToList().ForEach(delegate(GameObject go)
		{
			SceneManager.MoveGameObjectToScene(go, SceneManager.GetActiveScene());
		});
		Info("loading/player");
		yield return null;
		GameObject playerInitializer = UnityEngine.Object.Instantiate(playerInitializerPrefab, playerContainer.transform);
		playerInitializer.transform.localPosition = Vector3.zero;
		playerInitializer.transform.localRotation = Quaternion.identity;
		Info("loading/car_pool");
		yield return null;
		MultipleUnitModule.SetupAutoCoupling();
		while (SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
		{
			yield return null;
		}
		Info("loading/restoring_game_state");
		yield return null;
		terrainGrid = SingletonBehaviour<TerrainGrid>.Instance;
		terrainGrid.TerrainsMoved += OnTerrainOrLoadedScenesChanged;
		yield return startGameData.DoLoad(playerContainer.transform);
		yield return null;
		SingletonBehaviour<WorldMover>.Instance.ForceMove();
		terrainGrid.trackingReference = SingletonBehaviour<WorldMover>.Instance.playerTracker.GetTrackerTransform();
		DistantTerrain distantTerrain = UnityEngine.Object.FindObjectOfType<DistantTerrain>();
		distantTerrain.trackingReference = terrainGrid.trackingReference;
		distantTerrain.enabled = true;
		Info("loading/waiting_for_terrains");
		Debug.Log("Waiting for TerrainGrid to load terrains");
		yield return null;
		do
		{
			yield return null;
		}
		while (terrainGrid.IsLoadingInProgress());
		playerInitializer.transform.SetParent(playerContainer.transform.parent, worldPositionStays: true);
		SingletonBehaviour<WorldMover>.Instance.playerTracker.SetActualPlayer(playerInitializer.transform);
		UnityEngine.Object.Destroy(playerContainer);
		Info("loading/streaming");
		yield return null;
		Streamer[] streamers = GetComponentsInChildren<Streamer>();
		if (streamers.Any((Streamer s) => s.streamerActive))
		{
			Debug.LogWarning("All streamers should have 'streamerActive' disabled since they need to be enabled from code");
		}
		Streamer[] array = streamers;
		foreach (Streamer streamer in array)
		{
			streamer.streamerActive = true;
			if (streamer.name.ToLower().Contains("near"))
			{
				nearScenesStreamer = streamer;
			}
			else if (streamer.name.ToLower().Contains("far"))
			{
				farScenesStreamer = streamer;
			}
			else
			{
				Debug.LogError("Unexpected state: Unknown streamer " + streamer.name);
			}
			streamer.LoadedScenesChanged += OnTerrainOrLoadedScenesChanged;
		}
		Info("loading/waiting_for_streaming");
		yield return null;
		while (true)
		{
			bool flag = true;
			array = streamers;
			foreach (Streamer streamer2 in array)
			{
				if (streamer2.LoadingProgress < 1f || streamer2.IsBusy)
				{
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
			yield return null;
		}
		IsStreamingDone = true;
		SingletonBehaviour<TerrainHoleManager>.Instance.playerCamera = PlayerManager.PlayerCamera;
		SingletonBehaviour<TerrainHoleManager>.Instance.RefreshHolePositions();
		PlayerManager.PlayerChanged += OnPlayerChanged;
		SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
		yield return null;
		while (!AStartGameData.carsAndJobsLoadingFinished)
		{
			yield return null;
		}
		SingletonBehaviour<WorldMover>.Instance.movingEnabled = true;
		Info("done");
		yield return null;
		while (StationController.allStations.Any((StationController s) => s.ProceduralJobsController.IsJobGenerationActive))
		{
			yield return null;
		}
		while (SingletonBehaviour<WeatherDriver>.Instance == null || SingletonBehaviour<WeatherDriver>.Instance.manager == null)
		{
			yield return null;
		}
		vsPro.SunDirectionalLight = SingletonBehaviour<WeatherDriver>.Instance.manager.LightSource;
		while (SingletonBehaviour<RenderTextureSystem>.Instance.PendingJobs > 0)
		{
			yield return null;
		}
		isLoaded = true;
		WorldStreamingInit.LoadingFinished?.Invoke();
		yield return null;
		if (startGameData.ShouldCreateSaveGameAfterLoad())
		{
			SingletonBehaviour<SaveGameManager>.Instance.Save(SaveType.Manual);
		}
		string message = startGameData.GetPostLoadMessage();
		if (!string.IsNullOrWhiteSpace(message))
		{
			yield return WaitFor.Seconds(3f);
			while (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
			{
				yield return null;
			}
			while (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
			{
				yield return null;
			}
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.uiReferences.popupOk, new PopupLocalizationKeys
			{
				labelKey = message
			});
		}
		yield return null;
		AStartGameData.DestroyAllInstances();
	}

	private bool Validate()
	{
		if (playerInitializerPrefab == null)
		{
			return false;
		}
		if (vegetationStudioPrefab == null)
		{
			return false;
		}
		if (railwayProcgenPrefab == null)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(terrainsScenePath))
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(railwayScenePath))
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(gameContentScenePath))
		{
			return false;
		}
		return true;
	}

	private GameObject Add(GameObject prefab)
	{
		GameObject obj = UnityEngine.Object.Instantiate(prefab);
		obj.transform.SetParent(originShiftParent);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		return obj;
	}

	private void MoveSceneObjectsToOriginShift(string scenePath)
	{
		SceneManager.GetSceneByPath(scenePath).GetRootGameObjects().ToList()
			.ForEach(delegate(GameObject go)
			{
				go.transform.SetParent(originShiftParent, worldPositionStays: true);
			});
	}

	private void OnPlayerChanged()
	{
		SingletonBehaviour<TerrainHoleManager>.Instance.playerCamera = PlayerManager.PlayerCamera;
	}

	private void OnWorldMoved(WorldMover _, Vector3 __)
	{
		SingletonBehaviour<TerrainHoleManager>.Instance.RefreshHolePositions();
	}

	private void DestroyTempAudioListener()
	{
		PlayerManager.PlayerChanged -= DestroyTempAudioListener;
		UnityEngine.Object.Destroy(audioListenerTempGO);
		audioListenerTempGO = null;
	}
}
