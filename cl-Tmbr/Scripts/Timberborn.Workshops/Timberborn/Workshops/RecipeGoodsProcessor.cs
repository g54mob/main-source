using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.Goods;
using UnityEngine;

namespace Timberborn.Workshops
{
	public class RecipeGoodsProcessor
	{
		private readonly IGoodService _goodService;

		private readonly RecipeSpecService _recipeSpecService;

		public RecipeGoodsProcessor(IGoodService goodService, RecipeSpecService recipeSpecService)
		{
			_goodService = goodService;
			_recipeSpecService = recipeSpecService;
		}

		public Dictionary<StorableGood, int> ProcessRecipes(IEnumerable<string> recipeIds, int capacityMultiplier = 1)
		{
			Dictionary<StorableGood, int> dictionary = new Dictionary<StorableGood, int>();
			foreach (string recipeId in recipeIds)
			{
				RecipeSpec recipe = _recipeSpecService.GetRecipe(recipeId);
				if (recipe.Blueprint.IsAllowedByFeatureToggles())
				{
					ProcessRecipe(recipe, dictionary, capacityMultiplier);
				}
			}
			return dictionary;
		}

		private void ProcessRecipe(RecipeSpec productionRecipe, Dictionary<StorableGood, int> goods, int capacityMultiplier = 1)
		{
			CheckRecipeGoods(productionRecipe);
			if (productionRecipe.ConsumesIngredients)
			{
				ImmutableArray<GoodAmountSpec>.Enumerator enumerator = productionRecipe.Ingredients.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GoodAmountSpec current = enumerator.Current;
					StorableGood storableGood = StorableGood.CreateAsGivable(current.Id);
					int capacity = productionRecipe.GetCapacity(current.ToGoodAmount());
					IncreaseAmount(goods, storableGood, capacity * capacityMultiplier);
				}
			}
			if (productionRecipe.ConsumesFuel)
			{
				StorableGood storableGood2 = StorableGood.CreateAsGivable(productionRecipe.Fuel);
				IncreaseAmount(goods, storableGood2, productionRecipe.FuelCapacity * capacityMultiplier);
			}
			if (productionRecipe.ProducesProducts)
			{
				ImmutableArray<GoodAmountSpec>.Enumerator enumerator = productionRecipe.Products.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GoodAmountSpec current2 = enumerator.Current;
					StorableGood storableGood3 = StorableGood.CreateAsTakeable(current2.Id);
					int capacity2 = productionRecipe.GetCapacity(current2.ToGoodAmount());
					IncreaseAmount(goods, storableGood3, capacity2 * capacityMultiplier);
				}
			}
		}

		private void CheckRecipeGoods(RecipeSpec recipeSpec)
		{
			string id = recipeSpec.Id;
			ValidateGoods(recipeSpec.Ingredients, id, "Ingredients");
			ValidateGoods(recipeSpec.Products, id, "Products");
			string fuel = recipeSpec.Fuel;
			if (!string.IsNullOrEmpty(fuel))
			{
				ValidateGood(fuel, id, "Fuel");
			}
		}

		private void ValidateGoods(IEnumerable<GoodAmountSpec> goods, string recipeId, string type)
		{
			foreach (GoodAmountSpec good in goods)
			{
				ValidateGood(good.Id, recipeId, type);
			}
		}

		private void ValidateGood(string goodId, string recipeId, string type)
		{
			if (!_goodService.HasGood(goodId))
			{
				Debug.LogWarning("Good " + goodId + " for " + type + " in recipe " + recipeId + " not found");
			}
		}

		private static void IncreaseAmount(IDictionary<StorableGood, int> goods, StorableGood storableGood, int amount)
		{
			if (!goods.ContainsKey(storableGood) || goods[storableGood] < amount)
			{
				goods[storableGood] = amount;
			}
		}
	}
}
