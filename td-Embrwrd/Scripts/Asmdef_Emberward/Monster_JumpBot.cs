using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_JumpBot : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Jump_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_JumpBot _003C_003E4__this;

		public Vector3Int targetPosition;

		private Vector3 _003CstartPosition_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

		private float _003Cheight_003E5__5;

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
		public _003CCR_Jump_003Ed__14(int _003C_003E1__state)
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
	private int maxJumpDistance;

	[SerializeField]
	private int minJumpDistance;

	[SerializeField]
	private float skillCooldown_Min;

	[SerializeField]
	private float skillCooldown_Max;

	[SerializeField]
	private ParticleSystem particle_Shockwave;

	private float jumpHeight;

	private bool isSkillUsed;

	private float skillTimer;

	private float skillCooldown;

	protected override void SpawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private bool FindJumpTarget()
	{
		return false;
	}

	public static Vector3 GetClosestDirection(Vector3 input)
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003CCR_Jump_003Ed__14))]
	private IEnumerator CR_Jump(Vector3Int targetPosition)
	{
		return null;
	}

	private void InterruptSkillProc()
	{
	}
}
