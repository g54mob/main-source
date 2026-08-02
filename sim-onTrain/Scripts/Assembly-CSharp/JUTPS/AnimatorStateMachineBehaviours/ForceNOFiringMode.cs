using JUTPS.CharacterBrain;
using UnityEngine;

namespace JUTPS.AnimatorStateMachineBehaviours
{
	public class ForceNOFiringMode : StateMachineBehaviour
	{
		private JUCharacterBrain Controller;

		public bool BlockFireMode;

		public bool BlockFireModeIK = true;

		public bool EnableOnEndTransition;

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller == null)
			{
				Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
			}
			if (Controller == null)
			{
				Debug.LogError("could not find a JU Controller");
				return;
			}
			if (BlockFireMode)
			{
				Controller.FiringMode = false;
			}
			if (BlockFireModeIK)
			{
				Controller.FiringModeIK = false;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller == null)
			{
				Debug.LogError("could not find a JU Controller");
			}
			else if (EnableOnEndTransition)
			{
				if (BlockFireMode)
				{
					Controller.FiringMode = true;
				}
				if (BlockFireModeIK)
				{
					Controller.FiringModeIK = true;
				}
			}
		}
	}
}
