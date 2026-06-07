using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class MasterMemoSheetBase : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CShowCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MasterMemoSheetBase _003C_003E4__this;

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
			public _003CShowCoroutine_003Ed__13(int _003C_003E1__state)
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
		protected TMP_Text _text;

		[SerializeField]
		protected float _textSpan;

		protected Coroutine _showCoroutine;

		protected UnityAction _callback;

		public bool HaveText => false;

		public virtual bool EnoughMessages => false;

		public void Awake()
		{
		}

		public virtual void ClearMessages()
		{
		}

		public virtual void SetMessage(string message)
		{
		}

		public virtual void Show(UnityAction callback = null)
		{
		}

		protected virtual void Init()
		{
		}

		[IteratorStateMachine(typeof(_003CShowCoroutine_003Ed__13))]
		protected virtual IEnumerator ShowCoroutine()
		{
			return null;
		}
	}
}
