using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
public class MarketingPlan : WorkItem
{
	public enum TaskType
	{
		PostMarket = 0,
		Hype = 1,
		PressRelease = 2
	}

	[Flags]
	public enum PressOption
	{
		None = 0,
		Text = 1,
		Image = 2,
		Video = 4,
		All = 7
	}

	public const int PressOptionCount = 3;

	public float[] Progress;

	public float LastProgress = -1f;

	public float MaxBudget;

	public float Spent;

	public float LastSpent;

	public IMarketable TargetProduct;

	public SoftwareWorkItem TargetItem;

	public string FakeTarget;

	public readonly bool PreMarketing;

	public static float PostMarketingPrice = 50000f;

	public TaskType Type;

	public PressOption PressOptions;

	public override Color BackColor
	{
		get
		{
			return new Color(0.75f, 0f, 0f);
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			if (Type != TaskType.PostMarket)
			{
				return Type == TaskType.PressRelease;
			}
			return true;
		}
	}

	public override string UnitName
	{
		get
		{
			if (Type != TaskType.PostMarket)
			{
				return "Percent";
			}
			return "PostMarketPrice";
		}
	}

	public override uint MaxUnits
	{
		get
		{
			if (Type != TaskType.PostMarket)
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
			return 4;
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return Type == TaskType.PressRelease;
		}
	}

	public override IReferenceFix FixReferences()
	{
		if (TargetProduct != null)
		{
			string name = TargetProduct.GetName();
			TargetProduct = (IMarketable)TargetProduct.FixReferences();
			if (TargetProduct == null)
			{
				SelectorController.MissingDataHost.Add(name);
				Kill();
				return null;
			}
		}
		return base.FixReferences();
	}

	public MarketingPlan(string name)
		: base(name, null, 0u, null)
	{
	}

	public MarketingPlan()
	{
	}

	public MarketingPlan(float budget, IMarketable targetProduct, uint networkID = 0u, NetworkDeal networkDeal = null)
		: base(targetProduct.GetName(), null, networkID, networkDeal)
	{
		Type = TaskType.PostMarket;
		Progress = new float[1];
		MaxBudget = budget;
		TargetProduct = targetProduct;
		PreMarketing = false;
		CorrectName();
		RunScripts(targetProduct.GetFeatures(), false, false);
	}

	public MarketingPlan(string fakeTarget, PressOption options, uint networkID, NetworkDeal networkDeal)
		: base(fakeTarget, null, networkID, networkDeal)
	{
		Type = TaskType.PressRelease;
		PressOptions = options;
		Progress = new float[CountOptions()];
		FakeTarget = fakeTarget;
		PreMarketing = true;
		base.Name = "MarketingProduct".Loc(fakeTarget);
	}

	public MarketingPlan(SoftwareWorkItem targetItem, TaskType type, PressOption options, int siblingIndex)
		: base(targetItem.Name, null, 0u, null, siblingIndex)
	{
		Type = type;
		PressOptions = options;
		Progress = new float[CountOptions()];
		TargetItem = targetItem;
		PreMarketing = true;
		CorrectName();
		RunScripts(targetItem.Features, false, false, (SoftwareWorkItem.FeatureProgress x) => x.Feature);
	}

