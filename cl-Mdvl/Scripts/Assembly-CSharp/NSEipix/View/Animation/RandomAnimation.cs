using UnityEngine;

namespace NSEipix.View.Animation
{
	public class RandomAnimation : StateMachineBehaviour
	{
		[SerializeField]
		private int count = 1;

		public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
		{
			int value = Random.Range(1, count + 1);
			animator.SetInteger("random", value);
		}
	}
}
