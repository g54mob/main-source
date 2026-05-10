using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class StorageTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGamePadCheck_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StorageTab _003C_003E4__this;

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
		public _003CGamePadCheck_003Ed__23(int _003C_003E1__state)
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
	private GameObject m_LockedUI;

	[SerializeField]
	private GameObject m_UnlockedUI;

	[SerializeField]
	private TMP_Text m_CostText;

	[SerializeField]
	private Button m_PurchaseButton;

	[Space]
	[SerializeField]
	private float m_Cost;

	[Header("Gamepad Handlers")]
	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private WindowTab m_tab;

	[Header("Components")]
	[SerializeField]
	private StorageSectionItem m_StorageSectionItemPrefab;

	[SerializeField]
	private Transform m_StorageSectionsContent;

	[SerializeField]
	private List<StorageSectionItem> m_StorageSectionItems;

	[SerializeField]
	private GameObject m_PurchasedAllText;

	private bool m_PurcasedStorage => false;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void Purchase()
	{
	}

	public void CheckStorageSections()
	{
	}

	public void UpdateUI()
	{
	}

	private void UpdatePurchaseButton(float _amount, MoneyManager.TransitionType _type)
	{
	}

	private void UnsubscribeMoneyManager()
	{
	}

	private void OnPurchasedStorageSection(int id)
	{
	}

	private void OnSectionManagerDisabled()
	{
	}

	private void CheckStorageSecitonsCount(int index = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CGamePadCheck_003Ed__23))]
	private IEnumerator GamePadCheck(int index = 0)
	{
		return null;
	}
}
