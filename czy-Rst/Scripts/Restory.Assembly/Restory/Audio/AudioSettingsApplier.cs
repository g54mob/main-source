using System;
using System.Collections;
using Restory.Gameplay.GameSettings;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class AudioSettingsApplier : MonoBehaviour
	{
		private const float DelayBeforePlayingTestSound = 0.2f;

		private IAudioPlayerService audioService;

		private GameSettingsManager gameSettingsManager;

		private Coroutine musicTestSoundDelayCoroutine;

		private Coroutine sfxTestSoundDelayCoroutine;

		private Coroutine masterTestSoundDelayCoroutine;

		[Inject]
		public void Construct(GameSettingsManager gameSettingsManager)
		{
			this.gameSettingsManager = gameSettingsManager;
		}

		private void Start()
		{
			audioService = GetComponent<IAudioPlayerService>();
			if (!gameSettingsManager.IsInitialized)
			{
				gameSettingsManager.OnInitialized.AddListener(ResolveGameSettingsInitialized);
			}
			else
			{
				ResolveGameSettingsInitialized();
			}
		}

		private void OnDestroy()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnInitialized.RemoveListener(ResolveGameSettingsInitialized);
				gameSettingsManager.OnAudioSettingsChanged.RemoveListener(ResolveAudioSettingsChanged);
			}
		}

		private void ResolveGameSettingsInitialized()
		{
			audioService.SetBusVolume(AudioMixerBus.Master, gameSettingsManager.AudioSettings.Master.Volume);
			audioService.SetBusVolume(AudioMixerBus.SFX, gameSettingsManager.AudioSettings.SFX.Volume);
			audioService.SetBusVolume(AudioMixerBus.Music, gameSettingsManager.AudioSettings.Music.Volume);
			gameSettingsManager.OnInitialized.RemoveListener(ResolveGameSettingsInitialized);
			gameSettingsManager.OnAudioSettingsChanged.AddListener(ResolveAudioSettingsChanged);
		}

		private void ResolveAudioSettingsChanged(AudioFMODSettings.AudioTypeSettings newSettings)
		{
			audioService.SetBusVolume(newSettings.AudioBusType, newSettings.Volume);
			TryToPlaySoundAfterDelay(newSettings.AudioBusType);
		}

		private void TryToPlaySoundAfterDelay(AudioMixerBus busType)
		{
			switch (busType)
			{
			case AudioMixerBus.Master:
				RestartCoroutine(ref masterTestSoundDelayCoroutine, AudioMixerBus.Master);
				break;
			case AudioMixerBus.Music:
				RestartCoroutine(ref musicTestSoundDelayCoroutine, AudioMixerBus.Music);
				break;
			case AudioMixerBus.SFX:
				RestartCoroutine(ref sfxTestSoundDelayCoroutine, AudioMixerBus.SFX);
				break;
			default:
				throw new ArgumentOutOfRangeException("busType", busType, null);
			}
		}

		private void RestartCoroutine(ref Coroutine coroutine, AudioMixerBus bus)
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
				coroutine = null;
			}
			coroutine = StartCoroutine(TestSoundDelayCoroutine(bus));
		}

		private IEnumerator TestSoundDelayCoroutine(AudioMixerBus bus)
		{
			yield return new WaitForSecondsRealtime(0.2f);
			PlayTestSound(bus);
		}

		private void PlayTestSound(AudioMixerBus bus)
		{
			audioService.PlayTestSoundForBus(bus);
		}
	}
}
