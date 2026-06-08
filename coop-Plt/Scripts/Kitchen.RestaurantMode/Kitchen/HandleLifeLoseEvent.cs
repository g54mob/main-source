using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class HandleLifeLoseEvent : RestaurantSystem
	{
		private EntityQuery Query;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SKitchenStatus_24;

		private EntityQuery _SingletonEntityQuery_SKitchenStatus_25;

		protected override void Initialise()
		{
			base.Initialise();
			Query = GetEntityQuery(typeof(CLoseLifeEvent));
		}

		protected override void OnUpdate()
		{
			int num = Query.CalculateEntityCount();
			base.EntityManager.DestroyEntity(Query);
			if (!Has<SCheatNoLosing>() && num > 0)
			{
				SKitchenStatus singleton = _SingletonEntityQuery_SKitchenStatus_24.GetSingleton<SKitchenStatus>();
				singleton.RemainingLives -= num;
				_SingletonEntityQuery_SKitchenStatus_25.SetSingleton(singleton);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SKitchenStatus_24 = GetEntityQuery(ComponentType.ReadOnly<SKitchenStatus>());
			_SingletonEntityQuery_SKitchenStatus_25 = GetEntityQuery(ComponentType.ReadWrite<SKitchenStatus>());
		}
	}
}
