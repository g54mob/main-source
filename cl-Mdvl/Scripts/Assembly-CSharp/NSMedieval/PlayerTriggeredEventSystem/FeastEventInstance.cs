using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("FeastEventInstance", "")]
	public class FeastEventInstance : PlayerTriggeredEventInstance
	{
		private const string AlcoholQuality = "alcohol";

		private const string FoodQualityQuality = "foodQuality";

		private const string FoodVarietyQuality = "foodVariety";

		private const string NutritionQuality = "nutrition";

		public FeastEventInstance()
		{
		}

		public override IEnumerable<ResourceInstance> GetDisplayEventResources()
		{
			foreach (ResourceInstance displayEventResource in base.GetDisplayEventResources())
			{
				if (displayEventResource.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
				{
					yield return displayEventResource;
				}
			}
		}

		public override void Initialize()
		{
			base.Initialize();
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (CanParticipate(key) && CanPathFind(key) && !base.AttendeesByType[EventAttendeeType.RoleParticipant].Contains(key))
				{
					AddRemoveParticipant(key, add: true);
				}
			}
		}

		protected override void StartGathering()
		{
			AssignChairs();
			base.StartGathering();
		}

		public override IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			foreach (PlayerTriggeredEventInfo item in base.IterateEventQualityInfo())
			{
				yield return item;
			}
			yield return GetFoodVarietyInfo();
			yield return GetNutritionInfo();
			yield return GetFoodQuality();
			yield return GetAlcoholInfo();
		}

		private PlayerTriggeredEventInfo GetFoodQuality()
		{
			float num = 0f;
			int num2 = 0;
			foreach (KeyValuePair<Resource, int> eventResource in base.EventResources)
			{
				if (eventResource.Value > 0)
				{
					num += (float)(eventResource.Key.RazzleDazzle * eventResource.Value);
					num2 += eventResource.Value;
				}
			}
			int num3 = ((num != 0f) ? Mathf.RoundToInt(num / (float)num2) : 0);
			return GetEventInfo(base.Blueprint.GetEventQualitySetting("foodQuality"), num3.ToString(), num3);
		}

		private PlayerTriggeredEventInfo GetAlcoholInfo()
		{
			float totalByParticipant = GetTotalByParticipant(TotalAlcohol());
			return GetEventInfo(base.Blueprint.GetEventQualitySetting("alcohol"), $"{totalByParticipant:F1}", totalByParticipant);
		}

		private PlayerTriggeredEventInfo GetFoodVarietyInfo()
		{
			int num = 0;
			foreach (KeyValuePair<Resource, int> eventResource in base.EventResources)
			{
				if (eventResource.Key.Category.HasFlag(ResourceCategory.CtgEdible) && eventResource.Value > 0)
				{
					num++;
				}
			}
			return GetEventInfo(base.Blueprint.GetEventQualitySetting("foodVariety"), num.ToString(), num);
		}

		private PlayerTriggeredEventInfo GetNutritionInfo()
		{
			float totalByParticipant = GetTotalByParticipant(TotalNutrition());
			return GetEventInfo(base.Blueprint.GetEventQualitySetting("nutrition"), $"{totalByParticipant:F1}", totalByParticipant);
		}

		private float TotalNutrition()
		{
			float num = 0f;
			foreach (KeyValuePair<Resource, int> eventResource in base.EventResources)
			{
				num += eventResource.Key.Nutrition * (float)eventResource.Value;
			}
			return num;
		}

		private float TotalAlcohol()
		{
			float num = 0f;
			foreach (KeyValuePair<Resource, int> eventResource in base.EventResources)
			{
				num += (float)(eventResource.Key.AlcoholStrength * eventResource.Value);
			}
			return num;
		}

		public FeastEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
