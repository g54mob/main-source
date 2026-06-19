using System;
using TMPEffects.CharacterData;
using TMPEffects.Modifiers;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	public class ReadOnlyAnimatorContext : IAnimatorContext, IAnimatorDataProvider, ICharacterTimingsProvider, IAnimatorTimingsProvider
	{
		private IAnimatorContext context;

		public CharDataModifiers Modifiers => context.Modifiers;

		public bool ScaleAnimations => context.ScaleAnimations;

		public bool ScaleUniformly => context.ScaleUniformly;

		public bool UseScaledTime => context.UseScaledTime;

		public TMPAnimator Animator => context.Animator;

		public float DeltaTime => context.DeltaTime;

		public float PassedTime => context.PassedTime;

		public float StateTime(CharData cData)
		{
			return context.StateTime(cData);
		}

		public float VisibleTime(CharData cData)
		{
			return context.VisibleTime(cData);
		}

		public float StateTime(int index)
		{
			return context.StateTime(index);
		}

		public float VisibleTime(int index)
		{
			return context.VisibleTime(index);
		}

		public ReadOnlyAnimatorContext(IAnimatorContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			this.context = context;
		}

		public ReadOnlyAnimatorContext(TMPAnimator animator, bool scaleAnimations, bool useScaledTime, bool scaleUniformly, Func<int, float> getVisibleTime, Func<int, float> getStateTime)
			: this(new AnimatorContext(animator, scaleAnimations, useScaledTime, scaleUniformly, getVisibleTime, getStateTime))
		{
		}
	}
}
