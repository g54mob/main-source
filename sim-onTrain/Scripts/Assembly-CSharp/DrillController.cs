using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class DrillController : NetworkBehaviour, IInteractable
{
	private enum EngineAudioState
	{
		Off = 0,
		Starting = 1,
		Running = 2,
		Stopping = 3
	}

	[SerializeField]
	private Transform interactionParent;

	private bool isShowingInteraction;

	[Header("Animation Settings")]
	[SerializeField]
	private string animationKey = "DrillWorking";

	public Animator animator;

	[Header("Fuel Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float fuelLevel;

	public List<TrainFuelData> fuelItems = new List<TrainFuelData>();

	private const float BaseFuelEndTime = 300f;

	private float baseFuelDepletionRate;

	[Header("Fuel Visual System")]
	public List<Transform> fuelPoints = new List<Transform>();

	public int maxFuelAmount = 16;

	public readonly SyncList<string> fuelItemQueue = new SyncList<string>();

	[Header("Fuel Gauge")]
	[SerializeField]
	private Transform fuelMeterObject;

	[SerializeField]
	private Vector3 minFuelRotation = new Vector3(0f, 0f, -30f);

	[SerializeField]
	private Vector3 maxFuelRotation = new Vector3(0f, 0f, -145f);

	[Header("Production Settings")]
	public List<ProductionItem> productionItems = new List<ProductionItem>();

	public ChestController outputChest;

	[SerializeField]
	private float currentProductionProgress;

	[Header("Audio Settings")]
	[SerializeField]
	private AudioClip engineStartSound;

	[SerializeField]
	private AudioClip engineLoopSound;

	[SerializeField]
	private AudioSource engineAudioSource;

	[SerializeField]
	[Range(0f, 1f)]
	private float engineVolume = 0.7f;

	[SerializeField]
	[Range(0.1f, 2f)]
	private float volumeFadeOutDuration = 0.5f;

	[Header("Visual Effects")]
	[SerializeField]
	private ParticleSystem fireParticle;

	[SerializeField]
	private ParticleSystem steamParticle;

	[SerializeField]
	private Light fireLight;

	[Tooltip("Drill calistiginda aktif olacak objeler")]
	[SerializeField]
	private List<GameObject> activateOnRunning = new List<GameObject>();

	[Header("Lever Settings")]
	[SerializeField]
	private Transform leverObject;

	[SerializeField]
	private Vector3 leverOnRotation = new Vector3(-45f, 0f, 0f);

	[SerializeField]
	private Vector3 leverOffRotation = new Vector3(45f, 0f, 0f);

	[SerializeField]
	private float leverAnimationDuration = 0.3f;

	[Header("Events")]
	[HideInInspector]
	public UnityEvent OnDrillStarted = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnDrillStopped = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnFuelEmpty = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnFuelAdded = new UnityEvent();

	[HideInInspector]
	public UnityEvent<CollectableItemData, int> OnItemProduced = new UnityEvent<CollectableItemData, int>();

	[Header("Network Sync")]
	[SyncVar(hook = "OnFuelLevelChanged")]
	private float networkFuelLevel;

	[SyncVar(hook = "OnEngineStateChanged")]
	private bool networkEngineRunning;

	public readonly SyncList<float> productionProgressList = new SyncList<float>();

	private EngineAudioState currentAudioState;

	private Coroutine engineStartCoroutine;

	private bool isLoadingFromSave;

	private Coroutine leverAnimationCoroutine;

	private bool isAnimatorSlowingDown;

	[SerializeField]
	private float animatorSlowDownDuration = 1f;

	public bool IsActive { get; set; }

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

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

	public bool NetworknetworkEngineRunning
	{
		get
		{
			return networkEngineRunning;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkEngineRunning, 2uL, OnEngineStateChanged);
		}
	}

	public float GetFuelLevel()
	{
		return networkFuelLevel;
	}

	public bool IsEngineRunning()
	{
		return networkEngineRunning;
	}

	public float GetProductionProgress(int index)
	{
		if (index < 0 || index >= productionProgressList.Count)
		{
			return 0f;
		}
		return productionProgressList[index];
	}

	private void Awake()
	{
		baseFuelDepletionRate = 0.0033333334f;
		SetupAudioSources();
	}

	private void SetupAudioSources()
	{
		if (engineAudioSource == null)
		{
			GameObject gameObject = new GameObject("EngineAudioSource");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localPosition = Vector3.zero;
			engineAudioSource = gameObject.AddComponent<AudioSource>();
			engineAudioSource.loop = false;
			engineAudioSource.playOnAwake = false;
			engineAudioSource.spatialBlend = 1f;
			engineAudioSource.minDistance = 3f;
			engineAudioSource.maxDistance = 30f;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		fuelItemQueue.Callback += OnFuelQueueUpdated;
		StartCoroutine(InitializeFuelVisuals());
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
			NetworknetworkEngineRunning = false;
			InitializeProductionProgressList();
		}
		UpdateFuelGauge();
		UpdateVisualEffects();
		LoadData();
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveData);
		Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadData);
	}

	private void OnDisable()
	{
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveData);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.RemoveListener(LoadData);
		}
		OnInteractionDisable();
	}

	private void Update()
	{
		if (base.isServer)
		{
			ServerUpdate();
		}
		UpdateAnimator();
	}

	private void ServerUpdate()
	{
		if (networkEngineRunning && networkFuelLevel > 0f)
		{
			float num = baseFuelDepletionRate * Time.deltaTime;
			NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel - num);
			SyncFuelQueueWithLevel();
			if (networkFuelLevel <= 0f)
			{
				StopEngineServer();
				OnFuelEmpty.Invoke();
			}
			else
			{
				ProcessProduction();
			}
		}
	}

	[Server]
	private void InitializeProductionProgressList()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::InitializeProductionProgressList()' called when server was not active");
			return;
		}
		productionProgressList.Clear();
		for (int i = 0; i < productionItems.Count; i++)
		{
			productionProgressList.Add(0f);
		}
	}

	private void ProcessProduction()
	{
		if (productionItems.Count == 0 || outputChest == null)
		{
			return;
		}
		for (int i = 0; i < productionItems.Count; i++)
		{
			if (i < productionProgressList.Count)
			{
				ProductionItem item = productionItems[i];
				float num = productionProgressList[i] + Time.deltaTime;
				if (num >= item.ProductionTimeInSeconds)
				{
					ProduceItem(item);
					productionProgressList[i] = 0f;
				}
				else
				{
					productionProgressList[i] = num;
				}
			}
		}
	}

	[Server]
	private void ProduceItem(ProductionItem item)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::ProduceItem(ProductionItem)' called when server was not active");
		}
		else if (!(outputChest == null) && !(item.itemData == null))
		{
			if (TryAddItemToChest(item.itemData, item.quantity))
			{
				OnItemProduced.Invoke(item.itemData, item.quantity);
				RpcOnItemProduced(item.itemData.itemName, item.quantity);
			}
			else
			{
				Debug.Log("[DrillController] Could not add " + item.itemData.itemName + " to chest - chest might be full");
			}
		}
	}

	[Server]
	private bool TryAddItemToChest(CollectableItemData itemData, int quantity)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean DrillController::TryAddItemToChest(CollectableItemData,System.Int32)' called when server was not active");
			return default(bool);
		}
		if (outputChest == null)
		{
			return false;
		}
		int num = quantity;
		for (int i = 0; i < outputChest.inventorySlotsData.Count; i++)
		{
			if (num <= 0)
			{
				break;
			}
			InventorySlotsDataNetwork inventorySlotsDataNetwork = outputChest.inventorySlotsData[i];
			if (inventorySlotsDataNetwork.itemName == itemData.itemName && inventorySlotsDataNetwork.itemCountInSlot < inventorySlotsDataNetwork.maxCapacity)
			{
				int b = inventorySlotsDataNetwork.maxCapacity - inventorySlotsDataNetwork.itemCountInSlot;
				int num2 = Mathf.Min(num, b);
				InventorySlotsDataNetwork value = inventorySlotsDataNetwork;
				value.itemCountInSlot += num2;
				outputChest.inventorySlotsData[i] = value;
				num -= num2;
			}
		}
		for (int j = 0; j < outputChest.inventorySlotsData.Count; j++)
		{
			if (num <= 0)
			{
				break;
			}
			InventorySlotsDataNetwork inventorySlotsDataNetwork2 = outputChest.inventorySlotsData[j];
			if (string.IsNullOrEmpty(inventorySlotsDataNetwork2.itemName) || inventorySlotsDataNetwork2.itemCountInSlot <= 0)
			{
				int num3 = Mathf.Min(num, inventorySlotsDataNetwork2.maxCapacity);
				InventorySlotsDataNetwork value2 = inventorySlotsDataNetwork2;
				value2.itemName = itemData.itemName;
				value2.itemCountInSlot = num3;
				outputChest.inventorySlotsData[j] = value2;
				num -= num3;
			}
		}
		return num < quantity;
	}

	[ClientRpc]
	private void RpcOnItemProduced(string itemName, int quantity)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(quantity);
		SendRPCInternal("System.Void DrillController::RpcOnItemProduced(System.String,System.Int32)", 1310386558, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
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
		SendCommandInternal("System.Void DrillController::CmdStartEngine()", 22657630, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdStopEngine()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DrillController::CmdStopEngine()", -800351060, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void StartEngineServer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::StartEngineServer()' called when server was not active");
			return;
		}
		if (networkFuelLevel <= 0f)
		{
			Debug.Log("[DrillController] Cannot start - no fuel!");
			return;
		}
		NetworknetworkEngineRunning = true;
		OnDrillStarted.Invoke();
		RpcPlayEngineStart();
		Debug.Log("[DrillController] Engine started");
	}

	[Server]
	private void StopEngineServer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::StopEngineServer()' called when server was not active");
			return;
		}
		NetworknetworkEngineRunning = false;
		OnDrillStopped.Invoke();
		RpcPlayEngineStop();
		Debug.Log("[DrillController] Engine stopped");
	}

	private void OnFuelLevelChanged(float oldValue, float newValue)
	{
		fuelLevel = newValue;
		UpdateFuelGauge();
		UpdateVisualEffects();
		if (newValue <= 0f && networkEngineRunning && base.isServer)
		{
			StopEngineServer();
		}
	}

	private void OnEngineStateChanged(bool oldValue, bool newValue)
	{
		if (isLoadingFromSave)
		{
			return;
		}
		if (newValue)
		{
			if (!oldValue)
			{
				PlayEngineStartLocal();
				AnimateLever(toOnPosition: true);
			}
		}
		else if (oldValue)
		{
			PlayEngineStopLocal();
			AnimateLever(toOnPosition: false);
		}
		UpdateVisualEffects();
		Debug.Log("[DrillController] Engine state: " + (newValue ? "RUNNING" : "STOPPED"));
	}

	private void AnimateLever(bool toOnPosition)
	{
		if (!(leverObject == null))
		{
			if (leverAnimationCoroutine != null)
			{
				StopCoroutine(leverAnimationCoroutine);
			}
			leverAnimationCoroutine = StartCoroutine(AnimateLeverCoroutine(toOnPosition));
		}
	}

	private IEnumerator AnimateLeverCoroutine(bool toOnPosition)
	{
		Vector3 startRotation = leverObject.localEulerAngles;
		Vector3 targetRotation = (toOnPosition ? leverOnRotation : leverOffRotation);
		if (startRotation.x > 180f)
		{
			startRotation.x -= 360f;
		}
		if (startRotation.y > 180f)
		{
			startRotation.y -= 360f;
		}
		if (startRotation.z > 180f)
		{
			startRotation.z -= 360f;
		}
		float elapsed = 0f;
		while (elapsed < leverAnimationDuration)
		{
			elapsed += Time.deltaTime;
			float num = elapsed / leverAnimationDuration;
			float num2 = 1.70158f;
			num -= 1f;
			num = num * num * ((num2 + 1f) * num + num2) + 1f;
			Vector3 localEulerAngles = Vector3.Lerp(startRotation, targetRotation, num);
			leverObject.localEulerAngles = localEulerAngles;
			yield return null;
		}
		leverObject.localEulerAngles = targetRotation;
		leverAnimationCoroutine = null;
	}

	private void SetLeverPositionImmediate(bool toOnPosition)
	{
		if (!(leverObject == null))
		{
			Vector3 localEulerAngles = (toOnPosition ? leverOnRotation : leverOffRotation);
			leverObject.localEulerAngles = localEulerAngles;
		}
	}

	private void PlayLoopSoundDirectly()
	{
		if (engineAudioSource != null && engineLoopSound != null)
		{
			currentAudioState = EngineAudioState.Running;
			engineAudioSource.loop = true;
			engineAudioSource.clip = engineLoopSound;
			engineAudioSource.volume = engineVolume;
			engineAudioSource.Play();
		}
	}

	[ClientRpc]
	private void RpcPlayEngineStart()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DrillController::RpcPlayEngineStart()", -1485579077, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayEngineStop()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DrillController::RpcPlayEngineStop()", 1060869547, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void PlayEngineStartLocal()
	{
		if (currentAudioState != EngineAudioState.Running && currentAudioState != EngineAudioState.Starting)
		{
			if (engineStartCoroutine != null)
			{
				StopCoroutine(engineStartCoroutine);
			}
			engineStartCoroutine = StartCoroutine(EngineStartSequence());
		}
	}

	private IEnumerator EngineStartSequence()
	{
		currentAudioState = EngineAudioState.Starting;
		float num = 0f;
		if (engineAudioSource != null && engineStartSound != null)
		{
			engineAudioSource.loop = false;
			engineAudioSource.clip = engineStartSound;
			engineAudioSource.volume = engineVolume;
			engineAudioSource.Play();
			num = engineStartSound.length;
		}
		if (num > 0f)
		{
			yield return new WaitForSeconds(num);
		}
		if (networkEngineRunning)
		{
			currentAudioState = EngineAudioState.Running;
			if (engineAudioSource != null && engineLoopSound != null)
			{
				engineAudioSource.loop = true;
				engineAudioSource.clip = engineLoopSound;
				engineAudioSource.volume = engineVolume;
				engineAudioSource.Play();
			}
		}
		else
		{
			currentAudioState = EngineAudioState.Off;
		}
	}

	private void PlayEngineStopLocal()
	{
		if (engineStartCoroutine != null)
		{
			StopCoroutine(engineStartCoroutine);
		}
		currentAudioState = EngineAudioState.Stopping;
		if (engineAudioSource != null && engineAudioSource.isPlaying)
		{
			StartCoroutine(FadeOutAndStop());
		}
		else
		{
			currentAudioState = EngineAudioState.Off;
		}
	}

	private IEnumerator FadeOutAndStop()
	{
		float startVolume = engineAudioSource.volume;
		float elapsed = 0f;
		while (elapsed < volumeFadeOutDuration)
		{
			elapsed += Time.deltaTime;
			engineAudioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / volumeFadeOutDuration);
			yield return null;
		}
		engineAudioSource.Stop();
		engineAudioSource.volume = engineVolume;
		currentAudioState = EngineAudioState.Off;
	}

	private void UpdateFuelGauge()
	{
		if (fuelMeterObject != null)
		{
			float t = Mathf.Clamp01(fuelLevel);
			Vector3 localEulerAngles = Vector3.Lerp(minFuelRotation, maxFuelRotation, t);
			fuelMeterObject.localEulerAngles = localEulerAngles;
		}
	}

	private void UpdateVisualEffects()
	{
		bool flag = networkEngineRunning && fuelLevel > 0f;
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
		if (steamParticle != null)
		{
			if (flag && !steamParticle.isPlaying)
			{
				steamParticle.Play(withChildren: true);
			}
			else if (!flag && steamParticle.isPlaying)
			{
				steamParticle.Stop(withChildren: true);
			}
		}
		if (fireLight != null)
		{
			fireLight.enabled = flag;
		}
		foreach (GameObject item in activateOnRunning)
		{
			if (item != null && item.activeSelf != flag)
			{
				item.SetActive(flag);
			}
		}
	}

	private void UpdateAnimator()
	{
		if (!(animator != null))
		{
			return;
		}
		if (networkEngineRunning && networkFuelLevel > 0f)
		{
			animator.SetBool(animationKey, value: true);
			if (!isAnimatorSlowingDown)
			{
				animator.speed = 1f;
			}
		}
		else if (!isAnimatorSlowingDown && animator.speed > 0f)
		{
			StartCoroutine(SlowDownAnimator());
		}
	}

	private IEnumerator SlowDownAnimator()
	{
		isAnimatorSlowingDown = true;
		float startSpeed = animator.speed;
		float elapsed = 0f;
		while (elapsed < animatorSlowDownDuration)
		{
			if (networkEngineRunning && networkFuelLevel > 0f)
			{
				animator.speed = 1f;
				isAnimatorSlowingDown = false;
				yield break;
			}
			elapsed += Time.deltaTime;
			animator.speed = Mathf.Lerp(startSpeed, 0f, elapsed / animatorSlowDownDuration);
			yield return null;
		}
		animator.speed = 0f;
		isAnimatorSlowingDown = false;
	}

	public bool IsFuelItem(CollectableItemData item)
	{
		return fuelItems.Exists((TrainFuelData x) => x.item == item);
	}

	public float GetFuelEfficiency(CollectableItemData item)
	{
		return fuelItems.Find((TrainFuelData x) => x.item == item)?.efficiency ?? 0f;
	}

	public bool TryAddFuel(PlayerInventory playerInventory, CollectableItemData fuelItem)
	{
		if (!IsFuelItem(fuelItem))
		{
			Debug.Log("[DrillController] " + fuelItem?.itemName + " is not a valid fuel item!");
			return false;
		}
		if (networkFuelLevel >= 1f)
		{
			Debug.Log("[DrillController] Fuel tank is full!");
			return false;
		}
		InventorySlotsData inventorySlotsData = playerInventory.FindItemOnInventory(fuelItem);
		if (inventorySlotsData == null || inventorySlotsData.itemCountInSlot <= 0)
		{
			Debug.Log("[DrillController] No " + fuelItem.itemName + " in inventory!");
			return false;
		}
		float fuelEfficiency = GetFuelEfficiency(fuelItem);
		if (base.isServer)
		{
			AddFuelServer(fuelEfficiency);
			AddFuelToQueue(fuelItem.itemName);
		}
		else
		{
			CmdAddFuel(fuelEfficiency);
			CmdAddFuelToQueue(fuelItem.itemName);
		}
		playerInventory.DecreaseItemOnInventorySlot(inventorySlotsData, 1);
		Debug.Log($"[DrillController] Added {fuelItem.itemName} to fuel (+{fuelEfficiency * 100f}%)");
		return true;
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuelToQueue(string fuelItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(fuelItemName);
		SendCommandInternal("System.Void DrillController::CmdAddFuelToQueue(System.String)", -791337093, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdAddFuel(float efficiency)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(efficiency);
		SendCommandInternal("System.Void DrillController::CmdAddFuel(System.Single)", -45182342, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void AddFuelServer(float efficiency)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::AddFuelServer(System.Single)' called when server was not active");
			return;
		}
		NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel + efficiency);
		OnFuelAdded.Invoke();
	}

	[Server]
	private void AddFuelToQueue(string fuelItemName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::AddFuelToQueue(System.String)' called when server was not active");
		}
		else if (fuelItemQueue.Count < maxFuelAmount)
		{
			fuelItemQueue.Add(fuelItemName);
		}
	}

	[Server]
	private void SyncFuelQueueWithLevel()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void DrillController::SyncFuelQueueWithLevel()' called when server was not active");
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

	public void SaveData()
	{
		if (!base.isServer)
		{
			return;
		}
		string saveKey = GetSaveKey();
		Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_FuelLevel", networkFuelLevel);
		Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_EngineRunning", networkEngineRunning);
		List<float> value = new List<float>(productionProgressList);
		Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_ProductionProgressList", value);
		List<string> value2 = new List<string>(fuelItemQueue);
		Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_FuelQueue", value2);
		if (outputChest != null)
		{
			List<string> list = new List<string>();
			List<int> list2 = new List<int>();
			foreach (InventorySlotsDataNetwork inventorySlotsDatum in outputChest.inventorySlotsData)
			{
				list.Add(inventorySlotsDatum.itemName ?? "");
				list2.Add(inventorySlotsDatum.itemCountInSlot);
			}
			Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_ChestItemNames", list);
			Singleton<ES3SaveManager>.Instance.SaveData(saveKey + "_ChestItemCounts", list2);
		}
		Debug.Log($"[DrillController] Data saved - Fuel: {networkFuelLevel:F2}, Running: {networkEngineRunning}");
	}

	public void LoadData()
	{
		if (!base.isServer)
		{
			return;
		}
		isLoadingFromSave = true;
		string saveKey = GetSaveKey();
		NetworknetworkFuelLevel = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_FuelLevel", 0f);
		NetworknetworkEngineRunning = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_EngineRunning", defaultValue: false);
		List<float> list = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_ProductionProgressList", new List<float>());
		productionProgressList.Clear();
		for (int i = 0; i < productionItems.Count; i++)
		{
			float item = ((i < list.Count) ? list[i] : 0f);
			productionProgressList.Add(item);
		}
		List<string> list2 = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_FuelQueue", new List<string>());
		fuelItemQueue.Clear();
		foreach (string item2 in list2)
		{
			fuelItemQueue.Add(item2);
		}
		fuelLevel = networkFuelLevel;
		if (outputChest != null)
		{
			StartCoroutine(DelayedChestLoad(saveKey));
		}
		UpdateFuelGauge();
		UpdateVisualEffects();
		UpdateAllFuelVisuals();
		if (networkEngineRunning && networkFuelLevel > 0f)
		{
			SetLeverPositionImmediate(toOnPosition: true);
			StartCoroutine(DelayedLoopSound());
		}
		else
		{
			SetLeverPositionImmediate(toOnPosition: false);
		}
		isLoadingFromSave = false;
	}

	private IEnumerator DelayedChestLoad(string saveKey)
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		while (outputChest != null && outputChest.inventorySlotsData.Count == 0)
		{
			yield return new WaitForSeconds(0.1f);
		}
		if (!(outputChest == null))
		{
			List<string> list = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_ChestItemNames", new List<string>());
			List<int> list2 = Singleton<ES3SaveManager>.Instance.LoadData(saveKey + "_ChestItemCounts", new List<int>());
			for (int i = 0; i < outputChest.inventorySlotsData.Count && i < list.Count; i++)
			{
				InventorySlotsDataNetwork value = outputChest.inventorySlotsData[i];
				value.itemName = list[i];
				value.itemCountInSlot = ((i < list2.Count) ? list2[i] : 0);
				outputChest.inventorySlotsData[i] = value;
			}
		}
	}

	private IEnumerator DelayedLoopSound()
	{
		yield return new WaitForSeconds(0.5f);
		if (networkEngineRunning && networkFuelLevel > 0f)
		{
			PlayLoopSoundDirectly();
			RpcPlayLoopSoundDirectly();
		}
	}

	[ClientRpc]
	private void RpcPlayLoopSoundDirectly()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DrillController::RpcPlayLoopSoundDirectly()", 129140444, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private string GetSaveKey()
	{
		NetworkIdentity component = GetComponent<NetworkIdentity>();
		if (component != null && component.netId != 0)
		{
			return $"Drill_{component.netId}";
		}
		return $"Drill_{base.transform.position.GetHashCode()}";
	}

	private void EditorStartEngine()
	{
		if (Application.isPlaying)
		{
			StartEngineManual();
		}
	}

	private void EditorStopEngine()
	{
		if (Application.isPlaying)
		{
			StopEngineManual();
		}
	}

	private void EditorAddFuel()
	{
		if (Application.isPlaying && base.isServer)
		{
			NetworknetworkFuelLevel = Mathf.Clamp01(networkFuelLevel + 0.5f);
			fuelLevel = networkFuelLevel;
			UpdateFuelGauge();
			UpdateVisualEffects();
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (!isShowingInteraction)
		{
			ShowInteract(player.transform);
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		HideInteract();
		isShowingInteraction = false;
	}

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void OnInteractionDisable()
	{
		if (isShowingInteraction)
		{
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			isShowingInteraction = false;
		}
	}

	private void ShowInteract(Transform playerTransform)
	{
		_ = InteractionPanel.Instance == null;
	}

	private void HideInteract()
	{
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanels();
		}
	}

	private void Remove(PlayerInventory player)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		if (component != null)
		{
			component.Remove(player);
		}
	}

	private void Dismantle(Transform playerTransform)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		Grabber component2 = playerTransform.GetComponent<Grabber>();
		TSPlayerController component3 = playerTransform.GetComponent<TSPlayerController>();
		if (component != null && component2 != null && component3 != null)
		{
			component.Dismantle(component2, component3);
		}
	}

	public DrillController()
	{
		InitSyncObject(fuelItemQueue);
		InitSyncObject(productionProgressList);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOnItemProduced__String__Int32(string itemName, int quantity)
	{
	}

	protected static void InvokeUserCode_RpcOnItemProduced__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnItemProduced called on server.");
		}
		else
		{
			((DrillController)obj).UserCode_RpcOnItemProduced__String__Int32(reader.ReadString(), reader.ReadInt());
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
			((DrillController)obj).UserCode_CmdStartEngine();
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
			((DrillController)obj).UserCode_CmdStopEngine();
		}
	}

	protected void UserCode_RpcPlayEngineStart()
	{
		PlayEngineStartLocal();
	}

	protected static void InvokeUserCode_RpcPlayEngineStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayEngineStart called on server.");
		}
		else
		{
			((DrillController)obj).UserCode_RpcPlayEngineStart();
		}
	}

	protected void UserCode_RpcPlayEngineStop()
	{
		PlayEngineStopLocal();
	}

	protected static void InvokeUserCode_RpcPlayEngineStop(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayEngineStop called on server.");
		}
		else
		{
			((DrillController)obj).UserCode_RpcPlayEngineStop();
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
			((DrillController)obj).UserCode_CmdAddFuelToQueue__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddFuel__Single(float efficiency)
	{
		AddFuelServer(efficiency);
	}

	protected static void InvokeUserCode_CmdAddFuel__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddFuel called on client.");
		}
		else
		{
			((DrillController)obj).UserCode_CmdAddFuel__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_RpcPlayLoopSoundDirectly()
	{
		PlayLoopSoundDirectly();
	}

	protected static void InvokeUserCode_RpcPlayLoopSoundDirectly(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayLoopSoundDirectly called on server.");
		}
		else
		{
			((DrillController)obj).UserCode_RpcPlayLoopSoundDirectly();
		}
	}

	static DrillController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DrillController), "System.Void DrillController::CmdStartEngine()", InvokeUserCode_CmdStartEngine, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DrillController), "System.Void DrillController::CmdStopEngine()", InvokeUserCode_CmdStopEngine, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DrillController), "System.Void DrillController::CmdAddFuelToQueue(System.String)", InvokeUserCode_CmdAddFuelToQueue__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DrillController), "System.Void DrillController::CmdAddFuel(System.Single)", InvokeUserCode_CmdAddFuel__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DrillController), "System.Void DrillController::RpcOnItemProduced(System.String,System.Int32)", InvokeUserCode_RpcOnItemProduced__String__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(DrillController), "System.Void DrillController::RpcPlayEngineStart()", InvokeUserCode_RpcPlayEngineStart);
		RemoteProcedureCalls.RegisterRpc(typeof(DrillController), "System.Void DrillController::RpcPlayEngineStop()", InvokeUserCode_RpcPlayEngineStop);
		RemoteProcedureCalls.RegisterRpc(typeof(DrillController), "System.Void DrillController::RpcPlayLoopSoundDirectly()", InvokeUserCode_RpcPlayLoopSoundDirectly);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(networkFuelLevel);
			writer.WriteBool(networkEngineRunning);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(networkFuelLevel);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(networkEngineRunning);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref networkFuelLevel, OnFuelLevelChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref networkEngineRunning, OnEngineStateChanged, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkFuelLevel, OnFuelLevelChanged, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkEngineRunning, OnEngineStateChanged, reader.ReadBool());
		}
	}
}
