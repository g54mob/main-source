using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class ModifierBehaviour : StateMachineBehaviour
	{
		public AnimalModifier EnterModifier;

		public AnimalModifier ExitModifier;

		public AnimalModifier OnTimeModifier;

		[Range(0f, 1f)]
		public float Time;

		private MAnimal animal;

		private bool sent;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animal = animator.GetComponent<MAnimal>();
			sent = false;
			EnterModifier.Modify(animal);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			ExitModifier.Modify(animal);
			if (!sent)
			{
				OnTimeModifier.Modify(animal);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!sent && stateInfo.normalizedTime >= Time)
			{
				OnTimeModifier.Modify(animal);
				sent = true;
			}
		}
	}
}
