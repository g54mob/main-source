using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.CrossPlataform
{
	public class MobileRig : MonoBehaviour
	{
		[Header("Panels")]
		public GameObject MobileScreenPanel;

		public GameObject NormalScreenPanel;

		public GameObject DrivingScreenPanel;

		[Header("Joysticks")]
		[SerializeField]
		private JoystickVirtual MovementJoystick;

		[SerializeField]
		private JoystickVirtual RightJoystick;

		[SerializeField]
		private bool RightJoystickIsShootInput = true;

		[SerializeField]
		private float RightJoystickShotSensibility = 0.5f;

		private bool PressedRightJoystickDown;

		[Header("Touch Fields")]
		[SerializeField]
		private Touchfield RotateCameraTouchfield;

		[SerializeField]
		private Touchfield ShotButtonTouchfield;

		[Header("Buttons")]
		public bool ShowShotButtonOnlyUsingItem;

		[SerializeField]
		private ButtonVirtual ShotButton;

		[SerializeField]
		private ButtonVirtual AimingButton;

		[SerializeField]
		private ButtonVirtual ReloadButton;

		[SerializeField]
		private ButtonVirtual RunButton;

		[SerializeField]
		private ButtonVirtual RunButtonRight;

		[SerializeField]
		private ButtonVirtual JumpButton;

		[SerializeField]
		private ButtonVirtual CrouchButton;

		[SerializeField]
		private ButtonVirtual RollButton;

		[SerializeField]
		private ButtonVirtual PickItemButton;

		[SerializeField]
		private ButtonVirtual EnterVehicleButton;

		[SerializeField]
		private ButtonVirtual NextWeaponButton;

		[SerializeField]
		private ButtonVirtual PreviousWeaponButton;

		[SerializeField]
		private ButtonVirtual RightButton;

		[SerializeField]
		private ButtonVirtual LeftButton;

		[SerializeField]
		private ButtonVirtual ForwardButton;

		[SerializeField]
		private ButtonVirtual BackButton;

		[SerializeField]
		private ButtonVirtual BrakeButton;

		public void FindButtonsAndTouches()
		{
			MobileScreenPanel = GameObject.Find("Mobile Screen");
			NormalScreenPanel = GameObject.Find("Normal Mobile Screen Panel");
			DrivingScreenPanel = GameObject.Find("Driving Mobile Screen Panel");
			RotateCameraTouchfield = GameObject.Find("Rotate Camera Touchfield").GetComponent<Touchfield>();
			ShotButtonTouchfield = GameObject.Find("ShotButton").GetComponent<Touchfield>();
			MovementJoystick = GameObject.Find("Joystick").GetComponent<JoystickVirtual>();
			ShotButton = GameObject.Find("ShotButton").GetComponent<ButtonVirtual>();
			AimingButton = GameObject.Find("AimingButton").GetComponent<ButtonVirtual>();
			JumpButton = GameObject.Find("JumpButton").GetComponent<ButtonVirtual>();
			RunButton = GameObject.Find("RunButton").GetComponent<ButtonVirtual>();
			RunButtonRight = GameObject.Find("RightRunButton").GetComponent<ButtonVirtual>();
			RollButton = GameObject.Find("RollButton").GetComponent<ButtonVirtual>();
			CrouchButton = GameObject.Find("CrouchButton").GetComponent<ButtonVirtual>();
			ReloadButton = GameObject.Find("ReloadButton").GetComponent<ButtonVirtual>();
			PickItemButton = GameObject.Find("InteractButton").GetComponent<ButtonVirtual>();
			EnterVehicleButton = GameObject.Find("Enter The Vehicle Button").GetComponent<ButtonVirtual>();
			PreviousWeaponButton = GameObject.Find("PreviousWeaponButton").GetComponent<ButtonVirtual>();
			NextWeaponButton = GameObject.Find("NextWeaponButton").GetComponent<ButtonVirtual>();
			RightButton = GameObject.Find("RightButton").GetComponent<ButtonVirtual>();
			LeftButton = GameObject.Find("LeftButton").GetComponent<ButtonVirtual>();
			ForwardButton = GameObject.Find("ForwardButton").GetComponent<ButtonVirtual>();
			BackButton = GameObject.Find("BackButton").GetComponent<ButtonVirtual>();
			BrakeButton = GameObject.Find("BrakeButton").GetComponent<ButtonVirtual>();
		}

		private void Update()
		{
			if (JUGameManager.IsMobile)
			{
				UpdateMobileScreen();
				UpdateMobileButtons();
				if (!JUInput.Instance().IsBlockingDefaultInputs)
				{
					JUInput.Instance().EnableBlockStandardInputs();
				}
				RewriteGetButtonDown();
				RewriteGetButtonUp();
				RewriteGetButton();
				RewriteAxis();
			}
			else
			{
				MobileScreenPanel.SetActive(value: false);
				if (JUInput.Instance().IsBlockingDefaultInputs)
				{
					JUInput.Instance().DisableBlockStandardInputs();
				}
			}
		}

		private void UpdateMobileScreen()
		{
			if (!JUGameManager.IsMobile)
			{
				MobileScreenPanel.SetActive(value: false);
				return;
			}
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			MobileScreenPanel.SetActive(JUGameManager.IsMobile);
			NormalScreenPanel.SetActive(!JUGameManager.InstancedPlayer.IsDriving);
			DrivingScreenPanel.SetActive(JUGameManager.InstancedPlayer.IsDriving);
		}

		private void UpdateMobileButtons()
		{
			if (PickItemButton != null)
			{
				PickItemButton.gameObject.SetActive(JUGameManager.InstancedPlayer.Inventory != null && (bool)JUGameManager.InstancedPlayer.Inventory.ItemToPickUp);
			}
			if (ReloadButton != null)
			{
				ReloadButton.gameObject.SetActive((JUGameManager.InstancedPlayer.WeaponInUseRightHand != null || JUGameManager.InstancedPlayer.WeaponInUseLeftHand != null) ? true : false);
			}
			if (AimingButton != null)
			{
				AimingButton.gameObject.SetActive((JUGameManager.InstancedPlayer.WeaponInUseRightHand != null) ? true : false);
			}
			if (ShotButton != null)
			{
				ShotButton.gameObject.SetActive(!ShowShotButtonOnlyUsingItem || JUGameManager.InstancedPlayer.IsItemEquiped);
			}
			if (!JUGameManager.InstancedPlayer.IsDriving && EnterVehicleButton != null)
			{
				EnterVehicleButton.gameObject.SetActive(JUGameManager.InstancedPlayer.ToEnterVehicle);
			}
		}

		private void RewriteAxis()
		{
			if (MovementJoystick != null)
			{
				JUInput.RewriteInputAxis(JUInput.Axis.MoveHorizontal, Mathf.Clamp(MovementJoystick.Horizontal(), -1f, 1f));
				JUInput.RewriteInputAxis(JUInput.Axis.MoveVertical, Mathf.Clamp(MovementJoystick.Vertical(), -1f, 1f));
			}
			if (ForwardButton != null && ForwardButton.IsPressed)
			{
				JUInput.RewriteInputAxis(JUInput.Axis.MoveVertical, 1f);
			}
			if (BackButton != null && BackButton.IsPressed)
			{
				JUInput.RewriteInputAxis(JUInput.Axis.MoveVertical, -1f);
			}
			if (RightButton != null && RightButton.IsPressed)
			{
				JUInput.RewriteInputAxis(JUInput.Axis.MoveHorizontal, 1f);
			}
			if (LeftButton != null && LeftButton.IsPressed)
			{
				JUInput.RewriteInputAxis(JUInput.Axis.MoveHorizontal, -1f);
			}
			if (!JUGameManager.IsMobile || !(RotateCameraTouchfield != null))
			{
				return;
			}
			if (RightJoystick == null)
			{
				if (ShotButtonTouchfield != null)
				{
					JUInput.RewriteInputAxis(JUInput.Axis.RotateHorizontal, RotateCameraTouchfield.TouchDistance.x / 5f + ShotButtonTouchfield.TouchDistance.x / 5f);
					JUInput.RewriteInputAxis(JUInput.Axis.RotateVertical, RotateCameraTouchfield.TouchDistance.y / 5f + ShotButtonTouchfield.TouchDistance.y / 5f);
				}
				else
				{
					JUInput.RewriteInputAxis(JUInput.Axis.RotateHorizontal, RotateCameraTouchfield.TouchDistance.x / 5f);
					JUInput.RewriteInputAxis(JUInput.Axis.RotateVertical, RotateCameraTouchfield.TouchDistance.y / 5f);
				}
			}
			else
			{
				JUInput.RewriteInputAxis(JUInput.Axis.RotateHorizontal, Mathf.Clamp(RightJoystick.Horizontal(), -1f, 1f));
				JUInput.RewriteInputAxis(JUInput.Axis.RotateVertical, Mathf.Clamp(RightJoystick.Vertical(), -1f, 1f));
			}
		}

		private void RewriteGetButtonDown()
		{
			if (ShotButton != null)
			{
				JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.ShotButton, ShotButton.IsPressedDown);
			}
			if (AimingButton != null)
			{
				JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.AimingButton, AimingButton.IsPressedDown);
			}
			if (RightJoystick != null && RightJoystickIsShootInput)
			{
				if (!PressedRightJoystickDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.ShotButton, RightJoystick.IsPressed);
					PressedRightJoystickDown = true;
				}
				if (!RightJoystick.IsPressed && PressedRightJoystickDown)
				{
					PressedRightJoystickDown = false;
				}
			}
			if (JumpButton != null)
			{
				if (JumpButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.JumpButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.JumpButton, ButtonValue: false);
				}
			}
			if (RunButton != null)
			{
				if (RunButton.IsPressedDown || RunButtonRight.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.RunButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.RunButton, ButtonValue: false);
				}
			}
			if (RollButton != null)
			{
				if (RollButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.RollButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.RollButton, ButtonValue: false);
				}
			}
			if (CrouchButton != null)
			{
				if (CrouchButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.CrouchButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.CrouchButton, ButtonValue: false);
				}
			}
			if (ReloadButton != null)
			{
				if (ReloadButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.ReloadButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.ReloadButton, ButtonValue: false);
				}
			}
			if (PickItemButton != null)
			{
				if (PickItemButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.PickupButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.PickupButton, ButtonValue: false);
				}
			}
			if (EnterVehicleButton != null)
			{
				if (EnterVehicleButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.EnterVehicleButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.EnterVehicleButton, ButtonValue: false);
				}
			}
			if (NextWeaponButton != null)
			{
				if (NextWeaponButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.NextWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.NextWeaponButton, ButtonValue: false);
				}
			}
			if (PreviousWeaponButton != null)
			{
				if (PreviousWeaponButton.IsPressedDown)
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.PreviousWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedDown(JUInput.Buttons.PreviousWeaponButton, ButtonValue: false);
				}
			}
		}

		private void RewriteGetButton()
		{
			if (RightJoystick == null)
			{
				if (ShotButton != null)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.ShotButton, ShotButton.IsPressed);
				}
			}
			else
			{
				if (ShotButton != null && !RightJoystickIsShootInput)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.ShotButton, ShotButton.IsPressed);
				}
				if (RightJoystickIsShootInput && RightJoystick != null)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.ShotButton, RightJoystick.Intensity > RightJoystickShotSensibility);
				}
			}
			if (AimingButton != null)
			{
				JUInput.RewriteInputButtonPressed(JUInput.Buttons.AimingButton, AimingButton.IsPressed);
			}
			if (JumpButton != null)
			{
				if (JumpButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.JumpButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.JumpButton, ButtonValue: false);
				}
			}
			if (BrakeButton != null && DrivingScreenPanel.activeInHierarchy)
			{
				if (BrakeButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.JumpButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.JumpButton, ButtonValue: false);
				}
			}
			if (RunButton != null)
			{
				if (RunButton.IsPressed || RunButtonRight.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.RunButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.RunButton, ButtonValue: false);
				}
			}
			if (RollButton != null)
			{
				if (RollButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.RollButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.RollButton, ButtonValue: false);
				}
			}
			if (CrouchButton != null)
			{
				if (CrouchButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.CrouchButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.CrouchButton, ButtonValue: false);
				}
			}
			if (ReloadButton != null)
			{
				if (ReloadButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.ReloadButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.ReloadButton, ButtonValue: false);
				}
			}
			if (PickItemButton != null)
			{
				if (PickItemButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.PickupButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.PickupButton, ButtonValue: false);
				}
			}
			if (EnterVehicleButton != null)
			{
				if (EnterVehicleButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.EnterVehicleButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.EnterVehicleButton, ButtonValue: false);
				}
			}
			if (NextWeaponButton != null)
			{
				if (NextWeaponButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.NextWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.NextWeaponButton, ButtonValue: false);
				}
			}
			if (PreviousWeaponButton != null)
			{
				if (PreviousWeaponButton.IsPressed)
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.PreviousWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressed(JUInput.Buttons.PreviousWeaponButton, ButtonValue: false);
				}
			}
		}

		private void RewriteGetButtonUp()
		{
			if (JUGameManager.IsMobile)
			{
				if (ShotButton != null)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.ShotButton, ShotButton.IsPressedUp);
				}
				if (AimingButton != null)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.AimingButton, AimingButton.IsPressedUp);
				}
			}
			if (JumpButton != null)
			{
				if (JumpButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.JumpButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.JumpButton, ButtonValue: false);
				}
			}
			if (RunButton != null)
			{
				if (RunButton.IsPressedUp || RunButtonRight.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.RunButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.RunButton, ButtonValue: false);
				}
			}
			if (RollButton != null)
			{
				if (RollButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.RollButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.RollButton, ButtonValue: false);
				}
			}
			if (CrouchButton != null)
			{
				if (CrouchButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.CrouchButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.CrouchButton, ButtonValue: false);
				}
			}
			if (ReloadButton != null)
			{
				if (ReloadButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.ReloadButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.ReloadButton, ButtonValue: false);
				}
			}
			if (PickItemButton != null)
			{
				if (PickItemButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.PickupButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.PickupButton, ButtonValue: false);
				}
			}
			if (EnterVehicleButton != null)
			{
				if (EnterVehicleButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.EnterVehicleButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.EnterVehicleButton, ButtonValue: false);
				}
			}
			if (NextWeaponButton != null)
			{
				if (NextWeaponButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.NextWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.NextWeaponButton, ButtonValue: false);
				}
			}
			if (PreviousWeaponButton != null)
			{
				if (PreviousWeaponButton.IsPressedUp)
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.PreviousWeaponButton, ButtonValue: true);
				}
				else
				{
					JUInput.RewriteInputButtonPressedUp(JUInput.Buttons.PreviousWeaponButton, ButtonValue: false);
				}
			}
		}
	}
}
