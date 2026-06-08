using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CGrantMoneyAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Amount;
	}
}
