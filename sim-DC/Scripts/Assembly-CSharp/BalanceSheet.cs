using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BalanceSheet : MonoBehaviour
{
	[Serializable]
	public class CustomerRecord
	{
		public int customerID;

		public string customerName;

		public Sprite customerLogo;

		public float revenue;

		public float penalties;

		public float Total => 0f;
	}

	[Serializable]
	public class MonthlySnapshot
	{
		public int month;

		public int day;

		public List<CustomerRecord> records;

		public float salaryExpense;

		public float TotalRevenue => 0f;

		public float TotalPenalties => 0f;

		public float GrandTotal => 0f;
	}

	[CompilerGenerated]
	private sealed class _003CTrackFinances_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BalanceSheet _003C_003E4__this;

		private DateTime _003ClastSnapshotTime_003E5__2;

		private int _003CcurrentMonth_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CTrackFinances_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static BalanceSheet instance;

	public List<MonthlySnapshot> history;

	private Dictionary<int, CustomerRecord> currentRecords;

	public float totalMonthlySalary;

	private float currentSalaryExpense;

	[SerializeField]
	private GameObject rowPrefab;

	[SerializeField]
	private Transform rowContainer;

	private List<GameObject> activeRows;

	private Coroutine trackFinancesCoroutine;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private CustomerRecord GetOrCreateRecord(CustomerItem item)
	{
		return null;
	}

	public void RegisterSalary(int monthlySalary)
	{
	}

	[IteratorStateMachine(typeof(_003CTrackFinances_003Ed__16))]
	private IEnumerator TrackFinances()
	{
		return null;
	}

	private int CountFailingApps(CustomerBase cb)
	{
		return 0;
	}

	private void SaveSnapshot(int month, DateTime snapshotTime)
	{
	}

	public MonthlySnapshot GetLatestSnapshot()
	{
		return null;
	}

	public void FillInBalanceSheet()
	{
	}

	private void AddRow(string name, float revenue, float penalties, float total, Sprite logo = null)
	{
	}

	private void AddSalaryRow(float salaryExpense)
	{
	}

	private void AddTotalRow(float revenue, float penalties, float total)
	{
	}

	private void AddHeaderRow()
	{
	}

	private void AddSectionTitle(string title)
	{
	}

	private BalanceSheetRow InstantiateRow()
	{
		return null;
	}

	private void ClearRows()
	{
	}

	public BalanceSheetSaveData GetSaveData()
	{
		return null;
	}

	private void LoadFromSave()
	{
	}

	private CustomerRecord RestoreRecord(CustomerRecordSaveData recData)
	{
		return null;
	}
}
