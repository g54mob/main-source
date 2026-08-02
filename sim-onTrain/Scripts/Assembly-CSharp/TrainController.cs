using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class TrainController : NetworkBehaviour
{
	[Serializable]
	public struct WagonSaveData
	{
		public int wagonID;

		public string itemName;

		public Vector3 localPosition;

		public Vector3 localEulerAngles;
	}

	[Header("Movement Settings")]
	public float maxSpeed = 2f;

	public float maxSpeedOnSpeedMeter = 10f;

	public float accelarition = 10f;

	public float breakSpeedFor10Kmh = 10f;

	[Tooltip("Gaz bırakıldığında yavaşlama hızı")]
	public float breakSpeedForNoGas = 0.5f;

	[Tooltip("Bu hız oranının altında tren hemen durur (0-1 arası, maxSpeed'in yüzdesi)")]
	[Range(0.05f, 0.3f)]
	public float lowSpeedStopThreshold = 0.1f;

	[Tooltip("Düşük hızlarda yavaşlama çarpanı (1 = sabit, 3 = düşük hızda 3x daha hızlı durur)")]
	[Range(1f, 5f)]
	public float lowSpeedBrakeMultiplier = 3f;

	[Tooltip("Trenden herkes inince gazın kaç saniyede kapanacağı")]
	[Range(0.5f, 5f)]
	public float gasDecreaseTime = 4f;

	public List<Transform> spawnPoints = new List<Transform>();

	[Header("Fuel Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float fuelLevel;

	public List<TrainFuelData> fuelItems = new List<TrainFuelData>();

	private const float BaseFuelEndTime = 120f;

	private float baseFuelDepletionRate;

	[Header("Fuel Visual System")]
	public List<Transform> fuelPoints = new List<Transform>();

	public int maxFuelAmount = 32;

	public readonly SyncList<string> fuelItemQueue = new SyncList<string>();

	[SerializeField]
	[Range(0.01f, 1f)]
	private float fuelGaugeFullLevel = 0.576f;

	[Header("Water Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float waterLevel;

	private const float BaseWaterEndTime = 90f;

	private float baseWaterDepletionRate;

	[Header("Break System")]
	private TrainBreak trainBreak;

	[SerializeField]
	private bool breakState = true;

	[Header("Gas Pedal System")]
	private TrainGasPedal gasPedal;

	private float currentGasValue;

	[SerializeField]
	private float minConsumptionMultiplier = 0.1f;

	[SerializeField]
	private float maxConsumptionMultiplier = 2f;

	[Header("UI References")]
	[SerializeField]
	private GameObject speedMeterObject;

	[SerializeField]
	private Vector3 minSpeedRotation = new Vector3(0f, 0f, 30f);

	[SerializeField]
	private Vector3 maxSpeedRotation = new Vector3(0f, 0f, -210f);

	[SerializeField]
	private Transform fuelMeterObject;

	[SerializeField]
	private Vector3 minFuelRotation = new Vector3(0f, 0f, -30f);

	[SerializeField]
	private Vector3 maxFuelRotation = new Vector3(0f, 0f, -145f);

	public Transform waterPanel;

	[Header("Visual Effects")]
	[SerializeField]
	private ParticleSystem fireParticle;

	[SerializeField]
	private ParticleSystem smokeParticle;

	[SerializeField]
	private Light fireLight;

	[Tooltip("Tren çalıştığında (ateş yandığında) aktif olacak objeler")]
	[SerializeField]
	private List<GameObject> trainLightsAndOthers = new List<GameObject>();

	private Tween fireLightTween;

	private bool isFireLightOn;

	[Header("Train Components")]
	public GameObject vagonPrefab;

	public Animator animator;

	[Tooltip("DEPRECATED: Artık kullanılmıyor - oyuncular direkt train/wagon'a parent olur")]
	public Transform playerAttachmentPivot;

	public TrainSoundController trainSoundController;

	[Header("New Swing System")]
	[Tooltip("Kod ile sallantı kontrolü (Animator yerine) - Oyuncular DA sallanır")]
	public TrainSwingController trainSwingController;

	[Header("Wagon System")]
	public Transform firstWagonConnectionPoint;

	public List<WagonController> wagonControllers = new List<WagonController>();

	public List<Animator> animators = new List<Animator>();

	public List<TrainSwingController> wagonSwingControllers = new List<TrainSwingController>();

	[Header("Build Management")]
	public TrainBuildManager trainBuildManager;

	[Header("Events")]
	[HideInInspector]
	public UnityEvent OnTrainStarted = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnTrainStopped = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnFuelEmpty = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnFuelAdded = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnWaterEmpty = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnWaterAdded = new UnityEvent();

	public UnityEvent<WagonController> OnWagonAdded = new UnityEvent<WagonController>();

	[Header("Network Sync")]
	[SyncVar(hook = "OnFuelLevelChanged")]
	private float networkFuelLevel;

	[SyncVar(hook = "OnWaterLevelChanged")]
	private float networkWaterLevel;

	[SyncVar(hook = "OnEngineStateChanged")]
	private bool networkEngineRunning;

	[SyncVar(hook = "OnCurrentSpeedChanged")]
	private float networkCurrentSpeed;

	[SyncVar(hook = "OnPositionChanged")]
	private Vector3 networkPosition;

	[SyncVar(hook = "OnRotationChanged")]
	private Quaternion networkRotation;

	[SyncVar(hook = "OnGasNetworkChanged")]
	private float networkGasValue;

	[SyncVar]
	private float networkSwingStartTime;

	[SyncVar]
	private bool demoFinished;

	[SerializeField]
	private float currentSpeed;

	public List<TSPlayerController> tsPlayers = new List<TSPlayerController>();

	private Vector3 lastSavedPos;

	private Vector3 lastSavedEulerAngles;

	private Tween trainSpeedTween;

	private Vector3 lastNetworkPosition;

	private Quaternion lastNetworkRotation;

	private float networkSendRate = 30f;

	private float lastNetworkSendTime;

	private Vector3 clientTargetPosition;

	private Quaternion clientTargetRotation;

	private Vector3 serverVelocity;

	private Vector3 lastReceivedPosition;

	private float lastReceiveTime;

	private Vector3 positionError;

	private float errorCorrectionSpeed = 3f;

	private bool wasEmptyLastFrame;

	private Coroutine stopTrainDelayCoroutine;

	private const float STOP_DELAY = 2f;

	private Tween gasDecreaseDelayTween;

	private bool hasTriggeredMoveTask;

	public float NetworknetworkFuelLevel
	{
		get
		{
			return networkFuelLevel;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkFuelLevel, 1uL, OnFuelLevelChanged);
		}
	}

	public float NetworknetworkWaterLevel
	{
		get
		{
			return networkWaterLevel;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkWaterLevel, 2uL, OnWaterLevelChanged);
		}
	}

	public bool NetworknetworkEngineRunning
	{
		get
		{
			return networkEngineRunning;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkEngineRunning, 4uL, OnEngineStateChanged);
		}
	}

	public float NetworknetworkCurrentSpeed
	{
		get
		{
			return networkCurrentSpeed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkCurrentSpeed, 8uL, OnCurrentSpeedChanged);
		}
	}

	public Vector3 NetworknetworkPosition
	{
		get
		{
			return networkPosition;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkPosition, 16uL, OnPositionChanged);
		}
	}

	public Quaternion NetworknetworkRotation
	{
		get
		{
			return networkRotation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkRotation, 32uL, OnRotationChanged);
		}
	}

	public float NetworknetworkGasValue
	{
		get
		{
			return networkGasValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkGasValue, 64uL, OnGasNetworkChanged);
		}
	}

	public float NetworknetworkSwingStartTime
	{
		get
		{
			return networkSwingStartTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkSwingStartTime, 128uL, null);
		}
	}

	public bool NetworkdemoFinished
	{
		get
		{
			return demoFinished;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref demoFinished, 256uL, null);
		}
	}

	public float GetFuelLevel()
	{
		return networkFuelLevel;
	}

	public float GetWaterLevel()
	{
		return networkWaterLevel;
	}

	public bool IsEngineRunning()
	{
		return networkEngineRunning;
	}

	public float GetCurrentSpeed()
	{
		return networkCurrentSpeed;
	}

	public float GetGasValue()
	{
		return networkGasValue;
	}

	private void Awake()
	{
		lastSavedPos = base.transform.position;
		lastSavedEulerAngles = base.transform.eulerAngles;
		baseFuelDepletionRate = 1f / 120f;
		baseWaterDepletionRate = 1f / 90f;
		lastNetworkPosition = base.transform.position;
		lastNetworkRotation = base.transform.rotation;
		clientTargetPosition = base.transform.position;
		clientTargetRotation = base.transform.rotation;
		serverVelocity = Vector3.zero;
		lastReceivedPosition = base.transform.position;
		lastReceiveTime = 0f;
		positionError = Vector3.zero;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		fuelItemQueue.Callback += OnFuelQueueUpdated;
		StartCoroutine(InitializeFuelVisuals());
		if (!base.isServer)
		{
			StartCoroutine(InitializeSwingControllersDelayed());
		}
	}

	private IEnumerator InitializeSwingControllersDelayed()
	{
		yield return new WaitForSeconds(0.5f);
		Debug.Log($"[TrainController] Client'ta swing controller'ları initialize ediyorum. networkSwingStartTime: {networkSwingStartTime}");
		CollectExistingSwingControllers();
	}

	private IEnumerator InitializeFuelVisuals()
	{
		yield return new WaitForEndOfFrame();
		NetworkIdentity netIdentity = GetComponent<NetworkIdentity>();
		while (netIdentity != null && netIdentity.netId == 0)
		{
			yield return new WaitForSeconds(0.1f);
		}
		UpdateAllFuelVisuals();
	}

	private void Start()
	{
		if (base.isServer)
		{
			NetworknetworkFuelLevel = fuelLevel;
			NetworknetworkWaterLevel = waterLevel;
			NetworknetworkEngineRunning = false;
			NetworknetworkCurrentSpeed = 0f;
			NetworknetworkPosition = base.transform.position;
			NetworknetworkRotation = base.transform.rotation;
			NetworknetworkGasValue = 0f;
			NetworknetworkSwingStartTime = Time.time;
		}
		UpdateFuelGauge();
		UpdateWaterGauge();
		UpdateFireParticle();
		if (trainBuildManager == null)
		{
			trainBuildManager = GetComponent<TrainBuildManager>();
			if (trainBuildManager == null)
			{
				trainBuildManager = base.gameObject.AddComponent<TrainBuildManager>();
			}
		}
		trainBuildManager.trainController = this;
		TSPlayerController[] array = UnityEngine.Object.FindObjectsOfType<TSPlayerController>();
		tsPlayers.Clear();
		TSPlayerController[] array2 = array;
		foreach (TSPlayerController item in array2)
		{
			if (!tsPlayers.Contains(item))
			{
				tsPlayers.Add(item);
			}
		}
		LoadData();
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveData);
		Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadData);
		OnWagonAdded.AddListener(OnWagonAddedCallback);
		UpdateWagonCreators();
		CollectExistingSwingControllers();
		StartCoroutine(AutoStartEngineAfterDelay());
	}

	private void OnTrainFirstMoved()
	{
		if (Singleton<SteamAchievementManager>.Instance != null)
		{
			Singleton<SteamAchievementManager>.Instance.UnlockAchievement(SteamAchievement.FullSteamAhead);
		}
		TaskEventManager.OnMoveTheTrainTaskCompleted.Invoke();
	}

	private void CollectExistingSwingControllers()
	{
		wagonSwingControllers.Clear();
		if (trainSwingController != null)
		{
			trainSwingController.maxSpeed = maxSpeed;
		}
		foreach (WagonController wagonController in wagonControllers)
		{
			if (wagonController != null)
			{
				TrainSwingController component = wagonController.GetComponent<TrainSwingController>();
				if (component != null)
				{
					component.maxSpeed = maxSpeed;
					wagonSwingControllers.Add(component);
					continue;
				}
				Debug.LogWarning($"[TrainController] Wagon {wagonController.wagonID} - TrainSwingController yok! Ekleniyor...");
				component = wagonController.gameObject.AddComponent<TrainSwingController>();
				component.maxSpeed = maxSpeed;
				wagonSwingControllers.Add(component);
			}
		}
	}

	private IEnumerator AutoStartEngineAfterDelay()
	{
		yield return new WaitForSeconds(1f);
		if (base.isServer && networkFuelLevel > 0f && networkWaterLevel > 0f && !networkEngineRunning && !demoFinished)
		{
			NetworknetworkEngineRunning = true;
			OnTrainStarted.Invoke();
		}
	}

	private void OnDisable()
	{
		Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveData);
		Singleton<ES3SaveManager>.Instance.OnGameLoad.RemoveListener(LoadData);
		OnWagonAdded.RemoveListener(OnWagonAddedCallback);
	}

	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		int num = tsPlayers.Where((TSPlayerController x) => x != null && x.isOnTrain).Count();
		if (num == 0 && !wasEmptyLastFrame)
		{
			if (currentSpeed > 0f)
			{
				if (stopTrainDelayCoroutine != null)
				{
					StopCoroutine(stopTrainDelayCoroutine);
				}
				stopTrainDelayCoroutine = StartCoroutine(StopTrainAfterDelay());
			}
			wasEmptyLastFrame = true;
		}
		else if (num > 0 && wasEmptyLastFrame)
		{
			if (stopTrainDelayCoroutine != null)
			{
				StopCoroutine(stopTrainDelayCoroutine);
				stopTrainDelayCoroutine = null;
			}
			if (gasDecreaseDelayTween != null && gasDecreaseDelayTween.IsActive())
			{
				gasDecreaseDelayTween.Kill();
				gasDecreaseDelayTween = null;
			}
			if (networkFuelLevel > 0f && networkWaterLevel > 0f && !networkEngineRunning && !demoFinished)
			{
				NetworknetworkEngineRunning = true;
				OnTrainStarted.Invoke();
			}
			wasEmptyLastFrame = false;
		}
		if (!networkEngineRunning || !(networkGasValue >= 0.1f))
		{
			return;
		}
		float num2 = Mathf.Lerp(minConsumptionMultiplier, maxConsumptionMultiplier, networkGasValue);
		if (networkFuelLevel > 0f)
		{
			float num3 = baseFuelDepletionRate * num2 * Time.deltaTime;
			NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel - num3);
			SyncFuelQueueWithLevel();
			if (networkFuelLevel <= 0f)
			{
				StopEngineServer();
				OnFuelEmpty.Invoke();
			}
		}
		if (networkWaterLevel > 0f)
		{
			float num4 = baseWaterDepletionRate * num2 * Time.deltaTime;
			NetworknetworkWaterLevel = Mathf.Clamp01(networkWaterLevel - num4);
			if (networkWaterLevel <= 0f)
			{
				StopEngineServer();
				OnWaterEmpty.Invoke();
			}
		}
		if (networkFuelLevel <= 0f || networkWaterLevel <= 0f)
		{
			StopEngineServer();
		}
	}

	private IEnumerator StopTrainAfterDelay()
	{
		Debug.LogWarning($"[GasPedal] StopTrainAfterDelay BASLADI! {2f}s bekleniyor...");
		yield return new WaitForSeconds(2f);
		int num = tsPlayers.Where((TSPlayerController x) => x != null && x.isOnTrain).Count();
		Debug.LogWarning($"[GasPedal] StopTrainAfterDelay KONTROL | playersOnTrain={num} | currentSpeed={currentSpeed:F2} | networkGasValue={networkGasValue:F3}");
		if (num == 0 && currentSpeed > 0f)
		{
			float num2 = networkGasValue;
			gasDecreaseDelayTween?.Kill();
			gasDecreaseDelayTween = DOTween.To(() => networkGasValue, delegate(float x)
			{
				NetworknetworkGasValue = x;
				currentGasValue = x;
				if (gasPedal != null)
				{
					gasPedal.SetGasValue(x);
				}
			}, 0f, gasDecreaseTime).SetEase(Ease.OutQuad);
			Debug.LogWarning($"[GasPedal] GAZ AZALTMA TWEEN BASLADI! {num2:F2} → 0 ({gasDecreaseTime}s icinde)");
		}
		else
		{
			Debug.Log($"[GasPedal] StopTrainAfterDelay: iptal (playersOnTrain={num})");
		}
		stopTrainDelayCoroutine = null;
	}

	private void FixedUpdate()
	{
		if (base.isServer)
		{
			ServerFixedUpdate();
		}
		else
		{
			ClientFixedUpdate();
		}
		if (!hasTriggeredMoveTask && currentSpeed > 0f)
		{
			hasTriggeredMoveTask = true;
			OnTrainFirstMoved();
		}
		UpdateSpeedMeter();
		UpdateAnimators();
	}

	private void UpdateWagonCreators()
	{
		for (int i = 0; i < wagonControllers.Count; i++)
		{
			WagonCreator[] componentsInChildren = wagonControllers[i].GetComponentsInChildren<WagonCreator>();
			foreach (WagonCreator obj in componentsInChildren)
			{
				bool asLastWagon = i == wagonControllers.Count - 1;
				obj.SetAsLastWagon(asLastWagon);
			}
		}
	}

	public void OnWagonAddedCallback(WagonController newWagon)
	{
		UpdateWagonCreators();
		if (newWagon != null)
		{
			TrainSwingController trainSwingController = newWagon.GetComponent<TrainSwingController>();
			if (trainSwingController == null)
			{
				trainSwingController = newWagon.gameObject.AddComponent<TrainSwingController>();
			}
			trainSwingController.maxSpeed = maxSpeed;
			if (!wagonSwingControllers.Contains(trainSwingController))
			{
				wagonSwingControllers.Add(trainSwingController);
			}
		}
	}

	private void ServerFixedUpdate()
	{
		float num = ((networkEngineRunning && networkFuelLevel > 0f && networkWaterLevel > 0f && networkGasValue >= 0.1f && !demoFinished && (trainBreak == null || !trainBreak.IsBreakOn)) ? (maxSpeed * networkGasValue) : 0f);
		if (networkGasValue < 0.1f && currentSpeed > num)
		{
			float num2 = currentSpeed / maxSpeed;
			if (num2 < lowSpeedStopThreshold)
			{
				currentSpeed = 0f;
			}
			else
			{
				float num3 = Mathf.Lerp(lowSpeedBrakeMultiplier, 1f, num2);
				float num4 = breakSpeedForNoGas * num3;
				currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, num4 * Time.fixedDeltaTime);
			}
		}
		else
		{
			currentSpeed = Mathf.MoveTowards(currentSpeed, num, accelarition * Time.fixedDeltaTime);
		}
		if (currentSpeed > 0f)
		{
			Vector3 vector = base.transform.forward * currentSpeed * Time.fixedDeltaTime;
			base.transform.position += vector;
		}
		if (Time.time - lastNetworkSendTime >= 1f / networkSendRate)
		{
			NetworknetworkPosition = base.transform.position;
			NetworknetworkRotation = base.transform.rotation;
			NetworknetworkCurrentSpeed = currentSpeed;
			lastNetworkPosition = base.transform.position;
			lastNetworkRotation = base.transform.rotation;
			lastNetworkSendTime = Time.time;
		}
	}

	private void ClientFixedUpdate()
	{
		if (networkCurrentSpeed <= 0f)
		{
			if (positionError.sqrMagnitude > 0.0001f)
			{
				float num = 1f - Mathf.Exp((0f - errorCorrectionSpeed) * Time.fixedDeltaTime);
				Vector3 vector = positionError * num;
				base.transform.position += vector;
				positionError -= vector;
			}
			currentSpeed = 0f;
			return;
		}
		if (Vector3.Distance(base.transform.position, clientTargetPosition) > 5f)
		{
			base.transform.position = clientTargetPosition;
			positionError = Vector3.zero;
			Vector3 eulerAngles = base.transform.localRotation.eulerAngles;
			Vector3 eulerAngles2 = clientTargetRotation.eulerAngles;
			base.transform.localRotation = Quaternion.Euler(eulerAngles.x, eulerAngles2.y, eulerAngles.z);
			currentSpeed = networkCurrentSpeed;
			return;
		}
		if (serverVelocity.sqrMagnitude > 0.001f)
		{
			base.transform.position += serverVelocity * Time.fixedDeltaTime;
		}
		if (positionError.sqrMagnitude > 0.0001f)
		{
			float num2 = 1f - Mathf.Exp((0f - errorCorrectionSpeed) * Time.fixedDeltaTime);
			Vector3 vector2 = positionError * num2;
			base.transform.position += vector2;
			positionError -= vector2;
		}
		Vector3 eulerAngles3 = base.transform.localRotation.eulerAngles;
		Vector3 eulerAngles4 = clientTargetRotation.eulerAngles;
		float y = Mathf.MoveTowardsAngle(eulerAngles3.y, eulerAngles4.y, 180f * Time.fixedDeltaTime);
		base.transform.localRotation = Quaternion.Euler(eulerAngles3.x, y, eulerAngles3.z);
		currentSpeed = networkCurrentSpeed;
	}

	public void SetTrainBreak(TrainBreak breakSystem)
	{
		trainBreak = breakSystem;
		Debug.Log("Fren sistemi TrainController'a bağlandı");
	}

	public void OnBreakStateChanged(bool isBreakOn)
	{
		breakState = isBreakOn;
		Debug.Log("TrainController: Fren durumu değişti - " + (isBreakOn ? "AÇIK" : "KAPALI"));
		if (isBreakOn && networkEngineRunning && currentSpeed > 0f)
		{
			Debug.Log("Fren çekildi, hızlı durma başlatılıyor...");
			ForceStopWithBrake();
			if (trainSoundController != null)
			{
				trainSoundController.OnBrakeActivated();
			}
		}
		else if (base.isServer)
		{
			UpdateTargetSpeed();
		}
	}

	private void ForceStopWithBrake()
	{
		if (base.isServer)
		{
			trainSpeedTween?.Kill();
			float num = currentSpeed / breakSpeedFor10Kmh / 3f;
			trainSpeedTween = DOTween.To(() => currentSpeed, delegate(float x)
			{
				currentSpeed = x;
				NetworknetworkCurrentSpeed = x;
			}, 0f, num).OnUpdate(UpdateAnimators).OnComplete(delegate
			{
				currentSpeed = 0f;
				NetworknetworkCurrentSpeed = 0f;
				NetworknetworkPosition = base.transform.position;
				NetworknetworkRotation = base.transform.rotation;
				RpcSyncFinalPosition(base.transform.position, base.transform.rotation);
			});
			Debug.Log($"Fren ile hızlı durma: {num:F2} saniye içinde duracak");
		}
	}

	public void SetGasPedal(TrainGasPedal gasPedalSystem)
	{
		gasPedal = gasPedalSystem;
		Debug.Log("Gas pedal sistemi TrainController'a bağlandı");
	}

	public void OnGasValueChanged(float gasValue)
	{
		if (!base.isServer)
		{
			Debug.LogWarning($"[GasPedal] TrainController.OnGasValueChanged CLIENT'TAN CAGIRILDI! Bu olmamali. value={gasValue:F3}");
			return;
		}
		NetworknetworkGasValue = Mathf.Clamp01(gasValue);
		currentGasValue = networkGasValue;
		UpdateTargetSpeed();
	}

	[Command(requiresAuthority = false)]
	private void CmdSetGasValue(float gasValue)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(gasValue);
		SendCommandInternal("System.Void TrainController::CmdSetGasValue(System.Single)", 761736938, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void UpdateTargetSpeed()
	{
		if (networkEngineRunning && !(networkFuelLevel <= 0f) && !(networkWaterLevel <= 0f) && (!(trainBreak != null) || !trainBreak.IsBreakOn))
		{
			float endValue = maxSpeed * networkGasValue;
			trainSpeedTween?.Kill();
			trainSpeedTween = DOTween.To(() => currentSpeed, delegate(float x)
			{
				currentSpeed = x;
				NetworknetworkCurrentSpeed = x;
			}, endValue, 1f / accelarition).OnUpdate(UpdateAnimators);
		}
	}

	private void OnFuelLevelChanged(float oldValue, float newValue)
	{
		fuelLevel = newValue;
		UpdateFuelGauge();
		UpdateFireParticle();
		if (newValue <= 0f && networkEngineRunning)
		{
			if (base.isServer)
			{
				StopEngineServer();
			}
		}
		else if (oldValue <= 0f && newValue > 0f && networkWaterLevel > 0f && base.isServer)
		{
			StartEngineServer();
		}
	}

	private void OnWaterLevelChanged(float oldValue, float newValue)
	{
		waterLevel = newValue;
		UpdateWaterGauge();
		if (newValue <= 0f && networkEngineRunning)
		{
			if (base.isServer)
			{
				StopEngineServer();
			}
		}
		else if (oldValue <= 0f && newValue > 0f && networkFuelLevel > 0f && base.isServer)
		{
			StartEngineServer();
		}
	}

	private void OnEngineStateChanged(bool oldValue, bool newValue)
	{
		if (newValue && networkGasValue >= 0.1f)
		{
			StartMovementEffects();
		}
		else
		{
			StopMovementEffects();
		}
		UpdateFireParticle();
		Debug.Log("Motor durumu: " + (newValue ? "ÇALIŞIYOR" : "DURDURULDU"));
	}

	private void OnCurrentSpeedChanged(float oldValue, float newValue)
	{
		currentSpeed = newValue;
		if (!base.isServer && Time.frameCount < 200)
		{
			Debug.Log($"[TrainController-Client] OnCurrentSpeedChanged - Old: {oldValue:F2}, New: {newValue:F2}, Frame: {Time.frameCount}");
		}
		UpdateAnimators();
	}

	private void OnPositionChanged(Vector3 oldValue, Vector3 newValue)
	{
		if (base.isServer)
		{
			return;
		}
		float num = Time.unscaledTime - lastReceiveTime;
		if (lastReceiveTime > 0f && num > 0.001f && num < 0.5f)
		{
			Vector3 b = (newValue - lastReceivedPosition) / num;
			float num2 = maxSpeed * 1.5f;
			if (b.magnitude > num2)
			{
				b = b.normalized * num2;
			}
			serverVelocity = Vector3.Lerp(serverVelocity, b, 0.5f);
		}
		lastReceivedPosition = newValue;
		lastReceiveTime = Time.unscaledTime;
		positionError = newValue - base.transform.position;
		clientTargetPosition = newValue;
	}

	private void OnRotationChanged(Quaternion oldValue, Quaternion newValue)
	{
		if (!base.isServer)
		{
			clientTargetRotation = newValue;
		}
	}

	private void OnGasNetworkChanged(float oldValue, float newValue)
	{
		Debug.Log($"[GasPedal] TrainController.OnGasNetworkChanged | isServer={base.isServer} | old={oldValue:F3} → new={newValue:F3}");
		currentGasValue = newValue;
		if (gasPedal != null)
		{
			gasPedal.SetGasValueFromNetwork(newValue);
		}
		if (newValue < 0.1f)
		{
			StopMovementEffects();
			UpdateFireParticle();
		}
		else if (oldValue < 0.1f && newValue >= 0.1f && networkEngineRunning)
		{
			StartMovementEffects();
			UpdateFireParticle();
		}
	}

	public void StartEngineManual()
	{
		if (base.isServer)
		{
			StartEngineServer();
		}
		else
		{
			CmdStartEngine();
		}
	}

	public void StopEngineManual()
	{
		if (base.isServer)
		{
			StopEngineServer();
		}
		else
		{
			CmdStopEngine();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdStartEngine()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainController::CmdStartEngine()", -2010579317, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdStopEngine()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TrainController::CmdStopEngine()", -1281581345, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void StartEngineServer()
	{
		if (demoFinished)
		{
			Debug.Log("Motor başlatılamıyor - demo bitti!");
			return;
		}
		if (networkFuelLevel <= 0f || networkWaterLevel <= 0f)
		{
			Debug.Log("Motor başlatılamıyor - yakıt veya su yok!");
			return;
		}
		NetworknetworkEngineRunning = true;
		OnTrainStarted.Invoke();
		Debug.Log("Motor başlatıldı");
	}

	private void StopEngineServer()
	{
		NetworknetworkEngineRunning = false;
		trainSpeedTween?.Kill();
		trainSpeedTween = DOTween.To(() => currentSpeed, delegate(float x)
		{
			currentSpeed = x;
			NetworknetworkCurrentSpeed = x;
		}, 0f, currentSpeed / breakSpeedFor10Kmh).OnUpdate(UpdateAnimators).OnComplete(delegate
		{
			currentSpeed = 0f;
			NetworknetworkCurrentSpeed = 0f;
			NetworknetworkPosition = base.transform.position;
			NetworknetworkRotation = base.transform.rotation;
			RpcSyncFinalPosition(base.transform.position, base.transform.rotation);
		});
		OnTrainStopped.Invoke();
		Debug.Log("Motor durduruldu");
	}

	public void SetDemoFinished()
	{
		if (base.isServer && !demoFinished)
		{
			NetworkdemoFinished = true;
			Debug.Log("[TrainController] Demo bitti! Tren artık ilerleyemez.");
			StopEngineServer();
			Singleton<ES3SaveManager>.Instance.SaveData("DemoFinished", true);
		}
	}

	[ClientRpc]
	private void RpcSyncFinalPosition(Vector3 finalPosition, Quaternion finalRotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(finalPosition);
		writer.WriteQuaternion(finalRotation);
		SendRPCInternal("System.Void TrainController::RpcSyncFinalPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", -1023573000, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void UpdateFuelGauge()
	{
		if (fuelMeterObject != null)
		{
			float t = Mathf.InverseLerp(0f, Mathf.Max(0.01f, fuelGaugeFullLevel), fuelLevel);
			Vector3 localEulerAngles = Vector3.Lerp(minFuelRotation, maxFuelRotation, t);
			fuelMeterObject.localEulerAngles = localEulerAngles;
		}
	}

	private void UpdateWaterGauge()
	{
		if (waterPanel != null)
		{
			Vector3 localScale = waterPanel.localScale;
			localScale.y = Mathf.Clamp01(waterLevel);
			waterPanel.localScale = localScale;
		}
	}

	private void UpdateFireParticle()
	{
		bool flag = fuelLevel > 0f && networkEngineRunning && networkGasValue >= 0.1f;
		if (fireParticle != null)
		{
			if (flag && !fireParticle.isPlaying)
			{
				fireParticle.Play(withChildren: true);
			}
			else if (!flag && fireParticle.isPlaying)
			{
				fireParticle.Stop(withChildren: true);
			}
		}
		if (fireLight != null && flag != isFireLightOn)
		{
			isFireLightOn = flag;
			float endValue = (flag ? 1f : 0f);
			fireLightTween?.Kill();
			float duration = (flag ? 3f : 1f);
			fireLightTween = DOTween.To(() => fireLight.intensity, delegate(float x)
			{
				fireLight.intensity = x;
			}, endValue, duration).SetEase(Ease.InOutQuad);
		}
		bool flag2 = fuelLevel > 0f && networkEngineRunning && networkGasValue > 0f;
		foreach (GameObject trainLightsAndOther in trainLightsAndOthers)
		{
			if (trainLightsAndOther != null && trainLightsAndOther.activeSelf != flag2)
			{
				trainLightsAndOther.SetActive(flag2);
			}
		}
	}

	private void UpdateSpeedMeter()
	{
		if (speedMeterObject != null)
		{
			float t = Mathf.Clamp01(currentSpeed / maxSpeedOnSpeedMeter);
			Vector3 localEulerAngles = Vector3.Lerp(minSpeedRotation, maxSpeedRotation, t);
			speedMeterObject.transform.localEulerAngles = localEulerAngles;
		}
	}

	private void StartMovementEffects()
	{
		if (networkEngineRunning && networkGasValue >= 0.1f && smokeParticle != null && !smokeParticle.isPlaying)
		{
			smokeParticle.Play();
		}
		UpdateAnimators();
	}

	private void StopMovementEffects()
	{
		if (smokeParticle != null && smokeParticle.isPlaying)
		{
			smokeParticle.Stop();
		}
		UpdateAnimators();
	}

	private void UpdateAnimators()
	{
		float num = Mathf.Clamp01(currentSpeed / maxSpeed);
		Mathf.Lerp(0f, 1f, num);
		if (animator != null)
		{
			animator.SetFloat("Speed", num);
		}
		foreach (Animator animator in animators)
		{
			if (animator != null)
			{
				animator.SetFloat("Speed", num);
			}
		}
		if (!base.isServer && Time.frameCount < 100 && Time.frameCount % 30 == 0)
		{
			Debug.Log($"[TrainController-Client] UpdateAnimators - currentSpeed: {currentSpeed:F2}, SwingControllers: Train={trainSwingController != null}, Wagons={wagonSwingControllers.Count}");
		}
		if (trainSwingController != null)
		{
			trainSwingController.UpdateSpeed(currentSpeed);
		}
		foreach (TrainSwingController wagonSwingController in wagonSwingControllers)
		{
			if (wagonSwingController != null)
			{
				wagonSwingController.UpdateSpeed(currentSpeed);
			}
		}
	}

	public void SaveData()
	{
		if (base.isServer)
		{
			Singleton<ES3SaveManager>.Instance.SaveData("TrainLastSavedPos", base.transform.position);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainLastSavedEulerAngles", base.transform.eulerAngles);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainFuelLevel", networkFuelLevel);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainWaterLevel", networkWaterLevel);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainEngineRunning", networkEngineRunning);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainGasValue", networkGasValue);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainBreakState", breakState);
			Singleton<ES3SaveManager>.Instance.SaveData("DemoFinished", demoFinished);
			List<string> value = new List<string>(fuelItemQueue);
			Singleton<ES3SaveManager>.Instance.SaveData("TrainFuelQueue", value);
			if (trainBuildManager != null)
			{
				trainBuildManager.SaveAllData();
				Debug.Log("TrainBuildManager üzerinden veriler kaydedildi.");
			}
			else
			{
				SaveWagonsWithItemData();
				PropSaveSystem.SaveAllPropsWithWagons(wagonControllers);
				Debug.LogWarning("TrainBuildManager bulunamadı, fallback sistem kullanıldı.");
			}
		}
	}

	public void LoadData()
	{
		if (!base.isServer)
		{
			return;
		}
		lastSavedPos = Singleton<ES3SaveManager>.Instance.LoadData("TrainLastSavedPos", base.transform.position);
		lastSavedEulerAngles = Singleton<ES3SaveManager>.Instance.LoadData("TrainLastSavedEulerAngles", base.transform.eulerAngles);
		NetworknetworkFuelLevel = Singleton<ES3SaveManager>.Instance.LoadData("TrainFuelLevel", 0f);
		NetworknetworkWaterLevel = Singleton<ES3SaveManager>.Instance.LoadData("TrainWaterLevel", 0f);
		NetworknetworkEngineRunning = Singleton<ES3SaveManager>.Instance.LoadData("TrainEngineRunning", defaultValue: false);
		NetworknetworkGasValue = Singleton<ES3SaveManager>.Instance.LoadData("TrainGasValue", 0f);
		breakState = Singleton<ES3SaveManager>.Instance.LoadData("TrainBreakState", defaultValue: true);
		NetworkdemoFinished = Singleton<ES3SaveManager>.Instance.LoadData("DemoFinished", defaultValue: false);
		List<string> list = Singleton<ES3SaveManager>.Instance.LoadData("TrainFuelQueue", new List<string>());
		fuelItemQueue.Clear();
		foreach (string item in list)
		{
			fuelItemQueue.Add(item);
		}
		base.transform.position = lastSavedPos;
		base.transform.eulerAngles = lastSavedEulerAngles;
		StartCoroutine(RestoreTrainComponentStates());
		if (trainBuildManager != null)
		{
			Debug.Log("TrainBuildManager bulundu, LoadAllDataFromSave çağrılıyor... [TREN]");
			trainBuildManager.LoadAllDataFromSave();
		}
		else
		{
			Debug.LogError("TrainBuildManager NULL! Manuel wagon yükleme yapılıyor... [TREN]");
			LoadWagonsWithItemData();
		}
	}

	private IEnumerator RestoreTrainComponentStates()
	{
		yield return new WaitForSeconds(0.1f);
		if (trainBreak != null)
		{
			trainBreak.SetBreakState(breakState);
		}
		else
		{
			Debug.LogWarning("TrainBreak component bulunamadı, fren durumu restore edilemedi");
		}
		if (gasPedal != null)
		{
			gasPedal.SetGasValue(networkGasValue);
		}
		else
		{
			Debug.LogWarning("TrainGasPedal component bulunamadı, gas durumu restore edilemedi");
		}
		UpdateFuelGauge();
		UpdateWaterGauge();
		UpdateFireParticle();
		UpdateSpeedMeter();
		UpdateAllFuelVisuals();
	}

	private void SaveWagonsWithItemData()
	{
		List<WagonSaveData> list = new List<WagonSaveData>();
		foreach (WagonController item2 in wagonControllers.OrderBy((WagonController w) => w.wagonID))
		{
			WagonSaveData item = new WagonSaveData
			{
				wagonID = item2.wagonID,
				itemName = item2.GetWagonItemName(),
				localPosition = item2.transform.localPosition,
				localEulerAngles = item2.transform.localEulerAngles
			};
			list.Add(item);
		}
		Singleton<ES3SaveManager>.Instance.SaveData("TrainWagonData", list);
		foreach (WagonSaveData item3 in list)
		{
			Debug.Log($"Wagon ID: {item3.wagonID}, Type: {item3.itemName}, Local Pos: {item3.localPosition}");
		}
	}

	private void LoadWagonsWithItemData()
	{
		if (!Singleton<ES3SaveManager>.Instance.KeyExists("TrainWagonData"))
		{
			CreateDefaultWagon();
			return;
		}
		List<WagonSaveData> list = Singleton<ES3SaveManager>.Instance.LoadData("TrainWagonData", new List<WagonSaveData>());
		List<int> list2 = wagonControllers.Select((WagonController w) => w.wagonID).ToList();
		List<int> list3 = list.Select((WagonSaveData w) => w.wagonID).ToList();
		foreach (int item in list2)
		{
			if (!list3.Contains(item))
			{
				RemoveWagon(item);
			}
		}
		foreach (WagonSaveData item2 in list)
		{
			if (!list2.Contains(item2.wagonID))
			{
				CollectableItemData wagonItemData = FindWagonItemByName(item2.itemName);
				AddWagonWithItemDataAndID(wagonItemData, item2.wagonID, item2.localPosition, item2.localEulerAngles);
			}
		}
	}

	public void AddWagon(CollectableItemData wagonItemData = null)
	{
		if (!base.isServer)
		{
			return;
		}
		if (trainBuildManager != null)
		{
			int count = wagonControllers.Count;
			for (int i = 0; i < wagonControllers.Count; i++)
			{
				_ = wagonControllers[i];
			}
			if (wagonControllers.Count > 0)
			{
				WagonController wagonController = wagonControllers[wagonControllers.Count - 1];
				if (wagonController != null && wagonController.nextWagonSpawnPoint != null)
				{
					string itemName = wagonItemData?.itemName ?? "Wagon";
					trainBuildManager.CmdAddWagonToParent(itemName, wagonController.wagonID, Vector3.zero, Vector3.zero, count);
					return;
				}
				Debug.LogError("Son wagon null veya nextWagonSpawnPoint null!");
			}
			if (firstWagonConnectionPoint != null)
			{
				Vector3 localPosition = firstWagonConnectionPoint.localPosition;
				Vector3 localEulerAngles = firstWagonConnectionPoint.localEulerAngles;
				string wagonItemName = wagonItemData?.itemName ?? "Wagon";
				trainBuildManager.CmdAddWagon(wagonItemName, localPosition, localEulerAngles, count);
			}
			else
			{
				Debug.LogError("firstWagonConnectionPoint null!");
			}
		}
		else
		{
			Debug.LogError("trainBuildManager null!");
		}
	}

	public void RemoveWagon(int wagonID)
	{
		if (base.isServer && trainBuildManager != null)
		{
			trainBuildManager.CmdRemoveWagon(wagonID);
		}
	}

	public WagonController GetWagonByID(int wagonID)
	{
		return wagonControllers.FirstOrDefault((WagonController w) => w.wagonID == wagonID);
	}

	public bool IsFuelItem(CollectableItemData item)
	{
		return fuelItems.Exists((TrainFuelData x) => x.item == item);
	}

	public float GetFuelEfficiency(CollectableItemData item)
	{
		return fuelItems.Find((TrainFuelData x) => x.item == item)?.efficiency ?? 0f;
	}

	public bool CanAddFuel(CollectableItemData item, int count)
	{
		if (!IsFuelItem(item))
		{
			return false;
		}
		return fuelItemQueue.Count + count <= maxFuelAmount;
	}

	public string GetCannotAddFuelReason(CollectableItemData item)
	{
		if (!IsFuelItem(item))
		{
			return "Bu item yakıt olarak kullanılamaz";
		}
		if (fuelItemQueue.Count >= maxFuelAmount)
		{
			return "Yakıt kapasitesi dolu";
		}
		return "";
	}

	public void TryAddFuel(CollectableItemData fuelItem, int count)
	{
		if (IsFuelItem(fuelItem))
		{
			float fuelEfficiency = GetFuelEfficiency(fuelItem);
			if (base.isServer)
			{
				AddFuelBulkServer(fuelEfficiency, count, fuelItem.itemName);
			}
			else
			{
				CmdAddFuelBulk(fuelEfficiency, count, fuelItem.itemName);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuelBulk(float efficiency, int count, string fuelItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(efficiency);
		writer.WriteInt(count);
		writer.WriteString(fuelItemName);
		SendCommandInternal("System.Void TrainController::CmdAddFuelBulk(System.Single,System.Int32,System.String)", 890881016, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void AddFuelBulkServer(float efficiency, int count, string fuelItemName)
	{
		for (int i = 0; i < count; i++)
		{
			NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel + efficiency);
			if (fuelItemQueue.Count < maxFuelAmount)
			{
				fuelItemQueue.Add(fuelItemName);
			}
		}
		OnFuelAdded.Invoke();
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuelToQueue(string fuelItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(fuelItemName);
		SendCommandInternal("System.Void TrainController::CmdAddFuelToQueue(System.String)", 645427624, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuel(float efficiency, int itemCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(efficiency);
		writer.WriteInt(itemCount);
		SendCommandInternal("System.Void TrainController::CmdAddFuel(System.Single,System.Int32)", -901769974, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void AddFuelServer(float efficiency, int itemCount)
	{
		NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel + efficiency);
		OnFuelAdded.Invoke();
	}

	[Server]
	private void AddFuelToQueue(string fuelItemName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainController::AddFuelToQueue(System.String)' called when server was not active");
		}
		else if (fuelItemQueue.Count < maxFuelAmount)
		{
			fuelItemQueue.Add(fuelItemName);
		}
	}

	[Server]
	private void ConsumeFuelFromQueue()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainController::ConsumeFuelFromQueue()' called when server was not active");
		}
		else if (fuelItemQueue.Count > 0)
		{
			fuelItemQueue.RemoveAt(fuelItemQueue.Count - 1);
		}
	}

	[Server]
	private void SyncFuelQueueWithLevel()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainController::SyncFuelQueueWithLevel()' called when server was not active");
			return;
		}
		int num = Mathf.RoundToInt(networkFuelLevel * (float)maxFuelAmount);
		while (fuelItemQueue.Count > num && fuelItemQueue.Count > 0)
		{
			fuelItemQueue.RemoveAt(fuelItemQueue.Count - 1);
		}
	}

	private void OnFuelQueueUpdated(SyncList<string>.Operation op, int index, string oldItem, string newItem)
	{
		UpdateAllFuelVisuals();
	}

	private void UpdateAllFuelVisuals()
	{
		for (int i = 0; i < fuelPoints.Count; i++)
		{
			ClearFuelVisual(i);
		}
		int num = Mathf.Min(fuelItemQueue.Count, fuelPoints.Count);
		for (int j = 0; j < num; j++)
		{
			UpdateFuelVisual(j, fuelItemQueue[j]);
		}
	}

	private void UpdateFuelVisual(int index, string fuelItemName)
	{
		if (index >= fuelPoints.Count || fuelPoints[index] == null || string.IsNullOrEmpty(fuelItemName))
		{
			return;
		}
		CollectableItemData collectableItemData = null;
		if (NetworkSceneObjectSpawner.Instance != null)
		{
			collectableItemData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(fuelItemName);
		}
		if (collectableItemData == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(collectableItemData))
			{
				objectDataEqualityChecker.OpenObject();
				break;
			}
		}
	}

	private void ClearFuelVisual(int index)
	{
		if (index < fuelPoints.Count && !(fuelPoints[index] == null))
		{
			ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].CloseObject();
			}
		}
	}

	public bool TryAddWater(float amount)
	{
		if (base.isServer)
		{
			AddWaterServer(amount);
		}
		else
		{
			CmdAddWater(amount);
		}
		return true;
	}

	[Command(requiresAuthority = false)]
	private void CmdAddWater(float amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amount);
		SendCommandInternal("System.Void TrainController::CmdAddWater(System.Single)", -372112294, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void AddWaterServer(float amount)
	{
		NetworknetworkWaterLevel = Mathf.Clamp01(networkWaterLevel + amount);
		OnWaterAdded.Invoke();
	}

	private void CreateDefaultWagon()
	{
		if (firstWagonConnectionPoint == null)
		{
			Debug.LogError("firstWagonConnectionPoint atanmamış!");
			return;
		}
		GameObject gameObject = null;
		if (vagonPrefab != null)
		{
			if (Singleton<PoolingSystem>.Instance != null)
			{
				gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS("Wagon");
			}
			if (gameObject == null)
			{
				gameObject = UnityEngine.Object.Instantiate(vagonPrefab);
			}
		}
		if (gameObject == null)
		{
			Debug.LogError("Default wagon instantiate edilemedi!");
			return;
		}
		WagonController wagonController = gameObject.GetComponent<WagonController>();
		if (wagonController == null)
		{
			wagonController = gameObject.AddComponent<WagonController>();
		}
		wagonController.InitializeWagon(0);
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.transform.localPosition = firstWagonConnectionPoint.localPosition;
		gameObject.transform.localEulerAngles = firstWagonConnectionPoint.localEulerAngles;
		wagonControllers.Add(wagonController);
		if (wagonController.animator != null)
		{
			animators.Add(wagonController.animator);
		}
	}

	private CollectableItemData FindWagonItemByName(string itemName)
	{
		if (string.IsNullOrEmpty(itemName) || itemName == "DefaultWagon")
		{
			return null;
		}
		CollectableItemData[] array = Resources.LoadAll<CollectableItemData>("");
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData.itemName == itemName && collectableItemData.itemType == ItemType.Wagon)
			{
				return collectableItemData;
			}
		}
		Debug.LogWarning("Wagon item data bulunamadı: " + itemName);
		return null;
	}

	private void AddWagonWithItemDataAndID(CollectableItemData wagonItemData, int targetWagonID, Vector3 localPosition, Vector3 localEulerAngles)
	{
		GameObject gameObject = null;
		if (wagonItemData != null && !string.IsNullOrEmpty(wagonItemData.itemName))
		{
			if (Singleton<PoolingSystem>.Instance != null)
			{
				gameObject = Singleton<PoolingSystem>.Instance.InstantiateAPS(wagonItemData.itemName);
			}
			else if (wagonItemData.itemPrefab != null)
			{
				gameObject = UnityEngine.Object.Instantiate(wagonItemData.itemPrefab);
			}
		}
		else if (vagonPrefab != null)
		{
			gameObject = UnityEngine.Object.Instantiate(vagonPrefab);
		}
		if (gameObject == null)
		{
			Debug.LogError($"Wagon ID {targetWagonID} instantiate edilemedi!");
			return;
		}
		WagonController wagonController = gameObject.GetComponent<WagonController>();
		if (wagonController == null)
		{
			wagonController = gameObject.AddComponent<WagonController>();
		}
		wagonController.InitializeWagon(targetWagonID);
		wagonController.data = wagonItemData;
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.transform.localPosition = localPosition;
		gameObject.transform.localEulerAngles = localEulerAngles;
		wagonControllers.Add(wagonController);
		if (wagonController.animator != null)
		{
			animators.Add(wagonController.animator);
		}
		TrainSwingController component = wagonController.GetComponent<TrainSwingController>();
		if (component != null)
		{
			wagonSwingControllers.Add(component);
		}
		if (wagonItemData != null)
		{
			_ = wagonItemData.itemName;
		}
	}

	public TrainController()
	{
		InitSyncObject(fuelItemQueue);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetGasValue__Single(float gasValue)
	{
		Debug.Log($"[GasPedal] TrainController.CmdSetGasValue | value={gasValue:F3}");
		NetworknetworkGasValue = Mathf.Clamp01(gasValue);
		currentGasValue = networkGasValue;
		UpdateTargetSpeed();
	}

	protected static void InvokeUserCode_CmdSetGasValue__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetGasValue called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdSetGasValue__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_CmdStartEngine()
	{
		StartEngineServer();
	}

	protected static void InvokeUserCode_CmdStartEngine(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartEngine called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdStartEngine();
		}
	}

	protected void UserCode_CmdStopEngine()
	{
		StopEngineServer();
	}

	protected static void InvokeUserCode_CmdStopEngine(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStopEngine called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdStopEngine();
		}
	}

	protected void UserCode_RpcSyncFinalPosition__Vector3__Quaternion(Vector3 finalPosition, Quaternion finalRotation)
	{
		if (!base.isServer)
		{
			base.transform.position = finalPosition;
			base.transform.rotation = finalRotation;
			clientTargetPosition = finalPosition;
			clientTargetRotation = finalRotation;
			positionError = Vector3.zero;
			serverVelocity = Vector3.zero;
			currentSpeed = 0f;
		}
	}

	protected static void InvokeUserCode_RpcSyncFinalPosition__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSyncFinalPosition called on server.");
		}
		else
		{
			((TrainController)obj).UserCode_RpcSyncFinalPosition__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdAddFuelBulk__Single__Int32__String(float efficiency, int count, string fuelItemName)
	{
		AddFuelBulkServer(efficiency, count, fuelItemName);
	}

	protected static void InvokeUserCode_CmdAddFuelBulk__Single__Int32__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddFuelBulk called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdAddFuelBulk__Single__Int32__String(reader.ReadFloat(), reader.ReadInt(), reader.ReadString());
		}
	}

	protected void UserCode_CmdAddFuelToQueue__String(string fuelItemName)
	{
		AddFuelToQueue(fuelItemName);
	}

	protected static void InvokeUserCode_CmdAddFuelToQueue__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddFuelToQueue called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdAddFuelToQueue__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddFuel__Single__Int32(float efficiency, int itemCount)
	{
		AddFuelServer(efficiency, itemCount);
	}

	protected static void InvokeUserCode_CmdAddFuel__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddFuel called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdAddFuel__Single__Int32(reader.ReadFloat(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdAddWater__Single(float amount)
	{
		AddWaterServer(amount);
	}

	protected static void InvokeUserCode_CmdAddWater__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddWater called on client.");
		}
		else
		{
			((TrainController)obj).UserCode_CmdAddWater__Single(reader.ReadFloat());
		}
	}

	static TrainController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdSetGasValue(System.Single)", InvokeUserCode_CmdSetGasValue__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdStartEngine()", InvokeUserCode_CmdStartEngine, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdStopEngine()", InvokeUserCode_CmdStopEngine, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdAddFuelBulk(System.Single,System.Int32,System.String)", InvokeUserCode_CmdAddFuelBulk__Single__Int32__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdAddFuelToQueue(System.String)", InvokeUserCode_CmdAddFuelToQueue__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdAddFuel(System.Single,System.Int32)", InvokeUserCode_CmdAddFuel__Single__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TrainController), "System.Void TrainController::CmdAddWater(System.Single)", InvokeUserCode_CmdAddWater__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainController), "System.Void TrainController::RpcSyncFinalPosition(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcSyncFinalPosition__Vector3__Quaternion);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(networkFuelLevel);
			writer.WriteFloat(networkWaterLevel);
			writer.WriteBool(networkEngineRunning);
			writer.WriteFloat(networkCurrentSpeed);
			writer.WriteVector3(networkPosition);
			writer.WriteQuaternion(networkRotation);
			writer.WriteFloat(networkGasValue);
			writer.WriteFloat(networkSwingStartTime);
			writer.WriteBool(demoFinished);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(networkFuelLevel);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(networkWaterLevel);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(networkEngineRunning);
		}
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteFloat(networkCurrentSpeed);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteVector3(networkPosition);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteQuaternion(networkRotation);
		}
		if ((base.syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteFloat(networkGasValue);
		}
		if ((base.syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteFloat(networkSwingStartTime);
		}
		if ((base.syncVarDirtyBits & 0x100L) != 0L)
		{
			writer.WriteBool(demoFinished);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref networkFuelLevel, OnFuelLevelChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref networkWaterLevel, OnWaterLevelChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref networkEngineRunning, OnEngineStateChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref networkCurrentSpeed, OnCurrentSpeedChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref networkPosition, OnPositionChanged, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref networkRotation, OnRotationChanged, reader.ReadQuaternion());
			GeneratedSyncVarDeserialize(ref networkGasValue, OnGasNetworkChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref networkSwingStartTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref demoFinished, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkFuelLevel, OnFuelLevelChanged, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkWaterLevel, OnWaterLevelChanged, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkEngineRunning, OnEngineStateChanged, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkCurrentSpeed, OnCurrentSpeedChanged, reader.ReadFloat());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkPosition, OnPositionChanged, reader.ReadVector3());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkRotation, OnRotationChanged, reader.ReadQuaternion());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkGasValue, OnGasNetworkChanged, reader.ReadFloat());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkSwingStartTime, null, reader.ReadFloat());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref demoFinished, null, reader.ReadBool());
		}
	}
}
