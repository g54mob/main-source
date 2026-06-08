using Unity.Entities;

namespace Kitchen
{
	public struct CHasAssociatedBubble : IComponentData
	{
		public Entity Entity;

		public static implicit operator Entity(CHasAssociatedBubble h)
		{
			return h.Entity;
		}

		public static implicit operator CHasAssociatedBubble(Entity h)
		{
			return new CHasAssociatedBubble
			{
				Entity = h
			};
		}
	}
}
