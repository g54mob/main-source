using System;
using System.Collections.Generic;
using Restory.Data.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class TimeIntervalsTracker : ITimeChangeReceiver, IInitializable, IDisposable
	{
		private class TimeIntervalData
		{
			public ITimeInterval Interval;

			public bool IsTimeInIntervalNow;
		}

		private readonly GameCalendar gameCalendar;

		private readonly List<TimeIntervalData> intervals = new List<TimeIntervalData>();

		private readonly List<ITimeInterval> intervalsToAdd = new List<ITimeInterval>();

		private readonly List<ITimeInterval> intervalsToRemove = new List<ITimeInterval>();

		public event Action OnActiveIntervalsChanged;

		public TimeIntervalsTracker(GameCalendar gameCalendar, params TimeIntervalInfo[] initialIntervals)
		{
			this.gameCalendar = gameCalendar;
			foreach (TimeIntervalInfo interval in initialIntervals)
			{
				intervals.Add(new TimeIntervalData
				{
					Interval = interval,
					IsTimeInIntervalNow = false
				});
			}
		}

		public void Initialize()
		{
			gameCalendar.AddSubscriber(this);
			ProcessTimeChanged();
		}

		public void Dispose()
		{
			if (gameCalendar != null)
			{
				gameCalendar.RemoveSubscriber(this);
			}
			intervals.Clear();
			intervalsToAdd.Clear();
			intervalsToRemove.Clear();
		}

		public void ProcessTimeChanged()
		{
			TimeSpan currentRoundedTime = GetCurrentRoundedTime();
			AddNewIntervals(currentRoundedTime, out var isTimeInAnyOfNewIntervals);
			RemoveExistingIntervals(out var wasTimeInAnyOfRemovedIntervals);
			bool flag = isTimeInAnyOfNewIntervals || wasTimeInAnyOfRemovedIntervals;
			foreach (TimeIntervalData interval in intervals)
			{
				bool flag2 = interval.Interval.IsInInterval(currentRoundedTime);
				if ((!flag2 && interval.IsTimeInIntervalNow) || (flag2 && !interval.IsTimeInIntervalNow))
				{
					flag = true;
				}
				interval.IsTimeInIntervalNow = flag2;
			}
			if (flag)
			{
				this.OnActiveIntervalsChanged?.Invoke();
			}
		}

		public void AddInterval(ITimeInterval intervalToAdd)
		{
			if (intervalToAdd == null)
			{
				return;
			}
			foreach (ITimeInterval item in intervalsToAdd)
			{
				if (item.ID == intervalToAdd.ID)
				{
					return;
				}
			}
			for (int num = intervalsToRemove.Count - 1; num >= 0; num--)
			{
				if (intervalsToRemove[num].ID == intervalToAdd.ID)
				{
					intervalsToRemove.RemoveAt(num);
					return;
				}
			}
			foreach (TimeIntervalData interval in intervals)
			{
				if (interval.Interval.ID == intervalToAdd.ID)
				{
					return;
				}
			}
			intervalsToAdd.Add(intervalToAdd);
		}

		public void RemoveInterval(ITimeInterval intervalToRemove)
		{
			if (intervalToRemove == null)
			{
				return;
			}
			for (int num = intervalsToRemove.Count - 1; num >= 0; num--)
			{
				if (intervalsToRemove[num].ID == intervalToRemove.ID)
				{
					intervalsToRemove.RemoveAt(num);
					return;
				}
			}
			intervalsToRemove.Add(intervalToRemove);
		}

		public bool IsTimeInIntervalNow(ITimeInterval interval)
		{
			if (interval == null)
			{
				return false;
			}
			foreach (TimeIntervalData interval2 in intervals)
			{
				if (interval.ID == interval2.Interval.ID)
				{
					return interval2.IsTimeInIntervalNow;
				}
			}
			return false;
		}

		public IEnumerable<ITimeInterval> GetAllIntervalsTimeIsCurrentlyIn()
		{
			foreach (TimeIntervalData interval in intervals)
			{
				if (interval.IsTimeInIntervalNow)
				{
					yield return interval.Interval;
				}
			}
		}

		private TimeSpan GetCurrentRoundedTime()
		{
			return TimeSpan.FromSeconds(Mathf.FloorToInt((float)gameCalendar.CurrentDateTime.TimeOfDay.TotalSeconds));
		}

		private void AddNewIntervals(TimeSpan currentRoundedTime, out bool isTimeInAnyOfNewIntervals)
		{
			isTimeInAnyOfNewIntervals = false;
			foreach (ITimeInterval item in intervalsToAdd)
			{
				bool flag = item.IsInInterval(currentRoundedTime);
				intervals.Add(new TimeIntervalData
				{
					Interval = item,
					IsTimeInIntervalNow = flag
				});
				if (flag)
				{
					isTimeInAnyOfNewIntervals = true;
				}
			}
			intervalsToAdd.Clear();
		}

		private void RemoveExistingIntervals(out bool wasTimeInAnyOfRemovedIntervals)
		{
			wasTimeInAnyOfRemovedIntervals = false;
			foreach (ITimeInterval item in intervalsToRemove)
			{
				for (int num = intervals.Count - 1; num >= 0; num--)
				{
					TimeIntervalData timeIntervalData = intervals[num];
					if (timeIntervalData.Interval.ID == item.ID)
					{
						if (timeIntervalData.IsTimeInIntervalNow)
						{
							wasTimeInAnyOfRemovedIntervals = true;
						}
						intervals.RemoveAt(num);
					}
				}
			}
			intervalsToRemove.Clear();
		}
	}
}
