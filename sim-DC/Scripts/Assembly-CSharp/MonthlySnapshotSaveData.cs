using System;
using System.Collections.Generic;

[Serializable]
public class MonthlySnapshotSaveData
{
	public int month;

	public int day;

	public List<CustomerRecordSaveData> records;

	public float salaryExpense;
}
