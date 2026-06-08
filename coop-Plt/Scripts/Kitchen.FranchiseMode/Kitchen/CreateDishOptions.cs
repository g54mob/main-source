using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateOffice))]
	public class CreateDishOptions : FranchiseFirstFrameSystem
	{
		private EntityQuery DishUpgrades;

		private EntityQuery DishSizeUpgrades;

		private EntityQuery DishCabinetUpgrades;

		protected override void Initialise()
		{
			base.Initialise();
			DishUpgrades = GetEntityQuery(typeof(CDishUpgrade));
			DishSizeUpgrades = GetEntityQuery(typeof(CUpgradeExtraDish));
			DishCabinetUpgrades = GetEntityQuery(typeof(CUpgradeDishCabinet));
		}

		protected override void OnUpdate()
		{
			if (PlatformSettings.DebugQuickLoadLobby)
			{
				return;
			}
			bool flag = !DishCabinetUpgrades.IsEmpty;
			bool isDemoMode = PlatformSettings.IsDemoMode;
			Vector3 office = LobbyPositionAnchors.Office;
			List<Vector3> list = new List<Vector3>
			{
				new Vector3(2f, 0f, -5f),
				new Vector3(3f, 0f, -5f),
				new Vector3(4f, 0f, -5f),
				new Vector3(1f, 0f, -5f)
			};
			Vector3 vector = new Vector3(4f, 0f, -3f);
			if (!flag)
			{
				list.Add(new Vector3(4f, 0f, -3f));
				list.Add(new Vector3(4f, 0f, -4f));
			}
			NativeArray<CDishUpgrade> nativeArray = DishUpgrades.ToComponentDataArray<CDishUpgrade>(Allocator.Temp);
			int demo_dish = AssetReference.DishSteak;
			int demo_dish2 = AssetReference.DishStirFry;
			List<CDishUpgrade> list2;
			if (isDemoMode)
			{
				list2 = new List<CDishUpgrade>
				{
					new CDishUpgrade
					{
						DishID = demo_dish
					}
				};
				if (nativeArray.Any((CDishUpgrade d) => d.DishID == demo_dish2))
				{
					list2.Add(new CDishUpgrade
					{
						DishID = demo_dish2
					});
				}
				list2.AddRange(from d in nativeArray.ToList().Shuffle()
					where d.DishID != demo_dish && d.DishID != demo_dish2
					select d);
			}
			else
			{
				list2 = nativeArray.ToList().Shuffle();
			}
			if (!isDemoMode && flag)
			{
				CreateCabinet(office + vector);
			}
			int num = 0;
			if (AssetReference.AlwaysAvailableDish != 0)
			{
				list2 = list2.Where((CDishUpgrade x) => x.DishID != AssetReference.AlwaysAvailableDish).ToList();
				CreateFoodSource(office + list[num], base.Data.Get<Dish>(AssetReference.AlwaysAvailableDish));
				num++;
			}
			for (; num < Mathf.Min(list.Count, 1 + DishSizeUpgrades.CalculateEntityCount()); num++)
			{
				Dish output;
				if (isDemoMode)
				{
					CreateFoodSource(office + list[num], (num < list2.Count()) ? base.Data.Get<Dish>(list2[num].DishID) : null, num != 0 && list2[num].DishID != demo_dish2);
				}
				else if (num < list2.Count && base.Data.TryGet<Dish>(list2[num].DishID, out output, warn_if_fail: true))
				{
					CreateFoodSource(office + list[num], (num < list2.Count()) ? output : null);
				}
			}
		}

		private void CreateCabinet(Vector3 location)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CDishSource), typeof(CItemHolder));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.DishCabinet
			});
			entityManager.SetComponentData(entity, new CPosition(location));
		}

		private void CreateFoodSource(Vector3 location, Dish dish, bool demo_lock = false)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CDishSource), typeof(CItemHolder));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.DishPedestal
			});
			entityManager.SetComponentData(entity, new CPosition(location));
			if (dish != null)
			{
				Entity entity2 = entityManager.CreateEntity(typeof(CCreateItem), typeof(CHeldBy), typeof(CHome));
				entityManager.SetComponentData(entity2, new CCreateItem
				{
					ID = AssetReference.DishPaper
				});
				entityManager.SetComponentData(entity2, new CHeldBy
				{
					Holder = entity
				});
				entityManager.SetComponentData(entity, new CItemHolder
				{
					HeldItem = entity2
				});
				entityManager.SetComponentData(entity2, (CHome)entity);
				if (demo_lock)
				{
					entityManager.AddComponent(entity2, typeof(CDemoLock));
				}
				entityManager.AddComponentData(entity2, new CDishChoice
				{
					Dish = dish.ID
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
