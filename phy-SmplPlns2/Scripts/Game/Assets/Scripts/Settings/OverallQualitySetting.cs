using System.Linq;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class OverallQualitySetting : SettingsCategory<OverallQualitySetting>
	{
		public const string CategoryDisplayName = "Overall Quality";

		public override int Order => -2000;

		public OverallQualitySetting()
			: base("Overall Quality")
		{
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			IGameQualitySettings gameQualitySettings = Game.Instance?.Settings?.Quality;
			if (gameQualitySettings == null || preset == SettingsCategoryPreset.Custom || gameQualitySettings == null)
			{
				return;
			}
			foreach (SettingsCategory category in gameQualitySettings.Categories)
			{
				if (category == this || category.Preset == preset)
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
