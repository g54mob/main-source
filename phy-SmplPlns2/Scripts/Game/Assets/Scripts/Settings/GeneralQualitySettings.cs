using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class GeneralQualitySettings : SettingsCategory<GeneralQualitySettings>
	{
		public override int Order => -1000;

		public GeneralQualitySettings()
			: base("General")
		{
		}

		public void ApplyUnityQualitySettings()
		{
			QualitySettings.skinWeights = SkinWeights.FourBones;
			QualitySettings.lodBias = 2f;
			QualitySettings.maximumLODLevel = 0;
			QualitySettings.particleRaycastBudget = 4096;
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			return SettingsCategoryPreset.None;
		}

		protected override void InitializeSettings()
		{
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			ApplyUnityQualitySettings();
		}
	}
}
