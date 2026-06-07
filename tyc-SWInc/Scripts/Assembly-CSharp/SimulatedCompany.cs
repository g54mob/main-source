using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using SINetworking;
using UnityEngine;

[AltDeprecate("DistributionDealKnockoff", typeof(float))]
[AltDeprecate("_playerDistributionCounter", typeof(int))]
[AltDeprecate("WantsPlayerDistribution", typeof(bool))]
[AltDeprecate("_playerAcceptRate", typeof(float))]
public class SimulatedCompany : Company
{
	public interface IProjectPrototype
	{
		string GetName();

		string GetSWType();

		string GetCategory();

		Company GetDevCompany();

		SDateTime? GetReleaseDate();

		void RemoveProject(bool fromNetwork = false);
	}

	[Serializable]
	public class ProductPrototype : IStockable, ILossable, IReferenceFix, IFormatColorObject, ICalenderItem, IProjectPrototype
	{
		public readonly string Name;

		public SoftwareType Type;

		public SoftwareCategory Category;

		public SoftwareProduct SequelTo;

		public SoftwareFramework Framework;

		public readonly string NewFramework;

		public float FrameworkRoyalty;

		public readonly Dictionary<string, SoftwareProduct> Needs;

		[AltWasFloat(0)]
		public double CreativityScore = 0.5;

		public Dictionary<SoftwareProduct, float> Tools = new Dictionary<SoftwareProduct, float>();

		public SoftwareProduct[] OSs;

		public FeatureBase[] Features;

		public Dictionary<string, TechLevel> Techs;

		public readonly float Price;

		public readonly bool SubscriptionBased;

		[AltWasFloat(0)]
		public readonly double[] Submarkets;

		[AltWasFloat(0)]
		public double CodeProgress;

		[AltWasFloat(0)]
		public double ArtProgress;

		[AltWasFloat(0)]
		public double CodeQuality;

		[AltWasFloat(0)]
		public double ArtQuality;

		[AltWasFloat(0)]
		public double Quality;

		[AltWasFloat(0)]
		public double Loss;

		public SDateTime DevStart;

		public readonly bool InHouse;

		public readonly float Reception;

		public readonly float DevTime;

		public int DevTeam;

		public float DevTimeLeft;

		public SDateTime ReleaseDate;

		public SimulatedCompany DevCompany;

		public uint? SWID;

		public bool Released;

		public bool DevStarted;

		private int _hardwareMask;

		private int _hardwareInputMask;

		private float _hardwarePrice;

		public SoftwareProduct Final;

		public bool PrintDeal;

		[NameRedirection(new string[] { "<PhysicalCopies>k__BackingField" })]
		private uint _physicalCopies;

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

		public bool StockNotifications
		{
			get
			{
				return false;
			}
		}

