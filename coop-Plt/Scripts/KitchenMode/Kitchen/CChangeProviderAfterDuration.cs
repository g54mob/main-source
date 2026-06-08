using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CChangeProviderAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ReplaceItem;
	}
}
