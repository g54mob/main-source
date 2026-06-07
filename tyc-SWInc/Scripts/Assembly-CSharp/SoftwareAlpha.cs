using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SINetworking;
using UnityEngine;

[Serializable]
public class SoftwareAlpha : SoftwareWorkItem, IServerItem, IReferenceFix, IStockable, ILossable
{
	public static float BugLimitFactor = 100f;

	public bool InBeta;

	public bool Released;

	public bool HasFinished;

	public bool HasFinishedArt;

	public bool HasFinishedCode;

	public float Bugs;

	public float FixedBugs;

	public SoftwareProduct Mock;

	public IStockable Final;

	private DesignDocument _child;

	public SDateTime LastIteration;

	private float SourceControlBoost;

	public float[,,] SpecTempQuality;

	public float[,,] SpecWeight;

	public float[,] FinalSpecQuality;

	public float MaxArtDt;

	public float MaxDevDt;

	public float DesignProgress;

	public SHashSet<uint> EverWorked;

	public List<ReviewWindow.ReviewData> PastReviews = new List<ReviewWindow.ReviewData>();

	public int ReviewsDone;

	public float ReviewScore;

	public float BugRate = 1f;

	public float DistributionLoss;

	public bool DidLastReviewIteration = true;

	public List<string> DesignTeams;

	public Dictionary<SoftwareProduct, float> Tools = new Dictionary<SoftwareProduct, float>();

	private int _hardwareMask;

	private int _hardwareInputMask;

	private float _hardwarePrice;

	private float _lastMaxCodeSkill = -1f;

	[NonSerialized]
	private float _lastMaxCodeSkillTime;

	public DesignDocument Child
	{
		get
		{
			return _child;
		}
		set
		{
			_child = value;
			if (guiItem != null)
			{
				guiItem.UpdatePauseButton();
			}
		}
	}

	public uint PhysicalCopies { get; set; }

