using Unity.Entities;

namespace Kitchen
{
	public static class WorldExtensions
	{
		public static Entity Add<T>(this World w) where T : struct, IComponentData
		{
			Entity entity = w.EntityManager.CreateEntity();
			w.EntityManager.AddComponent<T>(entity);
			return entity;
		}

		public static Entity Add<T>(this World w, T comp) where T : struct, IComponentData
		{
			Entity entity = w.EntityManager.CreateEntity();
			w.EntityManager.AddComponentData(entity, comp);
			return entity;
		}
	}
}
