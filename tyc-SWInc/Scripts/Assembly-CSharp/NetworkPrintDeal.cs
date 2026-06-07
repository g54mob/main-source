using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class NetworkPrintDeal : IStockable, ILossable, IReferenceFix, IByteData, IFormatColorObject
{
	public string ProductName;

	public float Markup;

	public uint DealID;

	public byte Client;

	public byte Printer;

	[NonSerialized]
	private Company _clientC;

	public IStockable Target;

	public List<FeatureBase> Features;

	public List<uint> FeatureFactors;

	private uint _buffer;

	public float OnCompletion;

	public float Penalty;

	public uint MaxCopies;

	public uint PerDay;

	public SDateTime? Deadline;

	private uint _physicalCopies;

	public float Cost
	{
		get
		{
			return GetCost(this, Markup);
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
			if (NetworkManager.LocalPlayerID != Printer)
			{
				Debug.LogError("Tried to change physical copies for a network print deal player is not the owner of");
			}
			else if (value > _physicalCopies)
			{
				uint num = value - _physicalCopies;
				if (NetworkManager.IsPlayerOffline(Client))
				{
					_buffer += num;
				}
				else
				{
					if (_clientC == null)
					{
						_clientC = MarketSimulation.Active.GetPlayerCompany(Client);
					}
					num += _buffer;
					_buffer = 0u;
					float num2 = (float)num * Cost;
					GameSettings.Instance.MyCompany.MakeTransaction(num2, Company.TransactionCategory.Contracts, true, "Productprintorders", true);
					Company clientC = _clientC;
					if (clientC != null)
					{
						clientC.MakeTransaction(0f - num2, Company.TransactionCategory.Contracts, true, "Productprintorders");
					}
					NetworkMessaging.SendNetworkPrintDealChange(DealID, num, NetworkMessaging.MessageTarget.Specifically, Client);
				}
				_physicalCopies = value;
			}
			else
			{
				Debug.LogError("Tried to subtract physical copies from a network print deal");
			}
		}
	}

	public int HardwareMask { get; set; }

	public int HardwareInputMask { get; set; }

	public uint CopiesPerBox
	{
		get
		{
			return 1000u;
		}
	}

	public float HardwarePrice { get; set; }

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
			return this;
		}
	}

	public SoftwareType SWType { get; set; }

	public SoftwareCategory SWCat { get; set; }

	public IManufacturable Manufacturing { get; set; }

	public IList<FeatureBase> FeaturesBases
	{
		get
		{
			return Features;
		}
	}

	public bool IsReadOnlyJob
	{
		get
		{
			return true;
		}
	}

	public void PurgeBuffer()
	{
		if (Printer == NetworkManager.LocalPlayerID && !NetworkManager.IsPlayerOffline(Client) && _buffer != 0)
		{
			if (_clientC == null)
			{
				_clientC = MarketSimulation.Active.GetPlayerCompany(Client);
			}
			float num = (float)_buffer * Cost;
			GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Contracts, true, "Productprintorders", true);
			Company clientC = _clientC;
			if (clientC != null)
			{
				clientC.MakeTransaction(0f - num, Company.TransactionCategory.Contracts, true, "Productprintorders");
			}
			NetworkMessaging.SendNetworkPrintDealChange(DealID, _buffer, NetworkMessaging.MessageTarget.Specifically, Client);
			_buffer = 0u;
		}
	}

	public void AddPhysicalCopies(uint copies)
	{
		_physicalCopies += copies;
	}

	public void SetPhysicalCopies(uint copies)
	{
		_physicalCopies = copies;
	}

	public NetworkPrintDeal()
	{
	}

	public NetworkPrintDeal(string productName, uint dealID, byte client, byte printer, float markup, List<uint> features, List<uint> featureFactors, uint swType, uint swCat, uint manufacturing, bool addon, float completion, float penalty, uint maxCopies, uint perDay, SDateTime? deadline, uint physicalCopies)
	{
		ProductName = productName;
		DealID = dealID;
		Target = null;
		Client = client;
		Printer = printer;
		Markup = markup;
		SWType = MarketSimulation.Active.GetSoftwareType(swType);
		SWCat = SWType.GetCategory(swCat);
		Features = features.SelectInPlaceList((uint x) => SWType.GetFeature(x));
		FeatureFactors = featureFactors;
		IManufacturable manufacturing2;
		if (!addon)
		{
			IManufacturable category = SWType.GetCategory(manufacturing);
			manufacturing2 = category;
		}
		else
		{
			IManufacturable category = SWType.GetAddon(manufacturing);
			manufacturing2 = category;
		}
		Manufacturing = manufacturing2;
		if (Manufacturing.IsHardware())
		{
			float price;
			int mask;
			int inputMask;
			Manufacturing.GetManufacturing().GetProcessInfo(Features, FeatureFactors, out price, out mask, out inputMask);
			HardwarePrice = price;
			HardwareMask = mask;
			HardwareInputMask = inputMask;
		}
		OnCompletion = completion;
		Penalty = penalty;
		MaxCopies = maxCopies;
		PerDay = perDay;
		Deadline = deadline;
		_physicalCopies = physicalCopies;
	}

	public NetworkPrintDeal(string productName, uint dealID, IStockable target, byte client, byte printer, float markup, List<FeatureBase> features, List<uint> featureFactors, SoftwareType swType, SoftwareCategory swCat, IManufacturable manufacturing, float completion, float penalty, uint maxCopies, uint perDay, SDateTime? deadline)
	{
		ProductName = productName;
		DealID = dealID;
		Target = target;
		Client = client;
		Printer = printer;
		Markup = markup;
		Features = features;
		FeatureFactors = featureFactors;
		SWType = swType;
		SWCat = swCat;
		Manufacturing = manufacturing;
		if (Manufacturing.IsHardware())
		{
			float price;
			int mask;
			int inputMask;
			Manufacturing.GetManufacturing().GetProcessInfo(Features, FeatureFactors, out price, out mask, out inputMask);
			HardwarePrice = price;
			HardwareMask = mask;
			HardwareInputMask = inputMask;
		}
		OnCompletion = completion;
		Penalty = penalty;
		MaxCopies = maxCopies;
		PerDay = perDay;
		Deadline = deadline;
	}

	public NetworkPrintDeal(uint dealID, IStockable target, NetworkPlayer printer, float markup, float completion, float penalty, uint maxCopies, uint perDay, SDateTime? deadline)
	{
		ProductName = target.GetName();
		DealID = dealID;
		Target = target;
		Client = NetworkManager.LocalPlayerID;
		Printer = printer.ID;
		Markup = markup;
		Features = target.FeaturesBases.ToList();
		IList<uint> featuresFactors = target.GetFeaturesFactors();
		FeatureFactors = ((featuresFactors != null) ? featuresFactors.ToList() : null);
		SWType = target.SWType;
		SWCat = target.SWCat;
		Manufacturing = target.Manufacturing;
		if (Manufacturing.IsHardware())
		{
			float price;
			int mask;
			int inputMask;
			Manufacturing.GetManufacturing().GetProcessInfo(Features, FeatureFactors, out price, out mask, out inputMask);
			HardwarePrice = price;
			HardwareMask = mask;
			HardwareInputMask = inputMask;
		}
		OnCompletion = completion;
		Penalty = penalty;
		MaxCopies = maxCopies;
		PerDay = perDay;
		Deadline = deadline;
		if (PerDay != 0)
		{
			_physicalCopies = target.PhysicalCopies;
		}
	}

	public IReferenceFix FixReferences()
	{
		if (Target != null)
		{
			Target = Target.FixReferences() as IStockable;
			if (Target == null)
			{
				NetworkManager.Instance.TradeController.CancelAllTradesFor(this);
				Cancel();
				return null;
			}
			TestUpgrade();
		}
		SWType = MarketSimulation.Active.GetSoftwareType(SWType.ID);
		SWCat = SWType.GetCategory(SWCat.ID);
		Manufacturing = Manufacturing.FixReferences() as IManufacturable;
		Features = Features.SelectNotNull((FeatureBase x) => SWType.GetFeature(x.ID)).ToList();
		return this;
	}

	public void TestUpgrade()
	{
		SoftwareAlpha softwareAlpha;
		if ((softwareAlpha = Target as SoftwareAlpha) != null && softwareAlpha.Final != null)
		{
			Target = softwareAlpha.Final;
		}
		SoftwareProduct softwareProduct;
		if ((softwareProduct = Target as SoftwareProduct) != null && softwareProduct.IsMock && softwareProduct.MockSucceeded != null)
		{
			Target = softwareProduct.MockSucceeded;
		}
		SimulatedCompany.ProductPrototype productPrototype;
		if ((productPrototype = Target as SimulatedCompany.ProductPrototype) != null && productPrototype.Final != null)
		{
			Target = productPrototype.Final;
		}
	}

	public void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
	}

	public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
	}

	public float GetLicenseAmount()
	{
		return 1f;
	}

	public string GetName()
	{
		return ProductName;
	}

	public string GetIdentifyingName()
	{
		return ProductName;
	}

	public string GetCompanyName()
	{
		Company playerCompany = MarketSimulation.Active.GetPlayerCompany(Client);
		if (playerCompany == null)
		{
			return "?";
		}
		return playerCompany.Name;
	}

	public static float GetCost(IStockable s, float markup)
	{
		return Mathf.Lerp(GetActualPrintPrice(s), GetPrintPrice(s), markup);
	}

	public static float GetActualPrintPrice(IStockable s)
	{
		if (!s.Manufacturing.IsHardware())
		{
			return 0.15f;
		}
		return s.HardwarePrice;
	}

	public float GetActualPrintPrice()
	{
		return GetActualPrintPrice(this);
	}

	public static float GetPrintPrice(IStockable s)
	{
		if (!s.Manufacturing.IsHardware())
		{
			return MarketSimulation.PhysicalCopyPrice;
		}
		return s.HardwarePrice * MarketSimulation.HardwareCopyPriceFactor;
	}

	public float GetPrintPrice(bool isAI = false)
	{
		return GetPrintPrice(this);
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
		return 0u;
	}

	public float GetRealQuality()
	{
		return 0f;
	}

	public uint GetFollowers()
	{
		return 0u;
	}

	public uint GetMaxPhysicalCopies(out IStockable limiter)
	{
		limiter = this;
		return 0u;
	}

	public void ChangeAllPhysicalStock(int change)
	{
	}

	public IList<uint> GetFeaturesFactors()
	{
		return FeatureFactors;
	}

	public IProductOrder PromoteHardware(uint copies)
	{
		return ManufactureOrder.PromoteProduct(this, copies);
	}

	public void Cancel()
	{
		GameSettings.Instance.NetworkPrintOrders.Remove(DealID);
		NetworkMessaging.SendCancelNetworkPrintDeal(DealID, NetworkMessaging.MessageTarget.Specifically, (Client == NetworkManager.LocalPlayerID) ? Printer : Client);
		HUD.Instance.distributionWindow.RefreshDeals();
	}

	public void WriteData(Stream st)
	{
		st.WriteBools(Manufacturing is SoftwareAddOn, Deadline.HasValue);
		st.WriteStringUTF8(ProductName);
		st.WriteUInt(DealID);
		st.WriteByte(Client);
		st.WriteByte(Printer);
		st.WriteFloat(Markup);
		st.WriteArray(Features, delegate(Stream s, FeatureBase x)
		{
			s.WriteUInt(x.ID);
		});
		st.WriteArray(FeatureFactors, delegate(Stream s, uint x)
		{
			s.WriteUInt(x);
		});
		st.WriteUInt(SWType.ID);
		st.WriteUInt(SWCat.ID);
		st.WriteUInt(Manufacturing.GetID());
		st.WriteFloat(OnCompletion);
		st.WriteFloat(Penalty);
		st.WriteUInt(MaxCopies);
		st.WriteUInt(PerDay);
		st.WriteUInt(PhysicalCopies);
		NetworkPrintDeal networkPrintDeal = this;
		if (networkPrintDeal.Deadline.HasValue)
		{
			networkPrintDeal.Deadline.GetValueOrDefault().WriteData(st);
		}
	}

	public static NetworkPrintDeal ReadData(Stream st)
	{
		bool b;
		bool b2;
		st.ReadBools(out b, out b2);
		return new NetworkPrintDeal(st.ReadStringUTF8(), st.ReadUInt(), (byte)st.ReadByte(), (byte)st.ReadByte(), st.ReadFloat(), st.ReadList((Stream s) => s.ReadUInt()), st.ReadList((Stream s) => s.ReadUInt()), st.ReadUInt(), st.ReadUInt(), st.ReadUInt(), completion: st.ReadFloat(), penalty: st.ReadFloat(), maxCopies: st.ReadUInt(), perDay: st.ReadUInt(), physicalCopies: st.ReadUInt(), deadline: b2 ? new SDateTime?(SDateTime.ReadData(st)) : ((SDateTime?)null), addon: b);
	}

	public override string ToString()
	{
		return ProductName;
	}

	public string GetActualString()
	{
		return ProductName;
	}

	public string GetDeadline()
	{
		if (!Deadline.HasValue)
		{
			return "NotApplicableAbbr".Loc();
		}
		return Deadline.Value.ToCompactString2();
	}

	public int GetDeadlineOrder()
	{
		if (!Deadline.HasValue)
		{
			return -1;
		}
		return Deadline.Value.ToInt();
	}
}
