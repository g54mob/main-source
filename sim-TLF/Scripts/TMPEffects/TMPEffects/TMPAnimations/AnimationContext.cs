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
				return segmentData;
			}
			set
			{
				segmentData = value;
				finishedDict = new Dictionary<int, bool>(segmentData.effectiveLength);
				for (int i = segmentData.firstAnimationIndex; i < segmentData.firstAnimationIndex + segmentData.effectiveLength; i++)
				{
					finishedDict.Add(i, value: false);
				}
			}
		}

		public object CustomData { get; set; }

		public bool Finished(int index)
		{
			if (!finishedDict.TryGetValue(index, out var value))
			{
				return false;
			}
			return value;
		}

		public bool Finished(CharData cData)
		{
			return finishedDict[cData.info.index];
		}

		public AnimationContext(IAnimatorContext animatorContext, CharDataModifiers modifiers, SegmentData segmentData, object customData)
		{
			CustomData = customData;
			AnimatorContext = animatorContext;
			SegmentData = segmentData;
		}

		public void ResetFinishAnimation(int index)
		{
			finishedDict[index] = false;
		}

		public void FinishAnimation(CharData cData)
		{
			finishedDict[cData.info.index] = true;
		}

		public void ResetFinishAnimation(CharData cData)
		{
			finishedDict[cData.info.index] = false;
		}

		public void ResetFinishAnimation()
		{
			foreach (int key in finishedDict.Keys)
			{
				finishedDict[key] = false;
			}
		}
	}
}
