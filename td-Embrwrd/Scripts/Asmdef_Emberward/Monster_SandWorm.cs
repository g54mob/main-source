using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_SandWorm : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_SandWorm _003C_003E4__this;

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
		public _003CCR_Cast_003Ed__10(int _003C_003E1__state)
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
	private float skillTriggerHPThreshold;

	[SerializeField]
	private float undergroundTotalTime;

	[SerializeField]
	private ParticleSystem particle_Burrowing;

	[SerializeField]
	private ParticleSystem particle_UnderGround;

	[SerializeField]
	private ParticleSystem particle_Unburrow;

	private bool isSkillUsed;

	private Coroutine coroutine_Skill;

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void DespawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__10))]
	private IEnumerator CR_Cast()
	{
		return null;
	}
}
