using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using StatementParser;
using UnityEngine;

[AltDeprecate("DistributionDeal", typeof(float?))]
[AltDeprecate("LastDistributionDeal", typeof(float?))]
[AltDeprecate("LastDistributionOffer", typeof(SDateTime))]
[AltDeprecate("HasDistributionDeal", typeof(bool))]
[AltDeprecate("ActiveDistributionDeal", typeof(bool))]
[AltDeprecate("_fans", typeof(uint))]
[AltDeprecate("LicenseIncome", typeof(float))]
public class Company : IFormatColorObject
{
	[Serializable]
	public class RepEffectItem
	{
		public float Positive;

		public float Negative;

		public SDateTime PositiveLast;

		public SDateTime NegativeLast;

		public RepEffectItem()
		{
		}

		public RepEffectItem(float value)
		{
			if (value > 0f)
			{
				Positive = value;
			}
			else
			{
				Negative = 0f - value;
			}
			NegativeLast = (PositiveLast = SDateTime.Now());
		}

		public float GetValue(bool positive)
		{
			if (positive)
			{
				float num = 1f - Mathf.Clamp01(SDateTime.GetHours(PositiveLast, SDateTime.Now()) / 24f);
				return Positive * num;
			}
			float num2 = 1f - Mathf.Clamp01(SDateTime.GetHours(NegativeLast, SDateTime.Now()) / 24f);
			return Negative * num2;
		}

		public bool IsRelevant()
		{
			if (Positive <= 0f && Negative <= 0f)
			{
				return false;
			}
			float hours = SDateTime.GetHours(PositiveLast, SDateTime.Now());
			float hours2 = SDateTime.GetHours(NegativeLast, SDateTime.Now());
			if (hours > 24f && hours2 > 24f)
			{
				return false;
			}
			return true;
		}

		public void ChangeValue(float value)
		{
			if (value > 0f)
			{
				ChangePositive(value);
			}
			else
			{
				ChangeNegative(0f - value);
			}
		}

		public void ChangePositive(float newValue)
		{
			SDateTime sDateTime = SDateTime.Now();
			float num = 1f - Mathf.Clamp01(SDateTime.GetHours(PositiveLast, sDateTime) / 24f);
			Positive = Positive * num + newValue;
			PositiveLast = sDateTime;
		}

		public void ChangeNegative(float newValue)
		{
			SDateTime sDateTime = SDateTime.Now();
			float num = 1f - Mathf.Clamp01(SDateTime.GetHours(NegativeLast, sDateTime) / 24f);
			Negative = Negative * num + newValue;
			NegativeLast = sDateTime;
		}
	}

	public enum TransactionCategory
	{
		Salaries = 0,
		Contracts = 1,
		Sales = 2,
		Bills = 3,
		Hire = 4,
		Construction = 5,
		Repairs = 6,
		Marketing = 7,
		Licenses = 8,
		Staff = 9,
		Stocks = 10,
		Education = 11,
		Loan = 12,
		Interest = 13,
		Distribution = 14,
		Deals = 15,
		Royalties = 16,
		Dividends = 17,
		NA = 18,
		Benefits = 19,
		Intercompany = 20,
		Legal = 21
	}

	public class TakeOverData : IByteData
	{
		public byte Target;

		public int Stocks;

		public List<SoftwareProduct> Products = new List<SoftwareProduct>();

		public int Patents;

		public List<SoftwareFramework> Frameworks = new List<SoftwareFramework>();

		public List<AddOnProduct> Addons = new List<AddOnProduct>();

		public bool Bankrupt;

		public void Clear()
		{
			Stocks = 0;
			Products.Clear();
			Patents = 0;
			Frameworks.Clear();
			Addons.Clear();
			Bankrupt = false;
		}

		public void WriteData(Stream st)
		{
			st.WriteBools(Stocks != 0, Products.Count > 0, Patents != 0, Frameworks.Count > 0, Addons.Count > 0, Bankrupt);
			st.WriteByte(Target);
			if (Stocks != 0)
			{
				st.WriteInt(Stocks);
			}
			if (Products.Count > 0)
			{
				st.WriteArray(Products, delegate(Stream s, SoftwareProduct x)
				{
					s.WriteUInt(x.ID);
				});
			}
			if (Patents != 0)
			{
				st.WriteInt(Patents);
			}
			if (Frameworks.Count > 0)
			{
				st.WriteArray(Frameworks, delegate(Stream s, SoftwareFramework x)
				{
					s.WriteUInt(x.ID);
				});
			}
			if (Addons.Count > 0)
			{
				st.WriteArray(Addons, delegate(Stream s, AddOnProduct x)
				{
					s.WriteUInt(x.Parent.ID);
					s.WriteUInt(x.ID);
				});
			}
		}

