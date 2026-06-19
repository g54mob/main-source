using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;

namespace TMPEffects.TMPAnimations
{
	public class AnimationContext : IAnimationContext, IAnimationData, IAnimationFinished, IAnimationFinisher
	{
		private SegmentData segmentData;

		public Dictionary<int, bool> finishedDict;

		public IAnimatorContext AnimatorContext { get; set; }

		public SegmentData SegmentData
		{
			get
			{
				return default(SegmentData);
			}
			set
			{
			}
		}

		public object CustomData { get; set; }

		public bool Finished(int index)
		{
			return false;
		}

		public bool Finished(CharData cData)
		{
			return false;
		}

		public AnimationContext(IAnimatorContext animatorContext, CharDataModifiers modifiers, SegmentData segmentData, object customData)
		{
		}

		public void ResetFinishAnimation(int index)
		{
		}

		public void FinishAnimation(CharData cData)
		{
		}

		public void ResetFinishAnimation(CharData cData)
		{
		}

		public void ResetFinishAnimation()
		{
		}
	}
}
