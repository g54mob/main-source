using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadIconSwitcher : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CResetMaskable_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GamepadIconSwitcher _003C_003E4__this;

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
			public _003CResetMaskable_003Ed__6(int _003C_003E1__state)
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
		private TextMeshProUGUI m_Text;

		[SerializeField]
		private string m_DefaultString;

		[SerializeField]
		private string m_GamepadString;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void SwitchText(bool isGamepad)
		{
		}

		[IteratorStateMachine(typeof(_003CResetMaskable_003Ed__6))]
		private IEnumerator ResetMaskable()
		{
			return null;
		}
	}
}
