using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct COrderEncourager : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Probability;
	}
}
