using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class LoansTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedGamepadCheck_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LoansTab _003C_003E4__this;

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
		public _003CDelayedGamepadCheck_003Ed__18(int _003C_003E1__state)
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

	[SerializeField]
	private LoanItem m_LoanItemPrefab;

	[SerializeField]
	private Transform m_LoanItemsContent;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private WindowTab m_tab;

	public List<LoanItem> m_LoanItems;

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

	public void SpawnLoanItems()
	{
	}

	private void UpdateActiveLoanItems()
	{
	}

	private void OnLoanTaken(int loanID)
	{
	}

	private void OnLoanCompleted(int loanID)
	{
	}

	private void OnBillDataChanged(PlayerPaymentData _billData, bool _isAdded)
	{
	}

	private void UnsubscribeOnBillDataChanged()
	{
	}

	private void GamepadCheck(int index = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGamepadCheck_003Ed__18))]
	private IEnumerator DelayedGamepadCheck(int index = 0)
	{
		return null;
	}

	private void InstantGamepadCheck(int index = 0)
	{
	}
}
