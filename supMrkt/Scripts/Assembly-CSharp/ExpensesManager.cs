using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;

public class ExpensesManager : NoktaSingleton<ExpensesManager>
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ExpensesManager _003C_003E4__this;

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
		public _003CStart_003Ed__27(int _003C_003E1__state)
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

	[Separator("Expenses Settings", false)]
	[SerializeField]
	private ExpensesSO m_ExpensesSettings;

	private float m_DailyRentAmount;

	private bool m_IncreaseBills;

	private List<PlayerPaymentData> m_BillDatas;

	private List<PlayerPaymentData> m_RentDatas;

	public Action<PlayerPaymentData, bool> OnBillDataChanged;

	public Action OnDisabled;

	private BillsTab m_BillsTab;

	public List<PlayerPaymentData> BillDatas
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<PlayerPaymentData> RentDatas
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float BillAmount
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float RentAmount => 0f;

	public int BillPaymentDueDate => 0;

	public List<PlayerPaymentData> OverdueBills => null;

	private float m_CurrentBillAmount
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private bool TooLateToIncreaseBills => false;

	[IteratorStateMachine(typeof(_003CStart_003Ed__27))]
	private IEnumerator Start()
	{
		return null;
	}

	public void LoadSaveProgress()
	{
	}

	private void OnDestroy()
	{
	}

	public void IncreaseDailyBill(ExpenseType type)
	{
	}

	public void PayBill(PlayerPaymentData billData, bool byForce = false)
	{
	}

	public void PayBill_Order(PlayerPaymentData billData, bool byForce)
	{
	}

	private void InitializeCanvas()
	{
	}

	private void AddBill()
	{
	}

	public void AddBill_Order(PlayerPaymentData data, bool isBill)
	{
	}

	private void RemoveBill(PlayerPaymentData billData)
	{
	}

	private void LoadDailyRentData()
	{
	}

	public void LoadBillDatas()
	{
	}

	public List<PlayerPaymentData> GetBills(PlayerPaymentType paymentType)
	{
		return null;
	}

	private void OnSectionPurchased(int id)
	{
	}

	private void OnSectionManagerDisabled()
	{
	}

	private void CheckIfDaysOver()
	{
	}

	private void CheckIfDayStarted(bool open)
	{
	}

	private void OnDayCycleDisabled()
	{
	}
}
