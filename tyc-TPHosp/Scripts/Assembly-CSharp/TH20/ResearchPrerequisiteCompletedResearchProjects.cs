using System;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteCompletedResearchProjects : ResearchPrerequisite
	{
		[SerializeField]
		private int _total;

		public bool IsValid(Level level)
		{
			return level.Metagame.CompletedResearchProjects.Count >= _total;
		}

		public string Description()
		{
			string text = ScriptLocalization.Research.Prerequisite_CompletedResearchProjects_CS;
			LocalisationParams.Set("COUNT", _total);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
