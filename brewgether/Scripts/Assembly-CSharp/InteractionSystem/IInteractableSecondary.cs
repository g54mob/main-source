namespace InteractionSystem
{
	public interface IInteractableSecondary
	{
		void InteractSecondary(ulong clientId);

		bool CanInteractSecondary(ulong clientId);
	}
}
