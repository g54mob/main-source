using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class AddOnProduct : IStockable, ILossable, IReferenceFix, IFormatColorObject, IDisplayable, IMarketable, IRoyaltyItem, IListDoubleClickable
{
	public readonly string Name;

	public readonly SoftwareAddOn Type;

	public readonly SoftwareProduct Parent;

	public readonly AddOnFeature[] Features;

	public readonly uint[] FeatureFactors;

	public readonly SDateTime DevStart;

	public readonly SDateTime Release;

	public readonly float DevTime;

	[AltWasFloat(0)]
	public readonly double ReleaseRelevancy;

	[AltWasFloat(0)]
	public readonly double CodeProgress;

	[AltWasFloat(0)]
	public readonly double ArtProgress;

	[AltWasFloat(0)]
	public readonly double CodeQuality;

	[AltWasFloat(0)]
	public readonly double ArtQuality;

	public readonly bool Forced;

	[AltWasFloat(0)]
	private Dictionary<string, double[]> _featureScoreSummation;

	public float Price;

	public float Marketing;

	public float OriginalPrice;

	public float LowestPrice = -1f;

	public float PriceChangeFact = 1f;

	public float DistributionLoss;

	public float PostMarketingLoss;

	[AltWasFloat(0)]
	public double Gross;

	[AltWasFloat(0)]
	public double Loss;

	private float _awareness;

	[AltWasFloat(0)]
	public readonly double RealQuality;

	[AltWasFloat(0)]
	public readonly double[] Quality;

	public uint Sales;

	public uint Refunds;

	public int LastMonthPhysical;

	public uint TotalPhysical;

	public float LastMonthIncome;

	public float LastDayIncome;

	public float LastDayLoss;

	public Company Owner;

	public readonly string Inventor;

	public readonly uint InventorID;

	public bool Traded;

	private int _hardwareMask;

	private int _hardwareInputMask;

	private float _hardwarePrice;

	public int MissedPhysicalCopies;

	[NameRedirection(new string[] { "<PhysicalCopies>k__BackingField" })]
	private uint _physicalCopies;

	public uint Followers;

	public uint ID = 1u;

	public List<int> UnitOnlineSales;

	public List<int> UnitOfflineSales;

	public List<int> RefundsSales;

	private SDateTime? _lastAddedToSales;

	[IgnoreNetwork]
	private bool _stockNotifications = true;

	public uint PositiveReviews;

	public uint NegativeReviews;

	public List<int> PositiveReviewList;

	public List<int> NegativeReviewList;

	[NonSerialized]
	private double[] _cachedWeightedMarketQuality;

	[NonSerialized]
	private SDateTime _cachedWeightedMarketQualityDate;

	private static double[] _priceCache = new double[3];

	[NonSerialized]
	private ScriptSystem.SaleScope _saleScope = new ScriptSystem.SaleScope();

	[AltWasFloat(0)]
	private double _cachedPerceivedValue;

	private SDateTime _cachedPerceivedTime;

	private List<KeyValuePair<Company, float>> _workRoyalties = new List<KeyValuePair<Company, float>>();

	public uint CopiesPerBox
	{
		get
		{
			return 1000u;
		}
	}

	public bool IsReadOnlyJob
	{
		get
		{
			return false;
		}
	}

	public bool OriginalOwner
	{
		get
		{
			return Owner.ID == InventorID;
		}
	}

	public uint PhysicalCopies
	{
		get
		{
			return _physicalCopies;
		}
		set
		{
			if (!Parent.IsMock)
			{
				NetworkMessaging.SendChangePhysicalCopies(Parent.ID, ID, value, 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			_physicalCopies = value;
		}
	}

	public bool StockNotifications
	{
		get
		{
			if (_stockNotifications)
			{
				return !Parent.PlayerArchived;
			}
			return false;
		}
		set
		{
			_stockNotifications = value;
		}
	}

	public float ReviewScore
	{
		get
		{
			if (PositiveReviews != 0)
			{
				return (float)PositiveReviews / (float)(PositiveReviews + NegativeReviews);
			}
			return 0f;
		}
	}

	public bool ActualStockNotifications
	{
		get
		{
			return _stockNotifications;
		}
	}

	public int ReleaseYear
	{
		get
		{
			return Release.RealYear;
		}
	}

	public int HardwareMask
	{
		get
		{
			return _hardwareMask;
		}
		set
		{
			_hardwareMask = value;
		}
	}

	public int HardwareInputMask
	{
		get
		{
			return _hardwareInputMask;
		}
		set
		{
			_hardwareInputMask = value;
		}
	}

	public float HardwarePrice
	{
		get
		{
			return _hardwarePrice;
		}
		set
		{
			_hardwarePrice = value;
		}
	}

	public byte[] HardwareDesign { get; set; }

	public SoftwareCategory SWCat
	{
		get
		{
			return Parent.Category;
		}
	}

	public IManufacturable Manufacturing
	{
		get
		{
			return Type;
		}
	}

	public bool Competitive
	{
		get
		{
			return Type.Hardware;
		}
	}

	public IList<FeatureBase> FeaturesBases
	{
		get
		{
			return Features;
		}
	}

	public IStockable DeferStock
	{
		get
		{
			return this;
		}
	}

	public SoftwareType SWType
	{
		get
		{
			return Parent.Type;
		}
	}

	public bool HasWorkRoyalties
	{
		get
		{
			return _workRoyalties.Count > 0;
		}
	}

	public void AddReviews(int positive, int negative, SDateTime time)
	{
		if (positive + negative > 0)
		{
			NetworkMessaging.SendAddReviews(Parent.ID, ID, positive, negative, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyAddReviews(positive, negative, time);
	}

	public void ActuallyAddReviews(int positive, int negative, SDateTime time)
	{
		if (positive + negative > 0)
		{
			if (PositiveReviewList == null)
			{
				PositiveReviewList = new List<int>();
				NegativeReviewList = new List<int>();
			}
			SDateTime release = Release;
			if (release.Hour > 0)
			{
				release += SDateTime.GetDay(1);
			}
			int num = Mathf.Max(0, SDateTime.GetMonthsFlat(release, time));
			int num2 = num - PositiveReviewList.Count + 1;
			for (int i = 0; i < num2; i++)
			{
				PositiveReviewList.Add(0);
				NegativeReviewList.Add(0);
			}
			PositiveReviewList[num] += positive;
			NegativeReviewList[num] += negative;
			PositiveReviews += (uint)positive;
			NegativeReviews += (uint)negative;
		}
	}

	public void ChangePhysicalCopiesDirectly(uint newValue)
	{
		_physicalCopies = newValue;
	}

	public string GetName()
	{
		return Name;
	}

	public string GetTypeName()
	{
		return Type.GetActualString();
	}

	public SDateTime GetReleaseDate()
	{
		return Release;
	}

	public IList<FeatureBase> GetFeatures()
	{
		return Features;
	}

	public float GetLastMonthIncome()
	{
		return LastMonthIncome;
	}

	public float GetLastDayIncome(bool gross)
	{
		if (!gross)
		{
			return LastDayIncome - LastDayLoss;
		}
		return LastDayIncome;
	}

	public string GetIdentifyingName()
	{
		return Name;
	}

	public string GetCompanyName()
	{
		return Owner.Name;
	}

	public AddOnProduct()
	{
	}

	public void AddSalesData(int online, int offline, int refunds, SDateTime time)
	{
		if (UnitOnlineSales == null)
		{
			UnitOnlineSales = new List<int> { 0 };
			UnitOfflineSales = new List<int> { 0 };
			RefundsSales = new List<int> { 0 };
			_lastAddedToSales = Release;
		}
		if (online + offline + refunds > 0)
		{
			Parent.ChangeLastSale(time, true);
		}
		else if (UnitOfflineSales[UnitOfflineSales.Count - 1] + UnitOnlineSales[UnitOnlineSales.Count - 1] + RefundsSales[RefundsSales.Count - 1] == 0)
		{
			return;
		}
		int monthsFlat = SDateTime.GetMonthsFlat(_lastAddedToSales ?? Release, time);
		SDateTime? lastAddedToSales = _lastAddedToSales;
		_lastAddedToSales = ((time > lastAddedToSales) ? new SDateTime?(time) : _lastAddedToSales);
		for (int i = 0; i < monthsFlat; i++)
		{
			UnitOfflineSales.Add(0);
			UnitOnlineSales.Add(0);
			RefundsSales.Add(0);
		}
		int index = Mathf.Clamp(SDateTime.GetMonthsFlat(Release, time), 0, UnitOfflineSales.Count - 1);
		UnitOfflineSales[index] += offline;
		UnitOnlineSales[index] += online;
		RefundsSales[index] += refunds;
	}

	public void SendNetwork()
	{
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendAddAddOn(Name.StripRichTags(), ID, Type.Parent.ID, Type.ID, Parent.ID, Features.SelectInPlace((AddOnFeature x) => x.ID), FeatureFactors, DevStart, Release, Price, _awareness, Loss, Quality, Owner.ID, PhysicalCopies, DistributionLoss, Followers, CodeProgress, ArtProgress, CodeQuality, ArtQuality, Forced, HardwareDesign, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public AddOnProduct(string name, uint id, uint swType, uint type, uint parent, uint[] features, uint[] featureFactors, SDateTime devStart, SDateTime release, float price, float awareness, double loss, double[] quality, uint devCompany, uint physicalCopies, float distributionLoss, uint followers, double codeProgress, double artProgress, double codeQuality, double artQuality, bool forced, byte[] hardwareDesign)
	{
		Name = name;
		Type = MarketSimulation.Active.GetSoftwareType(swType).GetAddon(type);
		Parent = MarketSimulation.Active.GetProduct(parent, false);
		ID = id;
		Features = features.SelectInPlace(Type.GetFeature);
		FeatureFactors = featureFactors;
		DevStart = devStart;
		Release = release;
		LowestPrice = (OriginalPrice = (Price = price));
		Loss = loss;
		Quality = quality;
		Owner = MarketSimulation.Active.GetCompany(devCompany);
		MarketEvent ev = new MarketEvent(MarketEvent.EventType.ProductRelease, release, parent, id);
		Parent.AddMarketEvent(ev, false);
		Owner.AddMarketEvent(ev, false);
		Inventor = Owner.Name;
		InventorID = Owner.ID;
		_physicalCopies = physicalCopies;
		Followers = followers;
		CodeProgress = codeProgress;
		ArtProgress = artProgress;
		CodeQuality = codeQuality;
		ArtQuality = artQuality;
		Forced = forced;
		DistributionLoss = distributionLoss;
		_awareness = awareness;
		RealQuality = Utilities.Clamp01(SWType.FinalQualityCalc(codeProgress, artProgress, codeQuality, artQuality, Features));
		DevTime = Type.DevTime(Features, featureFactors, SWCat, null, Parent.TechLevels);
		ReleaseRelevancy = CalculateRelevancy();
		_featureScoreSummation = Type.GetSummarizedMarketScore(SWCat, Features, FeatureFactors);
		if (Type.Hardware)
		{
			HardwareDesign = hardwareDesign ?? HardwareDesignInstance.GenerateRandomDesign(Type.Manufacturing, Parent.SequelTo, Parent, Type, Features, Owner);
			Type.Manufacturing.GetProcessInfo(Features, FeatureFactors, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
		}
		Owner.ReleaseNow(Parent.Category, release);
		Parent.Addons.Append(Type, this);
		Parent.ResetAddonID();
	}

	public AddOnProduct(string name, SoftwareAddOn type, SoftwareProduct parent, AddOnFeature[] features, uint[] featureFactors, SDateTime devStart, SDateTime release, float price, double loss, double[] quality, Company devCompany, uint physicalCopies, float distributionLoss, uint followers, double codeProgress, double artProgress, double codeQuality, double artQuality, bool forced, byte[] hardwareDesign = null)
		: this(name, parent.GetNextAddonID(), type, parent, features, featureFactors, devStart, release, price, loss, quality, devCompany, physicalCopies, distributionLoss, followers, codeProgress, artProgress, codeQuality, artQuality, forced, hardwareDesign)
	{
	}

	public AddOnProduct(string name, uint? id, SoftwareAddOn type, SoftwareProduct parent, AddOnFeature[] features, uint[] featureFactors, SDateTime devStart, SDateTime release, float price, double loss, double[] quality, Company devCompany, uint physicalCopies, float distributionLoss, uint followers, double codeProgress, double artProgress, double codeQuality, double artQuality, bool forced, byte[] hardwareDesign = null)
	{
		Name = name;
		Type = type;
		Parent = parent;
		ID = id ?? parent.GetNextAddonID();
		Features = features;
		FeatureFactors = featureFactors;
		DevStart = devStart;
		Release = release;
		LowestPrice = (OriginalPrice = (Price = price));
		Loss = loss;
		Quality = quality;
		Owner = devCompany;
		MarketEvent ev = new MarketEvent(MarketEvent.EventType.ProductRelease, release, parent.ID, ID);
		Parent.AddMarketEvent(ev, false);
		Owner.AddMarketEvent(ev, false);
		Inventor = devCompany.Name;
		InventorID = devCompany.ID;
		_physicalCopies = physicalCopies;
		Followers = followers;
		CodeProgress = codeProgress;
		ArtProgress = artProgress;
		CodeQuality = codeQuality;
		ArtQuality = artQuality;
		Forced = forced;
		DistributionLoss = distributionLoss;
		uint reach = GetReach();
		_awareness = ((reach == 0) ? 1f : Mathf.Clamp01((float)followers / (float)reach)) * Parent.GetMaxAwareness(this);
		RealQuality = Utilities.Clamp01(SWType.FinalQualityCalc(codeProgress, artProgress, codeQuality, artQuality, features));
		DevTime = type.DevTime(features, featureFactors, SWCat, null, Parent.TechLevels);
		ReleaseRelevancy = CalculateRelevancy();
		_featureScoreSummation = Type.GetSummarizedMarketScore(SWCat, Features, FeatureFactors);
		if (Type.Hardware)
		{
			HardwareDesign = hardwareDesign ?? HardwareDesignInstance.GenerateRandomDesign(Type.Manufacturing, Parent.SequelTo, Parent, Type, Features, Owner);
			Type.Manufacturing.GetProcessInfo(Features, FeatureFactors, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
		}
		devCompany.ReleaseNow(parent.Category, release);
		Parent.Addons.Append(Type, this);
	}

	public float GetAwareness()
	{
		return Mathf.Clamp01(_awareness / Parent.GetMaxAwareness(this));
	}

	public void SetAwareness(float value)
	{
		_awareness = value;
	}

	public float GetRealAwareness()
	{
		return _awareness;
	}

	public void SimulateAwareness(bool fromNetwork = false)
	{
		if (!fromNetwork && (_awareness > 0f || Marketing > 0f))
		{
			NetworkMessaging.SendUpdateMarketing(Parent.ID, ID, Marketing, true, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_awareness = Mathf.Max(0f, _awareness * (1f - 0.15f / (float)GameSettings.DaysPerMonth) + Marketing);
		Marketing = 0f;
	}

	public void KillAwareness(bool fromNetwork = false)
	{
		if (!fromNetwork && (_awareness > 0f || Marketing > 0f))
		{
			NetworkMessaging.SendUpdateMarketing(Parent.ID, ID, 0f, true, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_awareness = 0f;
		Marketing = 0f;
	}

	public bool ChangePrice(float newPrice)
	{
		NetworkMessaging.SendChangePrice(Parent.ID, ID, newPrice, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		return ActuallyChangePrice(newPrice);
	}

	public bool ActuallyChangePrice(float newPrice)
	{
		if (float.IsNaN(newPrice) || float.IsInfinity(newPrice) || Price < 1f)
		{
			return false;
		}
		LowestPrice = Mathf.Min(LowestPrice, newPrice);
		PriceChangeFact = ((newPrice == 0f) ? 2f : Mathf.Pow(LowestPrice / newPrice, newPrice / OriginalPrice * 3f));
		Price = newPrice;
		return true;
	}

	public double CalculateRelevancy()
	{
		Dictionary<string, double> dictionary = Parent.TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => 0.0);
		for (int num = 0; num < Features.Length; num++)
		{
			AddOnFeature addOnFeature = Features[num];
			if (addOnFeature.Level < 3)
			{
				dictionary[addOnFeature.Spec] += (double)(addOnFeature.DevTime * (float)FeatureFactors[num]) * addOnFeature.Submarkets.SubmarketDistance(Parent.Submarkets) * (double)Mathf.Max(1, addOnFeature.Level);
			}
		}
		double num2 = 0.0;
		double num3 = dictionary.Sum((KeyValuePair<string, double> x) => x.Value);
		foreach (KeyValuePair<string, double> item in dictionary)
		{
			num2 += (double)Parent.TechLevels[item.Key].GetRelevancy(SWCat) * (item.Value / num3);
		}
		return num2;
	}

	public void GetPriceAdjustedQuality(double[] output, SDateTime time)
	{
		float num = ((Price >= 1f) ? (MarketSimulation.PriceFact(Price, (double)GameSettings.Instance.simulation.GetIdealMarketPrice(Type) * PerceivedValue(time)) * PriceChangeFact) : 1f);
		for (int i = 0; i < 3; i++)
		{
			output[i] = SoftwareProduct.QualityForgiveness(Quality[i]) * (double)num;
		}
	}

	public double[] GetWeightedQualityAddition(SDateTime time, bool competitive)
	{
		if (time.Equals(_cachedWeightedMarketQualityDate, true) && _cachedWeightedMarketQuality != null)
		{
			return _cachedWeightedMarketQuality;
		}
		if (_cachedWeightedMarketQuality == null)
		{
			_cachedWeightedMarketQuality = new double[3];
		}
		double time2 = GetTime(time);
		float num = GetRep() * ((!competitive) ? 1f : (Owner.Player ? 0.01f : 0.04f));
		if (Type.Hardware)
		{
			num *= 2f;
		}
		float num2 = ((!competitive) ? 0.5f : (Owner.Player ? DifficultyValues.Difficulty.ProductReputationFactor : 0.002f));
		float num3 = Mathf.Sqrt(GetAwareness());
		uint num4 = (Parent.SubscriptionBased ? Parent.SubscriptionSum : Parent.UnitSum);
		float num5 = ((num4 != 0) ? (Mathf.Max(0f, Sales - Refunds) / (float)num4 * (competitive ? 0.01f : 0f)) : 0f);
		double num6 = (double)((num + num2).WeightOne(0.5f) * (num3 + num5)) * time2;
		double[] cachedWeightedMarketQuality = _cachedWeightedMarketQuality;
		lock (_priceCache)
		{
			GetPriceAdjustedQuality(_priceCache, time);
			for (int i = 0; i < 3; i++)
			{
				_priceCache[i] *= num6;
			}
			SWCat.GetFinalScoreFromSummary(_featureScoreSummation, Parent.TechLevels, _priceCache, Parent.Submarkets, cachedWeightedMarketQuality);
		}
		for (int j = 0; j < cachedWeightedMarketQuality.Length; j++)
		{
			cachedWeightedMarketQuality[j] *= time2;
		}
		_cachedWeightedMarketQualityDate = time;
		return cachedWeightedMarketQuality;
	}

	public float GetRep()
	{
		if (!Forced || Parent.Publishing == null)
		{
			return Owner.GetReputation(SWCat);
		}
		return SWCat.RepCut(Owner, Parent.Publishing.Publisher);
	}

	public double SimulateSales(double[] quality, SDateTime time, double timeFactor, double pvsd, List<KeyValuePair<uint, TechLevel>> patentRoyalties, double parentTime, float saleServerReq, ref uint totalDigitalSales)
	{
		float num = ((Price > 0f) ? (MarketSimulation.PricePenalty(Price, (double)MarketSimulation.Active.GetIdealMarketPrice(Type) * PerceivedValue(time)) * PriceChangeFact) : 4f);
		if (Price > 0f && Parent.SubscriptionBased)
		{
			num *= 0.5f;
		}
		double num2 = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num2 += quality[i] * Parent.Submarkets[i];
		}
		long num3 = Parent.UnitSum * (Type.PerUser - (Forced ? 1 : 0));
		num2 *= (double)((float)num3 * SWCat.GetPopularityFactor()) * RealQuality * timeFactor * (double)num * Parent.RealQuality;
		num2 /= (double)GameSettings.DaysPerMonth;
		if (Owner.Player)
		{
			float num4 = DifficultyValues.Difficulty.RecognitionSalesFactor;
			if (Type.Hardware)
			{
				num4 *= 0.75f;
			}
			float num5 = GetRep().WeightOne(num4);
			num2 *= (double)num5;
		}
		int num6 = 0;
		if (Followers != 0)
		{
			num6 = ((Followers < 100) ? ((int)Followers) : Mathf.RoundToInt((float)Followers * 0.1f / (float)GameSettings.DaysPerMonth));
			if (num6 > 0)
			{
				if (num6 >= Followers)
				{
					Followers = 0u;
				}
				else
				{
					Followers -= (uint)num6;
				}
				NetworkMessaging.SendChangeFollowers(Parent.ID, ID, Followers, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			num6 = Mathf.FloorToInt((float)num6 * num);
			if ((double)num6 > num2)
			{
				num2 = num6;
			}
		}
		uint reach = GetReach();
		reach = ((Sales <= reach) ? (reach - Sales) : 0u);
		num2 = Math.Min(reach, Math.Round(num2));
		double refunds = ((Price > 0f) ? Parent.GetRefundRate() : 0.0);
		IStockable limiter;
		MarketSimulation.FixSales(Utilities.RoundToInt(num2), Type.Hardware ? 1.0 : pvsd, refunds, num6, RealQuality, _saleScope, this, out limiter);
		MissedPhysicalCopies = _saleScope.MissedPhysicalSales;
		ChangeAllPhysicalStock(-_saleScope.PhysicalSales);
		MarketSimulation.Active.DoOutOfStockNotification(limiter, Owner, Traded, PublisherDeal.HasDeal(this, "Printing"), MissedPhysicalCopies > 0);
		MarketSimulation.Active.HandleDigitalDistributionLimiting(_saleScope, Owner, null);
		AddSalesData(_saleScope.DigitalSales, _saleScope.PhysicalSales, _saleScope.Refunds, time);
		LastMonthPhysical = _saleScope.PhysicalSales;
		TotalPhysical += (uint)_saleScope.PhysicalSales;
		double num7 = (float)_saleScope.DigitalSales * Price;
		double num8 = (float)_saleScope.PhysicalSales * Price;
		double num9 = num8 + num7;
		double num10 = 0.0;
		double num11 = ((Forced && Parent.Publishing != null) ? (num9 * (double)Parent.Publishing.GetApplicableRoyalty()) : 0.0);
		if (!Competitive && num9 > 0.0 && Parent.Framework != null && Parent.Framework.HasToPay(Owner))
		{
			num10 = num9 * (double)Parent.FrameworkRoyalty;
			Parent.Framework.Income += (float)num10;
		}
		double num12 = num8 * (double)MarketSimulation.DistributionStandardCut;
		double digCut = 0.0;
		if (num10 > 0.0)
		{
			NetworkMessaging.SendFrameworkPayment(Parent.Framework.ID, Parent.ID, (float)num10, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			Parent.Framework.Owner.MakeTransaction(num10, Company.TransactionCategory.Licenses, true, Name, true);
			Parent.FrameworkPayout += (float)num10;
		}
		if (num11 > 0.0)
		{
			Parent.Publishing.Publisher.MakeTransaction(num11, Company.TransactionCategory.Royalties, true);
			Parent.Publishing.AddCut(num11);
		}
		MarketSimulation.Active.HandleDigitalDistribution(_saleScope, Owner, null, saleServerReq, num7, ref digCut, ref totalDigitalSales);
		double num13 = 0.0;
		if (num9 > 0.0)
		{
			Parent.GetRoyalties(patentRoyalties);
			if (patentRoyalties != null)
			{
				for (int j = 0; j < patentRoyalties.Count; j++)
				{
					Company company = MarketSimulation.Active.GetCompany(patentRoyalties[j].Key);
					if (company != null)
					{
						double num14 = num9 * (double)patentRoyalties[j].Value.Royalty;
						patentRoyalties[j].Value.Income += (float)num14;
						company.MakeTransaction(num14, Company.TransactionCategory.Royalties, true, Name, true);
						num13 += num14;
					}
				}
			}
		}
		float num15 = 0f;
		if (HasWorkRoyalties)
		{
			double num16 = num9 - digCut - num12 - num13 - num11 - num10;
			if (num16 > 0.0)
			{
				foreach (KeyValuePair<Company, float> workRoyalty in GetWorkRoyalties())
				{
					double num17 = (double)workRoyalty.Value * num16;
					num15 += (float)num17;
					workRoyalty.Key.MakeTransaction(num17, Company.TransactionCategory.Royalties, true, Name, true);
				}
			}
		}
		if (!double.IsNaN(num9) && !double.IsInfinity(num9))
		{
			AddLoss((float)(num13 + digCut + num12 + num10 + num11 + (double)num15), SoftwareProduct.LossType.Other, true);
			Gross += num9;
			uint refunds2 = (uint)_saleScope.Refunds;
			Refunds += refunds2;
			uint num18 = (uint)(_saleScope.PhysicalSales + _saleScope.DigitalSales);
			Sales += num18;
			ValueTuple<int, int> valueTuple = MarketSimulation.Active.GenerateReviews(ID, time, GetReviewTargetScore(time), num18);
			AddReviews(valueTuple.Item1, valueTuple.Item2, time);
			if (time.Day == 0)
			{
				LastMonthIncome = 0f;
			}
			LastDayIncome = (float)num9;
			LastDayLoss = (float)(num12 + digCut + num13 + num10 + num11 + (double)num15);
			LastMonthIncome += (float)num9;
			Owner.MakeTransaction(num9, Company.TransactionCategory.Sales, true, "Addons", true);
			Owner.MakeTransaction(0.0 - num12, Company.TransactionCategory.Distribution, true, "Physical store cut");
			Owner.MakeTransaction(0.0 - digCut, Company.TransactionCategory.Distribution, true, "Digital store cut");
			Owner.MakeTransaction(0.0 - num13 - num10 - num11 - (double)num15, Company.TransactionCategory.Royalties, true, Name);
			NetworkMessaging.SendAddonSimulation(Parent.ID, ID, num9, _saleScope.Refunds, _saleScope.DigitalSales, _saleScope.PhysicalSales, LastMonthIncome, LastDayLoss, LastDayIncome, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		if (PriceChangeFact < 0.99f)
		{
			PriceChangeFact = Mathf.Lerp(PriceChangeFact, 1f, 1f / (float)GameSettings.DaysPerMonth / 12f);
		}
		return (double)num * RealQuality * GetTime(time) * (double)GetAwareness();
	}

	public void SyncSimulation(double gross, int refunds, int online, int offline, float lastMonthIncome, float lastDayIncome, float lastDayLoss, SDateTime time)
	{
		Gross += gross;
		Refunds += (uint)refunds;
		Sales += (uint)(online + offline);
		AddSalesData(online, offline, refunds, time);
		LastMonthIncome = lastMonthIncome;
		LastDayIncome = lastDayIncome;
		LastDayLoss = lastDayLoss;
		LastMonthPhysical = offline;
		TotalPhysical += (uint)offline;
	}

	public void LastDayClearStats()
	{
		LastMonthIncome = 0f;
		LastDayIncome = 0f;
		LastDayLoss = 0f;
		LastMonthPhysical = 0;
	}

	public void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
		lock (this)
		{
			if (!fromNetwork && cost != 0f)
			{
				if (immediate)
				{
					NetworkMessaging.SendAddLoss(Parent.ID, cost, type, ID, 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					NetworkManager.AddDirtyLoss(this, type, cost);
				}
			}
			if (type != SoftwareProduct.LossType.Publisher)
			{
				Loss += cost;
			}
			switch (type)
			{
			case SoftwareProduct.LossType.Copies:
				DistributionLoss += cost;
				break;
			case SoftwareProduct.LossType.Marketing:
				PostMarketingLoss += cost;
				break;
			}
		}
	}

	public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
		throw new NotImplementedException();
	}

	public float GetLicenseAmount()
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		return Name;
	}

	public void OnDoubleClick()
	{
		HUD.Instance.GetProductWindow(null).ShowAddonDetails(this);
	}

	public IReferenceFix FixReferences()
	{
		SoftwareProduct product = MarketSimulation.Active.GetProduct(Parent.ID, false);
		if (product == null)
		{
			return null;
		}
		return product.GetAddon(ID);
	}

	public string GetActualString()
	{
		return Name;
	}

	public double PerceivedValue(SDateTime time, bool withTech = true)
	{
		if (!time.Equals(_cachedPerceivedTime, true))
		{
			_cachedPerceivedValue = Type.PerceivedValue(Features, FeatureFactors, Parent.Category, withTech ? Parent.TechLevels : null);
			_cachedPerceivedTime = time;
		}
		return _cachedPerceivedValue;
	}

	public double GetMarketWeightedQuality(double[] quality)
	{
		return quality[0] * Parent.Submarkets[0] + quality[1] * Parent.Submarkets[1] + quality[2] * Parent.Submarkets[2];
	}

	public double GetTime(SDateTime time, float dieValue = 0.05f)
	{
		float num = Mathf.Max(0f, SDateTime.GetMonths(Release, time));
		double num2 = Utilities.Lerp((double)Math.Min(1f, DevTime / Type.OptimalDevTime) * ReleaseRelevancy, 1.0, GetMarketWeightedQuality(Quality), true) * (double)Type.Retention;
		return Math.Pow(Math.Pow(10.0, Math.Log10(dieValue) / num2), num);
	}

	public float GetPrintPrice(bool isAI = false)
	{
		if (!Type.Hardware)
		{
			return MarketSimulation.PhysicalCopyPrice;
		}
		return _hardwarePrice * (isAI ? 1.2f : MarketSimulation.HardwareCopyPriceFactor);
	}

	public int GetLastPhysicalSales()
	{
		return LastMonthPhysical;
	}

	public int GetSalesMonths()
	{
		return SDateTime.GetMonthsFlat(Release, SDateTime.Now());
	}

	public int GetLastMissedPhysicalSales()
	{
		return MissedPhysicalCopies;
	}

	public uint GetReach()
	{
		return (uint)(Parent.Userbase * (Type.PerUser - (Forced ? 1 : 0)));
	}

	public float GetRealQuality()
	{
		return (float)RealQuality;
	}

	public void AddToMarketing(float amount)
	{
		Marketing += amount;
		if (amount > 0f)
		{
			NetworkManager.AddDirtyMarketing(this);
		}
	}

	public bool IsMarketable()
	{
		return true;
	}

	public uint GetFollowers()
	{
		return Followers;
	}

	public uint GetMaxPhysicalCopies(out IStockable limiter)
	{
		limiter = this;
		return PhysicalCopies;
	}

	public void ChangeAllPhysicalStock(int change)
	{
		PhysicalCopies = PhysicalCopies.AddIntClamped(change);
	}

	public IList<uint> GetFeaturesFactors()
	{
		return FeatureFactors;
	}

	public IProductOrder PromoteHardware(uint copies)
	{
		return ManufactureOrder.PromoteProduct(this, copies);
	}

	public uint GetTotalPhysicalSales()
	{
		return TotalPhysical;
	}

	public void Trade(Company company)
	{
		NetworkMessaging.SendTradeIP((company != null) ? company.ID : 0u, Parent.ID, ID, new SDateTime(0), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		ActuallyTrade(company);
	}

	public void ActuallyTrade(Company company)
	{
		GameSettings.Instance.CancelPrintOrder(this, false);
		GameSettings.Instance.MyCompany.CancelAllWorkFor(this);
		Owner.AddOns.Remove(this);
		Owner = company;
		Owner.AddOns.Add(this);
		Traded = true;
		NetworkMeta.CheckDirty();
	}

	public static void HandleNews(AddOnProduct p, bool manualRelease)
	{
		if (p.Owner.Player)
		{
			NetworkMessaging.SendGenerateProductReview(p.Parent.ID, p.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			if (manualRelease)
			{
				FinalReviewGenerator.Review[] reviews = FinalReviewGenerator.GenerateReview(new ArticleGenerator.SoftwareReviewData(p));
				Newspaper.GenerateProductReview(p.Name, reviews);
				HUD.Instance.finalReviewWindow.Show(p, reviews);
			}
			else
			{
				Newspaper.GenerateProductReview(p);
			}
		}
	}

	public void TransferDistributionCost(int units)
	{
		uint num = PhysicalCopies + TotalPhysical;
		if (num != 0)
		{
			float num2 = DistributionLoss / (float)num;
			float num3 = Mathf.Min(DistributionLoss, (float)units * num2);
			AddLoss(0f - num3, SoftwareProduct.LossType.Copies, true);
			Parent.AddLoss(num3, SoftwareProduct.LossType.Copies, true);
		}
	}

	public void ClearRoyalties()
	{
		_workRoyalties.Clear();
	}

	public IEnumerable<KeyValuePair<Company, float>> GetWorkRoyalties()
	{
		for (int i = 0; i < _workRoyalties.Count; i++)
		{
			KeyValuePair<Company, float> keyValuePair = _workRoyalties[i];
			if (keyValuePair.Key.Bankrupt)
			{
				_workRoyalties.RemoveAt(i);
				i--;
			}
			else
			{
				yield return keyValuePair;
			}
		}
	}

	public void AddWorkRoyalty(Company c, float r)
	{
		r = Mathf.Min(r, 1f - _workRoyalties.SumSafe((KeyValuePair<Company, float> x) => x.Value));
		if (!(r > 0f))
		{
			return;
		}
		for (int num = 0; num < _workRoyalties.Count; num++)
		{
			if (_workRoyalties[num].Key == c)
			{
				_workRoyalties[num] = new KeyValuePair<Company, float>(c, _workRoyalties[num].Value + r);
				return;
			}
		}
		_workRoyalties.Add(new KeyValuePair<Company, float>(c, r));
	}

	public float GetReviewTargetScore(SDateTime time, bool withTech = true)
	{
		double marketWeightedQuality = GetMarketWeightedQuality(Quality);
		double num = PerceivedValue(time, false);
		double num2 = (withTech ? PerceivedValue(time) : num);
		double number = num2 / num;
		float num3 = (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(Type) * num2);
		float number2 = Mathf.Clamp01((Price <= num3) ? PriceChangeFact : (MarketSimulation.PriceFact(Price, num3) * PriceChangeFact));
		return Mathf.Clamp01((float)(marketWeightedQuality * number.WeightOne(0.75) * num.WeightOne(0.10000000149011612) * (double)number2.WeightOne(0.5f)));
	}
}
