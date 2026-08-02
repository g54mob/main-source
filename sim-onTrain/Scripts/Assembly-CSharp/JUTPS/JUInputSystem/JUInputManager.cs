using UnityEngine;
using UnityEngine.InputSystem;

namespace JUTPS.JUInputSystem
{
	[AddComponentMenu("JU TPS/Input/JU Input Manager")]
	public class JUInputManager : MonoBehaviour
	{
		public JUTPSInputControlls InputActions;

		private bool BlockStandardInputs;

		[HideInInspector]
		public float MoveHorizontal;

		[HideInInspector]
		public float MoveVertical;

		[HideInInspector]
		public float RotateHorizontal;

		[HideInInspector]
		public float RotateVertical;

		[HideInInspector]
		public bool PressedShooting;

		[HideInInspector]
		public bool PressedAiming;

		[HideInInspector]
		public bool PressedReload;

		[HideInInspector]
		public bool PressedRun;

		[HideInInspector]
		public bool PressedJump;

		[HideInInspector]
		public bool PressedPunch;

		[HideInInspector]
		public bool PressedCrouch;

		[HideInInspector]
		public bool PressedProne;

		[HideInInspector]
		public bool PressedRoll;

		[HideInInspector]
		public bool PressedPickup;

		[HideInInspector]
		public bool PressedInteract;

		[HideInInspector]
		public bool PressedNextItem;

		[HideInInspector]
		public bool PressedPreviousItem;

		[HideInInspector]
		public bool PressedShootingDown;

		[HideInInspector]
		public bool PressedAimingDown;

		[HideInInspector]
		public bool PressedReloadDown;

		[HideInInspector]
		public bool PressedRunDown;

		[HideInInspector]
		public bool PressedJumpDown;

		[HideInInspector]
		public bool PressedPunchDown;

		[HideInInspector]
		public bool PressedCrouchDown;

		[HideInInspector]
		public bool PressedProneDown;

		[HideInInspector]
		public bool PressedRollDown;

		[HideInInspector]
		public bool PressedPickupDown;

		[HideInInspector]
		public bool PressedInteractDown;

		[HideInInspector]
		public bool PressedNextItemDown;

		[HideInInspector]
		public bool PressedPreviousItemDown;

		[HideInInspector]
		public bool PressedOpenInventoryDown;

		[HideInInspector]
		public bool PressedShootingUp;

		[HideInInspector]
		public bool PressedAimingUp;

		[HideInInspector]
		public bool PressedReloadUp;

		[HideInInspector]
		public bool PressedRunUp;

		[HideInInspector]
		public bool PressedJumpUp;

		[HideInInspector]
		public bool PressedPunchUp;

		[HideInInspector]
		public bool PressedCrouchUp;

		[HideInInspector]
		public bool PressedProneUp;

		[HideInInspector]
		public bool PressedRollUp;

		[HideInInspector]
		public bool PressedPickupUp;

		[HideInInspector]
		public bool PressedInteractUp;

		[HideInInspector]
		public bool PressedNextItemUp;

		[HideInInspector]
		public bool PressedPreviousItemUp;

		public CustomTouchButton[] CustomTouchButton;

		public CustomTouchfield[] CustomTouchfield;

		public CustomJoystickVirtual[] CustomJoystickVirtual;

		[Header("(Old Input System)")]
		public CustomInputButton[] CustomButton;

		public static bool IsUsingGamepad;

		public bool IsBlockingDefaultInputs => BlockStandardInputs;

		public void EnableBlockStandardInputs()
		{
			BlockStandardInputs = true;
		}

		public void DisableBlockStandardInputs()
		{
			BlockStandardInputs = false;
		}

		private void Update()
		{
			if (InputActions == null)
			{
				InputActions = new JUTPSInputControlls();
				InputActions.Enable();
				AddInputUpListeners(InputActions.Player);
			}
			if (!BlockStandardInputs)
			{
				UpdateGetButtonDown();
				UpdateGetButton();
				UpdateAxis();
				double num = ((Gamepad.current != null) ? Gamepad.current.lastUpdateTime : 0.0);
				double num2 = ((Keyboard.current == null || Mouse.current == null) ? 0.0 : ((Mouse.current.lastUpdateTime < Keyboard.current.lastUpdateTime) ? Keyboard.current.lastUpdateTime : Mouse.current.lastUpdateTime));
				IsUsingGamepad = ((num > num2) ? true : false);
			}
		}

