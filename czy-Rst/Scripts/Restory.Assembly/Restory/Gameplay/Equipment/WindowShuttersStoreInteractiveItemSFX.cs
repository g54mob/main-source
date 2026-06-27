using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class WindowShuttersStoreInteractiveItemSFX : MonoBehaviour
	{
		[SerializeField]
		private WindowShuttersStoreInteractiveItem windowShutters;

		[SerializeField]
		private EventReference windowOpeningSoundLoop;

		[SerializeField]
		private EventReference windowOpeningStartSound;

		[SerializeField]
		private EventReference windowOpeningEndSound;

		[SerializeField]
		private EventReference windowClosingSoundLoop;

		[SerializeField]
		private EventReference windowClosingStartSound;

		[SerializeField]
		private EventReference windowClosingEndSound;

		[SerializeField]
		[ParamRef]
		private string windowOpennessParameter;

		private IAudioPlayerService audioPlayer;

		private EventInstance windowOpeningClosingSoundLoopInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			windowShutters.OnWindowOpenProgressChanged += ResolveWindowOpenProgressChanged;
			windowShutters.OnOpeningAnimationStarted += ResolveWindowOpeningAnimationStarted;
			windowShutters.OnOpeningAnimationEnded += ResolveWindowOpeningAnimationEnded;
			windowShutters.OnClosingAnimationStarted += ResolveWindowClosingAnimationStarted;
			windowShutters.OnClosingAnimationEnded += ResolveWindowClosingAnimationEnded;
		}

		private void OnDisable()
		{
			if (windowShutters.MonoShellExists())
			{
				windowShutters.OnWindowOpenProgressChanged -= ResolveWindowOpenProgressChanged;
				windowShutters.OnOpeningAnimationStarted -= ResolveWindowOpeningAnimationStarted;
				windowShutters.OnOpeningAnimationEnded -= ResolveWindowOpeningAnimationEnded;
				windowShutters.OnClosingAnimationStarted -= ResolveWindowClosingAnimationStarted;
				windowShutters.OnClosingAnimationEnded -= ResolveWindowClosingAnimationEnded;
			}
		}

		private void ResolveWindowOpeningAnimationStarted()
		{
			audioPlayer.StopSoundEventInstance(windowOpeningClosingSoundLoopInstance, allowFadeOut: false);
			audioPlayer.PlaySoundEventOneShot(windowOpeningStartSound, base.gameObject);
			audioPlayer.TryToStartSoundEvent(windowOpeningSoundLoop, base.gameObject, out windowOpeningClosingSoundLoopInstance);
		}

		private void ResolveWindowOpeningAnimationEnded()
		{
			audioPlayer.StopSoundEventInstance(windowOpeningClosingSoundLoopInstance, allowFadeOut: false);
			audioPlayer.PlaySoundEventOneShot(windowOpeningEndSound, base.gameObject);
		}

		private void ResolveWindowClosingAnimationStarted()
		{
			audioPlayer.StopSoundEventInstance(windowOpeningClosingSoundLoopInstance, allowFadeOut: false);
			audioPlayer.PlaySoundEventOneShot(windowClosingStartSound, base.gameObject);
			audioPlayer.TryToStartSoundEvent(windowClosingSoundLoop, base.gameObject, out windowOpeningClosingSoundLoopInstance);
		}

		private void ResolveWindowClosingAnimationEnded()
		{
			audioPlayer.StopSoundEventInstance(windowOpeningClosingSoundLoopInstance, allowFadeOut: false);
			audioPlayer.PlaySoundEventOneShot(windowClosingEndSound, base.gameObject);
		}

		private void ResolveWindowOpenProgressChanged()
		{
			audioPlayer.SetGlobalParameterValue(windowOpennessParameter, windowShutters.WindowOpenProgress);
		}
	}
}
