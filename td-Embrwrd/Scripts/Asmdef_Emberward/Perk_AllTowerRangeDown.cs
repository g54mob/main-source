using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Perk_AllTowerRangeDown : PerkTemplate_TowerBuff
{
	[CompilerGenerated]
	private sealed class _003CCR_BuffEffect_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<ABaseTower> towers;

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
		public _003CCR_BuffEffect_003Ed__2(int _003C_003E1__state)
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

	private List<ABaseTower> list_BuffedTowers;

	protected override void OnEnableProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BuffEffect_003Ed__2))]
	private IEnumerator CR_BuffEffect(List<ABaseTower> towers)
	{
		return null;
	}

	protected override void OnDisableProc()
	{
	}

	protected override bool TowerValidCondition(ABaseTower tower)
	{
		return false;
	}
}
