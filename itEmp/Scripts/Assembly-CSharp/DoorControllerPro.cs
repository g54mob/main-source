using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorControllerPro : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimCloseDoor_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DoorControllerPro _003C_003E4__this;

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
		public _003CAnimCloseDoor_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003CAnimOpenDoor_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DoorControllerPro _003C_003E4__this;

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
		public _003CAnimOpenDoor_003Ed__25(int _003C_003E1__state)
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

	[Header("Doors")]
	public List<Door> doors;

	[Header("Door Type")]
	public string doorType;

	[Header("Door Animation")]
	public float openAngle;

	public float doorSpeed;

	public bool openMirror;

	[Header("Audio Settings")]
	public AudioSource audioSource;

	public AudioClip openClip;

	public float openClipStartTime;

	public AudioClip closeClip;

	public float closeClipStartTime;

	[Header("Status")]
	public DoorStatus doorStatus;

	private bool isBussy;

	private Coroutine nowAnim;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private bool CanOpenDoor()
	{
		return false;
	}

	private bool CanCloseDoor()
	{
		return false;
	}

	private void InteractionCodeOpen(KeyCode key, object[] param)
	{
	}

	private void InteractionCodeClose(KeyCode key, object[] param)
	{
	}

	public void OpenDoor()
	{
	}

	public void CloseDoor()
	{
	}

	public void CloseDoorByStepAwayDevice()
	{
	}

	public void StopAnim()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimOpenDoor_003Ed__25))]
	private IEnumerator AnimOpenDoor()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CAnimCloseDoor_003Ed__26))]
	private IEnumerator AnimCloseDoor(bool stepAwayDevice = false)
	{
		return null;
	}

	private float AnimationProgress()
	{
		return 0f;
	}
}
