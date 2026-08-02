public interface IDoor
{
	bool IsOpened { get; }

	void OpenDoor();

	void CloseDoor();

	void Interact();
}
