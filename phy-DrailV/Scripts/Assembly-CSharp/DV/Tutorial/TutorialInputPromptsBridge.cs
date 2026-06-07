using System;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Localization;
using DV.Utils;
using DV.VRTK_Extensions;
using Rewired;
using UnityEngine;
using VRTK;

namespace DV.Tutorial
{
	public static class TutorialInputPromptsBridge
	{
		public enum Semantics
		{
			Turn = 0,
			Move = 1,
			Teleport = 2,
			Use = 3,
			Grab = 4,
			Drop = 5,
			Scroll = 6,
			Jump = 7,
			Crouch = 8,
			InventoryOpen = 9
		}

		private const string K_Mouse = "keycode/meta/mouse";

		private const string K_MouseWheel = "keycode/meta/mouse_wheel";

		private const string K_VR_Trigger = "vr/meta/trigger";

		private const string K_VR_Grip = "vr/meta/grip";

		private const string K_VR_Hold_Trigger = "vr/meta/hold_trigger";

		private const string K_VR_Hold_Grip = "vr/meta/hold_grip";

		private const string K_VR_Release_Trigger = "vr/meta/release_trigger";

		private const string K_VR_Release_Grip = "vr/meta/release_grip";

		private const string K_VR_Joystick = "vr/meta/joystick";

		private const string K_VR_L_Joystick = "vr/meta/left_joystick";

		private const string K_VR_R_Joystick = "vr/meta/right_joystick";

		private const string K_VR_Joystick_Move_Full = "vr/meta/joystick_move_full";

		private const string K_VR_Joystick_Move_LeftRight = "vr/meta/joystick_move_leftright";

		private const string K_VR_Joystick_Flick_LeftRight = "vr/meta/joystick_flick_leftright";

		private const string K_VR_Joystick_Up = "vr/meta/joystick_up";

		private const string K_VR_Joystick_Down = "vr/meta/joystick_down";

		private const string K_VR_Joystick_Left = "vr/meta/joystick_left";

		private const string K_VR_Joystick_Right = "vr/meta/joystick_right";

		private const string K_VR_L_Joystick_Up = "vr/meta/left_joystick_up";

		private const string K_VR_L_Joystick_Down = "vr/meta/left_joystick_down";

		private const string K_VR_L_Joystick_Left = "vr/meta/left_joystick_left";

		private const string K_VR_L_Joystick_Right = "vr/meta/left_joystick_right";

		private const string K_VR_R_Joystick_Up = "vr/meta/right_joystick_up";

		private const string K_VR_R_Joystick_Down = "vr/meta/right_joystick_down";

		private const string K_VR_R_Joystick_Left = "vr/meta/right_joystick_left";

		private const string K_VR_R_Joystick_Right = "vr/meta/right_joystick_right";

		private const string K_VR_L_Joystick_Move_Full = "vr/meta/left_joystick_move_full";

		private const string K_VR_L_Joystick_Move_LeftRight = "vr/meta/left_joystick_move_leftright";

		private const string K_VR_L_Joystick_Flick_LeftRight = "vr/meta/left_joystick_flick_leftright";

		private const string K_VR_R_Joystick_Move_Full = "vr/meta/right_joystick_move_full";

		private const string K_VR_R_Joystick_Move_LeftRight = "vr/meta/right_joystick_move_leftright";

		private const string K_VR_R_Joystick_Flick_LeftRight = "vr/meta/right_joystick_flick_leftright";

		private const string K_VR_Joystick_Flick_Up = "vr/meta/joystick_flick_up";

		private const string K_VR_Joystick_Flick_Down = "vr/meta/joystick_flick_down";

		private const string K_VR_L_Joystick_Flick_Up = "vr/meta/left_joystick_flick_up";

		private const string K_VR_L_Joystick_Flick_Down = "vr/meta/left_joystick_flick_down";

		private const string K_VR_R_Joystick_Flick_Up = "vr/meta/right_joystick_flick_up";

		private const string K_VR_R_Joystick_Flick_Down = "vr/meta/right_joystick_flick_down";

		private const string K_VR_Touchpad = "vr/meta/touchpad";

		private const string K_VR_LTouchpad = "vr/meta/left_touchpad";

		private const string K_VR_RTouchpad = "vr/meta/right_touchpad";

