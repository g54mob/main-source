using Unity.Entities;

namespace Kitchen
{
	public class CustomersLeaveOnGameOver : GameOverSystem
	{
		private EntityQuery Query;

		protected override void Initialise()
		{
			base.Initialise();
			Query = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[1] { typeof(CCustomerGroup) },
				None = new ComponentType[1] { typeof(CGroupStartLeaving) }
			});
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CGroupStartLeaving>(Query);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
