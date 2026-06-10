using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Extensions;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Sound
{
	public class AudioManager : MonoSingleton<AudioManager>, IObserver
	{
		public const string MasterBus = "bus:/";

		public const string MusicBus = "bus:/Music";

		public const string SfxBus = "bus:/SFX";

		public const string UIBus = "bus:/UI";

		public const string AmbienceBus = "bus:/Ambience";

		private readonly Dictionary<string, EventInstance> eventInstances = new Dictionary<string, EventInstance>();

		private void Start()
		{
			SetBusVolume("bus:/", MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.MasterVolume);
			SetBusVolume("bus:/Music", MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.MusicVolume);
			SetBusVolume("bus:/SFX", MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SfxVolume);
			SetBusVolume("bus:/UI", MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SfxVolume);
			SetBusVolume("bus:/Ambience", MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.AmbienceVolume);
		}

		public void PlayStinger(string soundID)
		{
			if (GetEventPath(soundID, out var sound))
			{
				try
				{
					RuntimeManager.GetEventDescription(sound).getLength(out var length);
					StartCoroutine(DuckMusicAndPlay(sound, length));
					return;
				}
				catch (Exception ex)
				{
					Log.Critical(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
				}
				StartCoroutine(DuckMusicAndPlay(sound, 1000));
			}
		}

		public void PlaySound(string soundID)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PlaySound ");
				messageBuilder.AppendFormatted(soundID);
			}
			Log.Debug(messageBuilder);
			if (GetEventPath(soundID, out var sound))
			{
				RuntimeManager.PlayOneShot(sound);
			}
		}

		public void PlaySound(string soundID, Dictionary<string, string> parameters)
		{
			UpdateEventInstance(soundID, parameters);
			GetEventInstance(soundID).start();
		}

		private IEnumerator DuckMusicAndPlay(string path, int msLength)
		{
			Bus musicBus = RuntimeManager.GetBus("bus:/Music");
			float num = 0.2f;
			float setVolume = num;
			musicBus.getVolume(out var endVolume);
			musicBus.setVolume(setVolume);
			RuntimeManager.PlayOneShot(path);
			float num2 = (float)msLength / 1000f / 2f;
			float volumeStep = (endVolume - num) / (num2 / Time.deltaTime);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("path:");
				messageBuilder.AppendFormatted(path);
				messageBuilder.AppendLiteral(" volumeStep: ");
				messageBuilder.AppendFormatted(volumeStep);
				messageBuilder.AppendLiteral(", seconds: ");
				messageBuilder.AppendFormatted(num2);
				messageBuilder.AppendLiteral(" endVolume: ");
				messageBuilder.AppendFormatted(endVolume);
			}
			Log.Info(messageBuilder);
			while (setVolume < endVolume)
			{
				setVolume += volumeStep;
				musicBus.setVolume(setVolume);
				yield return null;
			}
			musicBus.setVolume(endVolume);
		}

		public void PlaySound(string soundID, Dictionary<string, float> parameters)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PlaySound ");
				messageBuilder.AppendFormatted(soundID);
				messageBuilder.AppendLiteral(" AtPosition ");
				messageBuilder.AppendFormatted(parameters.Values.ToPrettyString());
			}
			Log.Debug(messageBuilder);
			UpdateEventInstance(soundID, parameters);
			GetEventInstance(soundID).start();
		}

		public void PlaySoundAtPosition(string soundID, Vector3 position)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PlaySound ");
				messageBuilder.AppendFormatted(soundID);
				messageBuilder.AppendLiteral(" AtPosition ");
				messageBuilder.AppendFormatted(position);
			}
			Log.Debug(messageBuilder);
			if (MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<UIController>.Instance.GameStarted)
			{
				string text = GetEvent(soundID);
				if (!string.IsNullOrEmpty(text) && !text.Equals("none"))
				{
					RuntimeManager.PlayOneShot(text, position);
				}
			}
		}

		public void PlaySoundAtPosition(string soundID, Vector3 position, Dictionary<string, string> parameters)
		{
			if (MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<UIController>.Instance.GameStarted)
			{
				UpdateEventInstance(soundID, position, parameters);
				GetEventInstance(soundID).start();
			}
		}

		public void PlaySoundAtPosition(string soundID, Vector3 position, Dictionary<string, float> parameters)
		{
			if (MonoSingleton<UIController>.IsInstantiated() && MonoSingleton<UIController>.Instance.GameStarted)
			{
				UpdateEventInstance(soundID, position, parameters);
				GetEventInstance(soundID).start();
			}
		}

		public void PlayLoopAtPosition(string soundID, Vector3 position)
		{
			EventInstance eventInstance = GetEventInstance(soundID);
			PlayLoopAtPosition(eventInstance, position);
		}

		public void PlayLoopAtPosition(EventInstance eventInstance, Vector3 position)
		{
			eventInstance.set3DAttributes(position.To3DAttributes());
			eventInstance.start();
		}

		public void StartEventInstance(string eventId)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("StartEventInstance ");
				messageBuilder.AppendFormatted(eventId);
			}
			Log.Debug(messageBuilder);
			GetEventInstance(eventId).start();
		}

		public void StopEventInstance(string eventId, FMOD.Studio.STOP_MODE mode)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("StopEventInstance ");
				messageBuilder.AppendFormatted(eventId);
			}
			Log.Debug(messageBuilder);
			GetEventInstance(eventId).stop(mode);
		}

		public void UpdateEventInstance(string eventId, string parameterName, string parameterLabel)
		{
			GetEventInstance(eventId).setParameterByNameWithLabel(parameterName, parameterLabel);
		}

		public void UpdateEventInstance(string eventId, string parameterName, float parameterValue)
		{
			GetEventInstance(eventId).setParameterByName(parameterName, parameterValue);
		}

		public void UpdateEventInstance(string eventId, Dictionary<string, string> parameters)
		{
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				UpdateEventInstance(eventId, parameter.Key, parameter.Value);
			}
		}

		public void UpdateEventInstance(string eventId, Dictionary<string, float> parameters)
		{
			foreach (KeyValuePair<string, float> parameter in parameters)
			{
				UpdateEventInstance(eventId, parameter.Key, parameter.Value);
			}
		}

		public void UpdateEventInstance(string eventId, Vector3 position, Dictionary<string, float> parameters)
		{
			UpdateEventInstance(eventId, parameters);
			GetEventInstance(eventId).set3DAttributes(position.To3DAttributes());
		}

		public void UpdateEventInstance(string eventId, Vector3 position, Dictionary<string, string> parameters)
		{
			UpdateEventInstance(eventId, parameters);
			GetEventInstance(eventId).set3DAttributes(position.To3DAttributes());
		}

		public void SetBusPaused(string bus, bool paused)
		{
			RuntimeManager.GetBus(bus).setPaused(paused);
		}

		public void SetBusVolume(string busName, float volume)
		{
			RuntimeManager.GetBus(busName).setVolume(volume);
		}

		public float GetBusVolume(string busName)
		{
			RuntimeManager.GetBus(busName).getVolume(out var volume);
			return volume;
		}

		public string GetEvent(string eventID)
		{
			return MonoRepository<SoundRepository, SoundEvent>.Instance.GetPathByID(eventID);
		}

		private EventInstance GetEventInstance(string eventID)
		{
			if (!eventInstances.ContainsKey(eventID))
			{
				eventInstances.Add(eventID, RuntimeManager.CreateInstance(GetEvent(eventID)));
			}
			return eventInstances[eventID];
		}

		private bool GetEventPath(string soundID, out string sound)
		{
			sound = string.Empty;
			if (string.IsNullOrEmpty(soundID) || soundID.Equals("none"))
			{
				return false;
			}
			sound = GetEvent(soundID);
			return !string.IsNullOrEmpty(sound);
		}
	}
}
