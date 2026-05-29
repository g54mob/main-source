using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AeLa.EasyFeedback.Utility
{
	[RequireComponent(typeof(FormElement))]
	public class SetSelectedOnOpen : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSetSelfAsSelected_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SetSelectedOnOpen _003C_003E4__this;

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
			public _003CSetSelfAsSelected_003Ed__5(int _003C_003E1__state)
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

		private FeedbackForm form;

		private Coroutine coroutine;

		private void Awake()
		{
		}

		private void StartSelectedCoroutine()
		{
		}

		private void StopCoroutineIfExists()
		{
		}

		[IteratorStateMachine(typeof(_003CSetSelfAsSelected_003Ed__5))]
		private IEnumerator SetSelfAsSelected()
		{
			return null;
		}
	}
}
