using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class PersonalBoxAppearanceSFX : MonoBehaviour
	{
		[SerializeField]
		private PersonalBoxAppearanceController appearanceController;

		[SerializeField]
		private EventReference boxDropHitSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			appearanceController.OnAppearanceCompleted += ResolveAppearanceSequenceCompleted;
		}

		private void OnDisable()
		{
			if (appearanceController.MonoShellExists())
			{
				appearanceController.OnAppearanceCompleted -= ResolveAppearanceSequenceCompleted;
			}
		}

		private void ResolveAppearanceSequenceCompleted()
		{
			audioPlayer.PlaySoundEventOneShot(boxDropHitSound, base.gameObject);
		}
	}
}
