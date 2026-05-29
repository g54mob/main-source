using System;
using System.Collections.Generic;
using DG.Tweening;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletDevice : NoktaSingleton<TabletDevice>
{
	private const float m_ScrollSpeed = 0.125f;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private MarketShoppingCart m_MarketShoppingCart;

	[SerializeField]
	private TabletCartItem m_CartItemPrefab;

	[SerializeField]
	private Transform m_ContentParent;

	[SerializeField]
	private TMP_Text m_ProductTotalPrice;

	[SerializeField]
	private TMP_Text m_ShippingCost;

	[SerializeField]
	private TMP_Text m_PaymentAmount;

	[SerializeField]
	private TMP_Text m_Balance;

	[SerializeField]
	private TMP_Text m_RemainingMoney;

	[SerializeField]
	private TMP_Text m_UnityAmount;

	[SerializeField]
	private ScrollRect m_ScrollRect;

	[SerializeField]
	private List<TabletCartItem> m_AllCartItems;

	[SerializeField]
	private Transform m_Tablet;

	[SerializeField]
	private GameObject m_CloseMartketAfter9PMText;

	[SerializeField]
	private float m_SwingTime;

	private Vector3 m_defaultScale;

	private Sequence m_ClosedMarketSequence;

	private Sequence m_RemainingMoneySequence;

	public Action onTabletPurchased;

	public Action onTabletBought;

	private ScannerDevice m_ScannerDevice;

	public ScannerDevice ScannerDevice => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnMoneyTransition(float amount, MoneyManager.TransitionType type)
	{
	}

	private void TimeCheck()
	{
	}

	private void OnTabletPurchase()
	{
	}

	private void OnScroll(bool obj)
	{
	}

	private void OnRemoveItem(ItemQuantity obj)
	{
	}

	private void OnAddItem(ItemQuantity obj, SalesType saleType)
	{
	}

	private void RefreshMoneyScreen()
	{
	}

	private void Start()
	{
	}

	private void OnPurchaseCompleted(bool fromTablet)
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void CreateList()
	{
	}

	public void Animate(bool isOpen)
	{
	}
}