		private void AddInputUpListeners(JUTPSInputControlls.PlayerActions input)
		{
			input.Run.performed += delegate
			{
				PressedRunUp = false;
			};
			input.Run.canceled += delegate
			{
				PressedRunUp = true;
			};
			input.Roll.performed += delegate
			{
				PressedRollUp = false;
			};
			input.Roll.canceled += delegate
			{
				PressedRollUp = true;
			};
			input.Jump.performed += delegate
			{
				PressedJumpUp = false;
			};
			input.Jump.canceled += delegate
			{
				PressedJumpUp = true;
			};
			input.Punch.performed += delegate
			{
				PressedPunchUp = false;
			};
			input.Punch.canceled += delegate
			{
				PressedPunchUp = true;
			};
			input.Crouch.performed += delegate
			{
				PressedCrouchUp = false;
			};
			input.Crouch.canceled += delegate
			{
				PressedCrouchUp = true;
			};
			input.Prone.performed += delegate
			{
				PressedProneUp = false;
			};
			input.Prone.canceled += delegate
			{
				PressedProneUp = true;
			};
			input.Fire.performed += delegate
			{
				PressedShootingUp = false;
			};
			input.Fire.canceled += delegate
			{
				PressedShootingUp = true;
			};
			input.Aim.performed += delegate
			{
				PressedAimingUp = false;
			};
			input.Aim.canceled += delegate
			{
				PressedAimingUp = true;
			};
			input.Reload.performed += delegate
			{
				PressedReloadUp = false;
			};
			input.Reload.canceled += delegate
			{
				PressedReloadUp = true;
			};
			input.Pickup.performed += delegate
			{
				PressedPickupUp = false;
			};
			input.Pickup.canceled += delegate
			{
				PressedPickupUp = true;
			};
			input.Interact.performed += delegate
			{
				PressedInteractUp = false;
			};
			input.Interact.canceled += delegate
			{
				PressedInteractUp = true;
			};
			input.Next.performed += delegate
			{
				PressedNextItemUp = false;
			};
			input.Next.canceled += delegate
			{
				PressedNextItemUp = true;
			};
			input.Previous.performed += delegate
			{
				PressedPreviousItemUp = false;
			};
			input.Previous.canceled += delegate
			{
				PressedPreviousItemUp = true;
			};
		}

		protected virtual void UpdateAxis()
		{
			MoveHorizontal = InputActions.Player.Move.ReadValue<Vector2>().x;
			MoveVertical = InputActions.Player.Move.ReadValue<Vector2>().y;
			MoveHorizontal = Mathf.Clamp(MoveHorizontal, -1f, 1f);
			MoveVertical = Mathf.Clamp(MoveVertical, -1f, 1f);
			if (JUGameManager.IsMobile)
			{
				if (IsBlockingDefaultInputs)
				{
					Debug.LogWarning("In the Game Manager the ''IsMobile'' variable is set to true, but there is no script blocking the default inputs. Add a Mobile Rig from the prefabs folder or create one.");
				}
			}
			else
			{
				RotateHorizontal = InputActions.Player.Look.ReadValue<Vector2>().x;
				RotateVertical = InputActions.Player.Look.ReadValue<Vector2>().y;
			}
		}

		protected virtual void UpdateGetButtonDown()
		{
			PressedJumpDown = InputActions.Player.Jump.triggered;
			PressedRunDown = InputActions.Player.Run.triggered;
			PressedPunchDown = InputActions.Player.Punch.triggered;
			PressedRollDown = InputActions.Player.Roll.triggered;
			PressedProneDown = InputActions.Player.Prone.triggered;
			PressedCrouchDown = InputActions.Player.Crouch.triggered;
			PressedShootingDown = InputActions.Player.Fire.triggered;
			PressedAimingDown = InputActions.Player.Aim.triggered;
			PressedReloadDown = InputActions.Player.Reload.triggered;
			PressedPickupDown = InputActions.Player.Pickup.triggered;
			PressedInteractDown = InputActions.Player.Interact.triggered;
			PressedNextItemDown = InputActions.Player.Next.triggered;
			PressedPreviousItemDown = InputActions.Player.Previous.triggered;
			PressedOpenInventoryDown = InputActions.Player.OpenInventory.triggered;
		}

		protected virtual void UpdateGetButton()
		{
			PressedJump = InputActions.Player.Jump.ReadValue<float>() == 1f;
			PressedRun = InputActions.Player.Run.ReadValue<float>() == 1f;
			PressedPunch = InputActions.Player.Punch.ReadValue<float>() == 1f;
			PressedRoll = InputActions.Player.Roll.ReadValue<float>() == 1f;
			PressedProne = InputActions.Player.Prone.ReadValue<float>() == 1f;
			PressedCrouch = InputActions.Player.Crouch.ReadValue<float>() == 1f;
			PressedShooting = InputActions.Player.Fire.ReadValue<float>() == 1f;
			PressedAiming = InputActions.Player.Aim.ReadValue<float>() == 1f;
			PressedReload = InputActions.Player.Reload.ReadValue<float>() == 1f;
			PressedPickup = InputActions.Player.Pickup.ReadValue<float>() == 1f;
			PressedInteract = InputActions.Player.Interact.ReadValue<float>() == 1f;
			PressedNextItem = InputActions.Player.Next.ReadValue<float>() == 1f;
			PressedPreviousItem = InputActions.Player.Previous.ReadValue<float>() == 1f;
		}
	}
}
