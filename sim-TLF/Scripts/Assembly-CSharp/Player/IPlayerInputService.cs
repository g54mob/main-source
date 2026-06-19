using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public interface IPlayerInputService
	{
		event Action<InputAction.CallbackContext> OnInventory;

		event Action<Vector2> OnMove;

		event Action<Vector2> OnLook;

		event Action<InputAction.CallbackContext> OnCrouch;

		event Action<bool> OnJump;

		event Action<bool> OnSprint;

		event Action<InputAction.CallbackContext> OnInteract;

		event Action<InputAction.CallbackContext> OnDrop;

		event Action<InputAction.CallbackContext> OnPlayerUse;

		event Action<bool> OnInventoryUse;

		event Action<InputAction.CallbackContext> OnInventoryInteract;

		event Action<Vector2> OnInventoryLook;

		event Action<InputAction.CallbackContext> OnZoom;

		event Action<InputAction.CallbackContext> OnRotateHolder;

		event Action<float> OnRotate;

		event Action<InputAction.CallbackContext> OnPause;

		event Action<InputAction.CallbackContext> OnPlayerMount;

		event Action<InputAction.CallbackContext> OnHideHud;

		event Action<InputAction.CallbackContext> OnPush;

		void DisableAllInput();

		void EnableAllInput();

		void EnablePushAction();

		void DisablePushAction();

		void DisableLookAction();

		void EnableLookAction();

		void DisablePlayerUseAction();

		void EnablePlayerUseAction();

		void DisableMoveAction();

		void EnableMoveAction();

		void DisableInteractAction();

		void EnableInteractAction();

		void DisablePauseAction();

		void EnablePauseAction();

		void DisableInventoryAction();

		void EnableInventoryAction();

		void EnableJumpAction();

		void DisableJumpAction();

		void EnableCrouchAction();

		void DisableCrouchAction();
	}
}
