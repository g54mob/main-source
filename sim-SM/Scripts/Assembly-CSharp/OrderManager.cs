using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OrderManager : NoktaSingleton<OrderManager>
{
	[SerializeField]
	private List<OrderSpawnSettingsSO> m_OrderSpawnSettings;

	[SerializeField]
	private float m_MinOrderIntervalInGameMinutes;

	[SerializeField]
	private OnlineOrderOfferIndicator m_Indicator;

	[SerializeField]
	private Transform m_SupermarketPosition;

	[SerializeField]
	private OrderPaperBag m_OrderPaperBagPrefab;

	private const float m_MinDistance = 60f;

	private const float m_MaxDistance = 210f;

	private const float m_MinFee = 15f;

	private const float m_MaxFee = 35f;

	private OrderSpawnSettingsSO m_CurrentOrderSettingSO;

	private List<int> m_OpenedProducts;

	private float m_DayEndTime;

	private OnlineOrderInteraction m_Interaction;

	public List<OrderListData> GeneratedOrderLists;

	public List<float> PlannedOrderTimeLists;

	private NetworkOrderManager m_NetworkOrderManager;

	private bool m_CanGenerateOrderTime => false;

	public int MinOrderLevel => 0;

	public event Action<OrderListData> OrderIssued
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<int> OrderRemoved
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<OrderListData> OrderDelivered
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance localPlayer)
	{
	}

	private void Start()
	{
	}

	private void CheckCurrentHour()
	{
	}

	private void CheckCurrentMinute()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSaveRequested()
	{
	}

	private void DeleteOrdersFromSave()
	{
	}

	private void LoadFromSave()
	{
	}

	private void OnStartedNewDay()
	{
	}

	public List<OrderData> GenerateOnlineOrderItems(OrderSpawnSettingsSO settings)
	{
		return null;
	}

	private void ShuffleList<T>(List<T> list)
	{
	}

	private List<float> GenerateOrderSpawnTimes()
	{
		return null;
	}

	public void AddOrder(OrderListData data)
	{
	}

	public void CreateOrder()
	{
	}

	public OnlineOrderCustomer CreateCustomer(OrderListData order)
	{
		return null;
	}

	private float CalculateNavMeshPathDistance(Vector3 start, Vector3 end)
	{
		return 0f;
	}

	private (int, float) CalculateExpireDate(int day, float orderTime)
	{
		return default((int, float));
	}

	public void PopulateDeliveryFee(OrderListData forOrder, int spawnIndex)
	{
	}

	public void PopulateDeliveryFee(OrderListData forOrder, Vector3 position)
	{
	}

	private float CalculateDeliveryFee(float distance)
	{
		return 0f;
	}

	public void OrderExpired(OrderListData Order)
	{
	}

	public void OrderCompleted(OrderListData Order)
	{
	}

	public void RemoveOrderOfId(int id)
	{
	}

	public void CancelOrder(OrderListData Order)
	{
	}

	public OrderListData GetOrder(int orderId)
	{
		return null;
	}

	private void GetCurrentOrderSO()
	{
	}

	private void GetCurrentProductList()
	{
	}

	public void CanShowUI()
	{
	}

	private int GetUnreadOrderCount()
	{
		return 0;
	}

	private void OnOnlineOrder()
	{
	}

	public void SaveOrdersToFile()
	{
	}

	public void SaveOrderTimesToFile()
	{
	}

	private string ConvertSecondsToDisplay(float seconds)
	{
		return null;
	}

	public void NetworkCreateOrder(OrderListData data)
	{
	}
}
