using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class TraderStockContent : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<TraderStockItem> stockItems = new List<TraderStockItem>();

		public List<TraderStockItem> StockItems => stockItems;

		public override string GetID()
		{
			return id;
		}

		public bool Contains(TradeResource tradeResource)
		{
			return stockItems.Any((TraderStockItem item) => item.Contains(tradeResource));
		}
	}
}
