using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CGivesDecoration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public DecorationValues DecorationValues;
	}
}
