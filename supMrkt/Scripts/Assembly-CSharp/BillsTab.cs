using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class BillsTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedGamepadControl_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BillsTab _003C_003E4__this;

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
		public _003CDelayedGamepadControl_003Ed__27(int _003C_003E1__state)
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
	private BillItem m_BillItemPrefab;

	[SerializeField]
	private Transform m_BillsContent;

	[SerializeField]
	private BillItem m_RentItemPrefab;

	[SerializeField]
	private Transform m_RentsContent;

	[SerializeField]
	private GameObject m_NoBills;

	[SerializeField]
	private GameObject m_NoRents;

	[SerializeField]
	private WindowTab m_tab;

	[SerializeField]
	private GamepadSelectableParentBill m_gamepadSelectableParent;

	private List<BillItem> m_BillItems;

	private List<BillItem> m_RentItems;

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

	private void OnBillDataChanged(PlayerPaymentData billData, bool isAdded)
	{
	}

	private void OnExpenseManagerDisabled()
	{
	}

	private void LoadBillDatas()
	{
	}

	private void SpawnBillItem(PlayerPaymentData billData)
	{
	}

	private void RemoveBillItem(PlayerPaymentData billData)
	{
	}

	private void CheckIfAnyBillsLeft()
	{
	}

	private void OnNewDayStarted()
	{
	}

	private void UnsubscribeDayCycle()
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

	[IteratorStateMachine(typeof(_003CDelayedGamepadControl_003Ed__27))]
	private IEnumerator DelayedGamepadControl(int index = 0)
	{
		return null;
	}

	private void InstantGamepadControl(int index = 0)
	{
	}
}
