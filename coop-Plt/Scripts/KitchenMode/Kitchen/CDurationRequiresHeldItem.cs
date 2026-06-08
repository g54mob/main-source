using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDurationRequiresHeldItem : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool MustHaveItem;
	}
}
