using FMOD.Studio;
using FMODUnity;
using HauntedPSX.RenderPipelines.PSX.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public SettingsSO m_settings;

	private Bus m_Master;

	private Bus m_BG;

	private Bus m_SFX;

	public Slider m_MasterVolSlider;

	public Slider m_SFXVolSlider;

	public Slider m_BGVolSlider;

	public Toggle m_VHSToggle;

	public Toggle m_GlitchToggle;

	public Toggle m_NoiseToggle;

	private float m_MasterVolume = 1f;

	private float m_SFXVolume = 1f;

	private float m_BGVolume = 1f;

	private Volume m_Volume;

	private VolumeProfile m_VolumeProfile;

	private GameObject m_GlitchOverlay;

	private void Awake()
	{
		m_MasterVolSlider.value = m_settings.m_MasterVolume;
		m_SFXVolSlider.value = m_settings.m_SFXVolume;
		m_BGVolSlider.value = m_settings.m_BGVolume;
		m_VHSToggle.isOn = m_settings.m_VHSToggle;
		m_GlitchToggle.isOn = m_settings.m_GlitchToggle;
		m_NoiseToggle.isOn = m_settings.m_NoiseToggle;
		m_Master = RuntimeManager.GetBus("bus:/");
		m_SFX = RuntimeManager.GetBus("bus:/SFX");
		m_BG = RuntimeManager.GetBus("bus:/BGM");
		m_Volume = GameObject.FindGameObjectWithTag("GlobalVolume").GetComponent<Volume>();
		if (m_Volume != null && m_Volume.profile != null)
		{
			m_VolumeProfile = m_Volume.profile;
		}
		m_GlitchOverlay = GameObject.FindGameObjectWithTag("Glitch");
		MasterVolumeLevel();
		SFXVolumeLevel();
		BGVolumeLevel();
		ToggleVHS();
		ToggleGlitch();
		ToggleNoise();
	}

	private void Start()
	{
		m_MasterVolSlider.onValueChanged.AddListener(delegate
		{
			MasterVolumeLevel();
		});
		m_SFXVolSlider.onValueChanged.AddListener(delegate
		{
			SFXVolumeLevel();
		});
		m_BGVolSlider.onValueChanged.AddListener(delegate
		{
			BGVolumeLevel();
		});
		m_VHSToggle.onValueChanged.AddListener(delegate
		{
			ToggleVHS();
		});
		m_GlitchToggle.onValueChanged.AddListener(delegate
		{
			ToggleGlitch();
		});
		m_NoiseToggle.onValueChanged.AddListener(delegate
		{
			ToggleNoise();
		});
		MasterVolumeLevel();
		SFXVolumeLevel();
		BGVolumeLevel();
		ToggleVHS();
		ToggleGlitch();
		ToggleNoise();
	}

	public void MasterVolumeLevel()
	{
		m_MasterVolume = m_MasterVolSlider.value;
		m_settings.m_MasterVolume = m_MasterVolSlider.value;
		m_Master.setVolume(m_MasterVolume);
		Debug.Log("Master Vol Changed to: " + m_MasterVolume);
	}

	public void SFXVolumeLevel()
	{
		m_SFXVolume = m_SFXVolSlider.value;
		m_settings.m_SFXVolume = m_SFXVolume;
		m_SFX.setVolume(m_SFXVolume);
		Debug.Log("SFX Vol Changed to: " + m_SFXVolume);
	}

	public void BGVolumeLevel()
	{
		m_BGVolume = m_BGVolSlider.value;
		m_settings.m_BGVolume = m_BGVolume;
		m_BG.setVolume(m_BGVolume);
		Debug.Log("BG Vol Changed to: " + m_BGVolume);
	}

	public void ToggleVHS()
	{
		if (m_VolumeProfile.TryGet<CathodeRayTubeVolume>(out var component))
		{
			component.isEnabled.value = m_VHSToggle.isOn;
			m_settings.m_VHSToggle = m_VHSToggle.isOn;
		}
	}

	public void ToggleGlitch()
	{
		m_GlitchOverlay.SetActive(m_GlitchToggle.isOn);
		m_settings.m_GlitchToggle = m_GlitchToggle.isOn;
	}

	public void ToggleNoise()
	{
		if (m_VolumeProfile.TryGet<QualityOverrideVolume>(out var component))
		{
			component.active = m_NoiseToggle.isOn;
			m_settings.m_NoiseToggle = m_NoiseToggle.isOn;
			Debug.Log("FOUND IT: NOISE");
		}
	}
}
