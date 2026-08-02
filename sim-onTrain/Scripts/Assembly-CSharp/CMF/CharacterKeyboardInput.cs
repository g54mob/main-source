using DG.Tweening;
using UnityEngine;

namespace CMF
{
	public class CharacterKeyboardInput : CharacterInput
	{
		public string horizontalInputAxis = "Horizontal";

		public string verticalInputAxis = "Vertical";

		public KeyCode jumpKey = KeyCode.Space;

		public bool useRawInput = true;

		public Transform modelObject;

		public override float GetHorizontalMovementInput()
		{
			if (useRawInput)
			{
				return Input.GetAxisRaw(horizontalInputAxis);
			}
			return Input.GetAxis(horizontalInputAxis);
		}

		public override float GetVerticalMovementInput()
		{
			if (useRawInput)
			{
				return Input.GetAxisRaw(verticalInputAxis);
			}
			return Input.GetAxis(verticalInputAxis);
		}

		public override bool IsJumpKeyPressed()
		{
			return Input.GetKey(jumpKey);
		}

		private void Update()
		{
			if (GetVerticalMovementInput() >= 1f && GetHorizontalMovementInput() == 1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, 45f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() >= 1f && GetHorizontalMovementInput() == -1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, -45f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() == 0f && GetHorizontalMovementInput() == -1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, -90f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() == 0f && GetHorizontalMovementInput() == 1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, 90f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() == -1f && GetHorizontalMovementInput() == 0f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, 180f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() == -1f && GetHorizontalMovementInput() == 1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, 135f, 0f), 0.5f);
			}
			else if (GetVerticalMovementInput() == -1f && GetHorizontalMovementInput() == -1f && Input.GetKey(KeyCode.LeftShift))
			{
				modelObject.DOLocalRotate(new Vector3(0f, 225f, 0f), 0.5f);
			}
			else
			{
				modelObject.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.5f);
			}
		}
	}
}
