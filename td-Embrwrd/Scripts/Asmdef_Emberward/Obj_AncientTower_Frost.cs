using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientTower_Frost : Obj_AncientTower_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootProc_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Frost _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__8(int _003C_003E1__state)
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
	private ParticleSystem particle_Freeze;

	[SerializeField]
	private ParticleSystem particle_FrostSmoke;

	[SerializeField]
	private List<Spin> list_Spin;

	protected override void OnEnableProc()
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void TowerActivateProc()
	{
	}

	protected override void TowerResetProc()
	{
	}

	protected override void ShootProc(ABaseTower targetTower)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__8))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}

	protected override void ShowTooltipProc()
	{
	}

	protected override void HideTooltipProc()
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}
}
