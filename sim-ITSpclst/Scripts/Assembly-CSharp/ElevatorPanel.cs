using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoor_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ElevatorPanel _003C_003E4__this;

		public bool toToggle;

		public Action finish;

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
		public _003CDoor_003Ed__24(int _003C_003E1__state)
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

	public ElevatorController elevatorController;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("Elevator Panel Wall")]
	public int thisFloor;

	public bool isPanelOnWall;

	[Header("Doors")]
	public Transform leftDoor;

	public Transform rightDoor;

	public float doorSpeed;

	public float positionThreshold;

	[Header("Other")]
	public TextMeshPro textCurrentFloor;

	public SpriteRenderer buttonCall;

	public List<TextMeshPro> ButtonFloorInElevator;

	public bool doorsIsOpen;

	public bool isAnimating;

	private Vector3 leftOpenPosition;

	private Vector3 rightOpenPosition;

	private Vector3 leftClosedPosition;

	private Vector3 rightClosedPosition;

	private InteractionManager.InteractionVariants interactionVariants;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private void InteractionCode_CallElevator(KeyCode key, object[] param)
	{
	}

	private void InteractionCode_GoToFloor1(KeyCode key, object[] param)
	{
	}

	public void RunElevator(int toFloor, bool playerInElevator)
	{
	}

	[IteratorStateMachine(typeof(_003CDoor_003Ed__24))]
	public IEnumerator Door(bool toToggle, Action finish)
	{
		return null;
	}

	private void DoorAnimation()
	{
	}

	private bool IsAtTargetPosition(Transform door, Vector3 targetPosition)
	{
		return false;
	}
}
