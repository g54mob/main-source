namespace CTS.StockInventory
{
	public struct StockCapacity
	{
		public int? MaxCapacity;

		public int CurrentCapacity;

		public bool HasCapacityFor(int amount)
		{
			if (!MaxCapacity.HasValue)
			{
				return true;
			}
			return MaxCapacity.Value - CurrentCapacity >= amount;
		}
	}
}
