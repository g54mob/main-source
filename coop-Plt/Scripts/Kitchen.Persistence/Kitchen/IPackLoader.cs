using Unity.Entities;

namespace Kitchen
{
	public interface IPackLoader
	{
		bool LoadEntity(EntityManager ctx, ISaveObject save_object);
	}
}
