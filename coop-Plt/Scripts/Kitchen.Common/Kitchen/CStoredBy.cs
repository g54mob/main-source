using Unity.Entities;

namespace Kitchen
{
	public struct CStoredBy : IComponentData
	{
		public Entity Storage;

		public static implicit operator CStoredBy(Entity e)
		{
			return new CStoredBy
			{
				Storage = e
			};
		}

		public static implicit operator Entity(CStoredBy h)
		{
			return h.Storage;
		}
	}
}
