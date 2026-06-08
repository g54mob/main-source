using KitchenData;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public static class SaveResearch
	{
		[MessagePackObject(false)]
		public struct V1 : IComponentData
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public int ResearchProvided;
		}

		public static bool DoesLoadedEntityMatch(EntityManager em, Entity e)
		{
			return em.HasComponent<CPartialResearch>(e);
		}

		public static bool Recreate(EntityManager save, EntityManager em, Entity e)
		{
			if (save.RequireComponent<V1>(e, out var component))
			{
				if (!GameData.Main.Has(component.ID))
				{
					return false;
				}
				Entity entity = em.CreateEntity(typeof(CPersistThroughSceneChanges));
				em.AddComponentData(entity, new CPartialResearch
				{
					Upgrade = component.ID,
					ResearchProvided = component.ResearchProvided
				});
				return true;
			}
			return false;
		}

		public static bool Save(EntityManager em, Entity e, out V1 output)
		{
			if (em.RequireComponent<CPartialResearch>(e, out var component))
			{
				output = new V1
				{
					ID = component.Upgrade,
					ResearchProvided = component.ResearchProvided
				};
				return true;
			}
			output = default(V1);
			return false;
		}
	}
}
