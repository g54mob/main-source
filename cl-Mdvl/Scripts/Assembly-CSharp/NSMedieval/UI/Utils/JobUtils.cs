using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Model;
using NSMedieval.Dictionary;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class JobUtils
	{
		private static IntRange priorityRange;

		public const int TotalPriorities = 5;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			priorityRange = null;
		}

		public static int GetPriorityInterpolated(int current, int priority, bool jobActive)
		{
			int num = current + priority;
			if (jobActive)
			{
				num = ((num <= PriorityRange().Max && num >= PriorityRange().Min) ? priority : 0);
			}
			else if (priority < 0)
			{
				num = PriorityRange().Max - current;
			}
			else if (priority > 0)
			{
				num = PriorityRange().Min - current;
			}
			return num;
			static IntRange PriorityRange()
			{
				int num2 = 2;
				int max = 5 + num2;
				int min = 5 - num2;
				return priorityRange ?? (priorityRange = new IntRange(min, max));
			}
		}

		public static int GetJobPriorityDisplay(int current, bool jobActive)
		{
			if (!jobActive)
			{
				return 0;
			}
			int num = 2;
			int num2 = current - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			else if (num2 > 5)
			{
				num2 = 5;
			}
			return num2;
		}

		public static int GetJobPriorityTruncated(float priority)
		{
			return Mathf.RoundToInt((priority - (float)(int)priority) * 10f);
		}

		public static JobTypeIntDictionary UpdatePrioritiesDictionary(JobTypeIntDictionary priorities, HumanoidInstance humanoidInstance)
		{
			if (priorities.Dictionary.Count > 0)
			{
				return priorities;
			}
			JobType[] allJobTypes = EnumValues.AllJobTypes;
			foreach (JobType jobType in allJobTypes)
			{
				if (jobType == JobType.None)
				{
					continue;
				}
				GoalPreferenceLevelData value = humanoidInstance.GoalPreferences.GetGoalPrefDictionary().FirstOrDefault((KeyValuePair<GoalPreference, GoalPreferenceLevelData> kvp) => kvp.Key.IsRelatedToJob(jobType)).Value;
				if (!(value == null))
				{
					int value2 = 0;
					switch (value.PreferenceLevel)
					{
					case GoalPreferenceLevel.Resentful:
						value2 = 2;
						break;
					case GoalPreferenceLevel.Unwilling:
						value2 = 1;
						break;
					case GoalPreferenceLevel.Indifferent:
						value2 = 0;
						break;
					case GoalPreferenceLevel.Eager:
						value2 = -1;
						break;
					case GoalPreferenceLevel.Passionate:
						value2 = -2;
						break;
					case GoalPreferenceLevel.Incapable:
						value2 = -4;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					case GoalPreferenceLevel.None:
						break;
					}
					priorities.Dictionary[jobType] = value2;
				}
			}
			return priorities;
		}
	}
}
