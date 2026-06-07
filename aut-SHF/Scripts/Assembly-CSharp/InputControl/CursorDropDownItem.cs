using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace InputControl
{
	public class CursorDropDownItem : CursorUIBase
	{
		[CompilerGenerated]
		private sealed class _003CDelayedShowDropdown_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CursorDropDownItem _003C_003E4__this;

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
			public _003CDelayedShowDropdown_003Ed__5(int _003C_003E1__state)
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
		private TMP_Dropdown _dropdown;

		[SerializeField]
		private float _cooldownTime;

		private bool _isShow;

		private float _lastShowTime;

		public override void OnDecide()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedShowDropdown_003Ed__5))]
		private IEnumerator DelayedShowDropdown()
		{
			return null;
		}

		public void CancelDropDown()
		{
		}

		private void Update()
		{
		}
	}
}
