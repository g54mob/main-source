using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteIllnessDiagnosed : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<IllnessDefinition> _definition;

		public bool IsValid(Level level)
		{
			if (level.GameplayStatsTracker != null)
			{
				return level.GameplayStatsTracker.HasIllnessBeenDiagnosedBefore(_definition.Instance);
			}
			return false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_IllnessDiagnosed_CS.Replace("{[ILLNESS]}", _definition.Instance.Name.Translation);
		}
	}
}
