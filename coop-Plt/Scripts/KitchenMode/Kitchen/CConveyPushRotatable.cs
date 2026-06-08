using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CConveyPushRotatable : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Orientation Target;
	}
}
