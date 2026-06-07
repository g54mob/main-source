using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ComputerStation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateCamera_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerStation _003C_003E4__this;

		public Vector3 startPos;

		public Vector3 endPos;

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
		public _003CAnimateCamera_003Ed__38(int _003C_003E1__state)
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
	private sealed class _003CCloseComputer_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerStation _003C_003E4__this;

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
		public _003CCloseComputer_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003COpenComputer_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerStation _003C_003E4__this;

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
		public _003COpenComputer_003Ed__35(int _003C_003E1__state)
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

	[Header("Components")]
	public SystemOScypek systemOScypek;

	public BiosMovement biosMovement;

	public ButtonInformationByDevice buttonInformationByDevice;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Camera Animation")]
	public Transform monitorTransform;

	public Transform monitorCanvas;

	public float duration;

	public Vector3 offset;

	private InteractionManager.InteractionVariants interactionVariants;

	private bool usingComputer;

	private bool activeAnimation;

	private bool isAtTarget;

	public Camera mainCamera;

	private Vector3 initialPosition;

	private Quaternion initialRotation;

	private GraphicRaycaster graphicRaycaster;

	private DefaultInterfaceSettings lastBlockPlayerData;

	[Header("Application")]
	public AppMail appMail;

	public AppTerminal appTerminal;

	[Header("Testy")]
	private Coroutine testCoroutine;

	[Header("Testy")]
	private Coroutine testCorotineNext;

	public int TextFieldActive;

	public bool UsingComputer => false;

	public void AddNewTextFieldActive()
	{
	}

	public void RemoveNewTextFieldActive()
	{
	}

	private void OnValidate()
	{
	}

	public bool GetActiveAnimation()
	{
		return false;
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

	[IteratorStateMachine(typeof(_003COpenComputer_003Ed__35))]
	private IEnumerator OpenComputer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCloseComputer_003Ed__36))]
	private IEnumerator CloseComputer(bool stepAwayDevice = false)
	{
		return null;
	}

	public void StepAwayDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateCamera_003Ed__38))]
	private IEnumerator AnimateCamera(Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot)
	{
		return null;
	}
}
