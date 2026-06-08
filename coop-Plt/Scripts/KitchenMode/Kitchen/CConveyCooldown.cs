using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CConveyCooldown : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Total;

		public float Remaining;
	}
}
