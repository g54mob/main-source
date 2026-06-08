using Unity.Entities;

namespace Kitchen
{
	public struct CHasExtraCollectionIndicator : IComponentData
	{
		public Entity Indicator;

		public static implicit operator Entity(CHasExtraCollectionIndicator h)
		{
			return h.Indicator;
		}
	}
}
