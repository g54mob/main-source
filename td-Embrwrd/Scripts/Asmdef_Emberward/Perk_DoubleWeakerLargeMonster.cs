using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Perk_DoubleWeakerLargeMonster : APerkBase
{
	[CompilerGenerated]
	private sealed class _003CRespawnLargeMonsterAfterDelay_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public eMonsterType monsterType;

		public MonsterSpawner spawner;

		public bool isCorrupted;

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
		public _003CRespawnLargeMonsterAfterDelay_003Ed__3(int _003C_003E1__state)
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

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CRespawnLargeMonsterAfterDelay_003Ed__3))]
	private IEnumerator RespawnLargeMonsterAfterDelay(eMonsterType monsterType, MonsterSpawner spawner, bool isCorrupted, float delay)
	{
		return null;
	}
}
