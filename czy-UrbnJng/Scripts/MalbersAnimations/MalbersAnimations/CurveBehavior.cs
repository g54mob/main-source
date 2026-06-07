using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MalbersAnimations
{
	public class CurveBehavior : StateMachineBehaviour
	{
		[Tooltip("ID of the Curve")]
		public int ID;

		[Tooltip("Curve to send to the Animator")]
		public AnimationCurve Value = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Tooltip("Enable or disable updating the animator parameter")]
		public bool driveAnimParameter = true;

		[Hide("driveAnimParameter", false)]
		[Tooltip("The name of the animator parameter to drive")]
		public string animatorParameterName;

		private List<IAnimatorCurve> curves;

		private bool hasICurves;

		public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
		{
			if (!hasICurves)
			{
				curves = animator.GetComponentsInChildren<IAnimatorCurve>().ToList();
				if (curves != null)
				{
					hasICurves = true;
				}
			}
		}

		public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			float time = stateInfo.normalizedTime % 1f;
			float value = Value.Evaluate(time);
			if (driveAnimParameter && !string.IsNullOrEmpty(animatorParameterName))
			{
				animator.SetFloat(animatorParameterName, value);
			}
			if (hasICurves)
			{
				for (int i = 0; i < curves.Count; i++)
				{
					curves[i].AnimatorCurve(ID, value);
				}
			}
		}
	}
}
