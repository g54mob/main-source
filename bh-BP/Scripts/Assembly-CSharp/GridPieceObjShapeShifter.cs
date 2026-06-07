using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjShapeShifter : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_AnimateShiftIdx_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShapeShifter _003C_003E4__this;

		public int idx;

		private Vector3 _003CstartScale_003E5__2;

		private Vector3 _003CstartRot_003E5__3;

		private Vector3 _003CtgtScale_003E5__4;

		private Vector3 _003CtgtRot_003E5__5;

		private Vector3 _003CstartShadowScale_003E5__6;

		private Vector3 _003CtgtShadowScale_003E5__7;

		private Vector3 _003CstartShadowRot_003E5__8;

		private Vector3 _003CtgtShadowRot_003E5__9;

		private float _003CstartTime_003E5__10;

		private float _003Clen_003E5__11;

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
		public _003C_AnimateShiftIdx_003Ed__11(int _003C_003E1__state)
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
	private sealed class _003C_MyUpdate_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShapeShifter _003C_003E4__this;

		private float _003CnextShiftTime_003E5__2;

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

	[Header("ShapeShift")]
	public float MinShapeShiftCycle;

	public float MaxShapeShiftCycle;

	public int CurShiftIdx;

	public Collider2D[] ShiftColliders;

	private CoroutineHandle _shiftAnim;

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

	public void SetShiftIdx(int idx, bool force = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateShiftIdx_003Ed__11))]
	private IEnumerator<float> _AnimateShiftIdx(int idx)
	{
		return null;
	}

	private Vector3 GetTgtPlatformScale(int idx)
	{
		return default(Vector3);
	}

	private Vector3 GetTgtPlatformRot(int idx)
	{
		return default(Vector3);
	}

	public override void RegisterColliders()
	{
	}

	public override void DeregisterColliders()
	{
	}

	public override void ResetSprite()
	{
	}
}
