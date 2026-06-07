using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Simulator
{
	[Settings("Application Settings/Accessibility", Scope.Project)]
	public class AccessibilityApplicationOptions : CustomApplicationOptions<AccessibilityApplicationOptions>
	{
		public enum EColorBlindnessCorrectionMode
		{
			NONE = 0,
			PROTANOPIA = 1,
			DEUTERANOPIA = 2,
			TRITANOPIA = 3
		}

		[SerializeField]
		private Sprite m_referenceSprite;

		[SerializeField]
		private VolumeProfile m_volumeProfile;

		private LiftGammaGain m_liftGammaGain;

		private ColorAdjustments m_colorAdjustments;

		[SerializeField]
		private PlayerPrefFloat m_gamma;

		[SerializeField]
		private PlayerPrefFloat m_contrast;

		[SerializeField]
		private PlayerPrefEnum<EColorBlindnessCorrectionMode> m_colorBlindCorrectionMode;

		[SerializeField]
		private PlayerPrefBool m_visualEffects;

		public static Sprite ReferenceSprite => CustomSettings<AccessibilityApplicationOptions>.I.m_referenceSprite;

		public static PlayerPrefFloat Gamma => CustomSettings<AccessibilityApplicationOptions>.I.m_gamma;

		public static PlayerPrefFloat Contrast => CustomSettings<AccessibilityApplicationOptions>.I.m_contrast;

		public static PlayerPrefEnum<EColorBlindnessCorrectionMode> ColorBlindCorrectionMode => CustomSettings<AccessibilityApplicationOptions>.I.m_colorBlindCorrectionMode;

		public static PlayerPrefBool VisualEffects => CustomSettings<AccessibilityApplicationOptions>.I.m_visualEffects;

		public void Update()
		{
			m_liftGammaGain.gamma.value = m_liftGammaGain.gamma.value.SetW(m_gamma);
			m_colorAdjustments.contrast.value = m_contrast;
			Shader.SetGlobalInt("_ColorBlindnessCorrectionMode", (int)m_colorBlindCorrectionMode.Value);
		}

		public override void Load()
		{
			m_volumeProfile.TryGet<LiftGammaGain>(out m_liftGammaGain);
			m_volumeProfile.TryGet<ColorAdjustments>(out m_colorAdjustments);
			m_gamma.Load();
			m_contrast.Load();
			m_colorBlindCorrectionMode.Load();
			m_visualEffects.Load();
			Update();
		}

		public override void ResetSettings()
		{
			m_gamma.Reset();
			m_contrast.Reset();
			m_colorBlindCorrectionMode.Reset();
			m_visualEffects.Reset();
			Update();
		}
	}
}
