using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerInputService : IPlayerInputService, ILateDisposable
	{
		private DefaultInput _defaultInput;

		public event Action<InputAction.CallbackContext> OnInventory;

		public event Action<Vector2> OnMove;

		public event Action<Vector2> OnLook;

		public event Action<bool> OnJump;

		public event Action<bool> OnSprint;

		public event Action<InputAction.CallbackContext> OnInteract;

		public event Action<InputAction.CallbackContext> OnDrop;

		public event Action<InputAction.CallbackContext> OnPlayerUse;

		public event Action<bool> OnInventoryUse;

		public event Action<Vector2> OnInventoryLook;

		public event Action<InputAction.CallbackContext> OnInventoryInteract;

		public event Action<InputAction.CallbackContext> OnZoom;

		public event Action<InputAction.CallbackContext> OnRotateHolder;

		public event Action<float> OnRotate;

		public event Action<InputAction.CallbackContext> OnPause;

		public event Action<InputAction.CallbackContext> OnPlayerMount;

		public event Action<InputAction.CallbackContext> OnHideHud;

		public event Action<InputAction.CallbackContext> OnPush;

		public event Action<InputAction.CallbackContext> OnCrouch;

		public PlayerInputService()
		{
			_defaultInput = new DefaultInput();
			_defaultInput.Enable();
			_defaultInput.Player.Inventory.performed += OnInventoryPerformed;
			_defaultInput.Player.Crouch.started += OnCrouchInput;
			_defaultInput.Player.Crouch.canceled += OnCrouchInput;
			_defaultInput.Player.Move.performed += OnMovePerformed;
			_defaultInput.Player.Move.canceled += OnMoveCancelled;
			_defaultInput.Player.Look.performed += OnLookPerformed;
			_defaultInput.Player.Look.canceled += OnLookCanceled;
			_defaultInput.Player.Jump.performed += OnJumpPerformed;
			_defaultInput.Player.Sprint.performed += OnSprintPerformed;
			_defaultInput.Player.Sprint.canceled += OnSprintCanceled;
			_defaultInput.Player.Interact.performed += OnInteractPerformed;
			_defaultInput.Player.Interact.started += OnInteractPerformed;
			_defaultInput.Player.Interact.canceled += OnInteractPerformed;
			_defaultInput.Inventory.Use.performed += OnInventoryUsePerformed;
			_defaultInput.Inventory.Look.performed += OnInventoryLookPerformed;
			_defaultInput.Inventory.Interact.performed += OnInventoryInteractPerformed;
			_defaultInput.Inventory.Interact.started += OnInventoryInteractPerformed;
			_defaultInput.Inventory.Interact.canceled += OnInventoryInteractPerformed;
			_defaultInput.Player.Use.performed += OnUsePerformed;
			_defaultInput.Player.Use.started += OnUsePerformed;
			_defaultInput.Player.Use.canceled += OnUsePerformed;
			_defaultInput.Player.Drop.performed += OnDropPerformed;
			_defaultInput.Player.Drop.started += OnDropPerformed;
			_defaultInput.Player.Drop.canceled += OnDropPerformed;
			_defaultInput.Player.Zoom.started += OnZoomPerformed;
			_defaultInput.Player.Zoom.canceled += OnZoomPerformed;
			_defaultInput.Player.Rotate.performed += OnRotatePerformed;
			_defaultInput.Player.Pause.performed += OnPausePerformed;
			_defaultInput.Player.Mount.performed += OnPlayerMountPerformed;
			_defaultInput.Player.RotateHolder.started += OnPlayerRotateHolder;
			_defaultInput.Player.RotateHolder.performed += OnPlayerRotateHolder;
			_defaultInput.Player.RotateHolder.canceled += OnPlayerRotateHolder;
			_defaultInput.Player.HideHud.started += OnPlayerHideHud;
			_defaultInput.Player.HideHud.performed += OnPlayerHideHud;
			_defaultInput.Player.HideHud.canceled += OnPlayerHideHud;
			_defaultInput.Player.Push.started += OnPlayerPush;
			_defaultInput.Player.Push.performed += OnPlayerPush;
			_defaultInput.Player.Push.canceled += OnPlayerPush;
		}

		private void OnCrouchInput(InputAction.CallbackContext context)
		{
			this.OnCrouch?.Invoke(context);
		}

		private void OnPlayerPush(InputAction.CallbackContext context)
		{
			this.OnPush?.Invoke(context);
		}

		private void OnPlayerHideHud(InputAction.CallbackContext context)
		{
			this.OnHideHud?.Invoke(context);
		}

		private void OnPlayerRotateHolder(InputAction.CallbackContext context)
		{
			this.OnRotateHolder?.Invoke(context);
		}

		private void OnPlayerMountPerformed(InputAction.CallbackContext context)
		{
			this.OnPlayerMount?.Invoke(context);
		}

		private void OnPausePerformed(InputAction.CallbackContext context)
		{
			this.OnPause?.Invoke(context);
		}

		private void OnRotatePerformed(InputAction.CallbackContext context)
		{
			this.OnRotate?.Invoke(context.ReadValue<float>());
		}

		private void OnSprintCanceled(InputAction.CallbackContext context)
		{
			this.OnSprint?.Invoke(obj: false);
		}

		private void OnInventoryInteractPerformed(InputAction.CallbackContext context)
		{
			this.OnInventoryInteract?.Invoke(context);
		}

		private void OnInventoryLookPerformed(InputAction.CallbackContext context)
		{
			this.OnInventoryLook?.Invoke(context.ReadValue<Vector2>());
		}

		private void OnZoomPerformed(InputAction.CallbackContext context)
		{
			this.OnZoom?.Invoke(context);
		}

		private void OnInventoryUsePerformed(InputAction.CallbackContext context)
		{
			this.OnInventoryUse?.Invoke(context.performed);
		}

		private void OnDropPerformed(InputAction.CallbackContext context)
		{
			this.OnDrop?.Invoke(context);
		}

		private void OnUsePerformed(InputAction.CallbackContext context)
		{
			this.OnPlayerUse?.Invoke(context);
		}

		private void OnSprintPerformed(InputAction.CallbackContext context)
		{
			this.OnSprint?.Invoke(obj: true);
		}

		private void OnJumpPerformed(InputAction.CallbackContext context)
		{
			this.OnJump?.Invoke(context.performed);
		}

		private void OnLookPerformed(InputAction.CallbackContext context)
		{
			this.OnLook?.Invoke(context.ReadValue<Vector2>());
		}

		private void OnLookCanceled(InputAction.CallbackContext context)
		{
			this.OnLook?.Invoke(Vector2.zero);
		}

		private void OnMovePerformed(InputAction.CallbackContext context)
		{
			this.OnMove?.Invoke(context.ReadValue<Vector2>());
		}

		private void OnMoveCancelled(InputAction.CallbackContext context)
		{
			this.OnMove?.Invoke(Vector2.zero);
		}

		private void OnInventoryPerformed(InputAction.CallbackContext context)
		{
			this.OnInventory?.Invoke(context);
		}

		private void OnInteractPerformed(InputAction.CallbackContext context)
		{
			this.OnInteract?.Invoke(context);
		}

		void IPlayerInputService.DisableLookAction()
		{
			_defaultInput.Player.Look.Disable();
		}

		void IPlayerInputService.EnableLookAction()
		{
			_defaultInput.Player.Look.Enable();
		}

		void IPlayerInputService.DisablePlayerUseAction()
		{
			_defaultInput.Player.Use.Disable();
		}

		void IPlayerInputService.EnablePlayerUseAction()
		{
			_defaultInput.Player.Use.Enable();
		}

		void IPlayerInputService.DisableMoveAction()
		{
			_defaultInput.Player.Move.Disable();
		}

		void IPlayerInputService.EnableMoveAction()
		{
			_defaultInput.Player.Move.Enable();
		}

		void IPlayerInputService.DisableInteractAction()
		{
			_defaultInput.Player.Interact.Disable();
		}

		void IPlayerInputService.EnableInteractAction()
		{
			_defaultInput.Player.Interact.Enable();
		}

		void IPlayerInputService.DisablePauseAction()
		{
			_defaultInput.Player.Pause.Disable();
		}

		void IPlayerInputService.EnablePauseAction()
		{
			_defaultInput.Player.Pause.Enable();
		}

		void IPlayerInputService.DisableInventoryAction()
		{
			_defaultInput.Player.Inventory.Disable();
		}

		void IPlayerInputService.EnableInventoryAction()
		{
			_defaultInput.Player.Inventory.Enable();
		}

		void IPlayerInputService.EnablePushAction()
		{
			_defaultInput.Player.Push.Enable();
		}

		void IPlayerInputService.DisablePushAction()
		{
			_defaultInput.Player.Push.Disable();
		}

		void IPlayerInputService.DisableAllInput()
		{
			_defaultInput.Player.Disable();
		}

		void IPlayerInputService.EnableAllInput()
		{
			_defaultInput.Player.Enable();
		}

		void IPlayerInputService.EnableJumpAction()
		{
			_defaultInput.Player.Jump.Enable();
		}

		void IPlayerInputService.DisableJumpAction()
		{
			_defaultInput.Player.Jump.Disable();
		}

		void IPlayerInputService.EnableCrouchAction()
		{
			_defaultInput.Player.Crouch.Enable();
		}

		void IPlayerInputService.DisableCrouchAction()
		{
			_defaultInput.Player.Crouch.Disable();
		}

		void ILateDisposable.LateDispose()
		{
		}
	}
}
