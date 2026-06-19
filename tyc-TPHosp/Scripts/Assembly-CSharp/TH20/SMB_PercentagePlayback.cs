using UnityEngine;

namespace TH20
{
	internal class SMB_PercentagePlayback : StateMachineBehaviour
	{
		public string _percentageVariableName;

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateUpdate(animator, stateInfo, layerIndex);
			float normalizedTime = animator.GetFloat(_percentageVariableName);
			animator.Play(stateInfo.shortNameHash, layerIndex, normalizedTime);
		}
	}
}
