using System;
using FMOD.Studio;
using FMODUnity;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class SoundLoopEmitter : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private EventReference sound;

		[SerializeField]
		private bool objectIsStationary = true;

		[SerializeField]
		private SoundLoopEmitterPlaybackControlType playbackControl;

		private IAudioPlayerService audioPlayerService;

		private SoundLoopEmittersService soundLoopEmittersService;

		private bool isCurrentlyPlaying;

		private EventInstance soundInstance;

		public SoundLoopEmitterPlaybackControlType PlaybackControlType => playbackControl;

		public bool IsCurrentlyPlaying
		{
			get
			{
				return isCurrentlyPlaying;
			}
			set
			{
				if (value != isCurrentlyPlaying)
				{
					if (value)
					{
						StartSound();
					}
					else
					{
						KillSound();
					}
					isCurrentlyPlaying = value;
				}
			}
		}

		[Inject]
		public void Construct(IAudioPlayerService audioPlayerService, SoundLoopEmittersService soundLoopEmittersService)
		{
			this.audioPlayerService = audioPlayerService;
			this.soundLoopEmittersService = soundLoopEmittersService;
			if (base.isActiveAndEnabled)
			{
				soundLoopEmittersService.Register(this);
			}
		}

		private void OnEnable()
		{
			if (!(soundLoopEmittersService == null))
			{
				soundLoopEmittersService.Register(this);
			}
		}

		private void OnDisable()
		{
			if (soundLoopEmittersService != null)
			{
				soundLoopEmittersService.Unregister(this);
			}
			if (isCurrentlyPlaying && audioPlayerService != null)
			{
				KillSound();
			}
		}

		public void ForceStartPlayback()
		{
			isCurrentlyPlaying = true;
			StartSound();
		}

		private void StartSound()
		{
			if (objectIsStationary)
			{
				audioPlayerService.TryToStartSoundEvent(sound, base.gameObject, out soundInstance);
			}
			else
			{
				audioPlayerService.TryToStartSoundEventAttached(sound, base.gameObject, out soundInstance);
			}
		}

		private void KillSound()
		{
			audioPlayerService.StopSoundEventInstance(soundInstance);
			soundInstance.clearHandle();
		}

		public object CaptureState()
		{
			try
			{
				return new SoundLoopEmitterSaveData
				{
					IsCurrentlyPlaying = isCurrentlyPlaying
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				SoundLoopEmitterSaveData soundLoopEmitterSaveData = DataMigrationWizard.Migrate<SoundLoopEmitterSaveData>(state, base.gameObject);
				isCurrentlyPlaying = soundLoopEmitterSaveData.IsCurrentlyPlaying;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
