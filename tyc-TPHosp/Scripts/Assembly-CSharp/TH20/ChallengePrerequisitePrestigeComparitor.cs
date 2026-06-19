using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisitePrestigeComparitor : IChallengePrerequisite
	{
		[SerializeField]
		private bool _lessThan;

		[SerializeField]
		private int _prestigeLevel;

		public bool CheckConditions(Level level)
		{
			int level2 = level.PrestigeTracker.Level;
			if (!_lessThan)
			{
				return level2 >= _prestigeLevel;
			}
			return level2 < _prestigeLevel;
		}
	}
}
