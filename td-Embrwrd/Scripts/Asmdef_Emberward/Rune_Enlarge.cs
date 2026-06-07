using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Rune_Enlarge : ARune
{
	[CompilerGenerated]
	private sealed class _003CCR_DelaySpawn_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_DelaySpawn_003Ed__1(int _003C_003E1__state)
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

	protected override void SpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelaySpawn_003Ed__1))]
	private IEnumerator CR_DelaySpawn()
	{
		return null;
	}

	protected override void DespawnProc()
	{
	}

	protected override void PlacementPreviewProc()
	{
	}
}
