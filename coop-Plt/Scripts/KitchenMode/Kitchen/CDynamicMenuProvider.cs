using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDynamicMenuProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public DynamicMenuType Type;
	}
}
