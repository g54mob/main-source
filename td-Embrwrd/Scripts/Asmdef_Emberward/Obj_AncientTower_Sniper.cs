using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientTower_Sniper : Obj_AncientTower_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_Shoot_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Sniper _003C_003E4__this;

		public ABaseTower targetTower;

		private float _003CshootEffectDuration_003E5__2;

		private float _003Ctime_003E5__3;

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
		public _003CCR_Shoot_003Ed__10(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CDeathProc_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Sniper _003C_003E4__this;

		public int damage;

		public bool isKilled;

		public bool playAnimation;

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
		public _003CDeathProc_003Ed__6(int _003C_003E1__state)
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
	private Transform node_ShootHead;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private ParticleSystem particle_Shoot;

	[SerializeField]
	private ParticleSystem particle_Hit;

	[SerializeField]
	private ParticleSystem particle_Smoke;

	[SerializeField]
	private List<Spin> list_SpinCogs;

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__6))]
	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void DespawnProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void ShootProc(ABaseTower targetTower)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Shoot_003Ed__10))]
	private IEnumerator CR_Shoot(ABaseTower targetTower)
	{
		return null;
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void TowerActivateProc()
	{
	}

	protected override void TowerResetProc()
	{
	}

	protected override ABaseTower GetTargetTower()
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
