using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionFilterExclusive : InteractionFilter
	{
		[SerializeField]
		private bool _checkReservation;

		public override bool IsValid(ObjectInteraction interaction, Character character)
		{
			if (!_enabled)
			{
				return true;
			}
			if (_checkReservation)
			{
				return !interaction.ParentRoomItem.HasAnyoneReservedInteraction(interaction.Name, character);
			}
			return !interaction.ParentRoomItem.IsAnyoneInteracting(character);
		}
	}
}
