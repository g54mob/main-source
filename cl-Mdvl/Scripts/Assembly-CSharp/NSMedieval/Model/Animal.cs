using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Models;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Animal : NSEipix.Base.Model, IEnemyPurchaseUnit
	{
		[Serializable]
		private class ModelBlueprintsByAnimalType
		{
			[SerializeField]
			private string wild;

			[SerializeField]
			private string wildAggressive;

			[SerializeField]
			private string domestic;

			[SerializeField]
			private string domesticNpc;

			[SerializeField]
			private string pet;

			private ScheduleConfig[] scheduleConfigs;

			private ScheduleModel[] scheduleModels;

			private WalkableModel[] walkSpeedMultipliers;

			internal WalkableModel GetWalkableModelBlueprint(AnimalType animalType)
			{
				if (walkSpeedMultipliers == null)
				{
					walkSpeedMultipliers = GetModelsPerAnimalType(Repository<WalkableModelRepository, WalkableModel>.Instance);
				}
				return walkSpeedMultipliers[(int)animalType];
			}

			internal ScheduleModel GetScheduleModel(AnimalType animalType)
			{
				if (scheduleModels == null)
				{
					scheduleModels = GetModelsPerAnimalType(Repository<ScheduleModelRepository, ScheduleModel>.Instance);
				}
				return scheduleModels[(int)animalType];
			}

			internal ScheduleConfig GetScheduleConfig(AnimalType animalType)
			{
				if (scheduleConfigs == null)
				{
					scheduleConfigs = GetModelsPerAnimalType(Repository<ScheduleConfigRepository, ScheduleConfig>.Instance);
				}
				return scheduleConfigs[(int)animalType];
			}

			private M[] GetModelsPerAnimalType<T, M>(Repository<T, M> repository) where T : Repository<T, M> where M : NSEipix.Base.Model
			{
				return new List<M>
				{
					repository.GetByID(domestic),
					repository.GetByID(domesticNpc),
					repository.GetByID(pet),
					repository.GetByID(wild),
					repository.GetByID(wildAggressive)
				}.ToArray();
			}

			public string GetId(AnimalType animalType)
			{
				return animalType switch
				{
					AnimalType.Domestic => domestic, 
					AnimalType.DomesticNpc => domesticNpc, 
					AnimalType.Pet => pet, 
					AnimalType.Wild => wild, 
					AnimalType.WildAggressive => wildAggressive, 
					_ => string.Empty, 
				};
			}
		}

		[SerializeField]
		private string id;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private ModelBlueprintsByAnimalType walkableModelBlueprints;

		[SerializeField]
		private ModelBlueprintsByAnimalType scheduleModelBlueprints;

		[SerializeField]
		private ModelBlueprintsByAnimalType scheduleConfigBlueprints;

		[SerializeField]
		private ModelBlueprintsByAnimalType combatAiBlueprints;

		[SerializeField]
		private ModelBlueprintsByAnimalType effectorsByAnimalType;

		[SerializeField]
		private List<AnimalLifePhase> lifePhases;

		[SerializeField]
		private string prefabMale = string.Empty;

		[SerializeField]
		private string prefabFemale = string.Empty;

		[SerializeField]
		private string attackIcon = string.Empty;

		[SerializeField]
		private bool canBeTamed;

		[SerializeField]
		private bool canBeTrained;

		[SerializeField]
		private bool canHaulAsPet;

		[SerializeField]
		private bool canAttackAsPet;

		[SerializeField]
		private bool canPestControlAsPet;

		[SerializeField]
		private bool canBeInPen;

		[SerializeField]
		private HitEffector[] onHitEffectors;

		[SerializeField]
		private HitEffector[] onCriticalHitEffectors;

		[SerializeField]
		private List<string> almanacTags;

		[SerializeField]
		private string unlockAchievementOnDeath;

		[SerializeField]
		private string increaseAchievementCountOnDeath;

		[SerializeField]
		private string unlockAchievementOnTame;

		[SerializeField]
		private string increaseAchievementCountOnTame;

		[SerializeField]
		private string category;

		[SerializeField]
		private string goapAgent;

		[SerializeField]
		private string statsModelId;

		[SerializeField]
		private string dietModelId;

		[SerializeField]
		private float pregnancyDuration;

		[SerializeField]
		private IntRange offspringRange;

		[SerializeField]
		private float chanceForPregnancy;

		[SerializeField]
		private string stopPregnancyEffector;

		[SerializeField]
		private int maxCount;

		[SerializeField]
		private int minGridSpace;

		[SerializeField]
		private int price;

		[SerializeField]
		private float wealthPoints = 2f;

		[SerializeField]
		private float priceThreshold = 1f;

		[SerializeField]
		private float tamingDuration;

		[SerializeField]
		private int minTameSkill;

		[SerializeField]
		private int slaughterXp;

		[SerializeField]
		private int tameTrySuccessfulXp;

		[SerializeField]
		private int tameTryFailXp;

		[SerializeField]
		private float trainingDuration;

		[SerializeField]
		private int minTrainSkill;

		[SerializeField]
		private string trainingAnimation;

		[SerializeField]
		private int trainTrySuccessfulXp;

		[SerializeField]
		private int trainTryFailXp;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string[] hitEffectorGroupIDs;

		[SerializeField]
		private string[] criticalHitEffectorGroupIDs;

		[SerializeField]
		private string haulEndEffectorName = "PetDisableHaulGoal";

		[SerializeField]
		private float fireHaulEndEffectorChance = 0.8f;

		[SerializeField]
		private FloatRange haulEndEffectorDuration = new FloatRange(0.3f, 3f);

		[SerializeField]
		private string forcedFleeWalkableModel;

		[SerializeField]
		private string scaredEffector = "AnimalScaredDontSleep";

		[SerializeField]
		private string animalHitTameEffectorName = "AnimalHitTame";

		[SerializeField]
		private string animalAnimalHitTrainEffectorName = "AnimalHitTrain";

		[SerializeField]
		private FloatRange scaredEffectorDuration = new FloatRange(0.7f, 3f);

		[SerializeField]
		private string pestControlEndEffectorName;

		[SerializeField]
		private FloatRange pestControlEndEffectorDuration = new FloatRange(0.7f, 3f);

		[SerializeField]
		private float firePestControlEndEffectorChance;

		[SerializeField]
		private float maxWeight;

		[SerializeField]
		private string footstepsAudioEvent;

		[SerializeField]
		private AnimalAttackType animalAttackType;

		[SerializeField]
		private string thermalModelId;

		[SerializeField]
		private bool canMakeDirtPath;

		[SerializeField]
		private bool isPetProtectiveAgainstPredators;

		[SerializeField]
		private List<TimedWounds> fireWounds;

		[SerializeField]
		private float flameSpawnInterval;

		[SerializeField]
		private int ritualSacrificeQuality;

		[SerializeField]
		private float buildablePassThroughDestroyChance;

		[SerializeField]
		private float fleeAfterAttackChanceWildAggro;

		[NonSerialized]
		private DietModel dietModelCache;

		[NonSerialized]
		private StatsModel statsModelCache;

		[NonSerialized]
		private ThermalModel thermalModelCache;

		[NonSerialized]
		private bool thermalModelInit;

		public List<TimedWounds> FireWounds => fireWounds;

		public string PrefabMale => prefabMale;

		public string PrefabFemale => prefabFemale;

		public string AttackIcon => attackIcon = (string.IsNullOrEmpty(attackIcon) ? "wolf_attack" : attackIcon);

		public string UnlockAchievementOnDeath => unlockAchievementOnDeath;

		public string IncreaseAchievementCountOnDeath => increaseAchievementCountOnDeath;

		public string UnlockAchievementOnTame => unlockAchievementOnTame;

		public string IncreaseAchievementCountOnTame => increaseAchievementCountOnTame;

		public float FleeAfterAttackChanceWildAggro => fleeAfterAttackChanceWildAggro;

		public float BaseHealth
		{
			get
			{
				if (StatsModel != null && StatsModel.GetByType(StatType.Health) != null)
				{
					return StatsModel.GetByType(StatType.Health).InitialValue;
				}
				return 0f;
			}
		}

		public bool CanBeTamed => canBeTamed;

		public bool CanBeTrained => canBeTrained;

		public bool CanHaulAsPet => canHaulAsPet;

		public bool CanAttackAsPet => canAttackAsPet;

		public bool CanPestControlAsPet => canPestControlAsPet;

		public bool CanBeInPen => canBeInPen;

		public HitEffector[] OnHitEffectors
		{
			get
			{
				if (onHitEffectors == null && hitEffectorGroupIDs != null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = hitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onHitEffectors = list.ToArray();
				}
				return onHitEffectors;
			}
		}

		public HitEffector[] OnCriticalHitEffectors
		{
			get
			{
				if (onCriticalHitEffectors == null && criticalHitEffectorGroupIDs != null)
				{
					List<HitEffector> list = new List<HitEffector>();
					string[] array = criticalHitEffectorGroupIDs;
					foreach (string text in array)
					{
						list.AddRange(Repository<HitEffectorGroupRepository, HitEffectorGroup>.Instance.GetByID(text).HitEffectors);
					}
					onCriticalHitEffectors = list.ToArray();
				}
				return onCriticalHitEffectors;
			}
		}

		public List<string> AlmanacTags => almanacTags;

		public string Category => category;

		public string GoapAgent => goapAgent;

		public List<AnimalLifePhase> LifePhases => lifePhases;

		public float TamingDuration => tamingDuration;

		public int MinTameSkill => minTameSkill;

		public string TrainingAnimation => trainingAnimation;

		public int SlaughterXp => slaughterXp;

		public int TameTrySuccessfulXp => tameTrySuccessfulXp;

		public int TameTryFailXp => tameTryFailXp;

		public float TrainingDuration => trainingDuration;

		public int TrainTrySuccessfulXp => trainTrySuccessfulXp;

		public int TrainTryFailXp => trainTryFailXp;

		public int MinTrainSkill => minTrainSkill;

		public StatsModel StatsModel
		{
			get
			{
				if (statsModelCache == null && !string.IsNullOrEmpty(statsModelId))
				{
					statsModelCache = Repository<StatsModelRepository, StatsModel>.Instance.GetByID(statsModelId);
				}
				return statsModelCache;
			}
		}

		public DietModel DietModel
		{
			get
			{
				if (dietModelCache == null)
				{
					dietModelCache = Repository<DietModelRepository, DietModel>.Instance.GetByID(dietModelId);
				}
				return dietModelCache;
			}
		}

		public ThermalModel ThermalModel
		{
			get
			{
				if (!thermalModelInit)
				{
					thermalModelInit = true;
					thermalModelCache = (string.IsNullOrEmpty(thermalModelId) ? null : Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModelId));
				}
				return thermalModelCache;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public float PregnancyDuration => pregnancyDuration;

		public IntRange OffspringRange => offspringRange;

		public float ChanceForPregnancy => chanceForPregnancy;

		public string StopPregnancyEffector => stopPregnancyEffector;

		public int MaxCount => (int)((float)maxCount * MonoSingleton<AnimalSpawner>.Instance.MapSizeMultiplier);

		public int MinGridSpace => minGridSpace;

		public string HaulEndEffectorName => haulEndEffectorName;

		public string AnimalHitTameEffectorName => animalHitTameEffectorName;

		public string AnimalAnimalHitTrainEffectorName => animalAnimalHitTrainEffectorName;

		public float FireHaulEndEffectorChance => fireHaulEndEffectorChance;

		public FloatRange HaulEndEffectorDuration => haulEndEffectorDuration;

		public string ScaredEffector => scaredEffector;

		public FloatRange ScaredEffectorDuration => scaredEffectorDuration;

		public string IconPath => iconPath;

		public float WealthPoints => wealthPoints;

		public string PestControlEndEffectorName => pestControlEndEffectorName;

		public FloatRange PestControlEndEffectorDuration => pestControlEndEffectorDuration;

		public double FirePestControlEndEffectorChance => fireHaulEndEffectorChance;

		public float MaxWeight => maxWeight;

		public string FootstepsAudioEvent => footstepsAudioEvent;

		public AnimalAttackType AnimalAttackType => animalAttackType;

		public bool CanMakeDirtPath => canMakeDirtPath;

		public bool IsPetProtectiveAgainstPredators => isPetProtectiveAgainstPredators;

		public float FlameSpawnInterval => flameSpawnInterval;

		public int RitualSacrificeQuality => ritualSacrificeQuality;

		public float BuildablePassThroughDestroyChance => buildablePassThroughDestroyChance;

		public string ForcedFleeWalkableModel => forcedFleeWalkableModel;

		public bool IsTrader()
		{
			return false;
		}

		public int GetPrice()
		{
			return price;
		}

		public float GetPriceThreshold()
		{
			return priceThreshold;
		}

		public override string GetID()
		{
			return id;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public WalkableModel GetWalkableModel(AnimalType animalType)
		{
			return walkableModelBlueprints?.GetWalkableModelBlueprint(animalType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ScheduleModel GetScheduleModel(AnimalType animalType)
		{
			return scheduleModelBlueprints?.GetScheduleModel(animalType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ScheduleConfig GetScheduleConfig(AnimalType animalType)
		{
			return scheduleConfigBlueprints?.GetScheduleConfig(animalType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string GetCombatAiBlueprintId(AnimalType animalType)
		{
			return combatAiBlueprints.GetId(animalType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string GetEffectorForAnimalType(AnimalType animalType)
		{
			return effectorsByAnimalType.GetId(animalType);
		}
	}
}
