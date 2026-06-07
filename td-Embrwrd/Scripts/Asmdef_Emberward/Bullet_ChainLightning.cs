using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet_ChainLightning : AProjectile
{
	[CompilerGenerated]
	private sealed class _003CCR_ChainLightningProc_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase firstTarget;

		public float jumpRange;

		public int targetCount;

		public Bullet_ChainLightning _003C_003E4__this;

		private List<AMonsterBase> _003Clist_Targets_003E5__2;

		private float _003CendingTimer_003E5__3;

		private int _003Ci_003E5__4;

		private float _003Ctimer_003E5__5;

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
		public _003CCR_ChainLightningProc_003Ed__13(int _003C_003E1__state)
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
	private LineRenderer lineRenderer;

	[SerializeField]
	private float jumpTargetInterval;

	[SerializeField]
	private ParticleSystem particle_HitEffect;

	private int damage;

	private int targetCount;

	private float jumpRange;

	private Transform startTransform;

	private int extraChargeIncreasePerHit;

	private void LateUpdate()
	{
	}

	public void Setup(int damage, int targetCount, float jumpRange, Transform startTransform, int extraChargeIncreasePerHit)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChainLightningProc_003Ed__13))]
	private IEnumerator CR_ChainLightningProc(int targetCount, AMonsterBase firstTarget, float jumpRange)
	{
		return null;
	}

	private void UpdateLineRenderer(List<AMonsterBase> list_Targets, int hitCount)
	{
	}
}
