using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GameCreator.Runtime.Variables;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayer : NetworkBehaviour
{
	[Header("GamePlayer Info")]
	[SyncVar(hook = "HandlePlayerNameUpdate")]
	public string playerName;

	[SyncVar]
	public ulong playerSteamId;

	[SyncVar]
	public int ownerConnectionId;

	[SyncVar(hook = "OnDigsiteStatusChanged")]
	public bool isInDigsite;

	[Header("Customization ID")]
	[SyncVar(hook = "OnCustomizationChanged")]
	public string customizationIDs;

	public int headID;

	public int topID;

	public int bottomID;

	public int helmetID;

	public int glovesID;

	public int bootsID;

	public int beltID;

	public int topMatID;

	public int bottomMatID;

	public int glovesMatID;

	public int helmetMatID;

	public int bootsMatID;

	[Header("Customization")]
	public SkinWrapper skinWrapper;

	[Header("UI")]
	public TextMeshPro playerNameText;

	[Header("Events")]
	public UnityEvent isLocalPlayerEvent;

	public UnityEvent isRemotePlayerEvent;

	public UnityEvent onClientConnectedEvent;

	public UnityEvent canGetUp;

	public UnityEvent onOpenCustomization;

	[Header("Stand Up Check")]
	public LayerMask standUpLayerMask;

	public float standUpCheckDistance = 2f;

	[Header("Voice")]
	public SteamVoiceChat voiceChat;

	[Header("References")]
	public PlayerInteractionManager interactionManager;

	[Header("GameCreator Variables")]
	public GlobalNameVariables globalNameVariables;

	public Action<string, string> _Mirror_SyncVarHookDelegate_playerName;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isInDigsite;

	public Action<string, string> _Mirror_SyncVarHookDelegate_customizationIDs;

	public string NetworkplayerName
	{
		get
		{
			return playerName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref playerName, 1uL, _Mirror_SyncVarHookDelegate_playerName);
		}
	}

	public ulong NetworkplayerSteamId
	{
		get
		{
			return playerSteamId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref playerSteamId, 2uL, null);
		}
	}

	public int NetworkownerConnectionId
	{
		get
		{
			return ownerConnectionId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref ownerConnectionId, 4uL, null);
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
			GeneratedSyncVarSetter(value, ref isInDigsite, 8uL, _Mirror_SyncVarHookDelegate_isInDigsite);
		}
	}

	public string NetworkcustomizationIDs
	{
		get
		{
			return customizationIDs;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref customizationIDs, 16uL, _Mirror_SyncVarHookDelegate_customizationIDs);
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (base.connectionToClient != null)
		{
			NetworkownerConnectionId = base.connectionToClient.connectionId;
		}
		TryRandomizeCustomizationAtStartServer();
	}

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.5f);
		if (!base.isLocalPlayer)
		{
			isRemotePlayerEvent.Invoke();
		}
		if (NetworkClient.localPlayer != null)
		{
			NetworkClient.localPlayer.GetComponent<GamePlayer>().onClientConnectedEvent.Invoke();
		}
	}

	public override void OnStartAuthority()
	{
		ConnectPlayer();
		base.gameObject.name = "LocalGamePlayer";
		isLocalPlayerEvent.Invoke();
		interactionManager.SetIsLocalPlayer(value: true);
		if (NewNetworkManager.Instance != null && NewNetworkManager.Instance.IsMultiplayer && ownerConnectionId != 0)
		{
			StartCoroutine(SendJoinNotificationAfterLoading());
		}
	}

	private IEnumerator SendJoinNotificationAfterLoading()
	{
		yield return new WaitUntil(() => LoadingManagerUI.Instance == null || !LoadingManagerUI.Instance.IsLoading);
		yield return new WaitForSeconds(0.5f);
		if (PlayerActionNotificationManager.Instance != null)
		{
			PlayerActionNotificationManager.Instance.RequestPlayerJoinedNotification(playerName);
		}
	}

	private void OnDestroy()
	{
		UnregisterFromNetworkManager();
	}

	private void LeaveSteamLobbyAndReturnToMenu()
	{
		PauseMenuManager.HandleKicked();
	}

	[TargetRpc]
	public void TargetKickFromLobby(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void GamePlayer::TargetKickFromLobby(Mirror.NetworkConnectionToClient)", -946663720, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerKickPlayer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GamePlayer::ServerKickPlayer()' called when server was not active");
			return;
		}
		Debug.Log("[GamePlayer] Server kicking player: " + playerName + ")");
		if (base.connectionToClient != null)
		{
			Debug.Log($"[GamePlayer] Server kicking player: {playerName} (ConnectionId: {ownerConnectionId})");
			TargetKickFromLobby(base.connectionToClient);
			StartCoroutine(DelayedDisconnect());
		}
	}

	private IEnumerator DelayedDisconnect()
	{
		yield return new WaitForSeconds(0.5f);
		if (base.connectionToClient != null)
		{
			base.connectionToClient.Disconnect();
		}
	}

	private void ConnectPlayer()
	{
		CmdSetPlayerName(SteamFriends.GetPersonaName().ToString());
		if (!GameManager.Instance.playerProgressManager.disableSteamworks)
		{
			SendLocalPlayerSteamID((ulong)SteamUser.GetSteamID());
		}
		else
		{
			CmdSetPlayerSteamID((ulong)ownerConnectionId + 1uL);
		}
		base.OnStartAuthority();
	}

	[Command]
	private void CmdSetPlayerName(string playerName)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetPlayerName__String(playerName);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		SendCommandInternal("System.Void GamePlayer::CmdSetPlayerName(System.String)", 1733093392, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void SendLocalPlayerSteamID(ulong id)
	{
		CmdSetPlayerSteamID(id);
	}

	[Command]
	private void CmdSetPlayerSteamID(ulong steamID)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetPlayerSteamID__UInt64(steamID);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(steamID);
		SendCommandInternal("System.Void GamePlayer::CmdSetPlayerSteamID(System.UInt64)", 189593607, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void SetIsInDigsite(bool value)
	{
		if (base.isServer)
		{
			NetworkisInDigsite = value;
			ServerSaveDigsiteStatus(value);
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
		SendCommandInternal("System.Void GamePlayer::CmdSetIsInDigsite(System.Boolean)", 1493664961, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnDigsiteStatusChanged(bool oldValue, bool newValue)
	{
	}

	private void ServerSaveDigsiteStatus(bool value)
	{
		if (PlayerProgressManager.Instance != null && playerSteamId != 0L)
		{
			PlayerProgressManager.Instance.Server_SetPlayerInDigsite(playerSteamId, value);
		}
	}

	private void ServerSaveCustomization(string packed)
	{
		if (PlayerProgressManager.Instance != null && playerSteamId != 0L)
		{
			PlayerProgressManager.Instance.Server_SetPlayerCustomization(playerSteamId, packed);
		}
	}

	public void HandlePlayerNameUpdate(string oldValue, string newValue)
	{
		if (base.isServer)
		{
			NetworkplayerName = newValue;
		}
		StartCoroutine(SetPlayerNameWithDelay());
		if (base.isLocalPlayer)
		{
			base.gameObject.name = newValue;
		}
	}

	private IEnumerator SetPlayerNameWithDelay()
	{
		yield return new WaitForSeconds(0.2f);
		playerNameText.text = playerName;
	}

	public void CheckCanGetUp()
	{
		Camera main = Camera.main;
		if (!(main == null) && !Physics.Raycast(main.transform.position, Vector3.up, standUpCheckDistance, standUpLayerMask))
		{
			canGetUp?.Invoke();
		}
	}

	public void NetworkTeleport(Vector3 pos, Quaternion rot)
	{
		if (base.isServer)
		{
			ApplyTeleportLocal(pos, rot);
			RpcTeleport(pos, rot);
		}
		else
		{
			ApplyTeleportLocal(pos, rot);
			CmdTeleport(pos, rot);
		}
	}

	[Command]
	private void CmdTeleport(Vector3 pos, Quaternion rot)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTeleport__Vector3__Quaternion(pos, rot);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendCommandInternal("System.Void GamePlayer::CmdTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", -1795811979, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcTeleport(Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendRPCInternal("System.Void GamePlayer::RpcTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", -1902055394, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ApplyTeleportLocal(Vector3 pos, Quaternion rot)
	{
		CharacterController component = GetComponent<CharacterController>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.transform.SetPositionAndRotation(pos, rot);
		if (component != null)
		{
			component.enabled = true;
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdConvertBagToSack(List<string> itemIds, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdConvertBagToSack__List_00601__NetworkConnectionToClient(itemIds, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, itemIds);
		SendCommandInternal("System.Void GamePlayer::CmdConvertBagToSack(System.Collections.Generic.List`1<System.String>,Mirror.NetworkConnectionToClient)", -1444988649, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdConvertItemTypeToSack(string itemTypeId, List<string> itemIds, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdConvertItemTypeToSack__String__List_00601__NetworkConnectionToClient(itemTypeId, itemIds, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemTypeId);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, itemIds);
		SendCommandInternal("System.Void GamePlayer::CmdConvertItemTypeToSack(System.String,System.Collections.Generic.List`1<System.String>,Mirror.NetworkConnectionToClient)", 1127877316, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	public void TargetRpcPickupSpawnedSack(NetworkConnectionToClient target, uint sackNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendTargetRPCInternal(target, "System.Void GamePlayer::TargetRpcPickupSpawnedSack(Mirror.NetworkConnectionToClient,System.UInt32)", 584941003, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ContextMenu("Randomize For All")]
	public void RandomizeForAll()
	{
		if (base.isServer)
		{
			ServerRandomizeAndBroadcast();
		}
		else
		{
			CmdRequestServerRandomize();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestServerRandomize(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestServerRandomize__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void GamePlayer::CmdRequestServerRandomize(Mirror.NetworkConnectionToClient)", 896745440, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerRandomizeAndBroadcast()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GamePlayer::ServerRandomizeAndBroadcast()' called when server was not active");
		}
		else if (!(skinWrapper == null))
		{
			string packed = (NetworkcustomizationIDs = BuildRandomCustomizationPacked());
			ServerSaveCustomization(packed);
		}
	}

	private string BuildRandomCustomizationPacked()
	{
		SkinWrapper skinWrapper = this.skinWrapper;
		int num = SafeRand(skinWrapper.headRef);
		int num2 = SafeRand(skinWrapper.topRef);
		int num3 = SafeRand(skinWrapper.bottomRef);
		int num4 = SafeRand(skinWrapper.helmetRef);
		int num5 = SafeRand(skinWrapper.beltRef);
		int num6 = SafeRand(skinWrapper.bootsRef);
		int num7 = ((num2 < 2) ? ((skinWrapper.closeGlovesRef != null) ? skinWrapper.closeGlovesRef.Count : 0) : ((skinWrapper.openGlovesRef != null) ? skinWrapper.openGlovesRef.Count : 0));
		int num8 = ((num7 > 0) ? UnityEngine.Random.Range(0, num7) : 0);
		int num9 = SafeRandMat(skinWrapper.topMaterials, num2);
		int num10 = SafeRandMat(skinWrapper.bottomMaterials, num3);
		int num11 = SafeRandMat(skinWrapper.glovesMaterials, num8);
		int num12 = SafeRandMat(skinWrapper.helmetMaterials, num4);
		int num13 = SafeRandMat(skinWrapper.bootsMaterials, num6);
		return $"{num} {num2} {num3} {num4} {num8} {num6} {num5} {num9} {num10} {num11} {num12} {num13}";
		static int SafeRand(List<SkinnedMeshRenderer> list)
		{
			int num14 = list?.Count ?? 0;
			if (num14 <= 0)
			{
				return 0;
			}
			return UnityEngine.Random.Range(0, num14);
		}
		static int SafeRandMat(List<ClothingMaterialEntry> entries, int meshIndex)
		{
			if (entries == null || meshIndex < 0 || meshIndex >= entries.Count)
			{
				return 0;
			}
			int num14 = ((entries[meshIndex].materials != null) ? entries[meshIndex].materials.Count : 0);
			if (num14 <= 0)
			{
				return 0;
			}
			return UnityEngine.Random.Range(0, num14);
		}
	}

	private void TryRandomizeCustomizationAtStartServer()
	{
		if (base.isServer)
		{
			StartCoroutine(ServerRestoreOrRandomizeCustomization());
		}
	}

	private IEnumerator ServerRestoreOrRandomizeCustomization()
	{
		float timeout = 5f;
		float elapsed = 0f;
		while (playerSteamId == 0L && elapsed < timeout)
		{
			elapsed += 0.25f;
			yield return new WaitForSeconds(0.5f);
		}
		if (playerSteamId == 0L && base.isServer && base.connectionToClient != null)
		{
			NetworkplayerSteamId = (ulong)base.connectionToClient.connectionId + 1uL;
			Debug.Log($"[GamePlayer] Host fallback steamId atandı: {playerSteamId}");
		}
		if (PlayerProgressManager.Instance != null && playerSteamId != 0L && string.IsNullOrWhiteSpace(customizationIDs))
		{
			string text = PlayerProgressManager.Instance.Server_GetPlayerCustomization(playerSteamId);
			if (!string.IsNullOrWhiteSpace(text))
			{
				NetworkcustomizationIDs = text;
				yield break;
			}
		}
		if (string.IsNullOrWhiteSpace(customizationIDs) && !(skinWrapper == null))
		{
			NetworkcustomizationIDs = BuildRandomCustomizationPacked();
			ServerSaveCustomization(customizationIDs);
		}
	}

	public void Respawn()
	{
		GameManager instance = GameManager.Instance;
		if (instance == null)
		{
			Debug.LogWarning("[GamePlayer] Respawn - GameManager bulunamadı!");
			return;
		}
		Transform transform = (isInDigsite ? instance.digsiteMarker : instance.factoryMarker);
		if (transform == null)
		{
			Debug.LogWarning($"[GamePlayer] Respawn - Hedef marker null! isInDigsite: {isInDigsite}");
			return;
		}
		Debug.Log($"[GamePlayer] Respawn - {playerName} -> {transform.name} (isInDigsite: {isInDigsite})");
		NetworkTeleport(transform.position, transform.rotation);
	}

	public void EmergencyRescue()
	{
		LocalRespawn();
		if ((!(TutorialManager.Instance != null) || !TutorialManager.Instance.IsTutorialRunning) && isInDigsite)
		{
			T_Bag t_Bag = GetComponent<T_Bag>();
			if (t_Bag == null && base.transform.parent != null)
			{
				t_Bag = base.transform.parent.GetComponentInChildren<T_Bag>();
			}
			if (t_Bag != null)
			{
				t_Bag.RemoveHalfItems();
			}
			Debug.Log("[GamePlayer] EmergencyRescue - " + playerName + " kurtarıldı, %50 item kaybedildi.");
		}
	}

	private void LocalRespawn()
	{
		GameManager instance = GameManager.Instance;
		if (instance == null)
		{
			return;
		}
		Transform transform = (isInDigsite ? instance.digsiteMarker : instance.factoryMarker);
		if (!(transform == null))
		{
			CharacterController component = GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = false;
			}
			base.transform.SetPositionAndRotation(transform.position, transform.rotation);
			if (component != null)
			{
				component.enabled = true;
			}
			Debug.Log("[GamePlayer] LocalRespawn - " + playerName + " -> " + transform.name);
		}
	}

	public void SendDamage(float damageValue)
	{
		if (NetworkServer.active)
		{
			ServerReceiveDamage(damageValue);
		}
		else
		{
			CmdReceiveDamage(damageValue);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdReceiveDamage(float damageValue, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdReceiveDamage__Single__NetworkConnectionToClient(damageValue, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damageValue);
		SendCommandInternal("System.Void GamePlayer::CmdReceiveDamage(System.Single,Mirror.NetworkConnectionToClient)", -27581946, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerReceiveDamage(float damageValue)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GamePlayer::ServerReceiveDamage(System.Single)' called when server was not active");
		}
		else if (base.connectionToClient != null)
		{
			TargetReceiveDamage(base.connectionToClient, damageValue);
			Debug.Log($"[GamePlayer] Server: Damage sent to {playerName}: {damageValue}");
		}
	}

	[TargetRpc]
	public void TargetReceiveDamage(NetworkConnectionToClient target, float damageValue)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damageValue);
		SendTargetRPCInternal(target, "System.Void GamePlayer::TargetReceiveDamage(Mirror.NetworkConnectionToClient,System.Single)", 648636473, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Client]
	public void SetCustomizationByIds(int head, int top, int bottom, int helmet, int gloves, int boots, int belt, int topMat = 0, int bottomMat = 0, int glovesMat = 0, int helmetMat = 0, int bootsMat = 0)
	{
		if (!NetworkClient.active)
		{
			Debug.LogWarning("[Client] function 'System.Void GamePlayer::SetCustomizationByIds(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)' called when client was not active");
			return;
		}
		string packed = PackIds(head, top, bottom, helmet, gloves, boots, belt, topMat, bottomMat, glovesMat, helmetMat, bootsMat);
		CmdSetCustomizationIDs(packed);
	}

	[Client]
	public void SetCustomizationByString(string packed)
	{
		if (!NetworkClient.active)
		{
			Debug.LogWarning("[Client] function 'System.Void GamePlayer::SetCustomizationByString(System.String)' called when client was not active");
		}
		else
		{
			CmdSetCustomizationIDs(packed);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetCustomizationIDs(string packed, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSetCustomizationIDs__String__NetworkConnectionToClient(packed, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(packed);
		SendCommandInternal("System.Void GamePlayer::CmdSetCustomizationIDs(System.String,Mirror.NetworkConnectionToClient)", -824560586, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnCustomizationChanged(string oldValue, string newValue)
	{
		ParseAndAssignIds(newValue);
		ApplyCustomization();
		if (base.isServer)
		{
			ServerSaveCustomization(newValue);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		RegisterToNetworkManager();
		if (!string.IsNullOrWhiteSpace(customizationIDs))
		{
			ParseAndAssignIds(customizationIDs);
			ApplyCustomization();
		}
	}

	private void RegisterToNetworkManager()
	{
		if (NetworkManager.singleton is NewNetworkManager newNetworkManager)
		{
			newNetworkManager.RegisterGamePlayer(this);
		}
	}

	private void UnregisterFromNetworkManager()
	{
		if (NetworkManager.singleton is NewNetworkManager newNetworkManager)
		{
			newNetworkManager.UnregisterGamePlayer(this);
		}
	}

	private static string PackIds(int head, int top, int bottom, int helmet, int gloves, int boots, int belt, int topMat = 0, int bottomMat = 0, int glovesMat = 0, int helmetMat = 0, int bootsMat = 0)
	{
		return $"{head} {top} {bottom} {helmet} {gloves} {boots} {belt} {topMat} {bottomMat} {glovesMat} {helmetMat} {bootsMat}";
	}

	private void ParseAndAssignIds(string packed)
	{
		string[] array = packed.Split(' ');
		int[] array2 = new int[12];
		for (int i = 0; i < array2.Length; i++)
		{
			if (i < array.Length && int.TryParse(array[i], out var result))
			{
				array2[i] = Mathf.Max(0, result);
			}
			else
			{
				array2[i] = 0;
			}
		}
		headID = array2[0];
		topID = array2[1];
		bottomID = array2[2];
		helmetID = array2[3];
		glovesID = array2[4];
		bootsID = array2[5];
		beltID = array2[6];
		topMatID = array2[7];
		bottomMatID = array2[8];
		glovesMatID = array2[9];
		helmetMatID = array2[10];
		bootsMatID = array2[11];
	}

	private void ApplyCustomization()
	{
		if (skinWrapper != null)
		{
			skinWrapper.ApplyCustomization(headID, topID, bottomID, helmetID, glovesID, bootsID, beltID, topMatID, bottomMatID, glovesMatID, helmetMatID, bootsMatID);
		}
	}

	public GamePlayer()
	{
		_Mirror_SyncVarHookDelegate_playerName = HandlePlayerNameUpdate;
		_Mirror_SyncVarHookDelegate_isInDigsite = OnDigsiteStatusChanged;
		_Mirror_SyncVarHookDelegate_customizationIDs = OnCustomizationChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_TargetKickFromLobby__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		Debug.Log("[GamePlayer] Kick komutu alındı, lobby'den çıkılıyor...");
		LeaveSteamLobbyAndReturnToMenu();
	}

	protected static void InvokeUserCode_TargetKickFromLobby__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetKickFromLobby called on server.");
		}
		else
		{
			((GamePlayer)obj).UserCode_TargetKickFromLobby__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_CmdSetPlayerName__String(string playerName)
	{
		HandlePlayerNameUpdate(this.playerName, playerName);
	}

	protected static void InvokeUserCode_CmdSetPlayerName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPlayerName called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdSetPlayerName__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdSetPlayerSteamID__UInt64(ulong steamID)
	{
		NetworkplayerSteamId = steamID;
	}

	protected static void InvokeUserCode_CmdSetPlayerSteamID__UInt64(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPlayerSteamID called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdSetPlayerSteamID__UInt64(reader.ReadVarULong());
		}
	}

	protected void UserCode_CmdSetIsInDigsite__Boolean(bool value)
	{
		NetworkisInDigsite = value;
		ServerSaveDigsiteStatus(value);
	}

	protected static void InvokeUserCode_CmdSetIsInDigsite__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetIsInDigsite called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdSetIsInDigsite__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_CmdTeleport__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		ApplyTeleportLocal(pos, rot);
		RpcTeleport(pos, rot);
	}

	protected static void InvokeUserCode_CmdTeleport__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTeleport called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdTeleport__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcTeleport__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		ApplyTeleportLocal(pos, rot);
	}

	protected static void InvokeUserCode_RpcTeleport__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTeleport called on server.");
		}
		else
		{
			((GamePlayer)obj).UserCode_RpcTeleport__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdConvertBagToSack__List_00601__NetworkConnectionToClient(List<string> itemIds, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("GamePlayer: CmdConvertBagToSack - sender null!");
			return;
		}
		List<T_ItemSO> list = new List<T_ItemSO>();
		if ((bool)ItemSOManager.Instance)
		{
			foreach (string itemId in itemIds)
			{
				if (!string.IsNullOrEmpty(itemId))
				{
					T_ItemSO t_ItemSO = ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == itemId);
					if (t_ItemSO != null)
					{
						list.Add(t_ItemSO);
					}
				}
			}
		}
		T_Bag t_Bag = null;
		if (sender.identity != null)
		{
			t_Bag = sender.identity.GetComponent<T_Bag>();
		}
		if (t_Bag == null)
		{
			GamePlayer[] array = UnityEngine.Object.FindObjectsByType<GamePlayer>(FindObjectsSortMode.None);
			foreach (GamePlayer gamePlayer in array)
			{
				if (gamePlayer.connectionToClient == sender)
				{
					t_Bag = gamePlayer.GetComponent<T_Bag>();
					if (t_Bag == null && gamePlayer.transform.parent != null)
					{
						t_Bag = gamePlayer.transform.parent.GetComponentInChildren<T_Bag>();
					}
					break;
				}
			}
		}
		if (t_Bag == null && GameManager.Instance != null)
		{
			t_Bag = GameManager.Instance.localBag;
		}
		if (t_Bag == null)
		{
			Debug.LogError($"GamePlayer: CmdConvertBagToSack - T_Bag bulunamadı! Sender: {sender.connectionId}");
		}
		else
		{
			t_Bag.ServerConvertToSack(list, sender);
		}
	}

	protected static void InvokeUserCode_CmdConvertBagToSack__List_00601__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdConvertBagToSack called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdConvertBagToSack__List_00601__NetworkConnectionToClient(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), senderConnection);
		}
	}

	protected void UserCode_CmdConvertItemTypeToSack__String__List_00601__NetworkConnectionToClient(string itemTypeId, List<string> itemIds, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("GamePlayer: CmdConvertItemTypeToSack - sender null!");
			return;
		}
		List<T_ItemSO> list = new List<T_ItemSO>();
		if ((bool)ItemSOManager.Instance)
		{
			foreach (string itemId in itemIds)
			{
				if (!string.IsNullOrEmpty(itemId))
				{
					T_ItemSO t_ItemSO = ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == itemId);
					if (t_ItemSO != null)
					{
						list.Add(t_ItemSO);
					}
				}
			}
		}
		T_Bag t_Bag = null;
		if (sender.identity != null)
		{
			t_Bag = sender.identity.GetComponent<T_Bag>();
		}
		if (t_Bag == null)
		{
			GamePlayer[] array = UnityEngine.Object.FindObjectsByType<GamePlayer>(FindObjectsSortMode.None);
			foreach (GamePlayer gamePlayer in array)
			{
				if (gamePlayer.connectionToClient == sender)
				{
					t_Bag = gamePlayer.GetComponent<T_Bag>();
					if (t_Bag == null && gamePlayer.transform.parent != null)
					{
						t_Bag = gamePlayer.transform.parent.GetComponentInChildren<T_Bag>();
					}
					break;
				}
			}
		}
		if (t_Bag == null && GameManager.Instance != null)
		{
			t_Bag = GameManager.Instance.localBag;
		}
		if (t_Bag == null)
		{
			Debug.LogError($"GamePlayer: CmdConvertItemTypeToSack - T_Bag bulunamadı! Sender: {sender.connectionId}");
		}
		else
		{
			t_Bag.ServerConvertItemTypeToSack(list, sender);
		}
	}

	protected static void InvokeUserCode_CmdConvertItemTypeToSack__String__List_00601__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdConvertItemTypeToSack called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdConvertItemTypeToSack__String__List_00601__NetworkConnectionToClient(reader.ReadString(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), senderConnection);
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
				Debug.Log($"[GamePlayer] Sack otomatik pickup yapıldı. NetId: {sackNetId}");
			}
			else
			{
				Debug.LogWarning($"[GamePlayer] Sack üzerinde T_Pickup component'i bulunamadı. NetId: {sackNetId}");
			}
		}
		else
		{
			Debug.LogWarning($"[GamePlayer] Sack bulunamadı. NetId: {sackNetId}");
		}
	}

	protected static void InvokeUserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetRpcPickupSpawnedSack called on server.");
		}
		else
		{
			((GamePlayer)obj).UserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32(null, reader.ReadVarUInt());
		}
	}

	protected void UserCode_CmdRequestServerRandomize__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerRandomizeAndBroadcast();
	}

	protected static void InvokeUserCode_CmdRequestServerRandomize__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestServerRandomize called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdRequestServerRandomize__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdReceiveDamage__Single__NetworkConnectionToClient(float damageValue, NetworkConnectionToClient sender)
	{
		ServerReceiveDamage(damageValue);
	}

	protected static void InvokeUserCode_CmdReceiveDamage__Single__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReceiveDamage called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdReceiveDamage__Single__NetworkConnectionToClient(reader.ReadFloat(), senderConnection);
		}
	}

	protected void UserCode_TargetReceiveDamage__NetworkConnectionToClient__Single(NetworkConnectionToClient target, float damageValue)
	{
		if (globalNameVariables == null)
		{
			Debug.LogWarning("[GamePlayer] TargetReceiveDamage: globalNameVariables null! Player: " + playerName);
			return;
		}
		globalNameVariables.Set("Damage-Value", (int)damageValue);
		Debug.Log($"[GamePlayer] {playerName} received damage: {damageValue}");
	}

	protected static void InvokeUserCode_TargetReceiveDamage__NetworkConnectionToClient__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetReceiveDamage called on server.");
		}
		else
		{
			((GamePlayer)obj).UserCode_TargetReceiveDamage__NetworkConnectionToClient__Single(null, reader.ReadFloat());
		}
	}

	protected void UserCode_CmdSetCustomizationIDs__String__NetworkConnectionToClient(string packed, NetworkConnectionToClient sender)
	{
		if (!string.IsNullOrWhiteSpace(packed))
		{
			NetworkcustomizationIDs = packed;
		}
	}

	protected static void InvokeUserCode_CmdSetCustomizationIDs__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetCustomizationIDs called on client.");
		}
		else
		{
			((GamePlayer)obj).UserCode_CmdSetCustomizationIDs__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	static GamePlayer()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdSetPlayerName(System.String)", InvokeUserCode_CmdSetPlayerName__String, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdSetPlayerSteamID(System.UInt64)", InvokeUserCode_CmdSetPlayerSteamID__UInt64, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdSetIsInDigsite(System.Boolean)", InvokeUserCode_CmdSetIsInDigsite__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdTeleport__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdConvertBagToSack(System.Collections.Generic.List`1<System.String>,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdConvertBagToSack__List_00601__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdConvertItemTypeToSack(System.String,System.Collections.Generic.List`1<System.String>,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdConvertItemTypeToSack__String__List_00601__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdRequestServerRandomize(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestServerRandomize__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdReceiveDamage(System.Single,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdReceiveDamage__Single__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GamePlayer), "System.Void GamePlayer::CmdSetCustomizationIDs(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSetCustomizationIDs__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(GamePlayer), "System.Void GamePlayer::RpcTeleport(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleport__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(GamePlayer), "System.Void GamePlayer::TargetKickFromLobby(Mirror.NetworkConnectionToClient)", InvokeUserCode_TargetKickFromLobby__NetworkConnectionToClient);
		RemoteProcedureCalls.RegisterRpc(typeof(GamePlayer), "System.Void GamePlayer::TargetRpcPickupSpawnedSack(Mirror.NetworkConnectionToClient,System.UInt32)", InvokeUserCode_TargetRpcPickupSpawnedSack__NetworkConnectionToClient__UInt32);
		RemoteProcedureCalls.RegisterRpc(typeof(GamePlayer), "System.Void GamePlayer::TargetReceiveDamage(Mirror.NetworkConnectionToClient,System.Single)", InvokeUserCode_TargetReceiveDamage__NetworkConnectionToClient__Single);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(playerName);
			writer.WriteVarULong(playerSteamId);
			writer.WriteVarInt(ownerConnectionId);
			writer.WriteBool(isInDigsite);
			writer.WriteString(customizationIDs);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(playerName);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarULong(playerSteamId);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteVarInt(ownerConnectionId);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(isInDigsite);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteString(customizationIDs);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref playerName, _Mirror_SyncVarHookDelegate_playerName, reader.ReadString());
			GeneratedSyncVarDeserialize(ref playerSteamId, null, reader.ReadVarULong());
			GeneratedSyncVarDeserialize(ref ownerConnectionId, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isInDigsite, _Mirror_SyncVarHookDelegate_isInDigsite, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref customizationIDs, _Mirror_SyncVarHookDelegate_customizationIDs, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref playerName, _Mirror_SyncVarHookDelegate_playerName, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref playerSteamId, null, reader.ReadVarULong());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref ownerConnectionId, null, reader.ReadVarInt());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInDigsite, _Mirror_SyncVarHookDelegate_isInDigsite, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref customizationIDs, _Mirror_SyncVarHookDelegate_customizationIDs, reader.ReadString());
		}
	}
}
