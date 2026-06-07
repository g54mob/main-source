using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class ScheduleManager : Singleton<ScheduleManager>
	{
		private class Interval
		{
			private Action Action { get; }

			private TimeMode TimeMode { get; }

			private float Duration { get; }

			private float LastTime { get; set; }

			public bool CanRun => TimeMode.Time >= LastTime + Duration;

			public Interval(Action action, float duration, TimeMode.UpdateMode mode)
			{
				Action = action;
				TimeMode = new TimeMode(mode);
				Duration = duration;
				Run();
			}

			public void Run()
			{
				Action?.Invoke();
				LastTime = TimeMode.Time;
			}
		}

		private static int IntervalCounter;

		[NonSerialized]
		private Dictionary<int, Interval> m_Intervals;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_Intervals = new Dictionary<int, Interval>();
		}

		private void Update()
		{
			foreach (KeyValuePair<int, Interval> interval in m_Intervals)
			{
				if (interval.Value.CanRun)
				{
					interval.Value.Run();
				}
			}
		}

		public async Task RunIn(Action action, float time, TimeMode.UpdateMode mode)
		{
			TimeMode timeMode = new TimeMode(mode);
			float startTime = timeMode.Time;
			while (timeMode.Time < startTime + time)
			{
				if (ApplicationManager.IsExiting)
				{
					return;
				}
				await Task.Yield();
			}
			action?.Invoke();
		}

		public int RunInterval(Action action, float interval, TimeMode.UpdateMode mode)
		{
			int num = ++IntervalCounter;
			m_Intervals[num] = new Interval(action, interval, mode);
			return num;
		}

		public void StopInterval(int intervalId)
		{
			m_Intervals.Remove(intervalId);
		}
	}
}
