using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DepartureMethodSubwayDefinition : DepartureMethodDefinition
	{
		public RuntimeAnimatorController CharacterAnimGraph;

		public override DepartureMethod Create(Character character, IDepartedCallback callback)
		{
			return new DepartureMethodSubway(this, character, callback);
		}

		public override bool IsAvailable()
		{
			return DepartureSubwayComponent.RandomSubway() != null;
		}
	}
}
