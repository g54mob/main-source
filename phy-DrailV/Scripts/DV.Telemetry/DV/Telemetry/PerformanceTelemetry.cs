using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DV.Utils;
using UnityEngine;
using UnityEngine.Profiling;

namespace DV.Telemetry
{
	public class PerformanceTelemetry : SingletonBehaviour<PerformanceTelemetry>
	{
		public struct Stats
		{
			public float minFrameTime;

			public float maxFrameTime;

			public float averageFrameTime;

			public float medianFrameTime;

			public Stats(float minFrameTime, float maxFrameTime, float averageFrameTime, float medianFrameTime)
			{
				this.minFrameTime = minFrameTime;
				this.maxFrameTime = maxFrameTime;
				this.averageFrameTime = averageFrameTime;
				this.medianFrameTime = medianFrameTime;
			}
		}

		private struct Snapshot
		{
			public float frameTime;

			public float frameRate;

			public float gcMemory;

			public float monoHeap;
		}

		private class Telemetry : TelemetryData<PerformanceTelemetry, Snapshot>
		{
			protected override string ObjectName => "Performance";

			public Telemetry(PerformanceTelemetry perf, bool lazyAllocation, int historyLength)
				: base(perf, false, historyLength)
			{
			}

			protected override void RecordTo(PerformanceTelemetry obj, ref Snapshot data)
			{
				data.frameTime = Time.unscaledDeltaTime;
				data.frameRate = 1f / Time.unscaledDeltaTime;
				data.monoHeap = (float)Profiler.GetMonoHeapSizeLong() / 1048576f;
			}
		}

		public int HistoryLength = 3600;

		[Header("Auto operation")]
		public bool autoMode;

		public float startDelay = 3f;

		public float runLength = 60f;

		[Header("Saving")]
		public string filePrefix = "PERFORMANCE_";

		[Header("Manual operation")]
		[InspectorButton("StartTelemetry", true, true)]
		public bool startTelemetry;

		[InspectorButton("SaveTelemetry", true, true)]
		public bool saveTelemetry;

		private Telemetry telemetry;

		private bool running;

		public bool IsStillWriting => telemetry.IsBusy;

		protected override void Initialize()
		{
			base.Initialize();
			telemetry = new Telemetry(this, lazyAllocation: false, HistoryLength);
			if (autoMode && startDelay <= 0f)
			{
				StartTelemetry();
			}
			else if (autoMode && startDelay > 0f)
			{
				StartCoroutine(StartAfter(startDelay));
			}
			if (autoMode && runLength > 0f)
			{
				StartCoroutine(SaveAfter(startDelay + runLength));
			}
		}

		private IEnumerator StartAfter(float delay)
		{
			yield return new WaitForSeconds(delay);
			running = true;
		}

		private IEnumerator SaveAfter(float delay)
		{
			yield return new WaitForSeconds(delay);
			SaveTelemetry();
		}

		private void LateUpdate()
		{
			if (running && Time.timeScale > 0f)
			{
				telemetry.RecordFrame();
			}
		}

		private void StartTelemetry()
		{
			running = true;
		}

		public float GetRecentAverageFrameTime(int samples = 5)
		{
			if (telemetry == null || telemetry.Count == 0 || samples <= 0)
			{
				return 0f;
			}
			float num = 0f;
			samples = Math.Min(samples, telemetry.Count);
			for (int i = 0; i < samples; i++)
			{
				num += telemetry[telemetry.Count - i - 1].frameTime;
			}
			return num / (float)samples;
		}

		public Stats ComputeStats()
		{
			List<float> list = new List<float>(telemetry.Count);
			float num = telemetry[0].frameTime;
			float num2 = telemetry[0].frameTime;
			float num3 = 0f;
			for (int i = 0; i < telemetry.Count; i++)
			{
				list.Add(telemetry[i].frameTime);
				num = Mathf.Min(num, telemetry[i].frameTime);
				num2 = Mathf.Max(num2, telemetry[i].frameTime);
				num3 += telemetry[i].frameTime;
			}
			num3 /= (float)telemetry.Count;
			list.Sort();
			float medianFrameTime = list[list.Count / 2];
			return new Stats(num, num2, num3, medianFrameTime);
		}

		public string SaveTelemetry()
		{
			if (telemetry != null && telemetry.Count > 0)
			{
				Stats stats = ComputeStats();
				float minFrameTime = stats.minFrameTime;
				float maxFrameTime = stats.maxFrameTime;
				float averageFrameTime = stats.averageFrameTime;
				float medianFrameTime = stats.medianFrameTime;
				Debug.Log($"FRAME RATES (over {telemetry.Count} frames) : max = {1f / minFrameTime} fps; min = {1f / maxFrameTime} fps; avg = {1f / averageFrameTime} fps; median = {1f / medianFrameTime} fps");
				minFrameTime *= 1000f;
				maxFrameTime *= 1000f;
				averageFrameTime *= 1000f;
				medianFrameTime *= 1000f;
				Debug.Log($"FRAME TIMES (over {telemetry.Count} frames) : min = {minFrameTime} ms; max = {maxFrameTime} ms; avg = {averageFrameTime} ms; median = {medianFrameTime} ms");
				string text = Path.Combine(Application.persistentDataPath, "Telemetry", filePrefix + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv");
				telemetry.SaveCSV(text);
				return text;
			}
			Debug.LogError("This can only be done during runtime, no data right now.");
			return null;
		}

		public void StartClean(int length)
		{
			telemetry = new Telemetry(this, lazyAllocation: false, length);
			running = true;
		}

		public void Stop()
		{
			running = false;
		}

		public void SaveCSV(string path)
		{
			telemetry.SaveCSV(path);
		}
	}
}
