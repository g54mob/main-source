using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ActionCreateOrScrapFranchise : FranchiseBuilderSystem
	{
		private EntityQuery Pedestals;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateFranchiseSelector_4;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SClaimExpSelector_5;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SSelectedLocation_6;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_7;

		protected override void Initialise()
		{
			base.Initialise();
			Pedestals = GetEntityQuery(typeof(CCardPedestal));
			RequireSingletonForUpdate<SCreateFranchiseSelector>();
			RequireSingletonForUpdate<SClaimExpSelector>();
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SFranchiseBuilderRewardsGranted>())
			{
				return;
			}
			bool flag = false;
			if (HasComponent<CSelectorActivated>(_SingletonEntityQuery_SCreateFranchiseSelector_4.GetSingleton<SCreateFranchiseSelector>().Selector))
			{
				flag = true;
				CreateFranchise();
			}
			if (HasComponent<CSelectorActivated>(_SingletonEntityQuery_SClaimExpSelector_5.GetSingleton<SClaimExpSelector>().Selector))
			{
				flag = true;
				Scrap();
			}
			if (flag)
			{
				if (HasSingleton<SSelectedLocation>())
				{
					int slot = _SingletonEntityQuery_SSelectedLocation_6.GetSingleton<SSelectedLocation>().Selected.Slot;
					Persistence.FullWorld.Clear(slot);
					base.EntityManager.DestroyEntity(_SingletonEntityQuery_SSelectedLocation_6.GetSingletonEntity());
				}
				base.World.Add<SFranchiseBuilderRewardsGranted>();
				StartSceneTransition(SceneType.Franchise);
			}
		}

		private void DeleteSave()
		{
		}

		private void Scrap()
		{
			SClaimExpSelector singleton = _SingletonEntityQuery_SClaimExpSelector_5.GetSingleton<SClaimExpSelector>();
			Entity selector = singleton.Selector;
			if (HasComponent<CSelectorActivated>(selector))
			{
				SPlayerLevel current = GetOrCreate<SPlayerLevel>();
				current.AdvanceByExp(singleton.ExpValue);
				Set(current);
				StartSceneTransition(SceneType.Franchise);
			}
		}

		private void CreateFranchise(bool is_old_franchise = false)
		{
			Entity singletonEntity = _SingletonEntityQuery_SEndgameStats_7.GetSingletonEntity();
			SEndgameStats singleton = _SingletonEntityQuery_SEndgameStats_7.GetSingleton<SEndgameStats>();
			NativeArray<CEndgameUnlock> nativeArray = GetBuffer<CEndgameUnlock>(singletonEntity).ToNativeArray(Allocator.Temp);
			if (singleton.FranchiseTier == 0 && is_old_franchise)
			{
				return;
			}
			Entity entity = base.EntityManager.CreateEntity(typeof(CFranchiseItem), typeof(CFranchiseTier), typeof(CPersistThroughSceneChanges));
			base.EntityManager.AddComponentData(entity, new CPersistentItem
			{
				ItemID = AssetReference.FranchiseCardSet,
				Type = PersistentStorageType.FranchiseCardSet
			});
			base.EntityManager.SetComponentData(entity, new CFranchiseTier
			{
				Tier = singleton.FranchiseTier + ((!is_old_franchise) ? 1 : 0)
			});
			DataObjectList cards = default(DataObjectList);
			DynamicBuffer<CEndgameUnlock> buffer = GetBuffer<CEndgameUnlock>(singletonEntity);
			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i].FromFranchise || (buffer[i].Type == CardType.ThemeUnlock && !is_old_franchise))
				{
					cards.Add(buffer[i].UnlockID);
				}
			}
			if (!is_old_franchise)
			{
				NativeArray<CCardPedestal> nativeArray2 = Pedestals.ToComponentDataArray<CCardPedestal>(Allocator.Temp);
				for (int j = 0; j < nativeArray2.Length; j++)
				{
					if (nativeArray2[j].IsSelected)
					{
						cards.Add(nativeArray2[j].CardID);
					}
				}
			}
			foreach (CEndgameUnlock item in nativeArray)
			{
				if (!GameData.Main.TryGet<Unlock>(item.UnlockID, out var output) || !(output.ParentOption != null))
				{
					continue;
				}
				foreach (int item2 in cards)
				{
					if (item2 == output.ParentOption.ID)
					{
						cards.Add(item.UnlockID);
					}
				}
			}
			base.EntityManager.SetComponentData(entity, new CFranchiseItem
			{
				Name = singleton.Name,
				Cards = cards
			});
			GetOrCreate<CAchievementNewChefPlusEvent>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCreateFranchiseSelector_4 = GetEntityQuery(ComponentType.ReadOnly<SCreateFranchiseSelector>());
			_SingletonEntityQuery_SClaimExpSelector_5 = GetEntityQuery(ComponentType.ReadOnly<SClaimExpSelector>());
			_SingletonEntityQuery_SSelectedLocation_6 = GetEntityQuery(ComponentType.ReadOnly<SSelectedLocation>());
			_SingletonEntityQuery_SEndgameStats_7 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
		}
	}
}
