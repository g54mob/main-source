using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	public class CustomizeGraphy : MonoBehaviour
	{
		[Header("Customize Graphy")]
		[SerializeField]
		private CUIColorPicker m_colorPicker;

		[SerializeField]
		private Toggle m_backgroundToggle;

		[SerializeField]
		private Dropdown m_graphyModeDropdown;

		[SerializeField]
		private Button m_backgroundColorButton;

		[SerializeField]
		private Dropdown m_graphModulePositionDropdown;

		[Header("Fps")]
		[SerializeField]
		private Dropdown m_fpsModuleStateDropdown;

		[SerializeField]
		private InputField m_goodInputField;

		[SerializeField]
		private InputField m_cautionInputField;

		[SerializeField]
		private Button m_goodColorButton;

		[SerializeField]
		private Button m_cautionColorButton;

		[SerializeField]
		private Button m_criticalColorButton;

		[SerializeField]
		private Slider m_timeToResetMinMaxSlider;

		[SerializeField]
		private Slider m_fpsGraphResolutionSlider;

		[SerializeField]
		private Slider m_fpsTextUpdateRateSlider;

		[Header("Memory")]
		[SerializeField]
		private Dropdown m_ramModuleStateDropdown;

		[SerializeField]
		private Button m_reservedColorButton;

		[SerializeField]
		private Button m_allocatedColorButton;

		[SerializeField]
		private Button m_monoColorButton;

		[SerializeField]
		private Slider m_ramGraphResolutionSlider;

		[SerializeField]
		private Slider m_ramTextUpdateRateSlider;

		[Header("Audio")]
		[SerializeField]
		private Dropdown m_audioModuleStateDropdown;

		[SerializeField]
		private Button m_audioGraphColorButton;

		[SerializeField]
		private Dropdown m_findAudioListenerDropdown;

		[SerializeField]
		private Dropdown m_fttWindowDropdown;

		[SerializeField]
		private Slider m_spectrumSizeSlider;

		[SerializeField]
		private Slider m_audioGraphResolutionSlider;

		[SerializeField]
		private Slider m_audioTextUpdateRateSlider;

		[Header("Advanced")]
		[SerializeField]
		private Dropdown m_advancedModulePositionDropdown;

		[SerializeField]
		private Toggle m_advancedModuleToggle;

		[Header("Other")]
		[SerializeField]
		private Button m_musicButton;

		[SerializeField]
		private Button m_sfxButton;

		[SerializeField]
		private Slider m_musicVolumeSlider;

		[SerializeField]
		private Slider m_sfxVolumeSlider;

		[SerializeField]
		private AudioSource m_musicAudioSource;

		[SerializeField]
		private AudioSource m_sfxAudioSource;

		[SerializeField]
		private List<AudioClip> m_sfxAudioClips;

		private GraphyManager m_graphyManager;

		private void Start()
		{
		}

		private void SetupCallbacks()
		{
		}

		private void ToggleMusic()
		{
		}

		private void PlayRandomSFX()
		{
		}
	}
}
