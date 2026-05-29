using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UI
{
	public class MasterMemoSheetSplitTextWithImage : MasterMemoSheetSplitText
	{
		[CompilerGenerated]
		private sealed class _003CShowCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MasterMemoSheetSplitTextWithImage _003C_003E4__this;

			private WaitForSeconds _003Cdelay_003E5__2;

			private (int start, int finish) _003Cindex_003E5__3;

			private int _003Ci_003E5__4;

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
			public _003CShowCoroutine_003Ed__3(int _003C_003E1__state)
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
		private float _fadeTime;

		[SerializeField]
		private List<CanvasGroup> _canvasGroups;

		protected override void Init()
		{
		}

		[IteratorStateMachine(typeof(_003CShowCoroutine_003Ed__3))]
		protected override IEnumerator ShowCoroutine()
		{
			return null;
		}
	}
}
