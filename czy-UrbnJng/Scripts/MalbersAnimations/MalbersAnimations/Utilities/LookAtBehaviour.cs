using UnityEngine;

namespace MalbersAnimations.Utilities
{
	public class LookAtBehaviour : StateMachineBehaviour
	{
		[Range(0f, 1f)]
		public float Time;

		[HideInInspector]
		public bool showTime;

		private ILookAtActivation lookat;

		public EnterExit when;

		public LookAtState OnEnter = LookAtState.Enable;

		private bool sent;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (lookat == null)
			{
				lookat = animator.FindInterface<ILookAtActivation>();
			}
			sent = false;
			if (when == EnterExit.OnEnter)
			{
				CheckLookAt(animator, layerIndex);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (when == EnterExit.OnTime && !sent && stateInfo.normalizedTime >= Time)
			{
				CheckLookAt(animator, layerIndex);
				sent = true;
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (when == EnterExit.OnExit)
			{
				CheckLookAt(animator, layerIndex);
			}
		}

		private void CheckLookAt(Animator animator, int layerIndex)
		{
			if (animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash != animator.GetNextAnimatorStateInfo(layerIndex).fullPathHash && lookat != null)
			{
				switch (OnEnter)
				{
				case LookAtState.Reset:
					lookat.ResetByPriority(layerIndex + 1);
					break;
				case LookAtState.Enable:
					lookat.EnableByPriority(layerIndex + 1);
					break;
				case LookAtState.Disable:
					lookat.DisableByPriority(layerIndex + 1);
					break;
				}
			}
		}
	}
}
