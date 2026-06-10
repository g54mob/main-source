namespace NSMedieval.Manager
{
	public struct ProducedItemData
	{
		public string ItemName { get; }

		public int ProducerUniqueId { get; }

		public ProducedItemData(string itemName, int producerUniqueId)
		{
			ItemName = itemName;
			ProducerUniqueId = producerUniqueId;
		}
	}
}
