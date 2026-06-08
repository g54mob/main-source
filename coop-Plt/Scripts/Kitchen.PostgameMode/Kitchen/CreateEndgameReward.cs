using System.Linq;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateEndgameExpReward))]
	public class CreateEndgameReward : PostgameInitialisationSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SRewardsGranted : IComponentData
		{
		}

		private EntityQuery GrantedRewards;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_5;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameExpRewarded_6;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_Marker_7;

		protected override void Initialise()
		{
			base.Initialise();
			GrantedRewards = GetEntityQuery(typeof(CUpgrade));
			RequireSingletonForUpdate<CreateEndgameExpReward.SEndgameExpRewarded>();
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SRewardsGranted>())
			{
				return;
			}
			base.EntityManager.CreateEntity(typeof(SRewardsGranted));
			SEndgameStats singleton = _SingletonEntityQuery_SEndgameStats_5.GetSingleton<SEndgameStats>();
			CExpChange component = GetComponent<CExpChange>(_SingletonEntityQuery_SEndgameExpRewarded_6.GetSingletonEntity());
			NativeArray<CUpgrade> all = GrantedRewards.ToComponentDataArray<CUpgrade>(Allocator.Temp);
			int num = component.New.Level - component.Old.Level;
			CreateExpNewsItem(component);
			if (num != 0)
			{
				foreach (LevelUpgradeSet item in base.Data.Get<LevelUpgradeSet>().ToList())
				{
					int level;
					for (level = component.Old.Level; level < component.New.Level; level++)
					{
						foreach (LevelUpgrade item2 in item.Upgrades.Where((LevelUpgrade u) => u.Level == level + 1))
						{
							if (UpgradeIsValid(all, item2.Upgrade))
							{
								ProvideReward(item2.Upgrade);
							}
						}
					}
				}
			}
			if (!singleton.IsExpGrant)
			{
				int dayReached = singleton.DayReached;
				GrantRandomReward(all, dayReached);
			}
			all.Dispose();
		}

		protected void GrantRandomReward(NativeArray<CUpgrade> all, int day)
		{
			foreach (RandomUpgradeSet item in from s in base.Data.Get<RandomUpgradeSet>()
				where s.Tier <= RandomUpgradeSet.GetTierForDay(day)
				orderby s.Tier descending
				select s)
			{
				foreach (IUpgrade item2 in item.Rewards.Shuffle())
				{
					if (UpgradeIsValid(all, item2))
					{
						ProvideReward(item2);
						return;
					}
				}
			}
		}

		protected void ProvideReward(IUpgrade upg)
		{
			if (!(upg is Dish dish))
			{
				if (!(upg is Appliance appliance))
				{
					if (!(upg is FranchiseUpgrade franchiseUpgrade))
					{
						if (!(upg is LayoutProfile layoutProfile))
						{
							if (!(upg is RestaurantSetting restaurantSetting))
							{
								if (upg is Contract contract)
								{
									CreateNewsItem(NewsItemType.Contract, contract.ID);
								}
							}
							else
							{
								CreateNewsItem(NewsItemType.Setting, restaurantSetting.ID);
							}
						}
						else
						{
							CreateNewsItem(NewsItemType.NewLayout, layoutProfile.ID);
						}
					}
					else
					{
						CreateNewsItem(NewsItemType.FranchiseUpgrade, franchiseUpgrade.ID);
					}
				}
				else
				{
					CreateNewsItem(NewsItemType.GarageReward, appliance.ID);
				}
			}
			else
			{
				CreateNewsItem(NewsItemType.Dish, dish.ID);
			}
		}

		protected bool UpgradeIsValid(NativeArray<CUpgrade> all, IUpgrade upg)
		{
			if (upg.MaximumUpgradeCount <= 0)
			{
				return true;
			}
			int num = 0;
			foreach (CUpgrade item in all)
			{
				if (item.ID == upg.ID)
				{
					num++;
				}
				if (num >= upg.MaximumUpgradeCount)
				{
					break;
				}
			}
			return num < upg.MaximumUpgradeCount;
		}

		protected void CreateNewsItem(NewsItemType type, int reward)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CNewsItem), typeof(CRequiresView));
			base.EntityManager.SetComponentData(entity, new CNewsItem
			{
				Type = type,
				Reward = reward
			});
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.NewsItem
			});
			GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_7.GetSingletonEntity()).Add(new SNewsList
			{
				Item = entity
			});
		}

		protected void CreateExpNewsItem(CExpChange change)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CPosition), typeof(CNewsItem), typeof(CRequiresView), typeof(CExpChange));
			base.EntityManager.SetComponentData(entity, new CNewsItem
			{
				Type = NewsItemType.LevelProgress
			});
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.NewsItem
			});
			base.EntityManager.SetComponentData(entity, change);
			GetBuffer<SNewsList>(_SingletonEntityQuery_Marker_7.GetSingletonEntity()).Add(new SNewsList
			{
				Item = entity
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_5 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			_SingletonEntityQuery_SEndgameExpRewarded_6 = GetEntityQuery(ComponentType.ReadOnly<CreateEndgameExpReward.SEndgameExpRewarded>());
			_SingletonEntityQuery_Marker_7 = GetEntityQuery(ComponentType.ReadOnly<SNewsList.Marker>());
		}
	}
}
