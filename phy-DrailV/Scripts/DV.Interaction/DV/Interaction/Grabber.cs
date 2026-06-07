using System;
using DV.Interaction.Inputs;
using Stateless;
using UnityEngine;

namespace DV.Interaction
{
	public class Grabber : MonoBehaviour
	{
		public enum State
		{
			Idle = 0,
			Holding = 1,
			Dragging = 2,
			DraggingWhileHeld = 3
		}

		public enum Trigger
		{
			Drag = 0,
			Hold = 1,
			ForceHold = 2,
			Update = 3,
			Release = 4,
			StartInteraction = 5,
			EndInteraction = 6
		}

		public delegate void GrabHandlerDelegate(AGrabHandler grabHandler);

		private const float MOUSE_SCREENSPACE_SPEED = 1.8f;

		private const float PLANE_ANGLE_THRESHOLD = 30f;

		private const float MAX_COLLIDER_RADIUS = 1f;

		public bool screenspaceDraggingAllowed;

		private StateMachine<State, Trigger> hsm;

		private State state;

		private CapsuleCollider capsuleCollider;

		private Plane plane;

		public AGrabHandler CurrentItemHeld { get; private set; }

		public AGrabHandler CurrentlyDragged { get; private set; }

		public IGrabberCursor Cursor { get; private set; }

		public IGrabberRaycaster Raycaster { get; private set; }

		public IGrabberInteractionHandler InteractionHandler { get; private set; }

		public event GrabHandlerDelegate GrabStarted;

		public event GrabHandlerDelegate GrabStopped;

		public bool IsGrabbing()
		{
			if (!CurrentlyDragged)
			{
				return CurrentItemHeld;
			}
			return true;
		}

		public bool IsHoldingItem()
		{
			return CurrentItemHeld;
		}

		public bool IsDragging()
		{
			return CurrentlyDragged;
		}

		public string GetState()
		{
			return state.ToString();
		}

		private void Awake()
		{
			Raycaster = GetComponent<IGrabberRaycaster>();
			Cursor = GetComponent<IGrabberCursor>();
			InteractionHandler = GetComponent<IGrabberInteractionHandler>();
			hsm = new StateMachine<State, Trigger>(() => state, delegate(State s)
			{
				state = s;
			});
			hsm.Configure(State.Idle).InternalTransition(Trigger.StartInteraction, GetInteractionHandlerAction(InteractionHandler.IdleStartInteraction)).Permit(Trigger.Hold, State.Holding)
				.Permit(Trigger.ForceHold, State.Holding)
				.Permit(Trigger.Drag, State.Dragging)
				.Ignore(Trigger.Update)
				.Ignore(Trigger.EndInteraction);
			hsm.Configure(State.Holding).SubstateOf(State.Idle).OnEntryFrom(Trigger.ForceHold, OnForceHoldingEntry)
				.OnEntryFrom(Trigger.Hold, OnHoldingEntry)
				.InternalTransition(Trigger.StartInteraction, GetInteractionHandlerAction(InteractionHandler.HoldingStartInteraction))
				.InternalTransition(Trigger.EndInteraction, GetInteractionHandlerAction(InteractionHandler.HoldingStopInteraction))
				.OnExit(OnHoldingExit)
				.Permit(Trigger.Drag, State.DraggingWhileHeld)
				.Permit(Trigger.Release, State.Idle);
			hsm.Configure(State.Dragging).SubstateOf(State.Idle).OnEntry(OnDraggingEntry)
				.OnExit(OnDraggingExit)
				.InternalTransition(Trigger.Update, OnDragUpdate)
				.Permit(Trigger.EndInteraction, State.Idle);
			hsm.Configure(State.DraggingWhileHeld).SubstateOf(State.Holding).OnEntry(OnDraggingEntry)
				.OnExit(OnDraggingExit)
				.InternalTransition(Trigger.Update, OnDragUpdate)
				.Permit(Trigger.EndInteraction, State.Holding);
			SetupListeners();
		}

		private void SetupListeners()
		{
			InteractionHandler.StartInteractionRequested += delegate
			{
				hsm.Fire(Trigger.StartInteraction);
			};
			InteractionHandler.EndInteractionRequested += delegate
			{
				hsm.Fire(Trigger.EndInteraction);
			};
			InteractionHandler.DropRequested += ReleaseHolding;
			InteractionHandler.ForceHoldRequested += OnForceHoldRequested;
		}

		private Action GetInteractionHandlerAction(Func<Trigger?> func)
		{
			return delegate
			{
				Trigger? trigger = func();
				if (trigger.HasValue)
				{
					hsm.Fire(trigger.Value);
				}
			};
		}

		public void DoUpdate()
		{
			hsm.Fire(Trigger.Update);
		}

		private void OnForceHoldRequested(AGrabHandler grabHandler)
		{
			if (CurrentItemHeld != null)
			{
				Debug.LogError("Should this be null?");
			}
			CurrentItemHeld = grabHandler;
			hsm.Fire(Trigger.ForceHold);
		}

		private void ReleaseHolding()
		{
			if (CurrentlyDragged != null)
			{
				hsm.Fire(Trigger.EndInteraction);
			}
			if (CurrentItemHeld != null)
			{
				hsm.Fire(Trigger.Release);
			}
		}

		private void OnForceHoldingEntry()
		{
			CurrentItemHeld.EndInteractionForced += ReleaseHolding;
			CurrentItemHeld.StartInteraction(Vector3.zero, this);
			Raycaster.UpdateRaycast();
			this.GrabStarted?.Invoke(CurrentItemHeld);
		}

