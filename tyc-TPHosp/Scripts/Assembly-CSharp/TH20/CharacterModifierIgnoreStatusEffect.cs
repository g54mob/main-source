using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierIgnoreStatusEffect : CharacterModifier
	{
		public SharedInstance<CharacterStatusEffectDefinition> StatusEffect;
	}
}
