using UnityEngine;

public class AudioSettingsPanel : SettingsPanel
{
	[Header("Audio")]
	[Tooltip("Slider to set master volume.")]
	[SerializeField]
	private InteractableSlider _masterVolumeSlider;

	[Tooltip("Slider to set music volume.")]
	[SerializeField]
	private InteractableSlider _musicVolumeSlider;

	[Tooltip("Slider to set SFX volume.")]
	[SerializeField]
	private InteractableSlider _soundEffectsVolumeSlider;

	[Tooltip("Slider to set ui volume.")]
	[SerializeField]
	private InteractableSlider _uiVolumeSlider;

	private AudioPlayerData _audioData;

	public override void Load(Settings playerData)
	{
		_audioData = playerData.AudioPlayerData;
		SetValues(_audioData);
	}

	public override void ApplyChanges()
	{
	}

	protected override void Reset()
	{
		_audioData.ResetSettings(GameSettings.Instance.MasterVolume);
		SetValues(_audioData);
	}

	public override bool HasChanges()
	{
		return false;
	}

	private void SetValues(AudioPlayerData audioPlayerData)
	{
		_masterVolumeSlider.SetValueNormalized(audioPlayerData.MasterVolume);
		_uiVolumeSlider.SetValueNormalized(audioPlayerData.UIVolume);
		_musicVolumeSlider.SetValueNormalized(audioPlayerData.MusicVolume);
		_soundEffectsVolumeSlider.SetValueNormalized(audioPlayerData.SFXVolume);
	}

	public void UpdateMasterVolumeSlider()
	{
		_audioData.MasterVolume = _masterVolumeSlider.ReturnValueNormalized(updateTextValue: true);
		FMODManager.SetMasterVolume(_audioData.MasterVolume);
	}

	public void UpdateMusicVolumeSlider()
	{
		_audioData.MusicVolume = _musicVolumeSlider.ReturnValueNormalized(updateTextValue: true);
		FMODManager.SetMusicVolume(_audioData.MusicVolume);
	}

	public void UpdateSFXVolumeSlider()
	{
		_audioData.SFXVolume = _soundEffectsVolumeSlider.ReturnValueNormalized(updateTextValue: true);
		FMODManager.SetSFXVolume(_audioData.SFXVolume);
	}

	public void UpdateUIVolumeSlider()
	{
		_audioData.UIVolume = _uiVolumeSlider.ReturnValueNormalized(updateTextValue: true);
		FMODManager.SetUIVolume(_audioData.UIVolume);
	}
}
