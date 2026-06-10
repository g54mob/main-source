using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("RitualEventInstance", "")]
	public class RitualEventInstance : PlayerTriggeredEventInstance
	{
		private const string SacrificeQualityQuality = "sacrificeQuality";

		public RitualEventInstance()
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (CanParticipate(key) && CanPathFind(key) && !(key.Stats.GetStat(StatType.ReligiousAlignment).Current >= 50f) && !base.AttendeesByType[EventAttendeeType.RoleParticipant].Contains(key))
				{
					AddRemoveParticipant(key, add: true);
				}
			}
			int num = 0;
			AnimalInstance animalInstance = null;
			foreach (AnimalInstance key2 in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				AnimalSetting[] animalSettings = base.Blueprint.AnimalSettings;
				foreach (AnimalSetting animalSetting in animalSettings)
				{
					if (key2.AnimalType == animalSetting.AnimalType && CanParticipate(key2) && CanAnimalPathFind(key2) && key2.Blueprint.RitualSacrificeQuality > num)
					{
						num = key2.Blueprint.RitualSacrificeQuality;
						animalInstance = key2;
					}
				}
			}
			if (animalInstance != null)
			{
				AddRemoveAnimal(animalInstance, add: true);
			}
		}

		protected override void StartGathering()
		{
			ReserveRolePosition(base.HostBuilding.GetComponentInstance<RugComponentInstance>().WorkplacePositions);
			base.StartGathering();
			foreach (IEventParticipant item in base.AttendeesByType[EventAttendeeType.AnimalParticipant])
			{
				if (item is AnimalInstance animal)
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animal);
				}
			}
		}

		public override IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			foreach (PlayerTriggeredEventInfo item in base.IterateEventQualityInfo())
			{
				yield return item;
			}
			yield return AnimalQuality();
		}

		private PlayerTriggeredEventInfo AnimalQuality()
		{
			int num = base.AttendeesByType[EventAttendeeType.AnimalParticipant].Cast<AnimalInstance>().Sum((AnimalInstance animal) => animal.Blueprint.RitualSacrificeQuality);
			if (Interrupted())
			{
				num = 0;
			}
			return GetEventInfo(base.Blueprint.GetEventQualitySetting("sacrificeQuality"), num.ToString(CultureInfo.InvariantCulture), num);
		}

		public RitualEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
