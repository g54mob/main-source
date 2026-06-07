using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Obj_SkeletonKingTrap : MonoBehaviour
{
	public enum eTrapType
	{
		Freeze = 0,
		Fire = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_DelayedDestory_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SkeletonKingTrap _003C_003E4__this;

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
		public _003CCR_DelayedDestory_003Ed__13(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SkeletonKingTrap _003C_003E4__this;

		public Obj_TetrisBlock tetris;

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
		public _003CCR_PlaceTetrisProc_003Ed__9(int _003C_003E1__state)
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
	private eTrapType trapType;

	[SerializeField]
	private ParticleSystem particle_Activate;

	[SerializeField]
	private ParticleSystem particle_Border;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Ground;

	[FormerlySerializedAs("spriteColor")]
	[SerializeField]
	private Color spriteColor_On;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__9))]
	protected IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}

	public void FreezeBlockAnim()
	{
	}

	public void Activate()
	{
	}

	public void Deactivate()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedDestory_003Ed__13))]
	private IEnumerator CR_DelayedDestory()
	{
		return null;
	}
}
