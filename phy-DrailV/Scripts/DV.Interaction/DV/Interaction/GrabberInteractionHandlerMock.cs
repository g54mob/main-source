using System;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabberInteractionHandlerMock : MonoBehaviour, IGrabberInteractionHandler
	{
		private IGrabberRaycaster raycaster;

		private Grabber grabber;

		public event Action<AGrabHandler> ForceHoldRequested;

		public event Action DropRequested;

		public event Action StartInteractionRequested;

		public event Action EndInteractionRequested;

		private void Awake()
		{
			raycaster = GetComponent<IGrabberRaycaster>();
			grabber = GetComponent<Grabber>();
		}

		public void RequestStartInteraction()
		{
			this.StartInteractionRequested?.Invoke();
		}

		public void RequestEndInteraction()
		{
			this.EndInteractionRequested?.Invoke();
		}

		public void RequestForceHold(AGrabHandler grabHandler)
		{
			if (!(grabber.CurrentItemHeld != null))
			{
				this.ForceHoldRequested?.Invoke(grabHandler);
			}
		}

		public void RequestDrop()
		{
			this.DropRequested?.Invoke();
		}

		public Grabber.Trigger? IdleStartInteraction()
		{
			AGrabHandler currentlyRaycasted = raycaster.CurrentlyRaycasted;
			if (currentlyRaycasted == null)
			{
				return null;
			}
			if (currentlyRaycasted.IsDraggable && grabber.CurrentlyDragged == null)
			{
				return Grabber.Trigger.Drag;
			}
			if (currentlyRaycasted.IsItem && grabber.CurrentItemHeld == null)
			{
				return Grabber.Trigger.Hold;
			}
			return null;
		}

		public Grabber.Trigger? HoldingStartInteraction()
		{
			AGrabHandler currentItemHeld = grabber.CurrentItemHeld;
			if (!currentItemHeld)
			{
				Debug.LogError("There should be an item here");
			}
			if (raycaster.CurrentlyRaycasted != null && raycaster.CurrentlyRaycasted != currentItemHeld && raycaster.CurrentlyRaycasted.IsDraggable)
			{
				return Grabber.Trigger.Drag;
			}
			currentItemHeld.Use();
			return null;
		}

		public Grabber.Trigger? HoldingStopInteraction()
		{
			return null;
		}
	}
}
