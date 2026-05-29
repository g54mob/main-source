using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Couch : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateCamera_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 startPos;

		public Vector3 endPos;

		public Couch _003C_003E4__this;

		public Quaternion startRot;

		public Quaternion endRot;

		private float _003CelapsedTime_003E5__2;

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
		public _003CAnimateCamera_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CClosePrinter_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Couch _003C_003E4__this;

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
		public _003CClosePrinter_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CFieldOfView_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Couch _003C_003E4__this;

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
		public _003CFieldOfView_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003COpenPrinter_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Couch _003C_003E4__this;

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
		public _003COpenPrinter_003Ed__22(int _003C_003E1__state)
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

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Camera Animation")]
	public Transform rcpTransform;

	public float duration;

	public Vector3 offset;

	public float delayFOD;

	[Header("Components")]
	public ButtonInformationByDevice buttonInformationByDevice;

	public DetectionCrosshair detectionCrosshair;

	public bool sittingOn;

	public bool activeAnimation;

	public bool isAtTarget;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private PlayerControllerDepthOfField playerControllerDepthOfField;

	private float saveLastFieldOfView;

	private float savedetectionCrosshairDistance;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private bool CanUse()
	{
		return false;
	}

	private bool CanExit()
	{
		return false;
	}

	private void CameraAnimation(KeyCode key, object[] param)
	{
	}

	[IteratorStateMachine(typeof(_003COpenPrinter_003Ed__22))]
	private IEnumerator OpenPrinter()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CFieldOfView_003Ed__23))]
	private IEnumerator FieldOfView()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CClosePrinter_003Ed__24))]
	private IEnumerator ClosePrinter()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimateCamera_003Ed__25))]
	private IEnumerator AnimateCamera(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot)
	{
		return null;
	}
}
