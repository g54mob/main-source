using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class AllowExitBehaviour : StateMachineBehaviour
	{
		private MAnimal animal;

		[Tooltip("State the Animal will exit to.\n If is left to null. it wont force a next state; AC will decide which will be the next State to Activate")]
		public StateID NextState;

		[Tooltip("The Animal will set an exit Status, so the Next State know what was the last animation played from the previous state")]
		public IntReference ExitStatus = new IntReference();

		[Tooltip("After this normalized time has elapsed, The State will be force to exit.")]
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
			if ((bool)animal && !isOn)
			{
				animal.ActiveState.IgnoreLowerStates = true;
				if (state.normalizedTime >= m_time)
				{
					isOn = true;
					int nextState = (NextState ? NextState.ID : (-1));
					animal.State_Allow_Exit(nextState, ExitStatus);
				}
			}
		}
	}
}
