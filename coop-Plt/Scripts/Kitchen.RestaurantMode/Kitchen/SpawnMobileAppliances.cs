using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class SpawnMobileAppliances : StartOfDaySystem
	{
		private EntityQuery Spawners;

		protected override void Initialise()
		{
			base.Initialise();
			Spawners = GetEntityQuery(new QueryHelper().All(typeof(CSpawnMobileAppliance), typeof(CPosition)).None(typeof(CDestroyApplianceAtDay)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = Spawners.ToEntityArray(Allocator.Temp);
			EntityContext entityContext = new EntityContext(base.EntityManager);
			foreach (Entity item in nativeArray)
			{
				if (Require<CPosition>(item, out CPosition comp) && Require<CSpawnMobileAppliance>(item, out CSpawnMobileAppliance comp2))
				{
					Entity entity = entityContext.CreateEntity();
					entityContext.Set(entity, new CCreateAppliance
					{
						ID = comp2.MobileAppliance
					});
					entityContext.Set(entity, comp);
					entityContext.Set(entity, default(CDestroyApplianceAtNight));
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
