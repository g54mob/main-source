using Unity.Netcode;
using UnityEngine;

public class ObjectOwnershipHelper : NetworkBehaviour
{
	public static ObjectOwnershipHelper Singleton;

	private void Awake()
	{
		if (!Singleton)
		{
			Singleton = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	[ServerRpc(RequireOwnership = false)]
	public void RequestOwnershipOfAPickUp_ServerRPC(ulong _clientID, ulong _objectID)
	{
		NetworkManager networkManager = base.NetworkManager;
		if ((object)networkManager != null && networkManager.IsListening)
		{
			if (__rpc_exec_stage != __RpcExecStage.Execute && (networkManager.IsClient || networkManager.IsHost))
			{
				ServerRpcParams serverRpcParams = default(ServerRpcParams);
				FastBufferWriter bufferWriter = __beginSendServerRpc(1354317305u, serverRpcParams, RpcDelivery.Reliable);
				BytePacker.WriteValueBitPacked(bufferWriter, _clientID);
				BytePacker.WriteValueBitPacked(bufferWriter, _objectID);
				__endSendServerRpc(ref bufferWriter, 1354317305u, serverRpcParams, RpcDelivery.Reliable);
			}
			if (__rpc_exec_stage == __RpcExecStage.Execute && (networkManager.IsServer || networkManager.IsHost))
			{
				__rpc_exec_stage = __RpcExecStage.Send;
				NetworkManager.Singleton.SpawnManager.SpawnedObjects[_objectID].ChangeOwnership(_clientID);
			}
		}
	}

	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	protected override void __initializeRpcs()
	{
		__registerRpc(1354317305u, __rpc_handler_1354317305, "RequestOwnershipOfAPickUp_ServerRPC");
		base.__initializeRpcs();
	}

	private static void __rpc_handler_1354317305(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
		NetworkManager networkManager = target.NetworkManager;
		if ((object)networkManager != null && networkManager.IsListening)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out ulong value);
			ByteUnpacker.ReadValueBitPacked(reader, out ulong value2);
			target.__rpc_exec_stage = __RpcExecStage.Execute;
			((ObjectOwnershipHelper)target).RequestOwnershipOfAPickUp_ServerRPC(value, value2);
			target.__rpc_exec_stage = __RpcExecStage.Send;
		}
	}

	protected internal override string __getTypeName()
	{
		return "ObjectOwnershipHelper";
	}
}
