using UltimateReplay.Storage;
using UnityEngine;

namespace UltimateReplay.Core
{
	internal sealed class ReplaySequencer
	{
		private ReplayTarget target;

		private ReplaySnapshot current;

		private ReplaySnapshot last;

		private float playbackTime;

		public ReplayTarget Target
		{
			set
			{
				target = value;
			}
		}

		public float CurrentTime => playbackTime;

		public float CurrentTimeNormalized => MapScale(playbackTime, 0f, target.Duration, 0f, 1f);

		public ReplaySnapshot SeekPlayback(float offset, PlaybackOrigin origin, bool normalized)
		{
			if (!normalized)
			{
				switch (origin)
				{
				case PlaybackOrigin.Start:
					playbackTime = offset;
					break;
				case PlaybackOrigin.End:
					playbackTime = target.Duration - offset;
					break;
				case PlaybackOrigin.Current:
					playbackTime += offset;
					break;
				}
			}
			else
			{
				offset = Mathf.Clamp01(offset);
				switch (origin)
				{
				case PlaybackOrigin.Start:
					playbackTime = MapScale(offset, 0f, 1f, 0f, target.Duration);
					break;
				case PlaybackOrigin.End:
					playbackTime = MapScale(offset, 1f, 0f, 0f, target.Duration);
					break;
				case PlaybackOrigin.Current:
					playbackTime = MapScale(offset, 0f, 1f, playbackTime, target.Duration);
					break;
				}
			}
			playbackTime = Mathf.Clamp(playbackTime, 0f, target.Duration);
			current = target.RestoreSnapshot(playbackTime);
			if (current != last)
			{
				ReplayTime.Time = playbackTime;
				if (last != null && current != null)
				{
					if (last.TimeStamp <= current.TimeStamp)
					{
						ReplayTime.Delta = MapScale(playbackTime, last.TimeStamp, current.TimeStamp, 0f, 1f);
					}
					else
					{
						ReplayTime.Delta = 0f - MapScale(playbackTime, last.TimeStamp, current.TimeStamp, 1f, 0f);
					}
				}
			}
			last = current;
			return current;
		}

		public ReplaySequenceResult UpdatePlayback(out ReplaySnapshot frame, PlaybackEndBehaviour endBehaviour, bool fixedTime)
		{
			PlaybackDirection timeScaleDirection = ReplayTime.TimeScaleDirection;
			ReplaySequenceResult result = ReplaySequenceResult.SequenceIdle;
			if (last != null)
			{
				if (timeScaleDirection == PlaybackDirection.Forward)
				{
					ReplayTime.Delta = MapScale(playbackTime, last.TimeStamp, current.TimeStamp, 0f, 1f);
				}
				else
				{
					ReplayTime.Delta = 0f - MapScale(playbackTime, current.TimeStamp, last.TimeStamp, 0f, 1f);
				}
			}
			else if (current == null)
			{
				ReplayTime.Delta = 0f;
			}
			else
			{
				ReplayTime.Delta = MapScale(playbackTime, 0f, current.TimeStamp, 0f, 1f);
			}
			ReplayTime.Delta = Mathf.Clamp01(ReplayTime.Delta);
			float num = 0f;
			num = ((!fixedTime) ? (Time.deltaTime * Mathf.Abs(ReplayTime.TimeScale)) : (Time.fixedDeltaTime * ReplayTime.TimeScale));
			switch (timeScaleDirection)
			{
			case PlaybackDirection.Forward:
				playbackTime += num;
				break;
			case PlaybackDirection.Backward:
				playbackTime -= num;
				break;
			}
			switch (endBehaviour)
			{
			default:
				if (playbackTime >= target.Duration || playbackTime < 0f)
				{
					frame = null;
					return ReplaySequenceResult.SequenceEnd;
				}
				break;
			case PlaybackEndBehaviour.LoopPlayback:
				if (playbackTime >= target.Duration || playbackTime < 0f)
				{
					playbackTime = ((timeScaleDirection == PlaybackDirection.Forward) ? 0f : target.Duration);
				}
				break;
			case PlaybackEndBehaviour.StopPlayback:
				if (playbackTime >= target.Duration)
				{
					playbackTime = target.Duration;
				}
				else if (playbackTime < 0f)
				{
					playbackTime = 0f;
				}
				break;
			}
			ReplaySnapshot replaySnapshot = target.RestoreSnapshot(playbackTime);
			if (replaySnapshot != null)
			{
				if (current != replaySnapshot)
				{
					ReplayTime.Delta = 0f;
					result = ReplaySequenceResult.SequenceAdvance;
					last = current;
				}
				current = replaySnapshot;
			}
			frame = current;
			return result;
		}

		private void UpdateTime()
		{
			ReplayTime.Time = playbackTime;
		}

		private float ScaleTime(float value, float min, float max)
		{
			if (value < min)
			{
				return 0f;
			}
			if (value > max)
			{
				return 1f;
			}
			return (value - min) / (max - min);
		}

		private float MapScale(float value, float min, float max, float newMin, float newMax)
		{
			return newMin + (value - min) * (newMax - newMin) / (max - min);
		}
	}
}
