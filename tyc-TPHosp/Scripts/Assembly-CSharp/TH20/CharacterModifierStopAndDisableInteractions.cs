using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierStopAndDisableInteractions : CharacterModifier
	{
		public override void Add(Character character)
		{
			if (character.Interaction != null && character.InteractionInterruptable)
			{
				character.Interaction.RequestExit();
			}
			character.DisallowInteractions = true;
		}

		public override void Remove(Character character)
		{
			character.DisallowInteractions = false;
		}
	}
}
