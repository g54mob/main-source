using Unity.Entities;

namespace Kitchen
{
	public struct CHasItemCollectionIndicator : IComponentData
	{
		public Entity Indicator;

		public static implicit operator Entity(CHasItemCollectionIndicator h)
		{
			return h.Indicator;
		}
	}
}
