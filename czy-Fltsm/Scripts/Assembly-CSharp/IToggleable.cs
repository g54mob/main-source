public interface IToggleable
{
	bool IsInteractable { get; }

	bool IsCompleted { get; }

	bool IsToggled { get; }

	void Toggle();
}
