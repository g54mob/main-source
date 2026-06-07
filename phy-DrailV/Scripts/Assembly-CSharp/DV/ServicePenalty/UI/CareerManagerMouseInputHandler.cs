using System.Linq;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.Utils;
using Rewired;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerMouseInputHandler : AGrabHandler, IScrollable
	{
		public DisplayScreenSwitcher screenController;

		private static Grabber nonVrGrabber;

		private static LayerMask screenLayerMask = -1;

		[SerializeField]
		private Collider interactionCollider;

		private CameraZoom _cameraZoom;

		private bool isLookingAtScreen;

		private bool shouldToggleCameraZoom;

		private CameraZoom CameraZoom
		{
			get
			{
				if (!_cameraZoom)
				{
					_cameraZoom = PlayerManager.PlayerCamera.GetComponent<CameraZoom>();
				}
				return _cameraZoom;
			}
		}

		public override bool IsItem => false;

		private void Awake()
		{
			if ((int)screenLayerMask == -1)
			{
				screenLayerMask = LayerMask.GetMask("Laser_Pointer_Target");
			}
			if (screenController == null)
			{
				Debug.LogError("screenController isn't set!, CareerManagerMouseInputHandler can't function. Destroying self!");
				Object.Destroy(this);
			}
			if (interactionCollider == null)
			{
				Debug.LogError("CareerManagerMouseInputHandler: Missing interaction collider. This should not happen.", this);
			}
			else
			{
				interactionColliders.Add(interactionCollider);
			}
			DV.Interaction.Inputs.InputManager.KeybindingsChanged += OnKeybindingsChanged;
			OnKeybindingsChanged();
			base.enabled = false;
		}

		private void OnKeybindingsChanged()
		{
			int[] first = GetMapIDsForAction(DV.Interaction.Inputs.InputManager.Actions.Zoom);
			int[] second = GetMapIDsForAction(DV.Interaction.Inputs.InputManager.Actions.InteractionPrimary);
			int[] second2 = GetMapIDsForAction(DV.Interaction.Inputs.InputManager.Actions.InteractionSecondary);
			shouldToggleCameraZoom = first.Intersect(second).Any() || first.Intersect(second2).Any();
			int[] GetMapIDsForAction(int actionID)
			{
				return (from x in DV.Interaction.Inputs.InputManager.NewPlayer.controllers.maps.GetAllMaps().SelectMany((ControllerMap m) => m.GetButtonMapsWithAction(actionID))
					select x.elementIdentifierId).ToArray();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			DV.Interaction.Inputs.InputManager.KeybindingsChanged -= OnKeybindingsChanged;
			SetupListeners(on: false);
		}

		private void OnTriggerEnter(Collider other)
		{
			Transform playerTransform = PlayerManager.PlayerTransform;
			if ((bool)playerTransform && nonVrGrabber == null)
			{
				nonVrGrabber = playerTransform.GetComponentInChildren<Grabber>();
				if (nonVrGrabber == null)
				{
					Debug.LogError("Couldn't extract Grabber from player", this);
				}
			}
			if (other.transform == playerTransform)
			{
				base.enabled = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.transform == PlayerManager.PlayerTransform)
			{
				base.enabled = false;
				if (isLookingAtScreen)
				{
					isLookingAtScreen = false;
					PlayerManager.PlayerCamera.GetComponent<CameraZoom>().RemoveZoomDisableRequest(this);
				}
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<MouseInputEvents>.Instance.UiInteractionPrimaryDown += OnInteractionPrimaryDown;
				SingletonBehaviour<MouseInputEvents>.Instance.UiInteractionSecondaryDown += OnInteractionSecondaryDown;
			}
			else if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<MouseInputEvents>.Instance.UiInteractionPrimaryDown -= OnInteractionPrimaryDown;
				SingletonBehaviour<MouseInputEvents>.Instance.UiInteractionSecondaryDown -= OnInteractionSecondaryDown;
			}
		}

		private void Update()
		{
			bool flag = isLookingAtScreen;
			isLookingAtScreen = nonVrGrabber.Raycaster.CurrentlyRaycasted == this && (!shouldToggleCameraZoom || !CameraZoom.IsMouseZoomedIn);
			if (flag && !isLookingAtScreen)
			{
				if (shouldToggleCameraZoom)
				{
					CameraZoom.RemoveZoomDisableRequest(this);
				}
				PlayerManager.PlayerTransform.GetComponent<PlayerScreenspaceMouse>().disallowEscapingScreenspace = false;
				SetupListeners(on: false);
			}
			else if (!flag && isLookingAtScreen)
			{
				if (shouldToggleCameraZoom)
				{
					CameraZoom.RequestZoomDisable(this, 0f);
				}
				PlayerManager.PlayerTransform.GetComponent<PlayerScreenspaceMouse>().disallowEscapingScreenspace = true;
				SetupListeners(on: true);
			}
		}

		private void OnInteractionPrimaryDown()
		{
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				screenController.HandleInput(InputAction.Confirm);
			}
		}

		private void OnInteractionSecondaryDown()
		{
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				screenController.HandleInput(InputAction.Cancel);
			}
		}

		public override Vector3 GetAxis()
		{
			return default(Vector3);
		}

		public override Vector3 GetAnchor()
		{
			return default(Vector3);
		}

		public override void FeedPosition(Vector3 worldPosition)
		{
		}

		public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			ForceEndInteraction();
		}

		public void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse)
		{
			if (base.enabled && action != ScrollAction.Release)
			{
				screenController.HandleInput(action.IsPositive() ? InputAction.Up : InputAction.Down);
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			return false;
		}
	}
}
