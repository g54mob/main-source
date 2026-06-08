using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CGrantsShopDiscount : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Amount;
	}
}
