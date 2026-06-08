using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CSlowPlayer : IItemProperty, IAttachableProperty, IComponentData, IApplianceProperty
	{
		public float Radius;

		public float Factor;
	}
}
