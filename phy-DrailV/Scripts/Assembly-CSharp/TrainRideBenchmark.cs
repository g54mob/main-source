using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DV;
using DV.Telemetry;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;
using UnityEngine.Events;

public class TrainRideBenchmark : MonoBehaviour
{
	private const float PLAYER_EYE_HEIGHT = 1.56f;

	[Header("Setup")]
	public string trackName = "[Y]_[HB]_[G-01-S]";

	public bool flipOrientation = true;

	[Header("Hooks")]
	public UnityEvent preparationHook;

	public UnityEvent preWarmupHook;

	public UnityEvent postWarmupHook;

	public UnityEvent perFrameHook;

	public UnityEvent finishedHook;

	public static string override_trackName;

	public static bool? override_flipOrientation;

	private TrainCar mainCar;

	private void Awake()
	{
		if (!string.IsNullOrEmpty(override_trackName))
		{
			trackName = override_trackName;
			override_trackName = null;
		}
		if (override_flipOrientation.HasValue)
		{
			override_flipOrientation = override_flipOrientation.Value;
			override_flipOrientation = null;
		}
		if (SingletonBehaviour<BenchmarkSetup>.Instance.IsAwoken)
		{
			Initialize();
		}
		else
		{
			SingletonBehaviour<BenchmarkSetup>.Instance.awakeEvent.AddListener(Initialize);
		}
	}

	private void Initialize()
	{
		StartCoroutine(InitCoro());
	}

	private IEnumerator InitCoro()
	{
		while (!SingletonBehaviour<BenchmarkSetup>.Instance.AreTracksLoaded)
		{
			yield return null;
		}
		RailTrack[] array = UnityEngine.Object.FindObjectsOfType<RailTrack>();
		RailTrack railTrack = null;
		RailTrack[] array2 = array;
		foreach (RailTrack railTrack2 in array2)
		{
			if (railTrack2.gameObject.name == trackName)
			{
				railTrack = railTrack2;
				break;
			}
		}
		PlayerManager.PlayerTransform.position = railTrack.transform.position + Vector3.up * 3f;
		List<TrainCarLivery> list = new List<TrainCarLivery>();
		list.Add(TrainCarType.LocoShunter.ToV2());
		list.Add(TrainCarType.BoxcarGreen.ToV2());
		list.Add(TrainCarType.BoxcarRed.ToV2());
		List<TrainCar> list2 = SpawnFreeRoamTrain(railTrack, list, flipOrientation);
		mainCar = list2[0];
		preparationHook.Invoke();
		SingletonBehaviour<BenchmarkSetup>.Instance.ExecuteAfterStart(OnLoadingFinished);
	}

	private static void TeleportPlayerToCar(TrainCar car)
	{
		if (!car.IsLoco && !CarTypes.IsCaboose(car.carLivery))
		{
			Debug.LogError("Given car '" + car.name + "' must be a locomotive or caboose", car);
			return;
		}
		Transform transform = car.transform.Find("[cab]");
		if (!transform)
		{
			transform = car.interior.transform.Find("[cab]");
			if (!transform)
			{
				Debug.LogError("Given car '" + car.name + "' doesn't have a [cab] object in hierarchy", car);
				return;
			}
		}
		SingletonBehaviour<BenchmarkSetup>.Instance.tracker.applyOriginShift = false;
		PlayerManager.PlayerTransform.position = transform.position + Vector3.up * 1.56f;
		PlayerManager.PlayerTransform.rotation = transform.rotation;
		PlayerManager.PlayerTransform.SetParent(car.interior, worldPositionStays: true);
	}

	public static List<TrainCar> SpawnFreeRoamTrain(RailTrack spawnRailtrack, List<TrainCarLivery> carList, bool carsOrientationAlongTrack)
	{
		int count = carList.Count;
		List<bool> carsOrientationReversed = Enumerable.Repeat(element: false, carList.Count).ToList();
		List<TrainCar> list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrack(carList, carsOrientationReversed, spawnRailtrack, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, !carsOrientationAlongTrack);
		while (list == null || list.Count == 0)
		{
			if (carList.Count == 1)
			{
				Debug.LogError($"Unexpected state: Couldn't spawn single free roam car on track '{spawnRailtrack.LogicTrack().ID}'. Something is not right");
				return null;
			}
			Debug.LogWarning($"Couldn't spawn all {count} free roam cars, attempting spawn with first {carList.Count - 1} cars");
			carList.RemoveAt(carList.Count - 1);
			list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrack(carList, carsOrientationReversed, spawnRailtrack, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, !carsOrientationAlongTrack);
		}
		return list;
	}

	private void OnLoadingFinished()
	{
		StartCoroutine(BenchmarkRoutine());
	}

