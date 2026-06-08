using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class SetDishPedestalOverride : FranchiseSystem
	{
		protected override void OnUpdate()
		{
			EntityContext entityContext = new EntityContext(base.EntityManager);
			if (!entityContext.Has<SDishPedestal>() || !entityContext.Has<SFixedDishPedestal>() || !entityContext.Has<SLayoutPedestal>())
			{
				return;
			}
			Entity entity = entityContext.GetEntity<SFixedDishPedestal>();
			Entity entity2 = entityContext.GetEntity<SDishPedestal>();
			Entity entity3 = entityContext.GetEntity<SLayoutPedestal>();
			if (!entityContext.Require<CItemHolder>(entity3, out var comp) || !entityContext.Require<CItemHolder>(entity2, out var comp2))
			{
				return;
			}
			SFranchiseSelector orCreate = GetOrCreate<SFranchiseSelector>();
			Entity selectedFranchise = orCreate.SelectedFranchise;
			CSpeedrun comp3;
			bool flag = Require<CSpeedrun>(comp.HeldItem, out comp3);
			CSettingDish comp4;
			bool flag2 = Require<CSettingDish>(comp.HeldItem, out comp4);
			CFranchiseItem comp5;
			bool flag3 = Require<CFranchiseItem>(selectedFranchise, out comp5);
			bool flag4 = (flag3 && !orCreate.RequiresAdditionalBase) || flag || flag2;
			int num = 0;
			if (flag3 && !orCreate.RequiresAdditionalBase)
			{
				for (int num2 = comp5.Cards.Count - 1; num2 >= 0; num2--)
				{
					int id = comp5.Cards[num2];
					if (GameData.Main.TryGet<Unlock>(id, out var output) && output is Dish { Type: DishType.Base } dish)
					{
						num = dish.ID;
						break;
					}
				}
				if (flag2 && num == comp4.DishID)
				{
					flag2 = false;
				}
			}
			entityContext.Ensure<CHideView>(entity2, flag4);
			entityContext.Ensure<CPreventItemTransfer>(entity2, flag4);
			entityContext.Ensure<CHideView>(entity, !flag4);
			if ((flag || flag2) && flag3 && orCreate.SelectedFranchise != Entity.Null)
			{
				orCreate.SelectedFranchise = Entity.Null;
				orCreate.SelectedIndex = 0;
				entityContext.Ensure(orCreate);
			}
			int num3 = 0;
			FixedDishReason reason = FixedDishReason.None;
			if (flag)
			{
				num3 = comp3.DishID;
				reason = FixedDishReason.Speedrun;
			}
			else if (flag2)
			{
				num3 = comp4.DishID;
				reason = FixedDishReason.Setting;
			}
			else if (num != 0)
			{
				num3 = num;
				reason = FixedDishReason.Franchise;
			}
			CItemHolder cItemHolder = entityContext.Get<CItemHolder>(entity);
			if (cItemHolder.HeldItem != Entity.Null)
			{
				if (GetComponent<CDishChoice>(cItemHolder.HeldItem).Dish == num3)
				{
					return;
				}
				entityContext.Destroy(cItemHolder.HeldItem);
				if (comp2.HeldItem != Entity.Null)
				{
					HolderHelpers.GoHome(base.EntityManager, comp2.HeldItem);
				}
			}
			Entity entity4 = base.EntityManager.CreateEntity(typeof(CCreateItem), typeof(RebuildKitchen.CNonKitchen), typeof(CHeldBy));
			entityContext.Set(entity4, (CCreateItem)AssetReference.DishPaper);
			entityContext.Set(entity4, (CHeldBy)entity);
			entityContext.Set(entity, (CItemHolder)entity4);
			entityContext.Set(entity4, new CDishChoice
			{
				Dish = num3,
				Reason = reason
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
