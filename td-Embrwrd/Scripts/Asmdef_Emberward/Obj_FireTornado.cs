using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_FireTornado : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDestroyProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_FireTornado _003C_003E4__this;

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
		public _003CDestroyProc_003Ed__11(int _003C_003E1__state)
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
	private float lifeDuration;

	[SerializeField]
	private float range;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float damageInterval;

	[SerializeField]
	private float burnDuration;

	[SerializeField]
	private ParticleSystem particle_FireTornado;

	private float lifeTimer;

	private float damageTimer;

	private bool isDestroyed;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CDestroyProc_003Ed__11))]
	private IEnumerator DestroyProc()
	{
		return null;
	}
}
