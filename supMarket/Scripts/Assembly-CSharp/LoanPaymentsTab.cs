using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class LoanPaymentsTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedGamepadControls_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoanPaymentsTab _003C_003E4__this;

		public int index;

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
		public _003CDelayedGamepadControls_003Ed__31(int _003C_003E1__state)
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

	[Header("Components")]
	[SerializeField]
	private LoanRepaymentItem m_RepaymentItemPrefab;

	[SerializeField]
	private Transform m_RepaymentsContent;

	[SerializeField]
	private GameObject m_NoRepayments;

	[Header("Loan Details")]
	[SerializeField]
	private TMP_Text m_LoansTakenText;

	[SerializeField]
	private TMP_Text m_PaymentsRemainingText;

	[SerializeField]
	private TMP_Text m_LatePaymentFeeText;

	[SerializeField]
	private TMP_Text m_TotalDebtText;

	private List<LoanRepaymentItem> m_RepaymentItems;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private WindowTab m_tab;

	private bool m_IsInitialized;

	public bool IsInitialized => false;

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	private void OnEnable()
	{
	}

	private void LoadBillDatas()
	{
	}

	private void SpawnBillItem(PlayerPaymentData repaymentData)
	{
	}

	private void RemoveBillItem(PlayerPaymentData repaymentData)
	{
	}

	private void CheckIfAnyRepaymentsLeft(int index = 0)
	{
	}

	private void UpdateLoansTaken(int _)
	{
	}

	private void UpdatePaymentsRemaining(int _)
	{
	}

	private void UpdateLatePaymentFee()
	{
	}

	private void UpdateTotalDebt(int _)
	{
	}

	private void OnNewDayStarted()
	{
	}

	private void UnsubscribeDayCycle()
	{
	}

	private void OnBillDataChanged(PlayerPaymentData billData, bool isAdded)
	{
	}

	private void UnsubscribeBankManager()
	{
	}

	private void UpdatePayButtons(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void UnsubscribeMoneyTransition()
	{
	}

	private void GamepadControls(int index = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGamepadControls_003Ed__31))]
	private IEnumerator DelayedGamepadControls(int index = 0)
	{
		return null;
	}

	private void InstantGamepadControls(int index = 0)
	{
	}
}
