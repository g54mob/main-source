using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_SoulMonsterSpawnEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_FlyToTarget_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SoulMonsterSpawnEffect _003C_003E4__this;

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
		public _003CCR_FlyToTarget_003Ed__10(int _003C_003E1__state)
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
	private float flyHeight_Min;

	[SerializeField]
	private float flyHeight_Max;

	private float flyHeight;

	private Vector3 targetPosition;

	private Vector3 monsterDirection;

	private eMonsterType monsterType;

	private Action<eMonsterType, Vector3> onHitCallback;

	public void Shoot(Vector3 targetPos, eMonsterType monsterType, float flyTime, Action<eMonsterType, Vector3> onHitCallback)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FlyToTarget_003Ed__10))]
	private IEnumerator CR_FlyToTarget(float flyTime)
	{
		return null;
	}
}
