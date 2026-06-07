using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_FireElemental : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_FireElemental _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private float _003CexplodeRadius_003E5__4;

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
		public _003CCR_Cast_003Ed__19(int _003C_003E1__state)
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
	private ParticleSystem particle_BodyFlame;

	[SerializeField]
	private ParticleSystem particle_Charge;

	[SerializeField]
	private ParticleSystem particle_Explode;

	[SerializeField]
	private float skillTriggerHPThreshold;

	[SerializeField]
	private float skillChargeTime;

	[SerializeField]
	private float skillExplodeRange;

	private bool isExploded;

	private bool isSkillUsed;

	private int chargeSndIndex;

	private bool isHardModeActive;

	private float finalSkillTriggerHPThreshold;

	private float finalSkillChargeTime;

	private Vector3 chargeParticleOriginalScale;

	private Vector3 explodeParticleOriginalScale;

	protected override void Awake()
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void DespawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__19))]
	private IEnumerator CR_Cast()
	{
		return null;
	}
}
