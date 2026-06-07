using ManagementScripts;
using SettingScripts;
using SteamIntegrations;
using UnityEngine;

namespace OneUseScripts
{
	public class TimeKeeper : MonoBehaviour
	{
		private float tps;

		private float stps;

		public static float fps;

		public static double simulatedTime = 0.0;

		public int hours;

		public int minutes;

		public int seconds;

		public float updateInterval = 0.5f;

		private double lastRenderRealTime;

		private int renderFrames;

		private double lastRenderInterval;

		private double lastFixedInterval;

		private double lastFixedRealTime;

		private int fixedFrames;

		private static readonly FloatSetting TimeScale = TimeController.engineTimeScale;

		private static float timeScale = TimeScale.SubscribeTo<FloatSetting, float>(UpdateSimTimeScale);

		private static readonly IntSetting SimTPS = ScenarioIndependentSettings.Instance.simTPS;

		private static int simTPS = SimTPS.SubscribeTo<IntSetting, int>(UpdateSimTPS);

		private double timeSinceSceneLoaded;

		private bool triggered7Days;

		private float timeBellow1FPS;

		private int framesBellow1FPS;

		public static bool firstUpdate = true;

		private bool wasPaused;

		private bool wasFixedPaused;

		public float logicFramePerSeconds => tps;

		public float simSecondsPerSeconds => stps;

		public float renderFramesPerSecond => fps;

		private static void UpdateSimTPS(int val)
		{
			simTPS = val;
		}

		private static void UpdateSimTimeScale(float val)
		{
			timeScale = val;
		}

		private void Start()
		{
			hours = 0;
			minutes = 0;
			seconds = 0;
			lastRenderInterval = Time.realtimeSinceStartupAsDouble;
			lastFixedInterval = Time.realtimeSinceStartupAsDouble;
			renderFrames = 0;
			fixedFrames = 0;
		}

		public void UpdateTimes()
		{
			int[] array = ParseTime(simulatedTime);
			hours = array[0];
			minutes = array[1];
			seconds = array[2];
		}

		private void Update()
		{
			if (TimeController.paused)
			{
				wasPaused = (wasFixedPaused = true);
				return;
			}
			if (wasPaused)
			{
				lastRenderInterval = Time.realtimeSinceStartupAsDouble;
				renderFrames = 0;
				wasPaused = false;
				return;
			}
			timeSinceSceneLoaded += Time.deltaTime;
			renderFrames++;
			double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
			if (realtimeSinceStartupAsDouble > lastRenderInterval + (double)updateInterval)
			{
				fps = (float)((double)renderFrames / (realtimeSinceStartupAsDouble - lastRenderInterval));
				renderFrames = 0;
				lastRenderInterval = realtimeSinceStartupAsDouble;
				if (!firstUpdate)
				{
					TimeController.Instance.CheckMinFPS(fps);
				}
				firstUpdate = false;
			}
			if (timeScale > 0f && fps < 1.5f && !firstUpdate)
			{
				timeBellow1FPS += Time.unscaledDeltaTime;
				framesBellow1FPS++;
				if (timeBellow1FPS >= 60f && framesBellow1FPS > 10)
				{
					AchievementManager.Trigger("ACH_SIM_1FPS");
				}
			}
			else
			{
				framesBellow1FPS = 0;
				timeBellow1FPS = 0f;
			}
			if (!triggered7Days)
			{
				int num = hours;
				if (num >= 168 && num < 170)
				{
					triggered7Days = true;
					AchievementManager.Trigger("ACH_SIM_7DAYS");
				}
			}
		}

		private void FixedUpdate()
		{
			if (wasFixedPaused)
			{
				fixedFrames = 0;
				lastFixedInterval = Time.realtimeSinceStartupAsDouble;
				wasFixedPaused = false;
				simulatedTime += Time.fixedDeltaTime;
				return;
			}
			simulatedTime += Time.fixedDeltaTime;
			fixedFrames++;
			double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
			if (realtimeSinceStartupAsDouble > lastFixedInterval + (double)updateInterval)
			{
				tps = (float)((double)fixedFrames / (realtimeSinceStartupAsDouble - lastFixedInterval));
				stps = tps * Time.fixedDeltaTime;
				fixedFrames = 0;
				lastFixedInterval = realtimeSinceStartupAsDouble;
			}
		}

		public static int[] ParseTime(double time)
		{
			int num = Mathf.FloorToInt((float)time);
			int num2 = num % 60;
			int num3 = (num - num2) / 60;
			int num4 = num3 % 60;
			int num5 = (num3 - num4) / 60;
			num2 = Mathf.FloorToInt((float)(time % 60.0));
			return new int[3] { num5, num4, num2 };
		}
	}
}
