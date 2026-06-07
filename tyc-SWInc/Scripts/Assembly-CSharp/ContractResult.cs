using System;
using UnityEngine;

[Serializable]
public class ContractResult
{
	public enum ContractStatus
	{
		Fulfilled = 0,
		Late = 1,
		Incomplete = 2,
		Cancelled = 3
	}

	public readonly ContractWork Contract;

	public readonly ContractStatus Status;

	public readonly float BugPenalty;

	public readonly float Income;

	public readonly float LatePenalty;

	public readonly float QualityPenalty;

	public readonly float CancelPenalty;

	public readonly float QualityResult = 1f;

	public readonly int MonthDiff;

	public readonly int Bugs;

	public readonly SDateTime Date;

	public float Result
	{
		get
		{
			return Income - BugPenalty - LatePenalty - CancelPenalty;
		}
	}

	public float FinalResult
	{
		get
		{
			return Result + (float)Contract.Initial;
		}
	}

	public int ActualMonth
	{
		get
		{
			return Contract.Months + MonthDiff;
		}
	}

	public ContractResult()
	{
	}

	public ContractResult(ContractWork work, bool cancelled)
	{
		Contract = work;
		work.LastPrinted = work.PhysicalCopies;
		uint num = ((work.PhysicalCopies > work.Goal) ? work.Goal : work.PhysicalCopies);
		Income = (work.PerPrintFactor + work.HardwarePrice) * (float)num;
		Date = SDateTime.Now();
		uint num2 = 0u;
		CancelPenalty = (float)work.PhysicalCopies * work.HardwarePrice;
		if (work.Goal > work.PhysicalCopies)
		{
			num2 = work.Goal - work.PhysicalCopies;
			bool flag = false;
			if (cancelled && work.PhysicalCopies == 0)
			{
				flag = true;
			}
			else
			{
				LatePenalty = (float)num2 * work.HardwarePrice * 0.1f;
				GameSettings.Instance.MyCompany.MakeTransaction(0f - LatePenalty, Company.TransactionCategory.Contracts, true);
				GameSettings.Instance.MyCompany.ChangeBusinessRep((0f - (1f - (float)work.PhysicalCopies / (float)work.Goal)) * 0.1f, "Contract");
			}
			if (cancelled)
			{
				if (!flag)
				{
					NotificationManager.AddNotification("ContractCancel".Loc(LatePenalty.Currency()), "Paper", NotificationManager.NotificationType.Warning);
				}
				Status = ContractStatus.Cancelled;
				return;
			}
			Status = ContractStatus.Incomplete;
		}
		else
		{
			Status = ContractStatus.Fulfilled;
		}
		NotificationManager.AddNotification(new ContractCompleteNotification(this, num2));
	}

	public ContractResult(ContractWork work, bool cancelled, int bugs, float quality, int months, float progress)
	{
		Contract = work;
		MonthDiff = months - Contract.Months * GameSettings.DaysPerMonth;
		Date = SDateTime.Now();
		Bugs = Mathf.Max(0, bugs - 10);
		QualityResult = quality / Contract.Quality;
		if (cancelled)
		{
			BugPenalty = 0f;
			Income = 0f;
			LatePenalty = 0f;
			QualityPenalty = 0f;
			CancelPenalty = Contract.Penalty;
			Status = ContractStatus.Cancelled;
			GameSettings.Instance.MyCompany.ChangeBusinessRep(0f - Contract.Months.MapRange(1f, 12f, 0.05f, 0.25f), "Contract");
			NotificationManager.AddNotification("ContractCancel".Loc(LatePenalty.Currency()), "Paper", NotificationManager.NotificationType.Warning);
		}
		else
		{
			Status = ContractStatus.Fulfilled;
			float num = Mathf.Pow(Mathf.Min(1f, progress), 3f);
			if (num < 1f)
			{
				Status = ContractStatus.Incomplete;
			}
			if (num < 0.01f)
			{
				Income = -Contract.Initial;
				QualityPenalty = Contract.Initial;
			}
			else
			{
				Income = Mathf.Round(num * (float)Contract.Done);
				QualityPenalty = Mathf.Max(0f, (float)Contract.Done - Income);
			}
			BugPenalty = (float)Bugs * Contract.PerBug;
			LatePenalty = 0f;
			if (MonthDiff > 0)
			{
				LatePenalty = Contract.Penalty;
				Status = ContractStatus.Late;
			}
			CancelPenalty = 0f;
			NotificationManager.AddNotification(new ContractCompleteNotification(this, 0u));
			float num2 = Contract.GetDevTime() * (float)GameSettings.DaysPerMonth;
			float f = quality - Contract.Quality + 0.05f;
			f = Mathf.Sign(f) * Mathf.Sqrt(f) * Contract.Quality;
			float num3 = 0f - (float)MonthDiff / num2 - (float)Bugs / Mathf.Max(2000f, num2 / (float)GameSettings.DaysPerMonth * SoftwareAlpha.BugLimitFactor) + f + 0.01f;
			GameSettings.Instance.MyCompany.ChangeBusinessRep(num3 * Contract.Months.MapRange(1f, 12f, 0.2f, 0.5f, true), "Contract");
		}
		GameSettings.Instance.MyCompany.MakeTransaction(Result, Company.TransactionCategory.Contracts, true);
	}

	public float GetRep()
	{
		float num = Contract.GetDevTime() * (float)GameSettings.DaysPerMonth;
		float num2 = QualityResult * Contract.Quality - Contract.Quality + 0.05f;
		return 0f - (float)MonthDiff / num - (float)Bugs / Mathf.Max(2000f, num / (float)GameSettings.DaysPerMonth * SoftwareAlpha.BugLimitFactor) + num2 + 0.01f;
	}

	public override string ToString()
	{
		return Contract.Company;
	}
}