	private int CountOptions()
	{
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			if (((byte)PressOptions & (1 << i)) > 0)
			{
				num++;
			}
		}
		return num;
	}

	public void CorrectName()
	{
		if (PreMarketing)
		{
			base.Name = "MarketingProduct".Loc(TargetItem.Name);
		}
		else
		{
			base.Name = "MarketingProduct".Loc(TargetProduct.GetName());
		}
	}

	public override string GetIcon()
	{
		return "Chart";
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Service, secondary);
		if (hasWorkReturn == HasWorkReturn.NotApplicable)
		{
			return HasWorkReturn.NotApplicable;
		}
		if (Type == TaskType.PressRelease)
		{
			int num = 0;
			bool flag = true;
			bool flag2 = false;
			int specialization = actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Marketing");
			for (int i = 0; i < 3; i++)
			{
				if (((byte)PressOptions & (1 << i)) <= 0)
				{
					continue;
				}
				if (Progress[num] < 1f)
				{
					if (specialization >= i + 1)
					{
						flag2 = true;
					}
					flag = false;
				}
				num++;
			}
			if (AutoDev && flag)
			{
				StopMarketing();
			}
			if (!flag2)
			{
				if (!flag)
				{
					return HasWorkReturn.NotApplicable;
				}
				return HasWorkReturn.Finished;
			}
			return hasWorkReturn;
		}
		if (Type == TaskType.PostMarket && MaxBudget > 0f && Spent >= MaxBudget)
		{
			return HasWorkReturn.Finished;
		}
		if (Type == TaskType.Hype)
		{
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem.FollowerChange >= 0f || targetItem.Followers == 0f)
			{
				return HasWorkReturn.Finished;
			}
		}
		return hasWorkReturn;
	}

	private AutoDevWorkItem FinishAutoDev()
	{
		AutoDevWorkItem autoDevWorkItem = GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().FirstOrDefault((AutoDevWorkItem x) => x.Items.Any((AutoDevWorkItem.AutoDevItem z) => z.SWWorkItem == TargetItem));
		if (autoDevWorkItem != null && autoDevWorkItem.GetMistakeChance(false) > Utilities.RandomValue)
		{
			float max = TargetItem.Followers * 0.5f;
			int num = Mathf.RoundToInt(autoDevWorkItem.GetMistakeAmount(max));
			if (num > 1)
			{
				TargetItem.Followers -= num;
				autoDevWorkItem.LogMistake("Press", TargetItem.SoftwareName, num.ToString());
			}
		}
		return autoDevWorkItem;
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		float skill = actor.employee.GetSkill(Employee.EmployeeRole.Service);
		effectiveness *= skill.MapRange(0f, 1f, 0.01f, 1f) * actor.GetPCAddonBonus((!actor.employee.IsRole(Employee.RoleBit.Lead)) ? Employee.EmployeeRole.Service : Employee.EmployeeRole.Lead) * actor.LeaderEffectivenessFactor(1);
		RecordSkill(Employee.EmployeeRole.Service, skill, delta);
		DoSubWork(effectiveness, delta, actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Marketing"), true);
	}

	private void DoSubWork(float effectiveness, float delta, int mLevel, bool useGameTime)
	{
		switch (Type)
		{
		case TaskType.PostMarket:
			if (MaxBudget <= 0f || Spent < MaxBudget)
			{
				float num6 = Utilities.PerDay(effectiveness, delta, useGameTime);
				float num7 = Utilities.PerDay(PostMarketingPrice, delta, useGameTime);
				Spent += num7;
				Progress[0] += num6;
				TotalNetworkUnits += num6;
			}
			break;
		case TaskType.Hype:
		{
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem.FollowerChange < 0f)
			{
				targetItem.FollowerChange = Mathf.Lerp(targetItem.FollowerChange, 0f, Utilities.PerHour(effectiveness, delta, useGameTime) / (float)GameSettings.DaysPerMonth);
			}
			break;
		}
		case TaskType.PressRelease:
		{
			int num = Progress.Length - 1;
			bool flag = true;
			for (int num2 = 2; num2 >= 0; num2--)
			{
				if (((byte)PressOptions & (1 << num2)) > 0)
				{
					if (Progress[num] < 1f)
					{
						flag = false;
						if (mLevel >= num2 + 1)
						{
							float num3 = Utilities.PerDay(effectiveness, delta, useGameTime);
							float num4 = num3 * HUD.Instance.marketingWindow.PressOptionCost[num2];
							Spent += num4;
							float num5 = Progress[num];
							Progress[num] = Mathf.Clamp01(Progress[num] + num3);
							TotalNetworkUnits += (Progress[num] - num5) / (float)Progress.Length * 100f;
							break;
						}
					}
					num--;
				}
			}
			if (AutoDev && flag)
			{
				StopMarketing();
			}
			break;
		}
		}
	}

	public override float CompanyWork(float delta)
	{
		int num = 20;
		DoSubWork((float)num * base.CompanyWorker.AverageQuality, delta, 3, false);
		return Utilities.PerDay(base.CompanyWorker.BusinessSavy.MapRange(0f, 1f, 4f, 2f) * (float)num * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Service, "Marketing"), delta, false);
	}

	private static MarketingWindow.MarketingOption GetOption(TaskType type)
	{
		switch (type)
		{
		case TaskType.PostMarket:
			return MarketingWindow.MarketingOption.Market;
		case TaskType.Hype:
			return MarketingWindow.MarketingOption.Hype;
		default:
			return MarketingWindow.MarketingOption.PressRelease;
		}
	}

	public void ShowDetails()
	{
		SoftwareProduct product;
		AddOnProduct product2;
		if ((product = TargetProduct as SoftwareProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(product);
		}
		else if ((product2 = TargetProduct as AddOnProduct) != null)
		{
			HUD.Instance.GetProductWindow(null).ShowAddonDetails(product2);
		}
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		if (state == NetworkDealState.Sender)
		{
			yield return new KeyValuePair<string, Action>("FinishDeal", delegate
			{
				NetworkCancel(true);
			});
			if (Type == TaskType.PostMarket)
			{
				yield return new KeyValuePair<string, Action>("Details", ShowDetails);
			}
			yield return new KeyValuePair<string, Action>("CancelDeal", delegate
			{
				NetworkCancel(false);
			});
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign(GetOption(Type).ToString());
		});
		if (Type == TaskType.PostMarket)
		{
			yield return new KeyValuePair<string, Action>("Details", ShowDetails);
		}
		if (state == NetworkDealState.Receiver)
		{
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
		}
		else if (Type == TaskType.PressRelease)
		{
			yield return new KeyValuePair<string, Action>("Release", delegate
			{
				if (TargetItem.ReleaseDate.HasValue)
				{
					StopMarketing();
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("MarketingReleaseDateWarning".Loc("Pressrelease".Loc().ToLower()), true, DialogWindow.DialogType.Question, StopMarketing, "Marketing without release date");
				}
			});
			yield return new KeyValuePair<string, Action>("Cancel", delegate
			{
				Kill();
			});
		}
		else
		{
			yield return new KeyValuePair<string, Action>("MarketingStop", StopMarketing);
		}
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		if (Type == TaskType.PressRelease)
		{
			if (PressOptions.HasFlag(PressOption.Video))
			{
				needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Marketing", 3)] = 9999;
			}
			if (PressOptions.HasFlag(PressOption.Image))
			{
				needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Marketing", 2)] = 9999;
			}
			if (PressOptions.HasFlag(PressOption.Text))
			{
				needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Marketing", 1)] = 9999;
			}
		}
		needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Marketing", -1)] = 9999;
	}

	public override string GetTypeName()
	{
		return "MarketingPlan";
	}

	public override string GetGroupType()
	{
		switch (Type)
		{
		case TaskType.PostMarket:
			return "Marketing";
		case TaskType.Hype:
			return "Hype";
		case TaskType.PressRelease:
			return "Pressrelease";
		default:
			return null;
		}
	}

	public override string GetGroupProject()
	{
		switch (Type)
		{
		case TaskType.PostMarket:
		{
			IMarketable targetProduct = TargetProduct;
			if (targetProduct == null)
			{
				return null;
			}
			return targetProduct.GetName();
		}
		case TaskType.Hype:
		case TaskType.PressRelease:
		{
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem == null)
			{
				return null;
			}
			return targetItem.SoftwareName;
		}
		default:
			return null;
		}
	}

	public override bool CanUseCompany()
	{
		return true;
	}

	public override bool HasCompanyWork()
	{
		if (Type == TaskType.PressRelease && Progress.None((float x) => x < 1f))
		{
			if (AutoDev)
			{
				StopMarketing();
			}
			return false;
		}
		if (Type == TaskType.PostMarket && MaxBudget > 0f && Spent >= MaxBudget)
		{
			return false;
		}
		if (Type == TaskType.Hype)
		{
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem.FollowerChange >= 0f || targetItem.Followers == 0f)
			{
				return false;
			}
		}
		return true;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		if (act.employee.IsRole(Employee.RoleBit.Service, secondary))
		{
			return Employee.EmployeeRole.Service;
		}
		return null;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.ThumbsUp;
	}

	public override string CollapseLabel()
	{
		if (Type == TaskType.Hype)
		{
			SoftwareWorkItem targetItem = TargetItem;
			float value = ((targetItem.Followers < 1f) ? 0f : (targetItem.FollowerChange * 24f * (float)GameSettings.DaysPerMonth / targetItem.Followers));
			return "FollowerAmount".Loc(value.ToPercent(true, true));
		}
		return base.CollapseLabel();
	}

	public override string Category()
	{
		return SubCategory(Spent);
	}

	public string SubCategory(float spent)
	{
		switch (Type)
		{
		case TaskType.PostMarket:
		{
			if (deal == 0)
			{
				float lastDayIncome = TargetProduct.GetLastDayIncome(false);
				return "MarketingBalance".Loc() + ": " + (lastDayIncome - spent).Currency() + " (-" + spent.Currency() + ")";
			}
			SoftwareProduct product = base.ActiveDeal.Product;
			if (product != null)
			{
				return "Budget".Loc() + ": " + spent.Currency() + "/" + WorkDeal.GetMarketingBudget(product).Currency();
			}
			return "Budget".Loc() + ": " + spent.Currency();
		}
		case TaskType.PressRelease:
			return "Cost".Loc() + ": " + spent.Currency();
		case TaskType.Hype:
		{
			SoftwareWorkItem targetItem = TargetItem;
			float followerChange = targetItem.FollowerChange;
			if (targetItem.Followers != 0f && !(followerChange >= 0f))
			{
				return "FollowerChange".Loc(((0f - followerChange) * 24f * (float)GameSettings.DaysPerMonth / targetItem.Followers * 100f).ToString("F1"));
			}
			return "HypingInactiveStatus".Loc();
		}
		default:
			return "";
		}
	}

	public override string GetProgressLabel()
	{
		if (Type != TaskType.PostMarket || deal != 0)
		{
			return "";
		}
		return SoftwareType.GetAwarenessLabel(TargetProduct.GetAwareness());
	}

	public override string CurrentStage()
	{
		switch (Type)
		{
		case TaskType.PostMarket:
			return "Marketing".Loc();
		case TaskType.Hype:
			return "Hyping".Loc();
		case TaskType.PressRelease:
			return "Writingpressrelease".Loc();
		default:
			return "";
		}
	}

	public override byte[] SerializeProgressData()
	{
		return BitConverter.GetBytes(Spent);
	}

	public override void DeserializeProgressData(byte[] data)
	{
		NetworkStage = CurrentStage();
		NetworkCategory = SubCategory(BitConverter.ToSingle(data, 0));
		NetworkProgressLabel = GetProgressLabel();
	}

	public override float GetProgress()
	{
		if (Type == TaskType.PostMarket && deal != 0)
		{
			return Spent / WorkDeal.GetMarketingBudget(TargetProduct);
		}
		if (Type == TaskType.PostMarket && (LastProgress >= 0f || MaxBudget > 0f))
		{
			return Mathf.Clamp01((MaxBudget > 0f) ? (Spent / MaxBudget) : (Progress[0] / LastProgress));
		}
		if (Type == TaskType.PressRelease)
		{
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				if (((byte)PressOptions & (1 << i)) > 0)
				{
					num += Progress[num2];
					num2++;
				}
			}
			return num / (float)num2;
		}
		return 0f;
	}

	public void AddEffect(bool checkIfDone = true)
	{
		GetWorkOwner().MakeTransaction(0f - Spent, Company.TransactionCategory.Marketing, true);
		if (Type == TaskType.PostMarket)
		{
			TargetProduct.AddToMarketing(Progress[0]);
			if (deal == 0)
			{
				TargetProduct.AddLoss(Spent, SoftwareProduct.LossType.Marketing, true);
			}
			LastSpent = Spent;
			LastProgress = Progress[0];
			Spent = 0f;
			Progress[0] = 0f;
		}
		else if (Type == TaskType.PressRelease)
		{
			Finish();
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem != null)
			{
				targetItem.AddLoss(Spent, SoftwareProduct.LossType.Marketing, true);
			}
		}
	}

	public static float GetHypeFactor(float monthsLeft, bool releaseDate)
	{
		if (monthsLeft < 0f)
		{
			if (!releaseDate)
			{
				return 1f;
			}
			return 0.1f;
		}
		if (monthsLeft < 3f)
		{
			return 1f;
		}
		return Mathf.Pow(Math.Max(1f - (monthsLeft - 3f) / DifficultyValues.Difficulty.PressReleaseHypeDeadline, 0.4f), 2f);
	}

	public static float GetFollowerWish(float maxFollowers)
	{
		return Mathf.Min(maxFollowers, Mathf.Sqrt(maxFollowers / (float)MarketSimulation.FollowerPopulation) * (float)MarketSimulation.Population * 0.01f);
	}

	private void Finish()
	{
		if (Type == TaskType.PressRelease)
		{
			FinishPressRelease(TargetItem, PressOptions, Progress, !AutoDev);
		}
	}

	public static void FinishPressRelease(SoftwareWorkItem tgt, PressOption options, float[] progress, bool includeArticle)
	{
		DesignDocument designDocument;
		if ((designDocument = tgt as DesignDocument) != null && designDocument.Result != null)
		{
			tgt = designDocument.Result as SoftwareWorkItem;
		}
		SDateTime sDateTime = SDateTime.Now();
		bool flag = !tgt.AddOn;
		float num;
		if (tgt is DesignDocument)
		{
			num = GetHypeFactor(SDateTime.GetMonths(sDateTime, tgt.DevStart + tgt.DevTime), false);
		}
		else
		{
			num = ((!tgt.ReleaseDate.HasValue) ? (GetHypeFactor(SDateTime.GetMonths(sDateTime, tgt.DevStart + tgt.DevTime), false) * 0.25f) : GetHypeFactor(SDateTime.GetMonths(sDateTime, tgt.ReleaseDate.Value), true));
			if (flag)
			{
				num *= (float)SoftwareProduct.GetCreativityFactor(tgt.CreativityScore, true);
				flag = tgt.CreativityScore > 0.5;
			}
		}
		if (flag && tgt.LeadWork != null && tgt.LeadWork.Count > 0)
		{
			Employee key = tgt.LeadWork.MaxInstance((KeyValuePair<Employee, float> x) => x.Value).Key;
			if (key.LastDemandScore >= 1f && key.Creativity > 0.5f)
			{
				num *= 1f + SoftwareProduct.CreativityAwarenessFactor.Evaluate(key.Creativity);
			}
		}
		double perceivedMarketValue = tgt.GetPerceivedMarketValue();
		float rep = tgt.GetRep();
		double number = SoftwareProduct.CalculateSequelBonus(tgt.SequelTo, tgt.SWCategory.PerceivedValue(tgt.GetFeatures(), tgt.TechLevels), (tgt is DesignDocument) ? 1.0 : tgt.CreativityScore, tgt.Submarkets, tgt.SubscriptionBased, sDateTime);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		int num5 = 0;
		for (int num6 = 0; num6 < 3; num6++)
		{
			if (((byte)options & (1 << num6)) > 0)
			{
				num3 += progress[num5];
				num4 += progress[num5] * HUD.Instance.marketingWindow.PressOptionEffect[num6];
				num2 += HUD.Instance.marketingWindow.PressOptionEffect[num6];
				num5++;
			}
		}
		num3 /= (float)num5;
		float num7 = (float)((double)(num4 * tgt.PressReleaseEffect * rep.WeightOne(0.95f)) * number.WeightOne(0.25) * perceivedMarketValue * (double)num);
		float followerWish = GetFollowerWish(tgt.MaxFollowers);
		string companyName = tgt.GetLocalCompanyOwner().Name;
		tgt.FixReviewRep(ref companyName, ref rep);
		if (includeArticle)
		{
			Newspaper.GeneratePressReleaseReview(new ArticleGenerator.PressReleaseData(companyName, tgt.SoftwareName, (!(tgt is DesignDocument)) ? 1 : 0, tgt.ReleaseDate, rep, (float)perceivedMarketValue, num3, num2, tgt.PressReleaseEffect));
		}
		tgt.Followers += num7 * followerWish * 0.25f;
		tgt.FollowerChange += num7 * followerWish * 0.01f;
		tgt.PressReleaseEffect = 0f;
		tgt.MarketingDone();
	}

	protected override void Cancelled()
	{
		base.Cancelled();
		if (base.ActiveDeal != null && GetProgress() == 0f)
		{
			HUD.Instance.dealWindow.CancelDeal(base.ActiveDeal, false);
			base.ActiveDeal = null;
		}
		AddEffect(false);
	}

	public void StopMarketing()
	{
		AddEffect(false);
		AutoDevWorkItem autoDevWorkItem = null;
		if (AutoDev && !Done && Type == TaskType.PressRelease)
		{
			autoDevWorkItem = FinishAutoDev();
		}
		Kill();
		if (autoDevWorkItem != null)
		{
			autoDevWorkItem.UpdateLists();
		}
	}

	public override float StressMultiplier()
	{
		return 0.25f;
	}

	public override string GetWorkTypeName()
	{
		return "Marketing";
	}

	public override string GetIdentifyingTypeName()
	{
		switch (Type)
		{
		case TaskType.Hype:
			return "Hype";
		case TaskType.PressRelease:
			return "Pressrelease";
		default:
			return base.GetIdentifyingTypeName();
		}
	}

	public override string GetDetailedTypeName()
	{
		switch (Type)
		{
		case TaskType.Hype:
			return "Hype".Loc();
		case TaskType.PressRelease:
			return "Pressrelease".Loc();
		case TaskType.PostMarket:
			return "Post-marketing".Loc();
		default:
			return base.GetDetailedTypeName();
		}
	}

	public override void AddLoss(float cost, bool fromNetwork = false)
	{
		if (PreMarketing)
		{
			if (GetNetworkDealState() != NetworkDealState.Receiver)
			{
				TargetItem.AddLoss(cost, SoftwareProduct.LossType.Marketing, false, fromNetwork);
			}
		}
		else
		{
			TargetProduct.AddLoss(cost, SoftwareProduct.LossType.Marketing, false, fromNetwork);
		}
	}

	public override string GetSubjectName()
	{
		if (Type == TaskType.PostMarket)
		{
			if (TargetProduct != null)
			{
				return TargetProduct.GetName();
			}
		}
		else
		{
			SoftwareWorkItem targetItem = TargetItem;
			if (targetItem != null)
			{
				return targetItem.SoftwareName;
			}
		}
		return "NotApplicableAbbr".Loc();
	}

	public override string GetTutorial()
	{
		if (Type != TaskType.PostMarket)
		{
			return base.GetTutorial();
		}
		return "Marketing";
	}

	public override string HightlightButton()
	{
		if (Type == TaskType.PressRelease)
		{
			for (int i = 0; i < Progress.Length; i++)
			{
				if (Progress[i] < 1f)
				{
					return base.HightlightButton();
				}
			}
			return "Release";
		}
		return base.HightlightButton();
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			if (Type == TaskType.PostMarket)
			{
				if (TargetProduct != null)
				{
					RunScripts(TargetProduct.GetFeatures(), true, wasCancelled);
				}
			}
			else
			{
				RunScripts(TargetItem.Features, true, wasCancelled, (SoftwareWorkItem.FeatureProgress x) => x.Feature);
			}
		}
		base.Kill(wasCancelled);
	}

	public override void OnNetworkComplete(Stream st)
	{
		switch (Type)
		{
		case TaskType.PostMarket:
			Progress[0] = st.ReadFloat();
			LastProgress = st.ReadFloat();
			Spent = st.ReadFloat();
			LastSpent = st.ReadFloat();
			break;
		case TaskType.PressRelease:
			Progress = st.ReadArray((Stream s) => s.ReadFloat());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		switch (Type)
		{
		case TaskType.PostMarket:
		{
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				memoryStream2.WriteFloat(Progress[0]);
				memoryStream2.WriteFloat(LastProgress);
				memoryStream2.WriteFloat(Spent);
				memoryStream2.WriteFloat(LastSpent);
				return memoryStream2.ToArray();
			}
		}
		case TaskType.PressRelease:
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.WriteArray(Progress, delegate(Stream s, float x)
				{
					s.WriteFloat(x);
				});
				return memoryStream.ToArray();
			}
		}
		default:
			return null;
		}
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		switch (Type)
		{
		case TaskType.PostMarket:
			return new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("Product".Loc(), TargetProduct.GetName()),
				new KeyValuePair<string, string>("Type".Loc(), TargetProduct.GetTypeName()),
				new KeyValuePair<string, string>("Release".Loc(), TargetProduct.GetReleaseDate().ToCompactString())
			};
		case TaskType.PressRelease:
			return new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("Product".Loc(), TargetItem.Name),
				new KeyValuePair<string, string>("Type".Loc(), TargetItem.GetTypeName()),
				new KeyValuePair<string, string>("Tasks".Loc(), Newspaper.MakeList(GetPressOptions()))
			};
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private List<string> GetPressOptions()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < 3; i++)
		{
			PressOption pressOption = (PressOption)(1 << i);
			if (PressOptions.HasFlag(pressOption))
			{
				list.Add(MarketingWindow.PressOptionNames[i].Loc());
			}
		}
		return list;
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteByte((byte)Type);
		SoftwareProduct softwareProduct;
		AddOnProduct addOnProduct;
		if ((softwareProduct = TargetProduct as SoftwareProduct) != null)
		{
			st.WriteByte(0);
			st.WriteUInt(softwareProduct.ID);
		}
		else if ((addOnProduct = TargetProduct as AddOnProduct) != null)
		{
			st.WriteByte(1);
			st.WriteUInt(addOnProduct.Parent.ID);
			st.WriteUInt(addOnProduct.ID);
		}
		switch (Type)
		{
		case TaskType.PostMarket:
			st.WriteFloat(Progress[0]);
			st.WriteFloat(LastProgress);
			st.WriteFloat(MaxBudget);
			st.WriteFloat(Spent);
			st.WriteFloat(LastSpent);
			break;
		case TaskType.PressRelease:
			st.WriteStringUTF8(TargetItem.Name);
			st.WriteByte((byte)PressOptions);
			st.WriteArray(Progress, delegate(Stream s, float x)
			{
				s.WriteFloat(x);
			});
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override bool IsDoneForNetworkDeal()
	{
		if (Type == TaskType.PressRelease)
		{
			for (int i = 0; i < Progress.Length; i++)
			{
				if (Progress[i] < 1f)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
