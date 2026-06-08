using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CRefreshesSpecificProvider : IItemProperty, IAttachableProperty, IComponentData
	{
		public int Item;
	}
}
