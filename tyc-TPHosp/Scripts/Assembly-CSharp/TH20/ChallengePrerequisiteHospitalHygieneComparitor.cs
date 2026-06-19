using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteHospitalHygieneComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _hygiene;

		public bool CheckConditions(Level level)
		{
			double value = 0.0;
			if (!level.LevelStatsDatabase.QueryCurrentMonthStat(LevelStatsDatabase.Stat.HospitalHygiene, out value))
			{
				return false;
			}
			if (!_lessThan)
			{
				return value >= (double)_hygiene;
			}
			return value < (double)_hygiene;
		}
	}
}
