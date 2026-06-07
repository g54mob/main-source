using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientMech_TrainStation : Obj_AncientMech_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_ActivateEffect_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientMech_TrainStation _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_ActivateEffect_003Ed__9(int _003C_003E1__state)
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
	private Spin spin;

	[SerializeField]
	private ParticleSystem particle_Electric;

	[SerializeField]
	private AudioSource audioSource_TrainLoop;

	[SerializeField]
	private Obj_TrainSystem trainSystem;

	private List<Obj_TrainRail> trainRails;

	private List<Obj_TrainSystem.CartData> trainCarts;

	private float soundDetectInterval;

	private float soundDetectTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ActivateEffect_003Ed__9))]
	private IEnumerator CR_ActivateEffect()
	{
		return null;
	}

	private void Update()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}
}
