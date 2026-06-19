using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchPrerequisiteIllnessUnlocked : ResearchPrerequisite
	{
		[SerializeField]
		private SharedInstance<IllnessDefinition> _definition;

		public bool IsValid(Level level)
		{
			if (level.CharacterManager != null)
			{
				return level.CharacterManager.IsIllnessUnlocked(_definition.Instance);
			}
			return false;
		}

		public string Description()
		{
			return ScriptLocalization.Research.Prerequisite_IllnessUnlocked_CS.Replace("{[ILLNESS]}", _definition.Instance.Name.Translation);
		}
	}
}
