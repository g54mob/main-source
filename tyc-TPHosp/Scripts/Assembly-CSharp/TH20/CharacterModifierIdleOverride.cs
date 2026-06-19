using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierIdleOverride : CharacterModifier
	{
		public int Priority;

		public IdleAnimation Animation;
	}
}
