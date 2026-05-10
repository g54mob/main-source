using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Base Stock")]
	public class LevelSettingBaseStock : LevelSetting
	{
		[SerializeField]
		private StockDeliveryData _stockData;

		public override void Apply()
		{
			BBTStock barStock = Stocks.BarStock;
			barStock.ClearInventory();
			StockItemSO[] items = _stockData.Deliverables.Items;
			foreach (StockItemSO stockItemSO in items)
			{
				if (!(stockItemSO == null))
				{
					barStock.ForceAdd(stackToAdd: new StockStack(stockItemSO, _stockData.GetAmount(stockItemSO), _stockData.GetQuality(stockItemSO)), stockType: stockItemSO.StockType);
				}
			}
		}
	}
}
