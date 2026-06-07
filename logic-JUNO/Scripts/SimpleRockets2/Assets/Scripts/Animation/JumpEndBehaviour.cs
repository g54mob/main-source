using UnityEngine;

namespace Assets.Scripts.Animation
{
	public class JumpEndBehaviour : StateMachineBehaviour
	{
		private int _hashEndingJump;

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetBool(_hashEndingJump, value: false);
		}

		private void Awake()
		{
			_hashEndingJump = Animator.StringToHash("EndingJump");
		}
	}
}
