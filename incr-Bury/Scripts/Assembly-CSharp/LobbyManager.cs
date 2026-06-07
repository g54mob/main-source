using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : NetworkBehaviour
{
	[SerializeField]
	private SceneType currSceneType = SceneType.LobbyScene;

	[SerializeField]
	private GameObject playerObject_Prefab;

	[SerializeField]
	public GameObject playerSpawnPoint;

	private void Start()
	{
		NetworkManager.Singleton.SceneManager.OnLoadComplete += OnSceneLoaded;
		SpawnPlayerObject_ServerRPC(NetworkManager.Singleton.LocalClientId);
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		NetworkManager.Singleton.SceneManager.OnLoadComplete -= OnSceneLoaded;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L) && currSceneType == SceneType.LobbyScene)
		{
			ChangeScene("Level_Test");
		}
	}

	private void OnSceneLoaded(ulong _clientID, string _sceneName, LoadSceneMode _mode)
	{
		Debug.Log($"Client {_clientID} has finished loading the {_sceneName} scene.");
	}

	public void ChangeScene(string _sceneName)
	{
		if (_sceneName == "GameLobby")
		{
			currSceneType = SceneType.LobbyScene;
		}
		else
		{
			currSceneType = SceneType.GameLevelScene;
		}
		NetworkManager.Singleton.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
	}

	[ServerRpc(RequireOwnership = false)]
	private void SpawnPlayerObject_ServerRPC(ulong _clientID)
	{
		NetworkManager networkManager = base.NetworkManager;
		if ((object)networkManager != null && networkManager.IsListening)
		{
			if (__rpc_exec_stage != __RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
			{
				ServerRpcParams serverRpcParams = default(ServerRpcParams);
				FastBufferWriter bufferWriter = __beginSendServerRpc(4082411635u, serverRpcParams, RpcDelivery.Reliable);
				BytePacker.WriteValueBitPacked(bufferWriter, _clientID);
				__endSendServerRpc(ref bufferWriter, 4082411635u, serverRpcParams, RpcDelivery.Reliable);
			}
			if (__rpc_exec_stage == __RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				__rpc_exec_stage = __RpcExecStage.Send;
				Object.Instantiate(playerObject_Prefab, playerSpawnPoint.transform.position, Quaternion.identity).GetComponent<NetworkObject>().SpawnAsPlayerObject(_clientID);
			}
		}
	}

	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	protected override void __initializeRpcs()
	{
		__registerRpc(4082411635u, __rpc_handler_4082411635, "SpawnPlayerObject_ServerRPC");
		base.__initializeRpcs();
	}

	private static void __rpc_handler_4082411635(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if ((object)networkManager != null && networkManager.IsListening)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out ulong value);
			target.__rpc_exec_stage = __RpcExecStage.Execute;
			((LobbyManager)target).SpawnPlayerObject_ServerRPC(value);
			target.__rpc_exec_stage = __RpcExecStage.Send;
		}
	}

	protected internal override string __getTypeName()
	{
		return "LobbyManager";
	}
}
