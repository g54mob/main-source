using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace OUSystems.Basics
{
	public class DeveloperConsoleUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFocusInputAfterTime_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DeveloperConsoleUI _003C_003E4__this;

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
			public _003CFocusInputAfterTime_003Ed__7(int _003C_003E1__state)
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

		public TMP_InputField InputField;

		public TextMeshProUGUI LogsText;

		public int commandHistoryIndex;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void NavigateCommandHistory(int delta)
		{
		}

		private void OnEndEditing(string input)
		{
		}

		[IteratorStateMachine(typeof(_003CFocusInputAfterTime_003Ed__7))]
		private IEnumerator FocusInputAfterTime()
		{
			return null;
		}

		public void FocusInput()
		{
		}

		public void OnAddLog(string log)
		{
		}

		public void OnSubmit(string input)
		{
		}
	}
}
