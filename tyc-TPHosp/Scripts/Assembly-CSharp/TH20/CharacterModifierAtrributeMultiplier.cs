using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierAtrributeMultiplier : CharacterModifierMultiplierBase
	{
		public readonly CharacterAttributes.Type Type;
	}
}
