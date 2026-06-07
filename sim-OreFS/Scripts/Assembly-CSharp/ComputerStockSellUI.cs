using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerStockSellUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private ComputerStockSellManager stockSellManager;

	[Header("Factory Info")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("Item List (Left Panel)")]
	[SerializeField]
	private GameObject stockItemPrefab;

	[SerializeField]
	private Transform stockItemListContent;

	[Header("Filter")]
	[SerializeField]
	private TextMeshProUGUI filterButtonText;

	[Header("Selected Item Panel")]
	[SerializeField]
	private GameObject selectedItemPanelRoot;

	[SerializeField]
	private Image selectedItemIcon;

	[SerializeField]
	private TextMeshProUGUI selectedItemNameText;

	[SerializeField]
	private TextMeshProUGUI selectedItemStockText;

	[Header("Offer List (Right Panel)")]
	[SerializeField]
	private GameObject offerItemPrefab;

	[SerializeField]
	private Transform offerListContent;

	[Header("Hover Panel")]
	[SerializeField]
	private ComputerHoverPanel hoverPanel;

	[Header("Selling Details Panel")]
	[SerializeField]
	private GameObject sellingDetailsPanelRoot;

	[SerializeField]
	private Image detailItemIcon;

	[SerializeField]
	private TextMeshProUGUI detailItemNameText;

	[SerializeField]
	private TextMeshProUGUI detailCompanyNameText;

	[SerializeField]
	private TextMeshProUGUI detailQuantityText;

	[SerializeField]
	private TextMeshProUGUI detailUnitPriceText;

	[SerializeField]
	private TextMeshProUGUI detailTotalPriceText;

	[SerializeField]
	private Slider quantitySlider;

	[SerializeField]
	private TextMeshProUGUI sliderValueText;

	[SerializeField]
	private TextMeshProUGUI currentPriceText;

	[SerializeField]
	private TextMeshProUGUI currentStockText;

	[SerializeField]
	private int minSliderValue = 5;

	private List<StockSellItemUI> _spawnedStockItems = new List<StockSellItemUI>();

	private List<StockSellOfferItemUI> _spawnedOfferItems = new List<StockSellOfferItemUI>();

	private T_ItemSO _selectedItem;

	private string _selectedItemId;

	private int currentFilterIndex = -1;

	private static readonly int filterTypeCount = Enum.GetValues(typeof(FilterType)).Length;

	private StockDemandData _currentOffer;

	private T_ItemSO _currentOfferItem;

	private int _selectedQuantity;

	private bool _offerListDirty;

	private const int tutorialMinSliderValue = 6;

	private void Awake()
	{
		if (stockSellManager == null)
		{
			stockSellManager = ComputerStockSellManager.Instance;
		}
	}

	private void OnEnable()
	{
		_selectedItem = null;
		_selectedItemId = null;
		_offerListDirty = false;
		SubscribeToEvents();
		RefreshUI();
		UpdateFactoryInfo();
		HideSelectedItemPanel();
		HideSellingDetailsPanel();
		SetupSellingDetailsPanelButtons();
		ResetFilter();
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.StockSellAndContract, TutorialStepType.StockSell, TutorialSubStepType.OpenStockSellApp);
		}
	}

	private void OnDisable()
	{
		UnsubscribeFromEvents();
		CleanupSellingDetailsPanelButtons();
		HideHoverPanel();
	}

	private void SubscribeToEvents()
	{
		if (stockSellManager == null)
		{
			stockSellManager = ComputerStockSellManager.Instance;
		}
		if (stockSellManager != null)
		{
			stockSellManager.onWarehouseUpdated.AddListener(OnWarehouseUpdated);
			stockSellManager.onSaleCompleted.AddListener(OnSaleCompleted);
			stockSellManager.onDemandsListChanged.AddListener(OnDemandsListChanged);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.AddListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.AddListener(OnLevelChanged);
		}
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.OnInventoryChanged.AddListener(OnWarehouseInventoryChanged);
		}
	}

	private void UnsubscribeFromEvents()
	{
		if (stockSellManager != null)
		{
			stockSellManager.onWarehouseUpdated.RemoveListener(OnWarehouseUpdated);
			stockSellManager.onSaleCompleted.RemoveListener(OnSaleCompleted);
			stockSellManager.onDemandsListChanged.RemoveListener(OnDemandsListChanged);
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.RemoveListener(OnLevelChanged);
		}
		if (T_Warehouse.Instance != null)
		{
			T_Warehouse.Instance.OnInventoryChanged.RemoveListener(OnWarehouseInventoryChanged);
		}
	}

	public void RefreshUI()
	{
		RefreshStockItemList();
		RefreshOfferList();
	}

	private void RefreshStockItemList()
	{
		ClearStockItemList();
		if (stockSellManager == null)
		{
			stockSellManager = ComputerStockSellManager.Instance;
		}
		if (stockSellManager == null)
		{
			Debug.LogWarning("[ComputerStockSellUI] stockSellManager null!");
			return;
		}
		IReadOnlyList<T_ItemSO> allItems = stockSellManager.AllItems;
		if (allItems == null || allItems.Count == 0)
		{
			Debug.LogWarning($"[ComputerStockSellUI] AllItems null veya boş! Count: {allItems?.Count ?? 0}");
			return;
		}
		if (stockItemPrefab == null)
		{
			Debug.LogWarning("[ComputerStockSellUI] stockItemPrefab null!");
			return;
		}
		if (stockItemListContent == null)
		{
			Debug.LogWarning("[ComputerStockSellUI] stockItemListContent null!");
			return;
		}
		List<WarehouseItemInfo> warehouseItems = stockSellManager.GetWarehouseItems();
		Debug.Log($"[ComputerStockSellUI] RefreshStockItemList - AllItems: {allItems.Count}, WarehouseItems: {warehouseItems.Count}");
		foreach (T_ItemSO item in allItems)
		{
			if (item == null)
			{
				continue;
			}
			int stockCount = 0;
			foreach (WarehouseItemInfo item2 in warehouseItems)
			{
				if (item2.itemId == item.GetItemID())
				{
					stockCount = item2.count;
					break;
				}
			}
			CreateStockItem(item, stockCount);
		}
		Debug.Log($"[ComputerStockSellUI] Toplam spawn edilen item: {_spawnedStockItems.Count}");
		ApplyFilter();
	}

	private void RefreshOfferList()
	{
		ClearOfferList();
		if (stockSellManager == null || string.IsNullOrEmpty(_selectedItemId))
		{
			return;
		}
		List<StockDemandData> demandsForItem = stockSellManager.GetDemandsForItem(_selectedItemId);
		Debug.Log($"[ComputerStockSellUI] RefreshOfferList - SelectedItemId: {_selectedItemId}, OfferCount: {demandsForItem.Count}, ActiveDemands Total: {stockSellManager.ActiveDemands.Count}");
		foreach (StockDemandData item in demandsForItem)
		{
			Debug.Log($"[ComputerStockSellUI] Offer: {item.companyName} - DemandId: {item.demandId} - Amount: {item.demandedAmount}");
			CreateOfferItem(item);
		}
	}

	private void CreateStockItem(T_ItemSO itemSO, int stockCount)
	{
		if (!(stockItemPrefab == null) && !(stockItemListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(stockItemPrefab, stockItemListContent);
			StockSellItemUI component = gameObject.GetComponent<StockSellItemUI>();
			if (component != null)
			{
				bool isSelected = _selectedItemId == itemSO.GetItemID();
				component.Initialize(itemSO, stockCount, isSelected, OnStockItemClicked, this);
				_spawnedStockItems.Add(component);
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void ClearStockItemList()
	{
		foreach (StockSellItemUI spawnedStockItem in _spawnedStockItems)
		{
			if (spawnedStockItem != null)
			{
				UnityEngine.Object.Destroy(spawnedStockItem.gameObject);
			}
		}
		_spawnedStockItems.Clear();
	}

	private void CreateOfferItem(StockDemandData offer)
	{
		if (!(offerItemPrefab == null) && !(offerListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(offerItemPrefab, offerListContent);
			StockSellOfferItemUI component = gameObject.GetComponent<StockSellOfferItemUI>();
			if (component != null)
			{
				component.Initialize(offer, OnOfferInspectClicked, GetStockCountForItem);
				_spawnedOfferItems.Add(component);
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private int GetStockCountForItem(string itemId)
	{
		return stockSellManager?.GetWarehouseItemCount(itemId) ?? 0;
	}

	private void ClearOfferList()
	{
		foreach (StockSellOfferItemUI spawnedOfferItem in _spawnedOfferItems)
		{
			if (spawnedOfferItem != null)
			{
				UnityEngine.Object.Destroy(spawnedOfferItem.gameObject);
			}
		}
		_spawnedOfferItems.Clear();
	}

	private void OnStockItemClicked(T_ItemSO itemSO)
	{
		if (!(itemSO == null))
		{
			_selectedItem = itemSO;
			_selectedItemId = itemSO.GetItemID();
			stockSellManager?.RequestSelectItem(_selectedItemId);
			UpdateStockItemSelectionStates();
			ShowSelectedItemPanel();
			_offerListDirty = true;
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.StockSellAndContract, TutorialStepType.StockSell, TutorialSubStepType.SelectProducedItem);
			}
		}
	}

	private void UpdateStockItemSelectionStates()
	{
		foreach (StockSellItemUI spawnedStockItem in _spawnedStockItems)
		{
			if (spawnedStockItem != null)
			{
				bool selected = spawnedStockItem.ItemId == _selectedItemId;
				spawnedStockItem.SetSelected(selected);
			}
		}
	}

	private void OnWarehouseUpdated()
	{
		UpdateStockCounts();
	}

	private void OnSaleCompleted(StockDemandData demand)
	{
		Debug.Log("[ComputerStockSellUI] OnSaleCompleted tetiklendi - ItemId: " + demand.itemId + ", SelectedItemId: " + _selectedItemId);
		_offerListDirty = true;
		UpdateStockCounts();
	}

	private void OnDemandsListChanged()
	{
		_offerListDirty = true;
		Debug.Log($"[ComputerStockSellUI] OnDemandsListChanged - dirty flag SET. SelectedItemId: {_selectedItemId}, isActiveAndEnabled: {base.isActiveAndEnabled}");
	}

	private void LateUpdate()
	{
		if (_offerListDirty)
		{
			_offerListDirty = false;
			Debug.Log("[ComputerStockSellUI] LateUpdate - Offer listesi yenileniyor. SelectedItemId: " + _selectedItemId);
			RefreshOfferList();
			UpdateStockCounts();
		}
	}

	private void OnWarehouseInventoryChanged()
	{
		UpdateStockCounts();
	}

	private void UpdateStockCounts()
	{
		if (stockSellManager == null)
		{
			return;
		}
		List<WarehouseItemInfo> warehouseItems = stockSellManager.GetWarehouseItems();
		Debug.Log($"[ComputerStockSellUI] UpdateStockCounts çağrıldı - warehouseItems.Count: {warehouseItems.Count}");
		foreach (StockSellItemUI spawnedStockItem in _spawnedStockItems)
		{
			if (spawnedStockItem == null)
			{
				continue;
			}
			string itemId = spawnedStockItem.ItemId;
			int num = 0;
			foreach (WarehouseItemInfo item in warehouseItems)
			{
				if (item.itemId == itemId)
				{
					num = item.count;
					break;
				}
			}
			Debug.Log($"[ComputerStockSellUI] UpdateStockCounts - ItemId: {itemId}, OldCount: {spawnedStockItem.StockCount}, NewCount: {num}");
			spawnedStockItem.UpdateStockCount(num);
		}
		UpdateSelectedItemStock();
		foreach (StockSellOfferItemUI spawnedOfferItem in _spawnedOfferItems)
		{
			if (spawnedOfferItem != null)
			{
				spawnedOfferItem.UpdateInspectButtonState();
			}
		}
	}

	private void OnMoneyChanged(int oldMoney, int newMoney)
	{
		UpdateMoneyText(newMoney);
	}

	private void OnLevelChanged(int oldLevel, int newLevel)
	{
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

	public void OnFilterButtonClicked()
	{
		currentFilterIndex++;
		if (currentFilterIndex >= filterTypeCount)
		{
			currentFilterIndex = -1;
		}
		UpdateFilterButtonText();
		ApplyFilter();
	}

	private void UpdateFilterButtonText()
	{
		if (!(filterButtonText == null))
		{
			if (currentFilterIndex == -1)
			{
				string translation = LocalizationManager.GetTranslation("FilterType_All");
				filterButtonText.text = ((!string.IsNullOrEmpty(translation)) ? translation : "NL- All");
			}
			else
			{
				FilterType filterType = (FilterType)currentFilterIndex;
				string translation2 = LocalizationManager.GetTranslation("FilterType_" + filterType);
				filterButtonText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : ("NL- " + filterType));
			}
		}
	}

	public void ApplyFilter()
	{
		foreach (StockSellItemUI spawnedStockItem in _spawnedStockItems)
		{
			if (spawnedStockItem == null)
			{
				continue;
			}
			if (currentFilterIndex == -1)
			{
				spawnedStockItem.gameObject.SetActive(value: true);
				continue;
			}
			FilterType item = (FilterType)currentFilterIndex;
			T_ItemSO itemSO = spawnedStockItem.ItemSO;
			if (itemSO != null && itemSO.FilterTypes != null)
			{
				spawnedStockItem.gameObject.SetActive(itemSO.FilterTypes.Contains(item));
			}
			else
			{
				spawnedStockItem.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetFilter()
	{
		currentFilterIndex = -1;
		UpdateFilterButtonText();
		ApplyFilter();
	}

	public void ClearSelection()
	{
		_selectedItem = null;
		_selectedItemId = null;
		stockSellManager?.RequestClearSelection();
		UpdateStockItemSelectionStates();
		RefreshOfferList();
		HideSelectedItemPanel();
	}

	public void ShowHoverPanel(T_ItemSO itemSO, RectTransform targetRect)
	{
		if (hoverPanel != null)
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

	private void ShowSelectedItemPanel()
	{
		if (_selectedItem == null)
		{
			HideSelectedItemPanel();
			return;
		}
		if (selectedItemPanelRoot != null)
		{
			selectedItemPanelRoot.SetActive(value: true);
		}
		if (selectedItemIcon != null)
		{
			selectedItemIcon.sprite = _selectedItem.Icon;
			selectedItemIcon.gameObject.SetActive(_selectedItem.Icon != null);
		}
		if (selectedItemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(_selectedItem.Name);
			selectedItemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _selectedItem.Name);
		}
		UpdateSelectedItemStock();
	}

	private void HideSelectedItemPanel()
	{
		if (selectedItemPanelRoot != null)
		{
			selectedItemPanelRoot.SetActive(value: false);
		}
	}

	private void UpdateSelectedItemStock()
	{
		if (selectedItemStockText != null && !string.IsNullOrEmpty(_selectedItemId))
		{
			int stockCountForItem = GetStockCountForItem(_selectedItemId);
			selectedItemStockText.text = $"x{stockCountForItem}";
		}
	}

	private void SetupSellingDetailsPanelButtons()
	{
		if (quantitySlider != null)
		{
			quantitySlider.onValueChanged.AddListener(OnQuantitySliderChanged);
		}
	}

	private void CleanupSellingDetailsPanelButtons()
	{
		if (quantitySlider != null)
		{
			quantitySlider.onValueChanged.RemoveListener(OnQuantitySliderChanged);
		}
	}

	private void OnOfferInspectClicked(StockDemandData offer)
	{
		if (!offer.IsValid)
		{
			return;
		}
		T_ItemSO t_ItemSO = stockSellManager?.FindItemById(offer.itemId);
		if (t_ItemSO == null)
		{
			Debug.LogWarning("[ComputerStockSellUI] Item bulunamadı: " + offer.itemId);
			return;
		}
		ShowSellingDetailsPanel(offer, t_ItemSO);
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.StockSellAndContract, TutorialStepType.StockSell, TutorialSubStepType.SelectOffer);
		}
	}

	private int GetEffectiveMinSliderValue()
	{
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			return 6;
		}
		return minSliderValue;
	}

	public void ShowSellingDetailsPanel(StockDemandData offer, T_ItemSO item)
	{
		if (!offer.IsValid || item == null)
		{
			return;
		}
		if (GetStockCountForItem(offer.itemId) < GetEffectiveMinSliderValue())
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_StocksellWarningLowStock"), isComputer: true);
			}
		}
		else
		{
			_currentOffer = offer;
			_currentOfferItem = item;
			SetupQuantitySlider();
			UpdateSellingDetailsPanelUI();
			SetSellingDetailsPanelVisible(visible: true);
		}
	}

	public void HideSellingDetailsPanel()
	{
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && TutorialManager.Instance.CurrentSubStep == TutorialSubStepType.SellToOfferTarget)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"), isComputer: true);
			}
		}
		else
		{
			SetSellingDetailsPanelVisible(visible: false);
			_currentOffer = default(StockDemandData);
			_currentOfferItem = null;
		}
	}

	private void SetSellingDetailsPanelVisible(bool visible)
	{
		if (sellingDetailsPanelRoot != null)
		{
			sellingDetailsPanelRoot.SetActive(visible);
		}
	}

	private void SetupQuantitySlider()
	{
		if (!(quantitySlider == null))
		{
			int num = Mathf.Min(GetStockCountForItem(_currentOffer.itemId), _currentOffer.demandedAmount);
			int num2 = Mathf.Min(GetEffectiveMinSliderValue(), num);
			if (num2 > num)
			{
				num2 = num;
			}
			quantitySlider.minValue = num2;
			quantitySlider.maxValue = num;
			quantitySlider.wholeNumbers = true;
			quantitySlider.value = num;
			_selectedQuantity = num;
		}
	}

	private void UpdateSellingDetailsPanelUI()
	{
		if (_currentOffer.IsValid)
		{
			if (detailItemIcon != null && _currentOfferItem != null)
			{
				detailItemIcon.sprite = _currentOfferItem.Icon;
				detailItemIcon.gameObject.SetActive(_currentOfferItem.Icon != null);
			}
			if (detailItemNameText != null && _currentOfferItem != null)
			{
				string translation = LocalizationManager.GetTranslation(_currentOfferItem.Name);
				detailItemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _currentOfferItem.Name);
			}
			if (detailCompanyNameText != null)
			{
				detailCompanyNameText.text = _currentOffer.companyName;
			}
			if (detailQuantityText != null)
			{
				detailQuantityText.text = $"x{_currentOffer.demandedAmount}";
			}
			if (detailUnitPriceText != null)
			{
				detailUnitPriceText.text = $"{_currentOffer.pricePerUnit:N0}";
			}
			if (detailTotalPriceText != null)
			{
				detailTotalPriceText.text = $"{_currentOffer.TotalPrice:N0}";
			}
			if (currentStockText != null)
			{
				int stockCountForItem = GetStockCountForItem(_currentOffer.itemId);
				currentStockText.text = $"x{stockCountForItem}";
			}
			UpdateSliderUI();
			UpdateSellButtonState();
		}
	}

	private void UpdateSliderUI()
	{
		if (sliderValueText != null)
		{
			sliderValueText.text = $"x{_selectedQuantity}";
		}
		if (currentPriceText != null)
		{
			int num = _selectedQuantity * _currentOffer.pricePerUnit;
			currentPriceText.text = $"{num:N0}";
		}
	}

	private void UpdateSellButtonState()
	{
	}

	private void OnQuantitySliderChanged(float value)
	{
		_selectedQuantity = Mathf.RoundToInt(value);
		UpdateSliderUI();
		UpdateSellButtonState();
	}

	public void OnSellButtonClicked()
	{
		Debug.Log($"[ComputerStockSellUI] OnSellButtonClicked - IsValid: {_currentOffer.IsValid}, SelectedQuantity: {_selectedQuantity}, DemandId: {_currentOffer.demandId}");
		if (!_currentOffer.IsValid)
		{
			Debug.LogWarning("[ComputerStockSellUI] CurrentOffer geçersiz!");
			return;
		}
		if (_selectedQuantity <= 0)
		{
			Debug.LogWarning("[ComputerStockSellUI] SelectedQuantity 0 veya negatif!");
			return;
		}
		if (stockSellManager == null)
		{
			Debug.LogWarning("[ComputerStockSellUI] stockSellManager null!");
			return;
		}
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryAddSubStepProgress(TutorialConfigType.StockSellAndContract, TutorialStepType.StockSell, TutorialSubStepType.SellToOfferTarget, _selectedQuantity);
		}
		GameManager.Instance.UImanager.computerUI.CloseAllMasks();
		stockSellManager.RequestAcceptPartialDemand(_currentOffer.demandId, _selectedQuantity);
		HideSellingDetailsPanel();
	}
}
