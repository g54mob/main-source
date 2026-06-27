using System;
using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Restory.Audio
{
	public class BackgroundLoopingSoundsService : MonoBehaviour
	{
		[Serializable]
		public class Entry
		{
			[Serializable]
			public struct DefaultParameterValues
			{
				public string ParameterName;

				public float ParameterValue;
			}

			public Dictionary<string, PARAMETER_ID> Parameters = new Dictionary<string, PARAMETER_ID>();

			public Dictionary<PARAMETER_ID, Tween> ActiveParameterChangingTweens = new Dictionary<PARAMETER_ID, Tween>();

			[SerializeField]
			private BackgroundLoopingSoundType soundType;

			[SerializeField]
			private EventReference soundEvent;

			[SerializeField]
			private DefaultParameterValues[] defaultValuesForParameters = Array.Empty<DefaultParameterValues>();

			public BackgroundLoopingSoundType SoundType => soundType;

			public EventReference SoundEvent => soundEvent;

			public DefaultParameterValues[] DefaultValuesForParameters => defaultValuesForParameters;

			public EventInstance SoundEventInstance { get; set; }

			public bool IsCurrentlyActive { get; set; }
		}

		[SerializeField]
		private Entry[] entries = Array.Empty<Entry>();

		private IAudioPlayerService audioPlayer;

		private Tween cachedTween;

		private void Awake()
		{
			TryGetComponent<IAudioPlayerService>(out audioPlayer);
			CheckEntriesForUniqueness();
		}

		public void StartSound(BackgroundLoopingSoundType soundType)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry.SoundType != soundType)
				{
					continue;
				}
				if (entry.IsCurrentlyActive)
				{
					Debug.Log($"[{typeof(BackgroundLoopingSoundsService)}] was asked to start playing sound of type [{soundType}], but that sound is already active!");
					break;
				}
				audioPlayer.TryToStartSoundEvent(entry.SoundEvent, out var soundEventInstance);
				entry.SoundEventInstance = soundEventInstance;
				Entry.DefaultParameterValues[] defaultValuesForParameters = entry.DefaultValuesForParameters;
				for (int j = 0; j < defaultValuesForParameters.Length; j++)
				{
					Entry.DefaultParameterValues defaultParameterValues = defaultValuesForParameters[j];
					TryToAddNewParameterToEntry(entry, defaultParameterValues.ParameterName);
					audioPlayer.SetSoundEventInstanceParameterValue(soundEventInstance, entry.Parameters[defaultParameterValues.ParameterName], defaultParameterValues.ParameterValue);
				}
				entry.IsCurrentlyActive = true;
				break;
			}
		}

		public void StopSound(BackgroundLoopingSoundType soundType)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry.SoundType == soundType)
				{
					if (!entry.IsCurrentlyActive)
					{
						Debug.Log($"[{typeof(BackgroundLoopingSoundsService)}] was asked to stop sound of type [{soundType}], but that sound is not playing!");
						break;
					}
					audioPlayer.StopSoundEventInstance(entry.SoundEventInstance, allowFadeOut: false);
					entry.SoundEventInstance.clearHandle();
					entry.IsCurrentlyActive = false;
					break;
				}
			}
		}

		public bool TryToChangeSoundParameter(BackgroundLoopingSoundType soundType, string parameterName, float newParameterValue, float changeDuration = 0f)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry.SoundType == soundType)
				{
					if (!entry.IsCurrentlyActive)
					{
						Debug.Log($"[{typeof(BackgroundLoopingSoundsService)}] was asked to change parameter of a sound of type [{soundType}], but that sound is not playing!");
						return false;
					}
					TryToAddNewParameterToEntry(entry, parameterName);
					PARAMETER_ID pARAMETER_ID = entry.Parameters[parameterName];
					entry.SoundEventInstance.getParameterByID(pARAMETER_ID, out var value);
					if (Math.Abs(value - newParameterValue) <= float.Epsilon)
					{
						return true;
					}
					if (changeDuration <= 0f)
					{
						audioPlayer.SetSoundEventInstanceParameterValue(entry.SoundEventInstance, pARAMETER_ID, newParameterValue);
					}
					else
					{
						ChangeSoundParameterTweened(entry, pARAMETER_ID, value, newParameterValue, changeDuration);
					}
					return true;
				}
			}
			Debug.LogError($"[{typeof(BackgroundLoopingSoundsService)}] was asked to change parameter of a sound of type [{soundType}], but could not find that sound!");
			return false;
		}

		private void TryToAddNewParameterToEntry(Entry entry, string parameterName)
		{
			if (!entry.Parameters.ContainsKey(parameterName))
			{
				PARAMETER_ID soundInstanceParameterIdByName = audioPlayer.GetSoundInstanceParameterIdByName(entry.SoundEventInstance, parameterName);
				entry.Parameters.Add(parameterName, soundInstanceParameterIdByName);
			}
		}

		private void ChangeSoundParameterTweened(Entry entry, PARAMETER_ID parameterID, float startingValue, float newParameterValue, float changeDuration)
		{
			float minValue = ((startingValue < newParameterValue) ? startingValue : newParameterValue);
			float maxValue = ((startingValue > newParameterValue) ? startingValue : newParameterValue);
			if (entry.ActiveParameterChangingTweens.TryGetValue(parameterID, out cachedTween) && cachedTween.IsActive())
			{
				cachedTween.Kill();
			}
			cachedTween = DOTween.To(delegate
			{
				entry.SoundEventInstance.getParameterByID(parameterID, out var value);
				return value;
			}, delegate(float value)
			{
				audioPlayer.SetSoundEventInstanceParameterValue(entry.SoundEventInstance, parameterID, Mathf.Clamp(value, minValue, maxValue));
			}, newParameterValue, changeDuration).OnComplete(delegate
			{
				audioPlayer.SetSoundEventInstanceParameterValue(entry.SoundEventInstance, parameterID, newParameterValue);
			}).OnKill(delegate
			{
				entry.ActiveParameterChangingTweens.Remove(parameterID);
			});
			entry.ActiveParameterChangingTweens[parameterID] = cachedTween;
		}

		private void CheckEntriesForUniqueness()
		{
			for (int i = 0; i < entries.Length; i++)
			{
				for (int j = 0; j < entries.Length; j++)
				{
					if (i != j && entries[i].SoundType == entries[j].SoundType)
					{
						Debug.LogError($"[{typeof(BackgroundLoopingSoundsService)}] may work incorrectly if it has several entries with the same Sound Type!");
					}
				}
			}
		}
	}
}
