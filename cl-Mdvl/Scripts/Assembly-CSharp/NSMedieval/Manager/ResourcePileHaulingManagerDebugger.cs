using System.Diagnostics;
using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class ResourcePileHaulingManagerDebugger
	{
		public struct ResultInfo
		{
			public long Time { get; set; }

			public int Count { get; set; }
		}

		public class CurrentProcessInfo
		{
			public Stopwatch Stopwatch { get; }

			public int Count { get; set; }

			public CurrentProcessInfo()
			{
				Stopwatch = new Stopwatch();
				Count = 0;
			}
		}

		private static ResultInfo queueProcess;

		private static ResultInfo reProcessAll;

		public static bool BackgroundThreadRunning;

		private static readonly CurrentProcessInfo CurrentQueueProcess = new CurrentProcessInfo();

		private static readonly CurrentProcessInfo CurrentReProcessAll = new CurrentProcessInfo();

		public static ResultInfo QueueProcess => queueProcess;

		public static ResultInfo ReProcessAll => reProcessAll;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			queueProcess = default(ResultInfo);
			reProcessAll = default(ResultInfo);
			BackgroundThreadRunning = false;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ProcessQueueBegin(int queueSize)
		{
			if (CurrentQueueProcess.Stopwatch.IsRunning)
			{
				Log.Error("ProcessQueueBegin called while stopwatch ware already running!", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManagerDebugger.cs");
				CurrentQueueProcess.Stopwatch.Stop();
			}
			CurrentQueueProcess.Stopwatch.Reset();
			CurrentQueueProcess.Stopwatch.Start();
			CurrentQueueProcess.Count = queueSize;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ProcessQueueEnd()
		{
			CurrentQueueProcess.Stopwatch.Stop();
			queueProcess = new ResultInfo
			{
				Count = CurrentQueueProcess.Count,
				Time = CurrentQueueProcess.Stopwatch.ElapsedMilliseconds
			};
			CurrentQueueProcess.Count = 0;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ReProcessAllBegin(int allCount)
		{
			if (CurrentReProcessAll.Stopwatch.IsRunning)
			{
				Log.Warning("ReProcessAllBegin called while stopwatch ware already running!", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileHaulingManagerDebugger.cs");
				CurrentReProcessAll.Stopwatch.Stop();
			}
			CurrentReProcessAll.Stopwatch.Reset();
			CurrentReProcessAll.Stopwatch.Start();
			CurrentReProcessAll.Count = allCount;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ReProcessAllEnd()
		{
			CurrentReProcessAll.Stopwatch.Stop();
			reProcessAll = new ResultInfo
			{
				Count = CurrentReProcessAll.Count,
				Time = CurrentReProcessAll.Stopwatch.ElapsedMilliseconds
			};
			CurrentReProcessAll.Count = 0;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ClearResults()
		{
			queueProcess = default(ResultInfo);
			reProcessAll = default(ResultInfo);
		}

		[Conditional("UNITY_EDITOR")]
		public static void UpdateThreadState(bool state)
		{
			BackgroundThreadRunning = state;
		}
	}
}
