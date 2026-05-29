using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class UI_BuyStockItem : UI_StockItem
	{
		protected override void OnEnabled()
		{
			base.OnEnabled();
			Stocks.BarStock.StockChanged += OnBarStockChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Stocks.BarStock.StockChanged -= OnBarStockChanged;
		}

		private void OnBarStockChanged(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData obj)
		{
			OnBasketChanged();
		}

		protected override string QualityToString(float quality)
		{
			return Mathf.FloorToInt(quality).ToString();
		}

		protected override BBTStock GetStock()
		{
			return Stocks.VendorStock;
		}

		protected override void SetCountText(int count)
		{
			if (count <= 0)
			{
				_refs.CountContainer.gameObject.SetActive(value: false);
				return;
			}
			_refs.CountContainer.gameObject.SetActive(value: true);
			if (count > 100000)
			{
				SetCountText("~");
			}
			else
			{
				SetCountText(count.ToString());
			}
		}
	}
}
