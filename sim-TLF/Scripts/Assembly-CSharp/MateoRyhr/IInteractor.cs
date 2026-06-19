namespace MateoRyhr
{
	public interface IInteractor
	{
		Interactable Interactable { get; set; }

		void Interact();
	}
}
