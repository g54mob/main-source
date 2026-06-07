using System;
using System.Collections;
using System.Linq;
using AwesomeTechnologies.VegetationSystem;
using DV.Telemetry;
using DV.TerrainSystem;
using DV.Utils;
using DV.WorldTools;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BenchmarkSetup : SingletonBehaviour<BenchmarkSetup>
{
	public delegate void ContinueCallback();

	private const int LOADING_COOLDOWN_FRAMES = 60;

	[Header("Behavior")]
	public bool allowNoRunners;

	[Header("Components")]
	public PlayerTracker tracker;

	public Transform playerTransform;

	public Transform originShiftParent;

	public Streamer[] streamers;

	public TerrainGrid terrainGrid;

	public VegetationSystemPro vegetation;

	public GameObject loadingScreen;

	[Header("Scenes")]
	public string railwayScenePath = "Assets/DV/World/Work/loading/railway_w3_LFS.unity";

	public string terrainsScenePath = "Assets/DV/World/Work/loading/terrains_w3.unity";

	[Header("Hooks")]
	public GameObject[] instantiateOnAwake;

	public GameObject[] instantiateOnStart;

	public UnityEvent awakeEvent;

	public UnityEvent startEvent;

	public static Type benchmarkRunner;

	public static ContinueCallback continueCallback;

	public static PerformanceTelemetry.Stats? lastRunStats;

	private int loadingCooldown;

	private bool startFired;

	public bool IsAwoken { get; private set; }

	public bool AreTracksLoaded { get; private set; }

	public bool IsLoaded { get; private set; }

	public TextMeshProUGUI OSDLabel { get; private set; }

	public bool AreStreamersStreaming
	{
		get
		{
			Streamer[] array = streamers;
			foreach (Streamer streamer in array)
			{
				if (streamer.streamerActive && (streamer.IsBusy || streamer.LoadingProgress < 1f))
				{
					loadingCooldown = 60;
					return true;
				}
			}
			return false;
		}
	}

	public bool IsStreaming
	{
		get
		{
			if (terrainGrid.IsLoadingInProgress())
			{
				loadingCooldown = 60;
				return true;
			}
			if (vegetation.IsLoading)
			{
				loadingCooldown = 60;
				return true;
			}
			if (AreStreamersStreaming)
			{
				loadingCooldown = 60;
				return true;
			}
			if (loadingCooldown > 0)
			{
				loadingCooldown--;
				return true;
			}
			return false;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		lastRunStats = null;
		PlayerManager.SetPlayer(playerTransform, playerTransform.GetComponent<Camera>());
		GameObject[] array = instantiateOnAwake;
		for (int i = 0; i < array.Length; i++)
		{
			UnityEngine.Object.Instantiate(array[i]);
		}
		if (benchmarkRunner != null)
		{
			Transform transform = base.transform.Find(benchmarkRunner.Name);
			if (!transform)
			{
				Debug.LogError("No benchmark runner object named '" + benchmarkRunner.Name + "' was found, aborting");
				EndWith(null);
				return;
			}
			if (!transform.GetComponent(benchmarkRunner))
			{
				if (allowNoRunners)
				{
					IsAwoken = true;
					awakeEvent.Invoke();
					StartCoroutine(LoadAndWait());
				}
				else
				{
					Debug.LogError("Benchmark runner object doesn't have a " + benchmarkRunner.Name + " component on it, aborting");
					EndWith(null);
				}
				return;
			}
			transform.gameObject.SetActive(value: true);
			benchmarkRunner = null;
		}
		else
		{
			if (base.transform.childCount == 0)
			{
				Debug.LogError("No benchmark runners are found, aborting");
				EndWith(null);
				return;
			}
			base.transform.GetChild(0).gameObject.SetActive(value: true);
		}
		IsAwoken = true;
		awakeEvent.Invoke();
		OSDLabel = ConstructOSD();
		StartCoroutine(LoadAndWait());
	}

	private TextMeshProUGUI ConstructOSD()
	{
		GameObject obj = new GameObject("[Benchmark OSD]");
		Canvas canvas = obj.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.matchWidthOrHeight = 1f;
		canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
		GameObject obj2 = new GameObject("Label");
		obj2.transform.SetParent(canvas.transform, worldPositionStays: false);
		TextMeshProUGUI textMeshProUGUI = obj2.AddComponent<TextMeshProUGUI>();
		RectTransform rectTransform = textMeshProUGUI.rectTransform;
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.sizeDelta = Vector2.zero;
		rectTransform.offsetMin = new Vector2(50f, 50f);
		rectTransform.offsetMax = new Vector2(-50f, -50f);
		Material material = textMeshProUGUI.material;
		material.EnableKeyword(ShaderUtilities.Keyword_Underlay);
		material.SetFloat("_UnderlayDilate", 1f);
		material.SetFloat("_UnderlayOffsetY", -1f);
		textMeshProUGUI.material = material;
		textMeshProUGUI.color = new Color(1f, 1f, 0.5f, 1f);
		textMeshProUGUI.text = "";
		return textMeshProUGUI;
	}

	private IEnumerator LoadAndWait()
	{
		SceneManager.LoadScene(railwayScenePath, LoadSceneMode.Additive);
		yield return null;
		MoveSceneObjectsToOriginShift(railwayScenePath);
		terrainGrid.trackingReference = SingletonBehaviour<WorldMover>.Instance.playerTracker.GetTrackerTransform();
		DistantTerrain distantTerrain = UnityEngine.Object.FindObjectOfType<DistantTerrain>();
		distantTerrain.trackingReference = terrainGrid.trackingReference;
		distantTerrain.enabled = true;
		AreTracksLoaded = true;
		yield return null;
		while (IsStreaming)
		{
			yield return null;
		}
		IsLoaded = true;
		if ((bool)loadingScreen)
		{
			loadingScreen.SetActive(value: false);
		}
	}

	private IEnumerator Start()
	{
		tracker.actualPlayer = playerTransform;
		GameObject[] array = instantiateOnStart;
		for (int i = 0; i < array.Length; i++)
		{
			UnityEngine.Object.Instantiate(array[i]);
		}
		yield return null;
		Streamer[] array2 = streamers;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].streamerActive = true;
		}
		while (!IsLoaded)
		{
			yield return null;
		}
		startFired = true;
		startEvent.Invoke();
		startEvent.RemoveAllListeners();
	}

	private void MoveSceneObjectsToOriginShift(string scenePath)
	{
		SceneManager.GetSceneByPath(scenePath).GetRootGameObjects().ToList()
			.ForEach(delegate(GameObject go)
			{
				go.transform.SetParent(originShiftParent, worldPositionStays: true);
			});
	}

	public void EndWith(PerformanceTelemetry.Stats? stats)
	{
		lastRunStats = stats;
		if (continueCallback != null)
		{
			continueCallback();
			continueCallback = null;
		}
		else
		{
			Application.Quit(0);
		}
	}

	public void ExecuteAfterStart(UnityAction action)
	{
		if (startFired)
		{
			action();
		}
		else
		{
			startEvent.AddListener(action);
		}
	}
}
