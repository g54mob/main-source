using CTS.BBT;

namespace CTS
{
	public abstract class BaseSpecificStockItemNumericGoal : QuestNumericGoal
	{
		protected StockItemSO TargetStockItem { get; private set; }

		public BaseSpecificStockItemNumericGoal(Quest quest, int entryID, string variableName, string targetVariableName, StockItemSO targetStockItem)
			: base(quest, entryID, variableName, targetVariableName)
		{
			TargetStockItem = targetStockItem;
		}
	}
}
