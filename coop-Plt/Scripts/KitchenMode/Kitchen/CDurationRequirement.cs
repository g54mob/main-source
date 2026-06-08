using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDurationRequirement : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool NeedsScheduledCustomers;

		public bool NeedsBeforeClosing;
	}
}
