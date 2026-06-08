using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CChangeProviderWhenEmpty : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ReplaceItem;
	}
}
