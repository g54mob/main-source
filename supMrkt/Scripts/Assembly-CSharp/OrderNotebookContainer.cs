using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OrderNotebookContainer : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private OrderNotebook m_NotebookPrefab;

	private List<OrderNotebook> m_NotebookInstances;

	private OrderNotebook m_EmptyNotebook;

	private OrderNotebook m_PreviousInstance;

	private bool m_IsInitialized;

	public bool HasInstance => false;

	public OrderNotebook CurrentInstance => null;

	public OrderListData CurrentOrder => null;

	public bool IsEmpty => false;

	public event Action ProductAdded
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

	public event Action ProductRemoved
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

	public void CreateEmptyIfNeeded()
	{
	}

	private void Awake()
	{
	}

	public void Initialize()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLabelIconstatusRequested(int orderId, bool value)
	{
	}

	private void OnDestroy()
	{
	}

	private OrderNotebook CreateOrderNotebook()
	{
		return null;
	}

	private void OnOrderRemoved(int id)
	{
	}

	private void OnOrderIssued(OrderListData data)
	{
	}

	private void UpdatePositions()
	{
	}

	public OrderNotebook GetNotebookOfOrderId(int id)
	{
		return null;
	}

	public OrderNotebook GetNotebookOfOrder(OrderListData order)
	{
		return null;
	}

	public void SetNotebookOfOrder(OrderListData order)
	{
	}

	public void SwapNotebook(int direction)
	{
	}

	private void OnOrderCompleted(OrderData data)
	{
	}

	public void Animate(bool isOpen)
	{
	}

	public void OnProductAdded(int productId)
	{
	}

	public void OnProductRemoved(int productId)
	{
	}

	public void RemoveInstanceForOrder(OrderListData order)
	{
	}

	public void CancelCurrentOrder()
	{
	}

	private void RemoveInstance(OrderNotebook instance)
	{
	}

	public void LoadOrderData(IReadOnlyList<OrderListData> orders)
	{
	}
}
