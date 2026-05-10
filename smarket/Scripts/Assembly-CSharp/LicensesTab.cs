using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class LicensesTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGamePadCheck_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LicensesTab _003C_003E4__this;

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
		public _003CGamePadCheck_003Ed__19(int _003C_003E1__state)
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
	private LicenseItem m_LicenseItemPrefab;

	[SerializeField]
	private LicenseItem m_LicenseItemDlcPrefab;

	[SerializeField]
	private Transform m_LicensesContent;

	[SerializeField]
	private GameObject m_PurchasedAllText;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private WindowTab m_tab;

	private List<LicenseItem> m_LicenseItems;

	private bool m_IsInitialized;

	private Coroutine m_GamePadCheckCoroutine;

	public List<LicenseItem> LicenseItems => null;

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

	private void OnPurchasedLicense(int id)
	{
	}

	private void OnLicenseManagerDisabled()
	{
	}

	private void CheckLicenseCount(int index = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CGamePadCheck_003Ed__19))]
	private IEnumerator GamePadCheck(int index = 0)
	{
		return null;
	}

	private void SortByRequiredLevelAndArrange()
	{
	}
}
