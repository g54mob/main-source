using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class CharacterModifierMultiplierBase : CharacterModifier
	{
		[InspectorTooltip("Modifier e.g. +0.2 is +20% -0.5 is -50%")]
		public readonly float Modifier = 1f;
	}
}
