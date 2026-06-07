using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_ShockBot : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_ShockBot _003C_003E4__this;

		public ABaseTower targetTower;

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
		public _003CCR_Cast_003Ed__12(int _003C_003E1__state)
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
	private float skillTriggerRange;

	[SerializeField]
	private ParticleSystem particle_ElectricShock;

	[SerializeField]
	private List<ABaseTower> list_AttackedTowers;

	private float detectInterval;

	private float detectTimer;

	private float skillCooldown;

	private float skillCooldownTimer;

	private bool isSkillUsed;

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__12))]
	private IEnumerator CR_Cast(ABaseTower targetTower)
	{
		return null;
	}
}
