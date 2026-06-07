using System;
using DV.Localization;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.Shops
{
	public class ScanItemCashRegisterModule : CashRegisterModule
	{
		private string soldOutText;

		private string notAvailableText;

		public InventoryItemSpec sellingItemSpec;

		private Shop shop;

		[SerializeField]
		private TextMeshPro itemNameText;

		[SerializeField]
		private TextMeshPro itemPriceText;

		[NonSerialized]
		public string descriptionText;

		public string ItemName => itemNameText.text;

		public event Action<InventoryItemSpec, Shop, int> ItemPurchased;

		private void Awake()
		{
			soldOutText = LocalizationAPI.L("shop/sold_out");
			notAvailableText = LocalizationAPI.L("shop/not_available");
			if (sellingItemSpec == null)
			{
				Debug.LogError("sellingItemSpec not set! ScanItemCashRegisterModule can't function properly! Destroying self", this);
				UnityEngine.Object.Destroy(this);
			}
			shop = GetComponentInParent<Shop>();
			SingletonBehaviour<GlobalShopController>.Instance.GlobalShopDataChanged += OnGlobalShopDataChanged;
			OnGlobalShopDataChanged();
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<GlobalShopController>.Instance.GlobalShopDataChanged -= OnGlobalShopDataChanged;
			}
		}

		private void OnGlobalShopDataChanged()
		{
			InitializeData();
			UpdateTexts();
		}

		public void UpdateTexts()
		{
			if (sellingItemSpec != null)
			{
				itemNameText.text = sellingItemSpec.LocalizedName;
				ShopItemData shopItemData = SingletonBehaviour<GlobalShopController>.Instance.GetShopItemData(sellingItemSpec);
				bool flag = shopItemData.ItemsInStock <= 0;
				itemPriceText.text = ((!flag) ? ("$" + Data.pricePerUnit.ToString("N0", LocalizationAPI.CC)) : (shopItemData.unavailableDueToGameMode ? notAvailableText : soldOutText));
				descriptionText = sellingItemSpec.LocalizedDescription;
			}
			else
			{
				itemNameText.text = string.Empty;
				itemPriceText.text = string.Empty;
				descriptionText = string.Empty;
			}
		}

		protected override void InitializeData()
		{
			Data.pricePerUnit = SingletonBehaviour<GlobalShopController>.Instance.GetShopItemData(sellingItemSpec)?.basePrice ?? float.PositiveInfinity;
			Data.resourceName = sellingItemSpec.LocalizedName;
			Data.resourceIcon = null;
		}

		public override void GetBoughtResource()
		{
			if (!(Data.unitsToBuy < 1f))
			{
				int arg = (int)Data.unitsToBuy;
				SetUnitsToBuy(0f);
				this.ItemPurchased?.Invoke(sellingItemSpec, shop, arg);
				UpdateTexts();
			}
		}

		public bool AddItemsToBuy()
		{
			int itemsInStock = SingletonBehaviour<GlobalShopController>.Instance.GetShopItemData(sellingItemSpec).ItemsInStock;
			if (sellingItemSpec == null || itemsInStock <= 0 || Data.unitsToBuy >= (float)itemsInStock)
			{
				return false;
			}
			SetUnitsToBuy(Data.unitsToBuy + 1f);
			return true;
		}

		public override void ResetData()
		{
			Data.unitsToBuy = 0f;
		}
	}
}
