using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientTower_Thunder : Obj_AncientTower_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_Shoot_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Thunder _003C_003E4__this;

		public ABaseTower targetTower;

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
		public _003CCR_Shoot_003Ed__14(int _003C_003E1__state)
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
	private ParticleSystem particle_Activate;

	[SerializeField]
	private ParticleSystem particle_Spark;

	[SerializeField]
	private ParticleSystem particle_Shoot;

	[SerializeField]
	private ParticleSystem particle_Thunder;

	[SerializeField]
	private List<Spin> list_SpinCogs;

	[SerializeField]
	private float explodeRadius;

	[SerializeField]
	private float delayTime;

	protected override void DespawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void ShootProc(ABaseTower targetTower)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void TowerActivateProc()
	{
	}

	protected override void TowerResetProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Shoot_003Ed__14))]
	private IEnumerator CR_Shoot(ABaseTower targetTower)
	{
		return null;
	}

	protected override void ShowTooltipProc()
	{
	}

	protected override void HideTooltipProc()
	{
	}
}
