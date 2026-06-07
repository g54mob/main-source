using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public abstract class StateOverrideAnimator : State
	{
		[SerializeField]
		protected AnimatorOverrideController m_Controller;

		public override RuntimeAnimatorController StateController => m_Controller;
	}
}
