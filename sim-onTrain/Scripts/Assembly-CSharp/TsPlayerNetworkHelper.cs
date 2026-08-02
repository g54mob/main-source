using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HQFPSTemplate;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;

public class TsPlayerNetworkHelper : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CNotifyPlayerReadyDelayed_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TsPlayerNetworkHelper _003C_003E4__this;

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
		public _003CNotifyPlayerReadyDelayed_003Ed__17(int _003C_003E1__state)
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
			TsPlayerNetworkHelper tsPlayerNetworkHelper = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = _waitOneSecond;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (InventorySaver.Instance != null && tsPlayerNetworkHelper.connectionToClient != null)
				{
					InventorySaver.Instance.RegisterPlayer(tsPlayerNetworkHelper.connectionToClient);
				}
				else
				{
					UnityEngine.Debug.LogError($"[Inventory] NotifyPlayerReadyDelayed FAIL - InventorySaver: {InventorySaver.Instance != null}, conn: {tsPlayerNetworkHelper.connectionToClient != null}");
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

	[SyncVar]
	public string steamID;

	private bool hasLoadedPosition;

	[SyncVar]
	public GameMode playerGameMode;

	public int playerLastSelectedSlot = 1;

	public Animator tpsAnimator;

	private TSPlayerController playerController;

	private NetworkAnimator networkAnimator;

	private static readonly WaitForSeconds _waitOneSecond;

	public string NetworksteamID
	{
		get
		{
			return steamID;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref steamID, 1uL, null);
		}
	}

	public GameMode NetworkplayerGameMode
	{
		get
		{
			return playerGameMode;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref playerGameMode, 2uL, null);
		}
	}

	[Command]
	public void CmdSetGameMode(GameMode newMode)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_GameMode(writer, newMode);
		SendCommandInternal("System.Void TsPlayerNetworkHelper::CmdSetGameMode(GameMode)", -824321311, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdCheatSpawnZombieNear(Vector3 origin)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(origin);
		SendCommandInternal("System.Void TsPlayerNetworkHelper::CmdCheatSpawnZombieNear(UnityEngine.Vector3)", 2034874784, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		playerController = GetComponent<TSPlayerController>();
		networkAnimator = GetComponent<NetworkAnimator>();
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveData);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadData);
		}
	}

	public override void OnStartClient()
	{
		CharacterController component = GetComponent<CharacterController>();
		if (component != null)
		{
			component.enabled = false;
		}
		PlayerMovement component2 = GetComponent<PlayerMovement>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		StartCoroutine(FixGroundedState());
	}

	private IEnumerator FixGroundedState()
	{
		yield return new WaitForSeconds(0.2f);
		tpsAnimator.SetBool("IsGrounded", value: true);
		tpsAnimator.SetBool("IsJumping", value: false);
		tpsAnimator.SetBool("IsCrouching", value: false);
		tpsAnimator.SetFloat("MoveSpeed", 0f);
		if (networkAnimator != null)
		{
			networkAnimator.enabled = false;
			yield return new WaitForEndOfFrame();
			networkAnimator.enabled = true;
		}
		if (!(Singleton<TSNetworkObjetManager>.Instance != null))
		{
			yield break;
		}
		foreach (TsPlayerNetworkHelper playerNetworkHelper in Singleton<TSNetworkObjetManager>.Instance.playerNetworkHelpers)
		{
			if (playerNetworkHelper != null && playerNetworkHelper != this && playerNetworkHelper.tpsAnimator != null)
			{
				playerNetworkHelper.tpsAnimator.SetBool("IsGrounded", value: true);
				playerNetworkHelper.tpsAnimator.SetBool("IsJumping", value: false);
			}
		}
	}

	private void Start()
	{
		StartCoroutine(InitializePlayerCO());
	}

	private IEnumerator InitializePlayerCO()
	{
		yield return new WaitUntil(() => base.isLocalPlayer || base.isServer);
		if (base.isLocalPlayer)
		{
			string text = "";
			if (SteamManager.Initialized)
			{
				CSteamID cSteamID = SteamUser.GetSteamID();
				if (cSteamID.IsValid())
				{
					text = cSteamID.ToString();
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = CustomNetworkManager.nick;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = (base.isServer ? "host" : "client");
			}
			if (base.isServer)
			{
				NetworksteamID = text;
				NotifyPlayerReady();
			}
			else
			{
				CmdSetSteamID(text);
				yield return new WaitUntil(() => !string.IsNullOrEmpty(steamID));
			}
		}
		else if (base.isServer)
		{
			float timeout = 30f;
			float elapsed = 0f;
			while (string.IsNullOrEmpty(steamID) && elapsed < timeout)
			{
				elapsed += Time.deltaTime;
				yield return null;
			}
			if (string.IsNullOrEmpty(steamID))
			{
				UnityEngine.Debug.LogError($"[TsPlayerNetworkHelper] Remote player Steam ID {timeout}s içinde gelmedi! netId={base.netId}");
			}
		}
		if (base.isLocalPlayer)
		{
			TrainGameManager.Instance.mainPlayer = base.gameObject;
			TrainGameManager.Instance.itemChooser = GetComponent<EastUpPlayerItemManager>();
			TrainGameManager.Instance.playerInventoryManagerUI = GetComponentInChildren<InventoryManagerUI>(includeInactive: true);
		}
		if (!base.isServer)
		{
			yield return new WaitUntil(() => TrainGameManager.Instance != null && TrainGameManager.Instance.terrainGenerationSort.Count > 0);
		}
		Singleton<TSNetworkObjetManager>.Instance.Initialize(playerController);
		LoadData();
		if (base.isLocalPlayer && !base.isServer && InventorySaver.Instance != null)
		{
			InventorySaver.Instance.PullInventoryFromSyncData(steamID);
			StartCoroutine(PullStatusFromSyncData());
		}
		if (base.isLocalPlayer && !base.isServer)
		{
			StartCoroutine(PeriodicStatusSync());
		}
	}

	[Command]
	private void CmdSetSteamID(string id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(id);
		SendCommandInternal("System.Void TsPlayerNetworkHelper::CmdSetSteamID(System.String)", -777486474, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void NotifyPlayerReady()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void TsPlayerNetworkHelper::NotifyPlayerReady()' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(steamID))
		{
			StartCoroutine(NotifyPlayerReadyDelayed());
		}
	}

	[IteratorStateMachine(typeof(_003CNotifyPlayerReadyDelayed_003Ed__17))]
	[Server]
	private IEnumerator NotifyPlayerReadyDelayed()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator TsPlayerNetworkHelper::NotifyPlayerReadyDelayed()' called when server was not active");
			return null;
		}
		return new _003CNotifyPlayerReadyDelayed_003Ed__17(0)
		{
			_003C_003E4__this = this
		};
	}

	public void LoadData()
	{
		if (base.isLocalPlayer && !base.isServer)
		{
			SpawnAtTrainPoint();
			return;
		}
		PlayerStatusSaveData? playerStatusSaveData = null;
		if (InventorySaver.Instance != null)
		{
			playerStatusSaveData = InventorySaver.Instance.GetPlayerStatusData(steamID);
		}
		int num;
		if (playerStatusSaveData.HasValue)
		{
			num = (playerStatusSaveData.Value.hasData ? 1 : 0);
			if (num != 0 && playerStatusSaveData.Value.lastSelectedSlot > 0)
			{
				playerLastSelectedSlot = playerStatusSaveData.Value.lastSelectedSlot;
				EastUpPlayerItemManager component = GetComponent<EastUpPlayerItemManager>();
				if (component != null)
				{
					StartCoroutine(DelayedSlotSelection(component, playerLastSelectedSlot));
				}
			}
		}
		else
		{
			num = 0;
		}
		if (num != 0)
		{
			try
			{
				Vector3 position = new Vector3(playerStatusSaveData.Value.posX, playerStatusSaveData.Value.posY, playerStatusSaveData.Value.posZ);
				Vector3 eulerAngles = new Vector3(playerStatusSaveData.Value.rotX, playerStatusSaveData.Value.rotY, playerStatusSaveData.Value.rotZ);
				ApplyStatusOnly(playerStatusSaveData.Value);
				if (IsTooFarFromTrain(position))
				{
					SpawnAtTrainPoint();
				}
				else
				{
					CharacterController component2 = GetComponent<CharacterController>();
					if (component2 != null)
					{
						component2.enabled = false;
					}
					base.transform.position = position;
					base.transform.eulerAngles = eulerAngles;
					hasLoadedPosition = true;
					if (base.isLocalPlayer)
					{
						GetComponentInChildren<PlayerCamera>().enabled = true;
					}
					StartCoroutine(EnableCharacterControllerAfterBuildObjects(component2));
				}
				return;
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError("[PlayerStatus] LoadData HATA: " + ex.Message);
				SpawnAtTrainPoint();
				return;
			}
		}
		SpawnAtTrainPoint();
	}

	private bool IsTooFarFromTrain(Vector3 position)
	{
		TrainController trainController = UnityEngine.Object.FindObjectOfType<TrainController>();
		if (trainController == null)
		{
			return true;
		}
		float num = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.maxDistanceFromTrain : 50f);
		return Vector3.Distance(position, trainController.transform.position) > num;
	}

	private void ApplyStatusOnly(PlayerStatusSaveData data)
	{
		TSPlayerStatusHolder component = GetComponent<TSPlayerStatusHolder>();
		if (component != null)
		{
			component.playerHpFuel = data.health;
			component.playerFoodFuel = data.food;
			component.playerWaterFuel = data.water;
		}
	}

	private void SpawnAtTrainPoint()
	{
		TrainController trainController = UnityEngine.Object.FindObjectOfType<TrainController>();
		if (trainController != null && trainController.spawnPoints.Count > 0)
		{
			Transform transform = trainController.spawnPoints[UnityEngine.Random.Range(0, trainController.spawnPoints.Count)];
			StartCoroutine(SpawnAtPositionWithRotation(transform.position, transform.rotation, transform.name));
		}
	}

	private IEnumerator SpawnAtPositionWithRotation(Vector3 position, Quaternion rotation, string spawnPointName)
	{
		CharacterController component = GetComponent<CharacterController>();
		component.enabled = false;
		base.transform.position = position;
		if (base.isLocalPlayer)
		{
			PlayerCamera componentInChildren = GetComponentInChildren<PlayerCamera>();
			if (componentInChildren != null)
			{
				componentInChildren.LookAngles = new Vector2(componentInChildren.LookAngles.x, rotation.eulerAngles.y);
				componentInChildren.enabled = true;
			}
		}
		hasLoadedPosition = true;
		yield return StartCoroutine(EnableCharacterControllerAfterBuildObjects(component));
	}

	private IEnumerator EnableCharacterControllerAfterBuildObjects(CharacterController cc)
	{
		if (cc == null)
		{
			yield break;
		}
		if (TrainBuildManager.Instance != null && !TrainBuildManager.Instance.isBuildObjectsLoaded)
		{
			yield return new WaitUntil(() => TrainBuildManager.Instance == null || TrainBuildManager.Instance.isBuildObjectsLoaded);
		}
		yield return new WaitForFixedUpdate();
		yield return new WaitForFixedUpdate();
		Physics.SyncTransforms();
		yield return null;
		AdjustSpawnPositionAboveGround(cc);
		TSPlayerStatusHolder statusHolder = GetComponent<TSPlayerStatusHolder>();
		if (statusHolder != null)
		{
			statusHolder.ignoreFallDamage = true;
		}
		if (cc != null)
		{
			cc.enabled = true;
		}
		PlayerMovement component = GetComponent<PlayerMovement>();
		if (component != null)
		{
			component.enabled = true;
		}
		yield return null;
		if (statusHolder != null)
		{
			statusHolder.ignoreFallDamage = false;
		}
	}

	private void AdjustSpawnPositionAboveGround(CharacterController cc)
	{
		if (playerController == null)
		{
			return;
		}
		LayerMask layerMask = (int)playerController.trainLayer | (int)playerController.terrainLayer;
		if (Physics.Raycast(base.transform.position + Vector3.up * 5f, Vector3.down, out var hitInfo, 15f, layerMask))
		{
			float num = hitInfo.point.y + cc.skinWidth + 0.05f;
			if (base.transform.position.y < num)
			{
				UnityEngine.Debug.Log($"[SpawnFix] Oyuncu zemin altında! Y={base.transform.position.y:F2} → {num:F2} (hit: {hitInfo.collider.name})");
				base.transform.position = new Vector3(base.transform.position.x, num, base.transform.position.z);
			}
		}
	}

	private IEnumerator DelayedSlotSelection(EastUpPlayerItemManager itemManager, int slotIndex)
	{
		yield return new WaitForSeconds(1f);
		if (itemManager != null)
		{
			itemManager.ChooseItem(slotIndex, directlyOpen: true);
		}
	}

	public void SaveData()
	{
		if (!string.IsNullOrEmpty(steamID) && base.isLocalPlayer && !(InventorySaver.Instance == null))
		{
			PlayerStatusSaveData statusData = CollectCurrentStatus();
			if (base.isServer)
			{
				InventorySaver.Instance.SavePlayerStatus(steamID, statusData);
			}
			else
			{
				InventorySaver.Instance.CmdSyncPlayerStatus(statusData);
			}
		}
	}

	private IEnumerator PeriodicStatusSync()
	{
		yield return new WaitForSeconds(2f);
		while (true)
		{
			if (InventorySaver.Instance != null && !string.IsNullOrEmpty(steamID))
			{
				PlayerStatusSaveData statusData = CollectCurrentStatus();
				InventorySaver.Instance.CmdSyncPlayerStatus(statusData);
			}
			yield return new WaitForSeconds(1f);
		}
	}

	private IEnumerator PullStatusFromSyncData()
	{
		if (InventorySaver.Instance == null)
		{
			UnityEngine.Debug.LogError("[PlayerStatus] PullStatusFromSyncData - InventorySaver NULL!");
			yield break;
		}
		float elapsed = 0f;
		float timeout = 120f;
		float interval = 0.5f;
		WaitForSeconds wait = new WaitForSeconds(interval);
		while (elapsed < timeout)
		{
			PlayerStatusSaveData? playerStatusData = InventorySaver.Instance.GetPlayerStatusData(steamID);
			if (playerStatusData.HasValue)
			{
				PlayerStatusSaveData value = playerStatusData.Value;
				if (!value.hasData)
				{
					yield break;
				}
				ApplyStatusOnly(value);
				if (value.lastSelectedSlot > 0)
				{
					playerLastSelectedSlot = value.lastSelectedSlot;
					EastUpPlayerItemManager component = GetComponent<EastUpPlayerItemManager>();
					if (component != null)
					{
						StartCoroutine(DelayedSlotSelection(component, value.lastSelectedSlot));
					}
				}
				Vector3 position = new Vector3(value.posX, value.posY, value.posZ);
				if (IsTooFarFromTrain(position))
				{
					SpawnAtTrainPoint();
					yield break;
				}
				CharacterController component2 = GetComponent<CharacterController>();
				if (component2 != null)
				{
					component2.enabled = false;
				}
				base.transform.position = position;
				base.transform.eulerAngles = new Vector3(value.rotX, value.rotY, value.rotZ);
				hasLoadedPosition = true;
				if (base.isLocalPlayer)
				{
					PlayerCamera componentInChildren = GetComponentInChildren<PlayerCamera>();
					if (componentInChildren != null)
					{
						componentInChildren.enabled = true;
					}
				}
				StartCoroutine(EnableCharacterControllerAfterBuildObjects(component2));
				yield break;
			}
			elapsed += interval;
			yield return wait;
		}
		UnityEngine.Debug.LogWarning($"[PlayerStatus] CLIENT PullStatus TIMEOUT ({timeout}s) - '{steamID}'");
	}

	private PlayerStatusSaveData CollectCurrentStatus()
	{
		TSPlayerStatusHolder component = GetComponent<TSPlayerStatusHolder>();
		EastUpPlayerItemManager component2 = GetComponent<EastUpPlayerItemManager>();
		return new PlayerStatusSaveData
		{
			hasData = true,
			posX = base.transform.position.x,
			posY = base.transform.position.y,
			posZ = base.transform.position.z,
			rotX = base.transform.eulerAngles.x,
			rotY = base.transform.eulerAngles.y,
			rotZ = base.transform.eulerAngles.z,
			health = ((component != null) ? component.playerHpFuel : 100f),
			food = ((component != null) ? component.playerFoodFuel : 100f),
			water = ((component != null) ? component.playerWaterFuel : 100f),
			lastSelectedSlot = ((!(component2 != null) || component2.LastIndex <= 0) ? 1 : component2.LastIndex)
		};
	}

	[Command]
	public void CmdCompleteCommonTask(int groupIndex, int taskIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		SendCommandInternal("System.Void TsPlayerNetworkHelper::CmdCompleteCommonTask(System.Int32,System.Int32)", -997578982, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCompleteCommonTask(int groupIndex, int taskIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		SendRPCInternal("System.Void TsPlayerNetworkHelper::RpcCompleteCommonTask(System.Int32,System.Int32)", -832534449, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	public void CmdUpdateCommonTaskProgress(int groupIndex, int taskIndex, int progress)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		writer.WriteInt(progress);
		SendCommandInternal("System.Void TsPlayerNetworkHelper::CmdUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", 650919514, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdateCommonTaskProgress(int groupIndex, int taskIndex, int progress)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(groupIndex);
		writer.WriteInt(taskIndex);
		writer.WriteInt(progress);
		SendRPCInternal("System.Void TsPlayerNetworkHelper::RpcUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", -135160059, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDestroy()
	{
		if (base.isLocalPlayer && !base.isServer && InventorySaver.Instance != null && !string.IsNullOrEmpty(steamID))
		{
			try
			{
				PlayerStatusSaveData statusData = CollectCurrentStatus();
				InventorySaver.Instance.CmdSyncPlayerStatus(statusData);
			}
			catch (Exception)
			{
			}
		}
		if (Singleton<TSNetworkObjetManager>.Instance != null && playerController != null)
		{
			Singleton<TSNetworkObjetManager>.Instance.RemovePlayer(playerController);
		}
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveData);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.RemoveListener(LoadData);
		}
	}

	static TsPlayerNetworkHelper()
	{
		_waitOneSecond = new WaitForSeconds(1f);
		RemoteProcedureCalls.RegisterCommand(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::CmdSetGameMode(GameMode)", InvokeUserCode_CmdSetGameMode__GameMode, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::CmdCheatSpawnZombieNear(UnityEngine.Vector3)", InvokeUserCode_CmdCheatSpawnZombieNear__Vector3, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::CmdSetSteamID(System.String)", InvokeUserCode_CmdSetSteamID__String, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::CmdCompleteCommonTask(System.Int32,System.Int32)", InvokeUserCode_CmdCompleteCommonTask__Int32__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::CmdUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", InvokeUserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::RpcCompleteCommonTask(System.Int32,System.Int32)", InvokeUserCode_RpcCompleteCommonTask__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(TsPlayerNetworkHelper), "System.Void TsPlayerNetworkHelper::RpcUpdateCommonTaskProgress(System.Int32,System.Int32,System.Int32)", InvokeUserCode_RpcUpdateCommonTaskProgress__Int32__Int32__Int32);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetGameMode__GameMode(GameMode newMode)
	{
		NetworkplayerGameMode = newMode;
	}

	protected static void InvokeUserCode_CmdSetGameMode__GameMode(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetGameMode called on client.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_CmdSetGameMode__GameMode(GeneratedNetworkCode._Read_GameMode(reader));
		}
	}

	protected void UserCode_CmdCheatSpawnZombieNear__Vector3(Vector3 origin)
	{
		if (ZombieSpawner.Instance != null)
		{
			ZombieSpawner.Instance.CheatSpawnZombieNear(origin);
		}
		else
		{
			UnityEngine.Debug.LogWarning("[Cheat] ZombieSpawner.Instance bulunamadı, zombi spawn edilemedi.");
		}
	}

	protected static void InvokeUserCode_CmdCheatSpawnZombieNear__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdCheatSpawnZombieNear called on client.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_CmdCheatSpawnZombieNear__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CmdSetSteamID__String(string id)
	{
		NetworksteamID = id;
		NotifyPlayerReady();
	}

	protected static void InvokeUserCode_CmdSetSteamID__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdSetSteamID called on client.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_CmdSetSteamID__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdCompleteCommonTask__Int32__Int32(int groupIndex, int taskIndex)
	{
		if (InventorySaver.Instance != null)
		{
			InventorySaver.Instance.UpdateCommonTask(groupIndex, taskIndex, 0, completed: true);
		}
		RpcCompleteCommonTask(groupIndex, taskIndex);
	}

	protected static void InvokeUserCode_CmdCompleteCommonTask__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdCompleteCommonTask called on client.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_CmdCompleteCommonTask__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcCompleteCommonTask__Int32__Int32(int groupIndex, int taskIndex)
	{
		if (TSPlayerTutorialManager.Instance != null)
		{
			TSPlayerTutorialManager.Instance.CompleteCommonTaskFromNetwork(groupIndex, taskIndex);
		}
	}

	protected static void InvokeUserCode_RpcCompleteCommonTask__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcCompleteCommonTask called on server.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_RpcCompleteCommonTask__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(int groupIndex, int taskIndex, int progress)
	{
		if (InventorySaver.Instance != null)
		{
			InventorySaver.Instance.UpdateCommonTask(groupIndex, taskIndex, progress, completed: false);
		}
		RpcUpdateCommonTaskProgress(groupIndex, taskIndex, progress);
	}

	protected static void InvokeUserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdUpdateCommonTaskProgress called on client.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_CmdUpdateCommonTaskProgress__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcUpdateCommonTaskProgress__Int32__Int32__Int32(int groupIndex, int taskIndex, int progress)
	{
		if (TSPlayerTutorialManager.Instance != null)
		{
			TSPlayerTutorialManager.Instance.UpdateCommonTaskProgressFromNetwork(groupIndex, taskIndex, progress);
		}
	}

	protected static void InvokeUserCode_RpcUpdateCommonTaskProgress__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcUpdateCommonTaskProgress called on server.");
		}
		else
		{
			((TsPlayerNetworkHelper)obj).UserCode_RpcUpdateCommonTaskProgress__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(steamID);
			GeneratedNetworkCode._Write_GameMode(writer, playerGameMode);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(steamID);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			GeneratedNetworkCode._Write_GameMode(writer, playerGameMode);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref steamID, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref playerGameMode, null, GeneratedNetworkCode._Read_GameMode(reader));
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref steamID, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref playerGameMode, null, GeneratedNetworkCode._Read_GameMode(reader));
		}
	}
}
