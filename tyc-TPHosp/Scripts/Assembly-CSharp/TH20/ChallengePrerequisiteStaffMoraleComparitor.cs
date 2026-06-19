using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteStaffMoraleComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _staffMoraleComparitor;

		public bool CheckConditions(Level level)
		{
			int num = (int)level.CharacterManager.StaffMorale * 100;
			if (!_lessThan)
			{
				return num > _staffMoraleComparitor;
			}
			return num < _staffMoraleComparitor;
		}
	}
}