		private const string K_VR_Touchpad_Move_Full = "vr/meta/touchpad_move_full";

		private const string K_VR_Touchpad_Move_LeftRight = "vr/meta/touchpad_move_leftright";

		private const string K_VR_Touchpad_Swipe_LeftRight = "vr/meta/touchpad_swipe_leftright";

		private const string K_VR_Touchpad_Click_LeftRight = "vr/meta/touchpad_click_leftright";

		private const string K_VR_L_Touchpad_Move_Full = "vr/meta/left_touchpad_move_full";

		private const string K_VR_L_Touchpad_Move_LeftRight = "vr/meta/left_touchpad_move_leftright";

		private const string K_VR_L_Touchpad_Swipe_LeftRight = "vr/meta/left_touchpad_swipe_leftright";

		private const string K_VR_L_Touchpad_Click_LeftRight = "vr/meta/left_touchpad_click_leftright";

		private const string K_VR_R_Touchpad_Move_Full = "vr/meta/right_touchpad_move_full";

		private const string K_VR_R_Touchpad_Move_LeftRight = "vr/meta/right_touchpad_move_leftright";

		private const string K_VR_R_Touchpad_Swipe_LeftRight = "vr/meta/right_touchpad_swipe_leftright";

		private const string K_VR_R_Touchpad_Click_LeftRight = "vr/meta/right_touchpad_click_leftright";

		private const string K_VR_Touchpad_Click_Up = "vr/meta/touchpad_click_up";

		private const string K_VR_Touchpad_Click_Down = "vr/meta/touchpad_click_down";

		private const string K_VR_Touchpad_Swipe_Up = "vr/meta/touchpad_swipe_up";

		private const string K_VR_Touchpad_Swipe_Down = "vr/meta/touchpad_swipe_down";

		private const string K_VR_L_Touchpad_Click_Up = "vr/meta/left_touchpad_click_up";

		private const string K_VR_L_Touchpad_Click_Down = "vr/meta/left_touchpad_click_down";

		private const string K_VR_L_Touchpad_Swipe_Up = "vr/meta/left_touchpad_swipe_up";

		private const string K_VR_L_Touchpad_Swipe_Down = "vr/meta/left_touchpad_swipe_down";

		private const string K_VR_R_Touchpad_Click_Up = "vr/meta/right_touchpad_click_up";

		private const string K_VR_R_Touchpad_Click_Down = "vr/meta/right_touchpad_click_down";

		private const string K_VR_R_Touchpad_Swipe_Up = "vr/meta/right_touchpad_swipe_up";

		private const string K_VR_R_Touchpad_Swipe_Down = "vr/meta/right_touchpad_swipe_down";

		private const string K_VR_Touchpad_Up = "vr/meta/touchpad_up";

		private const string K_VR_Touchpad_Down = "vr/meta/touchpad_down";

		private const string K_VR_Touchpad_Left = "vr/meta/touchpad_left";

		private const string K_VR_Touchpad_Right = "vr/meta/touchpad_right";

		private const string K_VR_L_Touchpad_Up = "vr/meta/left_touchpad_up";

		private const string K_VR_L_Touchpad_Down = "vr/meta/left_touchpad_down";

		private const string K_VR_L_Touchpad_Left = "vr/meta/left_touchpad_left";

		private const string K_VR_L_Touchpad_Right = "vr/meta/left_touchpad_right";

		private const string K_VR_R_Touchpad_Up = "vr/meta/right_touchpad_up";

		private const string K_VR_R_Touchpad_Down = "vr/meta/right_touchpad_down";

		private const string K_VR_R_Touchpad_Left = "vr/meta/right_touchpad_left";

		private const string K_VR_R_Touchpad_Right = "vr/meta/right_touchpad_right";

		private const string K_VR_AliasPrefix = "vr/meta/alias/";

		public static string GetLocalizedForSemantic(string semantic)
		{
			if (Enum.TryParse<Semantics>(semantic, ignoreCase: true, out var result))
			{
				return GetLocalizedForSemantic(result);
			}
			Debug.LogError("Can't parse input semantic '" + semantic + "'");
			return "!!!";
		}

