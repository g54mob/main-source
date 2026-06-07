using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRTK
{
	[SDK_Description(typeof(SDK_SteamVRSystem), 0)]
	public class SDK_SteamVRController : SDK_BaseController
	{
		protected SteamVR_TrackedObject cachedLeftTrackedObject;

		protected SteamVR_TrackedObject cachedRightTrackedObject;

		protected Dictionary<GameObject, SteamVR_TrackedObject> cachedTrackedObjectsByGameObject = new Dictionary<GameObject, SteamVR_TrackedObject>();

		protected Dictionary<uint, SteamVR_TrackedObject> cachedTrackedObjectsByIndex = new Dictionary<uint, SteamVR_TrackedObject>();

		protected Dictionary<EVRButtonId, bool> axisTouchStates = new Dictionary<EVRButtonId, bool>();

		protected Dictionary<EVRButtonId, float> axisTouchFidelity = new Dictionary<EVRButtonId, float>
		{
			{
				EVRButtonId.k_EButton_Axis0,
				0f
			},
			{
				EVRButtonId.k_EButton_Axis2,
				0.25f
			}
		};

		protected ushort maxHapticVibration = 3999;

		private static Dictionary<uint, ControllerType> cachedControllerTypeMap = new Dictionary<uint, ControllerType>();

		private bool isOculusRift;

		public override void ProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null)
		{
			uint num = uint.MaxValue;
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				num = controllerReference.index;
			}
			else
			{
				VRTK_ControllerReference controllerReference2 = VRTK_ControllerReference.GetControllerReference(GetControllerLeftHand());
				VRTK_ControllerReference controllerReference3 = VRTK_ControllerReference.GetControllerReference(GetControllerRightHand());
				if (!VRTK_ControllerReference.IsValid(controllerReference2) && !VRTK_ControllerReference.IsValid(controllerReference3))
				{
					return ControllerType.Undefined;
				}
				num = (VRTK_ControllerReference.IsValid(controllerReference3) ? controllerReference3.index : controllerReference2.index);
				cachedControllerTypeMap.Remove(num);
			}
			ControllerType value = ControllerType.Undefined;
			if (num < uint.MaxValue && !cachedControllerTypeMap.TryGetValue(num, out value))
			{
				string modelNumber = GetModelNumber(num);
				value = MatchControllerTypeByString(modelNumber);
				cachedControllerTypeMap[num] = value;
			}
			return value;
		}

		public override string GetControllerDefaultColliderPath(ControllerHand hand)
		{
			switch (GetCurrentControllerType())
			{
			case ControllerType.SteamVR_ViveWand:
				return "ControllerColliders/HTCVive";
			case ControllerType.SteamVR_OculusTouch:
				if (hand != ControllerHand.Left)
				{
					return "ControllerColliders/SteamVROculusTouch_Right";
				}
				return "ControllerColliders/SteamVROculusTouch_Left";
			case ControllerType.SteamVR_ValveKnuckles:
				if (hand != ControllerHand.Left)
				{
					return "ControllerColliders/ValveKnuckles_Right";
				}
				return "ControllerColliders/ValveKnuckles_Left";
			case ControllerType.SteamVR_WindowsMRController:
				if (hand != ControllerHand.Left)
				{
					return "ControllerColliders/SteamVRWindowsMRController_Right";
				}
				return "ControllerColliders/SteamVRWindowsMRController_Left";
			default:
				return "ControllerColliders/Fallback";
			}
		}

		public override string GetControllerElementPath(ControllerElements element, ControllerHand hand, bool fullPath = false)
		{
			string text = (fullPath ? "/attach" : "");
			switch (element)
			{
			case ControllerElements.AttachPoint:
				return "tip/attach";
			case ControllerElements.Trigger:
				return "trigger" + text;
			case ControllerElements.GripLeft:
				return GetControllerGripPath(hand, text, ControllerHand.Left);
			case ControllerElements.GripRight:
				return GetControllerGripPath(hand, text, ControllerHand.Right);
			case ControllerElements.Touchpad:
				return GetControllerTouchpadPath(hand, text);
			case ControllerElements.ButtonOne:
				return GetControllerButtonOnePath(hand, text);
			case ControllerElements.ButtonTwo:
				return GetControllerButtonTwoPath(hand, text);
			case ControllerElements.SystemMenu:
				return GetControllerSystemMenuPath(hand, text);
			case ControllerElements.StartMenu:
				return GetControllerStartMenuPath(hand, text);
			case ControllerElements.Body:
				return "body";
			default:
				return "";
			}
		}

		public override uint GetControllerIndex(GameObject controller)
		{
			SteamVR_TrackedObject trackedObject = GetTrackedObject(controller);
			if (!(trackedObject != null))
			{
				return uint.MaxValue;
			}
			return (uint)trackedObject.index;
		}

		public override GameObject GetControllerByIndex(uint index, bool actual = false)
		{
			SetTrackedControllerCaches();
			if (index < uint.MaxValue)
			{
				VRTK_SDKManager instance = VRTK_SDKManager.instance;
				if (instance != null)
				{
					if (cachedLeftTrackedObject != null && cachedLeftTrackedObject.index == (SteamVR_TrackedObject.EIndex)index)
					{
						if (!actual)
						{
							return instance.scriptAliasLeftController;
						}
						return instance.loadedSetup.actualLeftController;
					}
					if (cachedRightTrackedObject != null && cachedRightTrackedObject.index == (SteamVR_TrackedObject.EIndex)index)
					{
						if (!actual)
						{
							return instance.scriptAliasRightController;
						}
						return instance.loadedSetup.actualRightController;
					}
				}
				SteamVR_TrackedObject dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(cachedTrackedObjectsByIndex, index);
				if (dictionaryValue != null)
				{
					return dictionaryValue.gameObject;
				}
			}
			return null;
		}

		public override Transform GetControllerOrigin(VRTK_ControllerReference controllerReference)
		{
			SteamVR_TrackedObject trackedObject = GetTrackedObject(controllerReference.actual);
			if (trackedObject != null)
			{
				if (!(trackedObject.origin != null))
				{
					return trackedObject.transform.parent;
				}
				return trackedObject.origin;
			}
			return null;
		}

		[Obsolete("GenerateControllerPointerOrigin has been deprecated and will be removed in a future version of VRTK.")]
		public override Transform GenerateControllerPointerOrigin(GameObject parent)
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.SteamVR_OculusTouch && (IsControllerLeftHand(parent) || IsControllerRightHand(parent)))
			{
				GameObject gameObject = new GameObject(parent.name + " _CustomPointerOrigin");
				gameObject.transform.SetParent(parent.transform);
				gameObject.transform.localEulerAngles = new Vector3(40f, 0f, 0f);
				gameObject.transform.localPosition = new Vector3(IsControllerLeftHand(parent) ? 0.0081f : (-0.0081f), -0.0273f, -0.0311f);
				return gameObject.transform;
			}
			return null;
		}

		public override GameObject GetControllerLeftHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerLeftHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SteamVR_ControllerManager>("Controller (left)", searchAllScenes: true);
			}
			return gameObject;
		}

		public override GameObject GetControllerRightHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerRightHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = VRTK_SharedMethods.FindEvenInactiveGameObject<SteamVR_ControllerManager>("Controller (right)", searchAllScenes: true);
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
			return ShouldWaitForControllerModel(hand, ignoreChildCount: false);
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
				switch (hand)
				{
				case ControllerHand.Left:
					gameObject = ((defaultSDKLeftControllerModel != null) ? defaultSDKLeftControllerModel.gameObject : null);
					break;
				case ControllerHand.Right:
					gameObject = ((defaultSDKRightControllerModel != null) ? defaultSDKRightControllerModel.gameObject : null);
					break;
				}
			}
			return gameObject;
		}

		public override GameObject GetControllerRenderModel(VRTK_ControllerReference controllerReference)
		{
			SteamVR_RenderModel componentInChildren = controllerReference.actual.GetComponentInChildren<SteamVR_RenderModel>();
			if (!(componentInChildren != null))
			{
				return null;
			}
			return componentInChildren.gameObject;
		}

		public override void SetControllerRenderModelWheel(GameObject renderModel, bool state)
		{
			SteamVR_RenderModel component = renderModel.GetComponent<SteamVR_RenderModel>();
			if (component != null)
			{
				component.controllerModeState.bScrollWheelVisible = state;
			}
		}

		public override void HapticPulse(VRTK_ControllerReference controllerReference, float strength = 0.5f)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex < uint.MaxValue)
			{
				float num = (float)(int)maxHapticVibration * strength;
				SteamVR_Controller.Input((int)realIndex).TriggerHapticPulse((ushort)num);
			}
		}

		public override bool HapticPulse(VRTK_ControllerReference controllerReference, AudioClip clip)
		{
			return false;
		}

		public override SDK_ControllerHapticModifiers GetHapticModifiers()
		{
			return new SDK_ControllerHapticModifiers
			{
				maxHapticVibration = maxHapticVibration
			};
		}

		public override Vector3 GetVelocity(VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex == 0 || realIndex >= uint.MaxValue)
			{
				return Vector3.zero;
			}
			return SteamVR_Controller.Input((int)realIndex).velocity;
		}

		public override Vector3 GetAngularVelocity(VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex == 0 || realIndex >= uint.MaxValue)
			{
				return Vector3.zero;
			}
			return SteamVR_Controller.Input((int)realIndex).angularVelocity;
		}

		public override bool IsTouchpadStatic(bool isTouched, Vector2 currentAxisValues, Vector2 previousAxisValues, int compareFidelity)
		{
			if (isOculusRift)
			{
				return VRTK_SharedMethods.Vector2ShallowCompare(currentAxisValues, previousAxisValues, compareFidelity);
			}
			if (isTouched)
			{
				return VRTK_SharedMethods.Vector2ShallowCompare(currentAxisValues, previousAxisValues, compareFidelity);
			}
			return true;
		}

		public override Vector2 GetButtonAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex >= uint.MaxValue)
			{
				return Vector2.zero;
			}
			SteamVR_Controller.Device device = SteamVR_Controller.Input((int)realIndex);
			switch (buttonType)
			{
			case ButtonTypes.Touchpad:
				return device.GetAxis();
			case ButtonTypes.TouchpadTwo:
				if (VRTK_DeviceFinder.GetCurrentControllerType(controllerReference) != ControllerType.SteamVR_WindowsMRController)
				{
					return Vector2.zero;
				}
				return device.GetAxis(EVRButtonId.k_EButton_Axis2);
			case ButtonTypes.Trigger:
				return device.GetAxis(EVRButtonId.k_EButton_Axis1);
			case ButtonTypes.Grip:
			{
				ControllerType currentControllerType = GetCurrentControllerType(controllerReference);
				if (currentControllerType == ControllerType.SteamVR_OculusTouch || currentControllerType == ControllerType.SteamVR_ValveKnuckles)
				{
					return device.GetAxis(EVRButtonId.k_EButton_Axis2);
				}
				return new Vector2(GetControllerButtonState(buttonType, ButtonPressTypes.Press, controllerReference) ? 1f : 0f, 0f);
			}
			default:
				return Vector2.zero;
			}
		}

		public override float GetButtonSenseAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex >= uint.MaxValue)
			{
				return 0f;
			}
			SteamVR_Controller.Device device = SteamVR_Controller.Input((int)realIndex);
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
				return device.GetAxis(EVRButtonId.k_EButton_Axis3).x;
			case ButtonTypes.Grip:
				return device.GetAxis(EVRButtonId.k_EButton_Axis2).x;
			case ButtonTypes.MiddleFinger:
				return device.GetAxis(EVRButtonId.k_EButton_Axis3).y;
			case ButtonTypes.RingFinger:
				return device.GetAxis(EVRButtonId.k_EButton_Axis4).x;
			case ButtonTypes.PinkyFinger:
				return device.GetAxis(EVRButtonId.k_EButton_Axis4).y;
			default:
				return 0f;
			}
		}

		public override float GetButtonHairlineDelta(ButtonTypes buttonType, VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex >= uint.MaxValue)
			{
				return 0f;
			}
			SteamVR_Controller.Device device = SteamVR_Controller.Input((int)realIndex);
			if (buttonType != ButtonTypes.Trigger && buttonType != ButtonTypes.TriggerHairline)
			{
				return 0f;
			}
			return device.hairTriggerDelta;
		}

		public override bool GetControllerButtonState(ButtonTypes buttonType, ButtonPressTypes pressType, VRTK_ControllerReference controllerReference)
		{
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			if (realIndex >= uint.MaxValue)
			{
				return false;
			}
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
				return IsButtonPressed(realIndex, pressType, 8589934592uL);
			case ButtonTypes.TriggerHairline:
				switch (pressType)
				{
				case ButtonPressTypes.PressDown:
					return SteamVR_Controller.Input((int)realIndex).GetHairTriggerDown();
				case ButtonPressTypes.PressUp:
					return SteamVR_Controller.Input((int)realIndex).GetHairTriggerUp();
				}
				break;
			case ButtonTypes.Grip:
				return IsButtonPressed(realIndex, pressType, 4uL);
			case ButtonTypes.Touchpad:
				return IsButtonPressed(realIndex, pressType, 4294967296uL);
			case ButtonTypes.ButtonOne:
				return IsButtonPressed(realIndex, pressType, 128uL);
			case ButtonTypes.ButtonTwo:
				return IsButtonPressed(realIndex, pressType, 2uL);
			case ButtonTypes.StartMenu:
				return IsButtonPressed(realIndex, pressType, 1uL);
			case ButtonTypes.TouchpadTwo:
				if (VRTK_DeviceFinder.GetCurrentControllerType(controllerReference) != ControllerType.SteamVR_WindowsMRController)
				{
					return false;
				}
				return CheckAxisTouch(realIndex, pressType, EVRButtonId.k_EButton_Axis2);
			}
			return false;
		}

		protected virtual void Awake()
		{
			defaultSDKLeftControllerModel = ((GetControllerLeftHand(actual: true) != null) ? GetControllerLeftHand(actual: true).transform.Find("Model") : null);
			defaultSDKRightControllerModel = ((GetControllerRightHand(actual: true) != null) ? GetControllerRightHand(actual: true).transform.Find("Model") : null);
			SteamVR_Events.System(EVREventType.VREvent_TrackedDeviceRoleChanged).Listen(OnTrackedDeviceRoleChanged);
			SteamVR_Events.RenderModelLoaded.Listen(OnRenderModelLoaded);
			SetTrackedControllerCaches(forceRefresh: true);
		}

		protected virtual void OnTrackedDeviceRoleChanged<T>(T ignoredArgument)
		{
			SetTrackedControllerCaches(forceRefresh: true);
		}

		protected virtual void OnRenderModelLoaded(SteamVR_RenderModel givenControllerRenderModel, bool successfullyLoaded)
		{
			if (successfullyLoaded)
			{
				SteamVR_RenderModel steamVR_RenderModel = ((GetControllerLeftHand(actual: true) != null) ? GetControllerLeftHand(actual: true).GetComponentInChildren<SteamVR_RenderModel>() : null);
				SteamVR_RenderModel steamVR_RenderModel2 = ((GetControllerRightHand(actual: true) != null) ? GetControllerRightHand(actual: true).GetComponentInChildren<SteamVR_RenderModel>() : null);
				ControllerHand hand = ControllerHand.None;
				if (givenControllerRenderModel == steamVR_RenderModel)
				{
					hand = ControllerHand.Left;
				}
				else if (givenControllerRenderModel == steamVR_RenderModel2)
				{
					hand = ControllerHand.Right;
				}
				OnControllerModelReady(hand, VRTK_ControllerReference.GetControllerReference((uint)givenControllerRenderModel.index));
			}
		}

		protected virtual void SetTrackedControllerCaches(bool forceRefresh = false)
		{
			if (forceRefresh)
			{
				cachedLeftTrackedObject = null;
				cachedRightTrackedObject = null;
				cachedTrackedObjectsByGameObject.Clear();
				cachedTrackedObjectsByIndex.Clear();
			}
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null)
			{
				if (cachedLeftTrackedObject == null && (bool)instance.loadedSetup.actualLeftController)
				{
					cachedLeftTrackedObject = instance.loadedSetup.actualLeftController.GetComponent<SteamVR_TrackedObject>();
				}
				if (cachedRightTrackedObject == null && (bool)instance.loadedSetup.actualRightController)
				{
					cachedRightTrackedObject = instance.loadedSetup.actualRightController.GetComponent<SteamVR_TrackedObject>();
				}
			}
		}

		protected virtual SteamVR_TrackedObject GetTrackedObject(GameObject controller)
		{
			SetTrackedControllerCaches();
			if (IsControllerLeftHand(controller))
			{
				return cachedLeftTrackedObject;
			}
			if (IsControllerRightHand(controller))
			{
				return cachedRightTrackedObject;
			}
			if (controller == null)
			{
				return null;
			}
			SteamVR_TrackedObject dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(cachedTrackedObjectsByGameObject, controller);
			if (dictionaryValue != null)
			{
				return dictionaryValue;
			}
			SteamVR_TrackedObject component = controller.GetComponent<SteamVR_TrackedObject>();
			if (component != null)
			{
				VRTK_SharedMethods.AddDictionaryValue(cachedTrackedObjectsByGameObject, controller, component, overwriteExisting: true);
				VRTK_SharedMethods.AddDictionaryValue(cachedTrackedObjectsByIndex, (uint)component.index, component, overwriteExisting: true);
			}
			return component;
		}

		protected virtual bool IsButtonPressed(uint index, ButtonPressTypes type, ulong button)
		{
			if (index >= uint.MaxValue)
			{
				return false;
			}
			SteamVR_Controller.Device device = SteamVR_Controller.Input((int)index);
			switch (type)
			{
			case ButtonPressTypes.Press:
				return device.GetPress(button);
			case ButtonPressTypes.PressDown:
				return device.GetPressDown(button);
			case ButtonPressTypes.PressUp:
				return device.GetPressUp(button);
			case ButtonPressTypes.Touch:
				return device.GetTouch(button);
			case ButtonPressTypes.TouchDown:
				return device.GetTouchDown(button);
			case ButtonPressTypes.TouchUp:
				return device.GetTouchUp(button);
			default:
				return false;
			}
		}

		protected virtual bool CheckAxisTouch(uint index, ButtonPressTypes type, EVRButtonId axisId)
		{
			if (index >= uint.MaxValue)
			{
				return false;
			}
			Vector2 axis = SteamVR_Controller.Input((int)index).GetAxis(axisId);
			bool dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(axisTouchStates, axisId, defaultValue: false, setMissingKey: true);
			float dictionaryValue2 = VRTK_SharedMethods.GetDictionaryValue(axisTouchFidelity, axisId, 0f);
			switch (type)
			{
			case ButtonPressTypes.Touch:
				return !VRTK_SharedMethods.Vector3ShallowCompare(axis, Vector2.zero, dictionaryValue2);
			case ButtonPressTypes.TouchDown:
				if (!dictionaryValue && !VRTK_SharedMethods.Vector3ShallowCompare(axis, Vector2.zero, dictionaryValue2))
				{
					VRTK_SharedMethods.AddDictionaryValue(axisTouchStates, axisId, value: true, overwriteExisting: true);
					return true;
				}
				return false;
			case ButtonPressTypes.TouchUp:
				if (dictionaryValue && VRTK_SharedMethods.Vector3ShallowCompare(axis, Vector2.zero, dictionaryValue2))
				{
					VRTK_SharedMethods.AddDictionaryValue(axisTouchStates, axisId, value: false, overwriteExisting: true);
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		protected virtual string GetControllerGripPath(ControllerHand hand, string suffix, ControllerHand forceHand)
		{
			switch (GetCurrentControllerType())
			{
			case ControllerType.SteamVR_ViveWand:
				return ((forceHand == ControllerHand.Left) ? "lgrip" : "rgrip") + suffix;
			case ControllerType.SteamVR_ValveKnuckles:
				return "button_b" + suffix;
			case ControllerType.SteamVR_OculusTouch:
				return "grip" + suffix;
			case ControllerType.SteamVR_WindowsMRController:
				return "handgrip" + suffix;
			default:
				return null;
			}
		}

		protected virtual string GetControllerTouchpadPath(ControllerHand hand, string suffix)
		{
			switch (GetCurrentControllerType())
			{
			case ControllerType.SteamVR_ViveWand:
			case ControllerType.SteamVR_ValveKnuckles:
			case ControllerType.SteamVR_WindowsMRController:
				return "trackpad" + suffix;
			case ControllerType.SteamVR_OculusTouch:
				return "thumbstick" + suffix;
			default:
				return null;
			}
		}

		protected virtual string GetControllerButtonOnePath(ControllerHand hand, string suffix)
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.SteamVR_OculusTouch)
			{
				return ((hand == ControllerHand.Left) ? "x_button" : "a_button") + suffix;
			}
			return null;
		}

		protected virtual string GetControllerButtonTwoPath(ControllerHand hand, string suffix)
		{
			switch (GetCurrentControllerType())
			{
			case ControllerType.SteamVR_ViveWand:
			case ControllerType.SteamVR_ValveKnuckles:
			case ControllerType.SteamVR_WindowsMRController:
				return "button" + suffix;
			case ControllerType.SteamVR_OculusTouch:
				return ((hand == ControllerHand.Left) ? "y_button" : "b_button") + suffix;
			default:
				return null;
			}
		}

		protected virtual string GetControllerSystemMenuPath(ControllerHand hand, string suffix)
		{
			switch (GetCurrentControllerType())
			{
			case ControllerType.SteamVR_ViveWand:
			case ControllerType.SteamVR_ValveKnuckles:
				return "sys_button" + suffix;
			case ControllerType.SteamVR_OculusTouch:
				return ((hand == ControllerHand.Left) ? "enter_button" : "home_button") + suffix;
			default:
				return null;
			}
		}

		protected virtual string GetControllerStartMenuPath(ControllerHand hand, string suffix)
		{
			ControllerType currentControllerType = GetCurrentControllerType();
			if (currentControllerType == ControllerType.SteamVR_OculusTouch)
			{
				return ((hand == ControllerHand.Left) ? "enter_button" : "home_button") + suffix;
			}
			return null;
		}

		protected virtual ControllerType MatchControllerTypeByString(string controllerModelNumber)
		{
			switch (controllerModelNumber)
			{
			case "vive controller mv":
			case "vive controller dvt":
				return ControllerType.SteamVR_ViveWand;
			case "knuckles ev1.3":
				return ControllerType.SteamVR_ValveKnuckles;
			case "oculus rift cv1 (right controller)":
			case "oculus rift cv1 (left controller)":
			case "oculus quest (right controller)":
			case "oculus quest (left controller)":
				return ControllerType.SteamVR_OculusTouch;
			case "windowsmr: 0x045e/0x065b/0/2":
				return ControllerType.SteamVR_WindowsMRController;
			default:
				return FuzzyMatchControllerTypeByString(controllerModelNumber);
			}
		}

		protected virtual ControllerType FuzzyMatchControllerTypeByString(string controllerModelNumber)
		{
			if (controllerModelNumber.Contains("knuckles"))
			{
				return ControllerType.SteamVR_ValveKnuckles;
			}
			if (controllerModelNumber.Contains("vive"))
			{
				return ControllerType.SteamVR_ViveWand;
			}
			if (controllerModelNumber.Contains("oculus rift") || controllerModelNumber.Contains("oculus quest"))
			{
				return ControllerType.SteamVR_OculusTouch;
			}
			if (controllerModelNumber.Contains("windowsmr"))
			{
				return ControllerType.SteamVR_WindowsMRController;
			}
			return ControllerType.Undefined;
		}

		protected virtual string GetModelNumber(uint index)
		{
			return ((SteamVR.instance != null) ? SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String, index) : "").ToLower();
		}

		public override void OnAfterSetupLoad(VRTK_SDKSetup setup)
		{
			base.OnAfterSetupLoad(setup);
			isOculusRift = VRTK_DeviceFinder.GetHeadsetType() == SDK_BaseHeadset.HeadsetType.OculusRift;
		}
	}
}
