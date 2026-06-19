using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ChanceToApplyConditionToSelfWhenDamagedAuthoring : MonoBehaviour
{
	[Serializable]
	public class ConditionByChance
	{
		[InfoBox("After health has been deduced, at that percentage of current health, this value multiplied by percentage damage of max health is the chance", EInfoBoxType.Normal)]
		public AnimationCurve chanceForEachPercentDamageTakenByCurrentHealthPercentage;

		public ConditionData conditionData;
	}

	public List<ConditionByChance> conditionsByChance;
}
