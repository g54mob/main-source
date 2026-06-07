using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SCC_Network : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CServerForkOpUnlockRoutine_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public SCC_Network _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerForkOpUnlockRoutine_003Ed__89(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SCC_Network sCC_Network = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(duration);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				sCC_Network.NetworkserverForkOpLock = false;
				sCC_Network.serverForkOpRoutine = null;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CServerTravelUnlockRoutine_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public SCC_Network _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CServerTravelUnlockRoutine_003Ed__93(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SCC_Network sCC_Network = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(duration);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				sCC_Network.NetworkserverTravelLock = false;
				sCC_Network.serverTravelRoutine = null;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Synced Vehicle State")]
	[SyncVar]
	public float syncSteerInput;

	[SyncVar]
	public float syncThrottleInput;

	[SyncVar]
	public float syncBrakeInput;

	[SyncVar]
	public float syncHandbrakeInput;

	[SyncVar]
	public float syncEngineRPM;

	[SyncVar]
	public float syncSpeed;

	[SyncVar]
	public new int syncDirection;

	[SyncVar]
	public bool isInDigsite;

	[SyncVar]
	public byte syncHornState;

	[Header("Events (Local Owner)")]
	public UnityEvent OnEnter;

	public UnityEvent OnExit;

	[Header("Events (All Clients)")]
	public UnityEvent OnOwnerTakenAll;

	public UnityEvent OnOwnerReleasedAll;

	[Header("Passenger Events")]
	public UnityEvent OnLocalPassengerEnter;

	public UnityEvent OnLocalPassengerExit;

	public UnityEvent OnPassengerCountChangedAll;

	[Header("Vehicle Info")]
	public T_BuildingItemSO vehicleItem;

	[Header("Occupants UI")]
	[Tooltip("True ise UIManager.vehicleOccupantsUI.RefreshUI() doğrudan çağrılır")]
	public bool refreshOccupantsUIDirectly;

	[Header("Passenger Settings")]
	public int maxPassengers = 4;

	public List<GameObject> passengersList = new List<GameObject>();

	[Header("Exit Positions")]
	[Tooltip("Her koltuk için iniş noktası. Index 0 = driver, 1 = yolcu1, vb.")]
	public List<Transform> exitPositions = new List<Transform>();

	[Header("Voice Chat (Per Seat)")]
	[Tooltip("Her koltuk için ses kaynağı. Index 0 = driver, 1..3 = yolcular")]
	public AudioSource[] seatVoiceAudioSources;

	[Tooltip("Her koltuk için konuşma ikonu. Index 0 = driver, 1..3 = yolcular")]
	public GameObject[] seatVoiceIconObjects;

	[Header("Horn")]
	public InputActionReference HornAction;

	[Header("Forklift")]
	public T_Forklift forklift;

	public InputActionReference LiftAction;

	[Header("References")]
	public SCC_Drivetrain drivetrain;

	public SCC_Audio audioComponent;

	public SCC_Particles particlesComponent;

	public SCC_InputProcessor InputProcessor;

	public InputActionReference ExitAction;

	public Rigidbody rb;

	public NetworkTransformReliable netTransform;

	[SyncVar]
	private int occupantCount;

	private readonly uint[] seatServer = new uint[4];

	private readonly uint[] seatClient = new uint[4];

	private readonly uint[] prevSeatClient = new uint[4];

	public static readonly List<SCC_Network> AllVehicles;

	private bool localForkDetachLock;

	[Header("Travel Runtime")]
	[SyncVar]
	private bool serverTravelActive;

	private bool localTravelActive;

	[Header("Travel Transition Lock")]
	[SyncVar]
	private bool serverTravelLock;

	private bool localTravelLock;

	private Coroutine localTravelRoutine;

	private Coroutine serverTravelRoutine;

	[Header("Travel Sim Runtime (Local Owner)")]
	private bool localTravelSimEnabled;

	private float localTravelSimSpeedKmh;

	private float localTravelSimRPM;

	private Vector3 localTravelSimVelocity;

	[Header("Post-Transition Auto Stop")]
	private bool hasInputAfterTransition = true;

	private Coroutine autoStopRoutine;

	[Header("Forklift Operation Lock (Server + Local)")]
	[SyncVar]
	private bool serverForkOpLock;

	private Coroutine localForkOpRoutine;

	private Coroutine serverForkOpRoutine;

	private Coroutine hornHoldRoutine;

	private readonly float longHornDelay = 1f;

	public bool IsTravelActive
	{
		get
		{
			if (!localTravelActive)
			{
				return serverTravelActive;
			}
			return true;
		}
	}

	public bool IsTravelLocked
	{
		get
		{
			if (!localTravelLock)
			{
				return serverTravelLock;
			}
			return true;
		}
	}

	public bool IsControlLocked
	{
		get
		{
			if (!base.isOwned)
			{
				if (!localForkDetachLock && !serverForkOpLock && !localTravelLock)
				{
					return serverTravelLock;
				}
				return true;
			}
			if (!localForkDetachLock)
			{
				return localTravelLock;
			}
			return true;
		}
	}

	public bool HasDriverAll
	{
		get
		{
			if (base.isServer)
			{
				return seatServer[0] != 0;
			}
			return seatClient[0] != 0;
		}
	}

	private bool DriverPresent
	{
		get
		{
			if (!base.isServer)
			{
				return seatClient[0] != 0;
			}
			return base.netIdentity.connectionToClient != null;
		}
	}

	public float NetworksyncSteerInput
	{
		get
		{
			return syncSteerInput;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncSteerInput, 1uL, null);
		}
	}

	public float NetworksyncThrottleInput
	{
		get
		{
			return syncThrottleInput;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncThrottleInput, 2uL, null);
		}
	}

	public float NetworksyncBrakeInput
	{
		get
		{
			return syncBrakeInput;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncBrakeInput, 4uL, null);
		}
	}

	public float NetworksyncHandbrakeInput
	{
		get
		{
			return syncHandbrakeInput;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncHandbrakeInput, 8uL, null);
		}
	}

	public float NetworksyncEngineRPM
	{
		get
		{
			return syncEngineRPM;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncEngineRPM, 16uL, null);
		}
	}

	public float NetworksyncSpeed
	{
		get
		{
			return syncSpeed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncSpeed, 32uL, null);
		}
	}

	public int NetworksyncDirection
	{
		get
		{
			return syncDirection;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncDirection, 64uL, null);
		}
	}

	public bool NetworkisInDigsite
	{
		get
		{
			return isInDigsite;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isInDigsite, 128uL, null);
		}
	}

	public byte NetworksyncHornState
	{
		get
		{
			return syncHornState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncHornState, 256uL, null);
		}
	}

	public int NetworkoccupantCount
	{
		get
		{
			return occupantCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref occupantCount, 512uL, null);
		}
	}

	public bool NetworkserverTravelActive
	{
		get
		{
			return serverTravelActive;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref serverTravelActive, 1024uL, null);
		}
	}

	public bool NetworkserverTravelLock
	{
		get
		{
			return serverTravelLock;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref serverTravelLock, 2048uL, null);
		}
	}

	public bool NetworkserverForkOpLock
	{
		get
		{
			return serverForkOpLock;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref serverForkOpLock, 4096uL, null);
		}
	}

	private void Awake()
	{
		if (!drivetrain)
		{
			drivetrain = GetComponent<SCC_Drivetrain>();
		}
		if (!audioComponent)
		{
			audioComponent = GetComponent<SCC_Audio>();
		}
		if (!particlesComponent)
		{
			particlesComponent = GetComponent<SCC_Particles>();
		}
		if (!InputProcessor)
		{
			InputProcessor = GetComponent<SCC_InputProcessor>();
		}
		if (!rb)
		{
			rb = GetComponent<Rigidbody>();
		}
		if (!netTransform)
		{
			netTransform = GetComponent<NetworkTransformReliable>();
		}
	}

	private void OnEnable()
	{
		if (!AllVehicles.Contains(this))
		{
			AllVehicles.Add(this);
		}
	}

	private void OnDisable()
	{
		AllVehicles.Remove(this);
	}

	[Client]
	public void EnterVehicle()
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::EnterVehicle()' called when client was not active");
			return;
		}
		if (NetworkClient.localPlayer != null && GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				T_Pickup component = pickupItem.GetComponent<T_Pickup>();
				if (component != null && (component.itemType == ItemType.Building || component.itemType == ItemType.Pickup))
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotPickupAvailable"));
					return;
				}
			}
		}
		if (DriverPresent)
		{
			CmdTryEnterPassenger();
		}
		else
		{
			CmdTryEnter();
		}
	}

	[Client]
	public void ExitVehicle()
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::ExitVehicle()' called when client was not active");
			return;
		}
		int localSeatIndex = GetLocalSeatIndex();
		if (localSeatIndex < 0 || !IsExitBlocked(localSeatIndex))
		{
			CmdTryExitOrPassenger();
		}
	}

	[Client]
	public void SetLocalTravelSimEnabled(bool enabled)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::SetLocalTravelSimEnabled(System.Boolean)' called when client was not active");
		}
		else if (base.isOwned)
		{
			localTravelSimEnabled = enabled;
			if (!enabled)
			{
				localTravelSimSpeedKmh = 0f;
				localTravelSimRPM = 0f;
				localTravelSimVelocity = Vector3.zero;
			}
		}
	}

	[Client]
	public void ResetPostTransitionInputFlag()
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::ResetPostTransitionInputFlag()' called when client was not active");
		}
		else if (base.isOwned)
		{
			hasInputAfterTransition = false;
			if (autoStopRoutine != null)
			{
				StopCoroutine(autoStopRoutine);
				autoStopRoutine = null;
			}
		}
	}

	public bool ShouldAutoStopAtTrigger()
	{
		if (base.isOwned)
		{
			return !hasInputAfterTransition;
		}
		return false;
	}

	[Client]
	public void BeginAutoStop()
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::BeginAutoStop()' called when client was not active");
		}
		else if (base.isOwned)
		{
			if (autoStopRoutine != null)
			{
				StopCoroutine(autoStopRoutine);
			}
			autoStopRoutine = StartCoroutine(AutoStopRoutine());
		}
	}

	private IEnumerator AutoStopRoutine()
	{
		while (!(InputProcessor == null))
		{
			float throttleInput = InputProcessor.inputs.throttleInput;
			float steerInput = InputProcessor.inputs.steerInput;
			if (throttleInput > 0.01f || Mathf.Abs(steerInput) > 0.01f)
			{
				hasInputAfterTransition = true;
				break;
			}
			if (rb != null && rb.linearVelocity.magnitude < 0.1f)
			{
				break;
			}
			InputProcessor.inputs.brakeInput = 1f;
			yield return null;
		}
		autoStopRoutine = null;
	}

	[Client]
	public void SetLocalTravelSimState(float speedKmh, float rpm)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::SetLocalTravelSimState(System.Single,System.Single)' called when client was not active");
		}
		else if (base.isOwned)
		{
			localTravelSimSpeedKmh = Mathf.Max(0f, speedKmh);
			localTravelSimRPM = Mathf.Max(0f, rpm);
		}
	}

	[Client]
	public void SetLocalTravelSimVelocity(Vector3 vel)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::SetLocalTravelSimVelocity(UnityEngine.Vector3)' called when client was not active");
		}
		else if (base.isOwned)
		{
			localTravelSimVelocity = vel;
		}
	}

	private void FixedUpdate()
	{
		if (!base.isClient || !base.isOwned || drivetrain == null || InputProcessor == null)
		{
			return;
		}
		float num = InputProcessor.inputs.steerInput;
		float num2 = InputProcessor.inputs.throttleInput;
		float brake = InputProcessor.inputs.brakeInput;
		float handbrake = InputProcessor.inputs.handbrakeInput;
		if (!hasInputAfterTransition && (num2 > 0.01f || Mathf.Abs(num) > 0.01f))
		{
			hasInputAfterTransition = true;
		}
		float rpm = drivetrain.currentEngineRPM;
		float speed = drivetrain.speed;
		if (IsControlLocked)
		{
			if (InputProcessor != null)
			{
				InputProcessor.receiveInputsFromInputManager = false;
				InputProcessor.ResetInputs();
			}
			num = 0f;
			num2 = 0f;
			brake = 1f;
			handbrake = 1f;
			if (localTravelLock && localTravelSimEnabled)
			{
				rpm = localTravelSimRPM;
				speed = localTravelSimSpeedKmh;
				if ((bool)rb && !rb.isKinematic)
				{
					rb.linearVelocity = localTravelSimVelocity;
					rb.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				rpm = drivetrain.minimumEngineRPM;
				speed = 0f;
			}
		}
		int direction = drivetrain.direction;
		CmdUpdateVehicleState(num, num2, brake, handbrake, rpm, speed, direction);
	}

	[Command]
	private void CmdUpdateVehicleState(float steer, float throttle, float brake, float handbrake, float rpm, float speed, int dir)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdUpdateVehicleState__Single__Single__Single__Single__Single__Single__Int32(steer, throttle, brake, handbrake, rpm, speed, dir);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(steer);
		writer.WriteFloat(throttle);
		writer.WriteFloat(brake);
		writer.WriteFloat(handbrake);
		writer.WriteFloat(rpm);
		writer.WriteFloat(speed);
		writer.WriteVarInt(dir);
		SendCommandInternal("System.Void SCC_Network::CmdUpdateVehicleState(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Int32)", 1696660092, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerResetSyncedInputs()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerResetSyncedInputs()' called when server was not active");
			return;
		}
		NetworksyncSteerInput = 0f;
		NetworksyncThrottleInput = 0f;
		NetworksyncBrakeInput = 1f;
		NetworksyncHandbrakeInput = 1f;
		NetworksyncEngineRPM = ((drivetrain != null) ? drivetrain.minimumEngineRPM : 0f);
		NetworksyncSpeed = 0f;
	}

	[Command]
	public void CmdSetTravelActive(bool active)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetTravelActive__Boolean(active);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendCommandInternal("System.Void SCC_Network::CmdSetTravelActive(System.Boolean)", 1701927474, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void SetIsInDigsite(bool value)
	{
		if (base.isServer)
		{
			NetworkisInDigsite = value;
			ServerUpdateAllOccupantsDigsiteStatus(value);
		}
		else
		{
			CmdSetIsInDigsite(value);
		}
	}

	[Command]
	private void CmdSetIsInDigsite(bool value)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetIsInDigsite__Boolean(value);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(value);
		SendCommandInternal("System.Void SCC_Network::CmdSetIsInDigsite(System.Boolean)", -131984890, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerUpdateAllOccupantsDigsiteStatus(bool value)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerUpdateAllOccupantsDigsiteStatus(System.Boolean)' called when server was not active");
			return;
		}
		for (int i = 0; i < maxPassengers && i < seatServer.Length; i++)
		{
			uint num = seatServer[i];
			if (num == 0)
			{
				continue;
			}
			GamePlayer gamePlayer = FindPlayerByNetId(num);
			if (gamePlayer != null)
			{
				gamePlayer.NetworkisInDigsite = value;
				if (PlayerProgressManager.Instance != null)
				{
					PlayerProgressManager.Instance.Server_SetPlayerInDigsite(gamePlayer.playerSteamId, value);
				}
			}
		}
	}

	[ClientRpc]
	private void RpcSetTravelActive(bool active)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(active);
		SendRPCInternal("System.Void SCC_Network::RpcSetTravelActive(System.Boolean)", -1225772409, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdBroadcastTravelLoading(bool open, int loadingTypeInt)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdBroadcastTravelLoading__Boolean__Int32(open, loadingTypeInt);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(open);
		writer.WriteVarInt(loadingTypeInt);
		SendCommandInternal("System.Void SCC_Network::CmdBroadcastTravelLoading(System.Boolean,System.Int32)", -399873416, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcBroadcastTravelLoading(bool open, int loadingTypeInt)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(open);
		writer.WriteVarInt(loadingTypeInt);
		SendRPCInternal("System.Void SCC_Network::RpcBroadcastTravelLoading(System.Boolean,System.Int32)", -2012856427, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void BeginForkliftOpLock(float duration)
	{
		if (base.isOwned)
		{
			localForkDetachLock = true;
			if (InputProcessor != null)
			{
				InputProcessor.receiveInputsFromInputManager = false;
				InputProcessor.ResetInputs();
			}
			if (localForkOpRoutine != null)
			{
				StopCoroutine(localForkOpRoutine);
			}
			localForkOpRoutine = StartCoroutine(LocalForkOpUnlockRoutine(duration));
		}
	}

	private IEnumerator LocalForkOpUnlockRoutine(float duration)
	{
		yield return new WaitForSeconds(duration);
		localForkDetachLock = false;
		if (base.isOwned && !localTravelLock && InputProcessor != null)
		{
			InputProcessor.receiveInputsFromInputManager = true;
		}
		localForkOpRoutine = null;
	}

	[Server]
	public void ServerBeginForkliftOpLock(float duration)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerBeginForkliftOpLock(System.Single)' called when server was not active");
			return;
		}
		NetworkserverForkOpLock = true;
		if (serverForkOpRoutine != null)
		{
			StopCoroutine(serverForkOpRoutine);
		}
		serverForkOpRoutine = StartCoroutine(ServerForkOpUnlockRoutine(duration));
	}

	[IteratorStateMachine(typeof(_003CServerForkOpUnlockRoutine_003Ed__89))]
	[Server]
	private IEnumerator ServerForkOpUnlockRoutine(float duration)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator SCC_Network::ServerForkOpUnlockRoutine(System.Single)' called when server was not active");
			return null;
		}
		return new _003CServerForkOpUnlockRoutine_003Ed__89(0)
		{
			_003C_003E4__this = this,
			duration = duration
		};
	}

	[Client]
	public void BeginTravelLock(float duration)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::BeginTravelLock(System.Single)' called when client was not active");
		}
		else if (base.isOwned)
		{
			localTravelLock = true;
			if ((bool)InputProcessor)
			{
				InputProcessor.receiveInputsFromInputManager = false;
				InputProcessor.ResetInputs();
			}
			if (localTravelRoutine != null)
			{
				StopCoroutine(localTravelRoutine);
			}
			localTravelRoutine = StartCoroutine(LocalTravelUnlockRoutine(duration));
		}
	}

	private IEnumerator LocalTravelUnlockRoutine(float duration)
	{
		yield return new WaitForSeconds(duration);
		localTravelLock = false;
		if (base.isOwned && !localForkDetachLock && InputProcessor != null)
		{
			InputProcessor.receiveInputsFromInputManager = true;
		}
		localTravelRoutine = null;
	}

	[Command]
	public void CmdServerBeginTravelLock(float duration)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdServerBeginTravelLock__Single(duration);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(duration);
		SendCommandInternal("System.Void SCC_Network::CmdServerBeginTravelLock(System.Single)", 1066087711, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[IteratorStateMachine(typeof(_003CServerTravelUnlockRoutine_003Ed__93))]
	[Server]
	private IEnumerator ServerTravelUnlockRoutine(float duration)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator SCC_Network::ServerTravelUnlockRoutine(System.Single)' called when server was not active");
			return null;
		}
		return new _003CServerTravelUnlockRoutine_003Ed__93(0)
		{
			_003C_003E4__this = this,
			duration = duration
		};
	}

	[Client]
	public void EndTravelLockNow()
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void SCC_Network::EndTravelLockNow()' called when client was not active");
		}
		else if (base.isOwned)
		{
			if (localTravelRoutine != null)
			{
				StopCoroutine(localTravelRoutine);
				localTravelRoutine = null;
			}
			localTravelLock = false;
			if ((bool)InputProcessor)
			{
				InputProcessor.receiveInputsFromInputManager = true;
				InputProcessor.ResetInputs();
			}
		}
	}

	[Command]
	public void CmdEndServerTravelLockNow()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdEndServerTravelLockNow();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SCC_Network::CmdEndServerTravelLockNow()", 2056880462, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdTeleportVehicleAll(Vector3 pos, Quaternion rot)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTeleportVehicleAll__Vector3__Quaternion(pos, rot);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendCommandInternal("System.Void SCC_Network::CmdTeleportVehicleAll(UnityEngine.Vector3,UnityEngine.Quaternion)", -1887614771, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerTeleport(Vector3 pos, Quaternion rot)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		bool isKinematic = true;
		if (rb != null)
		{
			isKinematic = rb.isKinematic;
			rb.isKinematic = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		base.transform.SetPositionAndRotation(pos, rot);
		if (rb != null)
		{
			rb.position = pos;
			rb.rotation = rot;
			rb.isKinematic = isKinematic;
		}
		RpcTeleportVehicleAll(pos, rot);
	}

	[ClientRpc]
	private void RpcTeleportVehicleAll(Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendRPCInternal("System.Void SCC_Network::RpcTeleportVehicleAll(UnityEngine.Vector3,UnityEngine.Quaternion)", 19856426, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdTryEnter(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryEnter__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SCC_Network::CmdTryEnter(Mirror.NetworkConnectionToClient)", 1244964647, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdTryEnterPassenger(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryEnterPassenger__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SCC_Network::CmdTryEnterPassenger(Mirror.NetworkConnectionToClient)", 1007743285, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private GamePlayer FindPlayerByNetId(uint netId)
	{
		GameObject gameObject = FindNetworkObject(netId);
		if (!gameObject)
		{
			return null;
		}
		return gameObject.GetComponent<GamePlayer>();
	}

	private GameObject FindNetworkObject(uint netId)
	{
		if (NetworkServer.active && NetworkServer.spawned.TryGetValue(netId, out var value))
		{
			return value.gameObject;
		}
		if (NetworkClient.active && NetworkClient.spawned.TryGetValue(netId, out var value2))
		{
			return value2.gameObject;
		}
		return null;
	}

	[Command(requiresAuthority = false)]
	private void CmdTryExitOrPassenger(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryExitOrPassenger__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SCC_Network::CmdTryExitOrPassenger(Mirror.NetworkConnectionToClient)", 1681573994, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetNotifyLocalPassengerEnter(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void SCC_Network::TargetNotifyLocalPassengerEnter(Mirror.NetworkConnection)", 1673034181, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetNotifyLocalPassengerExit(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void SCC_Network::TargetNotifyLocalPassengerExit(Mirror.NetworkConnection)", 930544233, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOwnerTakenAll()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SCC_Network::RpcOwnerTakenAll()", -412525187, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOwnerReleasedAll()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SCC_Network::RpcOwnerReleasedAll()", -1113273415, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSeatMap(uint s0, uint s1, uint s2, uint s3, int newCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(s0);
		writer.WriteVarUInt(s1);
		writer.WriteVarUInt(s2);
		writer.WriteVarUInt(s3);
		writer.WriteVarInt(newCount);
		SendRPCInternal("System.Void SCC_Network::RpcSeatMap(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.Int32)", 975458276, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void UpdateVoiceForSeats(uint prev0, uint prev1, uint prev2, uint prev3)
	{
		uint[] array = new uint[4] { prev0, prev1, prev2, prev3 };
		for (int i = 0; i < 4; i++)
		{
			uint num = array[i];
			if (num == 0)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < 4; j++)
			{
				if (seatClient[j] == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				GamePlayer gamePlayer = FindPlayerByNetId(num);
				if (gamePlayer != null && gamePlayer.voiceChat != null)
				{
					gamePlayer.voiceChat.ClearVehicleVoice();
				}
			}
		}
		for (int k = 0; k < maxPassengers && k < seatClient.Length; k++)
		{
			uint num2 = seatClient[k];
			if (num2 == 0 || seatVoiceAudioSources == null || k >= seatVoiceAudioSources.Length)
			{
				continue;
			}
			AudioSource audioSource = seatVoiceAudioSources[k];
			if (!(audioSource == null))
			{
				GameObject vehicleIcon = ((seatVoiceIconObjects != null && k < seatVoiceIconObjects.Length) ? seatVoiceIconObjects[k] : null);
				GamePlayer gamePlayer2 = FindPlayerByNetId(num2);
				if (gamePlayer2 != null && gamePlayer2.voiceChat != null)
				{
					gamePlayer2.voiceChat.SetVehicleVoice(audioSource, vehicleIcon);
				}
			}
		}
	}

	private void TryRefreshOccupantsUI()
	{
		if (refreshOccupantsUIDirectly && !(GameManager.Instance == null) && !(GameManager.Instance.UImanager == null) && !(GameManager.Instance.UImanager.vehicleOccupantsUI == null))
		{
			VehicleOccupantsUI vehicleOccupantsUI = GameManager.Instance.UImanager.vehicleOccupantsUI;
			vehicleOccupantsUI.currentVehicle = this;
			vehicleOccupantsUI.RefreshUI();
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		UpdateKinematic();
		ApplySyncDirection();
		ApplyOccupantObjects();
		EnsureExitBindingDisabledForLocal();
		localTravelActive = serverTravelActive;
		if (HasDriverAll && audioComponent != null)
		{
			audioComponent.StartEngine();
		}
	}

	public override void OnStartAuthority()
	{
		localForkDetachLock = false;
		localTravelLock = false;
		if ((bool)InputProcessor)
		{
			InputProcessor.receiveInputsFromInputManager = true;
		}
		BindExitInput(bind: true);
		BindLiftInput(bind: true);
		BindHornInput(bind: true);
		UpdateKinematic();
		ApplySyncDirection();
		OnEnter?.Invoke();
		if (forklift != null)
		{
			forklift.LocalDriverEntered();
		}
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.TryEquipByItemType(ItemType.Vehicle);
			GameManager.Instance.localEquipments.SetOnVehicle(value: true);
		}
	}

	public override void OnStopAuthority()
	{
		localForkDetachLock = false;
		localTravelLock = false;
		localTravelActive = false;
		SetLocalTravelSimEnabled(enabled: false);
		if ((bool)InputProcessor)
		{
			InputProcessor.receiveInputsFromInputManager = false;
			InputProcessor.ResetInputs();
		}
		if (forklift != null)
		{
			forklift.LocalDriverExited();
		}
		BindHornInput(bind: false);
		if (!IsLocalOccupant())
		{
			BindExitInput(bind: false);
			BindLiftInput(bind: false);
		}
		UpdateKinematic();
		ApplySyncDirection();
		OnExit?.Invoke();
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.TryUnequip();
			GameManager.Instance.localEquipments.SetOnVehicle(value: false);
		}
	}

	public override void OnStopServer()
	{
		if (base.netIdentity.connectionToClient != null)
		{
			base.netIdentity.RemoveClientAuthority();
		}
		NetworkserverTravelActive = false;
		NetworkserverTravelLock = false;
		ServerResetSyncedInputs();
		Array.Clear(seatServer, 0, seatServer.Length);
		ServerRecountAndBroadcast();
		UpdateKinematic();
		ApplySyncDirection();
	}

	private void OnExitPerformed(InputAction.CallbackContext _)
	{
		if (!IsControlLocked)
		{
			if (InputProcessor != null)
			{
				InputProcessor.ResetInputs();
			}
			ExitVehicle();
		}
	}

	private void OnLiftPerformed(InputAction.CallbackContext _)
	{
		if (base.isOwned && !IsControlLocked && !(forklift == null))
		{
			forklift.TryAttach();
		}
	}

	private void OnHornStarted(InputAction.CallbackContext _)
	{
		if (base.isOwned)
		{
			CmdSetHornState(1);
			if (hornHoldRoutine != null)
			{
				StopCoroutine(hornHoldRoutine);
			}
			hornHoldRoutine = StartCoroutine(HornHoldRoutine());
		}
	}

	private void OnHornCanceled(InputAction.CallbackContext _)
	{
		if (base.isOwned && hornHoldRoutine != null)
		{
			StopCoroutine(hornHoldRoutine);
			hornHoldRoutine = null;
		}
	}

	private IEnumerator HornHoldRoutine()
	{
		yield return new WaitForSeconds(longHornDelay);
		CmdSetHornState(2);
		hornHoldRoutine = null;
	}

	[Command]
	private void CmdSetHornState(byte state)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetHornState__Byte(state);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, state);
		SendCommandInternal("System.Void SCC_Network::CmdSetHornState(System.Byte)", 1163090298, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHornState(byte state)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		NetworkWriterExtensions.WriteByte(writer, state);
		SendRPCInternal("System.Void SCC_Network::RpcHornState(System.Byte)", 1342289685, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayEnterExitSound(bool enter)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(enter);
		SendRPCInternal("System.Void SCC_Network::RpcPlayEnterExitSound(System.Boolean)", -551395320, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerRecountAndBroadcast()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerRecountAndBroadcast()' called when server was not active");
			return;
		}
		int num = 0;
		for (int i = 0; i < maxPassengers && i < seatServer.Length; i++)
		{
			if (seatServer[i] != 0)
			{
				num++;
			}
		}
		NetworkoccupantCount = num;
		RpcSeatMap(seatServer[0], seatServer[1], seatServer[2], seatServer[3], occupantCount);
	}

	[Server]
	public static void HandleClientDisconnected(uint netId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::HandleClientDisconnected(System.UInt32)' called when server was not active");
			return;
		}
		foreach (SCC_Network allVehicle in AllVehicles)
		{
			if (allVehicle == null)
			{
				continue;
			}
			bool flag = false;
			for (int i = 0; i < allVehicle.seatServer.Length; i++)
			{
				if (allVehicle.seatServer[i] == netId)
				{
					allVehicle.seatServer[i] = 0u;
					flag = true;
				}
			}
			if (flag)
			{
				if (allVehicle.netIdentity != null && allVehicle.netIdentity.connectionToClient != null && allVehicle.netIdentity.connectionToClient.identity != null && allVehicle.netIdentity.connectionToClient.identity.netId == netId)
				{
					allVehicle.netIdentity.RemoveClientAuthority();
				}
				allVehicle.NetworkserverTravelActive = false;
				allVehicle.NetworkserverTravelLock = false;
				allVehicle.ServerResetSyncedInputs();
				allVehicle.ServerRecountAndBroadcast();
				allVehicle.RpcOwnerReleasedAll();
			}
		}
	}

	[Server]
	public static void ServerRebroadcastSeatsForAll()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void SCC_Network::ServerRebroadcastSeatsForAll()' called when server was not active");
			return;
		}
		foreach (SCC_Network allVehicle in AllVehicles)
		{
			if (!(allVehicle == null))
			{
				allVehicle.ServerRecountAndBroadcast();
			}
		}
	}

	private void UpdateKinematic()
	{
		if (!rb)
		{
			return;
		}
		bool flag = false;
		if (base.isServer)
		{
			NetworkConnectionToClient networkConnectionToClient = base.netIdentity.connectionToClient;
			if (networkConnectionToClient != null && networkConnectionToClient == NetworkServer.localConnection)
			{
				flag = true;
			}
		}
		if (base.isClient && base.isOwned)
		{
			flag = true;
		}
		rb.isKinematic = !flag;
	}

	private void ApplySyncDirection()
	{
		if ((bool)netTransform)
		{
			if (base.isServer)
			{
				netTransform.syncDirection = ((base.netIdentity.connectionToClient != null) ? SyncDirection.ClientToServer : SyncDirection.ServerToClient);
			}
			if (base.isClient && !base.isServer)
			{
				netTransform.syncDirection = (base.isOwned ? SyncDirection.ClientToServer : SyncDirection.ServerToClient);
			}
			if (base.isClient && base.isServer && base.isOwned)
			{
				netTransform.syncDirection = SyncDirection.ClientToServer;
			}
		}
	}

	private void ApplyOccupantObjects()
	{
		if (passengersList == null)
		{
			return;
		}
		for (int i = 0; i < passengersList.Count; i++)
		{
			GameObject gameObject = passengersList[i];
			if (!gameObject)
			{
				continue;
			}
			bool flag = i < seatClient.Length && seatClient[i] != 0;
			if (gameObject.activeSelf == flag)
			{
				continue;
			}
			gameObject.SetActive(flag);
			if (flag)
			{
				GamePlayer gamePlayer = FindPlayerByNetId(seatClient[i]);
				SkinWrapper component = gameObject.transform.GetChild(0).GetComponent<SkinWrapper>();
				if (component != null && gamePlayer != null)
				{
					component.ApplyCustomization(gamePlayer.headID, gamePlayer.topID, gamePlayer.bottomID, gamePlayer.helmetID, gamePlayer.glovesID, gamePlayer.bootsID, gamePlayer.beltID, gamePlayer.topMatID, gamePlayer.bottomMatID, gamePlayer.glovesMatID, gamePlayer.helmetMatID, gamePlayer.bootsMatID);
				}
			}
		}
	}

	public bool IsLocalOccupant()
	{
		if (base.isOwned)
		{
			return true;
		}
		NetworkIdentity localPlayer = NetworkClient.localPlayer;
		if (localPlayer == null)
		{
			return false;
		}
		uint num = localPlayer.netId;
		if (num == 0)
		{
			return false;
		}
		for (int i = 0; i < maxPassengers && i < seatClient.Length; i++)
		{
			if (seatClient[i] == num)
			{
				return true;
			}
		}
		return false;
	}

	private void BindExitInput(bool bind)
	{
		if (ExitAction == null || ExitAction.action == null)
		{
			return;
		}
		if (bind)
		{
			ExitAction.action.performed -= OnExitPerformed;
			ExitAction.action.performed += OnExitPerformed;
			if (!ExitAction.action.enabled)
			{
				ExitAction.action.Enable();
			}
		}
		else
		{
			ExitAction.action.performed -= OnExitPerformed;
		}
	}

	private void BindLiftInput(bool bind)
	{
		if (LiftAction == null || LiftAction.action == null)
		{
			return;
		}
		if (bind)
		{
			LiftAction.action.performed -= OnLiftPerformed;
			LiftAction.action.performed += OnLiftPerformed;
			if (!LiftAction.action.enabled)
			{
				LiftAction.action.Enable();
			}
		}
		else
		{
			LiftAction.action.performed -= OnLiftPerformed;
		}
	}

	private void BindHornInput(bool bind)
	{
		if (HornAction == null || HornAction.action == null)
		{
			return;
		}
		if (bind)
		{
			HornAction.action.started -= OnHornStarted;
			HornAction.action.started += OnHornStarted;
			HornAction.action.canceled -= OnHornCanceled;
			HornAction.action.canceled += OnHornCanceled;
			if (!HornAction.action.enabled)
			{
				HornAction.action.Enable();
			}
		}
		else
		{
			HornAction.action.started -= OnHornStarted;
			HornAction.action.canceled -= OnHornCanceled;
		}
	}

	private void EnsureExitBindingEnabledForLocal()
	{
		BindExitInput(bind: true);
	}

	private void EnsureExitBindingDisabledForLocal()
	{
		BindExitInput(bind: false);
	}

	[Server]
	private Vector3 GetExitWorldPosition(int seatIndex)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'UnityEngine.Vector3 SCC_Network::GetExitWorldPosition(System.Int32)' called when server was not active");
			return default(Vector3);
		}
		if (seatIndex >= 0 && seatIndex < exitPositions.Count && exitPositions[seatIndex] != null)
		{
			return exitPositions[seatIndex].position;
		}
		return base.transform.position + base.transform.right * ((seatIndex == 0) ? (-2f) : 2f);
	}

	[Server]
	private Quaternion GetExitWorldRotation(int seatIndex)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'UnityEngine.Quaternion SCC_Network::GetExitWorldRotation(System.Int32)' called when server was not active");
			return default(Quaternion);
		}
		if (seatIndex >= 0 && seatIndex < exitPositions.Count && exitPositions[seatIndex] != null)
		{
			return exitPositions[seatIndex].rotation;
		}
		return base.transform.rotation;
	}

	[TargetRpc]
	private void TargetTeleportToExitPosition(NetworkConnection target, Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendTargetRPCInternal(target, "System.Void SCC_Network::TargetTeleportToExitPosition(Mirror.NetworkConnection,UnityEngine.Vector3,UnityEngine.Quaternion)", -74093206, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private int GetLocalSeatIndex()
	{
		if (base.isOwned)
		{
			return 0;
		}
		NetworkIdentity localPlayer = NetworkClient.localPlayer;
		if (localPlayer == null)
		{
			return -1;
		}
		uint num = localPlayer.netId;
		if (num == 0)
		{
			return -1;
		}
		for (int i = 0; i < maxPassengers && i < seatClient.Length; i++)
		{
			if (seatClient[i] == num)
			{
				return i;
			}
		}
		return -1;
	}

	private bool IsExitBlocked(int seatIndex)
	{
		if (seatIndex < 0 || seatIndex >= exitPositions.Count || exitPositions[seatIndex] == null)
		{
			return false;
		}
		Transform obj = exitPositions[seatIndex];
		Vector3 vector = obj.TransformDirection(Vector3.forward);
		Vector3 origin = obj.position + vector * 0.25f;
		Vector3 direction = -vector;
		if (Physics.Raycast(origin, direction, out var hitInfo, 1f) && !hitInfo.transform.IsChildOf(base.transform))
		{
			if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_ExitBlocked"));
			}
			return true;
		}
		return false;
	}

	public int GetOccupantCount()
	{
		return occupantCount;
	}

	public bool HasFreeSeat()
	{
		return occupantCount < maxPassengers;
	}

	public void ForceRefreshOccupantObjects()
	{
		ApplyOccupantObjects();
	}

	public uint GetSeatNetId(int seatIndex)
	{
		if (seatIndex < 0 || seatIndex >= seatClient.Length)
		{
			return 0u;
		}
		return seatClient[seatIndex];
	}

	static SCC_Network()
	{
		AllVehicles = new List<SCC_Network>();
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdUpdateVehicleState(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Int32)", InvokeUserCode_CmdUpdateVehicleState__Single__Single__Single__Single__Single__Single__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdSetTravelActive(System.Boolean)", InvokeUserCode_CmdSetTravelActive__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdSetIsInDigsite(System.Boolean)", InvokeUserCode_CmdSetIsInDigsite__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdBroadcastTravelLoading(System.Boolean,System.Int32)", InvokeUserCode_CmdBroadcastTravelLoading__Boolean__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdServerBeginTravelLock(System.Single)", InvokeUserCode_CmdServerBeginTravelLock__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdEndServerTravelLockNow()", InvokeUserCode_CmdEndServerTravelLockNow, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdTeleportVehicleAll(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdTeleportVehicleAll__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdTryEnter(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTryEnter__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdTryEnterPassenger(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTryEnterPassenger__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdTryExitOrPassenger(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTryExitOrPassenger__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(SCC_Network), "System.Void SCC_Network::CmdSetHornState(System.Byte)", InvokeUserCode_CmdSetHornState__Byte, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcSetTravelActive(System.Boolean)", InvokeUserCode_RpcSetTravelActive__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcBroadcastTravelLoading(System.Boolean,System.Int32)", InvokeUserCode_RpcBroadcastTravelLoading__Boolean__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcTeleportVehicleAll(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleportVehicleAll__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcOwnerTakenAll()", InvokeUserCode_RpcOwnerTakenAll);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcOwnerReleasedAll()", InvokeUserCode_RpcOwnerReleasedAll);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcSeatMap(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.Int32)", InvokeUserCode_RpcSeatMap__UInt32__UInt32__UInt32__UInt32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcHornState(System.Byte)", InvokeUserCode_RpcHornState__Byte);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::RpcPlayEnterExitSound(System.Boolean)", InvokeUserCode_RpcPlayEnterExitSound__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::TargetNotifyLocalPassengerEnter(Mirror.NetworkConnection)", InvokeUserCode_TargetNotifyLocalPassengerEnter__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::TargetNotifyLocalPassengerExit(Mirror.NetworkConnection)", InvokeUserCode_TargetNotifyLocalPassengerExit__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(SCC_Network), "System.Void SCC_Network::TargetTeleportToExitPosition(Mirror.NetworkConnection,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_TargetTeleportToExitPosition__NetworkConnection__Vector3__Quaternion);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdUpdateVehicleState__Single__Single__Single__Single__Single__Single__Int32(float steer, float throttle, float brake, float handbrake, float rpm, float speed, int dir)
	{
		NetworksyncSteerInput = steer;
		NetworksyncThrottleInput = throttle;
		NetworksyncBrakeInput = brake;
		NetworksyncHandbrakeInput = handbrake;
		NetworksyncEngineRPM = rpm;
		NetworksyncSpeed = speed;
		NetworksyncDirection = dir;
	}

	protected static void InvokeUserCode_CmdUpdateVehicleState__Single__Single__Single__Single__Single__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdUpdateVehicleState called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdUpdateVehicleState__Single__Single__Single__Single__Single__Single__Int32(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdSetTravelActive__Boolean(bool active)
	{
		NetworkserverTravelActive = active;
		RpcSetTravelActive(active);
	}

	protected static void InvokeUserCode_CmdSetTravelActive__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetTravelActive called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdSetTravelActive__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetIsInDigsite__Boolean(bool value)
	{
		NetworkisInDigsite = value;
		ServerUpdateAllOccupantsDigsiteStatus(value);
	}

	protected static void InvokeUserCode_CmdSetIsInDigsite__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetIsInDigsite called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdSetIsInDigsite__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcSetTravelActive__Boolean(bool active)
	{
		localTravelActive = active;
	}

	protected static void InvokeUserCode_RpcSetTravelActive__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSetTravelActive called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcSetTravelActive__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdBroadcastTravelLoading__Boolean__Int32(bool open, int loadingTypeInt)
	{
		RpcBroadcastTravelLoading(open, loadingTypeInt);
	}

	protected static void InvokeUserCode_CmdBroadcastTravelLoading__Boolean__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdBroadcastTravelLoading called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdBroadcastTravelLoading__Boolean__Int32(reader.ReadBool(), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcBroadcastTravelLoading__Boolean__Int32(bool open, int loadingTypeInt)
	{
		if (!(GameManager.Instance == null) && IsLocalOccupant())
		{
			if (open)
			{
				GameManager.Instance.OpenLoadingUI((LoadingType)loadingTypeInt);
			}
			else
			{
				GameManager.Instance.CloseLoadingUI((LoadingType)loadingTypeInt);
			}
		}
	}

	protected static void InvokeUserCode_RpcBroadcastTravelLoading__Boolean__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcBroadcastTravelLoading called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcBroadcastTravelLoading__Boolean__Int32(reader.ReadBool(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdServerBeginTravelLock__Single(float duration)
	{
		NetworkserverTravelLock = true;
		if (serverTravelRoutine != null)
		{
			StopCoroutine(serverTravelRoutine);
		}
		serverTravelRoutine = StartCoroutine(ServerTravelUnlockRoutine(duration));
	}

	protected static void InvokeUserCode_CmdServerBeginTravelLock__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdServerBeginTravelLock called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdServerBeginTravelLock__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_CmdEndServerTravelLockNow()
	{
		NetworkserverTravelLock = false;
		if (serverTravelRoutine != null)
		{
			StopCoroutine(serverTravelRoutine);
			serverTravelRoutine = null;
		}
	}

	protected static void InvokeUserCode_CmdEndServerTravelLockNow(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdEndServerTravelLockNow called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdEndServerTravelLockNow();
		}
	}

	protected void UserCode_CmdTeleportVehicleAll__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		RpcTeleportVehicleAll(pos, rot);
	}

	protected static void InvokeUserCode_CmdTeleportVehicleAll__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTeleportVehicleAll called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdTeleportVehicleAll__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcTeleportVehicleAll__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		bool isKinematic = true;
		if (rb != null)
		{
			isKinematic = rb.isKinematic;
			rb.isKinematic = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		base.transform.SetPositionAndRotation(pos, rot);
		if (rb != null)
		{
			rb.position = pos;
			rb.rotation = rot;
			rb.isKinematic = isKinematic;
		}
	}

	protected static void InvokeUserCode_RpcTeleportVehicleAll__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcTeleportVehicleAll called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcTeleportVehicleAll__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdTryEnter__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (base.netIdentity.connectionToClient == null)
		{
			NetworkConnectionToClient networkConnectionToClient = sender ?? NetworkServer.localConnection;
			if (networkConnectionToClient != null && !(networkConnectionToClient.identity == null))
			{
				base.netIdentity.AssignClientAuthority(networkConnectionToClient);
				seatServer[0] = networkConnectionToClient.identity.netId;
				ServerRecountAndBroadcast();
				RpcOwnerTakenAll();
			}
		}
	}

	protected static void InvokeUserCode_CmdTryEnter__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTryEnter called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdTryEnter__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdTryEnterPassenger__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (base.netIdentity.connectionToClient == null)
		{
			return;
		}
		if (sender == null)
		{
			sender = NetworkServer.localConnection;
		}
		if (sender == null || sender.identity == null)
		{
			return;
		}
		uint num = sender.identity.netId;
		if (num == 0)
		{
			return;
		}
		for (int i = 0; i < seatServer.Length; i++)
		{
			if (seatServer[i] == num)
			{
				return;
			}
		}
		int num2 = -1;
		for (int j = 1; j < maxPassengers && j < seatServer.Length; j++)
		{
			if (seatServer[j] == 0)
			{
				num2 = j;
				break;
			}
		}
		if (num2 != -1)
		{
			seatServer[num2] = num;
			ServerRecountAndBroadcast();
			RpcPlayEnterExitSound(enter: true);
			TargetNotifyLocalPassengerEnter(sender);
		}
	}

	protected static void InvokeUserCode_CmdTryEnterPassenger__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTryEnterPassenger called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdTryEnterPassenger__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdTryExitOrPassenger__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		NetworkConnectionToClient networkConnectionToClient = sender ?? NetworkServer.localConnection;
		if (networkConnectionToClient == null || networkConnectionToClient.identity == null)
		{
			return;
		}
		uint num = networkConnectionToClient.identity.netId;
		if (serverForkOpLock || serverTravelLock)
		{
			for (int i = 0; i < maxPassengers && i < seatServer.Length; i++)
			{
				if (seatServer[i] == num)
				{
					return;
				}
			}
		}
		NetworkConnectionToClient networkConnectionToClient2 = base.netIdentity.connectionToClient;
		if (networkConnectionToClient2 != null && networkConnectionToClient == networkConnectionToClient2)
		{
			ServerResetSyncedInputs();
			Vector3 exitWorldPosition = GetExitWorldPosition(0);
			Quaternion exitWorldRotation = GetExitWorldRotation(0);
			base.netIdentity.RemoveClientAuthority();
			seatServer[0] = 0u;
			ServerRecountAndBroadcast();
			RpcOwnerReleasedAll();
			TargetTeleportToExitPosition(networkConnectionToClient, exitWorldPosition, exitWorldRotation);
			return;
		}
		for (int j = 1; j < maxPassengers && j < seatServer.Length; j++)
		{
			if (seatServer[j] == num)
			{
				Vector3 exitWorldPosition2 = GetExitWorldPosition(j);
				Quaternion exitWorldRotation2 = GetExitWorldRotation(j);
				seatServer[j] = 0u;
				ServerRecountAndBroadcast();
				RpcPlayEnterExitSound(enter: false);
				TargetNotifyLocalPassengerExit(networkConnectionToClient);
				TargetTeleportToExitPosition(networkConnectionToClient, exitWorldPosition2, exitWorldRotation2);
				break;
			}
		}
	}

	protected static void InvokeUserCode_CmdTryExitOrPassenger__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTryExitOrPassenger called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdTryExitOrPassenger__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_TargetNotifyLocalPassengerEnter__NetworkConnection(NetworkConnection target)
	{
		EnsureExitBindingEnabledForLocal();
		OnLocalPassengerEnter?.Invoke();
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.TryEquipByItemType(ItemType.Vehicle);
		}
	}

	protected static void InvokeUserCode_TargetNotifyLocalPassengerEnter__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetNotifyLocalPassengerEnter called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_TargetNotifyLocalPassengerEnter__NetworkConnection(null);
		}
	}

	protected void UserCode_TargetNotifyLocalPassengerExit__NetworkConnection(NetworkConnection target)
	{
		if (!IsLocalOccupant())
		{
			EnsureExitBindingDisabledForLocal();
		}
		OnLocalPassengerExit?.Invoke();
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_TargetNotifyLocalPassengerExit__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetNotifyLocalPassengerExit called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_TargetNotifyLocalPassengerExit__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcOwnerTakenAll()
	{
		UpdateKinematic();
		ApplySyncDirection();
		ApplyOccupantObjects();
		if (audioComponent != null)
		{
			audioComponent.StartEngine();
			audioComponent.PlayEnterSound();
		}
		OnOwnerTakenAll?.Invoke();
		OnPassengerCountChangedAll?.Invoke();
		TryRefreshOccupantsUI();
	}

	protected static void InvokeUserCode_RpcOwnerTakenAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOwnerTakenAll called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcOwnerTakenAll();
		}
	}

	protected void UserCode_RpcOwnerReleasedAll()
	{
		UpdateKinematic();
		ApplySyncDirection();
		ApplyOccupantObjects();
		if (audioComponent != null)
		{
			audioComponent.StopEngine();
			audioComponent.PlayExitSound();
		}
		OnOwnerReleasedAll?.Invoke();
		OnPassengerCountChangedAll?.Invoke();
		TryRefreshOccupantsUI();
	}

	protected static void InvokeUserCode_RpcOwnerReleasedAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOwnerReleasedAll called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcOwnerReleasedAll();
		}
	}

	protected void UserCode_RpcSeatMap__UInt32__UInt32__UInt32__UInt32__Int32(uint s0, uint s1, uint s2, uint s3, int newCount)
	{
		uint prev = prevSeatClient[0];
		uint prev2 = prevSeatClient[1];
		uint prev3 = prevSeatClient[2];
		uint prev4 = prevSeatClient[3];
		seatClient[0] = s0;
		seatClient[1] = s1;
		seatClient[2] = s2;
		seatClient[3] = s3;
		prevSeatClient[0] = s0;
		prevSeatClient[1] = s1;
		prevSeatClient[2] = s2;
		prevSeatClient[3] = s3;
		NetworkoccupantCount = newCount;
		ApplyOccupantObjects();
		OnPassengerCountChangedAll?.Invoke();
		TryRefreshOccupantsUI();
		if (IsLocalOccupant())
		{
			EnsureExitBindingEnabledForLocal();
		}
		else
		{
			EnsureExitBindingDisabledForLocal();
		}
		UpdateVoiceForSeats(prev, prev2, prev3, prev4);
	}

	protected static void InvokeUserCode_RpcSeatMap__UInt32__UInt32__UInt32__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSeatMap called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcSeatMap__UInt32__UInt32__UInt32__UInt32__Int32(reader.ReadVarUInt(), reader.ReadVarUInt(), reader.ReadVarUInt(), reader.ReadVarUInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdSetHornState__Byte(byte state)
	{
		NetworksyncHornState = state;
		RpcHornState(state);
	}

	protected static void InvokeUserCode_CmdSetHornState__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetHornState called on client.");
		}
		else
		{
			((SCC_Network)obj).UserCode_CmdSetHornState__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcHornState__Byte(byte state)
	{
		if (!(audioComponent == null))
		{
			switch (state)
			{
			case 1:
				audioComponent.PlayHorn();
				break;
			case 2:
				audioComponent.PlayLongHorn();
				break;
			}
		}
	}

	protected static void InvokeUserCode_RpcHornState__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcHornState called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcHornState__Byte(NetworkReaderExtensions.ReadByte(reader));
		}
	}

	protected void UserCode_RpcPlayEnterExitSound__Boolean(bool enter)
	{
		if (!(audioComponent == null))
		{
			if (enter)
			{
				audioComponent.PlayEnterSound();
			}
			else
			{
				audioComponent.PlayExitSound();
			}
		}
	}

	protected static void InvokeUserCode_RpcPlayEnterExitSound__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPlayEnterExitSound called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_RpcPlayEnterExitSound__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_TargetTeleportToExitPosition__NetworkConnection__Vector3__Quaternion(NetworkConnection target, Vector3 pos, Quaternion rot)
	{
		NetworkIdentity localPlayer = NetworkClient.localPlayer;
		if (!(localPlayer == null))
		{
			GamePlayer component = localPlayer.GetComponent<GamePlayer>();
			if (component != null)
			{
				component.NetworkTeleport(pos, rot);
			}
		}
	}

	protected static void InvokeUserCode_TargetTeleportToExitPosition__NetworkConnection__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetTeleportToExitPosition called on server.");
		}
		else
		{
			((SCC_Network)obj).UserCode_TargetTeleportToExitPosition__NetworkConnection__Vector3__Quaternion(null, reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(syncSteerInput);
			writer.WriteFloat(syncThrottleInput);
			writer.WriteFloat(syncBrakeInput);
			writer.WriteFloat(syncHandbrakeInput);
			writer.WriteFloat(syncEngineRPM);
			writer.WriteFloat(syncSpeed);
			writer.WriteVarInt(syncDirection);
			writer.WriteBool(isInDigsite);
			NetworkWriterExtensions.WriteByte(writer, syncHornState);
			writer.WriteVarInt(occupantCount);
			writer.WriteBool(serverTravelActive);
			writer.WriteBool(serverTravelLock);
			writer.WriteBool(serverForkOpLock);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(syncSteerInput);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(syncThrottleInput);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(syncBrakeInput);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteFloat(syncHandbrakeInput);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteFloat(syncEngineRPM);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteFloat(syncSpeed);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteVarInt(syncDirection);
		}
		if ((syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteBool(isInDigsite);
		}
		if ((syncVarDirtyBits & 0x100L) != 0L)
		{
			NetworkWriterExtensions.WriteByte(writer, syncHornState);
		}
		if ((syncVarDirtyBits & 0x200L) != 0L)
		{
			writer.WriteVarInt(occupantCount);
		}
		if ((syncVarDirtyBits & 0x400L) != 0L)
		{
			writer.WriteBool(serverTravelActive);
		}
		if ((syncVarDirtyBits & 0x800L) != 0L)
		{
			writer.WriteBool(serverTravelLock);
		}
		if ((syncVarDirtyBits & 0x1000L) != 0L)
		{
			writer.WriteBool(serverForkOpLock);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncSteerInput, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncThrottleInput, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncBrakeInput, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncHandbrakeInput, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncEngineRPM, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncSpeed, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref syncDirection, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isInDigsite, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncHornState, null, NetworkReaderExtensions.ReadByte(reader));
			GeneratedSyncVarDeserialize(ref occupantCount, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref serverTravelActive, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref serverTravelLock, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref serverForkOpLock, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncSteerInput, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncThrottleInput, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncBrakeInput, null, reader.ReadFloat());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncHandbrakeInput, null, reader.ReadFloat());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncEngineRPM, null, reader.ReadFloat());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncSpeed, null, reader.ReadFloat());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncDirection, null, reader.ReadVarInt());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInDigsite, null, reader.ReadBool());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncHornState, null, NetworkReaderExtensions.ReadByte(reader));
		}
		if ((num & 0x200L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref occupantCount, null, reader.ReadVarInt());
		}
		if ((num & 0x400L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref serverTravelActive, null, reader.ReadBool());
		}
		if ((num & 0x800L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref serverTravelLock, null, reader.ReadBool());
		}
		if ((num & 0x1000L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref serverForkOpLock, null, reader.ReadBool());
		}
	}
}
