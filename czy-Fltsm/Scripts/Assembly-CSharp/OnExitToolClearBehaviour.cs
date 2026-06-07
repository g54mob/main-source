using UnityEngine;

public class OnExitToolClearBehaviour : StateMachineBehaviour
{
	private AnimationTools _animationTools;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (_animationTools == null)
		{
			_animationTools = animator.GetComponent<AnimationTools>();
		}
		_animationTools.ClearAnimationTools();
	}
}
