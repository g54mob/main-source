using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct COriginalOrderBeforePiecemeal : IComponentData
	{
		public int ItemID;

		public ItemList OriginalItems;
	}
}
