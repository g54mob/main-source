using System.Collections.Generic;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class OrderNotebookDisplay : MonoBehaviour, IPoolable
{
	[SerializeField]
	private TMP_Text m_OrderNameText;

	[SerializeField]
	private Transform m_OrderEntryContainer;

	[SerializeField]
	private OrderNotebookProductEntry m_ProductEntryPrefab;

	[SerializeField]
	private Image m_ReadDisplay;

	[SerializeField]
	private ScrollRect m_ScrollRect;

	[SerializeField]
	[Header("Price Texts")]
	private GameObject m_PriceDisplayContainer;

	[SerializeField]
	private LocalizeStringEvent m_TotalPriceText;

	[SerializeField]
	private LocalizeStringEvent m_DistancePriceText;

	[SerializeField]
	private LocalizeStringEvent m_WorkedOnText;

	[SerializeField]
	private OrderTimeDisplay m_TimeDisplay;

	[SerializeField]
	private Image m_LabeledIndicator;

	private Dictionary<int, OrderNotebookProductEntry> m_Entries;

	private OrderListData m_OrderData;

	private Queue<int> m_ClearQueue;

	private float m_TotalDisplayedPrice;

	public bool ReadState
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private OrderNotebookProductEntry CreateEntry(int id)
	{
		return null;
	}

	public void SetEntryData(IEnumerable<PaperBagProductInstance> instances)
	{
	}

	private void UpdateTotalPriceDisplay()
	{
	}

	public void SetOrderData(OrderListData value)
	{
	}

	private void TogglePriceDisplays()
	{
	}

	public void OnProductAdded(int productId)
	{
	}

	public void OnProductRemoved(int productId)
	{
	}

	private void CalculateTotalPrice()
	{
	}

	private void ClearNonRequiredEntries()
	{
	}

	public void Clear()
	{
	}

	private void RemoveEntryOfId(int id)
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	private void Update()
	{
	}

	private void HandleScroll()
	{
	}

	public void SetLabelIcon(bool value)
	{
	}

	public void OnScroll(bool clockwise)
	{
	}

	public void SetWorkedOnBy(bool available, string workedBy)
	{
	}
}
