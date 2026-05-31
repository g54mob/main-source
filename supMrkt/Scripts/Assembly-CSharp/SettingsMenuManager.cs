using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.PlayerAim;

public class SettingsMenuManager : MonoBehaviour
{
	[SerializeField]
	private InputActionAsset m_InputActionAsset;

	[SerializeField]
	private GameObject m_Menu;

	[SerializeField]
	private bool m_IsXBoxSettings;

	[Header("Gameplay")]
	[SerializeField]
	private TMP_Dropdown m_LanguageSetting;

	[SerializeField]
	private Toggle m_InvertYAxisToggle;

	[SerializeField]
	private Toggle m_InvertXAxisToggle;

	[SerializeField]
	private Slider m_MouseSensitivitySetting;

	[SerializeField]
	private Slider m_GamepadRotateSensitivitySetting;

	[SerializeField]
	private TMP_Text m_SensitivityText;

	[SerializeField]
	private TMP_Text m_RotateSensitivityText;

	[SerializeField]
	private Toggle m_RunInBackgroundToggle;

	[SerializeField]
	private Toggle m_EnableShopliftersToggle;

	[SerializeField]
	private GameObject m_EnableShopLifterPanel;

	[Header("Graphics")]
	[SerializeField]
	private TMP_Dropdown m_QualitySetting;

	[SerializeField]
	private TMP_Dropdown m_ResolutionSetting;

	[SerializeField]
	private TMP_Dropdown m_TargetFrameRate;

	[SerializeField]
	private GameObject m_TargetFrameRateObject;

	[SerializeField]
	private Toggle m_FullscreenToggle;

	[SerializeField]
	private Slider m_FOVSetting;

	[SerializeField]
	private TMP_Text m_FOVText;

	[SerializeField]
	private Toggle m_VSync;

	[SerializeField]
	private Button m_AdvancedSettingsButton;

	[Header("Advanced Graphics")]
	[SerializeField]
	private GameObject m_AdvancedSettingsMenu;

	[SerializeField]
	private TMP_Dropdown m_TextureQualitySetting;

	[SerializeField]
	private TMP_Dropdown m_AntiAliasingSetting;

	[SerializeField]
	private TMP_Dropdown m_ShadowQuality;

	[SerializeField]
	private TMP_Dropdown m_UpscalingFilter;

	[SerializeField]
	private Toggle m_HDR;

	[SerializeField]
	private Toggle m_PostProcess;

	[Header("Audio")]
	[SerializeField]
	private AudioMixerGroup m_masterGroup;

	[SerializeField]
	private AudioMixerGroup m_musicGroup;

	[SerializeField]
	private AudioMixerGroup m_sfxGroup;

	[SerializeField]
	private TMP_Text m_masterVolumeText;

	[SerializeField]
	private TMP_Text m_musicVolumeText;

	[SerializeField]
	private TMP_Text m_sfxVolumeText;

	[SerializeField]
	private Slider m_MasterVolumeSlider;

	[SerializeField]
	private Slider m_MusicVolumeSlider;

	[SerializeField]
	private Slider m_SFXVolumeSlider;

	[SerializeField]
	private TabManager m_tabManager;

	[SerializeField]
	public GamePadUIPanel gamePadUIPanel;

	[SerializeField]
	private EscapeMenuManager m_EscapeMenuManager;

	[SerializeField]
	private MainMenuManager m_mainMenuManager;

	private UniversalRenderPipelineAsset m_CustomRenderPipelineAsset;

	private Resolution[] m_Resolutions;

	private string m_ResolutionsTexts;

	private bool m_ChangingLocale;

	private bool m_isCustomSelected;

	private bool m_alreadyLoaded;

	public Action onResolutionChange;

	[SerializeField]
	private List<int> m_FrameRates;

	[Space]
	[SerializeField]
	private AimColorPreview aimColorPreview;

	private SettingsContainer m_Settings => null;

	public bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void LoadSaveProgress()
	{
	}

	public void RefreshSelectedTab()
	{
	}

	public void SetLanguage(int languageIndex)
	{
	}

	public void InvertYAxis(bool invert)
	{
	}

	public void InvertXAxis(bool invert)
	{
	}

	public void SetSensitivity(float sensitivity)
	{
	}

	public void SetRotateSensitivity(float sensitivity)
	{
	}

	public void SetRunInBackground(bool runInBackground)
	{
	}

	public void SetEnableShoplifters(bool enableShoplifters)
	{
	}

	public void SetFOV(float fov)
	{
	}

	public void SetQualitySerialized(int qualityIndex)
	{
	}

	public void SetQuality(int qualityIndex, bool isCustom = false)
	{
	}

	public void SetFullscreen(bool fullscreen)
	{
	}

	public void SetVSync(bool isVsync)
	{
	}

	private void VsyncNavigationHandle(bool isVsync)
	{
	}

	public void SetResolution(string resText)
	{
	}

	public void SetResolutionSerialize(int resolutionIndex)
	{
	}

	public void SetTargetFrameRate(int resolutionIndex)
	{
	}

	public void SwitchAdvancedSettingsMenu(bool willOpen)
	{
	}

	private bool SetCustomGraphic(bool isFirstLoad = false)
	{
		return false;
	}

	private void SetCustomPipeline()
	{
	}

	private void ChangeAdvancedSettingsToCurrent()
	{
	}

	private void SetTextureQuality(int qualityIndex, bool isCustom)
	{
	}

	public void SetTextureQualitySerialized(int qualityIndex)
	{
	}

	public void SetAA(int index)
	{
	}

	[Obsolete("Use SetAA instead")]
	private void SetAntiAliasing(int antiAliasingIndex, bool isCustom)
	{
	}

	[Obsolete("Use SetAA instead")]
	public void SetAntiAliasingSerialized(int antiAliasingIndex)
	{
	}

	private void SetShadowQuality(int shadowQualityIndex, bool isCustom)
	{
	}

	public void SetShadowQualitySerialized(int shadowQualityIndex)
	{
	}

	private void SetUpscalingFilter(int upscalingFilter, bool isCustom)
	{
	}

	public void SetUpscalingFilterSerialized(int upscalingFilter)
	{
	}

	private void SetHDR(bool isHDROpen, bool isCustom)
	{
	}

	public void SetHDRSerialized(bool isHDROpen)
	{
	}

	private void SetPostProcess(bool isPostProcessOpen, bool isCustom)
	{
	}

	public void SetPostProcessSerialized(bool isPostProcessOpen)
	{
	}

	private void LoadAdvancedQualitySettings(bool isCustom)
	{
	}

	public void SetMasterVolume(float volume)
	{
	}

	public void SetMusicVolume(float volume)
	{
	}

	public void SetSFXVolume(float volume)
	{
	}

	public void SaveSettings()
	{
	}

	private void LoadSettings()
	{
	}

	private void LoadInputSettings(bool value = false)
	{
	}

	private void LoadResolutions()
	{
	}

	private Vector2Int ParseResolution(string resText)
	{
		return default(Vector2Int);
	}
}
