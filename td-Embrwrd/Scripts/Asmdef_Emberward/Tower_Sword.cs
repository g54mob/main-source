using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Sword : ADirectionalTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootEffect_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Sword _003C_003E4__this;

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
		public _003CCR_ShootEffect_003Ed__8(int _003C_003E1__state)
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
	private ParticleSystem particleSystem_SwordSwing;

	[SerializeField]
	private ParticleSystem particleSystem_SwordHit;

	[SerializeField]
	private float baseAttackRange;

	private List<AMonsterBase> list_MonstersInArea;

	private Vector3 baseParticleScale;

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootEffect_003Ed__8))]
	private IEnumerator CR_ShootEffect()
	{
		return null;
	}
}
