using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_QualificationAvailable : StaffChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<QualificationDefinition> _definition;

		public bool IsValid(Level level, Staff staff)
		{
			return level.JobApplicantManager.Qualifications.Contains(_definition.Instance);
		}
	}
}
