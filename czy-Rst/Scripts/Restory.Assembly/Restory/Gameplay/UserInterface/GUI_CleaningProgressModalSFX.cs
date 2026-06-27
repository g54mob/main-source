using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_CleaningProgressModalSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_CleaningProgressModal cleaningProgressModal;

		[SerializeField]
		private EventReference crossOutSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			cleaningProgressModal.OnNonFinalDirtSectionCrossOutAnimationStarted += ResolveNonFinalDirtSectionCrossOutAnimationStarted;
		}

		private void OnDisable()
		{
			if (cleaningProgressModal.MonoShellExists())
			{
				cleaningProgressModal.OnNonFinalDirtSectionCrossOutAnimationStarted -= ResolveNonFinalDirtSectionCrossOutAnimationStarted;
			}
		}

		private void ResolveNonFinalDirtSectionCrossOutAnimationStarted()
		{
			audioPlayer.PlaySoundEventOneShot(crossOutSound);
		}
	}
}
