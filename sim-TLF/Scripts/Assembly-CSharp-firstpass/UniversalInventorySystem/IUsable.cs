namespace UniversalInventorySystem
{
	public interface IUsable
	{
		void OnUse(object sender, InventoryHandler.UseItemEventArgs e);
	}
}
