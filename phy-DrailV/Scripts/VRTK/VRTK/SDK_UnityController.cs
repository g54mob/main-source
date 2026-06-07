using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_UnitySystem), 0)]
	[SDK_Description(typeof(SDK_UnitySystem), 1)]
	[SDK_Description(typeof(SDK_UnitySystem), 2)]
	[SDK_Description(typeof(SDK_UnitySystem), 3)]
	[SDK_Description(typeof(SDK_UnitySystem), 4)]
	[SDK_Description(typeof(SDK_UnitySystem), 5)]
	public class SDK_UnityController : SDK_BaseController
	{
		protected VRTK_TrackedController cachedLeftController;

		protected VRTK_TrackedController cachedRightController;

		protected SDK_UnityControllerTracker cachedLeftTracker;

		protected SDK_UnityControllerTracker cachedRightTracker;

		protected VRTK_VelocityEstimator cachedLeftVelocityEstimator;

		protected VRTK_VelocityEstimator cachedRightVelocityEstimator;

		protected Vector2 buttonPressThreshold = new Vector2(0.2f, 0.5f);

		protected Dictionary<ButtonTypes, bool> rightAxisButtonPressState = new Dictionary<ButtonTypes, bool>
		{
			{
				ButtonTypes.Trigger,
				false
			},
			{
				ButtonTypes.Grip,
				false
			}
		};

		protected Dictionary<ButtonTypes, bool> leftAxisButtonPressState = new Dictionary<ButtonTypes, bool>
		{
			{
				ButtonTypes.Trigger,
				false
			},
			{
				ButtonTypes.Grip,
				false
			}
		};

		protected List<string> validRightHands = new List<string> { "OpenVR Controller - Right", "OpenVR Controller(Vive. Controller MV) - Right", "OpenVR Controller(VIVE Controller Pro MV) - Right", "Oculus Touch - Right", "Oculus Remote" };

		protected List<string> validLeftHands = new List<string> { "OpenVR Controller - Left", "OpenVR Controller(Vive. Controller MV) - Left", "OpenVR Controller(VIVE Controller Pro MV) - Left", "Oculus Touch - Left" };

		protected int[] rightControllerTouchCodes = new int[4] { 15, 17, 10, 11 };

		protected int[] rightControllerPressCodes = new int[4] { 9, 1, 0, 7 };

		protected int[] rightOculusRemotePressCodes = new int[4] { 9, 0, 1, 7 };

		protected int[] leftControllerTouchCodes = new int[4] { 14, 16, 12, 13 };

		protected int[] leftControllerPressCodes = new int[4] { 8, 3, 2, 7 };

		protected ControllerType cachedControllerType = ControllerType.Custom;

		protected Dictionary<ButtonTypes, KeyCode?> rightControllerTouchKeyCodes = new Dictionary<ButtonTypes, KeyCode?>
		{
			{
				ButtonTypes.Trigger,
				KeyCode.JoystickButton15
			},
			{
				ButtonTypes.TriggerHairline,
				null
			},
			{
				ButtonTypes.Grip,
				null
			},
			{
				ButtonTypes.GripHairline,
				null
			},
			{
				ButtonTypes.Touchpad,
				KeyCode.JoystickButton17
			},
			{
				ButtonTypes.ButtonOne,
				KeyCode.JoystickButton10
			},
			{
				ButtonTypes.ButtonTwo,
				KeyCode.JoystickButton11
			},
			{
				ButtonTypes.StartMenu,
				null
			}
		};

		protected Dictionary<ButtonTypes, KeyCode?> rightControllerPressKeyCodes = new Dictionary<ButtonTypes, KeyCode?>
		{
			{
				ButtonTypes.Trigger,
				null
			},
			{
				ButtonTypes.TriggerHairline,
				null
			},
			{
				ButtonTypes.Grip,
				null
			},
			{
				ButtonTypes.GripHairline,
				null
			},
			{
				ButtonTypes.Touchpad,
				KeyCode.JoystickButton9
			},
			{
				ButtonTypes.ButtonOne,
				KeyCode.JoystickButton1
			},
			{
				ButtonTypes.ButtonTwo,
				KeyCode.JoystickButton0
			},
			{
				ButtonTypes.StartMenu,
				KeyCode.JoystickButton7
			}
		};

		protected Dictionary<ButtonTypes, KeyCode?> leftControllerTouchKeyCodes = new Dictionary<ButtonTypes, KeyCode?>
		{
			{
				ButtonTypes.Trigger,
				KeyCode.JoystickButton14
			},
			{
				ButtonTypes.TriggerHairline,
				null
			},
			{
				ButtonTypes.Grip,
				null
			},
			{
				ButtonTypes.GripHairline,
				null
			},
			{
				ButtonTypes.Touchpad,
				KeyCode.JoystickButton16
			},
			{
				ButtonTypes.ButtonOne,
				KeyCode.JoystickButton12
			},
			{
				ButtonTypes.ButtonTwo,
				KeyCode.JoystickButton13
			},
			{
				ButtonTypes.StartMenu,
				null
			}
		};

		protected Dictionary<ButtonTypes, KeyCode?> leftControllerPressKeyCodes = new Dictionary<ButtonTypes, KeyCode?>
		{
			{
				ButtonTypes.Trigger,
				null
			},
			{
				ButtonTypes.TriggerHairline,
				null
			},
			{
				ButtonTypes.Grip,
				null
			},
			{
				ButtonTypes.GripHairline,
				null
			},
			{
				ButtonTypes.Touchpad,
				KeyCode.JoystickButton8
			},
			{
				ButtonTypes.ButtonOne,
				KeyCode.JoystickButton3
			},
			{
				ButtonTypes.ButtonTwo,
				KeyCode.JoystickButton2
			},
			{
				ButtonTypes.StartMenu,
				KeyCode.JoystickButton7
			}
		};

		private bool settingCaches;

		public override void ProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null)
		{
			SetTrackedControllerCaches();
			return cachedControllerType;
		}

		public override string GetControllerDefaultColliderPath(ControllerHand hand)
		{
			return "ControllerColliders/Fallback";
		}

		public override string GetControllerElementPath(ControllerElements element, ControllerHand hand, bool fullPath = false)
		{
			if (element == ControllerElements.AttachPoint)
			{
				return "AttachPoint";
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
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SDK_UnityCameraRig>("LeftHandAnchor", searchAllScenes: true);
			}
			return gameObject;
		}

		public override GameObject GetControllerRightHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerRightHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SDK_UnityCameraRig>("RightHandAnchor", searchAllScenes: true);
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
				GameObject gameObject2 = null;
				switch (hand)
				{
				case ControllerHand.Left:
					gameObject2 = GetControllerLeftHand(actual: true);
					break;
				case ControllerHand.Right:
					gameObject2 = GetControllerRightHand(actual: true);
					break;
				}
				if (gameObject2 != null)
				{
					gameObject = gameObject2.transform.Find("Model").gameObject;
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
		}

		public override bool HapticPulse(VRTK_ControllerReference controllerReference, AudioClip clip)
		{
			return true;
		}

		public override SDK_ControllerHapticModifiers GetHapticModifiers()
		{
			return new SDK_ControllerHapticModifiers();
		}

		public override Vector3 GetVelocity(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				if (controllerReference.hand == ControllerHand.Left && cachedLeftVelocityEstimator != null)
				{
					return cachedLeftVelocityEstimator.GetVelocityEstimate();
				}
				if (controllerReference.hand == ControllerHand.Right && cachedRightVelocityEstimator != null)
				{
					return cachedRightVelocityEstimator.GetVelocityEstimate();
				}
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
			if (isTouched)
			{
				return VRTK_SharedMethods.Vector2ShallowCompare(currentAxisValues, previousAxisValues, compareFidelity);
			}
			return true;
		}

		public override Vector2 GetButtonAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return Vector2.zero;
			}
			bool flag = controllerReference.hand == ControllerHand.Right;
			if ((flag && cachedRightTracker == null) || (!flag && cachedLeftTracker == null))
			{
				return Vector2.zero;
			}
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
				return new Vector2(GetAxisValue(flag ? cachedRightTracker.triggerAxisName : cachedLeftTracker.triggerAxisName), 0f);
			case ButtonTypes.Grip:
				return new Vector2(GetAxisValue(flag ? cachedRightTracker.gripAxisName : cachedLeftTracker.gripAxisName), 0f);
			case ButtonTypes.Touchpad:
				return new Vector2(GetAxisValue(flag ? cachedRightTracker.touchpadHorizontalAxisName : cachedLeftTracker.touchpadHorizontalAxisName), GetAxisValue(flag ? cachedRightTracker.touchpadVerticalAxisName : cachedLeftTracker.touchpadVerticalAxisName));
			default:
				return Vector2.zero;
			}
		}

		public override float GetButtonSenseAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			return 0f;
		}

		public override float GetButtonHairlineDelta(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			return 0f;
		}

		public override bool GetControllerButtonState(ButtonTypes buttonType, ButtonPressTypes pressType, VRTK_ControllerReference controllerReference)
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			bool flag = controllerReference.hand == ControllerHand.Right;
			KeyCode? dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(flag ? rightControllerTouchKeyCodes : leftControllerTouchKeyCodes, buttonType);
			KeyCode? dictionaryValue2 = VRTK_SharedMethods.GetDictionaryValue(flag ? rightControllerPressKeyCodes : leftControllerPressKeyCodes, buttonType);
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
				switch (pressType)
				{
				case ButtonPressTypes.Touch:
				case ButtonPressTypes.TouchDown:
				case ButtonPressTypes.TouchUp:
					return IsButtonPressed(pressType, dictionaryValue, dictionaryValue2);
				case ButtonPressTypes.Press:
				case ButtonPressTypes.PressDown:
				case ButtonPressTypes.PressUp:
					if (!IsMouseAliasPress(flag, buttonType, pressType))
					{
						return IsAxisButtonPress(controllerReference, buttonType, pressType);
					}
					return true;
				}
				break;
			case ButtonTypes.Grip:
				if (!IsMouseAliasPress(flag, buttonType, pressType))
				{
					return IsAxisButtonPress(controllerReference, buttonType, pressType);
				}
				return true;
			case ButtonTypes.Touchpad:
				return IsButtonPressed(pressType, dictionaryValue, dictionaryValue2);
			case ButtonTypes.ButtonOne:
				return IsButtonPressed(pressType, dictionaryValue, dictionaryValue2);
			case ButtonTypes.ButtonTwo:
				return IsButtonPressed(pressType, dictionaryValue, dictionaryValue2);
			case ButtonTypes.StartMenu:
				return IsButtonPressed(pressType, dictionaryValue, dictionaryValue2);
			}
			return false;
		}

		protected virtual bool IsMouseAliasPress(bool validController, ButtonTypes buttonType, ButtonPressTypes pressType)
		{
			if (validController)
			{
				switch (buttonType)
				{
				case ButtonTypes.Trigger:
					return MousePressType(pressType, 0);
				case ButtonTypes.Grip:
					return MousePressType(pressType, 1);
				}
			}
			return false;
		}

		protected virtual bool MousePressType(ButtonPressTypes pressType, int buttonIndex)
		{
			switch (pressType)
			{
			case ButtonPressTypes.Press:
				return Input.GetMouseButton(buttonIndex);
			case ButtonPressTypes.PressDown:
				return Input.GetMouseButtonDown(buttonIndex);
			case ButtonPressTypes.PressUp:
				return Input.GetMouseButtonUp(buttonIndex);
			default:
				return false;
			}
		}

		protected virtual float GetAxisValue(string axisName)
		{
			try
			{
				return Input.GetAxis(axisName);
			}
			catch (ArgumentException)
			{
			}
			return 0f;
		}

		protected virtual bool IsAxisOnHandButtonPress(Dictionary<ButtonTypes, bool> axisHandState, ButtonTypes buttonType, ButtonPressTypes pressType, Vector2 axisValue)
		{
			bool dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(axisHandState, buttonType, defaultValue: false);
			if (pressType == ButtonPressTypes.PressDown && !dictionaryValue)
			{
				bool axisPressState = GetAxisPressState(dictionaryValue, axisValue.x);
				VRTK_SharedMethods.AddDictionaryValue(axisHandState, buttonType, axisPressState, overwriteExisting: true);
				return axisPressState;
			}
			if (pressType == ButtonPressTypes.PressUp && dictionaryValue)
			{
				bool axisPressState2 = GetAxisPressState(dictionaryValue, axisValue.x);
				VRTK_SharedMethods.AddDictionaryValue(axisHandState, buttonType, axisPressState2, overwriteExisting: true);
				return !axisPressState2;
			}
			return false;
		}

		protected virtual bool IsAxisButtonPress(VRTK_ControllerReference controllerReference, ButtonTypes buttonType, ButtonPressTypes pressType)
		{
			bool flag = controllerReference.hand == ControllerHand.Right;
			Vector2 buttonAxis = GetButtonAxis(buttonType, controllerReference);
			return IsAxisOnHandButtonPress(flag ? rightAxisButtonPressState : leftAxisButtonPressState, buttonType, pressType, buttonAxis);
		}

		protected virtual bool GetAxisPressState(bool currentState, float axisValue)
		{
			if (currentState && axisValue <= buttonPressThreshold.x)
			{
				currentState = false;
			}
			else if (!currentState && axisValue >= buttonPressThreshold.y)
			{
				currentState = true;
			}
			return currentState;
		}

		protected virtual bool IsButtonPressed(ButtonPressTypes pressType, KeyCode? touchKey, KeyCode? pressKey)
		{
			switch (pressType)
			{
			case ButtonPressTypes.Touch:
				if (touchKey.HasValue)
				{
					return Input.GetKey(touchKey.Value);
				}
				return false;
			case ButtonPressTypes.TouchDown:
				if (touchKey.HasValue)
				{
					return Input.GetKeyDown(touchKey.Value);
				}
				return false;
			case ButtonPressTypes.TouchUp:
				if (touchKey.HasValue)
				{
					return Input.GetKeyUp(touchKey.Value);
				}
				return false;
			case ButtonPressTypes.Press:
				if (pressKey.HasValue)
				{
					return Input.GetKey(pressKey.Value);
				}
				return false;
			case ButtonPressTypes.PressDown:
				if (pressKey.HasValue)
				{
					return Input.GetKeyDown(pressKey.Value);
				}
				return false;
			case ButtonPressTypes.PressUp:
				if (pressKey.HasValue)
				{
					return Input.GetKeyUp(pressKey.Value);
				}
				return false;
			default:
				return false;
			}
		}

		protected virtual void SetTrackedControllerCaches(bool forceRefresh = false)
		{
			if (settingCaches)
			{
				return;
			}
			settingCaches = true;
			if (forceRefresh)
			{
				cachedLeftController = null;
				cachedRightController = null;
			}
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				if (cachedLeftController == null && instance.loadedSetup.actualLeftController != null)
				{
					cachedLeftController = instance.loadedSetup.actualLeftController.GetComponent<VRTK_TrackedController>();
					SetControllerIndex(ref cachedLeftController);
					if (cachedLeftController != null)
					{
						cachedLeftTracker = cachedLeftController.GetComponent<SDK_UnityControllerTracker>();
						cachedLeftVelocityEstimator = cachedLeftController.GetComponent<VRTK_VelocityEstimator>();
						SetControllerButtons(ControllerHand.Left);
					}
				}
				if (cachedRightController == null && instance.loadedSetup.actualRightController != null)
				{
					cachedRightController = instance.loadedSetup.actualRightController.GetComponent<VRTK_TrackedController>();
					SetControllerIndex(ref cachedRightController);
					if (cachedRightController != null)
					{
						cachedRightTracker = cachedRightController.GetComponent<SDK_UnityControllerTracker>();
						cachedRightVelocityEstimator = cachedRightController.GetComponent<VRTK_VelocityEstimator>();
						SetControllerButtons(ControllerHand.Right);
					}
				}
			}
			settingCaches = false;
		}

		protected virtual void SetControllerButtons(ControllerHand hand)
		{
			List<string> list = ((hand == ControllerHand.Right) ? validRightHands : validLeftHands);
			bool flag = false;
			int joystickIndex = 0;
			string[] joystickNames = Input.GetJoystickNames();
			for (int i = 0; i < joystickNames.Length; i++)
			{
				if (list.Contains(joystickNames[i]))
				{
					SetCachedControllerType(joystickNames[i]);
					flag = true;
					joystickIndex = i + 1;
				}
			}
			if (!flag)
			{
				SDK_BaseHeadset.HeadsetType headsetType = VRTK_DeviceFinder.GetHeadsetType();
				if (headsetType == SDK_BaseHeadset.HeadsetType.GoogleDaydream)
				{
					SetCachedControllerType("googledaydream");
					flag = true;
					joystickIndex = 1;
				}
			}
			if (flag)
			{
				if (hand == ControllerHand.Right)
				{
					int[] pressCodes = ((cachedControllerType == ControllerType.Oculus_OculusRemote) ? rightOculusRemotePressCodes : rightControllerPressCodes);
					SetControllerButtonValues(ref rightControllerTouchKeyCodes, ref rightControllerPressKeyCodes, joystickIndex, rightControllerTouchCodes, pressCodes);
				}
				else
				{
					SetControllerButtonValues(ref leftControllerTouchKeyCodes, ref leftControllerPressKeyCodes, joystickIndex, leftControllerTouchCodes, leftControllerPressCodes);
				}
			}
			else if (joystickNames.Length != 0 && VRTK_ControllerReference.GetControllerReference(hand) != null && VRTK_ControllerReference.GetControllerReference(hand).actual.gameObject.activeInHierarchy)
			{
				VRTK_Logger.Warn(string.Concat("Failed setting controller buttons on [", hand, "] due to no valid joystick type found in `GetJoyStickNames` -> ", string.Join(", ", joystickNames)));
			}
		}

		protected virtual void SetCachedControllerType(string givenType)
		{
			givenType = givenType.ToLower();
			if (!(givenType == "googledaydream"))
			{
				if (givenType == "oculus remote")
				{
					cachedControllerType = ControllerType.Oculus_OculusRemote;
				}
				else if (givenType.Contains("openvr controller"))
				{
					switch (VRTK_DeviceFinder.GetHeadsetType())
					{
					case SDK_BaseHeadset.HeadsetType.HTCVive:
						cachedControllerType = ControllerType.SteamVR_ViveWand;
						break;
					case SDK_BaseHeadset.HeadsetType.OculusRift:
						cachedControllerType = ControllerType.SteamVR_OculusTouch;
						break;
					}
				}
				else if (givenType.Contains("oculus touch"))
				{
					cachedControllerType = ControllerType.Oculus_OculusTouch;
				}
			}
			else
			{
				cachedControllerType = ControllerType.Daydream_Controller;
			}
		}

		protected virtual void SetControllerButtonValues(ref Dictionary<ButtonTypes, KeyCode?> touchKeyCodes, ref Dictionary<ButtonTypes, KeyCode?> pressKeyCodes, int joystickIndex, int[] touchCodes, int[] pressCodes)
		{
			VRTK_SharedMethods.AddDictionaryValue(touchKeyCodes, ButtonTypes.Trigger, StringToKeyCode(joystickIndex, touchCodes[0]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(touchKeyCodes, ButtonTypes.Touchpad, StringToKeyCode(joystickIndex, touchCodes[1]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(touchKeyCodes, ButtonTypes.ButtonOne, StringToKeyCode(joystickIndex, touchCodes[2]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(touchKeyCodes, ButtonTypes.ButtonTwo, StringToKeyCode(joystickIndex, touchCodes[3]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(pressKeyCodes, ButtonTypes.Touchpad, StringToKeyCode(joystickIndex, pressCodes[0]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(pressKeyCodes, ButtonTypes.ButtonOne, StringToKeyCode(joystickIndex, pressCodes[1]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(pressKeyCodes, ButtonTypes.ButtonTwo, StringToKeyCode(joystickIndex, pressCodes[2]), overwriteExisting: true);
			VRTK_SharedMethods.AddDictionaryValue(pressKeyCodes, ButtonTypes.StartMenu, StringToKeyCode(joystickIndex, pressCodes[3]), overwriteExisting: true);
		}

		protected virtual KeyCode StringToKeyCode(int index, int code)
		{
			return (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + index + "Button" + code);
		}

		protected virtual void SetControllerIndex(ref VRTK_TrackedController trackedController)
		{
			if (trackedController != null)
			{
				SDK_UnityControllerTracker component = trackedController.GetComponent<SDK_UnityControllerTracker>();
				if (component != null)
				{
					trackedController.index = component.index;
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
	}
}
