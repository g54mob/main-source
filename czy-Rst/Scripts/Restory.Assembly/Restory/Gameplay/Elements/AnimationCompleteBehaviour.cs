using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class AnimationCompleteBehaviour : StateMachineBehaviour
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.transform.parent.gameObject.SendMessage("OnAnimationComplete", SendMessageOptions.DontRequireReceiver);
		}
	}
}
