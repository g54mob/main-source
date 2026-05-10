using System;
using System.Collections.Generic;
using MyBox;
using Photon.Pun;
using UnityEngine;

public class PriceManager : NoktaSingletonPunCallbacks<PriceManager>
{
	[SerializeField]
	private int m_MinDayToChangeBasePrice;

	[SerializeField]
	private int m_MaxDayToChangeBasePrice;

	[SerializeField]
	[Range(0f, 100f)]
	private float m_DailyChanceToChangeBasePrice;

	[SerializeField]
	private int m_MaxNumberOfProductsPerDayToChangeBasePrice;

	[SerializeField]
	private float m_NewPriceClampPercentage;

	[SerializeField]
	private PricingProductViewer m_PricingProductViewer;

	[SerializeField]
	private AnimationCurve m_DiscountCurve;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private List<Pricing> m_CurrentCosts;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private List<Pricing> m_PricesSetByPlayer;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private List<Pricing> m_AveragePrices;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private List<Pricing> m_DailyPriceChanges;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private List<Pricing> m_PreviousPrices;

	[ReadOnly(new string[] { })]
	public List<Pricing> pricingDatas;

	private float m_TotalDiscountPoints;

	public Action<int> onPriceSet;

	public Action<int, int> onSaleSignSet;

	public Action<List<int>> onCostsChanged;

	public Action onDisabled;

	public Action onSlaveLoadedPriceSave;

	private static bool m_Registered;

	private HashSet<int> PriceChangedProductsCache;

	public float TotalDiscountPoints
	{
		get
		{
			return 0f;
		}
		private set
		{
		}
	}

	public PricingProductViewer PricingProductViewer => null;

	public AnimationCurve DiscountCurve
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool HasPriceSetByPlayer(int productID)
	{
		return false;
	}

	public float SellingPrice(int productID)
	{
		return 0f;
	}

	public float DiscountedPrice(int productID)
	{
		return 0f;
	}

	public float AverageCost(int productID)
	{
		return 0f;
	}

	public float GetProfitRate(int productID)
	{
		return 0f;
	}

	public float CalculateTotalDiscountPoints()
	{
		return 0f;
	}

	public PricingState PricingState(int productID)
	{
		return default(PricingState);
	}

	public float PreviousCost(int productID)
	{
		return 0f;
	}

	public float CurrentCost(int productID)
	{
		return 0f;
	}

	public bool DidPriceIncreased(int productID)
	{
		return false;
	}

	private void Start()
	{
	}

	public void OnSyncRequest(string userId)
	{
	}

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	public string GetJsonFormatList(List<Pricing> list)
	{
		return null;
	}

	private void OnSaveLoaded()
	{
	}

	[RuntimeInitializeOnLoadMethod]
	private static void Reset()
	{
	}

	private void Awake()
	{
	}

	public void Load_Request(string userId)
	{
	}

	[PunRPC]
	public void Load_Broadcast(Pricing[] currentCosts, Pricing[] pricesSetByPlayer, Pricing[] averagePrices, Pricing[] dailyPriceChanges, Pricing[] previousPrices, Pricing[] _pricingDatas)
	{
	}

	private void LoadSave()
	{
	}

	private void RepopulatePricingDataIfNeeded(List<Pricing> targetList)
	{
	}

	public void PriceSet(Pricing pricing)
	{
	}

	public float TotalBoxPrice(int productID)
	{
		return 0f;
	}

	public void UpdateAverageCost(int productID, int unitAmount, float costPerUnit)
	{
	}

	private void AddPricing(Pricing pricing)
	{
	}

	[PunRPC]
	public void SetPricingList(string pricingJson)
	{
	}

	public Pricing GetPriceSetByPlayer(int productID)
	{
		return null;
	}

	public Pricing GetPrice(int productID)
	{
		return null;
	}

	private Pricing GetAverageCost(int productID)
	{
		return null;
	}

	private void TryChangingBasePrices()
	{
	}

	public void BasePricesChanged_Broadcast(HashSet<int> priceChangedProducts)
	{
	}

	[PunRPC]
	public void BasePricesChangedFirst_RPC(string priceChangedProducts, Pricing[] currentCosts, Pricing[] pricesSetByPlayer, Pricing[] averagePrices, Pricing[] dailyPrices, Pricing[] previousPrices, Pricing[] p_pricingDatas)
	{
	}

	private void OnPriceChangesReceived()
	{
	}

	private void OnDayCycleDisabled()
	{
	}

	private void ChangeCurrentCost(int productID)
	{
	}

	private void LoadCurrentCosts()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void CreatePricingData()
	{
	}

	public void LoadPricingData()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SavePricingData()
	{
	}

	public void SetPrice_Order(int productID, float price, int discountRate, int saleIndex)
	{
	}
}
