using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DV.Debugging;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace DV.Rain
{
	public class WindowSimulationManager : SingletonBehaviour<WindowSimulationManager>
	{
		public struct PerformanceMetrics
		{
			public float timeMilliseconds;

			public float memoryMB;

			public bool visible;
		}

		public static readonly int _mistAmount = Shader.PropertyToID("_MistAmount");

		public static readonly int _rainAmount = Shader.PropertyToID("_RainAmount");

		private static bool ReachedVRAMLimit;

		public HashSet<Window> windows = new HashSet<Window>();

		public float mistAmount;

		public float rainAmount;

		public int maxVRAMInMB = 256;

		public int maxWindowSimulationsPerFrame = 25;

		public bool useWeatherDriver;

		public bool debug;

		public RenderTexture simulationRenderTexture;

		public Vector2Int overrideTextureSize;

		public RenderTexture overrideTexture;

		[NonSerialized]
		public int mistFadeAmount;

		[NonSerialized]
		public int dropletFadeAmount;

		[NonSerialized]
		public int dropletCountMultiplier;

		[NonSerialized]
		public float windowResolutionMultiplier;

		private Stopwatch stopwatch = new Stopwatch();

		private float mistFadeCounter;

		private float dropletFadeCounter;

		private bool disableSimulation;

		private bool debugDisable;

		private List<(float distance, Window window)> sortedWindows = new List<(float, Window)>();

		public new static string AllowAutoCreate()
		{
			return null;
		}

		protected override void Awake()
		{
			simulationRenderTexture = new RenderTexture(8, 8, 0, GraphicsFormat.R8G8B8A8_UNorm);
			simulationRenderTexture.enableRandomWrite = true;
			simulationRenderTexture.filterMode = FilterMode.Point;
			simulationRenderTexture.Create();
			overrideTexture = new RenderTexture(overrideTextureSize.x, overrideTextureSize.y, 0, GraphicsFormat.R8G8B8A8_UNorm);
			overrideTexture.enableRandomWrite = true;
			overrideTexture.filterMode = FilterMode.Point;
			overrideTexture.Create();
			base.Awake();
			if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
			{
				SingletonBehaviour<EffectsTogglerDebug>.Instance.SubscribeChanged(EffectsTogglerDebug.EffectType.WindowDropletsSimulation, OnDebugChanged);
			}
			GamePreferences.RegisterToPreferenceUpdated(Preferences.RainQualityIndex, QualityChanged);
			QualityChanged();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
			{
				SingletonBehaviour<EffectsTogglerDebug>.Instance.UnsubscribeChanged(EffectsTogglerDebug.EffectType.WindowDropletsSimulation, OnDebugChanged);
			}
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RainQualityIndex, QualityChanged);
		}

		private void QualityChanged()
		{
			int num = GamePreferences.Get<int>(Preferences.RainQualityIndex);
			dropletCountMultiplier = ((num == 3) ? 1 : 0);
			windowResolutionMultiplier = ((num == 3) ? 1f : 0.2f);
			disableSimulation = num < 2;
			disableSimulation |= debugDisable;
		}

		private void OnDebugChanged(bool on)
		{
			debugDisable = !on;
			QualityChanged();
		}

		public RenderTexture GetSimTexture(Vector2Int resolution)
		{
			if (simulationRenderTexture.width < resolution.x || simulationRenderTexture.height < resolution.y)
			{
				Vector2Int vector2Int = new Vector2Int(Mathf.Max(simulationRenderTexture.width, resolution.x), Mathf.Max(simulationRenderTexture.height, resolution.y));
				simulationRenderTexture.Release();
				simulationRenderTexture = new RenderTexture(vector2Int.x, vector2Int.y, 0, GraphicsFormat.R8G8B8A8_UNorm);
				simulationRenderTexture.enableRandomWrite = true;
				simulationRenderTexture.filterMode = FilterMode.Point;
				simulationRenderTexture.Create();
			}
			return simulationRenderTexture;
		}

		private void FixedUpdate()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera)
			{
				return;
			}
			if (useWeatherDriver && (bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				rainAmount = SingletonBehaviour<WeatherDriver>.Instance.RainValue;
				mistAmount = SingletonBehaviour<WeatherDriver>.Instance.WetnessValue;
			}
			Shader.SetGlobalFloat(_mistAmount, mistAmount);
			Shader.SetGlobalFloat(_rainAmount, rainAmount);
			if (disableSimulation)
			{
				return;
			}
			dropletFadeCounter += Time.fixedDeltaTime * 255f / Mathf.Max(Mathf.Lerp(SingletonBehaviour<WindowSettings>.Instance.timeToFadeDropletMinRain, SingletonBehaviour<WindowSettings>.Instance.timeToFadeDropletMaxRain, rainAmount) * mistAmount, 0.0001f);
			mistFadeCounter += Time.fixedDeltaTime * 255f / Mathf.Max(Mathf.Lerp(SingletonBehaviour<WindowSettings>.Instance.timeToFadeMistMinRain, SingletonBehaviour<WindowSettings>.Instance.timeToFadeMistMaxRain, rainAmount), 0.0001f);
			int num = (int)dropletFadeCounter;
			dropletFadeCounter -= num;
			dropletFadeAmount = num;
			int num2 = (int)mistFadeCounter;
			mistFadeCounter -= num2;
			mistFadeAmount = num2;
			sortedWindows.Clear();
			foreach (Window window in windows)
			{
				sortedWindows.Add((Vector3.SqrMagnitude(window.transform.position - activeCamera.transform.position), window));
			}
			sortedWindows.Sort(((float distance, Window window) a, (float distance, Window window) b) => a.distance.CompareTo(b.distance));
			int num3 = 0;
			PerformanceMetrics performanceMetrics = default(PerformanceMetrics);
			int num4 = 0;
			foreach (var sortedWindow in sortedWindows)
			{
				Window item = sortedWindow.window;
				if (num3 == maxWindowSimulationsPerFrame)
				{
					break;
				}
				if (debug)
				{
					stopwatch.Restart();
				}
				item.textureOverride = performanceMetrics.memoryMB > (float)maxVRAMInMB;
				item.Simulate(Time.fixedDeltaTime);
				if (debug)
				{
					stopwatch.Stop();
				}
				performanceMetrics.memoryMB += (float)(item.dropletRenderingTexture.width * item.dropletRenderingTexture.height) * 4f / 1048576f;
				if (debug)
				{
					performanceMetrics.timeMilliseconds += (float)stopwatch.Elapsed.TotalMilliseconds;
				}
				if (item.IsVisible())
				{
					num3++;
				}
				num4++;
			}
			DebugVRAMLimit(performanceMetrics.memoryMB > (float)maxVRAMInMB);
			if (debug)
			{
				UnityEngine.Debug.Log(string.Format("Droplet Simulation stats: {0} ms | {1} MB | {2} visible | {3} total", performanceMetrics.timeMilliseconds.ToString("F4"), performanceMetrics.memoryMB.ToString("F2"), num3, windows.Count));
			}
		}

		private void DebugVRAMLimit(bool reachedVRAMLimit)
		{
			if (ReachedVRAMLimit == reachedVRAMLimit)
			{
				return;
			}
			ReachedVRAMLimit = reachedVRAMLimit;
			StringBuilder stringBuilder = new StringBuilder();
			if (reachedVRAMLimit)
			{
				stringBuilder.AppendLine($"Window simulation crossed {maxVRAMInMB}MB in VRAM usage!");
			}
			else
			{
				stringBuilder.AppendLine("Window simulation went below VRAM limit!");
			}
			stringBuilder.AppendLine("List of windows:");
			PerformanceMetrics performanceMetrics = default(PerformanceMetrics);
			foreach (var sortedWindow in sortedWindows)
			{
				Window item = sortedWindow.window;
				performanceMetrics.memoryMB += (float)(item.dropletRenderingTexture.width * item.dropletRenderingTexture.height) * 4f / 1048576f;
				stringBuilder.AppendLine("[" + item.transform.root.name + "/" + item.name + "] : " + $"[texture size : {item.dropletRenderingTexture.width}, {item.dropletRenderingTexture.height}] " + $"[window size : {item.sizeInMeters}] " + $"[dist : {Vector3.Distance(item.transform.position, PlayerManager.ActiveCamera.transform.position)}] " + $"[textureOverride : {item.textureOverride}] " + $"[MB : {performanceMetrics.memoryMB}] " + $"[visible : {item.IsVisible()}]");
			}
			UnityEngine.Debug.LogError(stringBuilder.ToString());
		}

		private void LateUpdate()
		{
			foreach (Window window in windows)
			{
				if (!window.useBakedUVs)
				{
					window.UpdateWindowMatrix();
				}
			}
		}
	}
}
