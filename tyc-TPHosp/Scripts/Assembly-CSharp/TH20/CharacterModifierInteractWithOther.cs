using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierInteractWithOther : CharacterModifier
	{
		public readonly CharacterAttributes.Type Type;

		public readonly float Amount;

		public readonly SharedInstance<CharacterStatusEffectDefinition> StatusEffect;
	}
}
