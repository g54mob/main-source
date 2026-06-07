using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_SortingOutput : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class SortingOutputSaveData
	{
		public bool isRunning;

		public string selectedItemId;
	}

	[CompilerGenerated]
	private sealed class _003CCo_RestoreOutputState_003Ed__119 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_SortingOutput _003C_003E4__this;

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
		public _003CCo_RestoreOutputState_003Ed__119(int _003C_003E1__state)
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
			T_SortingOutput t_SortingOutput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				t_SortingOutput.DebugLog("Co_RestoreOutputState - restoring output state after load");
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				if (t_SortingOutput.storageManager == null && GameManager.Instance != null)
				{
					t_SortingOutput.storageManager = GameManager.Instance.storageManager;
				}
				t_SortingOutput.DebugLog("Co_RestoreOutputState - storageManager: " + ((t_SortingOutput.storageManager != null) ? "found" : "NULL") + ", selectedItemId: " + t_SortingOutput.selectedItemId);
				t_SortingOutput.NetworkisOutputRunning = true;
				t_SortingOutput.outputCoroutine = t_SortingOutput.StartCoroutine(t_SortingOutput.OutputCycleCoroutine());
				t_SortingOutput.UpdateOutputEventState();
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
	private sealed class _003COutputCycleCoroutine_003Ed__97 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_SortingOutput _003C_003E4__this;

		private T_ItemSO _003Citem_003E5__2;

		private float _003Ct_003E5__3;

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
		public _003COutputCycleCoroutine_003Ed__97(int _003C_003E1__state)
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
			T_SortingOutput t_SortingOutput = _003C_003E4__this;
			int itemCount;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 1:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 2:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 3:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 4:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 5:
				_003C_003E1__state = -1;
				goto IL_01da;
			case 6:
				_003C_003E1__state = -1;
				goto IL_033e;
			case 7:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 8;
				return true;
			case 8:
				_003C_003E1__state = -1;
				t_SortingOutput.DebugLog("OutputCycle - spawning item: " + _003Citem_003E5__2.Name);
				t_SortingOutput.SpawnSingleItem(_003Citem_003E5__2);
				t_SortingOutput.OnItemSpawned?.Invoke(_003Citem_003E5__2, 1);
				t_SortingOutput.UpdateOutputUIForItem(_003Citem_003E5__2);
				_003C_003E2__current = null;
				_003C_003E1__state = 9;
				return true;
			case 9:
				{
					_003C_003E1__state = -1;
					t_SortingOutput.UpdateSelectedItemCount();
					t_SortingOutput.UpdateOutputEventState();
					t_SortingOutput.NetworkoutputProgress = 0f;
					_003Citem_003E5__2 = null;
					goto IL_033e;
				}
				IL_01da:
				if (_003Ct_003E5__3 < t_SortingOutput.outputSpawnDelay && t_SortingOutput.isOutputRunning)
				{
					_003Ct_003E5__3 += Time.deltaTime;
					t_SortingOutput.NetworkoutputProgress = Mathf.Clamp01(_003Ct_003E5__3 / t_SortingOutput.outputSpawnDelay);
					_003C_003E2__current = null;
					_003C_003E1__state = 5;
					return true;
				}
				if (!t_SortingOutput.isOutputRunning)
				{
					t_SortingOutput.DebugLog("OutputCycle - interrupted during progress, item: " + _003Citem_003E5__2.Name);
					break;
				}
				if (t_SortingOutput.storageManager.GetItemCount(_003Citem_003E5__2) <= 0)
				{
					t_SortingOutput.DebugLog("OutputCycle - item no longer in storage at 100%, waiting. item: " + _003Citem_003E5__2.Name);
					t_SortingOutput.NetworkoutputProgress = 0f;
					t_SortingOutput.UpdateOutputEventState();
					_003C_003E2__current = new WaitForSeconds(0.5f);
					_003C_003E1__state = 6;
					return true;
				}
				t_SortingOutput.storageManager.RequestRemoveItem(_003Citem_003E5__2, 1);
				_003C_003E2__current = null;
				_003C_003E1__state = 7;
				return true;
				IL_033e:
				if (!t_SortingOutput.isOutputRunning)
				{
					break;
				}
				if (string.IsNullOrEmpty(t_SortingOutput.selectedItemId))
				{
					_003C_003E2__current = new WaitForSeconds(0.1f);
					_003C_003E1__state = 1;
					return true;
				}
				_003Citem_003E5__2 = t_SortingOutput.ResolveItem(t_SortingOutput.selectedItemId);
				if (_003Citem_003E5__2 == null)
				{
					_003C_003E2__current = new WaitForSeconds(0.1f);
					_003C_003E1__state = 2;
					return true;
				}
				if (t_SortingOutput.storageManager == null && GameManager.Instance != null)
				{
					t_SortingOutput.storageManager = GameManager.Instance.storageManager;
				}
				if (t_SortingOutput.storageManager == null)
				{
					UnityEngine.Debug.LogError("T_SortingOutput: StorageManager null (OutputCycleCoroutine).");
					_003C_003E2__current = new WaitForSeconds(0.1f);
					_003C_003E1__state = 3;
					return true;
				}
				itemCount = t_SortingOutput.storageManager.GetItemCount(_003Citem_003E5__2);
				if (itemCount <= 0)
				{
					_003C_003E2__current = new WaitForSeconds(0.5f);
					_003C_003E1__state = 4;
					return true;
				}
				t_SortingOutput.DebugLog($"OutputCycle - starting progress for item: {_003Citem_003E5__2.Name}, available: {itemCount}");
				t_SortingOutput.currentProcessingItem = null;
				_003Ct_003E5__3 = 0f;
				goto IL_01da;
			}
			t_SortingOutput.outputCoroutine = null;
			t_SortingOutput.NetworkoutputProgress = 0f;
			return false;
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
	private sealed class _003CUpdateEventStateAfterStorageChange_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_SortingOutput _003C_003E4__this;

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
		public _003CUpdateEventStateAfterStorageChange_003Ed__48(int _003C_003E1__state)
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
			T_SortingOutput t_SortingOutput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				t_SortingOutput.UpdateOutputEventState();
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
	private sealed class _003CUpdateItemCountAfterFrame_003Ed__102 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_ItemSO item;

		public T_SortingOutput _003C_003E4__this;

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
		public _003CUpdateItemCountAfterFrame_003Ed__102(int _003C_003E1__state)
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
			T_SortingOutput t_SortingOutput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (item != null && item.GetItemID() == t_SortingOutput.selectedItemId)
				{
					t_SortingOutput.UpdateSelectedItemCount();
				}
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
	private sealed class _003CUpdateItemCountAfterStorageChange_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_SortingOutput _003C_003E4__this;

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
		public _003CUpdateItemCountAfterStorageChange_003Ed__49(int _003C_003E1__state)
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
			T_SortingOutput t_SortingOutput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				t_SortingOutput.UpdateSelectedItemCount();
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

	private BuildingObject _buildingObject;

	[Header("Save Settings")]
	[SerializeField]
	private bool useManualSaveId = true;

	[SerializeField]
	private string manualSaveId = "sorting-output-01";

	[Header("Output Settings")]
	[SerializeField]
	private bool hasOutputOperation = true;

	[Header("Spawn Settings")]
	[SerializeField]
	private Transform itemSpawnPoint;

	[Header("Sack Spawn")]
	[SerializeField]
	private GameObject sackPrefab;

	[SerializeField]
	private Transform sackSpawnPoint;

	[Header("Output Cycle")]
	[SerializeField]
	[Min(0.05f)]
	private float outputSpawnDelay = 0.5f;

	[Header("References")]
	[SerializeField]
	private StorageUI storageUI;

	[SerializeField]
	private StorageManager storageManager;

	[Header("Events")]
	public UnityEvent<T_ItemSO, int> OnItemSpawned;

	public UnityEvent<T_Sack> OnSackSpawned;

	public UnityEvent OnUIClosed;

	public UnityEvent OnInteractWithoutSack;

	[Header("State Events")]
	public UnityEvent OnOutputActive;

	public UnityEvent OnOutputDeactive;

	public UnityEvent OnOutputWorking;

	public UnityEvent OnOutputStopped;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	private Coroutine outputCoroutine;

	private T_ItemSO currentProcessingItem;

	[SyncVar(hook = "OnOutputRunningChanged")]
	private bool isOutputRunning;

	[SyncVar(hook = "OnOutputProgressChanged")]
	private float outputProgress;

	[SyncVar(hook = "OnSelectedItemChanged")]
	private string selectedItemId;

	[SyncVar(hook = "OnSelectedItemCountChanged")]
	private int selectedItemCount;

	private bool lastOutputActiveState;

	private bool lastOutputDeactiveState;

	private bool lastOutputWorkingState;

	private bool lastOutputStoppedState;

	private bool pendingRestoreAfterLoad;

	private T_Sack currentTransferSack;

	private T_ItemSO currentTransferItem;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isOutputRunning;

	public Action<float, float> _Mirror_SyncVarHookDelegate_outputProgress;

	public Action<string, string> _Mirror_SyncVarHookDelegate_selectedItemId;

	public Action<int, int> _Mirror_SyncVarHookDelegate_selectedItemCount;

	private BuildingObject BuildingObj
	{
		get
		{
			if (_buildingObject == null)
			{
				_buildingObject = GetComponent<BuildingObject>();
			}
			return _buildingObject;
		}
	}

	public string UniqueSortingOutputId
	{
		get
		{
			if (!(BuildingObj != null))
			{
				return string.Empty;
			}
			return BuildingObj.UniqueBuildingId;
		}
	}

	public bool UseManualSaveId => useManualSaveId;

	public string SaveID
	{
		get
		{
			if (!useManualSaveId)
			{
				return "sorting-output-" + UniqueSortingOutputId;
			}
			return manualSaveId;
		}
	}

	public bool IsShared => false;

	public Type SaveType => typeof(SortingOutputSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public bool NetworkisOutputRunning
	{
		get
		{
			return isOutputRunning;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isOutputRunning, 1uL, _Mirror_SyncVarHookDelegate_isOutputRunning);
		}
	}

	public float NetworkoutputProgress
	{
		get
		{
			return outputProgress;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref outputProgress, 2uL, _Mirror_SyncVarHookDelegate_outputProgress);
		}
	}

	public string NetworkselectedItemId
	{
		get
		{
			return selectedItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref selectedItemId, 4uL, _Mirror_SyncVarHookDelegate_selectedItemId);
		}
	}

	public int NetworkselectedItemCount
	{
		get
		{
			return selectedItemCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref selectedItemCount, 8uL, _Mirror_SyncVarHookDelegate_selectedItemCount);
		}
	}

	public event Action<T_ItemSO> OnSelectedItemChangedEvent;

	public event Action<int> OnItemCountChangedEvent;

	private void Awake()
	{
		if (GameManager.Instance != null)
		{
			if (storageManager == null)
			{
				storageManager = GameManager.Instance.storageManager;
			}
			if (storageUI == null && GameManager.Instance.UImanager != null)
			{
				storageUI = GameManager.Instance.UImanager.storageUI;
			}
		}
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.AddListener(OnStorageChanged);
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (storageManager != null)
		{
			storageManager.OnStorageChanged.RemoveListener(OnStorageChanged);
		}
	}

	private void OnStorageChanged()
	{
		if (base.isServer && !string.IsNullOrEmpty(selectedItemId))
		{
			DebugLog($"OnStorageChanged - selectedItemId: {selectedItemId}, isRunning: {isOutputRunning}");
			StartCoroutine(UpdateItemCountAfterStorageChange());
			StartCoroutine(UpdateEventStateAfterStorageChange());
		}
	}

	[IteratorStateMachine(typeof(_003CUpdateEventStateAfterStorageChange_003Ed__48))]
	[Server]
	private IEnumerator UpdateEventStateAfterStorageChange()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_SortingOutput::UpdateEventStateAfterStorageChange()' called when server was not active");
			return null;
		}
		return new _003CUpdateEventStateAfterStorageChange_003Ed__48(0)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(_003CUpdateItemCountAfterStorageChange_003Ed__49))]
	[Server]
	private IEnumerator UpdateItemCountAfterStorageChange()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_SortingOutput::UpdateItemCountAfterStorageChange()' called when server was not active");
			return null;
		}
		return new _003CUpdateItemCountAfterStorageChange_003Ed__49(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		DebugLog("OnStartServer - server connection established");
		UpdateOutputEventState();
		SaveLoadManager.Subscribe(this, 55);
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.AddListener(OnLoadingFinished);
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		DebugLog("OnStopServer - server connection lost");
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Instance.OnLoadingFinished.RemoveListener(OnLoadingFinished);
		}
	}

	[Server]
	private void OnLoadingFinished(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::OnLoadingFinished(LoadingType)' called when server was not active");
		}
		else if (pendingRestoreAfterLoad)
		{
			pendingRestoreAfterLoad = false;
			StartCoroutine(Co_RestoreOutputState());
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		StartCoroutine(UpdateClientStateOnJoin());
	}

	private IEnumerator UpdateClientStateOnJoin()
	{
		yield return new WaitForSeconds(0.1f);
		CmdRequestEventSync();
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestEventSync(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestEventSync__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_SortingOutput::CmdRequestEventSync(Mirror.NetworkConnectionToClient)", 524025242, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetSyncEventStates(NetworkConnection target, bool outputActive, bool outputDeactive, bool outputWorking, bool outputStopped)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(outputActive);
		writer.WriteBool(outputDeactive);
		writer.WriteBool(outputWorking);
		writer.WriteBool(outputStopped);
		SendTargetRPCInternal(target, "System.Void T_SortingOutput::TargetSyncEventStates(Mirror.NetworkConnection,System.Boolean,System.Boolean,System.Boolean,System.Boolean)", 819517528, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void UpdateOutputEventState()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::UpdateOutputEventState()' called when server was not active");
			return;
		}
		bool num = !string.IsNullOrEmpty(selectedItemId);
		int num2 = 0;
		if (num && storageManager != null)
		{
			T_ItemSO t_ItemSO = ResolveItem(selectedItemId);
			if (t_ItemSO != null)
			{
				num2 = storageManager.GetItemCount(t_ItemSO);
			}
		}
		bool flag = num;
		if (flag != lastOutputActiveState)
		{
			lastOutputActiveState = flag;
			if (flag)
			{
				OnOutputActive?.Invoke();
				RpcOutputActive();
			}
		}
		bool flag2 = !num;
		if (flag2 != lastOutputDeactiveState)
		{
			lastOutputDeactiveState = flag2;
			if (flag2)
			{
				OnOutputDeactive?.Invoke();
				RpcOutputDeactive();
			}
		}
		bool flag3 = num && num2 > 0 && isOutputRunning;
		if (flag3 != lastOutputWorkingState)
		{
			lastOutputWorkingState = flag3;
			if (flag3)
			{
				OnOutputWorking?.Invoke();
				RpcOutputWorking();
			}
		}
		bool flag4 = num && num2 <= 0 && isOutputRunning;
		bool flag5 = num && !isOutputRunning;
		bool flag6 = flag4 || flag5;
		if (flag6 != lastOutputStoppedState)
		{
			lastOutputStoppedState = flag6;
			if (flag6)
			{
				OnOutputStopped?.Invoke();
				RpcOutputStopped();
			}
		}
	}

	[ClientRpc]
	private void RpcOutputActive()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_SortingOutput::RpcOutputActive()", -656680099, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOutputDeactive()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_SortingOutput::RpcOutputDeactive()", -725484326, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOutputWorking()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_SortingOutput::RpcOutputWorking()", -354607048, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOutputStopped()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_SortingOutput::RpcOutputStopped()", 2014731070, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void HandleOutputInteraction()
	{
		if (!TryHandleSackInteraction())
		{
			OnInteractWithoutSack?.Invoke();
		}
	}

	public void OpenStorageUI()
	{
		if (storageUI == null && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			storageUI = GameManager.Instance.UImanager.storageUI;
		}
		if (storageUI != null)
		{
			storageUI.OpenUI(this);
		}
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PutOreInMachine, TutorialSubStepType.OpenSortingOutput);
		}
	}

	public void CloseStorageUI()
	{
		if (storageUI != null)
		{
			storageUI.CloseUI();
		}
	}

	private bool TryHandleSackInteraction()
	{
		T_Equipments t_Equipments = GameManager.Instance?.localEquipments;
		if (t_Equipments == null || t_Equipments.pickupItem == null)
		{
			return false;
		}
		T_Sack component = t_Equipments.pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return false;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			return false;
		}
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			T_ItemSO t_ItemSO = ResolveItem(item.Key);
			if (t_ItemSO != null && item.Value > 0)
			{
				OpenSackPickerUI(component, t_ItemSO, item.Value);
				return true;
			}
		}
		return false;
	}

	private void OpenSackPickerUI(T_Sack sack, T_ItemSO item, int availableCount)
	{
		PickerUI pickerUI = GameManager.Instance?.UImanager?.pickerUI;
		if (!(pickerUI == null))
		{
			currentTransferSack = sack;
			currentTransferItem = item;
			pickerUI.OpenUI(item, availableCount, OnSackTransferRequested);
		}
	}

	private void OnSackTransferRequested(T_ItemSO item, int quantity)
	{
		if (!(currentTransferSack == null) && !(item == null) && quantity > 0)
		{
			TransferItemsFromSack(currentTransferSack.netId, item.GetItemID(), quantity);
			currentTransferSack = null;
			currentTransferItem = null;
		}
	}

	public void TriggerOnUIClosed()
	{
		OnUIClosed?.Invoke();
	}

	public void HandleOutputStartButton(T_ItemSO item)
	{
		if (!hasOutputOperation || item == null)
		{
			return;
		}
		string itemID = item.GetItemID();
		if (!string.IsNullOrEmpty(itemID))
		{
			if (base.isServer)
			{
				ServerToggleOutput(itemID);
			}
			else
			{
				CmdToggleOutput(itemID);
			}
		}
	}

	public void SetStorageManager(StorageManager manager)
	{
		storageManager = manager;
	}

	public StorageManager GetStorageManager()
	{
		return storageManager;
	}

	public bool GetOutputRunningState()
	{
		return isOutputRunning;
	}

	public float GetOutputProgress()
	{
		return outputProgress;
	}

	public void SetSelectedItem(T_ItemSO item)
	{
		if (base.isServer)
		{
			ServerSetSelectedItem((item != null) ? item.GetItemID() : null);
		}
		else
		{
			CmdSetSelectedItem((item != null) ? item.GetItemID() : null);
		}
	}

	public T_ItemSO GetSelectedItem()
	{
		if (string.IsNullOrEmpty(selectedItemId))
		{
			return null;
		}
		return ResolveItem(selectedItemId);
	}

	public int GetSelectedItemCount()
	{
		T_ItemSO selectedItem = GetSelectedItem();
		if (selectedItem == null || storageManager == null)
		{
			return 0;
		}
		return storageManager.GetItemCount(selectedItem);
	}

	public void RequestSpawnItem(T_ItemSO item, int count = 1)
	{
		if (!hasOutputOperation || item == null || count <= 0)
		{
			return;
		}
		string itemID = item.GetItemID();
		if (!string.IsNullOrEmpty(itemID))
		{
			if (base.isServer)
			{
				ServerSpawnItem(itemID, count);
			}
			else
			{
				CmdRequestSpawnItem(itemID, count);
			}
		}
	}

	public void RequestSpawnSack(T_ItemSO item, int count)
	{
		if (!hasOutputOperation || item == null || count <= 0)
		{
			return;
		}
		string itemID = item.GetItemID();
		if (!string.IsNullOrEmpty(itemID))
		{
			if (base.isServer)
			{
				NetworkConnectionToClient localConnection = NetworkServer.localConnection;
				ServerSpawnSack(itemID, count, localConnection);
			}
			else
			{
				CmdRequestSpawnSack(itemID, count);
			}
		}
	}

	public void RequestSpawnOutputItems(T_ItemSO item, int count)
	{
		if (!hasOutputOperation || item == null || count <= 0)
		{
			return;
		}
		string itemID = item.GetItemID();
		if (!string.IsNullOrEmpty(itemID))
		{
			if (base.isServer)
			{
				ServerSpawnOutputItems(itemID, count);
			}
			else
			{
				CmdRequestSpawnOutputItems(itemID, count);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSpawnItem(string itemId, int count)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSpawnItem__String__Int32(itemId, count);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_SortingOutput::CmdRequestSpawnItem(System.String,System.Int32)", -1948478885, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSpawnSack(string itemId, int count, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSpawnSack__String__Int32__NetworkConnectionToClient(itemId, count, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_SortingOutput::CmdRequestSpawnSack(System.String,System.Int32,Mirror.NetworkConnectionToClient)", -569825469, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSpawnOutputItems(string itemId, int count)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSpawnOutputItems__String__Int32(itemId, count);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_SortingOutput::CmdRequestSpawnOutputItems(System.String,System.Int32)", -1348602009, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdToggleOutput(string itemId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdToggleOutput__String(itemId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		SendCommandInternal("System.Void T_SortingOutput::CmdToggleOutput(System.String)", -1985445106, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetSelectedItem(string itemId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetSelectedItem__String(itemId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		SendCommandInternal("System.Void T_SortingOutput::CmdSetSelectedItem(System.String)", -1510752905, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetSelectedItem(string itemId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerSetSelectedItem(System.String)' called when server was not active");
		}
		else if (!(selectedItemId == itemId))
		{
			DebugLog("ServerSetSelectedItem - old: " + selectedItemId + ", new: " + itemId);
			if (isOutputRunning)
			{
				ServerStopOutput();
			}
			NetworkselectedItemId = itemId;
			UpdateSelectedItemCount();
			UpdateOutputEventState();
		}
	}

	[Server]
	private void ServerStopOutput()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerStopOutput()' called when server was not active");
		}
		else if (isOutputRunning)
		{
			DebugLog("ServerStopOutput - selectedItemId: " + selectedItemId);
			NetworkisOutputRunning = false;
			if (outputCoroutine != null)
			{
				StopCoroutine(outputCoroutine);
				outputCoroutine = null;
			}
			NetworkoutputProgress = 0f;
			currentProcessingItem = null;
			UpdateOutputEventState();
		}
	}

	[Server]
	private void UpdateSelectedItemCount()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::UpdateSelectedItemCount()' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(selectedItemId))
		{
			NetworkselectedItemCount = 0;
			return;
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			NetworkselectedItemCount = 0;
			return;
		}
		T_ItemSO t_ItemSO = ResolveItem(selectedItemId);
		if (t_ItemSO == null)
		{
			NetworkselectedItemCount = 0;
		}
		else
		{
			NetworkselectedItemCount = storageManager.GetItemCount(t_ItemSO);
		}
	}

	private void OnSelectedItemChanged(string oldValue, string newValue)
	{
		if (!string.IsNullOrEmpty(oldValue))
		{
			ResolveItem(oldValue);
		}
		T_ItemSO t_ItemSO = (string.IsNullOrEmpty(newValue) ? null : ResolveItem(newValue));
		this.OnSelectedItemChangedEvent?.Invoke(t_ItemSO);
		if (t_ItemSO != null)
		{
			int obj = 0;
			if (base.isServer)
			{
				obj = selectedItemCount;
			}
			else
			{
				if (storageManager == null && GameManager.Instance != null)
				{
					storageManager = GameManager.Instance.storageManager;
				}
				if (storageManager != null)
				{
					obj = storageManager.GetItemCount(t_ItemSO);
				}
			}
			this.OnItemCountChangedEvent?.Invoke(obj);
		}
		else
		{
			this.OnItemCountChangedEvent?.Invoke(0);
		}
	}

	private void OnSelectedItemCountChanged(int oldValue, int newValue)
	{
		this.OnItemCountChangedEvent?.Invoke(newValue);
	}

	[Server]
	private void ServerSpawnItem(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerSpawnItem(System.String,System.Int32)' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(itemId))
		{
			ServerSetSelectedItem(itemId);
		}
	}

	[Server]
	private void SpawnSingleItem(T_ItemSO itemSO)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::SpawnSingleItem(T_ItemSO)' called when server was not active");
			return;
		}
		if (itemSO == null)
		{
			UnityEngine.Debug.LogError("T_SortingOutput: ItemSO null, spawn edilemedi.");
			return;
		}
		GameObject spawnPrefab = itemSO.SpawnPrefab;
		if (spawnPrefab == null)
		{
			UnityEngine.Debug.LogError("T_SortingOutput: ItemSO'da SpawnPrefab null. Item: " + itemSO.Name);
			return;
		}
		Vector3 position = ((itemSpawnPoint != null) ? itemSpawnPoint.position : (base.transform.position + Vector3.up));
		GameObject obj = UnityEngine.Object.Instantiate(spawnPrefab, position, Quaternion.identity);
		T_Item component = obj.GetComponent<T_Item>();
		if (component != null)
		{
			component.ServerPreAssignSO(itemSO);
			component.checkForBeltOnSpawn = true;
		}
		else
		{
			UnityEngine.Debug.LogError("T_SortingOutput: T_Item component bulunamadı.");
		}
		NetworkServer.Spawn(obj);
	}

	[Server]
	private void ServerSpawnSack(string itemId, int count, NetworkConnectionToClient sender = null)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerSpawnSack(System.String,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(itemId) || count <= 0)
			{
				return;
			}
			if (storageManager == null && GameManager.Instance != null)
			{
				storageManager = GameManager.Instance.storageManager;
			}
			if (storageManager == null)
			{
				UnityEngine.Debug.LogError("T_SortingOutput: StorageManager null (ServerSpawnSack).");
				return;
			}
			T_ItemSO t_ItemSO = ResolveItem(itemId);
			if (t_ItemSO == null)
			{
				UnityEngine.Debug.LogError("T_SortingOutput: Item çözümlenemedi (ServerSpawnSack).");
				return;
			}
			int itemCount = storageManager.GetItemCount(t_ItemSO);
			if (itemCount > 0)
			{
				int count2 = Mathf.Min(count, itemCount);
				storageManager.RequestRemoveItem(t_ItemSO, count2);
				SpawnSackWithItems(t_ItemSO, count2, sender);
				UpdateOutputUIForItem(t_ItemSO);
				if (t_ItemSO.GetItemID() == selectedItemId)
				{
					StartCoroutine(UpdateItemCountAfterFrame(t_ItemSO));
				}
			}
		}
	}

	[Server]
	private void SpawnSackWithItems(T_ItemSO item, int count, NetworkConnectionToClient sender = null)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::SpawnSackWithItems(T_ItemSO,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (item == null || count <= 0)
			{
				return;
			}
			GameObject gameObject = sackPrefab;
			if (gameObject == null)
			{
				T_Bag t_Bag = UnityEngine.Object.FindFirstObjectByType<T_Bag>();
				if (t_Bag != null)
				{
					FieldInfo field = t_Bag.GetType().GetField("sackPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
					if (field != null)
					{
						gameObject = field.GetValue(t_Bag) as GameObject;
					}
				}
			}
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError("T_SortingOutput: Sack prefab bulunamadı.");
				return;
			}
			Vector3 position = ((sackSpawnPoint != null) ? sackSpawnPoint.position : ((itemSpawnPoint != null) ? itemSpawnPoint.position : (base.transform.position + Vector3.up * 0.5f)));
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, position, Quaternion.identity);
			T_Sack component = gameObject2.GetComponent<T_Sack>();
			if (component == null)
			{
				UnityEngine.Debug.LogError("T_SortingOutput: Spawn edilen sack'te T_Sack component'i bulunamadı.");
				UnityEngine.Object.Destroy(gameObject2);
				return;
			}
			component.SetAsAutoPickupSack();
			NetworkServer.Spawn(gameObject2);
			int num = Mathf.Min(count, T_Sack.MaxItemsPerSack);
			List<T_ItemSO> list = new List<T_ItemSO>();
			for (int i = 0; i < num; i++)
			{
				list.Add(item);
			}
			component.ServerSetItems(list);
			OnSackSpawned?.Invoke(component);
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PutOreInMachine, TutorialSubStepType.PickUpSortedOre);
			}
			if (sender != null)
			{
				uint sackNetId = gameObject2.GetComponent<NetworkIdentity>().netId;
				TargetRpcPickupSpawnedSack(sender, sackNetId);
			}
			else
			{
				UnityEngine.Debug.LogWarning("[T_SortingOutput] Sender null, sack kimin eline verileceği bilinmiyor!");
			}
		}
	}

	[TargetRpc]
	private void TargetRpcPickupSpawnedSack(NetworkConnectionToClient target, uint sackNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendTargetRPCInternal(target, "System.Void T_SortingOutput::TargetRpcPickupSpawnedSack(Mirror.NetworkConnectionToClient,System.UInt32)", 2039211614, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSpawnOutputItems(string itemId, int count)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerSpawnOutputItems(System.String,System.Int32)' called when server was not active");
		}
		else
		{
			ServerSpawnItem(itemId, count);
		}
	}

	[Server]
	private void ServerToggleOutput(string itemId)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerToggleOutput(System.String)' called when server was not active");
			return;
		}
		if (isOutputRunning)
		{
			DebugLog("ServerToggleOutput - stopping, itemId: " + itemId);
			ServerStopOutput();
			return;
		}
		if (!string.IsNullOrEmpty(itemId))
		{
			NetworkselectedItemId = itemId;
			UpdateSelectedItemCount();
		}
		if (string.IsNullOrEmpty(selectedItemId))
		{
			DebugLog("ServerToggleOutput - no selected item, cannot start");
			UnityEngine.Debug.LogWarning("T_SortingOutput: Seçili item yok, output başlatılamadı.");
			return;
		}
		DebugLog("ServerToggleOutput - starting, selectedItemId: " + selectedItemId);
		NetworkisOutputRunning = true;
		outputCoroutine = StartCoroutine(OutputCycleCoroutine());
		UpdateOutputEventState();
	}

	[IteratorStateMachine(typeof(_003COutputCycleCoroutine_003Ed__97))]
	[Server]
	private IEnumerator OutputCycleCoroutine()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_SortingOutput::OutputCycleCoroutine()' called when server was not active");
			return null;
		}
		return new _003COutputCycleCoroutine_003Ed__97(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	private void UpdateOutputUIForItem(T_ItemSO item)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::UpdateOutputUIForItem(T_ItemSO)' called when server was not active");
		}
		else if (item != null)
		{
			RpcUpdateOutputUI(item.GetItemID());
		}
	}

	[ClientRpc]
	private void RpcUpdateOutputUI(string itemId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		SendRPCInternal("System.Void T_SortingOutput::RpcUpdateOutputUI(System.String)", 1944637158, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnOutputRunningChanged(bool oldValue, bool newValue)
	{
		if (base.isServer)
		{
			UpdateOutputEventState();
		}
	}

	private void OnOutputProgressChanged(float oldValue, float newValue)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateItemCountAfterFrame_003Ed__102))]
	[Server]
	private IEnumerator UpdateItemCountAfterFrame(T_ItemSO item)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_SortingOutput::UpdateItemCountAfterFrame(T_ItemSO)' called when server was not active");
			return null;
		}
		return new _003CUpdateItemCountAfterFrame_003Ed__102(0)
		{
			_003C_003E4__this = this,
			item = item
		};
	}

	public void TransferItemsFromSack(uint sackNetId, string itemId, int amount)
	{
		if (base.isServer)
		{
			ServerTransferItemsFromSack(sackNetId, itemId, amount, NetworkServer.localConnection);
		}
		else
		{
			CmdTransferItemsFromSack(sackNetId, itemId, amount);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTransferItemsFromSack(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTransferItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(sackNetId, itemId, amount, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		writer.WriteString(itemId);
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void T_SortingOutput::CmdTransferItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", -417919800, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTransferItemsFromSack(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_SortingOutput::ServerTransferItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (sackNetId == 0 || string.IsNullOrEmpty(itemId) || amount <= 0 || !NetworkServer.spawned.TryGetValue(sackNetId, out var value))
			{
				return;
			}
			T_Sack component = value.GetComponent<T_Sack>();
			if (component == null)
			{
				return;
			}
			Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
			int num = (storedItemCounts.ContainsKey(itemId) ? storedItemCounts[itemId] : 0);
			if (num <= 0)
			{
				return;
			}
			int num2 = Mathf.Min(amount, num);
			if (storageManager == null && GameManager.Instance != null)
			{
				storageManager = GameManager.Instance.storageManager;
			}
			if (storageManager == null)
			{
				return;
			}
			T_ItemSO t_ItemSO = ResolveItem(itemId);
			if (t_ItemSO == null)
			{
				return;
			}
			storageManager.RequestAddItem(t_ItemSO, num2);
			component.ServerRemoveItems(new Dictionary<string, int> { { itemId, num2 } });
			if (component.ItemCount <= 0)
			{
				if (sender != null)
				{
					TargetClearPickupItem(sender);
				}
				NetworkServer.Destroy(component.gameObject);
			}
		}
	}

	[TargetRpc]
	private void TargetClearPickupItem(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_SortingOutput::TargetClearPickupItem(Mirror.NetworkConnection)", -1696768347, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			UnityEngine.Debug.Log("[T_SortingOutput] " + message);
		}
	}

	private T_ItemSO ResolveItem(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetItemSOById(itemId);
		}
		return null;
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		DebugLog($"GetSaveData - isRunning: {isOutputRunning}, selectedItemId: {selectedItemId}");
		return new SortingOutputSaveData
		{
			isRunning = isOutputRunning,
			selectedItemId = selectedItemId
		};
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		DebugLog("OnLoad - starting load");
		if (!(value is SortingOutputSaveData sortingOutputSaveData))
		{
			DebugLog("OnLoad - invalid data type, aborting");
			UnityEngine.Debug.LogWarning("[T_SortingOutput] OnLoad - Invalid data type");
			return Task.CompletedTask;
		}
		DebugLog($"OnLoad - isRunning: {sortingOutputSaveData.isRunning}, selectedItemId: {sortingOutputSaveData.selectedItemId}");
		if (!string.IsNullOrEmpty(sortingOutputSaveData.selectedItemId))
		{
			NetworkselectedItemId = sortingOutputSaveData.selectedItemId;
			UpdateSelectedItemCount();
		}
		if (sortingOutputSaveData.isRunning && !string.IsNullOrEmpty(sortingOutputSaveData.selectedItemId))
		{
			pendingRestoreAfterLoad = true;
		}
		DebugLog($"OnLoad - complete, pendingRestore: {pendingRestoreAfterLoad}");
		return Task.CompletedTask;
	}

	[IteratorStateMachine(typeof(_003CCo_RestoreOutputState_003Ed__119))]
	[Server]
	private IEnumerator Co_RestoreOutputState()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_SortingOutput::Co_RestoreOutputState()' called when server was not active");
			return null;
		}
		return new _003CCo_RestoreOutputState_003Ed__119(0)
		{
			_003C_003E4__this = this
		};
	}

	public T_SortingOutput()
	{
		_Mirror_SyncVarHookDelegate_isOutputRunning = OnOutputRunningChanged;
		_Mirror_SyncVarHookDelegate_outputProgress = OnOutputProgressChanged;
		_Mirror_SyncVarHookDelegate_selectedItemId = OnSelectedItemChanged;
		_Mirror_SyncVarHookDelegate_selectedItemCount = OnSelectedItemCountChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestEventSync__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			return;
		}
		bool num = !string.IsNullOrEmpty(selectedItemId);
		int num2 = 0;
		if (num && storageManager != null)
		{
			T_ItemSO t_ItemSO = ResolveItem(selectedItemId);
			if (t_ItemSO != null)
			{
				num2 = storageManager.GetItemCount(t_ItemSO);
			}
		}
		bool outputActive = num;
		bool outputDeactive = !num;
		bool outputWorking = num && num2 > 0 && isOutputRunning;
		bool flag = num && num2 <= 0 && isOutputRunning;
		bool flag2 = num && !isOutputRunning;
		bool outputStopped = flag || flag2;
		TargetSyncEventStates(sender, outputActive, outputDeactive, outputWorking, outputStopped);
	}

	protected static void InvokeUserCode_CmdRequestEventSync__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestEventSync called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdRequestEventSync__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(NetworkConnection target, bool outputActive, bool outputDeactive, bool outputWorking, bool outputStopped)
	{
		lastOutputActiveState = outputActive;
		lastOutputDeactiveState = outputDeactive;
		lastOutputWorkingState = outputWorking;
		lastOutputStoppedState = outputStopped;
		if (outputActive)
		{
			OnOutputActive?.Invoke();
		}
		if (outputDeactive)
		{
			OnOutputDeactive?.Invoke();
		}
		if (outputWorking)
		{
			OnOutputWorking?.Invoke();
		}
		if (outputStopped)
		{
			OnOutputStopped?.Invoke();
		}
	}

	protected static void InvokeUserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetSyncEventStates called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean(null, reader.ReadBool(), reader.ReadBool(), reader.ReadBool(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcOutputActive()
	{
		lastOutputActiveState = true;
		lastOutputDeactiveState = false;
		OnOutputActive?.Invoke();
	}

	protected static void InvokeUserCode_RpcOutputActive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOutputActive called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_RpcOutputActive();
		}
	}

	protected void UserCode_RpcOutputDeactive()
	{
		lastOutputActiveState = false;
		lastOutputDeactiveState = true;
		OnOutputDeactive?.Invoke();
	}

	protected static void InvokeUserCode_RpcOutputDeactive(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOutputDeactive called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_RpcOutputDeactive();
		}
	}

	protected void UserCode_RpcOutputWorking()
	{
		lastOutputWorkingState = true;
		lastOutputStoppedState = false;
		OnOutputWorking?.Invoke();
	}

	protected static void InvokeUserCode_RpcOutputWorking(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOutputWorking called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_RpcOutputWorking();
		}
	}

	protected void UserCode_RpcOutputStopped()
	{
		lastOutputWorkingState = false;
		lastOutputStoppedState = true;
		OnOutputStopped?.Invoke();
	}

	protected static void InvokeUserCode_RpcOutputStopped(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOutputStopped called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_RpcOutputStopped();
		}
	}

	protected void UserCode_CmdRequestSpawnItem__String__Int32(string itemId, int count)
	{
		ServerSpawnItem(itemId, count);
	}

	protected static void InvokeUserCode_CmdRequestSpawnItem__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestSpawnItem called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdRequestSpawnItem__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdRequestSpawnSack__String__Int32__NetworkConnectionToClient(string itemId, int count, NetworkConnectionToClient sender)
	{
		ServerSpawnSack(itemId, count, sender);
	}

	protected static void InvokeUserCode_CmdRequestSpawnSack__String__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestSpawnSack called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdRequestSpawnSack__String__Int32__NetworkConnectionToClient(reader.ReadString(), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestSpawnOutputItems__String__Int32(string itemId, int count)
	{
		ServerSpawnOutputItems(itemId, count);
	}

	protected static void InvokeUserCode_CmdRequestSpawnOutputItems__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestSpawnOutputItems called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdRequestSpawnOutputItems__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdToggleOutput__String(string itemId)
	{
		ServerToggleOutput(itemId);
	}

	protected static void InvokeUserCode_CmdToggleOutput__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdToggleOutput called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdToggleOutput__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdSetSelectedItem__String(string itemId)
	{
		ServerSetSelectedItem(itemId);
	}

	protected static void InvokeUserCode_CmdSetSelectedItem__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetSelectedItem called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdSetSelectedItem__String(reader.ReadString());
		}
	}

	protected void UserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32(NetworkConnectionToClient target, uint sackNetId)
	{
		if (NetworkClient.spawned.TryGetValue(sackNetId, out var value))
		{
			T_Pickup component = value.GetComponent<T_Pickup>();
			if (component != null)
			{
				component.TryRequestPickup(animate: false);
			}
			else
			{
				UnityEngine.Debug.LogWarning($"[T_SortingOutput] Sack üzerinde T_Pickup component'i bulunamadı. NetId: {sackNetId}");
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning($"[T_SortingOutput] Sack bulunamadı. NetId: {sackNetId}");
		}
	}

	protected static void InvokeUserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcPickupSpawnedSack called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32(null, reader.ReadVarUInt());
		}
	}

	protected void UserCode_RpcUpdateOutputUI__String(string itemId)
	{
		if (storageUI == null && GameManager.Instance != null && GameManager.Instance.UImanager != null)
		{
			storageUI = GameManager.Instance.UImanager.storageUI;
		}
		if (storageUI != null)
		{
			storageUI.RefreshItemList();
		}
	}

	protected static void InvokeUserCode_RpcUpdateOutputUI__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcUpdateOutputUI called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_RpcUpdateOutputUI__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdTransferItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(uint sackNetId, string itemId, int amount, NetworkConnectionToClient sender)
	{
		ServerTransferItemsFromSack(sackNetId, itemId, amount, sender);
	}

	protected static void InvokeUserCode_CmdTransferItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTransferItemsFromSack called on client.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_CmdTransferItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(reader.ReadVarUInt(), reader.ReadString(), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_TargetClearPickupItem__NetworkConnection(NetworkConnection target)
	{
		if (GameManager.Instance?.localEquipments != null)
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_TargetClearPickupItem__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetClearPickupItem called on server.");
		}
		else
		{
			((T_SortingOutput)obj).UserCode_TargetClearPickupItem__NetworkConnection(null);
		}
	}

	static T_SortingOutput()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdRequestEventSync(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestEventSync__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdRequestSpawnItem(System.String,System.Int32)", InvokeUserCode_CmdRequestSpawnItem__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdRequestSpawnSack(System.String,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestSpawnSack__String__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdRequestSpawnOutputItems(System.String,System.Int32)", InvokeUserCode_CmdRequestSpawnOutputItems__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdToggleOutput(System.String)", InvokeUserCode_CmdToggleOutput__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdSetSelectedItem(System.String)", InvokeUserCode_CmdSetSelectedItem__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingOutput), "System.Void T_SortingOutput::CmdTransferItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTransferItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::RpcOutputActive()", InvokeUserCode_RpcOutputActive);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::RpcOutputDeactive()", InvokeUserCode_RpcOutputDeactive);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::RpcOutputWorking()", InvokeUserCode_RpcOutputWorking);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::RpcOutputStopped()", InvokeUserCode_RpcOutputStopped);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::RpcUpdateOutputUI(System.String)", InvokeUserCode_RpcUpdateOutputUI__String);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::TargetSyncEventStates(Mirror.NetworkConnection,System.Boolean,System.Boolean,System.Boolean,System.Boolean)", InvokeUserCode_TargetSyncEventStates__NetworkConnection__Boolean__Boolean__Boolean__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::TargetRpcPickupSpawnedSack(Mirror.NetworkConnectionToClient,System.UInt32)", InvokeUserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingOutput), "System.Void T_SortingOutput::TargetClearPickupItem(Mirror.NetworkConnection)", InvokeUserCode_TargetClearPickupItem__NetworkConnection);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isOutputRunning);
			writer.WriteFloat(outputProgress);
			writer.WriteString(selectedItemId);
			writer.WriteVarInt(selectedItemCount);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isOutputRunning);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(outputProgress);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteString(selectedItemId);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarInt(selectedItemCount);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isOutputRunning, _Mirror_SyncVarHookDelegate_isOutputRunning, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref outputProgress, _Mirror_SyncVarHookDelegate_outputProgress, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref selectedItemId, _Mirror_SyncVarHookDelegate_selectedItemId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref selectedItemCount, _Mirror_SyncVarHookDelegate_selectedItemCount, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isOutputRunning, _Mirror_SyncVarHookDelegate_isOutputRunning, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref outputProgress, _Mirror_SyncVarHookDelegate_outputProgress, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref selectedItemId, _Mirror_SyncVarHookDelegate_selectedItemId, reader.ReadString());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref selectedItemCount, _Mirror_SyncVarHookDelegate_selectedItemCount, reader.ReadVarInt());
		}
	}
}
