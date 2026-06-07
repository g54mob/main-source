using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_SceneDecoration : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_BurnEffect_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SceneDecoration _003C_003E4__this;

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
		public _003CCR_BurnEffect_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003CDestroyProc_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SceneDecoration _003C_003E4__this;

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
		public _003CDestroyProc_003Ed__28(int _003C_003E1__state)
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
	private GameObject node_Content;

	[SerializeField]
	protected Renderer renderer;

	[SerializeField]
	private bool isDestroyable;

	[SerializeField]
	private bool isFlammable;

	[SerializeField]
	private bool isExplodeable;

	[SerializeField]
	private ParticleSystem particle_Destroy;

	[SerializeField]
	private ParticleSystem particle_Flame;

	[SerializeField]
	private float burnTimeBeforeDestroy_Min;

	[SerializeField]
	private float burnTimeBeforeDestroy_Max;

	[SerializeField]
	private Material mat_Burning;

	[SerializeField]
	private ParticleSystem particle_Explosion;

	[Header("破壞音效")]
	[SerializeField]
	private string sound_OnDestroy_DataName;

	[Header("破壞音效")]
	[SerializeField]
	private string sound_OnDestroy_Key;

	[SerializeField]
	protected float range;

	[SerializeField]
	private float destroyDelay;

	protected bool isDestroyed;

	protected bool isBurning;

	protected float burnTimer;

	private float burnTimeBeforeDestroy;

	protected float rangeWithScale => 0f;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	private void OnPhysicsInteraction_Flame(Vector3 pos, float effectRange, bool isFromPlayer)
	{
	}

	public void AttackedEffect(float duration, float strengthMultiplier, float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BurnEffect_003Ed__26))]
	private IEnumerator CR_BurnEffect()
	{
		return null;
	}

	private void OnPhysicsInteraction_Explosion(Vector3 pos, float effectRange, bool isFromPlayer)
	{
	}

	[IteratorStateMachine(typeof(_003CDestroyProc_003Ed__28))]
	protected IEnumerator DestroyProc()
	{
		return null;
	}
}
