using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace ScheduleOne
{
	public class UIPopupScreen_ConfirmationMenu : UIPopupScreen
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass8_0
		{
			public Action onConfirm;

			public UIPopupScreen_ConfirmationMenu _003C_003E4__this;

			public Action onCancel;

			internal void _003CRegisterInput_003Eb__0()
			{
			}

			internal void _003CRegisterInput_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRegisterInput_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action onConfirm;

			public UIPopupScreen_ConfirmationMenu _003C_003E4__this;

			public Action onCancel;

			private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

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
			public _003CRegisterInput_003Ed__8(int _003C_003E1__state)
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
		private TMP_Text titleText;

		[SerializeField]
		private TMP_Text messageText;

		[SerializeField]
		private UISelectable confirmButton;

		[SerializeField]
		private UISelectable cancelButton;

		[SerializeField]
		private Canvas canvas;

		public override void Close()
		{
		}

		private void Open()
		{
		}

		public override void Open(params object[] args)
		{
		}

		[IteratorStateMachine(typeof(_003CRegisterInput_003Ed__8))]
		private IEnumerator RegisterInput(Action onConfirm, Action onCancel)
		{
			return null;
		}

		private void SelectPanel(UISelectable selectable)
		{
		}
	}
}
