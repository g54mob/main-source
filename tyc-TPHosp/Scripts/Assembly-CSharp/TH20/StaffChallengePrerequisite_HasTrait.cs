using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_HasTrait : StaffChallengePrerequisite
	{
		[SerializeField]
		private SharedInstance<CharacterTraitDefinition> _trait;

		public bool IsValid(Level level, Staff staff)
		{
			return staff.Traits.HasTrait(_trait.Instance);
		}
	}
}
