using System;
using Restory.Data.Restrictions;
using UnityEngine;

namespace Restory.Data.Shops.HomeDepot
{
	[Serializable]
	public class HomeDepotShopItemData
	{
		[Min(0f)]
		public int Price;

		public ShopCategory Category;

		public bool IsHiddenInShop;

		public int SortOrder;

		[NonSerialized]
		public ContentRestrictionBase ContentRestriction;
	}
}
