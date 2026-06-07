using System.Collections.Generic;
using SaveData;

namespace UI
{
	public class OutGameShopData
	{
		public eOutGameShopId id;

		public string title;

		public string desc;

		public int price;

		public bool unlock;

		public eUpgradeKind shopEffectKind1;

		public List<string> param1;

		public eUpgradeKind shopEffectKind2;

		public List<string> param2;

		public eUpgradeKind shopEffectKind3;

		public List<string> param3;

		public eOutGameShopId updateId;

		public string iconPath;

		public bool purchase;

		public bool switchEnable;

		public bool enable;

		public bool isConsumption;

		public OutGameShopData(MstOutGameShopEntities mstData, OutGameShopUnlockData unlockData)
		{
		}

		public OutGameShopData(MstOutGameShopEntities mstData, bool isPurchase = false, bool enable = true)
		{
		}

		public bool IsParent(eOutGameShopId id)
		{
			return false;
		}
	}
}
