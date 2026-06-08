using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup))]
	public class ManageParameters : GameSystemBase
	{
		private EntityQuery Starters;

		private EntityQuery Desserts;

		protected override void Initialise()
		{
			base.Initialise();
			Starters = GetEntityQuery(typeof(CMenuItemStarter));
			Desserts = GetEntityQuery(typeof(CMenuItemDessert));
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SKitchenParameters>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SKitchenParameters));
				base.EntityManager.SetComponentData(entity, new SKitchenParameters
				{
					Parameters = KitchenParameters.Defaults
				});
			}
			SKitchenParameters orCreate = GetOrCreate<SKitchenParameters>();
			orCreate.Parameters.CurrentCourses = 1 + ((!Starters.IsEmpty) ? 1 : 0) + ((!Desserts.IsEmpty) ? 1 : 0);
			Set(orCreate);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
