using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientMech_HugeFan : Obj_AncientMech_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_DestroyEffect_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientMech_HugeFan _003C_003E4__this;

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
		public _003CCR_DestroyEffect_003Ed__9(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private Transform node_WindArea;

	[SerializeField]
	private Obj_AccelerateArea obj_AccelerateArea;

	[SerializeField]
	private ParticleSystem particle_Wind;

	[SerializeField]
	private Spin spin_Fan;

	[SerializeField]
	private GameObject obj_AreaPreview;

	private bool isDestroyEffectTriggered;

	private bool isPreviewOn;

	protected override void OnEnableProc()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DestroyEffect_003Ed__9))]
	private IEnumerator CR_DestroyEffect()
	{
		return null;
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private void OnDetectMonsters(List<AMonsterBase> list)
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}
}
