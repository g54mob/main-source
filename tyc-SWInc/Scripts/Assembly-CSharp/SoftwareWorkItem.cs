using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[AltDeprecate("Working", typeof(Dictionary<uint, FeatureProgress>))]
[AltDeprecate("AddonFactors", typeof(uint[]))]
public abstract class SoftwareWorkItem : WorkItem, ICalenderItem, IRoyaltyItem
{
	[Serializable]
	public class FeatureProgress
	{
		public FeatureBase Feature;

		[AltWasFloat(1)]
		public double DevTime;

		[AltWasFloat(1)]
		public double CDevTime;

		[AltWasFloat(1)]
		public double ADevTime;

		[AltWasFloat(0)]
		public double Progress;

		[AltWasFloat(0)]
		public double ArtProgress;

		[AltWasFloat(0)]
		public double Qual;

		[AltWasFloat(0)]
		public double Qual2;

		[AltWasFloat(0)]
		public double CodeTargetQual;

		[AltWasFloat(0)]
		public double ArtTargetQual;

		public bool OS;

		public bool CodeDone;

		public bool ArtDone;

		public float LastIterationProg;

		public int Assigned;

		public uint Factor = 1u;

		private static FloatInterpolator _speedDamper = new FloatInterpolator((float x) => -1.35f * (x * x) + 1.45f, 100);

		public static float[] Means = new float[5] { 0f, 0.5f, 0.75f, 1f, 1f };

		public static float[] Deviations = new float[5] { 0.1f, 0.2f, 0.1f, 0.1f, 0.01f };

		public FeatureProgress()
		{
		}

		public FeatureProgress(FeatureBase feature, SoftwareCategory cat, Company c, Dictionary<string, TechLevel> techs, SoftwareProduct sequelTo, bool createFramework, SoftwareFramework framework, uint factor, float scale = 1f)
		{
			Feature = feature;
			DevTime = feature.GetDevTime(cat, c, techs, sequelTo, framework, createFramework) * (float)factor * scale;
			Factor = factor;
			InitDevTime();
		}

		public FeatureProgress(FeatureBase feature, uint factor, float devtime = -1f, bool art = true, bool code = true, float scale = 1f)
		{
			Feature = feature;
			DevTime = devtime * (float)factor * scale;
			Factor = factor;
			InitDevTime(art, code);
		}

		public FeatureProgress(SoftwareType t, int osCount)
		{
			Feature = new FeatureBase("Operating system support", t.Name);
			Feature.ID = 0u;
			DevTime = osCount;
			OS = true;
			InitDevTime();
		}

		private void InitDevTime(bool art = true, bool code = true)
		{
			double num = DevTime * (double)Feature.CodeArtRatio;
			CDevTime = (code ? num : 0.0);
			ADevTime = (art ? (DevTime - num) : 0.0);
			DevTime = CDevTime + ADevTime;
		}

		public double GetOverallProgress()
		{
			return (Progress + ArtProgress) / DevTime;
		}

		public int ValidForReviewers(HashSet<KeyValuePair<string, string>> specs)
		{
			if (OS)
			{
				return 0;
			}
			int num = 0;
			if (Feature.CodeArtRatio < 1f && (specs == null || specs.Contains(new KeyValuePair<string, string>("Art", Feature.Spec))))
			{
				num++;
			}
			if (Feature.CodeArtRatio > 0f && (specs == null || specs.Contains(new KeyValuePair<string, string>("Code", Feature.Spec))))
			{
				num++;
			}
			return num;
		}

		public float ValidReviewDevTime(HashSet<KeyValuePair<string, string>> specs)
		{
			if (OS)
			{
				return 0f;
			}
			double num = 0.0;
			if (Feature.CodeArtRatio < 1f && (specs == null || specs.Contains(new KeyValuePair<string, string>("Art", Feature.Spec))))
			{
				num += ADevTime;
			}
			if (Feature.CodeArtRatio > 0f && (specs == null || specs.Contains(new KeyValuePair<string, string>("Code", Feature.Spec))))
			{
				num += CDevTime;
			}
			return (float)num;
		}

		private static double GetSpeedDamp(double prog)
		{
			return _speedDamper.Evaluate((float)prog);
		}

		public bool Valid(bool code)
		{
			if (code)
			{
				return CDevTime > 0.0;
			}
			return ADevTime > 0.0;
		}

		public void UpdateStatus(bool design, float max = 1f)
		{
			if (!CodeDone)
			{
				double num = (double)max * (design ? DevTime : CDevTime);
				if (Progress >= num)
				{
					CodeDone = true;
				}
			}
			if (!ArtDone)
			{
				double num2 = (double)max * ADevTime;
				if (ArtProgress >= num2)
				{
					ArtDone = true;
				}
			}
		}

		public double AddProgress(double amount, Employee.EmployeeRole role, bool boost, out bool change, out double actuallyAdded, double maxx = 1.0, bool speedDamp = true)
		{
			change = false;
			double num = amount * (double)(1f + (boost ? 0.15f : 0f));
			actuallyAdded = 0.0;
			switch (role)
			{
			case Employee.EmployeeRole.Designer:
			{
				if (CodeDone)
				{
					return 0.0;
				}
				double num4 = maxx * DevTime;
				if (Progress < num4)
				{
					actuallyAdded = num * (speedDamp ? GetSpeedDamp(Progress / (DevTime * 4.0)) : 1.0);
					Progress += actuallyAdded;
					if (Progress >= num4)
					{
						CodeDone = true;
						change = true;
						double num5 = Progress - num4;
						Progress = num4;
						return amount - num5;
					}
					return amount;
				}
				change = true;
				CodeDone = true;
				break;
			}
			case Employee.EmployeeRole.Programmer:
			{
				if (CodeDone)
				{
					return 0.0;
				}
				double num6 = maxx * CDevTime;
				if (CDevTime > 0.0 && Progress < num6)
				{
					actuallyAdded = num * (speedDamp ? GetSpeedDamp(Progress / CDevTime - (maxx - 1.0)) : 1.0);
					Progress += actuallyAdded;
					if (Progress >= num6)
					{
						CodeDone = true;
						change = true;
						double num7 = Progress - num6;
						Progress = num6;
						return amount - num7;
					}
					return amount;
				}
				change = true;
				CodeDone = true;
				break;
			}
			case Employee.EmployeeRole.Artist:
			{
				if (ArtDone)
				{
					return 0.0;
				}
				double num2 = maxx * ADevTime;
				if (ADevTime > 0.0 && ArtProgress < num2)
				{
					actuallyAdded = num * (speedDamp ? GetSpeedDamp(ArtProgress / ADevTime - (maxx - 1.0)) : 1.0);
					ArtProgress += actuallyAdded;
					if (ArtProgress >= num2)
					{
						ArtDone = true;
						change = true;
						double num3 = ArtProgress - num2;
						ArtProgress = num2;
						return amount - num3;
					}
					return amount;
				}
				change = true;
				ArtDone = true;
				break;
			}
			}
			return 0.0;
		}

		public void AddQuality(double qual, double weight, bool art)
		{
			if (art)
			{
				if (ADevTime > 0.0)
				{
					Qual2 = (Qual2 + weight * 1.5 * qual * ArtTargetQual / ADevTime).Clamp(0.0, ArtTargetQual);
				}
			}
			else if (CDevTime > 0.0)
			{
				Qual = (Qual + weight * 1.5 * qual * CodeTargetQual / CDevTime).Clamp(0.0, CodeTargetQual);
			}
		}

