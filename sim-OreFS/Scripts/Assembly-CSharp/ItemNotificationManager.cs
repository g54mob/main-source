using UnityEngine;

public class ItemNotificationManager : MonoBehaviour
{
	[Header("Prefab")]
	[Tooltip("ItemNotificationUI scripti içeren bildirim prefab'ı")]
	[SerializeField]
	private GameObject notificationPrefab;

	[Header("Container")]
	[Tooltip("Bildirimlerin spawn edileceği container (VerticalLayoutGroup önerilir)")]
	[SerializeField]
	private Transform notificationContainer;

	[Header("Money & XP Icons")]
	[Tooltip("Para bildirimi için kullanılacak ikon")]
	[SerializeField]
	private Sprite moneyIcon;

	[Tooltip("XP bildirimi için kullanılacak ikon")]
	[SerializeField]
	private Sprite xpIcon;

	public static ItemNotificationManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void ShowNotification(Sprite icon, string itemName, int value, NotificationType notificationType)
	{
		if (value != 0)
		{
			CreateNotification(icon, itemName, value, notificationType);
		}
	}

	public void ShowItemNotification(T_ItemSO item, int amount)
	{
		if (item == null)
		{
			Debug.LogWarning("[ItemNotificationManager] ShowItemNotification - Item null!");
		}
		else if (amount != 0)
		{
			ShowNotification(item.Icon, item.Name, amount, NotificationType.Item);
		}
	}

	public void ShowMoneyNotification(int delta, EconomyType economyType)
	{
		if (delta != 0)
		{
			string economyTypeName = GetEconomyTypeName(economyType);
			ShowNotification(moneyIcon, economyTypeName, delta, NotificationType.Money);
		}
	}

	public void ShowXPNotification(int delta, EconomyType economyType)
	{
		if (delta != 0)
		{
			string economyTypeName = GetEconomyTypeName(economyType);
			ShowNotification(xpIcon, economyTypeName, delta, NotificationType.XP);
		}
	}

	private string GetEconomyTypeName(EconomyType economyType)
	{
		return economyType.ToString();
	}

	public void ClearAllNotifications()
	{
		if (notificationContainer == null)
		{
			return;
		}
		foreach (Transform item in notificationContainer)
		{
			Object.Destroy(item.gameObject);
		}
	}

	private void CreateNotification(Sprite icon, string itemName, int value, NotificationType notificationType)
	{
		if (notificationPrefab == null)
		{
			Debug.LogError("[ItemNotificationManager] Notification prefab atanmamış!");
			return;
		}
		if (notificationContainer == null)
		{
			Debug.LogError("[ItemNotificationManager] Notification container atanmamış!");
			return;
		}
		GameObject gameObject = Object.Instantiate(notificationPrefab, notificationContainer);
		ItemNotificationUI component = gameObject.GetComponent<ItemNotificationUI>();
		if (component == null)
		{
			Debug.LogError("[ItemNotificationManager] Prefab'da ItemNotificationUI component'i bulunamadı!");
			Object.Destroy(gameObject);
		}
		else
		{
			component.Initialize(icon, itemName, value, notificationType);
		}
	}

	[ContextMenu("Test: Show Money +100 (Sale)")]
	private void TestShowMoney()
	{
		ShowMoneyNotification(100, EconomyType.EconomyType_Sale);
	}

	[ContextMenu("Test: Show Money -50 (Purchase)")]
	private void TestReduceMoney()
	{
		ShowMoneyNotification(-50, EconomyType.EconomyType_Purchase);
	}

	[ContextMenu("Test: Show XP +30 (Contract)")]
	private void TestShowXP()
	{
		ShowXPNotification(30, EconomyType.EconomyType_Contract);
	}
}
