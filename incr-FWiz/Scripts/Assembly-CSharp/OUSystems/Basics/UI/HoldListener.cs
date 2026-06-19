using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace OUSystems.Basics.UI
{
	public class HoldListener : PressListener
	{
		[CompilerGenerated]
		private sealed class _003CAct_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HoldListener _003C_003E4__this;

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
			public _003CAct_003Ed__19(int _003C_003E1__state)
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

		private float _level;

		public float DecayDuration;

		public float HoldDuration;

		private bool _acting;

		private Coroutine _actingCoroutine;

		public bool ResetOnComplete;

		public bool WaitForNewPressOnComplete;

		public event Action AnnounceComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> AnnounceHoldProgress
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public override void OnPress()
		{
		}

		public override void OnPressEnd()
		{
		}

		public void SetLevel(float level)
		{
		}

		private void ActIfNotActing()
		{
		}

		[IteratorStateMachine(typeof(_003CAct_003Ed__19))]
		public IEnumerator Act()
		{
			return null;
		}

		public virtual void CompleteHold()
		{
		}
	}
}
