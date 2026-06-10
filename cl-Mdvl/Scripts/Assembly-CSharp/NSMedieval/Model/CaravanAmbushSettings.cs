using System;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;
using NSMedieval.Repository;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class CaravanAmbushSettings : NSEipix.Base.Model
	{
		private static CaravanAmbushSettings instance;

		[SerializeField]
		private InterpolatedValueList chanceBySettlersCount;

		[SerializeField]
		private InterpolatedValueList chanceByTripLength;

		[SerializeField]
		private InterpolatedValueList chanceByPrisonersCount;

		[SerializeField]
		private InterpolatedValueList chanceByWealthPerSettler;

		[SerializeField]
		private InterpolatedValueList chanceByArmedSettlersPercentage;

		[SerializeField]
		private FloatRange tripPositionPercentRange;

		[SerializeField]
		private IntRange waitTimeRangeMinutes;

		[SerializeField]
		private InterpolatedValueList valueDemandedBasedOnWealth;

		[SerializeField]
		private string negotiatorTraderTypeId;

		[SerializeField]
		private float escapeLoseCargoPercent;

		[SerializeField]
		private float defeatLoseCargoPercent;

		[SerializeField]
		private float tieLoseCargoPercent;

		[NonSerialized]
		private TraderType cachedTraderType;

		public static CaravanAmbushSettings I
		{
			get
			{
				if (instance == null)
				{
					instance = Repository<CaravanAmbushSettingsData, CaravanAmbushSettings>.Instance.GetData<CaravanAmbushSettings>();
				}
				return instance;
			}
		}

		public InterpolatedValueList ChanceByTripLength => chanceByTripLength;

		public InterpolatedValueList ChanceBySettlersCount => chanceBySettlersCount;

		public InterpolatedValueList ChanceByPrisonersCount => chanceByPrisonersCount;

		public InterpolatedValueList ChanceByWealthPerSettler => chanceByWealthPerSettler;

		public InterpolatedValueList ChanceByArmedSettlersPercentage => chanceByArmedSettlersPercentage;

		public FloatRange TripPositionPercentRange => tripPositionPercentRange;

		public IntRange WaitTimeRangeMinutes => waitTimeRangeMinutes;

		public InterpolatedValueList ValueDemandedBasedOnWealth => valueDemandedBasedOnWealth;

		public TraderType NegotiatorTraderType => cachedTraderType ?? (cachedTraderType = Repository<TraderTypeRepository, TraderType>.Instance.GetByID(negotiatorTraderTypeId));

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			instance = null;
		}

		public override string GetID()
		{
			return "CaravanAmbushSettings";
		}
	}
}
