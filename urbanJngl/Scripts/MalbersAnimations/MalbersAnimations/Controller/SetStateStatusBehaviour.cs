using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class SetStateStatusBehaviour : StateMachineBehaviour
	{
		private MAnimal animal;

		public IntReference StateEnterStatus = new IntReference();

		[Range(0f, 1f)]
		public float m_time = 0.8f;

		private bool isOn;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (animal == null)
			{
				animal = animator.FindComponent<MAnimal>();
			}
			isOn = false;
		}

		public override void OnStateMove(Animator animator, AnimatorStateInfo state, int layerIndex)
		{
			if ((bool)animal)
			{
				float normalizedTime = state.normalizedTime;
				if (!isOn && normalizedTime >= m_time)
				{
					isOn = true;
					animal.State_SetEnterStatus(StateEnterStatus);
				}
			}
		}
	}
}
