using DG.Tweening;
using UnityEngine;

namespace EAST_UP
{
	public class EASTUP_AnimationController : MonoBehaviour
	{
		public Animator animator;

		[SerializeField]
		private EASTUP_PlayerController playerController;

		private float animationWalkSpeed;

		[SerializeField]
		private float animationWalkSpeedMultiplier;

		private Vector3 animationInput;

		private void FixedUpdate()
		{
			AnimationBlend(playerController.currentSpeed / playerController.sprintSpeed);
			SetHorizantal(playerController.moveInput);
		}

		public void AnimationBlend(float walkSpeed)
		{
			walkSpeed *= animationWalkSpeedMultiplier;
			DOTween.To(() => animationWalkSpeed, delegate(float x)
			{
				animationWalkSpeed = x;
			}, playerController.moveInput.y, 0.7f);
			animator.SetFloat("MoveY", animationWalkSpeed);
		}

		public void SetHorizantal(Vector3 input)
		{
			DOTween.To(() => animationInput, delegate(Vector3 x)
			{
				animationInput = x;
			}, input, 0.7f);
			animator.SetFloat("MoveX", animationInput.x);
		}

		public void SmoothTurn(float turningValue)
		{
			if (playerController.stateMachine.CurrentStateType == PlayerStateType.Idle)
			{
				if (turningValue > 0f)
				{
					animator.SetTrigger(EASTUP_AnimationKeys.TurnRightAnimation);
				}
				else if (turningValue < 0f)
				{
					animator.SetTrigger(EASTUP_AnimationKeys.TurnLeftAnimation);
				}
			}
		}
	}
}
