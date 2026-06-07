using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.IK
{
	public class IKBehavior : StateMachineBehaviour
	{
		private IIKSource source;

		public StringReference IKSet = new StringReference();

		public bool OnEnter = true;

		[Hide("OnEnter")]
		public bool enable = true;

		[Space]
		public bool OnExit;

		[Hide("OnExit")]
		public bool m_enable = true;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (source == null)
			{
				source = animator.GetComponent<IIKSource>();
			}
			if (OnEnter)
			{
				source?.Set_Enable(IKSet.Value, enable);
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (OnExit)
			{
				source?.Set_Enable(IKSet.Value, m_enable);
			}
		}
	}
}
