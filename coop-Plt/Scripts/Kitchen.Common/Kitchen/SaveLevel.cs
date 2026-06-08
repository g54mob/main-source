using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public static class SaveLevel
	{
		[MessagePackObject(false)]
		public struct V1 : IComponentData
		{
			[Key(0)]
			public int Level;

			[Key(1)]
			public int ExpProgress;
		}

		public static bool DoesLoadedEntityMatch(EntityManager em, Entity e)
		{
			return em.HasComponent<SPlayerLevel>(e);
		}

		public static bool Recreate(EntityManager save, EntityManager em, Entity e)
		{
			if (save.RequireComponent<V1>(e, out var component))
			{
				Entity entity = em.CreateEntity(typeof(CPersistThroughSceneChanges));
				em.AddComponentData(entity, new SPlayerLevel
				{
					Level = component.Level,
					ExpProgress = component.ExpProgress
				});
				return true;
			}
			return false;
		}

		public static bool Save(EntityManager em, Entity e, out V1 output)
		{
			if (em.RequireComponent<SPlayerLevel>(e, out var component))
			{
				output = new V1
				{
					Level = component.Level,
					ExpProgress = component.ExpProgress
				};
				return true;
			}
			output = default(V1);
			return false;
		}
	}
}
