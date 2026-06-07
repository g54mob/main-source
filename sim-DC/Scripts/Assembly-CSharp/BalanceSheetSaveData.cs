using System;
using System.Collections.Generic;

[Serializable]
public class BalanceSheetSaveData
{
	public List<MonthlySnapshotSaveData> history;

	public List<CustomerRecordSaveData> currentRecords;

	public float totalMonthlySalary;

	public float currentSalaryExpense;
}
