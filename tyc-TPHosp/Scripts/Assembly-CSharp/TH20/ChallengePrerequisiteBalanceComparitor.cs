using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteBalanceComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _dollars;

		public bool CheckConditions(Level level)
		{
			int balance = level.FinanceManager.Balance;
			if (!_lessThan)
			{
				return balance > _dollars;
			}
			return balance < _dollars;
		}
	}
}
