using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class IPDeal : Deal
{
	public SoftwareProduct[] _products;

	public AddOnProduct[] AddOns;

	public SoftwareFramework Framework;

	private readonly float worth;

	public readonly SDateTime Date;

	public string GetSWType()
	{
		if (_products.Length != 0)
		{
			return _products[0].Type.Name;
		}
		if (AddOns.Length != 0)
		{
			return AddOns[0].SWType.Name;
		}
		if (Framework != null)
		{
			return Framework.Type.Name;
		}
		return null;
	}

	public string GetSWCategory()
	{
		if (_products.Length != 0)
		{
			return _products[0].Category.Name;
		}
		if (AddOns.Length != 0)
		{
			return AddOns[0].SWCat.Name;
		}
		if (Framework != null)
		{
			return Framework.Category.Name;
		}
		return null;
	}

	public string GetIPName()
	{
		if (_products.Length != 0)
		{
			return _products[0].Name;
		}
		if (AddOns.Length != 0)
		{
			return AddOns[0].Name;
		}
		if (Framework != null)
		{
			return Framework.Name;
		}
		return "NotApplicableAbbr".Loc();
	}

	public Employee GetIPOwner()
	{
		if (_products.Length != 0 && _products[0].DesignerOwned)
		{
			return _products[0].LeadDesigner;
		}
		return null;
	}

	public IPDeal(Company c, uint id, uint[] products, uint addonProduct, uint addon, uint framework, float dealWorth, SDateTime date)
		: base(c, id)
	{
		if (addonProduct != 0)
		{
			_products = Array.Empty<SoftwareProduct>();
			SoftwareProduct product = MarketSimulation.Active.GetProduct(addonProduct, false);
			AddOns = new AddOnProduct[1] { product.GetAddon(addon) };
		}
		else
		{
			_products = products.SelectInPlace((uint x) => MarketSimulation.Active.GetProduct(x, false));
			AddOns = GetAddons(_products);
		}
		Framework = MarketSimulation.Active.GetFramework(framework);
		worth = dealWorth;
		Date = date;
	}

	public IPDeal(SoftwareProduct product, bool ignorePlayer = false)
		: base(product.DevCompany)
	{
		_products = GetIP(product);
		AddOns = GetAddons(_products);
		Company client = base.Client;
		if (client != null && client.IsPlayerOwned())
		{
			worth = 0f;
			return;
		}
		if (!ignorePlayer && client != null && client.IsLocalPlayer)
		{
			if (HUD.Instance.docWindow.SequelTo != null && _products.Contains(HUD.Instance.docWindow.SequelTo))
			{
				HUD.Instance.docWindow.SequelTo = null;
			}
			if (HUD.Instance.addonDesignWindow.Window.Shown && HUD.Instance.addonDesignWindow.ParentProduct != null && _products.Contains(HUD.Instance.addonDesignWindow.ParentProduct))
			{
				HUD.Instance.addonDesignWindow.Window.Close();
			}
		}
		SDateTime time = SDateTime.Now();
		worth = _products.SumSafe((SoftwareProduct p) => GetProductValue(p, client, time, ignorePlayer)) + AddOns.SumSafe((AddOnProduct x) => GetProductValue(x, client, time, ignorePlayer));
	}

	public IPDeal(SoftwareProduct product, float amount)
		: base(product.DevCompany)
	{
		_products = GetIP(product);
		AddOns = GetAddons(_products);
		if (base.Client.IsLocalPlayer)
		{
			if (HUD.Instance.docWindow.SequelTo != null && _products.Contains(HUD.Instance.docWindow.SequelTo))
			{
				HUD.Instance.docWindow.SequelTo = null;
			}
			if (HUD.Instance.addonDesignWindow.Window.Shown && _products.Contains(HUD.Instance.addonDesignWindow.ParentProduct))
			{
				HUD.Instance.addonDesignWindow.Window.Close();
			}
		}
		worth = amount;
	}

	public static float GetWorth(SoftwareProduct product)
	{
		SoftwareProduct[] iP = GetIP(product);
		AddOnProduct[] addons = GetAddons(iP);
		SDateTime time = SDateTime.Now();
		return iP.SumSafe((SoftwareProduct p) => GetProductValue(p, p.DevCompany, time)) + addons.SumSafe((AddOnProduct x) => GetProductValue(x, x.Owner, time));
	}

	public IPDeal(AddOnProduct product)
		: base(product.Owner)
	{
		_products = Array.Empty<SoftwareProduct>();
		AddOns = new AddOnProduct[1] { product };
		Company client = base.Client;
		if (client != null && client.IsPlayerOwned())
		{
			worth = 0f;
		}
		else
		{
			worth = GetProductValue(product, client, SDateTime.Now());
		}
	}

	public IPDeal(SoftwareFramework product)
		: base(product.Owner)
	{
		_products = new SoftwareProduct[0];
		AddOns = new AddOnProduct[0];
		Framework = product;
		Company client = base.Client;
		if (client != null && client.IsPlayerOwned())
		{
			worth = 0f;
		}
		else
		{
			worth = GetProductValue(product, client, SDateTime.Now());
		}
	}

	private static float GetProductValue(SoftwareProduct p, Company client, SDateTime time, bool ignorePlayer = false)
	{
		bool flag = !ignorePlayer && client != null && client.Player;
		double num = (flag ? ((double)(client.GetReputation(p.Category) * client.DiscreteRep) * (p.RealQuality * p.RealQuality)) : 1.0);
		float num2 = 1f;
		if (p.HasWorkRoyalties)
		{
			foreach (KeyValuePair<Company, float> workRoyalty in p.GetWorkRoyalties())
			{
				num2 -= workRoyalty.Value;
			}
		}
		return (float)((double)num2 * ((double)Math.Max(0f, GetProductSaleSum(p)) + Math.Max((!flag) ? 10000 : 0, p.PerceivedValue(time) * (double)p.Category.Popularity * num * 1000000.0)));
	}

	private static float GetProductValue(SoftwareFramework p, Company client, SDateTime time, bool ignorePlayer = false)
	{
		bool flag = !ignorePlayer && client != null && client.Player;
		float num = p.Quality();
		float num2 = (flag ? (client.GetReputation(p.Category) * client.DiscreteRep * (num * num)) : 1f);
		return (float)((double)p.Income + Math.Max((!flag) ? 10000 : 0, p.Category.PerceivedValue(p.Features.Keys.ToList(), p.TechLevels) * (double)p.Category.Popularity * (double)num2 * 1000000.0));
	}

	private static float GetProductValue(AddOnProduct p, Company client, SDateTime time, bool ignorePlayer = false)
	{
		bool flag = !ignorePlayer && client != null && client.Player;
		double num = (flag ? ((double)(client.GetReputation(p.SWCat) * client.DiscreteRep) * (p.RealQuality * p.RealQuality)) : 1.0);
		float num2 = 1f;
		if (p.HasWorkRoyalties)
		{
			foreach (KeyValuePair<Company, float> workRoyalty in p.GetWorkRoyalties())
			{
				num2 -= workRoyalty.Value;
			}
		}
		return (float)((double)num2 * (p.Gross * p.GetTime(time) * 0.10000000149011612 + Math.Max((!flag) ? (p.Competitive ? 1000 : 0) : 0, p.PerceivedValue(time) * (double)p.SWCat.Popularity * num * (double)(p.Competitive ? 100000 : 10000))));
	}

	private static float GetProductSaleSum(SoftwareProduct p)
	{
		float num = 0f;
		float months = SDateTime.GetMonths(p.Release, SDateTime.Now());
		List<float> cashflow = p.GetCashflow(false);
		float num2 = Mathf.Pow(0.95f, months - (float)cashflow.Count);
		for (int i = 0; i < 12; i++)
		{
			int num3 = cashflow.Count - 1 - i;
			if (num3 < 0)
			{
				break;
			}
			num += cashflow[num3] * num2;
			num2 *= 0.95f;
		}
		return num;
	}

	public IPDeal(SoftwareProduct product, Company company, SDateTime date)
		: base(company, true)
	{
		_products = GetIP(product);
		AddOns = GetAddons(_products);
		worth = (float)(_products.Sum(delegate(SoftwareProduct p)
		{
			double marketWeightedQuality = p.GetMarketWeightedQuality(p.GetQuality(date));
			return (double)Mathf.Max(0f, GetProductSaleSum(p)) + marketWeightedQuality * p.PerceivedValue(date) * (double)p.Category.Popularity * 500000.0 * (double)Utilities.RandomGauss(0.7f, 0.1f);
		}) + AddOns.SumSafe((AddOnProduct x) => x.Gross + x.GetMarketWeightedQuality(x.Quality) * (double)x.SWCat.Popularity * 50000.0 * (double)Utilities.RandomGauss(0.7f, 0.1f)));
		Date = date;
	}

	public IPDeal()
	{
	}

	private static AddOnProduct[] GetAddons(SoftwareProduct[] ps)
	{
		List<AddOnProduct> list = new List<AddOnProduct>();
		foreach (SoftwareProduct softwareProduct in ps)
		{
			foreach (KeyValuePair<SoftwareAddOn, List<AddOnProduct>> addon in softwareProduct.Addons)
			{
				foreach (AddOnProduct item in addon.Value)
				{
					if (!item.Competitive || item.Owner == softwareProduct.DevCompany)
					{
						list.Add(item);
					}
				}
			}
		}
		return list.ToArray();
	}

	public static SoftwareProduct[] GetIP(SoftwareProduct product)
	{
		int num = CountIP(product, out product);
		SoftwareProduct[] array = new SoftwareProduct[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = product;
			product = product.Sequel;
		}
		return array;
	}

	private static int CountIP(SoftwareProduct product, out SoftwareProduct start)
	{
		while (product.SequelTo != null)
		{
			product = product.SequelTo;
		}
		start = product;
		int num = 0;
		while (product != null)
		{
			num++;
			product = product.Sequel;
		}
		return num;
	}

	public override string ReputationCategory()
	{
		return null;
	}

	public void BuyFromDesigner(Company c)
	{
		c.MakeTransaction(0f - worth, Company.TransactionCategory.Deals, true, Title());
		_products.ForEachEnum(delegate(SoftwareProduct x)
		{
			x.DesignerOwned = false;
		});
	}

	private void FixDesigner(Company newOwner)
	{
		if (_products == null || _products.Length == 0 || !_products[0].DesignerOwned)
		{
			return;
		}
		SoftwareProduct softwareProduct = _products.FirstOrDefault((SoftwareProduct x) => x.LeadDesigner != null);
		if (softwareProduct != null && softwareProduct.LeadDesigner.MyEmployer != newOwner)
		{
			_products.ForEachEnum(delegate(SoftwareProduct x)
			{
				x.DesignerOwned = false;
			});
		}
	}

	public override void Accept(Company company)
	{
		base.Accept(company);
		string bill = Title();
		SoftwareProduct[] array;
		AddOnProduct[] array2;
		if (_products.Length != 0)
		{
			array = GetIP(_products[0]);
			array2 = GetAddons(array);
		}
		else
		{
			array = Array.Empty<SoftwareProduct>();
			array2 = AddOns;
		}
		if (Request)
		{
			if (base.Bidder != null)
			{
				if (company.OwnerCompany != base.Bidder || base.Bidder.OwnerCompany == company)
				{
					if (array.Length == 0 || !array[0].DesignerOwned)
					{
						bool flag = false;
						if (worth > 0f && array.Length != 0 && array[0].BoughtFor >= 0f)
						{
							float num = worth - array[0].BoughtFor;
							GameSettings.Instance.MyCompany.AddTax((num > 0f) ? TaxReport.TaxType.Income : TaxReport.TaxType.Depreciation, num);
							flag = true;
						}
						GameSettings.Instance.MyCompany.MakeTransaction(worth, Company.TransactionCategory.Deals, !flag, bill);
					}
					base.Bidder.MakeTransaction(0f - worth, Company.TransactionCategory.Deals, false, bill);
					FixDesigner(base.Bidder);
				}
				if (array.Length != 0)
				{
					MarketEvent ev = new MarketEvent(MarketEvent.EventType.IPTrade, SDateTime.Now(), worth, array[0].ID, GameSettings.Instance.MyCompany.ID, base.Bidder.ID);
					base.Bidder.AddMarketEvent(ev, true);
					GameSettings.Instance.MyCompany.AddMarketEvent(ev, true);
					array.ForEachEnum(delegate(SoftwareProduct x)
					{
						x.AddMarketEvent(ev, true);
					});
					if (worth > 0f)
					{
						array[0].BoughtFor = worth;
					}
				}
				SDateTime time = SDateTime.Now();
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					array[num2].Trade(base.Bidder, time);
				}
				for (int num3 = 0; num3 < array2.Length; num3++)
				{
					array2[num3].Trade(base.Bidder);
				}
				SoftwareFramework framework = Framework;
				if (framework != null)
				{
					framework.Transfer(base.Bidder);
				}
			}
		}
		else
		{
			float num4 = worth;
			if (company.OwnerCompany == base.Client || (base.Client != null && base.Client.OwnerCompany == company))
			{
				num4 = 0f;
			}
			if (base.Client != null && (array.Length == 0 || !array[0].DesignerOwned))
			{
				bool flag2 = false;
				if (num4 > 0f && array.Length != 0 && array[0].BoughtFor >= 0f)
				{
					float num5 = num4 - array[0].BoughtFor;
					base.Client.AddTax((num5 > 0f) ? TaxReport.TaxType.Income : TaxReport.TaxType.Depreciation, num5);
					flag2 = true;
				}
				base.Client.MakeTransaction(num4, Company.TransactionCategory.Deals, !flag2, bill);
			}
			if (array.Length != 0)
			{
				if (base.Client != null)
				{
					MarketEvent ev2 = new MarketEvent(MarketEvent.EventType.IPTrade, SDateTime.Now(), worth, array[0].ID, base.Client.ID, company.ID);
					company.AddMarketEvent(ev2, true);
					base.Client.AddMarketEvent(ev2, true);
					array.ForEachEnum(delegate(SoftwareProduct x)
					{
						x.AddMarketEvent(ev2, true);
					});
				}
				if (num4 > 0f)
				{
					array[0].BoughtFor = num4;
				}
			}
			SimulatedCompany simulatedCompany;
			if ((simulatedCompany = base.Client as SimulatedCompany) != null)
			{
				for (int num6 = 0; num6 < simulatedCompany.Releases.Count; num6++)
				{
					SimulatedCompany.ProductPrototype productPrototype = simulatedCompany.Releases[num6];
					if (productPrototype.SequelTo != null && array.Contains(productPrototype.SequelTo))
					{
						productPrototype.RemoveProject();
						num6--;
					}
				}
				for (int num7 = 0; num7 < simulatedCompany.ProjectQueue.Count; num7++)
				{
					SimulatedCompany.ProductPrototype productPrototype2 = simulatedCompany.ProjectQueue[num7];
					if (productPrototype2.SequelTo != null && array.Contains(productPrototype2.SequelTo))
					{
						productPrototype2.RemoveProject();
						num7--;
					}
				}
				if (simulatedCompany.CurrentAddonProject != null && array.Contains(simulatedCompany.CurrentAddonProject.Parent))
				{
					simulatedCompany.CurrentAddonProject.RemoveProject();
					simulatedCompany.CurrentAddonProject = null;
				}
			}
			company.MakeTransaction(0f - num4, Company.TransactionCategory.Deals, false, bill);
			SDateTime time2 = SDateTime.Now();
			foreach (SoftwareProduct softwareProduct in array)
			{
				HUD.Instance.dealWindow.CancelProductDeals(softwareProduct, true);
				softwareProduct.Trade(company, time2);
			}
			for (int num9 = 0; num9 < array2.Length; num9++)
			{
				array2[num9].Trade(company);
				HUD.Instance.dealWindow.CancelProductDeals(array2[num9]);
			}
			SoftwareFramework framework2 = Framework;
			if (framework2 != null)
			{
				framework2.Transfer(company);
			}
			FixDesigner(company);
		}
		HUD.Instance.ApplyProductWindowFilters();
	}

	public override void RecalculateWorth()
	{
	}

	public override float Worth()
	{
		return worth;
	}

	public override string Description()
	{
		return "IPDeal".Loc(GetIPName());
	}

	public override string Title()
	{
		return "IntellectualPropertyAbbr";
	}

	public override float Payout()
	{
		return 0f;
	}

	public override void HandleUpdate()
	{
	}

	public override void GetDetailedDescription(List<string> vars, List<string> values)
	{
		vars.Add("Offer".Loc());
		values.Add(worth.Currency());
	}

	public override bool CancelOnAccept()
	{
		return true;
	}

	public override SDateTime? GetTime()
	{
		return null;
	}

	public override bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		return false;
	}

	public override byte GetTypeID()
	{
		return 1;
	}

	public override void WriteTypeData(Stream st)
	{
		st.WriteArray(_products, delegate(Stream s, SoftwareProduct x)
		{
			s.WriteUInt(x.ID);
		});
		if (_products.Length == 0 && AddOns.Length != 0)
		{
			st.WriteUInt(AddOns[0].Parent.ID);
			st.WriteUInt(AddOns[0].ID);
		}
		else
		{
			st.WriteUInt(0u);
			st.WriteUInt(0u);
		}
		SoftwareFramework framework = Framework;
		st.WriteUInt((framework != null) ? framework.ID : 0u);
		st.WriteFloat(worth);
		Date.WriteData(st);
	}

	public override IReferenceFix FixReferences()
	{
		if (base.FixReferences() == null)
		{
			return null;
		}
		if (_products != null && _products.Length != 0)
		{
			_products = _products.SelectNotNull((SoftwareProduct x) => x.FixReferences() as SoftwareProduct).ToArray();
			if (_products.Length == 0)
			{
				return null;
			}
		}
		if (Framework != null)
		{
			Framework = Framework.FixReferences() as SoftwareFramework;
			if (Framework == null)
			{
				return null;
			}
		}
		if (AddOns != null && AddOns.Length != 0)
		{
			AddOns = AddOns.SelectNotNull((AddOnProduct x) => x.FixReferences() as AddOnProduct).ToArray();
			if (AddOns.Length == 0)
			{
				return null;
			}
		}
		return this;
	}

	public override bool StillValid(bool active)
	{
		SoftwareProduct start;
		if (SDateTime.GetMonths(Date, SDateTime.Now()) < 1f && CountIP(_products[0], out start) == _products.Length)
		{
			if (Request)
			{
				if (base.Bidder != null)
				{
					return !base.Bidder.IsSubsidiary();
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override float ReputationEffect(bool ending)
	{
		return 0f;
	}
}
