using Unity.Entities;
using Unity.Mathematics;

namespace PugScan
{
	public struct ScanRequestCD : IComponentData, IQueryTypeParameter
	{
		public ObjectDataCD objectToScan;

		public Entity inventory;

		public int inventorySlot;

		public bool consumeItemFromInventory;

		public Entity sourceConnectionEntity;

		public bool sendResponse;

		public PugScanType typeOfRequest;

		public float3 position;

		public Entity mapMarkerToScan;
	}
}
