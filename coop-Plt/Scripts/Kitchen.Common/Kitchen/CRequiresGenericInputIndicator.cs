using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CRequiresGenericInputIndicator : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public InputIndicatorMessage Message;
	}
}
