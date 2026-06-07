using System;
using DV.CabControls;
using DV.Common;
using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabberInteractionHandlerDV : MonoBehaviour, IGrabberInteractionHandler
	{
		private IGrabberRaycaster raycaster;

		private ItemPlacerNonVr itemPlacer;

		private Grabber grabber;

		private CanvasController.ElementType interactionBlockers = CanvasController.ElementType.Blockers | CanvasController.ElementType.Hotbar;

		public bool IsHoldingLocked { get; private set; }

		public event Action<AGrabHandler> ForceHoldRequested;

		public event Action DropRequested;

		public event Action StartInteractionRequested;

		public event Action EndInteractionRequested;

		private void Awake()
		{
			raycaster = GetComponent<IGrabberRaycaster>();
			itemPlacer = GetComponentInChildren<ItemPlacerNonVr>();
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
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
			{
				return null;
			}
			if ((bool)SingletonBehaviour<HighlightNearbyItems>.Instance && grabber.CurrentItemHeld == null && grabber.Raycaster.CurrentlyRaycasted == null && !SingletonBehaviour<ScreenspaceMouse>.Instance.on && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				SingletonBehaviour<HighlightNearbyItems>.Instance.Ping();
			}
			AGrabHandler currentlyRaycasted = raycaster.CurrentlyRaycasted;
			if (currentlyRaycasted == null)
			{
				return null;
			}
			if (currentlyRaycasted.IsDraggable && grabber.CurrentlyDragged == null)
			{
				if (currentlyRaycasted.IsItem)
				{
					if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.ItemGrab))
					{
						return Grabber.Trigger.Drag;
					}
					return null;
				}
				if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.WorldInteraction))
				{
					return Grabber.Trigger.Drag;
				}
				return null;
			}
			if (!SingletonBehaviour<ScreenspaceMouse>.Instance.on && currentlyRaycasted.IsItem && grabber.CurrentItemHeld == null)
			{
				if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.ItemGrab))
				{
					return Grabber.Trigger.Hold;
				}
				return null;
			}
			return null;
		}

		public Grabber.Trigger? HoldingStartInteraction()
		{
			if (SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				return null;
			}
			if (itemPlacer.Processing)
			{
				return null;
			}
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(interactionBlockers))
			{
				return null;
			}
			AGrabHandler currentItemHeld = grabber.CurrentItemHeld;
			if (!currentItemHeld)
			{
				Debug.LogError("There should be an item here", this);
				return null;
			}
			if (raycaster.CurrentlyRaycasted != null && raycaster.CurrentlyRaycasted != currentItemHeld && raycaster.CurrentlyRaycasted.IsDraggable && SingletonBehaviour<ScreenspaceMouse>.Instance.on)
			{
				return Grabber.Trigger.Drag;
			}
			if (!currentItemHeld.isUsable)
			{
				return null;
			}
			if (SingletonBehaviour<ScreenspaceMouse>.Instance.on && raycaster.CurrentlyRaycasted != currentItemHeld)
			{
				return null;
			}
			currentItemHeld.Use();
			if (!currentItemHeld.continuousUse)
			{
				currentItemHeld.UnUse();
			}
			else
			{
				SetupContinuousUseEvents(on: true);
			}
			return null;
		}

		private void SetupContinuousUseEvents(bool on)
		{
			if (on)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += OnCanvasElementToggled;
				itemPlacer.ItemPlacementStarted += OnPlacementStarted;
			}
			else
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= OnCanvasElementToggled;
				itemPlacer.ItemPlacementStarted -= OnPlacementStarted;
			}
		}

		private void OnPlacementStarted(ItemBase _, bool __, GameObject ___)
		{
			EndUse();
		}

		private void OnCanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
		{
			if (element.Type == CanvasController.ElementType.MouseMode)
			{
				EndUse();
			}
			else if (interactionBlockers.HasUnknownFlag(element.Type) && SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(interactionBlockers))
			{
				EndUse();
			}
		}

		private void EndUse()
		{
			AGrabHandler currentItemHeld = grabber.CurrentItemHeld;
			if (!currentItemHeld)
			{
				Debug.LogError("There should be an item here", this);
			}
			else if (currentItemHeld.IsUsed)
			{
				currentItemHeld.UnUse();
				if (currentItemHeld.continuousUse)
				{
					SetupContinuousUseEvents(on: false);
				}
			}
		}

		public Grabber.Trigger? HoldingStopInteraction()
		{
			if (!grabber.CurrentItemHeld)
			{
				Debug.LogError("There should be an item here", this);
				return null;
			}
			EndUse();
			return null;
		}

		public void LockHolding()
		{
			if (IsHoldingLocked)
			{
				Debug.LogError("Trying to lock holding but is locked already!");
			}
			IsHoldingLocked = true;
		}

		public void UnlockHolding()
		{
			if (!IsHoldingLocked)
			{
				Debug.LogError("Trying to unlock holding but is not locked!");
			}
			IsHoldingLocked = false;
		}
	}
}
