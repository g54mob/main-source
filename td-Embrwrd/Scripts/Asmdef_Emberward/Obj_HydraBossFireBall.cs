using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_HydraBossFireBall : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_FlyToTarget_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_HydraBossFireBall _003C_003E4__this;

		public float flyTime;

		private float _003Ctimer_003E5__2;

		private Vector3 _003CstartPosition_003E5__3;

		private Vector3 _003CtargetPosition_003E5__4;

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
		public _003CCR_FlyToTarget_003Ed__11(int _003C_003E1__state)
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
	private ParticleSystem particle_Missile;

	[SerializeField]
	private ParticleSystem particle_Explosion;

	[SerializeField]
	private float flyHeight;

	[SerializeField]
	private float explosionRange;

	[SerializeField]
	private float flySpeed;

	private Vector3 targetPosition;

	private ABaseTower targetTower;

	private AMonsterBase boss;

	private float stunTime;

	private int hardModeLevel;

	public void Shoot(ABaseTower tower, AMonsterBase boss, float stunTime, int hardModeLevel)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FlyToTarget_003Ed__11))]
	private IEnumerator CR_FlyToTarget(float flyTime)
	{
		return null;
	}
}
