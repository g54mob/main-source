using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_SkeletonMage : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_SkeletonMage _003C_003E4__this;

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
		public _003CCR_Cast_003Ed__14(int _003C_003E1__state)
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
	private int maxSummonCount_Casual;

	[SerializeField]
	private int maxSummonCount_Normal;

	[SerializeField]
	private int maxSummonCount_Heroic;

	[SerializeField]
	private float skillTimer;

	[SerializeField]
	private ParticleSystem particle_Summon;

	[SerializeField]
	private List<AMonsterBase> list_SummonedMonsters;

	private int maxSummonCount;

	private int skillCastCount;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void Skill_SummonSkeleton()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__14))]
	private IEnumerator CR_Cast()
	{
		return null;
	}

	private void SummonedMonsterRemoveCallback(AMonsterBase monster)
	{
	}

	private void RestoreToDefault()
	{
	}

	private Vector3 GetSummonPosition()
	{
		return default(Vector3);
	}
}
