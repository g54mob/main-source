using Unity.Entities;

namespace Kitchen
{
	public struct CHome : IComponentData
	{
		public Entity Holder;

		public static implicit operator CHome(Entity e)
		{
			return new CHome
			{
				Holder = e
			};
		}

		public static implicit operator Entity(CHome h)
		{
			return h.Holder;
		}
	}
}
