using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCleanAppliance : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int WaterAppliance;

		public bool CanReplace;
	}
}
