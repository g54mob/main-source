using Restory.Constants;
using Restory.UserInterface;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public class GUI_MouseTooltip : MonoBehaviour
	{
		[SerializeField]
		private GUI_ScreenObjectModelFollower follower;

		[SerializeField]
		private Animator animator;

		public void Init(Transform target)
		{
			follower.FollowTransform = target;
		}

		public void PlayLeftClickAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.LeftClickTrigger);
		}

		public void PlayDragAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.DragTrigger);
		}

		public void PlayDragTopDownAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.DragTopDownTrigger);
		}

		public void PlayDragDownTopAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.DragDownTopTrigger);
		}

		public void PlayDiagonalAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.DiagonalTrigger);
		}

		public void PlayRightButtonHoldAndDragAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.RightButtonHoldAndDrag);
		}

		public void PlayMouseWheelAnimation()
		{
			animator.SetTrigger(ProjectConstants.Animations.Wheel);
		}
	}
}
