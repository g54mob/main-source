using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Inject]
		private IPlayerInputService _inputService;

		[Header("Character Input Values")]
		public Vector2 move;

		public Vector2 look;

		public bool jump;

		public bool sprint;

		public bool crouch;

		[Header("Movement Settings")]
		public bool analogMovement;

		private void OnEnable()
		{
			_inputService.OnMove += MoveInput;
			_inputService.OnLook += LookInput;
			_inputService.OnSprint += SprintInput;
			_inputService.OnJump += JumpInput;
			_inputService.OnCrouch += CrouchInput;
		}

		private void OnDisable()
		{
			_inputService.OnMove -= MoveInput;
			_inputService.OnLook -= LookInput;
			_inputService.OnSprint -= SprintInput;
			_inputService.OnJump -= JumpInput;
			_inputService.OnCrouch -= CrouchInput;
		}

		private void CrouchInput(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				crouch = true;
			}
			else
			{
				crouch = false;
			}
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			Debug.Log($"sprint: {newSprintState}");
			sprint = newSprintState;
		}
	}
}
