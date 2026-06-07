using System;
using ModApi.Settings.Core;
using UnityEngine;

namespace ModApi.Settings
{
	public class FlightSettings : SettingsCategory<FlightSettings>
	{
		public NumericSetting<float> AmbientLightAtNightStrength { get; private set; }

		public BoolSetting AmbientLightAttenuation { get; private set; }

		public NumericSetting<float> AmbientLightInSpaceStrength { get; private set; }

		public BoolSetting AstronautFollowCamera { get; private set; }

		public NumericSetting<float> CameraSensitivity { get; private set; }

		public NumericSetting<float> CameraSensitivityFps { get; private set; }

		public NumericSetting<float> CameraShake { get; private set; }

		public NumericSetting<float> CameraSmoothingChase { get; private set; }

		public NumericSetting<float> CameraSmoothingFps { get; private set; }

		public NumericSetting<float> CameraSpeed { get; private set; }

		public NumericSetting<float> DragScale { get; set; }

		public NumericSetting<float> FastForwardSpeed { get; private set; }

		public NumericSetting<float> GravityScale { get; set; }

		public NumericSetting<float> HeatDamageScale { get; set; }

		public NumericSetting<float> ImpactDamageScale { get; set; }

		public BoolSetting ShowFlightViewInspector { get; private set; }

		public BoolSetting ShowNavSphere { get; private set; }

		public BoolSetting ShowNavSphereInMapView { get; private set; }

		public NumericSetting<float> SlowMotionSpeed { get; private set; }

		public NumericSetting<float> StarSkyboxExposure { get; private set; }

		public StringSetting VisibleFlightInputSliders { get; private set; }

		public FlightSettings()
			: base("Flight")
		{
		}

		protected override void InitializeSettings()
		{
			ShowNavSphere = CreateBool("Show Nav Sphere").SetState(SettingState.Hidden).SetDefault(value: true);
			ShowNavSphereInMapView = CreateBool("Show Nav Sphere in Map View").SetState(SettingState.Hidden).SetDefault(value: false);
			ShowFlightViewInspector = CreateBool("Show Flight View Inspector").SetState(SettingState.Hidden).SetDefault(value: false);
			AstronautFollowCamera = CreateBool("Astronaut Follows Camera").SetState(SettingState.Hidden).SetDefault(value: true);
			DragScale = CreateNumeric("Drag Scale", 0f, 2f, 0.1f).SetState(SettingState.Hidden).SetDefault(1f);
			GravityScale = CreateNumeric("Gravity Scale", 0f, 2f, 0.1f).SetState(SettingState.Hidden).SetDefault(1f);
			HeatDamageScale = CreateNumeric("Heat Damage", 0f, 2f, 0.1f).SetState(SettingState.Hidden).SetDefault(1f);
			ImpactDamageScale = CreateNumeric("Physical Damage", 0f, 2f, 0.1f).SetState(SettingState.Hidden).SetDefault(1f);
			AmbientLightAttenuation = CreateBool("Ambient Light Attenuation").SetDescription("Enables or disables ambient light attenuation. When enabled, ambient light is only applied to an area centered on the game camera, falling off to nothing in the distance.").SetDefault(value: true);
			AmbientLightAtNightStrength = CreateNumeric("Ambient Light At Night", 0f, 3f, 0.1f).SetDescription("Adjusts the strength of the ambient lighting at night.").SetDisplayFormatter((float x) => System.Math.Round(x * 100f).ToString("F0") + "%").SetDefault(1f);
			AmbientLightInSpaceStrength = CreateNumeric("Ambient Light In Space", 0f, 3f, 0.1f).SetDescription("Adjusts the strength of the ambient lighting in space.").SetDisplayFormatter((float x) => System.Math.Round(x * 100f).ToString("F0") + "%").SetDefault(1f);
			StarSkyboxExposure = CreateNumeric("Star Brightness", 0f, 2f, 0.1f).SetDescription("Adjusts the strength of the stars in the background.").SetDisplayFormatter((float x) => System.Math.Round(x * 100f).ToString("F0") + "%").SetDefault(1f);
			CameraShake = CreateNumeric("Camera Shake", 0f, 2f, 0.1f).SetDescription("Adjusts the strength of the camera shake in flight.").SetDisplayFormatter((float x) => System.Math.Round(x * 100f).ToString("F0") + "%").SetDefault(1f);
			CameraSpeed = CreateNumeric("Camera Speed", 1f, 10f, 1f).SetDescription("Adjusts the rotation speed of the flight camera. The higher this is, the less 'floaty' the camera will feel.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(2f);
			CameraSensitivity = CreateNumeric("Camera Sensitivity", 1f, 10f, 1f).SetDescription("Adjusts the sensitivity of the flight camera.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(2f);
			CameraSmoothingChase = CreateNumeric("Chase Camera Smoothing", 1f, 10f, 1f).SetDescription("Adjusts the smoothing of the chase camera.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(7f);
			CameraSmoothingFps = CreateNumeric("FPS Camera Smoothing", 0f, 4f, 0.1f).SetDescription("Adjusts the smoothing of the first-person camera when controlling an astronaut.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(1f);
			CameraSensitivityFps = CreateNumeric("FPS Camera Speed", 0.1f, 2f, 0.1f).SetDescription("Adjusts the sensitivity of the first-person camera when controlling an astronaut.").SetDisplayFormatter((float x) => x.ToString("F1")).SetDefault(1f);
			SlowMotionSpeed = CreateNumeric("Slow-Mo Speed", 4f, 20f, 1f).SetDescription("Adjust the slow motion speed.").SetDisplayFormatter((float x) => $"{x}x").SetDefault(4f);
			FastForwardSpeed = CreateNumeric("Fast Forward Speed", 2f, Debug.isDebugBuild ? 20f : 10f, 1f).SetDescription("Adjusts the fast forward speed.  Setting this too high can cause performance problems during fast forward. This setting does not impact warp speeds.").AddWarning((float x) => x > 2f, "Increasing the fast forward speed will reduce the framerate while in fast forward.  Smaller crafts may not show a significant impact, but larger crafts may result in extreme frame-rate drops.  The \"Physics Update Frequency\" setting can be lowered to allow a higher fast forward with reduced framerate drop. This setting does not impact framerate during warping.").SetDisplayFormatter((float x) => $"{x}x")
				.SetDefault(2f);
			VisibleFlightInputSliders = CreateString("Visible Input Sliders").SetState(SettingState.Hidden).SetDefault(string.Empty);
		}
	}
}
