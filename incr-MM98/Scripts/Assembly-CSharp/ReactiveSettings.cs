using R3;
using UnityEngine;

public static class ReactiveSettings
{
	public static PrefEnumReactiveProperty<FullScreenMode> FullscreenMode;

	public static PrefIntReactiveProperty FpsLimit;

	public static PrefIntReactiveProperty Brightness;

	public static PrefBoolReactiveProperty CRTEffect;

	public static PrefBoolReactiveProperty GnormanMuffled;

	public static PrefBoolReactiveProperty TwitchEnabled;

	public static PrefStringReactiveProperty TwitchChannel;

	public static PrefBoolReactiveProperty AudioMuted;

	public static PrefBoolReactiveProperty MuteAudioOnFocusLoss;

	public static PrefFloatReactiveProperty AudioMaster;

	public static PrefFloatReactiveProperty AudioSfx;

	public static PrefFloatReactiveProperty AudioMusic;

	public static PrefFloatReactiveProperty AudioAmbient;

	public static ReadOnlyReactiveProperty<float> AudioSfxVolume;

	public static ReadOnlyReactiveProperty<float> AudioMusicVolume;

	public static ReadOnlyReactiveProperty<float> AudioAmbientVolume;

	private static DisposableBag _properties;

	public static void Initialize(Component owner)
	{
		_properties.Clear();
		_properties = new DisposableBag(15);
		MigratePlayerPrefs();
		FullscreenMode = new PrefEnumReactiveProperty<FullScreenMode>("display_mode", Screen.fullScreenMode).AddTo(ref _properties);
		FpsLimit = new PrefIntReactiveProperty("frame_rate_limit", 60).AddTo(ref _properties);
		Brightness = new PrefIntReactiveProperty("brightness", 2).AddTo(ref _properties);
		CRTEffect = new PrefBoolReactiveProperty("crt_effect", defaultValue: true).AddTo(ref _properties);
		GnormanMuffled = new PrefBoolReactiveProperty("gnorman_muffled", defaultValue: false).AddTo(ref _properties);
		TwitchEnabled = new PrefBoolReactiveProperty("twitch_enabled", defaultValue: false).AddTo(ref _properties);
		TwitchChannel = new PrefStringReactiveProperty("twitch_channel", string.Empty).AddTo(ref _properties);
		AudioMuted = new PrefBoolReactiveProperty("volume_muted", defaultValue: false).AddTo(ref _properties);
		MuteAudioOnFocusLoss = new PrefBoolReactiveProperty("mute_on_focus_loss", defaultValue: true).AddTo(ref _properties);
		AudioMaster = new PrefFloatReactiveProperty("volume_master", 0.5f).AddTo(ref _properties);
		AudioSfx = new PrefFloatReactiveProperty("volume_sfx", 0.5f).AddTo(ref _properties);
		AudioMusic = new PrefFloatReactiveProperty("volume_music", 0.5f).AddTo(ref _properties);
		AudioAmbient = new PrefFloatReactiveProperty("volume_ambient", 0.5f).AddTo(ref _properties);
		AudioSfxVolume = AudioSfx.CombineLatest(AudioMaster, (float channel, float master) => channel * master).DistinctUntilChanged().ToReadOnlyReactiveProperty(AudioSfx.Value * AudioMaster.Value)
			.AddTo(ref _properties);
		AudioMusicVolume = AudioMusic.CombineLatest(AudioMaster, (float channel, float master) => channel * master).DistinctUntilChanged().ToReadOnlyReactiveProperty(AudioMusic.Value * AudioMaster.Value)
			.AddTo(ref _properties);
		AudioAmbientVolume = AudioAmbient.CombineLatest(AudioMaster, (float channel, float master) => channel * master).DistinctUntilChanged().ToReadOnlyReactiveProperty(AudioAmbient.Value * AudioMaster.Value)
			.AddTo(ref _properties);
		_properties.AddTo(owner);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void OnEnterPlaymode()
	{
		FullscreenMode?.Dispose();
		FpsLimit?.Dispose();
		Brightness?.Dispose();
		CRTEffect?.Dispose();
		GnormanMuffled?.Dispose();
		TwitchEnabled?.Dispose();
		TwitchChannel?.Dispose();
		AudioMuted?.Dispose();
		MuteAudioOnFocusLoss?.Dispose();
		AudioMaster?.Dispose();
		AudioSfx?.Dispose();
		AudioMusic?.Dispose();
		AudioAmbient?.Dispose();
		AudioSfxVolume?.Dispose();
		AudioMusicVolume?.Dispose();
		AudioAmbientVolume?.Dispose();
	}

	private static void MigratePlayerPrefs()
	{
		if (PlayerPrefs.GetInt("prefs_migration_v1", 0) != 1)
		{
			if (PlayerPrefs.HasKey("crt_effect") && !PlayerPrefs.HasKey("gnorman_muffled"))
			{
				PlayerPrefs.SetInt("crt_effect", 1);
				PlayerPrefs.SetInt("gnorman_muffled", 0);
				Debug.Log("[ReactiveSettings] Migrated PlayerPrefs: reset 'crt_effect' to true, created 'gnorman_muffled'.");
			}
			PlayerPrefs.SetInt("prefs_migration_v1", 1);
			PlayerPrefs.Save();
		}
	}
}
