using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_SimSystem), 0)]
	public class SDK_SimController : SDK_BaseController
	{
		protected SDK_ControllerSim rightController;

		protected SDK_ControllerSim leftController;

		protected Dictionary<string, KeyCode> keyMappings = new Dictionary<string, KeyCode>
		{
			{
				"Trigger",
				KeyCode.Mouse1
			},
			{
				"Grip",
				KeyCode.Mouse0
			},
			{
				"TouchpadPress",
				KeyCode.Q
			},
			{
				"ButtonOne",
				KeyCode.E
			},
			{
				"ButtonTwo",
				KeyCode.R
			},
			{
				"StartMenu",
				KeyCode.F
			},
			{
				"TouchModifier",
				KeyCode.T
			},
			{
				"HairTouchModifier",
				KeyCode.H
			}
		};

		protected const string RIGHT_HAND_CONTROLLER_NAME = "RightHand";

		protected const string LEFT_HAND_CONTROLLER_NAME = "LeftHand";

		public virtual void SetKeyMappings(Dictionary<string, KeyCode> givenKeyMappings)
		{
			keyMappings = givenKeyMappings;
		}

		public override void ProcessUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(VRTK_ControllerReference controllerReference, Dictionary<string, object> options)
		{
		}

		public override ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null)
		{
			return ControllerType.Simulator_Hand;
		}

		public override string GetControllerDefaultColliderPath(ControllerHand hand)
		{
			return "ControllerColliders/Simulator";
		}

		public override string GetControllerElementPath(ControllerElements element, ControllerHand hand, bool fullPath = false)
		{
			string text = (fullPath ? "/attach" : "");
			switch (element)
			{
			case ControllerElements.AttachPoint:
				return "";
			case ControllerElements.Trigger:
				return text ?? "";
			case ControllerElements.GripLeft:
				return text ?? "";
			case ControllerElements.GripRight:
				return text ?? "";
			case ControllerElements.Touchpad:
				return text ?? "";
			case ControllerElements.ButtonOne:
				return text ?? "";
			case ControllerElements.SystemMenu:
				return text ?? "";
			case ControllerElements.Body:
				return "";
			default:
				return "";
			}
		}

		public override uint GetControllerIndex(GameObject controller)
		{
			if (CheckActualOrScriptAliasControllerIsRightHand(controller))
			{
				return 1u;
			}
			if (CheckActualOrScriptAliasControllerIsLeftHand(controller))
			{
				return 2u;
			}
			return uint.MaxValue;
		}

		public override GameObject GetControllerByIndex(uint index, bool actual = false)
		{
			SetupPlayer();
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			switch (index)
			{
			case 1u:
				if (!(instance != null) || actual)
				{
					if (!(rightController != null))
					{
						return null;
					}
					return rightController.gameObject;
				}
				return instance.scriptAliasRightController;
			case 2u:
				if (!(instance != null) || actual)
				{
					if (!(leftController != null))
					{
						return null;
					}
					return leftController.gameObject;
				}
				return instance.scriptAliasLeftController;
			default:
				return null;
			}
		}

		public override Transform GetControllerOrigin(VRTK_ControllerReference controllerReference)
		{
			if (controllerReference == null || !(controllerReference.actual != null))
			{
				return null;
			}
			return controllerReference.actual.transform;
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
				gameObject = GetActualController(ControllerHand.Left);
			}
			return gameObject;
		}

		public override GameObject GetControllerRightHand(bool actual = false)
		{
			GameObject gameObject = GetSDKManagerControllerRightHand(actual);
			if (gameObject == null && actual)
			{
				gameObject = GetActualController(ControllerHand.Right);
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
			GameObject result = null;
			GameObject gameObject = SDK_InputSimulator.FindInScene();
			if (gameObject != null)
			{
				switch (hand)
				{
				case ControllerHand.Left:
					result = gameObject.transform.Find(string.Format("{0}/Hand", "LeftHand")).gameObject;
					break;
				case ControllerHand.Right:
					result = gameObject.transform.Find(string.Format("{0}/Hand", "RightHand")).gameObject;
					break;
				}
			}
			return result;
		}

		public override GameObject GetControllerRenderModel(VRTK_ControllerReference controllerReference)
		{
			return controllerReference.scriptAlias.transform.parent.Find("Hand").gameObject;
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
			SetupPlayer();
			switch (VRTK_ControllerReference.GetRealIndex(controllerReference))
			{
			case 1u:
				if (!(rightController != null))
				{
					return Vector3.zero;
				}
				return rightController.GetVelocity();
			case 2u:
				if (!(leftController != null))
				{
					return Vector3.zero;
				}
				return leftController.GetVelocity();
			default:
				return Vector3.zero;
			}
		}

		public override Vector3 GetAngularVelocity(VRTK_ControllerReference controllerReference)
		{
			SetupPlayer();
			switch (VRTK_ControllerReference.GetRealIndex(controllerReference))
			{
			case 1u:
				if (!(rightController != null))
				{
					return Vector3.zero;
				}
				return rightController.GetAngularVelocity();
			case 2u:
				if (!(leftController != null))
				{
					return Vector3.zero;
				}
				return leftController.GetAngularVelocity();
			default:
				return Vector3.zero;
			}
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
			return Vector2.zero;
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
			uint realIndex = VRTK_ControllerReference.GetRealIndex(controllerReference);
			switch (buttonType)
			{
			case ButtonTypes.Trigger:
			case ButtonTypes.TriggerHairline:
				return GetControllerButtonState(realIndex, "Trigger", pressType);
			case ButtonTypes.Grip:
			case ButtonTypes.GripHairline:
				return GetControllerButtonState(realIndex, "Grip", pressType);
			case ButtonTypes.Touchpad:
				return GetControllerButtonState(realIndex, "TouchpadPress", pressType);
			case ButtonTypes.ButtonOne:
				return GetControllerButtonState(realIndex, "ButtonOne", pressType);
			case ButtonTypes.ButtonTwo:
				return GetControllerButtonState(realIndex, "ButtonTwo", pressType);
			case ButtonTypes.StartMenu:
				return GetControllerButtonState(realIndex, "StartMenu", pressType);
			default:
				return false;
			}
		}

		protected virtual void OnEnable()
		{
			SetupPlayer();
		}

		protected virtual void SetupPlayer()
		{
			if (rightController == null || leftController == null)
			{
				GameObject gameObject = SDK_InputSimulator.FindInScene();
				if (gameObject != null)
				{
					rightController = ((rightController == null) ? gameObject.transform.Find("RightHand").GetComponent<SDK_ControllerSim>() : rightController);
					leftController = ((leftController == null) ? gameObject.transform.Find("LeftHand").GetComponent<SDK_ControllerSim>() : leftController);
				}
			}
		}

		protected virtual bool IsTouchModifierPressed()
		{
			return Input.GetKey(VRTK_SharedMethods.GetDictionaryValue(keyMappings, "TouchModifier", KeyCode.None));
		}

		protected virtual bool IsHairTouchModifierPressed()
		{
			return Input.GetKey(VRTK_SharedMethods.GetDictionaryValue(keyMappings, "HairTouchModifier", KeyCode.None));
		}

		protected virtual bool IsButtonPressIgnored()
		{
			if (!IsHairTouchModifierPressed())
			{
				return IsTouchModifierPressed();
			}
			return true;
		}

		protected virtual bool IsButtonHairTouchIgnored()
		{
			if (IsTouchModifierPressed())
			{
				return !IsHairTouchModifierPressed();
			}
			return false;
		}

		protected virtual bool GetControllerButtonState(uint index, string keyMapping, ButtonPressTypes pressType)
		{
			KeyCode dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(keyMappings, keyMapping, KeyCode.None);
			switch (pressType)
			{
			case ButtonPressTypes.Touch:
				return IsButtonPressed(index, ButtonPressTypes.Press, dictionaryValue);
			case ButtonPressTypes.TouchDown:
				return IsButtonPressed(index, ButtonPressTypes.PressDown, dictionaryValue);
			case ButtonPressTypes.TouchUp:
				return IsButtonPressed(index, ButtonPressTypes.PressUp, dictionaryValue);
			case ButtonPressTypes.Press:
				if (!IsButtonPressIgnored())
				{
					return IsButtonPressed(index, ButtonPressTypes.Press, dictionaryValue);
				}
				return false;
			case ButtonPressTypes.PressDown:
				if (!IsButtonPressIgnored())
				{
					return IsButtonPressed(index, ButtonPressTypes.PressDown, dictionaryValue);
				}
				return false;
			case ButtonPressTypes.PressUp:
				if (!IsButtonPressIgnored())
				{
					return IsButtonPressed(index, ButtonPressTypes.PressUp, dictionaryValue);
				}
				return false;
			default:
				return false;
			}
		}

		protected virtual bool IsButtonPressed(uint index, ButtonPressTypes type, KeyCode button)
		{
			SetupPlayer();
			switch (index)
			{
			case uint.MaxValue:
				return false;
			case 1u:
				if (rightController == null || !rightController.selected)
				{
					return false;
				}
				break;
			case 2u:
				if (leftController == null || !leftController.selected)
				{
					return false;
				}
				break;
			default:
				return false;
			}
			switch (type)
			{
			case ButtonPressTypes.Press:
				return Input.GetKey(button);
			case ButtonPressTypes.PressDown:
				return Input.GetKeyDown(button);
			case ButtonPressTypes.PressUp:
				return Input.GetKeyUp(button);
			default:
				return false;
			}
		}

		protected virtual GameObject GetActualController(ControllerHand hand)
		{
			GameObject gameObject = SDK_InputSimulator.FindInScene();
			GameObject result = null;
			if (gameObject != null)
			{
				switch (hand)
				{
				case ControllerHand.Right:
					result = gameObject.transform.Find("RightHand").gameObject;
					break;
				case ControllerHand.Left:
					result = gameObject.transform.Find("LeftHand").gameObject;
					break;
				}
			}
			return result;
		}
	}
}
