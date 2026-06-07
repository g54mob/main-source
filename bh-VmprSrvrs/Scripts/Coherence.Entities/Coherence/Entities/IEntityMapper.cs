namespace Coherence.Entities
{
	public interface IEntityMapper
	{
		public enum Error
		{
			None = 0,
			EntityNotFound = 1,
			TooManyEntities = 2
		}

		bool HasRelativeEntityMapped(Entity relativeEntity);

		bool FindAbsoluteEntity(Entity relativeEntity, out Entity absoluteEntity);

		bool FindRelativeEntity(Entity absoluteEntity, out Entity relativeEntity);

		Error MapToAbsoluteEntity(Entity relativeEntity, bool createEntityIfNotFound, out Entity absoluteEntity);

		Error MapToRelativeEntity(Entity absoluteEntity, bool createEntityIfNotFound, out Entity relativeEntity);

		Error UnmapRelativeEntity(Entity relativeEntity, string reason);
	}
}
