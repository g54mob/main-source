using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteAnachronisticCureRateComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _percent;

		public bool CheckConditions(Level level)
		{
			float anachronisticCureRate = level.LevelStatsDatabase.GetCumulativeLevelStats().AnachronisticCureRate;
			if (!_lessThan)
			{
				return anachronisticCureRate >= (float)_percent;
			}
			return anachronisticCureRate < (float)_percent;
		}
	}
}
