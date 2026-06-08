using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDurationRequiresProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int RequiredItem;

		public int MinimumItems;
	}
}
