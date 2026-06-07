using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkLoadingSync : NetworkBehaviour
{
	private HashSet<NetworkConnection> joiningPlayers = new HashSet<NetworkConnection>();

	public static NetworkLoadingSync Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	[Server]
	public void ServerOnPlayerJoining(NetworkConnection joiningConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerOnPlayerJoining(Mirror.NetworkConnection)' called when server was not active");
			return;
		}
		joiningPlayers.Add(joiningConnection);
		TargetShowLoading(joiningConnection, LoadingType.Scene);
		ServerShowLoadingExcept(joiningConnection, LoadingType.PlayerJoining);
	}

	[Server]
	public void ServerOnPlayerJoined(NetworkConnection joinedConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerOnPlayerJoined(Mirror.NetworkConnection)' called when server was not active");
		}
	}

	[Server]
	public void ServerOnPlayerLeft(NetworkConnection leftConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerOnPlayerLeft(Mirror.NetworkConnection)' called when server was not active");
			return;
		}
		bool num = joiningPlayers.Contains(leftConnection);
		joiningPlayers.Remove(leftConnection);
		if (num && joiningPlayers.Count == 0)
		{
			ServerHideLoading(LoadingType.PlayerJoining);
		}
	}

	[Server]
	public void ServerOnPlayerSceneLoaded(NetworkConnection connection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerOnPlayerSceneLoaded(Mirror.NetworkConnection)' called when server was not active");
			return;
		}
		joiningPlayers.Remove(connection);
		if (joiningPlayers.Count == 0)
		{
			ServerHideLoading(LoadingType.PlayerJoining);
		}
	}

	[Server]
	public void ServerShowLoadingExcept(NetworkConnection exceptConnection, LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerShowLoadingExcept(Mirror.NetworkConnection,LoadingType)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected && NetworkServer.localConnection != exceptConnection)
		{
			LoadingManagerUI.Show(loadingType);
		}
		foreach (NetworkConnectionToClient value in NetworkServer.connections.Values)
		{
			if (value != null && value != exceptConnection && value.isReady)
			{
				TargetShowLoading(value, loadingType);
			}
		}
	}

	[Server]
	public void ServerHideLoadingExcept(NetworkConnection exceptConnection, LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideLoadingExcept(Mirror.NetworkConnection,LoadingType)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected && NetworkServer.localConnection != exceptConnection)
		{
			LoadingManagerUI.Hide(loadingType);
		}
		foreach (NetworkConnectionToClient value in NetworkServer.connections.Values)
		{
			if (value != null && value != exceptConnection && value.isReady)
			{
				TargetHideLoading(value, loadingType);
			}
		}
	}

	[Server]
	public void ServerShowLoading(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerShowLoading(LoadingType)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.Show(loadingType);
		}
		RpcShowLoading(loadingType);
	}

	[Server]
	public void ServerHideLoading(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideLoading(LoadingType)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.Hide(loadingType);
		}
		RpcHideLoading(loadingType);
	}

	[Server]
	public void ServerHideAll()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideAll()' called when server was not active");
			return;
		}
		if (SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			Debug.Log("[NetworkLoadingSync] ServerHideAll atlandı - load pending/in progress.");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.HideAll();
		}
		RpcHideAll();
	}

	[Server]
	public void ServerHideLoadingImmediate(LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideLoadingImmediate(LoadingType)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.HideImmediate(loadingType);
		}
		RpcHideLoadingImmediate(loadingType);
	}

	[Server]
	public void ServerHideAllImmediate()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideAllImmediate()' called when server was not active");
			return;
		}
		if (SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			Debug.Log("[NetworkLoadingSync] ServerHideAllImmediate atlandı - load pending/in progress.");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.HideAllImmediate();
		}
		RpcHideAllImmediate();
	}

	[Server]
	public void ServerUpdateReason(string reason)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerUpdateReason(System.String)' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			LoadingManagerUI.UpdateReason(reason);
		}
		RpcUpdateReason(reason);
	}

	[Server]
	public void ServerShowLoadingToTarget(NetworkConnection target, LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerShowLoadingToTarget(Mirror.NetworkConnection,LoadingType)' called when server was not active");
		}
		else
		{
			TargetShowLoading(target, loadingType);
		}
	}

	[Server]
	public void ServerHideLoadingToTarget(NetworkConnection target, LoadingType loadingType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideLoadingToTarget(Mirror.NetworkConnection,LoadingType)' called when server was not active");
		}
		else
		{
			TargetHideLoading(target, loadingType);
		}
	}

	[ClientRpc]
	private void RpcShowLoading(LoadingType loadingType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendRPCInternal("System.Void NetworkLoadingSync::RpcShowLoading(LoadingType)", -1922108178, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideLoading(LoadingType loadingType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendRPCInternal("System.Void NetworkLoadingSync::RpcHideLoading(LoadingType)", 1898705067, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideAll()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkLoadingSync::RpcHideAll()", 1782898776, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideLoadingImmediate(LoadingType loadingType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendRPCInternal("System.Void NetworkLoadingSync::RpcHideLoadingImmediate(LoadingType)", 1354733756, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideAllImmediate()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkLoadingSync::RpcHideAllImmediate()", -1889335481, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpdateReason(string reason)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(reason);
		SendRPCInternal("System.Void NetworkLoadingSync::RpcUpdateReason(System.String)", -1703004464, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetShowLoading(NetworkConnection target, LoadingType loadingType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendTargetRPCInternal(target, "System.Void NetworkLoadingSync::TargetShowLoading(Mirror.NetworkConnection,LoadingType)", 3658225, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetHideLoading(NetworkConnection target, LoadingType loadingType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendTargetRPCInternal(target, "System.Void NetworkLoadingSync::TargetHideLoading(Mirror.NetworkConnection,LoadingType)", -1740327674, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetHideAll(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void NetworkLoadingSync::TargetHideAll(Mirror.NetworkConnection)", -1575195523, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerShowSavingPanel()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerShowSavingPanel()' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			PauseMenuManager.Instance?.ShowSavingPanel();
		}
		RpcShowSavingPanel();
	}

	[Server]
	public void ServerHideSavingPanel()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkLoadingSync::ServerHideSavingPanel()' called when server was not active");
			return;
		}
		if (NetworkClient.isConnected)
		{
			PauseMenuManager.Instance?.HideSavingPanel();
		}
		RpcHideSavingPanel();
	}

	[ClientRpc]
	private void RpcShowSavingPanel()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkLoadingSync::RpcShowSavingPanel()", 573454236, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcHideSavingPanel()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void NetworkLoadingSync::RpcHideSavingPanel()", 692044407, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestShowLoading(LoadingType loadingType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestShowLoading__LoadingType(loadingType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendCommandInternal("System.Void NetworkLoadingSync::CmdRequestShowLoading(LoadingType)", 1170500230, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestHideLoading(LoadingType loadingType)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestHideLoading__LoadingType(loadingType);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_LoadingType(writer, loadingType);
		SendCommandInternal("System.Void NetworkLoadingSync::CmdRequestHideLoading(LoadingType)", 1121317187, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public static void ShowOnAllClients(LoadingType loadingType)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerShowLoading(loadingType);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void HideOnAllClients(LoadingType loadingType)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerHideLoading(loadingType);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void HideAllOnAllClients()
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerHideAll();
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void HideImmediateOnAllClients(LoadingType loadingType)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerHideLoadingImmediate(loadingType);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void HideAllImmediateOnAllClients()
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerHideAllImmediate();
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void RequestShow(LoadingType loadingType)
	{
		if (Instance != null)
		{
			Instance.CmdRequestShowLoading(loadingType);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı!");
		}
	}

	public static void RequestHide(LoadingType loadingType)
	{
		if (Instance != null)
		{
			Instance.CmdRequestHideLoading(loadingType);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı!");
		}
	}

	public static void OnPlayerJoining(NetworkConnection joiningConnection)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerOnPlayerJoining(joiningConnection);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void OnPlayerJoined(NetworkConnection joinedConnection)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerOnPlayerJoined(joinedConnection);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void OnPlayerLeft(NetworkConnection leftConnection)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerOnPlayerLeft(leftConnection);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public static void OnPlayerSceneLoaded(NetworkConnection connection)
	{
		if (Instance != null && Instance.isServer)
		{
			Instance.ServerOnPlayerSceneLoaded(connection);
		}
		else
		{
			Debug.LogWarning("[NetworkLoadingSync] Instance bulunamadı veya server değil!");
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcShowLoading__LoadingType(LoadingType loadingType)
	{
		if (!base.isServer)
		{
			LoadingManagerUI.Show(loadingType);
		}
	}

	protected static void InvokeUserCode_RpcShowLoading__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowLoading called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcShowLoading__LoadingType(GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_RpcHideLoading__LoadingType(LoadingType loadingType)
	{
		if (!base.isServer)
		{
			LoadingManagerUI.Hide(loadingType);
		}
	}

	protected static void InvokeUserCode_RpcHideLoading__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideLoading called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcHideLoading__LoadingType(GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_RpcHideAll()
	{
		if (!base.isServer)
		{
			LoadingManagerUI.HideAll();
		}
	}

	protected static void InvokeUserCode_RpcHideAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideAll called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcHideAll();
		}
	}

	protected void UserCode_RpcHideLoadingImmediate__LoadingType(LoadingType loadingType)
	{
		if (!base.isServer)
		{
			LoadingManagerUI.HideImmediate(loadingType);
		}
	}

	protected static void InvokeUserCode_RpcHideLoadingImmediate__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideLoadingImmediate called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcHideLoadingImmediate__LoadingType(GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_RpcHideAllImmediate()
	{
		if (!base.isServer)
		{
			LoadingManagerUI.HideAllImmediate();
		}
	}

	protected static void InvokeUserCode_RpcHideAllImmediate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideAllImmediate called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcHideAllImmediate();
		}
	}

	protected void UserCode_RpcUpdateReason__String(string reason)
	{
		if (!base.isServer)
		{
			LoadingManagerUI.UpdateReason(reason);
		}
	}

	protected static void InvokeUserCode_RpcUpdateReason__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateReason called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcUpdateReason__String(reader.ReadString());
		}
	}

	protected void UserCode_TargetShowLoading__NetworkConnection__LoadingType(NetworkConnection target, LoadingType loadingType)
	{
		LoadingManagerUI.Show(loadingType);
	}

	protected static void InvokeUserCode_TargetShowLoading__NetworkConnection__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetShowLoading called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_TargetShowLoading__NetworkConnection__LoadingType(null, GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_TargetHideLoading__NetworkConnection__LoadingType(NetworkConnection target, LoadingType loadingType)
	{
		LoadingManagerUI.Hide(loadingType);
	}

	protected static void InvokeUserCode_TargetHideLoading__NetworkConnection__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetHideLoading called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_TargetHideLoading__NetworkConnection__LoadingType(null, GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_TargetHideAll__NetworkConnection(NetworkConnection target)
	{
		LoadingManagerUI.HideAll();
	}

	protected static void InvokeUserCode_TargetHideAll__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetHideAll called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_TargetHideAll__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcShowSavingPanel()
	{
		if (!base.isServer)
		{
			PauseMenuManager.Instance?.ShowSavingPanel();
		}
	}

	protected static void InvokeUserCode_RpcShowSavingPanel(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowSavingPanel called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcShowSavingPanel();
		}
	}

	protected void UserCode_RpcHideSavingPanel()
	{
		if (!base.isServer)
		{
			PauseMenuManager.Instance?.HideSavingPanel();
		}
	}

	protected static void InvokeUserCode_RpcHideSavingPanel(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideSavingPanel called on server.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_RpcHideSavingPanel();
		}
	}

	protected void UserCode_CmdRequestShowLoading__LoadingType(LoadingType loadingType)
	{
		ServerShowLoading(loadingType);
	}

	protected static void InvokeUserCode_CmdRequestShowLoading__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestShowLoading called on client.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_CmdRequestShowLoading__LoadingType(GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	protected void UserCode_CmdRequestHideLoading__LoadingType(LoadingType loadingType)
	{
		ServerHideLoading(loadingType);
	}

	protected static void InvokeUserCode_CmdRequestHideLoading__LoadingType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestHideLoading called on client.");
		}
		else
		{
			((NetworkLoadingSync)obj).UserCode_CmdRequestHideLoading__LoadingType(GeneratedNetworkCode._Read_LoadingType(reader));
		}
	}

	static NetworkLoadingSync()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::CmdRequestShowLoading(LoadingType)", InvokeUserCode_CmdRequestShowLoading__LoadingType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::CmdRequestHideLoading(LoadingType)", InvokeUserCode_CmdRequestHideLoading__LoadingType, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcShowLoading(LoadingType)", InvokeUserCode_RpcShowLoading__LoadingType);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcHideLoading(LoadingType)", InvokeUserCode_RpcHideLoading__LoadingType);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcHideAll()", InvokeUserCode_RpcHideAll);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcHideLoadingImmediate(LoadingType)", InvokeUserCode_RpcHideLoadingImmediate__LoadingType);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcHideAllImmediate()", InvokeUserCode_RpcHideAllImmediate);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcUpdateReason(System.String)", InvokeUserCode_RpcUpdateReason__String);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcShowSavingPanel()", InvokeUserCode_RpcShowSavingPanel);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::RpcHideSavingPanel()", InvokeUserCode_RpcHideSavingPanel);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::TargetShowLoading(Mirror.NetworkConnection,LoadingType)", InvokeUserCode_TargetShowLoading__NetworkConnection__LoadingType);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::TargetHideLoading(Mirror.NetworkConnection,LoadingType)", InvokeUserCode_TargetHideLoading__NetworkConnection__LoadingType);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkLoadingSync), "System.Void NetworkLoadingSync::TargetHideAll(Mirror.NetworkConnection)", InvokeUserCode_TargetHideAll__NetworkConnection);
	}
}
