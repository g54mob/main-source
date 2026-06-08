using Unity.Entities;

namespace Kitchen
{
	public class HandleRestaurantQuitEvent : RestaurantSystem
	{
		private EntityQuery Quits;

		protected override void Initialise()
		{
			base.Initialise();
			Quits = GetEntityQuery(typeof(CRequestQuitEvent));
			RequireForUpdate(Quits);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Quits);
			Entity entity = base.EntityManager.CreateEntity(typeof(SGameOver));
			base.EntityManager.SetComponentData(entity, new SGameOver
			{
				Reason = LossReason.Quitting
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
