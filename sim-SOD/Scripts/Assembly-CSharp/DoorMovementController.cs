using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorMovementController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COpenDoor_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DoorMovementController _003C_003E4__this;

		public Actor interactor;

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
		public _003COpenDoor_003Ed__28(int _003C_003E1__state)
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

	[Header("State Positions")]
	public Transform door;

	[NonSerialized]
	public Interactable interactable;

	public Dictionary<Collider, int> spawnedDoorColliders;

	[Space(7f)]
	public Vector3 closedLocalPos;

	public Vector3 openLocalPos;

	public Vector3 closedLocalEuler;

	public Vector3 openLocalEuler;

	public Vector3 closedLocalScale;

	public Vector3 openLocalScale;

	[Space(7f)]
	public Vector3 desiredPos;

	public Vector3 desiredEuler;

	public Vector3 desiredScale;

	[Header("Door State")]
	public DoorMovementPreset preset;

	[Tooltip("0 = Closed, 1 = Open")]
	public float desiredTransition;

	public float currentTransition;

	[Tooltip("True if open")]
	public bool isOpen;

	public Actor interacting;

	public bool isAnimating;

	public bool isSetup;

	public bool isOpening;

	public bool isClosing;

	[Tooltip("If true this will update looping audio params while animating. Useful for fridge doors etc where the animation is tied to a sfx param.")]
	public bool updateLoopingParams;

	[Tooltip("If true this will remove collisions with player while animating")]
	public bool removePlayerCollisionsWhileAnimating;

	private void Start()
	{
	}

	public void Setup(Interactable newInteractable, bool inheritOpenStatusFromInteractable = true)
	{
	}

	public virtual void SetOpen(float newAjar, Actor interactor, bool skipAnimation = false)
	{
	}

	public void SetCollisionsWithPlayerActive(bool val)
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(_003COpenDoor_003Ed__28))]
	private IEnumerator OpenDoor(Actor interactor)
	{
		return null;
	}

	public void SetDoorPosition()
	{
	}

	public void OnClose(Actor interactor, bool playSound = true)
	{
	}

	public void OnOpen(Actor interactor, bool playSound = true)
	{
	}

	public void OnCollisionEnter(Collision collision)
	{
	}

	public void OnCollisionExit(Collision collision)
	{
	}
}
