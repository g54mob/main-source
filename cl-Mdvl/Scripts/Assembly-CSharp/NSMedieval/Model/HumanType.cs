using System;
using System.Collections.Generic;
using Models;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.Construction;
using NSMedieval.Goap;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HumanType : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string prefabMale;

		[SerializeField]
		private string prefabFemale;

		[SerializeField]
		private string thermalModelId;

		[SerializeField]
		private WarmthBase warmth;

		[SerializeField]
		private string dietModelId;

		[SerializeField]
		private string drinkDietModelId;

		[SerializeField]
		private StorageBase storageBase;

		[SerializeField]
		private EquipmentSlotType availableEquipmentSlots;

		[SerializeField]
		private string statsModelId;

		[SerializeField]
		private string appearanceID;

		[SerializeField]
		private string walkableModelFriendlyBlueprintId;

		[SerializeField]
		private string walkableModelAggressiveBlueprintId;

		[SerializeField]
		private string scheduleModelId;

		[SerializeField]
		private string scheduleConfigId;

		[SerializeField]
		private List<StringStringPair> sleepEffectors = new List<StringStringPair>();

		[SerializeField]
		private List<KeyIntPair> wakeUpEffectors = new List<KeyIntPair>();

		[SerializeField]
		private List<string> killedHumanEffectors = new List<string>();

		[SerializeField]
		private List<RangeBasedEffector> heightEffectors = new List<RangeBasedEffector>();

		[SerializeField]
		private List<RangeBasedEffector> weightEffectors = new List<RangeBasedEffector>();

		[SerializeField]
		private List<RangeBasedEffector> ageEffectors = new List<RangeBasedEffector>();

		[SerializeField]
		private List<AgeDeathCategory> oldAgeDeathRanges = new List<AgeDeathCategory>();

		[SerializeField]
		private List<string> breakdownEffectors;

		[SerializeField]
		private List<string> inspiredEffectors;

		[SerializeField]
		private List<string> becomePrisonerEffectors;

		[SerializeField]
		private string faintEffector;

		[SerializeField]
		private string restEffector;

		[SerializeField]
		private List<string> banishEffectors;

		[SerializeField]
		private List<string> diedEffectors;

		[SerializeField]
		private string raidWonEffector;

		[SerializeField]
		private string raidLostEffector;

		[SerializeField]
		private string eatStandingUpEffector;

		[SerializeField]
		private string eatWithoutTableEffector;

		[SerializeField]
		private string eatAtTableEffector;

		[SerializeField]
		private string afterVomitEffector;

		[SerializeField]
		private string entertainmentEffector;

		[SerializeField]
		private string[] spawnEffectors;

		[SerializeField]
		private string whileUntendedEffector;

		[SerializeField]
		private List<string> prayEffectors;

		[SerializeField]
		private List<string> sleepingOnGroundEffectors;

		[SerializeField]
		private List<TimedWounds> fireWounds;

		[SerializeField]
		private float breakdownChance;

		[SerializeField]
		private float inspiredChance;

		[NonSerialized]
		private StatsModel statsModelCache;

		[NonSerialized]
		private bool thermalModelInit;

		[NonSerialized]
		private WalkableModel walkableModelFriendlyCache;

		[NonSerialized]
		private WalkableModel walkableModelAggressiveCache;

		[NonSerialized]
		private ThermalModel thermalModelCache;

		[NonSerialized]
		private DietModel dietModelCache;

		[NonSerialized]
		private DietModel drinkDietModelCache;

		[NonSerialized]
		private ScheduleModel scheduleModelCache;

		[NonSerialized]
		private ScheduleConfig scheduleConfigCache;

		public WalkableModel WalkableModelFriendly
		{
			get
			{
				if (walkableModelFriendlyCache == null)
				{
					walkableModelFriendlyCache = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(WalkableModelFriendlyBlueprintId);
				}
				return walkableModelFriendlyCache;
			}
		}

		public WalkableModel WalkableModelAggressive
		{
			get
			{
				if (walkableModelAggressiveCache == null)
				{
					walkableModelAggressiveCache = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID(WalkableModelAggressiveBlueprintId);
				}
				return walkableModelAggressiveCache;
			}
		}

		public DietModel DietModel
		{
			get
			{
				if (dietModelCache == null)
				{
					dietModelCache = Repository<DietModelRepository, DietModel>.Instance.GetByID(DietModelId);
				}
				return dietModelCache;
			}
		}

		public DietModel DrinkDietModel
		{
			get
			{
				if (drinkDietModelCache == null)
				{
					drinkDietModelCache = Repository<DietModelRepository, DietModel>.Instance.GetByID(DrinkDietModelId);
				}
				return drinkDietModelCache;
			}
		}

		public StatsModel StatsModel
		{
			get
			{
				if (statsModelCache == null && !string.IsNullOrEmpty(StatsModelId))
				{
					statsModelCache = Repository<StatsModelRepository, StatsModel>.Instance.GetByID(StatsModelId);
				}
				return statsModelCache;
			}
		}

		public ThermalModel ThermalModel
		{
			get
			{
				if (!thermalModelInit)
				{
					thermalModelInit = true;
					thermalModelCache = (string.IsNullOrEmpty(ThermalModelId) ? null : Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(ThermalModelId));
				}
				return thermalModelCache;
			}
		}

		public ScheduleModel ScheduleModel
		{
			get
			{
				if (scheduleModelCache == null)
				{
					scheduleModelCache = Repository<ScheduleModelRepository, ScheduleModel>.Instance.GetByID(ScheduleModelId);
				}
				return scheduleModelCache;
			}
		}

		public ScheduleConfig ScheduleConfig
		{
			get
			{
				if (scheduleConfigCache == null)
				{
					scheduleConfigCache = Repository<ScheduleConfigRepository, ScheduleConfig>.Instance.GetByID(ScheduleConfigId);
				}
				return scheduleConfigCache;
			}
		}

		public string PrefabMale => prefabMale;

		public string PrefabFemale => prefabFemale;

		public string ThermalModelId => thermalModelId;

		public WarmthBase Warmth => warmth;

		public string DietModelId => dietModelId;

		public string DrinkDietModelId => drinkDietModelId;

		public StorageBase StorageBase => storageBase;

		public EquipmentSlotType AvailableEquipmentSlots => availableEquipmentSlots;

		public string StatsModelId => statsModelId;

		public string AppearanceID => appearanceID;

		public string WalkableModelFriendlyBlueprintId => walkableModelFriendlyBlueprintId;

		public string WalkableModelAggressiveBlueprintId => walkableModelAggressiveBlueprintId;

		public string ScheduleModelId => scheduleModelId;

		public string ScheduleConfigId => scheduleConfigId;

		public List<StringStringPair> SleepEffectors => sleepEffectors;

		public List<KeyIntPair> WakeUpEffectors => wakeUpEffectors;

		public List<string> KilledHumanEffectors => killedHumanEffectors;

		public List<RangeBasedEffector> HeightEffectors => heightEffectors;

		public List<RangeBasedEffector> WeightEffectors => weightEffectors;

		public List<RangeBasedEffector> AgeEffectors => ageEffectors;

		public List<AgeDeathCategory> OldAgeDeathRanges => oldAgeDeathRanges;

		public List<string> BreakdownEffectors => breakdownEffectors;

		public List<string> InspiredEffectors => inspiredEffectors;

		public List<string> BecomePrisonerEffectors => becomePrisonerEffectors;

		public string FaintEffector => faintEffector;

		public string RestEffector => restEffector;

		public List<string> BanishEffectors => banishEffectors;

		public List<string> DiedEffectors => diedEffectors;

		public string RaidWonEffector => raidWonEffector;

		public string RaidLostEffector => raidLostEffector;

		public string EatStandingUpEffector => eatStandingUpEffector;

		public string EatWithoutTableEffector => eatWithoutTableEffector;

		public string EatAtTableEffector => eatAtTableEffector;

		public string AfterVomitEffector => afterVomitEffector;

		public string EntertainmentEffector => entertainmentEffector;

		public string[] SpawnEffectors => spawnEffectors;

		public string WhileUntendedEffector => whileUntendedEffector;

		public List<string> PrayEffectors => prayEffectors;

		public List<string> SleepingOnGroundEffectors => sleepingOnGroundEffectors;

		public float BreakdownChance => breakdownChance;

		public float InspiredChance => inspiredChance;

		public List<TimedWounds> FireWounds => fireWounds;

		public override string GetID()
		{
			return id;
		}

		public string GetPrefab(BodyType bodyType)
		{
			return bodyType switch
			{
				BodyType.Male => PrefabMale, 
				BodyType.Female => PrefabFemale, 
				_ => null, 
			};
		}
	}
}
