using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Levels;
using Jundroo.Common.Cache;
using Jundroo.Common.Math;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class InstrumentPanelScript : WidgetScript
	{
		private TextWidget _altitudeLabel;

		private CachedFloatString _altitudeLabelCache = new CachedFloatString(0.1f, (float x) => x.Format(UnitType.ShortDistance, solo: true, longName: false, "#,###,###"));

		private TextWidget _altitudeTypeLabel;

		private Widget _attitudeInstrument;

		private Widget _compass;

		private TextWidget _engineGearNameText;

		private ImageWidget _engineRpmFill;

		private Widget _engineRpmInstrument;

		private TextWidget _engineRpmText;

		private FlightUIScript _flightUI;

		private TextWidget _fuelLabel;

		private CachedIntString _fuelLabelCache = new CachedIntString((int x) => x + "%");

		private ImageWidget _fuelProgress;

		private TextWidget _headingLabel;

		private CachedIntString _headingLabelCache = new CachedIntString((int x) => $"{x:000}°");

		private Widget _headingLock;

		private Widget _parkingBrake;

		private bool _parkingBrakeState;

		private Widget _pitchWidget;

		private IPowertrain _powertrain;

		private bool _preferRpmGauge;

		private bool _refreshPrimaryInstrument;

		private Widget _rollWidget;

		private TextWidget _speedLabel;

		private CachedFloatString _speedLabelCache = new CachedFloatString(0.1f, (float x) => x.Format(UnitType.Speed, solo: true, longName: false, "0"));

		private TextWidget _speedTypeLabel;

		private TextWidget _throttleLabel;

		private CachedIntString _throttleLabelCache = new CachedIntString((int x) => x + "%");

		private ImageWidget _throttleProgress;

		private bool _useAgl = true;

		public AircraftScript.SpeedType CurrentSpeedType { get; set; }

		public void Initialize(FlightUIScript flightUI, Widget root)
		{
			_flightUI = flightUI;
			_engineRpmInstrument = root.FindWidget("rpm-instrument");
			_engineRpmFill = root.FindWidget<ImageWidget>("engine-rpm-fill");
			_engineRpmText = root.FindWidget<TextWidget>("engine-rpm-text");
			_engineGearNameText = root.FindWidget<TextWidget>("gear-name-text");
			_attitudeInstrument = root.FindWidget("attitude-instrument");
			_rollWidget = root.FindWidget("attitude-roll");
			_pitchWidget = root.FindWidget("attitude-pitch");
			_headingLabel = root.FindWidget<TextWidget>("heading-text");
			_fuelLabel = root.FindWidget<TextWidget>("fuel-text");
			_fuelProgress = root.FindWidget<ImageWidget>("fuel-progress");
			_throttleLabel = root.FindWidget<TextWidget>("throttle-text");
			_throttleProgress = root.FindWidget<ImageWidget>("throttle-progress");
			_speedLabel = root.FindWidget<TextWidget>("speed-text");
			_speedTypeLabel = root.FindWidget<TextWidget>("speed-type-text");
			_altitudeLabel = root.FindWidget<TextWidget>("altitude-text");
			_altitudeTypeLabel = root.FindWidget<TextWidget>("altitude-type-text");
			_compass = root.FindWidget("compass");
			_headingLock = root.FindWidget("heading-lock");
			_parkingBrake = root.FindWidget("parking-brake-button");
			root.FindWidget<TextWidget>("speed-unit-text").Text = Game.Instance.Settings.Gameplay.General.UnitSystem.Units[UnitType.Speed].Abbreviation;
			root.FindWidget<TextWidget>("altitude-unit-text").Text = Game.Instance.Settings.Gameplay.General.UnitSystem.Units[UnitType.ShortDistance].Abbreviation;
			CurrentSpeedType = (AircraftScript.SpeedType)PlayerPrefs.GetInt("SpeedType", 0);
			UpdateSpeedTypeText();
			UpdateAltitudeTypeText();
		}

		protected virtual void LateUpdate()
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			InstrumentData? instrumentData = aircraftScript?.InstrumentData;
			IPowertrain powertrain = aircraftScript?.Powertrain?.PrimaryPowertrain;
			UpdatePrimaryInstrument(powertrain, instrumentData);
			float num = instrumentData?.Throttle ?? 0f;
			int currentValue = (int)(num * 100f);
			_throttleLabel.Text = _throttleLabelCache.Update(currentValue);
			_throttleProgress.Image.fillAmount = Mathf.Clamp01(num);
			float num2 = (instrumentData?.Fuel ?? 0f) * 100f + 1f;
			if (num2 > 100f)
			{
				num2 = 100f;
			}
			else if (num2 <= 1.005f)
			{
				num2 = 0f;
			}
			_fuelLabel.Text = _fuelLabelCache.Update((int)num2);
			_fuelProgress.Image.fillAmount = Mathf.Clamp01(instrumentData?.Fuel ?? 0f);
			_altitudeLabel.Text = _altitudeLabelCache.Update(((!_useAgl) ? instrumentData?.Altitude : aircraftScript?.AltitudeAgl).GetValueOrDefault());
			_speedLabel.Text = _speedLabelCache.Update(aircraftScript?.GetSpeed(CurrentSpeedType) ?? 0f);
			int num3 = (int)(instrumentData?.Heading ?? 0f);
			string text = _headingLabelCache.Update(num3);
			_headingLabel.Text = text;
			_compass.transform.localRotation = Quaternion.Euler(0f, 0f, num3);
			_headingLock.Visible = aircraftScript?.Controls.HasInputOverrides ?? false;
			bool valueOrDefault = aircraftScript?.Controls?.ParkingBrake == true;
			if (_parkingBrakeState != valueOrDefault)
			{
				_parkingBrakeState = valueOrDefault;
				_parkingBrake.EnableClass("btn-flight-selected", _parkingBrakeState);
			}
		}

		private void OnAltitudeTypeButtonClicked(Widget widget)
		{
			_useAgl = !_useAgl;
			UpdateAltitudeTypeText();
		}

		private void OnHeadingClicked(Widget widget)
		{
			LevelBase.CurrentLevel.ToggleAutopilot();
		}

		private void OnHideClicked(Widget wigdet)
		{
			_flightUI.ShowActivationPanel();
		}

		private void OnParkingBrakeClicked(Widget widget)
		{
			AircraftControls aircraftControls = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.Controls;
			if (aircraftControls != null)
			{
				aircraftControls.ParkingBrake = !aircraftControls.ParkingBrake;
				string message = "Parking brake " + (aircraftControls.ParkingBrake ? "engaged" : "disengaged");
				_flightUI.ShowMessage(message, 1f);
			}
		}

		private void OnPrimaryInstrumentClicked(Widget widget)
		{
			_preferRpmGauge = !_preferRpmGauge;
			_refreshPrimaryInstrument = true;
		}

		private void OnSpeedTypeButtonClicked(Widget widget)
		{
			CurrentSpeedType++;
			if (!Enum.IsDefined(typeof(AircraftScript.SpeedType), CurrentSpeedType))
			{
				CurrentSpeedType = AircraftScript.SpeedType.IAS;
			}
			UpdateSpeedTypeText();
			PlayerPrefs.SetInt("SpeedType", (int)CurrentSpeedType);
		}

		private void UpdateAltitudeTypeText()
		{
			_altitudeTypeLabel.Text = (_useAgl ? "AGL" : "ASL");
		}

		private void UpdatePrimaryInstrument(IPowertrain powertrain, InstrumentData? instrumentData)
		{
			if (_powertrain != powertrain)
			{
				_refreshPrimaryInstrument = true;
				_powertrain = powertrain;
				_preferRpmGauge = _powertrain?.PrimaryTransmission != null;
			}
			if (_refreshPrimaryInstrument)
			{
				_refreshPrimaryInstrument = false;
				_engineRpmInstrument.Visible = _powertrain != null && _preferRpmGauge;
				_attitudeInstrument.Visible = !_engineRpmInstrument.Visible;
			}
			if (_engineRpmInstrument.Visible)
			{
				float fillAmount = powertrain.EngineRpm / Mathf.Max(1f, powertrain.EngineMaxRpm);
				_engineRpmFill.EnableClass("rpm-redline", powertrain.EngineRpm > powertrain.EngineRedlineRpm);
				_engineRpmFill.Image.fillAmount = fillAmount;
				_engineRpmText.Text = $"{powertrain.EngineRpm:n0}";
				_engineGearNameText.Text = powertrain.PrimaryTransmission?.CurrentGearName ?? string.Empty;
				return;
			}
			_rollWidget.transform.rotation = Quaternion.Euler(0f, 0f, 0f - (instrumentData?.Roll ?? 0f));
			float num = (0f - (instrumentData?.Pitch ?? 0f)) * 19.5f / 10f;
			if (num > 175f)
			{
				num = 175f;
			}
			else if (num < -175f)
			{
				num = -175f;
			}
			_pitchWidget.transform.localPosition = new Vector3(0f, num, 0f);
		}

		private void UpdateSpeedTypeText()
		{
			_speedTypeLabel.Text = Enum.GetName(typeof(AircraftScript.SpeedType), CurrentSpeedType);
		}
	}
}
