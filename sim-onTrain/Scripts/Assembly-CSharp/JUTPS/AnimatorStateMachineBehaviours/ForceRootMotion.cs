using JUTPS.CharacterBrain;
using UnityEngine;

namespace JUTPS.AnimatorStateMachineBehaviours
{
	public class ForceRootMotion : StateMachineBehaviour
	{
		private JUCharacterBrain Controller;

		public bool ForceRootMotionRotation;

		public bool DisableOnEndTransition = true;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller == null)
			{
				Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
			}
			if (Controller == null)
			{
				Debug.LogError("the use of the root motion was not possible, could not find a JU Controller");
			}
			else
			{
				base.OnStateEnter(animator, stateInfo, layerIndex);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller == null)
			{
				Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
			}
			if (Controller == null)
			{
				Debug.LogError("the use of the root motion was not possible, could not find a JU Controller");
			}
			else if ((double)Vector3.Dot(animator.transform.up, Vector3.up) < 0.8 && Vector3.Dot(animator.transform.up, Vector3.up) > -0.8f)
			{
				Controller.RootMotion = false;
				Controller.RootMotionRotation = false;
			}
			else
			{
				Controller.RootMotion = true;
				Controller.RootMotionRotation = (ForceRootMotionRotation ? true : false);
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (Controller == null)
			{
				Debug.LogError("the use of the root motion was not possible, could not find a JU Controller");
			}
			else if (DisableOnEndTransition)
			{
				Controller.RootMotion = false;
				Controller.RootMotionRotation = false;
			}
		}
	}
}
