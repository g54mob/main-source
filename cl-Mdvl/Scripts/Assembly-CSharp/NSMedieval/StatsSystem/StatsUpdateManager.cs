using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.GameDifficulty;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class StatsUpdateManager : MonoSingleton<StatsUpdateManager>
	{
		private class StatUpdateContainer : IDisposable
		{
			private const long PauseUpdateAfterMilliseconds = 3L;

			private readonly float minutesInHour = (int)Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().MinutesInHour;

			private readonly float statUpdateInterval = (float)(int)Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().MinutesInHour / (float)(int)Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().StatsUpdatePerHour;

			private readonly List<StatsInstance> stats = new List<StatsInstance>();

			private int nextStatToUpdate;

			private float timeAccumulator;

			private float stepTime;

			public void RegisterStat(StatsInstance statsInstance)
			{
				stats.Add(statsInstance);
			}

			public void UnregisterStat(StatsInstance statsInstance)
			{
				stats.Remove(statsInstance);
			}

			public void UpdateStats(float deltaTime)
			{
				if (timeAccumulator <= statUpdateInterval && nextStatToUpdate == 0)
				{
					timeAccumulator += deltaTime;
					return;
				}
				float num = timeAccumulator / minutesInHour;
				DateTime utcNow = DateTime.UtcNow;
				for (int i = nextStatToUpdate; i < stats.Count; i++)
				{
					nextStatToUpdate = i + 1;
					if (stats[i] != null && (stats[i].OwnerHumanoidInstance == null || !stats[i].OwnerHumanoidInstance.IsInIncognitoMode()) && (stats[i].OwnerAnimalInstance == null || !stats[i].OwnerAnimalInstance.IsInIncognitoMode()))
					{
						stats[i].Update(num);
						if (i % 4 == 0 && (DateTime.UtcNow - utcNow).TotalMilliseconds > 3.0)
						{
							break;
						}
					}
				}
				if (nextStatToUpdate >= stats.Count)
				{
					nextStatToUpdate = 0;
					timeAccumulator = 0f;
				}
			}

			public void Dispose()
			{
				stats.Clear();
			}
		}

		private const float TickAllEffectorsTimeFrame = 1.5f;

		private bool initialized;

		private StatUpdateContainer workerStatsContainer;

		private StatUpdateContainer animalStatsContainer;

		private StatUpdateContainer plantStatsContainer;

		private StatUpdateContainer defaultStatsContainer;

		private List<StatsInstance> tickableEffectorStats;

		private int tickEffectorCurrentIndex;

		private Dictionary<string, List<AttributeInstance>> attributeCache;

		private void Initialize()
		{
			workerStatsContainer = new StatUpdateContainer();
			animalStatsContainer = new StatUpdateContainer();
			plantStatsContainer = new StatUpdateContainer();
			defaultStatsContainer = new StatUpdateContainer();
			attributeCache = new Dictionary<string, List<AttributeInstance>>();
			tickableEffectorStats = new List<StatsInstance>();
			initialized = true;
		}

		public void RegisterStat(StatsInstance statsInstance)
		{
			if (!initialized)
			{
				Initialize();
			}
			if (statsInstance.NeedTickEffectors)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsUpdateManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding stats instance to tickable list for owner ");
					messageBuilder.AppendFormatted(statsInstance.Owner);
				}
				Log.Trace(messageBuilder);
				tickableEffectorStats.Add(statsInstance);
			}
			IStatsOwner owner = statsInstance.Owner;
			if (owner is BaseBuildingInstance)
			{
				return;
			}
			if (!(owner is HumanoidInstance))
			{
				if (!(owner is AnimalInstance))
				{
					if (owner is MapResourceInstance)
					{
						plantStatsContainer.RegisterStat(statsInstance);
					}
					else
					{
						defaultStatsContainer.RegisterStat(statsInstance);
					}
				}
				else
				{
					animalStatsContainer.RegisterStat(statsInstance);
				}
			}
			else
			{
				workerStatsContainer.RegisterStat(statsInstance);
			}
			foreach (AttributeInstance value2 in statsInstance.Attributes.Values)
			{
				string difficultyOptionId = value2.Blueprint.DifficultyOptionId;
				if (!string.IsNullOrEmpty(difficultyOptionId))
				{
					attributeCache.TryGetValue(difficultyOptionId, out var value);
					if (value == null)
					{
						attributeCache.Add(difficultyOptionId, new List<AttributeInstance>());
						attributeCache[difficultyOptionId].Add(value2);
					}
					else
					{
						value.Add(value2);
					}
				}
			}
		}

		public void UnregisterStat(StatsInstance statsInstance)
		{
			if (statsInstance == null)
			{
				Log.Error("StatsInstance is null when unregistering stat", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\StatsUpdateManager.cs");
				return;
			}
			if (statsInstance.NeedTickEffectors)
			{
				tickableEffectorStats.Remove(statsInstance);
			}
			IStatsOwner owner = statsInstance.Owner;
			if (owner is BaseBuildingInstance)
			{
				return;
			}
			if (!(owner is HumanoidInstance))
			{
				if (!(owner is AnimalInstance))
				{
					if (owner is MapResourceInstance)
					{
						plantStatsContainer.UnregisterStat(statsInstance);
					}
					else
					{
						defaultStatsContainer.UnregisterStat(statsInstance);
					}
				}
				else
				{
					animalStatsContainer.UnregisterStat(statsInstance);
				}
			}
			else
			{
				workerStatsContainer.UnregisterStat(statsInstance);
			}
			foreach (AttributeInstance value2 in statsInstance.Attributes.Values)
			{
				string difficultyOptionId = value2.Blueprint.DifficultyOptionId;
				if (!string.IsNullOrEmpty(difficultyOptionId))
				{
					attributeCache.TryGetValue(difficultyOptionId, out var value);
					value?.Remove(value2);
				}
			}
		}

		public void DifficultyChanged(GameParametersInstance oldGameParameters, GameParametersInstance newGameParameters)
		{
			foreach (string key in oldGameParameters.OptionsDictionary.Dictionary.Keys)
			{
				if (Math.Abs(oldGameParameters.OptionsDictionary.Dictionary[key] - newGameParameters.OptionsDictionary.Dictionary[key]) > 0.01f)
				{
					RefreshAttributes(key);
				}
			}
		}

		private void RefreshAttributes(string id)
		{
			attributeCache.TryGetValue(id, out var value);
			if (value == null)
			{
				return;
			}
			foreach (var (attributeInstance, index) in value.IterateInReverseDynamicWithIndex())
			{
				if (attributeInstance == null)
				{
					value.RemoveAt(index);
				}
			}
			foreach (AttributeInstance item in value)
			{
				item.RefreshDifficultyModifier();
			}
		}

		private void TickEffectors(float deltaTime)
		{
			int num = (int)((float)tickableEffectorStats.Count * deltaTime / 1.5f);
			int num2 = tickEffectorCurrentIndex + num;
			long minutesTotal = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
			int minutesInHour = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			while (tickEffectorCurrentIndex < num2)
			{
				if (tickEffectorCurrentIndex >= tickableEffectorStats.Count)
				{
					tickEffectorCurrentIndex = 0;
					break;
				}
				tickableEffectorStats[tickEffectorCurrentIndex].HandleEffectorTimers(minutesTotal, minutesInHour);
				tickEffectorCurrentIndex++;
			}
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
			base.OnDestroy();
			if (attributeCache != null)
			{
				foreach (List<AttributeInstance> value in attributeCache.Values)
				{
					value.Clear();
				}
				attributeCache.Clear();
			}
			workerStatsContainer?.Dispose();
			workerStatsContainer = null;
			animalStatsContainer?.Dispose();
			animalStatsContainer = null;
			plantStatsContainer?.Dispose();
			plantStatsContainer = null;
			defaultStatsContainer?.Dispose();
			defaultStatsContainer = null;
		}

		private void OnSceneSetup()
		{
			MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
		}

		private void OnTick(float deltaTime)
		{
			if (LoadingController.IsLeavingMainScene || LoadingController.IsSceneTransition || !MonoSingleton<World>.IsInstantiated())
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("StatsUpdateManager.Tick"))
			{
				workerStatsContainer.UpdateStats(deltaTime);
				animalStatsContainer.UpdateStats(deltaTime);
				plantStatsContainer.UpdateStats(deltaTime);
				defaultStatsContainer.UpdateStats(deltaTime);
				TickEffectors(deltaTime);
			}
		}
	}
}
