using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionFilterFunctional : InteractionFilter
	{
		public override bool IsValid(ObjectInteraction interaction, Character character)
		{
			if (_enabled)
			{
				return interaction.ParentRoomItem.IsFunctional();
			}
			return true;
		}
	}
}
