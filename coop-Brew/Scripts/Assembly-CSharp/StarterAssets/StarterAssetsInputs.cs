using UnityEngine;

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;

		public Vector2 look;

		public bool jump;

		public bool sprint;

		public bool aim;

		public bool shoot;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked;

		public bool cursorInputForLook;

		public void MoveInput(Vector2 newMoveDirection)
		{
		}

		public void LookInput(Vector2 newLookDirection)
		{
		}

		public void JumpInput(bool newJumpState)
		{
		}

		public void SprintInput(bool newSprintState)
		{
		}

		public void AimInput(bool newAimState)
		{
		}

		public void ShootInput(bool newShootState)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void SetCursorState(bool newState)
		{
		}
	}
}
