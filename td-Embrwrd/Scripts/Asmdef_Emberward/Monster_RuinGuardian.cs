using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_RuinGuardian : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_RuinGuardian _003C_003E4__this;

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
		public _003CCR_Cast_003Ed__29(int _003C_003E1__state)
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
	private float skillInterval;

	[SerializeField]
	private float skillRange;

	[SerializeField]
	private float healPercentagePerTick_Casual;

	[SerializeField]
	private float healPercentagePerTick_Normal;

	[SerializeField]
	private float healPercentagePerTick_Hard;

	[SerializeField]
	private float skillActivateTime;

	[SerializeField]
	private int maxHealPointPerTick_Casual;

	[SerializeField]
	private int maxHealPointPerTick_Normal;

	[SerializeField]
	private int maxHealPointPerTick_Hard;

	[SerializeField]
	private float skillTimer;

	[SerializeField]
	private ParticleSystem particle_HealAura;

	[SerializeField]
	private ParticleSystem particle_HealTick;

	private int skillCastCount;

	private bool isHealActivated;

	[SerializeField]
	private float healTickInterval;

	private float healTickTimer;

	private float skillActivateTimer;

	private float healPercentagePerTick;

	private int maxHealPointPerTick;

	private float finalSkillRange;

	private bool isHardModeActive;

	private Vector3 healAuraParticleOriginalScale;

	private Vector3 healTickParticleOriginalScale;

	protected override void Awake()
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void HealTick()
	{
	}

	private void Skill_HealAura()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__29))]
	private IEnumerator CR_Cast()
	{
		return null;
	}

	private void RestoreToDefault()
	{
	}
}
