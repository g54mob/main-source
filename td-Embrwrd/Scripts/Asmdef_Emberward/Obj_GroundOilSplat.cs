using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_GroundOilSplat : ASpawnableObject
{
	[CompilerGenerated]
	private sealed class _003CCR_DelayedDestroy_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_GroundOilSplat _003C_003E4__this;

		public float delay;

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
		public _003CCR_DelayedDestroy_003Ed__15(int _003C_003E1__state)
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
	private ParticleSystem particle_OilSplat;

	[SerializeField]
	private ParticleSystem particle_BurningEffect;

	private float duration;

	private bool isBurning;

	private float fireDetectRange;

	private float detectInterval;

	private float detectTimer;

	private float durationTimer;

	private bool isDestroyed;

	private Vector3Int posInt;

	public override void OnSpawnProcess()
	{
	}

	public void Setup(float duration)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedDestroy_003Ed__15))]
	private IEnumerator CR_DelayedDestroy(float delay)
	{
		return null;
	}

	private void OnPhysicsInteraction_Flame(Vector3 pos, float effectRange, bool isFromPlayer)
	{
	}

	private void StartBurning()
	{
	}
}
