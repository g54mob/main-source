using Unity.Entities;

namespace Kitchen
{
	public struct CHasProgressIndicator : IComponentData
	{
		public Entity Indicator;

		public static implicit operator Entity(CHasProgressIndicator h)
		{
			return h.Indicator;
		}
	}
}
