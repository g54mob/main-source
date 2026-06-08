using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CPreventGardenDespawn : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Radius;
	}
}
