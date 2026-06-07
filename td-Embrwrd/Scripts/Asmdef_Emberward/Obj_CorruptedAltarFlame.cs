using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_CorruptedAltarFlame : ASpawnableObject
{
	[CompilerGenerated]
	private sealed class _003CCR_DelayedDespawnAnim_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_CorruptedAltarFlame _003C_003E4__this;

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
		public _003CCR_DelayedDespawnAnim_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003CCR_DelayedSpawnAnim_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_CorruptedAltarFlame _003C_003E4__this;

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
		public _003CCR_DelayedSpawnAnim_003Ed__8(int _003C_003E1__state)
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
	private Collider boxCollider;

	[SerializeField]
	private ParticleSystem particle_Flame;

	[SerializeField]
	private Transform node_Flame;

	private List<float> list_FlameSizes;

	private int roundLeft;

	private Obj_TetrisBlock attachedTetris;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedSpawnAnim_003Ed__8))]
	private IEnumerator CR_DelayedSpawnAnim()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public override void OnSpawnProcess()
	{
	}

	private void Despawn()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedDespawnAnim_003Ed__13))]
	private IEnumerator CR_DelayedDespawnAnim()
	{
		return null;
	}

	private void OnRoundEnd()
	{
	}
}
