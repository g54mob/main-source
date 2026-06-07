using Jundroo.Common.Platform;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class CraftQualitySettings : SettingsCategory<CraftQualitySettings>
	{
		public enum CraftReflectionsQuality
		{
			[EnumOption("None", "Craft parts will render with simplified lighting and not reflect anything in their surface.", DisplayOrder = 0, State = SettingState.Hidden)]
			None = 0,
			[EnumOption("Static", "Reflective craft parts will use a vague static image to give the illusion of the parts reflecting their surroundings without actually doing so.", DisplayOrder = 1)]
			Static = 1,
			[EnumOption("Realtime", "Reflective craft parts will reflect the surrounding world in realtime. Enabling this option can result in extreme performance impacts.", State = SettingState.Hidden, DisplayOrder = 2)]
			[EnumOption(1u, DeviceFlags.Desktop, State = SettingState.Enabled, DisplayName = "Realtime")]
			Realtime = 2
		}

		public BoolSetting CraftCulling { get; private set; }

		public BoolSetting HeatDistortion { get; private set; }

		public EnumSetting<CraftReflectionsQuality> Reflections { get; private set; }

		public CraftQualitySettings()
			: base("Craft")
		{
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				Reflections.Value = CraftReflectionsQuality.Static;
				HeatDistortion.Value = true;
				switch (preset)
				{
				case SettingsCategoryPreset.VeryHigh:
					Reflections.Value = CraftReflectionsQuality.Realtime;
					break;
				case SettingsCategoryPreset.Low:
					HeatDistortion.Value = false;
					break;
				case SettingsCategoryPreset.VeryLow:
					HeatDistortion.Value = false;
					break;
				case SettingsCategoryPreset.Medium:
				case SettingsCategoryPreset.High:
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			Reflections = CreateEnum<CraftReflectionsQuality>("Reflections").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("This setting changes the way reflections are handled on the craft surfaces.").SetDefault(CraftReflectionsQuality.Static);
			HeatDistortion = CreateBool("Heat Distortion").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("This setting toggles on or off the heat distortion effects from parts like jet engines.").SetDefault(value: true);
			CraftCulling = CreateBool("Craft Culling").SetDescription("Hide distant craft parts to improve performance").SetDefault(value: true).SetState(SettingState.Hidden);
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			Reflections.RaiseSettingChangedEvent();
		}
	}
}
