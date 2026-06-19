namespace UniversalInventorySystem
{
	public interface IPickUpBehaviour
	{
		void OnPickUp(object sender, InventoryHandler.AddItemEventArgs e);
	}
}
