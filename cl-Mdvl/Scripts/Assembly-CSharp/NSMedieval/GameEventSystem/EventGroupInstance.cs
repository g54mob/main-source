using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Model.MapNew;
using NSMedieval.Objectives;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using Objectives;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class EventGroupInstance
	{
		private EventGroup blueprint;

		public EventGroup Blueprint => blueprint;

		public int DaysPast
		{
			get
			{
				Dictionary<string, int> daysPastSinceEvent = GlobalSaveController.CurrentVillageData.DaysPastSinceEvent;
				if (!daysPastSinceEvent.ContainsKey(Blueprint.GetID()))
				{
					daysPastSinceEvent.Add(Blueprint.GetID(), 0);
				}
				return daysPastSinceEvent[Blueprint.GetID()];
			}
			set
			{
				Dictionary<string, int> daysPastSinceEvent = GlobalSaveController.CurrentVillageData.DaysPastSinceEvent;
				if (!daysPastSinceEvent.ContainsKey(Blueprint.GetID()))
				{
					daysPastSinceEvent.Add(Blueprint.GetID(), value);
				}
				else
				{
					daysPastSinceEvent[Blueprint.GetID()] = value;
				}
			}
		}

		public EventGroupInstance(EventGroup blueprint)
		{
			this.blueprint = blueprint;
		}

		public float GetDaysPastMultiplier()
		{
			if (Blueprint.DaysPastMultipliers.IsEmpty())
			{
				return 1f;
			}
			return Blueprint.DaysPastMultipliers.GetMultiplierInterpolated(DaysPast);
		}

		public float GetWorkersCountMultiplier(int workersCount)
		{
			if (Blueprint.WorkerCountMultipliers.IsEmpty())
			{
				return 1f;
			}
			return Blueprint.WorkerCountMultipliers.GetMultiplierInterpolated(workersCount);
		}

		public float GetValue(int workersCount, int prisonersCount)
		{
			if (Blueprint.Events != null && Blueprint.Events.Count > 0 && !Blueprint.GameEvents.Any())
			{
				return 0f;
			}
			float num = GetDaysPastMultiplier();
			if (num > 0f)
			{
				num *= GetWorkersCountMultiplier(workersCount);
			}
			if (num > 0f)
			{
				num *= GetSeasonMultiplier();
			}
			if (num > 0f)
			{
				num *= GetAnimalMultiplier();
			}
			if (num > 0f)
			{
				num *= GetMapTypeMultiplier();
			}
			if (num > 0f)
			{
				num *= GetPrisonersCountMultiplier(prisonersCount);
			}
			if (num > 0f)
			{
				num *= GetUniqueResourceModifier();
			}
			if (num > 0f)
			{
				num *= GetActiveObjectiveModifier();
			}
			if (num > 0f)
			{
				num *= GetNeededResourcesModifier();
			}
			float num2 = Blueprint.BaseValue;
			if (GlobalSaveController.CurrentVillageData.GameParametersCurrent.HasOption(Blueprint.GetID()))
			{
				num2 = GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById(Blueprint.GetID());
			}
			return num2 * num;
		}

		public float GetNeededResourcesModifier()
		{
			if (Blueprint.NeedResources == null)
			{
				return 1f;
			}
			if (!NeedResource.CheckNeededResources(Blueprint.NeedResources))
			{
				return 0f;
			}
			return 1f;
		}

		public float GetUniqueResourceModifier()
		{
			if (Blueprint.NeedUniqueResources == null)
			{
				return 1f;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			int num = 0;
			string[] needUniqueResources = Blueprint.NeedUniqueResources;
			foreach (string resourceId in needUniqueResources)
			{
				if (map.UniqueResourceTracker.GetUniqueResourceCount(resourceId) > 0)
				{
					num++;
				}
			}
			if (blueprint.SkipIfAnyUniqueResourceFound)
			{
				if (num <= 0)
				{
					return 1f;
				}
				return 0f;
			}
			if (num != Blueprint.NeedUniqueResources.Length)
			{
				return 0f;
			}
			return 1f;
		}

		public float GetActiveObjectiveModifier()
		{
			if (string.IsNullOrEmpty(Blueprint.ActiveObjective))
			{
				return 1f;
			}
			if (!MonoSingleton<ObjectiveManager>.IsInstantiated())
			{
				return 0f;
			}
			ObjectiveInstance activeObjective = MonoSingleton<ObjectiveManager>.Instance.ActiveObjective;
			if (activeObjective == null)
			{
				return 0f;
			}
			if (!(activeObjective.BlueprintId == Blueprint.ActiveObjective))
			{
				return 0f;
			}
			return 1f;
		}

		public float GetPrisonersCountMultiplier(int prisonersCount)
		{
			if (Blueprint.PrisonerCountMultipliers.IsEmpty())
			{
				return 1f;
			}
			return Blueprint.PrisonerCountMultipliers.GetMultiplierInterpolated(prisonersCount);
		}

		public float GetAnimalMultiplier()
		{
			float num = 0f;
			int num2 = 0;
			foreach (GameEvent gameEvent in Blueprint.GameEvents)
			{
				if (gameEvent.HasAnimalType)
				{
					num2++;
					num += gameEvent.GetAnimalEventChance();
				}
			}
			if (num2 == 0)
			{
				return 1f;
			}
			return num / (float)num2;
		}

		public void ResetDaysPastCounters()
		{
			foreach (string resetCounter in blueprint.ResetCounters)
			{
				EventGroupInstance eventGroup = MonoSingleton<EventScheduler>.Instance.GetEventGroup(resetCounter);
				if (eventGroup != null)
				{
					eventGroup.DaysPast = 0;
				}
			}
		}

		private float GetSeasonMultiplier()
		{
			if (Blueprint.SeasonMultipliers == null || !MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return 1f;
			}
			string name = GlobalSaveController.CurrentVillageData.DateAndTime.Season.Name;
			if (!Blueprint.SeasonMultipliers.Dictionary.ContainsKey(name))
			{
				return 1f;
			}
			return Blueprint.SeasonMultipliers.Dictionary[name];
		}

		private float GetMapTypeMultiplier()
		{
			if (Blueprint.MapTypeMultipliers == null || !MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
			{
				return 1f;
			}
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			if (mapBlueprint == null || mapBlueprint.GetID() == null)
			{
				return 1f;
			}
			if (!Blueprint.MapTypeMultipliers.Dictionary.ContainsKey(mapBlueprint.GetID()))
			{
				return 1f;
			}
			return Blueprint.MapTypeMultipliers.Dictionary[mapBlueprint.GetID()];
		}
	}
}
