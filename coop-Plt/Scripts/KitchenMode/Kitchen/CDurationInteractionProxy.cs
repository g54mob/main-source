using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDurationInteractionProxy : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Entity Proxy;
	}
}
