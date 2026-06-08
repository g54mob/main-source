using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateNewKitchen : GenericSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SKitchenFirstFrame : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCreateScene_29;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SSceneData_30;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SCreateScene>();
		}

		protected override void OnUpdate()
		{
			if (_SingletonEntityQuery_SCreateScene_29.GetSingleton<SCreateScene>().Type != SceneType.Kitchen)
			{
				return;
			}
			EntityManager entityManager = base.EntityManager;
			Entity singletonEntity = _SingletonEntityQuery_SSceneData_30.GetSingletonEntity();
			base.EntityManager.AddComponent<SKitchenLayout>(singletonEntity);
			MarkTransitionStageCompleted();
			Entity entity = entityManager.CreateEntity(typeof(SKitchenMarker), typeof(SGameplayMarker));
			entityManager.AddComponent<SKitchenFirstFrame>(entity);
			GetCommandBuffer(ECB.End).RemoveComponent<SKitchenFirstFrame>(entity);
			base.EntityManager.CreateEntity(typeof(SIsNightTime));
			base.EntityManager.CreateEntity(typeof(SIsNightFirstUpdate));
			if (!entityManager.HasComponent<CLayoutRoomTile>(singletonEntity))
			{
				entityManager.AddBuffer<CLayoutRoomTile>(singletonEntity);
			}
			Entity entity2 = entityManager.CreateEntity();
			entityManager.AddComponentData(entity2, new CLayoutView
			{
				Layout = singletonEntity
			});
			entityManager.AddComponentData(entity2, (CPosition)Vector3.zero);
			entityManager.AddComponentData(entity2, (CRequiresView)ViewType.Floorplan);
			entityManager.AddComponent<SLayout>(singletonEntity);
			entityManager.AddBuffer<CLayoutOccupant>(singletonEntity);
			if (entityManager.HasComponent<CLayoutAppliancePlacement>(singletonEntity))
			{
				NativeArray<CLayoutAppliancePlacement> nativeArray = GetBuffer<CLayoutAppliancePlacement>(singletonEntity).ToNativeArray(Allocator.Temp);
				foreach (CLayoutAppliancePlacement item in nativeArray)
				{
					Entity entity3 = entityManager.CreateEntity();
					entityManager.AddComponentData(entity3, new CCreateAppliance
					{
						ID = item.Appliance
					});
					entityManager.AddComponentData(entity3, new CPosition(item.Position, item.Rotation));
					base.TileManager.SetOccupant(item.Position, entity3);
				}
				nativeArray.Dispose();
			}
			Bounds bounds = (HasComponent<CBounds>(singletonEntity) ? GetComponent<CBounds>(singletonEntity).Bounds : default(Bounds));
			bounds.Expand(1f);
			AddBoundPoint(bounds.center + new Vector3(bounds.extents.x + 1f, 0f, bounds.extents.z + 0.5f));
			AddBoundPoint(bounds.center + new Vector3(bounds.extents.x + 1f, 0f, 0f - bounds.extents.z - 1f));
			AddBoundPoint(bounds.center + new Vector3(0f - bounds.extents.x - 1f, 0f, bounds.extents.z + 0.5f));
			AddBoundPoint(bounds.center + new Vector3(0f - bounds.extents.x - 1f, 0f, 0f - bounds.extents.z - 1f));
			AddNewView<CTimeDisplay>(ViewType.TimeDisplay, new Vector3(0.5f, 1f, 0f));
			AddNewView<CDayDisplay>(ViewType.DayDisplay, new Vector3(1f, 1f, 0f));
			AddNewView<CMoneyDisplay>(ViewType.MoneyDisplay, new Vector3(0f, 1f, 0f));
			AddNewView<CParametersDisplay>(ViewType.ParametersDisplay, new Vector3(0f, 1f, 0f));
			Entity entity4 = base.EntityManager.CreateEntity(typeof(SWeatherPrecipitation), typeof(CRequiresView), typeof(CPosition));
			base.EntityManager.SetComponentData(entity4, new CRequiresView
			{
				Type = ViewType.Weather
			});
			if (Require<CSetting>(singletonEntity, out CSetting comp))
			{
				RestaurantSetting restaurantSetting = base.Data.Get<RestaurantSetting>(comp.RestaurantSetting);
				base.EntityManager.SetComponentData(entity4, new SWeatherPrecipitation
				{
					Mode = restaurantSetting.WeatherMode
				});
				if (comp.FixedSeed.IsSet)
				{
					Set(new SFixedSeed
					{
						Seed = comp.FixedSeed
					});
				}
				else
				{
					Set(new SFixedSeed
					{
						Seed = Seed.Generate(Random.Range(-100000, 100000))
					});
				}
			}
			else
			{
				Set(new SFixedSeed
				{
					Seed = Seed.Generate(Random.Range(-100000, 100000))
				});
				base.EntityManager.SetComponentData(entity4, new SWeatherPrecipitation
				{
					Mode = WeatherMode.None
				});
			}
		}

		private void AddBoundPoint(Vector3 p)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CRequiresView), typeof(CMaintainInView), typeof(CPosition));
			entityManager.SetComponentData(entity, new CRequiresView
			{
				Type = ViewType.Marker
			});
			entityManager.SetComponentData(entity, new CPosition(p));
		}

		private void AddNewView<T>(ViewType view, Vector3 pos) where T : IComponentData
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity();
			entityManager.AddComponent<T>(entity);
			entityManager.AddComponentData(entity, (CPosition)pos);
			entityManager.AddComponentData(entity, new CRequiresView
			{
				Type = view,
				ViewMode = ViewMode.Screen
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCreateScene_29 = GetEntityQuery(ComponentType.ReadOnly<SCreateScene>());
			_SingletonEntityQuery_SSceneData_30 = GetEntityQuery(ComponentType.ReadOnly<SSceneData>());
		}
	}
}
