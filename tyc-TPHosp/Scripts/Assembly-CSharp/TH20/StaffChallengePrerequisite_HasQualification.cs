using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_HasQualification : StaffChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<QualificationDefinition> _definition;

		public virtual bool IsValid(Level level, Staff staff)
		{
			return _definition.Instance.HasQualification(staff.Qualifications);
		}
	}
}
