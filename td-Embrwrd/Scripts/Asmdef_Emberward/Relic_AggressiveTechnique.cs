using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Relic_AggressiveTechnique : RelicTemplate_TetrisBased
{
	[CompilerGenerated]
	private sealed class _003CCR_StunEffect_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock block;

		public Relic_AggressiveTechnique _003C_003E4__this;

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
		public _003CCR_StunEffect_003Ed__1(int _003C_003E1__state)
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

	protected override void OnTetrisPlacedProc(Obj_TetrisBlock block)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_StunEffect_003Ed__1))]
	private IEnumerator CR_StunEffect(Obj_TetrisBlock block)
	{
		return null;
	}
}
