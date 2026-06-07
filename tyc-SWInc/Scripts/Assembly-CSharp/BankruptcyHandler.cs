using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BankruptcyHandler
{
	public class BankruptcyAction
	{
		public string Name;

		public Func<double> Available;

		public Func<double, double> Invoke;

		public BankruptcyAction(string name, Func<double> available, Func<double, double> invoke)
		{
			Name = name;
			Available = available;
			Invoke = invoke;
		}
	}

	private static List<BankruptcyAction> Actions = new List<BankruptcyAction>
	{
		new BankruptcyAction("Bonds", () => GameSettings.Instance.Insurance.GetMaxWithdraw(), BondsAction),
		new BankruptcyAction("Investments", () => GameSettings.Instance.Investments.SumSafe((Investment x) => x.CurrentValue), InvestmentAction),
		new BankruptcyAction("Inventory", () => GameSettings.Instance.FurnitureInventory.SumSafe((KeyValuePair<string, List<InventoryItem>> x) => x.Value.SumSafe((InventoryItem z) => z.SellPrice())) + GameSettings.Instance.Awards.SumSafe((AwardTrophy.AwardData x) => AwardTrophy.GetAwardWorth(x.Tier, x.Year)), InventoryAction),
		new BankruptcyAction("Stocks", () => GameSettings.Instance.MyCompany.NewOwnedStock.SumSafe((NewStock x) => (!(x.Seller is FounderShareHolder)) ? x.TotalWorth : 0.0), StockAction),
		new BankruptcyAction("Subsidiaries", () => GameSettings.Instance.MyCompany.GetSubsidiaries().SumSafe((Company x) => x.Money), SubsidiaryAction),
		new BankruptcyAction("Loans", () => (float)HUD.Instance.loanWindow.MaxLoan(0) * 10000f, LoanAction)
	};

	private static double BondsAction(double needed)
	{
		double num = Math.Min(needed, GameSettings.Instance.Insurance.GetMaxWithdraw());
		GameSettings.Instance.Insurance.Withdraw(num);
		GameSettings.Instance.Insurance.ChangeAmount(0.0 - num);
		HUD.Instance.insuranceWindow.ResetTexts();
		return num;
	}

	private static double LoanAction(double needed)
	{
		int num = (int)Math.Ceiling(Math.Min(needed, (float)HUD.Instance.loanWindow.MaxLoan(0) * 10000f) / 10000.0);
		if (num > 0)
		{
			LoanWindow.TakeLoan(LoanWindow.GetMaxPeriod(num), num, 0);
		}
		return (float)num * 10000f;
	}

	private static double InvestmentAction(double needed)
	{
		double num = 0.0;
		foreach (Investment item in GameSettings.Instance.Investments.OrderBy((Investment x) => x.CurrentValue).ToList())
		{
			num += (double)item.CurrentValue;
			needed -= (double)item.CurrentValue;
			GameSettings.Instance.MyCompany.MakeTransaction(item.CurrentValue, Company.TransactionCategory.Stocks, false, item.Stock.Name);
			if (item.LastTaxValue >= 0f)
			{
				GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Investments, item.CurrentValue - item.LastTaxValue);
			}
			GameSettings.Instance.RegisterStat("StockExchange", item.CurrentValue - item.Amount);
			GameSettings.Instance.Investments.Remove(item);
			if (needed <= 0.0)
			{
				break;
			}
		}
		HUD.Instance.insuranceWindow.UpdateInvestments();
		return num;
	}

	private static double InventoryAction(double needed)
	{
		double num = 0.0;
		foreach (KeyValuePair<string, List<InventoryItem>> item in GameSettings.Instance.FurnitureInventory)
		{
			for (int num2 = item.Value.Count - 1; num2 >= 0; num2--)
			{
				InventoryItem inventoryItem = item.Value[num2];
				if (!inventoryItem.Offshore)
				{
					float num3 = inventoryItem.SellPrice();
					if (num3 > 0f)
					{
						num += (double)num3;
						needed -= (double)num3;
						item.Value.RemoveAt(num2);
						if (needed <= 0.0)
						{
							break;
						}
					}
				}
			}
			if (needed <= 0.0)
			{
				break;
			}
		}
		if (needed > 0.0)
		{
			for (int num4 = GameSettings.Instance.Awards.Count - 1; num4 >= 0; num4--)
			{
				AwardTrophy.AwardData awardData = GameSettings.Instance.Awards[num4];
				awardData.RemoveFromSearch();
				float awardWorth = AwardTrophy.GetAwardWorth(awardData.Tier, awardData.Year);
				num += (double)awardWorth;
				needed -= (double)awardWorth;
				GameSettings.Instance.MyCompany.MakeTransaction(awardWorth, Company.TransactionCategory.Construction, true, "Recycle");
				GameSettings.Instance.Awards.RemoveAt(num4);
				if (needed <= 0.0)
				{
					break;
				}
			}
			HUD.Instance.UpdateAwardButtons();
		}
		GameSettings.Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, false, "Furniture");
		GameSettings.Instance.RefreshAllInventoryCounts();
		return num;
	}

	private static double StockAction(double needed)
	{
		List<NewStock> list = GameSettings.Instance.MyCompany.NewOwnedStock.ToList();
		double num = 0.0;
		foreach (NewStock item in list)
		{
			if (item.Seller is FounderShareHolder)
			{
				continue;
			}
			double shareWorth = item.ShareWorth;
			uint num2 = Math.Min(item.Shares, (uint)Math.Ceiling(needed / shareWorth));
			if (num2 != 0)
			{
				num += (double)num2 * shareWorth;
				needed -= (double)num2 * shareWorth;
				MarketSimulation.Active.FindBuyer(item, num2, SDateTime.Now());
				if (needed <= 0.0)
				{
					break;
				}
			}
		}
		return num;
	}

	private static double SubsidiaryAction(double needed)
	{
		List<Company> list = GameSettings.Instance.MyCompany.GetSubsidiaries().ToList();
		double num = 0.0;
		foreach (Company item in list)
		{
			double num2 = Math.Min(needed, item.Money);
			num += num2;
			needed -= num2;
			GameSettings.Instance.MyCompany.MakeTransaction(num2, Company.TransactionCategory.Intercompany, false);
			item.MakeTransaction(0.0 - num2, Company.TransactionCategory.Intercompany, false);
			if (item.Money < 1.0)
			{
				item.MakeTransaction(-3.0, Company.TransactionCategory.NA, false);
			}
			if (needed <= 0.0)
			{
				break;
			}
		}
		return num;
	}

	public static double GetMax()
	{
		return Actions.SumSafe((BankruptcyAction x) => x.Available());
	}

	public static string Execute(double needed)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("BankruptAutoResult".Loc() + ":");
		foreach (BankruptcyAction action in Actions)
		{
			double num = action.Invoke(needed);
			if (num > 0.0)
			{
				stringBuilder.AppendLine(action.Name.Loc().FontBold() + ": " + num.Currency());
			}
			needed -= num;
			if (needed <= 0.0)
			{
				break;
			}
		}
		GameSettings.Instance.TransmitExtraWorth();
		return stringBuilder.ToString().TrimEnd();
	}
}
