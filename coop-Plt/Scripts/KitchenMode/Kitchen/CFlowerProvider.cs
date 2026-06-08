using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CFlowerProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int GardenProfile;
	}
}