		public void Reset()
		{
			double num = Progress / DevTime;
			CodeTargetQual = (ArtTargetQual = Utilities.RandomGaussClamped(Means.FuzzyIndex((float)num), Deviations.FuzzyIndex((float)num)));
			Progress = 0.0;
			ArtProgress = 0.0;
			ResetDoneness();
		}

		public void ResetDoneness()
		{
			ArtDone = ADevTime == 0.0;
			CodeDone = CDevTime == 0.0;
		}

		public double GetFinalQuality()
		{
			return SoftwareAlpha.FinalQualityCalc((CDevTime > 0.0) ? (Progress / CDevTime) : 1.0, (ADevTime > 0.0) ? (ArtProgress / ADevTime) : 1.0, Qual, Qual2, (float)(CDevTime / DevTime));
		}

		public double[] GetSubAdd(SoftwareCategory parent, TechLevel tech, double[] sub = null, bool add = false)
		{
			return Feature.GetSubAdd(parent, tech, GetFinalQuality(), sub, add);
		}

		public override string ToString()
		{
			return Feature.Name;
		}

		public bool RelevantFor(Employee.EmployeeRole role)
		{
			switch (role)
			{
			case Employee.EmployeeRole.Designer:
				if (DevTime > 0.0)
				{
					return !CodeDone;
				}
				return false;
			case Employee.EmployeeRole.Artist:
				if (ADevTime > 0.0)
				{
					return !ArtDone;
				}
				return false;
			case Employee.EmployeeRole.Programmer:
				if (CDevTime > 0.0)
				{
					return !CodeDone;
				}
				return false;
			default:
				return false;
			}
		}
	}

	public const float LevelThreeSpeedBoost = 0.15f;

	public string SoftwareName;

	public string CreateFramework;

	public SoftwareType Type;

	public SoftwareCategory SWCategory;

	public SoftwareFramework Framework;

	public float FrameworkRoyalty;

	public Dictionary<string, SoftwareProduct> Needs;

	public SoftwareProduct[] OSs;

	public SDateTime DevStart;

	public PublisherDeal Publishing;

	public int MaxBugs;

	public readonly float DevTime;

	public Company MyCompany;

	public SoftwareProduct SequelTo;

	public readonly bool InHouse;

	public readonly bool SubscriptionBased;

	public HashSet<uint> LastWorked = new HashSet<uint>();

	public Dictionary<Employee, float> LeadWork;

	protected List<KeyValuePair<Company, float>> _workRoyalties = new List<KeyValuePair<Company, float>>();

	private int? _networkLastWorked;

	public Dictionary<string, TechLevel> TechLevels;

	public FeatureProgress[] Features;

	[AltWasFloat(0)]
	public double[] Submarkets;

	public byte[] HardwareDesign;

	public readonly string Server;

	public string Server2;

	public float Price;

	public float PressReleaseEffect = 1f;

	public float PressBuildEffect = 1f;

	private float _followers;

	public uint MaxFollowers;

	public float FollowerChange;

	public SDateTime? ReleaseDate;

	public float CodeArtRatio;

	public float WorkDevTime = -1f;

	[AltWasFloat(0)]
	public double CreativityScore = 0.5;

	protected bool _anyMarketing;

	public uint AddonIDOffset = 1u;

	private bool _hypeWarned;

	public SoftwareAddOn AddonType;

	public SoftwareProduct AddonParent;

	public SoftwareWorkItem AddonWorkParent;

	public List<SoftwareWorkItem> AddonWorkChildren = new List<SoftwareWorkItem>();

	public uint? SWID;

	public TwoWayDictionary<Employee, FeatureProgress> NewWorking = new TwoWayDictionary<Employee, FeatureProgress>();

	public bool AddOn
	{
		get
		{
			return AddonType != null;
		}
	}

	public bool WorkAddOn
	{
		get
		{
			return AddonWorkParent != null;
		}
	}

	public bool DistributionPlatform
	{
		get
		{
			return Type == MarketSimulation.Active.DigitalDistSoft;
		}
	}

	public uint? AddonParentSWID
	{
		get
		{
			if (AddOn)
			{
				if (AddonParent == null)
				{
					return AddonWorkParent.SWID;
				}
				return AddonParent.ID;
			}
			return null;
		}
	}

	public float Followers
	{
		get
		{
			return _followers;
		}
		set
		{
			if (_followers > (float)MaxFollowers)
			{
				if (value <= _followers)
				{
					_followers = value;
				}
				else
				{
					float num = (value - (float)MaxFollowers) / ((float)MaxFollowers * 0.01f);
					_followers += (value - _followers) / num;
				}
			}
			else if (value > (float)MaxFollowers)
			{
				_followers = MaxFollowers;
				float num2 = (value - (float)MaxFollowers) / ((float)MaxFollowers * 0.01f);
				_followers += (value - _followers) / num2;
			}
			else
			{
				_followers = value;
			}
			if (_followers < 0f)
			{
				_followers = 0f;
			}
			if (AddonWorkParent != null && _followers > AddonWorkParent.Followers)
			{
				_followers = AddonWorkParent.Followers;
			}
		}
	}

	public float PremarketingBoost
	{
		get
		{
			return Mathf.Clamp01(Followers / (float)MaxFollowers);
		}
	}

	public override bool AlwaysUseLocalCategory
	{
		get
		{
			return true;
		}
	}

	public bool HasWorkRoyalties
	{
		get
		{
			return _workRoyalties.Count > 0;
		}
	}

	public static int GetOptimalIterations(float devTime)
	{
		return Mathf.FloorToInt(Mathf.Sqrt(devTime));
	}

	public uint GetNextAddonID()
	{
		uint addonIDOffset = AddonIDOffset;
		AddonIDOffset++;
		return addonIDOffset;
	}

	public override IReferenceFix FixReferences()
	{
		string name = Type.Name;
		if (name.Equals("Distribution platform"))
		{
			Type = MarketSimulation.Active.DigitalDistSoft;
		}
		else if (!MarketSimulation.Active.SoftwareTypes.TryGetValue(name, out Type))
		{
			Debug.Log("Non existent type: " + name + " when fixing references for software work item");
			Kill();
			return null;
		}
		if (SWCategory != null)
		{
			name = SWCategory.Name;
			if (!Type.Categories.TryGetValue(name, out SWCategory))
			{
				Debug.Log("Non existent category: " + name + " when fixing references for software work item");
				Kill();
				return null;
			}
		}
		if (AddOn)
		{
			name = AddonType.Name;
			if (!Type.AddOns.TryGetValue(name, out AddonType))
			{
				Debug.Log("Non existent addon type: " + name + " when fixing references for software work item");
				Kill();
				return null;
			}
			if (AddonWorkParent == null)
			{
				string name2 = AddonParent.Name;
				AddonParent = (SoftwareProduct)AddonParent.FixReferences();
				if (AddonParent == null)
				{
					SelectorController.MissingDataHost.Add(name2);
					Kill();
					return null;
				}
			}
		}
		Framework = ((Framework == null) ? null : MarketSimulation.Active.GetFramework(Framework.ID));
		OSs = ((OSs == null) ? null : OSs.ToList().FixMyReferences(true).ToArray());
		PublisherDeal publishing = Publishing;
		Publishing = ((publishing != null) ? publishing.FixReferences() : null) as PublisherDeal;
		if (Publishing != null)
		{
			Publishing.Publisher.Publishing.Add(Publishing);
		}
		MyCompany = MarketSimulation.Active.GetCompany(MyCompany.ID);
		SoftwareProduct sequelTo = SequelTo;
		SequelTo = (SoftwareProduct)((sequelTo != null) ? sequelTo.FixReferences() : null);
		Dictionary<string, TechLevel> techLevels = TechLevels;
		TechLevels = ((techLevels != null) ? techLevels.FixValueReferences(true) : null);
		Features.Where((FeatureProgress x) => !x.OS).ForEachEnum(delegate(FeatureProgress x)
		{
			x.Feature = (AddOn ? AddonType.GetFeature(x.Feature.ID) : Type.GetFeature(x.Feature.ID));
		});
		Dictionary<string, SoftwareProduct> needs = Needs;
		Needs = ((needs != null) ? needs.FixValueReferences(true) : null);
		List<KeyValuePair<Company, float>> workRoyalties = _workRoyalties;
		_workRoyalties = ((workRoyalties != null) ? workRoyalties.SelectInPlaceList((KeyValuePair<Company, float> x) => new KeyValuePair<Company, float>(MarketSimulation.Active.GetCompany(x.Key.ID), x.Value)) : null);
		return base.FixReferences();
	}