		private void OnHoldingEntry()
		{
			CurrentItemHeld = Raycaster.CurrentlyRaycasted;
			OnForceHoldingEntry();
		}

		private void OnHoldingExit()
		{
			InteractionHandler.HoldingStopInteraction();
			AGrabHandler currentItemHeld = CurrentItemHeld;
			currentItemHeld.EndInteraction();
			currentItemHeld.EndInteractionForced -= ReleaseHolding;
			Raycaster.UpdateRaycast();
			CurrentItemHeld = null;
			this.GrabStopped?.Invoke(currentItemHeld);
		}

		private void OnDraggingEntry()
		{
			CurrentlyDragged = Raycaster.CurrentlyRaycasted;
			Vector3? vector;
			if (CurrentlyDragged is GrabHandlerHingeJoint && GetPlaneIncidentAngle() < 30f)
			{
				vector = Raycaster.CurrentlyHit.point;
				SetupCapsuleCollider(vector.Value);
			}
			else
			{
				vector = GetPointOnPlane(forceAnyPointOnPlaneReturn: true);
				if (!vector.HasValue)
				{
					throw new InvalidOperationException("GetPointOnPlane returned null point, this shouldn't happen at this moment");
				}
			}
			CurrentlyDragged.EndInteractionForced += EndDragForced;
			CurrentlyDragged.StartInteraction(vector.Value, this);
			this.GrabStarted?.Invoke(CurrentlyDragged);
		}

		private void OnDragUpdate()
		{
			if (CurrentlyDragged == null)
			{
				Debug.LogWarning("Destroyed while dragging interactable! This should not happen!");
			}
			else if (CurrentlyDragged.AllowFeedValue() && screenspaceDraggingAllowed)
			{
				CurrentlyDragged.FeedValue(InputManager.GetMouseAxisInput().y * 1.8f);
			}
			else if (capsuleCollider != null && capsuleCollider.enabled)
			{
				Vector3? pointOnCapsule = GetPointOnCapsule();
				if (pointOnCapsule.HasValue)
				{
					CurrentlyDragged.FeedPosition(pointOnCapsule.Value);
				}
			}
			else
			{
				Vector3? pointOnPlane = GetPointOnPlane();
				if (pointOnPlane.HasValue)
				{
					CurrentlyDragged.FeedPosition(pointOnPlane.Value);
				}
			}
		}

		private void OnDraggingExit()
		{
			if (capsuleCollider != null)
			{
				capsuleCollider.transform.parent = null;
				capsuleCollider.enabled = false;
			}
			AGrabHandler currentlyDragged = CurrentlyDragged;
			CurrentlyDragged = null;
			currentlyDragged.EndInteraction();
			currentlyDragged.EndInteractionForced -= EndDragForced;
			Raycaster.UpdateRaycast();
			this.GrabStopped?.Invoke(currentlyDragged);
		}

		private void EndDragForced()
		{
			hsm.Fire(Trigger.EndInteraction);
		}

		private float GetPlaneIncidentAngle()
		{
			Vector3 planeNormal = CurrentlyDragged.transform.TransformDirection(CurrentlyDragged.GetAxis());
			Ray ray = Cursor.GetRay();
			return Vector3.Angle(Vector3.ProjectOnPlane(ray.direction, planeNormal), ray.direction);
		}

		private void SetupCapsuleCollider(Vector3 point)
		{
			if (capsuleCollider == null)
			{
				GameObject gameObject = new GameObject("Grabber HingeJoint collider");
				gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
				capsuleCollider.isTrigger = true;
				capsuleCollider.direction = 2;
			}
			capsuleCollider.enabled = true;
			Transform obj = capsuleCollider.transform;
			obj.parent = CurrentlyDragged.transform.parent;
			obj.position = CurrentlyDragged.transform.TransformPoint(CurrentlyDragged.GetAnchor());
			obj.localRotation = Quaternion.LookRotation(CurrentlyDragged.GetAxis());
			Vector3 vector = obj.InverseTransformPoint(point);
			vector.z = 0f;
			capsuleCollider.radius = Mathf.Min(1f, vector.magnitude);
		}

		private Vector3? GetPointOnCapsule()
		{
			if (capsuleCollider.Raycast(Cursor.GetRay(), out var hitInfo, 4f))
			{
				return hitInfo.point;
			}
			return null;
		}

		private Vector3? GetPointOnPlane(bool forceAnyPointOnPlaneReturn = false)
		{
			Vector3 normalized = CurrentlyDragged.transform.TransformVector(CurrentlyDragged.GetAxis()).normalized;
			Vector3 vector = CurrentlyDragged.transform.TransformPoint(CurrentlyDragged.GetAnchor());
			Ray ray = Cursor.GetRay();
			normalized = Vector3.Lerp(normalized, -ray.direction, 0.2f).normalized;
			plane.SetNormalAndPosition(normalized, vector);
			Debug.DrawRay(vector, normalized, Color.red, 0.01f);
			if (plane.Raycast(ray, out var enter))
			{
				return ray.GetPoint(enter);
			}
			if (forceAnyPointOnPlaneReturn)
			{
				return plane.ClosestPointOnPlane(vector + Vector3.Cross(normalized, UnityEngine.Random.onUnitSphere));
			}
			return null;
		}
	}
}
