using System;
using UnityEngine;

[Serializable]
public class Stock
{
	public uint Owner;

	public uint Target;

	public float InitialPrice;

	public float Percentage;

	public float Payout;

	public bool Main;

	public Company OwnerCompany
	{
		get
		{
			return GameSettings.Instance.simulation.GetCompany(Owner);
		}
	}

	public Company TargetCompany
	{
		get
		{
			return GameSettings.Instance.simulation.GetCompany(Target);
		}
	}

	public float RealPercentage
	{
		get
		{
			return 0f;
		}
	}

	public float CurrentWorth
	{
		get
		{
			Company targetCompany = TargetCompany;
			if (targetCompany == null)
			{
				return 0f;
			}
			return (float)(Main ? targetCompany.GetMoneyWithInsurance() : ((double)(GameSettings.GetStockPercent() * TargetCompany.Valuation)));
		}
	}

	public float Change
	{
		get
		{
			return CurrentWorth / Mathf.Max(1f, InitialPrice) - 1f;
		}
	}

	public Stock()
	{
	}

	public Stock(uint owner, uint target, float price, bool main = false)
	{
		Owner = owner;
		Target = target;
		InitialPrice = price;
		Main = main;
	}
}
