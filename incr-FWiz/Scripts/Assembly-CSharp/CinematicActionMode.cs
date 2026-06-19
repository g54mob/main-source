using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CinematicActionMode : PlayerActionMode
{
	[CompilerGenerated]
	private sealed class _003CDoCinematicEnumerator_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CinematicEvent cinematicEvent;

		public Action action;

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
		public _003CDoCinematicEnumerator_003Ed__6(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CDoCinematicEnumerator_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CinematicActionMode _003C_003E4__this;

		public IEnumerator cinematicEvent;

		public Action action;

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
		public _003CDoCinematicEnumerator_003Ed__7(int _003C_003E1__state)
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

	private bool _doingCinematic;

	private Coroutine _coroutine;

	public override bool PlayerCanMove => false;

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}

	[IteratorStateMachine(typeof(_003CDoCinematicEnumerator_003Ed__6))]
	private IEnumerator DoCinematicEnumerator(CinematicEvent cinematicEvent, Action action)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDoCinematicEnumerator_003Ed__7))]
	private IEnumerator DoCinematicEnumerator(IEnumerator cinematicEvent, Action action = null)
	{
		return null;
	}

	public void StartCinematic(CinematicEvent cinematicEvent)
	{
	}

	public void StartCinematic(IEnumerator cinematicEvent)
	{
	}

	public void CancelCinematic()
	{
	}

	private void EndCinematic()
	{
	}
}
