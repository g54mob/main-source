using System.Linq;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class OverallQualitySetting : SettingsCategory<OverallQualitySetting>
	{
		public const string CategoryDisplayName = "Overall Quality";

		public override int Order => -2000;

		public OverallQualitySetting()
			: base("Overall Quality")
		{
			RegisterPresetList(DeviceFlags.Mobile, SettingsCategoryPreset.VeryLow, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom, SettingsCategoryPreset.Default);
			RegisterPresetList(DeviceFlags.Desktop, SettingsCategoryPreset.VeryLow, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Ultra, SettingsCategoryPreset.Custom, SettingsCategoryPreset.Default);
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			return SettingsCategoryPreset.Default;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset == SettingsCategoryPreset.Custom || Game.Instance?.QualitySettings == null)
			{
				return;
			}
			foreach (SettingsCategory category in Game.Instance.QualitySettings.Categories)
			{
				if (category == this)
				{
					continue;
				}
				if (category.AvailablePresets != null && category.AvailablePresets.Contains(preset))
				{
					category.SetPreset(preset);
				}
				else if (category.AvailablePresets != null)
				{
					SettingsCategoryPreset nearestAvailablePreset = GetNearestAvailablePreset(category, preset);
					if (nearestAvailablePreset != SettingsCategoryPreset.None || preset == SettingsCategoryPreset.Default)
					{
						category.SetPreset(nearestAvailablePreset);
					}
				}
			}
			if (Device.IsMobileBuild && preset != SettingsCategoryPreset.High)
			{
				Game.Instance.QualitySettings.ImageEffects.SetPreset(SettingsCategoryPreset.Off);
			}
		}

		protected override void InitializeSettings()
		{
		}

		private SettingsCategoryPreset GetNearestAvailablePreset(SettingsCategory category, SettingsCategoryPreset targetPreset)
		{
			if (targetPreset == SettingsCategoryPreset.Default)
			{
				return category.GetDefaultPreset();
			}
			if (category.AvailablePresets == null)
			{
				return SettingsCategoryPreset.None;
			}
			SettingsCategoryPreset settingsCategoryPreset = targetPreset;
			if (category.AvailablePresets.Contains(targetPreset))
			{
				return targetPreset;
			}
			switch (targetPreset)
			{
			case SettingsCategoryPreset.Ultra:
				if (category.AvailablePresets.Contains(SettingsCategoryPreset.VeryHigh))
				{
					settingsCategoryPreset = SettingsCategoryPreset.VeryHigh;
				}
				else if (category.AvailablePresets.Contains(SettingsCategoryPreset.High))
				{
					settingsCategoryPreset = SettingsCategoryPreset.High;
				}
				break;
			case SettingsCategoryPreset.VeryHigh:
				if (category.AvailablePresets.Contains(SettingsCategoryPreset.High))
				{
					settingsCategoryPreset = SettingsCategoryPreset.High;
				}
				break;
			case SettingsCategoryPreset.VeryLow:
				settingsCategoryPreset = (category.AvailablePresets.Contains(SettingsCategoryPreset.Off) ? SettingsCategoryPreset.Off : SettingsCategoryPreset.Low);
				break;
			}
			if (!category.AvailablePresets.Contains(settingsCategoryPreset))
			{
				settingsCategoryPreset = SettingsCategoryPreset.None;
			}
			return settingsCategoryPreset;
		}
	}
}
