using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSMedieval.OcclusionCulling;
using NSMedieval.StatsSystem;
using NSMedieval.Tools.Math;
using NSMedieval.Types;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class PlantMapResource : MapResource
	{
		[SerializeField]
		private List<ResourceOrderPair> storableResources;

		[SerializeField]
		private int minBotanicalSkill;

		[SerializeField]
		private int harvestPhase;

		[SerializeField]
		private int cutPhase;

		[SerializeField]
		private float harvestDuration;

		[SerializeField]
		private int lifeCyclesCount;

		[SerializeField]
		private int cycleStarterIndex;

		[SerializeField]
		private float phaseSkipTemperature;

		[SerializeField]
		private float newPlantTemperatureLimit;

		[SerializeField]
		private float newPlantsPerDay;

		[SerializeField]
		private bool destroyOnHarvest;

		[SerializeField]
		private List<PlantLifePhases> lifePhases = new List<PlantLifePhases>();

		[SerializeField]
		private bool cultivable;

		[SerializeField]
		private float sowTime;

		[SerializeField]
		private List<string> growsOn = new List<string>();

		[SerializeField]
		private int neighborCheck;

		[SerializeField]
		private float attackTraversePenalty;

		[SerializeField]
		private PlantType plantType;

		[SerializeField]
		private List<string> almanacTags;

		[SerializeField]
		private bool yieldByDifficulty;

		[SerializeField]
		private float healthRecoverySpeed = 0.1f;

		[SerializeField]
		private FloatRange freezeDyingSpeed = new FloatRange(0.5f, 1f);

		[SerializeField]
		private FloatRange noLightDyingSpeed = new FloatRange(0.1f, 0.4f);

		[SerializeField]
		private FloatRange overheatDyingSpeed = new FloatRange(0.2f, 0.6f);

		[SerializeField]
		private float placeAnywhereChance = 0.3f;

		[SerializeField]
		private int maxCount;

		[SerializeField]
		private bool canSpawnOnZeroCount = true;

		[SerializeField]
		private bool canHaveBlight;

		[SerializeField]
		private float nutritionPerHp = 2f;

		[SerializeField]
		private float temperatureOverheat = 35f;

		[SerializeField]
		private float stuntedYieldMultiplier = 0.5f;

		[SerializeField]
		private string[] onEatEffectors;

		[SerializeField]
		private PlantAppearance stuntedAppearance;

		[SerializeField]
		private bool useSunlight = true;

		[SerializeField]
		private float noLightGrowSpeed = 0.2f;

		[SerializeField]
		private float stuntedSunlightThreshold = 0.5f;

		[SerializeField]
		private bool stuntedIfBlockedByAbove;

		[SerializeField]
		private bool stuntedIfBlockedBySides;

		[SerializeField]
		private SoundWalkableMaterialCategory soundWalkableMaterialCategory;

		[SerializeField]
		private bool idleTargetForbidden;

		[SerializeField]
		private WaterDepthLevel waterDepthLevel;

		[SerializeField]
		private float[] loseHpOnWaterDepthLevel;

		[SerializeField]
		private float flammability = -1f;

		[SerializeField]
		private string spawnPileWhenDestroyedByFire;

		[SerializeField]
		private int spawnPileAmountWhenDestroyedByFire;

		[SerializeField]
		private bool uniqueResource;

		[SerializeField]
		private int[] uniqueResourceActiveLifePhases;

		[SerializeField]
		private OcclusionCullingMode occlusionCullingMode;

		[NonSerialized]
		private bool[] loseHpWaterLevelReason;

		[NonSerialized]
		private bool loseHpWaterLevelReasonCached;

		[NonSerialized]
		private bool cutPhaseCacheInitialized;

		[NonSerialized]
		private PlantLifePhases cutPhaseCache;

		private HarvestParametars harvestParametars;

		private SowingParameters sowingParameters;

		private bool harvestableSet;

		private bool cutSet;

		public float AttackTraversePenalty => attackTraversePenalty;

		public List<ResourceOrderPair> StorableResources => storableResources;

		public int MinBotanicalSkill => minBotanicalSkill;

		public int HarvestPhase => harvestPhase;

		public int CutPhase => cutPhase;

		public int LifeCyclesCount => lifeCyclesCount;

		public int CycleStarterIndex => cycleStarterIndex;

		public float PhaseSkipTemperature => phaseSkipTemperature;

		public float NewPlantTemperatureLimit => newPlantTemperatureLimit;

		public float NewPlantsPerDay => newPlantsPerDay;

		public bool DestroyOnHarvest => destroyOnHarvest;

		public List<PlantLifePhases> LifePhases => lifePhases;

		public bool CanHaveBlight => canHaveBlight;

		public bool Cultivable => cultivable;

		public float SowTime => sowTime;

		public List<string> GrowsOn => growsOn;

		public int NeighborCheck => neighborCheck;

		public PlantType PlantType => plantType;

		public List<string> AlmanacTags => almanacTags;

		public bool YieldByDifficulty => yieldByDifficulty;

		public float HealthRecoverySpeed => healthRecoverySpeed;

		public float TemperatureOverheat => temperatureOverheat;

		public float StuntedYieldMultiplier => stuntedYieldMultiplier;

		public WaterDepthLevel WaterDepthLevel => waterDepthLevel;

		public OcclusionCullingMode OcclusionCullingMode => occlusionCullingMode;

		public FloatRange FreezeDyingSpeed
		{
			get
			{
				if (freezeDyingSpeed == null)
				{
					freezeDyingSpeed = new FloatRange(0.5f, 1f);
				}
				return freezeDyingSpeed;
			}
		}

		public FloatRange NoLightDyingSpeed
		{
			get
			{
				if (noLightDyingSpeed == null)
				{
					noLightDyingSpeed = new FloatRange(0.1f, 0.4f);
				}
				return noLightDyingSpeed;
			}
		}

		public FloatRange OverheatDyingSpeed
		{
			get
			{
				if (overheatDyingSpeed == null)
				{
					overheatDyingSpeed = new FloatRange(0.1f, 0.4f);
				}
				return overheatDyingSpeed;
			}
		}

		private bool[] LoseHpWaterLevelReason
		{
			get
			{
				if (!loseHpWaterLevelReasonCached)
				{
					loseHpWaterLevelReasonCached = true;
					CacheLoseHpWaterLevelReason();
				}
				return loseHpWaterLevelReason;
			}
		}

		public float PlaceAnywhereChance => placeAnywhereChance;

		public int MaxCount => maxCount;

		public bool CanSpawnOnZeroCount => canSpawnOnZeroCount;

		public float NutritionPerHp => nutritionPerHp;

		public string[] OnEatEffectors => onEatEffectors;

		public PlantAppearance StuntedAppearance => stuntedAppearance;

		public bool UseSunlight => useSunlight;

		public float NoLightGrowSpeed => noLightGrowSpeed;

		public double StuntedSunlightThreshold => stuntedSunlightThreshold;

		public bool StuntedIfBlockedByAbove => stuntedIfBlockedByAbove;

		public bool StuntedIfBlockedBySides => stuntedIfBlockedBySides;

		public SoundWalkableMaterialCategory WalkableMaterialCategory => soundWalkableMaterialCategory;

		public bool IdleTargetForbidden => idleTargetForbidden;

		public float Flammability => flammability;

		public string SpawnPileWhenDestroyedByFire => spawnPileWhenDestroyedByFire;

		public int SpawnPileAmountWhenDestroyedByFire => spawnPileAmountWhenDestroyedByFire;

		public bool UniqueResource => uniqueResource;

		public int[] UniqueResourceActiveLifePhases => uniqueResourceActiveLifePhases;

		public PlantLifePhases GetCutPhase()
		{
			if (!cutPhaseCacheInitialized)
			{
				cutPhaseCache = ((cutPhase < 0) ? null : lifePhases[cutPhase % lifePhases.Count]);
				cutPhaseCacheInitialized = true;
			}
			return cutPhaseCache;
		}

		private void CacheLoseHpWaterLevelReason()
		{
			if (loseHpOnWaterDepthLevel == null)
			{
				return;
			}
			loseHpWaterLevelReason = new bool[loseHpOnWaterDepthLevel.Length];
			for (int i = 0; i < loseHpOnWaterDepthLevel.Length; i++)
			{
				if (loseHpOnWaterDepthLevel[i] > 0f)
				{
					for (int num = i - 1; num >= 0; num--)
					{
						if (loseHpOnWaterDepthLevel[num] <= 0f)
						{
							loseHpWaterLevelReason[i] = true;
							break;
						}
					}
				}
				if (i >= loseHpOnWaterDepthLevel.Length - 1)
				{
					continue;
				}
				for (int j = i + 1; j < loseHpOnWaterDepthLevel.Length; j++)
				{
					if (loseHpOnWaterDepthLevel[j] > 0f)
					{
						loseHpWaterLevelReason[i] = false;
						break;
					}
				}
			}
		}

		public bool GetIsLosingHpFlooded(WaterDepthLevel waterLevel)
		{
			int num = (int)(Mathf.Log((float)waterLevel) / Mathf.Log(2f));
			return LoseHpWaterLevelReason[num];
		}

		public override HarvestParametars GetMiningParameters()
		{
			if (base.MiningParameters == null)
			{
				base.MiningParameters = new HarvestParametars(base.MiningDuration, AttributeType.CutSpeed, AttributeType.CutAmount, AttributeType.CutFail, SkillType.Botanical, 50f, base.MiningTool);
			}
			return base.MiningParameters;
		}

		public HarvestParametars GetHarvestParameters()
		{
			if (harvestParametars == null)
			{
				harvestParametars = new HarvestParametars(harvestDuration, AttributeType.HarvestSpeed, AttributeType.HarvestAmount, AttributeType.HarvestFail, SkillType.Botanical, 50f, string.Empty);
			}
			return harvestParametars;
		}

		public SowingParameters GetSowingParameters()
		{
			if (sowingParameters == null)
			{
				sowingParameters = new SowingParameters(sowTime, AttributeType.SowSpeed, SkillType.Botanical, 30f, string.Empty);
			}
			return sowingParameters;
		}

		public void SetHarvestablePhases()
		{
			if (harvestableSet)
			{
				return;
			}
			for (int i = 0; i < storableResources.Count; i++)
			{
				foreach (PlantLifePhases lifePhase in lifePhases)
				{
					if ((lifePhase.ResourcesRange[i].Min > 0 || lifePhase.ResourcesRange[i].Max > 0) && storableResources[i].Orders.HasFlag(OrderType.Harvesting))
					{
						lifePhase.SetHarvestablePhase();
					}
				}
			}
			harvestableSet = true;
		}

		public void SetCutPhases()
		{
			if (cutSet)
			{
				return;
			}
			for (int i = 0; i < storableResources.Count; i++)
			{
				foreach (PlantLifePhases lifePhase in lifePhases)
				{
					if ((lifePhase.ResourcesRange[i].Min > 0 || lifePhase.ResourcesRange[i].Max > 0) && storableResources[i].Orders.HasFlag(OrderType.Chopping))
					{
						lifePhase.SetCutPhase();
					}
				}
			}
			cutSet = true;
		}

		public float GetHpLossOnWaterLevel(int waterLevel)
		{
			if (loseHpOnWaterDepthLevel == null)
			{
				return 0f;
			}
			float num = 0f;
			if (loseHpOnWaterDepthLevel.Length >= 1 && (waterLevel & 1) != 0)
			{
				num = loseHpOnWaterDepthLevel[0];
			}
			if (loseHpOnWaterDepthLevel.Length >= 2 && (waterLevel & 2) != 0)
			{
				num = MathfUtils.Max(num, loseHpOnWaterDepthLevel[1]);
			}
			if (loseHpOnWaterDepthLevel.Length >= 3 && (waterLevel & 4) != 0)
			{
				num = MathfUtils.Max(num, loseHpOnWaterDepthLevel[2]);
			}
			if (loseHpOnWaterDepthLevel.Length >= 4 && (waterLevel & 8) != 0)
			{
				num = MathfUtils.Max(num, loseHpOnWaterDepthLevel[3]);
			}
			return num;
		}
	}
}
