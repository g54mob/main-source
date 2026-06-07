using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class LargeMultiOptionSavePopup : LargeMultiOptionPopup
	{
		[CompilerGenerated]
		private sealed class _003CFrameDelays_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LargeMultiOptionSavePopup _003C_003E4__this;

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
			public _003CFrameDelays_003Ed__2(int _003C_003E1__state)
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
		private GameObject _CancelButton;

		public void Initialize(string id, string title, string description, List<SaveOptionDataSet> options, Action<int> callback, bool hasCancelButton = false, Action onCancel = null)
		{
		}

		[IteratorStateMachine(typeof(_003CFrameDelays_003Ed__2))]
		private IEnumerator FrameDelays()
		{
			return null;
		}
	}
}
