using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Restory.Data.Audio;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class MusicSwitcherService : SerializedMonoBehaviour
	{
		private static readonly string DebugLogPrefix = "[MusicSwitcherService]";

		[SerializeField]
		private MusicSlot[] musicSlotsSortedByPriority = Array.Empty<MusicSlot>();

		[OdinSerialize]
		private Dictionary<MusicSoundEvent, BackgroundLoopingSoundType> musicEventsToSoundTypes = new Dictionary<MusicSoundEvent, BackgroundLoopingSoundType>();

		private BackgroundLoopingSoundsService backgroundLoopingSoundsService;

		private MusicTrack currentlyPlayingTrack;

		private readonly Dictionary<string, MusicTrack> currentlyRequestedTracks = new Dictionary<string, MusicTrack>();

		private Coroutine updatePlayingTrackAfterOneFrameCoroutine;

		[Inject]
		private void Construct(BackgroundLoopingSoundsService backgroundLoopingSoundsService)
		{
			this.backgroundLoopingSoundsService = backgroundLoopingSoundsService;
		}

		private void OnDisable()
		{
			if (updatePlayingTrackAfterOneFrameCoroutine != null)
			{
				StopCoroutine(updatePlayingTrackAfterOneFrameCoroutine);
				updatePlayingTrackAfterOneFrameCoroutine = null;
			}
		}

		public void SetMusicTrackIntoSlot(MusicSlot musicSlot, MusicTrack track)
		{
			Debug.Log($"{DebugLogPrefix} trying to add track '{track}' to slot '{musicSlot}'.");
			if (!(musicSlot == null) && !(track == null) && (!currentlyRequestedTracks.TryGetValue(musicSlot.ID, out var value) || !(value.ID == track.ID)))
			{
				currentlyRequestedTracks[musicSlot.ID] = track;
				if (!(currentlyPlayingTrack != null) || !(currentlyPlayingTrack.ID == track.ID))
				{
					RequestDelayedPlayingTrackUpdate();
				}
			}
		}

		public void SetDefaultMusicTrackForSlot(MusicSlot musicSlot)
		{
			if (!(musicSlot == null))
			{
				if (musicSlot.DefaultMusicTrack == null)
				{
					Debug.LogWarning(DebugLogPrefix + " tried to set request for default music track " + $"in music slot '{musicSlot}', but that music slot has no default track set.");
				}
				else
				{
					SetMusicTrackIntoSlot(musicSlot, musicSlot.DefaultMusicTrack);
				}
			}
		}

		public void RemoveMusicTrackFromSlot(MusicSlot musicSlot, MusicTrack track)
		{
			Debug.Log($"{DebugLogPrefix} trying to remove track '{track}' from slot '{musicSlot}'.");
			if (currentlyRequestedTracks.TryGetValue(musicSlot.ID, out var value) && !(value.ID != track.ID))
			{
				currentlyRequestedTracks.Remove(musicSlot.ID);
				RequestDelayedPlayingTrackUpdate();
			}
		}

		public void ClearMusicSlot(MusicSlot musicSlot)
		{
			Debug.Log($"{DebugLogPrefix} trying to clear slot '{musicSlot}'.");
			if (currentlyRequestedTracks.TryGetValue(musicSlot.ID, out var _))
			{
				currentlyRequestedTracks.Remove(musicSlot.ID);
				RequestDelayedPlayingTrackUpdate();
			}
		}

		public void StopAllMusic()
		{
			MusicSlot[] array = musicSlotsSortedByPriority;
			foreach (MusicSlot musicSlot in array)
			{
				ClearMusicSlot(musicSlot);
			}
		}

		private void RequestDelayedPlayingTrackUpdate()
		{
			Debug.Log(DebugLogPrefix + " requesting update.");
			if (updatePlayingTrackAfterOneFrameCoroutine == null)
			{
				updatePlayingTrackAfterOneFrameCoroutine = StartCoroutine(UpdatePlayingTrackAfterOneFrameCoroutine());
			}
		}

		private IEnumerator UpdatePlayingTrackAfterOneFrameCoroutine()
		{
			yield return null;
			UpdatePlayingTrack();
			updatePlayingTrackAfterOneFrameCoroutine = null;
		}

		private void UpdatePlayingTrack()
		{
			MusicSlot[] array = musicSlotsSortedByPriority;
			foreach (MusicSlot musicSlot in array)
			{
				if (!(musicSlot == null) && currentlyRequestedTracks.TryGetValue(musicSlot.ID, out var value))
				{
					if (currentlyPlayingTrack != null && currentlyPlayingTrack.ID == value.ID)
					{
						Debug.Log($"{DebugLogPrefix} tried to change music to track '{value}', but it is already playing.");
						return;
					}
					SwitchPlayingMusicTrack(currentlyPlayingTrack, value);
					currentlyPlayingTrack = value;
					return;
				}
			}
			if (currentlyPlayingTrack != null)
			{
				StopSoundEventForTrack(currentlyPlayingTrack);
				currentlyPlayingTrack = null;
			}
			Debug.Log($"{DebugLogPrefix} updated - currently playing track is '{currentlyPlayingTrack}'.");
		}

		private void SwitchPlayingMusicTrack(MusicTrack oldTrack, MusicTrack newTrack)
		{
			Debug.Log($"{DebugLogPrefix} switching from track '{oldTrack}' to track '{newTrack}'.");
			if (oldTrack == null)
			{
				StartNewSoundEventForTrack(newTrack);
			}
			else if (oldTrack.MusicSoundEvent == newTrack.MusicSoundEvent)
			{
				SwitchParametersForTracksWithSameSoundEvent(oldTrack, newTrack);
			}
			else
			{
				SwitchTracksWithDifferentSoundEvents(oldTrack, newTrack);
			}
		}

		private void SwitchTracksWithDifferentSoundEvents(MusicTrack oldTrack, MusicTrack newTrack)
		{
			StopSoundEventForTrack(oldTrack);
			StartNewSoundEventForTrack(newTrack);
		}

		private void SwitchParametersForTracksWithSameSoundEvent(MusicTrack oldTrack, MusicTrack newTrack)
		{
			if (oldTrack.MusicSoundEvent == MusicSoundEvent.None || !musicEventsToSoundTypes.TryGetValue(oldTrack.MusicSoundEvent, out var value))
			{
				return;
			}
			List<string> list = newTrack.ParametersValues.Select((MusicTrack.ParameterValues newTrackParameterValues) => newTrackParameterValues.ParameterName).Intersect(oldTrack.ParametersValues.Select((MusicTrack.ParameterValues oldTrackParameterValues) => oldTrackParameterValues.ParameterName)).ToList();
			foreach (MusicTrack.ParameterValues parametersValue in oldTrack.ParametersValues)
			{
				if (!list.Contains(parametersValue.ParameterName))
				{
					backgroundLoopingSoundsService.TryToChangeSoundParameter(value, parametersValue.ParameterName, parametersValue.OffParameterValue, parametersValue.FadeOutDuration);
				}
			}
			foreach (MusicTrack.ParameterValues parametersValue2 in newTrack.ParametersValues)
			{
				backgroundLoopingSoundsService.TryToChangeSoundParameter(value, parametersValue2.ParameterName, parametersValue2.OnParameterValue, parametersValue2.FadeInDuration);
			}
		}

		private void StartNewSoundEventForTrack(MusicTrack musicTrack)
		{
			if (musicTrack.MusicSoundEvent == MusicSoundEvent.None || !musicEventsToSoundTypes.TryGetValue(musicTrack.MusicSoundEvent, out var value))
			{
				return;
			}
			backgroundLoopingSoundsService.StartSound(value);
			foreach (MusicTrack.ParameterValues parametersValue in musicTrack.ParametersValues)
			{
				backgroundLoopingSoundsService.TryToChangeSoundParameter(value, parametersValue.ParameterName, parametersValue.OnParameterValue, parametersValue.FadeInDuration);
			}
		}

		private void StopSoundEventForTrack(MusicTrack musicTrack)
		{
			if (musicTrack.MusicSoundEvent != MusicSoundEvent.None && musicEventsToSoundTypes.TryGetValue(musicTrack.MusicSoundEvent, out var value))
			{
				backgroundLoopingSoundsService.StopSound(value);
			}
		}

		[UsedImplicitly]
		private bool ValidatePrioritiesArray()
		{
			return musicSlotsSortedByPriority.Distinct().Count() == musicSlotsSortedByPriority.Length;
		}
	}
}
