using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CBreakIfBadDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool CatchFire;

		public bool TriggeredByNoProcess;

		public bool TriggeredByBadProcess;
	}
}
