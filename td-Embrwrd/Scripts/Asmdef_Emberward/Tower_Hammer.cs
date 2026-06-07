using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Hammer : ADirectionalTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootEffect_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Hammer _003C_003E4__this;

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
		public _003CCR_ShootEffect_003Ed__13(int _003C_003E1__state)
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
	private float baseAttackRange;

	[SerializeField]
	[Header("升級B: 槌子上的閃電特效")]
	private ParticleSystem particleSystem_Lightning;

	[Header("升級B: 原始槌子模型")]
	[SerializeField]
	private Renderer renderer_Hammer;

	[SerializeField]
	[Header("升級B: 升級後的槌子模型")]
	private Mesh mesh_Hammer_UpgradeB;

	private List<AMonsterBase> list_MonstersInArea_Detection;

	private List<AMonsterBase> list_MonstersInArea_OnAttack;

	private Vector3 baseParticleScale;

	private float stunTime;

	private int extraAttackCount;

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootEffect_003Ed__13))]
	private IEnumerator CR_ShootEffect()
	{
		return null;
	}
}
