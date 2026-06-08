using UnityEngine;
using UnityEngine.Audio;

public class SettingsApplier : MonoBehaviour
{
	[SerializeField]
	private Settings settings;

	[SerializeField]
	private AudioMixer sfxMixer;

	[SerializeField]
	private CRTSettings crtSettings;

	private void Awake()
	{
		SetMasterVolume();
	}

	private void Start()
	{
		SetSfxVolume();
		settings.InitializeBackground();
		if (crtSettings.InitalizeCrtSettings())
		{
			crtSettings.LoadChromaticAbberation();
			crtSettings.LoadScanLines();
		}
	}

	public void SetMasterVolume()
	{
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.MASTER_VOLUME);
		AudioListener.volume = (volume.HasValue ? volume.Value : Settings.DEFAULT_VOLUME);
	}

	public void SetSfxVolume()
	{
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.SFX_VOLUME);
		float sfxVolume = Settings.GetSfxVolume(volume.HasValue ? volume.Value : Settings.DEFAULT_VOLUME);
		sfxMixer.SetFloat(Settings.SFX_VOLUME_MIXER_KEY, sfxVolume);
	}
}
