using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_RuneTrap_Frost : MonoBehaviour
{
	public enum eTrapType
	{
		Freeze = 0,
		Fire = 1,
		Break = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_RuneTrap_Frost _003C_003E4__this;

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
		public _003CCR_PlaceTetrisProc_003Ed__6(int _003C_003E1__state)
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
	private SpriteRenderer spriteRenderer_Ground;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__6))]
	protected IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}
}
