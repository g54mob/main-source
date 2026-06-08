using Kitchen.ShopBuilder;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class ShopEffectExtensions
	{
		public static void Apply(this ShopEffect effect, EntityContext ctx)
		{
			if (effect.AddStaple != null)
			{
				AddStaple(effect, ctx);
			}
			if (effect.BlueprintDeskAddition > 0)
			{
				BlueprintDeskAddition(effect, ctx);
			}
			if (effect.ExtraShopBlueprints != 0)
			{
				ExtraShopBlueprints(effect, ctx);
			}
			if (effect.ShopCostDecrease != 0f)
			{
				ShopCostDecrease(effect, ctx);
			}
			if (effect.RandomiseShopPrices)
			{
				RandomiseShopPrices(effect, ctx);
			}
			if (effect.ExtraStartingBlueprints > 0)
			{
				ExtraStartingBlueprints(effect, ctx);
			}
			if (effect.UpgradedShopChance > 0f)
			{
				UpgradedShopChance(effect, ctx);
			}
			if (effect.BlueprintRefreshChance > 0f)
			{
				BlueprintRefreshChance(effect, ctx);
			}
			if (effect.BlueprintRebuyableChance > 0f)
			{
				BlueprintRebuyableChance(effect, ctx);
			}
		}

		private static void AddStaple(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CShopStaple
			{
				Appliance = effect.AddStaple.ID
			});
		}

		private static void BlueprintDeskAddition(ShopEffect effect, EntityContext ctx)
		{
			for (int i = 0; i < effect.BlueprintDeskAddition; i++)
			{
				ctx.Add<CBlueprintGrantDuplicator>(ctx.CreateEntity());
			}
		}

		private static void ExtraStartingBlueprints(ShopEffect effect, EntityContext ctx)
		{
			for (int i = 0; i < effect.ExtraStartingBlueprints; i++)
			{
				Entity entity = ctx.CreateEntity();
				ctx.Set(entity, new CNewShop
				{
					Tags = (ShoppingTags.Technology | ShoppingTags.FrontOfHouse | ShoppingTags.Plumbing | ShoppingTags.Cooking | ShoppingTags.Automation | ShoppingTags.Misc | ShoppingTags.Office),
					IsFree = true
				});
			}
		}

		private static void ExtraShopBlueprints(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CRemovesShopBlueprint
			{
				Count = -effect.ExtraShopBlueprints
			});
		}

		private static void UpgradedShopChance(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CUpgradedShopChance
			{
				Chance = effect.UpgradedShopChance
			});
		}

		private static void ShopCostDecrease(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CGrantsShopDiscount
			{
				Amount = effect.ShopCostDecrease
			});
		}

		private static void RandomiseShopPrices(ShopEffect effect, EntityContext ctx)
		{
			ctx.Add<CRandomiseShopPrices>(ctx.CreateEntity());
		}

		private static void BlueprintRefreshChance(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CBlueprintRefreshChance
			{
				Chance = effect.BlueprintRefreshChance
			});
		}

		private static void BlueprintRebuyableChance(ShopEffect effect, EntityContext ctx)
		{
			ctx.Set(ctx.CreateEntity(), new CBlueprintRebuyableChance
			{
				Chance = effect.BlueprintRebuyableChance
			});
		}
	}
}
