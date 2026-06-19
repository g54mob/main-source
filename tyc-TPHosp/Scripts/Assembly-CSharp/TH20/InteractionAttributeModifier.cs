using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionAttributeModifier
	{
		public enum Type
		{
			[UsedImplicitly]
			Use = 0,
			[UsedImplicitly]
			Maintain = 1,
			[UsedImplicitly]
			Serve = 2,
			[UsedImplicitly]
			Special = 3,
			[UsedImplicitly]
			Upgrade = 4
		}

		[InspectorTooltip("Type of interaction")]
		public Type _interactionType;

		[InspectorTooltip("Name of interaction (optional)")]
		public string _interactionName;

		[InspectorTooltip("Object attributes to modify for this interaction type")]
		public ObjectAttributeModifier[] _objectModifiers;

		[InspectorTooltip("Character attributes to modify for this interaction type")]
		public CharacterAttributeModifier[] _characterModifiers;

		[InspectorTooltip("Finance modifier to apply for this interaction type")]
		public SharedInstance<FinanceModifier> _financeModifier;

		[InspectorTooltip("Character attributes to apply while the interaction is playing")]
		public CharacterAttributeModifier[] _characterModifiersWhileInteracting;

		[InspectorTooltip("Character status effects to apply for this interaction type")]
		public SharedInstance<CharacterStatusEffectDefinition>[] _characterStatusEffects;

		[InspectorTooltip("Character attributes that are chosen randomly for this interaction type")]
		public CharacterAttributeModifier[] _characterModifiersRandom;
	}
}
