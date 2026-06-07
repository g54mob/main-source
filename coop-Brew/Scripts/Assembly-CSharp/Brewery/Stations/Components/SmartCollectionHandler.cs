using Brewery.Stations.Components.Interfaces;
using Brewery.Systems;

namespace Brewery.Stations.Components
{
	public sealed class SmartCollectionHandler
	{
		private readonly IMetadataProvider metadataProvider;

		private readonly ulong stationId;

		private readonly InventoryType stationInventoryType;

		public SmartCollectionHandler(IMetadataProvider metadataProvider, ulong stationId, InventoryType stationInventoryType = InventoryType.Player)
		{
		}

		public int CalculateCollectableCount(StationSlotData outputSlot, IInventoryQuery inventoryQuery)
		{
			return 0;
		}

		public void ShiftMetadata(int collectedCount, int remainingCount)
		{
		}
	}
}
