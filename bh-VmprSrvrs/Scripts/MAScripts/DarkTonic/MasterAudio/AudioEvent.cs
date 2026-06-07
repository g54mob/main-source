using System;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class AudioEvent
	{
		public enum TargetVolumeMode
		{
			UseSliderValue = 0,
			UseSpecificValue = 1
		}

		[Serializable]
		public class MA_SnapshotInfo
		{
			public AudioMixerSnapshot snapshot;

			public float weight;

			public MA_SnapshotInfo(AudioMixerSnapshot snap, float wt)
			{
			}
		}

		public string actionName;

		public bool isExpanded;

		public string soundType;

		public bool allPlaylistControllersForGroupCmd;

		public bool allSoundTypesForGroupCmd;

		public bool allSoundTypesForBusCmd;

		public float volume;

		public bool useFixedPitch;

		public float pitch;

		public EventSounds.GlidePitchType glidePitchType;

		public float targetGlidePitch;

		public float pitchGlideTime;

		public float delaySound;

		public MasterAudio.EventSoundFunctionType currentSoundFunctionType;

		public MasterAudio.PlaylistCommand currentPlaylistCommand;

		public MasterAudio.SoundGroupCommand currentSoundGroupCommand;

		public MasterAudio.BusCommand currentBusCommand;

		public MasterAudio.CustomEventCommand currentCustomEventCommand;

		public MasterAudio.GlobalCommand currentGlobalCommand;

		public MasterAudio.UnityMixerCommand currentMixerCommand;

		public AudioMixerSnapshot snapshotToTransitionTo;

		public float snapshotTransitionTime;

		public List<MA_SnapshotInfo> snapshotsToBlend;

		public MasterAudio.PersistentSettingsCommand currentPersistentSettingsCommand;

		public string busName;

		public string playlistName;

		public string playlistControllerName;

		public bool startPlaylist;

		public float fadeVolume;

		public float fadeTime;

		public float minAge;

		public bool stopAfterFade;

		public bool restoreVolumeAfterFade;

		public TargetVolumeMode targetVolMode;

		public string clipName;

		public EventSounds.VariationType variationType;

		public string variationName;

		public float colliderMaxDistance;

		public bool showSphereGizmo;

		public string theCustomEventName;

		public bool IsFadeCommand => false;
	}
}
