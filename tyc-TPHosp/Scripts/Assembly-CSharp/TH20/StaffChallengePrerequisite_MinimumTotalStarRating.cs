using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_MinimumTotalStarRating : StaffChallengePrerequisite
	{
		[SerializeField]
		private int _numStars;

		public bool IsValid(Level level, Staff staff)
		{
			return level.Metagame.TotalStars() >= _numStars;
		}
	}
}
