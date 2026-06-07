using System;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Shops
{
	[RequireComponent(typeof(ItemSaveData))]
	[DisallowMultipleComponent]
	public class ShopRestocker : MonoBehaviour
	{
		public const string RESTOCK_SHOP_KEY = "Restock";

		private string itemPrefabName;

		private ItemSaveData itemSaveData;

		[NonSerialized]
		public bool restockOnItemDestroyed;

		private void Awake()
		{
			InventoryItemSpec component = GetComponent<InventoryItemSpec>();
			if (component == null)
			{
				Debug.LogError("ShopRestocker: Missing InventoryItemSpec reference. Restocking shop will not be possible. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				itemPrefabName = component.ItemPrefabName;
				itemSaveData = GetComponent<ItemSaveData>();
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (!(itemSaveData == null))
			{
				if (on)
				{
					itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
					itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
				}
				else
				{
					itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
					itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
				}
			}
		}

		private void OnItemSaveDataLoaded(JObject data)
		{
			restockOnItemDestroyed = data.GetBool("Restock") ?? false;
		}

		private JObject OnItemSaveDataRequested(JObject data)
		{
			data.SetBool("Restock", restockOnItemDestroyed);
			return data;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
				if (restockOnItemDestroyed)
				{
					SingletonBehaviour<GlobalShopController>.Instance.Restock(itemPrefabName);
				}
			}
		}
	}
}
