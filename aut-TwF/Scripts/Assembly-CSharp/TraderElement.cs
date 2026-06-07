using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TraderElement : ISavable
{
	private const float SELL_PRICE_MULTIPLIER = 2f;

	private const float BUY_PRICE_MULTIPLIER = 6f;

	private const float MAX_DEMAND_VARIATION = 3f;

	private const float MAX_DEMAND_DELTA = 0.125f;

	private const float DEMAND_STEP_FACTOR = 2500f;

	private const float MAX_DEMAND_REBALANCE = 0.3f;

	public const float DISCOUNT_MULTIPLIER = 0.5f;

	[SerializeField]
	private ResourceData resourceData;

	[SerializeField]
	private int tier;

	[SerializeField]
	private float valueMultiplier = 1f;

	private int sellPrice;

	private int buyPrice;

	[Savable("demand", true, false)]
	private float demand;

	private Trader trader;

	[Savable("hasPurchaseDiscount", true, false)]
	private bool hasPurchaseDiscount;

	[Savable("hasSaleDiscount", true, false)]
	private bool hasSaleDiscount;

	private bool hasLoadedData;

	public ResourceData ResourceData => resourceData;

	public int Tier => tier;

	public int SellPrice
	{
		get
		{
			return sellPrice;
		}
		private set
		{
			sellPrice = value;
		}
	}

	public int BuyPrice
	{
		get
		{
			return buyPrice;
		}
		private set
		{
			buyPrice = value;
		}
	}

	public Trader Trader
	{
		get
		{
			return trader;
		}
		set
		{
			trader = value;
			if ((bool)trader)
			{
				if (!hasLoadedData)
				{
					Init();
				}
				UpdateCurrentPrice();
			}
		}
	}

	public float Demand
	{
		get
		{
			return demand;
		}
		set
		{
			demand = Mathf.Clamp01(value);
			this.onDemandChanged?.Invoke(demand);
			UpdateCurrentPrice();
		}
	}

	public bool HasPurchaseDiscount
	{
		get
		{
			return hasPurchaseDiscount;
		}
		set
		{
			hasPurchaseDiscount = value;
			UpdateCurrentPrice();
		}
	}

	public bool HasSaleDiscount
	{
		get
		{
			return hasSaleDiscount;
		}
		set
		{
			hasSaleDiscount = value;
			UpdateCurrentPrice();
		}
	}

	public event Action onPriceChanged;

	public event Action<float> onDemandChanged;

	public void Init()
	{
		demand = 0.5f;
		HasPurchaseDiscount = false;
		HasSaleDiscount = false;
	}

	private void UpdateCurrentPrice()
	{
		_ = resourceData.Value;
		float p = 2f * Demand - 1f;
		float num = Mathf.Pow(3f, p);
		SellPrice = Mathf.Max(1, Mathf.RoundToInt(resourceData.Value * 2f * num * valueMultiplier / (hasSaleDiscount ? 0.5f : 1f)));
		BuyPrice = Mathf.Max(1, Mathf.RoundToInt(resourceData.Value * 6f * num * valueMultiplier * (hasPurchaseDiscount ? 0.5f : 1f)));
		BuyPrice = Mathf.Max(SellPrice, BuyPrice);
		this.onPriceChanged?.Invoke();
	}

	public void UpdateDemand(int amount)
	{
		Demand += Mathf.Clamp((float)amount * resourceData.Value / 2500f, -0.125f, 0.125f);
	}

	public void RebalanceDemand()
	{
		if (Demand < 0.5f)
		{
			Demand = Math.Min(Demand + 0.3f, 0.5f);
		}
		else if (Demand > 0.5f)
		{
			Demand = Math.Max(Demand - 0.3f, 0.5f);
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			UpdateCurrentPrice();
			hasLoadedData = true;
		}
	}
}
