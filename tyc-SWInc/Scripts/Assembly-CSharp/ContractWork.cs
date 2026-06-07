using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ContractWork : IStockable, ILossable, IReferenceFix, ICalenderItem
{
	public readonly string Company;

	public readonly int Months;

	public readonly int Initial;

	public readonly int Done;

	public readonly int Penalty;

	public SoftwareType SoftwareType;

	public SoftwareCategory SoftwareCat;

	public FeatureBase[] Features;

	public readonly float Quality;

	public readonly float PerBug;

	public readonly float Art;

	public readonly float Difficulty;

	public readonly float PerPrintFactor;

	public readonly float MinProg;

	public readonly SDateTime Added;

	public SDateTime Deadline;

	public readonly uint Goal;

	public readonly bool Hardware;

	private readonly float _hardwarePrice;

	private readonly int _hardwareMask;

	private readonly int _hardwareInputMask;

	private uint _copies;

	public uint LastPrinted;

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
			return true;
		}
	}

	public uint PhysicalCopies
	{
		get
		{
			lock (this)
			{
				return _copies;
			}
		}
		set
		{
			lock (this)
			{
				_copies = value;
			}
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
			return this;
		}
	}

	public SoftwareType SWType
	{
		get
		{
			return SoftwareType;
		}
	}

	public SoftwareCategory SWCat
	{
		get
		{
			return SoftwareCat;
		}
	}

	public IManufacturable Manufacturing
	{
		get
		{
			return SoftwareCat;
		}
	}

	public IList<FeatureBase> FeaturesBases
	{
		get
		{
			return Features;
		}
	}

	public void SetDeadline()
	{
		Deadline = (SDateTime.Now() + Months).Simplify();
	}

	private ContractWork(string companyName, int months, int initial, int done, int penalty, SoftwareType s, SoftwareCategory c, float quality, float perBug, SDateTime added, FeatureBase[] features, float art, float minProg, float diff)
	{
		Company = companyName;
		Months = months;
		Initial = initial;
		Done = done;
		Penalty = penalty;
		SoftwareType = s;
		SoftwareCat = c;
		Quality = quality;
		PerBug = perBug;
		Added = added;
		Features = features;
		Art = art;
		Difficulty = diff;
		MinProg = minProg;
	}

	private ContractWork(string companyName, int months, SoftwareType s, SoftwareCategory c, float perPrint, SDateTime added, FeatureBase[] features, uint goal, float diff)
	{
		Company = companyName;
		Months = months;
		SoftwareType = s;
		SoftwareCat = c;
		Added = added;
		Features = features;
		Goal = goal;
		Hardware = true;
		c.Manufacturing.GetProcessInfo(Features, null, out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
		PerPrintFactor = perPrint;
		Difficulty = diff;
	}

	public ContractWork()
	{
	}

	public float GetDevTime()
	{
		return SoftwareType.DevTime(Features, null, GameSettings.Instance.MyCompany, null, null, null, false, null);
	}

	public float GetIncome()
	{
		if (Hardware)
		{
			return PerPrintFactor * (float)Goal;
		}
		return Initial + Done;
	}

	public static ContractWork GenerateWork(SoftwareCategory cat, float difficulty, float rep, bool hardware)
	{
		string companyName = MarketSimulation.Active.RNG["ContractCompany"].GenerateName(Utilities.RNG);
		FeatureBase[] feat = GenerateFeatures(cat, difficulty);
		SoftwareType parent = cat.Parent;
		if (hardware)
		{
			int num = Mathf.Max(1, Mathf.CeilToInt(difficulty * 6f));
			int a = cat.Manufacturing.Components.Where((HardwareComponent x) => x.Valid(feat, null)).Max((HardwareComponent x) => x.Time);
			a = Mathf.Max(a, cat.Manufacturing.FinalTime);
			uint goal = (uint)(60f / (float)a * 24f * 1000f * (float)num * Mathf.Max(0.2f, difficulty * 6f)) / 1000 * 1000;
			float num2 = difficulty.MapRange(0f, 1f, 0.25f, 0.5f);
			num2 += 2000f / (float)((long)AI.MaxBoxesDPM * 1000L);
			return new ContractWork(companyName, num, parent, cat, num2, SDateTime.Now(), feat, goal, difficulty);
		}
		float f = parent.DevTime(feat, cat, GameSettings.Instance.MyCompany, null, null, null, false, null);
		float quality = Mathf.Min(0.95f, Utilities.RandomGaussClamped(rep, 0.1f));
		float num3 = Utilities.RandomGaussClamped(rep, 0.05f).WeightOne(0.9f);
		float perBug = Utilities.RandomGaussClamped() * 100f;
		int devTime = Mathf.RoundToInt(f);
		int optimalEmployees = GameData.GetOptimalEmployees(devTime);
		float num4 = Mathf.Max(1f, GameData.ProjectDevTimeGeneric(GameData.GetOptimalEmployees(devTime), devTime) * num3);
		float num5 = 1f - SoftwareType.CodeArtRatio(feat);
		int months = Mathf.FloorToInt(num4 * 1.5f);
		float num6 = (float)optimalEmployees * Mathf.Max(1f, (float)optimalEmployees / 2f) * num3.WeightOne(0.25f) * num4;
		num6 = num5 * num6 * 0.7f + (1f - num5) * num6;
		float contractIncomeFactor = DifficultyValues.Difficulty.ContractIncomeFactor;
		int initial = Mathf.RoundToInt(num6 * 2500f * RandomGaussAround() * contractIncomeFactor);
		int done = Mathf.RoundToInt(num6 * 7500f * RandomGaussAround() * contractIncomeFactor);
		int penalty = Mathf.RoundToInt(num6 * 5000f * RandomGaussAround());
		return new ContractWork(companyName, months, initial, done, penalty, parent, cat, quality, perBug, SDateTime.Now(), feat, num5, num3, difficulty);
	}

	private static float RandomGaussAround(float factor = 0.1f)
	{
		return 1f + (Utilities.RandomGaussClamped() - 0.5f) * factor;
	}

	public static FeatureBase[] GenerateFeatures(SoftwareCategory cat, float difficulty)
	{
		HashSet<string> hashSet = new HashSet<string>();
		List<FeatureBase> list = new List<FeatureBase>();
		int year = SDateTime.Now().Year;
		float a = 1f / 6f;
		float num = difficulty.MapRange(a, 1f, 1f, 24f, true);
		SoftwareType parent = cat.Parent;
		foreach (SpecFeature item in from x in parent.Features.Values.OfType<SpecFeature>()
			orderby (!x.IsForced(cat.Name)) ? 1 : 0
			select x)
		{
			if (item.IsUnlocked(year) && item.IsCompatible(cat.Name))
			{
				num -= item.DevTime;
				list.Add(item);
				hashSet.Add(item.Spec);
				if (num <= 0f)
				{
					break;
				}
			}
		}
		List<SubFeature> list2 = (from x in parent.Features.Values.OfType<SubFeature>()
			orderby x.Level, x.DevTime, Utilities.RandomValue
			select x).ToList();
		if (difficulty >= 0.95f)
		{
			num = UnityEngine.Random.Range(24f, parent.Features.Values.SumSafe((FeatureBase x) => x.DevTime)) - list.SumSafe((FeatureBase x) => x.DevTime);
		}
		if (num > 0f)
		{
			for (int num2 = 0; num2 < list2.Count; num2++)
			{
				SubFeature subFeature = list2[num2];
				if (hashSet.Contains(subFeature.Spec) && subFeature.IsUnlocked(year) && subFeature.IsCompatible(cat.Name))
				{
					list.Add(subFeature);
					num -= subFeature.DevTime;
					if (num <= 0f)
					{
						break;
					}
				}
			}
		}
		return list.ToArray();
	}

	public DesignDocument GenerateWorkItem(string SCM)
	{
		return DesignDocument.CreateWork(Company, SoftwareType, SoftwareType.Categories.Values.First(), new Dictionary<string, SoftwareProduct>(), null, 0f, false, new double[3], SDateTime.Now(), GameSettings.Instance.MyCompany, null, false, 0.0, Features, null, this, null, SCM, null, null, new List<SoftwareProduct>(), false);
	}

	public string GetStatus(SDateTime start)
	{
		return SDateTime.Countdown(SDateTime.Now(), start + new SDateTime(Months, 0));
	}

	public override string ToString()
	{
		return Company;
	}

	public IReferenceFix FixReferences()
	{
		SoftwareType = MarketSimulation.Active.SoftwareTypes[SoftwareType.Name];
		SoftwareCat = SoftwareType.Categories[SoftwareCat.Name];
		Features = Features.SelectInPlace((FeatureBase x) => SoftwareType.Features[x.Name]);
		return this;
	}

	public void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
	}

	public void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
	}

	public float GetLicenseAmount()
	{
		return 0f;
	}

	public string GetName()
	{
		return SWCat.GetPrettyName();
	}

	public string GetIdentifyingName()
	{
		return Company;
	}

	public string GetCompanyName()
	{
		return Company;
	}

	public float GetPrintPrice(bool isAI = false)
	{
		if (!Manufacturing.IsHardware())
		{
			return 0f;
		}
		return _hardwarePrice;
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
		return 0.5f;
	}

	public uint GetFollowers()
	{
		return 0u;
	}

	public string GetTitle()
	{
		return GetCompanyName();
	}

	public string GetDescription()
	{
		return GetName() + " (" + "Manufacturing".Loc() + ")";
	}

	public SDateTime? GetTime()
	{
		return Deadline;
	}

	public ComingReleaseWindow.EventType GetEventType()
	{
		return ComingReleaseWindow.EventType.ContractDeadline;
	}

	public bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		if (t != null)
		{
			return t == SoftwareType;
		}
		return true;
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

	public IProductOrder PromoteHardware(uint copies)
	{
		return ManufactureOrder.PromoteProduct(this, copies);
	}
}
