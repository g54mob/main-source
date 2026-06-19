namespace UniversalInventorySystem
{
	public interface IDropBehaviour
	{
		void OnDropItem(object sender, InventoryHandler.DropItemEventArgs e);
	}
}
