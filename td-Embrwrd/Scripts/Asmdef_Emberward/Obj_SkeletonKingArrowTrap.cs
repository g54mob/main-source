using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_SkeletonKingArrowTrap : MonoBehaviour
{
	public enum eTrapType
	{
		LEFT = 0,
		RIGHT = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_Activate_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SkeletonKingArrowTrap _003C_003E4__this;

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
		public _003CCR_Activate_003Ed__10(int _003C_003E1__state)
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
	private eTrapType trapType;

	[SerializeField]
	private ParticleSystem particle_Dust;

	[SerializeField]
	private List<Obj_Trap_WallArrow> list_ArrowTraps;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequesteActivateSkeletonKingArrowTrap(eTrapType type)
	{
	}

	private void Start()
	{
	}

	public void Activate()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Activate_003Ed__10))]
	private IEnumerator CR_Activate()
	{
		return null;
	}
}
