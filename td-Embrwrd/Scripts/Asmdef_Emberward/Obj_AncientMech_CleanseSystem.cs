using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientMech_CleanseSystem : Obj_AncientMech_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_CleanseCorruptedBlock_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientMech_CleanseSystem _003C_003E4__this;

		public ACorruptedPowerGrid target;

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
		public _003CCR_CleanseCorruptedBlock_003Ed__16(int _003C_003E1__state)
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
	private LineRenderer lineRenderer;

	[SerializeField]
	private Transform node_RangeRing;

	[SerializeField]
	private ParticleSystem particle_Wave;

	[SerializeField]
	private ParticleSystem particle_Cleanse;

	[SerializeField]
	private Transform node_ShootPoint;

	[SerializeField]
	private float cleanseInterval_min;

	[SerializeField]
	private float cleanseInterval_max;

	[SerializeField]
	private float effectRange;

	[SerializeField]
	private Material material_Activated;

	[SerializeField]
	private Material material_Deactivated;

	private float cleanseTimer;

	private List<Vector3> list_LinePoints;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void CleanseCorruptedBlock(ACorruptedPowerGrid target)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CleanseCorruptedBlock_003Ed__16))]
	private IEnumerator CR_CleanseCorruptedBlock(ACorruptedPowerGrid target)
	{
		return null;
	}

	private void SetLinePoints(List<Vector3> list_LinePoints, int v1, int v2)
	{
	}

	private void OnMouseOver()
	{
	}

	private void OnMouseExit()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}
}