		public IStockable DeferStock
		{
			get
			{
				IStockable final = Final;
				return final ?? this;
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
				if (SWID.HasValue)
				{
					NetworkMessaging.SendChangePhysicalCopies(SWID.Value, 0u, value, DevCompany.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				_physicalCopies = value;
			}
		}

		public void ChangePhysicalCopiesDirectly(uint newValue)
		{
			_physicalCopies = newValue;
		}

		public uint ForceID()
		{
			if (!SWID.HasValue)
			{
				SWID = GameSettings.Instance.simulation.GetID();
			}
			return SWID.Value;
		}

		public bool IsInDeal()
		{
			if (HUD.Instance != null)
			{
				return HUD.Instance.dealWindow.IsInDeal(this, DevCompany);
			}
			return false;
		}

		public float GetCodeArtRatio()
		{
			return SoftwareType.CodeArtRatio(Features);
		}

		public void SendNetwork()
		{
			if (GameSettings.Instance.IsNetworkMode)
			{
				string name = Name;
				uint id = ForceID();
				uint iD = Type.ID;
				uint iD2 = Category.ID;
				Dictionary<string, uint> needs = Needs.ToDictionary((KeyValuePair<string, SoftwareProduct> x) => x.Key, (KeyValuePair<string, SoftwareProduct> x) => x.Value.ID);
				SoftwareProduct[] oSs = OSs;
				uint[] os = ((oSs != null) ? oSs.SelectInPlace((SoftwareProduct x) => x.ID) : null);
				double codeProgress = CodeProgress;
				double artProgress = ArtProgress;
				double codeQuality = CodeQuality;
				double artQuality = ArtQuality;
				float price = Price;
				bool subscriptionBased = SubscriptionBased;
				double[] submarkets = Submarkets;
				uint iD3 = DevCompany.ID;
				bool inHouse = InHouse;
				float reception = Reception;
				SoftwareProduct sequelTo = SequelTo;
				uint sequelTo2 = ((sequelTo != null) ? sequelTo.ID : 0);
				uint[] feats = Features.SelectInPlace((FeatureBase x) => x.ID);
				Dictionary<string, int> techs = Techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.Year);
				double loss = Loss;
				SoftwareFramework framework = Framework;
				NetworkMessaging.SendProductPrototype(name, id, iD, iD2, needs, os, codeProgress, artProgress, codeQuality, artQuality, price, subscriptionBased, submarkets, iD3, inHouse, reception, sequelTo2, feats, techs, loss, (framework != null) ? framework.ID : 0u, NewFramework, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}

		public ProductPrototype(string name, uint id, uint type, uint category, Dictionary<string, uint> needs, uint[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, bool subscription, double[] submarkets, uint company, bool inHouse, float reception, uint sequelTo, uint[] feats, Dictionary<string, int> techs, double loss, uint framework, string newFramework)
		{
			Name = name;
			Type = MarketSimulation.Active.GetSoftwareType(type);
			SWID = id;
			Category = Type.GetCategory(category);
			SequelTo = MarketSimulation.Active.GetProduct(sequelTo, false);
			Submarkets = submarkets;
			Needs = needs.ToDictionary((KeyValuePair<string, uint> x) => x.Key, (KeyValuePair<string, uint> x) => MarketSimulation.Active.GetProduct(x.Value, false));
			OSs = ((os != null) ? os.SelectInPlace((uint x) => MarketSimulation.Active.GetProduct(x, false)) : null);
			CodeProgress = codeProgress;
			ArtProgress = artProgress;
			CodeQuality = codeQuality;
			ArtQuality = artQuality;
			Price = price;
			SubscriptionBased = subscription;
			InHouse = inHouse;
			Reception = reception;
			Features = feats.SelectInPlace((uint x) => Type.GetFeature(x));
			Techs = techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => MarketSimulation.Active.GetTechLevel(x.Key, x.Value));
			Loss = loss;
			DevCompany = MarketSimulation.Active.GetCompany(company) as SimulatedCompany;
			Framework = MarketSimulation.Active.GetFramework(framework);
			FrameworkRoyalty = Framework.Royalty();
			NewFramework = newFramework;
			DevTime = Type.DevTime(Features, Category, DevCompany, Techs, OSs, Framework, NewFramework != null, SequelTo);
			Quality = Utilities.Clamp01(Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
			if (Category.Hardware)
			{
				Category.Manufacturing.GetProcessInfo(Features, null, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
				if (Price < _hardwarePrice)
				{
					Price = _hardwarePrice * 1.25f;
				}
			}
		}

		public void SetQuality(double codeP, double artP, double codeQ, double artQ, bool fromNetwork = false)
		{
			if (!fromNetwork && SWID.HasValue)
			{
				NetworkMessaging.SendUpdateProtoQuality(DevCompany.ID, SWID.Value, codeP, artP, codeQ, artQ, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			CodeProgress = codeP;
			ArtProgress = artP;
			CodeQuality = codeQ;
			ArtQuality = artQ;
			Quality = Utilities.Clamp01(Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
		}

		public ProductPrototype(string name, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] os, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, bool subscription, double[] submarkets, SimulatedCompany company, bool inHouse, float reception, SoftwareProduct sequelTo, FeatureBase[] feats, Dictionary<string, TechLevel> techs, double loss, SoftwareFramework framework, string newFramework)
		{
			Name = name;
			Type = type;
			Category = category;
			SequelTo = sequelTo;
			Submarkets = submarkets;
			Needs = needs;
			OSs = os;
			CodeProgress = codeProgress;
			ArtProgress = artProgress;
			CodeQuality = codeQuality;
			ArtQuality = artQuality;
			Price = price;
			SubscriptionBased = subscription;
			InHouse = inHouse;
			Reception = reception;
			Features = feats;
			Techs = techs;
			Loss = loss;
			DevCompany = company;
			Framework = framework;
			FrameworkRoyalty = Framework.Royalty();
			NewFramework = newFramework;
			DevTime = Type.DevTime(Features, Category, company, techs, OSs, Framework, NewFramework != null, sequelTo);
			Quality = Utilities.Clamp01(Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
			if (category.Hardware)
			{
				category.Manufacturing.GetProcessInfo(Features, null, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
				if (Price < _hardwarePrice)
				{
					Price = _hardwarePrice * 1.25f;
				}
			}
		}

		public void StartDev(SDateTime start, SDateTime releaseDate, bool fromNetwork = false)
		{
			if (!fromNetwork && SWID.HasValue)
			{
				NetworkMessaging.SendStartDev(DevCompany.ID, SWID.Value, start, releaseDate, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			DevStart = start;
			ReleaseDate = releaseDate;
			DevTimeLeft = SDateTime.GetMonthsFlat(start, releaseDate);
			DevCompany._focus -= DevCompany.Type.GetEffort(Type.Name, Category.Name);
			DevStarted = true;
			DevCompany.ProjectQueue.Remove(this);
			lock (DevCompany.Releases)
			{
				DevCompany.Releases.Add(this);
			}
			if (Type.OSSpecific && OSs != null)
			{
				int workers = SoftwareType.GetOptimalEmployeeCount(DevTime)[1];
				DevCompany.UpdateOSLicenses(OSs.Where((SoftwareProduct x) => x.HasToPay(DevCompany)).ToDictionary((SoftwareProduct x) => x, (SoftwareProduct x) => workers), fromNetwork);
			}
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				DevCompany.AddLicense(need.Value, this);
			}
			if (OSs != null && OSs.Length != 0)
			{
				GameSettings.Instance.simulation.RegisterOSSupport(Category, OSs);
			}
		}

		public ProductPrototype()
		{
		}

		public void RemoveProject(bool fromNetwork = false)
		{
			if (!fromNetwork && SWID.HasValue)
			{
				NetworkMessaging.SendReleaseDev(DevCompany.ID, SWID.Value, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			if (DevStarted)
			{
				DevCompany.FreeFocus(this);
				DevCompany.Releases.Remove(this);
				{
					foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
					{
						DevCompany.RemoveLicense(need.Value, this);
					}
					return;
				}
			}
			DevCompany.ProjectQueue.Remove(this);
		}

		public SoftwareProduct ToProduct(SDateTime time, Employee leadDesigner)
		{
			if (SequelTo != null && SequelTo.DesignerOwned)
			{
				leadDesigner = SequelTo.LeadDesigner;
			}
			Released = true;
			int bugs = Mathf.FloorToInt(Utilities.RandomGaussClamped(DevCompany.BusinessSavy, 0.1f, MarketSimulation.Active.Random) * DevTime * 50f);
			uint followers = (uint)((float)GameSettings.Instance.simulation.GetFollowerReach(Type, Category, OSs) * 0.1f * Reception);
			bool oSSpecific = Type.OSSpecific;
			FeatureBase[] array = Type.FixUp(Features, Category, Techs);
			float num = Mathf.Max(0.01f, 1f - DevTimeLeft / Mathf.Max(1f, SDateTime.GetMonthsFlat(DevStart, ReleaseDate)));
			double num2 = SoftwareAlpha.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Type, array);
			if (GameSettings.DaysPerMonth > 1 && time.Day == GameSettings.DaysPerMonth - 1)
			{
				time -= new SDateTime(0, 1, 0, 0, 0);
			}
			if (leadDesigner != null)
			{
				leadDesigner.LeadSpecializationFix[Type.Name] = 1f;
			}
			SoftwareProduct softwareProduct = new SoftwareProduct(Name, Type, Category, oSSpecific ? OSs : null, (double)num * CodeProgress, (double)num * ArtProgress, CodeQuality, ArtQuality, new double[3] { num2, num2, num2 }, (leadDesigner != null) ? leadDesigner.Creativity : 0.5f, Price, SubscriptionBased, Submarkets, DevStart, time, bugs, InHouse, DevCompany, SequelTo, SWID ?? GameSettings.Instance.simulation.GetID(), Loss, array, Techs, null, followers, Framework, FrameworkRoyalty, Tools);
			softwareProduct.SendNetwork();
			softwareProduct.PhysicalCopies += PhysicalCopies;
			if (NewFramework != null)
			{
				SoftwareWorkItem.FeatureProgress[] array2 = SoftwareWorkItem.GenerateProgress(Type, Category, DevCompany, array, Techs, null, SequelTo, true, null);
				SoftwareWorkItem.FeatureProgress[] array3 = array2;
				foreach (SoftwareWorkItem.FeatureProgress obj in array3)
				{
					obj.Progress = obj.CDevTime;
					obj.ArtProgress = obj.ADevTime;
				}
				GameSettings.Instance.simulation.CreateFramework(NewFramework, DevCompany, Type, Category, array2, Techs, time);
			}
			Final = softwareProduct;
			List<AddOnProduct> list = null;
			foreach (SoftwareAddOn item in from x in Type.GetValidAddons(Category, Techs, Features, time)
				where x.Forced.HasValue
				select x)
			{
				List<AddOnFeature> list2 = new List<AddOnFeature>();
				List<uint> list3 = new List<uint>();
				System.Random random = MarketSimulation.Active.Random;
				item.GenerateFeatures(array, Techs, Submarkets, Category, random, list2, list3);
				AddOnProduct addOnProduct = new AddOnProduct(MarketSimulation.Active.GenerateAddonName(Final, Final.SequelTo, item, true, random), item, Final, list2.ToArray(), list3.ToArray(), DevStart, ReleaseDate, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(item) * item.PerceivedValue(list2, list3, Category, Techs)), 0.0, new double[3] { num2, num2, num2 }, DevCompany, 0u, 0f, followers, CodeProgress, ArtProgress, CodeQuality, ArtQuality, true);
				addOnProduct.SendNetwork();
				DevCompany.AddOns.Add(addOnProduct);
				GameSettings.Instance.simulation.AddAddOn(addOnProduct);
				if (list == null)
				{
					list = new List<AddOnProduct>();
				}
				list.Add(addOnProduct);
				AddOnProduct.HandleNews(addOnProduct, false);
			}
			if (list != null)
			{
				Final.ForcedAddons = list.ToArray();
				Final.UpdateForcedAddonQualityEffect();
			}
			GameSettings.Instance.MoveStorage(this, softwareProduct);
			if (leadDesigner != null)
			{
				leadDesigner.FinishLeadProject(softwareProduct, 1f, true, MarketSimulation.Active.Random.Next());
			}
			SoftwareProduct.HandleNews(softwareProduct, false);
			softwareProduct.RunReleaseScripts();
			return softwareProduct;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetIdentifyingName()
		{
			return Name;
		}

		public void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
		{
			lock (this)
			{
				Loss += cost;
			}
		}

		public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
		{
			Tools.AddUp(tool, cost);
		}

		public float GetLicenseAmount()
		{
			if (DevTeam == 0)
			{
				DevTeam = SoftwareType.GetOptimalEmployeeCount(DevTime)[1];
			}
			return DevTeam;
		}

		public string GetCompanyName()
		{
			return DevCompany.Name;
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
			return 0;
		}

		public uint GetTotalPhysicalSales()
		{
			return 0u;
		}

		public int GetSalesMonths()
		{
			return 0;
		}

		public int GetLastMissedPhysicalSales()
		{
			return 0;
		}

		public uint GetReach()
		{
			return Type.GetReach(Category, OSs);
		}

		public float GetRealQuality()
		{
			return (float)Quality;
		}

		public uint GetFollowers()
		{
			return (uint)((float)GameSettings.Instance.simulation.GetFollowerReach(Type, Category, OSs) * 0.1f * Reception);
		}

		public string GetActualString()
		{
			return Name;
		}

		public string GetTitle()
		{
			return Name;
		}

		public string GetDescription()
		{
			return Category.GetActualString() + "\n" + DevCompany.Name;
		}

		public SDateTime? GetTime()
		{
			return ReleaseDate;
		}

		public ComingReleaseWindow.EventType GetEventType()
		{
			if (!DevCompany.IsPlayerOwned())
			{
				return ComingReleaseWindow.EventType.AIRelease;
			}
			return ComingReleaseWindow.EventType.SubsidiaryRelease;
		}

		public bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
		{
			if (t == null || t == Type)
			{
				if (c != null)
				{
					return c == Category;
				}
				return true;
			}
			return false;
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
			return null;
		}

		public string GetSWType()
		{
			return Type.GetActualString();
		}

		public string GetCategory()
		{
			return Category.Name.LocSWC(Category.Parent.Name);
		}

		public Company GetDevCompany()
		{
			return DevCompany;
		}

		public SDateTime? GetReleaseDate()
		{
			if (!DevStarted)
			{
				return null;
			}
			return ReleaseDate;
		}

		public IProductOrder PromoteHardware(uint copies)
		{
			return ManufactureOrder.PromoteProduct(this, copies);
		}

		public IReferenceFix FixReferences()
		{
			if (SWID.HasValue)
			{
				SimulatedCompany simulatedCompany;
				if ((simulatedCompany = MarketSimulation.Active.GetCompany(DevCompany.ID) as SimulatedCompany) != null)
				{
					return simulatedCompany.GetPrototype(SWID.Value);
				}
				return MarketSimulation.Active.GetProduct(SWID.Value, false);
			}
			return null;
		}
	}

	[Serializable]
	public class AddonPrototype : IStockable, ILossable, IReferenceFix, IFormatColorObject, IProjectPrototype
	{
		public readonly string Name;

		public readonly SoftwareAddOn Type;

		public readonly SoftwareProduct Parent;

		public readonly Dictionary<string, SoftwareProduct> Needs;

		public Dictionary<SoftwareProduct, float> Tools = new Dictionary<SoftwareProduct, float>();

		public readonly AddOnFeature[] Features;

		public readonly uint[] FeatureFactors;

		public readonly float Price;

		[AltWasFloat(0)]
		public double CodeProgress;

		[AltWasFloat(0)]
		public double ArtProgress;

		[AltWasFloat(0)]
		public double CodeQuality;

		[AltWasFloat(0)]
		public double ArtQuality;

		[AltWasFloat(0)]
		public double Quality;

		[AltWasFloat(0)]
		public double Loss;

		public float DistributionLoss;

		public SDateTime DevStart;

		public readonly float Reception;

		public readonly float DevTime;

		public int DevTeam;

		public SDateTime ReleaseDate;

		public SimulatedCompany DevCompany;

		public bool Released;

		private int _hardwareMask;

		private int _hardwareInputMask;

		private float _hardwarePrice;

		public AddOnProduct Final;

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

		public uint PhysicalCopies { get; set; }

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

		public bool StockNotifications
		{
			get
			{
				return false;
			}
		}

		public IStockable DeferStock
		{
			get
			{
				IStockable final = Final;
				return final ?? this;
			}
		}

		public SoftwareType SWType
		{
			get
			{
				return Parent.Type;
			}
		}

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

		public IList<FeatureBase> FeaturesBases
		{
			get
			{
				return Features;
			}
		}

		public void SendNetwork()
		{
			if (NetworkManager.IsConnected)
			{
				NetworkMessaging.SendAddonPrototype(Name, Type.ID, Parent.ID, Needs.ToDictionary((KeyValuePair<string, SoftwareProduct> x) => x.Key, (KeyValuePair<string, SoftwareProduct> x) => x.Value.ID), CodeProgress, ArtProgress, CodeQuality, ArtQuality, Price, DevCompany.ID, Reception, Features.SelectInPlace((AddOnFeature x) => x.ID), FeatureFactors, Loss, ReleaseDate, DevStart, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}

		public AddonPrototype()
		{
		}

		public AddonPrototype(string name, uint type, uint parent, Dictionary<string, uint> needs, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, uint company, float reception, uint[] feats, uint[] factors, double loss, SDateTime releaseDate, SDateTime devStart)
		{
			Name = name;
			Parent = MarketSimulation.Active.GetProduct(parent, false);
			Type = Parent.Type.GetAddon(type);
			Needs = needs.ToDictionary((KeyValuePair<string, uint> x) => x.Key, (KeyValuePair<string, uint> x) => MarketSimulation.Active.GetProduct(x.Value, false));
			CodeProgress = codeProgress;
			ArtProgress = artProgress;
			CodeQuality = codeQuality;
			ArtQuality = artQuality;
			Price = price;
			Reception = reception;
			Features = feats.SelectInPlace((uint x) => Type.GetFeature(x));
			FeatureFactors = factors;
			Loss = loss;
			DevCompany = MarketSimulation.Active.GetCompany(company) as SimulatedCompany;
			DevTime = Type.DevTime(Features, FeatureFactors, Parent.Category, DevCompany, Parent.TechLevels);
			Quality = Utilities.Clamp01(Parent.Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
			ReleaseDate = releaseDate;
			DevStart = devStart;
			if (Type.Hardware)
			{
				Type.Manufacturing.GetProcessInfo(Features, FeatureFactors, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
				if (Price < _hardwarePrice)
				{
					Price = _hardwarePrice * 1.25f;
				}
			}
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				DevCompany.AddLicense(need.Value, this);
			}
		}

		public AddonPrototype(string name, SoftwareAddOn type, SoftwareProduct parent, Dictionary<string, SoftwareProduct> needs, double codeProgress, double artProgress, double codeQuality, double artQuality, float price, SimulatedCompany company, float reception, AddOnFeature[] feats, uint[] factors, double loss, SDateTime releaseDate, SDateTime devStart)
		{
			Name = name;
			Type = type;
			Parent = parent;
			Needs = needs;
			CodeProgress = codeProgress;
			ArtProgress = artProgress;
			CodeQuality = codeQuality;
			ArtQuality = artQuality;
			Price = price;
			Reception = reception;
			Features = feats;
			FeatureFactors = factors;
			Loss = loss;
			DevCompany = company;
			DevTime = Type.DevTime(Features, FeatureFactors, Parent.Category, company, Parent.TechLevels);
			Quality = Utilities.Clamp01(Parent.Type.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Features));
			ReleaseDate = releaseDate;
			DevStart = devStart;
			if (Type.Hardware)
			{
				Type.Manufacturing.GetProcessInfo(Features, FeatureFactors, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
				if (Price < _hardwarePrice)
				{
					Price = _hardwarePrice * 1.25f;
				}
			}
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				DevCompany.AddLicense(need.Value, this);
			}
		}

		public AddOnProduct ToProduct(SDateTime time)
		{
			Released = true;
			uint followers = (uint)((float)GameSettings.Instance.simulation.GetFollowerReach(Parent.Type, Parent.Category, Parent.GetOSs()) * 0.1f * Reception);
			double num = SoftwareAlpha.FinalQualityCalc(CodeProgress, ArtProgress, CodeQuality, ArtQuality, Parent.Type, Features);
			if (GameSettings.DaysPerMonth > 1 && time.Day == GameSettings.DaysPerMonth - 1)
			{
				time -= new SDateTime(0, 1, 0, 0, 0);
			}
			AddOnProduct addOnProduct = (Final = new AddOnProduct(Name, Type, Parent, Features, FeatureFactors, DevStart, time, Price, Loss, new double[3] { num, num, num }, DevCompany, PhysicalCopies, DistributionLoss, followers, CodeProgress, ArtProgress, CodeQuality, ArtQuality, false));
			GameSettings.Instance.MoveStorage(this, addOnProduct);
			addOnProduct.SendNetwork();
			AddOnProduct.HandleNews(addOnProduct, false);
			return addOnProduct;
		}

		public SDateTime? GetReleaseDate()
		{
			return ReleaseDate;
		}

		public void RemoveProject(bool fromNetwork = false)
		{
			if (!fromNetwork)
			{
				NetworkMessaging.SendEndAddonDev(DevCompany.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				DevCompany.RemoveLicense(need.Value, this);
			}
			if (DevCompany.CurrentAddonProject == this)
			{
				DevCompany.CurrentAddonProject = null;
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public IReferenceFix FixReferences()
		{
			SimulatedCompany simulatedCompany;
			if ((simulatedCompany = MarketSimulation.Active.GetCompany(DevCompany.ID) as SimulatedCompany) != null && simulatedCompany.CurrentAddonProject.Name.Equals(Name))
			{
				return simulatedCompany.CurrentAddonProject;
			}
			return null;
		}

		public string GetActualString()
		{
			return Name;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetSWType()
		{
			return Type.GetPrettyName();
		}

		public string GetCategory()
		{
			return SWCat.Name.LocSWC(SWCat.Name);
		}

		public Company GetDevCompany()
		{
			return DevCompany;
		}

		public string GetIdentifyingName()
		{
			return Name;
		}

		public string GetCompanyName()
		{
			return DevCompany.Name;
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
			return 0;
		}

		public uint GetTotalPhysicalSales()
		{
			return 0u;
		}

		public int GetSalesMonths()
		{
			return 0;
		}

		public int GetLastMissedPhysicalSales()
		{
			return 0;
		}

		public uint GetReach()
		{
			return Parent.Type.GetReach(Parent.Category, Parent.GetOSs());
		}

		public float GetRealQuality()
		{
			return (float)Quality;
		}

		public uint GetFollowers()
		{
			return (uint)((float)GameSettings.Instance.simulation.GetFollowerReach(Parent.Type, Parent.Category, Parent.GetOSs()) * 0.1f * Reception);
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

		public void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
		{
			lock (this)
			{
				Loss += cost;
				if (type == SoftwareProduct.LossType.Copies)
				{
					DistributionLoss += cost;
				}
			}
		}

		public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
		{
			Tools.AddUp(tool, cost);
		}

		public float GetLicenseAmount()
		{
			if (DevTeam == 0)
			{
				DevTeam = SoftwareType.GetOptimalEmployeeCount(DevTime)[1];
			}
			return DevTeam;
		}

		public IList<uint> GetFeaturesFactors()
		{
			return FeatureFactors;
		}

		public IProductOrder PromoteHardware(uint copies)
		{
			return ManufactureOrder.PromoteProduct(this, copies);
		}
	}

	[Serializable]
	public class TechResearch : IByteData
	{
		public string Spec;

		public SDateTime ETA;

		public TechLevel Patent;

		public int Year;

		public TechResearch()
		{
		}

		public TechResearch(string spec, SDateTime eta, int year)
		{
			Spec = spec;
			ETA = eta;
			Year = year;
		}

		public void FilePatent(TechLevel t, SDateTime eta)
		{
			ETA = eta;
			Patent = t;
		}

		public void WriteData(Stream st)
		{
			st.WriteStringUTF8(Spec);
			st.WriteInt(Year);
			ETA.WriteData(st);
			st.WriteBool(Patent != null);
		}

		public static TechResearch ReadData(Stream st)
		{
			string text = st.ReadStringUTF8();
			if (text == null)
			{
				return null;
			}
			int year = st.ReadInt();
			SDateTime eta = SDateTime.ReadData(st);
			bool num = st.ReadBool();
			TechResearch techResearch = new TechResearch(text, eta, year);
			if (num)
			{
				techResearch.FilePatent(MarketSimulation.Active.GetTechLevel(text, year), eta);
			}
			return techResearch;
		}
	}

	public List<KeyValuePair<string, string>> Categories;

	private List<KeyValuePair<string, string>> _addonDev;

	public float AverageQuality;

	public float BusinessSavy;

	public List<ProductPrototype> Releases = new List<ProductPrototype>();

	public List<ProductPrototype> ProjectQueue = new List<ProductPrototype>();

	public AddonPrototype CurrentAddonProject;

	public TechResearch SpecResearch;

	public Employee LeadDesigner;

	public readonly bool DoesAddons;

	private readonly string _type;

	public float StockBudgetUsed;

	public bool CampaignProtected;

	private float _focus = 1f;

	private float _workItemFocus;

	public float WorkItemCost;

	private bool _firstLaunch = true;

	private bool _autonomous = true;

	public int DistributionDealCooldown;

	public int DistributionDevelopmentCooldown = -1;

	private SDateTime _lastForcedDilution;

	[IgnoreNetwork]
	public bool WillPublishPlayer = true;

	[IgnoreNetwork]
	public float PlayerRelationship;

	private SDateTime _lastUpdate;

	private SDateTime _lastLeadLook;

	private static Dictionary<string, int> _researchCache = new Dictionary<string, int>();

	private static List<Company> _playerCompanyCache = new List<Company>();

	private bool _hadItTough;

	private static HashSet<IMarketable> _marketingCache = new HashSet<IMarketable>();

	public List<KeyValuePair<string, string>> AddonDev
	{
		get
		{
			if (_addonDev == null)
			{
				CompanyType type = Type;
				_addonDev = ((type.Addons != null) ? type.Addons.Keys.ToList() : new List<KeyValuePair<string, string>>());
			}
			return _addonDev;
		}
	}

	public float FocusLeft
	{
		get
		{
			return _focus;
		}
	}

	public CompanyType Type
	{
		get
		{
			return MarketSimulation.Active.CompanyTypes[_type];
		}
	}

	public bool Autonomous
	{
		get
		{
			return _autonomous;
		}
	}

	public double GetStockBudget(double needed)
	{
		return ((base.Money - 20000000.0) * 0.3 - (double)StockBudgetUsed).Clamp(0.0, needed);
	}

	public void SetAutonomy(bool value, bool online)
	{
		if (online)
		{
			NetworkMessaging.SendSetAIAutonomy(ID, value, NetworkMessaging.MessageTarget.Everyone, 0);
		}
		else
		{
			_autonomous = value;
		}
	}

	public bool CompatibleSoftware(string type, string cat)
	{
		return Categories.Any((KeyValuePair<string, string> x) => x.Key.Equals(type) && (cat == null || x.Value == null || x.Value.Equals(cat)));
	}

	public bool DoWork(float work)
	{
		if (_focus >= work)
		{
			_workItemFocus += work;
			_focus -= work;
			return true;
		}
		return false;
	}

	public SimulatedCompany(string name, SDateTime time, CompanyType stype, Dictionary<string, string[]> categories, float avgQual, MarketSimulation sim)
		: base(name, StartingMoney(categories, avgQual, time.Year, sim), time, sim)
	{
		_type = stype.Name;
		Categories = categories.SelectMany((KeyValuePair<string, string[]> x) => x.Value.Select((string z) => new KeyValuePair<string, string>(x.Key, z))).ToList();
		AverageQuality = avgQual;
		BusinessSavy = Utilities.RandomGaussClamped(0.5f, 0.2f, sim.Random);
		DoesAddons = stype.HasAddons();
		_autoAcceptPlatforms = false;
	}

	public void InitialLeadDesigner(CompanyType stype, SDateTime time)
	{
		SoftwareType[] types = stype.GetDistinctTypes(time);
		Employee employee = MarketSimulation.Active.FreeLeads.FirstOrDefault((Employee x) => EvaluateCandidate(x, 0.85f, types, time));
		if (employee != null)
		{
			MarketSimulation.Active.FreeLeads.Remove(employee);
			LeadDesigner = employee;
			employee.RefreshUpfrontDemand(false);
			MakeTransaction(employee.GetUpfrontCost(false), TransactionCategory.NA, false);
			employee.Employ(this, time, false);
		}
		else
		{
			LeadDesigner = new Employee(time, Utilities.RandomValue > 0.5f, GameSettings.Instance.Personalities, types, true, "Default");
			LeadDesigner.RefreshUpfrontDemand(false);
			MakeTransaction(LeadDesigner.GetUpfrontCost(false), TransactionCategory.NA, false);
			LeadDesigner.Employ(this, time, false);
		}
		_lastLeadLook = time;
	}

	public SimulatedCompany(uint id, string name, SDateTime time, double startingMoney, CompanyType stype, float avgQual, float businessSavy)
		: base(name, startingMoney, time, id)
	{
		_type = stype.Name;
		Categories = stype.GetTypes().SelectMany((KeyValuePair<string, string[]> x) => x.Value.Select((string z) => new KeyValuePair<string, string>(x.Key, z))).ToList();
		AverageQuality = avgQual;
		BusinessSavy = businessSavy;
		_lastLeadLook = time;
		DoesAddons = stype.HasAddons();
		_autoAcceptPlatforms = false;
	}

	public SimulatedCompany()
	{
	}

	private static float StartingMoney(Dictionary<string, string[]> category, float avgQual, int year, MarketSimulation sim)
	{
		float num = 0f;
		int num2 = 0;
		bool flag = true;
		float num3 = 0f;
		foreach (KeyValuePair<string, string[]> item in category)
		{
			SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes[item.Key];
			string[] value = item.Value;
			foreach (string text in value)
			{
				if (text == null)
				{
					foreach (SoftwareCategory value2 in MarketSimulation.Active.SoftwareTypes[item.Key].Categories.Values)
					{
						if (value2.Hidden)
						{
							continue;
						}
						if (flag && value2.Hardware)
						{
							num3 = Mathf.Max(num3, value2.Manufacturing.Components.SumSafe((HardwareComponent x) => x.Price));
						}
						else
						{
							flag = false;
							num3 = 0f;
						}
						num += softwareType.MaxDevTime(value2, year);
						num2++;
					}
					continue;
				}
				SoftwareCategory softwareCategory = softwareType.Categories[text];
				num += softwareType.MaxDevTime(softwareCategory, year);
				num2++;
				if (flag && softwareCategory.Hardware)
				{
					num3 = Mathf.Max(num3, softwareCategory.Manufacturing.Components.SumSafe((HardwareComponent x) => x.Price));
				}
				else
				{
					flag = false;
					num3 = 0f;
				}
			}
		}
		float num4 = ((num2 == 0) ? 1f : (num / (float)num2));
		return Mathf.Max(10000f, Utilities.RandomGaussClamped(0.75f, 0.1f, sim.Random) * (num4 * 18000f)) + num3 * 2000000f;
	}

	public void SimulateDistribution(MarketSimulation sim, SDateTime time, double pvsd)
	{
		double num = base.Money * (double)(_hadItTough ? 0.1f : 0.4f);
		double num2 = base.Money * (double)(_hadItTough ? 0.1f : 0.2f);
		if (Publishing.Count > 0)
		{
			double num3 = num * 0.5;
			double num4 = num3;
			foreach (SoftwareProduct item in from x in Publishing.Where((PublisherDeal x) => x.Deals.Contains("Printing")).SelectNotNull((PublisherDeal x) => x.ProductTarget)
				where SDateTime.GetMonths(x.Release, time) <= 60f
				orderby x.Release descending
				select x)
			{
				if (item.Archived)
				{
					continue;
				}
				int num5 = SimulateProductDistribution(item, num4, pvsd, true);
				if (SDateTime.GetMonths(item.Release, time) < 1f && item.PhysicalCopies == 0)
				{
					float printPrice = item.GetPrintPrice(true);
					num5 = Mathf.Max(num5, Math.Min(10000, Utilities.FloorToInt(num4 / (double)printPrice)));
				}
				double num6 = BuyCopies(item, num5);
				num4 -= num6;
				item.Publishing.AddInvestment(num6);
				if (item.ForcedAddons != null)
				{
					for (int num7 = 0; num7 < item.ForcedAddons.Length; num7++)
					{
						AddOnProduct addOnProduct = item.ForcedAddons[num7];
						num4 -= BuyCopies(addOnProduct, num5);
						int num8 = SimulateProductDistribution(addOnProduct, num4, pvsd, true);
						if (addOnProduct.Forced && num8 + addOnProduct.PhysicalCopies < addOnProduct.Parent.PhysicalCopies)
						{
							num8 = Mathf.RoundToInt((float)(addOnProduct.Parent.PhysicalCopies - addOnProduct.PhysicalCopies) * (1f + ((float)addOnProduct.Type.PerUser - 1f) * 0.25f));
							float printPrice2 = addOnProduct.GetPrintPrice(true);
							num8 = Utilities.FloorToInt(Math.Min(num4, (float)num8 * printPrice2) / (double)printPrice2);
						}
						double num9 = BuyCopies(addOnProduct, num8);
						num4 -= num9;
						item.Publishing.AddInvestment(num9);
						if (num4 <= 0.0)
						{
							break;
						}
					}
				}
				if (num4 <= 0.0)
				{
					break;
				}
			}
			num -= num3 - num4;
		}
		foreach (SoftwareProduct item2 in from x in Products
			where SDateTime.GetMonths(x.Release, time) <= 60f
			orderby x.Release descending
			select x)
		{
			if (item2.Archived)
			{
				continue;
			}
			bool flag = item2.GetSalesMonths() == 0 || item2.GetLastMissedPhysicalSales() > 0;
			int copies = SimulateProductDistribution(item2, flag ? (num + num2) : num, pvsd, true);
			double num10 = BuyCopies(item2, copies);
			if (flag && num2 > 0.0)
			{
				if (num10 > num2)
				{
					num10 -= num2;
					num2 = 0.0;
				}
				else
				{
					num2 -= num10;
					num10 = 0.0;
				}
			}
			num -= num10;
			if (item2.ForcedAddons != null)
			{
				for (int num11 = 0; num11 < item2.ForcedAddons.Length; num11++)
				{
					AddOnProduct p = item2.ForcedAddons[num11];
					num -= BuyCopies(p, copies);
				}
			}
			if (num <= 0.0)
			{
				break;
			}
		}
		foreach (AddOnProduct item3 in from x in AddOns
			where SDateTime.GetMonths(x.Release, time) <= 60f
			orderby x.Release descending
			select x)
		{
			if (!item3.Parent.Archived)
			{
				int num12 = SimulateProductDistribution(item3, num, pvsd, true);
				if (item3.Forced && num12 + item3.PhysicalCopies < item3.Parent.PhysicalCopies)
				{
					num12 = Mathf.RoundToInt((float)(item3.Parent.PhysicalCopies - item3.PhysicalCopies) * (1f + ((float)item3.Type.PerUser - 1f) * 0.25f));
					float printPrice3 = item3.GetPrintPrice(true);
					num12 = Utilities.FloorToInt(Math.Min(num, (float)num12 * printPrice3) / (double)printPrice3);
				}
				num -= BuyCopies(item3, num12);
				if (num <= 0.0)
				{
					break;
				}
			}
		}
	}

	private double BuyCopies(IStockable p, int copies)
	{
		if (copies > 0)
		{
			float num = (float)copies * p.GetPrintPrice(true);
			MakeTransaction(0f - num, TransactionCategory.Distribution, true);
			p.AddLoss(num, SoftwareProduct.LossType.Copies, true);
			p.PhysicalCopies += (uint)copies;
			return num;
		}
		return 0.0;
	}

	public static int SimulateProductDistribution(IStockable p, double budget, bool ai)
	{
		return SimulateProductDistribution(p, budget, MarketSimulation.GetPhysicalVsDigital(SDateTime.Now()), ai);
	}

	public static int SimulateProductDistribution(IStockable p, double budget, double pvsd, bool ai)
	{
		SoftwareProduct softwareProduct;
		AddOnProduct addOnProduct;
		if (((softwareProduct = p as SoftwareProduct) != null && softwareProduct.Archived) || ((addOnProduct = p as AddOnProduct) != null && addOnProduct.Parent.Archived))
		{
			return 0;
		}
		int lastPhysicalSales = p.GetLastPhysicalSales();
		int salesMonths = p.GetSalesMonths();
		if (salesMonths > 3 && lastPhysicalSales == 0 && p.GetLastMissedPhysicalSales() == 0 && p.GetFollowers() == 0)
		{
			return 0;
		}
		float num = p.GetPrintPrice(ai);
		SoftwareProduct softwareProduct2;
		if (ai && (softwareProduct2 = p as SoftwareProduct) != null && softwareProduct2.ForcedAddons != null)
		{
			for (int i = 0; i < softwareProduct2.ForcedAddons.Length; i++)
			{
				AddOnProduct addOnProduct2 = softwareProduct2.ForcedAddons[i];
				num += addOnProduct2.GetPrintPrice(ai);
			}
		}
		double val = ((salesMonths != 0 && (salesMonths != 1 || lastPhysicalSales != 0)) ? (Math.Max(0.0, (double)lastPhysicalSales * 0.9 + (double)p.GetFollowers() * pvsd * 0.5 + (double)p.GetLastMissedPhysicalSales() * 1.5 - (double)p.PhysicalCopies) * (double)num) : ((Math.Max(ai ? 25000 : 0, (double)p.GetReach() * pvsd * 0.05 * (double)p.GetRealQuality() + (double)p.GetFollowers() * pvsd - (double)p.PhysicalCopies) + (double)(p.GetLastMissedPhysicalSales() * 2)) * (double)num));
		return Utilities.FloorToInt(Math.Min(budget, val) / (double)num);
	}

	public override void KillCompany()
	{
		for (int num = Releases.Count - 1; num >= 0; num--)
		{
			Releases[num].RemoveProject();
		}
		for (int num2 = ProjectQueue.Count - 1; num2 >= 0; num2--)
		{
			ProjectQueue[num2].RemoveProject();
		}
		if (CurrentAddonProject != null)
		{
			CurrentAddonProject.RemoveProject();
		}
		if (LeadDesigner != null && LeadDesigner.MyEmployer == this)
		{
			LeadDesigner.Dismiss(false);
			LeadDesigner.CleanUp();
			LeadDesigner.MyEmployer = null;
			bool flag = LeadDesigner.Creativity >= 0.85f;
			if (flag)
			{
				MarketSimulation.Active.FreeLeads.Add(LeadDesigner);
			}
			NetworkMessaging.MoveLeadDesigner(LeadDesigner, null, true, flag);
		}
	}

	public void FreeFocus(ProductPrototype p)
	{
		_focus += Type.GetEffort(p.Type.Name, p.Category.Name);
	}

	private bool UpdateReleases(SDateTime time, List<SoftwareProduct> releases)
	{
		for (int i = 0; i < Releases.Count; i++)
		{
			ProductPrototype productPrototype = Releases[i];
			try
			{
				int num = (time - productPrototype.ReleaseDate).ToInt();
				double productMonthlyCost = GetProductMonthlyCost(productPrototype);
				double num2 = 1.0;
				if (productMonthlyCost > 0.0)
				{
					num2 = Math.Min(base.Money * 0.25, productMonthlyCost) / productMonthlyCost;
					MakeTransaction(0.0 - productMonthlyCost, TransactionCategory.Salaries, true);
					productPrototype.Loss += (float)productMonthlyCost;
				}
				productPrototype.DevTimeLeft = (float)Math.Max(0.0, (double)productPrototype.DevTimeLeft - num2);
				if (!productPrototype.IsInDeal() && num >= 0)
				{
					if (LeadDesigner != null)
					{
						HUD.Instance.dealWindow.CancelWorkDeal(productPrototype, this);
						SoftwareProduct product = productPrototype.ToProduct(time, LeadDesigner);
						_lastUpdate = time;
						releases.Add(product);
						Products.Add(product);
						GameSettings.Instance.CancelPrintOrder(productPrototype, true);
						productPrototype.RemoveProject();
						if (product.TechLevels.Any((KeyValuePair<string, TechLevel> x) => x.Value.Outdates > 5))
						{
							product.Update(0, 0, product.TechLevels.Values.Where((TechLevel x) => x.Outdates > 5).ToDictionary((TechLevel x) => x.Spec, (TechLevel x) => MarketSimulation.Active.GetLatestTech(x.Spec, time, product.Category, this)), time);
						}
						i--;
					}
					else if (IsPlayerOwned(false))
					{
						if (!IsPlayerOwned())
						{
							NotificationManager.SendNotification(new SubsidaryLeadNotification(this), base.OwnerCompany.NetworkPlayerID);
						}
						else if (!NotificationManager.CheckAggregate<SubsidaryLeadNotification>(this))
						{
							NotificationManager.AddNotification(new SubsidaryLeadNotification(this));
						}
					}
				}
				else if (!productPrototype.PrintDeal && !IsPlayerOwned() && num >= -1440 * GameSettings.DaysPerMonth * MarketSimulation.Active.Random.Next(4, 12))
				{
					OfferPrintDeal(productPrototype, time);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				lock (Releases)
				{
					Releases.Remove(productPrototype);
				}
				i--;
			}
			if (Bankrupt)
			{
				return false;
			}
		}
		if (CurrentAddonProject != null && (time - CurrentAddonProject.ReleaseDate).ToInt() >= 0)
		{
			AddOnProduct addOnProduct = CurrentAddonProject.ToProduct(time);
			if (CurrentAddonProject.Parent.DevCompany == this)
			{
				addOnProduct.Parent.Update(Mathf.FloorToInt((float)addOnProduct.Parent.Bugss * 0.25f), 0, GetLatestTech(addOnProduct.Parent, time), time);
				_lastUpdate = time;
			}
			AddOns.Add(addOnProduct);
			MarketSimulation.Active.AddAddOn(addOnProduct);
			GameSettings.Instance.CancelPrintOrder(addOnProduct, true);
			CurrentAddonProject.RemoveProject();
		}
		if (_workItemFocus > 0f)
		{
			MakeTransaction(0f - WorkItemCost, TransactionCategory.Salaries, true);
			WorkItemCost = 0f;
			_focus += _workItemFocus;
			_workItemFocus = 0f;
		}
		return !Bankrupt;
	}

	private Dictionary<string, TechLevel> GetLatestTech(SoftwareProduct p, SDateTime time)
	{
		Dictionary<string, TechLevel> dictionary = new Dictionary<string, TechLevel>();
		foreach (KeyValuePair<string, TechLevel> techLevel in p.TechLevels)
		{
			TechLevel latestTech = MarketSimulation.Active.GetLatestTech(techLevel.Key, time, p.Category, this);
			if (latestTech.Year > techLevel.Value.Year)
			{
				dictionary[techLevel.Key] = latestTech;
			}
		}
		return dictionary;
	}

	public void CheckSubsidiaryBankruptcy()
	{
		if (!IsPlayerOwned())
		{
			return;
		}
		List<float> orNull = Cashflow.GetOrNull("Balance");
		if (orNull != null && orNull.Count > 4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 1f;
			for (int i = 0; i < 4; i++)
			{
				num += (orNull[orNull.Count - 1 - i] - orNull[orNull.Count - 2 - i]) * num3;
				num2 += num3;
				num3 /= 4f;
			}
			if ((double)(num / num2 * 4f) + base.Money < 0.0)
			{
				NotificationManager.AddNotification(new CompanyDetailNotification(this, "SubsidiaryMoneyWarning".LocColor(this), "Money", SDateTime.Now(), NotificationManager.NotificationType.Warning));
			}
		}
	}

	private void OfferPrintDeal(ProductPrototype pr, SDateTime time)
	{
		SDateTime? t = DealWindow.FindReceptionTime();
		if (!t.HasValue && !NetworkManager.IsHostingPlayers)
		{
			return;
		}
		double physicalVsDigital = MarketSimulation.GetPhysicalVsDigital(time);
		uint num = (uint)((double)pr.Type.GetReach(pr.Category, pr.OSs) * physicalVsDigital * (double)MarketSimulation.Active.Random.Range(0.1f, 0.5f) * pr.Quality);
		if (num <= 10000)
		{
			return;
		}
		pr.PrintDeal = true;
		ValueTuple<float, float> offerAndPrice = PrintDeal.GetOfferAndPrice(pr.Category, pr.HardwarePrice);
		float item = offerAndPrice.Item1;
		float item2 = offerAndPrice.Item2;
		uint num2 = (uint)(base.Money * 0.20000000298023224 / (double)item);
		if (num > num2)
		{
			num = num2;
		}
		if (num > 10000)
		{
			num2 = (uint)(SDateTime.GetMonths(time, pr.ReleaseDate) * 600000f);
			if (num > num2)
			{
				num = num2;
			}
			HUD.Instance.dealWindow.AddDeal(new PrintDeal(this, pr, item, item2, num), t, true);
		}
	}

	private float GetUpcoming(string type, string cat, SDateTime time)
	{
		float num = 0f;
		foreach (SimulatedCompany value in GameSettings.Instance.simulation.Companies.Values)
		{
			for (int i = 0; i < value.Releases.Count; i++)
			{
				ProductPrototype productPrototype = value.Releases[i];
				if (productPrototype.Type.Name.Equals(type) && (cat == null || productPrototype.Category.Name.Equals(cat)))
				{
					num += 1f / SDateTime.GetMonths(time, productPrototype.ReleaseDate);
				}
			}
		}
		return num;
	}

	private bool SimulateTechResearch(SDateTime time, HashSet<string> unlockedSpecs)
	{
		if (SpecResearch != null)
		{
			if (IsSubsidiary() || (SpecResearch.Patent != null && !SpecResearch.Patent.CanPatent))
			{
				SpecResearch = null;
				NetworkMessaging.SendAIResearch(ID, SpecResearch, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			else if (time > SpecResearch.ETA)
			{
				float researchAggressiveness = DifficultyValues.Difficulty.ResearchAggressiveness;
				if (SpecResearch.Patent == null)
				{
					AddResearch(SpecResearch.Spec, SpecResearch.Year);
					TechLevel techLevel = GameSettings.Instance.simulation.AddTechLevel(SpecResearch.Spec, SpecResearch.Year, time);
					if (techLevel != null && base.Money * 0.10000000149011612 > (double)TechLevel.PatentPrice && MarketSimulation.Active.Random.NextFloat() <= researchAggressiveness.MapRange(0f, 1f, 0.5f, 1f))
					{
						float num = GameData.ProjectDevTimeGeneric(Mathf.CeilToInt(GameSettings.Instance.simulation.GetTechMonths(SpecResearch.Spec)));
						SpecResearch.FilePatent(techLevel, time + Mathf.CeilToInt(Mathf.Lerp(researchAggressiveness.MapRange(0f, 1f, num, 0f), researchAggressiveness.MapRange(0f, 1f, num * 0.75f, 0f), BusinessSavy)));
						NetworkMessaging.SendAIResearch(ID, SpecResearch, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
					if (SpecResearch.Patent == null)
					{
						SpecResearch = null;
						NetworkMessaging.SendAIResearch(ID, SpecResearch, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
				}
				if (SpecResearch != null && time + 0.5f >= SpecResearch.ETA && SpecResearch.Patent != null && CanMakeTransaction(0f - TechLevel.PatentPrice))
				{
					if (SpecResearch.Patent.TransferPatent(this, time))
					{
						MakeTransaction(0f - TechLevel.PatentPrice, TransactionCategory.Legal, true, "Patent");
					}
					SpecResearch = null;
					NetworkMessaging.SendAIResearch(ID, SpecResearch, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					if (Bankrupt)
					{
						return false;
					}
				}
			}
		}
		if (SpecResearch == null && !IsSubsidiary() && time.Day == 0)
		{
			string random = Type.Types.Select((KeyValuePair<KeyValuePair<string, string>, float> x) => x.Key.Key).GetRandom(Type.Types.Count, MarketSimulation.Active.Random);
			_researchCache.Clear();
			int minYear = int.MaxValue;
			bool flag = false;
			foreach (FeatureBase value in MarketSimulation.Active.SoftwareTypes[random].Features.Values)
			{
				if (unlockedSpecs.Contains(value.Spec) && !_researchCache.ContainsKey(value.Spec))
				{
					if (MarketSimulation.Active.GetAIResearching(value.Spec) >= 4)
					{
						_researchCache[value.Spec] = -1;
					}
					else
					{
						int year = MarketSimulation.Active.TechLevels[value.Spec].Last().Year;
						minYear = Mathf.Min(minYear, year);
						_researchCache[value.Spec] = year;
						flag = true;
					}
				}
				if (unlockedSpecs.Count == _researchCache.Count)
				{
					break;
				}
			}
			if (flag)
			{
				string key = _researchCache.Where((KeyValuePair<string, int> x) => x.Value == minYear).GetRandom(MarketSimulation.Active.Random).Key;
				float techMonths = MarketSimulation.Active.GetTechMonths(key);
				if (MarketSimulation.Active.Random.NextFloat() * techMonths < 5f)
				{
					float researchAggressiveness2 = DifficultyValues.Difficulty.ResearchAggressiveness;
					float num2 = GameData.ProjectDevTimeGeneric(Mathf.CeilToInt(techMonths));
					SpecResearch = new TechResearch(key, time + Mathf.CeilToInt(Mathf.Lerp(researchAggressiveness2.MapRange(0f, 1f, num2 + 6f, num2 * 0.4f), num2 * researchAggressiveness2.MapRange(0f, 1f, 0.75f, 0.2f), BusinessSavy)), time.Year);
					NetworkMessaging.SendAIResearch(ID, SpecResearch, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
			}
		}
		return true;
	}

	private KeyValuePair<SoftwareType, SoftwareCategory>? PickReleaseType(SDateTime time)
	{
		if (_focus <= 0f)
		{
			return null;
		}
		KeyValuePair<string, string>? keyValuePair = null;
		if (Categories.Count == 1)
		{
			SoftwareType orNull = MarketSimulation.Active.SoftwareTypes.GetOrNull(Categories[0].Key);
			if (orNull != null && orNull.IsUnlocked(time.Year))
			{
				keyValuePair = Categories[0];
			}
		}
		else
		{
			float num = 0f;
			int num2 = MarketSimulation.Active.Random.Next(0, Categories.Count);
			for (int i = 0; i < Categories.Count; i++)
			{
				KeyValuePair<string, string> value = Categories[(i + num2) % Categories.Count];
				SoftwareType orNull2 = MarketSimulation.Active.SoftwareTypes.GetOrNull(value.Key);
				if (orNull2 != null && orNull2.IsUnlocked(time.Year))
				{
					float upcoming = GetUpcoming(value.Key, value.Value, time);
					if (!keyValuePair.HasValue || upcoming < num)
					{
						num = upcoming;
						keyValuePair = value;
					}
				}
			}
		}
		if (keyValuePair.HasValue)
		{
			SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes[keyValuePair.Value.Key];
			string value2 = keyValuePair.Value.Value;
			SoftwareCategory softwareCategory = null;
			if (value2 != null)
			{
				softwareCategory = softwareType.Categories.GetOrNull(value2);
				if (softwareCategory == null || !softwareCategory.IsUnlocked(time.Year) || softwareCategory.Hidden)
				{
					softwareCategory = null;
				}
			}
			else if (softwareType.Categories.Count == 1)
			{
				value2 = softwareType.Categories.First().Key;
				softwareCategory = softwareType.Categories.GetOrNull(value2);
				if (softwareCategory == null || !softwareCategory.IsUnlocked(time.Year) || softwareCategory.Hidden)
				{
					softwareCategory = null;
				}
			}
			else
			{
				float num3 = 0f;
				foreach (SoftwareCategory value3 in softwareType.Categories.Values)
				{
					if (!value3.Hidden && value3.IsUnlocked(time.Year))
					{
						float upcoming2 = GetUpcoming(softwareType.Name, value3.Name, time);
						if (softwareCategory == null || upcoming2 < num3)
						{
							num3 = upcoming2;
							softwareCategory = value3;
						}
					}
				}
			}
			if (softwareCategory != null)
			{
				return new KeyValuePair<SoftwareType, SoftwareCategory>(softwareType, softwareCategory);
			}
		}
		return null;
	}

	private float UpgradeChance()
	{
		return Utilities.RandomGaussClamped(1f, (1f - BusinessSavy) * 0.1f, MarketSimulation.Active.Random);
	}

	public SoftwareProduct ReleaseNow(SoftwareType type, SoftwareCategory cat, SDateTime time)
	{
		_firstLaunch = false;
		Dictionary<string, SoftwareProduct> needs = ChooseNeeds(type, cat.Name, time);
		if (needs == null)
		{
			return null;
		}
		SoftwareProduct[] array = ChooseOS(type, time);
		Dictionary<string, TechLevel> dictionary = type.Features.Values.OfType<SpecFeature>().ToDictionary((SpecFeature x) => x.Spec, (SpecFeature x) => GameSettings.Instance.simulation.TechLevels[x.Spec].Last());
		double[] array2 = PickMarketFocus(cat, 0.75f + BusinessSavy * 0.2f, time);
		FeatureBase[] array3 = type.GenerateFeatures(UpgradeChance(), cat, needs, dictionary, type.GetValidSpecs(array), time, array2, MarketSimulation.Active.Random, false);
		if (array3 == null)
		{
			return null;
		}
		TechLevel.CleanTechLevels(dictionary, array3);
		string[] needs2 = type.GetNeeds(array3, cat.Name);
		if (needs2.Any((string x) => !needs.ContainsKey(x)))
		{
			return null;
		}
		needs = needs2.ToDictionary((string x) => x, (string x) => needs[x]);
		float num = Utilities.RandomGaussClamped(1f, 0.1f, MarketSimulation.Active.Random);
		float num2 = Utilities.RandomGaussClamped(1f, 0.1f, MarketSimulation.Active.Random);
		float num3 = Utilities.RandomGaussClamped(AverageQuality, 0.1f, MarketSimulation.Active.Random);
		float num4 = Utilities.RandomGaussClamped(AverageQuality, 0.1f, MarketSimulation.Active.Random);
		double num5 = SoftwareAlpha.FinalQualityCalc(num, num2, num3, num4, type, array3);
		string name = GameSettings.Instance.simulation.GenerateProductName(cat, null, true);
		double codeProgress = num;
		double artProgress = num2;
		double codeQuality = num3;
		double artQuality = num4;
		double[] marketQuality = new double[3] { num5, num5, num5 };
		Employee leadDesigner = LeadDesigner;
		SoftwareProduct softwareProduct = new SoftwareProduct(name, type, cat, array, codeProgress, artProgress, codeQuality, artQuality, marketQuality, (leadDesigner != null) ? leadDesigner.Creativity : 0.5f, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(cat, false) * cat.PerceivedValue(array3, dictionary)), false, array2, time, time, 0, false, this, null, GameSettings.Instance.simulation.GetID(), 0.0, array3, dictionary, null, 0u, null, 0f, needs.ToDictionary((KeyValuePair<string, SoftwareProduct> x) => x.Value, (KeyValuePair<string, SoftwareProduct> x) => 0f));
		softwareProduct.SendNetwork();
		List<AddOnProduct> list = null;
		foreach (SoftwareAddOn item in from x in type.GetValidAddons(cat, dictionary, array3, time)
			where x.Forced.HasValue
			select x)
		{
			List<AddOnFeature> list2 = new List<AddOnFeature>();
			List<uint> list3 = new List<uint>();
			System.Random random = MarketSimulation.Active.Random;
			item.GenerateFeatures(array3, dictionary, array2, cat, random, list2, list3);
			AddOnProduct addOnProduct = new AddOnProduct(MarketSimulation.Active.GenerateAddonName(softwareProduct, softwareProduct.SequelTo, item, true, random, true), item, softwareProduct, list2.ToArray(), list3.ToArray(), time, time, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(item) * item.PerceivedValue(list2, list3, cat, dictionary)), 0.0, new double[3] { num5, num5, num5 }, this, 0u, 0f, 0u, num, num2, num3, num4, true);
			addOnProduct.SendNetwork();
			AddOns.Add(addOnProduct);
			GameSettings.Instance.simulation.AddAddOn(addOnProduct);
			if (list == null)
			{
				list = new List<AddOnProduct>();
			}
			list.Add(addOnProduct);
			AddOnProduct.HandleNews(addOnProduct, false);
		}
		if (list != null)
		{
			softwareProduct.ForcedAddons = list.ToArray();
			softwareProduct.UpdateForcedAddonQualityEffect();
		}
		Products.Add(softwareProduct);
		if (LeadDesigner != null)
		{
			LeadDesigner.FinishLeadProject(softwareProduct, 1f, true, MarketSimulation.Active.Random.Next());
		}
		SoftwareProduct.HandleNews(softwareProduct, false);
		softwareProduct.RunReleaseScripts();
		_lastUpdate = time;
		return softwareProduct;
	}

	public static SoftwareFramework FindFramework(Company c, SoftwareCategory cat, SDateTime time, float savy = 1f)
	{
		SoftwareFramework softwareFramework = null;
		SoftwareFramework softwareFramework2 = null;
		int num = 0;
		int num2 = 0;
		float num3 = savy.MapRange(0f, 1f, 0.5f, 0.85f);
		for (int i = 0; i < GameSettings.Instance.simulation.Frameworks.Count; i++)
		{
			SoftwareFramework softwareFramework3 = GameSettings.Instance.simulation.Frameworks[i];
			if (softwareFramework3.Category != cat || !(SDateTime.GetMonths(softwareFramework3.LastUpdate ?? softwareFramework3.Release, time) <= 36f))
			{
				continue;
			}
			bool flag = softwareFramework3.HasToPay(c);
			float num4 = softwareFramework3.Quality();
			int num5 = (softwareFramework3.LastUpdate ?? softwareFramework3.Release).ToInt() + Mathf.RoundToInt(((flag && softwareFramework3.Owner.Player) ? (0.5f + softwareFramework3.Owner.DiscreteRep * 0.5f) : 1f) * num4 * (float)(GameSettings.DaysPerMonth * 12 * 2));
			if (!flag)
			{
				if (num5 > num2)
				{
					num2 = num5;
					softwareFramework2 = softwareFramework3;
				}
			}
			else if (num5 > num && num4 > num3)
			{
				num = num5;
				softwareFramework = softwareFramework3;
			}
		}
		if (softwareFramework2 != null && num2 > num)
		{
			if (SDateTime.GetMonths(softwareFramework2.LastUpdate ?? softwareFramework2.Release, time) < 36f && softwareFramework2.TechLevels.Values.MaxSafeInt((TechLevel x) => x.Outdates) < 4)
			{
				return softwareFramework2;
			}
		}
		else if (softwareFramework != null && SDateTime.GetMonths(softwareFramework.LastUpdate ?? softwareFramework.Release, time) <= 24f && softwareFramework.TechLevels.Values.MaxSafeInt((TechLevel x) => x.Outdates) < 4)
		{
			return softwareFramework;
		}
		if (softwareFramework2 != null && SDateTime.GetMonths(softwareFramework2.LastUpdate ?? softwareFramework2.Release, time) <= 36f && softwareFramework2.TechLevels.Values.MaxSafeInt((TechLevel x) => x.Outdates) < 4)
		{
			return softwareFramework2;
		}
		return null;
	}

	private uint ReevaluateDistSum(ref uint max, ref uint sum, uint newVal)
	{
		if (newVal > max)
		{
			max = newVal;
		}
		sum += newVal;
		return max + (sum - max >> 2);
	}

	public float GetMaxPlayerCut(DistributionPlatform pd)
	{
		return Mathf.Min(Mathf.Max(DistributionPlatform.AcceptableCut(pd.MarketShare), _playerAcceptRates.GetOrDefault(pd.Owner, 0f)), _playerAcceptRates.GetOrDefault(pd.Owner, 0f) + 0.01f + (float)WantsDistribution.GetOrDefault(pd.Owner, 0) * 0.01f);
	}

	private void UpdatePlayerDistributions(SDateTime time)
	{
		foreach (Company playerCompany in MarketSimulation.Active.GetPlayerCompanies())
		{
			int value;
			if (!WantsDistribution.TryGetValue(playerCompany, out value))
			{
				continue;
			}
			if (value < 0 && time.Day == 0)
			{
				if (value == -1)
				{
					WantsDistribution.Remove(playerCompany);
				}
				else
				{
					WantsDistribution[playerCompany]++;
				}
			}
			else
			{
				if (value < 0 || playerCompany.Distribution == null)
				{
					continue;
				}
				if (time.Day == 0 && value < 3)
				{
					WantsDistribution[playerCompany]++;
				}
				float maxPlayerCut = GetMaxPlayerCut(playerCompany.Distribution);
				if (playerCompany.Distribution.GetCut() > maxPlayerCut)
				{
					if (playerCompany.Distribution.HasToPay(this))
					{
						if (SignPlatform(playerCompany.Distribution, false))
						{
							MarkInterested(playerCompany.Distribution.Owner, false, -3);
						}
						else
						{
							MarkInterested(playerCompany.Distribution.Owner, false, 0);
						}
					}
					else
					{
						_playerAcceptRates[playerCompany] = maxPlayerCut;
					}
				}
				else
				{
					_playerAcceptRates[playerCompany] = playerCompany.Distribution.GetCut();
				}
			}
		}
	}

	public void EvaluateDistributionPlatforms(SDateTime time)
	{
		if (IsPlayerOwned(false))
		{
			return;
		}
		UpdatePlayerDistributions(time);
		uint sum = MarketSimulation.Active.EvalutateDistributionSums(GetPlatforms(), true, false);
		float num = 0.9f * (float)MarketSimulation.Population;
		if ((float)sum < num || GetPlatforms().Count < 2)
		{
			uint max = sum;
			uint num2 = sum;
			{
				foreach (var item2 in MarketSimulation.Active.DistributionPlatforms.Select([return: TupleElementNames(new string[] { "platform", null })] (DistributionPlatform platform) => new ValueTuple<DistributionPlatform, float>(platform, platform.CutScore())).OrderBy(([TupleElementNames(new string[] { "platform", null })] ValueTuple<DistributionPlatform, float> x) => x.Item1.HasToPay(this) ? 1 : 0).ThenByDescending(([TupleElementNames(new string[] { "platform", null })] ValueTuple<DistributionPlatform, float> x) => x.Item2))
				{
					DistributionPlatform item = item2.Item1;
					if (item2.Item2 < 0.05f && item.HasToPay(this))
					{
						break;
					}
					if (IsSigned(item) || !item.Open)
					{
						continue;
					}
					if (item.Owner.Player)
					{
						if (!PlayerDistributionQuarantined(item))
						{
							MarkInterested(item.Owner, true, 0);
							num2 = ReevaluateDistSum(ref max, ref sum, item.ActualUsers);
						}
					}
					else
					{
						SignPlatform(item, true);
						num2 = ReevaluateDistSum(ref max, ref sum, item.ActualUsers);
					}
					if ((float)num2 >= num)
					{
						break;
					}
				}
				return;
			}
		}
		if ((float)sum > (float)MarketSimulation.Population * 1.2f && GetPlatforms().Count > 2)
		{
			float num3 = float.MaxValue;
			DistributionPlatform distributionPlatform = null;
			List<DistributionPlatform> platforms = GetPlatforms();
			for (int num4 = 0; num4 < platforms.Count; num4++)
			{
				DistributionPlatform distributionPlatform2 = platforms[num4];
				if (distributionPlatform2.Owner != this && distributionPlatform2.HasToPay(this))
				{
					float num5 = distributionPlatform2.CutScore();
					if (num5 < num3)
					{
						num3 = num5;
						distributionPlatform = distributionPlatform2;
					}
				}
			}
			foreach (Company playerCompany in MarketSimulation.Active.GetPlayerCompanies())
			{
				if (playerCompany.Distribution != null && !IsSigned(playerCompany.Distribution))
				{
					MarkInterested(playerCompany, false, 0);
				}
			}
			if (distributionPlatform != null && SignPlatform(distributionPlatform, false))
			{
				MarkInterested(distributionPlatform.Owner, false, 0);
			}
		}
		else
		{
			if (!(MarketSimulation.Active.Random.NextDouble() < (double)0.1f.SpreadChance(GameSettings.DaysPerMonth)))
			{
				return;
			}
			DistributionPlatform distributionPlatform3 = MarketSimulation.Active.DistributionPlatforms.Where((DistributionPlatform x) => x.Open && x.Owner != this && WantsDistribution.GetOrDefault(x.Owner, 0) >= 0).MaxInstance((DistributionPlatform x) => (!x.HasToPay(this)) ? 2f : x.CutScore());
			if (distributionPlatform3 == null || IsSigned(distributionPlatform3))
			{
				return;
			}
			if (distributionPlatform3.Owner.Player && distributionPlatform3.AutoAcceptClients)
			{
				MarkInterested(distributionPlatform3.Owner, true, 0);
				return;
			}
			DistributionPlatform distributionPlatform4 = (from x in GetPlatforms()
				where x.HasToPay(this)
				select x).MinInstance((DistributionPlatform x) => x.CutScore());
			if (distributionPlatform4 != null)
			{
				if (SignPlatform(distributionPlatform4, false))
				{
					MarkInterested(distributionPlatform4.Owner, false, 0);
				}
				if (distributionPlatform3.Owner.Player)
				{
					MarkInterested(distributionPlatform3.Owner, true, 0);
				}
				else
				{
					SignPlatform(distributionPlatform3, true);
				}
			}
		}
	}

	private bool EvaluateCandidate(Employee emp, float minCreativity, SoftwareType[] types, SDateTime time)
	{
		if (emp.GetAge(time) > (float)(Employee.RetirementAge - 2))
		{
			return false;
		}
		if (emp.CreativityKnown < 1f || emp.Creativity <= minCreativity)
		{
			return false;
		}
		for (int i = 0; i < types.Length; i++)
		{
			if (emp.LeadSpecializationFix.GetOrDefault(types[i].Name, 0f) < 1f)
			{
				return false;
			}
		}
		return true;
	}

	public Employee LookForEmployee(float minCreativity, SoftwareType[] types, SDateTime time, bool canPoachPlayer = true)
	{
		Employee employee = MarketSimulation.Active.FreeLeads.FirstOrDefault(delegate(Employee x)
		{
			if (EvaluateCandidate(x, minCreativity, types, time))
			{
				x.RefreshUpfrontDemand(false);
				if ((double)x.GetUpfrontCost(false) < base.Money * 0.10000000149011612)
				{
					return true;
				}
			}
			return false;
		});
		if (employee != null)
		{
			employee.RefreshUpfrontDemand(false);
			MarketSimulation.Active.FreeLeads.Remove(employee);
			return employee;
		}
		if (canPoachPlayer)
		{
			_playerCompanyCache.Clear();
			_playerCompanyCache.AddRange(MarketSimulation.Active.GetPlayerCompanies());
			_playerCompanyCache.Shuffle();
			foreach (Company item in _playerCompanyCache)
			{
				if (item.LeadBidHappening)
				{
					continue;
				}
				foreach (Employee playerCompanyEmployee in GetPlayerCompanyEmployees(item))
				{
					if (playerCompanyEmployee.HasDemanded(LeadDesignDemands.Demand.NonBinding) && SDateTime.GetMonths(playerCompanyEmployee.Hired, time) > 6f && SDateTime.GetMonths(playerCompanyEmployee.LastBid, time) > 6f && playerCompanyEmployee.GetAgeFlat(time) < Employee.RetirementAge - 2 && (!GameSettings.Instance.IsNetworkMode || playerCompanyEmployee.NetworkID != 0) && EvaluateCandidate(playerCompanyEmployee, minCreativity, types, time))
					{
						playerCompanyEmployee.LastBid = time;
						item.LeadBidHappening = true;
						float offer = playerCompanyEmployee.GetMonthlySalary(null) * 5f * 12f;
						if (NetworkManager.IsHostingPlayers)
						{
							NetworkMessaging.SendStartLeadPoach(ID, playerCompanyEmployee.NetworkID, offer, NetworkMessaging.MessageTarget.Specifically, item.NetworkPlayerID);
						}
						else
						{
							NetworkMessaging.ActuallyStartLeadPoach(this, playerCompanyEmployee, offer);
						}
						return null;
					}
				}
			}
			_playerCompanyCache.Clear();
		}
		foreach (SimulatedCompany value in MarketSimulation.Active.Companies.Values)
		{
			if (value != this && !value.CampaignProtected && value.LeadDesigner != null && !value.IsSubsidiary() && SDateTime.GetMonths(value.LeadDesigner.Hired, time) > 6f && EvaluateCandidate(value.LeadDesigner, minCreativity, types, time))
			{
				Employee leadDesigner = value.LeadDesigner;
				leadDesigner.RefreshUpfrontDemand(false);
				if ((double)leadDesigner.GetUpfrontCost(false) < base.Money * 0.10000000149011612)
				{
					leadDesigner.Hired = time;
					leadDesigner.Dismiss(false);
					value.FindNewLead(time, canPoachPlayer);
					return leadDesigner;
				}
			}
		}
		return null;
	}

	private static IEnumerable<Employee> GetPlayerCompanyEmployees(Company c)
	{
		if (c.LeadBidHappening)
		{
			yield break;
		}
		if (c.LocalPlayer)
		{
			for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
			{
				yield return GameSettings.Instance.sActorManager.Actors[i].employee;
			}
			yield break;
		}
		NetworkPlayer player = NetworkManager.GetPlayer(c.NetworkPlayerID);
		if (player != null && player.Connected)
		{
			for (int i = 0; i < c.NetworkEmployees.Count; i++)
			{
				yield return c.NetworkEmployees[i];
			}
		}
	}

	public void FindNewLead(SDateTime time, bool canPoachPlayer = true)
	{
		SoftwareType[] distinctTypes = Type.GetDistinctTypes(time);
		Employee employee = LookForEmployee(0.85f, distinctTypes, time, canPoachPlayer);
		if (employee != null)
		{
			LeadDesigner = employee;
			LeadDesigner.Employ(this, time, false);
			NetworkMessaging.MoveLeadDesigner(employee, this, true, false);
		}
		else
		{
			LeadDesigner = new Employee(time, Utilities.RandomValue > 0.5f, GameSettings.Instance.Personalities, distinctTypes, false, "Default");
			LeadDesigner.Employ(this, time, false);
			NetworkMessaging.MoveLeadDesigner(LeadDesigner, this, true, false);
		}
		_lastLeadLook = time;
	}

	private void SimulateAddonDev(SDateTime time, bool presim)
	{
		if (!DoesAddons || CurrentAddonProject != null)
		{
			return;
		}
		System.Random rnd = MarketSimulation.Active.Random;
		if (AddonDev.Count > 0)
		{
			float num = rnd.NextFloat();
			SoftwareAddOn addon = null;
			CompanyType type = Type;
			foreach (KeyValuePair<string, string> item in AddonDev.OrderBy((KeyValuePair<string, string> x) => rnd.Next()))
			{
				SoftwareAddOn softwareAddOn = MarketSimulation.Active.SoftwareTypes[item.Key].AddOns[item.Value];
				if (softwareAddOn.IsUnlocked(time.Year) && type.Addons[item].SpreadChance(GameSettings.DaysPerMonth) > num)
				{
					addon = softwareAddOn;
					break;
				}
			}
			if (addon != null)
			{
				HashSet<SoftwareCategory> hashSet = addon.Categories.Select((string x) => addon.Parent.Categories[x]).ToHashSet();
				SoftwareProduct softwareProduct = null;
				int num2 = 10000;
				foreach (SoftwareProduct allProduct in MarketSimulation.Active.GetAllProducts(false))
				{
					if (hashSet.Contains(allProduct.Category) && SDateTime.GetMonths(allProduct.Release, time) < 36f && CountProjects(allProduct, addon) < 5 && allProduct.Userbase > num2)
					{
						num2 = allProduct.Userbase;
						softwareProduct = allProduct;
					}
				}
				if (softwareProduct != null)
				{
					CurrentAddonProject = CreateAddonPrototype(addon, softwareProduct, time, true, presim);
					return;
				}
			}
		}
		SoftwareProduct softwareProduct2 = Products.Where((SoftwareProduct x) => !x.Traded && SDateTime.GetMonths(x.Release, time) < 60f).MaxInstance((SoftwareProduct x) => x.Userbase);
		if (softwareProduct2 == null || softwareProduct2.Userbase <= 5000 || softwareProduct2.Category.Hardware)
		{
			return;
		}
		SoftwareAddOn random = softwareProduct2.Type.GetValidAddons(softwareProduct2.Category, softwareProduct2.TechLevels, softwareProduct2.Features, time).GetRandom();
		if (random == null)
		{
			return;
		}
		bool flag = true;
		List<AddOnProduct> value;
		if (softwareProduct2.Addons.TryGetValue(random, out value) && value.Count > 0)
		{
			AddOnProduct addOnProduct = value.MaxInstance((AddOnProduct x) => x.Release.ToInt());
			if (addOnProduct.Gross < addOnProduct.Loss)
			{
				flag = false;
			}
		}
		if (flag)
		{
			CurrentAddonProject = CreateAddonPrototype(random, softwareProduct2, time, true, presim);
		}
	}

	private int CountProjects(SoftwareProduct p, SoftwareAddOn a)
	{
		List<AddOnProduct> orNull = p.Addons.GetOrNull(a);
		int num = 0;
		if (orNull != null)
		{
			num += orNull.Count;
		}
		foreach (SimulatedCompany value in MarketSimulation.Active.Companies.Values)
		{
			if (value.CurrentAddonProject != null && value.CurrentAddonProject.Parent == p && value.CurrentAddonProject.Type == a)
			{
				num++;
			}
		}
		return num;
	}

	private AddonPrototype CreateAddonPrototype(SoftwareAddOn type, SoftwareProduct parent, SDateTime time, bool cancelIfLowUserBase, bool presim)
	{
		System.Random random = MarketSimulation.Active.Random;
		List<AddOnFeature> list = new List<AddOnFeature>();
		List<uint> list2 = new List<uint>();
		Dictionary<string, SoftwareProduct> tools = ChooseNeeds(parent.Type, parent.Category.Name, time);
		type.GenerateFeatures(parent.Features, parent.TechLevels, parent.Submarkets, parent.Category, random, list, list2);
		HashSet<string> specs = list.Select((AddOnFeature x) => x.Spec).Distinct().ToHashSet();
		tools = (from x in parent.Features.OfType<SpecFeature>()
			where specs.Contains(x.Spec)
			select x).SelectMany((SpecFeature x) => x.Dependencies).Distinct().ToDictionary((string x) => x, (string x) => tools.GetOrDefault(x));
		if (tools.Values.None((SoftwareProduct x) => x == null))
		{
			float devTime = type.DevTime(list, list2, parent.Category, this, parent.TechLevels);
			float artRatio = SoftwareType.CodeArtRatio(list.OfType<FeatureBase>().ToList());
			int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(devTime);
			int num = Mathf.RoundToInt(GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], devTime, artRatio) * MarketSimulation.Active.Random.Range(0.9f, 1.1f) * 1.5f);
			if (cancelIfLowUserBase && (float)parent.Userbase * Mathf.Pow(0.9f, num + 6) < 5000f)
			{
				return null;
			}
			SDateTime releaseDate = time + num;
			double codeProgress = PickQuality(false, true);
			double artProgress = PickQuality(true, true);
			double codeQuality = PickQuality(false, false);
			double artQuality = PickQuality(true, false);
			KeyValuePair<double, double> keyValuePair = Premarket(devTime);
			AddonPrototype addonPrototype = new AddonPrototype(MarketSimulation.Active.GenerateAddonName(parent, null, type, false, random, presim), type, parent, tools, codeProgress, artProgress, codeQuality, artQuality, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(type) * type.PerceivedValue(list, list2, parent.Category, parent.TechLevels)), this, (float)keyValuePair.Key, list.ToArray(), list2.ToArray(), keyValuePair.Value, releaseDate, time);
			addonPrototype.SendNetwork();
			return addonPrototype;
		}
		return null;
	}

	private bool CheckProductUpdate(SDateTime time)
	{
		if (Products.Count > 0 && SDateTime.GetMonths(_lastUpdate, time) >= 3f)
		{
			SoftwareProduct softwareProduct = Products.MaxInstance((SoftwareProduct x) => x.Release.ToInt());
			softwareProduct.Update(Mathf.FloorToInt((float)softwareProduct.Bugss * 0.25f), 0, GetLatestTech(softwareProduct, time), time);
			_lastUpdate = time;
		}
		return true;
	}

	private void TryToSellIP(double minBalance)
	{
		if (Frameworks.Count > 0)
		{
			List<SoftwareFramework> list = Frameworks.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				IPDeal iPDeal = new IPDeal(list[i]);
				Company company = MarketSimulation.Active.FindBuyer(iPDeal);
				if (company != null)
				{
					iPDeal.Accept(company);
				}
				if (base.Money >= minBalance)
				{
					break;
				}
			}
		}
		if (base.Money < minBalance && AddOns.Any((AddOnProduct x) => x.Parent.DevCompany != this))
		{
			List<AddOnProduct> list2 = AddOns.ToList();
			for (int num = 0; num < list2.Count; num++)
			{
				AddOnProduct addOnProduct = list2[num];
				if (addOnProduct.Parent.DevCompany != this)
				{
					IPDeal iPDeal2 = new IPDeal(addOnProduct);
					Company company2 = MarketSimulation.Active.FindBuyer(iPDeal2);
					if (company2 != null)
					{
						iPDeal2.Accept(company2);
					}
					if (base.Money >= minBalance)
					{
						break;
					}
				}
			}
		}
		if (!(base.Money < minBalance) || Products.Count <= 1)
		{
			return;
		}
		List<IGrouping<SoftwareProduct, SoftwareProduct>> list3 = (from x in Products
			group x by x.GetLatestSuccessor() into x
			orderby (!x.Key.Traded) ? 1 : 0, x.Key.Release.ToInt()
			select x).ToList();
		while (list3.Count > 1)
		{
			IGrouping<SoftwareProduct, SoftwareProduct> grouping = list3[0];
			list3.RemoveAt(0);
			IPDeal iPDeal3 = new IPDeal(grouping.Key);
			Company company3 = MarketSimulation.Active.FindBuyer(iPDeal3);
			if (company3 != null)
			{
				iPDeal3.Accept(company3);
			}
			if (base.Money >= minBalance)
			{
				break;
			}
		}
	}

	private double GetMinBalance()
	{
		List<float> list = Cashflow["Balance"];
		int num = Mathf.Min(list.Count - 1, 24);
		double num2 = 0.0;
		for (int i = 0; i < num; i++)
		{
			float num3 = list[list.Count - 1 - i];
			float num4 = list[list.Count - 2 - i];
			num2 += (double)(num3 - num4);
		}
		return (0.0 - num2) / (double)num * 12.0;
	}

	public bool DoingWell()
	{
		return base.Money > GetMinBalance();
	}

	public void Simulate(SDateTime time, List<SoftwareProduct> releases, HashSet<string> unlockedSpecs, bool preSim)
	{
		if (LastTaxReport != null)
		{
			LastTaxReport.ReportProgress = 1f;
			LastTaxReport.Optimization = 100000000f;
		}
		bool isBankrupting = false;
		bool flag = false;
		_hadItTough = false;
		if (!IsSubsidiary() && NewStock.None((NewStock x) => x.Percentage >= 0.5))
		{
			if (Cashflow["Balance"].Count > 11)
			{
				double num = GetMinBalance();
				if (time.Month == 3 && LastTaxReport != null)
				{
					float optimization;
					num += LastTaxReport.FinalValue(out optimization);
				}
				if (base.Money < num)
				{
					isBankrupting = true;
					int num2 = NewOwnedStock.Count;
					int num3 = 0;
					while (NewOwnedStock.Count > 0 && num3 < NewOwnedStock.Count && base.Money < num)
					{
						NewStock newStock = NewOwnedStock[num3];
						if (newStock.Seller.Player && newStock.Seller.TakeOver.HasValue)
						{
							num3++;
							continue;
						}
						if ((double)((float)newStock.Shares / (float)newStock.Seller.Shares) >= 0.5 && base.Money > 1000000.0)
						{
							num3++;
							continue;
						}
						uint shares = newStock.Shares.Min((uint)((num - base.Money) / newStock.ShareWorth) + 1);
						MarketSimulation.Active.FindBuyer(newStock, shares, time);
						num2--;
						if (num2 < 0)
						{
							break;
						}
					}
					if (base.Money < num)
					{
						double num4 = Math.Min(num - base.Money, GetPossibleStockWorth());
						if (num4 > 25000.0)
						{
							KeyValuePair<uint, double> sharesAndPrice = GetSharesAndPrice(num4);
							if (sharesAndPrice.Key > 1)
							{
								flag = MarketSimulation.Active.FindBuyers(this, sharesAndPrice.Key, sharesAndPrice.Value, time);
							}
						}
					}
					if (base.Money / num < 0.5)
					{
						TryToSellIP(num);
					}
					if (base.Money / num < 0.5)
					{
						_hadItTough = true;
					}
				}
			}
			if (!flag && (CampaignProtected || SDateTime.GetMonths(_lastForcedDilution, time) >= 6f))
			{
				float minShares = GetMinShares(time);
				double num5 = 1.0 - GetShare();
				if (num5 < (double)minShares)
				{
					double possibleStockWorth = GetPossibleStockWorth();
					if (possibleStockWorth > 25000.0)
					{
						KeyValuePair<uint, double> sharesAndPrice2 = GetSharesAndPrice(possibleStockWorth);
						if (sharesAndPrice2.Key > 1)
						{
							uint num6 = Shares;
							if (num6 == 0)
							{
								num6 = (uint)Utilities.FloorToInt(GetMoneyWithInsurance() / sharesAndPrice2.Value);
							}
							uint num7 = (uint)(((double)minShares - num5) * (double)num6);
							if (num7 > sharesAndPrice2.Key)
							{
								num7 = sharesAndPrice2.Key;
							}
							if (num7 > 1)
							{
								flag = MarketSimulation.Active.FindBuyers(this, num7, sharesAndPrice2.Value, time);
							}
							_lastForcedDilution = time;
						}
					}
				}
			}
		}
		if (Bankrupt)
		{
			return;
		}
		if (Distribution != null)
		{
			Dictionary<string, TechLevel> dictionary = null;
			foreach (KeyValuePair<string, TechLevel> techLevel in Distribution.Software.TechLevels)
			{
				TechLevel latestTech = MarketSimulation.Active.GetLatestTech(techLevel.Key, time, Distribution.Software.Category, this);
				if (latestTech.Year > techLevel.Value.Year)
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<string, TechLevel>();
					}
					dictionary[techLevel.Key] = latestTech;
				}
			}
			if (dictionary != null)
			{
				Distribution.Software.Update(0, 0, dictionary, time);
			}
			if (time.Month == Distribution.Founded.Month && time.Day == 0)
			{
				float num8 = DistributionPlatform.AcceptableCut(Distribution.MarketShare).MapRange(0.05f, 0.3f, 0.025f, 0.3f, true);
				Distribution.SetCut((Mathf.Abs(num8 - Distribution.GetCut()) <= 0.02f) ? num8 : Mathf.Lerp(Distribution.GetCut(), num8, 0.25f));
			}
		}
		if (Bankrupt)
		{
			return;
		}
		if (LeadDesigner == null || LeadDesigner.GetAgeFlat() >= Employee.RetirementAge)
		{
			if (LeadDesigner != null)
			{
				LeadDesigner.Dismiss(false);
				LeadDesigner.CleanUp();
				LeadDesigner.Retired = true;
				LeadDesigner.MyEmployer = null;
				NetworkMessaging.MoveLeadDesigner(LeadDesigner, null, false, false);
				if (LeadDesigner.HasDemanded(LeadDesignDemands.Demand.GoldenHandshake))
				{
					MakeTransaction((0f - LeadDesigner.GetMonthlySalary(null)) * 5f * 12f, TransactionCategory.Benefits, true);
				}
				LeadDesigner = null;
			}
			if (!IsSubsidiary() && !Bankrupt)
			{
				FindNewLead(time, !preSim);
			}
		}
		else if (!IsSubsidiary() && !CampaignProtected && SDateTime.GetMonths(_lastLeadLook, time) > ((LeadDesigner.Creativity < 0.85f) ? 6f : (LeadDesigner.HasDemanded(LeadDesignDemands.Demand.GoldenHandshake) ? 48f : 24f)))
		{
			SoftwareType[] distinctTypes = Type.GetDistinctTypes(time);
			Employee employee = LookForEmployee(LeadDesigner.Creativity, distinctTypes, time, !preSim);
			if (employee != null && LeadDesigner.MyEmployer == this)
			{
				LeadDesigner.Dismiss(false);
				LeadDesigner.CleanUp();
				LeadDesigner.MyEmployer = null;
				bool flag2 = LeadDesigner.Creativity >= 0.85f;
				if (flag2)
				{
					MarketSimulation.Active.FreeLeads.Add(LeadDesigner);
				}
				NetworkMessaging.MoveLeadDesigner(LeadDesigner, null, true, flag2);
				Employee leadDesigner = LeadDesigner;
				LeadDesigner = employee;
				employee.Employ(this, time, false);
				_lastLeadLook = time;
				if (leadDesigner.HasDemanded(LeadDesignDemands.Demand.GoldenHandshake))
				{
					MakeTransaction((0f - leadDesigner.GetMonthlySalary(null)) * 5f * 12f, TransactionCategory.Benefits, true);
				}
			}
		}
		else if (time.Month == 0 && time.Day == 0)
		{
			LeadDesigner.RefreshSalary();
		}
		if (Bankrupt)
		{
			return;
		}
		TradeStocks(flag, isBankrupting, time);
		if (Bankrupt)
		{
			return;
		}
		PayExpenses(time);
		if (Bankrupt)
		{
			return;
		}
		CheckPorting(time);
		if (Autonomous)
		{
			SimulateAddonDev(time, preSim);
		}
		bool flag3 = false;
		if (ProjectQueue.Count > 0 && _focus > 0f)
		{
			ProductPrototype productPrototype = ProjectQueue[0];
			productPrototype.StartDev(time, PickReleaseDate(productPrototype.Type, productPrototype.Category, productPrototype.Features, productPrototype.Techs, productPrototype.OSs, productPrototype.SequelTo, productPrototype.Framework, productPrototype.NewFramework != null, time));
			flag3 = true;
		}
		if (!Autonomous || flag3)
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs) && UpdateReleases(time, releases))
			{
				CheckProductUpdate(time);
			}
			return;
		}
		KeyValuePair<SoftwareType, SoftwareCategory>? keyValuePair = PickReleaseType(time);
		if (!keyValuePair.HasValue)
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs) && UpdateReleases(time, releases))
			{
				CheckProductUpdate(time);
			}
			return;
		}
		Dictionary<string, SoftwareProduct> needs = ChooseNeeds(keyValuePair.Value.Key, keyValuePair.Value.Value.Name, time);
		if (needs == null)
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		SoftwareProduct[] array = ChooseOS(keyValuePair.Value.Key, time);
		if (keyValuePair.Value.Key.OSSpecific && (array == null || array.Length == 0))
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		if (keyValuePair.Value.Key.ForceIssueBool(keyValuePair.Value.Value.Name, needs, array))
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		bool frameworks = Type.Frameworks;
		SoftwareFramework softwareFramework = (frameworks ? FindFramework(this, keyValuePair.Value.Value, time, BusinessSavy) : null);
		bool flag4 = softwareFramework == null && frameworks && keyValuePair.Value.Value.Iterative > 0.5f;
		if (Type.LatestTech)
		{
			InstaReseach(keyValuePair.Value.Value);
		}
		Dictionary<string, TechLevel> dictionary2 = PickTechs(keyValuePair.Value.Value, time, needs, softwareFramework, this);
		if (dictionary2 == null)
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		SoftwareProduct softwareProduct = MakeSequel(keyValuePair.Value.Key, keyValuePair.Value.Value);
		double[] array2 = ((softwareProduct != null) ? softwareProduct.Submarkets.ToArray() : PickMarketFocus(keyValuePair.Value.Value, 0.75f + BusinessSavy * 0.2f, time));
		FeatureBase[] array3 = keyValuePair.Value.Key.GenerateFeatures(UpgradeChance(), keyValuePair.Value.Value, needs, dictionary2, keyValuePair.Value.Key.GetValidSpecs(array), time, array2, MarketSimulation.Active.Random);
		if (array3 == null)
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		string[] needs2 = keyValuePair.Value.Key.GetNeeds(array3, keyValuePair.Value.Value.Name);
		if (needs2.Any((string x) => !needs.ContainsKey(x)))
		{
			if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
			{
				UpdateReleases(time, releases);
			}
			return;
		}
		TechLevel.CleanTechLevels(dictionary2, array3);
		if (_firstLaunch)
		{
			LimitInitialTechs(dictionary2, keyValuePair.Value.Value, time - Mathf.RoundToInt(GameData.ProjectDevTimeGeneric(Mathf.RoundToInt(keyValuePair.Value.Key.DevTime(array3, keyValuePair.Value.Value, this, dictionary2, array, softwareFramework, flag4, softwareProduct)))));
		}
		needs = needs2.ToDictionary((string x) => x, (string x) => needs[x]);
		List<SoftwareProduct> list = needs.Values.ToList();
		if (array != null)
		{
			list.AddRange(array);
		}
		float num9 = 0f;
		double codeProgress = PickQuality(false, true);
		double artProgress = PickQuality(true, true);
		double codeQuality = PickQuality(false, false);
		double artQuality = PickQuality(true, false);
		float devTime = keyValuePair.Value.Key.DevTime(array3, keyValuePair.Value.Value, this, dictionary2, array, null, false, softwareProduct);
		KeyValuePair<double, double> keyValuePair2 = Premarket(devTime);
		bool subscription = false;
		SDateTime sDateTime = PickReleaseDate(keyValuePair.Value.Key, keyValuePair.Value.Value, array3, dictionary2, array, softwareProduct, softwareFramework, flag4, time);
		int monthsFlat = SDateTime.GetMonthsFlat(time, sDateTime);
		ProductPrototype productPrototype2 = new ProductPrototype((softwareProduct != null) ? GameSettings.Instance.simulation.GenerateProductSequalName(softwareProduct.Name) : GameSettings.Instance.simulation.GenerateProductName(keyValuePair.Value.Value, null, preSim), keyValuePair.Value.Key, keyValuePair.Value.Value, needs, array, codeProgress, artProgress, codeQuality, artQuality, PickPrice(keyValuePair.Value.Key, keyValuePair.Value.Value, subscription, array3, dictionary2, BusinessSavy), subscription, array2, this, false, (float)keyValuePair2.Key, softwareProduct, array3, dictionary2, (float)((double)num9 + keyValuePair2.Value), softwareFramework, flag4 ? GameSettings.Instance.simulation.GenerateFrameworkName() : null);
		productPrototype2.SendNetwork();
		productPrototype2.StartDev(time, sDateTime);
		if (!IsSubsidiary() && (DealWindow.FindReceptionTime().HasValue || NetworkManager.IsHostingPlayers))
		{
			float num10 = ((SoftwareType.CodeArtRatio(array3) > 0f) ? MarketSimulation.Active.Random.NextFloat() : 0f);
			HUD.Instance.dealWindow.AddDeal(new WorkDeal(productPrototype2, (!(num10 > 0.5f)) ? WorkDeal.WorkType.Development : WorkDeal.WorkType.Design, this, time, monthsFlat - 2));
		}
		if (Products.Count > 0 && MarketSimulation.Active.Random.Next(0, 10 * GameSettings.DaysPerMonth) == 0)
		{
			float num11 = Utilities.RandomGaussClamped(0.5f, 0.2f, MarketSimulation.Active.Random);
			SoftwareProduct softwareProduct2 = Products.Last();
			AddFans(-Mathf.RoundToInt(num11 * (float)MarketSimulation.MagicRepFactor), softwareProduct2.Category);
		}
		if (Marketing(time) && SimulateTechResearch(time, unlockedSpecs))
		{
			UpdateReleases(time, releases);
		}
	}

	public void InstaReseach(SoftwareCategory cat)
	{
		foreach (SpecFeature item in cat.Parent.Features.Values.OfType<SpecFeature>())
		{
			int year = GameSettings.Instance.simulation.TechLevels[item.Spec].Last().Year;
			AddResearch(item.Spec, year);
		}
	}

	private void LimitInitialTechs(Dictionary<string, TechLevel> techs, SoftwareCategory cat, SDateTime time)
	{
		List<TechLevel> list = techs.Values.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			TechLevel techLevel = list[i];
			TechLevel latestTech = MarketSimulation.Active.GetLatestTech(techLevel.Spec, time, cat, this);
			if (latestTech != null && latestTech.Year < techLevel.Year)
			{
				techs[techLevel.Spec] = latestTech;
			}
		}
	}

	public static Dictionary<string, TechLevel> PickTechs(SoftwareCategory cat, SDateTime time, Dictionary<string, SoftwareProduct> needs, SoftwareFramework framework, Company c)
	{
		Dictionary<string, TechLevel> dictionary = new Dictionary<string, TechLevel>();
		foreach (SpecFeature item in cat.Parent.Features.Values.OfType<SpecFeature>())
		{
			TechLevel techLimit = cat.GetTechLimit(item, needs, framework, c, time);
			if (techLimit == null)
			{
				if (item.IsForced(cat.Name))
				{
					return null;
				}
			}
			else
			{
				dictionary[item.Spec] = techLimit;
			}
		}
		return dictionary;
	}

	public double PickQuality(bool art, bool progress)
	{
		return Utilities.RandomGaussClamped(progress ? 1f : AverageQuality, 0.1f, MarketSimulation.Active.Random);
	}

	private void CheckPorting(SDateTime time)
	{
		for (int num = Products.Count - 1; num >= 0; num--)
		{
			SoftwareProduct softwareProduct = Products[num];
			if (!softwareProduct.Traded)
			{
				if (SDateTime.GetMonths(softwareProduct.Release, time) > 36f)
				{
					break;
				}
				if (softwareProduct.Type.OSSpecific)
				{
					SHashSet<SoftwareProduct> oSSupport = GameSettings.Instance.simulation.GetOSSupport(softwareProduct.Category);
					if (oSSupport.Count > 0)
					{
						SoftwareProduct random = oSSupport.GetRandom(oSSupport.Count, MarketSimulation.Active.Random);
						bool flag = random.HasToPay(this);
						if ((!flag || random.FairPrice(time)) && SoftwareType.OSDependenciesMet(random, softwareProduct.Features))
						{
							if (flag)
							{
								UpdateOSLicense(random, SoftwareType.GetOptimalEmployeeCount(softwareProduct.DevTime)[1], false);
							}
							softwareProduct.AddOS(random);
							oSSupport.Remove(random);
							NetworkMessaging.SendPort(softwareProduct.ID, random.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
							softwareProduct.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Port, SDateTime.Now(), random.ID), true);
						}
						else if (SDateTime.GetMonths(random.Release, time) > 60f)
						{
							oSSupport.Remove(random);
						}
						break;
					}
				}
			}
		}
	}

	private SDateTime PickReleaseDate(SoftwareType type, SoftwareCategory category, FeatureBase[] features, Dictionary<string, TechLevel> techs, SoftwareProduct[] oss, SoftwareProduct sequel, SoftwareFramework framework, bool newFramework, SDateTime time)
	{
		int num = 0;
		float num2 = type.DevTime(features, category, this, techs, oss, framework, newFramework, sequel);
		bool firstLaunch = _firstLaunch;
		if (!_firstLaunch)
		{
			float artRatio = SoftwareType.CodeArtRatio(features);
			int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(num2);
			num = Mathf.RoundToInt(GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], num2, artRatio) * MarketSimulation.Active.Random.Range(0.9f, 1.1f) * 1.5f);
		}
		else
		{
			_firstLaunch = false;
		}
		SDateTime sDateTime = time + new SDateTime(num, 0);
		int num3 = 0;
		if (!firstLaunch)
		{
			float num4 = Mathf.Min(12f, MarketSimulation.Active.Random.Range(num2 / 10f, num2 / 6f));
			double num5 = MarketSimulation.TimeFactor[sDateTime.Month];
			int num6 = Mathf.RoundToInt(0f - Mathf.Min(num2 / 10f, num4 / 2f));
			int num7 = Mathf.RoundToInt((num4 % 2f == 1f) ? (num4 / 2f + 1f) : (num4 / 2f));
			for (int i = num6; i < num7; i++)
			{
				int num8 = ((i < 0) ? (12 + i) : i);
				double num9 = MarketSimulation.TimeFactor[(sDateTime.Month + num8) % 12];
				if (num9 > num5)
				{
					num5 = num9;
					num3 = i;
				}
			}
		}
		return time + new SDateTime(Mathf.Max(1, num + num3), 0);
	}

	public static float PickPrice(SoftwareType type, SoftwareCategory category, bool subscription, IList<FeatureBase> features, Dictionary<string, TechLevel> techs, float savy)
	{
		return (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(category, subscription) * category.PerceivedValue(features, techs) * (double)savy.MapRange(0f, 1f, 1.1f, 0.8f));
	}

	public static double[] PickMarketFocus(SoftwareCategory cat, float accuracy, SDateTime time)
	{
		double[] array = GameSettings.Instance.simulation.GetSubMarket(cat).ToArray();
		double[] quality = GameSettings.Instance.simulation.GetQuality(cat, time);
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += quality[i];
		}
		if (num > 0.0)
		{
			for (int j = 0; j < 3; j++)
			{
				array[j] += (1.0 - quality[j] / num) * 2.0;
			}
		}
		double num2 = 0.0;
		for (int k = 0; k < 3; k++)
		{
			array[k] += MarketSimulation.Active.Random.NextFloat() * (1f - accuracy);
			num2 += array[k];
		}
		for (int l = 0; l < 3; l++)
		{
			array[l] /= num2;
		}
		return array;
	}

	private SoftwareProduct MakeSequel(SoftwareType type, SoftwareCategory category)
	{
		List<SoftwareProduct> list = new List<SoftwareProduct>();
		for (int i = 0; i < Products.Count; i++)
		{
			SoftwareProduct softwareProduct = Products[i];
			if (softwareProduct.Type.Equals(type) && softwareProduct.Category.Equals(category) && softwareProduct.Sequel == null && (!softwareProduct.DesignerOwned || softwareProduct.LeadDesigner == LeadDesigner))
			{
				list.Add(softwareProduct);
			}
		}
		if (list.Count == 0)
		{
			for (int j = 0; j < Products.Count; j++)
			{
				SoftwareProduct softwareProduct2 = Products[j];
				if (softwareProduct2.Type.Equals(type) && softwareProduct2.Category.Equals(category) && softwareProduct2.Sequel == null && softwareProduct2.DesignerOwned)
				{
					IPDeal iPDeal = new IPDeal(softwareProduct2);
					if ((double)iPDeal.Worth() < base.Money * 0.10000000149011612)
					{
						iPDeal.BuyFromDesigner(this);
						list.Add(softwareProduct2);
					}
				}
			}
		}
		if (list.Count > 0 && MarketSimulation.Active.Random.NextFloat() < category.Iterative)
		{
			SoftwareProduct r = list.MaxInstance((SoftwareProduct x) => GetFranchiseWorth(x));
			if (Releases.Any((ProductPrototype x) => x.SequelTo == r))
			{
				return null;
			}
			if (ProjectQueue.Any((ProductPrototype x) => x.SequelTo == r))
			{
				return null;
			}
			return r;
		}
		return null;
	}

	private double GetFranchiseWorth(SoftwareProduct p)
	{
		double num = p.Sum;
		for (SoftwareProduct sequelTo = p.SequelTo; sequelTo != null; sequelTo = sequelTo.SequelTo)
		{
			num += sequelTo.Sum;
		}
		return num;
	}

	private float OwnedSavvy()
	{
		if (!IsPlayerOwned())
		{
			return BusinessSavy / 2f;
		}
		return 1f;
	}

	private float OwnedQuality()
	{
		if (!IsPlayerOwned())
		{
			return AverageQuality;
		}
		return 0.5f;
	}

	private double GetProductMonthlyCost(ProductPrototype product)
	{
		if (!product.IsInDeal())
		{
			return Math.Sqrt(base.Money / 100000.0) / 1.5 * (double)OwnedSavvy().MapRange(0f, 1f, 1f, 0.75f) * (double)OwnedQuality().MapRange(0f, 1f, 0.5f, 1f) * (double)(Employee.AverageWage * (float)SoftwareType.GetOptimalEmployeeCount(product.DevTime).Sum()) / (double)GameSettings.DaysPerMonth;
		}
		return 0.0;
	}

	private void PayExpenses(SDateTime time)
	{
		double num = 0.0;
		for (int i = 0; i < Products.Count; i++)
		{
			SoftwareProduct softwareProduct = Products[i];
			if (!softwareProduct.Traded && SDateTime.GetMonths(softwareProduct.Release, time) < softwareProduct.DevTime)
			{
				double num2 = (double)SoftwareType.GetOptimalEmployeeCount(softwareProduct.DevTime).Sum() * softwareProduct.GetTime(time);
				num += (double)Employee.AverageWage * num2 / (double)GameSettings.DaysPerMonth;
			}
		}
		if (SpecResearch != null)
		{
			int optimalEmployees = GameData.GetOptimalEmployees(Mathf.CeilToInt(GameSettings.Instance.simulation.GetTechMonths(SpecResearch.Spec)));
			num += (double)(Employee.AverageWage * (float)optimalEmployees / (float)GameSettings.DaysPerMonth);
		}
		if (LeadDesigner != null)
		{
			num += (double)(LeadDesigner.GetMonthlySalary(null) / (float)GameSettings.DaysPerMonth);
		}
		double num3 = (Products.Where((SoftwareProduct x) => !x.Traded).SumSafe((SoftwareProduct x) => Math.Max(0.0, x.Sum - x.Loss)) * 2.0 + TwelveMonthAverageProfit()) / 3.0 / (5000.0 * (double)(1f + OwnedSavvy()));
		if (Type.Types.ContainsKey(new KeyValuePair<string, string>("Operating System", "Computer")))
		{
			num3 /= 2.0;
		}
		num3 *= 0.1 + (double)Utilities.RandomGaussClamped(0f, 0.05f, MarketSimulation.Active.Random);
		num3 = Math.Max(1.0, num3);
		double num4 = (double)((0f - (OwnedQuality() + Utilities.RandomGaussClamped(0f, 0.05f, MarketSimulation.Active.Random))) * 1000f) * num3;
		num4 /= (double)GameSettings.DaysPerMonth;
		if (Distribution != null)
		{
			double num5 = (double)Distribution.ActualUsers / (double)MarketSimulation.Population;
			num5 *= 1.0 - MarketSimulation.GetPhysicalVsDigital(time);
			num4 -= num5 * 4000000.0;
			num += num5 * 400000.0;
		}
		if (CampaignProtected)
		{
			if (base.Money < 200000.0)
			{
				return;
			}
			double num6 = base.Money.MapRange(5000000.0, 30000000.0, 0.05000000074505806, 0.5, true);
			if (num - num4 > base.Money * num6)
			{
				double num7 = base.Money * num6;
				double num8 = num - num4;
				num = num / num8 * num7;
				num4 = num4 / num8 * num7;
			}
		}
		MakeTransaction(0.0 - num, TransactionCategory.Salaries, true);
		MakeTransaction(num4, TransactionCategory.Bills, true);
	}

	private double TwelveMonthAverageProfit()
	{
		List<float> value;
		if (Cashflow.TryGetValue("Balance", out value) && value.Count > 1)
		{
			int num = Mathf.Min(12, value.Count - 1);
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				num2 += (double)(value[value.Count - 1 - i] - value[value.Count - 2 - i]);
			}
			return Math.Max(num2 / (double)num, 0.0);
		}
		return 0.0;
	}

	public override bool CanTakeStockFrom()
	{
		return true;
	}

	private float GetMinShares(SDateTime time)
	{
		if (!CampaignProtected)
		{
			return Mathf.Min(0.55f, SDateTime.GetYears(Founded, time) * 0.05f);
		}
		return 0.55f;
	}

	private void TradeStocks(bool soldStocks, bool isBankrupting, SDateTime time)
	{
		if (IsSubsidiary())
		{
			return;
		}
		List<NewStock> list = null;
		if (!soldStocks && !isBankrupting)
		{
			list = new List<NewStock>(NewStock);
			double share = GetShare();
			float num = ((share < 0.5) ? 0.2f : 0.05f);
			double num2 = Math.Max(0.0, 1.0 - share - (double)GetMinShares(time));
			uint num3 = (uint)((double)Shares * num2);
			if (num3 != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					NewStock newStock = list[i];
					uint num4 = num3.Min(newStock.Shares);
					if ((double)num4 * newStock.ShareWorth < GetStockBudget(base.Money * (double)num) && newStock.Buyer is SimulatedCompany)
					{
						TradeStock(this, num4, time, null, newStock);
					}
					else if (newStock.Buyer.IsInvestor)
					{
						uint num5 = num4.Min((uint)(GetStockBudget(base.Money * 0.10000000149011612) / newStock.ShareWorth));
						if (num5 != 0)
						{
							TradeStock(this, num5, time, null, newStock);
						}
					}
				}
			}
			list.Clear();
			list.AddRange(NewOwnedStock);
		}
		else
		{
			list = new List<NewStock>(NewOwnedStock);
		}
		for (int j = 0; j < list.Count; j++)
		{
			NewStock newStock2 = list[j];
			if (newStock2.Seller.Bankrupt || (newStock2.Seller.Player && newStock2.Seller.TakeOver.HasValue) || newStock2.Seller.Bankrupt)
			{
				continue;
			}
			if (newStock2.Seller.CanBuyOut(this))
			{
				SimulatedCompany simulatedCompany;
				if ((simulatedCompany = newStock2.Seller as SimulatedCompany) != null)
				{
					if (simulatedCompany.CampaignProtected || SDateTime.GetMonthsFlat(newStock2.Seller.Founded, time) <= 12 || !(newStock2.Seller.GetBuyOutPrice(this) < GetStockBudget(base.Money * 0.5)))
					{
						continue;
					}
					uint v = (uint)(((float)newStock2.Shares - (float)newStock2.Seller.Shares * 0.25f) / 0.75f);
					v = v.Min(newStock2.Shares);
					if ((double)v * newStock2.ShareWorth < newStock2.Seller.Money * 0.75)
					{
						newStock2.Seller.TradeStock(newStock2.Seller, v, time, null, newStock2);
						newStock2.Seller.StockQuarantine = 12 * GameSettings.DaysPerMonth;
						continue;
					}
					bool flag = false;
					for (int k = 0; k < newStock2.Seller.NewStock.Count; k++)
					{
						NewStock newStock3 = newStock2.Seller.NewStock[k];
						if (newStock3.Buyer != this)
						{
							if (newStock3.Buyer.CanTakeStockFrom())
							{
								newStock2.Seller.TradeStock(this, newStock3.Shares, time, null, newStock3);
								k--;
							}
							else
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						newStock2.Seller.BuyOut(new Company[1] { this }, false, time);
					}
				}
				else
				{
					if (!newStock2.Seller.Player)
					{
						continue;
					}
					bool flag2 = true;
					for (int l = 0; l < newStock2.Seller.NewStock.Count; l++)
					{
						NewStock newStock4 = newStock2.Seller.NewStock[l];
						if (newStock4.Buyer != this && newStock4.Buyer.CanTakeStockFrom())
						{
							if (!(newStock4.TotalWorth < base.Money * 0.75))
							{
								flag2 = false;
								break;
							}
							newStock2.Seller.TradeStock(this, newStock4.Shares, time, null, newStock4);
							l--;
						}
					}
					if (flag2)
					{
						newStock2.Seller.BeginTakeover(this);
					}
				}
			}
			else if (newStock2 == newStock2.Seller.NewStock.MaxInstance((NewStock x) => x.Shares) && newStock2.Seller.GetShare() < 0.5)
			{
				if (newStock2.Seller.NewStock.Count <= 1)
				{
					continue;
				}
				uint num6 = (newStock2.Seller.Shares - newStock2.Shares).Min((uint)(GetStockBudget(base.Money * 0.10000000149011612) / newStock2.ShareWorth));
				if (num6 == 0)
				{
					continue;
				}
				int num7 = 0;
				while (num6 != 0 && num7 < newStock2.Seller.NewStock.Count)
				{
					NewStock newStock5 = newStock2.Seller.NewStock[num7];
					if (newStock5 != newStock2 && newStock5.Buyer.CanTakeStockFrom())
					{
						uint num8 = num6.Min(newStock5.Shares);
						bool num9 = num8 == newStock5.Shares;
						newStock2.Seller.TradeStock(this, num8, time, null, newStock5);
						num6 -= num8;
						if (num9)
						{
							num7--;
						}
					}
					num7++;
				}
			}
			else if (newStock2.Change > 0.25 && !newStock2.Seller.CanBuyOut(this))
			{
				float num10 = (float)(MarketSimulation.Active.Random.Next(0, 4) + 1) / 4f;
				MarketSimulation.Active.FindBuyer(newStock2, (uint)((float)newStock2.Shares * num10), time);
			}
		}
	}

	public KeyValuePair<double, double> Premarket(float devTime)
	{
		double num = (double)(4800f * devTime) * (1.0 - (double)OwnedSavvy() * 0.25);
		double num2 = base.Money * 0.10000000149011612;
		double num3 = Math.Min(1.0, num2 / num);
		double num4 = num3 * num;
		MakeTransaction(0.0 - num4, TransactionCategory.Marketing, true);
		return new KeyValuePair<double, double>(num3, num4);
	}

	private bool Marketing(SDateTime time)
	{
		HashSet<IMarketable> hashSet = new HashSet<IMarketable>();
		List<object> activeDealsPerformance = HUD.Instance.dealWindow.GetActiveDealsPerformance();
		for (int i = 0; i < activeDealsPerformance.Count; i++)
		{
			WorkDeal workDeal;
			MarketingPlan marketingPlan;
			if ((workDeal = activeDealsPerformance[i] as WorkDeal) != null && workDeal.workType == WorkDeal.WorkType.Marketing && (marketingPlan = workDeal.WorkItem as MarketingPlan) != null)
			{
				hashSet.Add(marketingPlan.TargetProduct);
			}
		}
		double num = 0.0;
		lock (_marketingCache)
		{
			_marketingCache.Clear();
			for (int j = 0; j < Products.Count; j++)
			{
				SoftwareProduct softwareProduct = Products[j];
				if (SDateTime.GetMonths(softwareProduct.Release, time) <= 12f || softwareProduct.GetCashflow(false).GetLastOrDefault(0f) > 1000f)
				{
					softwareProduct = softwareProduct.GetLatestSuccessor();
					_marketingCache.Add(softwareProduct);
				}
			}
			for (int k = 0; k < Publishing.Count; k++)
			{
				if (Publishing[k].Deals.Contains("Marketing"))
				{
					SoftwareProduct productTarget = Publishing[k].ProductTarget;
					if (productTarget != null && (SDateTime.GetMonths(productTarget.Release, time) <= 12f || productTarget.GetCashflow(false).GetLastOrDefault(0f) > 1000f))
					{
						_marketingCache.Add(productTarget);
					}
				}
			}
			foreach (SoftwareProduct item in from x in _marketingCache.OfType<SoftwareProduct>()
				orderby x.Release descending
				select x)
			{
				if (!hashSet.Contains(item))
				{
					double num2 = (double)MarketingPlan.PostMarketingPrice * 0.8 * (double)(1f - OwnedSavvy() / 2f);
					float num3 = Mathf.Max(Utilities.GetMarketingEffort(item.Category.Retention), GameSettings.Instance.simulation.GetMaxAwareness(item));
					double val = Math.Floor(num2 * (double)Math.Max(0f, num3 - item.GetRealAwareness()));
					double num4 = Math.Min(base.Money * 0.1, val);
					if (item.DevCompany != this && SDateTime.GetMonths(item.Release, time) > 2f)
					{
						num4 = Math.Max(0.0, Math.Min((double)item.LastDayGross * 0.75, num4));
					}
					double num5 = num4 * (double)(item.OpenSource ? 0.5f : 1f);
					if (!(num4 > 0.0) || !(num + num5 < base.Money))
					{
						break;
					}
					num += num5;
					item.AddLoss((float)num5, SoftwareProduct.LossType.Marketing, true);
					if (item.Publishing != null && item.Publishing.Publisher == this)
					{
						item.Publishing.AddInvestment(num5);
					}
					item.AddToMarketing((float)(num4 / num2));
				}
			}
			MakeTransaction(0.0 - num, TransactionCategory.Marketing, true);
			if (Bankrupt)
			{
				return false;
			}
		}
		lock (_marketingCache)
		{
			_marketingCache.Clear();
			for (int num6 = 0; num6 < AddOns.Count; num6++)
			{
				AddOnProduct addOnProduct = AddOns[num6];
				float months = SDateTime.GetMonths(addOnProduct.Release, time);
				if (addOnProduct.LastMonthIncome > 1000f || months <= 6f)
				{
					_marketingCache.Add(addOnProduct);
				}
			}
			for (int num7 = 0; num7 < Publishing.Count; num7++)
			{
				if (!Publishing[num7].Deals.Contains("Marketing"))
				{
					continue;
				}
				SoftwareProduct productTarget2 = Publishing[num7].ProductTarget;
				if (productTarget2 == null || Publishing[num7].ProductTarget.ForcedAddons == null)
				{
					continue;
				}
				for (int num8 = 0; num8 < productTarget2.ForcedAddons.Length; num8++)
				{
					AddOnProduct addOnProduct2 = productTarget2.ForcedAddons[num8];
					if (SDateTime.GetMonths(addOnProduct2.Release, time) <= 6f || addOnProduct2.LastMonthIncome > 1000f)
					{
						_marketingCache.Add(addOnProduct2);
					}
				}
			}
			foreach (AddOnProduct item2 in from x in _marketingCache.OfType<AddOnProduct>()
				orderby x.Release descending
				select x)
			{
				float months2 = SDateTime.GetMonths(item2.Release, time);
				float num9 = MarketingPlan.PostMarketingPrice * 0.8f * (1f - OwnedSavvy() / 2f);
				float maxAwareness = item2.Parent.GetMaxAwareness(item2);
				double num10 = Math.Min(val2: Mathf.Floor(num9 * Mathf.Max(0f, maxAwareness - item2.GetRealAwareness())), val1: base.Money * 0.1);
				if (months2 > 2f)
				{
					num10 = Math.Max(0.0, Math.Min(item2.Gross * 0.5, num10 + (double)item2.PostMarketingLoss) - (double)item2.PostMarketingLoss);
				}
				double num11 = num10 * (double)((item2.Price < 0.01f) ? 0.5f : 1f);
				if (num10 > 0.0 && num + num11 < base.Money)
				{
					num += num11;
					item2.AddLoss((float)num11, SoftwareProduct.LossType.Marketing, true);
					if (item2.Parent.Publishing != null && item2.Parent.Publishing.Publisher == this)
					{
						item2.Parent.Publishing.AddInvestment(num11);
					}
					item2.AddToMarketing((float)(num10 / (double)num9));
					continue;
				}
				break;
			}
		}
		return !Bankrupt;
	}

	public Dictionary<string, SoftwareProduct> ChooseNeeds(SoftwareType type, string category, SDateTime time)
	{
		Dictionary<string, SoftwareProduct> dictionary = new Dictionary<string, SoftwareProduct>();
		Dictionary<string, List<string>> needsWithSpecs = type.GetNeedsWithSpecs(category);
		if (needsWithSpecs.Count > 0)
		{
			List<SoftwareProduct> list = GameSettings.Instance.simulation.GetAllProducts(false).ToList();
			foreach (KeyValuePair<string, List<string>> item in needsWithSpecs)
			{
				double num = double.MinValue;
				SoftwareProduct softwareProduct = null;
				for (int i = 0; i < list.Count; i++)
				{
					SoftwareProduct softwareProduct2 = list[i];
					if ((softwareProduct2.InHouse && softwareProduct2.DevCompany != this) || !softwareProduct2.Type.Name.Equals(item.Key) || (time - softwareProduct2.Release).Year >= 5 || !softwareProduct2.FairPrice(time))
					{
						continue;
					}
					double num2 = softwareProduct2.RelativeFeatureScore(MarketSimulation.Active, time) + (double)(MarketSimulation.Active.Random.NextFloat() * 0.05f);
					for (int j = 0; j < item.Value.Count; j++)
					{
						num2 += (double)softwareProduct2.TechLevels.GetOrDefault(item.Value[j], (TechLevel z) => z.ActualYear, 0);
					}
					if (num2 > num && (softwareProduct == null || !softwareProduct2.DevCompany.Player || GameSettings.IgnoreBusinessRep || MarketSimulation.Active.Random.NextFloat() < softwareProduct2.DevCompany.BusinessReputation))
					{
						num = num2;
						softwareProduct = softwareProduct2;
					}
				}
				if (softwareProduct != null)
				{
					dictionary.Add(item.Key, softwareProduct);
				}
			}
		}
		return dictionary;
	}

	public SoftwareProduct[] ChooseOS(SoftwareType type, SDateTime time)
	{
		if (!type.OSSpecific)
		{
			return null;
		}
		List<SoftwareProduct> secondaryWhere = GameSettings.Instance.simulation.GetAllProducts(false).GetSecondaryWhere((SoftwareProduct x) => x.Sequel == null && x.Type.Name.Equals("Operating System") && type.SupportsOS(x.Category.Name), (SoftwareProduct x) => (time - x.Release).Year < 5 && x.FairPrice(time));
		SoftwareType softwareType = MarketSimulation.Active.SoftwareTypes["Operating System"];
		HashSet<SoftwareCategory> hashSet = new HashSet<SoftwareCategory>();
		foreach (SoftwareCategory value in softwareType.Categories.Values)
		{
			if (value.IsUnlocked(time.Year) && type.SupportsOS(value.Name) && MarketSimulation.Active.Random.NextFloat() < value.TimeScale)
			{
				hashSet.Add(value);
			}
		}
		if (hashSet.Count == 0)
		{
			hashSet.Add(softwareType.Categories.Values.Where((SoftwareCategory x) => type.SupportsOS(x.Name)).MaxInstance((SoftwareCategory x) => x.TimeScale));
		}
		int count = hashSet.Count;
		int num = MarketSimulation.Active.Random.Next(count, count + 2);
		HashSet<SoftwareCategory> hashSet2 = new HashSet<SoftwareCategory>();
		List<SoftwareProduct> list = new List<SoftwareProduct>(num);
		foreach (SoftwareProduct item in secondaryWhere.OrderByDescending((SoftwareProduct x) => x.PerceivedValue(time) * x.RealQuality))
		{
			if (list.Count == num)
			{
				break;
			}
			if (hashSet.Contains(item.Category) && (hashSet2.Count == count || !hashSet2.Contains(item.Category)))
			{
				list.Add(item);
				hashSet2.Add(item.Category);
			}
		}
		return list.ToArray();
	}

	public override bool CanMakeSequel(SoftwareProduct p)
	{
		if (!base.CanMakeSequel(p))
		{
			return false;
		}
		if (Releases.Any((ProductPrototype y) => y.SequelTo == p) || ProjectQueue.Any((ProductPrototype y) => y.SequelTo == p))
		{
			return false;
		}
		return true;
	}

	public void CheckTopOSPort(List<SoftwareProduct> oss, SDateTime time)
	{
		SoftwareProduct softwareProduct = null;
		SDateTime sDateTime = default(SDateTime);
		for (int i = 0; i < Products.Count; i++)
		{
			SoftwareProduct softwareProduct2 = Products[i];
			if (softwareProduct2.Type.OSSpecific && (softwareProduct == null || softwareProduct2.Release > sDateTime))
			{
				softwareProduct = softwareProduct2;
				sDateTime = softwareProduct2.Release;
			}
		}
		if (softwareProduct == null)
		{
			return;
		}
		for (int j = 0; j < oss.Count; j++)
		{
			SoftwareProduct softwareProduct3 = oss[j];
			if ((!softwareProduct.Type.HasOSLimits() || softwareProduct.Type.SupportsOS(softwareProduct3.Category.Name)) && softwareProduct3.FairPrice(time) && !MarketSimulation.Active.IsCompatibleOS(softwareProduct, softwareProduct3) && SoftwareType.OSDependenciesMet(softwareProduct3, softwareProduct.Features))
			{
				if (softwareProduct3.HasToPay(this))
				{
					UpdateOSLicense(softwareProduct3, SoftwareType.GetOptimalEmployeeCount(softwareProduct.DevTime)[1], false);
				}
				softwareProduct.AddOS(softwareProduct3);
				NetworkMessaging.SendPort(softwareProduct.ID, softwareProduct3.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				softwareProduct.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Port, SDateTime.Now(), softwareProduct3.ID), true);
			}
		}
	}

	public SoftwareProduct GenerateDistributionPlatform(SDateTime time, DistributionPlatform existing)
	{
		SoftwareType digitalDistSoft = MarketSimulation.Active.DigitalDistSoft;
		SoftwareCategory softwareCategory = digitalDistSoft.Categories.Values.First();
		string name = ((Distribution != null) ? MarketSimulation.Active.GenerateProductSequalName(Distribution.Software.Name, true) : MarketSimulation.Active.GeneratePlatformName());
		Dictionary<string, TechLevel> dictionary = new Dictionary<string, TechLevel>();
		List<FeatureBase> list = new List<FeatureBase>();
		foreach (SpecFeature item in digitalDistSoft.Features.Values.OfType<SpecFeature>())
		{
			TechLevel latestTech = MarketSimulation.Active.GetLatestTech(item.Spec, time, softwareCategory, this);
			if (item.IsUnlocked(latestTech, softwareCategory))
			{
				dictionary[item.Spec] = latestTech;
				list.Add(item);
			}
		}
		foreach (SubFeature item2 in digitalDistSoft.Features.Values.OfType<SubFeature>())
		{
			if (item2.IsUnlocked(dictionary, softwareCategory))
			{
				list.Add(item2);
			}
		}
		return new SoftwareProduct(name, digitalDistSoft, softwareCategory, Array.Empty<SoftwareProduct>(), 1.0, 1.0, 1.0, 1.0, new double[3] { 1.0, 1.0, 1.0 }, 1.0, 0f, false, new double[3]
		{
			1.0 / 3.0,
			1.0 / 3.0,
			1.0 / 3.0
		}, time, time, 0, false, this, null, (existing != null) ? existing.Software.ID : MarketSimulation.Active.GetID(), 0.0, list.ToArray(), dictionary, null, 0u, null, 0f, new Dictionary<SoftwareProduct, float>());
	}

	public ProductPrototype GetPrototype(uint id)
	{
		return ProjectQueue.FirstOrDefault((ProductPrototype x) => x.SWID.HasValue && x.SWID.Value == id) ?? Releases.FirstOrDefault((ProductPrototype x) => x.SWID.HasValue && x.SWID.Value == id);
	}

	public override void EndDayCallback(SDateTime time)
	{
		if (time.Day == 0)
		{
			StockBudgetUsed = 0f;
		}
	}
}
