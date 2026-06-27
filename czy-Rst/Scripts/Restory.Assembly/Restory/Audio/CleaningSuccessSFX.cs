using FMODUnity;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class CleaningSuccessSFX : MonoBehaviour
	{
		[SerializeField]
		private EventReference singleBellSound;

		[SerializeField]
		private EventReference doubleBellSound;

		private IAudioPlayerService audioPlayer;

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
		}

		public void PlaySingleBellSound()
		{
			PlaySound(singleBellSound);
		}

		public void PlayDoubleBellSound()
		{
			PlaySound(doubleBellSound);
		}

		private void PlaySound(EventReference soundEvent)
		{
			if (base.isActiveAndEnabled && audioPlayer != null)
			{
				audioPlayer.PlaySoundEventOneShot(soundEvent);
			}
		}
	}
}
