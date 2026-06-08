using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceDeskIterate : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float AverageTime;

		public bool IsLocked;

		public bool RequestUpdate;

		public float NextUpdateTime;
	}
}
