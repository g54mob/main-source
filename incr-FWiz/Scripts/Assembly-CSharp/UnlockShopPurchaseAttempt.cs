using System;
using System.Runtime.CompilerServices;

[Serializable]
public class UnlockShopPurchaseAttempt
{
	public UnlockShop Shop;

	public ShopItem ShopItem;

	public PaymentGroup Payment;

	public bool Active => false;

	public bool Valid => false;

	public event Action AnnouncedCleared
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

	public void Set(UnlockShop shop, ShopItem item, PaymentGroup payment)
	{
	}

	public void Clear()
	{
	}
}
