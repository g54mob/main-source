using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine.Audio;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RadioConfig
	{
		public AudioMixerGroup LevelMusicAudioMixerGroup;

		public AudioMixerGroup PreviewMusicAudioMixerGroup;

		public AudioMixerGroup SubMasterAudioMixerGroup;

		public AudioMixerGroup DJAudioMixerGroup;

		public float PauseBetweenSongs = 2f;

		public float VolumeMultiplierDuringDJQuote = 0.4f;

		public float VolumeMultiplierDuringTannoyAnnouncement = 0.8f;

		public float VolumeMultiplierDuringAwardCeremony;

		public float VolumeMultiplierDuringNotificationAudioExclusiveMode;

		public float VolumeChangeStep = 0.02f;

		public float JingleFrequencyMin = 3f;

		public float JingleFrequencyMax = 4f;

		public List<LevelPitchOverride> LevelSongPitchOverrides;

		[InspectorName("DJs")]
		public List<SharedInstance<RadioDJDefinition>> DJs;

		public List<RadioSong> Playlist;

		public List<RadioDJQuote> Jingles;
	}
}
