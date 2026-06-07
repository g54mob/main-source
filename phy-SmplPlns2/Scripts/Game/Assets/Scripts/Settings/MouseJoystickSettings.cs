using Assets.Scripts.Input;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class MouseJoystickSettings : SettingsCategory<MouseJoystickSettings>
	{
		public NumericSetting<float> MouseJoystickDeadzone { get; private set; }

		public BoolSetting MouseJoystickEnabled { get; private set; }

		public BoolSetting MouseJoystickInvertPitch { get; private set; }

		public NumericSetting<float> MouseJoystickRange { get; private set; }

		public override int Order => -1;

		public MouseJoystickSettings()
			: base("Mouse Joystick")
		{
			base.State = SettingState.Hidden;
		}

		public void RestoreDefaults()
		{
			MouseJoystickEnabled.Value = false;
			MouseJoystickInvertPitch.Value = false;
			MouseJoystickDeadzone.Value = 0.1f;
			MouseJoystickRange.Value = 0.9f;
		}

		protected override void InitializeSettings()
		{
			MouseJoystickEnabled = CreateBool("Mouse As Joystick Enabled").SetDefault(value: false);
			MouseJoystickInvertPitch = CreateBool("Invert Mouse Joystick Pitch").SetDefault(value: false);
			MouseJoystickDeadzone = CreateNumeric("Mouse Joystick Deadzone", 0.05f, 0.5f, 0.05f).SetDefault(0.1f);
			MouseJoystickRange = CreateNumeric("Mouse Joystick Range", 0.5f, 1f, 0.05f).SetDefault(0.9f);
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
