using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemHolderPreventTransfer : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool PreventInsertingInto;

		public bool PreventTakingFrom;
	}
}
