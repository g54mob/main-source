using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemHolderOnlySpecificItem : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ItemID;
	}
}
