using System;
using System.Collections.Generic;

namespace Assets.Scripts.Analysis.Analytics
{
	internal static class UnityAnalytics
	{
		private static TimeSpan? _accumulatedTime = default(TimeSpan);

		private static bool _analyticsTimerPaused = false;

		private static DateTime _startTime = DateTime.Now;

		public static double MinutesAccumulated
		{
			get
			{
				double totalMinutes = DateTime.Now.Subtract(_startTime).TotalMinutes;
				if (!_accumulatedTime.HasValue)
				{
					return totalMinutes;
				}
				return _accumulatedTime.Value.TotalMinutes + (_analyticsTimerPaused ? 0.0 : totalMinutes);
			}
		}

		public static void Initialize()
		{
		}

		public static void PauseTimer()
		{
			if (!_analyticsTimerPaused)
			{
				if (!_accumulatedTime.HasValue)
				{
					_accumulatedTime = default(TimeSpan);
				}
				_analyticsTimerPaused = true;
				_accumulatedTime += DateTime.Now.Subtract(_startTime);
			}
		}

		public static void RestartTimer()
		{
			_startTime = DateTime.Now;
			_accumulatedTime = null;
		}

		public static void ResumeTimer()
		{
			if (_analyticsTimerPaused)
			{
				_startTime = DateTime.Now;
				_analyticsTimerPaused = false;
			}
		}

		public static void SceneExited(bool designer)
		{
			try
			{
				string name = Game.Instance.CurrentLevel.Name;
				int num = (int)MinutesAccumulated;
				Dictionary<string, object> eventData = new Dictionary<string, object>
				{
					{ "name", name },
					{ "designer", designer },
					{ "playTime", num }
				};
				CustomEvent("Level", eventData);
				_accumulatedTime = null;
			}
			catch (Exception)
			{
			}
		}

		private static void CustomEvent(string eventName, Dictionary<string, object> eventData)
		{
		}
	}
}
