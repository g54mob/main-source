using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DevConsole;
using SINetworking;
using UnityEngine;

[Serializable]
[AltDeprecate("StockFix", typeof(bool))]
public class MarketSimulation
{
	public const double SubscriptionFactor = 0.08;

	public const int SpawnGraceMonths = 6;

	public readonly Dictionary<string, SoftwareType> SoftwareTypes;

	public readonly Dictionary<string, CompanyType> CompanyTypes;

	public readonly Dictionary<string, RandomNameGenerator> RNG;

	public SoftwareType DigitalDistSoft;

	private Dictionary<uint, SoftwareProduct> Products = new Dictionary<uint, SoftwareProduct>();

	[IgnoreNetwork]
	private Dictionary<uint, SoftwareProduct> MockProducts = new Dictionary<uint, SoftwareProduct>();

	private Dictionary<uint, SoftwareProduct> ArchivedProducts = new Dictionary<uint, SoftwareProduct>();

	public List<AddOnProduct> AddOnProducts = new List<AddOnProduct>();

	public Dictionary<uint, SimulatedCompany> Companies = new Dictionary<uint, SimulatedCompany>();

	public Dictionary<string, List<TechLevel>> TechLevels = new Dictionary<string, List<TechLevel>>();

	public Dictionary<string, Dictionary<SoftwareCategory, int>> MarketTechLevels = new Dictionary<string, Dictionary<SoftwareCategory, int>>();

	public Dictionary<string, float> TechComplexity = new Dictionary<string, float>();

	public List<SoftwareFramework> Frameworks = new List<SoftwareFramework>();

	public HashSet<Employee> FreeLeads = new HashSet<Employee>();

	private EventList<Company> AllCompanies = new EventList<Company>();

	private Dictionary<uint, Company> AllCompanyDict = new Dictionary<uint, Company>();

	public static int MagicFactor = 126543;

	public static int MagicRepFactor = 500000;

	public static uint Population = 145613576u;

	public static uint FanPopulation = 9100848u;

	public static uint FollowerPopulation = 73576u;

	public static double HypeFactor = 0.05;

	public readonly bool SimulateCompanies;

	private SDateTime LastCache = new SDateTime(-1, -1);

	private SDateTime LastFCache = new SDateTime(-1, -1);

	[AltWasFloat(0)]
	private Dictionary<SoftwareCategory, double[]> CachedMarketQuality = new Dictionary<SoftwareCategory, double[]>();

	[AltWasFloat(0)]
	private Dictionary<uint, Dictionary<SoftwareCategory, double[]>> PerOSQuality = new Dictionary<uint, Dictionary<SoftwareCategory, double[]>>();

	private Dictionary<SoftwareCategory, float> Awareness = new Dictionary<SoftwareCategory, float>();

	[AltWasFloat(0)]
	private Dictionary<SoftwareCategory, double> NewCachedFeatures = new Dictionary<SoftwareCategory, double>();

	public Dictionary<SoftwareCategory, SHashSet<SoftwareProduct>> MissingOSSupport;

	[AltWasFloat(0)]
	private Dictionary<SoftwareCategory, double[]> SubMarkets = new Dictionary<SoftwareCategory, double[]>();

	private Dictionary<SoftwareCategory, float> _currentIdealMarketPrice = new Dictionary<SoftwareCategory, float>();

	private Dictionary<SoftwareAddOn, float> _currentIdealAddonPrice = new Dictionary<SoftwareAddOn, float>();

	public EventList<DistributionPlatform> DistributionPlatforms = new EventList<DistributionPlatform>();

	public List<MarketEvent> MarketEvents = new List<MarketEvent>();

	[NonSerialized]
	public HashSet<Company> DistributionQueryChange = new HashSet<Company>();

	private uint nextID = 1u;

	[NonSerialized]
	private List<uint> _networkIDs = new List<uint>();

	[NonSerialized]
	private List<uint> _networkFrameIDs = new List<uint>();

	private uint nextCompanyID = 1u;

	private uint nextDealID = 1u;

	private uint nextFrameworkID = 1u;

	public int Layoffs;

	private float _distMaxDevTime = -1f;

	public Dictionary<string, Dictionary<string, int>> ConsumerBuckets;

	private bool NewStockFix = true;

	public Company PrivateInvestors;

	public Company PublicDomain;

	public System.Random Random = new System.Random();

	private Dictionary<CompanyType, int> _spawnGrace = new Dictionary<CompanyType, int>();

	[NonSerialized]
	public bool RaiseEvents = true;

	[NonSerialized]
	private Dictionary<string, int> ManufacturingAtlas;

	[NonSerialized]
	public Texture2D ManufacturingIcons;

	[NonSerialized]
	public bool ManufacturingIconsInitialized;

	[NonSerialized]
	public int ManAtlasWidth = 1;

	[NonSerialized]
	public int ManAtlasHeight = 1;

	private Dictionary<string, byte[]> _serializedAtlas;

	public const int AtlasImgSize = 128;

	public static double[] TimeFactor = new double[12]
	{
		1.028506787, 0.939027141, 0.989777805, 1.045073759, 1.049443767, 1.004892777, 0.948164321, 0.928002915, 0.982416459, 1.115938637,
		1.276891317, 1.334646951
	};

	public static double[] PhysicalVsDigital = new double[52]
	{
		1.0, 0.99, 0.99, 0.99, 0.99, 0.99, 0.98, 0.98, 0.98, 0.98,
		0.97, 0.97, 0.97, 0.96, 0.96, 0.96, 0.95, 0.95, 0.95, 0.94,
		0.94, 0.94, 0.93, 0.93, 0.92, 0.92, 0.92, 0.91, 0.91, 0.9,
		0.9, 0.89, 0.88, 0.88, 0.87, 0.86, 0.86, 0.85, 0.83, 0.8,
		0.71, 0.68, 0.59, 0.53, 0.48, 0.44, 0.43, 0.42, 0.41, 0.41,
		0.4, 0.39
	};

	public List<float> PlayerDigitalShare = new List<float>
	{
		0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f
	};

	public static float DistributionStandardCut = 0.3f;

	public static float PhysicalSubscriptionCutFactor = 12f;

	public static float PhysicalCopyPrice = 2f;

	public static float HardwareCopyPriceFactor = 2f;

	private static int MaxPresim = 50;

	[NonSerialized]
	private HashSet<string> OSBacked;

	[NonSerialized]
	private Dictionary<uint, SoftwareType> _swCache;

	private static double[] _defaultSubMarket = new double[3]
	{
		1.0 / 3.0,
		1.0 / 3.0,
		1.0 / 3.0
	};

	private static double[] _fullQuality = new double[3] { 1.0, 1.0, 1.0 };

	public static FloatInterpolator PriceFactEval = new FloatInterpolator(0.1f, 0.14f, 0.18f, 0.24f, 0.31f, 0.42f, 0.6f, 0.8f, 0.92f, 1.05f, 1.12f, 1.18f, 1.21f, 1.23f, 1.24f, 1.23f, 1.21f, 1.18f, 1.12f, 1.05f, 1f, 0.9f, 0.8f, 0.65f, 0.5f, 0.38f, 0.27f, 0.2f, 0.16f, 0.12f, 0.1f, 0.09f, 0.08f, 0.07f, 0.06f, 0.05f, 0.04f, 0.03f, 0.02f, 0.01f, 0f);

	private static List<SimulatedCompany> AICompCache = new List<SimulatedCompany>();

	[NonSerialized]
	private ScriptSystem.SaleScope _saleScope = new ScriptSystem.SaleScope();

	[NonSerialized]
	private Dictionary<string, SoftwareProduct> _osPortCache = new Dictionary<string, SoftwareProduct>();

	private static List<Employee> _leadCache = new List<Employee>();

	[NonSerialized]
	private Dictionary<uint, uint> _distributionSums = new Dictionary<uint, uint>();

	private static List<Company> _rejectDistCache = new List<Company>();

	private static List<Company> _acceptDistCache = new List<Company>();

	[NonSerialized]
	private Dictionary<byte, Dictionary<uint, float>> _distributionLoads = new Dictionary<byte, Dictionary<uint, float>>();

	[NonSerialized]
	private Dictionary<uint, float> _fullDistributionLoads = new Dictionary<uint, float>();

	private static readonly HashSet<SoftwareProduct> CoverageCache = new HashSet<SoftwareProduct>();

	private static readonly HashSet<SoftwareProduct> CompatibleCache = new HashSet<SoftwareProduct>();

