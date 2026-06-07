using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay
{
	public class ReplayAudio : ReplayBehaviour
	{
		public AudioSource observedAudioSource;

		public override void Awake()
		{
			if (observedAudioSource == null)
			{
				Debug.LogWarningFormat("No audio source for '{0}' component, '{1}'", GetType().Name, base.gameObject.name);
			}
			else
			{
				base.Awake();
			}
		}

		public void Play()
		{
			if (observedAudioSource != null)
			{
				observedAudioSource.Play();
				if (base.IsRecording)
				{
					ReplayRecordEvent(ReplayEvents.PlaySound);
				}
			}
		}

		public override void OnReplayEvent(ReplayEvent replayEvent)
		{
			ReplayEvents eventID = (ReplayEvents)replayEvent.eventID;
			if (eventID == ReplayEvents.PlaySound && base.PlaybackDirection != PlaybackDirection.Backward && observedAudioSource != null)
			{
				observedAudioSource.pitch = ReplayTime.TimeScale;
				observedAudioSource.Play();
			}
		}

		public override void OnReplayUpdate()
		{
			if (base.PlaybackDirection != PlaybackDirection.Backward && observedAudioSource != null && observedAudioSource.isPlaying)
			{
				observedAudioSource.pitch = ReplayTime.TimeScale;
			}
		}

		public override void OnReplayEnd()
		{
			if (observedAudioSource != null)
			{
				observedAudioSource.Stop();
			}
		}
	}
}