	private IEnumerator BenchmarkRoutine()
	{
		SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Preparing benchmark...";
		Bogie bogie = mainCar.Bogies[0];
		bogie.DistanceTrackingEnabled = true;
		bogie.ResetDistanceTravelled();
		AccelerateToSpeed accelerator = mainCar.gameObject.AddComponent<AccelerateToSpeed>();
		accelerator.targetSpeedKMH = 50f;
		accelerator.enabled = false;
		preWarmupHook.Invoke();
		TeleportPlayerToCar(mainCar);
		yield return WaitFor.Seconds(3f);
		accelerator.enabled = true;
		postWarmupHook.Invoke();
		yield return null;
		Debug.Log("<<< BENCHMARK START >>>");
		if (!SingletonBehaviour<PerformanceTelemetry>.Instance)
		{
			new GameObject("[PerformanceTelemetry]", typeof(PerformanceTelemetry));
		}
		SingletonBehaviour<PerformanceTelemetry>.Instance.StartClean(30000);
		float duration = 60f;
		for (float time = 0f; time < duration; time += Time.deltaTime)
		{
			float num = Mathf.Max(0f, duration - time);
			SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Benchmarking...\n" + (1f / SingletonBehaviour<PerformanceTelemetry>.Instance.GetRecentAverageFrameTime(10)).ToString("0.0") + " fps\n" + ((int)(num / 60f)).ToString("00") + ":" + ((int)num % 60).ToString("00");
			PlayerManager.PlayerTransform.localRotation = Quaternion.Euler(0f, (0f - Mathf.Sin((float)bogie.TotalDistanceTravelled * 0.025f)) * 45f, 0f);
			perFrameHook.Invoke();
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Debug.LogWarning("!!! BENCHMARK ABORTED !!!");
				SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Aborting...";
				SingletonBehaviour<AppUtil>.Instance.PauseGame();
				yield return null;
				SingletonBehaviour<BenchmarkSetup>.Instance.EndWith(null);
				yield break;
			}
			yield return null;
		}
		SingletonBehaviour<PerformanceTelemetry>.Instance.Stop();
		finishedHook.Invoke();
		Debug.Log("<<< BENCHMARK END >>>");
		yield return null;
		PerformanceTelemetry.Stats stats = SingletonBehaviour<PerformanceTelemetry>.Instance.ComputeStats();
		SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Benchmark done!\nAverage FPS is " + (1f / stats.averageFrameTime).ToString("0.00") + "\n(range " + (1f / stats.maxFrameTime).ToString("0.00") + " - " + (1f / stats.minFrameTime).ToString("0.00") + ", " + (1f / stats.medianFrameTime).ToString("0.00") + " median)\nPress space to continue...";
		SingletonBehaviour<PerformanceTelemetry>.Instance.filePrefix = "BENCHMARK_TRAINRUN_" + trackName + "_";
		string text = SingletonBehaviour<PerformanceTelemetry>.Instance.SaveTelemetry();
		text = text.Substring(0, text.Length - ".csv".Length) + ".txt";
		StringBuilder stringBuilder = new StringBuilder();
		string text2 = "DV GAME BENCHMARK (" + trackName + ")";
		stringBuilder.AppendLine(text2);
		stringBuilder.AppendLine(new string('=', text2.Length));
		stringBuilder.AppendLine("Benchmark timestamp: " + DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
		stringBuilder.AppendLine("Average FPS: " + (1f / stats.averageFrameTime).ToString("0.0"));
		stringBuilder.AppendLine("Minimum FPS: " + (1f / stats.maxFrameTime).ToString("0.0"));
		stringBuilder.AppendLine("Maximum FPS: " + (1f / stats.minFrameTime).ToString("0.0"));
		stringBuilder.AppendLine("Median FPS: " + (1f / stats.medianFrameTime).ToString("0.0"));
		stringBuilder.AppendLine(new string('=', text2.Length));
		stringBuilder.AppendLine("Current resolution: " + Screen.width + " x " + Screen.height + " @ " + Screen.currentResolution.refreshRate + " Hz");
		foreach (Preferences item in PreferencesUtils.GetPreferencesInCategory(PreferenceCategory.Graphics))
		{
			if (item.GetAttribute().PreferenceType == typeof(int))
			{
				stringBuilder.AppendLine(string.Concat(item, ": ", GamePreferences.Get<int>(item)));
			}
			else if (item.GetAttribute().PreferenceType == typeof(float))
			{
				stringBuilder.AppendLine(string.Concat(item, ": ", GamePreferences.Get<float>(item)));
			}
			else if (item.GetAttribute().PreferenceType == typeof(bool))
			{
				stringBuilder.AppendLine(string.Concat(item, ": ", GamePreferences.Get<bool>(item).ToString()));
			}
		}
		stringBuilder.AppendLine(new string('=', text2.Length));
		stringBuilder.AppendLine(string.Join("\n", Bootstrap.StartupInfo));
		File.WriteAllText(text, stringBuilder.ToString());
		SingletonBehaviour<AppUtil>.Instance.RequestPause(this, paused: true, 10);
		while (!Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}
		SingletonBehaviour<BenchmarkSetup>.Instance.EndWith(stats);
	}
}
