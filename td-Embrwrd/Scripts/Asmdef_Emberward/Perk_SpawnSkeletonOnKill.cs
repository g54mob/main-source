using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Perk_SpawnSkeletonOnKill : APerkBase
{
	[CompilerGenerated]
	private sealed class _003CCR_SpawnSkeletons_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase monster;

		private bool _003CisCorrupted_003E5__2;

		private Vector3 _003CspawnPosition_003E5__3;

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
		public _003CCR_SpawnSkeletons_003Ed__4(int _003C_003E1__state)
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

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnSkeletons_003Ed__4))]
	private IEnumerator CR_SpawnSkeletons(AMonsterBase monster)
	{
		return null;
	}
}
