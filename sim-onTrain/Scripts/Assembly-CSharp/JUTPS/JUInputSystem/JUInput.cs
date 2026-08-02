using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;

namespace JUTPS.JUInputSystem
{
	public class JUInput
	{
		public enum Axis
		{
			MoveHorizontal = 0,
			MoveVertical = 1,
			RotateHorizontal = 2,
			RotateVertical = 3
		}

		public enum Buttons
		{
			ShotButton = 0,
			AimingButton = 1,
			JumpButton = 2,
			RunButton = 3,
			PunchButton = 4,
			RollButton = 5,
			CrouchButton = 6,
			ProneButton = 7,
			ReloadButton = 8,
			PickupButton = 9,
			EnterVehicleButton = 10,
			PreviousWeaponButton = 11,
			NextWeaponButton = 12,
			OpenInventory = 13
		}

		private static JUInputManager JUInputInstance;

		private static void GetJUInputInstance()
		{
			if (!(JUInputInstance != null))
			{
				if (Object.FindObjectOfType<JUInputManager>() != null)
				{
					JUInputInstance = Object.FindObjectOfType<JUInputManager>();
					return;
				}
				JUInputInstance = new GameObject("JU Input Manager").AddComponent<JUInputManager>();
				Debug.Log("New JU Input Manager was created because none were found on the scene");
			}
		}

		public static JUInputManager Instance()
		{
			if (JUInputInstance != null)
			{
				return JUInputInstance;
			}
			GetJUInputInstance();
			JUInputInstance = Object.FindObjectOfType<JUInputManager>();
			return JUInputInstance;
		}

		public static float GetAxis(Axis axis)
		{
			GetJUInputInstance();
			return axis switch
			{
				Axis.MoveHorizontal => JUInputInstance.MoveHorizontal, 
				Axis.MoveVertical => JUInputInstance.MoveVertical, 
				Axis.RotateHorizontal => JUInputInstance.RotateHorizontal, 
				Axis.RotateVertical => JUInputInstance.RotateVertical, 
				_ => 0f, 
			};
		}

		public static bool GetButtonDown(Buttons Button)
		{
			GetJUInputInstance();
			return Button switch
			{
				Buttons.ShotButton => JUInputInstance.PressedShootingDown, 
				Buttons.AimingButton => JUInputInstance.PressedAimingDown, 
				Buttons.JumpButton => JUInputInstance.PressedJumpDown, 
				Buttons.RunButton => JUInputInstance.PressedRunDown, 
				Buttons.PunchButton => JUInputInstance.PressedPunchDown, 
				Buttons.RollButton => JUInputInstance.PressedRollDown, 
				Buttons.CrouchButton => JUInputInstance.PressedCrouchDown, 
				Buttons.ProneButton => JUInputInstance.PressedProneDown, 
				Buttons.ReloadButton => JUInputInstance.PressedReloadDown, 
				Buttons.PickupButton => JUInputInstance.PressedPickupDown, 
				Buttons.EnterVehicleButton => JUInputInstance.PressedInteractDown, 
				Buttons.PreviousWeaponButton => JUInputInstance.PressedPreviousItemDown, 
				Buttons.NextWeaponButton => JUInputInstance.PressedNextItemDown, 
				Buttons.OpenInventory => JUInputInstance.PressedOpenInventoryDown, 
				_ => false, 
			};
		}

		public static bool GetButton(Buttons Button)
		{
			GetJUInputInstance();
			return Button switch
			{
				Buttons.ShotButton => JUInputInstance.PressedShooting, 
				Buttons.AimingButton => JUInputInstance.PressedAiming, 
				Buttons.JumpButton => JUInputInstance.PressedJump, 
				Buttons.RunButton => JUInputInstance.PressedRun, 
				Buttons.PunchButton => JUInputInstance.PressedPunch, 
				Buttons.RollButton => JUInputInstance.PressedRoll, 
				Buttons.CrouchButton => JUInputInstance.PressedCrouch, 
				Buttons.ProneButton => JUInputInstance.PressedProne, 
				Buttons.ReloadButton => JUInputInstance.PressedReload, 
				Buttons.PickupButton => JUInputInstance.PressedPickup, 
				Buttons.EnterVehicleButton => JUInputInstance.PressedInteract, 
				Buttons.PreviousWeaponButton => JUInputInstance.PressedPreviousItem, 
				Buttons.NextWeaponButton => JUInputInstance.PressedNextItem, 
				_ => false, 
			};
		}

