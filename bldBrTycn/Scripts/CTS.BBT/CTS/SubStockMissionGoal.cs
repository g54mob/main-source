using System;
using CTS.BBT;

namespace CTS
{
	public class SubStockMissionGoal : BaseSpecificStockItemNumericGoal
	{
		private readonly MissionBasket _basket;

		public SubStockMissionGoal(Quest quest, int entryID, string variableName, string targetVariableName, MissionBasket basket, StockItemSO targetStockItem)
			: base(quest, entryID, variableName, targetVariableName, targetStockItem)
		{
			_basket = basket;
		}

		public override void StopObserving()
		{
			_basket.BasketValidated -= OnBasketValidated;
		}

		public override void StartObserving()
		{
			_basket.BasketValidated += OnBasketValidated;
		}

		private void OnBasketValidated(ShopBasket.BasketValidation basket)
		{
			ReadOnlySpan<StockStack>.Enumerator enumerator = basket.GetEnumerator();
			while (enumerator.MoveNext())
			{
				StockStack current = enumerator.Current;
				if (current.ItemData == base.TargetStockItem)
				{
					AddToGoalVariable(current.StackCount);
					break;
				}
			}
		}
	}
}
