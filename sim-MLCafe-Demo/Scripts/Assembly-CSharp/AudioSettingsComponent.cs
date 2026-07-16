using Game;
using Game.Audio;
using UnityEngine;
using UnityEngine.Events;

public class AudioSettingsComponent : SettingsComponent
{
	[SerializeField]
	private AudioSettingsContainer loadedAudioSettings;

	[SerializeField]
	private UnityEvent<float> OnUpdateMaster = new UnityEvent<float>();

	[SerializeField]
	private UnityEvent<float> OnUpdateMusic = new UnityEvent<float>();

	[SerializeField]
	private UnityEvent<float> OnUpdateSFX = new UnityEvent<float>();

	[SerializeField]
	private UnityEvent<float> OnUpdateUI = new UnityEvent<float>();

	[SerializeField]
	private UnityEvent<float> OnUpdateAmbient = new UnityEvent<float>();

	public override void OnConfigLoad(GameSettingsConfig config)
	{
		loadedAudioSettings = config.audioSettings;
		base.OnConfigLoad(config);
		UpdateProperties();
	}

	public override void OnConfigUpdate(GameSettingsConfig config)
	{
		loadedAudioSettings = config.audioSettings;
		UpdateProperties();
	}

	private void UpdateProperties()
	{
		OnUpdateMaster.Invoke(loadedAudioSettings.masterVolume);
		OnUpdateMusic.Invoke(loadedAudioSettings.musicVolume);
		OnUpdateSFX.Invoke(loadedAudioSettings.sfxVolume);
		OnUpdateUI.Invoke(loadedAudioSettings.uiVolume);
		OnUpdateAmbient.Invoke(loadedAudioSettings.ambientVolume);
	}

	public AudioSettingsContainer GetLoadedGraphics()
	{
		return loadedAudioSettings;
	}

	public void OnLoadMasterVolume(SliderField slider)
	{
		slider.Init(loadedAudioSettings.masterVolume);
		Game.Audio.AudioSettings.SetMasterVolume(loadedAudioSettings.masterVolume);
		GameSettings.SetAudioSettings(loadedAudioSettings);
	}

	public void OnLoadMusicVolume(SliderField slider)
	{
		slider.Init(loadedAudioSettings.musicVolume);
		Game.Audio.AudioSettings.SetMusicVolume(loadedAudioSettings.musicVolume);
		GameSettings.SetAudioSettings(loadedAudioSettings);
	}

	public void OnLoadSFXVolume(SliderField slider)
	{
		slider.Init(loadedAudioSettings.sfxVolume);
		Game.Audio.AudioSettings.SetSFXVolume(loadedAudioSettings.sfxVolume);
		GameSettings.SetAudioSettings(loadedAudioSettings);
	}

	public void OnLoadUIVolume(SliderField slider)
	{
		slider.Init(loadedAudioSettings.uiVolume);
		Game.Audio.AudioSettings.SetUIVolume(loadedAudioSettings.uiVolume);
		GameSettings.SetAudioSettings(loadedAudioSettings);
	}

	public void OnLoadAmbientVolume(SliderField slider)
	{
		slider.Init(loadedAudioSettings.ambientVolume);
		Game.Audio.AudioSettings.SetAmbientVolume(loadedAudioSettings.ambientVolume);
		GameSettings.SetAudioSettings(loadedAudioSettings);
	}

	public void OnMasterVolumeChanged(float value)
	{
		loadedAudioSettings.masterVolume = value;
		Game.Audio.AudioSettings.SetMasterVolume(loadedAudioSettings.masterVolume);
		GameSettings.UpdateAudioSettings(loadedAudioSettings);
	}

	public void OnMusicVolumeChanged(float value)
	{
		loadedAudioSettings.musicVolume = value;
		Game.Audio.AudioSettings.SetMusicVolume(loadedAudioSettings.musicVolume);
		GameSettings.UpdateAudioSettings(loadedAudioSettings);
	}

	public void OnSFXVolumeChanged(float value)
	{
		loadedAudioSettings.sfxVolume = value;
		Game.Audio.AudioSettings.SetSFXVolume(loadedAudioSettings.sfxVolume);
		GameSettings.UpdateAudioSettings(loadedAudioSettings);
	}

	public void OnUIVolumeChanged(float value)
	{
		loadedAudioSettings.uiVolume = value;
		Game.Audio.AudioSettings.SetUIVolume(loadedAudioSettings.uiVolume);
		GameSettings.UpdateAudioSettings(loadedAudioSettings);
	}

	public void OnAmbientVolumeChanged(float value)
	{
		loadedAudioSettings.ambientVolume = value;
		Game.Audio.AudioSettings.SetAmbientVolume(loadedAudioSettings.ambientVolume);
		GameSettings.UpdateAudioSettings(loadedAudioSettings);
	}
}
