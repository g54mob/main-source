using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_PalletMachine : NetworkBehaviour, IGameSave
{
	public enum ProcessingPhase
	{
		None = 0,
		ProcessingStarted = 1,
		DeliveryCreated = 2,
		MovingToOutputs = 3
	}

	[Serializable]
	public class PalletMachineSaveData
	{
		public string inputPalletId;

		public string deliveryPalletId;

		public ProcessingPhase phase;

		public bool autoWork;
	}

	[CompilerGenerated]
	private sealed class _003CCo_ContinueAfterLoad_003Ed__123 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_PalletMachine _003C_003E4__this;

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
		public _003CCo_ContinueAfterLoad_003Ed__123(int _003C_003E1__state)
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
			T_PalletMachine t_PalletMachine = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				t_PalletMachine._isLoadContinuationInProgress = true;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
			{
				_003C_003E1__state = -1;
				T_Pallet t_Pallet = t_PalletMachine.FindPalletByUniqueId(t_PalletMachine._pendingInputPalletId);
				T_DeliveryPallet t_DeliveryPallet = null;
				if (!string.IsNullOrEmpty(t_PalletMachine._pendingDeliveryPalletId) && DynamicObjectSpawner.Instance != null)
				{
					t_DeliveryPallet = DynamicObjectSpawner.Instance.GetDeliveryPalletByUniqueId(t_PalletMachine._pendingDeliveryPalletId);
				}
				UnityEngine.Debug.Log(string.Format("[T_PalletMachine] Co_ContinueAfterLoad - Phase: {0}, InputPallet: {1}, DeliveryPallet: {2}", t_PalletMachine._pendingPhase, (t_Pallet != null) ? "found" : "null", (t_DeliveryPallet != null) ? "found" : "null"));
				switch (t_PalletMachine._pendingPhase)
				{
				case ProcessingPhase.None:
				{
					if (!(t_Pallet != null))
					{
						break;
					}
					NetworkIdentity component3 = t_Pallet.GetComponent<NetworkIdentity>();
					if (component3 != null)
					{
						t_PalletMachine.Network_inputPalletNetId = component3.netId;
						t_PalletMachine._cachedInputPallet = t_Pallet;
						if (t_PalletMachine.inputSnapPoint != null)
						{
							t_Pallet.transform.position = t_PalletMachine.inputSnapPoint.position;
						}
						t_PalletMachine.SetPalletLegColliders(t_Pallet, enabled: false);
						t_PalletMachine.RpcSetPalletLegColliders(component3.netId, enabled: false);
						UnityEngine.Debug.Log("[T_PalletMachine] Load continuation - Input palet bulundu, TryAutoStart çağrılacak");
					}
					break;
				}
				case ProcessingPhase.ProcessingStarted:
				{
					if (!(t_Pallet != null))
					{
						break;
					}
					NetworkIdentity component4 = t_Pallet.GetComponent<NetworkIdentity>();
					if (component4 != null)
					{
						t_PalletMachine.Network_inputPalletNetId = component4.netId;
						t_PalletMachine._cachedInputPallet = t_Pallet;
						if (t_PalletMachine.processingSnapPoint != null)
						{
							t_Pallet.transform.position = t_PalletMachine.processingSnapPoint.position;
							float y = Mathf.Round(t_Pallet.transform.eulerAngles.y / 90f) * 90f;
							t_Pallet.transform.rotation = Quaternion.Euler(0f, y, 0f);
						}
						t_PalletMachine.ServerCreateDeliveryPallet();
						t_PalletMachine.ServerTransferItems();
						t_PalletMachine.ServerMoveOutputs();
						UnityEngine.Debug.Log("[T_PalletMachine] Load continuation - ProcessingStarted tamamlandı");
					}
					break;
				}
				case ProcessingPhase.DeliveryCreated:
					if (t_Pallet != null)
					{
						NetworkIdentity component5 = t_Pallet.GetComponent<NetworkIdentity>();
						if (component5 != null)
						{
							t_PalletMachine.Network_inputPalletNetId = component5.netId;
							t_PalletMachine._cachedInputPallet = t_Pallet;
							if (t_PalletMachine.processingSnapPoint != null)
							{
								t_Pallet.transform.position = t_PalletMachine.processingSnapPoint.position;
								float y2 = Mathf.Round(t_Pallet.transform.eulerAngles.y / 90f) * 90f;
								t_Pallet.transform.rotation = Quaternion.Euler(0f, y2, 0f);
							}
						}
					}
					if (t_DeliveryPallet != null)
					{
						t_PalletMachine._currentDeliveryPallet = t_DeliveryPallet;
						if (t_PalletMachine.processingSnapPoint != null)
						{
							t_DeliveryPallet.transform.position = t_PalletMachine.processingSnapPoint.position;
							t_DeliveryPallet.transform.rotation = t_PalletMachine.processingSnapPoint.rotation;
						}
					}
					t_PalletMachine.ServerTransferItems();
					t_PalletMachine.ServerMoveOutputs();
					UnityEngine.Debug.Log("[T_PalletMachine] Load continuation - DeliveryCreated tamamlandı");
					break;
				case ProcessingPhase.MovingToOutputs:
					if (t_Pallet != null)
					{
						NetworkIdentity component = t_Pallet.GetComponent<NetworkIdentity>();
						if (component != null)
						{
							if (t_PalletMachine.output1SnapPoint != null)
							{
								t_Pallet.transform.position = t_PalletMachine.output1SnapPoint.position;
								t_Pallet.transform.rotation = t_PalletMachine.output1SnapPoint.rotation;
							}
							t_PalletMachine.Network_output1PalletNetId = component.netId;
							if (t_PalletMachine.output1Trigger != null)
							{
								t_PalletMachine.output1Trigger.ForceOccupy(component.netId);
							}
							t_PalletMachine.SetPalletLegColliders(t_Pallet, enabled: true);
							t_PalletMachine.RpcSetPalletLegColliders(component.netId, enabled: true);
						}
					}
					if (t_DeliveryPallet != null)
					{
						NetworkIdentity component2 = t_DeliveryPallet.GetComponent<NetworkIdentity>();
						if (component2 != null)
						{
							if (t_PalletMachine.output2SnapPoint != null)
							{
								t_DeliveryPallet.transform.position = t_PalletMachine.output2SnapPoint.position;
								t_DeliveryPallet.transform.rotation = t_PalletMachine.output2SnapPoint.rotation;
							}
							t_PalletMachine.Network_output2PalletNetId = component2.netId;
							if (t_PalletMachine.output2Trigger != null)
							{
								t_PalletMachine.output2Trigger.ForceOccupy(component2.netId);
							}
						}
					}
					t_PalletMachine.Network_inputPalletNetId = 0u;
					t_PalletMachine._cachedInputPallet = null;
					t_PalletMachine._currentDeliveryPallet = null;
					if (t_PalletMachine.inputTrigger != null)
					{
						t_PalletMachine.inputTrigger.ClearCurrentPallet();
					}
					UnityEngine.Debug.Log("[T_PalletMachine] Load continuation - MovingToOutputs tamamlandı");
					break;
				}
				t_PalletMachine._pendingPhase = ProcessingPhase.None;
				t_PalletMachine._pendingInputPalletId = null;
				t_PalletMachine._pendingDeliveryPalletId = null;
				t_PalletMachine._isLoadContinuationInProgress = false;
				t_PalletMachine.UpdateMachineState();
				t_PalletMachine.TryAutoStart();
				return false;
			}
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

	[Header("References")]
	[Tooltip("Giriş trigger'ı")]
	[SerializeField]
	private T_PalletMachineInputTrigger inputTrigger;

	[Tooltip("Çıkış 1 trigger'ı (eski palet)")]
	[SerializeField]
	private T_PalletMachineOutputTrigger output1Trigger;

	[Tooltip("Çıkış 2 trigger'ı (delivery palet)")]
	[SerializeField]
	private T_PalletMachineOutputTrigger output2Trigger;

	[Tooltip("Delivery palet prefab'ı")]
	[SerializeField]
	private GameObject deliveryPalletPrefab;

	[Header("Snap Points")]
	[Tooltip("Giriş paleti hedef noktası")]
	[SerializeField]
	private Transform inputSnapPoint;

	[Tooltip("İşlem sırasında paletin gideceği nokta (içeri çekilme)")]
	[SerializeField]
	private Transform processingSnapPoint;

	[Tooltip("Çıkış 1 (eski palet) hedef noktası")]
	[SerializeField]
	private Transform output1SnapPoint;

	[Tooltip("Çıkış 2 (delivery palet) hedef noktası")]
	[SerializeField]
	private Transform output2SnapPoint;

	[Header("Processing Settings")]
	[Tooltip("İşlem süresi (saniye)")]
	[SerializeField]
	private float processingDuration = 5f;

	[Tooltip("Palet hareket süresi (saniye)")]
	[SerializeField]
	private float palletMoveDuration = 1f;

	[Header("Events")]
	public UnityEvent<PalletMachineState> onStateChanged;

	public UnityEvent onProcessingStarted;

	public UnityEvent onProcessingCompleted;

	public UnityEvent closeUIEvent;

	public UnityEvent<float> onProcessingProgressChanged;

	public UnityEvent<bool> onAutoWorkChanged;

	[Header("Forklift Indicator")]
	[Tooltip("Forklift T_Pallet aldığında ve item delivery request'te gerekli ise açılan indicator")]
	[SerializeField]
	private GameObject forkliftPalletIndicator;

	[SyncVar(hook = "OnMachineStateChanged")]
	private PalletMachineState _machineState;

	[SyncVar(hook = "OnInputPalletChanged")]
	private uint _inputPalletNetId;

	[SyncVar]
	private uint _output1PalletNetId;

	[SyncVar]
	private uint _output2PalletNetId;

	[SyncVar]
	private bool _isProcessing;

	[SyncVar]
	private float _processingStartTime;

	[SyncVar(hook = "OnAutoWorkChanged")]
	private bool _autoWork = true;

	private T_Pallet _cachedInputPallet;

	private T_DeliveryPallet _currentDeliveryPallet;

	private const float OUTPUT_VALIDATION_INTERVAL = 0.1f;

	private float _lastOutputValidationTime;

	private bool _pendingLoadContinuation;

	private ProcessingPhase _pendingPhase;

	private string _pendingInputPalletId;

	private string _pendingDeliveryPalletId;

	private bool _isLoadContinuationInProgress;

	public Action<PalletMachineState, PalletMachineState> _Mirror_SyncVarHookDelegate__machineState;

	public Action<uint, uint> _Mirror_SyncVarHookDelegate__inputPalletNetId;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate__autoWork;

	public static T_PalletMachine Instance { get; private set; }

	public PalletMachineState MachineState => _machineState;

	public uint InputPalletNetId => _inputPalletNetId;

	public bool IsProcessing => _isProcessing;

	public float ProcessingProgress
	{
		get
		{
			if (!_isProcessing || processingDuration <= 0f)
			{
				return 0f;
			}
			return Mathf.Clamp01((Time.time - _processingStartTime) / processingDuration);
		}
	}

	public float RemainingTime
	{
		get
		{
			if (!_isProcessing)
			{
				return 0f;
			}
			float num = Time.time - _processingStartTime;
			return Mathf.Max(0f, processingDuration - num);
		}
	}

	public bool HasInputPallet => _inputPalletNetId != 0;

	public bool IsOutput1Occupied => _output1PalletNetId != 0;

	public bool IsOutput2Occupied => _output2PalletNetId != 0;

	public bool AreOutputsEmpty
	{
		get
		{
			if (!IsOutput1Occupied)
			{
				return !IsOutput2Occupied;
			}
			return false;
		}
	}

	public bool AutoWork => _autoWork;

	public bool CanStartProcessing
	{
		get
		{
			if (!HasInputPallet)
			{
				return false;
			}
			if (_isProcessing)
			{
				return false;
			}
			if (ComputerContractManager.Instance == null)
			{
				return false;
			}
			if (!ComputerContractManager.Instance.HasDeliveryRequest)
			{
				return false;
			}
			if (!IsInputPalletItemInContract())
			{
				return false;
			}
			if (!AreOutputsEmpty)
			{
				return false;
			}
			return true;
		}
	}

	public string SaveID => "pallet-machine";

	public bool IsShared => false;

	public Type SaveType => typeof(PalletMachineSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public PalletMachineState Network_machineState
	{
		get
		{
			return _machineState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _machineState, 1uL, _Mirror_SyncVarHookDelegate__machineState);
		}
	}

	public uint Network_inputPalletNetId
	{
		get
		{
			return _inputPalletNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _inputPalletNetId, 2uL, _Mirror_SyncVarHookDelegate__inputPalletNetId);
		}
	}

	public uint Network_output1PalletNetId
	{
		get
		{
			return _output1PalletNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _output1PalletNetId, 4uL, null);
		}
	}

	public uint Network_output2PalletNetId
	{
		get
		{
			return _output2PalletNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _output2PalletNetId, 8uL, null);
		}
	}

	public bool Network_isProcessing
	{
		get
		{
			return _isProcessing;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isProcessing, 16uL, null);
		}
	}

	public float Network_processingStartTime
	{
		get
		{
			return _processingStartTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _processingStartTime, 32uL, null);
		}
	}

	public bool Network_autoWork
	{
		get
		{
			return _autoWork;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _autoWork, 64uL, _Mirror_SyncVarHookDelegate__autoWork);
		}
	}

	private void Awake()
	{
		Instance = this;
		if (forkliftPalletIndicator != null)
		{
			forkliftPalletIndicator.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public T_Pallet GetInputPallet()
	{
		if (_inputPalletNetId == 0)
		{
			return null;
		}
		if (_cachedInputPallet != null)
		{
			NetworkIdentity component = _cachedInputPallet.GetComponent<NetworkIdentity>();
			if (component != null && component.netId == _inputPalletNetId)
			{
				return _cachedInputPallet;
			}
		}
		if (NetworkServer.spawned.TryGetValue(_inputPalletNetId, out var value))
		{
			_cachedInputPallet = value.GetComponent<T_Pallet>();
			return _cachedInputPallet;
		}
		return null;
	}

	public ActiveContractData? GetCurrentContract()
	{
		if (ComputerContractManager.Instance == null)
		{
			return null;
		}
		return ComputerContractManager.Instance.GetDeliveryRequestedContract();
	}

	public Transform GetInputSnapPoint()
	{
		return inputSnapPoint;
	}

	private void Update()
	{
		if (base.isServer)
		{
			ServerUpdate();
		}
		if (_isProcessing)
		{
			onProcessingProgressChanged?.Invoke(ProcessingProgress);
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.AddListener(OnDeliveryContractChanged);
		}
		StartCoroutine(Co_SubscribeToSaveSystem());
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.AddListener(OnLoadingFinished);
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onDeliveryContractChanged.RemoveListener(OnDeliveryContractChanged);
		}
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.RemoveListener(OnLoadingFinished);
		}
	}

	[Server]
	private void ServerUpdate()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerUpdate()' called when server was not active");
		}
		else if (!_pendingLoadContinuation && !_isLoadContinuationInProgress)
		{
			if (Time.time - _lastOutputValidationTime >= 0.1f)
			{
				_lastOutputValidationTime = Time.time;
				ValidateOutputSlots();
			}
			if (_isProcessing && Time.time - _processingStartTime >= processingDuration)
			{
				ServerCompleteProcessing();
			}
			UpdateMachineState();
		}
	}

	[Server]
	private void ValidateOutputSlots()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ValidateOutputSlots()' called when server was not active");
			return;
		}
		bool flag = false;
		if (_output1PalletNetId != 0 && IsOutputPalletInvalid(_output1PalletNetId))
		{
			UnityEngine.Debug.Log($"[PalletMachine] Output 1 doğrulama: slot temizleniyor - NetId: {_output1PalletNetId}");
			Network_output1PalletNetId = 0u;
			if (output1Trigger != null)
			{
				output1Trigger.ForceClear();
			}
			flag = true;
		}
		if (_output2PalletNetId != 0 && IsOutputPalletInvalid(_output2PalletNetId))
		{
			UnityEngine.Debug.Log($"[PalletMachine] Output 2 doğrulama: slot temizleniyor - NetId: {_output2PalletNetId}");
			Network_output2PalletNetId = 0u;
			if (output2Trigger != null)
			{
				output2Trigger.ForceClear();
			}
			flag = true;
		}
		if (flag)
		{
			UpdateMachineState();
			TryAutoStart();
		}
	}

	private bool IsOutputPalletInvalid(uint palletNetId)
	{
		if (!NetworkServer.spawned.TryGetValue(palletNetId, out var value))
		{
			return true;
		}
		T_Pallet component = value.GetComponent<T_Pallet>();
		if (component != null)
		{
			if (component.IsLifted)
			{
				return true;
			}
			return false;
		}
		T_DeliveryPallet component2 = value.GetComponent<T_DeliveryPallet>();
		if (component2 != null)
		{
			if (component2.IsLifted)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	[Server]
	private void UpdateMachineState()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::UpdateMachineState()' called when server was not active");
			return;
		}
		PalletMachineState machineState = _machineState;
		if (_isProcessing)
		{
			machineState = PalletMachineState.Processing;
		}
		else if (!HasInputPallet)
		{
			machineState = PalletMachineState.Idle;
		}
		else if (!AreOutputsEmpty)
		{
			machineState = PalletMachineState.OutputBlocked;
		}
		else
		{
			ComputerContractManager instance = ComputerContractManager.Instance;
			machineState = (((object)instance == null || !instance.HasDeliveryRequest) ? PalletMachineState.WaitingForContract : PalletMachineState.Ready);
		}
		if (machineState != _machineState)
		{
			Network_machineState = machineState;
		}
	}

	[Server]
	public void ServerOnPalletEnter(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerOnPalletEnter(T_Pallet)' called when server was not active");
		}
		else if (!(pallet == null))
		{
			NetworkIdentity component = pallet.GetComponent<NetworkIdentity>();
			if (!(component == null) && _inputPalletNetId == 0)
			{
				Network_inputPalletNetId = component.netId;
				_cachedInputPallet = pallet;
				Vector3 position = pallet.transform.position;
				RpcSnapInputPallet(component.netId, position);
				UnityEngine.Debug.Log($"[PalletMachine] Palet girdi - NetId: {component.netId}, ItemId: {pallet.PaletItemId}, Count: {pallet.PaletItemCount}");
				SetPalletLegColliders(pallet, enabled: false);
				RpcSetPalletLegColliders(component.netId, enabled: false);
				UpdateMachineState();
				TryAutoStart();
			}
		}
	}

	[Server]
	public void ServerOnPalletExit(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerOnPalletExit(T_Pallet)' called when server was not active");
		}
		else
		{
			if (pallet == null)
			{
				return;
			}
			NetworkIdentity component = pallet.GetComponent<NetworkIdentity>();
			if (!(component == null) && component.netId == _inputPalletNetId)
			{
				if (_isProcessing)
				{
					UnityEngine.Debug.LogWarning("[PalletMachine] İşlem sırasında palet çıkışı engellendi!");
					return;
				}
				Network_inputPalletNetId = 0u;
				_cachedInputPallet = null;
				UnityEngine.Debug.Log("[PalletMachine] Palet çıktı");
			}
		}
	}

	[Server]
	public void ServerOnOutputSlotOccupied(int slotIndex, uint palletNetId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerOnOutputSlotOccupied(System.Int32,System.UInt32)' called when server was not active");
			return;
		}
		switch (slotIndex)
		{
		case 0:
			Network_output1PalletNetId = palletNetId;
			break;
		case 1:
			Network_output2PalletNetId = palletNetId;
			break;
		}
		UnityEngine.Debug.Log($"[PalletMachine] Çıkış slot {slotIndex} doldu - NetId: {palletNetId}");
	}

	[Server]
	public void ServerOnOutputSlotCleared(int slotIndex)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerOnOutputSlotCleared(System.Int32)' called when server was not active");
			return;
		}
		switch (slotIndex)
		{
		case 0:
			Network_output1PalletNetId = 0u;
			break;
		case 1:
			Network_output2PalletNetId = 0u;
			break;
		}
		UnityEngine.Debug.Log($"[PalletMachine] Çıkış slot {slotIndex} boşaldı");
		UpdateMachineState();
		TryAutoStart();
	}

	private void OnDeliveryContractChanged(string contractId)
	{
		UnityEngine.Debug.Log("[PalletMachine] Delivery contract değişti: " + contractId);
		if (base.isServer)
		{
			UpdateMachineState();
			TryAutoStart();
		}
	}

	public void RequestStartProcessing()
	{
		if (base.isServer)
		{
			ServerStartProcessing();
		}
		else
		{
			CmdRequestStartProcessing();
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestStartProcessing(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestStartProcessing__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_PalletMachine::CmdRequestStartProcessing(Mirror.NetworkConnectionToClient)", 1272714984, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void RequestSetAutoWork(bool value)
	{
		if (base.isServer)
		{
			Network_autoWork = value;
		}
		else
		{
			CmdSetAutoWork(value);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdSetAutoWork(bool value)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetAutoWork__Boolean(value);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(value);
		SendCommandInternal("System.Void T_PalletMachine::CmdSetAutoWork(System.Boolean)", 562495568, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStartProcessing(NetworkConnectionToClient requester = null)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerStartProcessing(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (_pendingLoadContinuation || _isLoadContinuationInProgress)
		{
			UnityEngine.Debug.Log("[PalletMachine] Load devam ediyor, normal işlem engellendi");
			return;
		}
		if (!CanStartProcessing)
		{
			string processingBlockReason = GetProcessingBlockReason();
			if (processingBlockReason != null)
			{
				if (requester != null)
				{
					TargetRpcShowWarning(requester, processingBlockReason);
				}
				else
				{
					ShowWarningLocal(processingBlockReason);
				}
			}
			UnityEngine.Debug.LogWarning("[PalletMachine] İşlem başlatılamaz! Sebep: " + processingBlockReason);
			return;
		}
		Network_isProcessing = true;
		Network_processingStartTime = Time.time;
		Network_machineState = PalletMachineState.Processing;
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet != null)
		{
			inputPallet.ServerSetBeingProcessed(value: true);
		}
		ServerCreateDeliveryPallet();
		MoveInputPalletToProcessing();
		UnityEngine.Debug.Log($"[PalletMachine] İşlem başladı - Süre: {processingDuration}s");
		RpcOnProcessingStarted();
	}

	[Server]
	private void TryAutoStart()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::TryAutoStart()' called when server was not active");
		}
		else
		{
			if (_pendingLoadContinuation || _isLoadContinuationInProgress || !_autoWork)
			{
				return;
			}
			if (!CanStartProcessing)
			{
				if (HasInputPallet)
				{
					string processingBlockReason = GetProcessingBlockReason();
					if (processingBlockReason != null)
					{
						RpcShowWarning(processingBlockReason);
						UnityEngine.Debug.Log("[PalletMachine] Otomatik çalışma başlatılamadı: " + processingBlockReason);
					}
				}
			}
			else
			{
				UnityEngine.Debug.Log("[PalletMachine] Otomatik çalışma başlatılıyor");
				ServerStartProcessing();
			}
		}
	}

	[Server]
	private void MoveInputPalletToProcessing()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::MoveInputPalletToProcessing()' called when server was not active");
		}
		else
		{
			if (processingSnapPoint == null)
			{
				return;
			}
			T_Pallet inputPallet = GetInputPallet();
			if (!(inputPallet == null))
			{
				NetworkIdentity component = inputPallet.GetComponent<NetworkIdentity>();
				if (!(component == null))
				{
					Vector3 position = processingSnapPoint.position;
					float y = Mathf.Round(inputPallet.transform.eulerAngles.y / 90f) * 90f;
					Quaternion targetRot = Quaternion.Euler(0f, y, 0f);
					StartCoroutine(SmoothMoveCoroutine(inputPallet.transform, position, targetRot, "[PalletMachine] Palet işlem pozisyonuna taşındı"));
					RpcMovePallet(component.netId, position, targetRot, animateRotation: true);
				}
			}
		}
	}

	[Server]
	private void ServerCompleteProcessing()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerCompleteProcessing()' called when server was not active");
		}
		else if (_isProcessing)
		{
			Network_isProcessing = false;
			ServerTransferItems();
			ServerMoveOutputs();
			UnityEngine.Debug.Log("[PalletMachine] İşlem tamamlandı");
		}
	}

	[Server]
	private void ServerCreateDeliveryPallet()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerCreateDeliveryPallet()' called when server was not active");
			return;
		}
		if (deliveryPalletPrefab == null)
		{
			UnityEngine.Debug.LogError("[PalletMachine] Delivery palet prefab'ı atanmamış!");
			return;
		}
		ActiveContractData? currentContract = GetCurrentContract();
		if (!currentContract.HasValue)
		{
			UnityEngine.Debug.LogError("[PalletMachine] Aktif contract yok!");
			return;
		}
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet == null || inputPallet.IsEmpty)
		{
			UnityEngine.Debug.LogWarning("[PalletMachine] Giriş paleti boş, delivery palet oluşturulmuyor");
			return;
		}
		string paletItemId = inputPallet.PaletItemId;
		ActiveContractData value = currentContract.Value;
		int num = -1;
		for (int i = 0; i < value.materialIds.Length; i++)
		{
			if (value.materialIds[i] == paletItemId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			UnityEngine.Debug.Log("[PalletMachine] Giriş paletindeki item (" + paletItemId + ") contract'ta yok, delivery palet oluşturulmuyor");
			return;
		}
		int num2 = value.materialCounts[num];
		int num3 = ((T_DeliveryZone.Instance != null) ? T_DeliveryZone.Instance.GetItemCount(paletItemId) : 0);
		int num4 = num2 - num3;
		if (num4 <= 0)
		{
			UnityEngine.Debug.Log("[PalletMachine] Material zaten tamamlanmış: " + paletItemId);
			return;
		}
		Vector3 position = ((processingSnapPoint != null) ? processingSnapPoint.position : base.transform.position);
		Quaternion rotation = ((processingSnapPoint != null) ? processingSnapPoint.rotation : base.transform.rotation);
		GameObject gameObject = UnityEngine.Object.Instantiate(deliveryPalletPrefab, position, rotation);
		NetworkServer.Spawn(gameObject);
		_currentDeliveryPallet = gameObject.GetComponent<T_DeliveryPallet>();
		if (_currentDeliveryPallet != null)
		{
			string[] itemIds = new string[1] { paletItemId };
			int[] maxCounts = new int[1] { num4 };
			_currentDeliveryPallet.ServerInitialize(value.activeId, itemIds, maxCounts);
			UnityEngine.Debug.Log($"[PalletMachine] Delivery palet oluşturuldu - Item: {paletItemId}, Max: {num4}");
		}
	}

	[Server]
	private void ServerTransferItems()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerTransferItems()' called when server was not active");
			return;
		}
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet == null)
		{
			UnityEngine.Debug.LogWarning("[PalletMachine] Giriş paleti bulunamadı!");
			return;
		}
		if (_currentDeliveryPallet == null)
		{
			UnityEngine.Debug.Log("[PalletMachine] Delivery palet yok, transfer yapılmıyor");
			return;
		}
		string paletItemId = inputPallet.PaletItemId;
		int paletItemCount = inputPallet.PaletItemCount;
		if (string.IsNullOrEmpty(paletItemId) || paletItemCount <= 0)
		{
			UnityEngine.Debug.Log("[PalletMachine] Giriş paleti boş");
			return;
		}
		int num = Mathf.Min(paletItemCount, _currentDeliveryPallet.GetRemainingCapacity(paletItemId));
		if (num <= 0)
		{
			UnityEngine.Debug.Log("[PalletMachine] Transfer yapılacak miktar yok");
			return;
		}
		int num2 = _currentDeliveryPallet.ServerAddItem(paletItemId, num);
		if (num2 > 0)
		{
			inputPallet.ServerRemoveItems(num2);
			UnityEngine.Debug.Log($"[PalletMachine] Transfer: {paletItemId} x{num2} ({paletItemCount} -> {inputPallet.PaletItemCount})");
		}
	}

	[Server]
	private void ServerMoveOutputs()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::ServerMoveOutputs()' called when server was not active");
			return;
		}
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet != null)
		{
			inputPallet.ServerSetBeingProcessed(value: false);
		}
		if (inputPallet != null)
		{
			if (inputPallet.IsEmpty)
			{
				SetPalletLegColliders(inputPallet, enabled: true);
				NetworkIdentity component = inputPallet.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					RpcSetPalletLegColliders(component.netId, enabled: true);
				}
				NetworkServer.Destroy(inputPallet.gameObject);
				UnityEngine.Debug.Log("[PalletMachine] Boş input palet destroy edildi");
			}
			else
			{
				MoveToOutput1(inputPallet);
				UnityEngine.Debug.Log("[PalletMachine] Eski palet çıkış 1'e taşındı");
			}
		}
		if (inputTrigger != null)
		{
			inputTrigger.ClearCurrentPallet();
		}
		Network_inputPalletNetId = 0u;
		_cachedInputPallet = null;
		if (_currentDeliveryPallet != null)
		{
			MoveToOutput2(_currentDeliveryPallet);
		}
		_currentDeliveryPallet = null;
	}

	[Server]
	private void MoveToOutput1(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::MoveToOutput1(T_Pallet)' called when server was not active");
		}
		else
		{
			if (pallet == null)
			{
				return;
			}
			Vector3 targetPos;
			Quaternion quaternion;
			if (output1SnapPoint != null)
			{
				targetPos = output1SnapPoint.position;
				quaternion = output1SnapPoint.rotation;
			}
			else
			{
				if (!(output1Trigger != null))
				{
					return;
				}
				targetPos = output1Trigger.OutputWorldPosition;
				quaternion = output1Trigger.OutputWorldRotation;
			}
			NetworkIdentity component = pallet.GetComponent<NetworkIdentity>();
			if (component != null)
			{
				Network_output1PalletNetId = component.netId;
				if (output1Trigger != null)
				{
					output1Trigger.ForceOccupy(component.netId);
				}
				pallet.transform.rotation = quaternion;
				StartCoroutine(SmoothMovePositionOnlyCoroutine(pallet.transform, targetPos, "[PalletMachine] Palet çıkış 1'e taşındı"));
				SetPalletLegColliders(pallet, enabled: true);
				RpcSetPalletLegColliders(component.netId, enabled: true);
				RpcMovePallet(component.netId, targetPos, quaternion, animateRotation: false);
			}
		}
	}

	[Server]
	private void MoveToOutput2(T_DeliveryPallet deliveryPallet)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::MoveToOutput2(T_DeliveryPallet)' called when server was not active");
		}
		else
		{
			if (deliveryPallet == null)
			{
				return;
			}
			Vector3 targetPos;
			Quaternion quaternion;
			if (output2SnapPoint != null)
			{
				targetPos = output2SnapPoint.position;
				quaternion = output2SnapPoint.rotation;
			}
			else
			{
				if (!(output2Trigger != null))
				{
					return;
				}
				targetPos = output2Trigger.OutputWorldPosition;
				quaternion = output2Trigger.OutputWorldRotation;
			}
			NetworkIdentity component = deliveryPallet.GetComponent<NetworkIdentity>();
			if (component != null)
			{
				Network_output2PalletNetId = component.netId;
				if (output2Trigger != null)
				{
					output2Trigger.ForceOccupy(component.netId);
				}
				deliveryPallet.transform.rotation = quaternion;
				StartCoroutine(SmoothMovePositionOnlyCoroutine(deliveryPallet.transform, targetPos, "[PalletMachine] Delivery palet çıkış 2'ye taşındı"));
				RpcMovePallet(component.netId, targetPos, quaternion, animateRotation: false);
			}
		}
	}

	private IEnumerator SmoothMoveCoroutine(Transform target, Vector3 targetPos, Quaternion targetRot, string logMessage)
	{
		if (target == null)
		{
			yield break;
		}
		Vector3 startPos = target.position;
		Quaternion startRot = target.rotation;
		float elapsed = 0f;
		float duration = ((palletMoveDuration > 0f) ? palletMoveDuration : 1f);
		while (elapsed < duration)
		{
			if (target == null)
			{
				yield break;
			}
			elapsed += Time.deltaTime;
			float t = Mathf.Clamp01(elapsed / duration);
			target.position = Vector3.Lerp(startPos, targetPos, t);
			target.rotation = Quaternion.Slerp(startRot, targetRot, t);
			yield return null;
		}
		if (target != null)
		{
			target.position = targetPos;
			target.rotation = targetRot;
		}
		if (!string.IsNullOrEmpty(logMessage))
		{
			UnityEngine.Debug.Log(logMessage);
		}
	}

	private IEnumerator SmoothMovePositionOnlyCoroutine(Transform target, Vector3 targetPos, string logMessage)
	{
		if (target == null)
		{
			yield break;
		}
		Vector3 startPos = target.position;
		float elapsed = 0f;
		float duration = ((palletMoveDuration > 0f) ? palletMoveDuration : 1f);
		while (elapsed < duration)
		{
			if (target == null)
			{
				yield break;
			}
			elapsed += Time.deltaTime;
			float t = Mathf.Clamp01(elapsed / duration);
			target.position = Vector3.Lerp(startPos, targetPos, t);
			yield return null;
		}
		if (target != null)
		{
			target.position = targetPos;
		}
		if (!string.IsNullOrEmpty(logMessage))
		{
			UnityEngine.Debug.Log(logMessage);
		}
		RpcOnProcessingCompleted();
	}

	[ClientRpc]
	private void RpcSnapInputPallet(uint palletNetId, Vector3 snapPos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(palletNetId);
		writer.WriteVector3(snapPos);
		SendRPCInternal("System.Void T_PalletMachine::RpcSnapInputPallet(System.UInt32,UnityEngine.Vector3)", -1305214443, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnProcessingStarted()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_PalletMachine::RpcOnProcessingStarted()", 1834393521, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcMovePallet(uint palletNetId, Vector3 targetPos, Quaternion targetRot, bool animateRotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(palletNetId);
		writer.WriteVector3(targetPos);
		writer.WriteQuaternion(targetRot);
		writer.WriteBool(animateRotation);
		SendRPCInternal("System.Void T_PalletMachine::RpcMovePallet(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", -2071903170, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnProcessingCompleted()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_PalletMachine::RpcOnProcessingCompleted()", -316994139, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcShowWarning(NetworkConnection conn, string localizationKey)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(localizationKey);
		SendTargetRPCInternal(conn, "System.Void T_PalletMachine::TargetRpcShowWarning(Mirror.NetworkConnection,System.String)", -1955035767, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShowWarning(string localizationKey)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(localizationKey);
		SendRPCInternal("System.Void T_PalletMachine::RpcShowWarning(System.String)", 2084144581, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetPalletLegColliders(uint palletNetId, bool enabled)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(palletNetId);
		writer.WriteBool(enabled);
		SendRPCInternal("System.Void T_PalletMachine::RpcSetPalletLegColliders(System.UInt32,System.Boolean)", -1690130628, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SetPalletLegColliders(T_Pallet pallet, bool enabled)
	{
		if (!(pallet == null))
		{
			pallet.SetLegCollidersEnabled(enabled);
		}
	}

	private bool IsInputPalletItemInContract()
	{
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet == null || inputPallet.IsEmpty)
		{
			return false;
		}
		ActiveContractData? currentContract = GetCurrentContract();
		if (!currentContract.HasValue)
		{
			return false;
		}
		string paletItemId = inputPallet.PaletItemId;
		ActiveContractData value = currentContract.Value;
		for (int i = 0; i < value.materialIds.Length; i++)
		{
			if (value.materialIds[i] == paletItemId)
			{
				int num = value.materialCounts[i];
				int num2 = ((T_DeliveryZone.Instance != null) ? T_DeliveryZone.Instance.GetItemCount(paletItemId) : 0);
				bool flag = num - num2 > 0;
				UnityEngine.Debug.Log($"[PalletMachine] IsInputPalletItemInContract - Item: {paletItemId}, Required: {num}, ZoneDelivered: {num2}, NeedsMore: {flag}");
				return flag;
			}
		}
		UnityEngine.Debug.Log("[PalletMachine] IsInputPalletItemInContract - Item: " + inputPallet.PaletItemId + " contract'ta bulunamadı!");
		return false;
	}

	private bool IsInputPalletItemAlreadyFulfilled()
	{
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet == null || inputPallet.IsEmpty)
		{
			return false;
		}
		ActiveContractData? currentContract = GetCurrentContract();
		if (!currentContract.HasValue)
		{
			return false;
		}
		string paletItemId = inputPallet.PaletItemId;
		ActiveContractData value = currentContract.Value;
		for (int i = 0; i < value.materialIds.Length; i++)
		{
			if (value.materialIds[i] == paletItemId)
			{
				int num = value.materialCounts[i];
				return ((T_DeliveryZone.Instance != null) ? T_DeliveryZone.Instance.GetItemCount(paletItemId) : 0) >= num;
			}
		}
		return false;
	}

	private string GetProcessingBlockReason()
	{
		if (!HasInputPallet)
		{
			return "Notification_PalletMachine_NoPallet";
		}
		if (_isProcessing)
		{
			return "Notification_PalletMachine_AlreadyProcessing";
		}
		if (ComputerContractManager.Instance == null || !ComputerContractManager.Instance.HasDeliveryRequest)
		{
			return "Notification_PalletMachine_NoContract";
		}
		if (IsInputPalletItemAlreadyFulfilled())
		{
			return "Notification_PalletMachine_ItemAlreadyFulfilled";
		}
		if (!IsInputPalletItemInContract())
		{
			return "Notification_PalletMachine_ItemNotInContract";
		}
		if (!AreOutputsEmpty)
		{
			return "Notification_PalletMachine_OutputBlocked";
		}
		return null;
	}

	private void ShowWarningLocal(string localizationKey)
	{
		if (!string.IsNullOrEmpty(localizationKey) && !(GameManager.Instance == null) && !(GameManager.Instance.notificationManager == null))
		{
			string translation = LocalizationManager.GetTranslation(localizationKey);
			GameManager.Instance.notificationManager.ShowNotification(translation);
		}
	}

	private void OnMachineStateChanged(PalletMachineState oldValue, PalletMachineState newValue)
	{
		UnityEngine.Debug.Log($"[PalletMachine] Durum değişti: {oldValue} -> {newValue}");
		onStateChanged?.Invoke(newValue);
	}

	private void OnInputPalletChanged(uint oldValue, uint newValue)
	{
		UnityEngine.Debug.Log($"[PalletMachine] Giriş paleti değişti: {oldValue} -> {newValue}");
		_cachedInputPallet = null;
		onStateChanged?.Invoke(_machineState);
	}

	private void OnAutoWorkChanged(bool oldValue, bool newValue)
	{
		UnityEngine.Debug.Log($"[PalletMachine] Auto work değişti: {oldValue} -> {newValue}");
		onAutoWorkChanged?.Invoke(newValue);
	}

	public void ShowForkliftIndicator()
	{
		if (forkliftPalletIndicator != null)
		{
			forkliftPalletIndicator.SetActive(value: true);
		}
	}

	public void HideForkliftIndicator()
	{
		if (forkliftPalletIndicator != null)
		{
			forkliftPalletIndicator.SetActive(value: false);
		}
	}

	public bool IsItemNeededForDelivery(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return false;
		}
		if (ComputerContractManager.Instance == null)
		{
			return false;
		}
		if (!ComputerContractManager.Instance.HasDeliveryRequest)
		{
			return false;
		}
		ActiveContractData? deliveryRequestedContract = ComputerContractManager.Instance.GetDeliveryRequestedContract();
		if (!deliveryRequestedContract.HasValue || !deliveryRequestedContract.Value.IsActive)
		{
			return false;
		}
		for (int i = 0; i < deliveryRequestedContract.Value.materialIds.Length; i++)
		{
			if (deliveryRequestedContract.Value.materialIds[i] == itemId)
			{
				int num = deliveryRequestedContract.Value.materialCounts[i];
				int num2 = deliveryRequestedContract.Value.deliveredCounts[i];
				int num3 = ((T_DeliveryZone.Instance != null) ? T_DeliveryZone.Instance.GetItemCount(itemId) : 0);
				return num2 + num3 < num;
			}
		}
		return false;
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		ProcessingPhase processingPhase = ProcessingPhase.None;
		string text = null;
		string text2 = null;
		T_Pallet inputPallet = GetInputPallet();
		if (inputPallet != null && inputPallet.buildingObject != null)
		{
			text = inputPallet.buildingObject.UniqueBuildingId;
		}
		if (_currentDeliveryPallet != null)
		{
			text2 = _currentDeliveryPallet.UniqueId;
		}
		if (_isProcessing)
		{
			processingPhase = ((_currentDeliveryPallet == null) ? ProcessingPhase.ProcessingStarted : ProcessingPhase.DeliveryCreated);
		}
		else if (_currentDeliveryPallet != null || (_output1PalletNetId != 0 && _machineState == PalletMachineState.OutputReady))
		{
			processingPhase = ProcessingPhase.MovingToOutputs;
		}
		else if (inputPallet != null)
		{
			processingPhase = ProcessingPhase.None;
		}
		PalletMachineSaveData result = new PalletMachineSaveData
		{
			inputPalletId = text,
			deliveryPalletId = text2,
			phase = processingPhase,
			autoWork = _autoWork
		};
		UnityEngine.Debug.Log(string.Format("[T_PalletMachine] Save - Phase: {0}, InputPallet: {1}, DeliveryPallet: {2}, AutoWork: {3}", processingPhase, text ?? "null", text2 ?? "null", _autoWork));
		return result;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is PalletMachineSaveData palletMachineSaveData))
		{
			UnityEngine.Debug.LogWarning("[T_PalletMachine] OnLoad - Invalid data type");
			return Task.CompletedTask;
		}
		Network_autoWork = palletMachineSaveData.autoWork;
		if (palletMachineSaveData.phase != ProcessingPhase.None)
		{
			_pendingLoadContinuation = true;
			_pendingPhase = palletMachineSaveData.phase;
			_pendingInputPalletId = palletMachineSaveData.inputPalletId;
			_pendingDeliveryPalletId = palletMachineSaveData.deliveryPalletId;
			UnityEngine.Debug.Log($"[T_PalletMachine] OnLoad - Pending continuation: Phase={palletMachineSaveData.phase}, InputPallet={palletMachineSaveData.inputPalletId}, DeliveryPallet={palletMachineSaveData.deliveryPalletId}");
		}
		else if (!string.IsNullOrEmpty(palletMachineSaveData.inputPalletId) && palletMachineSaveData.autoWork)
		{
			_pendingLoadContinuation = true;
			_pendingPhase = ProcessingPhase.None;
			_pendingInputPalletId = palletMachineSaveData.inputPalletId;
			_pendingDeliveryPalletId = null;
			UnityEngine.Debug.Log($"[T_PalletMachine] OnLoad - AutoStart pending: InputPallet={palletMachineSaveData.inputPalletId}, AutoWork={palletMachineSaveData.autoWork}");
		}
		else
		{
			UnityEngine.Debug.Log($"[T_PalletMachine] OnLoad - No pending phase, AutoWork={palletMachineSaveData.autoWork}");
		}
		return Task.CompletedTask;
	}

	private IEnumerator Co_SubscribeToSaveSystem()
	{
		yield return null;
		SaveLoadManager.Subscribe(this, 60);
		UnityEngine.Debug.Log("[T_PalletMachine] Save sistemine kaydedildi");
	}

	[Server]
	private void OnLoadingFinished(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_PalletMachine::OnLoadingFinished(LoadingType)' called when server was not active");
		}
		else if (_pendingLoadContinuation)
		{
			_pendingLoadContinuation = false;
			UnityEngine.Debug.Log($"[T_PalletMachine] OnLoadingFinished - Phase: {_pendingPhase}");
			StartCoroutine(Co_ContinueAfterLoad());
		}
	}

	[IteratorStateMachine(typeof(_003CCo_ContinueAfterLoad_003Ed__123))]
	[Server]
	private IEnumerator Co_ContinueAfterLoad()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_PalletMachine::Co_ContinueAfterLoad()' called when server was not active");
			return null;
		}
		return new _003CCo_ContinueAfterLoad_003Ed__123(0)
		{
			_003C_003E4__this = this
		};
	}

	private T_Pallet FindPalletByUniqueId(string uniqueId)
	{
		if (string.IsNullOrEmpty(uniqueId))
		{
			return null;
		}
		foreach (KeyValuePair<uint, NetworkIdentity> item in NetworkServer.spawned)
		{
			T_Pallet component = item.Value.GetComponent<T_Pallet>();
			if (component != null && component.buildingObject != null && component.buildingObject.UniqueBuildingId == uniqueId)
			{
				return component;
			}
		}
		return null;
	}

	public T_PalletMachine()
	{
		_Mirror_SyncVarHookDelegate__machineState = OnMachineStateChanged;
		_Mirror_SyncVarHookDelegate__inputPalletNetId = OnInputPalletChanged;
		_Mirror_SyncVarHookDelegate__autoWork = OnAutoWorkChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestStartProcessing__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerStartProcessing(sender);
	}

	protected static void InvokeUserCode_CmdRequestStartProcessing__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestStartProcessing called on client.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_CmdRequestStartProcessing__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdSetAutoWork__Boolean(bool value)
	{
		Network_autoWork = value;
	}

	protected static void InvokeUserCode_CmdSetAutoWork__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetAutoWork called on client.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_CmdSetAutoWork__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcSnapInputPallet__UInt32__Vector3(uint palletNetId, Vector3 snapPos)
	{
		if (!base.isServer && NetworkClient.spawned.TryGetValue(palletNetId, out var value))
		{
			value.transform.position = snapPos;
		}
	}

	protected static void InvokeUserCode_RpcSnapInputPallet__UInt32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSnapInputPallet called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcSnapInputPallet__UInt32__Vector3(reader.ReadVarUInt(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcOnProcessingStarted()
	{
		onProcessingStarted?.Invoke();
	}

	protected static void InvokeUserCode_RpcOnProcessingStarted(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnProcessingStarted called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcOnProcessingStarted();
		}
	}

	protected void UserCode_RpcMovePallet__UInt32__Vector3__Quaternion__Boolean(uint palletNetId, Vector3 targetPos, Quaternion targetRot, bool animateRotation)
	{
		if (base.isServer)
		{
			return;
		}
		if (!NetworkClient.spawned.TryGetValue(palletNetId, out var value))
		{
			UnityEngine.Debug.LogWarning($"[PalletMachine] Client: Palet bulunamadı - NetId: {palletNetId}");
			return;
		}
		Transform transform = value.transform;
		if (animateRotation)
		{
			StartCoroutine(SmoothMoveCoroutine(transform, targetPos, targetRot, ""));
			return;
		}
		transform.rotation = targetRot;
		StartCoroutine(SmoothMovePositionOnlyCoroutine(transform, targetPos, ""));
	}

	protected static void InvokeUserCode_RpcMovePallet__UInt32__Vector3__Quaternion__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcMovePallet called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcMovePallet__UInt32__Vector3__Quaternion__Boolean(reader.ReadVarUInt(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcOnProcessingCompleted()
	{
		onProcessingCompleted?.Invoke();
	}

	protected static void InvokeUserCode_RpcOnProcessingCompleted(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnProcessingCompleted called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcOnProcessingCompleted();
		}
	}

	protected void UserCode_TargetRpcShowWarning__NetworkConnection__String(NetworkConnection conn, string localizationKey)
	{
		ShowWarningLocal(localizationKey);
	}

	protected static void InvokeUserCode_TargetRpcShowWarning__NetworkConnection__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcShowWarning called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_TargetRpcShowWarning__NetworkConnection__String(null, reader.ReadString());
		}
	}

	protected void UserCode_RpcShowWarning__String(string localizationKey)
	{
		ShowWarningLocal(localizationKey);
	}

	protected static void InvokeUserCode_RpcShowWarning__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcShowWarning called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcShowWarning__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcSetPalletLegColliders__UInt32__Boolean(uint palletNetId, bool enabled)
	{
		if (!base.isServer && NetworkClient.spawned.TryGetValue(palletNetId, out var value))
		{
			T_Pallet component = value.GetComponent<T_Pallet>();
			if (component != null)
			{
				component.SetLegCollidersEnabled(enabled);
			}
		}
	}

	protected static void InvokeUserCode_RpcSetPalletLegColliders__UInt32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSetPalletLegColliders called on server.");
		}
		else
		{
			((T_PalletMachine)obj).UserCode_RpcSetPalletLegColliders__UInt32__Boolean(reader.ReadVarUInt(), reader.ReadBool());
		}
	}

	static T_PalletMachine()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletMachine), "System.Void T_PalletMachine::CmdRequestStartProcessing(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestStartProcessing__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletMachine), "System.Void T_PalletMachine::CmdSetAutoWork(System.Boolean)", InvokeUserCode_CmdSetAutoWork__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcSnapInputPallet(System.UInt32,UnityEngine.Vector3)", InvokeUserCode_RpcSnapInputPallet__UInt32__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcOnProcessingStarted()", InvokeUserCode_RpcOnProcessingStarted);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcMovePallet(System.UInt32,UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean)", InvokeUserCode_RpcMovePallet__UInt32__Vector3__Quaternion__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcOnProcessingCompleted()", InvokeUserCode_RpcOnProcessingCompleted);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcShowWarning(System.String)", InvokeUserCode_RpcShowWarning__String);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::RpcSetPalletLegColliders(System.UInt32,System.Boolean)", InvokeUserCode_RpcSetPalletLegColliders__UInt32__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletMachine), "System.Void T_PalletMachine::TargetRpcShowWarning(Mirror.NetworkConnection,System.String)", InvokeUserCode_TargetRpcShowWarning__NetworkConnection__String);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_PalletMachineState(writer, _machineState);
			writer.WriteVarUInt(_inputPalletNetId);
			writer.WriteVarUInt(_output1PalletNetId);
			writer.WriteVarUInt(_output2PalletNetId);
			writer.WriteBool(_isProcessing);
			writer.WriteFloat(_processingStartTime);
			writer.WriteBool(_autoWork);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_PalletMachineState(writer, _machineState);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarUInt(_inputPalletNetId);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarUInt(_output1PalletNetId);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarUInt(_output2PalletNetId);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteBool(_isProcessing);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteFloat(_processingStartTime);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteBool(_autoWork);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _machineState, _Mirror_SyncVarHookDelegate__machineState, GeneratedNetworkCode._Read_PalletMachineState(reader));
			GeneratedSyncVarDeserialize(ref _inputPalletNetId, _Mirror_SyncVarHookDelegate__inputPalletNetId, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref _output1PalletNetId, null, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref _output2PalletNetId, null, reader.ReadVarUInt());
			GeneratedSyncVarDeserialize(ref _isProcessing, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _processingStartTime, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _autoWork, _Mirror_SyncVarHookDelegate__autoWork, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _machineState, _Mirror_SyncVarHookDelegate__machineState, GeneratedNetworkCode._Read_PalletMachineState(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _inputPalletNetId, _Mirror_SyncVarHookDelegate__inputPalletNetId, reader.ReadVarUInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _output1PalletNetId, null, reader.ReadVarUInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _output2PalletNetId, null, reader.ReadVarUInt());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isProcessing, null, reader.ReadBool());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _processingStartTime, null, reader.ReadFloat());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _autoWork, _Mirror_SyncVarHookDelegate__autoWork, reader.ReadBool());
		}
	}
}
