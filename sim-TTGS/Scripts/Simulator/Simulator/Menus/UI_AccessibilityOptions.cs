using Dhs5.Utility.Settings;
using Simulator.CustomSettings;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class UI_AccessibilityOptions : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Image m_referenceImage;

		[Header("Settings")]
		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_gammaUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_contrastUI;

		[SerializeField]
		private UI_DropdownPlayerPrefEnumOptions<AccessibilityApplicationOptions.EColorBlindnessCorrectionMode> m_colorBlindnessCorrectionModeUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_visualEffectsUI;

		private void Awake()
		{
			m_gammaUI.Init(AccessibilityApplicationOptions.Gamma);
			m_gammaUI.Awake();
			m_contrastUI.Init(AccessibilityApplicationOptions.Contrast);
			m_contrastUI.Awake();
			m_colorBlindnessCorrectionModeUI.Init(AccessibilityApplicationOptions.ColorBlindCorrectionMode);
			m_colorBlindnessCorrectionModeUI.Awake();
			m_visualEffectsUI.Init(AccessibilityApplicationOptions.VisualEffects);
			m_visualEffectsUI.Awake();
		}

		private void Start()
		{
			m_referenceImage.sprite = AccessibilityApplicationOptions.ReferenceSprite;
		}

		private void OnEnable()
		{
			m_gammaUI.OnEnable();
			m_gammaUI.OnValueChanged += OnGammaUIValueChangedUpdateVolumeProfile;
			m_contrastUI.OnEnable();
			m_contrastUI.OnValueChanged += OnContrastUIValueChangedUpdateVolumeProfile;
			m_colorBlindnessCorrectionModeUI.OnEnable();
			m_colorBlindnessCorrectionModeUI.OnValueChanged += OnColorBlindnessChanged_UpdateVolumeProfile;
			m_visualEffectsUI.OnEnable();
		}

		private void OnDisable()
		{
			m_gammaUI.OnDisable();
			m_gammaUI.OnValueChanged -= OnGammaUIValueChangedUpdateVolumeProfile;
			m_contrastUI.OnDisable();
			m_contrastUI.OnValueChanged -= OnContrastUIValueChangedUpdateVolumeProfile;
			m_colorBlindnessCorrectionModeUI.OnDisable();
			m_colorBlindnessCorrectionModeUI.OnValueChanged -= OnColorBlindnessChanged_UpdateVolumeProfile;
			m_visualEffectsUI.OnDisable();
		}

		private void OnGammaUIValueChangedUpdateVolumeProfile(float _)
		{
			CustomSettings<AccessibilityApplicationOptions>.I.Update();
		}

		private void OnContrastUIValueChangedUpdateVolumeProfile(float _)
		{
			CustomSettings<AccessibilityApplicationOptions>.I.Update();
		}

		private void OnColorBlindnessChanged_UpdateVolumeProfile(AccessibilityApplicationOptions.EColorBlindnessCorrectionMode obj)
		{
			CustomSettings<AccessibilityApplicationOptions>.I.Update();
		}
	}
}
