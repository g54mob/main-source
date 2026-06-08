using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class CreateEndgameStatsEntity : GameOverSystem
	{
		private EntityQuery Unlocks;

		private EntityQuery UnlockOptions;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLayout_26;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_27;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_CRenameRestaurant_28;

		protected override void Initialise()
		{
			base.Initialise();
			Unlocks = GetEntityQuery(typeof(CProgressionUnlock));
			UnlockOptions = GetEntityQuery(typeof(CProgressionOption));
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SEndgameStats>())
			{
				return;
			}
			Entity entity = base.EntityManager.CreateEntity(typeof(SEndgameStats), typeof(CSceneChangeData), typeof(CEndgameUnlock));
			int franchiseTier = 0;
			Entity singletonEntity = _SingletonEntityQuery_SLayout_26.GetSingletonEntity();
			if (HasComponent<CFranchiseTier>(singletonEntity))
			{
				franchiseTier = GetComponent<CFranchiseTier>(singletonEntity).Tier;
			}
			int day = _SingletonEntityQuery_SDay_27.GetSingleton<SDay>().Day;
			bool flag = Has<SIsNightTime>();
			string text = "Restaurant";
			if (HasSingleton<CRenameRestaurant>())
			{
				text = _SingletonEntityQuery_CRenameRestaurant_28.GetSingleton<CRenameRestaurant>().Name.Value;
			}
			Set(new SEndgameStats
			{
				DayReached = day,
				IsFranchiseCreation = (day > 15 || (flag && day == 15)),
				FranchiseTier = franchiseTier,
				Name = text
			});
			DynamicBuffer<CEndgameUnlock> buffer = base.EntityManager.GetBuffer<CEndgameUnlock>(entity);
			using NativeArray<CProgressionUnlock> nativeArray = Unlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp);
			foreach (CProgressionUnlock item in nativeArray)
			{
				buffer.Add(new CEndgameUnlock
				{
					UnlockID = item.ID,
					FromFranchise = item.FromFranchise,
					Type = item.Type
				});
			}
			if (!UnlockOptions.IsEmpty)
			{
				CProgressionOption cProgressionOption = UnlockOptions.First<CProgressionOption>();
				if (base.Data.TryGet<ICard>(cProgressionOption.ID, out var output, warn_if_fail: true))
				{
					buffer.Add(new CEndgameUnlock
					{
						UnlockID = cProgressionOption.ID,
						FromFranchise = cProgressionOption.FromFranchise,
						Type = output.CardType
					});
				}
			}
			if (RequireEntity<SSelectedLocation>(out var comp))
			{
				Set<CSceneChangeData>(comp);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLayout_26 = GetEntityQuery(ComponentType.ReadOnly<SLayout>());
			_SingletonEntityQuery_SDay_27 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			_SingletonEntityQuery_CRenameRestaurant_28 = GetEntityQuery(ComponentType.ReadOnly<CRenameRestaurant>());
		}
	}
}
