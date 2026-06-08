using System;
using System.Collections;
using System.Collections.Generic;
using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class BeginRestaurant : FranchiseSystem
	{
		private EntityQuery Pedestals;

		private EntityQuery Selectors;

		private EntityQuery SeedFixers;

		private EntityQuery Layouts;

		private EntityQuery Dishes;

		private EntityQuery Setting;

		private List<CDishChoice> DishList = new List<CDishChoice>();

		private List<CItemLayoutMap> LayoutList = new List<CItemLayoutMap>();

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLoadoutStatus_13;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SFranchiseSelector_14;

		public static BeginRestaurant Instance { get; private set; }

		protected override void Initialise()
		{
			base.Initialise();
			Pedestals = GetEntityQuery(typeof(CItemHolder), typeof(CItemPedestal));
			SeedFixers = GetEntityQuery(typeof(CSeededRunInfo));
			Selectors = GetEntityQuery(typeof(SBeginGameSelector), typeof(CSelectorActivated), typeof(CGroupSelector));
			Layouts = GetEntityQuery(typeof(CItemHolder), typeof(CreateLayoutSlots.CLayoutSlot));
			Dishes = GetEntityQuery(typeof(CItemHolder), typeof(CDishSource));
			Setting = GetEntityQuery(typeof(CSettingSelector));
			RequireForUpdate(Selectors);
			Instance = this;
		}

		public IEnumerator InitialiseRandomRestaurant()
		{
			yield return new WaitUntil(() => !HasSingleton<SPerformSceneTransition>());
			if (GameInfo.CurrentScene == SceneType.Kitchen)
			{
				yield break;
			}
			yield return new WaitUntil(() => !Layouts.IsEmpty && !Dishes.IsEmpty);
			yield return new WaitUntil(delegate
			{
				Layouts.First();
				return true;
			});
			using NativeArray<CItemHolder> nativeArray = Layouts.ToComponentDataArray<CItemHolder>(Allocator.TempJob);
			foreach (CItemHolder item in nativeArray)
			{
				if (HasComponent<CItemLayoutMap>(item.HeldItem))
				{
					LayoutList.Add(base.EntityManager.GetComponentData<CItemLayoutMap>(item.HeldItem));
				}
			}
			CItemLayoutMap cItemLayoutMap = LayoutList.Random();
			CSetting componentData = new CSetting
			{
				RestaurantSetting = Setting.First<CSettingSelector>().SettingID
			};
			if (!componentData.FixedSeed.IsSet && !SeedFixers.IsEmpty)
			{
				componentData.FixedSeed = SeedFixers.First<CSeededRunInfo>().FixedSeed;
				base.EntityManager.AddComponentData(cItemLayoutMap.Layout, componentData);
			}
			else
			{
				base.EntityManager.AddComponentData(cItemLayoutMap.Layout, componentData);
			}
			using NativeArray<CItemHolder> nativeArray2 = Dishes.ToComponentDataArray<CItemHolder>(Allocator.TempJob);
			foreach (CItemHolder item2 in nativeArray2)
			{
				if (HasComponent<CDishChoice>(item2.HeldItem))
				{
					DishList.Add(base.EntityManager.GetComponentData<CDishChoice>(item2.HeldItem));
				}
			}
			CDishChoice cDishChoice = DishList.Random();
			bool flag = false;
			base.EntityManager.AddComponent<CSceneChangeData>(cItemLayoutMap.Layout);
			base.EntityManager.AddComponent<SSceneData>(cItemLayoutMap.Layout);
			if (true)
			{
				base.EntityManager.GetBuffer<CStartingItem>(cItemLayoutMap.Layout).Add(new CStartingItem
				{
					ID = cDishChoice.Dish
				});
				if (!flag && GameData.Main.TryGet<Dish>(cDishChoice.Dish, out var output) && !output.StartingNameSet.IsNullOrEmpty())
				{
					string text = output.StartingNameSet.Random();
					try
					{
						Set(cItemLayoutMap.Layout, new CStartingName
						{
							Name = text
						});
					}
					catch (ArgumentException message)
					{
						Debug.LogError(message);
						Debug.LogError("Failed to rename restaurant " + text);
					}
				}
			}
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponent<CPersistThroughSceneChanges>(entity);
			base.EntityManager.AddComponentData(entity, new CRequestSave
			{
				SaveType = SaveType.Auto
			});
			StartSceneTransition(SceneType.Kitchen);
			LayoutList.Clear();
			DishList.Clear();
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SPerformSceneTransition>() || _SingletonEntityQuery_SLoadoutStatus_13.GetSingleton<SLoadoutStatus>().Required != SLoadoutStatus.RequiredActions.None)
			{
				return;
			}
			bool flag = false;
			CSpeedrun result;
			bool componentOfSingletonHolder = GetComponentOfSingletonHolder<CSpeedrun, SSelectedLayoutPedestal>(out result);
			bool flag2 = true;
			Entity entity = default(Entity);
			if (!componentOfSingletonHolder && HasSingleton<SFranchiseSelector>())
			{
				SFranchiseSelector singleton = _SingletonEntityQuery_SFranchiseSelector_14.GetSingleton<SFranchiseSelector>();
				entity = singleton.SelectedFranchise;
				if (entity != default(Entity))
				{
					flag = true;
				}
				flag2 = !flag || singleton.RequiresAdditionalBase;
			}
			using NativeArray<CItemHolder> nativeArray = Pedestals.ToComponentDataArray<CItemHolder>(Allocator.TempJob);
			CItemLayoutMap result2 = default(CItemLayoutMap);
			if (!GetComponentOfSingletonHolder<CItemLayoutMap, SSelectedLayoutPedestal>(out result2))
			{
				return;
			}
			int num = 0;
			CDishChoice result3;
			CDishChoice result4;
			if (componentOfSingletonHolder)
			{
				base.EntityManager.AddComponent<CSpeedrun>(result2.Layout);
				base.EntityManager.SetComponentData(result2.Layout, result);
				num = result.DishID;
			}
			else if (!flag && GetComponentOfSingletonHolder<CDishChoice, SFixedDishPedestal>(out result3) && result3.Dish != 0)
			{
				num = result3.Dish;
			}
			else if (GetComponentOfSingletonHolder<CDishChoice, SDishPedestal>(out result4))
			{
				num = result4.Dish;
			}
			else if (flag2)
			{
				return;
			}
			base.EntityManager.AddComponent<CSceneChangeData>(result2.Layout);
			base.EntityManager.AddComponent<SSceneData>(result2.Layout);
			if (flag)
			{
				int tier = 0;
				if (base.EntityManager.RequireComponent<CFranchiseTier>(entity, out var component))
				{
					tier = component.Tier;
				}
				foreach (int card in base.EntityManager.GetComponentData<CFranchiseItem>(entity).Cards)
				{
					base.EntityManager.GetBuffer<CStartingItem>(result2.Layout).Add(new CStartingItem
					{
						ID = card,
						SkipFirstTimeInfo = true
					});
				}
				base.EntityManager.AddComponentData(result2.Layout, new CFranchiseTier
				{
					Tier = tier
				});
				if (Require<CFranchiseItem>(entity, out CFranchiseItem comp))
				{
					base.EntityManager.AddComponentData(result2.Layout, comp);
				}
				base.EntityManager.DestroyEntity(entity);
			}
			if (GetEntityOfSingletonHolder<SSelectedLayoutPedestal>(out var result5) && Require<CSetting>(result5, out CSetting comp2))
			{
				if (!comp2.FixedSeed.IsSet && !SeedFixers.IsEmpty)
				{
					comp2.FixedSeed = SeedFixers.First<CSeededRunInfo>().FixedSeed;
				}
				else if (Has<CShowSeed>(result5))
				{
					base.EntityManager.AddComponentData(result2.Layout, default(CShowSeed));
				}
				base.EntityManager.AddComponentData(result2.Layout, comp2);
			}
			if (flag2)
			{
				base.EntityManager.GetBuffer<CStartingItem>(result2.Layout).Add(new CStartingItem
				{
					ID = num
				});
				if (!flag && GameData.Main.TryGet<Dish>(num, out var output) && !output.StartingNameSet.IsNullOrEmpty())
				{
					string text = output.StartingNameSet.Random();
					try
					{
						Set(result2.Layout, new CStartingName
						{
							Name = text
						});
					}
					catch (ArgumentException message)
					{
						Debug.LogError(message);
						Debug.LogError("Failed to rename restaurant " + text);
					}
				}
			}
			Preferences.TryGet<bool>(Pref.SpeedrunMode, out var value);
			if (!componentOfSingletonHolder && !value)
			{
				foreach (CItemHolder item in nativeArray)
				{
					if (HasComponent<CProvidesLoadoutItem>(item.HeldItem))
					{
						base.EntityManager.GetBuffer<CStartingItem>(result2.Layout).Add(new CStartingItem
						{
							ID = GetComponent<CProvidesLoadoutItem>(item.HeldItem).ID
						});
						base.EntityManager.DestroyEntity(item.HeldItem);
					}
				}
			}
			Entity entity2 = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponent<CPersistThroughSceneChanges>(entity2);
			base.EntityManager.AddComponentData(entity2, new CRequestSave
			{
				SaveType = SaveType.Auto
			});
			StartSceneTransition(SceneType.Kitchen);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLoadoutStatus_13 = GetEntityQuery(ComponentType.ReadOnly<SLoadoutStatus>());
			_SingletonEntityQuery_SFranchiseSelector_14 = GetEntityQuery(ComponentType.ReadOnly<SFranchiseSelector>());
		}
	}
}
