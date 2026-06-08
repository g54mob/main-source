using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct CRenameRestaurant : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public FixedString64 Name;
	}
}
