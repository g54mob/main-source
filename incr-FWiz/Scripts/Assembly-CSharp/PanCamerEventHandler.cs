using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class PanCamerEventHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public bool completed;

		internal void _003CPanCameraEnumerator_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public Camera camera;

		public bool completed;

		internal float _003CZoomCameraEnumerator_003Eb__0()
		{
			return 0f;
		}

		internal void _003CZoomCameraEnumerator_003Eb__1(float x)
		{
		}

		internal void _003CZoomCameraEnumerator_003Eb__2()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CPanCameraEnumerator_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PanCamerEventHandler _003C_003E4__this;

		public Vector2 endPosition;

		public float speed;

		public Ease ease;

		private _003C_003Ec__DisplayClass19_0 _003C_003E8__1;

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
		public _003CPanCameraEnumerator_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003CZoomCameraEnumerator_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PanCamerEventHandler _003C_003E4__this;

		public float zoomModifier;

		public float duration;

		public Ease ease;

		private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

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
		public _003CZoomCameraEnumerator_003Ed__21(int _003C_003E1__state)
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

	private Coroutine _panCoroutine;

	private Coroutine _zoomCoroutine;

	private bool _panning;

	private bool _zooming;

	private bool _canCancel;

	private bool _instantClipOn;

	private Tween _panTween;

	private Tween _zoomTween;

	public float BaseCameraZoom;

	public bool IsPanning => false;

	private event Action _onCompleteCallback
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private event Action _onCancelCallback
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void PanCameraDuration(Vector2 endPosition, float duration, bool canCancel = true, Action onComplete = null, Action onCancel = null, Ease ease = Ease.InOutQuad)
	{
	}

	public void PanCamera(Vector2 endPosition, float speed, bool canCancel = true, Action onComplete = null, Action onCancel = null, Ease ease = Ease.InOutQuad)
	{
	}

	[IteratorStateMachine(typeof(_003CPanCameraEnumerator_003Ed__19))]
	public IEnumerator PanCameraEnumerator(Vector2 endPosition, float speed, Ease ease = Ease.InOutSine)
	{
		return null;
	}

	public void ZoomCamera(float zoomModifier, float duration, Ease ease = Ease.InOutSine)
	{
	}

	[IteratorStateMachine(typeof(_003CZoomCameraEnumerator_003Ed__21))]
	public IEnumerator ZoomCameraEnumerator(float zoomModifier, float duration, Ease ease = Ease.InOutSine)
	{
		return null;
	}

	public void HandleEndPan()
	{
	}
}
