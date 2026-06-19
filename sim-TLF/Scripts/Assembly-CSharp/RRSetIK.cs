using UnityEngine;

public class RRSetIK : StateMachineBehaviour
{
	[SerializeField]
	private bool handIKIsEnabled;

	[SerializeField]
	private bool forwardLeanIsEnabled = true;

	private bool setOnEnter = true;

	private bool setOnExit;

	[SerializeField]
	private float stateChangeTime = 2f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (setOnEnter)
		{
			animator.gameObject.GetComponent<OnAnimatorIKRelay>().Saddle.SetHandIKPassEnabled(handIKIsEnabled, stateChangeTime);
			animator.gameObject.GetComponent<OnAnimatorIKRelay>().Saddle.SetChestForwardLeanEnabled(forwardLeanIsEnabled, stateChangeTime);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (setOnExit)
		{
			animator.gameObject.GetComponent<OnAnimatorIKRelay>().Saddle.SetHandIKPassEnabled(handIKIsEnabled, stateChangeTime);
			animator.gameObject.GetComponent<OnAnimatorIKRelay>().Saddle.SetChestForwardLeanEnabled(forwardLeanIsEnabled, stateChangeTime);
		}
	}
}
