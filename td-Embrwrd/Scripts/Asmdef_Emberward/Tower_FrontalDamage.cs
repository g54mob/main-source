using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_FrontalDamage : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootProc_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_FrontalDamage _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__15(int _003C_003E1__state)
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
	private int damageSplitCount;

	[SerializeField]
	private float damageTriggerInterval;

	[SerializeField]
	private float originalShootRange;

	[SerializeField]
	private ParticleSystem particle_NormalFire;

	[SerializeField]
	private ParticleSystem particle_FrostFire;

	private Vector3 headModelForward;

	private float timeSinceShoot;

	private bool isFireParticleOn;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRelicChanged(List<eItemType> list_relics)
	{
	}

	private void Start()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerStunProc()
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__15))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}
}
