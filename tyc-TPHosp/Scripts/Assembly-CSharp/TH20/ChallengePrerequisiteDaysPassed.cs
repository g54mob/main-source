using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengePrerequisiteDaysPassed : IChallengePrerequisite
	{
		[SerializeField]
		private int _numDays = 60;

		public bool CheckConditions(Level level)
		{
			return level.TimelineManager.TotalGameDaysPassed >= _numDays;
		}
	}
}
