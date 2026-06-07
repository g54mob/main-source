using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace InputControl
{
	public class AutoCursorUIGroupSelector : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedEnableRoutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AutoCursorUIGroupSelector _003C_003E4__this;

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
			public _003CDelayedEnableRoutine_003Ed__5(int _003C_003E1__state)
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
		private List<CursorUIGroup> _cursorUIGroups;

		[SerializeField]
		private CursorUIGroup _defaultCursorUIGroup;

		[SerializeField]
		private bool _delayOnEnable;

		private CursorUIGroup _currentCursorUIGroup;

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedEnableRoutine_003Ed__5))]
		private IEnumerator DelayedEnableRoutine()
		{
			return null;
		}

		private void EnableImmediate()
		{
		}

		public void SelectGroup()
		{
		}

		public void SetSelectGroup(CursorUIGroup group)
		{
		}
	}
}
