using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Goods;
using Timberborn.InventorySystem;

namespace Timberborn.Workshops
{
	internal class RecipeGoodDisallower : BaseComponent, IAwakableComponent, IGoodDisallower, IFinishedStateListener
	{
		private readonly Dictionary<string, int> _limits = new Dictionary<string, int>();

		public event EventHandler<DisallowedGoodsChangedEventArgs> DisallowedGoodsChanged;

		public void Awake()
		{
			DisableComponent();
		}

		public int AllowedAmount(string goodId)
		{
			if (!_limits.TryGetValue(goodId, out var value))
			{
				return 0;
			}
			return value;
		}

		public void UpdateAllowedAmounts(RecipeSpec recipeSpec)
		{
			ResetLimits();
			if (recipeSpec != null)
			{
				SetLimitsForRecipe(recipeSpec);
			}
			foreach (string key in _limits.Keys)
			{
				this.DisallowedGoodsChanged?.Invoke(this, new DisallowedGoodsChangedEventArgs(key));
			}
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
		}

		private void ResetLimits()
		{
			foreach (string item in _limits.Keys.ToList())
			{
				_limits[item] = 0;
			}
		}

		private void SetLimitsForRecipe(RecipeSpec recipeSpec)
		{
			ImmutableArray<GoodAmountSpec>.Enumerator enumerator = recipeSpec.Ingredients.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GoodAmountSpec current = enumerator.Current;
				_limits[current.Id] = recipeSpec.GetCapacity(current.ToGoodAmount());
			}
			enumerator = recipeSpec.Products.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GoodAmountSpec current2 = enumerator.Current;
				_limits[current2.Id] = recipeSpec.GetCapacity(current2.ToGoodAmount());
			}
			if (recipeSpec.ConsumesFuel)
			{
				_limits[recipeSpec.Fuel] = recipeSpec.FuelCapacity;
			}
		}
	}
}
