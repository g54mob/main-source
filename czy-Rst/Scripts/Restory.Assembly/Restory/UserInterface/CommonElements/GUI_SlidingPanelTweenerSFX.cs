using System;
using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_SlidingPanelTweenerSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_SlidingPanelTweener slidingPanelTweener;

		[SerializeField]
		private EventReference showSound;

		[SerializeField]
		private EventReference hideSound;

		private IAudioPlayerService audioPlayer;

		private EventInstance slideSoundInstance;

		private SlidingPanelState previousState;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			slidingPanelTweener.OnTransitionStarted += ResolveTransitionStarted;
			slidingPanelTweener.OnTransitionComplete += ResolveTransitionCompleted;
		}

		private void OnDisable()
		{
			if (slidingPanelTweener.MonoShellExists())
			{
				slidingPanelTweener.OnTransitionStarted -= ResolveTransitionStarted;
				slidingPanelTweener.OnTransitionComplete -= ResolveTransitionCompleted;
			}
		}

		private void ResolveTransitionStarted()
		{
			audioPlayer.StopSoundEventInstance(slideSoundInstance, allowFadeOut: false);
			switch (slidingPanelTweener.State)
			{
			case SlidingPanelState.Hidden:
				audioPlayer.TryToStartSoundEvent(hideSound, out slideSoundInstance);
				break;
			case SlidingPanelState.Peeking:
				audioPlayer.TryToStartSoundEvent((previousState == SlidingPanelState.Open) ? hideSound : showSound, out slideSoundInstance);
				break;
			case SlidingPanelState.Open:
				audioPlayer.TryToStartSoundEvent(showSound, out slideSoundInstance);
				break;
			default:
				throw new NotImplementedException();
			case SlidingPanelState.None:
				break;
			}
			previousState = slidingPanelTweener.State;
		}

		private void ResolveTransitionCompleted()
		{
			audioPlayer.StopSoundEventInstance(slideSoundInstance);
		}
	}
}
