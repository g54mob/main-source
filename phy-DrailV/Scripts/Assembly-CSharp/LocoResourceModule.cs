using System;
using System.Collections;
using System.Collections.Generic;
using DV;
using DV.Localization;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using TMPro;
using UnityEngine;

public class LocoResourceModule : CashRegisterModule
{
	public const float UNKNOWN_PRICE = -1f;

	private const float FLOW_RATE_PERCENTAGE = 0.15f;

	private const float RESOURCE_LIMIT_REACHED_PERCENTAGE = 0.98f;

	private const string RAYCAST_HIT_TAG = "LocoResourceReceiver";

	public ResourceType resourceType;

	[Header("Text")]
	public TextMeshPro currentValueText;

	public TextMeshPro statusText;

	public TextMeshPro differenceValueStaticText;

	public TextMeshPro differenceValueText;

	public TextMeshPro resourceTypeText;

	public TextMeshPro pricePerUnitText;

	public TextMeshPro totalPriceText;

	[Header("Lamp")]
	public LampControl lamp;

	[Header("Audio")]
	public AudioClip chingSound;

	public AudioClip raycastAlignedSound;

	public AudioClip raycastMisalignedSound;

	public LayeredAudio flowAudioLayered;

	public LayeredAudio plugConnectionAudioLayered;

	public LayeredAudio raycastConnectionAudioLayered;

	[Header("VFX")]
	public ParticleSystem[] plugStartFlowEffects;

	public ParticleSystem[] plugStopFlowEffects;

	public ParticleSystem[] plugFlowingEffects;

	public ParticleSystem[] raycastStartFlowEffects;

	public ParticleSystem[] raycastStopFlowEffects;

	public ParticleSystem[] raycastFlowingEffects;

	private float[] flowVolume = new float[Enum.GetValues(typeof(ResourceFlowMode)).Length];

	private float[] curVolumeVelocity = new float[Enum.GetValues(typeof(ResourceFlowMode)).Length];

	private LayeredAudio[] audioSourcesPerFlow = new LayeredAudio[Enum.GetValues(typeof(ResourceFlowMode)).Length];

	[Header("Indicator")]
	public TwoValuesIndicator indicator;

	[Header("Checking")]
	public bool bothChecksRequired;

	public Transform receiverRaycastOrigin;

	public float receiverRaycastLength;

	public PluggableObject resourceHose;

	public string hoseSocketTag = "loco";

	private LayerMask raycastLayerMask;

	[Header("Colors")]
	public Color colInactive = new Color(0.25f, 0.25f, 0.25f);

	public Color colUnavailable = new Color(0.5f, 0.5f, 0.5f);

	public Color colReady = new Color(0.5f, 1f, 0.5f);

	public Color colActive = new Color(1f, 1f, 0.5f);

	public Color colSoftError = new Color(1f, 0.5f, 0.25f);

	public Color colHardError = new Color(1f, 0.5f, 0.5f);

	private float flowRate;

	private int flowMultiplier;

	private bool limitHit;

	private LocoParameterData locoParamData;

	private PitStopStation pitStopStation;

	private bool initialized;

	private bool isDraining;

	private bool isFilling;

	private RaycastHit raycastHit;

	private LocoResourceModuleState state;

	private bool raycastPassed = true;

	private bool hosePassed = true;

	private CashRegisterModuleData emptyData = new CashRegisterModuleData();

	private List<CashRegisterModuleData> resourceData = new List<CashRegisterModuleData>();

	public bool HasCarTypeDependentPrice
	{
		get
		{
			if (resourceType != ResourceType.Car_DMG && resourceType != ResourceType.Wheels_DMG && resourceType != ResourceType.MechanicalPowertrain_DMG)
			{
				return resourceType == ResourceType.ElectricalPowertrain_DMG;
			}
			return true;
		}
	}

	private string STATUS_NO_VEHICLE => LocalizationAPI.L("pit/no_vehicle");

	private string STATUS_INCOMPATIBLE => LocalizationAPI.L("pit/incompatible");

	private string STATUS_EMPTY => LocalizationAPI.L("pit/empty");

	private string STATUS_FULL => LocalizationAPI.L("pit/full");

	private string STATUS_ADDING => LocalizationAPI.L("pit/adding");

	private string STATUS_REMOVING => LocalizationAPI.L("pit/removing");

