using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class BaseCamMgr : CamMgr
{
	[CompilerGenerated]
	private sealed class _003C_MoveToSteadyPos_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCamMgr _003C_003E4__this;

		public Vector3 pos;

		public float zoom;

		public float speed;

		private Vector3 _003CstartSteadyPos_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartZoom_003E5__4;

		private float _003CstartTime_003E5__5;

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
		public _003C_MoveToSteadyPos_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_MoveToTargetZoom_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCamMgr _003C_003E4__this;

		private float _003Clen_003E5__2;

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
		public _003C_MoveToTargetZoom_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003C_RotateTo_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseCamMgr _003C_003E4__this;

		public float rot;

		public float speed;

		private float _003CstartRot_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003Clen_003E5__4;

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
		public _003C_RotateTo_003Ed__21(int _003C_003E1__state)
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

	public new static BaseCamMgr I;

	public float ZoomDist;

	public float LookRot;

	private CoroutineHandle _lookAnim;

	private CoroutineHandle _moveAnim;

	public DelegateUtl.NoArgsEvent OnLookRotChanged;

	public bool IsRotating;

	public float MinZoomDist;

	public float MaxZoomDist;

	private float _zoomInFactor;

	private float _zoomOutFactor;

	public float TargetZoomDist;

	private float _zoomLerpStartZoom;

	private float _zoomLerpStartTime;

	public bool IsLerpingZoom;

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetLookRot(float rot)
	{
	}

	public void StopRotateAnim()
	{
	}

	public void RotateTo(float rot, float speed)
	{
	}

	[IteratorStateMachine(typeof(_003C_RotateTo_003Ed__21))]
	private IEnumerator<float> _RotateTo(float rot, float speed)
	{
		return null;
	}

	public void StopMoveAnim()
	{
	}

	public override void SetSteadyPos(Vector3 pos)
	{
	}

	public void SetZoomDist(float zoomLvl)
	{
	}

	public void ZoomIn()
	{
	}

	public void ZoomOut()
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToTargetZoom_003Ed__27))]
	private IEnumerator<float> _MoveToTargetZoom()
	{
		return null;
	}

	public float GetDefaultZoomDistForBase(int cols, int rows)
	{
		return 0f;
	}

	protected override void MyUpdate()
	{
	}

	public void MoveToSteadyPos(Vector3 pos, float zoom, float speed)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveToSteadyPos_003Ed__31))]
	private IEnumerator<float> _MoveToSteadyPos(Vector3 pos, float zoom, float speed)
	{
		return null;
	}

	public void RotateAndMoveTo(float rot, float rotSpeed, Vector3 pos, float zoom, float moveSpeed)
	{
	}

	public void RotateAndMoveTo(float rot, Vector3 pos, float zoom, float len)
	{
	}

	public override void ShakeScreen(float size, float len)
	{
	}
}
