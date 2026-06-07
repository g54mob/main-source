using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Relic_AdaptiveBlueprint : RelicTemplate_RoundEndBased
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Relic_AdaptiveBlueprint _003C_003E4__this;

		private int _003CdiscardCount_003E5__2;

		private List<CardData> _003ChandCard_003E5__3;

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
		public _003CCR_Proc_003Ed__1(int _003C_003E1__state)
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

	protected override void OnRoundEndProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__1))]
	private IEnumerator CR_Proc()
	{
		return null;
	}
}
