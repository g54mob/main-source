using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Shops
{
	public class GlobalShopController : SingletonBehaviour<GlobalShopController>
	{
		private const float TimeToInstantiateItem = 0.5f;

		public List<Shop> globalShopList;

		public List<ShopItemData> shopItemsData;

		[Header("Debug")]
		public GameObject scanItemShelfPrefab;

		public ShopShelvesVerifiedSeeds shopShelvesVerifiedSeeds;

		public GameObject shopShelvesPrefab;

		private readonly List<ShoppingCartEntry> itemInstantiationQueue = new List<ShoppingCartEntry>();

		private readonly List<(Transform itemTransform, ItemBase itemBase, Shop shop)> staggeredItemActivationCollection = new List<(Transform, ItemBase, Shop)>();

		private bool isInstantiatingItems;

		public event Action GlobalShopDataChanged;

		public void Fire_GlobalShopDataChanged()
		{
			this.GlobalShopDataChanged?.Invoke();
		}

		protected override void Awake()
		{
			base.Awake();
			InitializeShopData();
			SetupListeners(on: true);
		}

		private void InitializeShopData()
		{
			bool flag = SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "Career";
			foreach (ShopItemData shopItemsDatum in shopItemsData)
			{
				shopItemsDatum.InitializeInitialAmount();
				if (!flag)
				{
					if (shopItemsDatum.careerOnly)
					{
						shopItemsDatum.initialAmount = 0;
						shopItemsDatum.unavailableDueToGameMode = true;
					}
					else
					{
						shopItemsDatum.basePrice = 0f;
					}
				}
				shopItemsDatum.allowedToHaveAmount = shopItemsDatum.initialAmount;
				if (shopItemsDatum.item.TryGetComponent<AShopRestockerLoadException>(out var component))
				{
					component.Initialize(shopItemsDatum);
				}
			}
			this.GlobalShopDataChanged?.Invoke();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			foreach (ShopItemData shopItemsDatum in shopItemsData)
			{
				if (shopItemsDatum.item.TryGetComponent<AShopRestockerLoadException>(out var component))
				{
					component.Uninitialize();
				}
			}
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			foreach (Shop globalShop in globalShopList)
			{
				ScanItemCashRegisterModule[] scanItemResourceModules = globalShop.scanItemResourceModules;
				foreach (ScanItemCashRegisterModule scanItemCashRegisterModule in scanItemResourceModules)
				{
					if (scanItemCashRegisterModule == null)
					{
						Debug.LogError("Item Resource Module missing. This should not happen!", this);
					}
					else if (on)
					{
						scanItemCashRegisterModule.ItemPurchased += AddItemToInstantiationQueue;
					}
					else
					{
						scanItemCashRegisterModule.ItemPurchased -= AddItemToInstantiationQueue;
					}
				}
			}
		}

		public void AddItemToInstantiationQueue(InventoryItemSpec boughtItemSpec, Shop shop, int amountBought)
		{
			if (boughtItemSpec == null)
			{
				Debug.LogError("Trying to buy a null item. This should not happen. Skipping...");
				return;
			}
			ShopItemData shopItemData = GetShopItemData(boughtItemSpec);
			if (shopItemData == null)
			{
				Debug.LogError("Unexpected state, item which is not part of shopItemsData is bought! Ignoring request, something is bad!", this);
				return;
			}
			shopItemData.purchasedItems += amountBought;
			itemInstantiationQueue.Add(new ShoppingCartEntry(shop, boughtItemSpec, amountBought));
			SingletonBehaviour<UnlockablesManager>.Instance.UnlockItem(boughtItemSpec.ItemPrefabName);
		}

		public ShopItemData GetShopItemData(InventoryItemSpec itemSpec)
		{
			return shopItemsData.FirstOrDefault((ShopItemData shoppingSpec) => shoppingSpec.item == itemSpec);
		}

		public ShopItemData GetShopItemData(string itemPrefabName)
		{
			return shopItemsData.FirstOrDefault((ShopItemData shoppingSpec) => shoppingSpec.item.ItemPrefabName == itemPrefabName);
		}

		private void SetShopProcessingTransactionState(bool isProcessing)
		{
			foreach (Shop globalShop in globalShopList)
			{
				globalShop.cashRegister.IsProcessingTransaction = isProcessing;
			}
		}

		private IEnumerator InstantiatePurchasedItems()
		{
			isInstantiatingItems = true;
			SetShopProcessingTransactionState(isProcessing: true);
			staggeredItemActivationCollection.Clear();
			Vector3 zero = Vector3.zero;
			Vector3 right = Vector3.right;
			int num = 0;
			foreach (ShoppingCartEntry item3 in itemInstantiationQueue)
			{
				for (int i = 0; i < item3.desiredAmount; i++)
				{
					Vector3 position = zero + right * num;
					string itemPrefabName = item3.specs.ItemPrefabName;
					GameObject obj = UnityEngine.Object.Instantiate(Resources.Load(itemPrefabName) as GameObject, position, Quaternion.identity);
					Transform transform = obj.transform;
					obj.GetComponent<InventoryItemSpec>().BelongsToPlayer = true;
					ShopRestocker component = obj.GetComponent<ShopRestocker>();
					if (component == null)
					{
						Debug.LogError("Missing ShopRestocker component on item prefab " + itemPrefabName + ". This should not happen.", this);
					}
					else
					{
						component.restockOnItemDestroyed = true;
					}
					ItemBase component2 = transform.GetComponent<ItemBase>();
					staggeredItemActivationCollection.Add((transform, component2, item3.shop));
					num++;
				}
			}
			yield return null;
			for (int num2 = staggeredItemActivationCollection.Count - 1; num2 >= 0; num2--)
			{
				ItemBase item = staggeredItemActivationCollection[num2].itemBase;
				SingletonBehaviour<StorageController>.Instance.AddItemToLostAndFound(item, updateTransformData: false);
				item.gameObject.SetActive(value: false);
			}
			foreach (var item4 in staggeredItemActivationCollection)
			{
				Transform playerTransform = PlayerManager.PlayerTransform;
				if (playerTransform == null)
				{
					continue;
				}
				Vector3 position2 = item4.shop.itemSpawnTransform.position;
				ItemBase item2 = item4.itemBase;
				RespawnOnDrop component3 = item2.GetComponent<RespawnOnDrop>();
				if (component3 != null && (playerTransform.position - position2).sqrMagnitude >= component3.maxDistance * component3.maxDistance)
				{
					item2.ItemRigidbody.velocity = Vector3.zero;
					item2.ItemRigidbody.angularVelocity = Vector3.zero;
					continue;
				}
				SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(item4.itemBase);
				item4.itemTransform.position = position2;
				item2.ItemRigidbody.velocity = Vector3.zero;
				item2.ItemRigidbody.angularVelocity = Vector3.zero;
				item2.gameObject.SetActive(value: true);
				APurchaseTrigger component4 = item2.GetComponent<APurchaseTrigger>();
				if ((bool)component4)
				{
					component4.OnPurchased(item2.gameObject);
				}
				yield return WaitFor.Seconds(0.5f);
			}
			itemInstantiationQueue.Clear();
			isInstantiatingItems = false;
			SetShopProcessingTransactionState(isProcessing: false);
		}

		private void Update()
		{
			if (itemInstantiationQueue.Count != 0 && !isInstantiatingItems)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(InstantiatePurchasedItems());
			}
		}

		public void Restock(string itemPrefabName)
		{
			foreach (ShopItemData shopItemsDatum in shopItemsData)
			{
				if (!(shopItemsDatum.item.ItemPrefabName != itemPrefabName))
				{
					if (shopItemsDatum.purchasedItems != 0)
					{
						shopItemsDatum.purchasedItems--;
						this.GlobalShopDataChanged?.Invoke();
					}
					return;
				}
			}
			Debug.LogError("Could not find item with prefab name " + itemPrefabName + " in any shop! Restock failed.", this);
		}

		public static void UpdateItemStocksOnGameLoad()
		{
			if (SingletonBehaviour<GlobalShopController>.Instance == null)
			{
				Debug.LogError("GlobalShopController: Instance is null. Aborting load.");
				return;
			}
			foreach (InventoryItemSpec item in from i in SingletonBehaviour<StorageController>.Instance.GetAllStorageItems()
				select i.GetComponent<ShopRestocker>() into t
				where t != null && t.restockOnItemDestroyed
				select t.GetComponent<InventoryItemSpec>())
			{
				if (item == null)
				{
					Debug.LogError("GlobalShopController: Item is null. Skipping stock modification.");
					continue;
				}
				ShopItemData shopItemData = SingletonBehaviour<GlobalShopController>.Instance.GetShopItemData(item.ItemPrefabName);
				if (shopItemData == null)
				{
					Debug.LogError("GlobalShopController: Item " + item.ItemPrefabName + " is not part of shop data. Skipping stock modification.", item);
				}
				else if (shopItemData.purchasedItems == shopItemData.allowedToHaveAmount)
				{
					Debug.LogError("GlobalShopController: Item " + item.ItemPrefabName + " is already out of stock. Skipping stock modification", item);
				}
				else
				{
					shopItemData.purchasedItems++;
				}
			}
			foreach (ShopItemData shopItemsDatum in SingletonBehaviour<GlobalShopController>.Instance.shopItemsData)
			{
				AShopRestockerLoadException component = shopItemsDatum.item.GetComponent<AShopRestockerLoadException>();
				if (!(component == null))
				{
					component.ModifyAmount();
				}
			}
			SingletonBehaviour<GlobalShopController>.Instance.GlobalShopDataChanged?.Invoke();
		}
	}
}
