using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCreateStorageToolAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ToolID;
	}
}
