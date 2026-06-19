namespace Player.FSM
{
	public interface IPlayerStateMachineParametersManipulator
	{
		bool IsPlacing { get; }

		void SetPushing(bool pushing);

		void SetInPlaceState(bool inPlace);

		void SetPlacingItemFromInventory(bool inPlace);
	}
}
