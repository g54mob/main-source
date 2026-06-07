using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjSideStepper : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjSideStepper _003C_003E4__this;

		private float _003CnextSidestepTime_003E5__2;

		private GridPieceInfo _003Cinf_003E5__3;

		private float _003CstartX_003E5__4;

		private float _003CtgtX_003E5__5;

		private float _003CstartTime_003E5__6;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MyUpdate_003Ed__9(int _003C_003E1__state)
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

	private CoroutineHandle _update;

	public GridPieceMarker CurMarker;

	private int _preferredDir;

	[Header("Sidestepping")]
	public float MinSidestepCycle;

	public float MaxSidestepCycle;

	private const float kSidestepLen = 0.75f;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	private float PickRandomCycle()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__9))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}
}
