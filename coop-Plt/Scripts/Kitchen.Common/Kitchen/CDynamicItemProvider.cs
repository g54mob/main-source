using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDynamicItemProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public ItemStorage StorageFlags;
	}
}
