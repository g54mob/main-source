using Unity.Entities;

namespace Kitchen
{
	public struct CHeldBy : IComponentData
	{
		public Entity Holder;

		public static implicit operator CHeldBy(Entity e)
		{
			return new CHeldBy
			{
				Holder = e
			};
		}

		public static implicit operator Entity(CHeldBy h)
		{
			return h.Holder;
		}
	}
}
