using Unity.Entities;

namespace Kitchen
{
	public interface IPackSaver
	{
		bool PrepareEntity(EntityManager ctx, Entity e);

		bool SaveEntity(EntityManager ctx, Entity e, out ISaveObject save_object);
	}
}
