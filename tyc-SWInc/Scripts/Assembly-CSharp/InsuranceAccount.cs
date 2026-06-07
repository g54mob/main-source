using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InsuranceAccount
{
	public static double MonthlyInterest = 0.0016515813;

	public static float ContentRateStart = 0.02f;

	public static float ContentRateMax = 0.08f;

	public static float ContentRateChange = 0.02f;

	public int ContentInsurance;

	public int ActualContentInsurance;

	public float CurrentRate = ContentRateStart;

	public SDateTime LastInsuranceIncident;

	[AltWasFloat(0)]
	public double Money;

	public double FreeAccruedInterest;

	[AltWasFloat(0)]
	public List<KeyValuePair<double, SDateTime>> Deposits = new List<KeyValuePair<double, SDateTime>>();

	public void UpdateAccrued(double amount)
	{
		FreeAccruedInterest += amount - Deposits.SumSafe((KeyValuePair<double, SDateTime> x) => x.Key * MonthlyInterest);
	}

	public void RecordInsuranceIncident()
	{
		float currentRate = CurrentRate;
		CurrentRate = Mathf.Min(ContentRateMax, CurrentRate + ContentRateChange);
		if (CurrentRate > currentRate + 0.001f && (ContentInsurance > 0 || ActualContentInsurance > 0))
		{
			NotificationManager.AddNotification("InsuranceIncrease".Loc(currentRate.ToPercent(), CurrentRate.ToPercent()), "Umbrella", NotificationManager.NotificationType.Warning);
		}
		LastInsuranceIncident = SDateTime.Now();
	}

	public void UpdateInsuranceRate()
	{
		if (CurrentRate > ContentRateStart)
		{
			int monthsFlat = SDateTime.GetMonthsFlat(LastInsuranceIncident, SDateTime.Now());
			if (monthsFlat > 0 && monthsFlat % 12 == 0)
			{
				CurrentRate = Mathf.Max(ContentRateStart, CurrentRate - ContentRateChange);
			}
		}
	}

	public float GetContentBill(bool actual)
	{
		if ((actual ? ActualContentInsurance : ContentInsurance) <= 0)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < GameSettings.Instance.sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = GameSettings.Instance.sRoomManager.AllFurniture[i];
			if (furniture.CanInsure && furniture.Insured)
			{
				float num2 = 0f;
				if (furniture.CheckCanSteal())
				{
					num2 += 0.5f;
				}
				if (furniture.CanBurn())
				{
					num2 += 0.5f;
				}
				if (num2 > 0f)
				{
					num += num2 * furniture.GetCost();
				}
			}
		}
		return Mathf.RoundToInt(num * CurrentRate);
	}

	public float GetContentCoverage(bool actual)
	{
		if ((actual ? ActualContentInsurance : ContentInsurance) <= 0)
		{
			return 0f;
		}
		return 1f;
	}

	public double GetMaxWithdraw()
	{
		double num = 0.0;
		for (int i = 0; i < Deposits.Count; i++)
		{
			num += GetDepositInterest(Deposits[i]);
		}
		return Math.Floor(Money - num);
	}

	public double GetDepositInterest(KeyValuePair<double, SDateTime> deposit)
	{
		return GetDepositInterest(deposit.Key, deposit.Value);
	}

	public double GetDepositInterest(double amount, SDateTime date)
	{
		int monthsFlat = SDateTime.GetMonthsFlat(date, SDateTime.Now());
		return (Math.Pow(1.0 + MonthlyInterest, monthsFlat) - 1.0) * amount;
	}

	public double GetWithdrawCost(double amount)
	{
		double num = 0.0;
		double num2 = Money - Deposits.SumSafe((KeyValuePair<double, SDateTime> x) => x.Key + GetDepositInterest(x));
		if (amount > num2)
		{
			double num3 = amount;
			for (int num4 = Deposits.Count - 1; num4 >= 0; num4--)
			{
				KeyValuePair<double, SDateTime> keyValuePair = Deposits[num4];
				num += GetDepositInterest(Math.Min(num3, keyValuePair.Key), keyValuePair.Value);
				num3 -= keyValuePair.Key;
				if (num3 <= 0.0)
				{
					break;
				}
			}
		}
		return num;
	}

	public void Withdraw(double amount)
	{
		double num = Money - Deposits.SumSafe((KeyValuePair<double, SDateTime> x) => x.Key + GetDepositInterest(x));
		double num2 = 0.0;
		double num3 = 0.0;
		if (amount > num)
		{
			double num4 = amount;
			for (int num5 = Deposits.Count - 1; num5 >= 0; num5--)
			{
				KeyValuePair<double, SDateTime> keyValuePair = Deposits[num5];
				double depositInterest = GetDepositInterest(Math.Min(num4, keyValuePair.Key), keyValuePair.Value);
				num2 += depositInterest;
				GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Investments, 0.0 - depositInterest);
				num3 += Math.Min(keyValuePair.Key, num4);
				num4 -= keyValuePair.Key;
				if (num4 < 0.0)
				{
					Deposits[num5] = new KeyValuePair<double, SDateTime>(0.0 - num4, keyValuePair.Value);
					break;
				}
				Deposits.RemoveAt(num5);
			}
			GameSettings.Instance.MyCompany.AddToCashflow(0.0 - num2, Company.TransactionCategory.Interest);
			Money -= num2;
		}
		FreeAccruedInterest = Math.Max(0.0, FreeAccruedInterest - (amount - (num3 + num2)));
		UpdateDeposits();
		GameSettings.Instance.TransmitExtraWorth();
	}

	public void Deposit(double amount)
	{
		SDateTime sDateTime = SDateTime.Now();
		int index = Deposits.Count - 1;
		if (Deposits.Count > 0 && Deposits[index].Value.EqualsVerySimple(sDateTime))
		{
			Deposits[index] = new KeyValuePair<double, SDateTime>(Deposits[index].Key + amount, Deposits[index].Value);
		}
		else
		{
			Deposits.Add(new KeyValuePair<double, SDateTime>(amount, sDateTime));
		}
		GameSettings.Instance.TransmitExtraWorth();
	}

	public void UpdateDeposits()
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		SDateTime sDateTime = SDateTime.Now();
		int num5 = 0;
		for (int i = 0; i < Deposits.Count; i++)
		{
			KeyValuePair<double, SDateTime> deposit = Deposits[i];
			if (num != deposit.Value.RealYear)
			{
				if (num2 > 0.0)
				{
					int num6 = num + GetLockYears(num2);
					if (sDateTime.RealYear > num6 || (num6 == sDateTime.RealYear && sDateTime.Month >= num5))
					{
						FreeAccruedInterest += num3;
						int num7 = i - num4;
						Deposits.RemoveRange(num4, num7);
						i -= num7;
					}
				}
				num3 = 0.0;
				num2 = 0.0;
				num = deposit.Value.RealYear;
				num4 = i;
			}
			num2 += deposit.Key;
			num5 = deposit.Value.Month;
			num3 += GetDepositInterest(deposit);
		}
		if (num2 > 0.0)
		{
			int num8 = num + GetLockYears(num2);
			if (sDateTime.RealYear > num8 || (num8 == sDateTime.RealYear && sDateTime.Month >= num5))
			{
				FreeAccruedInterest += num3;
				Deposits.RemoveRange(num4, Deposits.Count - num4);
			}
		}
	}

	private static int GetLockYears(double amount)
	{
		return Utilities.FloorToInt(amount / 100000.0).Clamp(1, 5);
	}

	public void GetDeposits(Text l, Text c, Text r)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		stringBuilder.AppendLine("MonetaryAmount".Loc());
		stringBuilder2.AppendLine("Accruedinterest".Loc());
		stringBuilder3.AppendLine("DepositRelease".Loc());
		int num = -1;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int month = 0;
		for (int i = 0; i < Deposits.Count; i++)
		{
			KeyValuePair<double, SDateTime> deposit = Deposits[i];
			if (num != deposit.Value.Year)
			{
				if (num2 > 0.0)
				{
					int year = num + GetLockYears(num2);
					SDateTime sDateTime = new SDateTime(0, month, year);
					stringBuilder.AppendLine(num2.Currency());
					stringBuilder2.AppendLine(num4.Currency());
					stringBuilder3.AppendLine(sDateTime.ToCompactString());
				}
				num2 = 0.0;
				num4 = 0.0;
				num = deposit.Value.Year;
			}
			num3 += deposit.Key;
			num2 += deposit.Key;
			double depositInterest = GetDepositInterest(deposit);
			num3 += depositInterest;
			num4 += depositInterest;
			month = deposit.Value.Month;
		}
		if (num2 > 0.0)
		{
			int year2 = num + GetLockYears(num2);
			SDateTime sDateTime2 = new SDateTime(0, month, year2);
			stringBuilder.AppendLine(num2.Currency());
			stringBuilder2.AppendLine(num4.Currency());
			stringBuilder3.AppendLine(sDateTime2.ToCompactString());
		}
		if (Money - num3 > 1.0)
		{
			stringBuilder.AppendLine((Money - num3).Currency());
			stringBuilder2.AppendLine(FreeAccruedInterest.Currency());
			stringBuilder3.AppendLine("Freetowithdraw".Loc());
		}
		l.text = stringBuilder.ToString();
		c.text = stringBuilder2.ToString();
		r.text = stringBuilder3.ToString();
	}

	public int GetAgeGroup(float age)
	{
		return Mathf.Clamp(Mathf.FloorToInt((age - (float)Employee.Youngest) / (float)(Employee.RetirementAge - Employee.Youngest) * 3f), 0, 2);
	}

	public void ChangeAmount(double change)
	{
		if (change.IsValidDouble())
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0.0 - change, Company.TransactionCategory.NA, false);
			Money += change;
			GameSettings.Instance.TransmitExtraWorth();
		}
	}
}
