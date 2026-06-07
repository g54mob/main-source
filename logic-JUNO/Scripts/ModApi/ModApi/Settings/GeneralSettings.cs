using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.Ui;
using UnityEngine;

namespace ModApi.Settings
{
	public class GeneralSettings : SettingsCategory<GeneralSettings>
	{
		public enum MobileFileLoggingType
		{
			[EnumOption("None", "No file logging will occur after the game is initialized.")]
			None = 0,
			[EnumOption("Minimal", "Errors and warnings will be recorded and logged to a file during loading screens.")]
			Minimal = 1,
			[EnumOption("Full", "All log messages will be recorded and logged to a file during loading screens.")]
			Full = 2,
			[EnumOption("Realtime", "All log messages will be recorded and logged to a file as they are received.")]
			Realtime = 3
		}

		public NumericSetting<float> FieldOfView { get; private set; }

		public EnumSetting<MobileFileLoggingType> MobileFileLogging { get; private set; }

		public override int Order => -1;

		public BoolSetting RunInBackground { get; private set; }

		public NumericSetting<float> ScreenMarginLeftRight { get; private set; }

		public NumericSetting<float> ScreenMarginTopBottom { get; private set; }

		public BoolSetting SkipMainMenu { get; private set; }

		public BoolSetting SupportUnknownGamepadsOnAndroid { get; private set; }

		public ButtonSetting UIPreferencesButton { get; private set; }

		public BoolSetting UseDirectInput { get; private set; }

		public NumericSetting<float> UserInterfaceScale { get; private set; }

		public GeneralSettings()
			: base("General")
		{
		}

		protected override void InitializeSettings()
		{
			float min = 0.5f;
			float max = 2f;
			float num = 1f;
			if (Device.IsMobileBuild)
			{
				min = 0.75f;
				max = 1.5f;
				if (!Device.IsTablet)
				{
					num = 1.25f;
				}
			}
			UserInterfaceScale = CreateNumeric("User Interface Size", min, max, 0.05f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Increases or decreases the size of the user interface.").SetDefault(num);
			ScreenMarginLeftRight = CreateNumeric("User Interface Padding - Sides", 0f, 0.1f, 0.001f, "uiPaddingHorizontal").SetDefault(0f).SetDescription("This setting pulls in the UI from the side edges of the screen for devices that have notches or curved corners.").SetDisplayFormatter((float x) => $"{x * 100f:n1}%")
				.SetState((!Device.IsAndroidBuild) ? SettingState.Disabled : SettingState.Enabled);
			ScreenMarginTopBottom = CreateNumeric("User Interface Padding - Top/Bottom", 0f, 0.1f, 0.001f, "uiPaddingVertical").SetDefault(0f).SetDescription("This setting pulls in the UI from the top and bottom edges of the screen for devices that have notches or curved corners.").SetDisplayFormatter((float x) => $"{x * 100f:n1}%")
				.SetState((!Device.IsAndroidBuild) ? SettingState.Disabled : SettingState.Enabled);
			FieldOfView = CreateNumeric("Field of View", 20f, 120f, 1f).SetDescription("The field of view used by most of the game cameras.").SetDefault(60f);
			RunInBackground = CreateBool("Run In Background").SetDescription("If enabled, the game will continue to run while minimized or not in focus.").SetState(DeviceFlags.Mobile, SettingState.Disabled).SetDefault(Application.isEditor);
			MobileFileLogging = CreateEnum<MobileFileLoggingType>("File Logging").SetDescription("Determines how the game handles file logging for errors, warnings and other log messages.").SetState(DeviceFlags.All, SettingState.Disabled).SetState(DeviceFlags.Mobile, SettingState.Enabled)
				.SetDefault(MobileFileLoggingType.Minimal);
			SkipMainMenu = CreateBool("Skip Main Menu").SetState(SettingState.Hidden).SetDefault(value: false);
			UseDirectInput = CreateBool("Use Direct Input").SetState(SettingState.Hidden).SetDefault(value: false);
			SupportUnknownGamepadsOnAndroid = CreateBool("Support Unknown Gamepads On Android").SetState(SettingState.Hidden).SetDefault(value: true);
			UIPreferencesButton = CreateButton("UI Preferences", "Reset").AddClickEvent(OnUIPreferencesReset);
			RunInBackground.Changed += delegate(object s, SettingChangedEventArgs<bool> e)
			{
				Application.runInBackground = e.Setting;
			};
			RunInBackground.RaiseSettingChangedEvent();
		}

		private void OnUIPreferencesReset(object sender, SettingChangedEventArgs<int> setting)
		{
			Game.Instance.Settings.UserPrefs.Remove((string x) => x.StartsWith("InspectorPanel.") || x.StartsWith("FlightLog."));
			Game.Instance.Settings.Save();
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
			messageDialogScript.MessageText = "UI Preferences have been reset. Reload the current scene for the changes to take effect.";
			Debug.Log(messageDialogScript.MessageText);
		}
	}
}
