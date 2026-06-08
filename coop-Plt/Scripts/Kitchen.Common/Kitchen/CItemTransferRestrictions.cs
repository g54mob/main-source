using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemTransferRestrictions : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool AllowWhenActive;

		public bool AllowWhenInactive;
	}
}
