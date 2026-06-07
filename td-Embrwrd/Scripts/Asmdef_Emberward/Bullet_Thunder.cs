using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Thunder : ASingleTargetProjectile
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Bullet_Thunder _003C_003E4__this;

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
		public _003CCR_Proc_003Ed__8(int _003C_003E1__state)
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
	private Rigidbody rigidbody;

	[SerializeField]
	[FormerlySerializedAs("explodeRange")]
	private float explodeRangeSetting;

	[SerializeField]
	private float delayTime;

	[SerializeField]
	private ParticleSystem particle_Thunder;

	private int damage;

	private ABaseTower.eUpgradeType upgradeType;

	private Vector3 lastTargetPosition;

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__8))]
	private IEnumerator CR_Proc()
	{
		return null;
	}

	public void Setup(int damage, float scale)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
