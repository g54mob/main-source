using CTS.BBT;
using CTS.StockInventory;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class StockAmountQualityGoal : BaseSpecificStockItemNumericGoal
	{
		private string _targetQuality;

		public StockAmountQualityGoal(Quest quest, int entryID, string variableName, string targetVariableName, string targetQuality, StockItemSO targetStockItem)
			: base(quest, entryID, variableName, targetVariableName, targetStockItem)
		{
			_targetQuality = targetQuality;
		}

		public override void StopObserving()
		{
			Stocks.BarStock.UnregisterToStockChange(base.TargetStockItem, OnBloodStockChange);
		}

		public override void StartObserving()
		{
			Stocks.BarStock.RegisterToStockChange(base.TargetStockItem, OnBloodStockChange);
			OnBloodStockChange(default(StockInventory<StockStack, StockItemSO>.StockItemChangedData));
		}

		private void OnBloodStockChange(StockInventory<StockStack, StockItemSO>.StockItemChangedData data)
		{
			if (Stocks.BarStock.TryPeekFirst(base.TargetStockItem.StockType, base.TargetStockItem, out var peekedStack))
			{
				if (peekedStack.Quality < (float)DialogueLua.GetVariable(_targetQuality).asInt)
				{
					SetGoalVariable(0);
				}
				else
				{
					SetGoalVariable(peekedStack.StackCount);
				}
			}
		}
	}
}