		public static bool GetButtonUp(Buttons Button)
		{
			GetJUInputInstance();
			return Button switch
			{
				Buttons.ShotButton => JUInputInstance.PressedShootingUp, 
				Buttons.AimingButton => JUInputInstance.PressedAimingUp, 
				Buttons.JumpButton => JUInputInstance.PressedJumpUp, 
				Buttons.RunButton => JUInputInstance.PressedRunUp, 
				Buttons.PunchButton => JUInputInstance.PressedPunchUp, 
				Buttons.RollButton => JUInputInstance.PressedRollUp, 
				Buttons.CrouchButton => JUInputInstance.PressedCrouchUp, 
				Buttons.ProneButton => JUInputInstance.PressedProneUp, 
				Buttons.ReloadButton => JUInputInstance.PressedReloadUp, 
				Buttons.PickupButton => JUInputInstance.PressedPickupUp, 
				Buttons.EnterVehicleButton => JUInputInstance.PressedInteractUp, 
				Buttons.PreviousWeaponButton => JUInputInstance.PressedPreviousItemUp, 
				Buttons.NextWeaponButton => JUInputInstance.PressedNextItemUp, 
				_ => false, 
			};
		}

		public static bool GetCustomButton(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomButton.Length; i++)
			{
				if (JUInputInstance.CustomButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomButton[i].Pressed();
				}
				if (JUInputInstance.CustomButton[i].Name != CustomButtonName && i == JUInputInstance.CustomButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetCustomButtonDown(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomButton.Length; i++)
			{
				if (JUInputInstance.CustomButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomButton[i].PressedDown();
				}
				if (JUInputInstance.CustomButton[i].Name != CustomButtonName && i == JUInputInstance.CustomButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetCustomButtonUp(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomButton.Length; i++)
			{
				if (JUInputInstance.CustomButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomButton[i].PressedUp();
				}
				if (JUInputInstance.CustomButton[i].Name != CustomButtonName && i == JUInputInstance.CustomButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetCustomTouchButton(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomTouchButton.Length; i++)
			{
				if (JUInputInstance.CustomTouchButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomTouchButton[i].Pressed();
				}
				if (JUInputInstance.CustomTouchButton[i].Name != CustomButtonName && i == JUInputInstance.CustomTouchButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetCustomTouchButtonDown(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomTouchButton.Length; i++)
			{
				if (JUInputInstance.CustomTouchButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomTouchButton[i].PressedDown();
				}
				if (JUInputInstance.CustomTouchButton[i].Name != CustomButtonName && i == JUInputInstance.CustomTouchButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetCustomTouchButtonUp(string CustomButtonName)
		{
			bool result = false;
			for (int i = 0; i < JUInputInstance.CustomTouchButton.Length; i++)
			{
				if (JUInputInstance.CustomTouchButton[i].Name == CustomButtonName)
				{
					result = JUInputInstance.CustomTouchButton[i].PressedUp();
				}
				if (JUInputInstance.CustomTouchButton[i].Name != CustomButtonName && i == JUInputInstance.CustomTouchButton.Length)
				{
					Debug.Log("Could not find an input with this name");
					result = false;
				}
			}
			return result;
		}

		public static bool GetKeyDown(KeyControl Key)
		{
			return Key.isPressed;
		}

		public static Vector2 GetMousePosition()
		{
			if (Instance() == null)
			{
				return Vector2.zero;
			}
			if (Instance().InputActions == null)
			{
				return Vector2.zero;
			}
			return Instance().InputActions.Player.MousePosition.ReadValue<Vector2>();
		}

		public static int GetTouchsLengh()
		{
			int num = -1;
			if (!EnhancedTouchSupport.enabled)
			{
				EnhancedTouchSupport.Enable();
				TouchSimulation.Enable();
				Debug.Log("Started Touch Simulation");
				return Touchscreen.current.touches.Count;
			}
			return Touchscreen.current.touches.Count;
		}

		public static TouchControl[] GetTouches()
		{
			if (!EnhancedTouchSupport.enabled)
			{
				EnhancedTouchSupport.Enable();
				TouchSimulation.Enable();
				Debug.Log("Started Touch Simulation");
			}
			return Touchscreen.current.touches.ToArray();
		}

		public static Vector2 GetCustomTouchfieldAxis(string CustomTouchfield)
		{
			Vector2 result = new Vector2(0f, 0f);
			for (int i = 0; i < JUInputInstance.CustomTouchfield.Length; i++)
			{
				if (JUInputInstance.CustomTouchfield[i].Name == CustomTouchfield)
				{
					result = JUInputInstance.CustomTouchfield[i].TouchDistance();
				}
				if (JUInputInstance.CustomTouchfield[i].Name != CustomTouchfield && i == JUInputInstance.CustomTouchfield.Length)
				{
					Debug.Log("Could not find an input with this name");
				}
			}
			return result;
		}

		public static Vector2 GetCustomVirtualJoystickAxis(string CustomJoystickName)
		{
			Vector2 result = new Vector2(0f, 0f);
			for (int i = 0; i < JUInputInstance.CustomJoystickVirtual.Length; i++)
			{
				if (JUInputInstance.CustomJoystickVirtual[i].Name == CustomJoystickName)
				{
					result = JUInputInstance.CustomJoystickVirtual[i].JoystickInput();
				}
				if (JUInputInstance.CustomJoystickVirtual[i].Name != CustomJoystickName && i == JUInputInstance.CustomJoystickVirtual.Length)
				{
					Debug.Log("Could not find an input with this name");
				}
			}
			return result;
		}

		public static void RewriteInputAxis(Axis axis, float AxisValue)
		{
			GetJUInputInstance();
			switch (axis)
			{
			case Axis.MoveHorizontal:
				JUInputInstance.MoveHorizontal = AxisValue;
				break;
			case Axis.MoveVertical:
				JUInputInstance.MoveVertical = AxisValue;
				break;
			case Axis.RotateHorizontal:
				JUInputInstance.RotateHorizontal = AxisValue;
				break;
			case Axis.RotateVertical:
				JUInputInstance.RotateVertical = AxisValue;
				break;
			default:
				Debug.LogWarning("No axis is being rewritten");
				break;
			}
		}

		public static void RewriteInputButtonPressed(Buttons button, bool ButtonValue)
		{
			GetJUInputInstance();
			switch (button)
			{
			case Buttons.ShotButton:
				JUInputInstance.PressedShooting = ButtonValue;
				break;
			case Buttons.AimingButton:
				JUInputInstance.PressedAiming = ButtonValue;
				break;
			case Buttons.JumpButton:
				JUInputInstance.PressedJump = ButtonValue;
				break;
			case Buttons.RunButton:
				JUInputInstance.PressedRun = ButtonValue;
				break;
			case Buttons.RollButton:
				JUInputInstance.PressedRoll = ButtonValue;
				break;
			case Buttons.CrouchButton:
				JUInputInstance.PressedCrouch = ButtonValue;
				break;
			case Buttons.ReloadButton:
				JUInputInstance.PressedReload = ButtonValue;
				break;
			case Buttons.PickupButton:
				JUInputInstance.PressedPickup = ButtonValue;
				break;
			case Buttons.EnterVehicleButton:
				JUInputInstance.PressedInteract = ButtonValue;
				break;
			case Buttons.PreviousWeaponButton:
				JUInputInstance.PressedPreviousItem = ButtonValue;
				break;
			case Buttons.NextWeaponButton:
				JUInputInstance.PressedNextItem = ButtonValue;
				break;
			default:
				Debug.LogWarning("No button is being rewritten");
				break;
			}
		}

		public static void RewriteInputButtonPressedDown(Buttons button, bool ButtonValue)
		{
			GetJUInputInstance();
			switch (button)
			{
			case Buttons.ShotButton:
				JUInputInstance.PressedShootingDown = ButtonValue;
				break;
			case Buttons.AimingButton:
				JUInputInstance.PressedAimingDown = ButtonValue;
				break;
			case Buttons.JumpButton:
				JUInputInstance.PressedJumpDown = ButtonValue;
				break;
			case Buttons.RunButton:
				JUInputInstance.PressedRunDown = ButtonValue;
				break;
			case Buttons.RollButton:
				JUInputInstance.PressedRollDown = ButtonValue;
				break;
			case Buttons.CrouchButton:
				JUInputInstance.PressedCrouchDown = ButtonValue;
				break;
			case Buttons.ReloadButton:
				JUInputInstance.PressedReloadDown = ButtonValue;
				break;
			case Buttons.PickupButton:
				JUInputInstance.PressedPickupDown = ButtonValue;
				break;
			case Buttons.EnterVehicleButton:
				JUInputInstance.PressedInteractDown = ButtonValue;
				break;
			case Buttons.PreviousWeaponButton:
				JUInputInstance.PressedPreviousItemDown = ButtonValue;
				break;
			case Buttons.NextWeaponButton:
				JUInputInstance.PressedNextItemDown = ButtonValue;
				break;
			default:
				Debug.LogWarning("No button down is being rewritten");
				break;
			}
		}

		public static void RewriteInputButtonPressedUp(Buttons button, bool ButtonValue)
		{
			GetJUInputInstance();
			switch (button)
			{
			case Buttons.ShotButton:
				JUInputInstance.PressedShootingUp = ButtonValue;
				break;
			case Buttons.AimingButton:
				JUInputInstance.PressedAimingUp = ButtonValue;
				break;
			case Buttons.JumpButton:
				JUInputInstance.PressedJumpUp = ButtonValue;
				break;
			case Buttons.RunButton:
				JUInputInstance.PressedRunUp = ButtonValue;
				break;
			case Buttons.RollButton:
				JUInputInstance.PressedRollUp = ButtonValue;
				break;
			case Buttons.CrouchButton:
				JUInputInstance.PressedCrouchUp = ButtonValue;
				break;
			case Buttons.ReloadButton:
				JUInputInstance.PressedReloadUp = ButtonValue;
				break;
			case Buttons.PickupButton:
				JUInputInstance.PressedPickupUp = ButtonValue;
				break;
			case Buttons.EnterVehicleButton:
				JUInputInstance.PressedInteractUp = ButtonValue;
				break;
			case Buttons.PreviousWeaponButton:
				JUInputInstance.PressedPreviousItemUp = ButtonValue;
				break;
			case Buttons.NextWeaponButton:
				JUInputInstance.PressedNextItemUp = ButtonValue;
				break;
			default:
				Debug.LogWarning("No button up is being rewritten");
				break;
			}
		}
	}
}
