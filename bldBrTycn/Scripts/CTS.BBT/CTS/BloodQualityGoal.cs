using CTS.BBT;
using CTS.StockInventory;

namespace CTS
{
	public class BloodQualityGoal : BaseSpecificStockItemNumericGoal
	{
		public BloodQualityGoal(Quest quest, int entryID, string variableName, string targetVariableName, StockItemSO targetStockItem)
			: base(quest, entryID, variableName, targetVariableName, targetStockItem)
		{
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
				SetGoalVariable(peekedStack.Quality);
			}
		}
	}
}
