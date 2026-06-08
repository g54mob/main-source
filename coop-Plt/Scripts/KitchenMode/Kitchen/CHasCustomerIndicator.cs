using Unity.Entities;

namespace Kitchen
{
	public struct CHasCustomerIndicator : IComponentData
	{
		public Entity Indicator;

		public static implicit operator Entity(CHasCustomerIndicator h)
		{
			return h.Indicator;
		}
	}
}
