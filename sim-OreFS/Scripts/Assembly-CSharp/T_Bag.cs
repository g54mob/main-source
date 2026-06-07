using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using I2.Loc;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class T_Bag : MonoBehaviour
{
	[Header("Bag Settings")]
	[Tooltip("Temel maksimum kapasite - Çantanın başlangıç item kapasitesi")]
	[SerializeField]
	private int baseMaxCapacity = 100;

	[Tooltip("Mevcut maksimum kapasite - Çantanın şu anki item kapasitesi (otomatik hesaplanır)")]
	[SerializeField]
	private int maxCapacity;

	[Tooltip("Kapasite seviyeleri listesi - Çanta upgrade edildiğinde kullanılacak kapasite değerleri")]
	[SerializeField]
	private List<int> maxCapacityLevels = new List<int>();

	[Tooltip("Mevcut maksimum kapasite indeksi - Hangi seviyede olduğunu belirler (0 = ilk seviye)")]
	[SerializeField]
	private int currentMaxCapacityIndex;

	[Header("Sack Conversion")]
	[Tooltip("Çuval prefab'ı - Çantadan fırlatılacak çuval objesi")]
	[SerializeField]
	private GameObject sackPrefab;

	[Tooltip("Fırlatma noktası - Çuvalın hangi noktadan fırlatılacağını belirler (boşsa bag'in transform'u kullanılır)")]
	public Transform throwPoint;

	[Tooltip("Fırlatma kuvveti - Çuvalın ne kadar güçlü fırlatılacağını belirler. Daha yüksek değer = daha uzağa fırlar")]
	public float throwForce = 10f;

	[Tooltip("Fırlatma açısı (derece) - Çuvalın hangi açıyla fırlatılacağını belirler. 0° = yatay, 30-45° = bombeli (önerilen), 90° = dikey")]
	public float throwAngle = 30f;

	[Tooltip("Yukarı doğru fırlatma katsayısı (0-1) - useThrowAngle false ise kullanılır. Daha yüksek = daha dik fırlatma")]
	public float throwUpwardForce = 0.3f;

	[Tooltip("Açı kullan - true ise throwAngle kullanılır (önerilen), false ise throwUpwardForce kullanılır")]
	public bool useThrowAngle = true;

	[Tooltip("Spawn ileri ofset - Çuvalın player'ın önünde ne kadar ileri spawn olacağını belirler (birim cinsinden)")]
	public float spawnForwardOffset = 0.5f;

	[Tooltip("Raycast başlangıç yüksekliği - Terrain bulmak için raycast'in başladığı yükseklik (birim cinsinden)")]
	public float raycastStartHeight = 10f;

	[Tooltip("Raycast mesafesi - Terrain aramak için raycast'in ne kadar mesafe arayacağını belirler (birim cinsinden)")]
	public float raycastDistance = 20f;

	[Tooltip("Yerden yükseklik - Çuvalın yerden ne kadar yüksekte spawn olacağını belirler (birim cinsinden)")]
	public float groundOffset = 0.5f;

	[Header("Current State")]
	[Tooltip("Çantadaki itemler listesi - Çantada bulunan tüm itemler (runtime'da otomatik güncellenir)")]
	[SerializeField]
	private List<T_ItemSO> items = new List<T_ItemSO>();

	[Header("Test")]
	public bool enabledTestInputs;

	[Tooltip("Test itemleri listesi - Her entry bir item ve Y tuşu için adet içerir. T tuşu her itemden 1 adet ekler.")]
	[SerializeField]
	private List<TestItemEntry> testItems = new List<TestItemEntry>();

	[Header("Network")]
	[Tooltip("GamePlayer referansı - Network Command'ları için gerekli (otomatik bulunur, manuel atama gerekmez)")]
	[SerializeField]
	public GamePlayer gamePlayer;

	private bool isLocalPlayerBag;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	[Header("Events")]
	public UnityEvent<T_ItemSO> OnItemAdded;

	public UnityEvent<T_ItemSO> OnItemRemoved;

	public UnityEvent<int, int> OnCapacityChanged;

	public UnityEvent<int> OnMaxCapacityUpgraded;

	public UnityEvent OnConvertedToSack;

	public GameManager gameManager;

	private Dictionary<T_ItemSO, int> _pendingNotifications = new Dictionary<T_ItemSO, int>();

	private bool _notificationCoroutineRunning;

	private bool _syncPending;

	private Coroutine _syncCoroutine;

	private const float SYNC_DELAY = 0.5f;

	public int MaxCapacity => maxCapacity;

	public int CurrentItemCount => items.Count;

	public int ItemCount => items.Count;

	public List<T_ItemSO> Items => new List<T_ItemSO>(items);

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			Debug.Log("[T_Bag] " + message);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(OnEnableActions());
	}

	private IEnumerator OnEnableActions()
	{
		yield return new WaitForSeconds(0.5f);
		CheckIfLocalPlayer();
		if (isLocalPlayerBag)
		{
			if (GameManager.Instance != null && GameManager.Instance.localBag == null)
			{
				GameManager.Instance.localBag = this;
			}
			yield return new WaitForSeconds(0.2f);
			RequestBagLoadFromServer();
		}
	}

	private void CheckIfLocalPlayer()
	{
		GamePlayer componentInParent = GetComponentInParent<GamePlayer>();
		if (componentInParent != null)
		{
			isLocalPlayerBag = componentInParent.isLocalPlayer;
		}
		else if (NetworkClient.localPlayer != null)
		{
			Transform parent = base.transform.parent;
			if (parent != null)
			{
				isLocalPlayerBag = parent.gameObject == NetworkClient.localPlayer.gameObject || parent.gameObject.transform.IsChildOf(NetworkClient.localPlayer.transform);
			}
			else
			{
				isLocalPlayerBag = base.gameObject == NetworkClient.localPlayer.gameObject;
			}
		}
		else
		{
			isLocalPlayerBag = false;
		}
		if (gamePlayer == null && componentInParent != null)
		{
			gamePlayer = componentInParent;
		}
	}

	private void Update()
	{
	}

	private void Awake()
	{
		if (gameManager == null)
		{
			gameManager = GameManager.Instance;
		}
		if (maxCapacityLevels != null && maxCapacityLevels.Count > 0)
		{
			ApplyMaxCapacityFromIndex();
		}
		else
		{
			maxCapacity = baseMaxCapacity;
		}
		UpdateSlider();
		if (throwPoint == null)
		{
			throwPoint = base.transform;
		}
	}

	public float GetFillRatio()
	{
		if (maxCapacity <= 0)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)items.Count / (float)maxCapacity);
	}

	public float GetFillPercentage()
	{
		return GetFillRatio() * 100f;
	}

	private void ApplyMaxCapacityFromIndex()
	{
		if (maxCapacityLevels != null && maxCapacityLevels.Count != 0)
		{
			currentMaxCapacityIndex = Mathf.Clamp(currentMaxCapacityIndex, 0, maxCapacityLevels.Count - 1);
			int num = Mathf.Max(1, maxCapacityLevels[currentMaxCapacityIndex]);
			maxCapacity = num;
			DebugLog($"Max capacity set from index {currentMaxCapacityIndex}: {maxCapacity}");
			OnMaxCapacityUpgraded?.Invoke(maxCapacity);
			OnCapacityChanged?.Invoke(items.Count, maxCapacity);
			UpdateSlider();
		}
	}

	public void SetMaxCapacityIndex(int index)
	{
		currentMaxCapacityIndex = index;
		ApplyMaxCapacityFromIndex();
	}

	public void NextMaxCapacityLevel()
	{
		SetMaxCapacityIndex(currentMaxCapacityIndex + 1);
	}

	public void PrevMaxCapacityLevel()
	{
		SetMaxCapacityIndex(currentMaxCapacityIndex - 1);
	}

	public void ShowBagUI(bool set)
	{
		if (gameManager == null)
		{
			if (GameManager.Instance == null)
			{
				Debug.LogError("T_Bag: ShowBagUI - GameManager.Instance null!");
				return;
			}
			gameManager = GameManager.Instance;
		}
		if (gameManager.UImanager.bagUI == null)
		{
			Debug.LogWarning("T_Bag: ShowBagUI - bagUI atanmamış!");
			return;
		}
		bool flag = set;
		gameManager.UImanager.bagUI.bagPanel.SetActive(flag);
		gameManager.UImanager.bagUI.bagButton.SetActive(!flag);
		if (flag)
		{
			gameManager.UImanager.lastOpenedUITab = gameManager.localBag.gameObject;
			RefreshBagUI();
			gameManager.UImanager.bagUI.ResetFilter();
			gameManager.UImanager.bagUI.UpdateFillInfo(items.Count, maxCapacity);
			gameManager.UImanager.bagUI.EnableInputActions();
		}
		else
		{
			gameManager.UImanager.bagUI.DisableInputActions();
		}
	}

	private void UpdateSlider()
	{
		if (gameManager == null)
		{
			if (!(GameManager.Instance != null))
			{
				return;
			}
			gameManager = GameManager.Instance;
		}
		if (gameManager.UImanager.bagUI != null)
		{
			if (gameManager.UImanager.bagUI.bagFillSlider != null)
			{
				gameManager.UImanager.bagUI.bagFillSlider.value = GetFillRatio();
			}
			gameManager.UImanager.bagUI.UpdateFillInfo(items.Count, maxCapacity);
		}
	}

	private void RefreshBagUIIfOpen()
	{
		if (!isLocalPlayerBag)
		{
			return;
		}
		if (gameManager == null)
		{
			if (GameManager.Instance == null)
			{
				return;
			}
			gameManager = GameManager.Instance;
		}
		if (!(gameManager.UImanager?.bagUI == null) && gameManager.UImanager.bagUI.bagPanel != null && gameManager.UImanager.bagUI.bagPanel.activeSelf)
		{
			RefreshBagUI();
		}
	}

	private void RefreshBagUI()
	{
		if (gameManager == null)
		{
			if (GameManager.Instance == null)
			{
				Debug.LogError("T_Bag: RefreshBagUI - GameManager.Instance null!");
				return;
			}
			gameManager = GameManager.Instance;
		}
		if (gameManager.UImanager.bagUI == null)
		{
			Debug.LogWarning("T_Bag: RefreshBagUI - bagUI atanmamış!");
			return;
		}
		if (gameManager.UImanager.bagUI.bagScrollContent == null)
		{
			Debug.LogWarning("T_Bag: bagScrollContent atanmamış!");
			return;
		}
		if (gameManager.UImanager.bagUI.bagItemEntryPrefab == null)
		{
			Debug.LogWarning("T_Bag: bagItemEntryPrefab atanmamış!");
			return;
		}
		for (int num = gameManager.UImanager.bagUI.bagScrollContent.childCount - 1; num >= 0; num--)
		{
			Transform child = gameManager.UImanager.bagUI.bagScrollContent.GetChild(num);
			if (child != null)
			{
				Object.Destroy(child.gameObject);
			}
		}
		if (items == null || items.Count == 0)
		{
			return;
		}
		foreach (var item in from i in items
			group i by i into g
			select new
			{
				Item = g.Key,
				Count = g.Count()
			})
		{
			Component component = Object.Instantiate(gameManager.UImanager.bagUI.bagItemEntryPrefab, gameManager.UImanager.bagUI.bagScrollContent).GetComponent("BagItemUI");
			if (component != null)
			{
				MethodInfo method = component.GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Public);
				if (method != null)
				{
					method.Invoke(component, new object[2] { item.Item, item.Count });
				}
			}
			else
			{
				Debug.LogWarning("T_Bag: bagItemEntryPrefab üzerinde BagItemUI component'i bulunamadı!");
			}
		}
		gameManager.UImanager.bagUI.UpdateFillInfo(items.Count, maxCapacity);
	}

	public bool CanAddItem(T_ItemSO item)
	{
		if (item == null)
		{
			Debug.LogWarning("T_Bag: Item null, eklenemez!");
			return false;
		}
		return items.Count < maxCapacity;
	}

	public bool AddItem(T_ItemSO item, bool countForTutorial = true)
	{
		if (!CanAddItem(item))
		{
			DebugLog($"Cannot add '{item.Name}' - bag full (current: {items.Count}/{maxCapacity})");
			if (gameManager.notificationManager != null)
			{
				gameManager.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_BagFullKey"));
			}
			return false;
		}
		items.Add(item);
		DebugLog($"Item added: '{item.Name}' (count: {items.Count}/{maxCapacity})");
		OnItemAdded?.Invoke(item);
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		if (item.Type == PickupType.Ore && countForTutorial && TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TrySetTutorialLockedItem(item.GetItemID());
			TutorialManager.Instance.TryAddSubStepProgress(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.MineOreTarget);
		}
		RefreshBagUIIfOpen();
		QueueNotification(item, 1);
		SyncBagToServer();
		return true;
	}

	public bool RemoveItem(T_ItemSO item)
	{
		if (item == null || !items.Contains(item))
		{
			Debug.LogWarning("T_Bag: Kaldırılmak istenen item çantada bulunamadı!");
			return false;
		}
		items.Remove(item);
		DebugLog($"Item removed: '{item.Name}' (count: {items.Count}/{maxCapacity})");
		OnItemRemoved?.Invoke(item);
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		RefreshBagUIIfOpen();
		QueueNotification(item, -1);
		SyncBagToServer();
		return true;
	}

	private void QueueNotification(T_ItemSO item, int amount)
	{
		if (isLocalPlayerBag && !(item == null))
		{
			if (_pendingNotifications.ContainsKey(item))
			{
				_pendingNotifications[item] += amount;
			}
			else
			{
				_pendingNotifications[item] = amount;
			}
			if (!_notificationCoroutineRunning)
			{
				StartCoroutine(SendPendingNotificationsEndOfFrame());
			}
		}
	}

	private IEnumerator SendPendingNotificationsEndOfFrame()
	{
		_notificationCoroutineRunning = true;
		yield return new WaitForEndOfFrame();
		if (ItemNotificationManager.Instance != null)
		{
			foreach (KeyValuePair<T_ItemSO, int> pendingNotification in _pendingNotifications)
			{
				if (pendingNotification.Key != null && pendingNotification.Value != 0)
				{
					ItemNotificationManager.Instance.ShowItemNotification(pendingNotification.Key, pendingNotification.Value);
				}
			}
		}
		_pendingNotifications.Clear();
		_notificationCoroutineRunning = false;
	}

	public bool RemoveItemBySO(T_ItemSO itemSO)
	{
		if (itemSO == null)
		{
			return false;
		}
		T_ItemSO t_ItemSO = items.FirstOrDefault((T_ItemSO i) => i == itemSO);
		if (t_ItemSO != null)
		{
			return RemoveItem(t_ItemSO);
		}
		return false;
	}

	private void ShowBatchRemoveNotification(List<T_ItemSO> removedItems)
	{
		if (!isLocalPlayerBag || ItemNotificationManager.Instance == null || removedItems == null || removedItems.Count == 0)
		{
			return;
		}
		foreach (var item in from i in removedItems
			where i != null
			group i by i into g
			select new
			{
				Item = g.Key,
				Count = g.Count()
			})
		{
			ItemNotificationManager.Instance.ShowItemNotification(item.Item, -item.Count);
		}
	}

	public int GetItemCount(T_ItemSO itemSO)
	{
		if (itemSO == null)
		{
			return 0;
		}
		return items.Count((T_ItemSO i) => i == itemSO);
	}

	public void UpgradeMaxCapacity(int additionalCapacity)
	{
		if (additionalCapacity <= 0)
		{
			Debug.LogWarning("T_Bag: Upgrade değeri 0'dan büyük olmalı!");
			return;
		}
		maxCapacity += additionalCapacity;
		DebugLog($"Max capacity upgraded by {additionalCapacity}, new max: {maxCapacity}");
		OnMaxCapacityUpgraded?.Invoke(maxCapacity);
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
	}

	public void SetMaxCapacity(int newMaxCapacity)
	{
		if (newMaxCapacity <= 0)
		{
			Debug.LogWarning("T_Bag: Max kapasite 0'dan büyük olmalı!");
			return;
		}
		maxCapacity = newMaxCapacity;
		if (items.Count > maxCapacity)
		{
			Debug.LogWarning($"T_Bag: Dikkat! Mevcut item sayısı ({items.Count}) max kapasiteyi ({maxCapacity}) aşıyor!");
		}
		OnMaxCapacityUpgraded?.Invoke(maxCapacity);
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
	}

	public void Clear()
	{
		items.Clear();
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		SyncBagToServer();
	}

	public void RemoveHalfItems()
	{
		if (items == null || items.Count == 0)
		{
			return;
		}
		foreach (var item in (from i in items
			group i by i into g
			select new
			{
				Item = g.Key,
				Count = g.Count()
			}).ToList())
		{
			int num = item.Count / 2;
			for (int num2 = 0; num2 < num; num2++)
			{
				RemoveItem(item.Item);
			}
		}
		Debug.Log($"[T_Bag] RemoveHalfItems - Çantadan %50 item silindi. Kalan: {items.Count}");
	}

	public bool HasSpaceFor(int count)
	{
		return items.Count + count <= maxCapacity;
	}

	public int ConvertToSack()
	{
		if (items.Count == 0)
		{
			Debug.LogWarning("T_Bag: Çanta boş, çuvala dönüştürülemez!");
			return 0;
		}
		if (sackPrefab == null)
		{
			Debug.LogError("T_Bag: Sack prefab atanmamış!");
			return 0;
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
					return 0;
				}
			}
		}
		if (NetworkServer.active)
		{
			int num = Mathf.Min(items.Count, T_Sack.MaxItemsPerSack);
			List<T_ItemSO> range = items.GetRange(0, num);
			DebugLog($"Converting bag to sack (server path) with {range.Count} items (bag had {items.Count})");
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				items.RemoveAt(num2);
			}
			OnCapacityChanged?.Invoke(items.Count, maxCapacity);
			UpdateSlider();
			ShowBatchRemoveNotification(range);
			if (isLocalPlayerBag)
			{
				RefreshBagUI();
			}
			SyncBagToServer();
			NetworkConnectionToClient localConnection = NetworkServer.localConnection;
			SpawnAndPickupSack(range, localConnection);
			OnConvertedToSack?.Invoke();
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutOreInSack);
			}
			return num;
		}
		if (gamePlayer == null)
		{
			if (NetworkClient.localPlayer != null)
			{
				gamePlayer = NetworkClient.localPlayer.GetComponent<GamePlayer>();
			}
			if (gamePlayer == null)
			{
				gamePlayer = Object.FindFirstObjectByType<GamePlayer>();
			}
			if (gamePlayer == null)
			{
				Debug.LogError("T_Bag: GamePlayer bulunamadı! Command gönderilemiyor.");
				return 0;
			}
		}
		int num3 = Mathf.Min(items.Count, T_Sack.MaxItemsPerSack);
		List<string> list = (from item in items.Take(num3)
			where item != null
			select item.GetItemID() into id
			where !string.IsNullOrEmpty(id)
			select id).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("T_Bag: Çantada geçerli item ID'si bulunamadı!");
			return 0;
		}
		List<T_ItemSO> range2 = items.GetRange(0, num3);
		DebugLog($"Converting bag to sack (client path) with {range2.Count} items (bag had {items.Count})");
		gamePlayer.CmdConvertBagToSack(list);
		for (int num4 = num3 - 1; num4 >= 0; num4--)
		{
			items.RemoveAt(num4);
		}
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		ShowBatchRemoveNotification(range2);
		if (isLocalPlayerBag)
		{
			RefreshBagUI();
		}
		OnConvertedToSack?.Invoke();
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutOreInSack);
		}
		return num3;
	}

	public void ServerConvertToSack(List<T_ItemSO> itemsToTransfer, NetworkConnectionToClient sender = null)
	{
		if (itemsToTransfer == null || itemsToTransfer.Count == 0)
		{
			Debug.LogWarning("T_Bag: ServerConvertToSack - Item listesi boş!");
			return;
		}
		int num = Mathf.Min(itemsToTransfer.Count, T_Sack.MaxItemsPerSack);
		if (num < itemsToTransfer.Count)
		{
			itemsToTransfer = itemsToTransfer.GetRange(0, num);
		}
		foreach (T_ItemSO item in itemsToTransfer)
		{
			items.Remove(item);
		}
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		SyncBagToServer();
		SpawnAndPickupSack(itemsToTransfer, sender);
		OnConvertedToSack?.Invoke();
	}

	public void ConvertItemTypeToSack(T_ItemSO itemType)
	{
		if (itemType == null)
		{
			Debug.LogWarning("T_Bag: ConvertItemTypeToSack - ItemType null!");
			return;
		}
		List<T_ItemSO> list = items.Where((T_ItemSO i) => i == itemType).Take(T_Sack.MaxItemsPerSack).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("T_Bag: Çantada '" + itemType.Name + "' türünde item bulunamadı!");
			return;
		}
		if (sackPrefab == null)
		{
			Debug.LogError("T_Bag: Sack prefab atanmamış!");
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
		if (NetworkServer.active)
		{
			foreach (T_ItemSO item in list)
			{
				RemoveItem(item);
			}
			if (isLocalPlayerBag)
			{
				RefreshBagUI();
			}
			NetworkConnectionToClient localConnection = NetworkServer.localConnection;
			SpawnAndPickupSack(list, localConnection);
			OnConvertedToSack?.Invoke();
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutOreInSack);
			}
			return;
		}
		if (gamePlayer == null)
		{
			if (NetworkClient.localPlayer != null)
			{
				gamePlayer = NetworkClient.localPlayer.GetComponent<GamePlayer>();
			}
			if (gamePlayer == null)
			{
				gamePlayer = Object.FindFirstObjectByType<GamePlayer>();
			}
			if (gamePlayer == null)
			{
				Debug.LogError("T_Bag: GamePlayer bulunamadı! Command gönderilemiyor.");
				return;
			}
		}
		List<string> list2 = (from item in list
			select (!(item != null)) ? null : item.GetItemID() into id
			where !string.IsNullOrEmpty(id)
			select id).ToList();
		if (list2.Count == 0)
		{
			Debug.LogWarning("T_Bag: Çantada geçerli item ID'si bulunamadı!");
			return;
		}
		gamePlayer.CmdConvertItemTypeToSack(itemType.GetItemID(), list2);
		foreach (T_ItemSO item2 in list)
		{
			RemoveItem(item2);
		}
		if (isLocalPlayerBag)
		{
			RefreshBagUI();
		}
		OnConvertedToSack?.Invoke();
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.MineOre, TutorialSubStepType.PutOreInSack);
		}
	}

	public void ServerConvertItemTypeToSack(List<T_ItemSO> itemsToTransfer, NetworkConnectionToClient sender = null)
	{
		if (itemsToTransfer == null || itemsToTransfer.Count == 0)
		{
			Debug.LogWarning("T_Bag: ServerConvertItemTypeToSack - Item listesi boş!");
			return;
		}
		if (itemsToTransfer.Count > T_Sack.MaxItemsPerSack)
		{
			itemsToTransfer = itemsToTransfer.GetRange(0, T_Sack.MaxItemsPerSack);
		}
		foreach (T_ItemSO item in itemsToTransfer)
		{
			RemoveItem(item);
		}
		SpawnAndPickupSack(itemsToTransfer, sender);
		OnConvertedToSack?.Invoke();
	}

	private void SpawnAndPickupSack(List<T_ItemSO> itemsToTransfer, NetworkConnectionToClient sender = null)
	{
		if (itemsToTransfer == null || itemsToTransfer.Count == 0)
		{
			return;
		}
		if (!NetworkServer.active)
		{
			Debug.LogWarning("T_Bag: SpawnAndPickupSack sadece server'da çalışabilir!");
			return;
		}
		int maxItemsPerSack = T_Sack.MaxItemsPerSack;
		if (itemsToTransfer.Count > maxItemsPerSack)
		{
			itemsToTransfer = itemsToTransfer.GetRange(0, maxItemsPerSack);
		}
		Vector3 vector = throwPoint.position + throwPoint.forward * spawnForwardOffset + Vector3.up * groundOffset;
		GameObject gameObject = Object.Instantiate(sackPrefab, vector, Quaternion.identity);
		T_Sack component = gameObject.GetComponent<T_Sack>();
		if (component != null)
		{
			component.SetAsAutoPickupSack();
		}
		NetworkServer.Spawn(gameObject);
		DebugLog($"Sack spawned on server at {vector} with {itemsToTransfer.Count} items");
		Component component2 = gameObject.GetComponent("T_Sack");
		if (component2 != null)
		{
			MethodInfo method = component2.GetType().GetMethod("ServerSetItems", BindingFlags.Instance | BindingFlags.Public);
			if (method != null)
			{
				method.Invoke(component2, new object[1] { itemsToTransfer });
			}
			if (sender != null && sender.identity != null)
			{
				uint netId = gameObject.GetComponent<NetworkIdentity>().netId;
				GamePlayer component3 = sender.identity.GetComponent<GamePlayer>();
				if (component3 != null)
				{
					component3.TargetRpcPickupSpawnedSack(sender, netId);
				}
			}
		}
		else
		{
			Debug.LogError("T_Bag: Sack prefab'inde T_Sack component'i bulunamadı!");
		}
	}

	private void SyncBagToServer()
	{
		if (isLocalPlayerBag && NetworkClient.active && !(PlayerProgressManager.Instance == null))
		{
			if (_syncCoroutine != null)
			{
				_syncPending = true;
			}
			else
			{
				_syncCoroutine = StartCoroutine(Co_SyncBagToServerDelayed());
			}
		}
	}

	private IEnumerator Co_SyncBagToServerDelayed()
	{
		yield return new WaitForSeconds(0.5f);
		SendBagDataToServer();
		if (_syncPending)
		{
			_syncPending = false;
			_syncCoroutine = StartCoroutine(Co_SyncBagToServerDelayed());
		}
		else
		{
			_syncCoroutine = null;
		}
	}

	private void SendBagDataToServer()
	{
		if (!isLocalPlayerBag || PlayerProgressManager.Instance == null)
		{
			return;
		}
		DebugLog($"Saving bag to server ({items.Count}/{maxCapacity} items)");
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		foreach (var item in from i in items
			where i != null
			group i by i.GetItemID() into g
			select new
			{
				ItemId = g.Key,
				Count = g.Count()
			})
		{
			if (!string.IsNullOrEmpty(item.ItemId) && item.Count > 0)
			{
				list.Add(item.ItemId);
				list2.Add(item.Count);
			}
		}
		if (NetworkServer.active)
		{
			List<PlayerProgressManager.BagItemEntry> list3 = new List<PlayerProgressManager.BagItemEntry>();
			for (int num = 0; num < list.Count; num++)
			{
				list3.Add(new PlayerProgressManager.BagItemEntry(list[num], list2[num]));
			}
			ulong steamId = 0uL;
			PlayerProgressManager.Instance.Server_SavePlayerBag(steamId, list3);
		}
		else if (NetworkClient.active)
		{
			PlayerProgressManager.Instance.CmdSavePlayerBag(list, list2);
		}
	}

	public void RequestBagLoadFromServer()
	{
		if (!isLocalPlayerBag || PlayerProgressManager.Instance == null)
		{
			return;
		}
		DebugLog("Requesting bag load from server");
		if (NetworkServer.active)
		{
			ulong steamId = 0uL;
			List<PlayerProgressManager.BagItemEntry> list = PlayerProgressManager.Instance.Server_GetPlayerBag(steamId);
			List<string> list2 = new List<string>();
			List<int> list3 = new List<int>();
			foreach (PlayerProgressManager.BagItemEntry item in list)
			{
				list2.Add(item.itemId);
				list3.Add(item.count);
			}
			LoadBagFromServer(list2, list3);
		}
		else if (NetworkClient.active)
		{
			PlayerProgressManager.Instance.CmdRequestBagLoad();
		}
	}

	public void LoadBagFromServer(List<string> itemIds, List<int> itemCounts)
	{
		if (!isLocalPlayerBag)
		{
			return;
		}
		items.Clear();
		if (ScriptableListManager.Instance == null)
		{
			Debug.LogWarning("[T_Bag] ScriptableListManager bulunamadı!");
			return;
		}
		int num = Mathf.Min(itemIds.Count, itemCounts.Count);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			string text = itemIds[i];
			int num3 = itemCounts[i];
			if (string.IsNullOrEmpty(text) || num3 <= 0)
			{
				continue;
			}
			T_ItemSO t_ItemSO = FindItemSOById(text);
			if (t_ItemSO == null)
			{
				Debug.LogWarning("[T_Bag] Item bulunamadı: " + text);
				continue;
			}
			for (int j = 0; j < num3; j++)
			{
				items.Add(t_ItemSO);
				num2++;
			}
		}
		DebugLog($"Bag loaded from server: {num2}/{maxCapacity} items");
		OnCapacityChanged?.Invoke(items.Count, maxCapacity);
		UpdateSlider();
		RefreshBagUIIfOpen();
	}

	private void OnApplicationQuit()
	{
		if (isLocalPlayerBag && items.Count > 0 && NetworkClient.active)
		{
			SendBagDataToServer();
		}
	}

	private T_ItemSO FindItemSOById(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		if (ScriptableListManager.Instance == null)
		{
			return null;
		}
		IReadOnlyList<T_ItemSO> allItemSOs = ScriptableListManager.Instance.AllItemSOs;
		for (int i = 0; i < allItemSOs.Count; i++)
		{
			if (allItemSOs[i] != null && allItemSOs[i].GetItemID() == itemId)
			{
				return allItemSOs[i];
			}
		}
		return null;
	}
}