		public static string LocalizeButtonAlias(VRTK_ControllerEvents.ButtonAlias alias)
		{
			if (alias == VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress && VRManager.AnyWandController())
			{
				return LocalizationAPI.L("vr/meta/alias/menu");
			}
			return LocalizationAPI.L("vr/meta/alias/" + alias.ToString().ToLower());
		}

		public static string GetLocalizedForSemantic(Semantics semantic)
		{
			if (!VRManager.IsVREnabled())
			{
				switch (semantic)
				{
				case Semantics.Turn:
					return LocalizationAPI.L("keycode/meta/mouse");
				case Semantics.Move:
					return string.Join(" ", DV.Interaction.Inputs.InputManager.Actions.MoveVertical.LocalizeInput(AxisRange.Positive), DV.Interaction.Inputs.InputManager.Actions.MoveHorizontal.LocalizeInput(AxisRange.Negative), DV.Interaction.Inputs.InputManager.Actions.MoveVertical.LocalizeInput(AxisRange.Negative), DV.Interaction.Inputs.InputManager.Actions.MoveHorizontal.LocalizeInput(AxisRange.Positive));
				case Semantics.Teleport:
					return DV.Interaction.Inputs.InputManager.Actions.Teleport.LocalizeInput();
				case Semantics.Use:
					return DV.Interaction.Inputs.InputManager.Actions.InteractionPrimary.LocalizeInput();
				case Semantics.Grab:
					return DV.Interaction.Inputs.InputManager.Actions.InteractionPrimary.LocalizeInput();
				case Semantics.Drop:
					return DV.Interaction.Inputs.InputManager.Actions.Drop.LocalizeInput();
				case Semantics.Scroll:
					return LocalizationAPI.L("keycode/meta/mouse_wheel");
				case Semantics.Jump:
					return DV.Interaction.Inputs.InputManager.Actions.Jump.LocalizeInput();
				case Semantics.Crouch:
					return DV.Interaction.Inputs.InputManager.Actions.Crouch.LocalizeInput();
				case Semantics.InventoryOpen:
					return DV.Interaction.Inputs.InputManager.Actions.InventoryOpen.LocalizeInput();
				default:
					Debug.LogError(string.Format("Semantic {0} unresolved in {1}, something is missing in code.", semantic, "GetLocalizedForSemantic"));
					return "!!!";
				}
			}
			GameObject[] array = new GameObject[2]
			{
				VRTK_DeviceFinder.GetControllerLeftHand(getActual: true),
				VRTK_DeviceFinder.GetControllerRightHand(getActual: true)
			};
			TouchpadInputInterpreter[] array2 = new TouchpadInputInterpreter[2]
			{
				array[0] ? array[0].GetComponentInChildren<TouchpadInputInterpreter>(includeInactive: true) : null,
				array[1] ? array[1].GetComponentInChildren<TouchpadInputInterpreter>(includeInactive: true) : null
			};
			VRTK_ControllerReference[] array3 = new VRTK_ControllerReference[2]
			{
				array[0] ? VRTK_ControllerReference.GetControllerReference(array[0]) : null,
				array[1] ? VRTK_ControllerReference.GetControllerReference(array[1]) : null
			};
			string[] array4 = new string[2]
			{
				string.Empty,
				string.Empty
			};
			for (int i = 0; i < 2; i++)
			{
				if (array[i] == null || array2[i] == null || array3[i] == null || !array3[i].IsValid())
				{
					continue;
				}
				switch (semantic)
				{
				case Semantics.Turn:
				{
					RotatePlayer instance = SingletonBehaviour<RotatePlayer>.Instance;
					bool flag3 = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
					if (instance == null)
					{
						Debug.LogError("RotatePlayer is not present on VRManager, this is unexpected, cannot determine rotation controls.");
					}
					else if (instance.RotationMode == RotationModeValue.Off)
					{
						Debug.LogWarning($"There probably shouldn't be a point in the tutorial where turning is being explained and it's set to {RotationModeValue.Off}.");
					}
					else if (instance.RotationMode == RotationModeValue.Snap)
					{
						if (!flag3 || i == 1)
						{
							if ((bool)array2[i] && array2[i].IsTouchpad)
							{
								array4[i] = (flag3 ? LocalizationAPI.L("vr/meta/right_touchpad_click_leftright") : LocalizationAPI.L("vr/meta/touchpad_click_leftright"));
							}
							else
							{
								array4[i] = (flag3 ? LocalizationAPI.L("vr/meta/right_joystick_flick_leftright") : LocalizationAPI.L("vr/meta/joystick_flick_leftright"));
							}
						}
					}
					else if (instance.RotationMode == RotationModeValue.Smooth)
					{
						if (!flag3 || i == 1)
						{
							if ((bool)array2[i] && array2[i].IsTouchpad)
							{
								array4[i] = (flag3 ? LocalizationAPI.L("vr/meta/right_touchpad_click_leftright") : LocalizationAPI.L("vr/meta/touchpad_click_leftright"));
							}
							else
							{
								array4[i] = (flag3 ? LocalizationAPI.L("vr/meta/right_joystick_move_leftright") : LocalizationAPI.L("vr/meta/joystick_move_leftright"));
							}
						}
					}
					else
					{
						Debug.LogError(string.Format("Rotation mode not implemented in {0}: {1}", "TutorialInputPromptsBridge", instance.RotationMode));
					}
					break;
				}
				case Semantics.Move:
					if (i != 0)
					{
						break;
					}
					if (GamePreferences.Get<bool>(Preferences.SmoothLocomotion))
					{
						if ((bool)array2[i] && array2[i].IsTouchpad)
						{
							array4[i] = LocalizationAPI.L("vr/meta/left_touchpad_move_full");
						}
						else
						{
							array4[i] = LocalizationAPI.L("vr/meta/left_joystick_move_full");
						}
					}
					else
					{
						Debug.LogWarning("There probably shouldn't be a point in the tutorial where moving is being explained and smooth locomotion if off.");
					}
					break;
				case Semantics.Teleport:
				{
					TeleportInputVR teleportInputVR = (array[i] ? array[i].GetComponentInChildren<TeleportInputVR>() : null);
					if (teleportInputVR != null)
					{
						array4[i] = LocalizeButtonAlias(teleportInputVR.TeleportButton);
					}
					break;
				}
				case Semantics.Use:
					if (array3[i].hand == (SDK_BaseController.ControllerHand)(i + 1))
					{
						ControllerType_DV controllerTypeDV4 = array3[i].GetControllerTypeDV();
						if ((bool)array[i].GetComponentInChildren<VRTK_InteractUse_DV>())
						{
							array4[i] = LocalizeButtonAlias(SetupDeviceSpecificControls.useButtonDictionary[controllerTypeDV4]);
						}
						else
						{
							Debug.LogError(string.Format("{0} not present on controller #{1}, this is unexpected, cannot determine {2} key.", "VRTK_InteractUse_DV", i, Semantics.Use));
						}
					}
					break;
				case Semantics.Grab:
				{
					GrabMethodValues grabMethodValues2 = (GrabMethodValues)GamePreferences.Get<int>(Preferences.ItemHoldType);
					if (array3[i] == null || array3[i].hand != (SDK_BaseController.ControllerHand)(i + 1))
					{
						break;
					}
					ControllerType_DV controllerTypeDV3 = array3[i].GetControllerTypeDV();
					VRTK_ControllerEvents.ButtonAlias buttonAlias2 = SetupDeviceSpecificControls.grabButtonDictionary[controllerTypeDV3];
					switch (grabMethodValues2)
					{
					case GrabMethodValues.Hold:
						switch (buttonAlias2)
						{
						case VRTK_ControllerEvents.ButtonAlias.TriggerPress:
							array4[i] = LocalizationAPI.L("vr/meta/hold_trigger");
							break;
						case VRTK_ControllerEvents.ButtonAlias.GripPress:
							array4[i] = LocalizationAPI.L("vr/meta/hold_grip");
							break;
						default:
							array4[i] = LocalizeButtonAlias(buttonAlias2);
							break;
						}
						break;
					case GrabMethodValues.ClickHold:
						switch (buttonAlias2)
						{
						case VRTK_ControllerEvents.ButtonAlias.TriggerPress:
							array4[i] = LocalizationAPI.L("vr/meta/trigger");
							break;
						case VRTK_ControllerEvents.ButtonAlias.GripPress:
							array4[i] = LocalizationAPI.L("vr/meta/grip");
							break;
						default:
							array4[i] = LocalizeButtonAlias(buttonAlias2);
							break;
						}
						break;
					default:
						array4[i] = LocalizeButtonAlias(buttonAlias2);
						break;
					}
					break;
				}
				case Semantics.Drop:
				{
					GrabMethodValues grabMethodValues = (GrabMethodValues)GamePreferences.Get<int>(Preferences.ItemHoldType);
					if (array3[i] == null || array3[i].hand != (SDK_BaseController.ControllerHand)(i + 1))
					{
						break;
					}
					VRTK_ControllerReference controllerReference = array3[i];
					ControllerType_DV controllerTypeDV = controllerReference.GetControllerTypeDV();
					VRTK_ControllerEvents.ButtonAlias buttonAlias = SetupDeviceSpecificControls.grabButtonDictionary[controllerTypeDV];
					if (controllerReference.IsWandOrUndefined())
					{
						array4[i] = LocalizeButtonAlias(SetupDeviceSpecificControls.useButtonDictionary[controllerTypeDV]) + " + " + LocalizationAPI.L("vr/meta/grip");
						break;
					}
					switch (grabMethodValues)
					{
					case GrabMethodValues.Hold:
						switch (buttonAlias)
						{
						case VRTK_ControllerEvents.ButtonAlias.TriggerPress:
							array4[i] = LocalizationAPI.L("vr/meta/release_trigger");
							break;
						case VRTK_ControllerEvents.ButtonAlias.GripPress:
							array4[i] = LocalizationAPI.L("vr/meta/release_grip");
							break;
						default:
							array4[i] = LocalizeButtonAlias(buttonAlias);
							break;
						}
						break;
					case GrabMethodValues.ClickHold:
						switch (buttonAlias)
						{
						case VRTK_ControllerEvents.ButtonAlias.TriggerPress:
							array4[i] = LocalizationAPI.L("vr/meta/trigger");
							break;
						case VRTK_ControllerEvents.ButtonAlias.GripPress:
							array4[i] = LocalizationAPI.L("vr/meta/grip");
							break;
						default:
							array4[i] = LocalizeButtonAlias(buttonAlias);
							break;
						}
						break;
					default:
						array4[i] = LocalizeButtonAlias(buttonAlias);
						break;
					}
					break;
				}
				case Semantics.Scroll:
				{
					TouchpadInputInterpreter touchpadInputInterpreter = array2[i];
					string text = ((touchpadInputInterpreter != null && touchpadInputInterpreter.IsTouchpad) ? LocalizationAPI.L("vr/meta/touchpad_click_leftright") : LocalizationAPI.L("vr/meta/joystick_flick_leftright"));
					ControllerType_DV controllerTypeDV2 = array3[i].GetControllerTypeDV();
					string text2 = LocalizeButtonAlias(SetupDeviceSpecificControls.useButtonDictionary[controllerTypeDV2]);
					array4[i] = text2 + " + " + text;
					break;
				}
				case Semantics.Jump:
				{
					LocomotionInputWrapper locomotionInputWrapper = (PlayerManager.PlayerTransform ? PlayerManager.PlayerTransform.GetComponentInChildren<LocomotionInputWrapper>() : null);
					LocomotionInputVr locomotionInputVr = (locomotionInputWrapper ? (locomotionInputWrapper.LocomotionInputInterpreter as LocomotionInputVr) : null);
					bool flag = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
					if (locomotionInputVr != null)
					{
						if (flag && i != 1)
						{
							break;
						}
						if ((bool)array2[i] && array2[i].IsTouchpad)
						{
							if (locomotionInputVr.CrouchButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
							{
								array4[i] = (flag ? LocalizationAPI.L("vr/meta/right_touchpad_swipe_down") : LocalizationAPI.L("vr/meta/touchpad_swipe_down"));
							}
							else if (locomotionInputVr.CrouchButton == VRTK_ControllerEvents.ButtonAlias.TouchpadPress)
							{
								array4[i] = (flag ? LocalizationAPI.L("vr/meta/right_touchpad_click_down") : LocalizationAPI.L("vr/meta/touchpad_click_down"));
							}
							else
							{
								array4[i] = LocalizeButtonAlias(locomotionInputVr.CrouchButton) + " + " + (flag ? LocalizationAPI.L("vr/meta/right_touchpad_swipe_down") : LocalizationAPI.L("vr/meta/touchpad_swipe_down"));
							}
						}
						else if (locomotionInputVr.CrouchButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
						{
							array4[i] = (flag ? LocalizationAPI.L("vr/meta/right_joystick_flick_down") : LocalizationAPI.L("vr/meta/joystick_flick_down"));
						}
						else
						{
							array4[i] = LocalizeButtonAlias(locomotionInputVr.CrouchButton) + " + " + (flag ? LocalizationAPI.L("vr/meta/right_joystick_flick_down") : LocalizationAPI.L("vr/meta/joystick_flick_down"));
						}
					}
					else if (flag)
					{
						Debug.LogError(string.Format("{0} not present on player's transform with smooth locomotion enabled, this is unexpected, cannot determine {1} key.", "LocomotionInputVr", Semantics.Jump));
					}
					break;
				}
				case Semantics.Crouch:
				{
					LocomotionInputWrapper locomotionInputWrapper2 = (PlayerManager.PlayerTransform ? PlayerManager.PlayerTransform.GetComponentInChildren<LocomotionInputWrapper>() : null);
					LocomotionInputVr locomotionInputVr2 = (locomotionInputWrapper2 ? (locomotionInputWrapper2.LocomotionInputInterpreter as LocomotionInputVr) : null);
					bool flag2 = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
					if (flag2 && i != 1)
					{
						break;
					}
					if (locomotionInputVr2 != null && (bool)array2[i] && array2[i].IsTouchpad)
					{
						if (locomotionInputVr2.CrouchButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
						{
							array4[i] = (flag2 ? LocalizationAPI.L("vr/meta/right_touchpad_down") : LocalizationAPI.L("vr/meta/touchpad_down"));
						}
						else if (locomotionInputVr2.CrouchButton == VRTK_ControllerEvents.ButtonAlias.TouchpadPress)
						{
							array4[i] = (flag2 ? LocalizationAPI.L("vr/meta/right_touchpad_click_down") : LocalizationAPI.L("vr/meta/touchpad_click_down"));
						}
						else
						{
							array4[i] = LocalizeButtonAlias(locomotionInputVr2.CrouchButton) + " + " + (flag2 ? LocalizationAPI.L("vr/meta/right_touchpad_swipe_down") : LocalizationAPI.L("vr/meta/touchpad_swipe_down"));
						}
					}
					else if (locomotionInputVr2 == null || locomotionInputVr2.CrouchButton == VRTK_ControllerEvents.ButtonAlias.Undefined)
					{
						array4[i] = (flag2 ? LocalizationAPI.L("vr/meta/right_joystick_down") : LocalizationAPI.L("vr/meta/joystick_down"));
					}
					else
					{
						array4[i] = LocalizeButtonAlias(locomotionInputVr2.CrouchButton);
					}
					break;
				}
				case Semantics.InventoryOpen:
					if (SingletonBehaviour<InventoryViewBase>.Instance is InventoryViewVR inventoryViewVR)
					{
						array4[i] = LocalizeButtonAlias(inventoryViewVR.Input.InventoryButton);
						break;
					}
					Debug.LogWarning("In VR mode, but InventoryViewBase is not InventoryViewVR, stuff is broken or outdated.");
					array4[i] = LocalizeButtonAlias(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress);
					break;
				default:
					Debug.LogError(string.Format("Semantic {0} unresolved in {1}, something is missing in code.", semantic, "GetLocalizedForSemantic"));
					return "!!!";
				}
			}
			if (string.IsNullOrEmpty(array4[0]) && string.IsNullOrEmpty(array4[1]))
			{
				Debug.LogWarning($"No input control strings were resolved on either controllers for semantic {semantic}.");
				return "N/A";
			}
			if (!string.IsNullOrEmpty(array4[0]) && string.IsNullOrEmpty(array4[1]))
			{
				return array4[0];
			}
			if (string.IsNullOrEmpty(array4[0]) && !string.IsNullOrEmpty(array4[1]))
			{
				return array4[1];
			}
			if (array4[0] == array4[1])
			{
				return array4[0];
			}
			return array4[0] + " | " + array4[1];
		}
	}
}
