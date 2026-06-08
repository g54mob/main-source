using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class RequestKitchenUpdates : FranchiseSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SCurrentKitchen_6;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SFixedDishPedestal_7;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDishPedestal_8;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SDishPedestal>();
			RequireSingletonForUpdate<RebuildKitchen.SCurrentKitchen>();
		}

		protected override void OnUpdate()
		{
			int dish = _SingletonEntityQuery_SCurrentKitchen_6.GetSingleton<RebuildKitchen.SCurrentKitchen>().Dish;
			int num;
			int num2;
			if (HasSingleton<SFranchiseSelector>() && GetOrDefault<SFranchiseSelector>().SelectedFranchise != default(Entity))
			{
				num = (HasSingleton<SFixedDishPedestal>() ? 1 : 0);
				if (num != 0)
				{
					num2 = (Has<CHideView>(_SingletonEntityQuery_SFixedDishPedestal_7.GetSingletonEntity()) ? 1 : 0);
					goto IL_0085;
				}
			}
			else
			{
				num = 0;
			}
			num2 = 0;
			goto IL_0085;
			IL_0085:
			bool flag = (byte)num2 != 0;
			CDishChoice result;
			bool flag2 = GetComponentOfHeld<CDishChoice>(_SingletonEntityQuery_SFixedDishPedestal_7.GetSingletonEntity(), out result) && result.Dish != 0;
			if (!flag2)
			{
				flag2 = GetComponentOfHeld<CDishChoice>(_SingletonEntityQuery_SDishPedestal_8.GetSingletonEntity(), out var result2);
				result = result2;
			}
			if (num != 0 && (!flag || !flag2))
			{
				GetComponentOfHeld<CDishChoice>(_SingletonEntityQuery_SFixedDishPedestal_7.GetSingletonEntity(), out var result3);
				if (result3.Dish != dish)
				{
					base.EntityManager.AddComponentData(base.EntityManager.CreateEntity(), new RebuildKitchen.CRebuildKitchen
					{
						Dish = result3.Dish
					});
				}
				return;
			}
			int num3 = result.Dish;
			if (num3 == 0)
			{
				num3 = AssetReference.DishSteak;
			}
			if (num3 != dish)
			{
				base.EntityManager.AddComponentData(base.EntityManager.CreateEntity(), new RebuildKitchen.CRebuildKitchen
				{
					Dish = num3
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SCurrentKitchen_6 = GetEntityQuery(ComponentType.ReadOnly<RebuildKitchen.SCurrentKitchen>());
			_SingletonEntityQuery_SFixedDishPedestal_7 = GetEntityQuery(ComponentType.ReadOnly<SFixedDishPedestal>());
			_SingletonEntityQuery_SDishPedestal_8 = GetEntityQuery(ComponentType.ReadOnly<SDishPedestal>());
		}
	}
}
