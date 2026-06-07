using System.Collections.Generic;
using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Quality Settings Dropdown")]
	public class QualitySettingsController : SettingsComponentDropdown
	{
		private int index;

		protected override void Setup()
		{
			List<string> list = new List<string>();
			foreach (SettingsProfile qualitySetting in universalSettings.GetQualitySettings())
			{
				list.Add(qualitySetting.name);
			}
			CreateOptions(list);
		}

		protected override ref int SettingsValue()
		{
			return ref index;
		}

		protected override bool AutoApplyValue()
		{
			return false;
		}

		protected override void OnValueChanged(int value)
		{
			if (value < universalSettings.GetQualitySettings().Count)
			{
				SettingsProfile settingsProfile = universalSettings.GetQualitySettings()[value];
				universalSettings.viewSettings = Object.Instantiate(universalSettings.viewSettings);
				universalSettings.viewSettings.antiAliasingIndex = settingsProfile.antiAliasingIndex;
				universalSettings.viewSettings.shadowModeIndex = settingsProfile.shadowModeIndex;
				universalSettings.viewSettings.shadowDistanceIndex = settingsProfile.shadowDistanceIndex;
				universalSettings.viewSettings.shadowResolutionIndex = settingsProfile.shadowResolutionIndex;
				universalSettings.viewSettings.textureResolutionIndex = settingsProfile.textureResolutionIndex;
				universalSettings.viewSettings.postProcessing = settingsProfile.postProcessing;
				universalSettings.viewSettings.postProcessingEffect = settingsProfile.postProcessingEffect;
				universalSettings.viewSettings.rendererFeatures = settingsProfile.rendererFeatures;
			}
			base.OnValueChanged(value);
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			index = 0;
			using (List<SettingsProfile>.Enumerator enumerator = universalSettings.GetQualitySettings().GetEnumerator())
			{
				while (enumerator.MoveNext() && !enumerator.Current.CompareGraphicQuality(settings))
				{
					index++;
				}
			}
			if (SettingsValue() >= universalSettings.GetQualitySettings().Count)
			{
				if (SettingsValue() >= GetOptionsCount())
				{
					AddOption("Custom");
				}
			}
			else if (GetOptionsCount() > universalSettings.GetQualitySettings().Count)
			{
				RemoveOption(GetOptionsCount() - 1);
			}
			base.UpdateComponent(settings);
		}
	}
}
