using System;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_NotHaveQualification : StaffChallengePrerequisite_HasQualification
	{
		public override bool IsValid(Level level, Staff staff)
		{
			return !base.IsValid(level, staff);
		}
	}
}
