using System;

[Serializable]
public class FurnitureStock
{
	public byte Month;

	public int Year;

	public int Amount;

	public FurnitureStock()
	{
	}

	public FurnitureStock(int amount)
	{
		Amount = amount;
		SDateTime sDateTime = SDateTime.Now();
		Year = sDateTime.Year;
		Month = (byte)sDateTime.Month;
	}

	public FurnitureStock(int amount, int year, int month)
	{
		Amount = amount;
		Year = year;
		Month = (byte)month;
	}

	public bool Perished(int expiration, SDateTime t)
	{
		if (expiration == -1)
		{
			return false;
		}
		return t.Year * 12 + t.Month - (Year * 12 + Month) > expiration;
	}

	public override string ToString()
	{
		return SDateTime.Months[Month] + " " + (1900 + Year) + ": " + Amount;
	}
}
