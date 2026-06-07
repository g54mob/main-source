using System;
using Assets.Scripts.Environment;
using Assets.Scripts.Environment.Roads;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Extensions;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class SettingsPanelScript : FlightPanelScript
	{
		private enum AiAirTrafficDensity
		{
			None = 0,
			Sparse = 1,
			Normal = 2,
			Dense = 3
		}

		private enum AiGroundTrafficDensity
		{
			None = 0,
			Normal = 2
		}

		private EnumSpinnerControl<AiAirTrafficDensity> _aiTrafficAir;

		private EnumSpinnerControl<AiGroundTrafficDensity> _aiTrafficGround;

		private ToggleControl _allowCopy;

		private SliderControl _lengthOfDay;

		private SliderControl _maxCars;

		private SliderControl _timeOfDay;

		private float _updateTimeOfDayTime;

		private EnumSpinnerControl<WeatherPreset> _weather;

		private WindSettingsDialogScript _windSettingsDialog;

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			_timeOfDay = new SliderControl(base.Widget.FindWidget("time-of-day-slider"));
			_timeOfDay.ValueFormatter = (float x) => $"{x:n0}°";
			_timeOfDay.Slider.MinValue = 0f;
			_timeOfDay.Slider.MaxValue = 24f;
			_timeOfDay.ValueFormatter = (float x) => ConvertTimeOfDayToString(x);
			_timeOfDay.Slider.ValueChanged += delegate(float x)
			{
				FlightSceneScript.Instance.Environment.UpdateTimeOfDay(x, 1f);
			};
			_lengthOfDay = new SliderControl(base.Widget.FindWidget("length-of-day-slider"));
			_lengthOfDay.ValueFormatter = (float x) => $"{x:n0}°";
			_lengthOfDay.Slider.MinValue = 0f;
			_lengthOfDay.Slider.MaxValue = 120f;
			_lengthOfDay.ValueFormatter = (float x) => (x > 0f) ? ($"{x:n0} minute" + ((x != 1f) ? "s" : string.Empty)) : "Forever";
			_lengthOfDay.Slider.ValueChanged += delegate(float x)
			{
				FlightSceneScript.Instance.Environment.LengthOfDay = x;
				Game.Instance.Settings.Gameplay.Flight.LengthOfDay.Value = x;
				Game.Instance.Settings.Gameplay.Flight.CommitChanges();
			};
			_weather = new EnumSpinnerControl<WeatherPreset>(base.Widget.FindWidget("weather-spinner"));
			_weather.Value = FlightSceneScript.Instance.Environment.WeatherType;
			_weather.OnLabelRequested = (WeatherPreset x) => FlightSceneScript.Instance.Environment.WeatherType.DisplayName();
			_weather.RefreshLabel();
			EnumSpinnerControl<WeatherPreset> weather = _weather;
			weather.OnValueChanging = (OnValueChanging<WeatherPreset>)Delegate.Combine(weather.OnValueChanging, (OnValueChanging<WeatherPreset>)delegate(WeatherPreset _, WeatherPreset x)
			{
				FlightSceneScript.Instance.Environment.UpdateWeather(x, 5f, ignorePause: true);
			});
			_maxCars = new SliderControl(base.Widget.FindWidget("max-cars-slider"));
			_maxCars.Slider.MinValue = 0f;
			_maxCars.Slider.MaxValue = 50f;
			_maxCars.Slider.NumberOfSteps = (int)_maxCars.Slider.MaxValue + 1;
			_maxCars.Slider.Value = CarSpawnerScript.MaxCars;
			_maxCars.Slider.ValueChanged += delegate(float x)
			{
				CarSpawnerScript.MaxCars = (int)x;
			};
			_aiTrafficGround = new EnumSpinnerControl<AiGroundTrafficDensity>(base.Widget.FindWidget("ai-traffic-ground-spinner"));
			EnumSpinnerControl<AiGroundTrafficDensity> aiTrafficGround = _aiTrafficGround;
			aiTrafficGround.OnValueChanged = (OnValueChanged<AiGroundTrafficDensity>)Delegate.Combine(aiTrafficGround.OnValueChanged, (OnValueChanged<AiGroundTrafficDensity>)delegate(AiGroundTrafficDensity _, AiGroundTrafficDensity x)
			{
				Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled.Value = x != AiGroundTrafficDensity.None;
				Game.Instance.Settings.Gameplay.Flight.CommitChanges();
				Game.Instance.Settings.Gameplay.Save();
			});
			_aiTrafficGround.Visible = false;
			_aiTrafficAir = new EnumSpinnerControl<AiAirTrafficDensity>(base.Widget.FindWidget("ai-traffic-air-spinner"));
			EnumSpinnerControl<AiAirTrafficDensity> aiTrafficAir = _aiTrafficAir;
			aiTrafficAir.OnValueChanged = (OnValueChanged<AiAirTrafficDensity>)Delegate.Combine(aiTrafficAir.OnValueChanged, (OnValueChanged<AiAirTrafficDensity>)delegate(AiAirTrafficDensity _, AiAirTrafficDensity x)
			{
				AiManagerScript.AiSettings.MaxAiTrafficCount = (int)x;
			});
			_aiTrafficAir.Visible = false;
			_allowCopy = new ToggleControl(base.Widget.FindWidget("allow-copy-toggle"));
			_allowCopy.Toggle.IsOn = Game.Instance.Settings.Gameplay.Flight.AllowCopyCraftXml.Value;
			_allowCopy.Toggle.ValueChanged += delegate(bool x)
			{
				Game.Instance.Settings.Gameplay.Flight.AllowCopyCraftXml.Value = x;
				Game.Instance.Settings.Gameplay.Flight.AllowCopyCraftXml.CommitChanges();
			};
			base.Flyout.Opened += delegate
			{
				_lengthOfDay.Slider.Value = FlightSceneScript.Instance.Environment.LengthOfDay;
				_timeOfDay.Slider.Value = FlightSceneScript.Instance.Environment.TimeOfDay;
				_aiTrafficAir.Value = (AiAirTrafficDensity)AiManagerScript.AiSettings.MaxAiTrafficCount;
				_aiTrafficGround.Value = (Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled.Value ? AiGroundTrafficDensity.Normal : AiGroundTrafficDensity.None);
			};
		}

		public void ToggleWindSettings()
		{
			if (_windSettingsDialog != null)
			{
				_windSettingsDialog.Close();
				_windSettingsDialog = null;
				return;
			}
			_windSettingsDialog = Game.Instance.UserInterface.CreateDialog<WindSettingsDialogScript>("Xml/Flight/WindSettingsDialog");
			_windSettingsDialog.Closed += delegate
			{
				_windSettingsDialog = null;
			};
		}

		protected void Update()
		{
			if (_timeOfDay.Slider.IsPointerPressed)
			{
				_updateTimeOfDayTime = Time.unscaledTime + 2f;
			}
			else if (Time.unscaledTime > _updateTimeOfDayTime)
			{
				_timeOfDay.Slider.Value = FlightSceneScript.Instance.Environment.TimeOfDay;
			}
		}

		private static string ConvertTimeOfDayToString(float timeOfDay)
		{
			int num = (int)(timeOfDay * 60f);
			int num2 = num / 60;
			int num3 = num % 60;
			return $"{num2:D2}:{num3:D2}";
		}

		private void OnGameSettingsClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateSettingsDialog();
		}

		private void OnWindSettingsClicked(Widget widget)
		{
			ToggleWindSettings();
		}
	}
}
