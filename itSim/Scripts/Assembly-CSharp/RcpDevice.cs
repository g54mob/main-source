using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class RcpDevice : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateCamera_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 startPos;

		public Vector3 endPos;

		public RcpDevice _003C_003E4__this;

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
	private sealed class _003CCloseRCP_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RcpDevice _003C_003E4__this;

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
		public _003CCloseRCP_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003COpenRCP_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RcpDevice _003C_003E4__this;

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
		public _003COpenRCP_003Ed__22(int _003C_003E1__state)
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

	[Header("Component")]
	public SimpleRCP simpleRCP;

	public ButtonInformationByDevice buttonInformationByDevice;

	[Header("Camera Animation")]
	public Transform rcpTransform;

	public float duration;

	public Vector3 offset;

	public bool usingRCP;

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

	private bool CanUseComputer()
	{
		return false;
	}

	private bool CanExitComputer()
	{
		return false;
	}

	private void CameraAnimation(KeyCode key, object[] param)
	{
	}

	[IteratorStateMachine(typeof(_003COpenRCP_003Ed__22))]
	private IEnumerator OpenRCP()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseRCP_003Ed__23))]
	private IEnumerator CloseRCP(bool stepAwayDevice = false)
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
