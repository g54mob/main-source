using System;
using FMOD.Studio;
using FMODUnity;
using Restory.Infrastructure.StateMachine;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class MainMenuBackgroundSoundsSwitcher : IInitializable, IDisposable
	{
		private readonly GlobalStateObserver globalStateObserver;

		private readonly GUI_FadeScreens fadeScreens;

		private readonly IAudioPlayerService audioPlayer;

		private readonly EventReference musicSoundEvent;

		private EventInstance musicSoundEventInstance;

		private MainMenuBackgroundSoundsSwitcher(GlobalStateObserver globalStateObserver, GUI_FadeScreens fadeScreens, IAudioPlayerService audioPlayer, EventReference musicSoundEvent)
		{
			this.fadeScreens = fadeScreens;
			this.musicSoundEvent = musicSoundEvent;
			this.audioPlayer = audioPlayer;
			this.globalStateObserver = globalStateObserver;
		}

		public void Initialize()
		{
			if (!TryToStartSoundsIfConditionsAllow())
			{
				globalStateObserver.AddSubscriber(this, ResolveGlobalStateChanged);
				fadeScreens.OnFadeOutEnded += ResolveFadeOutEnded;
			}
		}

		public void Dispose()
		{
			if (fadeScreens.MonoShellExists())
			{
				fadeScreens.OnFadeOutEnded -= ResolveFadeOutEnded;
			}
			globalStateObserver?.RemoveSubscriber(this);
			StopSounds();
		}

		private void ResolveGlobalStateChanged()
		{
			TryToStartSoundsIfConditionsAllow();
		}

		private void ResolveFadeOutEnded()
		{
			TryToStartSoundsIfConditionsAllow();
		}

		private bool CanStartSounds()
		{
			if (globalStateObserver.ActiveState is MainMenuState)
			{
				return !fadeScreens.IsAnyFadeScreenOn;
			}
			return false;
		}

		private bool TryToStartSoundsIfConditionsAllow()
		{
			if (CanStartSounds())
			{
				StartSounds();
				return true;
			}
			return false;
		}

		private void StartSounds()
		{
			if (!musicSoundEventInstance.isValid())
			{
				audioPlayer.TryToStartSoundEvent(musicSoundEvent, out musicSoundEventInstance);
			}
		}

		private void StopSounds()
		{
			if ((audioPlayer is MonoBehaviour monoBehaviour && monoBehaviour.MonoShellExists()) || audioPlayer != null)
			{
				audioPlayer.StopSoundEventInstance(musicSoundEventInstance);
				musicSoundEventInstance.clearHandle();
			}
		}
	}
}
