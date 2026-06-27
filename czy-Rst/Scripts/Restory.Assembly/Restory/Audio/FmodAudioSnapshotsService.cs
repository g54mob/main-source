using System;
using System.Collections.Generic;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using Helpers.Extensions;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class FmodAudioSnapshotsService : SerializedMonoBehaviour, IOverlayingAudioEffectsService
	{
		[Serializable]
		private class Entry
		{
			public EventReference SnapshotSoundEvent;

			public bool IsActive;

			[HideInInspector]
			public EventInstance SnapshotInstance;

			[HideInInspector]
			public PARAMETER_ID SnapshotIntensityParameterId;

			[HideInInspector]
			public Tween Tween;
		}

		[OdinSerialize]
		private Dictionary<OverlayingAudioEffectsType, Entry> entries = new Dictionary<OverlayingAudioEffectsType, Entry>();

		private IAudioPlayerService audioPlayer;

		private Entry cachedEntry;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnDisable()
		{
			if (audioPlayer == null)
			{
				return;
			}
			foreach (Entry value in entries.Values)
			{
				if (value != null)
				{
					if (value.Tween.IsActive())
					{
						value.Tween.Kill();
					}
					audioPlayer.StopSoundEventInstance(value.SnapshotInstance, allowFadeOut: false);
					value.SnapshotInstance.clearHandle();
					value.SnapshotIntensityParameterId = default(PARAMETER_ID);
					value.IsActive = false;
				}
			}
		}

		public void TurnOnEffect(OverlayingAudioEffectsType effect)
		{
			if (!entries.TryGetValue(effect, out cachedEntry))
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to turn on effect of type [{effect}], but it is not present in the [FmodAudioSnapshotsService]'s Entries!", base.gameObject);
				return;
			}
			if (cachedEntry.IsActive)
			{
				Debug.Log($"[FmodAudioSnapshotsService] tried to turn on an effect [{effect}], but it is already active.");
				return;
			}
			if (cachedEntry.Tween.IsActive())
			{
				cachedEntry.Tween.Kill();
			}
			audioPlayer.TryToStartSoundEvent(cachedEntry.SnapshotSoundEvent, out cachedEntry.SnapshotInstance);
			cachedEntry.IsActive = true;
		}

		public void TurnOffEffect(OverlayingAudioEffectsType effect)
		{
			if (!entries.TryGetValue(effect, out cachedEntry))
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to turn off effect of type [{effect}], but it is not present in the [FmodAudioSnapshotsService]'s Entries!", base.gameObject);
				return;
			}
			if (!cachedEntry.IsActive)
			{
				Debug.Log($"IAF Error: [FmodAudioSnapshotsService] tried to turn off an effect [{effect}], but it is not active!");
				return;
			}
			if (cachedEntry.Tween.IsActive())
			{
				cachedEntry.Tween.Kill();
			}
			audioPlayer.StopSoundEventInstance(cachedEntry.SnapshotInstance, allowFadeOut: false);
			cachedEntry.SnapshotInstance.clearHandle();
			cachedEntry.SnapshotIntensityParameterId = default(PARAMETER_ID);
			cachedEntry.IsActive = false;
		}

		public void TurnOnEffectAnimated(OverlayingAudioEffectsType effect, float duration)
		{
			if (!entries.TryGetValue(effect, out cachedEntry))
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to turn on effect of type [{effect}], but it is not present in the [FmodAudioSnapshotsService]'s Entries!", base.gameObject);
				return;
			}
			if (cachedEntry.IsActive)
			{
				Debug.Log($"[FmodAudioSnapshotsService] tried to turn on an effect [{effect}], but it is already active!");
				return;
			}
			cachedEntry.IsActive = true;
			ProcessTweenRequestForEntry(cachedEntry, 100f, duration);
		}

		public void TurnOffEffectAnimated(OverlayingAudioEffectsType effect, float duration)
		{
			if (!entries.TryGetValue(effect, out cachedEntry))
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to turn off effect of type [{effect}], but it is not present in the [FmodAudioSnapshotsService]'s Entries!", base.gameObject);
				return;
			}
			if (!cachedEntry.IsActive)
			{
				Debug.Log($"[FmodAudioSnapshotsService] tried to turn off an effect [{effect}], but it is not active.");
				return;
			}
			cachedEntry.IsActive = false;
			ProcessTweenRequestForEntry(cachedEntry, 0f, duration);
		}

		private void ProcessTweenRequestForEntry(Entry entry, float finalIntensityValue, float duration)
		{
			if (!entry.SnapshotInstance.isValid())
			{
				if (!TryToStartNewSnapshotEventInstance(entry) || !TryToSetUpParameterForSnapshotEventInstance(entry))
				{
					return;
				}
			}
			else if (entry.SnapshotIntensityParameterId.IsDefault())
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to tween a snapshot effect [{entry.SnapshotSoundEvent}]'s intensity to {finalIntensityValue}, but that FMOD event has no Intensity parameter. Falling back to just turning off the effect, without tweening.");
				audioPlayer.StopSoundEventInstance(cachedEntry.SnapshotInstance, allowFadeOut: false);
				cachedEntry.SnapshotInstance.clearHandle();
				return;
			}
			LaunchTween(entry, finalIntensityValue, duration);
		}

		private bool TryToStartNewSnapshotEventInstance(Entry entry)
		{
			if (audioPlayer.TryToStartSoundEvent(entry.SnapshotSoundEvent, out entry.SnapshotInstance))
			{
				return true;
			}
			Debug.LogWarning($"[FmodAudioSnapshotsService] could not start snapshot effect [{entry.SnapshotSoundEvent}]!", base.gameObject);
			return false;
		}

		private bool TryToSetUpParameterForSnapshotEventInstance(Entry entry)
		{
			entry.SnapshotIntensityParameterId = audioPlayer.GetSoundInstanceParameterIdByName(entry.SnapshotInstance, "Intensity");
			if (entry.SnapshotIntensityParameterId.IsDefault())
			{
				Debug.LogWarning($"[FmodAudioSnapshotsService] tried to turn on a snapshot effect [{entry.SnapshotSoundEvent}] and tween its intensity, but that FMOD event has no Intensity parameter. Falling back to just turning on the effect, without tweening.");
				if (entry.Tween.IsActive())
				{
					entry.Tween.Kill();
				}
				return false;
			}
			audioPlayer.SetSoundEventInstanceParameterValue(entry.SnapshotInstance, entry.SnapshotIntensityParameterId, 0f);
			return true;
		}

		private void LaunchTween(Entry entry, float finalIntensityValue, float duration)
		{
			if (entry.Tween.IsActive())
			{
				entry.Tween.Kill();
			}
			entry.Tween = DOTween.To(() => audioPlayer.GetSoundEventInstanceParameterValue(entry.SnapshotInstance, entry.SnapshotIntensityParameterId), delegate(float value)
			{
				audioPlayer.SetSoundEventInstanceParameterValue(entry.SnapshotInstance, entry.SnapshotIntensityParameterId, Mathf.Clamp(value, 0f, 100f));
			}, finalIntensityValue, duration).OnComplete(delegate
			{
				if (entry.SnapshotInstance.isValid())
				{
					if (finalIntensityValue == 0f)
					{
						audioPlayer.StopSoundEventInstance(entry.SnapshotInstance, allowFadeOut: false);
						entry.SnapshotInstance.clearHandle();
						entry.SnapshotIntensityParameterId = default(PARAMETER_ID);
					}
					else
					{
						audioPlayer.SetSoundEventInstanceParameterValue(entry.SnapshotInstance, entry.SnapshotIntensityParameterId, Mathf.Clamp(finalIntensityValue, 0f, 100f));
					}
				}
			}).SetUpdate(UpdateType.Normal, isIndependentUpdate: true);
		}
	}
}
