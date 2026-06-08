using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class CheckGameOverFromLife : RestaurantSystem
	{
		private EntityQuery Patience;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SKitchenStatus_21;

		private EntityQuery _SingletonEntityQuery_SKitchenStatus_22;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_23;

		protected override void Initialise()
		{
			base.Initialise();
			Patience = GetEntityQuery(typeof(CPatience));
		}

		protected override void OnUpdate()
		{
			SKitchenStatus singleton = _SingletonEntityQuery_SKitchenStatus_21.GetSingleton<SKitchenStatus>();
			if (!HasSingleton<SGameOver>() && singleton.RemainingLives <= 0 && !Has<SPracticeMode>() && !RescuedByAppliance() && !RescuedByDay())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(SGameOver), typeof(CGamePauseBlock));
				base.EntityManager.SetComponentData(entity, new SGameOver
				{
					Reason = LossReason.Patience
				});
			}
		}

		private bool RescuedByAppliance()
		{
			SKitchenStatus singleton = _SingletonEntityQuery_SKitchenStatus_21.GetSingleton<SKitchenStatus>();
			EntityQuery entityQuery = GetEntityQuery(new QueryHelper().All(typeof(CPreventGameOver)).None(typeof(CPreventGameOverConsumed)));
			if (!entityQuery.IsEmpty)
			{
				base.EntityManager.AddComponent<CPreventGameOverConsumed>(entityQuery.First());
				_SingletonEntityQuery_SKitchenStatus_22.SetSingleton(new SKitchenStatus
				{
					RemainingLives = 1,
					TotalLives = singleton.TotalLives
				});
				using NativeArray<Entity> nativeArray = Patience.ToEntityArray(Allocator.Temp);
				foreach (Entity item in nativeArray)
				{
					if (Require<CPatience>(item, out CPatience comp))
					{
						comp.ResetTime();
						Set(item, comp);
					}
				}
				return true;
			}
			return false;
		}

		private bool RescuedByDay()
		{
			SKitchenStatus singleton = _SingletonEntityQuery_SKitchenStatus_21.GetSingleton<SKitchenStatus>();
			if (_SingletonEntityQuery_SDay_23.GetSingleton<SDay>().Day <= 3)
			{
				base.World.Add(new COfferRestartDay
				{
					Reason = LossReason.Patience
				});
				_SingletonEntityQuery_SKitchenStatus_22.SetSingleton(new SKitchenStatus
				{
					RemainingLives = singleton.TotalLives,
					TotalLives = singleton.TotalLives
				});
				return true;
			}
			return false;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SKitchenStatus_21 = GetEntityQuery(ComponentType.ReadOnly<SKitchenStatus>());
			_SingletonEntityQuery_SKitchenStatus_22 = GetEntityQuery(ComponentType.ReadWrite<SKitchenStatus>());
			_SingletonEntityQuery_SDay_23 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
