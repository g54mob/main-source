using System;
using System.Collections.Generic;

namespace UI
{
	[Serializable]
	public class ShopData
	{
		public eShopId id;

		public int purchasesCount;

		public eShopType type { get; set; }

		public string title { get; set; }

		public string desc { get; set; }

		public List<int> prices { get; set; }

		public bool unlock { get; set; }

		public int limit { get; set; }

		public eUpgradeKind shopEffectKind1 { get; set; }

		public List<string> param1 { get; set; }

		public eUpgradeKind shopEffectKind2 { get; set; }

		public List<string> param2 { get; set; }

		public eShopId updateShopId { get; set; }

		public eArchiveCategory archiveCategory { get; set; }

		public string archiveId { get; set; }

		public int Currency => 0;

		public bool ValidLimit => false;

		public ShopData(MstShopDataEntities mstData)
		{
		}

		public void SetData()
		{
		}

		public int GetPrice()
		{
			return 0;
		}

		public bool ValidPurchase()
		{
			return false;
		}
	}
}
