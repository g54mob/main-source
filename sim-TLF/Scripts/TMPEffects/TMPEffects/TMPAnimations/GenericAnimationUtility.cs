using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	public static class GenericAnimationUtility
	{
		[Serializable]
		public class Track
		{
			[SerializeReference]
			private List<AnimationStep> clips = new List<AnimationStep>();

			public List<AnimationStep> Clips
			{
				get
				{
					return clips;
				}
				set
				{
					clips = value;
				}
			}
		}

		[Serializable]
		public class TrackList
		{
			public List<Track> Tracks = new List<Track>();

			public Track this[int index]
			{
				get
				{
					return Tracks[index];
				}
				set
				{
					Tracks[index] = value;
				}
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct StepComparer : IComparer<AnimationStep>
		{
			public int Compare(AnimationStep x, AnimationStep y)
			{
				if (x == null || y == null)
				{
					return 0;
				}
				if (x.startTime < y.startTime)
				{
					return -1;
				}
				if (x.startTime > y.startTime)
				{
					return 1;
				}
				if (x.EndTime < y.EndTime)
				{
					return -1;
				}
				if (x.EndTime > y.EndTime)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct CachedOffset
		{
			public Dictionary<CharData, float> offset;

			public float minOffset;

			public float maxOffset;
		}

		public static void EnsureNonOverlappingTimings_Editor(TrackList trackList)
		{
			for (int i = 0; i < trackList.Tracks.Count; i++)
			{
				Track track = trackList.Tracks[i];
				for (int j = 0; j < track.Clips.Count; j++)
				{
					AnimationStep animationStep = track.Clips[j];
					if (animationStep != null)
					{
						if (animationStep.duration < 0f)
						{
							animationStep.duration = 0f;
						}
						if (animationStep.startTime < 0f)
						{
							animationStep.startTime = 0f;
						}
					}
				}
				List<AnimationStep> list = new List<AnimationStep>(track.Clips);
				list.Sort(default(StepComparer));
				float num = -1f;
				float num2 = 0f;
				for (int k = 0; k < list.Count; k++)
				{
					AnimationStep animationStep2 = list[k];
					if (animationStep2 != null && animationStep2.duration != 0f)
					{
						if (animationStep2.startTime < num + num2)
						{
							float startTime = animationStep2.startTime;
							animationStep2.startTime = num + num2;
							animationStep2.duration = Mathf.Max(0f, animationStep2.duration - (animationStep2.startTime - startTime));
						}
						num = animationStep2.startTime;
						num2 = animationStep2.duration;
					}
				}
			}
		}

		public static void EnsureNonOverlappingTimings(List<List<AnimationStep>> steps)
		{
			for (int i = 0; i < steps.Count; i++)
			{
				List<AnimationStep> list = steps[i];
				for (int j = 0; j < list.Count; j++)
				{
					AnimationStep animationStep = list[j];
					if (animationStep != null)
					{
						if (animationStep.duration < 0f)
						{
							animationStep.duration = 0f;
						}
						if (animationStep.startTime < 0f)
						{
							animationStep.startTime = 0f;
						}
					}
				}
				List<AnimationStep> list2 = new List<AnimationStep>(list);
				list2.Sort(default(StepComparer));
				float num = -1f;
				float num2 = 0f;
				for (int k = 0; k < list2.Count; k++)
				{
					AnimationStep animationStep2 = list2[k];
					if (animationStep2 != null && animationStep2.duration != 0f)
					{
						if (animationStep2.startTime < num + num2)
						{
							float startTime = animationStep2.startTime;
							animationStep2.startTime = num + num2;
							animationStep2.duration = Mathf.Max(0f, animationStep2.duration - (animationStep2.startTime - startTime));
						}
						num = animationStep2.startTime;
						num2 = animationStep2.duration;
					}
				}
			}
		}

		public static void CreateStepsSorted(TrackList tracks, ref List<List<AnimationStep>> steps)
		{
			if (steps == null)
			{
				steps = new List<List<AnimationStep>>();
				for (int i = 0; i < tracks.Tracks.Count; i++)
				{
					List<AnimationStep> list = new List<AnimationStep>(tracks.Tracks[i].Clips);
					list.Sort(default(StepComparer));
					steps.Add(list);
				}
			}
		}

		public static float AdjustTimeForExtrapolation(AnimationStep step, float timeValue)
		{
			if (timeValue < 0f)
			{
				switch (step.preExtrapolation)
				{
				case AnimationStep.ExtrapolationMode.Hold:
					timeValue = 0f;
					break;
				case AnimationStep.ExtrapolationMode.Loop:
				{
					float num = (0f - timeValue) % step.duration;
					timeValue = step.duration - num;
					break;
				}
				case AnimationStep.ExtrapolationMode.PingPong:
				{
					float num = (0f - timeValue) % step.duration;
					timeValue = num;
					break;
				}
				}
			}
			if (timeValue > step.duration)
			{
				switch (step.postExtrapolation)
				{
				case AnimationStep.ExtrapolationMode.Hold:
					timeValue = step.duration;
					break;
				case AnimationStep.ExtrapolationMode.Loop:
				{
					float num2 = (timeValue - step.duration) % step.duration;
					timeValue = num2;
					break;
				}
				case AnimationStep.ExtrapolationMode.PingPong:
				{
					float num2 = (timeValue - step.duration) % step.duration;
					timeValue = step.duration - num2;
					break;
				}
				}
			}
			return timeValue;
		}

		public static int FindCurrentlyActive(float timeValue, List<AnimationStep> steps)
		{
			if (steps == null || steps.Count == 0)
			{
				return -1;
			}
			for (int i = 0; i < steps.Count; i++)
			{
				AnimationStep animationStep = steps[i];
				if (animationStep == null)
				{
					continue;
				}
				if (animationStep.startTime < timeValue && animationStep.EndTime > timeValue)
				{
					return i;
				}
				if (!(animationStep.startTime > timeValue))
				{
					continue;
				}
				if (i == 0)
				{
					if (animationStep.preExtrapolation != AnimationStep.ExtrapolationMode.None)
					{
						return i;
					}
					return -1;
				}
				if (steps[i - 1].postExtrapolation != AnimationStep.ExtrapolationMode.None)
				{
					return i - 1;
				}
				if (animationStep.preExtrapolation != AnimationStep.ExtrapolationMode.None)
				{
					return i;
				}
				return -1;
			}
			if (steps[steps.Count - 1].postExtrapolation != AnimationStep.ExtrapolationMode.None)
			{
				return steps.Count - 1;
			}
			return -1;
		}

		public static void Animate(CharData cData, TrackList tracks, ref List<List<AnimationStep>> dataSteps, Dictionary<AnimationStep, (CachedOffset inOffset, CachedOffset outOffset)> cachedOffsets, bool repeat, float duration, float passedTime, IAnimationContext context, ref CharDataModifiers modifiersStorage, ref CharDataModifiers modifiersStorage2, ref CharDataModifiers accModifier, ref CharDataModifiers current)
		{
			if (dataSteps == null)
			{
				CreateStepsSorted(tracks, ref dataSteps);
			}
			IAnimatorContext animatorContext = context.AnimatorContext;
			List<List<AnimationStep>> obj = dataSteps;
			if (modifiersStorage == null)
			{
				modifiersStorage = new CharDataModifiers();
			}
			if (modifiersStorage2 == null)
			{
				modifiersStorage2 = new CharDataModifiers();
			}
			if (accModifier == null)
			{
				accModifier = new CharDataModifiers();
			}
			if (current == null)
			{
				current = new CharDataModifiers();
			}
			float num = (repeat ? (passedTime % duration) : passedTime);
			accModifier.Reset();
			foreach (List<AnimationStep> item in obj)
			{
				int num2 = FindCurrentlyActive(num, item);
				if (num2 == -1)
				{
					continue;
				}
				AnimationStep animationStep = item[num2];
				if (animationStep.animate)
				{
					float timeValue = num - animationStep.startTime;
					timeValue = AdjustTimeForExtrapolation(animationStep, timeValue);
					if (!cachedOffsets.TryGetValue(animationStep, out (CachedOffset, CachedOffset) value))
					{
						animationStep.entryCurve.provider.GetMinMaxOffset(out var min, out var max, context.SegmentData, context.AnimatorContext);
						animationStep.exitCurve.provider.GetMinMaxOffset(out var min2, out var max2, context.SegmentData, context.AnimatorContext);
						value = (cachedOffsets[animationStep] = (new CachedOffset
						{
							minOffset = min,
							maxOffset = max,
							offset = new Dictionary<CharData, float>()
						}, new CachedOffset
						{
							minOffset = min2,
							maxOffset = max2,
							offset = new Dictionary<CharData, float>()
						}));
					}
					if (!value.Item1.offset.TryGetValue(cData, out var value2))
					{
						value2 = animationStep.entryCurve.provider.GetOffset(cData, context.SegmentData, context.AnimatorContext);
						value.Item1.offset[cData] = value2;
					}
					if (!value.Item2.offset.TryGetValue(cData, out var value3))
					{
						value3 = animationStep.entryCurve.provider.GetOffset(cData, context.SegmentData, context.AnimatorContext);
						value.Item2.offset[cData] = value3;
					}
					float weight = AnimationStep.CalcWeight(animationStep, timeValue, animationStep.duration, cData, animatorContext, context.SegmentData, value.Item1, value.Item2);
					AnimationStep.LerpAnimationStepWeighted(animationStep, weight, cData, animatorContext, modifiersStorage, modifiersStorage2, current);
					accModifier.MeshModifiers.Combine(current.MeshModifiers);
					accModifier.CharacterModifiers.Combine(current.CharacterModifiers);
				}
			}
			cData.MeshModifiers.Combine(accModifier.MeshModifiers);
			cData.CharacterModifiers.Combine(accModifier.CharacterModifiers);
		}
	}
}
