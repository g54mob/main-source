using System;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	[Serializable]
	public class AnimationStep
	{
		public enum ExtrapolationMode
		{
			None = 0,
			Hold = 1,
			Loop = 2,
			PingPong = 3,
			Continue = 4
		}

		public string name;

		public bool animate;

		[HideInInspector]
		public TMPBlendCurve entryCurve;

		public float entryDuration;

		[HideInInspector]
		public TMPBlendCurve exitCurve;

		public float exitDuration;

		public ExtrapolationMode preExtrapolation;

		public ExtrapolationMode postExtrapolation;

		public bool useWave;

		public Wave wave;

		public OffsetBundle waveOffset;

		public float startTime;

		public float duration;

		public bool useInitialModifiers;

		public EditorFriendlyCharDataModifiers initModifiers;

		public EditorFriendlyCharDataModifiers modifiers;

		public float EndTime => 0f;

		public AnimationStep()
		{
		}

		public AnimationStep(AnimationStep original)
		{
		}

		public float CalcWeight(float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			return 0f;
		}

		public static float CalcWeight(AnimationStep step, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			return 0f;
		}

		public static float CalcWeight(AnimationStep step, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData, GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset, float waveOffset = 0f)
		{
			return 0f;
		}

		public void LerpAnimationStepWeighted(float weight, CharData cData, IAnimatorContext context, CharDataModifiers storage, CharDataModifiers storage2, CharDataModifiers result)
		{
		}

		public static void LerpAnimationStepWeighted(AnimationStep step, float weight, CharData cData, IAnimatorContext context, CharDataModifiers storage, CharDataModifiers storage2, CharDataModifiers result)
		{
		}
	}
}
