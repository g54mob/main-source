using System;

[Serializable]
public class NewStock
{
	public Company Seller;

	public Company Buyer;

	public uint Shares;

	[AltWasFloat(0)]
	public double InitialWorth;

	[AltWasFloat(0)]
	public double LastTaxValue = -1.0;

	public float Payout;

	public double ShareWorth
	{
		get
		{
			return Seller.GetShareWorth();
		}
	}

	public double ShareWorthNoStocks
	{
		get
		{
			return Seller.GetShareWorth(false);
		}
	}

	public double TotalWorth
	{
		get
		{
			return ShareWorth * (double)Shares;
		}
	}

	public double TotalWorthNoStocks
	{
		get
		{
			return ShareWorthNoStocks * (double)Shares;
		}
	}

	public double Change
	{
		get
		{
			if (!(InitialWorth > 0.0))
			{
				return 0.0;
			}
			return (ShareWorth - InitialWorth) / InitialWorth;
		}
	}

	public double Percentage
	{
		get
		{
			return (Seller.Shares != 0) ? ((float)Shares / (float)Seller.Shares) : 0f;
		}
	}

	public string BuyerName
	{
		get
		{
			if (!Buyer.IsInvestor)
			{
				return Buyer.Name;
			}
			return "PrivateInvestors".Loc();
		}
	}

	public NewStock()
	{
	}

	public NewStock(Company seller, Company buyer, uint shares, double? offer = null)
	{
		Seller = seller;
		Buyer = buyer;
		Shares = shares;
		if (offer.HasValue && offer.Value > 0.0)
		{
			InitialWorth = offer.Value / (double)Shares;
		}
		else
		{
			InitialWorth = ShareWorth;
		}
		LastTaxValue = InitialWorth * (double)Shares;
	}

	public void Expand(uint shares, double? offer = null)
	{
		double num = InitialWorth * (double)Shares;
		num = ((!offer.HasValue) ? (num + (double)shares * ShareWorth) : (num + offer.Value));
		Shares += shares;
		InitialWorth = num / (double)Shares;
		LastTaxValue += offer ?? ((double)shares * ShareWorth);
	}
}
