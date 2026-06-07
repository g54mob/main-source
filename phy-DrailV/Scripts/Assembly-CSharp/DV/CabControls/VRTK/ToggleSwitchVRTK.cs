using System.Collections;
using DV.VR;
using UnityEngine;
using VRTK;

namespace DV.CabControls.VRTK
{
	public class ToggleSwitchVRTK : ToggleSwitchBase
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		private bool useOverrideButtonSet;

		private IControlTouchBehaviourVRTK touchBehaviour;

		private bool touchInteraction;

		protected override void Awake()
		{
			base.Awake();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = false;
			interactable.isUsable = true;
			interactable.InteractableObjectUsed += delegate
			{
				Use();
			};
			interactable.priority = 1;
			interactable.pipaExclusiveInteraction = true;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			if (!spec.disableTouchUse)
			{
				touchBehaviour = GetComponent<IControlTouchBehaviourVRTK>();
				if (touchBehaviour == null)
				{
					((SpeedZoneControlTouchBehaviour)(touchBehaviour = SpeedZoneControlTouchBehaviour.Setup(base.gameObject))).direction.up = base.transform.TransformDirection(spec.touchInteractionAxis);
				}
				interactable.InteractableObjectTouched += OnTouched;
				interactable.InteractableObjectUntouched += OnUntouched;
				GamePreferences.RegisterToPreferenceUpdated(Preferences.TouchInteraction, TouchInteractionChanged);
				TouchInteractionChanged();
			}
			base.gameObject.AddComponent<TelegrabbableUseControl>();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!spec.disableTouchUse)
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.TouchInteraction, TouchInteractionChanged);
			}
		}

		private void TouchInteractionChanged()
		{
			touchInteraction = GamePreferences.Get<bool>(Preferences.TouchInteraction);
		}

		private void OnTouched(object sender, InteractableObjectEventArgs e)
		{
			if (interactable.isUsable && touchInteraction)
			{
				touchBehaviour.Touch(e);
			}
		}

		private void OnUntouched(object sender, InteractableObjectEventArgs e)
		{
			if (interactable.isUsable && touchInteraction)
			{
				touchBehaviour.UnTouch(e);
			}
		}

		private void OnDisable()
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		private void OnEnable()
		{
			if (!useOverrideButtonSet)
			{
				if (TransmogrifyControllers.IsControllerReadyLeft || TransmogrifyControllers.IsControllerReadyRight)
				{
					StartCoroutine(SetUseButtonOverride());
				}
				else
				{
					SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
				}
			}
		}

		private IEnumerator SetUseButtonOverride()
		{
			int safety = 3;
			while (safety-- > 0 && SetupDeviceSpecificControls.useOverrideButtonForButtonComponent == VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				yield return null;
			}
			if (safety == 0)
			{
				Debug.LogError($"Toggle wait time expired. Setting override to: {SetupDeviceSpecificControls.useOverrideButtonForButtonComponent}", this);
			}
			interactable.useOverrideButton = SetupDeviceSpecificControls.useOverrideButtonForButtonComponent;
			useOverrideButtonSet = true;
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand obj)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			StartCoroutine(SetUseButtonOverride());
		}

		public override bool IsGrabbed()
		{
			return false;
		}

		public override void ForceEndInteraction()
		{
			interactable.ForceStopInteracting();
		}
	}
}
