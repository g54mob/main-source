using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Sirenix.Utilities;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerCreationGroup))]
	public class CreateCustomerGroup : DaySystem
	{
		private EntityQuery ScheduledCustomers;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_STime_0;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			STime singleton = _SingletonEntityQuery_STime_0.GetSingleton<STime>();
			NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);
			NativeArray<CScheduledCustomer> nativeArray2 = ScheduledCustomers.ToComponentDataArray<CScheduledCustomer>(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				Entity entity = nativeArray[i];
				CScheduledCustomer cScheduledCustomer = nativeArray2[i];
				if (singleton.TimeOfDayUnbounded > cScheduledCustomer.TimeOfDay)
				{
					CCustomerType comp;
					int id = (Require<CCustomerType>(entity, out comp) ? comp.Type : 0);
					if (GameData.Main.TryGet<CustomerType>(id, out var output))
					{
						NewGroup(output, cScheduledCustomer.GroupSize, cScheduledCustomer.IsCat);
					}
					base.EntityManager.DestroyEntity(entity);
				}
			}
			nativeArray.Dispose();
			nativeArray2.Dispose();
		}

		public Entity NewGroup(CustomerType type_data, int customer_count, bool is_cat)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CCustomerGroup), typeof(CPosition), typeof(CPatience), typeof(CCustomerSettings), typeof(CGroupArrive), typeof(CGroupMealPhase), typeof(CGroupReward), typeof(CGroupMember), typeof(CCustomerType));
			base.EntityManager.SetComponentData(entity, new CGroupMealPhase
			{
				Phase = MenuPhase.Starter
			});
			base.EntityManager.SetComponentData(entity, new CCustomerType(type_data.ID));
			base.EntityManager.SetComponentData(entity, new CPatience(PatienceReason.Seating));
			PatienceValues patienceValues = PatienceValues.Default.ApplyModifiers(type_data.PatienceModifiers, 0f);
			OrderingValues orderingValues = OrderingValues.Default.ApplyModifiers(type_data.OrderingModifiers, 0f);
			base.EntityManager.SetComponentData(entity, new CCustomerSettings
			{
				BasePatience = patienceValues,
				Patience = patienceValues,
				BaseOrdering = orderingValues,
				Ordering = orderingValues
			});
			for (int i = 0; i < customer_count; i++)
			{
				Entity entity2 = NewCustomer(entity, is_cat, type_data, i);
				base.EntityManager.GetBuffer<CGroupMember>(entity).Add(entity2);
			}
			return entity;
		}

		protected Entity NewCustomer(Entity group, bool is_cat, CustomerType type, int index)
		{
			ViewType type2 = (is_cat ? ViewType.CustomerCat : ViewType.Customer);
			Entity entity = base.EntityManager.CreateEntity(typeof(CCustomer), typeof(CPlayerCosmetics), typeof(CCustomerState), typeof(CBelongsToGroup), typeof(CPosition), typeof(CRequiresView), typeof(CCustomerType));
			base.EntityManager.SetComponentData(entity, new CCustomer
			{
				Scale = 1f,
				Speed = 1f
			});
			base.EntityManager.SetComponentData(entity, new CCustomerType(type.ID));
			bool flag = false;
			if (!type.Cosmetics.IsNullOrEmpty())
			{
				flag = true;
				base.EntityManager.SetComponentData(entity, new CPlayerCosmetics
				{
					Cosmetics = new DataObjectList(type.Cosmetics.Random().ID)
				});
			}
			if (!flag && RequireEntity<SLayout>(out var comp) && Require<CSetting>(comp, out CSetting setting))
			{
				List<PlayerCosmetic> list = (from c in base.Data.Get<PlayerCosmetic>()
					where c.CosmeticType == CosmeticType.Hat && c.CustomerSettings.Select((RestaurantSetting r) => r.ID).Contains(setting.RestaurantSetting)
					select c).ToList();
				if (list.Count > 0)
				{
					flag = true;
					base.EntityManager.SetComponentData(entity, new CPlayerCosmetics
					{
						Cosmetics = new DataObjectList(list.Random().ID)
					});
				}
			}
			base.EntityManager.SetComponentData(entity, new CCustomerState
			{
				CurrentState = CCustomerState.State.Normal
			});
			base.EntityManager.SetComponentData(entity, new CBelongsToGroup
			{
				Group = group,
				IndexInGroup = index
			});
			if (!is_cat)
			{
				base.EntityManager.AddComponent<TwitchNameList.CAssignName>(entity);
			}
			float x = base.Bounds.min.x;
			base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(x - 10f + (float)Random.Range(-3, 3), 0f, -6 + Random.Range(-1, 1))));
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				Type = type2,
				PhysicsDriven = true
			});
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STime_0 = GetEntityQuery(ComponentType.ReadOnly<STime>());
		}
	}
}