	public static MarketSimulation Active
	{
		get
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				return GameSettings.Instance.simulation;
			}
			return null;
		}
	}

	public int CompanyCount
	{
		get
		{
			return AllCompanies.Count;
		}
	}

	public event EventHandler<SoftwareProduct> OnProductReleased;

	public event EventHandler<SoftwareProduct> OnProductRemoved;

	public event EventHandler<AddOnProduct> OnAddOnReleased;

	public event EventHandler<AddOnProduct> OnAddOnRemoved;

	public event EventHandler<Company> OnCompanyFounded;

	public event EventHandler<Company> OnCompanyClosed;

	public event EventHandler<TechLevel> OnTechResearched;

	public event EventHandler<SoftwareFramework> OnFrameworkReleased;

	public SDateTime? GetResearchETA(string spec, int year)
	{
		SDateTime? result = null;
		lock (Companies)
		{
			foreach (SimulatedCompany value in Companies.Values)
			{
				if (value.SpecResearch != null && value.SpecResearch.Patent == null && value.SpecResearch.Year >= year && value.SpecResearch.Spec.Equals(spec) && (!result.HasValue || value.SpecResearch.ETA < result.Value))
				{
					result = value.SpecResearch.ETA;
				}
			}
			return result;
		}
	}

	public int GetAIResearching(string spec)
	{
		int num = 0;
		foreach (SimulatedCompany value in Companies.Values)
		{
			if (value.SpecResearch != null && value.SpecResearch.Patent == null && value.SpecResearch.Spec.Equals(spec))
			{
				num++;
			}
		}
		return num;
	}

	public void InitializeAtlas()
	{
		if (ManufacturingIconsInitialized)
		{
			return;
		}
		Dictionary<string, Texture2D> dictionary = ObjectDatabase.Instance.DefaultManufacuringSprites.Concat(GameData.InstalledDLC.Values.SelectMany((DLCObject x) => x.ManufacturingIcons)).ToDictionary((Texture2D x) => x.name, (Texture2D x) => x);
		List<Texture2D> list = new List<Texture2D>();
		if (_serializedAtlas != null)
		{
			foreach (KeyValuePair<string, byte[]> serializedAtla in _serializedAtlas)
			{
				try
				{
					Texture2D texture2D = new Texture2D(128, 128, TextureFormat.ARGB32, false);
					byte[] value = serializedAtla.Value;
					texture2D.LoadImage(value);
					texture2D.Apply(false);
					dictionary[serializedAtla.Key] = texture2D;
					list.Add(texture2D);
				}
				catch (Exception message)
				{
					Debug.Log(message);
				}
			}
		}
		else
		{
			_serializedAtlas = new Dictionary<string, byte[]>();
			HashSet<string> ignore = new HashSet<string>();
			foreach (SoftwareType value2 in SoftwareTypes.Values)
			{
				foreach (SoftwareCategory value3 in value2.Categories.Values)
				{
					if (value3.Hardware)
					{
						InitIconsForManufacturing(value3.Manufacturing, dictionary, ignore, list);
					}
				}
				foreach (SoftwareAddOn value4 in value2.AddOns.Values)
				{
					if (value4.Hardware)
					{
						InitIconsForManufacturing(value4.Manufacturing, dictionary, ignore, list);
					}
				}
			}
		}
		CreateAtlas(dictionary);
		InitializeAtlasIndices();
		for (int num = 0; num < list.Count; num++)
		{
			UnityEngine.Object.Destroy(list[num]);
		}
		ObjectDatabase.Instance.HardwareAtlasMaterial.mainTexture = ManufacturingIcons;
		ManufacturingIconsInitialized = true;
	}

	private void InitIconsForManufacturing(Manufacturing m, Dictionary<string, Texture2D> icons, HashSet<string> ignore, List<Texture2D> destroy)
	{
		for (int i = 0; i < m.Components.Length; i++)
		{
			HardwareComponent hardwareComponent = m.Components[i];
			if (hardwareComponent.Thumbnail == null || hardwareComponent.Texture == null || icons.ContainsKey(hardwareComponent.Thumbnail) || ignore.Contains(hardwareComponent.Thumbnail))
			{
				continue;
			}
			try
			{
				Texture2D texture2D = new Texture2D(128, 128, TextureFormat.ARGB32, false);
				destroy.Add(texture2D);
				byte[] array = File.ReadAllBytes(hardwareComponent.Texture);
				texture2D.LoadImage(array);
				texture2D.Apply(false);
				if (texture2D.height != 128 || texture2D.width != 128)
				{
					string text = hardwareComponent.Thumbnail + " is not 128x128 pixels and will not be loaded";
					DevConsole.Console.LogWarning(text);
					Debug.Log(text);
					ignore.Add(hardwareComponent.Thumbnail);
				}
				else
				{
					icons[hardwareComponent.Thumbnail] = texture2D;
					_serializedAtlas[hardwareComponent.Thumbnail] = array;
				}
			}
			catch (Exception message)
			{
				Debug.Log(message);
				hardwareComponent.Thumbnail = null;
			}
		}
	}

	private void CreateAtlas(Dictionary<string, Texture2D> icons)
	{
		ManAtlasWidth = Mathf.NextPowerOfTwo(Mathf.CeilToInt(Mathf.Sqrt(icons.Count)));
		ManAtlasHeight = ManAtlasWidth;
		ManufacturingIcons = new Texture2D(ManAtlasWidth * 128, ManAtlasHeight * 128, TextureFormat.ARGB32, false);
		ManufacturingAtlas = new Dictionary<string, int>();
		int num = 0;
		foreach (KeyValuePair<string, Texture2D> icon in icons)
		{
			int num2 = num % ManAtlasWidth;
			int num3 = num / ManAtlasWidth;
			Graphics.CopyTexture(icon.Value, 0, 0, 0, 0, 128, 128, ManufacturingIcons, 0, 0, num2 * 128, num3 * 128);
			ManufacturingAtlas[icon.Key] = num;
			num++;
		}
		ManufacturingIcons.Apply(false);
		ManufacturingIcons.Compress(true);
	}

	public void DestroyAtlas()
	{
		if (ManufacturingIcons != null)
		{
			UnityEngine.Object.Destroy(ManufacturingIcons);
		}
	}

	public int GetManufacturingIndex(string icon)
	{
		if (ManufacturingAtlas == null)
		{
			return 0;
		}
		return ManufacturingAtlas.GetOrDefault(icon, 0);
	}

	private void InitializeAtlasIndices()
	{
		int defaultValue = ManufacturingAtlas["Unknown"];
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				if (value2.Hardware)
				{
					for (int i = 0; i < value2.Manufacturing.Components.Length; i++)
					{
						HardwareComponent hardwareComponent = value2.Manufacturing.Components[i];
						hardwareComponent.AtlasIndex = ManufacturingAtlas.GetOrDefault(hardwareComponent.Thumbnail ?? hardwareComponent.BuiltInThumbnail, defaultValue);
					}
				}
			}
			foreach (SoftwareAddOn value3 in value.AddOns.Values)
			{
				if (value3.Hardware)
				{
					for (int j = 0; j < value3.Manufacturing.Components.Length; j++)
					{
						HardwareComponent hardwareComponent2 = value3.Manufacturing.Components[j];
						hardwareComponent2.AtlasIndex = ManufacturingAtlas.GetOrDefault(hardwareComponent2.Thumbnail ?? hardwareComponent2.BuiltInThumbnail, defaultValue);
					}
				}
			}
		}
	}

	public static double GetPhysicalVsDigital(SDateTime time)
	{
		int num = Mathf.Max(0, time.RealYear - 1970);
		if (num >= PhysicalVsDigital.Length - 1)
		{
			return PhysicalVsDigital[PhysicalVsDigital.Length - 1];
		}
		double num2 = ((double)time.Month + (double)time.Day / (double)GameSettings.DaysPerMonth) / 12.0;
		return PhysicalVsDigital[num + 1] * num2 + PhysicalVsDigital[num] * (1.0 - num2);
	}

	public bool IsOSBacked(string spec)
	{
		if (OSBacked == null)
		{
			OSBacked = new HashSet<string>();
			foreach (SpecFeature item in SoftwareTypes["Operating System"].Features.Values.OfType<SpecFeature>())
			{
				OSBacked.Add(item.Spec);
			}
		}
		return OSBacked.Contains(spec);
	}

	public IEnumerable<Company> GetAllCompanies()
	{
		for (int i = 0; i < AllCompanies.Count; i++)
		{
			yield return AllCompanies[i];
		}
	}

	public IEnumerable<Company> GetPlayerCompanies()
	{
		for (int i = 0; i < AllCompanies.Count; i++)
		{
			if (AllCompanies[i].Player)
			{
				yield return AllCompanies[i];
			}
		}
	}

	public Company GetPlayerCompany(byte playerID)
	{
		for (int i = 0; i < AllCompanies.Count; i++)
		{
			if (AllCompanies[i].Player && AllCompanies[i].NetworkPlayerID == playerID)
			{
				return AllCompanies[i];
			}
		}
		return null;
	}

	public void EndDay(SDateTime time, Company exempt = null)
	{
		for (int i = 0; i < AllCompanies.Count; i++)
		{
			Company company = AllCompanies[i];
			if (company != exempt)
			{
				if (!NetworkManager.IsClient)
				{
					company.PayDividends();
				}
				if (company.IsLocalPlayer || (NetworkManager.NotConnectedOrHost && !company.Player))
				{
					company.PayForLicenses(time);
				}
			}
		}
		for (int j = 0; j < AllCompanies.Count; j++)
		{
			Company company2 = AllCompanies[j];
			if (company2 != exempt)
			{
				if (time.Month == 0)
				{
					company2.TurnTaxReport();
				}
				else if (time.Month == 3)
				{
					company2.FinishTaxReport(time.RealYear - 1);
				}
				company2.EndDay(time);
			}
		}
		if (!NetworkManager.IsHostingPlayers)
		{
			return;
		}
		Dictionary<uint, Dictionary<uint, float>> dictionary = new Dictionary<uint, Dictionary<uint, float>>();
		for (int k = 0; k < AllCompanies.Count; k++)
		{
			Company company3 = AllCompanies[k];
			for (int l = 0; l < company3.NewStock.Count; l++)
			{
				NewStock newStock = company3.NewStock[l];
				if (newStock.Buyer != company3 && newStock.Payout > 0f)
				{
					dictionary.GetOrAdd(company3.ID, (uint x) => new Dictionary<uint, float>())[newStock.Buyer.ID] = newStock.Payout;
				}
			}
		}
		NetworkMessaging.SendDividendStats(dictionary, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public SimulatedCompany FindPublisher(Company client, SoftwareCategory cat, float funding, bool osEx)
	{
		return Companies.Values.Where((SimulatedCompany x) => !x.IsSubsidiary() && (x.WillPublishPlayer || !client.LocalPlayer) && (double)funding < x.Money * 0.10000000149011612 && (!osEx || x.Type.OSSupport(cat.Parent))).MaxInstance((SimulatedCompany x) => x.GetReputation(cat));
	}

	public void RemoveMock(SoftwareProduct p)
	{
		MockProducts.Remove(p.ID);
	}

	public void AddProduct(SoftwareProduct p, bool mock)
	{
		if (mock)
		{
			lock (Products)
			{
				MockProducts[p.ID] = p;
				return;
			}
		}
		lock (Products)
		{
			Products[p.ID] = p;
		}
		UpdateMarketTechOutdates(p);
		if (RaiseEvents && this.OnProductReleased != null)
		{
			this.OnProductReleased(this, p);
		}
		NetworkMeta.CheckDirty();
		if (p.Framework != null && p.Framework.Owner != null && p.DevCompany != null && p.Framework.Owner.IsLocalPlayer && !p.DevCompany.IsLocalPlayer)
		{
			NotificationManager.AddNotification(new ProductDetailNotification(p, "FrameworkRelease".LocColor(p), "SoftwarePlus", NotificationManager.NotificationType.Good));
		}
	}

	public void UpgradeFromMock(SoftwareProduct p)
	{
		SoftwareProduct product = GetProduct(p.ID, true);
		if (product != null && product.IsMock)
		{
			product.MockSucceeded = p;
			product.MockWork = null;
			MockProducts.Remove(p.ID);
		}
		AddProduct(p, false);
	}

	public void ProductUpdated(SoftwareProduct p)
	{
		UpdateMarketTechOutdates(p);
	}

	public void AddAddOn(AddOnProduct add)
	{
		AddOnProducts.Add(add);
		if (RaiseEvents && this.OnAddOnReleased != null)
		{
			this.OnAddOnReleased(this, add);
		}
	}

	private void UpdateMarketTechOutdates(SoftwareProduct p)
	{
		foreach (KeyValuePair<string, TechLevel> techLevel2 in p.TechLevels)
		{
			Dictionary<SoftwareCategory, int> dictionary = MarketTechLevels[techLevel2.Key];
			int orDefault = dictionary.GetOrDefault(p.Category, 0);
			if (techLevel2.Value.Year <= orDefault)
			{
				continue;
			}
			dictionary[p.Category] = techLevel2.Value.Year;
			List<TechLevel> list = TechLevels[techLevel2.Key];
			int num = 1;
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				TechLevel techLevel = list[num2];
				if (techLevel.Year < techLevel2.Value.Year)
				{
					techLevel.MarketOutdates[p.Category] = num;
					techLevel.RefreshRelevancy(p.Category);
					num++;
				}
			}
		}
	}

	public SoftwareProduct GetProduct(uint ID, bool withMock, bool threaded = false, bool distribution = false)
	{
		if (ID == 0)
		{
			return null;
		}
		if (threaded)
		{
			lock (Products)
			{
				return SubGetProduct(ID, withMock, distribution);
			}
		}
		return SubGetProduct(ID, withMock, distribution);
	}

	public float GetDistributionMaxDevTime()
	{
		if (_distMaxDevTime < 0f)
		{
			CalculateMaxDistDevTime();
		}
		return _distMaxDevTime;
	}

	private void CalculateMaxDistDevTime()
	{
		if (DistributionPlatforms.Count == 0)
		{
			SoftwareCategory cat = DigitalDistSoft.Categories.Values.First();
			Dictionary<string, TechLevel> tech = TechLevels.ToDictionary((KeyValuePair<string, List<TechLevel>> x) => x.Key, (KeyValuePair<string, List<TechLevel>> x) => x.Value.Last());
			_distMaxDevTime = DigitalDistSoft.Features.Values.Where((FeatureBase x) => x.IsUnlocked(tech, cat)).SumSafe((FeatureBase x) => x.DevTime);
			return;
		}
		_distMaxDevTime = DistributionPlatforms.MaxSafe((DistributionPlatform x) => x.Software.Features.SumSafe((FeatureBase z) => z.DevTime));
	}

	private SoftwareProduct SubGetProduct(uint ID, bool withMock, bool distribution)
	{
		if (ID == 0)
		{
			return null;
		}
		SoftwareProduct value;
		if (Products.TryGetValue(ID, out value))
		{
			return value;
		}
		if (withMock && MockProducts.TryGetValue(ID, out value))
		{
			return value;
		}
		if (ArchivedProducts.TryGetValue(ID, out value))
		{
			return value;
		}
		if (!distribution)
		{
			return null;
		}
		DistributionPlatform distributionPlatform = DistributionPlatforms.FirstOrDefault((DistributionPlatform x) => x.Software.ID == ID);
		if (distributionPlatform == null)
		{
			return null;
		}
		return distributionPlatform.Software;
	}

	public IEnumerable<SoftwareProduct> GetAllProducts(bool archived)
	{
		foreach (SoftwareProduct value in Products.Values)
		{
			yield return value;
		}
		if (!archived)
		{
			yield break;
		}
		foreach (SoftwareProduct value2 in ArchivedProducts.Values)
		{
			yield return value2;
		}
	}

	public IEnumerable<SoftwareProduct> GetMockProducts()
	{
		foreach (SoftwareProduct value in MockProducts.Values)
		{
			yield return value;
		}
	}

	public IEnumerable<SoftwareProduct> GetProductsWithMock(bool archived)
	{
		foreach (SoftwareProduct value in Products.Values)
		{
			yield return value;
		}
		if (archived)
		{
			foreach (SoftwareProduct value2 in ArchivedProducts.Values)
			{
				yield return value2;
			}
		}
		foreach (SoftwareProduct value3 in MockProducts.Values)
		{
			yield return value3;
		}
	}

	public void BindCompanyUpdate(EventList<object> target)
	{
		AllCompanies.OnChange = delegate
		{
			AllCompanies.Update(target);
		};
	}

	public MarketSimulation(bool simulate, SDateTime time, Dictionary<string, SoftwareType> softwareTypes, Dictionary<string, CompanyType> companyTypes, Dictionary<string, RandomNameGenerator> rng)
	{
		SoftwareTypes = softwareTypes;
		CompanyTypes = companyTypes;
		RNG = rng;
		SimulateCompanies = simulate;
		InitOSSupport();
		if (NetworkManager.NotConnectedOrHost)
		{
			GenerateTechLevels(time.Year, time);
		}
		InitializeSubmarkets();
		NewStockFix = false;
		PrivateInvestors = new Company("Private investors", 10000000000.0, default(SDateTime), this)
		{
			DontSync = true
		};
		PublicDomain = new Company("PublicDomain".Loc(), 10000000000.0, default(SDateTime), this)
		{
			DontSync = true
		};
		PrivateInvestors.ForceBuyStocksFrom = true;
		DigitalDistSoft = GameData.DigitalDistributionPlatform;
		uint num = 2u;
		foreach (KeyValuePair<string, SoftwareType> softwareType in softwareTypes)
		{
			softwareType.Value.UpdateID(num);
			num++;
		}
	}

	public SoftwareType GetSoftwareType(uint id)
	{
		if (_swCache == null)
		{
			_swCache = SoftwareTypes.Values.ToDictionary((SoftwareType x) => x.ID, (SoftwareType x) => x);
			_swCache[DigitalDistSoft.ID] = DigitalDistSoft;
		}
		return _swCache.GetOrNull(id);
	}

	public void FixMarketRecognition()
	{
		foreach (Company allCompany in AllCompanies)
		{
			allCompany.FixMarketRecognition();
		}
	}

	public void FixHardwareDependencies()
	{
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				if (value2.Hardware)
				{
					value2.Manufacturing.FixDependencies();
				}
			}
		}
	}

	public void FixStocks()
	{
		if (PublicDomain == null)
		{
			PublicDomain = new Company("PublicDomain".Loc(), 10000000000.0, default(SDateTime), this);
		}
		if (NewStockFix)
		{
			if (PrivateInvestors == null)
			{
				PrivateInvestors = new Company("Private investors", 10000000000.0, default(SDateTime), this);
			}
			Dictionary<Company, List<KeyValuePair<Company, float>>> dictionary = new Dictionary<Company, List<KeyValuePair<Company, float>>>();
			foreach (Company allCompany in GetAllCompanies())
			{
				allCompany.Stocks = null;
				if (allCompany.OwnedStock.Count > 0)
				{
					for (int i = 0; i < allCompany.OwnedStock.Count; i++)
					{
						Stock stock = allCompany.OwnedStock[i];
						if (stock.Target != allCompany.ID)
						{
							dictionary.Append(stock.TargetCompany, new KeyValuePair<Company, float>(allCompany, stock.CurrentWorth));
						}
					}
				}
				allCompany.OwnedStock = null;
			}
			foreach (KeyValuePair<Company, List<KeyValuePair<Company, float>>> item2 in dictionary)
			{
				double moneyWithInsurance = item2.Key.GetMoneyWithInsurance(false);
				item2.Key.Shares = (uint)(item2.Key.GetMoneyWithInsurance(false) / 100.0);
				if (item2.Key.Shares < item2.Value.Count + 1)
				{
					item2.Key.Shares = (uint)(item2.Value.Count + 1);
				}
				foreach (IGrouping<Company, KeyValuePair<Company, float>> item3 in from x in item2.Value
					group x by x.Key)
				{
					uint num = (uint)((double)item2.Key.Shares * ((double)item3.SumSafe((KeyValuePair<Company, float> x) => x.Value) / moneyWithInsurance));
					if (num == 0)
					{
						num = 1u;
					}
					NewStock item = new NewStock(item2.Key, item3.Key, num);
					item2.Key.NewStock.Add(item);
					item3.Key.NewOwnedStock.Add(item);
				}
				item2.Key.UpdateShare();
			}
			NewStockFix = false;
		}
		PrivateInvestors.ForceBuyStocksFrom = true;
		if (DigitalDistSoft != null)
		{
			return;
		}
		DigitalDistSoft = GameData.DigitalDistributionPlatform;
		SDateTime time = SDateTime.Now();
		int num2 = 0;
		foreach (SimulatedCompany item4 in Companies.Values.OrderByDescending((SimulatedCompany x) => x.Money))
		{
			item4.Distribution = CreatePlatform(item4, item4.GenerateDistributionPlatform(time, null), DistributionPlatform.AcceptableCut(0.25f));
			num2++;
			if (num2 >= 4)
			{
				break;
			}
		}
	}

	private void GenerateTechLevels(int year, SDateTime time)
	{
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			foreach (FeatureBase value2 in value.Features.Values)
			{
				TechComplexity.AddUp(value2.Spec, value2.DevTime);
			}
		}
		float num = TechComplexity.Max((KeyValuePair<string, float> x) => x.Value);
		foreach (string item in TechComplexity.Keys.ToList())
		{
			TechComplexity[item] /= num;
		}
		foreach (string key in TechComplexity.Keys)
		{
			AddTechLevel(key, year, time, false);
			MarketTechLevels[key] = new Dictionary<SoftwareCategory, int>();
		}
	}

	public float GetRoyalty(string spec)
	{
		return TechComplexity[spec] * 0.05f;
	}

	public float GetTechMonths(string spec)
	{
		return TechComplexity[spec].MapRange(0f, 1f, 12f, 48f);
	}

	public TechLevel AddTechLevel(string spec, int year, SDateTime time, bool raiseEvent = true)
	{
		NetworkMessaging.SendAddTechLevel(spec, year, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		TechLevel orDefault = TechLevels.GetOrDefault(spec, (List<TechLevel> x) => x.Last());
		if (orDefault != null && orDefault.Year >= year)
		{
			if (orDefault.Year == year)
			{
				orDefault.CanPatent = false;
			}
			return null;
		}
		TechLevel techLevel = ActuallyAddTechLevel(spec, year, time);
		if (RaiseEvents && raiseEvent && this.OnTechResearched != null)
		{
			this.OnTechResearched(this, techLevel);
		}
		return techLevel;
	}

	public TechLevel ActuallyAddTechLevel(string spec, int year, SDateTime time)
	{
		TechLevel techLevel = new TechLevel(spec, year, GetRoyalty(spec));
		List<TechLevel> list = TechLevels.GetOrNull(spec);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].CanPatent = false;
				list[i].Outdates++;
			}
		}
		else
		{
			list = new List<TechLevel>();
			TechLevels[spec] = list;
		}
		list.Add(techLevel);
		NetworkMeta.CheckDirty();
		MarketEvents.Add(new MarketEvent(MarketEvent.EventType.TechResearch, time, spec, (uint)(1900 + year)));
		return techLevel;
	}

	public IEnumerable<MarketEvent> GetRelevantTechEvents(Dictionary<string, TechLevel> techs, SDateTime start, SDateTime end)
	{
		ushort st = MarketEvent.ConvertDate(start);
		ushort ed = MarketEvent.ConvertDate(end);
		for (int i = 0; i < MarketEvents.Count; i++)
		{
			MarketEvent marketEvent = MarketEvents[i];
			if (marketEvent.Type == MarketEvent.EventType.TechResearch && marketEvent.DateInt >= st && marketEvent.DateInt <= ed && techs.ContainsKey(marketEvent.Desc[0]))
			{
				yield return marketEvent;
			}
		}
	}

	public TechLevel GetLatestTech(string spec, SDateTime time, SoftwareCategory cat, Company c)
	{
		List<TechLevel> list = TechLevels[spec];
		if (list.Count > 1)
		{
			int num = ((c == null) ? int.MaxValue : c.GetLatestResearch(spec, list[list.Count - 2].Year));
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				TechLevel techLevel = list[num2];
				if ((cat == null || !cat.LagBehind.HasValue || techLevel.Year < time.Year - cat.LagBehind.Value) && techLevel.Year <= num)
				{
					return techLevel;
				}
			}
		}
		return list[0];
	}

	private void InitializeSubmarkets()
	{
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			if (value.OneClient)
			{
				continue;
			}
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				SubMarkets[value2] = value2.SubmarketEq.ToArray();
			}
		}
	}

	private void PullMarket(double[] market, double[] target, float t)
	{
		market[0] = Utilities.Lerp(market[0], target[0], t, true);
		market[1] = Utilities.Lerp(market[1], target[1], t, true);
		market[2] = Utilities.Lerp(market[2], target[2], t, true);
	}

	private void PullSubmarkets(SDateTime time)
	{
		foreach (KeyValuePair<SoftwareCategory, double[]> subMarket in SubMarkets)
		{
			PullMarket(subMarket.Value, subMarket.Key.SubmarketEq, 0.01f);
		}
		foreach (KeyValuePair<uint, SoftwareProduct> product in Products)
		{
			SoftwareProduct value = product.Value;
			List<int> unitSales = value.GetUnitSales(false);
			double[] value2;
			if (SubMarkets.TryGetValue(value.Category, out value2) && !value.InHouse && unitSales.Count > 0)
			{
				float t = (float)(unitSales.Last() + value.GetUnitSales(true).Last()) / ((float)Population * value.Category.Popularity);
				PullMarket(value2, value.Submarkets, t);
			}
		}
		foreach (KeyValuePair<SoftwareCategory, double[]> subMarket2 in SubMarkets)
		{
			double[] value3 = subMarket2.Value;
			double num = value3[0] + value3[1] + value3[2];
			value3[0] /= num;
			value3[1] /= num;
			value3[2] /= num;
			if (time.Day == 0)
			{
				subMarket2.Key.StoreHistory(time);
			}
		}
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendUpdateSubMarkets(SubMarkets.ToDictionary((KeyValuePair<SoftwareCategory, double[]> x) => new KeyValuePair<uint, uint>(x.Key.Parent.ID, x.Key.ID), (KeyValuePair<SoftwareCategory, double[]> x) => x.Value), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public void RefreshMarkets(Dictionary<KeyValuePair<uint, uint>, double[]> submarkets, SDateTime time)
	{
		foreach (KeyValuePair<SoftwareCategory, double[]> subMarket in SubMarkets)
		{
			double[] array = submarkets[new KeyValuePair<uint, uint>(subMarket.Key.Parent.ID, subMarket.Key.ID)];
			subMarket.Value[0] = array[0];
			subMarket.Value[1] = array[1];
			subMarket.Value[2] = array[2];
			subMarket.Key.StoreHistory(time);
		}
	}

	public double[] GetSubMarket(SoftwareCategory sw)
	{
		return SubMarkets.GetOrNull(sw) ?? _defaultSubMarket;
	}

	private void InitOSSupport()
	{
		if (MissingOSSupport != null)
		{
			return;
		}
		MissingOSSupport = new Dictionary<SoftwareCategory, SHashSet<SoftwareProduct>>();
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			if (!value.OSSpecific)
			{
				continue;
			}
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				if (!value2.Hidden)
				{
					MissingOSSupport[value2] = new SHashSet<SoftwareProduct>();
				}
			}
		}
	}

	public void AddMissingOSSupport(SoftwareProduct os, SDateTime time)
	{
		if (!os.FairPrice(time))
		{
			return;
		}
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			if (!value.OSSpecific || !value.SupportsOS(os.Category.Name))
			{
				continue;
			}
			foreach (KeyValuePair<string, SoftwareCategory> category in value.Categories)
			{
				if (!category.Value.Hidden && category.Value.IsUnlocked(time.Year))
				{
					MissingOSSupport[category.Value].Add(os);
				}
			}
		}
	}

	public void RegisterOSSupport(SoftwareProduct p)
	{
		RegisterOSSupport(p.Category, p.GetOSs());
	}

	public void RegisterOSSupport(SoftwareCategory cat, SoftwareProduct os)
	{
		SHashSet<SoftwareProduct> oSSupport = GetOSSupport(cat);
		if (oSSupport != null)
		{
			oSSupport.Remove(os);
		}
	}

	public void RegisterOSSupport(SoftwareCategory cat, IEnumerable<SoftwareProduct> os)
	{
		SHashSet<SoftwareProduct> oSSupport = GetOSSupport(cat);
		if (oSSupport == null)
		{
			return;
		}
		foreach (SoftwareProduct o in os)
		{
			oSSupport.Remove(o);
		}
	}

	public SHashSet<SoftwareProduct> GetOSSupport(SoftwareCategory cat)
	{
		return MissingOSSupport.GetOrNull(cat);
	}

	public MarketSimulation()
	{
	}

	public uint GetProductIDFromName(string name)
	{
		SoftwareProduct softwareProduct = Products.Values.FirstOrDefault((SoftwareProduct x) => x.Name.Equals(name));
		if (softwareProduct == null)
		{
			throw new UnityException("Failed to find ID for " + name);
		}
		return softwareProduct.ID;
	}

	public SoftwareProduct GetProductFromName(string name, bool archived = false)
	{
		SoftwareProduct softwareProduct = Products.Values.FirstOrDefault((SoftwareProduct x) => x.Name.Equals(name));
		if (softwareProduct == null)
		{
			if (!archived)
			{
				return null;
			}
			softwareProduct = ArchivedProducts.Values.FirstOrDefault((SoftwareProduct x) => x.Name.Equals(name));
		}
		return softwareProduct;
	}

	public void AddCompany(Company company, bool raiseEvent = true)
	{
		AllCompanies.Add(company);
		AllCompanyDict[company.ID] = company;
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = company as SimulatedCompany) != null)
		{
			lock (Companies)
			{
				Companies.Add(simulatedCompany.ID, simulatedCompany);
			}
		}
		if (RaiseEvents && raiseEvent && this.OnCompanyFounded != null)
		{
			this.OnCompanyFounded(this, company);
		}
		NetworkMeta.CheckDirty();
	}

	public void RemoveCompany(Company company)
	{
		List<uint> list = company.Subsidiaries.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			GetCompany(list[i]).OwnerCompany = null;
		}
		company.OwnerCompany = null;
		AllCompanyDict.Remove(company.ID);
		lock (Companies)
		{
			Companies.Remove(company.ID);
		}
		if (company.Distribution != null)
		{
			ClosePlatform(company.Distribution);
		}
		if (RaiseEvents && this.OnCompanyClosed != null)
		{
			this.OnCompanyClosed(this, company);
		}
		AllCompanies.Remove(company);
		company.KillCompany();
		NetworkMeta.CheckDirty();
	}

	public void AddNetworkID(uint id, bool framework)
	{
		if (framework)
		{
			_networkFrameIDs.Insert(0, id);
		}
		else
		{
			_networkIDs.Insert(0, id);
		}
	}

	public void ResetSoftwareIDs()
	{
		_networkIDs.Clear();
		_networkFrameIDs.Clear();
		nextID = ((Products.Count <= 0) ? 1u : Products.Keys.Max());
		nextFrameworkID = ((Frameworks.Count <= 0) ? 1u : Frameworks.Max((SoftwareFramework x) => x.ID));
		uint num = ((DistributionPlatforms.Count > 0) ? DistributionPlatforms.Select((DistributionPlatform x) => x.Software.ID).Max() : 0u);
		if (num > nextID)
		{
			nextID = num;
		}
		foreach (SimulatedCompany value in Companies.Values)
		{
			foreach (SimulatedCompany.ProductPrototype item in value.ProjectQueue)
			{
				if (item.SWID.HasValue && item.SWID > nextID)
				{
					nextID = item.SWID.Value;
				}
			}
			foreach (SimulatedCompany.ProductPrototype release in value.Releases)
			{
				if (release.SWID.HasValue && release.SWID > nextID)
				{
					nextID = release.SWID.Value;
				}
			}
		}
		foreach (Company playerCompany in GetPlayerCompanies())
		{
			foreach (ScheduledRelease release2 in playerCompany.GetReleases())
			{
				if (release2.ID > nextID)
				{
					nextID = release2.ID;
				}
			}
		}
		foreach (SoftwareWorkItem item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>())
		{
			if (item2.SWID.HasValue && item2.SWID.Value > nextID)
			{
				nextID = item2.SWID.Value;
			}
		}
		nextID++;
	}

	public uint GetID()
	{
		if (NetworkManager.IsClient)
		{
			if (_networkIDs.Count > 0)
			{
				NetworkMessaging.SendSoftwareID(0u, false, NetworkMessaging.MessageTarget.Host, 0);
				return _networkIDs.Pop();
			}
			throw new Exception("Network client did not get any Software IDs from host to allocate");
		}
		uint result = nextID;
		nextID++;
		return result;
	}

	public uint GetCompanyID()
	{
		uint result = nextCompanyID;
		nextCompanyID++;
		return result;
	}

	public uint GetDealID()
	{
		uint result = nextDealID;
		nextDealID++;
		return result;
	}

	public void SetIDS(uint swID, uint frameworkID, uint companyID, uint dealID)
	{
		nextID = swID;
		nextFrameworkID = frameworkID;
		nextCompanyID = companyID;
		nextDealID = dealID;
	}

	public void GetIDS(out uint swID, out uint frameworkID, out uint companyID, out uint dealID)
	{
		swID = nextID;
		frameworkID = nextFrameworkID;
		companyID = nextCompanyID;
		dealID = nextDealID;
	}

	public Company GetCompany(uint id)
	{
		if (id == 0)
		{
			return null;
		}
		if (id == PrivateInvestors.ID)
		{
			return PrivateInvestors;
		}
		if (id == PublicDomain.ID)
		{
			return PublicDomain;
		}
		return AllCompanyDict.GetOrNull(id);
	}

	public DistributionPlatform GetDistributionPlatform(uint id)
	{
		return DistributionPlatforms.FirstOrDefault((DistributionPlatform x) => x.Software.ID == id);
	}

	public void FindBuyer(NewStock stock, uint shares, SDateTime time)
	{
		Company buyer = stock.Buyer;
		double shareWorth = stock.ShareWorth;
		double value = shareWorth * (double)shares;
		if (stock.Seller.NewStock.Count > 1)
		{
			List<NewStock> list = stock.Seller.NewStock.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				NewStock newStock = list[i];
				if (shares == 0)
				{
					break;
				}
				SimulatedCompany simulatedCompany;
				if ((simulatedCompany = newStock.Buyer as SimulatedCompany) != null && newStock.Buyer != buyer)
				{
					uint num = shares.Min((uint)Utilities.FloorToInt(simulatedCompany.GetStockBudget(newStock.Buyer.Money * 0.3) / shareWorth));
					if (num != 0)
					{
						shares -= num;
						stock.Seller.TradeStock(newStock.Buyer, num, time, shareWorth * (double)num, stock);
					}
				}
			}
		}
		if (shares != 0)
		{
			foreach (SimulatedCompany item in Companies.Values.OrderByDescending((SimulatedCompany x) => x.Money))
			{
				if (shares == 0)
				{
					break;
				}
				if (!item.IsSubsidiary() && !item.Bankrupt && item != buyer && stock.Seller.CanOwnStock(item))
				{
					uint num2 = shares.Min((uint)Utilities.FloorToInt(item.GetStockBudget(item.Money * 0.2) / shareWorth));
					if (num2 != 0)
					{
						shares -= num2;
						stock.Seller.TradeStock(item, num2, time, shareWorth * (double)num2, stock);
					}
				}
			}
		}
		if (shares != 0)
		{
			stock.Seller.TradeStock(PrivateInvestors, shares, time, value, stock);
		}
	}

	public bool FindBuyers(Company client, uint shares, double sharePrice, SDateTime time)
	{
		bool flag = false;
		uint shares2 = client.Shares;
		if (client.Shares == 0)
		{
			client.Shares = (uint)Utilities.FloorToInt(client.GetMoneyWithInsurance() / sharePrice);
		}
		double num = (double)shares + (double)client.Shares;
		for (int i = 0; i < client.NewStock.Count; i++)
		{
			NewStock newStock = client.NewStock[i];
			SimulatedCompany simulatedCompany;
			if ((simulatedCompany = newStock.Buyer as SimulatedCompany) != null && newStock.Buyer != client)
			{
				uint num2 = shares.Min((uint)Utilities.FloorToInt(simulatedCompany.GetStockBudget(newStock.Buyer.Money * 0.3) / sharePrice));
				if (num2 != 0)
				{
					shares -= num2;
					flag |= client.TradeStock(newStock.Buyer, num2, time, sharePrice * (double)num2);
				}
			}
			else if (newStock.Buyer.Player)
			{
				NotificationManager.SendNotification(new IncreaseShareNotification(newStock.Seller), newStock.Buyer.NetworkPlayerID);
			}
			if (shares == 0)
			{
				break;
			}
		}
		if (shares != 0 && (double)shares / num > 0.05)
		{
			uint v = shares.Min((uint)(num * 0.25));
			foreach (SimulatedCompany item in Companies.Values.OrderByDescending((SimulatedCompany x) => x.Money))
			{
				if (!item.IsSubsidiary() && !item.Bankrupt && item != client && client.CanOwnStock(item))
				{
					uint num3 = shares.Min((uint)Utilities.FloorToInt(item.GetStockBudget(item.Money * 0.2) / sharePrice));
					if (num3 != 0 && (double)num3 / num > 0.05)
					{
						num3 = num3.Min(v);
						shares -= num3;
						flag |= client.TradeStock(item, num3, time, sharePrice * (double)num3);
					}
				}
				if (shares == 0)
				{
					break;
				}
			}
		}
		if (shares != 0)
		{
			flag |= client.TradeStock(PrivateInvestors, shares, time, sharePrice * (double)shares);
		}
		if (client.Shares != shares2)
		{
			MarketEvent marketEvent = new MarketEvent((shares2 == 0) ? MarketEvent.EventType.IPO : MarketEvent.EventType.StockDilution, time, (float)client.GetShare());
			if (!NetworkManager.IsConnectedToAnyone && shares2 != 0 && client.MarketEvents.Last().Type == MarketEvent.EventType.StockDilution)
			{
				client.MarketEvents[client.MarketEvents.Count - 1] = marketEvent;
			}
			else
			{
				client.AddMarketEvent(marketEvent, true);
			}
		}
		return flag;
	}

	public Company FindBuyer(IPDeal deal)
	{
		float num = deal.Worth();
		double num2 = 0.0;
		Company result = null;
		foreach (SimulatedCompany value in Companies.Values)
		{
			if (value != deal.Client && !value.IsSubsidiary() && value.Money * 0.01 > (double)num && value.Money > num2)
			{
				num2 = value.Money;
				result = value;
			}
		}
		return result;
	}

	public Company FindBuyer(IPDeal deal, Dictionary<Company, double> costs)
	{
		float num = deal.Worth();
		if (deal._products != null && deal._products.Length != 0 && deal._products[0].DesignerOwned)
		{
			Company devCompany = deal._products[0].DevCompany;
			Employee leadDesigner = deal._products[0].LeadDesigner;
			if (leadDesigner != null && !leadDesigner.Dismissed && leadDesigner.MyEmployer != null && devCompany != leadDesigner.MyEmployer && !leadDesigner.MyEmployer.Player && (leadDesigner.MyEmployer.Money - ((costs != null) ? new double?(costs.GetOrDefault(leadDesigner.MyEmployer, 0.0)) : ((double?)null))) * 0.1 > (double)num)
			{
				return leadDesigner.MyEmployer;
			}
		}
		double num2 = 0.0;
		Company result = null;
		foreach (SimulatedCompany value in Companies.Values)
		{
			if (value != deal.Client && !value.IsSubsidiary() && (value.Money - ((costs != null) ? new double?(costs.GetOrDefault(value, 0.0)) : ((double?)null))) * 0.01 > (double)num && value.Money > num2)
			{
				num2 = value.Money;
				result = value;
			}
		}
		return result;
	}

	public double[] GetQuality(SoftwareProduct product, SDateTime time)
	{
		return GetQuality(product.Category, time);
	}

	private double[] GetPerOSQuality(SoftwareProduct product, SDateTime time, List<SoftwareProduct> osCache, out uint osCov)
	{
		if (product.OSCount == 0)
		{
			osCov = 0u;
			return product.GetQuality(GetQuality(product, time), time);
		}
		osCache.Clear();
		double[] weightedQualityAddition = product.GetWeightedQualityAddition(time);
		double[] array = new double[3];
		osCov = 0u;
		float num = 0f;
		List<SoftwareProduct> compatibleOS = GetCompatibleOS(product, false, osCache);
		for (int i = 0; i < compatibleOS.Count; i++)
		{
			num = Mathf.Max(num, compatibleOS[i].Userbase);
		}
		SoftwareCategory category = product.Category;
		for (int j = 0; j < compatibleOS.Count; j++)
		{
			SoftwareProduct softwareProduct = compatibleOS[j];
			if (softwareProduct.Userbase <= 0)
			{
				continue;
			}
			osCov += (uint)softwareProduct.Userbase;
			Dictionary<SoftwareCategory, double[]> orNull = PerOSQuality.GetOrNull(softwareProduct.ID);
			if (orNull == null)
			{
				continue;
			}
			double num2 = 0.0;
			double[] orDefault = orNull.GetOrDefault(category, weightedQualityAddition);
			for (int k = 0; k < 3; k++)
			{
				if (orDefault[k] > 0.0)
				{
					num2 = Math.Min(1.0, weightedQualityAddition[k] / orDefault[k]);
				}
				array[k] += num2 * (double)((float)softwareProduct.Userbase / num);
			}
		}
		return array;
	}

	public uint GetOSCoverage(SoftwareProduct product)
	{
		uint num = 0u;
		List<SoftwareProduct> compatibleOS = GetCompatibleOS(product);
		for (int i = 0; i < compatibleOS.Count; i++)
		{
			SoftwareProduct softwareProduct = compatibleOS[i];
			if (softwareProduct.Userbase > 0)
			{
				num += (uint)softwareProduct.Userbase;
			}
		}
		return num;
	}

	public double[] GetQuality(SoftwareCategory category, SDateTime time)
	{
		if (!time.Equals(LastCache, true))
		{
			CacheQuality(time);
		}
		return CachedMarketQuality.GetOrDefault(category, _fullQuality);
	}

	public double GetFeatureScore(SoftwareProduct product, SDateTime time)
	{
		return GetFeatureScore(product.Category, time);
	}

	public ValueTuple<int, int> GenerateReviews(uint productID, SDateTime date, float targetScore, uint sales)
	{
		ValueTuple<float, float> twoFloats = GetTwoFloats(productID, date.Simplify().ToInt());
		float num = Mathf.Clamp01(targetScore + twoFloats.Item1.MapRange(0f, 1f, -0.05f, 0.05f, true));
		int num2 = Mathf.RoundToInt((float)sales * twoFloats.Item2.MapRange(0f, 1f, 0.01f, 0.03f, true));
		return new ValueTuple<int, int>(Mathf.RoundToInt(num * (float)num2), Mathf.RoundToInt((1f - num) * (float)num2));
	}

	[return: TupleElementNames(new string[] { "a", "b" })]
	private static ValueTuple<float, float> GetTwoFloats(uint id, int date)
	{
		uint num = (id * 747796405) ^ (uint)(date * -1403630843) ^ 0x9E3779B9u;
		if (num == 0)
		{
			num = 1u;
		}
		num ^= num << 13;
		num ^= num >> 17;
		num ^= num << 5;
		float item = (float)(num >> 8) * 5.9604645E-08f;
		num ^= num << 13;
		num ^= num >> 17;
		num ^= num << 5;
		float item2 = (float)(num >> 8) * 5.9604645E-08f;
		return new ValueTuple<float, float>(item, item2);
	}

	public double GetFeatureScore(SoftwareCategory category, SDateTime time)
	{
		if (!time.Equals(LastFCache, true))
		{
			CacheFeatures(time);
			LastFCache = time;
		}
		return NewCachedFeatures.GetOrDefault(category, 0.0);
	}

	public float GetMaxAwareness(SoftwareProduct p)
	{
		if (Awareness.Count == 0)
		{
			CalculateAwareness();
		}
		return Awareness.GetOrDefault(p.Category, 1f);
	}

	private void CalculateAwareness()
	{
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				if (!value2.Hidden)
				{
					Awareness[value2] = 1f;
				}
			}
		}
		foreach (SoftwareProduct value3 in Products.Values)
		{
			Awareness[value3.Category] = Mathf.Max(Awareness.GetOrDefault(value3.Category, 0f), value3.GetRealAwareness());
		}
	}

	private void CacheQuality(SDateTime time)
	{
		LastCache = time;
		CachedMarketQuality.Clear();
		PerOSQuality.Clear();
		CalculateAwareness();
		Dictionary<SoftwareCategory, double[]> dict = new Dictionary<SoftwareCategory, double[]>();
		foreach (SimulatedCompany value3 in Companies.Values)
		{
			SimulatedCompany simulatedCompany = value3;
			for (int i = 0; i < value3.Releases.Count; i++)
			{
				SimulatedCompany.ProductPrototype productPrototype = value3.Releases[i];
				double[] value = productPrototype.Submarkets.MultNewArray((double)Utilities.GetHypeFactor(productPrototype.DevTime, productPrototype.Reception, simulatedCompany.GetReputation(productPrototype.Category), productPrototype.Price, productPrototype.ReleaseDate, time) * HypeFactor);
				dict.AddUp(productPrototype.Category, value);
				if (productPrototype.OSs == null)
				{
					continue;
				}
				for (int j = 0; j < productPrototype.OSs.Length; j++)
				{
					SoftwareProduct softwareProduct = productPrototype.OSs[j];
					if (softwareProduct != null && softwareProduct.Userbase > 0)
					{
						PerOSQuality.Append(softwareProduct.ID).AddUp(productPrototype.Category, value);
					}
				}
			}
		}
		List<SoftwareWorkItem> list = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().ToList();
		for (int k = 0; k < list.Count; k++)
		{
			SoftwareWorkItem softwareWorkItem = list[k];
			if (softwareWorkItem.AddOn || !softwareWorkItem.ReleaseDate.HasValue || softwareWorkItem.InHouse)
			{
				continue;
			}
			double[] value2 = softwareWorkItem.Submarkets.MultNewArray((double)Utilities.GetHypeFactor(softwareWorkItem.DevTime, softwareWorkItem.PremarketingBoost, softwareWorkItem.GetRep(), softwareWorkItem.Price, softwareWorkItem.ReleaseDate.Value, time) * HypeFactor);
			dict.AddUp(softwareWorkItem.SWCategory, value2);
			if (softwareWorkItem.OSs == null)
			{
				continue;
			}
			for (int l = 0; l < softwareWorkItem.OSs.Length; l++)
			{
				SoftwareProduct softwareProduct2 = softwareWorkItem.OSs[l];
				if (softwareProduct2 != null && softwareProduct2.Userbase > 0)
				{
					PerOSQuality.Append(softwareProduct2.ID).AddUp(softwareWorkItem.SWCategory, value2);
				}
			}
		}
		List<SoftwareProduct> list2 = new List<SoftwareProduct>();
		foreach (SoftwareType value4 in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value5 in value4.Categories.Values)
			{
				if (value5.Hidden)
				{
					continue;
				}
				double[] array = new double[3];
				foreach (SoftwareProduct value6 in Products.Values)
				{
					if (value6.InHouse || value6.DevCompany.Bankrupt || !value6.Category.Equals(value5))
					{
						continue;
					}
					double[] weightedQualityAddition = value6.GetWeightedQualityAddition(time);
					array.AddArray(weightedQualityAddition);
					if (!value4.OSSpecific || value6.OSCount <= 0 || !weightedQualityAddition.Any((double z) => z > 0.0))
					{
						continue;
					}
					List<SoftwareProduct> compatibleOS = GetCompatibleOS(value6, false, list2);
					for (int num = 0; num < compatibleOS.Count; num++)
					{
						SoftwareProduct softwareProduct3 = compatibleOS[num];
						if (softwareProduct3.Userbase > 0)
						{
							PerOSQuality.Append(softwareProduct3.ID).AddUp(value5, weightedQualityAddition);
						}
					}
					list2.Clear();
				}
				double[] orDefault = dict.GetOrDefault(value5);
				for (int num2 = 0; num2 < 3; num2++)
				{
					array[num2] += Math.Min(array[num2], (orDefault == null) ? 0.0 : orDefault[num2]);
				}
				CachedMarketQuality[value5] = array;
			}
		}
	}

	private void CacheFeatures(SDateTime time)
	{
		NewCachedFeatures.Clear();
		foreach (KeyValuePair<string, SoftwareType> softwareType in SoftwareTypes)
		{
			foreach (SoftwareCategory value in softwareType.Value.Categories.Values)
			{
				if (value.Hidden)
				{
					continue;
				}
				double num = 0.0;
				foreach (KeyValuePair<uint, SoftwareProduct> product in Products)
				{
					if (!product.Value.InHouse && product.Value.Category.Equals(value))
					{
						num = Math.Max(num, product.Value.PerceivedValue(time));
					}
				}
				NewCachedFeatures[value] = num;
			}
		}
	}

	public SoftwareFramework CreateFramework(string name, Company c, SoftwareType t, SoftwareCategory cat, IEnumerable<SoftwareWorkItem.FeatureProgress> feats, Dictionary<string, TechLevel> techs, SDateTime releaseDate)
	{
		SoftwareFramework softwareFramework = new SoftwareFramework(name, GetFrameworkID(), t, cat, feats, techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value), releaseDate);
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendAddFramework(name.StripRichTags(), softwareFramework.ID, softwareFramework.Type.ID, softwareFramework.Category.ID, softwareFramework.Features.ToDictionary((KeyValuePair<FeatureBase, double> x) => x.Key.ID, (KeyValuePair<FeatureBase, double> x) => x.Value), softwareFramework.TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.Year), softwareFramework.Release, c.NetworkPlayerID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		softwareFramework.Transfer(c);
		Frameworks.Add(softwareFramework);
		if (RaiseEvents && this.OnFrameworkReleased != null)
		{
			this.OnFrameworkReleased(this, softwareFramework);
		}
		return softwareFramework;
	}

	public void AddFramework(string name, uint id, uint t, uint cat, Dictionary<uint, double> feats, Dictionary<string, int> techs, SDateTime releaseDate)
	{
		SoftwareFramework item = new SoftwareFramework(name, id, t, cat, feats, techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => x.Value), releaseDate);
		Frameworks.Add(item);
		NetworkMeta.CheckDirty();
	}

	public SoftwareFramework GetFramework(uint id)
	{
		if (id != 0)
		{
			return Frameworks.FirstOrDefault((SoftwareFramework x) => x.ID == id);
		}
		return null;
	}

	public uint GetFrameworkID()
	{
		if (NetworkManager.IsClient)
		{
			if (_networkFrameIDs.Count > 0)
			{
				NetworkMessaging.SendSoftwareID(0u, true, NetworkMessaging.MessageTarget.Host, 0);
				return _networkFrameIDs.Pop();
			}
			throw new Exception("Network client did not get any Software IDs from host to allocate");
		}
		uint result = nextFrameworkID;
		nextFrameworkID++;
		return result;
	}

	public TechLevel GetTechLevel(string spec, int year)
	{
		if (spec != null)
		{
			return TechLevels[spec].FirstOrDefault((TechLevel x) => x.Year == year);
		}
		return null;
	}

	public DistributionPlatform CreatePlatform(Company owner, SoftwareProduct software, float cut, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			software.SendNetwork();
			NetworkMessaging.SendCreateDigitalPlatform(owner.ID, software.ID, cut, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		uint id;
		for (id = 1u; DistributionPlatforms.Any((DistributionPlatform x) => x.BitID == id); id <<= 1)
		{
		}
		DistributionPlatform distributionPlatform = new DistributionPlatform(id, owner, software, cut);
		UpdateMarketTechOutdates(software);
		DistributionPlatforms.Add(distributionPlatform);
		owner.Distribution = distributionPlatform;
		if (NetworkManager.NotConnectedOrHost)
		{
			foreach (Company allCompany in AllCompanies)
			{
				if (allCompany.AutoAcceptPlatforms || allCompany == owner || allCompany.OwnerCompany == owner)
				{
					allCompany.MarkInterested(owner, true, 0);
				}
			}
		}
		NetworkMeta.CheckDirty();
		return distributionPlatform;
	}

	public void UpdatePlatform(DistributionPlatform d, SoftwareProduct p, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			p.SendNetwork();
			NetworkMessaging.SendCreateDigitalPlatform(d.Owner.ID, d.Software.ID, d.GetCut(), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		d.Software = p;
		UpdateMarketTechOutdates(p);
		d.UpdateExtraBandwidth();
		NetworkMeta.CheckDirty();
	}

	public void ClosePlatform(DistributionPlatform p, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			NetworkMessaging.SendArchiveProduct(p.Software.ID, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		DistributionPlatforms.Remove(p);
		p.Owner.Distribution = null;
		foreach (Company allCompany in AllCompanies)
		{
			allCompany.MarkInterested(p.Owner, false, 0, true);
			allCompany.SignPlatform(p, false, true);
		}
		if (p.Owner.IsLocalPlayer)
		{
			DistributionQueryChange.Clear();
		}
		foreach (SoftwareProduct allProduct in GetAllProducts(false))
		{
			if (allProduct.ExclusiveStore == p)
			{
				allProduct.ExclusiveStore = null;
			}
		}
	}

	public void InitialReleases(SDateTime time)
	{
		foreach (CompanyType value in CompanyTypes.Values)
		{
			if (value.ForceType == null)
			{
				continue;
			}
			SoftwareType softwareType = SoftwareTypes[value.ForceType];
			SoftwareCategory softwareCategory = ((softwareType.Categories.Count == 1) ? softwareType.Categories.Values.First() : ((value.ForceCat == null) ? softwareType.Categories.Values.GetRandom(softwareType.Categories.Count, Random) : softwareType.Categories[value.ForceCat]));
			if (softwareType.IsUnlocked(time.Year) && softwareCategory.IsUnlocked(time.Year) && !softwareCategory.Hidden)
			{
				SimulatedCompany simulatedCompany = new SimulatedCompany(GenerateCompanyName(value.NameGen), time, value, value.GetTypes(), 1f, this);
				simulatedCompany.InitialLeadDesigner(value, time);
				AddCompany(simulatedCompany);
				SoftwareProduct softwareProduct = simulatedCompany.ReleaseNow(softwareType, softwareCategory, time);
				if (softwareProduct != null)
				{
					AddProduct(softwareProduct, false);
				}
			}
		}
	}

	public static void FixSales(int sales, double physical, double refunds, int follows, double quality, ScriptSystem.SaleScope saleScope, IStockable stockable, out IStockable limiter)
	{
		limiter = null;
		if (sales == 0)
		{
			saleScope.SetValues(0, 0, 0, 0);
			return;
		}
		int num = ((follows != 0) ? Utilities.RoundToInt((double)follows * Math.Pow(Math.Max(0.0, 1.0 - quality * 1.399999976158142), 1.5)) : 0);
		int num2 = Math.Min(sales, Math.Max(Utilities.FloorToInt((double)sales * refunds), num));
		int num3 = Utilities.RoundToInt((double)num2 * physical);
		int num4 = Utilities.RoundToInt((double)sales * physical);
		int num5 = sales - num4;
		int num6 = Mathf.Min(num5, num2 - num3);
		uint maxPhysicalCopies = stockable.GetMaxPhysicalCopies(out limiter);
		if (maxPhysicalCopies == 0)
		{
			saleScope.SetValues(0, num5 - num6, num6, Mathf.Max(0, num4 - num3));
			return;
		}
		int missedPhysicalSales = 0;
		if (num4 > maxPhysicalCopies)
		{
			int num7 = num4;
			num4 = (int)maxPhysicalCopies;
			num3 = Mathf.Min(num4, Mathf.Max(Utilities.FloorToInt((double)num4 * refunds), Utilities.FloorToInt(physical * (double)num)));
			missedPhysicalSales = Mathf.Max(0, num7 - num3 - num4);
		}
		saleScope.SetValues(num4 - num3, num5 - num6, num6 + num3, missedPhysicalSales);
	}

	public void DoOutOfStockNotification(IStockable p, Company devCompany, bool traded, bool hasPrintDeal, bool outOfStock)
	{
		if (!outOfStock || !p.StockNotifications || !devCompany.Player || traded || hasPrintDeal)
		{
			return;
		}
		if (devCompany.LocalPlayer)
		{
			if (!NotificationManager.CheckAggregate<NoStockNotification>(p))
			{
				NotificationManager.AddNotification(new NoStockNotification(p));
			}
		}
		else if (p is SoftwareProduct)
		{
			NotificationManager.SendNotification(new NoStockNotification(p), devCompany.NetworkPlayerID);
		}
	}

	private bool PreSimValid(SoftwareProduct p)
	{
		List<float> cashflow = p.GetCashflow(false);
		List<int> unitSales = p.GetUnitSales(true);
		List<int> unitSales2 = p.GetUnitSales(false);
		List<int> refunds = p.GetRefunds();
		if (unitSales.Count < 5 || (unitSales.Count == cashflow.Count && cashflow[cashflow.Count - 1] > 0f) || unitSales[unitSales.Count - 1] > 0 || unitSales2[unitSales2.Count - 1] > 0 || refunds[refunds.Count - 1] > 0)
		{
			return true;
		}
		p.KillAwareness();
		p.ClearAddonSalesStats();
		return false;
	}

	public float GetIdealMarketPrice(SoftwareCategory cat, bool subscriptionBased)
	{
		float orDefault = _currentIdealMarketPrice.GetOrDefault(cat, cat.IdealPrice);
		if (subscriptionBased)
		{
			return (float)((double)orDefault * 0.08);
		}
		return orDefault;
	}

	public float GetIdealMarketPrice(SoftwareAddOn cat)
	{
		return _currentIdealAddonPrice.GetOrDefault(cat, cat.IdealPrice);
	}

	private void CalculateIdealPrices(SDateTime time)
	{
		foreach (SoftwareType value in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value2 in value.Categories.Values)
			{
				_currentIdealMarketPrice[value2] = value2.IdealPrice;
			}
			foreach (SoftwareAddOn value3 in value.AddOns.Values)
			{
				_currentIdealAddonPrice[value3] = value3.IdealPrice;
			}
		}
		int num = (time - SDateTime.GetYear(5)).ToInt();
		foreach (SoftwareProduct value4 in Products.Values)
		{
			if (value4.Release.ToInt() < num)
			{
				continue;
			}
			float orDefault = _currentIdealMarketPrice.GetOrDefault(value4.Category, value4.Category.IdealPrice);
			double num2 = value4.PerceivedValue(time, false);
			if (num2 > 0.0)
			{
				double num3 = (double)value4.Price / num2;
				if (value4.SubscriptionBased)
				{
					num3 /= 0.08;
				}
				if ((num3 / (double)orDefault).IsBetween(0.75, 1.25))
				{
					_currentIdealMarketPrice[value4.Category] = Mathf.Lerp(orDefault, (float)num3, (float)value4.GetTime(time) * 0.5f);
				}
			}
		}
		foreach (AddOnProduct addOnProduct in AddOnProducts)
		{
			if (addOnProduct.Release.ToInt() < num)
			{
				continue;
			}
			float orDefault2 = _currentIdealAddonPrice.GetOrDefault(addOnProduct.Type, addOnProduct.Type.IdealPrice);
			double num4 = addOnProduct.PerceivedValue(time, false);
			if (num4 > 0.0)
			{
				double num5 = (double)addOnProduct.Price / num4;
				if ((num5 / (double)orDefault2).IsBetween(0.75, 1.25))
				{
					_currentIdealAddonPrice[addOnProduct.Type] = Mathf.Lerp(orDefault2, (float)num5, (float)addOnProduct.GetTime(time) * 0.5f);
				}
			}
		}
	}

	public static float PriceFact(float price, double market)
	{
		double num = (1.0 + ((double)price - market) / market) / 2.0;
		return PriceFactEval.Evaluate((float)num);
	}

	public static float PricePenalty(float price, double market)
	{
		float num = (float)((double)price / market);
		if (!(num > 1.75f))
		{
			return 1f;
		}
		return num.MapRange(1.75f, 2f, 1f, 0f, true);
	}

	private void SimulateLeads(SDateTime time)
	{
		_leadCache.Clear();
		_leadCache.AddRange(FreeLeads);
		for (int i = 0; i < _leadCache.Count; i++)
		{
			Employee employee = _leadCache[i];
			if (employee.GetAgeFlat(time) >= Employee.RetirementAge)
			{
				employee.Retired = true;
				FreeLeads.Remove(employee);
				NetworkManager instance = NetworkManager.Instance;
				if ((object)instance != null)
				{
					instance.UnregisterNetworkObject(employee, true);
				}
			}
		}
	}

	public uint EvalutateDistributionSums(IList<DistributionPlatform> platforms, bool cached = true, bool capped = true)
	{
		if (platforms.Count == 0)
		{
			return 0u;
		}
		uint num = 0u;
		if (cached)
		{
			for (int i = 0; i < platforms.Count; i++)
			{
				num |= platforms[i].BitID;
			}
			uint value;
			if (_distributionSums.TryGetValue(num, out value))
			{
				if (capped && value > Population)
				{
					return Population;
				}
				return value;
			}
		}
		uint num2 = 0u;
		uint num3 = 0u;
		for (int j = 0; j < platforms.Count; j++)
		{
			DistributionPlatform distributionPlatform = platforms[j];
			if (distributionPlatform.ActualUsers > num3)
			{
				num3 = distributionPlatform.ActualUsers;
			}
			num2 += distributionPlatform.ActualUsers;
		}
		uint num4 = num3 + (num2 - num3 >> 2);
		if (cached)
		{
			_distributionSums[num] = num4;
		}
		if (capped && num4 > Population)
		{
			return Population;
		}
		return num4;
	}

	private void EqualizeDistributions(double pvsd)
	{
		float num = 1f;
		if (DistributionPlatforms.Count > 5)
		{
			num = 0.5f;
		}
		else if (DistributionPlatforms.Count > 1)
		{
			num -= (float)(DistributionPlatforms.Count - 1) * 0.1f;
		}
		uint maxPopulation = (uint)((float)Population * num);
		for (int i = 0; i < DistributionPlatforms.Count; i++)
		{
			DistributionPlatforms[i].RecalculateTargetUsers(maxPopulation, pvsd);
		}
		uint num2 = EvalutateDistributionSums(DistributionPlatforms, true, false);
		if (num2 < Population)
		{
			uint amount = (Population - num2) * 3;
			PullDistributionUp(DistributionPlatforms, amount);
		}
	}

	public void PullDistributionUp(IList<DistributionPlatform> platforms, uint amount)
	{
		if (platforms.Count == 1)
		{
			PullDistributionUp(platforms[0], amount);
			return;
		}
		_distributionSums.Clear();
		uint num = platforms.SumSafe((DistributionPlatform x) => x.ActualUsers);
		for (int num2 = 0; num2 < platforms.Count; num2++)
		{
			DistributionPlatform distributionPlatform = platforms[num2];
			distributionPlatform.ActualUsers += (uint)((float)amount * ((float)distributionPlatform.ActualUsers / (float)num));
			if (distributionPlatform.ActualUsers > Population)
			{
				distributionPlatform.ActualUsers = Population;
			}
		}
	}

	public void PullDistributionUp(DistributionPlatform p, uint amount)
	{
		_distributionSums.Clear();
		p.ActualUsers += amount;
		if (p.ActualUsers > Population)
		{
			p.ActualUsers = Population;
		}
	}

	public void ArchiveProduct(SoftwareProduct pp, bool delete)
	{
		if (delete)
		{
			ArchivedProducts.Remove(pp.ID);
			if (RaiseEvents && this.OnProductRemoved != null)
			{
				this.OnProductRemoved(this, pp);
			}
			{
				foreach (List<AddOnProduct> value in pp.Addons.Values)
				{
					for (int i = 0; i < value.Count; i++)
					{
						AddOnProduct e = value[i];
						if (RaiseEvents && this.OnAddOnRemoved != null)
						{
							this.OnAddOnRemoved(this, e);
						}
					}
				}
				return;
			}
		}
		Products.Remove(pp.ID);
		ArchivedProducts[pp.ID] = pp;
	}

	public void ClearForClient(SDateTime time)
	{
		if (time.Day == 0)
		{
			Layoffs = Mathf.Max(0, Layoffs - 10);
		}
		_distributionSums.Clear();
		SimulateLeads(time);
		CalculateIdealPrices(time);
		CalculateMaxDistDevTime();
		Active.PlayerDigitalShare.RemoveAt(0);
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			Active.PlayerDigitalShare.Add(GameSettings.Instance.MyCompany.Distribution.MarketShare);
		}
		else
		{
			Active.PlayerDigitalShare.Add(0f);
		}
		CacheQuality(time);
		float t = 1f / (float)GameSettings.DaysPerMonth / 12f;
		foreach (SoftwareProduct value in Products.Values)
		{
			if (value.ExclusiveStore != null && value.ExclusiveEnd < time)
			{
				value.ExclusiveStore = null;
			}
			value.MaxLoadIncidents = 0;
			value.PriceChangeFact = Mathf.Lerp(value.PriceChangeFact, 1f, t);
			value.AddonProfit = 0f;
			if (value.Addons.Count <= 0)
			{
				continue;
			}
			foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in value.Addons)
			{
				foreach (AddOnProduct item in addon.Value)
				{
					if (!addon.Key.Hardware || item.Owner == value.DevCompany)
					{
						value.AddonProfit += (float)(item.Gross - item.Loss);
					}
				}
			}
		}
		UpdateDistributionDealNotification();
	}

	private void UpdateDistributionDealNotification()
	{
		_rejectDistCache.Clear();
		_acceptDistCache.Clear();
		foreach (Company item in DistributionQueryChange)
		{
			if (item.WantLocalPlayerDistribution())
			{
				_acceptDistCache.Add(item);
			}
			else
			{
				_rejectDistCache.Add(item);
			}
		}
		if (_acceptDistCache.Count > 0)
		{
			NotificationManager.AddNotification(new MultiCompanyDetailNotification("AcceptDistributionNotification".Loc((_acceptDistCache.Count == 1) ? _acceptDistCache[0].Name : "Company".LocPlural(_acceptDistCache.Count)), "Distribution", NotificationManager.NotificationType.Neutral, _acceptDistCache)
			{
				Distribution = true
			});
		}
		if (_rejectDistCache.Count > 0)
		{
			NotificationManager.AddNotification(new MultiCompanyDetailNotification("RejectDistributionNotification".Loc((_rejectDistCache.Count == 1) ? _rejectDistCache[0].Name : "Company".LocPlural(_rejectDistCache.Count)), "Distribution", NotificationManager.NotificationType.Neutral, _rejectDistCache));
		}
		DistributionQueryChange.Clear();
		_rejectDistCache.Clear();
		_acceptDistCache.Clear();
	}

	public void SimulateMonth(SDateTime time, bool presim = false)
	{
		if (time.Day == 0)
		{
			Layoffs = Mathf.Max(0, Layoffs - 10);
		}
		MarketEvents.RemoveAll((MarketEvent x) => x.Type == MarketEvent.EventType.TechResearch && x.DateInt / 12 + 50 < time.Year);
		_distributionSums.Clear();
		if (Companies.Count > 0)
		{
			if (Companies.Values.Count((SimulatedCompany x) => x.DistributionDevelopmentCooldown > -1 || x.Distribution != null) < 4)
			{
				SimulatedCompany simulatedCompany = Companies.Values.Where((SimulatedCompany x) => x.Distribution == null && x.DistributionDevelopmentCooldown == -1 && !x.IsSubsidiary()).MaxInstance((SimulatedCompany x) => x.Money);
				if (simulatedCompany != null)
				{
					simulatedCompany.DistributionDevelopmentCooldown = ((DistributionPlatforms.Count > 0) ? Mathf.RoundToInt(GameData.ProjectDevTimeGeneric(Mathf.RoundToInt(GetDistributionMaxDevTime()))) : 0);
				}
			}
			foreach (SimulatedCompany value3 in Companies.Values)
			{
				if (value3.DistributionDevelopmentCooldown > -1)
				{
					if (value3.DistributionDevelopmentCooldown == 0)
					{
						SoftwareProduct softwareProduct = value3.GenerateDistributionPlatform(time, value3.Distribution);
						if (value3.Distribution == null)
						{
							value3.Distribution = CreatePlatform(value3, softwareProduct, DistributionPlatform.AcceptableCut(0.25f));
						}
						else
						{
							UpdatePlatform(value3.Distribution, softwareProduct);
						}
					}
					value3.DistributionDevelopmentCooldown--;
				}
				else if (value3.Distribution != null && value3.Distribution.Software.Features.SumSafe((FeatureBase x) => x.DevTime) < GetDistributionMaxDevTime())
				{
					value3.DistributionDevelopmentCooldown = Mathf.RoundToInt(GameData.ProjectDevTimeGeneric(Mathf.RoundToInt(GetDistributionMaxDevTime())));
				}
			}
		}
		double physicalVsDigital = GetPhysicalVsDigital(time);
		EqualizeDistributions(physicalVsDigital);
		SimulateLeads(time);
		CalculateIdealPrices(time);
		if (SimulateCompanies)
		{
			_osPortCache.Clear();
			foreach (SoftwareProduct value4 in Products.Values)
			{
				if (value4.Type.Name.Equals("Operating System") && value4.Userbase > 50000)
				{
					SoftwareProduct value;
					if (!_osPortCache.TryGetValue(value4.Category.Name, out value))
					{
						_osPortCache[value4.Category.Name] = value4;
					}
					else if (value4.Userbase > value.Userbase)
					{
						_osPortCache[value4.Category.Name] = value4;
					}
				}
			}
			List<SoftwareProduct> list = _osPortCache.Select((KeyValuePair<string, SoftwareProduct> x) => x.Value).ToList();
			List<SoftwareProduct> list2 = new List<SoftwareProduct>();
			int num = 0;
			AICompCache.Clear();
			AICompCache.AddRange(Companies.Values);
			HashSet<string> unlockedSpecs = GameSettings.Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Designer).ToHashSet();
			for (int num2 = 0; num2 < AICompCache.Count; num2++)
			{
				SimulatedCompany simulatedCompany2 = AICompCache[num2];
				if (!Companies.ContainsKey(simulatedCompany2.ID))
				{
					continue;
				}
				if (simulatedCompany2.Bankrupt)
				{
					HUD.Instance.dealWindow.CancelCompanyDeals(simulatedCompany2);
					lock (Companies)
					{
						Companies.Remove(simulatedCompany2.ID);
					}
					if (simulatedCompany2.Products.Count == 0)
					{
						simulatedCompany2.CleanCompany(time);
						RemoveCompany(simulatedCompany2);
					}
					continue;
				}
				simulatedCompany2.EvaluateDistributionPlatforms(time);
				if (presim)
				{
					DistributionQueryChange.Clear();
				}
				if (list.Count > 0)
				{
					simulatedCompany2.CheckTopOSPort(list, time);
				}
				simulatedCompany2.Simulate(time, list2, unlockedSpecs, presim);
				simulatedCompany2.DistributionLoad = 0f;
				for (int num3 = num; num3 < list2.Count; num3++)
				{
					AddProduct(list2[num3], false);
				}
				num = list2.Count;
			}
			SDateTime? t = DealWindow.FindReceptionTime();
			if (t.HasValue || NetworkManager.IsHostingPlayers)
			{
				for (int num4 = 0; num4 < list2.Count; num4++)
				{
					if (!NetworkManager.IsHostingPlayers && !t.HasValue)
					{
						break;
					}
					SoftwareProduct softwareProduct2 = list2[num4];
					if (!softwareProduct2.DevCompany.IsSubsidiary())
					{
						if (softwareProduct2.ServerReq > 0f)
						{
							ServerDeal deal = new ServerDeal(softwareProduct2);
							HUD.Instance.dealWindow.AddDeal(deal, t, true);
							t = DealWindow.FindReceptionTime();
						}
						if (t.HasValue || NetworkManager.IsHostingPlayers)
						{
							WorkDeal workDeal = null;
							workDeal = ((!(Random.NextDouble() > 0.5)) ? new WorkDeal(softwareProduct2, WorkDeal.WorkType.Support, time, Mathf.CeilToInt(softwareProduct2.DevTime * 2f)) : new WorkDeal(softwareProduct2, WorkDeal.WorkType.Marketing, time, Mathf.CeilToInt(softwareProduct2.DevTime / 4f)));
							HUD.Instance.dealWindow.AddDeal(workDeal, t, true);
							t = DealWindow.FindReceptionTime();
						}
					}
				}
			}
			UpdateDistributionDealNotification();
		}
		foreach (SimulatedCompany value5 in Companies.Values)
		{
			value5.SimulateDistribution(this, time, physicalVsDigital);
		}
		List<SoftwareProduct> list3 = new List<SoftwareProduct>();
		List<SoftwareProduct> list4 = new List<SoftwareProduct>();
		foreach (SoftwareProduct value6 in Products.Values)
		{
			value6.LastMonthPhysical = 0;
			if (!value6.InHouse && value6.LastSale.Year > 0 && SDateTime.GetYears(value6.LastSale, time) > 10f && (value6.SequelTo == null || value6.SequelTo.Archived))
			{
				list4.Add(value6);
			}
			else if (!value6.InHouse && !value6.DevCompany.Bankrupt && (!presim || PreSimValid(value6)))
			{
				list3.Add(value6);
			}
		}
		for (int num5 = 0; num5 < list4.Count; num5++)
		{
			SoftwareProduct softwareProduct3 = list4[num5];
			if (softwareProduct3.Archive())
			{
				bool flag = false;
				foreach (SoftwareProduct item in softwareProduct3.GetEntireIP())
				{
					if (item.DevCompany.IsLocalPlayer && !item.PlayerArchived)
					{
						flag = true;
					}
					item.Trade(PublicDomain, time);
					foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in item.Addons)
					{
						foreach (AddOnProduct item2 in addon.Value)
						{
							item2.Trade(PublicDomain);
						}
					}
				}
				if (flag)
				{
					NotificationManager.AddNotification(new ProductListNotification("PublicDomainInfo".Loc(), "MoreSoftware", NotificationManager.NotificationType.Neutral, softwareProduct3.GetEntireIP().ToArray()));
				}
			}
			ArchiveProduct(softwareProduct3, false);
		}
		for (int num6 = 0; num6 < PublicDomain.Products.Count; num6++)
		{
			SoftwareProduct latestSuccessor = PublicDomain.Products[num6].GetLatestSuccessor();
			if (latestSuccessor.Archived && SDateTime.GetYears(latestSuccessor.Release, time) > 20f)
			{
				for (SoftwareProduct softwareProduct4 = latestSuccessor; softwareProduct4 != null; softwareProduct4 = softwareProduct4.SequelTo)
				{
					softwareProduct4.RemoveFromGame();
					ArchiveProduct(softwareProduct4, true);
				}
				num6 = -1;
			}
		}
		if (presim && list3.Count > MaxPresim)
		{
			for (int num7 = list3.Count - MaxPresim - 1; num7 >= 0; num7--)
			{
				list3[num7].AddToCashflow(0, 0, 0, 0f, 0f, time);
			}
			for (int num8 = 0; num8 < MaxPresim; num8++)
			{
				list3[num8] = list3[list3.Count - MaxPresim + num8];
			}
			for (int num9 = list3.Count - 1; num9 >= MaxPresim; num9--)
			{
				list3[num9].ChangeLastSale(time, true);
				list3[num9].AddToCashflow(0, 0, 0, 0f, 0f, time);
				list3[num9].ClearAddonSalesStats();
				list3.RemoveAt(num9);
			}
		}
		List<SoftwareProduct> list5 = list3;
		Dictionary<SoftwareProduct, Dictionary<SoftwareCategory, double[]>> dict = new Dictionary<SoftwareProduct, Dictionary<SoftwareCategory, double[]>>();
		Dictionary<SoftwareCategory, int> dictionary = new Dictionary<SoftwareCategory, int>();
		foreach (SoftwareType value7 in SoftwareTypes.Values)
		{
			foreach (SoftwareCategory value8 in value7.Categories.Values)
			{
				dictionary[value8] = 0;
			}
		}
		List<SoftwareProduct> list6 = (presim ? Products.Values.Where((SoftwareProduct x) => !x.InHouse && !x.DevCompany.Bankrupt).ToList() : list5);
		for (int num10 = 0; num10 < list6.Count; num10++)
		{
			SoftwareProduct softwareProduct5 = list6[num10];
			dictionary.AddUp(softwareProduct5.Category, softwareProduct5.Userbase);
			dictionary[softwareProduct5.Category] += softwareProduct5.Userbase;
		}
		float num11 = 0f;
		for (int num12 = 0; num12 < list6.Count; num12++)
		{
			SoftwareProduct softwareProduct6 = list6[num12];
			double retentionFact = softwareProduct6.Category.GetRetentionFact();
			retentionFact *= (double)((float)softwareProduct6.Bugss / (float)SoftwareWorkItem.GetMaximumBugs(softwareProduct6.DevTime)).MapRange(0.2f, 1f, 1f, 0.25f, true);
			if (softwareProduct6.LastUpdated.HasValue)
			{
				double num13 = (double)SDateTime.GetMonths(softwareProduct6.LastUpdated.Value, time) / (double)softwareProduct6.Category.Retention;
				if (num13 < 1.0)
				{
					num13 *= softwareProduct6.ReleaseRelevancy;
					retentionFact = Utilities.Lerp(retentionFact, 1.0, (1.0 - num13) * 0.5, true);
				}
			}
			if (softwareProduct6.ServerReq > 0f)
			{
				retentionFact = (retentionFact + 1.0) * 0.5;
			}
			if (softwareProduct6.SubscriptionBased)
			{
				float value2 = PricePenalty(softwareProduct6.Price, (double)GetIdealMarketPrice(softwareProduct6.Category, softwareProduct6.SubscriptionBased) * softwareProduct6.PerceivedValue(time));
				retentionFact *= (double)Mathf.Clamp01(value2);
			}
			softwareProduct6.Userbase = Utilities.FloorToInt((double)softwareProduct6.Userbase * retentionFact.SpreadPercentage(GameSettings.DaysPerMonth));
			if (softwareProduct6.Type.Name.Equals("Operating System"))
			{
				num11 += (float)softwareProduct6.Userbase;
			}
			softwareProduct6.SimulateAwareness();
		}
		CacheQuality(time);
		double num14 = TimeFactor[time.Month];
		uint totalDigitalSales = 0u;
		List<SoftwareProduct> osCache = new List<SoftwareProduct>();
		List<KeyValuePair<uint, TechLevel>> list7 = new List<KeyValuePair<uint, TechLevel>>();
		_saleScope.Time = time;
		float t2 = 1f / (float)GameSettings.DaysPerMonth / 12f;
		DistributionPlatforms.ForEach(delegate(DistributionPlatform x)
		{
			x.ActualItemSales = (x.ItemSales = 0f);
		});
		DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
		if (distribution != null)
		{
			distribution.UpdateBandwidth(time);
		}
		float saleServerReq = 0.05f.BandwidthFactor(time);
		foreach (SoftwareProduct product in list5.OrderBy((SoftwareProduct x) => x.Type.Name.Equals("Operating System") ? 1 : 0))
		{
			if (product.ExclusiveStore != null && product.ExclusiveEnd < time)
			{
				product.ExclusiveStore = null;
			}
			product.OSSalesBoost = 0f;
			_saleScope.Product = product;
			if (product.OSCount > 0 && !product.Type.Name.Equals("Operating System"))
			{
				double[] weightedQualityAddition = product.GetWeightedQualityAddition(time);
				foreach (SoftwareProduct item3 in product.GetOSs())
				{
					dict.Append(item3).AddTo(product.Category, weightedQualityAddition, Math.Max);
				}
			}
			uint osCov = 0u;
			SoftwareType type = product.Type;
			double[] perOSQuality = GetPerOSQuality(product, time, osCache, out osCov);
			if (perOSQuality.Any((double x) => double.IsNaN(x) || double.IsInfinity(x)))
			{
				continue;
			}
			float num15 = PricePenalty(product.Price, (double)GetIdealMarketPrice(product.Category, product.SubscriptionBased) * product.PerceivedValue(time)) * product.PriceChangeFact;
			if (num15 == 0f && product.DevCompany.Player && !product.Traded && product.Followers != 0 && !product.PlayerArchived)
			{
				NotificationManager.SendNotification(new ProductDetailNotification(product, "TooExpensiveWarning".Loc(product.Name), "Money", NotificationManager.NotificationType.Warning), product.DevCompany.NetworkPlayerID);
			}
			double num16 = product.SimulateAddonSales(time, num14, physicalVsDigital, list7, saleServerReq, ref totalDigitalSales) * (double)(product.SubscriptionBased ? Mathf.Clamp01(num15) : 1f);
			if (num16 > 0.0)
			{
				uint num17 = (product.SubscriptionBased ? product.SubscriptionSum : product.UnitSum);
				if (product.Type.OSSpecific && num17 > osCov)
				{
					num17 = osCov;
				}
				product.Userbase = Utilities.RoundToInt((double)product.Userbase * (1.0 + num16 * 0.25).SpreadPercentage(GameSettings.DaysPerMonth));
				if (product.Userbase > num17)
				{
					product.Userbase = (int)num17;
				}
			}
			if (num15 > 0f && product.GetBigProjectFactor() > 0.0 && product.Type.Name.Equals("Operating System"))
			{
				double[] array = new double[3];
				Dictionary<SoftwareCategory, double[]> orNull = dict.GetOrNull(product);
				if (orNull != null)
				{
					foreach (KeyValuePair<SoftwareCategory, double[]> item4 in orNull)
					{
						double[] orDefault = CachedMarketQuality.GetOrDefault(item4.Key);
						if (orDefault != null)
						{
							for (int num18 = 0; num18 < 3; num18++)
							{
								array[num18] += item4.Value[num18] / orDefault[num18];
							}
						}
					}
				}
				if (array.None((double x) => double.IsInfinity(x) || double.IsNaN(x)))
				{
					double num19 = product.GetTime(time, 0.01f) * 0.5 * (double)num15 * ((product.CreativityScore < 0.5) ? product.CreativityScore.MapRange(0.0, 0.5, 0.10000000149011612, 1.0) : 1.0) * product.GetBigProjectFactor();
					double num20 = perOSQuality[0] + perOSQuality[1] + perOSQuality[2];
					double num21 = 0.0;
					for (int num22 = 0; num22 < 3; num22++)
					{
						perOSQuality[num22] += num19 * array[num22];
						num21 += perOSQuality[num22];
					}
					product.OSSalesBoost = (float)((num20 > 0.0) ? (num21 / num20 - 1.0) : 0.0);
				}
			}
			double[] subMarket = GetSubMarket(product.Category);
			double num23 = 0.0;
			int num24 = 0;
			if (!product.OpenSource)
			{
				for (int num25 = 0; num25 < 3; num25++)
				{
					num23 += perOSQuality[num25] * subMarket[num25];
				}
				num23 *= (double)((float)MagicFactor * product.Category.GetPopularityFactor()) * product.RealQuality * num14 * (double)num15 * (1.0 + num16 * (double)(product.SubscriptionBased ? 1f : 0.5f)) * product.AddonQualityEffect * SoftwareProduct.GetCreativityFactor(product.CreativityScore, product.DevCompany.Player);
				num23 /= (double)GameSettings.DaysPerMonth;
				if (product.DevCompany.Player)
				{
					float num26 = DifficultyValues.Difficulty.RecognitionSalesFactor;
					if (product.Category.Hardware)
					{
						num26 *= 0.75f;
					}
					num23 *= (double)product.GetRep().WeightOne(num26);
				}
				int num27 = 0;
				if (product.Followers != 0)
				{
					num27 = ((product.Followers < 100) ? ((int)product.Followers) : Mathf.RoundToInt((float)product.Followers * 0.1f / (float)GameSettings.DaysPerMonth));
					if (num27 >= product.Followers)
					{
						product.Followers = 0u;
					}
					else
					{
						product.Followers -= (uint)num27;
					}
					NetworkMessaging.SendChangeFollowers(product.ID, 0u, product.Followers, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					num27 = Mathf.FloorToInt((float)num27 * num15);
					if (num27 > 0)
					{
						num24 = Utilities.RoundToInt(Utilities.Clamp01(1.0 - product.RealQuality * 2.0) * (double)num27);
					}
					if ((double)num27 > num23)
					{
						num23 = num27;
					}
				}
				uint num28 = (product.SubscriptionBased ? ((uint)product.Userbase) : product.UnitSum);
				if (type.OSSpecific)
				{
					float num29 = 0f;
					if (type.HasOSLimits())
					{
						SoftwareType softwareType = SoftwareTypes["Operating System"];
						foreach (string oSLimit in type.GetOSLimits())
						{
							num29 += (float)dictionary[softwareType.Categories[oSLimit]];
						}
					}
					else
					{
						num29 = num11;
					}
					double num30 = num23;
					num23 = ((osCov < num28) ? 0.0 : Math.Min(osCov - num28, Math.Round(num23)));
					if (!product.PlayerArchived && !product.HadOSWarning && !product.Traded && product.DevCompany.Player && num23 == 0.0 && num30 > 1000.0 && (float)osCov / num29 < 0.75f && GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().None((SoftwarePort x) => x.Product == product) && CheckAnyValidOS(product, type))
					{
						product.HadOSWarning = true;
						NotificationManager.SendNotification(new ProductDetailNotification(product, "ProductOSAudienceZero".LocColor(product), "Software", SDateTime.Now(), NotificationManager.NotificationType.Warning, "ProductOSAudienceZeroHint".Loc()), product.DevCompany.NetworkPlayerID);
					}
				}
				else
				{
					num23 = Math.Min(Math.Max(0f, product.Category.Popularity * (float)Population - (float)num28), Math.Round(num23));
				}
				num23 = Math.Max(0.0, num23);
				IStockable limiter;
				FixSales(Utilities.RoundToInt(num23), product.Category.Hardware ? 1.0 : physicalVsDigital, product.GetRefundRate(), num27, product.RealQuality, _saleScope, product, out limiter);
				product.RunScripts(ScriptSystem.EntryPoint.AfterSales, _saleScope);
				product.MissedPhysicalSales = _saleScope.MissedPhysicalSales;
				product.ChangeAllPhysicalStock(-_saleScope.PhysicalSales);
				DoOutOfStockNotification(limiter, product.DevCompany, product.Traded, PublisherDeal.HasDeal(product, "Printing"), _saleScope.MissedPhysicalSales > 0);
				HandleDigitalDistributionLimiting(_saleScope, product.DevCompany, product.ExclusiveStore);
				int num31 = _saleScope.PhysicalSales + _saleScope.DigitalSales;
				double num32 = 0.0;
				double num33 = 0.0;
				if (product.SubscriptionBased)
				{
					num33 = (float)(product.Userbase + _saleScope.DigitalSales) * product.Price;
					num32 = (float)_saleScope.PhysicalSales * product.Price;
					if (GameSettings.DaysPerMonth > 1)
					{
						num33 /= (double)GameSettings.DaysPerMonth;
						num32 /= (double)GameSettings.DaysPerMonth;
					}
				}
				else
				{
					num33 = (float)_saleScope.DigitalSales * product.Price;
					num32 = (float)_saleScope.PhysicalSales * product.Price;
				}
				double num34 = num32 + num33;
				double num35 = ((product.Publishing != null) ? (num34 * (double)product.Publishing.GetApplicableRoyalty()) : 0.0);
				double num36 = ((product.DesignerRoyalties && product.LeadDesigner != null) ? (num34 * 0.05000000074505806) : 0.0);
				double num37 = 0.0;
				if (num34 > 0.0 && product.Framework != null && product.Framework.HasToPay(product.DevCompany))
				{
					num37 = num34 * (double)product.FrameworkRoyalty;
					product.Framework.Income += (float)num37;
				}
				double num38 = num32 * (double)DistributionStandardCut;
				if (product.SubscriptionBased)
				{
					num38 *= (double)PhysicalSubscriptionCutFactor;
				}
				double digCut = 0.0;
				if (num35 > 0.0)
				{
					product.Publishing.Publisher.MakeTransaction(num35, Company.TransactionCategory.Royalties, true);
					product.Publishing.AddCut(num35);
				}
				if (num37 > 0.0)
				{
					NetworkMessaging.SendFrameworkPayment(product.Framework.ID, product.ID, (float)num37, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					product.Framework.Owner.MakeTransaction(num37, Company.TransactionCategory.Licenses, true, product.Name, true);
					product.FrameworkPayout += (float)num37;
				}
				HandleDigitalDistribution(_saleScope, product.DevCompany, product.ExclusiveStore, saleServerReq, num33, ref digCut, ref totalDigitalSales);
				double num39 = 0.0;
				if (num34 > 0.0)
				{
					product.GetRoyalties(list7);
					if (list7 != null)
					{
						for (int num40 = 0; num40 < list7.Count; num40++)
						{
							Company company = GetCompany(list7[num40].Key);
							if (company != null)
							{
								double num41 = num34 * (double)list7[num40].Value.Royalty;
								list7[num40].Value.Income += (float)num41;
								company.MakeTransaction(num41, Company.TransactionCategory.Royalties, true, product.Name, true);
								num39 += num41;
							}
						}
					}
				}
				double num42 = 0.0;
				if (product.HasWorkRoyalties)
				{
					double num43 = num34 - digCut - num38 - num39 - num35 - num36 - num37;
					if (num43 > 0.0)
					{
						foreach (KeyValuePair<Company, float> workRoyalty in product.GetWorkRoyalties())
						{
							double num44 = (double)workRoyalty.Value * num43;
							num42 += num44;
							workRoyalty.Key.MakeTransaction(num44, Company.TransactionCategory.Royalties, true, product.Name, true);
						}
					}
				}
				if (!double.IsNaN(num34) && !double.IsInfinity(num34))
				{
					product.AddLoss((float)num39, SoftwareProduct.LossType.Patents, true);
					product.AddLoss((float)num42, SoftwareProduct.LossType.Deals, true);
					product.AddLoss((float)(digCut + num38), SoftwareProduct.LossType.Distribution, true);
					product.AddLoss((float)num35, SoftwareProduct.LossType.Publisher, true);
					product.AddLoss((float)num36, SoftwareProduct.LossType.LeadDesigner, true);
					product.AddLoss((float)num37, SoftwareProduct.LossType.Framework, true);
					product.AddToCashflow(_saleScope.DigitalSales, _saleScope.PhysicalSales, _saleScope.Refunds, (float)num34, (float)(num34 - digCut - num38 - num39 - num35 - num36 - num37 - num42), 0f, time);
					product.Userbase += num31;
					ValueTuple<int, int> valueTuple = GenerateReviews(product.ID, time, product.GetReviewTargetScore(time), (uint)num31);
					product.AddReviews(valueTuple.Item1, valueTuple.Item2, time);
					if (type.OSSpecific && product.Userbase > osCov)
					{
						product.Userbase = (int)osCov;
					}
					NetworkMessaging.SendProductUserbase(product.ID, product.Userbase, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					product.DevCompany.MakeTransaction(num34, Company.TransactionCategory.Sales, true, product.SubscriptionBased ? "SubscriptionBased" : (product.Category.Hardware ? "Hardware" : "Software"), true);
					product.DevCompany.MakeTransaction(0.0 - num38, Company.TransactionCategory.Distribution, true, "Physical store cut");
					product.DevCompany.MakeTransaction(0.0 - digCut, Company.TransactionCategory.Distribution, true, "Digital store cut");
					product.DevCompany.MakeTransaction(0.0 - num39 - num35 - num37 - num36 - num42, Company.TransactionCategory.Royalties, true, product.Name);
				}
				if (product.Release.Year == time.Year - 1 && product.Release.Month == time.Month && product.Release.Day == time.Day)
				{
					product.ProfitAward = new float[2]
					{
						(float)product.Sum,
						(float)product.Loss
					};
				}
			}
			else
			{
				for (int num45 = 0; num45 < 3; num45++)
				{
					num23 += perOSQuality[num45] * subMarket[num45];
				}
				num23 *= (double)((float)MagicFactor * product.Category.GetPopularityFactor(0.15f)) * (1.0 + num16 * 0.5);
				num23 /= (double)GameSettings.DaysPerMonth;
				num23 = ((!type.OSSpecific) ? Math.Min(Math.Max(0f, product.Category.Popularity * (float)Population - (float)product.UnitSum), Math.Round(num23)) : Math.Min(Math.Max(0u, osCov - product.UnitSum), Math.Round(num23)));
				num23 = Math.Max(0.0, num23);
				IStockable limiter2;
				FixSales((int)num23, product.Category.Hardware ? 1.0 : physicalVsDigital, 0.0, 0, 1.0, _saleScope, product, out limiter2);
				product.RunScripts(ScriptSystem.EntryPoint.AfterSales, _saleScope);
				product.MissedPhysicalSales = _saleScope.MissedPhysicalSales;
				product.ChangeAllPhysicalStock(-_saleScope.PhysicalSales);
				DoOutOfStockNotification(limiter2, product.DevCompany, product.Traded, PublisherDeal.HasDeal(product, "Printing"), _saleScope.MissedPhysicalSales > 0);
				HandleDigitalDistributionLimiting(_saleScope, product.DevCompany, product.ExclusiveStore);
				double digCut2 = 0.0;
				HandleDigitalDistribution(_saleScope, product.DevCompany, product.ExclusiveStore, saleServerReq, 0.0, ref digCut2, ref totalDigitalSales);
				product.Userbase += _saleScope.DigitalSales + _saleScope.PhysicalSales;
				if (type.OSSpecific && product.Userbase > osCov)
				{
					product.Userbase = (int)osCov;
				}
				NetworkMessaging.SendProductUserbase(product.ID, product.Userbase, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				product.AddToCashflow(_saleScope.DigitalSales, _saleScope.PhysicalSales, 0, 0f, 0f, time);
			}
			if (!product.Traded && num23 > 0.0)
			{
				double num46 = 0.0;
				for (int num47 = 0; num47 < 3; num47++)
				{
					num46 += (product.Quality[num47] - 0.2) * subMarket[num47];
				}
				num46 *= product.SequelBonus;
				double num48 = (double)(_saleScope.DigitalSales + _saleScope.PhysicalSales) * num46.Clamp(-1.0, 1.0) - (double)_saleScope.Refunds;
				if (num48 > 0.0 && product.LastUpdated.HasValue)
				{
					float num49 = Mathf.Clamp01((6f - SDateTime.GetMonths(product.LastUpdated.Value, time)) / 6f);
					if (num49 > 0f)
					{
						num48 *= (double)(1f + Mathf.Sqrt(num49) * 0.25f);
					}
				}
				int num50 = Utilities.RoundToInt(num48) - num24;
				product.AddRepChange(num50, time);
				ValueTuple<int, int> valueTuple2 = GenerateReviews(product.ID, time, product.GetReviewTargetScore(time), (uint)(_saleScope.DigitalSales + _saleScope.PhysicalSales));
				product.AddReviews(valueTuple2.Item1, valueTuple2.Item2, time);
				if (product.Publishing != null)
				{
					product.Publishing.Publisher.AddFans(Mathf.RoundToInt((float)num50 * 0.75f), product.Category);
					product.DevCompany.AddFans(Mathf.RoundToInt((float)num50 * 0.25f), product.Category);
				}
				else
				{
					product.DevCompany.AddFans(num50, product.Category);
				}
			}
			product.PriceChangeFact = Mathf.Lerp(product.PriceChangeFact, 1f, t2);
			product.MaxLoadIncidents = 0;
		}
		float num51 = totalDigitalSales;
		foreach (DistributionPlatform distributionPlatform2 in DistributionPlatforms)
		{
			distributionPlatform2.MarketShare = ((num51 > 0f) ? Mathf.Clamp01(distributionPlatform2.ItemSales / num51) : 0f);
		}
		PlayerDigitalShare.RemoveAt(0);
		if (GameSettings.Instance.MyCompany.Distribution != null)
		{
			PlayerDigitalShare.Add(GameSettings.Instance.MyCompany.Distribution.MarketShare);
		}
		else
		{
			PlayerDigitalShare.Add(0f);
		}
		if (SimulateCompanies)
		{
			GenerateCompany(time);
		}
		PullSubmarkets(time);
		CalculateMaxDistDevTime();
		for (int num52 = 0; num52 < DistributionPlatforms.Count; num52++)
		{
			DistributionPlatform distributionPlatform = DistributionPlatforms[num52];
			NetworkMessaging.SendDistributionSales(distributionPlatform.Software.ID, distributionPlatform.ItemSales, distributionPlatform.ActualItemSales, totalDigitalSales, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		if (_distributionLoads.Count > 0)
		{
			foreach (KeyValuePair<byte, Dictionary<uint, float>> load in _distributionLoads)
			{
				NetworkMessaging.SendDistributionLoad(_fullDistributionLoads.ToDictionary((KeyValuePair<uint, float> x) => x.Key, (KeyValuePair<uint, float> x) => load.Value.GetOrDefault(x.Key, x.Value)), NetworkMessaging.MessageTarget.Specifically, load.Key);
			}
			_distributionLoads.Clear();
		}
		_fullDistributionLoads.Clear();
	}

	public void HandleDigitalDistributionLimiting(ScriptSystem.SaleScope scope, Company devCompany, DistributionPlatform exclusiveStore)
	{
		if (scope.DigitalSales <= 0)
		{
			return;
		}
		uint num = ((exclusiveStore != null) ? exclusiveStore.ActualUsers : EvalutateDistributionSums(devCompany.GetPlatforms()));
		if (num < scope.DigitalSales)
		{
			uint amount = (uint)(scope.DigitalSales - num);
			if (exclusiveStore != null)
			{
				PullDistributionUp(exclusiveStore, amount);
			}
			else
			{
				PullDistributionUp(devCompany.GetPlatforms(), amount);
			}
			num = ((exclusiveStore != null) ? exclusiveStore.ActualUsers : EvalutateDistributionSums(devCompany.GetPlatforms()));
			if (num < scope.DigitalSales)
			{
				scope.DigitalSales = (int)num;
			}
		}
	}

	public void HandleDigitalDistribution(ScriptSystem.SaleScope scope, Company devCompany, DistributionPlatform exclusiveStore, float saleServerReq, double digitalMoney, ref double digCut, ref uint totalDigitalSales)
	{
		if (scope.DigitalSales <= 0)
		{
			return;
		}
		List<DistributionPlatform> platforms = devCompany.GetPlatforms();
		uint num = ((exclusiveStore != null) ? exclusiveStore.ActualUsers : platforms.SumSafe((DistributionPlatform x) => x.ActualUsers));
		if (num == 0)
		{
			return;
		}
		int num2 = ((exclusiveStore != null) ? 1 : platforms.Count);
		bool flag = false;
		for (int num3 = 0; num3 < num2; num3++)
		{
			DistributionPlatform distributionPlatform;
			if (exclusiveStore != null)
			{
				distributionPlatform = exclusiveStore;
			}
			else
			{
				if (num3 >= platforms.Count)
				{
					break;
				}
				distributionPlatform = platforms[num3];
			}
			float num4 = (float)distributionPlatform.ActualUsers / (float)num;
			uint num5 = (uint)((float)scope.DigitalSales * num4);
			double num6 = 1.0;
			if (distributionPlatform.Owner.Player)
			{
				distributionPlatform.ActualItemSales += num5;
				float num7 = (float)num5 * saleServerReq;
				if (num7 > distributionPlatform.AvailableBandwidth)
				{
					num6 = Mathf.Clamp01(1f - (num7 - distributionPlatform.AvailableBandwidth) / num7);
					distributionPlatform.AvailableBandwidth = 0f;
				}
				else
				{
					distributionPlatform.AvailableBandwidth -= num7;
					num6 = 1.0;
				}
				num5 = (uint)((double)num5 * num6);
				if (distributionPlatform.Owner.LocalPlayer)
				{
					devCompany.AddDistributionLoad((float)num5 * 0.05f);
					flag = true;
				}
				else
				{
					_distributionLoads.GetOrAdd(distributionPlatform.Owner.NetworkPlayerID, (byte x) => new Dictionary<uint, float>()).AddUp(devCompany.ID, (float)num5 * 0.05f);
				}
			}
			distributionPlatform.ItemSales += num5;
			totalDigitalSales += num5;
			if (digitalMoney > 0.0 && distributionPlatform.HasToPay(devCompany))
			{
				double num8 = digitalMoney * (double)num4 * num6 * (double)distributionPlatform.GetCut();
				digCut += num8;
				distributionPlatform.Owner.MakeTransaction(num8, Company.TransactionCategory.Distribution, true, "Digital store", true);
			}
		}
		_fullDistributionLoads[devCompany.ID] = (float)scope.DigitalSales * 0.05f;
		if (!flag)
		{
			devCompany.AddDistributionLoad((float)scope.DigitalSales * 0.05f);
		}
	}

	private bool CheckAnyValidOS(SoftwareProduct product, SoftwareType type)
	{
		IEnumerable<SoftwareProduct> enumerable = from x in GetProductsWithMock(false)
			where x.Type.Name.Equals("Operating System")
			select x;
		if (type.HasOSLimits())
		{
			enumerable = enumerable.Where((SoftwareProduct x) => type.SupportsOS(x.Category.Name));
		}
		foreach (SoftwareProduct item in enumerable)
		{
			if (item.Userbase >= 1000 && !product.HasOS(item))
			{
				return true;
			}
		}
		return false;
	}

	public List<SoftwareProduct> GetCompatibleOS(uint p, bool withMock = false)
	{
		return GetCompatibleOS(GetProduct(p, withMock), withMock);
	}

	public List<SoftwareProduct> GetCompatibleOS(SoftwareProduct p, bool withMock = false, List<SoftwareProduct> reusableList = null)
	{
		CompatibleCache.Clear();
		if (p.OSCount > 0)
		{
			foreach (SoftwareProduct item in p.GetOSs())
			{
				if (item != null && (withMock || !item.IsMock))
				{
					CompatibleCache.Add(item);
					GetSequels(item, CompatibleCache, 3);
				}
			}
			if (reusableList != null)
			{
				reusableList.AddRange(CompatibleCache);
				return reusableList;
			}
		}
		return CompatibleCache.ToList();
	}

	public void GetSequels(SoftwareProduct p, HashSet<SoftwareProduct> output, int limit = -1, bool sameCategory = true)
	{
		SoftwareProduct sequel = p.Sequel;
		int num = limit;
		while (sequel != null && num != 0)
		{
			if (!sameCategory || sequel.Category.Equals(p.Category))
			{
				output.Add(sequel);
			}
			sequel = sequel.Sequel;
			num--;
		}
	}

	public bool IsCompatibleOS(SoftwareProduct p, SoftwareProduct os, bool withMock = false)
	{
		foreach (SoftwareProduct item in p.GetOSs())
		{
			if (item != null && (withMock || !item.IsMock) && (item == os || CheckInSequels(item, p, 3)))
			{
				return true;
			}
		}
		return false;
	}

	public bool CheckInSequels(SoftwareProduct p, SoftwareProduct against, int limit = -1, bool sameCategory = true)
	{
		SoftwareProduct sequel = p.Sequel;
		int num = limit;
		while (sequel != null && num != 0)
		{
			if ((!sameCategory || sequel.Category.Equals(p.Category)) && sequel == against)
			{
				return true;
			}
			sequel = sequel.Sequel;
			num--;
		}
		return false;
	}

	public uint GetOSCoverage(IEnumerable<SoftwareProduct> OSs)
	{
		CoverageCache.Clear();
		uint num = 0u;
		foreach (SoftwareProduct item in OSs)
		{
			SoftwareProduct softwareProduct = item;
			int num2 = 4;
			while (softwareProduct != null && num2 != 0 && !CoverageCache.Contains(softwareProduct))
			{
				CoverageCache.Add(softwareProduct);
				if (softwareProduct.Category.Equals(item.Category))
				{
					num += (uint)GetUserBase(softwareProduct);
				}
				softwareProduct = softwareProduct.Sequel;
				num2--;
			}
		}
		return num;
	}

	private int GetUserBase(SoftwareProduct os)
	{
		if (!os.IsMock)
		{
			return os.Userbase;
		}
		if (os.MockWork == null)
		{
			return os.MockSucceeded.Userbase;
		}
		return Mathf.FloorToInt(os.MockWork.Followers);
	}

	private void GenerateCompany(SDateTime time)
	{
		foreach (CompanyType item in CompanyTypes.Values.Where((CompanyType x) => x.IsValid(time.Year)))
		{
			CompanyType type1 = item;
			int num = Companies.Values.Count((SimulatedCompany x) => x.Type == type1 && !x.IsPlayerOwned(false));
			if (num < item.Max || item.Max == 0)
			{
				int value;
				if (!_spawnGrace.TryGetValue(item, out value) || value <= 0)
				{
					if (num < item.Min || Random.NextDouble() < (double)(item.PerYear / (12f * (float)GameSettings.DaysPerMonth)))
					{
						_spawnGrace[item] = 6 * GameSettings.DaysPerMonth;
						SimulatedCompany simulatedCompany = new SimulatedCompany(GenerateCompanyName(item.NameGen), time, item, item.GetTypes(), Utilities.RandomGaussClamped(Mathf.Clamp01(DifficultyValues.Difficulty.AICompanyAverageSavy), 0.15f, Random), this);
						AddCompany(simulatedCompany);
						simulatedCompany.GenerateLogo();
						NetworkMessaging.SendAddSimulatedCompany(simulatedCompany.ID, simulatedCompany.Name, simulatedCompany.Founded, simulatedCompany.Money, item.Name, simulatedCompany.AverageQuality, simulatedCompany.BusinessSavy, simulatedCompany.Logo, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						simulatedCompany.InitialLeadDesigner(item, time);
						NetworkMessaging.MoveLeadDesigner(simulatedCompany.LeadDesigner, simulatedCompany, true, false);
					}
				}
				else
				{
					_spawnGrace[item] = _spawnGrace.GetOrDefault(item, 6 * GameSettings.DaysPerMonth) - 1;
				}
			}
			else
			{
				_spawnGrace[item] = 6 * GameSettings.DaysPerMonth;
			}
		}
	}

	public string GenerateCompanyName(string nameGen)
	{
		RandomNameGenerator randomNameGenerator = RNG[nameGen ?? "Company"];
		if (randomNameGenerator.FailCount > 3)
		{
			randomNameGenerator = GameData.GetStaticNameGenerator("Company");
		}
		string[] result = new string[1] { randomNameGenerator.GenerateName(Random) };
		int num = 0;
		while (AllCompanies.Any((Company x) => x.Name.Equals(result[0])))
		{
			if (num > 10000)
			{
				randomNameGenerator.FailCount++;
				Debug.Log("Tried 10,000 times to find company name and failed");
				while (AllCompanies.Any((Company x) => x.Name.Equals(result[0])))
				{
					result[0] = result[0] + "E";
				}
				return result[0];
			}
			result[0] = randomNameGenerator.GenerateName(Random);
			num++;
		}
		return result[0];
	}

	public string GeneratePlatformName(System.Random rnd = null)
	{
		rnd = rnd ?? Random;
		RandomNameGenerator nameGen = DigitalDistSoft.Categories.Values.First().GetNameGen(RNG);
		string text = nameGen.GenerateName(rnd);
		HashSet<string> hashSet = DistributionPlatforms.Select((DistributionPlatform x) => x.Software.Name).ToHashSet();
		for (int num = 0; num < 500; num++)
		{
			if (!hashSet.Contains(text))
			{
				return text;
			}
			text = nameGen.GenerateName(rnd);
		}
		Debug.Log("Tried 500 times to generate platform name and failed!");
		return text;
	}

	public string GenerateProductName(SoftwareCategory cat, System.Random rnd = null, bool presim = false)
	{
		rnd = rnd ?? Random;
		RandomNameGenerator nameGen = cat.GetNameGen(RNG);
		string text = nameGen.GenerateName(rnd);
		if (nameGen.FailCount > 3)
		{
			return text;
		}
		HashSet<string> hashSet = (from x in GetProductsWithMock(true)
			select x.Name).ToHashSet();
		if (!presim)
		{
			hashSet.AddRange(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>()
				where !x.AddOn
				select x.SoftwareName);
		}
		hashSet.AddRange(Companies.Values.SelectMany((SimulatedCompany x) => x.Releases.Select((SimulatedCompany.ProductPrototype z) => z.Name)));
		hashSet.AddRange(Companies.Values.SelectMany((SimulatedCompany x) => x.ProjectQueue.Select((SimulatedCompany.ProductPrototype z) => z.Name)));
		for (int num = 0; num < 1000; num++)
		{
			if (!hashSet.Contains(text))
			{
				nameGen.FailCount = 0;
				return text;
			}
			text = nameGen.GenerateName(rnd);
		}
		nameGen.FailCount++;
		Debug.Log("Tried 1000 times to generate product name and failed!");
		return text;
	}

	public string GenerateAddonName(SoftwareProduct p, SoftwareProduct sequelTo, SoftwareAddOn addon, bool forced, System.Random rnd = null, bool presim = false)
	{
		rnd = rnd ?? Random;
		SoftwareProduct softwareProduct = p;
		List<AddOnProduct> list = ((softwareProduct != null) ? softwareProduct.Addons.GetOrNull(addon) : null);
		HashSet<string> hashSet = ((list == null) ? new HashSet<string>() : list.Select((AddOnProduct x) => x.Name).ToHashSet());
		if (!presim)
		{
			hashSet.AddRange(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>()
				where x.AddOn && x.AddonParent == p
				select x.SoftwareName);
		}
		if (forced && ((sequelTo != null) ? sequelTo.ForcedAddons : null) != null)
		{
			AddOnProduct addOnProduct = sequelTo.ForcedAddons.FirstOrDefault((AddOnProduct x) => x.Type == addon);
			if (addOnProduct != null)
			{
				KeyValuePair<string, int> versionString = GetVersionString(addOnProduct.Name);
				int num = versionString.Value;
				string text = versionString.Key + " " + num;
				while (hashSet.Contains(text))
				{
					num++;
					text = versionString.Key + " " + num;
				}
				return text;
			}
		}
		RandomNameGenerator nameGen = addon.GetNameGen(RNG);
		string text2 = nameGen.GenerateName(rnd);
		for (int num2 = 0; num2 < 1000; num2++)
		{
			if (!hashSet.Contains(text2))
			{
				return text2;
			}
			text2 = nameGen.GenerateName(rnd);
		}
		Debug.Log("Tried 1000 times to generate product name and failed!");
		return text2;
	}

	public string GenerateFrameworkName(System.Random rnd = null)
	{
		rnd = rnd ?? Random;
		RandomNameGenerator randomNameGenerator = RNG["Framework"];
		string text = randomNameGenerator.GenerateName(rnd);
		HashSet<string> hashSet = Frameworks.Select((SoftwareFramework x) => x.Name).ToHashSet();
		for (int num = 0; num < 1000; num++)
		{
			if (!hashSet.Contains(text))
			{
				return text;
			}
			text = randomNameGenerator.GenerateName(rnd);
		}
		Debug.Log("Tried 1000 times to generate product name and failed!");
		return text;
	}

	public string GenerateProductSequalName(string input, bool force = false)
	{
		HashSet<string> hashSet = (from x in GetProductsWithMock(true)
			select x.Name).ToHashSet();
		hashSet.AddRange(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>()
			where !x.AddOn
			select x.SoftwareName);
		hashSet.AddRange(Companies.Values.SelectMany((SimulatedCompany x) => x.Releases.Select((SimulatedCompany.ProductPrototype z) => z.Name)));
		hashSet.AddRange(Companies.Values.SelectMany((SimulatedCompany x) => x.ProjectQueue.Select((SimulatedCompany.ProductPrototype z) => z.Name)));
		KeyValuePair<string, int> versionString = GetVersionString(input);
		int num = versionString.Value;
		if (force)
		{
			input = versionString.Key + " " + num;
		}
		while (hashSet.Contains(input))
		{
			input = versionString.Key + " " + num;
			num++;
		}
		return input;
	}

	public KeyValuePair<string, int> GetVersionString(string input)
	{
		string[] array = input.Split(' ');
		string key;
		int result;
		if (array.Length > 1 && int.TryParse(array[array.Length - 1], out result))
		{
			key = string.Join(" ", array.Take(array.Length - 1).ToArray());
			result++;
		}
		else
		{
			key = input;
			result = 2;
		}
		return new KeyValuePair<string, int>(key, result);
	}

	public uint GetFollowerReach(SoftwareType type, SoftwareCategory category, IEnumerable<SoftwareProduct> OSs)
	{
		uint reach = type.GetReach(category, OSs);
		uint num = (uint)((float)FollowerPopulation * category.Popularity);
		if (num >= reach)
		{
			return reach;
		}
		return num;
	}

	public void TurnLoss()
	{
		foreach (KeyValuePair<uint, SoftwareProduct> product in Products)
		{
			product.Value.TurnLoss();
		}
	}
}
