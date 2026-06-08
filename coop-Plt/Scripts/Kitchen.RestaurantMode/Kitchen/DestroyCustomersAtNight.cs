using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(DestructionGroup))]
	public class DestroyCustomersAtNight : NightSystem
	{
		private EntityQuery Query;

		protected override void Initialise()
		{
			base.Initialise();
			Query = GetEntityQuery(new EntityQueryDesc
			{
				Any = new ComponentType[2]
				{
					typeof(CCustomer),
					typeof(CCustomerGroup)
				}
			});
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Query);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
