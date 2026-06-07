using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class DesignerSettings : SettingsCategory<DesignerSettings>
	{
		public NumericSetting<float> AngleSnap { get; private set; }

		public BoolSetting EnableAutoResize { get; private set; }

		public BoolSetting EnableSurfaceAttachments { get; private set; }

		public BoolSetting EnableAutoRotation { get; private set; }

		public BoolSetting EnableGizmos { get; private set; }

		public BoolSetting EnableTinkerPanel { get; private set; }

		public NumericSetting<float> GridSize { get; private set; }

		public BoolSetting OptimizeCraftXml { get; private set; }

		public NumericSetting<float> PanSensitivity { get; private set; }

		public NumericSetting<float> RotateSensitivity { get; private set; }

		public BoolSetting ShowAttachPoints { get; private set; }

		public BoolSetting ShowHiddenPartProperties { get; private set; }

		public BoolSetting UnlockTransparencySlider { get; private set; }

		public NumericSetting<float> ZoomSensitivity { get; private set; }

		public DesignerSettings()
			: base("Designer")
		{
		}

		protected override void InitializeSettings()
		{
			ZoomSensitivity = CreateNumeric("Zoom Sensitivity", 0.1f, 2.5f, 0.05f).SetState(SettingState.Enabled).SetDescription("Adjusts the sensitivity of the zooming the view in/out in the designer.").SetDisplayFormatter((float x) => x.ToString("F2"))
				.SetDefault(1f);
			RotateSensitivity = CreateNumeric("Rotate Sensitivity", 0.1f, 2.5f, 0.05f).SetState(SettingState.Enabled).SetDescription("Adjusts the sensitivity of rotating the view in the designer.").SetDisplayFormatter((float x) => x.ToString("F2"))
				.SetDefault(1f);
			PanSensitivity = CreateNumeric("Pan Sensitivity", 0.1f, 2.5f, 0.05f).SetDescription("Adjusts the sensitivity of the panning the view side to side in the designer.").SetDisplayFormatter((float x) => x.ToString("F2")).SetDefault(1f);
			AngleSnap = CreateNumeric("Angle Snap", 0f, 180f, 5f).SetState(SettingState.Hidden).SetDefault(15f);
			GridSize = CreateNumeric("Grid Size", 0f, 2f, 0.05f).SetState(SettingState.Hidden).SetDefault(0.1f);
			EnableAutoResize = CreateBool("Auto Resize").SetState(SettingState.Hidden).SetDefault(value: true);
			EnableSurfaceAttachments = CreateBool("Surface Attachments").SetState(SettingState.Hidden).SetDefault(value: true);
			EnableAutoRotation = CreateBool("Auto Rotation").SetState(SettingState.HiddenReadOnly).SetDefault(value: true);
			EnableGizmos = CreateBool("Show Gizmos").SetState(SettingState.Hidden).SetDefault(value: true);
			ShowAttachPoints = CreateBool("Show Attach Points").SetState(SettingState.Hidden).SetDefault(value: true);
			ShowHiddenPartProperties = CreateBool("Show Hidden Properties").SetState(SettingState.HiddenReadOnly).SetDefault(value: false);
			EnableTinkerPanel = CreateBool("Tinker Panel Enabled").SetState(SettingState.Hidden).SetDefault(value: false);
			OptimizeCraftXml = CreateBool("Optimize Craft XML").SetState(SettingState.Hidden).SetDefault(value: true);
			UnlockTransparencySlider = CreateBool("Unlock Transparency").SetState(SettingState.Hidden).SetDefault(value: false);
		}
	}
}
