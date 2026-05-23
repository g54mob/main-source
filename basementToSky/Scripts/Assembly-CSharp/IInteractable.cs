public interface IInteractable
{
	string InteractionText { get; }

	void Interact();

	void OnDetected();

	void OnLost();
}
