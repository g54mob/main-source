using System.Collections.Generic;
using UnityEngine;

namespace Restory.Audio
{
	public class SoundLoopEmittersService : MonoBehaviour
	{
		private List<SoundLoopEmitter> emitters = new List<SoundLoopEmitter>();

		private Coroutine playbackStartingCoroutine;

		private bool isPlaybackActive;

		public void Register(SoundLoopEmitter newEmitter)
		{
			if (!emitters.Contains(newEmitter))
			{
				if (isPlaybackActive && (newEmitter.IsCurrentlyPlaying || newEmitter.PlaybackControlType == SoundLoopEmitterPlaybackControlType.AlwaysPlaysWhenOn))
				{
					newEmitter.ForceStartPlayback();
				}
				emitters.Add(newEmitter);
			}
		}

		public void Unregister(SoundLoopEmitter emitter)
		{
			if (emitters.Contains(emitter))
			{
				emitters.Remove(emitter);
			}
		}

		public void StartEmittersPlayback()
		{
			if (isPlaybackActive)
			{
				return;
			}
			isPlaybackActive = true;
			foreach (SoundLoopEmitter emitter in emitters)
			{
				if (emitter.IsCurrentlyPlaying || emitter.PlaybackControlType == SoundLoopEmitterPlaybackControlType.AlwaysPlaysWhenOn)
				{
					emitter.ForceStartPlayback();
				}
			}
		}

		public void Clean()
		{
			isPlaybackActive = false;
			emitters.Clear();
		}
	}
}
