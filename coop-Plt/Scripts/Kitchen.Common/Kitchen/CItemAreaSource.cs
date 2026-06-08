using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemAreaSource : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Range;
	}
}
