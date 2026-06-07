using System;
using System.Collections.Generic;
using System.IO;
using Achievements;
using UnityEngine;

[Serializable]
public class LegalWork : WorkItem
{
	public enum WorkType
	{
		InternalLawsuit = 1,
		ExternalLawsuit = 2,
		Patent = 3
	}

	private ActiveWorkerManager _workerManager = new ActiveWorkerManager();

	public Company Plaintiff;

	public TechLevel Patent;

	public string Subject;

	[AltWasFloat(0)]
	public double Amount;

	public float Backlash;

	public int Months;

	public int DevTime;

	public SDateTime Deadline;

	public SDateTime Settle;

	public float Progress;

	public WorkType Type;

	public bool CanSettle = true;

	public bool Spiff;

	private bool _patentWarned;

	public override bool AlwaysUseLocalProgressLabel
	{
		get
		{
			return true;
		}
	}

	public override bool AlwaysUseLocalStageLabel
	{
		get
		{
			return true;
		}
	}

	public override bool AlwaysUseLocalCategory
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
			return new Color(0.5f, 0.3f, 0.2f);
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			return true;
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 5;
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return true;
		}
	}

	public override IReferenceFix FixReferences()
	{
		if (Plaintiff != null)
		{
			string name = Plaintiff.Name;
			Plaintiff = MarketSimulation.Active.GetCompany(Plaintiff.ID);
			if (Plaintiff == null)
			{
				SelectorController.MissingDataHost.Add(name);
				Kill();
				return null;
			}
		}
		if (Patent != null)
		{
			TechLevel patent = Patent;
			Patent = (TechLevel)Patent.FixReferences();
			if (Patent == null)
			{
				SelectorController.MissingDataHost.Add(patent.GetActualString() + " " + patent.ActualYear);
				Kill();
				return null;
			}
		}
		return base.FixReferences();
	}

	public LegalWork()
	{
	}

	public static string GetName(WorkType type)
	{
		switch (type)
		{
		case WorkType.InternalLawsuit:
			return "Internallawsuit".Loc();
		case WorkType.ExternalLawsuit:
			return "Externallawsuit".Loc();
		case WorkType.Patent:
			return "Patent".Loc();
		default:
			return "NotApplicableAbbr".Loc();
		}
	}

	public override string GetDetailedTypeName()
	{
		return GetName(Type);
	}

	public LegalWork(WorkType type, Company plaintiff, TechLevel patent, string subject, double amount, float backlash, int months, int devTime, SDateTime deadline, SDateTime settle, float progress, bool canSettle, uint networkID, NetworkDeal networkDeal)
		: base(GetName(type), null, networkID, networkDeal)
	{
		Plaintiff = plaintiff;
		Patent = patent;
		Subject = subject;
		Amount = amount;
		Backlash = backlash;
		Months = months;
		DevTime = devTime;
		Deadline = deadline;
		Settle = settle;
		Progress = progress;
		Type = type;
		CanSettle = canSettle;
	}

	public LegalWork(Company plaintiff, string subject, double money, float difficulty)
		: base("Externallawsuit".Loc(), null, 0u, null)
	{
		Type = WorkType.ExternalLawsuit;
		Plaintiff = plaintiff;
		Subject = subject;
		InitTimeline(money, difficulty);
	}

	public LegalWork(string subject, double money, float difficulty)
		: base("Internallawsuit".Loc(), null, 0u, null)
	{
		Type = WorkType.InternalLawsuit;
		Subject = subject;
		InitTimeline(money, difficulty);
	}

	private void InitTimeline(double money, float difficulty)
	{
		Amount = money;
		DevTime = Utilities.CeilToInt(Math.Max(1.0, Math.Pow(money, 0.4000000059604645) / 15.0));
		float num = GameData.ProjectDevTimeGeneric(DevTime);
		Months = Mathf.Max(2, Mathf.CeilToInt(num * difficulty.MapRange(0f, 1f, 0.75f, 1f)));
		Deadline = (SDateTime.Now() + Months).SimplifyLess();
		Settle = (SDateTime.Now() + Mathf.Max(1, Mathf.CeilToInt((float)Months * difficulty.MapRange(0f, 1f, 0.75f, 0.25f)))).SimplifyLess();
		Backlash = difficulty;
	}

	public LegalWork(TechLevel t)
		: base("Patent".Loc(), null, 0u, null)
	{
		Type = WorkType.Patent;
		Patent = t;
		DevTime = Mathf.CeilToInt(GameSettings.Instance.simulation.GetTechMonths(t.Spec));
	}

	public bool IsLawsuit()
	{
		if (Type != WorkType.ExternalLawsuit)
		{
			return Type == WorkType.InternalLawsuit;
		}
		return true;
	}

	public override string Category()
	{
		switch (Type)
		{
		case WorkType.InternalLawsuit:
			return Subject.Loc();
		case WorkType.ExternalLawsuit:
			if (Plaintiff == null)
			{
				return Subject.Loc();
			}
			return Plaintiff.Name + ": " + Subject.Loc();
		case WorkType.Patent:
			return Patent.Spec.LocTry() + " " + Patent.ActualYear;
		default:
			return null;
		}
	}

	public override string GetProgressLabel()
	{
		if (IsLawsuit())
		{
			if (!CanSettle)
			{
				return Amount.Currency();
			}
			return "TimeToSettle".Loc(SDateTime.DateDiff2(SDateTime.Now(), Settle), SettleAmount().Currency());
		}
		if (Type == WorkType.Patent)
		{
			SDateTime? researchETA = MarketSimulation.Active.GetResearchETA(Patent.Spec, Patent.Year);
			if (researchETA.HasValue)
			{
				return "CompetitorResearchETA".Loc() + ": " + researchETA.Value.ToQuarterString();
			}
		}
		return base.GetProgressLabel();
	}

	public override string CurrentStage()
	{
		if (IsLawsuit())
		{
			return "TimeToDefeat".Loc(SDateTime.DateDiff2(SDateTime.Now(), Deadline));
		}
		if (Type == WorkType.Patent)
		{
			if (!(Progress >= 1f))
			{
				return "Applyingforpatent".Loc();
			}
			return "Finished".Loc();
		}
		return base.CurrentStage();
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		if (Progress >= 1f)
		{
			return HasWorkReturn.Finished;
		}
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Service, secondary);
		if (hasWorkReturn != HasWorkReturn.NotApplicable && actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Law") >= (int)Type)
		{
			return hasWorkReturn;
		}
		return HasWorkReturn.NotApplicable;
	}

	public override string HightlightButton()
	{
		if (Type == WorkType.Patent && Progress >= 1f)
		{
			return "Patent";
		}
		return base.HightlightButton();
	}

	public override string GetIcon()
	{
		return "Law";
	}

	public override string GetSubjectName()
	{
		if (Type != WorkType.Patent)
		{
			return Subject.Loc();
		}
		return Patent.Spec.LocTry() + " " + "Patent".Loc();
	}

	public override string GetWorkTypeName()
	{
		return "Legalwork";
	}

	public override float StressMultiplier()
	{
		return 1f;
	}

	public override float GetProgress()
	{
		return Progress;
	}

	public void UpdateSettleStatus()
	{
		if (CanSettle && SDateTime.Now() >= Settle)
		{
			CanSettle = false;
			guiItem.InitButtons();
		}
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		if (Type == WorkType.Patent && !Patent.CanPatent)
		{
			if (GetNetworkDealState() == NetworkDealState.Receiver)
			{
				NetworkComplete();
				return;
			}
			if (!_patentWarned)
			{
				_patentWarned = true;
				NotificationManager.AddNotification(new NotificationMessage("PatentTooSlow".Loc(Patent.Spec), "Law", NotificationManager.NotificationType.Warning));
			}
			Kill();
			return;
		}
		_workerManager.UpdateWorker(actor.DID, SDateTime.Now());
		float num = Utilities.PerDay(actor.GetPCAddonBonus(Employee.EmployeeRole.Service) * effectiveness * GameData.GetProjectEffectiveness(_workerManager.Count, DevTime) * actor.employee.GetSkill(Employee.EmployeeRole.Service).MapRange(0f, 1f, 0.5f, 1f), delta) * actor.LeaderEffectivenessFactor(3);
		Progress += num / (float)DevTime * 8f;
		if (!(Progress >= 1f) || GetNetworkDealState() == NetworkDealState.Receiver)
		{
			return;
		}
		if (IsLawsuit())
		{
			NotificationManager.AddNotification(new NotificationMessage("LawsuitWon".Loc(Subject.Loc()), "Law", NotificationManager.NotificationType.Good));
			GameSettings.Instance.MyCompany.ChangeBusinessRep((0f - Backlash) * 0.5f, "Lawsuit");
			if (Spiff)
			{
				AchievementController.SetAchievement("SPIFFBREAK");
			}
			Kill();
		}
		else if (Type == WorkType.Patent)
		{
			guiItem.InitButtons();
		}
	}

	private double SettleAmount()
	{
		return Amount * (double)Progress.MapRange(0f, 1f, 1f, 0.5f, true);
	}

	public void SettleNow()
	{
		if (Type == WorkType.ExternalLawsuit && !GameSettings.HasCompletedMission("Mission13"))
		{
			WindowManager.Instance.ShowMessageBox("CampaignLockError".Loc(), true, DialogWindow.DialogType.Information);
		}
		else
		{
			if (!CanSettle)
			{
				return;
			}
			double amount = SettleAmount();
			WindowManager.Instance.ShowMessageBox("SettlePrompt".Loc(amount.Currency()), true, DialogWindow.DialogType.Question, delegate
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0.0 - amount, Company.TransactionCategory.Legal, true, "Lawsuit");
				if (Plaintiff != null && !Plaintiff.Bankrupt)
				{
					Plaintiff.MakeTransaction(amount, Company.TransactionCategory.Legal, true, "Lawsuit");
				}
				Kill();
			});
		}
	}

	public void Defeat()
	{
		if (GetNetworkDealState() != NetworkDealState.Receiver)
		{
			NotificationManager.AddNotification(new NotificationMessage("LawsuitLost".LocColor(new FormatColorString(Subject.Loc()), Amount.Currency()), "Law", NotificationManager.NotificationType.Warning));
			GameSettings.Instance.MyCompany.MakeTransaction(0.0 - Amount, Company.TransactionCategory.Legal, true, "Lawsuit");
			if (Plaintiff != null && !Plaintiff.Bankrupt)
			{
				Plaintiff.MakeTransaction(Amount, Company.TransactionCategory.Legal, true, "Lawsuit");
			}
			GameSettings.Instance.MyCompany.ChangeBusinessRep(0f - Backlash, "Lawsuit");
			Kill();
		}
	}

	public void PatentNow()
	{
		if (Progress >= 1f)
		{
			if (Patent.CanPatent)
			{
				Company myCompany = GameSettings.Instance.MyCompany;
				Patent.TransferPatent(myCompany, SDateTime.Now());
				myCompany.MakeTransaction(0f - TechLevel.PatentPrice, Company.TransactionCategory.Legal, true, "Patent");
			}
			else if (!_patentWarned)
			{
				_patentWarned = true;
				NotificationManager.AddNotification(new NotificationMessage("PatentTooSlow".Loc(Patent.Spec), "Law", NotificationManager.NotificationType.Warning));
			}
			Kill();
		}
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		if (!act.employee.IsRole(Employee.EmployeeRole.Service, secondary) || act.employee.GetSpecialization(Employee.EmployeeRole.Service, "Law") < (int)Type)
		{
			return null;
		}
		return Employee.EmployeeRole.Service;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.CourtHammer;
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
			yield return new KeyValuePair<string, Action>("CancelDeal", delegate
			{
				NetworkCancel(false);
			});
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign(string.Concat(Type, "Team"));
		});
		if (state == NetworkDealState.Receiver)
		{
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
			yield break;
		}
		if (IsLawsuit() && CanSettle)
		{
			yield return new KeyValuePair<string, Action>("Settle", SettleNow);
		}
		if (Type != WorkType.Patent)
		{
			yield break;
		}
		if (Progress >= 1f)
		{
			yield return new KeyValuePair<string, Action>("Patent", PatentNow);
		}
		yield return new KeyValuePair<string, Action>("Cancel", delegate
		{
			WindowManager.Instance.ShowMessageBox("WorkItemThingCancelConf".Loc(GetName(Type)), true, DialogWindow.DialogType.Question, delegate
			{
				Kill(true);
			}, "LegalCancelPrompt");
		});
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		needs.GetNeed(Employee.EmployeeRole.Service).AddUp(new HRManagement.EdNeed("Law", (int)Type), GameData.GetOptimalEmployees(DevTime));
	}

	public override string GetTypeName()
	{
		return "LegalWork";
	}

	public override string GetGroupType()
	{
		switch (Type)
		{
		case WorkType.InternalLawsuit:
		case WorkType.ExternalLawsuit:
			return "Lawsuit";
		case WorkType.Patent:
			return "Patent";
		default:
			return null;
		}
	}

	public override string GetGroupProject()
	{
		switch (Type)
		{
		case WorkType.InternalLawsuit:
		case WorkType.ExternalLawsuit:
			return "Lawsuit".Loc();
		case WorkType.Patent:
			return "Patent".Loc();
		default:
			return null;
		}
	}

	public override string GetGroupProjectLabel()
	{
		switch (Type)
		{
		case WorkType.InternalLawsuit:
		case WorkType.ExternalLawsuit:
			return "Lawsuit".Loc();
		case WorkType.Patent:
			return Patent.GetActualString() + " " + Patent.ActualYear;
		default:
			return null;
		}
	}

	public override string GetGroupTypeLabel()
	{
		return GetGroupProjectLabel();
	}

	public override bool HasProjectGrouping()
	{
		return false;
	}

	public override void OnNetworkComplete(Stream st)
	{
		Progress = st.ReadFloat();
		if (Progress >= 1f && IsLawsuit())
		{
			NotificationManager.AddNotification(new NotificationMessage("LawsuitWon".Loc(Subject.Loc()), "Law", NotificationManager.NotificationType.Good));
			GameSettings.Instance.MyCompany.ChangeBusinessRep((0f - Backlash) * 0.5f, "Lawsuit");
			if (Spiff)
			{
				AchievementController.SetAchievement("SPIFFBREAK");
			}
			Kill();
		}
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		if (!success)
		{
			return null;
		}
		return BitConverter.GetBytes(Progress);
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		if (Type == WorkType.Patent)
		{
			return new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("Type".Loc(), GetName(Type)),
				new KeyValuePair<string, string>("Techlevel".Loc(), Patent.Spec.Loc() + " " + Patent.ActualYear)
			};
		}
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("Type".Loc(), GetName(Type)),
			new KeyValuePair<string, string>("Reason".Loc(), Subject.Loc()),
			new KeyValuePair<string, string>("MonetaryAmount".Loc(), Amount.Currency()),
			new KeyValuePair<string, string>("Deadline".Loc(), Deadline.ToCompactString())
		};
		if (Plaintiff != null)
		{
			list.Add(new KeyValuePair<string, string>("Company".Loc(), Plaintiff.Name));
		}
		return list;
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteByte((byte)Type);
		Company plaintiff = Plaintiff;
		st.WriteUInt((plaintiff != null) ? plaintiff.ID : 0u);
		TechLevel patent = Patent;
		st.WriteStringUTF8((patent != null) ? patent.Spec : null);
		TechLevel patent2 = Patent;
		st.WriteInt((patent2 != null) ? patent2.Year : 0);
		st.WriteStringUTF8(Subject);
		st.WriteDouble(Amount);
		st.WriteFloat(Backlash);
		st.WriteInt(Months);
		st.WriteInt(DevTime);
		Deadline.WriteData(st);
		Settle.WriteData(st);
		st.WriteFloat(Progress);
		st.WriteBool(CanSettle);
	}

	public override bool IsDoneForNetworkDeal()
	{
		return Progress >= 1f;
	}
}
