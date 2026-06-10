using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class PlantLifePhases
	{
		[SerializeField]
		private string phaseName;

		[SerializeField]
		private PlantLifePhaseType phaseType;

		[SerializeField]
		private PlantAppearance appearance;

		[SerializeField]
		private float durationDays;

		[SerializeField]
		private float baseHealth;

		[SerializeField]
		private List<IntRange> resourcesRange;

		[SerializeField]
		private float temperatureFreeze;

		[SerializeField]
		private float temperatureDeath;

		[SerializeField]
		private int nextPhaseIndex;

		[SerializeField]
		private int deathPhaseIndex;

		[SerializeField]
		private int deathPhaseIndexFire;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float beautyInput;

		[SerializeField]
		private string thermalModelID = string.Empty;

		[SerializeField]
		private string tempShadowCaster = string.Empty;

		[SerializeField]
		private string tempShadowCasterWinter = string.Empty;

		[SerializeField]
		private string tempShadowCasterStunted = string.Empty;

		[SerializeField]
		private string tempShadowCasterWinterStunted = string.Empty;

		[SerializeField]
		private bool turningPhase;

		[SerializeField]
		private float flammability = 1f;

		[SerializeField]
		private bool disableCanopyCollider;

		[SerializeField]
		private bool isTastyForBees = true;

		[SerializeField]
		private bool useSunLight = true;

		private bool isThermalModelInitialized;

		private ThermalModel thermalModelCache;

		private bool isHarvestablePhase;

		private bool isCutPhase;

		private PlantShape tempShadowCasterCache;

		private bool tempShadowCasterCacheInit;

		private PlantShape tempShadowCasterWinterCache;

		private bool tempShadowCasterWinterCacheInit;

		private PlantShape tempShadowCasterStuntedCache;

		private bool tempShadowCasterStuntedCacheInit;

		private PlantShape tempShadowCasterWinterStuntedCache;

		private bool tempShadowCasterWinterStuntedCacheInit;

		public string PhaseName => phaseName;

		public PlantLifePhaseType PhaseType => phaseType;

		public PlantAppearance Appearance => appearance;

		public float DurationDays => durationDays;

		public float BaseHealth => baseHealth;

		public List<IntRange> ResourcesRange => resourcesRange;

		public float TemperatureFreeze => temperatureFreeze;

		public float TemperatureDeath => temperatureDeath;

		public int NextPhaseIndex => nextPhaseIndex;

		public int DeathPhaseIndex => deathPhaseIndex;

		public int DeathPhaseIndexFire => deathPhaseIndexFire;

		public bool IsHarvestablePhase => isHarvestablePhase;

		public bool IsCutPhase => isCutPhase;

		public LocKeys[] LocKeys => locKeys;

		public float BeautyInput => beautyInput;

		public bool TurningPhase => turningPhase;

		public bool UseSunLight => useSunLight;

		public PlantShape TempShadowCaster
		{
			get
			{
				if (!tempShadowCasterCacheInit)
				{
					tempShadowCasterCacheInit = true;
					tempShadowCasterCache = (string.IsNullOrEmpty(tempShadowCaster) ? null : Repository<PlantShapeRepository, PlantShape>.Instance.GetByID(tempShadowCaster));
				}
				return tempShadowCasterCache;
			}
		}

		public PlantShape TempShadowCasterWinter
		{
			get
			{
				if (!tempShadowCasterWinterCacheInit)
				{
					tempShadowCasterWinterCacheInit = true;
					tempShadowCasterWinterCache = Repository<PlantShapeRepository, PlantShape>.Instance.GetByID(tempShadowCasterWinter);
				}
				return tempShadowCasterWinterCache;
			}
		}

		public PlantShape TempShadowCasterStunted
		{
			get
			{
				if (!tempShadowCasterStuntedCacheInit)
				{
					tempShadowCasterStuntedCacheInit = true;
					tempShadowCasterStuntedCache = Repository<PlantShapeRepository, PlantShape>.Instance.GetByID(tempShadowCasterStunted);
				}
				return tempShadowCasterStuntedCache;
			}
		}

		public PlantShape TempShadowCasterWinterStunted
		{
			get
			{
				if (!tempShadowCasterWinterStuntedCacheInit)
				{
					tempShadowCasterWinterStuntedCacheInit = true;
					tempShadowCasterWinterStuntedCache = Repository<PlantShapeRepository, PlantShape>.Instance.GetByID(tempShadowCasterWinterStunted);
				}
				return tempShadowCasterWinterStuntedCache;
			}
		}

		public ThermalModel ThermalModel
		{
			get
			{
				if (!isThermalModelInitialized)
				{
					isThermalModelInitialized = true;
					if (!string.IsNullOrEmpty(thermalModelID))
					{
						thermalModelCache = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModelID);
					}
				}
				return thermalModelCache;
			}
		}

		public float Flammability => flammability;

		public bool IsTastyForBees => isTastyForBees;

		public bool DisableCanopyCollider => disableCanopyCollider;

		public float DurationHours()
		{
			return durationDays * (float)GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
		}

		public void SetHarvestablePhase()
		{
			isHarvestablePhase = true;
		}

		public void SetCutPhase()
		{
			isCutPhase = true;
		}

		public override string ToString()
		{
			return phaseName;
		}
	}
}
