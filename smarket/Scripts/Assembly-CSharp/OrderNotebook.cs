using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class OrderNotebook : MonoBehaviour, IPoolable
{
	[SerializeField]
	private Transform m_OrderNotebook;

	[SerializeField]
	private OrderNotebookDisplay m_Display;

	private Vector3 m_defaultScale;

	private OrderListData m_OrderData;

	public OrderNotebookDisplay Display => null;

	public OrderListData OrderData => null;

	public bool IsRead { get; private set; }

	public void SetOrderData(OrderListData value)
	{
	}

	public void SetEntryData(IEnumerable<PaperBagProductInstance> entryData)
	{
	}

	public void Read()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnWorkingStatusChanged(int _)
	{
	}

	private void UpdateWorkedStatus()
	{
	}

	public void OnProductAdded(int productId)
	{
	}

	public void OnProductRemoved(int productId)
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void OnScroll(bool clockwise)
	{
	}

	public void OnViewed()
	{
	}

	public void OnCanceledView()
	{
	}
}
