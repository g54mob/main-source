using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PersistProgressionEntities : GenericSystemBase
	{
		protected override void OnUpdate()
		{
		}

		public void RemoveEntities()
		{
			Debug.Log("Deleting progression entities");
			NativeArray<Entity> allEntities = base.EntityManager.GetAllEntities();
			foreach (Entity item in allEntities)
			{
				if (SaveUpgrades.DoesLoadedEntityMatch(base.EntityManager, item) || SaveLevel.DoesLoadedEntityMatch(base.EntityManager, item) || SaveCardSets.DoesLoadedEntityMatch(base.EntityManager, item) || SaveResearch.DoesLoadedEntityMatch(base.EntityManager, item))
				{
					base.EntityManager.DestroyEntity(item);
				}
			}
			allEntities.Dispose();
		}

		public void AddEntitiesToSave(EntityManager save)
		{
			Debug.Log("Beginning a save");
			NativeArray<Entity> allEntities = base.EntityManager.GetAllEntities();
			foreach (Entity item in allEntities)
			{
				if (SaveUpgrades.Save(base.EntityManager, item, out var output))
				{
					save.AddComponentData(save.CreateEntity(), output);
				}
				if (SaveLevel.Save(base.EntityManager, item, out var output2))
				{
					save.AddComponentData(save.CreateEntity(), output2);
				}
				if (SaveResearch.Save(base.EntityManager, item, out var output3))
				{
					save.AddComponentData(save.CreateEntity(), output3);
				}
				SaveCardSets.Save(base.EntityManager, item, save);
			}
			allEntities.Dispose();
		}

		public void LoadEntitiesFromSave(EntityManager save)
		{
			Debug.Log("Beginning a load");
			NativeArray<Entity> allEntities = save.GetAllEntities();
			foreach (Entity item in allEntities)
			{
				SaveUpgrades.Recreate(save, base.EntityManager, item);
				SaveResearch.Recreate(save, base.EntityManager, item);
				SaveLevel.Recreate(save, base.EntityManager, item);
				SaveCardSets.Recreate(save, base.EntityManager, item);
			}
			allEntities.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
