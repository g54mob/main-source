using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Spear : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootEffect_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Spear _003C_003E4__this;

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
		public _003CCR_ShootEffect_003Ed__10(int _003C_003E1__state)
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
	private sealed class _003CSpawnProc_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Spear _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__7(int _003C_003E1__state)
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

	[Header("放置時的煙霧特效")]
	[SerializeField]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	protected ParticleSystem particle_ShootEffect_Normal;

	[SerializeField]
	protected ParticleSystem particle_ShootEffect_Poison;

	[SerializeField]
	protected ParticleSystem particle_ShootEffect_Arcane;

	private Vector3 headModelForward;

	private int extraAttackCount;

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__7))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootEffect_003Ed__10))]
	private IEnumerator CR_ShootEffect()
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}
}
