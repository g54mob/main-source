using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Restory.Audio
{
	public class FmodAudioPlayerService : MonoBehaviour, IAudioPlayerService
	{
		private struct InstanceAndTimer
		{
			public EventInstance SoundInstance;

			public int TimerIndex;
		}

		private const string SCENE_VOLUME_PARAMETER_NAME = "SceneVolume";

		[SerializeField]
		private FmodAudioPlayerSettings settings;

		private readonly Dictionary<AudioMixerBus, Bus> buses = new Dictionary<AudioMixerBus, Bus>();

		private readonly List<EventInstance> pausedInstances = new List<EventInstance>();

		private readonly Dictionary<EventReference, InstanceAndTimer> active2dSounds = new Dictionary<EventReference, InstanceAndTimer>();

		private readonly List<float> active2dSoundsTimers = new List<float>();

		private float sceneVolume;

		private Coroutine active2dSoundsTimersUpdatingCoroutine;

		private void Awake()
		{
			buses[AudioMixerBus.Master] = RuntimeManager.GetBus("bus:/");
			buses[AudioMixerBus.Music] = RuntimeManager.GetBus("bus:/Music");
			buses[AudioMixerBus.SFX] = RuntimeManager.GetBus("bus:/Sounds");
		}

		private void OnEnable()
		{
			active2dSoundsTimersUpdatingCoroutine = StartCoroutine(Active2dSoundsTimersUpdatingCoroutine());
		}

		private void OnDisable()
		{
			if (active2dSoundsTimersUpdatingCoroutine != null)
			{
				StopCoroutine(active2dSoundsTimersUpdatingCoroutine);
				active2dSoundsTimersUpdatingCoroutine = null;
			}
		}

		private IEnumerator Active2dSoundsTimersUpdatingCoroutine()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(settings.Same2dSoundTimerUpdateStep);
				for (int i = 0; i < active2dSoundsTimers.Count; i++)
				{
					if (active2dSoundsTimers[i] > 0f)
					{
						active2dSoundsTimers[i] -= settings.Same2dSoundTimerUpdateStep;
					}
				}
			}
		}

		public void DetachSoundInstanceFromGameObject(EventInstance soundInstance)
		{
			if (soundInstance.isValid())
			{
				RuntimeManager.DetachInstanceFromGameObject(soundInstance);
			}
		}

		public void PauseAllSFX()
		{
			RuntimeManager.StudioSystem.getBankList(out var array);
			Bank[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Bank bank = array2[i];
				if (!bank.isValid())
				{
					continue;
				}
				bank.getPath(out var path);
				if (path == "bank:/" + settings.MusicBank)
				{
					continue;
				}
				bank.getEventList(out var array3);
				EventDescription[] array4 = array3;
				foreach (EventDescription eventDescription in array4)
				{
					eventDescription.getInstanceList(out var array5);
					EventInstance[] array6 = array5;
					for (int k = 0; k < array6.Length; k++)
					{
						EventInstance item = array6[k];
						if (!item.isValid())
						{
							continue;
						}
						item.getPlaybackState(out var state);
						if (state == PLAYBACK_STATE.STOPPED || state == PLAYBACK_STATE.STOPPING)
						{
							continue;
						}
						item.getPaused(out var paused);
						if (!paused)
						{
							item.setPaused(paused: true);
							if (!pausedInstances.Contains(item))
							{
								pausedInstances.Add(item);
							}
						}
					}
				}
			}
		}

		public void ResumeAllPausedSounds()
		{
			foreach (EventInstance pausedInstance in pausedInstances)
			{
				if (pausedInstance.isValid())
				{
					pausedInstance.setPaused(paused: false);
				}
			}
			pausedInstances.Clear();
		}

		public PARAMETER_ID GetSoundInstanceParameterIdByName(EventInstance soundEventInstance, string parameterName)
		{
			soundEventInstance.getDescription(out var description);
			description.getParameterDescriptionByName(parameterName, out var parameter);
			return parameter.id;
		}

		public float GetSoundEventInstanceParameterValue(EventInstance eventInstance, PARAMETER_ID parameterId)
		{
			eventInstance.getParameterByID(parameterId, out var value);
			return value;
		}

		public void SetSoundEventInstanceParameterValue(EventInstance eventInstance, PARAMETER_ID parameterId, float parameterValue)
		{
			eventInstance.setParameterByID(parameterId, parameterValue);
		}

		public void SetGlobalParameterValue(string parameterName, float value)
		{
			RuntimeManager.StudioSystem.setParameterByName(parameterName, value);
		}

		public void SetSceneVolume(float volume)
		{
			if (!Mathf.Approximately(volume, sceneVolume))
			{
				sceneVolume = volume;
				SetGlobalParameterValue("SceneVolume", sceneVolume);
			}
		}

		public void PlaySoundEventOneShot(EventReference soundEvent, GameObject soundSourceGameObject = null)
		{
			if (!soundEvent.IsNull && !(sceneVolume <= 0f))
			{
				RuntimeManager.GetEventDescription(soundEvent).is3D(out var is3D);
				if (!is3D)
				{
					TryToPlay2dSoundOneShot(soundEvent);
				}
				else if (soundSourceGameObject != null)
				{
					RuntimeManager.PlayOneShot(soundEvent, soundSourceGameObject.transform.position);
				}
				else
				{
					RuntimeManager.PlayOneShot(soundEvent);
				}
			}
		}

		public void PlaySoundEventOneShot(EventReference soundEvent, Vector3 soundSourcePosition)
		{
			if (!soundEvent.IsNull && !(sceneVolume <= 0f))
			{
				RuntimeManager.GetEventDescription(soundEvent).is3D(out var is3D);
				if (is3D)
				{
					RuntimeManager.PlayOneShot(soundEvent.Guid, soundSourcePosition);
				}
				else
				{
					TryToPlay2dSoundOneShot(soundEvent);
				}
			}
		}

		public bool TryToPlaySoundEventOneShotAttached(EventReference soundEvent, GameObject soundSourceGameObject)
		{
			if (soundEvent.IsNull || sceneVolume <= 0f)
			{
				return false;
			}
			if (soundSourceGameObject == null)
			{
				Debug.LogError($"IAF Warning: [{typeof(FmodAudioPlayerService)}] tried to play a sound attached to a game object, but the game object is NULL.");
				return false;
			}
			RuntimeManager.GetEventDescription(soundEvent).is3D(out var is3D);
			if (!is3D)
			{
				Debug.LogError($"IAF Warning: [{typeof(FmodAudioPlayerService)}] tried to play a sound attached to a game object, but the sound is not 3D.");
				return false;
			}
			RuntimeManager.PlayOneShotAttached(soundEvent.Guid, soundSourceGameObject);
			return true;
		}

		public bool TryToStartSoundEventAttached(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance)
		{
			return TryToCreateSoundEventAttached(soundEvent, soundSourceGameObject, out soundEventInstance);
		}

		public bool TryToCreateSoundEventAttached(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance, bool startSoundEventInstance = true)
		{
			if (soundEvent.IsNull)
			{
				soundEventInstance = default(EventInstance);
				return false;
			}
			if (soundSourceGameObject == null)
			{
				Debug.LogError($"IAF Warning: [{typeof(FmodAudioPlayerService)}] tried starting sound event attached to a game object, but the game object is NULL!");
				soundEventInstance = default(EventInstance);
				return false;
			}
			RuntimeManager.GetEventDescription(soundEvent).is3D(out var is3D);
			if (!is3D)
			{
				Debug.LogError($"IAF Error: [{typeof(FmodAudioPlayerService)}] tried to play a sound attached to a game object, but the sound is not 3D.");
				soundEventInstance = default(EventInstance);
				return false;
			}
			soundEventInstance = RuntimeManager.CreateInstance(soundEvent);
			RuntimeManager.AttachInstanceToGameObject(soundEventInstance, soundSourceGameObject);
			if (startSoundEventInstance)
			{
				soundEventInstance.start();
			}
			return true;
		}

		public bool TryToStartSoundEvent(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance)
		{
			if (soundEvent.IsNull)
			{
				soundEventInstance = default(EventInstance);
				return false;
			}
			RuntimeManager.GetEventDescription(soundEvent).is3D(out var is3D);
			soundEventInstance = RuntimeManager.CreateInstance(soundEvent);
			if (soundSourceGameObject != null && is3D)
			{
				soundEventInstance.set3DAttributes(soundSourceGameObject.transform.position.To3DAttributes());
			}
			soundEventInstance.start();
			return true;
		}

		public bool TryToStartSoundEvent(EventReference soundEvent, out EventInstance soundEventInstance)
		{
			if (soundEvent.IsNull)
			{
				soundEventInstance = default(EventInstance);
				soundEventInstance.release();
				return false;
			}
			soundEventInstance = RuntimeManager.CreateInstance(soundEvent);
			soundEventInstance.start();
			return true;
		}

		public void StopSoundEventInstance(EventInstance eventInstance, bool allowFadeOut = true)
		{
			if (eventInstance.isValid())
			{
				eventInstance.stop((!allowFadeOut) ? FMOD.Studio.STOP_MODE.IMMEDIATE : FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				eventInstance.release();
			}
		}

		public void RestartSoundEventInstance(EventInstance eventInstance)
		{
			if (eventInstance.isValid())
			{
				eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
				eventInstance.start();
			}
		}

		public float GetBusVolume(AudioMixerBus targetBus)
		{
			if (buses.TryGetValue(targetBus, out var value))
			{
				value.getVolume(out var volume);
				return volume;
			}
			return 0f;
		}

		public void SetBusVolume(AudioMixerBus targetBus, float volume)
		{
			if (buses.TryGetValue(targetBus, out var value))
			{
				value.setVolume(volume);
			}
			else
			{
				Debug.LogError(string.Format("Can't {0}. Reason: Unknown target bus {1}", "SetBusVolume", targetBus));
			}
		}

		public void PlayTestSoundForBus(AudioMixerBus audioMixerBus)
		{
			switch (audioMixerBus)
			{
			case AudioMixerBus.Master:
				if (!settings.TestSounds.TestSoundForMaster.IsNull)
				{
					RuntimeManager.PlayOneShot(settings.TestSounds.TestSoundForMaster);
				}
				else
				{
					Debug.Log("No test sound for master bus!");
				}
				break;
			case AudioMixerBus.Music:
				if (!settings.TestSounds.TestSoundForMusic.IsNull)
				{
					RuntimeManager.PlayOneShot(settings.TestSounds.TestSoundForMusic);
				}
				else
				{
					Debug.Log("No test sound for music bus!");
				}
				break;
			case AudioMixerBus.SFX:
				if (!settings.TestSounds.TestSoundForSFX.IsNull)
				{
					RuntimeManager.PlayOneShot(settings.TestSounds.TestSoundForSFX);
				}
				else
				{
					Debug.Log("No test sound for SFX bus!");
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("audioMixerBus", audioMixerBus, null);
			}
		}

		private void TryToPlay2dSoundOneShot(EventReference soundEvent)
		{
			if (active2dSounds.TryGetValue(soundEvent, out var value))
			{
				if (value.SoundInstance.isValid())
				{
					if (!(active2dSoundsTimers[value.TimerIndex] > 0f))
					{
						Restart2dSoundInDictionary(value);
					}
				}
				else
				{
					StartNewInstanceFor2dSoundInDictionary(soundEvent);
				}
			}
			else
			{
				AddNew2dSoundToDictionary(soundEvent);
			}
		}

		private void AddNew2dSoundToDictionary(EventReference soundEvent)
		{
			EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvent);
			soundInstance.start();
			soundInstance.release();
			active2dSoundsTimers.Add(settings.Same2dSoundTimeLimit);
			InstanceAndTimer value = new InstanceAndTimer
			{
				SoundInstance = soundInstance,
				TimerIndex = active2dSoundsTimers.Count - 1
			};
			active2dSounds.Add(soundEvent, value);
		}

		private void StartNewInstanceFor2dSoundInDictionary(EventReference soundEvent)
		{
			EventInstance soundInstance = RuntimeManager.CreateInstance(soundEvent);
			soundInstance.start();
			soundInstance.release();
			int timerIndex = active2dSounds[soundEvent].TimerIndex;
			active2dSoundsTimers[timerIndex] = settings.Same2dSoundTimeLimit;
			active2dSounds[soundEvent] = new InstanceAndTimer
			{
				SoundInstance = soundInstance,
				TimerIndex = timerIndex
			};
		}

		private void Restart2dSoundInDictionary(InstanceAndTimer entry)
		{
			entry.SoundInstance.start();
			active2dSoundsTimers[entry.TimerIndex] = settings.Same2dSoundTimeLimit;
		}
	}
}
