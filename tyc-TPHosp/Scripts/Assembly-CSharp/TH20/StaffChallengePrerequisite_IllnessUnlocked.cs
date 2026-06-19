using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_IllnessUnlocked : StaffChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<IllnessDefinition> _definition;

		public bool IsValid(Level level, Staff staff)
		{
			CharacterManager characterManager = level.CharacterManager;
			if (characterManager.IsIllnessUnlocked(_definition.Instance) && characterManager.IsIllnessAvailable(_definition.Instance))
			{
				return true;
			}
			return false;
		}
	}
}
