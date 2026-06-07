using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AccountingWork : WorkItem
{
	public enum WorkType
	{
		BackgroundWork = 0,
		LoanApplication = 1,
		Procurement = 2,
		MoneyFunneling = 3
	}

	public WorkType Type;

	public float[] BackgroundWork;

	public float TotalProgress;

	[AltWasFloat(0)]
	public double Cost;

	public float Interest;

	public int Months;

	public string Procurement;

	public SDateTime Deadline;

	public string ActualProcurement
	{
		get
		{
			if (!char.IsDigit(Procurement[Procurement.Length - 1]))
			{
				return Procurement;
			}
			return Procurement.Substring(0, Procurement.Length - 1);
		}
	}

	public int ProcurementLevel
	{
		get
		{
			if (!char.IsDigit(Procurement[Procurement.Length - 1]))
			{
				return 0;
			}
			return Procurement.Substring(Procurement.Length - 1, 1).ConvertToIntDef(0);
		}
	}

	public override Color BackColor
	{
		get
		{
			return new Color32(91, byte.MaxValue, 139, byte.MaxValue);
		}
	}

	public override string GetIcon()
	{
		return "Money";
	}

	public AccountingWork()
	{
	}

	public AccountingWork(bool backgroundWork)
		: base("Background accounting", null, 0u, null)
	{
		Type = WorkType.BackgroundWork;
		BackgroundWork = new float[3];
	}

	public AccountingWork(double loan, float interest, int time)
		: base(WorkType.LoanApplication.ToString().Loc(), null, 0u, null)
	{
		Type = WorkType.LoanApplication;
		Cost = loan;
		Interest = interest;
		Months = time;
	}

	public AccountingWork(double moneyFunnel)
		: base(WorkType.MoneyFunneling.ToString().Loc(), null, 0u, null)
	{
		Type = WorkType.MoneyFunneling;
		Cost = moneyFunnel;
	}

	public AccountingWork(string procurement, double cost)
		: base(WorkType.Procurement.ToString().Loc(), null, 0u, null)
	{
		Type = WorkType.Procurement;
		Procurement = procurement;
		Cost = cost;
		Deadline = SDateTime.Now() + 1;
	}

	public override void DevTeamChange()
	{
		CheckCompetency();
	}

	public void CheckCompetency()
	{
		switch (Type)
		{
		case WorkType.BackgroundWork:
			return;
		case WorkType.Procurement:
			if (TotalProgress >= 1f || SDateTime.Now() > Deadline)
			{
				NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
				return;
			}
			break;
		case WorkType.LoanApplication:
		case WorkType.MoneyFunneling:
			if (TotalProgress >= 1f)
			{
				NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
				return;
			}
			break;
		}
		int specReq = GetSpecReq();
		bool flag = DevTeams.Count == 0;
		foreach (Team item in DevTeams.SelectNotNull(GameSettings.GetTeam))
		{
			List<Actor> employeesDirect = item.GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (actor.employee.IsRole(Employee.EmployeeRole.Service, true) && actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Accounting") >= specReq)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			if (!NotificationManager.CheckAggregate<NoQualifiedNotification>(this, ID))
			{
				NotificationManager.AddNotification(new NoQualifiedNotification(this, "", "SpecSkill".Loc(specReq, "Accountant".Loc())));
			}
		}
		else
		{
			NotificationManager.RemoveAggregate<NoQualifiedNotification>(this, ID);
		}
	}

	public override string Category()
	{
		switch (Type)
		{
		case WorkType.LoanApplication:
			return Cost.Currency();
		case WorkType.Procurement:
			return ActualProcurement.Loc();
		case WorkType.MoneyFunneling:
		{
			float num = GameSettings.Instance.Heat / 10000000f;
			return "LawHeat".Loc() + ": " + num.ToPercent().FontColor(Color.Lerp(new Color32(50, 50, 50, byte.MaxValue), new Color32(200, 0, 0, byte.MaxValue), num));
		}
		default:
			return "";
		}
	}

	public override string GetProgressLabel()
	{
		if (Type == WorkType.MoneyFunneling || Type == WorkType.Procurement)
		{
			return Cost.Currency();
		}
		return base.GetProgressLabel();
	}

	public override string CurrentStage()
	{
		if (Type == WorkType.Procurement)
		{
			SDateTime sDateTime = SDateTime.Now();
			if (!(sDateTime > Deadline))
			{
				return SDateTime.DateDiff2(sDateTime, Deadline);
			}
			return "Failed".Loc();
		}
		if (Type == WorkType.MoneyFunneling)
		{
			return Interest.Currency();
		}
		return "";
	}

	public override string GetSubjectName()
	{
		if (Type == WorkType.BackgroundWork)
		{
			return "Accounting".Loc();
		}
		return Type.ToString().Loc();
	}

	public override string GetWorkTypeName()
	{
		return "Accounting";
	}

	public override float StressMultiplier()
	{
		if (Type == WorkType.BackgroundWork)
		{
			return 0.5f;
		}
		return 1f;
	}

	public bool HasLastTaxReport()
	{
		TaxReport lastTaxReport = GameSettings.Instance.MyCompany.LastTaxReport;
		if (lastTaxReport != null)
		{
			return lastTaxReport.ReportProgress < 1f;
		}
		return false;
	}

	public int GetSpecReq()
	{
		switch (Type)
		{
		case WorkType.BackgroundWork:
			return 1;
		case WorkType.LoanApplication:
			return 2;
		case WorkType.Procurement:
			return 3;
		case WorkType.MoneyFunneling:
			return 3;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return HasWorkReturn.Ignore;
		}
		if (Type == WorkType.BackgroundWork && !TaxReport.NeedsAccounting(GameSettings.Instance.MyCompany.LastTaxReport))
		{
			return HasWorkReturn.Ignore;
		}
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Service, secondary);
		if (hasWorkReturn == HasWorkReturn.True || hasWorkReturn == HasWorkReturn.Secondary)
		{
			if (Type == WorkType.Procurement && SDateTime.Now() > Deadline)
			{
				MetalFailMessage();
				Kill();
				return HasWorkReturn.Finished;
			}
			if (Type == WorkType.MoneyFunneling && TotalProgress >= 1f)
			{
				Kill();
				return HasWorkReturn.Finished;
			}
			int specialization = actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Accounting");
			if (Type == WorkType.BackgroundWork && specialization == 1 && !HasLastTaxReport())
			{
				return HasWorkReturn.NotApplicable;
			}
			if (TotalProgress >= 1f)
			{
				return HasWorkReturn.Finished;
			}
			if (Type == WorkType.MoneyFunneling && GameSettings.Instance.Heat >= 10000000f)
			{
				return HasWorkReturn.Waiting;
			}
			int specReq = GetSpecReq();
			if (specialization < specReq)
			{
				return HasWorkReturn.NotApplicable;
			}
			return hasWorkReturn;
		}
		return hasWorkReturn;
	}

	public void UpdateBackgroundTask()
	{
		if (HasLastTaxReport())
		{
			TaxReport lastTaxReport = GameSettings.Instance.MyCompany.LastTaxReport;
			float num = Mathf.Max(0.01f, lastTaxReport.GetComplexity());
			for (int i = 0; i < BackgroundWork.Length; i++)
			{
				if (BackgroundWork[i] > 0f)
				{
					float num2 = BackgroundWork[i];
					BackgroundWork[i] = 0f;
					float num3 = (1f + (float)i / 4f) / num;
					lastTaxReport.ReportProgress += num2 * num3;
					if (lastTaxReport.ReportProgress > 1f)
					{
						float num4 = lastTaxReport.ReportProgress - 1f;
						BackgroundWork[i] += num4 / num3;
						lastTaxReport.ReportProgress = 1f;
						break;
					}
				}
			}
		}
		TaxReport currentTaxReport = GameSettings.Instance.MyCompany.CurrentTaxReport;
		for (int j = 1; j < BackgroundWork.Length; j++)
		{
			if (BackgroundWork[j] > 0f)
			{
				float num5 = BackgroundWork[j] * (1f + (float)j / 4f);
				BackgroundWork[j] = 0f;
				currentTaxReport.Optimization += num5 * 40000f;
			}
		}
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		effectiveness *= actor.LeaderEffectivenessFactor(3);
		float skill = actor.employee.GetSkill(Employee.EmployeeRole.Service);
		switch (Type)
		{
		case WorkType.BackgroundWork:
			BackgroundWork[actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Accounting") - 1] += Utilities.PerDay(effectiveness * skill, delta);
			break;
		case WorkType.LoanApplication:
		{
			float num = Utilities.PerDay(effectiveness * skill, delta) * 4f;
			num *= (float)(Cost / 1000000.0).MapRange(1.0, 10.0, 1.0, 0.5) * Months.MapRange(1f, 240f, 1f, 0.5f);
			TotalProgress += num;
			if (TotalProgress >= 1f)
			{
				TotalProgress = 1f;
				guiItem.InitButtons();
			}
			break;
		}
		case WorkType.Procurement:
			if (SDateTime.Now() > Deadline)
			{
				MetalFailMessage();
				Kill();
				break;
			}
			TotalProgress += Utilities.PerDay(effectiveness * skill * 4f, delta);
			if (TotalProgress >= 1f)
			{
				TotalProgress = 1f;
				guiItem.InitButtons();
			}
			break;
		case WorkType.MoneyFunneling:
		{
			float perHour = effectiveness * skill * Employee.GetMaxEmployeeWorth(4, "Accounting") / 0.05f;
			perHour = Utilities.PerHour(perHour) / (float)GameSettings.DaysPerMonth;
			Interest += perHour;
			if ((double)Interest > Cost)
			{
				perHour -= Interest - (float)Cost;
				Interest = (float)Cost;
				Kill();
			}
			GameSettings.Instance.AddHeat(perHour);
			TotalProgress = (float)((double)Interest / Cost);
			break;
		}
		}
		RecordSkill(Employee.EmployeeRole.Service, skill, delta);
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (Type == WorkType.MoneyFunneling)
		{
			GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
			if (wasCancelled)
			{
				GameSettings.Instance.OffshoreAccount += Cost;
			}
			else
			{
				GameSettings.Instance.OffshoreAccount += Cost - (double)Interest;
				GameSettings.Instance.MyCompany.MakeTransaction(Interest, Company.TransactionCategory.Sales, false, "TotallyLegit".Loc());
			}
		}
		base.Kill(wasCancelled);
	}

	public override float GetProgress()
	{
		WorkType type = Type;
		if ((uint)(type - 1) <= 2u)
		{
			return TotalProgress;
		}
		return base.GetProgress();
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		return Employee.EmployeeRole.Service;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Dollar;
	}

	private void MetalFailMessage()
	{
		NotificationManager.AddNotification("MetalProcurementFailed".Loc(), "Money", NotificationManager.NotificationType.Warning);
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		if (TotalProgress < 1f)
		{
			yield return new KeyValuePair<string, Action>("Assign", delegate
			{
				Assign("Accounting");
			});
		}
		switch (Type)
		{
		case WorkType.LoanApplication:
			if (TotalProgress >= 1f)
			{
				yield return new KeyValuePair<string, Action>("Takeloan", delegate
				{
					LoanWindow.TakeLoan(Months, (int)(Cost / 10000.0), 1);
					Kill();
				});
			}
			break;
		case WorkType.Procurement:
			if (!(TotalProgress >= 1f))
			{
				break;
			}
			yield return new KeyValuePair<string, Action>("Buy", delegate
			{
				if (SDateTime.Now() > Deadline)
				{
					MetalFailMessage();
					Kill();
				}
				else if (!GameSettings.Instance.HasDanger())
				{
					string text = null;
					switch (ActualProcurement)
					{
					case "Gold":
						text = "Gold Bars";
						break;
					case "Silver":
						text = "Silver Bars";
						break;
					case "Copper":
						text = "Copper Bars";
						break;
					}
					switch (ProcurementLevel)
					{
					case 1:
						text += " Level 1";
						break;
					case 2:
						text += " Level 2";
						break;
					}
					if (text != null)
					{
						HUD.Instance.BuildMode = true;
						BuildController.Instance.BeginBuildFurniture(ObjectDatabase.Instance.GetFurniture(text));
						BuildController.Instance.CurrentFurnitureBuilder.PriceOverride = Cost;
						BuildController.Instance.CurrentFurnitureBuilder.OnBuild = delegate
						{
							GameSettings.Instance.MyCompany.CurrentTaxReport.MakeIllegal();
							Kill();
						};
					}
				}
			});
			break;
		case WorkType.MoneyFunneling:
			yield return new KeyValuePair<string, Action>("Finish", delegate
			{
				Kill();
			});
			break;
		}
		if (Type != WorkType.BackgroundWork)
		{
			yield return new KeyValuePair<string, Action>("Cancel", delegate
			{
				Kill(true);
			});
		}
	}

	public override string HightlightButton()
	{
		switch (Type)
		{
		case WorkType.LoanApplication:
			if (TotalProgress >= 1f)
			{
				return "Takeloan";
			}
			break;
		case WorkType.Procurement:
			if (TotalProgress >= 1f)
			{
				return "Buy";
			}
			break;
		}
		return base.HightlightButton();
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		switch (Type)
		{
		case WorkType.BackgroundWork:
			needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Accounting", 1)] = 9999;
			break;
		case WorkType.LoanApplication:
			needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Accounting", 2)] = 9999;
			break;
		case WorkType.Procurement:
			needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Accounting", 3)] = 9999;
			break;
		case WorkType.MoneyFunneling:
			needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Accounting", 3)] = 9999;
			break;
		}
		needs.GetNeed(Employee.EmployeeRole.Service)[new HRManagement.EdNeed("Accounting", -1)] = 9999;
	}

	public override string GetTypeName()
	{
		return "AccountingWork";
	}

	public override string GetGroupType()
	{
		WorkType type = Type;
		if ((uint)(type - 1) <= 2u)
		{
			return Type.ToString();
		}
		return null;
	}

	public override string GetDetailedTypeName()
	{
		return GetGroupType().Loc() ?? base.GetDetailedTypeName();
	}

	public override string GetGroupProject()
	{
		return "Accounting".Loc();
	}

	public override bool HasProjectGrouping()
	{
		return false;
	}
}
