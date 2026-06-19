using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteProject : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<ResearchProjectDefinition> _definition;

		public bool IsValid(Level level)
		{
			return ((level.ResearchManager != null) ? level.ResearchManager.GetProject(_definition.Instance) : null)?.IsComplete() ?? false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_Project_CS.Replace("{[PROJECT]}", _definition.Instance.NameLocalised.Translation);
		}
	}
}
