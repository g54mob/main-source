using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceHostStand : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool Automatic;
	}
}
