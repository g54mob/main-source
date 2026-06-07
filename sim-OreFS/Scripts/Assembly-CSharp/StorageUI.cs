using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StorageUI : MonoBehaviour
{
	[Header("Panel")]
	public GameObject storagePanel;

	public Button closeButton;

	[Header("Info")]
	public TextMeshProUGUI totalItemCountText;

	public TextMeshProUGUI uniqueItemCountText;

	public TextMeshProUGUI totalCountText;

	[Header("Content")]
	public Transform storageContent;

	public GameObject storageItemPrefab;

	[Header("References")]
	public OutputUI outputUI;

	public StorageManager storageManager;

	public T_SortingOutput sortingOutput;

	public PickerUI pickerUI;

	[Header("Selected Item Button")]
	[SerializeField]
	private GameObject selectedItemButton;

	[Header("Filter")]
	[SerializeField]
	private TextMeshProUGUI filterButtonText;

	[Header("Input Actions")]
	[SerializeField]
	private InputActionReference leftAction;

	[SerializeField]
	private InputActionReference rightAction;

	private readonly List<StorageItemUI> itemUIList = new List<StorageItemUI>();

	private readonly Dictionary<string, StorageItemUI> itemUIDict = new Dictionary<string, StorageItemUI>();

	private int currentFilterIndex = -1;

	private static readonly int filterTypeCount = Enum.GetValues(typeof(FilterType)).Length;

	private void Awake()
	{
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(CloseUI);
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storagePanel != null)
		{
			storagePanel.SetActive(value: false);
		}
		SetSelectedItemButtonActive(active: false);
	}

	private void OnEnable()
	{
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.AddListener(RefreshItemList);
		}
	}

	private void OnDisable()
	{
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.RemoveListener(RefreshItemList);
		}
	}

	public void OpenUI(T_SortingOutput output = null)
	{
		_ = sortingOutput != output;
		sortingOutput = output;
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			Debug.LogError("StorageUI: StorageManager bulunamadı! GameManager'da StorageManager referansı atanmamış olabilir.");
			return;
		}
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.RemoveListener(RefreshItemList);
			storageManager.OnStorageChanged.AddListener(RefreshItemList);
		}
		if (storagePanel != null)
		{
			storagePanel.SetActive(value: true);
		}
		EnableInputActions();
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent -= OnSelectedItemChangedFromServer;
			sortingOutput.OnSelectedItemChangedEvent += OnSelectedItemChangedFromServer;
		}
		ResetFilter();
		RefreshItemList();
		UpdateInfo();
		UpdateSelectedItemButton();
		if (outputUI != null)
		{
			outputUI.SetSortingOutput(sortingOutput);
		}
		GameManager.Instance.UImanager.lastOpenedUITab = base.gameObject;
	}

	public void CloseUI()
	{
		if (sortingOutput != null)
		{
			sortingOutput.TriggerOnUIClosed();
		}
		if (storagePanel != null)
		{
			storagePanel.SetActive(value: false);
		}
		DisableInputActions();
		if (sortingOutput != null)
		{
			sortingOutput.OnSelectedItemChangedEvent -= OnSelectedItemChangedFromServer;
		}
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.RemoveListener(RefreshItemList);
		}
	}

	public void RefreshItemList()
	{
		if (storagePanel == null || !storagePanel.activeSelf || storageManager == null)
		{
			return;
		}
		Dictionary<string, int> storedItemCounts = storageManager.GetStoredItemCounts();
		ClearItemList();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			UpdateInfo();
			return;
		}
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			string key = item.Key;
			int value = item.Value;
			T_ItemSO t_ItemSO = ResolveItem(key);
			if (!(t_ItemSO == null))
			{
				CreateItemEntry(t_ItemSO, value);
			}
		}
		UpdateInfo();
		ApplyFilter();
	}

	private void CreateItemEntry(T_ItemSO item, int count)
	{
		if (storageItemPrefab == null || storageContent == null)
		{
			Debug.LogError("StorageUI: Prefab veya content atanmadı!");
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(storageItemPrefab, storageContent);
		StorageItemUI component = gameObject.GetComponent<StorageItemUI>();
		if (component == null)
		{
			Debug.LogError("StorageUI: StorageItemUI component'i bulunamadı! Prefab'da StorageItemUI olmalı.");
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		component.Initialize(item, count);
		component.OnSendToBeltRequested = (Action<T_ItemSO>)Delegate.Combine(component.OnSendToBeltRequested, new Action<T_ItemSO>(OnSendToBeltRequested));
		component.OnTakeAsSackRequested = (Action<T_ItemSO>)Delegate.Combine(component.OnTakeAsSackRequested, new Action<T_ItemSO>(OnTakeAsSackRequested));
		itemUIList.Add(component);
		itemUIDict[item.GetItemID()] = component;
	}

	private void ClearItemList()
	{
		foreach (StorageItemUI itemUI in itemUIList)
		{
			if (itemUI != null)
			{
				itemUI.OnSendToBeltRequested = (Action<T_ItemSO>)Delegate.Remove(itemUI.OnSendToBeltRequested, new Action<T_ItemSO>(OnSendToBeltRequested));
				itemUI.OnTakeAsSackRequested = (Action<T_ItemSO>)Delegate.Remove(itemUI.OnTakeAsSackRequested, new Action<T_ItemSO>(OnTakeAsSackRequested));
				UnityEngine.Object.Destroy(itemUI.gameObject);
			}
		}
		itemUIList.Clear();
		itemUIDict.Clear();
	}

	private void UpdateInfo()
	{
		if (!(storageManager == null))
		{
			if (totalItemCountText != null)
			{
				totalItemCountText.text = $"Total Items: {storageManager.ItemCount}";
			}
			if (uniqueItemCountText != null)
			{
				uniqueItemCountText.text = $"Unique Items: {storageManager.UniqueItemCount}";
			}
			if (totalCountText != null)
			{
				totalCountText.text = $"Total: {storageManager.ItemCount}";
			}
		}
	}

	private void OnSendToBeltRequested(T_ItemSO item)
	{
		if (!(item == null) && !(storageManager == null) && !(sortingOutput == null))
		{
			sortingOutput.SetSelectedItem(item);
			UpdateSelectedItemButton();
			int itemCount = storageManager.GetItemCount(item);
			if (itemCount > 0)
			{
				sortingOutput.RequestSpawnItem(item, itemCount);
				StartCoroutine(RefreshItemListDelayed());
			}
		}
	}

	private void OnTakeAsSackRequested(T_ItemSO item)
	{
		if (item == null || storageManager == null || sortingOutput == null)
		{
			return;
		}
		int itemCount = storageManager.GetItemCount(item);
		if (itemCount <= 0)
		{
			return;
		}
		if (NetworkClient.localPlayer != null && GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				T_Pickup component = pickupItem.GetComponent<T_Pickup>();
				if (component != null && (component.itemType == ItemType.Building || component.itemType == ItemType.Pickup))
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotPickupAvailable"));
					return;
				}
			}
		}
		if (pickerUI != null)
		{
			pickerUI.OpenUI(item, itemCount, delegate(T_ItemSO selectedItem, int quantity)
			{
				sortingOutput.RequestSpawnSack(selectedItem, quantity);
				StartCoroutine(RefreshItemListDelayed());
			});
		}
		else
		{
			Debug.LogWarning("StorageUI: PickerUI referansı atanmamış!");
		}
	}

	private IEnumerator RefreshItemListDelayed()
	{
		yield return null;
		yield return null;
		RefreshItemList();
	}

	private T_ItemSO ResolveItem(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetItemSOById(itemId);
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == itemId);
		}
		return null;
	}

	private void SetSelectedItemButtonActive(bool active)
	{
		if (selectedItemButton != null)
		{
			selectedItemButton.SetActive(active);
		}
	}

	private void UpdateSelectedItemButton()
	{
		bool selectedItemButtonActive = sortingOutput != null && sortingOutput.GetSelectedItem() != null;
		SetSelectedItemButtonActive(selectedItemButtonActive);
	}

	private void EnableInputActions()
	{
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.Enable();
		}
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.Enable();
		}
	}

	private void DisableInputActions()
	{
		if (leftAction != null && leftAction.action != null)
		{
			leftAction.action.Disable();
		}
		if (rightAction != null && rightAction.action != null)
		{
			rightAction.action.Disable();
		}
	}

	private void OnSelectedItemChangedFromServer(T_ItemSO item)
	{
		UpdateSelectedItemButton();
	}

	public void SetStorageManager(StorageManager manager)
	{
		storageManager = manager;
	}

	public void SetSortingOutput(T_SortingOutput output)
	{
		sortingOutput = output;
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
		foreach (StorageItemUI itemUI in itemUIList)
		{
			if (itemUI == null)
			{
				continue;
			}
			if (currentFilterIndex == -1)
			{
				itemUI.gameObject.SetActive(value: true);
				continue;
			}
			FilterType item = (FilterType)currentFilterIndex;
			T_ItemSO itemSO = itemUI.GetItemSO();
			if (itemSO != null && itemSO.FilterTypes != null)
			{
				itemUI.gameObject.SetActive(itemSO.FilterTypes.Contains(item));
			}
			else
			{
				itemUI.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetFilter()
	{
		currentFilterIndex = -1;
		UpdateFilterButtonText();
		ApplyFilter();
	}
}
