using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.Localization;

public class UnlockShop : MonoBehaviour
{
	[SerializeField]
	private UnlockShopCanvasUI _shopUI;

	public List<ClickListener> ToggleShopClickListeners;

	[SerializeField]
	private PaymentCollector _paymentCollector;

	public UnlockShopPurchaseAttempt ShopPurchase;

	[SerializeField]
	private UnlockShopPaymentUI _unlockShopPaymentUI;

	public bool Locked;

	public List<ShopItem> ShopItems;

	public LocalizedString ShopTitle;

	public Action DoInsteadOfOpen;

	public bool ShopUIShown => false;

	public bool TrackingPurchase => false;

	public static event Action<UnlockShopPurchaseAttempt> AnnouncePurchaseAttempt
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

	public static event Action AnnouncePurchaseAttemptCleared
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

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	private void OnDestroy()
	{
	}

	public void ToggleUnlockShop()
	{
	}

	public List<ShopItem> GetShopItems()
	{
		return null;
	}

	private void SelectBuilding(ShopItem shopitem)
	{
	}

	public void Unlock()
	{
	}

	public void Fulfill()
	{
	}
}
