namespace Brewery.Stations.Components.Interfaces
{
	public interface IInventoryModifier
	{
		bool TryRemoveItem(string itemId, int quantity);

		bool TryAddItem(string itemId, int quantity);
	}
}
