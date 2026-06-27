using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class DemoSimpleDialogueVoicesSFX : MonoBehaviour
	{
		[SerializeField]
		private EventReference oldManShortSound;

		[SerializeField]
		private EventReference oldManMediumSound;

		[SerializeField]
		private EventReference oldManLongSpacedSound;

		[SerializeField]
		private EventReference oldManLongTightSound;

		[SerializeField]
		private EventReference policemanShortSound;

		[SerializeField]
		private EventReference policemanAhaSound;

		[SerializeField]
		private EventReference policemanMediumSound;

		[SerializeField]
		private EventReference policemanLongSound;

		private IAudioPlayerService audioPlayer;

		private EventInstance soundInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
			KillSound();
		}

		public void PlayOldManShortSound()
		{
			PlaySound(oldManShortSound);
		}

		public void PlayOldManMediumSound()
		{
			PlaySound(oldManMediumSound);
		}

		public void PlayOldManLongSpacedSound()
		{
			PlaySound(oldManLongSpacedSound);
		}

		public void PlayOldManLongTightSound()
		{
			PlaySound(oldManLongTightSound);
		}

		public void PlayPolicemanShortSound()
		{
			PlaySound(policemanShortSound);
		}

		public void PlayPolicemanAhaSound()
		{
			PlaySound(policemanAhaSound);
		}

		public void PlayPolicemanMediumSound()
		{
			PlaySound(policemanMediumSound);
		}

		public void PlayPolicemanLongSound()
		{
			PlaySound(policemanLongSound);
		}

		public void StopSound()
		{
			KillSound();
		}

		public void PlaySound(EventReference soundEvent)
		{
			if (base.isActiveAndEnabled && audioPlayer != null)
			{
				audioPlayer.StopSoundEventInstance(soundInstance);
				audioPlayer.TryToStartSoundEvent(soundEvent, out soundInstance);
			}
		}

		private void KillSound()
		{
			audioPlayer?.StopSoundEventInstance(soundInstance, allowFadeOut: false);
			soundInstance.clearHandle();
		}
	}
}
