using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPEffects.CharacterData;
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
			private List<AnimationStep> clips;

			public List<AnimationStep> Clips
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class TrackList
		{
			public List<Track> Tracks;

			public Track this[int index]
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct StepComparer : IComparer<AnimationStep>
		{
			public int Compare(AnimationStep x, AnimationStep y)
			{
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
		}

		public static void EnsureNonOverlappingTimings(List<List<AnimationStep>> steps)
		{
		}

		public static void CreateStepsSorted(TrackList tracks, ref List<List<AnimationStep>> steps)
		{
		}

		public static float AdjustTimeForExtrapolation(AnimationStep step, float timeValue)
		{
			return 0f;
		}

		public static int FindCurrentlyActive(float timeValue, List<AnimationStep> steps)
		{
			return 0;
		}

		public static void Animate(CharData cData, TrackList tracks, ref List<List<AnimationStep>> dataSteps, Dictionary<AnimationStep, (CachedOffset inOffset, CachedOffset outOffset)> cachedOffsets, bool repeat, float duration, float passedTime, IAnimationContext context, ref CharDataModifiers modifiersStorage, ref CharDataModifiers modifiersStorage2, ref CharDataModifiers accModifier, ref CharDataModifiers current)
		{
		}
	}
}