	public override CashRegisterModuleData Data
	{
		get
		{
			int selectedIndex = pitStopStation.pitstop.SelectedIndex;
			if (selectedIndex < 0)
			{
				return emptyData;
			}
			while (resourceData.Count <= selectedIndex)
			{
				if (resourceData.Count > 0)
				{
					resourceData.Add(new CashRegisterModuleData(resourceData[0]));
				}
				else
				{
					resourceData.Add(new CashRegisterModuleData());
				}
			}
			return resourceData[selectedIndex];
		}
	}

	public float UnitsToBuy => Data.unitsToBuy;

	public float AbsoluteMinValue => 0f;

	public float AbsoluteMaxValue
	{
		get
		{
			if (locoParamData == null)
			{
				return 0f;
			}
			return locoParamData.maxValue;
		}
	}

	public float PreviouslyOwnedUnits
	{
		get
		{
			if (locoParamData == null)
			{
				return 0f;
			}
			return locoParamData.value;
		}
	}

	public float BuyMinLimit => 0f;

	public float BuyMaxLimit => AbsoluteMaxValue - PreviouslyOwnedUnits;

	public float TotalUnits => PreviouslyOwnedUnits + UnitsToBuy;

	public float TotalCost => Data.TotalPrice;

	public override bool IsReady => state == LocoResourceModuleState.Ready;

