using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ServerDeal : Deal, IServerItem, IReferenceFix
{
	private readonly uint _product;

	public float PerPower;

	private float NextPayment;

	public string activeServer;

	private bool incidents;

	public SoftwareProduct Product
	{
		get
		{
			return GameSettings.Instance.simulation.GetProduct(_product, false);
		}
	}

	public bool UsesISP
	{
		get
		{
			return true;
		}
	}

	public ServerDeal(Company c, uint id, uint product, float perPower)
		: base(c, id)
	{
		_product = product;
		PerPower = perPower;
	}

	public ServerDeal(SoftwareProduct product)
		: base(product.DevCompany)
	{
		_product = product.ID;
		float num = Server.GetISPCost() / 24f / 60f + ObjectDatabase.Instance.CheapestServer() / 60f;
		PerPower = Deal.GetPlayerWorth(num * 1.05f, num * 1.25f);
	}

	public ServerDeal()
	{
	}

	public override void RecalculateWorth()
	{
		float num = Server.GetISPCost() / 24f / 60f + ObjectDatabase.Instance.CheapestServer() / 60f;
		PerPower = Deal.GetPlayerWorth(num * 1.05f, num * 1.25f);
	}

	public override float Worth()
	{
		return PerPower * 60f;
	}

	public override bool Cancel()
	{
		if (!base.Cancel())
		{
			return false;
		}
		SoftwareProduct product = Product;
		if (product == null)
		{
			if (base.Incoming)
			{
				GameSettings.Instance.DeregisterServerItem(this);
			}
			return true;
		}
		product.ExternalHostingActive = false;
		product.ExternalHosting = 0u;
		if (base.Incoming)
		{
			GameSettings.Instance.DeregisterServerItem(this);
		}
		else
		{
			product.RegisterServer();
		}
		return true;
	}

	public override void Accept(Company company)
	{
		base.Accept(company);
		Product.ExternalHostingActive = true;
		if (base.Incoming)
		{
			GameSettings.Instance.RegisterWithServer(null, this);
		}
		else
		{
			GameSettings.Instance.DeregisterServerItem(Product);
		}
	}

	public override string Description()
	{
		return "HostingDeal".Loc(Product.Name);
	}

	public override string Title()
	{
		return "Hosting";
	}

	public override float Payout()
	{
		float nextPayment = NextPayment;
		NextPayment = 0f;
		return nextPayment;
	}

	public float GetLoadRequirement()
	{
		SoftwareProduct product = Product;
		if (product == null)
		{
			return 0f;
		}
		return product.GetLoadRequirement();
	}

	public void HandleLoad(float load)
	{
		if (Product != null)
		{
			float num = GetLoadRequirement().BandwidthFactor(SDateTime.Now());
			if (num > 0f)
			{
				NextPayment += load * PerPower * num * 60f / (float)GameSettings.DaysPerMonth;
			}
			incidents = load < 1f;
			Product.HandleLoad(load);
		}
	}

	public new string GetDescription()
	{
		return Product.GetDescription();
	}

	public override SDateTime? GetTime()
	{
		return null;
	}

	public void SerializeServer(string name)
	{
		activeServer = name;
	}

	public override void HandleUpdate()
	{
		if (!base.Incoming)
		{
			NextPayment += Utilities.PerHour(GetLoadRequirement() * PerPower * 60f);
		}
	}

	private float MaximumUsage()
	{
		SoftwareProduct product = Product;
		SoftwareType type = product.Type;
		float num = product.Category.Popularity * (float)MarketSimulation.Population;
		if (type.OSSpecific)
		{
			num = Mathf.Min(num, GameSettings.Instance.simulation.GetOSCoverage(Product.GetOSs()));
		}
		return (Product.ServerReq * num).BandwidthFactor(SDateTime.Now());
	}

	public override void GetDetailedDescription(List<string> vars, List<string> values)
	{
		vars.AddRange("Type".Loc(), "IncomeperMbperhour".Loc(), "Currentbandwidthusage".Loc(), "Maximumbandwidthusage".Loc());
		values.AddRange(Product.Type.Name.LocSW(), Worth().Currency(), Product.GetLoadRequirement().BandwidthFactor(SDateTime.Now()).Bandwidth(), MaximumUsage().Bandwidth());
	}

	public override float ReputationEffect(bool ending)
	{
		float result = (incidents ? (-0.1f) : (GetLoadRequirement().BandwidthFactor(SDateTime.Now()) / 10000000f));
		incidents = false;
		return result;
	}

	public override string ReputationCategory()
	{
		return "Hosting";
	}

	public bool CancelOnUnload()
	{
		return false;
	}

	public override bool StillValid(bool active)
	{
		if (Product == null)
		{
			return false;
		}
		if (!base.StillValid(active))
		{
			return false;
		}
		if (!active)
		{
			return SDateTime.GetMonths(Product.Release, SDateTime.Now()) <= 24f;
		}
		return true;
	}

	public override bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		SoftwareProduct product = Product;
		if (t == null || t == product.Type)
		{
			if (c != null)
			{
				return c == product.Category;
			}
			return true;
		}
		return false;
	}

	public override byte GetTypeID()
	{
		return 2;
	}

	public override void WriteTypeData(Stream st)
	{
		st.WriteUInt(_product);
		st.WriteFloat(PerPower);
	}

	public override IReferenceFix FixReferences()
	{
		if (base.FixReferences() == null || Product == null)
		{
			return null;
		}
		return this;
	}
}
