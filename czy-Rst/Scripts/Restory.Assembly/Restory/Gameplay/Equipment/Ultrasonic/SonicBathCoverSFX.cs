using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public sealed class SonicBathCoverSFX : MonoBehaviour
	{
		[SerializeField]
		private SonicBathCover sonicBathCover;

		[SerializeField]
		private EventReference openingSound;

		[SerializeField]
		private EventReference closingSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			sonicBathCover.OnStartedOpeningAnimation += ResolveStartedOpening;
			sonicBathCover.OnStartedClosingAnimation += ResolveStartedClosing;
		}

		private void OnDisable()
		{
			if (sonicBathCover.MonoShellExists())
			{
				sonicBathCover.OnStartedOpeningAnimation -= ResolveStartedOpening;
				sonicBathCover.OnStartedClosingAnimation -= ResolveStartedClosing;
			}
		}

		private void ResolveStartedOpening()
		{
			audioPlayer.PlaySoundEventOneShot(openingSound, base.gameObject);
		}

		private void ResolveStartedClosing()
		{
			audioPlayer.PlaySoundEventOneShot(closingSound, base.gameObject);
		}
	}
}
