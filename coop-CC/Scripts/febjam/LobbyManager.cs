using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class LobbyManager : NetworkAggroManagerBase<LobbyManager>, IInputController
{
	public enum LobbyState : byte
	{
		Waiting = 0,
		Transitioning = 1
	}

	[Min(0f)]
	public float durationBeforeFade;

	public GameObject firstSelectedButton;

	[SyncVar]
	private int _syncContractIndex;

	[SyncVar]
	private int _syncHostTotalBells;

	private bool _serverTransitioning;

	private ulong _saveVersion;

	private List<ContractObject> _allContracts = new List<ContractObject>();

	private List<LobbyPlayer> _serverAvailablePlayers = new List<LobbyPlayer>();

	private string[] _sceneBuildIndices;

	private LobbyState _state;

	public int hostTotalBells => _syncHostTotalBells;

	public LobbyState state => _state;

	public int Network_syncContractIndex
	{
		get
		{
			return _syncContractIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncContractIndex, 1uL, null);
		}
	}

	public int Network_syncHostTotalBells
	{
		get
		{
			return _syncHostTotalBells;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncHostTotalBells, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_state = LobbyState.Waiting;
		AudioManager.PlayLobbyTitleMusic();
		GameManager.GetAllContracts(_allContracts);
		if (base.isServer)
		{
			NetworkAggroManagerBase<PlayersManager>.instance.ServerStartProceed(useTimer: true);
			if (SaveManager.data.TryGetLastPlayedContract(out var contract))
			{
				Network_syncContractIndex = math.max(_allContracts.IndexOf(contract), 0);
			}
			else
			{
				Network_syncContractIndex = 0;
			}
			ServerSetContract();
			CheckForAndUpdateTotalBells();
		}
	}

	protected override void OnEntityStart()
	{
		if (base.isServer)
		{
			base.entityManager.GetAllObjects(_serverAvailablePlayers);
			_serverAvailablePlayers.Sort((LobbyPlayer x, LobbyPlayer y) => x.lobbyPlayerIndex.CompareTo(y.lobbyPlayerIndex));
		}
	}

	protected override void OnEntityDestroyed()
	{
		AggroInputManager.RemoveController(this);
	}

	public int GetContractIndex()
	{
		return _syncContractIndex;
	}

	public ContractObject GetContract()
	{
		if (_syncContractIndex > _allContracts.Count - 1 || _syncContractIndex < 0)
		{
			return null;
		}
		return _allContracts[_syncContractIndex];
	}

	public bool IsCurrentContractUnlocked()
	{
		ContractObject contract = GetContract();
		if (contract == null)
		{
			return false;
		}
		if (!contract.isDemoLocked)
		{
			return _syncHostTotalBells >= contract.bellsRequired;
		}
		return false;
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer && !_serverTransitioning)
		{
			CheckForAndUpdateTotalBells();
			if (NetworkAggroManagerBase<PlayersManager>.instance.ServerProcessProceed())
			{
				StartCoroutine(TransitionToRunCo());
			}
		}
	}

	private void CheckForAndUpdateTotalBells()
	{
		if (_saveVersion != SaveManager.data.GetVersion())
		{
			_saveVersion = SaveManager.data.GetVersion();
			if (SaveManager.data.IsDebugUnlocked())
			{
				Network_syncHostTotalBells = 999;
			}
			else
			{
				Network_syncHostTotalBells = SaveManager.data.GetTotalBells();
			}
		}
	}

	public void RequestCycleLeft()
	{
		CmdCycleLeft();
	}

	public void RequestCycleRight()
	{
		CmdCycleRight();
	}

	[Command(requiresAuthority = false)]
	private void CmdCycleLeft()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void LobbyManager::CmdCycleLeft()", 1291350087, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdCycleRight()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void LobbyManager::CmdCycleRight()", 529254950, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetContract()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyManager::ServerSetContract()' called when server was not active");
		}
		else
		{
			GameManager.selectedRunContract = _allContracts[_syncContractIndex];
		}
	}

	public void DevCmdStartWarehouse()
	{
		CmdStartDevCmd();
	}

	[Command(requiresAuthority = false)]
	private void CmdStartDevCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void LobbyManager::CmdStartDevCmd()", 272315305, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator TransitionToRunCo()
	{
		_serverTransitioning = true;
		AggroNetworkManager.DisableHost();
		RpcRunStarting();
		yield return new WaitForSeconds(durationBeforeFade);
		RpcFade();
		yield return NetworkAggroManagerBase<PlayersManager>.instance.ServerPlayerProceedReadyCo(useTimer: false);
		GameManager.NextRun();
	}

	[ClientRpc]
	private void RpcRunStarting()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void LobbyManager::RpcRunStarting()", -896244380, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcFade()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void LobbyManager::RpcFade()", 1354234551, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ClientFadeForLoadCo()
	{
		yield return FadeManager.FadeInCo();
		NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
	}

	[Server]
	public void ServerAddPlayer(NetworkConnectionToClient conn, int playerIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyManager::ServerAddPlayer(Mirror.NetworkConnectionToClient,System.Int32)' called when server was not active");
			return;
		}
		LobbyPlayer lobbyPlayer = _serverAvailablePlayers[playerIndex];
		NetworkServer.AddPlayerForConnection(conn, lobbyPlayer.entity.gameObject);
		lobbyPlayer.ServerPlayerAssigned();
		NetworkAggroManagerBase<VoiceOverManager>.instance.ServerPlayLobbyPlayerJoined();
	}

	[Server]
	public void ServerDisconnected(NetworkConnectionToClient conn, int playerIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyManager::ServerDisconnected(Mirror.NetworkConnectionToClient,System.Int32)' called when server was not active");
			return;
		}
		NetworkServer.RemovePlayerForConnection(conn);
		_serverAvailablePlayers[playerIndex].ServerPlayerUnassigned();
	}

	[Server]
	public void ServerStartContract(int contractIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void LobbyManager::ServerStartContract(System.Int32)' called when server was not active");
			return;
		}
		Network_syncContractIndex = contractIndex % _allContracts.Count;
		ServerSetContract();
		StartCoroutine(TransitionToRunCo());
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
		AggroInputManager.input.Lobby.Enable();
		EventSystem.current.SetSelectedGameObject(firstSelectedButton);
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.Lobby.Disable();
		AggroInputManager.DisableUIModule();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdCycleLeft()
	{
		if (!_serverTransitioning && _syncContractIndex > 0)
		{
			Network_syncContractIndex = _syncContractIndex - 1;
			ServerSetContract();
			NetworkAggroManagerBase<PlayersManager>.instance.ServerResetProceeding();
			NetworkAggroManagerBase<PlayersManager>.instance.serverSuppressProceed = false;
		}
	}

	protected static void InvokeUserCode_CmdCycleLeft(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCycleLeft called on client.");
		}
		else
		{
			((LobbyManager)obj).UserCode_CmdCycleLeft();
		}
	}

	protected void UserCode_CmdCycleRight()
	{
		if (!_serverTransitioning && _syncContractIndex < _allContracts.Count - 1)
		{
			Network_syncContractIndex = _syncContractIndex + 1;
			ServerSetContract();
			NetworkAggroManagerBase<PlayersManager>.instance.ServerResetProceeding();
			NetworkAggroManagerBase<PlayersManager>.instance.serverSuppressProceed = _syncContractIndex == _allContracts.Count;
		}
	}

	protected static void InvokeUserCode_CmdCycleRight(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCycleRight called on client.");
		}
		else
		{
			((LobbyManager)obj).UserCode_CmdCycleRight();
		}
	}

	protected void UserCode_CmdStartDevCmd()
	{
		StartCoroutine(TransitionToRunCo());
	}

	protected static void InvokeUserCode_CmdStartDevCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartDevCmd called on client.");
		}
		else
		{
			((LobbyManager)obj).UserCode_CmdStartDevCmd();
		}
	}

	protected void UserCode_RpcRunStarting()
	{
		_state = LobbyState.Transitioning;
		AggroInputManager.Disable();
	}

	protected static void InvokeUserCode_RpcRunStarting(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRunStarting called on server.");
		}
		else
		{
			((LobbyManager)obj).UserCode_RpcRunStarting();
		}
	}

	protected void UserCode_RpcFade()
	{
		StartCoroutine(ClientFadeForLoadCo());
	}

	protected static void InvokeUserCode_RpcFade(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcFade called on server.");
		}
		else
		{
			((LobbyManager)obj).UserCode_RpcFade();
		}
	}

	static LobbyManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(LobbyManager), "System.Void LobbyManager::CmdCycleLeft()", InvokeUserCode_CmdCycleLeft, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(LobbyManager), "System.Void LobbyManager::CmdCycleRight()", InvokeUserCode_CmdCycleRight, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(LobbyManager), "System.Void LobbyManager::CmdStartDevCmd()", InvokeUserCode_CmdStartDevCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(LobbyManager), "System.Void LobbyManager::RpcRunStarting()", InvokeUserCode_RpcRunStarting);
		RemoteProcedureCalls.RegisterRpc(typeof(LobbyManager), "System.Void LobbyManager::RpcFade()", InvokeUserCode_RpcFade);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_syncContractIndex);
			writer.WriteVarInt(_syncHostTotalBells);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncContractIndex);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_syncHostTotalBells);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncContractIndex, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _syncHostTotalBells, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncContractIndex, null, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncHostTotalBells, null, reader.ReadVarInt());
		}
	}
}
