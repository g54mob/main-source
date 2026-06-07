using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class PublisherDeal : IReferenceFix, IByteData
{
	public struct DealPackage
	{
		public Company Publisher;

		public float Royalty;

		public float Recoup;

		public float PostRoyalty;

		public float Deadline;

		public float Funding;

		public SoftwareCategory Cat;

		public HashSet<string> Deals;

		public DealPackage(Company publisher, SoftwareCategory cat, float royalty, float recoup, float postRoyalty, float deadline, float funding, HashSet<string> deals)
		{
			Publisher = publisher;
			Cat = cat;
			Royalty = royalty;
			Recoup = recoup;
			PostRoyalty = postRoyalty;
			Deadline = deadline;
			Funding = funding;
			Deals = deals;
		}
	}

	public const float MaxRoyalty = 0.6f;

	public Company Publisher;

	public readonly float Royalty;

	public readonly float Funding;

	public readonly float Months;

	public readonly float Recoup;

	public readonly float PostRoyalty;

	public SoftwareProduct ProductTarget;

	public SoftwareWorkItem WorkTarget;

	public SHashSet<string> Deals = new SHashSet<string>();

	public double Invested;

	public double Cut;

	public bool OldDeal = true;

	public static Dictionary<string, float> DealRoyalty = new Dictionary<string, float>
	{
		{ "Funding", 0.1f },
		{ "Marketing", 0.4f },
		{ "Printing", 0.4f },
		{ "OSExclusivity", -0.2f }
	};

	public PublisherDeal()
	{
	}

	public PublisherDeal(Company publisher, float royalty, float postRoyalty, float recoup, float funding, float months, SHashSet<string> deals)
	{
		Publisher = publisher;
		Royalty = royalty;
		PostRoyalty = postRoyalty;
		Recoup = recoup;
		Funding = funding;
		Months = months;
		Deals = deals;
		OldDeal = false;
	}

	public PublisherDeal(DealPackage package)
	{
		Publisher = package.Publisher;
		Royalty = package.Royalty;
		PostRoyalty = package.PostRoyalty;
		Recoup = package.Recoup;
		Funding = package.Funding;
		Months = package.Deadline;
		Deals = package.Deals.ToSHashSet();
		OldDeal = false;
	}

	public static DealPackage? GetDealPackage(HashSet<string> deals, SoftwareCategory cat, Company client, SimulatedCompany publisher, SDateTime devStart, float devtime, float artRatio, bool allowFunding, bool allowRelease)
	{
		if (!publisher.WillPublishPlayer || !publisher.DoingWell())
		{
			return null;
		}
		System.Random random = new System.Random(publisher.Name.GetHashCode());
		float num = 0.5f;
		float num2 = 0.5f;
		float num3 = 0.5f;
		float x = (float)random.Next(3) * 0.5f;
		switch (random.Next(5))
		{
		case 0:
			num = 0f;
			num2 = 0f;
			break;
		case 1:
			num = 0f;
			num3 = 0f;
			break;
		case 3:
			num = 1f;
			num2 = 1f;
			num3 = 0f;
			break;
		case 4:
			num = 1f;
			num3 = 1f;
			num2 = 0f;
			break;
		}
		if (!deals.Contains("Funding"))
		{
			if (!allowRelease)
			{
				num = 0.5f;
				num3 = 0.5f;
				num2 = 0.5f;
			}
			else
			{
				num2 = Mathf.Min(1f, num2 + num3);
				if (num2 >= 1f)
				{
					num = 1f;
				}
				num3 = 0f;
			}
		}
		else if (!allowRelease)
		{
			num3 = Mathf.Min(1f, num2 + num3);
			if (num3 >= 1f)
			{
				num = 1f;
			}
			num2 = 0f;
		}
		num = Mathf.Clamp01(num + (random.NextFloat() * 0.2f - 0.1f)).MapRange(0f, 1f, 0.48000002f, 0.6f + publisher.GetReputation(cat).MapRange(0f, 0.5f, 0f, 0.05f, true));
		num2 = Mathf.Clamp01(num2 + (random.NextFloat() * 0.2f - 0.1f));
		num3 = Mathf.Clamp01(num3 + (random.NextFloat() * 0.2f - 0.1f)).MapRange(0f, 1f, 0.5f, 1.5f);
		float num4 = Mathf.Lerp(client.BusinessStars.MapRange(1f, 6f, 0f, 0.75f, true), 1f, Mathf.Max((1f - publisher.BusinessSavy) * 0.25f, publisher.PlayerRelationship));
		float reputation = client.GetReputation(cat);
		float num5 = 0f;
		if (deals.Contains("Funding"))
		{
			float num6 = 1.25f;
			num5 = EstimateProjectCost(devtime, artRatio) * num6 * num4.MapRange(0f, 1f, 0.5f, 2f) * (1f + reputation * 0.25f) * num3;
			float num7 = 1f;
			if (!deals.Contains("Marketing"))
			{
				num7 += 0.5f;
			}
			if (!deals.Contains("Printing"))
			{
				num7 += 0.5f;
			}
			num5 *= num7;
			num5 = Mathf.Round(num5 / 1000f) * 1000f;
			if ((double)num5 > publisher.Money * 0.10000000149011612)
			{
				return null;
			}
		}
		float num8 = Mathf.Lerp(num2.MapRange(0f, 1f, -1f, 0f), num2, num4);
		float num9 = EstimateProjectLength(devtime, artRatio);
		num9 = ((!(num8 < 0f)) ? (num9 + num8.MapRange(0f, 1f, 0f, 6f, true)) : (num9 * num8.MapRange(0f, -1f, 1f, 0.85f, true)));
		if (allowRelease && devStart + num9 < SDateTime.Now())
		{
			return null;
		}
		if (allowFunding && allowRelease && cat.Parent.OSSpecific && publisher.Type.OSSupport(cat.Parent))
		{
			deals = new HashSet<string>(deals);
			deals.Add("OSExclusivity");
		}
		float num10 = GetRoyaltyRaw(deals) * num;
		float royalty = num10 * publisher.PlayerRelationship.MapRange(0f, 1f, 1f, x.MapRange(0f, 1f, 1f, 0.8f));
		float num11 = num10 * publisher.PlayerRelationship.MapRange(0f, 1f, 0.75f, 0.1f);
		if (num11 < 0.05f)
		{
			num11 = 0f;
		}
		float recoup = 0f;
		if (publisher.PlayerRelationship > 0f || client.DiscreteRep > 0.5f)
		{
			recoup = num4.MapRange(0f, 1f, 6f, 3f) + x.MapRange(0f, 1f, 0f, 3f);
		}
		return new DealPackage(publisher, cat, royalty, recoup, num11, num9, num5, deals);
	}

	public static float GetRoyaltyRaw(HashSet<string> deals)
	{
		float num = 1f;
		float num2 = 0f;
		foreach (string deal in deals)
		{
			float orDefault = DealRoyalty.GetOrDefault(deal, 0f);
			if (orDefault > 0f)
			{
				num2 += orDefault;
			}
			else
			{
				num *= 1f + orDefault;
			}
		}
		return num2 * num;
	}

	public static float GetRoyalty(HashSet<string> deals, SoftwareCategory cat, Company client)
	{
		return GetRoyaltyRaw(deals) * 0.6f * client.DiscreteRep.MapRange(0f, 1f, 1f, 0.75f) * client.GetReputation(cat).MapRange(0f, 1f, 1f, 0.5f);
	}

	public void Affect(SoftwareWorkItem item)
	{
		WorkTarget = item;
		item.Publishing = this;
		if (Deals.Contains("Funding"))
		{
			Publisher.MakeTransaction(0f - Funding, Company.TransactionCategory.Deals, true, "Funding");
			item.MyCompany.MakeTransaction(Funding, Company.TransactionCategory.Deals, true, "Funding");
			AddInvestment(Funding);
		}
		if (ControlReleaseSchedule())
		{
			item.ReleaseDate = item.DevStart + Months;
			item.NetworkSchedule(false);
		}
		Publisher.Publishing.Add(this);
	}

	public bool ControlReleaseSchedule()
	{
		if (OldDeal)
		{
			return Deals.Contains("ScheduleControl");
		}
		return true;
	}

	public void Affect(SoftwareProduct item)
	{
		ProductTarget = item;
		ProductTarget.Publishing = this;
		ProductTarget.AddMarketEvent(new MarketEvent(MarketEvent.EventType.PublisherChange, SDateTime.Now(), 1f, Publisher.Name), true);
		if (Deals.Contains("Funding"))
		{
			Publisher.MakeTransaction(0f - Funding, Company.TransactionCategory.Deals, true, "Funding");
			item.DevCompany.MakeTransaction(Funding, Company.TransactionCategory.Deals, true, "Funding");
			AddInvestment(Funding);
		}
		Publisher.Publishing.Add(this);
		if (Deals.Contains("Marketing") && item.DevCompany.IsLocalPlayer)
		{
			MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetProduct == item);
			if (marketingPlan != null)
			{
				marketingPlan.StopMarketing();
			}
		}
	}

	public void SendNetwork()
	{
		NetworkMessaging.SendPublishingDeal(this, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public static bool HasDeal(IMarketable item, string deal)
	{
		SoftwareProduct softwareProduct = item as SoftwareProduct;
		if (softwareProduct == null)
		{
			AddOnProduct addOnProduct = item as AddOnProduct;
			if (addOnProduct != null && addOnProduct.Forced)
			{
				return HasDeal(addOnProduct.Parent, deal);
			}
			return false;
		}
		return HasDeal(softwareProduct, deal);
	}

	public static bool HasDeal(SoftwareProduct item, string deal)
	{
		if (item.Publishing != null)
		{
			return item.Publishing.Deals.Contains(deal);
		}
		return false;
	}

	public static bool HasDeal(SoftwareWorkItem item, string deal)
	{
		if (item.AddonWorkParent != null)
		{
			return HasDeal(item.AddonWorkParent, deal);
		}
		if (item.Publishing != null)
		{
			return item.Publishing.Deals.Contains(deal);
		}
		return false;
	}

	public void Suit()
	{
		SimulatedCompany simulatedCompany;
		if ((simulatedCompany = Publisher as SimulatedCompany) != null)
		{
			simulatedCompany.WillPublishPlayer = false;
		}
	}

	public void Abandon(bool doAlert = true, bool sync = false)
	{
		if (WorkTarget != null)
		{
			WorkTarget.Publishing = null;
			if (doAlert && WorkTarget.MyCompany.IsLocalPlayer)
			{
				SoftwareWorkItem workTarget = WorkTarget;
				Company publisher = Publisher;
				NotificationManager.AddNotification(new PublisherAbandonNotification(workTarget, (publisher != null) ? publisher.Name : null));
			}
			if (WorkTarget.guiItem != null)
			{
				WorkTarget.guiItem.InitButtons();
			}
		}
		else if (ProductTarget != null)
		{
			ProductTarget.Publishing = null;
			ProductTarget.AddMarketEvent(new MarketEvent(MarketEvent.EventType.PublisherChange, SDateTime.Now(), -1f, Publisher.Name), true);
			if (doAlert && !ProductTarget.Archived && !ProductTarget.PlayerArchived && ProductTarget.DevCompany.IsLocalPlayer)
			{
				SoftwareProduct productTarget = ProductTarget;
				Company publisher2 = Publisher;
				NotificationManager.AddNotification(new PublisherAbandonNotification(productTarget, (publisher2 != null) ? publisher2.Name : null));
			}
		}
		if (Publisher != null)
		{
			Publisher.Publishing.Remove(this);
		}
	}

	public static float EstimateProjectCost(float devtime, float artRatio)
	{
		int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(devtime);
		float num = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], devtime, artRatio);
		float num2 = num * SoftwareType.DesignRatio;
		float num3 = num - num2;
		int num4 = Mathf.CeilToInt((float)optimalEmployeeCount[1] * artRatio);
		int num5 = optimalEmployeeCount[1] - num4;
		return (float)optimalEmployeeCount[0] * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Designer) * num2 + (float)num4 * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Programmer) * num3 * 1.1f + (float)num5 * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Artist) * num3;
	}

	public static float EstimateProjectLength(float devtime, float artRatio)
	{
		int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(devtime);
		float num = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], devtime, artRatio);
		float num2 = num * SoftwareType.DesignRatio;
		float num3 = num - num2;
		return num2 + num3 * 1.5f;
	}

	public override string ToString()
	{
		return Publisher.Name;
	}

	public void WriteData(Stream st)
	{
		st.WriteUInt(Publisher.ID);
		st.WriteFloat(Royalty);
		st.WriteFloat(Funding);
		st.WriteFloat(PostRoyalty);
		st.WriteFloat(Recoup);
		st.WriteFloat(Months);
		st.WriteUInt(ProductTarget.ID);
		st.WriteDouble(Invested);
		st.WriteDouble(Cut);
		st.WriteArray(Deals, delegate(Stream s, string x)
		{
			s.WriteStringUTF8(x);
		});
	}

	public void AddInvestment(double investment)
	{
		Invested += investment;
		if (ProductTarget != null)
		{
			NetworkMessaging.SendPublishingEcoChange(ProductTarget.ID, false, investment, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public float GetApplicableRoyalty()
	{
		if (Recoup <= 0f)
		{
			return Royalty;
		}
		if (!(Cut / Invested >= (double)Recoup))
		{
			return Royalty;
		}
		return PostRoyalty;
	}

	public void AddCut(double cut)
	{
		Cut += cut;
		if (ProductTarget != null)
		{
			AddRelationshipFromCut(cut);
			NetworkMessaging.SendPublishingEcoChange(ProductTarget.ID, true, cut, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public void AddRelationshipFromCut(double cut)
	{
		SimulatedCompany simulatedCompany;
		if (ProductTarget.DevCompany.IsLocalPlayer && Invested > 0.0 && (simulatedCompany = Publisher as SimulatedCompany) != null)
		{
			simulatedCompany.PlayerRelationship = Mathf.Min(1f, simulatedCompany.PlayerRelationship + Mathf.Min(0.01f, (float)(cut / Invested * 0.1)));
		}
	}

	public static PublisherDeal ReadData(Stream st)
	{
		uint num = st.ReadUInt();
		float royalty = st.ReadFloat();
		float funding = st.ReadFloat();
		float postRoyalty = st.ReadFloat();
		float recoup = st.ReadFloat();
		float months = st.ReadFloat();
		uint num2 = st.ReadUInt();
		double invested = st.ReadDouble();
		double cut = st.ReadDouble();
		SHashSet<string> deals = st.ReadArray((Stream s) => s.ReadStringUTF8()).ToSHashSet();
		PublisherDeal publisherDeal = new PublisherDeal(MarketSimulation.Active.GetCompany(num), royalty, postRoyalty, recoup, funding, months, deals);
		publisherDeal.Invested = invested;
		publisherDeal.Cut = cut;
		publisherDeal.ProductTarget = MarketSimulation.Active.GetProduct(num2, false);
		if (publisherDeal.Publisher == null)
		{
			Debug.LogError("Got publishing deal with missing company: " + num);
			return null;
		}
		if (publisherDeal.ProductTarget == null)
		{
			Debug.LogError("Got publishing deal with missing product: " + num2);
			return null;
		}
		return publisherDeal;
	}

	public IReferenceFix FixReferences()
	{
		string name = Publisher.Name;
		Publisher = MarketSimulation.Active.GetCompany(Publisher.ID);
		if (Publisher == null)
		{
			SelectorController.MissingDataHost.Add(name);
			return null;
		}
		if (ProductTarget != null)
		{
			name = ProductTarget.Name;
			ProductTarget = (SoftwareProduct)ProductTarget.FixReferences();
			if (ProductTarget == null)
			{
				SelectorController.MissingDataHost.Add(name);
				return null;
			}
		}
		return this;
	}
}
