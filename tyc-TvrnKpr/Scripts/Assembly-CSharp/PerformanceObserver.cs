using System;
using System.Collections.Generic;

public static class PerformanceObserver
{
	private static class FPSObserver
	{
		private static float _evaluationTime;

		private static float _recoveryTime;

		private static float _fpsThreshold;

		private static Action<bool> _callback;

		private static float _chunkTotalTime;

		private static int _chunkFrameCount;

		private static readonly List<float> _frameTimes;

		public static void Initialize(float evaluationTime, float recoveryTime, float fpsThreshold, Action<bool> callback)
		{
		}

		public static void Update()
		{
		}
	}

	public static bool DetectedLowPerformance { get; set; }

	public static void Init()
	{
	}

	public static void Update()
	{
	}

	private static void HandleLowPerformance(bool isLowPerformance)
	{
	}
}
