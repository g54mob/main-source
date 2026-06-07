using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_SpikyBot : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Deaccelerate_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_SpikyBot _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_Deaccelerate_003Ed__6(int _003C_003E1__state)
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

	[SerializeField]
	private ParticleSystem particle_deacclerateDust;

	[SerializeField]
	private float startSpeedMultiplier;

	private bool isAttacked;

	protected override void SpawnProc()
	{
	}

	public override void Hit(int damage, float baseCritChance, eDamageType damageType, ABaseTower tower, bool hideDamageNumber = false, bool doTriggerHitReaction = true)
	{
	}

	public override void Hit(int damage, eDamageType damageType, Action<AMonsterBase> OnKillCallback = null, ABaseTower fromTower = null, bool hideDamageNumber = false, bool doTriggerHitReaction = true, float baseCritChance = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Deaccelerate_003Ed__6))]
	public IEnumerator CR_Deaccelerate()
	{
		return null;
	}

	public void RemoveRunSpeed()
	{
	}
}
