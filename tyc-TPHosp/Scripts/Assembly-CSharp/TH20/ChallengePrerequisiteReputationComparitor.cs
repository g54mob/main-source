using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteReputationComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _reputationComparitor;

		public bool CheckConditions(Level level)
		{
			int num = (int)level.ReputationTracker.OverallReputation * 100;
			if (!_lessThan)
			{
				return num > _reputationComparitor;
			}
			return num < _reputationComparitor;
		}
	}
}
