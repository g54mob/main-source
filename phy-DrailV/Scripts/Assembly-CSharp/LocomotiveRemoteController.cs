using System;
using System.Collections;
using DV;
using DV.CabControls;
using DV.CabControls.NonVR;
using DV.JObjectExtstensions;
using DV.Simulation.Cars;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LocomotiveRemoteController : MonoBehaviour
{
	private const string PAIRED_LOCO_GUID_SAVE_KEY = "Paired_loco_ID";

	private const string ITEM_TURNED_ON_STATE = "Item_turned_on_state";

	private const int MAX_REGULAR_SIGNAL_DISTANCE = 650;

	private const int MAX_EXTENDED_SIGNAL_DISTANCE = 2000;

	private const float THROTTLE_UPDATE_VALUE = 1f;

	private const float BRAKES_UPDATE_VALUE = 1f;

	[InspectorButton("TogglePower", true, true)]
	public bool togglePower;

	[InspectorButton("TogglePairing", true, true)]
	public bool togglePairing;

	private ILocomotiveRemoteControl pairedLocomotive;

	private bool isOn;

	private Coroutine updateDisplayCoroutine;

	private Coroutine updateControlsCoroutine;

	private float signal;

	private float lostSignalSecondsLeft;

	private Interpolator staticNoiseFade;

	private int numberOfCarsInFront;

	private int numberOfCarsInRear;

	private int selectedCoupler;

	private bool wasCouplerInRangeAndCouplingAllowed;

	private float updateLoopDelay = 0.1f;

	private bool wasSignalBoosted;

	private MultipleUnitStateObserver.TemperatureState previousTemperatureState;

	[Header("Controls")]
	public GameObject powerButton;

	public GameObject pairingButton;

	public GameObject coupleButton;

	public GameObject decoupleButton;

	public GameObject couplerSelectorKnob;

	public JoystickDriver independentBrakeJoystick;

	public JoystickDriver hornJoystick;

	public JoystickDriver reverserJoystick;

	public JoystickDriver sandJoystick;

	public JoystickDriver brakeJoystick;

	public JoystickDriver throttleJoystick;

	public LCDDriver reverserDisplay;

	public LCDDriver speedometerDisplay;

	public LCDDriver couplerSignDisplay;

	public LCDDriver couplerDisplay;

	public LampControl couplerInRangeLamp;

	public LampControl powerLamp;

	public LampControl pairedLamp;

	public LampControl signalBoostedLamp;

	public LampControl sandLamp;

	public LampControl wheelslipLamp;

	public LampControl engineTemperatureLamp;

	public LedBarDriverBase signalBar;

	public LedBarDriverBase independentBrakeBar;

	public LedBarDriverBase brakeBar;

	public LedBarDriverBase throttleBar;

	public AudioSource staticAudio;

	public AudioClip couplerInRangeAudio;

	public AudioClip turnOnAudio;

	public AudioClip turnOffAudio;

	public AudioClip signalBoostingOnAudio;

	public AudioClip signalBoostingOffAudio;

	public AudioClip invalidPairingAudio;

	private ControlImplBase powerButtonControl;

	private ControlImplBase pairingButtonControl;

	private ControlImplBase coupleButtonControl;

	private ControlImplBase decoupleButtonControl;

	private SteppedJoint couplerSelectorKnobJoint;

	private ItemNonVR itemNonVr;

	private Battery battery;

	private BatteryConsumer batteryConsumer;

	private SolarPanel solarPanel;

	private ItemSaveData itemSaveData;

	private bool initialized;

	private GameParams gameParams;

	public bool InControl
	{
		get
		{
			if (IsPaired() && IsPowered)
			{
				return base.gameObject.activeInHierarchy;
			}
			return false;
		}
	}

	private bool IsPowered
	{
		get
		{
			if (isOn)
			{
				return !battery.Depleted;
			}
			return false;
		}
	}

	private void Awake()
	{
		solarPanel = GetComponent<SolarPanel>();
		batteryConsumer = GetComponent<BatteryConsumer>();
		battery = GetComponent<Battery>();
		if (battery != null)
		{
			battery.Initialize();
		}
		itemSaveData = GetComponent<ItemSaveData>();
		if (itemSaveData != null)
		{
			itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
			itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
		}
		gameParams = Globals.G.GameParams;
	}

	private void Start()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	private void OnEnable()
	{
		if (initialized)
		{
			updateControlsCoroutine = StartCoroutine(UpdateRemote());
			updateDisplayCoroutine = StartCoroutine(UpdateDisplay());
			TogglePower(isOn, playPowerSound: false);
		}
	}

	private void OnDisable()
	{
		if (updateControlsCoroutine != null)
		{
			StopCoroutine(updateControlsCoroutine);
		}
		updateControlsCoroutine = null;
		if (updateDisplayCoroutine != null)
		{
			StopCoroutine(updateDisplayCoroutine);
		}
		updateDisplayCoroutine = null;
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private IEnumerator Initialize()
	{
		while (!solarPanel.Initialized)
		{
			yield return null;
		}
		yield return null;
		couplerSelectorKnobJoint = couplerSelectorKnob.GetComponent<SteppedJoint>();
		while (couplerSelectorKnobJoint == null)
		{
			yield return null;
			couplerSelectorKnobJoint = couplerSelectorKnob.GetComponent<SteppedJoint>();
		}
		staticNoiseFade = base.gameObject.AddComponent<Interpolator>();
		powerButtonControl = powerButton.GetComponent<ControlImplBase>();
		pairingButtonControl = pairingButton.GetComponent<ControlImplBase>();
		coupleButtonControl = coupleButton.GetComponent<ControlImplBase>();
		decoupleButtonControl = decoupleButton.GetComponent<ControlImplBase>();
		signalBar.Initialize();
		throttleBar.Initialize();
		brakeBar.Initialize();
		independentBrakeBar.Initialize();
		if (!IsPowered)
		{
			TurnOffDisplay();
		}
		itemNonVr = base.gameObject.GetComponent<ItemNonVR>();
		if (itemNonVr != null)
		{
			base.gameObject.AddComponent<LocomotiveRemoteKeyboardInput>();
		}
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		foreach (Collider collider in componentsInChildren)
		{
			solarPanel.IgnoreSunBlocking(collider);
		}
		SetupListeners(on: true);
		initialized = true;
		if (base.gameObject.activeInHierarchy)
		{
			if (updateControlsCoroutine == null)
			{
				updateControlsCoroutine = StartCoroutine(UpdateRemote());
			}
			if (updateDisplayCoroutine == null)
			{
				updateDisplayCoroutine = StartCoroutine(UpdateDisplay());
			}
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			powerButtonControl.Used += OnPowerButtonPressed;
			pairingButtonControl.Used += OnPairingButtonPressed;
			coupleButtonControl.Used += OnCoupleButtonPressed;
			decoupleButtonControl.Used += OnUncoupleButtonPressed;
			couplerSelectorKnobJoint.PositionChanged += OnCouplerSelectorChanged;
			reverserJoystick.ValueUpdated += OnReverserUpdated;
			throttleJoystick.ValueUpdated += OnThrottleUpdated;
			brakeJoystick.ValueUpdated += OnBrakeUpdated;
			independentBrakeJoystick.ValueUpdated += OnIndependentBrakeUpdated;
			hornJoystick.ValueUpdated += OnHornUpdated;
			sandJoystick.ValueUpdated += OnSandUpdated;
			if (itemNonVr != null)
			{
				itemNonVr.Grabbed += TakeKeyboardFocus;
				itemNonVr.Ungrabbed += ReleaseKeyboardFocus;
			}
			return;
		}
		if (itemSaveData != null)
		{
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
		}
		if (battery != null)
		{
			battery.PowerDepleted -= OnPowerDepleted;
			battery.PowerRestored -= OnPowerRestored;
		}
		if (powerButtonControl != null)
		{
			powerButtonControl.Used -= OnPowerButtonPressed;
		}
		if (pairingButtonControl != null)
		{
			pairingButtonControl.Used -= OnPairingButtonPressed;
		}
		if (coupleButtonControl != null)
		{
			coupleButtonControl.Used -= OnCoupleButtonPressed;
		}
		if (decoupleButtonControl != null)
		{
			decoupleButtonControl.Used -= OnUncoupleButtonPressed;
		}
		if (couplerSelectorKnobJoint != null)
		{
			couplerSelectorKnobJoint.PositionChanged -= OnCouplerSelectorChanged;
		}
		if (reverserJoystick != null)
		{
			reverserJoystick.ValueUpdated -= OnReverserUpdated;
		}
		if (throttleJoystick != null)
		{
			throttleJoystick.ValueUpdated -= OnThrottleUpdated;
		}
		if (brakeJoystick != null)
		{
			brakeJoystick.ValueUpdated -= OnBrakeUpdated;
		}
		if (independentBrakeJoystick != null)
		{
			independentBrakeJoystick.ValueUpdated -= OnIndependentBrakeUpdated;
		}
		if (hornJoystick != null)
		{
			hornJoystick.ValueUpdated -= OnHornUpdated;
		}
		if (sandJoystick != null)
		{
			sandJoystick.ValueUpdated -= OnSandUpdated;
		}
		if (itemNonVr != null)
		{
			itemNonVr.Grabbed -= TakeKeyboardFocus;
			itemNonVr.Ungrabbed -= ReleaseKeyboardFocus;
		}
	}

	private void OnReverserUpdated(float value)
	{
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			if (t != null)
			{
				ToggleDirection toggle = ToggleDirectionMethods.FromNumber(value);
				t.UpdateReverser(toggle);
			}
		});
	}

	private void OnThrottleUpdated(float value)
	{
		if (!Mathf.Approximately(value, 0f))
		{
			value = Mathf.Sign(value) * 1f;
		}
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			t?.UpdateThrottle(value);
		});
	}

	private void OnBrakeUpdated(float value)
	{
		if (!Mathf.Approximately(value, 0f))
		{
			value = Mathf.Sign(value) * 1f;
		}
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			t?.UpdateBrake(value);
		});
	}

	private void OnIndependentBrakeUpdated(float value)
	{
		if (!Mathf.Approximately(value, 0f))
		{
			value = Mathf.Sign(value) * 1f;
		}
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			t?.UpdateIndependentBrake(value);
		});
	}

	private void OnHornUpdated(float value)
	{
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			t?.UpdateHorn(value);
		});
	}

	private void OnSandUpdated(float value)
	{
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			t?.UpdateSand(ToggleDirectionMethods.FromNumber(value));
		});
	}

	private void OnPowerButtonPressed()
	{
		isOn = !isOn;
		TogglePower(isOn);
	}

	private void TakeKeyboardFocus(ControlImplBase controlImplBase)
	{
		SingletonBehaviour<InputFocusManager>.Instance.TakeKeyboardFocus();
	}

	private void ReleaseKeyboardFocus(ControlImplBase controlImplBase)
	{
		SingletonBehaviour<InputFocusManager>.Instance.ReleaseKeyboardFocus();
	}

	private void TogglePairing()
	{
		if (!IsPowered)
		{
			return;
		}
		if (IsPaired())
		{
			ILocomotiveRemoteControl pairingTarget = GetPairingTarget(PlayerManager.Car);
			if (pairingTarget == null)
			{
				if (invalidPairingAudio != null)
				{
					invalidPairingAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
			}
			else if (pairedLocomotive == pairingTarget)
			{
				Unpair();
			}
			else
			{
				Pair();
			}
		}
		else
		{
			Pair();
		}
	}

	private void OnPairingButtonPressed()
	{
		TogglePairing();
	}

	private void Pair()
	{
		Pair(PlayerManager.Car);
	}

	private void Pair(TrainCar car)
	{
		Unpair();
		lostSignalSecondsLeft = 0f;
		previousTemperatureState = MultipleUnitStateObserver.TemperatureState.Nominal;
		pairedLocomotive = GetPairingTarget(car);
		if (pairedLocomotive != null)
		{
			pairedLocomotive.PairRemoteController(this);
		}
		else if (invalidPairingAudio != null)
		{
			invalidPairingAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
		}
		UpdateCouplerSelection();
	}

	private ILocomotiveRemoteControl GetPairingTarget(TrainCar car)
	{
		if (car == null)
		{
			return null;
		}
		ILocomotiveRemoteControl component = car.GetComponent<ILocomotiveRemoteControl>();
		if (component == null)
		{
			return null;
		}
		if (!component.IsReadyToPair)
		{
			return null;
		}
		return component;
	}

	private void Unpair()
	{
		if (pairedLocomotive != null)
		{
			pairedLocomotive.UnpairRemoteController(this);
			pairedLocomotive = null;
			UpdateSignal();
			wasSignalBoosted = false;
			signalBoostedLamp.SetLampState(LampControl.LampState.Off);
		}
	}

	private bool IsPaired()
	{
		return pairedLocomotive != null;
	}

	private void OnCoupleButtonPressed()
	{
		if (gameParams.CouplingViaRemoteControllerAllowed)
		{
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				t?.RemoteControllerCouple();
			});
		}
	}

	private void OnUncoupleButtonPressed()
	{
		if (gameParams.CouplingViaRemoteControllerAllowed)
		{
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				t?.Uncouple(selectedCoupler);
			});
		}
	}

	private void OnCouplerSelectorChanged(ValueChangedEventArgs args)
	{
		if (Globals.G.GameParams.CouplingViaRemoteControllerAllowed)
		{
			UpdateCouplerSelection((int)args.delta);
		}
	}

	private void UpdateCouplingInformation()
	{
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			if (t != null)
			{
				numberOfCarsInFront = t.GetNumberOfCarsInFront();
				numberOfCarsInRear = t.GetNumberOfCarsInRear();
			}
		});
	}

	private void UpdateCouplerSelection(int delta = 0)
	{
		UpdateCouplingInformation();
		if (numberOfCarsInFront + numberOfCarsInRear > 0)
		{
			int num = selectedCoupler + delta;
			if (num > numberOfCarsInFront)
			{
				num = -numberOfCarsInRear;
			}
			else if (num < -numberOfCarsInRear)
			{
				num = numberOfCarsInFront;
			}
			if (num == 0)
			{
				num += ((delta > 0) ? 1 : (-1));
			}
			if (num > numberOfCarsInFront)
			{
				num = -numberOfCarsInRear;
			}
			else if (num < -numberOfCarsInRear)
			{
				num = numberOfCarsInFront;
			}
			selectedCoupler = num;
		}
		else
		{
			selectedCoupler = 0;
		}
		UpdateCouplerDisplay();
	}

	private void UpdateCouplerDisplay()
	{
		if (!IsSignalLost() && IsPaired() && IsPowered)
		{
			string text = " ";
			if (selectedCoupler != 0)
			{
				text = ((selectedCoupler > 0) ? "+" : "-");
			}
			string text2 = Mathf.Clamp(Math.Abs(selectedCoupler), 0, 99).ToString();
			if (Math.Abs(selectedCoupler) < 10)
			{
				couplerSignDisplay.Display(" ");
				couplerDisplay.Display(text + text2);
			}
			else
			{
				couplerSignDisplay.Display(text);
				couplerDisplay.Display(text2);
			}
		}
		else
		{
			couplerSignDisplay.Display(" ");
			couplerDisplay.Display(IsPowered ? "--" : "  ");
		}
	}

	private void UpdateCouplerInRangeLight()
	{
		Transmit(delegate(ILocomotiveRemoteControl t)
		{
			if (t != null)
			{
				bool flag = gameParams.CouplingViaRemoteControllerAllowed && t.IsCouplerInRange(0.64f);
				couplerInRangeLamp.SetLampState(flag ? LampControl.LampState.On : LampControl.LampState.Off);
				if (flag && !wasCouplerInRangeAndCouplingAllowed)
				{
					couplerInRangeAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
				wasCouplerInRangeAndCouplingAllowed = flag;
			}
		});
	}

	private string GetSpeedometerText(ILocomotiveRemoteControl locomotive)
	{
		if (locomotive == null)
		{
			return null;
		}
		if (locomotive.IsDerailed())
		{
			return "DRLD";
		}
		float num = pairedLocomotive.GetForwardSpeed() * 3.6f;
		return string.Concat(str1: Math.Round(Mathf.Clamp(Math.Abs(num), 0f, 999f)).ToString().PadLeft(3, '0'), str0: (Math.Round(num) >= 0.0) ? " " : "-");
	}

	private IEnumerator UpdateDisplay()
	{
		while (true)
		{
			yield return WaitFor.Seconds(0.1f);
			if (!IsPowered)
			{
				continue;
			}
			powerLamp.SetLampState(isOn ? LampControl.LampState.On : LampControl.LampState.Off);
			UpdatePairedLamp();
			signalBar.UpdateValue(signal);
			signalBar.UpdateDisplayMode(IsSignalLost() ? LedBarDriverBase.DisplayMode.BLINKING : LedBarDriverBase.DisplayMode.NORMAL);
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				reverserDisplay.Display(t?.GetReverserSymbol() ?? "-");
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				speedometerDisplay.Display(GetSpeedometerText(t) ?? "----");
			});
			UpdateCouplerSelection();
			UpdateCouplerInRangeLight();
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				throttleBar.UpdateValue(t?.GetTargetThrottle() ?? 0f);
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				brakeBar.UpdateValue(t?.GetBrakeIndicatorValue() ?? 0f);
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				independentBrakeBar.UpdateValue(t?.GetTargetIndependentBrake() ?? 0f);
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				sandLamp.SetLampState((t != null && t.IsSandOn()) ? LampControl.LampState.On : LampControl.LampState.Off);
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				if (t != null && t.IsWheelslipping(includeMUConnections: true))
				{
					wheelslipLamp.SetLampState(LampControl.LampState.On);
				}
				else
				{
					wheelslipLamp.SetLampState(LampControl.LampState.Off);
				}
			});
			Transmit(delegate(ILocomotiveRemoteControl t)
			{
				MultipleUnitStateObserver.TemperatureState temperatureState = t?.GetEngineTemperatureState(includeMUConnections: true) ?? MultipleUnitStateObserver.TemperatureState.Nominal;
				LampControl.LampState state = ((temperatureState != MultipleUnitStateObserver.TemperatureState.Nominal) ? (((temperatureState & MultipleUnitStateObserver.TemperatureState.Critical) != MultipleUnitStateObserver.TemperatureState.Critical) ? LampControl.LampState.On : LampControl.LampState.Blinking) : LampControl.LampState.Off);
				bool playWarningAudio = ShouldPlayTemperatureWarning(temperatureState);
				engineTemperatureLamp.SetLampState(state, playWarningAudio);
				previousTemperatureState = temperatureState;
			});
		}
	}

	private bool ShouldPlayTemperatureWarning(MultipleUnitStateObserver.TemperatureState currentTemperatureState)
	{
		switch (previousTemperatureState)
		{
		case MultipleUnitStateObserver.TemperatureState.Nominal:
			return currentTemperatureState != MultipleUnitStateObserver.TemperatureState.Nominal;
		case MultipleUnitStateObserver.TemperatureState.Warning:
			return (currentTemperatureState & MultipleUnitStateObserver.TemperatureState.WarningAndCritical) != 0;
		case MultipleUnitStateObserver.TemperatureState.Critical:
		case MultipleUnitStateObserver.TemperatureState.WarningAndCritical:
			return false;
		default:
			Debug.LogError($"Unsupported temperature state {previousTemperatureState}. Assuming no sound should be played.", this);
			return false;
		}
	}

	private void UpdatePairedLamp()
	{
		if (IsPaired())
		{
			pairedLamp.SetLampState(LampControl.LampState.On);
		}
		else
		{
			pairedLamp.SetLampState((GetPairingTarget(PlayerManager.Car) != null) ? LampControl.LampState.Blinking : LampControl.LampState.Off);
		}
	}

	private void TurnOffDisplay()
	{
		powerLamp.SetLampState(LampControl.LampState.Off);
		pairedLamp.SetLampState(LampControl.LampState.Off);
		couplerInRangeLamp.SetLampState(LampControl.LampState.Off);
		signalBar.UpdateValue(0f);
		reverserDisplay.Display(" ");
		speedometerDisplay.Display("   ");
		couplerSignDisplay.Display(" ");
		couplerDisplay.Display("  ");
		throttleBar.UpdateValue(0f);
		brakeBar.UpdateValue(0f);
		independentBrakeBar.UpdateValue(0f);
		wheelslipLamp.SetLampState(LampControl.LampState.Off);
		sandLamp.SetLampState(LampControl.LampState.Off);
		signalBoostedLamp.SetLampState(LampControl.LampState.Off);
	}

	private void TogglePower(bool on, bool playPowerSound = true)
	{
		battery.PowerDepleted -= OnPowerDepleted;
		battery.PowerRestored -= OnPowerRestored;
		if (on)
		{
			battery.PowerDepleted += OnPowerDepleted;
			battery.PowerRestored += OnPowerRestored;
		}
		batteryConsumer.TogglePowerConsumption(on && base.gameObject.activeInHierarchy);
		if (on)
		{
			TurnOn(playPowerSound);
		}
		else
		{
			TurnOff(playPowerSound);
		}
	}

	private void TurnOn(bool playTurnOnAudio = true)
	{
		if (!battery.Depleted)
		{
			if (playTurnOnAudio)
			{
				turnOnAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
			}
			if (IsPaired())
			{
				lostSignalSecondsLeft = 0.2f;
				previousTemperatureState = MultipleUnitStateObserver.TemperatureState.Nominal;
				UpdateStaticNoise(enabled: true);
			}
		}
	}

	private void TurnOff(bool playTurnOffSound = true)
	{
		wasSignalBoosted = false;
		TurnOffDisplay();
		if (playTurnOffSound)
		{
			turnOffAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
		}
	}

	private void OnPowerDepleted()
	{
		if (isOn)
		{
			TurnOff();
		}
	}

	private void OnPowerRestored()
	{
		if (isOn)
		{
			TurnOn();
		}
	}

	private IEnumerator UpdateRemote()
	{
		while (true)
		{
			yield return WaitFor.Seconds(updateLoopDelay);
			UpdateSignal();
		}
	}

	private void UpdateSignal()
	{
		if (pairedLocomotive == null || !IsPowered)
		{
			signal = 0f;
			staticAudio.volume = 0f;
			return;
		}
		bool flag = false;
		foreach (RemoteControllerSignalBooster signalBooster in RemoteControllerSignalBooster.signalBoosters)
		{
			if (Vector3.Distance(base.transform.position, signalBooster.transform.position) <= signalBooster.range)
			{
				flag = true;
				break;
			}
		}
		if (flag != wasSignalBoosted)
		{
			if (flag)
			{
				signalBoostedLamp.SetLampState(LampControl.LampState.On);
				if (signalBoostingOnAudio != null)
				{
					signalBoostingOnAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
			}
			else
			{
				signalBoostedLamp.SetLampState(LampControl.LampState.Off);
				if (signalBoostingOffAudio != null)
				{
					signalBoostingOffAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
			}
			wasSignalBoosted = flag;
		}
		int num = (flag ? 2000 : 650);
		float num2 = Vector3.Distance(pairedLocomotive.GetPosition(), base.transform.position);
		signal = Mathf.Clamp01(((float)num - num2) / (float)num);
		bool flag2 = IsSignalLost();
		if (GetConnectivity())
		{
			lostSignalSecondsLeft -= updateLoopDelay;
		}
		else if (!IsSignalLost())
		{
			lostSignalSecondsLeft = (float)UnityEngine.Random.Range(100, 1000) / 1000f;
		}
		if (lostSignalSecondsLeft < 0f)
		{
			lostSignalSecondsLeft = 0f;
		}
		if (!flag2 && IsSignalLost())
		{
			UpdateStaticNoise(enabled: true);
		}
		else if (flag2 && !IsSignalLost())
		{
			UpdateStaticNoise(enabled: false);
		}
	}

	private bool IsSignalLost()
	{
		return lostSignalSecondsLeft > 0f;
	}

	private void UpdateStaticNoise(bool enabled)
	{
		if (enabled)
		{
			staticNoiseFade.Interpolate(0f, 1f, 0.15f, delegate(float volume)
			{
				staticAudio.volume = volume;
			});
		}
		else
		{
			staticNoiseFade.Interpolate(1f, 0f, 0.15f, delegate(float volume)
			{
				staticAudio.volume = volume;
			});
		}
	}

	private float GetSignalLossChance()
	{
		if (signal <= 0f)
		{
			return 1f;
		}
		return Math.Max((1f - signal / 0.4f) / 10f, 0f);
	}

	private bool GetConnectivity()
	{
		return UnityEngine.Random.value > GetSignalLossChance();
	}

	private void Transmit(Action<ILocomotiveRemoteControl> action)
	{
		if (IsPowered)
		{
			action(IsSignalLost() ? null : pairedLocomotive);
		}
	}

	public void ExternalUnpair()
	{
		Unpair();
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			battery.LoadSavedState(null);
			return;
		}
		battery.LoadSavedState(data);
		bool? flag = data.GetBool("Item_turned_on_state");
		bool valueOrDefault = flag == true;
		if (flag.HasValue && valueOrDefault)
		{
			isOn = true;
			TogglePower(isOn, playPowerSound: false);
		}
		string text;
		if ((text = data.GetString("Paired_loco_ID")) != null && !string.IsNullOrWhiteSpace(text))
		{
			TrainCar trainCarByCarGuid = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(text);
			if (trainCarByCarGuid != null)
			{
				Pair(trainCarByCarGuid);
			}
		}
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		data.SetBool("Item_turned_on_state", isOn);
		string value = ((pairedLocomotive is Component) ? pairedLocomotive.GetLocoGuid() : "");
		data.SetString("Paired_loco_ID", value);
		battery.SaveState(data);
		return data;
	}
}
