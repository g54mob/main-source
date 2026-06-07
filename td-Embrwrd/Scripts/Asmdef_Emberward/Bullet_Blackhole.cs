using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet_Blackhole : ASingleTargetProjectile
{
	[CompilerGenerated]
	private sealed class _003CCR_AfterLanded_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Bullet_Blackhole _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private float _003CdamageTimer_003E5__4;

		private float _003CdamageInterval_003E5__5;

		private int _003CtickIndex_003E5__6;

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
		public _003CCR_AfterLanded_003Ed__24(int _003C_003E1__state)
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
	private GameObject node_Blackhole;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float explodeRange;

	[SerializeField]
	private float stayTime;

	[SerializeField]
	private float maxPullPower;

	[SerializeField]
	private ParticleSystem particle_Flash;

	[SerializeField]
	private ParticleSystem particle_Explosion_UpgradeB;

	[SerializeField]
	private float upgradeAScale;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private bool isLanded;

	protected eDamageType damageType;

	private List<AMonsterBase> list_AffectedMonsters;

	private ABaseTower.eUpgradeType upgradeType;

	private int sndIndex;

	public void Setup(int damage, eDamageType damageType)
	{
	}

	protected override void SpawnProc()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_AfterLanded_003Ed__24))]
	private IEnumerator CR_AfterLanded()
	{
		return null;
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
