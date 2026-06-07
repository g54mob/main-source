namespace Brewery.Stations.Components.Interfaces
{
	public readonly struct InventorySlotSnapshot
	{
		public int Index { get; }

		public string ItemId { get; }

		public int Quantity { get; }

		public bool IsEmpty => false;

		public InventorySlotSnapshot(int index, string itemId, int quantity)
		{
			Index = 0;
			ItemId = null;
			Quantity = 0;
		}
	}
}
