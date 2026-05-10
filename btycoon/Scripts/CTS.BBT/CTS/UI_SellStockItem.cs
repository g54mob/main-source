using System;
using UnityEngine;

namespace CTS
{
	public class UI_SellStockItem : UI_StockItem
	{
		protected override string QualityToString(float quality)
		{
			float num = (float)Math.Round(quality, 1);
			if (Mathf.Approximately(num - (float)Mathf.RoundToInt(quality), 0f))
			{
				return num.ToString("N0");
			}
			return num.ToString("N1");
		}

		protected override BBTStock GetStock()
		{
			return Stocks.BarStock;
		}

		protected override int GetUnitPrice(float quality)
		{
			return Mathf.FloorToInt((float)base.GetUnitPrice(quality) * _itemData.SellPriceMultiplier);
		}
	}
}
