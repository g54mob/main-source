using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using JetBrains.Annotations;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework
{
	[UsedImplicitly]
	public class SoundManager : IInitializable, IDisposable
	{
		public class SoundConfig
		{
			public bool Mute;

			public float? Volume;

			public float Rate;

			public float Detune;

			public float Seek;

			public bool Loop;

			public float Delay;

			public float Pan;
		}

		private static PlayerOptions _playerOptions;

		private static readonly Dictionary<SfxType, int> SoundInstances;

		private static float _currentVolume;

		private static Dictionary<SfxType, PlaySoundResult> _prevSkippableSounds;

		private static DataManager _dataManager;

		public const string BGM_CACHE_GROUP = "BGM";

		public const string SFX_CACHE_GROUP = "SFX";

		public static BgmType CurrentBgm { get; set; }

		public static SoundConfig CurrentMusicSoundConfig { get; set; }

		public static bool AllowUIFades { get; set; }

		public static float NormalMusicVolume => 0f;

		[Inject]
		private void Construct(PlayerOptions playerOptions, DataManager data)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static void Cleanup()
		{
		}

		public static PlaySoundResult PlaySound(SfxType sfxType, SoundConfig soundConfig = null, float durationMillis = 0f, int maxInstances = 10, float time = 0f)
		{
			return null;
		}

		public static PlaySoundResult PlaySoundNonAlloc(SfxType sfxType, float durationMillis = 0f, int maxInstances = 10, float time = 0f, float? Volume = null, float Rate = 1f, float Detune = 0f, bool Loop = false, float Delay = 0f)
		{
			return null;
		}

		private static void HandlePlaybackSkipping(PlaySoundResult sound, SfxType sfxType)
		{
		}

		public static void StopSound(SfxType sfxType)
		{
		}

		public static void StopAll()
		{
		}

		public static void GetPlaylistSource(BgmType bgmType)
		{
		}

		public static void PreloadBgmAsync(BgmType bgmType)
		{
		}

		public static void PreloadBgmAsync(List<BgmType> bgmTypes)
		{
		}

		public static void PlayMusic(BgmType bgmType, SoundConfig config = null)
		{
		}

		public static void TransitionMusic(BgmType newTrack, float durationMillisOut, float durationMillisIn, float? finalVolume = null)
		{
		}

		public static void FadeInMusic(BgmType newTrack, float fadeInTimeMillis, float? finalVolume = null)
		{
		}

		public static void StopMusic(BgmType bgmType)
		{
		}

		public static void FadeMusic(float volume, float durationMillis)
		{
		}

		public static void FadeMusic(BgmType bgmType, float volume, float durationMillis)
		{
		}

		public static void UpdateMusicVolume(float volume)
		{
		}

		public static void UpdateSfxVolume(float volume)
		{
		}

		public static void UpdateCurrentMusicWithConfig(SoundConfig config)
		{
		}

		public static string GetSoundGroupFromType(SfxType sfxType)
		{
			return null;
		}

		private static float CalculatePitch(float detune, float rate)
		{
			return 0f;
		}
	}
}
