using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientMech_ElectricTower : Obj_AncientMech_Base, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CCR_AttackMonster_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientMech_ElectricTower _003C_003E4__this;

		public AMonsterBase target;

		public LineRenderer lineRenderer;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_AttackMonster_003Ed__20(int _003C_003E1__state)
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
	private Obj_AreaMonsterDetector monsterDetector;

	[SerializeField]
	private int damage;

	[SerializeField]
	private Material material_Activated;

	[SerializeField]
	private Material material_Deactivated;

	[SerializeField]
	private Renderer renderer_ElectricTower;

	[SerializeField]
	private ParticleSystem particle_Spark;

	[SerializeField]
	private LineRenderer[] lineRenderers;

	[SerializeField]
	private Vector3 lineStartPointRange_A;

	[SerializeField]
	private Vector3 lineStartPointRange_B;

	[SerializeField]
	private float lineWidth;

	private float detectInterval;

	private float detectTimer;

	private int damageIncreasePerRound;

	private int activatedRouneCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void Update()
	{
	}

	private void DetectMonster()
	{
	}

	private void ShuffleList<T>(List<T> list)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_AttackMonster_003Ed__20))]
	private IEnumerator CR_AttackMonster(AMonsterBase target, LineRenderer lineRenderer)
	{
		return null;
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	protected void OnMouseEnter()
	{
	}

	protected void OnMouseExit()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
