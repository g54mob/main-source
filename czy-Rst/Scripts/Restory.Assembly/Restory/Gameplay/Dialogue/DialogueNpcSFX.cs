using FMOD.Studio;
using Restory.Audio;
using Restory.Data.NPCs;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueNpcSFX : MonoBehaviour
	{
		private IAudioPlayerService audioPlayer;

		private EventInstance npcSoundInstance;

		[Inject]
		public void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnDisable()
		{
			if (((audioPlayer is MonoBehaviour monoBehaviour && monoBehaviour.MonoShellExists()) || audioPlayer != null) && npcSoundInstance.isValid())
			{
				audioPlayer.StopSoundEventInstance(npcSoundInstance, allowFadeOut: false);
				npcSoundInstance.clearHandle();
			}
		}

		public void PlayNpcSound(NpcEmotionData emotionData)
		{
			StopCurrentNpcSound();
			audioPlayer.TryToStartSoundEvent(emotionData.Sound, base.gameObject, out npcSoundInstance);
		}

		public void StopCurrentNpcSound()
		{
			audioPlayer.StopSoundEventInstance(npcSoundInstance, allowFadeOut: false);
		}
	}
}
