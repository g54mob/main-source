using UnityEngine;

namespace TH20
{
	public class SMB_ElectricShock : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			CharacterAnimationController component = animator.gameObject.GetComponent<CharacterAnimationController>();
			if (component.Character.GetComponent<ElectricShockComponent>() == null)
			{
				component.Character.AddComponent<ElectricShockComponent>();
			}
		}
	}
}
