using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class PostHelpers
	{
		public static Entity CreateBlueprintLetter(EntityContext ctx, CPosition position, CLetterBlueprint letter)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CCreateAppliance
			{
				ID = letter.BlueprintID
			});
			ctx.Set(entity, new CPosition(position));
			ctx.Set(entity, new CApplianceBlueprint
			{
				Appliance = letter.ApplianceID
			});
			if (!Preferences.Get<bool>(Pref.RequirePingForBlueprintInfo))
			{
				ctx.Set(entity, new CShowApplianceInfo
				{
					Appliance = letter.ApplianceID,
					Price = letter.Price,
					ShowPrice = true
				});
			}
			ctx.Set(entity, new CForSale
			{
				Price = letter.Price
			});
			ctx.Set(entity, default(CShopEntity));
			return entity;
		}

		public static Entity OpenBlueprintLetter(EntityContext ctx, Entity letter_ent)
		{
			if (!ctx.Require<CLetterBlueprint>(letter_ent, out var comp))
			{
				return default(Entity);
			}
			if (!ctx.Require<CPosition>(letter_ent, out var comp2))
			{
				return default(Entity);
			}
			return CreateBlueprintLetter(ctx, comp2, comp);
		}

		public static Entity CreateOpenedLetter(EntityContext ctx, Vector3 position, int appliance_id, float price_multiplier = 1f, int force_price = -1)
		{
			int num = 0;
			Appliance output;
			if (force_price >= 0)
			{
				num = force_price;
			}
			else if (GameData.Main.TryGet<Appliance>(appliance_id, out output, warn_if_fail: true))
			{
				num = output.PurchaseCost;
			}
			return CreateBlueprintLetter(ctx, position, new CLetterBlueprint
			{
				BlueprintID = AssetReference.Blueprint,
				ApplianceID = appliance_id,
				Price = Mathf.CeilToInt((float)num * price_multiplier)
			});
		}

		public static Entity CreateBlueprintLetter(EntityManager em, Vector3 position, int appliance_id, float price_multiplier = 1f, int force_price = -1, bool use_red = false)
		{
			Entity entity = em.CreateEntity();
			em.AddComponentData(entity, new CCreateAppliance
			{
				ID = (use_red ? (-707206359) : 1553046198)
			});
			em.AddComponentData(entity, new CPosition(position));
			em.AddComponentData(entity, default(CLetter));
			int num = 0;
			Appliance output;
			if (force_price >= 0)
			{
				num = force_price;
			}
			else if (GameData.Main.TryGet<Appliance>(appliance_id, out output, warn_if_fail: true))
			{
				num = output.PurchaseCost;
			}
			em.AddComponentData(entity, new CLetterBlueprint
			{
				BlueprintID = AssetReference.Blueprint,
				ApplianceID = appliance_id,
				Price = Mathf.CeilToInt((float)num * price_multiplier)
			});
			em.AddComponentData(entity, default(CShopEntity));
			return entity;
		}

		public static Entity CreateApplianceParcel(EntityManager em, Vector3 position, int appliance_id)
		{
			Entity entity = em.CreateEntity();
			em.AddComponentData(entity, new CCreateAppliance
			{
				ID = -1936421857
			});
			em.AddComponentData(entity, new CPosition(position));
			em.AddComponentData(entity, default(CLetter));
			em.AddComponentData(entity, default(CPreventStartDayPost));
			em.AddComponentData(entity, new CLetterAppliance
			{
				ApplianceID = appliance_id
			});
			return entity;
		}

		public static Entity CreateIngredientParcel(EntityContext ctx, Vector3 position, int ingredient_id)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CCreateAppliance
			{
				ID = -1936421857
			});
			ctx.Set(entity, new CPosition(position));
			ctx.Set(entity, default(CLetter));
			ctx.Set(entity, default(CPreventStartDayPost));
			ctx.Set(entity, new CLetterIngredient
			{
				IngredientID = ingredient_id
			});
			return entity;
		}
	}
}
