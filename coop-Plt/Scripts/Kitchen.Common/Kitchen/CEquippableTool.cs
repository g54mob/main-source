using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CEquippableTool : IItemProperty, IAttachableProperty, IComponentData
	{
		public bool CanHoldItems;
	}
}
