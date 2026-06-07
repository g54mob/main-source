using UnityEngine;

public class LoopBlockerScript : StateMachineBehaviour
{
	[Tooltip("Set on true to block onStateEnter, false to open OnStateExit")]
	public bool BlockState = true;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (BlockState)
		{
			animator.SetInteger("LoopBlocker", 1);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!BlockState)
		{
			animator.SetInteger("LoopBlocker", 0);
		}
	}
}
