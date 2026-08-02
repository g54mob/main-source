public interface IGrabbable
{
	void Remove(PlayerInventory inventory);

	void Grab();

	void Drop(Grabber grabber, TSPlayerController player);

	void Rotate();
}
