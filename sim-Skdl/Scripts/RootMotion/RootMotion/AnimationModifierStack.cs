using UnityEngine;

namespace RootMotion
{
	public class AnimationModifierStack : MonoBehaviour
	{
		public AnimationModifier[] modifiers;

		private Animator animator;

		private Baker baker;

		private void Start()
		{
		}

		private void OnBakerStartClip(AnimationClip clip, float normalizedTime)
		{
		}

		private void OnBakerUpdateClip(AnimationClip clip, float normalizedTime)
		{
		}

		private void LateUpdate()
		{
		}
	}
}
