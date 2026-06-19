using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_MinimumFreeQualificationSlots : StaffChallengePrerequisite
	{
		[SerializeField]
		private int _numFreeSlots = 1;

		public bool IsValid(Level level, Staff staff)
		{
			return staff.NumFreeQualificationSlots >= _numFreeSlots;
		}
	}
}
