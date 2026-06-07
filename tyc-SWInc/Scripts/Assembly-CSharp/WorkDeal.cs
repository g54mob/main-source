using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class WorkDeal : Deal
{
	public enum WorkType
	{
		Design = 0,
		Development = 1,
		Support = 2,
		Marketing = 3
	}

	public WorkType workType;

	public float worth;

	public readonly SDateTime StartDate;

	public readonly int Longevity;

	public WorkItem WorkItem;

	public SimulatedCompany.ProductPrototype Prototype;

	public SoftwareProduct Product;

	public WorkDeal(Company c, uint id, SimulatedCompany.ProductPrototype proto, SoftwareProduct product, WorkType type, float dealWorth, SDateTime start, int longevity)
		: base(c, id)
	{
		Prototype = proto;
		Product = product;
		workType = type;
		worth = dealWorth;
		StartDate = start;
		Longevity = longevity;
	}

	public WorkDeal(WorkItem work, float bid)
		: base(GameSettings.Instance.MyCompany)
	{
		WorkItem = work;
		worth = bid;
		StartDate = SDateTime.Now();
		Longevity = 0;
	}

	public WorkDeal(SimulatedCompany.ProductPrototype product, WorkType type, Company company, SDateTime start, int longevity)
		: base(company)
	{
		Prototype = product;
		workType = type;
		worth = Deal.GetPlayerWorth(0.6f, 1f) * product.Type.DevTime(product.Features, product.Category, company, product.Techs, product.OSs, product.Framework, false, product.SequelTo) * 1000f;
		StartDate = start;
		Longevity = Mathf.Max(1, longevity);
	}

	public WorkDeal(SoftwareProduct product, WorkType type, SDateTime start, int longevity)
		: base(product.DevCompany)
	{
		Product = product;
		workType = type;
		if (type == WorkType.Support)
		{
			worth = product.DevTime * 500f * Deal.GetPlayerWorth(0.6f, 1f);
		}
		else
		{
			worth = (float)product.RealQuality * Utilities.GetMarketingEffort(product.Category.Retention) * Deal.GetPlayerWorth(MarketingPlan.PostMarketingPrice + 20000f, MarketingPlan.PostMarketingPrice * 2f) * 0.05f;
		}
		StartDate = start;
		Longevity = Mathf.Max(1, longevity);
	}

	public WorkDeal()
	{
	}

	public override void Accept(Company company)
	{
		base.Accept(company);
		if (base.Incoming)
		{
			WorkItem workItem = GenerateWork();
			if (workItem != null)
			{
				GameSettings.Instance.MyCompany.AddWorkItem(workItem);
				workItem.ActiveDeal = this;
				workItem.guiItem.UpdateActivation();
			}
			WorkItem = workItem;
		}
	}

	public WorkItem GenerateWork()
	{
		switch (workType)
		{
		case WorkType.Design:
		{
			SimulatedCompany.ProductPrototype prototype = Prototype;
			DesignDocument designDocument = new DesignDocument(prototype.Name, prototype.Type, prototype.Category, prototype.Needs, prototype.OSs, prototype.Price, prototype.SubscriptionBased, prototype.Submarkets, prototype.DevStart, base.Client, prototype.SequelTo, prototype.InHouse, prototype.Loss, prototype.Features, prototype.Techs, null, null, null, prototype.Framework, prototype.NewFramework, new List<SoftwareProduct>(), false);
			designDocument.KillLicenses();
			return designDocument;
		}
		case WorkType.Development:
		{
			SimulatedCompany.ProductPrototype prototype = Prototype;
			SoftwareWorkItem.FeatureProgress[] array = SoftwareWorkItem.GenerateProgress(prototype.Type, prototype.Category, prototype.DevCompany, prototype.Features, prototype.Techs, prototype.OSs, prototype.SequelTo, false, prototype.Framework);
			SoftwareWorkItem.FeatureProgress[] array2 = array;
			foreach (SoftwareWorkItem.FeatureProgress obj in array2)
			{
				obj.Progress = obj.DevTime;
			}
			SoftwareAlpha softwareAlpha = new SoftwareAlpha(prototype.Name, prototype.SWID, prototype.Type, prototype.Category, prototype.Needs, array, prototype.Techs, prototype.OSs, prototype.Price, prototype.SubscriptionBased, prototype.Submarkets, prototype.DevStart, 0f, base.Client, prototype.SequelTo, prototype.InHouse, prototype.Loss, null, null, null, -1, new SHashSet<uint>(), 0f, 1u, 0f, null, SoftwareWorkItem.GetMaximumBugs(prototype.DevTime * prototype.GetCodeArtRatio()), 1f, prototype.Framework, prototype.FrameworkRoyalty, prototype.NewFramework, null, new List<SoftwareProduct>(), prototype.CreativityScore, true, null);
			softwareAlpha.KillLicenses();
			return softwareAlpha;
		}
		case WorkType.Support:
		{
			SoftwareProduct product = Product;
			if (product.Bugss == 0)
			{
				int num = Mathf.FloorToInt(Utilities.RandomGaussClamped(0.7f, 0.1f) * product.DevTime * 20f);
				product.ChangeBugs(product.StartBugss + num, num);
			}
			return new SupportWork(product, -1);
		}
		case WorkType.Marketing:
		{
			SoftwareProduct product = Product;
			return new MarketingPlan(GetMarketingBudget(product), product);
		}
		default:
			return null;
		}
	}

	public override bool Cancel()
	{
		if (!base.Cancel())
		{
			return false;
		}
		if (base.Incoming)
		{
			WorkItem workItem = WorkItem;
			if (workItem != null)
			{
				SimulatedCompany.ProductPrototype prototype = Prototype;
				if (prototype != null)
				{
					float num = Mathf.Clamp01(SDateTime.GetMonths(prototype.DevStart, SDateTime.Now()) / prototype.DevTime);
					switch (workType)
					{
					case WorkType.Design:
					{
						DesignDocument obj = workItem as DesignDocument;
						double spProgress = obj.GetSpProgress(false, false);
						double spProgress2 = obj.GetSpProgress(false, true);
						prototype.SetQuality(LerpQ(spProgress, prototype.CodeProgress, num), LerpQ(spProgress2, prototype.ArtProgress, num), prototype.CodeQuality, prototype.ArtQuality);
						break;
					}
					case WorkType.Development:
					{
						double[] qualities = (workItem as SoftwareAlpha).GetQualities();
						prototype.SetQuality(LerpQ(qualities[0], prototype.CodeProgress, num), LerpQ(qualities[0], prototype.ArtProgress, num), LerpQ(qualities[0], prototype.CodeQuality, num), LerpQ(qualities[0], prototype.ArtQuality, num));
						break;
					}
					}
				}
				workItem.Kill(true);
			}
		}
		return true;
	}

	private static double LerpQ(double value, double quality, double monthsCompleted)
	{
		return Utilities.Lerp(Math.Max(value, quality), value, monthsCompleted, true);
	}

	public override void RecalculateWorth()
	{
		switch (workType)
		{
		case WorkType.Design:
		case WorkType.Development:
			worth = Deal.GetPlayerWorth(0.6f, 1f) * Prototype.Type.DevTime(Prototype.Features, Prototype.Category, Prototype.DevCompany, Prototype.Techs, Prototype.OSs, Prototype.Framework, false, Prototype.SequelTo) * 1000f;
			break;
		case WorkType.Support:
			worth = Product.DevTime * 500f * Deal.GetPlayerWorth(0.6f, 1f);
			break;
		case WorkType.Marketing:
			worth = (float)(Product.RealQuality * (double)Utilities.GetMarketingEffort(Product.Category.Retention) * (double)Deal.GetPlayerWorth(MarketingPlan.PostMarketingPrice + 20000f, MarketingPlan.PostMarketingPrice * 2f) * 0.05000000074505806);
			break;
		}
	}

	public override float Worth()
	{
		return worth / (float)GameSettings.DaysPerMonth;
	}

	private string GetName()
	{
		if (base.Incoming)
		{
			if (Product == null)
			{
				if (Prototype != null)
				{
					return Prototype.Name;
				}
				return "";
			}
			return Product.Name;
		}
		if (WorkItem != null)
		{
			return WorkItem.Name;
		}
		return "";
	}

	public string GetEndDate()
	{
		if (!base.Incoming)
		{
			return "NotApplicableAbbr".Loc();
		}
		return (StartDate + new SDateTime(Longevity, 0)).ToCompactString();
	}

	public string GetStatus()
	{
		return SDateTime.Countdown(SDateTime.Now(), StartDate + new SDateTime(Longevity, 0));
	}

	private WorkType GetWorkType()
	{
		WorkItem workItem = WorkItem;
		if (workItem != null)
		{
			if (workItem is DesignDocument)
			{
				return WorkType.Design;
			}
			if (workItem is SoftwareAlpha)
			{
				return WorkType.Development;
			}
			if (workItem is MarketingPlan)
			{
				return WorkType.Marketing;
			}
			if (workItem is SupportWork)
			{
				return WorkType.Support;
			}
		}
		return workType;
	}

	public override string Description()
	{
		return string.Format("WorkDeal".Loc(), GetName(), GetWorkType().ToString().Loc());
	}

	public override string Title()
	{
		return workType.ToString();
	}

	public override float Payout()
	{
		return Worth();
	}

	public override void HandleUpdate()
	{
		bool incoming = base.Incoming;
	}

	private FormatColorString GetSoftwareType()
	{
		if (base.Incoming)
		{
			if (Product != null)
			{
				return Product.Type.Name.LocSW();
			}
			if (Prototype != null)
			{
				if (Prototype == null)
				{
					return "";
				}
				return Prototype.Type.Name.LocSW();
			}
		}
		return "";
	}

	private FeatureBase[] GetFeatures()
	{
		if (base.Incoming)
		{
			if (Product != null)
			{
				return Product.Features;
			}
			if (Prototype != null)
			{
				if (Prototype != null)
				{
					return Prototype.Features;
				}
				return null;
			}
		}
		return null;
	}

	public override void GetDetailedDescription(List<string> vars, List<string> values)
	{
		if (workType == WorkType.Marketing)
		{
			vars.AddRange("Type".Loc(), "Software".Loc(), (GameSettings.DaysPerMonth == 1) ? "PerMonth".Loc() : "Perday".Loc(), "Budget".Loc() + " " + ((GameSettings.DaysPerMonth == 1) ? "PerMonth".Loc() : "Perday".Loc()).ToLower(), "Expires".Loc());
			values.AddRange(GetWorkType().ToString().Loc(), GetSoftwareType(), Worth().Currency(), GetMarketingBudget(Product).Currency(), GetEndDate());
			return;
		}
		if (workType == WorkType.Support)
		{
			vars.AddRange("Type".Loc(), "Software".Loc(), (GameSettings.DaysPerMonth == 1) ? "PerMonth".Loc() : "Perday".Loc(), "Expires".Loc());
			values.AddRange(GetWorkType().ToString().Loc(), GetSoftwareType(), Worth().Currency(), GetEndDate());
			return;
		}
		vars.AddRange("Type".Loc(), "Software".Loc(), (GameSettings.DaysPerMonth == 1) ? "PerMonth".Loc() : "Perday".Loc(), "Expires".Loc());
		values.AddRange(GetWorkType().ToString().Loc(), GetSoftwareType(), Worth().Currency(), GetEndDate());
		if (GetFeatures() == null)
		{
			return;
		}
		Dictionary<Employee.EmployeeRole, Dictionary<string, int>> specs = SoftwareType.GetSpecs(GetFeatures(), workType == WorkType.Design);
		if (specs.Count <= 0)
		{
			return;
		}
		vars.Add("Requirements".Loc().FontBold());
		values.Add("");
		foreach (KeyValuePair<Employee.EmployeeRole, Dictionary<string, int>> item in specs)
		{
			vars.Add(item.Key.ToString().Loc());
			values.Add("");
			foreach (KeyValuePair<string, int> item2 in item.Value)
			{
				vars.Add("");
				values.Add((item2.Value == 0) ? string.Format("{0} ({1})", item2.Key.LocTry(), "AnyLevel".Loc()) : "SpecSkill".Loc(item2.Value, item2.Key.LocTry()));
			}
		}
	}

	public static float GetMarketingBudget(IMarketable p)
	{
		return ((p == null) ? MarketingPlan.PostMarketingPrice : (Utilities.GetMarketingEffort(p.SWCat.Retention) * p.GetRealQuality() * 0.05f * MarketingPlan.PostMarketingPrice)) / (float)GameSettings.DaysPerMonth;
	}

	public override bool StillValid(bool active)
	{
		if (!base.StillValid(active))
		{
			return false;
		}
		if (base.Incoming)
		{
			if (Prototype != null && Prototype.Released)
			{
				return false;
			}
			if (workType == WorkType.Support && SDateTime.GetMonths(Product.Release, SDateTime.Now()) > 4f && Product.Userbase == 0)
			{
				return false;
			}
			if (Product != null && Product.DevCompany != base.Client)
			{
				return false;
			}
			return SDateTime.GetMonths(StartDate, SDateTime.Now()) <= (float)Longevity;
		}
		return true;
	}

	public override float ReputationEffect(bool ending)
	{
		if (base.Incoming)
		{
			switch (workType)
			{
			case WorkType.Design:
				if (ending)
				{
					DesignDocument designDocument;
					if ((designDocument = WorkItem as DesignDocument) == null)
					{
						return 0f;
					}
					double num4 = designDocument.RawProgress();
					return (float)(((num4 < 1.0) ? (num4 - 0.5) : (num4 / 4.0)) * (double)(designDocument.DevTime / 128f)).Clamp(-0.5, 0.25);
				}
				break;
			case WorkType.Development:
				if (ending)
				{
					SoftwareAlpha softwareAlpha;
					if ((softwareAlpha = WorkItem as SoftwareAlpha) == null)
					{
						return 0f;
					}
					return (float)((softwareAlpha.GetLimitedQuality() * 2.0 - 1.0) * 2.0 * (double)(softwareAlpha.DevTime / 48f));
				}
				break;
			case WorkType.Support:
			{
				if (ending)
				{
					break;
				}
				SupportWork supportWork;
				if ((supportWork = WorkItem as SupportWork) == null)
				{
					return 0f;
				}
				int ticketDeal = supportWork.TicketDeal;
				supportWork.TicketDeal = 0;
				if (SDateTime.GetHours(Accepted, SDateTime.Now()) < 16f)
				{
					return 0f;
				}
				if (supportWork.Generated > 0)
				{
					int num5 = Mathf.RoundToInt((float)supportWork.Generated * 0.1f);
					if (ticketDeal > 0)
					{
						supportWork.Generated -= ticketDeal;
					}
					if (ticketDeal > num5)
					{
						return ((float)(ticketDeal - num5) / (float)num5).MapRange(0f, 10f, 0.005f, 0.03f, true);
					}
					return Mathf.Lerp(-0.1f, 0f, (float)ticketDeal / (float)num5);
				}
				return 0f;
			}
			case WorkType.Marketing:
			{
				if (ending)
				{
					break;
				}
				MarketingPlan marketingPlan;
				if ((marketingPlan = WorkItem as MarketingPlan) == null)
				{
					return 0f;
				}
				if (SDateTime.GetHours(Accepted, SDateTime.Now()) < 16f)
				{
					return 0f;
				}
				float marketingBudget = GetMarketingBudget(Product);
				float num = marketingBudget / MarketingPlan.PostMarketingPrice;
				float num2 = marketingPlan.LastProgress - num + 0.1f;
				float num3 = (marketingPlan.LastSpent - marketingBudget) / marketingBudget;
				if (!(num3 < -0.01f))
				{
					if (!(num2 > 0f))
					{
						return 0f;
					}
					return Mathf.Min(num2 * 0.03f, 0.03f);
				}
				return (0f - Mathf.Sqrt(Mathf.Max(0.1f, 0f - num3))) * 0.1f;
			}
			}
		}
		return 0f;
	}

	public override string ReputationCategory()
	{
		return "Deal";
	}

	public override void MadePayment(float amount)
	{
		base.MadePayment(amount);
		switch (workType)
		{
		case WorkType.Design:
		case WorkType.Development:
			Prototype.AddLoss(amount, SoftwareProduct.LossType.Development, true);
			break;
		case WorkType.Support:
			Product.AddLoss(amount, SoftwareProduct.LossType.Support, true);
			break;
		case WorkType.Marketing:
			Product.AddLoss(amount, SoftwareProduct.LossType.Marketing, true);
			break;
		}
	}

	public override SDateTime? GetTime()
	{
		return StartDate + new SDateTime(Longevity, 0);
	}

	public override bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		switch (workType)
		{
		case WorkType.Design:
		case WorkType.Development:
			if (t == null || t == Prototype.Type)
			{
				if (c != null)
				{
					return c == Prototype.Category;
				}
				return true;
			}
			return false;
		case WorkType.Support:
		case WorkType.Marketing:
			if (t == null || t == Product.Type)
			{
				if (c != null)
				{
					return c == Product.Category;
				}
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public override byte GetTypeID()
	{
		return 3;
	}

	public override void WriteTypeData(Stream st)
	{
		if (Product != null)
		{
			st.WriteBool(false);
			st.WriteUInt(Product.ID);
		}
		else
		{
			st.WriteBool(true);
			st.WriteUInt(Prototype.ForceID());
		}
		st.WriteEnum(workType, true);
		st.WriteFloat(worth);
		StartDate.WriteData(st);
		st.WriteInt(Longevity);
	}

	public override IReferenceFix FixReferences()
	{
		if (base.FixReferences() == null)
		{
			return null;
		}
		if (Product != null)
		{
			Product = MarketSimulation.Active.GetProduct(Product.ID, false, false, true);
			if (Product == null)
			{
				return null;
			}
		}
		if (Prototype != null)
		{
			if (base.Client == null)
			{
				HUD.Instance.dealWindow.CancelDeal(this, false, false);
				return null;
			}
			Prototype = Prototype.FixReferences() as SimulatedCompany.ProductPrototype;
			if (Prototype == null)
			{
				return null;
			}
		}
		return this;
	}

	public string GetWorkClassType()
	{
		switch (workType)
		{
		case WorkType.Design:
			return "DesignDocument";
		case WorkType.Development:
			return "SoftwareAlpha";
		case WorkType.Support:
			return "SupportWork";
		case WorkType.Marketing:
			return "MarketingPlan";
		default:
			return null;
		}
	}
}
