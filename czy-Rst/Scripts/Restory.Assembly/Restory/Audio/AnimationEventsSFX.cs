using System;
using FMOD.Studio;
using FMODUnity;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class AnimationEventsSFX : MonoBehaviour
	{
		[Serializable]
		private struct SoundEntry
		{
			public EventReference sound;

			public int animationEventIntParameter;
		}

		[SerializeField]
		private SoundEntry[] soundEntries;

		private IAudioPlayerService audioPlayer;

		private EventInstance cachedSoundInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		[UsedImplicitly]
		public void AnimationEvent_PlaySound(AnimationEvent animationEvent)
		{
			if (audioPlayer == null)
			{
				return;
			}
			bool flag = false;
			SoundEntry[] array = soundEntries;
			for (int i = 0; i < array.Length; i++)
			{
				SoundEntry soundEntry = array[i];
				if (animationEvent.intParameter == soundEntry.animationEventIntParameter)
				{
					if (string.IsNullOrEmpty(animationEvent.stringParameter))
					{
						audioPlayer.PlaySoundEventOneShot(soundEntry.sound, base.gameObject);
					}
					else
					{
						audioPlayer.TryToStartSoundEvent(soundEntry.sound, out cachedSoundInstance);
						PARAMETER_ID soundInstanceParameterIdByName = audioPlayer.GetSoundInstanceParameterIdByName(cachedSoundInstance, animationEvent.stringParameter);
						audioPlayer.SetSoundEventInstanceParameterValue(cachedSoundInstance, soundInstanceParameterIdByName, animationEvent.floatParameter);
						cachedSoundInstance.release();
						cachedSoundInstance.clearHandle();
					}
					flag = true;
				}
			}
			if (!flag)
			{
				Debug.LogError($"IAF Warning: [{this}] at [{base.gameObject}] could not find any sound with index {animationEvent.intParameter} (set in the animation event) in the 'Sound Entries' list!", base.gameObject);
			}
		}
	}
}
