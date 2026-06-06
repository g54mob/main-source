using System;

namespace Brewery.Stations.Components
{
	public readonly struct BatchInputRequirement
	{
		public int SlotIndex { get; }

		public string ItemId { get; }

		public int QuantityPerBatch { get; }

		public bool Required { get; }

		public bool AllowDynamicItemId { get; }

		public Func<StationSlotData, bool> AdditionalValidator { get; }

		public BatchInputRequirement(int slotIndex, string itemId, int quantityPerBatch, bool required = true, bool allowDynamicItemId = false, Func<StationSlotData, bool> additionalValidator = null)
		{
			SlotIndex = 0;
			ItemId = null;
			QuantityPerBatch = 0;
			Required = false;
			AllowDynamicItemId = false;
			AdditionalValidator = null;
		}
	}
}
