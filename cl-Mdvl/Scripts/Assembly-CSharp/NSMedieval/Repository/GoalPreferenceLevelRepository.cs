using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class GoalPreferenceLevelRepository : DynamicJsonRepository<GoalPreferenceLevelRepository, GoalPreferenceLevelData>
	{
		private const string DefaultLevel = "Indifferent";

		private Dictionary<GoalPreferenceLevel, GoalPreferenceLevelData> goalPreferenceDataByPreferenceLevelCached;

		protected override string JsonFile()
		{
			return "Worker/GoalPreferenceLevelData.json";
		}

		public GoalPreferenceLevelData GetDataByPreferenceLevel(GoalPreferenceLevel preferenceLevel)
		{
			if (preferenceLevel == GoalPreferenceLevel.None)
			{
				Debug.LogError("GoalPreferenceLevelRepository.GetDataByPreferenceLevel: preferenceLevel is None");
			}
			if (goalPreferenceDataByPreferenceLevelCached.TryGetValue(preferenceLevel, out var value))
			{
				return value;
			}
			return GetByID("Indifferent");
		}

		public GoalPreferenceLevelData GetDataByPreferenceLevel(int preferenceLevel)
		{
			return GetDataByPreferenceLevel((GoalPreferenceLevel)preferenceLevel);
		}

		public GoalPreferenceLevelData GetCumulativeLevelData(GoalPreferenceLevel currentValue, GoalPreferenceLevel valueToAdd)
		{
			return GetCumulativeLevelData((int)currentValue, (int)valueToAdd);
		}

		public GoalPreferenceLevelData GetCumulativeLevelData(int currentValue, int valueToAdd)
		{
			if (currentValue == valueToAdd)
			{
				return GetDataByPreferenceLevel(currentValue);
			}
			int num = valueToAdd - 3;
			int preferenceLevel = Mathf.Clamp(currentValue + num, 1, 5);
			return GetDataByPreferenceLevel(preferenceLevel);
		}

		public override void Deserialize()
		{
			base.Deserialize();
			goalPreferenceDataByPreferenceLevelCached = new Dictionary<GoalPreferenceLevel, GoalPreferenceLevelData>();
			foreach (GoalPreferenceLevelData allItem in GetAllItems())
			{
				goalPreferenceDataByPreferenceLevelCached.Add(allItem.PreferenceLevel, allItem);
			}
		}
	}
}
