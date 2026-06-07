using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ShopUiManager : MonoBehaviour
	{
		public UIGrid InventoryGrid;

		public ShopUiItem ItemPrefab;

		public DisplayShopItemDetails ItemDetails;

		private List<ShopInventoryItem> _savedInventory;

		[HideInInspector]
		public ShopItem SelectedItem { get; private set; }

		public void Awake()
		{
			FillShop();
		}

		private void FillShop()
		{
			InventoryGrid.transform.DestroyAllChildren();
			ShopItem shopItem = null;
			foreach (ShopInventoryItem item in _savedInventory = _savedInventory ?? ShopInventoryHelper.GetBuyableItems())
			{
				ShopUiItem shopUiItem = Object.Instantiate(ItemPrefab);
				shopUiItem.Init(this, item);
				shopUiItem.transform.position = InventoryGrid.transform.position;
				shopUiItem.transform.parent = InventoryGrid.transform;
				shopUiItem.transform.localScale = InventoryGrid.transform.localScale;
				if (shopItem == null)
				{
					shopItem = item;
				}
			}
			SelectItem(shopItem);
			InventoryGrid.enabled = true;
			InventoryGrid.repositionNow = true;
		}

		public void SelectItem(ShopItem item)
		{
			SelectedItem = item;
			ItemDetails.Init(this, item);
		}

		public void Update()
		{
			ItemDetails.gameObject.SetActive(SelectedItem != null);
		}
	}
}
