using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class GrowthTab : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CGamepadCheck_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GrowthTab _003C_003E4__this;

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
		public _003CGamepadCheck_003Ed__11(int _003C_003E1__state)
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
	private GrowthSectionItem m_GrowthSectionItemPrefab;

	[SerializeField]
	private Transform m_GrowthSectionsContent;

	[SerializeField]
	private List<GrowthSectionItem> m_GrowthSectionItems;

	[SerializeField]
	private GameObject m_PurchasedAllText;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	[SerializeField]
	private WindowTab m_tab;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnPurchasedSection(int id)
	{
	}

	private void OnSectionManagerDisabled()
	{
	}

	private void CheckSecitonsCount(int index = 0)
	{
	}

	[IteratorStateMachine(typeof(_003CGamepadCheck_003Ed__11))]
	private IEnumerator GamepadCheck(int index = 0)
	{
		return null;
	}
}
