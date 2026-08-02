using System;
using HQFPSTemplate;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Synty.AnimationBaseLocomotion.Samples.InputSystem
{
	public class InputReader : MonoBehaviour, Controls.IPlayerActions
	{
		public Vector2 _mouseDelta;

		public Vector2 _moveComposite;

		public float _movementInputDuration;

		public bool _movementInputDetected;

		private Controls _controls;

		public Action onAimActivated;

		public Action onAimDeactivated;

		public Action onCrouchActivated;

		public Action onCrouchDeactivated;

		public Action onJumpPerformed;

		public Action onLockOnToggled;

		public Action onSprintActivated;

		public Action onSprintDeactivated;

		public Action onWalkToggled;

		public bool isMovingBack;

		private bool itCanSpring = true;

		private bool previousSprintState;

		public PlayerMovement playerComponent;

		private bool _suppressMovement;

		public bool isPressingSprint => IsRunning();

		private void OnEnable()
		{
			if (_controls == null)
			{
				_controls = new Controls();
				_controls.Player.SetCallbacks(this);
			}
			_controls.Player.Enable();
		}

		public void OnDisable()
		{
			_controls.Player.Disable();
		}

		public bool IsRunning()
		{
			if (playerComponent.ReturnCurrentState() == playerComponent.m_RunState)
			{
				return true;
			}
			return false;
		}

		private void Update()
		{
			if (_moveComposite.y >= 0f)
			{
				isMovingBack = false;
				itCanSpring = true;
			}
			else
			{
				isMovingBack = true;
				itCanSpring = false;
			}
			if (isPressingSprint && !previousSprintState)
			{
				onSprintActivated?.Invoke();
			}
			else if (!isPressingSprint && previousSprintState)
			{
				onSprintDeactivated?.Invoke();
			}
			previousSprintState = isPressingSprint;
			if (Input.GetButtonUp("Vertical") && Input.GetAxis("Vertical") < 0f && !isMovingBack && Input.GetButton("Sprint"))
			{
				onSprintActivated();
				itCanSpring = false;
			}
		}

		public void OnLook(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive && !TrainGameManager.isMouseLocked)
			{
				_mouseDelta = context.ReadValue<Vector2>();
			}
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			if (!TrainGameManager.isInputActive)
			{
				_moveComposite = Vector2.zero;
				_movementInputDetected = false;
			}
			else
			{
				_moveComposite = context.ReadValue<Vector2>();
				_movementInputDetected = _moveComposite.magnitude > 0f;
			}
		}

		public void OnJump(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive && context.performed)
			{
				onJumpPerformed?.Invoke();
			}
		}

		public void OnToggleWalk(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive && context.performed)
			{
				onWalkToggled?.Invoke();
			}
		}

		public void OnSprint(InputAction.CallbackContext context)
		{
		}

		public void OnCrouch(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive)
			{
				if (context.started)
				{
					onCrouchActivated?.Invoke();
				}
				else if (context.canceled)
				{
					onCrouchDeactivated?.Invoke();
				}
			}
		}

		public void OnAim(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive)
			{
				if (context.started)
				{
					onAimActivated?.Invoke();
				}
				if (context.canceled)
				{
					onAimDeactivated?.Invoke();
				}
			}
		}

		public void OnLockOn(InputAction.CallbackContext context)
		{
			if (TrainGameManager.isInputActive && context.performed)
			{
				onLockOnToggled?.Invoke();
				onSprintDeactivated?.Invoke();
			}
		}

		public bool IsMoving()
		{
			if (_moveComposite.magnitude > 0.01f)
			{
				return true;
			}
			return false;
		}

		public void SetMovementSuppressed(bool value)
		{
			_suppressMovement = value;
			if (_controls != null)
			{
				if (value)
				{
					_controls.Player.Move.Disable();
				}
				else
				{
					_controls.Player.Move.Enable();
				}
			}
			if (value)
			{
				_moveComposite = Vector2.zero;
				_movementInputDetected = false;
			}
		}
	}
}
