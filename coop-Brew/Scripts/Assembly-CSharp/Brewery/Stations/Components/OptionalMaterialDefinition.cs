namespace Brewery.Stations.Components
{
	public readonly struct OptionalMaterialDefinition
	{
		public string Key { get; }

		public string ItemId { get; }

		public int SlotIndex { get; }

		public OptionalMaterialDefinition(string key, string itemId, int slotIndex)
		{
			Key = null;
			ItemId = null;
			SlotIndex = 0;
		}
	}
}
