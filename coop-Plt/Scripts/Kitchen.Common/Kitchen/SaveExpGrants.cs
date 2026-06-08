using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SaveExpGrants : GenericSystemBase
	{
		private EntityQuery ExpGrants;

		protected override void Initialise()
		{
			ExpGrants = GetEntityQuery(typeof(CExpGrant));
		}

		protected override void OnUpdate()
		{
		}

		public void RemoveEntities()
		{
			NativeArray<Entity> allEntities = base.EntityManager.GetAllEntities();
			foreach (Entity item in allEntities)
			{
				if (base.EntityManager.HasComponent<CExpGrant>(item))
				{
					base.EntityManager.DestroyEntity(item);
				}
			}
			allEntities.Dispose();
		}

		public void AddEntitiesToSave(EntityManager dst)
		{
			foreach (CExpGrant item in ExpGrants.ToComponentDataArray<CExpGrant>(Allocator.Temp))
			{
				Entity entity = dst.CreateEntity(typeof(CExpGrant));
				dst.SetComponentData(entity, item);
			}
		}

		public void LoadEntitiesFromSave(EntityManager src)
		{
			foreach (Entity allEntity in src.GetAllEntities())
			{
				if (src.HasComponent<CExpGrant>(allEntity))
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CExpGrant), typeof(CPersistThroughSceneChanges));
					base.EntityManager.SetComponentData(entity, src.GetComponentData<CExpGrant>(allEntity));
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
