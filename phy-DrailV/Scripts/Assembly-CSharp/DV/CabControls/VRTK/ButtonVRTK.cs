using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls.Spec;
using DV.VR;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.CabControls.VRTK
{
	public class ButtonVRTK : ButtonBase
	{
		private class ButtonDefaultTouchBehaviour : IControlTouchBehaviourVRTK
		{
			private readonly ButtonVRTK button;

			public ButtonDefaultTouchBehaviour(ButtonVRTK buttonVrtk)
			{
				button = buttonVrtk;
			}

			public void Touch(InteractableObjectEventArgs e)
			{
				if (!button.IsHoldMode || !button.IsOn)
				{
					float timeSinceLevelLoad = Time.timeSinceLevelLoad;
					if (timeSinceLevelLoad - button.interactionTimeStart >= button.interactionTimeThreshold)
					{
						button.interactable.StartUsing();
						button.interactionTimeStart = timeSinceLevelLoad;
					}
				}
			}

			public void UnTouch(InteractableObjectEventArgs e)
			{
				button.interactable.StopUsing();
			}
		}

		private VRTK_ControlImplBaseInteractableObject interactable;

		[SerializeField]
		private float interactionTimeThreshold = 0.5f;

		[SerializeField]
		private float interactionTimeStart;

		private bool useOverrideButtonSet;

		private IControlTouchBehaviourVRTK touchBehaviour;

		private bool touchInteraction;

		private bool holdModeUsedByController;

		private IHoverReaction[] hoverReactions;

		public event Action<ControlImplBase> Touched;

		public event Action<ControlImplBase> Untouched;

		protected override void Awake()
		{
			base.Awake();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = false;
			interactable.isUsable = true;
			interactable.InteractableObjectUsed += delegate
			{
				if (!base.IsHoldMode || !base.IsOn)
				{
					Use();
					if (base.IsHoldMode)
					{
						holdModeUsedByController = true;
					}
				}
			};
			interactable.InteractableObjectUnused += delegate
			{
				if (base.IsHoldMode && base.IsOn && holdModeUsedByController)
				{
					Use();
					holdModeUsedByController = false;
				}
			};
			if (!spec.disableTouchUse)
			{
				touchBehaviour = GetComponent<IControlTouchBehaviourVRTK>();
				if (touchBehaviour == null)
				{
					SpeedZoneControlTouchBehaviour speedZoneControlTouchBehaviour = (SpeedZoneControlTouchBehaviour)(touchBehaviour = SpeedZoneControlTouchBehaviour.Setup(base.gameObject));
					speedZoneControlTouchBehaviour.direction.up = base.transform.forward;
					speedZoneControlTouchBehaviour.onlyDoForwardDirection = true;
					if (spec.isTogglingBack)
					{
						speedZoneControlTouchBehaviour.useOnUntouch = true;
					}
				}
				interactable.InteractableObjectTouched += OnTouched;
				interactable.InteractableObjectUntouched += OnUntouched;
				GamePreferences.RegisterToPreferenceUpdated(Preferences.TouchInteraction, TouchInteractionChanged);
				TouchInteractionChanged();
			}
			interactable.priority = 1;
			interactable.pipaExclusiveInteraction = true;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			hoverReactions = GetComponents<IHoverReaction>();
			base.gameObject.AddComponent<TelegrabbableButton>();
		}

		private void OnDestroy()
		{
			if (!spec.disableTouchUse)
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.TouchInteraction, TouchInteractionChanged);
			}
		}

		private void TouchInteractionChanged()
		{
			touchInteraction = GamePreferences.Get<bool>(Preferences.TouchInteraction);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (!UnloadWatcher.isQuitting)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		private void OnTouched(object sender, InteractableObjectEventArgs e)
		{
			this.Touched?.Invoke(this);
			IHoverReaction[] array = hoverReactions;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnHovered();
			}
			if (interactable.isUsable && touchInteraction)
			{
				touchBehaviour.Touch(e);
			}
		}

		private void OnUntouched(object sender, InteractableObjectEventArgs e)
		{
			this.Untouched?.Invoke(this);
			IHoverReaction[] array = hoverReactions;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnUnhovered();
			}
			if (holdModeUsedByController)
			{
				Use();
				holdModeUsedByController = false;
			}
			if (interactable.isUsable && touchInteraction)
			{
				touchBehaviour.UnTouch(e);
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand obj)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			StartCoroutine(SetUseButtonOverride());
		}

		protected override void OnEnable()
		{
			base.OnEnable();
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
				Debug.LogError($"Button wait time expired. Setting override to: {SetupDeviceSpecificControls.useOverrideButtonForButtonComponent}", this);
			}
			VRTK_ControllerReference controllerReferenceRightHand = VRTK_DeviceFinder.GetControllerReferenceRightHand();
			bool flag = controllerReferenceRightHand.IsValid() && controllerReferenceRightHand.IsWandOrUndefined();
			VRTK_ControllerReference controllerReferenceLeftHand = VRTK_DeviceFinder.GetControllerReferenceLeftHand();
			bool flag2 = controllerReferenceLeftHand.IsValid() && controllerReferenceLeftHand.IsWandOrUndefined();
			if (spec.overrideUseButton == VRControllerButton.Undefined || flag || flag2)
			{
				interactable.useOverrideButton = SetupDeviceSpecificControls.useOverrideButtonForButtonComponent;
			}
			else
			{
				interactable.useOverrideButton = GetMatchingVRTKButton(spec.overrideUseButton);
			}
			useOverrideButtonSet = true;
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		public override bool IsGrabbed()
		{
			return false;
		}

		public List<GameObject> GetTouchingControllers()
		{
			return (from t in interactable.GetTouchingObjects()
				where VRTK_ControllerReference.GetControllerReference(t) != null
				select t).ToList();
		}

		public override void ForceEndInteraction()
		{
			interactable.ForceStopInteracting();
		}

		private static VRTK_ControllerEvents.ButtonAlias GetMatchingVRTKButton(VRControllerButton button)
		{
			switch (button)
			{
			case VRControllerButton.Undefined:
				return VRTK_ControllerEvents.ButtonAlias.Undefined;
			case VRControllerButton.Trigger:
				return VRTK_ControllerEvents.ButtonAlias.TriggerPress;
			case VRControllerButton.Grip:
				return VRTK_ControllerEvents.ButtonAlias.GripPress;
			default:
				throw new ArgumentOutOfRangeException("button", button, null);
			}
		}
	}
}
