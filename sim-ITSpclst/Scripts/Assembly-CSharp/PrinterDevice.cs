using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PrinterDevice : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateCamera_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 startPos;

		public Vector3 endPos;

		public PrinterDevice _003C_003E4__this;

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
	private sealed class _003CClosePrinter_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PrinterDevice _003C_003E4__this;

		public bool stepAwayDevice;

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
		public _003CClosePrinter_003Ed__23(int _003C_003E1__state)
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

		public PrinterDevice _003C_003E4__this;

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

	[Header("Unique Device ID")]
	public string deviceID;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Camera Animation")]
	public Transform rcpTransform;

	public float duration;

	public Vector3 offset;

	[Header("Components")]
	public ButtonInformationByDevice buttonInformationByDevice;

	public SimplePrinter simplePrinter;

	public bool usingPrinter;

	private bool activeAnimation;

	private bool isAtTarget;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private GraphicRaycaster graphicRaycaster;

	private PlayerControllerDepthOfField playerControllerDepthOfField;

	private DefaultInterfaceSettings lastBlockPlayerData;

	private void OnValidate()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private bool CanUseDevice()
	{
		return false;
	}

	private bool CanExitDevice()
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

	[IteratorStateMachine(typeof(_003CClosePrinter_003Ed__23))]
	private IEnumerator ClosePrinter(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateCamera_003Ed__25))]
	private IEnumerator AnimateCamera(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot)
	{
		return null;
	}
}
