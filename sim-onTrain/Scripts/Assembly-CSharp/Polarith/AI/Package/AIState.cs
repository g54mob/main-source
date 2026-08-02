using System.Collections.Generic;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/AI State")]
	public sealed class AIState : StateMachineBehaviour
	{
		[Tooltip("The labels correspond to the AIMBehaviour.Label. If a label is in this list, the corresponding behaviour will be activated OnStateEnter.")]
		public List<string> BehaviourLabel;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			AIMBehaviour[] components = animator.gameObject.GetComponents<AIMBehaviour>();
			foreach (AIMBehaviour aIMBehaviour in components)
			{
				if (BehaviourLabel.Contains(aIMBehaviour.Label))
				{
					aIMBehaviour.enabled = true;
				}
				else
				{
					aIMBehaviour.enabled = false;
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateExit(animator, stateInfo, layerIndex);
			animator.SetInteger("Change", 0);
		}
	}
}
