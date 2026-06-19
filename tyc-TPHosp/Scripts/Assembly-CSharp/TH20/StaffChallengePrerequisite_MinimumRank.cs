using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_MinimumRank : StaffChallengePrerequisite
	{
		[SerializeField]
		private int _rank;

		public bool IsValid(Level level, Staff staff)
		{
			return staff.Rank >= _rank;
		}
	}
}
