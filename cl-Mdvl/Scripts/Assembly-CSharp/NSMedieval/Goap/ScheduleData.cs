using System;
using System.Collections.Generic;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Goap
{
	[Serializable]
	public struct ScheduleData
	{
		public struct GoalPriority
		{
			private float priority;

			private string goal;

			public float Priority => priority;

			public string Goal => goal;

			public GoalPriority(float priority, string goal)
			{
				this.priority = priority;
				this.goal = goal;
			}
		}

		[SerializeField]
		private HourType hourType;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private SchedulePriority[] priorities;

		[SerializeField]
		private Color color;

		[SerializeField]
		private string[] activeEffectors;

		[SerializeField]
		private ScheduleDataSettings[] settings;

		[SerializeField]
		private bool isHidden;

		private GoalPriority[] goals;

		private float disableBelowPriority;

		public string ID => hourType.ToString();

		public HourType HourType => hourType;

		public bool IsHidden => isHidden;

		public GoalPriority[] Goals
		{
			get
			{
				if (goals == null)
				{
					List<GoalPriority> list = new List<GoalPriority>();
					if (priorities == null || priorities.Length == 0)
					{
						return null;
					}
					SchedulePriority[] array = priorities;
					foreach (SchedulePriority schedulePriority in array)
					{
						SchedulerJob[] jobs = schedulePriority.Jobs;
						foreach (SchedulerJob schedulerJob in jobs)
						{
							float num = 0f;
							string[] array2 = schedulerJob.Goals;
							foreach (string goal in array2)
							{
								list.Add(new GoalPriority(schedulerJob.Priority + schedulePriority.Priority + num, goal));
								num += 0.0001f;
							}
						}
					}
					list.Sort((GoalPriority x, GoalPriority y) => x.Priority.CompareTo(y.Priority));
					goals = list.ToArray();
				}
				return goals;
			}
		}

		public Color Color => color;

		public string[] ActiveEffectors => activeEffectors;

		public ScheduleDataSettings[] Settings => settings;

		public LocKeys[] LocKeys => locKeys;

		public string GetSettingsParameter(ScheduleDataSettingsType type, string value, string parameterId)
		{
			for (int i = 0; i < settings.Length; i++)
			{
				if (settings[i].Type == type && settings[i].Value.Equals(value))
				{
					return Array.Find(settings[i].Parameters, (StringStringPair entry) => entry.Key.Equals(parameterId)).Value;
				}
			}
			return string.Empty;
		}

		public bool ContainsGoal(string goal)
		{
			GoalPriority[] array = Goals;
			if (array == null || array.Length == 0)
			{
				return false;
			}
			GoalPriority[] array2 = array;
			foreach (GoalPriority goalPriority in array2)
			{
				if (goalPriority.Goal == goal)
				{
					return true;
				}
			}
			return false;
		}
	}
}
