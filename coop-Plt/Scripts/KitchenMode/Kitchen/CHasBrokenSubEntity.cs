using Unity.Entities;

namespace Kitchen
{
	public struct CHasBrokenSubEntity : IComponentData
	{
		public Entity Entity;

		public static implicit operator Entity(CHasBrokenSubEntity c)
		{
			return c.Entity;
		}

		public static implicit operator CHasBrokenSubEntity(Entity c)
		{
			return new CHasBrokenSubEntity
			{
				Entity = c
			};
		}
	}
}
