using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CSpawnMobileAppliance : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int MobileAppliance;
	}
}
