using Gauges;
using JSAM;
using UnityEngine;
using Vehicles.FunctionalObjects;
using WorldEnvironment.FunctionalObjects;

namespace Vehicles.Plane
{
	public class Dashboard : MonoBehaviour
	{
		[Header("Mid Switches")]
		[SerializeField]
		private EnablerSwitch _batteryEnabler;

		[SerializeField]
		private EnablerSwitch _alternatorEnabler;

		[SerializeField]
		private EnablerSwitch _dashEnabler;

		[SerializeField]
		private EnablerSwitch _radioEnabler;

		[SerializeField]
		private EnablerSwitch _horizonEnabler;

		[Header("Left Switches")]
		[SerializeField]
		private EnablerSwitch _leftAlternator;

		[SerializeField]
		private EnablerSwitch _rightAlternator;

		[SerializeField]
		private SwitchHoldingPoint _startButton;

		[Header("Mid Lamps")]
		[SerializeField]
		private IndicatorLamp _batteryLamp;

		[SerializeField]
		private IndicatorLamp _alternatorLamp;

		[Header("Functional Objects")]
		[SerializeField]
		private Battery _battery;

		[SerializeField]
		private Alternator _alternator;

		[SerializeField]
		private Starter _starter;

		[SerializeField]
		private EngineComponent _engine;

		[Header("Gauges")]
		[SerializeField]
		private TimerGauge _clockGauge;

		[SerializeField]
		private TimerGauge _radioGauge;

		[SerializeField]
		private NeedleGauge _ampGauge;

		[SerializeField]
		private NeedleGauge _voltsGauge;

		[SerializeField]
		private NeedleGauge _speedGauge;

		[SerializeField]
		private NeedleGauge _speedGaugeSecond;

		[SerializeField]
		private NeedleGauge _fuelGauge;

		[SerializeField]
		private AltimeterGauge _altitudeGauge;

		[SerializeField]
		private AltimeterGauge _altitudeGaugeSecond;

		[SerializeField]
		private GyroGauge _gyroGauge;

		[SerializeField]
		private VerticalSpeedGauge _vertSpeedGauge;

		private void OnEnable()
		{
			_batteryEnabler.OnActivate.AddListener(OnBatterySwitchOn);
			_batteryEnabler.OnDeactivate.AddListener(OnBatterySwitchOff);
			_alternatorEnabler.OnActivate.AddListener(OnAlternatorSwitchOn);
			_alternatorEnabler.OnDeactivate.AddListener(OnAlternatorSwitchOff);
			_dashEnabler.OnActivate.AddListener(DashSwitchOn);
			_dashEnabler.OnDeactivate.AddListener(DashSwitchOff);
			_horizonEnabler.OnActivate.AddListener(EnableHorizon);
			_horizonEnabler.OnDeactivate.AddListener(DisableHorizon);
			_startButton.HoldingStart.AddListener(StartButtonHoldStart);
			_startButton.HoldingEnd.AddListener(StartButtonHoldEnd);
			_engine.OnEngineStarted += EngineStarted;
		}

		private void EngineStarted()
		{
			AudioManager.StopSoundIfPlaying(PlaneLibrarySounds.StarterLoop);
		}

		private void Start()
		{
			_batteryEnabler.UpdateState();
			_dashEnabler.UpdateState();
			_radioEnabler.UpdateState();
			_horizonEnabler.UpdateState();
		}

		private void EnableHorizon()
		{
			_gyroGauge.enabled = true;
		}

		private void DisableHorizon()
		{
			_gyroGauge.enabled = false;
		}

		private void StartButtonHoldStart()
		{
			_starter.StarterOn();
		}

		private void StartButtonHoldEnd()
		{
			if (_starter.Enabled)
			{
				_starter.StarterOff();
				if (!_engine.IsRunning)
				{
					AudioManager.PlaySound(PlaneLibrarySounds.StarterStalled);
				}
			}
		}

		private void DashSwitchOn()
		{
			EnableGaugesWithoutAT(value: true);
		}

		private void EnableGaugesWithoutAT(bool value)
		{
			_clockGauge.enabled = value;
			_radioGauge.enabled = value;
			_ampGauge.enabled = value;
			_voltsGauge.enabled = value;
			_speedGauge.enabled = value;
			_speedGaugeSecond.enabled = value;
			_fuelGauge.enabled = value;
			_altitudeGauge.enabled = value;
			_altitudeGaugeSecond.enabled = value;
			_vertSpeedGauge.enabled = value;
			_horizonEnabler.UpdateState();
		}

		private void DashSwitchOff()
		{
			EnableGaugesWithoutAT(value: false);
			_horizonEnabler.UpdateState();
		}

		private void OnAlternatorSwitchOn()
		{
			_alternatorLamp.DisableLamp();
			_alternator.TryEnable();
		}

		private void OnAlternatorSwitchOff()
		{
			_alternatorLamp.EnableLamp();
			_alternator.TryDisable();
		}

		private void OnBatterySwitchOn()
		{
			EnableAllSwitchers();
			_battery.TryEnable();
		}

		private void OnBatterySwitchOff()
		{
			DisableAllButBatteryEnabler();
			if (_engine.IsRunning)
			{
				_engine.StopEngine();
			}
			_battery.TryDisable();
		}

		private void DisableAllButBatteryEnabler()
		{
			_alternatorEnabler.Interactable = false;
			_dashEnabler.Interactable = false;
			_radioEnabler.Interactable = false;
			_horizonEnabler.Interactable = false;
			_leftAlternator.Interactable = false;
			_rightAlternator.Interactable = false;
			_startButton.Interactable = false;
			_batteryLamp.DisableLamp();
			_alternatorLamp.DisableLamp();
		}

		private void EnableAllSwitchers()
		{
			_alternatorEnabler.Interactable = true;
			_dashEnabler.Interactable = true;
			_radioEnabler.Interactable = true;
			_horizonEnabler.Interactable = true;
			_leftAlternator.Interactable = true;
			_rightAlternator.Interactable = true;
			_startButton.Interactable = true;
			_batteryLamp.EnableLamp();
			_alternatorEnabler.UpdateState();
		}
	}
}
