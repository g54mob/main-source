using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using EAST_UP;
using HQFPSTemplate;
using JUTPS.CameraSystems;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TSPlayerController : NetworkBehaviour
{
	public bool isOnTrain;

	public GameObject deathInventoryChest;

	public GameObject playerReveiver;

	public Camera worldCamera;

	public Transform tpsPlayer;

	public Vector3 tpsLocalPosition;

	public LayerMask trainLayer;

	public LayerMask terrainLayer;

	public float raycastDistance = 0.2f;

	public Transform connectedObject;

	[HideInInspector]
	public TPSCameraController tpsCameraController;

	public TPSCharacterPartsHolder tpsCharacterPartsHolder;

	private CharacterController characterController;

	private PlayerMovement playerMovement;

	private bool checkTrain = true;

	private float defaultSlopeLimit;

	private const float TRAIN_SLOPE_LIMIT = 65f;

	public TsPlayerAnimationController animationController;

	[SyncVar]
	public bool isSleeping;

	private Transform parentObject;

	public Transform playerTarget;

	public Transform playerSpine;

	public GameObject uiParent;

	public Camera activeCamera;

	[SyncVar]
	public bool isDeath;

	[SyncVar]
	public bool spawnProtected = true;

	private const float SPAWN_PROTECTION_MAX_DURATION = 5f;

	private float spawnProtectionEndTime;

	[SyncVar]
	private Vector3 networkPosition;

	[SyncVar]
	private Quaternion networkRotation;

	[SyncVar]
	private Vector3 trainLocalPosition;

	[SyncVar]
	private Quaternion trainLocalRotation;

	[SyncVar(hook = "OnTrainStateChanged")]
	private bool networkIsOnTrain;

	[SyncVar(hook = "OnConnectedTrainChanged")]
	private uint connectedTrainId;

	[SyncVar(hook = "OnConnectedWagonChanged")]
	private int connectedWagonId = -1;

	private float lastSync;

	private float syncRate = 25f;

	private float positionThreshold = 0.05f;

	private float rotationThreshold = 2f;

	private bool wasSyncingLocal;

	private bool wasSyncingWorld;

	private Vector3 remoteLocalVelocity;

	private Vector3 remoteWorldVelocity;

	private Vector3 lastReceivedLocalPos;

	private float lastLocalReceiveTime;

	private Vector3 lastReceivedWorldPos;

	private float lastWorldReceiveTime;

	private Vector3 localPositionError;

	private Vector3 worldPositionError;

	private float playerErrorCorrectionSpeed = 10f;

	public BuildingHammerController buildingHammerController;

	private WrenchController wrenchController;

	public CanvasGroup playerCanvas;

	public TSPlayerStatusHolder playerStatusHolder;

	private BedProp sleepingBed;

	[SerializeField]
	private Vector3 tpsPlayerDefaultPos;

	[SerializeField]
	private Vector3 tpsPlayerDefaultRot;

	private Vector3 lastSafePosition;

	private float safePositionUpdateInterval = 0.5f;

	private float lastSafePositionUpdateTime;

	[Tooltip("Bu Y değerinin altına düşen oyuncu güvenli pozisyona teleport edilir")]
	public float terrainMinPos = -10f;

	private TrainController trainController;

	private bl_Compass compass;

	private PlayerStatusPanel playerStatusPanel;

	private DeathScreenUI deathScreenUI;

	private CameraPositionController cameraPositionController;

	private CameraRigController cameraRigController;

	private float sleepTime;

	private uint serverBedNetId;

	public bool NetworkisSleeping
	{
		get
		{
			return isSleeping;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isSleeping, 1uL, null);
		}
	}

	public bool NetworkisDeath
	{
		get
		{
			return isDeath;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isDeath, 2uL, null);
		}
	}

	public bool NetworkspawnProtected
	{
		get
		{
			return spawnProtected;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref spawnProtected, 4uL, null);
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
			GeneratedSyncVarSetter(value, ref networkPosition, 8uL, null);
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
			GeneratedSyncVarSetter(value, ref networkRotation, 16uL, null);
		}
	}

	public Vector3 NetworktrainLocalPosition
	{
		get
		{
			return trainLocalPosition;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref trainLocalPosition, 32uL, null);
		}
	}

	public Quaternion NetworktrainLocalRotation
	{
		get
		{
			return trainLocalRotation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref trainLocalRotation, 64uL, null);
		}
	}

	public bool NetworknetworkIsOnTrain
	{
		get
		{
			return networkIsOnTrain;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkIsOnTrain, 128uL, OnTrainStateChanged);
		}
	}

	public uint NetworkconnectedTrainId
	{
		get
		{
			return connectedTrainId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedTrainId, 256uL, OnConnectedTrainChanged);
		}
	}

	public int NetworkconnectedWagonId
	{
		get
		{
			return connectedWagonId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedWagonId, 512uL, OnConnectedWagonChanged);
		}
	}

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		defaultSlopeLimit = characterController.slopeLimit;
	}

	private void Start()
	{
		playerStatusHolder = GetComponentInChildren<TSPlayerStatusHolder>();
		tpsCharacterPartsHolder = GetComponent<TPSCharacterPartsHolder>();
		parentObject = base.transform.parent;
		animationController = GetComponentInChildren<TsPlayerAnimationController>();
		if (buildingHammerController == null)
		{
			buildingHammerController = GetComponentInChildren<BuildingHammerController>(includeInactive: true);
		}
		wrenchController = GetComponentInChildren<WrenchController>(includeInactive: true);
		cameraPositionController = GetComponentInChildren<CameraPositionController>();
		cameraRigController = GetComponentInChildren<CameraRigController>();
		playerMovement = GetComponent<PlayerMovement>();
		if (isOnTrain)
		{
			characterController.slopeLimit = 65f;
		}
		NetworknetworkPosition = base.transform.position;
		NetworknetworkRotation = base.transform.rotation;
		lastSafePosition = base.transform.position;
		trainController = UnityEngine.Object.FindObjectOfType<TrainController>();
		playerStatusPanel = UnityEngine.Object.FindObjectOfType<PlayerStatusPanel>();
		deathScreenUI = UnityEngine.Object.FindObjectOfType<DeathScreenUI>(includeInactive: true);
		if (!trainController.tsPlayers.Contains(this))
		{
			trainController.tsPlayers.Add(this);
		}
		GetComponent<EASTUP_CameraController>().OnCameraModeChanged.AddListener(ChanceActiveCamera);
		if (base.isLocalPlayer)
		{
			compass = UnityEngine.Object.FindObjectOfType<bl_Compass>();
			compass.playerCamera = activeCamera;
			GetComponentInChildren<bl_CompassMagnet>().SetCompass();
			tpsPlayer.transform.localPosition = tpsLocalPosition;
		}
		if (base.hasAuthority)
		{
			BeginSpawnProtection();
		}
	}

	private void OnEnable()
	{
		ZombieController.RegisterPlayer(this);
	}

	private void OnDisable()
	{
		ZombieController.UnregisterPlayer(this);
		if (trainController != null)
		{
			trainController.tsPlayers.Remove(this);
		}
	}

	private void Update()
	{
		if (checkTrain && base.hasAuthority)
		{
			IsOnTrain();
		}
		if (base.hasAuthority && !isDeath)
		{
			CheckFallThroughTerrain();
		}
		if (base.hasAuthority && spawnProtected)
		{
			UpdateSpawnProtection();
		}
		if (isSleeping && !TrainGameManager.isSkippingToMorning && Time.time - sleepTime > 1.5f && (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) || Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey)))
		{
			WakeUp();
		}
		if (!isSleeping)
		{
			if (base.hasAuthority)
			{
				HandleMovementSync();
			}
			else
			{
				HandleMovementApply();
			}
		}
	}

	private void OnTrainStateChanged(bool oldValue, bool newValue)
	{
		if (!base.hasAuthority)
		{
			if (newValue && connectedTrainId != 0)
			{
				UpdateParentFromNetwork();
				base.transform.localPosition = trainLocalPosition;
				base.transform.localRotation = trainLocalRotation;
				remoteLocalVelocity = Vector3.zero;
				localPositionError = Vector3.zero;
				lastReceivedLocalPos = trainLocalPosition;
				lastLocalReceiveTime = Time.unscaledTime;
				isOnTrain = true;
			}
			else
			{
				Vector3 position = base.transform.position;
				Quaternion rotation = base.transform.rotation;
				base.transform.parent = parentObject;
				isOnTrain = false;
				connectedObject = null;
				base.transform.position = position;
				base.transform.rotation = rotation;
				remoteWorldVelocity = Vector3.zero;
				worldPositionError = Vector3.zero;
				lastReceivedWorldPos = position;
				lastWorldReceiveTime = Time.unscaledTime;
			}
		}
	}

	private void OnConnectedTrainChanged(uint oldValue, uint newValue)
	{
		if (!base.hasAuthority && networkIsOnTrain && newValue != 0)
		{
			UpdateParentFromNetwork();
			base.transform.localPosition = trainLocalPosition;
			base.transform.localRotation = trainLocalRotation;
		}
	}

	private void OnConnectedWagonChanged(int oldValue, int newValue)
	{
		if (!base.hasAuthority && networkIsOnTrain)
		{
			UpdateParentFromNetwork();
			base.transform.localPosition = trainLocalPosition;
			base.transform.localRotation = trainLocalRotation;
		}
	}

	public void RefreshNetworkParent()
	{
		if (!base.hasAuthority && networkIsOnTrain && connectedTrainId != 0)
		{
			UpdateParentFromNetwork();
			base.transform.localPosition = trainLocalPosition;
			base.transform.localRotation = trainLocalRotation;
			remoteLocalVelocity = Vector3.zero;
			localPositionError = Vector3.zero;
			lastReceivedLocalPos = trainLocalPosition;
			lastLocalReceiveTime = Time.unscaledTime;
			isOnTrain = true;
		}
	}

	private void UpdateParentFromNetwork()
	{
		if (connectedTrainId == 0)
		{
			Debug.LogWarning("[Client] " + base.gameObject.name + " - UpdateParentFromNetwork: connectedTrainId = 0");
			return;
		}
		TrainController trainById = GetTrainById(connectedTrainId);
		if (trainById == null)
		{
			Debug.LogWarning($"[Client] {base.gameObject.name} - Train bulunamadı! TrainID: {connectedTrainId}");
			return;
		}
		Debug.Log($"[Client] {base.gameObject.name} - UpdateParentFromNetwork çağrıldı. WagonID: {connectedWagonId}, TrainID: {connectedTrainId}");
		if (connectedWagonId >= 0)
		{
			WagonController wagonByID = trainById.GetWagonByID(connectedWagonId);
			if (wagonByID != null)
			{
				base.transform.parent = wagonByID.transform;
				connectedObject = wagonByID.transform;
				Debug.Log($"[Client] {base.gameObject.name} - Parent güncellendi: Wagon {connectedWagonId} ({wagonByID.gameObject.name})");
				return;
			}
			Debug.LogWarning($"[Client] {base.gameObject.name} - Wagon {connectedWagonId} bulunamadı! Train'de {trainById.wagonControllers.Count} wagon var.");
		}
		base.transform.parent = trainById.transform;
		connectedObject = trainById.transform;
		Debug.Log($"[Client] {base.gameObject.name} - Parent güncellendi: Train (locomotive) - WagonID: {connectedWagonId}");
	}

	public void HidePlayerCanvas()
	{
		playerCanvas.alpha = 0f;
		playerCanvas.interactable = false;
	}

	public void ShowPlayerCanvas()
	{
		playerCanvas.alpha = 1f;
		playerCanvas.interactable = true;
	}

	private void HandleMovementSync()
	{
		if (!(Time.time - lastSync >= 1f / syncRate))
		{
			return;
		}
		if (isOnTrain && connectedObject != null)
		{
			Vector3 localPosition = base.transform.localPosition;
			Quaternion localRotation = base.transform.localRotation;
			if (Vector3.Distance(localPosition, trainLocalPosition) > positionThreshold || Quaternion.Angle(localRotation, trainLocalRotation) > rotationThreshold)
			{
				CmdUpdateTrainLocalPosition(localPosition, localRotation, isSettle: false);
				wasSyncingLocal = true;
			}
			else if (wasSyncingLocal)
			{
				CmdUpdateTrainLocalPosition(localPosition, localRotation, isSettle: true);
				wasSyncingLocal = false;
			}
			wasSyncingWorld = false;
		}
		else
		{
			Vector3 position = base.transform.position;
			Quaternion rotation = base.transform.rotation;
			if (Vector3.Distance(position, networkPosition) > positionThreshold || Quaternion.Angle(rotation, networkRotation) > rotationThreshold)
			{
				CmdUpdateWorldPosition(position, rotation, isSettle: false);
				wasSyncingWorld = true;
			}
			else if (wasSyncingWorld)
			{
				CmdUpdateWorldPosition(position, rotation, isSettle: true);
				wasSyncingWorld = false;
			}
			wasSyncingLocal = false;
		}
		lastSync = Time.time;
	}

	private void HandleMovementApply()
	{
		if (isSleeping)
		{
			return;
		}
		float num = playerErrorCorrectionSpeed;
		float t = 1f - Mathf.Exp((0f - syncRate) * Time.deltaTime);
		if (networkIsOnTrain && connectedObject != null)
		{
			if (Time.unscaledTime - lastLocalReceiveTime > 2f / syncRate)
			{
				remoteLocalVelocity = Vector3.Lerp(remoteLocalVelocity, Vector3.zero, Time.deltaTime * 5f);
			}
			if (remoteLocalVelocity.sqrMagnitude > 0.001f)
			{
				base.transform.localPosition += remoteLocalVelocity * Time.deltaTime;
			}
			if (localPositionError.sqrMagnitude > 0.0001f)
			{
				Vector3 vector = localPositionError * Mathf.Min(num * Time.deltaTime, 1f);
				base.transform.localPosition += vector;
				localPositionError -= vector;
			}
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, trainLocalRotation, t);
		}
		else
		{
			if (Time.unscaledTime - lastWorldReceiveTime > 2f / syncRate)
			{
				remoteWorldVelocity = Vector3.Lerp(remoteWorldVelocity, Vector3.zero, Time.deltaTime * 5f);
			}
			if (remoteWorldVelocity.sqrMagnitude > 0.001f)
			{
				base.transform.position += remoteWorldVelocity * Time.deltaTime;
			}
			if (worldPositionError.sqrMagnitude > 0.0001f)
			{
				Vector3 vector2 = worldPositionError * Mathf.Min(num * Time.deltaTime, 1f);
				base.transform.position += vector2;
				worldPositionError -= vector2;
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, networkRotation, t);
		}
	}

	private TrainController GetTrainById(uint trainId)
	{
		if (trainId == 0)
		{
			return null;
		}
		if (NetworkClient.spawned.ContainsKey(trainId))
		{
			return NetworkClient.spawned[trainId].GetComponent<TrainController>();
		}
		return null;
	}

	[Command]
	private void CmdUpdateTrainLocalPosition(Vector3 localPos, Quaternion localRot, bool isSettle)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPos);
		writer.WriteQuaternion(localRot);
		writer.WriteBool(isSettle);
		SendCommandInternal("System.Void TSPlayerController::CmdUpdateTrainLocalPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", 1440239445, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc(includeOwner = false)]
	private void RpcUpdateTrainLocalPosition(Vector3 localPos, Quaternion localRot, bool isSettle)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPos);
		writer.WriteQuaternion(localRot);
		writer.WriteBool(isSettle);
		SendRPCInternal("System.Void TSPlayerController::RpcUpdateTrainLocalPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", 1242636490, writer, 0, includeOwner: false);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdUpdateWorldPosition(Vector3 worldPos, Quaternion worldRot, bool isSettle)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(worldPos);
		writer.WriteQuaternion(worldRot);
		writer.WriteBool(isSettle);
		SendCommandInternal("System.Void TSPlayerController::CmdUpdateWorldPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", -1624745908, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc(includeOwner = false)]
	private void RpcUpdateWorldPosition(Vector3 worldPos, Quaternion worldRot, bool isSettle)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(worldPos);
		writer.WriteQuaternion(worldRot);
		writer.WriteBool(isSettle);
		SendRPCInternal("System.Void TSPlayerController::RpcUpdateWorldPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", 1492496823, writer, 0, includeOwner: false);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdSetOnTrainTrue(uint trainNetId, int wagonId, Vector3 worldPos, Quaternion worldRot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteUInt(trainNetId);
		writer.WriteInt(wagonId);
		writer.WriteVector3(worldPos);
		writer.WriteQuaternion(worldRot);
		SendCommandInternal("System.Void TSPlayerController::CmdSetOnTrainTrue(System.UInt32,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", -1605190863, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc(includeOwner = false)]
	private void RpcSetTrainPositionAndState(uint trainNetId, int wagonId, Vector3 worldPos, Quaternion worldRot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteUInt(trainNetId);
		writer.WriteInt(wagonId);
		writer.WriteVector3(worldPos);
		writer.WriteQuaternion(worldRot);
		SendRPCInternal("System.Void TSPlayerController::RpcSetTrainPositionAndState(System.UInt32,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", -2144506414, writer, 0, includeOwner: false);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdSetOnTrainFalse()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TSPlayerController::CmdSetOnTrainFalse()", 1541983011, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdActivateReveiverObject(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendCommandInternal("System.Void TSPlayerController::CmdActivateReveiverObject(System.Boolean)", -921594880, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RpcActivateReveiverObject(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendRPCInternal("System.Void TSPlayerController::RpcActivateReveiverObject(System.Boolean)", 1120728171, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ChanceActiveCamera(CameraMode mode)
	{
		switch (mode)
		{
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdSetDeathState(bool deathState)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(deathState);
		SendCommandInternal("System.Void TSPlayerController::CmdSetDeathState(System.Boolean)", 1635232413, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetSpawnProtected(bool value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(value);
		SendCommandInternal("System.Void TSPlayerController::CmdSetSpawnProtected(System.Boolean)", 1070969491, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void BeginSpawnProtection()
	{
		spawnProtectionEndTime = Time.time + 5f;
		CmdSetSpawnProtected(value: true);
	}

	private void UpdateSpawnProtection()
	{
		if (Time.time >= spawnProtectionEndTime || HasProtectionBreakingInput())
		{
			CmdSetSpawnProtected(value: false);
		}
	}

	private bool HasProtectionBreakingInput()
	{
		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f)
		{
			return true;
		}
		if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f)
		{
			return true;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			return true;
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			return true;
		}
		return false;
	}

	public void ToFaint()
	{
		if (isDeath)
		{
			Debug.Log("[Death] Already dead, ignoring ToFaint() call");
			return;
		}
		Debug.Log($"[Death] Custom Health: {playerStatusHolder.playerHpFuel}");
		NetworkisDeath = true;
		if (cameraRigController != null)
		{
			Debug.Log("[ToFaint] CameraRigController found, clearing weapon. CurrentWeapon was: " + ((cameraRigController.currentWeapon != null) ? cameraRigController.currentWeapon.name : "null"));
			cameraRigController.SetActive(active: false);
			cameraRigController.ClearWeapon();
		}
		else
		{
			Debug.LogWarning("[ToFaint] CameraRigController is NULL!");
		}
		playerStatusPanel.HidePanel();
		GetComponent<Interactor>().enabled = false;
		tpsCharacterPartsHolder.EnableTPSParts();
		deathScreenUI.ShowPanel();
		if (base.hasAuthority)
		{
			CmdSetDeathState(deathState: true);
			cameraPositionController.DeatchCamera();
			CmdActivateReveiverObject(active: true);
		}
		LockPlayer();
		animationController.Faint();
		if (animationController.weaponVisuals != null)
		{
			animationController.weaponVisuals.ResetOnDeath();
		}
	}

	public void ToReveive()
	{
		NetworkisDeath = false;
		if (base.hasAuthority)
		{
			BeginSpawnProtection();
		}
		if (base.isOwned)
		{
			CmdEnableTpsBase();
		}
		tpsCharacterPartsHolder.DisableTPSParts();
		deathScreenUI.HidePanel();
		InteractionPanel.Instance.HideAllInteractions();
		if (base.hasAuthority)
		{
			CmdSetDeathState(deathState: false);
			cameraPositionController.ResetCameraPos();
			CmdActivateReveiverObject(active: false);
		}
		if (cameraRigController != null)
		{
			cameraRigController.SetActive(active: true);
			cameraRigController.ClearWeapon();
		}
		GetComponent<Interactor>().enabled = true;
		UnLockPlayer();
		animationController.Revive();
		if (animationController.weaponVisuals != null)
		{
			animationController.weaponVisuals.ResetOnRevive();
		}
		playerStatusHolder.playerFoodFuel = 50f;
		playerStatusHolder.playerHpFuel = 50f;
		playerStatusHolder.playerWaterFuel = 50f;
		HQFPSTemplate.Player component = GetComponent<HQFPSTemplate.Player>();
		if (component != null)
		{
			playerStatusHolder.isResettingHQFPSHealth = true;
			component.Health.Set(100f);
			playerStatusHolder.isResettingHQFPSHealth = false;
			Debug.Log("[Revive] HQFPS Health reset to 100");
		}
		playerStatusPanel.ShowPanel();
	}

	public void Spawn()
	{
		NetworkisDeath = false;
		if (base.hasAuthority)
		{
			BeginSpawnProtection();
		}
		InteractionPanel.Instance.HideAllInteractions();
		Transform transform = trainController.spawnPoints[UnityEngine.Random.Range(0, trainController.spawnPoints.Count - 1)];
		base.transform.position = transform.position;
		base.transform.rotation = transform.rotation;
		if (base.isOwned)
		{
			CmdEnableTpsBase();
		}
		tpsCharacterPartsHolder.DisableTPSParts();
		GetComponent<Interactor>().enabled = true;
		UnLockPlayer();
		animationController.Revive();
		if (animationController.weaponVisuals != null)
		{
			animationController.weaponVisuals.ResetOnRevive();
		}
		if (base.hasAuthority)
		{
			CmdSetDeathState(deathState: false);
			cameraPositionController.ResetCameraPos();
			CmdActivateReveiverObject(active: false);
		}
		if (cameraRigController != null)
		{
			cameraRigController.SetActive(active: true);
			cameraRigController.ClearWeapon();
		}
		playerStatusPanel.ShowPanel();
		playerStatusHolder.playerFoodFuel = 50f;
		playerStatusHolder.playerHpFuel = 50f;
		playerStatusHolder.playerWaterFuel = 50f;
		HQFPSTemplate.Player component = GetComponent<HQFPSTemplate.Player>();
		if (component != null)
		{
			playerStatusHolder.isResettingHQFPSHealth = true;
			component.Health.Set(100f);
			playerStatusHolder.isResettingHQFPSHealth = false;
		}
	}

	public void ActivateReveiverObject(bool active)
	{
		playerReveiver.SetActive(active);
	}

	public void LockPlayer()
	{
		TrainGameManager.isInputActive = false;
		TrainGameManager.isMouseLocked = true;
		characterController.enabled = false;
		if (playerMovement != null)
		{
			playerMovement.enabled = false;
		}
	}

	public void UnLockPlayer()
	{
		characterController.enabled = true;
		TrainGameManager.isInputActive = true;
		TrainGameManager.isMouseLocked = false;
		if (playerMovement != null)
		{
			playerMovement.enabled = true;
		}
	}

	public void Sleep(float cameraPosY, BedProp bed, uint bedNetId)
	{
		sleepingBed = bed;
		LockPlayer();
		checkTrain = false;
		GetComponent<Interactor>().enabled = false;
		tpsCharacterPartsHolder.EnableTPSParts();
		cameraPositionController.Sleep();
		animationController.Sleep(sleep: true);
		sleepTime = Time.time;
		StartCoroutine(DuubyUtilities.WaitEndOfFixedUpdate(delegate
		{
			if (base.hasAuthority)
			{
				CmdSleep(base.transform.position, base.transform.rotation, bedNetId);
			}
		}));
	}

	public void WakeUp()
	{
		if (!(sleepingBed == null))
		{
			sleepingBed.WakeUp();
			sleepingBed = null;
			cameraPositionController.ResetCameraPos();
			tpsCharacterPartsHolder.DisableTPSParts();
			if (base.hasAuthority)
			{
				CmdWakeUp();
			}
			InteractionPanel.Instance.HidePanels();
			checkTrain = true;
			UnLockPlayer();
			animationController.Sleep(sleep: false);
			StartCoroutine(EnableInteractorDelayed());
		}
	}

	private IEnumerator EnableInteractorDelayed()
	{
		yield return new WaitForSeconds(0.1f);
		GetComponent<Interactor>().enabled = true;
	}

	[Command]
	private void CmdSleep(Vector3 position, Quaternion rotation, uint bedNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		writer.WriteUInt(bedNetId);
		SendCommandInternal("System.Void TSPlayerController::CmdSleep(UnityEngine.Vector3,UnityEngine.Quaternion,System.UInt32)", -569041910, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSleep(Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendRPCInternal("System.Void TSPlayerController::RpcSleep(UnityEngine.Vector3,UnityEngine.Quaternion)", -1487196405, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdWakeUp()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TSPlayerController::CmdWakeUp()", -1622219398, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcWakeUp()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TSPlayerController::RpcWakeUp()", -1588772059, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void Death()
	{
		Debug.Log("Death");
		PlayerInventory component = GetComponent<PlayerInventory>();
		List<InventorySlotsDataNetwork> list = new List<InventorySlotsDataNetwork>();
		if (component != null)
		{
			float num = 0.7f;
			int num2 = 0;
			foreach (InventorySlotsData inventorySlotsDatum in component.inventorySlotsData)
			{
				if (inventorySlotsDatum.item != null && inventorySlotsDatum.itemCountInSlot > 0)
				{
					num2 += inventorySlotsDatum.itemCountInSlot;
				}
			}
			int num3 = Mathf.RoundToInt((float)num2 * num);
			int num4 = 0;
			List<InventorySlotsData> list2 = new List<InventorySlotsData>();
			foreach (InventorySlotsData inventorySlotsDatum2 in component.inventorySlotsData)
			{
				if (inventorySlotsDatum2.item != null && inventorySlotsDatum2.itemCountInSlot > 0)
				{
					list2.Add(inventorySlotsDatum2);
				}
			}
			for (int num5 = list2.Count - 1; num5 > 0; num5--)
			{
				int index = UnityEngine.Random.Range(0, num5 + 1);
				InventorySlotsData value = list2[num5];
				list2[num5] = list2[index];
				list2[index] = value;
			}
			foreach (InventorySlotsData item in list2)
			{
				if (num4 >= num3)
				{
					break;
				}
				int num6 = Mathf.Min(item.itemCountInSlot, num3 - num4);
				int a = UnityEngine.Random.Range(1, num6 + 1);
				a = Mathf.Min(a, item.itemCountInSlot);
				if (a > 0)
				{
					list.Add(new InventorySlotsDataNetwork
					{
						itemName = item.item.itemName,
						slotID = item.slotID,
						itemCountInSlot = a,
						maxCapacity = item.maxCapacity,
						currentMagazineCount = item.currentMagazineCount,
						currentDurability = item.currentDurability
					});
					num4 += a;
				}
			}
			Debug.Log($"[Death] Sending {list.Count} items to server, totalDropped: {num4}");
		}
		CmdDropInventoryOnDeath(list);
		CmdDisableTpsBase();
		if (base.isOwned)
		{
			CmdActivateReveiverObject(active: false);
		}
		animationController.Faint();
	}

	[Command]
	private void CmdDisableTpsBase()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TSPlayerController::CmdDisableTpsBase()", -1867590469, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcDisableTpsBase()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TSPlayerController::RpcDisableTpsBase()", -1699326106, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdEnableTpsBase()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TSPlayerController::CmdEnableTpsBase()", 1077628812, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcEnableTpsBase()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TSPlayerController::RpcEnableTpsBase()", -718058623, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private Vector3 FindValidTerrainSpawnPosition()
	{
		float num = 0.5f;
		float num2 = 20f;
		Vector3 position = base.transform.position;
		Vector3 right;
		if (isOnTrain && connectedObject != null)
		{
			right = connectedObject.right;
			Debug.Log($"[Death Chest] Player is on train, using train's right direction: {right}");
		}
		else
		{
			right = Vector3.right;
			Debug.Log("[Death Chest] Player is NOT on train, using world right direction");
		}
		if (CheckRaycastForValidTerrain(position, out var terrainPoint))
		{
			Debug.Log($"[Death Chest] Found valid terrain directly below at {terrainPoint}");
			return terrainPoint + Vector3.up * 1f;
		}
		Debug.Log("[Death Chest] No valid terrain directly below, searching left and right...");
		float num3 = -1f;
		float num4 = -1f;
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		for (float num5 = num; num5 <= num2; num5 += num)
		{
			Vector3 startPos = position + right * num5;
			if (CheckRaycastForValidTerrain(startPos, out terrainPoint))
			{
				num3 = num5;
				vector = terrainPoint;
				Debug.Log($"[Death Chest] Found valid terrain on RIGHT at distance {num5}m, position {terrainPoint}");
				break;
			}
			Debug.Log($"[Death Chest] RIGHT {num5}m is blocked by train or no terrain, continuing search...");
		}
		for (float num6 = num; num6 <= num2; num6 += num)
		{
			Vector3 startPos2 = position - right * num6;
			if (CheckRaycastForValidTerrain(startPos2, out terrainPoint))
			{
				num4 = num6;
				vector2 = terrainPoint;
				Debug.Log($"[Death Chest] Found valid terrain on LEFT at distance {num6}m, position {terrainPoint}");
				break;
			}
			Debug.Log($"[Death Chest] LEFT {num6}m is blocked by train or no terrain, continuing search...");
		}
		if (num3 > 0f && num4 > 0f)
		{
			if (num3 < num4)
			{
				Debug.Log($"[Death Chest] Using RIGHT position (closer: {num3}m vs {num4}m)");
				return vector + Vector3.up * 1f;
			}
			Debug.Log($"[Death Chest] Using LEFT position (closer: {num4}m vs {num3}m)");
			return vector2 + Vector3.up * 1f;
		}
		if (num3 > 0f)
		{
			Debug.Log("[Death Chest] Only found RIGHT terrain");
			return vector + Vector3.up * 1f;
		}
		if (num4 > 0f)
		{
			Debug.Log("[Death Chest] Only found LEFT terrain");
			return vector2 + Vector3.up * 1f;
		}
		Debug.LogWarning("[Death Chest] No valid terrain found, using default position!");
		return base.transform.position + Vector3.up * 1f;
	}

	private bool CheckRaycastForValidTerrain(Vector3 startPos, out Vector3 terrainPoint)
	{
		terrainPoint = Vector3.zero;
		float maxDistance = 100f;
		RaycastHit[] array = Physics.RaycastAll(startPos, Vector3.down, maxDistance);
		if (array.Length == 0)
		{
			Debug.Log($"[Death Chest] No hits at position {startPos}");
			return false;
		}
		Array.Sort(array, (RaycastHit a, RaycastHit b) => a.distance.CompareTo(b.distance));
		RaycastHit[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			RaycastHit raycastHit = array2[num];
			if (raycastHit.transform.root.GetComponent<TrainController>() != null)
			{
				Debug.Log($"[Death Chest] Raycast hit train first at {startPos}, blocked");
				return false;
			}
			if (((1 << raycastHit.collider.gameObject.layer) & (int)terrainLayer) != 0)
			{
				terrainPoint = raycastHit.point;
				Debug.Log($"[Death Chest] Raycast hit valid terrain at {raycastHit.point}");
				return true;
			}
		}
		Debug.Log($"[Death Chest] No valid terrain found at {startPos}");
		return false;
	}

	[Command(requiresAuthority = false)]
	private void CmdDropInventoryOnDeath(List<InventorySlotsDataNetwork> itemsFromClient)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E(writer, itemsFromClient);
		SendCommandInternal("System.Void TSPlayerController::CmdDropInventoryOnDeath(System.Collections.Generic.List`1<InventorySlotsDataNetwork>)", 1025522194, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcClearInventory()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TSPlayerController::RpcClearInventory()", -1425889195, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ActivateBuildSystem(bool active = false)
	{
		if (buildingHammerController != null)
		{
			buildingHammerController.ChangeBuildState(active);
		}
	}

	public bool IsBuildSystemActive()
	{
		BuildingHammerController componentInChildren = GetComponentInChildren<BuildingHammerController>();
		if (componentInChildren != null)
		{
			return componentInChildren.itCanBuild;
		}
		return false;
	}

	private void CheckFallThroughTerrain()
	{
		if (characterController != null && characterController.isGrounded && Time.time - lastSafePositionUpdateTime > safePositionUpdateInterval)
		{
			lastSafePosition = base.transform.position;
			lastSafePositionUpdateTime = Time.time;
		}
		if (base.transform.position.y < terrainMinPos)
		{
			Debug.LogWarning($"[TSPlayerController] Oyuncu terrain altına düştü! Y={base.transform.position.y:F1} < {terrainMinPos} | Teleport: {lastSafePosition}");
			if (playerStatusHolder != null)
			{
				playerStatusHolder.ignoreFallDamage = true;
			}
			if (characterController != null)
			{
				characterController.enabled = false;
			}
			base.transform.position = lastSafePosition;
			if (characterController != null)
			{
				characterController.enabled = true;
			}
			StartCoroutine(ReenableFallDamageNextFrame());
		}
	}

	private IEnumerator ReenableFallDamageNextFrame()
	{
		yield return null;
		if (playerStatusHolder != null)
		{
			playerStatusHolder.ignoreFallDamage = false;
		}
	}

	public bool IsOnTrain()
	{
		if (characterController == null)
		{
			Debug.LogWarning("[IsOnTrain] CharacterController bulunamadı!");
			return false;
		}
		Vector3 position = base.transform.position;
		float num = characterController.radius * 1.02f;
		float maxDistance = 20f;
		Vector3[] array = new Vector3[5]
		{
			position,
			position + base.transform.forward * num,
			position - base.transform.forward * num,
			position + base.transform.right * num,
			position - base.transform.right * num
		};
		for (int i = 0; i < array.Length; i++)
		{
			if (!Physics.Raycast(array[i], Vector3.down, out var hitInfo, maxDistance, trainLayer))
			{
				continue;
			}
			Transform transform = null;
			TrainController trainController = null;
			WagonController wagonController = hitInfo.transform.GetComponentInParent<WagonController>();
			if (wagonController == null)
			{
				wagonController = hitInfo.transform.GetComponent<WagonController>();
			}
			if (wagonController != null)
			{
				transform = wagonController.transform;
				trainController = wagonController.GetComponentInParent<TrainController>();
			}
			else
			{
				trainController = hitInfo.transform.GetComponentInParent<TrainController>();
				if (trainController != null)
				{
					transform = trainController.transform;
				}
			}
			if (!(transform == null))
			{
				Transform transform2 = connectedObject;
				connectedObject = transform;
				if (!isOnTrain)
				{
					int wagonId = ((wagonController != null) ? wagonController.wagonID : (-1));
					OnTrainEntered(trainController, wagonId);
					characterController.slopeLimit = 65f;
				}
				else if (transform2 != transform)
				{
					int wagonId2 = ((wagonController != null) ? wagonController.wagonID : (-1));
					CmdSetOnTrainTrue(trainController.GetComponent<NetworkIdentity>().netId, wagonId2, base.transform.position, base.transform.rotation);
				}
				if (base.transform.parent != connectedObject)
				{
					base.transform.parent = connectedObject;
				}
				isOnTrain = true;
				return true;
			}
		}
		if (isOnTrain)
		{
			OnTrainExited();
			characterController.slopeLimit = defaultSlopeLimit;
		}
		connectedObject = null;
		if (base.transform.parent != parentObject)
		{
			base.transform.parent = parentObject;
		}
		isOnTrain = false;
		return false;
	}

	private void OnTrainEntered(TrainController train, int wagonId)
	{
		uint trainNetId = train.GetComponent<NetworkIdentity>().netId;
		CmdSetOnTrainTrue(trainNetId, wagonId, base.transform.position, base.transform.rotation);
	}

	private void OnTrainExited()
	{
		CmdSetOnTrainFalse();
		CmdUpdateWorldPosition(base.transform.position, base.transform.rotation, isSettle: true);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(Vector3 localPos, Quaternion localRot, bool isSettle)
	{
		NetworktrainLocalPosition = localPos;
		NetworktrainLocalRotation = localRot;
		RpcUpdateTrainLocalPosition(localPos, localRot, isSettle);
	}

	protected static void InvokeUserCode_CmdUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateTrainLocalPosition called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(Vector3 localPos, Quaternion localRot, bool isSettle)
	{
		if (isSettle)
		{
			remoteLocalVelocity = Vector3.zero;
			localPositionError = localPos - base.transform.localPosition;
			lastReceivedLocalPos = localPos;
			lastLocalReceiveTime = Time.unscaledTime;
			NetworktrainLocalPosition = localPos;
			NetworktrainLocalRotation = localRot;
			return;
		}
		float num = Time.unscaledTime - lastLocalReceiveTime;
		if (lastLocalReceiveTime > 0f && num > 0.001f && num < 0.5f)
		{
			remoteLocalVelocity = (localPos - lastReceivedLocalPos) / num;
		}
		lastReceivedLocalPos = localPos;
		lastLocalReceiveTime = Time.unscaledTime;
		localPositionError = localPos - base.transform.localPosition;
		NetworktrainLocalPosition = localPos;
		NetworktrainLocalRotation = localRot;
	}

	protected static void InvokeUserCode_RpcUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateTrainLocalPosition called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcUpdateTrainLocalPosition__Vector3__Quaternion__Boolean(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdUpdateWorldPosition__Vector3__Quaternion__Boolean(Vector3 worldPos, Quaternion worldRot, bool isSettle)
	{
		NetworknetworkPosition = worldPos;
		NetworknetworkRotation = worldRot;
		RpcUpdateWorldPosition(worldPos, worldRot, isSettle);
	}

	protected static void InvokeUserCode_CmdUpdateWorldPosition__Vector3__Quaternion__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateWorldPosition called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdUpdateWorldPosition__Vector3__Quaternion__Boolean(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcUpdateWorldPosition__Vector3__Quaternion__Boolean(Vector3 worldPos, Quaternion worldRot, bool isSettle)
	{
		if (isSettle)
		{
			remoteWorldVelocity = Vector3.zero;
			worldPositionError = worldPos - base.transform.position;
			lastReceivedWorldPos = worldPos;
			lastWorldReceiveTime = Time.unscaledTime;
			NetworknetworkPosition = worldPos;
			NetworknetworkRotation = worldRot;
			return;
		}
		float num = Time.unscaledTime - lastWorldReceiveTime;
		if (lastWorldReceiveTime > 0f && num > 0.001f && num < 0.5f)
		{
			remoteWorldVelocity = (worldPos - lastReceivedWorldPos) / num;
		}
		lastReceivedWorldPos = worldPos;
		lastWorldReceiveTime = Time.unscaledTime;
		worldPositionError = worldPos - base.transform.position;
		NetworknetworkPosition = worldPos;
		NetworknetworkRotation = worldRot;
	}

	protected static void InvokeUserCode_RpcUpdateWorldPosition__Vector3__Quaternion__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateWorldPosition called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcUpdateWorldPosition__Vector3__Quaternion__Boolean(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetOnTrainTrue__UInt32__Int32__Vector3__Quaternion(uint trainNetId, int wagonId, Vector3 worldPos, Quaternion worldRot)
	{
		NetworknetworkIsOnTrain = true;
		NetworkconnectedTrainId = trainNetId;
		NetworkconnectedWagonId = wagonId;
		RpcSetTrainPositionAndState(trainNetId, wagonId, worldPos, worldRot);
		Debug.Log($"[Server] Player train'e bindi. WagonID: {wagonId}, WorldPos: {worldPos}");
	}

	protected static void InvokeUserCode_CmdSetOnTrainTrue__UInt32__Int32__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetOnTrainTrue called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdSetOnTrainTrue__UInt32__Int32__Vector3__Quaternion(reader.ReadUInt(), reader.ReadInt(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcSetTrainPositionAndState__UInt32__Int32__Vector3__Quaternion(uint trainNetId, int wagonId, Vector3 worldPos, Quaternion worldRot)
	{
		TrainController trainById = GetTrainById(trainNetId);
		if (trainById == null)
		{
			return;
		}
		Transform parent = trainById.transform;
		if (wagonId >= 0)
		{
			WagonController wagonByID = trainById.GetWagonByID(wagonId);
			if (wagonByID != null)
			{
				parent = wagonByID.transform;
			}
		}
		base.transform.parent = parent;
		connectedObject = parent;
		base.transform.position = worldPos;
		base.transform.rotation = worldRot;
		isOnTrain = true;
		NetworktrainLocalPosition = base.transform.localPosition;
		NetworktrainLocalRotation = base.transform.localRotation;
		remoteLocalVelocity = Vector3.zero;
		localPositionError = Vector3.zero;
		lastReceivedLocalPos = base.transform.localPosition;
		lastLocalReceiveTime = Time.unscaledTime;
		Debug.Log($"[Client RPC] Parent ve pozisyon ayarlandı. WorldPos: {worldPos}, ResultLocalPos: {base.transform.localPosition}");
	}

	protected static void InvokeUserCode_RpcSetTrainPositionAndState__UInt32__Int32__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetTrainPositionAndState called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcSetTrainPositionAndState__UInt32__Int32__Vector3__Quaternion(reader.ReadUInt(), reader.ReadInt(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdSetOnTrainFalse()
	{
		NetworknetworkIsOnTrain = false;
		NetworkconnectedTrainId = 0u;
		NetworkconnectedWagonId = -1;
	}

	protected static void InvokeUserCode_CmdSetOnTrainFalse(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetOnTrainFalse called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdSetOnTrainFalse();
		}
	}

	protected void UserCode_CmdActivateReveiverObject__Boolean(bool active)
	{
		ActivateReveiverObject(active);
		RpcActivateReveiverObject(active);
	}

	protected static void InvokeUserCode_CmdActivateReveiverObject__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdActivateReveiverObject called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdActivateReveiverObject__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcActivateReveiverObject__Boolean(bool active)
	{
		ActivateReveiverObject(active);
	}

	protected static void InvokeUserCode_RpcActivateReveiverObject__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcActivateReveiverObject called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcActivateReveiverObject__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetDeathState__Boolean(bool deathState)
	{
		NetworkisDeath = deathState;
	}

	protected static void InvokeUserCode_CmdSetDeathState__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetDeathState called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdSetDeathState__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetSpawnProtected__Boolean(bool value)
	{
		NetworkspawnProtected = value;
	}

	protected static void InvokeUserCode_CmdSetSpawnProtected__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetSpawnProtected called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdSetSpawnProtected__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSleep__Vector3__Quaternion__UInt32(Vector3 position, Quaternion rotation, uint bedNetId)
	{
		NetworkisSleeping = true;
		serverBedNetId = bedNetId;
		if (NetworkServer.spawned.TryGetValue(bedNetId, out var value))
		{
			BedProp component = value.GetComponent<BedProp>();
			if (component != null)
			{
				component.ServerSetFull(full: true);
			}
		}
		RpcSleep(position, rotation);
		if (TrainGameManager.Instance != null)
		{
			TrainGameManager.Instance.CheckAllPlayersSleeping();
		}
	}

	protected static void InvokeUserCode_CmdSleep__Vector3__Quaternion__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSleep called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdSleep__Vector3__Quaternion__UInt32(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadUInt());
		}
	}

	protected void UserCode_RpcSleep__Vector3__Quaternion(Vector3 position, Quaternion rotation)
	{
		if (!base.hasAuthority)
		{
			base.transform.SetPositionAndRotation(position, rotation);
			remoteLocalVelocity = Vector3.zero;
			remoteWorldVelocity = Vector3.zero;
			localPositionError = Vector3.zero;
			worldPositionError = Vector3.zero;
			lastReceivedLocalPos = base.transform.localPosition;
			lastReceivedWorldPos = position;
			lastLocalReceiveTime = Time.unscaledTime;
			lastWorldReceiveTime = Time.unscaledTime;
			animationController.Sleep(sleep: true);
		}
	}

	protected static void InvokeUserCode_RpcSleep__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSleep called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcSleep__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdWakeUp()
	{
		NetworkisSleeping = false;
		if (serverBedNetId != 0 && NetworkServer.spawned.TryGetValue(serverBedNetId, out var value))
		{
			BedProp component = value.GetComponent<BedProp>();
			if (component != null)
			{
				component.ServerSetFull(full: false);
			}
		}
		serverBedNetId = 0u;
		RpcWakeUp();
	}

	protected static void InvokeUserCode_CmdWakeUp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdWakeUp called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdWakeUp();
		}
	}

	protected void UserCode_RpcWakeUp()
	{
		if (!base.hasAuthority)
		{
			animationController.Sleep(sleep: false);
		}
	}

	protected static void InvokeUserCode_RpcWakeUp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcWakeUp called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcWakeUp();
		}
	}

	protected void UserCode_CmdDisableTpsBase()
	{
		RpcDisableTpsBase();
	}

	protected static void InvokeUserCode_CmdDisableTpsBase(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDisableTpsBase called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdDisableTpsBase();
		}
	}

	protected void UserCode_RpcDisableTpsBase()
	{
		tpsCharacterPartsHolder.DisableTpsBase();
	}

	protected static void InvokeUserCode_RpcDisableTpsBase(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcDisableTpsBase called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcDisableTpsBase();
		}
	}

	protected void UserCode_CmdEnableTpsBase()
	{
		RpcEnableTpsBase();
	}

	protected static void InvokeUserCode_CmdEnableTpsBase(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdEnableTpsBase called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdEnableTpsBase();
		}
	}

	protected void UserCode_RpcEnableTpsBase()
	{
		tpsCharacterPartsHolder.EnableTpsBase();
	}

	protected static void InvokeUserCode_RpcEnableTpsBase(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEnableTpsBase called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcEnableTpsBase();
		}
	}

	protected void UserCode_CmdDropInventoryOnDeath__List_00601(List<InventorySlotsDataNetwork> itemsFromClient)
	{
		Debug.Log($"[CmdDropInventoryOnDeath] Called on server with {itemsFromClient.Count} items from client");
		if (deathInventoryChest == null)
		{
			Debug.Log("[CmdDropInventoryOnDeath] deathInventoryChest is NULL, cannot spawn chest");
			return;
		}
		if (itemsFromClient.Count == 0)
		{
			Debug.Log("[CmdDropInventoryOnDeath] No items to drop, skipping chest spawn");
			return;
		}
		Vector3 vector = FindValidTerrainSpawnPosition();
		Debug.Log($"[CmdDropInventoryOnDeath] Spawning chest at: {vector}");
		GameObject gameObject = UnityEngine.Object.Instantiate(deathInventoryChest, vector, Quaternion.identity);
		ChestController component = gameObject.GetComponent<ChestController>();
		component.inventorySlotsData.Clear();
		for (int i = 0; i < component.slotCount; i++)
		{
			if (i < itemsFromClient.Count)
			{
				InventorySlotsDataNetwork inventorySlotsDataNetwork = itemsFromClient[i];
				component.inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = inventorySlotsDataNetwork.itemName,
					slotID = i + 1,
					itemCountInSlot = inventorySlotsDataNetwork.itemCountInSlot,
					maxCapacity = inventorySlotsDataNetwork.maxCapacity,
					currentMagazineCount = inventorySlotsDataNetwork.currentMagazineCount,
					currentDurability = inventorySlotsDataNetwork.currentDurability
				});
			}
			else
			{
				component.inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = "",
					slotID = i + 1,
					itemCountInSlot = 0,
					maxCapacity = component.inventorySlotMaxCapacity
				});
			}
		}
		NetworkServer.Spawn(gameObject);
		Debug.Log($"[CmdDropInventoryOnDeath] Chest spawned successfully with {itemsFromClient.Count} items! NetId: {gameObject.GetComponent<NetworkIdentity>()?.netId}");
		NetworkIdentity component2 = gameObject.GetComponent<NetworkIdentity>();
		if (component2 != null)
		{
			component2.RemoveClientAuthority();
		}
		RpcClearInventory();
	}

	protected static void InvokeUserCode_CmdDropInventoryOnDeath__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDropInventoryOnDeath called on client.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_CmdDropInventoryOnDeath__List_00601(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E(reader));
		}
	}

	protected void UserCode_RpcClearInventory()
	{
		if (!base.isOwned)
		{
			return;
		}
		PlayerInventory component = GetComponent<PlayerInventory>();
		if (!(component != null))
		{
			return;
		}
		foreach (InventorySlotsData inventorySlotsDatum in component.inventorySlotsData)
		{
			inventorySlotsDatum.Clear();
		}
		foreach (InventorySlot mainInventorySlot in component.mainInventorySlots)
		{
			mainInventorySlot.Clear();
			if (mainInventorySlot.InventoryItem != null)
			{
				mainInventorySlot.InventoryItem.ClearInventoryData();
			}
		}
		component.UpdateInventoryDataFromSlots();
	}

	protected static void InvokeUserCode_RpcClearInventory(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcClearInventory called on server.");
		}
		else
		{
			((TSPlayerController)obj).UserCode_RpcClearInventory();
		}
	}

	static TSPlayerController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdUpdateTrainLocalPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", InvokeUserCode_CmdUpdateTrainLocalPosition__Vector3__Quaternion__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdUpdateWorldPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", InvokeUserCode_CmdUpdateWorldPosition__Vector3__Quaternion__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdSetOnTrainTrue(System.UInt32,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdSetOnTrainTrue__UInt32__Int32__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdSetOnTrainFalse()", InvokeUserCode_CmdSetOnTrainFalse, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdActivateReveiverObject(System.Boolean)", InvokeUserCode_CmdActivateReveiverObject__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdSetDeathState(System.Boolean)", InvokeUserCode_CmdSetDeathState__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdSetSpawnProtected(System.Boolean)", InvokeUserCode_CmdSetSpawnProtected__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdSleep(UnityEngine.Vector3,UnityEngine.Quaternion,System.UInt32)", InvokeUserCode_CmdSleep__Vector3__Quaternion__UInt32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdWakeUp()", InvokeUserCode_CmdWakeUp, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdDisableTpsBase()", InvokeUserCode_CmdDisableTpsBase, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdEnableTpsBase()", InvokeUserCode_CmdEnableTpsBase, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TSPlayerController), "System.Void TSPlayerController::CmdDropInventoryOnDeath(System.Collections.Generic.List`1<InventorySlotsDataNetwork>)", InvokeUserCode_CmdDropInventoryOnDeath__List_00601, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcUpdateTrainLocalPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", InvokeUserCode_RpcUpdateTrainLocalPosition__Vector3__Quaternion__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcUpdateWorldPosition(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", InvokeUserCode_RpcUpdateWorldPosition__Vector3__Quaternion__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcSetTrainPositionAndState(System.UInt32,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcSetTrainPositionAndState__UInt32__Int32__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcActivateReveiverObject(System.Boolean)", InvokeUserCode_RpcActivateReveiverObject__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcSleep(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcSleep__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcWakeUp()", InvokeUserCode_RpcWakeUp);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcDisableTpsBase()", InvokeUserCode_RpcDisableTpsBase);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcEnableTpsBase()", InvokeUserCode_RpcEnableTpsBase);
		RemoteProcedureCalls.RegisterRpc(typeof(TSPlayerController), "System.Void TSPlayerController::RpcClearInventory()", InvokeUserCode_RpcClearInventory);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isSleeping);
			writer.WriteBool(isDeath);
			writer.WriteBool(spawnProtected);
			writer.WriteVector3(networkPosition);
			writer.WriteQuaternion(networkRotation);
			writer.WriteVector3(trainLocalPosition);
			writer.WriteQuaternion(trainLocalRotation);
			writer.WriteBool(networkIsOnTrain);
			writer.WriteUInt(connectedTrainId);
			writer.WriteInt(connectedWagonId);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isSleeping);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isDeath);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(spawnProtected);
		}
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVector3(networkPosition);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteQuaternion(networkRotation);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteVector3(trainLocalPosition);
		}
		if ((base.syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteQuaternion(trainLocalRotation);
		}
		if ((base.syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteBool(networkIsOnTrain);
		}
		if ((base.syncVarDirtyBits & 0x100L) != 0L)
		{
			writer.WriteUInt(connectedTrainId);
		}
		if ((base.syncVarDirtyBits & 0x200L) != 0L)
		{
			writer.WriteInt(connectedWagonId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isSleeping, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isDeath, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref spawnProtected, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref networkPosition, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref networkRotation, null, reader.ReadQuaternion());
			GeneratedSyncVarDeserialize(ref trainLocalPosition, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref trainLocalRotation, null, reader.ReadQuaternion());
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref connectedTrainId, OnConnectedTrainChanged, reader.ReadUInt());
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isSleeping, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isDeath, null, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref spawnProtected, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkPosition, null, reader.ReadVector3());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkRotation, null, reader.ReadQuaternion());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref trainLocalPosition, null, reader.ReadVector3());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref trainLocalRotation, null, reader.ReadQuaternion());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedTrainId, OnConnectedTrainChanged, reader.ReadUInt());
		}
		if ((num & 0x200L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
		}
	}
}
