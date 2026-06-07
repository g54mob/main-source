using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public static class TimelineHelper
	{
		public class TimeRange
		{
			public List<GameEvent> gameEvents;

			public float startsAt;

			public float length;
		}

		private static bool _isDirty;

		private static List<TimeRange> _timeRangeData;

		public static event EventHandler TimelineDataChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void RegisterEventHandlers()
		{
		}

		public static void MarkTimelineAsDirty()
		{
		}

		public static void RefreshIfDirty()
		{
		}

		public static void RefreshTimeRangeData()
		{
		}

		public static List<TimelineRange3DUIView> RenderTimeRanges(Transform timelineElementsParent, Action<TimelineRange3DUIView, TimeRange, float> updateTransform, GameObject timelineRangePrefab, int timelineLengthHours, float timeStartOffset = 0f)
		{
			return null;
		}

		private static float ClampLength(float startTime, float maxTime, float unclampedLength)
		{
			return 0f;
		}

		public static void UpdateTimeRanges(List<TimelineRange3DUIView> timeRangeVisuals, Action<TimelineRange3DUIView, TimeRange, float> updateTransform, int timelineLengthHours, float timeStartOffset = 0f)
		{
		}
	}
}
