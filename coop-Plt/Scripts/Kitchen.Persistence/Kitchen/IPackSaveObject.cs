using Unity.Entities;

namespace Kitchen
{
	public interface IPackSaveObject : ISaveObject
	{
		bool Save(EntityManager ctx, Entity e);

		void Load(EntityManager ctx);
	}
}
