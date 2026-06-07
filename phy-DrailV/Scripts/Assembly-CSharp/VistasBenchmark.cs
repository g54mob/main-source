using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DV;
using DV.Telemetry;
using DV.Utils;
using UnityEngine;
using UnityEngine.Events;

public class VistasBenchmark : MonoBehaviour
{
	[Header("Hooks")]
	public UnityEvent preparationHook;

	public UnityEvent preWarmupHook;

	public UnityEvent postWarmupHook;

	public UnityEvent perFrameHook;

	public UnityEvent finishedHook;

	private List<Transform> vistaPoints = new List<Transform>();

	private void Awake()
	{
		GameObject gameObject = GameObject.Find("BenchmarkVistas");
		if (!gameObject)
		{
			Debug.LogError("CRITICAL ERROR! 'BenchmarkVistas' object wasn't found, are the points properly set up?");
			return;
		}
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			vistaPoints.Add(gameObject.transform.GetChild(i));
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
		PlayerManager.PlayerTransform.position = vistaPoints[0].transform.position;
		PlayerManager.PlayerTransform.rotation = vistaPoints[0].transform.rotation;
		preparationHook.Invoke();
		SingletonBehaviour<BenchmarkSetup>.Instance.startEvent.AddListener(OnLoadingFinished);
	}

	private void OnLoadingFinished()
	{
		SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Streaming...";
		StartCoroutine(BenchmarkRoutine());
	}

	private IEnumerator BenchmarkRoutine()
	{
		preWarmupHook.Invoke();
		yield return WaitFor.Seconds(3f);
		postWarmupHook.Invoke();
		yield return null;
		Debug.Log("<<< BENCHMARK START >>>");
		if (!SingletonBehaviour<PerformanceTelemetry>.Instance)
		{
			new GameObject("[PerformanceTelemetry]", typeof(PerformanceTelemetry));
		}
		float duration = 10f;
		StringBuilder sb = new StringBuilder();
		List<float> medians = new List<float>();
		for (int i = 0; i < vistaPoints.Count; i++)
		{
			SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Streaming...";
			PlayerManager.PlayerTransform.position = vistaPoints[i].transform.position;
			PlayerManager.PlayerTransform.rotation = vistaPoints[i].transform.rotation;
			yield return null;
			while (SingletonBehaviour<BenchmarkSetup>.Instance.IsStreaming)
			{
				yield return null;
			}
			SingletonBehaviour<BenchmarkSetup>.Instance.loadingScreen.SetActive(value: false);
			SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Warming up...";
			yield return WaitFor.Seconds(1f);
			SingletonBehaviour<PerformanceTelemetry>.Instance.StartClean(30000);
			for (float time = 0f; time < duration; time += Time.deltaTime)
			{
				float num = Mathf.Max(0f, duration - time);
				SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = string.Format("Benchmarking [{0}/{1}]...\n{2} fps\n{3}:{4}", i + 1, vistaPoints.Count, (1f / SingletonBehaviour<PerformanceTelemetry>.Instance.GetRecentAverageFrameTime(10)).ToString("0.0"), ((int)(num / 60f)).ToString("00"), ((int)num % 60).ToString("00"));
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
			string text = vistaPoints[i].name;
			SingletonBehaviour<PerformanceTelemetry>.Instance.filePrefix = "BENCHMARK_VISTA_" + text + "_";
			SingletonBehaviour<PerformanceTelemetry>.Instance.SaveTelemetry();
			string text2 = "DV VISTA BENCHMARK (" + text + ")";
			sb.AppendLine(text2);
			sb.AppendLine(new string('=', text2.Length));
			sb.AppendLine("Benchmark timestamp: " + DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"));
			sb.AppendLine("Average FPS: " + (1f / stats.averageFrameTime).ToString("0.0"));
			sb.AppendLine("Minimum FPS: " + (1f / stats.maxFrameTime).ToString("0.0"));
			sb.AppendLine("Maximum FPS: " + (1f / stats.minFrameTime).ToString("0.0"));
			sb.AppendLine("Median FPS: " + (1f / stats.medianFrameTime).ToString("0.0"));
			sb.AppendLine();
			medians.Add(stats.medianFrameTime);
			if (i < vistaPoints.Count - 1)
			{
				SingletonBehaviour<BenchmarkSetup>.Instance.loadingScreen.SetActive(value: true);
			}
			yield return null;
		}
		sb.AppendLine();
		sb.AppendLine("Current resolution: " + Screen.width + " x " + Screen.height + " @ " + Screen.currentResolution.refreshRate + " Hz");
		foreach (Preferences item in PreferencesUtils.GetPreferencesInCategory(PreferenceCategory.Graphics))
		{
			if (item.GetAttribute().PreferenceType == typeof(int))
			{
				sb.AppendLine(string.Concat(item, ": ", GamePreferences.Get<int>(item)));
			}
			else if (item.GetAttribute().PreferenceType == typeof(float))
			{
				sb.AppendLine(string.Concat(item, ": ", GamePreferences.Get<float>(item)));
			}
			else if (item.GetAttribute().PreferenceType == typeof(bool))
			{
				sb.AppendLine(string.Concat(item, ": ", GamePreferences.Get<bool>(item).ToString()));
			}
		}
		sb.AppendLine();
		sb.AppendLine(string.Join("\n", Bootstrap.StartupInfo));
		File.WriteAllText(Path.Combine(Application.persistentDataPath, "Telemetry", "BENCHMARK_VISTA_SUMMARY_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt"), sb.ToString());
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < medians.Count; j++)
		{
			stringBuilder.AppendLine(string.Format("Scene {0}: {1} fps", j + 1, (1f / medians[j]).ToString("0.0")));
		}
		SingletonBehaviour<BenchmarkSetup>.Instance.OSDLabel.text = "Benchmark done!\n\n" + stringBuilder.ToString() + "\nPress space to continue...";
		SingletonBehaviour<AppUtil>.Instance.PauseGame();
		while (!Input.GetKeyDown(KeyCode.Space))
		{
			yield return null;
		}
		SingletonBehaviour<BenchmarkSetup>.Instance.EndWith(default(PerformanceTelemetry.Stats));
	}
}
