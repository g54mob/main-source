using UnityEngine;

namespace StarterAssets
{
	public class UICanvasControllerInput : MonoBehaviour
	{
		[Header("Output")]
		public StarterAssetsInputs starterAssetsInputs;

		public void VirtualMoveInput(Vector2 virtualMoveDirection)
		{
		}

		public void VirtualLookInput(Vector2 virtualLookDirection)
		{
		}

		public void VirtualJumpInput(bool virtualJumpState)
		{
		}

		public void VirtualSprintInput(bool virtualSprintState)
		{
		}
	}
}
