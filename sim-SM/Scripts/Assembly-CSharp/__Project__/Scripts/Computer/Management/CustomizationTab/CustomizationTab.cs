using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Management.CustomizationTab
{
	public class CustomizationTab : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGamePadCheckDelayed_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomizationTab _003C_003E4__this;

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
			public _003CGamePadCheckDelayed_003Ed__14(int _003C_003E1__state)
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
		private GamepadSelectableParent m_gamepadSelectableParent;

		[SerializeField]
		private WindowTab m_tab;

		[SerializeField]
		private GameObject m_firstSelected;

		private bool m_UpgradedStore => false;

		private void Start()
		{
		}

		public void InitializeClientPlayer()
		{
		}

		private void OnEnable()
		{
		}

		public void SetEventsFromOutside()
		{
		}

		private void OnSectionPurchased(int id)
		{
		}

		private void UpdateUI()
		{
		}

		private void GamepadControl()
		{
		}

		[IteratorStateMachine(typeof(_003CGamePadCheckDelayed_003Ed__14))]
		private IEnumerator GamePadCheckDelayed()
		{
			return null;
		}

		private void GamepadCheckInstant()
		{
		}
	}
}
