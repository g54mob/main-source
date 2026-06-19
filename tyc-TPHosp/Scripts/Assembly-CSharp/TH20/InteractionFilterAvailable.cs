using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionFilterAvailable : InteractionFilter
	{
		public override bool IsValid(ObjectInteraction interaction, Character character)
		{
			if (_enabled)
			{
				return interaction.IsAvailable(character);
			}
			return true;
		}
	}
}
