using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Relic_FreezeGuard : RelicTemplate_MonsterAttackPlayerBased
{
	[CompilerGenerated]
	private sealed class _003CCR_FreezeMonsters_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Relic_FreezeGuard _003C_003E4__this;

		private List<AMonsterBase> _003Clist_Monsters_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

		private float _003CmaxDist_003E5__5;

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
		public _003CCR_FreezeMonsters_003Ed__3(int _003C_003E1__state)
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

	private bool isUsedInGame;

	private Obj_FireSource fireSource;

	protected override void OnMonsterDealDamageToPlayerProc(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FreezeMonsters_003Ed__3))]
	private IEnumerator CR_FreezeMonsters()
	{
		return null;
	}
}
