using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntroSleepingController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnim_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroSleepingController _003C_003E4__this;

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
		public _003CAnim_003Ed__13(int _003C_003E1__state)
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
	private sealed class _003CAnimateEyelids_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroSleepingController _003C_003E4__this;

		public float upTarget;

		public float downTarget;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartUp_003E5__3;

		private Vector2 _003CstartDown_003E5__4;

		private Vector2 _003CtargetUp_003E5__5;

		private Vector2 _003CtargetDown_003E5__6;

		private float _003CstartAlpha_003E5__7;

		private float _003CtargetAlpha_003E5__8;

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
		public _003CAnimateEyelids_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CSmoothRotateToIdentity_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroSleepingController _003C_003E4__this;

		public float duration;

		private Quaternion _003CstartRotation_003E5__2;

		private float _003CelapsedTime_003E5__3;

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
		public _003CSmoothRotateToIdentity_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CWaitToUnlockPlayer_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroSleepingController _003C_003E4__this;

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
		public _003CWaitToUnlockPlayer_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003CWakeUpAnim_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IntroSleepingController _003C_003E4__this;

		private Vector3[] _003CcurvePoints_003E5__2;

		private float _003Cspeed_003E5__3;

		private int _003CcurrentIndex_003E5__4;

		private Vector3 _003Cstart_003E5__5;

		private Vector3 _003Cend_003E5__6;

		private Quaternion _003CstartRot_003E5__7;

		private Quaternion _003CendRot_003E5__8;

		private float _003CsegmentTime_003E5__9;

		private float _003Ct_003E5__10;

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
		public _003CWakeUpAnim_003Ed__14(int _003C_003E1__state)
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

	public PlayerManager playerManager;

	public Transform cameraObject;

	public List<Transform> waypoints;

	public float duration;

	public int curveResolution;

	public RectTransform Up;

	public RectTransform Down;

	public CanvasGroup eyelidCanvasGroup;

	public RectTransform WakeUpButton;

	public bool runAnim;

	public bool doneAnim;

	[ContextMenu("Start Anim")]
	public void StartAnim()
	{
	}

	private Vector3[] GenerateCurve()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnim_003Ed__13))]
	public IEnumerator Anim()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWakeUpAnim_003Ed__14))]
	public IEnumerator WakeUpAnim()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CSmoothRotateToIdentity_003Ed__15))]
	private IEnumerator SmoothRotateToIdentity(float duration)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWaitToUnlockPlayer_003Ed__16))]
	private IEnumerator WaitToUnlockPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateEyelids_003Ed__17))]
	private IEnumerator AnimateEyelids(float upTarget, float downTarget, float time)
	{
		return null;
	}

	private Vector3 CatmullRomSpline(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		return default(Vector3);
	}
}
