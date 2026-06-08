using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCreatesTemporaryAppliances : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Range;

		public int Appliance;
	}
}
