using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMarketplaceUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private ComputerMarketplaceManager marketplaceManager;

	[SerializeField]
	private ComputerHoverPanel hoverPanel;

	[SerializeField]
	private AudioSource audioSource;

	[Header("Factory Info")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("Item List")]
	[SerializeField]
	private Transform itemListContent;

	[SerializeField]
	private GameObject itemListPrefab;

	[Header("Shopping Cart")]
	[SerializeField]
	private Transform shoppingCartContent;

	[SerializeField]
	private GameObject shoppingCartItemPrefab;

	[SerializeField]
	private TextMeshProUGUI cartTotalPriceText;

	[SerializeField]
	private Color defaultTotalPriceColor = Color.white;

	[SerializeField]
	private Color insufficientFundsTotalPriceColor = Color.red;

	[SerializeField]
	private Button purchaseButton;

	[SerializeField]
	private Button clearCartButton;

	[Header("Purchase Feedback")]
	[SerializeField]
	private GameObject purchaseCompleted;

	[SerializeField]
	private AudioClip cashRegisterSound;

	[SerializeField]
	private float purchasePopupDuration = 2f;

	private BuildingCategory _selectedCategory;

	private bool _isAllCategorySelected = true;

	private Dictionary<int, GameObject> _itemListItems = new Dictionary<int, GameObject>();

	private Dictionary<int, GameObject> _cartItems = new Dictionary<int, GameObject>();

	private void Awake()
	{
		if (marketplaceManager == null)
		{
			marketplaceManager = Object.FindFirstObjectByType<ComputerMarketplaceManager>();
		}
	}

	private void OnEnable()
	{
		_isAllCategorySelected = true;
		RefreshUI();
		SubscribeToEvents();
		UpdateFactoryInfo();
	}

	private void OnDisable()
	{
		UnsubscribeFromEvents();
		HideHoverPanel();
		if (purchaseCompleted != null)
		{
			purchaseCompleted.SetActive(value: false);
		}
		StopAllCoroutines();
	}

	private void SubscribeToEvents()
	{
		if (marketplaceManager != null)
		{
			marketplaceManager.onCartItemAdded.AddListener(OnCartItemAdded);
			marketplaceManager.onCartItemRemoved.AddListener(OnCartItemRemoved);
			marketplaceManager.onCartItemUpdated.AddListener(OnCartItemUpdated);
			marketplaceManager.onCartCleared.AddListener(OnCartCleared);
			marketplaceManager.onPurchaseCompleted.AddListener(OnPurchaseCompleted);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.AddListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.AddListener(OnLevelChanged);
		}
	}

	private void UnsubscribeFromEvents()
	{
		if (marketplaceManager != null)
		{
			marketplaceManager.onCartItemAdded.RemoveListener(OnCartItemAdded);
			marketplaceManager.onCartItemRemoved.RemoveListener(OnCartItemRemoved);
			marketplaceManager.onCartItemUpdated.RemoveListener(OnCartItemUpdated);
			marketplaceManager.onCartCleared.RemoveListener(OnCartCleared);
			marketplaceManager.onPurchaseCompleted.RemoveListener(OnPurchaseCompleted);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.RemoveListener(OnLevelChanged);
		}
	}

	public void RefreshUI()
	{
		RefreshItemList();
		RefreshShoppingCart();
	}

	private void RefreshItemList()
	{
		if (marketplaceManager == null || marketplaceManager.MarketplaceItemList == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] ComputerMarketplaceManager veya MarketplaceItemList bulunamadı!");
			return;
		}
		foreach (KeyValuePair<int, GameObject> itemListItem in _itemListItems)
		{
			if (itemListItem.Value != null)
			{
				Object.Destroy(itemListItem.Value);
			}
		}
		_itemListItems.Clear();
		List<T_BuildingItemSO> list = new List<T_BuildingItemSO>();
		foreach (T_BuildingItemSO marketplaceItem in marketplaceManager.MarketplaceItemList)
		{
			if (!(marketplaceItem == null) && marketplaceItem.canBeSoldInMarket)
			{
				if (_isAllCategorySelected)
				{
					list.Add(marketplaceItem);
				}
				else if (marketplaceItem.Category == _selectedCategory)
				{
					list.Add(marketplaceItem);
				}
			}
		}
		list = list.OrderBy((T_BuildingItemSO item) => item.Level).ToList();
		foreach (T_BuildingItemSO item in list)
		{
			int itemIndex = marketplaceManager.GetItemIndex(item);
			if (itemIndex >= 0)
			{
				CreateItemListItem(item, itemIndex);
			}
		}
	}

	private void RefreshShoppingCart()
	{
		if (marketplaceManager == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] RefreshShoppingCart - marketplaceManager null!");
			return;
		}
		Debug.Log($"[ComputerMarketplaceUI] RefreshShoppingCart - Cart item count: {marketplaceManager.ShoppingCart.Count}");
		foreach (KeyValuePair<int, GameObject> cartItem in _cartItems)
		{
			if (cartItem.Value != null)
			{
				Object.Destroy(cartItem.Value);
			}
		}
		_cartItems.Clear();
		foreach (ShoppingCartItemData item in marketplaceManager.ShoppingCart)
		{
			Debug.Log($"[ComputerMarketplaceUI] RefreshShoppingCart - Creating item: Index {item.itemSOIndex}, Quantity: {item.quantity}");
			CreateCartItem(item);
		}
		Debug.Log($"[ComputerMarketplaceUI] RefreshShoppingCart - Created {_cartItems.Count} cart items");
		UpdateCartTotalPrice();
		UpdatePurchaseButton();
	}

	private void CreateItemListItem(T_BuildingItemSO itemSO, int itemIndex)
	{
		if (itemListPrefab == null || itemListContent == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] Item list prefab veya content bulunamadı!");
			return;
		}
		GameObject gameObject = Object.Instantiate(itemListPrefab, itemListContent);
		ComputerMarketplaceItemListUI component = gameObject.GetComponent<ComputerMarketplaceItemListUI>();
		if (component == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] ComputerMarketplaceItemListUI component'i bulunamadı!");
			Object.Destroy(gameObject);
		}
		else
		{
			component.Setup(itemSO, itemIndex, this);
			_itemListItems[itemIndex] = gameObject;
		}
	}

	private void CreateCartItem(ShoppingCartItemData cartItem)
	{
		if (shoppingCartItemPrefab == null || shoppingCartContent == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] Shopping cart item prefab veya content bulunamadı!");
			return;
		}
		if (marketplaceManager == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] marketplaceManager null!");
			return;
		}
		T_BuildingItemSO itemSO = marketplaceManager.GetItemSO(cartItem.itemSOIndex);
		if (itemSO == null)
		{
			Debug.LogWarning($"[ComputerMarketplaceUI] ItemSO bulunamadı! Index: {cartItem.itemSOIndex}");
			return;
		}
		GameObject gameObject = Object.Instantiate(shoppingCartItemPrefab, shoppingCartContent);
		ComputerMarketplaceShoppingCartItemUI component = gameObject.GetComponent<ComputerMarketplaceShoppingCartItemUI>();
		if (component == null)
		{
			Debug.LogWarning("[ComputerMarketplaceUI] ComputerMarketplaceShoppingCartItemUI component'i bulunamadı!");
			Object.Destroy(gameObject);
		}
		else
		{
			component.Setup(itemSO, cartItem, this);
			_cartItems[cartItem.itemSOIndex] = gameObject;
			Debug.Log($"[ComputerMarketplaceUI] Cart item oluşturuldu: {itemSO.Name} (Index: {cartItem.itemSOIndex}, Quantity: {cartItem.quantity})");
		}
	}

	public void OnAllCategoryButtonClicked()
	{
		_isAllCategorySelected = true;
		RefreshItemList();
	}

	public void OnProcessorsCategoryButtonClicked()
	{
		_isAllCategorySelected = false;
		_selectedCategory = BuildingCategory.Processors;
		RefreshItemList();
	}

	public void OnFabricatorsCategoryButtonClicked()
	{
		_isAllCategorySelected = false;
		_selectedCategory = BuildingCategory.Fabricators;
		RefreshItemList();
	}

	public void OnWarehouseCategoryButtonClicked()
	{
		_isAllCategorySelected = false;
		_selectedCategory = BuildingCategory.Warehouse;
		RefreshItemList();
	}

	public void OnPurchaseButtonClicked()
	{
		if (marketplaceManager == null || marketplaceManager.IsCartEmpty)
		{
			return;
		}
		if (FactoryManager.Instance != null)
		{
			int cartTotalPrice = marketplaceManager.CartTotalPrice;
			if (FactoryManager.Instance.Money < cartTotalPrice)
			{
				ShowInsufficientFundsWarning();
				return;
			}
		}
		marketplaceManager.RequestPurchase();
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.BuyMachine, TutorialSubStepType.PurchaseMachine);
	}

	private void ShowInsufficientFundsWarning()
	{
		if (NotificationManager.Instance != null)
		{
			NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance"), isComputer: true);
		}
	}

	public void OnClearCartButtonClicked()
	{
		if (!(marketplaceManager == null))
		{
			marketplaceManager.RequestClearCart();
		}
	}

	public void OnAddToCartClicked(int itemSOIndex)
	{
		if (!(marketplaceManager == null))
		{
			marketplaceManager.RequestAddToCart(itemSOIndex);
		}
	}

	public void OnCartItemDeleteClicked(int itemSOIndex)
	{
		if (!(marketplaceManager == null))
		{
			marketplaceManager.RequestRemoveFromCart(itemSOIndex);
		}
	}

	private void OnCartItemAdded(ShoppingCartItemData cartItem)
	{
		Debug.Log($"[ComputerMarketplaceUI] OnCartItemAdded - ItemIndex: {cartItem.itemSOIndex}, Quantity: {cartItem.quantity}");
		if (_cartItems.ContainsKey(cartItem.itemSOIndex))
		{
			GameObject gameObject = _cartItems[cartItem.itemSOIndex];
			if (gameObject != null)
			{
				ComputerMarketplaceShoppingCartItemUI component = gameObject.GetComponent<ComputerMarketplaceShoppingCartItemUI>();
				if (component != null)
				{
					component._cartItem = cartItem;
					component.UpdateUI();
				}
			}
		}
		else
		{
			CreateCartItem(cartItem);
		}
		UpdateCartTotalPrice();
		UpdatePurchaseButton();
		RefreshItemListButtons();
	}

	private void OnCartItemUpdated(ShoppingCartItemData cartItem)
	{
		Debug.Log($"[ComputerMarketplaceUI] OnCartItemUpdated - ItemIndex: {cartItem.itemSOIndex}, Quantity: {cartItem.quantity}");
		if (_cartItems.ContainsKey(cartItem.itemSOIndex))
		{
			GameObject gameObject = _cartItems[cartItem.itemSOIndex];
			if (gameObject != null)
			{
				ComputerMarketplaceShoppingCartItemUI component = gameObject.GetComponent<ComputerMarketplaceShoppingCartItemUI>();
				if (component != null)
				{
					component._cartItem = cartItem;
					component.UpdateUI();
					Debug.Log($"[ComputerMarketplaceUI] Cart item UI güncellendi: {cartItem.itemSOIndex}, Quantity: {cartItem.quantity}");
				}
			}
		}
		UpdateCartTotalPrice();
		UpdatePurchaseButton();
	}

	private void OnCartItemRemoved(ShoppingCartItemData cartItem)
	{
		Debug.Log($"[ComputerMarketplaceUI] OnCartItemRemoved - ItemIndex: {cartItem.itemSOIndex}");
		if (_cartItems.ContainsKey(cartItem.itemSOIndex))
		{
			GameObject gameObject = _cartItems[cartItem.itemSOIndex];
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			_cartItems.Remove(cartItem.itemSOIndex);
		}
		UpdateCartTotalPrice();
		UpdatePurchaseButton();
		RefreshItemListButtons();
	}

	private void OnCartCleared()
	{
		Debug.Log("[ComputerMarketplaceUI] OnCartCleared - UI temizleniyor");
		foreach (KeyValuePair<int, GameObject> cartItem in _cartItems)
		{
			if (cartItem.Value != null)
			{
				Object.Destroy(cartItem.Value);
			}
		}
		_cartItems.Clear();
		if (cartTotalPriceText != null)
		{
			cartTotalPriceText.text = "0";
			cartTotalPriceText.color = defaultTotalPriceColor;
		}
		UpdatePurchaseButton();
		RefreshItemListButtons();
	}

	private void OnPurchaseCompleted(List<ShoppingCartItemData> orderSummary)
	{
		Debug.Log("[ComputerMarketplaceUI] Satın alma tamamlandı!");
		Debug.Log($"[ComputerMarketplaceUI] Sipariş Özeti ({orderSummary.Count} item):");
		if (marketplaceManager != null)
		{
			int num = 0;
			foreach (ShoppingCartItemData item in orderSummary)
			{
				T_BuildingItemSO itemSO = marketplaceManager.GetItemSO(item.itemSOIndex);
				if (itemSO != null)
				{
					int totalPrice = item.GetTotalPrice(itemSO);
					num += totalPrice;
					Debug.Log($"  - {itemSO.Name} x{item.quantity} (Paket: {itemSO.packageQuantity}x) = ${totalPrice:N0}");
				}
			}
			Debug.Log($"[ComputerMarketplaceUI] Toplam: ${num:N0}");
		}
		ShowPurchaseCompletedPopup();
		PlayCashRegisterSound();
		RefreshItemListButtons();
	}

	private void OnMoneyChanged(int oldMoney, int newMoney)
	{
		RefreshItemListButtons();
		UpdatePurchaseButton();
		UpdateCartTotalPrice();
		UpdateMoneyText(newMoney);
	}

	private void OnLevelChanged(int oldLevel, int newLevel)
	{
		RefreshItemListButtons();
		UpdateLevelText(newLevel);
	}

	private void UpdateFactoryInfo()
	{
		if (FactoryManager.Instance != null)
		{
			UpdateMoneyText(FactoryManager.Instance.Money);
			UpdateLevelText(FactoryManager.Instance.Level);
		}
	}

	private void UpdateMoneyText(int money)
	{
		if (moneyText != null)
		{
			moneyText.text = $"{money:N0}";
		}
	}

	private void UpdateLevelText(int level)
	{
		if (levelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				level.ToString()
			} });
			levelText.text = translation;
		}
	}

	private void UpdateCartTotalPrice()
	{
		if (!(cartTotalPriceText == null) && !(marketplaceManager == null))
		{
			int cartTotalPrice = marketplaceManager.CartTotalPrice;
			cartTotalPriceText.text = $"{cartTotalPrice:N0}";
			bool flag = cartTotalPrice == 0 || (FactoryManager.Instance != null && FactoryManager.Instance.Money >= cartTotalPrice);
			cartTotalPriceText.color = (flag ? defaultTotalPriceColor : insufficientFundsTotalPriceColor);
		}
	}

	private void UpdatePurchaseButton()
	{
		if (!(purchaseButton == null) && !(marketplaceManager == null))
		{
			purchaseButton.interactable = true;
		}
	}

	private void RefreshItemListButtons()
	{
		foreach (KeyValuePair<int, GameObject> itemListItem in _itemListItems)
		{
			if (itemListItem.Value != null)
			{
				ComputerMarketplaceItemListUI component = itemListItem.Value.GetComponent<ComputerMarketplaceItemListUI>();
				if (component != null)
				{
					component.UpdateButtonState();
				}
			}
		}
	}

	public void ShowHoverPanel(T_BuildingItemSO itemSO, RectTransform targetRect)
	{
		if (hoverPanel != null && itemSO != null)
		{
			hoverPanel.Show(itemSO, targetRect);
		}
	}

	public void HideHoverPanel()
	{
		if (hoverPanel != null)
		{
			hoverPanel.Hide();
		}
	}

	private void ShowPurchaseCompletedPopup()
	{
		if (purchaseCompleted != null)
		{
			purchaseCompleted.SetActive(value: true);
			StartCoroutine(HidePurchaseCompletedPopupCoroutine());
		}
	}

	private IEnumerator HidePurchaseCompletedPopupCoroutine()
	{
		yield return new WaitForSeconds(purchasePopupDuration);
		if (purchaseCompleted != null)
		{
			purchaseCompleted.SetActive(value: false);
		}
		if (!(TutorialManager.Instance == null) && !TutorialManager.Instance.IsTutorialRunning)
		{
			yield break;
		}
		foreach (KeyValuePair<int, GameObject> itemListItem in _itemListItems)
		{
			if (itemListItem.Value != null)
			{
				ComputerMarketplaceItemListUI component = itemListItem.Value.GetComponent<ComputerMarketplaceItemListUI>();
				if (component != null)
				{
					component.UpdateUI();
				}
			}
		}
	}

	private void PlayCashRegisterSound()
	{
		if (cashRegisterSound == null)
		{
			return;
		}
		if (audioSource == null)
		{
			audioSource = GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = base.gameObject.AddComponent<AudioSource>();
			}
		}
		audioSource.PlayOneShot(cashRegisterSound);
	}
}
