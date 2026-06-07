using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_BossTrainBox : MonoBehaviour
{
	public enum eBoxDestroyType
	{
		EXPLODE = 0,
		FALL_OFF = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_DestroyProc_Explode_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_BossTrainBox _003C_003E4__this;

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
		public _003CCR_DestroyProc_Explode_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003CCR_DestroyProc_FallOff_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_BossTrainBox _003C_003E4__this;

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
		public _003CCR_DestroyProc_FallOff_003Ed__14(int _003C_003E1__state)
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
	private eBoxDestroyType destroyType;

	[SerializeField]
	private Transform node_Model;

	[SerializeField]
	private Collider collider_Box;

	[SerializeField]
	private Rigidbody rigidbody_Box;

	[SerializeField]
	private ParticleSystem particleSystem_Explosion;

	private bool doCreateChest;

	private bool isExploded;

	private bool isDestroyed;

	private bool isCreatedChest;

	public void SetDestroyType(eBoxDestroyType destroyType)
	{
	}

	public void SetDoCreateChest(bool doCreateChest)
	{
	}

	public void DestroyBox()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DestroyProc_Explode_003Ed__13))]
	private IEnumerator CR_DestroyProc_Explode()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_DestroyProc_FallOff_003Ed__14))]
	private IEnumerator CR_DestroyProc_FallOff()
	{
		return null;
	}
}
