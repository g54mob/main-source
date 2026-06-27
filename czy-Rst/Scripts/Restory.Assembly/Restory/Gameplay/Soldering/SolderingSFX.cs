using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderingSFX : MonoBehaviour
	{
		[SerializeField]
		private SolderingVfxController solderingVfxController;

		[SerializeField]
		private EventReference solderingNoiseLoop;

		[SerializeField]
		private EventReference solderingLineCompletionSound;

		private IAudioPlayerService audioPlayer;

		private SolderingService solderingService;

		private EventInstance solderingNoiseLoopInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer, SolderingService solderingService)
		{
			this.solderingService = solderingService;
			this.audioPlayer = audioPlayer;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if (solderingService != null)
			{
				Init();
			}
		}

		private void Init()
		{
			solderingVfxController.OnVfxStarted += ResolveVfxStarted;
			solderingVfxController.OnVfxStopped += ResolveVfxStopped;
			solderingVfxController.OnVfxCleared += ResolveVfxCleared;
			solderingService.OnTraceSuccessfullyResoldered += ResolveTraceResoldered;
		}

		private void OnDisable()
		{
			KillNoiseLoop();
			if ((bool)solderingVfxController)
			{
				solderingVfxController.OnVfxStarted -= ResolveVfxStarted;
				solderingVfxController.OnVfxStopped -= ResolveVfxStopped;
				solderingVfxController.OnVfxCleared -= ResolveVfxCleared;
			}
			if (solderingService != null)
			{
				solderingService.OnTraceSuccessfullyResoldered -= ResolveTraceResoldered;
			}
		}

		private void ResolveVfxStarted()
		{
			StartNoiseLoop();
		}

		private void ResolveVfxStopped()
		{
			KillNoiseLoop();
		}

		private void ResolveVfxCleared()
		{
			KillNoiseLoop();
		}

		private void StartNoiseLoop()
		{
			if (solderingNoiseLoopInstance.isValid())
			{
				solderingNoiseLoopInstance.getPlaybackState(out var state);
				if (state != PLAYBACK_STATE.PLAYING)
				{
					audioPlayer.RestartSoundEventInstance(solderingNoiseLoopInstance);
				}
			}
			else
			{
				audioPlayer.TryToStartSoundEvent(solderingNoiseLoop, out solderingNoiseLoopInstance);
			}
		}

		private void KillNoiseLoop()
		{
			audioPlayer.StopSoundEventInstance(solderingNoiseLoopInstance);
			solderingNoiseLoopInstance.clearHandle();
		}

		private void ResolveTraceResoldered()
		{
			audioPlayer.StopSoundEventInstance(solderingNoiseLoopInstance, allowFadeOut: false);
			solderingNoiseLoopInstance.clearHandle();
			audioPlayer.PlaySoundEventOneShot(solderingLineCompletionSound);
		}
	}
}
