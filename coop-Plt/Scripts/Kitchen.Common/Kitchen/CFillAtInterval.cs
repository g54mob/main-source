using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CFillAtInterval : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float IntervalSeconds;

		public int Amount;

		public float CurrentDurationSeconds;
	}
}
