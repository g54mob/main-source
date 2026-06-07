using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	public abstract class SDK_BaseController : SDK_Base
	{
		public enum ButtonTypes
		{
			ButtonOne = 0,
			ButtonTwo = 1,
			Grip = 2,
			GripHairline = 3,
			StartMenu = 4,
			Trigger = 5,
			TriggerHairline = 6,
			Touchpad = 7,
			TouchpadTwo = 8,
			MiddleFinger = 9,
			RingFinger = 10,
			PinkyFinger = 11
		}

		public enum ButtonPressTypes
		{
			Press = 0,
			PressDown = 1,
			PressUp = 2,
			Touch = 3,
			TouchDown = 4,
			TouchUp = 5
		}

		public enum ControllerElements
		{
			AttachPoint = 0,
			Trigger = 1,
			GripLeft = 2,
			GripRight = 3,
			Touchpad = 4,
			ButtonOne = 5,
			ButtonTwo = 6,
			SystemMenu = 7,
			Body = 8,
			StartMenu = 9,
			TouchpadTwo = 10
		}

		public enum ControllerHand
		{
			None = 0,
			Left = 1,
			Right = 2
		}

		public enum ControllerType
		{
			Undefined = 0,
			Custom = 1,
			Simulator_Hand = 2,
			SteamVR_ViveWand = 3,
			SteamVR_OculusTouch = 4,
			Oculus_OculusTouch = 5,
			Daydream_Controller = 6,
			Ximmerse_Flip = 7,
			SteamVR_ValveKnuckles = 8,
			Oculus_OculusGamepad = 9,
			Oculus_OculusRemote = 10,
			Oculus_GearVRHMD = 11,
			Oculus_GearVRController = 12,
			WindowsMR_MotionController = 13,
			SteamVR_WindowsMRController = 14
		}

		protected Transform defaultSDKLeftControllerModel;

		protected Transform defaultSDKRightControllerModel;

		public event VRTKSDKBaseControllerEventHandler LeftControllerReady;

		public event VRTKSDKBaseControllerEventHandler RightControllerReady;

		public event VRTKSDKBaseControllerEventHandler LeftControllerModelReady;

		public event VRTKSDKBaseControllerEventHandler RightControllerModelReady;

		public virtual void OnControllerReady(ControllerHand hand)
		{
			VRTKSDKBaseControllerEventArgs e = default(VRTKSDKBaseControllerEventArgs);
			e.controllerReference = VRTK_ControllerReference.GetControllerReference(hand);
			switch (hand)
			{
			case ControllerHand.Left:
				if (this.LeftControllerReady != null)
				{
					this.LeftControllerReady(this, e);
				}
				break;
			case ControllerHand.Right:
				if (this.RightControllerReady != null)
				{
					this.RightControllerReady(this, e);
				}
				break;
			}
		}

		public abstract void ProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options);

		public abstract void ProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options);

		public abstract ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null);

		public abstract string GetControllerDefaultColliderPath(ControllerHand hand);

		public abstract string GetControllerElementPath(ControllerElements element, ControllerHand hand, bool fullPath = false);

		public abstract uint GetControllerIndex(GameObject controller);

		public abstract GameObject GetControllerByIndex(uint index, bool actual = false);

		public abstract Transform GetControllerOrigin(VRTK_ControllerReference controllerReference);

		[Obsolete("GenerateControllerPointerOrigin has been deprecated and will be removed in a future version of VRTK.")]
		public abstract Transform GenerateControllerPointerOrigin(GameObject parent);

		public abstract GameObject GetControllerLeftHand(bool actual = false);

		public abstract GameObject GetControllerRightHand(bool actual = false);

		public abstract bool IsControllerLeftHand(GameObject controller);

		public abstract bool IsControllerRightHand(GameObject controller);

		public abstract bool IsControllerLeftHand(GameObject controller, bool actual);

		public abstract bool IsControllerRightHand(GameObject controller, bool actual);

		public abstract bool WaitForControllerModel(ControllerHand hand);

		public abstract GameObject GetControllerModel(GameObject controller);

		public abstract GameObject GetControllerModel(ControllerHand hand);

		public virtual ControllerHand GetControllerModelHand(GameObject controllerModel)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				if (controllerModel == instance.loadedSetup.modelAliasLeftController)
				{
					return ControllerHand.Left;
				}
				if (controllerModel == instance.loadedSetup.modelAliasRightController)
				{
					return ControllerHand.Right;
				}
			}
			return ControllerHand.None;
		}

		public abstract GameObject GetControllerRenderModel(VRTK_ControllerReference controllerReference);

		public abstract void SetControllerRenderModelWheel(GameObject renderModel, bool state);

		public abstract void HapticPulse(VRTK_ControllerReference controllerReference, float strength = 0.5f);

		public abstract bool HapticPulse(VRTK_ControllerReference controllerReference, AudioClip clip);

		public abstract SDK_ControllerHapticModifiers GetHapticModifiers();

		public abstract Vector3 GetVelocity(VRTK_ControllerReference controllerReference);

		public abstract Vector3 GetAngularVelocity(VRTK_ControllerReference controllerReference);

		public abstract bool IsTouchpadStatic(bool isTouched, Vector2 currentAxisValues, Vector2 previousAxisValues, int compareFidelity);

		public abstract Vector2 GetButtonAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference);

		public abstract float GetButtonSenseAxis(ButtonTypes buttonType, VRTK_ControllerReference controllerReference);

		public abstract float GetButtonHairlineDelta(ButtonTypes buttonType, VRTK_ControllerReference controllerReference);

		public abstract bool GetControllerButtonState(ButtonTypes buttonType, ButtonPressTypes pressType, VRTK_ControllerReference controllerReference);

		protected virtual GameObject GetSDKManagerControllerLeftHand(bool actual = false)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				if (!actual)
				{
					return instance.scriptAliasLeftController;
				}
				return instance.loadedSetup.actualLeftController;
			}
			return null;
		}

		protected virtual GameObject GetSDKManagerControllerRightHand(bool actual = false)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				if (!actual)
				{
					return instance.scriptAliasRightController;
				}
				return instance.loadedSetup.actualRightController;
			}
			return null;
		}

		protected virtual bool CheckActualOrScriptAliasControllerIsLeftHand(GameObject controller)
		{
			if (!IsControllerLeftHand(controller, actual: true))
			{
				return IsControllerLeftHand(controller, actual: false);
			}
			return true;
		}

		protected virtual bool CheckActualOrScriptAliasControllerIsRightHand(GameObject controller)
		{
			if (!IsControllerRightHand(controller, actual: true))
			{
				return IsControllerRightHand(controller, actual: false);
			}
			return true;
		}

		protected virtual bool CheckControllerLeftHand(GameObject controller, bool actual)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null && controller != null)
			{
				if (!actual)
				{
					return controller == instance.scriptAliasLeftController;
				}
				return controller == instance.loadedSetup.actualLeftController;
			}
			return false;
		}

		protected virtual bool CheckControllerRightHand(GameObject controller, bool actual)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null && controller != null)
			{
				if (!actual)
				{
					return controller == instance.scriptAliasRightController;
				}
				return controller == instance.loadedSetup.actualRightController;
			}
			return false;
		}

		protected virtual GameObject GetControllerModelFromController(GameObject controller)
		{
			return GetControllerModel(VRTK_DeviceFinder.GetControllerHand(controller));
		}

		protected virtual GameObject GetSDKManagerControllerModelForHand(ControllerHand hand)
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				switch (hand)
				{
				case ControllerHand.Left:
					return instance.loadedSetup.modelAliasLeftController;
				case ControllerHand.Right:
					return instance.loadedSetup.modelAliasRightController;
				}
			}
			return null;
		}

		protected virtual GameObject GetActualController(GameObject controller)
		{
			GameObject result = null;
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null)
			{
				if (IsControllerLeftHand(controller))
				{
					result = instance.loadedSetup.actualLeftController;
				}
				else if (IsControllerRightHand(controller))
				{
					result = instance.loadedSetup.actualRightController;
				}
			}
			return result;
		}

		protected virtual void OnControllerModelReady(ControllerHand hand, VRTK_ControllerReference controllerReference)
		{
			VRTKSDKBaseControllerEventArgs e = default(VRTKSDKBaseControllerEventArgs);
			e.controllerReference = controllerReference;
			switch (hand)
			{
			case ControllerHand.Left:
				if (this.LeftControllerModelReady != null)
				{
					this.LeftControllerModelReady(this, e);
				}
				break;
			case ControllerHand.Right:
				if (this.RightControllerModelReady != null)
				{
					this.RightControllerModelReady(this, e);
				}
				break;
			}
		}

		protected virtual bool ShouldWaitForControllerModel(ControllerHand hand, bool ignoreChildCount)
		{
			switch (hand)
			{
			case ControllerHand.Left:
				return IsDefaultControllerModel(defaultSDKLeftControllerModel, GetControllerModel(ControllerHand.Left), ignoreChildCount);
			case ControllerHand.Right:
				return IsDefaultControllerModel(defaultSDKRightControllerModel, GetControllerModel(ControllerHand.Right), ignoreChildCount);
			default:
				return false;
			}
		}

		protected virtual bool IsDefaultControllerModel(Transform givenDefault, GameObject givenActual, bool ignoreChildCount)
		{
			if (givenDefault != null && givenActual == givenDefault.gameObject && givenActual != null)
			{
				if (!ignoreChildCount)
				{
					return givenActual.transform.childCount == 0;
				}
				return true;
			}
			return false;
		}
	}
}
