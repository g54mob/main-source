using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public static class GrantExp
	{
		public static void GrantExpFromMultiplayer(int amount, int identifier)
		{
			World createdWorld = new WorldBootstrapper("XP Grant World", GameSetupMode.Server).CreatedWorld;
			EntityManager entityManager = createdWorld.EntityManager;
			Persistence.Progress.Load(entityManager);
			NativeArray<Entity> allEntities = entityManager.GetAllEntities();
			foreach (Entity item in allEntities)
			{
				if (entityManager.HasComponent<CExpGrant>(item) && entityManager.GetComponentData<CExpGrant>(item).ExpIdentifier == identifier)
				{
					return;
				}
			}
			allEntities.Dispose();
			Entity entity = entityManager.CreateEntity(typeof(CExpGrant));
			entityManager.SetComponentData(entity, new CExpGrant
			{
				Amount = amount,
				ExpIdentifier = identifier
			});
			Persistence.Progress.Save(entityManager);
			createdWorld.Dispose();
		}
	}
}