	public uint CopiesPerBox
	{
		get
		{
			return 1000u;
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

	public IManufacturable Manufacturing
	{
		get
		{
			if (!base.AddOn)
			{
				return SWCategory;
			}
			return AddonType;
		}
	}

	public IList<FeatureBase> FeaturesBases
	{
		get
		{
			return GetFeatures();
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
			return Final ?? this;
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
			return SWCategory;
		}
	}

	public override bool Paused
	{
		get
		{
			if (Child == null)
			{
				return base.Paused;
			}
			return true;
		}
		set
		{
			base.Paused = value;
		}
	}

	public override bool AlwaysUseLocalStageLabel
	{
		get
		{
			return true;
		}
	}

	public override Color BackColor
	{
		get
		{
			return new Color(0f, 0.75f, 0f);
		}
	}

	public bool UsesISP
	{
		get
		{
			return false;
		}
	}

	public bool IsReadOnlyJob
	{
		get
		{
			return false;
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			if ((Needs == null || Needs.Values.None((SoftwareProduct x) => x.IsMock)) && (OSs == null || OSs.None((SoftwareProduct x) => x.IsMock)))
			{
				return AddonWorkParent == null;
			}
			return false;
		}
	}

	public override string UnitName
	{
		get
		{
			if (!InBeta)
			{
				return "Percent";
			}
			return "Bug";
		}
	}

	public override uint MaxUnits
	{
		get
		{
			if (!InBeta)
			{
				return 100u;
			}
			return 0u;
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 7;
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return !InBeta;
		}
	}

	public void AddReviewScore(float accuracy)
	{
		ReviewsDone++;
		ReviewScore += (float)((double)accuracy * GetCodeArtProgress() * (double)((float)ReviewsDone / 8f));
	}

	private float GetReviewFactor()
	{
		return 1f - Mathf.Pow(0.25f, ReviewScore);
	}

	public float GetBugReviewFactor()
	{
		return GetReviewFactor() * 0.1f;
	}

	public override IReferenceFix FixReferences()
	{
		SoftwareProduct mock = Mock;
		Mock = (SoftwareProduct)((mock != null) ? mock.FixReferences() : null);
		Tools = Tools.FixKeyReferences(true);
		IStockable final = Final;
		Final = (IStockable)((final != null) ? final.FixReferences() : null);
		return base.FixReferences();
	}

	public SoftwareAlpha(string name)
		: base(name)
	{
	}

	public SoftwareAlpha()
	{
	}

	public override void DevTeamChange()
	{
		base.DevTeamChange();
		_lastMaxCodeSkill = -1f;
		GameSettings.Instance.CheckOSLicenses = true;
	}

	public SoftwareAlpha(string name, uint? swid, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, FeatureProgress[] feat, Dictionary<string, TechLevel> techs, SoftwareProduct[] os, float price, bool subscription, double[] submarkets, SDateTime start, float bugs, Company company, SoftwareProduct sequelTo, bool inHouse, double loss, ContractWork contract, string server, string server2, int siblingIndex, SHashSet<uint> everWorked, float followers, uint maxFollowers, float followerChange, SDateTime? releaseDate, int maxBugs, float bugRate, SoftwareFramework framework, float frameworkRoyalty, string createFramework, List<string> designTeams, List<SoftwareProduct> tools, double creativityScore, bool anyMarketing, List<KeyValuePair<Company, float>> workRoyalties, uint workID = 0u, NetworkDeal networkDeal = null)
		: base(name, swid, type, category, needs, os, price, subscription, submarkets, start, company, sequelTo, feat, techs, inHouse, loss, contract, server, server2, siblingIndex, followers, maxFollowers, followerChange, releaseDate, maxBugs, createFramework, framework, frameworkRoyalty, creativityScore, anyMarketing, workRoyalties, workID, networkDeal)
	{
		Bugs = bugs;
		BugRate = bugRate;
		if (contract == null)
		{
			TutorialSystem.Instance.StartTutorial("Alpha work");
		}
		Tools = tools.Distinct().ToDictionary((SoftwareProduct x) => x, (SoftwareProduct x) => 0f);
		LastIteration = SDateTime.Now();
		RegisterServer();
		DesignTeams = designTeams;
		EverWorked = everWorked;
		if (category.Hardware)
		{
			category.Manufacturing.GetProcessInfo(GetFeatures(), GetFeaturesFactors(), out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
		}
	}

	public SoftwareAlpha(string name, uint? swid, SoftwareAddOn type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, FeatureProgress[] feat, float price, SDateTime start, float bugs, Company company, SoftwareProduct parent, SoftwareWorkItem parentW, double loss, string server2, int siblingIndex, SHashSet<uint> everWorked, float followers, uint maxFollowers, float followerChange, SDateTime? releaseDate, int maxBugs, float bugRate, List<string> designTeams, List<SoftwareProduct> tools, double creativityScore, bool anyMarketing, List<KeyValuePair<Company, float>> workRoyalties, uint workID = 0u, NetworkDeal networkDeal = null)
		: base(name, swid, type, category, needs, price, start, company, parent, parentW, feat, loss, server2, siblingIndex, followers, maxFollowers, followerChange, releaseDate, maxBugs, creativityScore, anyMarketing, workRoyalties, workID, networkDeal)
	{
		Bugs = bugs;
		BugRate = bugRate;
		if (contract == null)
		{
			TutorialSystem.Instance.StartTutorial("Alpha work");
		}
		Tools = tools.Distinct().ToDictionary((SoftwareProduct x) => x, (SoftwareProduct x) => 0f);
		LastIteration = SDateTime.Now();
		RegisterServer();
		DesignTeams = designTeams;
		EverWorked = everWorked;
		if (type.Hardware)
		{
			type.Manufacturing.GetProcessInfo(GetFeatures(), GetFeaturesFactors(), out _hardwarePrice, out _hardwareMask, out _hardwareInputMask);
		}
	}

	public void CreateMock()
	{
		if (!base.AddOn && !base.DistributionPlatform)
		{
			double[] qualities = GetQualities();
			Mock = new SoftwareProduct(SoftwareName, Type, SWCategory, OSs, qualities[0], qualities[1], qualities[2], qualities[3], GetMarketQuality(), CreativityScore, Price, SubscriptionBased, Submarkets, DevStart, DevStart, 0, InHouse, GameSettings.Instance.MyCompany, SequelTo, ForceID(), 0.0, GetFeatures(), TechLevels, null, 0u, Framework, FrameworkRoyalty, Tools, this);
			GameSettings.Instance.simulation.AddProduct(Mock, true);
		}
	}

	public void RegisterServer()
	{
		if (Server2 != null)
		{
			GameSettings.Instance.RegisterWithServer(Server2, this);
		}
	}

	public override string CurrentStage()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(InBeta ? "Beta".Loc() : "Alpha".Loc());
		if (contract != null)
		{
			stringBuilder.AppendLine(contract.GetStatus(DevStart));
		}
		else if (deal != 0)
		{
			stringBuilder.AppendLine(base.ActiveDeal.GetStatus());
		}
		else if (!base.DistributionPlatform)
		{
			stringBuilder.AppendLine("FollowerAmount".Loc(Mathf.RoundToInt(base.Followers).ToString("N0")));
		}
		return stringBuilder.ToString();
	}

	public override string GetProgressLabel()
	{
		if (InBeta)
		{
			return GetProgressBeta(Mathf.FloorToInt(Bugs), (int)FixedBugs);
		}
		return GetProgressAlpha(Child != null, (float)((Child == null && CodeArtRatio > 0f) ? GetSpProgress(false, false) : (-1.0)), (float)((Child == null && CodeArtRatio < 1f) ? GetSpProgress(false, true) : (-1.0)));
	}

	private string GetProgressBeta(int bugs, int fixedBugs)
	{
		if (bugs != 0)
		{
			return "StillBugs".Loc(fixedBugs);
		}
		return "NoBugs".Loc();
	}

	private string GetProgressAlpha(bool iterating, float code, float art)
	{
		if (iterating)
		{
			return "Iterating".Loc();
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (code >= 0f)
		{
			stringBuilder.AppendLine("Code".Loc() + ": " + code.ToPercent(false));
		}
		if (art >= 0f)
		{
			stringBuilder.AppendLine("Art".Loc() + ": " + art.ToPercent(false));
		}
		return stringBuilder.ToString();
	}

	public override byte[] SerializeProgressData()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			if (InBeta)
			{
				memoryStream.WriteInt(Mathf.FloorToInt(Bugs));
				memoryStream.WriteInt((int)FixedBugs);
			}
			else
			{
				memoryStream.WriteBool(Child != null);
				if (Child == null)
				{
					memoryStream.WriteFloat((float)((CodeArtRatio > 0f) ? GetSpProgress(false, false) : (-1.0)));
					memoryStream.WriteFloat((float)((CodeArtRatio < 1f) ? GetSpProgress(false, true) : (-1.0)));
				}
			}
			return memoryStream.ToArray();
		}
	}

	public override void DeserializeProgressData(byte[] data)
	{
		NetworkStage = CurrentStage();
		NetworkCategory = Category();
		using (MemoryStream stream = new MemoryStream(data))
		{
			if (InBeta)
			{
				NetworkProgressLabel = GetProgressBeta(stream.ReadInt(), stream.ReadInt());
				return;
			}
			bool flag = stream.ReadBool();
			NetworkProgressLabel = GetProgressAlpha(flag, (!flag) ? stream.ReadFloat() : 0f, (!flag) ? stream.ReadFloat() : 0f);
		}
	}

	public override string GetIcon()
	{
		return "Software";
	}

	public float MaxQualityPercent(Team team, bool secondary, bool both = true, bool onlyArt = true, bool ratio = true)
	{
		if (team == null)
		{
			return 0f;
		}
		float num = 0f;
		float num2 = 0f;
		List<Actor> employeesDirect = team.GetEmployeesDirect();
		for (int i = 0; i < employeesDirect.Count; i++)
		{
			Employee employee = employeesDirect[i].employee;
			if ((both || onlyArt) && employee.IsRole(Employee.RoleBit.Artist, secondary))
			{
				num = Mathf.Max(num, employee.GetSkill(Employee.EmployeeRole.Artist));
			}
			if ((both || !onlyArt) && employee.IsRole(Employee.RoleBit.Programmer, secondary))
			{
				num2 = Mathf.Max(num2, employee.GetSkill(Employee.EmployeeRole.Programmer));
			}
		}
		float num3 = 0f;
		if (both)
		{
			return num * (1f - CodeArtRatio) + num2 * CodeArtRatio;
		}
		if (onlyArt)
		{
			return num * (ratio ? (1f - CodeArtRatio) : 1f);
		}
		return num2 * (ratio ? CodeArtRatio : 1f);
	}

	public override float GetMax()
	{
		if (contract == null || InBeta)
		{
			return 0f;
		}
		return contract.MinProg;
	}

	public override float GetProgress()
	{
		if (InBeta)
		{
			return 0f;
		}
		return (float)GetCodeArtProgress();
	}

	public double GetCodeArtProgress()
	{
		return GetSpProgress(true, false);
	}

	public double GetQuality()
	{
		return FinalQualityCalc(GetSpProgress(true, false), GetSpQuality(true, false));
	}

	public static float GetMaxCodeQuality(float progress)
	{
		if (progress <= 1f)
		{
			return 1f;
		}
		if (progress <= 2f)
		{
			return (2f - progress) * 0.75f + 0.25f;
		}
		return 1f / progress * 0.5f;
	}

	public double[] GetQualities()
	{
		return new double[4]
		{
			GetSpProgress(false, false),
			GetSpProgress(false, true),
			GetSpQuality(false, false),
			GetSpQuality(false, true)
		};
	}

	public double GetLimitedQuality()
	{
		return GetQuality();
	}

	public double GetLimitedProgress(Team team)
	{
		if (!InBeta)
		{
			return GetCodeArtProgress();
		}
		return (Mathf.FloorToInt(Bugs) == 0) ? 1f : (FixedBugs / Mathf.Min(Mathf.Floor(Bugs), Mathf.Floor(MaxBugFix(team))));
	}

	public override bool DisableCompCheck()
	{
		return Child != null;
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		if (Child != null)
		{
			return HasWorkReturn.Ignore;
		}
		if (AutoDev && !Enabled)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.Ignore;
		}
		HasWorkReturn a = actor.employee.IsRoleSecondary(Employee.RoleBit.Artist, secondary);
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Programmer, secondary);
		if (WorkItem.CombineWorkResult(a, hasWorkReturn) == HasWorkReturn.NotApplicable)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.NotApplicable;
		}
		int num;
		if (InBeta)
		{
			if (hasWorkReturn != HasWorkReturn.NotApplicable && FixedBugs < Mathf.Floor(Bugs))
			{
				num = ((FixedBugs < Mathf.Floor(MaxBugFix(actor.GetTeam()))) ? 1 : 0);
				if (num != 0)
				{
					if (actualCheck && actor.isActiveAndEnabled)
					{
						AssignTaskIfNone(actor, secondary, false, false);
					}
					goto IL_00cf;
				}
			}
			else
			{
				num = 0;
			}
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			goto IL_00cf;
		}
		HasWorkReturn hasWorkReturn2 = HasWorkReturn.Finished;
		if (!HasFinishedArt || !HasFinishedCode)
		{
			hasWorkReturn2 = CheckAdequateSpecLevel(actor, secondary, false, actualCheck);
			if (hasWorkReturn2 == HasWorkReturn.True || hasWorkReturn2 == HasWorkReturn.Secondary)
			{
				if (actualCheck && actor.isActiveAndEnabled)
				{
					AssignTaskIfNone(actor, secondary, false, false);
				}
			}
			else if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
		}
		else if (actualCheck)
		{
			RemoveWorking(actor.employee);
		}
		return hasWorkReturn2;
		IL_00cf:
		if (num != 0)
		{
			return hasWorkReturn;
		}
		if (NewWorking.Count <= 0)
		{
			return HasWorkReturn.Finished;
		}
		return HasWorkReturn.NotApplicable;
	}

	private float MaxBugFix(Team team)
	{
		float num = ((contract == null && Bugs > BugLimitFactor) ? 0.9f : 1f);
		if (_lastMaxCodeSkill < 0f || Time.realtimeSinceStartup - _lastMaxCodeSkillTime > 3f)
		{
			_lastMaxCodeSkill = ((DevTeams.Count > 0) ? DevTeams.SelectNotNull(GameSettings.GetTeam).MaxSafe(MaxCodeSkill, 0f) : 1f);
			_lastMaxCodeSkillTime = Time.realtimeSinceStartup;
		}
		return Bugs * ContractBugFactor(_lastMaxCodeSkill) * num;
	}

	public float MaxCodeSkill(Team team)
	{
		float num = 0f;
		List<Actor> employeesDirect = team.GetEmployeesDirect();
		for (int i = 0; i < employeesDirect.Count; i++)
		{
			Employee employee = employeesDirect[i].employee;
			if (employee.IsRole(Employee.RoleBit.Programmer, employeesDirect[i].SecondaryWork))
			{
				num = Mathf.Max(num, employee.GetSkill(Employee.EmployeeRole.Programmer));
			}
		}
		return num;
	}

	public float ContractBugFactor(float input)
	{
		if (contract == null)
		{
			return input;
		}
		return Mathf.Lerp(input, 1f, 0.5f);
	}

	public void AddQuality(float effectiveness, float companySkill, bool realTime)
	{
		throw new NotImplementedException();
	}

	public static float GetBugSpeedDamp(float prog)
	{
		return 1f - prog * prog + 0.01f;
	}

	public static double FinalQualityCalc(double codeProgress, double artProgress, double codeQuality, double artQuality, SoftwareType type, IList<FeatureBase> features)
	{
		return FinalQualityCalc(codeProgress, artProgress, codeQuality, artQuality, SoftwareType.CodeArtRatio(features));
	}

	public static double FinalQualityCalc(double codeProgress, double artProgress, double codeQuality, double artQuality, float ratio)
	{
		double progress = (double)ratio * Utilities.Clamp01(codeProgress) + (double)(1f - ratio) * Utilities.Clamp01(artProgress);
		double quality = (double)ratio * codeQuality + (double)(1f - ratio) * artQuality;
		return FinalQualityCalc(progress, quality);
	}

	public static double FinalQualityCalc(double progress, double quality)
	{
		return progress * quality * (2.0 - progress + quality) / 2.0;
	}

	public float GetLastProgress()
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < Features.Length; i++)
		{
			num += (double)Features[i].LastIterationProg * Features[i].DevTime;
			num2 += Features[i].DevTime;
		}
		return (float)((num2 == 0.0) ? 0.0 : (num / num2));
	}

	public double GetSpQuality(bool all, bool art)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < Features.Length; i++)
		{
			if (!Features[i].OS)
			{
				if (all || art)
				{
					num += Features[i].Qual2 * Features[i].ADevTime;
					num2 += Features[i].ADevTime;
				}
				if (all || !art)
				{
					num += Features[i].Qual * Features[i].CDevTime;
					num2 += Features[i].CDevTime;
				}
			}
		}
		if (num2 != 0.0)
		{
			return num / num2;
		}
		return 0.0;
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		EverWorked.Add(actor.DID);
		LastWorked.Add(actor.DID);
		Team team = actor.GetTeam();
		if (team == null || float.IsNaN(effectiveness) || float.IsInfinity(effectiveness) || effectiveness < 0f)
		{
			return;
		}
		if (WorkDevTime < 0f)
		{
			RefreshWorkDevTime(InBeta);
		}
		float employeeCountEffect = SoftwareType.GetEmployeeCountEffect(Mathf.Max(1, NewWorking.Count), WorkDevTime, false);
		effectiveness *= employeeCountEffect * DifficultyValues.Difficulty.AlphaSpeedBonus * actor.LeaderEffectivenessFactor(2);
		effectiveness *= 1f + SourceControlBoost * 0.1f;
		if (InBeta)
		{
			float num = Mathf.Min(MaxBugFix(team), Bugs);
			if (num > 0f)
			{
				float fixedBugs = FixedBugs;
				FixedBugs = Mathf.Clamp(FixedBugs + Utilities.PerHour(effectiveness * actor.GetPCAddonBonus(Employee.EmployeeRole.Programmer), delta) * (4f / (float)GameSettings.DaysPerMonth) * GetBugSpeedDamp(FixedBugs / num), 0f, num);
				TotalNetworkUnits += FixedBugs - fixedBugs;
			}
		}
		else
		{
			if (HasFinished)
			{
				return;
			}
			float num2 = 1f;
			float num3 = 1f;
			float num4 = actor.employee.GetSkill(Employee.EmployeeRole.Programmer);
			float num5 = actor.employee.GetSkill(Employee.EmployeeRole.Artist);
			if (actor.employee.HasTrait(Employee.Trait.FirmwareInc))
			{
				num4 = HWSkillFactor(num4, actor);
				num5 = HWSkillFactor(num5, actor);
			}
			if (actor.employee.IsRole(Employee.RoleBit.Artist, secondary) && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary) && CodeArtRatio > 0f && CodeArtRatio < 1f && !HasFinishedArt && !HasFinishedCode)
			{
				float num6 = num4 + num5;
				if (num6 > 0f)
				{
					num2 = num4 / num6;
					num3 = num5 / num6;
				}
			}
			float num7 = Utilities.PerHour(SoftwareType.DesignRatio, delta);
			num7 /= (float)GameSettings.DaysPerMonth;
			FeatureProgress featureProgress = FindJob(actor, secondary, false, true);
			if (featureProgress != null && (!featureProgress.Valid(true) || !featureProgress.Valid(false)))
			{
				num2 = 1f;
				num3 = 1f;
			}
			bool flag = GetNetworkDealState() == NetworkDealState.Receiver;
			float num8 = (flag ? GetProgress() : 0f);
			bool flag2 = false;
			for (int i = 0; i < 2; i++)
			{
				bool flag3 = i == 0;
				if (flag3 && (CodeArtRatio == 0f || HasFinishedCode))
				{
					HasFinishedCode = true;
					continue;
				}
				if (!flag3 && (CodeArtRatio == 1f || HasFinishedArt))
				{
					HasFinishedArt = true;
					continue;
				}
				Employee.EmployeeRole role = (flag3 ? Employee.EmployeeRole.Programmer : Employee.EmployeeRole.Artist);
				if (actor.employee.IsRole(role, secondary))
				{
					float num9 = (flag3 ? num4 : num5);
					RecordSkill(role, num9, delta);
					float num10 = (flag3 ? num2 : num3);
					num10 *= actor.GetPCAddonBonus(role);
					float num11 = num9.MapRange(0f, 0.1f, 0.5f, 1f, true);
					float num12 = effectiveness * num7 * num11 * num10;
					double added = 0.0;
					if (featureProgress == null)
					{
						if (WorkAllFeatures(actor, num12, 1f, role, out added, true, num9.WeightOne(0.25f)))
						{
							RefreshWorkDevTime();
						}
					}
					else if (featureProgress.Valid(flag3))
					{
						bool change;
						double actuallyAdded;
						added = featureProgress.AddProgress(num12, role, actor.employee.GetSpecialization(role, featureProgress.Feature.Spec) == 3, out change, out actuallyAdded);
						if (change)
						{
							RefreshWorkDevTime();
						}
						if (!featureProgress.OS)
						{
							featureProgress.AddQuality(num9.WeightOne(0.25f), actuallyAdded, !flag3);
						}
					}
					if (added > 0.0)
					{
						flag2 = true;
						if (flag3)
						{
							Bugs += (float)(added * (double)MaxBugs * (double)num9.MapRange(0f, 1f, 1f, 0.25f) * (double)(1f - SourceControlBoost * 0.5f) * (double)BugRate);
						}
					}
				}
				if (!flag3 && !HasFinishedArt && AllDone(false, true, false))
				{
					HasFinishedArt = true;
				}
				if (flag3 && !HasFinishedCode && AllDone(false, false))
				{
					HasFinishedCode = true;
				}
			}
			if (flag && flag2)
			{
				TotalNetworkUnits += (GetProgress() - num8) * 100f;
			}
			if (!HasFinished && HasFinishedArt && HasFinishedCode)
			{
				HasFinished = true;
			}
		}
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		bool flag = act.employee.IsRole(Employee.RoleBit.Artist, secondary) && (InBeta || !HasFinishedArt);
		bool flag2 = act.employee.IsRole(Employee.RoleBit.Programmer, secondary) && (InBeta || !HasFinishedCode);
		if (flag && flag2)
		{
			if (!InBeta)
			{
				if (CodeArtRatio == 0f)
				{
					return Employee.EmployeeRole.Artist;
				}
				if (CodeArtRatio == 1f)
				{
					return Employee.EmployeeRole.Programmer;
				}
				return (Utilities.RandomValue > 0.5f) ? Employee.EmployeeRole.Programmer : Employee.EmployeeRole.Artist;
			}
			return Employee.EmployeeRole.Programmer;
		}
		if (flag)
		{
			return Employee.EmployeeRole.Artist;
		}
		if (flag2)
		{
			return Employee.EmployeeRole.Programmer;
		}
		return null;
	}

	private float LerpTowards(float a, float b, float t)
	{
		if (a == b)
		{
			return a;
		}
		if (b < a)
		{
			return Mathf.Max(b, a - t);
		}
		return Mathf.Min(b, a + t);
	}

	public override float GetWorkScore()
	{
		return (float)(InBeta ? (GetCodeArtProgress() * 0.5 + 0.5) : (GetCodeArtProgress() * 0.5));
	}

	public void UserPromote()
	{
		if (InBeta)
		{
			if (base.DistributionPlatform)
			{
				PromoteAction();
			}
			else if (GameSettings.Instance.PressBuildQueue.Contains(this))
			{
				WindowManager.Instance.ShowMessageBox("PressBuildNotReleased".Loc(), true, DialogWindow.DialogType.Question, PressCheck);
			}
			else
			{
				PressCheck();
			}
		}
		else
		{
			PromoteAction();
		}
	}

	public void PressCheck()
	{
		if (GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().Any((MarketingPlan x) => x.Type == MarketingPlan.TaskType.PressRelease && x.TargetItem == this))
		{
			WindowManager.Instance.ShowMessageBox("PressReleaseNotReleased".Loc(), true, DialogWindow.DialogType.Question, PriceCheck);
			return;
		}
		WindowManager.Instance.ShowMessageBox("ProductReleaseConfirmation".LocColor(this), true, DialogWindow.DialogType.Question, PriceCheck, "Release product");
	}

	public void PriceCheck()
	{
		double num = (base.AddOn ? AddonType.PerceivedValue(GetAddonFeatures(), GetFactors(), SWCategory, TechLevels) : SWCategory.PerceivedValue(GetFeatures(), TechLevels));
		float num2 = (base.AddOn ? GameSettings.Instance.simulation.GetIdealMarketPrice(AddonType) : GameSettings.Instance.simulation.GetIdealMarketPrice(SWCategory, SubscriptionBased));
		num2 *= (float)num;
		if (Price > num2 * 1.75f)
		{
			WindowManager.SpawnInputDialog(((num < 0.75) ? "PriceLowScoreWarning" : "PriceTooHighWarning").Loc(num2.Currency()), "Info".Loc(), Price.Currency(false), delegate(string price)
			{
				try
				{
					float num3 = ((float)Convert.ToDouble(price.Replace(",", ""))).FromCurrency();
					if (float.IsNaN(num3) || float.IsInfinity(num3))
					{
						throw new Exception();
					}
					Price = num3;
					PublisherCheck();
				}
				catch (Exception)
				{
					WindowManager.Instance.ShowMessageBox("InvalidAmount".Loc(), false, DialogWindow.DialogType.Error);
				}
			});
		}
		else
		{
			PublisherCheck();
		}
	}

	public double[] GetMarketQuality()
	{
		double[] array = new double[3];
		double[] array2 = new double[3];
		for (int i = 0; i < Features.Length; i++)
		{
			FeatureProgress featureProgress = Features[i];
			if (!featureProgress.OS)
			{
				double num = featureProgress.DevTime * (double)Mathf.Max(1, featureProgress.Feature.Level);
				double finalQuality = featureProgress.GetFinalQuality();
				for (int j = 0; j < 3; j++)
				{
					double num2 = num * featureProgress.Feature.Submarkets[j];
					array[j] += finalQuality * num2;
					array2[j] += num2;
				}
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (array2[k] > 0.0)
			{
				array[k] /= array2[k];
			}
			else
			{
				array[k] = 0.0;
			}
		}
		return array;
	}

	private void UpgradeMocks()
	{
		if (Type.OSSpecific && OSs != null)
		{
			for (int i = 0; i < OSs.Length; i++)
			{
				SoftwareProduct softwareProduct = OSs[i];
				if (softwareProduct.MockSucceeded != null)
				{
					OSs[i] = softwareProduct.MockSucceeded;
				}
			}
		}
		if (Needs == null)
		{
			return;
		}
		List<KeyValuePair<string, SoftwareProduct>> list = Needs.ToList();
		for (int j = 0; j < list.Count; j++)
		{
			KeyValuePair<string, SoftwareProduct> keyValuePair = list[j];
			if (keyValuePair.Value.MockSucceeded != null)
			{
				Needs[keyValuePair.Key] = keyValuePair.Value.MockSucceeded;
			}
		}
	}

	public void PublisherCheck()
	{
		if (Publishing != null && Publishing.ControlReleaseSchedule())
		{
			if (Mathf.Abs(SDateTime.GetMonths(ReleaseDate.Value, SDateTime.Now())) > 1f)
			{
				WindowManager.Instance.ShowMessageBox("PublisherDateContractWarning".Loc(), true, DialogWindow.DialogType.Warning, delegate
				{
					PromoteAction();
				});
			}
			else
			{
				PromoteAction();
			}
		}
		else
		{
			PromoteAction();
		}
	}

	private void AddRoyalties(IRoyaltyItem result)
	{
		foreach (KeyValuePair<Company, float> workRoyalty in GetWorkRoyalties())
		{
			SoftwareProduct softwareProduct;
			AddOnProduct addOnProduct;
			if ((softwareProduct = result as SoftwareProduct) != null)
			{
				NetworkMessaging.SendAddWorkRoyalty(workRoyalty.Key.ID, softwareProduct.ID, 0u, false, workRoyalty.Value, NetworkMessaging.MessageTarget.Everyone, 0);
			}
			else if ((addOnProduct = result as AddOnProduct) != null)
			{
				NetworkMessaging.SendAddWorkRoyalty(workRoyalty.Key.ID, addOnProduct.Parent.ID, addOnProduct.ID, false, workRoyalty.Value, NetworkMessaging.MessageTarget.Everyone, 0);
			}
		}
	}

	public override object PromoteAction()
	{
		if (InBeta)
		{
			UpgradeMocks();
			if (Type.OSSpecific && OSs != null && OSs.Any((SoftwareProduct x) => x.IsMock))
			{
				if (!AutoDev)
				{
					WindowManager.Instance.ShowMessageBox("MockOSError".Loc(), false, DialogWindow.DialogType.Error);
				}
				return null;
			}
			if (Needs.Values.Any((SoftwareProduct x) => x.IsMock))
			{
				if (!AutoDev)
				{
					WindowManager.Instance.ShowMessageBox("MockNeedError".Loc(), false, DialogWindow.DialogType.Error);
				}
				return null;
			}
			if (AddonWorkChildren.Any((SoftwareWorkItem x) => x is DesignDocument || !((SoftwareAlpha)x).InBeta))
			{
				if (!AutoDev)
				{
					WindowManager.Instance.ShowMessageBox("MockNeedError".Loc(), false, DialogWindow.DialogType.Error);
				}
				return null;
			}
			GameSettings.Instance.DeregisterServerItem(this);
			if (base.ActiveDeal != null && base.ActiveDeal.Incoming)
			{
				Kill();
				return null;
			}
			bool flag = false;
			if (Publishing != null && Publishing.ControlReleaseSchedule())
			{
				float num = Mathf.Abs(SDateTime.GetMonths(ReleaseDate.Value, SDateTime.Now()));
				if (num > 1f)
				{
					flag = true;
					SimulatedCompany simulatedCompany;
					if ((simulatedCompany = Publishing.Publisher as SimulatedCompany) != null)
					{
						simulatedCompany.PlayerRelationship = Mathf.Max(0f, simulatedCompany.PlayerRelationship - num * 0.05f);
					}
					MyCompany.ChangeBusinessRep((0f - num) / 4f, "Publisher");
					if (num > 3f)
					{
						Publishing.Suit();
						GameSettings.Lawsuit lawsuit = new GameSettings.Lawsuit(Publishing.Publisher, "PublishingLawsuit", 50000.0, 1f);
						lawsuit.Reasons.Add("ScheduleNotMet");
						GameSettings.Instance.LaunchSuit(lawsuit);
					}
				}
			}
			Features = Features.ToArray();
			if (base.AddOn)
			{
				double[] qualities = GetQualities();
				AddOnFeature[] addonFeatures = GetAddonFeatures();
				MarketingDone();
				AddOnProduct addOnProduct = new AddOnProduct(SoftwareName, SWID, AddonType, AddonParent, addonFeatures, GetFactors(), DevStart, SDateTime.Now(), Price, LossBreakdown.SumSafe((double x) => x) + Loss, GetMarketQuality(), MyCompany, PhysicalCopies, DistributionLoss, (uint)Mathf.Floor(base.Followers), qualities[0], qualities[1], qualities[2], qualities[3], base.WorkAddOn, HardwareDesign);
				GameSettings.Instance.MoveStorage(this, addOnProduct);
				PrintJob job = GameSettings.Instance.GetPrintJob(this);
				if (job != null)
				{
					List<KeyValuePair<AssemblyLine, bool>> list = null;
					if (job.Hardware)
					{
						list = (from x in GameSettings.Instance.GetAssemblyLines()
							where x.HasTask(job)
							select new KeyValuePair<AssemblyLine, bool>(x, x.PlayerAssigned.Contains(job))).ToList();
					}
					GameSettings.Instance.CancelPrintOrder(job, false);
					PrintJob printJob = new PrintJob(addOnProduct, job.Priority);
					printJob.Limit = job.Limit;
					printJob.Maximum = job.Maximum;
					GameSettings.Instance.AddPrintOrder(printJob, false);
					if (list != null)
					{
						for (int num2 = 0; num2 < list.Count; num2++)
						{
							list[num2].Key.AddTask(printJob, list[num2].Value);
						}
					}
				}
				GameSettings.Instance.MyCompany.AddOns.Add(addOnProduct);
				GameSettings.Instance.simulation.AddAddOn(addOnProduct);
				HUD.Instance.distributionWindow.RefreshOrders();
				HUD.Instance.ApplyProductWindowFilters();
				int bugs = (int)Mathf.Max(0f, Bugs - FixedBugs);
				addOnProduct.SendNetwork();
				AddRoyalties(addOnProduct);
				AddonParent.AddBugs(bugs);
				SupportWork supportWork = GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().FirstOrDefault((SupportWork z) => z.TargetProduct == AddonParent);
				Kill();
				Final = addOnProduct;
				GameSettings.Instance.NetworkPrintOrders.Values.ForEachEnum(delegate(NetworkPrintDeal x)
				{
					x.TestUpgrade();
				});
				AddOnProduct.HandleNews(addOnProduct, !AutoDev);
				return new object[2] { supportWork, addOnProduct };
			}
			if (contract == null)
			{
				double[] qualities2 = GetQualities();
				FeatureBase[] features = GetFeatures();
				LossBreakdown[0] += Loss;
				SoftwareFramework framework = Framework;
				float frameworkRoyalty = FrameworkRoyalty;
				if (CreateFramework != null)
				{
					framework = GameSettings.Instance.simulation.CreateFramework(CreateFramework, MyCompany, Type, SWCategory, Features, TechLevels, SDateTime.Now());
					frameworkRoyalty = 0f;
				}
				MarketingDone();
				if (base.DistributionPlatform && GameSettings.Instance.MyCompany.Distribution != null)
				{
					SWID = GameSettings.Instance.MyCompany.Distribution.Software.ID;
				}
				SoftwareProduct softwareProduct = new SoftwareProduct(SoftwareName, Type, SWCategory, OSs, qualities2[0], qualities2[1], qualities2[2], qualities2[3], GetMarketQuality(), CreativityScore, Price, SubscriptionBased, Submarkets, DevStart, SDateTime.Now(), (int)Mathf.Max(0f, Bugs - FixedBugs), InHouse, MyCompany, SequelTo, (Mock != null) ? Mock.ID : (SWID ?? GameSettings.Instance.simulation.GetID()), LossBreakdown, features, TechLevels, Server, (uint)Math.Floor(base.Followers), framework, frameworkRoyalty, Tools, null, HardwareDesign);
				softwareProduct.SetAddonID(AddonIDOffset);
				if (!base.DistributionPlatform)
				{
					softwareProduct.SendNetwork();
					if (Publishing != null)
					{
						float num3 = (float)GetSpProgress(true, true);
						if (Publishing.Deals.Contains("Funding") && num3 < 0.15f)
						{
							flag = true;
							SimulatedCompany simulatedCompany2;
							if ((simulatedCompany2 = Publishing.Publisher as SimulatedCompany) != null)
							{
								simulatedCompany2.PlayerRelationship = Mathf.Max(0f, simulatedCompany2.PlayerRelationship - (1f - num3) * 0.25f);
							}
							Publishing.Suit();
							GameSettings.Lawsuit lawsuit2 = new GameSettings.Lawsuit(Publishing.Publisher, "PublishingLawsuit", Publishing.Funding, 1f);
							lawsuit2.Reasons.Add("SubparProjectFund");
							GameSettings.Instance.LaunchSuit(lawsuit2);
						}
						SimulatedCompany simulatedCompany3;
						if (!flag && (simulatedCompany3 = Publishing.Publisher as SimulatedCompany) != null)
						{
							simulatedCompany3.PlayerRelationship = Mathf.Min(1f, simulatedCompany3.PlayerRelationship + num3 * 0.25f);
						}
						softwareProduct.Publishing = Publishing;
						Publishing.ProductTarget = softwareProduct;
						Publishing.WorkTarget = null;
						Publishing = null;
						softwareProduct.Publishing.SendNetwork();
					}
					softwareProduct.PhysicalCopies += PhysicalCopies;
					GameSettings.Instance.MoveStorage(this, softwareProduct);
					PrintJob job2 = GameSettings.Instance.GetPrintJob(this);
					if (job2 != null)
					{
						List<KeyValuePair<AssemblyLine, bool>> list2 = null;
						if (job2.Hardware)
						{
							list2 = (from x in GameSettings.Instance.GetAssemblyLines()
								where x.HasTask(job2)
								select new KeyValuePair<AssemblyLine, bool>(x, x.PlayerAssigned.Contains(job2))).ToList();
						}
						GameSettings.Instance.CancelPrintOrder(job2, false);
						PrintJob printJob2 = new PrintJob(softwareProduct, job2.Priority);
						printJob2.Limit = job2.Limit;
						printJob2.Maximum = job2.Maximum;
						GameSettings.Instance.AddPrintOrder(printJob2, false);
						if (list2 != null)
						{
							for (int num4 = 0; num4 < list2.Count; num4++)
							{
								list2[num4].Key.AddTask(printJob2, list2[num4].Value);
							}
						}
					}
				}
				if (base.DistributionPlatform)
				{
					if (GameSettings.Instance.MyCompany.Distribution == null)
					{
						DistributionPlatform distributionPlatform = MarketSimulation.Active.CreatePlatform(GameSettings.Instance.MyCompany, softwareProduct, DigitalDistributionWindow.GetCut());
						GameSettings.Instance.MyCompany.Distribution = distributionPlatform;
						GameSettings.Instance.RegisterWithServer(Server, distributionPlatform);
					}
					else
					{
						DigitalDistributionWindow.CancelAllJobs();
						MarketSimulation.Active.UpdatePlatform(GameSettings.Instance.MyCompany.Distribution, softwareProduct);
					}
					HUD.Instance.digitalDistributionWindow.UpdateStoreButton();
					HUD.Instance.digitalDistributionWindow.UpdateInfo();
				}
				else
				{
					GameSettings.Instance.MyCompany.Products.Add(softwareProduct);
					if (Mock != null)
					{
						GameSettings.Instance.simulation.UpgradeFromMock(softwareProduct);
					}
					else
					{
						GameSettings.Instance.simulation.AddProduct(softwareProduct, false);
					}
					HUD.Instance.distributionWindow.RefreshOrders();
					HUD.Instance.ApplyProductWindowFilters();
					AddRoyalties(softwareProduct);
				}
				SupportWork supportWork2 = new SupportWork(softwareProduct, (guiItem == null) ? (-1) : guiItem.transform.GetSiblingIndex());
				if (!supportWork2.Done)
				{
					if (!AutoDev)
					{
						supportWork2.AddDevTeams(GameSettings.Instance.GetDefaultTeams("Support", DevTeams));
					}
					supportWork2.Collapsed = Collapsed;
					GameSettings.Instance.MyCompany.AddWorkItem(supportWork2);
				}
				if (AddonWorkChildren.Count > 0)
				{
					List<AddOnProduct> list3 = new List<AddOnProduct>();
					foreach (SoftwareWorkItem addonWorkChild in AddonWorkChildren)
					{
						SoftwareAlpha softwareAlpha = addonWorkChild as SoftwareAlpha;
						if (softwareAlpha.InBeta)
						{
							softwareAlpha.AddonParent = softwareProduct;
							object[] array = softwareAlpha.PromoteAction() as object[];
							if (array != null && array.Length > 1)
							{
								AddOnProduct item = array[1] as AddOnProduct;
								list3.Add(item);
							}
							else
							{
								softwareAlpha.Kill();
							}
						}
					}
					if (list3.Count > 0)
					{
						softwareProduct.ForcedAddons = list3.ToArray();
						softwareProduct.UpdateForcedAddonQualityEffect();
					}
				}
				bool owner = true;
				if (LeadWork != null)
				{
					foreach (KeyValuePair<Employee, float> item2 in LeadWork.OrderByDescending((KeyValuePair<Employee, float> x) => x.Value))
					{
						item2.Key.FinishLeadProject(softwareProduct, item2.Value * DesignProgress, owner, Utilities.RNG.Next());
						owner = false;
					}
				}
				Kill();
				Final = softwareProduct;
				GameSettings.Instance.NetworkPrintOrders.Values.ForEachEnum(delegate(NetworkPrintDeal x)
				{
					x.TestUpgrade();
				});
				if (!base.DistributionPlatform)
				{
					SoftwareProduct.HandleNews(softwareProduct, !AutoDev);
				}
				softwareProduct.RunReleaseScripts();
				SWID = softwareProduct.ID;
				NetworkSchedule(true);
				return new object[2] { supportWork2, softwareProduct };
			}
			GameSettings.Instance.RegisterStat("ContractsCompleted", 1f);
			double[] qualities3 = GetQualities();
			double num5 = qualities3[2] * (double)CodeArtRatio + qualities3[3] * (double)(1f - CodeArtRatio);
			double num6 = GetCodeArtProgress() / (double)contract.MinProg;
			int daysFlat = SDateTime.GetDaysFlat(DevStart, SDateTime.Now());
			int bugs2 = (int)Mathf.Clamp(Bugs - FixedBugs, 0f, DevTime * BugLimitFactor);
			ContractResult value = new ContractResult(contract, false, bugs2, (float)num5, daysFlat, (float)num6);
			if (LeadWork != null)
			{
				foreach (KeyValuePair<Employee, float> item3 in LeadWork)
				{
					double num7 = (double)(item3.Value * DevTime) * Math.Max(1.0, GetCodeArtProgress() * 2.0);
					item3.Key.RevealCreativity((float)((num7 > 1.0) ? num7.MapRange(1.0, 16.0, 0.10000000149011612, 0.3400000035762787, true) : num7.MapRange(0.0, 1.0, 0.0, 0.10000000149011612, true)));
				}
			}
			HUD.Instance.contractWindow.ContractResults.Items.Add(value);
			Kill();
		}
		else
		{
			if (GetCodeArtProgress() > 0.0)
			{
				if (!AutoDev)
				{
					WindowManager.Instance.ShowMessageBox("AlphaPromoteConfirmation".Loc(), true, DialogWindow.DialogType.Question, StartBeta, "Promote from alpha");
				}
				else
				{
					StartBeta();
				}
			}
			else if (!AutoDev)
			{
				WindowManager.Instance.ShowMessageBox("AlphaNoProgress".Loc(), false, DialogWindow.DialogType.Error);
			}
			if (WorkItemID != null)
			{
				NetworkManager.Instance.TradeController.CancelAllTradesFor(WorkItemID);
			}
		}
		return null;
	}

	private void StartBeta()
	{
		Bugs = Mathf.Clamp(Bugs, 0f, MaxBugs);
		if (GetWorkOwner().IsLocalPlayer && contract == null && Mock == null)
		{
			CreateMock();
		}
		if (!AutoDev && contract == null && base.ActiveDeal == null)
		{
			HelpTipPanel.Show(HintController.Hints.HintProductRelease, HUD.Instance.comingReleaseWindow.Window.SpawnFrom);
		}
		Bugs *= 1f - GetBugReviewFactor();
		FeatureProgress featureProgress = Features.FirstOrDefault((FeatureProgress x) => x.OS);
		if (featureProgress != null)
		{
			Bugs += (float)((1.0 - featureProgress.GetOverallProgress()) * 0.25 * (double)MaxBugs);
		}
		InBeta = true;
		RefreshWorkDevTime(InBeta);
		if (!(guiItem != null))
		{
			return;
		}
		guiItem.InitButtons();
		if (HUD.Instance.GroupTaskManager.Grouping == WorkGroupManager.GroupType.Project)
		{
			SubWorkItem item = HUD.Instance.GroupTaskManager.GetItem(this).Item2;
			if (item != null)
			{
				item.MainLabel.text = (item.Label = GetGroupProjectLabel());
			}
		}
	}

	public override float StressMultiplier()
	{
		return 1f;
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (Child != null)
		{
			Child.Kill(wasCancelled);
		}
		if (Mock != null && Mock.MockSucceeded == null)
		{
			GameSettings.Instance.simulation.RemoveMock(Mock);
			foreach (SoftwareWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().ToList())
			{
				if (item.Needs.ContainsValue(Mock))
				{
					item.Kill(true);
				}
				else if (item.Type.OSSpecific && item.OSs != null && item.OSs.Contains(Mock))
				{
					HashSet<SoftwareProduct> hashSet = item.OSs.ToHashSet();
					hashSet.Remove(Mock);
					if (hashSet.Count > 0)
					{
						item.OSs = hashSet.ToArray();
					}
					else
					{
						item.Kill(true);
					}
				}
			}
			foreach (SoftwarePort item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().ToList())
			{
				SoftwarePort.PortProgress portProgress = item2.OSs.FirstOrDefault((SoftwarePort.PortProgress x) => x.Product == Mock);
				if (portProgress != null)
				{
					item2.OSs.Remove(portProgress);
					item2.RefreshCurrent();
				}
			}
		}
		List<MarketingPlan> list = (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where x.TargetItem == this
			select x).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			list[num].Kill();
		}
		if (HUD.Instance.marketingWindow.TargetWork == this)
		{
			HUD.Instance.marketingWindow.Window.Close();
		}
		GameSettings.Instance.PressBuildQueue.Remove(this);
		GameSettings.Instance.FollowerSimulation.Remove(this);
		FixAutoDev();
		GameSettings.Instance.DeregisterServerItem(this);
		base.Kill(wasCancelled);
	}

	protected override void Cancelled()
	{
		base.Cancelled();
		if (base.Followers > 0f && ReleaseDate.HasValue)
		{
			GameSettings.Instance.MyCompany.AddFans(-Mathf.CeilToInt(base.Followers * 0.75f), SWCategory);
		}
		GameSettings.Instance.CancelPrintOrder(this, false);
		GameSettings.Instance.CancelPrintNetworkDeals(this);
		HUD.Instance.distributionWindow.RefreshOrders();
		if (contract != null)
		{
			ContractResult value = new ContractResult(contract, true, 0, 0f, SDateTime.GetDaysFlat(DevStart, SDateTime.Now()), 0f);
			HUD.Instance.contractWindow.ContractResults.Items.Add(value);
		}
		double codeArtProgress = GetCodeArtProgress();
		if (base.ActiveDeal != null && codeArtProgress == 0.0)
		{
			HUD.Instance.dealWindow.CancelDeal(base.ActiveDeal, false);
			base.ActiveDeal = null;
		}
	}

	public float GetLoadRequirement()
	{
		float num = 0f;
		List<Team> devTeams = GetDevTeams();
		for (int i = 0; i < devTeams.Count; i++)
		{
			num += (float)devTeams[i].Count * (DevTime / 24f);
		}
		return num;
	}

	public void HandleLoad(float load)
	{
		SourceControlBoost = load;
	}

	public new string GetDescription()
	{
		return base.Name;
	}

	public override string GetSoftwareWorkType()
	{
		if (!InBeta)
		{
			return "Alpha";
		}
		return "Beta";
	}

	public void SerializeServer(string name)
	{
		if (name == null)
		{
			SourceControlBoost = 0f;
		}
		Server2 = name;
	}

	public override string GetWorkTypeName()
	{
		return "Development";
	}

	public bool CancelOnUnload()
	{
		return true;
	}

	public override string HightlightButton()
	{
		if (!InBeta && HasFinished)
		{
			return "Promote";
		}
		if (!InHouse && GetNetworkDealState() != NetworkDealState.Receiver && base.Followers <= 0f && contract == null && deal == 0 && !base.DistributionPlatform)
		{
			if (PublisherDeal.HasDeal(this, "Marketing"))
			{
				return null;
			}
			if (GameSettings.Instance.PressBuildQueue.Contains(this))
			{
				return null;
			}
			foreach (WorkItem workItem in GameSettings.Instance.MyCompany.WorkItems)
			{
				MarketingPlan marketingPlan;
				if ((marketingPlan = workItem as MarketingPlan) != null && marketingPlan.Type == MarketingPlan.TaskType.PressRelease && marketingPlan.TargetItem == this)
				{
					return null;
				}
			}
			return "Market";
		}
		return null;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		if (InBeta)
		{
			return Actor.WorkParticle.Binary;
		}
		FeatureProgress value;
		if (NewWorking.TryGetValue(actor.employee, out value) && value != null)
		{
			bool flag = value.ADevTime > 0.0 && !value.ArtDone && actor.employee.IsRole(Employee.RoleBit.Artist, secondary);
			bool flag2 = value.CDevTime > 0.0 && !value.CodeDone && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary);
			if (flag && flag2)
			{
				if (UnityEngine.Random.Range(0, 2) != 0)
				{
					return Actor.WorkParticle.Binary;
				}
				return Actor.WorkParticle.Shapes;
			}
			if (!flag)
			{
				return Actor.WorkParticle.Binary;
			}
			return Actor.WorkParticle.Shapes;
		}
		bool flag3 = CodeArtRatio < 1f && !HasFinishedArt && actor.employee.IsRole(Employee.RoleBit.Artist, secondary);
		bool flag4 = CodeArtRatio > 0f && !HasFinishedCode && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary);
		if (flag3 && flag4)
		{
			if (UnityEngine.Random.Range(0, 2) != 0)
			{
				return Actor.WorkParticle.Binary;
			}
			return Actor.WorkParticle.Shapes;
		}
		if (!flag3)
		{
			return Actor.WorkParticle.Binary;
		}
		return Actor.WorkParticle.Shapes;
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		bool playerIP = contract == null && base.ActiveDeal == null;
		bool canMarket = playerIP && !InHouse && !PublisherDeal.HasDeal(this, "Marketing") && !base.DistributionPlatform;
		if (state == NetworkDealState.Sender)
		{
			if (canMarket)
			{
				yield return new KeyValuePair<string, Action>("Market", delegate
				{
					HUD.Instance.marketingWindow.Show(this);
				});
			}
			if ((InBeta || Manufacturing.IsHardware()) && playerIP && !base.DistributionPlatform && GameSettings.HasCompletedOrInMission("Printing"))
			{
				yield return new KeyValuePair<string, Action>("Print", StartPrint);
			}
			yield return new KeyValuePair<string, Action>("FinishDeal", delegate
			{
				NetworkCancel(true);
			});
			yield return new KeyValuePair<string, Action>("CancelDeal", delegate
			{
				NetworkCancel(false);
			});
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign((contract != null) ? "ContractDevelopment" : "Development", base.CheckCompetency);
		});
		if (state == NetworkDealState.Receiver)
		{
			if (!InBeta)
			{
				yield return new KeyValuePair<string, Action>("Review", delegate
				{
					HUD.Instance.startReviewWindow.Show(this);
				});
			}
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
			yield break;
		}
		if (canMarket)
		{
			yield return new KeyValuePair<string, Action>("Market", delegate
			{
				HUD.Instance.marketingWindow.Show(this);
			});
		}
		if ((InBeta || Manufacturing.IsHardware()) && playerIP && !base.DistributionPlatform && GameSettings.HasCompletedOrInMission("Printing"))
		{
			yield return new KeyValuePair<string, Action>("Print", StartPrint);
		}
		if (!InBeta)
		{
			yield return new KeyValuePair<string, Action>("Review", delegate
			{
				HUD.Instance.startReviewWindow.Show(this);
			});
		}
		if (playerIP && (!base.WorkAddOn || !InBeta))
		{
			yield return new KeyValuePair<string, Action>(InBeta ? "Release" : "Promote", UserPromote);
		}
		if (!playerIP && !base.WorkAddOn && InBeta)
		{
			yield return new KeyValuePair<string, Action>("Finish", UserPromote);
		}
		if (!base.WorkAddOn && (contract != null || GameSettings.HasCompletedMission("Mission05")))
		{
			yield return new KeyValuePair<string, Action>("Cancel", delegate
			{
				WindowManager.Instance.ShowMessageBox("WorkItemCancelConf".LocColor(this), true, DialogWindow.DialogType.Warning, delegate
				{
					Kill(true);
				}, "Cancel work");
			});
		}
		if (!playerIP && !InBeta)
		{
			yield return new KeyValuePair<string, Action>("Promote", UserPromote);
		}
	}

	public void StartPrint()
	{
		if (GameSettings.Instance.CanOutsourcePrint(Manufacturing))
		{
			WindowManager.Instance.ShowMessageBox("OutsourcePrintPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				HUD.Instance.copyOrderWindow.Show(true, this);
			}, null, StartSubPrint);
		}
		else
		{
			StartSubPrint();
		}
	}

	public void StartSubPrint()
	{
		if (GameSettings.Instance.GetPrintJob(this) != null)
		{
			return;
		}
		if (!Manufacturing.IsHardware() && GameSettings.Instance.ProductPrinters.Count((ProductPrinter x) => x.Type == ProductPrinter.PrinterType.Product) == 0)
		{
			WindowManager.Instance.ShowMessageBox("NoPrintersWarning".Loc(MarketSimulation.PhysicalCopyPrice.Currency()), false, DialogWindow.DialogType.Question, delegate
			{
				PrintJob printJob2 = new PrintJob(this);
				GameSettings.Instance.AddPrintOrder(printJob2, false);
				HUD.Instance.distributionWindow.Show(printJob2);
			});
		}
		else
		{
			PrintJob printJob = new PrintJob(this);
			GameSettings.Instance.AddPrintOrder(printJob, false);
			if (printJob.Hardware)
			{
				GameSettings.Instance.PromptPrintAssignment(printJob);
			}
			HUD.Instance.distributionWindow.Show(printJob);
		}
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		GetNeeds(needs, false);
	}

	public override string GetTypeName()
	{
		return "SoftwareAlpha";
	}

	public override string GetGroupType()
	{
		if (!InBeta)
		{
			return "Alpha";
		}
		return "Beta";
	}

	public string GetName()
	{
		return SoftwareName;
	}

	public string GetIdentifyingName()
	{
		return SoftwareName;
	}

	public string GetCompanyName()
	{
		return GetWorkOwner().Name;
	}

	public float GetPrintPrice(bool isAI = false)
	{
		if (!Manufacturing.IsHardware())
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
		if (base.AddOn)
		{
			uint num = AddonType.PerUser - (uint)(AddonType.Forced.HasValue ? 1 : 0);
			if (AddonParent != null)
			{
				return (uint)(AddonParent.Userbase * num);
			}
			SoftwareAlpha softwareAlpha;
			if ((softwareAlpha = AddonWorkParent as SoftwareAlpha) != null)
			{
				return softwareAlpha.GetReach() * num;
			}
			return Type.GetReach(SWCategory, AddonWorkParent.OSs) * num;
		}
		return Type.GetReach(SWCategory, OSs);
	}

	public float GetRealQuality()
	{
		return 0.5f;
	}

	public uint GetFollowers()
	{
		return (uint)base.Followers;
	}

	public override string GetSubjectName()
	{
		return SoftwareName;
	}

	public void ReviewAndIterate()
	{
		float num = (float)(ReviewWork.GetOptimalReviews(this, null) * ReviewWork.GetReviewsPerReviewer(this, null)) * ReviewWork.StandardCost;
		GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Bills, true, "Reviews");
		AddLoss(num);
		AddReviewScore(1f);
		Dictionary<string, Dictionary<string, float>> dictionary = new Dictionary<string, Dictionary<string, float>>
		{
			{
				"Art",
				new Dictionary<string, float>()
			},
			{
				"Code",
				new Dictionary<string, float>()
			}
		};
		FeatureProgress[] features = Features;
		foreach (FeatureProgress featureProgress in features)
		{
			if (!featureProgress.OS)
			{
				if (featureProgress.ADevTime > 0.0)
				{
					dictionary["Art"][featureProgress.Feature.Spec] = 1f;
				}
				if (featureProgress.CDevTime > 0.0)
				{
					dictionary["Code"][featureProgress.Feature.Spec] = 1f;
				}
			}
		}
		FeatureProgress[] array = SoftwareWorkItem.GenerateProgress(SWCategory, MyCompany, Features, TechLevels, SequelTo, new ReviewWindow.ReviewData(dictionary, null, SDateTime.Now(), 1f, null, 1f));
		for (int j = 0; j < array.Length; j++)
		{
			array[j].Progress = array[j].DevTime;
		}
		DesignDocument.FinishIteration(this, array, 1f, null);
	}

	protected override IEnumerable<Employee.EmployeeRole> CompCheck()
	{
		if (!InBeta && !HasFinished)
		{
			yield return Employee.EmployeeRole.Programmer;
			yield return Employee.EmployeeRole.Artist;
		}
	}

	public override void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
		base.AddLoss(cost, type, immediate);
		if (type == SoftwareProduct.LossType.Copies)
		{
			lock (this)
			{
				DistributionLoss += cost;
			}
		}
	}

	public override string GetTutorial()
	{
		if (contract != null)
		{
			return base.GetTutorial();
		}
		return "Alpha work";
	}

	public override void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
		Tools.AddUp(tool, cost);
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
		if (!base.AddOn)
		{
			return null;
		}
		return GetFactors();
	}

	public IProductOrder PromoteHardware(uint copies)
	{
		return ManufactureOrder.PromoteProduct(this, copies);
	}

	public override void OnNetworkComplete(Stream st)
	{
		if (!InBeta)
		{
			st.ExecuteArray(delegate(Stream s)
			{
				uint id = s.ReadUInt();
				double artTargetQual = s.ReadDouble();
				double codeTargetQual = s.ReadDouble();
				FeatureProgress featureProgress = Features.FirstOrDefault((FeatureProgress x) => x.Feature.ID == id);
				if (featureProgress != null)
				{
					featureProgress.ArtTargetQual = artTargetQual;
					featureProgress.CodeTargetQual = codeTargetQual;
				}
			});
		}
		ReadProgress(st, false);
	}

	public void ReadProgress(Stream st, bool forceReadCompleteData)
	{
		Bugs = st.ReadFloat();
		FixedBugs = st.ReadFloat();
		if (!(!InBeta || forceReadCompleteData))
		{
			return;
		}
		ReviewsDone = st.ReadInt();
		ReviewScore = st.ReadFloat();
		st.ExecuteArray(delegate(Stream s)
		{
			uint id = s.ReadUInt();
			double progress = s.ReadDouble();
			double artProgress = s.ReadDouble();
			double qual = s.ReadDouble();
			double qual2 = s.ReadDouble();
			FeatureProgress featureProgress = Features.FirstOrDefault((FeatureProgress x) => x.Feature.ID == id);
			if (featureProgress != null)
			{
				featureProgress.Progress = progress;
				featureProgress.ArtProgress = artProgress;
				featureProgress.Qual = qual;
				featureProgress.Qual2 = qual2;
				featureProgress.UpdateStatus(true);
			}
		});
		if (!HasFinishedArt && AllDone(false, true, false))
		{
			HasFinishedArt = true;
		}
		if (!HasFinishedCode && AllDone(false, false))
		{
			HasFinishedCode = true;
		}
		if (!HasFinished && HasFinishedArt && HasFinishedCode)
		{
			HasFinished = true;
		}
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		if (success)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (!InBeta)
				{
					memoryStream.WriteArray(Features, delegate(Stream s, FeatureProgress x)
					{
						s.WriteUInt(x.Feature.ID);
						s.WriteDouble(x.ArtTargetQual);
						s.WriteDouble(x.CodeTargetQual);
					});
				}
				memoryStream.WriteFloat(Bugs);
				memoryStream.WriteFloat(FixedBugs);
				if (!InBeta)
				{
					memoryStream.WriteInt(ReviewsDone);
					memoryStream.WriteFloat(ReviewScore);
					memoryStream.WriteArray(Features, delegate(Stream s, FeatureProgress x)
					{
						s.WriteUInt(x.Feature.ID);
						s.WriteDouble(x.Progress);
						s.WriteDouble(x.ArtProgress);
						s.WriteDouble(x.Qual);
						s.WriteDouble(x.Qual2);
					});
				}
				return memoryStream.ToArray();
			}
		}
		return null;
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteStringUTF8(SoftwareName);
		st.WriteBool(InBeta);
		st.WriteUInt(Type.ID);
		st.WriteUInt(SWCategory.ID);
		st.WriteUInt(base.AddOn ? AddonType.ID : 0u);
		st.WriteUInt(base.AddOn ? AddonParent.ID : 0u);
		st.WriteArray(Needs, delegate(Stream s, KeyValuePair<string, SoftwareProduct> x)
		{
			st.WriteStringUTF8(x.Key);
			st.WriteUInt(x.Value.ID);
		});
		st.WriteArray(OSs, delegate(Stream s, SoftwareProduct x)
		{
			s.WriteUInt(x.ID);
		});
		st.WriteFloat(Price);
		st.WriteBool(SubscriptionBased);
		st.WriteArray(Submarkets, delegate(Stream s, double x)
		{
			s.WriteDouble(x);
		});
		DevStart.WriteData(st);
		Stream stream = st;
		SoftwareProduct sequelTo = SequelTo;
		stream.WriteUInt((sequelTo != null) ? sequelTo.ID : 0u);
		st.WriteBool(InHouse);
		st.WriteDouble(Loss);
		st.WriteArray(TechLevels, delegate(Stream s, KeyValuePair<string, TechLevel> x)
		{
			st.WriteStringUTF8(x.Key);
			st.WriteInt(x.Value.Year);
		});
		Stream stream2 = st;
		SoftwareFramework framework = Framework;
		stream2.WriteUInt((framework != null) ? framework.ID : 0u);
		st.WriteStringUTF8(CreateFramework);
		st.WriteArray(Features, delegate(Stream s, FeatureProgress x)
		{
			s.WriteUInt(x.Feature.ID);
			s.WriteUInt(x.Factor);
			s.WriteDouble(x.ArtTargetQual);
			s.WriteDouble(x.CodeTargetQual);
		});
		st.WriteArray(Tools, delegate(Stream s, KeyValuePair<SoftwareProduct, float> x)
		{
			s.WriteUInt(x.Key.ID);
		});
		st.WriteDouble(CreativityScore);
		st.WriteInt(MaxBugs);
		st.WriteFloat(BugRate);
		st.WriteFloat(Bugs);
		st.WriteFloat(Bugs);
		st.WriteFloat(FixedBugs);
		st.WriteInt(ReviewsDone);
		st.WriteFloat(ReviewScore);
		st.WriteArray(Features, delegate(Stream s, FeatureProgress x)
		{
			s.WriteUInt(x.Feature.ID);
			s.WriteDouble(x.Progress);
			s.WriteDouble(x.ArtProgress);
			s.WriteDouble(x.Qual);
			s.WriteDouble(x.Qual2);
		});
	}

	public override bool IsDoneForNetworkDeal()
	{
		if (!InBeta)
		{
			return HasFinished;
		}
		return false;
	}

	public override void ReceiveNetworkDealSync(Stream st)
	{
		base.ReceiveNetworkDealSync(st);
		ReviewsDone = st.ReadInt();
		ReviewScore = st.ReadFloat();
	}

	public override byte[] SubSendNetworkDealSync()
	{
		byte[] value = base.SubSendNetworkDealSync();
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteBytes(value);
			memoryStream.WriteInt(ReviewsDone);
			memoryStream.WriteFloat(ReviewScore);
			return memoryStream.ToArray();
		}
	}

	public override void InitNetworkDealAccepted()
	{
		if (Child != null)
		{
			Child.Kill(true);
		}
	}

	public override string GetDetailedTypeName()
	{
		if (!InBeta)
		{
			return "Alpha".Loc();
		}
		return "Beta".Loc();
	}

	public override string CollapseLabel()
	{
		string text = "";
		if (contract != null)
		{
			text = contract.GetStatus(DevStart) + " - ";
		}
		return text + (InBeta ? GetProgressBeta(Mathf.FloorToInt(Bugs), (int)FixedBugs) : GetSpProgress(true, false).ToPercent());
	}
}
