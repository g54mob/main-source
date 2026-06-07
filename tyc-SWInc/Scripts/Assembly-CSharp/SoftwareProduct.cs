using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using SINetworking;
using UnityEngine;

[AltDeprecate("EnableServerHosting", typeof(bool))]
public class SoftwareProduct : IServerItem, IReferenceFix, IStockable, ILossable, IFormatColorObject, IDisplayable, IMarketable, IRoyaltyItem, IListDoubleClickable
{
	public enum LossType
	{
		Other = 0,
		Development = 1,
		Support = 2,
		Copies = 3,
		Marketing = 4,
		Printing = 5,
		Licenses = 6,
		Distribution = 7,
		Hosting = 8,
		Publisher = 9,
		Patents = 10,
		Framework = 11,
		LeadDesigner = 12,
		Server = 13,
		Deals = 14
	}

	public const int LossTypeCount = 15;

	public static readonly float DieValue = 0.25f;

	[AltWasFloat(0)]
	private readonly double[] _quality;

	[AltWasFloat(0)]
	public readonly double RealQuality;

	[IgnoreNetwork]
	public uint ExternalHosting;

	[IgnoreNetwork]
	public bool ExternalHostingActive;

	public uint Followers;

	public SoftwareAlpha MockWork;

	public SoftwareProduct MockSucceeded;

	public readonly string Name;

	public SoftwareType Type;

	public SoftwareCategory Category;

	[AltWasFloat(0)]
	public readonly double[] Submarkets = new double[3];

	[AltWasFloat(0)]
	public readonly double CreativityScore = 0.5;

	[Obsolete]
	[NameRedirection(new string[] { "OSs" })]
	public List<SoftwareProduct> OldOSs;

	public List<uint> _oss;

	public readonly uint ID;

	public int MissedPhysicalSales;

	public SoftwareProduct SequelTo;

	public SoftwareProduct Sequel;

	public SoftwareFramework Framework;

	public readonly float FrameworkRoyalty;

	public readonly SDateTime DevStart;

	public readonly SDateTime Release;

	public readonly float DevTime;

	public FeatureBase[] Features;

	[AltWasFloat(0)]
	public readonly double CodeQuality;

	[AltWasFloat(0)]
	public readonly double ArtQuality;

	[AltWasFloat(0)]
	public readonly double CodeProgress;

	[AltWasFloat(0)]
	public readonly double ArtProgress;

	public int VMajor = 1;

	public int VMinor;

	public int VRev;

	public Company DevCompany;

	public PublisherDeal Publishing;

	public readonly float RandomFactor;

	[AltWasFloat(0)]
	public readonly double SequelBonus;

	public bool InHouse;

	public uint PositiveReviews;

	public uint NegativeReviews;

	public List<int> PositiveReviewList;

	public List<int> NegativeReviewList;

	[NameRedirection(new string[] { "Bugs" })]
	private int _bugs;

	[NameRedirection(new string[] { "StartBugs" })]
	private int _startBugs = 1;

	public int VerifiedBugs;

	public float Marketing;

	public float FrameworkPayout;

	public readonly bool SubscriptionBased;

	private float _awareness;

	[AltWasFloat(0)]
	private Dictionary<string, double[]> _featureScoreSummation;

	public float ServerReq;

	public float Price;

	public float OriginalPrice;

	public float LowestPrice = -1f;

	public float PriceChangeFact = 1f;

	public float LicenseCost;

	public float AddonProfit;

	[IgnoreNetwork]
	public string Server;

	private List<float> _cashflow;

	private List<float> _licenseCashflow;

	private List<int> _unitOnlineSales;

	private List<int> _unitOfflineSales;

	private List<int> _refunds;

	[Obsolete]
	[NameRedirection(new string[] { "Tools" })]
	public Dictionary<SoftwareProduct, float> OldTools = new Dictionary<SoftwareProduct, float>();

	private Dictionary<uint, float> _tools;

	public Dictionary<SoftwareAddOn, List<AddOnProduct>> Addons = new Dictionary<SoftwareAddOn, List<AddOnProduct>>();

	public AddOnProduct[] ForcedAddons;

	[AltWasFloat(0)]
	public double AddonQualityEffect = 1.0;

	public List<AddOnProduct> IncludedAddons;

	private ScriptSystem.EntryPoint _entryPoints;

	public List<float> Rep = new List<float>();

	public Dictionary<string, TechLevel> TechLevels;

	private SDateTime LastAddedToCashflow;

	private SDateTime LastAddedToUnits;

	[AltWasFloat(0)]
	public double Sum;

	[AltWasFloat(0)]
	public double LicenseSum;

	public float LastMonthGross;

	public float LastDayGross;

	public float LastDayLoss;

	public int LastMonthPhysical;

	public uint TotalPhysical;

	[AltWasFloat(0)]
	public double ReleaseRelevancy;

	public uint UnitSum;

	public uint RefundSum;

	public uint SubscriptionSum;

	public int Userbase;

	public bool _archived;

	[IgnoreNetwork]
	public bool PlayerArchived;

	public SDateTime LastSale;

	public SDateTime LastSaleUpdate;

	public Employee LeadDesigner;

	public bool DesignerOwned;

	public bool DesignerRoyalties;

	[AltWasFloat(0)]
	public double[] LossBreakdown;

	[AltWasFloat(0)]
	public double Loss;

	public float OSSalesBoost;

	public SDateTime? LastUpdated;

	private float _activeLoss;

	public float BoughtFor = -1f;

	private string inventor;

	public readonly uint InventorID;

	public float[] ProfitAward;

	public List<MarketEvent> MarketEvents = new List<MarketEvent>();

	[AltWasFloat(0)]
	private double _bigProjectFactor = -1.0;

	public DistributionPlatform ExclusiveStore;

	public SDateTime ExclusiveEnd;

	public bool HadOSWarning;

	private Dictionary<string, object> _scriptDictionary;

	[IgnoreNetwork]
	private bool _stockNotifications = true;

	private int _hardwareMask;

	private int _hardwareInputMask;

	private float _hardwarePrice;

	public static List<float> EmptyFlow = new List<float>();

	public static List<int> EmptyUnit = new List<int>();

	public static FloatInterpolator CreativityAwarenessFactor = new FloatInterpolator((float x) => (!(x < 0.5f)) ? Mathf.Pow(2f * (x - 0.5f), 4f) : 0f, 100);

	[AltWasFloat(0)]
	private static double[] _priceCache = new double[3];

	private static FloatInterpolator[] _creativityFactors = new FloatInterpolator[3]
	{
		new FloatInterpolator(0.4f, 0.4f, 0.4f, 0.4f, 0.6f, 0.6f, 0.6f, 0.6f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.80138886f, 73f / 90f, 0.8375f, 8f / 9f, 0.9736111f, 1.1f),
		new FloatInterpolator(0.3f, 0.3f, 0.3f, 0.3f, 0.5f, 0.5f, 0.5f, 0.5f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.6f, 0.70185184f, 0.71481484f, 0.75f, 0.8185185f, 0.9314815f, 1.1f),
		new FloatInterpolator(0.2f, 0.2f, 0.2f, 0.2f, 0.3f, 0.3f, 0.3f, 0.3f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.60231483f, 0.61851853f, 0.6625f, 101f / 135f, 0.88935184f, 1.1f)
	};

	[NonSerialized]
	private double[] _cachedWeightedMarketQuality;

	[NonSerialized]
	private SDateTime _cachedWeightedMarketQualityDate;

	private uint _physicalCopies;

	private List<KeyValuePair<Company, float>> _workRoyalties = new List<KeyValuePair<Company, float>>();

	public int LoadIncidents;

	public int MaxLoadIncidents;

	[AltWasFloat(0)]
	private double _cachedPerceivedValue;

	private SDateTime _cachedPerceivedTime;

	private uint _addonID = 1u;

	public bool IsMock
	{
		get
		{
			if (MockSucceeded == null)
			{
				return MockWork != null;
			}
			return true;
		}
	}

	public double[] Quality
	{
		get
		{
			return _quality;
		}
	}

	public bool HasSequel
	{
		get
		{
			return Sequel != null;
		}
	}

	public int OSCount
	{
		get
		{
			InitOS();
			return _oss.Count;
		}
	}

