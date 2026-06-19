using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteStaffComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private StaffDefinition.Type _staff;

		[SerializeField]
		private int _numStaff;

		public bool CheckConditions(Level level)
		{
			int staffOfTypeCount = level.CharacterManager.GetStaffOfTypeCount(_staff);
			if (!_lessThan)
			{
				return staffOfTypeCount > _numStaff;
			}
			return staffOfTypeCount < _numStaff;
		}
	}
}