	public uint ForceID()
	{
		if (SWID.HasValue)
		{
			return SWID.Value;
		}
		SoftwareAlpha softwareAlpha;
		if ((softwareAlpha = this as SoftwareAlpha) != null && softwareAlpha.Mock != null)
		{
			SWID = softwareAlpha.Mock.ID;
			return softwareAlpha.Mock.ID;
		}
		if (DistributionPlatform && GameSettings.Instance.MyCompany.Distribution != null)
		{
			SWID = GameSettings.Instance.MyCompany.Distribution.Software.ID;
		}
		if (!SWID.HasValue)
		{
			if (AddOn)
			{
				if (AddonParent != null)
				{
					SWID = AddonParent.GetNextAddonID();
				}
				else
				{
					AddonWorkParent.ForceID();
					SWID = AddonWorkParent.GetNextAddonID();
				}
			}
			else
			{
				SWID = GameSettings.Instance.simulation.GetID();
			}
		}
		return SWID.Value;
	}

	public void NetworkSchedule(bool unschedule)
	{
		DesignDocument designDocument;
		if (GameSettings.Instance.IsNetworkMode && GetNetworkDealState() != NetworkDealState.Receiver && !AddOn && !DistributionPlatform && base.ActiveDeal == null && contract == null && ((designDocument = this as DesignDocument) == null || designDocument.Parent == null))
		{
			if (unschedule)
			{
				MyCompany.UnscheduleRelease(ForceID());
			}
			else
			{
				MyCompany.ScheduleRelease(SoftwareName, ForceID(), SWCategory, SequelTo, ReleaseDate);
			}
		}
	}

	public void MarketingDone()
	{
		if (!_anyMarketing)
		{
			_anyMarketing = true;
			if (AddOn && !WorkAddOn && AddonParent.DevCompany == MyCompany)
			{
				double num = (double)(AddonParent.Userbase + AddonParent.Followers) * AddonParent.RealQuality * AddonParent.CreativityScore * 0.05;
				Followers += (float)num;
			}
		}
	}

	public SoftwareWorkItem(string name)
		: base(name, null, 0u, null)
	{
	}

	public SoftwareWorkItem()
	{
	}

	public virtual object PromoteAction()
	{
		return null;
	}

	public override string Category()
	{
		string text2;
		if (AddOn)
		{
			string text = (WorkAddOn ? AddonWorkParent.SoftwareName : AddonParent.Name);
			text2 = "AddonForProduct".Loc(AddonType.GetPrettyName(), text);
		}
		else
		{
			text2 = Type.Name.LocSWFull(SWCategory.Name);
		}
		if (ReleaseDate.HasValue)
		{
			return ReleaseDate.Value.ToVeryCompactString() + " - " + text2;
		}
		return text2;
	}

	public void RegisterLeadWork(Employee lead, float work)
	{
		if (LeadWork == null)
		{
			LeadWork = new Dictionary<Employee, float>();
		}
		LeadWork.AddUp(lead, work);
	}

	public void ReEvaluateMaxFollowers()
	{
		MaxFollowers = GetMaxFollowers(Type, SWCategory, MyCompany, AddonType, AddonParent, AddonWorkParent, OSs, GetRelevantPublisherDeal());
		Followers = Followers;
	}

	public static uint GetMaxFollowers(SoftwareType type, SoftwareCategory cat, Company c, SoftwareAddOn addonType, SoftwareProduct parent, SoftwareWorkItem workParent, IEnumerable<SoftwareProduct> OSs, PublisherDeal pub)
	{
		float number = ((pub == null) ? c.GetReputation(cat) : cat.RepCut(c, pub.Publisher));
		uint num2;
		if (addonType != null)
		{
			uint num = ((workParent == null) ? ((uint)parent.Userbase) : GameSettings.Instance.simulation.GetFollowerReach(workParent.Type, workParent.SWCategory, workParent.OSs));
			num2 = (uint)((float)(num * (addonType.PerUser - ((workParent != null) ? 1 : 0))) * number.WeightOne(0.9f));
		}
		else
		{
			num2 = (uint)((float)GameSettings.Instance.simulation.GetFollowerReach(type, cat, OSs) * number.WeightOne(0.9f));
		}
		if (num2 == 0)
		{
			num2 = 1u;
		}
		return num2;
	}

	public PublisherDeal GetRelevantPublisherDeal()
	{
		PublisherDeal result = Publishing;
		if (AddOn)
		{
			SoftwareWorkItem addonWorkParent = AddonWorkParent;
			result = ((addonWorkParent != null) ? addonWorkParent.Publishing : null);
		}
		return result;
	}

	public float GetRep()
	{
		PublisherDeal relevantPublisherDeal = GetRelevantPublisherDeal();
		if (relevantPublisherDeal == null)
		{
			return GetLocalCompanyOwner().GetReputation(SWCategory);
		}
		return SWCategory.RepCut(GetLocalCompanyOwner(), relevantPublisherDeal.Publisher);
	}

	public void RefreshWorkDevTime(bool forceFull = false)
	{
		WorkDevTime = 0f;
		for (int i = 0; i < Features.Length; i++)
		{
			FeatureProgress featureProgress = Features[i];
			if (!featureProgress.ArtDone || forceFull)
			{
				WorkDevTime += (float)featureProgress.ADevTime;
			}
			if (!featureProgress.CodeDone || forceFull)
			{
				WorkDevTime += (float)featureProgress.CDevTime;
			}
		}
	}

	public static float Lateness(SDateTime releaseDate)
	{
		return SDateTime.GetMonths(new SDateTime(0, 0, 0, releaseDate.Month + 1, releaseDate.Year), SDateTime.Now());
	}

	public bool AllZero(bool includeArt)
	{
		for (int i = 0; i < Features.Length; i++)
		{
			if (Features[i].Progress > 0.0)
			{
				return false;
			}
			if (includeArt && Features[i].ArtProgress > 0.0)
			{
				return false;
			}
		}
		return true;
	}

	public bool AllDone(bool design, bool art = true, bool code = true)
	{
		for (int i = 0; i < Features.Length; i++)
		{
			FeatureProgress featureProgress = Features[i];
			if (((design && featureProgress.DevTime > 0.0) || featureProgress.CDevTime > 0.0) && code && !featureProgress.CodeDone)
			{
				return false;
			}
			if (!design && featureProgress.ADevTime > 0.0 && art && !featureProgress.ArtDone)
			{
				return false;
			}
		}
		return true;
	}

