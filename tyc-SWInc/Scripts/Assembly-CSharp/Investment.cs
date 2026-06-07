using System;

[Serializable]
public class Investment
{
	public float Amount;

	public float InitialValue;

	public float LastTaxValue = -1f;

	public StockMarket Stock;

	public float CurrentValue
	{
		get
		{
			return Amount / InitialValue * Stock.Value;
		}
	}

	public Investment()
	{
	}

	public Investment(StockMarket stock, float amount)
	{
		Stock = stock;
		InitialValue = Stock.Value;
		LastTaxValue = (Amount = amount);
	}
}
