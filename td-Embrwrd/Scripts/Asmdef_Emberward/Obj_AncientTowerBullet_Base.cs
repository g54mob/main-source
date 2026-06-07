using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Obj_AncientTowerBullet_Base : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_RemoveProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTowerBullet_Base _003C_003E4__this;

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
		public _003CCR_RemoveProc_003Ed__11(int _003C_003E1__state)
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
	protected GameObject node_Model;

	[SerializeField]
	protected ParticleSystem particle_Explode;

	[SerializeField]
	protected float flySpeed;

	[SerializeField]
	protected float removeDelay;

	[SerializeField]
	protected ABaseTower targetTower;

	[SerializeField]
	protected float stunTime;

	[SerializeField]
	protected Obj_AncientTower_Base source;

	protected bool isFinished;

	public void Setup(ABaseTower targetTower, float stunTime, Obj_AncientTower_Base source)
	{
	}

	protected virtual void SetupProc()
	{
	}

	public void Remove()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RemoveProc_003Ed__11))]
	private IEnumerator CR_RemoveProc()
	{
		return null;
	}
}
