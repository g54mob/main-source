using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CIsInteractive : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsLowPriority;
	}
}
