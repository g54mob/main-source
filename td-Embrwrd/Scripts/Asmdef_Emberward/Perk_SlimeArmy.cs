using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Perk_SlimeArmy : APerkBase
{
	[CompilerGenerated]
	private sealed class _003CCR_SpawnSlime_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase monster;

		public Perk_SlimeArmy _003C_003E4__this;

		private Vector3 _003Cposition_003E5__2;

		private bool _003CisCorrupted_003E5__3;

		private int _003CspawnNodeIndex_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003CCR_SpawnSlime_003Ed__4(int _003C_003E1__state)
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

	private int spawnCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnSlime_003Ed__4))]
	private IEnumerator CR_SpawnSlime(AMonsterBase monster)
	{
		return null;
	}
}
