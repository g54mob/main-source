using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_OculusSystem), 0)]
	[SDK_Description(typeof(SDK_OculusSystem), 1)]
	public class SDK_OculusController : SDK_BaseController
	{
		protected SDK_OculusBoundaries cachedBoundariesSDK;

		protected VRTK_TrackedController cachedLeftController;

		protected VRTK_TrackedController cachedRightController;

		protected OVRInput.RawAxis2D[] thumbsticks = new OVRInput.RawAxis2D[2]
		{
			OVRInput.RawAxis2D.LThumbstick,
			OVRInput.RawAxis2D.RThumbstick
		};

		protected OVRInput.RawAxis2D[] touchpads = new OVRInput.RawAxis2D[2]
		{
			OVRInput.RawAxis2D.LTouchpad,
			OVRInput.RawAxis2D.RTouchpad
		};

		protected OVRInput.RawAxis1D[] triggers = new OVRInput.RawAxis1D[2]
		{
			OVRInput.RawAxis1D.LIndexTrigger,
			OVRInput.RawAxis1D.RIndexTrigger
		};

		protected OVRInput.RawAxis1D[] grips = new OVRInput.RawAxis1D[2]
		{
			OVRInput.RawAxis1D.LHandTrigger,
			OVRInput.RawAxis1D.RHandTrigger
		};

		protected OVRInput.RawNearTouch[] triggerSense = new OVRInput.RawNearTouch[2]
		{
			OVRInput.RawNearTouch.LIndexTrigger,
			OVRInput.RawNearTouch.RIndexTrigger
		};

		protected OVRInput.RawNearTouch[] touchpadSense = new OVRInput.RawNearTouch[2]
		{
			OVRInput.RawNearTouch.LThumbButtons,
			OVRInput.RawNearTouch.RThumbButtons
		};

		protected VRTK_VelocityEstimator cachedLeftVelocityEstimator;

		protected VRTK_VelocityEstimator cachedRightVelocityEstimator;

		protected bool[] previousHairTriggerState = new bool[2];

		protected bool[] currentHairTriggerState = new bool[2];

		protected bool[] previousHairGripState = new bool[2];

		protected bool[] currentHairGripState = new bool[2];

		protected float[] hairTriggerLimit = new float[2];

		protected float[] hairGripLimit = new float[2];

		protected OVRHapticsClip hapticsProceduralClipLeft;

		protected OVRHapticsClip hapticsProceduralClipRight;

		public override void OnAfterSetupLoad(VRTK_SDKSetup setup)
		{
			base.OnAfterSetupLoad(setup);
			if (hapticsProceduralClipLeft == null && hapticsProceduralClipRight == null)
			{
				OVRHaptics.Config.Load();
				hapticsProceduralClipLeft = new OVRHapticsClip();
				hapticsProceduralClipRight = new OVRHapticsClip();
			}
		}

		public override void ProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
			ProcessControllerUpdate(controllerReference);
		}

		public override void ProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null)
		{
			OVRInput.Controller connectedControllers = OVRInput.GetConnectedControllers();
			if ((connectedControllers & OVRInput.Controller.Touch) != OVRInput.Controller.None)
			{
				return ControllerType.Oculus_OculusTouch;
			}
			if ((connectedControllers & OVRInput.Controller.Remote) == OVRInput.Controller.Remote)
			{
				return ControllerType.Oculus_OculusRemote;
			}
			if ((connectedControllers & OVRInput.Controller.Gamepad) == OVRInput.Controller.Gamepad)
			{
				return ControllerType.Oculus_OculusGamepad;
			}
			return ControllerType.Undefined;
		}

		public override string GetControllerDefaultColliderPath(ControllerHand hand)
		{
			if (HasAvatar() && GetCurrentControllerType() == ControllerType.Oculus_OculusTouch)
			{
				return "ControllerColliders/OculusTouch_" + hand;
			}
			return "ControllerColliders/Fallback";
		}

		public override string GetControllerElementPath(ControllerElements element, ControllerHand hand, bool fullPath = false)
		{
			if (GetAvatar() != null && GetCurrentControllerType() == ControllerType.Oculus_OculusTouch)
			{
				string text = (fullPath ? "" : "");
				string text2 = "controller_" + ((hand == ControllerHand.Left) ? "left" : "right") + "_renderPart_0";
				string text3 = ((hand == ControllerHand.Left) ? "l" : "r") + "ctrl:";
				string text4 = text3 + ((hand == ControllerHand.Left) ? "left" : "right") + "_touch_controller_world";
				string text5 = text2 + "/" + text4 + "/" + text3 + "b_";
				switch (element)
				{
				case ControllerElements.AttachPoint:
					return "";
				case ControllerElements.Trigger:
					return text5 + "trigger" + text;
				case ControllerElements.GripLeft:
					return text5 + "hold" + text;
				case ControllerElements.GripRight:
					return text5 + "hold" + text;
				case ControllerElements.Touchpad:
					return text5 + "stick/" + text3 + "b_stick_IGNORE" + text;
				case ControllerElements.ButtonOne:
					return text5 + "button01" + text;
				case ControllerElements.ButtonTwo:
					return text5 + "button02" + text;
				case ControllerElements.SystemMenu:
					return text5 + "button03" + text;
				case ControllerElements.StartMenu:
					return text5 + "button03" + text;
				case ControllerElements.Body:
					return text2;
				}
			}
			return "";
		}

		public override uint GetControllerIndex(GameObject controller)
		{
			VRTK_TrackedController trackedObject = GetTrackedObject(controller);
			if (!(trackedObject != null))
			{
				return uint.MaxValue;
			}
			return trackedObject.index;
		}

		public override GameObject GetControllerByIndex(uint index, bool actual = false)
		{
			SetTrackedControllerCaches();
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null)
			{
				if (cachedLeftController != null && cachedLeftController.index == index)
				{
					if (!actual)
					{
						return instance.scriptAliasLeftController;
					}
					return instance.loadedSetup.actualLeftController;
				}
				if (cachedRightController != null && cachedRightController.index == index)
				{
					if (!actual)
					{
						return instance.scriptAliasRightController;
					}
					return instance.loadedSetup.actualRightController;
				}
			}
			return null;
		}

		public override Transform GetControllerOrigin(VRTK_ControllerReference controllerReference)
		{
			return VRTK_SDK_Bridge.GetPlayArea();
		}

		[Obsolete("GenerateControllerPointerOrigin has been deprecated and will be removed in a future version of VRTK.")]
		public override Transform GenerateControllerPointerOrigin(GameObject parent)
		{
			return null;
		}

		public override GameObject GetControllerLeftHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerLeftHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<OVRCameraRig>("TrackingSpace/LeftHandAnchor", searchAllScenes: true);
			}
			return gameObject;
		}

		public override GameObject GetControllerRightHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerRightHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<OVRCameraRig>("TrackingSpace/RightHandAnchor", searchAllScenes: true);
			}
			return gameObject;
		}

		public override bool IsControllerLeftHand(GameObject controller)
		{
			return CheckActualOrScriptAliasControllerIsLeftHand(controller);
		}

		public override bool IsControllerRightHand(GameObject controller)
		{
			return CheckActualOrScriptAliasControllerIsRightHand(controller);
		}

		public override bool IsControllerLeftHand(GameObject controller, bool actual)
		{
			return CheckControllerLeftHand(controller, actual);
		}

		public override bool IsControllerRightHand(GameObject controller, bool actual)
		{
			return CheckControllerRightHand(controller, actual);
		}

		public override bool WaitForControllerModel(ControllerHand hand)
		{
			if (HasAvatar())
			{
				return ShouldWaitForControllerModel(hand, ignoreChildCount: false);
			}
			return false;
		}

		public override GameObject GetControllerModel(GameObject controller)
		{
			return GetControllerModelFromController(controller);
		}

		public override GameObject GetControllerModel(ControllerHand hand)
		{
			GameObject gameObject = GetSDKManagerControllerModelForHand(hand);
			if (gameObject == null)
			{
				GameObject avatar = GetAvatar();
				switch (hand)
				{
				case ControllerHand.Left:
					if (avatar != null)
					{
						gameObject = avatar.transform.Find("controller_left").gameObject;
						break;
					}
					gameObject = GetControllerLeftHand(actual: true);
					gameObject = ((gameObject != null && gameObject.transform.childCount > 0) ? gameObject.transform.GetChild(0).gameObject : null);
					break;
				case ControllerHand.Right:
					if (avatar != null)
					{
						gameObject = avatar.transform.Find("controller_right").gameObject;
						break;
					}
					gameObject = GetControllerRightHand(actual: true);
					gameObject = ((gameObject != null && gameObject.transform.childCount > 0) ? gameObject.transform.GetChild(0).gameObject : null);
					break;
				}
			}
			return gameObject;
		}

		public override GameObject GetControllerRenderModel(VRTK_ControllerReference controllerReference)
		{
			return null;
		}

		public override void SetControllerRenderModelWheel(GameObject renderModel, bool state)
		{
		}

		public override void HapticPulse(VRTK_ControllerReference controllerReference, float strength = 0.5f)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
				GameObject controllerByIndex = GetControllerByIndex(realIndex);
				if (IsControllerLeftHand(controllerByIndex))
				{
					hapticsProceduralClipLeft.Reset();
					hapticsProceduralClipLeft.WriteSample((byte)(strength * 255f));
					OVRHaptics.LeftChannel.Preempt(hapticsProceduralClipLeft);
				}
				else if (IsControllerRightHand(controllerByIndex))
				{
					hapticsProceduralClipRight.Reset();
					hapticsProceduralClipRight.WriteSample((byte)(strength * 255f));
					OVRHaptics.RightChannel.Preempt(hapticsProceduralClipRight);
				}
			}
		}

		public override bool HapticPulse(VRTK_ControllerReference controllerReference, AudioClip clip)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
				GameObject controllerByIndex = GetControllerByIndex(realIndex);
				if (IsControllerLeftHand(controllerByIndex))
				{
					OVRHaptics.LeftChannel.Preempt(new OVRHapticsClip(clip));
				}
				else if (IsControllerRightHand(controllerByIndex))
				{
					OVRHaptics.RightChannel.Preempt(new OVRHapticsClip(clip));
				}
			}
			return true;
		}

		public override SDK_ControllerHapticModifiers GetHapticModifiers()
		{
			return new SDK_ControllerHapticModifiers
			{
				durationModifier = 0.8f,
				intervalModifier = 1f
			};
		}

		public override Vector3 GetVelocity(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				return OVRInput.GetLocalControllerVelocity(GetControllerMask(controllerReference.index));
			}
			return Vector3.zero;
		}

		public override Vector3 GetAngularVelocity(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				if (controllerReference.hand == ControllerHand.Left && cachedLeftVelocityEstimator != null)
				{
					return cachedLeftVelocityEstimator.GetAngularVelocityEstimate();
				}
				if (controllerReference.hand == ControllerHand.Right && cachedRightVelocityEstimator != null)
				{
					return cachedRightVelocityEstimator.GetAngularVelocityEstimate();
				}
			}
			return Vector3.zero;
		}

		public override bool IsTouchpadStatic(bool isTouched, Vector2 currentAxisValues, Vector2 previousAxisValues, int compareFidelity)
		{
			return VRTK_SharedMethods.Vector2ShallowCompare(currentAxisValues, previousAxisValues, compareFidelity);
		}

		public override Vector2 GetButtonAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return Vector2.zero;
			}
			OVRInput.Controller controllerMask = GetControllerMask(controllerReference.index);
			switch (buttonType)
			{
			case ButtonTypes.Touchpad:
				return OVRInput.Get(GetTouchpadAxisMask(controllerReference.index), controllerMask);
			case ButtonTypes.Trigger:
				return new Vector2(OVRInput.Get(triggers[controllerReference.index], controllerMask), 0f);
			case ButtonTypes.Grip:
				return new Vector2(OVRInput.Get(grips[controllerReference.index], controllerMask), 0f);
			default:
				return Vector2.zero;
			}
		}

		public override float GetButtonSenseAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return 0f;
			}
			bool flag = false;
			OVRInput.Controller controllerMask = GetControllerMask(controllerReference.index);
			switch (buttonType)
			{
			case ButtonTypes.Touchpad:
				flag = OVRInput.Get(touchpadSense[controllerReference.index], controllerMask);
				break;
			case ButtonTypes.Trigger:
				flag = OVRInput.Get(triggerSense[controllerReference.index], controllerMask);
				break;
			}
			if (!flag)
			{
				return 0f;
			}
			return 1f;
		}

		public override float GetButtonHairlineDelta(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return 0f;
			}
			return 0.1f;
		}

		public override bool GetControllerButtonState(ButtonTypes buttonType, ButtonPressTypes pressType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
				switch (pressType)
				{
				case ButtonPressTypes.Press:
				case ButtonPressTypes.PressDown:
				case ButtonPressTypes.PressUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Button.PrimaryIndexTrigger);
				case ButtonPressTypes.Touch:
				case ButtonPressTypes.TouchDown:
				case ButtonPressTypes.TouchUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Touch.PrimaryIndexTrigger);
				}
				break;
			case ButtonTypes.TriggerHairline:
				switch (pressType)
				{
				case ButtonPressTypes.PressDown:
					if (currentHairTriggerState[realIndex])
					{
						return !previousHairTriggerState[realIndex];
					}
					return false;
				case ButtonPressTypes.PressUp:
					if (!currentHairTriggerState[realIndex])
					{
						return previousHairTriggerState[realIndex];
					}
					return false;
				}
				break;
			case ButtonTypes.Grip:
				return IsButtonPressed(realIndex, pressType, OVRInput.Button.PrimaryHandTrigger);
			case ButtonTypes.GripHairline:
				switch (pressType)
				{
				case ButtonPressTypes.PressDown:
					if (currentHairGripState[realIndex])
					{
						return !previousHairGripState[realIndex];
					}
					return false;
				case ButtonPressTypes.PressUp:
					if (!currentHairGripState[realIndex])
					{
						return previousHairGripState[realIndex];
					}
					return false;
				}
				break;
			case ButtonTypes.Touchpad:
				switch (pressType)
				{
				case ButtonPressTypes.Press:
				case ButtonPressTypes.PressDown:
				case ButtonPressTypes.PressUp:
					return IsButtonPressed(realIndex, pressType, GetTouchpadButtonMask());
				case ButtonPressTypes.Touch:
				case ButtonPressTypes.TouchDown:
				case ButtonPressTypes.TouchUp:
					return IsButtonPressed(realIndex, pressType, GetTouchpadTouchMask());
				}
				break;
			case ButtonTypes.ButtonOne:
				switch (pressType)
				{
				case ButtonPressTypes.Press:
				case ButtonPressTypes.PressDown:
				case ButtonPressTypes.PressUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Button.One);
				case ButtonPressTypes.Touch:
				case ButtonPressTypes.TouchDown:
				case ButtonPressTypes.TouchUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Touch.One);
				}
				break;
			case ButtonTypes.ButtonTwo:
				switch (pressType)
				{
				case ButtonPressTypes.Press:
				case ButtonPressTypes.PressDown:
				case ButtonPressTypes.PressUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Button.Two);
				case ButtonPressTypes.Touch:
				case ButtonPressTypes.TouchDown:
				case ButtonPressTypes.TouchUp:
					return IsButtonPressed(realIndex, pressType, OVRInput.Touch.Two);
				}
				break;
			case ButtonTypes.StartMenu:
				return IsButtonPressed(realIndex, pressType, OVRInput.Button.Start);
			}
			return false;
		}

		protected virtual void Awake()
		{
			GameObject avatar = GetAvatar();
			if (avatar != null)
			{
				defaultSDKLeftControllerModel = avatar.transform.Find("controller_left");
				defaultSDKRightControllerModel = avatar.transform.Find("controller_right");
			}
			RegisterAvatarEvents();
		}

		protected virtual void RegisterAvatarEvents()
		{
			if (!HasAvatar())
			{
				return;
			}
			GetBoundariesSDK();
			if (cachedBoundariesSDK != null)
			{
				OvrAvatar avatar = cachedBoundariesSDK.GetAvatar();
				bool flag = defaultSDKLeftControllerModel != null && defaultSDKRightControllerModel != null && GetControllerModel(ControllerHand.Left) == defaultSDKLeftControllerModel.gameObject && GetControllerModel(ControllerHand.Right) == defaultSDKRightControllerModel.gameObject;
				if (avatar != null && flag)
				{
					avatar.AssetsDoneLoading.AddListener(BothControllersReady);
				}
			}
		}

		protected virtual void BothControllersReady()
		{
			OnControllerModelReady(ControllerHand.Left, VRTK_ControllerReference.GetControllerReference(0u));
			OnControllerModelReady(ControllerHand.Right, VRTK_ControllerReference.GetControllerReference(1u));
		}

		protected virtual void ProcessControllerUpdate(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
				if (!(GetTrackedObject(controllerReference.actual) == null))
				{
					UpdateHairValues(realIndex, GetButtonAxis(ButtonTypes.Trigger, controllerReference).x, GetButtonHairlineDelta(ButtonTypes.Trigger, controllerReference), ref previousHairTriggerState[realIndex], ref currentHairTriggerState[realIndex], ref hairTriggerLimit[realIndex]);
					UpdateHairValues(realIndex, GetButtonAxis(ButtonTypes.Grip, controllerReference).x, GetButtonHairlineDelta(ButtonTypes.Grip, controllerReference), ref previousHairGripState[realIndex], ref currentHairGripState[realIndex], ref hairGripLimit[realIndex]);
				}
			}
		}

		protected virtual void SetTrackedControllerCaches(bool forceRefresh = false)
		{
			if (forceRefresh)
			{
				cachedLeftController = null;
				cachedRightController = null;
			}
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (!(instance != null))
			{
				return;
			}
			if (cachedLeftController == null && (bool)instance.loadedSetup.actualLeftController)
			{
				cachedLeftController = instance.loadedSetup.actualLeftController.GetComponent<VRTK_TrackedController>();
				if (cachedLeftController != null)
				{
					cachedLeftController.index = 0u;
					cachedLeftVelocityEstimator = ((cachedLeftController.GetComponent<VRTK_VelocityEstimator>() != null) ? cachedLeftController.GetComponent<VRTK_VelocityEstimator>() : cachedLeftController.gameObject.AddComponent<VRTK_VelocityEstimator>());
				}
			}
			if (cachedRightController == null && (bool)instance.loadedSetup.actualRightController)
			{
				cachedRightController = instance.loadedSetup.actualRightController.GetComponent<VRTK_TrackedController>();
				if (cachedRightController != null)
				{
					cachedRightController.index = 1u;
					cachedRightVelocityEstimator = ((cachedRightController.GetComponent<VRTK_VelocityEstimator>() != null) ? cachedRightController.GetComponent<VRTK_VelocityEstimator>() : cachedRightController.gameObject.AddComponent<VRTK_VelocityEstimator>());
				}
			}
		}

		protected virtual VRTK_TrackedController GetTrackedObject(GameObject controller)
		{
			SetTrackedControllerCaches();
			VRTK_TrackedController result = null;
			if (IsControllerLeftHand(controller))
			{
				result = cachedLeftController;
			}
			else if (IsControllerRightHand(controller))
			{
				result = cachedRightController;
			}
			return result;
		}

		protected virtual bool IsButtonPressed(uint index, ButtonPressTypes type, OVRInput.Button button)
		{
			if (index >= uint.MaxValue)
			{
				return false;
			}
			if (GetTrackedObject(GetControllerByIndex(index)) != null)
			{
				OVRInput.Controller controllerMask = GetControllerMask(index);
				switch (type)
				{
				case ButtonPressTypes.Press:
					return OVRInput.Get(button, controllerMask);
				case ButtonPressTypes.PressDown:
					return OVRInput.GetDown(button, controllerMask);
				case ButtonPressTypes.PressUp:
					return OVRInput.GetUp(button, controllerMask);
				}
			}
			return false;
		}

		protected virtual bool IsButtonPressed(uint index, ButtonPressTypes type, OVRInput.Touch button)
		{
			if (index >= uint.MaxValue)
			{
				return false;
			}
			if (GetTrackedObject(GetControllerByIndex(index)) != null)
			{
				OVRInput.Controller controllerMask = GetControllerMask(index);
				switch (type)
				{
				case ButtonPressTypes.Touch:
					return OVRInput.Get(button, controllerMask);
				case ButtonPressTypes.TouchDown:
					return OVRInput.GetDown(button, controllerMask);
				case ButtonPressTypes.TouchUp:
					return OVRInput.GetUp(button, controllerMask);
				}
			}
			return false;
		}

		protected virtual OVRInput.Controller GetControllerMask(uint index)
		{
			OVRInput.Controller connectedControllers = OVRInput.GetConnectedControllers();
			switch (connectedControllers)
			{
			case OVRInput.Controller.Touch:
			case OVRInput.Controller.Touch | OVRInput.Controller.Remote:
			case OVRInput.Controller.Touch | OVRInput.Controller.Gamepad:
			case OVRInput.Controller.Touch | OVRInput.Controller.Remote | OVRInput.Controller.Gamepad:
				switch (index)
				{
				default:
					return OVRInput.Controller.None;
				case 1u:
					return OVRInput.Controller.RTouch;
				case 0u:
					return OVRInput.Controller.LTouch;
				}
			case OVRInput.Controller.LTouch:
				if (index != 0)
				{
					return OVRInput.Controller.None;
				}
				return OVRInput.Controller.LTouch;
			case OVRInput.Controller.RTouch:
				if (index != 1)
				{
					return OVRInput.Controller.None;
				}
				return OVRInput.Controller.RTouch;
			default:
				return connectedControllers;
			}
		}

		protected virtual OVRInput.RawAxis2D GetTouchpadAxisMask(uint index)
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.Oculus_OculusTouch || currentControllerType == ControllerType.Oculus_OculusGamepad)
			{
				return thumbsticks[index];
			}
			return touchpads[index];
		}

		protected virtual OVRInput.Touch GetTouchpadTouchMask()
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.Oculus_OculusTouch || currentControllerType == ControllerType.Oculus_OculusGamepad)
			{
				return OVRInput.Touch.PrimaryThumbstick;
			}
			return OVRInput.Touch.PrimaryTouchpad;
		}

		protected virtual OVRInput.Button GetTouchpadButtonMask()
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.Oculus_OculusTouch || currentControllerType == ControllerType.Oculus_OculusGamepad)
			{
				return OVRInput.Button.PrimaryThumbstick;
			}
			return OVRInput.Button.PrimaryTouchpad;
		}

		protected virtual void UpdateHairValues(uint index, float axisValue, float hairDelta, ref bool previousState, ref bool currentState, ref float hairLimit)
		{
			previousState = currentState;
			if (currentState)
			{
				if (axisValue < hairLimit - hairDelta || axisValue <= 0f)
				{
					currentState = false;
				}
			}
			else if (axisValue > hairLimit + hairDelta || axisValue >= 1f)
			{
				currentState = true;
			}
			hairLimit = (currentState ? Mathf.Max(hairLimit, axisValue) : Mathf.Min(hairLimit, axisValue));
		}

		protected virtual SDK_OculusBoundaries GetBoundariesSDK()
		{
			if (cachedBoundariesSDK == null)
			{
				cachedBoundariesSDK = (VRTK_SDKManager.instance ? VRTK_SDKManager.instance.loadedSetup.boundariesSDK : ScriptableObject.CreateInstance<SDK_OculusBoundaries>()) as SDK_OculusBoundaries;
			}
			return cachedBoundariesSDK;
		}

		protected virtual bool HasAvatar(bool controllersAreVisible = true)
		{
			GetBoundariesSDK();
			if (cachedBoundariesSDK != null)
			{
				OvrAvatar avatar = cachedBoundariesSDK.GetAvatar();
				if (avatar != null && controllersAreVisible)
				{
					return avatar.StartWithControllers;
				}
				return false;
			}
			return false;
		}

		protected virtual GameObject GetAvatar()
		{
			GetBoundariesSDK();
			if (cachedBoundariesSDK != null)
			{
				OvrAvatar avatar = cachedBoundariesSDK.GetAvatar();
				if (avatar != null)
				{
					return avatar.gameObject;
				}
			}
			return null;
		}
	}
}
