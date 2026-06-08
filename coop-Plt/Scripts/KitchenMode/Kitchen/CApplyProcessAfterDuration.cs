using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplyProcessAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool BreakOnFailure;
	}
}
