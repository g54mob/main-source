using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class BenchmarkRunner : MonoBehaviour
{
	private abstract class TimeMetric
	{
		public struct Sample
		{
			public int Index;

			public double Value;
		}

		public readonly string Name;

		public readonly List<Sample> AllSamples = new List<Sample>();

		private int _nextSampleIndex;

		public double Mean
		{
			get
			{
				if (AllSamples.Count == 0)
				{
					return CurrentValue();
				}
				double num = 0.0;
				foreach (Sample allSample in AllSamples)
				{
					num += allSample.Value;
				}
				return num / (double)AllSamples.Count;
			}
		}

		public double Min
		{
			get
			{
				if (AllSamples.Count == 0)
				{
					return CurrentValue();
				}
				double value = AllSamples[0].Value;
				foreach (Sample allSample in AllSamples)
				{
					if (allSample.Value < value)
					{
						value = allSample.Value;
					}
				}
				return value;
			}
		}

		public double Max
		{
			get
			{
				if (AllSamples.Count == 0)
				{
					return CurrentValue();
				}
				double value = AllSamples[0].Value;
				foreach (Sample allSample in AllSamples)
				{
					if (allSample.Value > value)
					{
						value = allSample.Value;
					}
				}
				return value;
			}
		}

		public double Median => Percentile(0.5);

		public TimeMetric(string name)
		{
			Name = name;
		}

		public void Reset()
		{
			_nextSampleIndex = 0;
			AllSamples.Clear();
		}

		public abstract double CurrentValue();

		public void TakeSample()
		{
			AllSamples.Add(new Sample
			{
				Index = _nextSampleIndex++,
				Value = CurrentValue()
			});
		}

		public double Percentile(double percentile)
		{
			if (AllSamples.Count == 0)
			{
				return CurrentValue();
			}
			AllSamples.Sort((Sample a, Sample b) => a.Value.CompareTo(b.Value));
			int index = (int)Math.Round(percentile * (double)(AllSamples.Count - 1));
			return AllSamples[index].Value;
		}
	}

	private class TimeMetricProfiler : TimeMetric
	{
		private const int NS_PER_MS = 1000000;

		private readonly ProfilerRecorder _recorder;

		public TimeMetricProfiler(string name, ProfilerRecorder recorder)
			: base(name)
		{
			_recorder = recorder;
		}

		public override double CurrentValue()
		{
			if (!_recorder.Valid)
			{
				return double.NaN;
			}
			return _recorder.LastValueAsDouble / 1000000.0;
		}
	}

	private class TimeMetricAggregated : TimeMetric
	{
		private readonly List<TimeMetric> _updateTimes = new List<TimeMetric>();

		private readonly List<double> _factors = new List<double>();

		private readonly List<bool> _ignoreNaNs = new List<bool>();

		public TimeMetricAggregated(string name)
			: base(name)
		{
		}

		public override double CurrentValue()
		{
			double num = 0.0;
			for (int i = 0; i < _updateTimes.Count; i++)
			{
				double d = _updateTimes[i].CurrentValue();
				if (!_ignoreNaNs[i] || !double.IsNaN(d))
				{
					num += _updateTimes[i].CurrentValue() * _factors[i];
				}
			}
			return num;
		}

		public void Add(TimeMetric timeMetric, double factor = 1.0, bool ignoreNaN = false)
		{
			_updateTimes.Add(timeMetric);
			_factors.Add(factor);
			_ignoreNaNs.Add(ignoreNaN);
		}
	}

	private interface IBenchmark
	{
		string Name();

		IEnumerator Setup();

		IEnumerator Run();

		IEnumerator Cleanup();
	}

	private class MoveAroundNearbyCore : IBenchmark
	{
		private const float RADIUS = 15f;

		private const float HORIZONTAL_DISTANCE = 30f;

		private const int LAPS = 3;

		public string Name()
		{
			return "MoveAroundNearbyCore";
		}

		public IEnumerator Setup()
		{
			Manager.main.player.playerCommandSystem.SetPlayerState(Manager.main.player.entity, PlayerStateEnum.NoClip, locked: true);
			Manager.input.DisableInput();
			Manager.main.player.DebugSetPlayerPosition(new Vector3(15f, 0f, 0f));
			Manager.main.player.targetMovementVelocity = Vector3.zero;
			yield return new WaitForSeconds(1f);
		}

		public IEnumerator Run()
		{
			int i = 0;
			while (i < 3)
			{
				yield return Circle(float2.zero);
				yield return Horizontal(new float2(15f, 0f), new float2(-15f, 0f));
				yield return Horizontal(new float2(-15f, 0f), new float2(15f, 0f));
				int num = i + 1;
				i = num;
			}
		}

		public IEnumerator Cleanup()
		{
			Manager.main.player.playerCommandSystem.UnlockCurrentState(Manager.main.player.entity);
			Manager.input.EnableInput();
			yield return null;
		}

		private IEnumerator Circle(float2 center)
		{
			float angularSpeed = Manager.main.player.noClipMovementSpeedMultipler / 15f;
			float angle = 0f;
			while (angle <= MathF.PI * 2f)
			{
				angle += angularSpeed * Time.deltaTime;
				float x = 15f * Mathf.Cos(angle);
				float y = 15f * Mathf.Sin(angle);
				Manager.main.player.DebugSetPlayerPosition((center + new float2(x, y)).ToFloat3());
				yield return null;
			}
		}

		private IEnumerator Horizontal(float2 start, float2 end)
		{
			float distance = math.length(end - start);
			float speed = Manager.main.player.noClipMovementSpeedMultipler;
			float distanceTravelled = 0f;
			while (distanceTravelled < distance)
			{
				distanceTravelled += speed * Time.deltaTime;
				float2 x = math.lerp(start, end, math.clamp(distanceTravelled / distance, 0f, 1f));
				Manager.main.player.DebugSetPlayerPosition(x.ToFloat3());
				yield return null;
			}
			Manager.main.player.DebugSetPlayerPosition(end.ToFloat3());
			yield return null;
		}
	}

	private class ExploreWorld : IBenchmark
	{
		private const float EXPLORE_RADIUS = 1500f;

		private const float CIRCLE_RADIUS = 15f;

		private const int LAPS = -1;

		public string Name()
		{
			return "ExploreWorld";
		}

		public IEnumerator Setup()
		{
			Manager.main.player.playerCommandSystem.SetPlayerState(Manager.main.player.entity, PlayerStateEnum.NoClip, locked: true);
			Manager.input.DisableInput();
			Manager.main.player.SetPlayerPosition(new float3(-1500f, 0f, -1500f));
			Manager.main.player.targetMovementVelocity = Vector3.zero;
			yield return new WaitForSeconds(1f);
		}

		public IEnumerator Run()
		{
			int i = 0;
			while (true)
			{
				if (i >= -1)
				{
				}
				int gridSize = (int)math.ceil(100f);
				float num = (float)(-(gridSize - 1)) * 15f;
				float3 basePosition = new float3(num, 0f, num);
				int num2;
				for (int x = 0; x < gridSize; x = num2)
				{
					for (int y = 0; y < gridSize; y = num2)
					{
						yield return Circle(basePosition + new float3(x, 0f, y) * 15f * 2f);
						num2 = y + 1;
					}
					num2 = x + 1;
				}
				num2 = i + 1;
				i = num2;
			}
		}

		public IEnumerator Cleanup()
		{
			Manager.main.player.playerCommandSystem.UnlockCurrentState(Manager.main.player.entity);
			Manager.input.EnableInput();
			yield return null;
		}

		private IEnumerator Circle(float3 offset)
		{
			float angularSpeed = Manager.main.player.noClipMovementSpeedMultipler / 15f;
			float angle = 0f;
			while (angle <= MathF.PI * 2f)
			{
				angle += angularSpeed * Time.deltaTime;
				float x = 15f * Mathf.Cos(angle);
				float z = 15f * Mathf.Sin(angle);
				Manager.main.player.SetPlayerPosition(new float3(x, 0f, z) + offset);
				yield return null;
			}
		}
	}

	private const int FONT_SIZE = 12;

	private static readonly string Header = string.Format("{0,20}: {1,6} / {2,6} / {3,6} / {4,6} / {5,6} [ms]", "", "mean", "max", "95%", "50%", "min");

	public SceneHandler sceneHandler;

	public bool printAvailableMetrics;

	public Font font;

	private GUIStyle _timingWindowStyle;

	private readonly List<TimeMetric> _metrics = new List<TimeMetric>();

	private string _statsText = "";

	private bool _runningBenchmarks;

	private bool _quitWhenDone;

	private string _outputBasePath;

	private StringBuilder _reusedStringBuilder;

	private void Awake()
	{
		if (CommandLineArgs.Has("-benchmark-quit"))
		{
			_quitWhenDone = true;
		}
		_outputBasePath = CommandLineArgs.GetParam("-benchmark-output-base-path");
		if (printAvailableMetrics)
		{
			List<ProfilerRecorderHandle> list = new List<ProfilerRecorderHandle>();
			ProfilerRecorderHandle.GetAvailable(list);
			foreach (ProfilerRecorderHandle item in list)
			{
				ProfilerRecorderDescription description = ProfilerRecorderHandle.GetDescription(item);
				Debug.Log($"Category {description.Category.Name} name {description.Name} unit {description.UnitType}");
			}
		}
		CreateMetrics();
		_reusedStringBuilder = new StringBuilder(100 * _metrics.Count);
		_timingWindowStyle = null;
		StartBenchmarks();
	}

	private void OnDisable()
	{
		if (_runningBenchmarks)
		{
			_runningBenchmarks = false;
			StopAllCoroutines();
		}
	}

	private void Update()
	{
		if (!_runningBenchmarks)
		{
			return;
		}
		foreach (TimeMetric metric in _metrics)
		{
			metric.TakeSample();
		}
	}

	private void CreateMetrics()
	{
		ProfilerCategory category = new ProfilerCategory("PlayerLoop");
		TimeMetricProfiler timeMetricProfiler = new TimeMetricProfiler("Total", ProfilerRecorder.StartNew(category, "PlayerLoop"));
		_metrics.Add(timeMetricProfiler);
		TimeMetricAggregated timeMetricAggregated = new TimeMetricAggregated("MonoBehaviour");
		_metrics.Add(timeMetricAggregated);
		TimeMetricProfiler timeMetricProfiler2 = new TimeMetricProfiler("- FixedUpdate", ProfilerRecorder.StartNew(category, "FixedBehaviourUpdate"));
		TimeMetricProfiler timeMetricProfiler3 = new TimeMetricProfiler("- Update", ProfilerRecorder.StartNew(category, "BehaviourUpdate"));
		TimeMetricProfiler timeMetricProfiler4 = new TimeMetricProfiler("- LateUpdate", ProfilerRecorder.StartNew(category, "LateBehaviourUpdate"));
		timeMetricAggregated.Add(timeMetricProfiler2);
		timeMetricAggregated.Add(timeMetricProfiler3);
		timeMetricAggregated.Add(timeMetricProfiler4);
		_metrics.Add(timeMetricProfiler2);
		_metrics.Add(timeMetricProfiler3);
		_metrics.Add(timeMetricProfiler4);
		TimeMetricAggregated timeMetricAggregated2 = new TimeMetricAggregated("ECS Update");
		_metrics.Add(timeMetricAggregated2);
		if (Manager.ecs.ClientWorld != null)
		{
			string statName = Manager.ecs.ClientWorld.Name + " Unity.Entities.SimulationSystemGroup";
			TimeMetricProfiler timeMetricProfiler5 = new TimeMetricProfiler("- ClientSimulation", ProfilerRecorder.StartNew(category, statName));
			timeMetricAggregated2.Add(timeMetricProfiler5);
			_metrics.Add(timeMetricProfiler5);
		}
		if (Manager.ecs.ServerWorld != null)
		{
			string statName2 = Manager.ecs.ServerWorld.Name + " Unity.Entities.SimulationSystemGroup";
			TimeMetricProfiler timeMetricProfiler6 = new TimeMetricProfiler("- ServerSimulation", ProfilerRecorder.StartNew(category, statName2));
			timeMetricAggregated2.Add(timeMetricProfiler6);
			_metrics.Add(timeMetricProfiler6);
		}
		TimeMetricProfiler timeMetricProfiler7 = new TimeMetricProfiler("Render (CPU)", ProfilerRecorder.StartNew(category, "UnityEngine.CoreModule.dll!UnityEngine.Rendering::RenderPipelineManager.DoRenderLoop_Internal() [Invoke]"));
		_metrics.Add(timeMetricProfiler7);
		TimeMetricProfiler timeMetricProfiler8 = new TimeMetricProfiler("VSync", ProfilerRecorder.StartNew(new ProfilerCategory("VSync"), "WaitForTargetFPS"));
		_metrics.Add(timeMetricProfiler8);
		TimeMetricProfiler timeMetricProfiler9 = new TimeMetricProfiler("Profiler", ProfilerRecorder.StartNew(new ProfilerCategory("Overhead"), "Profiler.FlushCounters"));
		_metrics.Add(timeMetricProfiler9);
		TimeMetricAggregated timeMetricAggregated3 = new TimeMetricAggregated("Other");
		timeMetricAggregated3.Add(timeMetricProfiler);
		timeMetricAggregated3.Add(timeMetricAggregated, -1.0, ignoreNaN: true);
		timeMetricAggregated3.Add(timeMetricAggregated2, -1.0, ignoreNaN: true);
		timeMetricAggregated3.Add(timeMetricProfiler7, -1.0, ignoreNaN: true);
		timeMetricAggregated3.Add(timeMetricProfiler8, -1.0, ignoreNaN: true);
		timeMetricAggregated3.Add(timeMetricProfiler9, -1.0, ignoreNaN: true);
		_metrics.Add(timeMetricAggregated3);
	}

	private static void FormatMetric(TimeMetric metric, StringBuilder builder)
	{
		builder.AppendFormat("{0,-20}: {1,6:F2} / {2,6:F2} / {3,6:F2} / {4,6:F2} / {5,6:F2}", metric.Name, metric.Mean, metric.Max, metric.Percentile(0.95), metric.Median, metric.Min);
		builder.AppendLine();
	}

	private void OnGUI()
	{
		if (_timingWindowStyle == null)
		{
			_timingWindowStyle = new GUIStyle(GUI.skin.textArea);
			if (font != null)
			{
				_timingWindowStyle.font = font;
			}
			_timingWindowStyle.fontSize = 12;
		}
		GUI.TextArea(new Rect(10f, 50f, 600f, 16 * (_metrics.Count + 3)), _statsText, _timingWindowStyle);
	}

	private void StartBenchmarks()
	{
		StartCoroutine(RunBenchmarks());
	}

	private IEnumerator RunBenchmarks()
	{
		Debug.LogWarning("The profiler is not available (expected if this is a release build). Runtime statistics will be limited.");
		_statsText = "Preparing benchmarks...";
		yield return new WaitUntil(() => Manager.main.player != null && (sceneHandler == null || sceneHandler.isSceneHandlerReady));
		yield return new WaitForSeconds(10f);
		Debug.Log("Running benchmarks...");
		List<IBenchmark> list = new List<IBenchmark>();
		list.Add(new MoveAroundNearbyCore());
		foreach (IBenchmark benchmark in list)
		{
			_statsText = "Setup for benchmark " + benchmark.Name() + "...";
			yield return StartCoroutine(benchmark.Setup());
			StartBenchmarkMeasurements(benchmark);
			yield return benchmark.Run();
			FinalizeBenchmarkMeasurements(benchmark);
			yield return null;
			yield return StartCoroutine(benchmark.Cleanup());
		}
		if (_quitWhenDone)
		{
			Application.Quit();
		}
		Debug.Log("Finished running benchmarks." + (_quitWhenDone ? " Quitting..." : ""));
	}

	private void StartBenchmarkMeasurements(IBenchmark benchmark)
	{
		_runningBenchmarks = true;
		Debug.Log("Preparing benchmark " + benchmark.Name());
		foreach (TimeMetric metric in _metrics)
		{
			metric.Reset();
		}
		_statsText = "Running benchmark " + benchmark.Name() + "...";
	}

	private void FinalizeBenchmarkMeasurements(IBenchmark benchmark)
	{
		Debug.Log("Finished benchmark " + benchmark.Name());
		_reusedStringBuilder.Clear();
		_reusedStringBuilder.AppendLine("Results from benchmark " + benchmark.Name() + ":");
		_reusedStringBuilder.AppendLine(Header);
		foreach (TimeMetric metric in _metrics)
		{
			FormatMetric(metric, _reusedStringBuilder);
		}
		_statsText = _reusedStringBuilder.ToString();
		Debug.Log(_statsText);
		_runningBenchmarks = false;
	}
}
