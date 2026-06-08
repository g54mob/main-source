using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class RecreateMobileAppliances : GameSystemBase
	{
		private EntityQuery OutdatedMobileAppliances;

		protected override void Initialise()
		{
			base.Initialise();
			OutdatedMobileAppliances = GetEntityQuery(new QueryHelper().All(typeof(CMobileAppliance), typeof(CPosition), typeof(CAppliance)).None(typeof(CDestroyApplianceAtNight)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = OutdatedMobileAppliances.ToEntityArray(Allocator.Temp);
			EntityContext entityContext = new EntityContext(base.EntityManager);
			foreach (Entity item in nativeArray)
			{
				if (Require<CPosition>(item, out CPosition comp) && Require<CAppliance>(item, out CAppliance comp2))
				{
					Entity entity = entityContext.CreateEntity();
					entityContext.Set(entity, new CCreateAppliance
					{
						ID = comp2.ID
					});
					entityContext.Set(entity, comp);
					entityContext.Destroy(item);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