	public bool AnyCode()
	{
		return CodeArtRatio > 0f;
	}

	public void SimulateFollowers(float delta)
	{
		if (deal != 0 || contract != null)
		{
			return;
		}
		PressBuildEffect = Mathf.Clamp01(PressBuildEffect + Utilities.PerDay(1f / DevTime, delta, false));
		PressReleaseEffect = Mathf.Clamp01(PressReleaseEffect + Utilities.PerDay(1f / DevTime, delta, false));
		bool hasValue = ReleaseDate.HasValue;
		if (hasValue)
		{
			float num = Lateness(ReleaseDate.Value);
			if (num > 0f)
			{
				if (Followers > 0f)
				{
					Followers -= Utilities.PerDay(Followers * (0.1f + num), delta, false);
					if (!WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.LateProductRelease))
					{
						NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.LateProductRelease, this));
					}
				}
				return;
			}
		}
		bool flag = PublisherDeal.HasDeal(this, "Marketing");
		SoftwareAlpha softwareAlpha = this as SoftwareAlpha;
		if (flag && softwareAlpha != null)
		{
			if (PressReleaseEffect > 0.5f && (softwareAlpha.InBeta || GetProgress() > 0.1f))
			{
				PublisherInstaMarket();
			}
			if (!GameSettings.Instance.PressBuildQueue.Contains(softwareAlpha) && PressBuildEffect > 0.5f && softwareAlpha.InBeta)
			{
				GameSettings.Instance.PressBuildQueue.Add(softwareAlpha);
			}
		}
		Followers += Utilities.PerHour(FollowerChange, delta, false) / (float)GameSettings.DaysPerMonth;
		FollowerChange = Mathf.Lerp(FollowerChange, flag ? 0f : ((0f - Followers) * (hasValue ? 0.005f : 0.01f)), Utilities.PerDay(1f, delta, false));
		if (!AutoDev && FollowerChange < -25f && !_hypeWarned)
		{
			_hypeWarned = true;
			NotificationManager.AddNotification(new WorkItemNotification(this, "HypeWarning".Loc(SoftwareName), "Chart", NotificationManager.NotificationType.Warning));
		}
	}

	public void PublisherInstaMarket()
	{
		if (!PublisherDeal.HasDeal(this, "Marketing"))
		{
			return;
		}
		MarketingPlan.FinishPressRelease(this, MarketingPlan.PressOption.All, Utilities.RepeatValue(1f, 3), false);
		float num = HUD.Instance.marketingWindow.PressOptionCost.Sum();
		if (AddonWorkParent != null)
		{
			Company publisher = AddonWorkParent.Publishing.Publisher;
			if (publisher != null)
			{
				publisher.MakeTransaction(0f - num, Company.TransactionCategory.Marketing, true);
			}
			AddonWorkParent.Publishing.AddInvestment(num);
		}
		else
		{
			Company publisher2 = Publishing.Publisher;
			if (publisher2 != null)
			{
				publisher2.MakeTransaction(0f - num, Company.TransactionCategory.Marketing, true);
			}
			Publishing.AddInvestment(num);
		}
		AddLoss(num);
	}

	public static FeatureProgress[] GenerateProgress(SoftwareCategory cat, Company c, IList<FeatureProgress> features, Dictionary<string, TechLevel> techs, SoftwareProduct sequelTo, ReviewWindow.ReviewData iterationData)
	{
		Dictionary<string, Dictionary<string, float>> data = iterationData.Data;
		Dictionary<FeatureProgress, ValueTuple<float, uint>> dictionary = features.Where((FeatureProgress x) => !x.OS).ToDictionary((FeatureProgress x) => x, [return: TupleElementNames(new string[] { null, "Factor" })] (FeatureProgress x) => new ValueTuple<float, uint>(x.Feature.GetDevTime(cat, c, techs, sequelTo, null, false), x.Factor));
		float num = dictionary.SumSafe(([TupleElementNames(new string[] { null, "Factor" })] KeyValuePair<FeatureProgress, ValueTuple<float, uint>> x) => x.Value.Item1);
		List<FeatureProgress> list = new List<FeatureProgress>();
		int num2 = 0;
		foreach (KeyValuePair<FeatureProgress, ValueTuple<float, uint>> item in dictionary)
		{
			bool flag = data["Art"].ContainsKey(item.Key.Feature.Spec) && item.Key.Feature.CodeArtRatio < 1f;
			bool flag2 = data["Code"].ContainsKey(item.Key.Feature.Spec) && item.Key.Feature.CodeArtRatio > 0f;
			if (flag2 || flag)
			{
				list.Add(new FeatureProgress(item.Key.Feature, item.Value.Item2, item.Value.Item1 / num, flag, flag2));
			}
			num2++;
		}
		return list.ToArray();
	}

	public static FeatureProgress[] GenerateProgress(SoftwareType type, SoftwareCategory cat, Company c, IList<FeatureBase> features, Dictionary<string, TechLevel> techs, IList<SoftwareProduct> os, SoftwareProduct sequelTo, bool createFramework, SoftwareFramework framework, Dictionary<string, TechLevel> update = null, uint[] factors = null, int frameworkUpdate = -1)
	{
		List<FeatureProgress> list;
		if (update != null)
		{
			float frScale = ((frameworkUpdate < 0) ? 1f : SoftwareFramework.GetUpdateSpeed(frameworkUpdate));
			Dictionary<string, float> scales = techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => (update[x.Key].Outdates - x.Value.Outdates).MapRange(1f, 5f, 0.1f, 0.5f, true));
			list = features.SelectInPlaceList((FeatureBase x) => new FeatureProgress(x, cat, c, techs, sequelTo, createFramework, framework, 1u, scales[x.Spec] * frScale));
		}
		else
		{
			list = new List<FeatureProgress>();
			for (int num = 0; num < features.Count; num++)
			{
				FeatureBase feature = features[num];
				list.Add(new FeatureProgress(feature, cat, c, techs, sequelTo, createFramework, framework, (factors == null) ? 1u : factors[num]));
			}
		}
		if (os != null && os.Count > 0)
		{
			list.Add(new FeatureProgress(type, os.Count));
		}
		return list.OrderByDescending((FeatureProgress x) => x.Feature.Level).ToArray();
	}

	public FeatureBase[] GetFeatures()
	{
		return (from x in Features
			where !x.OS
			select x.Feature).ToArray();
	}

	public AddOnFeature[] GetAddonFeatures()
	{
		return Features.Where((FeatureProgress x) => !x.OS).SelectNotNull((FeatureProgress x) => x.Feature as AddOnFeature).ToArray();
	}

	public uint[] GetFactors()
	{
		return (from x in Features
			where !x.OS
			where x.Feature is AddOnFeature
			select x.Factor).ToArray();
	}

	protected SoftwareWorkItem(string name, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] os, float price, bool subscription, double[] submarkets, SDateTime start, Company company, SoftwareProduct sequelTo, bool inHouse, double loss, IList<FeatureBase> feat, Dictionary<string, TechLevel> techs, ContractWork contract, string server, string server2, string createFramework, SoftwareFramework framework, uint workID, NetworkDeal networkDeal)
		: base(name, contract, workID, networkDeal)
	{
		if (category == null)
		{
			throw new Exception("Tried to create software work item with no software category defined");
		}
		SoftwareName = name;
		Type = type;
		SWCategory = category;
		Framework = framework;
		FrameworkRoyalty = framework.Royalty();
		CreateFramework = createFramework;
		Submarkets = submarkets;
		Needs = needs;
		OSs = os;
		Price = price;
		SubscriptionBased = subscription;
		DevStart = start;
		TechLevels = techs;
		Features = GenerateProgress(Type, SWCategory, company, feat, TechLevels, OSs, sequelTo, CreateFramework != null, Framework);
		DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
		Server = server;
		Server2 = server2;
		double num = Features.Sum((FeatureProgress x) => x.CDevTime);
		CodeArtRatio = (float)(num / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		MaxBugs = GetMaximumBugs((float)num);
		MyCompany = company;
		SequelTo = sequelTo;
		InHouse = inHouse;
		Loss = loss;
		ReEvaluateMaxFollowers();
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			GameSettings.Instance.FollowerSimulation.Add(this);
		}
		RunScripts(Features, false, false, (FeatureProgress x) => x.Feature);
	}

	protected SoftwareWorkItem(string name, SoftwareAddOn type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, float price, SDateTime start, Company company, SoftwareProduct parent, SoftwareWorkItem parentW, double loss, IList<FeatureBase> feat, uint[] factors, string server2, uint workID, NetworkDeal networkDeal)
		: base(name, null, workID, networkDeal)
	{
		if (category == null)
		{
			throw new Exception("Tried to create software work item with no software category defined");
		}
		SoftwareName = name;
		AddonType = type;
		Type = category.Parent;
		SWCategory = category;
		Needs = needs;
		Price = price;
		DevStart = start;
		if (parent == null)
		{
			AddonWorkParent = parentW;
			AddonWorkParent.AddonWorkChildren.Add(this);
			TechLevels = AddonWorkParent.TechLevels;
			Submarkets = AddonWorkParent.Submarkets;
		}
		else
		{
			AddonParent = parent;
			TechLevels = parent.TechLevels;
			Submarkets = parent.Submarkets;
		}
		Features = GenerateProgress(Type, SWCategory, company, feat, TechLevels, null, null, false, null, null, factors);
		DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
		Server2 = server2;
		double num = Features.Sum((FeatureProgress x) => x.CDevTime);
		CodeArtRatio = (float)(num / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		MaxBugs = GetMaximumBugs((float)num);
		MyCompany = company;
		Loss = loss;
		ReEvaluateMaxFollowers();
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			GameSettings.Instance.FollowerSimulation.Add(this);
		}
	}

	protected SoftwareWorkItem(SoftwareAlpha parent, ReviewWindow.ReviewData data)
		: base(parent.SoftwareName, parent.contract, 0u, null, parent.guiItem.transform.GetSiblingIndex() + 1)
	{
		SoftwareName = parent.SoftwareName;
		Type = parent.Type;
		SWCategory = parent.SWCategory;
		Submarkets = parent.Submarkets;
		Needs = parent.Needs;
		OSs = parent.OSs;
		Price = parent.Price;
		SubscriptionBased = parent.SubscriptionBased;
		DevStart = parent.DevStart;
		TechLevels = parent.TechLevels;
		Features = GenerateProgress(SWCategory, parent.MyCompany, parent.Features, TechLevels, parent.SequelTo, data);
		DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
		CodeArtRatio = (float)(Features.Sum((FeatureProgress x) => x.CDevTime) / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		MyCompany = parent.MyCompany;
		SequelTo = parent.SequelTo;
		InHouse = parent.InHouse;
	}

	public static int GetMaximumBugs(float devTime)
	{
		return Mathf.RoundToInt(Mathf.Max(0f, devTime * SoftwareAlpha.BugLimitFactor) * ((devTime < 12f) ? Mathf.Sqrt(Mathf.Min(1f, devTime * 0.75f / 12f + 0.25f)) : 1f));
	}

	protected SoftwareWorkItem(string name, uint? swid, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] os, float price, bool subscription, double[] submarkets, SDateTime start, Company company, SoftwareProduct sequelTo, FeatureProgress[] feat, Dictionary<string, TechLevel> techs, bool inHouse, double loss, ContractWork contract, string server, string server2, int siblingIndex, float followers, uint maxFollowers, float followerChange, SDateTime? releaseDate, int maxBugs, string createFramework, SoftwareFramework framework, float frameworkRoyalty, double creativityScore, bool anyMarketing, List<KeyValuePair<Company, float>> workRoyalties, uint workID, NetworkDeal networkDeal)
		: base(name, contract, workID, networkDeal, siblingIndex)
	{
		if (category == null)
		{
			throw new Exception("Tried to create software work item with no software category defined");
		}
		SoftwareName = name;
		SWID = swid;
		Type = type;
		SWCategory = category;
		Submarkets = submarkets;
		Needs = needs;
		CreateFramework = createFramework;
		Framework = framework;
		FrameworkRoyalty = frameworkRoyalty;
		CreativityScore = creativityScore;
		_workRoyalties = workRoyalties;
		_anyMarketing = anyMarketing;
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				company.AddLicense(need.Value, this);
			}
		}
		OSs = os;
		Price = price;
		SubscriptionBased = subscription;
		DevStart = start;
		TechLevels = techs;
		Features = feat;
		DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
		for (int num = 0; num < Features.Length; num++)
		{
			if (GetNetworkDealState() != NetworkDealState.Receiver)
			{
				Features[num].Reset();
			}
			Features[num].Assigned = 0;
		}
		Server = server;
		Server2 = server2;
		ReleaseDate = releaseDate;
		CodeArtRatio = (float)(Features.Sum((FeatureProgress x) => x.CDevTime) / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		MaxBugs = maxBugs;
		MyCompany = company;
		SequelTo = sequelTo;
		InHouse = inHouse;
		Loss = loss;
		MaxFollowers = maxFollowers;
		if (MaxFollowers == 0)
		{
			MaxFollowers = 1u;
		}
		Followers = followers;
		FollowerChange = followerChange;
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			GameSettings.Instance.FollowerSimulation.Add(this);
		}
		RunScripts(Features, false, false, (FeatureProgress x) => x.Feature);
	}

	protected SoftwareWorkItem(string name, uint? swid, SoftwareAddOn type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, float price, SDateTime start, Company company, SoftwareProduct parent, SoftwareWorkItem parentW, FeatureProgress[] feat, double loss, string server2, int siblingIndex, float followers, uint maxFollowers, float followerChange, SDateTime? releaseDate, int maxBugs, double creativityScore, bool anyMarketing, List<KeyValuePair<Company, float>> workRoyalties, uint workID, NetworkDeal networkDeal)
		: base(name, null, workID, networkDeal, siblingIndex)
	{
		if (category == null)
		{
			throw new Exception("Tried to create software work item with no software category defined");
		}
		SoftwareName = name;
		SWID = swid;
		AddonType = type;
		CreativityScore = creativityScore;
		Type = category.Parent;
		SWCategory = category;
		_anyMarketing = anyMarketing;
		_workRoyalties = workRoyalties;
		Needs = needs;
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				company.AddLicense(need.Value, this);
			}
		}
		Price = price;
		DevStart = start;
		if (parent == null)
		{
			AddonWorkParent = parentW;
			AddonWorkParent.AddonWorkChildren.Add(this);
			TechLevels = AddonWorkParent.TechLevels;
			Submarkets = AddonWorkParent.Submarkets;
		}
		else
		{
			AddonParent = parent;
			TechLevels = parent.TechLevels;
			Submarkets = parent.Submarkets;
		}
		Features = feat;
		DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
		for (int num = 0; num < Features.Length; num++)
		{
			if (GetNetworkDealState() != NetworkDealState.Receiver)
			{
				Features[num].Reset();
			}
			Features[num].Assigned = 0;
		}
		Server2 = server2;
		ReleaseDate = releaseDate;
		CodeArtRatio = (float)(Features.Sum((FeatureProgress x) => x.CDevTime) / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		MaxBugs = maxBugs;
		MyCompany = company;
		Loss = loss;
		MaxFollowers = maxFollowers;
		if (MaxFollowers == 0)
		{
			MaxFollowers = 1u;
		}
		Followers = followers;
		FollowerChange = followerChange;
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			GameSettings.Instance.FollowerSimulation.Add(this);
		}
	}

	protected SoftwareWorkItem(SoftwareProduct targetSoftware, Dictionary<string, TechLevel> techs, Dictionary<string, SoftwareProduct> needs, string server2, int siblingIndex, uint networkID, NetworkDeal networkDeal)
		: base("UpdatingProduct".Loc(targetSoftware.Name), null, networkID, networkDeal, siblingIndex)
	{
		SoftwareName = targetSoftware.Name;
		Type = targetSoftware.Type;
		SWCategory = targetSoftware.Category;
		TechLevels = techs;
		Needs = needs;
		MyCompany = targetSoftware.DevCompany;
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
			{
				MyCompany.AddLicense(need.Value, this);
			}
		}
		if (TechLevels != null && TechLevels.Count > 0)
		{
			Features = GenerateProgress(targetSoftware.Type, targetSoftware.Category, targetSoftware.DevCompany, targetSoftware.Features.Where((FeatureBase x) => techs.ContainsKey(x.Spec)).ToList(), techs, null, null, false, targetSoftware.Framework, targetSoftware.TechLevels);
			DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
			for (int num = 0; num < Features.Length; num++)
			{
				Features[num].Reset();
				Features[num].Assigned = 0;
			}
			CodeArtRatio = (float)(Features.Sum((FeatureProgress x) => x.CDevTime) / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		}
		else
		{
			Features = Array.Empty<FeatureProgress>();
		}
		Server2 = server2;
		MaxBugs = Mathf.Max(0, GetMaximumBugs(targetSoftware.Features.SumSafe((FeatureBase x) => x.DevTime * x.CodeArtRatio)) - targetSoftware.FixableBugs);
		RunScripts(Features, false, false, (FeatureProgress x) => x.Feature);
	}

	protected SoftwareWorkItem(SoftwareFramework targetSoftware, Dictionary<string, TechLevel> techs, string server2, int siblingIndex, uint networkID, NetworkDeal networkDeal)
		: base("UpdatingProduct".Loc(targetSoftware.Name), null, networkID, networkDeal, siblingIndex)
	{
		SoftwareName = targetSoftware.Name;
		Type = targetSoftware.Type;
		SWCategory = targetSoftware.Category;
		TechLevels = techs;
		Needs = new Dictionary<string, SoftwareProduct>();
		MyCompany = targetSoftware.Owner;
		if (TechLevels != null && TechLevels.Count > 0)
		{
			Features = GenerateProgress(targetSoftware.Type, targetSoftware.Category, targetSoftware.Owner, targetSoftware.Features.Keys.Where((FeatureBase x) => techs.ContainsKey(x.Spec)).ToList(), techs, null, null, false, null, targetSoftware.TechLevels, null, targetSoftware.Updated);
			DevTime = (float)Features.Sum((FeatureProgress x) => x.DevTime);
			for (int num = 0; num < Features.Length; num++)
			{
				Features[num].Reset();
				Features[num].Assigned = 0;
			}
			CodeArtRatio = (float)(Features.Sum((FeatureProgress x) => x.CDevTime) / Features.Sum((FeatureProgress x) => x.CDevTime + x.ADevTime));
		}
		else
		{
			Features = Array.Empty<FeatureProgress>();
		}
		Server2 = server2;
		MaxBugs = 0;
		RunScripts(Features, false, false, (FeatureProgress x) => x.Feature);
	}

	public override void DevTeamChange()
	{
		if (!Done)
		{
			UpdateWorking();
		}
	}

	public override void PauseChange()
	{
		UpdateWorking();
	}

	public void UpdateWorking()
	{
		HashSet<Employee> hashSet = NewWorking.Keys.ToHashSet();
		if (Paused)
		{
			return;
		}
		foreach (string devTeam in DevTeams)
		{
			Team team = GameSettings.GetTeam(devTeam);
			if (team == null)
			{
				continue;
			}
			List<Actor> employeesDirect = team.GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (!(actor != null) || !actor.isActiveAndEnabled || !actor.IsWorking || actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
				{
					continue;
				}
				HasWorkReturn hasWorkReturn = HasWork(actor, actor.SecondaryWork, false);
				if (hasWorkReturn == HasWorkReturn.True || hasWorkReturn == HasWorkReturn.Secondary)
				{
					FeatureProgress value;
					if (NewWorking.TryGetValue(actor.employee, out value) && value != null)
					{
						value.Assigned--;
					}
					NewWorking[actor.employee] = null;
					hashSet.Remove(actor.employee);
				}
			}
		}
		foreach (Employee item in hashSet)
		{
			RemoveWorking(item);
		}
		for (int j = 0; j < Features.Length; j++)
		{
			Features[j].Assigned = 0;
		}
		foreach (KeyValuePair<Employee, FeatureProgress> item2 in NewWorking)
		{
			if (item2.Value != null)
			{
				item2.Value.Assigned++;
			}
		}
	}

	public void RemoveWorking(Employee u)
	{
		FeatureProgress value;
		if (NewWorking.TryGetValue(u, out value))
		{
			NewWorking.Remove(u);
			if (value != null)
			{
				value.Assigned--;
			}
		}
	}

	protected FeatureProgress FindOptimalTask(Actor a, bool secondary, bool design)
	{
		FeatureProgress featureProgress = null;
		FeatureProgress featureProgress2 = null;
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		for (int i = 0; i < Features.Length; i++)
		{
			FeatureProgress featureProgress3 = Features[i];
			HasWorkReturn hasWorkReturn = a.employee.CanWorkOnFeatureSecondary(featureProgress3, secondary, design);
			if (hasWorkReturn == HasWorkReturn.True && featureProgress3.Assigned < num)
			{
				num = featureProgress3.Assigned;
				featureProgress = featureProgress3;
			}
			else if (hasWorkReturn == HasWorkReturn.Secondary && featureProgress3.Assigned < num2)
			{
				num2 = featureProgress3.Assigned;
				featureProgress2 = featureProgress3;
			}
		}
		FeatureProgress c = featureProgress ?? featureProgress2;
		HasWorkReturn hasWorkReturn2 = ((featureProgress == null) ? HasWorkReturn.Secondary : HasWorkReturn.True);
		if (c != null && c.Feature.Level < 3 && a.employee.GetBestSpecialization(design, c) < 3)
		{
			for (int j = 0; j < Features.Length; j++)
			{
				FeatureProgress feat = Features[j];
				if (feat != c && feat.Feature.Level < 3 && a.employee.CanWorkOnFeatureSecondary(feat, secondary, design) == hasWorkReturn2 && !c.Feature.Spec.Equals(feat.Feature.Spec) && a.employee.GetBestSpecialization(design, feat) == 3)
				{
					HashSet<Employee> hashSet = NewWorking.ReverseLookup(feat);
					Employee employee = ((hashSet != null) ? hashSet.FirstOrDefault((Employee x) => x.GetBestSpecialization(design, feat) < 3 && x.CanWorkOnFeature(c, false, design)) : null);
					if (employee != null)
					{
						featureProgress = feat;
						AssignTask(employee.MyActor, c);
						break;
					}
				}
			}
		}
		if (featureProgress != null)
		{
			AssignTask(a, featureProgress);
			return featureProgress;
		}
		if (featureProgress2 != null)
		{
			AssignTask(a, featureProgress2);
			return featureProgress2;
		}
		return null;
	}

	protected void AssignTaskIfNone(Actor a, bool secondary, bool design, bool actuallyAssignTask = true)
	{
		if (!NewWorking.ContainsKey(a.employee))
		{
			NewWorking[a.employee] = null;
			if (actuallyAssignTask)
			{
				FindOptimalTask(a, secondary, design);
			}
		}
	}

	protected void AssignTask(Actor a, FeatureProgress f)
	{
		FeatureProgress value;
		if (NewWorking.TryGetValue(a.employee, out value) && value != null)
		{
			if (value == f)
			{
				return;
			}
			value.Assigned--;
		}
		NewWorking[a.employee] = f;
		f.Assigned++;
	}

	protected FeatureProgress FindJob(Actor actor, bool secondary, bool design, bool canAssignNew)
	{
		if (NewWorking.Count < Features.Length)
		{
			return null;
		}
		FeatureProgress featureProgress = NewWorking.GetOrDefault(actor.employee);
		if (canAssignNew && (featureProgress == null || !actor.employee.CanWorkOnFeature(featureProgress, secondary, design)))
		{
			RemoveWorking(actor.employee);
			featureProgress = FindOptimalTask(actor, secondary, design);
		}
		return featureProgress;
	}

	protected HasWorkReturn CheckAdequateSpecLevel(Actor act, bool secondary, bool design, bool canAssignNew)
	{
		FeatureProgress featureProgress = FindJob(act, secondary, design, canAssignNew);
		if (featureProgress != null)
		{
			return act.employee.CanWorkOnFeatureSecondary(featureProgress, secondary, design);
		}
		HasWorkReturn result = HasWorkReturn.NotApplicable;
		for (int i = 0; i < Features.Length; i++)
		{
			switch (act.employee.CanWorkOnFeatureSecondary(Features[i], secondary, design))
			{
			case HasWorkReturn.True:
				return HasWorkReturn.True;
			case HasWorkReturn.Secondary:
				result = HasWorkReturn.Secondary;
				break;
			}
		}
		return result;
	}

	protected bool WorkAllFeatures(Actor ac, double left, float max, Employee.EmployeeRole role, out double added, bool addQuality, float skill)
	{
		float num = (float)Features.Length / 2f + 0.5f;
		added = 0.0;
		bool art = role == Employee.EmployeeRole.Artist;
		bool flag = false;
		for (int i = 0; i < Features.Length; i++)
		{
			FeatureProgress featureProgress = Features[i];
			if (ac.employee.GetSpecialization(role, featureProgress.Feature.Spec) >= featureProgress.Feature.Level)
			{
				bool change;
				double actuallyAdded;
				double num2 = featureProgress.AddProgress(left / (double)num, role, ac.employee.GetSpecialization(role, featureProgress.Feature.Spec) == 3, out change, out actuallyAdded, max);
				flag = flag || change;
				left -= num2;
				added += num2;
				if (!featureProgress.OS && addQuality)
				{
					featureProgress.AddQuality(skill, actuallyAdded, art);
				}
			}
			num -= 0.5f;
		}
		return flag;
	}

	public override int GUIWorkItemType()
	{
		return 1;
	}

	public void FixAutoDev()
	{
		if (!AutoDev)
		{
			return;
		}
		foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			for (int i = 0; i < item.Items.Count; i++)
			{
				AutoDevWorkItem.AutoDevItem autoDevItem = item.Items[i];
				if (autoDevItem.SWWorkItem == this)
				{
					item.Items.Remove(autoDevItem);
					if (SoftwareName.Equals(item.LastDesign))
					{
						item.LastDesign = null;
					}
					if (SoftwareName.Equals(item.LastAlpha))
					{
						item.LastAlpha = null;
					}
					if (SoftwareName.Equals(item.LastAlpha2))
					{
						item.LastAlpha2 = null;
					}
					item.RefreshNextReleaseDate();
					return;
				}
			}
		}
	}

	public override string GetActualString()
	{
		return SoftwareName;
	}

	public void KillLicenses()
	{
		if (Needs == null || MyCompany == null)
		{
			return;
		}
		foreach (KeyValuePair<string, SoftwareProduct> need in Needs)
		{
			MyCompany.RemoveLicense(need.Value, this);
		}
	}

	public override void Kill(bool wasCancelled = false)
	{
		foreach (SoftwareWorkItem addonWorkChild in AddonWorkChildren)
		{
			addonWorkChild.Kill(wasCancelled);
		}
		RunScripts(Features, true, wasCancelled, (FeatureProgress x) => x.Feature);
		if (Publishing != null)
		{
			if (wasCancelled)
			{
				float months = SDateTime.GetMonths(DevStart, SDateTime.Now());
				MyCompany.ChangeBusinessRep(0f - Mathf.Clamp01(months / Publishing.Months), "Publisher");
				float num = 0.05f;
				if (Publishing.Deals.Contains("Funding"))
				{
					num = 0.25f;
					Publishing.Suit();
					GameSettings.Lawsuit lawsuit = new GameSettings.Lawsuit(Publishing.Publisher, "PublishingLawsuit", Publishing.Funding * 1.5f, 1f);
					lawsuit.Reasons.Add("CancelledProjectFund");
					lawsuit.Spiff = true;
					GameSettings.Instance.LaunchSuit(lawsuit);
				}
				SimulatedCompany simulatedCompany;
				if ((simulatedCompany = Publishing.Publisher as SimulatedCompany) != null)
				{
					simulatedCompany.PlayerRelationship = Mathf.Max(0f, simulatedCompany.PlayerRelationship - num);
				}
			}
			Publishing.Abandon(false);
		}
		KillLicenses();
		if (wasCancelled)
		{
			NetworkSchedule(true);
		}
		base.Kill(wasCancelled);
	}

	protected abstract IEnumerable<Employee.EmployeeRole> CompCheck();

	public virtual bool DisableCompCheck()
	{
		return false;
	}

	public void CheckCompetency()
	{
		if (DevTeams.Count > 0 && !DisableCompCheck())
		{
			bool flag = false;
			List<Team> devTeams = GetDevTeams();
			foreach (Employee.EmployeeRole item in CompCheck())
			{
				for (int i = 0; i < Features.Length; i++)
				{
					FeatureProgress featureProgress = Features[i];
					if (!featureProgress.RelevantFor(item))
					{
						continue;
					}
					bool flag2 = false;
					bool flag3 = false;
					for (int j = 0; j < devTeams.Count; j++)
					{
						List<Actor> employeesDirect = devTeams[j].GetEmployeesDirect();
						for (int k = 0; k < employeesDirect.Count; k++)
						{
							flag2 = true;
							Actor actor = employeesDirect[k];
							if (!actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && actor.employee.IsRole(item, true))
							{
								HasWorkReturn hasWorkReturn = HasWork(actor, true, false);
								if ((hasWorkReturn == HasWorkReturn.True || hasWorkReturn == HasWorkReturn.Secondary) && actor.employee.GetSpecialization(item, featureProgress.Feature.Spec) >= featureProgress.Feature.Level)
								{
									flag3 = true;
									break;
								}
							}
						}
						if (flag3)
						{
							break;
						}
					}
					if (!flag2)
					{
						NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
						return;
					}
					if (!flag3)
					{
						FormatColorString feature = featureProgress.Feature.Name.SWFeat(Type.Name);
						string spec = ((featureProgress.Feature.Level > 0) ? "SpecSkillRole".Loc(featureProgress.Feature.Level, featureProgress.Feature.Spec.LocTry(), item.ToString().Loc()) : item.ToString().Loc());
						if (!NotificationManager.CheckAggregate<NoQualifiedNotification>(this, ID))
						{
							NotificationManager.AddNotification(new NoQualifiedNotification(this, feature, spec));
						}
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
			}
		}
		else
		{
			NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
		}
	}

	public double GetPerceivedMarketValue()
	{
		if (AddOn)
		{
			return AddonType.PerceivedMarketValue(GetAddonFeatures(), GetFactors(), SWCategory, TechLevels, Submarkets);
		}
		FeatureBase[] features = GetFeatures();
		return SWCategory.PerceivedMarketValue(features, TechLevels, Submarkets, SoftwareType.BigProjectEffect(Type.GetOptimalDevTime(SWCategory), 1.0, 1.0, Type.SimpleDevTime(features, SWCategory, TechLevels)));
	}

	public void UpdateContract()
	{
		SoftwareAlpha softwareAlpha = this as SoftwareAlpha;
		if (softwareAlpha != null)
		{
			if (!(SDateTime.GetMonths(DevStart, SDateTime.Now()) > (float)Mathf.Max(4, contract.Months * 2)))
			{
				return;
			}
			if (softwareAlpha.GetCodeArtProgress() > 0.0)
			{
				softwareAlpha.AutoDev = true;
				if (softwareAlpha.InBeta)
				{
					softwareAlpha.PromoteAction();
					return;
				}
				softwareAlpha.PromoteAction();
				softwareAlpha.PromoteAction();
			}
			else
			{
				Kill(true);
			}
		}
		else if (SDateTime.GetMonths(DevStart + 2, SDateTime.Now()) > (float)Mathf.Max(4, contract.Months * 2))
		{
			Kill(true);
		}
	}

	public string GetTitle()
	{
		return SoftwareName;
	}

	public string GetDescription()
	{
		return SWCategory.GetActualString();
	}

	public SDateTime? GetTime()
	{
		if (contract != null)
		{
			return DevStart + contract.Months;
		}
		if (deal == 0)
		{
			return ReleaseDate;
		}
		return null;
	}

	public ComingReleaseWindow.EventType GetEventType()
	{
		if (contract == null)
		{
			return ComingReleaseWindow.EventType.PlayerRelease;
		}
		return ComingReleaseWindow.EventType.ContractDeadline;
	}

	public bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		if (t == null || t == Type)
		{
			if (c != null)
			{
				return c == SWCategory;
			}
			return true;
		}
		return false;
	}

	public float HWSkillFactor(float skill, Actor a)
	{
		if (AddOn ? AddonType.Hardware : SWCategory.Hardware)
		{
			a.SetTraitView(Employee.Trait.FirmwareInc, 0, 5);
			return Mathf.Min(1f, skill * 1.2f);
		}
		return skill * 0.8f;
	}

	public double GetSpProgress(bool all, bool art)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < Features.Length; i++)
		{
			if (all || art)
			{
				num += Features[i].ArtProgress;
				num2 += Features[i].ADevTime;
			}
			if (all || !art)
			{
				num += Features[i].Progress;
				num2 += Features[i].CDevTime;
			}
		}
		if (num2 != 0.0)
		{
			return num / num2;
		}
		return 0.0;
	}

	protected void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs, bool design)
	{
		int num = SoftwareType.GetOptimalEmployeeCount(DevTime)[(!design) ? 1u : 0u];
		FeatureProgress[] features = Features;
		foreach (FeatureProgress featureProgress in features)
		{
			if (featureProgress.Feature.Level <= 0)
			{
				continue;
			}
			if (design)
			{
				int value = Mathf.Max(1, Utilities.CeilToInt(featureProgress.DevTime / (double)DevTime * (double)num));
				needs.GetNeed(Employee.EmployeeRole.Designer).AddUp(new HRManagement.EdNeed(featureProgress.Feature.Spec, featureProgress.Feature.Level), value);
				continue;
			}
			if (featureProgress.ADevTime > 0.0)
			{
				int value2 = Mathf.Max(1, Utilities.CeilToInt(featureProgress.ADevTime / (double)DevTime * (double)num));
				needs.GetNeed(Employee.EmployeeRole.Artist).AddUp(new HRManagement.EdNeed(featureProgress.Feature.Spec, featureProgress.Feature.Level), value2);
			}
			if (featureProgress.CDevTime > 0.0)
			{
				int value3 = Mathf.Max(1, Utilities.CeilToInt(featureProgress.CDevTime / (double)DevTime * (double)num));
				needs.GetNeed(Employee.EmployeeRole.Programmer).AddUp(new HRManagement.EdNeed(featureProgress.Feature.Spec, featureProgress.Feature.Level), value3);
			}
		}
	}

	public Employee GetLeadDesigner()
	{
		if (AddOn)
		{
			if (WorkAddOn)
			{
				return AddonWorkParent.GetLeadDesigner();
			}
			return AddonParent.LeadDesigner;
		}
		if (LeadWork != null && LeadWork.Count > 0)
		{
			return LeadWork.MaxInstance((KeyValuePair<Employee, float> x) => x.Value).Key;
		}
		if (this is DesignDocument)
		{
			return ((DesignDocument)this).LeadDesigner;
		}
		return null;
	}

	public override Company GetLocalCompanyOwner()
	{
		return MyCompany ?? GameSettings.Instance.MyCompany;
	}

	public override float GetLicenseAmount()
	{
		return (_networkLastWorked.HasValue && GetNetworkDealState() == NetworkDealState.Sender) ? _networkLastWorked.Value : LastWorked.Count;
	}

	public override void ReceiveNetworkDealSync(Stream st)
	{
		_networkLastWorked = st.ReadInt();
	}

	public override byte[] SubSendNetworkDealSync()
	{
		return BitConverter.GetBytes(LastWorked.Count);
	}

	public IEnumerable<KeyValuePair<Company, float>> GetWorkRoyalties()
	{
		if (_workRoyalties == null)
		{
			yield break;
		}
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
		if (!(r > 0f))
		{
			return;
		}
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

	public override IRoyaltyItem GetRoyaltyItem()
	{
		if (!DistributionPlatform)
		{
			return this;
		}
		return null;
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		return new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("Product".Loc(), SoftwareName),
			new KeyValuePair<string, string>("Type".Loc(), AddOn ? AddonType.GetActualString() : SWCategory.GetActualString()),
			new KeyValuePair<string, string>("Work".Loc(), GetSoftwareWorkType().Loc())
		};
	}

	public override string GetGroupProject()
	{
		return SoftwareName;
	}

	public abstract string GetSoftwareWorkType();

	public void FixReviewRep(ref string companyName, ref float rep)
	{
		PublisherDeal relevantPublisherDeal = GetRelevantPublisherDeal();
		if (relevantPublisherDeal != null)
		{
			float reputation = relevantPublisherDeal.Publisher.GetReputation(SWCategory);
			if (reputation > GetLocalCompanyOwner().GetReputation(SWCategory))
			{
				companyName = relevantPublisherDeal.Publisher.Name;
				rep = reputation;
			}
		}
	}
}
