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

		public bool animate = true;

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

		public float EndTime => startTime + duration;

		public AnimationStep()
		{
		}

		public AnimationStep(AnimationStep original)
		{
			name = original.name;
			animate = original.animate;
			entryCurve = new TMPBlendCurve(original.entryCurve);
			entryDuration = original.entryDuration;
			exitCurve = new TMPBlendCurve(original.exitCurve);
			exitDuration = original.exitDuration;
			preExtrapolation = original.preExtrapolation;
			postExtrapolation = original.postExtrapolation;
			useWave = original.useWave;
			waveOffset = original.waveOffset;
			wave = new Wave(original.wave);
			startTime = original.startTime;
			duration = original.duration;
			useInitialModifiers = original.useInitialModifiers;
			initModifiers = new EditorFriendlyCharDataModifiers(original.initModifiers);
			modifiers = new EditorFriendlyCharDataModifiers(original.modifiers);
		}

		public float CalcWeight(float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			return CalcWeight(this, timeValue, duration, cData, context, segmentData);
		}

		public static float CalcWeight(AnimationStep step, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData)
		{
			float num = 1f;
			if (step.entryDuration > 0f)
			{
				num = step.entryCurve.EvaluateIn(timeValue, step.entryDuration, cData, context, segmentData);
			}
			if (step.exitDuration > 0f)
			{
				float preTime = duration - step.exitDuration;
				float num2 = step.exitCurve.EvaluateOut(timeValue, step.exitDuration, preTime, cData, context, segmentData);
				num *= num2;
			}
			if (step.useWave)
			{
				float offset = step.waveOffset.GetOffset(cData, context, segmentData);
				num *= step.wave.Evaluate(timeValue, offset).Value;
			}
			return num;
		}

		public static float CalcWeight(AnimationStep step, float timeValue, float duration, CharData cData, IAnimatorDataProvider context, ITMPSegmentData segmentData, GenericAnimationUtility.CachedOffset inOffset, GenericAnimationUtility.CachedOffset outOffset, float waveOffset = 0f)
		{
			float num = 1f;
			if (step.entryDuration > 0f)
			{
				num = step.entryCurve.EvaluateIn(timeValue, step.entryDuration, inOffset.minOffset, inOffset.maxOffset, inOffset.offset[cData]);
			}
			if (step.exitDuration > 0f)
			{
				float preTime = duration - step.exitDuration;
				float num2 = step.exitCurve.EvaluateOut(timeValue, step.exitDuration, preTime, outOffset.minOffset, outOffset.maxOffset, outOffset.offset[cData]);
				num *= num2;
			}
			if (step.useWave)
			{
				num *= step.wave.Evaluate(timeValue, waveOffset).Value;
			}
			return num;
		}

		public void LerpAnimationStepWeighted(float weight, CharData cData, IAnimatorContext context, CharDataModifiers storage, CharDataModifiers storage2, CharDataModifiers result)
		{
			LerpAnimationStepWeighted(this, weight, cData, context, storage, storage2, result);
		}

		public static void LerpAnimationStepWeighted(AnimationStep step, float weight, CharData cData, IAnimatorContext context, CharDataModifiers storage, CharDataModifiers storage2, CharDataModifiers result)
		{
			result.Reset();
			if (step.useInitialModifiers)
			{
				storage.Reset();
				storage2.Reset();
				step.initModifiers.ToCharDataModifiers(cData, context, storage);
				step.modifiers.ToCharDataModifiers(cData, context, storage2);
				CharDataModifiers.LerpUnclamped(cData, context, storage, storage2, weight, result);
			}
			else
			{
				storage.Reset();
				step.modifiers.ToCharDataModifiers(cData, context, storage);
				CharDataModifiers.LerpUnclamped(cData, storage, weight, result);
			}
		}
	}
}
