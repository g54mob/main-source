using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerInput_PC : PlayerComponent
	{
		private bool isCrouching;

		public bool isSprinting;

		public bool isCPRActive;

		private bool wasCPRCrouching;

		private void Update()
		{
			if (!base.Player.Pause.Active && base.Player.ViewLocked.Is(value: false) && TrainGameManager.isInputActive)
			{
				base.Player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
				if (base.Player.Aim.Active && base.Player.Prone.Active)
				{
					base.Player.moveInput = Vector2.zero;
				}
				base.Player.MoveInput.Set(base.Player.moveInput);
				if (TrainGameManager.isInputActive && !TrainGameManager.isMouseLocked)
				{
					base.Player.LookInput.Set(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")));
				}
				base.Player.Interact.Set(Input.GetButton("Interact"));
				if (Input.GetButtonDown("Jump"))
				{
					base.Player.Jump.TryStart();
				}
				bool button = Input.GetButton("Sprint");
				bool flag = base.Player.IsGrounded.Get() && base.Player.MoveInput.Get().y > 0f;
				if (!base.Player.Run.Active && button && flag)
				{
					base.Player.Run.TryStart();
				}
				if (base.Player.Run.Active && !button)
				{
					base.Player.Run.ForceStop();
				}
				if (isCPRActive && !base.Player.Crouch.Active)
				{
					wasCPRCrouching = true;
					base.Player.Crouch.TryStart();
					Debug.Log("CPR Crouch Started");
				}
				else if (!isCPRActive && wasCPRCrouching && !Input.GetButton("Crouch"))
				{
					wasCPRCrouching = false;
					base.Player.Crouch.ForceStop();
					isCrouching = false;
					Debug.Log("CPR Crouch Ended");
				}
				if (Input.GetButtonDown("Crouch") && !isCrouching && !isCPRActive && !base.Player.Crouch.Active)
				{
					isCrouching = true;
					base.Player.Crouch.TryStart();
					Debug.Log("Crouch Started");
				}
				if (Input.GetButtonUp("Crouch") && isCrouching && !isCPRActive)
				{
					base.Player.Crouch.ForceStop();
					isCrouching = false;
				}
				if (Input.GetButton("Sprint"))
				{
					isSprinting = true;
					base.Player.Run.TryStart();
				}
				else
				{
					isSprinting = false;
				}
				UseEquipment();
			}
			else
			{
				base.Player.moveInput = Vector2.zero;
				base.Player.MoveInput.Set(Vector2Int.zero);
				base.Player.LookInput.Set(Vector2.zero);
			}
			float axisRaw = Input.GetAxisRaw("Mouse ScrollWheel");
			base.Player.ScrollValue.Set(axisRaw);
		}

		private void UseEquipment()
		{
			if (!Input.GetButtonDown("Drop") || base.Player.EquippedItem.Is(null) || base.Player.Reload.Active || base.Player.Healing.Active)
			{
				if (Input.GetButtonDown("ChangeUseMode"))
				{
					base.Player.ChangeUseMode.Try();
				}
				bool button = Input.GetButton("AlternateUse");
				if (Input.GetButtonDown("UseEquipment"))
				{
					base.Player.UseItem.Try(arg1: false, button ? 1 : 0);
				}
				else if (Input.GetButton("UseEquipment"))
				{
					base.Player.UseItem.Try(arg1: true, button ? 1 : 0);
				}
				if (Input.GetButtonDown("ReloadEquipment"))
				{
					base.Player.Reload.TryStart();
				}
				bool button2 = Input.GetButton("Aim");
				if (!base.Player.Aim.Active && button2)
				{
					base.Player.Aim.TryStart();
				}
				else if (base.Player.Aim.Active && !button2)
				{
					base.Player.Aim.ForceStop();
				}
			}
		}
	}
}
