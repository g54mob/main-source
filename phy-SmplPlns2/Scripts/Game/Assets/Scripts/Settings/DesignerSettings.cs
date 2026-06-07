using Assets.Scripts.Design;
using Assets.Scripts.Input;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;

namespace Assets.Scripts.Settings
{
	public class DesignerSettings : SettingsCategory<DesignerSettings>
	{
		public StringSetting AmbientColor { get; private set; }

		public BoolSetting AutoRecenter { get; private set; }

		public NumericSetting<float> LightIntensity { get; private set; }

		public NumericSetting<float> LightRotationX { get; private set; }

		public NumericSetting<float> LightRotationY { get; private set; }

		public NumericSetting<float> NudgeDistance { get; private set; }

		public StringSetting Platform { get; private set; }

		public StringSetting PlatformColor { get; private set; }

		public NumericSetting<float> ReflectionIntensity { get; private set; }

		public NumericSetting<float> RotateAmount { get; private set; }

		public StringSetting Sky { get; private set; }

		public StringSetting SkyColor { get; private set; }

		public BoolSetting SymmetryDisabled { get; private set; }

		public DesignerSettings()
			: base("Designer")
		{
		}

		protected override void InitializeSettings()
		{
			AutoRecenter = CreateBool("Auto Recenter").SetDescription("Automatically recenter the craft in the designer when the craft is saved.").SetDefault(value: true);
			NudgeDistance = CreateNumeric("Nudge Distance", 0.0001f, 10f, 0.5f).SetDefault(1f / 128f).SetDisplayFormatter((float x) => x.ToString("n3")).SetState(SettingState.Hidden);
			RotateAmount = CreateNumeric("Rotate Amount", 0.001f, 180f, 5f).SetDefault(15f).SetState(SettingState.Hidden);
			Sky = CreateString("Sky").SetDefault("Purple Haze").SetState(SettingState.Hidden);
			SkyColor = CreateString("SkyColor").SetDefault(ColorsUtility.ToString(DesignerEnvironmentScript.DefaultSkyColor, ColorStringFormat.HexRGB)).SetState(SettingState.Hidden);
			Platform = CreateString("Platform").SetDefault("Square").SetState(SettingState.Hidden);
			PlatformColor = CreateString("PlatformColor").SetDefault(ColorsUtility.ToString(DesignerEnvironmentScript.DefaultPlatformColor, ColorStringFormat.HexRGB)).SetState(SettingState.Hidden);
			AmbientColor = CreateString("AmbientColor").SetDefault(ColorsUtility.ToString(DesignerEnvironmentScript.DefaultAmbientColor, ColorStringFormat.HexRGB)).SetState(SettingState.Hidden);
			LightIntensity = CreateNumeric("Light Intensity", 0f, 2f, 0.05f).SetDefault(1f).SetState(SettingState.Hidden);
			LightRotationY = CreateNumeric("Light Rotation Y", -90f, 90f, 1f).SetDefault(-30f).SetState(SettingState.Hidden);
			LightRotationX = CreateNumeric("Light Rotation X", -90f, 90f, 1f).SetDefault(0f).SetState(SettingState.Hidden);
			ReflectionIntensity = CreateNumeric("Reflection Intensity", 0f, 2f, 0.05f).SetDefault(1f).SetState(SettingState.Hidden);
			SymmetryDisabled = CreateBool("Symmetry Disabled").SetDefault(value: false).SetState(SettingState.Hidden);
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			base.Changed += delegate
			{
				InputWrapper.MouseAsJoystickSettingsChanged = true;
			};
			RaiseSettingsChangedEvent();
		}
	}
}