		public static TakeOverData ReadData(Stream st)
		{
			TakeOverData takeOverData = new TakeOverData();
			bool b;
			bool b2;
			bool b3;
			bool b4;
			bool b5;
			st.ReadBools(out b, out b2, out b3, out b4, out b5, out takeOverData.Bankrupt);
			takeOverData.Target = (byte)st.ReadByte();
			if (b)
			{
				takeOverData.Stocks = st.ReadInt();
			}
			if (b2)
			{
				takeOverData.Products = st.ReadList((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			}
			if (b3)
			{
				takeOverData.Patents = st.ReadInt();
			}
			if (b4)
			{
				takeOverData.Frameworks = st.ReadList((Stream s) => MarketSimulation.Active.GetFramework(s.ReadUInt()));
			}
			if (b5)
			{
				takeOverData.Addons = st.ReadList((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false).GetAddon(s.ReadUInt()));
			}
			return takeOverData;
		}
	}

	public const int BusinessRepStars = 6;

	public static float StockDefaultPrice = 50000f;

	public readonly uint ID;

	public readonly string Name;

	public readonly SDateTime Founded;

	private Dictionary<SoftwareProduct, SHashSet<ILossable>> Licenses = new Dictionary<SoftwareProduct, SHashSet<ILossable>>();

	private Dictionary<SoftwareProduct, int> OSSeats = new Dictionary<SoftwareProduct, int>();

	public List<PublisherDeal> Publishing = new List<PublisherDeal>();

	private Dictionary<uint, ScheduledRelease> _scheduledReleases = new Dictionary<uint, ScheduledRelease>();

	protected Dictionary<string, int> _latestResearch = new Dictionary<string, int>();

	public List<Employee> NetworkEmployees = new List<Employee>();

	public List<MarketEvent> MarketEvents = new List<MarketEvent>();

	public int CompaniesBought;

	public uint Shares;

	[AltWasFloat(0)]
	private double _share = 1.0;

	[AltWasFloat(0)]
	protected double _money;

	[AltWasFloat(0)]
	private double[] _valuationValues = new double[12];

	private int _valuationOffset;

	public bool LeadBidHappening;

	[Obsolete]
	public Stock[] Stocks;

	[Obsolete]
	public EventList<Stock> OwnedStock;

	public byte NetworkPlayerID;

	public List<NewStock> NewStock = new List<NewStock>();

	public EventList<NewStock> NewOwnedStock = new EventList<NewStock>();

	public int StockQuarantine;

	public List<TechLevel> Patents = new List<TechLevel>();

	public SHashSet<uint> Subsidiaries = new SHashSet<uint>();

	public Dictionary<string, RepEffectItem> RepEffects;

	public List<SoftwareFramework> Frameworks = new List<SoftwareFramework>();

	public List<AddOnProduct> AddOns = new List<AddOnProduct>();

	public bool ForceBuyStocksFrom;

	public DistributionPlatform Distribution;

	[NameRedirection(new string[] { "ActiveDistribution" })]
	private List<DistributionPlatform> _activeDistribution = new List<DistributionPlatform>();

	public TaxReport CurrentTaxReport = new TaxReport();

	public TaxReport LastTaxReport;

	public byte[] Logo;

	public List<KeyValuePair<int, byte[]>> PreviousLogos;

	public bool DontSync;

	public float EmployerScore;

	public Dictionary<Company, int> WantsDistribution = new Dictionary<Company, int>();

	protected Dictionary<Company, float> _playerAcceptRates = new Dictionary<Company, float>();

	public SDateTime? TakeOver;

	public NetworkServer CloudService;

	public float? SoftwarePrintMarkup;

	public Dictionary<IManufacturable, float> HardwarePrintMarkup = new Dictionary<IManufacturable, float>();

	protected bool _autoAcceptPlatforms = true;

	private uint _ownerCompany;

	private uint _cachedFans;

	private bool _fanCountDirty = true;

	protected Dictionary<SoftwareCategory, float> _softwareRep = new Dictionary<SoftwareCategory, float>();

	protected Dictionary<SoftwareCategory, uint> _softwarePop = new Dictionary<SoftwareCategory, uint>();

	protected Dictionary<SoftwareCategory, SDateTime> _lastRelease = new Dictionary<SoftwareCategory, SDateTime>();

	protected float _businessReputation = 1f / 6f;

	[IgnoreNetwork]
	public SHashSet<WorkItem> WorkItems = new SHashSet<WorkItem>();

	public List<SoftwareProduct> Products = new List<SoftwareProduct>();

	public bool Bankrupt;

	public bool Player;

	public bool LocalPlayer = true;

	public Dictionary<string, List<float>> Cashflow = new Dictionary<string, List<float>>();

	public Dictionary<string, float> tempCashflow = new Dictionary<string, float>();

	[AltWasFloat(0)]
	public double ExtraWorth;

	public float? DistributionLoad;

	private static List<double> _pcCache = new List<double>();

	public static float FanThresh = 2000000f;

	private static FloatInterpolator _popScore = new FloatInterpolator(0f, 0.1f, 0.18f, 0.24f, 0.29f, 0.34f, 0.38f, 0.41f, 0.43f, 0.44f, 0.45f, 0.46f, 0.47f, 0.48f, 0.52f, 0.58f, 0.66f, 0.74f, 0.82f, 0.9f, 1f);

	private static Dictionary<byte, TakeOverData> _takeOverData = new Dictionary<byte, TakeOverData>();

	private static ObjectPool<TakeOverData> _takeOverPool = new ObjectPool<TakeOverData>(() => new TakeOverData(), null, delegate(TakeOverData x)
	{
		x.Clear();
	});

	public float Valuation { get; private set; }

	public bool AutoAcceptPlatforms
	{
		get
		{
			return _autoAcceptPlatforms;
		}
	}

	public bool IsInvestor
	{
		get
		{
			return MarketSimulation.Active.PrivateInvestors == this;
		}
	}

	public Company OwnerCompany
	{
		get
		{
			if (_ownerCompany != 0)
			{
				return GameSettings.Instance.simulation.GetCompany(_ownerCompany);
			}
			return null;
		}
		set
		{
			if (_ownerCompany != 0)
			{
				Company ownerCompany = OwnerCompany;
				if (ownerCompany != null)
				{
					ownerCompany.Subsidiaries.Remove(ID);
				}
			}
			_ownerCompany = ((value != null) ? value.ID : 0u);
			if (_ownerCompany != 0)
			{
				Company ownerCompany2 = OwnerCompany;
				if (ownerCompany2 != null)
				{
					ownerCompany2.Subsidiaries.Add(ID);
				}
			}
		}
	}

	public double Money
	{
		get
		{
			return _money;
		}
	}

	public uint Fans
	{
		get
		{
			if (_fanCountDirty)
			{
				_fanCountDirty = false;
				if (_softwarePop.Count == 0)
				{
					_cachedFans = 0u;
				}
				else
				{
					uint num = 0u;
					uint num2 = 0u;
					foreach (KeyValuePair<SoftwareCategory, uint> item in _softwarePop)
					{
						if (item.Value > num2)
						{
							num2 = item.Value;
						}
						num += item.Value;
					}
					_cachedFans = num2 + (num - num2 >> 2);
				}
			}
			return _cachedFans;
		}
	}

	public float BusinessReputation
	{
		get
		{
			return _businessReputation;
		}
	}

	public float DiscreteRep
	{
		get
		{
			if (!Mathf.Approximately(_businessReputation, 1f))
			{
				return Mathf.Floor(_businessReputation * 6f) / 6f;
			}
			return 1f;
		}
	}

	public int BusinessStars
	{
		get
		{
			if (!Mathf.Approximately(_businessReputation, 1f))
			{
				return Mathf.FloorToInt(_businessReputation * 6f);
			}
			return 6;
		}
	}

	public bool IsLocalPlayer
	{
		get
		{
			if (Player)
			{
				return LocalPlayer;
			}
			return false;
		}
	}

	public float GetPrintPrice(IStockable s)
	{
		return NetworkPrintDeal.GetCost(s, GetPrintMarkup(s));
	}

	public float GetPrintMarkup(IStockable s)
	{
		if (!s.Manufacturing.IsHardware())
		{
			return SoftwarePrintMarkup.Value;
		}
		return HardwarePrintMarkup[s.Manufacturing];
	}

	public void SetPrintMarkup(IManufacturable man, float markup)
	{
		SoftwareAddOn softwareAddOn;
		SoftwareCategory softwareCategory;
		if (man == null || !man.IsHardware())
		{
			NetworkMessaging.SendChangePrintMarkup(ID, 0u, 0u, false, markup, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else if ((softwareAddOn = man as SoftwareAddOn) != null)
		{
			NetworkMessaging.SendChangePrintMarkup(ID, softwareAddOn.Parent.ID, softwareAddOn.ID, true, markup, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else if ((softwareCategory = man as SoftwareCategory) != null)
		{
			NetworkMessaging.SendChangePrintMarkup(ID, softwareCategory.Parent.ID, softwareCategory.ID, false, markup, NetworkMessaging.MessageTarget.Everyone, 0);
		}
	}

	public void BeginTakeover(Company c, bool fromNetwork = false)
	{
		if (!TakeOver.HasValue)
		{
			if (!fromNetwork)
			{
				NetworkMessaging.SendBeginTakeover(ID, c.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			SDateTime sDateTime = SDateTime.Now();
			int num = Mathf.FloorToInt(Options.Difficulty.TakeoverMonths);
			TakeOver = new SDateTime(0, sDateTime.Hour, sDateTime.Month + num, sDateTime.Year);
			StockQuarantine = 12 * GameSettings.DaysPerMonth;
			if (LocalPlayer)
			{
				WindowManager.Instance.ShowMessageBox("PlayerTakeOverPrompt".Loc((c != null) ? c.Name : null, num), true, DialogWindow.DialogType.Warning);
			}
		}
	}

	public void FixNetworkPlayerReferences(Company actualCompany, bool sameMonth)
	{
		Licenses.Clear();
		foreach (KeyValuePair<SoftwareProduct, SHashSet<ILossable>> license in actualCompany.Licenses)
		{
			SoftwareProduct key;
			if ((key = license.Key.FixReferences() as SoftwareProduct) == null)
			{
				continue;
			}
			SHashSet<ILossable> value;
			if (!Licenses.TryGetValue(key, out value))
			{
				SHashSet<ILossable> sHashSet = (Licenses[key] = new SHashSet<ILossable>());
				value = sHashSet;
			}
			List<ILossable> list = license.Value.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				ILossable item;
				if ((item = list[i].FixReferences() as ILossable) != null)
				{
					value.Add(item);
				}
			}
			if (value.Count == 0)
			{
				Licenses.Remove(key);
			}
		}
		OSSeats = actualCompany.OSSeats.FixKeyReferences(true);
		Publishing = actualCompany.Publishing.SelectNotNull((PublisherDeal x) => x.FixReferences() as PublisherDeal).ToList();
		if (Distribution != null && actualCompany.Distribution != null)
		{
			Distribution.ServerName = actualCompany.Distribution.ServerName;
		}
		List<WorkItem> input = actualCompany.WorkItems.ToList();
		WorkItems = input.SelectNotNull((WorkItem x) => x.FixReferences() as WorkItem).ToSHashSet();
		PreviousLogos = actualCompany.PreviousLogos;
		Logo = actualCompany.Logo;
		if (sameMonth)
		{
			CurrentTaxReport.IllegalActions = actualCompany.CurrentTaxReport.IllegalActions;
			CurrentTaxReport.ReportProgress = actualCompany.CurrentTaxReport.ReportProgress;
			CurrentTaxReport.Optimization = actualCompany.CurrentTaxReport.Optimization;
			if (actualCompany.LastTaxReport != null && LastTaxReport != null)
			{
				LastTaxReport.IllegalActions = actualCompany.LastTaxReport.IllegalActions;
				LastTaxReport.ReportProgress = actualCompany.LastTaxReport.ReportProgress;
				LastTaxReport.Optimization = actualCompany.LastTaxReport.Optimization;
			}
		}
		else
		{
			CurrentTaxReport.IllegalActions = actualCompany.CurrentTaxReport.IllegalActions;
			CurrentTaxReport.Optimization = actualCompany.CurrentTaxReport.Optimization;
			if (actualCompany.LastTaxReport != null && LastTaxReport != null)
			{
				LastTaxReport.ReportProgress = actualCompany.LastTaxReport.ReportProgress;
				LastTaxReport.Optimization = actualCompany.LastTaxReport.Optimization;
			}
		}
		for (int num = 0; num < actualCompany.Products.Count; num++)
		{
			SoftwareProduct pr = actualCompany.Products[num];
			SoftwareProduct softwareProduct = Products.FirstOrDefault((SoftwareProduct x) => x.ID == pr.ID);
			if (softwareProduct == null)
			{
				continue;
			}
			softwareProduct.Server = pr.Server;
			softwareProduct.StockNotifications = pr.StockNotifications;
			softwareProduct.PlayerArchived = pr.PlayerArchived;
			foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon2 in softwareProduct.Addons)
			{
				foreach (AddOnProduct item2 in addon2.Value)
				{
					AddOnProduct addon = pr.GetAddon(item2.ID);
					if (addon != null)
					{
						item2.StockNotifications = addon.StockNotifications;
					}
				}
			}
		}
	}

	public void SetAutoAcceptPlatforms(bool autoAcceptPlatforms, bool fromNetwork = false)
	{
		if (!fromNetwork && autoAcceptPlatforms != _autoAcceptPlatforms)
		{
			NetworkMessaging.SendChangePlatformAccept(ID, false, autoAcceptPlatforms, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_autoAcceptPlatforms = autoAcceptPlatforms;
	}

	public void HostChangeMoney(double money)
	{
		_money = money;
	}

	public bool IsSigned(DistributionPlatform p)
	{
		return _activeDistribution.Contains(p);
	}

	public List<DistributionPlatform> GetPlatforms()
	{
		return _activeDistribution;
	}

	public void ResetAcceptRates()
	{
		_playerAcceptRates = _activeDistribution.ToDictionary((DistributionPlatform x) => x.Owner, (DistributionPlatform x) => x.GetCut());
	}

	public bool SignPlatform(DistributionPlatform platform, bool sign, bool fromNetwork = false)
	{
		bool result = false;
		if (sign)
		{
			if (!_activeDistribution.Contains(platform))
			{
				_activeDistribution.Add(platform);
				if (platform.Owner.IsLocalPlayer)
				{
					HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
					if (platform.HasToPay(this))
					{
						MarketSimulation.Active.DistributionQueryChange.Add(this);
					}
				}
				result = true;
				if (!fromNetwork)
				{
					NetworkMessaging.SendSignDigitalPlatform(ID, platform.Software.ID, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
			}
		}
		else if (_activeDistribution.Remove(platform))
		{
			_playerAcceptRates.Remove(platform.Owner);
			result = true;
			if (platform.Owner.IsLocalPlayer)
			{
				HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
				if (platform.HasToPay(this))
				{
					MarketSimulation.Active.DistributionQueryChange.Add(this);
				}
			}
			if (!fromNetwork)
			{
				NetworkMessaging.SendSignDigitalPlatform(ID, platform.Software.ID, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
		if (!fromNetwork)
		{
			foreach (Company item in Subsidiaries.Select(MarketSimulation.Active.GetCompany))
			{
				if (item.IsSigned(platform) != sign)
				{
					item.MarkInterested(platform.Owner, sign, 0);
				}
			}
		}
		return result;
	}

	public void ScheduleRelease(string name, uint id, SoftwareCategory cat, SoftwareProduct sequelTo, SDateTime? releaseDate, bool fromNetwork = false)
	{
		if (!GameSettings.Instance.IsNetworkMode)
		{
			return;
		}
		if (_scheduledReleases.ContainsKey(id))
		{
			RescheduleRelease(id, releaseDate, fromNetwork);
			return;
		}
		if (!fromNetwork)
		{
			NetworkMessaging.SendScheduleRelease(ID, id, name, cat.Parent.ID, cat.ID, (sequelTo != null) ? sequelTo.ID : 0u, releaseDate, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_scheduledReleases[id] = new ScheduledRelease(name, id, cat, releaseDate, sequelTo, this);
	}

	public void RescheduleRelease(uint id, SDateTime? releaseDate, bool fromNetwork = false)
	{
		ScheduledRelease value;
		if (_scheduledReleases.TryGetValue(id, out value))
		{
			if (!fromNetwork)
			{
				NetworkMessaging.SendScheduleRelease(ID, id, null, 0u, 0u, 0u, releaseDate, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			value.ReleaseDate = releaseDate;
		}
	}

	public void UnscheduleRelease(uint id, bool fromNetwork = false)
	{
		if (_scheduledReleases.ContainsKey(id))
		{
			if (!fromNetwork)
			{
				NetworkMessaging.SendScheduleRelease(ID, id, null, 0u, 0u, 0u, null, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			_scheduledReleases.Remove(id);
		}
	}

	public IEnumerable<ScheduledRelease> GetReleases()
	{
		return _scheduledReleases.Values;
	}

	public void GenerateLogo()
	{
		Logo = SDFCreator.SerializeTree(SDFCreator.Instance.GetRandomTree("Final").Generate());
	}

	public virtual bool CanTakeStockFrom()
	{
		return ForceBuyStocksFrom;
	}

	public IEnumerable<Company> GetSubsidiaries()
	{
		foreach (uint subsidiary in Subsidiaries)
		{
			Company company = GameSettings.Instance.simulation.GetCompany(subsidiary);
			if (company != null)
			{
				yield return company;
			}
		}
	}

	public int LicenseCount(SoftwareProduct p)
	{
		SHashSet<ILossable> value;
		if (!Licenses.TryGetValue(p, out value))
		{
			return 0;
		}
		return value.Count;
	}

	public IEnumerable<SoftwareProduct> GetLicenses()
	{
		return Licenses.Keys;
	}

	public void ReleaseNow(SoftwareCategory cat, SDateTime time)
	{
		_lastRelease[cat] = time;
	}

	public void AddMarketEvent(MarketEvent ev, bool networked)
	{
		if (networked)
		{
			NetworkMessaging.SendMarketEventData(ev, 1, ID, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else
		{
			MarketEvents.Add(ev);
		}
	}

	public void FixMarketRecognition()
	{
		if (_softwareRep.Count <= 0 || _softwarePop.Count != 0)
		{
			return;
		}
		foreach (KeyValuePair<SoftwareCategory, float> item in _softwareRep)
		{
			_softwarePop[item.Key] = (uint)(item.Value * item.Key.Popularity * (float)MarketSimulation.Population);
			_fanCountDirty = true;
		}
	}

	public void ChangeBusinessRep(float percentStars, string category, float max = 1f)
	{
		if (percentStars == 0f || float.IsNaN(percentStars) || float.IsInfinity(percentStars))
		{
			return;
		}
		percentStars = ((percentStars > 0f) ? Mathf.Min(max, percentStars) : Mathf.Max(0f - max, percentStars));
		if (IsLocalPlayer && category != null)
		{
			RepEffectItem value;
			if (RepEffects.TryGetValue(category, out value))
			{
				value.ChangeValue(percentStars);
			}
			else
			{
				RepEffects[category] = new RepEffectItem(percentStars);
			}
		}
		_businessReputation = Mathf.Clamp01(_businessReputation + percentStars / 6f);
	}

	public double GetMoneyWithInsurance(bool withStocks = true, bool firstRecursion = false)
	{
		double num = Money;
		if (Subsidiaries.Count > 0)
		{
			foreach (uint subsidiary in Subsidiaries)
			{
				Company company = GameSettings.Instance.simulation.GetCompany(subsidiary);
				if (company != null)
				{
					num += company.GetMoneyWithInsurance(false);
				}
			}
		}
		if (withStocks)
		{
			num = ((!firstRecursion) ? (num + NewOwnedStock.SumSafe((NewStock x) => x.TotalWorthNoStocks)) : (num + NewOwnedStock.SumSafe((NewStock x) => x.TotalWorth)));
		}
		num = ((!IsLocalPlayer) ? (num + ExtraWorth) : (num + GetPlayerExtraWorth()));
		return Math.Max(0.0, num);
	}

	public double GetPlayerExtraWorth()
	{
		double num = GameSettings.Instance.Insurance.Money - GameSettings.Instance.Loans.SumSafe((Loan x) => (double)x.Months * x.Monthly);
		if (!GameSettings.Instance.RentMode)
		{
			num += (double)GameSettings.Instance.PlayerPlots.SumSafe((PlotArea x) => x.Price - x.Monthly * (float)x.MonthsLeft);
		}
		return num + (double)GameSettings.Instance.Investments.SumSafe((Investment x) => x.CurrentValue);
	}

	public double GetShareWorth(bool withStocks = true)
	{
		if (Shares != 0)
		{
			return GetMoneyWithInsurance(withStocks) / (double)Shares;
		}
		return 0.0;
	}

	public int GetLocalLatestResearch(string spec, int def)
	{
		return Mathf.Max(_latestResearch.GetOrDefault(spec, 0), def);
	}

	public int GetLatestResearch(string spec, int def)
	{
		int num = Mathf.Max(_latestResearch.GetOrDefault(spec, 0), def);
		for (int i = 0; i < NewOwnedStock.Count; i++)
		{
			if (NewOwnedStock[i].Percentage >= 0.10000000149011612)
			{
				num = Mathf.Max(num, NewOwnedStock[i].Seller._latestResearch.GetOrDefault(spec, 0));
			}
		}
		foreach (uint subsidiary in Subsidiaries)
		{
			Company company = GameSettings.Instance.simulation.GetCompany(subsidiary);
			if (company != null)
			{
				num = Mathf.Max(num, company._latestResearch.GetOrDefault(spec, 0));
			}
		}
		Company ownerCompany = OwnerCompany;
		if (ownerCompany != null)
		{
			num = Mathf.Max(num, ownerCompany._latestResearch.GetOrDefault(spec, 0));
		}
		return num;
	}

	public int GetLatestResearchDetailed(string spec, int minLevel, out string source, out string sourceType)
	{
		source = null;
		sourceType = null;
		int num = minLevel;
		int value;
		if (_latestResearch.TryGetValue(spec, out value) && value >= num)
		{
			sourceType = "Research";
			num = value;
		}
		for (int i = 0; i < NewOwnedStock.Count; i++)
		{
			int value2;
			if (NewOwnedStock[i].Percentage >= 0.10000000149011612 && NewOwnedStock[i].Seller._latestResearch.TryGetValue(spec, out value2) && value2 > num)
			{
				source = NewOwnedStock[i].Seller.Name;
				sourceType = "Stock";
				num = value2;
			}
		}
		foreach (uint subsidiary in Subsidiaries)
		{
			Company company = GameSettings.Instance.simulation.GetCompany(subsidiary);
			int value3;
			if (company != null && company._latestResearch.TryGetValue(spec, out value3) && value3 > num)
			{
				source = company.Name;
				sourceType = "Subsidiary";
				num = value3;
			}
		}
		Company ownerCompany = OwnerCompany;
		int value4;
		if (ownerCompany != null && ownerCompany._latestResearch.TryGetValue(spec, out value4) && value4 > num)
		{
			source = ownerCompany.Name;
			sourceType = "Owner";
			num = value4;
		}
		return num;
	}

	public virtual bool CanMakeSequel(SoftwareProduct p)
	{
		if (p.HasSequel || p.DevCompany != this)
		{
			return false;
		}
		if (IsLocalPlayer && WorkItems.OfType<SoftwareWorkItem>().Any((SoftwareWorkItem x) => x.SequelTo == p))
		{
			return false;
		}
		return true;
	}

	public void AddResearch(string spec, int value, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			NetworkMessaging.SendAddResearch(ID, spec, value, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_latestResearch[spec] = value;
	}

	public Dictionary<SoftwareCategory, float> GetSoftwareRep()
	{
		return _softwareRep;
	}

	public Dictionary<SoftwareCategory, uint> GetSoftwarePop()
	{
		return _softwarePop;
	}

	public void AddDistributionLoad(float value)
	{
		if (DistributionLoad.HasValue)
		{
			DistributionLoad = DistributionLoad.Value + value;
		}
		else
		{
			DistributionLoad = value;
		}
	}

	public bool IsPlayerOwned(bool onlyLocal = true)
	{
		if (!onlyLocal)
		{
			Company ownerCompany = OwnerCompany;
			if (ownerCompany != null)
			{
				return ownerCompany.Player;
			}
			return false;
		}
		return _ownerCompany == GameSettings.Instance.MyCompany.ID;
	}

	public bool IsSubsidiary()
	{
		return _ownerCompany != 0;
	}

	public void MakeSubsidiaryNetwork(Company owner, SDateTime time)
	{
		OwnerCompany = owner;
		AddMarketEvent(new MarketEvent(MarketEvent.EventType.Subsidiary, time, new string[1] { Name }, new uint[2] { ID, owner.ID }), false);
		owner.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Subsidiary, time, new string[1] { Name }, new uint[2] { ID, owner.ID }, 1f), false);
	}

	public void MakeSubsidiary(Company owner, SDateTime time)
	{
		NetworkMessaging.SendMakeSubsidiary(ID, owner.ID, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		OwnerCompany = owner;
		AddMarketEvent(new MarketEvent(MarketEvent.EventType.Subsidiary, time, new string[1] { Name }, new uint[2] { ID, owner.ID }), false);
		owner.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Subsidiary, time, new string[1] { Name }, new uint[2] { ID, owner.ID }, 1f), false);
		int num = 0;
		foreach (TechLevel item in Patents.ToList())
		{
			if (item.TransferPatent(owner, time))
			{
				num++;
			}
		}
		foreach (SoftwareFramework item2 in Frameworks.ToList())
		{
			item2.Transfer(owner);
			if (owner.Player)
			{
				GetTakeOverData(owner.NetworkPlayerID).Frameworks.Add(item2);
			}
		}
		Publishing.ToList().ForEach(delegate(PublisherDeal x)
		{
			x.Abandon();
		});
		List<NewStock> list = NewStock.ToList();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			NewStock newStock = list[num2];
			TradeStock(this, newStock.Shares, time, 0.0, newStock);
		}
		int idx = 0;
		TransferStock(new Company[1] { owner }, time, ref idx, true, true);
		foreach (DistributionPlatform distributionPlatform in MarketSimulation.Active.DistributionPlatforms)
		{
			bool flag = IsSigned(distributionPlatform);
			if (flag != owner.IsSigned(distributionPlatform))
			{
				MarkInterested(distributionPlatform.Owner, !flag, 0);
			}
		}
		if (Distribution != null)
		{
			MarketSimulation.Active.ClosePlatform(Distribution);
		}
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = this as SimulatedCompany) != null)
		{
			simulatedCompany.DistributionDevelopmentCooldown = -1;
		}
		if (owner.IsLocalPlayer)
		{
			TutorialSystem.Instance.StartTutorial("Subsidiary");
			HUD.Instance.dealWindow.CancelCompanyDeals(this);
			HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
		}
		foreach (KeyValuePair<byte, TakeOverData> takeOverDatum in _takeOverData)
		{
			if (!NetworkMessaging.SendTakeOverData(ID, takeOverDatum.Value, NetworkMessaging.MessageTarget.Specifically, takeOverDatum.Key))
			{
				GenerateTakeOverMessage(this, takeOverDatum.Value);
			}
		}
		ReleaseTakeOverData();
		NetworkMeta.CheckDirty();
	}

	public double GetShare()
	{
		return _share;
	}

	public double GetCompanyShares(Company c)
	{
		if (this == c)
		{
			return GetShare();
		}
		for (int i = 0; i < NewStock.Count; i++)
		{
			NewStock newStock = NewStock[i];
			if (newStock.Buyer == c)
			{
				return newStock.Percentage;
			}
		}
		return 0.0;
	}

	public double GetShareWithFounders()
	{
		if (Shares == 0)
		{
			return 1.0;
		}
		double num = Shares;
		foreach (NewStock item in NewStock)
		{
			if (!(item.Buyer is FounderShareHolder))
			{
				num -= (double)item.Shares;
			}
		}
		return num / (double)Shares;
	}

	public float GetOwnShares()
	{
		return Shares - NewStock.SumSafe((NewStock x) => x.Shares);
	}

	public void UpdateShare()
	{
		if (Shares == 0)
		{
			_share = 1.0;
			return;
		}
		double moneyWithInsurance = GetMoneyWithInsurance();
		if (moneyWithInsurance / (double)Shares < 25.0 && moneyWithInsurance > 100000.0)
		{
			_pcCache.Clear();
			for (int i = 0; i < NewStock.Count; i++)
			{
				_pcCache.Add(NewStock[i].Percentage);
			}
			Shares = (uint)moneyWithInsurance / 100;
			for (int j = 0; j < NewStock.Count; j++)
			{
				double num = (double)Shares * _pcCache[j];
				uint num2 = (uint)num;
				NewStock[j].Shares = ((num - (double)num2 > 0.5) ? (num2 + 1) : num2);
				if (NewStock[j].Shares == 0)
				{
					NewStock[j].Shares = 1u;
				}
				else if (NewStock[j].Shares >= Shares)
				{
					NewStock[j].Shares = Shares - 1;
				}
			}
		}
		uint num3 = Shares;
		for (int k = 0; k < NewStock.Count; k++)
		{
			if (NewStock[k].Shares >= num3)
			{
				uint num4 = NewStock[k].Shares - num3;
				num3 += num4 + 1;
				Shares += num4 + 1;
			}
			num3 -= NewStock[k].Shares;
		}
		_share = (float)num3 / (float)Shares;
	}

	public Company(string name, double startingMoney, SDateTime time, MarketSimulation sim, bool eventComp = false)
	{
		Name = name;
		_money = startingMoney;
		Founded = time;
		string[] names = Enum.GetNames(typeof(TransactionCategory));
		foreach (string key in names)
		{
			Cashflow.Add(key, new List<float>());
		}
		Cashflow.Remove("NA");
		Cashflow.Add("Balance", new List<float>());
		ID = ((!eventComp) ? sim.GetCompanyID() : 0u);
		Valuation = 0f;
		MarketEvents.Add(new MarketEvent(MarketEvent.EventType.Founded, time, ID));
	}

	public Company(string name, double startingMoney, SDateTime time, uint id)
	{
		Name = name;
		_money = startingMoney;
		Founded = time;
		string[] names = Enum.GetNames(typeof(TransactionCategory));
		foreach (string key in names)
		{
			Cashflow.Add(key, new List<float>());
		}
		Cashflow.Remove("NA");
		Cashflow.Add("Balance", new List<float>());
		ID = id;
		Valuation = 0f;
		MarketEvents.Add(new MarketEvent(MarketEvent.EventType.Founded, time, ID));
	}

	public void InfiniteMoney()
	{
		_money = double.PositiveInfinity;
	}

	public Company()
	{
	}

	public float GetReputation(SoftwareCategory cat)
	{
		return _softwareRep.GetOrDefault(cat, 0f);
	}

	private static float PopulationToScore(uint pop, uint max, float difficulty)
	{
		float num = Mathf.Clamp01((float)pop / (float)max);
		return Mathf.Lerp(_popScore.Evaluate(num), num * num, difficulty);
	}

	public void AddFans(int amount, SoftwareCategory cat)
	{
		if (amount != 0)
		{
			NetworkMessaging.SendAddFans(ID, cat.Parent.ID, cat.ID, amount, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyAddFans(amount, cat);
	}

	public void ActuallyAddFans(int amount, SoftwareCategory cat)
	{
		if (amount == 0 || cat == null)
		{
			return;
		}
		uint orDefault = _softwarePop.GetOrDefault(cat, 0u);
		uint num = (uint)(cat.Popularity * (float)MarketSimulation.FanPopulation);
		if (amount < 0)
		{
			orDefault = ((-amount <= orDefault) ? (orDefault - (uint)(-amount)) : 0u);
		}
		else
		{
			try
			{
				orDefault = checked(orDefault + (uint)amount);
			}
			catch (OverflowException)
			{
				orDefault = num;
			}
			if (orDefault > num)
			{
				orDefault = num;
			}
		}
		_softwarePop[cat] = orDefault;
		uint num2 = 0u;
		foreach (KeyValuePair<SoftwareCategory, uint> item in _softwarePop)
		{
			if (item.Key == cat || item.Value <= orDefault)
			{
				continue;
			}
			if (item.Key.Parent == cat.Parent)
			{
				float num3 = (float)(item.Value - orDefault) * 0.1f;
				if (num3 > (float)num2)
				{
					num2 = (uint)num3;
				}
			}
			else
			{
				float num4 = (float)(item.Value - orDefault) * 0.05f;
				if (num4 > (float)num2)
				{
					num2 = (uint)num4;
				}
			}
		}
		_softwareRep[cat] = PopulationToScore(orDefault + num2, num, cat.Hardware ? 0f : (cat.IdealPrice * cat.Popularity).MapRange(50f, 200f, 0f, 1f, true));
		_fanCountDirty = true;
	}

	private float GetRecBoost(float cur)
	{
		return 0.5f + (1f - Mathf.Clamp01(cur));
	}

	public bool CanOwnStock(Company c)
	{
		if (!Player || !c.Player)
		{
			return NewOwnedStock.None((NewStock x) => x.Seller == c);
		}
		return true;
	}

	public bool TradeStock(Company c, uint shares, SDateTime time, double? offer = null, NewStock existing = null)
	{
		if (existing != null && NetworkManager.IsConnected)
		{
			NetworkManager.Instance.TradeController.CancelAllTradesFor(existing);
		}
		NetworkMessaging.SendTradeStock(ID, c.ID, shares, Shares, offer ?? (-1.0), (existing != null) ? existing.Buyer.ID : 0u, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		return ActuallyTradeStock(c, shares, time, offer, existing);
	}

	public bool ActuallyTradeStock(Company c, uint shares, SDateTime time, double? offer = null, NewStock existing = null)
	{
		NetworkMeta.CheckDirty();
		if (shares == 0)
		{
			if (existing != null && existing.Shares == 0)
			{
				existing.Buyer.NewOwnedStock.Remove(existing);
				NewStock.Remove(existing);
			}
			return false;
		}
		if (existing != null && c == existing.Buyer)
		{
			return false;
		}
		double num = offer ?? ((double)shares * GetShareWorth());
		if (existing != null)
		{
			if (existing.Seller != this)
			{
				Debug.LogException(new Exception("Tried to trade stock from wrong owner"));
				return false;
			}
			shares = shares.Min(existing.Shares);
			existing.Buyer.ActuallyMakeTransaction(num, TransactionCategory.Stocks, TaxReport.TaxType.None, time);
			if (!Bankrupt && _ownerCompany == 0)
			{
				existing.Buyer.AddMarketEvent(new MarketEvent(MarketEvent.EventType.SoldStock, time, (float)(num - existing.InitialWorth * (double)shares), (float)shares / (float)existing.Shares, ID), false);
			}
			double num2 = existing.LastTaxValue * (double)((float)shares / (float)existing.Shares);
			existing.Buyer.ActuallyAddTax(TaxReport.TaxType.Investments, num - num2);
			existing.LastTaxValue -= num2;
			existing.Shares -= shares;
			if (existing.Shares == 0)
			{
				existing.Buyer.NewOwnedStock.Remove(existing);
				NewStock.Remove(existing);
			}
		}
		else
		{
			uint shares2 = Shares;
			try
			{
				shares2 = checked(Shares + shares);
			}
			catch (OverflowException)
			{
				UpdateShare();
				return false;
			}
			ActuallyMakeTransaction(num, TransactionCategory.Stocks, TaxReport.TaxType.None, time);
			Shares = shares2;
		}
		c.ActuallyMakeTransaction(0.0 - num, TransactionCategory.Stocks, TaxReport.TaxType.None, time);
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = c as SimulatedCompany) != null)
		{
			simulatedCompany.StockBudgetUsed += (float)num;
		}
		if (c != this)
		{
			NewStock newStock = NewStock.FirstOrDefault((NewStock x) => x.Buyer == c);
			if (newStock == null)
			{
				newStock = new NewStock(this, c, shares, offer);
				NewStock.Add(newStock);
				c.NewOwnedStock.Add(newStock);
			}
			else
			{
				newStock.Expand(shares, offer);
			}
			c.AddMarketEvent(new MarketEvent(MarketEvent.EventType.BoughtStock, time, (float)num, (float)newStock.Percentage, ID), false);
		}
		else
		{
			Shares -= shares;
			if (NewStock.Count == 0)
			{
				Shares = 0u;
			}
		}
		UpdateShare();
		if (c == this && !Bankrupt && _ownerCompany == 0)
		{
			MarketEvent marketEvent = new MarketEvent(MarketEvent.EventType.StockBuyBack, time, (float)GetShare());
			if (c.MarketEvents.Last().Type == MarketEvent.EventType.StockBuyBack)
			{
				c.MarketEvents[c.MarketEvents.Count - 1] = marketEvent;
			}
			else
			{
				c.AddMarketEvent(marketEvent, false);
			}
		}
		return true;
	}

	public void CleanCompany(SDateTime time)
	{
		if (IsSubsidiary())
		{
			foreach (WorkItem workItem in OwnerCompany.WorkItems)
			{
				if (workItem.CompanyWorker == this)
				{
					workItem.CompanyWorker = null;
				}
			}
			OwnerCompany.Subsidiaries.Remove(ID);
		}
		if (GetPlatforms().Any((DistributionPlatform x) => x.Owner.IsLocalPlayer))
		{
			HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
		}
		Publishing.ToList().ForEach(delegate(PublisherDeal x)
		{
			x.Abandon();
		});
		List<TechLevel> list = Patents.ToList();
		for (int num = 0; num < list.Count; num++)
		{
			list[num].TransferPatent(null, time);
		}
		List<SoftwareFramework> list2 = Frameworks.ToList();
		for (int num2 = 0; num2 < list2.Count; num2++)
		{
			list2[num2].Transfer(null);
		}
		List<NewStock> list3 = NewStock.ToList();
		for (int num3 = 0; num3 < list3.Count; num3++)
		{
			NewStock newStock = list3[num3];
			TradeStock(this, newStock.Shares, time, 0.0, newStock);
		}
		ClearStock(time);
	}

	public void NetworkBuyout(string buyer)
	{
		if (IsPlayerOwned())
		{
			NotificationManager.AddNotification("SubsidiaryBankruptWarning".LocColor(this), "Skyskraper", NotificationManager.NotificationType.Warning);
		}
		Bankrupt = true;
		if (IsSubsidiary())
		{
			foreach (WorkItem workItem in OwnerCompany.WorkItems)
			{
				if (workItem.CompanyWorker == this)
				{
					workItem.CompanyWorker = null;
				}
			}
			OwnerCompany.Subsidiaries.Remove(ID);
		}
		Publishing.ToList().ForEach(delegate(PublisherDeal x)
		{
			x.Abandon();
		});
		Products.ForEach(delegate(SoftwareProduct x)
		{
			x.CancelHostingServices();
		});
		GameSettings.Instance.simulation.RemoveCompany(this);
		SimulateLayoffs();
		NetworkPlayerBuyout(buyer, true);
		for (int num = 0; num < GameSettings.Instance.Loans.Count; num++)
		{
			if (GameSettings.Instance.Loans[num].Payee == this)
			{
				GameSettings.Instance.Loans.RemoveAt(num);
				num--;
			}
		}
	}

	private void SimulateLayoffs()
	{
		if (!Player)
		{
			MarketSimulation.Active.Layoffs = Mathf.Min(MarketSimulation.Active.Layoffs + 50, 300);
		}
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = this as SimulatedCompany) != null && simulatedCompany.LeadDesigner != null)
		{
			simulatedCompany.LeadDesigner.Dismiss(true);
			simulatedCompany.LeadDesigner.MyEmployer = null;
			MarketSimulation.Active.FreeLeads.Add(simulatedCompany.LeadDesigner);
		}
	}

	public void NetworkPlayerBuyout(string buyer, bool canDisconnect)
	{
		if (!Player)
		{
			return;
		}
		NetworkMeta networkData = GameSettings.Instance.NetworkData;
		if (networkData != null)
		{
			networkData.UnregisterCompany(NetworkPlayerID, ID);
		}
		if (LocalPlayer)
		{
			if (!canDisconnect)
			{
				return;
			}
			foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
			{
				if (actor.employee.NetworkID != 0)
				{
					NetworkMessaging.MoveLeadDesigner(actor.employee, null, true, true);
				}
			}
			NetworkMessaging.DisconnectMyself();
			NetworkMessaging.SendAllNow();
			NetworkManager.Instance.CleanUpEverything(true);
			WindowManager.SpawnDialog().Show("PlayerTakeOverLosePrompt".Loc(buyer), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("Finances", delegate
			{
				HUD.Instance.financeWindow.Window.Modal = true;
				HUD.Instance.financeWindow.Show();
			}), new KeyValuePair<string, Action>("Quit", TimeOfDay.Instance.EndGame));
			return;
		}
		for (int num = 0; num < GameSettings.Instance.NetworkPrintOrders.List.Count; num++)
		{
			NetworkPrintDeal networkPrintDeal = GameSettings.Instance.NetworkPrintOrders.List[num];
			if (networkPrintDeal.Client == NetworkPlayerID || networkPrintDeal.Printer == NetworkPlayerID)
			{
				GameSettings.Instance.CancelPrintOrder(networkPrintDeal, false);
				networkPrintDeal.Cancel();
				num--;
			}
		}
		if (CloudService != null)
		{
			GameSettings.Instance.RemoveServer(CloudService);
			CloudService = null;
		}
		GameSettings.Instance.RemovePlayerFromCloudService(NetworkPlayerID);
		NetworkPlayer player = NetworkManager.GetPlayer(NetworkPlayerID);
		if (player != null)
		{
			NetworkManager.Instance.TradeController.CancelAllTradesFor(player, false);
		}
		PlayerMap value;
		if (GameSettings.Instance.sRoomManager.PlayerMaps.TryGetValue(NetworkPlayerID, out value))
		{
			value.Destroy();
			GameSettings.Instance.sRoomManager.PlayerMaps.Remove(NetworkPlayerID);
		}
		PlotArea plotArea = GameSettings.Instance.Plots.FirstOrDefault((PlotArea x) => x.PlayerStarterPlot && x.Owner == NetworkPlayerID);
		GameSettings.Instance.Plots.Where((PlotArea x) => x.Owner == NetworkPlayerID).ForEachEnum(delegate(PlotArea x)
		{
			x.SetOwner(0);
		});
		GameSettings.Instance.NetworkData.OldPlayers[NetworkPlayerID] = (float)Math.Max(0.0, Money);
		if (NetworkManager.IsHost)
		{
			NetworkManager.SetLobbyMetaData("AvailableSpots", NetworkManager.Instance.GetAvailableSpots().ToString());
			if (plotArea != null)
			{
				Rect bounds = ((IList<Vector2>)plotArea.Polygon).GetBounds();
				float roadSize = RoadManager.Instance.RoadSize;
				Rect r = new Rect(Mathf.FloorToInt(bounds.x / roadSize), Mathf.FloorToInt(bounds.y / roadSize), Mathf.CeilToInt(bounds.width / roadSize), Mathf.CeilToInt(bounds.height / roadSize));
				for (int num2 = RoadManager.Floors - 1; num2 >= 0; num2--)
				{
					RoadManager.Instance.PlaceRoad(r, num2, 0, null, true);
				}
			}
		}
		RoadManager.Instance.UpdateParkingAvailability(false);
	}

	public void BuyOut(IList<Company> companies, bool broke, SDateTime time, bool canDisconnect = true)
	{
		int idx = 0;
		if (IsSubsidiary())
		{
			foreach (WorkItem workItem in OwnerCompany.WorkItems)
			{
				if (workItem.CompanyWorker == this)
				{
					workItem.CompanyWorker = null;
				}
			}
			OwnerCompany.Subsidiaries.Remove(ID);
		}
		Publishing.ToList().ForEach(delegate(PublisherDeal x)
		{
			x.Abandon();
		});
		Products.ForEach(delegate(SoftwareProduct x)
		{
			x.CancelHostingServices();
		});
		MarketEvent marketEvent = new MarketEvent(MarketEvent.EventType.BuyOut, time, Name);
		if (companies != null)
		{
			companies.Distinct().ForEachEnum(delegate(Company x)
			{
				x.AddMarketEvent(marketEvent, true);
			});
		}
		if (GetPlatforms().Any((DistributionPlatform x) => x.Owner.IsLocalPlayer))
		{
			HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
		}
		HUD.Instance.dealWindow.CancelCompanyDeals(this);
		Company company = null;
		double num = Math.Max(0.0, GetMoneyWithInsurance(false));
		if (!broke && num > 0.0 && companies != null)
		{
			companies[0].MakeTransaction(0.0 - num, TransactionCategory.Stocks, true);
			companies[0].CompaniesBought++;
			company = companies[0];
		}
		if (broke)
		{
			MarketEvents.Add(new MarketEvent(MarketEvent.EventType.Bankrupt, time));
		}
		else
		{
			MarketEvents.Add(new MarketEvent(MarketEvent.EventType.BoughtOut, time, (company != null) ? company.ID : 0u));
		}
		Bankrupt = true;
		SimulateLayoffs();
		if (companies != null)
		{
			if (!IsSubsidiary())
			{
				List<Company> list = companies.Distinct().ToList();
				Newspaper.GenerateStockBuyout(this, list, num);
				if (NetworkManager.IsConnected)
				{
					NetworkMessaging.SendNewspaperTakeover(ID, list.SelectInPlace((Company x) => x.ID), num, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
			}
			List<TechLevel> list2 = Patents.ToList();
			for (int num2 = 0; num2 < list2.Count; num2++)
			{
				if (list2[num2].TransferPatent(companies[idx], time) && companies[idx].Player)
				{
					GetTakeOverData(companies[idx].NetworkPlayerID).Patents++;
				}
				idx = (idx + 1) % companies.Count;
			}
			List<SoftwareFramework> list3 = Frameworks.ToList();
			for (int num3 = 0; num3 < list3.Count; num3++)
			{
				list3[num3].Transfer(companies[idx]);
				if (companies[idx].Player)
				{
					GetTakeOverData(companies[idx].NetworkPlayerID).Frameworks.Add(list3[num3]);
				}
				idx = (idx + 1) % companies.Count;
			}
			foreach (IGrouping<SoftwareProduct, SoftwareProduct> item in (from x in Products
				group x by x.GetLatestSuccessor()).ToList())
			{
				if (item.All((SoftwareProduct x) => x.Archived))
				{
					foreach (SoftwareProduct item2 in item)
					{
						item2.Trade(MarketSimulation.Active.PublicDomain, time);
						foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in item2.Addons)
						{
							foreach (AddOnProduct item3 in addon.Value)
							{
								if (item3.Owner == this)
								{
									item3.Trade(MarketSimulation.Active.PublicDomain);
								}
							}
						}
					}
					continue;
				}
				foreach (SoftwareProduct item4 in item)
				{
					item4.Trade(companies[idx], time);
					if (companies[idx].Player)
					{
						GetTakeOverData(companies[idx].NetworkPlayerID).Products.Add(item4);
					}
					foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon2 in item4.Addons)
					{
						foreach (AddOnProduct item5 in addon2.Value)
						{
							if (item5.Owner == this)
							{
								item5.Trade(companies[idx]);
								if (companies[idx].Player)
								{
									GetTakeOverData(companies[idx].NetworkPlayerID).Addons.Add(item5);
								}
							}
						}
					}
				}
				idx = (idx + 1) % companies.Count;
			}
			foreach (AddOnProduct item6 in AddOns.ToList())
			{
				if (item6.Parent.Archived)
				{
					item6.Trade(MarketSimulation.Active.PublicDomain);
					continue;
				}
				item6.Trade(companies[idx]);
				if (companies[idx].Player)
				{
					GetTakeOverData(companies[idx].NetworkPlayerID).Addons.Add(item6);
				}
				idx = (idx + 1) % companies.Count;
			}
		}
		else
		{
			List<TechLevel> list4 = Patents.ToList();
			for (int num4 = 0; num4 < list4.Count; num4++)
			{
				list4[num4].TransferPatent(null, time);
			}
			List<SoftwareFramework> list5 = Frameworks.ToList();
			for (int num5 = 0; num5 < list5.Count; num5++)
			{
				list5[num5].Transfer(MarketSimulation.Active.PublicDomain);
			}
			foreach (IGrouping<SoftwareProduct, SoftwareProduct> item7 in (from x in Products
				group x by x.GetLatestSuccessor()).ToList())
			{
				if (item7.All((SoftwareProduct x) => x.Archived))
				{
					foreach (SoftwareProduct item8 in item7)
					{
						item8.Trade(MarketSimulation.Active.PublicDomain, time);
						foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon3 in item8.Addons)
						{
							foreach (AddOnProduct item9 in addon3.Value)
							{
								if (item9.Owner == this)
								{
									item9.Trade(MarketSimulation.Active.PublicDomain);
								}
							}
						}
					}
					continue;
				}
				Company publicDomain = MarketSimulation.Active.PublicDomain;
				foreach (SoftwareProduct item10 in item7)
				{
					item10.Trade(publicDomain, time);
					foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon4 in item10.Addons)
					{
						foreach (AddOnProduct item11 in addon4.Value)
						{
							if (item11.Owner == this)
							{
								item11.Trade(publicDomain);
							}
						}
					}
				}
			}
			foreach (AddOnProduct item12 in AddOns.ToList())
			{
				item12.Trade(MarketSimulation.Active.PublicDomain);
			}
		}
		List<NewStock> list6 = NewStock.ToList();
		for (int num6 = 0; num6 < list6.Count; num6++)
		{
			NewStock newStock = list6[num6];
			TradeStock(this, newStock.Shares, time, 0.0, newStock);
		}
		TransferStock(companies, time, ref idx, broke, true);
		foreach (KeyValuePair<byte, TakeOverData> takeOverDatum in _takeOverData)
		{
			takeOverDatum.Value.Bankrupt = broke;
			if (!NetworkMessaging.SendTakeOverData(ID, takeOverDatum.Value, NetworkMessaging.MessageTarget.Specifically, takeOverDatum.Key))
			{
				GenerateTakeOverMessage(this, takeOverDatum.Value);
			}
		}
		GameSettings.Instance.simulation.RemoveCompany(this);
		GameSettings.Instance.ConferenceController.UnreserveBooth(this);
		GameSettings.Instance.AddBuyout(this, company);
		NetworkPlayerBuyout(((company != null) ? company.Name : null) ?? "", canDisconnect);
		ReleaseTakeOverData();
		NetworkMeta.CheckDirty();
	}

	private static TakeOverData GetTakeOverData(byte c)
	{
		TakeOverData value;
		if (_takeOverData.TryGetValue(c, out value))
		{
			return value;
		}
		return _takeOverData[c] = _takeOverPool.Get();
	}

	private static void ReleaseTakeOverData()
	{
		_takeOverPool.ReleaseAll();
		_takeOverData.Clear();
	}

	public static void GenerateTakeOverMessage(Company c, TakeOverData d)
	{
		if (d.Stocks > 0 || d.Products.Count > 0 || d.Patents > 0 || d.Frameworks.Count > 0 || d.Addons.Count > 0)
		{
			NotificationManager.AddNotification(new BuyoutNotification(c, d.Stocks, d.Patents, d.Products, d.Frameworks, d.Addons, d.Bankrupt));
		}
	}

	public void CleanStock()
	{
		for (int i = 0; i < NewOwnedStock.Count; i++)
		{
			if (NewOwnedStock[i].Seller.Bankrupt)
			{
				NewOwnedStock.RemoveAt(i);
				i--;
			}
		}
	}

	private void ClearStock(SDateTime time)
	{
		int idx = 0;
		TransferStock(null, time, ref idx, false, false);
	}

	private void TransferStock(IList<Company> companies, SDateTime time, ref int idx, bool broke, bool withData)
	{
		if (companies != null)
		{
			List<NewStock> list = NewOwnedStock.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				NewStock newStock = list[i];
				Company company = companies[idx];
				if (company.Player && withData)
				{
					GetTakeOverData(company.NetworkPlayerID).Stocks++;
				}
				bool flag = false;
				for (int j = 0; j < companies.Count; j++)
				{
					if (newStock.Seller.CanOwnStock(company))
					{
						newStock.Seller.TradeStock(company, newStock.Shares, time, broke ? new float?(0f) : ((float?)null), newStock);
						flag = true;
						break;
					}
					idx = (idx + 1) % companies.Count;
					company = companies[idx];
				}
				if (!flag)
				{
					MarketSimulation.Active.FindBuyer(newStock, newStock.Shares, time);
				}
			}
			return;
		}
		List<NewStock> list2 = NewOwnedStock.ToList();
		for (int k = 0; k < list2.Count; k++)
		{
			NewStock newStock2 = list2[k];
			if (newStock2.Seller.TakeOver.HasValue)
			{
				NetworkMessaging.SendBeginTakeover(newStock2.Seller.ID, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
			MarketSimulation.Active.FindBuyer(newStock2, newStock2.Shares, time);
		}
	}

	public double GetPossibleStockWorth()
	{
		if (StockQuarantine <= 0)
		{
			return Math.Max(0.0, (double)(Valuation * 10f) - NewStock.SumSafe((NewStock x) => x.TotalWorth));
		}
		return 0.0;
	}

	public KeyValuePair<uint, double> GetSharesAndPrice(double sum)
	{
		if (sum < 500.0)
		{
			return new KeyValuePair<uint, double>(0u, 0.0);
		}
		if (Shares != 0)
		{
			double shareWorth = GetShareWorth();
			return new KeyValuePair<uint, double>((uint)Utilities.FloorToInt(sum / shareWorth), shareWorth);
		}
		double moneyWithInsurance = GetMoneyWithInsurance();
		double num = sum + moneyWithInsurance;
		double num2 = 100.0;
		int num3 = Utilities.CeilToInt(num / num2);
		double num4 = (double)num3 * num2;
		double num5 = num - num4;
		if (num3 == 0)
		{
			return new KeyValuePair<uint, double>(0u, 0.0);
		}
		num2 += num5 / (double)num3;
		int num6 = Utilities.FloorToInt(moneyWithInsurance / num2);
		if (num6 < 2)
		{
			return new KeyValuePair<uint, double>(0u, 0.0);
		}
		num2 = moneyWithInsurance / (double)num6;
		num3 = Utilities.FloorToInt(sum / num2);
		return new KeyValuePair<uint, double>((uint)num3, num2);
	}

	public void AddLicense(SoftwareProduct product, ILossable owner)
	{
		Licenses.Append(product, owner);
	}

	public void RemoveLicense(SoftwareProduct p, ILossable owner, bool completely = false)
	{
		SHashSet<ILossable> value;
		if (completely)
		{
			Licenses.Remove(p);
		}
		else if (Licenses.TryGetValue(p, out value))
		{
			value.Remove(owner);
			if (value.Count == 0)
			{
				Licenses.Remove(p);
			}
		}
	}

	public void PayForLicenses(SDateTime time)
	{
		foreach (KeyValuePair<SoftwareProduct, SHashSet<ILossable>> license in Licenses)
		{
			if (!license.Key.HasToPay(this))
			{
				continue;
			}
			float num = 0f;
			foreach (ILossable item in license.Value)
			{
				float num2 = item.GetLicenseAmount() * license.Key.GetLicenseCost(Player);
				if (num2 > 0f)
				{
					num += num2;
					item.AddLoss(num2, SoftwareProduct.LossType.Licenses, true);
					item.AddLicenseCost(license.Key, num2);
				}
			}
			MakeTransaction(0f - num, TransactionCategory.Licenses, true, license.Key.Name);
			license.Key.DevCompany.MakeTransaction(num, TransactionCategory.Licenses, true, license.Key.Name, true);
			license.Key.AddToCashflow(0, 0, 0, 0f, num, time);
			if (Bankrupt)
			{
				break;
			}
		}
	}

	public bool CanMakeTransaction(double amount)
	{
		if (!Bankrupt && !double.IsNaN(amount) && !double.IsInfinity(amount))
		{
			if (!(amount >= 0.0))
			{
				return _money + amount >= 0.0;
			}
			return true;
		}
		return false;
	}

	public void AddToCashflow(double amount, TransactionCategory category)
	{
		if (category != TransactionCategory.NA)
		{
			tempCashflow.AddUp(EnumStringer<TransactionCategory>.ToString(category), (float)amount);
		}
	}

	private static void AddToLast(List<float> l, float v, bool set)
	{
		if (l.Count == 0)
		{
			l.Add(v);
		}
		else if (set)
		{
			l[l.Count - 1] = v;
		}
		else
		{
			l[l.Count - 1] += v;
		}
	}

	public void EndDay(SDateTime time, bool justCashflow = false)
	{
		foreach (string key in Cashflow.Keys)
		{
			if (justCashflow)
			{
				if (key.Equals("Balance"))
				{
					AddToLast(Cashflow[key], (float)Money, true);
				}
				else
				{
					AddToLast(Cashflow[key], tempCashflow.GetOrDefault(key, 0f), false);
				}
			}
			else if (key.Equals("Balance"))
			{
				if (IsLocalPlayer)
				{
					Cashflow[key].Add((float)(Money + GameSettings.Instance.Insurance.Money));
				}
				else
				{
					Cashflow[key].Add((float)Money);
				}
			}
			else
			{
				Cashflow[key].Add(tempCashflow.GetOrDefault(key, 0f));
			}
		}
		tempCashflow.Clear();
		if (!justCashflow)
		{
			RefreshValuation();
			EndDayCallback(time);
			if (StockQuarantine > 0)
			{
				StockQuarantine--;
			}
		}
	}

	private void RefreshValuation()
	{
		double num = 0.0;
		for (int i = 0; i < _valuationValues.Length; i++)
		{
			num += Math.Max(StockDefaultPrice, _valuationValues[i]);
		}
		Valuation = (float)num / (float)_valuationValues.Length;
		_valuationOffset = (_valuationOffset + 1) % _valuationValues.Length;
		_valuationValues[_valuationOffset] = 0.0;
	}

	public virtual void EndDayCallback(SDateTime time)
	{
	}

	private string ErrorMessage(string value, TransactionCategory category, string bill)
	{
		if (bill != null)
		{
			return string.Format("Tried to deduct {0} from company {1} in category {2}: {3}", value, Name, EnumStringer<TransactionCategory>.ToString(category), bill);
		}
		return string.Format("Tried to deduct {0} from company {1} in category {2}", value, Name, EnumStringer<TransactionCategory>.ToString(category));
	}

	public void AddTax(TaxReport.TaxType type, double amount)
	{
		if (!DontSync && amount != 0.0)
		{
			NetworkMessaging.SendAddTax(ID, type, amount, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyAddTax(type, amount);
	}

	public void ActuallyAddTax(TaxReport.TaxType type, double amount)
	{
		CurrentTaxReport.AddTax(type, amount);
	}

	public double GetCurrentStockTax()
	{
		double num = 0.0;
		for (int i = 0; i < NewOwnedStock.Count; i++)
		{
			NewStock newStock = NewOwnedStock[i];
			if (newStock.LastTaxValue > 0.0)
			{
				num += newStock.TotalWorth - newStock.LastTaxValue;
			}
		}
		return num;
	}

	public void TurnTaxReport()
	{
		LastTaxReport = CurrentTaxReport;
		CurrentTaxReport = new TaxReport();
	}

	public void FinishTaxReport(int year)
	{
		if (LastTaxReport == null)
		{
			return;
		}
		if (IsLocalPlayer || (NetworkManager.NotConnectedOrHost && !Player))
		{
			float optimization;
			double num = LastTaxReport.FinalValue(out optimization);
			MakeTransaction(0.0 - num, TransactionCategory.Bills, false, "Taxes");
			bool flag = false;
			double num2 = 0.0;
			if (LastTaxReport.ReportProgress < 1f)
			{
				num2 = LastTaxReport.GetCost();
				MakeTransaction(0.0 - num2, TransactionCategory.Bills, true, "TaxReport");
				if (LastTaxReport.IllegalActions && Player)
				{
					flag = GameSettings.Instance.Audit();
				}
			}
			if (!flag && Player)
			{
				string text;
				if (LastTaxReport.ReportProgress < 1f)
				{
					if (num2 > 0.0)
					{
						int workers;
						float salary;
						LastTaxReport.GetWorkersNeeded(out workers, out salary);
						text = ((!((double)salary > num)) ? "UnfinishedTaxReport".Loc(year, num2.Currency(), (optimization > 0f) ? optimization.Currency() : null) : "IgnoredTaxNotification".Loc(num.Currency(), num2.Currency()));
					}
					else
					{
						text = null;
					}
				}
				else
				{
					text = "FinishedTaxReport".Loc(year, (optimization > 0f) ? optimization.Currency() : null);
				}
				if (text != null)
				{
					NotificationManager.AddNotification(text, "Money", NotificationManager.NotificationType.Neutral);
				}
			}
		}
		else if (Player && !LocalPlayer && NetworkManager.IsPlayerOffline(NetworkPlayerID))
		{
			float optimization2;
			double num3 = LastTaxReport.FinalValue(out optimization2);
			MakeTransaction(0.0 - num3, TransactionCategory.Bills, false, "Taxes");
		}
		LastTaxReport = null;
	}

	public void MakeTransaction(double amount, TransactionCategory category, string bill = null, bool valuated = false)
	{
		MakeTransaction(amount, category, TaxReport.TaxType.None, bill, valuated);
	}

	public void MakeTransaction(double amount, TransactionCategory category, bool taxed, string bill = null, bool valuated = false)
	{
		MakeTransaction(amount, category, taxed ? ((amount > 0.0) ? TaxReport.TaxType.Income : TaxReport.TaxType.Operation) : TaxReport.TaxType.None, bill, valuated);
	}

	public void MakeTransaction(double amount, TransactionCategory category, TaxReport.TaxType taxes, string bill = null, bool valuated = false)
	{
		SDateTime time = SDateTime.Now();
		if (!DontSync && amount != 0.0)
		{
			NetworkMessaging.SendMakeTransaction(ID, amount, category, taxes, Player ? bill : null, valuated, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyMakeTransaction(amount, category, taxes, time, bill, valuated);
	}

	public void ActuallyMakeTransaction(double amount, TransactionCategory category, TaxReport.TaxType taxes, SDateTime time, string bill = null, bool valuated = false)
	{
		if (amount == 0.0 || IsInvestor)
		{
			return;
		}
		if (double.IsNaN(amount))
		{
			string message = ErrorMessage("NaN", category, bill);
			if (LineParse.RunningScript)
			{
				throw new Exception(message);
			}
			Debug.LogException(new UnityException(message));
			return;
		}
		if (double.IsInfinity(amount))
		{
			string message2 = ErrorMessage("infinity", category, bill);
			if (LineParse.RunningScript)
			{
				throw new Exception(message2);
			}
			Debug.LogException(new UnityException(message2));
			return;
		}
		if (!Player && !Bankrupt && !CanMakeTransaction(amount) && NetworkManager.NotConnectedOrHost)
		{
			Bankrupt = true;
			if (IsPlayerOwned())
			{
				NotificationManager.AddNotification("SubsidiaryBankruptWarning".LocColor(this), "Skyskraper", NotificationManager.NotificationType.Warning);
				BuyOut(new Company[1] { OwnerCompany }, true, time);
			}
			else
			{
				List<Company> list = GenerateStockCompanyList();
				BuyOut((list == null || list.Count == 0) ? null : list, true, time);
			}
		}
		_money += amount;
		AddToCashflow(amount, category);
		if (taxes != TaxReport.TaxType.None)
		{
			ActuallyAddTax(taxes, amount);
		}
		if (valuated)
		{
			_valuationValues[_valuationOffset] += amount;
		}
		if (bill != null)
		{
			AddToBill(amount, category, bill);
		}
		if (IsLocalPlayer && HUD.Instance != null)
		{
			HUD.Instance.financeWindow.UpdateSheet(true);
		}
	}

	public void AddToBill(double amount, TransactionCategory category, string bill)
	{
		if (!IsLocalPlayer)
		{
			return;
		}
		Dictionary<string, float> value;
		if (!GameSettings.Instance.BillsNext.TryGetValue(category, out value))
		{
			value = new Dictionary<string, float>();
			GameSettings.Instance.BillsNext[category] = value;
		}
		float value2;
		if (value.TryGetValue(bill, out value2))
		{
			double num = (double)value2 + amount;
			if (num == 0.0)
			{
				value.Remove(bill);
			}
			else
			{
				value[bill] = (float)num;
			}
		}
		else
		{
			value[bill] = (float)amount;
		}
	}

	public bool IsSoleStock(Company c)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < NewStock.Count; i++)
		{
			if (NewStock[i].Buyer != this)
			{
				if (NewStock[i].Buyer == c)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
				}
			}
		}
		if (flag)
		{
			return !flag2;
		}
		return false;
	}

	public List<Company> GenerateStockCompanyList()
	{
		if (NewStock.Count == 0)
		{
			return null;
		}
		List<Company> list = new List<Company>();
		if (NewStock.Count == 1)
		{
			NewStock newStock = NewStock[0];
			if (!newStock.Buyer.IsInvestor)
			{
				list.Add(newStock.Buyer);
			}
		}
		else
		{
			double num = 1.0 - GetShare();
			foreach (NewStock item in NewStock.OrderByDescending((NewStock x) => x.Shares))
			{
				if (!item.Buyer.IsInvestor && !(item.Buyer is FounderShareHolder))
				{
					int num2 = Utilities.RoundToInt(item.Percentage / num * 10.0);
					for (int num3 = 0; num3 < num2; num3++)
					{
						list.Add(item.Buyer);
					}
				}
			}
		}
		return list;
	}

	public bool CanBuyOut(Company cmp)
	{
		if (this == cmp || TakeOver.HasValue)
		{
			return false;
		}
		if (cmp.TakeOver.HasValue && cmp.IsSoleStock(this))
		{
			return false;
		}
		NewStock newStock = NewStock.FirstOrDefault((NewStock x) => x.Buyer == cmp);
		if (newStock != null)
		{
			return newStock.Percentage > 0.5;
		}
		return false;
	}

	public double GetBuyOutPrice(Company cmp)
	{
		double num = GetMoneyWithInsurance();
		for (int i = 0; i < NewStock.Count; i++)
		{
			if (NewStock[i].Buyer != cmp)
			{
				num += NewStock[i].TotalWorth;
			}
		}
		return num;
	}

	public override string ToString()
	{
		return Name;
	}

	public string GetActualString()
	{
		return Name;
	}

	public void SimulateFanLoss(SDateTime time)
	{
		if (Fans == 0)
		{
			return;
		}
		foreach (KeyValuePair<SoftwareCategory, SDateTime> item in _lastRelease)
		{
			uint orDefault = _softwarePop.GetOrDefault(item.Key, 0u);
			if (orDefault == 0)
			{
				continue;
			}
			float retention = item.Key.Retention;
			if (!(SDateTime.GetMonths(item.Value, time) > 4f * retention))
			{
				continue;
			}
			float num = ((orDefault < 100) ? ((float)orDefault) : (0.1f * (float)orDefault));
			KeyValuePair<Company, SoftwareCategory> key = new KeyValuePair<Company, SoftwareCategory>(this, item.Key);
			SDateTime value;
			if (Player && num > 1000f && (!GameSettings.Instance.LastFanWarning.TryGetValue(key, out value) || SDateTime.GetMonths(value, SDateTime.Now()) > 12f))
			{
				GameSettings.Instance.LastFanWarning[key] = SDateTime.Now();
				if (LocalPlayer)
				{
					NotificationManager.AddNotification(new SoftwareSupportWane(item.Key));
				}
				else
				{
					NotificationManager.SendNotification(new SoftwareSupportWane(item.Key), NetworkPlayerID);
				}
			}
			num /= (float)GameSettings.DaysPerMonth;
			AddFans(-Mathf.FloorToInt(num), item.Key);
		}
	}

	public virtual void KillCompany()
	{
	}

	public void PayDividends()
	{
		float num = tempCashflow.Where((KeyValuePair<string, float> x) => !x.Key.Equals("Balance") && !x.Key.Equals("Dividends") && !x.Key.Equals("Stocks") && !x.Key.Equals("Loan")).SumSafe((KeyValuePair<string, float> x) => x.Value);
		if (num > 0f)
		{
			for (int num2 = 0; num2 < NewStock.Count; num2++)
			{
				NewStock newStock = NewStock[num2];
				double num3 = (double)num * newStock.Percentage * (double)((newStock.Buyer is FounderShareHolder) ? Options.Difficulty.FounderDividend : 0.2f);
				newStock.Buyer.MakeTransaction(num3, TransactionCategory.Dividends, true, Name);
				MakeTransaction(0.0 - num3, TransactionCategory.Dividends, false, newStock.BuyerName);
				newStock.Payout = (float)num3;
			}
		}
		else
		{
			for (int num4 = 0; num4 < NewStock.Count; num4++)
			{
				NewStock[num4].Payout = 0f;
			}
		}
	}

	public int GetOSSeats(SoftwareProduct os)
	{
		return OSSeats.GetOrDefault(os, 0);
	}

	public void UpdateOSLicenses(Dictionary<SoftwareProduct, int> inUse, bool fromNetwork)
	{
		foreach (KeyValuePair<SoftwareProduct, int> item in inUse)
		{
			UpdateOSLicense(item.Key, item.Value, fromNetwork);
		}
	}

	public void UpdateOSLicense(SoftwareProduct os, int inUse, bool fromNetwork)
	{
		int orDefault = OSSeats.GetOrDefault(os, 0);
		if (inUse > orDefault)
		{
			int num = inUse - orDefault;
			if (!fromNetwork)
			{
				double num2 = (double)(os.Price * (float)num) / (os.SubscriptionBased ? 0.08 : 1.0);
				os.AddToCashflow((!os.SubscriptionBased) ? num : 0, 0, 0, 0f, (float)num2, SDateTime.Now());
				MakeTransaction(0.0 - num2, TransactionCategory.Licenses, true, os.Name);
				os.DevCompany.MakeTransaction(num2, TransactionCategory.Licenses, true, os.Name, true);
			}
			OSSeats.AddUp(os, num);
		}
	}

	public void CancelAllWorkFor(SoftwareProduct product)
	{
		bool flag = false;
		foreach (WorkItem item in WorkItems.ToList())
		{
			MarketingPlan marketingPlan;
			if ((marketingPlan = item as MarketingPlan) != null && marketingPlan.Type == MarketingPlan.TaskType.PostMarket && marketingPlan.TargetProduct == product)
			{
				marketingPlan.Kill();
				flag |= marketingPlan.AutoDev;
				continue;
			}
			SupportWork supportWork;
			if ((supportWork = item as SupportWork) != null && supportWork.TargetProduct == product)
			{
				supportWork.Kill();
				flag |= supportWork.AutoDev;
				continue;
			}
			SoftwarePort softwarePort;
			if ((softwarePort = item as SoftwarePort) != null && softwarePort.Product == product)
			{
				softwarePort.Kill();
			}
			SoftwareWorkItem softwareWorkItem;
			if ((softwareWorkItem = item as SoftwareWorkItem) != null && softwareWorkItem.SequelTo == product)
			{
				softwareWorkItem.Kill();
			}
			SoftwareUpdate softwareUpdate;
			if ((softwareUpdate = item as SoftwareUpdate) != null && softwareUpdate.Target == product)
			{
				softwareUpdate.Kill();
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (AutoDevWorkItem item2 in WorkItems.OfType<AutoDevWorkItem>())
		{
			item2.UpdatePostItems();
		}
	}

	public void CancelAllWorkFor(AddOnProduct product)
	{
		bool flag = false;
		foreach (WorkItem item in WorkItems.ToList())
		{
			MarketingPlan marketingPlan;
			if ((marketingPlan = item as MarketingPlan) != null && marketingPlan.Type == MarketingPlan.TaskType.PostMarket && marketingPlan.TargetProduct == product)
			{
				marketingPlan.Kill();
				flag |= marketingPlan.AutoDev;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (AutoDevWorkItem item2 in WorkItems.OfType<AutoDevWorkItem>())
		{
			item2.UpdatePostItems();
		}
	}

	public float GetTotalCashflow(string category)
	{
		List<float> value;
		if (!Cashflow.TryGetValue(category, out value))
		{
			return 0f;
		}
		return value.SumSafe((float x) => x);
	}

	public void AddWorkItem(WorkItem item)
	{
		lock (WorkItems)
		{
			WorkItems.Add(item);
		}
	}

	public void CreateFounderStocks(Employee[] founders, MarketSimulation sim, int startYear)
	{
		int num = founders.Length + 1;
		Shares = (uint)(Utilities.CeilToInt(Math.Max(num * 100, Money / 100.0) / (double)num) * num);
		SDateTime time = new SDateTime(0, startYear);
		SDateTime expiration = new SDateTime(founders.Length * 5 * 12, startYear);
		for (int i = 0; i < founders.Length; i++)
		{
			FounderShareHolder founderShareHolder = new FounderShareHolder(founders[i], time, sim, expiration);
			NewStock item = new NewStock(this, founderShareHolder, Shares / (uint)num);
			NewStock.Add(item);
			founderShareHolder.NewOwnedStock.Add(item);
		}
		UpdateShare();
	}

	public bool DistributionAcceptedAt(DistributionPlatform p, out float val)
	{
		val = 0f;
		if (IsSigned(p))
		{
			return _playerAcceptRates.TryGetValue(p.Owner, out val);
		}
		return false;
	}

	public void ChangeDistributionAccept(Company c, float val)
	{
		_playerAcceptRates[c] = val;
	}

	public bool IsInterested(DistributionPlatform p)
	{
		if (p.Open || p.Owner == this || !p.HasToPay(this))
		{
			int value;
			if (WantsDistribution.TryGetValue(p.Owner, out value))
			{
				return value >= 0;
			}
			return false;
		}
		return false;
	}

	public void MarkInterested(Company c, bool interested, int quarantine, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			NetworkMessaging.SendRegisterLocalPlayerPlatformQuery(ID, c.ID, interested, quarantine, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		bool num = interested;
		DistributionPlatform distribution = c.Distribution;
		interested = num & (distribution == null || distribution.Open);
		bool flag = false;
		if (interested)
		{
			int value;
			if ((!WantsDistribution.TryGetValue(c, out value) || value != quarantine) && c.IsLocalPlayer)
			{
				flag = true;
				if (c.Distribution != null && c.Distribution.HasToPay(this))
				{
					MarketSimulation.Active.DistributionQueryChange.Add(this);
				}
			}
			WantsDistribution[c] = quarantine;
			if (c.Distribution != null)
			{
				_playerAcceptRates[c] = c.Distribution.GetCut();
				if (c.Distribution.AutoAcceptClients || c == this || _ownerCompany == c.ID)
				{
					SignPlatform(c.Distribution, true);
				}
			}
		}
		else
		{
			_playerAcceptRates.Remove(c);
			int value2;
			if (WantsDistribution.TryGetValue(c, out value2) && value2 >= 0 && c.IsLocalPlayer)
			{
				flag = true;
				if (c.Distribution != null && c.Distribution.HasToPay(this))
				{
					MarketSimulation.Active.DistributionQueryChange.Add(this);
				}
			}
			if (quarantine > 0)
			{
				WantsDistribution[c] = -quarantine;
			}
			else
			{
				WantsDistribution.Remove(c);
			}
		}
		if (flag)
		{
			HUD.Instance.digitalDistributionWindow.UpdateDistributionDeals();
		}
	}

	public bool WantLocalPlayerDistribution()
	{
		return WantsPlayerDistribution(GameSettings.Instance.MyCompany);
	}

	public bool WantsPlayerDistribution(DistributionPlatform p)
	{
		return WantsPlayerDistribution(p.Owner);
	}

	public bool WantsPlayerDistribution(Company c)
	{
		int value;
		if (WantsDistribution.TryGetValue(c, out value))
		{
			return value >= 0;
		}
		return false;
	}

	public bool PlayerDistributionQuarantined(DistributionPlatform p)
	{
		return PlayerDistributionQuarantined(p.Owner);
	}

	public bool PlayerDistributionQuarantined(Company c)
	{
		int value;
		if (WantsDistribution.TryGetValue(c, out value))
		{
			return value < 0;
		}
		return false;
	}
}
