using FMODUnity;
using Restory.Gameplay.Elements;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class ToggleElementSFX : MonoBehaviour
	{
		[SerializeField]
		private EventReference activateSound;

		[SerializeField]
		private EventReference deactivateSound;

		[SerializeField]
		private EventReference stateToggleFailedSound;

		private IAudioPlayerService audioPlayer;

		private ToggleElement toggleElement;

		[Inject]
		public void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
			TryGetComponent<ToggleElement>(out toggleElement);
			if (base.isActiveAndEnabled)
			{
				Subscribe();
			}
		}

		private void OnEnable()
		{
			if (toggleElement != null)
			{
				Subscribe();
			}
		}

		private void OnDisable()
		{
			if (toggleElement != null)
			{
				Unsubscribe();
			}
		}

		private void Subscribe()
		{
			toggleElement.OnSwitched += ResolveElementSwitched;
		}

		private void Unsubscribe()
		{
			toggleElement.OnSwitched -= ResolveElementSwitched;
		}

		private void ResolveElementSwitched()
		{
			audioPlayer.PlaySoundEventOneShot(toggleElement.IsOn ? activateSound : deactivateSound);
		}

		private void ResolveInteractionFailed()
		{
			audioPlayer.PlaySoundEventOneShot(stateToggleFailedSound);
		}
	}
}
