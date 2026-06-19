using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_StaffType : StaffChallengePrerequisite
	{
		[SerializeField]
		private StaffDefinition.Type _staffType;

		public bool IsValid(Level level, Staff staff)
		{
			return staff.Definition._type == _staffType;
		}
	}
}
