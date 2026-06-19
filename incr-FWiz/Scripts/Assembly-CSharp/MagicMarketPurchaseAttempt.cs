using System;

[Serializable]
public class MagicMarketPurchaseAttempt
{
	public MagicMarketDeal Deal;

	public PaymentGroup Payment;

	public bool Valid => false;

	public void Clear()
	{
	}

	public void Set(MagicMarketDeal deal, PaymentGroup payment)
	{
	}
}
