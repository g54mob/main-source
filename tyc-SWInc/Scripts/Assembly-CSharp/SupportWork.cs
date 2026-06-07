using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
[AltDeprecate("StartBugs", typeof(int))]
[AltDeprecate("Verified", typeof(int))]
public class SupportWork : WorkItem
{
	public List<SDateTime> Tickets = new List<SDateTime>();

	private int _ticketsLast;

	public float NextFix;

	public float NextVerify;

	public int Missed;

	public int TicketDeal;

	public int Generated;

	public SDateTime LastMissed;

	public SoftwareProduct TargetProduct;

	private static Color _missColor = new Color(0.7f, 0f, 0f, 1f);

	public override Color BackColor
	{
		get
		{
			return new Color(0.75f, 0.75f, 0f);
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 1;
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			return true;
		}
	}

	public override string UnitName
	{
		get
		{
			return "SupportTicket";
		}
	}

	public override IReferenceFix FixReferences()
	{
		string name = TargetProduct.Name;
		TargetProduct = (SoftwareProduct)TargetProduct.FixReferences();
		if (TargetProduct == null)
		{
			SelectorController.MissingDataHost.Add(name);
			Kill();
			return null;
		}
		return base.FixReferences();
	}

	public SupportWork(string name)
		: base(name, null, 0u, null)
	{
	}

	public SupportWork()
	{
	}

	public SupportWork(SoftwareProduct targetProduct, int siblingIndex, uint networkID = 0u, NetworkDeal networkDeal = null)
		: base("Support for " + targetProduct.Name, null, networkID, networkDeal, siblingIndex)
	{
		TargetProduct = targetProduct;
		TutorialSystem.Instance.StartTutorial("Support work");
		RunScripts(targetProduct.Features, false, false);
	}

