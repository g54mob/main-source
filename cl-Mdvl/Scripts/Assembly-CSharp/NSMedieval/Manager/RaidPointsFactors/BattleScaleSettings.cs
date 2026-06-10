using System;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.GameEventSystem;
using UnityEngine;

namespace NSMedieval.Manager.RaidPointsFactors
{
	[Serializable]
	public class BattleScaleSettings : SingletonModel<BattleScaleSettings, BattleScalesSettingsData>
	{
		[SerializeField]
		private float buildingWealthPointsMultiplier;

		[SerializeField]
		private float buildingLostAdditionalMultiplier;

		[SerializeField]
		private FloatRange neutralOutcomePointsRange;

		[SerializeField]
		private InterpolatedValueList unitsDeadEndConditionPercents;

		[SerializeField]
		private int noDamageTimerGracePeriodMinutes;

		[SerializeField]
		private int noDamageTimerMinutes;

		public float BuildingWealthPointsMultiplier => buildingWealthPointsMultiplier;

		public float BuildingLostAdditionalMultiplier => buildingLostAdditionalMultiplier;

		public FloatRange NeutralOutcomePointsRange => neutralOutcomePointsRange;

		public int NoDamageTimerGracePeriodMinutes => noDamageTimerGracePeriodMinutes;

		public int NoDamageTimerMinutes => noDamageTimerMinutes;

		public override string GetID()
		{
			return "BattleScaleSettings";
		}

		public float GetUnitsDeadEndConditionPercent(int totalUnitsCount)
		{
			if (unitsDeadEndConditionPercents == null || unitsDeadEndConditionPercents.IsEmpty())
			{
				if (totalUnitsCount < 5)
				{
					return 0.5f;
				}
				return 0.8f;
			}
			return unitsDeadEndConditionPercents.GetMultiplierInterpolated(totalUnitsCount);
		}
	}
}
