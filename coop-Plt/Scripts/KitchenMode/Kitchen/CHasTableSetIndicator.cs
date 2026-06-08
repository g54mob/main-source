using Unity.Entities;

namespace Kitchen
{
	public struct CHasTableSetIndicator : IComponentData
	{
		public Entity Indicator;

		public static implicit operator Entity(CHasTableSetIndicator h)
		{
			return h.Indicator;
		}
	}
}
