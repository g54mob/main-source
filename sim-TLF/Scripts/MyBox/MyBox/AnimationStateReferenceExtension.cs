using UnityEngine;

namespace MyBox
{
	public static class AnimationStateReferenceExtension
	{
		public static void Play(this Animator animator, AnimationStateReference state)
		{
			if (state.Assigned)
			{
				animator.Play(state.StateName);
			}
		}

		public static void Play(this AnimationStateReference state)
		{
			if (state.Assigned)
			{
				state.Animator.Play(state.StateName);
			}
		}
	}
}
