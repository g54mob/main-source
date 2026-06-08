using Unity.Entities;

namespace Kitchen
{
	public struct CHasFireSubEntity : IComponentData
	{
		public Entity Entity;

		public static implicit operator Entity(CHasFireSubEntity c)
		{
			return c.Entity;
		}

		public static implicit operator CHasFireSubEntity(Entity c)
		{
			return new CHasFireSubEntity
			{
				Entity = c
			};
		}
	}
}
