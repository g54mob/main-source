using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class MasterMemoSheetWithImage : MasterMemoSheetBase
	{
		[CompilerGenerated]
		private sealed class _003CShowCoroutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MasterMemoSheetWithImage _003C_003E4__this;

			private WaitForSeconds _003Cdelay_003E5__2;

			private int _003Clength_003E5__3;

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
			public _003CShowCoroutine_003Ed__7(int _003C_003E1__state)
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
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private float _fadeTime;

		[SerializeField]
		private bool _isImageOnly;

		private bool _isFaded;

		public new void Awake()
		{
		}

		protected override void Init()
		{
		}

		public override void Show(UnityAction callback = null)
		{
		}

		[IteratorStateMachine(typeof(_003CShowCoroutine_003Ed__7))]
		protected override IEnumerator ShowCoroutine()
		{
			return null;
		}
	}
}
