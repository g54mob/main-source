using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class CameraSettings : SettingsCategory<CameraSettings>
	{
		public NumericSetting<float> CameraSensitivityFPV { get; private set; }

		public NumericSetting<float> CameraSmoothingFPV { get; private set; }

		public NumericSetting<float> CharacterFPVChickenHead { get; private set; }

		public BoolSetting ChasedByPedro { get; private set; }

		public NumericSetting<float> FieldOfView { get; private set; }

		public NumericSetting<float> FieldOfViewCharacterFPV { get; private set; }

		public CameraSettings()
			: base("Camera")
		{
		}

		protected override void InitializeSettings()
		{
			CameraSensitivityFPV = CreateNumeric("Camera Speed FPV", 0.1f, 2f, 0.1f).SetDescription("Adjusts the sensitivity of the first-person camera when outside the craft.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(1f);
			CameraSmoothingFPV = CreateNumeric("Camera Smoothing FPV", 0f, 4f, 0.1f).SetDescription("Adjusts the smoothing of the first-person camera when outside the craft.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(1f);
			FieldOfView = CreateNumeric("Field of View", 20f, 120f, 1f).SetDescription("The field of view used by most of the game cameras.").SetDefault(60f);
			FieldOfViewCharacterFPV = CreateNumeric("Field of View Character FPV", 20f, 120f, 1f).SetDescription("The field of view used for the character in first-person.").SetDefault(80f);
			CharacterFPVChickenHead = CreateNumeric("Character FPV Tilt Sensitivity", 0f, 100f, 1f).SetDescription("How sensitive the character camera will be to roll, higher values will make it more snappy.").SetDefault(50f);
			ChasedByPedro = CreateBool("Chased by Pedro").SetDescription("This toggles between a clearly better chase camera and looking sad at the ground.").SetDefault(value: false).SetState(SettingState.Hidden);
		}
	}
}
