using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDestroyApplianceAtDay : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool HideBin;
	}
}