	public override string GetIcon()
	{
		return "Info";
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Service, secondary);
		if (hasWorkReturn == HasWorkReturn.NotApplicable)
		{
			return HasWorkReturn.NotApplicable;
		}
		if (Tickets.Count <= 0)
		{
			return HasWorkReturn.Waiting;
		}
		return hasWorkReturn;
	}

	public void Simulate(SDateTime time)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return;
		}
		int num = 0;
		int num2;
		for (num2 = 0; num2 < Tickets.Count; num2++)
		{
			SDateTime sDateTime = Tickets[num2];
			if (!((float)(time - sDateTime).ToInt() > 2880f * (float)GameSettings.DaysPerMonth))
			{
				break;
			}
			Missed++;
			LastMissed = time;
			TicketDeal--;
			Tickets.RemoveAt(num2);
			num2--;
			if (!TargetProduct.OpenSource)
			{
				num += Mathf.CeilToInt((float)Missed * Mathf.Clamp(((float)TargetProduct.Bugss + 10f) / 5000f, 0f, 0.1f));
			}
		}
		if (num > 0)
		{
			if (TargetProduct.Type == MarketSimulation.Active.DigitalDistSoft && GetWorkOwner().Distribution != null)
			{
				GetWorkOwner().Distribution.AddPenalty((uint)(num * 500));
			}
			else
			{
				GetWorkOwner().AddFans(-num, TargetProduct.Category);
			}
			if (!WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.SupportWorkSlowWarning))
			{
				NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.SupportWorkSlowWarning, this));
			}
		}
		_ticketsLast = Tickets.Count;
		if (TargetProduct.Userbase != 0)
		{
			int num3 = Mathf.RoundToInt(FixChance(0.25f, true) * Utilities.RandomRange(0f, Mathf.Pow(TargetProduct.Userbase, 0.3f) * 1.2f));
			if (num3 == 0 && TargetProduct.Userbase > 0)
			{
				num3 = Utilities.RandomRange(0, 3);
			}
			if (deal != 0)
			{
				Generated += num3;
			}
			for (int i = 0; i < num3; i++)
			{
				Tickets.Add(time);
			}
		}
	}

	public override string GetActualString()
	{
		return TargetProduct.Name;
	}

	private float FixChance(float offset, bool dpm)
	{
		float num = ((TargetProduct.StartBugss == 0) ? 0f : Mathf.Clamp01((float)TargetProduct.Bugss / (float)TargetProduct.StartBugss));
		float num2 = offset + num * (1f - offset);
		if (!dpm)
		{
			return num2;
		}
		return num2 / (float)GameSettings.DaysPerMonth;
	}

	public float GetAverageSkill(Team t)
	{
		float num = 0f;
		float num2 = 0f;
		List<Actor> employeesDirect = t.GetEmployeesDirect();
		for (int i = 0; i < employeesDirect.Count; i++)
		{
			if (employeesDirect[i].employee.IsRole(Employee.RoleBit.Programmer, employeesDirect[i].SecondaryWork))
			{
				float skill = employeesDirect[i].employee.GetSkill(Employee.EmployeeRole.Programmer);
				num += skill * skill;
				num2 += skill;
			}
		}
		if (!(num2 > 0f))
		{
			return 0f;
		}
		return num / num2;
	}

	public override void DoWork(Actor employee, float effectiveness, float delta, bool secondary)
	{
		effectiveness *= (employee.employee.IsRole(Employee.RoleBit.Lead) ? employee.GetPCAddonBonus(Employee.EmployeeRole.Lead) : employee.GetPCAddonBonus(Employee.EmployeeRole.Service));
		effectiveness *= employee.LeaderEffectivenessFactor(1);
		DoWorkSub(effectiveness, delta, employee.employee.GetSkill(Employee.EmployeeRole.Service), employee.employee.GetSpecialization(Employee.EmployeeRole.Service, "Support"), true, true, employee.employee.IsRole(Employee.RoleBit.Service, secondary));
	}

	public override bool CanUseCompany()
	{
		return true;
	}

	public override bool HasCompanyWork()
	{
		if (Tickets.Count == 0)
		{
			return TargetProduct.VerifiedBugs > TargetProduct.StartBugss - TargetProduct.Bugss;
		}
		return true;
	}

	private void DoWorkSub(float effectiveness, float delta, float markSkill, int supportSpec, bool useGameSpeed, bool recordSkill, bool mark)
	{
		float num = 1f;
		mark &= Tickets.Count > 0;
		if (!mark)
		{
			return;
		}
		NextVerify += Utilities.PerDay(markSkill.MapRange(0f, 1f, 1f, 2f) * 300f * effectiveness * num, delta, useGameSpeed);
		if (recordSkill)
		{
			RecordSkill(Employee.EmployeeRole.Service, markSkill, delta);
		}
		while (NextVerify >= 1f && Tickets.Count > 0)
		{
			TicketDeal++;
			TotalNetworkUnits += 1f;
			Tickets.RemoveAt(0);
			if (supportSpec >= 2 && Tickets.Count > 0)
			{
				Tickets.RemoveAt(0);
				TicketDeal++;
				TotalNetworkUnits += 1f;
			}
			_ticketsLast = Mathf.Min(Tickets.Count, _ticketsLast);
			if (deal == 0 && TargetProduct.VerifiedBugs < TargetProduct.StartBugss && supportSpec >= 1)
			{
				float num2 = FixChance(0.1f, false);
				if (UnityEngine.Random.value * 1.25f + 0.1f < num2)
				{
					TargetProduct.VerifiedBugs++;
					if (supportSpec >= 3 && TargetProduct.Bugss > 0 && UnityEngine.Random.value < 0.01f)
					{
						TargetProduct.FixBugs(1);
					}
				}
			}
			NextVerify -= 1f;
		}
	}

	public override float CompanyWork(float delta)
	{
		int num = Mathf.Clamp(TargetProduct.Userbase / 10000, 5, 100);
		float averageQuality = base.CompanyWorker.AverageQuality;
		float effectiveness = averageQuality * (float)num;
		DoWorkSub(effectiveness, delta, averageQuality, 1, false, false, true);
		return Utilities.PerDay(base.CompanyWorker.BusinessSavy.MapRange(0f, 1f, 4f, 2f) * (float)num * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Service, "Support"), delta, false);
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		if (state == NetworkDealState.Sender)
		{
			yield return new KeyValuePair<string, Action>("UpdateAction", delegate
			{
				HUD.Instance.updateWindow.Show(TargetProduct);
			});
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
			Assign("Support");
		});
		if (base.ActiveDeal == null && state == NetworkDealState.None)
		{
			yield return new KeyValuePair<string, Action>("UpdateAction", delegate
			{
				HUD.Instance.updateWindow.Show(TargetProduct);
			});
		}
		if (state == NetworkDealState.Receiver)
		{
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
		}
		else if (TargetProduct.Type != MarketSimulation.Active.DigitalDistSoft)
		{
			yield return new KeyValuePair<string, Action>("CancelSupport", delegate
			{
				CancelSupport(true);
			});
		}
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Support", -1)] = 9999;
	}

	public override string GetTypeName()
	{
		return "SupportWork";
	}

	public override string GetGroupType()
	{
		return "Support";
	}

	public override string GetGroupProject()
	{
		return TargetProduct.Name;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		return Employee.EmployeeRole.Service;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Phone;
	}

	public override float GetWorkScore()
	{
		return 1f;
	}

	public override string CollapseLabel()
	{
		int fixableBugs = TargetProduct.FixableBugs;
		if (fixableBugs > 0)
		{
			return "TicketsQueued".Loc(GetTicketCount()) + ", " + "UnfixedBugs".Loc(fixableBugs);
		}
		return "TicketsQueued".Loc(GetTicketCount());
	}

	public override string Category()
	{
		return TargetProduct.Userbase.ToString("N0") + " " + "Activeusers".Loc().ToLower();
	}

	public override string CurrentStage()
	{
		if (deal != 0)
		{
			float num = ((Generated > 0) ? ((float)Generated / 2f) : 1f);
			return "Satisfaction".Loc() + ": " + Mathf.Clamp((float)TicketDeal / num, -1f, 1f).ToPercent(false);
		}
		return "BugsFixed".Loc(TargetProduct.StartBugss - TargetProduct.Bugss) + "\n" + "BugsVerified".Loc(TargetProduct.VerifiedBugs);
	}

	public override string GetProgressLabel()
	{
		return GetProgressLabelSub(GetTicketCount(), Missed, Missed > 0 && !SDateTime.DayHasPassed(LastMissed, SDateTime.Now()));
	}

	private string GetProgressLabelSub(int ticketCount, int missed, bool bad)
	{
		if (bad)
		{
			return "TicketsQueued".Loc(ticketCount) + "\n" + "TicketsMissed".Loc(missed).FontColor(_missColor);
		}
		return "TicketsQueued".Loc(ticketCount) + "\n" + "TicketsMissed".Loc(missed);
	}

	public override void DeserializeProgressData(byte[] data)
	{
		using (MemoryStream stream = new MemoryStream(data))
		{
			NetworkStage = "BugsFixed".Loc(stream.ReadInt()) + "\n" + "BugsVerified".Loc(stream.ReadInt());
			NetworkCategory = Category();
			NetworkProgressLabel = GetProgressLabelSub(stream.ReadInt(), stream.ReadInt(), stream.ReadBool());
		}
	}

	public override byte[] SerializeProgressData()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteInt(TargetProduct.StartBugss - TargetProduct.Bugss);
			memoryStream.WriteInt(TargetProduct.VerifiedBugs);
			memoryStream.WriteInt(Tickets.Count);
			memoryStream.WriteInt(Missed);
			memoryStream.WriteBool(Missed > 0 && !SDateTime.DayHasPassed(LastMissed, SDateTime.Now()));
			return memoryStream.ToArray();
		}
	}

	public override int GUIWorkItemType()
	{
		return 1;
	}

	private int GetTicketCount()
	{
		float t = TimeOfDay.Instance.Minute / 60f;
		return Mathf.RoundToInt(Mathf.Lerp(_ticketsLast, Tickets.Count, t));
	}

	public void CancelSupport(bool allowWarning = false)
	{
		if (TargetProduct.Type == MarketSimulation.Active.DigitalDistSoft)
		{
			return;
		}
		if (base.ActiveDeal != null)
		{
			if (TargetProduct.Bugss == TargetProduct.StartBugss && Tickets.Count == 0)
			{
				HUD.Instance.dealWindow.CancelDeal(base.ActiveDeal, false);
				base.ActiveDeal = null;
				Kill();
			}
			else if (allowWarning)
			{
				WindowManager.Instance.ShowMessageBox("WorkItemThingCancelConf".Loc("Support".Loc()), false, DialogWindow.DialogType.Warning, delegate
				{
					Kill();
				}, "Cancel support deal");
			}
			else
			{
				Kill();
			}
		}
		else if (!TargetProduct.OpenSource && (base.ActiveDeal == null || !base.ActiveDeal.Incoming) && TargetProduct.Userbase > 0)
		{
			if (!AutoDev && allowWarning)
			{
				WindowManager.Instance.ShowMessageBox("SupportWorkCancelWarning2".Loc(), false, DialogWindow.DialogType.Warning, ActuallyCancel, "Cancel support");
			}
			else
			{
				ActuallyCancel();
			}
		}
		else
		{
			Kill();
		}
	}

	private void ActuallyCancel()
	{
		GameSettings.Instance.MyCompany.AddFans(-Mathf.RoundToInt((float)TargetProduct.Bugss / (TargetProduct.DevTime * SoftwareAlpha.BugLimitFactor) * (float)TargetProduct.Userbase), TargetProduct.Category);
		Kill();
	}

	public override void InitNetworkDealAccepted()
	{
		Tickets.Clear();
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteFloat(success ? NextVerify : 0f);
			memoryStream.WriteInt(Missed);
			LastMissed.WriteData(memoryStream);
			memoryStream.WriteArray(Tickets, delegate(Stream s, SDateTime x)
			{
				x.WriteData(s);
			});
			return memoryStream.ToArray();
		}
	}

	public override void OnNetworkComplete(Stream st)
	{
		NextVerify = st.ReadFloat();
		Missed = st.ReadInt();
		LastMissed = SDateTime.ReadData(st);
		Tickets.Clear();
		Tickets.AddRange(st.ReadArray(SDateTime.ReadData));
	}

	public override byte[] SubSendNetworkDealSync()
	{
		return BitConverter.GetBytes(TargetProduct.VerifiedBugs);
	}

	public override void ReceiveNetworkDealSync(Stream st)
	{
		TargetProduct.VerifiedBugs = st.ReadInt();
	}

	public override float StressMultiplier()
	{
		return 0.25f;
	}

	public override string GetWorkTypeName()
	{
		return "Support";
	}

	public override void AddLoss(float cost, bool fromNetwork = false)
	{
		TargetProduct.AddLoss(cost, SoftwareProduct.LossType.Support, false, fromNetwork);
	}

	public override string GetSubjectName()
	{
		if (TargetProduct == null)
		{
			return "NotApplicableAbbr".Loc();
		}
		return TargetProduct.Name;
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (TargetProduct != null)
		{
			RunScripts(TargetProduct.Features, true, wasCancelled);
		}
		base.Kill(wasCancelled);
	}

	public override string GetTutorial()
	{
		return "Support work";
	}

	public override void DevTeamChange()
	{
		CheckCompetency();
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteUInt(TargetProduct.ID);
		st.WriteInt(TargetProduct.VerifiedBugs);
		st.WriteArray(Tickets, delegate(Stream s, SDateTime x)
		{
			x.WriteData(s);
		});
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		return new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("Product".Loc(), TargetProduct.Name),
			new KeyValuePair<string, string>("Type".Loc(), TargetProduct.Category.GetActualString()),
			new KeyValuePair<string, string>("Release".Loc(), TargetProduct.Release.ToCompactString()),
			new KeyValuePair<string, string>("Activeusers".Loc(), TargetProduct.Userbase.ToString("F0"))
		};
	}

	private void CheckCompetency()
	{
		if (Done || TargetProduct.Bugss <= 0 || DevTeams.Count <= 0)
		{
			return;
		}
		bool flag = false;
		foreach (Team item in DevTeams.SelectNotNull(GameSettings.GetTeam))
		{
			List<Actor> employeesDirect = item.GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (HasWork(actor, actor.SecondaryWork, false) != HasWorkReturn.NotApplicable && actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Support") > 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag && !WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.MissingBugReporters))
		{
			NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.MissingBugReporters, this));
		}
	}
}
