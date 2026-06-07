using System;
using System.Collections.Generic;

[Serializable]
public class DaySummaryData
{
	public int gameDay;

	public Dictionary<EconomyType, int> incomeByType;

	public Dictionary<EconomyType, int> expenseByType;

	public Dictionary<EconomyType, int> xpByType;

	public int totalIncome;

	public int totalExpense;

	public int netProfit;

	public int startMoney;

	public int endMoney;

	public int totalXP;

	public int startLevel;

	public int endLevel;

	public bool HasLeveledUp => endLevel > startLevel;

	public int LevelsGained => endLevel - startLevel;
}
