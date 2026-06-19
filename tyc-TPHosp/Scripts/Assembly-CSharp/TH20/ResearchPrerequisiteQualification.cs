using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteQualification : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<QualificationDefinition> _definition;

		public bool IsValid(Level level)
		{
			if (level.JobApplicantManager != null)
			{
				return level.JobApplicantManager.Qualifications.Contains(_definition.Instance);
			}
			return false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_Qualification_CS.Replace("{[QUALIFICATION]}", _definition.Instance.NameLocalised.Translation);
		}
	}
}
