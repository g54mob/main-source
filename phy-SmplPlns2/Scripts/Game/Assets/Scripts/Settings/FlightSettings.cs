using Assets.Scripts.Multiplayer;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;

namespace Assets.Scripts.Settings
{
	public class FlightSettings : SettingsCategory<FlightSettings>
	{
		public BoolSetting MouseAsJoystickEnabled { get; private set; }

		public BoolSetting AllowCopyCraftXml { get; private set; }

		public NumericSetting<float> DragScale { get; set; }

		public BoolSetting GroundTrafficEnabled { get; private set; }

		public NumericSetting<float> LengthOfDay { get; private set; }

		public BoolSetting XRGripToggleEnabled { get; private set; }

		public FlightSettings()
			: base("Flight")
		{
		}

		protected override void InitializeSettings()
		{
			MouseAsJoystickEnabled = CreateBool("Mouse As Joystick").SetDescription("Enables or disables support for toggling the mouse as joystick control scheme during flight. (Bound to right mouse click by default)").SetState(SettingState.Enabled).SetState(DeviceFlags.Mobile, SettingState.Hidden)
				.SetDefault(value: true)
				.SetDefault(DeviceFlags.Mobile | DeviceFlags.SteamDeck, value: false);
			AllowCopyCraftXml = CreateBool("Allow Copy Craft Xml").SetState(SettingState.Hidden).SetDefault(value: true);
			GroundTrafficEnabled = CreateBool("Ground Traffic Enabled").SetState(SettingState.Hidden).SetDefault(DeviceFlags.Desktop, value: false);
			XRGripToggleEnabled = CreateBool("XR Grip Toggle").SetState(SettingState.Hidden).SetDefault(value: false);
			LengthOfDay = CreateNumeric("Length of Day", 0f, 1440f, 1f).SetState(SettingState.Hidden).SetDefault(120f);
			DragScale = CreateNumeric("Drag Scale", 0f, 2f, 0.1f).SetState(SettingState.Hidden).SetDefault(1f);
			AllowCopyCraftXml.Changed += OnAllowCopyCraftXmlChanged;
		}

		private void OnAllowCopyCraftXmlChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			NetworkPlayerScript networkPlayerScript = Game.Instance.NetworkGameManager?.LocalPlayer;
			if (networkPlayerScript != null)
			{
				networkPlayerScript.AllowCopyCraftXml = e.Setting.Value;
			}
		}
	}
}
