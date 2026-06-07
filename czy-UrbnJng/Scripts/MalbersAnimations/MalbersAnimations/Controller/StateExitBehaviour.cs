using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class StateExitBehaviour : StateMachineBehaviour
	{
		private MAnimal animal;

		[Tooltip("State the Animal will exit to, when the time as passed. If null it will not force the next state")]
		public StateID ExitState;

		public IntReference StateExitStatus = new IntReference();

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
			if ((bool)animal)
			{
				animal.State_SetExitStatus(StateExitStatus);
				animal.ActiveState.IgnoreLowerStates = true;
			}
		}

		public override void OnStateMove(Animator animator, AnimatorStateInfo state, int layerIndex)
		{
			if ((bool)animal)
			{
				float normalizedTime = state.normalizedTime;
				if (!isOn && normalizedTime >= m_time)
				{
					isOn = true;
					animal.State_Allow_Exit((ExitState != null) ? ExitState.ID : (-1));
				}
			}
		}
	}
}
