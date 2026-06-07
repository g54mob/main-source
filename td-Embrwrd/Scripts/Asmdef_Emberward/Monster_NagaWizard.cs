using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_NagaWizard : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_NagaWizard _003C_003E4__this;

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
		public _003CCR_Cast_003Ed__20(int _003C_003E1__state)
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
	private float bestCandidateDistance;

	[SerializeField]
	private float skillSpeedModifier;

	[SerializeField]
	private ParticleSystem particle_Roar;

	[SerializeField]
	private float skillSpeedModifierDuration;

	[SerializeField]
	private float skillTimer;

	[SerializeField]
	private LineRenderer lineRenderer_Skill;

	[SerializeField]
	private Transform node_SkillStart;

	[SerializeField]
	private bool doUpdateLineRenderer;

	[SerializeField]
	private AMonsterBase skillTargetMonster;

	[SerializeField]
	private ParticleSystem particle_SkillPrepare;

	[SerializeField]
	private ParticleSystem particle_SkillEnchant;

	private bool isHardModeActive;

	private int skillCastCount;

	private int maxSkillCastCount;

	private Vector3 linePos;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void Skill_BuffMonster()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__20))]
	private IEnumerator CR_Cast()
	{
		return null;
	}

	private void RestoreToDefault()
	{
	}

	private void UpdateLineRenderer()
	{
	}

	private void UpdateLine(LineRenderer line, Vector3 start, Vector3 end)
	{
	}

	private List<AMonsterBase> GetBestBuffTargets(List<AMonsterBase> monsters, int count)
	{
		return null;
	}
}
