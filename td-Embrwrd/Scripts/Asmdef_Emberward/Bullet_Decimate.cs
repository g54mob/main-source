using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet_Decimate : ASingleTargetProjectile
{
	[CompilerGenerated]
	private sealed class _003CCR_Upgrade_B_PoisonCloud_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Bullet_Decimate _003C_003E4__this;

		private float _003CpoisonCloudTimer_003E5__2;

		private float _003CtickTimer_003E5__3;

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
		public _003CCR_Upgrade_B_PoisonCloud_003Ed__18(int _003C_003E1__state)
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
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float explodeRange;

	[Header("升級B: 毒雲效果")]
	[SerializeField]
	private ParticleSystem particle_PoisonCloud;

	[SerializeField]
	private float poisonCloudDuration;

	[SerializeField]
	private float poisonCloudRadius;

	[SerializeField]
	private float poisonCloudTickInterval;

	[SerializeField]
	private float poisonCloudDamagePercentage;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private bool isLanded;

	private ABaseTower.eUpgradeType upgradeType;

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Upgrade_B_PoisonCloud_003Ed__18))]
	private IEnumerator CR_Upgrade_B_PoisonCloud()
	{
		return null;
	}

	public void Setup(int damage)
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
}
