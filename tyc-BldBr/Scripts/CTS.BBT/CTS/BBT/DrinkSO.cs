using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	[CreateAssetMenu(fileName = "New Drink", menuName = "BBT/Drinks/Drink Data")]
	public class DrinkSO : ScriptableObject
	{
		public string Name;

		[Range(0f, 1f)]
		public float ThirstPercent;

		public bool CanBeServedAtPump = true;

		private static List<StockStack> _tempStacks = new List<StockStack>();

		[field: SerializeField]
		public DrinkMesh FullMeshPrefab { get; private set; }

		[field: SerializeField]
		public DrinkMesh EmptyMeshPrefab { get; private set; }

		[field: SerializeField]
		[field: Range(0f, 100f)]
		public int AlcoholValue { get; private set; }

		[field: SerializeField]
		public float PriceModifier { get; private set; } = 1f;

		[field: SerializeField]
		public Recipe Recipe { get; private set; }

		[field: SerializeField]
		[field: ShowAssetPreview(64, 64)]
		public Sprite Icon { get; protected set; }

		public int GetCurrentPrice()
		{
			int num = 0;
			foreach (RecipeIngredient ingredient in Recipe.Ingredients)
			{
				num += ingredient.ScriptableObject.GetCurrentPrice();
			}
			return Mathf.FloorToInt((float)num * PriceModifier);
		}

		public bool TryGetIngredients(List<StockStack> stockStacks)
		{
			stockStacks.Clear();
			if (!Stocks.CVarDrinksRequireStock.GetCurrentValue())
			{
				return true;
			}
			foreach (RecipeIngredient ingredient in Recipe.Ingredients)
			{
				if (!Stocks.BarStock.RetrieveStock(ingredient.ScriptableObject, ingredient.Count, _tempStacks))
				{
					foreach (StockStack stockStack in stockStacks)
					{
						Stocks.ForceAdd(stockStack);
					}
					stockStacks.Clear();
					return false;
				}
				stockStacks.AddRange(_tempStacks);
			}
			return true;
		}

		public void ImportData(DrinkImportData data)
		{
			ThirstPercent = data.ThirstPercent;
			AlcoholValue = data.AlcoholValue;
			PriceModifier = data.PriceModifier;
		}
	}
}
