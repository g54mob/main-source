using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(GameTransitionsCreateGroup))]
	public class ManageStatus : RestaurantSystem
	{
		private EntityQuery _SingletonEntityQuery_SKitchenStatus_55;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SKitchenStatus>())
			{
				base.EntityManager.CreateEntity(typeof(SKitchenStatus));
				_SingletonEntityQuery_SKitchenStatus_55.SetSingleton(new SKitchenStatus
				{
					RemainingLives = 1,
					TotalLives = 1
				});
			}
			if (!HasSingleton<SMoney>())
			{
				base.EntityManager.CreateEntity(typeof(SMoney));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SKitchenStatus_55 = GetEntityQuery(ComponentType.ReadWrite<SKitchenStatus>());
		}
	}
}
