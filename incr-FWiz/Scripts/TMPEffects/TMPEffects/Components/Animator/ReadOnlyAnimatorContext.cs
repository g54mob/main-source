using System;
using TMPEffects.CharacterData;
using TMPEffects.Modifiers;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	public class ReadOnlyAnimatorContext : IAnimatorContext, IAnimatorDataProvider, ICharacterTimingsProvider, IAnimatorTimingsProvider
	{
		private IAnimatorContext context;

		public CharDataModifiers Modifiers => null;

		public bool ScaleAnimations => false;

		public bool ScaleUniformly => false;

		public bool UseScaledTime => false;

		public TMPAnimator Animator => null;

		public float DeltaTime => 0f;

		public float PassedTime => 0f;

		public float StateTime(CharData cData)
		{
			return 0f;
		}

		public float VisibleTime(CharData cData)
		{
			return 0f;
		}

		public float StateTime(int index)
		{
			return 0f;
		}

		public float VisibleTime(int index)
		{
			return 0f;
		}

		public ReadOnlyAnimatorContext(IAnimatorContext context)
		{
		}

		public ReadOnlyAnimatorContext(TMPAnimator animator, bool scaleAnimations, bool useScaledTime, bool scaleUniformly, Func<int, float> getVisibleTime, Func<int, float> getStateTime)
		{
		}
	}
}