	public uint CopiesPerBox
	{
		get
		{
			return 1000u;
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
			if (value > _physicalCopies)
			{
				uint copiesAdded = value - _physicalCopies;
				RunScripts(ScriptSystem.EntryPoint.NewCopies, ScriptSystem.CopyScope.GetTempScope(this, copiesAdded));
			}
			if (!IsMock)
			{
				NetworkMessaging.SendChangePhysicalCopies(ID, 0u, value, 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			_physicalCopies = value;
		}
	}

	public bool OpenSource
	{
		get
		{
			if (!SubscriptionBased)
			{
				return Price == 0f;
			}
			return false;
		}
	}

	public int ReleaseYear
	{
		get
		{
			return Release.RealYear;
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

	public int Bugss
	{
		get
		{
			return _bugs;
		}
	}

	public int StartBugss
	{
		get
		{
			return _startBugs;
		}
	}

	public int FixableBugs
	{
		get
		{
			return Mathf.Clamp(VerifiedBugs - (StartBugss - Bugss), 0, Bugss);
		}
	}

	public int ToolCount
	{
		get
		{
			InitTools();
			return _tools.Count;
		}
	}

	public bool Traded
	{
		get
		{
			return inventor != null;
		}
	}

	public bool OriginalOwner
	{
		get
		{
			if (inventor != null)
			{
				return DevCompany.ID == InventorID;
			}
			return true;
		}
	}

	public string Inventor
	{
		get
		{
			return inventor ?? DevCompany.Name;
		}
	}

	public bool StockNotifications
	{
		get
		{
			if (_stockNotifications)
			{
				return !PlayerArchived;
			}
			return false;
		}
		set
		{
			_stockNotifications = value;
		}
	}

	public bool ActualStockNotifications
	{
		get
		{
			return _stockNotifications;
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

	public IManufacturable Manufacturing
	{
		get
		{
			return Category;
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
			return Type;
		}
	}

	public SoftwareCategory SWCat
	{
		get
		{
			return Category;
		}
	}

	public string Version
	{
		get
		{
			return VMajor + "." + VMinor + "." + VRev;
		}
	}

	public bool Archived
	{
		get
		{
			return _archived;
		}
	}

	public bool HasWorkRoyalties
	{
		get
		{
			return _workRoyalties.Count > 0;
		}
	}

	public bool UsesISP
	{
		get
		{
			return true;
		}
	}

	public bool IsReadOnlyJob
	{
		get
		{
			return false;
		}
	}

	public void InitOS()
	{
		if (_oss != null)
		{
			return;
		}
		if (OldOSs == null || OldOSs.Count == 0)
		{
			_oss = new List<uint>();
			return;
		}
		_oss = OldOSs.SelectInPlaceList((SoftwareProduct x) => x.ID);
		OldOSs.Clear();
	}

	public void AddOS(SoftwareProduct p)
	{
		InitOS();
		_oss.Add(p.ID);
	}

	public void AddOSs(IList<SoftwareProduct> oss)
	{
		InitOS();
		_oss.AddRange(oss.Select((SoftwareProduct x) => x.ID));
	}

	public void RemoveOS(SoftwareProduct p)
	{
		InitOS();
		_oss.Remove(p.ID);
	}

	public IEnumerable<SoftwareProduct> GetOSs()
	{
		InitOS();
		for (int i = 0; i < _oss.Count; i++)
		{
			uint iD = _oss[i];
			SoftwareProduct product = MarketSimulation.Active.GetProduct(iD, true);
			if (product != null)
			{
				yield return product;
				continue;
			}
			_oss.RemoveAt(i);
			i--;
		}
	}

	public bool HasOS(SoftwareProduct tool)
	{
		InitOS();
		return _oss.Contains(tool.ID);
	}

	public void ChangePhysicalCopiesDirectly(uint newValue)
	{
		_physicalCopies = newValue;
	}

	public void AddReviews(int positive, int negative, SDateTime time)
	{
		if (positive + negative > 0)
		{
			NetworkMessaging.SendAddReviews(ID, 0u, positive, negative, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
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

	public void InitTools()
	{
		if (_tools != null)
		{
			return;
		}
		if (OldTools.Count == 0)
		{
			_tools = new Dictionary<uint, float>();
			return;
		}
		_tools = OldTools.ToDictionary((KeyValuePair<SoftwareProduct, float> x) => x.Key.ID, (KeyValuePair<SoftwareProduct, float> x) => x.Value);
		OldTools.Clear();
	}

	public void AddTool(SoftwareProduct p, float value)
	{
		InitTools();
		_tools.AddUp(p.ID, value);
	}

	public void AddTools(Dictionary<SoftwareProduct, float> tools)
	{
		InitTools();
		foreach (KeyValuePair<SoftwareProduct, float> tool in tools)
		{
			_tools.AddUp(tool.Key.ID, tool.Value);
		}
	}

	public void RemoveTool(SoftwareProduct p)
	{
		InitTools();
		_tools.Remove(p.ID);
	}

	public IEnumerable<ValueTuple<SoftwareProduct, float>> GetTools()
	{
		InitTools();
		foreach (KeyValuePair<uint, float> tool in _tools)
		{
			SoftwareProduct product = MarketSimulation.Active.GetProduct(tool.Key, true);
			if (product != null)
			{
				yield return new ValueTuple<SoftwareProduct, float>(product, tool.Value);
			}
		}
	}

	public float GetToolValue(SoftwareProduct tool)
	{
		InitTools();
		return _tools.GetOrDefault(tool.ID, 0f);
	}

	public bool HasTool(SoftwareProduct tool)
	{
		InitTools();
		return _tools.ContainsKey(tool.ID);
	}

	public void UpdateForcedAddonQualityEffect()
	{
		AddonQualityEffect = 1.0;
		if (ForcedAddons != null)
		{
			for (int i = 0; i < ForcedAddons.Length; i++)
			{
				AddOnProduct addOnProduct = ForcedAddons[i];
				AddonQualityEffect *= addOnProduct.RealQuality.WeightOne(addOnProduct.Type.Forced.Value);
			}
		}
	}

	public void PutVar(string name, object value)
	{
		if (_scriptDictionary == null)
		{
			_scriptDictionary = new Dictionary<string, object>();
		}
		_scriptDictionary[name] = value;
	}

	public object GetVar(string name, object defaultValue)
	{
		if (_scriptDictionary != null)
		{
			return _scriptDictionary.GetOrDefault(name, defaultValue);
		}
		return defaultValue;
	}

	public List<float> GetCashflow(bool license)
	{
		List<float> list = (license ? _licenseCashflow : _cashflow);
		if (list == null)
		{
			return EmptyFlow;
		}
		return list;
	}

	public void RemoveFromGame()
	{
		NetworkMessaging.SendArchiveProduct(ID, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		ActuallyRemoveFromGame();
	}

	public bool CanMakeExclusive()
	{
		if (ExclusiveEnd < SDateTime.Now())
		{
			ExclusiveStore = null;
		}
		return ExclusiveStore == null;
	}

	public void ActuallyRemoveFromGame()
	{
		DevCompany.Products.Remove(this);
		foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(true))
		{
			allProduct.RemoveTool(this);
			allProduct.RemoveOS(this);
		}
		HUD.Instance.dealWindow.CancelProductDeals(this, false);
		foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in Addons)
		{
			for (int i = 0; i < addon.Value.Count; i++)
			{
				AddOnProduct addOnProduct = addon.Value[i];
				Company owner = addOnProduct.Owner;
				if (owner != null)
				{
					owner.AddOns.Remove(addOnProduct);
				}
				MarketSimulation.Active.AddOnProducts.Remove(addOnProduct);
				HUD.Instance.dealWindow.CancelProductDeals(addOnProduct);
			}
		}
		PublisherDeal publishing = Publishing;
		if (publishing != null)
		{
			publishing.Abandon(false);
		}
		NetworkMeta.CheckDirty();
	}

	public double GetBigProjectFactor()
	{
		if (!(_bigProjectFactor < 0.0))
		{
			return _bigProjectFactor;
		}
		return 1.0;
	}

	public bool Archive()
	{
		NetworkMessaging.SendArchiveProduct(ID, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		return ActuallyArchive();
	}

	public bool ActuallyArchive()
	{
		if (!_archived)
		{
			_archived = true;
			_unitOfflineSales = null;
			_unitOnlineSales = null;
			_refunds = null;
			_cashflow = null;
			_licenseCashflow = null;
			LossBreakdown = null;
			Rep.Clear();
			InitTools();
			_tools.Clear();
			LeadDesigner = null;
			_workRoyalties.Clear();
			PositiveReviewList = null;
			NegativeReviewList = null;
		}
		MarketEvents.Clear();
		foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in Addons)
		{
			foreach (AddOnProduct item in addon.Value)
			{
				item.UnitOfflineSales = null;
				item.UnitOnlineSales = null;
				item.RefundsSales = null;
				item.PositiveReviewList = null;
				item.NegativeReviewList = null;
				item.ClearRoyalties();
			}
		}
		ExclusiveStore = null;
		SoftwareProduct softwareProduct = this;
		while (softwareProduct.Sequel != null)
		{
			softwareProduct = softwareProduct.Sequel;
		}
		SoftwareProduct last = softwareProduct;
		bool flag;
		for (flag = softwareProduct.Archived; flag && softwareProduct.SequelTo != null; flag &= softwareProduct.Archived)
		{
			softwareProduct = softwareProduct.SequelTo;
		}
		NetworkMeta.CheckDirty();
		if (flag)
		{
			SimulatedCompany simulatedCompany;
			if (DevCompany.IsLocalPlayer)
			{
				if (DevCompany.WorkItems.OfType<SoftwareWorkItem>().Any((SoftwareWorkItem x) => x.SequelTo == last))
				{
					return false;
				}
			}
			else if ((simulatedCompany = DevCompany as SimulatedCompany) != null)
			{
				if (simulatedCompany.Releases.Any((SimulatedCompany.ProductPrototype x) => x.SequelTo == last) || simulatedCompany.ProjectQueue.Any((SimulatedCompany.ProductPrototype x) => x.SequelTo == last))
				{
					return false;
				}
			}
			else if (DevCompany.GetReleases().Any((ScheduledRelease x) => x.SequelTo == last))
			{
				return false;
			}
		}
		PublisherDeal publishing = Publishing;
		if (publishing != null)
		{
			publishing.Abandon(false);
		}
		return flag;
	}

	public IEnumerable<SoftwareProduct> GetEntireIP()
	{
		SoftwareProduct s = this;
		while (s.Sequel != null)
		{
			s = s.Sequel;
		}
		yield return s;
		while (s.SequelTo != null)
		{
			s = s.SequelTo;
			yield return s;
		}
	}

	public bool IsSameIP(SoftwareProduct p)
	{
		if (this == p)
		{
			return true;
		}
		for (SoftwareProduct sequel = Sequel; sequel != null; sequel = sequel.Sequel)
		{
			if (sequel == p)
			{
				return true;
			}
		}
		for (SoftwareProduct sequel = SequelTo; sequel != null; sequel = sequel.SequelTo)
		{
			if (sequel == p)
			{
				return true;
			}
		}
		return false;
	}

	public SoftwareProduct GetFirstRelease()
	{
		SoftwareProduct softwareProduct = this;
		while (softwareProduct.SequelTo != null)
		{
			softwareProduct = softwareProduct.SequelTo;
		}
		return softwareProduct;
	}

	public List<int> GetUnitSales(bool online)
	{
		List<int> list = (online ? _unitOnlineSales : _unitOfflineSales);
		if (list == null)
		{
			return EmptyUnit;
		}
		return list;
	}

	public List<int> GetRefunds()
	{
		if (_refunds == null)
		{
			return EmptyUnit;
		}
		return _refunds;
	}

	public float GetLicenseCost(bool player)
	{
		if (player && !DevCompany.Player)
		{
			return LicenseCost * DifficultyValues.Difficulty.PlayerLicenseCostFactor;
		}
		return LicenseCost;
	}

	public void AddRepChange(int fanGain, SDateTime time)
	{
		if (fanGain != 0 || Rep.Count == 0 || Rep[Rep.Count - 1] != 0f)
		{
			NetworkMessaging.SendAddProductRep(ID, fanGain, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyAddRepChange(fanGain, time);
	}

	public void ActuallyAddRepChange(int fanGain, SDateTime time)
	{
		int monthsFlat = SDateTime.GetMonthsFlat(Release, time);
		if (fanGain != 0)
		{
			for (int i = Rep.Count; i < monthsFlat; i++)
			{
				Rep.Add(0f);
			}
			if (Rep.Count == 0)
			{
				Rep.Add(0f);
			}
			Rep[Mathf.Clamp(monthsFlat, 0, Rep.Count - 1)] += fanGain;
		}
		else if (Rep.Count > 0 && Rep[Rep.Count - 1] != 0f)
		{
			Rep.Add(0f);
		}
	}

	public void AddToCashflow(int onlineUnits, int offlineUnits, int refunds, float amount, float license, SDateTime now)
	{
		AddToCashflow(onlineUnits, offlineUnits, refunds, amount, amount, license, now);
	}

	public void AddToCashflow(int onlineUnits, int offlineUnits, int refunds, float gross, float profit, float license, SDateTime now)
	{
		if (onlineUnits > 0 || offlineUnits > 0 || refunds > 0 || gross > 0f || profit > 0f || license > 0f)
		{
			NetworkMessaging.SendProductCashflow(ID, onlineUnits, offlineUnits, refunds, gross, profit, license, now, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyAddToCashflow(onlineUnits, offlineUnits, refunds, gross, profit, license, now);
	}

	public void ChangeLastSale(SDateTime now, bool clear)
	{
		bool flag = now.Year > LastSaleUpdate.Year || (now.Year == LastSaleUpdate.Year && now.Month > LastSaleUpdate.Month);
		if (!flag && (now.Year != LastSaleUpdate.Year || now.Month != LastSaleUpdate.Month || now.Day <= LastSaleUpdate.Day))
		{
			return;
		}
		LastSaleUpdate = now;
		if (clear)
		{
			LastDayGross = 0f;
			LastDayLoss = 0f;
			if (flag)
			{
				LastMonthGross = 0f;
			}
		}
	}

	public void ActuallyAddToCashflow(int onlineUnits, int offlineUnits, int refunds, float gross, float profit, float license, SDateTime now)
	{
		bool flag = true;
		bool flag2 = true;
		gross += license;
		profit += license;
		switch (now.GetSimpleOrder(LastSaleUpdate, false))
		{
		case 0:
			LastMonthGross += gross;
			break;
		case 1:
			LastMonthGross = gross;
			break;
		}
		switch (now.GetSimpleOrder(LastSaleUpdate, true))
		{
		case 0:
			LastDayGross += gross;
			LastDayLoss += gross - profit;
			break;
		case 1:
			LastDayGross = gross;
			LastDayLoss = gross - profit;
			break;
		}
		ChangeLastSale(now, false);
		if (gross != 0f && now > LastSale)
		{
			LastSale = now;
		}
		LastMonthPhysical += offlineUnits;
		TotalPhysical += (uint)offlineUnits;
		if (SubscriptionBased)
		{
			onlineUnits += offlineUnits;
			offlineUnits = Userbase;
			SubscriptionSum += (uint)onlineUnits;
		}
		if (_cashflow != null && _cashflow[_cashflow.Count - 1] < 0.01f && _licenseCashflow[_licenseCashflow.Count - 1] < 0.01f)
		{
			flag = gross >= 0.01f;
		}
		if (_unitOfflineSales != null && _unitOfflineSales[_unitOfflineSales.Count - 1] < 1 && _unitOnlineSales[_unitOnlineSales.Count - 1] < 1)
		{
			flag2 = onlineUnits != 0 || offlineUnits != 0 || refunds != 0;
		}
		if (!flag && !flag2)
		{
			return;
		}
		if (_unitOfflineSales == null)
		{
			LastAddedToUnits = ((now > LastAddedToUnits) ? now : LastAddedToUnits);
			_unitOfflineSales = new List<int> { 0 };
			_unitOnlineSales = new List<int> { 0 };
			_refunds = new List<int> { 0 };
		}
		if (_cashflow == null)
		{
			LastAddedToCashflow = now;
			_cashflow = new List<float> { 0f };
			_licenseCashflow = new List<float> { 0f };
		}
		if (flag && (LastAddedToCashflow.Month != now.Month || LastAddedToCashflow.Year != now.Year))
		{
			int monthsFlat = SDateTime.GetMonthsFlat(LastAddedToCashflow, now);
			for (int i = 0; i < monthsFlat; i++)
			{
				_cashflow.Add(0f);
				_licenseCashflow.Add(0f);
			}
		}
		if (flag2 && (LastAddedToUnits.Month != now.Month || LastAddedToUnits.Year != now.Year))
		{
			int monthsFlat2 = SDateTime.GetMonthsFlat(LastAddedToUnits, now);
			for (int j = 0; j < monthsFlat2; j++)
			{
				_unitOfflineSales.Add(0);
				_unitOnlineSales.Add(0);
				_refunds.Add(0);
			}
		}
		int monthsFlat3 = SDateTime.GetMonthsFlat(Release, now);
		if (flag)
		{
			int index = Mathf.Clamp(monthsFlat3, 0, _cashflow.Count - 1);
			_cashflow[index] += profit;
			_licenseCashflow[index] += license;
		}
		if (SubscriptionBased && _unitOfflineSales[_unitOfflineSales.Count - 1] > 0)
		{
			offlineUnits = 0;
		}
		if (flag2)
		{
			int index2 = Mathf.Clamp(monthsFlat3, 0, _unitOfflineSales.Count - 1);
			_unitOfflineSales[index2] += offlineUnits;
			_unitOnlineSales[index2] += onlineUnits;
			_refunds[index2] += refunds;
		}
		LicenseSum += license;
		Sum += gross;
		UnitSum += (uint)(offlineUnits + onlineUnits);
		RefundSum += (uint)refunds;
		if (flag)
		{
			LastAddedToCashflow = ((now > LastAddedToCashflow) ? now : LastAddedToCashflow);
		}
		if (flag2)
		{
			LastAddedToUnits = ((now > LastAddedToUnits) ? now : LastAddedToUnits);
		}
	}

	public void ClearAddonSalesStats()
	{
		if (Addons.Count <= 0)
		{
			return;
		}
		foreach (List<AddOnProduct> value in Addons.Values)
		{
			for (int i = 0; i < value.Count; i++)
			{
				value[i].LastDayClearStats();
			}
		}
	}

	public SoftwareProduct()
	{
	}

	public SoftwareProduct(string name, SoftwareType type, SoftwareCategory category, SoftwareProduct[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, double[] marketQuality, double creativityScore, float price, bool subscription, double[] submarkets, SDateTime start, SDateTime release, int bugs, bool inHouse, Company company, SoftwareProduct sequelto, uint id, double loss, FeatureBase[] features, Dictionary<string, TechLevel> techs, string server, uint followers, SoftwareFramework framework, float frameworkRoyalty, Dictionary<SoftwareProduct, float> newTools, SoftwareAlpha mock = null, byte[] hardwareDesign = null)
		: this(name, type, category, os, codeProgress, artProgress, codeQuality, artQuality, marketQuality, creativityScore, price, subscription, submarkets, start, release, bugs, inHouse, company, sequelto, id, new double[1] { loss }, features, techs, server, followers, framework, frameworkRoyalty, newTools, mock, hardwareDesign)
	{
	}

	public float GetMaxAwareness(AddOnProduct p)
	{
		List<AddOnProduct> value;
		if (p.Competitive && Addons.TryGetValue(p.Type, out value))
		{
			return value.MaxSafe((AddOnProduct x) => x.GetRealAwareness(), 1f, 1f);
		}
		return 1f;
	}

	public void SendNetwork()
	{
		if (NetworkManager.IsConnected)
		{
			InitOS();
			InitTools();
			string name = Name.StripRichTags();
			uint iD = Type.ID;
			uint iD2 = Category.ID;
			uint[] os = _oss.ToArray();
			float randomFactor = RandomFactor;
			float awareness = _awareness;
			double codeProgress = CodeProgress;
			double artProgress = ArtProgress;
			double codeQuality = CodeQuality;
			double artQuality = ArtQuality;
			double[] quality = _quality;
			double creativityScore = CreativityScore;
			float price = Price;
			bool subscriptionBased = SubscriptionBased;
			double[] submarkets = Submarkets;
			SDateTime devStart = DevStart;
			SDateTime release = Release;
			int bugss = Bugss;
			bool inHouse = InHouse;
			uint iD3 = DevCompany.ID;
			SoftwareProduct sequelTo = SequelTo;
			uint sequelto = ((sequelTo != null) ? sequelTo.ID : 0);
			double sequelBonus = SequelBonus;
			uint iD4 = ID;
			uint[] features = Features.SelectInPlace((FeatureBase x) => x.ID);
			Dictionary<string, int> techs = TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.Year);
			uint followers = Followers;
			SoftwareFramework framework = Framework;
			NetworkMessaging.SendAddProduct(name, iD, iD2, os, randomFactor, awareness, codeProgress, artProgress, codeQuality, artQuality, quality, creativityScore, price, subscriptionBased, submarkets, devStart, release, bugss, inHouse, iD3, sequelto, sequelBonus, iD4, features, techs, followers, (framework != null) ? framework.ID : 0u, FrameworkRoyalty, _tools, HardwareDesign, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	private static T GetOrThrow<T>(T get, string identity, bool justLog = false)
	{
		if (get == null)
		{
			if (!justLog)
			{
				throw new Exception("Failed creating product due to missing " + typeof(T).Name + " " + identity);
			}
			Debug.Log("Failed fully creating product due to missing " + typeof(T).Name + " " + identity);
		}
		return get;
	}

	public SoftwareProduct(string name, uint type, uint category, uint[] os, float randomFactor, float awareness, double codeProgress, double artProgress, double codeQuality, double artQuality, double[] marketQuality, double creativityScore, float price, bool subscription, double[] submarkets, SDateTime start, SDateTime release, int bugs, bool inHouse, uint company, uint sequelto, double sequelBonus, uint id, uint[] features, Dictionary<string, int> techs, uint followers, uint framework, float frameworkRoyalty, Dictionary<uint, float> tools, byte[] hardwareDesign)
	{
		Name = name;
		Type = MarketSimulation.Active.GetSoftwareType(type);
		Category = Type.GetCategory(category);
		InventorID = company;
		Framework = MarketSimulation.Active.GetFramework(framework);
		FrameworkRoyalty = frameworkRoyalty;
		List<SoftwareProduct> arr = os.SelectInPlaceList((uint x) => GetOrThrow(MarketSimulation.Active.GetProduct(x, false), "OS: " + x));
		_oss = arr.SelectInPlaceList((SoftwareProduct x) => x.ID);
		Submarkets = submarkets;
		Dictionary<SoftwareProduct, float> tools2 = tools.ToDictionaryNotNull((KeyValuePair<uint, float> x) => GetOrThrow(MarketSimulation.Active.GetProduct(x.Key, false), "Tool: " + x.Key, true), (KeyValuePair<uint, float> x) => x.Value);
		AddTools(tools2);
		Features = features.SelectInPlace(Type.GetFeature);
		TechLevels = techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => GetOrThrow(MarketSimulation.Active.GetTechLevel(x.Key, x.Value), x.Key + x.Value));
		CodeProgress = Utilities.Clamp01(codeProgress);
		ArtProgress = Utilities.Clamp01(artProgress);
		CodeQuality = Utilities.Clamp01(codeQuality);
		ArtQuality = Utilities.Clamp01(artQuality);
		RealQuality = Utilities.Clamp01(Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
		_quality = marketQuality;
		_featureScoreSummation = Category.GetSummarizedMarketScore(Features);
		CreativityScore = creativityScore;
		DevStart = start;
		LastSaleUpdate = (LastSale = (Release = release));
		_startBugs = (_bugs = bugs);
		SequelTo = ((sequelto == 0) ? null : MarketSimulation.Active.GetProduct(sequelto, false));
		SoftwareProduct sequelTo = SequelTo;
		while (sequelTo != null)
		{
			sequelTo = sequelTo.SequelTo;
			VMajor++;
		}
		DevTime = Type.DevTime(Features, Category, null, TechLevels, OSCount, null, false, SequelTo);
		SubscriptionBased = subscription;
		LowestPrice = (OriginalPrice = (Price = price));
		LicenseCost = (float)((double)(price * 10f) / (SubscriptionBased ? 0.08 : 1.0));
		InHouse = Type.InHouse && inHouse;
		DevCompany = MarketSimulation.Active.GetCompany(company);
		RandomFactor = randomFactor;
		if (SequelTo != null && (!SequelTo.Type.Equals(Type) || SequelTo.DevCompany == null || SequelTo.DevCompany != DevCompany || SequelTo.Sequel != null))
		{
			SequelTo = null;
		}
		if (SequelTo != null && SequelTo.Sequel == null && !IsMock)
		{
			SequelTo.Sequel = this;
			HUD.Instance.dealWindow.CancelBids(SequelTo);
		}
		SequelBonus = sequelBonus;
		_awareness = awareness;
		Followers = followers;
		ID = id;
		ServerReq = SoftwareType.GetServerRequirement(Features);
		ReleaseRelevancy = CalculateRelevancy();
		if (!IsMock)
		{
			RegisterServer();
			RegisterOSSupport(release);
		}
		_entryPoints = ScriptSystem.EntryPoint.None;
		for (int num = 0; num < Features.Length; num++)
		{
			SubFeature subFeature;
			if ((subFeature = Features[num] as SubFeature) != null && subFeature.Level == 3)
			{
				_entryPoints |= subFeature.GetEntryPoints();
			}
		}
		if (!IsMock && DevCompany.IsLocalPlayer)
		{
			GameSettings.Instance.RegisterStat("ProductsReleased", 1f);
		}
		_entryPoints &= ScriptSystem.EntryPoint.ValidForProduct;
		if (Category.Hardware)
		{
			Category.Manufacturing.GetProcessInfo(Features, null, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
			HardwareDesign = hardwareDesign ?? HardwareDesignInstance.GenerateRandomDesign(Category.Manufacturing, SequelTo, this, null, Features, null);
		}
		CalculateBigProjectFactor();
	}

	private void CalculateBigProjectFactor()
	{
		_bigProjectFactor = SoftwareType.BigProjectEffect(Type.GetOptimalDevTime(Category), RealQuality, CreativityScore, Type.SimpleDevTime(Features, Category, TechLevels));
	}

	public SoftwareProduct(string name, SoftwareType type, SoftwareCategory category, SoftwareProduct[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, double[] marketQuality, double creativityScore, float price, bool subscription, double[] submarkets, SDateTime start, SDateTime release, int bugs, bool inHouse, Company company, SoftwareProduct sequelto, uint id, double[] loss, FeatureBase[] features, Dictionary<string, TechLevel> techs, string server, uint followers, SoftwareFramework framework, float frameworkRoyalty, Dictionary<SoftwareProduct, float> newTools, SoftwareAlpha mock = null, byte[] hardwareDesign = null)
	{
		MockWork = mock;
		Name = name;
		Type = type;
		Category = category;
		InventorID = company.ID;
		if (mock == null)
		{
			company.ReleaseNow(category, release);
			company.AddMarketEvent(new MarketEvent(MarketEvent.EventType.ProductRelease, release, id), false);
		}
		Framework = framework;
		FrameworkRoyalty = frameworkRoyalty;
		_oss = ((os != null) ? os.SelectInPlaceList((SoftwareProduct x) => x.ID) : new List<uint>());
		Submarkets = submarkets;
		AddTools(newTools);
		Features = features ?? Type.Features.Values.Where((FeatureBase x) => x.IsForced(category.Name)).ToArray();
		TechLevels = techs;
		CodeProgress = Utilities.Clamp01(codeProgress);
		ArtProgress = Utilities.Clamp01(artProgress);
		CodeQuality = Utilities.Clamp01(codeQuality);
		ArtQuality = Utilities.Clamp01(artQuality);
		RealQuality = Utilities.Clamp01(Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, features));
		_quality = marketQuality;
		_featureScoreSummation = Category.GetSummarizedMarketScore(Features);
		CreativityScore = creativityScore;
		DevStart = start;
		LastSaleUpdate = (LastSale = (Release = release));
		_startBugs = (_bugs = bugs);
		SequelTo = sequelto;
		SoftwareProduct sequelTo = SequelTo;
		while (sequelTo != null)
		{
			sequelTo = sequelTo.SequelTo;
			VMajor++;
		}
		DevTime = Type.DevTime(Features, Category, null, techs, OSCount, null, false, SequelTo);
		SubscriptionBased = subscription;
		LowestPrice = (OriginalPrice = (Price = price));
		LicenseCost = (float)((double)(price * 10f) / (SubscriptionBased ? 0.08 : 1.0));
		InHouse = Type.InHouse && inHouse;
		DevCompany = company;
		RandomFactor = Utilities.RandomGaussClamped(1f, 0.2f, MarketSimulation.Active.Random);
		if (SequelTo != null && (!SequelTo.Type.Equals(Type) || SequelTo.DevCompany == null || SequelTo.DevCompany != DevCompany || SequelTo.Sequel != null))
		{
			SequelTo = null;
		}
		if (SequelTo != null && SequelTo.Sequel == null && !IsMock)
		{
			SequelTo.Sequel = this;
			HUD.Instance.dealWindow.CancelBids(SequelTo);
		}
		SequelBonus = CalculateSequelBonus(SequelTo, PerceivedValue(Release), GetMarketWeightedQuality(Quality) * CreativityScore, Submarkets, SubscriptionBased, Release);
		if (loss.Length > 1)
		{
			LossBreakdown = loss;
		}
		for (int num = 0; num < loss.Length; num++)
		{
			Loss += loss[num];
		}
		float num2 = Mathf.Max(1f, GameSettings.Instance.simulation.GetFollowerReach(Type, Category, GetOSs()));
		_awareness = (float)((double)Mathf.Clamp01((float)followers / num2) * SequelBonus * (double)GameSettings.Instance.simulation.GetMaxAwareness(this));
		Followers = followers / 2;
		ID = id;
		ServerReq = SoftwareType.GetServerRequirement(Features);
		Server = server;
		ReleaseRelevancy = (float)CalculateRelevancy();
		if (!IsMock)
		{
			RegisterServer();
			RegisterOSSupport(release);
			DevCompany.UnscheduleRelease(id);
		}
		_entryPoints = ScriptSystem.EntryPoint.None;
		for (int num3 = 0; num3 < Features.Length; num3++)
		{
			SubFeature subFeature;
			if ((subFeature = Features[num3] as SubFeature) != null && subFeature.Level == 3)
			{
				_entryPoints |= subFeature.GetEntryPoints();
			}
		}
		if (!IsMock && DevCompany.IsLocalPlayer)
		{
			GameSettings.Instance.RegisterStat("ProductsReleased", 1f);
			if (!AchievementController.HasAchievement("DEDICATION"))
			{
				int num4 = 1;
				for (SoftwareProduct sequelTo2 = SequelTo; sequelTo2 != null; sequelTo2 = sequelTo2.SequelTo)
				{
					if (!sequelTo2.OriginalOwner)
					{
						num4 = 0;
						break;
					}
					num4++;
					if (num4 >= 10)
					{
						break;
					}
				}
				if (num4 >= 10)
				{
					AchievementController.SetAchievement("DEDICATION");
				}
			}
		}
		_entryPoints &= ScriptSystem.EntryPoint.ValidForProduct;
		if (Category.Hardware)
		{
			Category.Manufacturing.GetProcessInfo(Features, null, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
			HardwareDesign = hardwareDesign ?? HardwareDesignInstance.GenerateRandomDesign(Category.Manufacturing, SequelTo, this, null, Features, null);
		}
		CalculateBigProjectFactor();
	}

	public void RunReleaseScripts()
	{
		if (!IsMock)
		{
			RunScripts(ScriptSystem.EntryPoint.OnRelease, ScriptSystem.ProductScope.GetTempScope(this, Release), true);
		}
	}

	public static void HandleNews(SoftwareProduct p, bool manualRelease)
	{
		if (!p.InHouse && !p.IsMock && p.DevCompany.IsLocalPlayer)
		{
			NetworkMessaging.SendGenerateProductReview(p.ID, 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
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

	public float GetPrintPrice(bool isAI = false)
	{
		if (!Category.Hardware)
		{
			return MarketSimulation.PhysicalCopyPrice;
		}
		return _hardwarePrice * (isAI ? 1.2f : MarketSimulation.HardwareCopyPriceFactor);
	}

	public int GetLastPhysicalSales()
	{
		return LastMonthPhysical;
	}

	public uint GetTotalPhysicalSales()
	{
		if (TotalPhysical == 0 && !SubscriptionBased && _unitOfflineSales != null)
		{
			for (int i = 0; i < _unitOfflineSales.Count; i++)
			{
				TotalPhysical += (uint)_unitOfflineSales[i];
			}
		}
		return TotalPhysical;
	}

	public int GetSalesMonths()
	{
		return GetUnitSales(false).Count;
	}

	public int GetLastMissedPhysicalSales()
	{
		return MissedPhysicalSales;
	}

	public uint GetReach()
	{
		return Type.GetReach(Category, GetOSs());
	}

	public float GetRealQuality()
	{
		return (float)RealQuality;
	}

	public uint GetFollowers()
	{
		return Followers;
	}

	public double CalculateRelevancy(bool includeSubmarketScore = true)
	{
		return SoftwareType.CalculateRelevancy(Features, TechLevels, SWCat, includeSubmarketScore ? Submarkets : null);
	}

	public void RunScripts(ScriptSystem.EntryPoint point, ScriptSystem.DefaultScope scope, bool force = false)
	{
		if (!DevCompany.Player || (!force && (_entryPoints & point) <= ScriptSystem.EntryPoint.None))
		{
			return;
		}
		for (int i = 0; i < Features.Length; i++)
		{
			SubFeature subFeature = Features[i] as SubFeature;
			if (subFeature != null && subFeature.Level == 3)
			{
				subFeature.RunScript(point, scope, this);
			}
		}
	}

	public void RegisterOSSupport(SDateTime time)
	{
		if ("Operating System".Equals(Type.Name))
		{
			GameSettings.Instance.simulation.AddMissingOSSupport(this, time);
		}
		else if (Type.OSSpecific && !DevCompany.Player)
		{
			GameSettings.Instance.simulation.RegisterOSSupport(this);
		}
	}

	public static double CalculateSequelBonus(SoftwareProduct sequelTo, double perceivedValue, double quality, double[] subMarket, bool subscriptionBased, SDateTime time)
	{
		if (sequelTo == null)
		{
			return 1.0;
		}
		double num = 1.0;
		SoftwareProduct softwareProduct = sequelTo;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = 0;
		while (softwareProduct != null && num5 < 3)
		{
			if (!softwareProduct.InHouse)
			{
				double num6 = softwareProduct.GetMarketWeightedQuality(softwareProduct.Quality) * softwareProduct.CreativityScore;
				if (Math.Abs(num6 - quality) < 0.05000000074505806)
				{
					num6 = quality;
				}
				float num7 = Math.Min(1f, (float)softwareProduct.UnitSum / 50000f);
				num6 = Utilities.Lerp(quality, num6, num7, true);
				num3 += num6 * (double)(3 - num5);
				num4 += softwareProduct.PerceivedValue(time) * (double)(3 - num5);
				num2 += (double)(3 - num5);
			}
			softwareProduct = softwareProduct.SequelTo;
			num5++;
		}
		if (num2 > 0.0)
		{
			double num8 = num3 / num2;
			num = ((quality / num8 - 1.0) * num8 + 1.0).Clamp(0.0, 2.0);
			double num9 = num4 / num2;
			if (num9 > perceivedValue)
			{
				num *= perceivedValue / num9;
			}
			if (num < 1.0)
			{
				num = Utilities.Lerp(num, 1.0, quality, true);
			}
		}
		if (subscriptionBased && !sequelTo.SubscriptionBased)
		{
			num *= 0.75;
		}
		return num * subMarket.SubmarketDistance(sequelTo.Submarkets);
	}

	public void GetRoyalties(List<KeyValuePair<uint, TechLevel>> result)
	{
		result.Clear();
		if (DevCompany == null || TechLevels == null || TechLevels.Count == 0)
		{
			return;
		}
		foreach (TechLevel value in TechLevels.Values)
		{
			if (value != null && value.HasToPay(DevCompany))
			{
				result.Add(new KeyValuePair<uint, TechLevel>(value.PatentOwner, value));
			}
		}
	}

	public void RegisterServer()
	{
		if (!ExternalHostingActive && DevCompany.ID == InventorID && ServerReq > 0f && DevCompany.IsLocalPlayer && !DropHosting() && Type != MarketSimulation.Active.DigitalDistSoft)
		{
			GameSettings.Instance.RegisterWithServer(Server, this);
		}
	}

	public void CancelHostingServices()
	{
		if (ExternalHosting != 0 && HUD.Instance.dealWindow.AllDeals.ContainsKey(ExternalHosting))
		{
			HUD.Instance.dealWindow.CancelDeal(HUD.Instance.dealWindow.AllDeals[ExternalHosting]);
		}
	}

	public void AddMarketEvent(MarketEvent ev, bool networked)
	{
		if (networked)
		{
			NetworkMessaging.SendMarketEventData(ev, 2, ID, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else
		{
			MarketEvents.Add(ev);
		}
	}

	public void Trade(Company company, SDateTime time)
	{
		if (company != DevCompany)
		{
			if (NetworkManager.IsConnected && SequelTo == null)
			{
				NetworkManager.Instance.TradeController.CancelAllTradesFor(this);
			}
			NetworkMessaging.SendTradeIP((company != null) ? company.ID : 0u, ID, 0u, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			ActuallyTrade(company, time);
		}
	}

	public void ActuallyTrade(Company company, SDateTime time)
	{
		CancelHostingServices();
		AddMarketEvent(new MarketEvent(MarketEvent.EventType.ProductTrade, time, company.Name, company.ID), false);
		HUD.Instance.dealWindow.CancelBids(this);
		if (inventor == null)
		{
			inventor = DevCompany.Name;
		}
		if (ExclusiveStore != null && (ExclusiveStore.Owner == DevCompany || ExclusiveStore.Owner == DevCompany.OwnerCompany) && company != ExclusiveStore.Owner && company.OwnerCompany != DevCompany)
		{
			ExclusiveStore = null;
		}
		GameSettings.Instance.CancelPrintOrder(this, false);
		GameSettings.Instance.MyCompany.CancelAllWorkFor(this);
		DevCompany.Products.Remove(this);
		company.RemoveLicense(this, null, true);
		if (DevCompany.IsLocalPlayer)
		{
			HUD.Instance.ApplyProductWindowFilters();
			foreach (AutoDevWorkItem item in DevCompany.WorkItems.OfType<AutoDevWorkItem>())
			{
				item.PreviousSoftware.Remove(this);
				item.PastReleases.Remove(this);
			}
		}
		DevCompany = company;
		DevCompany.Products.Add(this);
		GameSettings.Instance.DeregisterServerItem(this);
		RegisterServer();
		LoadIncidents = 0;
		LossBreakdown = null;
		if (Publishing != null)
		{
			Publishing.Abandon(false);
		}
		if (DevCompany.IsLocalPlayer)
		{
			HUD.Instance.ApplyProductWindowFilters();
		}
		if (company == MarketSimulation.Active.PublicDomain)
		{
			LowestPrice = 0f;
			PriceChangeFact = 1f;
			Price = 0f;
			_cachedWeightedMarketQualityDate = new SDateTime(0);
		}
		NetworkMeta.CheckDirty();
	}

	public double RelativeFeatureScore(MarketSimulation sim, SDateTime time)
	{
		double featureScore = sim.GetFeatureScore(this, time);
		if (featureScore != 0.0)
		{
			return PerceivedValue(time) / featureScore;
		}
		return 1.0;
	}

	public void SimulateAwareness(bool fromNetwork = false)
	{
		if (!fromNetwork && (_awareness > 0f || Marketing > 0f))
		{
			NetworkMessaging.SendUpdateMarketing(ID, 0u, Marketing, true, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_awareness = Mathf.Max(0f, _awareness * (1f - Mathf.Lerp(0.15f, 0.1f, CreativityAwarenessFactor.Evaluate((float)CreativityScore)) / (float)GameSettings.DaysPerMonth) + Marketing);
		Marketing = 0f;
		_cachedWeightedMarketQualityDate = new SDateTime(0);
	}

	public void KillAwareness(bool fromNetwork = false)
	{
		if (!fromNetwork && (_awareness > 0f || Marketing > 0f))
		{
			NetworkMessaging.SendUpdateMarketing(ID, 0u, 0f, true, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_awareness = 0f;
		Marketing = 0f;
		_cachedWeightedMarketQualityDate = new SDateTime(0);
	}

	public static double QualityForgiveness(double val)
	{
		if (val <= 0.0)
		{
			return 0.0;
		}
		if (val >= 1.0)
		{
			return 1.0;
		}
		return Utilities.Clamp01(Math.Pow(val, 1.75) * (3.0 - 2.0 * val));
	}

	public void GetPriceAdjustedQuality(double[] output, SDateTime time)
	{
		float num = ((Price >= 1f) ? (MarketSimulation.PriceFact(Price, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(Category, SubscriptionBased) * PerceivedValue(time))) * PriceChangeFact) : 1f);
		for (int i = 0; i < 3; i++)
		{
			output[i] = QualityForgiveness(Quality[i] * AddonQualityEffect) * (double)num;
		}
	}

	public static double GetCreativityFactor(double score, bool player)
	{
		int num = (int)DifficultyValues.Difficulty.CreativityFactor;
		if (num < 0)
		{
			return 1.0;
		}
		return player ? _creativityFactors[Mathf.Clamp(num, 0, _creativityFactors.Length - 1)].Evaluate((float)score) : _creativityFactors[2].Evaluate((float)score);
	}

	public float GetRep()
	{
		if (Publishing == null)
		{
			return DevCompany.GetReputation(Category);
		}
		return Category.RepCut(DevCompany, Publishing.Publisher);
	}

	public double[] GetWeightedQualityAddition(SDateTime time)
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
		float num = RandomPoint().WeightOne(0.1f);
		float num2 = GetRep() * (DevCompany.Player ? 0.01f : 0.04f);
		if (Category.Hardware)
		{
			num2 *= 2f;
		}
		double num3 = (DevCompany.Player ? ((double)DifficultyValues.Difficulty.ProductReputationFactor) : 0.002);
		double num4 = RelativeFeatureScore(GameSettings.Instance.simulation, time).InOutCurve().WeightOne(0.20000000298023224);
		double num5 = Math.Sqrt(GetAwareness());
		double num6 = (double)(Math.Max(0f, Userbase - RefundSum) / (float)MarketSimulation.Population) * 0.01;
		double num7 = (double)num * ((double)num2 + num3) * num4 * (num5 + num6) * time2;
		double[] cachedWeightedMarketQuality = _cachedWeightedMarketQuality;
		lock (_priceCache)
		{
			GetPriceAdjustedQuality(_priceCache, time);
			for (int i = 0; i < 3; i++)
			{
				_priceCache[i] *= num7 * SequelBonus;
			}
			Category.GetFinalScoreFromSummary(_featureScoreSummation, TechLevels, _priceCache, Submarkets, cachedWeightedMarketQuality);
		}
		time2 *= GetCreativityFactor(CreativityScore, DevCompany.Player) * GetBigProjectFactor();
		for (int j = 0; j < cachedWeightedMarketQuality.Length; j++)
		{
			cachedWeightedMarketQuality[j] *= time2;
		}
		_cachedWeightedMarketQualityDate = time;
		return cachedWeightedMarketQuality;
	}

	public double GetFinalScoreFromSummaryAverage()
	{
		double[] array = new double[3];
		Category.GetFinalScoreFromSummary(_featureScoreSummation, TechLevels, _priceCache, Submarkets, array);
		return (array[0] + array[1] + array[2]) / 3.0;
	}

	public double[] GetQuality(double[] max, SDateTime time)
	{
		double[] weightedQualityAddition = GetWeightedQualityAddition(time);
		return new double[3]
		{
			(max[0] == 0.0) ? 1.0 : Math.Min(1.0, weightedQualityAddition[0] / max[0]),
			(max[1] == 0.0) ? 1.0 : Math.Min(1.0, weightedQualityAddition[1] / max[1]),
			(max[2] == 0.0) ? 1.0 : Math.Min(1.0, weightedQualityAddition[2] / max[2])
		};
	}

	public double GetMarketWeightedQuality(double[] quality)
	{
		return quality[0] * Submarkets[0] + quality[1] * Submarkets[1] + quality[2] * Submarkets[2];
	}

	public double[] GetQuality(SDateTime time)
	{
		double[] quality = GameSettings.Instance.simulation.GetQuality(this, time);
		return GetQuality(quality, time);
	}

	public bool ChangePrice(float newPrice)
	{
		NetworkMessaging.SendChangePrice(ID, 0u, newPrice, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		return ActuallyChangePrice(newPrice);
	}

	public bool ActuallyChangePrice(float newPrice)
	{
		if (float.IsNaN(newPrice) || float.IsInfinity(newPrice) || newPrice < 1f || Price < 1f)
		{
			return false;
		}
		MarketEvent ev = new MarketEvent(MarketEvent.EventType.PriceChange, SDateTime.Now(), newPrice);
		if (MarketEvents.Count > 0 && MarketEvents[MarketEvents.Count - 1].Type == MarketEvent.EventType.PriceChange && MarketEvents[MarketEvents.Count - 1].DateInt == ev.DateInt)
		{
			MarketEvents.RemoveAt(MarketEvents.Count - 1);
		}
		AddMarketEvent(ev, false);
		LowestPrice = Mathf.Min(LowestPrice, newPrice);
		PriceChangeFact = Mathf.Pow(LowestPrice / newPrice, newPrice / OriginalPrice * 3f);
		Price = newPrice;
		_cachedWeightedMarketQualityDate = new SDateTime(0);
		NetworkMeta.CheckDirty();
		return true;
	}

	public void Update(int bugsFixed, int bugsAdded, Dictionary<string, TechLevel> techs, SDateTime time)
	{
		if ((techs == null || techs.Count == 0) && bugsFixed == 0 && bugsAdded == 0)
		{
			return;
		}
		if (NetworkManager.IsConnected && techs != null && techs.Count > 0)
		{
			NetworkMessaging.SendUpdateProduct(ID, techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.Year), time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyUpdate(bugsFixed, bugsAdded, techs, time);
	}

	public void ActuallyUpdate(int bugsFixed, int bugsAdded, Dictionary<string, TechLevel> techs, SDateTime time)
	{
		if (bugsAdded > 0 || bugsFixed > 0)
		{
			ChangeBugs(StartBugss + bugsAdded, Mathf.Max(0, Bugss + bugsAdded - bugsFixed));
		}
		string[] array = null;
		if (techs != null && techs.Count > 0)
		{
			array = new string[techs.Count + 1];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < Features.Length; i++)
			{
				FeatureBase featureBase = Features[i];
				TechLevel orNull = techs.GetOrNull(featureBase.Spec);
				num2 += featureBase.DevTime;
				if (orNull != null)
				{
					num += featureBase.DevTime * orNull.GetRelevancy(Category);
				}
			}
			LastUpdated = Release + SDateTime.GetMonths(Release, time) * (num / num2);
			int num3 = 1;
			foreach (KeyValuePair<string, TechLevel> tech in techs)
			{
				TechLevels[tech.Key] = tech.Value;
				array[num3] = tech.Key;
				num3++;
			}
			ReleaseRelevancy = Math.Max(ReleaseRelevancy, CalculateRelevancy());
			VMinor++;
			VRev = 0;
			MarketSimulation.Active.ProductUpdated(this);
			DevCompany.ReleaseNow(Category, time);
			_cachedPerceivedTime = new SDateTime(0);
		}
		else
		{
			array = new string[1];
			VRev++;
		}
		array[0] = Version;
		AddMarketEvent(new MarketEvent(MarketEvent.EventType.Update, time, array, (bugsFixed <= 0) ? null : new uint[1] { (uint)bugsFixed }), false);
		_cachedWeightedMarketQualityDate = new SDateTime(0);
		NetworkMeta.CheckDirty();
	}

	public void FixBugs(int fixes)
	{
		if (fixes > 0)
		{
			ChangeBugs(StartBugss, Mathf.Max(Bugss - fixes, 0));
		}
	}

	public void AddBugs(int bugs)
	{
		if (bugs > 0)
		{
			ChangeBugs(StartBugss + bugs, Bugss + bugs);
		}
	}

	public void ChangeBugs(int startbugs, int bugs)
	{
		NetworkMessaging.SendChangeBugs(ID, startbugs, bugs, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		ActuallyChangeBugs(startbugs, bugs);
	}

	public void ActuallyChangeBugs(int startbugs, int bugs)
	{
		_startBugs = startbugs;
		_bugs = bugs;
		int num = StartBugss - Bugss;
		if (num > VerifiedBugs)
		{
			VerifiedBugs = num;
		}
		NetworkMeta.CheckDirty();
	}

	public double GetTime(SDateTime time, float dieValue = 0.05f)
	{
		float num = Mathf.Max(0f, SDateTime.GetMonths(Release, time));
		if (LastUpdated.HasValue)
		{
			num = Mathf.Lerp(num, Mathf.Max(0f, SDateTime.GetMonths(LastUpdated.Value, time)), 0.5f);
		}
		double num2 = Utilities.Lerp((double)Math.Min(1f, DevTime / Type.GetOptimalDevTime(Category)) * ReleaseRelevancy, 1.0, GetMarketWeightedQuality(Quality), true) * (double)Category.Retention;
		return Math.Pow(Math.Pow(10.0, Math.Log10(dieValue) / num2), num);
	}

	public float GetDevFalloff(SDateTime time, float devTime, float dieValue = 0.15f)
	{
		float p = Mathf.Max(0f, SDateTime.GetMonths(Release, time));
		float num = devTime * Mathf.Pow(0.99f, devTime);
		return Mathf.Pow(Mathf.Pow(10f, Mathf.Log10(dieValue) / num), p);
	}

	public float RandomPoint()
	{
		return RandomFactor.WeightOne(Type.RandomFactor);
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
		return !InHouse;
	}

	public override string ToString()
	{
		return Name;
	}

	public void OnDoubleClick()
	{
		HUD.Instance.GetProductWindow(null).ShowProductDetails(this);
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
		if (r > 0f)
		{
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
		if (!AchievementController.HasAchievement("PROPERCOOP") && (DevCompany.IsLocalPlayer || _workRoyalties.Any((KeyValuePair<Company, float> x) => x.Key.IsLocalPlayer)))
		{
			float num2 = 1f / (float)(1 + _workRoyalties.Count);
			float num3 = ((!DevCompany.IsLocalPlayer) ? _workRoyalties.First((KeyValuePair<Company, float> x) => x.Key.IsLocalPlayer).Value : (1f - _workRoyalties.SumSafe((KeyValuePair<Company, float> x) => x.Value)));
			if (Mathf.Abs(1f - num3 / num2) <= 0.5f)
			{
				AchievementController.SetAchievement("PROPERCOOP");
			}
		}
	}

	public SoftwareProduct FixSubReferences()
	{
		string name = Type.Name;
		if (!MarketSimulation.Active.SoftwareTypes.TryGetValue(name, out Type))
		{
			Debug.Log("Got invalid software type when fixing sub references: " + Name + " - " + name);
			return null;
		}
		name = Category.Name;
		if (!Type.Categories.TryGetValue(name, out Category))
		{
			Debug.Log("Got invalid software category when fixing sub references: " + Name + " - " + Type.Name + " " + name);
			return null;
		}
		InitOS();
		List<uint> list = new List<uint>();
		foreach (uint item in _oss)
		{
			if (MarketSimulation.Active.GetProduct(item, true, true, true) != null)
			{
				list.Add(item);
			}
		}
		_oss = list;
		SoftwareProduct sequelTo = SequelTo;
		SequelTo = (SoftwareProduct)((sequelTo != null) ? sequelTo.FixReferences() : null);
		SoftwareProduct sequel = Sequel;
		Sequel = (SoftwareProduct)((sequel != null) ? sequel.FixReferences() : null);
		SoftwareFramework framework = Framework;
		Framework = (SoftwareFramework)((framework != null) ? framework.FixReferences() : null);
		Features = Features.SelectNotNull((FeatureBase x) => Type.Features.GetOrNull(x.Name)).ToArray();
		DevCompany = MarketSimulation.Active.GetCompany(DevCompany.ID);
		PublisherDeal publishing = Publishing;
		Publishing = ((publishing != null) ? publishing.FixReferences() : null) as PublisherDeal;
		InitTools();
		Dictionary<uint, float> dictionary = new Dictionary<uint, float>();
		foreach (KeyValuePair<uint, float> tool in _tools)
		{
			if (MarketSimulation.Active.GetProduct(tool.Key, true, true, true) != null)
			{
				dictionary[tool.Key] = tool.Value;
			}
		}
		_tools = dictionary;
		return this;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.GetProduct(ID, true, true, true);
	}

	public string GetActualString()
	{
		return Name;
	}

	public float GetLoadRequirement()
	{
		return ServerReq * (float)Userbase;
	}

	private bool DropHosting()
	{
		if (SDateTime.GetMonths(Release, SDateTime.Now()) > 6f)
		{
			return GetLoadRequirement().BandwidthFactor(SDateTime.Now()) < 1f;
		}
		return false;
	}

	public void ChangeUserbase(int newValue)
	{
		Userbase = newValue;
		NetworkMessaging.SendProductUserbase(ID, Userbase, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public void HandleLoad(float load)
	{
		if (DropHosting())
		{
			if (ExternalHostingActive)
			{
				CancelHostingServices();
			}
			else
			{
				GameSettings.Instance.DeregisterServerItem(this);
			}
		}
		else if (GetLoadRequirement() < 0.001f)
		{
			if (LoadIncidents > 0)
			{
				if (NetworkManager.IsClient)
				{
					NetworkMessaging.SendAddProductLoadIncident(ID, false, NetworkMessaging.MessageTarget.Host, 0);
				}
				LoadIncidents--;
			}
		}
		else if (load < 0.75f)
		{
			load /= 0.75f;
			float num = (1f - load) * Mathf.Min(0.9f, 0.05f * Mathf.Pow(1.25f, LoadIncidents));
			LoadIncidents++;
			MaxLoadIncidents = Mathf.Max(LoadIncidents, MaxLoadIncidents);
			if (NetworkManager.IsClient)
			{
				NetworkMessaging.SendAddProductLoadIncident(ID, true, NetworkMessaging.MessageTarget.Host, 0);
			}
			if (!ExternalHostingActive)
			{
				float num2 = (1f - load) * 0.25f;
				DevCompany.AddFans(-Mathf.CeilToInt(num2 * (float)Userbase), Category);
			}
			num = 1f - num;
			Userbase = Mathf.FloorToInt((float)Userbase * num);
			NetworkMessaging.SendProductUserbase(ID, Userbase, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			_awareness *= num;
			NetworkMessaging.SendUpdateMarketing(ID, 0u, _awareness, false, true, NetworkMessaging.MessageTarget.Everyone, 0);
			if (DevCompany.IsLocalPlayer && !NotificationManager.CheckAggregate<ServerIssueNotification>(Server))
			{
				NotificationManager.AddNotification(new ServerIssueNotification(Server));
			}
		}
		else if (LoadIncidents > 0)
		{
			if (NetworkManager.IsClient)
			{
				NetworkMessaging.SendAddProductLoadIncident(ID, false, NetworkMessaging.MessageTarget.Host, 0);
			}
			LoadIncidents--;
		}
	}

	public string GetDescription()
	{
		return Name;
	}

	public void SerializeServer(string name)
	{
		Server = name;
	}

	public bool CancelOnUnload()
	{
		return false;
	}

	public float GetLastMonthIncome()
	{
		List<float> cashflow = GetCashflow(false);
		if (cashflow.Count <= 0)
		{
			return 0f;
		}
		return cashflow[cashflow.Count - 1];
	}

	public float GetLastDayIncome(bool gross)
	{
		if (!gross)
		{
			return LastDayGross - LastDayLoss;
		}
		return LastDayGross;
	}

	public float GetAwareness()
	{
		return Mathf.Clamp01(_awareness / GameSettings.Instance.simulation.GetMaxAwareness(this));
	}

	public void SetAwareness(float value, bool fromNetwork)
	{
		_cachedWeightedMarketQualityDate = new SDateTime(0);
		_awareness = value;
		if (!fromNetwork)
		{
			NetworkMessaging.SendUpdateMarketing(ID, 0u, _awareness, false, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public float GetRealAwareness()
	{
		return _awareness;
	}

	public SoftwareProduct GetLatestSuccessor()
	{
		SoftwareProduct softwareProduct = this;
		while (softwareProduct.Sequel != null)
		{
			softwareProduct = softwareProduct.Sequel;
		}
		return softwareProduct;
	}

	public string GetName()
	{
		return Name;
	}

	public string GetTypeName()
	{
		return Category.GetActualString();
	}

	public SDateTime GetReleaseDate()
	{
		return Release;
	}

	public IList<FeatureBase> GetFeatures()
	{
		return Features;
	}

	public string GetIdentifyingName()
	{
		return Name;
	}

	public void AddLoss(float cost, bool fromNetwork = false)
	{
		AddLoss(cost, LossType.Other, false, fromNetwork);
	}

	public void AddLoss(float cost, LossType type, bool immediate, bool fromNetwork = false)
	{
		lock (this)
		{
			if (!fromNetwork && cost != 0f)
			{
				if (immediate)
				{
					NetworkMessaging.SendAddLoss(ID, cost, type, 0u, 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				else
				{
					NetworkManager.AddDirtyLoss(this, type, cost);
				}
			}
			if (!Archived && DevCompany.IsLocalPlayer && !Traded)
			{
				if (LossBreakdown == null || LossBreakdown.Length != 15)
				{
					LossBreakdown = LossBreakdown.Resize(15);
				}
				LossBreakdown[(int)type] += cost;
			}
			if (type != LossType.Publisher)
			{
				if (immediate)
				{
					Loss += cost;
				}
				else
				{
					_activeLoss += cost;
				}
			}
		}
	}

	public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
		if (!fromNetwork && cost != 0f)
		{
			NetworkMessaging.SendAddLoss(ID, cost, LossType.Other, 0u, tool.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		AddTool(tool, cost);
	}

	public float GetLicenseAmount()
	{
		return 1f;
	}

	public void TurnLoss()
	{
		Loss += _activeLoss;
		_activeLoss = 0f;
	}

	public string GetCompanyName()
	{
		return DevCompany.Name;
	}

	public bool CompatibleWith(ComponentProcess process)
	{
		if (process.Parent.Type == Type)
		{
			return process.Parent.Category == Category;
		}
		return false;
	}

	public bool OSOverlap(SoftwareProduct other)
	{
		if (OSCount > 0 && other.OSCount > 0)
		{
			for (int i = 0; i < _oss.Count; i++)
			{
				uint num = _oss[i];
				for (int j = 0; j < other._oss.Count; j++)
				{
					if (num == other._oss[j])
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public double PerceivedValue(SDateTime time, bool withTech = true)
	{
		if (!withTech)
		{
			return Category.PerceivedValue(Features, null);
		}
		if (!time.Equals(_cachedPerceivedTime, true))
		{
			_cachedPerceivedValue = Category.PerceivedValue(Features, TechLevels);
			_cachedPerceivedTime = time;
		}
		return _cachedPerceivedValue;
	}

	public float GetReviewTargetScore(SDateTime time, bool withTech = true)
	{
		double marketWeightedQuality = GetMarketWeightedQuality(Quality);
		double num = PerceivedValue(time, false);
		double num2 = (withTech ? PerceivedValue(time) : num);
		double number = num2 / num;
		float num3 = (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(Category, SubscriptionBased) * num2);
		float number2 = Mathf.Clamp01((Price <= num3) ? PriceChangeFact : (MarketSimulation.PriceFact(Price, num3) * PriceChangeFact));
		float number3 = 1f - Mathf.Clamp01((float)_bugs / (float)SoftwareWorkItem.GetMaximumBugs(DevTime));
		return Mathf.Clamp01((float)(marketWeightedQuality * CreativityScore.WeightOne(0.800000011920929) * number.WeightOne(0.75) * num.WeightOne(0.10000000149011612) * (double)number2.WeightOne(0.5f) * (double)Mathf.Clamp01((float)SequelBonus).WeightOne(0.5f) * (double)number3.WeightOne(0.75f)));
	}

	public bool HasToPay(Company c)
	{
		if (DevCompany == MarketSimulation.Active.PublicDomain)
		{
			return false;
		}
		if (c == DevCompany)
		{
			return false;
		}
		if (c.OwnerCompany == DevCompany)
		{
			return false;
		}
		if (c.Subsidiaries.Contains(DevCompany.ID))
		{
			return false;
		}
		for (int i = 0; i < c.NewOwnedStock.Count; i++)
		{
			if (c.NewOwnedStock[i].Seller == DevCompany && c.NewOwnedStock[i].Percentage >= 0.25)
			{
				return false;
			}
		}
		return true;
	}

	public bool FairPrice(SDateTime time)
	{
		return (double)(Price / MarketSimulation.Active.GetIdealMarketPrice(Category, SubscriptionBased)) * PerceivedValue(time) < 2.0;
	}

	public double SimulateAddonSales(SDateTime time, double timeFactor, double pvsd, List<KeyValuePair<uint, TechLevel>> patentRoyalties, float saleServerReq, ref uint totalDigitalSales)
	{
		AddonProfit = 0f;
		if (Addons.Count > 0)
		{
			double num = 0.0;
			double time2 = GetTime(time - 12, 0.1f);
			{
				foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in Addons)
				{
					for (int i = 0; i < addon.Value.Count; i++)
					{
						addon.Value[i].SimulateAwareness();
					}
					if (addon.Key.Hardware)
					{
						double[] array = new double[3];
						for (int j = 0; j < addon.Value.Count; j++)
						{
							double[] weightedQualityAddition = addon.Value[j].GetWeightedQualityAddition(time, true);
							for (int k = 0; k < 3; k++)
							{
								array[k] += weightedQualityAddition[k];
							}
						}
						for (int l = 0; l < addon.Value.Count; l++)
						{
							AddOnProduct addOnProduct = addon.Value[l];
							double[] weightedQualityAddition2 = addOnProduct.GetWeightedQualityAddition(time, true);
							for (int m = 0; m < 3; m++)
							{
								weightedQualityAddition2[m] += ((array[m] > 0.0) ? Math.Min(1.0, weightedQualityAddition2[m] / array[m]) : 0.0);
							}
							addOnProduct.SimulateSales(weightedQualityAddition2, time, timeFactor, pvsd, patentRoyalties, time2, saleServerReq, ref totalDigitalSales);
							if (addOnProduct.Owner == DevCompany)
							{
								AddonProfit += (float)(addOnProduct.Gross - addOnProduct.Loss);
							}
							if (addOnProduct.LastMonthIncome != 0f)
							{
								ChangeLastSale(time, true);
							}
						}
						continue;
					}
					for (int n = 0; n < addon.Value.Count; n++)
					{
						AddOnProduct addOnProduct2 = addon.Value[n];
						double[] weightedQualityAddition3 = addOnProduct2.GetWeightedQualityAddition(time, false);
						num = Math.Max(num, addOnProduct2.SimulateSales(weightedQualityAddition3, time, timeFactor, pvsd, patentRoyalties, time2, saleServerReq, ref totalDigitalSales));
						if (addOnProduct2.LastMonthIncome != 0f)
						{
							ChangeLastSale(time, true);
						}
						AddonProfit += (float)(addOnProduct2.Gross - addOnProduct2.Loss);
					}
				}
				return num;
			}
		}
		return 0.0;
	}

	public void ChangeAllPhysicalStock(int change)
	{
		PhysicalCopies = PhysicalCopies.AddIntClamped(change);
		if (ForcedAddons == null)
		{
			return;
		}
		for (int i = 0; i < ForcedAddons.Length; i++)
		{
			AddOnProduct addOnProduct = ForcedAddons[i];
			addOnProduct.PhysicalCopies = addOnProduct.PhysicalCopies.AddIntClamped(change);
			if (change < 0)
			{
				addOnProduct.TransferDistributionCost(-change);
			}
		}
	}

	public uint GetMaxPhysicalCopies(out IStockable limiter)
	{
		uint physicalCopies = PhysicalCopies;
		limiter = this;
		if (ForcedAddons != null)
		{
			for (int i = 0; i < ForcedAddons.Length; i++)
			{
				AddOnProduct addOnProduct = ForcedAddons[i];
				if (addOnProduct.PhysicalCopies < physicalCopies)
				{
					limiter = addOnProduct;
					physicalCopies = addOnProduct.PhysicalCopies;
				}
			}
		}
		return physicalCopies;
	}

	public IEnumerable<AddOnProduct> GetAllAddons()
	{
		foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in Addons)
		{
			foreach (AddOnProduct item in addon.Value)
			{
				yield return item;
			}
		}
	}

	public IList<uint> GetFeaturesFactors()
	{
		return null;
	}

	public IProductOrder PromoteHardware(uint copies)
	{
		return ManufactureOrder.PromoteProduct(this, copies);
	}

	public double GetRefundRate()
	{
		return Math.Min(1.0, MaxLoadIncidents.MapRange(0.0, 24.0, 0.0, 0.5, true) + Math.Pow(Math.Min(0.75, (double)Bugss / (double)SoftwareWorkItem.GetMaximumBugs(DevTime)), 2.0));
	}

	public uint GetNextAddonID()
	{
		uint addonID = _addonID;
		_addonID++;
		NetworkMeta.CheckDirty();
		return addonID;
	}

	public void ResetAddonID()
	{
		_addonID = 1u;
		foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in Addons)
		{
			foreach (AddOnProduct item in addon.Value)
			{
				if (item.ID > _addonID)
				{
					_addonID = item.ID;
				}
			}
		}
		_addonID++;
		NetworkMeta.CheckDirty();
	}

	public void SetAddonID(uint value)
	{
		_addonID = value;
		NetworkMeta.CheckDirty();
	}

	public AddOnProduct GetAddon(uint id)
	{
		foreach (List<AddOnProduct> value in Addons.Values)
		{
			AddOnProduct addOnProduct = value.FirstOrDefault((AddOnProduct x) => x.ID == id);
			if (addOnProduct != null)
			{
				return addOnProduct;
			}
		}
		return null;
	}
}
