using DV.CabControls;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.Utils;
using DV.WeatherSystem;
using DV.Wheels;
using TMPro;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetControlPanelLODObject : CustomizerLODObject<GadgetControlPanel>
	{
		private const float BAR_TEMP_MIN = 30f;

		private const float BAR_TEMP_MAX = 120f;

		private const float UPDATE_INTERVAL = 0.125f;

		private const string FORMAT_PRESSURE = "0.0";

		private const string FORMAT_TEMPERATURE = "0";

		private const string FORMAT_AMPERAGE = "0";

		private const string FORMAT_QUANTITY = "0";

		private const string FORMAT_RPM = "0.0";

		[Header("Joysticks")]
		public JoystickDriver joystickThr;

		public JoystickDriver joystickRev;

		public JoystickDriver joystickBrkTrn;

		public JoystickDriver joystickBrkInd;

		public JoystickDriver joystickBrkDyn;

		public JoystickDriver joystickHorn;

		public JoystickDriver joystickSander;

		public JoystickDriver joystickWipers;

		public JoystickDriver joystickLightsCab;

		public JoystickDriver joystickLightsF;

		public JoystickDriver joystickLightsR;

		[Header("Buttons")]
		public Button btnStart;

		public Button btnCutoff;

		[Header("LED Bars")]
		public LedBarDriverBase barThr;

		public LedBarDriverBase barAmps;

		public LedBarDriverBase barTemp;

		public LedBarDriverBase barSander;

		public LedBarDriverBase barTacho;

		public LedBarDriverBase barTurbine;

		public LedBarDriverBase barPressurePipe;

		public LedBarDriverBase barPressureRes;

		public LedBarDriverBase barPressureCyl;

		public LedBarDriverBase barBrkTrn;

		public LedBarDriverBase barBrkInd;

		public LedBarDriverBase barBrkDyn;

		public LedBarDriverBase barFuel;

		public LedBarDriverBase barOil;

		public LedBarDriverBase barSand;

		[Header("Text Meshes")]
		public TextMeshPro textAmps;

		public TextMeshPro textTemp;

		public TextMeshPro textReverser;

		public TextMeshPro textSpd;

		public TextMeshPro texTacho;

		public TextMeshPro textTurbine;

		public TextMeshPro textPressurePipe;

		public TextMeshPro textPressureRes;

		public TextMeshPro textPressureCyl;

		public TextMeshPro textFuel;

		public TextMeshPro textOil;

		public TextMeshPro textSand;

		[Header("Lamps")]
		public LampControl lampEngine;

		public LampControl lampAmp;

		public LampControl lampTemp;

		public LampControl lampSlip;

		public LampControl lampSander;

		public LampControl lampRPM;

		public LampControl lampBrakes;

		public LampControl lampFuel;

		public LampControl lampOil;

		public LampControl lampSand;

		public LampControl lampWipers;

		public LampControl lampLightCab;

		public LampControl lampLightF;

		public LampControl lampLightR;

		[Header("Other")]
		public Transform panel;

		public Vector3 tiltAxis;

		public Rotary tiltKnob;

		private ControlImplBase tiltControl;

		private SteppedJoint tiltStepJoint;

		private float panelDegreesPerKnobRound;

		private float smoothedTilt;

		private MultipleUnitStateObserver muTempAndWheelslipObserver;

		private WheelSlideTrainsetObserver wheelSlideObserver;

		private float faultChance;

		private float faultTimer;

		private bool on;

		private bool isInFaultState;

		private float updateTimer;

		private ControlImplBase buttonControlStart;

		private ControlImplBase buttonControlCutoff;

		private BrakeWarningChecker warningChecker;

		private void Awake()
		{
			warningChecker = new BrakeWarningChecker();
			warningChecker.BrakeWarningChanged += delegate(bool b)
			{
				lampBrakes.SetLampState(b ? LampControl.LampState.Blinking : LampControl.LampState.Off);
			};
		}

		private void Start()
		{
			panelDegreesPerKnobRound = 360f / (float)base.Base.TiltKnobRate;
			tiltStepJoint = tiltKnob.GetComponent<SteppedJoint>();
			tiltControl = tiltKnob.GetComponent<ControlImplBase>();
			tiltControl.SetValue(Mathf.Repeat(base.Base.tilt, panelDegreesPerKnobRound) / panelDegreesPerKnobRound);
			smoothedTilt = base.Base.tilt;
			panel.localRotation = Quaternion.AngleAxis(smoothedTilt, tiltAxis);
			tiltStepJoint.PositionChanged += TiltChanged;
			joystickThr.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.Throttle);
			};
			joystickRev.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.Reverser);
			};
			joystickBrkTrn.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.TrainBrake);
			};
			joystickBrkInd.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.IndBrake);
			};
			joystickBrkDyn.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.DynamicBrake);
			};
			joystickHorn.ValueUpdated += UpdateHornUsingJoystick;
			joystickSander.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.Sander);
			};
			joystickWipers.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.Wipers);
			};
			joystickLightsCab.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.CabLight);
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.IndCabLight);
			};
			joystickLightsF.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.HeadlightsFront);
			};
			joystickLightsR.ValueUpdated += delegate(float v)
			{
				UpdateOverridableControlUsingJoystick(v, InteriorControlsManager.ControlType.HeadlightsRear);
			};
			buttonControlStart = btnStart.GetComponent<ControlImplBase>();
			buttonControlCutoff = btnCutoff.GetComponent<ControlImplBase>();
			buttonControlStart.ValueChanged += ButtonStartUpdated;
			buttonControlCutoff.ValueChanged += ButtonCutoffUpdated;
		}

		private void TiltChanged(ValueChangedEventArgs valueChanged)
		{
			base.Base.tilt = Mathf.Repeat(base.Base.tilt + valueChanged.delta / (float)tiltStepJoint.notches * panelDegreesPerKnobRound, 360f);
		}

		private void OnEnable()
		{
			muTempAndWheelslipObserver = ((base.Base.TrainCar != null) ? base.Base.TrainCar.GetComponent<MultipleUnitStateObserver>() : null);
			wheelSlideObserver = ((base.Base.TrainCar != null) ? base.Base.TrainCar.GetComponent<WheelSlideTrainsetObserver>() : null);
		}

		private void OnDisable()
		{
			muTempAndWheelslipObserver = null;
			wheelSlideObserver = null;
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			if (on != newValue)
			{
				on = newValue;
				if (on)
				{
					updateTimer = 0f;
					UpdateDisplay();
				}
				else
				{
					ClearDisplay();
					base.Base.Controls?.Horn?.Set(0f);
				}
				warningChecker.SetTrainCar(on ? base.Base.TrainCar : null);
			}
		}

		private void Update()
		{
			smoothedTilt += Mathf.DeltaAngle(smoothedTilt, base.Base.tilt) * Time.deltaTime * 10f;
			panel.localRotation = Quaternion.AngleAxis(smoothedTilt, tiltAxis);
			faultChance = (base.Base.IsExposedToOutside ? SingletonBehaviour<WeatherDriver>.Instance.RainValue.CurrentValue : 0f);
			if (on)
			{
				UpdateDisplay();
			}
		}

		private bool IsJoystickValueActive(float value)
		{
			if (base.Base.PowerState)
			{
				return Mathf.Abs(value) > 0.1f;
			}
			return false;
		}

		private bool SampleRandomFault()
		{
			return Random.value < faultChance;
		}

		private void UpdateOverridableControlUsingJoystick(float value, InteriorControlsManager.ControlType type)
		{
			if (IsJoystickValueActive(value) && !isInFaultState)
			{
				base.Base.Controls?.GetControl(type)?.Move(Mathf.Sign(value));
			}
		}

		private void UpdateHornUsingJoystick(float value)
		{
			if (base.Base.PowerState && !isInFaultState)
			{
				base.Base.Controls?.Horn?.Set(Mathf.Abs(value));
			}
		}

		private void ButtonStartUpdated(ValueChangedEventArgs value)
		{
			if (base.Base.PowerState || value.newValue == 0f)
			{
				base.Base.Controls?.Starter?.Set(value.newValue);
			}
		}

		private void ButtonCutoffUpdated(ValueChangedEventArgs value)
		{
			if (base.Base.PowerState || value.newValue == 0f)
			{
				base.Base.Controls?.PowerOff?.Set(value.newValue);
			}
		}

		private void UpdateDisplay()
		{
			updateTimer -= Time.deltaTime;
			if (updateTimer > 0f)
			{
				return;
			}
			updateTimer += 0.125f;
			isInFaultState = SampleRandomFault();
			float? num = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.Temperature));
			float? num2 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.TractionMotorAmps));
			if (num2.HasValue)
			{
				num2 = Mathf.Abs(num2.Value);
			}
			float? num3 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.TractionMotorAmpsMax));
			float? num4 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.Fuel));
			float? num5 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.FuelMax));
			float? num6 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.Oil));
			float? num7 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.OilMax));
			float? num8 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.Sand));
			float? num9 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.SandMax));
			float? num10 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.EngineRPM));
			float? num11 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.EngineRPMMax));
			float? num12 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.TurbineRPM));
			float? num13 = (isInFaultState ? ((float?)null) : base.Base.TryReadPort(STDSimPort.TurbineRPMMax));
			barThr.UpdateValue(isInFaultState ? 0f : (base.Base.Controls?.Throttle?.Value ?? 0f));
			barAmps.UpdateValue((num2.HasValue && num3.HasValue) ? (num2.Value / num3.Value) : 0f);
			barTacho.UpdateValue((num10.HasValue && num11.HasValue) ? (num10.Value / num11.Value) : 0f);
			barTurbine.UpdateValue((num12.HasValue && num13.HasValue) ? (num12.Value / num13.Value) : 0f);
			LedBarDriverBase ledBarDriverBase = barPressurePipe;
			float value;
			if (!isInFaultState)
			{
				TrainCar trainCar = base.Base.TrainCar;
				value = (((object)trainCar == null) ? ((float?)null) : (trainCar.brakeSystem?.brakePipePressure / 9f)) ?? 0f;
			}
			else
			{
				value = 0f;
			}
			ledBarDriverBase.UpdateValue(value);
			barPressureRes.UpdateValue(isInFaultState ? 0f : (base.Base.TrainCar?.brakeSystem?.MainResPressureNormalized ?? 0f));
			barPressureCyl.UpdateValue(isInFaultState ? 0f : (base.Base.TrainCar?.brakeSystem?.BrakeCylinderPressureNormalized ?? 0f));
			barBrkTrn.UpdateValue(isInFaultState ? 0f : (base.Base.Controls?.Brake?.Value ?? 0f));
			barBrkInd.UpdateValue(isInFaultState ? 0f : (base.Base.Controls?.IndependentBrake?.Value ?? 0f));
			barBrkDyn.UpdateValue(isInFaultState ? 0f : (base.Base.Controls?.DynamicBrake?.Value ?? 0f));
			barFuel.UpdateValue((num4.HasValue && num5.HasValue) ? (num4.Value / num5.Value) : 0f);
			barOil.UpdateValue((num6.HasValue && num7.HasValue) ? (num6.Value / num7.Value) : 0f);
			barSand.UpdateValue((num8.HasValue && num9.HasValue) ? (num8.Value / num9.Value) : 0f);
			barTemp.UpdateValue(num.HasValue ? Mathf.InverseLerp(30f, 120f, num.Value) : 0f);
			barSander.UpdateValue(isInFaultState ? 0f : (base.Base.Controls?.Sander?.Value ?? 0f));
			textAmps.text = num2?.ToString("0") ?? string.Empty;
			textTemp.text = num?.ToString("0") ?? string.Empty;
			float absSpeed = base.Base.TrainCar.GetAbsSpeed();
			string text = "----";
			if (base.Base.TrainCar != null && !isInFaultState)
			{
				text = ((!base.Base.TrainCar.derailed) ? Mathf.Clamp(Mathf.RoundToInt(absSpeed * 3.6f), 0, 999).ToString().PadLeft(3, '0') : "DRLD");
			}
			textSpd.text = text;
			texTacho.text = (num10.HasValue ? (num10.Value / 1000f).ToString("0.0") : string.Empty);
			textTurbine.text = (num12.HasValue ? (num12.Value / 1000f).ToString("0.0") : string.Empty);
			TextMeshPro textMeshPro = textPressurePipe;
			float? obj;
			if (!isInFaultState)
			{
				TrainCar trainCar2 = base.Base.TrainCar;
				obj = (((object)trainCar2 == null) ? ((float?)null) : (trainCar2.brakeSystem?.brakePipePressure - 1f));
			}
			else
			{
				obj = null;
			}
			float? num14 = obj;
			textMeshPro.text = num14?.ToString("0.0") ?? string.Empty;
			TextMeshPro textMeshPro2 = textPressureRes;
			float? obj2;
			if (!isInFaultState)
			{
				TrainCar trainCar3 = base.Base.TrainCar;
				obj2 = (((object)trainCar3 == null) ? ((float?)null) : (trainCar3.brakeSystem?.mainReservoirPressure - 1f));
			}
			else
			{
				obj2 = null;
			}
			num14 = obj2;
			textMeshPro2.text = num14?.ToString("0.0") ?? string.Empty;
			TextMeshPro textMeshPro3 = textPressureCyl;
			float? obj3;
			if (!isInFaultState)
			{
				TrainCar trainCar4 = base.Base.TrainCar;
				obj3 = (((object)trainCar4 == null) ? ((float?)null) : (trainCar4.brakeSystem?.brakeCylinderPressure - 1f));
			}
			else
			{
				obj3 = null;
			}
			num14 = obj3;
			textMeshPro3.text = num14?.ToString("0.0") ?? string.Empty;
			textFuel.text = (num4.HasValue ? num4.Value.ToString("0") : string.Empty);
			textOil.text = (num6.HasValue ? num6.Value.ToString("0") : string.Empty);
			textSand.text = (num8.HasValue ? num8.Value.ToString("0") : string.Empty);
			float? num15 = (isInFaultState ? ((float?)null) : base.Base.Controls?.Reverser?.Value);
			textReverser.text = ((!num15.HasValue) ? string.Empty : ((num15.Value == 1f) ? "F" : ((num15.Value == 0f) ? "R" : "N")));
			LampControl.LampState state = LampControl.LampState.Off;
			if (muTempAndWheelslipObserver != null && !isInFaultState)
			{
				switch (muTempAndWheelslipObserver.CarTemperatureState)
				{
				case MultipleUnitStateObserver.TemperatureState.Warning:
					state = LampControl.LampState.On;
					break;
				case MultipleUnitStateObserver.TemperatureState.Critical:
				case MultipleUnitStateObserver.TemperatureState.WarningAndCritical:
					state = LampControl.LampState.Blinking;
					break;
				}
			}
			lampTemp.SetLampState(state);
			if ((bool)base.Base.TrainCar && !isInFaultState)
			{
				bool flag = false;
				if (muTempAndWheelslipObserver != null)
				{
					flag = muTempAndWheelslipObserver.AnyInChainWheelslipping;
				}
				else if (base.Base.TrainCar.SimController.wheelslipController != null)
				{
					flag = base.Base.TrainCar.SimController.wheelslipController.IsWheelslipping;
				}
				WheelSlideTrainsetObserver wheelSlideTrainsetObserver = wheelSlideObserver;
				bool flag2 = (object)wheelSlideTrainsetObserver != null && wheelSlideTrainsetObserver.AnyWheelSlidingInTrainset && absSpeed > 5f / 9f;
				lampSlip.SetLampState((flag || flag2) ? LampControl.LampState.On : LampControl.LampState.Off);
			}
			lampEngine.SetLampState((base.Base.TryReadPort(STDSimPort.EngineOn, out var value2) && value2 > 0.5f && !isInFaultState) ? LampControl.LampState.On : LampControl.LampState.Off);
			if (base.Base.TryReadPort(STDSimPort.FuelLampState, out var value3))
			{
				lampFuel.ProcessLampLogicCode(isInFaultState ? 0f : value3, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.OilLampState, out var value4))
			{
				lampOil.ProcessLampLogicCode(isInFaultState ? 0f : value4, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.SandLampState, out var value5))
			{
				lampSand.ProcessLampLogicCode(isInFaultState ? 0f : value5, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.EngineRpmLampState, out var value6))
			{
				lampRPM.ProcessLampLogicCode(isInFaultState ? 0f : value6, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.AmpsLampState, out var value7))
			{
				lampAmp.ProcessLampLogicCode(isInFaultState ? 0f : value7, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.SanderLampState, out var value8))
			{
				lampSander.ProcessLampLogicCode(isInFaultState ? 0f : value8, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.WipersLampState, out var value9))
			{
				lampWipers.ProcessLampLogicCode(isInFaultState ? 0f : value9, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.CabLightLampState, out var value10))
			{
				lampLightCab.ProcessLampLogicCode(isInFaultState ? 0f : value10, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.HeadlightFLampState, out var value11))
			{
				lampLightF.ProcessLampLogicCode(isInFaultState ? 0f : value11, audioAllowed: true);
			}
			if (base.Base.TryReadPort(STDSimPort.HeadlightRLampState, out var value12))
			{
				lampLightR.ProcessLampLogicCode(isInFaultState ? 0f : value12, audioAllowed: true);
			}
		}

		private void ClearDisplay()
		{
			barThr.UpdateValue(0f);
			barAmps.UpdateValue(0f);
			barTemp.UpdateValue(0f);
			barSander.UpdateValue(0f);
			barTacho.UpdateValue(0f);
			barTurbine.UpdateValue(0f);
			barPressurePipe.UpdateValue(0f);
			barPressureRes.UpdateValue(0f);
			barPressureCyl.UpdateValue(0f);
			barBrkTrn.UpdateValue(0f);
			barBrkInd.UpdateValue(0f);
			barBrkDyn.UpdateValue(0f);
			barFuel.UpdateValue(0f);
			barOil.UpdateValue(0f);
			barSand.UpdateValue(0f);
			textAmps.text = string.Empty;
			textTemp.text = string.Empty;
			textReverser.text = string.Empty;
			textSpd.text = string.Empty;
			texTacho.text = string.Empty;
			textTurbine.text = string.Empty;
			textPressurePipe.text = string.Empty;
			textPressureRes.text = string.Empty;
			textPressureCyl.text = string.Empty;
			textFuel.text = string.Empty;
			textOil.text = string.Empty;
			textSand.text = string.Empty;
			lampEngine.SetLampState(LampControl.LampState.Off);
			lampAmp.SetLampState(LampControl.LampState.Off);
			lampTemp.SetLampState(LampControl.LampState.Off);
			lampSlip.SetLampState(LampControl.LampState.Off);
			lampSander.SetLampState(LampControl.LampState.Off);
			lampRPM.SetLampState(LampControl.LampState.Off);
			lampBrakes.SetLampState(LampControl.LampState.Off);
			lampFuel.SetLampState(LampControl.LampState.Off);
			lampOil.SetLampState(LampControl.LampState.Off);
			lampSand.SetLampState(LampControl.LampState.Off);
			lampWipers.SetLampState(LampControl.LampState.Off);
			lampLightCab.SetLampState(LampControl.LampState.Off);
			lampLightF.SetLampState(LampControl.LampState.Off);
			lampLightR.SetLampState(LampControl.LampState.Off);
		}
	}
}
