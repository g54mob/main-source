using UnityEngine;

namespace Assets.Scripts.Animation
{
	public class MidAirBehaviour : StateMachineBehaviour
	{
		private int _hashEndingJump;

		private int _hashInMidAir;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetBool(_hashInMidAir, value: true);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetBool(_hashInMidAir, value: false);
			animator.SetBool(_hashEndingJump, value: true);
		}

		private void Awake()
		{
			_hashEndingJump = Animator.StringToHash("EndingJump");
			_hashInMidAir = Animator.StringToHash("InMidAir");
		}
	}
}