	public bool IsFlowing
	{
		get
		{
			if (IsReady)
			{
				if (flowMultiplier <= 0 || !(UnitsToBuy < BuyMaxLimit))
				{
					if (flowMultiplier < 0)
					{
						return UnitsToBuy > BuyMinLimit;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public ResourceFlowMode FlowMode { get; private set; }

	public bool IsSwitchingAllowed
	{
		get
		{
			if (!(pitStopStation != null) || !(pitStopStation.pitstop != null))
			{
				return true;
			}
			return pitStopStation.pitstop.IsSwitchingAllowed;
		}
	}

	public bool IsTrainPresent
	{
		get
		{
			if (!(pitStopStation != null))
			{
				return false;
			}
			return pitStopStation.pitstop.IsOccupied;
		}
	}

	public static event Action<float, bool> LocoResourceBoughtGlobalEvent;

	public event Action<CarPitStopParametersBase, ResourceType, float> OnResourceBought;

	public event Action FillStarted;

	public event Action FillStopped;

	public event Action DrainStarted;

	public event Action DrainStopped;

	private void Awake()
	{
		if (receiverRaycastOrigin != null)
		{
			raycastLayerMask = LayerMask.GetMask("Laser_Pointer_Target");
		}
		audioSourcesPerFlow[0] = flowAudioLayered;
		audioSourcesPerFlow[2] = raycastConnectionAudioLayered;
		audioSourcesPerFlow[1] = plugConnectionAudioLayered;
	}

	public override double GetTotalPrice()
	{
		float num = 0f;
		foreach (CashRegisterModuleData resourceDatum in resourceData)
		{
			num += resourceDatum.TotalPrice;
		}
		return num;
	}

	public override float GetTotalUnitsInBasket()
	{
		float num = 0f;
		foreach (CashRegisterModuleData resourceDatum in resourceData)
		{
			num += resourceDatum.unitsToBuy;
		}
		return num;
	}

	public void ConnectTo(PitStopStation station)
	{
		if (station == null && pitStopStation != null)
		{
			pitStopStation.pitstop.CarEntered -= Pitstop_CarEntered;
		}
		pitStopStation = station;
		if (pitStopStation != null)
		{
			pitStopStation.pitstop.CarEntered += Pitstop_CarEntered;
		}
	}

	private void Pitstop_CarEntered()
	{
		ResetData();
	}

	public override void ResetData()
	{
		for (int i = 0; i < resourceData.Count; i++)
		{
			resourceData[i].unitsToBuy = 0f;
		}
		limitHit = false;
		lamp.SetLampState(LampControl.LampState.Off);
	}

	private void OnEnable()
	{
		if (!initialized)
		{
			StartCoroutine(InitHJAF());
		}
	}

	protected override void Start()
	{
		base.Start();
		InitializeTexts();
		float newPricePerUnit = ((!HasCarTypeDependentPrice) ? ResourceTypes.GetFullUnitPriceOfResource(resourceType, null, null, Globals.G.GameParams.ResourcesParams) : (-1f));
		UpdateResourcePricePerUnit(pitStopStation.pitstop.CurrentCar, newPricePerUnit);
		flowMultiplier = 0;
		flowRate = 0f;
		UpdateResourceModule(null);
	}

	protected override void InitializeData()
	{
		Data.resourceName = LocalizationAPI.L(resourceType.ToV2().localizationKeyFull);
		Sprite sprite = resourceType.ToV2()?.resourceIcon;
		if (sprite == null)
		{
			Debug.LogError($"Missing icon for {resourceType}. Using null for icon.");
		}
		else
		{
			Data.resourceIcon = sprite;
		}
		for (int i = 0; i < resourceData.Count; i++)
		{
			resourceData[i].pricePerUnit = Data.pricePerUnit;
			resourceData[i].resourceName = Data.resourceName;
			resourceData[i].resourceIcon = Data.resourceIcon;
			resourceData[i].car = Data.car;
		}
	}

	private void InitializeTexts()
	{
		resourceTypeText.text = LocalizationAPI.L(this.resourceType.ToV2().localizationKeyFull);
		ResourceType resourceType = this.resourceType;
		if (resourceType == ResourceType.Car_DMG || (uint)(resourceType - 102) <= 2u)
		{
			differenceValueStaticText.text = LocalizationAPI.L("pit/repair");
		}
		else
		{
			differenceValueStaticText.text = LocalizationAPI.L("pit/add");
		}
		string text = 0.ToString("N2", LocalizationAPI.CC);
		UpdateStatusText();
		currentValueText.text = text;
		differenceValueText.text = text;
		totalPriceText.text = "$" + 0.ToString("N2", LocalizationAPI.CC);
	}

	protected void UpdateStatusText()
	{
		if (!IsTrainPresent)
		{
			statusText.color = colInactive;
			statusText.text = STATUS_NO_VEHICLE;
		}
		else if (BuyMinLimit == BuyMaxLimit)
		{
			if (AbsoluteMaxValue == 0f)
			{
				statusText.color = colUnavailable;
				statusText.text = STATUS_INCOMPATIBLE;
			}
			else
			{
				statusText.color = colUnavailable;
				statusText.text = STATUS_FULL;
			}
		}
		else if (IsReady && flowMultiplier == 0 && UnitsToBuy >= BuyMaxLimit)
		{
			statusText.color = colReady;
			statusText.text = STATUS_FULL;
		}
		else if (IsReady && flowMultiplier != 0)
		{
			if (flowMultiplier > 0)
			{
				if (UnitsToBuy >= BuyMaxLimit)
				{
					statusText.color = colSoftError;
					statusText.text = STATUS_FULL;
				}
				else
				{
					statusText.color = colActive;
					statusText.text = STATUS_ADDING;
				}
			}
			else if (UnitsToBuy <= BuyMinLimit)
			{
				statusText.color = colSoftError;
				statusText.text = STATUS_EMPTY;
			}
			else
			{
				statusText.color = colActive;
				statusText.text = STATUS_REMOVING;
			}
		}
		else
		{
			if (IsReady)
			{
				statusText.color = colReady;
			}
			else
			{
				statusText.color = colHardError;
			}
			statusText.text = state.GetLocalizedString();
		}
	}

	private IEnumerator InitHJAF()
	{
		HingeJointAngleFix componentInChildren;
		while ((componentInChildren = GetComponentInChildren<HingeJointAngleFix>()) == null)
		{
			yield return WaitFor.Seconds(0.2f);
		}
		RotaryAmplitudeChecker rotaryAmplitudeChecker = componentInChildren.gameObject.AddComponent<RotaryAmplitudeChecker>();
		HingeJoint component = componentInChildren.gameObject.GetComponent<HingeJoint>();
		float num = component.limits.max - component.limits.min;
		rotaryAmplitudeChecker.checkThreshold = num * 0.2f;
		rotaryAmplitudeChecker.checkPeriod = 0.075f;
		rotaryAmplitudeChecker.RotaryStateChanged += OnValvePositionChange;
		initialized = true;
	}

	private void OnValvePositionChange(int positionState)
	{
		flowMultiplier = -1 * positionState;
		UpdateStatusText();
	}

	private void AddUnitsToBuy(float changeAmount)
	{
		SetUnitsToBuy(UnitsToBuy + changeAmount);
	}

	private void Update()
	{
		if (!TimeUtil.IsFlowing)
		{
			return;
		}
		if (TotalUnits >= AbsoluteMaxValue * 0.98f)
		{
			lamp.SetLampState(LampControl.LampState.On);
			if (UnitsToBuy > 0f && !limitHit)
			{
				limitHit = true;
				chingSound.Play(lamp.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}
		else
		{
			limitHit = false;
			lamp.SetLampState(LampControl.LampState.Off);
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = raycastPassed;
		raycastPassed = false;
		hosePassed = false;
		state = LocoResourceModuleState.Ready;
		if (receiverRaycastOrigin != null && receiverRaycastLength > 0f)
		{
			flag = true;
			if (Physics.Raycast(receiverRaycastOrigin.position, receiverRaycastOrigin.forward, out raycastHit, receiverRaycastLength, raycastLayerMask) && raycastHit.collider.CompareTag("LocoResourceReceiver"))
			{
				LocoResourceReceiver component = raycastHit.collider.gameObject.GetComponent<LocoResourceReceiver>();
				if (component != null && component.resourceType == resourceType)
				{
					if (IsSwitchingAllowed)
					{
						raycastPassed = true;
					}
					else
					{
						TrainCar trainCar = TrainCar.Resolve(component.gameObject);
						raycastPassed = trainCar == pitStopStation.pitstop.CurrentCar;
					}
				}
			}
			if (flag3 != raycastPassed)
			{
				if (raycastPassed && (bool)raycastAlignedSound)
				{
					raycastAlignedSound.Play(receiverRaycastOrigin.transform.position, 1f, 1f, 0f, 1f, 100f, default(AudioSourceCurves), null, receiverRaycastOrigin.transform);
				}
				else if (!raycastPassed && (bool)raycastMisalignedSound)
				{
					raycastMisalignedSound.Play(receiverRaycastOrigin.transform.position, 1f, 1f, 0f, 3f, 100f, default(AudioSourceCurves), null, receiverRaycastOrigin.transform);
				}
			}
		}
		if (resourceHose != null)
		{
			flag2 = true;
			if (resourceHose.State == PluggableObject.PluggableState.PluggedIn && (string.IsNullOrEmpty(hoseSocketTag) || resourceHose.Socket.socketTag == hoseSocketTag))
			{
				if (IsSwitchingAllowed)
				{
					hosePassed = true;
				}
				else
				{
					TrainCar trainCar2 = TrainCar.Resolve(resourceHose.Socket.gameObject);
					hosePassed = trainCar2 == pitStopStation.pitstop.CurrentCar;
				}
			}
		}
		if (bothChecksRequired)
		{
			if (!raycastPassed)
			{
				state = LocoResourceModuleState.Misaligned;
			}
			else if (!hosePassed)
			{
				state = LocoResourceModuleState.Unplugged;
			}
		}
		else if (flag && !raycastPassed && (!flag2 || !hosePassed))
		{
			state = LocoResourceModuleState.Misaligned;
		}
		else if (flag2 && !hosePassed && !flag)
		{
			state = LocoResourceModuleState.Unplugged;
		}
		bool flag4 = isDraining;
		bool flag5 = isFilling;
		if (IsReady && flowMultiplier != 0)
		{
			if (flowMultiplier > 0)
			{
				isDraining = false;
				if (TotalUnits >= AbsoluteMaxValue)
				{
					isFilling = false;
				}
				else
				{
					isFilling = true;
				}
			}
			else
			{
				isFilling = false;
				if (TotalUnits <= PreviouslyOwnedUnits)
				{
					isDraining = false;
				}
				else
				{
					isDraining = true;
				}
			}
		}
		else
		{
			isFilling = false;
			isDraining = false;
		}
		if (flowRate > 0f && IsFlowing)
		{
			if (hosePassed)
			{
				FlowMode = ResourceFlowMode.Hose;
			}
			else if (raycastPassed)
			{
				FlowMode = ResourceFlowMode.Air;
			}
			else
			{
				FlowMode = ResourceFlowMode.Invisible;
			}
			AddUnitsToBuy((float)flowMultiplier * flowRate * Time.deltaTime);
		}
		for (int i = 0; i < audioSourcesPerFlow.Length; i++)
		{
			if (!(audioSourcesPerFlow[i] != null))
			{
				continue;
			}
			if (IsFlowing && FlowMode == (ResourceFlowMode)i)
			{
				if (flowVolume[i] < 1f)
				{
					flowVolume[i] = Mathf.SmoothDamp(flowVolume[i], 1f, ref curVolumeVelocity[i], 0.15f);
				}
			}
			else if (flowVolume[i] > 0f)
			{
				flowVolume[i] = Mathf.SmoothDamp(flowVolume[i], 0f, ref curVolumeVelocity[i], 0.15f);
			}
			audioSourcesPerFlow[i].Set(flowVolume[i]);
		}
		if (isDraining != flag4)
		{
			if (flag4)
			{
				this.DrainStopped?.Invoke();
			}
			else
			{
				this.DrainStarted?.Invoke();
			}
		}
		if (isFilling == flag5)
		{
			return;
		}
		if (flag5)
		{
			if (plugFlowingEffects != null)
			{
				ParticleSystem[] array = plugFlowingEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Stop();
				}
			}
			if (raycastFlowingEffects != null)
			{
				ParticleSystem[] array = raycastFlowingEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Stop();
				}
			}
			if (FlowMode == ResourceFlowMode.Hose && plugStopFlowEffects != null)
			{
				ParticleSystem[] array = plugStopFlowEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
			if (FlowMode == ResourceFlowMode.Air && raycastStopFlowEffects != null)
			{
				ParticleSystem[] array = raycastStopFlowEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
			this.FillStopped?.Invoke();
			return;
		}
		if (FlowMode == ResourceFlowMode.Hose)
		{
			if (plugFlowingEffects != null)
			{
				ParticleSystem[] array = plugFlowingEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
			if (plugStartFlowEffects != null)
			{
				ParticleSystem[] array = plugStartFlowEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
		}
		if (FlowMode == ResourceFlowMode.Air)
		{
			if (raycastFlowingEffects != null)
			{
				ParticleSystem[] array = raycastFlowingEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
			if (raycastStartFlowEffects != null)
			{
				ParticleSystem[] array = raycastStartFlowEffects;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Play();
				}
			}
		}
		this.FillStarted?.Invoke();
	}

	protected override void SetUnitsToBuy(float targetValue)
	{
		targetValue = Mathf.Clamp(targetValue, BuyMinLimit, BuyMaxLimit);
		indicator.targetIndicator.Value = targetValue;
		if (targetValue == 0f || state == LocoResourceModuleState.Ready)
		{
			base.SetUnitsToBuy(targetValue);
		}
	}

	public override void GetBoughtResource()
	{
		for (int i = 0; i < resourceData.Count; i++)
		{
			if (!(resourceData[i].unitsToBuy <= BuyMinLimit))
			{
				this.OnResourceBought?.Invoke(pitStopStation.pitstop.GetCarParameters(i), resourceType, resourceData[i].unitsToBuy);
				TrainCar car = resourceData[i].car;
				bool arg = car != null && (car.uniqueCar || car.playerSpawnedCar);
				LocoResourceModule.LocoResourceBoughtGlobalEvent?.Invoke(resourceData[i].TotalPrice, arg);
				resourceData[i].unitsToBuy = 0f;
			}
		}
	}

	public void UpdateResourceModule(LocoParameterData locoParamData)
	{
		this.locoParamData = locoParamData;
		if (locoParamData == null)
		{
			SetUnitsToBuy(0f);
		}
		indicator.UpdateIndicator(AbsoluteMinValue, AbsoluteMaxValue, PreviouslyOwnedUnits, UnitsToBuy);
		flowRate = (AbsoluteMaxValue - AbsoluteMinValue) * 0.15f;
		UpdateValuesTextIfVisible(TotalUnits, UnitsToBuy, TotalCost);
	}

	public void UpdateResourcePricePerUnit(TrainCar trainCar, float newPricePerUnit)
	{
		Data.car = trainCar;
		Data.pricePerUnit = newPricePerUnit;
		pricePerUnitText.text = "$" + ((Data.pricePerUnit != -1f) ? Data.pricePerUnit : 0f).ToString("N2", LocalizationAPI.CC);
		totalPriceText.text = "$" + ((Data.TotalPrice != -1f) ? Data.TotalPrice : 0f).ToString("N2", LocalizationAPI.CC);
	}

	private void UpdateValuesTextIfVisible(float currentValue, float differenceValue, float totalPrice)
	{
		if (currentValueText.renderer.isVisible)
		{
			currentValueText.text = currentValue.ToString("N2", LocalizationAPI.CC);
		}
		if (differenceValueText.renderer.isVisible)
		{
			differenceValueText.text = differenceValue.ToString("N2", LocalizationAPI.CC);
		}
		if (totalPriceText.renderer.isVisible)
		{
			totalPriceText.text = "$" + totalPrice.ToString("N2", LocalizationAPI.CC);
		}
		UpdateStatusText();
	}

	public override IReadOnlyList<CashRegisterModuleData> GetAllNonZeroPurchaseData()
	{
		List<CashRegisterModuleData> list = new List<CashRegisterModuleData>();
		foreach (CashRegisterModuleData resourceDatum in resourceData)
		{
			if (resourceDatum.unitsToBuy > 0f)
			{
				list.Add(resourceDatum);
			}
		}
		return list;
	}
}
